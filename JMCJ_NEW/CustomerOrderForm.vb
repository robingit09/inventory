Public Class CustomerOrderForm

    Public SelectedProdID As Integer = 0
    Public SelectedBrand As Integer = 0
    Public SelectedUnit As Integer = 0
    Public SelectedCustomer As Integer = 0
    Public seletedCategory As Integer = 0
    Public selectedSubcategory As Integer = 0
    Public term As Integer = 0
    Public payment_method As Integer = 0

    Private Sub CustomerOrderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            Dim query As String = "Select distinct u.id, u.name from (product_unit as pu LEFT JOIN unit as u on u.id = pu.unit) 
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
            SelectedProdID = 0

            populateBrand(SelectedProdID)
            SelectedBrand = 0

            populateUnit(SelectedProdID)
            SelectedUnit = 0

            cbProducts.SelectedIndex = 0
            cbBrand.SelectedIndex = 0
            cbUnit.SelectedIndex = 0


        End If

        If cbCat.SelectedIndex = 0 Then
            populateSubCategory(0)
            populateProducts(0, selectedSubcategory)
        End If
    End Sub
    Private Sub btnAddProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToCart.Click


        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT pu.barcode,p.id,p.description,b.name as brand, u.name as unit,pu.price from (((products as p 
                left join product_unit as pu on pu.product_id = p.id)
                left join brand as b on b.id = pu.brand)
                left join unit as u on u.id = pu.unit)
                where pu.brand = " & SelectedBrand & " and pu.product_id = " & SelectedProdID & " and pu.unit = " & SelectedUnit)

            If .dr.HasRows Then
                If .dr.Read Then
                    Dim product_id As String = .dr("id").ToString
                    Dim barcode As String = .dr("barcode").ToString
                    Dim desc As String = .dr("description").ToString
                    Dim brand As String = .dr("brand").ToString
                    Dim unit As String = .dr("unit").ToString
                    Dim unitprice As String = .dr("price").ToString
                    Dim row As String() = New String() {product_id, barcode, "0", desc, brand, unit, unitprice, "", "Add less", "Reset", "", "0.00", "", "Remove"}
                    dgvProd.Rows.Add(row)

                End If
            End If
        End With
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
            lblTotalAmount.Text = totalamount.ToString("f2")
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
                amount = qty * Val(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value)

                If less.Contains(",") Then
                    Dim split = less.Split(",")
                    Try
                        Dim temp As Double = amount
                        Dim res As Double = 0
                        Dim x As Double = 0
                        For i As Integer = 0 To split.Length - 1
                            temp = temp * (1.0 - (Val(split(i)) / 100))
                        Next
                        dgvProd.Rows(e.RowIndex).Cells("amount").Value = temp
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    dgvProd.Rows(e.RowIndex).Cells("amount").Value = amount * (1.0 - (Val(less) / 100))
                End If

                'change color
                If qty > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Color.Red
                End If
            End If

            If e.ColumnIndex = 7 Then
                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("price").Value)
                Dim less As String = CStr(dgvProd.Rows(e.RowIndex).Cells("less").Value)
                Dim sellprice As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value)
                amount = qty * Val(dgvProd.Rows(e.RowIndex).Cells("sell_price").Value)

                If less.Contains(",") Then
                    Dim split = less.Split(",")
                    Try
                        Dim temp As Double = amount
                        Dim res As Double = 0
                        Dim x As Double = 0
                        For i As Integer = 0 To split.Length - 1
                            temp = temp * (1.0 - (Val(split(i)) / 100))
                        Next
                        dgvProd.Rows(e.RowIndex).Cells("amount").Value = temp
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    dgvProd.Rows(e.RowIndex).Cells("amount").Value = amount * (1.0 - (Val(less) / 100))
                End If
            End If
            computeTotalAmount()
        End If
    End Sub

    Private Function getLastID(ByVal table As String) As Integer
        Dim id As Integer = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT MAX(ID) from " & table)
            If .dr.HasRows Then
                .dr.Read()
                id = If(IsDBNull(.dr.GetValue(0)), 1, .dr.GetValue(0))
            Else
                id = 1
            End If
        End With
        Return id
    End Function

    Private Function generateInvoice() As String
        Dim res As String = ""
        Dim id As Integer = 0

        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select max(id) from customer_orders")
            If .dr.HasRows Then
                .dr.Read()
                id = If(IsDBNull(.dr.GetValue(0)), 0, .dr.GetValue(0))
                res = (id + 1).ToString("D7")
            Else
                res = (id + 1).ToString("D7")
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With

        Return res
    End Function

    Private Sub saveData()
        Dim dborder As New DatabaseConnect
        With dborder
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "insert into customer_orders ([invoice_no],[customer],[received_by],[delivered_by],
                [net_amount],[total_amount],[payment_method],[terms],[date_issue],[created_at],[updated_at],[status])VALUES(?,?,?,?,?,?,?,?
                ,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@invoice_no", generateInvoice())
            .cmd.Parameters.AddWithValue("@customer", SelectedCustomer)
            .cmd.Parameters.AddWithValue("@received_by", txtReceivedBy.Text)
            .cmd.Parameters.AddWithValue("@delivered_by", txtDeliveredBy.Text)
            .cmd.Parameters.AddWithValue("@net_amount", lblTotalAmount.Text)
            .cmd.Parameters.AddWithValue("@total_amount", lblTotalAmount.Text)
            .cmd.Parameters.AddWithValue("@payment_method", Me.payment_method)
            .cmd.Parameters.AddWithValue("@terms", Me.term)
            .cmd.Parameters.AddWithValue("@date_issue", dtpDateIssue.Value.ToString)
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@status", 1)
            .cmd.ExecuteNonQuery()

            Dim cmd2 As New System.Data.OleDb.OleDbCommand
            cmd2.Connection = .con
            cmd2.CommandType = CommandType.Text
            For Each item As DataGridViewRow In Me.dgvProd.Rows

                Dim product As Integer = .get_id("products", "description", dgvProd.Rows(item.Index).Cells("product").Value)
                Dim brand As Integer = .get_id("brand", "name", dgvProd.Rows(item.Index).Cells("brand").Value)
                Dim unit As Integer = .get_id("unit", "name", dgvProd.Rows(item.Index).Cells("unit").Value)
                Dim qty As Integer = dgvProd.Rows(item.Index).Cells("quantity").Value
                Dim price As String = dgvProd.Rows(item.Index).Cells("price").Value
                Dim sell_price As String = dgvProd.Rows(item.Index).Cells("sell_price").Value
                Dim less As String = dgvProd.Rows(item.Index).Cells("less").Value
                Dim total_amount As String = dgvProd.Rows(item.Index).Cells("amount").Value

                ' check if not blank
                If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("product").Value)) Then
                    cmd2.CommandText = "insert into customer_order_products (customer_order_id,product_id,brand,unit,quantity,unit_price,sell_price,less,
                total_amount)VALUES(?,?,?,?,?,?,?,?,?)"
                    cmd2.Parameters.AddWithValue("@customer_order_id", getLastID("customer_orders"))
                    cmd2.Parameters.AddWithValue("@product_id", product)
                    cmd2.Parameters.AddWithValue("@brand", brand)
                    cmd2.Parameters.AddWithValue("@unit", unit)
                    cmd2.Parameters.AddWithValue("@quantity", qty)
                    cmd2.Parameters.AddWithValue("@unit_price", price)
                    cmd2.Parameters.AddWithValue("@sell_price", sell_price)
                    cmd2.Parameters.AddWithValue("@quantity", qty)
                    cmd2.Parameters.AddWithValue("@less", less)
                    cmd2.Parameters.AddWithValue("@total_amount", total_amount)
                    cmd2.ExecuteNonQuery()
                    cmd2.Parameters.Clear()

                End If
            Next
            cmd2.Dispose()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Customer Order Save Successfully.", MsgBoxStyle.Information)
            clearSelection()
            CustomerOrder.loadCustomer("")
        End With
        Me.Close()

    End Sub

    Public Sub clearSelection()
        cbCustomer.SelectedIndex = 0
        cbCat.SelectedIndex = 0
        cbProducts.SelectedIndex = 0
        txtDeliveredBy.Text = ""
        txtReceivedBy.Text = ""
        dgvProd.Rows.Clear()
        cbTermPayment.SelectedIndex = 0
        lblTotalAmount.Text = "0.00"
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

            Me.SelectedCustomer = key

            If Me.SelectedCustomer > 0 Then
                cbCustomer.BackColor = Color.White
            End If
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

    Private Sub cbBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand.SelectedIndexChanged
        If cbBrand.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbBrand.SelectedItem, KeyValuePair(Of String, String)).Value
            SelectedBrand = key
        End If
    End Sub

    Private Sub cbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbUnit.SelectedIndexChanged
        If cbUnit.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbUnit.SelectedItem, KeyValuePair(Of String, String)).Value
            SelectedUnit = key
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
        comboSource.Add(120, "120 Days")
        cbTermPayment.DataSource = New BindingSource(comboSource, Nothing)
        cbTermPayment.DisplayMember = "Value"
        cbTermPayment.ValueMember = "Key"
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If validator() = True Then
            Exit Sub
        End If

        ' *** product validation ***
        Dim validate As Boolean = False
        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim qty As Integer = dgvProd.Rows(item.Index).Cells("quantity").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If qty <= 0 And prod <> "" Then
                dgvProd.Rows(item.Index).Cells("quantity").Style.BackColor = Color.Red
                validate = True
            End If
        Next

        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim sell_price As Double = dgvProd.Rows(item.Index).Cells("sell_price").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If sell_price <= 0.00 And prod <> "" Then
                dgvProd.Rows(item.Index).Cells("sell_price").Style.BackColor = Color.Red
                validate = True
            End If
        Next

        If validate = True Then
            Exit Sub
        End If
        saveData()

    End Sub

    Private Sub btnSaveAndPrint_Click(sender As Object, e As EventArgs) Handles btnSaveAndPrint.Click

    End Sub

    Private Function validator() As Boolean
        Dim res As Boolean = False
        If cbCustomer.SelectedIndex = 0 Then
            res = True
            MsgBox("Customer are required fields!", MsgBoxStyle.Critical)
            cbCustomer.BackColor = Color.Red
            cbCustomer.Focus()
            Return res
        End If

        If txtDeliveredBy.TextLength = 0 Then
            res = True
            MsgBox("Delivered by are required fields!", MsgBoxStyle.Critical)
            txtDeliveredBy.BackColor = Color.Red
            txtDeliveredBy.Focus()
            Return res
        End If

        If txtReceivedBy.TextLength = 0 Then
            res = True
            MsgBox("Received by are required fields!", MsgBoxStyle.Critical)
            txtReceivedBy.BackColor = Color.Red
            txtReceivedBy.Focus()
            Return res
        End If


        If dgvProd.Rows.Count = 0 Or dgvProd.Rows.Count = 1 Then
            res = True
            MsgBox("Please add a product!", MsgBoxStyle.Critical)
            dgvProd.BackgroundColor = Color.Red
            dgvProd.Focus()
            Return res
        End If

        If cbPaymentType.SelectedIndex = 0 Then
            res = True
            MsgBox("Please add payment method!", MsgBoxStyle.Critical)
            cbPaymentType.BackColor = Color.Red
            cbPaymentType.Focus()
            Return res
        End If

        If cbTermPayment.SelectedIndex = 0 Then
            res = True
            MsgBox("Please add terms!", MsgBoxStyle.Critical)
            cbTermPayment.BackColor = Color.Red
            cbTermPayment.Focus()
            Return res
        End If



        Return res
    End Function

    Private Sub cbPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaymentType.SelectedIndexChanged
        If cbPaymentType.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Value
            payment_method = key
            cbPaymentType.BackColor = Color.White
        End If
    End Sub

    Private Sub cbTermPayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTermPayment.SelectedIndexChanged
        If cbTermPayment.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbTermPayment.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbTermPayment.SelectedItem, KeyValuePair(Of String, String)).Value
            cbTermPayment.BackColor = Color.White
            Me.term = key
        End If
    End Sub

    Private Sub txtDeliveredBy_TextChanged(sender As Object, e As EventArgs) Handles txtDeliveredBy.TextChanged
        If txtDeliveredBy.TextLength > 0 Then
            txtDeliveredBy.BackColor = Color.White
        End If
    End Sub

    Private Sub txtReceivedBy_TextChanged(sender As Object, e As EventArgs) Handles txtReceivedBy.TextChanged
        If txtReceivedBy.TextLength > 0 Then
            txtReceivedBy.BackColor = Color.White
        End If
    End Sub


End Class