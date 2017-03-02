VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3075
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   10785
   LinkTopic       =   "Form1"
   ScaleHeight     =   3075
   ScaleWidth      =   10785
   StartUpPosition =   3  '窗口缺省
   Begin VB.TextBox Text1 
      Height          =   2655
      Left            =   120
      MultiLine       =   -1  'True
      TabIndex        =   0
      Text            =   "Form1.frx":0000
      Top             =   120
      Width           =   7455
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "不包含"
      Height          =   180
      Left            =   9120
      TabIndex        =   3
      Top             =   1680
      Width           =   540
   End
   Begin VB.Label Label2 
      Caption         =   "0"
      Height          =   375
      Left            =   9240
      TabIndex        =   2
      Top             =   480
      Width           =   1215
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "运行中，计数"
      Height          =   180
      Left            =   8040
      TabIndex        =   1
      Top             =   480
      Width           =   1080
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private Sub Form_Load()
Dim url As String
url = "https://shop112084796.taobao.com/"
Set xmlHTTP = CreateObject("Microsoft.XMLHTTP")
xmlHTTP.open "GET", url, False
xmlHTTP.Send (Null)
While xmlHTTP.ReadyState <> 4
DoEvents
Wend
areacheck = xmlHTTP.responseText




Text1.Text = ""

Text1.Text = areacheck

Label2.Caption = Label2.Caption + 1

If InStr(areacheck, "MK60FN") Then
Label3.Caption = "包含"
CreateObject("wscript.shell").run "1.vbs"
Else
Label3.Caption = "不包含"
End
End If
End Sub
