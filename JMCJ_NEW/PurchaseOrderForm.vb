Public Class PurchaseOrderForm

    Public isSupplierLoaded As Boolean = False

    Public selectedSupplier As Integer = 0
    Public selectedTerm As Integer = 0
    Public selectedPaymentType As Integer = 0
    Private Sub PurchaseOrderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSupplier()
        loadTerms()
        loadPaymentType()
        gpEnterBarcode.Enabled = False
        gpEnterProduct.Enabled = False
        dgvProd.Enabled = False
    End Sub

    Public Sub loadSupplier()
        cbSupplier.DataSource = Nothing
        cbSupplier.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,supplier_name from suppliers where status <> 0 order by supplier_name")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Supplier")

            While .dr.Read
                Dim id As Integer = CInt(.dr.GetValue(0))
                Dim sup As String = .dr.GetValue(1)
                comboSource.Add(id, sup)
            End While

            cbSupplier.DataSource = New BindingSource(comboSource, Nothing)
            cbSupplier.DisplayMember = "Value"
            cbSupplier.ValueMember = "Key"

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub loadPaymentType()
        cbPaymentType.DataSource = Nothing
        cbPaymentType.Items.Clear()

        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Payment Type")
        comboSource.Add(1, "Cash")
        comboSource.Add(2, "C.O.D")
        comboSource.Add(3, "Credit")

        cbPaymentType.DataSource = New BindingSource(comboSource, Nothing)
        cbPaymentType.DisplayMember = "Value"
        cbPaymentType.ValueMember = "Key"
        cbPaymentType.SelectedIndex = 0
    End Sub

    Private Function generatePONo() As String
        Dim result As String = ""
        Try
            Dim db As New DatabaseConnect
            With db
                .selectByQuery("SELECT COUNT(id) from purchase_orders where supplier = " & selectedSupplier)
                If .dr.Read Then
                    Dim count_supplier As Integer = CInt(.dr.GetValue(0))
                    result = "PO-" & getSupplierCode(selectedSupplier) & "-" & (count_supplier + 1).ToString("D6")
                End If

                .dr.Close()
                .cmd.Dispose()
                .con.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return result
    End Function

    Private Function getSupplierCode(ByVal sup_id As Integer) As String
        Dim code As String = ""
        Dim db As New DatabaseConnect
        With db
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "SELECT supplier_code from suppliers where id = " & sup_id & " and status <> 0"
            .dr = .cmd.ExecuteReader

            If .dr.Read Then
                code = .dr.GetValue(0)
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()

        End With

        Return code
    End Function

    Private Sub cbSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSupplier.SelectedIndexChanged
        If cbSupplier.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Value
            Me.selectedSupplier = key
            cbSupplier.BackColor = Drawing.Color.White
            txtPONO.Text = generatePONo()

            gpEnterBarcode.Enabled = True
            gpEnterProduct.Enabled = True
            dgvProd.Enabled = True

        Else
            selectedSupplier = 0
            cbSupplier.SelectedIndex = 0
            txtPONO.Text = ""
            gpEnterBarcode.Enabled = False
            gpEnterProduct.Enabled = False
            dgvProd.Enabled = False
        End If

    End Sub

    Private Sub loadTerms()
        cbTerms.Items.Clear()
        cbTerms.Items.Add("Select Terms")
        cbTerms.Items.Add("15 Days")
        cbTerms.Items.Add("30 Days")
        cbTerms.Items.Add("Immediate")
        cbTerms.SelectedIndex = 0

    End Sub

    Private Sub addproduct(ByVal id As Integer)
        'validation
        For Each item As DataGridViewRow In Me.dgvProd.Rows

            Dim key As String = dgvProd.Rows(item.Index).Cells(0).Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells(2).Value
            Dim selectedId As String = id

            If key = selectedId Then
                MsgBox(prod & "Already added!", MsgBoxStyle.Critical)
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
                    Dim prodid As String = database.dr.GetValue(0)
                    Dim name As String = database.dr.GetValue(1)
                    Dim brand As String = database.dr.GetValue(2)
                    Dim unit As String = database.dr.GetValue(3)
                    Dim price As String = database.dr.GetValue(4)

                    Dim row As String() = New String() {prodid, "1", name, unit, brand, "0.00", "0.00", "Remove(-)"}
                    dgvProd.Rows.Add(row)

                End If

            End If

            database.con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub cbTerms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTerms.SelectedIndexChanged
        If cbTerms.SelectedIndex > 0 Then
            Select Case cbTerms.Text
                Case "15 Days"
                    selectedTerm = 15
                Case "30 Days"
                    selectedTerm = 30
                Case "Immediate"
                    selectedTerm = 0
            End Select
        Else
            selectedTerm = 0
        End If

    End Sub

    Private Sub txtEnterBarcode_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEnterBarcode.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Trim(txtEnterBarcode.Text).Length > 0 Then
                'validation
                ' check if exist
                For Each item As DataGridViewRow In dgvProd.Rows
                    If item.Cells("product").Value <> "" Then
                        Dim barcode As String = item.Cells("barcode").Value

                        If barcode = Trim(txtEnterBarcode.Text) Then
                            MsgBox("Product (" & txtEnterBarcode.Text & ") already added!", MsgBoxStyle.Critical)
                            txtEnterBarcode.Text = ""
                            Exit Sub
                        End If
                    End If
                Next

                Dim db As New DatabaseConnect
                With db
                    .selectByQuery("Select distinct pu.id, pu.barcode, p.description, b.name As brand, u.name As unit, cc.name As color, c.name As cat,sub.name as subcat FROM ((((((((products as p 
                    INNER Join product_unit as pu ON p.id = pu.product_id) 
                    Left Join brand as b ON b.id = pu.brand)
                    INNER Join unit as u ON u.id = pu.unit)
                    Left Join color as cc ON cc.id = pu.color)
                    INNER Join product_categories as pc ON pc.product_id = p.id) 
                    Left Join product_subcategories as psc ON psc.product_id = p.id)
                    Left Join categories as c ON c.id = pc.category_id)
                    Left Join categories as sub ON sub.id = psc.subcategory_id)  where pu.status <> 0 and p.status <> 0 and pu.barcode = '" & Trim(txtEnterBarcode.Text) & "'")

                    If .dr.Read Then
                        Dim id As String = .dr("id")
                        Dim barcode As String = .dr("barcode")
                        Dim desc As String = .dr("description")
                        Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                        Dim unit As String = .dr("unit")
                        Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                        Dim cost As String = Val(getCost(selectedSupplier, id)).ToString("N2")

                        Dim row As String() = New String() {id, barcode, "", desc, brand, unit, color, cost, "", "", "Remove"}
                        dgvProd.Rows.Add(row)
                        txtEnterBarcode.Text = ""
                    End If

                    .dr.Close()
                    .cmd.Dispose()
                    .con.Close()
                End With
            End If

        End If
    End Sub

    Private Sub dgvProd_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellValueChanged
        If dgvProd.Rows.Count > 1 Then
            'change if edit the qty
            If e.ColumnIndex = 2 Then
                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("cost").Value.ToString.Replace(",", ""))

                amount = qty * CDbl(price)
                dgvProd.Rows(e.RowIndex).Cells("amount").Value = Val(amount).ToString("N2")


                'change color
                If qty > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Drawing.Color.Red
                End If
            End If

            If e.ColumnIndex = 7 Then
                Dim amount As Double = 0
                Dim qty As Integer = CInt(dgvProd.Rows(e.RowIndex).Cells("quantity").Value)
                Dim price As Double = CDbl(dgvProd.Rows(e.RowIndex).Cells("price").Value.ToString.Replace(",", ""))

                amount = qty * CDbl(price)
                dgvProd.Rows(e.RowIndex).Cells("amount").Value = Val(amount).ToString("N2")


                'change color
                If qty > 0 Then
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Drawing.Color.White
                Else
                    dgvProd.Rows(e.RowIndex).Cells("quantity").Style.BackColor = Drawing.Color.Red
                End If
            End If
            computeTotalAmount()
        End If
    End Sub

    Public Sub computeTotalAmount()
        Dim totalamount As Double = 0.0
        If dgvProd.Rows.Count > 1 Then
            For Each item As DataGridViewRow In Me.dgvProd.Rows
                If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("amount").Value)) Then
                    Dim amount As Double = dgvProd.Rows(item.Index).Cells("amount").Value
                    totalamount += amount
                End If
            Next
        End If
        lblTotalAmount.Text = totalamount.ToString("N2")
        txtAmount.Text = totalamount.ToString("N2")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            If validation() = False Then
                Exit Sub
            End If
            insertData()
            clearFields()
            POList.loadPO("")
        Else

        End If
    End Sub

    Private Function validation() As Boolean

        If cbSupplier.SelectedIndex = 0 Then
            MsgBox("Supplier field is required!", MsgBoxStyle.Critical)
            cbSupplier.Focus()
            Return False
        End If

        If txtPONO.Text = "" Then
            MsgBox("PO no. field is required!", MsgBoxStyle.Critical)
            txtPONO.Focus()
            Return False
        End If

        If cbTerms.SelectedIndex = 0 Then
            MsgBox("Term field is required!", MsgBoxStyle.Critical)
            cbTerms.Focus()
            Return False
        End If

        If cbPaymentType.SelectedIndex = 0 Then
            MsgBox("Payment Type field is required!", MsgBoxStyle.Critical)
            cbPaymentType.Focus()
            Return False
        End If

        If dgvProd.Rows.Count = 1 Then
            MsgBox("Please add product!", MsgBoxStyle.Critical)
            dgvProd.Focus()
            Return False
        End If

        'qty validation
        Dim validate As Boolean = False
        For Each item As DataGridViewRow In Me.dgvProd.Rows
            Dim qty As String = dgvProd.Rows(item.Index).Cells("quantity").Value
            Dim prod As String = dgvProd.Rows(item.Index).Cells("product").Value
            If prod <> "" Then
                If qty = "" Then
                    dgvProd.Rows(item.Index).Cells("quantity").Style.BackColor = Drawing.Color.Red
                    validate = True
                End If

                If IsNumeric(qty) And Val(qty) <= 0 Then
                    dgvProd.Rows(item.Index).Cells("quantity").Style.BackColor = Drawing.Color.Red
                    validate = True
                End If
            End If

        Next

        If validate = True Then
            Return False
        End If
        Return True
    End Function

    Public Sub clearFields()
        cbSupplier.SelectedIndex = cbSupplier.FindString("Select Supplier")
        selectedSupplier = 0
        txtPONO.Text = ""
        cbTerms.SelectedIndex = cbTerms.FindString("Select Terms")
        selectedTerm = 0
        dtp_po_date.Value = DateTime.Now
        dtpETA.Value = DateTime.Now
        txtAmount.Text = ""
        lblTotalAmount.Text = "0.00"
        dgvProd.Rows.Clear()

    End Sub

    Private Sub insertData()

        Dim insertPO As New DatabaseConnect
        With insertPO
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO purchase_orders (po_no,supplier,po_date,eta,terms,payment_type,total_amount,delivery_status,payment_status,created_at,updated_at)
                VALUES(?,?,?,?,?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@po_no", generatePONo())
            .cmd.Parameters.AddWithValue("@supplier", selectedSupplier)
            .cmd.Parameters.AddWithValue("@po_date", dtp_po_date.Value.ToString)
            .cmd.Parameters.AddWithValue("@eta", dtpETA.Value.Date.ToString)
            .cmd.Parameters.AddWithValue("@terms", selectedTerm)
            .cmd.Parameters.AddWithValue("@payment_type", selectedPaymentType)
            .cmd.Parameters.AddWithValue("@total_amount", txtAmount.Text)
            .cmd.Parameters.AddWithValue("@delivery_status", 1)
            .cmd.Parameters.AddWithValue("@payment_status", 1)
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()

        End With

        Dim insertProduct As New DatabaseConnect
        With insertProduct
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text

            For Each item As DataGridViewRow In Me.dgvProd.Rows

                Dim product_unit_id As String = dgvProd.Rows(item.Index).Cells("id").Value
                Dim qty As String = dgvProd.Rows(item.Index).Cells("quantity").Value
                Dim cost As String = dgvProd.Rows(item.Index).Cells("cost").Value
                Dim amount As String = dgvProd.Rows(item.Index).Cells("amount").Value


                If (Not String.IsNullOrEmpty(dgvProd.Rows(item.Index).Cells("product").Value)) Then
                    .cmd.CommandText = "INSERT INTO purchase_order_products(purchase_order_id,product_unit_id,quantity,unit_cost,total_amount,created_at,updated_at)
                        VALUES(?,?,?,?,?,?,?)"

                    .cmd.Parameters.AddWithValue("@purchase_order_id", getLastID("purchase_orders"))
                    .cmd.Parameters.AddWithValue("@product_unit_id", product_unit_id)
                    .cmd.Parameters.AddWithValue("@quantity", qty)
                    .cmd.Parameters.AddWithValue("@unit_cost", cost)
                    .cmd.Parameters.AddWithValue("@amount", amount)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()

                End If

            Next
            .cmd.Dispose()
            .con.Close()
        End With

        MsgBox("Purchase Order Successfully Save.", MsgBoxStyle.Information)

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

    Private Sub dgvProd_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProd.CellContentClick
        'remove product
        If e.ColumnIndex = 10 And dgvProd.Rows.Count > 1 Then
            dgvProd.Rows.RemoveAt(e.RowIndex)
            computeTotalAmount()
        End If
    End Sub

    Private Sub cbPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaymentType.SelectedIndexChanged
        If cbPaymentType.SelectedIndex > 0 Then
            Dim key As Integer = CInt(DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaymentType = key
        Else
            selectedPaymentType = 0
        End If
    End Sub

    Private Function getCost(ByVal supplier As Integer, ByVal p_u_id As Integer) As Double
        Dim result As Double = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("select unit_cost from product_suppliers where supplier = " & supplier & " and product_unit_id = " & p_u_id)
            If .dr.Read Then
                result = CDbl(Val(.dr("unit_cost")).ToString("N2"))
            End If
        End With

        Return result
    End Function
End Class