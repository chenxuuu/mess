Imports System.Reflection
Imports System.Runtime.InteropServices
Imports uWindows.ConstDefine
Imports uWindows.SafeNativeMethods

Namespace uWindows

    <ComVisibleAttribute(False), Security.SuppressUnmanagedCodeSecurityAttribute()> _
    Public Class KeyboardHook

        Public Event KeyDown As KeyEventHandler
        Public Event KeyPress As KeyPressEventHandler
        Public Event KeyUp As KeyEventHandler

        Private hKeyboardHook As Integer = 0
        Private KeyboardHookProcedure As SafeNativeMethods.HookProc

        Private ThreadHook As Boolean = True


        Public Sub New()
            Call Start()
        End Sub

        Public Sub New(ByVal mThreadHook As Boolean)
            ThreadHook = mThreadHook
            Call Start()
        End Sub

        Protected Overrides Sub Finalize()
            Try
                [Stop]()
            Finally
                MyBase.Finalize()
            End Try
        End Sub

        Private Sub Start()
            If (hKeyboardHook = 0) Then
                KeyboardHookProcedure = New HookProc(AddressOf KeyboardHookProc)
                If ThreadHook Then  '线程钩子
                    hKeyboardHook = SetWindowsHookEx(uWindows.ConstDefine.HookType.WH_KEYBOARD, _
                                                    KeyboardHookProcedure, _
                                                    GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), _
                                                    GetCurrentThreadId)
                Else '系统钩子()
                    hKeyboardHook = SetWindowsHookEx(uWindows.ConstDefine.HookType.WH_KEYBOARD_LL, _
                                                     KeyboardHookProcedure, _
                                                     GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), _
                                                     0)
                End If

                If (hKeyboardHook = 0) Then
                    [Stop]()
                    Throw New Exception("SetWindowsHookEx is failed in KeyboardHook.")
                End If
            End If
        End Sub

        Public Sub [Stop]()
            Dim retKeyboard As Boolean = True
            If hKeyboardHook <> 0 Then
                retKeyboard = UnhookWindowsHookEx(hKeyboardHook)
                hKeyboardHook = 0
            End If

            If Not retKeyboard Then Throw New Exception("UnhookWindowsHookEx failed.")
        End Sub

        Private Function KeyboardHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
            If nCode >= 0 Then
                If ThreadHook Then
                    '我们从右向左数，假设最右边那位为第0位，最左边的就是第31位，那么该参数的的0-15位表示键的发送次数等扩展信息，
                    '16-23位为按键的扫描码，24-31位表示是按下键还是释放键。
                    If lParam.ToInt32 > 0 Then
                        RaiseEvent KeyDown(Me, New KeyEventArgs(CType(wParam, Keys)))
                    Else
                        RaiseEvent KeyUp(Me, New KeyEventArgs(CType(wParam, Keys)))
                    End If
                Else
                    Dim MyKeyboardHookStruct As KeyboardHookStruct
                    MyKeyboardHookStruct = CType(Marshal.PtrToStructure(lParam, GetType(KeyboardHookStruct)), KeyboardHookStruct)

                    If wParam = WM_KEYDOWN OrElse wParam = WM_SYSKEYDOWN Then
                        Dim keyData As Keys = CType(MyKeyboardHookStruct.vkCode, Keys)
                        Dim e As New KeyEventArgs(keyData)
                        RaiseEvent KeyDown(Me, e)
                    End If

                    If wParam = WM_KEYDOWN Then
                        Dim keyState As Byte() = New Byte(256 - 1) {}
                        Call GetKeyboardState(keyState)
                        Dim inBuffer As Byte() = New Byte(2 - 1) {}
                        If ToAscii(MyKeyboardHookStruct.vkCode, _
                                   MyKeyboardHookStruct.scanCode, _
                                   keyState, _
                                   inBuffer, _
                                   MyKeyboardHookStruct.flags) = 1 Then
                            Dim e As KeyPressEventArgs = New KeyPressEventArgs(System.Convert.ToChar(inBuffer(0)))
                            RaiseEvent KeyPress(Me, e)
                        End If
                    End If

                    If wParam = WM_KEYUP OrElse wParam = WM_SYSKEYUP Then
                        Dim keyData As Keys = CType(MyKeyboardHookStruct.vkCode, Keys)
                        Dim e As KeyEventArgs = New KeyEventArgs(keyData)
                        RaiseEvent KeyUp(Me, e)
                    End If
                End If
            End If

            'Return CallNextHookEx(hKeyboardHook, nCode, wParam, lParam)
            Return -1
        End Function

    End Class

End Namespace
