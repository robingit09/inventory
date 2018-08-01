Public Class UnitForm
    Public selectedUnit As Integer = 0
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If btnSave.Text = "Save" Then
            saveData()

            'after add unit function
            For Each form In My.Application.OpenForms
                If (form.name = ProductAddUnitForm.Name) Then
                    'form is loaded so can do work 
                    'if you need to check whether it is actually visible
                    If form.Visible Then
                        'do work when visible
                        ProductAddUnitForm.loadUnit()
                        ProductAddUnitForm.cbUnit.SelectedIndex = ProductAddUnitForm.cbUnit.FindString(Me.txtUnit.Text)
                    End If
                End If
            Next
            txtUnit.Text = ""
        ElseIf btnSave.Text = "Update" Then
            updateData()
        End If
    End Sub

    Private Function validation() As Boolean
        Dim res As Boolean = True
        If Trim(txtUnit.Text) = "" Then
            res = False
            MsgBox("Unit name field is required!", MsgBoxStyle.Critical)
            txtUnit.Focus()
        End If

        If New DatabaseConnect().isExist("unit", "name", txtUnit.Text.ToUpper) Then
            res = False
            MsgBox("Unit name is already exist!", MsgBoxStyle.Critical)
            txtUnit.Focus()
            txtUnit.SelectAll()
        End If
        Return res
    End Function

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

        database.cmd.Parameters.AddWithValue("@name", toCapitalFirst(txtUnit.Text))
        database.cmd.Parameters.AddWithValue("@st", 1)
        database.cmd.Parameters.AddWithValue("@created_at", DateTime.Now.Date.ToString)
        database.cmd.Parameters.AddWithValue("@updated_at", DateTime.Now.Date.ToString)
        database.cmd.ExecuteNonQuery()
        database.con.Close()
        MsgBox("Unit Save Successfully", MsgBoxStyle.Information)
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

    Private Sub txtUnit_MouseLeave(sender As Object, e As EventArgs) Handles txtUnit.MouseLeave
        If Trim(txtUnit.Text).Length > 0 Then
            txtUnit.Text = toCapitalFirst(txtUnit.Text)
        End If
    End Sub

    Private Function toCapitalFirst(ByVal str As String) As String
        Dim result As String
        result = str.Substring(0, 1).ToUpper() + str.Substring(1)
        Return result
    End Function
End Class