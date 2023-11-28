
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class BusinessRenewalTreasury
    Inherits System.Web.UI.Page


    Dim usertmp As String
    Dim xTotalDue As Double
    Dim nTempGross As String
    Dim nHasPayment As Boolean = False
    Dim nFullyPaid As Boolean = False
    Dim nLQP As Integer
    Dim nLGUName As String
    Public Shared ngrossvisibility As String = Nothing

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        'TextAskHeadInit()
        'TextAskInit()
        'DropDownAskInit()

    End Sub





    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nQtrPay As String
        Dim _nSelectedQtr As Integer
        Dim _nAPPRV_TOP_ONLINE As Integer
        Dim _nISASSESS As Integer
        Dim _ScriptJSText As String = ""
        Dim _nClass_ApplBP As New CDalGenPaymentBusline

        If ngrossvisibility = "Assess" Then
            '_ScriptJSText = "document.getElementsByClassName('thgross')[0].style.visibility = 'hidden';" & _
            '    "var sample  = document.getElementsByClassName('tdgross');" & _
            '    "for (var a = 0 ; a < sample.length ; a++) { sample[a].style.visibility = 'hidden'; }"
            _oGVBusinessRenewal.Visible = False
            _oPnYandQ.Visible = False
            _oPnTotal.Visible = False
            _oPnPrintStatement.Visible = False
        Else
            '_ScriptJSText = "document.getElementsByClassName('thgross')[0].style.visibility = 'visible';" & _
            '    "var sample  = document.getElementsByClassName('tdgross');" & _
            '    "for (var a = 0 ; a < sample.length ; a++) { sample[a].style.visibility = 'visible'; }"
            _oGVBusinessRenewal.Visible = True
            _oPnYandQ.Visible = True
            _oPnTotal.Visible = True
            _oPnPrintStatement.Visible = True
        End If

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>")
        sb.Append(_ScriptJSText)
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

        cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

        If Not Me.IsPostBack Then
            Dim tst As String
            cSessionLGUProfile._pGetLGUProfile(tst)
            nLGUName = cSessionLGUProfile._pLGU_Header2
            GetTypeWOwnCode()
            If cSessionUser._pUserID = Nothing Then Response.Redirect("register.aspx")
            usertmp = cSessionUser._pUserID.Replace(".", "")

            'cSessionLoader._pAccountNo pang call ng naselect na account no.
            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo

            '_nClass1._pSubSelectPrevGross()
            '_oTxtPreviousGross.Value = Format(_nClass1._nPrevGross, "###,###,##0.00")
            '_oTxtBusLine.Value = _nClass1._nBusDesc

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nClass2 As New cDalBPSOS
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass2._pAcctNo = cSessionLoader._pAccountNo
            _nClass2._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass2._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass2._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass2._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass2._pSubGetDetail()

            _oLblBusID.Text = cSessionLoader._pAccountNo
            _oLblBusOwner.Text = _nClass2._nOwner
            _oLblBusName.Text = _nClass2._nBusName
            _oLblBusAddress.Text = _nClass2._nBusAddress
            _oLblBusCategory.Text = _nClass2._nBusCategory
            _oLblBusCategory1.Text = _nClass2._nBusCategory1
            _oLblMOP.Text = _nClass2._nMOP


            _nClass2._pLocServer = _nClBP._pDBDataSource
            _nClass2._pLocDB = _nClBP._pDBInitialCatalog
            _nClass2._pSubGetCurYear()
            _nClass2._pForYear = _nClass2._nCurYear
            '_nClass2._pForYear = _radYear.Value
            _nClass2._pSubCheckPayment()
            _nQtrPay = _nClass2._nOutput


            _mSubCheckifHasPayment()
            _nClass2._pSubGETAPPRV_TOP_ONLINE()
            _nAPPRV_TOP_ONLINE = _nClass2._nOutput


            loadGrid_TOP(cSessionLoader._pAccountNo)
            div_TOP.Style.Add("display", "block")

            txt_Subject.Value = "DECLINED : Application of Business Renewal"
            txt_Header.Value = "Your Business Renewal Application has been DECLINED for the following reasons : "
            txt_Body.Value = ""

            If _nAPPRV_TOP_ONLINE = 1 Then
                _nClass2._pSubCHECKISASSESS()
                _nISASSESS = _nClass2._nOutput
                btnPostAssessment.Visible = False
                btnApprove.Visible = True
                _obtnDecline.Visible = False

                _oPnPrintStatement.Visible = True

                div_AssessNotice.Style.Add("display", "none")
                div_Request.Style.Add("display", "none")
                div_RequestPaymentMode.Style.Add("display", "none")
                div_TOP.Style.Add("display", "block")
                btnApprove.Style.Add("display", "block")

            ElseIf _nAPPRV_TOP_ONLINE = 2 Then
                div_AssessNotice.Style.Add("display", "none")
                div_Request.Style.Add("display", "block")
                div_RequestPaymentMode.Style.Add("display", "none")
                div_TOP.Style.Add("display", "none")

            ElseIf _nAPPRV_TOP_ONLINE = 3 Then
                div_AssessNotice.Style.Add("display", "none")
                div_Request.Style.Add("display", "none")
                div_RequestPaymentMode.Style.Add("display", "block")
                div_TOP.Style.Add("display", "none")
            Else
                div_RequestPaymentMode.Style.Add("display", "none")
                div_TOP.Style.Add("display", "none")
                div_Request.Style.Add("display", "none")
                div_AssessNotice.Style.Add("display", "block")

                _nClass2._pSubCHECKISASSESS()
                _nISASSESS = _nClass2._nOutput
                btnPostAssessment.Visible = True
                btnApprove.Visible = False
                _obtnDecline.Visible = True
                If _nISASSESS = 1 Then
                    btnPostAssessment.Visible = False
                    btnApprove.Visible = True
                    _obtnDecline.Visible = False
                    '_oPnRadQtr.Visible = True
                    '_oPnTotal.Visible = True
                    _oLblYear.Visible = True
                    _obtnPrintStatement.Visible = True
                End If


            End If
            '  Exit Sub
            'If _nQtrPay = 4 Then
            '    'MsgBox("Account already enrolled!")
            '    snackbar("red", "Account already paid!.")
            '    _oRadio1stQ.Enabled = False
            '    _oRadio2ndQ.Enabled = False
            '    _oRadio3rdQ.Enabled = False
            '    _oRadio4thQ.Enabled = False
            '    _obtnSaveEdit.Disabled = True
            '    btnPostAssessment.Disabled = True
            '    _mDisplayApplBusinessPermit()
            '    Exit Sub
            'End If

            'If nFullyPaid = True Then
            '    _obtnSaveEdit.Disabled = True
            '    Button2.Disabled = True
            '    btnPostAssessment.Disabled = True
            '    Exit Sub
            'End If


            If nHasPayment = True Then 'has payment in BP local
                _nQtrPay = nLQP
                _obtnSaveEdit.Disabled = True

                btnPostAssessment.Disabled = True
                If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
                    If _nQtrPay = 0 Then
                        _oRadio1stQ.Enabled = True
                        _oRadio2ndQ.Enabled = True
                        _oRadio3rdQ.Enabled = True
                        _oRadio4thQ.Enabled = True
                    ElseIf _nQtrPay = 1 Then
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = True
                        _oRadio3rdQ.Enabled = True
                        _oRadio4thQ.Enabled = True
                    ElseIf _nQtrPay = 2 Then
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = True
                        _oRadio4thQ.Enabled = True
                    ElseIf _nQtrPay = 3 Then
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = False
                        _oRadio4thQ.Enabled = True
                    Else
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = False
                        _oRadio4thQ.Enabled = False
                    End If
                End If
                '_oRadio1stQ.Enabled = False
                '_oRadio2ndQ.Enabled = False
                '_oRadio3rdQ.Enabled = False
                '_oRadio4thQ.Enabled = False

                _nSelectedQtr = 4
                _oRadio4thQ.Checked = True
                _nClass2._pQtrPaid = _nQtrPay
                _nClass2._pQtr = _nSelectedQtr
                _nClass2._pSubGetPenalty()

                '_mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)

                If _nQtrPay = 0 Then
                    _mSubDisplayQtrPayment(_nSelectedQtr)
                Else
                    _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)
                End If


                _nClass2._pSubGetTotalDue()
                _oLabelTotalAmountDue.Text = Format(_nClass2._nTotalDue, "###,###,##0.00")

                _nClass2._pSubShowBusDetailExtn3()
                _GVBusinessLine.DataSource = _nClass2._mDataTable
                _GVBusinessLine.DataBind()



            Else




                If _nQtrPay = 0 Then
                    ''for Ask hdg,qty,opt
                    ''   _mSubGETGR()

                    TextAskHead()
                    TextAsk()
                    DropDownAsk()

                    '==========================


                    _oRadio4thQ.Checked = True
                    _nClass1._pQtr = "4"



                    If _nISASSESS = 1 Then
                        _obtnSaveEdit.Disabled = True
                        btnPostAssessment.Disabled = True
                        _nClass2._pSubPaymentGross()
                        _GVBusinessLine.DataSource = _nClass2._mDataTable
                        _GVBusinessLine.DataBind()
                        _nClass2._pQtrPaid = _nQtrPay
                        _nClass2._pQtr = _nSelectedQtr
                        _nClass2._pSubGetPenalty()
                        _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)
                        _nClass2._pSubGetTotalDue()
                        _oLabelTotalAmountDue.Text = Format(_nClass2._nTotalDue, "###,###,##0.00")
                        '_oPnRadQtr.Visible = True
                        '_oPnTotal.Visible = True
                        _oLblYear.Visible = True
                        _obtnPrintStatement.Visible = True
                    Else
                        _nClass2._pSubShowBusDetailExtn()
                        _GVBusinessLine.DataSource = _nClass2._mDataTable
                        _GVBusinessLine.DataBind()
                    End If


                    '_nClass2._pSubShowBusDetailExtn()
                    '_GVBusinessLine.DataSource = _nClass2._mDataTable
                    '_GVBusinessLine.DataBind()
                Else
                    _obtnSaveEdit.Disabled = True
                    btnPostAssessment.Disabled = True
                    If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
                        If _nQtrPay = 0 Then
                            _oRadio1stQ.Enabled = True
                            _oRadio2ndQ.Enabled = True
                            _oRadio3rdQ.Enabled = True
                            _oRadio4thQ.Enabled = True
                        ElseIf _nQtrPay = 1 Then
                            _oRadio1stQ.Enabled = False
                            _oRadio2ndQ.Enabled = True
                            _oRadio3rdQ.Enabled = True
                            _oRadio4thQ.Enabled = True
                        ElseIf _nQtrPay = 2 Then
                            _oRadio1stQ.Enabled = False
                            _oRadio2ndQ.Enabled = False
                            _oRadio3rdQ.Enabled = True
                            _oRadio4thQ.Enabled = True
                        ElseIf _nQtrPay = 3 Then
                            _oRadio1stQ.Enabled = False
                            _oRadio2ndQ.Enabled = False
                            _oRadio3rdQ.Enabled = False
                            _oRadio4thQ.Enabled = True
                        Else
                            _oRadio1stQ.Enabled = False
                            _oRadio2ndQ.Enabled = False
                            _oRadio3rdQ.Enabled = False
                            _oRadio4thQ.Enabled = False
                        End If
                    End If
                    _nClass1._pQtr = "4"

                    _nSelectedQtr = 4
                    _nClass2._pSubPaymentGross()
                    _GVBusinessLine.DataSource = _nClass2._mDataTable
                    _GVBusinessLine.DataBind()
                    _nClass2._pQtrPaid = _nQtrPay
                    _nClass2._pQtr = _nSelectedQtr
                    _nClass2._pSubGetPenalty()

                    _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)

                    _nClass2._pSubGetTotalDue()

                    _oLabelTotalAmountDue.Text = Format(_nClass2._nTotalDue, "###,###,##0.00")

                End If
                'View_Details()
            End If

            ''  _nClass_ApplBP._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            ''  _nClass_ApplBP._GetApplBusinessPermitDetail()
            _mDisplayApplBusinessPermit()


            Dim _nSqlCmd As SqlCommand
            Dim _nSqlDtr As SqlDataReader
            Dim _nOwnerNo As String = Nothing
            Dim _nDataTable As New DataTable

            '  ._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS

            _nSqlCmd = New SqlCommand("  Select (FirstName + ' ' + LastName) as UP_Name,  [Address] as UP_Addr, Contact_Cp as UP_ContactNo , " &
            " UserID as UP_EmailAddr  from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].[dbo].[Registered] " &
            " where USERID='" & cDalBPSOS._nEmail & "'", cGlobalConnections._pSqlCxn_OAIMS)

            _nSqlDtr = _nSqlCmd.ExecuteReader
            If _nSqlDtr.HasRows Then
                While _nSqlDtr.Read
                    _oLabelFullname.InnerText = _nSqlDtr.Item("UP_Name").ToString
                    _oLabelUserEmailAddress.InnerText = _nSqlDtr.Item("UP_EmailAddr").ToString
                    _oLabelAddress.InnerText = _nSqlDtr.Item("UP_Addr").ToString
                    _oLabelUserContactNo.InnerText = _nSqlDtr.Item("UP_ContactNo").ToString

                End While
            End If


            _nSqlCmd.Dispose()
            _nSqlDtr.Dispose()

            ' hdnEmail.Value
            ' hdnORNO.Value
            ' hdnTDN.Value

            ' _oLabelTDN.InnerText = hdnTDN.Value

            GetFiles(cDalBPSOS._nEmail)
            Dim newsb As System.Text.StringBuilder = New System.Text.StringBuilder()
            newsb.Append("<script language='javascript'>")
            newsb.Append("$('#myModal').modal('show');")
            newsb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "NewJSScript", sb.ToString())


            View_Details()


        Else
            Dim tst As String
            cSessionLGUProfile._pGetLGUProfile(tst)
            nLGUName = cSessionLGUProfile._pLGU_Header2

            If InStr(1, UCase(nLGUName), "CALOOCAN") = 0 Then
                If Month(Now) > 9 Then
                    _oRadio1stQ.Enabled = False
                    _oRadio2ndQ.Enabled = False
                    _oRadio3rdQ.Enabled = False
                    _oRadio4thQ.Enabled = True
                ElseIf Month(Now) > 6 Then
                    _oRadio1stQ.Enabled = False
                    _oRadio2ndQ.Enabled = False
                    _oRadio3rdQ.Enabled = True
                    _oRadio4thQ.Enabled = True
                ElseIf Month(Now) > 3 Then
                    _oRadio1stQ.Enabled = False
                    _oRadio2ndQ.Enabled = True
                    _oRadio3rdQ.Enabled = True
                    _oRadio4thQ.Enabled = True
                Else
                    _oRadio1stQ.Enabled = True
                    _oRadio2ndQ.Enabled = True
                    _oRadio3rdQ.Enabled = True
                    _oRadio4thQ.Enabled = True
                End If
            End If
            'nTempGross = Request.Form("txarea")


            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")



            If action = "Post" And val = "OK" Then
                Post_OK()
                Exit Sub
            End If



            If action = "Post1" And val = "OK1" Then
                _mSubApprovePayment()
                Exit Sub
            End If

            If action = "DownloadFiles" Then
                Download_Selected_New(val, cSessionLoader._pAccountNo)
                'Download_Selected(cSessionLoader._pAccountNo)
                'Response.Write("<script>window.open('Sample.aspx','_blank');</script>")                    
                'chie = True
            End If

            If action = "DownloadFiles_profile" Then
                Download_Selected_profile(val, cDalBPSOS._nEmail)
            End If

            'If action = "QuarterClick" Then
            '    If _oTxtEnterGross.Value <> "" Then
            '        _mSubDisplayQtrPayment(val)
            '    End If
            'End If
            'If Trim(nTempGross) = "" Then
            '    snackbar("red", "Please input Gross Amount!")
            '    Exit Sub
            'End If


            TextAskHeadInit()
            TextAskInit()
            DropDownAskInit()



            Dim _nClBP1 As New cDalGlobalConnectionsDefault
            _nClBP1._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP1._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP1._pSubRecordSelectSpecific()

            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            '  _nClass._pForYear = _radYear.Value
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            cDalBPSOS._mShareAcctNo = cSessionLoader._pAccountNo

            _nClass._pLocServer = _nClBP1._pDBDataSource
            _nClass._pLocDB = _nClBP1._pDBInitialCatalog

            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

            _nClass._pSubCheckPayment()
            _nQtrPay = _nClass._nOutput
            _mSubCheckifHasPayment()

            If _oRadioPickup.Checked = True Then

                _nClass._pDeliver = 1
                _nClass._pSubDelFee()
            Else
                _nClass._pDeliver = 0
                _nClass._pSubDelFee()

            End If

            If nFullyPaid = True Then Exit Sub
            If nHasPayment = True Then 'has payment in BP local
                _nQtrPay = nLQP
                _obtnSaveEdit.Disabled = True
                If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
                    If _nQtrPay = 0 Then
                        _oRadio1stQ.Enabled = True
                        _oRadio2ndQ.Enabled = True
                        _oRadio3rdQ.Enabled = True
                        _oRadio4thQ.Enabled = True
                    ElseIf _nQtrPay = 1 Then
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = True
                        _oRadio3rdQ.Enabled = True
                        _oRadio4thQ.Enabled = True
                    ElseIf _nQtrPay = 2 Then
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = True
                        _oRadio4thQ.Enabled = True
                    ElseIf _nQtrPay = 3 Then
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = False
                        _oRadio4thQ.Enabled = True
                    Else
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = False
                        _oRadio4thQ.Enabled = False
                    End If
                End If
                If _oRadio1stQ.Checked = True Then
                    _nSelectedQtr = 1
                ElseIf _oRadio2ndQ.Checked = True Then
                    _nSelectedQtr = 2
                ElseIf _oRadio3rdQ.Checked = True Then
                    _nSelectedQtr = 3
                Else
                    _nSelectedQtr = 4
                End If
                _nClass._pQtrPaid = _nQtrPay
                _nClass._pQtr = _nSelectedQtr
                _nClass._pSubGetPenalty()
                _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)

            Else
                If _nQtrPay = 0 Then
                    If _oRadio1stQ.Checked = True Then
                        '_mSubDisplayQtrPayment(1)
                        _nSelectedQtr = 1
                    ElseIf _oRadio2ndQ.Checked = True Then
                        ' _mSubDisplayQtrPayment(2)
                        _nSelectedQtr = 2
                    ElseIf _oRadio3rdQ.Checked = True Then
                        ' _mSubDisplayQtrPayment(3)
                        _nSelectedQtr = 3
                    Else
                        '  _mSubDisplayQtrPayment(4)
                        _nSelectedQtr = 4
                    End If
                    _nClass._pQtr = _nSelectedQtr
                    _nClass._pQtrPaid = _nQtrPay
                    _nClass._pSubGetPenalty()
                    _mSubDisplayQtrPayment(_nSelectedQtr)
                    _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
                    _nClass._pSubShowBusDetailExtn2()
                    _GVBusinessLine.DataSource = _nClass._mDataTable
                    _GVBusinessLine.DataBind()


                Else
                    _obtnSaveEdit.Disabled = True
                    If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
                        If _nQtrPay = 0 Then
                            _oRadio1stQ.Enabled = True
                            _oRadio2ndQ.Enabled = True
                            _oRadio3rdQ.Enabled = True
                            _oRadio4thQ.Enabled = True
                        ElseIf _nQtrPay = 1 Then
                            _oRadio1stQ.Enabled = False
                            _oRadio2ndQ.Enabled = True
                            _oRadio3rdQ.Enabled = True
                            _oRadio4thQ.Enabled = True
                        ElseIf _nQtrPay = 2 Then
                            _oRadio1stQ.Enabled = False
                            _oRadio2ndQ.Enabled = False
                            _oRadio3rdQ.Enabled = True
                            _oRadio4thQ.Enabled = True
                        ElseIf _nQtrPay = 3 Then
                            _oRadio1stQ.Enabled = False
                            _oRadio2ndQ.Enabled = False
                            _oRadio3rdQ.Enabled = False
                            _oRadio4thQ.Enabled = True
                        Else
                            _oRadio1stQ.Enabled = False
                            _oRadio2ndQ.Enabled = False
                            _oRadio3rdQ.Enabled = False
                            _oRadio4thQ.Enabled = False
                        End If
                    End If

                    If _oRadio1stQ.Checked = True Then
                        '_mSubDisplayQtrPayment(1)
                        _nSelectedQtr = 1
                    ElseIf _oRadio2ndQ.Checked = True Then
                        ' _mSubDisplayQtrPayment(2)
                        _nSelectedQtr = 2
                    ElseIf _oRadio3rdQ.Checked = True Then
                        ' _mSubDisplayQtrPayment(3)
                        _nSelectedQtr = 3
                    Else
                        '  _mSubDisplayQtrPayment(4)
                        _nSelectedQtr = 4
                    End If
                    _nClass._pQtrPaid = _nQtrPay
                    _nClass._pQtr = _nSelectedQtr
                    _nClass._pSubGetPenalty()
                    _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)

                End If
            End If
            _nClass._pSubGetTotalDue()

            _oLabelTotalAmountDue.Text = Format(_nClass._nTotalDue, "###,###,##0.00")

            View_Details()




        End If
    End Sub
    Private Sub btn_TOP_ServerClick(sender As Object, e As EventArgs) Handles btn_TOP.ServerClick
        ReportViewer.NEWBP_TOP_ACCTNO = cSessionLoader._pAccountNo
        ReportViewer.NEWBP_TOP_Email = cDalBPSOS._nEmail
        Response.Redirect("Report/ReportViewer.aspx?ReportType=NEW_BP_TOP")
    End Sub
    Public Sub loadGrid_TOP(ByVal acctno As String)
        Try
            Dim Sum_TotAmtDue As Double
            Dim Sum_TotPenDue As Double
            Dim Sum_TotTaxDue As Double
            Dim Sum_TotETC As Double
            Dim CTC_AMOUNT As Double
            Dim CTC_REMARK As String
            Dim _GrandTotal As Double
            Dim _nClass2 As New cDalNewBP

            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass2._pSubSelectTOP(acctno, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, 0)
            GridViewTOP.DataSource = _nClass2._mDataTable
            GridViewTOP.DataBind()

            _nClass2._pSubGetCTC(acctno, CTC_AMOUNT, CTC_REMARK)
            lblCTCAmount.InnerText = String.Format("{0:C}", CTC_AMOUNT).Replace("$", "")
            TotAmtDue.InnerText = String.Format("{0:C}", Sum_TotAmtDue).Replace("$", "")
            _GrandTotal = CTC_AMOUNT + Sum_TotAmtDue
            GrandTotal.InnerText = String.Format("{0:C}", _GrandTotal).Replace("$", "")

            cSessionLoader._pTotalAmountDue = Format(_GrandTotal.ToString, "STANDARD")

            GridViewTOP.FooterRow.Cells(0).ColumnSpan = 3
            GridViewTOP.FooterRow.Cells(0).Font.Bold = True
            GridViewTOP.FooterRow.Cells(0).Text = "T O T A L    D U E :"
            GridViewTOP.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Center

            GridViewTOP.FooterRow.Cells(1).Font.Bold = True
            GridViewTOP.FooterRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(1).Text = Sum_TotTaxDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(2).Font.Bold = True
            GridViewTOP.FooterRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(2).Text = Sum_TotPenDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(3).Font.Bold = True
            GridViewTOP.FooterRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(3).Text = Sum_TotAmtDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(5).Font.Bold = True
            GridViewTOP.FooterRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(5).Text = Sum_TotETC.ToString("N2")

            GridViewTOP.FooterRow.Cells(6).Visible = False
            GridViewTOP.FooterRow.Cells(7).Visible = False
        Catch ex As Exception

        End Try
    End Sub


    Private Sub _obtnPrintApplication_ServerClick(sender As Object, e As EventArgs) Handles _obtnPrintApplication.ServerClick
        Try
            '_oPnRadQtr.Visible = True
            '_oPnTotal.Visible = True
            _oLblYear.Visible = True
            _obtnPrintStatement.Visible = True

            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            '_nClass2._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            '_nClass2._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            '_nClass2._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            '_nClass2._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            '_nClass2._pSubGetDetail()
            '_nClass2._pLocServer = _nClBP._pDBDataSource
            '_nClass2._pLocDB = _nClBP._pDBInitialCatalog
            ' _nClass._pForYear = _radYear.Value
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            '_nClass2._pSubCheckPayment()
            '_nQtrPay = _nClass2._nOutput

            '_nClass2._pSubGetTotalDue()
            '_oLabelTotalAmountDue.Text = Format(_nClass2._nTotalDue, "###,###,##0.00")
            nTempGross = Request.Form("txarea")

            'If Trim(nTempGross) = "" Then

            'End If
            _nClass._pGrossDetail = nTempGross
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubGetGross()
            _nClass._pSubShowBusDetailExtn2()
            _GVBusinessLine.DataSource = _nClass._mDataTable
            _GVBusinessLine.DataBind()

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>sessionStorage.setItem('txarea','" & hdtarea.InnerHtml & "');</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "NewJSScript", sb.ToString())

            '' Display report in New Tab            
            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=APPFORM" + "&ACCTNO=" + cSessionLoader._pAccountNo + "&STATCODE=R&TYPE=BPLO','_blank');</script>")
            '' Display report in Current Tab
        Catch ex As Exception
        End Try
    End Sub

    Private Sub _mDisplayApplBusinessPermit()
        Try
            ''----------------------------------------------------MCE 20210202
            Dim _nClass_ApplBP As New CDalGenPaymentBusline
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR



            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"

            _nClBP._pSubRecordSelectSpecific()
            _nClass_ApplBP._pLocServer = _nClBP._pDBDataSource
            _nClass_ApplBP._pLocDB = _nClBP._pDBInitialCatalog

            _nClass_ApplBP._mSqllocalcon = cGlobalConnections._pSqlCxn_BPLTAS



            '   _nClass_ApplBP._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            ' _nClass_ApplBP._GetApplBusinessPermitDetail()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub _obtnPrintStatement_ServerClick(sender As Object, e As EventArgs) Handles _obtnPrintStatement.ServerClick
        Try

            Dim _nQtr As String = Nothing
            If _oRadio1stQ.Checked = True Then
                _nQtr = "1"
            ElseIf _oRadio2ndQ.Checked = True Then
                _nQtr = "2"
            ElseIf _oRadio3rdQ.Checked = True Then
                _nQtr = "3"
            Else
                _nQtr = "4"

            End If

            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=BPSA" + "&AccountNo=" + cSessionLoader._pAccountNo + "&Qtr=" + _nQtr + "','_blank');</script>")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub _obtnSaveEdit_ServerClick(sender As Object, e As EventArgs) Handles _obtnSaveEdit.ServerClick
        'TextAskHeadInit()
        'TextAskInit()
        'DropDownAskInit()
        _mSubGetGrValue()

        _mSubComputeTax()
    End Sub

    Private Sub _mSubComputeTax()
        Try
            cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR
            Dim tst As String
            cSessionLGUProfile._pGetLGUProfile(tst)
            nLGUName = cSessionLGUProfile._pLGU_Header2

            '----------------------------------
            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectPrevGross()

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()


            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            nTempGross = Request.Form("txarea")

            If Trim(nTempGross) = "" Then
                snackbar("red", "Please input Gross Amount!")
                Exit Sub
            End If







            'Specify Blank to Select Nothing but Column Names
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            '   _nClass._pBusCode = _nClass._nBusCode
            '_nClass._pGross = (_oTxtEnterGross.Value.Replace(",", ""))
            '_nClass._pPrevGross = (_oTxtPreviousGross.Value.Replace(",", ""))
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pArea = _nClass1._nArea
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            '----------------------------------
            ' _nClass._pForYear = _radYear.Value
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pQtr = "4"

            'Get Gross Amount

            _nClass._pGrossDetail = nTempGross
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubGetGross()

            'save busdetailextn
            _nClass._pSubSAVEBPLOGROSS()
            _nClass._pQtrPaid = 0
            '-------------------------------------
            'COMPUTE SP
            _nClass._pSubComputeTax()
            'get garbage
            _nClass._pSubGetGarbage()

            _nClass._pAcctNo = cSessionLoader._pAccountNo
            ' _nClass._pSubSelectPayment()
            _nClass._pSubSelectPaymentPerQtr()


            'If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
            _nClass._pSubCHECKDESCRIPTION()
            'End If

            _oGVBusinessRenewal.DataSource = _nClass._mDataTable
            _oGVBusinessRenewal.DataBind()

            _nClass._pSubGetTotalDue()

            _oLabelTotalAmountDue.Text = Format(_nClass._nTotalDue, "###,###,##0.00")

            _nClass._pSubShowBusDetailExtn2()
            _GVBusinessLine.DataSource = _nClass._mDataTable
            _GVBusinessLine.DataBind()

            ''If myOutPut = 0 Then
            ''    'MsgBox("Invalid Account!")
            ''    snackbar("red", "Invalid Account!")
            ''ElseIf myOutPut = 1 Then
            ''    'MsgBox("Account already enrolled!")
            ''    snackbar("green", "Account already enrolled!")
            ''    _nClass._pSubSelectEnroll()
            ''    ' GridView1.AutoGenerateColumns = True
            ''    GridView1.DataSource = _nClass._mDataTable
            ''    GridView1.DataBind()
            ''Else
            ''    _nClass._pSubSelectEnroll()
            ''    ' GridView1.AutoGenerateColumns = True
            ''    GridView1.DataSource = _nClass._mDataTable
            ''    GridView1.DataBind()

            ''End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Private Sub _mSubDisplayQtrPayment(qtr As Integer)
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog

            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pQtr = qtr


            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            '  _nClass._pQtr 
            _nClass._pSubSelectPaymentPerQtr()
            _nClass._pSubDELINQUENT_NYP()

            _nClass._pSubDELINQUENT_NYP_PREVYR()
            _nClass._pSubGetDelinquent()
            _nClass._pSubSelectRecordPayment()
            'If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
            _nClass._pSubCHECKDESCRIPTION()
            'End If

            _oGVBusinessRenewal.DataSource = _nClass._mDataTable
            _oGVBusinessRenewal.DataBind()
            ' _nClass._pSubGetTotalDue()
            ' _oLabelTotalAmountDue.Text = Format(_nClass._nTotalDue, "###,###,##0.00")



        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Private Sub _mSubDisplayQtrPaymentPaid(qtr As Integer, qtrpaid As Integer)
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS


            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog

            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pQtrPaid = qtrpaid
            _nClass._pQtr = qtr


            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            '  _nClass._pQtr 
            _nClass._pSubSelectPaymentPerQtrPaid()
            _nClass._pSubDELINQUENT_NYP()

            _nClass._pSubDELINQUENT_NYP_PREVYR()
            _nClass._pSubGetDelinquent()
            _nClass._pSubSelectRecordPayment()

            ' If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
            _nClass._pSubCHECKDESCRIPTION()
            ' End If

            _oGVBusinessRenewal.DataSource = _nClass._mDataTable
            _oGVBusinessRenewal.DataBind()
            ' _nClass._pSubGetTotalDue()
            ' _oLabelTotalAmountDue.Text = Format(_nClass._nTotalDue, "###,###,##0.00")



        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Private Sub _oBtnOkay_ServerClick(sender As Object, e As EventArgs) Handles _oBtnOkay.ServerClick
        Try

            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")


            _nClass._pSubPosAssessment()
            btnPostAssessment.Disabled = True
            _obtnSaveEdit.Disabled = True


            'ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModalDone();", True)




        Catch ex As Exception

        End Try
    End Sub

    Sub Post_OK()
        Try
            Dim _nTPEmail As String
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubPosAssessment()


            _nClass._pSubTPEmail()
            _nTPEmail = _nClass._nOutput

            Dim Sent As Boolean
            Dim Subject As String
            Dim Body As String


            Subject = "Account Ready for Payment"

            Body = "Dear Valued Tax Payer, <br>" & _
                    "Your Business Application for Account : " & cSessionLoader._pAccountNo & " is ready for payment. <br>" & _
                    "Please always check your email. <br><br>" & _
                    "Thank you.<br>"
            cDalNewSendEmail.SendEmail(_nTPEmail, Subject, Body, Sent)
            If Sent = True Then
                _nClass._pSubPosAssessment()
                btnPostAssessment.Disabled = True
                _obtnSaveEdit.Disabled = True
                Response.Write("<script>alert('Assessment Posted. Email notification has been sent to tax payer')</script>")
            Else
                Response.Write("<script>alert('Failed to send email notification to tax payer. Please try again.')</script>")
            End If





        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mSubApprovePayment()

        Try
            Dim _nTPEmail As String
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")

            _nClass._pSubAPPROVEPAYMENT()
            _nClass.GenerateWebAssessNo(cSessionLoader._pAccountNo)
            _nClass._pSubTPEmail()
            _nTPEmail = _nClass._nOutput




            Dim Sent As Boolean
            Dim Subject As String
            Dim Body As String

            Subject = "Account Ready for Payment"

            Body = "Dear Valued Tax Payer, <br>" & _
                    "Your Business Renewal Application for Account : " & cSessionLoader._pAccountNo & " is now ready for payment. <br>" & _
                    "Please always check your email. <br><br>" & _
                    "Thank you for choosing online transaction. Have a wonderful day!<br>"
            cDalNewSendEmail.SendEmail(_nTPEmail, Subject, Body, Sent)
            If Sent = True Then
                snackbar("green", "Email notification has been sent to tax payer")
            Else
                snackbar("red", "Failed to send email notification to tax payer")
            End If

            btnApprove.Disabled = True
            _obtnSaveEdit.Disabled = True



        Catch ex As Exception

        End Try
    End Sub
  

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


            If myOutPut = 4 Then
                'MsgBox("Account already enrolled!")
                snackbar("red", "Account already paid!")
                nFullyPaid = True
            ElseIf myOutPut <> 4 And myOutPut <> 5 Then
                nHasPayment = True
                nLQP = myOutPut
            End If




        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Private Sub TextAskInit()
        Try
            'askquestion
            Dim I As Integer

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
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nAskValue As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPASKQTY()
            _nClass._pSubGET_ASKQTY()
            _nAskhdg = ""
            _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE xvalue is null"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("ASKHDG").ToString
                        _nAskValue = Format(_nSqlDr.Item("XVALUE").ToString, "Standard")
                        _nTaxCode = _nSqlDr.Item("TAXCODE").ToString
                        'Dim keys As List(Of String) = Request.Form.AllKeys.Where(Function(key) key.Contains("_oTxtAskQ")).ToList()
                        'Dim i As Integer = 1
                        'For Each key As String In keys
                        '    Me.CreateTextBox("_oTxtAskQ" & i)
                        '    i += 1
                        'Next



                        'Dim keys1 As List(Of String) = Request.Form.AllKeys.Where(Function(key1) key1.Contains("_oLblAskQ")).ToList()
                        'Dim j As Integer = 1
                        'For Each key1 As String In keys1
                        '    Me.CreateLabel("_oLblAskQ" & j, _nAskhdg)
                        '    j += 1
                        'Next

                        I = I + 1


                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlTextAskQ.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlTextAskQ.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:90%'>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------
                        Me.CreateLabel("_oLblAskQTC" & I, _nTaxCode)
                        Me.CreateLabel("_oLblAskQ" & I, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:10%'>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        '  Me.CreateTextBox("_oTxtAskQ" & I)
                        Me.CreateTextBox("_oTxtAskQ" & I, _nAskValue)
                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlTextAskQ.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlTextAskQ.Controls.Add(_oLTtTable1)


                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()





        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetFiles(Email)

        Dim _nclass As New cDalProfileLoader
        _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        cDalVerifications._pSPAName = Nothing
        cDalVerifications._pSPAType = Nothing
        cDalVerifications._pSPAData = Nothing
        cDalVerifications._pGIdName = Nothing
        cDalVerifications._pGIdType = Nothing
        cDalVerifications._pGIdData = Nothing
        _oTxtGovernmentID.Value = Nothing
        _oTxtSPA.Value = Nothing

        _nclass._pSubSelect("Attachment", "where EMAIL = '" & Email & "' and  SeqID = '001'  and ModuleID = 'Change/Update Contact Informations' ;")
        Dim _nDataTable As New DataTable

        _nDataTable = _nclass._pDataTable

        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            '_oPGIDView.Visible = Not _oPGIDView.Visible
            '_oPGIDUpload.Visible = Not _oPGIDUpload.Visible
            _oTxtGovernmentID.Value = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pGIdName = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pGIdType = _nDataTable.Rows(0)("FileType").ToString()
            cDalVerifications._pGIdData = _nDataTable.Rows(0)("FileData")
        End If

        _nclass._pSubSelect("Attachment", " where EMAIL = '" & Email & "' and  SeqID = '002'  and ModuleID = 'Change/Update Contact Informations' ;")
        _nDataTable = _nclass._pDataTable
        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            '_oPSPAView.Visible = Not _oPSPAView.Visible
            '_oPSPAUpload.Visible = Not _oPSPAUpload.Visible
            _oTxtSPA.Value = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pSPAName = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pSPAType = _nDataTable.Rows(0)("FileType").ToString()
            cDalVerifications._pSPAData = _nDataTable.Rows(0)("FileData")
        End If

        _nclass._pSubSelect("Attachment", " where EMAIL = '" & Email & "' and  SeqID = '003'  and ModuleID = 'Change/Update Contact Informations' ;")
        _nDataTable = _nclass._pDataTable
        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            '_oPSPAView.Visible = Not _oPSPAView.Visible
            '_oPSPAUpload.Visible = Not _oPSPAUpload.Visible
            _oTxtBRSec.Value = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pBRSecName = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pBRSecType = _nDataTable.Rows(0)("FileType").ToString()
            cDalVerifications._pBRSecData = _nDataTable.Rows(0)("FileData")
        End If

        '_oFileSPA.Name = _nDataTable.Rows(0)("FileData").ToString()
        '_nClass._pSPAType = _nDataTable.Rows(0)("FileType").ToString()
        '_nClass._pSPAData = _nDataTable.Rows(0)("FileData")
        If _oTxtGovernmentID.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then _oTxtGovernmentID.Value = "No Attached File"
        If _oTxtSPA.Value Is Nothing Or String.IsNullOrEmpty(_oTxtSPA.Value) Then _oTxtSPA.Value = "No Attached File"
        If _oTxtBRSec.Value Is Nothing Or String.IsNullOrEmpty(_oTxtBRSec.Value) Then _oTxtBRSec.Value = "No Attached File"
    End Sub

    Private Sub TextAskHeadInit()
        Try


            'askheading
            Dim I As Integer
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            '_nClass._pForYear = Year(Today)
            '_nClass._pMonth = Month(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String
            Dim _nAskValue As String
            _nClass._pTempTbl = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPASKHDG()
            _nClass._pSubGET_ASKHDG()
            _nAskhdg = ""
            _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE xvalue is null"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("ASKHDG").ToString
                        _nAskValue = _nSqlDr.Item("XVALUE").ToString
                        _nTaxCode = _nSqlDr.Item("TAXCODE").ToString
                        'Dim keys As List(Of String) = Request.Form.AllKeys.Where(Function(key) key.Contains("_oTxtAskHP")).ToList()
                        'Dim i As Integer = 1
                        'For Each key As String In keys
                        '    Me.CreateTextBoxHead("_oTxtAskHP" & i)
                        '    i += 1
                        'Next

                        'Dim keys1 As List(Of String) = Request.Form.AllKeys.Where(Function(key1) key1.Contains("_oLblAskHP")).ToList()
                        'Dim j As Integer = 1
                        'For Each key1 As String In keys1
                        '    Me.CreateLabelHead("_oLblAskHP" & j, _nAskhdg)
                        '    j += 1
                        'Next


                        I = I + 1

                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlAllAskHeading.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:85%'>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------
                        Me.CreateLabelHead("_oLblAskHPTC" & I, _nTaxCode)
                        Me.CreateLabelHead("_oLblAskHP" & I, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:15%'>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Me.CreateTextBoxHead("_oTxtAskHP" & I, _nAskValue)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlAllAskHeading.Controls.Add(_oLTtTable1)


                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()

        Catch ex As Exception

        End Try


    End Sub
    Private Sub DropDownAskInit()
        Try


            Dim I As Integer
            Dim askOptDesc As String
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
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPOPTION()
            _nClass._pSubGET_OPTION()
            _nAskhdg = ""
            _nQuery = "SELECT DISTINCT TAXCODE FROM [" & _nClass._pTempTbl & "]"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("TAXCODE").ToString


                        'Dim keys As List(Of String) = Request.Form.AllKeys.Where(Function(key) key.Contains("_oLblOpt")).ToList()
                        'Dim i As Integer = 1
                        'For Each key As String In keys
                        '    Me.CreateLabelDropDown("_oLblOpt" & i, _nAskhdg)
                        '    i += 1
                        'Next

                        'Dim keys1 As List(Of String) = Request.Form.AllKeys.Where(Function(key1) key1.Contains("_oSelectOpt")).ToList()
                        'Dim j As Integer = 1
                        'For Each key1 As String In keys1
                        '    Me.CreateSelect("_oSelectOpt" & j, _nAskhdg, j)
                        '    j += 1
                        'Next



                        I = I + 1

                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:50%'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------
                        If Left(_nAskhdg, 1) = "1" Or Left(_nAskhdg, 1) = "2" Then
                            askOptDesc = "Business Tax Option"
                        ElseIf Left(_nAskhdg, 1) = "3" Then
                            askOptDesc = "Garbage Option"
                        ElseIf Left(_nAskhdg, 1) = "4" Then
                            askOptDesc = "Mayors Permit Option"
                        ElseIf Left(_nAskhdg, 1) = "5" Then
                            askOptDesc = "Sanitary Option"
                        ElseIf Left(_nAskhdg, 1) = "6" Then
                            askOptDesc = "Fire Fee Option"
                        End If

                        Me.CreateLabelDropDown("_oLblOpt" & I, askOptDesc)
                        Me.CreateLabelDropDown2("_oLblOpt2" & I, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:50%'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Me.CreateSelect("_oSelectOpt" & I, _nAskhdg, I)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLTtTable1)

                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub TextAsk()
        Try
            'askquestion
            Dim I As Integer

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
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String
            Dim _nAskValue As String
            _nClass._pTempTbl = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPASKQTY()
            _nClass._pSubGET_ASKQTY()
            _nAskhdg = ""
            _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE xvalue is null"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("ASKHDG").ToString
                        _nTaxCode = _nSqlDr.Item("TAXCODE").ToString
                        _nAskValue = Format(_nSqlDr.Item("XVALUE").ToString, "Standard")

                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlTextAskQ.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlTextAskQ.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:90%'>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------

                        Dim index1 As Integer = _opnlTextAskQ.Controls.OfType(Of Label)().ToList().Count + 1
                        Me.CreateLabel("_oLblAskQTC" & index1, _nTaxCode)
                        Me.CreateLabel("_oLblAskQ" & index1, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:10%'>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Dim index As Integer = _opnlTextAskQ.Controls.OfType(Of TextBox)().ToList().Count + 1
                        Me.CreateTextBox("_oTxtAskQ" & index, _nAskValue)
                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlTextAskQ.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlTextAskQ.Controls.Add(_oLTtTable1)
                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextAskHead()
        Try


            'askheading
            Dim I As Integer
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
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String
            Dim _nAskValue As String
            _nClass._pTempTbl = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPASKHDG()
            _nClass._pSubGET_ASKHDG()
            _nAskhdg = ""
            ' _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "]"
            _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE xvalue is null"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("ASKHDG").ToString
                        _nAskValue = Format(_nSqlDr.Item("XVALUE").ToString, "Standard")
                        _nTaxCode = _nSqlDr.Item("TAXCODE").ToString
                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlAllAskHeading.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:85%'>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------

                        Dim index1 As Integer = _opnlAllAskHeading.Controls.OfType(Of Label)().ToList().Count + 1
                        Me.CreateLabelHead("_oLblAskHPTC" & index1, _nTaxCode)
                        Me.CreateLabelHead("_oLblAskHP" & index1, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:15%'>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Dim index As Integer = _opnlAllAskHeading.Controls.OfType(Of TextBox)().ToList().Count + 1
                        Me.CreateTextBoxHead("_oTxtAskHP" & index, _nAskValue)
                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlAllAskHeading.Controls.Add(_oLTtTable1)

                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()

        Catch ex As Exception

        End Try


    End Sub
    Private Sub DropDownAsk()
        Try


            Dim I As Integer
            Dim askOptDesc As String
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
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPOPTION()
            _nClass._pSubGET_OPTION()
            _nAskhdg = ""
            _nQuery = "SELECT DISTINCT TAXCODE FROM [" & _nClass._pTempTbl & "]"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("TAXCODE").ToString


                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:50%'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------

                        Dim index As Integer = _opnlDrpDownAskOpt.Controls.OfType(Of Label)().ToList().Count + 1

                        If Left(_nAskhdg, 1) = "1" Or Left(_nAskhdg, 1) = "2" Then
                            askOptDesc = "Business Tax Option"
                        ElseIf Left(_nAskhdg, 1) = "3" Then
                            askOptDesc = "Garbage Option"
                        ElseIf Left(_nAskhdg, 1) = "4" Then
                            askOptDesc = "Mayors Permit Option"
                        ElseIf Left(_nAskhdg, 1) = "5" Then
                            askOptDesc = "Sanitary Option"
                        ElseIf Left(_nAskhdg, 1) = "6" Then
                            askOptDesc = "Fire Fee Option"
                        End If


                        Me.CreateLabelDropDown("_oLblOpt" & index, askOptDesc)
                        Me.CreateLabelDropDown2("_oLblOpt2" & index, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:50%'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Dim index1 As Integer = _opnlDrpDownAskOpt.Controls.OfType(Of DropDownList)().ToList().Count + 1
                        Me.CreateSelect("_oSelectOpt" & index1, _nAskhdg, index1)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLTtTable1)

                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateLabel(id As String, txt As String)
        'askquestion
        Dim lbl = New Label()
        lbl.ID = id
        lbl.CssClass = "col"
        lbl.Text = txt
        _opnlTextAskQ.Controls.Add(lbl)
    End Sub

    Private Sub CreateLabelHead(id As String, txt As String)
        'askheading
        Dim lbl = New Label()
        lbl.ID = id
        lbl.CssClass = "col"
        lbl.Text = txt
        _opnlAllAskHeading.Controls.Add(lbl)
    End Sub



    Private Sub CreateTextBox(id As String, txtval As String)
        'askquestion
        Dim txt = New TextBox()
        txt.ID = id
        txt.Text = txtval
        txt.CssClass = "col-12"
        _opnlTextAskQ.Controls.Add(txt)

        Dim lt = New Literal()
        lt.Text = "<br />"
        _opnlTextAskQ.Controls.Add(lt)
    End Sub

    Private Sub CreateTextBoxHead(id As String, txtval As String)

        'askheading
        Dim txt = New TextBox()
        txt.ID = id
        txt.Text = txtval
        txt.CssClass = "col-12"
        txt.Attributes.Add("style", "font-size:11px;")
        _opnlAllAskHeading.Controls.Add(txt)

        Dim lt = New Literal()
        lt.Text = "<br />"
        _opnlAllAskHeading.Controls.Add(lt)
    End Sub
    Private Sub CreateTextBoxHead1(id As String, txtval As String)
        'askheading
        Dim txt = New TextBox()
        txt.ID = id
        txt.Text = txtval
        txt.Width = 50
        _opnlAllAskHeading.Controls.Add(txt)

        Dim lt = New Literal()
        lt.Text = "<br />"
        _opnlAllAskHeading.Controls.Add(lt)
    End Sub
    Private Sub CreateLabelDropDown(id As String, txt As String)
        Dim lbl = New Label()
        lbl.ID = id
        lbl.CssClass = "col"
        lbl.Text = txt
        lbl.Visible = True
        _opnlDrpDownAskOpt.Controls.Add(lbl)

    End Sub
    Private Sub CreateLabelDropDown2(id As String, txt As String)
        Dim lbl = New Label()
        lbl.ID = id
        lbl.CssClass = "col"
        lbl.Text = txt
        lbl.Visible = False
        _opnlDrpDownAskOpt.Controls.Add(lbl)

    End Sub
    Private Sub CreateSelect(id As String, xTaxCode As String, xindex As Integer)

        Dim index As Integer
        Dim j As Integer


        'For j = 1 To noOfItem

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
        _nClass._pMonth = _nClass._nCurMonth

        _nClass._pAcctNo = cSessionLoader._pAccountNo
        _nClass._pLocServer = _nClBP._pDBDataSource
        _nClass._pLocDB = _nClBP._pDBInitialCatalog
        _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pSubTotalGross()

        '----------------------------------

        Dim _nClass1 As New cDalBPSOS
        _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass1._pAcctNo = cSessionLoader._pAccountNo
        _nClass1._pSubSelectPrevGross()
        Dim _nSqlCommand As SqlCommand
        Dim _nQuery As String = Nothing
        Dim _nSqlDataReader As SqlDataReader
        Dim _nAskhdg As String
        Dim _nTaxCode As String

        _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pSubCREATE_TEMPOPTION()
        _nClass._pSubGET_OPTION()
        _nAskhdg = ""
        _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE TAXCODE = '" & xTaxCode & "' ORDER BY XSELECTED DESC"

        Dim listvalue As String
        ' Dim MyLI As New ListItem

        Dim MyDDL = New DropDownList()
        MyDDL.ID = id
        MyDDL.CssClass = "col-12"

        _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
        Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
            ''  _nSqlDr.Read()
            If _nSqlDr.HasRows Then
                'Getting Record using reader

                Do While _nSqlDr.Read

                    listvalue = _nSqlDr.Item("OPTHDG1").ToString
                    MyDDL.Items.Add(New ListItem(listvalue, listvalue))
                Loop
            End If

        End Using
        _nSqlCommand.Dispose()


        _opnlDrpDownAskOpt.Controls.Add(MyDDL)

        Dim MyLiteral = New LiteralControl
        MyLiteral.Text = "<BR>"
        _opnlDrpDownAskOpt.Controls.Add(MyLiteral)
    End Sub

    Private Sub _mSubGetGrValue()
        Dim index As Integer
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        _nClass._pTempTbl = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")


        For Each textBox As TextBox In _opnlAllAskHeading.Controls.OfType(Of TextBox)()

            index = index + 1
            Dim label As New Label
            Dim txtbox As New TextBox
            label = _opnlAllAskHeading.FindControl("_oLblAskHP" & index)
            '  txtbox = _opnlAllAskHeading.FindControl("_oTxtAskHP" & index)

            If textBox.ID = "_oTxtAskHP" & index Then
                _nClass._pASKHDG = label.Text
                _nClass._pXValue = textBox.Text
                _nClass._pSubGETVALUE_TEMPASKHDG()
            End If
        Next


        'For index = 0 To 100




        Dim index1 As Integer
        _nClass._pTempTbl = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")


        For Each textBox1 As TextBox In _opnlTextAskQ.Controls.OfType(Of TextBox)()

            index1 = index1 + 1
            Dim label1 As New Label
            label1 = _opnlTextAskQ.FindControl("_oLblAskQ" & index1)


            If textBox1.ID = "_oTxtAskQ" & index1 Then
                _nClass._pASKHDG = label1.Text
                _nClass._pXValue = textBox1.Text
                _nClass._pSubGETVALUE_TEMPASKHDG()
            End If
        Next


        Dim index2 As Integer
        _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

        For Each DropDown As DropDownList In _opnlDrpDownAskOpt.Controls.OfType(Of DropDownList)()

            index2 = index2 + 1
            Dim label2 As New Label
            label2 = _opnlDrpDownAskOpt.FindControl("_oLblOpt2" & index2)


            If DropDown.ID = "_oSelectOpt" & index2 Then
                _nClass._pASKHDG = DropDown.Text
                _nClass._pTaxCode = label2.Text
                _nClass._pSubGETVALUE_TEMPASKOPT()
            End If
        Next


    End Sub


    Sub Download_Selected_New(seqid, AcctNo)
        Try
            'Select Case seqid
            '    Case "001"
            '        If _oTxtGovernmentID.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then
            '            snackbar("red", "No Attached file")
            '            Exit Sub
            '        End If
            '    Case "002"
            '        If _oTxtSPA.Value Is Nothing Or String.IsNullOrEmpty(_oTxtSPA.Value) Then
            '            snackbar("red", "No Attached file")
            '            Exit Sub
            '        End If
            '    Case "003"
            '        If _oTxtBRSec.Value Is Nothing Or String.IsNullOrEmpty(_oTxtBRSec.Value) Then
            '            snackbar("red", "No Attached file")
            '            Exit Sub
            '        End If
            'End Select

            Dim _nclass As New cDalBPSOS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim filetype As String
            Dim bytes As Byte()
            Dim _nFileExtn As String
            Dim _mFilename As String
            _nQuery = "select * from BUSDETAIL_ATTACHMENTS_NEW where SEQID ='" & seqid & "' and ACCTNO ='" & AcctNo & "'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))
                    If _nFileExtn = "TEXT/PLAIN" Then
                        _nFileExtn = ".TXT"
                    End If
                    If _nFileExtn = "APPLICATION/PDF" Then
                        _nFileExtn = ".PDF"
                    End If
                    If _nFileExtn = "IMAGE/PNG" Then
                        _nFileExtn = ".PNG"
                    End If
                    If _nFileExtn = "IMAGE/JPEG" Then
                        _nFileExtn = ".JPG"
                    End If

                End If
                If _nFileExtn = ".PDF" Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()

                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Response.Clear()
                    Response.ContentType = "image/png"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Then
                    Response.Clear()
                    Response.ContentType = "image/jpeg"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub ClearFilesLabel()
        _oTxtFile1.Value = "No Attached File"
        _oTxtFile2.Value = "No Attached File"
        _oTxtFile3.Value = "No Attached File"
        _oTxtFile4.Value = "No Attached File"
        _oTxtFile5.Value = "No Attached File"
        _oTxtFile6.Value = "No Attached File"
        _oTxtFile7.Value = "No Attached File"
        _oTxtFile8.Value = "No Attached File"
        _oTxtFile9.Value = "No Attached File"
        _oTxtFile10.Value = "No Attached File"
        _oTxtFile11.Value = "No Attached File"
    End Sub

    '----------------- Added by Archie

    Private Sub View_Details()
        Try
            '----------------------------------

            ClearFilesLabel()

            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSubSelect("BUSDETAIL_ATTACHMENTS_NEW", "WHERE ACCTNO = '" & cSessionLoader._pAccountNo & "'")

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable
            If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
                For i As Integer = 0 To _nDataTable.Rows.Count - 1
                    Select Case _nDataTable.Rows(i)("SEQID").ToString()
                        Case "001" : _oTxtFile1.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "002" : _oTxtFile2.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "003" : _oTxtFile3.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "004" : _oTxtFile4.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "005" : _oTxtFile5.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "006" : _oTxtFile6.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "007" : _oTxtFile7.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "008" : _oTxtFile8.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "009" : _oTxtFile9.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "010" : _oTxtFile10.Value = _nDataTable.Rows(i)("FileName").ToString()
                        Case "011" : _oTxtFile11.Value = _nDataTable.Rows(i)("FileName").ToString()
                    End Select
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub

    Sub Download_Selected(acctno)
        Try
            Dim _nclass As New cDalBPSOS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim filetype As String
            Dim bytes As Byte()
            Dim _nFileExtn As String
            Dim _mFilename As String

            '----------------------------------    
            'If chie = True Then
            '    Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")

            'Else

            _nQuery = "select " & hdnData.Value & "," & hdnType.Value & "," & hdnName.Value & " from BUSDETAIL_ATTACHMENTS where acctno='" & acctno & "'"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.IsDBNull(0) Then View_Details() : snackbar("red", "No Attached file!") : Exit Sub
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))

                    If _nFileExtn = "TEXT/PLAIN" Then
                        _nFileExtn = ".TXT"
                    End If
                    If _nFileExtn = "APPLICATION/PDF" Then
                        _nFileExtn = ".PDF"
                    End If
                    If _nFileExtn = "IMAGE/PNG" Then
                        _nFileExtn = ".PNG"
                    End If
                    If _nFileExtn = "IMAGE/JPEG" Or _nFileExtn = "IMAGE/JPG" Then
                        _nFileExtn = ".JPG"
                    End If
                End If
                If _nFileExtn = ".PDF" Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()

                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Response.Clear()
                    Response.ContentType = "image/png"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Then
                    Response.Clear()
                    Response.ContentType = "image/jpeg"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using






            '_oLabel_FileName.Text = _nCls._pFileName & _nFileExtn.ToLower


        Catch ex As Exception

        End Try
    End Sub

    Sub Download_Selected_profile(seqid, userid)
        Try
            Select Case seqid
                Case "001"
                    If _oTxtGovernmentID.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then
                        snackbar("red", "No Attached file")
                        Exit Sub
                    End If
                Case "002"
                    If _oTxtSPA.Value Is Nothing Or String.IsNullOrEmpty(_oTxtSPA.Value) Then
                        snackbar("red", "No Attached file")
                        Exit Sub
                    End If
                Case "003"
                    If _oTxtBRSec.Value Is Nothing Or String.IsNullOrEmpty(_oTxtBRSec.Value) Then
                        snackbar("red", "No Attached file")
                        Exit Sub
                    End If
            End Select

            Dim _nclass As New cDalProfileLoader
            _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim filetype As String
            Dim bytes As Byte()
            Dim _nFileExtn As String
            Dim _mFilename As String
            _nQuery = "select * from attachment where SEQID ='" & seqid & "' and EMAIL ='" & userid & "'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_OAIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))
                    If _nFileExtn = "TEXT/PLAIN" Then
                        _nFileExtn = ".TXT"
                    End If
                    If _nFileExtn = "APPLICATION/PDF" Then
                        _nFileExtn = ".PDF"
                    End If
                    If _nFileExtn = "IMAGE/PNG" Then
                        _nFileExtn = ".PNG"
                    End If
                    If _nFileExtn = "IMAGE/JPEG" Then
                        _nFileExtn = ".JPG"
                    End If

                End If
                If _nFileExtn = ".PDF" Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()

                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Response.Clear()
                    Response.ContentType = "image/png"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Then
                    Response.Clear()
                    Response.ContentType = "image/jpeg"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetTypeWOwnCode()

        Dim _nClass As New cDalBPSOS
        Dim myOutPut As String

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
        _nClBP._pSubRecordSelectSpecific()

        '----------------------------------
        'Specify Blank to Select Nothing but Column Names
        _nClass._pAcctNo = cSessionLoader._pAccountNo
        _nClass._pLocServer = _nClBP._pDBDataSource
        _nClass._pLocDB = _nClBP._pDBInitialCatalog
        '----------------------------------

        _nClass._pSubGETOWNCODE()
        myOutPut = UCase(_nClass._nOutput)

        _oLblBusOwnership.Text = myOutPut

        Select Case myOutPut
            Case "COOPERATIVE"
                _oLblTypeTitle.InnerHtml = " For Coopertive"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile7.Visible = Not _oPnFile7.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnView4.Visible = Not _oPnView4.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible
                _oPnView7.Visible = Not _oPnView7.Visible
                _oPnView9.Visible = Not _oPnView9.Visible
                _oPnView10.Visible = Not _oPnView10.Visible
                '_oPnView11.Visible = Not _oPnView11.Visible
            Case "CORPORATION"
                _oLblTypeTitle.InnerHtml = " For Corporation"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile7.Visible = Not _oPnFile7.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnView4.Visible = Not _oPnView4.Visible
                _oPnView9.Visible = Not _oPnView9.Visible
                _oPnView10.Visible = Not _oPnView10.Visible
                '_oPnView11.Visible = Not _oPnView11.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible
                _oPnView7.Visible = Not _oPnView7.Visible

            Case "AMUSEMENT"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible
            Case "FOREIGN"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible
            Case "PARTNERSHIP"
                _oLblTypeTitle.InnerHtml = " For Partnership"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnFile8.Visible = Not _oPnFile8.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible
                _oPnView8.Visible = Not _oPnView8.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                _oPnView4.Visible = Not _oPnView4.Visible
                _oPnView9.Visible = Not _oPnView9.Visible
                _oPnView10.Visible = Not _oPnView10.Visible
                ' _oPnView11.Visible = Not _oPnView11.Visible
            Case "SINGLE"
                _oLblTypeTitle.InnerHtml = " For Single Proprietorship"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile5.Visible = Not _oPnFile5.Visible
                _oPnFile6.Visible = Not _oPnFile6.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible
                _oPnView5.Visible = Not _oPnView5.Visible
                _oPnView6.Visible = Not _oPnView6.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnView4.Visible = Not _oPnView4.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                _oPnView9.Visible = Not _oPnView9.Visible
                _oPnView10.Visible = Not _oPnView10.Visible
                '_oPnView11.Visible = Not _oPnView11.Visible
            Case "SINGLE PROPRIETORSHIP"
                _oLblTypeTitle.InnerHtml = " For Single Proprietorship"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile5.Visible = Not _oPnFile5.Visible
                _oPnFile6.Visible = Not _oPnFile6.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible
                _oPnView5.Visible = Not _oPnView5.Visible
                _oPnView6.Visible = Not _oPnView6.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnView4.Visible = Not _oPnView4.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                _oPnView9.Visible = Not _oPnView9.Visible
                _oPnView10.Visible = Not _oPnView10.Visible
                '_oPnView11.Visible = Not _oPnView11.Visible

            Case "FOUNDATION"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible

            Case "ASSOCIATION"

                _oLblTypeTitle.InnerHtml = " For Association"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile7.Visible = Not _oPnFile7.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnView4.Visible = Not _oPnView4.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                _oPnView1.Visible = Not _oPnView1.Visible
                _oPnView2.Visible = Not _oPnView2.Visible
                _oPnView3.Visible = Not _oPnView3.Visible
                _oPnView7.Visible = Not _oPnView7.Visible
                _oPnView9.Visible = Not _oPnView9.Visible
                _oPnView10.Visible = Not _oPnView10.Visible
                '_oPnView11.Visible = Not _oPnView11.Visible

        End Select

    End Sub


    Private Sub btnApprove_ServerClick(sender As Object, e As EventArgs) Handles btnApprove.ServerClick
        _mSubApprovePayment()
    End Sub

 

    Private Sub _obtnSubmit_ServerClick(sender As Object, e As EventArgs) Handles _obtnSubmit.ServerClick
        Dim _nTPEmail As String
        Dim _nClass As New cDalBPSOS

        _nClass._pSubGetCurYear()
        _nClass._pForYear = _nClass._nCurYear
        _nClass._pAcctNo = cSessionLoader._pAccountNo

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubDECLINEAPPLICATION()
        _nClass._pSubResetStatus(cSessionLoader._pAccountNo)
        _nClass._pSubTPEmail()
        _nTPEmail = _nClass._nOutput

        Dim Sent As Boolean
        Dim Subject As String
        Dim header As String
        Dim Body As String
        Dim footer As String

        Subject = txt_Subject.Value
        header = txt_Header.Value
        Body = "To our Valued Taxpayer, <br>" & _
                "Account Number : " & cSessionLoader._pAccountNo & _
                "<br>Business Name  : " & _oLblBusName.Text & _
                "<br>" & header & "<br>" & _
                txt_Body.Value

        cDalNewSendEmail.SendEmail(_nTPEmail, Subject, Body, Sent)
        If Sent = True Then
            Response.Write("<script>alert('Email notification has been sent to tax payer')</script>")

        Else
            Response.Write("<script>alert('Failed to send email notification to tax payer')</script>")
        End If
    End Sub
End Class