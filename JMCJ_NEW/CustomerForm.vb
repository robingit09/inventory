Public Class CustomerForm

    Public ID As String
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If btnSave.Text = "Save" Then
            saveData()
        ElseIf btnSave.Text = "Update" Then
            updateData()

        End If
    End Sub

    Private Sub updateData()

        Dim database As New DatabaseConnect
        database.dbConnect()
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "UPDATE company SET [company]='" & txtCompany.Text & "',[contact_person]='" & txtContactPerson.Text & "',[address]='" & txtAddress.Text & "',[contact_number1]=" & txtContact1.Text & ", " & _
                                    "[contact_number2]=" & txtContact2.Text & ",[fax_tel]='" & txtFax.Text & "', [tin]=" & txtTin.Text & ",[email]='" & txtEmail.Text & "',[city]='" & txtCity.Text & "' WHERE [ID] = " & CustomerList.selectedID


        database.cmd.Connection = database.con

        Try
            database.cmd.ExecuteNonQuery()
            database.con.Close()
            MsgBox("Customer Update Successfully", MsgBoxStyle.Information)
            Me.Close()


        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & database.cmd.CommandText, MsgBoxStyle.Critical)
        End Try



        CustomerList.populateComboLocation()
        CustomerList.loadList("")
    End Sub

    Private Sub saveData()
        Dim database As New DatabaseConnect
        database.dbConnect()
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "INSERT INTO company([company],[contact_person],[address],[contact_number1],[contact_number2],[fax_tel],[tin],[email],[city],status,[created_at],[updated_at])" & _
        "VALUES(@company,@contact_person,@address,@contact_number1,@contact_number2,@fax_tel,@tin,@email,@city,@st,@created_at,@updated_at)"

        database.cmd.Parameters.AddWithValue("@company", txtCompany.Text)
        database.cmd.Parameters.AddWithValue("@contact_person", txtContactPerson.Text)
        database.cmd.Parameters.AddWithValue("@address", txtAddress.Text)
        database.cmd.Parameters.AddWithValue("@contact_number1", txtContact1.Text)



        database.cmd.Parameters.AddWithValue("@contact_number2", txtContact2.Text)
        database.cmd.Parameters.AddWithValue("@fax_tel", txtFax.Text)

  

        database.cmd.Parameters.AddWithValue("@tin", txtTin.Text)
        database.cmd.Parameters.AddWithValue("@email", txtEmail.Text)
        database.cmd.Parameters.AddWithValue("@city", txtCity.Text)

        database.cmd.Parameters.AddWithValue("@st", 1)

        database.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.Date)

        database.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.Date)
        database.cmd.Connection = database.con

        database.cmd.ExecuteNonQuery()
        database.con.Close()
        MsgBox("Save Successful", MsgBoxStyle.Information)


        txtCompany.Text = ""
        txtAddress.Text = ""
        txtContactPerson.Text = ""
        txtContact1.Text = ""
        txtContact2.Text = ""
        txtEmail.Text = ""

        txtFax.Text = ""
        txtTin.Text = ""

        CustomerList.loadList("")
        CustomerList.populateComboLocation()

        Me.Close()


    End Sub


End Class