Imports System.Reflection
Imports System.Runtime.InteropServices
Imports uWindows.ConstDefine
Imports uWindows.SafeNativeMethods

Namespace uWindows
    Public Class MouseHook

        Public Event OnMouseActivity As MouseEventHandler

        Private hMouseHook As Integer = 0
        Private MouseHookProcedure As HookProc

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
            MouseHookProcedure = New uWindows.SafeNativeMethods.HookProc(AddressOf Me.MouseHookProc)
            If ThreadHook Then '线程钩子
                hMouseHook = SetWindowsHookEx(uWindows.ConstDefine.HookType.WH_MOUSE, _
                                                         MouseHookProcedure, _
                                                         GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), _
                                                         GetCurrentThreadId)
            Else '系统钩子
                hMouseHook = SetWindowsHookEx(uWindows.ConstDefine.HookType.WH_MOUSE_LL, _
                                                         MouseHookProcedure, _
                                                         GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), _
                                                         0)
            End If

            If (hMouseHook = 0) Then
                [Stop]()
                Throw New Exception("SetWindowsHookEx is failed in MouseHook.")
            End If
        End Sub

        Public Sub [Stop]()
            Dim retMouse As Boolean = True

            If hMouseHook <> 0 Then
                retMouse = UnhookWindowsHookEx(hMouseHook)
                hMouseHook = 0
            End If

            If Not retMouse Then Throw New Exception("UnhookWindowsHookEx failed in MouseHook.")
        End Sub

        Private Function MouseHookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
            If nCode >= 0 Then
                Dim button As MouseButtons = MouseButtons.None
                Select Case wParam
                    Case WM_LBUTTONDOWN
                        button = MouseButtons.Left
                    Case WM_RBUTTONDOWN
                        button = MouseButtons.Right
                    Case WM_MOUSEWHEEL

                End Select

                Dim clickCount As Integer = 0
                If Not button = MouseButtons.None Then
                    If wParam = WM_LBUTTONDBLCLK OrElse wParam = WM_RBUTTONDBLCLK Then
                        clickCount = 2
                    Else
                        clickCount = 1
                    End If
                End If

                Dim MyMouseHookStruct As MouseLLHookStruct
                MyMouseHookStruct = CType(Marshal.PtrToStructure(lParam, GetType(MouseLLHookStruct)), MouseLLHookStruct)
                Dim e As MouseEventArgs = New MouseEventArgs(button, _
                                                             clickCount, _
                                                             MyMouseHookStruct.pt.x, _
                                                             MyMouseHookStruct.pt.y, _
                                                             MyMouseHookStruct.mouseData)
                RaiseEvent OnMouseActivity(Me, e)
            End If

            'Return CallNextHookEx(hMouseHook, nCode, wParam, lParam)
            Return -1
        End Function

    End Class
End Namespace

