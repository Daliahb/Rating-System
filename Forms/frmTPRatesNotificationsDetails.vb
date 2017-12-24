Public Class frmTPRatesNotificationsDetails

    Dim lNotiID As Long
    Dim dFromDate, dToDate As Date
    Dim boolDate As Boolean
    Dim enumStatus As Enumerators.Rate_Notification_Status
    Dim ds As New DataSet
    Dim strTariff As String

    Public Sub New(lNotiID As Long, enumStatus As Enumerators.Rate_Notification_Status, strTariff As String, strDate As String, strStatus As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lNotiID = lNotiID
        Me.enumStatus = enumStatus
        Me.strTariff = strTariff

        lblStatus.Text = strStatus
        lblTariff.Text = strTariff
        lblTariffDate.Text = strDate
    End Sub

    Private Sub FrmClientsPoints_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillDataGrid()
        If Me.enumStatus = Enumerators.Rate_Notification_Status.Temperory Then
            Me.DataGridView1.ContextMenuStrip = ContextMenuStrip1
        Else
            Me.DataGridView1.ContextMenuStrip = Nothing
        End If
    End Sub

    Private Sub EditMCCIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditMCCIToolStripMenuItem.Click
        Dim strCode As String
        Dim intMC, intCI As Integer

        If Not Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim dr As DataGridViewRow = Me.DataGridView1.SelectedRows(0)
            strCode = dr.Cells("Destination Code").Value
            Try
                intMC = CInt(dr.Cells("MC").Value)
                intCI = CInt(dr.Cells("CI").Value)
                Dim ofrmEditMCCI As New frmEditMCCI(strTariff, strCode, intMC, intCI, Enumerators.OPTP.TP, lNotiID)
                ofrmEditMCCI.showdialog()
                If ofrmEditMCCI.boolSaved Then
                    dr.Cells("MC").Value = ofrmEditMCCI.txtMC.Text
                    dr.Cells("CI").Value = ofrmEditMCCI.txtCI.Text
                End If

            Catch ex As Exception

            End Try

        End If
    End Sub

    Public Sub FillDataGrid()
        '  Dim intRowIndex, intColIndex As Integer
        Try
            ds = odbaccess.GetTPRatesNotificationDetails(lNotiID)
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then

                DataGridView1.DataSource = ds.Tables(0)

                'For i As Integer = 0 To ds.Tables(0).Columns.Count - 1
                '    intColIndex = Me.DataGridView1.Columns.Add(ds.Tables(0).Columns(i).ColumnName, ds.Tables(0).Columns(i).ColumnName)
                'Next
                'For Each dr As DataRow In ds.Tables(0).Rows
                '    Try
                '        intRowIndex = DataGridView1.Rows.Add
                '        With DataGridView1.Rows(intRowIndex)
                '            For x As Integer = 0 To Me.DataGridView1.Columns.Count - 1
                '                .Cells(x).Value = dr.Item(x)
                '            Next
                '        End With
                '    Catch ex As Exception

                '    End Try
                'Next
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class