<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseOrderForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbSupplier = New System.Windows.Forms.ComboBox()
        Me.txtPONO = New System.Windows.Forms.TextBox()
        Me.cbTerms = New System.Windows.Forms.ComboBox()
        Me.dtp_po_date = New System.Windows.Forms.DateTimePicker()
        Me.dtpETA = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnSaveAndPrint = New System.Windows.Forms.Button()
        Me.gpEnterBarcode = New System.Windows.Forms.GroupBox()
        Me.txtEnterBarcode = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgvProd = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.gpEnterProduct = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.btnAddToCart = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbUnit = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.cbPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gpFields = New System.Windows.Forms.GroupBox()
        Me.txtDeliverBy = New System.Windows.Forms.TextBox()
        Me.txtDeliverTo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gpEnterBarcode.SuspendLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpEnterProduct.SuspendLayout()
        Me.gpFields.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PO Number:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Select Supplier:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Select Terms:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(459, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ETA:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(457, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Date:"
        '
        'cbSupplier
        '
        Me.cbSupplier.FormattingEnabled = True
        Me.cbSupplier.Location = New System.Drawing.Point(134, 23)
        Me.cbSupplier.Name = "cbSupplier"
        Me.cbSupplier.Size = New System.Drawing.Size(288, 21)
        Me.cbSupplier.TabIndex = 5
        '
        'txtPONO
        '
        Me.txtPONO.Location = New System.Drawing.Point(134, 55)
        Me.txtPONO.Name = "txtPONO"
        Me.txtPONO.ReadOnly = True
        Me.txtPONO.Size = New System.Drawing.Size(288, 20)
        Me.txtPONO.TabIndex = 6
        '
        'cbTerms
        '
        Me.cbTerms.FormattingEnabled = True
        Me.cbTerms.Location = New System.Drawing.Point(134, 82)
        Me.cbTerms.Name = "cbTerms"
        Me.cbTerms.Size = New System.Drawing.Size(288, 21)
        Me.cbTerms.TabIndex = 7
        '
        'dtp_po_date
        '
        Me.dtp_po_date.Location = New System.Drawing.Point(536, 20)
        Me.dtp_po_date.Name = "dtp_po_date"
        Me.dtp_po_date.Size = New System.Drawing.Size(208, 20)
        Me.dtp_po_date.TabIndex = 8
        '
        'dtpETA
        '
        Me.dtpETA.Location = New System.Drawing.Point(536, 52)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(208, 20)
        Me.dtpETA.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(956, 599)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 30)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Total Amount:"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.lblTotalAmount.Location = New System.Drawing.Point(1116, 599)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(55, 30)
        Me.lblTotalAmount.TabIndex = 17
        Me.lblTotalAmount.Text = "0.00"
        Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1170, 23)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 38)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnSaveAndPrint
        '
        Me.btnSaveAndPrint.Location = New System.Drawing.Point(1170, 72)
        Me.btnSaveAndPrint.Name = "btnSaveAndPrint"
        Me.btnSaveAndPrint.Size = New System.Drawing.Size(102, 38)
        Me.btnSaveAndPrint.TabIndex = 19
        Me.btnSaveAndPrint.Text = "Save and Print"
        Me.btnSaveAndPrint.UseVisualStyleBackColor = True
        '
        'gpEnterBarcode
        '
        Me.gpEnterBarcode.Controls.Add(Me.txtEnterBarcode)
        Me.gpEnterBarcode.Controls.Add(Me.Label14)
        Me.gpEnterBarcode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEnterBarcode.Location = New System.Drawing.Point(15, 169)
        Me.gpEnterBarcode.Name = "gpEnterBarcode"
        Me.gpEnterBarcode.Size = New System.Drawing.Size(255, 58)
        Me.gpEnterBarcode.TabIndex = 61
        Me.gpEnterBarcode.TabStop = False
        Me.gpEnterBarcode.Text = "Enter Barcode"
        '
        'txtEnterBarcode
        '
        Me.txtEnterBarcode.Location = New System.Drawing.Point(73, 19)
        Me.txtEnterBarcode.Name = "txtEnterBarcode"
        Me.txtEnterBarcode.Size = New System.Drawing.Size(170, 21)
        Me.txtEnterBarcode.TabIndex = 56
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 15)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Barcode"
        '
        'dgvProd
        '
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Barcode, Me.quantity, Me.product, Me.brand, Me.unit, Me.Color, Me.cost, Me.amount, Me.stock, Me.action})
        Me.dgvProd.Location = New System.Drawing.Point(15, 233)
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.Size = New System.Drawing.Size(1296, 363)
        Me.dgvProd.TabIndex = 60
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
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        '
        'product
        '
        Me.product.HeaderText = "Product Description"
        Me.product.Name = "product"
        Me.product.ReadOnly = True
        Me.product.Width = 150
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
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 15)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Product Desc"
        '
        'txtProductDesc
        '
        Me.txtProductDesc.Location = New System.Drawing.Point(84, 20)
        Me.txtProductDesc.MaxLength = 32000
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.Size = New System.Drawing.Size(241, 21)
        Me.txtProductDesc.TabIndex = 64
        '
        'gpEnterProduct
        '
        Me.gpEnterProduct.Controls.Add(Me.Label20)
        Me.gpEnterProduct.Controls.Add(Me.cbColor)
        Me.gpEnterProduct.Controls.Add(Me.txtProductDesc)
        Me.gpEnterProduct.Controls.Add(Me.btnAddToCart)
        Me.gpEnterProduct.Controls.Add(Me.Label15)
        Me.gpEnterProduct.Controls.Add(Me.cbUnit)
        Me.gpEnterProduct.Controls.Add(Me.Label16)
        Me.gpEnterProduct.Controls.Add(Me.cbBrand)
        Me.gpEnterProduct.Controls.Add(Me.Label17)
        Me.gpEnterProduct.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEnterProduct.Location = New System.Drawing.Point(308, 169)
        Me.gpEnterProduct.Name = "gpEnterProduct"
        Me.gpEnterProduct.Size = New System.Drawing.Size(1003, 58)
        Me.gpEnterProduct.TabIndex = 62
        Me.gpEnterProduct.TabStop = False
        Me.gpEnterProduct.Text = "Enter Product"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(533, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 15)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "Color"
        '
        'cbColor
        '
        Me.cbColor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Location = New System.Drawing.Point(575, 21)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(149, 23)
        Me.cbColor.TabIndex = 65
        '
        'btnAddToCart
        '
        Me.btnAddToCart.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToCart.Location = New System.Drawing.Point(920, 13)
        Me.btnAddToCart.Name = "btnAddToCart"
        Me.btnAddToCart.Size = New System.Drawing.Size(77, 37)
        Me.btnAddToCart.TabIndex = 39
        Me.btnAddToCart.Text = "Add to Cart"
        Me.btnAddToCart.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(730, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 15)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Unit"
        '
        'cbUnit
        '
        Me.cbUnit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(784, 19)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(130, 23)
        Me.cbUnit.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(331, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 15)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Brand"
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(373, 19)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(143, 23)
        Me.cbBrand.TabIndex = 35
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(457, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Total Amount:"
        '
        'txtAmount
        '
        Me.txtAmount.ForeColor = System.Drawing.Color.Red
        Me.txtAmount.Location = New System.Drawing.Point(536, 82)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(208, 20)
        Me.txtAmount.TabIndex = 58
        '
        'cbPaymentType
        '
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Location = New System.Drawing.Point(134, 109)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(288, 21)
        Me.cbPaymentType.TabIndex = 65
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 13)
        Me.Label7.TabIndex = 64
        Me.Label7.Text = "Select Payment Type"
        '
        'gpFields
        '
        Me.gpFields.Controls.Add(Me.txtDeliverBy)
        Me.gpFields.Controls.Add(Me.txtDeliverTo)
        Me.gpFields.Controls.Add(Me.Label10)
        Me.gpFields.Controls.Add(Me.Label9)
        Me.gpFields.Controls.Add(Me.txtAmount)
        Me.gpFields.Controls.Add(Me.Label7)
        Me.gpFields.Controls.Add(Me.Label6)
        Me.gpFields.Controls.Add(Me.btnSave)
        Me.gpFields.Controls.Add(Me.btnSaveAndPrint)
        Me.gpFields.Controls.Add(Me.cbPaymentType)
        Me.gpFields.Controls.Add(Me.cbSupplier)
        Me.gpFields.Controls.Add(Me.txtPONO)
        Me.gpFields.Controls.Add(Me.cbTerms)
        Me.gpFields.Controls.Add(Me.dtp_po_date)
        Me.gpFields.Controls.Add(Me.dtpETA)
        Me.gpFields.Controls.Add(Me.Label2)
        Me.gpFields.Controls.Add(Me.Label1)
        Me.gpFields.Controls.Add(Me.Label3)
        Me.gpFields.Controls.Add(Me.Label5)
        Me.gpFields.Controls.Add(Me.Label4)
        Me.gpFields.Location = New System.Drawing.Point(12, 12)
        Me.gpFields.Name = "gpFields"
        Me.gpFields.Size = New System.Drawing.Size(1299, 151)
        Me.gpFields.TabIndex = 66
        Me.gpFields.TabStop = False
        Me.gpFields.Text = "Purchase Order"
        '
        'txtDeliverBy
        '
        Me.txtDeliverBy.Location = New System.Drawing.Point(911, 55)
        Me.txtDeliverBy.Name = "txtDeliverBy"
        Me.txtDeliverBy.Size = New System.Drawing.Size(161, 20)
        Me.txtDeliverBy.TabIndex = 69
        '
        'txtDeliverTo
        '
        Me.txtDeliverTo.Location = New System.Drawing.Point(911, 23)
        Me.txtDeliverTo.Name = "txtDeliverTo"
        Me.txtDeliverTo.Size = New System.Drawing.Size(161, 20)
        Me.txtDeliverTo.TabIndex = 68
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(829, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "Delivered by:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(829, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "Delivered to:"
        '
        'PurchaseOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 638)
        Me.Controls.Add(Me.gpEnterBarcode)
        Me.Controls.Add(Me.dgvProd)
        Me.Controls.Add(Me.gpEnterProduct)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gpFields)
        Me.Name = "PurchaseOrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Purchase Order Form (Add New)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gpEnterBarcode.ResumeLayout(False)
        Me.gpEnterBarcode.PerformLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpEnterProduct.ResumeLayout(False)
        Me.gpEnterProduct.PerformLayout()
        Me.gpFields.ResumeLayout(False)
        Me.gpFields.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents txtPONO As System.Windows.Forms.TextBox
    Friend WithEvents cbTerms As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_po_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnSaveAndPrint As System.Windows.Forms.Button
    Friend WithEvents gpEnterBarcode As GroupBox
    Friend WithEvents txtEnterBarcode As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents dgvProd As DataGridView
    Friend WithEvents Label17 As Label
    Friend WithEvents txtProductDesc As TextBox
    Friend WithEvents gpEnterProduct As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents cbUnit As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents cbPaymentType As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents product As DataGridViewTextBoxColumn
    Friend WithEvents brand As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents Color As DataGridViewTextBoxColumn
    Friend WithEvents cost As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents stock As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewButtonColumn
    Friend WithEvents gpFields As GroupBox
    Friend WithEvents txtDeliverBy As TextBox
    Friend WithEvents txtDeliverTo As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
End Class
