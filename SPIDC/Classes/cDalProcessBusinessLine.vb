
Partial Public Class BPLTIMSBusinessLine

#Region "Variable field"

    Private Shared _mAccount As String
    Private Shared _mArea As Double
    Private Shared _mCapital As Double
    Private Shared _mGross As Double
    Private Shared _mStatus As String
    Private Shared _mForYear As String
    Private Shared _mBusCode As String

#End Region


#Region "Property field"
    Public Property _pAccount() As String
        Get
            Return _mAccount
        End Get
        Set(ByVal value As String)
            _mAccount = value
        End Set
    End Property

    Public Property _pArea() As Double
        Get
            Return _mArea
        End Get
        Set(ByVal value As Double)
            _mArea = value
        End Set
    End Property

    Public Property _pCapital() As Double
        Get
            Return _mCapital
        End Get
        Set(ByVal value As Double)
            _mCapital = value
        End Set
    End Property

    Public Property _pGross() As Double
        Get
            Return _mGross
        End Get
        Set(ByVal value As Double)
            _mGross = value
        End Set
    End Property

    Public Property _pStatus() As String
        Get
            Return _mStatus
        End Get
        Set(ByVal value As String)
            _mStatus = value
        End Set
    End Property

    Public Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(ByVal value As String)
            _mForYear = value
        End Set
    End Property

    Public Property _pBusCode() As String
        Get
            Return _mBusCode
        End Get
        Set(ByVal value As String)
            _mBusCode = value
        End Set
    End Property

#End Region

    Public Function _pFnCheckIfBuslineExist()
        _pFnCheckIfBuslineExist = False
        Try
            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " SELEC BUS_CODE FROM BUSLINE "
                ._pCondition = " WHERE ACCTNO =''" & _mAccount & "'' AND FORYEAR = ''" & _mForYear & "'' AND BUS_CODE = ''" & _mBusCode & "'' "
                ._pExec(_nSuccessful, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            End With
        Catch ex As Exception

        End Try

    End Function ' Check if Busline already exists

    Public Sub _pSetDefaults()

        cPageSession_BusinessLine._pTaxCode2Mode = False
        cPageSession_BusinessLine._pOptionTaxCode2 = Nothing

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = False

        cPageSession_BusinessLine._pELECCODE_FEE = 0
        cPageSession_BusinessLine._pMECHCODE_FEE = 0
        cPageSession_BusinessLine._pBLDGCODE_FEE = 0
        cPageSession_BusinessLine._pBLDGCODE_FEE = 0
        cPageSession_BusinessLine._pSIGNCODE_FEE = 0
        cPageSession_BusinessLine._pEPOCODE_FEE = 0
        cPageSession_BusinessLine._pEIFCODE_FEE = 0
        cPageSession_BusinessLine._pPLATECODE_FEE = 0
        cPageSession_BusinessLine._pBUSCODE = cLoader_BPLTIMS._pBUS_CODE
        cPageSession_BusinessLine._pxForYear = cLoader_BPLTIMS._pFORYEAR

        cPageSession_BusinessLine._pAREA = cLoader_BPLTIMS._pAREA
        cPageSession_BusinessLine._pCAPITAL = cLoader_BPLTIMS._pCAPITAL
        cPageSession_BusinessLine._pGROSS = cLoader_BPLTIMS._pGROSSREC

        cPageSession_BusinessLine._pBCOMPSW = 0
        cPageSession_BusinessLine._pMCOMPSW = 0
        cPageSession_BusinessLine._pGCOMPSW = 0
        cPageSession_BusinessLine._pSCOMPSW = 0
        cPageSession_BusinessLine._pFCOMPSW = 0
    End Sub


#Region "AIF DATA GATHERING PROCESSES"
    Public Sub _mAskELECCODE() '@ Added 20170811   
        Try


            '_oLabelFeeType.Text = "ELECTICAL FEE"
            cPageSession_BusinessLine._pTaxField = "ELECCODE"

            cPageSession_BusinessLine._pELECCODE = True
            cPageSession_BusinessLine._pMECHCODE = False
            cPageSession_BusinessLine._pBLDGCODE = False
            cPageSession_BusinessLine._pSIGNCODE = False
            cPageSession_BusinessLine._pEPOCODE = False
            cPageSession_BusinessLine._pEIFCODE = False
            cPageSession_BusinessLine._pPLATECODE = False

            '_mpAsk.Hide()
            If _mFnIfHasRecord_GRADTABL_AIF() = True Then
                cPageSession_BusinessLine._pELECCODE_processed = True
                Exit Sub
            ElseIf cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode = Nothing Then
                'cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pELECCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                    ' _oLabelFeeType.Text = "ELECTICAL FEE"
                    cPageSession_BusinessLine._pELECCODE_processed = True
                    Exit Sub
                ElseIf HasRange(cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pELECCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pELECCODE_GRADTABL_EffMonth) = True Then
                    Dim xTaxBase As Double
                    xTaxBase = cPageSession_BusinessLine._pAREA
                    cPageSession_BusinessLine._pELECCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pELECCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pELECCODE_GRADTABL_EffMonth, xTaxBase, "0")
                    cPageSession_BusinessLine._pELECCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GROPTION_AIF() = True Then
                        _oLabelFeeType.Text = "ELECTICAL FEE"
                        cPageSession_BusinessLine._pELECCODE_processed = True
                        Exit Sub
                    Else

                        If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                            _oLabelFeeType.Text = "ELECTICAL FEE"
                            cPageSession_BusinessLine._pELECCODE_processed = True
                            Exit Sub
                        Else
                        End If
                    End If
                End If
            End If
            cPageSession_BusinessLine._pELECCODE_processed = True
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mAskMECHCODE() '@ Added 20170811
        Try
            '_oLabelFeeType.Text = "MECHANICAL FEE"
            cPageSession_BusinessLine._pTaxField = "MECHCODE"

            cPageSession_BusinessLine._pELECCODE = False
            cPageSession_BusinessLine._pMECHCODE = True
            cPageSession_BusinessLine._pBLDGCODE = False
            cPageSession_BusinessLine._pSIGNCODE = False
            cPageSession_BusinessLine._pEPOCODE = False
            cPageSession_BusinessLine._pEIFCODE = False
            cPageSession_BusinessLine._pPLATECODE = False
            '_mpAsk.Hide()
            If _mFnIfHasRecord_GRADTABL_AIF() = True Then
                cPageSession_BusinessLine._pMECHCODE_processed = True
                Exit Sub
            ElseIf cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode = Nothing Then
                cPageSession_BusinessLine._pMECHCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                    _oLabelFeeType.Text = "MECHANICAL FEE"
                    cPageSession_BusinessLine._pMECHCODE_processed = True
                    Exit Sub
                ElseIf HasRange(cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffMonth) = True Then
                    Dim xTaxBase As Double
                    xTaxBase = cPageSession_BusinessLine._pAREA
                    cPageSession_BusinessLine._pMECHCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffMonth, xTaxBase, "0")
                    cPageSession_BusinessLine._pMECHCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GROPTION_AIF() = True Then
                        _oLabelFeeType.Text = "MECHANICAL FEE"
                        cPageSession_BusinessLine._pMECHCODE_processed = True
                        Exit Sub
                    Else

                        If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                            _oLabelFeeType.Text = "MECHANICAL FEE"
                            cPageSession_BusinessLine._pMECHCODE_processed = True
                            Exit Sub
                        Else
Next_Fee:
                            If cPageSession_BusinessLine._pPLATECODE = True Then
                                cPageSession_BusinessLine._pPLATECODE = False
                                cPageSession_BusinessLine._pBCODE = True
                                cPageSession_BusinessLine._pMECHCODE_processed = True
                                _mFnContinueDataGather()
                            End If
                        End If
                    End If
                End If
            End If
            cPageSession_BusinessLine._pMECHCODE_processed = True
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mAskBLDGCODE() '@ Added 20170811
        Try
            '_oLabelFeeType.Text = "BUILDING FEE"
            cPageSession_BusinessLine._pTaxField = "BLDGCODE"

            cPageSession_BusinessLine._pELECCODE = False
            cPageSession_BusinessLine._pMECHCODE = False
            cPageSession_BusinessLine._pBLDGCODE = True
            cPageSession_BusinessLine._pSIGNCODE = False
            cPageSession_BusinessLine._pEPOCODE = False
            cPageSession_BusinessLine._pEIFCODE = False
            cPageSession_BusinessLine._pPLATECODE = False
            '_mpAsk.Hide()
            If _mFnIfHasRecord_GRADTABL_AIF() = True Then
                cPageSession_BusinessLine._pBLDGCODE_processed = True
                Exit Sub
            ElseIf cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode = Nothing Then
                cPageSession_BusinessLine._pBLDGCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                    _oLabelFeeType.Text = "BUILDING FEE"
                    cPageSession_BusinessLine._pBLDGCODE_processed = True
                    Exit Sub
                ElseIf HasRange(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffMonth) = True Then
                    Dim xTaxBase As Double
                    xTaxBase = cPageSession_BusinessLine._pAREA
                    cPageSession_BusinessLine._pBLDGCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffMonth, xTaxBase, "0")
                    cPageSession_BusinessLine._pBLDGCODE_processed = True
                    Exit Sub

                Else

                    If _mFnIfHasRecord_GROPTION_AIF() = True Then
                        _oLabelFeeType.Text = "BUILDING FEE"
                        cPageSession_BusinessLine._pBLDGCODE_processed = True
                        Exit Sub
                    Else

                        If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                            _oLabelFeeType.Text = "BUILDING FEE"
                            cPageSession_BusinessLine._pBLDGCODE_processed = True
                            Exit Sub
                        Else
Next_Fee:
                            If cPageSession_BusinessLine._pPLATECODE = True Then
                                cPageSession_BusinessLine._pPLATECODE = False
                                cPageSession_BusinessLine._pBCODE = True
                                cPageSession_BusinessLine._pBLDGCODE_processed = True
                                _mFnContinueDataGather()
                            End If
                        End If
                    End If
                End If
            End If
            cPageSession_BusinessLine._pBLDGCODE_processed = True
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mAskSIGNCODE() '@ Added 20170811
        '_oLabelFeeType.Text = "SIGNAGE FEE"
        cPageSession_BusinessLine._pTaxField = "SIGNCODE"

        cPageSession_BusinessLine._pELECCODE = False
        cPageSession_BusinessLine._pMECHCODE = False
        cPageSession_BusinessLine._pBLDGCODE = False
        cPageSession_BusinessLine._pSIGNCODE = True
        cPageSession_BusinessLine._pEPOCODE = False
        cPageSession_BusinessLine._pEIFCODE = False
        cPageSession_BusinessLine._pPLATECODE = False
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL_AIF() = True Then
            cPageSession_BusinessLine._pSIGNCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pSIGNCODE_processed = True
            ' cPageSession_BusinessLine._pSIGNCODE = False
            Exit Sub
        Else

            If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                _oLabelFeeType.Text = "SIGNAGE FEE"
                cPageSession_BusinessLine._pSIGNCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pSIGNCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pSIGNCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION_AIF() = True Then
                    _oLabelFeeType.Text = "SIGNAGE FEE"
                    cPageSession_BusinessLine._pSIGNCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                        _oLabelFeeType.Text = "SIGNAGE FEE"
                        cPageSession_BusinessLine._pSIGNCODE_processed = True
                        Exit Sub
Next_Fee:
                        If cPageSession_BusinessLine._pPLATECODE = True Then
                            cPageSession_BusinessLine._pPLATECODE = False
                            cPageSession_BusinessLine._pBCODE = True
                            cPageSession_BusinessLine._pSIGNCODE_processed = True
                            _mFnContinueDataGather()
                        End If
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pSIGNCODE_processed = True
    End Sub

    Public Sub _mAskEPOCODE() '@ Added 20170811
        Dim _nClass As New cDalBusinessLine
        '_nClass._mSubGetAIF_Desc()
        'cPageSession_BusinessLine._pLabelFee = _nClass._pEPO
        '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee

        cPageSession_BusinessLine._pTaxField = "EPOCODE"

        cPageSession_BusinessLine._pELECCODE = False
        cPageSession_BusinessLine._pMECHCODE = False
        cPageSession_BusinessLine._pBLDGCODE = False
        cPageSession_BusinessLine._pSIGNCODE = False
        cPageSession_BusinessLine._pEPOCODE = True
        cPageSession_BusinessLine._pEIFCODE = False
        cPageSession_BusinessLine._pPLATECODE = False

        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL_AIF() = True Then
            cPageSession_BusinessLine._pEPOCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode = Nothing Then
            'cPageSession_BusinessLine._pEPOCODE = False
            cPageSession_BusinessLine._pEPOCODE_processed = True
            Exit Sub
        Else
            '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
            If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
                cPageSession_BusinessLine._pEPOCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pEPOCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pEPOCODE_processed = True
                Exit Sub
            Else
                '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                If _mFnIfHasRecord_GROPTION_AIF() = True Then
                    _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                    cPageSession_BusinessLine._pEPOCODE_processed = True
                    Exit Sub
                Else
                    '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                    If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                        _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                        cPageSession_BusinessLine._pEPOCODE_processed = True
                        Exit Sub
                    Else
Next_Fee:
                        If cPageSession_BusinessLine._pPLATECODE = True Then
                            cPageSession_BusinessLine._pPLATECODE = False
                            cPageSession_BusinessLine._pBCODE = True
                            cPageSession_BusinessLine._pEPOCODE_processed = True
                            _mFnContinueDataGather()
                        End If
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pEPOCODE_processed = True
    End Sub

    Public Sub _mAskEIFCODE() '@ Added 20170811

        'Dim _nClass As New cDalBusinessLine
        '_nClass._mSubGetAIF_Desc()
        'cPageSession_BusinessLine._pLabelFee = _nClass._pEIF
        '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee

        cPageSession_BusinessLine._pTaxField = "EIFCODE"

        cPageSession_BusinessLine._pELECCODE = False
        cPageSession_BusinessLine._pMECHCODE = False
        cPageSession_BusinessLine._pBLDGCODE = False
        cPageSession_BusinessLine._pSIGNCODE = False
        cPageSession_BusinessLine._pEPOCODE = False
        cPageSession_BusinessLine._pEIFCODE = True
        cPageSession_BusinessLine._pPLATECODE = False


        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL_AIF() = True Then
            cPageSession_BusinessLine._pEIFCODE_processed = True
            Exit Sub

        ElseIf cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pEIFCODE_processed = True
            'cPageSession_BusinessLine._pEIFCODE = False
            Exit Sub
        Else
            '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
            If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
                cPageSession_BusinessLine._pEIFCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pEIFCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pEIFCODE_processed = True
                Exit Sub
            Else
                '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                If _mFnIfHasRecord_GROPTION_AIF() = True Then
                    _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                    cPageSession_BusinessLine._pEIFCODE_processed = True
                    Exit Sub
                Else
                    '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                    If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                        _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                        cPageSession_BusinessLine._pEIFCODE_processed = True
                        Exit Sub
                    Else
Next_Fee:
                        If cPageSession_BusinessLine._pPLATECODE = True Then
                            cPageSession_BusinessLine._pPLATECODE = False
                            cPageSession_BusinessLine._pBCODE = True
                            _mFnContinueDataGather()
                        End If
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pEIFCODE_processed = True
    End Sub

    Public Sub _mAskPLATECODE() '@ Added 20170811
        'Dim _nClass As New cDalBusinessLine
        '_nClass._mSubGetAIF_Desc()
        'cPageSession_BusinessLine._pLabelFee = _nClass._pPLATE
        '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee
        cPageSession_BusinessLine._pTaxField = "PLATECODE"

        cPageSession_BusinessLine._pELECCODE = False
        cPageSession_BusinessLine._pMECHCODE = False
        cPageSession_BusinessLine._pBLDGCODE = False
        cPageSession_BusinessLine._pSIGNCODE = False
        cPageSession_BusinessLine._pEPOCODE = False
        cPageSession_BusinessLine._pEIFCODE = False
        cPageSession_BusinessLine._pPLATECODE = True
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL_AIF() = True Then
            cPageSession_BusinessLine._pPLATECODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pPLATECODE_processed = True
            GoTo Next_Fee
            Exit Sub
        Else


            If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
                cPageSession_BusinessLine._pPLATECODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffYear, cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pPLATECODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffYear, cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pPLATECODE_processed = True
                Exit Sub
            Else


                If _mFnIfHasRecord_GROPTION_AIF() = True Then
                    _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                    cPageSession_BusinessLine._pPLATECODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                        _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                        cPageSession_BusinessLine._pPLATECODE_processed = True
                        Exit Sub
                    Else
Next_Fee:
                        cPageSession_BusinessLine._pPLATECODE = False
                        cPageSession_BusinessLine._pExit_ELECCODE = False
                        cPageSession_BusinessLine._pExit_MECHCODE = False
                        cPageSession_BusinessLine._pExit_BLDGCODE = False
                        cPageSession_BusinessLine._pExit_SIGNCODE = False
                        cPageSession_BusinessLine._pExit_EPOCODE = False
                        cPageSession_BusinessLine._pExit_EIFCODE = False

                        cPageSession_BusinessLine._pBCODE = True
                        cPageSession_BusinessLine._pPLATECODE_processed = True
                        '_mFnContinueDataGather()
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pPLATECODE_processed = True
    End Sub

    '=====================================================================================
    Private Function _mFnIfHasRecord_GRADTABL_AIF() As Boolean     'Active  '@  Added 20170420
        Try
            '----------------------------------
            _mFnIfHasRecord_GRADTABL_AIF = False
            ' _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRADTABL"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            ' _nClass._pSubCheckGradTable()
            _nClass._pSubSelect_GRADTABL()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    '_mFnIfHasRecord_GRADTABL = True
                    '_oPanel_Ask.Visible = True
                    '_mpAsk.Show()
                    _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
                    _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
                    _nClass._pTblCode = cPageSession_BusinessLine._pTblCode

                    _nClass._mSubGetGRADTABLValue()
                    Select Case True
                        Case cPageSession_BusinessLine._pELECCODE
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pMECHCODE
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pBLDGCODE
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pSIGNCODE
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pEPOCODE
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pEIFCODE
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pPLATECODE
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                    End Select

                    If _nClass._pTaxAmt <> 0.0 Then

                        '-------------------------------------------------------------------------
                        ' Get Tax Amount for comparison of Min and Max

                        _mFnIfHasRecord_GRADTABL_AIF = True
                        Select Case True
                            Case cPageSession_BusinessLine._pELECCODE
                                cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pELECCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pMECHCODE
                                cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pMECHCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pBLDGCODE
                                cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pBLDGCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pSIGNCODE
                                cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pSIGNCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pEPOCODE
                                cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pEPOCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pEIFCODE
                                cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pEIFCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pPLATECODE
                                cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pPLATECODE_FEE = _nClass._pTaxAmt

                        End Select
                        Return True
                        '-------------------------------------------------------------------------
                        ' _mFnExitTrigger_True()
                        Exit Function 'Exit
                    ElseIf _nClass._pTaxRate <> 0.0 Then ' @ Added 20170801
                        ' Get TAXCODE, YEAR and MONTH then Refer to GRRANGE
                        Select Case True
                            Case cPageSession_BusinessLine._pELECCODE
                                cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pELECCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pMECHCODE
                                cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pMECHCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pBLDGCODE
                                cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pBLDGCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pSIGNCODE
                                cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pSIGNCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pEPOCODE
                                cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pEPOCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pEIFCODE
                                cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pEIFCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pPLATECODE
                                cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pPLATECODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                        End Select
                        Return False
                    End If
                Else
                    Return False
                    Exit Function 'Exit
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

    Private Function _mFnIfHasRecord_GRASKHDG_AIF() As Boolean '@ Added 20170811 ACTIVE 

        Try
            '----------------------------------
            _mFnIfHasRecord_GRASKHDG_AIF = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRASKHDG"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pSubCheck_GRASKHDG()
            '_nClass._pSubSelect_GRASKHDG()

            'If cPageSession_BusinessLine._pTaxCode2Mode = False Then
            '    _nClass._pSubSelect_GRASKHDG()
            'Else
            '    _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
            '    _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
            '    _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
            '    _nClass._pSubSelect_GRASKHDG_TaxCode2()
            'End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRASKHDG_AIF = True

                    _oPanel1_Ask.Visible = False
                    _oPanel2_Ask.Visible = False
                    _oPanel3_Ask.Visible = False
                    _oPanel4_Ask.Visible = False
                    _oPanel5_Ask.Visible = False
                    _oPanel6_Ask.Visible = False
                    _oPanel7_Ask.Visible = False
                    _oPanel8_Ask.Visible = False
                    _oPanel9_Ask.Visible = False
                    _oPanel10_Ask.Visible = False

                    _mSubCollectAskHeading(_nDataTable)

                    '_nClass._mSubGetQuestions_GRASKHDG()
                    ''@  Added   20170420    -----------------------
                    ''_mSubShowHideInputTextBox()
                    '' Ask info. GRASKHDG
                    ''---------------------------------
                    'If _nClass._pShowPanel1 = True Then
                    '    _oPanel1_Ask.Visible = True
                    '    _oLabel1_Ask.Text = _nClass._pOutputRec1
                    '    _oLabel1_Ask.Visible = True
                    '    _oTextBox1_Ask.Text = Nothing

                    '    If _nClass._pShowPanel2 = True Then
                    '        _oPanel2_Ask.Visible = True
                    '        _oLabel2_Ask.Text = _nClass._pOutputRec2
                    '        _oTextBox2_Ask.Text = Nothing

                    '        If _nClass._pShowPanel3 = True Then
                    '            _oPanel3_Ask.Visible = True
                    '            _oLabel3_Ask.Text = _nClass._pOutputRec3
                    '            _oTextBox3_Ask.Text = Nothing

                    '            If _nClass._pShowPanel4 = True Then
                    '                _oPanel4_Ask.Visible = True
                    '                _oLabel4_Ask.Text = _nClass._pOutputRec4
                    '                _oTextBox4_Ask.Text = Nothing

                    '                If _nClass._pShowPanel5 = True Then
                    '                    _oPanel5_Ask.Visible = True
                    '                    _oLabel5_Ask.Text = _nClass._pOutputRec5
                    '                    _oTextBox5_Ask.Text = Nothing

                    '                    If _nClass._pShowPanel6 = True Then
                    '                        _oPanel6_Ask.Visible = True
                    '                        _oLabel6_Ask.Text = _nClass._pOutputRec6
                    '                        _oTextBox6_Ask.Text = Nothing

                    '                        If _nClass._pShowPanel7 = True Then
                    '                            _oPanel7_Ask.Visible = True
                    '                            _oLabel7_Ask.Text = _nClass._pOutputRec7
                    '                            _oTextBox7_Ask.Text = Nothing

                    '                            If _nClass._pShowPanel8 = True Then
                    '                                _oPanel8_Ask.Visible = True
                    '                                _oLabel8_Ask.Text = _nClass._pOutputRec8
                    '                                _oTextBox8_Ask.Text = Nothing

                    '                                If _nClass._pShowPanel9 = True Then
                    '                                    _oPanel9_Ask.Visible = True
                    '                                    _oLabel9_Ask.Text = _nClass._pOutputRec9
                    '                                    _oTextBox9_Ask.Text = Nothing

                    '                                    If _nClass._pShowPanel10 = True Then
                    '                                        _oPanel10_Ask.Visible = True
                    '                                        _oLabel10_Ask.Text = _nClass._pOutputRec10
                    '                                        _oTextBox10_Ask.Text = Nothing
                    '                                    Else
                    '                                        _oPanel10_Ask.Visible = False
                    '                                    End If
                    '                                Else
                    '                                    _oPanel9_Ask.Visible = False
                    '                                End If
                    '                            Else
                    '                                _oPanel8_Ask.Visible = False
                    '                            End If
                    '                        Else
                    '                            _oPanel7_Ask.Visible = False
                    '                        End If
                    '                    Else
                    '                        _oPanel6_Ask.Visible = False
                    '                    End If
                    '                Else
                    '                    _oPanel5_Ask.Visible = False
                    '                End If
                    '            Else
                    '                _oPanel4_Ask.Visible = False
                    '            End If
                    '        Else
                    '            _oPanel3_Ask.Visible = False
                    '        End If
                    '    Else
                    '        _oPanel2_Ask.Visible = False
                    '    End If
                    'Else
                    '    _oPanel1_Ask.Visible = False
                    'End If

                    '---------------------------------
                    cPageSession_BusinessLine._pHeadingMode = True
                    cPageSession_BusinessLine._pOptionMode = False
                    cPageSession_BusinessLine._pQtyMode = False


                    '' ---- @ Added 20170823
                    If InStr(1, _nClass._pOutputRec1, "[AREA]") <> 0 Then '20170120
                        _oTextBox1_Ask.Text = _otextCapital.Text

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[GC]") <> 0 Then '20170120
                        _oTextBox1_Ask.Text = _otextCapital.Text

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[C]") <> 0 Then '20170120
                        _oTextBox1_Ask.Text = _otextCapital.Text

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[CORG]") <> 0 Then '20170122  'replace [CorG] to uppercase 20170126
                        _oTextBox1_Ask.Text = _otextCapital.Text

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    Else
                        If _oPanel1_Ask.Visible = False Then
                            _oPanel_Ask.Visible = False
                            _mFnExitTrigger_False_AIF() '' Continiue Procedure
                            _mFnIfHasRecord_GRASKHDG_AIF = False
                        Else
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanel_Ask.Focus()
                            _mFnExitTrigger_False_AIF() '' Exit Gather Info procedure to giveway for Pop Modal
                            '_oButtonTaxSave.Text = "Save"
                            _oButtonTaxSave.Enabled = True
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            Return True
                        End If
                    End If

                Else
                    _mFnExitTrigger_False_AIF() '' Continiue Procedure
                    _oPanel_Ask.Visible = False
                    Return False
                    Exit Function 'Exit
                End If
            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function


    'Protected Sub ShowPopup()
    '    Dim title As String = ""

    '    ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" & title & "');", True)


    'End Sub
    Private Function _mFnIfHasRecord_GRASKQTY_AIF() As Boolean '@  Added 20170428 ACTIVE

        Try
            '----------------------------------
            _mFnIfHasRecord_GRASKQTY_AIF = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRASKQTY"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            _nClass._pSubSelect_GRASKQTY()
            'If cPageSession_BusinessLine._pTaxCode2Mode = False Then
            '    _nClass._pSubSelect_GRASKQTY()
            'Else
            '    _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
            '    _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
            '    _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
            '    _nClass._pSubSelect_GRASKQTY_TaxCode2()
            'End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRASKQTY_AIF = True

                    _nClass._mSubGetQuestions_GRASKQTY()
                    ' Ask info. GRASKQTY

                    '----------------
                    If _nClass._pShowPanel1 = True Then
                        _oPanel1_Ask.Visible = True
                        _oLabel1_Ask.Text = _nClass._pOutputRec1
                        _oLabel1_Ask.Visible = True
                        _oTextBox1_Ask.Text = Nothing
                        cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt2 = _nClass._pTaxAmt1

                        If _nClass._pShowPanel2 = True Then
                            _oPanel2_Ask.Visible = True
                            _oLabel2_Ask.Text = _nClass._pOutputRec2
                            cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt2 = _nClass._pTaxAmt2
                            _oTextBox2_Ask.Text = Nothing

                            If _nClass._pShowPanel3 = True Then
                                _oPanel3_Ask.Visible = True
                                _oLabel3_Ask.Text = _nClass._pOutputRec3
                                cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt3 = _nClass._pTaxAmt3
                                _oTextBox3_Ask.Text = Nothing

                                If _nClass._pShowPanel4 = True Then
                                    _oPanel4_Ask.Visible = True
                                    _oLabel4_Ask.Text = _nClass._pOutputRec4
                                    cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt4 = _nClass._pTaxAmt4
                                    _oTextBox4_Ask.Text = Nothing

                                    If _nClass._pShowPanel5 = True Then
                                        _oPanel5_Ask.Visible = True
                                        _oLabel5_Ask.Text = _nClass._pOutputRec5
                                        cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt5 = _nClass._pTaxAmt5
                                        _oTextBox5_Ask.Text = Nothing

                                        If _nClass._pShowPanel6 = True Then
                                            _oPanel6_Ask.Visible = True
                                            _oLabel6_Ask.Text = _nClass._pOutputRec6
                                            cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt6 = _nClass._pTaxAmt6
                                            _oTextBox6_Ask.Text = Nothing

                                            If _nClass._pShowPanel7 = True Then
                                                _oPanel7_Ask.Visible = True
                                                _oLabel7_Ask.Text = _nClass._pOutputRec7
                                                cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt7 = _nClass._pTaxAmt7
                                                _oTextBox7_Ask.Text = Nothing

                                                If _nClass._pShowPanel8 = True Then
                                                    _oPanel8_Ask.Visible = True
                                                    _oLabel8_Ask.Text = _nClass._pOutputRec8
                                                    cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt8 = _nClass._pTaxAmt8
                                                    _oTextBox8_Ask.Text = Nothing

                                                    If _nClass._pShowPanel9 = True Then
                                                        _oPanel9_Ask.Visible = True
                                                        _oLabel9_Ask.Text = _nClass._pOutputRec9
                                                        cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt9 = _nClass._pTaxAmt9
                                                        _oTextBox9_Ask.Text = Nothing

                                                        If _nClass._pShowPanel10 = True Then
                                                            _oPanel10_Ask.Visible = True
                                                            _oLabel10_Ask.Text = _nClass._pOutputRec10
                                                            cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt10 = _nClass._pTaxAmt10
                                                            _oTextBox10_Ask.Text = Nothing
                                                        Else
                                                            _oPanel10_Ask.Visible = False
                                                        End If
                                                    Else
                                                        _oPanel9_Ask.Visible = False
                                                    End If
                                                Else
                                                    _oPanel8_Ask.Visible = False
                                                End If
                                            Else
                                                _oPanel7_Ask.Visible = False
                                            End If
                                        Else
                                            _oPanel6_Ask.Visible = False
                                        End If
                                    Else
                                        _oPanel5_Ask.Visible = False
                                    End If
                                Else
                                    _oPanel4_Ask.Visible = False
                                End If
                            Else
                                _oPanel3_Ask.Visible = False
                            End If
                        Else
                            _oPanel2_Ask.Visible = False
                        End If
                    Else
                        _oPanel1_Ask.Visible = False
                    End If

                    '---------------------------------
                    cPageSession_BusinessLine._pHeadingMode = False
                    cPageSession_BusinessLine._pOptionMode = False
                    cPageSession_BusinessLine._pQtyMode = True


                    '' ---- @ Added 20210528
                    If InStr(1, _nClass._pOutputRec1, "[AREA]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[GC]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[C]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[CORG]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    Else

                        If _oPanel1_Ask.Visible = False Then
                            _oPanel_Ask.Visible = False
                            _mFnExitTrigger_False_AIF() '' Continiue Procedure
                            _mFnIfHasRecord_GRASKQTY_AIF = False
                        Else
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            _oButtonTaxSave.Enabled = True
                            '_oButtonTaxSave.Text = "Save"
                            _mFnExitTrigger_True_AIF() '

                            _oButtonTaxSave.Enabled = True
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            Return True

                        End If

                    End If

                Else
                    _mFnExitTrigger_False_AIF() '
                    _oPanel_Ask.Visible = False
                    Return False
                    Exit Function 'Exit
                End If

            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GRRANGE() As Boolean ' @ Added 20170504
        Try
            '----------------------------------
            _mFnIfHasRecord_GRRANGE = False

            cPageSession_BusinessLine._pTblCode = "GRRANGE"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            _nClass._pSubSelect_GRRANGE()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRRANGE = True
                Else
                    Return False
                    Exit Function

                End If

            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GROPTION_AIF() As Boolean '@  Added 20170428

        Try
            '----------------------------------
            _mFnIfHasRecord_GROPTION_AIF = False

            cPageSession_BusinessLine._pTblCode = "GROPTION"
            '_oPanel_oGridViewOption.Visible = False

            Dim _nGridView As New GridView
            _nGridView = _oGridViewOption
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            _nClass._pSubSelect_GROPTION()
            'If cPageSession_BusinessLine._pTaxCode2Mode = False Then
            '    _nClass._pSubSelect_GROPTION()
            'Else
            '    _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
            '    _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
            '    _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
            '    _nClass._pSubSelect_GROPTION_TaxCode2()
            'End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GROPTION_AIF = True
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()   '

                    ''_oPanel_oGridViewOption.Height = 150
                    _oPanel_oGridViewOption.Visible = True
                    cPageSession_BusinessLine._pHeadingMode = False
                    cPageSession_BusinessLine._pOptionMode = True
                    cPageSession_BusinessLine._pQtyMode = False
                    _oPanel_Ask.Visible = True
                    ShowPopup()
                    _nFnHide_PanelAsk()
                    _mFnExitTrigger_True_AIF() '

                    '_oButtonTaxSave.Text = "Save"
                    _oButtonTaxSave.Enabled = True
                    _oPanel_Ask.Visible = True
                    _oPanelProcess.Visible = False
                    '_mpAsk.Show()
                    Return True



                    ' Ask info. GRASKHDG

                Else
                    _mFnExitTrigger_False_AIF()

                    _oPanel_oGridViewOption.Visible = False
                    ''_oPanel_oGridViewOption.Height = 25
                    Return False
                    Exit Function 'Exit
                End If
                cPageSession_BusinessLine._pRowCountBuslineOption = _nDataTable.Rows.Count
            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub _mFnExitTrigger_False_AIF()
        Dim _mExitCode As String
        _mExitCode = cPageSession_BusinessLine._pTaxField

        Select Case _mExitCode  ' @ Modified 20170621
            Case "ELECCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "MECHCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "BLDGCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "SIGNCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "EPOCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "EIFCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "PLATECODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
        End Select

    End Sub

    Private Sub _mFnExitTrigger_True_AIF()
        Dim _mExitCode As String
        _mExitCode = cPageSession_BusinessLine._pTaxField

        Select Case _mExitCode  ' @ Modified 20170621
            Case "ELECCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = True
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "MECHCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = True
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "BLDGCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = True
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "SIGNCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = True
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "EPOCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = True
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "EIFCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = True
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "PLATECODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = True
        End Select

    End Sub


#End Region

#Region "FOR AIF AND BASIC FEES"

    Private Sub _nFnHide_PanelAsk()  '20171113 Added LOuie
        _oPanel1_Ask.Visible = False
        _oPanel2_Ask.Visible = False
        _oPanel3_Ask.Visible = False
        _oPanel4_Ask.Visible = False
        _oPanel5_Ask.Visible = False
        _oPanel6_Ask.Visible = False
        _oPanel7_Ask.Visible = False
        _oPanel8_Ask.Visible = False
        _oPanel9_Ask.Visible = False
        _oPanel10_Ask.Visible = False
        ' _oPanel_oGridViewOption.Visible = False
    End Sub

    Private Sub _mFnContinueDataGather()
        Select Case True
            Case cPageSession_BusinessLine._pELECCODE
                _mAskELECCODE()
                If cPageSession_BusinessLine._pExit_ELECCODE = False Then
                    _mAskMECHCODE()
                Else
                    cPageSession_BusinessLine._pExit_ELECCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MECHCODE = False Then
                    _mAskBLDGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MECHCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BLDGCODE = False Then
                    _mAskSIGNCODE()
                Else
                    cPageSession_BusinessLine._pExit_BLDGCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                    _mAskEPOCODE()
                Else
                    cPageSession_BusinessLine._pExit_SIGNCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If

                '---------- Continue until basic fees ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pMECHCODE
                _mAskMECHCODE()
                If cPageSession_BusinessLine._pExit_MECHCODE = False Then
                    _mAskBLDGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MECHCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BLDGCODE = False Then
                    _mAskSIGNCODE()
                Else
                    cPageSession_BusinessLine._pExit_BLDGCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                    _mAskEPOCODE()
                Else
                    cPageSession_BusinessLine._pExit_SIGNCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
                '---------- Continue until basic fees ' remarkes 20200115
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pBLDGCODE
                _mAskBLDGCODE()
                If cPageSession_BusinessLine._pExit_BLDGCODE = False Then
                    _mAskSIGNCODE()
                Else
                    cPageSession_BusinessLine._pExit_BLDGCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                    _mAskEPOCODE()
                Else
                    cPageSession_BusinessLine._pExit_SIGNCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
                ''---------- Continue until basic fees ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pSIGNCODE
                _mAskSIGNCODE()
                If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                    _mAskEPOCODE()
                Else
                    cPageSession_BusinessLine._pExit_SIGNCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
                ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pEPOCODE
                _mAskEPOCODE()
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
                ''---------- Continue until basic fees ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pEIFCODE
                _mAskEIFCODE()
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pPLATECODE
                _mAskPLATECODE()
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                ''---------- Continue until basic fees ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If

            Case cPageSession_BusinessLine._pBCODE
                _mAskBCODE()
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If

            Case cPageSession_BusinessLine._pMCODE
                _mAskMCODE()
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    Exit Sub
                End If

            Case cPageSession_BusinessLine._pGCODE
                _mAskGCODE()
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    Exit Sub
                End If

            Case cPageSession_BusinessLine._pSCODE
                _mAskSCODE()
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pFCODE
                cPageSession_BusinessLine._pTaxCode2Mode = False
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskFCODE()
        End Select


    End Sub

    Private Function _mFnIfHasRecord_GRADTABL() As Boolean     'Active  '@  Added 20170420
        Try
            '----------------------------------
            _mFnIfHasRecord_GRADTABL = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRADTABL"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            ' cPageSession_BusinessLine._pTaxCode2Mode = False

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._pSubSelect_GRADTABL()
            Else
                _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
                _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
                _nClass._pSubSelect_GRADTABL_TaxCode2()
            End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    '_mFnIfHasRecord_GRADTABL = True
                    '_oPanel_Ask.Visible = True
                    '_mpAsk.Show()
                    _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
                    _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
                    _nClass._pTblCode = cPageSession_BusinessLine._pTblCode

                    _nClass._mSubGetGRADTABLValue()
                    Select Case True
                        Case cPageSession_BusinessLine._pBCODE
                            cPageSession_BusinessLine._pBCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pBCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pBCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pBCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pBCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pMCODE
                            cPageSession_BusinessLine._pMCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pMCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pMCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pMCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pMCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pGCODE
                            cPageSession_BusinessLine._pGCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pGCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pGCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pGCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pGCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pSCODE
                            cPageSession_BusinessLine._pSCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pSCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pSCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pSCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pSCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pFCODE
                            cPageSession_BusinessLine._pFCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pFCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pFCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pFCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pFCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                    End Select

                    If _nClass._pTaxAmt <> 0.0 Then

                        '-------------------------------------------------------------------------
                        ' Get Tax Amount for comparison of Min and Max
                        _mFnIfHasRecord_GRADTABL = True

                        Select Case True
                            Case cPageSession_BusinessLine._pBCODE
                                cPageSession_BusinessLine._pBCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                            Case cPageSession_BusinessLine._pMCODE
                                cPageSession_BusinessLine._pMCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                            Case cPageSession_BusinessLine._pGCODE
                                cPageSession_BusinessLine._pGCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                            Case cPageSession_BusinessLine._pSCODE
                                cPageSession_BusinessLine._pSCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                            Case cPageSession_BusinessLine._pFCODE
                                cPageSession_BusinessLine._pFCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                        End Select
                        '-------------------------------------------------------------------------
                        ' _mFnExitTrigger_True()
                        Return True
                        Exit Function 'Exit
                    ElseIf _nClass._pTaxRate <> 0.0 Then ' @ Added 20170713
                        ' Get TAXCODE, YEAR and MONTH then Refer to GRRANGE
                        Select Case True
                            Case cPageSession_BusinessLine._pBCODE
                                cPageSession_BusinessLine._pBCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                            Case cPageSession_BusinessLine._pMCODE
                                cPageSession_BusinessLine._pMCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                            Case cPageSession_BusinessLine._pGCODE
                                cPageSession_BusinessLine._pGCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                            Case cPageSession_BusinessLine._pSCODE
                                cPageSession_BusinessLine._pSCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                            Case cPageSession_BusinessLine._pFCODE
                                cPageSession_BusinessLine._pFCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                        End Select
                        Return False
                    End If

                Else
                    Return False
                    Exit Function 'Exit
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

    Private Sub _mSubCollectAskHeading(_nDataTable As DataTable)
        Try
            Dim _nRow As Integer = 0
            For Each nDataRow As DataRow In _nDataTable.Rows
                Select Case _nRow
                    Case 0
                        _oPanel1_Ask.Visible = True
                        _oLabel1_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel1_Ask.Visible = True
                        _oTextBox1_Ask.Text = Nothing
                    Case 1
                        _oPanel2_Ask.Visible = True
                        _oLabel2_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel2_Ask.Visible = True
                        _oTextBox2_Ask.Text = Nothing
                    Case 2
                        _oPanel3_Ask.Visible = True
                        _oLabel3_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel3_Ask.Visible = True
                        _oTextBox3_Ask.Text = Nothing
                    Case 3
                        _oPanel4_Ask.Visible = True
                        _oLabel4_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel4_Ask.Visible = True
                        _oTextBox4_Ask.Text = Nothing
                    Case 4
                        _oPanel5_Ask.Visible = True
                        _oLabel5_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel5_Ask.Visible = True
                        _oTextBox5_Ask.Text = Nothing
                    Case 5
                        _oPanel6_Ask.Visible = True
                        _oLabel6_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel6_Ask.Visible = True
                        _oTextBox6_Ask.Text = Nothing
                    Case 6
                        _oPanel7_Ask.Visible = True
                        _oLabel7_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel7_Ask.Visible = True
                        _oTextBox7_Ask.Text = Nothing
                    Case 7
                        _oPanel8_Ask.Visible = True
                        _oLabel8_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel8_Ask.Visible = True
                        _oTextBox8_Ask.Text = Nothing
                    Case 8
                        _oPanel9_Ask.Visible = True
                        _oLabel9_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel9_Ask.Visible = True
                        _oTextBox9_Ask.Text = Nothing
                    Case 9
                        _oPanel10_Ask.Visible = True
                        _oLabel10_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel10_Ask.Visible = True
                        _oTextBox10_Ask.Text = Nothing
                End Select

                _nRow = _nRow + 1
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Function _mFnCallClssAIF_RANGE(ByVal XTaxCode As String, ByVal xEff_Yr As String, ByVal xEff_Mo As String, ByVal xTaxbase As Double, ByVal xServices As String) As Double
        Try
            _mFnCallClssAIF_RANGE = 0
            Dim _nClass As New cDalBusinessLine
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

                Dim _nClssBPLTAS As New BPLTAS_AIFASKRANGE_OL.ClsAIFRange
                Dim x As String = Nothing

                '_nClssBPLTAS.BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                '_nClssBPLTAS.BPLTAS_xUID = "juan.dela.cruz"
                '_nClssBPLTAS.BPLTAS_xPW = "#P@ssw0rd#"

                '_nClssBPLTAS.LIVE_BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                '_nClssBPLTAS.LIVE_BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                '_nClssBPLTAS.LIVE_BPLTAS_xUID = "sa"
                '_nClssBPLTAS.LIVE_BPLTAS_xPW = "P@ssw0rd"


                'BPLTIMS
                Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
                _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
                _nClBPLTIMS._pSubRecordSelectSpecific()

                _nClssBPLTAS.BPLTAS_SERVER = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                _nClssBPLTAS.BPLTAS_xDataBase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                _nClssBPLTAS.BPLTAS_xUID = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
                _nClssBPLTAS.BPLTAS_xPW = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"

                'BPLTAS LIVE
                Dim _nClBP As New cDalGlobalConnectionsDefault
                _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                _nClBP._pSubRecordSelectSpecific()

                _nClssBPLTAS.LIVE_BPLTAS_SERVER = _nClBP._pDBDataSource ' cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                _nClssBPLTAS.LIVE_BPLTAS_xDataBase = _nClBP._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                _nClssBPLTAS.LIVE_BPLTAS_xUID = _nClBP._pDBUserID '"sa"
                _nClssBPLTAS.LIVE_BPLTAS_xPW = _nClBP._pDBUserKey '"P@ssw0rd"


                ' "128.1.14.4\MSSQL2012DEV"
                '"R&D.BPLTIMS"
                _nClssBPLTAS.BPLTAS_xTaxbase = xTaxbase
                _nClssBPLTAS.BPLTAS_xTaxcode = XTaxCode
                _nClssBPLTAS.BPLTAS_xEff_Yr = xEff_Yr
                _nClssBPLTAS.BPLTAS_xEff_Mo = xEff_Mo
                _nClssBPLTAS.BPLTAS_xIsServices = xServices

                _nClssBPLTAS.pSub_AIF_RANGE()

                _mFnCallClssAIF_RANGE = _nClssBPLTAS.pAIFDue

            End With
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function HasRange(ByVal Taxcode As String, ByVal EffYr As String, ByVal EffMo As String) As Boolean
        Try
            HasRange = False

            Dim _nClass As New cDalBusinessLine
            _nClass._mSubCheckGRANGE(Taxcode, EffMo, EffYr)

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            If _nDataTable.Rows.Count <> 0 Then
                HasRange = True
            End If
        Catch ex As Exception
            HasRange = False
        End Try
    End Function

    Private Sub _mCheckInputedData()    '@  Added 20170427
        Dim _nClass As New cDalBusinessLine
        '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        If _oTextBox1_Ask.Text <> "" Then   '@ 20170428
            _mSubSaveInputedData_Textbox1()
            If _oTextBox2_Ask.Text <> "" Then
                _mSubSaveInputedData_Textbox2()
                If _oTextBox3_Ask.Text <> "" Then
                    _mSubSaveInputedData_Textbox3()
                    If _oTextBox4_Ask.Text <> "" Then
                        _mSubSaveInputedData_Textbox4()
                        If _oTextBox5_Ask.Text <> "" Then
                            _mSubSaveInputedData_Textbox5()
                            If _oTextBox6_Ask.Text <> "" Then
                                _mSubSaveInputedData_Textbox6()
                                If _oTextBox7_Ask.Text <> "" Then
                                    _mSubSaveInputedData_Textbox7()
                                    If _oTextBox8_Ask.Text <> "" Then
                                        _mSubSaveInputedData_Textbox8()
                                        If _oTextBox9_Ask.Text <> "" Then
                                            _mSubSaveInputedData_Textbox9()
                                            If _oTextBox10_Ask.Text <> "" Then
                                                _mSubSaveInputedData_Textbox10()
                                            Else
                                                GoTo Here
                                            End If
                                        Else
                                            GoTo Here
                                        End If
                                    Else
                                        GoTo Here
                                    End If
                                Else
                                    GoTo Here
                                End If
                            Else
                                GoTo Here
                            End If
                        Else
                            GoTo Here
                        End If
                    Else
                        GoTo Here
                    End If
                Else
                    GoTo Here
                End If
            Else
                GoTo Here
            End If
        Else
            GoTo Here
        End If
Here:
        Select Case True
            Case cPageSession_BusinessLine._pELECCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = True
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pMECHCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = True
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pBLDGCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = True
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pSIGNCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = True
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pEPOCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = True
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pEIFCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = True
            Case cPageSession_BusinessLine._pPLATECODE
                cPageSession_BusinessLine._pPLATECODE = False
                cPageSession_BusinessLine._pBCODE = True

            Case cPageSession_BusinessLine._pBCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = True
                cPageSession_BusinessLine._pGCODE = False
                cPageSession_BusinessLine._pSCODE = False
                cPageSession_BusinessLine._pFCODE = False
            Case cPageSession_BusinessLine._pMCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = False
                cPageSession_BusinessLine._pGCODE = True
                cPageSession_BusinessLine._pSCODE = False
                cPageSession_BusinessLine._pFCODE = False
            Case cPageSession_BusinessLine._pGCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = False
                cPageSession_BusinessLine._pGCODE = False
                cPageSession_BusinessLine._pSCODE = True
                cPageSession_BusinessLine._pFCODE = False
            Case cPageSession_BusinessLine._pSCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = False
                cPageSession_BusinessLine._pGCODE = False
                cPageSession_BusinessLine._pSCODE = False
                cPageSession_BusinessLine._pFCODE = True
            Case cPageSession_BusinessLine._pFCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = False
                cPageSession_BusinessLine._pGCODE = False
                cPageSession_BusinessLine._pSCODE = False
                cPageSession_BusinessLine._pFCODE = False
                '' cPageSession_BusinessLine._pGCODE = True
        End Select
        cPageSession_BusinessLine._pTaxCode2Mode = False
        _mFnContinueDataGather()

        '''Select Case True        '   @ Added 20170819
        '''    Case cPageSession_BusinessLine._pExit_BCODE
        '''        _mAskMCODE()
        '''    Case cPageSession_BusinessLine._pExit_MCODE
        '''        _mAskGCODE()
        '''    Case cPageSession_BusinessLine._pExit_GCODE
        '''        _mAskSCODE()
        '''    Case cPageSession_BusinessLine._pExit_SCODE ' @ Added 20170627
        '''        _mAskFCODE()
        '''End Select

    End Sub

    Private Sub _GetSelectGridviewIndex(_nGridview As GridView)

        Try

            If _nGridview.SelectedRow IsNot Nothing Then
                cPageSession_BusinessLine._pRowCountBuslineOption = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                cPageSession_BusinessLine._pOptionTaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                cPageSession_BusinessLine._pOptionBusDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                cPageSession_BusinessLine._pOptionTaxCode2 = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode2"), Label).Text)
                cPageSession_BusinessLine._pOptionTaxRate = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxRate"), Label).Text)
                cPageSession_BusinessLine._pOptionTaxAmt = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                ''''''   Added   20170511
                cPageSession_BusinessLine._pEff_Month = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Month"), Label).Text)
                cPageSession_BusinessLine._pEff_Year = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                ''''''   Added   20170616
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pBCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pBCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pBCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pBCHOICE_trg = True
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pMCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pMCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pMCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pMCHOICE_trg = True
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pGCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pGCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pGCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pGCHOICE_trg = True
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pSCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pSCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pSCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pSCHOICE_trg = True
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pFCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pFCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pFCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pFCHOICE_trg = True
                End Select


            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub _mSubSaveSelectedValue() '@ Added 20170502

        _GetSelectGridviewIndex(_oGridViewOption)

        cPageSession_BusinessLine._pTaxCode2Mode = False
        _LogData(cPageSession_BusinessLine._pTaxField & ": OPTION SELECTED", cPageSession_BusinessLine._pOptionBusDesc & IIf(cPageSession_BusinessLine._pOptionTaxCode2 <> Nothing, " [TAXCODE2: " & cPageSession_BusinessLine._pOptionTaxCode2 & "]", ""))

        If Not cPageSession_BusinessLine._pOptionTaxCode2 = Nothing Then
            cPageSession_BusinessLine._pTaxCode2Mode = True
            '_mFnIfHasRecord_GRADTABL() ' Goto GRADTABL
            '   Added 20170515
            _mFnContinueDataGather()
            Exit Sub
        Else
            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = cPageSession_BusinessLine._pOptionBusDesc
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            '_nClass._pInputVal = _oTextBox1_Ask.Text
            _nClass._pTaxCode = cPageSession_BusinessLine._pOptionTaxCode
            _nClass._pTaxRate = cPageSession_BusinessLine._pOptionTaxRate
            _nClass._pTaxAmt = cPageSession_BusinessLine._pOptionTaxAmt
            '_nClass._mSubSavetoTableComputation()

            _oGridViewOption.SelectedIndex = IIf(cPageSession_BusinessLine._pRowCountBuslineOption = 1, 2, cPageSession_BusinessLine._pRowCountBuslineOption)
            Select Case True
                Case cPageSession_BusinessLine._pELECCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = True
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pMECHCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = True
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pBLDGCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = True
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pSIGNCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = True
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pEPOCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = True
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pEIFCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = True
                Case cPageSession_BusinessLine._pPLATECODE
                    cPageSession_BusinessLine._pPLATECODE = False
                    cPageSession_BusinessLine._pBCODE = True

                Case cPageSession_BusinessLine._pBCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = True
                    cPageSession_BusinessLine._pGCODE = False
                    cPageSession_BusinessLine._pSCODE = False
                    cPageSession_BusinessLine._pFCODE = False
                Case cPageSession_BusinessLine._pMCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = False
                    cPageSession_BusinessLine._pGCODE = True
                    cPageSession_BusinessLine._pSCODE = False
                    cPageSession_BusinessLine._pFCODE = False
                Case cPageSession_BusinessLine._pGCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = False
                    cPageSession_BusinessLine._pGCODE = False
                    cPageSession_BusinessLine._pSCODE = True
                    cPageSession_BusinessLine._pFCODE = False
                Case cPageSession_BusinessLine._pSCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = False
                    cPageSession_BusinessLine._pGCODE = False
                    cPageSession_BusinessLine._pSCODE = False
                    cPageSession_BusinessLine._pFCODE = True
                Case cPageSession_BusinessLine._pFCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = False
                    cPageSession_BusinessLine._pGCODE = False
                    cPageSession_BusinessLine._pSCODE = False
                    cPageSession_BusinessLine._pFCODE = False
            End Select
            cPageSession_BusinessLine._pTaxCode2Mode = False
            _mFnContinueDataGather()
            Exit Sub

        End If
    End Sub
    Private Function _mFnGetAIFTaxBase(ByVal xSwitch As Integer) As Double
        Try
            _mFnGetAIFTaxBase = 0
            'Get Taxbase Basis
            Dim xTaxBase As Double : Dim TaxAmt As Double : Dim RTaxAmt As Double : Dim TaxRate As Double : Dim RTaxRate As Double

            If xSwitch = 1 Then 'Elec
                TaxAmt = IIf(cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pELECCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pELECCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pELECCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pELECCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 2 Then 'Mech
                TaxAmt = IIf(cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pMECHCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pMECHCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pMECHCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pMECHCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 3 Then 'Bldg
                TaxAmt = IIf(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 4 Then 'Sign
                TaxAmt = IIf(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 5 Then 'Epo
                TaxAmt = IIf(cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pEPOCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pEPOCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pEPOCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pEPOCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 6 Then 'Eif
                TaxAmt = IIf(cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pEIFCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pEIFCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pEIFCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pEIFCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 7 Then 'Plate
                TaxAmt = IIf(cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pPLATECODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pPLATECODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pPLATECODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pPLATECODE_GRADTABL_RTaxRate)
            End If

            If TaxAmt > 0 Or TaxRate > 0 And cPageSession_BusinessLine._pSTATCODE = "N" Then '20170724 basis of computation is capital
                xTaxBase = cPageSession_BusinessLine._pCAPITAL
            ElseIf RTaxAmt > 0 Or RTaxRate > 0 And cPageSession_BusinessLine._pSTATCODE = "R" Then  '20170724 basis of computation is gross
                xTaxBase = cPageSession_BusinessLine._pGROSS
                'Original
            ElseIf InStr(1, _oLabel1_Ask.Text, "[AREA]") <> 0 Then
                xTaxBase = cPageSession_BusinessLine._pAREA
            ElseIf InStr(1, _oLabel1_Ask.Text, "[GC]") <> 0 Then '20170120
                If cPageSession_BusinessLine._pSTATCODE = "R" Then
                    xTaxBase = cPageSession_BusinessLine._pGROSS
                Else
                    xTaxBase = cPageSession_BusinessLine._pCAPITAL
                End If
                '''    ElseIf InStr(1, xHdg, "[G]") <> 0 Then '20170120
                '''        TAXBASE = txtGross.Value
            ElseIf InStr(1, _oLabel1_Ask.Text, "[C]") <> 0 Then '20170120
                xTaxBase = cPageSession_BusinessLine._pCAPITAL
            ElseIf InStr(1, UCase(_oLabel1_Ask.Text), "[CORG]") <> 0 Then '20170122  'replace [CorG] to uppercase 20170131
                If cPageSession_BusinessLine._pGROSS <> 0 And cPageSession_BusinessLine._pCAPITAL = 0 And cPageSession_BusinessLine._pSTATCODE = "R" Then
                    xTaxBase = cPageSession_BusinessLine._pGROSS
                ElseIf cPageSession_BusinessLine._pGROSS = 0 And cPageSession_BusinessLine._pCAPITAL <> 0 And cPageSession_BusinessLine._pSTATCODE = "R" Then
                    xTaxBase = cPageSession_BusinessLine._pCAPITAL
                ElseIf cPageSession_BusinessLine._pSTATCODE Then
                    xTaxBase = cPageSession_BusinessLine._pGROSS
                Else
                    xTaxBase = cPageSession_BusinessLine._pCAPITAL
                End If
            Else 'Original
                xTaxBase = cPageSession_BusinessLine._pAREA
            End If
            _mFnGetAIFTaxBase = xTaxBase
        Catch ex As Exception
            _mFnGetAIFTaxBase = 0
        End Try
    End Function
    Private Sub _mSubSaveInputedData_Textbox1() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "1"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox1_Ask.Text

            '' _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------
            'Get Taxbase Basis
            Dim xTaxCode As String : Dim xTaxBase As Double

            Select Case True
                Case cPageSession_BusinessLine._pELECCODE
                    xTaxBase = _mFnGetAIFTaxBase(1)
                Case cPageSession_BusinessLine._pMECHCODE
                    xTaxBase = _mFnGetAIFTaxBase(2)
                Case cPageSession_BusinessLine._pBLDGCODE
                    xTaxBase = _mFnGetAIFTaxBase(3)
                Case cPageSession_BusinessLine._pSIGNCODE
                    xTaxBase = _mFnGetAIFTaxBase(4)
                Case cPageSession_BusinessLine._pEPOCODE
                    xTaxBase = _mFnGetAIFTaxBase(5)
                Case cPageSession_BusinessLine._pEIFCODE
                    xTaxBase = _mFnGetAIFTaxBase(6)
                Case cPageSession_BusinessLine._pPLATECODE
                    xTaxBase = _mFnGetAIFTaxBase(7)

            End Select

            Select Case True

                Case cPageSession_BusinessLine._pELECCODE
                    cPageSession_BusinessLine._pELECCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pELECCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pELECCODE_GRASKHDG_Val = _oTextBox1_Ask.Text()
                    xTaxCode = cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pELECCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")
                Case cPageSession_BusinessLine._pMECHCODE
                    cPageSession_BusinessLine._pMECHCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pMECHCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pMECHCODE_GRASKHDG_Val = _oTextBox1_Ask.Text()
                    xTaxCode = cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pMECHCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pBLDGCODE
                    cPageSession_BusinessLine._pBLDGCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pBLDGCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pBLDGCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pBLDGCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pSIGNCODE
                    cPageSession_BusinessLine._pSIGNCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pSIGNCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pSIGNCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pSIGNCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pEPOCODE
                    cPageSession_BusinessLine._pEPOCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pEPOCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pEPOCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pEPOCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pEIFCODE
                    cPageSession_BusinessLine._pEIFCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pEIFCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pEIFCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pEIFCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pPLATECODE
                    cPageSession_BusinessLine._pPLATECODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pPLATECODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pPLATECODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pPLATECODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pBCODE
                    cPageSession_BusinessLine._pBCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pBCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pBCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                Case cPageSession_BusinessLine._pMCODE
                    cPageSession_BusinessLine._pMCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pMCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pMCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                Case cPageSession_BusinessLine._pGCODE
                    cPageSession_BusinessLine._pGCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pGCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pGCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                Case cPageSession_BusinessLine._pSCODE
                    cPageSession_BusinessLine._pSCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pSCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pSCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                Case cPageSession_BusinessLine._pFCODE
                    cPageSession_BusinessLine._pFCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pFCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pFCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
            End Select

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then

            'Dim TaxAmt As Double
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord1_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox1_Ask.Text
            'TaxAmt = _nClass._pTaxAmt

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                '_nClass._mSubSavetoTableComputation()

                Select Case True
                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE  ' @ Added 20170627
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE  ' @ Added 20170627
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select

            End If


        End If

        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel1_Ask.Text, _oTextBox1_Ask.Text)

    End Sub
    Private Sub _mSubSaveInputedData_Textbox2() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "2"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox2_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord2_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox2_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                '_nClass._mSubSavetoTableComputation()
                Select Case True
                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel2_Ask.Text, _oTextBox2_Ask.Text)

    End Sub

    Private Sub _mSubSaveInputedData_Textbox3() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "3"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox3_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord3_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox3_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel3_Ask.Text, _oTextBox3_Ask.Text)

    End Sub

    Private Sub _mSubSaveInputedData_Textbox4() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "4"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox4_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord4_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox4_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True
                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel4_Ask.Text, _oTextBox4_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox5() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "5"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox5_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------


        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord5_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox5_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel5_Ask.Text, _oTextBox5_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox6() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "6"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox6_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------


        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord6_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox6_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel6_Ask.Text, _oTextBox6_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox7() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "7"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox7_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord7_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox7_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel7_Ask.Text, _oTextBox7_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox8() '@ Added 20180428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "8"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox8_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord8_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox8_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel8_Ask.Text, _oTextBox8_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox9() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "9"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox9_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord9_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox9_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel9_Ask.Text, _oTextBox9_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox10() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
        _nClass._pRowNo = "10"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox10_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord10_GRASKQTY()
            _nClass._pAccount = csessionloader._pAccountNo
            _nClass._pBusCode = cloader_BPLTIMS._pBus_Code
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cloader_BPLTIMS._pForYear
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox10_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel10_Ask.Text, _oTextBox10_Ask.Text)
    End Sub

#End Region

#Region "BASIC FEES DATA GATHERING PROCESS"

    Private Sub _mAskBCODE()
        '_oLabelFeeType.Text = "BUSINESS FEE"
        cPageSession_BusinessLine._pTaxField = "BCODE"

        cPageSession_BusinessLine._pBCODE = True
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = False
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL() = True Then
            cPageSession_BusinessLine._pBCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pBCODE_processed = True
            Exit Sub
        Else

            If _mFnIfHasRecord_GRASKHDG() = True Then '@ Added 20170412
                _oLabelFeeType.Text = "BUSINESS FEE (ASK HEADING)"
                cPageSession_BusinessLine._pBCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pBCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pBCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pBCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pBCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then '@ Added 20170412
                    _oLabelFeeType.Text = "BUSINESS FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pBCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then '@ Added 20170412
                        _oLabelFeeType.Text = "BUSINESS FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pBCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pBCODE_processed = True
    End Sub

    Private Sub _mAskMCODE() ' @ Added 20170420
        '_oLabelFeeType.Text = "MAYOR'S FEE"
        cPageSession_BusinessLine._pTaxField = "MCODE"

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = True
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = False
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL() = True Then
            cPageSession_BusinessLine._pMCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pMCODE_processed = True
            Exit Sub
        Else

            If _mFnIfHasRecord_GRASKHDG() = True Then '@ Added 20170412
                _oLabelFeeType.Text = "MAYOR'S FEE (ASK HEADING)"
                cPageSession_BusinessLine._pMCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pMCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pMCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then '@ Added 20170412
                    _oLabelFeeType.Text = "MAYOR'S FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pMCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then '@ Added 20170412
                        _oLabelFeeType.Text = "MAYOR'S FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pMCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pMCODE_processed = True
    End Sub

    Private Sub _mAskGCODE()   ' @ Added 20170518
        '_oLabelFeeType.Text = "GARBAGE FEE"
        cPageSession_BusinessLine._pTaxField = "GCODE"

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = True
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = False
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL() = True Then
            cPageSession_BusinessLine._pGCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pGCODE_processed = True
            Exit Sub
        Else

            If _mFnIfHasRecord_GRASKHDG() = True Then
                _oLabelFeeType.Text = "GARBAGE FEE (ASK HEADING)"
                cPageSession_BusinessLine._pGCODE_processed = True
                Exit Sub

            ElseIf HasRange(cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pGCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pGCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pGCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pGCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then
                    _oLabelFeeType.Text = "GARBAGE FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pGCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then
                        _oLabelFeeType.Text = "GARBAGE FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pGCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pGCODE_processed = True
    End Sub

    Private Sub _mAskSCODE()   ' @ Added 20170518
        '_oLabelFeeType.Text = "SANITARY FEE"
        '_mpAsk.Hide()
        cPageSession_BusinessLine._pTaxField = "SCODE"

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = True
        cPageSession_BusinessLine._pFCODE = False

        If _mFnIfHasRecord_GRADTABL() = True Then
            cPageSession_BusinessLine._pSCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pSCODE_processed = True
            Exit Sub
        Else

            If _mFnIfHasRecord_GRASKHDG() = True Then
                _oLabelFeeType.Text = "SANITARY FEE (ASK HEADING)"
                cPageSession_BusinessLine._pSCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pSCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pSCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then
                    _oLabelFeeType.Text = "SANITARY FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pSCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then
                        _oLabelFeeType.Text = "SANITARY FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pSCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pSCODE_processed = True
    End Sub

    Private Sub _mAskFCODE()   ' @ Added 20170518
        '_oLabelFeeType.Text = "FIRE FEE"
        '_mpAsk.Hide()
        cPageSession_BusinessLine._pTaxField = "FCODE"

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = True

        If _mFnIfHasRecord_GRADTABL() = True Then
            cPageSession_BusinessLine._pFCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pFCODE_processed = True
            _mFnExitTrigger_False() '' Continiue Procedure
            ''
            Exit Sub
        Else

            If _mFnIfHasRecord_GRASKHDG() = True Then
                _oLabelFeeType.Text = "FIRE FEE (ASK HEADING)"
                cPageSession_BusinessLine._pFCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pFCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pFCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pFCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pFCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pFCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pFCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then
                    _oLabelFeeType.Text = "FIRE FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pFCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then
                        _oLabelFeeType.Text = "FIRE FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pFCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pFCODE_processed = True
    End Sub

    Private Function _mFnIfHasRecord_GRASKHDG() As Boolean '@ Active  20170420

        Try
            '----------------------------------
            _mFnIfHasRecord_GRASKHDG = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRASKHDG"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._pSubSelect_GRASKHDG()
            Else
                _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
                _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
                _nClass._pSubSelect_GRASKHDG_TaxCode2()
            End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRASKHDG = True

                    If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                        _nClass._mSubGetQuestions_GRASKHDG()
                    Else
                        _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                        _nClass._mSubGetQuestions_GRASKHDG_2()

                    End If

                    '@  Added   20170420    -----------------------
                    '_mSubShowHideInputTextBox()
                    ' Ask info. GRASKHDG
                    '---------------------------------


                    If _nClass._pShowPanel1 = True Then
                        _oPanel1_Ask.Visible = True
                        _oLabel1_Ask.Text = _nClass._pOutputRec1
                        _oLabel1_Ask.Visible = True
                        _oTextBox1_Ask.Text = Nothing

                        If _nClass._pShowPanel2 = True Then
                            _oPanel2_Ask.Visible = True
                            _oLabel2_Ask.Text = _nClass._pOutputRec2
                            _oTextBox2_Ask.Text = Nothing

                            If _nClass._pShowPanel3 = True Then
                                _oPanel3_Ask.Visible = True
                                _oLabel3_Ask.Text = _nClass._pOutputRec3
                                _oTextBox3_Ask.Text = Nothing

                                If _nClass._pShowPanel4 = True Then
                                    _oPanel4_Ask.Visible = True
                                    _oLabel4_Ask.Text = _nClass._pOutputRec4
                                    _oTextBox4_Ask.Text = Nothing

                                    If _nClass._pShowPanel5 = True Then
                                        _oPanel5_Ask.Visible = True
                                        _oLabel5_Ask.Text = _nClass._pOutputRec5
                                        _oTextBox5_Ask.Text = Nothing

                                        If _nClass._pShowPanel6 = True Then
                                            _oPanel6_Ask.Visible = True
                                            _oLabel6_Ask.Text = _nClass._pOutputRec6
                                            _oTextBox6_Ask.Text = Nothing

                                            If _nClass._pShowPanel7 = True Then
                                                _oPanel7_Ask.Visible = True
                                                _oLabel7_Ask.Text = _nClass._pOutputRec7
                                                _oTextBox7_Ask.Text = Nothing

                                                If _nClass._pShowPanel8 = True Then
                                                    _oPanel8_Ask.Visible = True
                                                    _oLabel8_Ask.Text = _nClass._pOutputRec8
                                                    _oTextBox8_Ask.Text = Nothing

                                                    If _nClass._pShowPanel9 = True Then
                                                        _oPanel9_Ask.Visible = True
                                                        _oLabel9_Ask.Text = _nClass._pOutputRec9
                                                        _oTextBox9_Ask.Text = Nothing

                                                        If _nClass._pShowPanel10 = True Then
                                                            _oPanel10_Ask.Visible = True
                                                            _oLabel10_Ask.Text = _nClass._pOutputRec10
                                                            _oTextBox10_Ask.Text = Nothing
                                                        Else
                                                            _oPanel10_Ask.Visible = False
                                                        End If
                                                    Else
                                                        _oPanel9_Ask.Visible = False
                                                    End If
                                                Else
                                                    _oPanel8_Ask.Visible = False
                                                End If
                                            Else
                                                _oPanel7_Ask.Visible = False
                                            End If
                                        Else
                                            _oPanel6_Ask.Visible = False
                                        End If
                                    Else
                                        _oPanel5_Ask.Visible = False
                                    End If
                                Else
                                    _oPanel4_Ask.Visible = False
                                End If
                            Else
                                _oPanel3_Ask.Visible = False
                            End If
                        Else
                            _oPanel2_Ask.Visible = False
                        End If
                    Else

                        _oPanel1_Ask.Visible = False
                        _oPanel_Ask.Visible = False
                    End If

                    '---------------------------------
                    cPageSession_BusinessLine._pHeadingMode = True
                    cPageSession_BusinessLine._pOptionMode = False
                    cPageSession_BusinessLine._pQtyMode = False

                    '' ---- @ Added 20170823
                    If InStr(1, _nClass._pOutputRec1, "[AREA]") <> 0 Then
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pAREA

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[GC]") <> 0 Then
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pCAPITAL

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[C]") <> 0 Then
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pAREA

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[CORG]") <> 0 Then
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pCAPITAL

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    Else
                        If _oPanel1_Ask.Visible = False Then
                            _oPanel_Ask.Visible = False
                            _mFnIfHasRecord_GRASKHDG = False
                            _mFnExitTrigger_False() '' Continiue Procedure
                        Else
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanel_Ask.Focus()
                            _mFnExitTrigger_True() '' Exit Gather Info procedure to giveway for Pop Modal
                            '_oButtonTaxSave.Text = "Save"
                            _oButtonTaxSave.Enabled = True
                            _oPanel_Ask.Visible = True
                            _oPanelProcess.Visible = False
                            Return True
                        End If
                    End If
                Else

                    _mFnExitTrigger_False() '' Continiue Procedure
                    _oPanel_Ask.Visible = False
                    Return False
                    Exit Function 'Exit
                End If
            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GROPTION() As Boolean '@  ACTIVE 20170915

        Try
            '----------------------------------
            _mFnIfHasRecord_GROPTION = False

            cPageSession_BusinessLine._pTblCode = "GROPTION"
            '_oPanel_oGridViewOption.Visible = False

            Dim _nGridView As New GridView
            _nGridView = _oGridViewOption
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._pSubSelect_GROPTION()
            Else
                _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
                _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
                _nClass._pSubSelect_GROPTION_TaxCode2()
            End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GROPTION = True
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()   '@ Added 20170502

                    ''_oPanel_oGridViewOption.Height = 150    '@ Added 20170704
                    _oPanel_oGridViewOption.Visible = True
                    cPageSession_BusinessLine._pHeadingMode = False
                    cPageSession_BusinessLine._pOptionMode = True
                    cPageSession_BusinessLine._pQtyMode = False
                    '_oPanelPopUpProcessing.Visible = False
                    _oPanel_Ask.Visible = True
                    ShowPopup()
                    '_oButtonTaxSave.Text = "Save"
                    _oButtonTaxSave.Enabled = True
                    _oPanel_Ask.Visible = True

                    _mFnExitTrigger_True() '
                    _nFnHide_PanelAsk()
                    _oPanel_oGridViewOption.Visible = True
                    _oPanelProcess.Visible = False
                    '_oPanelPopUp_ModalPopupExtender.Hide()  '@ ADDED 20170913
                    '_oPanelPopUp_ModalPopupExtender.Enabled = False  '@ ADDED 20170913
                    ' Ask info. GRASKHDG

                    ''_mpAsk.Show()
                    Return True
                Else
                    _mFnExitTrigger_False()

                    _oPanel_oGridViewOption.Visible = False
                    '_oPanel_oGridViewOption.Height = 25

                    Return False
                    Exit Function 'Exit
                End If

            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GRASKQTY() As Boolean '@  ACTIVE 20170915

        Try
            '----------------------------------
            _mFnIfHasRecord_GRASKQTY = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRASKQTY"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._pSubSelect_GRASKQTY()
            Else
                _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
                _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
                _nClass._pSubSelect_GRASKQTY_TaxCode2()
            End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRASKQTY = True

                    _nClass._mSubGetQuestions_GRASKQTY()
                    ' Ask info. GRASKQTY

                    '----------------
                    If _nClass._pShowPanel1 = True Then
                        _oPanel1_Ask.Visible = True
                        _oLabel1_Ask.Text = _nClass._pOutputRec1
                        _oLabel1_Ask.Visible = True
                        _oTextBox1_Ask.Text = Nothing

                        If _nClass._pShowPanel2 = True Then
                            _oPanel2_Ask.Visible = True
                            _oLabel2_Ask.Text = _nClass._pOutputRec2
                            _oTextBox2_Ask.Text = Nothing

                            If _nClass._pShowPanel3 = True Then
                                _oPanel3_Ask.Visible = True
                                _oLabel3_Ask.Text = _nClass._pOutputRec3
                                _oTextBox3_Ask.Text = Nothing

                                If _nClass._pShowPanel4 = True Then
                                    _oPanel4_Ask.Visible = True
                                    _oLabel4_Ask.Text = _nClass._pOutputRec4
                                    _oTextBox4_Ask.Text = Nothing

                                    If _nClass._pShowPanel5 = True Then
                                        _oPanel5_Ask.Visible = True
                                        _oLabel5_Ask.Text = _nClass._pOutputRec5
                                        _oTextBox5_Ask.Text = Nothing

                                        If _nClass._pShowPanel6 = True Then
                                            _oPanel6_Ask.Visible = True
                                            _oLabel6_Ask.Text = _nClass._pOutputRec6
                                            _oTextBox6_Ask.Text = Nothing

                                            If _nClass._pShowPanel7 = True Then
                                                _oPanel7_Ask.Visible = True
                                                _oLabel7_Ask.Text = _nClass._pOutputRec7
                                                _oTextBox7_Ask.Text = Nothing

                                                If _nClass._pShowPanel8 = True Then
                                                    _oPanel8_Ask.Visible = True
                                                    _oLabel8_Ask.Text = _nClass._pOutputRec8
                                                    _oTextBox8_Ask.Text = Nothing

                                                    If _nClass._pShowPanel9 = True Then
                                                        _oPanel9_Ask.Visible = True
                                                        _oLabel9_Ask.Text = _nClass._pOutputRec9
                                                        _oTextBox9_Ask.Text = Nothing

                                                        If _nClass._pShowPanel10 = True Then
                                                            _oPanel10_Ask.Visible = True
                                                            _oLabel10_Ask.Text = _nClass._pOutputRec10
                                                            _oTextBox10_Ask.Text = Nothing
                                                        Else
                                                            _oPanel10_Ask.Visible = False
                                                        End If
                                                    Else
                                                        _oPanel9_Ask.Visible = False
                                                    End If
                                                Else
                                                    _oPanel8_Ask.Visible = False
                                                End If
                                            Else
                                                _oPanel7_Ask.Visible = False
                                            End If
                                        Else
                                            _oPanel6_Ask.Visible = False
                                        End If
                                    Else
                                        _oPanel5_Ask.Visible = False
                                    End If
                                Else
                                    _oPanel4_Ask.Visible = False
                                End If
                            Else
                                _oPanel3_Ask.Visible = False
                            End If
                        Else
                            _oPanel2_Ask.Visible = False
                        End If
                    Else
                        _oPanel1_Ask.Visible = False
                    End If

                    '---------------------------------
                    cPageSession_BusinessLine._pHeadingMode = False
                    cPageSession_BusinessLine._pOptionMode = False
                    cPageSession_BusinessLine._pQtyMode = True

                    '' ---- @ Added 20210528
                    If InStr(1, _nClass._pOutputRec1, "[AREA]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mArea

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[GC]") <> 0 Then '20210528
                        If _mStatus = "R" Then
                            _oTextBox1_Ask.Text = _mGross
                        Else
                            _oTextBox1_Ask.Text = _mCapital
                        End If

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[C]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[CORG]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[NOEMP]") <> 0 Then '@Added 20211026
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pNO_EMP
                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[ASSET]") <> 0 Then '@Added 20211026
                        _oTextBox1_Ask.Text = 0 ' Assesst sana
                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    Else

                        If _oPanel1_Ask.Visible = False Then
                            _oPanel_Ask.Visible = False
                            _mFnExitTrigger_False() '' Continiue Procedure
                            _mFnIfHasRecord_GRASKQTY = False

                        Else
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            _oButtonTaxSave.Enabled = True
                            '_oButtonTaxSave.Text = "Save"
                            _mFnExitTrigger_True() '

                            _oButtonTaxSave.Enabled = True
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            Return True
                        End If

                    End If

                   
                Else
                    _mFnExitTrigger_False() '
                    _oPanel_Ask.Visible = False
                    Return False
                    Exit Function 'Exit
                End If

            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub _mFnExitTrigger_True()
        Dim _mExitCode As String
        _mExitCode = cPageSession_BusinessLine._pTaxField

        Select Case _mExitCode  ' @ Modified 20170621
            Case "BCODE"
                cPageSession_BusinessLine._pExit_BCODE = True
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "MCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = True
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "GCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = True
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "SCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = True
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "FCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = True
        End Select

    End Sub


    Private Sub _mFnExitTrigger_False()
        Dim _mExitCode As String
        _mExitCode = cPageSession_BusinessLine._pTaxField
        Select Case _mExitCode
            Case "BCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "MCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "GCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "SCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "FCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
        End Select
    End Sub

#End Region

End Class

Partial Public Class BPLTIMS_BPLOReview

#Region "Variable field"

    Private Shared _mAccount As String
    Private Shared _mArea As Double
    Private Shared _mCapital As Double
    Private Shared _mGross As Double
    Private Shared _mStatus As String
    Private Shared _mForYear As String
    Private Shared _mBusCode As String

#End Region


#Region "Property field"
    Public Property _pAccount() As String
        Get
            Return _mAccount
        End Get
        Set(ByVal value As String)
            _mAccount = value
        End Set
    End Property

    Public Property _pArea() As Double
        Get
            Return _mArea
        End Get
        Set(ByVal value As Double)
            _mArea = value
        End Set
    End Property

    Public Property _pCapital() As Double
        Get
            Return _mCapital
        End Get
        Set(ByVal value As Double)
            _mCapital = value
        End Set
    End Property

    Public Property _pGross() As Double
        Get
            Return _mGross
        End Get
        Set(ByVal value As Double)
            _mGross = value
        End Set
    End Property

    Public Property _pStatus() As String
        Get
            Return _mStatus
        End Get
        Set(ByVal value As String)
            _mStatus = value
        End Set
    End Property

    Public Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(ByVal value As String)
            _mForYear = value
        End Set
    End Property

    Public Property _pBusCode() As String
        Get
            Return _mBusCode
        End Get
        Set(ByVal value As String)
            _mBusCode = value
        End Set
    End Property

#End Region

    Public Function _pFnCheckIfBuslineExist()
        _pFnCheckIfBuslineExist = False
        Try
            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " SELEC BUS_CODE FROM BUSLINE "
                ._pCondition = " WHERE ACCTNO =''" & _mAccount & "'' AND FORYEAR = ''" & _mForYear & "'' AND BUS_CODE = ''" & _mBusCode & "'' "
                ._pExec(_nSuccessful, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            End With

        Catch ex As Exception

        End Try

    End Function ' Check if Busline already exists

    Public Sub _pSetDefaults()

        cPageSession_BusinessLine._pTaxCode2Mode = False
        cPageSession_BusinessLine._pOptionTaxCode2 = Nothing

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = False

        cPageSession_BusinessLine._pELECCODE_FEE = 0
        cPageSession_BusinessLine._pMECHCODE_FEE = 0
        cPageSession_BusinessLine._pBLDGCODE_FEE = 0
        cPageSession_BusinessLine._pBLDGCODE_FEE = 0
        cPageSession_BusinessLine._pSIGNCODE_FEE = 0
        cPageSession_BusinessLine._pEPOCODE_FEE = 0
        cPageSession_BusinessLine._pEIFCODE_FEE = 0
        cPageSession_BusinessLine._pPLATECODE_FEE = 0
        cPageSession_BusinessLine._pBUSCODE = cLoader_BPLTIMS._pBUS_CODE
        cPageSession_BusinessLine._pxForYear = cLoader_BPLTIMS._pFORYEAR

        cPageSession_BusinessLine._pAREA = cLoader_BPLTIMS._pAREA
        cPageSession_BusinessLine._pCAPITAL = cLoader_BPLTIMS._pCAPITAL
        cPageSession_BusinessLine._pGROSS = cLoader_BPLTIMS._pGROSSREC

        cPageSession_BusinessLine._pBCOMPSW = 0
        cPageSession_BusinessLine._pMCOMPSW = 0
        cPageSession_BusinessLine._pGCOMPSW = 0
        cPageSession_BusinessLine._pSCOMPSW = 0
        cPageSession_BusinessLine._pFCOMPSW = 0

    End Sub


#Region "AIF DATA GATHERING PROCESSES"
    Public Sub _mAskELECCODE() '@ Added 20170811   
        Try


            '_oLabelFeeType.Text = "ELECTICAL FEE"
            cPageSession_BusinessLine._pTaxField = "ELECCODE"

            cPageSession_BusinessLine._pELECCODE = True
            cPageSession_BusinessLine._pMECHCODE = False
            cPageSession_BusinessLine._pBLDGCODE = False
            cPageSession_BusinessLine._pSIGNCODE = False
            cPageSession_BusinessLine._pEPOCODE = False
            cPageSession_BusinessLine._pEIFCODE = False
            cPageSession_BusinessLine._pPLATECODE = False

            '_mpAsk.Hide()
            If _mFnIfHasRecord_GRADTABL_AIF() = True Then
                cPageSession_BusinessLine._pELECCODE_processed = True
                Exit Sub
            ElseIf cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode = Nothing Then
                'cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pELECCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                    ' _oLabelFeeType.Text = "ELECTICAL FEE"
                    cPageSession_BusinessLine._pELECCODE_processed = True
                    Exit Sub
                ElseIf HasRange(cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pELECCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pELECCODE_GRADTABL_EffMonth) = True Then
                    Dim xTaxBase As Double
                    xTaxBase = cPageSession_BusinessLine._pAREA
                    cPageSession_BusinessLine._pELECCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pELECCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pELECCODE_GRADTABL_EffMonth, xTaxBase, "0")
                    cPageSession_BusinessLine._pELECCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GROPTION_AIF() = True Then
                        _oLabelFeeType.Text = "ELECTICAL FEE"
                        cPageSession_BusinessLine._pELECCODE_processed = True
                        Exit Sub
                    Else

                        If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                            _oLabelFeeType.Text = "ELECTICAL FEE"
                            cPageSession_BusinessLine._pELECCODE_processed = True
                            Exit Sub
                        Else
                        End If
                    End If
                End If
            End If
            cPageSession_BusinessLine._pELECCODE_processed = True
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mAskMECHCODE() '@ Added 20170811
        Try
            '_oLabelFeeType.Text = "MECHANICAL FEE"
            cPageSession_BusinessLine._pTaxField = "MECHCODE"

            cPageSession_BusinessLine._pELECCODE = False
            cPageSession_BusinessLine._pMECHCODE = True
            cPageSession_BusinessLine._pBLDGCODE = False
            cPageSession_BusinessLine._pSIGNCODE = False
            cPageSession_BusinessLine._pEPOCODE = False
            cPageSession_BusinessLine._pEIFCODE = False
            cPageSession_BusinessLine._pPLATECODE = False
            '_mpAsk.Hide()
            If _mFnIfHasRecord_GRADTABL_AIF() = True Then
                cPageSession_BusinessLine._pMECHCODE_processed = True
                Exit Sub
            ElseIf cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode = Nothing Then
                cPageSession_BusinessLine._pMECHCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                    _oLabelFeeType.Text = "MECHANICAL FEE"
                    cPageSession_BusinessLine._pMECHCODE_processed = True
                    Exit Sub
                ElseIf HasRange(cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffMonth) = True Then
                    Dim xTaxBase As Double
                    xTaxBase = cPageSession_BusinessLine._pAREA
                    cPageSession_BusinessLine._pMECHCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffMonth, xTaxBase, "0")
                    cPageSession_BusinessLine._pMECHCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GROPTION_AIF() = True Then
                        _oLabelFeeType.Text = "MECHANICAL FEE"
                        cPageSession_BusinessLine._pMECHCODE_processed = True
                        Exit Sub
                    Else

                        If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                            _oLabelFeeType.Text = "MECHANICAL FEE"
                            cPageSession_BusinessLine._pMECHCODE_processed = True
                            Exit Sub
                        Else
Next_Fee:
                            If cPageSession_BusinessLine._pPLATECODE = True Then
                                cPageSession_BusinessLine._pPLATECODE = False
                                cPageSession_BusinessLine._pBCODE = True
                                cPageSession_BusinessLine._pMECHCODE_processed = True
                                _mFnContinueDataGather()
                            End If
                        End If
                    End If
                End If
            End If
            cPageSession_BusinessLine._pMECHCODE_processed = True
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mAskBLDGCODE() '@ Added 20170811
        Try
            '_oLabelFeeType.Text = "BUILDING FEE"
            cPageSession_BusinessLine._pTaxField = "BLDGCODE"

            cPageSession_BusinessLine._pELECCODE = False
            cPageSession_BusinessLine._pMECHCODE = False
            cPageSession_BusinessLine._pBLDGCODE = True
            cPageSession_BusinessLine._pSIGNCODE = False
            cPageSession_BusinessLine._pEPOCODE = False
            cPageSession_BusinessLine._pEIFCODE = False
            cPageSession_BusinessLine._pPLATECODE = False
            '_mpAsk.Hide()
            If _mFnIfHasRecord_GRADTABL_AIF() = True Then
                cPageSession_BusinessLine._pBLDGCODE_processed = True
                Exit Sub
            ElseIf cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode = Nothing Then
                cPageSession_BusinessLine._pBLDGCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                    _oLabelFeeType.Text = "BUILDING FEE"
                    cPageSession_BusinessLine._pBLDGCODE_processed = True
                    Exit Sub
                ElseIf HasRange(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffMonth) = True Then
                    Dim xTaxBase As Double
                    xTaxBase = cPageSession_BusinessLine._pAREA
                    cPageSession_BusinessLine._pBLDGCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffMonth, xTaxBase, "0")
                    cPageSession_BusinessLine._pBLDGCODE_processed = True
                    Exit Sub

                Else

                    If _mFnIfHasRecord_GROPTION_AIF() = True Then
                        _oLabelFeeType.Text = "BUILDING FEE"
                        cPageSession_BusinessLine._pBLDGCODE_processed = True
                        Exit Sub
                    Else

                        If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                            _oLabelFeeType.Text = "BUILDING FEE"
                            cPageSession_BusinessLine._pBLDGCODE_processed = True
                            Exit Sub
                        Else
Next_Fee:
                            If cPageSession_BusinessLine._pPLATECODE = True Then
                                cPageSession_BusinessLine._pPLATECODE = False
                                cPageSession_BusinessLine._pBCODE = True
                                cPageSession_BusinessLine._pBLDGCODE_processed = True
                                _mFnContinueDataGather()
                            End If
                        End If
                    End If
                End If
            End If
            cPageSession_BusinessLine._pBLDGCODE_processed = True
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mAskSIGNCODE() '@ Added 20170811
        '_oLabelFeeType.Text = "SIGNAGE FEE"
        cPageSession_BusinessLine._pTaxField = "SIGNCODE"

        cPageSession_BusinessLine._pELECCODE = False
        cPageSession_BusinessLine._pMECHCODE = False
        cPageSession_BusinessLine._pBLDGCODE = False
        cPageSession_BusinessLine._pSIGNCODE = True
        cPageSession_BusinessLine._pEPOCODE = False
        cPageSession_BusinessLine._pEIFCODE = False
        cPageSession_BusinessLine._pPLATECODE = False
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL_AIF() = True Then
            cPageSession_BusinessLine._pSIGNCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pSIGNCODE_processed = True
            ' cPageSession_BusinessLine._pSIGNCODE = False
            Exit Sub
        Else

            If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                _oLabelFeeType.Text = "SIGNAGE FEE"
                cPageSession_BusinessLine._pSIGNCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pSIGNCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pSIGNCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION_AIF() = True Then
                    _oLabelFeeType.Text = "SIGNAGE FEE"
                    cPageSession_BusinessLine._pSIGNCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                        _oLabelFeeType.Text = "SIGNAGE FEE"
                        cPageSession_BusinessLine._pSIGNCODE_processed = True
                        Exit Sub
Next_Fee:
                        If cPageSession_BusinessLine._pPLATECODE = True Then
                            cPageSession_BusinessLine._pPLATECODE = False
                            cPageSession_BusinessLine._pBCODE = True
                            cPageSession_BusinessLine._pSIGNCODE_processed = True
                            _mFnContinueDataGather()
                        End If
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pSIGNCODE_processed = True
    End Sub

    Public Sub _mAskEPOCODE() '@ Added 20170811
        Dim _nClass As New cDalBusinessLine
        '_nClass._mSubGetAIF_Desc()
        'cPageSession_BusinessLine._pLabelFee = _nClass._pEPO
        '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee

        cPageSession_BusinessLine._pTaxField = "EPOCODE"

        cPageSession_BusinessLine._pELECCODE = False
        cPageSession_BusinessLine._pMECHCODE = False
        cPageSession_BusinessLine._pBLDGCODE = False
        cPageSession_BusinessLine._pSIGNCODE = False
        cPageSession_BusinessLine._pEPOCODE = True
        cPageSession_BusinessLine._pEIFCODE = False
        cPageSession_BusinessLine._pPLATECODE = False

        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL_AIF() = True Then
            cPageSession_BusinessLine._pEPOCODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode = Nothing Then
            'cPageSession_BusinessLine._pEPOCODE = False
            cPageSession_BusinessLine._pEPOCODE_processed = True
            Exit Sub
        Else
            '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
            If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
                cPageSession_BusinessLine._pEPOCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pEPOCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pEPOCODE_processed = True
                Exit Sub
            Else
                '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                If _mFnIfHasRecord_GROPTION_AIF() = True Then
                    _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                    cPageSession_BusinessLine._pEPOCODE_processed = True
                    Exit Sub
                Else
                    '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                    If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                        _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                        cPageSession_BusinessLine._pEPOCODE_processed = True
                        Exit Sub
                    Else
Next_Fee:
                        If cPageSession_BusinessLine._pPLATECODE = True Then
                            cPageSession_BusinessLine._pPLATECODE = False
                            cPageSession_BusinessLine._pBCODE = True
                            cPageSession_BusinessLine._pEPOCODE_processed = True
                            _mFnContinueDataGather()
                        End If
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pEPOCODE_processed = True
    End Sub

    Public Sub _mAskEIFCODE() '@ Added 20170811

        'Dim _nClass As New cDalBusinessLine
        '_nClass._mSubGetAIF_Desc()
        'cPageSession_BusinessLine._pLabelFee = _nClass._pEIF
        '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee

        cPageSession_BusinessLine._pTaxField = "EIFCODE"

        cPageSession_BusinessLine._pELECCODE = False
        cPageSession_BusinessLine._pMECHCODE = False
        cPageSession_BusinessLine._pBLDGCODE = False
        cPageSession_BusinessLine._pSIGNCODE = False
        cPageSession_BusinessLine._pEPOCODE = False
        cPageSession_BusinessLine._pEIFCODE = True
        cPageSession_BusinessLine._pPLATECODE = False


        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL_AIF() = True Then
            cPageSession_BusinessLine._pEIFCODE_processed = True
            Exit Sub

        ElseIf cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pEIFCODE_processed = True
            'cPageSession_BusinessLine._pEIFCODE = False
            Exit Sub
        Else
            '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
            If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
                cPageSession_BusinessLine._pEIFCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pEIFCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pEIFCODE_processed = True
                Exit Sub
            Else
                '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                If _mFnIfHasRecord_GROPTION_AIF() = True Then
                    _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                    cPageSession_BusinessLine._pEIFCODE_processed = True
                    Exit Sub
                Else
                    '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                    If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                        _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                        cPageSession_BusinessLine._pEIFCODE_processed = True
                        Exit Sub
                    Else
Next_Fee:
                        If cPageSession_BusinessLine._pPLATECODE = True Then
                            cPageSession_BusinessLine._pPLATECODE = False
                            cPageSession_BusinessLine._pBCODE = True
                            _mFnContinueDataGather()
                        End If
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pEIFCODE_processed = True
    End Sub

    Public Sub _mAskPLATECODE() '@ Added 20170811
        'Dim _nClass As New cDalBusinessLine
        '_nClass._mSubGetAIF_Desc()
        'cPageSession_BusinessLine._pLabelFee = _nClass._pPLATE
        '_oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee
        cPageSession_BusinessLine._pTaxField = "PLATECODE"

        cPageSession_BusinessLine._pELECCODE = False
        cPageSession_BusinessLine._pMECHCODE = False
        cPageSession_BusinessLine._pBLDGCODE = False
        cPageSession_BusinessLine._pSIGNCODE = False
        cPageSession_BusinessLine._pEPOCODE = False
        cPageSession_BusinessLine._pEIFCODE = False
        cPageSession_BusinessLine._pPLATECODE = True
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL_AIF() = True Then
            cPageSession_BusinessLine._pPLATECODE_processed = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pPLATECODE_processed = True
            GoTo Next_Fee
            Exit Sub
        Else


            If _mFnIfHasRecord_GRASKHDG_AIF() = True Then
                _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & "  ASK HEADING"
                cPageSession_BusinessLine._pPLATECODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffYear, cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pPLATECODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffYear, cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pPLATECODE_processed = True
                Exit Sub
            Else


                If _mFnIfHasRecord_GROPTION_AIF() = True Then
                    _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK OPTION"
                    cPageSession_BusinessLine._pPLATECODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY_AIF() = True Then
                        _oLabelFeeType.Text = cPageSession_BusinessLine._pLabelFee & " ASK QUANTITY"
                        cPageSession_BusinessLine._pPLATECODE_processed = True
                        Exit Sub
                    Else
Next_Fee:
                        cPageSession_BusinessLine._pPLATECODE = False
                        cPageSession_BusinessLine._pExit_ELECCODE = False
                        cPageSession_BusinessLine._pExit_MECHCODE = False
                        cPageSession_BusinessLine._pExit_BLDGCODE = False
                        cPageSession_BusinessLine._pExit_SIGNCODE = False
                        cPageSession_BusinessLine._pExit_EPOCODE = False
                        cPageSession_BusinessLine._pExit_EIFCODE = False

                        cPageSession_BusinessLine._pBCODE = True
                        cPageSession_BusinessLine._pPLATECODE_processed = True
                        '_mFnContinueDataGather()
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pPLATECODE_processed = True
    End Sub

    '=====================================================================================
    Private Function _mFnIfHasRecord_GRADTABL_AIF() As Boolean     'Active  '@  Added 20170420
        Try
            '----------------------------------
            _mFnIfHasRecord_GRADTABL_AIF = False
            ' _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRADTABL"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            ' _nClass._pSubCheckGradTable()
            _nClass._pSubSelect_GRADTABL()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    '_mFnIfHasRecord_GRADTABL = True
                    '_oPanel_Ask.Visible = True
                    '_mpAsk.Show()
                    _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
                    _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
                    _nClass._pTblCode = cPageSession_BusinessLine._pTblCode

                    _nClass._mSubGetGRADTABLValue()
                    Select Case True
                        Case cPageSession_BusinessLine._pELECCODE
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pMECHCODE
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pBLDGCODE
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pSIGNCODE
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pEPOCODE
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pEIFCODE
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pPLATECODE
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                    End Select

                    If _nClass._pTaxAmt <> 0.0 Then

                        '-------------------------------------------------------------------------
                        ' Get Tax Amount for comparison of Min and Max

                        _mFnIfHasRecord_GRADTABL_AIF = True
                        Select Case True
                            Case cPageSession_BusinessLine._pELECCODE
                                cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pELECCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pMECHCODE
                                cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pMECHCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pBLDGCODE
                                cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pBLDGCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pSIGNCODE
                                cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pSIGNCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pEPOCODE
                                cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pEPOCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pEIFCODE
                                cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pEIFCODE_FEE = _nClass._pTaxAmt

                            Case cPageSession_BusinessLine._pPLATECODE
                                cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pPLATECODE_FEE = _nClass._pTaxAmt

                        End Select
                        Return True
                        '-------------------------------------------------------------------------
                        ' _mFnExitTrigger_True()
                        Exit Function 'Exit
                    ElseIf _nClass._pTaxRate <> 0.0 Then ' @ Added 20170801
                        ' Get TAXCODE, YEAR and MONTH then Refer to GRRANGE
                        Select Case True
                            Case cPageSession_BusinessLine._pELECCODE
                                cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pELECCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pMECHCODE
                                cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pMECHCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pBLDGCODE
                                cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pBLDGCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pSIGNCODE
                                cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pSIGNCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pEPOCODE
                                cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pEPOCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pEIFCODE
                                cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pEIFCODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                            Case cPageSession_BusinessLine._pPLATECODE
                                cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxAmt = _nClass._pTaxRate ' ==> Save TaxCode to Temporary Variable
                                cPageSession_BusinessLine._pPLATECODE_FEE = _nClass._pTaxRate * cPageSession_BusinessLine._pAREA
                        End Select
                        Return False
                    End If
                Else
                    Return False
                    Exit Function 'Exit
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

    Private Function _mFnIfHasRecord_GRASKHDG_AIF() As Boolean '@ Added 20170811 ACTIVE 

        Try
            '----------------------------------
            _mFnIfHasRecord_GRASKHDG_AIF = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRASKHDG"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pSubCheck_GRASKHDG()
            '_nClass._pSubSelect_GRASKHDG()

            'If cPageSession_BusinessLine._pTaxCode2Mode = False Then
            '    _nClass._pSubSelect_GRASKHDG()
            'Else
            '    _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
            '    _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
            '    _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
            '    _nClass._pSubSelect_GRASKHDG_TaxCode2()
            'End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRASKHDG_AIF = True

                    _oPanel1_Ask.Visible = False
                    _oPanel2_Ask.Visible = False
                    _oPanel3_Ask.Visible = False
                    _oPanel4_Ask.Visible = False
                    _oPanel5_Ask.Visible = False
                    _oPanel6_Ask.Visible = False
                    _oPanel7_Ask.Visible = False
                    _oPanel8_Ask.Visible = False
                    _oPanel9_Ask.Visible = False
                    _oPanel10_Ask.Visible = False

                    _mSubCollectAskHeading(_nDataTable)

                    '_nClass._mSubGetQuestions_GRASKHDG()
                    ''@  Added   20170420    -----------------------
                    ''_mSubShowHideInputTextBox()
                    '' Ask info. GRASKHDG
                    ''---------------------------------
                    'If _nClass._pShowPanel1 = True Then
                    '    _oPanel1_Ask.Visible = True
                    '    _oLabel1_Ask.Text = _nClass._pOutputRec1
                    '    _oLabel1_Ask.Visible = True
                    '    _oTextBox1_Ask.Text = Nothing

                    '    If _nClass._pShowPanel2 = True Then
                    '        _oPanel2_Ask.Visible = True
                    '        _oLabel2_Ask.Text = _nClass._pOutputRec2
                    '        _oTextBox2_Ask.Text = Nothing

                    '        If _nClass._pShowPanel3 = True Then
                    '            _oPanel3_Ask.Visible = True
                    '            _oLabel3_Ask.Text = _nClass._pOutputRec3
                    '            _oTextBox3_Ask.Text = Nothing

                    '            If _nClass._pShowPanel4 = True Then
                    '                _oPanel4_Ask.Visible = True
                    '                _oLabel4_Ask.Text = _nClass._pOutputRec4
                    '                _oTextBox4_Ask.Text = Nothing

                    '                If _nClass._pShowPanel5 = True Then
                    '                    _oPanel5_Ask.Visible = True
                    '                    _oLabel5_Ask.Text = _nClass._pOutputRec5
                    '                    _oTextBox5_Ask.Text = Nothing

                    '                    If _nClass._pShowPanel6 = True Then
                    '                        _oPanel6_Ask.Visible = True
                    '                        _oLabel6_Ask.Text = _nClass._pOutputRec6
                    '                        _oTextBox6_Ask.Text = Nothing

                    '                        If _nClass._pShowPanel7 = True Then
                    '                            _oPanel7_Ask.Visible = True
                    '                            _oLabel7_Ask.Text = _nClass._pOutputRec7
                    '                            _oTextBox7_Ask.Text = Nothing

                    '                            If _nClass._pShowPanel8 = True Then
                    '                                _oPanel8_Ask.Visible = True
                    '                                _oLabel8_Ask.Text = _nClass._pOutputRec8
                    '                                _oTextBox8_Ask.Text = Nothing

                    '                                If _nClass._pShowPanel9 = True Then
                    '                                    _oPanel9_Ask.Visible = True
                    '                                    _oLabel9_Ask.Text = _nClass._pOutputRec9
                    '                                    _oTextBox9_Ask.Text = Nothing

                    '                                    If _nClass._pShowPanel10 = True Then
                    '                                        _oPanel10_Ask.Visible = True
                    '                                        _oLabel10_Ask.Text = _nClass._pOutputRec10
                    '                                        _oTextBox10_Ask.Text = Nothing
                    '                                    Else
                    '                                        _oPanel10_Ask.Visible = False
                    '                                    End If
                    '                                Else
                    '                                    _oPanel9_Ask.Visible = False
                    '                                End If
                    '                            Else
                    '                                _oPanel8_Ask.Visible = False
                    '                            End If
                    '                        Else
                    '                            _oPanel7_Ask.Visible = False
                    '                        End If
                    '                    Else
                    '                        _oPanel6_Ask.Visible = False
                    '                    End If
                    '                Else
                    '                    _oPanel5_Ask.Visible = False
                    '                End If
                    '            Else
                    '                _oPanel4_Ask.Visible = False
                    '            End If
                    '        Else
                    '            _oPanel3_Ask.Visible = False
                    '        End If
                    '    Else
                    '        _oPanel2_Ask.Visible = False
                    '    End If
                    'Else
                    '    _oPanel1_Ask.Visible = False
                    'End If

                    '---------------------------------
                    cPageSession_BusinessLine._pHeadingMode = True
                    cPageSession_BusinessLine._pOptionMode = False
                    cPageSession_BusinessLine._pQtyMode = False


                    '' ---- @ Added 20170823
                    If InStr(1, _nClass._pOutputRec1, "[AREA]") <> 0 Then '20170120
                        _oTextBox1_Ask.Text = _oBusinessLineCapital.Value

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[GC]") <> 0 Then '20170120
                        _oTextBox1_Ask.Text = _oBusinessLineCapital.Value

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[C]") <> 0 Then '20170120
                        _oTextBox1_Ask.Text = _oBusinessLineCapital.Value

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[CORG]") <> 0 Then '20170122  'replace [CorG] to uppercase 20170126
                        _oTextBox1_Ask.Text = _oBusinessLineCapital.Value

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    Else
                        If _oPanel1_Ask.Visible = False Then
                            _oPanel_Ask.Visible = False
                            _mFnExitTrigger_False_AIF() '' Continiue Procedure
                            _mFnIfHasRecord_GRASKHDG_AIF = False
                        Else
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanel_Ask.Focus()
                            _mFnExitTrigger_False_AIF() '' Exit Gather Info procedure to giveway for Pop Modal
                            '_oButtonTaxSave.Text = "Save"
                            _oButtonTaxSave.Enabled = True
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            Return True
                        End If
                    End If

                Else
                    _mFnExitTrigger_False_AIF() '' Continiue Procedure
                    _oPanel_Ask.Visible = False
                    Return False
                    Exit Function 'Exit
                End If
            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GRASKQTY_AIF() As Boolean '@  Added 20170428 ACTIVE

        Try
            '----------------------------------
            _mFnIfHasRecord_GRASKQTY_AIF = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRASKQTY"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            _nClass._pSubSelect_GRASKQTY()
            'If cPageSession_BusinessLine._pTaxCode2Mode = False Then
            '    _nClass._pSubSelect_GRASKQTY()
            'Else
            '    _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
            '    _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
            '    _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
            '    _nClass._pSubSelect_GRASKQTY_TaxCode2()
            'End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRASKQTY_AIF = True

                    _nClass._mSubGetQuestions_GRASKQTY()
                    ' Ask info. GRASKQTY

                    '----------------
                    If _nClass._pShowPanel1 = True Then
                        _oPanel1_Ask.Visible = True
                        _oLabel1_Ask.Text = _nClass._pOutputRec1
                        _oLabel1_Ask.Visible = True
                        _oTextBox1_Ask.Text = Nothing
                        cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt2 = _nClass._pTaxAmt1

                        If _nClass._pShowPanel2 = True Then
                            _oPanel2_Ask.Visible = True
                            _oLabel2_Ask.Text = _nClass._pOutputRec2
                            cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt2 = _nClass._pTaxAmt2
                            _oTextBox2_Ask.Text = Nothing

                            If _nClass._pShowPanel3 = True Then
                                _oPanel3_Ask.Visible = True
                                _oLabel3_Ask.Text = _nClass._pOutputRec3
                                cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt3 = _nClass._pTaxAmt3
                                _oTextBox3_Ask.Text = Nothing

                                If _nClass._pShowPanel4 = True Then
                                    _oPanel4_Ask.Visible = True
                                    _oLabel4_Ask.Text = _nClass._pOutputRec4
                                    cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt4 = _nClass._pTaxAmt4
                                    _oTextBox4_Ask.Text = Nothing

                                    If _nClass._pShowPanel5 = True Then
                                        _oPanel5_Ask.Visible = True
                                        _oLabel5_Ask.Text = _nClass._pOutputRec5
                                        cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt5 = _nClass._pTaxAmt5
                                        _oTextBox5_Ask.Text = Nothing

                                        If _nClass._pShowPanel6 = True Then
                                            _oPanel6_Ask.Visible = True
                                            _oLabel6_Ask.Text = _nClass._pOutputRec6
                                            cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt6 = _nClass._pTaxAmt6
                                            _oTextBox6_Ask.Text = Nothing

                                            If _nClass._pShowPanel7 = True Then
                                                _oPanel7_Ask.Visible = True
                                                _oLabel7_Ask.Text = _nClass._pOutputRec7
                                                cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt7 = _nClass._pTaxAmt7
                                                _oTextBox7_Ask.Text = Nothing

                                                If _nClass._pShowPanel8 = True Then
                                                    _oPanel8_Ask.Visible = True
                                                    _oLabel8_Ask.Text = _nClass._pOutputRec8
                                                    cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt8 = _nClass._pTaxAmt8
                                                    _oTextBox8_Ask.Text = Nothing

                                                    If _nClass._pShowPanel9 = True Then
                                                        _oPanel9_Ask.Visible = True
                                                        _oLabel9_Ask.Text = _nClass._pOutputRec9
                                                        cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt9 = _nClass._pTaxAmt9
                                                        _oTextBox9_Ask.Text = Nothing

                                                        If _nClass._pShowPanel10 = True Then
                                                            _oPanel10_Ask.Visible = True
                                                            _oLabel10_Ask.Text = _nClass._pOutputRec10
                                                            cPageSession_BusinessLine._pFEE_GRASKQTY_TaxAmt10 = _nClass._pTaxAmt10
                                                            _oTextBox10_Ask.Text = Nothing
                                                        Else
                                                            _oPanel10_Ask.Visible = False
                                                        End If
                                                    Else
                                                        _oPanel9_Ask.Visible = False
                                                    End If
                                                Else
                                                    _oPanel8_Ask.Visible = False
                                                End If
                                            Else
                                                _oPanel7_Ask.Visible = False
                                            End If
                                        Else
                                            _oPanel6_Ask.Visible = False
                                        End If
                                    Else
                                        _oPanel5_Ask.Visible = False
                                    End If
                                Else
                                    _oPanel4_Ask.Visible = False
                                End If
                            Else
                                _oPanel3_Ask.Visible = False
                            End If
                        Else
                            _oPanel2_Ask.Visible = False
                        End If
                    Else
                        _oPanel1_Ask.Visible = False
                    End If

                    '---------------------------------
                    cPageSession_BusinessLine._pHeadingMode = False
                    cPageSession_BusinessLine._pOptionMode = False
                    cPageSession_BusinessLine._pQtyMode = True

                    '' ---- @ Added 20210528
                    If InStr(1, _nClass._pOutputRec1, "[AREA]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[GC]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[C]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[CORG]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    Else
                        If _oPanel1_Ask.Visible = False Then
                            _oPanel_Ask.Visible = False
                            _mFnExitTrigger_False_AIF() '' Continiue Procedure
                            _mFnIfHasRecord_GRASKQTY_AIF = False
                        Else
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            _oButtonTaxSave.Enabled = True
                            '_oButtonTaxSave.Text = "Save"
                            _mFnExitTrigger_True_AIF() '
                            Return True

                        End If

                    End If
                    
                Else
                    _mFnExitTrigger_False_AIF() '
                    _oPanel_Ask.Visible = False
                    Return False
                    Exit Function 'Exit
                End If

            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GRRANGE() As Boolean ' @ Added 20170504
        Try
            '----------------------------------
            _mFnIfHasRecord_GRRANGE = False

            cPageSession_BusinessLine._pTblCode = "GRRANGE"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            _nClass._pSubSelect_GRRANGE()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRRANGE = True
                Else
                    Return False
                    Exit Function

                End If

            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GROPTION_AIF() As Boolean '@  Added 20170428

        Try
            '----------------------------------
            _mFnIfHasRecord_GROPTION_AIF = False

            cPageSession_BusinessLine._pTblCode = "GROPTION"
            '_oPanel_oGridViewOption.Visible = False

            Dim _nGridView As New GridView
            _nGridView = _oGridViewOption
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            _nClass._pSubSelect_GROPTION()
            'If cPageSession_BusinessLine._pTaxCode2Mode = False Then
            '    _nClass._pSubSelect_GROPTION()
            'Else
            '    _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
            '    _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
            '    _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
            '    _nClass._pSubSelect_GROPTION_TaxCode2()
            'End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GROPTION_AIF = True
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()   '

                    ''_oPanel_oGridViewOption.Height = 150
                    _oPanel_oGridViewOption.Visible = True
                    cPageSession_BusinessLine._pHeadingMode = False
                    cPageSession_BusinessLine._pOptionMode = True
                    cPageSession_BusinessLine._pQtyMode = False
                    _oPanel_Ask.Visible = True
                    ShowPopup()
                    _nFnHide_PanelAsk()
                    _mFnExitTrigger_True_AIF() '

                    '_oButtonTaxSave.Text = "Save"
                    _oButtonTaxSave.Enabled = True
                    _oPanel_Ask.Visible = True
                    _oPanelProcess.Visible = False
                    '_mpAsk.Show()
                    Return True



                    ' Ask info. GRASKHDG

                Else
                    _mFnExitTrigger_False_AIF()

                    _oPanel_oGridViewOption.Visible = False
                    ''_oPanel_oGridViewOption.Height = 25
                    Return False
                    Exit Function 'Exit
                End If
                cPageSession_BusinessLine._pRowCountBuslineOption = _nDataTable.Rows.Count
            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub _mFnExitTrigger_False_AIF()
        Dim _mExitCode As String
        _mExitCode = cPageSession_BusinessLine._pTaxField

        Select Case _mExitCode  ' @ Modified 20170621
            Case "ELECCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "MECHCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "BLDGCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "SIGNCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "EPOCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "EIFCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "PLATECODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
        End Select

    End Sub

    Private Sub _mFnExitTrigger_True_AIF()
        Dim _mExitCode As String
        _mExitCode = cPageSession_BusinessLine._pTaxField

        Select Case _mExitCode  ' @ Modified 20170621
            Case "ELECCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = True
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "MECHCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = True
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "BLDGCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = True
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "SIGNCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = True
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "EPOCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = True
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "EIFCODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = True
                cPageSession_BusinessLine._pExit_PLATECODE = False
            Case "PLATECODE"
                cPageSession_BusinessLine._pExit_ELECCODE = False
                cPageSession_BusinessLine._pExit_MECHCODE = False
                cPageSession_BusinessLine._pExit_BLDGCODE = False
                cPageSession_BusinessLine._pExit_SIGNCODE = False
                cPageSession_BusinessLine._pExit_EPOCODE = False
                cPageSession_BusinessLine._pExit_EIFCODE = False
                cPageSession_BusinessLine._pExit_PLATECODE = True
        End Select

    End Sub


#End Region

#Region "FOR AIF AND BASIC FEES"

    Private Sub _nFnHide_PanelAsk()  '20171113 Added LOuie
        _oPanel1_Ask.Visible = False
        _oPanel2_Ask.Visible = False
        _oPanel3_Ask.Visible = False
        _oPanel4_Ask.Visible = False
        _oPanel5_Ask.Visible = False
        _oPanel6_Ask.Visible = False
        _oPanel7_Ask.Visible = False
        _oPanel8_Ask.Visible = False
        _oPanel9_Ask.Visible = False
        _oPanel10_Ask.Visible = False
        ' _oPanel_oGridViewOption.Visible = False
    End Sub

    Private Sub _mFnContinueDataGather()
        Select Case True
            Case cPageSession_BusinessLine._pELECCODE
                _mAskELECCODE()
                If cPageSession_BusinessLine._pExit_ELECCODE = False Then
                    _mAskMECHCODE()
                Else
                    cPageSession_BusinessLine._pExit_ELECCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MECHCODE = False Then
                    _mAskBLDGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MECHCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BLDGCODE = False Then
                    _mAskSIGNCODE()
                Else
                    cPageSession_BusinessLine._pExit_BLDGCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                    _mAskEPOCODE()
                Else
                    cPageSession_BusinessLine._pExit_SIGNCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If

                '---------- Continue until basic fees ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pMECHCODE
                _mAskMECHCODE()
                If cPageSession_BusinessLine._pExit_MECHCODE = False Then
                    _mAskBLDGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MECHCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BLDGCODE = False Then
                    _mAskSIGNCODE()
                Else
                    cPageSession_BusinessLine._pExit_BLDGCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                    _mAskEPOCODE()
                Else
                    cPageSession_BusinessLine._pExit_SIGNCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
                '---------- Continue until basic fees ' remarkes 20200115
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pBLDGCODE
                _mAskBLDGCODE()
                If cPageSession_BusinessLine._pExit_BLDGCODE = False Then
                    _mAskSIGNCODE()
                Else
                    cPageSession_BusinessLine._pExit_BLDGCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                    _mAskEPOCODE()
                Else
                    cPageSession_BusinessLine._pExit_SIGNCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
                ''---------- Continue until basic fees ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pSIGNCODE
                _mAskSIGNCODE()
                If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                    _mAskEPOCODE()
                Else
                    cPageSession_BusinessLine._pExit_SIGNCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
                ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pEPOCODE
                _mAskEPOCODE()
                If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                    _mAskEIFCODE()
                Else
                    cPageSession_BusinessLine._pExit_EPOCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
                ''---------- Continue until basic fees ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pEIFCODE
                _mAskEIFCODE()
                If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                    _mAskPLATECODE()
                Else
                    cPageSession_BusinessLine._pExit_EIFCODE = True
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pPLATECODE
                _mAskPLATECODE()
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                ''---------- Continue until basic fees ' 20170823
                If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                    _mAskBCODE() 'Proceed to basic fees
                Else
                    cPageSession_BusinessLine._pExit_PLATECODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If

            Case cPageSession_BusinessLine._pBCODE
                _mAskBCODE()
                If cPageSession_BusinessLine._pExit_BCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskMCODE()
                Else
                    cPageSession_BusinessLine._pExit_BCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    cPageSession_BusinessLine._pExit_MCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    cPageSession_BusinessLine._pExit_GCODE = True
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    cPageSession_BusinessLine._pExit_SCODE = True
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    Exit Sub
                End If

            Case cPageSession_BusinessLine._pMCODE
                _mAskMCODE()
                If cPageSession_BusinessLine._pExit_MCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskGCODE()
                Else
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    Exit Sub
                End If

            Case cPageSession_BusinessLine._pGCODE
                _mAskGCODE()
                If cPageSession_BusinessLine._pExit_GCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskSCODE()
                Else
                    Exit Sub
                End If
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    Exit Sub
                End If

            Case cPageSession_BusinessLine._pSCODE
                _mAskSCODE()
                If cPageSession_BusinessLine._pExit_SCODE = False Then
                    cPageSession_BusinessLine._pTaxCode2Mode = False
                    cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                    _mAskFCODE()
                Else
                    Exit Sub
                End If
            Case cPageSession_BusinessLine._pFCODE
                cPageSession_BusinessLine._pTaxCode2Mode = False
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskFCODE()
        End Select


    End Sub

    Private Function _mFnIfHasRecord_GRADTABL() As Boolean     'Active  '@  Added 20170420
        Try
            '----------------------------------
            _mFnIfHasRecord_GRADTABL = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRADTABL"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            ' cPageSession_BusinessLine._pTaxCode2Mode = False

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._pSubSelect_GRADTABL()
            Else
                _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
                _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
                _nClass._pSubSelect_GRADTABL_TaxCode2()
            End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    '_mFnIfHasRecord_GRADTABL = True
                    '_oPanel_Ask.Visible = True
                    '_mpAsk.Show()
                    _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
                    _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
                    _nClass._pTblCode = cPageSession_BusinessLine._pTblCode

                    _nClass._mSubGetGRADTABLValue()

                    Select Case True
                        Case cPageSession_BusinessLine._pBCODE
                            cPageSession_BusinessLine._pBCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pBCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pBCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pBCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pBCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pMCODE
                            cPageSession_BusinessLine._pMCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pMCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pMCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pMCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pMCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pGCODE
                            cPageSession_BusinessLine._pGCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pGCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pGCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pGCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pGCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pSCODE
                            cPageSession_BusinessLine._pSCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pSCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pSCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pSCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pSCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                        Case cPageSession_BusinessLine._pFCODE
                            cPageSession_BusinessLine._pFCOMPSW = _nClass._pCOMPSW
                            cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode = _nClass._pTaxCode ' ==> Save TaxCode to Temporary Variable
                            cPageSession_BusinessLine._pFCODE_GRADTABL_EffYear = _nClass._pGradYear ' ==> Save Eff_Year to Temporary Variable
                            cPageSession_BusinessLine._pFCODE_GRADTABL_EffMonth = _nClass._pGradMonth ' ==> Save Eff_Month to Temporary Variable
                            cPageSession_BusinessLine._pFCODE_GRADTABL_TaxMin = _nClass._pGradTaxMin
                            cPageSession_BusinessLine._pFCODE_GRADTABL_TaxMax = _nClass._pGradTaxMax
                    End Select

                    If _nClass._pTaxAmt <> 0.0 Then

                        '-------------------------------------------------------------------------
                        ' Get Tax Amount for comparison of Min and Max
                        _mFnIfHasRecord_GRADTABL = True

                        Select Case True
                            Case cPageSession_BusinessLine._pBCODE
                                cPageSession_BusinessLine._pBCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                            Case cPageSession_BusinessLine._pMCODE
                                cPageSession_BusinessLine._pMCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                            Case cPageSession_BusinessLine._pGCODE
                                cPageSession_BusinessLine._pGCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                            Case cPageSession_BusinessLine._pSCODE
                                cPageSession_BusinessLine._pSCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                            Case cPageSession_BusinessLine._pFCODE
                                cPageSession_BusinessLine._pFCODE_GRADTABL_TaxAmt = _nClass._pTaxAmt ' ==> Save TaxCode to Temporary Variable
                        End Select
                        '-------------------------------------------------------------------------
                        ' _mFnExitTrigger_True()
                        Return True
                        Exit Function 'Exit
                    ElseIf _nClass._pTaxRate <> 0.0 Then ' @ Added 20170713
                        ' Get TAXCODE, YEAR and MONTH then Refer to GRRANGE
                        Select Case True
                            Case cPageSession_BusinessLine._pBCODE
                                cPageSession_BusinessLine._pBCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                            Case cPageSession_BusinessLine._pMCODE
                                cPageSession_BusinessLine._pMCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                            Case cPageSession_BusinessLine._pGCODE
                                cPageSession_BusinessLine._pGCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                            Case cPageSession_BusinessLine._pSCODE
                                cPageSession_BusinessLine._pSCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                            Case cPageSession_BusinessLine._pFCODE
                                cPageSession_BusinessLine._pFCODE_GRADTABL_TaxRate = _nClass._pTaxRate ' ==> Save TaxRate to Temporary Variable
                        End Select
                        Return False
                    End If

                Else
                    Return False
                    Exit Function 'Exit
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

    Private Sub _mSubCollectAskHeading(_nDataTable As DataTable)
        Try
            Dim _nRow As Integer = 0
            For Each nDataRow As DataRow In _nDataTable.Rows
                Select Case _nRow
                    Case 0
                        _oPanel1_Ask.Visible = True
                        _oLabel1_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel1_Ask.Visible = True
                        _oTextBox1_Ask.Text = Nothing
                    Case 1
                        _oPanel2_Ask.Visible = True
                        _oLabel2_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel2_Ask.Visible = True
                        _oTextBox2_Ask.Text = Nothing
                    Case 2
                        _oPanel3_Ask.Visible = True
                        _oLabel3_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel3_Ask.Visible = True
                        _oTextBox3_Ask.Text = Nothing
                    Case 3
                        _oPanel4_Ask.Visible = True
                        _oLabel4_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel4_Ask.Visible = True
                        _oTextBox4_Ask.Text = Nothing
                    Case 4
                        _oPanel5_Ask.Visible = True
                        _oLabel5_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel5_Ask.Visible = True
                        _oTextBox5_Ask.Text = Nothing
                    Case 5
                        _oPanel6_Ask.Visible = True
                        _oLabel6_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel6_Ask.Visible = True
                        _oTextBox6_Ask.Text = Nothing
                    Case 6
                        _oPanel7_Ask.Visible = True
                        _oLabel7_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel7_Ask.Visible = True
                        _oTextBox7_Ask.Text = Nothing
                    Case 7
                        _oPanel8_Ask.Visible = True
                        _oLabel8_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel8_Ask.Visible = True
                        _oTextBox8_Ask.Text = Nothing
                    Case 8
                        _oPanel9_Ask.Visible = True
                        _oLabel9_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel9_Ask.Visible = True
                        _oTextBox9_Ask.Text = Nothing
                    Case 9
                        _oPanel10_Ask.Visible = True
                        _oLabel10_Ask.Text = Trim(_nDataTable.Rows(_nRow).Item("ASKHDG").ToString)
                        _oLabel10_Ask.Visible = True
                        _oTextBox10_Ask.Text = Nothing
                End Select

                _nRow = _nRow + 1
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Function _mFnCallClssAIF_RANGE(ByVal XTaxCode As String, ByVal xEff_Yr As String, ByVal xEff_Mo As String, ByVal xTaxbase As Double, ByVal xServices As String) As Double
        Try
            _mFnCallClssAIF_RANGE = 0
            Dim _nClass As New cDalBusinessLine
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

                Dim _nClssBPLTAS As New BPLTAS_AIFASKRANGE_OL.ClsAIFRange
                Dim x As String = Nothing

                '_nClssBPLTAS.BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                '_nClssBPLTAS.BPLTAS_xUID = "juan.dela.cruz"
                '_nClssBPLTAS.BPLTAS_xPW = "#P@ssw0rd#"

                '_nClssBPLTAS.LIVE_BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                '_nClssBPLTAS.LIVE_BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                '_nClssBPLTAS.LIVE_BPLTAS_xUID = "sa"
                '_nClssBPLTAS.LIVE_BPLTAS_xPW = "P@ssw0rd"


                'BPLTIMS
                Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
                _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
                _nClBPLTIMS._pSubRecordSelectSpecific()

                _nClssBPLTAS.BPLTAS_SERVER = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                _nClssBPLTAS.BPLTAS_xDataBase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                _nClssBPLTAS.BPLTAS_xUID = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
                _nClssBPLTAS.BPLTAS_xPW = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"

                'BPLTAS LIVE
                Dim _nClBP As New cDalGlobalConnectionsDefault
                _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                _nClBP._pSubRecordSelectSpecific()

                _nClssBPLTAS.LIVE_BPLTAS_SERVER = _nClBP._pDBDataSource ' cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                _nClssBPLTAS.LIVE_BPLTAS_xDataBase = _nClBP._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                _nClssBPLTAS.LIVE_BPLTAS_xUID = _nClBP._pDBUserID '"sa"
                _nClssBPLTAS.LIVE_BPLTAS_xPW = _nClBP._pDBUserKey '"P@ssw0rd"


                ' "128.1.14.4\MSSQL2012DEV"
                '"R&D.BPLTIMS"
                _nClssBPLTAS.BPLTAS_xTaxbase = xTaxbase
                _nClssBPLTAS.BPLTAS_xTaxcode = XTaxCode
                _nClssBPLTAS.BPLTAS_xEff_Yr = xEff_Yr
                _nClssBPLTAS.BPLTAS_xEff_Mo = xEff_Mo
                _nClssBPLTAS.BPLTAS_xIsServices = xServices

                _nClssBPLTAS.pSub_AIF_RANGE()

                _mFnCallClssAIF_RANGE = _nClssBPLTAS.pAIFDue

            End With
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function HasRange(ByVal Taxcode As String, ByVal EffYr As String, ByVal EffMo As String) As Boolean
        Try
            HasRange = False

            Dim _nClass As New cDalBusinessLine
            _nClass._mSubCheckGRANGE(Taxcode, EffMo, EffYr)

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            If _nDataTable.Rows.Count <> 0 Then
                HasRange = True
            End If
        Catch ex As Exception
            HasRange = False
        End Try
    End Function

    Private Sub _mCheckInputedData()    '@  Added 20170427
        Dim _nClass As New cDalBusinessLine
        '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        If _oTextBox1_Ask.Text <> "" Then   '@ 20170428
            _mSubSaveInputedData_Textbox1()
            If _oTextBox2_Ask.Text <> "" Then
                _mSubSaveInputedData_Textbox2()
                If _oTextBox3_Ask.Text <> "" Then
                    _mSubSaveInputedData_Textbox3()
                    If _oTextBox4_Ask.Text <> "" Then
                        _mSubSaveInputedData_Textbox4()
                        If _oTextBox5_Ask.Text <> "" Then
                            _mSubSaveInputedData_Textbox5()
                            If _oTextBox6_Ask.Text <> "" Then
                                _mSubSaveInputedData_Textbox6()
                                If _oTextBox7_Ask.Text <> "" Then
                                    _mSubSaveInputedData_Textbox7()
                                    If _oTextBox8_Ask.Text <> "" Then
                                        _mSubSaveInputedData_Textbox8()
                                        If _oTextBox9_Ask.Text <> "" Then
                                            _mSubSaveInputedData_Textbox9()
                                            If _oTextBox10_Ask.Text <> "" Then
                                                _mSubSaveInputedData_Textbox10()
                                            Else
                                                GoTo Here
                                            End If
                                        Else
                                            GoTo Here
                                        End If
                                    Else
                                        GoTo Here
                                    End If
                                Else
                                    GoTo Here
                                End If
                            Else
                                GoTo Here
                            End If
                        Else
                            GoTo Here
                        End If
                    Else
                        GoTo Here
                    End If
                Else
                    GoTo Here
                End If
            Else
                GoTo Here
            End If
        Else
            GoTo Here
        End If
Here:
        Select Case True
            Case cPageSession_BusinessLine._pELECCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = True
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pMECHCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = True
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pBLDGCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = True
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pSIGNCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = True
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pEPOCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = True
                cPageSession_BusinessLine._pPLATECODE = False
            Case cPageSession_BusinessLine._pEIFCODE
                cPageSession_BusinessLine._pELECCODE = False
                cPageSession_BusinessLine._pMECHCODE = False
                cPageSession_BusinessLine._pBLDGCODE = False
                cPageSession_BusinessLine._pSIGNCODE = False
                cPageSession_BusinessLine._pEPOCODE = False
                cPageSession_BusinessLine._pEIFCODE = False
                cPageSession_BusinessLine._pPLATECODE = True
            Case cPageSession_BusinessLine._pPLATECODE
                cPageSession_BusinessLine._pPLATECODE = False
                cPageSession_BusinessLine._pBCODE = True

            Case cPageSession_BusinessLine._pBCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = True
                cPageSession_BusinessLine._pGCODE = False
                cPageSession_BusinessLine._pSCODE = False
                cPageSession_BusinessLine._pFCODE = False
            Case cPageSession_BusinessLine._pMCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = False
                cPageSession_BusinessLine._pGCODE = True
                cPageSession_BusinessLine._pSCODE = False
                cPageSession_BusinessLine._pFCODE = False
            Case cPageSession_BusinessLine._pGCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = False
                cPageSession_BusinessLine._pGCODE = False
                cPageSession_BusinessLine._pSCODE = True
                cPageSession_BusinessLine._pFCODE = False
            Case cPageSession_BusinessLine._pSCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = False
                cPageSession_BusinessLine._pGCODE = False
                cPageSession_BusinessLine._pSCODE = False
                cPageSession_BusinessLine._pFCODE = True
            Case cPageSession_BusinessLine._pFCODE
                cPageSession_BusinessLine._pBCODE = False
                cPageSession_BusinessLine._pMCODE = False
                cPageSession_BusinessLine._pGCODE = False
                cPageSession_BusinessLine._pSCODE = False
                cPageSession_BusinessLine._pFCODE = False
                '' cPageSession_BusinessLine._pGCODE = True
        End Select
        cPageSession_BusinessLine._pTaxCode2Mode = False
        _mFnContinueDataGather()

        '''Select Case True        '   @ Added 20170819
        '''    Case cPageSession_BusinessLine._pExit_BCODE
        '''        _mAskMCODE()
        '''    Case cPageSession_BusinessLine._pExit_MCODE
        '''        _mAskGCODE()
        '''    Case cPageSession_BusinessLine._pExit_GCODE
        '''        _mAskSCODE()
        '''    Case cPageSession_BusinessLine._pExit_SCODE ' @ Added 20170627
        '''        _mAskFCODE()
        '''End Select

    End Sub

    Private Sub _GetSelectGridviewIndex(_nGridview As GridView)

        Try

            If _nGridview.SelectedRow IsNot Nothing Then
                cPageSession_BusinessLine._pRowCountBuslineOption = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                cPageSession_BusinessLine._pOptionTaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                cPageSession_BusinessLine._pOptionBusDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                cPageSession_BusinessLine._pOptionTaxCode2 = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode2"), Label).Text)
                cPageSession_BusinessLine._pOptionTaxRate = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxRate"), Label).Text)
                cPageSession_BusinessLine._pOptionTaxAmt = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                ''''''   Added   20170511
                cPageSession_BusinessLine._pEff_Month = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Month"), Label).Text)
                cPageSession_BusinessLine._pEff_Year = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                ''''''   Added   20170616
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_FEE = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pBCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pBCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pBCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pBCHOICE_trg = True
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pMCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pMCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pMCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pMCHOICE_trg = True
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pGCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pGCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pGCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pGCHOICE_trg = True
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pSCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pSCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pSCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pSCHOICE_trg = True
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_Option_RowNo = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
                        cPageSession_BusinessLine._pFCODE_Option_TaxCode = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
                        cPageSession_BusinessLine._pFCODE_Option_TaxDesc = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelOption"), Label).Text)
                        cPageSession_BusinessLine._pFCODE_Option_TaxYear = Trim(DirectCast(_nGridview.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
                        cPageSession_BusinessLine._pFCHOICE_trg = True
                End Select


            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub _mSubSaveSelectedValue() '@ Added 20170502

        '_GetSelectGridviewIndex(_oGridViewOption) ' Remarked 20210623

        cPageSession_BusinessLine._pTaxCode2Mode = False
        _LogData(cPageSession_BusinessLine._pTaxField & ": OPTION SELECTED", cPageSession_BusinessLine._pOptionBusDesc & IIf(cPageSession_BusinessLine._pOptionTaxCode2 <> Nothing, " [TAXCODE2: " & cPageSession_BusinessLine._pOptionTaxCode2 & "]", ""))

        If Not cPageSession_BusinessLine._pOptionTaxCode2 = Nothing Then
            cPageSession_BusinessLine._pTaxCode2Mode = True
            '_mFnIfHasRecord_GRADTABL() ' Goto GRADTABL
            '   Added 20170515
            _mFnContinueDataGather()
            Exit Sub
        Else
            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = cPageSession_BusinessLine._pOptionBusDesc
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            '_nClass._pInputVal = _oTextBox1_Ask.Text
            _nClass._pTaxCode = cPageSession_BusinessLine._pOptionTaxCode
            _nClass._pTaxRate = cPageSession_BusinessLine._pOptionTaxRate
            _nClass._pTaxAmt = cPageSession_BusinessLine._pOptionTaxAmt
            '_nClass._mSubSavetoTableComputation()

            _oGridViewOption.SelectedIndex = IIf(cPageSession_BusinessLine._pRowCountBuslineOption = 1, 2, cPageSession_BusinessLine._pRowCountBuslineOption)
            Select Case True
                Case cPageSession_BusinessLine._pELECCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = True
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pMECHCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = True
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pBLDGCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = True
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pSIGNCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = True
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pEPOCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = True
                    cPageSession_BusinessLine._pPLATECODE = False
                Case cPageSession_BusinessLine._pEIFCODE
                    cPageSession_BusinessLine._pELECCODE = False
                    cPageSession_BusinessLine._pMECHCODE = False
                    cPageSession_BusinessLine._pBLDGCODE = False
                    cPageSession_BusinessLine._pSIGNCODE = False
                    cPageSession_BusinessLine._pEPOCODE = False
                    cPageSession_BusinessLine._pEIFCODE = False
                    cPageSession_BusinessLine._pPLATECODE = True
                Case cPageSession_BusinessLine._pPLATECODE
                    cPageSession_BusinessLine._pPLATECODE = False
                    cPageSession_BusinessLine._pBCODE = True

                Case cPageSession_BusinessLine._pBCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = True
                    cPageSession_BusinessLine._pGCODE = False
                    cPageSession_BusinessLine._pSCODE = False
                    cPageSession_BusinessLine._pFCODE = False
                Case cPageSession_BusinessLine._pMCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = False
                    cPageSession_BusinessLine._pGCODE = True
                    cPageSession_BusinessLine._pSCODE = False
                    cPageSession_BusinessLine._pFCODE = False
                Case cPageSession_BusinessLine._pGCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = False
                    cPageSession_BusinessLine._pGCODE = False
                    cPageSession_BusinessLine._pSCODE = True
                    cPageSession_BusinessLine._pFCODE = False
                Case cPageSession_BusinessLine._pSCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = False
                    cPageSession_BusinessLine._pGCODE = False
                    cPageSession_BusinessLine._pSCODE = False
                    cPageSession_BusinessLine._pFCODE = True
                Case cPageSession_BusinessLine._pFCODE
                    cPageSession_BusinessLine._pBCODE = False
                    cPageSession_BusinessLine._pMCODE = False
                    cPageSession_BusinessLine._pGCODE = False
                    cPageSession_BusinessLine._pSCODE = False
                    cPageSession_BusinessLine._pFCODE = False
            End Select
            cPageSession_BusinessLine._pTaxCode2Mode = False
            _mFnContinueDataGather()
            Exit Sub

        End If
    End Sub
    Private Function _mFnGetAIFTaxBase(ByVal xSwitch As Integer) As Double
        Try
            _mFnGetAIFTaxBase = 0
            'Get Taxbase Basis
            Dim xTaxBase As Double : Dim TaxAmt As Double : Dim RTaxAmt As Double : Dim TaxRate As Double : Dim RTaxRate As Double

            If xSwitch = 1 Then 'Elec
                TaxAmt = IIf(cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pELECCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pELECCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pELECCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pELECCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 2 Then 'Mech
                TaxAmt = IIf(cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pMECHCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pMECHCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pMECHCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pMECHCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 3 Then 'Bldg
                TaxAmt = IIf(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pBLDGCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pBLDGCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 4 Then 'Sign
                TaxAmt = IIf(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pSIGNCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pSIGNCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 5 Then 'Epo
                TaxAmt = IIf(cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pEPOCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pEPOCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pEPOCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pEPOCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 6 Then 'Eif
                TaxAmt = IIf(cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pEIFCODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pEIFCODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pEIFCODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pEIFCODE_GRADTABL_RTaxRate)
            ElseIf xSwitch = 7 Then 'Plate
                TaxAmt = IIf(cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxAmt = Nothing, 0, cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxAmt)
                RTaxAmt = IIf(cPageSession_BusinessLine._pPLATECODE_GRADTABL_RTaxAmt = Nothing, 0, cPageSession_BusinessLine._pPLATECODE_GRADTABL_RTaxAmt)
                TaxRate = IIf(cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxRate = Nothing, 0, cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxRate)
                RTaxRate = IIf(cPageSession_BusinessLine._pPLATECODE_GRADTABL_RTaxRate = Nothing, 0, cPageSession_BusinessLine._pPLATECODE_GRADTABL_RTaxRate)
            End If

            If TaxAmt > 0 Or TaxRate > 0 And cPageSession_BusinessLine._pSTATCODE = "N" Then '20170724 basis of computation is capital
                xTaxBase = cPageSession_BusinessLine._pCAPITAL
            ElseIf RTaxAmt > 0 Or RTaxRate > 0 And cPageSession_BusinessLine._pSTATCODE = "R" Then  '20170724 basis of computation is gross
                xTaxBase = cPageSession_BusinessLine._pGROSS
                'Original
            ElseIf InStr(1, _oLabel1_Ask.Text, "[AREA]") <> 0 Then
                xTaxBase = cPageSession_BusinessLine._pAREA
            ElseIf InStr(1, _oLabel1_Ask.Text, "[GC]") <> 0 Then '20170120
                If cPageSession_BusinessLine._pSTATCODE = "R" Then
                    xTaxBase = cPageSession_BusinessLine._pGROSS
                Else
                    xTaxBase = cPageSession_BusinessLine._pCAPITAL
                End If
                '''    ElseIf InStr(1, xHdg, "[G]") <> 0 Then '20170120
                '''        TAXBASE = txtGross.Value
            ElseIf InStr(1, _oLabel1_Ask.Text, "[C]") <> 0 Then '20170120
                xTaxBase = cPageSession_BusinessLine._pCAPITAL
            ElseIf InStr(1, UCase(_oLabel1_Ask.Text), "[CORG]") <> 0 Then '20170122  'replace [CorG] to uppercase 20170131
                If cPageSession_BusinessLine._pGROSS <> 0 And cPageSession_BusinessLine._pCAPITAL = 0 And cPageSession_BusinessLine._pSTATCODE = "R" Then
                    xTaxBase = cPageSession_BusinessLine._pGROSS
                ElseIf cPageSession_BusinessLine._pGROSS = 0 And cPageSession_BusinessLine._pCAPITAL <> 0 And cPageSession_BusinessLine._pSTATCODE = "R" Then
                    xTaxBase = cPageSession_BusinessLine._pCAPITAL
                ElseIf cPageSession_BusinessLine._pSTATCODE Then
                    xTaxBase = cPageSession_BusinessLine._pGROSS
                Else
                    xTaxBase = cPageSession_BusinessLine._pCAPITAL
                End If
            Else 'Original
                xTaxBase = cPageSession_BusinessLine._pAREA
            End If
            _mFnGetAIFTaxBase = xTaxBase
        Catch ex As Exception
            _mFnGetAIFTaxBase = 0
        End Try
    End Function
    Private Sub _mSubSaveInputedData_Textbox1() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "1"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox1_Ask.Text

            '' _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------
            'Get Taxbase Basis
            Dim xTaxCode As String : Dim xTaxBase As Double

            Select Case True
                Case cPageSession_BusinessLine._pELECCODE
                    xTaxBase = _mFnGetAIFTaxBase(1)
                Case cPageSession_BusinessLine._pMECHCODE
                    xTaxBase = _mFnGetAIFTaxBase(2)
                Case cPageSession_BusinessLine._pBLDGCODE
                    xTaxBase = _mFnGetAIFTaxBase(3)
                Case cPageSession_BusinessLine._pSIGNCODE
                    xTaxBase = _mFnGetAIFTaxBase(4)
                Case cPageSession_BusinessLine._pEPOCODE
                    xTaxBase = _mFnGetAIFTaxBase(5)
                Case cPageSession_BusinessLine._pEIFCODE
                    xTaxBase = _mFnGetAIFTaxBase(6)
                Case cPageSession_BusinessLine._pPLATECODE
                    xTaxBase = _mFnGetAIFTaxBase(7)

            End Select

            Select Case True

                Case cPageSession_BusinessLine._pELECCODE
                    cPageSession_BusinessLine._pELECCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pELECCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pELECCODE_GRASKHDG_Val = _oTextBox1_Ask.Text()
                    xTaxCode = cPageSession_BusinessLine._pELECCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pELECCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")
                Case cPageSession_BusinessLine._pMECHCODE
                    cPageSession_BusinessLine._pMECHCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pMECHCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pMECHCODE_GRASKHDG_Val = _oTextBox1_Ask.Text()
                    xTaxCode = cPageSession_BusinessLine._pMECHCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pMECHCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pBLDGCODE
                    cPageSession_BusinessLine._pBLDGCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pBLDGCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pBLDGCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pBLDGCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pBLDGCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pSIGNCODE
                    cPageSession_BusinessLine._pSIGNCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pSIGNCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pSIGNCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pSIGNCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pSIGNCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pEPOCODE
                    cPageSession_BusinessLine._pEPOCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pEPOCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pEPOCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pEPOCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pEPOCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pEIFCODE
                    cPageSession_BusinessLine._pEIFCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pEIFCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pEIFCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pEIFCODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pEIFCODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pPLATECODE
                    cPageSession_BusinessLine._pPLATECODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pPLATECODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pPLATECODE_GRASKHDG_Val = _oTextBox1_Ask.Text() '
                    xTaxCode = cPageSession_BusinessLine._pPLATECODE_GRADTABL_TaxCode
                    cPageSession_BusinessLine._pPLATECODE_FEE = _mFnCallClssAIF_RANGE(xTaxCode, _nClass._pASKHDG_Year, _nClass._pASKHDG_Month, xTaxBase, "0")

                Case cPageSession_BusinessLine._pBCODE
                    cPageSession_BusinessLine._pBCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pBCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pBCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                Case cPageSession_BusinessLine._pMCODE
                    cPageSession_BusinessLine._pMCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pMCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pMCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                Case cPageSession_BusinessLine._pGCODE
                    cPageSession_BusinessLine._pGCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pGCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pGCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                Case cPageSession_BusinessLine._pSCODE
                    cPageSession_BusinessLine._pSCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pSCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pSCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                Case cPageSession_BusinessLine._pFCODE
                    cPageSession_BusinessLine._pFCODE_GRASKHDG_Month = _nClass._pASKHDG_Month
                    cPageSession_BusinessLine._pFCODE_GRASKHDG_Year = _nClass._pASKHDG_Year
                    cPageSession_BusinessLine._pFCODE_GRASKHDG_Val = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
            End Select

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then

            'Dim TaxAmt As Double
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord1_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox1_Ask.Text
            'TaxAmt = _nClass._pTaxAmt

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                '_nClass._mSubSavetoTableComputation()

                Select Case True
                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = _oTextBox1_Ask.Text() * _nClass._pTaxAmt1

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE  ' @ Added 20170627
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE  ' @ Added 20170627
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val1 = _oTextBox1_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select

            End If


        End If

        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel1_Ask.Text, _oTextBox1_Ask.Text)

    End Sub
    Private Sub _mSubSaveInputedData_Textbox2() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "2"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox2_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord2_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox2_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                '_nClass._mSubSavetoTableComputation()
                Select Case True
                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox2_Ask.Text() * _nClass._pTaxAmt2)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val2 = _oTextBox2_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel2_Ask.Text, _oTextBox2_Ask.Text)

    End Sub

    Private Sub _mSubSaveInputedData_Textbox3() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "3"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox3_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord3_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox3_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox3_Ask.Text() * _nClass._pTaxAmt3)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val3 = _oTextBox3_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel3_Ask.Text, _oTextBox3_Ask.Text)

    End Sub

    Private Sub _mSubSaveInputedData_Textbox4() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "4"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox4_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord4_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox4_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True
                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox4_Ask.Text() * _nClass._pTaxAmt4)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val4 = _oTextBox4_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel4_Ask.Text, _oTextBox4_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox5() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "5"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox5_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------


        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord5_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox5_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox5_Ask.Text() * _nClass._pTaxAmt5)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val5 = _oTextBox5_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel5_Ask.Text, _oTextBox5_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox6() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "6"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox6_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------


        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord6_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox6_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox6_Ask.Text() * _nClass._pTaxAmt6)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val6 = _oTextBox6_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel6_Ask.Text, _oTextBox6_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox7() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "7"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox7_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord7_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox7_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox7_Ask.Text() * _nClass._pTaxAmt7)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val7 = _oTextBox7_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel7_Ask.Text, _oTextBox7_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox8() '@ Added 20180428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "8"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox8_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord8_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox8_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox8_Ask.Text() * _nClass._pTaxAmt8)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val8 = _oTextBox8_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel8_Ask.Text, _oTextBox8_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox9() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "9"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox9_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord9_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox9_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox9_Ask.Text() * _nClass._pTaxAmt9)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val9 = _oTextBox9_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel9_Ask.Text, _oTextBox9_Ask.Text)
    End Sub

    Private Sub _mSubSaveInputedData_Textbox10() '@ Added 20170428
        Dim _nClass As New cDalBusinessLine

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

        _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
        _nClass._pRowNo = "10"
        _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

        If cPageSession_BusinessLine._pTblCode = "GRASKHDG" Then
            _nClass._pSubSelect_GRASKHDG_ROW()

            _nClass._mFnHasRecord1()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox10_Ask.Text

            _nClass._mSubSavetoTableComputation()
            '----------------------------------------------------------------------------

        ElseIf cPageSession_BusinessLine._pTblCode = "GRASKQTY" Then
            _nClass._pSubSelect_GRASKQTY_ROW()

            _nClass._mFnHasRecord10_GRASKQTY()
            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pTaxDesc = _oLabel1_Ask.Text
            _nClass._pTblCode = cPageSession_BusinessLine._pTblCode
            _nClass._pInputVal = _oTextBox10_Ask.Text

            _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._mSubSavetoTableComputation()
                Select Case True

                    Case cPageSession_BusinessLine._pELECCODE
                        cPageSession_BusinessLine._pELECCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pELECCODE_FEE = cPageSession_BusinessLine._pELECCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pMECHCODE
                        cPageSession_BusinessLine._pMECHCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pMECHCODE_FEE = cPageSession_BusinessLine._pMECHCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pBLDGCODE
                        cPageSession_BusinessLine._pBLDGCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pBLDGCODE_FEE = cPageSession_BusinessLine._pBLDGCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pSIGNCODE
                        cPageSession_BusinessLine._pSIGNCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pSIGNCODE_FEE = cPageSession_BusinessLine._pSIGNCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pEPOCODE
                        cPageSession_BusinessLine._pEPOCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pEPOCODE_FEE = cPageSession_BusinessLine._pEPOCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pEIFCODE
                        cPageSession_BusinessLine._pEIFCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pEIFCODE_FEE = cPageSession_BusinessLine._pEIFCODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)
                    Case cPageSession_BusinessLine._pPLATECODE
                        cPageSession_BusinessLine._pPLATECODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text()
                        cPageSession_BusinessLine._pPLATECODE_FEE = cPageSession_BusinessLine._pPLATECODE_FEE + (_oTextBox10_Ask.Text() * _nClass._pTaxAmt10)

                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            Else
                _nClass._mSubSavetoTableComputation_TaxCode2()
                Select Case True
                    Case cPageSession_BusinessLine._pBCODE
                        cPageSession_BusinessLine._pBCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pMCODE
                        cPageSession_BusinessLine._pMCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pGCODE
                        cPageSession_BusinessLine._pGCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pSCODE
                        cPageSession_BusinessLine._pSCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                    Case cPageSession_BusinessLine._pFCODE
                        cPageSession_BusinessLine._pFCODE_GRASKQTY_Val10 = _oTextBox10_Ask.Text() ' Save Inputed Value to Temporary variable
                End Select
            End If

        End If
        _LogData(cPageSession_BusinessLine._pTaxField & ": " & _oLabel10_Ask.Text, _oTextBox10_Ask.Text)
    End Sub

#End Region

#Region "BASIC FEES DATA GATHERING PROCESS"

    Private Sub _mAskBCODE()
        '_oLabelFeeType.Text = "BUSINESS FEE"
        cPageSession_BusinessLine._pTaxField = "BCODE"

        cPageSession_BusinessLine._pBCODE = True
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = False
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL() = True Then
            If cPageSession_BusinessLine._pBCOMPSW <> 3 Then
                cPageSession_BusinessLine._pBCODE_processed = True
                Exit Sub
            Else
                GoTo Cont
            End If
        ElseIf cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pBCODE_processed = True
            Exit Sub
        Else
Cont:
            If _mFnIfHasRecord_GRASKHDG() = True Then '@ Added 20170412
                _oLabelFeeType.Text = "BUSINESS FEE (ASK HEADING)"
                cPageSession_BusinessLine._pBCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pBCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pBCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pBCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pBCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then '@ Added 20170412
                    _oLabelFeeType.Text = "BUSINESS FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pBCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then '@ Added 20170412
                        _oLabelFeeType.Text = "BUSINESS FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pBCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pBCODE_processed = True
    End Sub

    Private Sub _mAskMCODE() ' @ Added 20170420
        '_oLabelFeeType.Text = "MAYOR'S FEE"
        cPageSession_BusinessLine._pTaxField = "MCODE"

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = True
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = False
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL() = True Then
            If cPageSession_BusinessLine._pMCOMPSW <> 3 Then
                cPageSession_BusinessLine._pMCODE_processed = True
                Exit Sub
            Else
                GoTo Cont
            End If
        ElseIf cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pMCODE_processed = True
            Exit Sub
        Else
Cont:
            If _mFnIfHasRecord_GRASKHDG() = True Then '@ Added 20170412
                _oLabelFeeType.Text = "MAYOR'S FEE (ASK HEADING)"
                cPageSession_BusinessLine._pMCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pMCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pMCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then '@ Added 20170412
                    _oLabelFeeType.Text = "MAYOR'S FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pMCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then '@ Added 20170412
                        _oLabelFeeType.Text = "MAYOR'S FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pMCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pMCODE_processed = True
    End Sub

    Private Sub _mAskGCODE()   ' @ Added 20170518
        '_oLabelFeeType.Text = "GARBAGE FEE"
        cPageSession_BusinessLine._pTaxField = "GCODE"

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = True
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = False
        '_mpAsk.Hide()
        If _mFnIfHasRecord_GRADTABL() = True Then
            If cPageSession_BusinessLine._pGCOMPSW <> 3 Then
                cPageSession_BusinessLine._pGCODE_processed = True
                Exit Sub
            Else
                GoTo Cont
            End If
        ElseIf cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pGCODE_processed = True
            Exit Sub
        Else
Cont:
            If _mFnIfHasRecord_GRASKHDG() = True Then
                _oLabelFeeType.Text = "GARBAGE FEE (ASK HEADING)"
                cPageSession_BusinessLine._pGCODE_processed = True
                Exit Sub

            ElseIf HasRange(cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pGCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pGCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pGCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pGCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then
                    _oLabelFeeType.Text = "GARBAGE FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pGCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then
                        _oLabelFeeType.Text = "GARBAGE FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pGCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pGCODE_processed = True
    End Sub

    Private Sub _mAskSCODE()   ' @ Added 20170518
        '_oLabelFeeType.Text = "SANITARY FEE"
        '_mpAsk.Hide()
        cPageSession_BusinessLine._pTaxField = "SCODE"

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = True
        cPageSession_BusinessLine._pFCODE = False

        If _mFnIfHasRecord_GRADTABL() = True Then
            If cPageSession_BusinessLine._pSCOMPSW <> 3 Then
                cPageSession_BusinessLine._pSCODE_processed = True
                Exit Sub
            Else
                GoTo Cont
            End If
        ElseIf cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pSCODE_processed = True
            Exit Sub
        Else
Cont:
            If _mFnIfHasRecord_GRASKHDG() = True Then
                _oLabelFeeType.Text = "SANITARY FEE (ASK HEADING)"
                cPageSession_BusinessLine._pSCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pSCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pSCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then
                    _oLabelFeeType.Text = "SANITARY FEE (ASK OPTION)"
                    cPageSession_BusinessLine._pSCODE_processed = True
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then
                        _oLabelFeeType.Text = "SANITARY FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pSCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pSCODE_processed = True
    End Sub

    Private Sub _mAskFCODE()   ' @ Added 20170518
        '_oLabelFeeType.Text = "FIRE FEE"
        '_mpAsk.Hide()
        cPageSession_BusinessLine._pTaxField = "FCODE"

        cPageSession_BusinessLine._pBCODE = False
        cPageSession_BusinessLine._pMCODE = False
        cPageSession_BusinessLine._pGCODE = False
        cPageSession_BusinessLine._pSCODE = False
        cPageSession_BusinessLine._pFCODE = True

        If _mFnIfHasRecord_GRADTABL() = True Then
            If cPageSession_BusinessLine._pFCOMPSW <> 3 Then
                cPageSession_BusinessLine._pFCODE_processed = True
                Exit Sub
            Else
                GoTo Cont
            End If
        ElseIf cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode = Nothing Then
            cPageSession_BusinessLine._pFCODE_processed = True
            _mFnExitTrigger_False() '' Continiue Procedure
            ''
            Exit Sub
        Else
Cont:
            If _mFnIfHasRecord_GRASKHDG() = True Then
                _oLabelFeeType.Text = "FIRE FEE (ASK HEADING)"
                cPageSession_BusinessLine._pFCODE_processed = True
                Exit Sub
            ElseIf HasRange(cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pFCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pFCODE_GRADTABL_EffMonth) = True Then
                Dim xTaxBase As Double
                xTaxBase = cPageSession_BusinessLine._pAREA
                cPageSession_BusinessLine._pFCODE_FEE = _mFnCallClssAIF_RANGE(cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pFCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pFCODE_GRADTABL_EffMonth, xTaxBase, "0")
                cPageSession_BusinessLine._pFCODE_processed = True
                Exit Sub
            Else

                If _mFnIfHasRecord_GROPTION() = True Then
                    _oLabelFeeType.Text = "FIRE FEE (ASK OPTION)"
                    'cPageSession_BusinessLine._pFCODE_processed = True  ' Remarked 20210603 Louie
                    Exit Sub
                Else

                    If _mFnIfHasRecord_GRASKQTY() = True Then
                        _oLabelFeeType.Text = "FIRE FEE (ASK QUANTITY)"
                        cPageSession_BusinessLine._pFCODE_processed = True
                        Exit Sub
                    Else
                    End If
                End If
            End If
        End If
        cPageSession_BusinessLine._pFCODE_processed = True
    End Sub

    Private Function _mFnIfHasRecord_GRASKHDG() As Boolean '@ Active  20170420

        Try
            '----------------------------------
            _mFnIfHasRecord_GRASKHDG = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRASKHDG"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._pSubSelect_GRASKHDG()
            Else
                _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
                _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
                _nClass._pSubSelect_GRASKHDG_TaxCode2()
            End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRASKHDG = True

                    If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                        _nClass._mSubGetQuestions_GRASKHDG()
                    Else
                        _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                        _nClass._mSubGetQuestions_GRASKHDG_2()

                    End If

                    '@  Added   20170420    -----------------------
                    '_mSubShowHideInputTextBox()
                    ' Ask info. GRASKHDG
                    '---------------------------------


                    If _nClass._pShowPanel1 = True Then
                        _oPanel1_Ask.Visible = True
                        _oLabel1_Ask.Text = _nClass._pOutputRec1
                        _oLabel1_Ask.Visible = True
                        _oTextBox1_Ask.Text = Nothing

                        If _nClass._pShowPanel2 = True Then
                            _oPanel2_Ask.Visible = True
                            _oLabel2_Ask.Text = _nClass._pOutputRec2
                            _oTextBox2_Ask.Text = Nothing

                            If _nClass._pShowPanel3 = True Then
                                _oPanel3_Ask.Visible = True
                                _oLabel3_Ask.Text = _nClass._pOutputRec3
                                _oTextBox3_Ask.Text = Nothing

                                If _nClass._pShowPanel4 = True Then
                                    _oPanel4_Ask.Visible = True
                                    _oLabel4_Ask.Text = _nClass._pOutputRec4
                                    _oTextBox4_Ask.Text = Nothing

                                    If _nClass._pShowPanel5 = True Then
                                        _oPanel5_Ask.Visible = True
                                        _oLabel5_Ask.Text = _nClass._pOutputRec5
                                        _oTextBox5_Ask.Text = Nothing

                                        If _nClass._pShowPanel6 = True Then
                                            _oPanel6_Ask.Visible = True
                                            _oLabel6_Ask.Text = _nClass._pOutputRec6
                                            _oTextBox6_Ask.Text = Nothing

                                            If _nClass._pShowPanel7 = True Then
                                                _oPanel7_Ask.Visible = True
                                                _oLabel7_Ask.Text = _nClass._pOutputRec7
                                                _oTextBox7_Ask.Text = Nothing

                                                If _nClass._pShowPanel8 = True Then
                                                    _oPanel8_Ask.Visible = True
                                                    _oLabel8_Ask.Text = _nClass._pOutputRec8
                                                    _oTextBox8_Ask.Text = Nothing

                                                    If _nClass._pShowPanel9 = True Then
                                                        _oPanel9_Ask.Visible = True
                                                        _oLabel9_Ask.Text = _nClass._pOutputRec9
                                                        _oTextBox9_Ask.Text = Nothing

                                                        If _nClass._pShowPanel10 = True Then
                                                            _oPanel10_Ask.Visible = True
                                                            _oLabel10_Ask.Text = _nClass._pOutputRec10
                                                            _oTextBox10_Ask.Text = Nothing
                                                        Else
                                                            _oPanel10_Ask.Visible = False
                                                        End If
                                                    Else
                                                        _oPanel9_Ask.Visible = False
                                                    End If
                                                Else
                                                    _oPanel8_Ask.Visible = False
                                                End If
                                            Else
                                                _oPanel7_Ask.Visible = False
                                            End If
                                        Else
                                            _oPanel6_Ask.Visible = False
                                        End If
                                    Else
                                        _oPanel5_Ask.Visible = False
                                    End If
                                Else
                                    _oPanel4_Ask.Visible = False
                                End If
                            Else
                                _oPanel3_Ask.Visible = False
                            End If
                        Else
                            _oPanel2_Ask.Visible = False
                        End If
                    Else

                        _oPanel1_Ask.Visible = False
                        _oPanel_Ask.Visible = False
                    End If

                    '---------------------------------
                    cPageSession_BusinessLine._pHeadingMode = True
                    cPageSession_BusinessLine._pOptionMode = False
                    cPageSession_BusinessLine._pQtyMode = False

                    '' ---- @ Added 20170823
                    If InStr(1, _nClass._pOutputRec1, "[AREA]") <> 0 Then
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pAREA

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[GC]") <> 0 Then
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pCAPITAL

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[C]") <> 0 Then
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pAREA

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[CORG]") <> 0 Then
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pCAPITAL

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    Else
                        If _oPanel1_Ask.Visible = False Then
                            _oPanel_Ask.Visible = False
                            _mFnIfHasRecord_GRASKHDG = False
                            _mFnExitTrigger_False() '' Continiue Procedure
                        Else
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanel_Ask.Focus()
                            _mFnExitTrigger_True() '' Exit Gather Info procedure to giveway for Pop Modal
                            '_oButtonTaxSave.Text = "Save"
                            _oButtonTaxSave.Enabled = True
                            _oPanel_Ask.Visible = True
                            _oPanelProcess.Visible = False
                            Return True
                        End If
                    End If
                Else

                    _mFnExitTrigger_False() '' Continiue Procedure
                    _oPanel_Ask.Visible = False
                    Return False
                    Exit Function 'Exit
                End If
            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GROPTION() As Boolean '@  ACTIVE 20170915

        Try
            '----------------------------------
            _mFnIfHasRecord_GROPTION = False

            cPageSession_BusinessLine._pTblCode = "GROPTION"
            '_oPanel_oGridViewOption.Visible = False

            Dim _nGridView As New GridView
            _nGridView = _oGridViewOption
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._pSubSelect_GROPTION()
            Else
                _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
                _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
                _nClass._pSubSelect_GROPTION_TaxCode2()
            End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GROPTION = True
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()   '@ Added 20170502

                    ''_oPanel_oGridViewOption.Height = 150    '@ Added 20170704
                    _oPanel_oGridViewOption.Visible = True
                    cPageSession_BusinessLine._pHeadingMode = False
                    cPageSession_BusinessLine._pOptionMode = True
                    cPageSession_BusinessLine._pQtyMode = False
                    '_oPanelPopUpProcessing.Visible = False
                    _oPanel_Ask.Visible = True
                    ShowPopup()
                    '_oButtonTaxSave.Text = "Save"
                    _oButtonTaxSave.Enabled = True
                    _oPanel_Ask.Visible = True

                    _mFnExitTrigger_True() '
                    _nFnHide_PanelAsk()
                    _oPanel_oGridViewOption.Visible = True
                    _oPanelProcess.Visible = False
                    '_oPanelPopUp_ModalPopupExtender.Hide()  '@ ADDED 20170913
                    '_oPanelPopUp_ModalPopupExtender.Enabled = False  '@ ADDED 20170913
                    ' Ask info. GRASKHDG

                    ''_mpAsk.Show()
                    Return True
                Else
                    _mFnExitTrigger_False()

                    _oPanel_oGridViewOption.Visible = False
                    '_oPanel_oGridViewOption.Height = 25

                    Return False
                    Exit Function 'Exit
                End If

            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnIfHasRecord_GRASKQTY() As Boolean '@  ACTIVE 20170915

        Try
            '----------------------------------
            _mFnIfHasRecord_GRASKQTY = False
            _oPanel_oGridViewOption.Visible = False
            cPageSession_BusinessLine._pTblCode = "GRASKQTY"

            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pBusLineCol = cPageSession_BusinessLine._pTaxField

            If cPageSession_BusinessLine._pTaxCode2Mode = False Then
                _nClass._pSubSelect_GRASKQTY()
            Else
                _nClass._pTaxCode2 = cPageSession_BusinessLine._pOptionTaxCode2
                _nClass._pEff_Month = cPageSession_BusinessLine._pEff_Month
                _nClass._pEff_Year = cPageSession_BusinessLine._pEff_Year
                _nClass._pSubSelect_GRASKQTY_TaxCode2()
            End If

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                If _nDataTable.Rows.Count <> 0 Then
                    _mFnIfHasRecord_GRASKQTY = True

                    _nClass._mSubGetQuestions_GRASKQTY()
                    ' Ask info. GRASKQTY

                    '----------------
                    If _nClass._pShowPanel1 = True Then
                        _oPanel1_Ask.Visible = True
                        _oLabel1_Ask.Text = _nClass._pOutputRec1
                        _oLabel1_Ask.Visible = True
                        _oTextBox1_Ask.Text = Nothing

                        If _nClass._pShowPanel2 = True Then
                            _oPanel2_Ask.Visible = True
                            _oLabel2_Ask.Text = _nClass._pOutputRec2
                            _oTextBox2_Ask.Text = Nothing

                            If _nClass._pShowPanel3 = True Then
                                _oPanel3_Ask.Visible = True
                                _oLabel3_Ask.Text = _nClass._pOutputRec3
                                _oTextBox3_Ask.Text = Nothing

                                If _nClass._pShowPanel4 = True Then
                                    _oPanel4_Ask.Visible = True
                                    _oLabel4_Ask.Text = _nClass._pOutputRec4
                                    _oTextBox4_Ask.Text = Nothing

                                    If _nClass._pShowPanel5 = True Then
                                        _oPanel5_Ask.Visible = True
                                        _oLabel5_Ask.Text = _nClass._pOutputRec5
                                        _oTextBox5_Ask.Text = Nothing

                                        If _nClass._pShowPanel6 = True Then
                                            _oPanel6_Ask.Visible = True
                                            _oLabel6_Ask.Text = _nClass._pOutputRec6
                                            _oTextBox6_Ask.Text = Nothing

                                            If _nClass._pShowPanel7 = True Then
                                                _oPanel7_Ask.Visible = True
                                                _oLabel7_Ask.Text = _nClass._pOutputRec7
                                                _oTextBox7_Ask.Text = Nothing

                                                If _nClass._pShowPanel8 = True Then
                                                    _oPanel8_Ask.Visible = True
                                                    _oLabel8_Ask.Text = _nClass._pOutputRec8
                                                    _oTextBox8_Ask.Text = Nothing

                                                    If _nClass._pShowPanel9 = True Then
                                                        _oPanel9_Ask.Visible = True
                                                        _oLabel9_Ask.Text = _nClass._pOutputRec9
                                                        _oTextBox9_Ask.Text = Nothing

                                                        If _nClass._pShowPanel10 = True Then
                                                            _oPanel10_Ask.Visible = True
                                                            _oLabel10_Ask.Text = _nClass._pOutputRec10
                                                            _oTextBox10_Ask.Text = Nothing
                                                        Else
                                                            _oPanel10_Ask.Visible = False
                                                        End If
                                                    Else
                                                        _oPanel9_Ask.Visible = False
                                                    End If
                                                Else
                                                    _oPanel8_Ask.Visible = False
                                                End If
                                            Else
                                                _oPanel7_Ask.Visible = False
                                            End If
                                        Else
                                            _oPanel6_Ask.Visible = False
                                        End If
                                    Else
                                        _oPanel5_Ask.Visible = False
                                    End If
                                Else
                                    _oPanel4_Ask.Visible = False
                                End If
                            Else
                                _oPanel3_Ask.Visible = False
                            End If
                        Else
                            _oPanel2_Ask.Visible = False
                        End If
                    Else
                        _oPanel1_Ask.Visible = False
                    End If

                    '---------------------------------
                    cPageSession_BusinessLine._pHeadingMode = False
                    cPageSession_BusinessLine._pOptionMode = False
                    cPageSession_BusinessLine._pQtyMode = True

                    '' ---- @ Added 20210528
                    If InStr(1, _nClass._pOutputRec1, "[AREA]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mArea

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[GC]") <> 0 Then '20210528
                        If _mStatus = "R" Then
                            _oTextBox1_Ask.Text = _mGross
                        Else
                            _oTextBox1_Ask.Text = _mCapital
                        End If

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, _nClass._pOutputRec1, "[C]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)

                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[CORG]") <> 0 Then '20210528
                        _oTextBox1_Ask.Text = _mCapital

                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[NOEMP]") <> 0 Then '@Added 20211026
                        _oTextBox1_Ask.Text = cLoader_BPLTIMS._pNO_EMP
                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    ElseIf InStr(1, UCase(_nClass._pOutputRec1), "[ASSET]") <> 0 Then '@Added 20211026
                        _oTextBox1_Ask.Text = 0 ' Assesst sana
                        Dim c As IPostBackEventHandler = DirectCast(Me._oButtonTaxSave, IPostBackEventHandler)
                        c.RaisePostBackEvent(String.Empty)
                    Else

                        If _oPanel1_Ask.Visible = False Then
                            _oPanel_Ask.Visible = False
                            _mFnExitTrigger_False() '' Continiue Procedure
                            _mFnIfHasRecord_GRASKQTY = False

                        Else
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            _oButtonTaxSave.Enabled = True
                            '_oButtonTaxSave.Text = "Save"
                            _mFnExitTrigger_True() '

                            _oButtonTaxSave.Enabled = True
                            _oPanel_Ask.Visible = True
                            ShowPopup()
                            _oPanelProcess.Visible = False
                            Return True
                        End If

                    End If


                    _oPanel_Ask.Visible = True
                    ShowPopup()
                    _oPanelProcess.Visible = False
                    _oButtonTaxSave.Enabled = True
                    '_oButtonTaxSave.Text = "Save"
                    _mFnExitTrigger_True() '
                    '_oPanelPopUp_ModalPopupExtender.Hide()  '@ ADDED 20170913
                    '_oPanelPopUp_ModalPopupExtender.Enabled = False  '@ ADDED 20170913
                    '_mpAsk.Show()

                    Return True
                Else
                    _mFnExitTrigger_False() '
                    _oPanel_Ask.Visible = False
                    Return False
                    Exit Function 'Exit
                End If

            Catch ex As Exception
                Return False
            End Try

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub _mFnExitTrigger_True()
        Dim _mExitCode As String
        _mExitCode = cPageSession_BusinessLine._pTaxField

        Select Case _mExitCode  ' @ Modified 20170621
            Case "BCODE"
                cPageSession_BusinessLine._pExit_BCODE = True
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "MCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = True
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "GCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = True
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "SCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = True
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "FCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = True
        End Select

    End Sub


    Private Sub _mFnExitTrigger_False()
        Dim _mExitCode As String
        _mExitCode = cPageSession_BusinessLine._pTaxField
        Select Case _mExitCode
            Case "BCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "MCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "GCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "SCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
            Case "FCODE"
                cPageSession_BusinessLine._pExit_BCODE = False
                cPageSession_BusinessLine._pExit_MCODE = False
                cPageSession_BusinessLine._pExit_GCODE = False
                cPageSession_BusinessLine._pExit_SCODE = False
                cPageSession_BusinessLine._pExit_FCODE = False
        End Select
    End Sub

#End Region

End Class

'Added 20210722

