Public Class frmCompanies

    Dim boolCheckStatus, boolActive As Boolean
    Dim ds As New DataSet

    Private Sub FrmClientsPoints_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim intRowIndex As Integer

        Try
            DataGridView1.Rows.Clear()
            GenerateCriteria()
            ds = odbaccess.GetCompanies(boolCheckStatus, boolActive)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = DataGridView1.Rows.Add
                        With DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = dr.Item("CompanyCode")
                            .Cells(2).Value = dr.Item("Billing_Email")
                            .Cells(3).Value = dr.Item("Rates_Email")
                            .Cells(4).Value = GetCompanyPoints(Enumerators.OPTP.OP, CLng(dr.Item("ID")))
                            .Cells(5).Value = GetCompanyPoints(Enumerators.OPTP.TP, CLng(dr.Item("ID")))
                            .Cells(6).Value = dr.Item("AccountManager")

                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkPoint_CheckedChanged(sender As Object, e As EventArgs) Handles chkStatus.CheckedChanged
        GroupBox1.Enabled = chkStatus.Checked

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

    Private Sub EditCompanyPointToolStripMenuItem_Click(sender As Object, e As EventArgs)
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

        If chkStatus.Checked Then
            boolCheckStatus = True
            If rbActive.Checked Then
                boolActive = True
            Else
                boolActive = False
            End If
        Else
            boolCheckStatus = False

        End If

    End Sub

    Public Function GetCompanyPoints(enumOPTP As Enumerators.OPTP, lCompanyID As Long) As String
        Dim strCompanies As String = ""
        For Each dr As DataRow In ds.Tables(1).Rows
            If CLng(dr.Item("FK_Client")) = lCompanyID And CType(dr.Item("enumOPTP"), Enumerators.OPTP) = enumOPTP Then
                strCompanies = strCompanies & dr.Item("CompanyPoint").ToString
                strCompanies = strCompanies & vbCrLf
            End If
        Next
        If strCompanies.Length > 0 Then
            strCompanies = strCompanies.Substring(0, strCompanies.Length - 1)
            ' strCompanies = strCompanies.Remove(, "vbCrLf")
        End If
        Return strCompanies
    End Function
End Class