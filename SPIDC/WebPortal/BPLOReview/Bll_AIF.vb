Partial Public Class BPLTIMS_BPLOReview

    Private Sub _PopulateAIF()

        Try

            Dim _nSuccessfull As Boolean, _nErrMsg As String = Nothing



            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT ACCTNO, FORYEAR, " & _
                            " ISNULL(ZONE,0)ZONE, ISNULL(PNP,0)PNP, ISNULL(RTC,0)RTC, ISNULL(FISCAL,0)FISCAL, ISNULL(MEDICAL,0)MEDICAL, ISNULL(WMEASURES,0)WMEASURES  " & _
                            " , ISNULL(STICKER,0)STICKER, ISNULL(BUILDING,0)BUILDING, ISNULL(MECHANICAL,0)MECHANICAL, ISNULL(PLUMBING,0)PLUMBING, ISNULL(ELECTRICAL,0)ELECTRICAL" & _
                            " , ISNULL(SIGNBILL,0)SIGNBILL, ISNULL(FIRECODE,0)FIRECODE, ISNULL(OTHER,0)OTHER" & _
                            " , ISNULL(RF1,0)RF1, ISNULL(RF2,0)RF2, ISNULL(RF3,0)RF3, ISNULL(RF4,0)RF4, ISNULL(RF5,0)RF5, ISNULL(RF6,0)RF6, ISNULL(RF7,0)RF7, ISNULL(RF8,0)RF8, ISNULL(RF9,0)RF9" & _
                            " , ISNULL(RF10,0)RF10, ISNULL(RF11,0)RF11, ISNULL(RF12,0)RF12, ISNULL(RF13,0)RF13, ISNULL(RF14,0)RF14, ISNULL(RF15,0)RF15, ISNULL(RF16,0)RF16  " & _
                            " FROM BUSEXTN"
                ._pCondition = " WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' and  FORYEAR = ''" & cSessionLoader._pCurrentYear & "''"
                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then

                    _otxtZONE.Value = _nDataTable.Rows(0).Item("ZONE")
                    _otxtPNP.Value = _nDataTable.Rows(0).Item("PNP")
                    _otxtRTC.Value = _nDataTable.Rows(0).Item("RTC")
                    _otxtFISCAL.Value = _nDataTable.Rows(0).Item("FISCAL")
                    _otxtMEDICAL.Value = _nDataTable.Rows(0).Item("MEDICAL")
                    _otxtWMEASURES.Value = _nDataTable.Rows(0).Item("WMEASURES")
                    _otxtSTICKER.Value = _nDataTable.Rows(0).Item("STICKER")
                    _otxtBUILDING.Value = _nDataTable.Rows(0).Item("BUILDING")
                    _otxtMECHANICAL.Value = _nDataTable.Rows(0).Item("MECHANICAL")
                    _otxtPLUMBING.Value = _nDataTable.Rows(0).Item("PLUMBING")
                    _otxtELECTRICAL.Value = _nDataTable.Rows(0).Item("ELECTRICAL")
                    _otxtSIGNBILL.Value = _nDataTable.Rows(0).Item("SIGNBILL")
                    _otxtFIRECODE.Value = _nDataTable.Rows(0).Item("FIRECODE")
                    _otxtOTHER.Value = _nDataTable.Rows(0).Item("OTHER")
                    _otxtRF1.Value = _nDataTable.Rows(0).Item("RF1")
                    _otxtRF2.Value = _nDataTable.Rows(0).Item("RF2")
                    _otxtRF3.Value = _nDataTable.Rows(0).Item("RF3")
                    _otxtRF4.Value = _nDataTable.Rows(0).Item("RF4")
                    _otxtRF5.Value = _nDataTable.Rows(0).Item("RF5")
                    _otxtRF6.Value = _nDataTable.Rows(0).Item("RF6")
                    _otxtRF7.Value = _nDataTable.Rows(0).Item("RF7")
                    _otxtRF8.Value = _nDataTable.Rows(0).Item("RF8")
                    _otxtRF9.Value = _nDataTable.Rows(0).Item("RF9")
                    _otxtRF10.Value = _nDataTable.Rows(0).Item("RF10")
                    _otxtRF11.Value = _nDataTable.Rows(0).Item("RF11")
                    _otxtRF12.Value = _nDataTable.Rows(0).Item("RF12")
                    _otxtRF13.Value = _nDataTable.Rows(0).Item("RF13")
                    _otxtRF14.Value = _nDataTable.Rows(0).Item("RF14")
                    _otxtRF15.Value = _nDataTable.Rows(0).Item("RF15")
                    _otxtRF16.Value = _nDataTable.Rows(0).Item("RF16")

                End If
            End With

            _PopulateAIF_DEFAMT()

            _Init_Displayname()
        Catch ex As Exception
            _otextBusinessNature.Text = ex.ToString
        End Try



    End Sub

    Private Sub _PopulateAIF_DEFAMT()

        Try

            Dim _nSuccessfull As Boolean, _nErrMsg As String = Nothing

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.vw_CheckAIF_DEFAMT "
                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    If _nDataTable.Rows(0).Item("ZONE") > 0 Then
                        _otxtZONE.Value = _nDataTable.Rows(0).Item("ZONE")
                    End If
                    If _nDataTable.Rows(0).Item("PNP") > 0 Then
                        _otxtPNP.Value = _nDataTable.Rows(0).Item("PNP")
                    End If
                    If _nDataTable.Rows(0).Item("RTC") > 0 Then
                        _otxtRTC.Value = _nDataTable.Rows(0).Item("RTC")
                    End If
                    If _nDataTable.Rows(0).Item("RTC") > 0 Then
                        _otxtRTC.Value = _nDataTable.Rows(0).Item("RTC")
                    End If
                    If _nDataTable.Rows(0).Item("FISCAL") > 0 Then
                        _otxtFISCAL.Value = _nDataTable.Rows(0).Item("FISCAL")
                    End If
                    If _nDataTable.Rows(0).Item("MEDICAL") > 0 Then
                        _otxtMEDICAL.Value = _nDataTable.Rows(0).Item("MEDICAL")
                    End If
                    If _nDataTable.Rows(0).Item("WMEASURES") > 0 Then
                        _otxtWMEASURES.Value = _nDataTable.Rows(0).Item("WMEASURES")
                    End If
                    If _nDataTable.Rows(0).Item("STICKER") > 0 Then
                        _otxtSTICKER.Value = _nDataTable.Rows(0).Item("STICKER")
                    End If
                    If _nDataTable.Rows(0).Item("BUILDING") > 0 Then
                        _otxtBUILDING.Value = _nDataTable.Rows(0).Item("BUILDING")
                    End If
                    If _nDataTable.Rows(0).Item("MECHANICAL") > 0 Then
                        _otxtMECHANICAL.Value = _nDataTable.Rows(0).Item("MECHANICAL")
                    End If
                    If _nDataTable.Rows(0).Item("FISCAL") > 0 Then
                        _otxtFISCAL.Value = _nDataTable.Rows(0).Item("FISCAL")
                    End If
                    If _nDataTable.Rows(0).Item("PLUMBING") > 0 Then
                        _otxtPLUMBING.Value = _nDataTable.Rows(0).Item("PLUMBING")
                    End If
                    If _nDataTable.Rows(0).Item("ELECTRICAL") > 0 Then
                        _otxtELECTRICAL.Value = _nDataTable.Rows(0).Item("ELECTRICAL")
                    End If
                    If _nDataTable.Rows(0).Item("SIGNBILL") > 0 Then
                        _otxtSIGNBILL.Value = _nDataTable.Rows(0).Item("SIGNBILL")
                    End If
                    If _nDataTable.Rows(0).Item("FIRECODE") > 0 Then
                        _otxtFIRECODE.Value = _nDataTable.Rows(0).Item("FIRECODE")
                    End If
                    If _nDataTable.Rows(0).Item("OTHER") > 0 Then
                        _otxtOTHER.Value = _nDataTable.Rows(0).Item("OTHER")
                    End If
                    If _nDataTable.Rows(0).Item("RF1") > 0 Then
                        _otxtRF1.Value = _nDataTable.Rows(0).Item("RF1")
                    End If
                    If _nDataTable.Rows(0).Item("RF2") > 0 Then
                        _otxtRF2.Value = _nDataTable.Rows(0).Item("RF2")
                    End If
                    If _nDataTable.Rows(0).Item("RF3") > 0 Then
                        _otxtRF3.Value = _nDataTable.Rows(0).Item("RF3")
                    End If
                    If _nDataTable.Rows(0).Item("RF4") > 0 Then
                        _otxtRF4.Value = _nDataTable.Rows(0).Item("RF4")
                    End If
                    If _nDataTable.Rows(0).Item("RF5") > 0 Then
                        _otxtRF5.Value = _nDataTable.Rows(0).Item("RF5")
                    End If
                    If _nDataTable.Rows(0).Item("RF6") > 0 Then
                        _otxtRF6.Value = _nDataTable.Rows(0).Item("RF6")
                    End If
                    If _nDataTable.Rows(0).Item("RF7") > 0 Then
                        _otxtRF7.Value = _nDataTable.Rows(0).Item("RF7")
                    End If
                    If _nDataTable.Rows(0).Item("RF8") > 0 Then
                        _otxtRF8.Value = _nDataTable.Rows(0).Item("RF8")
                    End If
                    If _nDataTable.Rows(0).Item("RF9") > 0 Then
                        _otxtRF9.Value = _nDataTable.Rows(0).Item("RF9")
                    End If
                    If _nDataTable.Rows(0).Item("RF10") > 0 Then
                        _otxtRF10.Value = _nDataTable.Rows(0).Item("RF10")
                    End If
                    If _nDataTable.Rows(0).Item("RF11") > 0 Then
                        _otxtRF11.Value = _nDataTable.Rows(0).Item("RF11")
                    End If
                    If _nDataTable.Rows(0).Item("RF12") > 0 Then
                        _otxtRF12.Value = _nDataTable.Rows(0).Item("RF12")
                    End If
                    If _nDataTable.Rows(0).Item("RF13") > 0 Then
                        _otxtRF13.Value = _nDataTable.Rows(0).Item("RF13")
                    End If
                    If _nDataTable.Rows(0).Item("RF14") > 0 Then
                        _otxtRF14.Value = _nDataTable.Rows(0).Item("RF14")
                    End If
                    If _nDataTable.Rows(0).Item("RF15") > 0 Then
                        _otxtRF15.Value = _nDataTable.Rows(0).Item("RF15")
                    End If
                    If _nDataTable.Rows(0).Item("RF16") > 0 Then
                        _otxtRF16.Value = _nDataTable.Rows(0).Item("RF16")
                    End If

                End If
            End With

        Catch ex As Exception

        End Try



    End Sub

    Private Sub _Init_Displayname()

        Try

            Dim _nSuccessfull As Boolean, _nErrMsg As String = Nothing

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.vw_AIF_DisplayName "
                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    If _nDataTable.Rows(0).Item("ZONE") <> "" Then
                        _oLabelZONE.Text = _nDataTable.Rows(0).Item("ZONE")
                    End If
                    If _nDataTable.Rows(0).Item("PNP") <> "" Then
                        _oLabelPNP.Text = _nDataTable.Rows(0).Item("PNP")
                    End If
                    If _nDataTable.Rows(0).Item("RTC") <> "" Then
                        _oLabelRTC.Text = _nDataTable.Rows(0).Item("RTC")
                    End If
                    If _nDataTable.Rows(0).Item("RTC") <> "" Then
                        _oLabelRTC.Text = _nDataTable.Rows(0).Item("RTC")
                    End If
                    If _nDataTable.Rows(0).Item("FISCAL") <> "" Then
                        _oLabelFISCAL.Text = _nDataTable.Rows(0).Item("FISCAL")
                    End If
                    If _nDataTable.Rows(0).Item("MEDICAL") <> "" Then
                        _oLabelMEDICAL.Text = _nDataTable.Rows(0).Item("MEDICAL")
                    End If
                    If _nDataTable.Rows(0).Item("WMEASURES") <> "" Then
                        _oLabelWMEASURES.Text = _nDataTable.Rows(0).Item("WMEASURES")
                    End If
                    If _nDataTable.Rows(0).Item("STICKER") <> "" Then
                        _oLabelSTICKER.Text = _nDataTable.Rows(0).Item("STICKER")
                    End If
                    If _nDataTable.Rows(0).Item("BUILDING") <> "" Then
                        _oLabelBUILDING.Text = _nDataTable.Rows(0).Item("BUILDING")
                    End If
                    If _nDataTable.Rows(0).Item("MECHANICAL") <> "" Then
                        _oLabelMECHANICAL.Text = _nDataTable.Rows(0).Item("MECHANICAL")
                    End If
                    If _nDataTable.Rows(0).Item("FISCAL") <> "" Then
                        _oLabelFISCAL.Text = _nDataTable.Rows(0).Item("FISCAL")
                    End If
                    If _nDataTable.Rows(0).Item("PLUMBING") <> "" Then
                        _oLabelPLUMBING.Text = _nDataTable.Rows(0).Item("PLUMBING")
                    End If
                    If _nDataTable.Rows(0).Item("ELECTRICAL") <> "" Then
                        _oLabelELECTRICAL.Text = _nDataTable.Rows(0).Item("ELECTRICAL")
                    End If
                    If _nDataTable.Rows(0).Item("SIGNBILL") <> "" Then
                        _oLabelSIGNBILL.Text = _nDataTable.Rows(0).Item("SIGNBILL")
                    End If
                    If _nDataTable.Rows(0).Item("FIRECODE") <> "" Then
                        _oLabelFIRECODE.Text = _nDataTable.Rows(0).Item("FIRECODE")
                    End If
                    If _nDataTable.Rows(0).Item("OTHER") <> "" Then
                        _oLabelOTHER.Text = _nDataTable.Rows(0).Item("OTHER")
                    End If
                    If _nDataTable.Rows(0).Item("RF1") <> "" Then
                        _oLabelRF1.Text = _nDataTable.Rows(0).Item("RF1")
                    End If
                    If _nDataTable.Rows(0).Item("RF2") <> "" Then
                        _oLabelRF2.Text = _nDataTable.Rows(0).Item("RF2")
                    End If
                    If _nDataTable.Rows(0).Item("RF3") <> "" Then
                        _oLabelRF3.Text = _nDataTable.Rows(0).Item("RF3")
                    End If
                    If _nDataTable.Rows(0).Item("RF4") <> "" Then
                        _oLabelRF4.Text = _nDataTable.Rows(0).Item("RF4")
                    End If
                    If _nDataTable.Rows(0).Item("RF5") <> "" Then
                        _oLabelRF5.Text = _nDataTable.Rows(0).Item("RF5")
                    End If
                    If _nDataTable.Rows(0).Item("RF6") <> "" Then
                        _oLabelRF6.Text = _nDataTable.Rows(0).Item("RF6")
                    End If
                    If _nDataTable.Rows(0).Item("RF7") <> "" Then
                        _oLabelRF7.Text = _nDataTable.Rows(0).Item("RF7")
                    End If
                    If _nDataTable.Rows(0).Item("RF8") <> "" Then
                        _oLabelRF8.Text = _nDataTable.Rows(0).Item("RF8")
                    End If
                    If _nDataTable.Rows(0).Item("RF9") <> "" Then
                        _oLabelRF9.Text = _nDataTable.Rows(0).Item("RF9")
                    End If
                    If _nDataTable.Rows(0).Item("RF10") <> "" Then
                        _oLabelRF10.Text = _nDataTable.Rows(0).Item("RF10")
                    End If
                    If _nDataTable.Rows(0).Item("RF11") <> "" Then
                        _oLabelRF11.Text = _nDataTable.Rows(0).Item("RF11")
                    End If
                    If _nDataTable.Rows(0).Item("RF12") <> "" Then
                        _oLabelRF12.Text = _nDataTable.Rows(0).Item("RF12")
                    End If
                    If _nDataTable.Rows(0).Item("RF13") <> "" Then
                        _oLabelRF13.Text = _nDataTable.Rows(0).Item("RF13")
                    End If
                    If _nDataTable.Rows(0).Item("RF14") <> "" Then
                        _oLabelRF14.Text = _nDataTable.Rows(0).Item("RF14")
                    End If
                    If _nDataTable.Rows(0).Item("RF15") <> "" Then
                        _oLabelRF15.Text = _nDataTable.Rows(0).Item("RF15")
                    End If
                    If _nDataTable.Rows(0).Item("RF16") <> "" Then
                        _oLabelRF16.Text = _nDataTable.Rows(0).Item("RF16")
                    End If

                End If
            End With

        Catch ex As Exception

        End Try



    End Sub

    Private Sub PassAIFvaluetoHiddenText()
        Try

        
        _oTxtHiddenZONE.Value = _otxtZONE.Value
        _oTxtHiddenPNP.Value = _otxtPNP.Value
        _oTxtHiddenRTC.Value = _otxtRTC.Value
        _oTxtHiddenFISCAL.Value = _otxtFISCAL.Value
        _oTxtHiddenMEDICAL.Value = _otxtMEDICAL.Value
        _oTxtHiddenWMEASURES.Value = _otxtWMEASURES.Value
        _oTxtHiddenSTICKER.Value = _otxtSTICKER.Value
        _oTxtHiddenBUILDING.Value = _otxtBUILDING.Value
        _oTxtHiddenMECHANICAL.Value = _otxtMECHANICAL.Value
        _oTxtHiddenPLUMBING.Value = _otxtPLUMBING.Value
        _oTxtHiddenELECTRICAL.Value = _otxtELECTRICAL.Value
        _oTxtHiddenSIGNBILL.Value = _otxtSIGNBILL.Value
        _oTxtHiddenFIRECODE.Value = _otxtFIRECODE.Value
        _oTxtHiddenOTHER.Value = _otxtOTHER.Value
        _oTxtHiddenRF1.Value = _otxtRF1.Value
        _oTxtHiddenRF2.Value = _otxtRF2.Value
        _oTxtHiddenRF3.Value = _otxtRF3.Value
        _oTxtHiddenRF4.Value = _otxtRF4.Value
        _oTxtHiddenRF5.Value = _otxtRF5.Value
        _oTxtHiddenRF6.Value = _otxtRF6.Value
        _oTxtHiddenRF7.Value = _otxtRF7.Value
        _oTxtHiddenRF8.Value = _otxtRF8.Value
        _oTxtHiddenRF9.Value = _otxtRF9.Value
        _oTxtHiddenRF10.Value = _otxtRF10.Value
        _oTxtHiddenRF11.Value = _otxtRF11.Value
        _oTxtHiddenRF12.Value = _otxtRF12.Value
        _oTxtHiddenRF13.Value = _otxtRF13.Value
        _oTxtHiddenRF14.Value = _otxtRF14.Value
        _oTxtHiddenRF15.Value = _otxtRF15.Value
            _oTxtHiddenRF16.Value = _otxtRF16.Value
        Catch ex As Exception
            _otextBusinessNature.Text = ex.ToString
        End Try

    End Sub

    Private Sub _LockRegulatoryInput()
        Try

        
        _otxtZONE.Disabled = True
        _otxtPNP.Disabled = True
        _otxtRTC.Disabled = True
        _otxtFISCAL.Disabled = True
        _otxtMEDICAL.Disabled = True
        _otxtWMEASURES.Disabled = True
        _otxtSTICKER.Disabled = True
        _otxtBUILDING.Disabled = True
        _otxtMECHANICAL.Disabled = True
        _otxtPLUMBING.Disabled = True
        _otxtELECTRICAL.Disabled = True
        _otxtSIGNBILL.Disabled = True
        _otxtFIRECODE.Disabled = True
        _otxtOTHER.Disabled = True
        _otxtRF1.Disabled = True
        _otxtRF2.Disabled = True
        _otxtRF3.Disabled = True
        _otxtRF4.Disabled = True
        _otxtRF5.Disabled = True
        _otxtRF6.Disabled = True
        _otxtRF7.Disabled = True
        _otxtRF8.Disabled = True
        _otxtRF9.Disabled = True
        _otxtRF10.Disabled = True
        _otxtRF11.Disabled = True
        _otxtRF12.Disabled = True
        _otxtRF13.Disabled = True
        _otxtRF14.Disabled = True
        _otxtRF15.Disabled = True
            _otxtRF16.Disabled = True
        Catch ex As Exception
            _otextBusinessNature.Text = ex.ToString
        End Try
    End Sub
    Private Sub _mSubLabelLocked()

        Try

            Dim _nSuccessfull As Boolean, _nErrMsg As String = Nothing

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.vw_CheckAIF_LOCKED"
                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then

                    _otxtZONE.Disabled = _FnLocked(_nDataTable, "ZONE")
                    _otxtPNP.Disabled = _FnLocked(_nDataTable, "PNP")
                    _otxtRTC.Disabled = _FnLocked(_nDataTable, "RTC")
                    _otxtFISCAL.Disabled = _FnLocked(_nDataTable, "FISCAL")
                    _otxtMEDICAL.Disabled = _FnLocked(_nDataTable, "MEDICAL")
                    _otxtWMEASURES.Disabled = _FnLocked(_nDataTable, "WMEASURES")
                    _otxtSTICKER.Disabled = _FnLocked(_nDataTable, "STICKER")
                    _otxtBUILDING.Disabled = _FnLocked(_nDataTable, "BUILDING")
                    _otxtMECHANICAL.Disabled = _FnLocked(_nDataTable, "MECHANICAL")
                    _otxtPLUMBING.Disabled = _FnLocked(_nDataTable, "PLUMBING")
                    _otxtELECTRICAL.Disabled = _FnLocked(_nDataTable, "ELECTRICAL")
                    _otxtSIGNBILL.Disabled = _FnLocked(_nDataTable, "SIGNBILL")
                    _otxtFIRECODE.Disabled = _FnLocked(_nDataTable, "FIRECODE")
                    _otxtOTHER.Disabled = _FnLocked(_nDataTable, "OTHER")
                    _otxtRF1.Disabled = _FnLocked(_nDataTable, "RF1")
                    _otxtRF2.Disabled = _FnLocked(_nDataTable, "RF2")
                    _otxtRF3.Disabled = _FnLocked(_nDataTable, "RF3")
                    _otxtRF4.Disabled = _FnLocked(_nDataTable, "RF4")
                    _otxtRF5.Disabled = _FnLocked(_nDataTable, "RF5")
                    _otxtRF6.Disabled = _FnLocked(_nDataTable, "RF6")
                    _otxtRF7.Disabled = _FnLocked(_nDataTable, "RF7")
                    _otxtRF8.Disabled = _FnLocked(_nDataTable, "RF8")
                    _otxtRF9.Disabled = _FnLocked(_nDataTable, "RF9")
                    _otxtRF10.Disabled = _FnLocked(_nDataTable, "RF10")
                    _otxtRF11.Disabled = _FnLocked(_nDataTable, "RF11")
                    _otxtRF12.Disabled = _FnLocked(_nDataTable, "RF12")
                    _otxtRF13.Disabled = _FnLocked(_nDataTable, "RF13")
                    _otxtRF14.Disabled = _FnLocked(_nDataTable, "RF14")
                    _otxtRF15.Disabled = _FnLocked(_nDataTable, "RF15")
                    _otxtRF16.Disabled = _FnLocked(_nDataTable, "RF16")

                End If
            End With







        Catch ex As Exception

        End Try



    End Sub

    Private Function _FnLocked(_nDataTable As DataTable, _nCol As String) As Boolean

        If _nDataTable.Rows(0).Item(_nCol) = 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub _mSubUpdateAIF()
        Try

            Dim _nCls As New cDalAIF
            _nCls._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            _nCls._pSubUpdate(cSessionLoader._pAccountNo, cSessionLoader._pCurrentYear, _
                              _otxtZONE.Value, _
                              _otxtPNP.Value, _
                              _otxtRTC.Value, _
                              _otxtFISCAL.Value, _
                              _otxtMEDICAL.Value, _
                              _otxtWMEASURES.Value, _
                              _otxtSTICKER.Value, _
                              _otxtBUILDING.Value, _
                              _otxtMECHANICAL.Value, _
                              _otxtPLUMBING.Value, _
                              _otxtELECTRICAL.Value, _
                              _otxtSIGNBILL.Value, _
                              _otxtFIRECODE.Value, _
                              _otxtOTHER.Value, _
                              _otxtRF1.Value, _
                              _otxtRF2.Value, _
                              _otxtRF3.Value, _
                              _otxtRF4.Value, _
                              _otxtRF5.Value, _
                              _otxtRF6.Value, _
                              _otxtRF7.Value, _
                              _otxtRF8.Value, _
                              _otxtRF9.Value, _
                              _otxtRF10.Value, _
                              _otxtRF11.Value, _
                              _otxtRF12.Value, _
                              _otxtRF13.Value, _
                              _otxtRF14.Value, _
                              _otxtRF15.Value, _
                              _otxtRF16.Value _
                              )

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub _oButtonAIF_Click(sender As Object, e As EventArgs) Handles _
     _obuttonregulatoryEdit.Click, _
      _obuttonregulatorySave.Click, _
      _obuttonregulatoryCancel.Click

        Select Case DirectCast(sender, Button).ID

            Case _obuttonregulatoryEdit.ID
                _mSubLabelLocked()
                _obuttonregulatoryEdit.Enabled = False
                _obuttonregulatorySave.Enabled = True
                _obuttonregulatoryCancel.Enabled = True
                _mSubvalueFormat()
            Case _obuttonregulatorySave.ID
                _mSubUpdateAIF()
                '_opnlregulatory.Enabled = False
                _obuttonregulatoryEdit.Enabled = True
                _obuttonregulatorySave.Enabled = False
                _obuttonregulatoryCancel.Enabled = False
                _mSubvalueFormat()
                _LockRegulatoryInput()

            Case _obuttonregulatoryCancel.ID
                _LockRegulatoryInput()
                _PopulateAIF()
                '_opnlregulatory.Enabled = False
                _obuttonregulatoryEdit.Enabled = True
                _obuttonregulatorySave.Enabled = False
                _obuttonregulatoryCancel.Enabled = False
                _mSubvalueFormat()
        End Select


    End Sub

    Private Sub _mSubvalueFormat()
        Try

        
        _otxtZONE.Value = Format(_otxtZONE.Value, "Standard")
        _otxtPNP.Value = Format(_otxtPNP.Value, "Standard")
        _otxtRTC.Value = Format(_otxtRTC.Value, "Standard")
        _otxtFISCAL.Value = Format(_otxtFISCAL.Value, "Standard")
        _otxtMEDICAL.Value = Format(_otxtMEDICAL.Value, "Standard")
        _otxtWMEASURES.Value = Format(_otxtWMEASURES.Value, "Standard")
        _otxtSTICKER.Value = Format(_otxtSTICKER.Value, "Standard")
        _otxtBUILDING.Value = Format(_otxtBUILDING.Value, "Standard")
        _otxtMECHANICAL.Value = Format(_otxtMECHANICAL.Value, "Standard")
        _otxtPLUMBING.Value = Format(_otxtPLUMBING.Value, "Standard")
        _otxtELECTRICAL.Value = Format(_otxtELECTRICAL.Value, "Standard")
        _otxtSIGNBILL.Value = Format(_otxtSIGNBILL.Value, "Standard")
        _otxtFIRECODE.Value = Format(_otxtFIRECODE.Value, "Standard")
        _otxtOTHER.Value = Format(_otxtOTHER.Value, "Standard")
        _otxtRF1.Value = Format(_otxtRF1.Value, "Standard")
        _otxtRF2.Value = Format(_otxtRF2.Value, "Standard")
        _otxtRF3.Value = Format(_otxtRF3.Value, "Standard")
        _otxtRF4.Value = Format(_otxtRF4.Value, "Standard")
        _otxtRF5.Value = Format(_otxtRF5.Value, "Standard")
        _otxtRF6.Value = Format(_otxtRF6.Value, "Standard")
        _otxtRF7.Value = Format(_otxtRF7.Value, "Standard")
        _otxtRF8.Value = Format(_otxtRF8.Value, "Standard")
        _otxtRF9.Value = Format(_otxtRF9.Value, "Standard")
        _otxtRF10.Value = Format(_otxtRF10.Value, "Standard")
        _otxtRF11.Value = Format(_otxtRF11.Value, "Standard")
        _otxtRF12.Value = Format(_otxtRF12.Value, "Standard")
        _otxtRF13.Value = Format(_otxtRF13.Value, "Standard")
        _otxtRF14.Value = Format(_otxtRF14.Value, "Standard")
        _otxtRF15.Value = Format(_otxtRF15.Value, "Standard")
            _otxtRF16.Value = Format(_otxtRF16.Value, "Standard")

        Catch ex As Exception
            _otextBusinessNature.Text = ex.ToString
        End Try
    End Sub

End Class
