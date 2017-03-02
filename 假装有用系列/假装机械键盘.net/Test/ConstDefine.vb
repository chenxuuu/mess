Namespace uWindows

    Public Module ConstDefine

        Public Enum HookType
            WH_CALLWNDPROC = 4
            WH_CALLWNDPROCRET = 12
            WH_CBT = 5
            WH_DEBUG = 9
            WH_FOREGROUNDIDLE = 11
            WH_GETMESSAGE = 3
            WH_HARDWARE = 8
            WH_JOURNALPLAYBACK = 1
            WH_JOURNALRECORD = 0
            WH_KEYBOARD = 2
            WH_MOUSE = 7
            WH_MSGFILTER = (-1)
            WH_SHELL = 10
            WH_SYSMSGFILTER = 6
            WH_KEYBOARD_LL = 13
            WH_MOUSE_LL = 14
        End Enum

        Public Const WM_MOUSEMOVE As Integer = &H200
        Public Const WM_LBUTTONDOWN As Integer = &H201
        Public Const WM_LBUTTONUP As Integer = &H202
        Public Const WM_LBUTTONDBLCLK As Integer = &H203

        Public Const WM_RBUTTONDOWN As Integer = &H204
        Public Const WM_RBUTTONUP As Integer = &H205
        Public Const WM_RBUTTONDBLCLK As Integer = &H206

        Public Const WM_MBUTTONDOWN As Integer = &H207
        Public Const WM_MBUTTONUP As Integer = &H208
        Public Const WM_MBUTTONDBLCLK As Integer = &H209
        Public Const WM_MOUSEWHEEL As Integer = &H20A

        Public Const WM_KEYDOWN As Integer = &H100
        Public Const WM_KEYUP As Integer = &H101
        Public Const WM_SYSKEYDOWN As Integer = &H104
        Public Const WM_SYSKEYUP As Integer = &H105

        Public Const WM_NCMOUSEMOVE = &HA0
        Public Const WM_NCLBUTTONDOWN = &HA1
        Public Const WM_NCLBUTTONUP = &HA2
        Public Const WM_NCLBUTTONDBLCLK = &HA3
        Public Const WM_NCRBUTTONDOWN = &HA4
        Public Const WM_NCRBUTTONUP = &HA5
        Public Const WM_NCRBUTTONDBLCLK = &HA6
        Public Const WM_NCMBUTTONDOWN = &HA7
        Public Const WM_NCMBUTTONUP = &HA8
        Public Const WM_NCMBUTTONDBLCLK = &HA9
        Public Const WM_NCXBUTTONDOWN = &HAB
        Public Const WM_NCXBUTTONUP = &HAC
        Public Const WM_NCXBUTTONDBLCLK = &HAD

        Public Const VK_XBUTTON1 = &H5
        Public Const VK_XBUTTON2 = &H6

        Public Const HC_ACTION = 0
        Public Const HC_NOREMOVE = 3

    End Module

End Namespace

