Public Class Form1
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (Label7.Text <> "全部完成") Then
            MsgBox("请先生成！")
        Else
            MsgBox("别偷懒了，快去认真地做吧")
            MsgBox("2333333333333333333")
            MsgBox("by晨旭 chenxublog.com")
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Show()
        System.Threading.Thread.Sleep(4000)
        Form2.Label2.Text = "已是最新版本"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label7.Text = "正在下载素材，请稍候"
        MsgBox("点击确认下载素材")
        System.Threading.Thread.Sleep(10000)
        Label7.Text = ""
        MsgBox("加载成功！")
        Button1.Font = Form3.Button1.Font
        Button1.ForeColor = Form3.Button1.ForeColor
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Label7.Text = "正在下载素材，请稍候"
        MsgBox("点击确认下载素材")
        System.Threading.Thread.Sleep(10000)
        Label7.Text = ""
        MsgBox("加载成功！")
        Button2.Font = Form3.Button1.Font
        Button2.ForeColor = Form3.Button1.ForeColor
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label7.Text = "正在下载素材，请稍候"
        MsgBox("点击确认下载素材")
        System.Threading.Thread.Sleep(10000)
        Label7.Text = ""
        MsgBox("加载成功！")
        Button3.Font = Form3.Button1.Font
        Button3.ForeColor = Form3.Button1.ForeColor
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Label7.Text = "正在下载素材，请稍候"
        MsgBox("点击确认下载素材")
        System.Threading.Thread.Sleep(10000)
        Label7.Text = ""
        MsgBox("加载成功！")
        Button4.Font = Form3.Button1.Font
        Button4.ForeColor = Form3.Button1.ForeColor
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label7.Text = "正在下载素材，请稍候"
        MsgBox("点击确认下载素材")
        System.Threading.Thread.Sleep(10000)
        Label7.Text = ""
        MsgBox("加载成功！")
        Button5.Font = Form3.Button1.Font
        Button5.ForeColor = Form3.Button1.ForeColor
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Label7.Text = "正在下载素材，请稍候"
        MsgBox("点击确认下载素材")
        System.Threading.Thread.Sleep(10000)
        Label7.Text = ""
        MsgBox("加载成功！")
        Button6.Font = Form3.Button1.Font
        Button6.ForeColor = Form3.Button1.ForeColor
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Label7.Text = "正在下载素材，请稍候"
        MsgBox("点击确认下载素材")
        System.Threading.Thread.Sleep(10000)
        Label7.Text = ""
        MsgBox("加载成功！")
        Button7.Font = Form3.Button1.Font
        Button7.ForeColor = Form3.Button1.ForeColor
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MsgBox("暂无其他选项")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If (TextBox2.Text = "请填写") Then
            MsgBox("请选完所有设置！")
        Else
            Label7.Text = "正在生成"
            MsgBox("点击确认开始生成")
            System.Threading.Thread.Sleep(10000)
            MsgBox("生成成功！请发布！")
            Label7.Text = "全部完成"
        End If
    End Sub
End Class
