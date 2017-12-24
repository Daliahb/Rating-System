Public Class FrmClientsPoints

    Dim lProviderID, lTypeID As Long
    Dim enumOPTP As Enumerators.OPTP
    Dim ds As New DataSet

    Private Sub FrmClientsPoints_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDatasets()

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

        Dim dsRatesTypes As DataSet = odbaccess.PointsTypes
        If Not dsRatesTypes Is Nothing AndAlso Not dsRatesTypes.Tables.Count = 0 AndAlso Not dsRatesTypes.Tables(0).Rows.Count = 0 Then
            cmbType.DataSource = dsRatesTypes.Tables(0)
            cmbType.DisplayMember = "PointType"
            cmbType.ValueMember = "ID"
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim intRowIndex As Integer

        Try
            DataGridView1.Rows.Clear()
            GenerateCriteria()
            ds = odbaccess.GetCompaniesPoints(enumOPTP, lProviderID, lTypeID)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = DataGridView1.Rows.Add
                        With DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = dr.Item("CompanyCode")
                            .Cells(2).Value = dr.Item("CompanyPoint")
                            .Cells(3).Value = dr.Item("PointType")
                            .Cells(4).Value = dr.Item("TariffName")
                            .Cells(5).Value = CType(dr.Item("enumOPTP"), Enumerators.OPTP)
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

    Private Sub chkType_CheckedChanged(sender As Object, e As EventArgs) Handles chkType.CheckedChanged
        cmbType.Enabled = chkType.Checked
    End Sub

    Private Sub chkPoint_CheckedChanged(sender As Object, e As EventArgs) Handles chkPoint.CheckedChanged
        GroupBox1.Enabled = chkPoint.Checked

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Application.OpenForms().OfType(Of frmAddClientPoint).Any Then
            For Each frm As Form In Application.OpenForms
                If frm.Name.Equals("frmAddClientPoint") Then
                    frm.WindowState = FormWindowState.Normal
                End If
            Next
        Else
            Dim frm As New frmAddClientPoint(Enumerators.EditAdd.Add)
            frm.Show()
        End If
    End Sub

    Private Sub EditCompanyPointToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditCompanyPointToolStripMenuItem.Click
        If Not DataGridView1.SelectedCells.Count = 0 Then
            Dim RowIndex As Integer = DataGridView1.SelectedCells(0).RowIndex

            Dim dr As DataRow
            For Each dr In ds.Tables(0).Rows
                If CLng(dr.Item("ID")) = CLng(DataGridView1.SelectedRows(0).Cells(0).Value) Then
                    Exit For
                End If
            Next


            Dim frm As New frmAddClientPoint(Enumerators.EditAdd.Edit, dr)
            frm.ShowDialog()
            DataGridView1.Rows(RowIndex).Cells(1).Value = frm.cmbClientCode.Text
            DataGridView1.Rows(RowIndex).Cells(2).Value = frm.txtCompanyPoint.Text
            DataGridView1.Rows(RowIndex).Cells(3).Value = frm.cmbType.Text
            If frm.rbOP.Checked Then
                DataGridView1.Rows(RowIndex).Cells(4).Value = "OP"
            Else
                DataGridView1.Rows(RowIndex).Cells(4).Value = "TP"
            End If
        End If
    End Sub

    Public Sub GenerateCriteria()
        If chkPoint.Checked Then
            If rbOP.Checked Then
                enumOPTP = Enumerators.OPTP.OP
            Else
                enumOPTP = Enumerators.OPTP.TP
            End If
        Else
            enumOPTP = 0
        End If
        If chkProvider.Checked Then
            If Not cmbClientCode.SelectedValue Is Nothing Then
                lProviderID = cmbClientCode.SelectedValue
            Else
                lProviderID = 0
            End If
        Else
            lProviderID = 0
        End If

        If chkType.Checked Then
            If Not cmbType.SelectedValue Is Nothing Then
                lTypeID = cmbType.SelectedValue
            Else
                lTypeID = 0
            End If
        Else
            lTypeID = 0
        End If
    End Sub

End Class