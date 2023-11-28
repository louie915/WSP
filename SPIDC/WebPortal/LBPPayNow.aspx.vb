Imports System.Net
Imports System.Net.WebClient
Imports System.Security.Cryptography
Imports System.IO
Imports RestSharp
Imports System.Web.Script.Serialization


Public Class LBPPayNow
    Inherits System.Web.UI.Page
    Dim txResponse As String
    Dim POST_OK As Boolean
    Dim redirectURL As String
    Public Shared referenceCode As String
    Public Shared transType As String
    Public Shared BIN_TDN As String
    Public Shared SelectedService As String
    Dim _nMachineName As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nClass2 As New cHardwareInformation
        Dim MerchantCode As String
        _nMachineName = _nClass2._pMachineName.ToUpper
        do_post()
    End Sub

    Shared Function GetHashMD5(theInput As String) As String
        Using hasher As MD5 = MD5.Create()
            Dim dbytes As Byte() = hasher.ComputeHash(System.Text.Encoding.UTF8.GetBytes(theInput))
            Dim sBuilder As New StringBuilder()
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n
            Return sBuilder.ToString()
        End Using
    End Function
    


    Private Sub do_post()
        Dim PostURL As String

        Dim pay As New cDalPayment
        pay._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        pay._pSubGetGatewayCredentials("LBP1")

        Dim MC As String = pay.gw_MerchantCode
        Dim MRN As String = referenceCode 'pay.LBP_MerchantRefNo
        Dim Particulars As String ' = pay.LBP_Particulars
        Dim A As String = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "") 'cSessionLoader._pTotalAmountDue 'pay.LBP_Amount
        Dim Ax As String = A.Replace(".", "")
        Dim Ay As String = Ax.Replace(",", "")
        Dim H As String = GetHashMD5(MC & MRN & Ay).ToLower
        Dim PayorName As String = cSessionUser._pFirstName & " " & cSessionUser._pLastName

        Dim RUO As String
        Dim RUE As String

        If pay.gw_LIVE = True Then
            RUO = pay.gw_ProdURL_Return
            RUE = pay.gw_ProdURL_Return
            PostURL = pay.gw_ProdURL
        Else
            RUO = pay.gw_TestURL_Return
            RUE = pay.gw_TestURL_Return
            PostURL = pay.gw_TestURL
        End If

        If _nMachineName = "WEBSVRCALOOCAN" Then
            If SelectedService = "RPT" Then
                Particulars = "transaction_type=Real Property Tax;" & _
                              "Description=" & transType & ";" & _
                              "Tax Declaration Number=" & BIN_TDN & ";" & _
                              "Online ID=" & referenceCode & ";" & _
                              "Payor Name=" & PayorName & ";" & _
                              "Email Address=" + cSessionUser._pUserID + ";"
            ElseIf SelectedService = "BP" Then
                Particulars = "transaction_type=Business Permit;" & _
                              "Description=" & transType & ";" & _
                              "Business Identification Number=" & BIN_TDN & ";" & _
                              "Online ID=" + referenceCode + ";" & _
                              "Payor Name=" & PayorName & ";" & _
                              "Email Address=" + cSessionUser._pUserID + ";"
            End If

        Else
            Particulars = "transaction_type=Real Property Tax;" & _
                       "Description=" & transType & ";" & _
                       "Tax Declaration Number=" & BIN_TDN & ";" & _
                       "Online ID=" & referenceCode & ";" & _
                       "Payor Name=" & PayorName & ";" & _
                       "E-mail Address=" + cSessionUser._pUserID + ";"
        End If

        Response.Clear()
        Response.Write("Redirecting to Land Bank Payment Portal...")
        Dim sb = New System.Text.StringBuilder()
        sb.Append("<html>")
        sb.Append("<head> <style type='text/css'> body, html {margin: 0; padding: 0; height: 100%; overflow: hidden;}</style></head>")
        sb.AppendFormat("<body onload='document.forms[0].submit()'>")
        ' sb.AppendFormat("<body>")
        sb.AppendFormat("<form target='_blank' action='" & PostURL & "' method='post'>")
        sb.AppendFormat("<input type='text' name='MerchantCode' value='{0}'>", MC)
        sb.AppendFormat("<br><input type='text' width='1300px' name='MerchantRefNo' value='{0}'>", MRN)
        sb.AppendFormat("<br><input type='text' width='1300px' name='Particulars' value='{0}'>", Particulars)
        sb.AppendFormat("<br><input type='text' width='1300px' name='Amount' value='{0}'>", A)
        sb.AppendFormat("<br><input type='text' width='1300px' name='PayorName' value='{0}'>", PayorName)
        sb.AppendFormat("<br><input type='text' width='1300px' name='PayorEmail' value='{0}'>", cSessionUser._pUserID)
        sb.AppendFormat("<br><input type='text' width='1300px' name='ReturnURLOK' value='{0}'>", RUO)
        sb.AppendFormat("<br><input type='text' width='1300px' name='ReturnURLError' value='{0}'>", RUE)
        sb.AppendFormat("<br><input type='text' width='1300px' name='Hash' value='{0}'>", H)
        sb.Append("<br><input type='submit' style='display:none;'>")
        sb.Append("</form>")
        sb.Append("</body>")
        sb.Append("</html>")

        Response.Write(sb.ToString())
        Response.[End]()

    End Sub



End Class