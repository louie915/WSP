Imports RestSharp
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Net.Mail
Imports System.Text.Json
Imports RestSharp.Serializers
Imports Newtonsoft.Json
Imports Microsoft.Reporting.WebForms
Imports System.Reflection
Imports SPIDC.Resources

Public Class PayMaya
    Inherits System.Web.UI.Page

    Public Shared PayorEmail As String 'taxpayer@spidc.com.ph
    Public Shared SPIDCRefNo As String 'txnrefno
    Public Shared Amount As Double '1000.00
    Public Shared ACCTNO As String 'BPLTAS ACCTNO
    Public Shared TransType As String 'BP,RPT,CTC
    Public Shared PaymentDesc As String 'BP Renewal, BP New
    Public Shared API_Type As String 'Paymaya API Module
    Public Shared checkoutId As String
    Public Shared paymentId As String
    Public Shared rrn As String
    Public Shared PK As String ' = "pk-Z0OSzLvIcOI2UIvDhdTGVVfRSSeiGStnceqwUE7n0Ah"
    '	pk-OyU4PmV2J9cYGyQyGSRxnGldzn4tiI8a9uj6t2NHXd2
    Public Shared PKPASS As String = ""
    Public Shared SK As String ' =' "sk-X8qolYjy62kIzEbr0QRK1h4b4KDVHaNcwMYk39jInSl"
    'sk-XKHQOckdpT3IwU8pkYY7gXP47W02jLEraWuPiosBzhG

    Public Shared SKPASS As String = ""
    Public Shared PayMayaDomain As String = "https://pg.paymaya.com"

    'Sandbox URL : https://pg-sandbox.paymaya.com
    'Production Url: https://pg.paymaya.com

    Public Shared reason As String
    Public Shared CallbackURL As String = HttpContext.Current.Request.Url.AbsoluteUri
    Public Shared _Status As String
    Public Shared _WebhookURL As String
    'Public Shared _WebhookURL As String = "https://ptsv2.com/t/4wsnh-1642569646/post"
    Dim err As String
    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

        Dim _nC As New cDalPayment
        '  _nC._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        '  _nC.GetCredentials_PayMaya(PK, SK)
        PK = _nC.gw_PublicApiKey
        SK = _nC.gw_SecretApiKey
        If API_Type = "Create Checkout Payment - POST" Then
            API_Type = ""
            '    CreateUpdateCustomization_POST(err)
            ' Response.Write("CreateUpdateCustomization_POST - " & err)

            'GetWebhookList_GET()
            'DeleteWebhook_DELETE("a")
            'For Testing Only 
            '- Delete and Re-create Webhooks Every Transaction
            ' GetDelete_Webhooks(err)
            ' Response.Write("GetDelete_Webhooks - " & err)


            'CreateWebhook_POST("CHECKOUT_SUCCESS", "https://online.spidc.com.ph/cainta/PayMaya/api/Paymaya_GetCheckout")
            'CreateWebhook_POST("CHECKOUT_FAILURE", "https://online.spidc.com.ph/cainta/PayMaya/api/Paymaya_GetCheckout")
            'CreateWebhook_POST("CHECKOUT_DROPOUT", "https://online.spidc.com.ph/cainta/PayMaya/api/Paymaya_GetCheckout")

            Dim strPathAndQuery As String = HttpContext.Current.Request.Url.PathAndQuery
            Dim strUrl As String = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/")
            If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("TEST") Then
                _WebhookURL = strUrl & "Test/API_Payment/api/Paymaya_GetPayment"
            Else
                _WebhookURL = strUrl & "API_Payment/api/Paymaya_GetPayment"
            End If


            ' CreateWebhook_POST("PAYMENT_SUCCESS", _WebhookURL)
            ' CreateWebhook_POST("PAYMENT_FAILED", _WebhookURL)
            ' CreateWebhook_POST("PAYMENT_EXPIRED", _WebhookURL)


            CreateCheckoutPayment_POST(err)
            Response.Write("CreateCheckoutPayment_POST - " & err)

            _Status = "PENDING"
        Else

            If Request.QueryString("S") = "S" Or
                Request.QueryString("S") = "F" Or
                Request.QueryString("S") = "C" Then
                rrn = Request.QueryString("RRN")
                API_Type = "Get Payments via RRN"
                GetPaymentsviaRRN_GET(rrn)
            End If
            Exit Sub
        End If

        'Insert to History Table

        Dim numAbbrv As String
        If TransType = "BP" Then
            numAbbrv = "BIN"
        ElseIf TransType = "RPT" Then
            numAbbrv = "AssessmentNo"
        ElseIf TransType = "CTC" Then
            numAbbrv = "CtrlNo"
        End If

        Dim _nClass3 As New cDalTransactionHistory
        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass3._pSubInsertHistory(SPIDCRefNo, _
                                    PayorEmail, _
                                    TransType, _
                                    "Payment", _
                                   PaymentDesc, _
                                   "ID=" & SPIDCRefNo & ";Description=" & PaymentDesc & ";" & numAbbrv & "=" & ACCTNO & ";PaymentMethod=Paymaya;TotalAmount=" & Amount & ";", _
                                    _Status)




        'CreateCheckoutPayment_POST()
        'GetCheckout_GET(checkoutId)
        'GetPaymentsviaRRN_GET(rrn)
        'VoidbyID_POST(paymentId, reason)
        'GetVoids_GET(paymentId)
        'RefundbyID_POST(Amount, rrn, reason)
        'GetRefunds_GET(paymentId)
    End Sub

    Public Shared Function Base64Encode(ByVal plainText As String) As String
        Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText)
        Return System.Convert.ToBase64String(plainTextBytes)
    End Function
    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
    Sub CreateCheckoutPayment_POST(Optional err As String = Nothing)
        Try
            Dim objReq As New Paymaya_Class
            objReq.totalAmount = New TotalAmount()
            objReq.totalAmount.details = New Details()
            objReq.buyer = New Buyer()
            objReq.buyer.contact = New Contact()
            objReq.buyer.shippingAddress = New ShippingAddress()
            objReq.buyer.billingAddress = New BillingAddress()
            objReq.items = New Item()
            objReq.items.amount = New Amount()
            objReq.items.amount.details = New Details()
            objReq.items.totalAmount = New ItemTotalAmount()
            objReq.items.totalAmount.details = New Details()
            objReq.redirectUrl = New RedirectUrl()

            'totalAmount
            objReq.totalAmount.value = Amount
            objReq.totalAmount.currency = "PHP"
            objReq.totalAmount.details.discount = 0
            objReq.totalAmount.details.serviceCharge = 0
            objReq.totalAmount.details.shippingFee = 0
            objReq.totalAmount.details.tax = 0
            objReq.totalAmount.details.subtotal = Amount
            'buyer
            objReq.buyer.firstName = IIf(cSessionUser._pFirstName = Nothing, " ", cSessionUser._pFirstName)
            objReq.buyer.middleName = IIf(cSessionUser._pMiddleName = Nothing, " ", cSessionUser._pMiddleName)
            objReq.buyer.lastName = IIf(cSessionUser._pLastName = Nothing, " ", cSessionUser._pLastName)
            objReq.buyer.birthday = "1995-10-24"
            objReq.buyer.customerSince = "1995-10-24"
            objReq.buyer.sex = "M"
            'buyer > contact
            objReq.buyer.contact.phone = "+639000000000"
            objReq.buyer.contact.email = PayorEmail
            'buyer > shippingAddress
            objReq.buyer.shippingAddress.firstName = IIf(cSessionUser._pFirstName = Nothing, " ", cSessionUser._pFirstName)
            objReq.buyer.shippingAddress.middleName = IIf(cSessionUser._pMiddleName = Nothing, " ", cSessionUser._pMiddleName)
            objReq.buyer.shippingAddress.lastName = IIf(cSessionUser._pLastName = Nothing, " ", cSessionUser._pLastName)
            objReq.buyer.shippingAddress.phone = "+639000000000"
            objReq.buyer.shippingAddress.email = PayorEmail
            objReq.buyer.shippingAddress.line1 = "Line 1"
            objReq.buyer.shippingAddress.line2 = "Line 2"
            objReq.buyer.shippingAddress.city = "City"
            objReq.buyer.shippingAddress.state = "State"
            objReq.buyer.shippingAddress.zipCode = "0000"
            objReq.buyer.shippingAddress.countryCode = "PH"
            objReq.buyer.shippingAddress.shippingType = "ST" ' ST - for standard, SD - for same day
            'buyer > billingAddress
            objReq.buyer.billingAddress.line1 = "Line 1"
            objReq.buyer.billingAddress.line2 = "Line 2"
            objReq.buyer.billingAddress.city = "City"
            objReq.buyer.billingAddress.state = "State"
            objReq.buyer.billingAddress.zipCode = "0000"
            objReq.buyer.billingAddress.countryCode = "PH"
            'items(0)
            objReq.items.name = ACCTNO
            objReq.items.quantity = 1
            objReq.items.code = ACCTNO
            objReq.items.description = PaymentDesc
            'items(0) > amount
            objReq.items.amount.value = Amount
            'items(0) > amount > details
            objReq.items.amount.details.discount = 0
            objReq.items.amount.details.serviceCharge = 0
            objReq.items.amount.details.shippingFee = 0
            objReq.items.amount.details.tax = 0
            objReq.items.amount.details.subtotal = Amount
            'items(1) > totalAmount 
            objReq.items.totalAmount.value = Amount
            'items(1) > totalAmount > details
            objReq.items.totalAmount.details.discount = 0
            objReq.items.totalAmount.details.serviceCharge = 0
            objReq.items.totalAmount.details.shippingFee = 0
            objReq.items.totalAmount.details.tax = 0
            objReq.items.totalAmount.details.subtotal = Amount
            'requestReferenceNumber
            objReq.requestReferenceNumber = SPIDCRefNo
            'redirectUrl

            objReq.redirectUrl.success = CallbackURL.Replace("PayNow2", "PayMaya") & "?S=S&RRN=" & SPIDCRefNo
            objReq.redirectUrl.failure = CallbackURL.Replace("PayNow2", "PayMaya") & "?S=F&RRN=" & SPIDCRefNo
            objReq.redirectUrl.cancel = CallbackURL.Replace("PayNow2", "PayMaya") & "?S=C&RRN=" & SPIDCRefNo

            'objReq.metadata()
            '   Dim request As WebRequest = WebRequest.Create(PayMayaDomain & "/checkout/v1/checkouts")
            '   request.Method = "POST"
            '   request.Headers.Add("Authorization", "Basic " & Base64Encode(PK & ":" & PKPASS))
            '   request.ContentType = "application/json"
            '   Dim body = serializer.Serialize(objReq)
            '   body = body.Replace("""items"":{", """items"":[{")
            '   body = body.Replace("},""redirectUrl""", "}],""redirectUrl""")
            '   body = body.Replace("null", "{}")
            '
            '   Dim byteArray As Byte() = Encoding.UTF8.GetBytes(body)
            '   request.ContentLength = byteArray.Length
            '
            '   Dim dataStream As Stream = request.GetRequestStream()
            '   dataStream.Write(byteArray, 0, byteArray.Length)
            '   dataStream.Close()
            '   Dim response1 As WebResponse = request.GetResponse()
            '   Console.WriteLine((CType(response1, HttpWebResponse)).StatusDescription)
            '   Dim responseFromServer As String
            '   Using CSharpImpl.__Assign(dataStream, response1.GetResponseStream())
            '       Dim reader As StreamReader = New StreamReader(dataStream)
            '       responseFromServer = reader.ReadToEnd()
            '   End Using
            '   Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(responseFromServer)
            '   Response.Write(responseFromServer)
            '   Response.Redirect(res("redirectUrl"))

            '-===========
            Dim client = New RestClient(PayMayaDomain)
            client.Timeout = -1
            Dim request = New RestRequest("/checkout/v1/checkouts", Method.POST)
            Dim body = serializer.Serialize(objReq)
            body = body.Replace("""items"":{", """items"":[{")
            body = body.Replace("},""redirectUrl""", "}],""redirectUrl""")
            body = body.Replace("null", "{}")

            request.AddHeader("Authorization", "Basic " & Base64Encode(PK & ":" & PKPASS))
            request.AddParameter("application/json", body, ParameterType.RequestBody)
            Response.Write(body & "<br><br>")

            '--Insert to Paymaya Transactions before POST
            Dim rq As String = request.ToString
            insert_PaymayaTransactions(rq)

            '--
            Dim response1 As IRestResponse = client.Execute(request)
            Response.Write(response1.Content)

            '--Update Response to Paymaya Transactions 
            Dim rp As String = response1.Content
            Update_PaymayaTransactions(rq, rp)
            '--

            Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(response1.Content)
            Response.Redirect(res("redirectUrl"))
        Catch ex As Exception
            err = ex.Message
        End Try

    End Sub

    Sub insert_PaymayaTransactions(ByVal Request As String)
        Dim _nClass3 As New cDalTransactionHistory
        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass3._pSubInsertPayMaya_Transactions(API_Type, _
                                    ACCTNO, _
                                    PayorEmail, _
                                    Request, _
                                   SPIDCRefNo)
    End Sub
    Sub Update_PaymayaTransactions(ByVal Request As String, ByVal Response As String)
        Dim _nClass3 As New cDalTransactionHistory
        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass3._pSubUpdatePayMaya_Transactions(API_Type, _
                                    ACCTNO, _
                                    PayorEmail, _
                                   Request, _
                                    Response, _
                                   SPIDCRefNo)
    End Sub
    Sub GetCheckout_GET(ByVal checkoutId As String)
        Dim client = New RestClient(PayMayaDomain & "/checkout/v1/checkouts/" & checkoutId)
        client.Timeout = -1
        '  ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim strAutorization = "Basic " & Base64Encode(SK & ":" & SKPASS)
        Dim request = New RestRequest(Method.[GET])
        request.AddHeader("Authorization", strAutorization)
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX.Content)
    End Sub

    Sub GetPaymentsviaRRN_GET(ByVal rrn As String)
        Dim client = New RestClient(PayMayaDomain & "/payments/v1/payment-rrns/" & rrn)
        client.Timeout = -1
        '     ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim request = New RestRequest(Method.[GET])
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))

        '--Insert to Paymaya Transactions before POST
        Dim rq As String = request.ToString
        insert_PaymayaTransactions(rq)
        '--

        Dim responseX As IRestResponse = client.Execute(request)

        '--Update Response to Paymaya Transactions 
        Dim rp As String = responseX.Content
        Update_PaymayaTransactions(rq, rp)
        '--

        '     Response.Write(responseX.Content)

        Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(responseX.Content)

        Dim valueType As Type = res.[GetType]()
        Dim PAYMENT_STATUS As String
        Dim PAYMENT_RRN As String
        Dim PAYMENT_ID As String
        If valueType.IsArray Then
            txt_ID.InnerText = res(res.length - 1)("id")
            txt_isPaid.InnerText = res(res.length - 1)("isPaid")
            txt_status.InnerText = res(res.length - 1)("status")
            txt_amount.InnerText = res(res.length - 1)("amount")
            txt_currency.InnerText = res(res.length - 1)("currency")
            txt_canVoid.InnerText = res(res.length - 1)("canVoid")
            txt_canRefund.InnerText = res(res.length - 1)("canRefund")
            txt_canCapture.InnerText = res(res.length - 1)("canCapture")
            txt_createdAt.InnerText = res(res.length - 1)("createdAt")
            txt_updatedAt.InnerText = res(res.length - 1)("updatedAt")
            txt_description.InnerText = res(res.length - 1)("description")
            txt_requestReferenceNumber.InnerText = res(res.length - 1)("requestReferenceNumber")
            PAYMENT_STATUS = res(res.length - 1)("status")
            PAYMENT_RRN = res(res.length - 1)("requestReferenceNumber")
            PAYMENT_ID = res(res.length - 1)("id")
        Else
            txt_ID.InnerText = res("id")
            txt_isPaid.InnerText = res("isPaid")
            txt_status.InnerText = res("status")
            txt_amount.InnerText = res("amount")
            txt_currency.InnerText = res("currency")
            txt_canVoid.InnerText = res("canVoid")
            txt_canRefund.InnerText = res("canRefund")
            txt_canCapture.InnerText = res("canCapture")
            txt_createdAt.InnerText = res("createdAt")
            txt_updatedAt.InnerText = res("updatedAt")
            txt_description.InnerText = res("description")
            txt_requestReferenceNumber.InnerText = res("requestReferenceNumber")
            PAYMENT_STATUS = res("status")
            PAYMENT_RRN = res("requestReferenceNumber")
            PAYMENT_ID = res("id")
        End If

        If PAYMENT_STATUS = "PAYMENT_SUCCESS" Then
            Dim TaxpayerEmail As String = Nothing
            Dim ACCTNO As String = Nothing
            Dim StatusId As String = Nothing
            Dim PaymentFor As String = Nothing
            Dim _nclass As New cDalPayment
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            ' _nclass._pSubSelect_PaymentDetails(PAYMENT_RRN, ACCTNO, StatusId)
            '  If StatusId = "SUCCESS" Then
            '      snackbar("green", "Account already Paid and Updated")
            '  Else
            _nclass._pSubSelect_PaymentDetails(PAYMENT_RRN, ACCTNO, StatusId, PaymentFor, TaxpayerEmail)
            _nclass._pSubUpdate_PaymentDetails(PAYMENT_RRN, PAYMENT_ID)

            If PaymentFor = "BP" Then
                _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nclass._pSubUpdate_forIssuance(ACCTNO)

            End If
            _Status = PAYMENT_STATUS


            Dim _nclassGetModules As New cDalGetModules
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            Dim eorno As String = Nothing
            Dim isTaxpayer As Boolean = True
            Dim _nclasseOR As New eOR_Jaka
            Dim _nClassPost As New Process
            Dim err As String = Nothing

            If cInit_eOR.Initialize_EOR(SPIDCRefNo, Report_EOR, "PAYMAYA", PAYMENT_ID) = True Then GoTo jumphere

            ' '' '' ''================================================================================================================
            ' '' '' ''If _nclassGetModules._pSubGetAvailableModules("EOR") = True Then
            ' '' '' ''    If _nclasseOR.isEOR_Exists(SPIDCRefNo) = False Then
            ' '' '' ''        Process.ACCTNO = _nclasseOR.getACCTNO(SPIDCRefNo)

            ' '' '' ''        '-----New Addedd 11-03-2023 JAY SITJAR-----
            ' '' '' ''        cSessionLoader._pTDN = _nclasseOR.getTDN1(Process.ACCTNO)
            ' '' '' ''        If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
            ' '' '' ''            cSessionLoader._pTDN = _nclasseOR.getTDNHist1(Process.ACCTNO)
            ' '' '' ''            If Not (cSessionLoader._pTDN Is Nothing) Then
            ' '' '' ''                'Move RPT AssessmentFrom History To Current
            ' '' '' ''                _nclasseOR.moveRPTAssessmentFromHistToCurrent1(Process.ACCTNO)
            ' '' '' ''            Else
            ' '' '' ''                'Do Nothing
            ' '' '' ''            End If
            ' '' '' ''        End If

            ' '' '' ''        cSessionLoader._pTDN = _nclasseOR.getTDN(Process.ACCTNO)
            ' '' '' ''        If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
            ' '' '' ''            cSessionLoader._pTDN = _nclasseOR.getTDNHist(Process.ACCTNO)
            ' '' '' ''            If Not (cSessionLoader._pTDN Is Nothing) Then
            ' '' '' ''                'Move RPT AssessmentFrom History To Current
            ' '' '' ''                _nclasseOR.moveRPTAssessmentFromHistToCurrent(Process.ACCTNO)
            ' '' '' ''            Else
            ' '' '' ''                'Do Nothing
            ' '' '' ''            End If
            ' '' '' ''        End If

            ' '' '' ''        cSessionLoader._pTDN = _nclasseOR.getTDN2(Process.ACCTNO)
            ' '' '' ''        If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
            ' '' '' ''            cSessionLoader._pTDN = _nclasseOR.getTDNHist2(Process.ACCTNO)
            ' '' '' ''            If Not (cSessionLoader._pTDN Is Nothing) Then
            ' '' '' ''                'Move RPT AssessmentFrom History To Current
            ' '' '' ''                _nclasseOR.moveRPTAssessmentFromHistToCurrent2(Process.ACCTNO)
            ' '' '' ''            Else
            ' '' '' ''                'Do Nothing
            ' '' '' ''            End If
            ' '' '' ''        End If

            ' '' '' ''        cSessionLoader._pTDN = _nclasseOR.getTDN3(Process.ACCTNO)
            ' '' '' ''        If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
            ' '' '' ''            cSessionLoader._pTDN = _nclasseOR.getTDNHist3(Process.ACCTNO)
            ' '' '' ''            If Not (cSessionLoader._pTDN Is Nothing) Then
            ' '' '' ''                'Move RPT AssessmentFrom History To Current
            ' '' '' ''                _nclasseOR.moveRPTAssessmentFromHistToCurrent3(Process.ACCTNO)
            ' '' '' ''            Else
            ' '' '' ''                'Do Nothing
            ' '' '' ''            End If


            ' '' '' ''        End If
            ' '' '' ''        '-----End Addedd 11-03-2023 JAY SITJAR-----

            ' '' '' ''        Process.Gateway_Selected = "PAYMAYA"
            ' '' '' ''        Process.GatewayRefNo = PAYMENT_ID
            ' '' '' ''        eOR.Gateway_RefNo = PAYMENT_ID
            ' '' '' ''        eOR.TaxPayerEmail = _nclasseOR.getEMAIL(SPIDCRefNo) 'TaxpayerEmail
            ' '' '' ''        Process.TransactionType = _nclasseOR.getTransactionType(SPIDCRefNo)
            ' '' '' ''        eOR.SPIDC_RefNo = SPIDCRefNo
            ' '' '' ''        _nClassPost.START_POSTING(err, eorno, isTaxpayer, SPIDCRefNo)
            ' '' '' ''        _GenerateReport_eOR(1, Process.TransactionType, eorno)
            ' '' '' ''        Response.Write("<script>alert('E-OR has been sent to your EMAIL.');</script>")

            ' '' '' ''    End If
            ' '' '' ''End If
            ' '' '' ''================================================================================================================

            If _nclassGetModules._pSubGetAvailableModules("EOR") = True Then
                If _nclasseOR.isEOR_Exists(SPIDCRefNo) = False Then
                    cSessionLoader._pTDN = _nclasseOR.getTDN(ACCTNO)
                    Process.ACCTNO = ACCTNO
                    Process.Gateway_Selected = "PAYMAYA"
                    Process.GatewayRefNo = PAYMENT_ID
                    eOR.Gateway_RefNo = PAYMENT_ID
                    eOR.TaxPayerEmail = TaxpayerEmail
                    Process.TransactionType = _nclasseOR.getTransactionType(SPIDCRefNo)
                    eOR.SPIDC_RefNo = SPIDCRefNo
                    _nClassPost.START_POSTING(err, eorno, isTaxpayer, PAYMENT_RRN)
                    _GenerateReport_eOR(1, Process.TransactionType, eorno)

                    Response.Write("<script>alert('E-OR has been sent to your EMAIL.');</script>")
                    ' _ExportToPDF("EOR", eorno)

                    ' Response.Write("<script>alert('E-OR has been sent to your EMAIL.');window.location.replace('WebPortal/Account.aspx');</script>")
                End If
            End If

jumphere:
            snackbar("green", "Payment Details has been Updated")
            'End If
        End If


    End Sub

    Public Sub _GenerateReport_eOR(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String)
        Try
            Dim _nclassEOR As New eOR

            Dim _nDataTable0 As New DataTable
            _nDataTable0 = _nclassEOR.Print_Template

            Dim _nDataTable1 As New DataTable
            _nDataTable1 = _nclassEOR.Print_Report(eORNO)

            Dim _nDataTable2 As New DataTable
            _nDataTable2 = _nclassEOR.Print_TOP(eORNO)



            Report_EOR.Reset()
            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo

            For Each extension As RenderingExtension In Report_EOR.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format
            If TAXTYPE_eOR = "REAL PROPERTY TAX" Or TAXTYPE_eOR = "RPT" Then
                Report_EOR.LocalReport.ReportPath = _gResxRdlc.pEOR_RPT2
            ElseIf TAXTYPE_eOR = "BUSINESS PERMIT" Or TAXTYPE_eOR = "BP" Then
                Report_EOR.LocalReport.ReportPath = _gResxRdlc.pEOR_BP2
            End If

            Report_EOR.LocalReport.EnableExternalImages = False

            Report_EOR.LocalReport.DataSources.Clear()

            Dim _nReportDataSource0 As New ReportDataSource
            _nReportDataSource0.Name = "DataSet0"
            _nReportDataSource0.Value = _nDataTable0
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource0)

            Dim _nReportDataSource1 As New ReportDataSource
            _nReportDataSource1.Name = "DataSet1"
            _nReportDataSource1.Value = _nDataTable1
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource1)

            Dim _nReportDataSource2 As New ReportDataSource
            _nReportDataSource2.Name = "DataSet2"
            _nReportDataSource2.Value = _nDataTable2
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource2)


            Dim ds_TotalAmount As String
            For Each row As DataRow In _nDataTable2.Rows
                ds_TotalAmount += CDec(row("Amount"))
            Next

            Dim _eOr As New eOR
            Dim strAmount As String = Nothing
            strAmount = _eOr.AmountInWords(ds_TotalAmount)

            Dim paramList As New List(Of ReportParameter)
            paramList.Add(New ReportParameter("AmountInWords", strAmount.ToUpper))

            Report_EOR.LocalReport.SetParameters(paramList)

            Report_EOR.AsyncRendering = True
            Report_EOR.LocalReport.Refresh()
            Report_EOR.Enabled = True


            If _send = 1 Then
                Dim bytes As Byte() = Report_EOR.LocalReport.Render("PDF")
                Dim sent As Boolean = False
                Dim err As String = Nothing
                Dim body As String

                body = "Dear Valued Tax Payer, <br> " & _
                       "This confirms your bill payment transaction with the following details: <br> " & _
                       "Transaction Number: " & _nDataTable1.Rows(0)("OnlineId") & "<br>" & _
                       "Transaction Type: " & _nDataTable1.Rows(0)("TaxType") & " Payment<br>" & _
                       "Account No. : " & _nDataTable1.Rows(0)("TDNBIN") & "<br>" & _
                       "Amount Paid : " & _nDataTable1.Rows(0)("GrandTotal") & "<br> <br>" & _
                       "Your Electronic Official Receipt is attached in this e-mail."

                cDalNewSendEmail.Send_eOR(eOR.TaxPayerEmail, "Electronic Official Receipt", body, bytes, sent, err)

                If String.IsNullOrEmpty(err) = True Then
                    eOR.Update_Sent(_nDataTable1.Rows(0)("eORNO"), err)
                    '   ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                    Exit Sub
                End If

                'If sent = True Then
                '    Response.Clear()
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                'Else
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + err + "');", True)
                'End If

            End If


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub

    Public Sub _ExportToPDF(ByVal DocType As String, Optional ByVal ID As String = Nothing)
        Try
            Dim warnings As Warning()
            Dim streamIds As String()
            Dim contentType As String
            Dim encoding As String
            Dim extension As String

            'Export the RDLC Report to Byte Array.
            Dim bytes As Byte() = Report_EOR.LocalReport.Render("PDF", Nothing, contentType, encoding, extension, streamIds, warnings)
            'Download the RDLC Report in Word, Excel, PDF and Image formats.
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.Charset = ""
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
            HttpContext.Current.Response.ContentType = contentType

            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & DocType & "_" & ID & ".pdf")

            HttpContext.Current.Response.BinaryWrite(bytes)
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.End()
        Catch ex As Exception
            HttpContext.Current.Response.Write(ex.Message)
        End Try

        '
    End Sub
    Sub VoidbyID_POST(ByVal paymentID As String, ByVal reason As String)
        Dim client = New RestClient(PayMayaDomain & "/payments/v1/payments/" & paymentID & "/voids")
        client.Timeout = -1
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
        request.AddHeader("Content-Type", "application/json")
        Dim body = "{""reason"": """ & reason & """}"
        request.AddParameter("application/json", body, ParameterType.RequestBody)
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX.Content)
    End Sub

    Sub GetVoids_GET(ByVal paymentID As String)
        Dim client = New RestClient(PayMayaDomain & "/payments/v1/payments/" & paymentID & "/voids")
        client.Timeout = -1
        '    ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim request = New RestRequest(Method.[GET])
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX.Content)
    End Sub

    Sub RefundbyID_POST(ByVal amount As Integer, ByVal rrn As String, ByVal reason As String)
        Dim client = New RestClient(PayMayaDomain & "/payments/v1/payments/" & paymentId & "/refunds")
        client.Timeout = -1
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
        request.AddHeader("Content-Type", "application/json")
        Dim body = "{" & _
              """totalAmount"": {" & _
                """amount"": " & amount & "," & _
                """currency"": ""PHP""" & _
             " }," & _
              """requestReferenceNumber"": """ & rrn & """," & _
              """reason"": """ & reason & """" & _
            "}"
        request.AddParameter("application/json", body, ParameterType.RequestBody)
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX.Content)
    End Sub

    Sub GetRefunds_GET(ByVal paymentID As String)
        Dim client = New RestClient(PayMayaDomain & "/payments/v1/payments/" & paymentID & "/refunds")
        client.Timeout = -1
        'ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim request = New RestRequest(Method.[GET])
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX.Content)
    End Sub

    Sub CreateUpdateCustomization_POST(Optional err As String = Nothing)
        Try
            Dim client = New RestClient(PayMayaDomain & "/checkout/v1/customizations")
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
            request.AddHeader("Content-Type", "application/json")
            Dim body = "{" & _
                    """logoUrl"": ""https://i.ibb.co/C6Jq691/spidc.png""," & _
                    """iconUrl"": ""https://spidc.com.ph/Images/favico.ico""," & _
                    """appleTouchIconUrl"": ""https://spidc.com.ph/Images/favico.ico""," & _
                    """customTitle"": ""SPIDC""," & _
                    """colorScheme"": ""#001aff""," & _
                    """showMerchantName"": false," & _
                    """hideReceiptInput"": false," & _
                    """skipResultPage"": false," & _
                    """redirectTimer"": 10" & _
                    "}"
            request.AddParameter("application/json", body, ParameterType.RequestBody)
            Dim responseX As IRestResponse = client.Execute(request)
            Response.Write(responseX.Content)
        Catch ex As Exception
            err = ex.Message
        End Try

    End Sub

    Sub CreateWebhook_POST(ByVal name As String, ByVal callbackUrl As String)
        Dim client = New RestClient(PayMayaDomain & "/checkout/v1/webhooks")
        client.Timeout = -1
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
        request.AddHeader("Content-Type", "application/json")
        Dim body = "{" & _
             """name"": """ & name & """," & _
              """callbackUrl"": """ & callbackUrl & """}"
        request.AddParameter("application/json", body, ParameterType.RequestBody)
        Dim responseX As IRestResponse = client.Execute(request)
        '    Response.Write(responseX.Content)
    End Sub

    Sub GetWebhookList_GET()
        Dim client = New RestClient(PayMayaDomain & "/checkout/v1/webhooks")
        client.Timeout = -1
        '  ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim request = New RestRequest(Method.[GET])
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX.Content)
    End Sub

    Sub GetDelete_Webhooks(Optional err As String = Nothing)
        Try
            Dim client = New RestClient(PayMayaDomain & "/checkout/v1/webhooks")
            client.Timeout = -1
            '     ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim request = New RestRequest(Method.[GET])
            request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
            Dim responseX As IRestResponse = client.Execute(request)
            '       Response.Write(responseX.Content)
            Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(responseX.Content)
            Dim valueType As Type = res.[GetType]()
            If valueType.IsArray Then
                For x As Integer = 0 To res.length - 1
                    If res(x)("callbackUrl") <> _WebhookURL Then
                        DeleteWebhook_DELETE(res(x)("id"))
                    End If
                Next
            Else
                If res("callbackUrl") <> _WebhookURL Then
                    DeleteWebhook_DELETE(res("id"))
                End If

            End If
        Catch ex As Exception
            err = ex.Message
        End Try

    End Sub

    Sub DeleteWebhook_DELETE(ByVal webhookID As String)
        Dim client = New RestClient(PayMayaDomain & "/checkout/v1/webhooks/" & webhookID)
        client.Timeout = -1
        '    ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        Dim request = New RestRequest(Method.[DELETE])
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX.Content)
    End Sub


    Private Sub btnSubmit_ServerClick(sender As Object, e As EventArgs) Handles btnSubmit.ServerClick
        Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(txtArea.Value)
        Dim valueType As Type = res.[GetType]()

        If valueType.IsArray Then
            txt_ID.InnerText = res(res.length - 1)("id")
            txt_isPaid.InnerText = res(res.length - 1)("isPaid")
            txt_status.InnerText = res(res.length - 1)("status")
            txt_amount.InnerText = res(res.length - 1)("amount")
            txt_currency.InnerText = res(res.length - 1)("currency")
            txt_canVoid.InnerText = res(res.length - 1)("canVoid")
            txt_canRefund.InnerText = res(res.length - 1)("canRefund")
            txt_canCapture.InnerText = res(res.length - 1)("canCapture")
            txt_createdAt.InnerText = res(res.length - 1)("createdAt")
            txt_updatedAt.InnerText = res(res.length - 1)("updatedAt")
            txt_description.InnerText = res(res.length - 1)("description")
            txt_requestReferenceNumber.InnerText = res(res.length - 1)("requestReferenceNumber")
        Else
            txt_ID.InnerText = res("id")
            txt_isPaid.InnerText = res("isPaid")
            txt_status.InnerText = res("status")
            txt_amount.InnerText = res("amount")
            txt_currency.InnerText = res("currency")
            txt_canVoid.InnerText = res("canVoid")
            txt_canRefund.InnerText = res("canRefund")
            txt_canCapture.InnerText = res("canCapture")
            txt_createdAt.InnerText = res("createdAt")
            txt_updatedAt.InnerText = res("updatedAt")
            txt_description.InnerText = res("description")
            txt_requestReferenceNumber.InnerText = res("requestReferenceNumber")
        End If





    End Sub

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            '   _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            '_oLabelSnackbargreen.Text = Caption
            'ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub
End Class