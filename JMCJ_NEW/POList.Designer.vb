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
        Me.btnAddNew = New System.Windows.Forms.Button
        Me.dgvPO = New System.Windows.Forms.DataGridView
        Me.DateCreated = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PONumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcessedBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.dgvPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateCreated, Me.PONumber, Me.SupplierName, Me.TotalAmount, Me.ProcessedBy, Me.Status})
        Me.dgvPO.Location = New System.Drawing.Point(26, 108)
        Me.dgvPO.Name = "dgvPO"
        Me.dgvPO.Size = New System.Drawing.Size(643, 335)
        Me.dgvPO.TabIndex = 1
        '
        'DateCreated
        '
        Me.DateCreated.HeaderText = "Date Created"
        Me.DateCreated.Name = "DateCreated"
        Me.DateCreated.ReadOnly = True
        '
        'PONumber
        '
        Me.PONumber.HeaderText = "PO Number"
        Me.PONumber.Name = "PONumber"
        Me.PONumber.ReadOnly = True
        '
        'SupplierName
        '
        Me.SupplierName.HeaderText = "Supplier Name"
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.ReadOnly = True
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
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'POList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 485)
        Me.Controls.Add(Me.dgvPO)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "POList"
        Me.Text = "Purchase Order"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents dgvPO As System.Windows.Forms.DataGridView
    Friend WithEvents DateCreated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PONumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
