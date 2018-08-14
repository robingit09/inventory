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
        'validation
        If cbSupplier.SelectedIndex = 0 Then
            MsgBox("Please select supplier!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Exit Sub
        End If

        If btnAdd.Text = "Add(+)" Then
            ' check if exist
            For Each item As DataGridViewRow In ProductMasterForm.dgvCost.Rows
                If item.Cells("Supplier").Value <> "" Then
                    Dim supplier As String = item.Cells("Supplier").Value.ToString.ToUpper
                    If supplier = cbSupplier.Text.ToUpper Then
                        MsgBox("Supplier is already added!", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            Next
        End If

        If Trim(txtCost.Text) = "" Then
            MsgBox("Please input unit cost!", MsgBoxStyle.Critical)
            txtCost.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtCost.Text) Then
            MsgBox("Invalid number format for unit cost!", MsgBoxStyle.Critical)
            txtCost.Focus()
            txtCost.SelectAll()
            Exit Sub
        End If


        Dim row As String() = New String() {cbSupplier.Text, Val(txtCost.Text).ToString("N2"), "Remove"}
        ProductMasterForm.dgvCost.Rows.Add(row)
        cbSupplier.SelectedIndex = 0
        txtCost.Text = ""
        cbSupplier.Focus()
        Me.Close()
    End Sub
End Class