<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierProductSelection
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
        Me.column_cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_cat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.column_subcat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ckSelectAll = New System.Windows.Forms.CheckBox()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.txtSupplier = New System.Windows.Forms.TextBox()
        Me.btnAddToOrder = New System.Windows.Forms.Button()
        Me.btnAddProducts = New System.Windows.Forms.Button()
        Me.gpSupplier = New System.Windows.Forms.GroupBox()
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProducts
        '
        Me.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.column_id, Me.selectp, Me.column_barcode, Me.column_description, Me.column_brand, Me.column_unit, Me.column_color, Me.column_cost, Me.column_stock, Me.column_cat, Me.column_subcat})
        Me.dgvProducts.Location = New System.Drawing.Point(12, 104)
        Me.dgvProducts.Name = "dgvProducts"
        Me.dgvProducts.Size = New System.Drawing.Size(1255, 474)
        Me.dgvProducts.TabIndex = 22
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
        'column_cost
        '
        Me.column_cost.HeaderText = "Unit Cost"
        Me.column_cost.Name = "column_cost"
        Me.column_cost.ReadOnly = True
        Me.column_cost.Width = 120
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
        'ckSelectAll
        '
        Me.ckSelectAll.AutoSize = True
        Me.ckSelectAll.Checked = True
        Me.ckSelectAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckSelectAll.Location = New System.Drawing.Point(15, 81)
        Me.ckSelectAll.Name = "ckSelectAll"
        Me.ckSelectAll.Size = New System.Drawing.Size(70, 17)
        Me.ckSelectAll.TabIndex = 25
        Me.ckSelectAll.Text = "Select All"
        Me.ckSelectAll.UseVisualStyleBackColor = True
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Location = New System.Drawing.Point(37, 36)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(45, 13)
        Me.lblSupplier.TabIndex = 26
        Me.lblSupplier.Text = "Supplier"
        '
        'txtSupplier
        '
        Me.txtSupplier.Location = New System.Drawing.Point(88, 33)
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.ReadOnly = True
        Me.txtSupplier.Size = New System.Drawing.Size(252, 20)
        Me.txtSupplier.TabIndex = 27
        '
        'btnAddToOrder
        '
        Me.btnAddToOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToOrder.Location = New System.Drawing.Point(1171, 27)
        Me.btnAddToOrder.Name = "btnAddToOrder"
        Me.btnAddToOrder.Size = New System.Drawing.Size(99, 39)
        Me.btnAddToOrder.TabIndex = 28
        Me.btnAddToOrder.Text = "Add"
        Me.btnAddToOrder.UseVisualStyleBackColor = True
        '
        'btnAddProducts
        '
        Me.btnAddProducts.Location = New System.Drawing.Point(355, 33)
        Me.btnAddProducts.Name = "btnAddProducts"
        Me.btnAddProducts.Size = New System.Drawing.Size(111, 23)
        Me.btnAddProducts.TabIndex = 29
        Me.btnAddProducts.Text = "Add Products"
        Me.btnAddProducts.UseVisualStyleBackColor = True
        '
        'gpSupplier
        '
        Me.gpSupplier.Location = New System.Drawing.Point(15, 17)
        Me.gpSupplier.Name = "gpSupplier"
        Me.gpSupplier.Size = New System.Drawing.Size(468, 49)
        Me.gpSupplier.TabIndex = 30
        Me.gpSupplier.TabStop = False
        '
        'SupplierProductSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1295, 637)
        Me.Controls.Add(Me.btnAddProducts)
        Me.Controls.Add(Me.btnAddToOrder)
        Me.Controls.Add(Me.txtSupplier)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.ckSelectAll)
        Me.Controls.Add(Me.dgvProducts)
        Me.Controls.Add(Me.gpSupplier)
        Me.Name = "SupplierProductSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Products"
        CType(Me.dgvProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvProducts As DataGridView
    Friend WithEvents ckSelectAll As CheckBox
    Friend WithEvents lblSupplier As Label
    Friend WithEvents txtSupplier As TextBox
    Friend WithEvents btnAddToOrder As Button
    Friend WithEvents column_id As DataGridViewTextBoxColumn
    Friend WithEvents selectp As DataGridViewCheckBoxColumn
    Friend WithEvents column_barcode As DataGridViewTextBoxColumn
    Friend WithEvents column_description As DataGridViewTextBoxColumn
    Friend WithEvents column_brand As DataGridViewTextBoxColumn
    Friend WithEvents column_unit As DataGridViewTextBoxColumn
    Friend WithEvents column_color As DataGridViewTextBoxColumn
    Friend WithEvents column_cost As DataGridViewTextBoxColumn
    Friend WithEvents column_stock As DataGridViewTextBoxColumn
    Friend WithEvents column_cat As DataGridViewTextBoxColumn
    Friend WithEvents column_subcat As DataGridViewTextBoxColumn
    Friend WithEvents btnAddProducts As Button
    Friend WithEvents gpSupplier As GroupBox
End Class
