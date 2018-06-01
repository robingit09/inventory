Public Class ProductForm
    Public selectedProduct As Integer = 0
    Private selectedCategory As Integer = 0
    Private selectedSubcategory As Integer = 0
    Private Sub saveData()
        Dim prod_id = getLatestID("products") + 1
        Dim db As New DatabaseConnect
        With db
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO PRODUCTS (barcode,description,status,created_at,updated_at)
        VALUES ('" & txtBarcode.Text & "','" & txtProduct.Text & "',1,'" & DateTime.Now.ToString & "','" & DateTime.Now.ToString & "')"
            If (.cmd.ExecuteNonQuery()) Then
                .cmd.CommandText = "INSERT INTO product_categories (product_id,category_id) VALUES(" & prod_id & "," & selectedCategory & ")"
                .cmd.ExecuteNonQuery()

                .cmd.CommandText = "INSERT INTO product_subcategories (product_id,subcategory_id) VALUES(" & prod_id & "," & selectedSubcategory & ")"
                .cmd.ExecuteNonQuery()

            End If
            .cmd.Dispose()
            .con.Close()

            Dim dbdelete As New DatabaseConnect
            With dbdelete
                .delete_permanent("product_unit", "product_id", prod_id)
                .delete_permanent("product_prices", "product_id", prod_id)
                .cmd.Dispose()
                .con.Close()
            End With

            If dgvMeasurement.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgvMeasurement.Rows
                    Dim barcode As String = row.Cells("barcode").Value
                    Dim brand As String = row.Cells("brand").Value
                    Dim unit As String = row.Cells("unit").Value
                    If barcode = "" And brand = "" And unit = "" Then

                    Else
                        Dim dbinsertUnit As New DatabaseConnect
                        With dbinsertUnit
                            .cmd.Connection = .con
                            .cmd.CommandType = CommandType.Text
                            .cmd.CommandText = "INSERT INTO product_unit (product_id,brand,unit,barcode,created_at,updated_at)VALUES(?,?,?,?,?,?)"
                            .cmd.Parameters.AddWithValue("@product_id", prod_id)
                            .cmd.Parameters.AddWithValue("@brand", brand)
                            .cmd.Parameters.AddWithValue("@unit", unit)
                            .cmd.Parameters.AddWithValue("@barcode", barcode)
                            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
                            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
                            .cmd.ExecuteNonQuery()
                            .cmd.Dispose()
                            .con.Close()

                        End With
                    End If

                Next
            End If

            MsgBox("Save Successfully!", MsgBoxStyle.Information)
            Me.Close()
        End With

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text
        'database.cmd.CommandText = "INSERT INTO products([name],[category],[brand],[unit],[quantity],[price],[created_at],[updated_at],[status])" & _
        '"VALUES(@name,@category,@brand,@unit,@quantity,@price,@created_at,@updated_at,@st)"

        'database.cmd.Parameters.AddWithValue("@name", txtProduct.Text)
        'database.cmd.Parameters.AddWithValue("@category", cbCat.Text)
        'database.cmd.Parameters.AddWithValue("@brand", txtBrand.Text)
        'database.cmd.Parameters.AddWithValue("@unit", cbUnit.Text)


        'database.cmd.Parameters.AddWithValue("@quantity", txtQty.Text)
        'database.cmd.Parameters.AddWithValue("@price", txtPrice.Text)


        'database.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.Date)
        'database.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.Date)
        'database.cmd.Parameters.AddWithValue("@st", 1)
        'database.cmd.Connection = database.con
        'database.cmd.ExecuteNonQuery()
        'database.con.Close()
        'MsgBox("Save Successful", MsgBoxStyle.Information)

        ''ProductList.lvEdger.Items.Clear()
        ''frmListEdger.loadList("")

        'txtProduct.Text = ""
        'txtBrand.Text = ""
        'cbCat.Text = ""
        'cbUnit.Text = ""
        'txtQty.Text = ""


        'txtPrice.Text = ""

        'ProductList.loadList("")

        'Me.Close()

    End Sub

    Private Function getLatestID(ByVal table As String) As Integer
        Dim result As Integer = 0
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select TOP 1 id from " & table & " ORDER BY created_at desc")
            If .dr.Read Then
                result = .dr.GetValue(0)
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
        Return result
    End Function

    Private Sub updateData()

        '        Dim database As New DatabaseConnect
        '        database.dbConnect()
        '        database.cmd.CommandType = CommandType.Text
        '        database.cmd.CommandText = "UPDATE products SET [name]='" & txtProduct.Text & "',[category]='" & cbCat.Text & "',[brand]='" & txtBrand.Text & "',[unit]='" & cbUnit.Text & "', " & _
        '"[quantity]='" & txtQty.Text & "',[price]='" & txtPrice.Text & "', [updated_at]='" & DateTime.Now.Date & "' WHERE [ID] = " & ProductList.selectedID


        '        database.cmd.Connection = database.con

        '        Try
        '            database.cmd.ExecuteNonQuery()
        '            database.con.Close()
        '            MsgBox("Update Successfully", MsgBoxStyle.Information)



        '        Catch ex As Exception
        '            MsgBox(ex.Message & vbNewLine & database.cmd.CommandText, MsgBoxStyle.Critical)
        '        End Try

        '        'frmCustomerList.populateComboLocation()
        '        ProductList.loadList("")
        '        Me.Close()

    End Sub

    Public Sub populateCategory()
        cbCategory.DataSource = Nothing
        cbCategory.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Category")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = 0")
            If .dr.Read Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
                cbCategory.DataSource = New BindingSource(comboSource, Nothing)
                cbCategory.DisplayMember = "Value"
                cbCategory.ValueMember = "Key"
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Public Sub populateSubcategory(ByVal category As Integer)
        cbSubcategory.DataSource = Nothing
        cbSubcategory.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Subcategory")
        Dim db As New DatabaseConnect
        With db
            If category > 0 Then
                .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = " & category)
            ElseIf category = 0 Then
                .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id <> 0 ")
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()

            cbSubcategory.DataSource = New BindingSource(comboSource, Nothing)
            cbSubcategory.DisplayMember = "Value"
            cbSubcategory.ValueMember = "Key"
        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            saveData()
        ElseIf btnSave.Text = "Update" Then
            updateData()
        End If

    End Sub

    Private Sub ProductForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        populateCategory()
        populateSubcategory(0)

    End Sub

    Public Sub initializeMeasure()

        If dgvMeasurement.Rows.Count = 1 Then
            Try
                Dim dtgCol As DataGridViewComboBoxCell

                dgvMeasurement.Rows(0).Cells(0).Value = ""
                dtgCol = dgvMeasurement.Rows(0).Cells(1)

                Dim comboSource As New Dictionary(Of String, String)()
                'comboSource.Add(0, "Select Brand")
                Dim dbbrand As New DatabaseConnect
                With dbbrand
                    .selectByQuery("Select id,name from brand where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))
                        End While
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                    dtgCol.DataSource = New BindingSource(comboSource, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With

                Dim comboSourceUnit As New Dictionary(Of String, String)()
                dtgCol = dgvMeasurement.Rows(0).Cells(2)

                Dim dbUnit As New DatabaseConnect
                With dbUnit
                    .selectByQuery("Select id,name from unit where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSourceUnit.Add(.dr.GetValue(0), .dr.GetValue(1))

                        End While
                    End If
                    dtgCol.DataSource = New BindingSource(comboSourceUnit, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With

                dgvMeasurement.Rows(0).Cells(3).Value = "Remove -"
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub initializePrices()
        If dgvPrices.Rows.Count = 1 Then
            Try
                Dim dtgCol As DataGridViewComboBoxCell

                dgvMeasurement.Rows(0).Cells(0).Value = ""
                dtgCol = dgvMeasurement.Rows(0).Cells(1)

                Dim comboSource As New Dictionary(Of String, String)()
                'comboSource.Add(0, "Select Brand")
                Dim dbbrand As New DatabaseConnect
                With dbbrand
                    .selectByQuery("Select id,name from brand where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))
                        End While
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                    dtgCol.DataSource = New BindingSource(comboSource, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With

                Dim comboSourceUnit As New Dictionary(Of String, String)()
                dtgCol = dgvMeasurement.Rows(2).Cells(3)

                Dim dbUnit As New DatabaseConnect
                With dbUnit
                    .selectByQuery("Select id,name from unit where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSourceUnit.Add(.dr.GetValue(0), .dr.GetValue(1))

                        End While
                    End If
                    dtgCol.DataSource = New BindingSource(comboSourceUnit, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With

                dgvMeasurement.Rows(3).Cells(4).Value = "Remove -"
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged

        If cbCategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCategory = CInt(key)
            populateSubcategory(selectedCategory)
            MsgBox(selectedCategory)
        ElseIf cbCategory.SelectedIndex = 0 Then
            populateSubcategory(0)
        End If

    End Sub

    Private Sub cbSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubcategory.SelectedIndexChanged
        If cbSubcategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSubcategory = CInt(key)
        End If
    End Sub

    Private Sub btnAddMoreUnit_Click(sxxender As Object, e As EventArgs) Handles btnAddMoreUnit.Click
        Try
            Dim dtgCol As DataGridViewComboBoxCell

            dgvMeasurement.Rows.Add(1)

            dgvMeasurement.Rows(dgvMeasurement.Rows.Count - 1).Cells(0).Value = "992423234"

            dtgCol = dgvMeasurement.Rows(dgvMeasurement.Rows.Count - 1).Cells(1)

            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select Brand")
            comboSource.Add(1, "Brand 1")
            comboSource.Add(2, "Brand 2")
            dtgCol.DataSource = New BindingSource(comboSource, Nothing)
            dtgCol.DisplayMember = "Value"
            dtgCol.ValueMember = "Key"


            dtgCol = dgvMeasurement.Rows(dgvMeasurement.Rows.Count - 1).Cells(2)
            dtgCol.Items.Add("unit 1")
            dtgCol.Items.Add("unit 2")

            dgvMeasurement.Rows(dgvMeasurement.Rows.Count - 1).Cells(3).Value = "Remove -"
        Catch ex As Exception

        End Try

    End Sub

    Public Sub addMeasure()

    End Sub

    Public Sub addPrices()

    End Sub

    Private Sub dgvMeasurement_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMeasurement.CellClick

        If (e.RowIndex = dgvMeasurement.NewRowIndex Or e.RowIndex < 0) Then
            Exit Sub
        End If

        'Check if click Is on specific column 
        If (e.ColumnIndex = dgvMeasurement.Columns("remove_column").Index) Then
            dgvMeasurement.Rows.RemoveAt(e.RowIndex)
        End If

    End Sub

    Private Sub dgvMeasurement_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvMeasurement.RowsAdded
        If dgvMeasurement.Rows.Count <> 1 Then
            Try
                Dim dtgCol As DataGridViewComboBoxCell

                dgvMeasurement.Rows(e.RowIndex).Cells(0).Value = ""
                dtgCol = dgvMeasurement.Rows(e.RowIndex).Cells(1)

                Dim comboSource As New Dictionary(Of String, String)()
                'comboSource.Add(0, "Select Brand")
                Dim dbbrand As New DatabaseConnect
                With dbbrand
                    .selectByQuery("Select id,name from brand where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSource.Add(.dr.GetValue(0), .dr.GetValue(1))
                        End While
                    End If
                    .cmd.Dispose()
                    .dr.Close()
                    .con.Close()
                    dtgCol.DataSource = New BindingSource(comboSource, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With

                Dim comboSourceUnit As New Dictionary(Of String, String)()
                dtgCol = dgvMeasurement.Rows(e.RowIndex).Cells(2)

                Dim dbUnit As New DatabaseConnect
                With dbUnit
                    .selectByQuery("Select id,name from unit where status = 1")
                    If .dr.HasRows Then
                        While .dr.Read
                            comboSourceUnit.Add(.dr.GetValue(0), .dr.GetValue(1))

                        End While
                    End If
                    dtgCol.DataSource = New BindingSource(comboSourceUnit, Nothing)
                    dtgCol.DisplayMember = "Value"
                    dtgCol.ValueMember = "Key"
                End With

                dgvMeasurement.Rows(e.RowIndex).Cells(3).Value = "Remove -"
            Catch ex As Exception

            End Try
        End If
    End Sub

End Class