Imports Microsoft.Office.Interop.Excel
Imports System.IO

Public Class GenerateExcel

    Public dInsertDate As Date
    Dim excel As Application = New Application
    Dim worksheet As Worksheet
    Dim oWorkBook As Workbook
    Dim RootDirectory As String

    '--- PDF Parameters---
    Dim PDFFile As String = "C:\Users\dalia\Desktop\invoices\Test.pdf"
    Dim pFormatType As XlFixedFormatType = XlFixedFormatType.xlTypePDF
    Dim pQuality As XlFixedFormatQuality = XlFixedFormatQuality.xlQualityMinimum
    Dim pIncludeDocProperties As Boolean = True
    Dim pIgnorePrintAreas As Boolean = True
    Dim pFrom As Object = Type.Missing
    Dim pTo As Object = Type.Missing
    Dim pOpenAfterPublish As Boolean = True
    Public boolEqual, isLoaded As Boolean

    Public Sub New()
        If My.Settings.RootDirectory.Length = 0 Then
            If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                Dim folderDlg As New FolderBrowserDialog With {
                    .SelectedPath = My.Settings.RootDirectory,
                    .ShowNewFolderButton = True,
                    .Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                }
                If (folderDlg.ShowDialog() = DialogResult.OK) Then

                    '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                    My.Settings.RootDirectory = folderDlg.SelectedPath
                End If
            Else
                Return
            End If

        End If
        'create a folder with today's date
        RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
        If (Not System.IO.Directory.Exists(RootDirectory)) Then
            System.IO.Directory.CreateDirectory(RootDirectory)
        End If
    End Sub

    Public Sub GenerateExcelFile(ByVal dt As System.Data.DataTable, strProvider As String, strCompanyPoint As String)
        Try
            excel.Visible = True
            Dim i As Integer
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
            Dim ExcelPath As String = System.Windows.Forms.Application.StartupPath & "\MC.xlsx"
            excel.Workbooks.Open(ExcelPath)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMinimized
            RootDirectory = My.Settings.RootDirectory + "/" + Now.ToString("dd-MM-yyyy")
            worksheet = excel.Worksheets(1)
            ' Dim strProvider As String = ""
            Dim row As Integer = 6

            ' Me.worksheet.Range("a" & 1).Value = "MC Report - " & Now().ToString("dd-MM-yyyy") & " - " & strProvider & " - " & strCompanyPoint
            i = 1
            For Each dr As DataRow In dt.Rows
                Try
                    With dr
                        If CBool(.Item("Changed")) = True Then
                            worksheet.Range("A" & i).Value = .Item("N_CityCode")
                            worksheet.Range("B" & i).Value = .Item("N_Destination")
                            worksheet.Range("C" & i).Value = CDbl(.Item("N_Rate"))
                            If CType(dr.Item("enumCodeStatus"), Enumerators.CodeStatus) = Enumerators.CodeStatus.Blocked Then
                                worksheet.Range("C" & i).Value = Format(CDbl(dr.Item("N_Rate")), "0.00000")
                            Else
                                worksheet.Range("C" & i).Value = dr.Item("N_Rate")
                            End If
                            worksheet.Range("D" & i).Value = .Item("Status")
                            worksheet.Range("E" & i).Value = .Item("ActiveDay")
                            '  Me.worksheet.Range("F" & i) =
                            worksheet.Range("G" & i).Value = .Item("MC")
                            worksheet.Range("H" & i).Value = .Item("CI")
                            worksheet.Range("I" & i).Value = 0
                            worksheet.Range("J" & i).Value = 1
                            worksheet.Range("K" & i).Value = 24
                            worksheet.Range("L" & i).Value = "t / f"
                            worksheet.Range("M" & i).Value = "t"

                            worksheet.Range("N" & i).Value = CDate(dr.Item("N_EffectiveDate")).ToString("yyyy-MM-dd")
                            worksheet.Range("O" & i).Value = "2037-12-31 23:59:59"
                            worksheet.Range("P" & i).Value = "00:00:00"
                            worksheet.Range("Q" & i).Value = "23:59:59"
                            worksheet.Range("R" & i).Value = "t"
                            worksheet.Range("S" & i).Value = "t"
                            worksheet.Range("T" & i).Value = "t"
                            worksheet.Range("U" & i).Value = "t"
                            worksheet.Range("V" & i).Value = "t"
                            worksheet.Range("W" & i).Value = "t"
                            worksheet.Range("X" & i).Value = "t"
                            worksheet.Range("Y" & i).Value = 0

                            i = i + 1
                        End If
                    End With
                Catch ex As Exception

                End Try
                '
            Next

            Dim strName As String
            strName = "MC Report - " & Now().ToString("dd-MM-yyyy") & " - " & strProvider & " - " & strCompanyPoint

            worksheet.SaveAs(Filename:=RootDirectory & "\" & strName)
            excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized
            'Me.worksheet.Range("a3:j6").Delete()

            ' ---- Generate PDF File ------


            If My.Settings.RootDirectory.Length = 0 Then
                If MsgBox("Please choose the Invoices directory. Do you want to do it now?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim folderDlg As New FolderBrowserDialog With {
                        .SelectedPath = My.Settings.RootDirectory,
                        .ShowNewFolderButton = True,
                        .Description = "Select a folder to save Invoices." & vbCrLf & "The current folder is: " & My.Settings.RootDirectory
                    }
                    If (folderDlg.ShowDialog() = DialogResult.OK) Then

                        '   Dim root As Environment.SpecialFolder = folderDlg.RootFolder
                        My.Settings.RootDirectory = folderDlg.SelectedPath
                    End If
                Else
                    Return
                End If

            End If

            'Dim PDFFile As String = RootDirectory & "\" & strName & ".pdf"
            'oWorkBook = excel.Workbooks(1)
            'If Not oWorkBook Is Nothing Then
            '    oWorkBook.ExportAsFixedFormat(pFormatType, PDFFile, pQuality,
            '                                  pIncludeDocProperties,
            '                                  pIgnorePrintAreas,
            '                                  pFrom, pTo, pOpenAfterPublish)
            'End If
            'oWorkBook.Close(False)
            'excel.Workbooks.Close()
            'excel.Quit()


        Catch ex As Exception
            'excel.Workbooks.Close()
            'excel.Quit()
            MsgBox(ex.Message)
        End Try

    End Sub

End Class
