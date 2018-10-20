Public Class UserForm

    Public selectedpos As Integer = 0
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then

            If validation() = False Then
                Exit Sub
            End If
            insertData()
            clearFields()

        End If
    End Sub

    Private Sub insertData()
        Dim insertuser As New DatabaseConnect
        With insertuser
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO users (user_group,first_name,surname,username,password,created_at,updated_at)
                VALUES(?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@user_group", selectedpos)
            .cmd.Parameters.AddWithValue("@first_name", Trim(txtFN.Text))
            .cmd.Parameters.AddWithValue("@surname", Trim(txtLN.Text))
            .cmd.Parameters.AddWithValue("@username", Trim(txtUser.Text))
            .cmd.Parameters.AddWithValue("@password", Trim(txtCPW.Text))
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("User Successfully Saved.", MsgBoxStyle.Information)
        End With
    End Sub

    Private Function validation() As Boolean
        If Trim(txtFN.Text) = "" Then
            MsgBox("First name field is required!", MsgBoxStyle.Critical)
            txtFN.Focus()
            Return False
        End If

        If Trim(txtLN.Text) = "" Then
            MsgBox("Last name field is required!", MsgBoxStyle.Critical)
            txtLN.Focus()
            Return False
        End If

        If Trim(txtPW.Text.ToLower) <> Trim(txtCPW.Text.ToLower) Then
            txtCPW.Focus()
            txtCPW.SelectAll()
            Return False
        End If

        Return True
    End Function

    Public Sub clearFields()
        txtFN.Clear()
        txtLN.Clear()
        If cbPosition.Items.Count > 0 Then
            cbPosition.SelectedIndex = 0
        End If
        txtUser.Clear()
        txtPW.Clear()
        txtCPW.Clear()
    End Sub

    Public Sub loadPosition()
        cbPosition.DataSource = Nothing
        cbPosition.Items.Clear()
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("SELECT id,user_group from user_groups where status <> 0")
            Dim comboSource As New Dictionary(Of String, String)()
            comboSource.Add(0, "Select User Type")
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = CInt(.dr("id"))
                    Dim ug As String = .dr("user_group")
                    comboSource.Add(id, ug.ToUpper)
                End While
            End If
            cbPosition.DataSource = New BindingSource(comboSource, Nothing)
            cbPosition.DisplayMember = "Value"
            cbPosition.ValueMember = "Key"
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPosition()
    End Sub

    Private Sub cbPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPosition.SelectedIndexChanged
        If cbPosition.SelectedIndex > 0 Then
            cbPosition.BackColor = Drawing.Color.White
            Dim key As String = DirectCast(cbPosition.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbPosition.SelectedItem, KeyValuePair(Of String, String)).Value
            selectedpos = key

        Else
            selectedpos = 0
        End If
    End Sub
End Class