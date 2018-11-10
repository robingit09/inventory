Imports System.Data.OleDb
Public Class btnTest

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        save()
    End Sub

    Private Sub save()

        If ModuleSettings.forTest = 1 Then
            MsgBox("You are in a Test Mode", MsgBoxStyle.Exclamation)
        Else

        End If

        If Trim(txtPath.Text) = "" Then
            MsgBox("Please select the destination path")
            btnSelect.Focus()
            Exit Sub
        End If

        If OpenFileDialog1.FileName <> "" Then
            Dim temp() As String
            temp = txtPath.Text.Split("\")
            Dim file As String = temp(temp.Length - 1)

            If ModuleSettings.forTest = 1 Then
                If Not file.Contains("inventory_dev") Then

                    MsgBox("Please select inventory_dev.accdb as your database for testing.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            Else
                If Not file.Contains("inventory") Then

                    MsgBox("Please select inventory.accdb as your database for live.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If
        End If

        If (checkConnection() = False) Then
            MsgBox("Connection Failed! Please change the path or ask the administrator.", MsgBoxStyle.Critical)
            btnSelect.Focus()
            Exit Sub
        End If


        Dim query As String = ""
        If ModuleSettings.forTest = 1 Then
            query = "update database_settings set [value] ='" & Trim(txtPath.Text) & "' where [code] = 'db_test'"
        Else
            query = "update database_settings set [value] ='" & Trim(txtPath.Text) & "' where [code] = 'db'"
        End If

        doQuery(query)
        MsgBox("Successfully Save.", MsgBoxStyle.Information)
        Login.getConnectionStatus()

    End Sub

    Public Sub doQuery(ByVal query As String)
        connect()
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        dr.Close()
        con.Close()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            txtPath.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub loadPath()
        txtPath.Text = get_db_path()
    End Sub

    Private Sub btnTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPath()
    End Sub

    Private Sub btnTes_Click(sender As Object, e As EventArgs) Handles btnTes.Click
        'test connection


        'If ModuleSettings.forTest = 0 Then
        '    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source" & Trim(txtPath.Text)

        'End If

        'If ModuleSettings.forTest = 1 Then

        '    con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Trim(txtPath.Text)
        'End If

        'If con.State = ConnectionState.Closed Then
        '    con.Open()
        '    MsgBox("Connection Established.", MsgBoxStyle.Information)
        'Else
        '    MsgBox("Connection Failed.", MsgBoxStyle.Critical)
        'End If
        testConnection()

    End Sub
    Private Sub testConnection()
        Dim con As New OleDbConnection
        Dim cmd As New OleDbCommand
        Dim dr As OleDbDataReader

        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Trim(txtPath.Text)

        Try
            con.Open()
            MsgBox("Connection Established.", MsgBoxStyle.Information)
            con.Close()
        Catch ex As Exception
            MsgBox("Connection Failed.", MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Function checkConnection() As Boolean
        Dim res As Boolean = False
        Dim con As New OleDbConnection
        Dim cmd As New OleDbCommand

        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Trim(txtPath.Text)

        Try
            con.Open()
            res = True
            con.Close()
        Catch ex As Exception
            res = False
        End Try

        Return res
    End Function
End Class