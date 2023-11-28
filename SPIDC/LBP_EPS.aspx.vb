Imports RestSharp
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Security.Cryptography

Public Class LBP_EPS
    Inherits System.Web.UI.Page
    Dim Post_OK As Boolean
    Dim redirectURL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Sub PerformEcho()
        Try
            Dim request As WebRequest = WebRequest.Create("http://222.127.109.129:8080/LBP-LinkBiz-RS/rs/echo/" & PerformEcho_Input.Value)
            request.Credentials = CredentialCache.DefaultCredentials
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine((CType(response, HttpWebResponse)).StatusDescription)

            Using dataStream As Stream = response.GetResponseStream()
                Dim reader As StreamReader = New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()
                txt_Result.InnerHtml = responseFromServer

            End Using
            response.Close()
        Catch ex As Exception
            txt_Result.InnerHtml = ex.Message
        End Try
    End Sub

    Sub PostPayments(ByRef Post_OK1 As Boolean)

        Try
            Dim strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery
            Dim strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/")
            Dim callbackurl As String = strUrl & "/PaymentConfirmation.aspx"

            Dim request As WebRequest = WebRequest.Create("http://222.127.109.129:8080/LBP-LinkBiz-RS/rs/postpayment")
            request.Method = "POST"
            Dim postData As String = "" & _
                "trxnamt=" & PostPayments_trxnamt.Value & "&" & _
                "merchantcode=" & PostPayments_merchantcode.Value & "&" & _
                "bankcode=" & PostPayments_bankcode.Value & "&" & _
                "trxndetails=" & PostPayments_trxndetails.Value & "&" & _
                "trandetail1=" & PostPayments_trandetail1.Value & "&" & _
                "trandetail2=" & PostPayments_trandetail2.Value & "&" & _
                "trandetail3=" & PostPayments_trandetail3.Value & "&" & _
                "trandetail4=" & PostPayments_trandetail4.Value & "&" & _
                "trandetail5=" & PostPayments_trandetail5.Value & "&" & _
                "trandetail6=&" & _
                "trandetail7=&" & _
                "trandetail8=&" & _
                "trandetail9=&" & _
                "trandetail10=&" & _
                "trandetail11=0&" & _
                "trandetail12=0&" & _
                "trandetail13=0&" & _
                "trandetail14=0&" & _
                "trandetail15=0&" & _
                "trandetail16=0&" & _
                "trandetail17=0&" & _
                "trandetail18=0&" & _
                "trandetail19=0&" & _
                "trandetail20=&" & _
                "callbackurl=" & callbackurl & "&" & _
                "checksum=" & Get_checksum() & "&" & _
                "username=username&" & _
                "password=password"


            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine((CType(response, HttpWebResponse)).StatusDescription)

            Using CSharpImpl.__Assign(dataStream, response.GetResponseStream())
                Dim reader As StreamReader = New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()

                Dim str As String
                Dim strArr() As String
                str = responseFromServer
                strArr = str.Split("|")
                If strArr(0) = "00" Then
                    redirectURL = strArr(1)
                    Post_OK1 = True
                Else
                    Post_OK1 = False
                End If
                txt_Result.InnerHtml = responseFromServer & "<h1> Posted Data</h1>" & postData.Replace("&", "</br>")

            End Using

            response.Close()
        Catch ex As Exception
            Post_OK1 = False
            txt_Result.InnerHtml = ex.Message
        End Try

    End Sub


    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class



    Private Sub btn_Submit_ServerClick(sender As Object, e As EventArgs) Handles btn_Submit.ServerClick
        ' Select Case hdn_transaction.Value
        '     Case "PerformEcho"
        '         PerformEcho()
        '     Case "PostPayments"
        PostPayments(Post_OK)
        If Post_OK = True Then Response.Redirect(redirectURL)
        '  End Select
    End Sub

    Public Function Get_checksum() As String
        Dim AllParams As String = "" & _
            PostPayments_trxnamt.Value & _
            PostPayments_merchantcode.Value & _
            PostPayments_trxndetails.Value & _
            PostPayments_trandetail1.Value & _
            PostPayments_trandetail2.Value & _
            PostPayments_trandetail3.Value & _
            PostPayments_trandetail4.Value & _
            PostPayments_trandetail5.Value & _
            Nothing & Nothing & Nothing & Nothing & Nothing & _
            0 & 0 & 0 & 0 & 0 & _
            0 & 0 & 0 & 0 & Nothing & _
            PostPayments_username.Value & PostPayments_password.Value

        Return GenerateSHA256String(AllParams & PostPayments_secretKey.Value).ToUpper
    End Function

    Public Shared Function GenerateSHA256String(ByVal inputString) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function

End Class