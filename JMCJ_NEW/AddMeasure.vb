Public Class AddMeasure
    Public selectedUnit As Integer = 0
    Private Sub AddMeasure_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadUnit()
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

    Private Sub btnAddUnit_Click(sender As Object, e As EventArgs) Handles btnAddUnit.Click
        UnitForm.txtUnit.Text = ""
        UnitForm.btnSave.Text = "Save"
        UnitForm.txtUnit.Focus()
        UnitForm.ShowDialog()
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'validation
        If selectedUnit = 0 Or cbUnit.SelectedIndex = 0 Then
            MsgBox("Please select unit!", MsgBoxStyle.Critical)
            cbUnit.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtPrice.Text.Replace(",", "")) Then
            MsgBox("Price field is required!", MsgBoxStyle.Critical)
            txtPrice.Focus()
            Exit Sub
        End If

        ' check if exist
        For Each item As DataGridViewRow In ProductMasterForm.dgvMeasure.Rows
            If item.Cells("measure_unit").Value <> "" Then

                Dim unit As String = item.Cells("measure_unit").Value.ToString.ToUpper
                Dim price As Double = CDbl(item.Cells("measure_price").Value)

                If unit = (cbUnit.Text.ToUpper) Then
                    MsgBox("The fields of measurement you input is already in list", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        Next
        Dim row As String() = New String() {cbUnit.Text, Val(txtPrice.Text).ToString("N2"), "Remove"}
        ProductMasterForm.dgvMeasure.Rows.Add(row)
        cbUnit.SelectedIndex = 0
        selectedUnit = 0
        txtPrice.Clear()
        Me.Close()

    End Sub
End Class