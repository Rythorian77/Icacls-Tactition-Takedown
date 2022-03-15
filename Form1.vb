Option Strict On
Option Explicit On
Imports System.IO
Imports System.Text
Imports Microsoft.Win32

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Tactician()



    End Sub

    Private Sub Tactician()
        Dim sb As New StringBuilder
        sb.AppendLine("SET FOLDER_NAME=C:\Windows\Temp")
        sb.AppendLine("TAKEOWN /f %FOLDER_NAME% /r /d y")
        sb.AppendLine("ICACLS %FOLDER_NAME% /grant administrators:F /t")
        sb.AppendLine("ICACLS %FOLDER_NAME% /reset /T")
        sb.AppendLine("icacls foo /grant Everyone:(OI)(CI)F")
        ' sb.AppendLine("IF NOT %ERRORLEVEL%==0 GOTO")
        sb.AppendLine("timeout /t 4 /nobreak")
        sb.AppendLine("echo .appactivate^(""%~1"" ^) : .sendkeys ""{enter}")
        sb.AppendLine("GoTo begin")
        File.WriteAllText("fileName.bat", sb.ToString())
        'Run Bat invisible
        Shell("fileName.bat", AppWinStyle.NormalFocus) 'Change to "hide" for it to be invisible
    End Sub






End Class
