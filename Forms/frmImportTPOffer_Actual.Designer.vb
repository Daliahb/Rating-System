<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportTPOffer_Actual
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblRow = New System.Windows.Forms.Label()
        Me.lblRowNotxt = New System.Windows.Forms.Label()
        Me.cmbCompanyPoints = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.btnSelectFile = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFileName
        '
        Me.txtFileName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFileName.Location = New System.Drawing.Point(150, 155)
        Me.txtFileName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFileName.Multiline = True
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(300, 62)
        Me.txtFileName.TabIndex = 125
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblRow)
        Me.Panel1.Controls.Add(Me.lblRowNotxt)
        Me.Panel1.Controls.Add(Me.cmbCompanyPoints)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.cmbClientCode)
        Me.Panel1.Controls.Add(Me.txtFileName)
        Me.Panel1.Controls.Add(Me.btnSelectFile)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(480, 325)
        Me.Panel1.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(150, 79)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(299, 22)
        Me.TextBox1.TabIndex = 136
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 83)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 135
        Me.Label4.Text = "Tariff"
        '
        'lblRow
        '
        Me.lblRow.AutoSize = True
        Me.lblRow.Location = New System.Drawing.Point(153, 226)
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(17, 16)
        Me.lblRow.TabIndex = 134
        Me.lblRow.Text = "1"
        Me.lblRow.Visible = False
        '
        'lblRowNotxt
        '
        Me.lblRowNotxt.AutoSize = True
        Me.lblRowNotxt.Location = New System.Drawing.Point(13, 226)
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
        Me.cmbCompanyPoints.Location = New System.Drawing.Point(150, 44)
        Me.cmbCompanyPoints.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbCompanyPoints.Name = "cmbCompanyPoints"
        Me.cmbCompanyPoints.Size = New System.Drawing.Size(299, 24)
        Me.cmbCompanyPoints.TabIndex = 133
        Me.cmbCompanyPoints.ValueMember = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 49)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 16)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Company Point"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 117)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 16)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Tariff Date"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(150, 112)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(299, 22)
        Me.DateTimePicker1.TabIndex = 129
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
        Me.cmbClientCode.Location = New System.Drawing.Point(150, 9)
        Me.cmbClientCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(299, 24)
        Me.cmbClientCode.TabIndex = 127
        Me.cmbClientCode.ValueMember = "ID"
        '
        'btnSelectFile
        '
        Me.btnSelectFile.Location = New System.Drawing.Point(10, 155)
        Me.btnSelectFile.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSelectFile.Name = "btnSelectFile"
        Me.btnSelectFile.Size = New System.Drawing.Size(117, 27)
        Me.btnSelectFile.TabIndex = 124
        Me.btnSelectFile.Text = "Select file"
        Me.btnSelectFile.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.btnCompare)
        Me.Panel2.Controls.Add(Me.btnCheck)
        Me.Panel2.Controls.Add(Me.btnImport)
        Me.Panel2.Location = New System.Drawing.Point(0, 258)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(479, 62)
        Me.Panel2.TabIndex = 78
        '
        'btnCompare
        '
        Me.btnCompare.Enabled = False
        Me.btnCompare.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompare.Location = New System.Drawing.Point(320, 16)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(98, 38)
        Me.btnCompare.TabIndex = 4
        Me.btnCompare.Text = "Compare"
        Me.btnCompare.UseVisualStyleBackColor = True
        '
        'btnCheck
        '
        Me.btnCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheck.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheck.Location = New System.Drawing.Point(61, 16)
        Me.btnCheck.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(98, 38)
        Me.btnCheck.TabIndex = 2
        Me.btnCheck.Text = "Check Excel Columns"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.Location = New System.Drawing.Point(190, 16)
        Me.btnImport.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(98, 38)
        Me.btnImport.TabIndex = 0
        Me.btnImport.Text = "Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
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
        'frmImportTPOffer_Actual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 332)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmImportTPOffer_Actual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import New TP Offer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtFileName As TextBox
    Friend WithEvents Panel1 As Panel
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
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnCompare As Button
End Class
