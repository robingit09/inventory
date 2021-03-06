﻿Public Class ProductReports

    Public selectedDesc As Integer = 0
    Public selectedBrand As Integer = 0
    Public selectedUnit As Integer = 0
    Public selectedColor As Integer = 0
    Public selectedCat As Integer = 0
    Public selectedSubCat As Integer = 0

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
        Dim query As String = "Select distinct p.id,pu.id as p_u_id,pu.barcode, p.description,b.name as brand, u.name as unit,cc.name as color,pu.price,c.name as cat,sub.name as subcat,pu.status FROM ((((((((products as p 
                INNER JOIN product_unit as pu ON p.id = pu.product_id) 
                LEFT JOIN brand as b ON b.id = pu.brand)
                INNER JOIN unit as u ON u.id = pu.unit)
                LEFT JOIN color as cc ON cc.id = pu.color)
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0"

        If Trim(txtBarcode.Text) <> "" Then
            query = query & " and pu.barcode = '" & Trim(txtBarcode.Text) & "'"
        End If

        If selectedDesc > 0 And Trim(txtProductDesc.Text) <> "" Then
            query = query & " and p.id = " & selectedDesc
        End If

        If selectedBrand > 0 Then
            query = query & " and b.id = " & selectedBrand
        End If

        If selectedUnit > 0 Then
            query = query & " and u.id = " & selectedUnit
        End If

        If selectedColor > 0 Then
            query = query & " and cc.id = " & selectedColor
        End If

        If selectedCat > 0 Then
            query = query & " and c.id = " & selectedCat
        End If

        If selectedSubCat > 0 Then
            query = query & " and sub.id = " & selectedSubCat
        End If

        query = query & " order by p.description"

        Dim table_content As String = ""
        Dim total_amount As Double = 0
        Dim dbledger As New DatabaseConnect()
        With dbledger
            .selectByQuery(query)
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

    Private Sub ProductReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        autocompleteDesc()
        loadBrand()
        loadUnit()
        loadColor()
        loadCat()
        loadSubCat()
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
            If txtProductDesc.TextLength > 0 Then
                selectedDesc = New DatabaseConnect().get_id("products", "description", txtProductDesc.Text)
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

    Private Sub txtProductDesc_MouseMove(sender As Object, e As MouseEventArgs) Handles txtProductDesc.MouseMove
        If txtProductDesc.TextLength > 0 Then
            selectedDesc = New DatabaseConnect().get_id("products", "description", txtProductDesc.Text)
        Else
            selectedDesc = 0
        End If
    End Sub
End Class