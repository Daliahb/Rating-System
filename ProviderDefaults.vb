Public Class ProviderDefaults

    Public lClientID As Long
    Public strIncrease As String
    Public strDecrease As String
    Public strSame As String
    Public strDelete As String
    Public strNew As String
    Public strDateFormat As String
    Public strCodeCol As String
    Public strOperatorCol As String
    Public strRateCol As String
    Public strStatusCol As String
    Public strDateCol As String
    Public intRowNo As Integer
    Public strMCCol As String
    Public strCICol As String

    Public Sub FillProperties(dr As DataRow)
        With dr
            If Not dr.Item("Increase") Is DBNull.Value Then
                strIncrease = dr.Item("Increase").ToString
            End If

            If Not dr.Item("Decrease") Is DBNull.Value Then
                strDecrease = dr.Item("Decrease").ToString
            End If

            If Not dr.Item("Same") Is DBNull.Value Then
                strSame = dr.Item("Same").ToString
            End If

            If Not dr.Item("Delete") Is DBNull.Value Then
                strDelete = dr.Item("Delete").ToString
            End If

            If Not dr.Item("New") Is DBNull.Value Then
                strNew = dr.Item("New").ToString
            End If

            If Not dr.Item("DateFormat") Is DBNull.Value Then
                strDateFormat = dr.Item("DateFormat").ToString
            End If

            If Not dr.Item("CodeCol") Is DBNull.Value Then
                strCodeCol = dr.Item("CodeCol").ToString
            End If

            If Not dr.Item("OperatorCol") Is DBNull.Value Then
                strOperatorCol = dr.Item("OperatorCol").ToString
            End If

            If Not dr.Item("RateCol") Is DBNull.Value Then
                strRateCol = dr.Item("RateCol").ToString
            End If

            If Not dr.Item("StatusCol") Is DBNull.Value Then
                strStatusCol = dr.Item("StatusCol").ToString
            End If

            If Not dr.Item("DateCol") Is DBNull.Value Then
                strDateCol = dr.Item("DateCol").ToString
            End If

            If Not dr.Item("MCCol") Is DBNull.Value Then
                strMCCol = dr.Item("MCCol").ToString
            End If

            If Not dr.Item("CICol") Is DBNull.Value Then
                strCICol = dr.Item("CICol").ToString
            End If

            If Not dr.Item("RowNo") Is DBNull.Value Then
                intRowNo = CInt(dr.Item("RowNo"))
            End If
        End With

    End Sub
End Class


