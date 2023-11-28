Public Class Confirm_LBPEPS
    Inherits System.Web.UI.Page
    Public Property Checksum As String
    Public Property ErrorCode As String
    Public Property LBPConfDate As String
    Public Property LBPConfNum As String
    Public Property LBPRefNum As String
    Public Property MerchantRefNum As String
    Public Property TrxnAmount As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Checksum = Request.Form("Checksum")
            ErrorCode = Request.Form("ErrorCode")
            LBPConfDate = Request.Form("LBPConfDate")
            LBPConfNum = Request.Form("LBPConfNum")
            LBPRefNum = Request.Form("LBPRefNum")
            MerchantRefNum = Request.Form("MerchantRefNum")
            TrxnAmount = Request.Form("TrxnAmount")

            Dim ACCTNO As String = Nothing
            Dim PayorEmail As String = Nothing
            Dim statusID As String = Nothing
            Dim PAYMENTCHANNEL As String = Nothing
            Dim PayorName As String = Nothing
            Dim Sent As Boolean = False
            Dim Body As String = Nothing
            Dim Type As String = Nothing
            Dim NumDesc As String = Nothing
            Dim ErrorDesc As String = Nothing
            Dim Origin_URL As String = "WebPortal/Account.aspx"

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetPayorInfo(MerchantRefNum, PayorEmail, PAYMENTCHANNEL, PayorName, ACCTNO,Type)

            If Type = "BP" Then
                NumDesc = "BIN"
                Type = "Business Permit"

            ElseIf Type = "RPT" Then
                NumDesc = "Assessment Number"
                Type = "Real Property Tax"

            ElseIf Type = "OBO" Then
                NumDesc = "Application Number"
                Type = "OBO Permit"

            ElseIf Type = "LCR" Then
                NumDesc = "Account Number"
                Type = "TEST Certificate"

            End If

            If ErrorCode = "0000" Then
                '0000  = Transaction Completed Successfully    
                statusID = "SUCCESS"

                Body = "Dear Valued Tax Payer, <br> " & _
                       "This confirms your bill payment transaction with the following details: <br> " & _
                       "Transaction Number: " & MerchantRefNum & "<br>" & _
                       "Transaction Type: " & Type & "<br>" & _
                       "" & NumDesc & " : " & ACCTNO & "<br>" & _
                       "Amount Paid : " & TrxnAmount & "<br> <br>"
                cDalNewSendEmail.SendEmail(PayorEmail, Type, Body, Sent)
            Else
                statusID = "FAILED"
            End If
            _nClass._pSubGetEpsErrorCode(ErrorCode, ErrorDesc)
            _nClass._pSubUpdateOnlinePaymentInfo(_MerchantRefNum _
                , ErrorCode & ":" & ErrorDesc _
                , LBPRefNum _
                , Checksum _
                , LBPConfDate _
                , _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", _MerchantRefNum) _
                , _nClass.Get_PaymentDetails("FeeAmount", "TXNREFNO", _MerchantRefNum) _
                , _nClass.Get_PaymentDetails("TotAmount", "TXNREFNO", _MerchantRefNum) _
                , statusID _
                , PAYMENTCHANNEL)

            Response.Clear()
            Dim sb = New System.Text.StringBuilder()
            sb.Append("<html>")
            '  sb.AppendFormat("<body onload='document.forms[0].submit()'>")
            sb.AppendFormat("<body>")
            sb.AppendFormat("<form action='PaymentNotification.aspx' method='post'>")
            sb.AppendFormat("<input type='text' name='MerchantCode' value='{0}'>", cDalPayment.gw_MerchantCode)
            sb.AppendFormat("<br><input type='text' style='display:none;' name='" & NumDesc & "' value='{0}'>", Origin_URL)
            sb.AppendFormat("<br><input type='text' style='display:none;' name='Origin_URL' value='{0}'>", Origin_URL)
            sb.Append("</form>")
            sb.Append("</body>")
            sb.Append("</html>")
            Response.Write(sb.ToString())
            Response.[End]()


        Catch ex As Exception

        End Try
    End Sub

End Class