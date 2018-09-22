<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseReceive
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
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.dgvPR = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dr_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivery_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        CType(Me.dgvPR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(119, 26)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 29)
        Me.btnView.TabIndex = 7
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(323, 26)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(83, 29)
        Me.btnVoid.TabIndex = 6
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'dgvPR
        '
        Me.dgvPR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.DateIssue, Me.PRNumber, Me.PONumber, Me.dr_no, Me.SupplierName, Me.TotalAmount, Me.ProcessedBy, Me.delivery_status})
        Me.dgvPR.Location = New System.Drawing.Point(12, 143)
        Me.dgvPR.Name = "dgvPR"
        Me.dgvPR.Size = New System.Drawing.Size(1121, 348)
        Me.dgvPR.TabIndex = 5
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'DateIssue
        '
        Me.DateIssue.HeaderText = "Date Issue"
        Me.DateIssue.Name = "DateIssue"
        Me.DateIssue.ReadOnly = True
        Me.DateIssue.Width = 200
        '
        'PRNumber
        '
        Me.PRNumber.HeaderText = "PR Number"
        Me.PRNumber.Name = "PRNumber"
        Me.PRNumber.ReadOnly = True
        Me.PRNumber.Width = 120
        '
        'PONumber
        '
        Me.PONumber.HeaderText = "PO Number"
        Me.PONumber.Name = "PONumber"
        Me.PONumber.ReadOnly = True
        '
        'dr_no
        '
        Me.dr_no.HeaderText = "DR Number"
        Me.dr_no.Name = "dr_no"
        Me.dr_no.ReadOnly = True
        '
        'SupplierName
        '
        Me.SupplierName.HeaderText = "Supplier Name"
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.ReadOnly = True
        Me.SupplierName.Width = 250
        '
        'TotalAmount
        '
        Me.TotalAmount.HeaderText = "Total Amount"
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = True
        '
        'ProcessedBy
        '
        Me.ProcessedBy.HeaderText = "Processed By"
        Me.ProcessedBy.Name = "ProcessedBy"
        Me.ProcessedBy.ReadOnly = True
        '
        'delivery_status
        '
        Me.delivery_status.HeaderText = "Delivery Status"
        Me.delivery_status.Name = "delivery_status"
        Me.delivery_status.ReadOnly = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(12, 26)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(83, 29)
        Me.btnAddNew.TabIndex = 4
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(221, 26)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 29)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'PurchaseReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 503)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.dgvPR)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "PurchaseReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Receive"
        CType(Me.dgvPR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnView As Button
    Friend WithEvents btnVoid As Button
    Friend WithEvents dgvPR As DataGridView
    Friend WithEvents btnAddNew As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As DataGridViewTextBoxColumn
    Friend WithEvents PRNumber As DataGridViewTextBoxColumn
    Friend WithEvents PONumber As DataGridViewTextBoxColumn
    Friend WithEvents dr_no As DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As DataGridViewTextBoxColumn
    Friend WithEvents ProcessedBy As DataGridViewTextBoxColumn
    Friend WithEvents delivery_status As DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As Button
End Class
