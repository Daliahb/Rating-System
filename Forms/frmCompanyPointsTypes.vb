Public Class frmCompanyPointsTypes

    Dim isChanged, isLoaded, isRowAdded, boolError, isSaved As Boolean
    Dim ds As New DataSet
    Dim ar() As String
    Dim intRowIndex As Integer

    Private Sub FrmClientsPoints_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillDataGrid()
        isLoaded = True
    End Sub


    Private Sub fillDataGrid()
        Try
            ds = odbaccess.GetCompaniesPointsTypes
            If Not ds Is Nothing AndAlso Not ds.Tables().Count = 0 AndAlso Not ds.Tables(0).Rows.Count = 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    Try
                        intRowIndex = DataGridView1.Rows.Add
                        With DataGridView1.Rows(intRowIndex)
                            .Cells(0).Value = dr.Item("ID")
                            .Cells(1).Value = dr.Item("PointType")
                        End With
                    Catch ex As Exception

                    End Try
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If isChanged And Not isSaved Then
            If MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Save()
            Else
                Close()
            End If
        Else
            Close()
        End If

    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If isLoaded Then
            isChanged = True
            isSaved = False
        End If
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        If isLoaded Then
            isChanged = True
            isSaved = False
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If CheckValidation() Then
            Save()
        End If
    End Sub



    Public Sub Save()
        Dim strEditQuery As String = ""
        Dim strAddQuery As String = "insert into r_points_types (PointType) values "
        Try
            isSaved = True
            If isChanged Then
                For row As Integer = 0 To DataGridView1.Rows.Count - 2
                    If Not DataGridView1.Rows(row).Cells(0).Value Is Nothing And Not DataGridView1.Rows(row).Cells(1).Value Is Nothing Then
                        strEditQuery = strEditQuery + "update r_points_types set PointType = '" & DataGridView1.Rows(row).Cells(1).Value.ToString & "' where id = " & CInt(DataGridView1.Rows(row).Cells(0).Value) & " ; "
                    End If

                    'If row.Cells(0).Value Is Nothing And row.Cells(1).Value.ToString.Length > 0 Then
                    '    
                    'End If

                    If row > intRowIndex Then
                        If Not DataGridView1.Rows(row).Cells(1).Value = Nothing Then
                            isRowAdded = True
                            strAddQuery = strAddQuery + "('" & DataGridView1.Rows(row).Cells(1).Value.ToString & "'),"
                        End If

                    End If
                Next

                strAddQuery = strAddQuery.Substring(0, strAddQuery.Length - 1)

                boolError = odbaccess.ExecuteQuery(strEditQuery)
                If boolError Then
                    If isRowAdded Then
                        boolError = odbaccess.ExecuteQuery(strAddQuery)
                    End If
                End If
                If boolError Then
                    MsgBox("Operation done successfully.")
                Else
                    MsgBox("An error occured.")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Public Function CheckValidation()
        For Each row In DataGridView1.Rows
            If row.Cells(1).Value Is Nothing Then
                ErrorProvider1.SetError(DataGridView1, "Empty cells are not allowed, please insert a valid data.")
                Return False
            End If
        Next
        ErrorProvider1.SetError(DataGridView1, "")
        boolError = False
        Return True
    End Function
End Class