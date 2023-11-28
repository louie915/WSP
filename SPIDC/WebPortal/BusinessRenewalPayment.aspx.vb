Imports System.Data.SqlClient

Public Class BusinessRenewalPayment
    Inherits System.Web.UI.Page

    Dim usertmp As String
    Dim xTotalDue As Double
    Dim nTempGross As String
    Dim nHasPayment As Boolean = False
    Dim nFullyPaid As Boolean = False
    Dim nLQP As Integer
    Dim _nIsNewBusiness As String
    Dim nLGUName As String
    Dim radqtr As Integer = 0

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nQtrPay As String
        Dim _nSelectedQtr As Integer
        Dim _nGetTempApplTbl As Boolean
        Dim _nClGenPaymentBusline As New CDalGenPaymentBusline
        cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

        _err.Value = " | 01 : OK" '& cGlobalConnections._pSqlCxn_CR.ConnectionString
        _err.Value += " | 02 : Ok" ' & cGlobalConnections._pSqlCxn_BPLTAS.ConnectionString
        _err.Value += " | 03 : OK" ' & cGlobalConnections._pSqlCxn_BPLTIMS.ConnectionString

        Dim _nClassX As New cDalNewBP
        _nClassX._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        Try
            If _nClassX._pSubPaidandPosted(cSessionLoader._pAccountNo) = True Then
                btnPayment.Style.Add("display", "none")
                btn_TOP.Style.Add("display", "none")
                div_BillingInfo.Style.Add("display", "none")
                div_PaymentExpired.Style.Add("display", "none")
                div_PaidandPosted.Style.Add("display", "block")
            Else
                If _nClassX._pSubExpired(cSessionLoader._pAccountNo) = True Then
                    'notice expired
                    btnPayment.Style.Add("display", "none")
                    div_BillingInfo.Style.Add("display", "none")
                    div_PaymentExpired.Style.Add("display", "block")
                    div_PaidandPosted.Style.Add("display", "none")
                Else
                    div_BillingInfo.Style.Add("display", "block")
                    div_PaidandPosted.Style.Add("display", "none")
                    div_PaymentExpired.Style.Add("display", "none")
                    ' _nClassX._pSubGetPeriodCovered(cSessionLoader._pAccountNo, cSessionLoader._pPeriodCovered, cSessionLoader._pPayMode, cSessionLoader._pFORYEAR)
                    loadGrid_TOP(cSessionLoader._pAccountNo, 0)

                    Dim _nClass As New cDalBPSOS
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
                    _nClass._getModeP(cSessionLoader._pAccountNo)

                    lbl_Paymode.Text = cSessionLoader._pPayMode
                    lbl_Foryear.Text = cSessionLoader._pFORYEAR
                    lbl_PeriodCovered.Text = cSessionLoader._pPeriodCovered

                End If
            End If
            _err.Value += " | 04 : OK"
        Catch ex As Exception
            _err.Value += " | 04 : " & ex.Message
        End Try
      
        Try
            Dim _nClassY As New cDalBPSOS
            _nClassY._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClassY._pSubGetDetail()
            _oLblBusID.Text = cSessionLoader._pAccountNo
            _oLblBusOwner.Text = _nClassY._nOwner
            _oLblBusName.Text = _nClassY._nBusName
            _oLblBusAddress.Text = _nClassY._nBusAddress
            _oLblBusCategory.Text = _nClassY._nBusCategory
            _oLblBusCategory1.Text = _nClassY._nBusCategory1

            _nClassY._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClassY._pAcctNo = cSessionLoader._pAccountNo
            _nClassY._pForYear = cSessionLoader._pFORYEAR
            _nClassY._pSubShowBusDetailExtn_PAYMENT()
            _GVBusinessLine.DataSource = _nClassY._mDataTable
            _GVBusinessLine.DataBind()
            _err.Value += " | 05 : OK"
        Catch ex As Exception
            _err.Value += " | 05 : " & ex.Message
        End Try
       

        'Exit Sub

     
        If Not Me.IsPostBack Then
            Try
                Try
                    If cSessionUser._pUserID = Nothing Then
                        Response.Redirect("Register.aspx")
                        Exit Sub
                    End If
                    usertmp = cSessionUser._pUserID.Replace(".", "")
                    Dim tst As String
                    Try
                        cSessionLGUProfile._pGetLGUProfile(tst)
                        _err.Value += " | 05.0 : " & tst
                    Catch ex As Exception
                        _err.Value += " | 05.0 : " & ex.Message
                    End Try

                    nLGUName = cSessionLGUProfile._pLGU_Header2
                    _err.Value += " | 05.1 : OK"
                Catch ex As Exception
                    _err.Value += " | 05.1 : " & ex.Message
                End Try

                Try
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
                    _err.Value += " | 05.2 : OK"
                Catch ex As Exception
                    _err.Value += " | 05.2 : " & ex.Message
                End Try

                Try
                    If cSessionLoader._pPeriodCovered.Length > 0 Then
                        Select Case cSessionLoader._pPeriodCovered.Substring(2)(0)
                            Case "1"
                                _oRadio1stQ.Checked = True
                                cSessionLoader._pBPQTR = 1
                            Case "2"
                                _oRadio2ndQ.Checked = True
                                cSessionLoader._pBPQTR = 2
                            Case "3"
                                _oRadio3rdQ.Checked = True
                                cSessionLoader._pBPQTR = 3
                            Case "4"
                                _oRadio4thQ.Checked = True
                                cSessionLoader._pBPQTR = 4
                        End Select
                        _err.Value += " | 05.3 : OK"
                    Else
                        _err.Value += " | 05.3 : OK " & cSessionLoader._pPeriodCovered.Length
                    End If
                  
                Catch ex As Exception
                    _err.Value += " | 05.3 : " & ex.Message
                End Try

                _err.Value += " | 05.5 : OK"
            Catch ex As Exception
                _err.Value += " | 05.5 : " & ex.Message
            End Try



            Try
                '=============
                'TextAskHead()
                'TextAsk()
                'DropDownAsk()
                '===============
                'cSessionLoader._pAccountNo pang call ng naselect na account no.
                Dim _nClass1 As New cDalBPSOS
                _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
                _nClass1._pAcctNo = cSessionLoader._pAccountNo
                _nClass1._mShareAcctNo = cSessionLoader._pAccountNo
                '_nClass1._pSubSelectPrevGross()
                '_oTxtPreviousGross.Value = Format(_nClass1._nPrevGross, "###,###,##0.00")
                '_oTxtBusLine.Value = _nClass1._nBusDesc

                Dim _nClBP1 As New cDalGlobalConnectionsDefault
                _nClBP1._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP1._pSetupGlobalConnectionsDatabases = "BPLTAS"
                Try
                    _nClBP1._pSubRecordSelectSpecific()
                    _err.Value += " | 06 : OK"
                Catch ex As Exception
                    _err.Value += " | 06 : " & ex.Message
                End Try


                Dim _nClass2 As New cDalBPSOS
                _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nClass2._pAcctNo = cSessionLoader._pAccountNo
                _nClass2._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
                _nClass2._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
                _nClass2._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
                _nClass2._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

                _nClass2._pLocServer = _nClBP1._pDBDataSource
                _nClass2._pLocDB = _nClBP1._pDBInitialCatalog
                _nClass2._pSubGetCurYear()
                _nClass2._pForYear = _nClass2._nCurYear
                '  _nClass2._pForYear = _radYear.Value
                Try
                    _mSubCheckIfNewBusiness()
                    _err.Value += " | 07 : OK"
                Catch ex As Exception
                    _err.Value += " | 07 : " & ex.Message
                End Try

                Try
                    If _nIsNewBusiness = "1" Then
                        _nClass2._pSubGetDetailNewBusiness()
                    Else
                        _nClass2._pSubGetDetail()
                        cSessionLoader._pBPQTR = _nClass2._pMOP
                    End If
                    _err.Value += " | 08 : OK"
                Catch ex As Exception
                    _err.Value += " | 08 : " & ex.Message
                End Try

              


                _oLblBusID.Text = cSessionLoader._pAccountNo
                _oLblBusOwner.Text = _nClass2._nOwner
                _oLblBusName.Text = _nClass2._nBusName
                _oLblBusAddress.Text = _nClass2._nBusAddress
                _oLblBusCategory.Text = _nClass2._nBusCategory
                _oLblBusCategory1.Text = _nClass2._nBusCategory1
                'for new business 

                '_nClass2._pSubCheckNewBusiness()
                '_nIsNewBusiness = _nClass2._nOutput


                If _nIsNewBusiness = "1" Then
                    _nClass2._pSubGetNewBusiness()
                    _nQtrPay = _nClass2._nOutput
                    GoTo displayna
                End If


                Try
                    _nClass2._pSubCheckPayment()
                    _err.Value += " | 09 : OK"
                Catch ex As Exception
                    _err.Value += " | 09 : " & ex.Message
                End Try

                _nQtrPay = _nClass2._nOutput

           



            Try
                _mSubCheckifHasPayment()
                    _err.Value += " | 10 : OK"
            Catch ex As Exception
                    _err.Value += " | 10 : " & ex.Message
            End Try



                Try
                    If _nQtrPay = 4 Then
                        'MsgBox("Account already enrolled!")
                        snackbar("red", "Account already paid!.")
                        btnPayment.Disabled = True
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = False
                        _oRadio4thQ.Enabled = False
                        _mDisplayApplBusinessPermit()
                        Exit Sub
                    End If
                    _err.Value += " | 11 : OK"
                Catch ex As Exception
                    _err.Value += " | 11 : " & ex.Message
                End Try




            If nHasPayment = True Then 'has payment in BP local
                _nQtrPay = nLQP

displayna:

                If _nIsNewBusiness = "1" Then
                    If _nQtrPay = 0 Then
                        _oRadio1stQ.Enabled = True
                        _oRadio2ndQ.Enabled = True
                        _oRadio3rdQ.Enabled = True
                        _oRadio4thQ.Enabled = True
                        _oRadio4thQ.Checked = True
                        _nSelectedQtr = 4
                    ElseIf _nQtrPay = 1 Then
                        _oRadio1stQ.Enabled = True
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = False
                        _oRadio4thQ.Enabled = False
                        _oRadio1stQ.Checked = True
                        _nSelectedQtr = 1
                    ElseIf _nQtrPay = 2 Then
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = True
                        _oRadio3rdQ.Enabled = False
                        _oRadio4thQ.Enabled = False
                        _oRadio2ndQ.Checked = True
                        _nSelectedQtr = 2
                    ElseIf _nQtrPay = 3 Then
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = True
                        _oRadio4thQ.Enabled = False
                        _oRadio3rdQ.Checked = True
                        _nSelectedQtr = 3
                    Else
                        _oRadio1stQ.Enabled = False
                        _oRadio2ndQ.Enabled = False
                        _oRadio3rdQ.Enabled = False
                        _oRadio4thQ.Enabled = True
                        _oRadio4thQ.Checked = True
                        _nSelectedQtr = 4
                    End If

                    'Else

                    '    If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
                    '        If _nQtrPay = 0 Then
                    '            _oRadio1stQ.Enabled = True
                    '            _oRadio2ndQ.Enabled = True
                    '            _oRadio3rdQ.Enabled = True
                    '            _oRadio4thQ.Enabled = True
                    '        ElseIf _nQtrPay = 1 Then
                    '            _oRadio1stQ.Enabled = False
                    '            _oRadio2ndQ.Enabled = True
                    '            _oRadio3rdQ.Enabled = True
                    '            _oRadio4thQ.Enabled = True
                    '        ElseIf _nQtrPay = 2 Then
                    '            _oRadio1stQ.Enabled = False
                    '            _oRadio2ndQ.Enabled = False
                    '            _oRadio3rdQ.Enabled = True
                    '            _oRadio4thQ.Enabled = True
                    '        ElseIf _nQtrPay = 3 Then
                    '            _oRadio1stQ.Enabled = False
                    '            _oRadio2ndQ.Enabled = False
                    '            _oRadio3rdQ.Enabled = False
                    '            _oRadio4thQ.Enabled = True
                    '        Else
                    '            _oRadio1stQ.Enabled = False
                    '            _oRadio2ndQ.Enabled = False
                    '            _oRadio3rdQ.Enabled = False
                    '            _oRadio4thQ.Enabled = False
                    '        End If
                    '    End If
                    '    _nSelectedQtr = 4
                    '    _oRadio4thQ.Checked = True
                End If

                'If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
                '    _radYear.Disabled = True
                '    _oRadio1stQ.Enabled = False
                '    _oRadio2ndQ.Enabled = False
                '    _oRadio3rdQ.Enabled = False
                '    _oRadio4thQ.Enabled = False
                'End If



                ' _nClass2._pSubShowBusDetailExtn()
                _nClass2._pQtrPaid = _nQtrPay
                _nClass2._pQtr = _nSelectedQtr

                    ''  _nClass2._pSubGetPenalty()
                    Try
                        If _nIsNewBusiness <> "1" Then
                            _nClass2._pSubGetPenalty()
                            _nClass2._pSubGetPenalty_PrevYr()
                        End If
                        _err.Value += " | 12 : OK"
                    Catch ex As Exception
                        _err.Value += " | 12 : " & ex.Message
                    End Try


                    Try
                        _nClass2._pSubShowBusDetailExtn_PAYMENT()
                        _GVBusinessLine.DataSource = _nClass2._mDataTable
                        _GVBusinessLine.DataBind()
                        _err.Value += " | 13 : OK"
                    Catch ex As Exception
                        _err.Value += " | 13 : " & ex.Message
                    End Try


                    Try
                        If _nIsNewBusiness = "1" And nHasPayment = False Then
                            _mSubDisplayQtrPayment(_nSelectedQtr)
                        Else
                            _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)
                        End If
                        _nClass2._pSubGetTotalDue()
                        _oLabelTotalAmountDue.Text = Format(_nClass2._nTotalDue, "###,###,##0.00")

                        _err.Value += " | 14 : OK"
                    Catch ex As Exception
                        _err.Value += " | 14 : " & ex.Message
                    End Try



            Else




                If _nQtrPay = 0 Then
                    ''for Ask hdg,qty,opt
                    ''   _mSubGETGR()



                    '==========================


                    '_oRadio4thQ.Checked = True
                    '_nClass1._pQtr = "4"
                    '_nSelectedQtr = 4

                    ' _nClass2._pSubShowBusDetailExtn()
                    '_nClass2._pSubShowBusDetailExtn_PAYMENT()
                    '_GVBusinessLine.DataSource = _nClass2._mDataTable
                    '_GVBusinessLine.DataBind()
                        Try
                            _nClass2._pQtrPaid = _nQtrPay
                            _nClass2._pQtr = _nSelectedQtr
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                            If _nIsNewBusiness <> "1" Then
                                _nClass2._pSubGetPenalty()
                                _nClass2._pSubGetPenalty_PrevYr()
                            End If
                            _nClass2._pSubShowBusDetailExtn_PAYMENT()
                            _GVBusinessLine.DataSource = _nClass2._mDataTable
                            _GVBusinessLine.DataBind()


                            _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)
                            _nClass2._pSubGetTotalDue()
                            _oLabelTotalAmountDue.Text = Format(_nClass2._nTotalDue, "###,###,##0.00")

                            _err.Value += " | 15 : OK"
                        Catch ex As Exception
                            _err.Value += " | 15 : " & ex.Message
                        End Try

                    Else
                        Try
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
                                '_radYear.Disabled = True
                                '_oRadio1stQ.Enabled = False
                                '_oRadio2ndQ.Enabled = False
                                '_oRadio3rdQ.Enabled = False
                                '_oRadio4thQ.Enabled = False
                            End If
                            _nClass1._pQtr = "4"

                            _nSelectedQtr = 4
                            ' _nClass2._pSubPaymentGross()
                            _nClass2._pQtrPaid = _nQtrPay
                            _nClass2._pQtr = _nSelectedQtr
                            If _nIsNewBusiness <> "1" Then
                                _nClass2._pSubGetPenalty()
                                _nClass2._pSubGetPenalty_PrevYr()
                            End If
                            _nClass2._pSubShowBusDetailExtn_PAYMENT()
                            _GVBusinessLine.DataSource = _nClass2._mDataTable
                            _GVBusinessLine.DataBind()

                            _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)

                            _nClass2._pSubGetTotalDue()

                            _oLabelTotalAmountDue.Text = Format(_nClass2._nTotalDue, "###,###,##0.00")
                            _err.Value += " | 16 : OK"
                        Catch ex As Exception
                            _err.Value += " | 16 : " & ex.Message
                        End Try


                End If
                _mDisplayApplBusinessPermit() : _nGetTempApplTbl = True ''----------------MCE
                End If

                _err.Value += " | 00 : OK"
            Catch ex As Exception
                _err.Value += " | 00 : " & ex.Message
            End Try

            Try
                If _nGetTempApplTbl = False Then _mDisplayApplBusinessPermit()
                _err.Value += " | 17 : OK"
            Catch ex As Exception
                _err.Value += " | 17 : " & ex.Message
            End Try



        Else

            'cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

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

            'If action = "QuarterClick" Then
            '    If _oTxtEnterGross.Value <> "" Then
            '        _mSubDisplayQtrPayment(val)
            '    End If
            'End If
            'If Trim(nTempGross) = "" Then
            '    snackbar("red", "Please input Gross Amount!")
            '    Exit Sub
            'End If

            '===============
            'TextAskHeadInit()
            'TextAskInit()
            'DropDownAskInit()
            '=================
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            '_nClass._pForYear = _radYear.Value
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo

            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog

            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

            Try
                _nClass._pSubCheckPayment()
                _nQtrPay = _nClass._nOutput
                _err.Value += " | 18 : OK"
            Catch ex As Exception
                _err.Value += " | 18 : " & ex.Message
            End Try

            Try
                _mSubCheckifHasPayment()
                _err.Value += " | 19 : OK"
            Catch ex As Exception
                _err.Value += " | 19 : " & ex.Message
            End Try

            Try
                _mSubCheckIfNewBusiness()
                _err.Value += " | 20 : OK"
            Catch ex As Exception
                _err.Value += " | 20 : " & ex.Message

            End Try


            If _oRadioPickup.Checked = True Then

                _nClass._pDeliver = 1
                _nClass._pSubDelFee()
            Else
                _nClass._pDeliver = 0
                _nClass._pSubDelFee()

            End If

            Try
                If nHasPayment = True Then 'has payment in BP local
                    _nQtrPay = nLQP
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

                        '_radYear.Disabled = True
                        '_oRadio1stQ.Enabled = False
                        '_oRadio2ndQ.Enabled = False
                        '_oRadio3rdQ.Enabled = False
                        '_oRadio4thQ.Enabled = False
                    End If
                    If _oRadio1stQ.Checked = True Then
                        _nSelectedQtr = 1
                        _nClGenPaymentBusline._pQtr = _nSelectedQtr
                    ElseIf _oRadio2ndQ.Checked = True Then
                        _nSelectedQtr = 2
                        _nClGenPaymentBusline._pQtr = _nSelectedQtr
                    ElseIf _oRadio3rdQ.Checked = True Then
                        _nSelectedQtr = 3
                        _nClGenPaymentBusline._pQtr = _nSelectedQtr
                    Else
                        _nSelectedQtr = 4
                        _nClGenPaymentBusline._pQtr = _nSelectedQtr
                    End If

                    _nClass._pQtrPaid = _nQtrPay
                    _nClass._pQtr = _nSelectedQtr
                    If _nIsNewBusiness <> "1" Then
                        _nClass._pSubGetPenalty()
                        _nClass._pSubGetPenalty_PrevYr()
                    End If
                    _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)

                Else
                    If _nQtrPay = 0 Then
                        If _oRadio1stQ.Checked = True Then
                            '_mSubDisplayQtrPayment(1)
                            _nSelectedQtr = 1
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                        ElseIf _oRadio2ndQ.Checked = True Then
                            ' _mSubDisplayQtrPayment(2)
                            _nSelectedQtr = 2
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                        ElseIf _oRadio3rdQ.Checked = True Then
                            ' _mSubDisplayQtrPayment(3)
                            _nSelectedQtr = 3
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                        Else
                            '  _mSubDisplayQtrPayment(4)
                            _nSelectedQtr = 4
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                        End If

                        _nClass._pQtrPaid = _nQtrPay
                        _nClass._pQtr = _nSelectedQtr
                        If _nIsNewBusiness <> "1" Then
                            _nClass._pSubGetPenalty()
                            _nClass._pSubGetPenalty_PrevYr()
                        End If

                        _mSubDisplayQtrPayment(_nSelectedQtr)
                        _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
                        ' _nClass._pSubShowBusDetailExtn2()
                        _nClass._pSubShowBusDetailExtn_PAYMENT()
                        _GVBusinessLine.DataSource = _nClass._mDataTable
                        _GVBusinessLine.DataBind()


                    Else
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

                            '_radYear.Disabled = True
                            '_oRadio1stQ.Enabled = False
                            '_oRadio2ndQ.Enabled = False
                            '_oRadio3rdQ.Enabled = False
                            '_oRadio4thQ.Enabled = False
                        End If
                        If _oRadio1stQ.Checked = True Then
                            '_mSubDisplayQtrPayment(1)
                            _nSelectedQtr = 1
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                        ElseIf _oRadio2ndQ.Checked = True Then
                            ' _mSubDisplayQtrPayment(2)
                            _nSelectedQtr = 2
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                        ElseIf _oRadio3rdQ.Checked = True Then
                            ' _mSubDisplayQtrPayment(3)
                            _nSelectedQtr = 3
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                        Else
                            '  _mSubDisplayQtrPayment(4)
                            _nSelectedQtr = 4
                            _nClGenPaymentBusline._pQtr = _nSelectedQtr
                        End If

                        _nClass._pQtrPaid = _nQtrPay
                        _nClass._pQtr = _nSelectedQtr
                        If _nIsNewBusiness <> "1" Then
                            _nClass._pSubGetPenalty()
                            _nClass._pSubGetPenalty_PrevYr()
                        End If
                        _mSubDisplayQtrPaymentPaid(_nSelectedQtr, _nQtrPay)

                    End If
                End If
                _err.Value += " | 21 : OK"
            Catch ex As Exception
                _err.Value += " | 21 : " & ex.Message
            End Try
            Try
                _nClass._pSubGetTotalDue()
                _oLabelTotalAmountDue.Text = Format(_nClass._nTotalDue, "###,###,##0.00")
                _err.Value += " | 22 : OK"
            Catch ex As Exception
                _err.Value += " | 22 : " & ex.Message
            End Try




        End If
    End Sub

   

    Private Sub btnPayment_ServerClick(sender As Object, e As EventArgs) Handles btnPayment.ServerClick
        Dim acctno As String = cSessionLoader._pAccountNo
        Dim Sum_TotAmtDue As Double
        Dim Sum_TotPenDue As Double
        Dim Sum_TotTaxDue As Double
        Dim Sum_TotETC As Double
        Dim CTC_AMOUNT As Double
        Dim CTC_REMARK As String
        Dim _GrandTotal As String
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubSelectTOP(acctno, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, cSessionLoader._pBPQTR)
        _nClass._pSubGetCTC(acctno, CTC_AMOUNT, CTC_REMARK)
        cSessionLoader._pType = "Business Permit Renewal" 'unique
        cSessionLoader._pService = "BP" 'CTC       

        Dim _nclassX As New cDalGetModules
        _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        If _nclassX._pSubGetAvailableModules("IncludeCTC") <> True Then
            CTC_AMOUNT = 0
        End If

        _GrandTotal = CTC_AMOUNT + Sum_TotAmtDue
        cSessionLoader._pTotalAmountDue = Format(_GrandTotal.ToString, "STANDARD")
        _nClass._pSubGetPeriodCovered(acctno, cSessionLoader._pPeriodCovered, cSessionLoader._pPayMode, cSessionLoader._pFORYEAR)


        Response.Redirect("PayNow.aspx")




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



            ' _nClass_ApplBP._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            '  _nClass_ApplBP._GetApplBusinessPermitDetail()


        Catch ex As Exception

        End Try
    End Sub
    Private Sub _obtnPrintApplication_ServerClick(sender As Object, e As EventArgs) Handles _obtnPrintApplication.ServerClick
        Try
            '' Display report in New Tab
            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=APPFORM" + "&ACCTNO=" + cSessionLoader._pAccountNo + "&STATCODE=R&TYPE=PAYMENT','_blank');</script>")
            '' Display report in Current Tab
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_ServerClick(sender As Object, e As EventArgs) 'Handles Button2.ServerClick
        Try


            'ClassPageSession_pBilling._pTotalAmountDue = _oLabelTotalAmountDue.Text
            'Response.Redirect("PayNow.aspx")
            Dim SELECTEDQTR As String
            Dim _nQtrPay As String
            Dim _nPeriod As String
            Dim _nPaymode As String

            cSessionLoader._pTotalAmountDue = _oLabelTotalAmountDue.Text
            cSessionLoader._pType = "Business Permit Renewal"

            If _oRadio1stQ.Checked = True Then
                SELECTEDQTR = "1"
            ElseIf _oRadio2ndQ.Checked = True Then
                SELECTEDQTR = "2"
            ElseIf _oRadio3rdQ.Checked = True Then
                SELECTEDQTR = "3"
            Else
                SELECTEDQTR = "4"

            End If
            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            '_nClass._pForYear = _radYear.Value
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSubCheckPayment()
            _nQtrPay = _nClass._nOutput
            If _nQtrPay = 0 Then _nQtrPay = 1


            _nPeriod = _nQtrPay & "-" & SELECTEDQTR
            If _nPeriod = "1-2" Or _nPeriod = "3-4" Then
                _nPaymode = "S"
                GoTo nxtna
            Else
                _nPaymode = "Q"
            End If
            If _nPeriod = "1-4" Then
                _nPaymode = "A"
                GoTo nxtna
            Else
                _nPaymode = "Q"
            End If




nxtna:
            cSessionLoader._pPeriodCovered = _nPeriod & " Qtr"
            cSessionLoader._pPayMode = _nPaymode
            cSessionLoader._pFORYEAR = _nClass._nCurYear
            cSessionLoader._pBPQTR = SELECTEDQTR
            cSessionLoader._pService = "BP"



            Response.Redirect("PayNow.aspx")



        Catch ex As Exception

        End Try
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


            ' _nClass._pForYear = _radYear.Value
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
            ' _nClass._pForYear = _radYear.Value
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            '  _nClass._pQtr 
            _nClass._pSubSelectPaymentPerQtr()


            _nClass._pSubDELINQUENT_NYP()
            _nClass._pSubDELINQUENT_NYP_PREVYR()
            _nClass._pSubGetDelinquent()
            _nClass._pSubSelectRecordPayment()
            '  If InStr(1, UCase(nLGUName), "CALOOCAN") > 0 Then
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

    Private Sub _mSubCheckIfNewBusiness()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS


            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            '  _nClass._pForYear = _radYear.Value
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            '  _nClass._pQtr 
            _nIsNewBusiness = "0"
            _nClass._pSubCheckNewBusiness()
            _nIsNewBusiness = _nClass._nOutput

        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Private Sub _obtnPrintStatement_ServerClick(sender As Object, e As EventArgs) 'Handles _obtnPrintStatement.ServerClick
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


            _mSubCheckIfNewBusiness()

            If _nIsNewBusiness = "1" Then
                Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=BPSA_NB" + "&AccountNo=" + cSessionLoader._pAccountNo + "&Qtr=" + _nQtr + "','_blank');</script>")
            Else
                Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=BPSA" + "&AccountNo=" + cSessionLoader._pAccountNo + "&Qtr=" + _nQtr + "','_blank');</script>")
            End If
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
            ' _nClass._pForYear = _radYear.Value
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
                btnPayment.Disabled = True
                'nHasPayment = True
                'nLQP = myOutPut
            ElseIf myOutPut = 0 Then 'marion 20200727
                nHasPayment = False
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
                        _nTaxCode = _nSqlDr.Item("TAXCODE").ToString
                        _nAskValue = Format(_nSqlDr.Item("XVALUE").ToString, "Standard")
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
                        _nTaxCode = _nSqlDr.Item("TAXCODE").ToString
                        _nAskValue = _nSqlDr.Item("XVALUE").ToString
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

    Public Sub loadGrid_TOP(ByVal acctno As String, ByVal Selected_QTR As Integer)
        Try
            Dim Sum_TotAmtDue As Double
            Dim Sum_TotPenDue As Double
            Dim Sum_TotTaxDue As Double
            Dim Sum_TotETC As Double
            Dim CTC_AMOUNT As Double
            Dim CTC_REMARK As String
            Dim _GrandTotal As Double
            Dim _nClass2 As New cDalNewBP

            If IsPostBack = True Then
            Else
                'If cSessionLoader._pPeriodCovered.Substring(2, 1) = 1 Then
                '    _oRadio1stQ.Checked = True
                'ElseIf cSessionLoader._pPeriodCovered.Substring(2, 1) = 2 Then
                '    _oRadio2ndQ.Checked = True
                'ElseIf cSessionLoader._pPeriodCovered.Substring(2, 1) = 3 Then
                '    _oRadio3rdQ.Checked = True
                'ElseIf cSessionLoader._pPeriodCovered.Substring(2, 1) = 4 Then
                '    _oRadio4thQ.Checked = True
                'Else
                '    If cSessionLoader._pPeriodCovered.Substring(2, 1) = "Q" Then
                '        If cSessionLoader._pPeriodCovered.Substring(0, 1) = 1 Then
                '            _oRadio1stQ.Checked = True
                '        ElseIf cSessionLoader._pPeriodCovered.Substring(0, 1) = 2 Then
                '            _oRadio2ndQ.Checked = True
                '        ElseIf cSessionLoader._pPeriodCovered.Substring(0, 1) = 3 Then
                '            _oRadio3rdQ.Checked = True
                '        ElseIf cSessionLoader._pPeriodCovered.Substring(0, 1) = 4 Then
                '            _oRadio4thQ.Checked = True
                '        End If

                '    End If
                'End If
            End If




            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass2._pSubSelectTOP(acctno, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, Selected_QTR)
            '  _nClass2._pSubGetAnnualDue(acctno)
            GridViewTOP.DataSource = _nClass2._mDataTable
            GridViewTOP.DataBind()




            Dim _nclassX As New cDalGetModules
            _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclassX._pSubGetAvailableModules("ChangeMOP") = False Then
                lbl_Paymode.Style.Add("display", "block")
                _oRadio1stQ.Style.Add("display", "none")
                _oRadio2ndQ.Style.Add("display", "none")
                _oRadio3rdQ.Style.Add("display", "none")
                _oRadio4thQ.Style.Add("display", "none")
            End If

            If _nclassX._pSubGetAvailableModules("IncludeCTC") = False Then
                lblCTCAmount.InnerText = "---"
                TotAmtDue.InnerText = String.Format("{0:C}", Sum_TotAmtDue).Replace("$", "")
                _GrandTotal = Sum_TotAmtDue
                GrandTotal.InnerText = String.Format("{0:C}", _GrandTotal).Replace("$", "")
            Else
                _nClass2._pSubGetCTC(acctno, CTC_AMOUNT, CTC_REMARK)
                lblCTCAmount.InnerText = String.Format("{0:C}", CTC_AMOUNT).Replace("$", "")
                TotAmtDue.InnerText = String.Format("{0:C}", Sum_TotAmtDue).Replace("$", "")
                _GrandTotal = CTC_AMOUNT + Sum_TotAmtDue
                GrandTotal.InnerText = String.Format("{0:C}", _GrandTotal).Replace("$", "")

            End If


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
            Dim _nAskValue As String
            Dim _nTaxCode As String

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
                        _nTaxCode = _nSqlDr.Item("TAXCODE").ToString
                        _nAskValue = Format(_nSqlDr.Item("XVALUE").ToString, "Standard")

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



    'Private Sub CreateTextBox(id As String)
    '    'askquestion
    '    Dim txt = New TextBox()
    '    txt.ID = id
    '    txt.CssClass = "col-12"
    '    _opnlTextAskQ.Controls.Add(txt)

    '    Dim lt = New Literal()
    '    lt.Text = "<br />"
    '    _opnlTextAskQ.Controls.Add(lt)
    'End Sub
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

    'Private Sub CreateTextBoxHead(id As String)

    '    'askheading
    '    Dim txt = New TextBox()
    '    txt.ID = id
    '    txt.CssClass = "col-12"
    '    txt.Attributes.Add("style", "font-size:11px;")
    '    _opnlAllAskHeading.Controls.Add(txt)

    '    Dim lt = New Literal()
    '    lt.Text = "<br />"
    '    _opnlAllAskHeading.Controls.Add(lt)
    'End Sub

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
        '_nClass._pForYear = _radYear.Value
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

        _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pSubCREATE_TEMPOPTION()
        _nClass._pSubGET_OPTION()
        _nAskhdg = ""
        _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE TAXCODE = '" & xTaxCode & "'  ORDER BY XSELECTED DESC"

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

    Private Sub btn_TOP_ServerClick(sender As Object, e As EventArgs) Handles btn_TOP.ServerClick
  
        ReportViewer.NEWBP_TOP_ACCTNO = cSessionLoader._pAccountNo
        ReportViewer.NEWBP_TOP_Email = cSessionUser._pUserID
        Try
            If cSessionLoader._pPeriodCovered.Substring(2, 1) = cSessionLoader._pBPQTR Then
                cSessionLoader._pBPQTR = 0
            End If
        Catch ex As Exception

        End Try
       

        Response.Redirect("Report/ReportViewer.aspx?ReportType=NEW_BP_TOP")
    End Sub

    Private Sub _oRadio1stQ_CheckedChanged(sender As Object, e As EventArgs) Handles _oRadio1stQ.CheckedChanged
        If _oRadio1stQ.Checked Then
            lbl_PeriodCovered.Text = cSessionLoader._pPeriodCovered.Remove(2) & radqtr & " Qtr " & cSessionLoader._pFORYEAR
            radqtr = 1
            cSessionLoader._pBPQTR = 1
            loadGrid_TOP(cSessionLoader._pAccountNo, radqtr)
        End If
    End Sub

    Private Sub _oRadio2ndQ_CheckedChanged(sender As Object, e As EventArgs) Handles _oRadio2ndQ.CheckedChanged
        If _oRadio2ndQ.Checked Then
            radqtr = 2
            cSessionLoader._pBPQTR = 2
            lbl_PeriodCovered.Text = cSessionLoader._pPeriodCovered.Remove(2) & radqtr & " Qtr " & cSessionLoader._pFORYEAR
            loadGrid_TOP(cSessionLoader._pAccountNo, radqtr)
        End If
    End Sub

    Private Sub _oRadio3rdQ_CheckedChanged(sender As Object, e As EventArgs) Handles _oRadio3rdQ.CheckedChanged
        If _oRadio3rdQ.Checked Then
            radqtr = 3
            cSessionLoader._pBPQTR = 3
            lbl_PeriodCovered.Text = cSessionLoader._pPeriodCovered.Remove(2) & radqtr & " Qtr " & cSessionLoader._pFORYEAR
            loadGrid_TOP(cSessionLoader._pAccountNo, radqtr)
        End If
    End Sub

    Private Sub _oRadio4thQ_CheckedChanged(sender As Object, e As EventArgs) Handles _oRadio4thQ.CheckedChanged
        If _oRadio4thQ.Checked Then
            radqtr = 4
            cSessionLoader._pBPQTR = 4
            lbl_PeriodCovered.Text = cSessionLoader._pPeriodCovered.Remove(2) & radqtr & " Qtr " & cSessionLoader._pFORYEAR
            loadGrid_TOP(cSessionLoader._pAccountNo, radqtr)
        End If
    End Sub




End Class