Imports Microsoft.Office.Interop
Module Module1

    Public odbaccess As New DBAccess
    Public oTCPConnection As TCPControl
    '  Public oUser As New User
    Public gBackColor As New System.Drawing.Color
    Public gUser As New User
    Public gDsClientsBanks As DataSet
    Public gDsMembers As DataSet
    Public gConnectionString, gCountry As String
    Public gPurchaseEditPercentage As Double
    Public gAPISessionID As String = ""


    Sub New()
        'Real Online DB
        'gConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=maple_db_user;Password=5skqi5ygv3ciiBF9LDf362uW;Persist Security Info=True;database=voip_billing_system"
        'gCountry = "Jordan"

        'Test Online DB
        gConnectionString = "server=mapleteletech-tools.cyhrjka02xij.eu-west-1.rds.amazonaws.com;port=3337;User Id=maple_db_user_dev;Password=xee1lahnaeyoa0iethaeJoo7;Persist Security Info=True;database=voip_billing_system_dev"
        gCountry = "Jordan"


        gUser.Id = 9
    End Sub

    Public Sub ExportToExcel(ByVal DataGridView1 As DataGridView)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer


        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        Dim x As Integer = 0
        'insert header
        For i = 0 To DataGridView1.Columns.Count - 1
            If DataGridView1.Columns(i).Visible Then
                xlWorkSheet.Cells(1, x + 1) = DataGridView1.Columns(i).HeaderText
                x += 1
            End If
        Next


        For i = 0 To DataGridView1.Rows.Count - 1
            x = 0
            For j = 0 To DataGridView1.ColumnCount - 1
                If DataGridView1.Columns(j).Visible Then
                    If Not DataGridView1(j, DataGridView1.Rows(i).Index).Value Is Nothing Then
                        xlWorkSheet.Cells(i + 2, x + 1) =
                                               DataGridView1(j, DataGridView1.Rows(i).Index).Value.ToString()
                    Else
                        xlWorkSheet.Cells(i + 2, x + 1) = ""
                    End If

                    x += 1
                End If
            Next

        Next
        xlWorkSheet.Columns.AutoFit()
        xlApp.Visible = True
    End Sub

    Public Sub AutoCompleteCombo_KeyUp(ByVal cbo As ComboBox, ByVal e As KeyEventArgs)
        Dim sTypedText As String
        Dim iFoundIndex As Integer
        Dim oFoundItem As Object
        Dim sFoundText As String
        Dim sAppendText As String

        'Allow select keys without Autocompleting
        Select Case e.KeyCode
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, Keys.Delete, Keys.Down
                Return
        End Select

        'Get the Typed Text and Find it in the list
        sTypedText = cbo.Text
        iFoundIndex = cbo.FindString(sTypedText)

        'If we found the Typed Text in the list then Autocomplete
        If iFoundIndex >= 0 Then

            'Get the Item from the list (Return Type depends if Datasource was bound 
            ' or List Created)
            oFoundItem = cbo.Items(iFoundIndex)

            'Use the ListControl.GetItemText to resolve the Name in case the Combo 
            ' was Data bound
            sFoundText = cbo.GetItemText(oFoundItem)

            'Append then found text to the typed text to preserve case
            sAppendText = sFoundText.Substring(sTypedText.Length)
            cbo.Text = sTypedText & sAppendText
            Try
                'Select the Appended Text
                cbo.SelectionStart = sTypedText.Length
                cbo.SelectionLength = sAppendText.Length
            Catch ex As Exception

            End Try

        End If

    End Sub

    Public Sub AutoCompleteCombo_Leave(ByVal cbo As ComboBox)
        Dim iFoundIndex As Integer

        iFoundIndex = cbo.FindStringExact(cbo.Text)

        cbo.SelectedIndex = iFoundIndex

    End Sub

End Module
