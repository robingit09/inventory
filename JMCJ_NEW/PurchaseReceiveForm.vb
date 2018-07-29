Public Class PurchaseReceiveForm
    Public selectedPO As Integer = 0
    Public selectedSupplier As Integer = 0
    Public selectedTerm As Integer = 0
    Public selectedPaymentType As Integer = 0

    Public Sub clearFields()
        loadPO()
        loadTerms()
        loadPaymentType()

        cbPO.SelectedIndex = 0
        selectedPO = 0
        txtPRNO.Text = ""
        txtSupplier.Text = ""
        selectedSupplier = 0
        cbTerms.SelectedIndex = 0
        selectedTerm = 0
        cbPaymentType.SelectedIndex = 0
        selectedPaymentType = 0
        dtp_pr_date.Value = DateTime.Now.Date
        dtpETA.Value = DateTime.Now.Date
        dtpATA.Value = DateTime.Now.Date
        txtAmount.Text = ""
        dgvProd.Rows.Clear()

    End Sub
    Private Sub PurchaseReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub loadPO()
        cbPO.DataSource = Nothing
        cbPO.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,po_no from purchase_orders where delivery_status <> 2 order by po_date desc")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select PO Number")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = CInt(.dr("id"))
                    Dim po As String = .dr("po_no")
                    comboSource.Add(id, po)
                End While
            End If
            cbPO.DataSource = New BindingSource(comboSource, Nothing)
            cbPO.DisplayMember = "Value"
            cbPO.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub cbPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPO.SelectedIndexChanged
        If cbPO.SelectedIndex > 0 Then
            gpEnterBarcode.Enabled = True
            gpEnterProduct.Enabled = True
            dgvProd.Enabled = True

            Dim key As String = DirectCast(cbPO.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbPO.SelectedItem, KeyValuePair(Of String, String)).Value
            Me.selectedPO = key
            Me.selectedSupplier = getSupplier(selectedPO)
            cbPO.BackColor = Drawing.Color.White
            txtPRNO.Text = generatePRNo()
            txtSupplier.Text = New DatabaseConnect().get_by_id("suppliers", Me.selectedSupplier, "supplier_name")

            Dim term As String = New DatabaseConnect().get_by_id("purchase_orders", Me.selectedPO, "terms")
            Select Case term
                Case "15"
                    cbTerms.SelectedIndex = cbTerms.FindString("15 Days")
                Case "30"
                    cbTerms.SelectedIndex = cbTerms.FindString("30 Days")
                Case "0"
                    cbTerms.SelectedIndex = 0
            End Select

            Dim payment_type As Integer = New DatabaseConnect().get_by_id("purchase_orders", Me.selectedPO, "payment_type")
            Select Case payment_type
                Case 1
                    cbPaymentType.SelectedIndex = cbPaymentType.FindString("Cash")
                Case 2
                    cbPaymentType.SelectedIndex = cbPaymentType.FindString("C.O.D")
                Case 3
                    cbPaymentType.SelectedIndex = cbPaymentType.FindString("Credit")
                Case Else
                    cbPaymentType.SelectedIndex = 0
            End Select

            Dim eta As String = New DatabaseConnect().get_by_id("purchase_orders", Me.selectedPO, "eta")
            dtpETA.Value = eta

            txtAmount.Text = Val(New DatabaseConnect().get_by_id("purchase_orders", Me.selectedPO, "total_amount")).ToString("N2")

            Dim dbprod As New DatabaseConnect()
            dgvProd.Rows.Clear()
            With dbprod
                .selectByQuery("select distinct pu.id,pu.barcode,p.description,b.name as brand,u.name as unit,c.name as color,pop.quantity,pop.unit_cost,pop.total_amount
                        FROM (((((purchase_order_products as pop
                        INNER JOIN product_unit as pu ON pu.id = pop.product_unit_id)
                        LEFT JOIN brand as b ON b.id = pu.brand)
                        INNER JOIN unit as u ON u.id = pu.unit)
                        LEFT JOIN color as c ON c.id = pu.color)
                        INNER JOIN products as p ON p.id = pu.product_id)
                        where pop.purchase_order_id = " & selectedPO)
                If .dr.HasRows Then
                    While .dr.Read
                        Dim id As Integer = .dr("id")
                        Dim barcode As String = .dr("barcode")
                        Dim qty As Integer = .dr("quantity")
                        Dim desc As String = .dr("description")
                        Dim brand As String = If(IsDBNull(.dr("brand")), "", .dr("brand"))
                        Dim unit As String = .dr("unit")
                        Dim color As String = If(IsDBNull(.dr("color")), "", .dr("color"))
                        Dim cost As String = Val(.dr("unit_cost")).ToString("N2")
                        Dim total As String = Val(.dr("total_amount")).ToString("N2")

                        Dim row As String() = New String() {id, barcode, qty, desc, brand, unit, color, cost, total, "", "Remove"}
                        dgvProd.Rows.Add(row)
                    End While
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()

            End With
        Else
            selectedPO = 0
            gpEnterBarcode.Enabled = False
            gpEnterProduct.Enabled = False
            dgvProd.Enabled = False
        End If
    End Sub

    Private Function generatePRNo() As String
        Dim result As String = ""
        Try
            Dim db As New DatabaseConnect
            With db
                .selectByQuery("SELECT COUNT(id) from purchase_receive where supplier = " & selectedSupplier)
                If .dr.Read Then
                    Dim count_supplier As Integer = CInt(.dr.GetValue(0))
                    result = "PR-" & getSupplierCode(selectedSupplier) & "-" & (count_supplier + 1).ToString("D6")
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

    Private Function getSupplier(ByVal po_id As Integer) As Integer
        Dim res As Integer = 0
        Dim dbpo As New DatabaseConnect
        With dbpo
            .selectByQuery("Select supplier from purchase_orders where id = " & po_id)
            If .dr.Read Then
                res = CInt(.dr("supplier"))
            End If
        End With
        Return res
    End Function

    Private Sub loadTerms()
        cbTerms.Items.Clear()
        cbTerms.Items.Add("Select Terms")
        cbTerms.Items.Add("15 Days")
        cbTerms.Items.Add("30 Days")
        cbTerms.Items.Add("Immediate")
        cbTerms.SelectedIndex = 0
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            insertData()
            clearFields()
            PurchaseReceive.loadPR("")
        End If
    End Sub

    Private Sub insertData()

        Dim insertPR As New DatabaseConnect
        With insertPR
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO purchase_receive (purchase_order_id,pr_no,supplier,pr_date,ata,terms,payment_type,total_amount,delivery_status,payment_status,created_at,updated_at)
                VALUES(?,?,?,?,?,?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@purchase_order_id", selectedPO)
            .cmd.Parameters.AddWithValue("@pr_no", generatePRNo)
            .cmd.Parameters.AddWithValue("@supplier", selectedSupplier)
            .cmd.Parameters.AddWithValue("@pr_date", dtp_pr_date.Value.ToString)
            .cmd.Parameters.AddWithValue("@ata", dtpATA.Value.Date.ToString)
            .cmd.Parameters.AddWithValue("@terms", selectedTerm)
            .cmd.Parameters.AddWithValue("@payment_type", selectedPaymentType)
            .cmd.Parameters.AddWithValue("@total_amount", txtAmount.Text)
            .cmd.Parameters.AddWithValue("@delivery_status", 2)
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
                    .cmd.CommandText = "INSERT INTO purchase_receive_products(purchase_receive_id,product_unit_id,quantity,unit_cost,total_amount,created_at,updated_at)
                        VALUES(?,?,?,?,?,?,?)"

                    .cmd.Parameters.AddWithValue("@purchase_receive_id", getLastID("purchase_receive"))
                    .cmd.Parameters.AddWithValue("@product_unit_id", product_unit_id)
                    .cmd.Parameters.AddWithValue("@quantity", qty)
                    .cmd.Parameters.AddWithValue("@unit_cost", cost)
                    .cmd.Parameters.AddWithValue("@amount", amount)
                    .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                    .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                    .cmd.ExecuteNonQuery()
                    .cmd.Parameters.Clear()

                    'increase stock
                    Dim increasestock As New DatabaseConnect
                    With increasestock
                        Dim temp As String = New DatabaseConnect().get_by_id("product_stocks", product_unit_id, "product_unit_id", "qty")
                        Dim cur_stock As Integer = Val(temp)
                        cur_stock = cur_stock + CInt(qty)

                        .cmd.Connection = .con
                        .cmd.CommandType = CommandType.Text
                        .cmd.CommandText = "UPDATE product_stocks set [qty] = " & cur_stock & " where product_unit_id = " & product_unit_id
                        .cmd.ExecuteNonQuery()
                        .cmd.Dispose()
                        .con.Close()
                    End With

                End If
            Next
            .cmd.Dispose()
            .con.Close()
        End With

        Dim dbupdate As New DatabaseConnect
        With dbupdate
            .update_where("purchase_orders", selectedPO, "delivery_status", 2)
            .cmd.Dispose()
            .con.Close()
        End With

        MsgBox("Purchase Receive Successfully Save.", MsgBoxStyle.Information)

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

    Private Sub cbPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPaymentType.SelectedIndexChanged
        If cbPaymentType.SelectedIndex > 0 Then
            Dim key As Integer = CInt(DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Key)
            Dim value As String = DirectCast(cbPaymentType.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedPaymentType = key
        Else
            selectedPaymentType = 0
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
End Class