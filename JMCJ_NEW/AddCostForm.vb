Public Class AddCostForm
    Private Sub AddCostForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cbSupplier.SelectedIndex = cbSupplier.FindString("Select Supplier") Then
            MsgBox("Please select supplier!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Exit Sub
        End If

        If Trim(txtCost.Text) = "" Then
            MsgBox("Please input cost!", MsgBoxStyle.Critical)
            txtCost.Focus()
            Exit Sub
        End If

        Dim row As String() = New String() {cbSupplier.Text, txtCost.Text, "Remove"}
        ProductMasterForm.dgvCost.Rows.Add(row)

    End Sub
End Class