Public Class BPLONewBusinessList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        check_NewBPVersion()
        If Not IsPostBack Then
            loaddata()
            loaddata_ForAppNo()      ' Pending
            loaddata_ForRegulatory() ' Approved - For Regulatory
            loaddata_ForApproval()   ' Approved - For BPLO Approval
            _BindGridview(GridView4) ' For notification

            If cInit_CBPReg._Fn_IsCBP_Integrated = True Then
                _BtnCBP.Visible = True
            Else
                _BtnCBP.Visible = False
            End If
        Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            Dim _nStr() As String
            Dim valAccount As String
            Dim valemail As String
            Dim valAppDate As String
            If Request("__EVENTARGUMENT").Contains("|") Then
                _nStr = Request("__EVENTARGUMENT").Split("|")
                valAccount = _nStr(0).ToString
                valemail = _nStr(1).ToString
                valAppDate = _nStr(2).ToString
            Else
                valAccount = Request("__EVENTARGUMENT")
            End If

            If action = "Notify" Then
                do_notify(valAccount, valemail, valAppDate)

            End If
        End If
    End Sub

    Sub check_NewBPVersion()
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        If _nClass._pSubNewBPv2() = True Then
            div_NewBPv2.Style.Add("display", "block")
            div_NewBPv1.Style.Add("display", "none")

            Dim _nclassX As New cDalGetModules
            _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclassX._pSubGetAvailableModules("BP_NRegulatory") = False Then
                div_NBP_ForRegulatory.Style.Add("display", "none")
            End If


        Else
            div_NewBPv1.Style.Add("display", "block")
            div_NewBPv2.Style.Add("display", "none")
        End If
    End Sub
    Public Sub _pGetCon(cls As cDalVerifications, dbname As String)
        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = dbname
        _nClBP._pSubRecordSelectSpecific()

        '----------------------------------
        'Specify Blank to Select Nothing but Column Names
        Select Case dbname
            Case "RPTIMS"
                cls._pLocalServer = _nClBP._pDBDataSource
                cls._pLocalDb = _nClBP._pDBInitialCatalog
            Case "OAIMS"
                cls._pLocalServer1 = _nClBP._pDBDataSource
                cls._pLocalDb1 = _nClBP._pDBInitialCatalog
            Case "BPLTIMS"
                cls._pLocalServer = _nClBP._pDBDataSource
                cls._pLocalDb = _nClBP._pDBInitialCatalog
        End Select
    End Sub

    Public Sub loaddata_ForAppNo()
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectNewBPSubmitted()
            GridView1.DataSource = _nClass._mDataTable
            GridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loaddata_ForRegulatory()
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectForRegulatory()
            GridView2.DataSource = _nClass._mDataTable
            GridView2.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loaddata_ForApproval()
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectForApproval()
            GridView_ForApproval.DataSource = _nClass._mDataTable
            GridView_ForApproval.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loaddata()
        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

        _pGetCon(_nClass, "BPLTIMS")
        _pGetCon(_nClass, "OAIMS")

        _nClass._pLoadNewBusinessApplication()
        _nClass._pLoadNewBusinessApplicationHistory()

        ' load New Bsuienss application to gridview
        GridView3.DataSource = _nClass._pDataTable2
        GridView3.DataBind()

        _oGvReviewed.DataSource = _nClass._pDataTable3
        _oGvReviewed.DataBind()

    End Sub

    Protected Sub datagrid4_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            _BindGridview(GridView4)
            GridView4.PageIndex = e.NewPageIndex
            GridView4.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata()
            GridView3.PageIndex = e.NewPageIndex
            GridView3.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging1(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata()
            _oGvReviewed.PageIndex = e.NewPageIndex
            _oGvReviewed.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ImageButton_Click(sender As Object, e As EventArgs)
        Try
            Dim redirectURL As String = Nothing
            Dim _nButton As ImageButton = TryCast(sender, ImageButton)
            Dim gvrow As GridViewRow = CType(_nButton.NamingContainer, GridViewRow)

            Dim _nAcctNo As String
            Dim _nForYear As String
            Dim _Status As String
            Dim _Remarks As String
            _nAcctNo = DirectCast(gvrow.FindControl("oLabelBIN"), Label).Text
            _nForYear = DirectCast(gvrow.FindControl("oLabelForYear"), Label).Text
            _Status = DirectCast(gvrow.FindControl("oLabelStatus"), Label).Text
            Session("Remarks") = DirectCast(gvrow.FindControl("oLabelRemarks"), Label).Text

            cSessionLoader._pAccountNo = _nAcctNo

            redirectURL = "BPLTIMS_BPLOReview.aspx?AccountNo=" & _nAcctNo & "&ForYear=" & _nForYear

            Response.Redirect(redirectURL)
            'cUrlRedirects._pSubRedirect(rPages_VS2014WABPLTIMS.pBPLOReview & "?AccountNo=" & _nAcctNo & "&ForYear=" & _nForYear, , 0)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ImageButton_Click2(sender As Object, e As EventArgs)
        Try
            Dim redirectURL As String = Nothing
            Dim _nButton As ImageButton = TryCast(sender, ImageButton)
            Dim gvrow As GridViewRow = CType(_nButton.NamingContainer, GridViewRow)

            Dim _nApplicationID As String
            Dim _nForYear As String
            Dim _Status As String
            Dim _Remarks As String
            _nApplicationID = DirectCast(gvrow.FindControl("oLabelApplication_ID"), Label).Text
            '_nForYear = DirectCast(gvrow.FindControl("oLabelForYear"), Label).Text
            '_Status = DirectCast(gvrow.FindControl("oLabelStatus"), Label).Text
            'Session("Remarks") = DirectCast(gvrow.FindControl("oLabelRemarks"), Label).Text

            cSessionLoader_NEWBP_Draft._pApplication_ID = _nApplicationID
            cSessionLoader._pAccountNo = _nApplicationID

            redirectURL = "BPLONewBP_ForApplicationNo.aspx?ApplicationID=" & _nApplicationID

            Response.Redirect(redirectURL)
            'cUrlRedirects._pSubRedirect(rPages_VS2014WABPLTIMS.pBPLOReview & "?AccountNo=" & _nAcctNo & "&ForYear=" & _nForYear, , 0)
        Catch ex As Exception

        End Try
    End Sub


#Region "FOR NOTIFICATION"
    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Private Sub _BindGridview(_nGridview As GridView)
        Try

            _nGridview.DataSource = Nothing

            Dim _nSucess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select ACCTNO,cbp_transaction_no ,COMMNAME,EMAILADDR,APP_DATE from BUSMAST "
                '   ._pCondition = "  WHERE REMARKS = ''Reviewed/ For Assessment Billing'' AND STATCODE = ''N'' AND ISNULL(IsNotified,0) <> 1 "
                ._pCondition = "  WHERE REMARKS = ''Acquired : Reviewed/ For Assessment Billing'' AND STATCODE = ''N'' AND ISNULL(IsNotified,0) <> 1 "
                ._pSortBy = " ORDER BY APP_DATE ASC"
                ._pExec(_nSucess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    _nGridview.DataSource = _nDataTable
                    _nGridview.DataBind()
                Else
                    cGridview.pEmptyGridView(_nDataTable, _nGridview, "-- NO RECORD AVAILABLE --")
                End If

            End With

        Catch ex As Exception

        End Try
    End Sub
    Private Sub do_notify(_nAcctno As String, _nEmail As String, _nAppDate As String)
        Try

            cSessionLoader._pAccountNo = _nAcctno
            cLoader_BPLTIMS._pEMAILADDR = _nEmail
            cLoader_BPLTIMS._pAPP_DATE = _nAppDate
            If _SendEmailNotification("Acquired : Reviewed/ For Assessment Billing", "") = True Then
                _TagAsNotified("1")

                If cLoader_CBPAuthRep._pIsFromCBP = True Then
                    Dim _nStatCode As String = "BUSINESS-PERMIT-FOR-PAYMENT"
                    '"VERIFIED-BUSINESS-PERMIT"
                    cInit_CBPReg.UpdateCBPAppStatus(_nStatCode, "New", cLoader_BPLTIMS._pAPP_DATE)
                    cInit_CBPReg._InsertAppStatLog(_nStatCode)
                End If
                'UpdateBusMastRemarks(_nRemarks)

                'If _nRemarks = "Reviewed/ For Assessment Billing" Then
                '    UpdateBusMastForPayment()
                'End If
                'SNACK BAR GREEN 
                'MESSAGE "Taxtpayer Sucessfully notified."
                _BindGridview(GridView4)
                snackbar("green", "Notification sent for account no. " & cSessionLoader._pAccountNo & ".")

                'Response.Write("<script language='javascript'>window.alert('Taxpayer successfully Notified');</script>")
                'Response.Redirect("NotificationPages/BPLONotification.aspx")
                Exit Sub
            Else
                snackbar("green", "Nofification failed to send for account  no. " & cSessionLoader._pAccountNo & ",please try again.")
                'Response.Write("<script language='javascript'>window.alert('Send notification failed, please try again.');</script>")
                'SNACK BAR RED 
                'MESSAGE "Failed sending notification, please check your internet connection and try again."

                Exit Sub
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub _TagAsNotified(_nNotified As Boolean)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BUSMAST SET IsNotified = 1 "
                ._pCondition = "Where Acctno = ''" & cSessionLoader._pAccountNo & "''"
                ._pExec(_nSuccess, _nErrMsg)



            End With

        Catch ex As Exception

        End Try
    End Sub
    Private Function _SendEmailNotification(_nResponse As String, _nComment As String) As Boolean

        Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim PageName As String = System.IO.Path.GetFileName(PagePath)
        Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")

        Dim Sent As Boolean
        Dim Subject As String = "BUSINESS PERMIT APPLICATION STATUS"
        Dim Body As String

        Select Case _nResponse

            Case "Acquired : Reviewed/ For Assessment Billing"

                Body = _
                  "<br> Sir/Ma`am: <br> <br>" & _
                    "Your Business account for BIN " & cSessionLoader._pAccountNo & " is now approved and ready for billing and payment. " & _
                    "Please to pay your bill online please do the following: <br> <br>" & _
                    " 1. Login to Web Service Portal <br>" & _
                    " 2. Once Logged in, Goto Accounts and find the BIN that you want to process for payment.<br>" & _
                    " 3. Click Payment link on the right most column. Once clicked, Billing TOP will display. <br>" & _
                    " 4. Click Proceed to Payment. <br>" & _
                    " 5. Select the desired payment channel then click the (Pay Now) button. <br> <br> " & _
                     " <a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a> <br>" & _
                    "You can pay online by providing your payment details or visit the License Treasury Office. <br> <br>" & _
                     IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                    "Thank you. <br>"

                '"<br> Sir/Ma`am: <br> <br>" & _
                '"Your Business account for Account Number " & cSessionLoader._pAccountNo & " is now approved and ready for billing and payment. " & _
                '"Please go to Accounts and click Payment link on For payment tab to generate your bill. <br>" & _
                '"You can pay online by providing your payment details or visit the License Treasury Office. <br> <br>" & _
                ' IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                '"Thank you. <br>"

            Case "Lacks Mandatory Requirements"

                Body = _
                    "<br> Sir/Ma`am: <br> <br>" & _
                    "Your Business account for Account Number " & cSessionLoader._pAccountNo & " is now pending until you submit all mandatory requirements. " & _
                     IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                    "Thank you. <br>"

        End Select


        Try
            cDalNewSendEmail.SendEmail(cLoader_BPLTIMS._pEMAILADDR, Subject, Body, Sent)
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function
#End Region

    Protected Sub _oButton_Click2(sender As Object, e As EventArgs) Handles _
   _BtnCBP.ServerClick
        Try

            Dim redirectURL As String = "CBP_PostECertificate.aspx"

            Response.Redirect(redirectURL)

        Catch ex As Exception
            'snackbar("red", "Error Occured: " & ex.Message)
        End Try

    End Sub

End Class