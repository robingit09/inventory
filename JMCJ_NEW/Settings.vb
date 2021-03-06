﻿Public Class Settings
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ModuleSettings.forTest = 1 Then
            'test mode
            testYes.Checked = True
        Else
            'ready mode
            testNo.Checked = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        btnSave.Enabled = False
        insertForTesting()
        If ModuleSettings.forTest = 1 Then
            'test mode
            Main_form.lblTest.Text = "For Testing"

        Else
            'ready mode
            Main_form.lblTest.Text = "Live"
        End If
        MsgBox("Settings sucessfully update.", MsgBoxStyle.Information)
        btnSave.Enabled = True
    End Sub

    Private Sub insertForTesting()

        Dim y As Integer = 0
        Dim db_path As String = ModuleSettings.get_db_path
        Dim temp() As String = db_path.Split("\")
        Dim database_name = temp(temp.Length - 1)
        Dim cur_path As String = db_path.Replace(database_name, "")

        If testYes.Checked = True Then
            ' for testing
            y = 1
            My.Computer.FileSystem.CopyFile(
                 db_path,
                   cur_path & "inventory_dev.accdb",
                  Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                  Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        Else
            ' live
            y = 0
            If System.IO.File.Exists(cur_path & "inventory.accdb") Then

                'My.Computer.FileSystem.DeleteFile(cur_path & "inventory_dev.accdb")
            End If

        End If
        doQuery("UPDATE settings set for_testing = " & y)

    End Sub

    Private Sub btnTruncate_Click(sender As Object, e As EventArgs) Handles btnTruncate.Click
        MsgBox("Warning! All your data will wipeout or reset.", MsgBoxStyle.Exclamation)
        Dim yesno As Integer = MsgBox("Are you sure you want to truncate database ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If yesno = MsgBoxResult.Yes Then
            ModelFunction.truncateDatabase()
            MsgBox("Database Successfully Truncate.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click

        Dim yesno As Integer = MsgBox("Are you sure you want to backup database ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If yesno = MsgBoxResult.Yes Then
            Dim path As String = ModuleSettings.get_db_path()
            If ModuleSettings.forTest = 1 Then
                My.Computer.FileSystem.CopyFile(
                   path,
                    "C:\users\inventory_db_backup\inventory_dev.accdb",
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                MsgBox("Database Successfully Backup.", MsgBoxStyle.Information)
            Else
                My.Computer.FileSystem.CopyFile(
                  path,
                  "C:\users\inventory_db_backup\inventory.accdb",
                  Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                  Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                MsgBox("Database Successfully Backup.", MsgBoxStyle.Information)
            End If

        End If

    End Sub

End Class