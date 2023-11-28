Imports SPIDC.Resources
Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient
Imports RestSharp
Imports System.Net
Imports System.Security.Cryptography
Imports System.IO
Imports System.Web.Script.Serialization
Imports Org.BouncyCastle.OpenSsl
Imports Org.BouncyCastle.Crypto
Imports Org.BouncyCastle.Security
Imports Org.BouncyCastle.Crypto.Parameters

Public Class LGU_PaymentInquiry
    Inherits System.Web.UI.Page
    Dim encoder As New UTF8Encoding
    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer()
    Private GCashDomain As String = "https://api.saas.mynt.xyz/"

    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader
    Private PublicKey_XML As String
    Private PrivateKey_XML As String
    Private PublicKey_PEM As String
    Private PrivateKey_PEM As String
    Private ClientId As String
    Private ClientSecret As String
    Private MerchantID As String
    Private ProductCode As String
    Private GCASH_PublicKey_PEM As String
    Private ReqMsgID As String
    Private GCASH_PubKey As String
    Private SPIDCREFNO As String

    Dim Q_acquirementStatus As String
    Public Q_TXNREFNO, Q_Status, Q_GateWayRefNo, Q_Security, Q_trxdate, Q_amount, Q_fee, Q_total, Q_statusID, Q_PaymentOption As String
    Public Q_JSON As String
    Public Q_acquirementId As String
    Public Q_merchantTransId As String
    Public Q_shortTransId As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCheck_ServerClick(sender As Object, e As EventArgs) Handles btnCheck.ServerClick
        Try
            PaymentInquiry()
        Catch ex As Exception

        End Try
    End Sub
    Sub lbp1()
        Try
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubGetGatewayCredentials("LBP1")
            Dim Hash As String = _nClass.GetHashMD5(cDalPayment.gw_MerchantCode & txt_MerchantRefNo.Value & cDalPayment.gw_SecretKey).ToLower()
            Dim URI As String
            If cDalPayment.gw_LIVE = True Then
                URI = cDalPayment.gw_ProdURL
            Else
                URI = cDalPayment.gw_TestURL
            End If
            Dim post_data As String = "?MerchantCode=" & cDalPayment.gw_MerchantCode &
                                  "&MerchantRefNo=" & txt_MerchantRefNo.Value &
                                  "&Hash=" & Hash
            Dim string_to_Post As String = URI & "api2-status.php" & post_data
            Dim client = New RestClient(string_to_Post)
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            Dim _response As IRestResponse = client.Execute(request)

            div_Result.InnerText = Nothing
            div_Result.InnerHtml += "URL : " & URI & "api2-status.php<br>"
            '   div_Result.InnerHtml += "Posted String : " & string_to_Post & "<br>"
            div_Result.InnerHtml += "MerchantCode : " & cDalPayment.gw_MerchantCode & "<br>"
            div_Result.InnerHtml += "MerchantRefNo : " & txt_MerchantRefNo.Value & "<br>"
            div_Result.InnerHtml += "SecretKey : " & cDalPayment.gw_SecretKey & "<br>"
            div_Result.InnerHtml += "Hash : " & Hash & "<br><br>"
            div_Result.InnerHtml += "Result : <br> " & _response.Content
        Catch ex As Exception
            err.Value += ex.Message
        End Try
    End Sub
   
    Sub PaymentInquiry()
        Try
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            Dim _nClass2 As New cDalPayment
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_CR

            Dim LBPDomain As String
            Dim Gateway As String = Nothing
            Dim str As String
            Dim strArr() As String
            Dim count As Integer
            str = txt_MerchantRefNo.InnerText
            strArr = str.Split(";")

            For count = 0 To strArr.Length - 1
                SPIDCREFNO = strArr(count)
                SPIDCREFNO = Replace(SPIDCREFNO, ";", "")
                Gateway = _nClass.Get_GateWayUsed(SPIDCREFNO)
                _nClass2._pSubGetGatewayCredentials(Gateway)
                Select Case Gateway
                    Case "GCASH"
                        SetCredentials()
                        Dim acquirementId As String
                        Dim shortTransId As String
                        Dim signature As String = "signature string"
                        _nClass.Get_GcashLog(SPIDCREFNO, acquirementId, shortTransId)
                        CreateQuery(SPIDCREFNO, shortTransId, acquirementId)

                    Case "LBP1"
                        _nClass2._pSubGetGatewayCredentials("LBP1")
                        Dim Hash As String = _nClass.GetHashMD5(cDalPayment.gw_MerchantCode & Trim(SPIDCREFNO).ToUpper & cDalPayment.gw_SecretKey).ToLower()
                        Dim URI As String
                        If cDalPayment.gw_LIVE = True Then
                            URI = cDalPayment.gw_ProdURL
                        Else
                            URI = cDalPayment.gw_TestURL
                        End If
                        Dim post_data As String = "?MerchantCode=" & cDalPayment.gw_MerchantCode &
                                                  "&MerchantRefNo=" & Trim(SPIDCREFNO).ToUpper &
                                                  "&Hash=" & Hash
                        Dim string_to_Post As String = URI & "api2-status.php" & post_data
                        Dim client = New RestClient(string_to_Post)
                        client.Timeout = -1
                        Dim request = New RestRequest(Method.POST)
                        Dim _response As IRestResponse = client.Execute(request)
                        Response.Write(_response.Content)

                        div_Result.InnerText = Nothing
                        div_Result.InnerHtml += "string_to_Post : " & string_to_Post & "<br>"
                        div_Result.InnerHtml += "MerchantCode : " & cDalPayment.gw_MerchantCode & "<br>"
                        div_Result.InnerHtml += "MerchantRefNo : " & Trim(SPIDCREFNO).ToUpper & "<br>"
                        div_Result.InnerHtml += "SecretKey : " & cDalPayment.gw_SecretKey & "<br>"
                        div_Result.InnerHtml += "Hash : " & Hash & "<br><br>"
                        div_Result.InnerHtml += "Result : <br> " & _response.Content
                      

                    Case "LBP2"
        If cDalPayment.gw_LIVE = True Then
            LBPDomain = cDalPayment.gw_ProdURL.Replace("postpayment", "inquirestatus")
        Else
            LBPDomain = cDalPayment.gw_TestURL.Replace("postpayment", "inquirestatus")
        End If
        Dim checksum As String = Nothing
        Dim username As String = cDalPayment.gw_UserName
        Dim password As String = cDalPayment.gw_Password
        Dim SecretKey As String = cDalPayment.gw_SecretKey

        checksum = cDalPayment.gw_MerchantCode & Nothing & SPIDCREFNO & username & password
        checksum = _nClass.GenerateSHA256String(checksum & SecretKey).ToUpper

        Dim post_data As String = "?merchantcode=" & cDalPayment.gw_MerchantCode &
                                  "&refnum=" & Nothing &
                                  "&trandetail1=" & SPIDCREFNO &
                                  "&checksum=" & checksum &
                                  "&username=" & username &
                                  "&password=" & password
        Dim string_to_Post As String = LBPDomain & post_data
        Dim client = New RestClient(string_to_Post)
        client.Timeout = -1
        Dim request = New RestRequest(Method.POST)
        Dim _response As IRestResponse = client.Execute(request)


        div_Result.InnerText = "Posted String <br/>" & string_to_Post &
                                "<br/><br/>" &
                                "Response String <br/>" & _response.Content

        Dim LBP_errDesc As String = Nothing
        Dim LBP_str As String = _response.Content
        Dim LBP_strArr() As String
        LBP_strArr = LBP_str.Split("|")
        _nClass._pSubGetEpsErrorCode(LBP_strArr(1), LBP_errDesc)
        If LBP_strArr(1) = "0000" Then
            _nClass._pSubUpdateOnlinePaymentInfo2("LBP2", SPIDCREFNO _
                    , LBP_errDesc _
                    , LBP_strArr(2) _
                    , LBP_strArr(4) _
                    , "SUCCESS")
        Else
            _nClass._pSubUpdateOnlinePaymentInfo2("LBP2", SPIDCREFNO _
                   , IIf(LBP_errDesc = Nothing, "Err: " & LBP_strArr(1), LBP_errDesc) _
                   , LBP_strArr(2) _
                   , LBP_strArr(4) _
                   , "FAILED")
        End If
        Dim LBP_ACCTNO As String
        _nClass._pSubGetACCTNO(SPIDCREFNO, LBP_ACCTNO)
        _nClass.LBP_EPS_InsertLog(string_to_Post, _response.Content, SPIDCREFNO, LBP_ACCTNO, _nClass.Get_Details("OnlinePaymentRefNo", "Type", "TXNREFNO", SPIDCREFNO))

                End Select

               
            Next
        Catch ex As Exception
            err.Value += ";do_Gcash : " & ex.Message
        End Try
    End Sub
   
    Public Function GenerateSHA256String(ByVal inputString) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function
    Function Do_Sign(ByVal StringToSign As String) As String
        Try
            Dim originalData As Byte() = encoder.GetBytes(StringToSign)
            Dim signedData As Byte()
            Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            Dim XML_PrivateKey As String = PrivateKey_XML
            rsa.FromXmlString(XML_PrivateKey)
            Dim key As RSAParameters = rsa.ExportParameters(True)
            signedData = HashAndSignBytes(originalData, key)
            Return Convert.ToBase64String(signedData)
        Catch ex As Exception

        End Try
    End Function
    Public Shared Function HashAndSignBytes(ByVal DataToSign As Byte(), ByVal Key As RSAParameters) As Byte()
        Try
            Dim RSAalg As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            RSAalg.ImportParameters(Key)
            Return RSAalg.SignData(DataToSign, SHA256.Create())
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
            Return Nothing
        End Try
    End Function
    Public Sub SetCredentials()
        Try
            Dim _nClass1 As New cDalGCash
            _nClass1._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass1.loadcredentials()
            ReqMsgID = _nClass1.Gen_MD5(SPIDCREFNO)
            PublicKey_XML = _nClass1._pPublicKey_XML
            PrivateKey_XML = _nClass1._pPrivateKey_XML
            PublicKey_PEM = _nClass1._pPublicKey_PEM
            PrivateKey_PEM = _nClass1._pPrivateKey_PEM
            ClientId = _nClass1._pClientId
            ClientSecret = _nClass1._pClientSecret
            MerchantID = _nClass1._pMerchantID
            Session("MerchantID") = _nClass1._pMerchantID
            ProductCode = _nClass1._pProductCode
            GCASH_PubKey = "-----BEGIN PUBLIC KEY-----" & vbCrLf & _nClass1._pGCASH_PublicKey_PEM & vbCrLf & "-----END PUBLIC KEY-----"
        Catch ex As Exception
            err.Value += ";SetCredentials : " & ex.Message
        End Try
       
    End Sub

    Sub CreateQuery(ByVal _merchantTransId As String, ByVal _shortTransId As String, ByVal _acquirementId As String)
        Try
            Dim objReq As New GCash_OrderQuery0.GCash_OrderQuery
            objReq.request = New GCash_OrderQuery0.Request()
            objReq.request.head = New GCash_OrderQuery0.Head()
            objReq.request.body = New GCash_OrderQuery0.Body()
            Dim _sqlDateNow As DateTime
            Dim _sqlDateNow10 As DateTime
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GetsqlDateNow(_sqlDateNow, _sqlDateNow10)

            'Head
            objReq.request.head.version = "2.0"
            objReq.request.head._function = "gcash.acquiring.order.query"
            objReq.request.head.clientId = ClientId
            objReq.request.head.clientSecret = ClientSecret
            objReq.request.head.reqTime = _sqlDateNow.ToString("yyyy-MM-dd'T'HH:mm:ssK")
            objReq.request.head.reqMsgId = ReqMsgID

            objReq.request.body.acquirementId = _acquirementId
            objReq.request.body.merchantTransId = _merchantTransId
            objReq.request.body.shortTransId = _shortTransId

            objReq.signature = "signature string"

            Dim client = New RestClient(GCashDomain)
            client.Timeout = -1
            Dim request = New RestRequest("gcash/acquiring/order/query.htm", Method.POST)
            Dim body = serializer.Serialize(objReq)

            body = body.Replace("_function", "function")

            Dim StringToSign As String = Nothing
            StringToSign = body.Remove(0, 11) ' Remove "request":
            StringToSign = StringToSign.Replace(",""signature"":""signature string""}", "")
            Dim signedString As String = Do_Sign(StringToSign)
            body = body.Replace("signature string", signedString)
            request.AddParameter("application/json", body, ParameterType.RequestBody)

            Dim _function As String = objReq.request.head._function
            Dim _transactionId As String = _shortTransId
            Dim _signature As String = signedString


            Dim response1 As IRestResponse = client.Execute(request)
            Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(response1.Content)

            div_Result.InnerText += "<br/><br/>" & body & "<br/><br/>" & response1.Content

            Dim Response_OriginalString
            Dim index As Integer = response1.Content.LastIndexOf(","c)
            Response_OriginalString = response1.Content.Remove(index)
            Response_OriginalString = Response_OriginalString.Remove(0, 12) ' Remove "response":

            err.Value += ";Response_OriginalString:" & Response_OriginalString

            ' If VerifySignature(Response_OriginalString, res("signature")) = True Then
            '  Try
            Q_acquirementStatus = res("response")("body")("statusDetail")("acquirementStatus")
            'err.Value += ";Q_acquirementStatus:" & Q_acquirementStatus
            '  Catch ex As Exception
            '      err.Value += ";Q_acquirementStatus: " & ex.Message
            '   End Try

            '  Try
            Q_Security = res("response")("body")("acquirementId")
            'err.Value += ";Q_Security: " & Q_Security
            ' Catch ex As Exception
            '      err.Value += ";Q_Security: " & ex.Message
            '  End Try

            '   Try
            Q_GateWayRefNo = res("response")("body")("transactionId")
            'err.Value += ";Q_GateWayRefNo: " & Q_GateWayRefNo
            '  Catch ex As Exception
            '      err.Value += ";Q_GateWayRefNo: " & ex.Message
            '  End Try



            'SAVE REQUEST FROM SPIDC
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GCASH_InsertLog(_function, _transactionId, _merchantTransId, body, "Request from SPIDC", _acquirementId, _signature)

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubUpdateOnlinePaymentInfo2("GCASH", SPIDCREFNO _
                , Q_acquirementStatus _
                , Q_GateWayRefNo _
                , Q_Security _
                , Q_acquirementStatus)

            body = response1.Content
            _function = res("response")("head")("function")
            _transactionId = res("response")("body")("transactionId")
            _merchantTransId = res("response")("body")("merchantTransId")
            _acquirementId = res("response")("body")("acquirementId")
            _signature = res("signature")

            'SAVE RESPONSE FROM GCASH
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GCASH_InsertLog(_function, _transactionId, _merchantTransId, body, "Response from GCASH", _acquirementId, _signature)
            Exit Sub
            '   Else
            '   err.Value += ";VerifySignature: False"
            '    End If

        Catch ex As Exception
            err.Value += ";CreateQuery:" & ex.Message
        End Try

    End Sub
    Sub WriteLogs(ByVal _function As String, ByVal _Type As String, ByVal _JSON As String)
        Response.Write("<table style='border-collapse: collapse;width: 800px;'>")
        Response.Write("<tr>")
        Response.Write("<th style='border: 1px solid #ddd;padding: 8px;text-align: left;background-color: gray;color: white;'>")
        Response.Write(_function & " : " & _Type)
        Response.Write("</th>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td style='border: 1px solid #ddd;padding: 8px;'>")
        Response.Write(_JSON)
        Response.Write("</th>")
        Response.Write("</tr>")
        Response.Write("</table>")
        Response.Write("</br></br>")
        Response.Write("<script>")
        Response.Write("console.log('" & _function & " : " & _Type & "')")
        Response.Write("console.log('" & _JSON & "')")
        Response.Write("</script>")


    End Sub


    Function VerifySignature(ByVal OriginalString As String, ByVal SignedString As String) As Boolean
        Try
            Dim initialProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            Dim privateKey As String = ExportPrivateKey(initialProvider)
            Dim publicKey As String = ExportPublicKey(initialProvider)

            Dim importedProvider As RSACryptoServiceProvider = ImportPublicKey(GCASH_PubKey)
            publicKey = ExportPublicKey(importedProvider)

            Dim pubKey As RSAParameters = importedProvider.ExportParameters(False)

            Dim encoder = New UTF8Encoding()
            Dim bytesToVerify As Byte() = encoder.GetBytes(OriginalString)
            Dim signedBytes As Byte() = Convert.FromBase64String(SignedString)

            Return importedProvider.VerifyData(bytesToVerify, SHA256.Create(), signedBytes)


        Catch ex As Exception

        End Try
    End Function

    Public Shared Function ExportPrivateKey(ByVal csp As RSACryptoServiceProvider) As String
        Dim outputStream As StringWriter = New StringWriter()
        If csp.PublicOnly Then Throw New ArgumentException("CSP does not contain a private key", "csp")
        Dim parameters = csp.ExportParameters(True)

        Using stream = New MemoryStream()
            Dim writer = New BinaryWriter(stream)
            writer.Write(CByte(&H30))

            Using innerStream = New MemoryStream()
                Dim innerWriter = New BinaryWriter(innerStream)
                EncodeIntegerBigEndian(innerWriter, New Byte() {&H0})
                EncodeIntegerBigEndian(innerWriter, parameters.Modulus)
                EncodeIntegerBigEndian(innerWriter, parameters.Exponent)
                EncodeIntegerBigEndian(innerWriter, parameters.D)
                EncodeIntegerBigEndian(innerWriter, parameters.P)
                EncodeIntegerBigEndian(innerWriter, parameters.Q)
                EncodeIntegerBigEndian(innerWriter, parameters.DP)
                EncodeIntegerBigEndian(innerWriter, parameters.DQ)
                EncodeIntegerBigEndian(innerWriter, parameters.InverseQ)
                Dim length = CInt(innerStream.Length)
                EncodeLength(writer, length)
                writer.Write(innerStream.GetBuffer(), 0, length)
            End Using

            Dim base64 = Convert.ToBase64String(stream.GetBuffer(), 0, CInt(stream.Length)).ToCharArray()
            outputStream.Write("-----BEGIN RSA PRIVATE KEY-----" & vbLf)

            For i = 0 To base64.Length - 1 Step 64
                outputStream.Write(base64, i, Math.Min(64, base64.Length - i))
                outputStream.Write(vbLf)
            Next

            outputStream.Write("-----END RSA PRIVATE KEY-----")
        End Using

        Return outputStream.ToString()
    End Function

    Private Shared Sub EncodeIntegerBigEndian(ByVal stream As BinaryWriter, ByVal value As Byte(), Optional ByVal forceUnsigned As Boolean = True)
        stream.Write(CByte(&H2))
        Dim prefixZeros = 0

        For i = 0 To value.Length - 1
            If value(i) <> 0 Then Exit For
            prefixZeros += 1
        Next

        If value.Length - prefixZeros = 0 Then
            EncodeLength(stream, 1)
            stream.Write(CByte(0))
        Else

            If forceUnsigned AndAlso value(prefixZeros) > &H7F Then
                EncodeLength(stream, value.Length - prefixZeros + 1)
                stream.Write(CByte(0))
            Else
                EncodeLength(stream, value.Length - prefixZeros)
            End If

            For i = prefixZeros To value.Length - 1
                stream.Write(value(i))
            Next
        End If
    End Sub

    Private Shared Sub EncodeLength(ByVal stream As BinaryWriter, ByVal length As Integer)
        If length < 0 Then Throw New ArgumentOutOfRangeException("length", "Length must be non-negative")

        If length < &H80 Then
            stream.Write(CByte(length))
        Else
            Dim temp = length
            Dim bytesRequired = 0

            While temp > 0
                temp >>= 8
                bytesRequired += 1
            End While

            stream.Write(CByte((bytesRequired Or &H80)))

            For i = bytesRequired - 1 To 0
                stream.Write(CByte((length >> (8 * i) & &HFF)))
            Next
        End If
    End Sub

    Public Shared Function ExportPublicKey(ByVal csp As RSACryptoServiceProvider) As String
        Dim outputStream As StringWriter = New StringWriter()
        Dim parameters = csp.ExportParameters(False)

        Using stream = New MemoryStream()
            Dim writer = New BinaryWriter(stream)
            writer.Write(CByte(&H30))

            Using innerStream = New MemoryStream()
                Dim innerWriter = New BinaryWriter(innerStream)
                innerWriter.Write(CByte(&H30))
                EncodeLength(innerWriter, 13)
                innerWriter.Write(CByte(&H6))
                Dim rsaEncryptionOid = New Byte() {&H2A, &H86, &H48, &H86, &HF7, &HD, &H1, &H1, &H1}
                EncodeLength(innerWriter, rsaEncryptionOid.Length)
                innerWriter.Write(rsaEncryptionOid)
                innerWriter.Write(CByte(&H5))
                EncodeLength(innerWriter, 0)
                innerWriter.Write(CByte(&H3))

                Using bitStringStream = New MemoryStream()
                    Dim bitStringWriter = New BinaryWriter(bitStringStream)
                    bitStringWriter.Write(CByte(&H0))
                    bitStringWriter.Write(CByte(&H30))

                    Using paramsStream = New MemoryStream()
                        Dim paramsWriter = New BinaryWriter(paramsStream)
                        EncodeIntegerBigEndian(paramsWriter, parameters.Modulus)
                        EncodeIntegerBigEndian(paramsWriter, parameters.Exponent)
                        Dim paramsLength = CInt(paramsStream.Length)
                        EncodeLength(bitStringWriter, paramsLength)
                        bitStringWriter.Write(paramsStream.GetBuffer(), 0, paramsLength)
                    End Using

                    Dim bitStringLength = CInt(bitStringStream.Length)
                    EncodeLength(innerWriter, bitStringLength)
                    innerWriter.Write(bitStringStream.GetBuffer(), 0, bitStringLength)
                End Using

                Dim length = CInt(innerStream.Length)
                EncodeLength(writer, length)
                writer.Write(innerStream.GetBuffer(), 0, length)
            End Using

            Dim base64 = Convert.ToBase64String(stream.GetBuffer(), 0, CInt(stream.Length)).ToCharArray()
            outputStream.Write("-----BEGIN PUBLIC KEY-----" & vbLf)

            For i = 0 To base64.Length - 1 Step 64
                outputStream.Write(base64, i, Math.Min(64, base64.Length - i))
                outputStream.Write(vbLf)
            Next

            outputStream.Write("-----END PUBLIC KEY-----")
        End Using

        Return outputStream.ToString()
    End Function

    Public Shared Function ImportPublicKey(ByVal pem As String) As RSACryptoServiceProvider
        Dim pr As PemReader = New PemReader(New StringReader(pem))
        Dim publicKey As AsymmetricKeyParameter = CType(pr.ReadObject(), AsymmetricKeyParameter)
        Dim rsaParams As RSAParameters = DotNetUtilities.ToRSAParameters(CType(publicKey, RsaKeyParameters))
        Dim csp As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        csp.ImportParameters(rsaParams)
        Return csp
    End Function
End Class