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
                .selectByQuery("Select distinct p.id,pu.barcode, p.description,b.name as brand, u.name as unit,pu.price,c.name,sub.name FROM (((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where p.status = 1 order by p.description")
            Else

            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim barcode As String = .dr.GetValue(1)
                    Dim desc As String = .dr.GetValue(2)
                    Dim brand As String = .dr.GetValue(3)
                    Dim unit As String = .dr.GetValue(4)
                    Dim price As String = .dr.GetValue(5)
                    Dim cat As String = .dr.GetValue(6)
                    Dim subcat As String = If(IsDBNull(.dr.GetValue(7)), "", .dr.GetValue(7))
                    Dim row As String() = New String() {id, True, barcode, desc, brand, unit, price, "0.00", cat, subcat}
                    dgvProducts.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub ckSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ckSelectAll.CheckedChanged
        If ckSelectAll.Checked Then
            For Each item As DataGridViewRow In Me.dgvProducts.Rows
                dgvProducts.Rows(item.Index).Cells(1).Value = True
            Next
        Else
            For Each item As DataGridViewRow In Me.dgvProducts.Rows
                dgvProducts.Rows(item.Index).Cells(1).Value = False
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

                        Dim product_id As String = dgvProducts.Rows(item.Index).Cells(0).Value
                        Dim brand As Integer = New DatabaseConnect().get_id("brand", "name", dgvProducts.Rows(item.Index).Cells(4).Value)
                        Dim unit As Integer = New DatabaseConnect().get_id("unit", "name", dgvProducts.Rows(item.Index).Cells(5).Value)
                        Dim sell_price As String = dgvProducts.Rows(item.Index).Cells(7).Value
                        .cmd.CommandText = "INSERT INTO customer_product_prices (customer_id,product_id,brand,unit,sell_price,created_at,updated_at)
                VALUES(?,?,?,?,?,?,?)"
                        .cmd.Parameters.AddWithValue("@customer_id", selectedCustomer)
                        .cmd.Parameters.AddWithValue("@product_id", product_id)
                        .cmd.Parameters.AddWithValue("@brand", brand.ToString)
                        .cmd.Parameters.AddWithValue("@unit", unit.ToString)
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