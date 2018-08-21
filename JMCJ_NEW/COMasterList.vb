Public Class COMasterList
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim path As String = Application.StartupPath & "\co_master.html"

        Try
            Dim code As String = generatePrint()
            Dim myWrite As System.IO.StreamWriter
            myWrite = IO.File.CreateText(path)
            myWrite.WriteLine(code)
            myWrite.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Dim proc As New System.Diagnostics.Process()
        proc = Process.Start(path, "")
    End Sub

    Public Function generatePrint() As String
        Dim table_content As String = ""
        Dim total_amount As Double = 0
        Dim dbledger As New DatabaseConnect()
        With dbledger
            .selectByQuery("SELECT c.company,l.date_issue,l.amount,l.paid,l.floating,l.date_paid,l.bank_details,l.check_date,
                l.payment_type,l.ledger FROM ledger as l 
                inner join company as c on c.id = l.customer")
            Dim num As Integer = 0
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    Dim customer As String = .dr("company")
                    Dim date_issue As String = .dr("date_issue")
                    Dim amount As Double = Val(.dr("amount")).ToString("N2")
                    Dim ispaid As String = If(.dr("paid") = True, "Yes", "No")
                    Dim isfloating As String = If(.dr("floating") = True, "Yes", "No")
                    Dim date_paid As String = .dr("date_paid")
                    Dim bank_details As String = .dr("bank_details")
                    Dim check_date As String = .dr("check_date")
                    Dim payment_type As String = .dr("payment_type")
                    Dim type As String = .dr("ledger")

                    Select Case payment_type
                        Case "0"
                            payment_type = "Cash"
                        Case "1"
                            payment_type = "C.O.D"
                        Case "2"
                            payment_type = "Credit"
                        Case "3"
                            payment_type = "Post Dated"
                        Case Else
                            payment_type = ""
                    End Select

                    Select Case type
                        Case "0"
                            type = "Charge"
                        Case "1"
                            type = "Delivery"
                        Case Else
                            type = ""
                    End Select
                    tr = tr & "<td>" & (num + 1) & "</td>"
                    tr = tr & "<td>" & customer & "</td>"
                    tr = tr & "<td>" & date_issue & "</td>"
                    tr = tr & "<td>" & Val(amount).ToString("N2") & "</td>"
                    tr = tr & "<td>" & ispaid & "</td>"
                    tr = tr & "<td>" & isfloating & "</td>"
                    tr = tr & "<td>" & date_paid & "</td>"
                    tr = tr & "<td>" & bank_details & "</td>"
                    tr = tr & "<td>" & check_date & "</td>"
                    tr = tr & "<td>" & payment_type & "</td>"
                    tr = tr & "<td>" & type & "</td>"
                    tr = tr & "</tr>"
                    table_content = table_content & tr

                    total_amount = total_amount + Val(amount)
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
                        <p style='font-family:Arial black;margin:1px;font-size:15pt;'><strong>CUSTOMER ORDER </strong></p><small>Master List</small>
                </div>
                <!--<div id='fieldset'>
					<table class='table_fieldset'>
						<tr>
							<td><label><strong> Supplier: </strong></label></td>
							<td><label>Patrick Pintados Maputi Si Terrence Shop</label></td>
							<td><label><strong> PO #: PO-PPS1-000003 </strong></label></td>
							<td>Date: 07-28-2018 </td>
						</tr>
						<tr>
							<td><label><strong> Address </strong></label></td>
							<td><label> Nakita ko na at di ko pa din matapuan street Quezon City  </label></td>
							<td colspan='2'><label><strong> ATTN: Dao Ming Zhie</strong></label></td>
							
						</tr>
						<tr>
							<td colspan='2'><label><strong> Delivered To: Victor Magtanggol </strong></label></td>
							<td colspan='2'><label><strong> Delivered By: Lee Gonzales </strong></label></td>
							
						</tr>
						
					<table>
				</div>-->

                <br>
                    <table class='table_fieldset'>
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Customer</th>
                                <th>Date</th>
                                <th>Amount</th>
                                <th>Is Paid</th>
                                <th>Is Floating</th>
                                <th>Date Paid</th>
                                <th>Bank Details</th>
                                <th>Check Date</th>
                                <th>Payment</th>
                                <th>Ledger</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                " & table_content & "
                            </tr>
                            <tr>
                                <td colspan='10' style='text-align:right;'><strong>Grand Total</strong></td>
                                <td style='color:red'><strong>" & Val(total_amount).ToString("N2") & "</strong></td>
                            </tr>
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
End Class