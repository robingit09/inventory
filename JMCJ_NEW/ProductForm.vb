Public Class ProductForm
    Public selectedProduct As Integer = 0
    Public selectedCategory As Integer = 0
    Public selectedSubcategory As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedBrand As Integer = 0
    Public selected

    'Private Function toCapitalFirst(ByVal str As String) As String
    '    Dim result As String
    '    result = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower
    '    Return result
    'End Function
    Private Sub saveData()
        Dim prod_id = 0
        Dim db As New DatabaseConnect
        With db

            Dim dbprod As New DatabaseConnect
            With dbprod
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "INSERT INTO PRODUCTS (description,status,created_at,updated_at)
        VALUES ('" & toFormatLetter(txtProduct.Text) & "',1,'" & DateTime.Now.ToString & "','" & DateTime.Now.ToString & "')"
                .cmd.ExecuteNonQuery()
                .cmd.Parameters.Clear()
                .cmd.Dispose()
                .con.Close()
                prod_id = getLatestID("products")
            End With

            Dim dbinsertcategory As New DatabaseConnect
            With dbinsertcategory
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "INSERT INTO product_categories (product_id,category_id,created_at,updated_at) VALUES(" & prod_id & "," & selectedCategory & ",'" & DateTime.Now.ToString & "','" & DateTime.Now.ToString & "')"
                .cmd.ExecuteNonQuery()
                '.cmd.Parameters.Clear()

                .cmd.CommandText = "INSERT INTO product_subcategories (product_id,subcategory_id,created_at,updated_at) VALUES(" & prod_id & "," & selectedSubcategory & ",'" & DateTime.Now.ToString & "','" & DateTime.Now.ToString & "')"
                .cmd.ExecuteNonQuery()
                '.cmd.Parameters.Clear()
                .cmd.Dispose()
                .con.Close()
            End With



            Dim barcode As String = ""
            Dim itemcode As String = Trim(txtItemCode.Text)
            Dim brand As Integer = If(cbBrand.Text = "No Brand", 0, New DatabaseConnect().get_id("brand", "name", cbBrand.Text))
            Dim color As Integer = If(cbColor.Text = "No Color", 0, New DatabaseConnect().get_id("color", "name", cbColor.Text))

            'insert unit and price
            Dim unit As Integer = 0
            Dim price As String = ""

            If dgvMeasure2.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgvMeasure2.Rows
                    If row.Cells("mUnit").Value <> "Select" And row.Cells("mPrice").Value <> "" And row.Cells("isdefault").Value = True Then
                        barcode = If(row.Cells("mBarcode").Value = "", "_", row.Cells("mBarcode").Value)
                        unit = New DatabaseConnect().get_id("unit", "name", row.Cells("mUnit").Value)
                        price = row.Cells("mPrice").Value

                    End If
                Next
            End If


            'insert default unit
            Dim dbinsertunit As New DatabaseConnect
            With dbinsertunit
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "INSERT INTO product_unit (product_id,brand,unit,color,barcode,item_code,price,status,created_at,updated_at)VALUES(?,?,?,?,?,?,?,?,?,?)"
                .cmd.Parameters.AddWithValue("@product_id", prod_id)
                .cmd.Parameters.AddWithValue("@brand", brand)
                .cmd.Parameters.AddWithValue("@unit", unit)
                .cmd.Parameters.AddWithValue("@color", color)
                .cmd.Parameters.AddWithValue("@barcode", barcode)
                .cmd.Parameters.AddWithValue("@item_code", itemcode)
                .cmd.Parameters.AddWithValue("@price", price)
                .cmd.Parameters.AddWithValue("@status", 1)
                .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                .cmd.ExecuteNonQuery()
                .cmd.Dispose()
                .con.Close()

            End With

            'insert stock
            Dim p_u_id As Integer = New DatabaseConnect().getLastID("product_unit")
            Dim insertstock As New DatabaseConnect
            With insertstock
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "INSERT INTO product_stocks (product_unit_id,qty,created_at,updated_at)VALUES(?,?,?,?)"
                .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                .cmd.Parameters.AddWithValue("@qty", 0)
                .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                .cmd.ExecuteNonQuery()
                .cmd.Parameters.Clear()

                .cmd.Dispose()
                .con.Close()

            End With

            'insert measurement
            Dim dbprodmeasure As New DatabaseConnect
            With dbprodmeasure
                If dgvMeasure2.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In dgvMeasure2.Rows
                        If row.Cells("mUnit").Value <> "Select" And row.Cells("mPrice").Value <> "" Then

                            Dim barcode2 As String = If(row.Cells("mBarcode").Value = "", "_", row.Cells("mBarcode").Value)
                            Dim unit2 As String = row.Cells("mUnit").Value
                            Dim def As Integer = row.Cells("isdefault").Value
                            If def = True Then
                                def = 1
                            Else
                                def = 0
                            End If

                            If Trim(row.Cells("mUnit").Value) <> "Select" Or Trim(row.Cells("mUnit").Value) <> "" Then
                                unit2 = New DatabaseConnect().get_id("unit", "name", Trim(row.Cells("mUnit").Value))
                            End If

                            Dim price2 As String = row.Cells("mPrice").Value

                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "INSERT INTO product_measure (barcode,product_unit_id,unit_id,price,is_default,created_at,updated_at)VALUES(?,?,?,?,?,?,?)"
                            .cmd.Parameters.AddWithValue("@barcode", barcode2)
                            .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                            .cmd.Parameters.AddWithValue("@unit_id", unit2)
                            .cmd.Parameters.AddWithValue("@price", price2)
                            .cmd.Parameters.AddWithValue("@is_default", def)
                            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                            .cmd.ExecuteNonQuery()
                            .cmd.Parameters.Clear()
                            '.con.Close()

                        End If
                    Next
                    .cmd.Dispose()
                    .con.Close()
                End If
            End With

            'update default unit
            'Dim dbupdateunit As New DatabaseConnect
            'With dbupdateunit
            '    .selectByQuery("select * from product_measure where product_unit_id = " & p_u_id & " and is_default = 1")
            '    Dim bcode As String = ""
            '    Dim unit_id As Integer = 0
            '    Dim pricee As Double = 0


            '    If .dr.Read Then
            '        bcode = .dr("barcode")
            '        unit_id = CInt(.dr("unit_id"))
            '        pricee = CDbl(.dr("price"))

            '    End If
            '    .dr.Close()
            '    .cmd.Parameters.Clear()

            '    .cmd.Connection = .con
            '    .cmd.CommandType = CommandType.Text
            '    .cmd.CommandText = "update product_unit set unit = @unit, barcode = @barcode , price = @price where product_id = " & p_u_id
            '    .cmd.Parameters.AddWithValue("@unit", unit_id)
            '    .cmd.Parameters.AddWithValue("@barcode", bcode)
            '    .cmd.Parameters.AddWithValue("@price", pricee)
            '    .cmd.ExecuteNonQuery()
            '    .cmd.Dispose()
            '    .dr.Close()
            '    .con.Close()

            'End With


            'insert suppliers
            Dim dbinsertsupplier As New DatabaseConnect
            With dbinsertsupplier
                If dgvCost.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In dgvCost.Rows
                        If row.Cells("sUnit").Value <> "Select" And row.Cells("Supplier").Value <> "Select" Then
                            Dim supplier_id As Integer = New DatabaseConnect().get_id("suppliers", "supplier_name", row.Cells("Supplier").Value)
                            Dim unit_id As Integer = New DatabaseConnect().get_id("unit", "name", row.Cells("sUnit").Value)
                            Dim cost As Double = CDbl(row.Cells("Cost").Value)

                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "INSERT INTO product_suppliers(product_unit_id,unit_id,supplier,unit_cost,created_at,updated_at)
                            VALUES(?,?,?,?,?,?)"
                            .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                            .cmd.Parameters.AddWithValue("@unit_id", unit_id)
                            .cmd.Parameters.AddWithValue("@supplier", supplier_id)
                            .cmd.Parameters.AddWithValue("@unit_cost", cost)
                            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                            .cmd.ExecuteNonQuery()
                            .cmd.Parameters.Clear()

                        End If
                    Next
                    .cmd.Dispose()
                    .con.Close()
                End If
            End With

            'insert customers
            Dim dginsertcustomer As New DatabaseConnect
            With dginsertcustomer
                If dgvSellPrice.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In dgvSellPrice.Rows
                        If row.Cells("spUnit").Value <> "Select" And row.Cells("spCustomer").Value <> "Select" Then
                            Dim customer_id As Integer = New DatabaseConnect().get_id("company", "company", row.Cells("spCustomer").Value)
                            Dim unit_id As Integer = New DatabaseConnect().get_id("unit", "name", row.Cells("spUnit").Value)
                            Dim sell_price As Double = CDbl(row.Cells("spSellPrice").Value)

                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "INSERT INTO customer_product_prices(product_unit_id,unit_id,customer_id,sell_price,created_at,updated_at) 
                        VALUES(?,?,?,?,?,?)"
                            .cmd.Parameters.AddWithValue("@product_unit_id", p_u_id)
                            .cmd.Parameters.AddWithValue("@unit_id", unit_id)
                            .cmd.Parameters.AddWithValue("@customer_id", customer_id)
                            .cmd.Parameters.AddWithValue("@sell_price", sell_price)
                            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                            .cmd.ExecuteNonQuery()
                            .cmd.Parameters.Clear()

                        End If
                    Next
                    .cmd.Dispose()
                    .con.Close()
                End If
            End With

            MsgBox("Save Successfully!", MsgBoxStyle.Information)
                Me.Close()
            End With

    End Sub

    Private Function getLatestID(ByVal table As String) As Integer
        Dim result As Integer = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select MAX(id) from " & table)
            If .dr.HasRows Then
                If .dr.Read Then
                    result = If(IsDBNull(.dr.GetValue(0)), 0, .dr.GetValue(0))
                Else
                    result = 0
                End If
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
        Return result
    End Function

    Private Sub updateData()

        Dim dbupdate As New DatabaseConnect
        With dbupdate
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "Update products set description=?,updated_at=? where id = " & selectedProduct
            .cmd.Parameters.AddWithValue("@description", toFormatLetter(txtProduct.Text))
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()
            .cmd.Parameters.Clear()

            .cmd.CommandText = "Update product_categories set category_id = " & selectedCategory & " where product_id = " & selectedProduct
            .cmd.ExecuteNonQuery()
            .cmd.Parameters.Clear()

            .cmd.CommandText = "Update product_subcategories set subcategory_id = " & selectedSubcategory & " where product_id = " & selectedProduct
            .cmd.ExecuteNonQuery()
            .cmd.Parameters.Clear()

            ' get the default unit and price
            Dim default_unit_id As String = ""
            Dim price As String = "0.00"
            For Each item As DataGridViewRow In Me.dgvMeasure2.Rows
                Dim is_default As Boolean = dgvMeasure2.Rows(item.Index).Cells("isdefault").Value
                Dim unit_name As String = dgvMeasure2.Rows(item.Index).Cells("mUnit").Value

                If is_default = True Then
                    default_unit_id = New DatabaseConnect().get_id("unit", "name", unit_name)
                    price = dgvMeasure2.Rows(item.Index).Cells("mPrice").Value
                End If
            Next

            .cmd.CommandText = "Update product_unit set brand=?,unit=?,color=?,barcode=?,item_code=?,price=?,updated_at=? 
                where product_id = " & selectedProduct
            .cmd.Parameters.AddWithValue("@brand", selectedBrand)
            .cmd.Parameters.AddWithValue("@unit", default_unit_id)
            .cmd.Parameters.AddWithValue("@color", selectedColor)
            .cmd.Parameters.AddWithValue("@barcode", Trim(txtBarcode.Text))
            .cmd.Parameters.AddWithValue("@item_code", Trim(txtItemCode.Text))
            .cmd.Parameters.AddWithValue("@price", price)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()
            .cmd.Parameters.Clear()

            .delete_permanent("product_measure", "product_unit_id", selectedProduct)


            Dim cmd2 As New System.Data.OleDb.OleDbCommand
            cmd2.Connection = .con
            cmd2.CommandType = CommandType.Text


            For Each row As DataGridViewRow In dgvMeasure2.Rows
                If row.Cells("mUnit").Value <> "Select" And row.Cells("mPrice").Value <> "" Then

                    Dim barcode2 As String = row.Cells("mBarcode").Value
                    Dim unit2 As String = row.Cells("mUnit").Value
                    Dim def As Boolean = row.Cells("isdefault").Value

                    If Trim(row.Cells("mUnit").Value) <> "Select" Or Trim(row.Cells("mUnit").Value) <> "" Then
                        unit2 = New DatabaseConnect().get_id("unit", "name", Trim(row.Cells("mUnit").Value))
                    End If

                    Dim price2 As String = row.Cells("mPrice").Value
                    'MsgBox(unit2 & "  " & price2 & " " & def)

                    .cmd.Connection = .con
                    .cmd.CommandType = CommandType.Text
                    .cmd.CommandText = "INSERT INTO product_measure (barcode,product_unit_id,unit_id,price,is_default,created_at,updated_at)VALUES(?,?,?,?,?,?,?)"
                    .cmd.Parameters.AddWithValue("@barcode", barcode2)
                    .cmd.Parameters.AddWithValue("@product_unit_id", selectedProduct)
                    .cmd.Parameters.AddWithValue("@unit_id", unit2)
                    .cmd.Parameters.AddWithValue("@price", price2)
                    .cmd.Parameters.AddWithValue("@is_default", If(def = True, 1, 0))
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()


                End If
            Next





            'insert supplier and their cost
            Dim dbdelete As New DatabaseConnect
            dbdelete.delete_permanent("product_suppliers", "product_unit_id", selectedProduct)
            dbdelete.cmd.Dispose()
            dbdelete.con.Close()
            Dim saveCost As New DatabaseConnect
            With saveCost


                For Each item As DataGridViewRow In dgvCost.Rows
                    If item.Cells("Supplier").Value <> "" And item.Cells("Supplier").Value <> "Select Supplier" And item.Cells("Supplier").Value <> "Select" Then


                        Dim supplier As String = New DatabaseConnect().get_id("suppliers", "supplier_name", item.Cells("Supplier").Value)
                        Dim unit_name As String = New DatabaseConnect().get_id("unit", "name", item.Cells("sUnit").Value)
                        Dim cost As Double = Val(item.Cells("Cost").Value)

                        'MsgBox(item.Cells("Supplier").Value & " " & item.Cells("sUnit").Value)
                        'MsgBox(supplier & " " & unit_name)

                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text
                        .cmd.CommandText = "INSERT INTO product_suppliers (product_unit_id,supplier,unit_id,unit_cost,created_at,updated_at)
            VALUES(?,?,?,?,?,?)"
                        .cmd.Parameters.AddWithValue("@product_unit_id", selectedProduct)
                        .cmd.Parameters.AddWithValue("@supplier", supplier)
                        .cmd.Parameters.AddWithValue("@unit_id", unit_name)
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



            Dim dbdelete2 As New DatabaseConnect
            dbdelete2.delete_permanent("customer_product_prices", "product_unit_id", selectedProduct)
            dbdelete2.cmd.Dispose()

            Dim dginsertcustomer As New DatabaseConnect
            With dginsertcustomer
                If dgvSellPrice.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In dgvSellPrice.Rows
                        If row.Cells("spUnit").Value <> "Select" And row.Cells("spCustomer").Value <> "Select" Then
                            Dim customer_id As Integer = New DatabaseConnect().get_id("company", "company", row.Cells("spCustomer").Value)
                            Dim unit_id As Integer = New DatabaseConnect().get_id("unit", "name", row.Cells("spUnit").Value)
                            Dim sell_price As Double = CDbl(row.Cells("spSellPrice").Value)

                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "INSERT INTO customer_product_prices(product_unit_id,unit_id,customer_id,sell_price,created_at,updated_at) 
                        VALUES(?,?,?,?,?,?)"
                            .cmd.Parameters.AddWithValue("@product_unit_id", selectedProduct)
                            .cmd.Parameters.AddWithValue("@unit_id", unit_id)
                            .cmd.Parameters.AddWithValue("@customer_id", customer_id)
                            .cmd.Parameters.AddWithValue("@sell_price", sell_price)
                            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                            .cmd.ExecuteNonQuery()
                            .cmd.Parameters.Clear()

                        End If
                    Next
                    .cmd.Dispose()
                    .con.Close()
                End If
            End With

            cmd2.Dispose()
            .cmd.Dispose()
            .con.Close()

            'update default unit
            Dim dbupdateunit As New DatabaseConnect
            With dbupdateunit
                .selectByQuery("select * from product_measure where product_unit_id = " & selectedProduct & " and is_default = 1")
                Dim bcode As String = ""
                Dim unit_id As Integer = 0
                Dim pricee As Double = 0

                If .dr.Read Then
                    bcode = .dr("barcode")
                    unit_id = CInt(.dr("unit_id"))
                    pricee = CDbl(.dr("price"))

                End If

                .cmd.Parameters.Clear()
                .dr.Close()

                'MsgBox(bcode & " " & unit_id & " " & pricee)
                .cmd.Connection = .con
                .cmd.CommandType = CommandType.Text
                .cmd.CommandText = "update product_unit set unit = @unit, barcode = @barcode , price = @price where product_id = " & selectedProduct
                .cmd.Parameters.AddWithValue("@unit", unit_id)
                .cmd.Parameters.AddWithValue("@barcode", bcode)
                .cmd.Parameters.AddWithValue("@price", pricee)
                .cmd.ExecuteNonQuery()
                .cmd.Dispose()
                .dr.Close()
                .con.Close()

            End With

            MsgBox("Product Successfully Update.", MsgBoxStyle.Information)
            clearFields()
            Me.Close()
            ProductList.loadList("")
        End With

        '        Dim database As New DatabaseConnect
        '        database.dbConnect()
        '        database.cmd.CommandType = CommandType.Text
        '        database.cmd.CommandText = "UPDATE products Set [name]='" & txtProduct.Text & "',[category]='" & cbCat.Text & "',[brand]='" & txtBrand.Text & "',[unit]='" & cbUnit.Text & "', " & _
        '"[quantity]='" & txtQty.Text & "',[price]='" & txtPrice.Text & "', [updated_at]='" & DateTime.Now.Date & "' WHERE [ID] = " & ProductList.selectedID


        '        database.cmd.Connection = database.con

        '        Try
        '            database.cmd.ExecuteNonQuery()
        '            database.con.Close()
        '            MsgBox("Update Successfully", MsgBoxStyle.Information)
        '        Catch ex As Exception
        '            MsgBox(ex.Message & vbNewLine & database.cmd.CommandText, MsgBoxStyle.Critical)
        '        End Try

        '        'frmCustomerList.populateComboLocation()
        '        ProductList.loadList("")
        '        Me.Close()

    End Sub

    Private Sub initializeStock()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select * from product_unit where id not in (select product_unit_id from product_stocks)")
            While .dr.Read
                Dim p_u_id As String = .dr("id")
                ModelFunction.update_stock(p_u_id, 0, "+")
            End While
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Public Sub populateCategory()
        cbCategory.DataSource = Nothing
        cbCategory.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Category")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = 0")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbCategory.DataSource = New BindingSource(comboSource, Nothing)
            cbCategory.DisplayMember = "Value"
            cbCategory.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub populateSubcategory(ByVal category As Integer)
        cbSubcategory.DataSource = Nothing
        cbSubcategory.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Subcategory")
        Dim db As New DatabaseConnect
        With db
            If category > 0 Then
                .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = " & category)
            ElseIf category = 0 Then
                .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id <> 0 ")
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()

            cbSubcategory.DataSource = New BindingSource(comboSource, Nothing)
            cbSubcategory.DisplayMember = "Value"
            cbSubcategory.ValueMember = "Key"
        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            Dim dbvalidate As New DatabaseConnect
            With dbvalidate
                If (.isExist("products", "description", txtProduct.Text)) Then

                    MsgBox("Product description already exist!", MsgBoxStyle.Critical)
                    txtProduct.Focus()
                    Exit Sub
                End If
                .dr.Close()
                .cmd.Dispose()
                .con.Close()
            End With
            If validation() = False Then
                Exit Sub
            End If
            saveData()

            ' re initialize product selection
            PurchaseOrderForm.autocompleteProduct()
            PurchaseOrderForm.populateBrand(0)
            PurchaseOrderForm.populateUnit(0, 0)
            PurchaseOrderForm.populateColor(0, 0, 0)
            ProductList.loadList("")
        ElseIf btnSave.Text = "Update" Then
            If validation() = False Then
                Exit Sub
            End If
            updateData()
            initializeStock() 'initialize stock of new products
        End If

    End Sub

    Function validation() As Boolean
        Dim res As Boolean = True

        If Trim(txtProduct.Text) = "" Then
            res = False
            MsgBox("Product description field is required!", MsgBoxStyle.Critical)
            txtProduct.Focus()
            Return res
        End If


        'If selectedCategory = 0 Then
        '    res = False
        '    MsgBox("Category field is required!", MsgBoxStyle.Critical)
        '    cbCategory.Focus()
        '    Return res
        'End If

        'If selectedSubcategory = 0 Then
        '    res = False
        '    MsgBox("Sub Category field is required!", MsgBoxStyle.Critical)
        '    cbCategory.Focus()
        '    Return res
        'End If

        'If dgvMeasure.Rows.Count = 0 Or dgvMeasure.Rows.Count = 1 Then
        '    res = False
        '    MsgBox("Please add measurement for this product!", MsgBoxStyle.Critical)
        '    dgvMeasure.Focus()
        '    Return res
        'End If

        If dgvMeasure2.Rows.Count = 0 Or dgvMeasure2.Rows.Count = 1 Then
            res = False
            MsgBox("Please add measurement for this product!", MsgBoxStyle.Critical)
            dgvMeasure2.Focus()
            Return res
        End If


        ' validation for measurement
        Dim validateunit As Boolean = True
        Dim validateprice As Boolean = True

        If dgvMeasure2.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvMeasure2.Rows
                If row.Cells("mUnit").Value = "Select" And row.Cells("mPrice").Value <> "" Then
                    validateunit = False
                End If

                If row.Cells("mUnit").Value <> "Select" And row.Cells("mPrice").Value = "" Then
                    validateprice = False
                End If
            Next
        End If


        If validateunit = False Then
            res = False
            MsgBox("Please select unit for measure.", MsgBoxStyle.Critical)
            Return res
        End If

        If validateprice = False Then
            res = False
            MsgBox("Please add price for unit.", MsgBoxStyle.Critical)
            Return res
        End If

        ' check if no default selected
        Dim validate_has_default As Boolean = False
        If dgvMeasure2.Rows.Count > 0 Then
            For Each row As DataGridViewRow In dgvMeasure2.Rows
                ' check if has default
                If (row.Cells("mUnit").Value <> "Select" Or row.Cells("mUnit").Value <> "") And row.Cells("isdefault").Value = True Then
                    validate_has_default = True
                    Exit For
                End If
            Next
        End If


        If validate_has_default = False Then
            res = False
            MsgBox("Please select the default unit measurement.", MsgBoxStyle.Critical)
            Return res
        End If


        'supplier and costing validation
        Dim count_duplicate_supplier As Integer = 0
        Dim prev_supplier As String = ""
        Dim prev_unit As String = ""
        For Each item As DataGridViewRow In dgvCost.Rows

            If item.Cells("Supplier").Value <> "Select Supplier" Then
                Dim supplier As String = item.Cells("Supplier").Value.ToString.ToUpper
                Dim unit_name As String = item.Cells("sUnit").Value.ToString.ToUpper

                If prev_supplier = supplier And prev_unit = unit_name Then
                    count_duplicate_supplier = count_duplicate_supplier + 1
                    'MsgBox(count_duplicate_supplier)
                End If

                prev_supplier = supplier
                prev_unit = unit_name
            End If
        Next

        If count_duplicate_supplier > 0 Then
            res = False
            MsgBox("Does not allow duplicate supplier and unit.", MsgBoxStyle.Critical)
            Return res
        End If

        'customer and prices validation
        Dim count_duplicate_customer As Integer = 0
        Dim prev_customer As String = ""
        Dim prev_unit2 As String = ""
        For Each item As DataGridViewRow In dgvSellPrice.Rows

            If item.Cells("spCustomer").Value <> "Select" Or item.Cells("spCustomer").Value <> "Select Customer" Then
                Dim customer As String = item.Cells("spCustomer").Value.ToString.ToUpper
                Dim unit_name As String = item.Cells("spUnit").Value.ToString.ToUpper

                If prev_customer = customer And prev_unit2 = unit_name Then
                    count_duplicate_customer = count_duplicate_customer + 1
                    'MsgBox(count_duplicate_supplier)
                End If

                prev_customer = customer
                prev_unit2 = unit_name
            End If
        Next

        If count_duplicate_customer > 0 Then
            res = False
            MsgBox("Does not allow duplicate customer and unit.", MsgBoxStyle.Critical)
            Return res
        End If

        Return res
    End Function

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged
        If cbCategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCategory = CInt(key)
            populateSubcategory(selectedCategory)

        ElseIf cbCategory.SelectedIndex = 0 Then
            selectedCategory = 0
            populateSubcategory(0)
        End If
    End Sub

    Private Sub cbSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubcategory.SelectedIndexChanged
        If cbSubcategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSubcategory = CInt(key)
        Else
            selectedSubcategory = 0
        End If
    End Sub

    Private Sub btnAddMoreUnit_Click(sender As Object, e As EventArgs)
        ProductAddUnitForm.Text = "Add"
        ProductAddUnitForm.btnAdd.Text = "Add"
        ProductAddUnitForm.selectedBarcode = ""
        ProductAddUnitForm.loadBrand()
        ProductAddUnitForm.loadUnit()
        ProductAddUnitForm.loadColor()
        ProductAddUnitForm.resetFields()
        ProductAddUnitForm.ShowDialog()
    End Sub

    Public Sub toUpdateInfo(ByVal id As Integer)
        If id > 0 Then
            selectedProduct = id
            Dim dbproduct As New DatabaseConnect
            With dbproduct
                .selectByQuery("Select id,description from products where status = 1 and id = " & id)
                If .dr.HasRows Then
                    If .dr.Read Then
                        txtProduct.Text = .dr("description")
                        Dim dbcategory As New DatabaseConnect
                        With dbcategory
                            .selectByQuery("SELECT c.id,c.name from product_categories as pc INNER JOIN categories as c on c.id = pc.category_id where pc.product_id = " & id)
                            If .dr.HasRows Then
                                If .dr.Read Then
                                    Dim catid As String = .dr.GetValue(0)
                                    Dim name As String = .dr.GetValue(1)
                                    cbCategory.SelectedIndex = cbCategory.FindStringExact(name)
                                End If
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With

                        Dim dbsub As New DatabaseConnect
                        With dbsub
                            .selectByQuery("SELECT c.id,c.name from product_subcategories as pc INNER JOIN categories as c on c.id = pc.subcategory_id where pc.product_id = " & id)
                            If .dr.HasRows Then
                                If .dr.Read Then
                                    Dim catid As String = .dr.GetValue(0)
                                    Dim name As String = .dr.GetValue(1)
                                    cbSubcategory.SelectedIndex = cbSubcategory.FindStringExact(name)
                                End If
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With

                    End If
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With


            Dim pu_id As String = ""
            Dim dbprodunit As New DatabaseConnect
            With dbprodunit
                .selectByQuery("select pu.id,pu.barcode,pu.item_code,b.name as brand, u.name as unit,c.name as color, pu.price from (((product_unit as pu 
                                LEFT JOIN brand as b ON b.id = pu.brand) 
                                INNER JOIN unit as u ON u.id = pu.unit)
                                LEFT JOIN color as c ON c.id = pu.color)
                                where pu.product_id = " & id & " and pu.status <> 0")
                If .dr.HasRows Then
                    If .dr.Read Then
                        pu_id = .dr("id")
                        Dim barcode As String = .dr("barcode")
                        Dim itemcode As String = If(IsDBNull(.dr("item_code")), "", .dr("item_code"))
                        Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                        Dim unit As String = .dr("unit")
                        Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                        Dim price As String = .dr("price")
                        txtBarcode.Text = barcode
                        txtItemCode.Text = itemcode
                        cbColor.SelectedIndex = cbColor.FindString(color)
                        cbBrand.SelectedIndex = cbBrand.FindString(brand)

                    End If
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With

            Dim dbmeasure As New DatabaseConnect
            With dbmeasure
                dgvMeasure2.Rows.Clear()
                .selectByQuery("select pm.id,pm.barcode,pm.price,pm.is_default, u.name as unit_name  from (product_measure as pm
                    INNER JOIN unit as u ON u.id = pm.unit_id)
                    where pm.product_unit_id = " & id & " order by pm.id")


                If .dr.HasRows Then
                    While .dr.Read
                        Dim pm_id As String = .dr("id")
                        Dim barcode As String = If(IsDBNull(.dr("barcode")), "", .dr("barcode"))
                        Dim unit As String = If(IsDBNull(.dr("unit_name")), "", .dr("unit_name"))
                        Dim price As String = Val(.dr("price")).ToString("N2")
                        Dim is_default As Boolean = .dr("is_default")
                        'MsgBox(barcode & " " & unit & " " & price & " " & is_default)
                        Dim row As String() = New String() {pm_id, barcode, unit, price, is_default, "Remove"}
                        dgvMeasure2.Rows.Add(row)
                    End While
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With


            Dim dbsupplier As New DatabaseConnect
            With dbsupplier
                dgvCost.Rows.Clear()
                .selectByQuery("Select s.supplier_name,u.name as unit_name,ps.unit_cost from ((product_suppliers as ps
            left join suppliers as s ON s.id = ps.supplier)
            inner join unit as u on u.id = ps.unit_id)
            where ps.product_unit_id = " & selectedProduct)
                If .dr.HasRows Then
                    While .dr.Read
                        Dim s_name As String = If(IsDBNull(.dr("supplier_name")), "", .dr("supplier_name"))
                        Dim unit_name As String = If(IsDBNull(.dr("unit_name")), "", .dr("unit_name"))
                        Dim cost As String = Val(.dr("unit_cost")).ToString("N2")

                        Dim row As String() = New String() {s_name, unit_name, cost, "Remove"}
                        dgvCost.Rows.Add(row)
                    End While
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With

            Dim dbsellprice As New DatabaseConnect
            With dbsellprice
                dgvSellPrice.Rows.Clear()
                .selectByQuery("Select s.company as customer,u.name as unit_name,ps.sell_price as sell_price from ((customer_product_prices as ps
            left join company as s ON s.id = ps.customer_id)
            inner join unit as u on u.id = ps.unit_id)
        where ps.product_unit_id = " & selectedProduct & " order by ps.id")
                If .dr.HasRows Then
                    While .dr.Read
                        Dim c_name As String = If(IsDBNull(.dr("customer")), "", .dr("customer"))
                        Dim unit_name As String = If(IsDBNull(.dr("unit_name")), "", .dr("unit_name"))
                        Dim sell_price As String = Val(.dr("sell_price")).ToString("N2")

                        Dim row As String() = New String() {c_name, unit_name, sell_price, "Remove"}
                        dgvSellPrice.Rows.Add(row)
                    End While
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With

        End If
    End Sub

    Private Sub btnEditUnit_Click(sender As Object, e As EventArgs)
        'If dgvMeasure.Rows.Count = 1 Then
        '    MsgBox("No measurement list found", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
        'If dgvMeasure.SelectedRows.Count = 1 Then
        '    ProductAddUnitForm.Text = "Update"
        '    ProductAddUnitForm.loadBrand()
        '    ProductAddUnitForm.loadUnit()
        '    ProductAddUnitForm.loadColor()
        '    ProductAddUnitForm.btnAdd.Text = "Update"
        '    ProductAddUnitForm.txtBarcode.Text = dgvMeasure.SelectedRows(0).Cells("barcode").Value
        '    ProductAddUnitForm.selectedBarcode = dgvMeasure.SelectedRows(0).Cells("barcode").Value
        '    ProductAddUnitForm.txtItemCode.Text = dgvMeasure.SelectedRows(0).Cells("item_code").Value
        '    ProductAddUnitForm.cbBrand.SelectedIndex = ProductAddUnitForm.cbBrand.FindString(dgvMeasure.SelectedRows(0).Cells("brand").Value)
        '    ProductAddUnitForm.cbUnit.SelectedIndex = ProductAddUnitForm.cbUnit.FindString(dgvMeasure.SelectedRows(0).Cells("unit").Value)
        '    ProductAddUnitForm.cbColor.SelectedIndex = ProductAddUnitForm.cbColor.FindString(dgvMeasure.SelectedRows(0).Cells("color").Value)
        '    ProductAddUnitForm.txtPrice.Text = dgvMeasure.SelectedRows(0).Cells("price").Value
        '    ProductAddUnitForm.ShowDialog()
        'Else
        '    MsgBox("Please select unit of measurement!", MsgBoxStyle.Critical)
        'End If
    End Sub

    Private Sub dgvMeasure_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        '// **  remove column function ** //
        'If (e.RowIndex = dgvMeasure.NewRowIndex Or e.RowIndex < 0) Then
        '    Exit Sub
        'End If

        ''Check if click Is on specific column 
        'If (e.ColumnIndex = dgvMeasure.Columns("col_remove").Index) Then
        '    dgvMeasure.Rows.RemoveAt(e.RowIndex)
        'End If

        'If (e.ColumnIndex = dgvMeasure.Columns("unit").Index) Then
        '    MsgBox("Select Unit")
        'End If
    End Sub

    Private Sub txtProduct_MouseLeave(sender As Object, e As EventArgs) Handles txtProduct.MouseLeave
        If Trim(txtProduct.Text).Length > 0 Then
            txtProduct.Text = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtProduct.Text.ToLower)
        End If
    End Sub

    Private Function toFormatLetter(ByVal str As String)
        Dim res As String = ""
        res = Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str)
        Return res
    End Function

    Public Sub clearFields()
        txtBarcode.Clear()
        txtProduct.Clear()
        txtItemCode.Clear()


        selectedCategory = 0
        If cbCategory.Items.Count > 0 Then
            cbCategory.SelectedIndex = 0
        End If

        selectedSubcategory = 0
        If cbSubcategory.Items.Count > 0 Then
            cbSubcategory.SelectedIndex = 0
        End If

        selectedBrand = 0
        If cbBrand.Items.Count > 0 Then
            cbBrand.SelectedIndex = 0
        End If

        selectedColor = 0
        If cbColor.Items.Count > 0 Then
            cbColor.SelectedIndex = 0
        End If

        dgvMeasure2.Rows.Clear()
    End Sub

    Private Sub btnAddCategory_Click(sender As Object, e As EventArgs) Handles btnAddCategory.Click
        CategoryForm.from_module = 1
        CategoryForm.selectedParent = 0
        CategoryForm.txtName.Text = ""
        CategoryForm.cbParent.Enabled = False
        CategoryForm.cbParent.Text = ""
        CategoryForm.btnSave.Text = "Save"
        CategoryForm.ShowDialog()
    End Sub

    Private Sub btnSubCat_Click(sender As Object, e As EventArgs) Handles btnSubCat.Click
        'validation
        If selectedCategory <= 0 Then
            MsgBox("Please select Category before you add Sub Category", MsgBoxStyle.Critical)
            cbCategory.Focus()
            Exit Sub
        End If

        CategoryForm.selectedParent = selectedCategory
        CategoryForm.SelectedID = 0
        CategoryForm.populateCategory()
        CategoryForm.cbParent.SelectedIndex = CategoryForm.cbParent.FindString(cbCategory.Text)
        CategoryForm.txtName.Text = ""
        CategoryForm.cbParent.Enabled = False
        CategoryForm.btnSave.Text = "Save"
        CategoryForm.ShowDialog()
    End Sub


    Private Sub ProductForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'loadBrand()
        'loadColor()
        TabControl1.SelectedIndex = 0

    End Sub

    Public Sub loadBrand()
        cbBrand.DataSource = Nothing
        cbBrand.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Brand")
        Dim dbbrand As New DatabaseConnect
        With dbbrand
            .selectByQuery("Select id,name from brand where status = 1 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))

                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
            cbBrand.DataSource = New BindingSource(comboSource, Nothing)
            cbBrand.DisplayMember = "Value"
            cbBrand.ValueMember = "Key"
        End With
    End Sub

    Public Sub loadColor()

        cbColor.DataSource = Nothing
        cbColor.Items.Clear()
        Dim comboSourceUnit As New Dictionary(Of String, String)()
        comboSourceUnit.Add(0, "Select Color")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name from color where status = 1 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    comboSourceUnit.Add(.dr.GetValue(0), .dr.GetValue(1))
                End While
            End If
            cbColor.DataSource = New BindingSource(comboSourceUnit, Nothing)
            cbColor.DisplayMember = "Value"
            cbColor.ValueMember = "Key"
        End With
    End Sub

    Private Sub dgvMeasure2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMeasure2.CellContentClick
        'go to selecting unit on click
        If (e.ColumnIndex = dgvMeasure2.Columns("mUnit").Index) Then
            UnitSelection.from_module = 1
            UnitSelection.ShowDialog()
        End If

        '// **  remove column function ** //
        If (e.RowIndex = dgvMeasure2.NewRowIndex Or e.RowIndex < 0) Then
            Exit Sub
        End If

        'Check if click Is on specific column 
        If (e.ColumnIndex = dgvMeasure2.Columns("mAction").Index) Then
            dgvMeasure2.Rows.RemoveAt(e.RowIndex)
        End If

        If (e.ColumnIndex = dgvMeasure2.Columns("isdefault").Index) Then

            Dim row_index As Integer = e.RowIndex
            For Each row As DataGridViewRow In dgvMeasure2.Rows
                'If row.Cells("mUnit").Value <> "Select" And row.Cells("mPrice").Value <> "" Then
                row.Cells("isdefault").Value = False
                'End If
            Next
            'row.Cells("isdefault").Value = True

            dgvMeasure2.Rows(row_index).Cells(e.ColumnIndex).Value = True

        End If


    End Sub

    Private Sub dgvMeasure2_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvMeasure2.RowsAdded
        If dgvMeasure2.Rows.Count > 0 Then
            If dgvMeasure2.Rows(e.RowIndex).Cells(2).Value = "" Then
                dgvMeasure2.Rows(e.RowIndex).Cells(2).Value = "Select"
            End If

            dgvMeasure2.Rows(e.RowIndex).Cells(5).Value = "Remove"
        End If
    End Sub

    Private Sub btnAddColor_Click(sender As Object, e As EventArgs) Handles btnAddColor.Click
        ColorForm.selectedColor = 0
        ColorForm.ShowDialog()
    End Sub

    Private Sub cbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbColor.SelectedIndexChanged
        If cbColor.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedColor = key
        Else
            selectedColor = 0
        End If
    End Sub

    Private Sub btnAddBrand_Click(sender As Object, e As EventArgs) Handles btnAddBrand.Click
        BrandForm.selectedBrand = 0
        BrandForm.ShowDialog()
    End Sub

    Private Sub cbBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand.SelectedIndexChanged
        If cbBrand.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedBrand = key
        Else
            selectedBrand = 0
        End If
    End Sub

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        AddCostForm.ShowDialog()
    End Sub

    Private Sub dgvCost_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCost.CellContentClick
        'go to selecting unit on click
        If (e.ColumnIndex = dgvCost.Columns("Supplier").Index) Then

            SupplierSelection.ShowDialog()
        End If

        'go to selecting unit on click
        If (e.ColumnIndex = dgvCost.Columns("sUnit").Index) Then
            UnitSelection.from_module = 2
            UnitSelection.ShowDialog()
        End If


        '// **  remove column function ** //
        If (e.RowIndex = dgvCost.NewRowIndex Or e.RowIndex < 0) Then
            Exit Sub
        End If



        'Check if click Is on specific column 
        If (e.ColumnIndex = dgvCost.Columns("sAction").Index) Then
            dgvCost.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub dgvCost_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvCost.RowsAdded
        If dgvCost.Rows.Count > 0 Then
            If dgvCost.Rows(e.RowIndex).Cells(0).Value = "" Then
                dgvCost.Rows(e.RowIndex).Cells(0).Value = "Select"
            End If

            If dgvCost.Rows(e.RowIndex).Cells(1).Value = "" Then
                dgvCost.Rows(e.RowIndex).Cells(1).Value = "Select"
            End If

            dgvCost.Rows(e.RowIndex).Cells(3).Value = "Remove"
        End If
    End Sub

    Private Sub dgvSellPrice_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSellPrice.CellContentClick
        'go to selecting unit on click
        If (e.ColumnIndex = dgvSellPrice.Columns("spCustomer").Index) Then

            CustomerSelection.ShowDialog()
        End If

        'go to selecting unit on click
        If (e.ColumnIndex = dgvSellPrice.Columns("spUnit").Index) Then
            UnitSelection.from_module = 3
            UnitSelection.ShowDialog()
        End If


        '// **  remove column function ** //
        If (e.RowIndex = dgvSellPrice.NewRowIndex Or e.RowIndex < 0) Then
            Exit Sub
        End If



        'Check if click Is on specific column 
        If (e.ColumnIndex = dgvSellPrice.Columns("spAction").Index) Then
            dgvSellPrice.Rows.RemoveAt(e.RowIndex)
        End If
    End Sub

    Private Sub dgvSellPrice_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvSellPrice.RowsAdded
        If dgvSellPrice.Rows.Count > 0 Then
            If dgvSellPrice.Rows(e.RowIndex).Cells(0).Value = "" Then
                dgvSellPrice.Rows(e.RowIndex).Cells(0).Value = "Select"
            End If

            If dgvSellPrice.Rows(e.RowIndex).Cells(1).Value = "" Then
                dgvSellPrice.Rows(e.RowIndex).Cells(1).Value = "Select"
            End If

            dgvSellPrice.Rows(e.RowIndex).Cells(3).Value = "Remove"
        End If
    End Sub
End Class