VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "函数作图工具  晨旭制作 (qq:961726194)"
   ClientHeight    =   7260
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   6855
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   7260
   ScaleWidth      =   6855
   StartUpPosition =   3  '窗口缺省
   Begin VB.TextBox Text7 
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   5040
      TabIndex        =   25
      Text            =   "0"
      Top             =   5640
      Width           =   495
   End
   Begin VB.TextBox Text6 
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   3840
      TabIndex        =   22
      Text            =   "0"
      Top             =   5640
      Width           =   495
   End
   Begin VB.TextBox Text5 
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2760
      TabIndex        =   19
      Text            =   "1"
      Top             =   5640
      Width           =   495
   End
   Begin VB.TextBox Text4 
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1320
      TabIndex        =   17
      Text            =   "1"
      Top             =   5640
      Width           =   495
   End
   Begin VB.CommandButton Command3 
      Caption         =   "点此画图"
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   18
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   3480
      TabIndex        =   16
      Top             =   6120
      Width           =   1695
   End
   Begin VB.CommandButton Command2 
      Caption         =   "退出"
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   18
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   5280
      TabIndex        =   9
      Top             =   6120
      Width           =   1455
   End
   Begin VB.TextBox Text3 
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2760
      TabIndex        =   8
      Text            =   "0"
      Top             =   5040
      Width           =   615
   End
   Begin VB.TextBox Text2 
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   2040
      TabIndex        =   6
      Text            =   "1"
      Top             =   4680
      Width           =   495
   End
   Begin VB.TextBox Text1 
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   1320
      TabIndex        =   3
      Text            =   "1"
      Top             =   5040
      Width           =   495
   End
   Begin VB.PictureBox Picture1 
      Height          =   4455
      Left            =   120
      ScaleHeight     =   4395
      ScaleWidth      =   6555
      TabIndex        =   1
      Top             =   120
      Width           =   6615
   End
   Begin VB.CommandButton Command1 
      BackColor       =   &H000000C0&
      Caption         =   "点此画图"
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   18
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   3480
      MaskColor       =   &H0000FFFF&
      TabIndex        =   0
      Top             =   4680
      Width           =   1695
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "+"
      BeginProperty Font 
         Name            =   "Segoe Script"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Index           =   2
      Left            =   4680
      TabIndex        =   24
      Top             =   5520
      Width           =   225
   End
   Begin VB.Label Label10 
      Caption         =   "）"
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   4440
      TabIndex        =   23
      Top             =   5640
      Width           =   255
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "+"
      BeginProperty Font 
         Name            =   "Segoe Script"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Index           =   1
      Left            =   3600
      TabIndex        =   21
      Top             =   5520
      Width           =   180
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "x"
      BeginProperty Font 
         Name            =   "Segoe Print"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   555
      Index           =   1
      Left            =   3360
      TabIndex        =   20
      Top             =   5520
      Width           =   165
   End
   Begin VB.Label Label9 
      AutoSize        =   -1  'True
      Caption         =   "sin（"
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Left            =   1920
      TabIndex        =   18
      Top             =   5640
      Width           =   885
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "函数:"
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Index           =   1
      Left            =   0
      TabIndex        =   15
      Top             =   5640
      Width           =   870
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "y="
      BeginProperty Font 
         Name            =   "Segoe Script"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Index           =   1
      Left            =   840
      TabIndex        =   14
      Top             =   5520
      Width           =   390
   End
   Begin VB.Label Label8 
      Caption         =   "(2)"
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   5400
      Width           =   495
   End
   Begin VB.Label Label7 
      Caption         =   "(1)"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   4680
      Width           =   495
   End
   Begin VB.Label Label6 
      AutoSize        =   -1  'True
      Caption         =   " 6"
      Height          =   180
      Left            =   1200
      TabIndex        =   11
      Top             =   6840
      Width           =   180
   End
   Begin VB.Label Label5 
      Caption         =   "示范：y=3x +2(（1）或（2）格子不能为空，必须填满，不然程序将无法运行)"
      Height          =   255
      Left            =   360
      TabIndex        =   10
      Top             =   6960
      Width           =   6255
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "+"
      BeginProperty Font 
         Name            =   "Segoe Script"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Index           =   0
      Left            =   2520
      TabIndex        =   7
      Top             =   4920
      Width           =   180
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "x"
      BeginProperty Font 
         Name            =   "Segoe Print"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   555
      Index           =   0
      Left            =   1920
      TabIndex        =   5
      Top             =   4920
      Width           =   165
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "y="
      BeginProperty Font 
         Name            =   "Segoe Script"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   510
      Index           =   0
      Left            =   840
      TabIndex        =   4
      Top             =   4920
      Width           =   390
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "函数:"
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   15.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      Index           =   0
      Left            =   0
      TabIndex        =   2
      Top             =   5040
      Width           =   870
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Dim X, Y As Single
s1 = Val(Text1.Text)
s2 = Val(Text2.Text)
s3 = Val(Text3.Text)
If Text1.Text = "" Then
  MsgBox ("请将空格填满")
Else
  If Text2.Text = "" Then
    MsgBox ("请将空格填满")
  Else
    If Text3.Text = "" Then
      MsgBox ("请将空格填满")
    Else
Picture1.Scale (-10, 25)-(10, -25)
Picture1.Line (-10, 0)-(10, 0), RGB(0, 0, 255)
Picture1.Line (0, 25)-(0, -25), RGB(0, 0, 255)
For X = -10 To 10 Step 0.0001
Y = s1 * X ^ s2 + s3
Picture1.PSet (X, Y), RGB(255, 0, 0)
Next X
     End If
End If
End If
End Sub
Private Sub Command2_Click()
End
End Sub
Private Sub Command3_Click()
Dim X, Y As Single
s4 = Val(Text4.Text)
s5 = Val(Text5.Text)
s6 = Val(Text6.Text)
s7 = Val(Text7.Text)

If Text4.Text = "" Then
  MsgBox ("请将空格填满")
Else
  If Text5.Text = "" Then
    MsgBox ("请将空格填满")
  Else
    If Text6.Text = "" Then
      MsgBox ("请将空格填满")
    Else
     If Text7.Text = "" Then
     MsgBox ("请将空格填满")
     Else
     Picture1.Scale (-10, 25)-(10, -25)
Picture1.Line (-10, 0)-(10, 0), RGB(0, 0, 255)
Picture1.Line (0, 25)-(0, -25), RGB(0, 0, 255)
For X = -10 To 10 Step 0.0001
Y = Sin(s5 * X + s6) * s4 + s7
Picture1.PSet (X, Y), RGB(0, 255, 0)
Next X
End If

     End If
End If
End If



End Sub

