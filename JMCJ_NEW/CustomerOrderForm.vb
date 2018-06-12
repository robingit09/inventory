Public Class CustomerOrderForm

    Public SelectedProdID As Integer = 0
    Public SelectedCustomer As Integer = 0
    Public seletedCategory As Integer = 0
    Public selectedSubcategory As Integer = 0
    Public Date_payment As New DateTime
    Private Sub CustomerOrderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        populateCustomer()
        populateCategory()
        populateSubCategory(0)
        populateProducts(0, 0)
        populateBrand(0)
        populateUnit(0)
        populatepayment()
        populateTerms()
    End Sub

    Public Sub populateCustomer()
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
            End If
            cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
            cbCustomer.DisplayMember = "Value"
            cbCustomer.ValueMember = "Key"
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

    End Sub

    Public Sub populateProducts(ByVal catid As Integer, ByVal subcatid As Integer)
        Dim dbproduct As New DatabaseConnect
        With dbproduct
            cbProducts.DataSource = Nothing
            cbProducts.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Product")
            Dim query As String = ""
            query = "Select distinct p.id, p.description,c.name,sub.name FROM ((((products As p 
                INNER JOIN product_categories as pc ON pc.product_id = p.id) 
                LEFT JOIN product_subcategories as psc ON psc.product_id = p.id)
                LEFT JOIN categories as c ON c.id = pc.category_id)
                LEFT JOIN categories as sub ON sub.id = psc.subcategory_id)  where p.status = 1"
            ' if filter by category
            If catid > 0 Then
                query = query & " And c.id = " & catid
            End If
            If subcatid > 0 Then
                query = query & " And Sub() .id = " & subcatid
            End If
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim product_desc As String = .dr.GetValue(1)
                    comboSource.Add(id, product_desc)
                End While
            End If
            cbProducts.DataSource = New BindingSource(comboSource, Nothing)
            cbProducts.DisplayMember = "Value"
            cbProducts.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub populateBrand(ByVal prodid As Integer)
        Dim dbbrand As New DatabaseConnect
        With dbbrand
            cbBrand.DataSource = Nothing
            cbBrand.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Brand")
            Dim query As String = "Select b.id, b.name from (product_unit as pu LEFT JOIN brand as b on b.id = pu.brand) 
            where pu.product_id = " & prodid
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim brand As String = .dr.GetValue(1)
                    comboSource.Add(id, brand)
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

    Public Sub populateUnit(ByVal prodid As Integer)
        Dim dbunit As New DatabaseConnect
        With dbunit
            cbUnit.DataSource = Nothing
            cbUnit.Items.Clear()
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Unit")
            Dim query As String = "Select u.id, u.name from (product_unit as pu LEFT JOIN unit as u on u.id = pu.unit) 
            where pu.product_id = " & prodid
            .selectByQuery(query)
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr.GetValue(0)
                    Dim unit As String = .dr.GetValue(1)
                    comboSource.Add(id, unit)
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

    Public Sub populateCategory()
        cbCat.DataSource = Nothing
        cbCat.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Category")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = 0 order by name")
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

    Private Sub populateSubCategory(ByVal catid As Integer)
        cbSubcat.DataSource = Nothing
        cbSubcat.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Sub Category")
        Dim db As New DatabaseConnect
        With db
            If catid = 0 Then
                .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id > 0 order by name")
            Else
                .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = " & catid & " order by name")
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            cbSubcat.DataSource = New BindingSource(comboSource, Nothing)
            cbSubcat.DisplayMember = "Value"
            cbSubcat.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub cbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCat.SelectedIndexChanged
        If cbCat.SelectedIndex > 0 Then
            Dim key As String = CInt(DirectCast(cbCat.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbCat.SelectedItem, KeyValuePair(Of String, String)).Value
            seletedCategory = key
            populateSubCategory(seletedCategory)
            populateProducts(Me.seletedCategory, selectedSubcategory)
        End If

        If cbCat.SelectedIndex = 0 Then
            populateSubCategory(0)
            populateProducts(0, selectedSubcategory)
        End If
    End Sub
    Private Sub btnAddProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProd.Click

        'MsgBox(cbProdId.Items(cbProducts.SelectedIndex))
        'Dim prodid As String = cbProdId.Items(cbProducts.SelectedIndex)
        'addproduct(prodid)

        computeTotalAmount()
    End Sub

    Public Sub addproduct(ByVal id As String)
        'validation
        'For Each item As DataGridViewRow In Me.dgvProd.Rows

        '    Dim key As String = dgvProd.Rows(item.Index).Cells(10).Value

        '    Dim selectedId As String = cbProdId.Items(cbProducts.SelectedIndex)

        '    If key = selectedId Then
        '        MsgBox("Already added!", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If

        'Next
        ''end validation

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text

        'database.cmd.CommandText = "SELECT id,name,brand,unit,price FROM products where status = 1 and ID = " & id
        'database.cmd.Connection = database.con
        'Try
        '    database.dr = database.cmd.ExecuteReader
        '    If database.dr.HasRows Then

        '        If database.dr.Read Then
        '            Dim arr(10) As String

        '            Dim prodid As String = database.dr.GetValue(0)
        '            Dim name As String = database.dr.GetValue(1)
        '            Dim brand As String = database.dr.GetValue(2)
        '            Dim unit As String = database.dr.GetValue(3)

        '            Dim price As String = database.dr.GetValue(4)

        '            arr(0) = name
        '            arr(1) = brand
        '            arr(2) = unit
        '            arr(3) = price
        '            arr(4) = "0.00"
        '            arr(5) = "0"
        '            arr(6) = "Add less"
        '            arr(7) = "Minus"
        '            arr(8) = "0.00"
        '            arr(9) = "%"
        '            arr(10) = prodid


        '            Dim row As String() = New String() {"1", name, brand, unit, price, "0", "Add less", "Reset", price, price, prodid}
        '            dgvProd.Rows.Add(row)


        '            'Dim lvitem As New ListViewItem(arr)

        '            'lvProd.Items.Add(lvitem)

        '        End If

        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Public Sub computeTotalAmount()

        If dgvProd.Rows.Count > 1 Then
            Dim totalamount = 0.0
            For Each item As DataGridViewRow In Me.dgvProd.Rows
                Dim amount As Double = dgvProd.Rows(item.Index).Cells("amount").Value
                totalamount += amount
            Next
            lblAmount.Text = totalamount.ToString("f2")
        End If
    End Sub

    Private Sub dgvProd_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProd.CellValueChanged
        If dgvProd.Rows.Count > 1 Then
            'change if edit the qty
            If e.ColumnIndex = 2 Then


                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("price").Value)
                Dim less As String = CStr(dgvProd.Rows(e.RowIndex).Cells("less").Value)
                Dim sellprice As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value)

                If less.Contains(",") Then
                    Dim split = less.Split(",")
                    Try
                        Dim temp As Double = price
                        Dim res As Double = 0
                        Dim x As Double = 0
                        For i As Integer = 0 To split.Length - 1
                            temp = temp * (1.0 - (Val(split(i)) / 100))

                        Next
                        dgvProd.Rows(e.RowIndex).Cells("sell_price").Value = temp
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    dgvProd.Rows(e.RowIndex).Cells("sell_price").Value = price * (1.0 - (Val(less) / 100))
                End If

                'compute amount
                dgvProd.Rows(e.RowIndex).Cells("amount").Value = qty * Val(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value)
            End If

            If e.ColumnIndex = 7 Then
                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("price").Value)
                Dim less As String = CStr(dgvProd.Rows(e.RowIndex).Cells("less").Value)
                Dim sellprice As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value)

                If less.Contains(",") Then
                    Dim split = less.Split(",")
                    Try
                        Dim temp As Double = price
                        Dim res As Double = 0
                        Dim x As Double = 0
                        For i As Integer = 0 To split.Length - 1
                            temp = temp * (1.0 - (Val(split(i)) / 100))

                        Next
                        dgvProd.Rows(e.RowIndex).Cells("sell_price").Value = temp
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    dgvProd.Rows(e.RowIndex).Cells("sell_price").Value = price * (1.0 - (Val(less) / 100))
                End If

                dgvProd.Rows(e.RowIndex).Cells("amount").Value = qty * Val(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value)

            End If

            computeTotalAmount()

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'saveData()
        'Dim cusRpt As New crCustomerOrder
        'cusRpt.RecordSelectionFormula = "{customer_orders.ID} = " & getLastID()
        'frmReportViewer.Enabled = True
        'frmReportViewer.CrystalReportViewer1.ReportSource = cusRpt
        'frmReportViewer.CrystalReportViewer1.Refresh()
        'frmReportViewer.CrystalReportViewer1.RefreshReport()
        'frmReportViewer.ShowDialog()
    End Sub

    Private Function getLastID() As Integer
        Dim id As Integer
        'Dim db As New DatabaseConnect
        'db.dbConnect()
        'db.cmd.CommandText = "SELECT MAX(ID) from customer_orders"
        'db.cmd.Connection = db.con
        'db.cmd.CommandType = CommandType.Text
        'db.dr = db.cmd.ExecuteReader

        'If db.dr.Read Then
        '    id = db.dr.GetValue(0)
        'End If
        'db.cmd.Dispose()
        'db.dr.Close()
        'db.con.Close()
        Return id
    End Function

    Private Sub saveData()
        Dim database As New DatabaseConnect
        database.dbConnect()

        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "INSERT INTO customer_orders([customer],[received_by],[delivered_by],[total_amount],[terms_of_payment],[date_issue],[date_payment])" & _
        "VALUES(@customer,@received_by,@delivered_by,@total_amount,@terms_of_payment,@date_issue,@date_payment)"

        database.cmd.Parameters.AddWithValue("@customer", selectedCustomer)
        database.cmd.Parameters.AddWithValue("@received_by", txtReceivedBy.Text)
        database.cmd.Parameters.AddWithValue("@delivered_by", txtDeliveredBy.Text)
        database.cmd.Parameters.AddWithValue("@total_amount", lblAmount.Text)


        Dim d As Integer = 0
        Select Case cbTermPayment.Text

            Case "30 days"
                d = 30
            Case "60 days"
                d = 60
            Case "90 days"
                d = 90
            Case "120 days"
                d = 120
            Case Else
                d = 0

        End Select

        database.cmd.Parameters.AddWithValue("@terms_of_payment", d)
        database.cmd.Parameters.AddWithValue("@date_issue", dtpDateIssue.Value.Date)
        database.cmd.Parameters.AddWithValue("@date_issue", dtpDateIssue.Value.Date.AddDays(d))
        database.cmd.Connection = database.con
        database.cmd.ExecuteNonQuery()
        database.con.Close()

        'insert products
        Dim customer_order_id As Integer

        database.dbConnect()
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "Select max(ID) from customer_orders"

        database.dr = database.cmd.ExecuteReader

        If database.dr.Read Then
            customer_order_id = database.dr.GetValue(0)

        End If
        database.dr.Close()

        Try
            If dgvProd.Rows.Count > 1 Then
                For Each item As DataGridViewRow In Me.dgvProd.Rows

                    Dim qty As String = dgvProd.Rows(item.Index).Cells(0).Value.ToString
                    Dim prod As String = dgvProd.Rows(item.Index).Cells(1).Value.ToString

                    Dim brand As String = dgvProd.Rows(item.Index).Cells(2).Value.ToString
                    Dim unit As String = dgvProd.Rows(item.Index).Cells(3).Value.ToString
                    Dim price As String = dgvProd.Rows(item.Index).Cells(4).Value.ToString
                    Dim less As String = dgvProd.Rows(item.Index).Cells(5).Value.ToString
                    Dim sellprice As String = dgvProd.Rows(item.Index).Cells(8).Value.ToString
                    Dim amount As String = dgvProd.Rows(item.Index).Cells(9).Value.ToString
                    Dim prodid As String = dgvProd.Rows(item.Index).Cells(10).Value.ToString


                    database.cmd.CommandType = CommandType.Text
                    database.cmd.CommandText = "INSERT INTO customer_order_products([customer_order_id],[product_id],[brand],[unit],[price],[quantity],[sell_price],[less],[total_amount])" & _
                    " VALUES(" & customer_order_id & "," & prodid & ",'" & brand & "', '" & unit & "', " & price & ", " & qty & ", " & sellprice & ", '" & less & "'," & amount & ")"
                    database.cmd.ExecuteNonQuery()

                Next
            End If
        Catch ex As Exception
            'MsgBox(database.cmd.CommandText)
            'MsgBox(ex.Message)
        End Try

        database.con.Close()


        MsgBox("Save Successful", MsgBoxStyle.Information)


        'ProductList.lvEdger.Items.Clear()
        'frmListEdger.loadList("")


        cbCustomer.Text = "Select Customer"
        cbCat.Text = "Select Category"
        cbProducts.Text = "Select Products"
        txtDeliveredBy.Text = ""
        txtReceivedBy.Text = ""

        dgvProd.Rows.Clear()


        cbTermPayment.Text = "Select Terms of Payment"
        lblAmount.Text = "0.00"

        Me.Close()

    End Sub

    Private Sub dgvProd_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProd.CellContentClick
        ' clicking add less
        If e.ColumnIndex = 8 Then
            Dim less As String = ""
            less = InputBox("Add less", "Enter the additional less(Numbers Only)", "0")

            ' validation
            If Not IsNumeric(less) Then
                MsgBox("Please insert number for less!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If Trim(less).Length > 0 Then
                Dim less_string As String = dgvProd.Rows(e.RowIndex).Cells("less").Value
                If less_string.Length > 0 Then
                    If less_string.Contains(",") Then
                        dgvProd.Rows(e.RowIndex).Cells("less").Value = less_string & "," & less
                    ElseIf less_string.Length > 0 Then
                        dgvProd.Rows(e.RowIndex).Cells("less").Value = less_string & "," & less
                    End If
                Else
                    dgvProd.Rows(e.RowIndex).Cells("less").Value = less
                End If
            End If
        End If
        'reset less
        If e.ColumnIndex = 9 Then
            dgvProd.Rows(e.RowIndex).Cells("less").Value = "0"
        End If

        'remove product
        If e.ColumnIndex = 13 Then
            dgvProd.Rows.RemoveAt(e.RowIndex)
            computeTotalAmount()
        End If
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged

        If cbCustomer.Text.Length > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value

            Me.selectedCustomer = key
        End If
    End Sub

    Private Sub cbSubcat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubcat.SelectedIndexChanged
        If cbSubcat.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSubcat.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSubcat.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSubcategory = key
            populateProducts(Me.seletedCategory, selectedSubcategory)
        End If

        If cbSubcat.SelectedIndex = 0 Then
            populateProducts(Me.seletedCategory, 0)
        End If
    End Sub

    Private Sub cbProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProducts.SelectedIndexChanged
        If cbProducts.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbProducts.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbProducts.SelectedItem, KeyValuePair(Of String, String)).Value
            SelectedProdID = key
            populateBrand(SelectedProdID)
            populateUnit(SelectedProdID)
        End If
    End Sub

    Private Sub populatepayment()
        cbPaymentType.DataSource = Nothing
        cbPaymentType.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(-1, "Select Payment Method")
        comboSource.Add(0, "Cash")
        comboSource.Add(1, "C.O.D")
        comboSource.Add(2, "Credit")
        comboSource.Add(3, "Post Dated")
        cbPaymentType.DataSource = New BindingSource(comboSource, Nothing)
        cbPaymentType.DisplayMember = "Value"
        cbPaymentType.ValueMember = "Key"
    End Sub

    Private Sub populateTerms()
        cbTermPayment.DataSource = Nothing
        cbTermPayment.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Term")
        comboSource.Add(30, "30 Days")
        comboSource.Add(60, "60 Days")
        comboSource.Add(90, "90 Days")
        cbTermPayment.DataSource = New BindingSource(comboSource, Nothing)
        cbTermPayment.DisplayMember = "Value"
        cbTermPayment.ValueMember = "Key"
    End Sub
End Class