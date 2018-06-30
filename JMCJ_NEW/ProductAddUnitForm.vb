Public Class ProductAddUnitForm
    Private selectedBrand As Integer
    Private selectedUnit As Integer
    Private Sub ProductAddUnitForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadBrand()
        loadUnit()
    End Sub

    Private Sub loadBrand()

        cbBrand.DataSource = Nothing
        cbBrand.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "No Brand")
        Dim dbbrand As New DatabaseConnect
        With dbbrand
            .selectByQuery("Select id,name from brand where status = 1 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))

                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
            cbBrand.DataSource = New BindingSource(comboSource, Nothing)
            cbBrand.DisplayMember = "Value"
            cbBrand.ValueMember = "Key"
        End With
    End Sub

    Private Sub loadUnit()

        cbUnit.DataSource = Nothing
        cbUnit.Items.Clear()
        Dim comboSourceUnit As New Dictionary(Of String, String)()
        comboSourceUnit.Add(0, "Select Unit")

        Dim dbUnit As New DatabaseConnect
        With dbUnit
            .selectByQuery("Select id,name from unit where status = 1 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    comboSourceUnit.Add(.dr.GetValue(0), .dr.GetValue(1))
                End While
            End If
            cbUnit.DataSource = New BindingSource(comboSourceUnit, Nothing)
            cbUnit.DisplayMember = "Value"
            cbUnit.ValueMember = "Key"
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'validation

        If Not selectedUnit > 0 Then
            MsgBox("Unit field required!", MsgBoxStyle.Critical)
            cbUnit.Focus()
            Exit Sub
        End If

        If Trim(txtPrice.Text).Length = 0 Then
            MsgBox("Price field required!", MsgBoxStyle.Critical)
            txtPrice.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtPrice.Text) Then
            MsgBox("Price field! Invalid number format.", MsgBoxStyle.Critical)
            txtPrice.Focus()
            Exit Sub
        End If

        If Val(txtPrice.Text) <= 0 Then
            MsgBox("Price must be greater than 0", MsgBoxStyle.Critical)
            txtPrice.Focus()
            Exit Sub
        End If

        ' check if exist
        For Each item As DataGridViewRow In ProductForm.dgvMeasure.Rows
            If item.Cells(1).Value <> "" Then
                Dim barcode As String = item.Cells(0).Value
                Dim brand As String = item.Cells(1).Value.ToString.ToUpper
                Dim unit As String = item.Cells(2).Value.ToString.ToUpper
                Dim price As Double = CDbl(item.Cells(3).Value)

                If barcode = Trim(txtBarcode.Text) And brand = (cbBrand.Text.ToUpper) And unit = (cbUnit.Text.ToUpper) Then
                    MsgBox("The fields of measurement you input is already in list", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        Next

        If btnAdd.Text = "Add(+)" Then
            Dim row As String() = New String() {txtBarcode.Text, cbBrand.Text, cbUnit.Text, Val(txtPrice.Text).ToString("N2"), "Remove"}
            ProductForm.dgvMeasure.Rows.Add(row)

        ElseIf btnAdd.Text = "Edit(->)" Then
            ProductForm.dgvMeasure.SelectedRows(0).Cells("barcode").Value = txtBarcode.Text
            ProductForm.dgvMeasure.SelectedRows(0).Cells("brand").Value = cbBrand.Text
            ProductForm.dgvMeasure.SelectedRows(0).Cells("unit").Value = cbUnit.Text
            ProductForm.dgvMeasure.SelectedRows(0).Cells("price").Value = txtPrice.Text
        End If

        txtBarcode.Clear()
        cbBrand.SelectedIndex = 0
        cbUnit.SelectedIndex = 0
        txtPrice.Clear()
        txtBarcode.Focus()
    End Sub

    Private Sub cbBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand.SelectedIndexChanged
        If cbBrand.SelectedIndex > -1 Then
            Dim key As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedBrand = key
        End If
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.SelectedIndex > -1 Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedUnit = key
        End If
    End Sub
End Class