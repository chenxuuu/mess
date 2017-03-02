Imports System.Runtime.InteropServices

Namespace uWindows

    Friend Class SafeNativeMethods

        '钩子处理过程
        Public Delegate Function HookProc(ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer

        Public Structure CWPSTRUCT
            Public lparam As IntPtr
            Public wparam As IntPtr
            Public message As Integer
            Public hwnd As IntPtr
        End Structure

        '点
        <StructLayout(LayoutKind.Sequential)> _
        Public Class POINT
            Public x As Integer
            Public y As Integer
        End Class

        '鼠标消息结构
        <StructLayout(LayoutKind.Sequential)> _
        Public Class MouseHookStruct
            Public pt As POINT
            Public hWnd As Integer
            Public wHitTestCode As Integer
            Public dwExtraInfo As Integer
        End Class

        <StructLayout(LayoutKind.Sequential)> _
        Public Class MouseLLHookStruct
            Public pt As POINT
            Public mouseData As Integer
            Public flags As Integer
            Public time As Integer
            Public dwExtraInfo As Integer
        End Class

        '键盘消息结构
        <StructLayout(LayoutKind.Sequential)> _
        Public Class KeyboardHookStruct
            Public vkCode As Integer        '1到254间的虚似键盘码
            Public scanCode As Integer      '扫描码
            Public flags As Integer
            Public time As Integer
            Public dwExtraInfo As Integer
        End Class

        '安装钩子
        <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function SetWindowsHookEx(ByVal idHook As Integer, ByVal lpfn As HookProc, ByVal hInstance As IntPtr, ByVal threadId As Integer) As Integer
        End Function

        '卸载钩子
        <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Auto)> _
        Public Shared Function UnhookWindowsHookEx(ByVal idHook As Integer) As Boolean
        End Function

        '处理下一个消息
        <DllImport("user32.dll", CallingConvention:=CallingConvention.StdCall, CharSet:=CharSet.Auto, SetLastError:=True)> _
        Public Shared Function CallNextHookEx(ByVal idHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As IntPtr) As Integer
        End Function

        <DllImport("user32")> _
        Public Shared Function ToAscii(ByVal uVirtKey As Integer, ByVal uScanCode As Integer, ByVal lpbKeyState As Byte(), ByVal lpwTransKey As Byte(), ByVal fuState As Integer) As Integer
        End Function

        <DllImport("user32")> _
        Public Shared Function GetKeyboardState(ByVal pbKeyState As Byte()) As Integer
        End Function

        Public Declare Function GetKeyState Lib "user32" Alias "GetKeyState" (ByVal nVirtKey As Integer) As Integer
        Public Declare Function GetModuleHandle Lib "kernel32.dll" Alias "GetModuleHandleA" (ByVal ModuleName As String) As IntPtr

        <DllImport("kernel32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
        Public Overloads Shared Function GetCurrentThreadId() As Integer
        End Function
    End Class

End Namespace

