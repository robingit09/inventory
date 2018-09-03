<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomerReturn
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
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.dgvCReturn = New System.Windows.Forms.DataGridView()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pr_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cr_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IssuedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(217, 26)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 10
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Location = New System.Drawing.Point(314, 26)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(75, 23)
        Me.btnVoid.TabIndex = 9
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Location = New System.Drawing.Point(118, 26)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(75, 23)
        Me.btnView.TabIndex = 8
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'dgvCReturn
        '
        Me.dgvCReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCReturn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.pr_date, Me.cr_no, Me.SupplierName, Me.TotalAmount, Me.IssuedBy, Me.status})
        Me.dgvCReturn.Location = New System.Drawing.Point(21, 86)
        Me.dgvCReturn.Name = "dgvCReturn"
        Me.dgvCReturn.Size = New System.Drawing.Size(1004, 424)
        Me.dgvCReturn.TabIndex = 7
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(21, 26)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 6
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
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
        'cr_no
        '
        Me.cr_no.HeaderText = "CR NO"
        Me.cr_no.Name = "cr_no"
        Me.cr_no.ReadOnly = True
        '
        'SupplierName
        '
        Me.SupplierName.HeaderText = "Customer"
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
        Me.IssuedBy.Width = 200
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'CustomerReturn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1051, 535)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.dgvCReturn)
        Me.Controls.Add(Me.btnAddNew)
        Me.Name = "CustomerReturn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Return"
        CType(Me.dgvCReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents btnVoid As Button
    Friend WithEvents btnView As Button
    Friend WithEvents dgvCReturn As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents pr_date As DataGridViewTextBoxColumn
    Friend WithEvents cr_no As DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As DataGridViewTextBoxColumn
    Friend WithEvents IssuedBy As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents btnAddNew As Button
End Class
