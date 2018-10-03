<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerReturnForm
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpEnterBarcode = New System.Windows.Forms.GroupBox()
        Me.txtEnterBarcode = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.gpEnterProduct = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.btnAddToCart = New System.Windows.Forms.Button()
        Me.cbUnit = New System.Windows.Forms.ComboBox()
        Me.dgvProd = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sell_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.cbInvoiceNo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCRNo = New System.Windows.Forms.TextBox()
        Me.dtpDateRecorded = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.cbReason = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.gpField = New System.Windows.Forms.GroupBox()
        Me.txtIssueBy = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSelectProduct = New System.Windows.Forms.Button()
        Me.gpEnterBarcode.SuspendLayout()
        Me.gpEnterProduct.SuspendLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpField.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpEnterBarcode
        '
        Me.gpEnterBarcode.Controls.Add(Me.txtEnterBarcode)
        Me.gpEnterBarcode.Controls.Add(Me.Label14)
        Me.gpEnterBarcode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEnterBarcode.Location = New System.Drawing.Point(6, 203)
        Me.gpEnterBarcode.Name = "gpEnterBarcode"
        Me.gpEnterBarcode.Size = New System.Drawing.Size(255, 58)
        Me.gpEnterBarcode.TabIndex = 64
        Me.gpEnterBarcode.TabStop = False
        Me.gpEnterBarcode.Text = "Enter Barcode"
        '
        'txtEnterBarcode
        '
        Me.txtEnterBarcode.Location = New System.Drawing.Point(79, 24)
        Me.txtEnterBarcode.Name = "txtEnterBarcode"
        Me.txtEnterBarcode.Size = New System.Drawing.Size(170, 21)
        Me.txtEnterBarcode.TabIndex = 56
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 27)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 15)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Barcode"
        '
        'txtProductDesc
        '
        Me.txtProductDesc.Location = New System.Drawing.Point(76, 24)
        Me.txtProductDesc.MaxLength = 32000
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.Size = New System.Drawing.Size(173, 21)
        Me.txtProductDesc.TabIndex = 64
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(454, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 15)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Unit"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(255, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 15)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Brand"
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(297, 24)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(143, 23)
        Me.cbBrand.TabIndex = 35
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(64, 15)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Description"
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
        Me.gpEnterProduct.Location = New System.Drawing.Point(267, 203)
        Me.gpEnterProduct.Name = "gpEnterProduct"
        Me.gpEnterProduct.Size = New System.Drawing.Size(916, 58)
        Me.gpEnterProduct.TabIndex = 65
        Me.gpEnterProduct.TabStop = False
        Me.gpEnterProduct.Text = "Enter Product"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(626, 27)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 15)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "Color"
        '
        'cbColor
        '
        Me.cbColor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Location = New System.Drawing.Point(668, 22)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(149, 23)
        Me.cbColor.TabIndex = 65
        '
        'btnAddToCart
        '
        Me.btnAddToCart.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToCart.Location = New System.Drawing.Point(829, 16)
        Me.btnAddToCart.Name = "btnAddToCart"
        Me.btnAddToCart.Size = New System.Drawing.Size(77, 37)
        Me.btnAddToCart.TabIndex = 39
        Me.btnAddToCart.Text = "Add to Cart"
        Me.btnAddToCart.UseVisualStyleBackColor = True
        '
        'cbUnit
        '
        Me.cbUnit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(490, 24)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(130, 23)
        Me.cbUnit.TabIndex = 37
        '
        'dgvProd
        '
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Barcode, Me.quantity, Me.product, Me.brand, Me.unit, Me.Color, Me.price, Me.sell_price, Me.amount, Me.stock, Me.action})
        Me.dgvProd.Location = New System.Drawing.Point(6, 316)
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.Size = New System.Drawing.Size(1452, 257)
        Me.dgvProd.TabIndex = 66
        '
        'id
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.DefaultCellStyle = DataGridViewCellStyle2
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
        Me.quantity.Width = 50
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
        'price
        '
        Me.price.HeaderText = "Unit Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'sell_price
        '
        Me.sell_price.HeaderText = "Sell Price"
        Me.sell_price.Name = "sell_price"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Customer:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(415, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Invoice No:"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(145, 65)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(212, 21)
        Me.cbCustomer.TabIndex = 70
        '
        'cbInvoiceNo
        '
        Me.cbInvoiceNo.FormattingEnabled = True
        Me.cbInvoiceNo.Location = New System.Drawing.Point(494, 35)
        Me.cbInvoiceNo.Name = "cbInvoiceNo"
        Me.cbInvoiceNo.Size = New System.Drawing.Size(201, 21)
        Me.cbInvoiceNo.TabIndex = 71
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "CR No:"
        '
        'txtCRNo
        '
        Me.txtCRNo.Enabled = False
        Me.txtCRNo.Location = New System.Drawing.Point(145, 35)
        Me.txtCRNo.Name = "txtCRNo"
        Me.txtCRNo.Size = New System.Drawing.Size(212, 20)
        Me.txtCRNo.TabIndex = 73
        '
        'dtpDateRecorded
        '
        Me.dtpDateRecorded.Location = New System.Drawing.Point(803, 34)
        Me.dtpDateRecorded.Name = "dtpDateRecorded"
        Me.dtpDateRecorded.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateRecorded.TabIndex = 74
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(714, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Date Recorded:"
        '
        'txtReason
        '
        Me.txtReason.Enabled = False
        Me.txtReason.Location = New System.Drawing.Point(145, 130)
        Me.txtReason.Multiline = True
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(212, 53)
        Me.txtReason.TabIndex = 79
        '
        'cbReason
        '
        Me.cbReason.FormattingEnabled = True
        Me.cbReason.Items.AddRange(New Object() {"Select", "Excess Product", "Wrong Product", "Other"})
        Me.cbReason.Location = New System.Drawing.Point(145, 98)
        Me.cbReason.Name = "cbReason"
        Me.cbReason.Size = New System.Drawing.Size(212, 21)
        Me.cbReason.TabIndex = 78
        Me.cbReason.Text = "Select"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Reason:"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(1081, 31)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(92, 30)
        Me.btnSave.TabIndex = 80
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(415, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Total Amount:"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.txtTotalAmount.Location = New System.Drawing.Point(495, 65)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtTotalAmount.TabIndex = 81
        Me.txtTotalAmount.Text = "0.00"
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gpField
        '
        Me.gpField.Controls.Add(Me.txtIssueBy)
        Me.gpField.Controls.Add(Me.Label7)
        Me.gpField.Location = New System.Drawing.Point(6, 13)
        Me.gpField.Name = "gpField"
        Me.gpField.Size = New System.Drawing.Size(1177, 184)
        Me.gpField.TabIndex = 83
        Me.gpField.TabStop = False
        '
        'txtIssueBy
        '
        Me.txtIssueBy.Enabled = False
        Me.txtIssueBy.Location = New System.Drawing.Point(786, 52)
        Me.txtIssueBy.Name = "txtIssueBy"
        Me.txtIssueBy.ReadOnly = True
        Me.txtIssueBy.Size = New System.Drawing.Size(200, 20)
        Me.txtIssueBy.TabIndex = 84
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(697, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "Issued By:"
        '
        'btnSelectProduct
        '
        Me.btnSelectProduct.Location = New System.Drawing.Point(6, 267)
        Me.btnSelectProduct.Name = "btnSelectProduct"
        Me.btnSelectProduct.Size = New System.Drawing.Size(167, 31)
        Me.btnSelectProduct.TabIndex = 84
        Me.btnSelectProduct.Text = "Select Product"
        Me.btnSelectProduct.UseVisualStyleBackColor = True
        '
        'CustomerReturnForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 585)
        Me.Controls.Add(Me.btnSelectProduct)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTotalAmount)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtReason)
        Me.Controls.Add(Me.cbReason)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpDateRecorded)
        Me.Controls.Add(Me.txtCRNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbInvoiceNo)
        Me.Controls.Add(Me.cbCustomer)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvProd)
        Me.Controls.Add(Me.gpEnterBarcode)
        Me.Controls.Add(Me.gpEnterProduct)
        Me.Controls.Add(Me.gpField)
        Me.Name = "CustomerReturnForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Return"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gpEnterBarcode.ResumeLayout(False)
        Me.gpEnterBarcode.PerformLayout()
        Me.gpEnterProduct.ResumeLayout(False)
        Me.gpEnterProduct.PerformLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpField.ResumeLayout(False)
        Me.gpField.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gpEnterBarcode As GroupBox
    Friend WithEvents txtEnterBarcode As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtProductDesc As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents gpEnterProduct As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents cbUnit As ComboBox
    Friend WithEvents dgvProd As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cbCustomer As ComboBox
    Friend WithEvents cbInvoiceNo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCRNo As TextBox
    Friend WithEvents dtpDateRecorded As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents txtReason As TextBox
    Friend WithEvents cbReason As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents product As DataGridViewTextBoxColumn
    Friend WithEvents brand As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents Color As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents sell_price As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents stock As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewButtonColumn
    Friend WithEvents btnSave As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents gpField As GroupBox
    Friend WithEvents txtIssueBy As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSelectProduct As Button
End Class
