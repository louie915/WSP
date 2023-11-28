Imports System
Imports System.Net.Http
Imports System.Text
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq
Imports System.Web.HttpResponse
Public Class cPayment

    Public Shared Function PostPaymentInfoToAPI(ByVal _nCheckoutPayload As Object) As String
        PostPaymentInfoToAPI = Nothing
        'Parse the json object in variable
        Dim _mJsonObject = JObject.Parse(_nCheckoutPayload.ToString)

        Dim url As String = "YOUR_POST_URL_HERE"

        'Parse the json object in variable
        Dim request = New JObject()
        request.Add("TransactionType", _mJsonObject("TransactionType").ToString())
        request.Add("Email", _mJsonObject("Email").ToString())
        request.Add("FirstName", _mJsonObject("FirstName").ToString())
        request.Add("MiddleName", _mJsonObject("MiddleName").ToString())
        request.Add("LastName", _mJsonObject("LastName").ToString())
        request.Add("AccountNo", _mJsonObject("AccountNo").ToString())
        request.Add("TotalAmount", _mJsonObject("TotalAmount").ToString())
        request.Add("BillingValidityDate", _mJsonObject("BillingValidityDate").ToString())
        request.Add("OtherFee", _mJsonObject("OtherFee").ToString())
        request.Add("RawAmount", _mJsonObject("RawAmount").ToString())
        request.Add("SpidcFee", _mJsonObject("SpidcFee").ToString())
        request.Add("Suffix", _mJsonObject("Suffix").ToString())
        request.Add("Url_Origin", _mJsonObject("Url_Origin").ToString())

        Dim myJson = request.ToString()

        Dim content = New StringContent(myJson, Encoding.UTF8, "application/json")

        Dim client As HttpClient = New HttpClient()

        ' Add token authorization header
        Dim token As String = cSessionUser._pKeyToken
        client.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token)

        ' Add other headers if necessary
        'client.DefaultRequestHeaders.Add("Authrization", "HeaderValue1")

        ' Post the data
        Dim response As HttpResponseMessage = client.PostAsync(url, content).Result

        ' Get the response content
        Dim responseContent As String = response.Content.ReadAsStringAsync().Result

        ' Display the response
        Console.WriteLine(responseContent)
        Dim _mJsonResponse = JObject.Parse(responseContent.ToString)

        If _mJsonResponse("Status").ToString().ToLower = "success" Then
            Return _mJsonResponse("CheckoutURL").ToString().ToLower
        End If


    End Function

End Class
