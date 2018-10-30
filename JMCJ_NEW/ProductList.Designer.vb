<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductList
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
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Category = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Subcategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.cbSubCat = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbUnit = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbCat = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProducts
        '
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Barcode, Me.ProductDesc, Me.Brand, Me.Unit, Me.Color, Me.UnitPrice, Me.StockQty, Me.Category, Me.Subcategory})
        Me.dgvProducts.Location = New System.Drawing.Point(23, 218)
        Me.dgvProducts.Name = "dgvProducts"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProducts.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvProducts.Size = New System.Drawing.Size(1379, 461)
        Me.dgvProducts.TabIndex = 20
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'Barcode
        '
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        Me.Barcode.ReadOnly = True
        '
        'ProductDesc
        '
        Me.ProductDesc.HeaderText = "Product Description"
        Me.ProductDesc.Name = "ProductDesc"
        Me.ProductDesc.ReadOnly = True
        Me.ProductDesc.Width = 350
        '
        'Brand
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Brand.DefaultCellStyle = DataGridViewCellStyle11
        Me.Brand.HeaderText = "Brand"
        Me.Brand.Name = "Brand"
        Me.Brand.ReadOnly = True
        Me.Brand.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Brand.Width = 110
        '
        'Unit
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Unit.DefaultCellStyle = DataGridViewCellStyle12
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Unit.Width = 110
        '
        'Color
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Color.DefaultCellStyle = DataGridViewCellStyle13
        Me.Color.HeaderText = "Color"
        Me.Color.Name = "Color"
        Me.Color.ReadOnly = True
        Me.Color.Width = 110
        '
        'UnitPrice
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.UnitPrice.DefaultCellStyle = DataGridViewCellStyle14
        Me.UnitPrice.HeaderText = "Unit Price"
        Me.UnitPrice.Name = "UnitPrice"
        Me.UnitPrice.ReadOnly = True
        Me.UnitPrice.Width = 160
        '
        'StockQty
        '
        Me.StockQty.HeaderText = "Stock Quantity"
        Me.StockQty.Name = "StockQty"
        Me.StockQty.ReadOnly = True
        Me.StockQty.Width = 80
        '
        'Category
        '
        Me.Category.HeaderText = "Category"
        Me.Category.Name = "Category"
        Me.Category.ReadOnly = True
        Me.Category.Width = 120
        '
        'Subcategory
        '
        Me.Subcategory.HeaderText = "Subcategory"
        Me.Subcategory.Name = "Subcategory"
        Me.Subcategory.ReadOnly = True
        Me.Subcategory.Width = 120
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtProductDesc)
        Me.GroupBox1.Controls.Add(Me.cbSubCat)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cbColor)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cbUnit)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cbBrand)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtBarcode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbCat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(23, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1379, 134)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'txtProductDesc
        '
        Me.txtProductDesc.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductDesc.Location = New System.Drawing.Point(340, 15)
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.Size = New System.Drawing.Size(190, 21)
        Me.txtProductDesc.TabIndex = 17
        '
        'cbSubCat
        '
        Me.cbSubCat.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubCat.FormattingEnabled = True
        Me.cbSubCat.Location = New System.Drawing.Point(340, 50)
        Me.cbSubCat.Name = "cbSubCat"
        Me.cbSubCat.Size = New System.Drawing.Size(190, 23)
        Me.cbSubCat.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(232, 53)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Sub Category"
        '
        'cbColor
        '
        Me.cbColor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Location = New System.Drawing.Point(953, 15)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(117, 23)
        Me.cbColor.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(911, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 15)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Color"
        '
        'cbUnit
        '
        Me.cbUnit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(787, 15)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(117, 23)
        Me.cbUnit.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(745, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Unit"
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(596, 15)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(132, 23)
        Me.cbBrand.TabIndex = 10
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(985, 88)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(85, 28)
        Me.btnFilter.TabIndex = 8
        Me.btnFilter.Text = "Filter"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Barcode"
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(78, 15)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(145, 21)
        Me.txtBarcode.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(554, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Brand"
        '
        'cbCat
        '
        Me.cbCat.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCat.FormattingEnabled = True
        Me.cbCat.Location = New System.Drawing.Point(78, 50)
        Me.cbCat.Name = "cbCat"
        Me.cbCat.Size = New System.Drawing.Size(145, 23)
        Me.cbCat.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(229, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Product Description"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(23, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(103, 34)
        Me.btnAdd.TabIndex = 22
        Me.btnAdd.Text = "Add New(+)"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Location = New System.Drawing.Point(152, 12)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(94, 34)
        Me.btnUpdate.TabIndex = 23
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(284, 12)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 34)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(403, 12)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 34)
        Me.btnPrint.TabIndex = 25
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'ProductList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1370, 722)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvProducts)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "ProductList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProducts As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCat As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cbSubCat As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbUnit As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents txtProductDesc As TextBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents ProductDesc As DataGridViewTextBoxColumn
    Friend WithEvents Brand As DataGridViewTextBoxColumn
    Friend WithEvents Unit As DataGridViewTextBoxColumn
    Friend WithEvents Color As DataGridViewTextBoxColumn
    Friend WithEvents UnitPrice As DataGridViewTextBoxColumn
    Friend WithEvents StockQty As DataGridViewTextBoxColumn
    Friend WithEvents Category As DataGridViewTextBoxColumn
    Friend WithEvents Subcategory As DataGridViewTextBoxColumn
End Class
