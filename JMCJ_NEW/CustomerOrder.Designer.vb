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
        Me.dgvCO = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_issue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.invoice_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.received_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivered_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.net_amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.payment_method = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.terms = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        CType(Me.dgvCO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCO
        '
        Me.dgvCO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.date_issue, Me.invoice_no, Me.customer, Me.received_by, Me.delivered_by, Me.net_amount, Me.payment_method, Me.terms, Me.status})
        Me.dgvCO.Location = New System.Drawing.Point(24, 84)
        Me.dgvCO.Name = "dgvCO"
        Me.dgvCO.Size = New System.Drawing.Size(969, 323)
        Me.dgvCO.TabIndex = 0
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
        'invoice_no
        '
        Me.invoice_no.HeaderText = "Invoice No"
        Me.invoice_no.Name = "invoice_no"
        Me.invoice_no.ReadOnly = True
        '
        'customer
        '
        Me.customer.HeaderText = "Customer"
        Me.customer.Name = "customer"
        Me.customer.ReadOnly = True
        '
        'received_by
        '
        Me.received_by.HeaderText = "Received By"
        Me.received_by.Name = "received_by"
        Me.received_by.ReadOnly = True
        '
        'delivered_by
        '
        Me.delivered_by.HeaderText = "Delivered By"
        Me.delivered_by.Name = "delivered_by"
        Me.delivered_by.ReadOnly = True
        '
        'net_amount
        '
        Me.net_amount.HeaderText = "Total Amount"
        Me.net_amount.Name = "net_amount"
        Me.net_amount.ReadOnly = True
        '
        'payment_method
        '
        Me.payment_method.HeaderText = "Payment Method"
        Me.payment_method.Name = "payment_method"
        Me.payment_method.ReadOnly = True
        Me.payment_method.Width = 120
        '
        'terms
        '
        Me.terms.HeaderText = "Terms"
        Me.terms.Name = "terms"
        Me.terms.ReadOnly = True
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(24, 23)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "Add New +"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Location = New System.Drawing.Point(230, 23)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(75, 23)
        Me.btnVoid.TabIndex = 2
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(128, 23)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 3
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'CustomerOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 459)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.dgvCO)
        Me.Name = "CustomerOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvCO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvCO As DataGridView
    Friend WithEvents btnNew As Button
    Friend WithEvents btnVoid As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents date_issue As DataGridViewTextBoxColumn
    Friend WithEvents invoice_no As DataGridViewTextBoxColumn
    Friend WithEvents customer As DataGridViewTextBoxColumn
    Friend WithEvents received_by As DataGridViewTextBoxColumn
    Friend WithEvents delivered_by As DataGridViewTextBoxColumn
    Friend WithEvents net_amount As DataGridViewTextBoxColumn
    Friend WithEvents payment_method As DataGridViewTextBoxColumn
    Friend WithEvents terms As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents btnView As Button
End Class
