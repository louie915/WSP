Imports Org.BouncyCastle.Crypto
Imports Org.BouncyCastle.Crypto.Parameters
Imports Org.BouncyCastle.OpenSsl
Imports Org.BouncyCastle.Security
Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports Org.BouncyCastle.Asn1.X509
Imports Org.BouncyCastle.Asn1.Pkcs
Imports Org.BouncyCastle.Pkcs
Imports Org.BouncyCastle.X509
Imports RestSharp
Imports System.Web.Script.Serialization
Imports System.Net
Imports Newtonsoft.Json


Public Class TestGcash
    Inherits System.Web.UI.Page




    Dim rsa As RSACryptoServiceProvider
    Dim textbytes, encryptedtextbytes As Byte()
    Dim encoder As New UTF8Encoding
    Private Shared RSA_OID As Byte() = {&H30, &HD, &H6, &H9, &H2A, &H86, &H48, &H86, &HF7, &HD, &H1, &H1, &H1, &H5, &H0}
    Const _INTEGER As Byte = &H2
    Const SEQUENCE As Byte = &H30
    Const BIT_STRING As Byte = &H3
    Const OCTET_STRING As Byte = &H4

    Const PrivateHeader As String = "-----BEGIN RSA PRIVATE KEY-----"
    Const PrivateFooter As String = "-----END RSA PRIVATE KEY-----"
    Const PublicHeader As String = "-----BEGIN PUBLIC KEY-----"
    Const PublicFooter As String = "-----END PUBLIC KEY-----"



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '   If Not IsPostBack Then

        'txtPubKey.InnerText += "-----BEGIN PUBLIC KEY-----"
        'txtPubKey.InnerText += vbNewLine
        'txtPubKey.InnerText += FormatPEMString(ConvertPublicKey(paramPub))
        'txtPubKey.InnerText += vbNewLine
        'txtPubKey.InnerText += "-----END PUBLIC KEY-----"

        'txtPriKey.InnerText += "-----BEGIN RSA PRIVATE KEY-----"
        'txtPriKey.InnerText += vbNewLine
        'txtPriKey.InnerText += FormatPEMString(ConvertPrivateKey(paramPri))
        'txtPriKey.InnerText += vbNewLine
        'txtPriKey.InnerText += "-----END RSA PRIVATE KEY-----"

        '---ENCRYPT PLAIN TEXT
        ' Dim TexttoEncrypt As String = _
        ' """head"":{""" & _
        '         """clientID"":""17268739123""," & _
        '         """reqTime"":""2001-07-04T12:08:56+05:30""," & _
        '         """reqMsgId"":""2183979123asd21312""," & _
        '         """clientSecret"":""123215324dsafniuewriwruw""" & _
        ' "}"


        ' & _
        '  """body"":{""" & _
        '         """merchantId"":""123456789012345678901""," & _
        '         """merchantTransId"":""1237621321984y87fdadqw""" & _
        ' "}"
        '  Dim RSA As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
        '  txtPriKey.InnerText = RSA.ToXmlString(True)

        ''textbytes = Encoder.GetBytes(TexttoEncrypt)
        ''encryptedtextbytes = rsa.Encrypt(textbytes, True)
        ''EncryptResult.InnerText = Convert.ToBase64String(encryptedtextbytes)

        ''---DECRYPT PLAIN TEXT
        ''textbytes = rsa.Decrypt(encryptedtextbytes, True)
        ''DecryptResult.InnerText = Encoder.GetString(textbytes)

        '  rsa = New RSACryptoServiceProvider(2048)
        '  rsa.
        ' txtPubKey.InnerText = rsa.ToXmlString(False)
        ' txtPriKey.InnerText = rsa.ToXmlString(True)

        ' Dim RSA As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
        '   ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        '  xxx()

    End Sub
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
    Public Shared Function VerifySignedHash(ByVal DataToVerify As Byte(), ByVal SignedData As Byte(), ByVal Key As RSAParameters) As Boolean
        Try
            Dim RSAalg As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            RSAalg.ImportParameters(Key)
            Return RSAalg.VerifyData(DataToVerify, SHA256.Create(), SignedData)
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
            Return False
        End Try
    End Function
    Private Shared Function FormatPEMString(ByVal key As String) As String
        Dim sb As System.Text.StringBuilder = New StringBuilder(key)

        For [loop] As Integer = 64 To key.Length - 1 Step 65
            sb.Insert([loop], vbLf)
        Next
        Return sb.ToString()
    End Function
    Function ConvertPrivateKey(ByVal param As RSAParameters) As String
        Dim arrBinaryPrivateKey As List(Of Byte) = New List(Of Byte)()
        arrBinaryPrivateKey.InsertRange(0, param.InverseQ)
        AppendLength(arrBinaryPrivateKey, param.InverseQ.Length)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        arrBinaryPrivateKey.InsertRange(0, param.DQ)
        AppendLength(arrBinaryPrivateKey, param.DQ.Length)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        arrBinaryPrivateKey.InsertRange(0, param.DP)
        AppendLength(arrBinaryPrivateKey, param.DP.Length)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        arrBinaryPrivateKey.InsertRange(0, param.Q)
        AppendLength(arrBinaryPrivateKey, param.Q.Length)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        arrBinaryPrivateKey.InsertRange(0, param.P)
        AppendLength(arrBinaryPrivateKey, param.P.Length)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        arrBinaryPrivateKey.InsertRange(0, param.D)
        AppendLength(arrBinaryPrivateKey, param.D.Length)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        arrBinaryPrivateKey.InsertRange(0, param.Exponent)
        AppendLength(arrBinaryPrivateKey, param.Exponent.Length)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        arrBinaryPrivateKey.InsertRange(0, param.Modulus)
        AppendLength(arrBinaryPrivateKey, param.Modulus.Length)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        arrBinaryPrivateKey.Insert(0, &H0)
        AppendLength(arrBinaryPrivateKey, 1)
        arrBinaryPrivateKey.Insert(0, _INTEGER)
        AppendLength(arrBinaryPrivateKey, arrBinaryPrivateKey.Count)
        arrBinaryPrivateKey.Insert(0, SEQUENCE)
        Return System.Convert.ToBase64String(arrBinaryPrivateKey.ToArray())
    End Function
    Function ConvertPublicKey(ByVal param As RSAParameters) As String
        Dim arrBinaryPublicKey As List(Of Byte) = New List(Of Byte)()
        arrBinaryPublicKey.InsertRange(0, param.Exponent)
        arrBinaryPublicKey.Insert(0, CByte(arrBinaryPublicKey.Count))
        arrBinaryPublicKey.Insert(0, _INTEGER)
        arrBinaryPublicKey.InsertRange(0, param.Modulus)
        AppendLength(arrBinaryPublicKey, param.Modulus.Length)
        arrBinaryPublicKey.Insert(0, _INTEGER)
        AppendLength(arrBinaryPublicKey, arrBinaryPublicKey.Count)
        arrBinaryPublicKey.Insert(0, SEQUENCE)
        arrBinaryPublicKey.Insert(0, &H0)
        AppendLength(arrBinaryPublicKey, arrBinaryPublicKey.Count)
        arrBinaryPublicKey.Insert(0, BIT_STRING)
        arrBinaryPublicKey.InsertRange(0, RSA_OID)
        AppendLength(arrBinaryPublicKey, arrBinaryPublicKey.Count)
        arrBinaryPublicKey.Insert(0, SEQUENCE)
        Return System.Convert.ToBase64String(arrBinaryPublicKey.ToArray())
    End Function
    Sub AppendLength(ByRef arrBinaryData As List(Of Byte), ByVal nLen As Integer)
        If nLen <= Byte.MaxValue Then
            arrBinaryData.Insert(0, Convert.ToByte(nLen))
            arrBinaryData.Insert(0, &H81)
        Else
            arrBinaryData.Insert(0, Convert.ToByte(nLen Mod (Byte.MaxValue + 1)))
            arrBinaryData.Insert(0, Convert.ToByte(nLen / (Byte.MaxValue + 1)))
            arrBinaryData.Insert(0, &H82)
        End If
    End Sub
    Function Enrcypt(ByVal Data As Byte(), ByVal PublicKeyln As String) As Byte()
        RSA.FromXmlString(PublicKeyln)
        '  rsa.
        Return RSA.Encrypt(Data, False)
    End Function
    Private Sub btnGenerateKey_ServerClick(sender As Object, e As EventArgs) Handles btnGenerateKey.ServerClick
        Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)

        td_PublicKey.InnerText = rsa.ToXmlString(False)
        td_PrivateKey.InnerText = rsa.ToXmlString(True)

        ' Dim parameters = rsa.ExportParameters(False)
        '
        ' td_PublicKey.InnerText += PublicHeader
        ' td_PublicKey.InnerText += vbNewLine
        ' td_PublicKey.InnerText += FormatPEMString(ConvertPublicKey(Parameters))
        ' td_PublicKey.InnerText += vbNewLine
        ' td_PublicKey.InnerText += PublicFooter

        '
        '  td_PublicKey.InnerText = ExportPublicKey(rsa)
        '  td_PrivateKey.InnerText = ExportPrivateKey(rsa)
        '  
    End Sub
    Private Sub btnSign_ServerClick(sender As Object, e As EventArgs) Handles btnSign.ServerClick
        Try
            Dim dataString As String = td_Message.InnerText
            Dim originalData As Byte() = Encoder.GetBytes(dataString)
            Dim signedData As Byte()

            Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)

            '  Using privateKeyTextReader As TextReader = New StringReader(td_PrivateKey2.InnerText)
            '      Dim readKeyPair As AsymmetricCipherKeyPair = CType(New PemReader(privateKeyTextReader).ReadObject(), AsymmetricCipherKeyPair)
            '      Dim rsaParams As RSAParameters = DotNetUtilities.ToRSAParameters(CType(readKeyPair.[Private], RsaPrivateCrtKeyParameters))
            '      rsa.ImportParameters(rsaParams)
            '  End Using

            rsa.FromXmlString(td_PrivateKey2.InnerText)
            '  rsa = ImportPrivateKey(td_PrivateKey2.InnerText)
            Dim key As RSAParameters = rsa.ExportParameters(True)

            signedData = HashAndSignBytes(originalData, key)
            td_SignedMessage.InnerText = Convert.ToBase64String(signedData) 'encoder.GetString(signedData)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnVerify_ServerClick(sender As Object, e As EventArgs) Handles btnVerify.ServerClick
        Try
            Dim initialProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            Dim privateKey As String = ExportPrivateKey(initialProvider)
            Dim publicKey As String = ExportPublicKey(initialProvider)

            Dim importedProvider As RSACryptoServiceProvider = ImportPublicKey(td_PublicKey2.InnerText)
            '    privateKey = ExportPrivateKey(importedProvider)
            publicKey = ExportPublicKey(importedProvider)

            Dim pubKey As RSAParameters = importedProvider.ExportParameters(False)

            Dim encoder = New UTF8Encoding()
            Dim bytesToVerify As Byte() = encoder.GetBytes(td_Message2.InnerText)
            Dim signedBytes As Byte() = Convert.FromBase64String(td_SignedMessage2.InnerText)

            td_VerificationResult.InnerHtml = importedProvider.VerifyData(bytesToVerify, SHA256.Create(), signedBytes)


        Catch ex As Exception

        End Try
    End Sub
    Private Function GetIntegerSize(ByVal binr As BinaryReader) As Integer
        Dim bt As Byte = 0
        Dim lowbyte As Byte = &H0
        Dim highbyte As Byte = &H0
        Dim count As Integer = 0
        bt = binr.ReadByte()
        If bt <> &H2 Then Return 0
        bt = binr.ReadByte()

        If bt = &H81 Then
            count = binr.ReadByte()
        ElseIf bt = &H82 Then
            highbyte = binr.ReadByte()
            lowbyte = binr.ReadByte()
            Dim modint As Byte() = {lowbyte, highbyte, &H0, &H0}
            count = BitConverter.ToInt32(modint, 0)
        Else
            count = bt
        End If

        While binr.ReadByte() = &H0
            count -= 1
        End While

        binr.BaseStream.Seek(-1, SeekOrigin.Current)
        Return count
    End Function
    Private Sub btnProcess_ServerClick(sender As Object, e As EventArgs) Handles btnProcess.ServerClick
        Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
        rsa.FromXmlString(td_PrivateKey0.InnerText)
        Dim parameters = rsa.ExportParameters(False)
        td_Result0.InnerText += PublicHeader
        td_Result0.InnerText += vbNewLine
        td_Result0.InnerText += FormatPEMString(ConvertPublicKey(parameters))
        td_Result0.InnerText += vbNewLine
        td_Result0.InnerText += PublicFooter

        ' td_Result0.InnerText = ExportPublicKey(rsa)
        '   rsa = ImportPrivateKey(td_PrivateKey0.InnerText)
        '   td_Result0.InnerText += ExportPublicKey(rsa) & vbNewLine & vbNewLine
        '   td_Result0.InnerText += ExportPrivateKey(rsa) & vbNewLine & vbNewLine
        '   td_Result0.InnerText += vbNewLine & vbNewLine
        '   td_Result0.InnerText += vbNewLine & vbNewLine

        Dim dataString As String = td_Message0.InnerText
        Dim originalData As Byte() = Encoder.GetBytes(dataString)
        Dim signedData As Byte()
        '   
        '   Dim strPub As String = ExportPublicKey(rsa)
        '   Dim strPri As String = ExportPrivateKey(rsa)
        '
        '   'rsaPub = ImportPublicKey(strPub)
        '   rsaPri = ImportPrivateKey(strPri)
        '
        Dim Pubkey As RSAParameters = rsa.ExportParameters(False)
        Dim Prikey As RSAParameters = rsa.ExportParameters(True)
        '
        signedData = HashAndSignBytes(originalData, Prikey)
        td_SignedMessage.InnerText = Convert.ToBase64String(signedData)
        '
        '   td_Result0.InnerHtml += "Public Key" & vbNewLine & ConvertPublicKey(Prikey)
        '   td_Result0.InnerHtml += vbNewLine & vbNewLine & "Private Key" & vbNewLine & ConvertPrivateKey(Prikey)
        td_Result0.InnerHtml += vbNewLine & vbNewLine & "Signed Data (Base64)" & vbNewLine & Convert.ToBase64String(signedData)
        '
        '
        If VerifySignedHash(originalData, signedData, Pubkey) Then
            td_Result0.InnerHtml += vbNewLine & vbNewLine & "The data was verified."
        Else
            td_Result0.InnerHtml += vbNewLine & vbNewLine & "The data does not match the signature."
        End If
        '   VerifySignature("testing mo to ")

    End Sub
    Function ImportPrivateKey(ByVal pem As String) As RSACryptoServiceProvider
        Dim pr As PemReader = New PemReader(New StringReader(pem))
        Dim KeyPair As AsymmetricCipherKeyPair = CType(pr.ReadObject(), AsymmetricCipherKeyPair)
        Dim rsaParams As RSAParameters = DotNetUtilities.ToRSAParameters(CType(KeyPair.[Private], RsaPrivateCrtKeyParameters))
        Dim csp As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        csp.ImportParameters(rsaParams)
        Return csp
    End Function
    Public Shared Function ImportPublicKey(ByVal pem As String) As RSACryptoServiceProvider
        Dim pr As PemReader = New PemReader(New StringReader(pem))
        Dim publicKey As AsymmetricKeyParameter = CType(pr.ReadObject(), AsymmetricKeyParameter)
        Dim rsaParams As RSAParameters = DotNetUtilities.ToRSAParameters(CType(publicKey, RsaKeyParameters))
        Dim csp As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        csp.ImportParameters(rsaParams)
        Return csp
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


    Sub xxx()
        Dim StringToSign As String =
            "{""head"":{" & _
                    """reqTime"":""2022-03-04T12:08:56-07:00""," & _
                    """reqMsgId"":""SPIDC00011""," & _
                    """clientSecret"":""2022013110514600022414fnVlwL""," & _
                    """clientId"":""2022013110514600022414""," & _
                    """function"":""gcash.acquiring.order.create""," & _
                    """version"":""2.0""" & _
            "}," & _
                """body"":{" & _
                    """envInfo"":{" & _
                        """terminalType"":""WAP""," & _
                        """orderTerminalType"":""WAP""" & _
                    "}," & _
                    """order"":{" & _
                        """orderTitle"":""ProductTest""," & _
                        """merchantTransId"":""SPIDC-030422-00011""," & _
                        """createdTime"":""2022-03-04T12:08:56-07:00""," & _
                        """orderAmount"":{" & _
                            """currency"":""PHP""," & _
                            """value"":""1900""}," & _
                            """expirytime"":""""," & _
                            """buyer"":{" & _
                                """externalUserId"":""1001""," & _
                                """externalUserType"":""TESTSELLER""," & _
                                """userId"":""""" & _
                                "}," & _
                            """seller"":{" & _
                                """externalUserId"":""1001""," & _
                                """externalUserType"":""TESTSELLER""," & _
                                """userId"":""""}" & _
                        "}," & _
                        """productCode"":""51051000101000100001""," & _
                        """merchantId"":""217020000647829935953""," & _
                        """subMerchantId"":""abcd""," & _
                        """subMerchantName"":""merchant""," & _
                        """notificationUrls"":[{" & _
                            """type"":""PAY_RETURN""," & _
                            """url"":""https://www.yahoo.com/""}," & _
                            "{" & _
                            """type"":""CANCEL_RETURN""," & _
                            """url"":""https://www.yahoo.com/""}," & _
                            "{" & _
                            """type"":""NOTIFICATION""," & _
                            """url"":""https://www.yahoo.com/""}]}}"


        Dim client = New RestClient("https://api-sit.saas.mynt.xyz/gcash/acquiring/order/create.htm")
        client.Timeout = -1
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "application/json")
        Dim body = "{" & _
             """request"": " & StringToSign & "," & _
              """signature"": """ & Do_Sign(StringToSign) & """}"
        request.AddParameter("application/json", body, ParameterType.RequestBody)
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX.Content)
        Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(responseX.Content)
        Response.Write(res("id"))
        Response.Redirect(res("response")("body")("checkoutUrl"))
    End Sub

    Function Do_Sign(ByVal StringToSign As String) As String
        Try
            Dim originalData As Byte() = Encoder.GetBytes(StringToSign)
            Dim signedData As Byte()
            Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            Dim XML_PrivateKey As String = "<RSAKeyValue><Modulus>wAtD1eO9SLdWodrQZpEVli+yqQ2crnGrQMIXwMQSprj4yn2aVwe4Jaqqo+xeHv04zh4GpL9yj4VWuMjRop04vq0HOfw/xylSAKULKYxmeplQM97UKHtDOheixtQxsPMY3aXSbJlbfB7VdiTEY7wV+ho91PKrBX9oExfnoEWxn53uLuzlvmdr55j3/TL8znJZR50GtSPOCswxyO0l7aP0azyLCR2VaYQHYUqbDqwuWXhwlTr4jPtD644US/Gx3ZgCgJ8aC1jYwLscRdrFAI6O7jBl3mJ/pylLfRBtqDF7zklEUR9NGCzkFOHYJg/27lPoDMYiTL3z94OMvlx92nF/rQ==</Modulus><Exponent>AQAB</Exponent><P>yMSDDj/oRuMnFPoTIr3AfTSgQvI59uBP4suMT9RxyLYBq8R9gBDNKjNNHjBmuceYtr6aBBZI+3wSg2iaRvP18LY5pFji4JI79KJL8QDEXC88HbYFJhfzoGpPKTMBi4MDhilWk4mhhLjnQX8FYr4Y4LWcufJIeRXYPgKo+tK5nIc=</P><Q>9OBfmer5liNqjWZNBhh/4Et2fv5Nwe4mAXo8LdL3hB3Kz7b3bOML6m95M5oRuYMUcGeGrrVfk2RH5wgd/H3xbLPjHZJiuyMb8wIrNlVs9Rg/Scqklp/uhWpRjeCuBAnX6wV22UmHu3EmBRKX4JO7/dplAJnjDQgszudLSW9kYys=</Q><DP>Tfq96Jf78SSjdmtXaWQIUtlQ8g/BYdloTe+/lPYwJ8RBy+Sq1kYwWhbI+lPUYo5bC4fmrHW3bS6Yxj+nxK1XNmKg6uu3W4CRFwi+tGIW4rNaBzQ+tbgR4ZnJG3h7PiPqB38g6HdJrBJhiDf88Ihjg0wnDrZDXfyVHCjOV3XnsBs=</DP><DQ>LctIFaC7zDgTVR4siVdLksaKAnXMVNgUg3I4jtlFMI/hvbaZzuMm91CheeT2K5s3102FAmco2IeIasw5z14+J/X8IyudCyIlt+xP6HlRRwSh0Ur0PLbsBEc9uSqrYFX26xy6fSgjGgqu8YPoozb9kRumh9Y/f9BnkMnwamtKesE=</DQ><InverseQ>nGEasHQbODByPSqWESq7eai8OXbdCeRmwY0wZI0Kq/lmHvPW0rTWRDTnMHvh8DgjGFt2M1b7EXMuXdrO49FUyiPvnyq2zP6ccAbwNXwTWzfWkqlGWV3V1JTvuGEQVwW+rK9WEMKAUzWGm0r+eCxkh/6f+mHqIk82u9rNRnZ5fKc=</InverseQ><D>hGH/lB0WqV7A2HgXOuz+fXZJ6WFZxaLT06M4boh69vUBg8yLrTzEAysf0DorM5+JHgTyvXS/yxG2k1DTug45RK/QEHfDm03vmkQraqu/JPo0oF0V0QYPdKdAbWFvE7SwSnJ5mKUqvGgg6/0yaDIK0Epwny/dFsAaBTdwUzpX1Ff92dpvUhc6RAMjUCTBPBFwp7z2ALY7qUkwy5tkaG0chDcacaN25Q4/oXddbide5jbaWz04IqkZ5ivqBhYT+SZe1yJpD0tTxFrRuAMMd5ko25de1Up9Dib0XaUMrljVfNDxP3JDcC+vOjzoUfWzvMiRyLE3eDc4hDpAcjKaqVe+HQ==</D></RSAKeyValue>"
            rsa.FromXmlString(XML_PrivateKey)
            Dim key As RSAParameters = rsa.ExportParameters(True)
            signedData = HashAndSignBytes(originalData, key)
            Return Convert.ToBase64String(signedData)
        Catch ex As Exception

        End Try
    End Function

End Class
