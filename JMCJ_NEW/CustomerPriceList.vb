Public Class CustomerPriceList

    Public selectedCustomer As Integer = 0
    Public selectedDesc As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedUnit As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedCat As Integer = 0
    Public selectedSubCat As Integer = 0

    Public Sub getCustomer()
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cbCustomer.SelectedIndex > 0 Then
            AddProductForm.selectedCustomer = Me.selectedCustomer
            AddProductForm.initialize()
            AddProductForm.ShowDialog()
        Else
            selectedCustomer = 0
            AddProductForm.selectedCustomer = 0
            cbCustomer.Focus()
            MsgBox("Please select customer", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCustomer.SelectedIndexChanged
        If cbCustomer.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCustomer = key
            getList("", selectedCustomer)
        Else
            selectedCustomer = 0
        End If
    End Sub

    Public Sub getList(ByVal query As String, ByVal customer_id As Integer)
        dgvPriceList.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                .selectByQuery("Select distinct pu.id,pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,cpp.sell_price,c.name as cat, subc.name as subcat from (((((((((product_unit as pu
                INNER JOIN customer_product_prices as cpp ON cpp.product_unit_id = pu.id)
                LEFT JOIN brand as b on b.id = pu.brand)
                INNER JOIN unit as u on u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN products as p ON p.id = pu.product_id)
                LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
                where cpp.customer_id = " & customer_id & " order by p.description")
            Else
                .selectByQuery(query)

            End If

            Dim recordfound As Boolean = False
            If .dr.HasRows Then
                recordfound = True
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim sell_price As String = Val(.dr("sell_price")).ToString("N2")
                    Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    Dim subcat As String = If(IsDBNull(.dr("subcat")), "", .dr("subcat"))

                    If Val(sell_price) <= 0 Then
                        sell_price = price
                    End If
                    Dim row As String() = New String() {id, True, barcode, desc, brand, unit, color, price, sell_price, cat, subcat}
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
        If dgvPriceList.Rows.Count = 0 Then
            MsgBox("Please add product for this customer!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If selectedCustomer > 0 Then
            CustomerOrderForm.enableControl(True)
            CustomerOrderForm.loadTerm()
            CustomerOrderForm.loadPaymentType()
            CustomerOrderForm.getCustomerList("")
            CustomerOrderForm.selectedCustomer = Me.selectedCustomer
            CustomerOrderForm.cbCustomer.SelectedIndex = CustomerOrderForm.cbCustomer.FindString(cbCustomer.Text)
            CustomerOrderForm.txtInvoiceNo.Text = CustomerOrderForm.generateInvoice
            CustomerOrderForm.dgvProd.Rows.Clear()

            'reset this fields
            CustomerOrderForm.dtpDateIssue.Value = DateTime.Now
            'LedgerForm.txtCounterNo.Text = ""
            'LedgerForm.cbDisable.Checked = False
            CustomerOrderForm.txtAmount.Text = "0.00"
            CustomerOrderForm.cbPaymentType.SelectedIndex = 0
            CustomerOrderForm.selectedPaymentType = 0
            CustomerOrderForm.rPaidYes.Checked = False
            CustomerOrderForm.rPaidNo.Checked = False
            'CustomerOrderForm.dtpPaid.Value = DateTime.Now
            'LedgerForm.txtBankDetails.Text = ""
            'LedgerForm.dtpCheckDate.Value = DateTime.Now
            'LedgerForm.rbFloatingYes.Checked = False
            'LedgerForm.rbFloatingNo.Checked = False

            CustomerOrderForm.cbTerms.SelectedIndex = 0
            CustomerOrderForm.txtRemarks.Text = ""
            CustomerOrderForm.txtDeliveredBy.Text = ""
            CustomerOrderForm.txtReceivedBy.Text = ""
            CustomerOrderForm.lblTotalAmount.Text = "0.00"

            CustomerOrderForm.btnSave.Text = "Save"
            CustomerOrderForm.btnSaveAndPrint.Text = "Save and Print"

            For Each item As DataGridViewRow In Me.dgvPriceList.Rows
                Dim selectedproduct As Boolean = dgvPriceList.Rows(item.Index).Cells("selectproduct").Value
                If selectedproduct Then
                    Dim prod_unit_id As String = dgvPriceList.Rows(item.Index).Cells("id").Value
                    Dim barcode As String = dgvPriceList.Rows(item.Index).Cells("barcode").Value
                    Dim desc As String = dgvPriceList.Rows(item.Index).Cells(3).Value
                    Dim brand As String = dgvPriceList.Rows(item.Index).Cells("Brand").Value
                    Dim unit As String = dgvPriceList.Rows(item.Index).Cells("Unit").Value
                    Dim color As String = dgvPriceList.Rows(item.Index).Cells("Color").Value
                    Dim unit_price As String = dgvPriceList.Rows(item.Index).Cells("UnitPrice").Value
                    Dim sell_price As String = dgvPriceList.Rows(item.Index).Cells("sell_price").Value
                    Dim stock As String = New DatabaseConnect().get_by_val("product_stocks", prod_unit_id, "product_unit_id", "qty")


                    Dim row As String() = New String() {prod_unit_id, barcode, "0", desc, brand, unit, color, unit_price, "", "Add less", "Reset", sell_price, "0.00", stock, "Remove"}
                    CustomerOrderForm.dgvProd.Rows.Add(row)
                End If
            Next
            CustomerOrderForm.gpFields.Enabled = True
            CustomerOrderForm.btnSave.Visible = True
            CustomerOrderForm.btnSaveAndPrint.Visible = True
            CustomerOrderForm.txtInvoiceNo.Enabled = False
            CustomerOrderForm.btnCheck.Visible = False
            CustomerOrderForm.btnApprove.Visible = False
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
            Dim prod_desc As String = dgvPriceList.SelectedRows(0).Cells(3).Value
            Dim brand As String = dgvPriceList.SelectedRows(0).Cells("Brand").Value
            Dim unit As String = dgvPriceList.SelectedRows(0).Cells("Unit").Value
            Dim color As String = dgvPriceList.SelectedRows(0).Cells("Color").Value
            Dim unit_price As String = dgvPriceList.SelectedRows(0).Cells("UnitPrice").Value.ToString.Replace(",", "")
            Dim sellprice As String = dgvPriceList.SelectedRows(0).Cells("sell_price").Value.ToString.Replace(",", "")

            UpdatePriceForm.selected_product_unit = dgvPriceList.SelectedRows(0).Cells("id").Value
            UpdatePriceForm.txtCustomer.Text = customer
            UpdatePriceForm.txtBarcode.Text = barcode
            UpdatePriceForm.txtProductDesc.Text = prod_desc
            UpdatePriceForm.txtBrand.Text = brand
            UpdatePriceForm.txtUnit.Text = unit
            UpdatePriceForm.txtColor.Text = color
            UpdatePriceForm.txtUnitPrice.Text = unit_price
            UpdatePriceForm.txtSellPrice.Text = sellprice
            UpdatePriceForm.ShowDialog()
            UpdatePriceForm.txtSellPrice.Focus()
            UpdatePriceForm.txtSellPrice.SelectAll()
            Exit Sub
        End If

        If dgvPriceList.SelectedRows.Count = 0 Or dgvPriceList.SelectedRows.Count > 1 Then
            MsgBox("Please select product you want to update price!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub ckSelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles ckSelectAll.CheckedChanged

        If dgvPriceList.Rows.Count > 0 Then
            If ckSelectAll.Checked = True Then
                For Each item As DataGridViewRow In Me.dgvPriceList.Rows
                    If dgvPriceList.Rows(item.Index).Cells(3).Value <> "" Then
                        dgvPriceList.Rows(item.Index).Cells(1).Value = True
                    End If
                Next
            Else
                For Each item As DataGridViewRow In Me.dgvPriceList.Rows
                    If dgvPriceList.Rows(item.Index).Cells(3).Value <> "" Then
                        dgvPriceList.Rows(item.Index).Cells(1).Value = False
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub CustomerPriceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getCustomer()
        autocompleteDesc()
        loadBrand()
        loadUnit()
        loadColor()
        loadCat()
        loadSubCat()
    End Sub

    Private Sub btnDeleteProduct_Click(sender As Object, e As EventArgs) Handles btnDeleteProduct.Click
        'validation
        Dim valid As Boolean = False
        For Each item As DataGridViewRow In Me.dgvPriceList.Rows
            Dim selectedproduct As Boolean = dgvPriceList.Rows(item.Index).Cells("selectproduct").Value
            If selectedproduct Then
                valid = True
            End If
        Next

        If valid = False Then
            MsgBox("Please select a product you want to delete!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim yesno = MsgBox("Are you sure you want to delete selected products ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
        If yesno = MsgBoxResult.Yes Then
            For Each item As DataGridViewRow In Me.dgvPriceList.Rows
                Dim selectedproduct As Boolean = dgvPriceList.Rows(item.Index).Cells("selectproduct").Value
                If selectedproduct Then
                    Dim prod_unit_id As String = dgvPriceList.Rows(item.Index).Cells("id").Value


                    Dim dbdelete As New DatabaseConnect
                    With dbdelete
                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text
                        .cmd.CommandText = "delete from customer_product_prices where customer_id = " & selectedCustomer & " and product_unit_id = " & prod_unit_id
                        .cmd.ExecuteNonQuery()
                        .cmd.Dispose()
                        .con.Close()
                    End With
                    MsgBox("Selected product successfully deleted!", MsgBoxStyle.Information)
                    'Dim row As String() = New String() {prod_id, barcode, "0", desc, brand, unit, unit_price, "", "Add less", "Reset", sell_price, "0.00", "", "Remove"}
                    'LedgerForm.dgvProd.Rows.Add(row)
                End If
            Next
            getList("", selectedCustomer)
        End If

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        'btnPrint.Text = "loading.."
        'If cbCustomer.SelectedIndex > 0 Then
        '    Dim cpr As New CustomerPriceReport
        '    cpr.RecordSelectionFormula = "{customer_product_prices.customer_id} = " & selectedCustomer
        '    ReportViewer.Enabled = True
        '    ReportViewer.CrystalReportViewer1.ReportSource = cpr
        '    ReportViewer.CrystalReportViewer1.Refresh()
        '    ReportViewer.CrystalReportViewer1.RefreshReport()
        '    ReportViewer.ShowDialog()
        'Else
        '    MsgBox("Please select customer!", MsgBoxStyle.Critical)
        '    selectedCustomer = 0
        'End If
        'btnPrint.Text = "Print"

        If cbCustomer.SelectedIndex = 0 Then
            MsgBox("Please select customer!", MsgBoxStyle.Critical)
            cbCustomer.Focus()
            selectedCustomer = 0
            Exit Sub
        End If

        Dim path As String = Application.StartupPath & "\prices_report.html"
        Dim filter() As String = {"sample1", "sample2"}
        Try
            Dim code As String = generatePrint(filter)
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Enabled = True
    End Sub

    Private Function generatePrint(ByVal filter() As String)
        Dim result As String

        Dim customer As String = New DatabaseConnect().get_by_id("company", selectedCustomer, "company")
        Dim address As String = New DatabaseConnect().get_by_id("company", selectedCustomer, "address")
        Dim city As String = New DatabaseConnect().get_by_id("company", selectedCustomer, "city")

        Dim total_price As Double = 0
        Dim total_sell_price As Double = 0
        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery("Select distinct pu.id,pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,cpp.sell_price,c.name as cat, subc.name as subcat from (((((((((product_unit as pu
                INNER JOIN customer_product_prices as cpp ON cpp.product_unit_id = pu.id)
                LEFT JOIN brand as b on b.id = pu.brand)
                INNER JOIN unit as u on u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN products as p ON p.id = pu.product_id)
                LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
                where cpp.customer_id = " & selectedCustomer)
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = Val(.dr("price")).ToString("N2")
                    Dim sell_price As String = Val(.dr("sell_price")).ToString("N2")

                    If Val(sell_price) <= 0 Then
                        sell_price = price
                    End If

                    total_price += CDbl(price)
                    total_sell_price += CDbl(sell_price)
                    tr = tr & "<td>" & barcode & "</td>"
                    tr = tr & "<td>" & desc & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & unit & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & price & "</td>"
                    tr = tr & "<td>" & sell_price & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
        result = "<!DOCTYPE html>
<html>
<head>
<style>
table {
	font-family:serif;
	border-collapse: collapse;
	width: 100%;
}

td, th {
	border: 1px solid #dddddd;
	text-align: left;
	padding: 8px;
}

tr:nth-child(even) {

}
</style>
</head>
<body>

<h2>Customer product and prices</h2>
<div id='fieldset'>
	<table>
		<tr>
			<td width='90'><label><strong>Customer: </strong></label></td>
			<td><label>" & customer & "</label></td>
			
			<td width='80'><label><strong>Address: </strong></label></td>
			<td><label>" & address & "</label></td>
			
			<td width='100'><label><strong>City/Municipality: </strong></label></td>
			<td><label>" & city & " </label></td>
		</tr>
	
	<table>
</div>
<br>
<table>
  <thead>
  <tr>
	<th>Barcode</th>
	<th>Description</th>
	<th>Brand</th>
	<th>Unit</th>
	<th>Color</th>
	<th>Unit Price</th>
	<th>Sell Price</th>
  </tr>
  </thead>
  <tbody>
    " & table_content & "
    <tr>
		<td colspan='5' style='text-align:right;'><strong>Total</strong></td>
		<td style='color:red'><strong>" & Format(total_price, "0.00") & "</strong></td>
		<td style='color:red'><strong>" & Format(total_sell_price, "0.00") & "</strong></td>
	</tr>
  </tbody>
</table>

</body>
</html>
"

        Return result
    End Function

    Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCustomer.Click
        CustomerForm.btnSave.Text = "Save"
        CustomerForm.loadCompanyStatus()
        CustomerForm.ShowDialog()
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

    Private Sub txtProductDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtProductDesc.TextLength > 0 And selectedDesc > 0 Then
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

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click

        If selectedCustomer <= 0 Then
            MsgBox("Please select customer.", MsgBoxStyle.Critical)
            cbCustomer.Focus()
            Exit Sub
        End If
        Dim query As String = "Select distinct pu.id,pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,cpp.sell_price,c.name as cat, subc.name as subcat from (((((((((product_unit as pu
                INNER JOIN customer_product_prices as cpp ON cpp.product_unit_id = pu.id)
                LEFT JOIN brand as b on b.id = pu.brand)
                INNER JOIN unit as u on u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN products as p ON p.id = pu.product_id)
                LEFT JOIN product_categories as pc ON pc.product_id = pu.product_id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = pu.product_id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as subc ON subc.id = psc.subcategory_id)
                where cpp.customer_id = " & selectedCustomer

        If Trim(txtBarcode.Text) <> "" Then
            query = query & " and pu.barcode = '" & txtBarcode.Text & "'"
        End If

        If selectedDesc > 0 Then
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

        getList(query, selectedCustomer)

    End Sub
End Class