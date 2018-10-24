<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserGroups
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
        Me.dgvUserGroup = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_created = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        CType(Me.dgvUserGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvUserGroup
        '
        Me.dgvUserGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUserGroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.position, Me.date_created, Me.status})
        Me.dgvUserGroup.Location = New System.Drawing.Point(24, 101)
        Me.dgvUserGroup.Name = "dgvUserGroup"
        Me.dgvUserGroup.Size = New System.Drawing.Size(498, 237)
        Me.dgvUserGroup.TabIndex = 0
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 5
        '
        'position
        '
        Me.position.HeaderText = "Position"
        Me.position.Name = "position"
        Me.position.ReadOnly = True
        Me.position.Width = 150
        '
        'date_created
        '
        Me.date_created.HeaderText = "Date Created"
        Me.date_created.Name = "date_created"
        Me.date_created.ReadOnly = True
        Me.date_created.Width = 150
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Width = 150
        '
        'btnAddNew
        '
        Me.btnAddNew.Location = New System.Drawing.Point(24, 57)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(75, 23)
        Me.btnAddNew.TabIndex = 1
        Me.btnAddNew.Text = "Add New"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(123, 57)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(220, 57)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'UserGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(541, 397)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAddNew)
        Me.Controls.Add(Me.dgvUserGroup)
        Me.Name = "UserGroups"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Groups"
        CType(Me.dgvUserGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvUserGroup As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents position As DataGridViewTextBoxColumn
    Friend WithEvents date_created As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewTextBoxColumn
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
End Class
