Public Class UnitForm
    Public selectedUnit As Integer = 0
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            saveData()
        ElseIf btnSave.Text = "Update" Then
            updateData()
        End If
    End Sub

    Public Sub toUpdateInfo(ByVal id As Integer)
        If id > 0 Then
            Dim db As New DatabaseConnect
            With db
                .selectByQuery("Select name from unit where status = 1 and id =" & Me.selectedUnit)
                If .dr.Read Then
                    txtUnit.Text = .dr.GetValue(0)
                End If
                .cmd.Dispose()
                .dr.Close()
                .con.Close()
            End With
        End If
    End Sub

    Private Sub saveData()

        Dim database As New DatabaseConnect
        database.cmd.CommandType = CommandType.Text
        database.cmd.Connection = database.con
        database.cmd.CommandText = "INSERT INTO Unit([name],[status],[created_at],[updated_at])" &
        "VALUES(@name,@status,@created_at,@updated_at)"

        database.cmd.Parameters.AddWithValue("@name", txtUnit.Text)
        database.cmd.Parameters.AddWithValue("@st", 1)
        database.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.Date.ToString)
        database.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.Date.ToString)
        database.cmd.ExecuteNonQuery()
        database.con.Close()
        MsgBox("Unit Save Successfully", MsgBoxStyle.Information)
        txtUnit.Text = ""
        UnitList.loadList("")
        Me.Close()
    End Sub

    Private Sub updateData()
        Dim db As New DatabaseConnect
        With db
            .cmd.CommandType = CommandType.Text
            .cmd.Connection = .con
            .cmd.CommandText = "UPDATE unit set name = ? , updated_at = ? where id = " & selectedUnit
            .cmd.Parameters.AddWithValue("@name", txtUnit.Text)
            .cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.Date.ToString)
            .cmd.ExecuteNonQuery()
            .con.Close()
            MsgBox("Unit Update Successfully", MsgBoxStyle.Information)
            txtUnit.Text = ""
            UnitList.loadList("")
            Me.Close()
        End With

    End Sub

    Private Sub UnitForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUnit.Focus()
    End Sub
End Class