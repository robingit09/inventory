Public Class CategoryForm

    Public SelectedCategory As Integer = 0
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            btnSave.Enabled = False
            saveData()
            btnSave.Enabled = True
        ElseIf btnSave.Text = "Update" Then
            btnSave.Enabled = False
            UpdateData()
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub saveData()

        Dim database As New DatabaseConnect
        database.dbConnect()
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "INSERT INTO categories([parent_id],[name],[status],[created_at],[updated_at])" & _
        "VALUES(@parent_id,@name,@status,@created_at,@updated_at)"

        database.cmd.Parameters.AddWithValue("@parent_id", 0)
        database.cmd.Parameters.AddWithValue("@name", txtCat.Text)
        database.cmd.Parameters.AddWithValue("@st", 1)
        database.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
        database.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
        database.cmd.Connection = database.con
        database.cmd.ExecuteNonQuery()
        database.con.Close()
        MsgBox("Category Save Successful", MsgBoxStyle.Information)
        txtCat.Text = ""
        CategoryList.loadList("")
        Me.Close()
    End Sub

    Private Sub UpdateData()
        Try
            Dim db As New DatabaseConnect
            db.dbConnect()
            db.cmd.CommandType = CommandType.Text
            db.cmd.CommandText = "UPDATE categories set [name] = '" & txtCat.Text & "', [updated_at] = '" & DateTime.Now.ToString & "' where ID = " & SelectedCategory
            db.cmd.Connection = db.con
            db.cmd.ExecuteNonQuery()
            db.cmd.Dispose()
            db.con.Close()

            MsgBox("Category Successfully Updated", MsgBoxStyle.Information)
            Me.Close()
            CategoryList.loadList("")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub CategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populateCategory()
    End Sub

    Public Sub populateCategory()
        cbParent.DataSource = Nothing
        cbParent.Items.Clear()
        Dim comboSource As New Dictionary(Of String, String)()
        comboSource.Add(0, "Select Category")
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name from CATEGORIES where status = 1 and parent_id = 0")
            If .dr.Read Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
                cbParent.DataSource = New BindingSource(comboSource, Nothing)
                cbParent.DisplayMember = "Value"
                cbParent.ValueMember = "Key"
            End If
        End With
    End Sub
End Class