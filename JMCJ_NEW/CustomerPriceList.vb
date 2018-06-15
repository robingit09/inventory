Public Class CustomerPriceList

    Public selectedCustomer As Integer = 0

    Private Sub getCustomer()
        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Customer")
        Dim dbcustomer As New DatabaseConnect
        With dbcustomer
            .selectByQuery("Select id,company from company where status = 1 order by company")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim customer As String = .dr.GetValue(1)
                    comboSource.Add(id, customer)
                End While

                cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
                cbCustomer.DisplayMember = "Value"
                cbCustomer.ValueMember = "Key"
            End If

            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Sub loadproduct(ByVal category As String)
        'cbProduct.DataSource = Nothing
        'cbProduct.Items.Clear()

        'Dim db As New DatabaseConnect
        'With db
        '    .dbConnect()
        '    .cmd.Connection = .con
        '    .cmd.CommandType = CommandType.Text
        '    .cmd.CommandText = "SELECT distinct id,name from products where status <> 0 and category like '%" & category & "%'"
        '    .dr = .cmd.ExecuteReader

        '    Dim comboSource As New Dictionary(Of String, String)()
        '    comboSource.Add(0, "Select Product")
        '    While .dr.Read
        '        Dim id As Integer = CInt(.dr.GetValue(0))
        '        Dim prod As String = .dr.GetValue(1)
        '        comboSource.Add(id, prod)
        '    End While
        '    cbProduct.DataSource = New BindingSource(comboSource, Nothing)
        '    cbProduct.DisplayMember = "Value"
        '    cbProduct.ValueMember = "Key"

        '    .dr.Close()
        '    .cmd.Dispose()
        '    .con.Close()

        'End With
    End Sub

    Private Sub Pricing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCustomer()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cbCustomer.SelectedIndex > 0 Then
            AddProductForm.selectedCustomer = Me.selectedCustomer
            AddProductForm.ShowDialog()
        Else
            selectedCustomer = 0
            AddProductForm.selectedCustomer = 0
            MsgBox("Please select customer", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key
            getList("", selectedCustomer)
        End If
    End Sub

    Public Sub getList(ByVal query As String, ByVal customer_id As Integer)
        dgvPriceList.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                .selectByQuery("Select distinct pu.product_id,pu.barcode,p.description,b.name as brand, u.name as unit,pu.price as price,cpp.sell_price, c.name, sub.name
                from ((((((((product_unit as pu
                INNER JOIN products as p on p.id = pu.product_id)
                INNER JOIN customer_product_prices as cpp on cpp.product_id = p.id)
                LEFT JOIN brand as b on b.id = cpp.brand)
                INNER JOIN unit as u on u.id = cpp.unit)
                LEFT JOIN product_categories as pc ON pc.product_id = cpp.product_id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = cpp.product_id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id) 
                where cpp.customer_id = " & customer_id)
            End If

            Dim recordfound As Boolean = False
            If .dr.HasRows Then
                recordfound = True
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim barcode As String = .dr.GetValue(1)
                    Dim desc As String = .dr.GetValue(2)
                    Dim brand As String = If(IsDBNull(.dr.GetValue(3)), "", .dr.GetValue(3))
                    Dim unit As String = .dr.GetValue(4)
                    Dim price As String = Val(.dr.GetValue(5)).ToString("N2")
                    Dim sell_price As String = Val(.dr.GetValue(6)).ToString("N2")
                    Dim cat As String = .dr.GetValue(7)
                    Dim subcat As String = If(IsDBNull(.dr.GetValue(8)), "", .dr.GetValue(8))
                    Dim row As String() = New String() {id, True, barcode, desc, brand, unit, price, sell_price, cat, subcat}
                    dgvPriceList.Rows.Add(row)
                End While
            Else
                recordfound = False
                MsgBox("No record products found!", MsgBoxStyle.Critical)
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()

            If recordfound = False Then
                Dim d As Integer = MsgBox("Do you want to add product for " & cbCustomer.Text & "?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
                If d = MsgBoxResult.Yes Then
                    btnAdd.PerformClick()
                End If
            End If
        End With
    End Sub

    Private Sub btnCreateOrder_Click(sender As Object, e As EventArgs) Handles btnCreateOrder.Click
        If selectedCustomer > 0 Then
            CustomerOrderForm.populateCustomer()
            CustomerOrderForm.SelectedCustomer = Me.selectedCustomer
            CustomerOrderForm.cbCustomer.Text = Me.cbCustomer.Text
            CustomerOrderForm.dgvProd.Rows.Clear()
            For Each item As DataGridViewRow In Me.dgvPriceList.Rows
                Dim selectedproduct As Boolean = dgvPriceList.Rows(item.Index).Cells("selectproduct").Value
                If selectedproduct Then
                    Dim prod_id As String = dgvPriceList.Rows(item.Index).Cells("id").Value
                    Dim barcode As String = dgvPriceList.Rows(item.Index).Cells("barcode").Value
                    Dim desc As String = dgvPriceList.Rows(item.Index).Cells("ProductDescription").Value
                    Dim brand As String = dgvPriceList.Rows(item.Index).Cells("Brand").Value
                    Dim unit As String = dgvPriceList.Rows(item.Index).Cells("Unit").Value
                    Dim unit_price As String = dgvPriceList.Rows(item.Index).Cells("UnitPrice").Value
                    Dim sell_price As String = dgvPriceList.Rows(item.Index).Cells("sell_price").Value

                    Dim row As String() = New String() {prod_id, barcode, "0", desc, brand, unit, unit_price, "", "Add less", "Reset", unit_price, "0.00", "", "Remove"}
                    CustomerOrderForm.dgvProd.Rows.Add(row)
                End If
            Next
            CustomerOrderForm.ShowDialog()
        Else
            MsgBox("Please select customer", MsgBoxStyle.Critical)
            cbCustomer.Focus()
        End If
    End Sub

    Private Sub btnUpdatePrice_Click(sender As Object, e As EventArgs) Handles btnUpdatePrice.Click
        'validation
        If cbCustomer.SelectedIndex = 0 And cbCustomer.Text.Length > 0 Then
            MsgBox("Please select customer!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If dgvPriceList.SelectedRows.Count = 1 Then
            Dim customer As String = cbCustomer.Text
            Dim barcode As String = dgvPriceList.SelectedRows(0).Cells("Barcode").Value
            Dim prod_desc As String = dgvPriceList.SelectedRows(0).Cells("ProductDescription").Value
            Dim brand As String = dgvPriceList.SelectedRows(0).Cells("Brand").Value
            Dim unit As String = dgvPriceList.SelectedRows(0).Cells("Unit").Value
            Dim unit_price As String = dgvPriceList.SelectedRows(0).Cells("UnitPrice").Value
            Dim sellprice As String = dgvPriceList.SelectedRows(0).Cells("sell_price").Value

            UpdatePriceForm.txtCustomer.Text = customer
            UpdatePriceForm.txtBarcode.Text = barcode
            UpdatePriceForm.txtProductDesc.Text = prod_desc
            UpdatePriceForm.txtBrand.Text = brand
            UpdatePriceForm.txtUnit.Text = unit
            UpdatePriceForm.txtUnitPrice.Text = unit_price
            UpdatePriceForm.txtSellPrice.Text = sellprice
            UpdatePriceForm.ShowDialog()
            Exit Sub
        End If

        If dgvPriceList.SelectedRows.Count = 0 Or dgvPriceList.SelectedRows.Count > 1 Then
            MsgBox("Please select product you want to update price!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub dgvPriceList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPriceList.CellContentClick

    End Sub
End Class



