Public Class FrmProviderDefault
    Dim lClientID As Long
    Public oProviderDefaults As ProviderDefaults
    Public boolSaved As Boolean
    Public isLoaded, isChanged, isNew As Boolean

    Public Sub New(lClientID As Long, strClientCompany As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lClientID = lClientID
        Me.lblProviderPoint.Text = strClientCompany
    End Sub

    Private Sub FrmProviderDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        oProviderDefaults = odbaccess.GetProviderDefaults(Me.lClientID)
        If Not oProviderDefaults Is Nothing Then
            SetControls()
        Else
            oProviderDefaults = New ProviderDefaults
            isNew = True
            Me.lblNewMSG.Visible = True
        End If
        isLoaded = True
    End Sub

    Public Sub SetControls()
        With Me.oProviderDefaults
            Me.txtDate.Text = .strDateFormat
            Me.txtDateCol.Text = .strDateCol
            Me.txtDelete.Text = .strDelete
            Me.txtIncrease.Text = .strIncrease
            Me.txtDecrease.Text = .strDecrease
            Me.txtCodeCol.Text = .strCodeCol
            Me.txtOperatorCol.Text = .strOperatorCol
            Me.txtNew.Text = .strNew
            Me.txtRateCol.Text = .strRateCol
            Me.txtSame.Text = .strSame
            Me.txtStatusCol.Text = .strStatusCol
            Me.txtRowNo.Text = .intRowNo.ToString
        End With
    End Sub

    Public Sub FillObject()
        With Me.oProviderDefaults
            .lClientID = Me.lClientID
            .strDateFormat = Me.txtDate.Text
            .strDateCol = Me.txtDateCol.Text
            .strDelete = Me.txtDelete.Text
            .strIncrease = Me.txtIncrease.Text
            .strDecrease = Me.txtDecrease.Text
            .strCodeCol = Me.txtCodeCol.Text
            .strOperatorCol = Me.txtOperatorCol.Text
            .strNew = Me.txtNew.Text
            .strRateCol = Me.txtRateCol.Text
            .strSame = Me.txtSame.Text
            .strStatusCol = Me.txtStatusCol.Text
            .intRowNo = CInt(Me.txtRowNo.Text)
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If isNew OrElse isChanged Then
            FillObject()
            If odbaccess.SaveProviderDefaults(oProviderDefaults) Then
                boolSaved = True
                MsgBox("Values saved successfully.")
                Me.Close()
            Else
                MsgBox("An Error Occured!")
            End If
        Else
            boolSaved = True
            '   MsgBox("Values saved successfully.")
            Me.Close()
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