Imports System.Data.OleDb
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
                    Dim firstname As String = New DatabaseConnect().get_by_id("users", CInt(.dr("id")), "first_name")
                    Dim lastname As String = New DatabaseConnect().get_by_id("users", CInt(.dr("id")), "surname")
                    Main_form.lblFullname.Text = firstname & " " & lastname
                    Main_form.ShowDialog()

                    txtUser.Clear()
                    txtPW.Clear()
                    Me.Close()

                End If
            Else
                MsgBox("Incorrect username or password!", MsgBoxStyle.Critical)
                txtPW.Text = ""
                txtPW.Focus()
                Main_form.current_user_id = 0
            End If
            '.dr.Close()
            '.con.Close()
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

    Private Sub ConnectionSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectionSettingsToolStripMenuItem.Click
        btnTest.ShowDialog()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ModuleSettings.forTest = 1 Then
            MsgBox("You are in a Test Mode", MsgBoxStyle.Exclamation, "System Mode")
        Else

        End If


        getConnectionStatus()
    End Sub

    Public Sub getConnectionStatus()
        Dim con As New OleDbConnection
        Dim cmd As New OleDbCommand

        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ModuleSettings.get_db_path
        Try
            con.Open()
            lblstatus.Text = "Connected"
            lblstatus.ForeColor = Drawing.Color.Green

        Catch ex As Exception
            lblstatus.Text = "Failed"
            lblstatus.ForeColor = Drawing.Color.Red
        End Try

    End Sub
End Class