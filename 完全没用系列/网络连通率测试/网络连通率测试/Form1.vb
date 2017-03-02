Public Class Form1
    Public now As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim count As Long
        count = 0
        now = 1
        'Label3.Text = ""
        For i = 1 To 10
            If (Len(CMD("ping 114.114.114.114 -n 1&&echo 1111111111111111111111111111111111111111111111111111111111111111111111&&ping -n 5 127.1>nul||echo 测试失败")) < 500) Then
                i = 1
                Label3.Text = "没网"
            Else
                Label3.Text = "测试"
            End If
            If (now = 2) Then
                i = 10
            End If
            Label5.Text = i
            count = count + 1
            Label2.Text = count
        Next
        If (now = 1) Then
            Label3.Text = "通畅"
        Else
            Label3.Text = "停止"
        End If
    End Sub
    Function CMD(ByVal Data As String) As String
        Try
            Dim p As New Process()
            p.StartInfo.FileName = "cmd.exe"
            p.StartInfo.UseShellExecute = False
            p.StartInfo.RedirectStandardInput = True
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardError = True
            p.StartInfo.CreateNoWindow = True
            p.Start()
            Application.DoEvents()
            p.StandardInput.WriteLine(Data)
            p.StandardInput.WriteLine("Exit")
            Dim strRst As String = p.StandardOutput.ReadToEnd()
            p.Close()
            Return strRst
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        now = 2
    End Sub
End Class
