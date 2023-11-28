Imports System.Net
Imports System.Security.Cryptography
Imports RestSharp

Public Class PaymentStatusInquiry
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCheck_ServerClick(sender As Object, e As EventArgs) Handles btnCheck.ServerClick
        Try
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            Select Case _nClass.Get_GateWayUsed(Trim(txtRefNo.Value).ToUpper)
                Case "LBP1"
                    do_LBP1()
                Case "LBP2"


            End Select


        Catch ex As Exception

        End Try
    End Sub

    Sub do_LBP1()
        Try
            '   ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubGetGatewayCredentials("LBP1")

            Dim Hash As String = _nClass.GetHashMD5(cDalPayment.gw_MerchantCode & Trim(txtRefNo.Value).ToUpper & cDalPayment.gw_SecretKey).ToLower()
            Dim URI As String
            If cDalPayment.gw_LIVE = True Then
                URI = cDalPayment.gw_ProdURL
            Else
                URI = cDalPayment.gw_TestURL
            End If

            '   https://epaymentportal.landbank.com/ws-pay1.php

            Dim post_data As String = "?MerchantCode=" & cDalPayment.gw_MerchantCode &
                                      "&MerchantRefNo=" & Trim(txtRefNo.Value).ToUpper &
                                      "&Hash=" & Hash
            Dim string_to_Post As String = URI.Replace("ws-pay1.php", "api2-status.php") & post_data
            Dim client = New RestClient(string_to_Post)
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            Dim _response As IRestResponse = client.Execute(request)
            Response.Write(_response.Content)
       
            div_Result.InnerText = Nothing
            div_Result.InnerHtml += "string_to_Post : " & string_to_Post & "<br>"
            '   div_Result.InnerHtml += "Posted String : " & string_to_Post & "<br>"
            div_Result.InnerHtml += "MerchantCode : " & cDalPayment.gw_MerchantCode & "<br>"
            div_Result.InnerHtml += "MerchantRefNo : " & Trim(txtRefNo.Value).ToUpper & "<br>"
            div_Result.InnerHtml += "SecretKey : " & cDalPayment.gw_SecretKey & "<br>"
            div_Result.InnerHtml += "Hash : " & Hash & "<br><br>"
            div_Result.InnerHtml += "Result : <br> " & _response.Content
        Catch ex As Exception
            div_Err.InnerText += ex.Message
        End Try
    End Sub
End Class