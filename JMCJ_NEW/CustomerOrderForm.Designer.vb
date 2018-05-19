<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerOrderForm
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
        Me.cbCustomer = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lvProd = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbProducts = New System.Windows.Forms.ComboBox
        Me.btnAddProd = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbCat = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblAmount = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbTermPayment = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpDateIssue = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDeliveredBy = New System.Windows.Forms.TextBox
        Me.txtReceivedBy = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbProdId = New System.Windows.Forms.ComboBox
        Me.dgvProd = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Barcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.product = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.brand = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.less = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.sell_price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbCustomer
        '
        Me.cbCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(118, 50)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(312, 32)
        Me.cbCustomer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'lvProd
        '
        Me.lvProd.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader2, Me.ColumnHeader9, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader7})
        Me.lvProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvProd.FullRowSelect = True
        Me.lvProd.GridLines = True
        Me.lvProd.Location = New System.Drawing.Point(16, 153)
        Me.lvProd.Name = "lvProd"
        Me.lvProd.Size = New System.Drawing.Size(939, 33)
        Me.lvProd.TabIndex = 2
        Me.lvProd.UseCompatibleStateImageBehavior = False
        Me.lvProd.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Products"
        Me.ColumnHeader1.Width = 170
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Brand"
        Me.ColumnHeader6.Width = 103
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Unit"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Price"
        Me.ColumnHeader2.Width = 78
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Sell Price"
        Me.ColumnHeader9.Width = 88
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Qty"
        Me.ColumnHeader3.Width = 69
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Amount"
        Me.ColumnHeader4.Width = 151
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Less"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "id"
        Me.ColumnHeader7.Width = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(305, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 24)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Products"
        '
        'cbProducts
        '
        Me.cbProducts.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProducts.FormattingEnabled = True
        Me.cbProducts.Location = New System.Drawing.Point(395, 102)
        Me.cbProducts.Name = "cbProducts"
        Me.cbProducts.Size = New System.Drawing.Size(279, 32)
        Me.cbProducts.TabIndex = 3
        '
        'btnAddProd
        '
        Me.btnAddProd.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddProd.Location = New System.Drawing.Point(704, 99)
        Me.btnAddProd.Name = "btnAddProd"
        Me.btnAddProd.Size = New System.Drawing.Size(101, 38)
        Me.btnAddProd.TabIndex = 5
        Me.btnAddProd.Text = "Add"
        Me.btnAddProd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Category"
        '
        'cbCat
        '
        Me.cbCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCat.FormattingEnabled = True
        Me.cbCat.Location = New System.Drawing.Point(118, 105)
        Me.cbCat.Name = "cbCat"
        Me.cbCat.Size = New System.Drawing.Size(171, 32)
        Me.cbCat.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(481, 417)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 22)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Total Amount"
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Red
        Me.lblAmount.Location = New System.Drawing.Point(607, 407)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(88, 39)
        Me.lblAmount.TabIndex = 10
        Me.lblAmount.Text = "0.00"
        '
        'btnRemove
        '
        Me.btnRemove.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(816, 99)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(101, 38)
        Me.btnRemove.TabIndex = 11
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(846, 407)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(109, 54)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "Save and Print"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 457)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 22)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Terms of Payment"
        '
        'cbTermPayment
        '
        Me.cbTermPayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTermPayment.FormattingEnabled = True
        Me.cbTermPayment.Items.AddRange(New Object() {"30 days", "60 days", "90 days", "120 days"})
        Me.cbTermPayment.Location = New System.Drawing.Point(180, 455)
        Me.cbTermPayment.Name = "cbTermPayment"
        Me.cbTermPayment.Size = New System.Drawing.Size(250, 28)
        Me.cbTermPayment.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 24)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Date Issue"
        '
        'dtpDateIssue
        '
        Me.dtpDateIssue.Location = New System.Drawing.Point(118, 12)
        Me.dtpDateIssue.Name = "dtpDateIssue"
        Me.dtpDateIssue.Size = New System.Drawing.Size(214, 20)
        Me.dtpDateIssue.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(760, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 24)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Delivered by:"
        '
        'txtDeliveredBy
        '
        Me.txtDeliveredBy.Location = New System.Drawing.Point(886, 16)
        Me.txtDeliveredBy.Name = "txtDeliveredBy"
        Me.txtDeliveredBy.Size = New System.Drawing.Size(272, 20)
        Me.txtDeliveredBy.TabIndex = 18
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.Location = New System.Drawing.Point(886, 42)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.Size = New System.Drawing.Size(272, 20)
        Me.txtReceivedBy.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(760, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 24)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Received by:"
        '
        'cbProdId
        '
        Me.cbProdId.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbProdId.FormattingEnabled = True
        Me.cbProdId.Location = New System.Drawing.Point(637, 292)
        Me.cbProdId.Name = "cbProdId"
        Me.cbProdId.Size = New System.Drawing.Size(168, 32)
        Me.cbProdId.TabIndex = 23
        Me.cbProdId.Visible = False
        '
        'dgvProd
        '
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Barcode, Me.quantity, Me.product, Me.brand, Me.unit, Me.price, Me.less, Me.Column1, Me.Column2, Me.sell_price, Me.amount, Me.id})
        Me.dgvProd.Location = New System.Drawing.Point(16, 153)
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.Size = New System.Drawing.Size(1145, 233)
        Me.dgvProd.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 417)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 22)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Payment Type"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"30 days", "60 days", "90 days", "120 days"})
        Me.ComboBox1.Location = New System.Drawing.Point(180, 415)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(250, 28)
        Me.ComboBox1.TabIndex = 26
        '
        'Barcode
        '
        Me.Barcode.HeaderText = "Barcode"
        Me.Barcode.Name = "Barcode"
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        '
        'product
        '
        Me.product.HeaderText = "Products"
        Me.product.Name = "product"
        Me.product.ReadOnly = True
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
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'less
        '
        Me.less.HeaderText = "Less"
        Me.less.Name = "less"
        Me.less.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Add less"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.Text = "ADD"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Set less to 0"
        Me.Column2.Name = "Column2"
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'sell_price
        '
        Me.sell_price.HeaderText = "Sell Price"
        Me.sell_price.Name = "sell_price"
        Me.sell_price.ReadOnly = True
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'id
        '
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'CustomerOrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1183, 529)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvProd)
        Me.Controls.Add(Me.cbProdId)
        Me.Controls.Add(Me.txtReceivedBy)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDeliveredBy)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpDateIssue)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbTermPayment)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbCat)
        Me.Controls.Add(Me.btnAddProd)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbProducts)
        Me.Controls.Add(Me.lvProd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbCustomer)
        Me.Name = "CustomerOrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Order"
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvProd As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbProducts As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddProd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbCat As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbTermPayment As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpDateIssue As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDeliveredBy As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivedBy As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbProdId As System.Windows.Forms.ComboBox
    Friend WithEvents dgvProd As System.Windows.Forms.DataGridView
    Friend WithEvents Barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents less As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents sell_price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
