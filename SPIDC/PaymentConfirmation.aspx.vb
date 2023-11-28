Imports RPTIMS_DLL

Public Class PaymentConfirmation
    Inherits System.Web.UI.Page
    Dim StatusDesc As String = Nothing
    Dim statusID As String = Nothing
    Dim subject As String = Nothing
    Dim NumDesc As String = Nothing
    Dim acctno As String = Nothing
    Dim _nClass As New cDalPayment
    Dim MerchantCode As String ' LBP
    Dim Message As String ' DBP

    Dim History_ID As String
    Dim History_Email As String
    Dim History_Module As String
    Dim History_Type As String
    Dim History_Description As String
    Dim History_Particulars As String
    Dim History_Status As String

    Dim PayorName As String = ""
    Dim PayorEmail As String = ""
    Dim PAYMENTCHANNEL As String = ""
    Dim DateStamp As String = ""


    Dim svc As String 'RPT,BP,CTC
    Dim NumAbbv As String ' CtrlNo,BIN,TDN

    Dim GateWayUsed As String
    Dim getdate As String

    Dim TXNREFNO As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubGetDate(getdate)
        Dim SB As String = Request.QueryString("SelectedBank")
        Dim RC As String = Request.QueryString("referenceCode")
        Dim MC As String = Request.Form("MerchantCode")
        Dim MRN As String = Request.Form("MerchantRefNo")
        Dim MSG As String = Request.QueryString("message")
        Dim LBPRefNum As String = Request.Form("LBPRefNum")

        '----LBP2 -EPS RESPONSE
        If isLBP_EPS() = True Then
            Exit Sub
        End If






        If SB = "GCASH" Then
            GateWayUsed = "GCASH"

            StatusDesc = Request.QueryString("S")
            If StatusDesc = "S" Then StatusDesc = "SUCCESS"
            'get_statusDesc()
            do_Save()
            'LBP_Logs()        

        ElseIf MC IsNot Nothing Then
            'do LBP
            GateWayUsed = "LBP"
            get_statusDesc()
            do_Save()
            LBP_Logs()

        ElseIf MRN IsNot Nothing Then
            'do LBP
            GateWayUsed = "LBP"
            get_statusDesc()
            do_Save()
            LBP_Logs()

        ElseIf LBPRefNum IsNot Nothing Then
            GateWayUsed = "LBP2"

            get_statusDesc2()
            do_Save()
            LBP_Logs2()

        ElseIf MSG IsNot Nothing Then
            'do DBP            GateWayUsed = "DBP"
            do_Save()
        Else

            do_else()

        End If




        do_notify()
    End Sub

    Function isLBP_EPS() As Boolean
        Try
            Dim _Checksum As String = Nothing
            Dim _ErrorCode As String = Nothing
            Dim _LBPConfDate As String = Nothing
            Dim _LBPConfNum As String = Nothing
            Dim _LBPRefNum As String = Nothing
            Dim _MerchantRefNum As String = Nothing
            Dim _TrxnAmount As String = Nothing
            _Checksum = Request.Form("Checksum")
            _ErrorCode = Request.Form("ErrorCode")
            _LBPConfDate = Request.Form("LBPConfDate")
            _LBPConfNum = Request.Form("LBPConfNum")
            _LBPRefNum = Request.Form("LBPRefNum")
            _MerchantRefNum = Request.Form("MerchantRefNum")
            _TrxnAmount = Request.Form("TrxnAmount")

            If Not IsNothing(_Checksum) _
                And Not IsNothing(_ErrorCode) _
                And Not IsNothing(_LBPConfDate) _
                And Not IsNothing(_LBPConfNum) _
                And Not IsNothing(_LBPRefNum) _
                And Not IsNothing(_MerchantRefNum) _
                And Not IsNothing(_TrxnAmount) _
            Then
                GateWayUsed = "LBP2"
                PAYMENTCHANNEL = "LBP2"
                '--PAYMENT FROM LBP-EPS DETECTED
                Response.Clear()
                Response.Write("Checking status, please wait...")
                Dim sb = New System.Text.StringBuilder()
                sb.Append("<html>")
                sb.AppendFormat("<body onload='document.forms[0].submit()'>")
                sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")

                Dim _nClass As New cDalPayment
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                If _nClass.isCheckSumExists(_Checksum, _MerchantRefNum) = False Then
                    sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", "INVALID TRANSACTION")
                Else
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    _nClass._pSubGetACCTNO(Request.Form("MerchantRefNum"), acctno)
                    Dim Sent As Boolean = False
                    Dim Body As String = Nothing
                    If _ErrorCode = "0000" Then
                        statusID = "SUCCESS"
                        '0000  = Transaction Completed Successfully    
                        Body = "Dear Valued Tax Payer, <br> " & _
                               "This confirms your bill payment transaction with the following details: <br> " & _
                               "Transaction Number: " & Request.Form("MerchantRefNum") & "<br>" & _
                               "Transaction Type: " & subject & "<br>" & _
                               "" & NumDesc & " : " & acctno & "<br>" & _
                               "Amount Paid : " & Request.Form("TrxnAmount") & "<br> <br>"
                        cDalNewSendEmail.SendEmail(PayorEmail, subject, Body, Sent)
                    Else
                        statusID = "FAILED"
                    End If

                    _nClass._pSubUpdateOnlinePaymentInfo(_MerchantRefNum _
                        , get_LBPEPS_ErrorCode(_ErrorCode) _
                        , _LBPRefNum _
                        , _Checksum _
                        , getdate _
                        , _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", _MerchantRefNum) _
                        , _nClass.Get_PaymentDetails("feeAmount", "TXNREFNO", _MerchantRefNum) _
                        , _nClass.Get_PaymentDetails("TotAmount", "TXNREFNO", _MerchantRefNum) _
                        , statusID _
                        , PAYMENTCHANNEL)


                    sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", _MerchantRefNum)
                    sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", _TrxnAmount)
                    sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", get_LBPEPS_ErrorCode(_ErrorCode))
                    sb.AppendFormat("<input type='hidden' name='LBPRefNum' value='{0}'>", _LBPRefNum)
                    sb.AppendFormat("<input type='hidden' name='Date' value='{0}'>", _LBPConfDate)
                    sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='" & GateWayUsed & "'>")
                End If
                sb.Append("</form>")
                sb.Append("</body>")
                sb.Append("</html>")
                Response.Write(sb.ToString())
                Response.[End]()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

        End Try
    End Function

    Sub do_notify()

        Response.Clear()
        Response.Write("Checking status, please wait...")
        Dim sb = New System.Text.StringBuilder()
        sb.Append("<html>")
        sb.AppendFormat("<body onload='document.forms[0].submit()'>")
        '  sb.AppendFormat("<body>")

        If GateWayUsed = "LBP" Then

            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
            sb.AppendFormat("<input type='hidden' name='MerchantCode' value='{0}'>", Request.Form("MerchantCode"))
            sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", Request.Form("MerchantRefNo"))
            sb.AppendFormat("<input type='hidden' name='Particulars' value='{0}'>", Request.Form("Particulars"))
            sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", Request.Form("Amount"))
            sb.AppendFormat("<input type='hidden' name='PayorName' value='{0}'>", Request.Form("PayorName"))
            sb.AppendFormat("<input type='hidden' name='PayorEmail' value='{0}'>", Request.Form("PayorEmail"))
            sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", Request.Form("Status"))
            sb.AppendFormat("<input type='hidden' name='EppRefNo' value='{0}'>", Request.Form("EppRefNo"))
            sb.AppendFormat("<input type='hidden' name='PaymentOption' value='{0}'>", Request.Form("PaymentOption"))
            sb.AppendFormat("<input type='hidden' name='DateStamp' value='{0}'>", Request.Form("DateStamp"))
            sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='" & GateWayUsed & "'>")

        ElseIf GateWayUsed = "LBP2" Then


            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
            sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", Request.Form("MerchantRefNum"))
            sb.AppendFormat("<input type='hidden' name='Particulars' value='{0}'>", "LBPConfDate:" & Request.Form("LBPConfDate") & ";" & "CheckSum:" & Request.Form("Checksum") & ";")
            sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", Request.Form("TrxnAmount"))
            sb.AppendFormat("<input type='hidden' name='PayorName' value='{0}'>", PayorName)
            sb.AppendFormat("<input type='hidden' name='PayorEmail' value='{0}'>", PayorEmail)
            sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", StatusDesc)
            sb.AppendFormat("<input type='hidden' name='LBPRefNum' value='{0}'>", Request.Form("LBPRefNum"))
            sb.AppendFormat("<input type='hidden' name='PaymentOption' value='{0}'>", PAYMENTCHANNEL)
            sb.AppendFormat("<input type='hidden' name='Date' value='{0}'>", getdate)
            sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='" & GateWayUsed & "'>")

        ElseIf GateWayUsed = "DBP" Then

            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")


            For Each key As String In Request.QueryString.Keys
                If Request.QueryString(key) <> Nothing Then
                    sb.AppendFormat("<input type='hidden' name='" & key & "' value='{0}'>", Request.QueryString(key))
                End If
            Next

            sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='" & GateWayUsed & "'>")

        ElseIf GateWayUsed = "GCASH" Then


            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
            sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", Request.QueryString("referenceCode"))
            'sb.AppendFormat("<input type='hidden' name='Particulars' value='{0}'>", "LBPConfDate:" & Request.Form("LBPConfDate") & ";" & "CheckSum:" & Request.Form("Checksum") & ";")
            'sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", Request.Form("TrxnAmount"))
            'sb.AppendFormat("<input type='hidden' name='PayorName' value='{0}'>", PayorName)
            'sb.AppendFormat("<input type='hidden' name='PayorEmail' value='{0}'>", PayorEmail)
            sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", StatusDesc)
            'sb.AppendFormat("<input type='hidden' name='LBPRefNum' value='{0}'>", Request.Form("LBPRefNum"))
            sb.AppendFormat("<input type='hidden' name='PaymentOption' value='{0}'>", "GCASH")
            'sb.AppendFormat("<input type='hidden' name='Date' value='{0}'>", getdate)
            sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='" & GateWayUsed & "'>")

        Else
            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
            For Each key As String In Request.QueryString.Keys
                If Request.QueryString(key) <> Nothing Then
                    sb.AppendFormat("<input type='hidden' name='" & key & "' value='{0}'>", Request.QueryString(key))
                End If
            Next
            sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='" & GateWayUsed & "'>")

        End If
        '  sb.AppendFormat("<input type='submit'>")
        sb.Append("</form>")
        sb.Append("</body>")
        sb.Append("</html>")
        Response.Write(sb.ToString())
        Response.[End]()

    End Sub

    Sub do_else()
        Response.Clear()
        Response.Write("Checking status, please wait...")
        Dim sb = New System.Text.StringBuilder()
        sb.Append("<html>")
        sb.AppendFormat("<body onload='document.forms[0].submit()'>")
        sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
        For Each key As String In Request.Form.Keys
            If Request.Form(key) <> Nothing Then
                sb.AppendFormat("<input type='hidden' name='" & key & "' value='{0}'>", Request.Form(key))
            End If
        Next
        sb.AppendFormat("<input type='hidden' name='GateWayUsed' value=''>")

        sb.Append("</form>")
        sb.Append("</body>")
        sb.Append("</html>")
        Response.Write(sb.ToString())
        Response.[End]()
    End Sub

    Sub get_statusDesc()
        Select Case Request.Form("Status")
            Case "00"
                StatusDesc = "Successful"
            Case "01"
                StatusDesc = "Invalid merchant code"
            Case "02"
                StatusDesc = "Invalid merchant reference number"
            Case "03"
                StatusDesc = "0 or negative amount"
            Case "04"
                StatusDesc = "Null payors name"
            Case "05"
                StatusDesc = "Null returnURLok"
            Case "06"
                StatusDesc = "Null returnURLerror"
            Case "07"
                StatusDesc = "invalid(hash)"
            Case "08"
                StatusDesc = "Service unavailable"
            Case "09"
                StatusDesc = "Transaction in process"
            Case "10"
                StatusDesc = "Cancelled transaction"
            Case "11"
                StatusDesc = "EPP offline"
            Case "12"
                StatusDesc = "Invalid transaction type"
            Case "13"
                StatusDesc = "invalid(Particulars)"
            Case "14"
                StatusDesc = "Duplicate transaction"
        End Select
        Return
    End Sub

    Sub get_statusDesc2()
        Dim ErrorCode As String = Request.Form("ErrorCode")
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubGetEpsErrorCode(ErrorCode, StatusDesc)
    End Sub

    Function get_LBPEPS_ErrorCode(ByVal ErrorCode As String) As String
        Dim ErrorDesc As String = Nothing
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubGetEpsErrorCode(ErrorCode, ErrorDesc)
        Return ErrorDesc
    End Function

    Sub LBP_Logs()

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubInsertLBPLogs(Request.Form("MerchantCode"),
                                   Request.Form("MerchantRefNo"),
                                   Request.Form("Particulars"),
                                   Request.Form("Amount"),
                                   Request.Form("PayorName"),
                                   Request.Form("PayorEmail"),
                                   Request.Form("Status"),
                                   Request.Form("EppRefNo"),
                                   Request.Form("PaymentOption"),
                                   Request.Form("DateStamp"),
                                   StatusDesc)



    End Sub
    Sub LBP_Logs2()
        MerchantCode = ""


        Dim Status = Request.Form("ErrorCode") & " : " & StatusDesc
        Dim Particulars = "LBPConfDate:" & Request.Form("LBPConfDate") & ";" & "CheckSum:" & Request.Form("Checksum") & ";"

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubGetPayorInfo(Request.Form("MerchantRefNum"), PayorEmail, PAYMENTCHANNEL, PayorName, acctno)
        _nClass._pSubInsertLBPLogs(MerchantCode,
                                   Request.Form("MerchantRefNum"),
                                   Particulars,
                                   Request.Form("TrxnAmount"),
                                   PayorName,
                                   PayorEmail,
                                   Status,
                                   Request.Form("LBPRefNum"),
                                   PAYMENTCHANNEL,
                                   DateStamp,
                                   StatusDesc)



    End Sub
    Sub do_Save()
        Try



            If GateWayUsed = "LBP" Then


                If Request.Form("Status") = "00" Then
                    statusID = "SUCCESS"

                    If Request.Form("MerchantRefNo").Substring(0, 2) = "BP" Then
                        svc = "BP"
                        subject = "Business Permit Payment"
                        NumDesc = "Business Identification Number"
                        NumAbbv = "BIN"
                        'Get AcctNo from Particulars
                        Dim strsplt As String() = Request.Form("Particulars").Split(";"c)
                        Dim strsplt2 = strsplt(2).ToString()
                        strsplt = strsplt2.Split("="c)
                        acctno = strsplt(1).ToString()
                        do_bp()

                    ElseIf Request.Form("MerchantRefNo").Substring(0, 3) = "RPT" Then
                        subject = "Real Property Payment"
                        NumDesc = "Assessment Number"
                        svc = "RPT"
                        NumAbbv = "TDN"
                        do_RPT()

                    ElseIf Request.Form("MerchantRefNo").Substring(0, 3) = "CTC" Then
                        subject = "Cedula Payment"
                        NumDesc = "Control Number"
                        acctno = Request.Form("MerchantRefNo").Replace("CTC", "")
                        svc = "CTC"
                        NumAbbv = "CtrlNo"
                        do_CTC(acctno, Request.Form("Datestamp"))
                    End If
                    do_UpdateOnlinePaymentRefno()





                ElseIf Request.Form("Status") = "10" Then
                    statusID = "CANCELLED"
                    do_UpdateOnlinePaymentRefno()
                End If

            ElseIf GateWayUsed = "LBP2" Then

                If Request.Form("ErrorCode") = "0000" Then
                    statusID = "SUCCESS"
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    _nClass._pSubGetPayorInfo(Request.Form("MerchantRefNum"), PayorEmail, PAYMENTCHANNEL, PayorName, acctno)


                    If Request.Form("MerchantRefNum").Substring(0, 2) = "BP" Then
                        svc = "BP"
                        subject = "Business Permit Payment"
                        NumDesc = "Business Identification Number"
                        NumAbbv = "BIN"
                        do_bp()

                    ElseIf Request.Form("MerchantRefNo").Substring(0, 3) = "RPT" Then
                        subject = "Real Property Payment"
                        NumDesc = "Assessment Number"
                        svc = "RPT"
                        NumAbbv = "TDN"
                        do_RPT()

                    ElseIf Request.Form("MerchantRefNo").Substring(0, 3) = "CTC" Then
                        subject = "Cedula Payment"
                        NumDesc = "Control Number"
                        acctno = Request.Form("MerchantRefNo").Replace("CTC", "")
                        svc = "CTC"
                        NumAbbv = "CtrlNo"
                        do_CTC(acctno, Request.Form("Datestamp"))
                    End If
                    do_UpdateOnlinePaymentRefno()
                Else
                    statusID = "CANCELLED"
                    do_UpdateOnlinePaymentRefno()
                End If
            ElseIf GateWayUsed = "DBP" Then
                Dim _nClass As New cDalPayment
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubGetACCTNO(Request.QueryString("referenceCode"), acctno)

                If Request.QueryString("message") = "Successful approval/completion." Then
                    statusID = "SUCCESS"
                    If Request.QueryString("referenceCode").Substring(0, 2) = "BP" Then
                        svc = "BP"
                        subject = "Business Permit Payment"
                        NumDesc = "Business Identification Number"
                        NumAbbv = "BIN"
                        'Get AcctNo from Particulars                      
                        do_bp()
                    ElseIf Request.QueryString("referenceCode").Substring(0, 3) = "RPT" Then
                        subject = "Real Property Payment"
                        NumDesc = "Assessment Number"
                        svc = "RPT"
                        NumAbbv = "TDN"
                        do_RPT()
                    ElseIf Request.QueryString("referenceCode").Substring(0, 3) = "CTC" Then
                        subject = "Cedula Payment"
                        NumDesc = "Control Number"
                        acctno = Request.Form("MerchantRefNo").Replace("CTC", "")
                        svc = "CTC"
                        NumAbbv = "CtrlNo"
                        do_CTC(acctno, Request.Form("Datestamp"))
                    End If
                    do_UpdateOnlinePaymentRefno()
                ElseIf Request.QueryString("message") <> "Successful approval/completion." Then
                    statusID = Request.QueryString("message")
                    do_UpdateOnlinePaymentRefno()
                End If
            ElseIf GateWayUsed = "GCASH" Then


                statusID = "SUCCESS"
                If Request.QueryString("referenceCode").Substring(0, 2) = "BP" Then
                    svc = "BP"
                    subject = "Business Permit Payment"
                    NumDesc = "Business Identification Number"
                    NumAbbv = "BIN"
                    do_bp()
                ElseIf Request.QueryString("referenceCode").Substring(0, 3) = "RPT" Then
                    subject = "Real Property Payment"
                    NumDesc = "Assessment Number"
                    svc = "RPT"
                    NumAbbv = "TDN"
                    do_RPT()
                ElseIf Request.QueryString("referenceCode").Substring(0, 3) = "CTC" Then
                    subject = "Cedula Payment"
                    NumDesc = "Control Number"
                    acctno = Request.QueryString("referenceCode")
                    svc = "CTC"
                    NumAbbv = "CtrlNo"
                    do_CTC(acctno, DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssK"))
                End If
                do_UpdateOnlinePaymentRefno()

            ElseIf GateWayUsed = "SPIDCPAY" Then
                statusID = "SUCCESS"
                If Request.QueryString("MerchantRefNo").Substring(0, 2) = "BP" Then
                    svc = "BP"
                    subject = "Business Permit Payment"
                    NumDesc = "Business Identification Number"
                    NumAbbv = "BIN"
                    '   do_bp()
                ElseIf Request.QueryString("MerchantRefNo").Substring(0, 3) = "RPT" Then
                    subject = "Real Property Payment"
                    NumDesc = "Assessment Number"
                    svc = "RPT"
                    NumAbbv = "TDN"
                    '   do_RPT()
                ElseIf Request.QueryString("MerchantRefNo").Substring(0, 3) = "CTC" Then
                    subject = "Cedula Payment"
                    NumDesc = "Control Number"
                    svc = "CTC"
                    NumAbbv = "CtrlNo"
                    '     do_CTC(acctno, DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssK"))
                End If
                do_UpdateOnlinePaymentRefno()
            Else
                statusID = "CANCELLED"
                do_UpdateOnlinePaymentRefno()
            End If


            'If statusID = "SUCCESS" Then
            '    '----------PAYMENT POSTING
            '    Dim err As String = Nothing
            '    do_Post(svc, acctno, err)
            '    If String.IsNullOrEmpty(err) = True Then
            '        do_SendeOR(err)
            '    End If
            'End If




        Catch ex As Exception

        End Try
    End Sub

    Sub do_UpdateOnlinePaymentRefno()
        If GateWayUsed = "LBP" Then
            '----------------------------------      
            If statusID = "SUCCESS" Then
                Dim _nClass As New cDalPayment
                '----------------------------------
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubGetACCTNO(Request.Form("MerchantRefNo"), acctno)

                Dim Sent As Boolean
                Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                                     "This confirms your bill payment transaction with the following details: <br> " & _
                                     "Transaction Number: " & Request.Form("MerchantRefNo") & "<br>" & _
                                     "Transaction Type: " & subject & "<br>" & _
                                     "" & NumDesc & " : " & acctno & "<br>" & _
                                     "Date/Time : " & Request.Form("Datestamp") & "<br>" & _
                                     "Amount Paid : " & Request.Form("Amount") & "<br> <br>"
                cDalNewSendEmail.SendEmail(Request.Form("PayorEmail"), subject, Body, Sent)
                If Sent = True Then
                    Response.Write("<script>alert('Email Notification has been sent');</script>")
                Else
                    Response.Write("<script>alert('Failed to send Email Notification');</script>")
                End If

                _nClass._pSubUpdateOnlinePaymentInfo(Request.Form("MerchantRefNo") _
                    , StatusDesc _
                    , Request.Form("EppRefNo") _
                    , Request.Form("EppRefNo") _
                    , Request.Form("Datestamp") _
                    , _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", Request.Form("MerchantRefNo")) _
                    , _nClass.Get_PaymentDetails("feeAmount", "TXNREFNO", Request.Form("MerchantRefNo")) _
                    , _nClass.Get_PaymentDetails("TotAmount", "TXNREFNO", Request.Form("MerchantRefNo")) _
                    , statusID _
                    , Request.Form("PaymentOption"))



            ElseIf statusID = "CANCELLED" Then
                Dim _nClass As New cDalPayment
                '----------------------------------
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubUpdateOnlinePaymentInfoCancelled(Request.Form("MerchantRefNo") _
                    , StatusDesc _
                    , Request.Form("EppRefNo") _
                    , Request.Form("EppRefNo") _
                    , Request.Form("Datestamp") _
                    , Request.Form("Amount") _
                    , 0 _
                    , Request.Form("Amount") _
                    , statusID)
            End If

            History_ID = Request.Form("MerchantRefNo")
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetEmail(Request.Form("MerchantRefNo"), History_Email)
            History_Email = History_Email
            History_Module = NumAbbv
            History_Type = subject
            History_Description = "Payment"
            History_Particulars = Request.Form("Particulars")
            History_Status = statusID

        ElseIf GateWayUsed = "LBP2" Then
            '----------------------------------      
            If statusID = "SUCCESS" Then
                Dim _nClass As New cDalPayment
                '----------------------------------
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubGetACCTNO(Request.Form("MerchantRefNum"), acctno)

                Dim Sent As Boolean
                Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                                     "This confirms your bill payment transaction with the following details: <br> " & _
                                     "Transaction Number: " & Request.Form("MerchantRefNum") & "<br>" & _
                                     "Transaction Type: " & subject & "<br>" & _
                                     "" & NumDesc & " : " & acctno & "<br>" & _
                                     "Amount Paid : " & Request.Form("TrxnAmount") & "<br> <br>"
                cDalNewSendEmail.SendEmail(PayorEmail, subject, Body, Sent)
                If Sent = True Then
                    Response.Write("<script>alert('Email Notification has been sent');</script>")
                Else
                    Response.Write("<script>alert('Failed to send Email Notification');</script>")
                End If

                _nClass._pSubUpdateOnlinePaymentInfo(Request.Form("MerchantRefNum") _
                    , StatusDesc _
                    , Request.Form("LBPRefNum") _
                    , Request.Form("Checksum") _
                    , getdate _
                    , _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", Request.Form("MerchantRefNum")) _
                    , _nClass.Get_PaymentDetails("feeAmount", "TXNREFNO", Request.Form("MerchantRefNum")) _
                    , _nClass.Get_PaymentDetails("totAmount", "TXNREFNO", Request.Form("MerchantRefNum")) _
                    , statusID _
                    , PAYMENTCHANNEL)



            ElseIf statusID = "CANCELLED" Then
                Dim _nClass As New cDalPayment
                '----------------------------------

                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

                _nClass._pSubUpdateOnlinePaymentInfoCancelled(Request.Form("MerchantRefNum") _
                    , StatusDesc _
                    , Request.Form("LBPRefNum") _
                    , Request.Form("Checksum") _
                    , getdate _
                    , Request.Form("TrxnAmount") _
                    , 0 _
                    , Request.Form("TrxnAmount") _
                    , statusID)
            End If

            History_ID = Request.Form("MerchantRefNum")
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetEmail(Request.Form("MerchantRefNum"), History_Email)
            History_Email = History_Email
            History_Module = NumAbbv
            History_Type = subject
            History_Description = "Payment"
            History_Particulars = "LBPConfDate:" & Request.Form("LBPConfDate") & ";" & "CheckSum:" & Request.Form("Checksum") & ";"
            History_Status = statusID

        ElseIf GateWayUsed = "DBP" Then
            '----------------------------------      
            If statusID = "SUCCESS" Then
                Dim _nClass As New cDalPayment
                '----------------------------------
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubGetACCTNO(Request.QueryString("referenceCode"), acctno)

                Dim Sent As Boolean
                Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                                     "This confirms your bill payment transaction with the following details: <br> " & _
                                     "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                                     "Transaction Type: " & subject & "<br>" & _
                                     "" & NumDesc & " : " & acctno & "<br>" & _
                                     "Date/Time : " & Request.QueryString("date") & "<br>" & _
                                     "Amount Paid : " & Request.QueryString("amount") & "<br> <br>"
                cDalNewSendEmail.SendEmail(cSessionUser._pUserID, subject, Body, Sent)
                If Sent = True Then
                    Response.Write("<script>alert('Email Notification has been sent');</script>")
                Else
                    Response.Write("<script>alert('Failed to send Email Notification');</script>")
                End If

                _nClass._pSubUpdateOnlinePaymentInfo(Request.QueryString("referenceCode") _
                    , Request.QueryString("message") _
                    , Request.QueryString("retrievalReferenceCode") _
                    , Request.QueryString("securityToken") _
                    , Request.QueryString("date") _
                    , Request.QueryString("amount") _
                    , Request.QueryString("serviceChargeFee") _
                    , Request.QueryString("total") _
                    , statusID _
                    , "DBP")

            ElseIf statusID = "CANCELLED" Then
                Dim _nClass As New cDalPayment
                '----------------------------------
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubUpdateOnlinePaymentInfoCancelled(Request.QueryString("referenceCode") _
                    , Request.QueryString("message") _
                    , Nothing _
                    , Nothing _
                    , Request.QueryString("date") _
                    , Request.QueryString("amount") _
                    , Request.QueryString("serviceChargeFee") _
                    , Request.QueryString("total") _
                    , statusID)
            End If


            History_ID = Request.QueryString("referenceCode")
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetEmail(Request.QueryString("referenceCode"), History_Email)
            History_Email = History_Email
            History_Module = NumAbbv
            History_Type = Request.QueryString("serviceType")
            History_Description = "Payment"
            History_Particulars = "ID=" & History_ID & ";Description=" & Request.QueryString("serviceType") & ";" & NumAbbv & "=" & acctno & ";PaymentMethod=" & GateWayUsed & ";TotalAmount=" & Request.QueryString("serviceType") & ";"
            History_Status = statusID


        ElseIf GateWayUsed = "GCASH" Then
            '----------------------------------      
            If statusID = "SUCCESS" Then
                Dim _nClass As New cDalPayment
                '----------------------------------
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubGetACCTNO(Request.QueryString("referenceCode"), acctno)

                'Dim Sent As Boolean
                'Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                '                     "This confirms your bill payment transaction with the following details: <br> " & _
                '                     "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
                '                     "Transaction Type: " & subject & "<br>" & _
                '                     "" & NumDesc & " : " & acctno & "<br>" & _
                '                     "Date/Time : " & Request.QueryString("date") & "<br>" & _
                '                     "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
                '                     "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
                'cDalNewSendEmail.SendEmail(cSessionUser._pUserID, subject, Body, Sent)
                'If Sent = True Then
                '    Response.Write("<script>alert('Email Notification has been sent');</script>")
                'Else
                '    Response.Write("<script>alert('Failed to send Email Notification');</script>")
                'End If

                '_nClass._pSubUpdateOnlinePaymentInfo(Request.QueryString("referenceCode") _
                '    , Request.QueryString("message") _
                '    , Request.QueryString("retrievalReferenceCode") _
                '    , Request.QueryString("securityToken") _
                '    , Request.QueryString("date") _
                '    , Request.QueryString("amount") _
                '    , Request.QueryString("serviceChargeFee") _
                '    , Request.QueryString("total") _
                '    , statusID _
                '    , "GCASH")

            ElseIf statusID = "CANCELLED" Then
                Dim _nClass As New cDalPayment
                '----------------------------------
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubUpdateOnlinePaymentInfoCancelled(Request.QueryString("referenceCode") _
                    , Request.QueryString("message") _
                    , Nothing _
                    , Nothing _
                    , Request.QueryString("date") _
                    , Request.QueryString("amount") _
                    , Request.QueryString("serviceChargeFee") _
                    , Request.QueryString("total") _
                    , statusID)
            End If


            History_ID = Request.QueryString("referenceCode")
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetEmail(Request.QueryString("referenceCode"), History_Email)
            History_Email = History_Email
            History_Module = NumAbbv
            History_Type = "Payment"
            History_Description = "GCASH"
            History_Particulars = "ID=" & History_ID & ";Description=" & Request.QueryString("serviceType") & ";" & NumAbbv & "=" & acctno & ";PaymentMethod=" & GateWayUsed & ";TotalAmount=" & Request.QueryString("total") & ";"
            History_Status = statusID


        ElseIf GateWayUsed = "SPIDCPAY" Then
            statusID = "SUCCESS"
            History_ID = Request.QueryString("MerchantRefNo")
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetEmail(Request.QueryString("MerchantRefNo"), History_Email)
            History_Email = History_Email
            History_Module = NumAbbv
            History_Type = "Payment"
            History_Description = "SPIDCPAY"
            History_Particulars = "ID=" & History_ID & ";Description=" & Request.QueryString("serviceType") & ";" & NumAbbv & "=" & acctno & ";PaymentMethod=" & GateWayUsed & ";TotalAmount=" & Request.QueryString("serviceType") & ";"
            History_Status = statusID

        End If



        Dim _nClass3 As New cDalTransactionHistory
        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass3._pSubInsertHistory(History_ID, _
                                    History_Email, _
                                    History_Module, _
                                    History_Type, _
                                    History_Description, _
                                    History_Particulars, _
                                    History_Status)








    End Sub

    Sub do_bp()
        Try
            Dim _nClass2 As New cDalBPSOS
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass2._pAcctNo = acctno
            _nClass2._pForYear = cSessionLoader._pFORYEAR

            If GateWayUsed = "LBP" Then
                _nClass2._pEmail = Request.Form("PayorEmail")
                _nClass2._pReferenceNo = Request.Form("MerchantRefNo")
                _nClass2._pAmountPaid = Request.Form("Amount")
                _nClass2._pDatePaid = Request.Form("Datestamp")
                _nClass2._pRemarks = cSessionLoader._pType
                _nClass2._pLQP = cSessionLoader._pBPQTR
                _nClass2._pQtr = cSessionLoader._pBPQTR
                _nClass2._pTempTbl = "temp_" & Request.Form("PayorEmail").Replace(".", "")

            ElseIf GateWayUsed = "LBP2" Then
                _nClass2._pEmail = PayorEmail
                _nClass2._pReferenceNo = Request.Form("MerchantRefNum")
                _nClass2._pAmountPaid = Request.Form("TrxnAmount")
                _nClass2._pDatePaid = getdate
                _nClass2._pRemarks = cSessionLoader._pType
                _nClass2._pLQP = cSessionLoader._pBPQTR
                _nClass2._pQtr = cSessionLoader._pBPQTR
                _nClass2._pTempTbl = "temp_" & PayorEmail.Replace(".", "")

            ElseIf GateWayUsed = "DBP" Then
                _nClass2._pEmail = cSessionUser._pUserID
                _nClass2._pReferenceNo = Request.QueryString("referenceCode")
                _nClass2._pAmountPaid = Request.QueryString("amount")
                _nClass2._pDatePaid = Request.QueryString("date")
                _nClass2._pRemarks = cSessionLoader._pType
                _nClass2._pLQP = cSessionLoader._pBPQTR
                _nClass2._pQtr = cSessionLoader._pBPQTR
                _nClass2._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")

            End If

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nClass2._pLocServer = _nClBP._pDBDataSource
            _nClass2._pLocDB = _nClBP._pDBInitialCatalog


            If acctno <> "" Then
                _nClass2._pSubSavePaymentDetail()
                _nClass2._pSubPaymentPosting()
                _nClass2._pSubUPDATELEDGERACCT()
            End If



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Sub do_CTC(ByVal referenceCode As String, ByVal Datestamp As String)
        Try
            Dim _nClass As New cDalPayment
            '----------------------------------
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
            _nClass._pAssessmentNo = referenceCode
            _nClass._pRemarks = statusID
            _nClass._pisPosted = "1"
            _nClass._pSubUpdateCTC(Datestamp, statusID, acctno, referenceCode)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Sub do_RPT()

    End Sub

    Sub do_Save_DBP()

    End Sub


    Sub DBP_POSTBACK()

        Dim Subject As String
        Dim ACCT As String
        Dim ACCTID As String
        Dim serviceType As String

        serviceType = Request.QueryString("serviceType")



        Dim stat As String = Nothing
        Dim _nclass As New cDalPayment
        If Request.QueryString("message") = "Successful approval/completion." Then
            stat = Request.QueryString("message")
            statusID = "SUCCESS"


        Else
            stat = "Failed: " & Request.QueryString("message")
            statusID = "FAILED"
        End If


        If Request.QueryString("message") = "Successful approval/completion." Then

        Else

        End If

        'send email to taxpayer
        ' Dim Sent As Boolean
        ' Dim Body As String = "Dear Valued Tax Payer, <br> " & _
        '                      "This confirms your bill payment transaction with the following details: <br> " & _
        '                      "Transaction Number: " & Request.QueryString("referenceCode") & "<br>" & _
        '                      "Transaction Type: " & Request.QueryString("serviceType") & "<br>" & _
        '                      "" & ACCT & " : " & ACCTID & "<br>" & _
        '                      "Date/Time : " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & "<br>" & _
        '                      "Amount Paid : " & Request.QueryString("amount") & "<br> <br>" & _
        '                      "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
        ' cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)

    End Sub

    Sub do_process(ByVal AssessmentNo As String)
        Dim getdate As Date
        Try
            Dim usertmp As String
            Dim _nclass As New cDalPDSRPTAS
            Dim _nclass2 As New cDalGetDate
            _nclass2._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
            _nclass._pSubGetSpecificRecord_getid()
            _msubGetServerDate()
            _nclass._mctr_no = cPageSession_Billing_EntryView._pOrigSrvDateValue

            Dim cls_rptas As New clsRPT

            cls_rptas.RPTAS_SERVER = cGlobalConnections._pSqlCxn_RPTAS.DataSource
            cls_rptas.RPTASWEB_SERVER = cGlobalConnections._pSqlCxn_RPTIMS.DataSource
            cls_rptas.RPTAS_xDataBase = cGlobalConnections._pSqlCxn_RPTAS.Database
            cls_rptas.RPTASWEB_xDataBase = cGlobalConnections._pSqlCxn_RPTIMS.Database

            cls_rptas.TOIMS_Server = cGlobalConnections._pSqlCxn_TOIMS.DataSource
            cls_rptas.TOIMS_xDataBase = cGlobalConnections._pSqlCxn_TOIMS.Database
            cls_rptas.TOIMS_xUID = _mSubUIPW("UI", "TOIMS")
            cls_rptas.TOIMS_xPW = _mSubUIPWWEB("UI")

            cls_rptas.RPTAS_xUID = _mSubUIPW("UI", "RPTAS")
            cls_rptas.RPTASWEB_xUID = _mSubUIPWWEB("UI")
            cls_rptas.RPTAS_xPW = _mSubUIPW("PW", "RPTAS")
            cls_rptas.RPTASWEB_xPW = _mSubUIPWWEB("PW")
            cls_rptas.Region_TMP = _mSubREGION()
            usertmp = PayorEmail.Replace(".", "")
            usertmp = usertmp.Replace("-", "")
            cls_rptas.User_TMP = usertmp 'remove the "." 
            cls_rptas.MultiTDN = 1
            cls_rptas.Tdn = ""
            cls_rptas.bill_date = CDate(_nclass2._GetDate_MMddyyyy())


            cls_rptas.SvrDateValue = cPageSession_Billing_EntryView._pOrigSrvDateValue

            'If RadioButton1.Checked = True Then
            '    cls_rptas.Quater_set = "1"
            'End If
            'If RadioButton2.Checked = True Then
            '    cls_rptas.Quater_set = "2"
            'End If
            'If RadioButton3.Checked = True Then
            '    cls_rptas.Quater_set = "3"
            'End If
            'If RadioButton4.Checked = True Then
            '    cls_rptas.Quater_set = "4"
            'End If

            '  cls_rptas.RPTAS_ForYear = _radYear.Text

            cls_rptas.SvrDateValue = _nclass._mctr_no

            cls_rptas.LoadForm()
            '      cls_rptas.TOIMSPOSTING(AssessmentNo)

        Catch ex As Exception

        End Try




    End Sub

    Function _mSubUIPW(cndtn As String, ConDB As String) As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR

                ._pSubSelectUIPW(ConDB)

                If cndtn = "UI" Then
                    Return ._pdbUI
                ElseIf cndtn = "PW" Then
                    Return ._pdbPW
                Else
                    Return Nothing
                End If

            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Function _mSubUIPWWEB(cndtn As String) As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR

                ._pSubSelectUIPWWEB()

                If cndtn = "UI" Then
                    Return ._pdbUI
                ElseIf cndtn = "PW" Then
                    Return ._pdbPW
                Else
                    Return Nothing
                End If

            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub _msubGetServerDate()
        Dim _nclass As New cDalPDSRPTAS
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
        ''_nclass._pSubGetSpecificRecord_getid().
        _nclass._pSubGetServerDate()

        Dim _nDataTable As New DataTable
        _nDataTable = _nclass._pDataTable

        Try
            '----------------------------------
            If _nDataTable.Rows.Count > 0 Then

                _nclass._mctr_no = _nDataTable.Rows("0").Item("ServerDateTime").ToString
                cPageSession_Billing_EntryView._pOrigSrvDateValue = _nclass._mctr_no
            Else
                ' _mSubShowBlankApplicationProcess()

            End If


            '_mSubGetApplicationAddress()
            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub

    Function _mSubREGION() As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

                ._pSubREGION()

                Return ._pRegion
            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Sub do_Post(ByVal Fee_type As String, ByVal Acctno As String, Optional ByRef Err As String = Nothing)
        Try
            If Fee_type = "RPT" Then
                do_process(Acctno)
            End If
        Catch ex As Exception
            Err = ";do_Post : " & ex.Message
        End Try
    End Sub
    Sub do_SendeOR(Optional ByRef Err As String = Nothing)
        Try

        Catch ex As Exception
            Err = ";do_SendeOR : " & ex.Message
        End Try
    End Sub
End Class