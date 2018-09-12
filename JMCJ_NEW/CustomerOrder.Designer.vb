<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerOrder
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.dgvProd = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_issue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.invoice_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount_paid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.payment_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivery_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivered_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.received_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approved_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.checked_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(210, 26)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 23)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(311, 26)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Void"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(118, 26)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 8
        Me.btnUpdate.Text = "View"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(22, 26)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 7
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'dgvProd
        '
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProd.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.date_issue, Me.customer, Me.invoice_no, Me.amount, Me.amount_paid, Me.payment_status, Me.delivery_status, Me.paid, Me.delivered_by, Me.received_by, Me.approved_by, Me.checked_by})
        Me.dgvProd.Location = New System.Drawing.Point(22, 75)
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.Size = New System.Drawing.Size(1150, 398)
        Me.dgvProd.TabIndex = 10
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'date_issue
        '
        Me.date_issue.HeaderText = "Date Invoice"
        Me.date_issue.Name = "date_issue"
        Me.date_issue.ReadOnly = True
        '
        'customer
        '
        Me.customer.HeaderText = "Customer"
        Me.customer.Name = "customer"
        '
        'invoice_no
        '
        Me.invoice_no.HeaderText = "Invoice No"
        Me.invoice_no.Name = "invoice_no"
        Me.invoice_no.ReadOnly = True
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'amount_paid
        '
        Me.amount_paid.HeaderText = "Amount Paid"
        Me.amount_paid.Name = "amount_paid"
        Me.amount_paid.ReadOnly = True
        '
        'payment_status
        '
        Me.payment_status.HeaderText = "Payment Status"
        Me.payment_status.Name = "payment_status"
        Me.payment_status.ReadOnly = True
        '
        'delivery_status
        '
        Me.delivery_status.HeaderText = "Delivery Status"
        Me.delivery_status.Name = "delivery_status"
        Me.delivery_status.ReadOnly = True
        '
        'paid
        '
        Me.paid.HeaderText = "Paid"
        Me.paid.Name = "paid"
        Me.paid.ReadOnly = True
        '
        'delivered_by
        '
        Me.delivered_by.HeaderText = "Delivered By"
        Me.delivered_by.Name = "delivered_by"
        Me.delivered_by.ReadOnly = True
        '
        'received_by
        '
        Me.received_by.HeaderText = "Received By"
        Me.received_by.Name = "received_by"
        Me.received_by.ReadOnly = True
        '
        'approved_by
        '
        Me.approved_by.HeaderText = "Approved By"
        Me.approved_by.Name = "approved_by"
        Me.approved_by.ReadOnly = True
        '
        'checked_by
        '
        Me.checked_by.HeaderText = "Checked By"
        Me.checked_by.Name = "checked_by"
        Me.checked_by.ReadOnly = True
        '
        'CustomerOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1179, 517)
        Me.Controls.Add(Me.dgvProd)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "CustomerOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Order"
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents dgvProd As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents date_issue As DataGridViewTextBoxColumn
    Friend WithEvents customer As DataGridViewTextBoxColumn
    Friend WithEvents invoice_no As DataGridViewTextBoxColumn
    Friend WithEvents amount As DataGridViewTextBoxColumn
    Friend WithEvents amount_paid As DataGridViewTextBoxColumn
    Friend WithEvents payment_status As DataGridViewTextBoxColumn
    Friend WithEvents delivery_status As DataGridViewTextBoxColumn
    Friend WithEvents paid As DataGridViewTextBoxColumn
    Friend WithEvents delivered_by As DataGridViewTextBoxColumn
    Friend WithEvents received_by As DataGridViewTextBoxColumn
    Friend WithEvents approved_by As DataGridViewTextBoxColumn
    Friend WithEvents checked_by As DataGridViewTextBoxColumn
End Class
