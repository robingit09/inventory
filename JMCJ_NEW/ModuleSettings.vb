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

    Public Function getDBSetup()
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
End Module
