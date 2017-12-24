Imports Newtonsoft.Json.Linq

Public Class frmGetActualFromMC

    Public boolError, isLoaded As Boolean
    Dim enumOpTp As Enumerators.OPTP
    Dim dscompanyPoints As DataSet
    Public lTariffID, lClientID, lCompanyPointID As Long
    Dim oAPIFunctions As New APIFunctions
    Dim dblRate As Double
    Dim dEffectiveDate, dEndDate As String
    Dim strDestination, strCityCode, strCountry As String
    Dim intMC, intCI As Integer
    Dim boolEnabled, boolAllowed As Boolean
    Dim Sql As New System.Text.StringBuilder
    Dim lNotificationID As Long = 0

    Public Sub New(enumOpTp As Enumerators.OPTP)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumOpTp = enumOpTp
    End Sub

    Private Sub frmGetActualFromMC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDatasets()
        isLoaded = True
        AddHandler oTCPConnection.ActualRatesMsg, AddressOf OnActualRatesMsgRecieved
    End Sub

    Public Sub FillDatasets()
        If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
            cmbClientCode.DataSource = gDsMembers.Tables(0)
            cmbClientCode.DisplayMember = "CompanyCode"
            cmbClientCode.ValueMember = "ID"
        Else
            gDsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                cmbClientCode.DataSource = gDsMembers.Tables(0)
                cmbClientCode.DisplayMember = "CompanyCode"
                cmbClientCode.ValueMember = "ID"
            End If
        End If

    End Sub

    Private Sub cmbClientCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbClientCode.SelectedValueChanged
        If isLoaded Then
            If Not cmbClientCode.SelectedValue Is Nothing Then
                dscompanyPoints = odbaccess.GetCompanyPoints(enumOpTp, cmbClientCode.SelectedValue)
                If Not dscompanyPoints Is Nothing AndAlso Not dscompanyPoints.Tables.Count = 0 Then
                    cmbCompanyPoints.DataSource = dscompanyPoints.Tables(0)
                    cmbCompanyPoints.DisplayMember = "CompanyPoint"
                    cmbCompanyPoints.ValueMember = "ID"
                End If
            End If
        End If

    End Sub

    Private Sub cmbCompanyPoints_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCompanyPoints.SelectedValueChanged
        If isLoaded Then
            For Each dr As DataRow In dscompanyPoints.Tables(0).Rows
                If dr.Item("id") = cmbCompanyPoints.SelectedValue Then
                    TextBox1.Text = dr.Item("TariffName").ToString
                    lTariffID = dr.Item("fk_Tariff")
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(cmbClientCode)
    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(cmbClientCode, e)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        boolError = False
        If cmbClientCode.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbClientCode, "Please choose provider from the list.")
            boolError = True
        Else
            ErrorProvider1.SetError(cmbClientCode, "")
        End If

        If cmbCompanyPoints.SelectedValue Is Nothing Then
            ErrorProvider1.SetError(cmbCompanyPoints, "Please choose company point from the list.")
            boolError = True
        Else
            ErrorProvider1.SetError(cmbCompanyPoints, "")
        End If

        If boolError Then
            Return
        End If

        btnImport.Enabled = False
        Me.lClientID = Me.cmbClientCode.SelectedValue
        Me.lCompanyPointID = Me.cmbCompanyPoints.SelectedValue
        '  GetActual(lTariffID)

        'lNotificationID = GetNewRateNotificationID()
        'If lNotificationID > 0 Then
        '    oTCPConnection.Send("GetActualRates|" & lTariffID & "|" & lNotificationID)
        'End If

        GetNewRateNotificationID()

    End Sub

    Public Function GetNewRateNotificationID() As Long
        Dim ds As DataSet
        Dim lNotificationID As Long = 0
        Dim intStatus As Integer

        ds = odbaccess.GetTPRateNotificationID(lClientID, lCompanyPointID, lTariffID, Enumerators.FullPartial.Full, Now(), False, Enumerators.Rate_Notification_Status.Current)

        If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
            lNotificationID = CInt(ds.Tables(0).Rows(0).Item(1))
            ' Me.enumStatus = CType(ds.Tables(0).Rows(0).Item(1), Enumerators.Rate_Notification_Status)
            intStatus = CInt(ds.Tables(0).Rows(0).Item(0)) ' 0 = current rates, 1= there is already a temp data, -1 = new rate notification id was inserted

            'if ID=0 and Status=0 then there is a already noti. in temp 
            If intStatus = -1 And lNotificationID > 0 Then
                '  Return lNotificationID

                oTCPConnection.Send("GetActualRates|" & lTariffID & "|" & lNotificationID)


            Else
                Return 0
            End If
        Else 'if dataset was empty or nothing
            MsgBox("An Error occured!")
            Return 0
        End If
    End Function

    Public Function GetActual(lTariffID As Long) As Boolean
        '1- Get Data from MC
        Dim jsonObject As JObject
        jsonObject = oAPIFunctions.GetTPRates(lTariffID)


        If Not jsonObject Is Nothing Then

            '2 get New Rate Notification Id

            lNotificationID = getNewRateNotificationID()
            If lNotificationID > 0 Then
                '3- Insert data from MC to DB
                Sql = New System.Text.StringBuilder
                Sql.Append("insert into r_tp_current_rates(`FK_RateNotification`,`Rate`,`Client_Effective_Date`,`End_Date`,`Destination`,`CityCode`,`MC`,`CI`,`Enabled`,`Allowed`) values ")

                Dim jsonArray As JArray = JArray.Parse(jsonObject.SelectToken("data").ToString)
                Try
                    For Each item As JArray In jsonArray
                        dblRate = CDbl(item(6).ToString)
                        dEffectiveDate = CDate(item(12)).ToString("yyyy-MM-dd")
                        dEndDate = CDate(item(13)).ToString("yyyy-MM-dd")
                        strDestination = item(21).ToString
                        strCityCode = item(5).ToString
                        intMC = CInt(item(8))
                        intCI = CInt(item(9))
                        boolEnabled = CBool(item(2))
                        boolAllowed = CBool(item(3))
                        '  Console.WriteLine(item(0).ToString & " " & item(1).ToString & " " & item(2).ToString & " " & item(3).ToString)

                        Sql.Append("(" & lNotificationID & ",'" & dblRate & "','" & dEffectiveDate & "','" & dEndDate & "','" & strDestination & "','" & strCityCode & "'," & intMC & ",'" & intCI & "','" & boolEnabled & "','" & boolAllowed & "'),")
                    Next

                    boolError = odbaccess.ExecuteQuery(Sql.ToString.Substring(0, Sql.ToString.Length - 1))

                    If boolError Then

                        If odbaccess.FillCountryCode(lNotificationID, enumOpTp) Then
                            MsgBox("Operation done successfully.")

                        Else
                            MsgBox("An error occured while filling countries codes.")
                        End If

                        '  Me.ProgressBar1.Value = 0
                    Else
                        MsgBox("An error occured!")
                    End If
                    btnImport.Enabled = True
                    Return True
                Catch ex As Exception
                    Return False
                End Try
                'MsgBox(jsonArray.ToString)
            End If
        End If
        Return False
    End Function

    Public Sub OnActualRatesMsgRecieved(sender As TCPControl, isdone As Boolean)
        If isdone Then
            ' MsgBox("Operation done successfully.")
            If odbaccess.FillCountryCode(lNotificationID, enumOpTp) Then
                MsgBox("Operation done successfully.")

            Else
                MsgBox("An error occured while filling countries codes.")
            End If
        Else
            MsgBox("An error occured!")
        End If
        btnImport.Enabled = True
        ' Return True
    End Sub
End Class