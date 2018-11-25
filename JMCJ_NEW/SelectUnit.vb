Public Class SelectUnit
    Public selected_prod_unit As Integer = 0
    Private Sub SelectUnit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loadUnit(ByVal product_unit_id As Integer)
        selected_prod_unit = product_unit_id
        dgvUnit.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("select u.name,pm.price from product_measure as pm
            inner join unit as u on u.id = pm.unit_id where pm.product_unit_id = " & product_unit_id & " order by pm.price desc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim unit_name As String = .dr("name")
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim row As String() = New String() {unit_name, price}
                    dgvUnit.Rows.Add(row)
                End While
            End If
        End With
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If dgvUnit.SelectedRows.Count = 1 Then
            Dim unit As String = dgvUnit.SelectedRows(0).Cells("unit").Value
            Dim price As String = dgvUnit.SelectedRows(0).Cells("price").Value

            'MsgBox(unit & " " & price)
            For Each item As DataGridViewRow In CustomerOrderForm.dgvProd.Rows
                If item.Cells("unit").Value <> "" Then
                    If item.Cells("id").Value = selected_prod_unit Then
                        item.Cells("unit").Value = unit
                        item.Cells("price").Value = price
                        item.Cells("sell_price").Value = price
                        item.Cells("less").Value = ""
                        Me.Close()
                    End If
                End If

            Next
        Else

        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class