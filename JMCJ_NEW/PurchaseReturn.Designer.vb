<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PurchaseReturn
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
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.dgvPO = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IssuedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(29, 33)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 0
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'dgvPO
        '
        Me.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.pr_date, Me.SupplierName, Me.TotalAmount, Me.IssuedBy, Me.status})
        Me.dgvPO.Location = New System.Drawing.Point(29, 74)
        Me.dgvPO.Name = "dgvPO"
        Me.dgvPO.Size = New System.Drawing.Size(803, 424)
        Me.dgvPO.TabIndex = 2
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'pr_date
        '
        Me.pr_date.HeaderText = "Date"
        Me.pr_date.Name = "pr_date"
        Me.pr_date.ReadOnly = True
        Me.pr_date.Width = 200
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
        'IssuedBy
        '
        Me.IssuedBy.HeaderText = "Issued By"
        Me.IssuedBy.Name = "IssuedBy"
        Me.IssuedBy.ReadOnly = True
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'PurchaseReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 531)
        Me.Controls.Add(Me.dgvPO)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "PurchaseReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Return"
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddNew As Button
    Friend WithEvents dgvPO As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents pr_date As DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As DataGridViewTextBoxColumn
    Friend WithEvents IssuedBy As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
