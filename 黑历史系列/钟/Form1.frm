VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FFFF00&
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   1365
   ClientLeft      =   10005
   ClientTop       =   0
   ClientWidth     =   6315
   DrawMode        =   1  'Blackness
   ForeColor       =   &H0000FF00&
   Icon            =   "Form1.frx":0000
   LinkTopic       =   "Form1"
   MouseIcon       =   "Form1.frx":1642
   ScaleHeight     =   1365
   ScaleWidth      =   6315
   ShowInTaskbar   =   0   'False
   Begin VB.Timer Timer1 
      Left            =   4800
      Top             =   960
   End
   Begin VB.Label Label2 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "΢���ź�"
         Size            =   24
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FF00&
      Height          =   615
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   6255
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "΢���ź�"
         Size            =   24
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H0000FFFF&
      Height          =   630
      Left            =   0
      TabIndex        =   0
      Top             =   720
      Width           =   6255
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim xx As Long, yy As Long
Private Sub Form_DblClick()
Dim Msg, Style, Title, Help, Ctxt, Response, MyString
Msg = "ȷ���˳���"   '������Ϣ�ı�
Style = vbYesNo + vbCritical + vbDefaultButton2     ' ���尴ť
Title = "��ʾ��"     ' ��������ı�
Response = MsgBox(Msg, Style, Title)
If Response = vbYes Then     ' �û����¡��ǡ�
    MyString = "Yes"     ' ���ĳ����
    End
Else     ' �û����¡���
    MyString = "No"     ' ���ĳ����
End If
End Sub
Private Sub Form_Load()
Label1.Caption = "˫���ɹر�"
Label2.Caption = "��ӭʹ�ã�"
Timer1.Enabled = True
Timer1.Interval = 1000
End Sub
Private Sub Label1_DblClick()                                                               '˫���ر�
Dim Msg, Style, Title, Help, Ctxt, Response, MyString
Msg = "ȷ���˳���"   '������Ϣ�ı�
Style = vbYesNo + vbCritical + vbDefaultButton2     ' ���尴ť
Title = "��ʾ��"     ' ��������ı�
Response = MsgBox(Msg, Style, Title)
If Response = vbYes Then     ' �û����¡��ǡ�
    MyString = "Yes"     ' ���ĳ����
    End
Else     ' �û����¡���
    MyString = "No"     ' ���ĳ����
End If
End Sub

Private Sub Label1_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) '�϶�����
xx = X
yy = Y
End Sub
Private Sub Label1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) '�϶�����
If Button = 1 Then Me.Move Me.Left + X - xx, Me.Top + Y - yy
End Sub
Private Sub Label2_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) '�϶�����
If Button = 1 Then Me.Move Me.Left + X - xx, Me.Top + Y - yy
End Sub
Private Sub Label2_DblClick()                                                               '˫���ر�
Dim Msg, Style, Title, Help, Ctxt, Response, MyString
Msg = "ȷ���˳���"   '������Ϣ�ı�
Style = vbYesNo + vbCritical + vbDefaultButton2     ' ���尴ť
Title = "��ʾ��"     ' ��������ı�
Response = MsgBox(Msg, Style, Title)
If Response = vbYes Then     ' �û����¡��ǡ�
    MyString = "Yes"     ' ���ĳ����
    End
Else     ' �û����¡���
    MyString = "No"     ' ���ĳ����
End If
End Sub

Private Sub Label2_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single) '�϶�����
xx = X
yy = Y
End Sub

Private Sub Timer1_Timer()                                                                  'ʱ��
Label1.Caption = "��ǰʱ�䣺" & Format(Time, "HH��MM��SS��")
Label2.Caption = "��ǰ���ڣ�" & Format(Date, "YYYY��MM��DD��")
End Sub
Private Sub Form_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)   '�϶�����
xx = X
yy = Y
End Sub
Private Sub Form_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)   '�϶�����
If Button = 1 Then Me.Move Me.Left + X - xx, Me.Top + Y - yy
End Sub
