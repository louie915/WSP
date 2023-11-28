Imports RestSharp
Imports System.Security.Cryptography
Imports System.Web.Script.Serialization
Imports Org.BouncyCastle.OpenSsl
Imports System.IO
Imports Org.BouncyCastle.Crypto
Imports Org.BouncyCastle.Security
Imports Org.BouncyCastle.Crypto.Parameters

Public Class Gcash_Checker
    Inherits System.Web.UI.Page
    Dim encoder As New UTF8Encoding
    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer()
    Public Shared GCashDomain As String = "https://api.saas.mynt.xyz/"
    '"https://api-sit.saas.mynt.xyz/"
    Dim GCASH_PubKey As String '= "-----BEGIN PUBLIC KEY-----" & vbCrLf & "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAgo22hZx9N2EXHh8ZspL/iHYcuL1tSdQ974nTkJHRlKRWNzyQqO6TSYouY+nA0y/WD2Pz2wwKwTDBFW82DNekYgFeKZ2bCrsG3Twi7tn3DbfFGKzXfBzXYv6sggL/1Ej2/ABzMVWIaAo8t9Wo5A+/12nOLQIwxsHXZTUrbCJeZYUAfRQFLyIp2/PxVeVd0bLhtEAAj8aJq8RlSlPYdUIgk+CJ+WVdUs7rhMd09MArgAFwB3iRPbBS4gf7QEswRaBDQ3fTJIYE6xTr53geuv9MAO6B2x0Qt0ctmrdGtjLdsoq2KWmlPXo/GS6uJadwQ+xR9JbudS4eZYKNYTf6zGsvVwIDAQAB" & vbCrLf & "-----END PUBLIC KEY-----"
    Public Shared PayorEmail As String 'taxpayer@spidc.com.ph
    Public Shared SPIDCRefNo As String 'txnrefno
    Public Shared Amount As Double '1000.00
    Public Shared ACCTNO As String 'BPLTAS ACCTNO
    Public Shared TransType As String 'BP,RPT,CTC
    Public Shared PaymentDesc As String 'BP Renewal, BP New    

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

    Dim Q_acquirementStatus As String

    Public Q_TXNREFNO, Q_Status, Q_GateWayRefNo, Q_Security, Q_trxdate, Q_amount, Q_fee, Q_total, Q_statusID, Q_PaymentOption As String
    Public Q_JSON As String
    Public Q_acquirementId As String
    Public Q_merchantTransId As String
    Public Q_shortTransId As String

    Public sw_Query As Stopwatch
    Public sw_Cancel As Stopwatch

    Public Request_JSON As String
    Public Response_JSON As String

    Dim Query_startTime As DateTime
    Dim Query_endTime As DateTime

    Dim _sqlDateNow As DateTime
    Dim _sqlDateNow10 As DateTime
    Dim AStatus As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'START ORDER QUERY Continuously      
        Timer1.Interval = 2000
        Timer1.Enabled = True
    End Sub
    Protected Sub Timer1_Tick(sender As Object, e As EventArgs)
        Dim err As String

        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass.GetsqlDateNow(_sqlDateNow, _sqlDateNow10)

        If Session("acquirementStatus") = "SUCCESS" Or Session("acquirementStatus") = "CLOSED" Then
            Timer1.Enabled = False
            Response.Redirect("Account.aspx")
        ElseIf _sqlDateNow > CDate(Session("EndDate")) Then
            OrderCancel(Session("acquirementId"), Session("MerchantID"), err)
            Timer1.Enabled = False
            Response.Redirect("Account.aspx")
        Else
            CreateQuery(Session("merchantTransId"), Session("shortTransId"), Session("acquirementId"))
        End If

    End Sub
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

    Sub OrderCancel(ByVal _acquirementId As String, ByVal _merchantId As String, ByRef Err As String)
        Try
            Dim objReq As New GCash_OrderCancel.Gcash_OrderCancel
            objReq.request = New GCash_OrderCancel.Request()
            objReq.request.head = New GCash_OrderCancel.Head()
            objReq.request.body = New GCash_OrderCancel.Body()

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GetsqlDateNow(_sqlDateNow, _sqlDateNow10)
            'Head
            objReq.request.head.version = "2.0"
            objReq.request.head._function = "gcash.acquiring.order.cancel"
            objReq.request.head.clientId = ClientId
            objReq.request.head.clientSecret = ClientSecret
            objReq.request.head.reqMsgId = SPIDCRefNo & "-" & ReqMsgID
            objReq.request.head.reqTime = _sqlDateNow.ToString("yyyy-MM-dd'T'HH:mm:ssK")



            objReq.request.body.acquirementId = _acquirementId
            objReq.request.body.merchantId = _merchantId

            objReq.signature = "signature string"

            Dim client = New RestClient(GCashDomain)
            client.Timeout = -1
            Dim request = New RestRequest("gcash/acquiring/order/cancel.htm", Method.POST)
            Dim body = serializer.Serialize(objReq)

            body = body.Replace("_function", "function")

            Dim StringToSign As String = Nothing
            StringToSign = body.Remove(0, 11) ' Remove "request":
            StringToSign = StringToSign.Replace(",""signature"":""signature string""}", "")
            Dim signedString As String = Do_Sign(StringToSign)
            body = body.Replace("signature string", signedString)
            request.AddParameter("application/json", body, ParameterType.RequestBody)

            Dim _function As String = objReq.request.head._function
            Dim _signature As String = signedString


            Request_JSON = body
            'SAVE REQUEST FROM SPIDC
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GCASH_InsertLog(_function, "_transactionId", "_merchantTransId", body, "Request from SPIDC", _acquirementId, _signature)

            Dim response1 As IRestResponse = client.Execute(request)
            Dim Response_OriginalString
            Dim index As Integer = response1.Content.LastIndexOf(","c)
            Response_OriginalString = response1.Content.Remove(index)
            Response_OriginalString = Response_OriginalString.Remove(0, 12) ' Remove "response":
            Response_JSON = response1.Content
            Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(response1.Content)

            If VerifySignature(Response_OriginalString, res("signature")) = True Then
                _function = res("response")("head")("function")
                Dim _merchantTransId As String = res("response")("body")("merchantTransId")
                _acquirementId = res("response")("body")("acquirementId")
                _signature = res("signature")

                'SAVE RESPONSE FROM GCASH
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass.GCASH_InsertLog(_function, "_transactionId", _merchantTransId, Response_JSON, "Response from GCASH", _acquirementId, _signature)
            End If


            WriteLogs("gcash.acquiring.order.cancel", "REQUEST", Request_JSON)
            WriteLogs("gcash.acquiring.order.cancel", "RESPONSE", Response_JSON)

            Err = Nothing
        Catch ex As Exception
            Err = ex.Message

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
    Public Shared Function ImportPublicKey(ByVal pem As String) As RSACryptoServiceProvider
        Dim pr As PemReader = New PemReader(New StringReader(pem))
        Dim publicKey As AsymmetricKeyParameter = CType(pr.ReadObject(), AsymmetricKeyParameter)
        Dim rsaParams As RSAParameters = DotNetUtilities.ToRSAParameters(CType(publicKey, RsaKeyParameters))
        Dim csp As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        csp.ImportParameters(rsaParams)
        Return csp
    End Function
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
            objReq.request.head.reqMsgId = SPIDCRefNo & "-" & ReqMsgID

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

            Dim Response_OriginalString
            Dim index As Integer = response1.Content.LastIndexOf(","c)
            Response_OriginalString = response1.Content.Remove(index)
            Response_OriginalString = Response_OriginalString.Remove(0, 12) ' Remove "response":

            If VerifySignature(Response_OriginalString, res("signature")) = True Then
                Q_acquirementStatus = res("response")("body")("statusDetail")("acquirementStatus")
                Session("acquirementStatus") = Q_acquirementStatus
                If Q_acquirementStatus = "SUCCESS" Or Q_acquirementStatus = "CLOSED" Then

                    'SAVE REQUEST FROM SPIDC
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    _nClass.GCASH_InsertLog(_function, _transactionId, _merchantTransId, body, "Request from SPIDC", _acquirementId, _signature)

                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    _nClass._pSubUpdateOnlinePaymentInfo(SPIDCRefNo _
                        , Q_Status _
                        , Q_GateWayRefNo _
                        , Q_Security _
                        , Q_trxdate _
                        , _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", SPIDCRefNo) _
                        , _nClass.Get_PaymentDetails("feeAmount", "TXNREFNO", SPIDCRefNo) _
                        , _nClass.Get_PaymentDetails("TotAmount", "TXNREFNO", SPIDCRefNo) _
                        , Q_statusID _
                        , "GCASH")

                    WriteLogs(_function, "REQUEST", body)
                    WriteLogs(_function, "RESPONSE", response1.Content)

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
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class