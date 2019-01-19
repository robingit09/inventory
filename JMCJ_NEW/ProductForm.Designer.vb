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
        Me.isdefault = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.mAction = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvCost = New System.Windows.Forms.DataGridView()
        Me.btnAddSupplier = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvcosthistory = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvPriceHistory = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Supplier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sUnit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabControl1.SuspendLayout()
        Me.tbMeasure.SuspendLayout()
        CType(Me.dgvMeasure2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvcosthistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvPriceHistory, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.Controls.Add(Me.tbMeasure)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(38, 310)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1035, 331)
        Me.TabControl1.TabIndex = 20
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
        Me.dgvMeasure2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.mBarcode, Me.mUnit, Me.mPrice, Me.isdefault, Me.mAction})
        Me.dgvMeasure2.Location = New System.Drawing.Point(13, 56)
        Me.dgvMeasure2.Name = "dgvMeasure2"
        Me.dgvMeasure2.Size = New System.Drawing.Size(997, 235)
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
        'isdefault
        '
        Me.isdefault.HeaderText = "Default"
        Me.isdefault.Name = "isdefault"
        '
        'mAction
        '
        Me.mAction.HeaderText = "Remove"
        Me.mAction.Name = "mAction"
        Me.mAction.ReadOnly = True
        Me.mAction.Text = "Delete"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnAddSupplier)
        Me.TabPage1.Controls.Add(Me.dgvCost)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1027, 305)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Suppliers"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvCost
        '
        Me.dgvCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Supplier, Me.sUnit, Me.Cost, Me.Action})
        Me.dgvCost.Location = New System.Drawing.Point(16, 64)
        Me.dgvCost.Name = "dgvCost"
        Me.dgvCost.Size = New System.Drawing.Size(994, 224)
        Me.dgvCost.TabIndex = 1
        '
        'btnAddSupplier
        '
        Me.btnAddSupplier.Location = New System.Drawing.Point(935, 14)
        Me.btnAddSupplier.Name = "btnAddSupplier"
        Me.btnAddSupplier.Size = New System.Drawing.Size(75, 23)
        Me.btnAddSupplier.TabIndex = 2
        Me.btnAddSupplier.Text = "Add"
        Me.btnAddSupplier.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvcosthistory)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1027, 305)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Cost History"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvcosthistory
        '
        Me.dgvcosthistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcosthistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgvcosthistory.Location = New System.Drawing.Point(14, 72)
        Me.dgvcosthistory.Name = "dgvcosthistory"
        Me.dgvcosthistory.Size = New System.Drawing.Size(996, 212)
        Me.dgvcosthistory.TabIndex = 4
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Unit Cost"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 300
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Date Added"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 200
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvPriceHistory)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1027, 305)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Price History"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvPriceHistory
        '
        Me.dgvPriceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPriceHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn5})
        Me.dgvPriceHistory.Location = New System.Drawing.Point(13, 69)
        Me.dgvPriceHistory.Name = "dgvPriceHistory"
        Me.dgvPriceHistory.Size = New System.Drawing.Size(996, 217)
        Me.dgvPriceHistory.TabIndex = 3
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Unit Price"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 300
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Date Added"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 200
        '
        'Supplier
        '
        Me.Supplier.HeaderText = "Supplier"
        Me.Supplier.Name = "Supplier"
        Me.Supplier.ReadOnly = True
        Me.Supplier.Width = 350
        '
        'sUnit
        '
        Me.sUnit.HeaderText = "Unit"
        Me.sUnit.Name = "sUnit"
        Me.sUnit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.sUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.sUnit.Width = 200
        '
        'Cost
        '
        Me.Cost.HeaderText = "Cost"
        Me.Cost.Name = "Cost"
        Me.Cost.ReadOnly = True
        '
        'Action
        '
        Me.Action.HeaderText = "Action"
        Me.Action.Name = "Action"
        Me.Action.ReadOnly = True
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
        Me.tbMeasure.ResumeLayout(False)
        CType(Me.dgvMeasure2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvcosthistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvPriceHistory, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnAddCategory As Button
    Friend WithEvents btnSubCat As Button
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
    Friend WithEvents isdefault As DataGridViewCheckBoxColumn
    Friend WithEvents mAction As DataGridViewButtonColumn
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvCost As DataGridView
    Friend WithEvents btnAddSupplier As Button
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvcosthistory As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvPriceHistory As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents Supplier As DataGridViewTextBoxColumn
    Friend WithEvents sUnit As DataGridViewButtonColumn
    Friend WithEvents Cost As DataGridViewTextBoxColumn
    Friend WithEvents Action As DataGridViewButtonColumn
End Class
