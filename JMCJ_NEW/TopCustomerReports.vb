Public Class TopCustomerReports
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        btnPrint.Enabled = False
        Dim path As String = Application.StartupPath & "\top_customer_reports.html"
        Dim code As String = generatePrint()


        Dim myWrite As System.IO.StreamWriter
        myWrite = IO.File.CreateText(path)
        myWrite.WriteLine(code)
        myWrite.Close()


        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
        btnPrint.Enabled = True
    End Sub

    Private Function generatePrint()
        Dim result As String = ""
        Dim table_content As String = ""

        ' get total product
        Dim total_sold As Integer = 0

        Dim dbprod As New DatabaseConnect
        With dbprod
            '.selectByQuery("Select c.id,c.company,(select sum(cop.quantity) from customer_order_products as cop inner join customer_orders as co on co.id = cop.customer_order_id where co.customer_id = c.id) as total_product from company as c
            '    where c.status <> 0 ")
            .selectByQuery("Select c.id,c.company,total_qty from company as c
                left join (select sum(cop.quantity) as total_qty,co.customer_id from customer_order_products as cop
                        inner join customer_orders as co on co.id = cop.customer_order_id group by co.customer_id) as total on total.customer_id = c.id 
                where c.status <> 0 order by total_qty desc,c.company asc")
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"

                    Dim id As Integer = .dr("id")
                    Dim company As String = .dr("company")
                    Dim total_product As String = If(IsDBNull(.dr("total_qty")), "0", .dr("total_qty"))
                    If Val(total_product) > total_sold Then
                        total_sold = Val(total_product)
                    End If
                    Dim percent As String = Val(Val(total_product) / Val(total_sold)).ToString("#0.##%")
                    'Dim contact_person As String = .dr("contact_person")
                    'Dim address As String = .dr("address")
                    'Dim city As String = .dr("city")
                    'Dim owner As String = .dr("owner_name")
                    'Dim contact1 As String = .dr("contact_number1")
                    'Dim contact2 As String = .dr("contact_number2")
                    'Dim faxtel As String = .dr("fax_tel")
                    'Dim tin As String = .dr("tin")
                    'Dim email As String = .dr("email")
                    'Dim status As String = .dr("status")
                    'Dim ledger_type As String = ""

                    'Select Case status
                    '    Case "0"
                    '        status = ""
                    '    Case "1"
                    '        status = "Rented"
                    '    Case "2"
                    '        status = "Owned"
                    'End Select
                    'Dim dbledger As New DatabaseConnect
                    'With dbledger
                    '    .selectByQuery("select top 1 ledger from ledger where customer = " & id & " order by created_at desc")
                    '    If .dr.HasRows Then
                    '        If .dr.Read Then
                    '            ledger_type = .dr("ledger")
                    '        End If
                    '    End If
                    '    .con.Close()
                    '    .dr.Close()
                    '    .cmd.Dispose()
                    'End With

                    'Select Case ledger_type
                    '    Case "0"
                    '        ledger_type = "Charge"
                    '    Case "1"
                    '        ledger_type = "Delivery"
                    'End Select

                    tr = tr & "<td>" & company & "</td>"
                    tr = tr & "<td>" & percent & "  <div style='height:40px;width:" & percent & " ; background-color:#3AE;'> " & total_product & " </div></td>"
                    'tr = tr & "<td>" & address & "</td>"
                    'tr = tr & "<td>" & city & "</td>"
                    'tr = tr & "<td>" & owner & "</td>"
                    'tr = tr & "<td>" & contact1 & "</td>"
                    'tr = tr & "<td>" & contact2 & "</td>"
                    'tr = tr & "<td>" & faxtel & "</td>"
                    'tr = tr & "<td>" & tin & "</td>"
                    'tr = tr & "<td>" & email & "</td>"
                    'tr = tr & "<td>" & status & "</td>"
                    'tr = tr & "<td>" & ledger_type & "</td>"
                    'tr = tr & "</tr>"
                    table_content = table_content & tr

                End While
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Dim percentage_label As String = ""
        For i = 0 To 100

        Next
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
<div id='header' style='text-align:center;'>
	<img src='header.png' width='180'>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>42 K Roosevelt Ave, Quezon City </p>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>Telefax: 411-5274. Globe:0917-132-1241</p>
	<p style='font-family:Arial;margin:1px;font-size:8pt;'>Email:purchasing.jmcj@gmail.com</p>
	<p style='font-family:Arial black;font-weight:bold;margin:1px;font-size:15pt;'>TOP CUSTOMERS</p>
</div>
<div id='fieldset'>
	<table>
		
	<table>
</div>
<br>
<table>
  <thead>
  <tr>
	<th width='20%'>Customer</th>
	<th style='text-align:center;'>Summary of total sold</th>
  </tr>
  </thead>
  <tbody>
    " & table_content & "
  </tbody>
</table>

</body>
</html>"
        Return result
    End Function
End Class