Public Class BrandForm
    Public selectedBrand As Integer = 0
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            saveData()
        ElseIf btnSave.Text = "Update" Then
            updateData()
        End If
    End Sub

    Private Sub saveData()
        Dim save As New DatabaseConnect
        With save
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO brand (name,status,created_at,updated_at)VALUES('" & txtBrand.Text & "',1,'" & DateTime.Now.ToString & "','" & DateTime.Now.ToString & "')"
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Save Successfully", MsgBoxStyle.Information)
            BrandList.loadBrand("")
            Me.Close()
        End With
    End Sub

    Private Sub updateData()
        Dim update As New DatabaseConnect
        With update
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE brand set name =?, updated_at = '" & DateTime.Now.ToString & "' where id = " & selectedBrand
            .cmd.Parameters.AddWithValue("@name", txtBrand.Text)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("Update Successfully", MsgBoxStyle.Information)
            BrandList.loadBrand("")
            Me.Close()
        End With
    End Sub

    Private Sub BrandForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBrand.Focus()
    End Sub

    Public Sub toUpdateInfo(ByVal id As Integer)
        If id > 0 Then
            Me.selectedBrand = id
            Dim s As New DatabaseConnect
            With s
                .selectByQuery("SELECT id,name from Brand where status = 1 and id = " & id)
                If .dr.Read Then
                    txtBrand.Text = .dr.GetValue(1)
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With

        End If
    End Sub
End Class