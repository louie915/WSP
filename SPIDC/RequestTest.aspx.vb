Imports RestSharp
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Net.Mail





Public Class RequestTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        itbs()
    End Sub

    Sub testHTTP()

        Dim url = "https://devuat.smartcountry.ph/cpps/api/itbsGetTokenKey"
        Dim httpRequest = CType(WebRequest.Create(url), HttpWebRequest)
        httpRequest.Method = "POST"
        httpRequest.ContentType = "application/json"

        Dim data = " {""apiKey"":""4f8b4e8d72f395d3bb0bb8bc2019cb44"",""mode"":""API"",""sourceTransID"":""bpn-12455485"",""amount"":800,""paymentDesc"":""soŌ shoes"",""payorName"":""Juan de la Cruz"",""email"": ""myemail@mailserver.com"",""contactNo"":""09124248465"",""returnURL"":""www.lgu.com/bpls/paymentCallBack""}"

        Using streamWriter As New StreamWriter(httpRequest.GetRequestStream())
            streamWriter.Write(data)
        End Using

        Dim httpResponse = CType(httpRequest.GetResponse(), HttpWebResponse)

        Using streamReader As New StreamReader(httpResponse.GetResponseStream())
            Dim result As String = streamReader.ReadToEnd()
        End Using

        Response.Write(httpResponse.StatusCode)
   
    End Sub

    Sub testPayMaya(ByVal API_Module As String)
        Dim pk As String = "pk-Z0OSzLvIcOI2UIvDhdTGVVfRSSeiGStnceqwUE7n0Ah"
        Dim pkPass As String = ""
        Dim strAutorization = "Basic " & Base64Encode(pk & ":" & pkPass)
        Dim url As String
        Dim data As String
        Response.Write(strAutorization)

        Select Case (API_Module)
            Case "Create Checkout Payment - POST"
                url = "https://pg-sandbox.paymaya.com/checkout/v1/checkouts"
                Dim httpRequest = CType(WebRequest.Create(url), HttpWebRequest)
                httpRequest.Method = "POST"
                httpRequest.ContentType = "application/json"
                httpRequest.Headers.Add("Authorization", strAutorization)
                '  CreateCheckoutPayment_POST.TotalAmount [discount]
                '  data = serializer.Serialize(Subscriptiondetails)              
            Case "Get Checkout - GET"
            Case "Get Payments via RRN - GET"
            Case "Void by ID - POST"
            Case "Get Voids - GET"
            Case "Refund by ID - POST"
            Case "Get Refunds - GET"
        End Select

    End Sub

    Public Shared Function Base64Encode(ByVal plainText As String) As String
        Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText)
        Return System.Convert.ToBase64String(plainTextBytes)
    End Function



    Function Generate_Token()
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim request As WebRequest = WebRequest.Create("https://api.dev.business.gov.ph/v1/api/security/request-token")
        request.Method = "POST"
        Dim postData As String = " {" & _
                   """application_id"":""caloocan@gov.ph""," & _
                   """application_secret"":""d5b6fdb0-1390-4f3c-8431-309a4063abf8"", " & _
                   """client_name"":""City Government of Caloocan""" & _
                   "}"
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/json"
        request.ContentLength = byteArray.Length

        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine((CType(response, HttpWebResponse)).StatusDescription)
        Dim responseFromServer As String
        Using CSharpImpl.__Assign(dataStream, response.GetResponseStream())
            Dim reader As StreamReader = New StreamReader(dataStream)
            responseFromServer = reader.ReadToEnd()
        End Using
        Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(responseFromServer)
        Return res("access_token")

    End Function


    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Sub itbs()
        'https://ptsv2.com/t/esert-1633674356/
        't/esert-1633674356/post

        'https://devuat.smartcountry.ph/
        '/cpps/api/itbsGetTokenKey

        Dim client = New RestClient("https://devuat.smartcountry.ph/")
        client.Timeout = -1
        Dim request = New RestRequest("/cpps/api/itbsGetTokenKey", Method.POST)

        Dim body = " {" & _
                    """apiKey"":""4f8b4e8d72f395d3bb0bb8bc2019cb44""," & _
                    """mode"":""API"", " & _
                    """sourceTransID"":""bpn-12455485""," & _
                    """amount"":800," & _
                    """paymentDesc"":""soŌ shoes""," & _
                    """payorName"":""Juan de la Cruz""," & _
                    """email"": ""myemail@mailserver.com""," & _
                    """contactNo"":""""," & _
                    """returnURL"":""www.lgu.com/bpls/paymentCallBack""" & _
                    "}"

        '    ' request.AddHeader("Authorization", "Basic c3BpZGN3ZWJhcGk6c3BpZGN3ZWJhcGlwYXNzd29yZA==")
        request.AddParameter("application/json", body, ParameterType.RequestBody)
        '    request.AddParameter("apiKey", "4f8b4e8d72f395d3bb0bb8bc2019cb44", ParameterType.RequestBody)
        '    request.AddParameter("mode", "API", ParameterType.RequestBody)
        '    request.AddParameter("sourceTransID", "bpn-12455485", ParameterType.RequestBody)
        '    request.AddParameter("payorName", "Juan de la Vega", ParameterType.RequestBody)
        '    request.AddParameter("email", "jdvega@noemail.com", ParameterType.RequestBody)
        '    request.AddParameter("contactNo", "09127248466", ParameterType.RequestBody)
        '    request.AddParameter("amount", "5001.95", ParameterType.RequestBody)
        '    request.AddParameter("paymentDesc", "Payment for business permit no : 944", ParameterType.RequestBody)
        '    request.AddParameter("returnURL", "https://lgu.com/callback", ParameterType.RequestBody)
        '
        Dim response1 As IRestResponse = client.Execute(request)
        Response.Write(response1.Content)

        Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(response1.Content)
        Response.Write(res)
        '  Response.Write(res("paymentLink"))
        '   Response.Redirect(res("paymentLink") & "/" & res("tokenID"))
        ' testHTTP()
    End Sub



    Private Sub btnSubmit_ServerClick(sender As Object, e As EventArgs) Handles btnSubmit.ServerClick
        '***Convert Image File to Base64 Encoded string***

        'Read the uploaded file using BinaryReader and convert it to Byte Array.
        ' Dim br As New BinaryReader(FileUpload1.PostedFile.InputStream)
        ' Dim bytes As Byte() = br.ReadBytes(CInt(FileUpload1.PostedFile.InputStream.Length))
        '
        'Convert the Byte Array to Base64 Encoded string.
        Dim base64String As String = txt64.Value

        '***Save Base64 Encoded string as Image File***

        'Convert Base64 Encoded string to Byte Array.
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)

        txtFileData.Value = imageBytes.ToString
        'Save the Byte Array as Image File.
        ' Dim filePath As String = Server.MapPath("~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName))
        Dim _nclass As New cDalAppointment
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

        ' Dim FileData As HttpPostedFile = up1.PostedFile
        ' Dim FileName As String = up1.PostedFile.FileName
        ' Dim FileType As String = up1.PostedFile.ContentType
        ' Dim fs As Stream = FileData.InputStream
        ' Dim br As New BinaryReader(fs)
        ' Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

        _nclass._pSubInsertAttachFiles("test", "test", "test", "test", "test", imageBytes, "test", "image/jpeg", "test", "test")



    End Sub


    Public Sub Upload(ByVal filePath As String)
        Dim access_token As String = Generate_Token()
        Dim formdataTemplate As String = "Content-Disposition: form-data; filename=""{0}"";" & vbCrLf & "Content-Type: application/pdf" & vbCrLf & vbCrLf
        Dim boundary As String = "---------------------------" & DateTime.Now.Ticks.ToString("x")
        Dim boundarybytes As Byte() = Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & vbCrLf)
        Dim request As WebRequest = WebRequest.Create("https://api.dev.business.gov.ph/v1/api/ebpls/business/v2/upload/CBPCC3C5E3F16E706ADC")
        request.Method = "POST"
        request.Headers.Add("Authorization", "Bearer " & access_token)
        Using fileStream As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read)

            Using requestStream As Stream = request.GetRequestStream()
                requestStream.Write(boundarybytes, 0, boundarybytes.Length)
                Dim formitem As String = String.Format(formdataTemplate, Path.GetFileName(filePath))
                Dim formbytes As Byte() = Encoding.UTF8.GetBytes(formitem)
                requestStream.Write(formbytes, 0, formbytes.Length)
                Dim buffer As Byte() = New Byte(4095) {}
                Dim bytesLeft As Integer = 0

                While (CSharpImpl.__Assign(bytesLeft, fileStream.Read(buffer, 0, buffer.Length))) > 0
                    requestStream.Write(buffer, 0, bytesLeft)
                End While
            End Using
        End Using

        Try
            Using response As WebResponse = CType(request.GetResponse(), WebResponse)
                Using reader As New StreamReader(response.GetResponseStream())
                    Dim result As String = reader.ReadToEnd()
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Sub test()
        Dim access_token As String = Generate_Token()
        Dim client = New RestClient("https://api.dev.business.gov.ph/v1/api/ebpls/business/v2/upload/CBPCC3C5E3F16E706ADC")
        client.Timeout = -1
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Authorization", "Bearer " & access_token)
        request.AddParameter("file", FileUpload1.PostedFile.InputStream, ParameterType.RequestBody)
        Dim responsex As IRestResponse = client.Execute(request)
        Response.Write(responsex.Content)
    End Sub
    Public Sub test2(ByVal file As Byte(), ByVal filename As String, ByVal contentType As String, ByVal url As String)
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim access_token As String = Generate_Token()
        Dim webClient = New WebClient()
        webClient.Headers.Add("Authorization", "Bearer " & access_token)
        Dim boundary As String = "------------------------" & DateTime.Now.Ticks.ToString("x")
        webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" & boundary)
        Dim fileData = webClient.Encoding.GetString(file)
        Dim package = String.Format("--{0}" & vbCrLf & "Content-Disposition: form-data; name=""file""; filename=""{1}""" & vbCrLf & "Content-Type: {2}" & vbCrLf & vbCrLf & "{3}" & vbCrLf & "--{0}--" & vbCrLf, boundary, filename, contentType, fileData)
        Dim nfile = webClient.Encoding.GetBytes(package)
        Dim resp As Byte() = webClient.UploadData(url, "POST", nfile)
        Response.Write(webClient.ResponseHeaders)
    End Sub

    Private Sub btnUpload_ServerClick(sender As Object, e As EventArgs) Handles btnUpload.ServerClick
        test()
    End Sub

    Private Sub btnGetURL_ServerClick(sender As Object, e As EventArgs) Handles btnGetURL.ServerClick
        Dim MyUrl As Uri = Request.UrlReferrer
        Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim requestedDomain As String = HttpContext.Current.Request.ServerVariables("HTTP_HOST")
        Dim requestScheme As String = HttpContext.Current.Request.Url.Scheme
        Dim requestQueryString As String = HttpContext.Current.Request.ServerVariables("QUERY_STRING")
        Dim requestUrl As String = HttpContext.Current.Request.ServerVariables("URL")

        Response.Write("Port: " & Server.HtmlEncode(MyUrl.Port.ToString()) & "<br>")
        Response.Write("Scheme: " & Server.HtmlEncode(MyUrl.Scheme) & "<br>")
        Response.Write("RawUrl: " & HttpContext.Current.Request.RawUrl & "<br>")
        Response.Write("UserHostName: " & HttpContext.Current.Request.UserHostName & "<br>")
        Response.Write("GetLeftPart: " & Request.Url.GetLeftPart(UriPartial.Authority) & "<br>")
        Response.Write("FullUrl: " & HttpContext.Current.Request.Url.AbsoluteUri & "<br>")
        Response.Write("PagePath: " & HttpContext.Current.Request.Url.AbsolutePath & "<br>")

        Response.Write("requestedDomain: " & HttpContext.Current.Request.ServerVariables("HTTP_HOST") & "<br>")
        Response.Write("requestScheme: " & HttpContext.Current.Request.Url.Scheme & "<br>")
        Response.Write("requestQueryString: " & HttpContext.Current.Request.ServerVariables("QUERY_STRING") & "<br>")
        Response.Write("requestUrl: " & HttpContext.Current.Request.ServerVariables("URL") & "<br>")

    End Sub


    



End Class
