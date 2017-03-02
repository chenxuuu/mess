Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Val(TextBox1.Text) <= 10000) Then
            MsgBox("请输入正确的QQ帐号！")
        Else
            MsgBox("点击确认开始刷钻，爆破可能会进行很长时间，爆破速度取决于网速以及电脑性能")
            Threading.Thread.Sleep(8000)
            Form2.Label2.Text = TextBox1.Text
            Form2.Show()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form3.Show()
        Threading.Thread.Sleep(4000)
        Form3.Label1.Text = "已是最新版本"
    End Sub
End Class
