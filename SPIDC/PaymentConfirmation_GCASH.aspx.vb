Imports RPTIMS_DLL

Public Class PaymentConfirmation_GCASH
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim _nClass As New cDalPaymentInquiry
            Dim TXNREFNO As String = Request.QueryString("referenceCode")
            _nClass.PaymentInquiry(TXNREFNO)

            _nClass.Gcash_reqMsgId
            _nClass.Gcash_acquirementId
            _nClass.Gcash_merchantTransId
            _nClass.Gcash_orderTitle
            _nClass.Gcash_payAmount
            _nClass.Gcash_acquirementStatus
            _nClass.Gcash_paidTime
            _nClass.Gcash_signature

        Catch ex As Exception

        End Try
        do_notify()
    End Sub



    Sub do_notify()

        Response.Clear()
        Response.Write("Checking status, please wait...")
        Dim sb = New System.Text.StringBuilder()
        sb.Append("<html>")
        sb.AppendFormat("<body onload='document.forms[0].submit()'>")
        '  sb.AppendFormat("<body>")

     

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

  
        '  sb.AppendFormat("<input type='submit'>")
        sb.Append("</form>")
        sb.Append("</body>")
        sb.Append("</html>")
        Response.Write(sb.ToString())
        Response.[End]()

    End Sub

    




    
    Sub do_Save()
        Try
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
            cls_rptas.TOIMS_xUID = _mSubUIPW("UI")
            cls_rptas.TOIMS_xPW = _mSubUIPWWEB("UI")

            cls_rptas.RPTAS_xUID = _mSubUIPW("UI")
            cls_rptas.RPTASWEB_xUID = _mSubUIPWWEB("UI")
            cls_rptas.RPTAS_xPW = _mSubUIPW("PW")
            cls_rptas.RPTASWEB_xPW = _mSubUIPWWEB("PW")
            cls_rptas.Region_TMP = _mSubREGION()
            usertmp = PayorEmail.Replace(".", "")
            usertmp = usertmp.Replace("-", "")
            cls_rptas.User_TMP = usertmp 'remove the "." 
            cls_rptas.MultiTDN = 1
            cls_rptas.Tdn = ""
            cls_rptas.bill_date = CDate(_nclass2._GetDate("MM/dd/yyyy"))


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
            cls_rptas.TOIMSPOSTING(AssessmentNo)

        Catch ex As Exception

        End Try




    End Sub

    Function _mSubUIPW(cndtn As String) As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR

                ._pSubSelectUIPW()

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