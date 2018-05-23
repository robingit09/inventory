Public Class CategoryList

    Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click

        CategoryForm.SelectedID = 0
        CategoryForm.txtName.Text = ""
        CategoryForm.btnSave.Text = "Save"
        CategoryForm.ShowDialog()

    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvCat.SelectedRows.Count = 1 Then
            CategoryForm.SelectedID = CInt(dgvCat.SelectedRows(0).Cells(0).Value)
            CategoryForm.toUpdateInfo(CategoryForm.SelectedID)
            CategoryForm.btnSave.Text = "Update"
            CategoryForm.ShowDialog()
        Else
            MsgBox("Please select record to update", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub CategoryList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadList("")

    End Sub

    Public Sub loadList(ByVal key As String)
        dgvCat.Rows.Clear()
        Dim db As New DatabaseConnect
        If key = "" Then
            db.selectByQuery("Select distinct sub.id, c.name,sub.name  from categories c right join categories sub on sub.parent_id = c.id")
        Else

        End If
        With db
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim category As String = If(IsDBNull(.dr.GetValue(1)), "N/A", .dr.GetValue(1))
                    Dim subcat As String = If(IsDBNull(.dr.GetValue(2)), "N/A", .dr.GetValue(2))
                    If category = "N/A" Then
                        Dim temp As String
                        temp = subcat
                        subcat = category
                        category = temp
                    End If

                    Dim row As String() = New String() {id, category, subcat}
                    dgvCat.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With


        'Dim database As New DatabaseConnect
        'database.dbConnect()
        'database.cmd.CommandType = CommandType.Text

        'If key = "" Then
        '    database.cmd.CommandText = "SELECT name,id FROM categories where status = 1"
        'ElseIf txtSearch.Text.Length > 0 Then
        '    database.cmd.CommandText = "SELECT name,id FROM categories where status = 1 and name like '%" & txtSearch.Text & "%'"
        '    'ElseIf cbCity.Text.Length > 0 And cbCity.Text <> "All" Then
        '    '    database.cmd.CommandText = "SELECT * FROM company where status = 1 and city like '%" & cbCity.Text & "%'"

        '    'ElseIf cbCity.Text = "All" Then
        '    '    database.cmd.CommandText = "SELECT * FROM company where status = 1"
        'End If

        'database.cmd.Connection = database.con

        'Try
        '    database.dr = database.cmd.ExecuteReader


        '    If database.dr.HasRows Then
        '        lvCat.Items.Clear()

        '        While database.dr.Read
        '            Dim arr(1) As String

        '            Dim id As String = database.dr.GetValue(1)
        '            Dim category As String = database.dr.GetValue(0)

        '            arr(0) = category
        '            arr(1) = id

        '            Dim lvitem As New ListViewItem(arr)
        '            lvCat.Items.Add(lvitem)



        '        End While

        '    End If

        '    database.con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        If txtSearch.Text.Length > 0 Then
            loadList(txtSearch.Text)
        End If

        If txtSearch.Text.Length <= 0 Then
            loadList("")
        End If
    End Sub

    Private Sub lvCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'If lvCat.SelectedItems.Count > 0 Then
        '    btnAddNew.Enabled = True
        '    btnEdit.Enabled = True
        '    btnDelete.Enabled = True

        'End If


        'If lvCat.SelectedItems.Count <= 0 Then
        '    btnAddNew.Enabled = True
        '    btnEdit.Enabled = False
        '    btnDelete.Enabled = False
        'End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        'If lvCat.SelectedItems.Count > 0 Then
        '    Dim category As String = lvCat.SelectedItems(0).SubItems(0).Text
        '    Dim key As Integer = CInt(lvCat.SelectedItems(0).SubItems(1).Text)

        '    Dim yesno = MsgBox("Are you sure you want to delete " & category & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        '    If yesno = MsgBoxResult.Yes Then
        '        Try
        '            Dim db As New DatabaseConnect
        '            db.dbConnect()
        '            With db.cmd
        '                .CommandType = CommandType.Text
        '                .CommandText = "UPDATE categories set [status] = 2, [updated_at] = '" & DateTime.Now.ToString & "' where ID = " & key
        '                .Connection = db.con
        '                .ExecuteNonQuery()
        '                .Dispose()
        '                db.con.Close()
        '                loadList("")
        '                MsgBox(category & "successfully deleted", MsgBoxStyle.Critical)

        '            End With
        '        Catch ex As Exception
        '            MsgBox(ex.Message, MsgBoxStyle.Critical)
        '        End Try

        '    End If
        'Else
        '    MsgBox("Please select category you want to delete", MsgBoxStyle.Exclamation)
        'End If

    End Sub

    Private Sub dgvCat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCat.CellContentClick

    End Sub

End Class
