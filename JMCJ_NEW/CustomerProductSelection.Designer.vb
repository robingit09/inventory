<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerProductSelection
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
        Me.btnAddToOrder = New System.Windows.Forms.Button()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvProducts = New System.Windows.Forms.DataGridView()
        Me.column_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.selectp = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.column_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_sell_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_subcat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAddProduct = New System.Windows.Forms.Button()
        Me.linkSelectAll = New System.Windows.Forms.LinkLabel()
        Me.linkUnselectAll = New System.Windows.Forms.LinkLabel()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddToOrder
        '
        Me.btnAddToOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToOrder.Location = New System.Drawing.Point(1262, 28)
        Me.btnAddToOrder.Name = "btnAddToOrder"
        Me.btnAddToOrder.Size = New System.Drawing.Size(99, 39)
        Me.btnAddToOrder.TabIndex = 33
        Me.btnAddToOrder.Text = "Add"
        Me.btnAddToOrder.UseVisualStyleBackColor = True
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(75, 25)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.ReadOnly = True
        Me.txtCustomer.Size = New System.Drawing.Size(252, 20)
        Me.txtCustomer.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Customer"
        '
        'dgvProducts
        '
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.column_id, Me.selectp, Me.column_barcode, Me.column_description, Me.column_brand, Me.column_unit, Me.column_color, Me.column_price, Me.column_sell_price, Me.column_stock, Me.column_cat, Me.column_subcat})
        Me.dgvProducts.Location = New System.Drawing.Point(21, 82)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.Size = New System.Drawing.Size(1340, 530)
        Me.dgvProducts.TabIndex = 29
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
        Me.column_description.Width = 250
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
        'column_price
        '
        Me.column_price.HeaderText = "Unit Price"
        Me.column_price.Name = "column_price"
        Me.column_price.ReadOnly = True
        Me.column_price.Width = 120
        '
        'column_sell_price
        '
        Me.column_sell_price.HeaderText = "Sell Price"
        Me.column_sell_price.Name = "column_sell_price"
        Me.column_sell_price.ReadOnly = True
        '
        'column_stock
        '
        Me.column_stock.HeaderText = "Stock"
        Me.column_stock.Name = "column_stock"
        Me.column_stock.ReadOnly = True
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
        'btnAddProduct
        '
        Me.btnAddProduct.Location = New System.Drawing.Point(333, 25)
        Me.btnAddProduct.Name = "btnAddProduct"
        Me.btnAddProduct.Size = New System.Drawing.Size(114, 23)
        Me.btnAddProduct.TabIndex = 34
        Me.btnAddProduct.Text = "Add Products"
        Me.btnAddProduct.UseVisualStyleBackColor = True
        '
        'linkSelectAll
        '
        Me.linkSelectAll.AutoSize = True
        Me.linkSelectAll.Location = New System.Drawing.Point(87, 54)
        Me.linkSelectAll.Name = "linkSelectAll"
        Me.linkSelectAll.Size = New System.Drawing.Size(51, 13)
        Me.linkSelectAll.TabIndex = 36
        Me.linkSelectAll.TabStop = True
        Me.linkSelectAll.Text = "Select All"
        '
        'linkUnselectAll
        '
        Me.linkUnselectAll.AutoSize = True
        Me.linkUnselectAll.Location = New System.Drawing.Point(18, 54)
        Me.linkUnselectAll.Name = "linkUnselectAll"
        Me.linkUnselectAll.Size = New System.Drawing.Size(63, 13)
        Me.linkUnselectAll.TabIndex = 35
        Me.linkUnselectAll.TabStop = True
        Me.linkUnselectAll.Text = "Unselect All"
        '
        'CustomerProductSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 637)
        Me.Controls.Add(Me.linkSelectAll)
        Me.Controls.Add(Me.linkUnselectAll)
        Me.Controls.Add(Me.btnAddProduct)
        Me.Controls.Add(Me.btnAddToOrder)
        Me.Controls.Add(Me.txtCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvProducts)
        Me.Name = "CustomerProductSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Product Selection"
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAddToOrder As Button
    Friend WithEvents txtCustomer As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents column_id As DataGridViewTextBoxColumn
    Friend WithEvents selectp As DataGridViewCheckBoxColumn
    Friend WithEvents column_barcode As DataGridViewTextBoxColumn
    Friend WithEvents column_description As DataGridViewTextBoxColumn
    Friend WithEvents column_brand As DataGridViewTextBoxColumn
    Friend WithEvents column_unit As DataGridViewTextBoxColumn
    Friend WithEvents column_color As DataGridViewTextBoxColumn
    Friend WithEvents column_price As DataGridViewTextBoxColumn
    Friend WithEvents column_sell_price As DataGridViewTextBoxColumn
    Friend WithEvents column_stock As DataGridViewTextBoxColumn
    Friend WithEvents column_cat As DataGridViewTextBoxColumn
    Friend WithEvents column_subcat As DataGridViewTextBoxColumn
    Friend WithEvents btnAddProduct As Button
    Friend WithEvents linkSelectAll As LinkLabel
    Friend WithEvents linkUnselectAll As LinkLabel
End Class
