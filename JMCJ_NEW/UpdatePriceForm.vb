Public Class UpdatePriceForm

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If Not IsNumeric(txtSellPrice.Text) Then
            MsgBox("Input number only!", MsgBoxStyle.Critical)
            txtSellPrice.Focus()
            Exit Sub
        End If

        Dim customer As String = New DatabaseConnect().get_id("company", "company", txtCustomer.Text)
        Dim product As String = New DatabaseConnect().get_id("products", "description", txtProductDesc.Text)
        Dim brand As String = New DatabaseConnect().get_id("brand", "name", txtBrand.Text)
        Dim unit As String = New DatabaseConnect().get_id("unit", "name", txtUnit.Text)

        Dim dbupdateprice As New DatabaseConnect
        With dbupdateprice
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "Update customer_product_prices set sell_price=? where customer_id = ? and product_id = ?
            and brand = ? and unit=?"
            .cmd.Parameters.AddWithValue("@sell_price", Val(txtSellPrice.Text))
            .cmd.Parameters.AddWithValue("@customer_id", customer)
            .cmd.Parameters.AddWithValue("@product_id", product)
            .cmd.Parameters.AddWithValue("@brand", brand)
            .cmd.Parameters.AddWithValue("@unit", unit)

            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Price Successfully Update", MsgBoxStyle.Information)
            Me.Close()
            CustomerPriceList.getList("", CustomerPriceList.selectedCustomer)
        End With
    End Sub
End Class