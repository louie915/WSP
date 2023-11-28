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
Imports System.Security.Cryptography
Imports Org.BouncyCastle.Crypto
Imports Org.BouncyCastle.Crypto.Parameters
Imports Org.BouncyCastle.OpenSsl
Imports Org.BouncyCastle.Security
Imports Org.BouncyCastle.Asn1.X509
Imports Org.BouncyCastle.Asn1.Pkcs
Imports Org.BouncyCastle.Pkcs
Imports Org.BouncyCastle.X509
Imports System.Threading
Imports System.Reflection
Imports Microsoft.Reporting.WebForms

Imports SPIDC.Resources
Imports System.ComponentModel
Imports System.Web.UI
Imports VB.NET.Email
Imports System.Drawing
Imports System.Web.HttpContext


Public Class GCash
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

    Public Shared RedirectURLCounter As Boolean = True


    Dim _nDataTable0 As New DataTable
    Dim _nDataTable1 As New DataTable
    Dim _nDataTable2 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        SetCredentials()
        If Not IsPostBack Then
            If Request.Params.AllKeys.Contains("cancel") = False Then
                Amount = verifyAmount(SPIDCRefNo)
                CreateCheckoutPayment_POST()
            End If
        End If

    End Sub
    Function verifyAmount(ByVal SPIDCRefNo As String) As String
        Dim result As String = Nothing
        Try
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            result = _nClass.Get_Details("OnlinePaymentRefNo", "TotAmount", "TXNREFNO", SPIDCRefNo)
        Catch ex As Exception
            result = ex.Message
            result = 0
        End Try

        Return result
    End Function
    Public Sub SetCredentials()
        Dim _nClass1 As New cDalGCash
        _nClass1._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        _nClass1.loadcredentials()
        _nClass1.Generate_ReqMsgID(SPIDCRefNo, ReqMsgID)
        PublicKey_XML = _nClass1._pPublicKey_XML
        PrivateKey_XML = _nClass1._pPrivateKey_XML
        PublicKey_PEM = _nClass1._pPublicKey_PEM
        PrivateKey_PEM = _nClass1._pPrivateKey_PEM
        ClientId = _nClass1._pClientId
        ClientSecret = _nClass1._pClientId '_nClass1._pClientId & _nClass1._pClientSecret '_nClass1._pClientId
        MerchantID = _nClass1._pMerchantID
        Session("MerchantID") = _nClass1._pMerchantID
        ProductCode = _nClass1._pProductCode
        GCASH_PubKey = "-----BEGIN PUBLIC KEY-----" & vbCrLf & _nClass1._pGCASH_PublicKey_PEM & vbCrLf & "-----END PUBLIC KEY-----"
    End Sub

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Sub CreateCheckoutPayment_POST(Optional err As String = Nothing)
        Try
            Dim _function As String
            Dim _transactionId As String
            Dim _merchantTransId As String
            Dim _acquirementStatus As String
            Dim _signature As String
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GetsqlDateNow(_sqlDateNow, _sqlDateNow10)


            Dim objReq As New GCash_OrderCreate0.Gcash_OrderCreate
            objReq.request = New GCash_OrderCreate0.Request()
            objReq.request.head = New GCash_OrderCreate0.Head()
            objReq.request.body = New GCash_OrderCreate0.Body()
            objReq.request.body.order = New GCash_OrderCreate0.Order()
            objReq.request.body.order.buyer = New GCash_OrderCreate0.Buyer()
            objReq.request.body.order.seller = New GCash_OrderCreate0.Seller()
            objReq.request.body.order.orderAmount = New GCash_OrderCreate0.OrderAmount()
            objReq.request.body.envInfo = New GCash_OrderCreate0.EnvInfo()

            'Head
            objReq.request.head.version = "2.0"
            objReq.request.head._function = "gcash.acquiring.order.create"
            objReq.request.head.clientId = ClientId
            objReq.request.head.clientSecret = ClientSecret
            objReq.request.head.reqTime = _sqlDateNow.ToString("yyyy-MM-dd'T'HH:mm:ssK")
            objReq.request.head.reqMsgId = ReqMsgID

            'Body>Order>Buyer
            objReq.request.body.order.buyer.userId = ""
            objReq.request.body.order.buyer.externalUserId = "1001"
            objReq.request.body.order.buyer.externalUserType = "1001"

            'Body>Order>Seller
            objReq.request.body.order.seller.userId = ""
            objReq.request.body.order.seller.externalUserId = "TESTSELLER"
            objReq.request.body.order.seller.externalUserType = "TESTSELLER"

            'Body>Order>orderTitle
            objReq.request.body.order.orderTitle = PaymentDesc & " - " & ACCTNO

            'Body>Order>orderAmount
            objReq.request.body.order.orderAmount.currency = "PHP"
            objReq.request.body.order.orderAmount.value = (CStr(Amount * 100)).Replace(".00", "")

            'Body>Order>
            objReq.request.body.order.merchantTransId = SPIDCRefNo
            objReq.request.body.order.createdTime = _sqlDateNow.ToString("yyyy-MM-dd'T'HH:mm:ssK")
            objReq.request.body.order.expirytime = _sqlDateNow10.ToString("yyyy-MM-dd'T'HH:mm:ssK")

            'Body>
            objReq.request.body.merchantId = MerchantID
            objReq.request.body.subMerchantId = ""
            objReq.request.body.subMerchantName = PaymentDesc
            objReq.request.body.productCode = ProductCode

            'Body>envInfo           
            objReq.request.body.envInfo.orderTerminalType = "WEB"
            objReq.request.body.envInfo.terminalType = "WEB"

            objReq.signature = "signature string"

            Dim client = New RestClient(GCashDomain)
            client.Timeout = -1
            Dim request = New RestRequest("gcash/acquiring/order/create.htm", Method.POST)
            Dim body = serializer.Serialize(objReq)

            Dim strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery
            Dim strUrl As String

            ' Dim callbackurl As String = strUrl & "PaymentConfirmation.aspx"
            'callbackurl = "http://ptsv2.com/t/zewy6-1646711060/post"

            Dim API_callback As String
            If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("TEST") Then
                strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/TEST/")
            ElseIf HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("ONLINE.SPIDC.COM.PH/CAINTA") Then
                strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/Cainta/")
            ElseIf HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("ONLINE.SPIDC.COM.PH/CALOOCAN") Then
                strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/Caloocan/")
            Else
                strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/")
            End If
            API_callback = strUrl & "API_Payment/api/GCASH_Notify"
            ''  API_callback = "https://ptsv2.com/t/mxn1t-1650360758/post"
            Dim PostBack_callback As String = strUrl & "PaymentConfirmation.aspx?referenceCode=" & SPIDCRefNo & "&SelectedBank=GCASH"



            Dim notifUrls As String = Nothing
            notifUrls += "[{""type"":""PAY_RETURN"",""url"":""" & PostBack_callback & "&S=S""},"
            notifUrls += "{""type"":""CANCEL_RETURN"",""url"":""" & PostBack_callback & "&S=F""},"
            notifUrls += "{""type"":""NOTIFICATION"",""url"":""" & API_callback & """}]}}"
            body = body.Replace("null}}", notifUrls)
            body = body.Replace("_function", "function")

            Dim StringToSign As String = Nothing
            StringToSign = body.Remove(0, 11) ' Remove "request":
            StringToSign = StringToSign.Replace(",""signature"":""signature string""}", "")
            Dim signedString = Do_Sign(StringToSign)
            body = body.Replace("signature string", signedString)
            request.AddParameter("application/json", body, ParameterType.RequestBody)

            Dim response1 As IRestResponse = client.Execute(request)

            '--Insert REQUEST to table GCASH_TRANSACTIONS 
            _function = objReq.request.head._function
            _transactionId = ""
            _merchantTransId = objReq.request.body.order.merchantTransId
            _acquirementStatus = ""
            _signature = signedString


            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GCASH_InsertLog(_function, _transactionId, _merchantTransId, body, "Request from SPIDC", _acquirementStatus, _signature)

            WriteLogs(_function, "REQUEST", body)
            WriteLogs(_function, "RESPONSE", response1.Content)


            Dim Response_OriginalString
            Dim index As Integer = response1.Content.LastIndexOf(","c)
            Response_OriginalString = response1.Content.Remove(index)
            Response_OriginalString = Response_OriginalString.Remove(0, 12) ' Remove "response":
            '   Response.Write(Response_OriginalString)
            Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(response1.Content)
            '  Response.Write(res("signature"))
            body = response1.Content
            'Response.Write("JSON to POST : </br>")
            'Response.Write(body & "</br>")
            'Response.Write("</br>")
            'Response.Write("OriginalString to POST : </br>")
            'Response.Write(Response_OriginalString & "</br>")
            'Response.Write("</br>")
            'Response.Write("Response Signature : </br>")
            'Response.Write(res("signature") & "</br>")
            'Response.Write("</br>")
            'Response.Write("Response String : </br>")
            'Response.Write(Response_OriginalString & "</br>")


            If VerifySignature(Response_OriginalString, res("signature")) = True Then

                '--UPDATE PREVIOUS RECORD BEFORE REDIRECT


                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubUpdateOnlinePaymentInfo(SPIDCRefNo _
                    , res("response")("body")("resultInfo")("resultMsg") _
                    , res("response")("body")("transactionId") _
                    , res("response")("body")("acquirementId") _
                    , res("response")("head")("respTime") _
                    , Amount _
                    , "0" _
                    , Amount _
                    , res("response")("body")("resultInfo")("resultCode") _
                    , "GCASH")

                Dim checkoutURL As String = res("response")("body")("checkoutUrl")
                '  Response.Redirect(res("response")("body")("checkoutUrl"))
                ' ClientScript.RegisterStartupScript(Me.[GetType](), "OpenWindow", "window.open('" & checkoutURL & "','_blank');", True)


                '--Insert RESPONSE to table GCASH_TRANSACTIONS 
                _function = res("response")("head")("function")
                _transactionId = res("response")("body")("transactionId")
                _merchantTransId = res("response")("body")("merchantTransId")
                _acquirementStatus = res("response")("body")("acquirementId")
                _signature = res("signature")

                cSessionLoader._ptransactionId = _transactionId
                cSessionLoader._pmerchantTransId = _merchantTransId
                cSessionLoader._pacquirementId = _acquirementStatus

                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass.GCASH_InsertLog(_function, _transactionId, _merchantTransId, body, "Response from GCASH", _acquirementStatus, _signature)


                If RedirectURLCounter Then

                    '  Response.Clear()
                    Response.Write("<center>")
                    Response.Write("<h1>Waiting for your payment...</h1>")
                    Response.Write("<h2>Please do not close this window. This page will automatically close after confirming your payment.</h2>")
                    Response.Write("<h2><p style='color:red;'>")
                    Response.Write("<b><u>DO NOT CLOSE this page or your payment may fail.</u></b>")
                    Response.Write("</p></h2>")
                    Response.Write("</br><div id='ten-countdown'></div>")
                    Response.Write("</center>")
                    '  Response.Write("<script>window.open ('" & checkoutURL & "','_blank');</script>")
                    Response.Write("<iframe src='" & checkoutURL & "' frameborder='0' width='100%' height='1000'></iframe>")

                    Q_acquirementId = res("response")("body")("acquirementId")
                    Q_merchantTransId = res("response")("body")("merchantTransId")
                    Q_shortTransId = res("response")("body")("transactionId")

                    'Set Order Query Params
                    Session("acquirementId") = Q_acquirementId
                    Session("merchantTransId") = Q_merchantTransId
                    Session("shortTransId") = Q_shortTransId
                    Session("acquirementStatus") = "none"
                    Session("EndDate") = _sqlDateNow10

                    'start Order Query 1st time                 
                    CreateQuery_1stTime(Session("merchantTransId"), Session("shortTransId"), Session("acquirementId"))

                    'START ORDER QUERY Continuously      
                    Timer1.Interval = 2000
                    Timer1.Enabled = True
                End If
            Else
                Response.Write(VerifySignature(Response_OriginalString, res("signature")))
            End If

        Catch ex As Exception
            err = ex.Message
        End Try

    End Sub
    Protected Sub Timer1_Tick(sender As Object, e As EventArgs)
        Dim err As String
        Dim spidcrefno As String
        Dim status As String
        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass.GetsqlDateNow(_sqlDateNow, _sqlDateNow10)

        spidcrefno = Session("merchantTransId")

        If Session("acquirementStatus") = "SUCCESS" Or Session("acquirementStatus") = "CLOSED" Then
            status = Session("acquirementStatus")
            Timer1.Enabled = False

            Dim _nclassGetModules As New cDalGetModules
            If _nclassGetModules._pSubGetAvailableModules("EOR") = True Then
                do_eor(Session("acquirementStatus"), Session("merchantTransId"), Session("shortTransId"))
            End If
          
            PayNow2.SpidcRefNo = spidcrefno
            PayNow2.TransactionType = _nClass.Get_PaymentDetails("[TYPE]", "TXNREFNO", spidcrefno)
            PayNow2.Email = _nClass.Get_PaymentDetails("EMAILADDR", "TXNREFNO", spidcrefno)
            PayNow2.Gateway_Selected = _nClass.Get_PaymentDetails("PaymentChannel", "TXNREFNO", spidcrefno)
            PayNow2.ACCTNO = _nClass.Get_PaymentDetails("acctno", "TXNREFNO", spidcrefno)
            PayNow2.RawAmount = _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", spidcrefno)
            PayNow2.OtherFee = _nClass.Get_PaymentDetails("FeeAmount", "TXNREFNO", spidcrefno)
            PayNow2.TotalAmount = _nClass.Get_PaymentDetails("TotAmount", "TXNREFNO", spidcrefno)

            _nClass.Insert_History2(Session("acquirementStatus"), Session("shortTransId"))
            Response.Redirect("Account.aspx")
            Exit Sub

        ElseIf _sqlDateNow > CDate(Session("EndDate")) Then
            OrderCancel(Session("acquirementId"), Session("MerchantID"), err)
            Timer1.Enabled = False
            Response.Redirect("Account.aspx")
        Else
            CreateQuery(Session("merchantTransId"), Session("shortTransId"), Session("acquirementId"))
        End If

    End Sub
    Sub do_eor(ByVal GatewaySTatus As String, ByVal SPIDCREFNO As String, ByVal gatewayRefNo As String)
        Try
            Dim isTaxpayer As Boolean = True
            Dim err As String = Nothing
            Dim eORNO As String = Nothing
            Dim _nclass As New cDalPayment
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nclassGetModules As New cDalGetModules
            Dim _nclassEOR As New eOR
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            Dim _nClassPost As New Process

            If GatewaySTatus = "SUCCESS" Then

                If cInit_eOR.Initialize_EOR(SPIDCREFNO, Report_EOR, "GCASH", gatewayRefNo) = True Then GoTo jumphere

                If _nclassEOR.isEOR_Exists(SPIDCREFNO) = False Then

                    Process.ACCTNO = _nclassEOR.getACCTNO(SPIDCREFNO)
                    cSessionLoader._pTDN = _nclassEOR.getTDN(Process.ACCTNO)
                    Process.Gateway_Selected = "GCASH"
                    Process.GatewayRefNo = gatewayRefNo
                    eOR.Gateway_RefNo = gatewayRefNo
                    eOR.TaxPayerEmail = _nclassEOR.getEMAIL(SPIDCREFNO)
                    Process.TransactionType = _nclassEOR.getTransactionType(SPIDCREFNO)
                    eOR.SPIDC_RefNo = SPIDCREFNO
                    _nClassPost.START_POSTING(err, eORNO, isTaxpayer, gatewayRefNo)
                    _GenerateReport_eOR(1, Process.TransactionType, eORNO)

jumphere:
                    '     Response.Write("<script>alert('E-OR has been sent to your EMAIL.');window.location.replace('WebPortal/Account.aspx');</script>")
                    '_ExportToPDF("EOR", eORNO, err)
                    'If String.IsNullOrEmpty(err) = False Then
                    '    Response.Write("<script>alert('" & err & "');window.location.replace('WebPortal/Account.aspx');</script>")
                    'Else
                    '    Response.Write("<script>alert('E-OR has been sent to your EMAIL.');window.location.replace('WebPortal/Account.aspx');</script>")
                    'End If
                End If




            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try
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

                    ' ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');window.location.replace('../Account.aspx');", True)
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

    Public Sub _ExportToPDF(ByVal DocType As String, Optional ByVal ID As String = Nothing, Optional ByRef err As String = Nothing)
        Dim line_ctr As integer = 0

        Try
            Dim warnings As Warning()
            Dim streamIds As String()
            Dim contentType As String
            Dim encoding As String
            Dim extension As String

            'Export the RDLC Report to Byte Array.
            Dim bytes As Byte() = Report_EOR.LocalReport.Render("PDF", Nothing, contentType, encoding, extension, streamIds, warnings)
            'Download the RDLC Report in Word, Excel, PDF and Image formats.
            line_ctr = 1
            Response.Clear()
            line_ctr = 2
            Response.Buffer = True
            line_ctr = 3
            Response.Charset = ""
            line_ctr = 4
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            line_ctr = 5
            Response.ContentType = contentType
            line_ctr = 6
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & DocType & "_" & ID & ".pdf")
            line_ctr = 7
            Response.BinaryWrite(bytes)
            line_ctr = 8
            Response.Flush()
            line_ctr = 9
            Response.End()
            line_ctr = 10

           

        Catch ex As Exception
            err = line_ctr & ":" & ex.Message
            Return
            '   Response.Write(line_ctr & ":" & ex.Message)
        End Try

        '
    End Sub
    Sub WriteLogs(ByVal _function As String, ByVal _Type As String, ByVal _JSON As String)
        'Response.Write("<table style='border-collapse: collapse;width: 800px;'>")
        'Response.Write("<tr>")
        'Response.Write("<th style='border: 1px solid #ddd;padding: 8px;text-align: left;background-color: gray;color: white;'>")
        'Response.Write(_function & " : " & _Type)
        'Response.Write("</th>")
        'Response.Write("</tr>")
        'Response.Write("<tr>")
        'Response.Write("<td style='border: 1px solid #ddd;padding: 8px;'>")
        'Response.Write(_JSON)
        'Response.Write("</th>")
        'Response.Write("</tr>")
        'Response.Write("</table>")
        'Response.Write("</br></br>")
        'Response.Write("<script>")
        'Response.Write("console.log('" & _function & " : " & _Type & "')")
        'Response.Write("console.log('" & _JSON & "')")
        'Response.Write("</script>")


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
                        , Amount _
                        , "0" _
                        , Amount _
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

    Sub CreateQuery_1stTime(ByVal _merchantTransId As String, ByVal _shortTransId As String, ByVal _acquirementId As String)
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

            If VerifySignature(Response_OriginalString, res("signature")) = True Then
                Q_acquirementStatus = res("response")("body")("statusDetail")("acquirementStatus")
                Session("acquirementStatus") = Q_acquirementStatus
                'SAVE REQUEST FROM SPIDC
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass.GCASH_InsertLog(_function, _transactionId, _merchantTransId, body, "Request from SPIDC", _acquirementId, _signature)

                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubUpdateOnlinePaymentInfo(SPIDCRefNo _
                    , Q_Status _
                    , Q_GateWayRefNo _
                    , Q_Security _
                    , Q_trxdate _
                    , Amount _
                    , "0" _
                    , Amount _
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

        Catch ex As Exception

        End Try

    End Sub
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
            objReq.request.head.reqMsgId = ReqMsgID
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

    Private Sub btnCancel_ServerClick(sender As Object, e As EventArgs) Handles btnCancel.ServerClick
        Dim Err As String = Nothing
        OrderCancel(txtacquirementId.Value, txtmerchantId.Value, Err)
        Response.Write(Err)

    End Sub



End Class