VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Mplayer"
   ClientHeight    =   2505
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   10215
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2505
   ScaleWidth      =   10215
   StartUpPosition =   3  '����ȱʡ
   Begin VB.CommandButton Command3 
      Caption         =   "����"
      Height          =   375
      Left            =   720
      TabIndex        =   4
      Top             =   1680
      Width           =   1335
   End
   Begin VB.CommandButton Command2 
      Caption         =   "����"
      Height          =   375
      Left            =   7200
      TabIndex        =   3
      Top             =   1680
      Width           =   1335
   End
   Begin VB.TextBox Text1 
      Height          =   375
      Left            =   600
      Locked          =   -1  'True
      TabIndex        =   2
      Text            =   "��ѡ���ļ�"
      Top             =   960
      Width           =   7695
   End
   Begin VB.CommandButton Command1 
      Caption         =   "���"
      Height          =   375
      Left            =   8640
      TabIndex        =   1
      Top             =   960
      Width           =   1335
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "��ѡ��Ҫ���ŵ��ļ���"
      BeginProperty Font 
         Name            =   "΢���ź�"
         Size            =   15
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   360
      TabIndex        =   0
      Top             =   360
      Width           =   3000
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Function GetOpenFileName Lib "comdlg32.dll" Alias "GetOpenFileNameA" (pOpenfilename As OPENFILENAME) As Long

Private Type OPENFILENAME
    lStructSize As Long
    hwndOwner As Long
    hInstance As Long
    lpstrFilter As String
    lpstrCustomFilter As String
    nMaxCustFilter As Long
    nFilterIndex As Long
    lpstrFile As String
    nMaxFile As Long
    lpstrFileTitle As String
    nMaxFileTitle As Long
    lpstrInitialDir As String
    lpstrTitle As String
    flags As Long
    nFileOffset As Integer
    nFileExtension As Integer
    lpstrDefExt As String
    lCustData As Long
    lpfnHook As Long
    lpTemplateName As String
End Type

Private Sub Command1_Click()
    Dim OFName As OPENFILENAME
    OFName.lStructSize = Len(OFName)
    OFName.hwndOwner = Me.hWnd
    OFName.hInstance = App.hInstance
'    OFName.lpstrFilter = "Mp4ý���ļ�(*.mp4)" & Chr$(0) & "*.mp4" & Chr$(0) & "�����ļ�(*.*)" & Chr$(0) & "*.*" & Chr$(0)
    OFName.lpstrFilter = "�����ļ�(*.*)" & Chr$(0) & "*.*" & Chr$(0)
    OFName.lpstrFile = Space(254)
    OFName.nMaxFile = 255
    OFName.lpstrFileTitle = Space(254)
    OFName.nMaxFileTitle = 255
    OFName.lpstrInitialDir = App.Path '��ʼĿ¼
    OFName.lpstrTitle = "ѡ���ļ�" '����
    OFName.flags = 6148
    If GetOpenFileName(OFName) >= 1 Then
        Text1 = OFName.lpstrFile
    Else
        Text1 = "��ѡ���ļ�"
    End If
End Sub

Private Sub Command2_Click()
If Text1 = "��ѡ���ļ�" Then
    MsgBox "��ѡ���ļ���"
Else
    Shell (App.Path & "\MPlayer\mplayer.exe  -vo caca " & Text1.Text)
End If

End Sub

Private Sub Command3_Click()
MsgBox "��������,chenxublog.com"
End Sub
