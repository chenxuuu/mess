VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H8000000B&
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "秒数快速计算器"
   ClientHeight    =   1950
   ClientLeft      =   6600
   ClientTop       =   4905
   ClientWidth     =   3435
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   1950
   ScaleWidth      =   3435
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton Command2 
      Caption         =   "退出"
      Height          =   375
      Left            =   120
      TabIndex        =   11
      Top             =   1440
      Width           =   615
   End
   Begin VB.TextBox Text1 
      Height          =   270
      Left            =   1320
      TabIndex        =   8
      Top             =   1560
      Width           =   1695
   End
   Begin VB.CommandButton Command1 
      Caption         =   "计算"
      Height          =   495
      Left            =   2160
      TabIndex        =   6
      Top             =   840
      Width           =   975
   End
   Begin VB.TextBox mz 
      Height          =   270
      Left            =   840
      TabIndex        =   5
      Top             =   1080
      Width           =   1215
   End
   Begin VB.TextBox fz 
      Height          =   270
      Left            =   840
      TabIndex        =   4
      Top             =   600
      Width           =   1215
   End
   Begin VB.TextBox xs 
      Height          =   270
      Left            =   840
      TabIndex        =   3
      Top             =   120
      Width           =   1215
   End
   Begin VB.Label Label6 
      AutoSize        =   -1  'True
      Caption         =   "晨旭制作"
      Height          =   180
      Left            =   2280
      TabIndex        =   10
      Top             =   480
      Width           =   720
   End
   Begin VB.Label Label5 
      AutoSize        =   -1  'True
      Caption         =   "秒。"
      Height          =   180
      Left            =   3120
      TabIndex        =   9
      Top             =   1560
      Width           =   360
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "是"
      Height          =   180
      Left            =   960
      TabIndex        =   7
      Top             =   1560
      Width           =   180
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "秒钟："
      Height          =   180
      Left            =   120
      TabIndex        =   2
      Top             =   1080
      Width           =   540
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "分钟："
      Height          =   180
      Left            =   120
      TabIndex        =   1
      Top             =   600
      Width           =   540
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "小时："
      Height          =   180
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   540
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Text1.Text = Val(xs.Text) * 60 * 60 + Val(fz.Text) * 60 + Val(mz.Text)
End Sub

Private Sub Command2_Click()
MsgBox ("谢谢使用！！")
End
End Sub
