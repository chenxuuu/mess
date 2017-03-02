Public Class frmHook

    Dim WithEvents MyKeyBoardHook As uWindows.KeyboardHook
    Dim WithEvents MyMouseHook As uWindows.MouseHook


    Private Sub frmHook_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call btnStop_Click(Nothing, Nothing)
    End Sub

    Private Sub btnStop_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Try
            If MyKeyBoardHook IsNot Nothing Then MyKeyBoardHook.Stop()
            If MyMouseHook IsNot Nothing Then MyMouseHook.Stop()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Call btnStart_Click(Nothing, Nothing)
        Dim s As Date = Now
        Do
            btnTest.Text = String.Format("«Î…‘∫Ú°≠£¨ª÷∏¥ Û±Íº¸≈Ãªπ £{0}√Î", DateDiff(DateInterval.Second, Now, DateAdd(DateInterval.Minute, 1, s)).ToString)
            Application.DoEvents()
        Loop While Now <= DateAdd(DateInterval.Minute, 1, s)
        Call btnStop_Click(Nothing, Nothing)
        btnTest.Text = "Ω˚”√ Û±Íº¸≈Ã“ª∑÷÷”"
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Try
            MyKeyBoardHook = New uWindows.KeyboardHook(False)
            'MyMouseHook = New uWindows.MouseHook(False)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub LogWrite(ByVal txt As String)
        txtLog.AppendText(txt + Environment.NewLine)
        txtLog.SelectionStart = txtLog.Text.Length
    End Sub

    Private Sub MyKeyboardHook_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyKeyBoardHook.KeyDown
        LogWrite("KeyDown 	- " + e.KeyData.ToString())
        My.Computer.Audio.Play(Application.StartupPath & "\1.wav", AudioPlayMode.Background)
    End Sub

    Private Sub MyKeyboardHook_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyKeyBoardHook.KeyPress
        LogWrite("KeyPress 	- " + e.KeyChar)
    End Sub

    Private Sub MyKeyboardHook_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyKeyBoardHook.KeyUp
        LogWrite("KeyUp 		- " + e.KeyData.ToString())
    End Sub

    Private Sub MyMouseHook_OnMouseActivity(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyMouseHook.OnMouseActivity
        lblMousePosition.Text = String.Format("x={0}  y={1} wheel={2}", e.X, e.Y, e.Delta)
        If (e.Clicks > 0) Then LogWrite("MouseButton 	- " + e.Button.ToString())
    End Sub

End Class





