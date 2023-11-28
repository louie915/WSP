Public Class PaymentConfirmation_SPIDCPAYaspx
    Inherits System.Web.UI.Page
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim statusID As String = Nothing
            Dim ACCTNO As String = Nothing
            Dim PaymentRefNo As String = Request.QueryString("PaymentRefNo")
            Dim BillingValidityDate As String = Request.QueryString("BillingValidityDate")
            Dim Status As String = Request.QueryString("Status")
            Dim PaymentOption As String = Request.QueryString("PaymentOption")
            Dim ConvinienceFee As String = Request.QueryString("ConvinienceFee")
            Dim BillingAmt As String = Request.QueryString("BillingAmt")
            Dim TotalAmount As String = Request.QueryString("TotalAmount")
            Dim OriginURL As String = Request.QueryString("OriginURL")
            Dim Note As String = Request.QueryString("Note")
            Response.Clear()
            Response.Write("Checking status, please wait...")
            Dim sb = New System.Text.StringBuilder()
            sb.Append("<html>")
            sb.AppendFormat("<body onload='document.forms[0].submit()'>")
            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetACCTNO(PaymentRefNo, ACCTNO)

            Dim Sent As Boolean = False
            Dim Body As String = Nothing

            statusID = "SUCCESS"

            Body = "Dear Valued Tax Payer, <br> " & _
                   "This confirms your bill payment transaction with the following details: <br> " & _
                   "Transaction Number: " & PaymentRefNo & "<br>" & _
                   "Transaction Type: " & _nClass.Get_PaymentDetails("TYPE", "TXNREFNO", PaymentRefNo) & " Payment<br>" & _
                   "Account No. : " & ACCTNO & "<br>" & _
                   "Amount Paid : " & TotalAmount & "<br> <br>"
            cDalNewSendEmail.SendEmail(_nClass.Get_PaymentDetails("EMAILADDR", "TXNREFNO", PaymentRefNo), "Online Payment Confirmation", Body, Sent)

            _nClass._pSubUpdateOnlinePaymentInfo(PaymentRefNo _
                , Status _
                , PaymentRefNo _
                , PaymentRefNo _
                , Date.Now _
                , _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", PaymentRefNo) _
                , _nClass.Get_PaymentDetails("FeeAmount", "TXNREFNO", PaymentRefNo) _
                , _nClass.Get_PaymentDetails("totAmount", "TXNREFNO", PaymentRefNo) _
                , statusID _
                , PaymentOption)
            Dim type As String = String.Concat(PaymentRefNo.Where(AddressOf Char.IsLetter))
            _nClass.Insert_History(PaymentRefNo, type, PaymentOption, ACCTNO, TotalAmount, TotalAmount, 0, Status, PaymentRefNo)
            sb.AppendFormat("<input type='hidden' name='PaymentRefNo' value='{0}'>", PaymentRefNo)
            sb.AppendFormat("<input type='hidden' name='BillingValidityDate' value='{0}'>", BillingValidityDate)
            sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", Status)
            sb.AppendFormat("<input type='hidden' name='PaymentOption' value='{0}'>", PaymentOption)
            sb.AppendFormat("<input type='hidden' name='ConvinienceFee' value='{0}'>", ConvinienceFee)
            sb.AppendFormat("<input type='hidden' name='BillingAmt' value='{0}'>", BillingAmt)
            sb.AppendFormat("<input type='hidden' name='TotalAmount' value='{0}'>", TotalAmount)
            sb.AppendFormat("<input type='hidden' name='OriginUrl' value='{0}'>", OriginURL)
            sb.AppendFormat("<input type='hidden' name='Note' value='{0}'>", Note)
            sb.Append("</form>")
            sb.Append("</body>")
            sb.Append("</html>")
            Response.Write(sb.ToString())
            Response.[End]()



        Catch ex As Exception

        End Try
    End Sub

End Class