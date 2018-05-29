Public Class ProductList

    Public selectedID As String

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProductForm.ShowDialog()
    End Sub

    Private Sub ProductList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        loadList("")
        populateCategory()


    End Sub

    Public Sub populateCategory()

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text

        'database.cmd.CommandText = "SELECT category FROM products where status = 1"

        'database.cmd.Connection = database.con

        'Try
        '    database.dr = database.cmd.ExecuteReader


        '    If database.dr.HasRows Then
        '        cbCat.Items.Clear()
        '        cbCat.Items.Add("All")

        '        While database.dr.Read
        '            Dim arr(1) As String


        '            Dim category As String = database.dr.GetValue(0)

        '            arr(0) = category



        '            cbCat.Items.Add(category)


        '        End While

        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try




    End Sub

    Public Sub loadList(ByVal key As String)

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text

        'If key = "" Then
        '    database.cmd.CommandText = "SELECT * FROM products where status = 1"
        'ElseIf txtSearch.Text.Length > 0 Then
        '    database.cmd.CommandText = "SELECT * FROM products where status = 1 and company like '%" & txtSearch.Text & "%' or contact_person like  '%" & txtSearch.Text & "%'" & _
        '    "or address like '%" & txtSearch.Text & "%' or contact_number1 like '%" & txtSearch.Text & "%' or  contact_number2 like '%" & txtSearch.Text & "%' or  fax_tel like '%" & txtSearch.Text & "%'" & _
        '    "or  tin like '%" & txtSearch.Text & "%' or  email like '%" & txtSearch.Text & "%'"

        'ElseIf cbCat.Text.Length > 0 And cbCat.Text <> "All" Then

        '    database.cmd.CommandText = "SELECT * FROM products where status = 1 and category = '" & cbCat.Text & "'"
        'ElseIf cbCat.Text = "All" Then

        '    database.cmd.CommandText = "SELECT * FROM products where status = 1"
        'End If

        'database.cmd.Connection = database.con

        'Try
        '    database.dr = database.cmd.ExecuteReader


        '    If database.dr.HasRows Then
        '        lvProducts.Items.Clear()

        '        While database.dr.Read
        '            Dim arr(8) As String

        '            Dim name As String = database.dr.GetValue(1)
        '            Dim category As String = database.dr.GetValue(2)
        '            Dim brand As String = database.dr.GetValue(3)
        '            Dim unit As String = database.dr.GetValue(4)

        '            Dim quantity As String = database.dr.GetValue(5)
        '            Dim price As String = database.dr.GetValue(6)

        '            Dim created_at As String = database.dr.GetValue(8)

        '            Dim id As String = database.dr.GetValue(0)

        '            arr(0) = created_at
        '            arr(1) = name
        '            arr(2) = category
        '            arr(3) = brand
        '            arr(4) = unit
        '            arr(5) = quantity
        '            arr(6) = price
        '            arr(7) = id

        '            Dim lvitem As New ListViewItem(arr)
        '            lvProducts.Items.Add(lvitem)


        '        End While

        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

   
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ProductForm.btnSave.Text = "Update"
        ProductForm.ShowDialog()

    End Sub
    
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ProductForm.btnSave.Text = "Save"
        ProductForm.ShowDialog()

    End Sub
End Class