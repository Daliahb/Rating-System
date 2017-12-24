Public Class frmAddClientPoint

    Dim intResult As Integer
    Dim enumOPTP As New Enumerators.OPTP
    Dim dRow As DataRow
    Dim enumEditAdd As Enumerators.EditAdd
    Dim lID As Long

    Public Sub New(enumEditAdd As Enumerators.EditAdd, Optional dRow As DataRow = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.enumEditAdd = enumEditAdd
        Me.dRow = dRow
    End Sub

    Private Sub frmAddClientPoint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDatasets()

        If enumEditAdd = Enumerators.EditAdd.Edit Then
            SetControls()
        End If
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

    Function SetControls()
        cmbClientCode.SelectedValue = dRow.Item("FK_Client")
        cmbType.SelectedValue = dRow.Item("FK_PointType")
        txtCompanyPoint.Text = dRow.Item("CompanyPoint")
        If CType(dRow.Item("enumOPTP"), Enumerators.OPTP) = Enumerators.OPTP.OP Then
            rbOP.Checked = True
        Else
            rbTP.Checked = True
        End If
        lID = CLng(dRow.Item("ID"))
    End Function

    Public Sub ResetForm()

    End Sub

    Public Function CheckValidation() As Boolean
        Try
            Dim boolError As Boolean = True
            If Not cmbClientCode.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbClientCode, "")
            Else
                ErrorProvider1.SetError(cmbClientCode, "Please choose Provider from the list.")
                boolError = False
            End If
            If Not cmbType.SelectedValue Is Nothing Then
                ErrorProvider1.SetError(cmbType, "")
            Else
                ErrorProvider1.SetError(cmbType, "Please choose Point type from the list.")
                boolError = False
            End If

            If Not txtCompanyPoint.Text.Length = 0 Then
                ErrorProvider1.SetError(cmbType, "")
            Else
                ErrorProvider1.SetError(cmbType, "Please insert a valid value in the Company Point field.")
                boolError = False
            End If
            Return boolError
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If CheckValidation() Then

            If rbOP.Checked Then
                enumOPTP = Enumerators.OPTP.OP
            Else
                enumOPTP = Enumerators.OPTP.TP
            End If

            If enumEditAdd = Enumerators.EditAdd.Add Then
                intResult = odbaccess.InsertClientPoint(cmbClientCode.SelectedValue, cmbType.SelectedValue, txtCompanyPoint.Text, enumOPTP)
                Select Case intResult
                    Case 0
                        MsgBox("An Error Occured!")
                    Case -1
                        MsgBox("Company Point is already exists. (Provider + Point Type)")
                    Case > 0
                        MsgBox("Operation done successfully.")
                        ResetForm()
                End Select
            Else
                Dim boolError As Boolean
                boolError = odbaccess.EditClientPoint(lID, cmbClientCode.SelectedValue, cmbType.SelectedValue, txtCompanyPoint.Text, enumOPTP)
                If boolError Then
                    MsgBox("Operation done successfully.")
                    Close()
                Else
                    MsgBox("An Error Occured!")
                End If
            End If

        End If
    End Sub

    Private Sub cmbClientCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbClientCode.KeyUp
        AutoCompleteCombo_KeyUp(cmbClientCode, e)
    End Sub

    Private Sub cmbClientCode_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cmbClientCode.Leave
        AutoCompleteCombo_Leave(cmbClientCode)
    End Sub

End Class