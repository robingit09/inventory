﻿Public Class ColorList
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
                .selectByQuery("Select id,name,created_at from color where status <> 0 order by name")
            Else

            End If

            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr("id")
                    Dim name As String = .dr("name")
                    Dim created_at As String = Convert.ToDateTime(.dr("created_at")).ToString("MM-dd-yy")
                    Dim row As String() = New String() {id, name, created_at}
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

        'check user access
        If ModelFunction.check_access(5, 1) = 1 Then
            btnAddNew.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
        Else
            btnAddNew.Enabled = False
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        End If
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvColor.SelectedRows.Count = 1 Then
            Dim yesno As Integer = MsgBox("Are you sure you want to delete Color(" & dgvColor.SelectedRows(0).Cells(1).Value & ") ? ", MsgBoxStyle.Information + MsgBoxStyle.YesNo)

            If yesno = MsgBoxResult.Yes Then
                Dim id As String = dgvColor.SelectedRows(0).Cells(0).Value
                Dim dbdelete As New DatabaseConnect()
                With dbdelete
                    .update_where("color", id, "status", 0)
                End With
                loadList("")
            End If

        Else
            MsgBox("Select a Color.", MsgBoxStyle.Critical)
        End If
    End Sub
End Class