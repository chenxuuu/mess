Public Class Form1
    Private Sub TxtFile1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragDrop
        Dim str() As String = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If str.Length > 1 Then
            Exit Sub
        Else
            TextBox1.Text = str(0)
        End If
    End Sub
    Private Sub TxtFile1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TextBox1.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("Mplayer字符画播放器GUI工具" & vbNewLine & "by 晨旭" & vbNewLine & "chenxublog.com")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Shell(Application.StartupPath & "\MPlayer\mplayer.exe  -vo caca " & TextBox1.Text)
    End Sub
End Class
