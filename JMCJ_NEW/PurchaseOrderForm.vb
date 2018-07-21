Public Class PurchaseOrderForm

    Public isSupplierLoaded As Boolean = False

    Public selectedSupplier As Integer = 0
    Public selectedTerm As Integer = 0
    Private Sub PurchaseOrderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSupplier()
        loadTerms()
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

    Private Sub generatePONO()
        Try

            Dim db As New DatabaseConnect
            With db
                .selectByQuery("SELECT COUNT(id) from purchase_orders where supplier = " & selectedSupplier)
                If .dr.Read Then
                    Dim count_supplier As Integer = CInt(.dr.GetValue(0))
                    txtPONO.Text = "PO-" & getSupplierCode(selectedSupplier) & "-" & (count_supplier + 1).ToString("D6")
                End If

                .dr.Close()
                .cmd.Dispose()
                .con.Close()
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

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
            generatePONO()

        Else
            selectedSupplier = 0
            cbSupplier.SelectedIndex = 0
            txtPONO.Text = ""
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

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

    End Sub
End Class