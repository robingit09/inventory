Public Class PurchaseOrderRequestForm
    Public selectedID As Integer = 0
    Public selectedSupplier As Integer = 0

    Public SelectedProdID As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedUnit As Integer = 0
    Public Sub initialize()
        loadSupplier()
        autocompleteProduct()
        populateBrand(0)
        populateUnit(0, 0)
        populateColor(0, 0, 0)
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

    Private Sub PurchaseOrderRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Function generatePORNo() As String
        Dim result As String = ""
        Try
            Dim db As New DatabaseConnect
            With db
                .selectByQuery("SELECT COUNT(id) from purchase_orders_request where supplier = " & selectedSupplier)
                If .dr.Read Then
                    Dim count_supplier As Integer = CInt(.dr.GetValue(0))
                    result = "POR-" & getSupplierCode(selectedSupplier) & "-" & (count_supplier + 1).ToString("D6")
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

    Private Function getSupplierCode(ByVal sup_id As Integer) As String
        Dim code As String = ""
        Dim db As New DatabaseConnect
        With db
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "SELECT supplier_code from suppliers where id = " & sup_id & " and status <> 0"
            .dr = .cmd.ExecuteReader

            If .dr.Read Then
                code = .dr.GetValue(0)
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()

        End With

        Return code
    End Function

    Private Sub cbSupplier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSupplier.SelectedIndexChanged
        If cbSupplier.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Value
            Me.selectedSupplier = key
            cbSupplier.BackColor = Drawing.Color.White
            txtPORNo.Text = generatePORNo()

            gpEnterBarcode.Enabled = True
            gpEnterProduct.Enabled = True
            dgvProd.Enabled = True

        Else
            selectedSupplier = 0
            cbSupplier.SelectedIndex = 0
            txtPORNo.Text = ""
            gpEnterBarcode.Enabled = False
            gpEnterProduct.Enabled = False
            dgvProd.Enabled = False
        End If
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
                        Dim row As String() = New String() {id, barcode, "", desc, brand, unit, color, cost, "", stock, "Remove"}
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
                If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("amount").Value)) Then
                    Dim amount As Double = dgvProd.Rows(item.Index).Cells("amount").Value
                    totalamount += amount
                End If
            Next
        End If
        txtAmount.Text = totalamount.ToString("N2")
    End Sub

    Private Sub dgvProd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellContentClick
        'remove product
        If e.ColumnIndex = 10 And dgvProd.Rows.Count > 1 Then
            dgvProd.Rows.RemoveAt(e.RowIndex)
            computeTotalAmount()
        End If
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

            If e.ColumnIndex = 7 Then
                Dim amount As Double = 0
                Dim qty As Integer = 0
                If IsNumeric(dgvProd.Rows(e.RowIndex).Cells("quantity").Value) Then
                    qty = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Else
                    qty = 0
                End If

                Dim cost As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("cost").Value.ToString.Replace(",", ""))
                If IsNumeric(dgvProd.Rows(e.RowIndex).Cells("cost").Value) Then
                    cost = CDbl(dgvProd.Rows(e.RowIndex).Cells("cost").Value.ToString.Replace(",", ""))
                Else
                    cost = 0
                End If

                amount = qty * CDbl(cost)
                dgvProd.Rows(e.RowIndex).Cells("amount").Value = Val(amount).ToString("N2")


                'change color
                If cost > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("cost").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("cost").Style.BackColor = Drawing.Color.Red
                End If
            End If
            computeTotalAmount()
        End If
    End Sub

    Private Sub insertData()
        Dim insertPO As New DatabaseConnect
        With insertPO
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO purchase_orders_request (por_no,supplier,por_date,total_amount,processed_by,status,created_at,updated_at)
                VALUES(?,?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@por_no", generatePORNo())
            .cmd.Parameters.AddWithValue("@supplier", selectedSupplier)
            .cmd.Parameters.AddWithValue("@por_date", dtp_por_date.Value.ToString)
            .cmd.Parameters.AddWithValue("@total_amount", Val(txtAmount.Text.Replace(",", "")))
            .cmd.Parameters.AddWithValue("@processed_by", 1)
            .cmd.Parameters.AddWithValue("@status", 1)
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
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
                Dim qty As String = dgvProd.Rows(item.Index).Cells("quantity").Value
                Dim cost As String = dgvProd.Rows(item.Index).Cells("cost").Value
                Dim amount As String = dgvProd.Rows(item.Index).Cells("amount").Value

                If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("product").Value)) Then
                    .cmd.CommandText = "INSERT INTO por_products(por_id,product_unit_id,quantity,unit_cost,total_amount,created_at,updated_at)
                        VALUES(?,?,?,?,?,?,?)"

                    .cmd.Parameters.AddWithValue("@por_id", getLastID("purchase_orders_request"))
                    .cmd.Parameters.AddWithValue("@product_unit_id", product_unit_id)
                    .cmd.Parameters.AddWithValue("@quantity", qty)
                    .cmd.Parameters.AddWithValue("@unit_cost", cost)
                    .cmd.Parameters.AddWithValue("@amount", amount)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()
                End If

            Next
            .cmd.Dispose()
            .con.Close()
        End With
        MsgBox("Purchase Order Request Successfully Save.", MsgBoxStyle.Information)
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

    Private Function validation() As Boolean

        If cbSupplier.SelectedIndex = 0 Then
            MsgBox("Supplier field is required!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Return False
        End If

        If dgvProd.Rows.Count = 1 Then
            MsgBox("Please add product!", MsgBoxStyle.Critical)
            dgvProd.Focus()
            Return False
        End If

        'qty validation
        Dim validate As Boolean = False
        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim qty As String = dgvProd.Rows(item.Index).Cells("quantity").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If prod <> "" Then
                If qty = "" Then
                    dgvProd.Rows(item.Index).Cells("quantity").Style.BackColor = Drawing.Color.Red
                    validate = True
                End If

                If IsNumeric(qty) And Val(qty) <= 0 Then
                    dgvProd.Rows(item.Index).Cells("quantity").Style.BackColor = Drawing.Color.Red
                    validate = True
                End If
            End If

        Next

        If validate = True Then
            Return False
        End If
        Return True
    End Function

    Public Sub clearFields()
        cbSupplier.SelectedIndex = cbSupplier.FindString("Select Supplier")
        selectedSupplier = 0
        txtPORNo.Text = ""
        dtp_por_date.Value = DateTime.Now
        txtAmount.Text = "0.00"
        dgvProd.Rows.Clear()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            If validation() = False Then
                Exit Sub
            End If
            insertData()
            clearFields()
            PurchaseOrderRequest.loadPOR("")
            PurchaseOrderRequest.loadPORSelection()
            PurchaseOrderRequest.getYear()
        Else

        End If
    End Sub

    Public Sub loadInfo(ByVal por_id As Integer)

        Me.selectedID = por_id
        Me.selectedSupplier = getSupplier(por_id)
        'MsgBox(Me.selectedSupplier)
        txtPORNo.Text = New DatabaseConnect().get_by_id("purchase_orders_request", por_id, "po_no")
        'MsgBox(New DatabaseConnect().get_by_id("suppliers", Me.selectedSupplier, "supplier_name"))
        cbSupplier.SelectedIndex = cbSupplier.FindString(New DatabaseConnect().get_by_id("suppliers", Me.selectedSupplier, "supplier_name"))

        Dim por_date As String = New DatabaseConnect().get_by_id("purchase_orders_request", Me.selectedID, "por_date")
        dtp_por_date.Value = por_date


        txtAmount.Text = Val(New DatabaseConnect().get_by_id("purchase_orders_request", Me.selectedID, "total_amount")).ToString("N2")

        Dim dbprod As New DatabaseConnect()
        dgvProd.Rows.Clear()
        With dbprod
            .selectByQuery("select distinct pu.id,pu.barcode,p.description,b.name as brand,u.name as unit,c.name as color,pop.quantity,pop.unit_cost,pop.total_amount,ps.qty as stock
                        FROM ((((((por_products as pop
                        INNER JOIN product_unit as pu ON pu.id = pop.product_unit_id)
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = pu.unit)
                        LEFT JOIN color as c ON c.id = pu.color)
                        INNER JOIN products as p ON p.id = pu.product_id)
                        left join product_stocks as ps on ps.product_unit_id = pu.id)
                        where pop.por_id = " & selectedID)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim qty As Integer = .dr("quantity")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim cost As String = Val(.dr("unit_cost")).ToString("N2")
                    Dim total As String = Val(.dr("total_amount")).ToString("N2")
                    Dim stock As String = Val(.dr("stock"))
                    Dim row As String() = New String() {id, barcode, qty, desc, brand, unit, color, cost, total, stock, "Remove"}
                    dgvProd.Rows.Add(row)
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Function getSupplier(ByVal por_id As Integer) As Integer
        Dim res As Integer = 0
        Dim dbpo As New DatabaseConnect
        With dbpo
            .selectByQuery("Select supplier from purchase_orders_request where id = " & por_id)
            If .dr.Read Then
                res = CInt(.dr("supplier"))
            End If
        End With
        Return res
    End Function

    Private Sub btnSelectProduct_Click(sender As Object, e As EventArgs) Handles btnSelectProduct.Click
        If selectedSupplier = 0 Then
            MsgBox("Please select supplier!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Exit Sub
        End If
        SupplierProductSelection.module_selection = 4
        SupplierProductSelection.loadSupplierProducts(Me.selectedSupplier)
        SupplierProductSelection.txtSupplier.Text = New DatabaseConnect().get_by_id("suppliers", Me.selectedSupplier, "supplier_name")
        SupplierProductSelection.ShowDialog()
    End Sub

    Private Sub btnCreatePO_Click(sender As Object, e As EventArgs) Handles btnCreatePO.Click
        If selectedID > 0 Then
            PurchaseOrderForm.clearFields()
            PurchaseOrderForm.initialize()
            PurchaseOrderForm.createPO(selectedID)
            PurchaseOrderForm.dgvProd.Visible = True
            PurchaseOrderForm.ShowDialog()
        End If

    End Sub

    Private Sub btnAddSupplier_Click(sender As Object, e As EventArgs) Handles btnAddSupplier.Click
        SupplierForm.loadstatus()
        SupplierForm.SelectedSupplier = 0
        SupplierForm.clearFields()
        SupplierForm.btnSave.Text = "Save"
        SupplierForm.from_module = 4
        SupplierForm.ShowDialog()
    End Sub
End Class