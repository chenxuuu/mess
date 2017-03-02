VERSION 5.00
Begin VB.Form frmMain 
   Caption         =   "Hook"
   ClientHeight    =   7050
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6510
   LinkTopic       =   "Form1"
   ScaleHeight     =   7050
   ScaleWidth      =   6510
   StartUpPosition =   3  '窗口缺省
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   495
      Left            =   5040
      TabIndex        =   9
      Top             =   7560
      Width           =   1215
   End
   Begin VB.CommandButton btnHook 
      Caption         =   "加载Hook"
      Height          =   495
      Left            =   4800
      TabIndex        =   4
      Top             =   360
      Width           =   1215
   End
   Begin VB.TextBox txtHwnd 
      Height          =   375
      Index           =   1
      Left            =   600
      TabIndex        =   3
      Text            =   "Text1"
      Top             =   10080
      Width           =   3615
   End
   Begin VB.TextBox txtHwnd 
      Height          =   375
      Index           =   0
      Left            =   600
      TabIndex        =   2
      Text            =   "Text1"
      Top             =   9000
      Width           =   3615
   End
   Begin VB.TextBox txtMsg 
      Height          =   375
      Index           =   1
      Left            =   600
      TabIndex        =   1
      Text            =   "Text1"
      Top             =   8040
      Width           =   3615
   End
   Begin VB.TextBox txtMsg 
      Height          =   375
      Index           =   0
      Left            =   360
      TabIndex        =   0
      Text            =   "Text1"
      Top             =   600
      Width           =   3615
   End
   Begin VB.Label Label4 
      Caption         =   "Label4"
      Height          =   375
      Left            =   600
      TabIndex        =   8
      Top             =   9600
      Width           =   975
   End
   Begin VB.Label Label3 
      Caption         =   "Label3"
      Height          =   255
      Left            =   600
      TabIndex        =   7
      Top             =   8640
      Width           =   975
   End
   Begin VB.Label Label2 
      Caption         =   "Label2"
      Height          =   255
      Left            =   600
      TabIndex        =   6
      Top             =   7560
      Width           =   975
   End
   Begin VB.Label Label1 
      Caption         =   "按键信息"
      Height          =   375
      Left            =   360
      TabIndex        =   5
      Top             =   120
      Width           =   1335
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private Sub btnHook_Click()
    If btnHook.Caption = "加载Hook" Then
        Call AddHook
        btnHook.Caption = "卸载Hook"
    Else
        Call DelHook
        btnHook.Caption = "加载Hook"
    End If
End Sub

Private Sub Command1_GotFocus()
    bolClickButton = True
End Sub

Private Sub Form_Load()


'play = sndPlaySound("C:\\Windows\\Media\\1.wav", &H0)




    Label1.Caption = txtMsg(0).hwnd
    Label2.Caption = txtMsg(1).hwnd
    Label3.Caption = txtHwnd(0).hwnd
    Label4.Caption = txtHwnd(1).hwnd
End Sub

Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    If btnHook.Caption = "卸载Hook" Then Call DelHook
End Sub


