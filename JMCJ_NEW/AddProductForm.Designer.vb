<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProductForm
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
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.column_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selectp = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.column_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_unit_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_sell_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_subcat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.cbSubCat = New System.Windows.Forms.ComboBox()
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.cbCat = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbUnit = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.linkUnselectAll = New System.Windows.Forms.LinkLabel()
        Me.linkSelectAll = New System.Windows.Forms.LinkLabel()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProducts
        '
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.column_id, Me.selectp, Me.column_barcode, Me.column_description, Me.column_brand, Me.column_unit, Me.column_color, Me.column_unit_price, Me.column_sell_price, Me.column_cat, Me.column_subcat})
        Me.dgvProducts.Location = New System.Drawing.Point(12, 210)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.Size = New System.Drawing.Size(1277, 416)
        Me.dgvProducts.TabIndex = 21
        '
        'column_id
        '
        Me.column_id.HeaderText = "id"
        Me.column_id.Name = "column_id"
        Me.column_id.ReadOnly = True
        Me.column_id.Width = 5
        '
        'selectp
        '
        Me.selectp.HeaderText = ""
        Me.selectp.Name = "selectp"
        Me.selectp.Width = 50
        '
        'column_barcode
        '
        Me.column_barcode.HeaderText = "Barcode"
        Me.column_barcode.Name = "column_barcode"
        Me.column_barcode.ReadOnly = True
        Me.column_barcode.Width = 140
        '
        'column_description
        '
        Me.column_description.HeaderText = "Product Description"
        Me.column_description.Name = "column_description"
        Me.column_description.ReadOnly = True
        Me.column_description.Width = 190
        '
        'column_brand
        '
        Me.column_brand.HeaderText = "Brand"
        Me.column_brand.Name = "column_brand"
        Me.column_brand.ReadOnly = True
        Me.column_brand.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.column_brand.Width = 110
        '
        'column_unit
        '
        Me.column_unit.HeaderText = "Unit"
        Me.column_unit.Name = "column_unit"
        Me.column_unit.ReadOnly = True
        Me.column_unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'column_color
        '
        Me.column_color.HeaderText = "Color"
        Me.column_color.Name = "column_color"
        Me.column_color.ReadOnly = True
        '
        'column_unit_price
        '
        Me.column_unit_price.HeaderText = "Unit Price"
        Me.column_unit_price.Name = "column_unit_price"
        Me.column_unit_price.ReadOnly = True
        Me.column_unit_price.Width = 120
        '
        'column_sell_price
        '
        Me.column_sell_price.HeaderText = "Sell Price"
        Me.column_sell_price.Name = "column_sell_price"
        '
        'column_cat
        '
        Me.column_cat.HeaderText = "Category"
        Me.column_cat.Name = "column_cat"
        Me.column_cat.ReadOnly = True
        Me.column_cat.Width = 150
        '
        'column_subcat
        '
        Me.column_subcat.HeaderText = "Subcategory"
        Me.column_subcat.Name = "column_subcat"
        Me.column_subcat.ReadOnly = True
        Me.column_subcat.Width = 150
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.cbSubCat)
        Me.GroupBox1.Controls.Add(Me.txtProductDesc)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbColor)
        Me.GroupBox1.Controls.Add(Me.cbCat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbUnit)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbBrand)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtBarcode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1258, 108)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(989, 62)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(85, 28)
        Me.btnFilter.TabIndex = 29
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'cbSubCat
        '
        Me.cbSubCat.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubCat.FormattingEnabled = True
        Me.cbSubCat.Location = New System.Drawing.Point(334, 59)
        Me.cbSubCat.Name = "cbSubCat"
        Me.cbSubCat.Size = New System.Drawing.Size(190, 23)
        Me.cbSubCat.TabIndex = 28
        '
        'txtProductDesc
        '
        Me.txtProductDesc.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductDesc.Location = New System.Drawing.Point(545, 18)
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.Size = New System.Drawing.Size(190, 21)
        Me.txtProductDesc.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(256, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Sub Category"
        '
        'cbColor
        '
        Me.cbColor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Location = New System.Drawing.Point(1129, 18)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(117, 23)
        Me.cbColor.TabIndex = 26
        '
        'cbCat
        '
        Me.cbCat.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCat.FormattingEnabled = True
        Me.cbCat.Location = New System.Drawing.Point(82, 59)
        Me.cbCat.Name = "cbCat"
        Me.cbCat.Size = New System.Drawing.Size(145, 23)
        Me.cbCat.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Category"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1087, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Color"
        '
        'cbUnit
        '
        Me.cbUnit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(963, 18)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(117, 23)
        Me.cbUnit.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(921, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 15)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Unit"
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(783, 18)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(132, 23)
        Me.cbBrand.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Barcode"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(82, 21)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(145, 21)
        Me.txtBarcode.TabIndex = 20
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(741, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Brand"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(434, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Product Description"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(1011, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 31)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(1150, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 31)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'linkUnselectAll
        '
        Me.linkUnselectAll.AutoSize = True
        Me.linkUnselectAll.Location = New System.Drawing.Point(9, 182)
        Me.linkUnselectAll.Name = "linkUnselectAll"
        Me.linkUnselectAll.Size = New System.Drawing.Size(63, 13)
        Me.linkUnselectAll.TabIndex = 25
        Me.linkUnselectAll.TabStop = True
        Me.linkUnselectAll.Text = "Unselect All"
        '
        'linkSelectAll
        '
        Me.linkSelectAll.AutoSize = True
        Me.linkSelectAll.Location = New System.Drawing.Point(78, 182)
        Me.linkSelectAll.Name = "linkSelectAll"
        Me.linkSelectAll.Size = New System.Drawing.Size(51, 13)
        Me.linkSelectAll.TabIndex = 26
        Me.linkSelectAll.TabStop = True
        Me.linkSelectAll.Text = "Select All"
        '
        'AddProductForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1301, 638)
        Me.Controls.Add(Me.linkSelectAll)
        Me.Controls.Add(Me.linkUnselectAll)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvProducts)
        Me.Name = "AddProductForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product List"
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProducts As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents column_id As DataGridViewTextBoxColumn
    Friend WithEvents selectp As DataGridViewCheckBoxColumn
    Friend WithEvents column_barcode As DataGridViewTextBoxColumn
    Friend WithEvents column_description As DataGridViewTextBoxColumn
    Friend WithEvents column_brand As DataGridViewTextBoxColumn
    Friend WithEvents column_unit As DataGridViewTextBoxColumn
    Friend WithEvents column_color As DataGridViewTextBoxColumn
    Friend WithEvents column_unit_price As DataGridViewTextBoxColumn
    Friend WithEvents column_sell_price As DataGridViewTextBoxColumn
    Friend WithEvents column_cat As DataGridViewTextBoxColumn
    Friend WithEvents column_subcat As DataGridViewTextBoxColumn
    Friend WithEvents txtProductDesc As TextBox
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbUnit As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbSubCat As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbCat As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents linkUnselectAll As LinkLabel
    Friend WithEvents linkSelectAll As LinkLabel
End Class
