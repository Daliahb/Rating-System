<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientsPoints
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbOP = New System.Windows.Forms.RadioButton()
        Me.rbTP = New System.Windows.Forms.RadioButton()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.chkProvider = New System.Windows.Forms.CheckBox()
        Me.chkType = New System.Windows.Forms.CheckBox()
        Me.chkPoint = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditCompanyPointToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbClientCode
        '
        Me.cmbClientCode.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbClientCode.DisplayMember = "Country"
        Me.cmbClientCode.DropDownHeight = 400
        Me.cmbClientCode.DropDownWidth = 200
        Me.cmbClientCode.Enabled = False
        Me.cmbClientCode.FormattingEnabled = True
        Me.cmbClientCode.IntegralHeight = False
        Me.cmbClientCode.Location = New System.Drawing.Point(109, 15)
        Me.cmbClientCode.Margin = New System.Windows.Forms.Padding(9, 6, 9, 6)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(308, 24)
        Me.cmbClientCode.TabIndex = 137
        Me.cmbClientCode.ValueMember = "ID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbOP)
        Me.GroupBox1.Controls.Add(Me.rbTP)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(109, 73)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(308, 43)
        Me.GroupBox1.TabIndex = 138
        Me.GroupBox1.TabStop = False
        '
        'rbOP
        '
        Me.rbOP.AutoSize = True
        Me.rbOP.Checked = True
        Me.rbOP.Location = New System.Drawing.Point(27, 15)
        Me.rbOP.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
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
        Me.rbTP.Location = New System.Drawing.Point(181, 15)
        Me.rbTP.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.rbTP.Name = "rbTP"
        Me.rbTP.Size = New System.Drawing.Size(43, 20)
        Me.rbTP.TabIndex = 1
        Me.rbTP.Text = "TP"
        Me.rbTP.UseVisualStyleBackColor = True
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbType.DisplayMember = "ID"
        Me.cmbType.DropDownHeight = 400
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.DropDownWidth = 200
        Me.cmbType.Enabled = False
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.IntegralHeight = False
        Me.cmbType.Location = New System.Drawing.Point(109, 47)
        Me.cmbType.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(308, 24)
        Me.cmbType.TabIndex = 140
        Me.cmbType.ValueMember = "ID"
        '
        'chkProvider
        '
        Me.chkProvider.AutoSize = True
        Me.chkProvider.Location = New System.Drawing.Point(15, 16)
        Me.chkProvider.Name = "chkProvider"
        Me.chkProvider.Size = New System.Drawing.Size(93, 20)
        Me.chkProvider.TabIndex = 141
        Me.chkProvider.Text = "Company"
        Me.chkProvider.UseVisualStyleBackColor = True
        '
        'chkType
        '
        Me.chkType.AutoSize = True
        Me.chkType.Location = New System.Drawing.Point(15, 51)
        Me.chkType.Name = "chkType"
        Me.chkType.Size = New System.Drawing.Size(61, 20)
        Me.chkType.TabIndex = 142
        Me.chkType.Text = "Type"
        Me.chkType.UseVisualStyleBackColor = True
        '
        'chkPoint
        '
        Me.chkPoint.AutoSize = True
        Me.chkPoint.Location = New System.Drawing.Point(15, 87)
        Me.chkPoint.Name = "chkPoint"
        Me.chkPoint.Size = New System.Drawing.Size(64, 20)
        Me.chkPoint.TabIndex = 143
        Me.chkPoint.Text = "Point"
        Me.chkPoint.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.Column2, Me.Category, Me.Column1, Me.Column4, Me.Column3})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Location = New System.Drawing.Point(13, 125)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(915, 612)
        Me.DataGridView1.TabIndex = 144
        '
        'clID
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clID.DefaultCellStyle = DataGridViewCellStyle2
        Me.clID.HeaderText = "ID"
        Me.clID.Name = "clID"
        Me.clID.ReadOnly = True
        Me.clID.Visible = False
        Me.clID.Width = 80
        '
        'Column2
        '
        Me.Column2.HeaderText = "Provider"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Category
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Category.DefaultCellStyle = DataGridViewCellStyle3
        Me.Category.HeaderText = "Company Point"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 250
        '
        'Column1
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column1.HeaderText = "Type"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = "Tariff"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "Point"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 110
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditCompanyPointToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 26)
        '
        'EditCompanyPointToolStripMenuItem
        '
        Me.EditCompanyPointToolStripMenuItem.Name = "EditCompanyPointToolStripMenuItem"
        Me.EditCompanyPointToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EditCompanyPointToolStripMenuItem.Text = "Edit Company Point"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(695, 15)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(89, 33)
        Me.btnAdd.TabIndex = 146
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(792, 14)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 34)
        Me.btnSearch.TabIndex = 145
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'FrmClientsPoints
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 740)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.chkPoint)
        Me.Controls.Add(Me.chkType)
        Me.Controls.Add(Me.chkProvider)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbClientCode)
        Me.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmClientsPoints"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Companies Points"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbClientCode As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbOP As RadioButton
    Friend WithEvents rbTP As RadioButton
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents chkProvider As CheckBox
    Friend WithEvents chkType As CheckBox
    Friend WithEvents chkPoint As CheckBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents EditCompanyPointToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents clID As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
End Class
