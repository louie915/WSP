Imports RestSharp

Public Class ITBS_Test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

       

    End Sub

    Private Sub btnSubmit_ServerClick(sender As Object, e As EventArgs) Handles btnSubmit.ServerClick
        Dim client = New RestClient("https://devuat.smartcountry.ph/")
        client.Timeout = -1
        Dim request = New RestRequest(cmbURL.Value, Method.POST)
        Dim body = txtJSON.Value
        request.AddParameter("application/json", body, ParameterType.RequestBody)
        Dim response1 As IRestResponse = client.Execute(request)
        divResult.InnerHtml = response1.Content
    End Sub
End Class