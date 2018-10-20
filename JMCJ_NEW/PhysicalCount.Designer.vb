<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PhysicalCount
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
        Me.dgvPC = New System.Windows.Forms.DataGridView()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.recorded_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pc_number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.issued_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.processed_by = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvPC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPC
        '
        Me.dgvPC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.recorded_date, Me.pc_number, Me.issued_by, Me.processed_by, Me.status})
        Me.dgvPC.Location = New System.Drawing.Point(24, 93)
        Me.dgvPC.Name = "dgvPC"
        Me.dgvPC.Size = New System.Drawing.Size(820, 530)
        Me.dgvPC.TabIndex = 2
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Location = New System.Drawing.Point(131, 36)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(83, 29)
        Me.btnView.TabIndex = 6
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(233, 36)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(83, 29)
        Me.btnVoid.TabIndex = 5
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'btnAddNew
        '
        Me.btnAddNew.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.Location = New System.Drawing.Point(24, 36)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(83, 29)
        Me.btnAddNew.TabIndex = 4
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
        'recorded_date
        '
        Me.recorded_date.HeaderText = "Recorded Date"
        Me.recorded_date.Name = "recorded_date"
        Me.recorded_date.ReadOnly = True
        Me.recorded_date.Width = 200
        '
        'pc_number
        '
        Me.pc_number.HeaderText = "PC Number"
        Me.pc_number.Name = "pc_number"
        Me.pc_number.ReadOnly = True
        Me.pc_number.Width = 120
        '
        'issued_by
        '
        Me.issued_by.HeaderText = "Issued By"
        Me.issued_by.Name = "issued_by"
        Me.issued_by.ReadOnly = True
        Me.issued_by.Width = 250
        '
        'processed_by
        '
        Me.processed_by.HeaderText = "Processed By"
        Me.processed_by.Name = "processed_by"
        Me.processed_by.ReadOnly = True
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'PhysicalCount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 649)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnVoid)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.dgvPC)
        Me.Name = "PhysicalCount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Physical Count"
        CType(Me.dgvPC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvPC As DataGridView
    Friend WithEvents btnView As Button
    Friend WithEvents btnVoid As Button
    Friend WithEvents btnAddNew As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents recorded_date As DataGridViewTextBoxColumn
    Friend WithEvents pc_number As DataGridViewTextBoxColumn
    Friend WithEvents issued_by As DataGridViewTextBoxColumn
    Friend WithEvents processed_by As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
End Class
