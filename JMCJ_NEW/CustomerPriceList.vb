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
        Else
            selectedCustomer = 0
        End If
    End Sub

    Public Sub getList(ByVal query As String, ByVal customer_id As Integer)
        dgvPriceList.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If query = "" Then
                .selectByQuery("Select distinct cpp.product_id,pu.barcode,p.description,b.name as brand, u.name as unit,cc.name as color,cpp.sell_price,c.name as cat, subc.name as subcat
                from (((((((((customer_product_prices as cpp
                INNER JOIN products as p ON p.id = cpp.product_id)
                INNER JOIN product_unit as pu ON pu.product_id = cpp.product_id and pu.brand = cpp.brand and pu.unit = cpp.unit)
                INNER JOIN brand as b on b.id = cpp.brand)
                INNER JOIN unit as u on u.id = cpp.unit)
                INNER JOIN color as cc ON cc.id = cpp.color)
                INNER JOIN product_categories as pc ON pc.product_id = cpp.product_id) 
                INNER JOIN product_subcategories as psc ON psc.product_id = cpp.product_id)
                INNER JOIN categories as c ON c.id = pc.category_id)
                INNER JOIN categories as subc ON subc.id = psc.subcategory_id)
                where cpp.customer_id = " & customer_id)
            End If

            Dim recordfound As Boolean = False
            If .dr.HasRows Then
                recordfound = True
                While .dr.Read
                    Dim id As String = .dr("product_id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim price As String = "0.00"

                    Dim b_id As Integer = New DatabaseConnect().get_id("brand", "name", brand)
                    Dim u_id As Integer = New DatabaseConnect().get_id("unit", "name", unit)
                    Dim c_id As Integer = New DatabaseConnect().get_id("color", "name", color)

                    Dim db2 As New DatabaseConnect
                    With db2
                        .selectByQuery("Select price from product_unit where product_id = " & id &
                            " and unit = " & u_id & " and brand = " & b_id & " and color = " & c_id)
                        If .dr.Read Then
                            price = CInt(.dr("price")).ToString("N2")
                        End If
                        .cmd.Dispose()
                        .dr.Close()
                        .con.Close()
                    End With

                    Dim sell_price As String = Val(.dr("sell_price")).ToString("N2")
                    Dim cat As String = If(IsDBNull(.dr("cat")), "", .dr("cat"))
                    Dim subcat As String = If(IsDBNull(.dr("subcat")), barcode, .dr("subcat"))
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
            LedgerForm.enableControl(True)
            LedgerForm.loadTerm()
            LedgerForm.loadPaymentType()
            LedgerForm.loadLedgerType()
            LedgerForm.getCustomerList("")
            LedgerForm.selectedCustomer = Me.selectedCustomer
            LedgerForm.cbCustomer.SelectedIndex = LedgerForm.cbCustomer.FindString(cbCustomer.Text)
            LedgerForm.txtInvoiceNo.Text = LedgerForm.generateInvoice
            LedgerForm.dgvProd.Rows.Clear()

            'reset this fields
            LedgerForm.dtpDateIssue.Value = DateTime.Now
            LedgerForm.txtCounterNo.Text = ""
            LedgerForm.cbDisable.Checked = False
            LedgerForm.txtAmount.Text = "0.00"
            LedgerForm.cbPaymentType.SelectedIndex = 0
            LedgerForm.selectedPaymentType = 0
            LedgerForm.rPaidYes.Checked = False
            LedgerForm.rPaidNo.Checked = False
            LedgerForm.dtpPaid.Value = DateTime.Now
            LedgerForm.txtBankDetails.Text = ""
            LedgerForm.dtpCheckDate.Value = DateTime.Now
            LedgerForm.rbFloatingYes.Checked = False
            LedgerForm.rbFloatingNo.Checked = False

            LedgerForm.cbTerms.SelectedIndex = 0
            LedgerForm.cbLedgerType.SelectedIndex = 0
            LedgerForm.txtRemarks.Text = ""
            LedgerForm.txtDeliveredBy.Text = ""
            LedgerForm.txtReceivedBy.Text = ""
            LedgerForm.lblTotalAmount.Text = "0.00"

            LedgerForm.btnSave.Text = "Save"
            LedgerForm.btnSaveAndPrint.Text = "Save and Print"

            For Each item As DataGridViewRow In Me.dgvPriceList.Rows
                Dim selectedproduct As Boolean = dgvPriceList.Rows(item.Index).Cells("selectproduct").Value
                If selectedproduct Then
                    Dim prod_id As String = dgvPriceList.Rows(item.Index).Cells("id").Value
                    Dim barcode As String = dgvPriceList.Rows(item.Index).Cells("barcode").Value
                    Dim desc As String = dgvPriceList.Rows(item.Index).Cells(3).Value
                    Dim brand As String = dgvPriceList.Rows(item.Index).Cells("Brand").Value
                    Dim unit As String = dgvPriceList.Rows(item.Index).Cells("Unit").Value
                    Dim color As String = dgvPriceList.Rows(item.Index).Cells("Color").Value
                    Dim unit_price As String = dgvPriceList.Rows(item.Index).Cells("UnitPrice").Value
                    Dim sell_price As String = dgvPriceList.Rows(item.Index).Cells("sell_price").Value

                    Dim row As String() = New String() {prod_id, barcode, "0", desc, brand, unit, color, unit_price, "", "Add less", "Reset", sell_price, "0.00", "", "Remove"}
                    LedgerForm.dgvProd.Rows.Add(row)
                End If
            Next
            LedgerForm.ShowDialog()
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
                    Dim prod_id As String = dgvPriceList.Rows(item.Index).Cells("id").Value
                    Dim brand As String = dgvPriceList.Rows(item.Index).Cells("Brand").Value
                    Dim unit As String = dgvPriceList.Rows(item.Index).Cells("Unit").Value
                    Dim color As String = dgvPriceList.Rows(item.Index).Cells("Color").Value

                    Dim b_id As Integer = New DatabaseConnect().get_id("brand", "name", brand)
                    Dim u_id As Integer = New DatabaseConnect().get_id("unit", "name", unit)
                    Dim c_id As Integer = New DatabaseConnect().get_id("color", "name", unit)

                    Dim dbdelete As New DatabaseConnect
                    With dbdelete
                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text
                        .cmd.CommandText = "delete from customer_product_prices where customer_id = " & selectedCustomer & " and 
                        product_id = " & prod_id & " and brand = " & b_id & " and unit = " & u_id & " and color = " & c_id
                        .cmd.ExecuteNonQuery()
                        .cmd.Dispose()
                        .con.Close()
                    End With
                    'Dim row As String() = New String() {prod_id, barcode, "0", desc, brand, unit, unit_price, "", "Add less", "Reset", sell_price, "0.00", "", "Remove"}
                    'LedgerForm.dgvProd.Rows.Add(row)
                End If
            Next
            getList("", selectedCustomer)
        End If

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        btnPrint.Text = "loading.."
        If cbCustomer.SelectedIndex > 0 Then
            Dim cpr As New CustomerPriceReport
            cpr.RecordSelectionFormula = "{customer_product_prices.customer_id} = " & selectedCustomer
            ReportViewer.Enabled = True
            ReportViewer.CrystalReportViewer1.ReportSource = cpr
            ReportViewer.CrystalReportViewer1.Refresh()
            ReportViewer.CrystalReportViewer1.RefreshReport()
            ReportViewer.ShowDialog()
        Else
            MsgBox("Please select customer!", MsgBoxStyle.Critical)
            selectedCustomer = 0
        End If
        btnPrint.Text = "Print"
        btnPrint.Enabled = True
    End Sub
End Class