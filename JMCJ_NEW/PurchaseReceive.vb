Public Class PurchaseReceive
    Public selectedPO As Integer = 0
    Public selectedSupplier As Integer = 0
    Private Sub PurchaseReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPO()
        loadTerms()
        loadPaymentType()
    End Sub

    Public Sub loadPO()
        cbPO.DataSource = Nothing
        cbPO.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,po_no from purchase_orders where delivery_status <> 0 order by po_date desc")
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

            'load product info
        Else
            selectedPO = 0
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
End Class