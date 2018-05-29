Public Class ProductForm
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

            MsgBox("Save Successfully!", MsgBoxStyle.Information)


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
            .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = " & category)
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

    Public Sub populateUnit()

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text

        'database.cmd.CommandText = "SELECT name,id FROM unit where status = 1"


        'database.cmd.Connection = database.con

        'Try
        '    database.dr = database.cmd.ExecuteReader


        '    If database.dr.HasRows Then
        '        cbUnit.Items.Clear()

        '        While database.dr.Read
        '            Dim arr(1) As String

        '            Dim id As String = database.dr.GetValue(1)
        '            Dim unit As String = database.dr.GetValue(0)

        '            arr(0) = unit
        '            arr(1) = id


        '            cbUnit.Items.Add(unit)

        '        End While
        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
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
        populateUnit()

    End Sub

    Private Sub cbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategory.SelectedIndexChanged

        If cbCategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbCategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedCategory = CInt(key)
            populateSubcategory(selectedCategory)
            MsgBox(selectedCategory)
        End If

    End Sub

    Private Sub cbSubcategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSubcategory.SelectedIndexChanged
        If cbSubcategory.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbSubcategory.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedSubcategory = CInt(key)
        End If
    End Sub
End Class