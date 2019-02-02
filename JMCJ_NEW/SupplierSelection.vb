Public Class SupplierSelection
    Private Sub SupplierSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadSupplier()
    End Sub

    Public Sub loadSupplier()
        cbSupplier.DataSource = Nothing
        cbSupplier.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,supplier_name from suppliers where status <> 0 order by supplier_name")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Supplier")

            While .dr.Read
                Dim id As Integer = CInt(.dr.GetValue(0))
                Dim sup As String = .dr.GetValue(1)
                comboSource.Add(id, sup)
            End While

            cbSupplier.DataSource = New BindingSource(comboSource, Nothing)
            cbSupplier.DisplayMember = "Value"
            cbSupplier.ValueMember = "Key"

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        If Trim(cbSupplier.Text) = "" Or Trim(cbSupplier.Text) = "Select Supplier" Or cbSupplier.SelectedIndex = 0 Then
            MsgBox("Please select supplier!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Exit Sub
        End If

        ' check if exist
        'For Each item As DataGridViewRow In ProductForm.dgvCost.Rows
        '    If item.Cells("Supplier").Value <> "Select Supplier" Then
        '        Dim supplier As String = item.Cells("Supplier").Value.ToString.ToUpper

        '        If supplier = (cbSupplier.Text.ToUpper) Then
        '            MsgBox("The supplier you input is already in list", MsgBoxStyle.Critical)
        '            Exit Sub
        '        End If
        '    End If
        'Next


        Dim cur_index As Integer = ProductForm.dgvCost.CurrentCell.RowIndex
        ProductForm.dgvCost.Rows(cur_index).Cells("Supplier").Value = cbSupplier.Text
        Me.Close()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        SupplierForm.loadstatus()
        SupplierForm.SelectedSupplier = 0
        SupplierForm.clearFields()
        SupplierForm.btnSave.Text = "Save"
        SupplierForm.from_module = 6
        SupplierForm.ShowDialog()
    End Sub


End Class