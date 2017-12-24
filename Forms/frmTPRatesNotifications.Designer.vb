<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTPRatesNotifications
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmbClientCode = New System.Windows.Forms.ComboBox()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.chkProvider = New System.Windows.Forms.CheckBox()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.clID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.cmbClientCode.Location = New System.Drawing.Point(109, 11)
        Me.cmbClientCode.Margin = New System.Windows.Forms.Padding(9, 6, 9, 6)
        Me.cmbClientCode.Name = "cmbClientCode"
        Me.cmbClientCode.Size = New System.Drawing.Size(308, 24)
        Me.cmbClientCode.TabIndex = 137
        Me.cmbClientCode.ValueMember = "ID"
        '
        'cmbStatus
        '
        Me.cmbStatus.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbStatus.DisplayMember = "ID"
        Me.cmbStatus.DropDownHeight = 400
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.DropDownWidth = 200
        Me.cmbStatus.Enabled = False
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.IntegralHeight = False
        Me.cmbStatus.Location = New System.Drawing.Point(109, 43)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(308, 24)
        Me.cmbStatus.TabIndex = 140
        Me.cmbStatus.ValueMember = "ID"
        '
        'chkProvider
        '
        Me.chkProvider.AutoSize = True
        Me.chkProvider.Location = New System.Drawing.Point(15, 13)
        Me.chkProvider.Name = "chkProvider"
        Me.chkProvider.Size = New System.Drawing.Size(64, 20)
        Me.chkProvider.TabIndex = 141
        Me.chkProvider.Text = "Tariff"
        Me.chkProvider.UseVisualStyleBackColor = True
        '
        'chkStatus
        '
        Me.chkStatus.AutoSize = True
        Me.chkStatus.Location = New System.Drawing.Point(15, 45)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(74, 20)
        Me.chkStatus.TabIndex = 142
        Me.chkStatus.Text = "Status"
        Me.chkStatus.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clID, Me.Column7, Me.Column2, Me.Category, Me.Column4, Me.Column1, Me.Column3, Me.Column5, Me.Column6})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle5.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.Location = New System.Drawing.Point(8, 90)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1190, 647)
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
        'Column7
        '
        Me.Column7.HeaderText = "enumStatus"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
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
        'Column4
        '
        Me.Column4.HeaderText = "Tariff"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 200
        '
        'Column1
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column1.HeaderText = "Status"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "Full/Partial"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 110
        '
        'Column5
        '
        Me.Column5.HeaderText = "Tariff Date"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 150
        '
        'Column6
        '
        Me.Column6.HeaderText = "Show"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1062, 9)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 34)
        Me.btnSearch.TabIndex = 145
        Me.btnSearch.Text = "Filter"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(553, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 16)
        Me.Label2.TabIndex = 149
        Me.Label2.Text = "To"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpToDate.Enabled = False
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(607, 44)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(200, 22)
        Me.dtpToDate.TabIndex = 147
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dddd  dd/MM/yyyy"
        Me.dtpFromDate.Enabled = False
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(607, 12)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(200, 22)
        Me.dtpFromDate.TabIndex = 148
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(451, 13)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(148, 20)
        Me.chkDate.TabIndex = 150
        Me.chkDate.Text = "Tariff date: From"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'frmTPRatesNotifications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 740)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.chkDate)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.chkStatus)
        Me.Controls.Add(Me.chkProvider)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.cmbClientCode)
        Me.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmTPRatesNotifications"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TP Rates Nofifications"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbClientCode As ComboBox
    Friend WithEvents cmbStatus As ComboBox
    Friend WithEvents chkProvider As CheckBox
    Friend WithEvents chkStatus As CheckBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpToDate As DateTimePicker
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents chkDate As CheckBox
    Friend WithEvents clID As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewButtonColumn
End Class
