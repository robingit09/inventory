<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProductForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCategory = New System.Windows.Forms.ComboBox()
        Me.cbSubcategory = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbProdInfo = New System.Windows.Forms.TabPage()
        Me.dgvMeasure = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_remove = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnEditUnit = New System.Windows.Forms.Button()
        Me.btnAddMoreUnit = New System.Windows.Forms.Button()
        Me.tbMeasure = New System.Windows.Forms.TabPage()
        Me.dgvMeasure2 = New System.Windows.Forms.DataGridView()
        Me.btnAddCategory = New System.Windows.Forms.Button()
        Me.btnSubCat = New System.Windows.Forms.Button()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAddBrand = New System.Windows.Forms.Button()
        Me.btnAddColor = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mBarcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mUnit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.mPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mAction = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabControl1.SuspendLayout()
        Me.tbProdInfo.SuspendLayout()
        CType(Me.dgvMeasure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMeasure.SuspendLayout()
        CType(Me.dgvMeasure2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(35, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Description"
        '
        'txtProduct
        '
        Me.txtProduct.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProduct.ForeColor = System.Drawing.Color.Black
        Me.txtProduct.Location = New System.Drawing.Point(166, 101)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(445, 22)
        Me.txtProduct.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(35, 215)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Category"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(975, 19)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(94, 37)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(35, 258)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Subcategory"
        '
        'cbCategory
        '
        Me.cbCategory.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCategory.FormattingEnabled = True
        Me.cbCategory.Location = New System.Drawing.Point(166, 212)
        Me.cbCategory.Name = "cbCategory"
        Me.cbCategory.Size = New System.Drawing.Size(445, 23)
        Me.cbCategory.TabIndex = 4
        '
        'cbSubcategory
        '
        Me.cbSubcategory.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSubcategory.FormattingEnabled = True
        Me.cbSubcategory.Location = New System.Drawing.Point(166, 255)
        Me.cbSubcategory.Name = "cbSubcategory"
        Me.cbSubcategory.Size = New System.Drawing.Size(445, 23)
        Me.cbSubcategory.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbProdInfo)
        Me.TabControl1.Controls.Add(Me.tbMeasure)
        Me.TabControl1.Location = New System.Drawing.Point(38, 310)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1035, 331)
        Me.TabControl1.TabIndex = 20
        '
        'tbProdInfo
        '
        Me.tbProdInfo.Controls.Add(Me.dgvMeasure)
        Me.tbProdInfo.Controls.Add(Me.btnEditUnit)
        Me.tbProdInfo.Controls.Add(Me.btnAddMoreUnit)
        Me.tbProdInfo.Location = New System.Drawing.Point(4, 22)
        Me.tbProdInfo.Name = "tbProdInfo"
        Me.tbProdInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProdInfo.Size = New System.Drawing.Size(1027, 305)
        Me.tbProdInfo.TabIndex = 0
        Me.tbProdInfo.Text = "Product Information"
        Me.tbProdInfo.UseVisualStyleBackColor = True
        '
        'dgvMeasure
        '
        Me.dgvMeasure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMeasure.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.barcode, Me.item_code, Me.brand, Me.unit, Me.color, Me.price, Me.col_remove})
        Me.dgvMeasure.Location = New System.Drawing.Point(16, 45)
        Me.dgvMeasure.Name = "dgvMeasure"
        Me.dgvMeasure.Size = New System.Drawing.Size(931, 241)
        Me.dgvMeasure.TabIndex = 3
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'barcode
        '
        Me.barcode.HeaderText = "Barcode"
        Me.barcode.Name = "barcode"
        Me.barcode.ReadOnly = True
        Me.barcode.Width = 180
        '
        'item_code
        '
        Me.item_code.HeaderText = "Item Code"
        Me.item_code.Name = "item_code"
        Me.item_code.ReadOnly = True
        Me.item_code.Width = 150
        '
        'brand
        '
        Me.brand.HeaderText = "Brand"
        Me.brand.Name = "brand"
        Me.brand.ReadOnly = True
        Me.brand.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.brand.Width = 150
        '
        'unit
        '
        Me.unit.HeaderText = "Unit"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
        Me.unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'color
        '
        Me.color.HeaderText = "Color"
        Me.color.Name = "color"
        Me.color.ReadOnly = True
        '
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'col_remove
        '
        Me.col_remove.HeaderText = "Action"
        Me.col_remove.Name = "col_remove"
        '
        'btnEditUnit
        '
        Me.btnEditUnit.Location = New System.Drawing.Point(124, 16)
        Me.btnEditUnit.Name = "btnEditUnit"
        Me.btnEditUnit.Size = New System.Drawing.Size(94, 23)
        Me.btnEditUnit.TabIndex = 2
        Me.btnEditUnit.Text = "Edit"
        Me.btnEditUnit.UseVisualStyleBackColor = True
        '
        'btnAddMoreUnit
        '
        Me.btnAddMoreUnit.Location = New System.Drawing.Point(16, 16)
        Me.btnAddMoreUnit.Name = "btnAddMoreUnit"
        Me.btnAddMoreUnit.Size = New System.Drawing.Size(88, 23)
        Me.btnAddMoreUnit.TabIndex = 1
        Me.btnAddMoreUnit.Text = "Add"
        Me.btnAddMoreUnit.UseVisualStyleBackColor = True
        '
        'tbMeasure
        '
        Me.tbMeasure.Controls.Add(Me.dgvMeasure2)
        Me.tbMeasure.Location = New System.Drawing.Point(4, 22)
        Me.tbMeasure.Name = "tbMeasure"
        Me.tbMeasure.Size = New System.Drawing.Size(1027, 305)
        Me.tbMeasure.TabIndex = 1
        Me.tbMeasure.Text = "Measurement"
        Me.tbMeasure.UseVisualStyleBackColor = True
        '
        'dgvMeasure2
        '
        Me.dgvMeasure2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMeasure2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.mBarcode, Me.mUnit, Me.mPrice, Me.mAction})
        Me.dgvMeasure2.Location = New System.Drawing.Point(13, 56)
        Me.dgvMeasure2.Name = "dgvMeasure2"
        Me.dgvMeasure2.Size = New System.Drawing.Size(996, 235)
        Me.dgvMeasure2.TabIndex = 4
        '
        'btnAddCategory
        '
        Me.btnAddCategory.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCategory.Location = New System.Drawing.Point(621, 211)
        Me.btnAddCategory.Name = "btnAddCategory"
        Me.btnAddCategory.Size = New System.Drawing.Size(59, 23)
        Me.btnAddCategory.TabIndex = 23
        Me.btnAddCategory.Text = "Add (+)"
        Me.btnAddCategory.UseVisualStyleBackColor = True
        '
        'btnSubCat
        '
        Me.btnSubCat.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubCat.Location = New System.Drawing.Point(621, 255)
        Me.btnSubCat.Name = "btnSubCat"
        Me.btnSubCat.Size = New System.Drawing.Size(59, 23)
        Me.btnSubCat.TabIndex = 24
        Me.btnSubCat.Text = "Add (+)"
        Me.btnSubCat.UseVisualStyleBackColor = True
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(166, 29)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(217, 22)
        Me.txtBarcode.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(35, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Barcode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(35, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 15)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Item Code"
        '
        'txtItemCode
        '
        Me.txtItemCode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemCode.Location = New System.Drawing.Point(166, 66)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(217, 22)
        Me.txtItemCode.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(35, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 15)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Brand"
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(166, 173)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(445, 23)
        Me.cbBrand.TabIndex = 29
        '
        'cbColor
        '
        Me.cbColor.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Location = New System.Drawing.Point(166, 138)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(445, 23)
        Me.cbColor.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(35, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 15)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Color"
        '
        'btnAddBrand
        '
        Me.btnAddBrand.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddBrand.Location = New System.Drawing.Point(621, 171)
        Me.btnAddBrand.Name = "btnAddBrand"
        Me.btnAddBrand.Size = New System.Drawing.Size(59, 23)
        Me.btnAddBrand.TabIndex = 32
        Me.btnAddBrand.Text = "Add (+)"
        Me.btnAddBrand.UseVisualStyleBackColor = True
        '
        'btnAddColor
        '
        Me.btnAddColor.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddColor.Location = New System.Drawing.Point(621, 136)
        Me.btnAddColor.Name = "btnAddColor"
        Me.btnAddColor.Size = New System.Drawing.Size(59, 23)
        Me.btnAddColor.TabIndex = 33
        Me.btnAddColor.Text = "Add (+)"
        Me.btnAddColor.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 5
        '
        'mBarcode
        '
        Me.mBarcode.HeaderText = "Barcode"
        Me.mBarcode.Name = "mBarcode"
        Me.mBarcode.Width = 180
        '
        'mUnit
        '
        Me.mUnit.HeaderText = "Unit"
        Me.mUnit.Name = "mUnit"
        Me.mUnit.ReadOnly = True
        Me.mUnit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.mUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.mUnit.Width = 170
        '
        'mPrice
        '
        Me.mPrice.HeaderText = "Price"
        Me.mPrice.Name = "mPrice"
        Me.mPrice.Width = 120
        '
        'mAction
        '
        Me.mAction.HeaderText = "Remove"
        Me.mAction.Name = "mAction"
        Me.mAction.ReadOnly = True
        Me.mAction.Text = "Delete"
        '
        'ProductForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1099, 662)
        Me.Controls.Add(Me.btnAddColor)
        Me.Controls.Add(Me.btnAddBrand)
        Me.Controls.Add(Me.cbColor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbBrand)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.btnSubCat)
        Me.Controls.Add(Me.btnAddCategory)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cbSubcategory)
        Me.Controls.Add(Me.cbCategory)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "ProductForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Product Form (Add New)"
        Me.TabControl1.ResumeLayout(False)
        Me.tbProdInfo.ResumeLayout(False)
        CType(Me.dgvMeasure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMeasure.ResumeLayout(False)
        CType(Me.dgvMeasure2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cbSubcategory As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbProdInfo As System.Windows.Forms.TabPage
    Friend WithEvents btnAddMoreUnit As Button
    Friend WithEvents btnEditUnit As Button
    Friend WithEvents dgvMeasure As DataGridView
    Friend WithEvents btnAddCategory As Button
    Friend WithEvents btnSubCat As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents barcode As DataGridViewTextBoxColumn
    Friend WithEvents item_code As DataGridViewTextBoxColumn
    Friend WithEvents brand As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents color As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents col_remove As DataGridViewButtonColumn
    Friend WithEvents tbMeasure As TabPage
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents dgvMeasure2 As DataGridView
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAddBrand As Button
    Friend WithEvents btnAddColor As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents mBarcode As DataGridViewTextBoxColumn
    Friend WithEvents mUnit As DataGridViewButtonColumn
    Friend WithEvents mPrice As DataGridViewTextBoxColumn
    Friend WithEvents mAction As DataGridViewButtonColumn
End Class
