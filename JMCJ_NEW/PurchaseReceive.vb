Public Class PurchaseReceive
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
            .selectByQuery("Select * from purchase_receive order by pr_date desc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim date_issue As String = .dr("pr_date")
                    Dim pr_no As String = .dr("pr_no")
                    Dim po_no As String = New DatabaseConnect().get_by_id("purchase_orders", Val(.dr("purchase_order_id")), "po_no")
                    Dim dr_no As String = ""
                    Dim supplier_id As Integer = CInt(.dr("supplier"))
                    Dim supplier_name As String = New DatabaseConnect().get_by_id("suppliers", supplier_id, "supplier_name")
                    Dim total_amount As String = Val(.dr("total_amount")).ToString("N2")
                    Dim delivery_status As String = ""

                    Select Case .dr("delivery_status")
                        Case "0"
                            delivery_status = "Voided"
                        Case "1"
                            delivery_status = "Pending"
                        Case "2"
                            delivery_status = "Received"
                    End Select
                    Dim row As String() = New String() {id, date_issue, pr_no, po_no, dr_no, supplier_name, total_amount, "", delivery_status}
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
        loadPR("")
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
                        INNER JOIN unit as u ON u.id = pu.unit)
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
End Class