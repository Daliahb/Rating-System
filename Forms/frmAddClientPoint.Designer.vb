<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddClientPoint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCompanyPoint = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbOP = New System.Windows.Forms.RadioButton()
        Me.rbTP = New System.Windows.Forms.RadioButton()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Provider"
        '
        'cmbClientCode
        '
        Me.cmbClientCode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbClientCode.DisplayMember = "Country"
        Me.cmbClientCode.DropDownHeight = 400
        Me.cmbClientCode.DropDownWidth = 200
        Me.cmbClientCode.FormattingEnabled = True
        Me.cmbClientCode.IntegralHeight = False
        Me.cmbClientCode.Location = New System.Drawing.Point(129, 24)
        Me.cmbClientCode.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(298, 24)
        Me.cmbClientCode.TabIndex = 0
        Me.cmbClientCode.ValueMember = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 94)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 16)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Company Point"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbType.DisplayMember = "ID"
        Me.cmbType.DropDownHeight = 400
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.DropDownWidth = 200
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.IntegralHeight = False
        Me.cmbType.Location = New System.Drawing.Point(129, 57)
        Me.cmbType.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(298, 24)
        Me.cmbType.TabIndex = 1
        Me.cmbType.ValueMember = "ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Type"
        '
        'txtCompanyPoint
        '
        Me.txtCompanyPoint.Location = New System.Drawing.Point(129, 94)
        Me.txtCompanyPoint.Name = "txtCompanyPoint"
        Me.txtCompanyPoint.Size = New System.Drawing.Size(298, 22)
        Me.txtCompanyPoint.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbOP)
        Me.GroupBox1.Controls.Add(Me.rbTP)
        Me.GroupBox1.Location = New System.Drawing.Point(129, 133)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(298, 46)
        Me.GroupBox1.TabIndex = 134
        Me.GroupBox1.TabStop = False
        '
        'rbOP
        '
        Me.rbOP.AutoSize = True
        Me.rbOP.Checked = True
        Me.rbOP.Location = New System.Drawing.Point(18, 18)
        Me.rbOP.Margin = New System.Windows.Forms.Padding(4)
        Me.rbOP.Name = "rbOP"
        Me.rbOP.Size = New System.Drawing.Size(46, 20)
        Me.rbOP.TabIndex = 0
        Me.rbOP.TabStop = True
        Me.rbOP.Text = "OP"
        Me.rbOP.UseVisualStyleBackColor = True
        '
        'rbTP
        '
        Me.rbTP.AutoSize = True
        Me.rbTP.Location = New System.Drawing.Point(184, 18)
        Me.rbTP.Margin = New System.Windows.Forms.Padding(4)
        Me.rbTP.Name = "rbTP"
        Me.rbTP.Size = New System.Drawing.Size(43, 20)
        Me.rbTP.TabIndex = 1
        Me.rbTP.Text = "TP"
        Me.rbTP.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(233, 215)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 34)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(129, 215)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 34)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmAddClientPoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 261)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCompanyPoint)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbClientCode)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmAddClientPoint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Company Point"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbClientCode As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCompanyPoint As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbOP As RadioButton
    Friend WithEvents rbTP As RadioButton
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
