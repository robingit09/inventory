﻿Public Class PurchaseReturn
    Public selectedSupplier As Integer = 0
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        PurchaseReturnForm.initialize()
        PurchaseReturnForm.ShowDialog()
        btnAddNew.Enabled = True
    End Sub

    Public Sub loadList(ByVal query As String)
        dgvPReturn.Rows.Clear()
        Dim dbPR As New DatabaseConnect
        With dbPR
            If query = "" Then
                .selectByQuery("Select * from purchase_return order by id desc")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim date_issue As String = Convert.ToDateTime(.dr("pr_date")).ToString("MM-dd-yy")
                    Dim pr_no As String = .dr("pr_no")
                    Dim supplier_id As Integer = CInt(.dr("supplier_id"))
                    Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim issue_by As String = .dr("issued_by")
                    issue_by = New DatabaseConnect().get_by_id("users", issue_by, "first_name") & " " & New DatabaseConnect().get_by_id("users", issue_by, "surname")

                    Dim status As String = ""
                    Select Case .dr("status")
                        Case "0"
                            status = "Voided"
                        Case "1"
                            status = "Active"
                        Case Else
                            status = ""
                    End Select
                    Dim row As String() = New String() {id, date_issue, pr_no, supplier_name, total_amount, issue_by, status}
                    dgvPReturn.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvPReturn.Rows
                    If row.Cells("status").Value = "Voided" Then
                        row.DefaultCellStyle.BackColor = Color.OrangeRed
                    End If
                Next
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub PurchaseReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList("")
        autocompleteSupplier()
        getMonth()
        getYear()

        'check user access
        If ModelFunction.check_access(13, 1) = 1 Then
            btnAddNew.Enabled = True
            btnView.Enabled = True
            btnVoid.Enabled = True
        Else
            btnAddNew.Enabled = False
            btnView.Enabled = False
            btnVoid.Enabled = False
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If dgvPReturn.SelectedRows.Count = 1 Then
            Dim id As Integer = dgvPReturn.SelectedRows(0).Cells("id").Value
            PurchaseReturnForm.initialize()
            PurchaseReturnForm.toLoadInfo(id)
            PurchaseReturnForm.enableControl(False)
            PurchaseReturnForm.ShowDialog()
        Else
            MsgBox("Please select one record to view!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvPReturn.SelectedRows.Count = 1 Then
            Dim id As Integer = dgvPReturn.SelectedRows(0).Cells("id").Value

            Dim status As String = dgvPReturn.SelectedRows(0).Cells("status").Value
            If status = "Voided" Then
                MsgBox("The selected transaction is already voided!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim yesno As Integer = MsgBox("Are you sure you want to void this transaction ?", MsgBoxStyle.YesNo + MsgBoxStyle.Information)
            If yesno = MsgBoxResult.Yes Then
                'void revert stock
                Dim dbprod As New DatabaseConnect()
                With dbprod
                    .selectByQuery("Select product_unit_id,qty from purchase_return_products where purchase_return_id = " & id)
                    If .dr.HasRows Then
                        While .dr.Read
                            Dim product_unit_id As Integer = .dr("product_unit_id")
                            Dim qty As Integer = CInt(.dr("qty"))
                            'revert stock
                            ModelFunction.update_stock(product_unit_id, qty, "+")


                        End While
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                End With
                Dim dbvoid As New DatabaseConnect
                With dbvoid
                    .update_where("purchase_return", id, "status", 0)
                    .cmd.Dispose()
                    .con.Close()
                    MsgBox("Purchase Return Successfully Voided.", MsgBoxStyle.Information)
                    loadList("")
                End With
            End If
        Else
            MsgBox("Please select one record to void!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        If dgvPReturn.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        btnPrint.Enabled = False
        Dim id As Integer = dgvPReturn.SelectedRows(0).Cells(0).Value
        Dim path As String = Application.StartupPath & "\preturn_report.html"

        Try
            Dim code As String = generatePrint(id)
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

    Public Function generatePrint(ByVal pr_id As Integer) As String
        Dim result As String = ""

        Dim supplier As String = getSupplier(pr_id)
        Dim pr_no As String = New DatabaseConnect().get_by_id("purchase_return", pr_id, "pr_no")
        Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier, "supplier_name")
        Dim address As String = New DatabaseConnect().get_by_id("suppliers", supplier, "address") & " " & New DatabaseConnect().get_by_id("suppliers", supplier, "city")
        'Dim contact_person As String = New DatabaseConnect().get_by_id("suppliers", supplier, "contact_person")
        'Dim delivered_to As String = New DatabaseConnect().get_by_id("purchase_orders", pr_id, "delivered_to")
        'Dim delivered_by As String = New DatabaseConnect().get_by_id("purchase_orders", pr_id, "delivered_by")
        Dim reason As String = New DatabaseConnect().get_by_id("purchase_return", pr_id, "reason")
        Dim user_id As String = New DatabaseConnect().get_by_id("purchase_return", pr_id, "issued_by")
        Dim issue_by As String = New DatabaseConnect().get_by_id("users", user_id, "first_name")



        Dim pr_date As String = New DatabaseConnect().get_by_id("purchase_return", pr_id, "pr_date")
        Dim pdate As DateTime = Convert.ToDateTime(pr_date)
        pr_date = pdate.ToString("MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture)


        Dim total_amount As String = Val(New DatabaseConnect().get_by_id("purchase_return", pr_id, "total_amount")).ToString("N2")

        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery("select distinct pu.id,pu.barcode,p.description,b.name as brand,u.name as unit,c.name as color,pop.qty,pop.unit_cost,pop.total_cost,ps.qty as stock
                        FROM ((((((purchase_return_products as pop
                        INNER JOIN product_unit as pu ON pu.id = pop.product_unit_id)
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = pu.unit)
                        LEFT JOIN color as c ON c.id = pu.color)
                        INNER JOIN products as p ON p.id = pu.product_id)
                        left join product_stocks as ps on ps.product_unit_id = pu.id)
                        where pop.purchase_return_id = " & pr_id)
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim id As Integer = .dr("id")
                    Dim barcode As String = .dr("barcode")
                    Dim qty As Integer = .dr("qty")
                    Dim desc As String = .dr("description")
                    Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                    Dim unit As String = .dr("unit")
                    Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                    Dim cost As String = Val(.dr("unit_cost")).ToString("N2")
                    Dim total As String = Val(.dr("total_cost")).ToString("N2")
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
				<p style='font-family:Arial black;font-weight:bold;margin:1px;font-size:15pt;'>PURCHASE RETURN</p>
			</div>
			<div id='fieldset'>
				<table class='table_fieldset'>
					<tr>
						<td><label><strong> Supplier: </strong></label></td>
						<td><label>" & supplier_name & "</label></td>
						<td><label><strong> PR #: " & pr_no & " </strong></label></td>
						<td>Date: " & pr_date & " </td>
					</tr>
					<tr>
						<td><strong>Address:</strong></td>
						<td colspan='3'>" & address & "</td>
					</tr>
					<tr>
						<td><label><strong> Reason: </strong></label></td>
						<td><label> " & reason & " </label></td>
						<td colspan='2'><label><strong> Issued By: " & issue_by & "</strong></label></td>
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

    Public Function getSupplier(ByVal po_id As Integer) As Integer
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
            .selectByQuery("SELECT distinct YEAR(pr_date) FROM purchase_return where status > -1 order by YEAR(pr_date) DESC")
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

    Private Sub txtSupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupplier.KeyDown
        If txtSupplier.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            txtSupplier.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplier.Text.ToLower())
            selectedSupplier = New DatabaseConnect().get_id("suppliers", "supplier_name", txtSupplier.Text)
            'MsgBox(selectedCustomer)
        Else
            selectedSupplier = 0
        End If
    End Sub

    Private Sub txtSupplier_Leave(sender As Object, e As EventArgs) Handles txtSupplier.Leave
        If txtSupplier.Text.Length > 0 Then
            selectedSupplier = New DatabaseConnect().get_id("suppliers", "supplier_name", txtSupplier.Text)
            'MsgBox(selectedCustomer)
        Else
            selectedSupplier = 0
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        btnFilter.Enabled = False
        Dim query As String = "Select * from purchase_return where status > -1 "
        If txtSupplier.Text <> "" And selectedSupplier > 0 Then
            query = query & " and supplier_id = " & selectedSupplier
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(pr_date) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(pr_date) = " & cbYear.Text
        End If

        query = query & "  order by id desc"
        loadList(query)
        btnFilter.Enabled = True
    End Sub
End Class