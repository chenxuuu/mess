NameSpace = "http://schemas.microsoft.com/cdo/configuration/"
Set Email = CreateObject("CDO.Message")
Email.From = "poi@papapoi.com"
Email.To = "liucx1@qq.com"
Email.Subject = "FN�ѵ���������"
Email.Textbody = "���Գ�����Ա����"
With Email.Configuration.Fields
.Item(NameSpace&"sendusing") = 2
.Item(NameSpace&"smtpserver") = "smtp.qq.com" 
.Item(NameSpace&"smtpserverport") = 25
.Item(NameSpace&"smtpauthenticate") = 1
.Item(NameSpace&"sendusername") = "poi@papapoi.com"
.Item(NameSpace&"sendpassword") = "shengwu123"
.Update
End With
Email.Send