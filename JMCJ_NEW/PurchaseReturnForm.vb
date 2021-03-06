﻿Public Class PurchaseReturnForm

    Public selectedID As Integer = 0
    Public selectedSupplier As Integer = 0
    Public SelectedProdID As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedUnit As Integer = 0

    Public Sub clearFields()

        If cbSupplier.Items.Count > 0 Then
            selectedSupplier = 0
            cbSupplier.SelectedIndex = 0
            gpEnterBarcode.Enabled = False
            gpEnterProduct.Enabled = False
            dgvProd.Enabled = False
        End If

        dgvProd.Rows.Clear()
        txtEnterBarcode.Clear()
        txtProductDesc.Clear()

        If cbBrand.Items.Count > 0 Then
            cbBrand.SelectedIndex = 0
            selectedBrand = 0
        End If

        If cbUnit.Items.Count > 0 Then
            cbUnit.SelectedIndex = 0
            selectedUnit = 0
        End If

        If cbColor.Items.Count > 0 Then
            cbColor.SelectedIndex = 0
            selectedColor = 0
        End If

    End Sub

    Public Sub loadSupplier()
        cbSupplier.DataSource = Nothing
        cbSupplier.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,supplier_name from suppliers where status <> 0 order by supplier_name")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Supplier")

            While .dr.Read
                Dim id As Integer = CInt(.dr.GetValue(0))
                Dim sup As String = .dr.GetValue(1)
                comboSource.Add(id, sup)
            End While

            cbSupplier.DataSource = New BindingSource(comboSource, Nothing)
            cbSupplier.DisplayMember = "Value"
            cbSupplier.ValueMember = "Key"

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub txtEnterBarcode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEnterBarcode.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Trim(txtEnterBarcode.Text).Length > 0 Then
                'validation
                ' check if already in list
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
                    .selectByQuery("Select distinct pu.id, pu.barcode, p.description, b.name As brand, u.name As unit, cc.name As color,ps.qty as stock, c.name As cat,sub.name as subcat FROM (((((((((products as p 
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
                        Dim id As String = .dr("id")
                        Dim barcode As String = .dr("barcode")
                        Dim desc As String = .dr("description")
                        Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                        Dim unit As String = .dr("unit")
                        Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                        Dim cost As String = Val(getCost(selectedSupplier, id)).ToString("N2")
                        Dim stock As Integer = Val(.dr("stock"))
                        Dim row As String() = New String() {id, barcode, "", desc, brand, unit, color, cost, "0.00", stock, "Remove"}
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

    Public Sub initialize()
        loadSupplier()
        autocompleteProduct()
        populateBrand(0)
        populateUnit(0, 0)
        populateColor(0, 0, 0)
        clearFields()
        txtPRNo.Text = generatePRNo()
        txtIssueBy.Text = New DatabaseConnect().get_by_id("users", 1, "first_name") & " " & New DatabaseConnect().get_by_id("users", 1, "surname")
    End Sub

    Private Sub cbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupplier.SelectedIndexChanged
        If cbSupplier.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Value
            Me.selectedSupplier = key
            cbSupplier.BackColor = Drawing.Color.White
            gpEnterBarcode.Enabled = True
            gpEnterProduct.Enabled = True
            dgvProd.Enabled = True
            cbSupplier.BackColor = Drawing.Color.White

        Else
            selectedSupplier = 0
            cbSupplier.SelectedIndex = 0
            gpEnterBarcode.Enabled = False
            gpEnterProduct.Enabled = False
            dgvProd.Enabled = False
        End If
    End Sub

    Private Function getCost(ByVal supplier As Integer, ByVal p_u_id As Integer) As Double
        Dim result As Double = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("select unit_cost from product_suppliers where supplier = " & supplier & " and product_unit_id = " & p_u_id)
            If .dr.Read Then
                result = CDbl(Val(.dr("unit_cost")).ToString("N2"))
            End If
        End With
        Return result
    End Function

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
            SelectedBrand = 0
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
        If selectedSupplier = 0 Then
            MsgBox("Please select supplier!", MsgBoxStyle.Critical)
            'cbSupplier.BackColor = Drawing.Color.Red
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
            .selectByQuery("SELECT pu.barcode,pu.id,p.description,b.name as brand, u.name as unit,cc.name as color, ps.qty as stock from (((((products as p 
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
                    Dim unitcost As String = "0.00"
                    'Dim sellprice As String = unitprice
                    'get sell price

                    Dim dbcost As New DatabaseConnect
                    With dbcost
                        .selectByQuery("Select unit_cost from product_suppliers where product_unit_id = " & product_unit_id & " and supplier = " & selectedSupplier)
                        If .dr.HasRows Then
                            If .dr.Read Then
                                If (Val(.dr("unit_cost") > 0)) Then
                                    unitcost = Val(.dr("unit_cost")).ToString("N2")
                                Else
                                    unitcost = "0.00"
                                End If
                            End If
                        End If
                        .con.Close()
                        .dr.Close()
                        .cmd.Dispose()
                    End With

                    Dim stock As String = If(IsDBNull(.dr("stock")), "0", .dr("stock"))

                    Dim row As String() = New String() {product_unit_id, barcode, "0", desc, brand, unit, color, unitcost, "0.00", stock, "Remove"}
                    dgvProd.Rows.Add(row)
                    computeTotalAmount()

                End If
            Else
                MsgBox("No Product Found!", MsgBoxStyle.Critical)
            End If
        End With
    End Sub

    Public Sub computeTotalAmount()
        Dim totalamount As Double = 0.0
        If dgvProd.Rows.Count > 1 Then
            For Each item As DataGridViewRow In Me.dgvProd.Rows
                Dim amount As Double = dgvProd.Rows(item.Index).Cells("amount").Value
                totalamount += amount
            Next
        End If
        'lblTotalAmount.Text = totalamount.ToString("N2")
        txtTotalAmount.Text = totalamount.ToString("N2")
    End Sub

    Private Sub dgvProd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellValueChanged
        If dgvProd.Rows.Count > 1 Then
            'change if edit the qty
            If e.ColumnIndex = 2 Then
                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("cost").Value.ToString.Replace(",", ""))

                amount = qty * CDbl(price)
                dgvProd.Rows(e.RowIndex).Cells("amount").Value = Val(amount).ToString("N2")


                'change color
                If qty > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Drawing.Color.Red
                End If
            End If

            'change unit cost
            If e.ColumnIndex = 7 Then
                Dim cost As Double = 0
                Dim amount As Double = 0
                Dim qty As Integer = 0

                If Not IsNumeric(dgvProd.Rows(e.RowIndex).Cells("quantity").Value) Then
                    qty = 0
                Else
                    qty = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                End If

                If Not IsNumeric(dgvProd.Rows(e.RowIndex).Cells("cost").Value) Then
                    cost = 0
                Else
                    cost = CDbl(dgvProd.Rows(e.RowIndex).Cells("cost").Value.ToString.Replace(",", ""))
                End If

                amount = qty * CDbl(cost)
                dgvProd.Rows(e.RowIndex).Cells("amount").Value = Val(amount).ToString("N2")


                'change color
                If cost > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("cost").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("cost").Style.BackColor = Drawing.Color.White
                End If
            End If
            computeTotalAmount()
        End If
    End Sub

    Private Sub cbReason_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbReason.SelectedIndexChanged
        If cbReason.Text = "Other" Then
            txtReason.Enabled = True
            txtReason.Focus()
        Else
            txtReason.Clear()
            txtReason.Enabled = False
        End If
        cbReason.BackColor = Drawing.Color.White
        txtReason.BackColor = Drawing.Color.White
    End Sub

    Private Sub dgvProd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellContentClick
        'remove product
        If e.ColumnIndex = 10 And dgvProd.Rows.Count > 1 Then
            dgvProd.Rows.RemoveAt(e.RowIndex)
            computeTotalAmount()
        End If

        'go to selecting unit 
        If (e.ColumnIndex = dgvProd.Columns("unit").Index) Then

            ' check if has description
            If (dgvProd.Rows(e.RowIndex).Cells(3).Value <> "") Then
                UnitSelection.from_module = 12

                Dim prod_id As String = dgvProd.Rows(e.RowIndex).Cells(0).Value
                UnitSelection.prod_id = CInt(prod_id)
                UnitSelection.supplier_id = selectedSupplier

                UnitSelection.ShowDialog()
            End If


        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If validation() = False Then
                Exit Sub
            End If

            insertData()
            clearFields()
        Else

        End If
    End Sub

    Private Sub insertData()
        Dim insertPR As New DatabaseConnect
        With insertPR
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO purchase_return (pr_no,supplier_id,pr_date,total_amount,issued_by,reason,created_at,updated_at,status)
                VALUES(?,?,?,?,?,?,?,?,?)"

            .cmd.Parameters.AddWithValue("@pr_no", generatePRNo())
            .cmd.Parameters.AddWithValue("@supplier_id", selectedSupplier)
            .cmd.Parameters.AddWithValue("@pr_date", dtpRecorded.Value.ToString)
            .cmd.Parameters.AddWithValue("@total_amount", txtTotalAmount.Text)
            .cmd.Parameters.AddWithValue("@issued_by", 1)
            If txtReason.Enabled = True Then
                .cmd.Parameters.AddWithValue("@reason", txtReason.Text)
            Else
                .cmd.Parameters.AddWithValue("@reason", cbReason.Text)
            End If
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@status", 1)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

        End With

        Dim insertProduct As New DatabaseConnect
        With insertProduct
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text

            For Each item As DataGridViewRow In Me.dgvProd.Rows

                Dim product_unit_id As String = dgvProd.Rows(item.Index).Cells("id").Value
                Dim unit_id As String = New DatabaseConnect().get_id("unit", "name", dgvProd.Rows(item.Index).Cells("unit").Value)
                Dim qty As String = dgvProd.Rows(item.Index).Cells("quantity").Value
                Dim cost As String = dgvProd.Rows(item.Index).Cells("cost").Value
                Dim total_amount As String = dgvProd.Rows(item.Index).Cells("amount").Value


                If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("product").Value)) Then
                    .cmd.CommandText = "INSERT INTO purchase_return_products(purchase_return_id,product_unit_id,unit_id,unit_cost,qty,total_cost,created_at,updated_at)
                        VALUES(?,?,?,?,?,?,?,?)"

                    .cmd.Parameters.AddWithValue("@purchase_return_id", getLastID("purchase_return"))
                    .cmd.Parameters.AddWithValue("@product_unit_id", product_unit_id)
                    .cmd.Parameters.AddWithValue("@unit_id", unit_id)
                    .cmd.Parameters.AddWithValue("@unit_cost", cost)
                    .cmd.Parameters.AddWithValue("@qty", qty)
                    .cmd.Parameters.AddWithValue("@total_cost", total_amount)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()
                    ModelFunction.update_stock(product_unit_id, qty, "-")
                End If

            Next
            .cmd.Dispose()
            .con.Close()
        End With

        MsgBox("Purchase Return Successfully Save.", MsgBoxStyle.Information)
        PurchaseReturn.loadList("")
    End Sub

    Private Function getLastID(ByVal table As String) As Integer
        Dim id As Integer = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT MAX(ID) from " & table)
            If .dr.HasRows Then
                .dr.Read()
                id = If(IsDBNull(.dr.GetValue(0)), 1, .dr.GetValue(0))
            Else
                id = 1
            End If
        End With
        Return id
    End Function

    Private Function generatePRNo() As String
        Dim result As String = ""
        Try
            Dim db As New DatabaseConnect
            With db
                .selectByQuery("SELECT COUNT(id) from purchase_return")
                If .dr.Read Then
                    Dim count_supplier As Integer = CInt(.dr.GetValue(0))
                    result = "PRP-" & (count_supplier + 1).ToString("D7")
                End If

                .dr.Close()
                .cmd.Dispose()
                .con.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return result
    End Function

    Private Function validation() As Boolean

        If cbSupplier.SelectedIndex = 0 Then
            MsgBox("Supplier field is required!", MsgBoxStyle.Critical)
            cbSupplier.BackColor = Drawing.Color.OrangeRed
            cbSupplier.Focus()
            Return False
        End If

        If cbReason.Text <> "Other" Then
            If Trim(cbReason.Text) = "Select" Or Trim(cbReason.Text) = "" Then
                MsgBox("Reason field is required!", MsgBoxStyle.Critical)
                cbReason.BackColor = Drawing.Color.OrangeRed
                cbReason.Focus()
                Return False
            End If
        Else
            If Trim(txtReason.Text) = "" Then
                MsgBox("Reason field is required!.", MsgBoxStyle.Critical)
                txtReason.BackColor = Drawing.Color.OrangeRed
                txtReason.Focus()
                Return False
            End If
        End If

        If dgvProd.Rows.Count = 1 Then
            MsgBox("Please add product!", MsgBoxStyle.Critical)
            dgvProd.Focus()
            Return False
        End If

        'qty and cost validation
        Dim validate As Boolean = False
        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim qty As String = dgvProd.Rows(item.Index).Cells("quantity").Value
            Dim cost As String = dgvProd.Rows(item.Index).Cells("cost").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If prod <> "" Then
                If qty = "" Then
                    dgvProd.Rows(item.Index).Cells("quantity").Style.BackColor = Drawing.Color.OrangeRed
                    validate = True
                End If

                If IsNumeric(qty) And Val(qty) <= 0 Then
                    dgvProd.Rows(item.Index).Cells("quantity").Style.BackColor = Drawing.Color.OrangeRed
                    validate = True
                End If

                If cost = "" Then
                    dgvProd.Rows(item.Index).Cells("cost").Style.BackColor = Drawing.Color.OrangeRed
                    validate = True
                End If

                If Val(cost) <= 0 Then
                    dgvProd.Rows(item.Index).Cells("cost").Style.BackColor = Drawing.Color.OrangeRed
                    validate = True
                End If

            End If
        Next

        If validate = True Then
            MsgBox("Please check all product information!", MsgBoxStyle.Critical)
            Return False
        End If
        Return True
    End Function

    Private Sub txtReason_TextChanged(sensder As Object, e As EventArgs) Handles txtReason.TextChanged
        If txtReason.TextLength > 0 Then
            cbReason.BackColor = Drawing.Color.White
            txtReason.BackColor = Drawing.Color.White
        End If
    End Sub

    Public Sub enableControl(ByVal flag As Boolean)
        gpField.Enabled = flag
        gpEnterBarcode.Enabled = flag
        gpEnterProduct.Enabled = flag
        dgvProd.Enabled = flag
    End Sub

    Public Sub toLoadInfo(ByVal id As Integer)
        selectedID = id
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("select * from purchase_return where id = " & id)
            If .dr.Read Then
                selectedSupplier = .dr("supplier_id")
                Dim supplier As String = New DatabaseConnect().get_by_id("suppliers", selectedSupplier, "supplier_name")
                cbSupplier.SelectedIndex = cbSupplier.FindString(supplier)

                txtPRNo.Text = .dr("pr_no")

                Dim issue_by As String = .dr("issued_by")
                txtIssueBy.Text = New DatabaseConnect().get_by_id("users", issue_by, "first_name") & " " & New DatabaseConnect().get_by_id("users", issue_by, "surname")

                Dim reason As String = .dr("reason")
                cbReason.SelectedIndex = cbReason.FindString(reason)
                If cbReason.Text = "Select" Then
                    txtReason.Text = reason
                    cbReason.Text = "Other"
                End If

                dtpRecorded.Value = .dr("pr_date")
                txtTotalAmount.Text = Val(.dr("total_amount")).ToString("N2")

            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With

        'loadProduct
        Dim dbprod As New DatabaseConnect
        With dbprod

            .selectByQuery("select distinct pu.id,pu.barcode,p.description,b.name as brand,u.name as unit,c.name as color,prp.qty as quantity,prp.unit_cost,prp.total_cost,ps.qty as stock
                        FROM ((((((purchase_return_products as prp
                        INNER JOIN product_unit as pu ON pu.id = prp.product_unit_id)
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = prp.unit_id)
                        LEFT JOIN color as c ON c.id = pu.color)
                        INNER JOIN products as p ON p.id = pu.product_id)
                        left join product_stocks as ps on ps.product_unit_id = pu.id)
                        where prp.purchase_return_id = " & id)
            If .dr.HasRows Then
                While .dr.Read
                    Dim p_u_id As Integer = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim qty As Integer = .dr("quantity")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim cost As String = Val(.dr("unit_cost")).ToString("N2")
                    Dim total As String = Val(.dr("total_cost")).ToString("N2")
                    Dim stock As String = Val(.dr("stock"))
                    Dim row As String() = New String() {id, barcode, qty, desc, brand, unit, color, cost, total, stock, "Remove"}
                    dgvProd.Rows.Add(row)
                End While
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End If
        End With

    End Sub

    Private Sub btnSelectProduct_Click(sender As Object, e As EventArgs) Handles btnSelectProduct.Click
        If selectedSupplier = 0 Then
            MsgBox("Please select supplier!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Exit Sub
        End If
        SupplierProductSelection.module_selection = 3
        SupplierProductSelection.loadSupplierProducts(Me.selectedSupplier, "")
        SupplierProductSelection.txtSupplier.Text = New DatabaseConnect().get_by_id("suppliers", Me.selectedSupplier, "supplier_name")
        SupplierProductSelection.ShowDialog()
    End Sub
End Class