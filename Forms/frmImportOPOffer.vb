Imports ExcelApplication = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.ComponentModel
Imports RatingSystem
Imports MySql.Data.MySqlClient


Public Class frmImportOPOffer

    Public enumEditAdd As New Enumerators.EditAdd
    Public lClientID, lCompanyPointID, lNotificationID As Long
    Public enumFullPartially As Enumerators.FullPartial
    Public boolError, isLoaded, boolNotFirstTime As Boolean
    Public filename As String = ""
    Dim excel As Excel.Application = New Excel.Application
    Dim worksheet As Excel.Worksheet
    Dim xlWorkBook As Excel.Workbook
    Dim sql As New System.Text.StringBuilder
    Dim dscompanyPoints As DataSet
    Dim enumStatus As New Enumerators.Rate_Notification_Status
    Dim enumOPTP As New Enumerators.OPTP
    Dim oProviderDefaults As ProviderDefaults

#Region "Controls Events"
    Public Sub New(enumOpTp As Enumerators.OPTP)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumOpTp = enumOpTp
    End Sub

    Private Sub frmImportOPOffer_Load(sender As Object, e As EventArgs) Handles Me.Load
        FillDatasets()
        isLoaded = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSelectFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectFile.Click
        ErrorProvider1.SetError(txtFileName, "")
        If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            filename = Me.OpenFileDialog1.FileName
            Me.txtFileName.Text = filename
        End If
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Try
            Dim strTableName As String
            If CheckValidation() Then
                If MsgBox("Are you sure you want to import this file?") = MsgBoxResult.No Then
                    Return
                End If
                '   GetdataFromExcel()
                Me.lClientID = CLng(Me.cmbClientCode.SelectedValue)
                Me.lCompanyPointID = CLng(Me.cmbCompanyPoints.SelectedValue)
                If Me.rbFull.Checked Then
                    Me.enumFullPartially = Enumerators.FullPartial.Full
                Else
                    Me.enumFullPartially = Enumerators.FullPartial.Partially
                End If

                Dim ds As DataSet
                ds = odbaccess.GetTPRateNotificationID(lClientID, lCompanyPointID, enumFullPartially, Me.DateTimePicker1.Value, False)

                If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                    Me.lNotificationID = CInt(ds.Tables(0).Rows(0).Item(0))
                    Me.enumStatus = CType(ds.Tables(0).Rows(0).Item(1), Enumerators.Rate_Notification_Status)
                    'if ID=0 and Status=0 then there is a already noti. in temp 
                    If lNotificationID = 0 And enumStatus = 0 Then
                        If MsgBox("There is already temperory rate notification for this Client Point, Do you want to replace it with this one?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            ds = odbaccess.GetTPRateNotificationID(lClientID, lCompanyPointID, enumFullPartially, Me.DateTimePicker1.Value, True)
                            If Not ds Is Nothing AndAlso Not ds.Tables.Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                                Me.lNotificationID = CInt(ds.Tables(0).Rows(0).Item(0))
                                Me.enumStatus = CType(ds.Tables(0).Rows(0).Item(1), Enumerators.Rate_Notification_Status)
                                If lNotificationID > 0 Then
                                    Select Case enumStatus
                                        Case Enumerators.Rate_Notification_Status.Current
                                            strTableName = "r_op_current_rates"
                                        Case Enumerators.Rate_Notification_Status.Temperory
                                            strTableName = "r_op_temp_rates"
                                    End Select
                                    ImportOffer(strTableName)
                                End If
                            Else
                                    MsgBox("An error occured!")
                            End If
                        Else
                            Return 'if no.. dont replace the temp notification already in DB
                        End If
                    ElseIf lNotificationID > 0 Then
                        Select Case enumStatus
                            Case Enumerators.Rate_Notification_Status.Current
                                strTableName = "r_op_current_rates"
                            Case Enumerators.Rate_Notification_Status.Temperory
                                strTableName = "r_op_temp_rates"
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
        If Not Me.cmbClientCode.SelectedValue Is Nothing Then
            Dim ofrm As New FrmProviderDefault(Me.cmbClientCode.SelectedValue, Me.cmbClientCode.Text)
            ofrm.ShowDialog()
            If ofrm.boolSaved Then
                oProviderDefaults = ofrm.oProviderDefaults
                Me.btnCheck.Visible = False
            End If
        End If

    End Sub

    Private Sub cmbClientCode_SelectedIndexChanged(sender As Object, e As EventArgs)

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
            If Me.cmbClientCode.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbClientCode, "Please select provider from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbClientCode, "")
            End If
            If Me.cmbCompanyPoints.SelectedIndex = -1 Then
                ErrorProvider1.SetError(cmbCompanyPoints, "Please select company point from the list.")
                boolError = False
            Else
                ErrorProvider1.SetError(cmbCompanyPoints, "")
            End If
            Return boolError
        Catch ex As Exception

        End Try
    End Function

    Public Sub FillDatasets()

        If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
            Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
            Me.cmbClientCode.DisplayMember = "CompanyCode"
            Me.cmbClientCode.ValueMember = "ID"
        Else
            gDsMembers = odbaccess.GetClientsDS
            If Not gDsMembers Is Nothing AndAlso Not gDsMembers.Tables.Count = 0 AndAlso Not gDsMembers.Tables(0).Rows.Count = 0 Then
                Me.cmbClientCode.DataSource = gDsMembers.Tables(0)
                Me.cmbClientCode.DisplayMember = "CompanyCode"
                Me.cmbClientCode.ValueMember = "ID"
            End If
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmbClientCode_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbClientCode.SelectedIndexChanged

    End Sub

    Private Sub ImportOffer(strTableName As String)
        Try
            Dim strCode, strDestination, strPrice, strClientStatus, strStartDate As String
            Dim boolError As Boolean

            excel.Visible = True
            Dim ExcelPath As String = filename
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            worksheet = excel.Worksheets(1)

            '  Dim x As Double
            '   x = 100 / Me.worksheet.UsedRange.Rows.Count
            '   Dim row As Integer = 3
            Dim CodeCol, DestinationCol, PriceCol, ChangeCol, StartDateCol As String
            '  Dim strBillingIncrement As String

            CodeCol = oProviderDefaults.strCodeCol
            DestinationCol = oProviderDefaults.strOperatorCol
            PriceCol = oProviderDefaults.strRateCol
            ChangeCol = oProviderDefaults.strStatusCol
            StartDateCol = oProviderDefaults.strDateCol

            sql = New System.Text.StringBuilder
            If Me.worksheet.Rows.Count >= 1 And (Not strTableName Is Nothing AndAlso Not strTableName.Length = 0) Then

                lblRowNotxt.Visible = True
                lblRow.Visible = True

                sql.Append("INSERT INTO " & strTableName & "(`FK_RateNotification`,`CityCode`,`Rate`,`ClientStatus`,`Client_Effective_Date`,`Destination`)  VALUES ")

                For rCnt = oProviderDefaults.intRowNo To Me.worksheet.UsedRange.Rows.Count
                    ' x += x
                    '   If x < 100 Then
                    '   Me.ProgressBar1.Value = CInt(x)
                    'End If
                    If Not Me.worksheet.Range(CodeCol & rCnt).Value() Is Nothing Then
                        strCode = Me.worksheet.Range(CodeCol & rCnt).Value().ToString.Trim
                    Else
                        '  Code = "''"
                        Exit For
                    End If

                    If Not Me.worksheet.Range(DestinationCol & rCnt).Value() Is Nothing Then
                        strDestination = Me.worksheet.Range(DestinationCol & rCnt).Value().ToString
                    Else
                        strDestination = "''"
                    End If

                    If Not Me.worksheet.Range(PriceCol & rCnt).Value() Is Nothing Then
                        strPrice = Me.worksheet.Range(PriceCol & rCnt).Value().ToString
                    Else
                        strPrice = "0.0"
                    End If

                    If Not Me.worksheet.Range(ChangeCol & rCnt).Value() Is Nothing Then
                        strClientStatus = Me.worksheet.Range(ChangeCol & rCnt).Value().ToString
                    Else
                        strClientStatus = "''"
                    End If

                    If Not Me.worksheet.Range(StartDateCol & rCnt).Value() Is Nothing Then
                        strStartDate = CDate(Me.worksheet.Range(StartDateCol & rCnt).Value()).ToString("yyyy-MM-dd")
                    Else
                        strStartDate = Now().ToString("yyyy-MM-dd")
                    End If

                    Me.lblRow.Text = rCnt
                    '  strBillingIncrement = "60-60"
                    sql.Append("(" & Me.lNotificationID & ",'" & strCode & "'," & strPrice & ",'" & strClientStatus & "','" & strStartDate & "','" & strDestination & "'),")
                Next
            End If
            '   Me.ProgressBar1.Value = 100
            excel.Workbooks.Close()
            excel.Quit()

            boolError = odbaccess.importdata(sql.ToString.Substring(0, sql.ToString.Length - 1))

            If boolError Then

                If odbaccess.FillCountryCode(Me.lNotificationID, enumOPTP) Then
                    MsgBox("Operation done successfully.")
                    filename = ""
                    Me.txtFileName.Text = ""
                    lblRowNotxt.Visible = False
                    lblRow.Visible = False
                    Me.btnCheck.Visible = True
                Else
                    MsgBox("An error occured while filling countries codes.")
                End If

                '  Me.ProgressBar1.Value = 0
            Else
                MsgBox("An error occured!")
            End If
            Me.btnImport.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message & "  " & ex.StackTrace)
        End Try
    End Sub

    Private Sub cmbClientCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbClientCode.SelectedValueChanged
        If isLoaded Then
            If Not Me.cmbClientCode.SelectedValue Is Nothing Then
                dscompanyPoints = odbaccess.getCompanyPoints(Me.enumOpTp, Me.cmbClientCode.SelectedValue)
                If Not dscompanyPoints Is Nothing AndAlso Not dscompanyPoints.Tables.Count = 0 Then
                    Me.cmbCompanyPoints.DataSource = dscompanyPoints.Tables(0)
                    Me.cmbCompanyPoints.DisplayMember = "ClientPoint"
                    Me.cmbCompanyPoints.ValueMember = "ID"
                End If
            End If
        End If

    End Sub
#End Region

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(Me.cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(Me.cmbClientCode)
    End Sub
End Class