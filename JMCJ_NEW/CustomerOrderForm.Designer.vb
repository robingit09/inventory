<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CustomerOrderForm
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
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gpFields = New System.Windows.Forms.GroupBox()
        Me.btnExact = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalAmountPaid = New System.Windows.Forms.TextBox()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.txtReceivedBy = New System.Windows.Forms.TextBox()
        Me.txtDeliveredBy = New System.Windows.Forms.TextBox()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.dtpDateIssue = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbPaymentType = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gpPaid = New System.Windows.Forms.GroupBox()
        Me.rPaidNo = New System.Windows.Forms.RadioButton()
        Me.rPaidYes = New System.Windows.Forms.RadioButton()
        Me.cbTerms = New System.Windows.Forms.ComboBox()
        Me.btnAddCustomer = New System.Windows.Forms.Button()
        Me.btnSaveAndPrint = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtEnterBarcode = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gpEnterBarcode = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.gpEnterProduct = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cbColor = New System.Windows.Forms.ComboBox()
        Me.txtProductDesc = New System.Windows.Forms.TextBox()
        Me.btnAddToCart = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbUnit = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbBrand = New System.Windows.Forms.ComboBox()
        Me.dgvProd = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Color = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.less = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.add_less = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.sell_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.action = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btnSelectProduct = New System.Windows.Forms.Button()
        Me.gpFields.SuspendLayout()
        Me.gpPaid.SuspendLayout()
        Me.gpEnterBarcode.SuspendLayout()
        Me.gpEnterProduct.SuspendLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCheck
        '
        Me.btnCheck.ForeColor = System.Drawing.Color.Green
        Me.btnCheck.Location = New System.Drawing.Point(984, 23)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(71, 31)
        Me.btnCheck.TabIndex = 69
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Customer"
        '
        'gpFields
        '
        Me.gpFields.Controls.Add(Me.btnExact)
        Me.gpFields.Controls.Add(Me.Label8)
        Me.gpFields.Controls.Add(Me.txtAddress)
        Me.gpFields.Controls.Add(Me.Label3)
        Me.gpFields.Controls.Add(Me.txtTotalAmountPaid)
        Me.gpFields.Controls.Add(Me.btnApprove)
        Me.gpFields.Controls.Add(Me.btnCheck)
        Me.gpFields.Controls.Add(Me.txtReceivedBy)
        Me.gpFields.Controls.Add(Me.Label1)
        Me.gpFields.Controls.Add(Me.txtDeliveredBy)
        Me.gpFields.Controls.Add(Me.cbCustomer)
        Me.gpFields.Controls.Add(Me.Label19)
        Me.gpFields.Controls.Add(Me.Label2)
        Me.gpFields.Controls.Add(Me.Label18)
        Me.gpFields.Controls.Add(Me.dtpDateIssue)
        Me.gpFields.Controls.Add(Me.Label4)
        Me.gpFields.Controls.Add(Me.lblTotalAmount)
        Me.gpFields.Controls.Add(Me.Label5)
        Me.gpFields.Controls.Add(Me.Label13)
        Me.gpFields.Controls.Add(Me.txtInvoiceNo)
        Me.gpFields.Controls.Add(Me.txtAmount)
        Me.gpFields.Controls.Add(Me.txtRemarks)
        Me.gpFields.Controls.Add(Me.Label6)
        Me.gpFields.Controls.Add(Me.Label11)
        Me.gpFields.Controls.Add(Me.cbPaymentType)
        Me.gpFields.Controls.Add(Me.Label12)
        Me.gpFields.Controls.Add(Me.gpPaid)
        Me.gpFields.Controls.Add(Me.cbTerms)
        Me.gpFields.Controls.Add(Me.btnAddCustomer)
        Me.gpFields.Controls.Add(Me.btnSaveAndPrint)
        Me.gpFields.Controls.Add(Me.btnSave)
        Me.gpFields.Location = New System.Drawing.Point(12, 12)
        Me.gpFields.Name = "gpFields"
        Me.gpFields.Size = New System.Drawing.Size(1322, 242)
        Me.gpFields.TabIndex = 70
        Me.gpFields.TabStop = False
        Me.gpFields.Text = "Customer Order Form"
        '
        'btnExact
        '
        Me.btnExact.Location = New System.Drawing.Point(314, 173)
        Me.btnExact.Name = "btnExact"
        Me.btnExact.Size = New System.Drawing.Size(88, 23)
        Me.btnExact.TabIndex = 75
        Me.btnExact.Text = "Exact"
        Me.btnExact.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 73
        Me.Label8.Text = "Address"
        '
        'txtAddress
        '
        Me.txtAddress.ForeColor = System.Drawing.Color.Black
        Me.txtAddress.Location = New System.Drawing.Point(108, 68)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(294, 20)
        Me.txtAddress.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Total Amount Paid"
        '
        'txtTotalAmountPaid
        '
        Me.txtTotalAmountPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmountPaid.ForeColor = System.Drawing.Color.Red
        Me.txtTotalAmountPaid.Location = New System.Drawing.Point(108, 176)
        Me.txtTotalAmountPaid.Name = "txtTotalAmountPaid"
        Me.txtTotalAmountPaid.Size = New System.Drawing.Size(200, 20)
        Me.txtTotalAmountPaid.TabIndex = 72
        Me.txtTotalAmountPaid.Text = "0.00"
        '
        'btnApprove
        '
        Me.btnApprove.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnApprove.Location = New System.Drawing.Point(1061, 24)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(71, 31)
        Me.btnApprove.TabIndex = 70
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = True
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.Location = New System.Drawing.Point(797, 133)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.Size = New System.Drawing.Size(241, 20)
        Me.txtReceivedBy.TabIndex = 68
        '
        'txtDeliveredBy
        '
        Me.txtDeliveredBy.Location = New System.Drawing.Point(797, 91)
        Me.txtDeliveredBy.Name = "txtDeliveredBy"
        Me.txtDeliveredBy.Size = New System.Drawing.Size(241, 20)
        Me.txtDeliveredBy.TabIndex = 67
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(108, 39)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(200, 21)
        Me.cbCustomer.TabIndex = 28
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(794, 115)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 62
        Me.Label19.Text = "Received by"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Date Issue"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(794, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 60
        Me.Label18.Text = "Delivered by"
        '
        'dtpDateIssue
        '
        Me.dtpDateIssue.Location = New System.Drawing.Point(108, 98)
        Me.dtpDateIssue.Name = "dtpDateIssue"
        Me.dtpDateIssue.Size = New System.Drawing.Size(294, 20)
        Me.dtpDateIssue.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Invoice Number"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.AutoSize = True
        Me.lblTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmount.ForeColor = System.Drawing.Color.Red
        Me.lblTotalAmount.Location = New System.Drawing.Point(950, 184)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(88, 39)
        Me.lblTotalAmount.TabIndex = 55
        Me.lblTotalAmount.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Total Amount"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(793, 196)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 22)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Total Amount"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.Enabled = False
        Me.txtInvoiceNo.Location = New System.Drawing.Point(108, 124)
        Me.txtInvoiceNo.MaxLength = 5
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(294, 20)
        Me.txtInvoiceNo.TabIndex = 35
        '
        'txtAmount
        '
        Me.txtAmount.Enabled = False
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.ForeColor = System.Drawing.Color.Red
        Me.txtAmount.Location = New System.Drawing.Point(108, 150)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(294, 20)
        Me.txtAmount.TabIndex = 36
        Me.txtAmount.Text = "0.00"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(507, 128)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(256, 64)
        Me.txtRemarks.TabIndex = 47
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(426, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Payment Type"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(426, 201)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Terms"
        '
        'cbPaymentType
        '
        Me.cbPaymentType.FormattingEnabled = True
        Me.cbPaymentType.Location = New System.Drawing.Point(507, 39)
        Me.cbPaymentType.Name = "cbPaymentType"
        Me.cbPaymentType.Size = New System.Drawing.Size(256, 21)
        Me.cbPaymentType.TabIndex = 38
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(426, 131)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Remarks"
        '
        'gpPaid
        '
        Me.gpPaid.Controls.Add(Me.rPaidNo)
        Me.gpPaid.Controls.Add(Me.rPaidYes)
        Me.gpPaid.Location = New System.Drawing.Point(429, 66)
        Me.gpPaid.Name = "gpPaid"
        Me.gpPaid.Size = New System.Drawing.Size(120, 52)
        Me.gpPaid.TabIndex = 39
        Me.gpPaid.TabStop = False
        Me.gpPaid.Text = "Is paid ?"
        '
        'rPaidNo
        '
        Me.rPaidNo.AutoSize = True
        Me.rPaidNo.Location = New System.Drawing.Point(70, 19)
        Me.rPaidNo.Name = "rPaidNo"
        Me.rPaidNo.Size = New System.Drawing.Size(39, 17)
        Me.rPaidNo.TabIndex = 1
        Me.rPaidNo.TabStop = True
        Me.rPaidNo.Text = "No"
        Me.rPaidNo.UseVisualStyleBackColor = True
        '
        'rPaidYes
        '
        Me.rPaidYes.AutoSize = True
        Me.rPaidYes.Location = New System.Drawing.Point(21, 19)
        Me.rPaidYes.Name = "rPaidYes"
        Me.rPaidYes.Size = New System.Drawing.Size(43, 17)
        Me.rPaidYes.TabIndex = 0
        Me.rPaidYes.TabStop = True
        Me.rPaidYes.Text = "Yes"
        Me.rPaidYes.UseVisualStyleBackColor = True
        '
        'cbTerms
        '
        Me.cbTerms.FormattingEnabled = True
        Me.cbTerms.Location = New System.Drawing.Point(507, 198)
        Me.cbTerms.Name = "cbTerms"
        Me.cbTerms.Size = New System.Drawing.Size(256, 21)
        Me.cbTerms.TabIndex = 43
        '
        'btnAddCustomer
        '
        Me.btnAddCustomer.Location = New System.Drawing.Point(314, 37)
        Me.btnAddCustomer.Name = "btnAddCustomer"
        Me.btnAddCustomer.Size = New System.Drawing.Size(88, 23)
        Me.btnAddCustomer.TabIndex = 51
        Me.btnAddCustomer.Text = "Add Customer"
        Me.btnAddCustomer.UseVisualStyleBackColor = True
        '
        'btnSaveAndPrint
        '
        Me.btnSaveAndPrint.Location = New System.Drawing.Point(885, 24)
        Me.btnSaveAndPrint.Name = "btnSaveAndPrint"
        Me.btnSaveAndPrint.Size = New System.Drawing.Size(93, 31)
        Me.btnSaveAndPrint.TabIndex = 50
        Me.btnSaveAndPrint.Text = "Save and Print"
        Me.btnSaveAndPrint.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(797, 23)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(82, 32)
        Me.btnSave.TabIndex = 48
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtEnterBarcode
        '
        Me.txtEnterBarcode.Location = New System.Drawing.Point(61, 19)
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
        'gpEnterBarcode
        '
        Me.gpEnterBarcode.Controls.Add(Me.txtEnterBarcode)
        Me.gpEnterBarcode.Controls.Add(Me.Label14)
        Me.gpEnterBarcode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEnterBarcode.Location = New System.Drawing.Point(12, 260)
        Me.gpEnterBarcode.Name = "gpEnterBarcode"
        Me.gpEnterBarcode.Size = New System.Drawing.Size(249, 58)
        Me.gpEnterBarcode.TabIndex = 71
        Me.gpEnterBarcode.TabStop = False
        Me.gpEnterBarcode.Text = "Enter Barcode"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 25)
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
        Me.gpEnterProduct.Location = New System.Drawing.Point(267, 260)
        Me.gpEnterProduct.Name = "gpEnterProduct"
        Me.gpEnterProduct.Size = New System.Drawing.Size(1067, 58)
        Me.gpEnterProduct.TabIndex = 72
        Me.gpEnterProduct.TabStop = False
        Me.gpEnterProduct.Text = "Enter Product"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(712, 26)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 15)
        Me.Label20.TabIndex = 66
        Me.Label20.Text = "Color"
        '
        'cbColor
        '
        Me.cbColor.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbColor.FormattingEnabled = True
        Me.cbColor.Location = New System.Drawing.Point(754, 23)
        Me.cbColor.Name = "cbColor"
        Me.cbColor.Size = New System.Drawing.Size(149, 23)
        Me.cbColor.TabIndex = 65
        '
        'txtProductDesc
        '
        Me.txtProductDesc.Location = New System.Drawing.Point(86, 23)
        Me.txtProductDesc.MaxLength = 32000
        Me.txtProductDesc.Name = "txtProductDesc"
        Me.txtProductDesc.Size = New System.Drawing.Size(228, 21)
        Me.txtProductDesc.TabIndex = 64
        '
        'btnAddToCart
        '
        Me.btnAddToCart.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddToCart.Location = New System.Drawing.Point(984, 15)
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
        Me.Label15.Location = New System.Drawing.Point(529, 26)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 15)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Unit"
        '
        'cbUnit
        '
        Me.cbUnit.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUnit.FormattingEnabled = True
        Me.cbUnit.Location = New System.Drawing.Point(565, 23)
        Me.cbUnit.Name = "cbUnit"
        Me.cbUnit.Size = New System.Drawing.Size(130, 23)
        Me.cbUnit.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(329, 26)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 15)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Brand"
        '
        'cbBrand
        '
        Me.cbBrand.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbBrand.FormattingEnabled = True
        Me.cbBrand.Location = New System.Drawing.Point(380, 23)
        Me.cbBrand.Name = "cbBrand"
        Me.cbBrand.Size = New System.Drawing.Size(143, 23)
        Me.cbBrand.TabIndex = 35
        '
        'dgvProd
        '
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Barcode, Me.quantity, Me.product, Me.brand, Me.unit, Me.Color, Me.price, Me.less, Me.add_less, Me.Column2, Me.sell_price, Me.amount, Me.stock, Me.action})
        Me.dgvProd.Location = New System.Drawing.Point(12, 361)
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.Size = New System.Drawing.Size(1377, 315)
        Me.dgvProd.TabIndex = 73
        '
        'id
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.DefaultCellStyle = DataGridViewCellStyle1
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
        Me.Barcode.Width = 80
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
        'less
        '
        Me.less.HeaderText = "Less"
        Me.less.Name = "less"
        Me.less.ReadOnly = True
        '
        'add_less
        '
        Me.add_less.HeaderText = "Add less"
        Me.add_less.Name = "add_less"
        Me.add_less.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.add_less.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.add_less.Text = "ADD"
        Me.add_less.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Set less to 0"
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column2.Width = 80
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
        'btnSelectProduct
        '
        Me.btnSelectProduct.Location = New System.Drawing.Point(12, 324)
        Me.btnSelectProduct.Name = "btnSelectProduct"
        Me.btnSelectProduct.Size = New System.Drawing.Size(167, 31)
        Me.btnSelectProduct.TabIndex = 75
        Me.btnSelectProduct.Text = "Select Product"
        Me.btnSelectProduct.UseVisualStyleBackColor = True
        '
        'CustomerOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 688)
        Me.Controls.Add(Me.btnSelectProduct)
        Me.Controls.Add(Me.dgvProd)
        Me.Controls.Add(Me.gpEnterProduct)
        Me.Controls.Add(Me.gpEnterBarcode)
        Me.Controls.Add(Me.gpFields)
        Me.Name = "CustomerOrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Order Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gpFields.ResumeLayout(False)
        Me.gpFields.PerformLayout()
        Me.gpPaid.ResumeLayout(False)
        Me.gpPaid.PerformLayout()
        Me.gpEnterBarcode.ResumeLayout(False)
        Me.gpEnterBarcode.PerformLayout()
        Me.gpEnterProduct.ResumeLayout(False)
        Me.gpEnterProduct.PerformLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCheck As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents gpFields As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtAddress As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTotalAmountPaid As TextBox
    Friend WithEvents btnApprove As Button
    Friend WithEvents txtReceivedBy As TextBox
    Friend WithEvents txtDeliveredBy As TextBox
    Friend WithEvents cbCustomer As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents dtpDateIssue As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtInvoiceNo As TextBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbPaymentType As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents gpPaid As GroupBox
    Friend WithEvents rPaidNo As RadioButton
    Friend WithEvents rPaidYes As RadioButton
    Friend WithEvents cbTerms As ComboBox
    Friend WithEvents btnAddCustomer As Button
    Friend WithEvents btnSaveAndPrint As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents txtEnterBarcode As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents gpEnterBarcode As GroupBox
    Friend WithEvents Label17 As Label
    Friend WithEvents gpEnterProduct As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cbColor As ComboBox
    Friend WithEvents txtProductDesc As TextBox
    Friend WithEvents btnAddToCart As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents cbUnit As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cbBrand As ComboBox
    Friend WithEvents dgvProd As DataGridView
    Friend WithEvents btnExact As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Barcode As DataGridViewTextBoxColumn
    Friend WithEvents quantity As DataGridViewTextBoxColumn
    Friend WithEvents product As DataGridViewTextBoxColumn
    Friend WithEvents brand As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents Color As DataGridViewTextBoxColumn
    Friend WithEvents price As DataGridViewTextBoxColumn
    Friend WithEvents less As DataGridViewTextBoxColumn
    Friend WithEvents add_less As DataGridViewButtonColumn
    Friend WithEvents Column2 As DataGridViewButtonColumn
    Friend WithEvents sell_price As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents stock As DataGridViewTextBoxColumn
    Friend WithEvents action As DataGridViewButtonColumn
    Friend WithEvents btnSelectProduct As Button
End Class
