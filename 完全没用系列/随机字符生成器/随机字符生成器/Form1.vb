Public Class Form1


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim MyValue, Myvalueh, s, count
        TextBox1.Text = ""
        For count = 0 To NumericUpDown1.Value - 1


            MyValue = Hex(Int((94 * Rnd()) + 161)) '随机产生161到264之间的整数
            Myvalueh = Hex(Int((94 * Rnd()) + 161)) '随机产生161到264之间的整数
            s = Myvalueh & MyValue '拼接十六进制字符串高低字节
            TextBox1.Text = TextBox1.Text & Chr(Val("&H" & s)) '用Chr函数返回汉字
            Randomize()
        Next
    End Sub
End Class
