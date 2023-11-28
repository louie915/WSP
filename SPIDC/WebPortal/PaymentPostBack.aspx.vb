Imports VB.NET.Email
Imports System.IO
Imports System.Net.Mail
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Imports System.Text
Imports System.Security.Cryptography


Imports System.Net
Imports System
Imports System.Globalization
Public Class PaymentPostBack
    Inherits System.Web.UI.Page
    Dim merchantid As String
    Dim merchantpwd As String
    Dim txnid As String
    Dim description As String
    Dim email As String
    Dim procid As String
    Dim ccy As String
    Dim refno As String
    Dim digest As String
    Dim invalid As String
    Dim BPL_PostBackURL As String
    Dim RPT_PostBackURL As String
    Dim status_desc As String
    Dim MerchantCode, DateStamp, MerchantRefNo, Particulars, Amount, PayorName, PayorEmail, Status, EppRefNo, PaymentOption As String
    Dim referenceCode As String
    Dim DevelopmentMode As Boolean
    Dim Bank_Used As String
    Dim PaymentFor As String
    Dim done As Boolean
    Dim statusID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim nvc As NameValueCollection = Request.QueryString
        Dim LBPStatus
        Dim Test As Boolean = False
        If done = True Then Exit Sub

        referenceCode = Request.QueryString("referenceCode")
        txtInitial.InnerText = cSessionLoader._pType


        ' Dim _nClass2 As New cHardwareInformation
        ' Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
        ' Select Case _nMachineName
        '   Case "WEBSVRCALOOCAN"
        '       If Request.QueryString("SelectedBank") = "OTC" Then
        '           OTC_POSTBACK()
        '           Exit Sub
        '       Else
        '           LBP_PostBack()
        '           Exit Sub
        '       End If
        '   Case Else

        If Request.QueryString("SelectedBank") = "SPIDCPay" Then
            SPIDCPay_POSTBACK()

        ElseIf Request.QueryString("SelectedBank") = "DBP" Then
            DBP_POSTBACK()

        ElseIf Request.QueryString("SelectedBank") = "LBP" Then
            LBP_PostBack()

        ElseIf Request.QueryString("SelectedBank") = "OTC" Then
            OTC_POSTBACK()
        ElseIf Request.QueryString("SelectedBank") = "GCASH" Then
            GCash_POSTBACK()

        Else
            Response.Write("<script>alert('0 - Fail');</script>")
            _oLabelTransactionNumber.InnerText = Request.Form("MerchantRefNo")
            _oLabelDateTime.InnerText = Date.Now
            _oLabelAmount.InnerText = Request.Form("Amount")
            LBLnOTE.InnerText = "Payment Failed"
            h5.InnerText = "Payment Failed"

            ' Response.Write("<script>alert([" & Request.QueryString("SelectedBank") & "]-Bank not found);</script>")

            Exit Sub
        End If
        '  End Select
        done = True

    End Sub

    Sub DBP_POSTBACK()


        Dim Subject As String
        Dim ACCT As String
        Dim ACCTID As String


        Bank_Used = "DBP"
        Dim stat As String = Nothing
        Dim _nclass As New cDalPayment
        If Request.QueryString("message") = "Successful approval/completion." Then
            stat = Request.QueryString("message")
            statusID = "SUCCESS"
            Select Case PaymentFor
                Case "BP"
                    Subject = "Business Permit Payment"
                    ACCT = "Account Number"
                    ACCTID = cSessionLoader._pAccountNo
                    _oLabelPeriodCovered.InnerText = cSessionLoader._pPeriodCovered
                    _mSubUpdate()
                Case "RPT"
                    Subject = "Real Property Payment"
                    ACCTID = cSessionLoader._pAssessNo
                    ACCT = "Assessment Number"
                    _mSubUpdateRPT()
                Case "CTC"
                    Subject = "Cedula Payment"
                    ACCTID = cSessionLoader._pAccountNo
                    ACCT = "Control Number"
                    _mSubUpdateCTC(stat)

                Case "CertRPT"
                    Subject = "Certificate Payment"
                    ACCTID = cDalCertificationAss._pUnique
                    ACCT = "Control Number"
                    saveCertRequestNoRPT(stat)

                Case "CertBP"
                    Subject = "Certificate Payment"
                    ACCT = "Control Number"
                    ACCTID = cDalCertificationAss._pUnique
                    saveCertRequestNoBP(stat)

                Case "1CertRPT"
                    Subject = "Certificate Payment"
                    ACCTID = cSessionLoader._pTDN
                    ACCT = "Tax Declaration Number"
                    _1certrpt(stat)

                Case "1CertBP"
                    Subject = "Certificate Payment"
                    ACCTID = cSessionLoader._pAccountNo
                    ACCT = "Business ID Number"
                    _1certbp(stat)

                Case Else
                    Response.Write("<script>alert(Invalid Credentials);</script>")
                    Exit Sub
            End Select

        Else
            stat = "Failed: " & Request.QueryString("message")
            statusID = "FAILED"
        End If

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubUpdateOnlinePaymentInfo(referenceCode _
            , stat _
            , Request.QueryString("retrievalReferenceCode") _
            , Request.QueryString("securityToken") _
            , Request.QueryString("date") _
            , Request.QueryString("amount") _
            , Request.QueryString("serviceChargeFee") _
            , Request.QueryString("total") _
            , statusID, "")

        _oLabelTransactionNumber.InnerText = Request.QueryString("referenceCode")
        _oLabelDateTime.InnerText = Request.QueryString("date")
        _oLabelTransactionType.InnerText = Request.QueryString("serviceType")
        _oLabelAmount.InnerText = Request.QueryString("total")

        If Request.QueryString("message") = "Successful approval/completion." Then

        Else

        End If

        'send email to taxpayer
        Dim Sent As Boolean
        Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                             "This confirms your bill payment transaction with the following details: <br> " & _
                             "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                             "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                             "" & ACCT & " : " & ACCTID & "<br>" & _
                             "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                             "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                             "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
        cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)

    End Sub
    Sub LBP_PostBack()
        Try

            'Dim ctr = 0
            'For Each key As String In Request.Form.Keys
            '    ctr = ctr + 1
            '    Response.Write(key & "=" & Request.Form(key) & "<br/>")
            '    If ctr = 8 Then PaymentOption = Request.Form(key)
            'Next

            Dim subject
            Dim acctid
            Dim acct

            Amount = Request.Form("Amount")
            DateStamp = Request.Form("Datestamp")
            referenceCode = Request.Form("MerchantCode")
            EppRefNo = Request.Form("EppRefNo")
            MerchantCode = Request.Form("MerchantCode")
            MerchantRefNo = Request.Form("MerchantRefNo")
            Particulars = Request.Form("Particulars")
            PaymentOption = Request.Form("PaymentOption")
            PayorEmail = Request.Form("PayorEmail")
            PayorName = Request.Form("PayorName")

            Dim LBPStatus = Request.Form("Status")

            Select Case LBPStatus
                Case "00"
                    LBPStatus = "Successful"
                Case "01"
                    LBPStatus = "Invalid merchant code"
                Case "02"
                    LBPStatus = "Invalid merchant reference number"
                Case "03"
                    LBPStatus = "0 or negative amount"
                Case "04"
                    LBPStatus = "Null payors name"
                Case "05"
                    LBPStatus = "Null returnURLok"
                Case "06"
                    LBPStatus = "Null returnURLerror"
                Case "07"
                    LBPStatus = "invalid(hash)"
                Case "08"
                    LBPStatus = "Service unavailable"
                Case "09"
                    LBPStatus = "Transaction in process"
                Case "10"
                    LBPStatus = "Cancelled transaction"
                Case "11"
                    LBPStatus = "EPP offline"
                Case "12"
                    LBPStatus = "Invalid transaction type"
                Case "13"
                    LBPStatus = "invalid(Particulars)"
                Case "14"
                    LBPStatus = "Duplicate transaction"
            End Select

            If MerchantRefNo.Substring(0, 2) = "BP" Then
                PaymentFor = "BP"
            ElseIf MerchantRefNo.Substring(0, 3) = "RPT" Then
                PaymentFor = "RPT"
            ElseIf MerchantRefNo.Substring(0, 3) = "CTC" Then
                PaymentFor = "CTC"
            Else
                PaymentFor = cSessionLoader._pService
            End If

            Bank_Used = "LBP"

            Dim _nclass As New cDalPayment

            Select Case PaymentFor
                Case "BP"
                    subject = "Business Permit Payment"
                    acct = "Account Number"
                    acctid = cSessionLoader._pAccountNo
                    _mSubUpdate()
                Case "RPT"
                    subject = "Real Property Payment"
                    acctid = cSessionLoader._pAssessNo
                    acct = "Assessment Number"
                    _mSubUpdateRPT()
                Case "CTC"
                    subject = "Cedula Payment"
                    acctid = cSessionLoader._pAccountNo
                    acct = "Control Number"
                    _mSubUpdateCTC(LBPStatus)

                Case "CertRPT"
                    subject = "Certificate Payment"
                    acctid = cDalCertificationAss._pUnique
                    acct = "Control Number"
                    saveCertRequestNoRPT(LBPStatus)

                Case "CertBP"
                    subject = "Certificate Payment"
                    acct = "Control Number"
                    acctid = cDalCertificationAss._pUnique
                    saveCertRequestNoBP(LBPStatus)

                Case "1CertRPT"
                    subject = "Certificate Payment"
                    acctid = cSessionLoader._pTDN
                    acct = "Tax Declaration Number"
                    _1certrpt(LBPStatus)

                Case "1CertBP"
                    subject = "Certificate Payment"
                    acctid = cSessionLoader._pAccountNo
                    acct = "Business ID Number"
                    _1certbp(LBPStatus)

                Case Else
                    Response.Write("<script>alert(Invalid Credentials);</script>")
                    Exit Sub
            End Select

            If Request.Form("Status") = "00" Then
                statusID = "SUCCESS"
                _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nclass._pSubUpdateOnlinePaymentInfo(referenceCode _
                    , LBPStatus _
                    , EppRefNo _
                    , GetHashMD5(MerchantRefNo).Substring(16, 16) _
                    , Date.Now _
                    , Amount _
                    , "0" _
                    , Amount _
                    , statusID, "")
                _oLabelTransactionNumber.InnerText = MerchantRefNo
                _oLabelDateTime.InnerText = Date.Now
                _oLabelTransactionType.InnerText = subject
                _oLabelAmount.InnerText = Amount
                'send email to taxpayer
                Dim Sent As Boolean
                Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                                     "This confirms your bill payment transaction with the following details: <br> " & _
                                     "Transaction Number: " & MerchantRefNo & "<br>" & _
                                     "Transaction Type: " & subject & "<br>" & _
                                     "" & acct & " : " & acctid & "<br>" & _
                                     "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                                     "Amount Paid : " & Amount & "<br> <br>" & _
                                     "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
                cDalNewSendEmail.SendEmail(PayorEmail, subject, Body, Sent)


            Else

                h5.InnerText = "PAYMENT FAILED"
                LBLnOTE.InnerText = LBPStatus
            End If

        Catch ex As Exception

        End Try


    End Sub

    Sub GCash_POSTBACK()
        Try

            'Dim ctr = 0
            'For Each key As String In Request.Form.Keys
            '    ctr = ctr + 1
            '    Response.Write(key & "=" & Request.Form(key) & "<br/>")
            '    If ctr = 8 Then PaymentOption = Request.Form(key)
            'Next

            Dim subject
            Dim acctid
            Dim acct

            Amount = Request.Form("Amount")
            DateStamp = Request.Form("Datestamp")
            referenceCode = Request.Form("MerchantCode")
            EppRefNo = Request.Form("EppRefNo")
            MerchantCode = Request.Form("MerchantCode")
            MerchantRefNo = Request.Form("MerchantRefNo")
            Particulars = Request.Form("Particulars")
            PaymentOption = Request.Form("PaymentOption")
            PayorEmail = Request.Form("PayorEmail")
            PayorName = Request.Form("PayorName")

            If MerchantRefNo.Substring(0, 2) = "BP" Then
                PaymentFor = "BP"
            ElseIf MerchantRefNo.Substring(0, 3) = "RPT" Then
                PaymentFor = "RPT"
            ElseIf MerchantRefNo.Substring(0, 3) = "CTC" Then
                PaymentFor = "CTC"
            Else
                PaymentFor = cSessionLoader._pService
            End If

            Bank_Used = "LBP"

            Dim _nclass As New cDalPayment

            Select Case PaymentFor
                Case "BP"
                    subject = "Business Permit Payment"
                    acct = "Account Number"
                    acctid = cSessionLoader._pAccountNo
                    _mSubUpdate()
                Case "RPT"
                    subject = "Real Property Payment"
                    acctid = cSessionLoader._pAssessNo
                    acct = "Assessment Number"
                    _mSubUpdateRPT()
                Case "CTC"
                    subject = "Cedula Payment"
                    acctid = cSessionLoader._pAccountNo
                    acct = "Control Number"
                    '_mSubUpdateCTC(GCashStatus)
                Case Else
                    Response.Write("<script>alert(Invalid Credentials);</script>")
                    Exit Sub
            End Select

            If Request.Form("Status") = "00" Then
                'statusID = "SUCCESS"
                '_nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                '_nclass._pSubUpdateOnlinePaymentInfo(referenceCode _
                '    ', 'GCashStatus _
                '    , EppRefNo _
                '    , GetHashMD5(MerchantRefNo).Substring(16, 16) _
                '    , Date.Now _
                '    , Amount _
                '    , "0" _
                '    , Amount _
                '    , statusID, "")
                '_oLabelTransactionNumber.InnerText = MerchantRefNo
                '_oLabelDateTime.InnerText = Date.Now
                '_oLabelTransactionType.InnerText = subject
                '_oLabelAmount.InnerText = Amount
                ''send email to taxpayer
                'Dim Sent As Boolean
                'Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                '                     "This confirms your bill payment transaction with the following details: <br> " & _
                '                     "Transaction Number: " & MerchantRefNo & "<br>" & _
                '                     "Transaction Type: " & subject & "<br>" & _
                '                     "" & acct & " : " & acctid & "<br>" & _
                '                     "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                '                     "Amount Paid : " & Amount & "<br> <br>" & _
                '                     "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
                'cDalNewSendEmail.SendEmail(PayorEmail, subject, Body, Sent)


            Else

                h5.InnerText = "PAYMENT FAILED"
                'LBLnOTE.InnerText = GCashStatus
            End If

        Catch ex As Exception

        End Try


    End Sub

    Sub SPIDCPay_POSTBACK()


        Dim Subject As String
        Dim ACCT As String
        Dim ACCTID As String

        If referenceCode.Substring(0, 2) = "BP" Then
            PaymentFor = "BP"
        ElseIf referenceCode.Substring(0, 3) = "RPT" Then
            PaymentFor = "RPT"
        ElseIf referenceCode.Substring(0, 3) = "CTC" Then
            PaymentFor = "CTC"
        ElseIf referenceCode.Substring(0, 7) = "" Then
            PaymentFor = ""
        ElseIf referenceCode.Substring(0, 6) = "" Then
            PaymentFor = ""
        Else
            PaymentFor = cSessionLoader._pService
        End If

        Bank_Used = "SPIDCPay"
        Dim stat As String = "Successful Payment"
        Dim _nclass As New cDalPayment

        Select Case PaymentFor
            Case "BP"
                Subject = "Business Permit Payment"
                ACCT = "Account Number"
                ACCTID = cSessionLoader._pAccountNo
                _mSubUpdate()

            Case "RPT"
                Subject = "Real Property Payment"
                ACCTID = cSessionLoader._pAssessNo
                ACCT = "Assessment Number"
                _mSubUpdateRPT()
            Case "CTC"
                Subject = "Cedula Payment"
                ACCTID = cSessionLoader._pAccountNo
                ACCT = "Control Number"
                _mSubUpdateCTC(stat)

            Case "CertRPT"
                Subject = "Certificate Payment"
                ACCTID = cDalCertificationAss._pUnique
                ACCT = "Control Number"
                saveCertRequestNoRPT(stat)

            Case "CertBP"
                Subject = "Certificate Payment"
                ACCT = "Control Number"
                ACCTID = cDalCertificationAss._pUnique
                saveCertRequestNoBP(stat)

            Case "1CertRPT"
                Subject = "Certificate Payment"
                ACCTID = cSessionLoader._pTDN
                ACCT = "Tax Declaration Number"
                _1certrpt(stat)

            Case "1CertBP"
                Subject = "Certificate Payment"
                ACCTID = cSessionLoader._pAccountNo
                ACCT = "Business ID Number"
                _1certbp(stat)

            Case Else
                Response.Write("<script>alert(Invalid Credentials);</script>")
                Exit Sub
        End Select

        If stat = "Successful Payment" Then
            statusID = "SUCCESS"
        Else
            statusID = "FAILED"
        End If


        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubUpdateOnlinePaymentInfo(referenceCode _
            , stat _
            , GetHashMD5(Date.Now & referenceCode & cSessionLoader._pTotalAmountDue).Substring(0, 16) _
            , GetHashMD5(Date.Now & referenceCode & cSessionLoader._pTotalAmountDue).Substring(16, 16) _
            , Date.Now _
            , cSessionLoader._pTotalAmountDue _
            , "0" _
            , cSessionLoader._pTotalAmountDue _
            , statusID, "")
        _oLabelacctID.InnerText = ACCTID
        _oLabelTransactionNumber.InnerText = Request.QueryString("referenceCode")
        _oLabelDateTime.InnerText = Date.Now
        _oLabelTransactionType.InnerText = Request.QueryString("serviceType")
        _oLabelAmount.InnerText = Request.QueryString("amount")


        'send email to taxpayer

        Dim Sent As Boolean
        Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                             "This confirms your bill payment transaction with the following details: <br> " & _
                             "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                             "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                             "" & ACCT & " : " & ACCTID & "<br>" & _
                             "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                             "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                             "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
        cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)

        If statusID = "SUCCESS" Then
            If cInit_CBPReg._Fn_CheckIfCBPApplicant = True Then
                cSessionLoader._pAccountNo = cSessionLoader._pAccountNo
                Dim _nAppDate As Date = cInit_CBPReg._Fn_GetBUSMASTAppDate
                cLoader_BPLTIMS._pEMAILADDR = cSessionUser._pUserID
                Dim _PaymentMode As String = "online payment"
                cInit_CBPReg.UpdateCBPAppStatus("BUSINESS-PERMIT-PAID", "New", _nAppDate, _PaymentMode, Nothing, Nothing, Nothing, referenceCode.ToString)
                cInit_CBPReg._InsertAppStatLog("BUSINESS-PERMIT-PAID")
            End If
        End If


    End Sub

    Sub OTC_POSTBACK()


        Dim Subject As String
        Dim ACCT As String
        Dim ACCTID As String
        Dim SOA As String

        If referenceCode.Substring(0, 2) = "BP" Then
            PaymentFor = "BP"
        ElseIf referenceCode.Substring(0, 3) = "RPT" Then
            PaymentFor = "RPT"
        ElseIf referenceCode.Substring(0, 3) = "CTC" Then
            PaymentFor = "CTC"
        ElseIf referenceCode.Substring(0, 7) = "" Then
            PaymentFor = ""
        ElseIf referenceCode.Substring(0, 6) = "" Then
            PaymentFor = ""
        Else
            PaymentFor = cSessionLoader._pService
        End If

        Bank_Used = "OTC"
        Dim stat As String = "Pending"
        Dim _nclass As New cDalPayment

        Select Case PaymentFor
            Case "BP"
                Subject = "Business Permit Payment"
                ACCT = "Account Number"
                SOA = "BPSA"
                ACCTID = cSessionLoader._pAccountNo
                _oLabelPeriodCovered.InnerText = cSessionLoader._pPeriodCovered
            Case "RPT"
                Subject = "Real Property Payment"
                ACCTID = cSessionLoader._pAssessNo
                SOA = "RPTSOA"
                ACCT = "Assessment Number"
            Case "CTC"
                Subject = "Cedula Payment"
                ACCTID = cSessionLoader._pAccountNo
                ACCT = "Control Number"
                _mSubUpdateCTC_OTC(stat)

            Case "CertRPT"
                Subject = "Certificate Payment"
                ACCTID = cDalCertificationAss._pUnique
                ACCT = "Control Number"
                saveCertRequestNoRPT(stat)

            Case "CertBP"
                Subject = "Certificate Payment"
                ACCT = "Control Number"
                ACCTID = cDalCertificationAss._pUnique
                saveCertRequestNoBP(stat)

            Case "1CertRPT"
                Subject = "Certificate Payment"
                ACCTID = cSessionLoader._pTDN
                ACCT = "Tax Declaration Number"
                _1certrpt(stat)

            Case "1CertBP"
                Subject = "Certificate Payment"
                ACCTID = cSessionLoader._pAccountNo
                ACCT = "Business ID Number"
                _1certbp(stat)

            Case Else
                Response.Write("<script>alert(Invalid Credentials);</script>")
                Exit Sub
        End Select

        BIN_ASSESSNO.InnerText = ACCT & ":"

        If stat = "Pending" Then
            statusID = "PENDING"
        Else
            statusID = "FAILED"
        End If

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubUpdateOTCPaymentInfo(referenceCode _
            , stat _
            , GetHashMD5(Date.Now & referenceCode & cSessionLoader._pTotalAmountDue).Substring(0, 16) _
            , GetHashMD5(Date.Now & referenceCode & cSessionLoader._pTotalAmountDue).Substring(16, 16) _
            , Date.Now _
            , cSessionLoader._pTotalAmountDue _
            , "0" _
            , cSessionLoader._pTotalAmountDue _
            , statusID)
        h5.InnerHtml = "OVER-THE-COUNTER PAYMENT"
        LBLAMOUNT.InnerHtml = "Amount to Pay:"
        _oLabelacctID.InnerText = ACCTID
        _oLabelTransactionNumber.InnerText = Request.QueryString("referenceCode")
        _oLabelDateTime.InnerText = Date.Now
        _oLabelTransactionType.InnerText = Request.QueryString("serviceType")
        _oLabelAmount.InnerText = String.Format("{0:n}", Convert.ToDecimal(Request.QueryString("amount")))


        Dim _nClass2 As New cHardwareInformation
        Dim _nMachineName As String = Nothing
        _nMachineName = _nClass2._pMachineName.ToUpper
        Select Case _nMachineName
            Case "WEBSVRCALOOCAN"
                LBLnOTE.InnerHtml = "NOTE: Please proceed to ""Ground flr, Caloocan City Hall, Treasury office"" and present your TRANSACTION REFNO to settle your payment.<br>" & _
                                    "Please print three(3) copies of Statement of Account(SOA) and attach filled up application form if you wish to pay over the counter at the City Hall."

            Case "GRACEVILLE"
                LBLnOTE.InnerHtml = "NOTE: Please proceed to ""Basement 2, SM City San Jose, B.O.S.S office"" and present your TRANSACTION REFNO to settle your payment."

            Case "MANDAUEWEBSVR"
                LBLnOTE.InnerHtml = "NOTE: Print and present a copy of your Statement of Account(SOA). Please proceed to Mandaue City Hall, Treasury Office."

            Case "MANOLOWEBSVR"
                LBLnOTE.InnerHtml = "NOTE: Print and present a copy of your Statement of Account(SOA). Please proceed to  Municipal Hall, Treasury Office."

            Case Else
                LBLnOTE.InnerHtml = "NOTE: Please proceed to Municipal/City Hall, Treasury Office and present your Statement of Account(SOA) to settle your payment."


        End Select

        cSessionLoader._pPSTransOTCNote = LBLnOTE.InnerHtml

        '  If PaymentFor = "RPT" Or PaymentFor = "BP" Then
        '      Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=" & SOA & "&PayNow=true','_blank');</script>")
        '  ElseIf PaymentFor = "CTC" Then
        Dim Sent As Boolean
        Dim Body As String = "Dear Valued Tax Payer, <br> " & _
              "This confirms your Over-the-counter transaction with the following details: <br> " & _
              "   <table>" & _
              "       <tr><td>" & ACCT & "</td><td>: " & ACCTID & "</td></tr>" & _
              "       <tr><td>Transaction Number</td><td>: " & Request.QueryString("referenceCode") & "</td></tr>" & _
              "       <tr><td>Transaction Type</td><td>: " & Request.QueryString("serviceType") & "</td></tr>" & _
              "       <tr><td>Date/Time</td><td>: " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & " </td>" & _
              "       </tr><tr><td>Amount to Pay</td><td>: " & String.Format("{0:C}", Request.QueryString("amount")).Replace("$", "") & "</td></tr>" & _
              "   </table>" & _
              "" & LBLnOTE.InnerHtml & "<br>" & _
              "Thank you for choosing our Web Service Portal. Have a wonderful day! <br><br>"
        cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)
        ' End If



    End Sub

    Sub snackbar(color, desc)
        Dim status As String
        If color = "red" Then
            status = "Failed: "
        Else
            status = "Success: "
        End If
        Response.Write("<script>alert('" & status & desc & "')</script>")

    End Sub

    Sub _1certbp(ByVal stat As String)
        If stat = "Successful Payment" Then
            stat = "SUCCESS"
        Else
            stat = "FAILED"
        End If
        cDalCertificationAss._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
        cDalCertificationAss._pStatus = stat
        cDalCertificationAss._pRefNo = referenceCode
        cDalCertificationAss.saveBPCertRequest()
    End Sub

    Sub _1certrpt(ByVal stat As String)
        If stat = "Successful Payment" Then
            stat = "SUCCESS"
        Else
            stat = "FAILED"
        End If
        cDalCertificationAss._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
        cDalCertificationAss._pStatus = stat
        cDalCertificationAss._pRefNo = referenceCode
        cDalCertificationAss.saveRPTCertRequest()
    End Sub

    Sub saveCertRequestNoRPT(ByVal stat As String)
        If stat = "Successful Payment" Then
            stat = "SUCCESS"
        Else
            stat = "FAILED"
        End If
        cDalCertificationAss._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
        cDalCertificationAss._pStatus = stat
        cDalCertificationAss._pRefNo = referenceCode
        cDalCertificationAss.updateRecordNoBPRPT("RPT")
    End Sub

    Sub saveCertRequestNoBP(ByVal stat As String)
        If stat = "Successful Payment" Then
            stat = "SUCCESS"
        Else
            stat = "FAILED"
        End If
        cDalCertificationAss._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
        cDalCertificationAss._pStatus = stat
        cDalCertificationAss._pRefNo = referenceCode
        cDalCertificationAss.updateRecordNoBPRPT("BP")
    End Sub

    Private Sub _mSubUpdate()
        Try
            '----------------------------------
            Dim _nClass As New cDalPayment
            '----------------------------------
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetPaidAccountNo(referenceCode)

            Select Case Bank_Used

                Case "DBP"
                    _nClass._pReferenceNumber = Request.QueryString("retrievalReferenceCode")
                    _nClass._pReferenceDate = DateTime.ParseExact(Replace(Request.QueryString("date"), "PHT ", ""), "ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture)
                    _nClass._pAccountNumber = Request.QueryString("referenceCode")
                    _nClass._pTypeofPayment = "BP"
                    _nClass._pPaymentChannel = "DBP"
                    _nClass._pTOPamount = Request.QueryString("amount")
                    _nClass._pPaymentStatus = Request.QueryString("message")
                    _nClass._pRemarks = "Paid/For Treasury Verification"
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass._pisPosted = "1"
                    _nClass._pSubUpdateBillingisPosted(_nClass._pisPosted, _nClass._pRemarks, _nClass._pBPAccountNumber)

                Case "SPIDCPay"
                    _nClass._pReferenceNumber = GetHashMD5(referenceCode)
                    _nClass._pReferenceDate = Date.Now
                    _nClass._pAccountNumber = Request.QueryString("referenceCode")
                    _nClass._pTypeofPayment = "BP"
                    _nClass._pPaymentChannel = "SPIDCPay"
                    _nClass._pTOPamount = cSessionLoader._pTotalAmountDue
                    _nClass._pPaymentStatus = "Successful Payment"
                    _nClass._pRemarks = "Successful Payment"

                    Dim _nClass2 As New cDalBPSOS

                    _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass2._pAcctNo = cSessionLoader._pAccountNo
                    _nClass2._pForYear = cSessionLoader._pFORYEAR
                    _nClass2._pEmail = cCookieUser._pUserID
                    _nClass2._pReferenceNo = Request.QueryString("referenceCode")
                    _nClass2._pAmountPaid = Request.QueryString("amount")
                    _nClass2._pDatePaid = Date.Now
                    _nClass2._pRemarks = cSessionLoader._pType
                    _nClass2._pLQP = cSessionLoader._pBPQTR
                    _nClass2._pQtr = cSessionLoader._pBPQTR
                    _nClass2._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")

                    Dim _nClBP As New cDalGlobalConnectionsDefault
                    _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                    _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                    _nClBP._pSubRecordSelectSpecific()

                    _nClass2._pLocServer = _nClBP._pDBDataSource
                    _nClass2._pLocDB = _nClBP._pDBInitialCatalog



                    If cSessionLoader._pAccountNo <> "" Then
                        _nClass2._pSubSavePaymentDetail()
                        _nClass2._pSubPaymentPosting()
                        _nClass2._pSubUPDATELEDGERACCT()

                        'TOM NEW BP START----------
                        Dim _nClass3 As New cDalNewBP
                        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                        _nClass3._pSubUpdateNewBPPaid(cSessionLoader._pAccountNo)
                        'TOM NEW BP END----------

                    End If


            End Select

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mSubUpdateRPT()
        Try
            '----------------------------------
            'Do RPT Transaction UPDATE

            Dim _nClass As New cDalPayment
            '----------------------------------
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pAssessmentNo = cSessionLoader._pAssessmentNo

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetPaidAccountNo(referenceCode)



            Select Case Bank_Used
                Case "DBP"
                    _nClass._pAssessmentNo = cSessionLoader._pAssessmentNo
                    _nClass._pRemarks = "Paid/For Treasury Verification"
                    _nClass._pisPosted = "1"
                    _nClass._pSubUpdateBillingisPosted_RPT(_nClass._pisPosted, _nClass._pRemarks, _nClass._pAssessmentNo)
            End Select



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mSubUpdateCTC(stat)
        Try
            Dim _nStatusID As String
            Dim _nClass As New cDalPayment
            '----------------------------------
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
            _nClass._pAssessmentNo = referenceCode

            If stat = "Successful Payment" Or stat = "Successful" Then
                _nStatusID = "SUCCESS"
            Else
                _nStatusID = "FAILED"
            End If

            Select Case Bank_Used
                Case "DBP"
                    _nClass._pAssessmentNo = cSessionLoader._pAssessmentNo
                    _nClass._pRemarks = "Paid/For Treasury Verification"
                    _nClass._pisPosted = "1"
                    _nClass._pSubUpdateCTC(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), _nStatusID, cSessionLoader._pAccountNo, referenceCode)

                Case Else
                    _nClass._pAssessmentNo = cSessionLoader._pAssessmentNo
                    _nClass._pRemarks = "Successful Payment"
                    _nClass._pisPosted = "1"
                    _nClass._pSubUpdateCTC(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), _nStatusID, cSessionLoader._pAccountNo, referenceCode)

            End Select



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Private Sub _mSubUpdateCTC_OTC(stat)
        Try
            Dim _nStatusID As String
            Dim _nClass As New cDalPayment
            '----------------------------------
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
            _nStatusID = "PENDING"
            _nClass._pRemarks = "PENDING"
            _nClass._pisPosted = "0"
            _nClass._pSubUpdateCTC_OTC(Format(Date.Now, "yyyy-MM-dd hh:mm:ss"), _nStatusID, cSessionLoader._pAccountNo, referenceCode)
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _SaveInformation(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = Nothing)
        Try

            Dim _nClass As New cDal_IUD
            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_TIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO CTC_Online " & _
                            " ( " & _
                            " ControlNo" & _
                            " ,CTC_Type " & _
                            " ,FirstName " & _
                            " ,MiddleName " & _
                            " ,LastName " & _
                            " ,[Address] " & _
                            " ,BirthPlace " & _
                            " ,BirthDate " & _
                            " ,CivilStatus " & _
                            " ,Citizenship " & _
                            " ,Gender " & _
                            " ,Occupation " & _
                            " ,TIN " & _
                            " ,ProfIncome " & _
                            " ,BusIncome " & _
                            " ,RPTIncome " & _
                            " ,TaxAmount " & _
                            " ,EMAIL " & _
                            " ,Penalty " & _
                            " ,Status " & _
                            " ,TransDate " & _
                            " ) " & _
                            "VALUES " & _
                            "( " & _
                            " ''" & cLoader_CTCApp._pControlNo & "''" & _
                            ",''" & cLoader_CTCApp._pCTC_Type & "''" & _
                            ",''" & cLoader_CTCApp._pFirstName & "''" & _
                            ",''" & cLoader_CTCApp._pMiddleName & "''" & _
                            ",''" & cLoader_CTCApp._pLastName & "''" & _
                            ",''" & cLoader_CTCApp._pAddress & "''" & _
                            ",''" & cLoader_CTCApp._pBirthPlace & "''" & _
                            ",''" & cLoader_CTCApp._pBirthDate & "''" & _
                            ",''" & cLoader_CTCApp._pCivilStatus & "''" & _
                            ",''" & cLoader_CTCApp._pCitizenship & "''" & _
                            ",''" & cLoader_CTCApp._pGender & "''" & _
                            ",''" & cLoader_CTCApp._pOccupation & "''" & _
                            ",''" & cLoader_CTCApp._pTIN & "''" & _
                            "," & cLoader_CTCApp._pIncome & "" & _
                            "," & cLoader_CTCApp._pGross & "" & _
                            "," & cLoader_CTCApp._pRealProperty & "" & _
                            "," & cLoader_CTCApp._pAmount & "" & _
                            ",''" & cSessionUser._pUserID & "''" & _
                            "," & cLoader_CTCApp._pPenalty & "" & _
                            ",''Pending''" & _
                            ",''" & Format(Date.Now, "MMMM dd, yyyy hh:mm:ss tt") & "''" & _
                            " )"
                ._pExec(_nSuccessful, _nErrMsg)

            End With

        Catch ex As Exception

        End Try
    End Sub


    Private Function _FnNotify_Taxpayer() As Boolean
        Try
            Select Case PaymentFor
                Case "BP"
                    Dim _nClass As New cDalSendEmail
                    With _nClass
                        ._pEmailTo = cSessionUser._pUserID
                        ._pSubject = "Business Permit Payment"
                        ._pHeader = cSessionLoader._pLGU_Name
                        ._pBody = "Dear Valued Tax Payer, <br> " & _
                                    "This confirms your bill payment transaction with the following details: <br> " & _
                                    "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                                    "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                                    "Account Number: " & cSessionLoader._pAccountNo & "<br>" & _
                                    "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                                    "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                                    "Thank you for choosing online transaction. Have a wonderful day! <br><br>" & _
                                    cSessionLoader._pLGU_Name
                        If ._pSubSendEmail() = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End With
                Case "RPT"
                    Dim _nClass As New cDalSendEmail
                    With _nClass
                        ._pEmailTo = cSessionUser._pUserID
                        ._pSubject = "Real Property Payment"
                        ._pHeader = cSessionLoader._pLGU_Name
                        ._pBody = "Dear Valued Tax Payer, <br> " & _
                                    "This confirms your bill payment transaction with the following details: <br> " & _
                                    "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                                    "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                                    "Assessment Number: " & cSessionLoader._pAssessNo & "<br>" & _
                                    "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                                    "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                                    "Thank you for choosing online transaction. Have a wonderful day! <br><br>" & _
                                    cSessionLoader._pLGU_Name
                        If ._pSubSendEmail() = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End With

                Case "CTC"
                    Dim _nClass As New cDalSendEmail
                    With _nClass
                        ._pEmailTo = cSessionUser._pUserID
                        ._pSubject = "Cedula Payment"
                        ._pHeader = cSessionLoader._pLGU_Name
                        ._pBody = "Dear Valued Tax Payer, <br> " & _
                                    "This confirms your bill payment transaction with the following details: <br> " & _
                                    "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                                    "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                                    "Control Number: " & cSessionLoader._pAccountNo & "<br>" & _
                                    "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                                    "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                                    "Thank you for choosing online transaction. Have a wonderful day! <br><br>" & _
                                    cSessionLoader._pLGU_Name
                        If ._pSubSendEmail() = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End With

                Case "1CertBP"
                    Dim _nClass As New cDalSendEmail
                    With _nClass
                        ._pEmailTo = cSessionUser._pUserID
                        ._pSubject = "Certificate Payment"
                        ._pHeader = cSessionLoader._pLGU_Name
                        ._pBody = "Dear Valued Tax Payer, <br> " & _
                                    "Thank you for paying your dues! <br>" & _
                                    "This confirms your bill payment transaction with the following details: <br> " & _
                                    "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                                    "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                                    "Business ID Number: " & cSessionLoader._pAccountNo & "<br>" & _
                                    "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                                    "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                                    "Thank you for choosing online transaction. Have a wonderful day! <br><br>" & _
                                    cSessionLoader._pLGU_Name
                        If ._pSubSendEmail() = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End With

                Case "CertBP"
                    Dim _nClass As New cDalSendEmail
                    With _nClass
                        ._pEmailTo = cSessionUser._pUserID
                        ._pSubject = "Certificate Payment"
                        ._pHeader = cSessionLoader._pLGU_Name
                        ._pBody = "Dear Valued Tax Payer, <br> " & _
                                    "Thank you for paying your dues! <br>" & _
                                    "This confirms your bill payment transaction with the following details: <br> " & _
                                    "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                                    "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                                    "Control Number: " & cDalCertificationAss._pUnique & "<br>" & _
                                    "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                                    "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                                    "Thank you for choosing online transaction. Have a wonderful day! <br><br>" & _
                                    cSessionLoader._pLGU_Name
                        If ._pSubSendEmail() = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End With

                Case "CertRPT"
                    Dim _nClass As New cDalSendEmail
                    With _nClass
                        ._pEmailTo = cSessionUser._pUserID
                        ._pSubject = "Certificate Payment"
                        ._pHeader = cSessionLoader._pLGU_Name
                        ._pBody = "Dear Valued Tax Payer, <br> " & _
                                    "Thank you for paying your dues! <br>" & _
                                    "This confirms your bill payment transaction with the following details: <br> " & _
                                    "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                                    "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                                    "Control Number: " & cDalCertificationAss._pUnique & "<br>" & _
                                    "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                                    "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                                    "Thank you for choosing online transaction. Have a wonderful day! <br><br>" & _
                                    cSessionLoader._pLGU_Name
                        If ._pSubSendEmail() = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End With

                Case "1CertRPT"
                    Dim _nClass As New cDalSendEmail
                    With _nClass
                        ._pEmailTo = cSessionUser._pUserID
                        ._pSubject = "Certificate Payment"
                        ._pHeader = cSessionLoader._pLGU_Name
                        ._pBody = "Dear Valued Tax Payer, <br> " & _
                                    "Thank you for paying your dues! <br>" & _
                                    "This confirms your bill payment transaction with the following details: <br> " & _
                                    "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                                    "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
                                    "Tax Declaration Number: " & cSessionLoader._pTDN & "<br>" & _
                                    "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
                                    "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                                    "Thank you for choosing online transaction. Have a wonderful day! <br><br>" & _
                                    cSessionLoader._pLGU_Name
                        If ._pSubSendEmail() = True Then
                            Return True
                        Else
                            Return False
                        End If
                    End With

            End Select



        Catch ex As Exception
            Return False
        End Try


    End Function

    Private Sub _mSubSendEmailTreasurer()
        Dim _nReturnValue As Boolean
        Try

            'Send Email For the Notification
            '----------------------------------
            Dim _mEmailWebMaster As String
            Dim _mPassword As String
            Dim _mEmailCC As String
            Dim _mEmailBCC As String


            Dim _nclassEmailSetup As New cDalGetWebEmailMaster
            _nclassEmailSetup._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nclassEmailSetup._pSubGetEmailMaster()

            _mEmailWebMaster = _nclassEmailSetup._pEmailMaster
            _mPassword = _nclassEmailSetup._pPassword
            _mEmailCC = _nclassEmailSetup._pEmailCC
            _mEmailBCC = _nclassEmailSetup._pEmailBCC


            Dim _nDate As String = FormatDateTime(Now, DateFormat.LongDate)
            Dim _nClass As New ClassEmailGoogle
            Dim _nStrucInfo As New ClassEmailGoogle._InfoEmail
            _nStrucInfo._pEmailFrom = _mEmailWebMaster
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(cCookieUser._pUserID)
                Dim _nclassEmail As New cDalGetTreasurerEmail
                _nclassEmail._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nclassEmail._pSubGetEmailTreasurer()
                _nStrucInfo._pEmailTo = _nclassEmail._pArrayListBploEmail
            Catch ex As Exception
            End Try
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailCC)
                _nStrucInfo._pEmailCc = _nArrayList
            Catch ex As Exception
            End Try
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailBCC)
                _nStrucInfo._pEmailBcc = _nArrayList
            Catch ex As Exception
            End Try

            _nStrucInfo._pEmailSubject = "Notification - Successful Payment"

            Select Case PaymentFor
                Case "BP"

                    _nStrucInfo._pEmailBody = "Sir/Ma`am: <br> " & _
                                   "Account Number   : " & cSessionLoader._pAccountNo & "<br>" & _
                                   "Merchant Name : " & Request.QueryString("merchantName") & "<br> " & _
                                   "Type of Payment  : " & Request.QueryString("serviceType") & "<br>" & _
                                   "Payment Status   : " & Request.QueryString("message") & "<br>" & _
                                   "Service Type     : Pick-Up" & _
                                   "This Account has successfuly paid the total amount of " & Request.QueryString("total") & ", . <br><br> " & _
                                    "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."
                Case "RPT"
                    _nStrucInfo._pEmailBody = "Sir/Ma`am: <br> " & _
                                   "Assessment Number   : " & cSessionLoader._pAssessmentNo & "<br>" & _
                                   "Merchant Name : " & Request.QueryString("merchantName") & "<br> " & _
                                   "Type of Payment  : " & Request.QueryString("serviceType") & "<br>" & _
                                   "Payment Status   : " & Request.QueryString("message") & "<br>" & _
                                   "Service Type     : Pick-Up" & _
                                   "This Account has successfuly paid the total amount of " & Request.QueryString("total") & ", . <br><br> " & _
                                    "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."
            End Select

            _nStrucInfo._pEmailFooter = "<br> Date Sent : " & Now.Date
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nUrlLink]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nUserID]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nFirstName]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nLastName]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nDate]", _nDate)

            _nStrucInfo._pEMailClientUserName = _mEmailWebMaster
            _nStrucInfo._pEMailClientPassword = _mPassword


            _nClass._pStrucInfo = _nStrucInfo
            If _nClass._pFuncSendEmail() Then
                _nReturnValue = True
            Else
                _nReturnValue = False
            End If
            _nClass = Nothing

        Catch ex As Exception
        End Try
    End Sub

    Shared Function GetHashMD5(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function




End Class