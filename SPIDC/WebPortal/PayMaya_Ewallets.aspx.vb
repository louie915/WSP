Imports RestSharp
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Net.Mail
Imports RestSharp.Serializers
Imports Newtonsoft.Json

Public Class PayMaya_Ewallets
    Inherits System.Web.UI.Page
    Public Shared SK As String ' =' "sk-X8qolYjy62kIzEbr0QRK1h4b4KDVHaNcwMYk39jInSl"
    Dim SKPASS As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        CreateCheckout()
    End Sub

    
    Private Sub CreateCheckout()
        Dim client = New RestClient("https://pg-sandbox.paymaya.com/checkout/v1/checkouts")
        Dim request = New RestRequest(Method.POST)
        request.AddHeader("Accept", "application/json")
        request.AddHeader("Content-Type", "application/json")
        request.AddHeader("Authorization", "Basic " & Base64Encode(SK & ":" & SKPASS))
        request.AddParameter("application/json", "{""totalAmount"":{""value"":100,""currency"":""PHP""},""buyer"":{""contact"":{""phone"":""6464646"",""email"":""lugarestom@gmail.com""},""billingAddress"":{""line1"":""1"",""line2"":""2"",""city"":""Pasig City"",""state"":""Metro Manila"",""zipCode"":""1600"",""countryCode"":""PH""},""firstName"":""Tom"",""middleName"":""C"",""lastName"":""Lugares"",""birthday"":""2000-07-24"",""sex"":""M"",""customerSince"":""2022-07-24""},""items"":[{""amount"":{""details"":{""subtotal"":""100"",""discount"":""0"",""serviceCharge"":""0"",""shippingFee"":""0"",""tax"":""0""},""value"":100},""totalAmount"":{""details"":{""subtotal"":""100"",""discount"":""0"",""serviceCharge"":""0"",""shippingFee"":""0"",""tax"":""0""},""value"":100},""name"":""test"",""quantity"":""1"",""code"":""test"",""description"":""test""}],""redirectUrl"":{""success"":""https://ptsv2.com/t/k2ovt-1662085943/post"",""failure"":""https://ptsv2.com/t/k2ovt-1662085943/post"",""cancel"":""https://ptsv2.com/t/k2ovt-1662085943/post""},""requestReferenceNumber"":""09022022-00001""}", ParameterType.RequestBody)
        Dim responseX As IRestResponse = client.Execute(request)
        Response.Write(responseX)
    End Sub
    Public Shared Function Base64Encode(ByVal plainText As String) As String
        Dim plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText)
        Return System.Convert.ToBase64String(plainTextBytes)
    End Function

End Class