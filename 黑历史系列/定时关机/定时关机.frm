VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H008080FF&
   BorderStyle     =   1  'Fixed Single
   Caption         =   "定时关机"
   ClientHeight    =   1305
   ClientLeft      =   4050
   ClientTop       =   2370
   ClientWidth     =   3660
   BeginProperty Font 
      Name            =   "宋体"
      Size            =   9
      Charset         =   134
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H00000000&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   MouseIcon       =   "定时关机.frx":0000
   ScaleHeight     =   1305
   ScaleWidth      =   3660
   Begin VB.TextBox Text2 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      Left            =   1080
      TabIndex        =   2
      Top             =   600
      Width           =   1215
   End
   Begin VB.TextBox Text1 
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   270
      Left            =   1080
      TabIndex        =   1
      Top             =   120
      Width           =   1215
   End
   Begin VB.CommandButton Command1 
      Caption         =   "设置"
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   2400
      TabIndex        =   0
      Top             =   360
      Width           =   1095
   End
   Begin VB.Timer Timer1 
      Left            =   2400
      Top             =   240
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      BackColor       =   &H008080FF&
      Caption         =   "设置分钟："
      BeginProperty Font 
         Name            =   "楷体"
         Size            =   10.5
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   210
      Left            =   0
      TabIndex        =   5
      Top             =   600
      Width           =   1125
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackColor       =   &H008080FF&
      Caption         =   "设置小时："
      BeginProperty Font 
         Name            =   "楷体"
         Size            =   10.5
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   210
      Left            =   0
      TabIndex        =   4
      Top             =   120
      Width           =   1125
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackColor       =   &H008080FF&
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   180
      Left            =   120
      TabIndex        =   3
      Top             =   960
      Width           =   90
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim Atime As Variant



Private Sub Form_Load()
Timer1.Interval = 1000
Timer1.Enabled = False
End Sub
Private Sub Command1_Click()
Atime = DateAdd("h", Val(Text1.Text), Time)
Atime = DateAdd("n", Val(Text2.Text), Atime)
Label1.Caption = "你将在" & Atime & "后关机"
Timer1.Enabled = True
End Sub

Private Sub Timer1_Timer()
If Atime = Time Then
Shell ("c:\windows\system32\shutdown.exe -s")
End If
End Sub


