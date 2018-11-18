Public Class Users
    Private Sub Users_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList("")
    End Sub

    Public Sub loadList(ByVal query As String)
        dgvUser.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            If query = "" Then
                .selectByQuery("Select * from users order by id desc")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")
                    Dim username As String = .dr("username")
                    Dim position As String = New DatabaseConnect().get_by_id("user_groups", CInt(.dr("user_group")), "user_group")
                    Dim firstname As String = .dr("first_name")
                    Dim surname As String = .dr("surname")
                    Dim created_at As String = Convert.ToDateTime(.dr("created_at")).ToString("MM-dd-yyyy")
                    Dim status As String = ""

                    Select Case .dr("status")
                        Case "0"
                            status = "Deleted/Inactive"
                        Case "1"
                            status = "Active"

                    End Select

                    Dim row As String() = New String() {id, username, position.ToUpper, firstname, surname, created_at, status}
                    dgvUser.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvUser.Rows
                    If row.Cells("status").Value = "Deleted/Inactive" Then
                        row.DefaultCellStyle.BackColor = Drawing.Color.Yellow
                    End If
                Next
            End If

            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        UserForm.initialize()
        UserForm.clearFields()
        UserForm.btnSave.Text = "Save"
        UserForm.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvUser.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(dgvUser.SelectedRows(0).Cells("id").Value)
            UserForm.initialize()
            UserForm.loadInfo(id)
            UserForm.btnSave.Text = "Update"
            UserForm.ShowDialog()
        Else
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUser.SelectedRows.Count = 1 Then

            Dim yesno As Integer = MsgBox("Are you sure you want to delete this record ? ", MsgBoxStyle.YesNo + MsgBoxStyle.Information)

            If yesno = DialogResult.Yes Then
                Dim id As Integer = CInt(dgvUser.SelectedRows(0).Cells("id").Value)
                Dim dbupdate As New DatabaseConnect
                dbupdate.update_where("users", id, "status", 0)
                Me.loadList("")
                MsgBox("Users successfully deleted.", MsgBoxStyle.Information)
            End If

        Else
            MsgBox("Please select one record!", MsgBoxStyle.Critical)
        End If
    End Sub
End Class