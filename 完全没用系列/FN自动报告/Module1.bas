Attribute VB_Name = "Module1"
Function HttpGet(url As String) As String
     Dim xmlHTTP As Object, Stime, Ntime
     Set xmlHTTP = CreateObject("Msxml2.XMLHTTP")
     If Not IsObject(xmlHTTP) Then
         Set xmlHTTP = CreateObject("Microsoft.XMLHTTP")
         If Not IsObject(xmlHTTP) Then Exit Function
     End If
     
     On Error GoTo Err
     
     xmlHTTP.open "GET", url, False
     xmlHTTP.setRequestHeader "CONTENT-TYPE", "application/x-www-form-urlencoded"
     
     On Error GoTo Err
     
     xmlHTTP.send
     
     Stime = Now '获取当前时间
     
     Do While xmlHTTP.ReadyState <> 4
         DoEvents
         
         If DateDiff("s", Stime, Ntime) > 5 Then HttpGet = "": Exit Function
     Loop

     If xmlHTTP.Status = 200 Then
         HttpGet = xmlHTTP.responseText
     End If
     
     If 1 = 0 Then
Err:
         HttpGet = ""
     End If
End Function


