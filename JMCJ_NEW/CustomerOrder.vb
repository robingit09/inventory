Public Class CustomerOrder
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        CustomerOrderForm.selectedID = 0
        CustomerOrderForm.enableControl(True)
        CustomerOrderForm.loadTerm()
        CustomerOrderForm.loadPaymentType()
        CustomerOrderForm.getCustomerList("")
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


        CustomerOrderForm.enableControl(True)
        CustomerOrderForm.btnSave.Text = "Save"
        CustomerOrderForm.btnSaveAndPrint.Text = "Save and Print"
        CustomerOrderForm.dgvProd.Visible = True
        CustomerOrderForm.gpFields.Enabled = True
        CustomerOrderForm.btnSave.Visible = True
        CustomerOrderForm.btnSaveAndPrint.Visible = True
        CustomerOrderForm.btnCheck.Visible = False
        CustomerOrderForm.btnApprove.Visible = False
        CustomerOrderForm.ShowDialog()

        'autocompleteCustomer()
    End Sub

    Private Sub CustomerOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList("")
    End Sub

    Public Sub loadList(ByVal query As String)
        dgvProd.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select * from customer_orders order by id desc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")

                    Dim date_issue As String = Convert.ToDateTime(.dr("date_issue")).ToString("MM-dd-yy")
                    Dim customer As String = New DatabaseConnect().get_by_id("company", .dr("customer_id"), "company")
                    Dim invoice As String = .dr("invoice_no")
                    Dim amount As String = Val(.dr("amount")).ToString("N2")
                    Dim amount_paid As String = Val(.dr("amount_paid")).ToString("N2")
                    Dim payment_status As String = .dr("payment_status")
                    Dim delivery_status As String = .dr("delivery_status")
                    Dim terms As String = .dr("payment_terms")
                    Dim paid As String = .dr("paid")
                    Dim delivered_by As String = .dr("delivered_by")
                    Dim received_by As String = .dr("received_by")

                    Select Case delivery_status
                        Case "0"
                            delivery_status = "Voided"
                        Case "1"
                            delivery_status = "Delivered"
                    End Select


                    Dim row As String() = New String() {id, date_issue, customer, invoice, amount, amount_paid, payment_status, delivery_status, paid, delivered_by, received_by}
                    dgvProd.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvProd.Rows
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

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvProd.SelectedRows.Count = 1 Then
            Dim id As Integer = 0
            id = CInt(dgvProd.SelectedRows(0).Cells(0).Value)
            CustomerOrderForm.selectedID = CInt(dgvProd.SelectedRows(0).Cells(0).Value)
            CustomerOrderForm.btnSave.Text = "Update"
            CustomerOrderForm.btnSaveAndPrint.Text = "Update and Print"
            CustomerOrderForm.getCustomerList("")
            CustomerOrderForm.loadPaymentType()
            CustomerOrderForm.loadTerm()
            CustomerOrderForm.loadToUpdateInfo(id)
            CustomerOrderForm.toloadproductinfo(id)
            CustomerOrderForm.enableControl(False)
            'LedgerForm.gpFields.Enabled = False
            CustomerOrderForm.btnSave.Visible = False
            CustomerOrderForm.btnSaveAndPrint.Visible = False
            CustomerOrderForm.btnCheck.Visible = True
            CustomerOrderForm.btnApprove.Visible = True
            CustomerOrderForm.ShowDialog()
        Else
            CustomerOrderForm.selectedID = 0
            MsgBox("Please select transaction!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProd.SelectedRows.Count = 1 Then
            Dim id As String = dgvProd.SelectedRows(0).Cells(0).Value
            Dim customer As String = dgvProd.SelectedRows(0).Cells(2).Value
            Dim invoice As String = dgvProd.SelectedRows(0).Cells("invoice_no").Value

            Dim yesno As Integer = MsgBox("Are you sure you want to void this transaction ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If yesno = MsgBoxResult.Yes Then
                Dim dbdelete As New DatabaseConnect
                With dbdelete
                    .update_where("customer_orders", id, "delivery_status", 0)
                    .update_where("customer_orders", id, "updated_at", "'" & DateTime.Now.ToString & "'")
                    .cmd.Dispose()
                    .con.Close()
                End With
                MsgBox(invoice & " Successfully voided.", MsgBoxStyle.Critical)
                loadList("")
            End If

        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        btnPrint.Text = "loading.."
        If dgvProd.SelectedRows.Count = 1 Then
            Dim id As Integer = dgvProd.SelectedRows(0).Cells("id").Value
            'Dim cr As New COReport
            'cr.RecordSelectionFormula = "{ledger.id} = " & id
            'ReportViewer.Enabled = True
            'ReportViewer.CrystalReportViewer1.ReportSource = cr
            'ReportViewer.CrystalReportViewer1.Refresh()
            'ReportViewer.CrystalReportViewer1.RefreshReport()
            'ReportViewer.ShowDialog()
            Dim path As String = Application.StartupPath & "\co.html"
            'Dim filter() As String = {"sample1", "sample2"}
            Try
                Dim code As String = generatePrint(id)
                Dim myWrite As System.IO.StreamWriter
                myWrite = IO.File.CreateText(path)
                myWrite.WriteLine(code)
                myWrite.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Dim proc As New System.Diagnostics.Process()
            proc = Process.Start(path, "")

        Else
            MsgBox("Please select one record before you print.", MsgBoxStyle.Critical)
        End If
        btnPrint.Enabled = True
        btnPrint.Text = "Print"
    End Sub


    Public Function generatePrint(ByVal id As Integer)
        Dim checked_by As Integer = New DatabaseConnect().get_by_id("customer_orders", id, "checked_by")
        Dim checked_by_val As String = ""
        If checked_by > 0 Then
            checked_by_val = New DatabaseConnect().get_by_id("users", checked_by, "first_name") & " " & New DatabaseConnect().get_by_id("users", checked_by, "middle_initial") &
        " " & New DatabaseConnect().get_by_id("users", checked_by, "surname")
        Else
            checked_by_val = ""
        End If

        Dim approve_by As Integer = New DatabaseConnect().get_by_id("customer_orders", id, "approved_by")
        Dim approve_by_val As String = ""
        If approve_by > 0 Then
            approve_by_val = New DatabaseConnect().get_by_id("users", approve_by, "first_name") & " " & New DatabaseConnect().get_by_id("users", approve_by, "middle_initial") &
        " " & New DatabaseConnect().get_by_id("users", approve_by, "surname")
        Else
            approve_by_val = ""
        End If

        Dim result As String = ""
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select * from customer_orders where ID = " & id & " order by id desc")
            If .dr.Read Then
                'Dim counter_no As String = .dr.GetValue(1)
                Dim date_issue As String = Convert.ToDateTime(.dr("date_issue")).ToString("MM-dd-yy")
                Dim invoice_no As String = .dr("invoice_no")
                Dim amount As String = Val(.dr("amount"))
                Dim paid As Boolean = CBool(.dr("paid"))


                Dim bank_details As String = ""
                Dim bank_details_label As String = "Bank Details:"
                Dim due_date As String = .dr("payment_due_date")
                Dim due_date_label As String = "Due Date:"


                Dim customer As Integer = CInt(.dr("customer_id"))
                Dim customer_val As String = ""
                Dim customer_address As String = ""
                Dim contact_person As String = ""
                Dim customer_city As String = ""
                Dim fax_tel As String = ""
                Dim db2 As New DatabaseConnect
                With db2
                    .selectByQuery("Select company,address,city,fax_tel,contact_person from company where ID = " & customer)
                    If .dr.Read Then
                        customer_val = .dr.GetValue(0)
                        customer_address = .dr.GetValue(1)
                        customer_city = .dr.GetValue(2)
                        fax_tel = .dr.GetValue(3)
                        contact_person = .dr.GetValue(4)
                        'LedgerForm.cbCustomer.SelectedIndex = LedgerForm.cbCustomer.FindStringExact(customer_val)
                        'LedgerForm.cbCustomer.Text = customer_val
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                End With


                Dim term_ As Integer = CInt(.dr("payment_terms"))
                Dim remarks As String = .dr("remarks")
                Dim paid_val As String = ""
                If paid = True Then
                    paid_val = "Yes"
                Else
                    paid_val = "No"
                End If

                'LedgerForm.dtpPaid.Value = date_paid
                'LedgerForm.txtBankDetails.Text = bank_details
                'LedgerForm.dtpCheckDate.Value = check_date



                Dim payment_type As Integer = If(IsDBNull(.dr("payment_type")), 0, Val(.dr("payment_type")))
                Dim payment_type_val As String = ""
                Select Case payment_type
                    Case 0
                        payment_type_val = "Cash"
                        bank_details = ""

                        due_date = ""
                        bank_details_label = ""

                        due_date_label = ""
                    Case 1
                        payment_type_val = "C.O.D"
                    Case 2
                        payment_type_val = "Credit"
                        bank_details = ""

                        due_date = ""
                        bank_details_label = ""

                        due_date_label = ""
                    Case 3
                        payment_type_val = "Post Dated"
                End Select
                'LedgerForm.txtRemarks.Text = remarks
                Dim deliverby As String = .dr("delivered_by")
                Dim receiveby As String = .dr("received_by")
                Dim grand_total As Double = 0
                Dim table_content As String = ""
                Dim dbprod As New DatabaseConnect()
                With dbprod
                    .selectByQuery("Select distinct pu.id,pu.barcode,p.description,cop.quantity,b.name as brand, u.name as unit,c.name as color,pu.price,cop.less,cop.sell_price,cop.total_amount,ps.qty as stock from ((((((customer_order_products as cop
                    Left Join product_unit as pu ON pu.id = cop.product_unit_id)
                    Left Join products as p on p.id = pu.product_id)
                    Left Join brand as b on b.id = pu.brand)
                    Left Join unit as u on u.id = pu.unit)
                    Left Join color as c on c.id = pu.color)
                    Left Join product_stocks as ps on ps.product_unit_id = pu.id)
                    where cop.customer_order_id = " & id)
                    If .dr.HasRows Then
                        While .dr.Read
                            Dim tr As String = "<tr>"
                            Dim p_id As String = .dr("id")
                            Dim barcode As String = .dr("barcode")
                            Dim qty As String = .dr("quantity")
                            Dim desc As String = .dr("description")
                            Dim brand As String = .dr("brand")
                            Dim unit As String = .dr("unit")
                            Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                            Dim price As String = Math.Round(Val(.dr("price")), 2).ToString("N2")
                            Dim less As String = .dr("less")
                            Dim sell_price As String = Math.Round(Val(.dr("sell_price")), 2).ToString("N2")
                            Dim total_amount As String = Math.Round(Val(.dr("total_amount")), 2).ToString("N2")
                            Dim stock As String = Val(.dr("stock"))

                            grand_total += CDbl(total_amount)
                            tr = tr & "<td>" & barcode & "</td>"
                            tr = tr & "<td>" & qty & "</td>"
                            tr = tr & "<td>" & desc & "</td>"
                            tr = tr & "<td>" & brand & "</td>"
                            tr = tr & "<td>" & unit & "</td>"
                            tr = tr & "<td>" & color & "</td>"
                            tr = tr & "<td>" & sell_price & "</td>"
                            tr = tr & "<td>" & total_amount & "</td>"
                            tr = tr & "</tr>"
                            table_content = table_content & tr
                        End While
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                End With

                Dim page As String = "<div id='header' style='text-align:center;'>
				<!-- <img src='header.png' width='180'>
				<p style='font-family:Arial;margin:1px;font-size:8pt;'>42 K Roosevelt Ave, Quezon City </p>
				<p style='font-family:Arial;margin:1px;font-size:8pt;'>Telefax: 411-5274. Globe:0917-132-1241</p>
				<p style='font-family:Arial;margin:1px;font-size:8pt;'>Email:purchasing.jmcj@gmail.com</p>-->
				<p style='font-family:Arial black;font-weight:bold;margin:1px;font-size:15pt;'>CUSTOMER ORDER</p>
			</div>
			<div id='fieldset'>
				<table class='table_fieldset'>
					<tr>
						<td><label><strong> Customer: </strong></label></td>
						<td><label>" & customer_val & " </label></td>
						<td><label><strong> Invoice #: " & invoice_no & " </strong></label></td>
						<td>Date: " & date_issue & "</td>
					</tr>
					<tr>
						<td><label><strong> Address </strong></label></td>
						<td><label> " & customer_address & " </label></td>
						<td colspan='2'><label><strong> ATTN: " & contact_person & "</strong></label></td>
					</tr>
					<tr>
						<td colspan='2'><label><strong> Delivered To: " & receiveby & " </strong></label></td>
						<td colspan='2'><label><strong> Delivered By: " & deliverby & "</strong></label></td>
					</tr>
				<table>
				<br>
				<table class='table_fieldset'>
					<tr>
						<td><strong>Payment Type:</strong></td>
						<td>" & payment_type_val & "</td>
						<td><strong>Terms:</strong></td>
						<td>" & term_ & " Days </td>
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
					<td style='color:red'><strong>" & grand_total & "</strong></td>
				</tr>
			  </tbody>
			</table>
			<br><br><br><br><br><br><br><br><br><br><br><br>
			<table id='footer' class='table_fieldset'>
				<tbody>
					<tr>
						<td width='120' colspan='1' style='text-align:right;'><strong>Remaining Balance:</strong></td>
						<td colspan='2' style='color:red'><strong>0.00</strong></td>
					</tr>
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

                result = "<style>
    .table_pager {
		Font-family: Arial;
		border-collapse: collapse;
		width: 100%;
		
	}

	.table_pager td, .table_pager th {
        border: 0px solid #dddddd;
		Text-align: Left;
		
		Font-Size:  8pt;
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
		Font-Size:  8pt;
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
            End If
        End With
        Return result
    End Function
End Class