Public Class CategoryForm


    Public SelectedID As Integer = 0
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

    Public Sub toUpdateInfo(ByVal id As Integer)
        Dim db As New DatabaseConnect
        With db
            .selectByQuery("Select id,name,parent_id from categories where status = 1 and id = " & id)

            If .dr.Read Then
                txtName.Text = .dr.GetValue(1)
                'cbParent.Text = getParent(CInt(.dr.GetValue(2)))
            End If
            .cmd.Dispose()
            .dr.Close()
            .con.Close()
        End With
    End Sub

    'Public Function getParent(ByVal parent_id As Integer) As String
    '    Dim result As String = ""
    '    Dim db As New DatabaseConnect
    '    With db
    '        .selectByQuery("Select name from categories where id = " & parent_id)
    '        If .dr.Read Then
    '            result = .dr.GetValue(0)
    '        End If
    '        .cmd.Dispose()
    '        .dr.Close()
    '        .con.Close()
    '    End With
    '    Return result
    'End Function

    Private Sub saveData()

        Dim database As New DatabaseConnect
        database.cmd.CommandType = CommandType.Text
        database.cmd.CommandText = "INSERT INTO categories([parent_id],[name],[status],[created_at],[updated_at])" &
        "VALUES(@parent_id,@name,@status,@created_at,@updated_at)"

        database.cmd.Parameters.AddWithValue("@parent_id", If((SelectedID > 0), SelectedID, 0))
        database.cmd.Parameters.AddWithValue("@name", txtName.Text)
        database.cmd.Parameters.AddWithValue("@st", 1)
        database.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.ToString)
        database.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.ToString)
        database.cmd.Connection = database.con
        database.cmd.ExecuteNonQuery()
        database.con.Close()
        MsgBox("Category Save Successful", MsgBoxStyle.Information)
        txtName.Text = ""
        CategoryList.loadList("")
        Me.Close()
    End Sub

    Private Sub UpdateData()
        Try
            Dim db As New DatabaseConnect
            db.cmd.CommandType = CommandType.Text
            db.cmd.CommandText = "UPDATE categories set [name] = '" & txtName.Text & "', [updated_at] = '" & DateTime.Now.ToString & "' where ID = " & SelectedID
            db.cmd.Connection = db.con
            db.cmd.ExecuteNonQuery()
            db.cmd.Dispose()
            db.con.Close()

            MsgBox("Successfully Update", MsgBoxStyle.Information)
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
            If .dr.HasRows Then
                While .dr.Read
                    Dim id As Integer = .dr.GetValue(0)
                    Dim name As String = .dr.GetValue(1)
                    comboSource.Add(id, name)
                End While
                cbParent.DataSource = New BindingSource(comboSource, Nothing)
                cbParent.DisplayMember = "Value"
                cbParent.ValueMember = "Key"
            End If
            .dr.Close()
            .cmd.Dispose()
            .con.Close()
        End With
    End Sub

    Private Sub cbParent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbParent.SelectedIndexChanged

        If cbParent.SelectedIndex > 0 Then
            Dim key As String = DirectCast(cbParent.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim value As String = DirectCast(cbParent.SelectedItem, KeyValuePair(Of String, String)).Value
            SelectedID = CInt(key)
        End If


    End Sub
End Class