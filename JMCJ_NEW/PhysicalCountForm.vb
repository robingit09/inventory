Public Class PhysicalCountForm

    Public selectedPC As Integer = 0
    Public selectedStockType As Integer = 1

    Public SelectedProdID As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedUnit As Integer = 0
    Private Sub btnSelectProduct_Click(sender As Object, e As EventArgs) Handles btnSelectProduct.Click
        SupplierProductSelection.module_selection = 5
        SupplierProductSelection.loadSupplierProducts(0, "")
        SupplierProductSelection.ShowDialog()
    End Sub

    Private Sub dgvProd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellContentClick
        'remove product
        If dgvProd.Rows(e.RowIndex).Cells(8).Value <> "" Then
            If e.ColumnIndex = 8 And dgvProd.Rows.Count > 1 Then
                dgvProd.Rows.RemoveAt(e.RowIndex)

            End If
        End If
    End Sub

    Public Sub initialize()
        txtPCNO.Text = generatePCNO()
        txtIssuedBy.Text = New DatabaseConnect().get_by_id("users", Main_form.current_user_id, "first_name") & " " & New DatabaseConnect().get_by_id("users", Main_form.current_user_id, "surname")
        dtp_r_date.Value = DateTime.Now
        loadStockType()
    End Sub

    Private Sub loadStockType()
        cbStockType.DataSource = Nothing
        cbStockType.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(1, "Stock Adjustment")
        comboSource.Add(2, "Stock Additional")
        cbStockType.DataSource = New BindingSource(comboSource, Nothing)
        cbStockType.DisplayMember = "Value"
        cbStockType.ValueMember = "Key"
    End Sub

    Private Function generatePCNO()
        Dim result As String = ""
        Try
            Dim db As New DatabaseConnect
            With db
                .selectByQuery("SELECT COUNT(id) from physical_count")
                If .dr.Read Then
                    Dim count_supplier As Integer = CInt(.dr.GetValue(0))
                    'result = "PO-" & getSupplierCode(selectedSupplier) & "-" & (count_supplier + 1).ToString("D6")
                    result = "PC-" & (count_supplier + 1).ToString("D6")
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

    Private Sub dgvProd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellValueChanged
        If dgvProd.Rows.Count > 1 Then
            'change if edit the actual_count
            If e.ColumnIndex = 6 And dgvProd.Rows(e.RowIndex).Cells("product").Value <> "" Then
                Dim actual_count As Integer = 0
                If IsNumeric(dgvProd.Rows(e.RowIndex).Cells("actual_count").Value.ToString().Replace(",", "")) Then
                    actual_count = CInt(dgvProd.Rows(e.RowIndex).Cells("actual_count").Value.ToString().Replace(",", ""))
                Else
                    actual_count = 0
                End If

                'change color
                If actual_count > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("actual_count").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("actual_count").Style.BackColor = Drawing.Color.Red
                End If
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
            PhysicalCount.loadList("")
            Me.Close()
        End If
    End Sub

    Private Function validation() As Boolean

        If Trim(txtIssuedBy.Text) = "" Then
            MsgBox("Issue By field is required!", MsgBoxStyle.Critical)
            txtIssuedBy.Focus()
            Return False
        End If

        If dgvProd.Rows.Count <= 1 Then
            MsgBox("Please add product!", MsgBoxStyle.Critical)
            dgvProd.Focus()
            Return False
        End If

        'actual count validation
        Dim validate As Boolean = False
        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim actual_count As String = dgvProd.Rows(item.Index).Cells("actual_count").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If prod <> "" Then
                If actual_count = "" Then
                    dgvProd.Rows(item.Index).Cells("actual_count").Style.BackColor = Drawing.Color.Red
                    validate = True
                End If

                If IsNumeric(actual_count) And Val(actual_count) <= 0 Then
                    dgvProd.Rows(item.Index).Cells("actual_count").Style.BackColor = Drawing.Color.Red
                    validate = True
                End If
            End If

        Next

        If validate = True Then
            Return False
        End If
        Return True
    End Function


    Private Sub insertData()
        Dim insertPC As New DatabaseConnect
        With insertPC
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO physical_count (pc_no,issued_by,user_id,recorded_date,stock_type,status,created_at,updated_at)
                VALUES(?,?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@pc_no", generatePCNO())
            .cmd.Parameters.AddWithValue("@issued_by", Trim(txtIssuedBy.Text))
            .cmd.Parameters.AddWithValue("@user_id", Main_form.current_user_id)
            .cmd.Parameters.AddWithValue("@recorded_date", dtp_r_date.Value.Date.ToString)
            .cmd.Parameters.AddWithValue("@stock_type", selectedStockType)
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
                Dim actual_count As String = dgvProd.Rows(item.Index).Cells("actual_count").Value
                Dim system_count As String = dgvProd.Rows(item.Index).Cells("system_count").Value


                If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("product").Value)) Then
                    .cmd.CommandText = "INSERT INTO physical_count_products(physical_count_id,product_unit_id,actual_count,system_count,created_at,updated_at)
                        VALUES(?,?,?,?,?,?)"

                    .cmd.Parameters.AddWithValue("@physical_count_id", getLastID("physical_count"))
                    .cmd.Parameters.AddWithValue("@product_unit_id", product_unit_id)
                    .cmd.Parameters.AddWithValue("@actual_count", actual_count)
                    .cmd.Parameters.AddWithValue("@system_count", system_count)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()

                    ' stock update
                    If selectedStockType = 1 Then
                        ModelFunction.adjuststock(product_unit_id, actual_count)
                    ElseIf selectedStockType = 2 Then
                        ModelFunction.update_stock(product_unit_id, actual_count, "+")
                    End If
                End If

            Next
            .cmd.Dispose()
            .con.Close()
        End With
        MsgBox("Physical Count Successfully Save.", MsgBoxStyle.Information)
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

    Public Sub clearFields()
        selectedPC = 0
        selectedStockType = 1
        txtPCNO.Text = ""
        txtIssuedBy.Text = ""
        dtp_r_date.Value = DateTime.Now
        dgvProd.Rows.Clear()
    End Sub

    Public Sub loadInfo(ByVal id As Integer)
        Me.selectedPC = id
        txtPCNO.Text = New DatabaseConnect().get_by_id("physical_count", id, "pc_no")
        Dim recorded_date As String = New DatabaseConnect().get_by_id("physical_count", id, "recorded_date")
        dtp_r_date.Value = recorded_date
        txtIssuedBy.Text = New DatabaseConnect().get_by_id("physical_count", id, "issued_by")
        Dim stock_type As Integer = CInt(New DatabaseConnect().get_by_id("physical_count", id, "stock_type"))
        If stock_type = 1 Then
            cbStockType.SelectedIndex = 0
        ElseIf stock_type = 2 Then
            cbStockType.SelectedIndex = 1
        End If

        Dim dbprod As New DatabaseConnect()
        dgvProd.Rows.Clear()
        With dbprod
            .selectByQuery("select distinct pu.id,pu.barcode,p.description,b.name as brand,u.name as unit,c.name as color,pop.actual_count,pop.system_count
                        FROM ((((((physical_count_products as pop
                        INNER JOIN product_unit as pu ON pu.id = pop.product_unit_id)
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = pu.unit)
                        LEFT JOIN color as c ON c.id = pu.color)
                        INNER JOIN products as p ON p.id = pu.product_id)
                        LEFT join product_stocks as ps on ps.product_unit_id = pu.id)
                        where pop.physical_count_id = " & id)
            If .dr.HasRows Then
                While .dr.Read
                    Dim p_u_id As Integer = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim actual_count As String = .dr("actual_count")
                    Dim system_count As String = .dr("system_count")
                    Dim row As String() = New String() {p_u_id, barcode, desc, brand, unit, color, actual_count, system_count, "Remove"}
                    dgvProd.Rows.Add(row)
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Public Sub freeView(ByVal flag As Boolean)

        If flag = True Then
            txtPCNO.Enabled = False
            txtIssuedBy.Enabled = False
            dtp_r_date.Enabled = False
            gpEnterBarcode.Enabled = False
            gpEnterProduct.Enabled = False
            dgvProd.Enabled = False

            btnSelectProduct.Enabled = False
            btnSave.Enabled = False

            cbStockType.Enabled = False
        Else
            txtPCNO.Enabled = True
            txtIssuedBy.Enabled = True
            dtp_r_date.Enabled = True
            gpEnterBarcode.Enabled = True
            gpEnterProduct.Enabled = True
            dgvProd.Enabled = True

            btnSelectProduct.Enabled = True
            btnSave.Enabled = True

            cbStockType.Enabled = True
        End If

    End Sub

    Private Sub cbStockType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStockType.SelectedIndexChanged
        If cbStockType.SelectedIndex > -1 Then
            Dim key As String = DirectCast(cbStockType.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbStockType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedStockType = key
        End If
    End Sub

    Private Sub PhysicalCountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
                        .selectByQuery("Select unit_cost from product_suppliers where product_unit_id = " & product_unit_id)
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

                    Dim row As String() = New String() {product_unit_id, barcode, desc, brand, unit, color, "", stock, "Remove"}
                    dgvProd.Rows.Add(row)
                    'computeTotalAmount()

                End If
            Else
                MsgBox("No Product Found!", MsgBoxStyle.Critical)
            End If
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

                        Dim stock As Integer = Val(.dr("stock"))
                        Dim row As String() = New String() {id, barcode, desc, brand, unit, color, "", stock, "Remove"}
                        dgvProd.Rows.Add(row)
                        txtEnterBarcode.Text = ""
                        txtEnterBarcode.Focus()
                    End If

                    .dr.Close()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If

        End If
    End Sub
End Class
