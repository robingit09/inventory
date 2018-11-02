Public Class Login
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If Trim(txtUser.Text) = "" Or Trim(txtPW.Text) = "" Then
            MsgBox("Please input your username or password", MsgBoxStyle.Critical)
            txtUser.Focus()
            Exit Sub
        End If
        Dim dblogin As New DatabaseConnect
        With dblogin
            .selectByQuery("select * from users where status = 1 and username = '" & Trim(txtUser.Text) & "' and password = '" & Trim(txtPW.Text) & "'")
            If .dr.HasRows Then
                If .dr.Read Then
                    Main_form.current_user_id = CInt(.dr("id"))
                    Main_form.ShowDialog()
                    Me.Close()
                End If
            Else
                MsgBox("Incorrect username or password!", MsgBoxStyle.Critical)
                txtPW.Text = ""
                txtPW.Focus()
                Main_form.current_user_id = 0
            End If

        End With
    End Sub

    Private Sub txtPW_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPW.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
    End Sub
End Class