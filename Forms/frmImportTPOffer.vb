Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.ComponentModel
Imports RatingSystem
Imports MySql.Data.MySqlClient


Public Class frmImportTPOffer

    Public enumEditAdd As New Enumerators.EditAdd
    Public lClientID, lCompanyPointID, lNotificationID, lTariffID As Long
    Public enumFullPartially As Enumerators.FullPartial
    Public boolError, isLoaded, boolNotFirstTime As Boolean
    Public filename As String = ""
    Dim excel As Excel.Application = New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim xlWorkBook As Excel.Workbook
    Dim sql As New System.Text.StringBuilder
    Dim dscompanyPoints As DataSet
    Dim enumNotificationStatus As New Enumerators.Rate_Notification_Status
    Dim enumOPTP As New Enumerators.OPTP
    Dim oProviderDefaults As ProviderDefaults

#Region "Controls Events"
    Public Sub New(enumOpTp As Enumerators.OPTP, enumNotificationStatus As Enumerators.Rate_Notification_Status)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumOPTP = enumOpTp
        Me.enumNotificationStatus = enumNotificationStatus

        If enumNotificationStatus = Enumerators.Rate_Notification_Status.Current Then
            lblNote.Visible = False
            Me.GroupBox1.Visible = False
            Text = "Import Actual TP Rates"
        End If
    End Sub

    Private Sub frmImportOPOffer_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillDatasets()
        isLoaded = True

        AddHandler oTCPConnection.ActualRatesMsg, AddressOf OnActualRatesMsgRecieved
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub btnSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click
        ErrorProvider1.SetError(txtFileName, "")
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            filename = OpenFileDialog1.FileName
            txtFileName.Text = filename
        End If
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Me.btnCompare.Enabled = True
        Me.btnGetActual.Enabled = True
        Try
            Dim strTableName As String
            If CheckValidation() Then
                If Not MsgBox("Are you sure you want to import this file?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Return
                End If
                '   GetdataFromExcel()
                lClientID = CLng(cmbClientCode.SelectedValue)
                lCompanyPointID = CLng(cmbCompanyPoints.SelectedValue)
                If rbFull.Checked Then
                    enumFullPartially = Enumerators.FullPartial.Full
                Else
                    enumFullPartially = Enumerators.FullPartial.Partially
                End If

                Dim ds As DataSet
                Dim intStatus As Integer
                ds = odbaccess.GetTPRateNotificationID(lClientID, lCompanyPointID, lTariffID, enumFullPartially, DateTimePicker1.Value, False, enumNotificationStatus)

                If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                    lNotificationID = CInt(ds.Tables(0).Rows(0).Item(1))
                    ' Me.enumStatus = CType(ds.Tables(0).Rows(0).Item(1), Enumerators.Rate_Notification_Status)
                    intStatus = CInt(ds.Tables(0).Rows(0).Item(0)) ' 0 = current rates, 1= there is already a temp data, -1 = new rate notification id was inserted

                    'if ID=0 and Status=0 then there is a already noti. in temp 
                    If intStatus = 1 Then
                        If MsgBox("There is already temperory rate notification for this Client Point, Do you want to replace it with this one?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            ds = odbaccess.GetTPRateNotificationID(lClientID, lCompanyPointID, lTariffID, enumFullPartially, DateTimePicker1.Value, True, enumNotificationStatus)
                            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                                lNotificationID = CInt(ds.Tables(0).Rows(0).Item(1))
                                '  Me.intStatus = CType(ds.Tables(0).Rows(0).Item(1), Enumerators.Rate_Notification_Status)
                                If lNotificationID > 0 Then
                                    Select Case enumNotificationStatus
                                        Case Enumerators.Rate_Notification_Status.Current
                                            strTableName = "r_tp_current_rates"
                                        Case Enumerators.Rate_Notification_Status.Temperory
                                            strTableName = "r_tp_temp_rates"
                                    End Select
                                    ImportOffer(strTableName)
                                End If
                            Else
                                MsgBox("An error occured!")
                            End If
                        Else
                            Return 'if no.. dont replace the temp notification already in DB
                        End If
                        'ElseIf intStatus = 0 Then
                        '    MsgBox("Please get the actual rates for this Tariff from Media Core.")
                    ElseIf intStatus = -1 And lNotificationID > 0 Then
                        Select Case enumNotificationStatus
                            Case Enumerators.Rate_Notification_Status.Current
                                strTableName = "r_tp_current_rates"
                            Case Enumerators.Rate_Notification_Status.Temperory
                                strTableName = "r_tp_temp_rates"
                        End Select
                        ImportOffer(strTableName)
                    End If
                Else 'if dataset was empty or nothing
                    MsgBox("An error occured!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If Not cmbClientCode.SelectedValue Is Nothing Then
            Select Case enumNotificationStatus
                Case Enumerators.Rate_Notification_Status.Current
                    Dim ofrm As New FrmProviderDefault_Current(cmbClientCode.SelectedValue, cmbClientCode.Text)
                    ofrm.ShowDialog()
                    If ofrm.boolSaved Then
                        oProviderDefaults = ofrm.oProviderDefaults
                        btnImport.Enabled = True
                    End If
                Case Enumerators.Rate_Notification_Status.Temperory
                    Dim ofrm As New FrmProviderDefault_Temp(cmbClientCode.SelectedValue, cmbClientCode.Text)
                    ofrm.ShowDialog()
                    If ofrm.boolSaved Then
                        oProviderDefaults = ofrm.oProviderDefaults
                        btnImport.Enabled = True
                    End If
            End Select

        End If

    End Sub

#End Region


#Region "Functions"
    Public Function CheckValidation() As Boolean
        Dim boolError = True
        Try

            If filename.Length = 0 OrElse (filename.Substring(filename.Length - 4, 4).ToLower <> "xlsx" And filename.Substring(filename.Length - 3, 3).ToLower <> "xls") Then
                ErrorProvider1.SetError(txtFileName, "Select a valid Excel file.")
                boolError = False
            Else
                ErrorProvider1.SetError(txtFileName, "")
            End If
            If cmbClientCode.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbClientCode, "Please select provider from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbClientCode, "")
            End If
            If cmbCompanyPoints.SelectedIndex = -1 Then
                ErrorProvider1.SetError(cmbCompanyPoints, "Please select company point from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbCompanyPoints, "")
            End If

            If Not lTariffID > 0 Then
                ErrorProvider1.SetError(TextBox1, "There should be a Tariff related to the company point.")
                boolError = False
            Else
                ErrorProvider1.SetError(TextBox1, "")
            End If


            Return boolError
        Catch ex As Exception
            Return False
        End Try
    End Function

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

    Private Sub btnGetActual_Click(sender As Object, e As EventArgs) Handles btnGetActual.Click
        Me.btnGetActual.Enabled = False
        Dim frm As New frmGetActualFromMC(enumOPTP)
        frm.lClientID = Me.cmbClientCode.SelectedValue
        frm.lCompanyPointID = Me.cmbCompanyPoints.SelectedValue
        frm.lTariffID = Me.lTariffID

        frm.GetNewRateNotificationID()

        'If frm.GetActual(lTariffID) Then
        'Me.btnCompare.Enabled = True
        '    Me.btnGetActual.Enabled = False
        'Else
        '    Me.btnGetActual.Enabled = True
        'End If
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        Dim frm As New frmCompare(enumOPTP, Me.cmbClientCode.SelectedValue, Me.cmbCompanyPoints.SelectedValue)
        frm.Show()
        frm.btnCompare_Click(Me, New EventArgs)

        Me.Close()
    End Sub

    Private Sub ImportOffer(strTableName As String)
        Try
            Dim strCode, strDestination, strPrice, strClientStatus, strStartDate, strCI, strMC As String
            Dim boolError As Boolean

            excel.Visible = True
            Dim ExcelPath As String = filename
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            worksheet = excel.Worksheets(1)

            '  Dim x As Double
            '   x = 100 / Me.worksheet.UsedRange.Rows.Count
            '   Dim row As Integer = 3
            Dim CodeCol, DestinationCol, PriceCol, ChangeCol, StartDateCol, MCCol, CICol As String
            '  Dim strBillingIncrement As String

            CodeCol = oProviderDefaults.strCodeCol
            DestinationCol = oProviderDefaults.strOperatorCol
            PriceCol = oProviderDefaults.strRateCol
            ChangeCol = oProviderDefaults.strStatusCol
            StartDateCol = oProviderDefaults.strDateCol
            MCCol = oProviderDefaults.strCICol
            CICol = oProviderDefaults.strCICol

            sql = New System.Text.StringBuilder
            If worksheet.Rows.Count >= 1 And (Not strTableName Is Nothing AndAlso Not strTableName.Length = 0) Then

                lblRowNotxt.Visible = True
                lblRow.Visible = True

                If enumNotificationStatus = Enumerators.Rate_Notification_Status.Temperory Then
                    sql.Append("INSERT INTO " & strTableName & "(`FK_RateNotification`,`CityCode`,`Rate`,`ClientStatus`,`Client_Effective_Date`,`Destination`)  VALUES ")
                Else
                    sql.Append("INSERT INTO " & strTableName & "(`FK_RateNotification`,`CityCode`,`Rate`,`ClientStatus`,`Client_Effective_Date`,`Destination`,MC,CI)  VALUES ")
                End If


                For rCnt = oProviderDefaults.intRowNo To worksheet.UsedRange.Rows.Count
                    ' x += x
                    '   If x < 100 Then
                    '   Me.ProgressBar1.Value = CInt(x)
                    'End If
                    If Not worksheet.Range(CodeCol & rCnt).Value() Is Nothing Then
                        strCode = worksheet.Range(CodeCol & rCnt).Value().ToString.Trim
                    Else
                        '  Code = "''"
                        Exit For
                    End If

                    If Not worksheet.Range(DestinationCol & rCnt).Value() Is Nothing Then
                        strDestination = worksheet.Range(DestinationCol & rCnt).Value().ToString
                    Else
                        strDestination = "''"
                    End If

                    If Not worksheet.Range(PriceCol & rCnt).Value() Is Nothing Then
                        strPrice = worksheet.Range(PriceCol & rCnt).Value().ToString
                    Else
                        strPrice = "0.0"
                    End If

                    If Not worksheet.Range(ChangeCol & rCnt).Value() Is Nothing Then
                        strClientStatus = worksheet.Range(ChangeCol & rCnt).Value().ToString
                    Else
                        strClientStatus = "''"
                    End If

                    If Not worksheet.Range(StartDateCol & rCnt).Value() Is Nothing Then
                        strStartDate = CDate(worksheet.Range(StartDateCol & rCnt).Value()).ToString("yyyy-MM-dd")
                    Else
                        strStartDate = Now().ToString("yyyy-MM-dd")
                    End If
                    Try
                        If Not worksheet.Range(MCCol & rCnt).Value() Is Nothing Then
                            strMC = CInt(worksheet.Range(MCCol & rCnt).Value())
                        Else
                            strMC = 1
                        End If

                        If Not worksheet.Range(CICol & rCnt).Value() Is Nothing Then
                            strCI = CInt(worksheet.Range(CICol & rCnt).Value())
                        Else
                            strCI = 1
                        End If
                    Catch ex As Exception

                    End Try


                    lblRow.Text = rCnt
                    '  strBillingIncrement = "60-60"

                    If enumNotificationStatus = Enumerators.Rate_Notification_Status.Temperory Then
                        sql.Append("(" & lNotificationID & ",'" & strCode & "'," & strPrice & ",'" & strClientStatus & "','" & strStartDate & "','" & strDestination & "'),")
                    Else
                        sql.Append("(" & lNotificationID & ",'" & strCode & "'," & strPrice & ",'" & strClientStatus & "','" & strStartDate & "','" & strDestination & "','" & strMC & "','" & strCI & "'),")
                    End If
                Next
            End If
            '   Me.ProgressBar1.Value = 100
            excel.Workbooks.Close()
            excel.Quit()

            boolError = odbaccess.ExecuteQuery(sql.ToString.Substring(0, sql.ToString.Length - 1))

            If boolError Then

                If odbaccess.FillCountryCode(lNotificationID, enumOPTP) Then
                    MsgBox("Operation done successfully.")
                    filename = ""
                    txtFileName.Text = ""
                    lblRowNotxt.Visible = False
                    lblRow.Visible = False
                    btnCheck.Visible = True
                    Me.btnGetActual.Enabled = True

                Else
                    MsgBox("An error occured while filling countries codes.")
                End If

                '  Me.ProgressBar1.Value = 0
            Else
                MsgBox("An error occured!")
            End If
            btnImport.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub


    Private Sub cmbClientCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbClientCode.SelectedValueChanged
        If isLoaded Then
            TextBox1.Text = ""
            lTariffID = 0
            btnImport.Enabled = False
            If Not cmbClientCode.SelectedValue Is Nothing Then
                dscompanyPoints = odbaccess.GetCompanyPoints(enumOPTP, cmbClientCode.SelectedValue)
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
#End Region

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(cmbClientCode)
    End Sub

    Public Sub OnActualRatesMsgRecieved(sender As TCPControl, isdone As Boolean)
        If isdone Then
            If odbaccess.FillCountryCode(lNotificationID, enumOPTP) Then
                MsgBox("Operation done successfully.")
                Me.btnGetActual.Enabled = False
                Me.btnCompare.Enabled = True
            Else
                MsgBox("An error occured while filling countries codes.")
            End If
        Else
            MsgBox("An error occured!")
            btnImport.Enabled = True
        End If

        ' Return True

    End Sub
End Class