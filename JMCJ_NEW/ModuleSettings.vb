Imports System.Data.OleDb
Module ModuleSettings
    Public con As New OleDbConnection
    Public cmd As New OleDbCommand
    Public dr As OleDbDataReader
    Public trans As OleDbTransaction

    Public Sub connect()
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\inventory_settings.accdb"
        'con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\users\inventory.mdb"
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
    End Sub

    Public Function forTest()
        connect()
        Dim result As Integer = 0
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select * from settings where id = 1"
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            If dr.Read Then
                result = CInt(dr("for_testing"))
            End If
        Else
            result = 0
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        Return result
    End Function

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

    Public Function get_db_path() As String
        Dim query As String = ""

        If ModuleSettings.forTest = 1 Then
            query = "select value from database_settings where code ='db_test'"
        Else
            query = "select value from database_settings where code ='db'"
        End If

        connect()
        Dim result As String = ""
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = query
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            If dr.Read Then
                result = dr("value")
            End If
        Else
            result = 0
        End If
        cmd.Dispose()
        dr.Close()
        con.Close()
        Return result
    End Function
End Module
