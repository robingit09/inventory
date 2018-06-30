Public Class ColorList
    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        ColorForm.btnSave.Text = "Save"
        ColorForm.txtColor.Clear()
        ColorForm.ShowDialog()
    End Sub

    Public Sub loadList(ByVal q As String)
        dgvColor.Rows.Clear()
        Dim db As New DatabaseConnect
        With db
            If q = "" Then
                .selectByQuery("Select id,name from color where status <> 0 order by name")
            Else

            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr("id")
                    Dim name As String = .dr("name")
                    Dim row As String() = New String() {id, name}
                    dgvColor.Rows.Add(row)
                End While
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub ColorList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList("")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvColor.SelectedRows.Count = 1 Then
            ColorForm.selectedColor = dgvColor.SelectedRows(0).Cells("id").Value
            ColorForm.toUpdateInfo(dgvColor.SelectedRows(0).Cells("id").Value)
            ColorForm.btnSave.Text = "Update"
            ColorForm.ShowDialog()
        Else
            MsgBox("Please select one to update", MsgBoxStyle.Critical)
            dgvColor.Focus()
        End If
    End Sub
End Class