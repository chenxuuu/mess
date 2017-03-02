Attribute VB_Name = "mdlHook"
Option Explicit



Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Long, ByVal hwndCallback As Long) As Long
'---------------------------------
'ģ��
Public Type KEYMSGS
       vKey As Long          '������  (and &HFF)
       sKey As Long          'ɨ����
       flag As Long          '�����£�128 ̧��0
       time As Long          'Window����ʱ��
End Type
Public Type MOUSEMSGS
       X As Long            'x����
       Y As Long            'y����
       a As Long
       b As Long
       time As Long         'Window����ʱ��
End Type
Public Type POINTAPI
    X As Long
    Y As Long
End Type
Public Const WH_KEYBOARD_LL = 13
Public Const WH_MOUSE_LL = 14
Public Const Alt_Down = &H20
'-----------------------------------------
'��Ϣ
Public Const HC_ACTION = 0
Public Const HC_SYSMODALOFF = 5
Public Const HC_SYSMODALON = 4
'������Ϣ
Public Const WM_KEYDOWN = &H100
Public Const WM_KEYUP = &H101
Public Const WM_SYSKEYDOWN = &H104
Public Const WM_SYSKEYUP = &H105
'�����Ϣ
Public Const WM_MOUSEMOVE = &H200
Public Const WM_LBUTTONDOWN = &H201
Public Const WM_LBUTTONUP = &H202
Public Const WM_LBUTTONDBLCLK = &H203
Public Const WM_RBUTTONDOWN = &H204
Public Const WM_RBUTTONUP = &H205
Public Const WM_RBUTTONDBLCLK = &H206
Public Const WM_MBUTTONDOWN = &H207
Public Const WM_MBUTTONUP = &H208
Public Const WM_MBUTTONDBLCLK = &H209
Public Const WM_MOUSEACTIVATE = &H21
Public Const WM_MOUSEFIRST = &H200
Public Const WM_MOUSELAST = &H209
Public Const WM_MOUSEWHEEL = &H20A
Public strKeyName As String * 255
Public keyMsg As KEYMSGS
Public MouseMsg As MOUSEMSGS
Public lHook(1) As Long
'----------------------------------------
'ģ�����
Private Const MOUSEEVENTF_LEFTDOWN = &H2
Private Const MOUSEEVENTF_LEFTUP = &H4
Private Const MOUSEEVENTF_ABSOLUTE = &H8000 '  absolute move
Public Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" _
                                                            (ByVal idHook As Long, _
                                                            ByVal lpfn As Long, _
                                                            ByVal hmod As Long, _
                                                            ByVal dwThreadId As Long) As Long
Public Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Long) As Long
Public Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Long) As Integer
Public Declare Function CallNextHookEx Lib "user32" (ByVal hHook As Long, _
                                                            ByVal ncode As Long, _
                                                            ByVal wParam As Long, _
                                                            lParam As Any) As Long
Public Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" _
                                                            (lpvDest As Any, _
                                                            ByVal lpvSource As Long, _
                                                            ByVal cbCopy As Long)
Public Declare Function GetKeyNameText Lib "user32" Alias "GetKeyNameTextA" _
                                                            (ByVal lParam As Long, _
                                                            ByVal lpBuffer As String, _
                                                            ByVal nSize As Long) As Long
Public Declare Function GetActiveWindow Lib "user32" () As Long
Public Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Long, _
                                                            ByVal dx As Long, _
                                                            ByVal dy As Long, _
                                                            ByVal cButtons As Long, _
                                                            ByVal dwExtraInfo As Long)
Public Declare Function ClientToScreen Lib "user32" (ByVal hwnd As Long, lpPoint As POINTAPI) As Long
'ģ�ⰴ��
Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, _
                                                            ByVal bScan As Byte, _
                                                            ByVal dwFlags As Long, _
                                                            ByVal dwExtraInfo As Long)
Public Declare Function GetFocus Lib "user32" () As Long
Public Declare Function GetObjectType Lib "gdi32" (ByVal hgdiobj As Long) As Long
Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
Public Declare Sub GetActiveObject Lib "oleaut32.dll" _
                                                            (ByVal rclsid As Long, _
                                                            pvReserved As Any, _
                                                            ByVal ppunk As Long)
Public Declare Function GetCursorPos Lib "user32" (lpPoint As POINTAPI) As Long
Public Declare Function WindowFromPoint Lib "user32" (ByVal xPoint As Long, ByVal yPoint As Long) As Long

Public Sub AddHook()
  '���̹���
  lHook(0) = SetWindowsHookEx(WH_KEYBOARD_LL, AddressOf CallKeyHookProc, App.hInstance, 0)
  '��깳��
'  lHook(1) = SetWindowsHookEx(WH_MOUSE_LL, AddressOf CallMouseHookProc, App.hInstance, 0)
    lHook(1) = SetWindowsHookEx(WH_MOUSE_LL, AddressOf CallHandle, App.hInstance, 0)
End Sub
'ж����
Public Sub DelHook()
  UnhookWindowsHookEx lHook(0)
  UnhookWindowsHookEx lHook(1)
End Sub
'--------------------------------------

'��깳��
Public Function CallMouseHookProc(ByVal code As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Dim pt As POINTAPI
    If code = HC_ACTION Then
        CopyMemory MouseMsg, lParam, LenB(MouseMsg)
        frmMain.txtMsg(1).Text = "X=" + Str(MouseMsg.X) + " Y=" + Str(MouseMsg.Y)
        frmMain.txtHwnd(1) = Format(wParam, "0")
        If wParam = WM_MBUTTONDOWN Then                      '���м���Ϊ���
            mouse_event MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0
            CallMouseHookProc = 1
        End If
        If wParam = WM_MBUTTONUP Then
            mouse_event MOUSEEVENTF_LEFTUP, 0, 0, 0, 0
            CallMouseHookProc = 1
        End If
        
        frmMain.txtHwnd(0).Text = CStr(GetFocus)
        
    End If
    If code <> 0 Then
        CallMouseHookProc = CallNextHookEx(0, code, wParam, lParam)
    End If
End Function
'���̹���
Public Function CallKeyHookProc(ByVal code As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Dim lKey As Long
    Dim strKeyName As String * 255
    Dim strLen As Long
    
    If code = HC_ACTION Then
        CopyMemory keyMsg, lParam, LenB(keyMsg)
        Select Case wParam
            Case WM_SYSKEYDOWN, WM_KEYDOWN, WM_SYSKEYUP, WM_KEYUP:
                lKey = keyMsg.sKey And &HFF           'ɨ����
                lKey = lKey * 65536
                strLen = GetKeyNameText(lKey, strKeyName, 250)
                frmMain.txtMsg(0).Text = "����:" + Left(strKeyName, strLen) + " ������:" + Format(keyMsg.vKey And &HFF, "0") + " ɨ����:" + Format(lKey / 65536, "0")
                frmMain.txtHwnd(0) = ""
                If (GetKeyState(vbKeyControl) And &H8000) Then
                    frmMain.txtHwnd(0) = frmMain.txtHwnd(0) + "Ctrl "
                End If
                If (keyMsg.flag And Alt_Down) <> 0 Then
                    frmMain.txtHwnd(0) = frmMain.txtHwnd(0) + "Alt "
                End If
                
                If (GetKeyState(vbKeyShift) And &H8000) Then
                    frmMain.txtHwnd(0) = frmMain.txtHwnd(0) + "Shift"
                End If
                'keyMsg.vKey And &HFF   ������
                'lKey / 65536           ɨ����
                If (keyMsg.vKey And &HFF) = vbKeyY Then       '��Y���滻ΪN
                    If wParam = WM_SYSKEYDOWN Or wParam = WM_KEYDOWN Then
                        keybd_event vbKeyN, 0, 0, 0
                    End If
                    CallKeyHookProc = 1        '���ΰ���
                End If
                
                
                
                    mciSendString "close mc", 0, 0, 0
                    mciSendString "open " & App.Path & "\1.wav" & " alias mc", 0, 0, 0
                    mciSendString "play mc", 0, 0, 0
                
                
                
                
                
                
                
                
        End Select
    End If
    
    If code <> 0 Then
        CallKeyHookProc = CallNextHookEx(0, code, wParam, lParam)
    End If
End Function
'��깳�ӣ����Ի�ÿؼ����
Public Function CallHandle(ByVal code As Long, ByVal wParam As Long, ByVal lParam As Long) As Long
    Dim pt As POINTAPI
    Dim lngP As Long
    If code = HC_ACTION Then
        If wParam = WM_LBUTTONDOWN Or wParam = WM_LBUTTONUP Then    'ֻ�������������º͵���
            If Not bolClickButton Then
                If Not bolClickButton Then
                    lngP = GetCursorPos(pt)
                     '��ô�������
                    frmMain.txtHwnd(0) = WindowFromPoint(pt.X, pt.Y)
                End If
            End If
        End If
    End If
    If code <> 0 Then
        CallHandle = CallNextHookEx(0, code, wParam, lParam)
    End If
End Function
