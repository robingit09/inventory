Imports System.Data.OleDb

Public Class DatabaseConnect
    Public con As New OleDbConnection
    Public cmd As New OleDbCommand
    Public dr As OleDbDataReader
    Public trans As OleDbTransaction

    Public Sub New()
        Try
            dbConnect()
        Catch ex As Exception
            If con.State = ConnectionState.Open Then
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If
        End Try
    End Sub

    Public Sub dbConnect()

        If ModuleSettings.getDBSetup = 0 Then
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\inventory.mdb"

        End If

        If ModuleSettings.getDBSetup = 1 Then
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\inventory_dev.mdb"
        End If


        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
    End Sub

    Public Sub selectTableByColumn(ByVal table As String, ByVal col As String, ByVal oper As String, ByVal val As String)
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT * FROM " & table & " Where " & col & " " & oper & " " & val
            dr = cmd.ExecuteReader
        Catch ex As Exception
            If con.State = ConnectionState.Open Then
                MsgBox("The database is already open, selectTableByColumn", MsgBoxStyle.Critical)
            Else
                MsgBox(ex.Message & " " & cmd.CommandText, MsgBoxStyle.Critical)
            End If
        End Try
    End Sub

    Public Sub selectByQuery(ByVal q As String)
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = q
        dr = cmd.ExecuteReader
    End Sub

    Public Function get_id(ByVal table As String, ByVal col As String, ByVal val As String) As Integer
        Dim res As Integer = 0
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select id from " & table & " WHERE UCASE(" & col & ") = UCASE('" & val & "')"
        dr = cmd.ExecuteReader
        If dr.Read Then
            res = dr.GetValue(0)
        End If
        dr.Close()
        cmd.Dispose()
        con.Close()
        Return res
    End Function

    Public Sub update_where(ByVal table As String, ByVal ID As String, ByVal col As String, ByVal val As String)
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "UPDATE " & table & " SET [" & col & "] = " & val & " WHERE ID = " & ID
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        cmd.Dispose()
        con.Close()
    End Sub

    Public Sub update_where(ByVal table As String, ByVal colname As String, ByVal ID As String, ByVal col As String, ByVal val As String)
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "UPDATE " & table & " SET [" & col & "] = " & val & " WHERE " & colname & " = " & ID
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub delete_permanent(ByVal table As String, ByVal column As String, ByVal id As Integer)
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM " & table & " WHERE " & column & " = " & id
        cmd.ExecuteNonQuery()
    End Sub

    Function isExist(ByVal table As String, ByVal column As String, ByVal val As String) As Boolean
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT " & column & " FROM " & table & " WHERE " & column & " = '" & val & "'"
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                cmd.Dispose()
                dr.Close()
                con.Close()
                Return True
            Else
                cmd.Dispose()
                dr.Close()
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Function isExist(ByVal table As String, ByVal column As String, ByVal val As String, ByVal id As Integer) As Boolean
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT " & column & " FROM " & table & " WHERE " & column & " = '" & val & "' and id <> " & id
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                cmd.Dispose()
                dr.Close()
                con.Close()
                Return True
            Else
                cmd.Dispose()
                dr.Close()
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Return False
    End Function

    Function get_by_id(ByVal table As String, ByVal id As Integer, ByVal col As String)
        Dim res As String = "0"
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select " & col & " from " & table & " where id = " & id
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                If dr.Read Then
                    res = dr.GetValue(0)
                End If

            End If
            cmd.Dispose()
            con.Close()
        Catch ex As Exception

        End Try
        Return res
    End Function

    Function get_by_val(ByVal table As String, ByVal id As Integer, ByVal wherecol As String, ByVal return_val As String)
        Dim res As String = ""
        Try
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Select " & return_val & " from " & table & " where " & wherecol & " = " & id
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                If dr.Read Then
                    res = dr.GetValue(0)
                End If

            End If
            cmd.Dispose()
            con.Close()
        Catch ex As Exception

        End Try
        Return res
    End Function

    Public Function getLastID(ByVal table As String) As Integer
        Dim id As Integer = 0
        cmd.Connection = con
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT MAX(ID) from " & table
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            id = If(IsDBNull(dr.GetValue(0)), 1, dr.GetValue(0))
        Else
            id = 1
        End If
        cmd.Dispose()
        con.Close()
        Return id
    End Function
End Class
