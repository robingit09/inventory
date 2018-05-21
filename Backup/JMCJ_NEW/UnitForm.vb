Public Class UnitForm

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then

            saveData()

        End If
    End Sub

    Private Sub saveData()

        Dim database As New DatabaseConnect
        database.dbConnect()
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "INSERT INTO Unit([name],[status],[created_at],[updated_at])" & _
        "VALUES(@name,@status,@created_at,@updated_at)"


        database.cmd.Parameters.AddWithValue("@name", txtUnit.Text)

        database.cmd.Parameters.AddWithValue("@st", 1)
        database.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.Date)
        database.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.Date)



        database.cmd.Connection = database.con

        database.cmd.ExecuteNonQuery()
        database.con.Close()
        MsgBox("Unit Save Successfully", MsgBoxStyle.Information)


        txtUnit.Text = ""

        UnitList.loadList("")

        Me.Close()
    End Sub
End Class