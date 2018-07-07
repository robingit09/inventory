Public Class AddProductForm

    Public selectedCustomer As Integer = 0
    Private Sub AddProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getProduct("")

    End Sub

    Private Sub getProduct(ByVal q As String)
        Dim db As New DatabaseConnect
        With db
            dgvProducts.Rows.Clear()
            If q = "" Then
                .selectByQuery("Select distinct p.id,pu.barcode, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                INNER JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where p.status = 1 order by p.description")
            Else

            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = .dr("brand")
                    Dim unit As String = .dr("unit")
                    Dim color As String = .dr("color")
                    Dim price As String = .dr("price")
                    Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat"))

                    Dim b_id As Integer = New DatabaseConnect().get_id("brand", "name", brand)
                    Dim u_id As Integer = New DatabaseConnect().get_id("unit", "name", unit)
                    Dim c_id As Integer = New DatabaseConnect().get_id("color", "name", color)

                    Dim cmd2 As New System.Data.OleDb.OleDbCommand
                    Dim dr2 As System.Data.OleDb.OleDbDataReader
                    cmd2.Connection = .con
                    cmd2.CommandType = CommandType.Text
                    cmd2.CommandText = "Select * from customer_product_prices where product_id = " & id & " 
                    and brand = " & b_id & " and unit = " & u_id & " and color = " & c_id & " and customer_id = " & selectedCustomer
                    dr2 = cmd2.ExecuteReader

                    If dr2.Read Then

                    Else
                        Dim row As String() = New String() {id, True, barcode, desc, brand, unit, color, price, "0.00", cat, subcat}
                        dgvProducts.Rows.Add(row)
                    End If
                    dr2.Close()
                    cmd2.Dispose()
                End While
            Else
                MsgBox("No product found")
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub ckSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ckSelectAll.CheckedChanged
        If ckSelectAll.Checked Then
            For Each item As DataGridViewRow In Me.dgvProducts.Rows
                If dgvProducts.Rows(item.Index).Cells(3).Value <> "" Then
                    dgvProducts.Rows(item.Index).Cells(1).Value = True
                End If
            Next
        Else
            For Each item As DataGridViewRow In Me.dgvProducts.Rows
                If dgvProducts.Rows(item.Index).Cells(3).Value <> "" Then
                    dgvProducts.Rows(item.Index).Cells(1).Value = False
                End If
            Next
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        saveData()
    End Sub

    Private Sub saveData()

        If dgvProducts.Rows.Count > 0 Then
            For Each item As DataGridViewRow In Me.dgvProducts.Rows

                Dim dbinsert As New DatabaseConnect
                With dbinsert
                    If dgvProducts.Rows(item.Index).Cells(1).Value = True Then
                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text

                        Dim product_id As String = dgvProducts.Rows(item.Index).Cells("column_id").Value
                        Dim brand As Integer = New DatabaseConnect().get_id("brand", "name", dgvProducts.Rows(item.Index).Cells("column_brand").Value)
                        Dim unit As Integer = New DatabaseConnect().get_id("unit", "name", dgvProducts.Rows(item.Index).Cells("column_unit").Value)
                        Dim color As Integer = New DatabaseConnect().get_id("color", "name", dgvProducts.Rows(item.Index).Cells("column_color").Value)
                        Dim sell_price As String = dgvProducts.Rows(item.Index).Cells("column_sell_price").Value
                        .cmd.CommandText = "INSERT INTO customer_product_prices (customer_id,product_id,brand,unit,color,sell_price,created_at,updated_at)
                VALUES(?,?,?,?,?,?,?,?)"
                        .cmd.Parameters.AddWithValue("@customer_id", selectedCustomer)
                        .cmd.Parameters.AddWithValue("@product_id", product_id)
                        .cmd.Parameters.AddWithValue("@brand", brand.ToString)
                        .cmd.Parameters.AddWithValue("@unit", unit.ToString)
                        .cmd.Parameters.AddWithValue("@color", color.ToString)
                        .cmd.Parameters.AddWithValue("@sell_price", sell_price)
                        .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                        .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                        .cmd.ExecuteNonQuery()
                        .cmd.Dispose()
                        .con.Close()
                    End If
                End With
            Next
        End If

        MsgBox("Successfully saved", MsgBoxStyle.Information)
        Me.Close()
        CustomerPriceList.getList("", selectedCustomer)

    End Sub
End Class