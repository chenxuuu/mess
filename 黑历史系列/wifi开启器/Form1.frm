VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "wifi������"
   ClientHeight    =   3030
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   4560
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3030
   ScaleWidth      =   4560
   StartUpPosition =   3  '����ȱʡ
   Begin VB.CommandButton Command3 
      Caption         =   "����"
      Height          =   375
      Left            =   3600
      TabIndex        =   8
      Top             =   2520
      Width           =   735
   End
   Begin VB.CommandButton Command2 
      Caption         =   "�ر�wifi"
      Height          =   375
      Left            =   2520
      TabIndex        =   5
      Top             =   2160
      Width           =   975
   End
   Begin VB.CommandButton Command1 
      Caption         =   "����wifi"
      Height          =   375
      Left            =   840
      TabIndex        =   4
      Top             =   2160
      Width           =   975
   End
   Begin VB.TextBox Text2 
      Height          =   270
      Left            =   1560
      TabIndex        =   3
      Text            =   "12345678"
      Top             =   720
      Width           =   2175
   End
   Begin VB.TextBox Text1 
      Height          =   270
      Left            =   1560
      TabIndex        =   2
      Text            =   "wifi"
      Top             =   360
      Width           =   2175
   End
   Begin VB.Label Label4 
      AutoSize        =   -1  'True
      Caption         =   "�ر�"
      ForeColor       =   &H000000FF&
      Height          =   180
      Left            =   2400
      TabIndex        =   7
      Top             =   1440
      Width           =   360
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "wifi״̬��"
      Height          =   180
      Left            =   1320
      TabIndex        =   6
      Top             =   1440
      Width           =   900
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "wifi���룺"
      Height          =   180
      Left            =   360
      TabIndex        =   1
      Top             =   720
      Width           =   900
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "wifi����"
      Height          =   180
      Left            =   360
      TabIndex        =   0
      Top             =   360
      Width           =   720
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Shell ("netsh wlan set hostednetwork mode=allow ssid=""" & Text1.Text & """ key=" & Text2.Text)
Shell ("netsh wlan start hostednetwork")
Label4.Caption = "�ѿ���"
End Sub

Private Sub Command2_Click()
Shell ("netsh wlan stop hostednetwork")
Label4.Caption = "�ر�"
End Sub

Private Sub Command3_Click()
MsgBox ("��������,qq961726194,������վ��blog.papapoi.com")
End Sub
