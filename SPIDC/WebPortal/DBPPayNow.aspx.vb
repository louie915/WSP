Imports System.Net
Imports System.Net.WebClient
Imports System.Security.Cryptography

Public Class DBPPayNow
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim PostURL As String

        If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("ILOILO") = True Then
            PostURL = "https://cas-tst.apollo.com.ph/transaction/verify"
        End If

        Dim pay As New cDalPayment
        Dim terminalID As String = pay.DBP_terminalID
        Dim referenceCode As String = pay.DBP_referenceCode
        Dim amount As String = pay.DBP_amount
        Dim securityToken As String = pay.DBP_securityToken
        Dim returnURL As String = pay.DBP_returnURL
        Dim serviceType As String = pay.DBP_serviceType

        Response.Clear()
        'Response.Write("Redirecting to DBP...")
        Dim sb = New System.Text.StringBuilder()
        sb.Append("<html>")
        ' sb.Append("<head> <style type='text/css'> body, html {margin: 0; padding: 0; height: 100%; overflow: hidden;}</style></head>")
        sb.AppendFormat("<body onload='document.forms[0].submit()'>")
        ' sb.AppendFormat("<body>")
        sb.AppendFormat("<form target='_blank' action='" & PostURL & "' method='post'>")
        sb.AppendFormat("<input type='text' name='terminalID' value='{0}'>", terminalID)
        sb.AppendFormat("<br><input type='text' width='300px' name='referenceCode' value='{0}'>", referenceCode)
        sb.AppendFormat("<br><input type='text' width='300px' name='amount' value='{0}'>", amount)
        sb.AppendFormat("<br><input type='text' width='300px' name='securityToken' value='{0}'>", securityToken)
        sb.AppendFormat("<br><input type='text' width='300px' name='returnURL' value='{0}'>", returnURL)
        sb.AppendFormat("<br><input type='text' width='300px' name='serviceType' value='{0}'>", serviceType)
        sb.Append("<br><input type='submit'>")
        sb.Append("</form>")

        '  sb.Append("<iframe width='100%' height='100%' name='my-iframe' src='" & PostURL & "'></iframe>")
        sb.Append("</body>")
        sb.Append("</html>")
        '    Response.AddHeader("Refresh", "3; url=account.aspx")
        Response.Write(sb.ToString())
        Response.[End]()

    End Sub


End Class