
Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization

Partial Public Class BPLTIMS_BPLOReview


    Protected Sub _oButtonNotify_Click(sender As Object, e As EventArgs) Handles _oButtonNotify.Click
        Try
            Dim _nRemarks As String
            Dim _nComment As String
            _nRemarks = _oDDL_Remarks.Value
            _nComment = _oTextboxComment.Text

            'If _SendEmailNotification(_nRemarks, _nComment) = True Then
            UpdateBusMastRemarks(_nRemarks)


            If _nRemarks = "Reviewed/ For Assessment Billing" Then
                UpdateBusMastForPayment()
                If cLoader_CBPAuthRep._pIsFromCBP = True Then
                    Dim _nStatCode As String = "VERIFIED-BUSINESS-PERMIT"
                    If _SendEmailNotification(_nStatCode, _nComment) = True Then
                        cLoader_BPLTIMS._pAPP_DATE = cInit_CBPReg._Fn_GetBUSMASTAppDate()
                        cInit_CBPReg.UpdateCBPAppStatus(_nStatCode, "New", cLoader_BPLTIMS._pAPP_DATE)
                        cInit_CBPReg._InsertAppStatLog(_nStatCode)

                        _InsertToHistory(_nRemarks) ' @ Added 20220511
                    End If
                End If
            ElseIf _nRemarks = "Lacks Mandatory Requirements" Then
                If cLoader_CBPAuthRep._pIsFromCBP = True Then
                    If _SendEmailNotification(_nRemarks, _nComment) = True Then
                        Dim _nStatCode As String = "APPLICATION-DISAPPROVED"
                        cLoader_BPLTIMS._pAPP_DATE = cInit_CBPReg._Fn_GetBUSMASTAppDate()
                        cInit_CBPReg.UpdateCBPAppStatus(_nStatCode, "New", cLoader_BPLTIMS._pAPP_DATE)
                        cInit_CBPReg._InsertAppStatLog(_nStatCode)

                        _InsertToHistory(_nRemarks) ' @ Added 20220511
                    End If
                End If
            End If
            _BindBussinessDetails()  '@Added 20211102 louie
            'SNACK BAR GREEN 
            'MESSAGE "Taxtpayer Sucessfully notified."
            'Response.Redirect("NotificationPages/BPLONotification.aspx")
            Exit Sub
            'Else

            '    Response.Write("<script language='javascript'>window.alert('Send notification failed, please try again.');</script>")
            '    'SNACK BAR RED 
            '    'MESSAGE "Failed sending notification, please check your internet connection and try again."

            '    Exit Sub
            'End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub _InsertToHistory(_nRemarks As String)
        Try

            Dim Particulars As String
            Dim Full As String = cLoader_BPLTIMS._pFIRST_NAME & " " & cLoader_BPLTIMS._pMIDDLE_NAME & " " & cLoader_BPLTIMS._pLAST_NAME

            Particulars = "Business Name=" & cLoader_BPLTIMS._pCOMMNAME & ";" _
                        & "Ownership Type=" & cLoader_BPLTIMS._pOWNCODE & ";" _
                        & "Owner Name=" & Full & ";"

            Dim _nClass3 As New cDalTransactionHistory

            _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nClass3._pSubInsertHistory(cSessionLoader._pAccountNo, _
                                        cSessionUser._pUserID, _
                                        "Business Permit", _
                                        "Application", _
                                        "New Business Application", _
                                        Particulars, _
                                        _nRemarks)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub _oButtonNotiFy2(sender As Object, e As EventArgs) Handles _ButtonNotiFy2.Click
        Try
            Dim _nRemarks As String
            Dim _nComment As String
            _nRemarks = _oDDL_Remarks.Value
            _nComment = _oTextboxComment.Text
            cSessionLoader._pAccountNo = _Fn_GetPermanentAccountNo()
            If _SendEmailNotification(_nRemarks, _nComment) = True Then
                If cLoader_CBPAuthRep._pIsFromCBP = True Then
                    Dim _nStatCode As String = "BUSINESS-PERMIT-FOR-PAYMENT"
                    '"VERIFIED-BUSINESS-PERMIT"
                    cInit_CBPReg.UpdateCBPAppStatus(_nStatCode, "New", cLoader_BPLTIMS._pAPP_DATE)
                    cInit_CBPReg._InsertAppStatLog(_nStatCode)
                End If
                _TagAsNotified("1")
                'UpdateBusMastRemarks(_nRemarks)

                'If _nRemarks = "Reviewed/ For Assessment Billing" Then
                '    UpdateBusMastForPayment()
                'End If
                'SNACK BAR GREEN 
                'MESSAGE "Taxtpayer Sucessfully notified."
                Response.Redirect("NotificationPages/BPLONotification.aspx")
                Exit Sub
            Else

                Response.Write("<script language='javascript'>window.alert('Send notification failed, please try again.');</script>")
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
    Public Function _Fn_GetPermanentAccountNo() As String
        Try
            Dim _nSucess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                ._pAction = "SELECT"
                ._pSelect = "SELECT ACCTNO FROM BUSMAST "
                ._pCondition = " WHERE PBN = ''" & cSessionLoader._pAccountNo & "'' and EMAILADDR = ''" & cLoader_BPLTIMS._pEMAILADDR & "''"
                ._pExec(_nSucess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows("0").Item("ACCTNO").ToString()
                Else
                    Return cSessionLoader._pAccountNo
                End If

            End With
        Catch ex As Exception

        End Try

    End Function
    Protected Sub rbSelector_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each oldrow As GridViewRow In _oGridViewOption.Rows
            CType(oldrow.FindControl("_oButtonRadio"), RadioButton).Checked = False
        Next
        Dim rb As RadioButton = CType(sender, RadioButton)
        Dim row As GridViewRow = CType(rb.NamingContainer, GridViewRow)
        CType(row.FindControl("_oButtonRadio"), RadioButton).Checked = True
    End Sub


    Protected Sub ImageButton_Click(sender As Object, e As EventArgs)
        Try
            Dim _nButton As ImageButton = TryCast(sender, ImageButton)
            Dim gvrow As GridViewRow = CType(_nButton.NamingContainer, GridViewRow)


            Dim _nBusCode As String = DirectCast(gvrow.FindControl("_oLabelBusCode"), Label).Text
            Dim _nForYear = DirectCast(gvrow.FindControl("_oLabelBusYear"), Label).Text

            If _FnRemoveBussinessLine(_nBusCode, _nForYear) = True Then
                _BindGridviewBusinessLine(_oGridViewBusLine)
                'Messege "Selected Business Line successfully removed."
                Exit Sub
            End If
            'Messege "Failure on Removing Selected Business Line."

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub _oButtonProcessAll(sender As Object, e As EventArgs) Handles _oButtonProcessAllLine.ServerClick
        Try
            cLoader_BPLTIMS._pIsProcessAll = True
            _ResetProcessAllIndicator()
            _InitProcessAllLineComputation()

        Catch ex As Exception

        End Try

    End Sub



    Private Function _FnCheckIfHasBusinessLineForProcessAll(ByRef _nDataTable As DataTable) As Boolean
        _FnCheckIfHasBusinessLineForProcessAll = False
        Try

            Dim _nSuccessfull As Boolean

            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT  TOP(1) " & _
                            " BC.BUS_CODE, BC.[DESCRIPTION], BL.FORYEAR, BL.GROSSREC, BL.CAPITAL, BL.AREA, " & _
                            " BL.BUSTAX, BL.MAYORS,BL.SANITARY,BL.GARBAGE,BL.FIRE, BL.STATCODE, " & _
                            " CASE WHEN ISNULL(BL.ISPRCS,0) = 0 " & _
                            " then '''' " & _
                            " else ''DONE'' " & _
                            " end ISPRCS " & _
                            " FROM [BUSLINE] AS BL " & _
                            " INNER JOIN [" & cSessionLoader._pBPLTAS_SvrName & "].[" & cSessionLoader._pBPLTAS_DbName & "].dbo.[BUSCODE] AS BC " & _
                            " ON " & _
                            " BL.BUS_CODE = BC.BUS_CODE COLLATE DATABASE_DEFAULT "

                ._pCondition = " WHERE BL.ACCTNO =  ''" & cSessionLoader._pAccountNo & "'' COLLATE DATABASE_DEFAULT and foryear = YEAR(GETDATE()) AND  ISNULL(isPrcsAll,0) <> 1 "
                ._pSortBy = "ORDER BY BC.[DESCRIPTION] ASC "
                ._pExec(_nSuccessfull, _nErrMsg)

                _nDataTable = _nClass._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                End If

            End With

        Catch ex As Exception

        End Try
    End Function

    Protected Sub _InitProcessAllLineComputation()
        Try
            Dim _nDataTable As New DataTable


            If _FnCheckIfHasBusinessLineForProcessAll(_nDataTable) = True Then


                cPageSession_BusinessLine._pELECCODE_processed = False
                cPageSession_BusinessLine._pMECHCODE_processed = False
                cPageSession_BusinessLine._pBLDGCODE_processed = False
                cPageSession_BusinessLine._pSIGNCODE_processed = False
                cPageSession_BusinessLine._pEPOCODE_processed = False
                cPageSession_BusinessLine._pEIFCODE_processed = False
                cPageSession_BusinessLine._pPLATECODE_processed = False

                cPageSession_BusinessLine._pBCODE_processed = False
                cPageSession_BusinessLine._pMCODE_processed = False
                cPageSession_BusinessLine._pGCODE_processed = False
                cPageSession_BusinessLine._pSCODE_processed = False
                cPageSession_BusinessLine._pFCODE_processed = False

                cLoader_BPLTIMS._pDATE_ESTA = _oLabelDateEstablish.Text

                cLoader_BPLTIMS._pBUS_CODE = _nDataTable.Rows("0").Item("BUS_CODE").ToString
                cLoader_BPLTIMS._pFORYEAR = _nDataTable.Rows("0").Item("FORYEAR").ToString 'dr("FORYEAR")
                cLoader_BPLTIMS._pCAPITAL = _nDataTable.Rows("0").Item("CAPITAL").ToString  'dr("CAPITAL")
                cLoader_BPLTIMS._pAREA = _nDataTable.Rows("0").Item("AREA").ToString 'dr("AREA")
                cLoader_BPLTIMS._pGROSSREC = _nDataTable.Rows("0").Item("GROSSREC").ToString 'dr("GROSSREC")
                cLoader_BPLTIMS._pBUSDESC = _nDataTable.Rows("0").Item("DESCRIPTION").ToString 'dr("DESCRIPTION")

                _oLabelAskBusinessDescription.Text = cLoader_BPLTIMS._pBUSDESC
                _InitDataGather()

            End If

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub _ResetProcessAllIndicator()
        Try

            Try

                Dim _nSuccessfull As Boolean
                Dim _nErrMsg As String = Nothing

                Dim _nClass As New cDal_IUD
                With _nClass
                    ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                    ._pAction = "UPDATE"
                    ._pSelect = "UPDATE BUSLINE SET isPrcsAll = 0 "
                    ._pCondition = " WHERE  AcctNo = ''" & cSessionLoader._pAccountNo & "'' and FORYEAR = YEAR(GETDATE())  "
                    ._pExec(_nSuccessfull, _nErrMsg)
                End With
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub _oButtonCompute_Click(sender As Object, e As EventArgs) Handles _
       _oButtonBuslineCompute.ServerClick

        cLoader_BPLTIMS._pIsProcessAll = False

        cLoader_BPLTIMS._pBUS_CODE = _oTextboxBusinessLineBusCodeCompute.Value
        cLoader_BPLTIMS._pAREA = _oTextboxBusinessLineAreaCompute.Value
        cLoader_BPLTIMS._pCAPITAL = _oTextboxBusinessLineCapitalCompute.Value
        cLoader_BPLTIMS._pGROSSREC = "0.00"
        cLoader_BPLTIMS._pFORYEAR = Year(Now)
        cLoader_BPLTIMS._pDATE_ESTA = _oLabelDateEstablish.Text
        _oLabelAskBusinessDescription.Text = _oTextboxBusinessLineDescCompute.Value
        _InitDataGather()


    End Sub

    Protected Sub _oButtonAddBusinessLine_Click(sender As Object, e As EventArgs) Handles _
        _ButtonSaveBusinessLine.ServerClick

        Try
            cLoader_BPLTIMS._pIsProcessAll = False
            cLoader_BPLTIMS._pBUS_CODE = cmbBusCode.Value.Substring(cmbBusCode.Value.IndexOf("_"c) + 1)
            cLoader_BPLTIMS._pAREA = _oTextboxAddArea.Value
            cLoader_BPLTIMS._pCAPITAL = _oTextboxAddCapital.Value
            cLoader_BPLTIMS._pGROSSREC = "0.00"
            cLoader_BPLTIMS._pFORYEAR = Year(Now)
            cLoader_BPLTIMS._pDATE_ESTA = _oLabelDateEstablish.Text
            _oLabelAskBusinessDescription.Text = cmbBusCode.SelectedIndex
            _InitDataGather()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub _oButton_Click(sender As Object, e As EventArgs) Handles _
     _oButton_UpdateBusline.ServerClick


        Try
            'Dim _nButton As ImageButton = TryCast(sender, ImageButton)
            'Dim gvrow As GridViewRow = CType(_nButton.NamingContainer, GridViewRow)

            cLoader_BPLTIMS._pIsProcessAll = False
            cLoader_BPLTIMS._pBUS_CODE = _oBusinessLineCode.Value
            cLoader_BPLTIMS._pAREA = _oBusinessLineTextArea.Value
            cLoader_BPLTIMS._pCAPITAL = _oBusinessLineCapital.Value
            cLoader_BPLTIMS._pGROSSREC = "0.00"
            cLoader_BPLTIMS._pFORYEAR = _oBusinessLineForYear.Value
            cLoader_BPLTIMS._pDATE_ESTA = _oLabelDateEstablish.Text
            _oLabelAskBusinessDescription.Text = _oBusinessLineDesc.Value
            'Dim _nBusCode As String = _oBusinessLineCode.Value
            'Dim _nForYear As String = cSessionLoader._pCurrentYear
            'Dim _nArea As String = _oBusinessLineArea.Value
            'Dim _nCapital As String = _oBusinessLineCapital.Value

            _InitDataGather()



            'If _FnUpdateBussinessLine(_nBusCode, _nForYear, _nArea, _nCapital) = True Then
            '    _BindGridviewBusinessLine(_oGridViewBusLine)
            '    'Messege "Business Line successfully updated."
            '    Exit Sub
            'End If
            'Messege "Failure on updating Line of Business."

        Catch ex As Exception

        End Try

    End Sub

    Private Sub _InitDataGather()
        Try


            _ProcessBuslineDataGathering()
            If cPageSession_BusinessLine._pELECCODE_processed = True And _
                       cPageSession_BusinessLine._pMECHCODE_processed = True And _
                        cPageSession_BusinessLine._pBLDGCODE_processed = True And _
                         cPageSession_BusinessLine._pSIGNCODE_processed = True And _
                          cPageSession_BusinessLine._pEPOCODE_processed = True And _
                           cPageSession_BusinessLine._pEIFCODE_processed = True And _
                            cPageSession_BusinessLine._pPLATECODE_processed = True And _
                            cPageSession_BusinessLine._pBCODE_processed = True And _
                            cPageSession_BusinessLine._pMCODE_processed = True And _
                            cPageSession_BusinessLine._pGCODE_processed = True And _
                            cPageSession_BusinessLine._pSCODE_processed = True And _
                            cPageSession_BusinessLine._pFCODE_processed = True Then
                _mSubBusLineUpdate()
                If _mSubSaveGatheredInfo() = True Then
                    '   _GenerateTOP()
                End If
            End If


            '_GenerateTOP()

            '_BindGridviewBusinessLine(_oGridViewBusLine)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub _UpdateProcessAllIndicator()
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BUSLINE SET isPrcsAll = 1 "
                ._pCondition = " WHERE  AcctNo = ''" & cSessionLoader._pAccountNo & "'' AND BUS_CODE = ''" & cLoader_BPLTIMS._pBUS_CODE & "'' and FORYEAR = YEAR(GETDATE())  "
                ._pExec(_nSuccessfull, _nErrMsg)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub _oButtonRemoveBusinessLine_Click(sender As Object, e As EventArgs) _
Handles _
     _oButtonBuslineRemove.ServerClick

        If _FnRemoveBussinessLine(_oTextboxBusinessLineBusCodeRemove.Value, _oTextboxBusinessLineYearRemove.Value) = True Then
            _BindGridviewBusinessLine(_oGridViewBusLine)
            _GenerateTOP()
        End If
    End Sub

    Protected Sub _oButton1_Click(sender As Object, e As EventArgs) _
Handles _
      _oButtonTaxSave.Click

        _oPanel_Ask.Visible = False
        _nFnHide_PanelAsk()
        _mFnExitTrigger_False_AIF()
        _mFnExitTrigger_False()
        '_oButtonAdd.Text = "Yes"
        '_oButtonTaxSave.Text = "Saving" ' Added 20170831
        '_oButtonTaxSave.Enabled = False
        '_oTextBoxArea.CssClass = "input"
        '_oTextBoxCapital.CssClass = "input"
        '_oTextBoxGrossRec.CssClass = "input"

        Select Case True
            Case cPageSession_BusinessLine._pHeadingMode
                _mCheckInputedData()    ' @ Added 20170428
            Case cPageSession_BusinessLine._pOptionMode
                _mSubSaveSelectedValue() ' Edited 20170915 with _MCODE
            Case cPageSession_BusinessLine._pQtyMode
                _mCheckInputedData()    ' @ Added 20170503
        End Select

        If cPageSession_BusinessLine._pExit_BCODE = True Or _
            cPageSession_BusinessLine._pExit_MCODE = True Or _
            cPageSession_BusinessLine._pExit_GCODE = True Or _
            cPageSession_BusinessLine._pExit_SCODE = True Or _
            cPageSession_BusinessLine._pExit_FCODE = True Then
            _oPanel_Ask.Visible = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pExit_ELECCODE = True Or _
            cPageSession_BusinessLine._pExit_MECHCODE = True Or _
            cPageSession_BusinessLine._pExit_BLDGCODE = True Or _
            cPageSession_BusinessLine._pExit_SIGNCODE = True Or _
            cPageSession_BusinessLine._pExit_EPOCODE = True Or _
            cPageSession_BusinessLine._pExit_EIFCODE = True Or _
            cPageSession_BusinessLine._pExit_PLATECODE = True Then
            _oPanel_Ask.Visible = True
            Exit Sub
        Else
            '_nFnHide_PanelAsk()
            ' _mSubBusLineUpdate()
            If cPageSession_BusinessLine._pELECCODE_processed = True And _
                 cPageSession_BusinessLine._pMECHCODE_processed = True And _
                  cPageSession_BusinessLine._pBLDGCODE_processed = True And _
                   cPageSession_BusinessLine._pSIGNCODE_processed = True And _
                    cPageSession_BusinessLine._pEPOCODE_processed = True And _
                     cPageSession_BusinessLine._pEIFCODE_processed = True And _
                      cPageSession_BusinessLine._pPLATECODE_processed = True And _
                      cPageSession_BusinessLine._pBCODE_processed = True And _
                      cPageSession_BusinessLine._pMCODE_processed = True And _
                      cPageSession_BusinessLine._pGCODE_processed = True And _
                      cPageSession_BusinessLine._pSCODE_processed = True And _
                      cPageSession_BusinessLine._pFCODE_processed = True Then
                _mSubBusLineUpdate()
                _mSubSaveGatheredInfo()
            Else
                _mFnContinueDataGather()
            End If
        End If

    End Sub

    Private Function _FnIsLineProcessComplete() As Boolean ' Check if all business Line has been processed

        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select ISNULL(isPrcs,0)isPrcs from BUSLINE "
                ._pCondition = " WHERE AcctNo = ''" & cSessionLoader._pAccountNo & "'' and FORYEAR = YEAR((GETDATE())) and ISNULL(isPrcs,0) = 0 "
                '" AND FORYEAR = ''" & cLoader_BPLTIMS._pFORYEAR & "'' "
                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return False
                Else
                    Return True
                End If

            End With

        Catch ex As Exception

        End Try
    End Function

    Private Sub _ProcessBuslineDataGathering()
        Try

            _pSetDefaults()

            _mAskELECCODE()

            If cPageSession_BusinessLine._pExit_ELECCODE = False Then
                _mAskMECHCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_MECHCODE = False Then
                _mAskBLDGCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_BLDGCODE = False Then
                _mAskSIGNCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                _mAskEPOCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                _mAskEIFCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                _mAskPLATECODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                GoTo Basic_Fees
            Else
                Exit Sub
            End If

Basic_Fees:
            '--------------------------------------------------------------------------------------------------------
            _mAskBCODE()

            If cPageSession_BusinessLine._pExit_BCODE = False Then
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskMCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_MCODE = False Then
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskGCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_GCODE = False Then
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskSCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_SCODE = False Then
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskFCODE()

            Else
                Exit Sub
            End If


        Catch ex As Exception

        End Try



    End Sub

    Private Function _mFnValidateIfExist() As Boolean
        Try
            '----------------------------------
            _mFnValidateIfExist = False


            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnValidateIfExist = True
                Else
                    _mFnValidateIfExist = False
                End If
                '----------------------------------
            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnValidateIfExist_BUSLINE() As Boolean       '@  Added 20161202
        Try
            '----------------------------------
            _mFnValidateIfExist_BUSLINE = False




            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pSubSelect_BUSLINE()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnValidateIfExist_BUSLINE = True
                Else
                    _mFnValidateIfExist_BUSLINE = False
                End If
                '----------------------------------
            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub _mSubBusLineUpdate()        ' @ Added   20161129

        Dim _nClass As New cDalBusinessLine
        With _nClass
            ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            ._pAccount = cSessionLoader._pAccountNo
            ._pBusDistCode = cLoader_BPLTIMS._pDISTCODE
            ._pBusBRGYCode = cLoader_BPLTIMS._pBRGYCODE
            ._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            ._pBusDesc = Trim(cmbBusCode.Value)
            ._pBusYear = cLoader_BPLTIMS._pFORYEAR
            ._pBusArea = cLoader_BPLTIMS._pAREA
            ._pBusCap = cLoader_BPLTIMS._pCAPITAL
            ._pBusGrossRec = cLoader_BPLTIMS._pGROSSREC
            ._pBusNRC = "N"
            cPageSession_BPLTASnew._pStatus = "N"
            ._pDate_Estab = cLoader_BPLTIMS._pDATE_ESTA

            If _mFnValidateIfExist() = False Then
                '_oPanelMsg.Visible = False
                '  ._pSubInserInto_BUSEXTN_WEB()
                If cPageSession_BPLTASnew._pStatus = "N" Then
                    ._pSubDeleteFrom_BUSEXTN_WEB()
                    ._pSubInserInto_BUSEXTN_WEB() ' Reused 20180622
                    ._pSubInserInto_BUSLINE_WEB()
                    ._pSub_DeleteBuslineZeroVal()
                End If


            Else
                If _mFnValidateIfExist_BUSLINE() = False Then
                    '_oPanelMsg.Visible = False
                    If cPageSession_BPLTASnew._pStatus = "N" Then
                        ._pSubInserInto_BUSLINE_WEB()
                        ._pSub_DeleteBuslineZeroVal()
                    End If
                Else
                    '_oPanelMsg.Visible = True
                    '_oLabelMsg.Text = "Double entry on Line of Business is not allowed."
                End If

            End If



        End With
    End Sub
End Class
