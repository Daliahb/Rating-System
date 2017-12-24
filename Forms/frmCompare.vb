Public Class frmCompare

    Public boolError, isLoaded As Boolean
    Dim enumOpTp As Enumerators.OPTP
    Dim dscompanyPoints As DataSet
    Dim lTariffID As Long
    Dim dsCompare As DataSet
    Dim lNotificationId, lPointID, lClientId As Long


    Public Sub New(enumOpTp As Enumerators.OPTP, Optional lClientId As Long = 0, Optional lPointID As Long = 0)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumOpTp = enumOpTp
        Me.lPointID = lPointID
        Me.lClientId = lClientId
    End Sub

    Private Sub frmCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDatasets()
        isLoaded = True
        If Not lClientId = 0 And Not lPointID = 0 Then
            Me.cmbClientCode.SelectedValue = lClientId
            Me.cmbCompanyPoints.SelectedValue = lPointID
        End If
    End Sub

#Region "Functions"
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

    Public Sub SelectRowinDG1(lID As Long)
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value = lID Then
                DataGridView1.Rows(row.Index).Cells(2).Selected = True
                Exit For
            End If
        Next
    End Sub

    Public Sub CheckIfAllApproved()
        Dim boolAllApproved As Boolean = True
        For Each dr As DataGridViewRow In DataGridView2.Rows
            If dr.Cells("dg2Approved").Value = False Then
                boolAllApproved = False
            End If
        Next
        If boolAllApproved Then
            btnUseAsCurrent.Enabled = True
            btnExcel.Enabled = True
        Else
            btnUseAsCurrent.Enabled = False
            btnExcel.Enabled = False
        End If
    End Sub
#End Region

#Region "Control Events"

    Public Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        Dim intCounter As Integer = 0
        Dim intRowIndex As Integer
        Dim lClientID As Long = 0
        Dim lCompanyPointID As Long = 0

        Try
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

            DataGridView1.Rows.Clear()
            DataGridView2.Rows.Clear()
            btnCompare.Enabled = False

            If cmbClientCode.SelectedValue Is Nothing Then
                Return
            End If

            If cmbCompanyPoints.SelectedValue Is Nothing Then
                Return
            End If

            If Not cmbClientCode.SelectedValue Is Nothing Then
                lClientID = CLng(cmbClientCode.SelectedValue)
            Else
                lClientID = 0
            End If

            If Not cmbCompanyPoints.SelectedValue Is Nothing Then
                lCompanyPointID = CLng(cmbCompanyPoints.SelectedValue)
            Else
                lCompanyPointID = 0
            End If

            dsCompare = odbaccess.GetNotificatonRepot(lClientID, lCompanyPointID, Enumerators.OPTP.TP)
            If Not dsCompare Is Nothing AndAlso Not dsCompare.Tables().Count = 0 AndAlso Not dsCompare.Tables(0).Rows.Count = 0 Then
                If dsCompare.Tables(0).Rows(0).Item(0) = 0 Then
                    MsgBox("There is no Actual Rates for this Tariff in the system. Please get the Tariff rates from Media Core.")
                ElseIf dsCompare.Tables(0).Rows(0).Item(0) = 1 Then
                    MsgBox("There is no Temperory Rates for this Tariff in the system. Please import the new notifications rates first.")

                Else


                    For Each dr As DataRow In dsCompare.Tables(1).Rows
                        Try
                            If rbWrong.Checked AndAlso (dr.Item("Changed") Is DBNull.Value OrElse CBool(dr.Item("Changed")) = False) Then
                                Continue For
                            Else
                                intRowIndex = DataGridView1.Rows.Add
                                With DataGridView1.Rows(intRowIndex)
                                    .Cells(0).Value = dr.Item("ID")
                                    .Cells(1).Value = intCounter + 1
                                    .Cells(2).Value = dr.Item("N_CityCode")
                                    .Cells(3).Value = dr.Item("N_Destination")
                                    If CType(dr.Item("enumCodeStatus"), Enumerators.CodeStatus) = Enumerators.CodeStatus.Blocked Then
                                        .Cells(4).Value = FormatNumber(dr.Item("N_Rate"), 5)
                                    Else
                                        .Cells(4).Value = dr.Item("N_Rate")
                                    End If

                                    .Cells(5).Value = dr.Item("ClientStatus")
                                    If Not dr.Item("N_ClientEffectiveDate") Is DBNull.Value Then
                                        .Cells(6).Value = CDate(dr.Item("N_ClientEffectiveDate")).ToString("yyyy-MM-dd")
                                    End If
                                    .Cells(7).Value = ""
                                    .Cells(8).Value = dr.Item("O_CityCode")
                                    .Cells(9).Value = dr.Item("O_Destination")
                                    .Cells(10).Value = dr.Item("O_Rate")
                                    .Cells(11).Value = dr.Item("ShortCode")
                                    .Cells(12).Value = dr.Item("ShortCodeRate")
                                    .Cells(13).Value = dr.Item("Status")
                                    .Cells(14).Value = dr.Item("ActiveDay")
                                    .Cells(15).Value = CDate(dr.Item("N_EffectiveDate")).ToString("yyyy-MM-dd")
                                    If Not dr.Item("Changed") Is DBNull.Value Then
                                        .Cells(16).Value = CBool(dr.Item("Changed"))
                                    End If
                                    .Cells(17).Value = dr.Item("MC")
                                    .Cells(18).Value = dr.Item("CI")
                                    intCounter += 1
                                End With
                            End If
                        Catch ex As Exception

                        End Try
                    Next
                    intCounter = 0
                    'Notification Report messages
                    If Not dsCompare.Tables.Count = 0 AndAlso Not dsCompare.Tables(2).Rows.Count = 0 Then
                        For Each dr As DataRow In dsCompare.Tables(2).Rows
                            Try
                                intRowIndex = DataGridView2.Rows.Add
                                With DataGridView2.Rows(intRowIndex)
                                    .Cells(0).Value = dr.Item("FK_TempRate")
                                    .Cells(1).Value = intCounter + 1
                                    .Cells(2).Value = dr.Item("CityCode")
                                    .Cells(3).Value = dr.Item("destination")
                                    .Cells(4).Value = dr.Item("Rate")
                                    .Cells(5).Value = dr.Item("Status")
                                    If Not dr.Item("Effective_Date") Is DBNull.Value Then
                                        .Cells(6).Value = CDate(dr.Item("Effective_Date")).ToString("yyyy-MM-dd")
                                    End If

                                    .Cells(7).Value = dr.Item("Message")
                                    .Cells(8).Value = CBool(dr.Item("isApproved"))
                                    .Cells("dgID").Value = dr.Item("ID")
                                    .Cells("dgNotifID").Value = dr.Item("NotiID")
                                    intCounter += 1
                                End With
                            Catch ex As Exception

                            End Try
                        Next
                        lNotificationId = CLng(dsCompare.Tables(2).Rows(0).Item("NotiID"))
                    End If

                    CheckIfAllApproved()
                End If
            End If
            btnCompare.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        If Not DataGridView2.SelectedRows.Count = 0 Then
            Dim lId As Integer
            lId = CInt(DataGridView2.SelectedRows(0).Cells(0).Value)
            SelectRowinDG1(lId)
        End If
    End Sub

    Private Sub ApproveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApproveToolStripMenuItem.Click
        If Not DataGridView2.SelectedRows.Count = 0 Then
            If MsgBox("Are you sure you want to Approve this message?") = MsgBoxResult.No Then
                Return
            End If
            Dim lId As Integer
            lId = CInt(DataGridView2.SelectedRows(0).Cells("dgID").Value)
            If odbaccess.ChangeApprovalStatus(lId, True, Enumerators.OPTP.TP, lNotificationId) Then
                '     MsgBox("Operation done successfully.")
                DataGridView2.SelectedRows(0).Cells("dg2Approved").Value = True

                CheckIfAllApproved()
            Else
                MsgBox("An error occured!")
            End If
        End If
    End Sub

    Private Sub SetAsNotApprovedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetAsNotApprovedToolStripMenuItem.Click
        If Not DataGridView2.SelectedRows.Count = 0 Then
            If MsgBox("Are you sure you want to change the status to Not Approved?") = MsgBoxResult.No Then
                Return
            End If
            Dim lId As Integer
            lId = CInt(DataGridView2.SelectedRows(0).Cells("dgID").Value)
            If odbaccess.ChangeApprovalStatus(lId, False, Me.enumOpTp, lNotificationId) Then
                '    MsgBox("Operation done successfully.")
                DataGridView2.SelectedRows(0).Cells("dg2Approved").Value = False

                CheckIfAllApproved()
            Else
                MsgBox("An error occured!")
            End If
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim oGenerateExcel As New GenerateExcel
        oGenerateExcel.GenerateExcelFile(dsCompare.Tables(1), cmbClientCode.Text, cmbCompanyPoints.Text)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(cmbClientCode)
    End Sub

    Private Sub ApproveAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApproveAllToolStripMenuItem.Click

        If MsgBox("Are you sure you want to Approve ALL message?") = MsgBoxResult.No Then
            Return
        End If

        If odbaccess.ChangeApprovalStatus(0, True, Me.enumOpTp, lNotificationId) Then
            For Each dr As DataGridViewRow In Me.DataGridView2.Rows
                dr.Cells(8).Value = True
            Next
            CheckIfAllApproved()
        Else
            MsgBox("An error occured!")
            End If

    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(cmbClientCode, e)
    End Sub
#End Region

End Class