Public Class UnitSelection
    Public selectedUnit As Integer = 0

    Private Sub UnitSelection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadUnit()
    End Sub

    Public Sub loadUnit()
        cbUnit.DataSource = Nothing
        cbUnit.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()

        Dim dbbrand As New DatabaseConnect
        With dbbrand
            .selectByQuery("Select id,name from unit where status = 1 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))

                End While
                cbUnit.DataSource = New BindingSource(comboSource, Nothing)
                cbUnit.DisplayMember = "Value"
                cbUnit.ValueMember = "Key"
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()

        End With
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.Text <> "" Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedUnit = CInt(key)
        Else
            selectedUnit = 0
        End If
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If Trim(cbUnit.Text) = "" Then
            Exit Sub
        End If

        ' check if exist
        For Each item As DataGridViewRow In ProductForm.dgvMeasure2.Rows
            If item.Cells("mUnit").Value <> "Select" Then

                Dim unit As String = item.Cells("mUnit").Value.ToString.ToUpper
                Dim price As Double = CDbl(item.Cells("mPrice").Value)

                If unit = (cbUnit.Text.ToUpper) Then
                    MsgBox("The fields of measurement you input is already in list", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        Next

        'MsgBox(ProductForm.dgvMeasure2.CurrentCell.RowIndex)
        Dim cur_index As Integer = ProductForm.dgvMeasure2.CurrentCell.RowIndex
        ProductForm.dgvMeasure2.Rows(cur_index).Cells("mUnit").Value = cbUnit.Text


        'cbUnit.SelectedIndex = 0
        'selectedUnit = 0

        'txtPrice.Clear()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        UnitForm.selectedUnit = 0
        UnitForm.ShowDialog()
    End Sub
End Class