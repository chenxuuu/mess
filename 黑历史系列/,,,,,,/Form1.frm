VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FFC0C0&
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   4920
   ClientLeft      =   5535
   ClientTop       =   4110
   ClientWidth     =   10980
   LinkTopic       =   "Form1"
   ScaleHeight     =   4920
   ScaleWidth      =   10980
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton Command1 
      Caption         =   "ȷ��"
      Height          =   495
      Left            =   4320
      TabIndex        =   3
      Top             =   3840
      Width           =   1815
   End
   Begin VB.TextBox Text1 
      BeginProperty Font 
         Name            =   "����"
         Size            =   30
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   870
      Left            =   2880
      TabIndex        =   2
      Top             =   2280
      Width           =   4455
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFC0C0&
      Caption         =   "������""������""����Ȼ��ػ�����"
      BeginProperty Font 
         Name            =   "����"
         Size            =   35.25
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   705
      Left            =   120
      TabIndex        =   1
      Top             =   1320
      Width           =   11040
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackColor       =   &H00FFC0C0&
      Caption         =   "�����������������ˣ�"
      BeginProperty Font 
         Name            =   "����"
         Size            =   39.75
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000FF&
      Height          =   795
      Left            =   1080
      TabIndex        =   0
      Top             =   240
      Width           =   8250
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
 If Text1.Text = "������" Then
      
            MsgBox ("�����㣬�Ҳ��������˵������ܵ�!! ^_^")
           
            End
        Else
            Shell ("c:\windows\system32\shutdown.exe -s")
        End If
End Sub
