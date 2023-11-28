
Public Class Account

    Inherits System.Web.UI.Page
    Dim usertmp As String
    Dim nHasPayment As Boolean = False
    Dim nFullyPaid As Boolean = False
    Dim nHasSubmit As Boolean = False
    Dim nLQP As Integer
    Dim nIsOnHold As Boolean = False
    Dim nIsClosed As Boolean = False
    Dim nIsDelinquent As Boolean = False
    Dim LoginEmail As String
    Dim _tdn As String = Nothing
    Dim _webassessno As String = Nothing
    Dim _txnrefno As String = Nothing
    Dim _amount As String = Nothing

    Private Sub btn_View_ServerClick(sender As Object, e As EventArgs) Handles btn_View.ServerClick
        Try
            ' ORNO = hdnEORno.Value
            Dim _class As New eOR
            Dim eORNO As String = hdnEORno.Value
            Process.TransactionType = hdnTAXTYPE.Value
            ReportViewer.TAXTYPE_eOR = hdnTAXTYPE.Value
            ReportViewer.DT0_eOR = Nothing
            ReportViewer.DT1_eOR = Nothing
            ReportViewer.DT2_eOR = Nothing

            ReportViewer.DT0_eOR = _class.Print_Template
            ReportViewer.DT1_eOR = _class.Print_Report(eORNO)
            ReportViewer.DT2_eOR = _class.Print_TOP(eORNO)

            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=eOR','_blank');</script>")

            ' Load_Report()
        Catch ex As Exception

        End Try
    End Sub

    Sub Load_GridviewEOR()
        Dim err As String = Nothing
        Try
            Dim _Class As New eOR
            gv_eor.DataSource = _Class.Get_SentEorList(err, cSessionUser._pUserID)
            gv_eor.DataBind()
        Catch ex As Exception
            snackbar("red", err)
        End Try
    End Sub

    Protected Sub PageIndexChanging_gv_eor(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            gv_eor.PageIndex = e.NewPageIndex
            gv_eor.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Sub Inquire_Payments()
        Try
            Dim _nclass As New cDalPaymentInquiry
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nclass.Update_NoGatewaySelected()
            _nclass.PaymentInquiry(_nclass.Get_txnrefno_list())
        Catch ex As Exception

        End Try
    End Sub

    Sub ShowConsentModal()
        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "ShowConsentModal();", True)
    End Sub

    Private Sub _mSubValidateEnrollment()
        Try
            '----------------------------------
            Dim _nClass As New cDalSOSRPTAS
            Dim myOutPut As String
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "RPTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names

            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pTDN = _otxtEnterPropTDN.Value
            _nClass._pORNO = _otxtEnterPropORNo.Value
            _nClass._pEmail = LoginEmail
            '----------------------------------
            Dim err As String = Nothing
            Dim qry As String = Nothing
            _nClass._pValidateTdn(err, qry)

            If String.IsNullOrEmpty(err) = False Then
                ' snackbar("red", err)
                hdn_ERR.Value += ";_pValidateTdn:" & err
                Exit Sub
            Else
                hdn_ERR.Value += ";_pValidateTdn:OK"
            End If

            myOutPut = _nClass._pStatus
            'hdn_ERR.Value = err & ";" & qry & ";" & myOutPut

            If myOutPut = 0 Then
                snackbar("red", "TDN Not Validated!")
                successEnrollment.Value = "Failed"
            ElseIf myOutPut = 1 Then
                Dim _nclass2 As New cDalGetModules
                _nclass2._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                If _nclass2._pSubGetAvailableModules("RPT_Enrollment_AutoApprove") = True Then
                    'Auto-Approve
                    Dim _nClass3 As New cDalVerifications
                    _nClass3._pUserEmail = cSessionUser._pUserID
                    _nClass3._pAccountNo = _otxtEnterPropTDN.Value
                    _nClass3._pOrNo = _otxtEnterPropORNo.Value
                    _nClass3._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
                    _nClass3._pUpdateVerificationAssessor(True, cSessionUser._pUserID, err, qry)

                    If String.IsNullOrEmpty(err) = False Then
                        hdn_ERR.Value += ";_pUpdateVerificationAssessor:" & err
                        Exit Sub
                    Else
                        hdn_ERR.Value += ";_pUpdateVerificationAssessor:OK"
                    End If


                    successEnrollment.Value = "Auto-Approve"
                    snackbar("green", "Enrollment Success")
                Else
                    Dim Emails As String
                    Dim sent As Boolean
                    Dim Body As String = "Taxpayer has applied for Real Property Enrollment with the following details: " & _
                           "<br> Email Address : " & cSessionUser._pUserID & _
                           "<br> TDN : " & _otxtEnterPropTDN.Value & _
                           "<br> Please login to your Web Account to Assess the Application. Thank you <br><br>"

                    cDalNewSendEmail.get_Emails("ASSESSOR", Emails)
                    cDalNewSendEmail.SendEmail(Emails, "Real Property Enrollment", Body, sent, , 1)
                    successEnrollment.Value = "Success"
                End If

            ElseIf myOutPut = 2 Then
                snackbar("red", "TDN Already Exist!")
                successEnrollment.Value = "Failed"
            ElseIf myOutPut = 3 Then
                snackbar("red", "TDN Already Cancelled!")
                successEnrollment.Value = "Failed"

            End If


        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try

        '----------------------------------

    End Sub
    Private Sub _mSubCheckEnrollment()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pAcctNo = _otxtEnterBusinessBIN.Value
            _nClass._pORNo = _otxtEnterBusinessORNo.Value
            _nClass._pEmail = LoginEmail.Replace(".", "") 'cSessionUser._pUserID.Replace(".", "")
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            '_nClass._pForYear = Year(Today)
            _nClass._pEmail2 = LoginEmail 'cSessionUser._pUserID
            '----------------------------------

            _nClass._pSubCheckEnroll()

            myOutPut = _nClass._nOutput

            If myOutPut = 0 Then
                'MsgBox("Invalid Account!")
                snackbar("red", "Invalid Account!")
                successEnrollment.Value = "Failed"
            ElseIf myOutPut = 1 Then
                'MsgBox("Account already enrolled!")
                snackbar("red", "Account is already enrolled and submitted for verification!")

                _nClass._pSubSelectEnroll()
                ' GridView1.AutoGenerateColumns = True
                GridView1.DataSource = _nClass._mDataTable
                GridView1.DataBind()

                _nClass._pSubSelectForPayment()
                _oGVBusinessPayment.DataSource = _nClass._mDataTable
                _oGVBusinessPayment.DataBind()





                successEnrollment.Value = "Failed"
            Else
                _nClass._pSubGetBusDetailExtn()
                _nClass._pSubSelectEnroll()
                ' GridView1.AutoGenerateColumns = True
                GridView1.DataSource = _nClass._mDataTable
                GridView1.DataBind()

                _nClass._pSubSelectForPayment()
                _oGVBusinessPayment.DataSource = _nClass._mDataTable
                _oGVBusinessPayment.DataBind()

                successEnrollment.Value = "Success"
                Dim Emails As String
                Dim sent As Boolean
                Dim Body As String = "Taxpayer has applied for Business Enrollment with the following details: " & _
                       "<br> Email Address : " & cSessionUser._pUserID & _
                       "<br> BIN : " & _otxtEnterBusinessBIN.Value & _
                       "<br> Please login to your Web Account to Assess the Application. Thank you <br><br>"

                cDalNewSendEmail.get_Emails("BPLO", Emails)
                cDalNewSendEmail.SendEmail(Emails, "Business Enrollment", Body, sent, , 1)
            End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Private Sub MsgBox(ByVal strMessage As String)
        'Begin building the script
        Dim strScript As String = "<SCRIPT LANGUAGE=""JavaScript"">" & vbCrLf
        strScript += "alert(""" & strMessage & """)" & vbCrLf
        strScript += "</SCRIPT>"
        'Register the script for the client side
        ClientScript.RegisterStartupScript(GetType(String), "messageBox", strScript)
    End Sub


    'Private Sub btnEnroll_ServerClick(sender As Object, e As EventArgs) Handles btnEnroll.ServerClick
    '    '_mSubCheckEnrollment()
    'End Sub

    'Sub snackbar(Color As String, Caption As String)
    '    If Color = "red" Then
    '        _oLabelSnackbar.Text = Caption
    '        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

    '    ElseIf Color = "green" Then
    '        _oLabelSnackbargreen.Text = Caption
    '        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
    '    End If
    'End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
            Response.Redirect("Register.aspx")
            Exit Sub
        End If


        Dim _nQtrPay As String
        Dim _nHasPayment As Boolean


        Try

            If cSessionUser._pNewAcc = 1 Then

            End If


            LoginEmail = cSessionUser._pUserID
            Dim Particulars As String = Nothing
            If Not IsPostBack Then

                Dim _nClass2 As New cHardwareInformation
                Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
                Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri

                Get_Modules()
                Get_TransactionHistory()
                Load_GridviewEOR()
                'Inquire_Payments()

                If _nMachineName = "MANDAUEWEBSVR" Then
                    _otxtEnterPropTDN.Attributes.Add("placeholder", "_ _ _ _ - _ _ _ - _ _ _ _ _")
                    tdn_placeholder.Style.Add("display", "")
                    _otxtEnterPropORNo.Attributes.Add("placeholder", "_ _ _ _ _ _ _")
                    pin_Placeholder.Style.Add("display", "")
                End If

            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")

                If action = "RPTINFORMATION" Then
                    cSessionLoader._pTDN = Request("__EVENTARGUMENT")
                    Response.Redirect("RPTINFORMATION.aspx")
                ElseIf action = "RPTTRANS" Then
                    cSessionLoader._pTDN = Request("__EVENTARGUMENT")
                ElseIf action = "RPTBILLING" Then
                    cSessionLoader._pTDN = "'" & Request("__EVENTARGUMENT") & "'"
                    cDalPayment.RPT_Single_TDN = Request("__EVENTARGUMENT")

                    'check if delinquent
                    Dim Err As String = Nothing
                    Dim _nclassGetModules As New cDalGetModules
                    _nclassGetModules._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                    If _nclassGetModules._pSubGetAvailableModules("RPT_Payment_Delinquent") = False Then
                        Dim _nClassDelinquent As New cDalSOSRPTAS
                        _nClassDelinquent._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

                        If _nClassDelinquent.isDelinquent(cSessionLoader._pTDN, Err) Then
                            If Err = "OK" Then
                                snackbar("red", "Delinquent TDN")
                            Else
                                snackbar("red", Err)
                            End If

                            Exit Sub
                        End If
                    End If

                    Dim _nClassX As New cDalSOSRPTAS
                    _nClassX._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

                    If _nClassX.ExistsInRPTMAST(cSessionLoader._pTDN) = False Then
                        snackbar("red", "TDN was changed.")
                        Exit Sub
                    End If

                    Dim _nClass3 As New cDalSOSRPTAS
                    _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
                    If _nClass3.hasTaxCredit(cSessionLoader._pTDN, Err) = True Then
                        If Err <> Nothing Then
                            snackbar("red", Err)
                        Else
                            snackbar("red", "TDN has Tax Credit")
                        End If
                        Exit Sub
                    End If

                    If _nClass3.hasSHORT(cSessionLoader._pTDN, Err) = True Then
                        If Err <> Nothing Then
                            snackbar("red", Err)
                        Else
                            snackbar("red", "TDN has Short Payment")
                        End If
                        Exit Sub
                    End If

                    Dim _arrTag As String() = {"CARP", "LITIGATION", "WARRANT OF LEVY"}
                    For index As Integer = 0 To _arrTag.Count - 1
                        If _nClass3.hasTag(cSessionLoader._pTDN, _arrTag(index).ToString, Err) = True Then
                            If Err <> Nothing Then
                                snackbar("red", Err)
                            Else
                                snackbar("red", "TDN was Tagged [" & _arrTag(index).ToString & "]")
                            End If
                            Exit Sub
                        End If
                    Next




                    '               If checkpending() = True Then Exit Sub

                    Dim _nClass As New cDalPayment
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                 
                    'If _nClass.PaymentAttemptFound(_tdn, _webassessno, _txnrefno, _amount) Then
                    '    cDalPayment._WebAssessNo = _webassessno
                    '    cDalPayment._TXNREFNO = _txnrefno
                    '    ShowConsentModal()
                    '    snackbar("red", "TDN has Pending Payment")
                    '    Exit Sub
                    'Else
                    Response.Redirect("RPTBilling.aspx")
                    '  End If



                ElseIf action = "RPTOtherTransaction" Then
                    cSessionLoader._pRPTKind = hdnkind.Value
                    cSessionLoader._pRPTLocation = hdnlocation.Value
                    cSessionLoader._pRPTOwnerName = hdnownername.Value
                    cSessionLoader._pRPTPin = hdnpin.Value
                    cSessionLoader._pTDN = hdntdn.Value
                    Response.Redirect("RPTOtherTransaction.aspx")

                ElseIf action = "PropertyEnroll" Then

                    _mSubValidateEnrollment()
                    Get_RPTAccounts()

                    If successEnrollment.Value = "Success" Then
                        Particulars = "TDN=" & _otxtEnterPropTDN.Value & _
                                     ";ORNo=" & _otxtEnterPropORNo.Value & _
                                     ";Status=Submitted for Verification;"
                        Dim _nClass2 As New cDalTransactionHistory
                        _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                        _nClass2._pSubInsertHistory("-", LoginEmail, "RPT", "Enrollment", "TDN:" & _otxtEnterPropTDN.Value, _
                                Particulars, _
                                "PENDING")

                        ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal('RPT');", True)
                        _pNotifyTaxPayer("Property")


                    ElseIf successEnrollment.Value = "Auto-Approve" Then
                        Particulars = "TDN=" & _otxtEnterPropTDN.Value & _
                                   ";ORNo=" & _otxtEnterPropORNo.Value & _
                                   ";Status=Auto-Approve;"
                        Dim _nClass2 As New cDalTransactionHistory
                        _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                        _nClass2._pSubInsertHistory("-", LoginEmail, "RPT", "Enrollment", "TDN:" & _otxtEnterPropTDN.Value, _
                                Particulars, _
                                "APPROVED")

                    End If

                    _otxtEnterPropORNo.Value = ""
                    _otxtEnterPropTDN.Value = ""

                    Exit Sub
                Else

                    Dim _nStr() As String
                    Dim valAccount As String
                    Dim valStatus As String
                    If Request("__EVENTARGUMENT").Contains(":") Then
                        _nStr = Request("__EVENTARGUMENT").Split(":")
                        valAccount = _nStr(0).ToString
                        valStatus = _nStr(1).ToString
                    Else
                        valAccount = Request("__EVENTARGUMENT")
                    End If



                    If action = "Information" Then
                        cSessionLoader._pAccountNo = valAccount ' Request("__EVENTARGUMENT")
                        Dim _nClass2 As New cDalNewBP
                        Dim exists As Boolean
                        _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                        _nClass2.checkIfNewBP(valAccount, exists)

                        If exists = True Then
                            NewBP_Payment.ACCTNO = valAccount
                            Response.Redirect("NewBP_Payment.aspx")
                        Else
                            Response.Redirect("AccountInformation.aspx")
                        End If


                    End If

                    If action = "Other Trans" Then
                        cSessionLoader._pAccountNo = valAccount ' Request("__EVENTARGUMENT")
                        Response.Redirect("BPOtherTransaction.aspx")
                    End If


                    If action = "Payment" Then
                        'Dim _nStr() As String = Request("__EVENTARGUMENT").Split(":")
                        'Dim _nStatus As String
                        'Dim Col = Request("__EVENTTARGET")
                        cSessionLoader._pStatus = valStatus

                        Dim _nClass3 As New cDalNewBP
                        Dim exists As Boolean
                        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                        _nClass3.checkIfNewBP(valAccount, exists)

                        If exists = True Then
                            NewBP_Payment.ACCTNO = valAccount
                            Response.Redirect("NewBP_Payment.aspx")
                        Else

                            If cSessionLoader._pStatus = "NEW" Then

                                cSessionLoader._pAccountNo = _nStr(0).ToString
                                ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + cSessionLoader._pAccountNo + "');", True)
                                _AcquireLedger()
                                Response.Redirect("Report/Report.aspx?ReportType=TOP", False)
                                Exit Sub

                            End If

                            cSessionLoader._pAccountNo = valAccount 'Request("__EVENTARGUMENT")
                            Response.Redirect("BusinessRenewalPayment2.aspx", False)
                        End If



                        Exit Sub
                    End If

                    If action = "Renew" Then
                        Dim _nClass As New cDalBPSOS
                        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                        Dim _nClBP As New cDalGlobalConnectionsDefault
                        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                        _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                        _nClBP._pSubRecordSelectSpecific()

                        ''----------------------------------
                        ''Specify Blank to Select Nothing but Column Names
                        '_nClass._pAcctNo = valAccount '  Request("__EVENTARGUMENT")
                        _nClass._pLocServer = _nClBP._pDBDataSource
                        _nClass._pLocDB = _nClBP._pDBInitialCatalog
                        ''_nClass._pForYear = Year(Today)
                        _nClass._pSubGetCurYear()
                        _nClass._pForYear = _nClass._nCurYear
                        '_nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
                        '_nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
                        '_nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
                        '_nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
                        ''----------------------------------
                        '_nClass._pSubGetBusDetailExtn()

                        cSessionLoader._pAccountNo = valAccount 'Request("__EVENTARGUMENT")
                        _nClass._pAcctNo = cSessionLoader._pAccountNo
                        '_nClass._pSubCheckhasPayment()
                        '_nHasPayment = _nClass._nOutput

                        'If nHasPayment = True Then
                        '    snackbar("red", "Account already renewed!.")
                        '    Exit Sub
                        'End If

                        ''_mSubCheckIsDelinquent2()
                        ''If nIsDelinquent = True Then Exit Sub


                        '_nClass._pSubCheckPayment()
                        '_nQtrPay = _nClass._nOutput
                        '_mSubCheckifHasPayment()
                        '_mSubCheckifHasSubmit()



                        'If _nQtrPay = 4 Or nFullyPaid = True Then
                        '    'MsgBox("Account already enrolled!")
                        '    snackbar("red", "Account already renewed!.")
                        'ElseIf nHasPayment = True Then
                        '    Response.Redirect("BusinessRenewalPayment.aspx")
                        'ElseIf nHasSubmit = True Then
                        '    snackbar("red", "Account already forwarded to BPLO!")

                        '  Else

                        If _nClass.CheckSubmitted(cSessionLoader._pAccountNo) = True Then
                            snackbar("red", "Account already forwarded to BPLO!")
                        Else

                            _nClass._pSubGetBusDetail_TAXPAYER()
                            Response.Redirect("BusinessRenewalTaxPayer2.aspx", False)
                        End If

                        Exit Sub
                    End If

                    If action = "BusinessEnroll" Then

                        '_mSubCheckIsOnHold()
                        'If nIsOnHold = True Then Exit Sub

                        ' _mSubCheckIsDelinquent()
                        '   If nIsDelinquent = True Then Exit Sub

                        _mSubCheckIsClosed()
                        If nIsClosed = True Then Exit Sub

                        _mSubCheckEnrollment()

                        If successEnrollment.Value = "Success" Then
                            Particulars = "BIN=" & _otxtEnterBusinessBIN.Value & _
                                          ";ORNo=" & _otxtEnterBusinessORNo.Value & _
                                          ";Status=Submitted for Verification;"
                            Dim _nClass2 As New cDalTransactionHistory
                            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                            _nClass2._pSubInsertHistory("-", LoginEmail, "BP", "Enrollment", "BIN:" & _otxtEnterBusinessBIN.Value, _
                                    Particulars, _
                                    "PENDING")
                            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal('BP');", True)
                            _pNotifyTaxPayer("Business")
                        End If

                        _otxtEnterBusinessBIN.Value = ""
                        _otxtEnterBusinessORNo.Value = ""
                    End If

                    If action = "TemporaryPermit" Then
                        cSessionLoader._pAccountNo = valAccount

                        Response.Redirect("Permit.aspx")
                    End If

                End If


            End If

            ''@ADDED 20231110 LOUIE
            _oDivMultipleDN.Visible = IIf(cInit_eOR.IsEOR_Enabled = True, False, True) 'TODO: Hides Multiple TDN Selection if EOR is Enable  
            ''@ADDED 20231006 LOUIE
            _oDivCourier.Visible = cCourier._Init_Courier(_oHl_Keri) 'TODO: Display available courier services integration
            ''@ADDED 202031103 LOUIED
            div_BP_BP_TempPermit.Visible = _ForTemporaryPermit() 'TODO: Display section for Generate Tempoarary Permit
        Catch ex As Exception

        End Try
    End Sub

    Private Function _ForTemporaryPermit() As Boolean
        _ForTemporaryPermit = False
        If cGlobalConnections._pSqlCxn_BPLTAS.Database.ToUpper.Contains("PASAY") = True Then Return True Else Return False

    End Function

    Private Sub _AcquireLedger() '@Added 20211102
        Try
            _fnCheckIfHasExistingCurrentYearRecordLocal()
            _InitData()

        Catch ex As Exception

        End Try
    End Sub

    Private Function _fnCheckIfHasExistingCurrentYearRecordLocal() As Boolean
        Try


            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                ._pAction = "SELECT"
                ._pSelect = "Select AcctNo  from BUSEXTN "
                ._pCondition = " WHERE Acctno = ''" & cSessionLoader._pAccountNo & "'' and foryear = year(getdate()) "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable
                If _nDataTable.Rows.Count > 0 Then


                    Dim _nAccountNo As String

                    _nAccountNo = _nDataTable.Rows(0).Item("ACCTNO")

                    _RemoveBusline_PerUser(_nAccountNo)
                    _RemoveBusExtn_PerUser(_nAccountNo)
                    _RemoveBILLINGTEMP_PerUser(_nAccountNo)
                    '_RemoveBusMastExtn_PerUser(_nAccountNo)
                    '_RemoveBusmast_PerUser(_nAccountNo)
                    _InsertLivetoWeb_BUSLINE()
                    _InsertLivetoWeb_BUSEXTN()
                    _InsertLivetoWeb_BILLINGTEMP()
                    Return True
                Else
                    Return False
                End If

            End With

        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub _RemoveBusMastExtn_PerUser(ByVal _nAcctNo As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'Dim _nClBPLTAS As New cDalGlobalConnectionsDefault
            '_nClBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            '_nClBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            '_nClBPLTAS._pSubRecordSelectSpecific()

            'Dim _nLiveServer As String = _nClBPLTAS._pDBDataSource
            'Dim _nLiveDatabase As String = _nClBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BUSMASTEXTN  "
                ._pCondition = " WHERE ACCTNO =''" & _nAcctNo & "'' and Foryear = Year(Getdate()) "
                '._pCondition = " WHERE ACCTNO COLLATE database_default IN (" & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSMASTEXTN " & _
                '               " where ACCTNO in " & _
                '               " ( " & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSMAST Where EMAILADDR=''" & cSessionUser._pUserID & "'' " & _
                '               " ) " & _
                '               " and foryear = cast(year(getdate()) as nvarchar(4)) " & _
                '               " ) "
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _RemoveBusmast_PerUser(ByVal _nAcctNo As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing


            'Dim _nClBPLTAS As New cDalGlobalConnectionsDefault
            '_nClBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            '_nClBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            '_nClBPLTAS._pSubRecordSelectSpecific()

            'Dim _nLiveServer As String = _nClBPLTAS._pDBDataSource
            'Dim _nLiveDatabase As String = _nClBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BUSMAST  "
                ._pCondition = " WHERE ACCTNO =''" & _nAcctNo & "'' "
                '._pCondition = " WHERE ACCTNO COLLATE database_default IN (" & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSLINE " & _
                '                " where ACCTNO in " & _
                '                " ( " & _
                '                " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSMAST Where EMAILADDR=''" & cSessionUser._pUserID & "'' " & _
                '                " ) " & _
                '                " and foryear = cast(year(getdate()) as nvarchar(4)) " & _
                '                " ) "
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _InitData()


        'If _FnIsBusMastExist() = False Then
        '    '' Get Account Information
        '    '_InsertLiveToWeb_BUSMAST()
        '    '_InsertLiveToWeb_BUSMASTEXTN()
        '    '---------------------------------
        '    '' Overwrite Existing Ledger
        '    _RemoveBusExtn()
        '    _RemoveBusline()
        '    _InsertLivetoWeb_BUSLINE()
        '    _InsertLivetoWeb_BUSEXTN()
        '    '---------------------------------
        'Else
        '    _UpdateWeb_BUSMAST() ' Update Email Address
        'End If
    End Sub

    Private Sub _UpdateWeb_BUSMAST()
        Try

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BUSMAST SET EMAILADDR = ''" & cSessionUser._pUserID & "''"
                ._pCondition = "WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "''"
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try

    End Sub


    Private Sub _RemoveBusline()
        Try

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BUSLINE  "
                ._pCondition = "WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _RemoveBusline_PerUser(ByVal _nAcctNo As String)
        Try

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'Dim _nClBPLTAS As New cDalGlobalConnectionsDefault
            '_nClBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            '_nClBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            '_nClBPLTAS._pSubRecordSelectSpecific()

            'Dim _nLiveServer As String = _nClBPLTAS._pDBDataSource
            'Dim _nLiveDatabase As String = _nClBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BUSLINE  "
                ._pCondition = " WHERE ACCTNO =''" & _nAcctNo & "'' and Foryear = Year(Getdate()) "
                '._pCondition = " WHERE ACCTNO COLLATE database_default IN (" & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSLINE " & _
                '               " where ACCTNO in " & _
                '               " ( " & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSMAST Where EMAILADDR=''" & cSessionUser._pUserID & "'' " & _
                '               " ) " & _
                '               " and foryear = cast(year(getdate()) as nvarchar(4)) " & _
                '               " ) "
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _RemoveBusExtn()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BUSEXTN  "
                ._pCondition = "WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub


    Private Sub _RemoveBILLINGTEMP_PerUser(ByVal _nAcctNo As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'Dim _nClBPLTAS As New cDalGlobalConnectionsDefault
            '_nClBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            '_nClBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            '_nClBPLTAS._pSubRecordSelectSpecific()

            'Dim _nLiveServer As String = _nClBPLTAS._pDBDataSource
            'Dim _nLiveDatabase As String = _nClBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BILLINGTEMP  "
                ._pCondition = " WHERE ACCTNO =''" & _nAcctNo & "'' and Foryear = Year(Getdate()) "
                '._pCondition = " WHERE ACCTNO COLLATE database_default IN (" & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSEXTN " & _
                '               " where ACCTNO in " & _
                '               " ( " & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSMAST Where EMAILADDR=''" & cSessionUser._pUserID & "'' " & _
                '               " ) " & _
                '               " and foryear = cast(year(getdate()) as nvarchar(4)) " & _
                '               " ) "
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _RemoveBusExtn_PerUser(ByVal _nAcctNo As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'Dim _nClBPLTAS As New cDalGlobalConnectionsDefault
            '_nClBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            '_nClBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            '_nClBPLTAS._pSubRecordSelectSpecific()

            'Dim _nLiveServer As String = _nClBPLTAS._pDBDataSource
            'Dim _nLiveDatabase As String = _nClBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BUSEXTN  "
                ._pCondition = " WHERE ACCTNO =''" & _nAcctNo & "'' and Foryear = Year(Getdate()) "
                '._pCondition = " WHERE ACCTNO COLLATE database_default IN (" & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSEXTN " & _
                '               " where ACCTNO in " & _
                '               " ( " & _
                '               " Select ACCTNO from [" & _nLiveServer & "].[" & _nLiveDatabase & "].dbo.BUSMAST Where EMAILADDR=''" & cSessionUser._pUserID & "'' " & _
                '               " ) " & _
                '               " and foryear = cast(year(getdate()) as nvarchar(4)) " & _
                '               " ) "
                ._pExec(_nSuccess, _nErrMsg)
            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub
    Private Function _InsertLiveToWeb_BUSMAST() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO BUSMAST " & _
                "([ACCTNO],[DATE_ESTA],[APP_DATE],[STATCODE] ,[FACODE],[LAST_NAME],[FIRST_NAME],[MIDDLE_NAME],[OWNERTEL],[OWNERADDR],[CONTACT],[CONTTEL],[COMMNAME]" & _
                ",[COMMADDR],[NO_EMP],[NATURE],[MAIN],[OWNCODE],[DISTCODE],[BRGYCODE],[STRTCODE],[TIN_NO],[DTI_NO],[SEC_NO],[SSS_NO],[TIN_DATE],[DTI_DATE],[SSS_DATE]" & _
                ",[SEC_DATE],[REMARKS],[BRANCH],[P_OWNER],[P_OWNERADDR],[P_ADMIN],[P_RENT],[BLDGPERMITNO],[BLDGPERMITDATE],[OCCUPANCYNO],[OCCUPANCYDATE],[BOI_NO],[BOI_DATE]" & _
                ",[ACR_NO],[ACR_DATE],[CDA_NO],[CDA_DATE],[BC_NO],[BC_DATE],[CTC_NO],[CTC_DATE],[CTC_PLACE],[IFTRANSF],[PLATENO],[STALLNO],[XSITE],[GOCC],[IsCHANGECOMM]" & _
                ",[isADDRESS],[IsTCampaign],[IsMarket],[CTC_AMT],[IsCompromise],[GRPBLDG],[STICKERNO],[CTZNCODE],[isTourism],[EDITTEDBY],[APPROVEDBY],[STATDATE],[STATBY]" & _
                ",[STATUS],[STATHOLD],[STATREMARKS],[STATDROP],[STATDROPREM],[STATDROPBY],[STATDROPDATE],[STATDROPTIME],[PBN],[P_RENTDATE],[Volume_Allow],[Additional_Vol]" & _
                ",[INCORPORATORS],[EMAILADDR],[IsSpecial],[EXAMINEDBY],[CPNO],[CPNO2],[CPNO3],[EMAILADDR2],[EDITTEDBYDATE],[EXAMINEDBYDATE],[DOWNLOADED],[UPLOADED],[PEZA_NO]" & _
                ",[PEZA_DATE],[IS_TERMINAL]) " & _
                "SELECT " & _
                "[ACCTNO], [DATE_ESTA], GETDATE(), ''R'', [FACODE], [LAST_NAME], [FIRST_NAME], [MIDDLE_NAME], [OWNERTEL], [OWNERADDR], [CONTACT], [CONTTEL], [COMMNAME]" & _
                ",[COMMADDR],ISNULL([NO_EMP],0)NO_EMP,[NATURE],[MAIN],[OWNCODE],[DISTCODE],[BRGYCODE],[STRTCODE],[TIN_NO],[DTI_NO],[SEC_NO],[SSS_NO],[TIN_DATE],[DTI_DATE],[SSS_DATE]" & _
                ",[SEC_DATE],''Reviewed/ For Assessment Billing'',[BRANCH],[P_OWNER],[P_OWNERADDR],[P_ADMIN],[P_RENT],[BLDGPERMITNO],[BLDGPERMITDATE],[OCCUPANCYNO],[OCCUPANCYDATE],[BOI_NO],[BOI_DATE]" & _
                ",[ACR_NO],[ACR_DATE],[CDA_NO],[CDA_DATE],[BC_NO],[BC_DATE],[CTC_NO],[CTC_DATE],[CTC_PLACE],[IFTRANSF],[PLATENO],[STALLNO],[XSITE],[GOCC],[IsCHANGECOMM]" & _
                ",[isADDRESS],[IsTCampaign],[IsMarket],[CTC_AMT],[IsCompromise],[GRPBLDG],[STICKERNO],[CTZNCODE],[isTourism],[EDITTEDBY],[APPROVEDBY],[STATDATE],[STATBY]" & _
                ",[STATUS],[STATHOLD],[STATREMARKS],[STATDROP],[STATDROPREM],[STATDROPBY],[STATDROPDATE],[STATDROPTIME],[PBN],[P_RENTDATE],[Volume_Allow],[Additional_Vol]" & _
                ",[INCORPORATORS],[EMAILADDR],[IsSpecial],[EXAMINEDBY],[CPNO],[CPNO2],[CPNO3],[EMAILADDR2],[EDITTEDBYDATE],[EXAMINEDBYDATE],[DOWNLOADED],[UPLOADED],[PEZA_NO]" & _
                ",[PEZA_DATE],[IS_TERMINAL] " & _
                "FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].DBO.BUSMAST "

                ._pCondition = "WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "''"

                ._pExec(_nSuccess, _nErrMsg)
            End With
            Return _nSuccess
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            Return False
        End Try
    End Function

    Private Function _InsertLiveToWeb_BUSMAST_PerUser() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO BUSMAST " & _
                "([ACCTNO],[DATE_ESTA],[APP_DATE],[STATCODE] ,[FACODE],[LAST_NAME],[FIRST_NAME],[MIDDLE_NAME],[OWNERTEL],[OWNERADDR],[CONTACT],[CONTTEL],[COMMNAME]" & _
                ",[COMMADDR],[NO_EMP],[NATURE],[MAIN],[OWNCODE],[DISTCODE],[BRGYCODE],[STRTCODE],[TIN_NO],[DTI_NO],[SEC_NO],[SSS_NO],[TIN_DATE],[DTI_DATE],[SSS_DATE]" & _
                ",[SEC_DATE],[REMARKS],[BRANCH],[P_OWNER],[P_OWNERADDR],[P_ADMIN],[P_RENT],[BLDGPERMITNO],[BLDGPERMITDATE],[OCCUPANCYNO],[OCCUPANCYDATE],[BOI_NO],[BOI_DATE]" & _
                ",[ACR_NO],[ACR_DATE],[CDA_NO],[CDA_DATE],[BC_NO],[BC_DATE],[CTC_NO],[CTC_DATE],[CTC_PLACE],[IFTRANSF],[PLATENO],[STALLNO],[XSITE],[GOCC],[IsCHANGECOMM]" & _
                ",[isADDRESS],[IsTCampaign],[IsMarket],[CTC_AMT],[IsCompromise],[GRPBLDG],[STICKERNO],[CTZNCODE],[isTourism],[EDITTEDBY],[APPROVEDBY],[STATDATE],[STATBY]" & _
                ",[STATUS],[STATHOLD],[STATREMARKS],[STATDROP],[STATDROPREM],[STATDROPBY],[STATDROPDATE],[STATDROPTIME],[PBN],[P_RENTDATE],[Volume_Allow],[Additional_Vol]" & _
                ",[INCORPORATORS],[EMAILADDR],[IsSpecial],[EXAMINEDBY],[CPNO],[CPNO2],[CPNO3],[EMAILADDR2],[EDITTEDBYDATE],[EXAMINEDBYDATE],[DOWNLOADED],[UPLOADED],[PEZA_NO]" & _
                ",[PEZA_DATE],[IS_TERMINAL]) " & _
                "SELECT " & _
                " [ACCTNO] + ''_'' + CONVERT(VARCHAR(8),GETDATE(), 112) , [DATE_ESTA], [APP_DATE], [STATCODE], [FACODE], [LAST_NAME], [FIRST_NAME], [MIDDLE_NAME], [OWNERTEL], [OWNERADDR], [CONTACT], [CONTTEL], [COMMNAME]" & _
                ",[COMMADDR],ISNULL([NO_EMP],0)NO_EMP,[NATURE],[MAIN],[OWNCODE],[DISTCODE],[BRGYCODE],[STRTCODE],[TIN_NO],[DTI_NO],[SEC_NO],[SSS_NO],[TIN_DATE],[DTI_DATE],[SSS_DATE]" & _
                ",[SEC_DATE],[REMARKS],[BRANCH],[P_OWNER],[P_OWNERADDR],[P_ADMIN],[P_RENT],[BLDGPERMITNO],[BLDGPERMITDATE],[OCCUPANCYNO],[OCCUPANCYDATE],[BOI_NO],[BOI_DATE]" & _
                ",[ACR_NO],[ACR_DATE],[CDA_NO],[CDA_DATE],[BC_NO],[BC_DATE],[CTC_NO],[CTC_DATE],[CTC_PLACE],[IFTRANSF],[PLATENO],[STALLNO],[XSITE],[GOCC],[IsCHANGECOMM]" & _
                ",[isADDRESS],[IsTCampaign],[IsMarket],[CTC_AMT],[IsCompromise],[GRPBLDG],[STICKERNO],[CTZNCODE],[isTourism],[EDITTEDBY],[APPROVEDBY],[STATDATE],[STATBY]" & _
                ",[STATUS],[STATHOLD],[STATREMARKS],[STATDROP],[STATDROPREM],[STATDROPBY],[STATDROPDATE],[STATDROPTIME],[PBN],[P_RENTDATE],[Volume_Allow],[Additional_Vol]" & _
                ",[INCORPORATORS],[EMAILADDR],[IsSpecial],[EXAMINEDBY],[CPNO],[CPNO2],[CPNO3],[EMAILADDR2],[EDITTEDBYDATE],[EXAMINEDBYDATE],[DOWNLOADED],[UPLOADED],[PEZA_NO]" & _
                ",[PEZA_DATE],[IS_TERMINAL] " & _
                "FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].DBO.BUSMAST "

                ._pCondition = "WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "''"

                ._pExec(_nSuccess, _nErrMsg)
            End With
            Return _nSuccess
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            Return False
        End Try
    End Function

    Private Sub _InsertLiveToWeb_BUSMASTEXTN()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = _
                    " INSERT INTO BUSMASTEXTN " & _
                        "(ACCTNO, PRES_NAME, AUTHO_REP, AUTHO_REP_POS, NO_EMP_M, NO_EMP_F, TAX_INDIC, IF_WITH_TAX, NO_EMP_LGU, FIRSTNAME, MIDDLENAME, LASTNAME, BLDG, STREET, CITY, BRGY, SUBD, PROVINCE, TEL, " & _
                        " EMAIL, EMRGNCY_CONTACT, EMRGNCY_TEL, EMRGNCY_MOBILE, EMRGNCY_EMAIL, TREAS_NAME, FORYEAR, PRES_GENDER, DOWNLOADED, UPLOADED) " & _
                    " SELECT " & _
                        " ACCTNO, PRES_NAME, AUTHO_REP, AUTHO_REP_POS, NO_EMP_M, NO_EMP_F, TAX_INDIC, IF_WITH_TAX, NO_EMP_LGU, FIRSTNAME, MIDDLENAME, LASTNAME, BLDG, STREET, CITY, BRGY, SUBD, PROVINCE, TEL, " & _
                        " EMAIL, EMRGNCY_CONTACT, EMRGNCY_TEL, EMRGNCY_MOBILE, EMRGNCY_EMAIL, TREAS_NAME, FORYEAR, PRES_GENDER, DOWNLOADED, UPLOADED " & _
                    " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.BUSMASTEXTN "
                ._pCondition = "WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' and ForYear = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _InsertLiveToWeb_BUSMASTEXTN_PerUser()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = _
                    " INSERT INTO BUSMASTEXTN " & _
                        "(ACCTNO, PRES_NAME, AUTHO_REP, AUTHO_REP_POS, NO_EMP_M, NO_EMP_F, TAX_INDIC, IF_WITH_TAX, NO_EMP_LGU, FIRSTNAME, MIDDLENAME, LASTNAME, BLDG, STREET, CITY, BRGY, SUBD, PROVINCE, TEL, " & _
                        " EMAIL, EMRGNCY_CONTACT, EMRGNCY_TEL, EMRGNCY_MOBILE, EMRGNCY_EMAIL, TREAS_NAME, FORYEAR, PRES_GENDER, DOWNLOADED, UPLOADED) " & _
                    " SELECT " & _
                        " [ACCTNO] + ''_'' + CONVERT(VARCHAR(8),GETDATE(), 112) , PRES_NAME, AUTHO_REP, AUTHO_REP_POS, NO_EMP_M, NO_EMP_F, TAX_INDIC, IF_WITH_TAX, NO_EMP_LGU, FIRSTNAME, MIDDLENAME, LASTNAME, BLDG, STREET, CITY, BRGY, SUBD, PROVINCE, TEL, " & _
                        " EMAIL, EMRGNCY_CONTACT, EMRGNCY_TEL, EMRGNCY_MOBILE, EMRGNCY_EMAIL, TREAS_NAME, FORYEAR, PRES_GENDER, DOWNLOADED, UPLOADED " & _
                    " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.BUSMASTEXTN "
                ._pCondition = "WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' and ForYear = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Function _InsertLivetoWeb_BUSLINE() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT "
                ._pSelect = "INSERT INTO [BUSLINE] " & _
                                "(ACCTNO, FORYEAR, BUS_CODE, STATCODE, BRGYCODE, LOCACODE, DATE_ESTA, DATECLOSE, BQTRIND, GQTRIND, GROSSREC, CAPITAL, AREA, PREVTAX, BUSTAX, BT_PAID, BT_PENPD, GARBAGE, GF_PAID, GF_PENPD, " & _
                                " MAYORS, MF_PAID, MF_PENPD, SANITARY, SF_PAID, SF_PENPD, FIRE, FF_PAID, FF_PENPD, ORNO1, ORNO2, L_DATEPD, GROSSREC0, GROSSREC1, GROSSREC2, GROSSREC3, GROSSREC4, BUSTAX0, BUSTAX1, " & _
                                " BUSTAX2, BUSTAX3, BUSTAX4, BRANGE_QTY, BCHOICE0, BCHOICE1, BCHOICE2, BCHOICE3, BCHOICE4, BQTY, BQTY1, BQTY2, BQTY3, BQTY4, BQTY5, BQTY6, BQTY7, BQTY8, BQTY9, BQTY10, GRANGE_QTY, GCHOICE1, " & _
                                " GCHOICE2, GCHOICE3, GCHOICE4, GQTY, GQTY1, GQTY2, GQTY3, GQTY4, GQTY5, GQTY6, GQTY7, GQTY8, GQTY9, GQTY10, MRANGE_QTY, MCHOICE1, MCHOICE2, MCHOICE3, MCHOICE4, MQTY, MQTY1, MQTY2, MQTY3, " & _
                                " MQTY4, MQTY5, MQTY6, MQTY7, MQTY8, MQTY9, MQTY10, SRANGE_QTY, SCHOICE1, SCHOICE2, SCHOICE3, SCHOICE4, SQTY, SQTY1, SQTY2, SQTY3, SQTY4, SQTY5, SQTY6, SQTY7, SQTY8, SQTY9, SQTY10, " & _
                                " MAINBUSIND, NEWSW, FRANGE_QTY, FCHOICE1, FCHOICE2, FCHOICE3, FCHOICE4, FQTY, FQTY1, FQTY2, FQTY3, FQTY4, FQTY5, FQTY6, FQTY7, FQTY8, FQTY9, FQTY10, GARBAGE_O, Sanitary_O, FIRE_O, BT_CREDIT, " & _
                                " GF_CREDIT, SF_CREDIT, MF_CREDIT, FF_CREDIT, BTCREDAPPL, GFCREDAPPL, MFCREDAPPL, SFCREDAPPL, FFCREDAPPL, TXCREDCODE, PERMITNO, PERM_DATE, PUSER_ID, MODEPAY, MODEPAYG, GMONTHIND, " & _
                                " BCODE, SHRTAMT, BT_YEAR, MF_YEAR, GF_YEAR, SF_YEAR, FF_YEAR, BT_DISCOUNT, GF_DISCOUNT, MF_DISCOUNT, SF_DISCOUNT, FF_DISCOUNT, I_YEAR1, I_DISCOUNT1, I_YEAR2, I_DISCOUNT2, I_YEAR3, " & _
                                " I_DISCOUNT3, I_YEAR4, I_DISCOUNT4, BT_NEWDUE, BT_SHRT2ND, BT_SHRT3RD, BT_SHRT4TH, BT_SHRT2NDPD, BT_SHRT3RDPD, BT_SHRT4THPD, GF_NEWDUE, GF_SHRT2ND, GF_SHRT3RD, GF_SHRT4TH, " & _
                                " GF_SHRT2NDPD, GF_SHRT3RDPD, GF_SHRT4THPD, MF_NEWDUE, MF_SHRT, MF_SHRTPD, SF_NEWDUE, SF_SHRT, SF_SHRTPD, FF_NEWDUE, FF_SHRT, FF_SHRTPD, WITH_SHRTPAY, NewBusCode, IsChangeLine, " & _
                                " Lock_Compromise, HASNEWREV, ISLOCKED, RASSESBY, RASSESDATE, DATECOPIED, IsTaxExempt, GFSHORT, SFSHORT, FFSHORT, BUSTAXPEN0, BUSTAXPEN1, BUSTAXPEN2, BUSTAXPEN3, GF_PAID_1ST, " & _
                                " GF_PENPD_1ST, GF_PAID_2ND, GF_PENPD_2ND, GF_PAID_3RD, GF_PENPD_3RD, GF_PAID_4TH, GF_PENPD_4TH, ISCOMPLETED, BT_PAID_1ST, BT_PENPD_1ST, BT_PAID_2ND, BT_PENPD_2ND, BT_PAID_3RD, " & _
                                " BT_PENPD_3RD, BT_PAID_4TH, BT_PENPD_4TH, GROSSCLOSE, GROSSCLOSE_PAID, DOWNLOADED, UPLOADED, EXISTGSHORT, LGFQTR, Particulars) "
                ._pSelect1 = " SELECT " & _
                                " ACCTNO, FORYEAR, BUS_CODE, STATCODE, BRGYCODE, LOCACODE, DATE_ESTA, DATECLOSE, BQTRIND, GQTRIND, GROSSREC, CAPITAL, AREA, PREVTAX, BUSTAX, BT_PAID, BT_PENPD, GARBAGE, GF_PAID, GF_PENPD, " & _
                                " MAYORS, MF_PAID, MF_PENPD, SANITARY, SF_PAID, SF_PENPD, FIRE, FF_PAID, FF_PENPD, ORNO1, ORNO2, L_DATEPD, GROSSREC0, GROSSREC1, GROSSREC2, GROSSREC3, GROSSREC4, BUSTAX0, BUSTAX1, " & _
                                " BUSTAX2, BUSTAX3, BUSTAX4, BRANGE_QTY, BCHOICE0, BCHOICE1, BCHOICE2, BCHOICE3, BCHOICE4, BQTY, BQTY1, BQTY2, BQTY3, BQTY4, BQTY5, BQTY6, BQTY7, BQTY8, BQTY9, BQTY10, GRANGE_QTY, GCHOICE1, " & _
                                " GCHOICE2, GCHOICE3, GCHOICE4, GQTY, GQTY1, GQTY2, GQTY3, GQTY4, GQTY5, GQTY6, GQTY7, GQTY8, GQTY9, GQTY10, MRANGE_QTY, MCHOICE1, MCHOICE2, MCHOICE3, MCHOICE4, MQTY, MQTY1, MQTY2, MQTY3, " & _
                                " MQTY4, MQTY5, MQTY6, MQTY7, MQTY8, MQTY9, MQTY10, SRANGE_QTY, SCHOICE1, SCHOICE2, SCHOICE3, SCHOICE4, SQTY, SQTY1, SQTY2, SQTY3, SQTY4, SQTY5, SQTY6, SQTY7, SQTY8, SQTY9, SQTY10, " & _
                                " MAINBUSIND, NEWSW, FRANGE_QTY, FCHOICE1, FCHOICE2, FCHOICE3, FCHOICE4, FQTY, FQTY1, FQTY2, FQTY3, FQTY4, FQTY5, FQTY6, FQTY7, FQTY8, FQTY9, FQTY10, GARBAGE_O, Sanitary_O, FIRE_O, BT_CREDIT, " & _
                                " GF_CREDIT, SF_CREDIT, MF_CREDIT, FF_CREDIT, BTCREDAPPL, GFCREDAPPL, MFCREDAPPL, SFCREDAPPL, FFCREDAPPL, TXCREDCODE, PERMITNO, PERM_DATE, PUSER_ID, MODEPAY, MODEPAYG, GMONTHIND, " & _
                                " BCODE, SHRTAMT, BT_YEAR, MF_YEAR, GF_YEAR, SF_YEAR, FF_YEAR, BT_DISCOUNT, GF_DISCOUNT, MF_DISCOUNT, SF_DISCOUNT, FF_DISCOUNT, I_YEAR1, I_DISCOUNT1, I_YEAR2, I_DISCOUNT2, I_YEAR3, " & _
                                " I_DISCOUNT3, I_YEAR4, I_DISCOUNT4, BT_NEWDUE, BT_SHRT2ND, BT_SHRT3RD, BT_SHRT4TH, BT_SHRT2NDPD, BT_SHRT3RDPD, BT_SHRT4THPD, GF_NEWDUE, GF_SHRT2ND, GF_SHRT3RD, GF_SHRT4TH, " & _
                                " GF_SHRT2NDPD, GF_SHRT3RDPD, GF_SHRT4THPD, MF_NEWDUE, MF_SHRT, MF_SHRTPD, SF_NEWDUE, SF_SHRT, SF_SHRTPD, FF_NEWDUE, FF_SHRT, FF_SHRTPD, WITH_SHRTPAY, NewBusCode, IsChangeLine, " & _
                                " Lock_Compromise, HASNEWREV, ISLOCKED, RASSESBY, RASSESDATE, DATECOPIED, IsTaxExempt, GFSHORT, SFSHORT, FFSHORT, BUSTAXPEN0, BUSTAXPEN1, BUSTAXPEN2, BUSTAXPEN3, GF_PAID_1ST, " & _
                                " GF_PENPD_1ST, GF_PAID_2ND, GF_PENPD_2ND, GF_PAID_3RD, GF_PENPD_3RD, GF_PAID_4TH, GF_PENPD_4TH, ISCOMPLETED, BT_PAID_1ST, BT_PENPD_1ST, BT_PAID_2ND, BT_PENPD_2ND, BT_PAID_3RD, " & _
                                " BT_PENPD_3RD, BT_PAID_4TH, BT_PENPD_4TH, GROSSCLOSE, GROSSCLOSE_PAID, DOWNLOADED, UPLOADED, EXISTGSHORT, LGFQTR, Particulars " & _
                                " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.BUSLINE "
                ._pCondition = " WHERE  ACCTNO = ''" & cSessionLoader._pAccountNo & "'' " & _
                               " AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Function


    Private Function _InsertLivetoWeb_BILLINGTEMP() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
                ._pAction = "INSERT "
                ._pSelect = "INSERT INTO [BILLINGTEMP] " & _
                              " ( Acctno, Foryear, Bus_Code, Desc1, Taxbase, Annualdue, Taxdue, PenDue, Totdue, Amt_Pd, Amt_PenPd, Discount, Taxcode, prevqtr, Qtryr1, Qtryr2, QtrPaid, Pres, Prev, Statcode, Newsw, ModeP, GradFix, Capital, Xsort, ORNo, " & _
                              "   DatePaid, BrgyCode, LocaCode, L_DatePD, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, Amt_Pd1, Amt_PenPd1, NewAmt_Pd, NewAmt_PenPd, NewTaxdue, NewPenDue, FieldName, PrevGMonth, GDateEsta," & _
                              "   GMonthPaid, DATE_ESTA, YearPeriod, NotEdit, NotDel, AssessTotal, UsedTCred, MainAcctCodePen, MainAcctDescPen, SubAcctCodePen, SubAcctDescPen, IsRegBill, ForClose, Area, xTotal, ADUE, xSQUENCELocal," & _
                              "   xSQUENCEPen, xSRS, xORNO, xSQUENCE, RES3, RES4, RES5, RES, RES1, RES2, QAMT, QDUE, PenYear, NotDelete, AAMT, I_DISCOUNT3, I_DISCOUNT4, I_DISCOUNT1, I_DISCOUNT2, I_YEAR2, I_YEAR3, I_YEAR4, I_YEAR1," & _
                              "   APPROVED, DATEAPP, TAXBALANCE, PENBALANCE, ForCompromise, ISPOSTED, EDITTEDBY, APPROVEDBY, EDITEDBY, EDPPrinted, Remarks0, Remarks1, RASSESBY, Remarks, xMainAcctCode, xMainAcctDesc," & _
                              "   xSubAcctCode, xSubAcctDesc, xMainAcctCodePen, xMainAcctDescPen, xSubAcctCodePen, xSubAcctDescPen, NEW1, NEW2, NEW3, NEW4, NEW5, XDEPT, ORIGDUEFEEADJ, TRANSTYPE" & _
                              "  ) "
                ._pSelect1 = " SELECT " & _
                              "  Acctno, Foryear, Bus_Code, Desc1, Taxbase, Annualdue, Taxdue, PenDue, Totdue, Amt_Pd, Amt_PenPd, Discount, Taxcode, prevqtr, Qtryr1, Qtryr2, QtrPaid, Pres, Prev, Statcode, Newsw, ModeP, GradFix, Capital, Xsort, ORNo, " & _
                              "  DatePaid, BrgyCode, LocaCode, L_DatePD, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, Amt_Pd1, Amt_PenPd1, NewAmt_Pd, NewAmt_PenPd, NewTaxdue, NewPenDue, FieldName, PrevGMonth, GDateEsta," & _
                              "  GMonthPaid, DATE_ESTA, YearPeriod, NotEdit, NotDel, AssessTotal, UsedTCred, MainAcctCodePen, MainAcctDescPen, SubAcctCodePen, SubAcctDescPen, IsRegBill, ForClose, Area, xTotal, ADUE, xSQUENCELocal," & _
                              "  xSQUENCEPen, xSRS, xORNO, xSQUENCE, RES3, RES4, RES5, RES, RES1, RES2, QAMT, QDUE, PenYear, NotDelete, AAMT, I_DISCOUNT3, I_DISCOUNT4, I_DISCOUNT1, I_DISCOUNT2, I_YEAR2, I_YEAR3, I_YEAR4, I_YEAR1," & _
                              "  APPROVED, DATEAPP, TAXBALANCE, PENBALANCE, ForCompromise, ISPOSTED, EDITTEDBY, APPROVEDBY, EDITEDBY, EDPPrinted, Remarks0, Remarks1, RASSESBY, Remarks, xMainAcctCode, xMainAcctDesc," & _
                              "  xSubAcctCode, xSubAcctDesc, xMainAcctCodePen, xMainAcctDescPen, xSubAcctCodePen, xSubAcctDescPen, NEW1, NEW2, NEW3, NEW4, NEW5, XDEPT, ORIGDUEFEEADJ, TRANSTYPE  " & _
                             " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.BILLINGTEMP "
                ._pCondition = " WHERE  ACCTNO = ''" & cSessionLoader._pAccountNo & "'' " & _
                               " AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + _nErrMsg + "');", True)
                End If
            End With

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
            cEventLog._pSubLogError(ex)
        End Try
    End Function

    Private Function _InsertLivetoWeb_BUSLINE_PerUser() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT "
                ._pSelect = "INSERT INTO [BUSLINE] " & _
                                "(ACCTNO, FORYEAR, BUS_CODE, STATCODE, BRGYCODE, LOCACODE, DATE_ESTA, DATECLOSE, BQTRIND, GQTRIND, GROSSREC, CAPITAL, AREA, PREVTAX, BUSTAX, BT_PAID, BT_PENPD, GARBAGE, GF_PAID, GF_PENPD, " & _
                                " MAYORS, MF_PAID, MF_PENPD, SANITARY, SF_PAID, SF_PENPD, FIRE, FF_PAID, FF_PENPD, ORNO1, ORNO2, L_DATEPD, GROSSREC0, GROSSREC1, GROSSREC2, GROSSREC3, GROSSREC4, BUSTAX0, BUSTAX1, " & _
                                " BUSTAX2, BUSTAX3, BUSTAX4, BRANGE_QTY, BCHOICE0, BCHOICE1, BCHOICE2, BCHOICE3, BCHOICE4, BQTY, BQTY1, BQTY2, BQTY3, BQTY4, BQTY5, BQTY6, BQTY7, BQTY8, BQTY9, BQTY10, GRANGE_QTY, GCHOICE1, " & _
                                " GCHOICE2, GCHOICE3, GCHOICE4, GQTY, GQTY1, GQTY2, GQTY3, GQTY4, GQTY5, GQTY6, GQTY7, GQTY8, GQTY9, GQTY10, MRANGE_QTY, MCHOICE1, MCHOICE2, MCHOICE3, MCHOICE4, MQTY, MQTY1, MQTY2, MQTY3, " & _
                                " MQTY4, MQTY5, MQTY6, MQTY7, MQTY8, MQTY9, MQTY10, SRANGE_QTY, SCHOICE1, SCHOICE2, SCHOICE3, SCHOICE4, SQTY, SQTY1, SQTY2, SQTY3, SQTY4, SQTY5, SQTY6, SQTY7, SQTY8, SQTY9, SQTY10, " & _
                                " MAINBUSIND, NEWSW, FRANGE_QTY, FCHOICE1, FCHOICE2, FCHOICE3, FCHOICE4, FQTY, FQTY1, FQTY2, FQTY3, FQTY4, FQTY5, FQTY6, FQTY7, FQTY8, FQTY9, FQTY10, GARBAGE_O, Sanitary_O, FIRE_O, BT_CREDIT, " & _
                                " GF_CREDIT, SF_CREDIT, MF_CREDIT, FF_CREDIT, BTCREDAPPL, GFCREDAPPL, MFCREDAPPL, SFCREDAPPL, FFCREDAPPL, TXCREDCODE, PERMITNO, PERM_DATE, PUSER_ID, MODEPAY, MODEPAYG, GMONTHIND, " & _
                                " BCODE, SHRTAMT, BT_YEAR, MF_YEAR, GF_YEAR, SF_YEAR, FF_YEAR, BT_DISCOUNT, GF_DISCOUNT, MF_DISCOUNT, SF_DISCOUNT, FF_DISCOUNT, I_YEAR1, I_DISCOUNT1, I_YEAR2, I_DISCOUNT2, I_YEAR3, " & _
                                " I_DISCOUNT3, I_YEAR4, I_DISCOUNT4, BT_NEWDUE, BT_SHRT2ND, BT_SHRT3RD, BT_SHRT4TH, BT_SHRT2NDPD, BT_SHRT3RDPD, BT_SHRT4THPD, GF_NEWDUE, GF_SHRT2ND, GF_SHRT3RD, GF_SHRT4TH, " & _
                                " GF_SHRT2NDPD, GF_SHRT3RDPD, GF_SHRT4THPD, MF_NEWDUE, MF_SHRT, MF_SHRTPD, SF_NEWDUE, SF_SHRT, SF_SHRTPD, FF_NEWDUE, FF_SHRT, FF_SHRTPD, WITH_SHRTPAY, NewBusCode, IsChangeLine, " & _
                                " Lock_Compromise, HASNEWREV, ISLOCKED, RASSESBY, RASSESDATE, DATECOPIED, IsTaxExempt, GFSHORT, SFSHORT, FFSHORT, BUSTAXPEN0, BUSTAXPEN1, BUSTAXPEN2, BUSTAXPEN3, GF_PAID_1ST, " & _
                                " GF_PENPD_1ST, GF_PAID_2ND, GF_PENPD_2ND, GF_PAID_3RD, GF_PENPD_3RD, GF_PAID_4TH, GF_PENPD_4TH, ISCOMPLETED, BT_PAID_1ST, BT_PENPD_1ST, BT_PAID_2ND, BT_PENPD_2ND, BT_PAID_3RD, " & _
                                " BT_PENPD_3RD, BT_PAID_4TH, BT_PENPD_4TH, GROSSCLOSE, GROSSCLOSE_PAID, DOWNLOADED, UPLOADED, EXISTGSHORT, LGFQTR, Particulars) "
                ._pSelect1 = " SELECT " & _
                                " [ACCTNO] + ''_'' +  CONVERT(VARCHAR(8),GETDATE(), 112) , FORYEAR, BUS_CODE, STATCODE, BRGYCODE, LOCACODE, DATE_ESTA, DATECLOSE, BQTRIND, GQTRIND, GROSSREC, CAPITAL, AREA, PREVTAX, BUSTAX, BT_PAID, BT_PENPD, GARBAGE, GF_PAID, GF_PENPD, " & _
                                " MAYORS, MF_PAID, MF_PENPD, SANITARY, SF_PAID, SF_PENPD, FIRE, FF_PAID, FF_PENPD, ORNO1, ORNO2, L_DATEPD, GROSSREC0, GROSSREC1, GROSSREC2, GROSSREC3, GROSSREC4, BUSTAX0, BUSTAX1, " & _
                                " BUSTAX2, BUSTAX3, BUSTAX4, BRANGE_QTY, BCHOICE0, BCHOICE1, BCHOICE2, BCHOICE3, BCHOICE4, BQTY, BQTY1, BQTY2, BQTY3, BQTY4, BQTY5, BQTY6, BQTY7, BQTY8, BQTY9, BQTY10, GRANGE_QTY, GCHOICE1, " & _
                                " GCHOICE2, GCHOICE3, GCHOICE4, GQTY, GQTY1, GQTY2, GQTY3, GQTY4, GQTY5, GQTY6, GQTY7, GQTY8, GQTY9, GQTY10, MRANGE_QTY, MCHOICE1, MCHOICE2, MCHOICE3, MCHOICE4, MQTY, MQTY1, MQTY2, MQTY3, " & _
                                " MQTY4, MQTY5, MQTY6, MQTY7, MQTY8, MQTY9, MQTY10, SRANGE_QTY, SCHOICE1, SCHOICE2, SCHOICE3, SCHOICE4, SQTY, SQTY1, SQTY2, SQTY3, SQTY4, SQTY5, SQTY6, SQTY7, SQTY8, SQTY9, SQTY10, " & _
                                " MAINBUSIND, NEWSW, FRANGE_QTY, FCHOICE1, FCHOICE2, FCHOICE3, FCHOICE4, FQTY, FQTY1, FQTY2, FQTY3, FQTY4, FQTY5, FQTY6, FQTY7, FQTY8, FQTY9, FQTY10, GARBAGE_O, Sanitary_O, FIRE_O, BT_CREDIT, " & _
                                " GF_CREDIT, SF_CREDIT, MF_CREDIT, FF_CREDIT, BTCREDAPPL, GFCREDAPPL, MFCREDAPPL, SFCREDAPPL, FFCREDAPPL, TXCREDCODE, PERMITNO, PERM_DATE, PUSER_ID, MODEPAY, MODEPAYG, GMONTHIND, " & _
                                " BCODE, SHRTAMT, BT_YEAR, MF_YEAR, GF_YEAR, SF_YEAR, FF_YEAR, BT_DISCOUNT, GF_DISCOUNT, MF_DISCOUNT, SF_DISCOUNT, FF_DISCOUNT, I_YEAR1, I_DISCOUNT1, I_YEAR2, I_DISCOUNT2, I_YEAR3, " & _
                                " I_DISCOUNT3, I_YEAR4, I_DISCOUNT4, BT_NEWDUE, BT_SHRT2ND, BT_SHRT3RD, BT_SHRT4TH, BT_SHRT2NDPD, BT_SHRT3RDPD, BT_SHRT4THPD, GF_NEWDUE, GF_SHRT2ND, GF_SHRT3RD, GF_SHRT4TH, " & _
                                " GF_SHRT2NDPD, GF_SHRT3RDPD, GF_SHRT4THPD, MF_NEWDUE, MF_SHRT, MF_SHRTPD, SF_NEWDUE, SF_SHRT, SF_SHRTPD, FF_NEWDUE, FF_SHRT, FF_SHRTPD, WITH_SHRTPAY, NewBusCode, IsChangeLine, " & _
                                " Lock_Compromise, HASNEWREV, ISLOCKED, RASSESBY, RASSESDATE, DATECOPIED, IsTaxExempt, GFSHORT, SFSHORT, FFSHORT, BUSTAXPEN0, BUSTAXPEN1, BUSTAXPEN2, BUSTAXPEN3, GF_PAID_1ST, " & _
                                " GF_PENPD_1ST, GF_PAID_2ND, GF_PENPD_2ND, GF_PAID_3RD, GF_PENPD_3RD, GF_PAID_4TH, GF_PENPD_4TH, ISCOMPLETED, BT_PAID_1ST, BT_PENPD_1ST, BT_PAID_2ND, BT_PENPD_2ND, BT_PAID_3RD, " & _
                                " BT_PENPD_3RD, BT_PAID_4TH, BT_PENPD_4TH, GROSSCLOSE, GROSSCLOSE_PAID, DOWNLOADED, UPLOADED, EXISTGSHORT, LGFQTR, Particulars " & _
                                " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.BUSLINE "
                ._pCondition = " WHERE  ACCTNO = ''" & cSessionLoader._pAccountNo & "'' " & _
                               " AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Function

    Private Sub _InsertLivetoWeb_BUSEXTN()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT "
                ._pSelect = "INSERT INTO [BUSEXTN] " & _
                                 " (ACCTNO, FORYEAR, STATCODE, ZONE, ZONE_PD, ZONE_PENPD, RTC, RTC_PD, RTC_PENPD, PNP, PNP_PD, PNP_PENPD, FISCAL, FISC_PD, FISC_PENPD, BUILDING, BLDG_PD, BLDG_PENPD, MECHANICAL, MECH_PD, " & _
                                 " MECH_PENPD, ELECTRICAL, ELEC_PD, ELEC_PENPD, PLUMBING, PLUM_PD, PLUM_PENPD, SIGNBILL, SIGN_PD, SIGN_PENPD, OTHER, OTHE_PD, OTHE_PENPD, STICKER, STIC_PD, STIC_PENPD, MEDICAL, MEDI_PD, " & _
                                 " MEDI_PENPD, WMEASURES, WMEAS_PD, MEAS_PENPD, FIRECODE, FC_PD, FC_PENPD, ZONE_CREDIT, RTC_CREDIT, PNP_CREDIT, FISC_CREDIT, BLDG_CREDIT, MECH_CREDIT, ELEC_CREDIT, PLUM_CREDIT, " & _
                                 " SIGN_CREDIT, OTHE_CREDIT, STIC_CREDIT, MEDI_CREDIT, WMEA_CREDIT, FC_CREDIT, FCCREDAPPL, ZONECREDAPPL, RTCCREDAPPL, PNPCREDAPPL, FISCCREDAPPL, BLDGCREDAPPL, MECHCREDAPPL, " & _
                                 " ELECCREDAPPL, PLUMCREDAPPL, SIGNCREDAPPL, OTHECREDAPPL, STICCREDAPPL, MEDICREDAPPL, WMEACREDAPPL, PROCFEE, TXCREDCODE, PRF_PD, BILL_DATE, BUSER_ID, POST_TIME, OTHERDESC, RF1, " & _
                                 " RF1_PD, RF1_PENPD, RF1_CREDIT, RF1CREDAPPL, RF2, RF2_PD, RF2_PENPD, RF2_CREDIT, RF2CREDAPPL, RF3, RF3_PD, RF3_PENPD, RF3_CREDIT, RF3CREDAPPL, RF4, RF4_PD, RF4_PENPD, RF4_CREDIT, " & _
                                 " RF4CREDAPPL, RF5, RF5_PD, RF5_PENPD, RF5_CREDIT, RF5CREDAPPL, RF6, RF6_PD, RF6_PENPD, RF6_CREDIT, RF6CREDAPPL, RF9CREDAPPL, RF9_CREDIT, RF9_PD, RF9_PENPD, RF8_PENPD, RF8CREDAPPL, RF9, " & _
                                 " RF8, RF8_CREDIT, RF8_PD, RF7_PD, RF7_PENPD, RF7CREDAPPL, RF7, RF7_CREDIT, RF16CREDAPPL, RF16_CREDIT, RF16_PD, RF16_PENPD, RF15_PENPD, RF15CREDAPPL, RF16, RF15, RF15_CREDIT, RF15_PD, " & _
                                 " RF14_PD, RF14_PENPD, RF14CREDAPPL, RF13CREDAPPL, RF14, RF14_CREDIT, RF13_CREDIT, RF13_PD, RF13_PENPD, RF12_PENPD, RF12CREDAPPL, RF13, RF12, RF12_CREDIT, RF12_PD, RF11_PD, RF11_PENPD, " & _
                                 " RF11CREDAPPL, RF10CREDAPPL, RF11, RF11_CREDIT, RF10_CREDIT, RF10_PD, RF10_PENPD, RF10, Lock_Compromise, RASSESBY, RASSESDATE, DATECOPIED, IsTaxExempt, ZONE_DISCAPPL, RTC_DISCAPPL, " & _
                                 " PNP_DISCAPPL, FISC_DISCAPPL, BLDG_DISCAPPL, MECH_DISCAPPL, ELEC_DISCAPPL, PLUM_DISCAPPL, SIGN_DISCAPPL, OTHE_DISCAPPL, STIC_DISCAPPL, MEDI_DISCAPPL, WMEA_DISCAPPL, FC_DISCAPPL, " & _
                                 " PRF_DISCAPPL, RF1_DISCAPPL, RF2_DISCAPPL, RF3_DISCAPPL, RF4_DISCAPPL, RF5_DISCAPPL, RF6_DISCAPPL, RF7_DISCAPPL, RF8_DISCAPPL, RF9_DISCAPPL, RF10_DISCAPPL, RF11_DISCAPPL, RF12_DISCAPPL, " & _
                                 " RF13_DISCAPPL, RF14_DISCAPPL, RF15_DISCAPPL, RF16_DISCAPPL, DateShipment, ISCOMPLETED, RF10_CREDAPPL, ISLOCKED, DOWNLOADED, UPLOADED, tran_code, Particulars) "
                ._pSelect1 = " SELECT " & _
                                 " ACCTNO, FORYEAR, STATCODE, ZONE, ZONE_PD, ZONE_PENPD, RTC, RTC_PD, RTC_PENPD, PNP, PNP_PD, PNP_PENPD, FISCAL, FISC_PD, FISC_PENPD, BUILDING, BLDG_PD, BLDG_PENPD, MECHANICAL, MECH_PD, " & _
                                 " MECH_PENPD, ELECTRICAL, ELEC_PD, ELEC_PENPD, PLUMBING, PLUM_PD, PLUM_PENPD, SIGNBILL, SIGN_PD, SIGN_PENPD, OTHER, OTHE_PD, OTHE_PENPD, STICKER, STIC_PD, STIC_PENPD, MEDICAL, MEDI_PD, " & _
                                 " MEDI_PENPD, WMEASURES, WMEAS_PD, MEAS_PENPD, FIRECODE, FC_PD, FC_PENPD, ZONE_CREDIT, RTC_CREDIT, PNP_CREDIT, FISC_CREDIT, BLDG_CREDIT, MECH_CREDIT, ELEC_CREDIT, PLUM_CREDIT, " & _
                                 " SIGN_CREDIT, OTHE_CREDIT, STIC_CREDIT, MEDI_CREDIT, WMEA_CREDIT, FC_CREDIT, FCCREDAPPL, ZONECREDAPPL, RTCCREDAPPL, PNPCREDAPPL, FISCCREDAPPL, BLDGCREDAPPL, MECHCREDAPPL, " & _
                                 " ELECCREDAPPL, PLUMCREDAPPL, SIGNCREDAPPL, OTHECREDAPPL, STICCREDAPPL, MEDICREDAPPL, WMEACREDAPPL, PROCFEE, TXCREDCODE, PRF_PD, BILL_DATE, BUSER_ID, POST_TIME, OTHERDESC, RF1, " & _
                                 " RF1_PD, RF1_PENPD, RF1_CREDIT, RF1CREDAPPL, RF2, RF2_PD, RF2_PENPD, RF2_CREDIT, RF2CREDAPPL, RF3, RF3_PD, RF3_PENPD, RF3_CREDIT, RF3CREDAPPL, RF4, RF4_PD, RF4_PENPD, RF4_CREDIT, " & _
                                 " RF4CREDAPPL, RF5, RF5_PD, RF5_PENPD, RF5_CREDIT, RF5CREDAPPL, RF6, RF6_PD, RF6_PENPD, RF6_CREDIT, RF6CREDAPPL, RF9CREDAPPL, RF9_CREDIT, RF9_PD, RF9_PENPD, RF8_PENPD, RF8CREDAPPL, RF9, " & _
                                 " RF8, RF8_CREDIT, RF8_PD, RF7_PD, RF7_PENPD, RF7CREDAPPL, RF7, RF7_CREDIT, RF16CREDAPPL, RF16_CREDIT, RF16_PD, RF16_PENPD, RF15_PENPD, RF15CREDAPPL, RF16, RF15, RF15_CREDIT, RF15_PD, " & _
                                 " RF14_PD, RF14_PENPD, RF14CREDAPPL, RF13CREDAPPL, RF14, RF14_CREDIT, RF13_CREDIT, RF13_PD, RF13_PENPD, RF12_PENPD, RF12CREDAPPL, RF13, RF12, RF12_CREDIT, RF12_PD, RF11_PD, RF11_PENPD, " & _
                                 " RF11CREDAPPL, RF10CREDAPPL, RF11, RF11_CREDIT, RF10_CREDIT, RF10_PD, RF10_PENPD, RF10, Lock_Compromise, RASSESBY, RASSESDATE, DATECOPIED, IsTaxExempt, ZONE_DISCAPPL, RTC_DISCAPPL, " & _
                                 " PNP_DISCAPPL, FISC_DISCAPPL, BLDG_DISCAPPL, MECH_DISCAPPL, ELEC_DISCAPPL, PLUM_DISCAPPL, SIGN_DISCAPPL, OTHE_DISCAPPL, STIC_DISCAPPL, MEDI_DISCAPPL, WMEA_DISCAPPL, FC_DISCAPPL, " & _
                                 " PRF_DISCAPPL, RF1_DISCAPPL, RF2_DISCAPPL, RF3_DISCAPPL, RF4_DISCAPPL, RF5_DISCAPPL, RF6_DISCAPPL, RF7_DISCAPPL, RF8_DISCAPPL, RF9_DISCAPPL, RF10_DISCAPPL, RF11_DISCAPPL, RF12_DISCAPPL, " & _
                                 " RF13_DISCAPPL, RF14_DISCAPPL, RF15_DISCAPPL, RF16_DISCAPPL, DateShipment, ISCOMPLETED, RF10_CREDAPPL, ISLOCKED, DOWNLOADED, UPLOADED, tran_code, Particulars " & _
                                " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.BUSEXTN "
                ._pCondition = " WHERE  ACCTNO = ''" & cSessionLoader._pAccountNo & "'' " & _
                               " AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _InsertLivetoWeb_BUSEXTN_PerUser()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT "
                ._pSelect = "INSERT INTO [BUSEXTN] " & _
                                 " (ACCTNO, FORYEAR, STATCODE, ZONE, ZONE_PD, ZONE_PENPD, RTC, RTC_PD, RTC_PENPD, PNP, PNP_PD, PNP_PENPD, FISCAL, FISC_PD, FISC_PENPD, BUILDING, BLDG_PD, BLDG_PENPD, MECHANICAL, MECH_PD, " & _
                                 " MECH_PENPD, ELECTRICAL, ELEC_PD, ELEC_PENPD, PLUMBING, PLUM_PD, PLUM_PENPD, SIGNBILL, SIGN_PD, SIGN_PENPD, OTHER, OTHE_PD, OTHE_PENPD, STICKER, STIC_PD, STIC_PENPD, MEDICAL, MEDI_PD, " & _
                                 " MEDI_PENPD, WMEASURES, WMEAS_PD, MEAS_PENPD, FIRECODE, FC_PD, FC_PENPD, ZONE_CREDIT, RTC_CREDIT, PNP_CREDIT, FISC_CREDIT, BLDG_CREDIT, MECH_CREDIT, ELEC_CREDIT, PLUM_CREDIT, " & _
                                 " SIGN_CREDIT, OTHE_CREDIT, STIC_CREDIT, MEDI_CREDIT, WMEA_CREDIT, FC_CREDIT, FCCREDAPPL, ZONECREDAPPL, RTCCREDAPPL, PNPCREDAPPL, FISCCREDAPPL, BLDGCREDAPPL, MECHCREDAPPL, " & _
                                 " ELECCREDAPPL, PLUMCREDAPPL, SIGNCREDAPPL, OTHECREDAPPL, STICCREDAPPL, MEDICREDAPPL, WMEACREDAPPL, PROCFEE, TXCREDCODE, PRF_PD, BILL_DATE, BUSER_ID, POST_TIME, OTHERDESC, RF1, " & _
                                 " RF1_PD, RF1_PENPD, RF1_CREDIT, RF1CREDAPPL, RF2, RF2_PD, RF2_PENPD, RF2_CREDIT, RF2CREDAPPL, RF3, RF3_PD, RF3_PENPD, RF3_CREDIT, RF3CREDAPPL, RF4, RF4_PD, RF4_PENPD, RF4_CREDIT, " & _
                                 " RF4CREDAPPL, RF5, RF5_PD, RF5_PENPD, RF5_CREDIT, RF5CREDAPPL, RF6, RF6_PD, RF6_PENPD, RF6_CREDIT, RF6CREDAPPL, RF9CREDAPPL, RF9_CREDIT, RF9_PD, RF9_PENPD, RF8_PENPD, RF8CREDAPPL, RF9, " & _
                                 " RF8, RF8_CREDIT, RF8_PD, RF7_PD, RF7_PENPD, RF7CREDAPPL, RF7, RF7_CREDIT, RF16CREDAPPL, RF16_CREDIT, RF16_PD, RF16_PENPD, RF15_PENPD, RF15CREDAPPL, RF16, RF15, RF15_CREDIT, RF15_PD, " & _
                                 " RF14_PD, RF14_PENPD, RF14CREDAPPL, RF13CREDAPPL, RF14, RF14_CREDIT, RF13_CREDIT, RF13_PD, RF13_PENPD, RF12_PENPD, RF12CREDAPPL, RF13, RF12, RF12_CREDIT, RF12_PD, RF11_PD, RF11_PENPD, " & _
                                 " RF11CREDAPPL, RF10CREDAPPL, RF11, RF11_CREDIT, RF10_CREDIT, RF10_PD, RF10_PENPD, RF10, Lock_Compromise, RASSESBY, RASSESDATE, DATECOPIED, IsTaxExempt, ZONE_DISCAPPL, RTC_DISCAPPL, " & _
                                 " PNP_DISCAPPL, FISC_DISCAPPL, BLDG_DISCAPPL, MECH_DISCAPPL, ELEC_DISCAPPL, PLUM_DISCAPPL, SIGN_DISCAPPL, OTHE_DISCAPPL, STIC_DISCAPPL, MEDI_DISCAPPL, WMEA_DISCAPPL, FC_DISCAPPL, " & _
                                 " PRF_DISCAPPL, RF1_DISCAPPL, RF2_DISCAPPL, RF3_DISCAPPL, RF4_DISCAPPL, RF5_DISCAPPL, RF6_DISCAPPL, RF7_DISCAPPL, RF8_DISCAPPL, RF9_DISCAPPL, RF10_DISCAPPL, RF11_DISCAPPL, RF12_DISCAPPL, " & _
                                 " RF13_DISCAPPL, RF14_DISCAPPL, RF15_DISCAPPL, RF16_DISCAPPL, DateShipment, ISCOMPLETED, RF10_CREDAPPL, ISLOCKED, DOWNLOADED, UPLOADED, tran_code, Particulars) "
                ._pSelect1 = " SELECT " & _
                                 "  [ACCTNO] + ''_'' + CONVERT(VARCHAR(8),GETDATE(), 112) , FORYEAR, STATCODE, ZONE, ZONE_PD, ZONE_PENPD, RTC, RTC_PD, RTC_PENPD, PNP, PNP_PD, PNP_PENPD, FISCAL, FISC_PD, FISC_PENPD, BUILDING, BLDG_PD, BLDG_PENPD, MECHANICAL, MECH_PD, " & _
                                 " MECH_PENPD, ELECTRICAL, ELEC_PD, ELEC_PENPD, PLUMBING, PLUM_PD, PLUM_PENPD, SIGNBILL, SIGN_PD, SIGN_PENPD, OTHER, OTHE_PD, OTHE_PENPD, STICKER, STIC_PD, STIC_PENPD, MEDICAL, MEDI_PD, " & _
                                 " MEDI_PENPD, WMEASURES, WMEAS_PD, MEAS_PENPD, FIRECODE, FC_PD, FC_PENPD, ZONE_CREDIT, RTC_CREDIT, PNP_CREDIT, FISC_CREDIT, BLDG_CREDIT, MECH_CREDIT, ELEC_CREDIT, PLUM_CREDIT, " & _
                                 " SIGN_CREDIT, OTHE_CREDIT, STIC_CREDIT, MEDI_CREDIT, WMEA_CREDIT, FC_CREDIT, FCCREDAPPL, ZONECREDAPPL, RTCCREDAPPL, PNPCREDAPPL, FISCCREDAPPL, BLDGCREDAPPL, MECHCREDAPPL, " & _
                                 " ELECCREDAPPL, PLUMCREDAPPL, SIGNCREDAPPL, OTHECREDAPPL, STICCREDAPPL, MEDICREDAPPL, WMEACREDAPPL, PROCFEE, TXCREDCODE, PRF_PD, BILL_DATE, BUSER_ID, POST_TIME, OTHERDESC, RF1, " & _
                                 " RF1_PD, RF1_PENPD, RF1_CREDIT, RF1CREDAPPL, RF2, RF2_PD, RF2_PENPD, RF2_CREDIT, RF2CREDAPPL, RF3, RF3_PD, RF3_PENPD, RF3_CREDIT, RF3CREDAPPL, RF4, RF4_PD, RF4_PENPD, RF4_CREDIT, " & _
                                 " RF4CREDAPPL, RF5, RF5_PD, RF5_PENPD, RF5_CREDIT, RF5CREDAPPL, RF6, RF6_PD, RF6_PENPD, RF6_CREDIT, RF6CREDAPPL, RF9CREDAPPL, RF9_CREDIT, RF9_PD, RF9_PENPD, RF8_PENPD, RF8CREDAPPL, RF9, " & _
                                 " RF8, RF8_CREDIT, RF8_PD, RF7_PD, RF7_PENPD, RF7CREDAPPL, RF7, RF7_CREDIT, RF16CREDAPPL, RF16_CREDIT, RF16_PD, RF16_PENPD, RF15_PENPD, RF15CREDAPPL, RF16, RF15, RF15_CREDIT, RF15_PD, " & _
                                 " RF14_PD, RF14_PENPD, RF14CREDAPPL, RF13CREDAPPL, RF14, RF14_CREDIT, RF13_CREDIT, RF13_PD, RF13_PENPD, RF12_PENPD, RF12CREDAPPL, RF13, RF12, RF12_CREDIT, RF12_PD, RF11_PD, RF11_PENPD, " & _
                                 " RF11CREDAPPL, RF10CREDAPPL, RF11, RF11_CREDIT, RF10_CREDIT, RF10_PD, RF10_PENPD, RF10, Lock_Compromise, RASSESBY, RASSESDATE, DATECOPIED, IsTaxExempt, ZONE_DISCAPPL, RTC_DISCAPPL, " & _
                                 " PNP_DISCAPPL, FISC_DISCAPPL, BLDG_DISCAPPL, MECH_DISCAPPL, ELEC_DISCAPPL, PLUM_DISCAPPL, SIGN_DISCAPPL, OTHE_DISCAPPL, STIC_DISCAPPL, MEDI_DISCAPPL, WMEA_DISCAPPL, FC_DISCAPPL, " & _
                                 " PRF_DISCAPPL, RF1_DISCAPPL, RF2_DISCAPPL, RF3_DISCAPPL, RF4_DISCAPPL, RF5_DISCAPPL, RF6_DISCAPPL, RF7_DISCAPPL, RF8_DISCAPPL, RF9_DISCAPPL, RF10_DISCAPPL, RF11_DISCAPPL, RF12_DISCAPPL, " & _
                                 " RF13_DISCAPPL, RF14_DISCAPPL, RF15_DISCAPPL, RF16_DISCAPPL, DateShipment, ISCOMPLETED, RF10_CREDAPPL, ISLOCKED, DOWNLOADED, UPLOADED, tran_code, Particulars " & _
                                " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.BUSEXTN "
                ._pCondition = " WHERE  ACCTNO = ''" & cSessionLoader._pAccountNo & "'' " & _
                               " AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Function _FnIsBusMastExist() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT ACCTNO FROM BUSMAST "
                ._pCondition = "WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "''  "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Function


    Private Sub _mSubCheckIsOnHold()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pAcctNo = _otxtEnterBusinessBIN.Value
            _nClass._pORNo = _otxtEnterBusinessORNo.Value
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            '_nClass._pForYear = Year(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pEmail2 = cSessionUser._pUserID
            '----------------------------------

            _nClass._pSubCheckIsOnHold()

            myOutPut = _nClass._nOutput

            If myOutPut = 1 Then
                Dim _nClass2 As New cHardwareInformation
                Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
                Select Case _nMachineName
                    Case "GRACEVILLE"
                        'CSJDM
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have deficiencies " & _
                                                       "to comply with. Kindly contact us through the following numbers or send us a message and we will gladly assist you regarding your concern." & _
                                                       "\n\n    (044) 3073139 " & _
                                                       "\n    (0953)-1730164   " & _
                                                       "\n    (0912)-5996151)');", True)

                    Case "WEBSVRCALOOCAN"
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have delinquency " & _
                                                     "to comply with. Kindly contact us or send us a message and we will gladly assist you regarding your concern." & _
                                                     "\n\n    5336-5692 (DirectLine) " & _
                                                       "\n    8288-8811 loc. 2217/2248 (Trunk Line)   " & _
                                                       "\n    8961-1860 (Direct Line - BPLO North)');", True)


                    Case Else
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have delinquency " & _
                                                     "to comply with. Kindly contact us or send us a message and we will gladly assist you regarding your concern." & _
                                                     ")');", True)


                End Select

                nIsOnHold = True

            Else
                nIsOnHold = False


            End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub
    Private Sub _mSubCheckIsClosed()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pAcctNo = _otxtEnterBusinessBIN.Value
            _nClass._pORNo = _otxtEnterBusinessORNo.Value
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            '_nClass._pForYear = Year(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pEmail2 = cSessionUser._pUserID
            '----------------------------------

            _nClass._pSubCheckIsClosed()

            myOutPut = _nClass._nOutput

            If myOutPut = 1 Then
                Dim _nClass2 As New cHardwareInformation
                Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
                Select Case _nMachineName
                    Case "GRACEVILLE"
                        'CSJDM
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment. It seems that your account " & _
                                                       "is inactive. Kindly contact us through the following numbers or send us a message and we will gladly assist you regarding your concern." & _
                                                       "\n\n    (044) 3073139 " & _
                                                       "\n    (0953)-1730164   " & _
                                                       "\n    (0912)-5996151)');", True)

                    Case Else
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.It seems that your account " & _
                                                     "is closed. Kindly contact us or send us a message and we will gladly assist you regarding your concern." & _
                                                     ")');", True)


                End Select

                nIsClosed = True

            Else
                nIsClosed = False


            End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub


    Private Sub _mSubCheckIsDelinquent()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pAcctNo = _otxtEnterBusinessBIN.Value
            _nClass._pORNo = _otxtEnterBusinessORNo.Value
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            '_nClass._pForYear = Year(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pEmail2 = cSessionUser._pUserID
            '----------------------------------

            _nClass._pSubCheckIsDelinquent()

            myOutPut = _nClass._nOutput

            If myOutPut = 1 Then
                Dim _nClass2 As New cHardwareInformation
                Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
                Select Case _nMachineName
                    Case "GRACEVILLE"
                        'CSJDM

                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have deficiencies " & _
                                                       "to comply with. Kindly contact us through the following numbers or send us a message and we will gladly assist you regarding your concern.   \n\n    (044) 3073139    \n    (0953)-1730164    \n    (0912)-5996151)');", True)

                    Case "WEBSVRCALOOCAN"
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have delinquency " & _
                                                       "to comply with. Kindly contact us through the following numbers or send us a message and we will gladly assist you regarding your concern.)" & _
                                                       "\n\n    5336-5692 (DirectLine) " & _
                                                       "\n    8288-8811 loc. 2217/2248 (Trunk Line)   " & _
                                                       "\n    8961-1860 (Direct Line - BPLO North)');", True)

                    Case Else
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have delinquency " & _
                                                       "to comply with. Kindly contact us through the following numbers or send us a message and we will gladly assist you regarding your concern.)');", True)

                End Select

                nIsDelinquent = True

            Else
                nIsDelinquent = False


            End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub
    Private Sub _mSubCheckIsDelinquent2()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pAcctNo = Request("__EVENTARGUMENT")
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            '_nClass._pForYear = Year(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pEmail2 = cSessionUser._pUserID
            '----------------------------------

            _nClass._pSubCheckIsDelinquent()

            myOutPut = _nClass._nOutput

            If myOutPut = 1 Then
                Dim _nClass2 As New cHardwareInformation
                Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
                Select Case _nMachineName
                    Case "GRACEVILLE"
                        'CSJDM

                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have deficiencies " & _
                                                       "to comply with. Kindly contact us through the following numbers or send us a message and we will gladly assist you regarding your concern.   \n\n    (044) 3073139    \n    (0953)-1730164    \n    (0912)-5996151)');", True)

                    Case "WEBSVRCALOOCAN"
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have delinquency " & _
                                                       "to comply with. Kindly contact us through the following numbers or send us a message and we will gladly assist you regarding your concern.)" & _
                                                       "\n\n    5336-5692 (DirectLine) " & _
                                                       "\n    8288-8811 loc. 2217/2248 (Trunk Line)   " & _
                                                       "\n    8961-1860 (Direct Line - BPLO North)');", True)


                    Case Else
                        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('     Sorry, we will not be able to process your online renewal application as of the moment.You still have delinquency " & _
                                                       "to comply with. Kindly contact us through the following numbers or send us a message and we will gladly assist you regarding your concern.)');", True)

                End Select

                nIsDelinquent = True

            Else
                nIsDelinquent = False


            End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Sub Get_Transactions()
        Try
            '----------------------------------

            Dim _nClass2 As New cHardwareInformation
            Dim _nMachineName As String = Nothing
            _nMachineName = _nClass2._pMachineName.ToUpper

            Select Case _nMachineName
                Case "WEBSVRCALOOCAN"
                    OTC_NOTE.InnerText = "Please proceed to Ground flr, Caloocan City Hall, Treasury office and present your TRANSACTION REFNO to settle your payment. Please print three(3) copies of Statement of Account(SOA) if you wish to pay over the counter at the City Hall"

                Case "GRACEVILLE"
                    OTC_NOTE.InnerText = "Note: Please proceed to Basement 2, SM City San Jose, B.O.S.S office and present your TRANSACTION REFNO to settle your payment."

                Case "MANDAUEWEBSVR"
                    OTC_NOTE.InnerText = "  NOTE: Please proceed to Mandaue City Hall, Treasury Office and present your SOA to settle your payment. Please print three(3) copies of Statement of Account(SOA) if you wish to pay over the counter at the City Hall"

                Case Else
                    OTC_NOTE.InnerText = "  NOTE: Please proceed to Municipality/City Hall, Treasury Office and present your TRANSACTION REFNO to settle your payment."

            End Select

            Dim _nGridView As New GridView
            _nGridView = _oGVTransaction
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubSelectTransactions()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()

                Else
                    ' snackbar("red", "No Records Found.")
                End If
                '----------------------------------
            Catch ex As Exception
                snackbar("red", "Transaction : " & ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try

    End Sub

 
    Sub Get_TransactionHistory()
        Try
            '----------------------------------
            Dim _nClass2 As New cHardwareInformation
            Dim _nMachineName As String = Nothing
            _nMachineName = _nClass2._pMachineName.ToUpper
            Select Case _nMachineName
                Case "WEBSVRCALOOCAN"
                    OTC_NOTE.InnerText = "Please proceed to Ground flr, Caloocan City Hall, Treasury office and present your TRANSACTION REFNO to settle your payment. Please print three(3) copies of Statement of Account(SOA) if you wish to pay over the counter at the City Hall"

                Case "GRACEVILLE"
                    OTC_NOTE.InnerText = "Note: Please proceed to Basement 2, SM City San Jose, B.O.S.S office and present your TRANSACTION REFNO to settle your payment."

                Case "MANDAUEWEBSVR"
                    OTC_NOTE.InnerText = "  NOTE: Please proceed to Mandaue City Hall, Treasury Office and present your SOA to settle your payment. Please print three(3) copies of Statement of Account(SOA) if you wish to pay over the counter at the City Hall"

                Case Else
                    OTC_NOTE.InnerText = "  NOTE: Please proceed to Municipality/City Hall, Treasury Office and present your TRANSACTION REFNO to settle your payment."

            End Select

            Dim _nGridView As New GridView
            _nGridView = _oGVTransaction
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalTransactionHistory
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubSelectHistory(cSessionUser._pUserID)

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()
                End If
                '----------------------------------
            Catch ex As Exception
                snackbar("red", "History : " & ex.Message)
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try

    End Sub
    Private Function checkpending() As Boolean
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = GridView2
            _nGridView.DataSourceID = Nothing


            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "RPTIMS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            Dim _nClass As New cDalSOSRPTAS
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog



            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pTDN = cSessionLoader._pTDN
            _nClass._pSubSelectPending()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable
            Try
                '----------------------------------
                'If _nDataTable.HasErrors Then

                'End If

                If _nDataTable.Rows.Count > 0 Then
                    snackbar("red", "TDN has Pending Transaction")
                    checkpending = True
                Else
                    checkpending = False

                End If
                '----------------------------------
            Catch ex As Exception
                snackbar("red", ex.Message)

            End Try
            '----------------------------------
        Catch ex As Exception



        End Try
    End Function



    Private Sub Get_RPTAccounts()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = GridView2
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalSOSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubSelect()
            cSessionUser._pStrDt = _nClass._pstrdt
            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()
                    _oGVSelectProperty.DataSource = _nDataTable
                    _oGVSelectProperty.DataBind()
                Else
                    ' snackbar("red", "No Records Found.")
                End If
                '----------------------------------
            Catch ex As Exception
                snackbar("red", ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try
    End Sub
    'Private Sub btnEnrollProp_ServerClick(sender As Object, e As EventArgs) Handles btnEnrollProp.ServerClick
    '    _mSubValidateEnrollment()
    '    Get_RPTAccounts()
    '    _otxtEnterPropORNo.Value = ""
    '    _otxtEnterPropTDN.Value = ""
    'End Sub
    Private Sub _mSubCheckifHasPayment()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            '_nClass._pForYear = Year(Now)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

            '----------------------------------

            _nClass._pSubCheckBusline()

            myOutPut = _nClass._nOutput
            _nClass._pSubCheckGarbage()


            If myOutPut = 0 Then
                nFullyPaid = False
            ElseIf myOutPut = 4 Then
                'MsgBox("Account already enrolled!")
                '  snackbar("red", "Account already paid!")
                nFullyPaid = True
            ElseIf myOutPut <> 4 And myOutPut <> 5 Then
                nHasPayment = True
                nLQP = myOutPut
            End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub
    Private Sub _mSubCheckifHasSubmit()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            ' _nClass._pForYear = Year(Now)
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            '----------------------------------

            _nClass._pSubCheckSubmit()

            myOutPut = _nClass._nOutput



            If myOutPut = 0 Then
                'MsgBox("Account already enrolled!")               
                nHasSubmit = False
            ElseIf myOutPut = 1 Then
                nHasSubmit = True
            End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub
    Public Sub _pNotifyTaxPayer(swtch As String)
        Try
            Dim Sent As Boolean
            Dim Subject As String = ""
            Dim Body As String = ""

            Select Case swtch
                Case "Business"
                    Subject = "Business Enrollment Application"
                    Body = "To our Valued Taxpayer, <br>" & _
                        "Your online enrollment application for Busines Account No.: " & _otxtEnterBusinessBIN.Value & " is now under BPLO verification. Once verified and approved, our office will send an email notification regarding the status of your application." & _
                        "<br><br>" & _
                        "We strongly suggest to regularly check your email for more updates." & _
                        "<br><br>"

                Case "Property"
                    Subject = "Real Property Enrollment Application"
                    Body = "To our Valued Taxpayer, <br>" & _
                         "Your online enrollment application for Property TDN.: " & _otxtEnterPropTDN.Value & " is now under ASSESSOR verification. Once verified and approved, our office will send an email notification regarding the status of your application." & _
                        "<br><br>" & _
                        "We strongly suggest to regularly check your email for more updates." & _
                        "<br><br>"

            End Select
            cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)

        Catch ex As Exception

        End Try



    End Sub
    Private Sub _obtnProceed_ServerClick(sender As Object, e As EventArgs) Handles _obtnProceed.ServerClick
        'snackbar("red", "Multiple TDN is DISABLED")
        'Exit Sub
        Dim multitdn As String
        Dim svr As String
        Dim dtb As String
        If ifchckall.Value = "1" Then
            multitdn = cSessionUser._pStrDt
        ElseIf ifchckall.Value = "2" Then
            multitdn = ""
        ElseIf ifchckall.Value = "3" Then
            multitdn = cSessionUser._pStrDt & Request.Form("txarea")
        ElseIf ifchckall.Value = "4" Then
            multitdn = Request.Form("txarea")
        End If


        If Trim(multitdn) = "" Then
            snackbar("red", "Please Select Tdn!")
            Exit Sub
        End If


        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = "RPTAS_T"
        _nClBP._pSubRecordSelectSpecific()

        '----------------------------------
        'Specify Blank to Select Nothing but Column Names

        svr = _nClBP._pDBDataSource
        dtb = _nClBP._pDBInitialCatalog


        Dim _nClass As New cDalSOSRPTAS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
        'Get Gross Amount

        _nClass._pTDN = multitdn
        _nClass._pEmail = "tempmultitdn_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pSubGetGross()


        cSessionLoader._pTDN = "select tdn from [" & svr & "].[" & dtb & "].[dbo].tempmultitdn_" & cSessionUser._pUserID.Replace(".", "")

        If checkpending() = True Then Exit Sub

        Response.Redirect("RPTBilling.aspx")
    End Sub
    Public Sub LoaddataBPN()
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectNewBP()
            GridView3.DataSource = _nClass._mDataTable
            GridView3.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoaddataBP()
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        '_nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
        '_nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
        '_nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
        '_nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

        'Dim _nClBP As New cDalGlobalConnectionsDefault
        '_nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        '_nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
        '_nClBP._pSubRecordSelectSpecific()

        '_nClass._pLocServer = _nClBP._pDBDataSource
        '_nClass._pLocDB = _nClBP._pDBInitialCatalog

        _nClass._pSubSelectEnroll()
        GridView1.DataSource = cDalBPSOS._mDataTable
        GridView1.DataBind()

        'remove temp
        'If cSessionUser._pUserID <> "" Then
        '    _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
        '    _nClass._pSubRemoveTemp()
        '    Dim _nClass1 As New cDalBPSOS
        '    _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        '    _nClass1._pEmail = cSessionUser._pUserID
        '    _nClass1._pSubRemoveTemp()
        'End If
    End Sub

    Public Sub LoaddataBP_withRemainingQtr()
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelect_wRemainingQtr()
        GridView4.DataSource = cDalBPSOS._mDataTable
        GridView4.DataBind()

    End Sub

    Public Sub LoaddataBPP()
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectForPayment(hdn_ERR.Value)
        _oGVBusinessPayment.DataSource = _nClass._mDataTable
        _oGVBusinessPayment.DataBind()

        'remove temp
        'If cSessionUser._pUserID <> "" Then
        '    _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
        '    _nClass._pSubRemoveTemp()
        '    Dim _nClass1 As New cDalBPSOS
        '    _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        '    _nClass1._pEmail = cSessionUser._pUserID
        '    _nClass1._pSubRemoveTemp()
        'End If
    End Sub

    Public Sub LoaddataNEW_BPP()
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectForPayment(hdn_ERR.Value)
        _oGVBusinessPayment.DataSource = _nClass._mDataTable
        _oGVBusinessPayment.DataBind()

        'remove temp
        'If cSessionUser._pUserID <> "" Then
        '    _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
        '    _nClass._pSubRemoveTemp()
        '    Dim _nClass1 As New cDalBPSOS
        '    _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        '    _nClass1._pEmail = cSessionUser._pUserID
        '    _nClass1._pSubRemoveTemp()
        'End If
    End Sub

    Public Sub LoaddataBPI()
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelectNewBP_Issuance_TAXPAYER()
            _oGVBusinessIssuance.DataSource = _nClass._mDataTable
            _oGVBusinessIssuance.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Public Sub LoaddataBP_TempPermit()
        Try
            Dim _nClass As New cDalBPSOS

            _nClass._pSubSelectForTemporaryPermit()
            _oGVBusinessTempPermit.DataSource = _nClass._mDataTable
            _oGVBusinessTempPermit.DataBind()
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub datagrid_PageIndexChanging_BPN(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBPN()
            GridView3.PageIndex = e.NewPageIndex
            GridView3.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_BP_RemainingQtr(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBP_withRemainingQtr()
            GridView4.PageIndex = e.NewPageIndex
            GridView4.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_BP(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBP()
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_BPP(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBPP()
            _oGVBusinessPayment.PageIndex = e.NewPageIndex
            _oGVBusinessPayment.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_BPI(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBPI()
            _oGVBusinessIssuance.PageIndex = e.NewPageIndex
            _oGVBusinessIssuance.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_BP_TempPermit(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBP_TempPermit()
            _oGVBusinessTempPermit.PageIndex = e.NewPageIndex
            _oGVBusinessTempPermit.DataBind()
        Catch ex As Exception
        End Try
    End Sub



    Protected Sub datagrid_PageIndexChanging_RPTAcc(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            Get_RPTAccounts()
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_RPTTran(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            '   Get_Transactions()
            Get_TransactionHistory()
            _oGVTransaction.PageIndex = e.NewPageIndex
            _oGVTransaction.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelNBP_ServerClick(sender As Object, e As EventArgs) Handles btnCancelNBP.ServerClick
        Dim AppID As String = hdnAppID.Value
        Dim Err As String
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubCancelNBP(AppID, Err)
            If Err = Nothing Then
                snackbar("green", "Application has been removed.")
            Else
                snackbar("red", Err)
            End If
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception

        End Try
    End Sub

    Sub Get_Modules()

        Dim _nclass As New cDalGetModules
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

        If _nclass._pSubGetAvailableModules("RPT_Enrollment") = False Or Session("SingleModule") = "BP" Then
            SetModules("RPT_Enrollment")
        Else
            Get_RPTAccounts()
        End If

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        If _nclass._pSubGetAvailableModules("BP_Enrollment") = False Or Session("SingleModule") = "RPT" Then
            SetModules("BP_Enrollment")
        Else
            LoaddataBP()
            LoaddataBP_withRemainingQtr()
            LoaddataBPN()
            LoaddataBPP()
            LoaddataBPI()
            LoaddataBP_TempPermit()
            'usertmp = cSessionUser._pUserID.Replace(".", "")
            'Dim _nClass2 As New cDalBPSOS
            '_nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            '_nClass2._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            '_nClass2._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            '_nClass2._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            '_nClass2._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

            'Dim _nClBP As New cDalGlobalConnectionsDefault
            '_nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            '_nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            '_nClBP._pSubRecordSelectSpecific()

            '_nClass2._pLocServer = _nClBP._pDBDataSource
            '_nClass2._pLocDB = _nClBP._pDBInitialCatalog

            '_nClass2._pSubSelectEnroll()
            '  hdn_ERR.Value += " _pSubSelectEnroll : " & cDalBPSOS._Query & " --- "

            ' GridView1.AutoGenerateColumns = True
            'GridView1.DataSource = cDalBPSOS._mDataTable
            'GridView1.DataBind()

            ' _nClass2._pSubSelectForPayment()
            ' '  hdn_ERR.Value += " _pSubSelectForPayment : " & cDalBPSOS._Query & " --- "
            '
            ' _oGVBusinessPayment.DataSource = _nClass2._mDataTable
            ' _oGVBusinessPayment.DataBind()



            If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                Response.Redirect("Register.aspx")
            End If


            'If cSessionUser._pUserID <> "" Then
            '    _nClass2._pEmail = cSessionUser._pUserID.Replace(".", "")
            '    _nClass2._pSubRemoveTemp()
            '    Dim _nClass1 As New cDalBPSOS
            '    _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            '    _nClass1._pEmail = cSessionUser._pUserID
            '    _nClass1._pSubRemoveTemp()
            'End If

        End If





    End Sub
    Sub SetModules(ByVal SubModule As String)
        Select Case SubModule
            Case "BP_Enrollment"
                div_BP_enroll.Attributes.CssStyle.Add("pointer-events", "none")
                div_BP_enroll.Attributes.CssStyle.Add("display", "none")
                div_BP_enroll.Attributes.CssStyle.Add("opacity", "0.4")

                div_BP_NEW.Attributes.CssStyle.Add("pointer-events", "none")
                div_BP_NEW.Attributes.CssStyle.Add("display", "none")
                div_BP_NEW.Attributes.CssStyle.Add("opacity", "0.4")

                div_BP_Issuance.Attributes.CssStyle.Add("pointer-events", "none")
                div_BP_Issuance.Attributes.CssStyle.Add("display", "none")
                div_BP_Issuance.Attributes.CssStyle.Add("opacity", "0.4")

                div_BP_NEW.Attributes.CssStyle.Add("pointer-events", "none")
                div_BP_NEW.Attributes.CssStyle.Add("display", "none")
                div_BP_NEW.Attributes.CssStyle.Add("opacity", "0.4")

                div_BP_Payment.Attributes.CssStyle.Add("pointer-events", "none")
                div_BP_Payment.Attributes.CssStyle.Add("display", "none")
                div_BP_Payment.Attributes.CssStyle.Add("opacity", "0.4")

                div_BP_Renewal.Attributes.CssStyle.Add("pointer-events", "none")
                div_BP_Renewal.Attributes.CssStyle.Add("display", "none")
                div_BP_Renewal.Attributes.CssStyle.Add("opacity", "0.4")




            Case "RPT_Enrollment"
                div_RPT_enroll.Attributes.CssStyle.Add("pointer-events", "none")
                div_RPT_enroll.Attributes.CssStyle.Add("display", "none")
                div_RPT_enroll.Attributes.CssStyle.Add("opacity", "0.4")

                div_RPT.Attributes.CssStyle.Add("pointer-events", "none")
                div_RPT.Attributes.CssStyle.Add("display", "none")
                div_RPT.Attributes.CssStyle.Add("opacity", "0.4")

        End Select
    End Sub

    Private Sub btnConsentYes_ServerClick(sender As Object, e As EventArgs) Handles btnConsentYes.ServerClick
        Try
            Dim nclass As New cDalPayment
            Dim err As String = Nothing
            nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            nclass._pSubVoidPreviousTransaction(cDalPayment._WebAssessNo, cDalPayment._TXNREFNO, err)
            If String.IsNullOrEmpty(err) Then
                snackbar("green", "You may now re-try your Transaction.")
            Else
                snackbar("red", err)
            End If

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
      
    End Sub

    Private Sub btnSubmitReqBill_ServerClick(sender As Object, e As EventArgs) Handles btnSubmitReqBill.ServerClick
        Try
            Dim _acctno As String = hdnReqBill_Acctno.Value
            Dim _LQP As String = hdnReqBill_LQP.value
            Dim _SLQP As String = hdnReqBill_SLQP.Value

            Dim Sent As Boolean
            Dim Subject As String = "Billing Request - Business Permit "
            Dim Body As String = 
            " Taxpayer has Requested for Updated Billing TOP with the following Details:" & _
             "<br><br>" & _
            " Email Address : <b>" & cSessionUser._pUserID & "</b> <br>" & _
            " BIN: <b> " & _acctno & " </b> <br>" & _
            " Selected Quarter to Pay : <b>" & _SLQP & "</b>"

            Dim Emails As String = Nothing
            cDalNewSendEmail.get_Emails("TREASURY", Emails)
            cDalNewSendEmail.SendEmail(Emails, Subject, Body, Sent)

            Emails = Nothing
            cDalNewSendEmail.get_Emails("BPLO", Emails)

            cDalNewSendEmail.SendEmail(Emails, Subject, Body, Sent)


            If Sent = True Then
                snackbar("green", "Request has been submitted.")
            Else
                snackbar("red", "Failed to Submit Request")
            End If

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Sub
End Class