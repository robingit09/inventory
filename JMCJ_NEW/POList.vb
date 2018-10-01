Public Class POList
    Public selectedSupplier As Integer = 0
    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        PurchaseOrderForm.initialize()
        PurchaseOrderForm.clearFields()
        PurchaseOrderForm.btnSave.Enabled = True
        PurchaseOrderForm.btnSaveAndPrint.Enabled = True
        PurchaseOrderForm.dgvProd.Enabled = True
        PurchaseOrderForm.gpFields.Enabled = True
        PurchaseOrderForm.gpEnterBarcode.Enabled = True
        PurchaseOrderForm.gpEnterProduct.Enabled = True
        PurchaseOrderForm.ShowDialog()
        btnAddNew.Enabled = True
    End Sub

    Public Sub loadPO(ByVal query As String)
        dgvPO.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            If query = "" Then
                .selectByQuery("Select * from purchase_orders order by id desc")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim date_issue As String = Convert.ToDateTime(.dr("po_date")).ToString("MM-dd-yy")
                    Dim po_no As String = .dr("po_no")
                    Dim supplier_id As Integer = CInt(.dr("supplier"))
                    Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim processed_by As String = New DatabaseConnect().get_by_id("users", .dr("processed_by"), "first_name") & " " & New DatabaseConnect().get_by_id("users", .dr("processed_by"), "surname")
                    Dim delivery_status As String = ""

                    Select Case .dr("delivery_status")
                        Case "0"
                            delivery_status = "Voided"
                        Case "1"
                            delivery_status = "Pending"
                        Case "2"
                            delivery_status = "Received"

                    End Select
                    Dim row As String() = New String() {id, date_issue, po_no, supplier_name, total_amount, processed_by, delivery_status}
                    dgvPO.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvPO.Rows
                    If row.Cells("delivery_status").Value = "Voided" Then
                        row.DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                Next
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub POList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPO("")
        autocompleteSupplier()
        getMonth()
        getYear()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click

        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim po_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        PurchaseOrderForm.initialize()
        PurchaseOrderForm.loadInfo(po_id)
        PurchaseOrderForm.btnSave.Enabled = False
        PurchaseOrderForm.btnSaveAndPrint.Enabled = False
        PurchaseOrderForm.dgvProd.Enabled = False
        PurchaseOrderForm.gpFields.Enabled = False
        PurchaseOrderForm.gpEnterBarcode.Enabled = False
        PurchaseOrderForm.gpEnterProduct.Enabled = False
        PurchaseOrderForm.ShowDialog()
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim po_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        Dim d_status As String = dgvPO.SelectedRows(0).Cells("delivery_status").Value

        If d_status = "Received" Then
            MsgBox("Already Received.This transaction cannot be voided!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim yn As Integer = MsgBox("Are you sure you want to void this transaction ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If yn = MsgBoxResult.Yes Then
            Dim db As New DatabaseConnect
            db.update_where("purchase_orders", po_id, "delivery_status", 0)
            db.cmd.Dispose()
            db.con.Close()
            MsgBox("Purchase Order Successfully Void.", MsgBoxStyle.Information)
            loadPO("")
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        If dgvPO.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        btnPrint.Enabled = False
        Dim po_id As Integer = dgvPO.SelectedRows(0).Cells(0).Value
        Dim path As String = Application.StartupPath & "\po_report.html"

        Try
            Dim code As String = generatePrint(po_id)
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Enabled = True
    End Sub

    Public Function generatePrint(ByVal po_id As Integer) As String
        Dim result As String = ""

        Dim supplier As String = getSupplier(po_id)
        Dim po_no As String = New DatabaseConnect().get_by_id("purchase_orders", po_id, "po_no")
        Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier, "supplier_name")
        Dim address As String = New DatabaseConnect().get_by_id("suppliers", supplier, "address") & " " & New DatabaseConnect().get_by_id("suppliers", supplier, "city")
        Dim contact_person As String = New DatabaseConnect().get_by_id("suppliers", supplier, "contact_person")
        Dim delivered_to As String = New DatabaseConnect().get_by_id("purchase_orders", po_id, "delivered_to")
        Dim delivered_by As String = New DatabaseConnect().get_by_id("purchase_orders", po_id, "delivered_by")

        Dim term As String = New DatabaseConnect().get_by_id("purchase_orders", po_id, "terms")
        Dim term_val As String = ""
        Select Case term
            Case "15"
                term_val = "15 days"
            Case "30"
                term_val = "30 days"
            Case "0"
                term_val = ""
            Case Else
                term_val = ""
        End Select

        Dim payment_type As Integer = New DatabaseConnect().get_by_id("purchase_orders", po_id, "payment_type")
        Dim payment_val As String = ""
        Select Case payment_type
            Case 1
                payment_val = "Cash"
            Case 2
                payment_val = "C.O.D"
            Case 3
                payment_val = "Credit"
            Case Else
                payment_val = ""
        End Select

        Dim po_date As String = New DatabaseConnect().get_by_id("purchase_orders", po_id, "po_date")
        Dim pdate As DateTime = Convert.ToDateTime(po_date)
        po_date = pdate.ToString("MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture)

        Dim eta As String = New DatabaseConnect().get_by_id("purchase_orders", po_id, "eta")
        Dim total_amount As String = Val(New DatabaseConnect().get_by_id("purchase_orders", po_id, "total_amount")).ToString("N2")

        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery("select distinct pu.id,pu.barcode,p.description,b.name as brand,u.name as unit,c.name as color,pop.quantity,pop.unit_cost,pop.total_amount,ps.qty as stock
                        FROM ((((((purchase_order_products as pop
                        INNER JOIN product_unit as pu ON pu.id = pop.product_unit_id)
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = pu.unit)
                        LEFT JOIN color as c ON c.id = pu.color)
                        INNER JOIN products as p ON p.id = pu.product_id)
                        left join product_stocks as ps on ps.product_unit_id = pu.id)
                        where pop.purchase_order_id = " & po_id)
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim qty As Integer = .dr("quantity")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim cost As String = Val(.dr("unit_cost")).ToString("N2")
                    Dim total As String = Val(.dr("total_amount")).ToString("N2")
                    tr = tr & "<td>" & barcode & "</td>"
                    tr = tr & "<td>" & qty & "</td>"
                    tr = tr & "<td>" & desc & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & unit & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & cost & "</td>"
                    tr = tr & "<td>" & total & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr
                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim page As String = "<div id='header' style='text-align:center;'>
				<img src='header.png' width='180'>
				<p style='font-family:Arial;margin:1px;font-size:8pt;'>42 K Roosevelt Ave, Quezon City </p>
				<p style='font-family:Arial;margin:1px;font-size:8pt;'>Telefax: 411-5274. Globe:0917-132-1241</p>
				<p style='font-family:Arial;margin:1px;font-size:8pt;'>Email:purchasing.jmcj@gmail.com</p>
				<p style='font-family:Arial black;font-weight:bold;margin:1px;font-size:15pt;'>PURCHASE ORDER</p>
			</div>
			<div id='fieldset'>
				<table class='table_fieldset'>
					<tr>
						<td><label><strong> Supplier: </strong></label></td>
						<td><label>" & supplier_name & "</label></td>
						<td><label><strong> PO #: " & po_no & " </strong></label></td>
						<td>Date: " & po_date & " </td>
					</tr>
					<tr>
						<td><label><strong> Address </strong></label></td>
						<td><label> " & address & "  </label></td>
						<td colspan='2'><label><strong> ATTN: " & contact_person & "</strong></label></td>
						
					</tr>
					<tr>
						<td colspan='2'><label><strong> Delivered To: <span style='color:blue;'>" & delivered_to & "</span> </strong></label></td>
						<td colspan='2'><label><strong> Delivered By:  <span style='color:blue;'>" & delivered_by & "</span> </strong></label></td>
						
					</tr>
					
				<table>
			</div>
			
			<br>
			<table class='table_fieldset'>
			  <thead>
			  <tr>
				<th>Barcode</th>
				<th>Qty</th>
				<th>Description</th>
				<th>Brand</th>
				<th>Unit</th>
				<th>Color</th>
				<th>Unit Price</th>
				<th>Total Amount</th>
			  </tr>
			  </thead>
			  <tbody>
				" & table_content & "
				<tr>
					<td colspan='7' style='text-align:right;'><strong>Grand Total</strong></td>
					<td style='color:red'><strong>" & total_amount & "</strong></td>
				</tr>
			  </tbody>
			</table>
			<br><br><br><br><br><br><br><br><br><br><br><br>
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
			</table>"

        result = " <style>
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

	tr: nth-child(even) {

	}
</style>
<body style ='margin:0;'>
<br>
    <table class='table_pager'>
        <tr>
            <td>" & page & "</td><td>" & page & "</td>
</tr>
</table>
</body>"
        Return result
    End Function

    Private Function getSupplier(ByVal po_id As Integer) As Integer
        Dim res As Integer = 0
        Dim dbpo As New DatabaseConnect
        With dbpo
            .selectByQuery("Select supplier from purchase_orders where id = " & po_id)
            If .dr.Read Then
                res = CInt(.dr("supplier"))
            End If
        End With
        Return res
    End Function

    Public Sub autocompleteSupplier()
        Dim MySource As New AutoCompleteStringCollection()
        With txtSupplier
            .AutoCompleteCustomSource = MySource
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With

        Dim customer As New DatabaseConnect
        With customer
            .selectByQuery("Select distinct supplier_name from suppliers  where status = 1")
            While .dr.Read
                MySource.Add(.dr.GetValue(0))
            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Private Sub getMonth()
        cbMonth.Items.Clear()
        Dim formatInfo = System.Globalization.DateTimeFormatInfo.CurrentInfo
        cbMonth.Items.Add("All")
        For i As Integer = 1 To 12
            Dim monthName = formatInfo.GetMonthName(i)
            cbMonth.Items.Add(monthName)
        Next
        cbMonth.SelectedIndex = 0
    End Sub

    Private Sub getYear()
        cbYear.Items.Clear()
        cbYear.Items.Add("All")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT distinct YEAR(po_date) FROM purchase_orders where delivery_status <> 0 order by YEAR(po_date) DESC")
            While .dr.Read
                cbYear.Items.Add(.dr.GetValue(0))
            End While
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
            cbYear.SelectedIndex = 0
        End With
    End Sub

    Private Function monthToNumber(ByVal month As String) As String
        Dim result As String = ""
        Select Case month.ToUpper
            Case "JANUARY"
                result = "1"
            Case "FEBRUARY"
                result = "2"
            Case "MARCH"
                result = "3"
            Case "APRIL"
                result = "4"
            Case "MAY"
                result = "5"
            Case "JUNE"
                result = "6"
            Case "JULY"
                result = "7"
            Case "AUGUST"
                result = "8"
            Case "SEPTEMBER"
                result = "9"
            Case "OCTOBER"
                result = "10"
            Case "NOVEMBER"
                result = "11"
            Case "DECEMBER"
                result = "12"
            Case Else
                result = ""
        End Select
        Return result
    End Function

    Private Sub txtSupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupplier.KeyDown, TextBox2.KeyDown, TextBox1.KeyDown
        If txtSupplier.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            txtSupplier.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplier.Text.ToLower())
            selectedSupplier = New DatabaseConnect().get_id("suppliers", "supplier_name", txtSupplier.Text)
            'MsgBox(selectedCustomer)
        Else
            selectedSupplier = 0
        End If
    End Sub

    Private Sub txtSupplier_Leave(sender As Object, e As EventArgs) Handles txtSupplier.Leave, TextBox2.Leave, TextBox1.Leave
        If txtSupplier.Text.Length > 0 Then
            selectedSupplier = New DatabaseConnect().get_id("suppliers", "supplier_name", txtSupplier.Text)
            'MsgBox(selectedCustomer)
        Else
            selectedSupplier = 0
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click, Button2.Click, Button1.Click
        btnFilter.Enabled = False
        Dim query As String = "Select * from purchase_orders where delivery_status > -1 "
        If txtSupplier.Text <> "" And selectedSupplier > 0 Then
            query = query & " and supplier = " & selectedSupplier
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(po_date) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(po_date) = " & cbYear.Text
        End If

        query = query & "  order by id desc"
        loadPO(query)
        btnFilter.Enabled = True
    End Sub


End Class