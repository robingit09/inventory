﻿Public Class CustomerReturn
    Public selectedCustomer As Integer = 0
    Public SelectedProdID As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedUnit As Integer = 0
    Public selectedColor As Integer = 0
    Private Sub CustomerReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialize()
    End Sub

    Public Sub initialize()
        getCustomerList("")
        getInvoiceNo("")
        autocompleteProduct()
        populateBrand(0)
        populateUnit(0, 0)
        populateColor(0, 0, 0)
    End Sub

    Public Sub autocompleteProduct()
        Dim MySource As New AutoCompleteStringCollection()

        With txtProductDesc
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        Dim product As New DatabaseConnect
        With product
            .selectByQuery("Select description from products  where status <> 0  order by description")
            While .dr.Read
                MySource.Add(.dr("description"))
            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub
    Public Sub populateBrand(ByVal prodid As Integer)
        Dim dbbrand As New DatabaseConnect
        With dbbrand
            cbBrand.DataSource = Nothing
            cbBrand.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Brand")
            Dim query As String = "Select distinct b.id, b.name from (product_unit as pu INNER JOIN brand as b on b.id = pu.brand) 
            where pu.product_id = " & prodid
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim brand As String = .dr.GetValue(1)
                    comboSource.Add(id, brand)
                End While
            End If
            cbBrand.DataSource = New BindingSource(comboSource, Nothing)
            cbBrand.DisplayMember = "Value"
            cbBrand.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub populateColor(ByVal prodid As Integer, ByVal brandid As Integer, ByVal unitid As Integer)
        Dim dbunit As New DatabaseConnect
        With dbunit
            cbColor.DataSource = Nothing
            cbColor.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "No Color")

            Dim query As String = "Select distinct c.id, c.name from (product_unit as pu INNER JOIN color as c on c.id = pu.color) 
            where pu.product_id = " & prodid
            If brandid > 0 Then
                query = query & " and pu.brand = " & brandid
            End If

            If unitid > 0 Then
                query = query & " and pu.unit = " & unitid
            End If

            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim color As String = .dr.GetValue(1)
                    comboSource.Add(id, color)
                End While
            End If
            cbColor.DataSource = New BindingSource(comboSource, Nothing)
            cbColor.DisplayMember = "Value"
            cbColor.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub populateUnit(ByVal prodid As Integer, ByVal brandid As Integer)
        Dim dbunit As New DatabaseConnect
        With dbunit
            cbUnit.DataSource = Nothing
            cbUnit.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Unit")
            Dim query As String = "Select distinct u.id, u.name from (product_unit as pu LEFT JOIN unit as u on u.id = pu.unit) 
            where pu.product_id = " & prodid

            If brandid > 0 Then
                query = query & " and pu.brand = " & brandid
            End If

            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim unit As String = .dr.GetValue(1)
                    comboSource.Add(id, unit)
                End While
            End If
            cbUnit.DataSource = New BindingSource(comboSource, Nothing)
            cbUnit.DisplayMember = "Value"
            cbUnit.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub getCustomerList(ByVal query As String)

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()
        Dim db As New DatabaseConnect

        With db
            If query = "" Then
                .selectByQuery("select company,ID from company where status <> 0 order by company")
            Else

            End If

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Customer")
            While db.dr.Read
                Dim cus As String = db.dr.GetValue(0)
                Dim id As String = db.dr.GetValue(1)
                comboSource.Add(id, cus)
            End While

            cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer.DisplayMember = "Value"
            cbCustomer.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Public Sub getInvoiceNo(ByVal query As String)

        cbInvoiceNo.DataSource = Nothing
        cbInvoiceNo.Items.Clear()
        Dim db As New DatabaseConnect

        With db
            If query = "" Then
                .selectByQuery("select invoice_no,ID from ledger where status <> 0 order by created_at desc")
            Else

            End If

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Invoice No")
            While db.dr.Read
                Dim cus As String = db.dr.GetValue(0)
                Dim id As String = db.dr.GetValue(1)
                comboSource.Add(id, cus)
            End While

            cbInvoiceNo.DataSource = New BindingSource(comboSource, Nothing)
            cbInvoiceNo.DisplayMember = "Value"
            cbInvoiceNo.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Private Sub txtEnterBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEnterBarcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(txtEnterBarcode.Text).Length > 0 Then
                'validation
                ' check if exist
                For Each item As DataGridViewRow In dgvProd.Rows
                    If item.Cells("product").Value <> "" Then
                        Dim barcode As String = item.Cells("barcode").Value

                        If barcode = Trim(txtEnterBarcode.Text) Then
                            MsgBox("Product (" & txtEnterBarcode.Text & ") already added!", MsgBoxStyle.Critical)
                            txtEnterBarcode.Text = ""
                            Exit Sub
                        End If
                    End If
                Next

                Dim db As New DatabaseConnect
                With db
                    .selectByQuery("Select distinct pu.product_id, pu.id, pu.barcode, p.description, b.name As brand, u.name As unit, cc.name As color,pu.price as price,
                        pu.brand as brand_id,pu.unit as unit_id,pu.color as color_id,ps.qty as stock, c.name As cat,sub.name as subcat FROM (((((((((products as p 
                    INNER Join product_unit as pu ON p.id = pu.product_id) 
                    Left Join brand as b ON b.id = pu.brand)
                    INNER Join unit as u ON u.id = pu.unit)
                    Left Join color as cc ON cc.id = pu.color)
                    LEFT JOIN product_stocks as ps on ps.product_unit_id = pu.id)
                    INNER Join product_categories as pc ON pc.product_id = p.id) 
                    Left Join product_subcategories as psc ON psc.product_id = p.id)
                    Left Join categories as c ON c.id = pc.category_id)
                    Left Join categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 and pu.barcode = '" & Trim(txtEnterBarcode.Text) & "'")

                    If .dr.Read Then
                        Dim p_u_id As Integer = CInt(.dr("id"))
                        Dim brand_id As Integer = CInt(.dr("brand_id"))
                        Dim unit_id As Integer = CInt(.dr("unit_id"))
                        Dim color_id As Integer = CInt(.dr("color_id"))

                        Dim id As Integer = CInt(.dr("id"))
                        Dim barcode As String = .dr("barcode")
                        Dim desc As String = .dr("description")
                        Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                        Dim unit As String = .dr("unit")
                        Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                        Dim price As String = Val(.dr("price")).ToString("N2")
                        Dim sell_price As String = Val(getSellPrice(selectedCustomer, p_u_id)).ToString("N2")
                        Dim stock As Integer = Val(.dr("stock"))
                        Dim row As String() = New String() {id, barcode, "", desc, brand, unit, color, price, sell_price, "0.00", stock, "Remove"}
                        dgvProd.Rows.Add(row)
                        txtEnterBarcode.Text = ""
                    End If

                    .dr.Close()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If

        End If
    End Sub


    Private Function getSellPrice(ByVal customer As Integer, ByVal p_u_id As Integer)
        Dim res As String = ""
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select sell_price from customer_product_prices where customer_id = " & customer & " and product_unit_id = " & p_u_id)
            If .dr.Read Then
                res = Val(.dr("sell_price")).ToString("N2")
            Else
                res = "0.00"
            End If
        End With
        Return res
    End Function

    Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            cbCustomer.BackColor = Drawing.Color.White
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key
        Else
            selectedCustomer = 0
        End If
    End Sub

    Private Sub txtProductDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Trim(txtProductDesc.Text).Length > 0 Then
                SelectedProdID = New DatabaseConnect().get_id("products", "description", Trim(txtProductDesc.Text))
                populateBrand(SelectedProdID)
                txtProductDesc.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtProductDesc.Text.ToLower())
            Else
                SelectedProdID = 0
                populateBrand(selectedBrand)
            End If
        End If
    End Sub

    Private Sub cbBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand.SelectedIndexChanged
        If cbBrand.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedBrand = key
            populateUnit(SelectedProdID, selectedBrand)
        Else
            selectedBrand = 0
            populateUnit(SelectedProdID, selectedBrand)
        End If
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedUnit = key
            populateColor(SelectedProdID, selectedBrand, selectedUnit)
        Else
            selectedUnit = 0
            populateColor(SelectedProdID, selectedBrand, selectedUnit)
        End If
    End Sub

    Private Sub cbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbColor.SelectedIndexChanged
        If cbColor.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedColor = key
            'populateUnit(SelectedProdID, selectedBrand)
        Else
            selectedColor = 0
            'populateUnit(SelectedProdID, selectedBrand)
        End If
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs) Handles btnAddToCart.Click
        If selectedCustomer = 0 Then
            MsgBox("Please select customer!", MsgBoxStyle.Critical)
            cbCustomer.Focus()

            Exit Sub
        End If

        'validation
        'check if already in list
        For Each item As DataGridViewRow In Me.dgvProd.Rows
            If Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("action").Value) Then
                Dim desc As String = dgvProd.Rows(item.Index).Cells("product").Value
                Dim brand As String = dgvProd.Rows(item.Index).Cells("brand").Value
                Dim unit As String = dgvProd.Rows(item.Index).Cells("unit").Value
                Dim color As String = dgvProd.Rows(item.Index).Cells("Color").Value

                Dim prod_id As String = New DatabaseConnect().get_id("products", "description", desc)
                Dim brand_id As String = New DatabaseConnect().get_id("brand", "name", brand)
                Dim unit_id As String = New DatabaseConnect().get_id("unit", "name", unit)
                Dim color_id As String = New DatabaseConnect().get_id("color", "name", color)

                If prod_id = SelectedProdID And brand_id = selectedBrand And unit_id = selectedUnit And color_id = selectedColor Then
                    MsgBox(brand & " " & desc & " already in list!", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        Next


        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT pu.barcode,pu.id,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price, ps.qty as stock from (((((products as p 
                left join product_unit as pu on pu.product_id = p.id)
                left join brand as b on b.id = pu.brand)
                left join unit as u on u.id = pu.unit)
                left join color as cc on cc.id = pu.color)
                left join product_stocks as ps ON ps.product_unit_id = pu.id)
                where pu.brand = " & selectedBrand & " and pu.product_id = " & SelectedProdID & " and pu.unit = " & selectedUnit & " and color = " & selectedColor)

            If .dr.HasRows Then
                If .dr.Read Then
                    Dim product_unit_id As String = .dr("id").ToString
                    Dim barcode As String = .dr("barcode").ToString
                    Dim desc As String = .dr("description").ToString
                    Dim brand As String = .dr("brand").ToString
                    Dim unit As String = .dr("unit").ToString
                    Dim color As String = .dr("color").ToString
                    Dim unitprice As String = Val(.dr("price")).ToString("N2")
                    Dim sell_price As String = Val(getSellPrice(selectedCustomer, product_unit_id)).ToString("N2")
                    'get sell price

                    'Dim dbcost As New DatabaseConnect
                    'With dbcost
                    '    .selectByQuery("Select unit_cost from product_suppliers where product_unit_id = " & product_unit_id)
                    '    If .dr.HasRows Then
                    '        If .dr.Read Then
                    '            If (Val(.dr("unit_cost") > 0)) Then
                    '                unitcost = Val(.dr("unit_cost")).ToString("N2")
                    '            Else
                    '                unitcost = "0.00"
                    '            End If
                    '        End If
                    '    End If
                    '    .con.Close()
                    '    .dr.Close()
                    '    .cmd.Dispose()
                    'End With

                    Dim stock As String = If(IsDBNull(.dr("stock")), "0", .dr("stock"))

                    Dim row As String() = New String() {product_unit_id, barcode, "0", desc, brand, unit, color, unitprice, sell_price, "0.00", stock, "Remove"}
                    dgvProd.Rows.Add(row)

                End If
            Else
                MsgBox("No Product Found!", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
End Class