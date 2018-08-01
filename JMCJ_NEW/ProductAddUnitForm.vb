Public Class ProductAddUnitForm
    Private selectedBrand As Integer = 0
    Private selectedUnit As Integer = 0
    Private selectedColor As Integer = 0
    Private Sub ProductAddUnitForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub resetFields()
        txtBarcode.Clear()
        cbBrand.SelectedIndex = 0
        cbUnit.SelectedIndex = 0
        txtPrice.Clear()
        selectedBrand = 0
        selectedUnit = 0
    End Sub

    Public Sub loadBrand()
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

    Public Sub loadUnit()

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


    Public Sub loadColor()

        cbColor.DataSource = Nothing
        cbColor.Items.Clear()
        Dim comboSourceUnit As New Dictionary(Of String, String)()
        comboSourceUnit.Add(0, "No Color")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name from color where status = 1 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    comboSourceUnit.Add(.dr.GetValue(0), .dr.GetValue(1))
                End While
            End If
            cbColor.DataSource = New BindingSource(comboSourceUnit, Nothing)
            cbColor.DisplayMember = "Value"
            cbColor.ValueMember = "Key"
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



        If btnAdd.Text = "Add(+)" Then
            ' check if exist
            For Each item As DataGridViewRow In ProductForm.dgvMeasure.Rows
                If item.Cells("brand").Value <> "" Then
                    Dim barcode As String = item.Cells("barcode").Value
                    Dim brand As String = item.Cells("brand").Value.ToString.ToUpper
                    Dim unit As String = item.Cells("unit").Value.ToString.ToUpper
                    Dim color As String = item.Cells("Color").Value.ToString.ToUpper
                    Dim price As Double = CDbl(item.Cells("Price").Value)

                    If brand = (cbBrand.Text.ToUpper) And unit = (cbUnit.Text.ToUpper) And color = (cbColor.Text.ToUpper) Then
                        MsgBox("The fields of measurement you input is already in list", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            Next
            Dim row As String() = New String() {"", txtBarcode.Text, cbBrand.Text, cbUnit.Text, cbColor.Text, Val(txtPrice.Text).ToString("N2"), "Remove"}
            ProductForm.dgvMeasure.Rows.Add(row)

        ElseIf btnAdd.Text = "Edit(->)" Then
            ProductForm.dgvMeasure.SelectedRows(0).Cells("barcode").Value = txtBarcode.Text
            ProductForm.dgvMeasure.SelectedRows(0).Cells("brand").Value = cbBrand.Text
            ProductForm.dgvMeasure.SelectedRows(0).Cells("unit").Value = cbUnit.Text
            ProductForm.dgvMeasure.SelectedRows(0).Cells("color").Value = cbColor.Text
            ProductForm.dgvMeasure.SelectedRows(0).Cells("price").Value = txtPrice.Text
            Me.Close()
        End If

        txtBarcode.Clear()
        cbBrand.SelectedIndex = 0
        cbUnit.SelectedIndex = 0
        cbColor.SelectedIndex = 0
        txtPrice.Clear()
        txtBarcode.Focus()
    End Sub

    Private Sub cbBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand.SelectedIndexChanged
        If cbBrand.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedBrand = key
        Else
            selectedBrand = 0
        End If
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedUnit = key
        Else
            selectedUnit = 0
        End If
    End Sub

    Private Sub cbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbColor.SelectedIndexChanged
        If cbColor.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedColor = key
        Else
            selectedColor = 0
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        If Not IsNumeric(txtPrice.Text) Then
            txtPrice.Focus()
            txtPrice.SelectAll()
        End If
    End Sub

    Private Sub btnAddBrand_Click(sender As Object, e As EventArgs) Handles btnAddBrand.Click
        BrandForm.btnSave.Text = "Save"
        BrandForm.txtBrand.Text = ""
        BrandForm.ShowDialog()
    End Sub

    Private Sub btnAddUnit_Click(sender As Object, e As EventArgs) Handles btnAddUnit.Click
        UnitForm.txtUnit.Text = ""
        UnitForm.btnSave.Text = "Save"
        UnitForm.txtUnit.Focus()
        UnitForm.ShowDialog()
    End Sub

    Private Sub btnAddColor_Click(sender As Object, e As EventArgs) Handles btnAddColor.Click
        ColorForm.btnSave.Text = "Save"
        ColorForm.txtColor.Clear()
        ColorForm.txtColor.Focus()
        ColorForm.ShowDialog()
    End Sub
End Class