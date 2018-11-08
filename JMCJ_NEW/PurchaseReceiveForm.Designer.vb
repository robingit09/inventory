<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseReceiveForm
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
        Me.cbPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbTerms = New System.Windows.Forms.ComboBox()
        Me.txtPRNO = New System.Windows.Forms.TextBox()
        Me.cbPO = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpETA = New System.Windows.Forms.DateTimePicker()
        Me.dtp_pr_date = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpATA = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSaveAndPrint = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gpEnterBarcode = New System.Windows.Forms.GroupBox()
        Me.txtEnterBarcode = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gpEnterProduct = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnAddToCart = New System.Windows.Forms.Button()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.cbUnit = New System.Windows.Forms.ComboBox()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dgvProd = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actual_quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.gpFields = New System.Windows.Forms.GroupBox()
        Me.btnAddSupplier = New System.Windows.Forms.Button()
        Me.cbSupplier = New System.Windows.Forms.ComboBox()
        Me.txtDrNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSelectProduct = New System.Windows.Forms.Button()
        Me.gpEnterBarcode.SuspendLayout()
        Me.gpEnterProduct.SuspendLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpFields.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbPaymentType
        '
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Location = New System.Drawing.Point(573, 22)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(209, 21)
        Me.cbPaymentType.TabIndex = 73
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(456, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "Select Payment Type:"
        '
        'cbTerms
        '
        Me.cbTerms.FormattingEnabled = True
        Me.cbTerms.Location = New System.Drawing.Point(573, 51)
        Me.cbTerms.Name = "cbTerms"
        Me.cbTerms.Size = New System.Drawing.Size(209, 21)
        Me.cbTerms.TabIndex = 71
        '
        'txtPRNO
        '
        Me.txtPRNO.Location = New System.Drawing.Point(89, 77)
        Me.txtPRNO.Name = "txtPRNO"
        Me.txtPRNO.ReadOnly = True
        Me.txtPRNO.Size = New System.Drawing.Size(348, 20)
        Me.txtPRNO.TabIndex = 70
        '
        'cbPO
        '
        Me.cbPO.FormattingEnabled = True
        Me.cbPO.Location = New System.Drawing.Point(89, 22)
        Me.cbPO.Name = "cbPO"
        Me.cbPO.Size = New System.Drawing.Size(348, 21)
        Me.cbPO.TabIndex = 69
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(456, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Select Terms:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Select PO:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "PR Number:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Supplier:"
        '
        'txtAmount
        '
        Me.txtAmount.ForeColor = System.Drawing.Color.Red
        Me.txtAmount.Location = New System.Drawing.Point(901, 115)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(209, 20)
        Me.txtAmount.TabIndex = 81
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(805, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "Total Amount:"
        '
        'dtpETA
        '
        Me.dtpETA.Enabled = False
        Me.dtpETA.Location = New System.Drawing.Point(901, 52)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(209, 20)
        Me.dtpETA.TabIndex = 80
        '
        'dtp_pr_date
        '
        Me.dtp_pr_date.Location = New System.Drawing.Point(900, 22)
        Me.dtp_pr_date.Name = "dtp_pr_date"
        Me.dtp_pr_date.Size = New System.Drawing.Size(210, 20)
        Me.dtp_pr_date.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(805, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Date:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(805, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "ETA:"
        '
        'dtpATA
        '
        Me.dtpATA.Location = New System.Drawing.Point(901, 82)
        Me.dtpATA.Name = "dtpATA"
        Me.dtpATA.Size = New System.Drawing.Size(209, 20)
        Me.dtpATA.TabIndex = 84
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(805, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 83
        Me.Label9.Text = "ATA:"
        '
        'btnSaveAndPrint
        '
        Me.btnSaveAndPrint.Location = New System.Drawing.Point(1178, 67)
        Me.btnSaveAndPrint.Name = "btnSaveAndPrint"
        Me.btnSaveAndPrint.Size = New System.Drawing.Size(102, 38)
        Me.btnSaveAndPrint.TabIndex = 86
        Me.btnSaveAndPrint.Text = "Save and Print"
        Me.btnSaveAndPrint.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1178, 22)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 38)
        Me.btnSave.TabIndex = 85
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gpEnterBarcode
        '
        Me.gpEnterBarcode.Controls.Add(Me.txtEnterBarcode)
        Me.gpEnterBarcode.Controls.Add(Me.Label14)
        Me.gpEnterBarcode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEnterBarcode.Location = New System.Drawing.Point(15, 178)
        Me.gpEnterBarcode.Name = "gpEnterBarcode"
        Me.gpEnterBarcode.Size = New System.Drawing.Size(256, 49)
        Me.gpEnterBarcode.TabIndex = 87
        Me.gpEnterBarcode.TabStop = False
        Me.gpEnterBarcode.Text = "Enter Barcode"
        '
        'txtEnterBarcode
        '
        Me.txtEnterBarcode.Location = New System.Drawing.Point(73, 16)
        Me.txtEnterBarcode.Name = "txtEnterBarcode"
        Me.txtEnterBarcode.Size = New System.Drawing.Size(170, 21)
        Me.txtEnterBarcode.TabIndex = 56
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 15)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Barcode"
        '
        'gpEnterProduct
        '
        Me.gpEnterProduct.Controls.Add(Me.Label20)
        Me.gpEnterProduct.Controls.Add(Me.btnAddToCart)
        Me.gpEnterProduct.Controls.Add(Me.cbColor)
        Me.gpEnterProduct.Controls.Add(Me.Label17)
        Me.gpEnterProduct.Controls.Add(Me.Label15)
        Me.gpEnterProduct.Controls.Add(Me.txtProductDesc)
        Me.gpEnterProduct.Controls.Add(Me.cbUnit)
        Me.gpEnterProduct.Controls.Add(Me.cbBrand)
        Me.gpEnterProduct.Controls.Add(Me.Label16)
        Me.gpEnterProduct.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEnterProduct.Location = New System.Drawing.Point(292, 179)
        Me.gpEnterProduct.Name = "gpEnterProduct"
        Me.gpEnterProduct.Size = New System.Drawing.Size(1019, 49)
        Me.gpEnterProduct.TabIndex = 88
        Me.gpEnterProduct.TabStop = False
        Me.gpEnterProduct.Text = "Enter Product"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(708, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 15)
        Me.Label20.TabIndex = 100
        Me.Label20.Text = "Color"
        '
        'btnAddToCart
        '
        Me.btnAddToCart.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToCart.Location = New System.Drawing.Point(920, 16)
        Me.btnAddToCart.Name = "btnAddToCart"
        Me.btnAddToCart.Size = New System.Drawing.Size(77, 26)
        Me.btnAddToCart.TabIndex = 39
        Me.btnAddToCart.Text = "Add to Cart"
        Me.btnAddToCart.UseVisualStyleBackColor = True
        '
        'cbColor
        '
        Me.cbColor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Location = New System.Drawing.Point(750, 18)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(149, 23)
        Me.cbColor.TabIndex = 99
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 15)
        Me.Label17.TabIndex = 93
        Me.Label17.Text = "Description"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(536, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 15)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "Unit"
        '
        'txtProductDesc
        '
        Me.txtProductDesc.Location = New System.Drawing.Point(76, 18)
        Me.txtProductDesc.MaxLength = 32000
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.Size = New System.Drawing.Size(241, 21)
        Me.txtProductDesc.TabIndex = 94
        '
        'cbUnit
        '
        Me.cbUnit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(572, 18)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(130, 23)
        Me.cbUnit.TabIndex = 97
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(379, 18)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(143, 23)
        Me.cbBrand.TabIndex = 95
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(337, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 15)
        Me.Label16.TabIndex = 96
        Me.Label16.Text = "Brand"
        '
        'dgvProd
        '
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Barcode, Me.quantity, Me.actual_quantity, Me.product, Me.brand, Me.unit, Me.Color, Me.cost, Me.amount, Me.stock, Me.action})
        Me.dgvProd.Location = New System.Drawing.Point(15, 270)
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.Size = New System.Drawing.Size(1296, 288)
        Me.dgvProd.TabIndex = 89
        '
        'id
        '
        Me.id.HeaderText = "ID"
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
        'quantity
        '
        Me.quantity.HeaderText = "Qty"
        Me.quantity.Name = "quantity"
        Me.quantity.Width = 80
        '
        'actual_quantity
        '
        Me.actual_quantity.HeaderText = "Actual Qty"
        Me.actual_quantity.Name = "actual_quantity"
        Me.actual_quantity.Width = 80
        '
        'product
        '
        Me.product.HeaderText = "Product Description"
        Me.product.Name = "product"
        Me.product.ReadOnly = True
        Me.product.Width = 250
        '
        'brand
        '
        Me.brand.HeaderText = "Brand"
        Me.brand.Name = "brand"
        Me.brand.ReadOnly = True
        '
        'unit
        '
        Me.unit.HeaderText = "Unit"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
        '
        'Color
        '
        Me.Color.HeaderText = "Color"
        Me.Color.Name = "Color"
        Me.Color.ReadOnly = True
        '
        'cost
        '
        Me.cost.HeaderText = "Unit Cost"
        Me.cost.Name = "cost"
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'stock
        '
        Me.stock.HeaderText = "Stock"
        Me.stock.Name = "stock"
        Me.stock.ReadOnly = True
        '
        'action
        '
        Me.action.HeaderText = "Action"
        Me.action.Name = "action"
        '
        'gpFields
        '
        Me.gpFields.Controls.Add(Me.btnAddSupplier)
        Me.gpFields.Controls.Add(Me.cbSupplier)
        Me.gpFields.Controls.Add(Me.txtDrNo)
        Me.gpFields.Controls.Add(Me.Label11)
        Me.gpFields.Controls.Add(Me.Label2)
        Me.gpFields.Controls.Add(Me.Label1)
        Me.gpFields.Controls.Add(Me.Label3)
        Me.gpFields.Controls.Add(Me.cbPO)
        Me.gpFields.Controls.Add(Me.txtPRNO)
        Me.gpFields.Controls.Add(Me.btnSaveAndPrint)
        Me.gpFields.Controls.Add(Me.cbTerms)
        Me.gpFields.Controls.Add(Me.btnSave)
        Me.gpFields.Controls.Add(Me.Label7)
        Me.gpFields.Controls.Add(Me.dtpATA)
        Me.gpFields.Controls.Add(Me.cbPaymentType)
        Me.gpFields.Controls.Add(Me.Label9)
        Me.gpFields.Controls.Add(Me.Label4)
        Me.gpFields.Controls.Add(Me.txtAmount)
        Me.gpFields.Controls.Add(Me.Label6)
        Me.gpFields.Controls.Add(Me.Label8)
        Me.gpFields.Controls.Add(Me.dtpETA)
        Me.gpFields.Controls.Add(Me.Label5)
        Me.gpFields.Controls.Add(Me.dtp_pr_date)
        Me.gpFields.Location = New System.Drawing.Point(15, 14)
        Me.gpFields.Name = "gpFields"
        Me.gpFields.Size = New System.Drawing.Size(1296, 159)
        Me.gpFields.TabIndex = 90
        Me.gpFields.TabStop = False
        Me.gpFields.Text = "Purchase Receive"
        '
        'btnAddSupplier
        '
        Me.btnAddSupplier.Location = New System.Drawing.Point(339, 47)
        Me.btnAddSupplier.Name = "btnAddSupplier"
        Me.btnAddSupplier.Size = New System.Drawing.Size(98, 23)
        Me.btnAddSupplier.TabIndex = 90
        Me.btnAddSupplier.Text = "Add Supplier"
        Me.btnAddSupplier.UseVisualStyleBackColor = True
        '
        'cbSupplier
        '
        Me.cbSupplier.FormattingEnabled = True
        Me.cbSupplier.Location = New System.Drawing.Point(89, 49)
        Me.cbSupplier.Name = "cbSupplier"
        Me.cbSupplier.Size = New System.Drawing.Size(244, 21)
        Me.cbSupplier.TabIndex = 89
        '
        'txtDrNo
        '
        Me.txtDrNo.Location = New System.Drawing.Point(89, 108)
        Me.txtDrNo.Name = "txtDrNo"
        Me.txtDrNo.Size = New System.Drawing.Size(348, 20)
        Me.txtDrNo.TabIndex = 88
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(18, 111)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "DR Number:"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.lblTotalAmount.Location = New System.Drawing.Point(819, 570)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(55, 30)
        Me.lblTotalAmount.TabIndex = 92
        Me.lblTotalAmount.Text = "0.00"
        Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(659, 570)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 30)
        Me.Label10.TabIndex = 91
        Me.Label10.Text = "Total Amount:"
        '
        'btnSelectProduct
        '
        Me.btnSelectProduct.Location = New System.Drawing.Point(15, 233)
        Me.btnSelectProduct.Name = "btnSelectProduct"
        Me.btnSelectProduct.Size = New System.Drawing.Size(167, 31)
        Me.btnSelectProduct.TabIndex = 93
        Me.btnSelectProduct.Text = "Search Supplier Product"
        Me.btnSelectProduct.UseVisualStyleBackColor = True
        '
        'PurchaseReceiveForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1327, 618)
        Me.Controls.Add(Me.btnSelectProduct)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dgvProd)
        Me.Controls.Add(Me.gpEnterBarcode)
        Me.Controls.Add(Me.gpEnterProduct)
        Me.Controls.Add(Me.gpFields)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "PurchaseReceiveForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Receive Form (Add New)"
        Me.gpEnterBarcode.ResumeLayout(False)
        Me.gpEnterBarcode.PerformLayout()
        Me.gpEnterProduct.ResumeLayout(False)
        Me.gpEnterProduct.PerformLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpFields.ResumeLayout(False)
        Me.gpFields.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbPaymentType As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cbTerms As ComboBox
    Friend WithEvents txtPRNO As TextBox
    Friend WithEvents cbPO As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpETA As DateTimePicker
    Friend WithEvents dtp_pr_date As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpATA As DateTimePicker
    Friend WithEvents Label9 As Label
    Friend WithEvents btnSaveAndPrint As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents gpEnterBarcode As GroupBox
    Friend WithEvents txtEnterBarcode As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents gpEnterProduct As GroupBox
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents dgvProd As DataGridView
    Friend WithEvents gpFields As GroupBox
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtDrNo As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtProductDesc As TextBox
    Friend WithEvents cbUnit As ComboBox
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cbSupplier As ComboBox
    Friend WithEvents btnSelectProduct As Button
    Friend WithEvents btnAddSupplier As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents actual_quantity As DataGridViewTextBoxColumn
    Friend WithEvents product As DataGridViewTextBoxColumn
    Friend WithEvents brand As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents Color As DataGridViewTextBoxColumn
    Friend WithEvents cost As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents stock As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewButtonColumn
End Class
