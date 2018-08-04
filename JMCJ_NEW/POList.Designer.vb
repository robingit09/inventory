<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POList
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
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.dgvPO = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateIssue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PONumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivery_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(26, 29)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(83, 29)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'dgvPO
        '
        Me.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.DateIssue, Me.PONumber, Me.SupplierName, Me.TotalAmount, Me.ProcessedBy, Me.delivery_status})
        Me.dgvPO.Location = New System.Drawing.Point(26, 108)
        Me.dgvPO.Name = "dgvPO"
        Me.dgvPO.Size = New System.Drawing.Size(921, 424)
        Me.dgvPO.TabIndex = 1
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
        'PONumber
        '
        Me.PONumber.HeaderText = "PO Number"
        Me.PONumber.Name = "PONumber"
        Me.PONumber.ReadOnly = True
        Me.PONumber.Width = 120
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
        'btnVoid
        '
        Me.btnVoid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(341, 29)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(83, 29)
        Me.btnVoid.TabIndex = 2
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(133, 29)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 29)
        Me.btnView.TabIndex = 3
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(235, 29)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 29)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'POList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 557)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.dgvPO)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "POList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order"
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents dgvPO As System.Windows.Forms.DataGridView
    Friend WithEvents btnVoid As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents DateIssue As DataGridViewTextBoxColumn
    Friend WithEvents PONumber As DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As DataGridViewTextBoxColumn
    Friend WithEvents ProcessedBy As DataGridViewTextBoxColumn
    Friend WithEvents delivery_status As DataGridViewTextBoxColumn
    Friend WithEvents btnView As Button
    Friend WithEvents btnPrint As Button
End Class
