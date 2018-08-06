Public Class UpdatePriceForm

    Public selected_product_unit As Integer = 0
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not IsNumeric(txtSellPrice.Text) Then
            MsgBox("Input number only!", MsgBoxStyle.Critical)
            txtSellPrice.Focus()
            Exit Sub
        End If

        Dim customer As String = New DatabaseConnect().get_id("company", "company", txtCustomer.Text)
        Dim dbupdateprice As New DatabaseConnect
        With dbupdateprice
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "Update customer_product_prices set sell_price=? where customer_id = ? and product_unit_id = ?"
            .cmd.Parameters.AddWithValue("@sell_price", Val(txtSellPrice.Text))
            .cmd.Parameters.AddWithValue("@customer_id", customer)
            .cmd.Parameters.AddWithValue("@product_unit_id", selected_product_unit)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Price Successfully Update.", MsgBoxStyle.Information)
            Me.Close()
            CustomerPriceList.getList("", CustomerPriceList.selectedCustomer)
        End With
    End Sub

    Private Sub txtSellPrice_Click(sender As Object, e As EventArgs) Handles txtSellPrice.Click
        txtSellPrice.Focus()
        txtSellPrice.SelectAll()
    End Sub

End Class