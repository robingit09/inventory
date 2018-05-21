Public Class ProductForm


    Private Sub saveData()
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

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text

        'database.cmd.CommandText = "SELECT name,id FROM categories where status = 1"

        'database.cmd.Connection = database.con

        'Try

        '    database.dr = database.cmd.ExecuteReader

        '    If database.dr.HasRows Then
        '        cbCat.Items.Clear()

        '        While database.dr.Read
        '            Dim arr(1) As String

        '            Dim id As String = database.dr.GetValue(1)
        '            Dim category As String = database.dr.GetValue(0)

        '            arr(0) = category
        '            arr(1) = id


        '            cbCat.Items.Add(category)

        '        End While

        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

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

End Class