Public Class FrmProviderDefault_Temp
    Dim lClientID As Long
    Public oProviderDefaults As ProviderDefaults
    Public boolSaved As Boolean
    Public isLoaded, isChanged, isNew As Boolean

    Public Sub New(lClientID As Long, strClientCompany As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lClientID = lClientID
        lblProviderPoint.Text = strClientCompany
    End Sub

    Private Sub FrmProviderDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        oProviderDefaults = odbaccess.GetProviderDefaults(lClientID)
        If Not oProviderDefaults Is Nothing Then
            SetControls()
        Else
            oProviderDefaults = New ProviderDefaults
            isNew = True
            lblNewMSG.Visible = True
        End If
        isLoaded = True
    End Sub

    Public Sub SetControls()
        With oProviderDefaults
            txtDate.Text = .strDateFormat
            txtDateCol.Text = .strDateCol
            txtDelete.Text = .strDelete
            txtIncrease.Text = .strIncrease
            txtDecrease.Text = .strDecrease
            txtCodeCol.Text = .strCodeCol
            txtOperatorCol.Text = .strOperatorCol
            txtNew.Text = .strNew
            txtRateCol.Text = .strRateCol
            txtSame.Text = .strSame
            txtStatusCol.Text = .strStatusCol
            txtRowNo.Text = .intRowNo.ToString
        End With
    End Sub

    Public Sub FillObject()
        With oProviderDefaults
            .lClientID = lClientID
            .strDateFormat = txtDate.Text
            .strDateCol = txtDateCol.Text
            .strDelete = txtDelete.Text
            .strIncrease = txtIncrease.Text
            .strDecrease = txtDecrease.Text
            .strCodeCol = txtCodeCol.Text
            .strOperatorCol = txtOperatorCol.Text
            .strNew = txtNew.Text
            .strRateCol = txtRateCol.Text
            .strSame = txtSame.Text
            .strStatusCol = txtStatusCol.Text
            .intRowNo = CInt(txtRowNo.Text)
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If isNew OrElse isChanged Then
            FillObject()
            If odbaccess.SaveProviderDefaults(oProviderDefaults) Then
                boolSaved = True
                MsgBox("Values saved successfully.")
                Close()
            Else
                MsgBox("An Error Occured!")
            End If
        Else
            boolSaved = True
            '   MsgBox("Values saved successfully.")
            Close()
        End If

    End Sub

    Private Sub TextBoxes_TextChanged(sender As Object, e As EventArgs) Handles txtCodeCol.TextChanged, txtDate.TextChanged, txtDateCol.TextChanged, txtDecrease.TextChanged, txtDelete.TextChanged, txtIncrease.TextChanged, txtNew.TextChanged, txtOperatorCol.TextChanged, txtRateCol.TextChanged, txtSame.TextChanged, txtStatusCol.TextChanged, txtRowNo.TextChanged
        If isLoaded Then
            isChanged = True
        End If
    End Sub

    Private Sub txtRowNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRowNo.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar)  Then
            e.Handled = True
        End If
    End Sub
End Class