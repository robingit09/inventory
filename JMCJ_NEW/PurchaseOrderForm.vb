Public Class PurchaseOrderForm

    Public isSupplierLoaded As Boolean = False
    Private Sub PurchaseOrderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadSupplier()
        loadTerms()
        loadCategory()
    End Sub

    Public Sub loadSupplier()
        cbSupplier.DataSource = Nothing
        cbSupplier.Items.Clear()

        Dim db As New DatabaseConnect
        With db
            .dbConnect()
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "SELECT id,supplier from suppliers where status <> 0"
            .dr = .cmd.ExecuteReader
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

            If .dr.HasRows Then
                isSupplierLoaded = True
            Else
                isSupplierLoaded = False
            End If
            
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With

    End Sub

    Private Sub generatePONO()
        Dim sup_id As Integer = CInt(DirectCast(cbSupplier.SelectedItem, KeyValuePair(Of String, String)).Key)
        Dim db As New DatabaseConnect
        With db
            .dbConnect()
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "SELECT COUNT(supplier) from purchase_orders where supplier = " & sup_id
            .dr = .cmd.ExecuteReader

            If .dr.Read Then
                Dim count_supplier As Integer = CInt(.dr.GetValue(0))
                txtPONO.Text = "PO-" & getSupplierCode(sup_id) & "-" & (count_supplier + 1).ToString("D6")
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()

        End With

    End Sub

    Private Function getSupplierCode(ByVal sup_id As Integer) As String
        Dim code As String = ""
        Dim db As New DatabaseConnect
        With db
            .dbConnect()
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

        If isSupplierLoaded = True Then
            If cbSupplier.SelectedIndex = 0 Then
                txtPONO.Text = ""
            Else
                generatePONO()
            End If
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

    Private Sub loadCategory()
        cbCategory.Items.Clear()

        Dim db As New DatabaseConnect
        With db
            .dbConnect()
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "SELECT distinct category from products where status <> 0"
            .dr = .cmd.ExecuteReader

            cbCategory.Items.Add("Select Category")
            cbCategory.SelectedIndex = 0
            While .dr.Read
                cbCategory.Items.Add(.dr.GetValue(0))
            End While
            .dr.Close()
            .cmd.Dispose()
            .con.Close()

        End With
    End Sub

    Private Sub loadproduct(ByVal category As String)
        cbProduct.DataSource = Nothing
        cbProduct.Items.Clear()

        Dim db As New DatabaseConnect
        With db
            .dbConnect()
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "SELECT distinct id,name from products where status <> 0 and category like '%" & category & "%'"
            .dr = .cmd.ExecuteReader

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Product")
            While .dr.Read
                Dim id As Integer = CInt(.dr.GetValue(0))
                Dim prod As String = .dr.GetValue(1)
                comboSource.Add(id, prod)
            End While
            cbProduct.DataSource = New BindingSource(comboSource, Nothing)
            cbProduct.DisplayMember = "Value"
            cbProduct.ValueMember = "Key"

            .dr.Close()
            .cmd.Dispose()
            .con.Close()

        End With
    End Sub

    Private Sub cbCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbCategory.SelectedIndexChanged

        If cbCategory.SelectedIndex > 0 Then
            loadproduct(cbCategory.Text)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If cbProduct.SelectedIndex > 0 Then
            Dim prodid As Integer = CInt(DirectCast(cbProduct.SelectedItem, KeyValuePair(Of String, String)).Key)
            addproduct(prodid)

        End If
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub dgvProd_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProd.CellContentClick

    End Sub
End Class