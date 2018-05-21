Public Class CustomerOrderForm

    Public SelectedProdID As String
    Public SelectedCustomer As Integer
    Public Date_payment As New DateTime
    Private Sub CustomerOrderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        populateCustomer()
        populateCategory()

        cbTermPayment.Text = "Select Terms of Payment"
    End Sub

    Public Sub populateCustomer()

        cbCustomer.DataSource = Nothing
        cbCustomer.Items.Clear()

        Dim database As New DatabaseConnect
        database.dbConnect()
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "SELECT distinct company, ID FROM company where status = 1"
        database.cmd.Connection = database.con
        Try
            database.dr = database.cmd.ExecuteReader



            If database.dr.HasRows Then


                Dim comboSource As New Dictionary(Of String, String)()
                comboSource.Add(0, "Select Customer")

                While database.dr.Read

                    Dim cus As String = database.dr.GetValue(0)
                    Dim id As String = database.dr.GetValue(1)

                    comboSource.Add(id, cus)


                End While

                cbCustomer.DataSource = New BindingSource(comboSource, Nothing)
                cbCustomer.DisplayMember = "Value"
                cbCustomer.ValueMember = "Key"

            End If

            database.con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub populateProducts(ByVal cat As String)

        Dim database As New DatabaseConnect
        database.dbConnect()
        database.cmd.CommandType = CommandType.Text


        If cat = "All" Then

            database.cmd.CommandText = "SELECT distinct id, name FROM products where status = 1"
        Else
            database.cmd.CommandText = "SELECT distinct id, name FROM products where status = 1 and category like '%" & cat & "%'"
        End If



        database.cmd.Connection = database.con

        Try
            database.dr = database.cmd.ExecuteReader


            If database.dr.HasRows Then

                cbProdId.Items.Clear()
                cbProducts.Items.Clear()


                cbProducts.Items.Add("Select Product")
                cbProdId.Items.Add("Select Product ID")

                Dim comboSource As New Dictionary(Of String, String)()


                While database.dr.Read
                    Dim id As String = database.dr.GetValue(0)
                    Dim prod As String = database.dr.GetValue(1)
                    cbProducts.Items.Add(prod)
                    cbProdId.Items.Add(id)

                End While

            End If

            database.con.Close()

            cbProducts.Text = "Select Product"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub populateCategory()

        Dim database As New DatabaseConnect
        database.dbConnect()
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "SELECT distinct id, category FROM products where status = 1"
        database.cmd.Connection = database.con

        Try
            database.dr = database.cmd.ExecuteReader


            If database.dr.HasRows Then
                cbCat.Items.Clear()
                cbCat.Items.Add("Select Category")

                While database.dr.Read

                    Dim cat As String = database.dr.GetValue(1)

                    cbCat.Items.Add(cat)


                End While

            End If

            database.con.Close()

            cbCat.Text = "Select Category"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCat.SelectedIndexChanged

        If cbCat.Text.Length > 0 Then

            populateProducts(cbCat.Text)
        End If
    End Sub
    Private Sub btnAddProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddProd.Click

        'MsgBox(cbProdId.Items(cbProducts.SelectedIndex))

        Dim prodid As String = cbProdId.Items(cbProducts.SelectedIndex)
        addproduct(prodid)

        computeTotalAmount()


    End Sub

    Public Sub addproduct(ByVal id As String)
        'validation
        For Each item As DataGridViewRow In Me.dgvProd.Rows

            Dim key As String = dgvProd.Rows(item.Index).Cells(10).Value

            Dim selectedId As String = cbProdId.Items(cbProducts.SelectedIndex)

            If key = selectedId Then
                MsgBox("Already added!", MsgBoxStyle.Critical)
                Exit Sub
            End If

        Next
        'end validation

        Dim database As New DatabaseConnect
        database.dbConnect()
        database.cmd.CommandType = CommandType.Text

        database.cmd.CommandText = "SELECT id,name,brand,unit,price FROM products where status = 1 and ID = " & id
        database.cmd.Connection = database.con


        Try
            database.dr = database.cmd.ExecuteReader
            If database.dr.HasRows Then

                If database.dr.Read Then
                    Dim arr(10) As String

                    Dim prodid As String = database.dr.GetValue(0)
                    Dim name As String = database.dr.GetValue(1)
                    Dim brand As String = database.dr.GetValue(2)
                    Dim unit As String = database.dr.GetValue(3)

                    Dim price As String = database.dr.GetValue(4)

                    arr(0) = name
                    arr(1) = brand
                    arr(2) = unit
                    arr(3) = price
                    arr(4) = "0.00"
                    arr(5) = "0"
                    arr(6) = "Add less"
                    arr(7) = "Minus"
                    arr(8) = "0.00"
                    arr(9) = "%"
                    arr(10) = prodid


                    Dim row As String() = New String() {"1", name, brand, unit, price, "0", "Add less", "Reset", price, price, prodid}
                    dgvProd.Rows.Add(row)


                    'Dim lvitem As New ListViewItem(arr)

                    'lvProd.Items.Add(lvitem)

                End If

            End If

            database.con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub computeTotalAmount()


        If dgvProd.Rows.Count > 1 Then
            Dim totalamount = 0.0
            For Each item As DataGridViewRow In Me.dgvProd.Rows


                Dim amount As Double = dgvProd.Rows(item.Index).Cells(9).Value
                totalamount += amount

            Next

            lblAmount.Text = totalamount.ToString("f2")

        End If
    End Sub

    Private Sub dgvProd_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProd.CellValueChanged


        If dgvProd.Rows.Count > 1 Then
            'change if edit the qty
            If e.ColumnIndex = 0 Then
                Dim amount As Double = 0

                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells(0).Value)
                Dim price As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells(4).Value)
                Dim less As String = CStr(dgvProd.Rows(e.RowIndex).Cells(5).Value)
                Dim total_less As Double = 0

                Dim temp_less As Double = 0

                If less.Contains(",") Then

                    Dim less_split() = less.Split(",")
                    Dim len As Integer = less_split.Length - 1


                    Dim res As String = ""
                    Try
                        If less_split(len).Length = 1 Then
                            res = "0.0" & less_split(len)
                        ElseIf less_split(len).Length = 2 Then
                            res = "0." & less_split(len)
                        End If
                        less_split(len) = res
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                    temp_less = CDbl(less_split(len))
                Else

                    Dim res As String = ""
                    Try
                        If less.Length = 1 Then
                            res = "0.0" & less
                        ElseIf less.Length = 2 Then
                            res = "0." & less
                        End If
                        less = res
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                    total_less = CDbl(less)
                End If

                Dim less_number As Double = total_less
                Dim sellprice As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells(8).Value)
                Dim x As Double = sellprice * less_number
                sellprice = price - x
                amount = qty * sellprice
                dgvProd.Rows(e.RowIndex).Cells(8).Value = sellprice
                dgvProd.Rows(e.RowIndex).Cells(9).Value = amount
            End If

            If e.ColumnIndex = 5 Then
                Dim amount As Double = 0

                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells(0).Value)
                Dim price As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells(4).Value)

                Dim less As String = CStr(dgvProd.Rows(e.RowIndex).Cells(5).Value)
                Dim sellprice As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells(8).Value)

                Dim temp_less As Double = 0

                If less.Contains(",") Then

                    Dim less_split() = less.Split(",")
                    Dim len As Integer = less_split.Length - 1


                    Dim res As String = ""
                    Try
                        If less_split(len).Length = 1 Then
                            res = "0.0" & less_split(len)
                        ElseIf less_split(len).Length = 2 Then
                            res = "0." & less_split(len)
                        End If
                        less_split(len) = res
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                    temp_less = CDbl(less_split(len))


                Else

                    Dim res As String = ""
                    Try
                        If less.Length = 1 Then
                            res = "0.0" & less
                        ElseIf less.Length = 2 Then
                            res = "0." & less
                        End If
                        less = res
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                    temp_less = CDbl(less)
                End If

                Dim less_number As Double = temp_less


                Dim x As Double = sellprice * less_number
                sellprice = sellprice - x

                amount = qty * sellprice
                dgvProd.Rows(e.RowIndex).Cells(8).Value = sellprice
                dgvProd.Rows(e.RowIndex).Cells(9).Value = amount
            End If

            computeTotalAmount()

        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click

        If dgvProd.SelectedRows.Count > 0 Then

            dgvProd.Rows.Remove(dgvProd.SelectedRows(0))
            computeTotalAmount()
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        saveData()

        Dim cusRpt As New crCustomerOrder
        cusRpt.RecordSelectionFormula = "{customer_orders.ID} = " & getLastID()
        frmReportViewer.Enabled = True
        frmReportViewer.CrystalReportViewer1.ReportSource = cusRpt
        frmReportViewer.CrystalReportViewer1.Refresh()
        frmReportViewer.CrystalReportViewer1.RefreshReport()
        frmReportViewer.ShowDialog()


    End Sub

    Private Function getLastID() As Integer
        Dim id As Integer
        Dim db As New DatabaseConnect
        db.dbConnect()
        db.cmd.CommandText = "SELECT MAX(ID) from customer_orders"
        db.cmd.Connection = db.con
        db.cmd.CommandType = CommandType.Text

        db.dr = db.cmd.ExecuteReader

        If db.dr.Read Then
            id = db.dr.GetValue(0)

        End If
        db.cmd.Dispose()
        db.dr.Close()
        db.con.Close()

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
        If e.ColumnIndex = 6 Then

            Dim less As String = ""
            less = InputBox("Add less", "Enter the additional less(Numbers Only)", "0")

            Dim less_string As String = dgvProd.Rows(e.RowIndex).Cells(5).Value
            If less_string.Length > 0 Then
                If less_string.Contains(",") Then
































                    dgvProd.Rows(e.RowIndex).Cells(5).Value = less_string & "," & less
                ElseIf CInt(less_string) > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells(5).Value = less_string & "," & less
                Else
                    dgvProd.Rows(e.RowIndex).Cells(5).Value = less
                End If
            End If

        End If

        If e.ColumnIndex = 7 Then


            dgvProd.Rows(e.RowIndex).Cells(5).Value = "0"

            dgvProd.Rows(e.RowIndex).Cells(8).Value = dgvProd.Rows(e.RowIndex).Cells(4).Value
        End If
    End Sub

    Private Sub cbCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedIndexChanged

        If cbCustomer.Text.Length > 0 Then
            Dim key As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCustomer.SelectedItem, KeyValuePair(Of String, String)).Value

            Me.selectedCustomer = key
        End If
    End Sub
End Class