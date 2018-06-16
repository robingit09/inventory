Public Class CustomerList
    Public selectedID As String

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CustomerForm.ShowDialog()
    End Sub

    Private Sub frmCustomerList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'loadList("")
        populateComboLocation()
    End Sub

    Public Sub populateComboLocation()


        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text
        'database.cmd.CommandText = "SELECT distinct city FROM company where status = 1"

        'database.cmd.Connection = database.con

        'Try
        '    database.dr = database.cmd.ExecuteReader
        '    If database.dr.HasRows Then
        '        cbCity.Items.Clear()
        '        cbCity.Items.Add("All")

        '        While database.dr.Read

        '            cbCity.Items.Add(database.dr.GetValue(0))
        '        End While


        '    End If
        '    database.con.Close()
        'Catch ex As Exception

        'End Try

    End Sub


    Public Sub loadList(ByVal key As String)

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text

        'If key = "" Then
        '    database.cmd.CommandText = "SELECT * FROM company where status = 1"
        'ElseIf txtSearch.Text.Length > 0 Then
        '    database.cmd.CommandText = "SELECT * FROM company where status = 1 and company like '%" & txtSearch.Text & "%' or contact_person like  '%" & txtSearch.Text & "%'" & _
        '    "or address like '%" & txtSearch.Text & "%' or contact_number1 like '%" & txtSearch.Text & "%' or  contact_number2 like '%" & txtSearch.Text & "%' or  fax_tel like '%" & txtSearch.Text & "%'" & _
        '    "or  tin like '%" & txtSearch.Text & "%' or  email like '%" & txtSearch.Text & "%'"

        'ElseIf cbCity.Text.Length > 0 And cbCity.Text <> "All" Then
        '    database.cmd.CommandText = "SELECT * FROM company where status = 1 and city like '%" & cbCity.Text & "%'"

        'ElseIf cbCity.Text = "All" Then
        '    database.cmd.CommandText = "SELECT * FROM company where status = 1"
        'End If

        'database.cmd.Connection = database.con

        'Try
        '    database.dr = database.cmd.ExecuteReader


        '    If database.dr.HasRows Then
        '        lvCompany.Items.Clear()

        '        While database.dr.Read
        '            Dim arr(12) As String

        '            Dim company As String = database.dr.GetValue(1)
        '            Dim contact_person As String = database.dr.GetValue(2)
        '            Dim address As String = database.dr.GetValue(3)
        '            Dim contact_number1 As String = database.dr.GetValue(4)

        '            Dim contact_number2 As String = database.dr.GetValue(5)
        '            Dim fax_tel As String = database.dr.GetValue(6)
        '            Dim tin As String = database.dr.GetValue(7)
        '            Dim email As String = database.dr.GetValue(8)
        '            Dim st As String = database.dr.GetValue(9)

        '            Dim created As String = database.dr.GetValue(11)
        '            Dim city As String = database.dr.GetValue(12)
        '            Dim id As String = database.dr.GetValue(0)


        '            arr(0) = created
        '            arr(1) = company
        '            arr(2) = address
        '            arr(3) = city
        '            arr(4) = contact_person
        '            arr(5) = contact_number1
        '            arr(6) = contact_number2
        '            arr(7) = fax_tel
        '            arr(8) = tin
        '            arr(9) = email
        '            arr(10) = id

        '            Dim lvitem As New ListViewItem(arr)
        '            lvCompany.Items.Add(lvitem)

        '        End While

        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If txtSearch.Text.Length > 0 Then

        '    loadList(txtSearch.Text)

        'End If
    End Sub

    Private Sub cbCity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'loadList(cbCity.Text)

    End Sub

    Private Sub lvCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If lvCompany.SelectedItems.Count > 0 Then

        '    btnAddNew.Enabled = False
        '    btnEdit.Enabled = True
        '    btnDelete.Enabled = True

        '    Dim id As String
        '    id = lvCompany.SelectedItems.Item(0).SubItems(10).Text
        '    selectedID = id


        '    Dim database As New DatabaseConnect
        '    database.dbConnect()
        '    database.cmd.CommandType = CommandType.Text
        '    database.cmd.CommandText = "SELECT * FROM company where status = 1 and ID = " & id
        '    database.cmd.Connection = database.con
        '    database.dr = database.cmd.ExecuteReader



        '    If database.dr.HasRows Then
        '        'lvEdger.Items.Clear()

        '        If database.dr.Read Then
        '            Dim arr(12) As String

        '            Dim company As String = database.dr.GetValue(1)
        '            Dim contact_person As String = database.dr.GetValue(2)
        '            Dim address As String = database.dr.GetValue(3)
        '            Dim contact_number1 As String = database.dr.GetValue(4)

        '            Dim contact_number2 As String = database.dr.GetValue(5)
        '            Dim fax_tel As String = database.dr.GetValue(6)
        '            Dim tin As String = database.dr.GetValue(7)
        '            Dim email As String = database.dr.GetValue(8)
        '            Dim st As String = database.dr.GetValue(9)

        '            Dim created As String = database.dr.GetValue(11)
        '            Dim city As String = database.dr.GetValue(12)



        '            arr(0) = created
        '            arr(1) = company
        '            arr(2) = address
        '            arr(3) = city
        '            arr(4) = contact_person
        '            arr(5) = contact_number1
        '            arr(6) = contact_number2
        '            arr(7) = fax_tel
        '            arr(8) = tin
        '            arr(9) = email
        '            arr(10) = id


        '            CustomerForm.txtCompany.Text = company
        '            CustomerForm.txtCity.Text = city
        '            CustomerForm.txtAddress.Text = address
        '            CustomerForm.txtContactPerson.Text = contact_person
        '            CustomerForm.txtContact1.Text = contact_number1
        '            CustomerForm.txtContact2.Text = contact_number2
        '            CustomerForm.txtFax.Text = fax_tel
        '            CustomerForm.txtTin.Text = tin
        '            CustomerForm.txtEmail.Text = email



        '        End If

        '    End If

        '    database.con.Close()

        'End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        CustomerForm.btnSave.Text = "Update"
        CustomerForm.ShowDialog()

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If lvCompany.SelectedItems.Count > 0 Then
        '    Dim Yes As Integer = MsgBox("Are you sure you want to delete this file", MsgBoxStyle.YesNo)

        '    If Yes = MsgBoxResult.Yes Then
        '        Dim database As New DatabaseConnect
        '        database.dbConnect()
        '        database.cmd.CommandType = CommandType.Text
        '        database.cmd.CommandText = "UPDATE company SET [status] = '2'   WHERE [ID] = " & selectedID



        '        database.cmd.Connection = database.con

        '        Try
        '            database.cmd.ExecuteNonQuery()
        '            database.con.Close()
        '            MsgBox("Delete Successfully!", MsgBoxStyle.Critical)



        '        Catch ex As Exception
        '            MsgBox(ex.Message & vbNewLine & database.cmd.CommandText, MsgBoxStyle.Critical)
        '        End Try




        '        populateComboLocation()
        '        loadList("")
        '    End If

        'End If


    End Sub


End Class