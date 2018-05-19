Imports System.Data.OleDb

Public Class DatabaseConnect
    Public con As New OleDbConnection
    Public cmd As New OleDbCommand
    Public dr As OleDbDataReader
    Public Sub dbConnect()

        'con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Documents\db_jmcj.accdb"
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\db_jmcj.mdb"
        'MsgBox(con.ConnectionString)

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If


    End Sub
End Class
