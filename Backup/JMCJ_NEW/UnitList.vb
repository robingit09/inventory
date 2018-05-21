Public Class UnitList

  
    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click

        UnitForm.ShowDialog()
    End Sub

    Private Sub UnitList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadList("")
    End Sub

    Public Sub loadList(ByVal key As String)

        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text

        'If key = "" Then
        '    database.cmd.CommandText = "SELECT name,id FROM unit where status = 1"
        'ElseIf txtSearch.Text.Length > 0 Then
        '    database.cmd.CommandText = "SELECT name,id FROM Unit where status = 1"
        '    'ElseIf cbCity.Text.Length > 0 And cbCity.Text <> "All" Then
        '    '    database.cmd.CommandText = "SELECT * FROM company where status = 1 and city like '%" & cbCity.Text & "%'"

        '    'ElseIf cbCity.Text = "All" Then
        '    '    database.cmd.CommandText = "SELECT * FROM company where status = 1"
        'End If

        'database.cmd.Connection = database.con

        'Try
        '    database.dr = database.cmd.ExecuteReader


        '    If database.dr.HasRows Then
        '        lvUnit.Items.Clear()

        '        While database.dr.Read
        '            Dim arr(1) As String

        '            Dim id As String = database.dr.GetValue(1)
        '            Dim unit As String = database.dr.GetValue(0)



        '            arr(0) = unit
        '            arr(1) = id


        '            Dim lvitem As New ListViewItem(arr)
        '            lvUnit.Items.Add(lvitem)


        '        End While

        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        UnitForm.btnSave.Text = "Update"
        UnitForm.ShowDialog()
    End Sub
End Class