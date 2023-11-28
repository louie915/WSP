

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.HttpContext
Imports System.Security.Cryptography
Imports System.Net
Imports RestSharp
Imports System.Web.Script.Serialization


#End Region

Public Class cDalPaymentInquiry

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader
    Public _Dataset As DataSet
#End Region

#Region "GateWay Variables"
    Dim encoder As New UTF8Encoding
    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer()
    Public Shared GCashDomain As String = "https://api.saas.mynt.xyz/"
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
#End Region

#Region "GCASH RESPONSE VARIABLES"
    Public Gcash_reqMsgId As String
    Public Gcash_acquirementId As String
    Public Gcash_merchantTransId As String
    Public Gcash_orderTitle As String
    Public Gcash_payAmount As String
    Public Gcash_acquirementStatus As String
    Public Gcash_paidTime As String
    Public Gcash_signature As String
#End Region


#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property
    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region



#Region "Routine Command"

    Public Function Get_Dataset() As DataSet
        Try
            _Dataset = New DataSet
            Dim _Query As String = ""
            _mSqlCommand = New SqlCommand(_Query, _mSqlCon)
            Dim _SqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _SqlDataAdapter.Fill(_Dataset)
        Catch ex As Exception

        End Try
        Return _Dataset
    End Function
    Public Sub Update_NoGatewaySelected()
        Try
            Dim _nQuery As String = _
                " UPDATE OnlinePaymentRefNo" &
                " SET statusId = 'FAILED', status = 'No Gateway Selected'" &
                " WHERE paymentchannel = ''" &
                " AND  EmailAddr = '" & cSessionUser._pUserID & "';"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub


    Public Sub Select_qry()
        Try
            Dim _nQuery As String = ""
               

            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    ' acquirementId = _mSqlDataReader("acquirementStatus")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Public Function Get_txnrefno_list() As String
        Dim result As String = Nothing
        Try
            Dim _nQuery As String = _
               " Select * from OnlinePaymentRefNo where EmailAddr = '" & cSessionUser._pUserID & "' and StatusID='PENDING' and PaymentChannel <> 'OTC'"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    result = _mSqlDataReader("txnrefno_list")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception
        End Try
        Return result
    End Function


#End Region

#Region "Gateway Routine"
    Public Sub PaymentInquiry(ByVal MerchantRefNo As String)
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
            str = MerchantRefNo
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

        End Try
    End Sub

    Private Sub SetCredentials()
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
            ProductCode = _nClass1._pProductCode
            GCASH_PubKey = "-----BEGIN PUBLIC KEY-----" & vbCrLf & _nClass1._pGCASH_PublicKey_PEM & vbCrLf & "-----END PUBLIC KEY-----"
        Catch ex As Exception

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

            Dim Response_OriginalString
            Dim index As Integer = response1.Content.LastIndexOf(","c)
            Response_OriginalString = response1.Content.Remove(index)
            Response_OriginalString = Response_OriginalString.Remove(0, 12) ' Remove "response":

      
            Q_acquirementStatus = res("response")("body")("statusDetail")("acquirementStatus")
            Q_Security = res("response")("body")("acquirementId")
            Q_GateWayRefNo = res("response")("body")("transactionId")

            Gcash_reqMsgId = res("response")("head")("reqMsgId")
            Gcash_acquirementId = res("response")("body")("acquirementId")
            Gcash_merchantTransId = res("response")("body")("merchantTransId")
            Gcash_orderTitle = res("response")("body")("orderTitle")
            Gcash_payAmount = res("response")("body")("amountDetail")("payAmount")("value")
            Gcash_acquirementStatus = res("response")("body")("statusDetail")("acquirementStatus")
            Gcash_paidTime = res("response")("body")("paymentViews")("paidTime")
            Gcash_signature = res("response")("signature")

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

        Catch ex As Exception

        End Try

    End Sub

    Private Function Do_Sign(ByVal StringToSign As String) As String
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

    Private Function HashAndSignBytes(ByVal DataToSign As Byte(), ByVal Key As RSAParameters) As Byte()
        Try
            Dim RSAalg As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            RSAalg.ImportParameters(Key)
            Return RSAalg.SignData(DataToSign, SHA256.Create())
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
            Return Nothing
        End Try
    End Function
#End Region
End Class
