Public Class ProductList

    Public selectedDesc As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedUnit As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedCat As Integer = 0
    Public selectedSubCat As Integer = 0

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProductForm.ShowDialog()
    End Sub

    Private Sub ProductList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'loadDesc()
        autocompleteDesc()
        loadBrand()
        loadUnit()
        loadColor()
        loadCat()
        loadSubCat()
        loadList("")
        getTotalQty()

        'check user access
        If ModelFunction.check_access(1, 1) = 1 Then
            btnAdd.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        Else
            btnAdd.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        End If

    End Sub


    Public Sub autocompleteDesc()
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

    Public Sub loadBrand()
        cbBrand.DataSource = Nothing
        cbBrand.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from brand where status <> 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
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

    Public Sub loadUnit()
        cbUnit.DataSource = Nothing
        cbUnit.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from unit where status <> 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
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

    Public Sub loadColor()
        cbColor.DataSource = Nothing
        cbColor.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from color where status <> 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
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

    Public Sub loadCat()
        cbCat.DataSource = Nothing
        cbCat.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from categories where status <> 0 and parent_id = 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbCat.DataSource = New BindingSource(comboSource, Nothing)
            cbCat.DisplayMember = "Value"
            cbCat.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub loadSubCat()
        cbSubCat.DataSource = Nothing
        cbSubCat.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "All")
        Dim dbdesc As New DatabaseConnect
        With dbdesc
            .selectByQuery("Select id,name from  categories where status <> 0 and parent_id > 0 order by name")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbSubCat.DataSource = New BindingSource(comboSource, Nothing)
            cbSubCat.DisplayMember = "Value"
            cbSubCat.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub loadList(ByVal q As String)
        Dim db As New DatabaseConnect
        With db
            dgvProducts.Rows.Clear()
            If q = "" Then
                .selectByQuery("Select distinct p.id,pu.id as p_u_id,pu.barcode,pu.item_code, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 order by p.id desc")
            Else
                .selectByQuery(q)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim p_u_id As String = .dr("p_u_id")
                    Dim barcode As String = .dr("barcode")
                    Dim itemcode As String = If(IsDBNull(.dr("item_code")), "", .dr("item_code"))
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")

                    Dim stock As String = ""
                    Try
                        Dim dbstock As New DatabaseConnect
                        With dbstock
                            .selectByQuery("select qty from product_stocks where product_unit_id = " & p_u_id)
                            If .dr.Read Then
                                stock = Val(.dr("qty")).ToString
                            Else
                                stock = ""
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    Catch ex As Exception
                        stock = ""
                    End Try

                    Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat"))
                    Dim row As String() = New String() {p_u_id, barcode, itemcode, desc, brand, unit, color, price, stock, cat, subcat}
                    dgvProducts.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ProductForm.btnSave.Text = "Save"
        'ProductForm.initializeMeasure()

        ProductForm.selectedProduct = 0
        ProductForm.loadBrand()
        ProductForm.loadColor()
        ProductForm.populateCategory()
        ProductForm.populateSubcategory(0)
        ProductForm.clearFields()
        ProductForm.ShowDialog()

    End Sub

    Private Sub dgvProducts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellValueChanged

        If dgvProducts.Rows.Count > 1 Then
            Dim product_id As String = dgvProducts.Rows(e.RowIndex).Cells(0).Value
            If e.ColumnIndex = 3 Then
                Dim brand As String = If(dgvProducts.Rows(e.RowIndex).Cells(3).Value = "", "0", dgvProducts.Rows(e.RowIndex).Cells(3).Value)
                Dim unit As String = If(dgvProducts.Rows(e.RowIndex).Cells(4).Value = "", "0", dgvProducts.Rows(e.RowIndex).Cells(4).Value)

                Dim dbPrice As New DatabaseConnect
                With dbPrice
                    .selectByQuery("Select price from product_unit where product_id = " & product_id & " and brand =" & brand & " and unit = " & unit)
                    If .dr.HasRows Then
                        If .dr.Read Then
                            dgvProducts.Rows(e.RowIndex).Cells(5).Value = .dr.GetValue(0)
                        End If
                    End If
                    .dr.Close()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If

            If e.ColumnIndex = 4 Then
                Dim brand As String = If(dgvProducts.Rows(e.RowIndex).Cells(3).Value = "", "0", dgvProducts.Rows(e.RowIndex).Cells(3).Value)
                Dim unit As String = If(dgvProducts.Rows(e.RowIndex).Cells(4).Value = "", "0", dgvProducts.Rows(e.RowIndex).Cells(4).Value)

                Dim dbPrice As New DatabaseConnect
                With dbPrice
                    .selectByQuery("Select price from product_unit where product_id = " & product_id & " and brand =" & brand & " and unit = " & unit)

                    If .dr.HasRows Then
                        If .dr.Read Then
                            dgvProducts.Rows(e.RowIndex).Cells(5).Value = .dr.GetValue(0)
                        End If
                    End If

                    .dr.Close()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If
        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvProducts.SelectedRows.Count = 1 Then
            Dim p_u_id As Integer = CInt(dgvProducts.SelectedRows(0).Cells(0).Value)

            Dim product_id As Integer = CInt(New DatabaseConnect().get_by_id("product_unit", p_u_id, "product_id"))
            'MsgBox(product_id)
            ProductForm.selectedProduct = product_id
            ProductForm.btnSave.Text = "Update"
            ProductForm.loadColor()
            ProductForm.loadBrand()
            ProductForm.populateCategory()
            ProductForm.populateSubcategory(0)
            ProductForm.toUpdateInfo(product_id)
            ProductForm.ShowDialog()
        Else
            ProductForm.selectedProduct = 0
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim query As String = "Select distinct p.id,pu.id as p_u_id,pu.barcode,pu.item_code, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0"
        If Trim(txtBarcode.Text) <> "" Then
            query = query & " and pu.barcode = '" & txtBarcode.Text & "'"
        End If

        If Trim(txtItemCode.Text) <> "" Then
            query = query & " and pu.item_code = '" & txtItemCode.Text & "'"
        End If

        If selectedDesc > 0 And Trim(txtProductDesc.Text) <> "" Then
            query = query & " and p.id = " & selectedDesc
        End If

        If cbBrand.Text <> "All" Then
            query = query & " and b.id = " & selectedBrand
        End If

        If cbUnit.Text <> "All" Then
            query = query & " and u.id = " & selectedUnit
        End If


        If cbColor.Text <> "All" Then
            query = query & " and cc.id = " & selectedColor
        End If

        If cbCat.Text <> "All" Then
            query = query & " and c.id = " & selectedCat
        End If

        If cbSubCat.Text <> "All" Then
            query = query & " and sub.id = " & selectedSubCat
        End If

        query = query & " order by p.description"
        btnFilter.Enabled = False
        loadList(query)
        btnFilter.Enabled = True
    End Sub

    Public Function generatePrint() As String
        Dim table_content As String = ""
        Dim total_amount As Double = 0
        Dim dbledger As New DatabaseConnect()
        With dbledger
            .selectByQuery("Select distinct p.id,pu.id as p_u_id,pu.barcode,pu.item_code, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat,pu.status FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 order by p.description")
            Dim num As Integer = 0
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    'Dim id As String = .dr("id")
                    Dim p_u_id As String = .dr("p_u_id")
                    Dim barcode As String = .dr("barcode")
                    Dim itemcode As String = If(IsDBNull(.dr("item_code")), "", .dr("item_code"))
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim stock As String = ""

                    'get current stock
                    Try
                        Dim dbstock As New DatabaseConnect
                        With dbstock
                            .selectByQuery("select qty from product_stocks where product_unit_id = " & p_u_id)
                            If .dr.Read Then
                                stock = Val(.dr("qty")).ToString
                            Else
                                stock = ""
                            End If
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    Catch ex As Exception
                        stock = ""
                    End Try

                    Dim unit_all As String = ""
                    Dim price_all As String = ""
                    Try
                        Dim dbmeasure As New DatabaseConnect
                        With dbmeasure
                            .selectByQuery("select u.name as unit,pm.price from product_measure as pm inner join unit as u on u.id = pm.unit_id
                                where pm.product_unit_id = " & p_u_id)
                            While .dr.Read
                                unit_all = unit_all & .dr("unit") & "<br>"
                                price_all = price_all & Val(.dr("price")).ToString("N2") & "<br>"
                            End While
                            .cmd.Dispose()
                            .dr.Close()
                            .con.Close()
                        End With
                    Catch ex As Exception

                    End Try


                    Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat"))
                    Dim status As String = .dr("status")

                    Select Case status
                        Case "0"
                            status = "Deleted"
                        Case "1"
                            status = "Active"
                        Case "2"
                            status = "Phase Out"
                    End Select

                    tr = tr & "<td>" & (num + 1) & "</td>"
                    tr = tr & "<td>" & barcode & "</td>"
                    tr = tr & "<td>" & itemcode & "</td>"
                    tr = tr & "<td>" & desc & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & unit_all & " </td>"

                    tr = tr & "<td>" & price_all & "</td>"
                    tr = tr & "<td>" & stock & "</td>"
                    tr = tr & "<td>" & cat & "</td>"
                    tr = tr & "<td>" & subcat & "</td>"
                    tr = tr & "<td>" & status & "</td>"

                    tr = tr & "</tr>"
                    table_content = table_content & tr
                    num = num + 1
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim result As String = "<style>
    .table_pager {
		Font-family: Arial;
		border-collapse: collapse;
		width: 100%;
		
	}

	.table_pager td, .table_pager th {
        border: 0px solid #dddddd;
		Text-align: Left;
		
		Font-Size: 8pt;
	}
	
	.table_fieldset {
        Font - family: Arial;
		border-collapse: collapse;
		width: 100%;
		
	}

	.table_fieldset td, .table_fieldset th {
        border: 1px solid #dddddd;
		Text-align: Left;
		padding: 8px;
		Font-Size: 8pt;
	}

</style>
<body style ='margin:0;'>
<br>
    <table class='table_pager'>
        <tr>
            <td>
                <div id='header' style='text-align:center;'>
                    <img src='header.png' width='180'>
                        <p style='font-family:Arial;margin:1px;font-size:8pt;'>42 K Roosevelt Ave, Quezon City </p>
                        <p style='font-family:Arial;margin:1px;font-size:8pt;'>Telefax: 411-5274. Globe:0917-132-1241</p>
                        <p style='font-family:Arial;margin:1px;font-size:8pt;'>Email:purchasing.jmcj@gmail.com</p>
                        <p style='font-family:Arial black;margin:1px;font-size:15pt;'><strong>PRODUCTS </strong></p><small>Master List</small>
                </div>
                <!--<div id='fieldset'>
				</div>-->
                <br>
                    <table class='table_fieldset'>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Barcode</th>
                                <th>Item Code</th>
                                <th>Description</th>
                                <th>Brand</th>
                                <th>Color</th>
                                <th>Unit</th>
                                <th>Price</th>
                                <th>Stock Qty</th>
                                <th>Category</th>
                                <th>Subcategory</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                " & table_content & "
                            </tr>
                           
                            <!-- <tr>
                                <td colspan='10' style='text-align:right;'><strong>Grand Total</strong></td>
                                <td style='color:red'><strong>" & Val(total_amount).ToString("N2") & "</strong></td>
                            </tr> -->
                        </tbody>
                    </table>
                    <!--<br><br><br><br><br><br><br><br><br><br><br><br>
				<table id='footer' class='table_fieldset'>
					<tbody>
						<tr>
							<td style='width:100px;'> <input type='checkbox'> DELIVER </td>
							<td style='width:150px;' colspan='2'> <input type='checkbox'>PICK UP _______________________________</td>
						</tr>
						<tr>
							<td style='width:100px;'> <input type='checkbox'> FAXED </td>
							<td rowspan='2'>CHECKED BY</td>
							<td rowspan='2'>APPROVED BY</td>
						</tr>
						<tr>
							<td style='width:100px;'> <input type='checkbox'> EMAILED </td>
						</tr>
					</tbody>
				</table>-->
            </td>
            <td>

            </td>
        </tr>
    </table>
</body>"
        Return result
    End Function

    Private Sub txtProductDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductDesc.KeyDown
        selectedDesc = 0
        If e.KeyCode = Keys.Enter Then
            If txtProductDesc.TextLength > 0 Then
                selectedDesc = New DatabaseConnect().get_id("products", "description", txtProductDesc.Text)
            Else
                selectedDesc = 0
            End If
        End If
    End Sub

    Private Sub cbBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand.SelectedIndexChanged
        If cbBrand.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedBrand = key
            'populateColor(SelectedProdID, selectedBrand)
        Else
            selectedBrand = 0
            'populateColor(SelectedProdID, selectedBrand)
        End If
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedUnit = key
        Else
            selectedUnit = 0
        End If
    End Sub

    Private Sub cbColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbColor.SelectedIndexChanged
        If cbColor.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbColor.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedColor = key
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        Else
            selectedColor = 0
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        End If
    End Sub

    Private Sub cbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCat.SelectedIndexChanged
        If cbCat.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCat.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCat.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCat = key
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        Else
            selectedCat = 0
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        End If
    End Sub

    Private Sub cbSubCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubCat.SelectedIndexChanged
        If cbSubCat.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSubCat.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSubCat.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSubCat = key
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        Else
            selectedSubCat = 0
            'populateUnit(SelectedProdID, selectedBrand, selectedColor)
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim path As String = Application.StartupPath & "\products.html"
        Try
            Dim code As String = generatePrint()
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            Exit Sub
        End Try
        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")

    End Sub

    Private Sub txtProductDesc_MouseLeave(sender As Object, e As EventArgs) Handles txtProductDesc.MouseLeave
        If txtProductDesc.TextLength > 0 Then
            selectedDesc = New DatabaseConnect().get_id("products", "description", txtProductDesc.Text)
        Else
            selectedDesc = 0
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim id As Integer = dgvProducts.SelectedRows(0).Cells(0).Value

        Dim yn As Integer = MsgBox("Are you sure you want to delete this product ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If yn = MsgBoxResult.Yes Then
            Dim db As New DatabaseConnect
            db.update_where("product_unit", id, "status", 0)
            db.cmd.Dispose()
            db.con.Close()
            MsgBox("Product Successfully Deleted.", MsgBoxStyle.Information)
            loadList("")
        End If
    End Sub

    Private Sub getTotalQty()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select sum(qty) as total from product_stocks as  ps inner join product_unit as pu on pu.id = ps.product_unit_id where pu.status <> 0")
            If .dr.Read Then
                lblTotalStock.Text = If(IsDBNull(.dr("total")), "0", .dr("total"))
            End If
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim k As String = Trim(txtSearch.Text).ToUpper
            Dim query As String = "Select p.id,pu.id as p_u_id,pu.barcode,pu.item_code, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 
                and UCASE(p.description) like '%" & k & "%'  or UCASE(pu.item_code) like '%" & k & "%' 
                or UCASE(pu.barcode) like '%" & k & "%' or UCASE(c.name) like '%" & k & "%' 
                or UCASE(sub.name) like '%" & k & "%' or UCASE(cc.name) like '%" & k & "%' order by p.created_at desc"

            loadList(query)
        End If
    End Sub

End Class