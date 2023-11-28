Imports RestSharp

Public Class Transaction_Checker
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim _nClass As New cDalPayment
        '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '_nClass.GCASH_OrderCreate(_function, _transactionId, _merchantTransId, body, "Request from SPIDC", _acquirementId, _signature)

    End Sub
    Sub Close_ExpiredGcash()
        'Try
        '    Dim objReq As New GCash_OrderCancel.Gcash_OrderCancel
        '    objReq.request = New GCash_OrderCancel.Request()
        '    objReq.request.head = New GCash_OrderCancel.Head()
        '    objReq.request.body = New GCash_OrderCancel.Body()

        '    'Head
        '    objReq.request.head.version = "2.0"
        '    objReq.request.head._function = "gcash.acquiring.order.cancel"
        '    objReq.request.head.clientId = ClientID
        '    objReq.request.head.clientSecret = ClientSecret
        '    objReq.request.head.reqTime = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssK")
        '    objReq.request.head.reqMsgId = SPIDCRefNo & "-" & ReqMsgID
        '    objReq.request.body.acquirementId = _acquirementId
        '    objReq.request.body.merchantId = _merchantId

        '    objReq.signature = "signature string"

        '    Dim client = New RestClient(GCashDomain)
        '    client.Timeout = -1
        '    Dim request = New RestRequest("gcash/acquiring/order/query.htm", Method.POST)
        '    Dim body = serializer.Serialize(objReq)

        '    body = body.Replace("_function", "function")

        '    Dim StringToSign As String = Nothing
        '    StringToSign = body.Remove(0, 11) ' Remove "request":
        '    StringToSign = StringToSign.Replace(",""signature"":""signature string""}", "")
        '    Dim signedString As String = Do_Sign(StringToSign)
        '    body = body.Replace("signature string", signedString)
        '    request.AddParameter("application/json", body, ParameterType.RequestBody)

        '    Dim _function As String = objReq.request.head._function
        '    Dim _transactionId As String = _shortTransId
        '    Dim _signature As String = signedString
        '    Dim _nClass As New cDalPayment

        '    'SAVE REQUEST FROM SPIDC
        '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '    _nClass.GCASH_OrderCreate(_function, _transactionId, _merchantTransId, body, "Request from SPIDC", _acquirementId, _signature)

        '    Dim response1 As IRestResponse = client.Execute(request)
        '    Res_JSON = response1.Content

        '    '  Dim Response_OriginalString
        '    '  Dim index As Integer = response1.Content.LastIndexOf(","c)
        '    '  Response_OriginalString = response1.Content.Remove(index)
        '    '  Response_OriginalString = Response_OriginalString.Remove(0, 12) ' Remove "response":
        '    '   Response.Write(Response_OriginalString)
        '    Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(response1.Content)

        '    body = response1.Content
        '    _function = res("response")("head")("function")
        '    _transactionId = res("response")("body")("transactionId")
        '    _merchantTransId = res("response")("body")("merchantTransId")
        '    _acquirementId = res("response")("body")("acquirementId")
        '    _signature = res("signature")

        '    'SAVE RESPONSE FROM GCASH
        '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '    _nClass.GCASH_OrderCreate(_function, _transactionId, _merchantTransId, body, "Response from GCASH", _acquirementId, _signature)

        '    '  Response.Write(res("signature"))

        '    '  Response.Write("</br>--------------------------------------------------------")
        '    '  Response.Write("JSON to POST : </br>")
        '    '  Response.Write(body & "</br>")
        '    '  Response.Write("</br>")
        '    '  Response.Write("OriginalString to POST : </br>")
        '    '  Response.Write(Response_OriginalString & "</br>")
        '    '  Response.Write("</br>")
        '    '  Response.Write("Response Signature : </br>")
        '    '  Response.Write(res("signature") & "</br>")
        '    '  Response.Write("</br>")
        '    '  Response.Write("Response String : </br>")
        '    '  Response.Write(Response_OriginalString & "</br>")
        '    '  Response.Write("-------------------------------------------------------- </br> </br>")


        '    'If VerifySignature(Response_OriginalString, res("signature")) = True Then

        '    '    '--UPDATE PREVIOUS RECORD BEFORE REDIRECT

        '    '    Dim _nClass As New cDalPayment
        '    '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '    '    _nClass._pSubUpdateOnlinePaymentInfo(SPIDCRefNo _
        '    '        , res("response")("body")("resultInfo")("resultMsg") _
        '    '        , res("response")("body")("transactionId") _
        '    '        , res("response")("body")("acquirementId") _
        '    '        , res("response")("head")("respTime") _
        '    '        , Amount _
        '    '        , "0" _
        '    '        , Amount _
        '    '        , "SUCCESS" _
        '    '        , "GCASH")
        '    '    Dim checkoutURL As String = res("response")("body")("checkoutUrl")
        '    '    ' Response.Redirect(res("response")("body")("checkoutUrl"))
        '    '    '  ClientScript.RegisterStartupScript(Me.[GetType](), "OpenWindow", "window.open('" & checkoutURL & "','_blank');", True)
        '    '    Response.Write("<script>window.open ('" & checkoutURL & "','_blank');</script>")
        '    'Else
        '    '    Response.Write(VerifySignature(Response_OriginalString, res("signature")))
        '    'End If
        'Catch ex As Exception
        '    ' Err = ex.Message
        'End Try


    End Sub
End Class