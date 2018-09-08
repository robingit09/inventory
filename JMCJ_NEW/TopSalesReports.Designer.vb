<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopSalesReports
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
        Me.gpFilter = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCustomer = New System.Windows.Forms.ComboBox()
        Me.gpFilter.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(612, 257)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'gpFilter
        '
        Me.gpFilter.Controls.Add(Me.Label1)
        Me.gpFilter.Controls.Add(Me.cbCustomer)
        Me.gpFilter.Location = New System.Drawing.Point(12, 23)
        Me.gpFilter.Name = "gpFilter"
        Me.gpFilter.Size = New System.Drawing.Size(675, 208)
        Me.gpFilter.TabIndex = 2
        Me.gpFilter.TabStop = False
        Me.gpFilter.Text = "Filter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer"
        '
        'cbCustomer
        '
        Me.cbCustomer.FormattingEnabled = True
        Me.cbCustomer.Location = New System.Drawing.Point(73, 25)
        Me.cbCustomer.Name = "cbCustomer"
        Me.cbCustomer.Size = New System.Drawing.Size(176, 21)
        Me.cbCustomer.TabIndex = 0
        '
        'TopSalesReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 292)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.gpFilter)
        Me.Name = "TopSalesReports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Top Sales Reports"
        Me.gpFilter.ResumeLayout(False)
        Me.gpFilter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPrint As Button
    Friend WithEvents gpFilter As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCustomer As ComboBox
End Class
