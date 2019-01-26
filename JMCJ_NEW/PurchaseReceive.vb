Public Class PurchaseReceive
    Public selectedSupplier As Integer = 0
    Public selectedPR As Integer = 0
    Public selectedDR As Integer = 0
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        btnAddNew.Enabled = False
        PurchaseReceiveForm.clearFields()
        PurchaseReceiveForm.initialize()


        PurchaseReceiveForm.btnSave.Enabled = True
        PurchaseReceiveForm.btnSaveAndPrint.Enabled = True
        PurchaseReceiveForm.dgvProd.Enabled = True
        PurchaseReceiveForm.gpFields.Enabled = True
        PurchaseReceiveForm.gpEnterBarcode.Enabled = True
        PurchaseReceiveForm.gpEnterProduct.Enabled = True
        PurchaseReceiveForm.ShowDialog()
        btnAddNew.Enabled = True
    End Sub

    Public Sub loadPR(ByVal query As String)
        dgvPR.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            If Trim(query) = "" Then
                .selectByQuery("Select * from purchase_receive order by pr_date desc")
            Else
                .selectByQuery(query)
            End If
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim date_issue As String = Convert.ToDateTime(.dr("pr_date")).ToString("MM-dd-yyyy")
                    Dim pr_no As String = .dr("pr_no")
                    Dim po_no As String = New DatabaseConnect().get_by_id("purchase_orders", Val(.dr("purchase_order_id")), "po_no")
                    Dim dr_no As String = If(IsDBNull(.dr("dr_no")), "", .dr("dr_no"))
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
                    Dim row As String() = New String() {id, date_issue, pr_no, po_no, dr_no, supplier_name, total_amount, processed_by, delivery_status}
                    dgvPR.Rows.Add(row)
                End While

                For Each row As DataGridViewRow In dgvPR.Rows
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

    Private Sub PurchaseReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autocompleteSupplier()
        loadPRSelection()
        loadDRSelection()
        getMonth()
        getYear()
        loadPR("")

        'check user access
        If ModelFunction.check_access(10, 1) = 1 Then
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
        btnView.Enabled = False
        If dgvPR.SelectedRows.Count = 0 Then
            MsgBox("Please select one transction to view!", MsgBoxStyle.Critical)
            btnView.Enabled = True
            Exit Sub
        End If
        Dim pr_id As Integer = dgvPR.SelectedRows(0).Cells("id").Value
        PurchaseReceiveForm.initialize()
        PurchaseReceiveForm.loadInfo(pr_id)
        PurchaseReceiveForm.btnSave.Enabled = False
        PurchaseReceiveForm.btnSaveAndPrint.Enabled = False
        PurchaseReceiveForm.dgvProd.Enabled = False
        PurchaseReceiveForm.gpFields.Enabled = False
        PurchaseReceiveForm.gpEnterBarcode.Enabled = False
        PurchaseReceiveForm.gpEnterProduct.Enabled = False
        PurchaseReceiveForm.ShowDialog()
        btnView.Enabled = True
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click
        If dgvPR.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim pr_id As Integer = dgvPR.SelectedRows(0).Cells(0).Value
        Dim d_status As String = dgvPR.SelectedRows(0).Cells("delivery_status").Value

        'If d_status = "Received" Then
        '    MsgBox("Already Received.This transaction cannot be voided!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        Dim yn As Integer = MsgBox("Are you sure you want to void this transaction ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Me.Text)
        If yn = MsgBoxResult.Yes Then
            'void purchase receive
            Dim db As New DatabaseConnect
            db.update_where("purchase_receive", pr_id, "delivery_status", 0)
            db.cmd.Dispose()
            db.con.Close()

            'void decrease stock
            Dim dbprod As New DatabaseConnect()
            With dbprod
                .selectByQuery("Select product_unit_id from purchase_receive_products where purchase_receive_id = " & pr_id)
                If .dr.HasRows Then
                    While .dr.Read
                        Dim product_unit_id As Integer = .dr("product_unit_id")
                        'decrease stock
                        Dim decreasestock As New DatabaseConnect
                        With decreasestock
                            Dim temp As String = New DatabaseConnect().get_by_val("product_stocks", product_unit_id, "product_unit_id", "qty")
                            Dim cur_stock As Integer = Val(temp)
                            Dim qty As Integer = New DatabaseConnect().get_by_val("purchase_receive_products", product_unit_id, "product_unit_id", "quantity")
                            cur_stock = cur_stock - Val(qty)

                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "UPDATE product_stocks set [qty] = " & cur_stock & " where product_unit_id = " & product_unit_id
                            .cmd.ExecuteNonQuery()
                            .cmd.Dispose()
                            .con.Close()
                        End With
                    End While
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With

            MsgBox("Purchase Receive Successfully Void.", MsgBoxStyle.Information)
            loadPR("")
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvPR.SelectedRows.Count = 0 Then
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        btnPrint.Enabled = False
        Dim pr_id As Integer = dgvPR.SelectedRows(0).Cells(0).Value
        Dim path As String = Application.StartupPath & "\pr_report.html"

        Try
            Dim code As String = generatePrint(pr_id)
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception

        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Enabled = True
    End Sub

    Public Function generatePrint(ByVal pr_id As Integer) As String
        Dim result As String = ""

        Dim po_id As Integer = New DatabaseConnect().get_by_val("purchase_receive", pr_id, "id", "purchase_order_id")
        Dim po_no As String = New DatabaseConnect().get_by_id("purchase_orders", po_id, "po_no")
        Dim supplier_id As Integer = getSupplier(pr_id)
        Dim pr_no As String = New DatabaseConnect().get_by_id("purchase_receive", pr_id, "pr_no")
        Dim dr_no As String = New DatabaseConnect().get_by_id("purchase_receive", pr_id, "dr_no")
        Dim supplier = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
        Dim term As String = New DatabaseConnect().get_by_id("purchase_receive", pr_id, "terms")
        Dim term_val As String = ""
        Select Case term
            Case "15"
                term_val = "15 days"
            Case "30"
                term_val = "30 days"
            Case "0"
                term_val = ""
        End Select

        Dim payment_type As Integer = New DatabaseConnect().get_by_id("purchase_receive", pr_id, "payment_type")
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

        Dim pr_date As String = New DatabaseConnect().get_by_id("purchase_receive", pr_id, "pr_date")
        Dim eta As String = New DatabaseConnect().get_by_id("purchase_receive", pr_id, "eta")
        Dim ata As String = New DatabaseConnect().get_by_id("purchase_receive", pr_id, "ata")
        Dim total_amount As String = Val(New DatabaseConnect().get_by_id("purchase_receive", pr_id, "total_amount")).ToString("N2")

        Dim table_content As String = ""
        Dim dbprod As New DatabaseConnect()
        With dbprod
            .selectByQuery("select distinct pu.id,pu.barcode,p.description,b.name as brand,u.name as unit,c.name as color,pop.quantity,pop.unit_cost,pop.total_amount,ps.qty as stock
                        FROM ((((((purchase_receive_products as pop
                        INNER JOIN product_unit as pu ON pu.id = pop.product_unit_id)
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = pop.unit_id)
                        LEFT JOIN color as c ON c.id = pu.color)
                        INNER JOIN products as p ON p.id = pu.product_id)
                        left join product_stocks as ps on ps.product_unit_id = pu.id)
                        where pop.purchase_receive_id = " & pr_id)
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
                    tr = tr & "<td>" & unit & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & desc & "</td>"
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

<h2>Purchase Receive</h2>
<div id='fieldset'>
	<table>
		<tr>
			<td width='150'><label><strong>Supplier: </strong></label></td>
			<td><label>" & supplier & "</label></td>
			
			<td width='150'><label><strong>Date Issue: </strong></label></td>
			<td><label>" & pr_date & "</label></td>
				
			<td><label><strong>ETA:	</strong></label></td>
			<td><label>" & eta & "</label></td>
		</tr>
		<tr>
			<td width='150'><label><strong>PR Number: </strong></label></td>
			<td><label>" & pr_no & "</label></td>
			
			<td><label><strong>Terms: </strong></label></td>
			<td><label>" & term_val & "</label></td>
			
			<td><label><strong>ATA:	</strong></label></td>
			<td><label>" & ata & "</label></td>
		
		</tr>

        <tr>
			<td width='150'><label><strong>PO Number: </strong></label></td>
			<td><label>" & po_no & "</label></td>
			
			<td><label><strong>Payment Type: </strong></label></td>
			<td><label>" & payment_val & "</label></td>
		</tr>
		
		<tr>
			<td><label><strong>DR Number: </strong></label></td>
			<td><label>" & dr_no & "</label></td>
		</tr>
	<table>
</div>
<br>
<table>
  <thead>
  <tr>
	<th>Barcode</th>
	<th>Qty</th>
	<th>Unit</th>
	<th>Brand</th>
	<th>Color</th>
	<th>Description</th>
	<th>Unit Cost</th>
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

</body>
</html>
"
        Return result
    End Function

    Private Function getSupplier(ByVal pr_id As Integer) As Integer
        Dim res As Integer = 0
        Dim dbpo As New DatabaseConnect
        With dbpo
            .selectByQuery("Select supplier from purchase_receive where id = " & pr_id)
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

        Dim supplier As New DatabaseConnect
        With supplier
            .selectByQuery("Select distinct supplier_name from suppliers  where status = 1")
            While .dr.Read
                MySource.Add(.dr.GetValue(0))
            End While
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    Public Sub loadDRSelection()
        cbDRNo.DataSource = Nothing
        cbDRNo.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,dr_no from purchase_receive where delivery_status <> 0 order by pr_date desc")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select DR Number")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = CInt(.dr("id"))
                    Dim dr As String = .dr("dr_no")
                    If dr <> "" Then
                        comboSource.Add(id, dr)
                    End If

                End While
            End If
            cbDRNo.DataSource = New BindingSource(comboSource, Nothing)
            cbDRNo.DisplayMember = "Value"
            cbDRNo.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub


    Public Sub loadPRSelection()
        cbPRNo.DataSource = Nothing
        cbPRNo.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,pr_no from purchase_receive where delivery_status <> 0 order by pr_date desc")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select PR Number")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = CInt(.dr("id"))
                    Dim pr As String = .dr("pr_no")
                    comboSource.Add(id, pr)
                End While
            End If
            cbPRNo.DataSource = New BindingSource(comboSource, Nothing)
            cbPRNo.DisplayMember = "Value"
            cbPRNo.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
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

    Public Sub getYear()
        cbYear.Items.Clear()
        cbYear.Items.Add("All")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT distinct YEAR(pr_date) FROM purchase_receive where delivery_status <> 0 order by YEAR(pr_date) DESC")
            While .dr.Read
                cbYear.Items.Add(.dr.GetValue(0))
            End While
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
            cbYear.SelectedIndex = 0
        End With
    End Sub

    Private Sub cbPRNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPRNo.SelectedIndexChanged
        If cbPRNo.SelectedIndex > 0 Then
            cbPRNo.BackColor = Drawing.Color.White
            Dim key As String = DirectCast(cbPRNo.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbPRNo.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPR = key

        Else
            selectedPR = 0
        End If
    End Sub

    Private Sub cbDRNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDRNo.SelectedIndexChanged
        If cbDRNo.SelectedIndex > 0 Then
            cbDRNo.BackColor = Drawing.Color.White
            Dim key As String = DirectCast(cbDRNo.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbDRNo.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedDR = key

        Else
            selectedDR = 0
        End If
    End Sub

    Private Sub txtSupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupplier.KeyDown
        If txtSupplier.Text.Length > 0 And e.KeyCode = Keys.Enter Then
            txtSupplier.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtSupplier.Text.ToLower())
            selectedSupplier = New DatabaseConnect().get_id("suppliers", "supplier_name", txtSupplier.Text)

        Else
            selectedSupplier = 0
        End If
    End Sub

    Private Sub txtSupplier_Leave(sender As Object, e As EventArgs) Handles txtSupplier.Leave
        If txtSupplier.Text.Length > 0 Then
            selectedSupplier = New DatabaseConnect().get_id("suppliers", "supplier_name", txtSupplier.Text)

        Else
            selectedSupplier = 0
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Dim query As String = "Select * from purchase_receive and delivery_status >- 1"

        If txtSupplier.Text <> "" And selectedSupplier > 0 Then
            query = query & " and supplier = " & selectedSupplier
        End If

        If cbPRNo.SelectedIndex > 0 And selectedPR > 0 Then
            query = query & " and id = " & selectedPR
        End If

        If cbDRNo.SelectedIndex > 0 And selectedDR > 0 Then
            query = query & " and id = " & selectedDR
        End If

        If cbMonth.Text <> "All" Then
            query = query & " and MONTH(pr_date) = " & monthToNumber(cbMonth.Text)
        End If

        If cbYear.Text <> "All" Then
            query = query & " and YEAR(pr_date) = " & cbYear.Text
        End If

        query = query & " order by pr_date desc"
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
End Class