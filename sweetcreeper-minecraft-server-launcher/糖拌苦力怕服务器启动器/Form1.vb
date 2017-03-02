Public Class Form1
    Dim time_run As Long
    Dim open_done As Boolean = False
    Private _process As Process = Nothing
    Dim psi As New ProcessStartInfo()
    Private Delegate Sub AddMessageHandler(ByVal msg As String)
    Dim msg_out As String

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox("糖拌苦力怕Minecraft服务器启动器" & vbCrLf & "晨旭制作" & vbCrLf & "http://chenxublog.com",, "关于软件")
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = "当前系统时间：" & Now
        time_run = 0
        Label6.Text = "软件已运行时间：" & Int(Int(Int(time_run / 60) / 60) / 24) & "天" & Int(Int(time_run / 60) / 60) Mod 24 & "小时" & Int(time_run / 60) Mod 60 & "分" & time_run Mod 60 & "秒"
        TextBox2.Text = "欢迎使用糖拌苦力怕服务器启动器！" & vbCrLf & "提交bug及建议请打开https://github.com/chenxuuu/sweetcreeper-minecraft-server-launcher提交Issues" & vbCrLf & vbCrLf & "服务器命令信息：" & vbCrLf
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (open_done) Then
            _process.StandardInput.WriteLine(TextBox7.Text)
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time_run += 1
        Label5.Text = "当前系统时间：" & Now
        Label6.Text = "软件已运行时间：" & Int(Int(Int(time_run / 60) / 60) / 24) & "天" & Int(Int(time_run / 60) / 60) Mod 24 & "小时" & Int(time_run / 60) Mod 60 & "分" & time_run Mod 60 & "秒"
        If (open_done) Then

            If (Date.Now.Second() = 0) Then                 '每分钟命令
                Dim s As String = TextBox5.Text
                Dim words As String() = s.Split(New Char() {";"c})
                Dim word As String
                For Each word In words
                    _process.StandardInput.WriteLine(word)
                Next
            End If

            If (Date.Now.Hour() = 0 And Date.Now.Minute() = 0 And Date.Now.Second() = 0) Then                 '每小时命令
                Dim s As String = TextBox6.Text
                Dim words As String() = s.Split(New Char() {";"c})
                Dim word As String
                For Each word In words
                    _process.StandardInput.WriteLine(word)
                Next
            End If


            If (RadioButton1.Checked = True) Then                                                           '计时重启

                If (Val(TextBox3.Text) * 60 * 60 - (time_run Mod Val(TextBox3.Text) * 60 * 60) = 60) Then
                    _process.StandardInput.WriteLine("say The server will restart in 60 seconds.")
                End If

                If (time_run Mod Val(TextBox3.Text) * 60 * 60 = 0) Then
                    _process.StandardInput.WriteLine("stop")
                End If

                If (time_run Mod Val(TextBox3.Text) * 60 * 60 = 30) Then
                    psi.FileName = "cmd.exe"
                    psi.Arguments = "/c @ECHO OFF &&" & TextBox1.Text
                    psi.UseShellExecute = False
                    psi.RedirectStandardOutput = True
                    psi.CreateNoWindow = True
                    psi.RedirectStandardInput = True
                    _process = New Process()
                    _process.StartInfo = psi
                    ' 定义接收消息的 Handler
                    AddHandler _process.OutputDataReceived, New DataReceivedEventHandler(AddressOf Process1_OutputDataReceived)
                    _process.Start()
                    ' 开始接收
                    _process.BeginOutputReadLine()
                End If

            End If

            If (RadioButton2.Checked = True) Then                                                           '定时重启

                If (Date.Now.Hour() = Val(TextBox4.Text) - 1 And Date.Now.Minute() = 59 And Date.Now.Second() = 59) Then
                    _process.StandardInput.WriteLine("say The server will restart in 60 seconds.")
                End If

                If (Date.Now.Hour() = Val(TextBox4.Text) And Date.Now.Minute() = 0 And Date.Now.Second() = 0) Then
                    _process.StandardInput.WriteLine("stop")
                End If

                If (Date.Now.Hour() = Val(TextBox4.Text) And Date.Now.Minute() = 0 And Date.Now.Second() = 30) Then
                    psi.FileName = "cmd.exe"
                    psi.Arguments = "/c @ECHO OFF &&" & TextBox1.Text
                    psi.UseShellExecute = False
                    psi.RedirectStandardOutput = True
                    psi.CreateNoWindow = True
                    psi.RedirectStandardInput = True
                    _process = New Process()
                    _process.StartInfo = psi
                    ' 定义接收消息的 Handler
                    AddHandler _process.OutputDataReceived, New DataReceivedEventHandler(AddressOf Process1_OutputDataReceived)
                    _process.Start()
                    ' 开始接收
                    _process.BeginOutputReadLine()
                End If

            End If


        End If
    End Sub


    Private Sub Process1_OutputDataReceived(ByVal sender As Object, ByVal e As System.Diagnostics.DataReceivedEventArgs) Handles Process1.OutputDataReceived
        Dim handler As AddMessageHandler = Function(msg As String)
                                               TextBox2.Text += msg + Environment.NewLine
                                               TextBox2.[Select](TextBox2.Text.Length - 1, 0)
                                               TextBox2.ScrollToCaret()
                                           End Function
        If TextBox2.InvokeRequired Then
            TextBox2.Invoke(handler, e.Data)
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        open_done = True
        '启动 cmd.exe
        psi.FileName = "cmd.exe"
        psi.Arguments = "/c @ECHO OFF &&" & TextBox1.Text
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True
        psi.RedirectStandardInput = True
        _process = New Process()
        _process.StartInfo = psi
        ' 定义接收消息的 Handler
        AddHandler _process.OutputDataReceived, New DataReceivedEventHandler(AddressOf Process1_OutputDataReceived)
        _process.Start()
        ' 开始接收
        _process.BeginOutputReadLine()
    End Sub


    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (open_done) Then
            _process.StandardInput.WriteLine("stop")
            MsgBox("程序关闭，服务器将自动停止运行",, "关闭提示")
            _process.Close()
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (open_done) Then
            _process.StandardInput.WriteLine("stop")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox2.Text = ""
    End Sub
End Class
