Imports System.Net
Imports System.Net.WebClient
Imports System.Security.Cryptography
Imports RestSharp
Imports System.IO

Public Class LBPPayNow2
    Inherits System.Web.UI.Page
    Public Shared transType As String
    Public Shared referenceCode As String
    Public Shared BIN_TDN As String
    Public Shared Multiple_TDN As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Write("Redirecting to Land Bank Payment Portal...")
        PostPayments()
    End Sub

    Private Shared Function sha256(ByVal randomString As String) As String
        Dim crypt = New System.Security.Cryptography.SHA256Managed()
        Dim hash = New System.Text.StringBuilder()
        Dim crypto As Byte() = crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(randomString))

        For Each theByte As Byte In crypto
            hash.Append(theByte.ToString("x2"))
        Next

        Return hash.ToString()
    End Function
    Private Sub do_post()
        Dim PostURL As String
        Dim allParam As String
        PostURL = "http://222.127.109.129:8080/LBP-LinkBiz-RS/rs/postpayment"
        Dim OriginProxy As String = "https://cors-anywhere.herokuapp.com/"
        Dim PostAction As String = "http://222.127.109.129:8080/LBP-LinkBiz-RS/rs/postpayment"
        Dim trxnamt As String = cDalPayment.LBP_Amount 'Transaction Amount(Ex. 2000.00)
        Dim merchantcode As String = "0322" 'Assigned Merchant Code for SJDM: 0322
        Dim bankcode As String = "B000" '	LBP = B000 (Fixed)
        Dim trxndetails As String = cDalPayment.LBP_TransType 'Transaction type Real Property Tax or Business Permit
        Dim trandetail1 As String = cDalPayment.LBP_OnlineID 'Online ID
        Dim trandetail2 As String = cDalPayment.LBP_PayorName '	Payor Name
        Dim trandetail3 As String = cDalPayment.LBP_ACCTNO 'TDN/BIN
        Dim trandetail4 As String = trxndetails & " Payment" ' Description = trxndetails & " Payment"
        Dim trandetail5 As String = cDalPayment.LBP_PayorEmail 'Email Address
        Dim trandetail6 As String = Nothing 'Null
        Dim trandetail7 As String = Nothing 'Null
        Dim trandetail8 As String = Nothing 'Null
        Dim trandetail9 As String = Nothing 'Null
        Dim trandetail10 As String = Nothing 'Null
        Dim trandetail11 As String = 0 '0
        Dim trandetail12 As String = 0 '0
        Dim trandetail13 As String = 0 '0
        Dim trandetail14 As String = 0 '0
        Dim trandetail15 As String = 0 '0
        Dim trandetail16 As String = 0 '0
        Dim trandetail17 As String = 0 '0
        Dim trandetail18 As String = 0 '0
        Dim trandetail19 As String = 0 '0
        Dim trandetail20 As String = Nothing 'Null
        Dim callbackurl As String = cDalPayment.LBP_ReturnURLOK 'Return URL

        Dim username As String = "sjdm0322" 'sjdm0322
        Dim password As String = "pass1234" 'pass1234
        Dim Key As String = "N\HWJUKFHQX"

        allParam = trxnamt & _
                   merchantcode & _
                   trxndetails & _
                   trandetail1 & _
                   trandetail2 & _
                   trandetail3 & _
                   trandetail4 & _
                   trandetail5 & _
                   trandetail6 & _
                   trandetail7 & _
                   trandetail8 & _
                   trandetail9 & _
                   trandetail10 & _
                   trandetail11 & _
                   trandetail12 & _
                   trandetail13 & _
                   trandetail14 & _
                   trandetail15 & _
                   trandetail16 & _
                   trandetail17 & _
                   trandetail18 & _
                   trandetail19 & _
                   trandetail20 & _
                   username & _
                   password & _
                   Key

        Dim checksum As String = sha256(allParam)  'Calculated Checksum based on the posted details

        Response.Clear()
        Dim sb = New System.Text.StringBuilder()
        sb.Append("<html>")
        sb.AppendFormat("<body>")
        sb.AppendFormat("<script>")
        sb.Append("var x;" & _
                  "var xhr = new XMLHttpRequest();" & _
                  "xhr.addEventListener('readystatechange', function() {" & _
                  "  if(this.readyState === 4) {" & _
                  " var ArrStr = this.responseText.split('|');" & _
                  " var ErrCode = ArrStr[0];" & _
                  " var StrUrl = ArrStr[1];" & _
                  "   console.log('ErrCode:' + ErrCode);" & _
                  "   console.log('StrUrl:' + StrUrl);" & _
                  "   if (ErrCode=='00'){location.replace(StrUrl);}" & _
                  "}});" & _
                  "xhr.open('POST', '" & OriginProxy & PostAction & "?trxnamt=" & trxnamt & _
                                    "&merchantcode=" & merchantcode & "&bankcode=" & bankcode & _
                                    "&trxndetails=" & trxndetails.Replace(" ", "%20") & "&trandetail1=" & trandetail1 & _
                                    "&trandetail2=" & trandetail2.Replace(" ", "%20") & "&trandetail3=" & trandetail3 & _
                                    "&trandetail4=" & trandetail4.Replace(" ", "%20") & "&trandetail5=" & trandetail5 & _
                                    "&trandetail6&trandetail7&trandetail8&trandetail9&trandetail10&trandetail11=0&trandetail12=0&trandetail13=0&trandetail14=0&trandetail15=0&trandetail16=0&trandetail17=0&trandetail18=0&trandetail19=0&trandetail20" & _
                                    "&callbackurl=" & callbackurl & "&checksum=" & checksum & "&username=" & username & "&password=" & password & "');" & _
                  "xhr.send();")
        sb.Append("</script>")
        sb.Append("</body>")
        sb.Append("</html>")
        Response.Write(sb.ToString())
        Response.[End]()






    End Sub
    Sub PostPayments()

        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

        Dim trxnamt As String = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "")
        Dim merchantcodex As String = cDalPayment.gw_MerchantCode
        Dim bankcode As String = "B000"
        Dim trxndetails As String = transType
        Dim trandetail1 As String = referenceCode ' Online ID
        Dim trandetail2 As String = cSessionUser._pFirstName & " " & cSessionUser._pLastName 'Payor Name
        Dim trandetail3 As String = BIN_TDN ' TDN or BIN
        Dim trandetail4 As String = cSessionUser._pUserID 'Email ADdress
        Dim trandetail5 As String = cDalPayment.Date_Expire 'Billing Validity Date
        Dim trandetail6 As String = Nothing
        Dim trandetail7 As String = Nothing
        Dim trandetail8 As String = Nothing
        Dim trandetail9 As String = Nothing
        Dim trandetail10 As String = Nothing
        Dim trandetail11 As String = 0
        Dim trandetail12 As String = 0
        Dim trandetail13 As String = 0
        Dim trandetail14 As String = 0
        Dim trandetail15 As String = 0
        Dim trandetail16 As String = 0
        Dim trandetail17 As String = 0
        Dim trandetail18 As String = 0
        Dim trandetail19 As String = 0
        Dim trandetail20 As String = Nothing
        Dim callbackURL As String
        Dim checksum As String = Nothing
        Dim username As String = cDalPayment.gw_UserName
        Dim password As String = cDalPayment.gw_Password
        Dim SecretKey As String = cDalPayment.gw_SecretKey

        Dim LBPDomain As String

        Dim _nClassX As New cHardwareInformation
        Dim _nMachineName As String = Nothing
        _nMachineName = _nClassX._pMachineName.ToUpper


        Try
            If cDalPayment.gw_LIVE = True Then
                callbackURL = cDalPayment.gw_ProdURL_Return
                LBPDomain = cDalPayment.gw_ProdURL

            Else
                callbackURL = cDalPayment.gw_TestURL_Return
                LBPDomain = cDalPayment.gw_TestURL
            End If
        Catch ex As Exception
            callbackURL = cDalPayment.gw_TestURL_Return
            LBPDomain = cDalPayment.gw_TestURL
        End Try


        'LBPDomain = _nClass.gw_ProdURL
        'callbackURL = _nClass.gw_ProdURL_Return

        'callbackURL = _nClass.gw_TestURL_Return
        'LBPDomain = _nClass.gw_TestURL

        checksum = trxnamt & merchantcodex & trxndetails & trandetail1 & trandetail2 & trandetail3 & _
                   trandetail4 & trandetail5 & trandetail6 & trandetail7 & trandetail8 & trandetail9 & _
                   trandetail10 & trandetail11 & trandetail12 & trandetail13 & trandetail14 & trandetail15 & _
                   trandetail16 & trandetail17 & trandetail18 & trandetail19 & trandetail20 & username & password
        checksum = GenerateSHA256String(checksum & SecretKey).ToUpper

        '    LBPDomain = "https://ptsv2.com/t/uhx32-1653967395/post"


        Dim errMsg As String

        ' Dim request As WebRequest = WebRequest.Create(LBPDomain)
        ' request.Method = "POST"
        Dim post_data As String = "?trxnamt=" & trxnamt & _
                                  "&merchantcode=" & merchantcodex & _
                                  "&bankcode=" & bankcode & _
                                  "&trxndetails=" & trxndetails & _
                                  "&trandetail1=" & trandetail1 & _
                                  "&trandetail2=" & trandetail2 & _
                                  "&trandetail3=" & trandetail3 & _
                                  "&trandetail4=" & trandetail4 & _
                                  "&trandetail5=" & trandetail5 & _
                                  "&trandetail6=" & trandetail6 & _
                                  "&trandetail7=" & trandetail7 & _
                                  "&trandetail8=" & trandetail8 & _
                                  "&trandetail9=" & trandetail9 & _
                                  "&trandetail10=" & trandetail10 & _
                                  "&trandetail11=" & trandetail11 & _
                                  "&trandetail12=" & trandetail12 & _
                                  "&trandetail13=" & trandetail13 & _
                                  "&trandetail14=" & trandetail14 & _
                                  "&trandetail15=" & trandetail15 & _
                                  "&trandetail16=" & trandetail16 & _
                                  "&trandetail17=" & trandetail17 & _
                                  "&trandetail18=" & trandetail18 & _
                                  "&trandetail19=" & trandetail19 & _
                                  "&trandetail20=" & trandetail20 & _
                                  "&callbackurl=" & callbackURL & _
                                  "&checksum=" & checksum & _
                                  "&username=" & username & _
                                  "&password=" & password

        Dim string_to_Post As String = LBPDomain & post_data

        Try
            Dim client = New RestClient(string_to_Post)
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            Dim _response As IRestResponse = client.Execute(request)

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.LBP_EPS_InsertLog(string_to_Post, _response.Content, referenceCode, BIN_TDN, transType)

            Response.Write(_response.Content)

            Dim str As String = _response.Content
            Dim strArr() As String
            strArr = str.Split("|")
            If strArr(0) = "00" Then
                Response.Redirect(strArr(1))
                Exit Sub
            End If

            errMsg = 10
            Response.Clear()
            Response.Write(_response.Content)

        Catch ex As Exception
            Response.Clear()
            Response.Write(ex.Message)
        End Try

        'Try

        '    Dim client = New RestClient(string_to_Post)
        '    client.Timeout = -1
        '    Dim request = New RestRequest(Method.POST)
        '    Dim responseX As IRestResponse = client.Execute(request)

        '    Dim str_response As String = responseX.Content.ToString

        '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '    _nClass.LBP_EPS_InsertLog(string_to_Post, responseX.Content, referenceCode, BIN_TDN, transType)
        '    response.Write(responseX.Content)
        '    Dim str As String = responseX.Content
        '    Dim strArr() As String
        '    strArr = str.Split("|")
        '    If strArr(0) = "00" Then
        '        response.Redirect(strArr(1))
        '    End If
        '    errMsg = 10
        'Catch ex As Exception
        '    response.Write(errMsg)
        '    response.Write("<br>")
        '    response.Write(ex.Message)
        'End Try

        '  Try
        '      Dim client = New RestClient(string_to_Post)
        '      client.Timeout = -1
        '      Dim request = New RestRequest(Method.POST)
        '      Dim _response As IRestResponse = client.Execute(request)
        '      Response.Write(_response.Content)
        '  Catch ex As Exception
        '
        '  End Try

        'Try
        '    Dim s As HttpWebRequest
        '    Dim enc As UTF8Encoding
        '    Dim postdata As String
        '    Dim postdatabytes As Byte()
        '    s = HttpWebRequest.Create(LBPDomain)
        '    ServicePointManager.Expect100Continue = True
        '    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        '    enc = New System.Text.UTF8Encoding()
        '    postdata = post_data
        '    postdatabytes = enc.GetBytes(postdata)
        '    s.Method = "POST"
        '    s.ContentType = "application/x-www-form-urlencoded"
        '    s.ContentLength = postdatabytes.Length

        '    Using stream = s.GetRequestStream()
        '        stream.Write(postdatabytes, 0, postdatabytes.Length)
        '    End Using
        '    Dim result = s.GetResponse()
        '    response.Write("ok : " & result.ToString)
        'Catch ex As Exception
        '    response.Write("err : " & ex.Message)
        'End Try




    End Sub


    


    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Public Shared Function GenerateSHA256String(ByVal inputString) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function


End Class