Imports Microsoft.VisualBasic

Public Class Class1
    Public Shared Function GetData(ByVal url As String, ByVal data As String) As String

        Dim request As HttpWebRequest = WebRequest.Create(url + "?" + data)
        request.Method = "GET"
        Dim sr As StreamReader = New StreamReader(request.GetResponse().GetResponseStream)
        Return sr.ReadToEnd
    End Function

    Public Shared Function PostData(ByVal url As String, ByVal data As String) As String

        ServicePointManager.Expect100Continue = False
        Dim request As HttpWebRequest = WebRequest.Create(url)
        '//Post请求方式  
        request.Method = "POST"

        '内容类型  
        request.ContentType = "application/x-www-form-urlencoded"
        '将URL编码后的字符串转化为字节  
        Dim encoding As New UTF8Encoding()
        Dim bys As Byte() = encoding.GetBytes(data)
        '设置请求的 ContentLength   
        request.ContentLength = bys.Length
        '获得请 求流  
        Dim newStream As Stream = request.GetRequestStream()
        newStream.Write(bys, 0, bys.Length)
        newStream.Close()
        '获得响应流  
        Dim sr As StreamReader = New StreamReader(request.GetResponse().GetResponseStream)
        Return sr.ReadToEnd
    End Function
End Class
