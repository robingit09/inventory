Public Class ProductMasterForm
    Public selected_prod_unit As Integer = 0


    Public Sub toLoadInfo(ByVal p_unit_id As Integer)
        Me.selected_prod_unit = p_unit_id
        Dim db As New DatabaseConnect
        With db

            .selectByQuery("Select distinct pu.id,pu.barcode, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 and pu.id = " & p_unit_id)

            If .dr.Read Then
                txtBarcode.Text = .dr("barcode")
                txtDescription.Text = .dr("description")
                txtBrand.Text = .dr("brand")
                txtUnit.Text = .dr("unit")
                txtColor.Text = If(IsDBNull(.dr("color")), "", .dr("color"))
                txtPrice.Text = Val(.dr("price")).ToString("N2")
                'Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                'Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat")

            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With

        Dim dbcost As New DatabaseConnect
        With dbcost
            dgvCost.Rows.Clear()
            .selectByQuery("Select s.supplier_name,ps.unit_cost from product_suppliers as ps
            left join suppliers as s ON s.id = ps.supplier where ps.product_unit_id = " & selected_prod_unit)
            If .dr.HasRows Then
                While .dr.Read
                    Dim s_name As String = .dr("supplier_name")
                    Dim cost As String = Val(.dr("unit_cost")).ToString("N2")

                    Dim row As String() = New String() {s_name, cost, "Remove"}
                    dgvCost.Rows.Add(row)
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim dbprice As New DatabaseConnect
        With dbprice
            dgvCPrices.Rows.Clear()
            .selectByQuery("Select c.company,cop.sell_price from customer_product_prices as cop
            left join company as c ON c.id = cop.customer_id where cop.product_unit_id = " & selected_prod_unit)
            If .dr.HasRows Then
                While .dr.Read
                    Dim c_name As String = .dr("company")
                    Dim price As String = Val(.dr("sell_price")).ToString("N2")

                    Dim row As String() = New String() {c_name, price, "Remove"}
                    dgvCPrices.Rows.Add(row)
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Sub btnAddCost_Click(sender As Object, e As EventArgs) Handles btnAddCost.Click
        AddCostForm.ShowDialog()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'validation
        If dgvCost.Rows.Count = 1 Then
            MsgBox("Costing table field is required!", MsgBoxStyle.Critical)
            dgvCost.Focus()
            Exit Sub
        End If

        'insert supplier and their cost
        Dim dbdelete As New DatabaseConnect
        dbdelete.delete_permanent("product_suppliers", "product_unit_id", Me.selected_prod_unit)
        dbdelete.cmd.Dispose()
        dbdelete.con.Close()
        Dim saveCost As New DatabaseConnect
        With saveCost
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text

            For Each item As DataGridViewRow In dgvCost.Rows
                If item.Cells("Supplier").Value <> "" Then
                    Dim supplier As String = item.Cells("Supplier").Value
                    Dim cost As Double = Val(item.Cells("Cost").Value)

                    .cmd.CommandText = "INSERT INTO product_suppliers (product_unit_id,supplier,unit_cost,created_at,updated_at)
            VALUES(?,?,?,?,?)"
                    .cmd.Parameters.AddWithValue("@product_unit_id", selected_prod_unit)
                    .cmd.Parameters.AddWithValue("@supplier", New DatabaseConnect().get_id("suppliers", "supplier_name", supplier))
                    .cmd.Parameters.AddWithValue("@unit_cost", cost)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()
                End If
            Next
            .cmd.Dispose()
            .con.Close()
        End With

        'insert customer and their price
        Dim dbdelete2 As New DatabaseConnect
        dbdelete2.delete_permanent("customer_product_prices", "product_unit_id", Me.selected_prod_unit)
        dbdelete2.cmd.Dispose()
        dbdelete2.con.Close()
        Dim savePrice As New DatabaseConnect
        With savePrice
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text

            For Each item As DataGridViewRow In dgvCPrices.Rows
                If item.Cells("customer").Value <> "" Then
                    Dim customer As String = item.Cells("customer").Value
                    Dim price As Double = Val(item.Cells("price").Value)

                    .cmd.CommandText = "INSERT INTO customer_product_prices (product_unit_id,customer_id,sell_price,created_at,updated_at)
            VALUES(?,?,?,?,?)"
                    .cmd.Parameters.AddWithValue("@product_unit_id", selected_prod_unit)
                    .cmd.Parameters.AddWithValue("@customer_id", New DatabaseConnect().get_id("company", "company", customer))
                    .cmd.Parameters.AddWithValue("@sell_price", price)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()
                End If
            Next
            .cmd.Dispose()
            .con.Close()
        End With

        MsgBox("Product Information Successfully Save", MsgBoxStyle.Information)
    End Sub

    Private Sub dgvCost_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCost.CellContentClick
        'remove product
        If e.ColumnIndex = 2 And dgvCost.Rows.Count > 1 Then
            dgvCost.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub btnAddCPrice_Click(sender As Object, e As EventArgs) Handles btnAddCPrice.Click
        AddCustomerPrices.ShowDialog()
    End Sub

    Private Sub ProductMasterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadCostHistory()
        loadPriceHistory()
    End Sub

    Private Sub loadPriceHistory()
        dgvPriceHistory.Rows.Clear()
        Dim dbpricehis As New DatabaseConnect
        With dbpricehis
            .selectByQuery("select unit_price,created_at from price_history where product_unit_id = " & selected_prod_unit & " order by created_at DESC")
            If .dr.HasRows Then
                While .dr.Read
                    Dim price As String = Val(.dr("unit_price")).ToString("N2")
                    Dim date_added As String = .dr("created_at")
                    Dim row As String() = New String() {price, date_added}
                    dgvPriceHistory.Rows.Add(row)
                End While
            End If
        End With
    End Sub

    Private Sub loadCostHistory()
        dgvcosthistory.Rows.Clear()
        Dim dgvhis As New DatabaseConnect
        With dgvhis
            .selectByQuery("select unit_cost,created_at from cost_history where product_unit_id = " & selected_prod_unit & " order by created_at DESC")
            If .dr.HasRows Then
                While .dr.Read
                    Dim cost As String = Val(.dr("unit_cost")).ToString("N2")
                    Dim date_added As String = .dr("created_at")
                    Dim row As String() = New String() {cost, date_added}
                    dgvcosthistory.Rows.Add(row)
                End While
            End If
        End With
    End Sub
End Class