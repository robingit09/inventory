Public Class UserGroups
    Private Sub UserGroups_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList("")
    End Sub

    Public Sub loadList(ByVal query As String)

        dgvUserGroup.Rows.Clear()
        Dim dbPO As New DatabaseConnect
        With dbPO
            If query = "" Then
                .selectByQuery("Select * from user_groups order by id")
            Else
                .selectByQuery(query)
            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As String = .dr("id")

                    Dim position As String = .dr("user_group")
                    Dim created_at As String = Convert.ToDateTime(.dr("created_at")).ToString("MM-dd-yyyy")
                    Dim status As String = ""

                    Select Case .dr("status")
                        Case "0"
                            status = "Deleted/Inactive"
                        Case "1"
                            status = "Active"

                    End Select

                    Dim row As String() = New String() {id, position.ToUpper, created_at, status}
                    dgvUserGroup.Rows.Add(row)
                End While
                For Each row As DataGridViewRow In dgvUserGroup.Rows
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
        UserGroupForm.clearFields()
        UserGroupForm.checkAll(True)
        UserGroupForm.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        btnUpdate.Enabled = False
        If dgvUserGroup.SelectedRows.Count = 1 Then
            Dim id As Integer = CInt(dgvUserGroup.SelectedRows(0).Cells("id").Value.ToString)
            UserGroupForm.loadInfo(id)
            UserGroupForm.btnSave.Text = "Update"
            UserGroupForm.ShowDialog()
        Else
            MsgBox("Please select one!", MsgBoxStyle.Critical)
        End If
        btnUpdate.Enabled = True
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvUserGroup.SelectedRows.Count = 1 Then
            Dim position As String = dgvUserGroup.SelectedRows(0).Cells("position").Value.ToString()

            If position = "ADMIN" Then
                MsgBox("Unable to delete admin.", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Else

        End If
    End Sub
End Class