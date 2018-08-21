Public Class ProductReports
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

    Public Function generatePrint() As String
        Dim table_content As String = ""
        Dim total_amount As Double = 0
        Dim dbledger As New DatabaseConnect()
        With dbledger
            .selectByQuery("Select distinct p.id,pu.id as p_u_id,pu.barcode, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat,pu.status FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0")
            Dim num As Integer = 0
            If .dr.HasRows Then
                While .dr.Read
                    Dim tr As String = "<tr>"
                    'Dim id As String = .dr("id")
                    Dim p_u_id As String = .dr("p_u_id")
                    Dim barcode As String = .dr("barcode")
                    Dim desc As String = .dr("description")
                    Dim brand As String = .dr("brand")
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
                    tr = tr & "<td>" & desc & "</td>"
                    tr = tr & "<td>" & brand & "</td>"
                    tr = tr & "<td>" & unit & "</td>"
                    tr = tr & "<td>" & color & "</td>"
                    tr = tr & "<td>" & price & "</td>"
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
                                <th>Description</th>
                                <th>Brand</th>
                                <th>Unit</th>
                                <th>Color</th>
                                <th>Price</th>
                                <th>Quantity</th>
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
End Class