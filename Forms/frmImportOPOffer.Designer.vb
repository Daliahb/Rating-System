<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportOPOffer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblRow = New System.Windows.Forms.Label()
        Me.lblRowNotxt = New System.Windows.Forms.Label()
        Me.cmbCompanyPoints = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbFull = New System.Windows.Forms.RadioButton()
        Me.rbPartial = New System.Windows.Forms.RadioButton()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.btnSelectFile = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFileName
        '
        Me.txtFileName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(160, 181)
        Me.txtFileName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFileName.Multiline = True
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(300, 62)
        Me.txtFileName.TabIndex = 125
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(204, 5)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 38)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblRow)
        Me.Panel1.Controls.Add(Me.lblRowNotxt)
        Me.Panel1.Controls.Add(Me.cmbCompanyPoints)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.cmbClientCode)
        Me.Panel1.Controls.Add(Me.txtFileName)
        Me.Panel1.Controls.Add(Me.btnSelectFile)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 363)
        Me.Panel1.TabIndex = 1
        '
        'lblRow
        '
        Me.lblRow.AutoSize = True
        Me.lblRow.Location = New System.Drawing.Point(160, 277)
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(17, 16)
        Me.lblRow.TabIndex = 134
        Me.lblRow.Text = "1"
        Me.lblRow.Visible = False
        '
        'lblRowNotxt
        '
        Me.lblRowNotxt.AutoSize = True
        Me.lblRowNotxt.Location = New System.Drawing.Point(19, 277)
        Me.lblRowNotxt.Name = "lblRowNotxt"
        Me.lblRowNotxt.Size = New System.Drawing.Size(126, 16)
        Me.lblRowNotxt.TabIndex = 134
        Me.lblRowNotxt.Text = "Reading row no."
        Me.lblRowNotxt.Visible = False
        '
        'cmbCompanyPoints
        '
        Me.cmbCompanyPoints.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbCompanyPoints.DisplayMember = "ID"
        Me.cmbCompanyPoints.DropDownHeight = 400
        Me.cmbCompanyPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCompanyPoints.DropDownWidth = 200
        Me.cmbCompanyPoints.FormattingEnabled = True
        Me.cmbCompanyPoints.IntegralHeight = False
        Me.cmbCompanyPoints.Location = New System.Drawing.Point(163, 47)
        Me.cmbCompanyPoints.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbCompanyPoints.Name = "cmbCompanyPoints"
        Me.cmbCompanyPoints.Size = New System.Drawing.Size(298, 24)
        Me.cmbCompanyPoints.TabIndex = 133
        Me.cmbCompanyPoints.ValueMember = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 54)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 16)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Company Point"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 91)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Tariff Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(160, 86)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(300, 22)
        Me.DateTimePicker1.TabIndex = 129
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbFull)
        Me.GroupBox1.Controls.Add(Me.rbPartial)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 119)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(451, 46)
        Me.GroupBox1.TabIndex = 128
        Me.GroupBox1.TabStop = False
        '
        'rbFull
        '
        Me.rbFull.AutoSize = True
        Me.rbFull.Checked = True
        Me.rbFull.Location = New System.Drawing.Point(9, 15)
        Me.rbFull.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbFull.Name = "rbFull"
        Me.rbFull.Size = New System.Drawing.Size(108, 20)
        Me.rbFull.TabIndex = 0
        Me.rbFull.TabStop = True
        Me.rbFull.Text = "Full Update"
        Me.rbFull.UseVisualStyleBackColor = True
        '
        'rbPartial
        '
        Me.rbPartial.AutoSize = True
        Me.rbPartial.Location = New System.Drawing.Point(156, 15)
        Me.rbPartial.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbPartial.Name = "rbPartial"
        Me.rbPartial.Size = New System.Drawing.Size(130, 20)
        Me.rbPartial.TabIndex = 1
        Me.rbPartial.Text = "Partial Update"
        Me.rbPartial.UseVisualStyleBackColor = True
        '
        'cmbClientCode
        '
        Me.cmbClientCode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbClientCode.DisplayMember = "Country"
        Me.cmbClientCode.DropDownHeight = 400
        Me.cmbClientCode.DropDownWidth = 200
        Me.cmbClientCode.FormattingEnabled = True
        Me.cmbClientCode.IntegralHeight = False
        Me.cmbClientCode.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmbClientCode.Location = New System.Drawing.Point(163, 9)
        Me.cmbClientCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(298, 24)
        Me.cmbClientCode.TabIndex = 127
        Me.cmbClientCode.ValueMember = "ID"
        '
        'btnSelectFile
        '
        Me.btnSelectFile.Location = New System.Drawing.Point(10, 181)
        Me.btnSelectFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSelectFile.Name = "btnSelectFile"
        Me.btnSelectFile.Size = New System.Drawing.Size(129, 27)
        Me.btnSelectFile.TabIndex = 124
        Me.btnSelectFile.Text = "Select file"
        Me.btnSelectFile.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnCheck)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnImport)
        Me.Panel2.Location = New System.Drawing.Point(46, 312)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(381, 43)
        Me.Panel2.TabIndex = 78
        '
        'btnCheck
        '
        Me.btnCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheck.Location = New System.Drawing.Point(66, 5)
        Me.btnCheck.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(112, 38)
        Me.btnCheck.TabIndex = 2
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Location = New System.Drawing.Point(66, 5)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(112, 38)
        Me.btnImport.TabIndex = 0
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Provider"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmImportOPOffer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 370)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmImportOPOffer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import OP Offer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtFileName As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbFull As RadioButton
    Friend WithEvents rbPartial As RadioButton
    Friend WithEvents cmbClientCode As ComboBox
    Friend WithEvents btnSelectFile As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnImport As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents cmbCompanyPoints As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCheck As Button
    Friend WithEvents lblRow As Label
    Friend WithEvents lblRowNotxt As Label
End Class
