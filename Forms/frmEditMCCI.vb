Public Class frmEditMCCI

    Dim enumOPTP As New Enumerators.OPTP
    Dim strTariff As String, strCode As String, intMC As Integer, intCI As Integer
    Dim lNotiID As Long
    Public boolSaved As Boolean

    Public Sub New(strTariff As String, strCode As String, intMC As Integer, intCI As Integer, enumOPTP As Enumerators.OPTP, lNotiID As Long)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.strCode = strCode
        Me.strTariff = strTariff
        Me.intCI = intCI
        Me.intMC = intMC
        Me.enumOPTP = enumOPTP
        Me.lNotiID = lNotiID

    End Sub

    Private Sub frmAddClientPoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SetControls()

    End Sub

    Sub SetControls()
        Me.lblCode.Text = strCode
        Me.lblTariff.Text = strTariff
        Me.txtCI.Text = intCI.ToString
        Me.txtMC.Text = intMC.ToString
    End Sub

    Public Function CheckValidation() As Boolean
        Try
            Dim boolError As Boolean = True

            If Not txtMC.Text.Length = 0 Then
                ErrorProvider1.SetError(txtMC, "")
            Else
                ErrorProvider1.SetError(txtMC, "Please insert a valid value in MC field.")
                boolError = False
            End If

            If Not txtCI.Text.Length = 0 Then
                ErrorProvider1.SetError(txtCI, "")
            Else
                ErrorProvider1.SetError(txtCI, "Please insert a valid value in CI field.")
                boolError = False
            End If

            Return boolError
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If CheckValidation() Then
            Dim boolError As Boolean
            boolError = odbaccess.EditMCCI(lNotiID, strCode, CInt(txtMC.Text), CInt(txtCI.Text), enumOPTP)
            If boolError Then
                MsgBox("Operation done successfully.")
                boolSaved = True
                Close()
            Else
                MsgBox("An Error Occured!")
            End If
        End If
    End Sub

    Private Sub txtMC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMC.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtCI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCI.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class