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
                    Main_form.auth_login = CInt(.dr("id"))
                    Main_form.ShowDialog()

                End If
            Else
                MsgBox("Incorrect username or password!", MsgBoxStyle.Critical)
                txtPW.Text = ""
                Main_form.auth_login = 0
            End If


        End With

    End Sub

End Class