Public Class UserForm

    Public selectedUser As Integer = 0
    Public selectedpos As Integer = 0
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then

            If validation() = False Then
                Exit Sub
            End If
            insertData()
            clearFields()
            Users.loadList("")
            Me.Close()
        End If

        If btnSave.Text = "Update" Then

            If validation() = False Then
                Exit Sub
            End If
            updateData()
            clearFields()
            Users.loadList("")
            Me.Close()

        End If
    End Sub

    Public Sub initialize()
        loadPosition()
    End Sub

    Private Sub insertData()
        Dim insertuser As New DatabaseConnect
        With insertuser
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "INSERT INTO [users] ([user_group],[first_name],[surname],[username],[password],[created_at],[updated_at],[address],[contact_no],[in_case_of_emergency])
            VALUES(?,?,?,?,?,?,?,?,?,?)"
            .cmd.Parameters.AddWithValue("@user_group", selectedpos)
            .cmd.Parameters.AddWithValue("@first_name", Trim(txtFN.Text))
            .cmd.Parameters.AddWithValue("@surname", Trim(txtLN.Text))
            .cmd.Parameters.AddWithValue("@username", Trim(txtUser.Text))
            .cmd.Parameters.AddWithValue("@password", Trim(txtCPW.Text))
            .cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            .cmd.Parameters.AddWithValue("@address", txtAddress.Text)
            .cmd.Parameters.AddWithValue("@contact_no", txtContactNo.Text)
            .cmd.Parameters.AddWithValue("@in_case_of_emergency", txtInCaseOfEmergency.Text)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("User Successfully Saved.", MsgBoxStyle.Information)
        End With
    End Sub

    Private Sub updateData()
        Dim updateuser As New DatabaseConnect
        With updateuser
            .cmd.Connection = .con
            .cmd.CommandType = CommandType.Text
            .cmd.CommandText = "UPDATE users set [first_name]='" & Trim(txtFN.Text) & "', [surname] ='" & Trim(txtLN.Text) & "',[user_group]=" & selectedpos & ", [username]='" & Trim(txtUser.Text) & "',[password]='" & Trim(txtPW.Text) & "',[address] = '" & Trim(txtAddress.Text) & "', [contact_no] = '" & txtContactNo.Text & "', [in_case_of_emergency]  = '" & txtInCaseOfEmergency.Text & "',
            [updated_at] ='" & DateTime.Now.ToString & "' where id=" & selectedUser

            '.cmd.Parameters.AddWithValue("@first_name", Trim(txtFN.Text))
            '.cmd.Parameters.AddWithValue("@surname", Trim(txtLN.Text))
            '.cmd.Parameters.AddWithValue("@user_group", selectedpos)
            '.cmd.Parameters.AddWithValue("@username", Trim(txtUser.Text))
            '.cmd.Parameters.AddWithValue("@password", Trim(txtPW.Text))
            '.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
            '.cmd.Parameters.AddWithValue("@id", selectedUser)
            .cmd.ExecuteNonQuery()
            .cmd.Dispose()
            .con.Close()
            MsgBox("User Successfully Update.", MsgBoxStyle.Information)
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

        If cbPosition.SelectedIndex = 0 Then
            MsgBox("Position field is required!", MsgBoxStyle.Critical)
            cbPosition.Focus()
            Return False
        End If

        If Trim(txtPW.Text) = "" Then
            MsgBox("Password field is required!", MsgBoxStyle.Critical)
            txtPW.Focus()
            Return False
        End If

        If Trim(txtPW.Text.ToLower) <> Trim(txtCPW.Text.ToLower) Then
            MsgBox("Password did not match!", MsgBoxStyle.Critical)
            txtCPW.Focus()
            txtCPW.SelectAll()
            Return False
        End If

        If Trim(txtAddress.Text) = "" Then
            MsgBox("Address field is required!", MsgBoxStyle.Critical)
            txtAddress.Focus()
            Return False
        End If

        If Trim(txtContactNo.Text) = "" Then
            MsgBox("Contact Number field is required!", MsgBoxStyle.Critical)
            txtContactNo.Focus()
            Return False
        End If

        If Trim(txtInCaseOfEmergency.Text) = "" Then
            MsgBox("In case of emergency field is required!", MsgBoxStyle.Critical)
            txtInCaseOfEmergency.Focus()
            Return False
        End If

        Return True
    End Function

    Public Sub clearFields()
        txtFN.Clear()
        txtLN.Clear()
        If cbPosition.Items.Count > 0 Then
            cbPosition.SelectedIndex = 0
            selectedpos = 0
        Else
            selectedpos = 0
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
        'loadPosition()
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

    Public Sub loadInfo(ByVal id As Integer)
        selectedUser = id
        Dim dbuser As New DatabaseConnect
        With dbuser
            .selectByQuery("Select * from users where id = " & id)
            If .dr.Read Then
                txtFN.Text = If(IsDBNull(.dr("first_name")), " ", .dr("first_name"))
                txtLN.Text = If(IsDBNull(.dr("surname")), " ", .dr("surname"))

                Dim user_group As String = New DatabaseConnect().get_by_id("user_groups", CInt(.dr("user_group")), "user_group")
                cbPosition.SelectedIndex = cbPosition.FindString(user_group)
                txtUser.Text = If(IsDBNull(.dr("username")), " ", .dr("username"))
                txtPW.Text = If(IsDBNull(.dr("password")), " ", .dr("password"))
                txtCPW.Text = If(IsDBNull(.dr("password")), " ", .dr("password"))
                txtAddress.Text = If(IsDBNull(.dr("address")), " ", .dr("address"))
                txtContactNo.Text = If(IsDBNull(.dr("contact_no")), " ", .dr("contact_no"))
                txtInCaseOfEmergency.Text = If(IsDBNull(.dr("in_case_of_emergency")), " ", .dr("in_case_of_emergency"))

            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub
End Class