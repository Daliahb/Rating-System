Public Class frmTPRatesNotifications

    Dim lProviderID, lStatusID As Long
    Dim dFromDate, dToDate As Date
    Dim boolDate As Boolean

    Dim ds As New DataSet

    Private Sub FrmClientsPoints_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDatasets()

    End Sub

    Public Sub FillDatasets()

        Dim dsTariffs As DataSet
        dsTariffs = odbaccess.GetTariffs(Enumerators.OPTP.TP)
        If Not dsTariffs Is Nothing AndAlso Not dsTariffs.Tables.Count = 0 AndAlso Not dsTariffs.Tables(0).Rows.Count = 0 Then
            cmbClientCode.DataSource = dsTariffs.Tables(0)
            cmbClientCode.DisplayMember = "TariffName"
            cmbClientCode.ValueMember = "ID"
        End If

        cmbStatus.DataSource = Nothing
        cmbStatus.Items.Add(New Obj("New", Enumerators.Rate_Notification_Status.Temperory))
        cmbStatus.Items.Add(New Obj("Actual", Enumerators.Rate_Notification_Status.Current))
        cmbStatus.Items.Add(New Obj("History", Enumerators.Rate_Notification_Status.Current_To_History))
        cmbStatus.ValueMember = "Value"
        cmbStatus.DisplayMember = "Name"
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim intRowIndex As Integer

        Try
            DataGridView1.Rows.Clear()
            GenerateCriteria()
            ds = odbaccess.GetTPRateNotifications(lProviderID, lStatusID, boolDate, dFromDate, dToDate)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = DataGridView1.Rows.Add
                        With DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = dr.Item("enumStatus")
                            .Cells(2).Value = dr.Item("CompanyCode")
                            .Cells(3).Value = dr.Item("CompanyPoint")
                            .Cells(4).Value = dr.Item("TariffName")
                            .Cells(5).Value = GetStatus(dr.Item("enumStatus"))
                            .Cells(6).Value = CType(dr.Item("enumFullPartial"), Enumerators.FullPartial)
                            .Cells(7).Value = CDate(dr.Item("Notification_Date")).ToString("dd/MM/yyyy")
                            .Cells(8).Value = "Show"
                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkProvider_CheckedChanged(sender As Object, e As EventArgs) Handles chkProvider.CheckedChanged
        cmbClientCode.Enabled = chkProvider.Checked
    End Sub

    Private Sub chkType_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatus.CheckedChanged
        cmbStatus.Enabled = chkStatus.Checked
    End Sub

    Private Sub chkDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkDate.CheckedChanged
        dtpFromDate.Enabled = chkDate.Checked
        dtpToDate.Enabled = chkDate.Checked
    End Sub

    Public Sub GenerateCriteria()
        If chkProvider.Checked Then
            If Not cmbClientCode.SelectedValue Is Nothing Then
                lProviderID = cmbClientCode.SelectedValue
            Else
                lProviderID = 0
            End If
        Else
            lProviderID = 0
        End If

        If chkStatus.Checked Then
            If Not cmbStatus.SelectedItem.value Is Nothing Then
                lStatusID = cmbStatus.SelectedItem.value
            Else
                lStatusID = 0
            End If
        Else
            lStatusID = 0
        End If

        If chkDate.Checked Then
            boolDate = True
            dFromDate = dtpFromDate.Value
            dToDate = dtpToDate.Value
        Else
            boolDate = False
        End If
    End Sub

    Public Function GetStatus(enumStatus As Enumerators.Rate_Notification_Status) As String
        Select Case enumStatus
            Case Enumerators.Rate_Notification_Status.Temperory
                Return "New"
            Case Enumerators.Rate_Notification_Status.Current
                Return "Actual"
            Case Enumerators.Rate_Notification_Status.Current_To_History
                Return "History from Actual"
            Case Enumerators.Rate_Notification_Status.Temp_To_History
                Return "History from New"
        End Select
        Return ""
    End Function


    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(cmbClientCode)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        Dim lID As Long
        Dim enumStatus, strTariff, strDate, strStatus As String
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 Then

            lID = CLng(DataGridView1.Rows(e.RowIndex).Cells(0).Value)
            strTariff = DataGridView1.Rows(e.RowIndex).Cells(4).Value.ToString
            strDate = DataGridView1.Rows(e.RowIndex).Cells(7).Value.ToString
            strStatus = DataGridView1.Rows(e.RowIndex).Cells(5).Value.ToString
            enumStatus = DataGridView1.Rows(e.RowIndex).Cells(1).Value.ToString

            Dim ofrmRateNotiDetails As New frmTPRatesNotificationsDetails(lID, enumStatus, strTariff, strDate, strStatus)
            ofrmRateNotiDetails.Show()
        End If
    End Sub
End Class