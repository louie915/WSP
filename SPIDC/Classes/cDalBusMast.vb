
#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
#End Region



Public Class cDalBusMast

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing

    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader


#End Region

#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property

    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

                Return _mDataTable
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property _pSqlDataReader() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mSqlDataReader = _mSqlCommand.ExecuteReader

                Return _mSqlDataReader
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Variable Field"

    Private _mAdd As Boolean
    Private _mACCTNO As String
    Private _mAcquired_By As String
    Private _mACR_DATE As String
    Private _mACR_NO As String
    Private _mAdditional_Vol As String
    Private _mAPP_DATE As String
    Private _mAppModule As String
    Private _mAPPROVEDBY As String
    Private _mAppUser As String
    Private _mAppUser1 As String
    Private _mAppUserName As String
    Private _mAppUserName1 As String
    Private _mBC_DATE As String
    Private _mBC_NO As String
    Private _mBLDGPERMITDATE As String
    Private _mBLDGPERMITNO As String
    Private _mBOI_DATE As String
    Private _mBOI_NO As String
    Private _mBRANCH As String
    Private _mBRGYCODE As String
    Private _mCDA_DATE As String
    Private _mCDA_NO As String
    Private _mCOMMADDR As String
    Private _mCOMMNAME As String
    Private _mCONTACT As String
    Private _mCONTTEL As String
    Private _mCPNO As String
    Private _mCPNO2 As String
    Private _mCPNO3 As String
    Private _mCPNoGTM As String
    Private _mCPNoSMTNT As String
    Private _mCPNoSun As String
    Private _mCTC_AMT As String
    Private _mCTC_DATE As String
    Private _mCTC_NO As String
    Private _mCTC_PLACE As String
    Private _mCTZNCODE As String
    Private _mDate_Acquired As String
    Private _mDate_Approved As String
    Private _mDATE_ESTA As String
    Private _mDate_Reviewed As String
    Private _mDISTCODE As String
    Private _mDOWNLOADED As String
    Private _mDTI_DATE As String
    Private _mDTI_NO As String
    Private _mEDITTEDBY As String
    Private _mEDITTEDBYDATE As String
    Private _mEMAILADDR As String
    Private _mEMAILADDR2 As String
    Private _mevent_date As String
    Private _mevent_id As String
    Private _mEXAMINEDBY As String
    Private _mEXAMINEDBYDATE As String
    Private _mFACODE As String
    Private _mFIRST_NAME As String
    Private _mFor_Billing As Boolean
    Private _mFor_Payment As Boolean
    Private _mFor_Permit As Boolean
    Private _mGOCC As Boolean
    Private _mGRPBLDG As String
    Private _mhost_name As String
    Private _mIFTRANSF As String
    Private _mINCORPORATORS As String
    Private _mIP As String
    Private _mIS_TERMINAL As String
    Private _misADDRESS As String
    Private _mIsCHANGECOMM As String
    Private _mIsComprimise As String
    Private _mIsCompromise As String
    Private _mIsMarket As String
    Private _misPosted As Boolean
    Private _misPrcs As Boolean
    Private _mIsSpecial As String
    Private _mIsTCampaign As Boolean
    Private _misTourism As Boolean
    Private _mLAST_NAME As String
    Private _mMAIN As String
    Private _mMIDDLE_NAME As String
    Private _mNATURE As String
    Private _mNO_EMP As String
    Private _mOCCUPANCYDATE As String
    Private _mOCCUPANCYNO As String
    Private _mOWNCODE As String
    Private _mOWNERADDR As String
    Private _mOWNERTEL As String
    Private _mP_ADMIN As String
    Private _mP_OWNER As String
    Private _mP_OWNERADDR As String
    Private _mP_RENT As String
    Private _mP_RENTDATE As String
    Private _mP_Reviewing As String
    Private _mpair_id As String
    Private _mPBN As String
    Private _mPEZA_DATE As String
    Private _mPEZA_NO As String
    Private _mPLATENO As String
    Private _mREMARKS As String
    Private _mReviewing As String
    Private _mrg As String
    Private _mRowId As String
    Private _mSEC_DATE As String
    Private _mSEC_NO As String
    Private _mSSS_DATE As String
    Private _mSSS_NO As String
    Private _mSTALLNO As String
    Private _mSTATBY As String
    Private _mSTATCODE As String
    Private _mstatcode1 As String
    Private _mSTATDATE As String
    Private _mSTATDROP As String
    Private _mSTATDROPBY As String
    Private _mSTATDROPDATE As String
    Private _mSTATDROPREM As String
    Private _mSTATDROPTIME As String
    Private _mSTATHOLD As String
    Private _mSTATREMARKS As String
    Private _mSTATUS As String
    Private _mSTICKERNO As String
    Private _mSTRTCODE As String
    Private _msys_name As String
    Private _msys_user As String
    Private _mTIN_DATE As String
    Private _mTIN_NO As String
    Private _mUPLOADED As String
    Private _mVolume_Allow As String
    Private _mXSITE As String

#End Region
#Region "Property Field"

    Public Property _pACCTNO() As String
        Get
            Return _mACCTNO
        End Get
        Set(value As String)
            _mACCTNO = value
        End Set
    End Property

    Public Property _pAcquired_By() As String
        Get
            Return _mAcquired_By
        End Get
        Set(value As String)
            _mAcquired_By = value
        End Set
    End Property

    Public Property _pACR_DATE() As String
        Get
            Return _mACR_DATE
        End Get
        Set(value As String)
            _mACR_DATE = value
        End Set
    End Property

    Public Property _pACR_NO() As String
        Get
            Return _mACR_NO
        End Get
        Set(value As String)
            _mACR_NO = value
        End Set
    End Property

    Public Property _pAdditional_Vol() As String
        Get
            Return _mAdditional_Vol
        End Get
        Set(value As String)
            _mAdditional_Vol = value
        End Set
    End Property

    Public Property _pAPP_DATE() As String
        Get
            Return _mAPP_DATE
        End Get
        Set(value As String)
            _mAPP_DATE = value
        End Set
    End Property

    Public Property _pAppModule() As String
        Get
            Return _mAppModule
        End Get
        Set(value As String)
            _mAppModule = value
        End Set
    End Property

    Public Property _pAPPROVEDBY() As String
        Get
            Return _mAPPROVEDBY
        End Get
        Set(value As String)
            _mAPPROVEDBY = value
        End Set
    End Property

    Public Property _pAppUser() As String
        Get
            Return _mAppUser
        End Get
        Set(value As String)
            _mAppUser = value
        End Set
    End Property

    Public Property _pAppUser1() As String
        Get
            Return _mAppUser1
        End Get
        Set(value As String)
            _mAppUser1 = value
        End Set
    End Property

    Public Property _pAppUserName() As String
        Get
            Return _mAppUserName
        End Get
        Set(value As String)
            _mAppUserName = value
        End Set
    End Property

    Public Property _pAppUserName1() As String
        Get
            Return _mAppUserName1
        End Get
        Set(value As String)
            _mAppUserName1 = value
        End Set
    End Property

    Public Property _pBC_DATE() As String
        Get
            Return _mBC_DATE
        End Get
        Set(value As String)
            _mBC_DATE = value
        End Set
    End Property

    Public Property _pBC_NO() As String
        Get
            Return _mBC_NO
        End Get
        Set(value As String)
            _mBC_NO = value
        End Set
    End Property

    Public Property _pBLDGPERMITDATE() As String
        Get
            Return _mBLDGPERMITDATE
        End Get
        Set(value As String)
            _mBLDGPERMITDATE = value
        End Set
    End Property

    Public Property _pBLDGPERMITNO() As String
        Get
            Return _mBLDGPERMITNO
        End Get
        Set(value As String)
            _mBLDGPERMITNO = value
        End Set
    End Property

    Public Property _pBOI_DATE() As String
        Get
            Return _mBOI_DATE
        End Get
        Set(value As String)
            _mBOI_DATE = value
        End Set
    End Property

    Public Property _pBOI_NO() As String
        Get
            Return _mBOI_NO
        End Get
        Set(value As String)
            _mBOI_NO = value
        End Set
    End Property

    Public Property _pBRANCH() As String
        Get
            Return _mBRANCH
        End Get
        Set(value As String)
            _mBRANCH = value
        End Set
    End Property

    Public Property _pBRGYCODE() As String
        Get
            Return _mBRGYCODE
        End Get
        Set(value As String)
            _mBRGYCODE = value
        End Set
    End Property

    Public Property _pCDA_DATE() As String
        Get
            Return _mCDA_DATE
        End Get
        Set(value As String)
            _mCDA_DATE = value
        End Set
    End Property

    Public Property _pCDA_NO() As String
        Get
            Return _mCDA_NO
        End Get
        Set(value As String)
            _mCDA_NO = value
        End Set
    End Property

    Public Property _pCOMMADDR() As String
        Get
            Return _mCOMMADDR
        End Get
        Set(value As String)
            _mCOMMADDR = value
        End Set
    End Property

    Public Property _pCOMMNAME() As String
        Get
            Return _mCOMMNAME
        End Get
        Set(value As String)
            _mCOMMNAME = value
        End Set
    End Property

    Public Property _pCONTACT() As String
        Get
            Return _mCONTACT
        End Get
        Set(value As String)
            _mCONTACT = value
        End Set
    End Property

    Public Property _pCONTTEL() As String
        Get
            Return _mCONTTEL
        End Get
        Set(value As String)
            _mCONTTEL = value
        End Set
    End Property

    Public Property _pCPNO() As String
        Get
            Return _mCPNO
        End Get
        Set(value As String)
            _mCPNO = value
        End Set
    End Property

    Public Property _pCPNO2() As String
        Get
            Return _mCPNO2
        End Get
        Set(value As String)
            _mCPNO2 = value
        End Set
    End Property

    Public Property _pCPNO3() As String
        Get
            Return _mCPNO3
        End Get
        Set(value As String)
            _mCPNO3 = value
        End Set
    End Property

    Public Property _pCPNoGTM() As String
        Get
            Return _mCPNoGTM
        End Get
        Set(value As String)
            _mCPNoGTM = value
        End Set
    End Property

    Public Property _pCPNoSMTNT() As String
        Get
            Return _mCPNoSMTNT
        End Get
        Set(value As String)
            _mCPNoSMTNT = value
        End Set
    End Property

    Public Property _pCPNoSun() As String
        Get
            Return _mCPNoSun
        End Get
        Set(value As String)
            _mCPNoSun = value
        End Set
    End Property

    Public Property _pCTC_AMT() As String
        Get
            Return _mCTC_AMT
        End Get
        Set(value As String)
            _mCTC_AMT = value
        End Set
    End Property

    Public Property _pCTC_DATE() As String
        Get
            Return _mCTC_DATE
        End Get
        Set(value As String)
            _mCTC_DATE = value
        End Set
    End Property

    Public Property _pCTC_NO() As String
        Get
            Return _mCTC_NO
        End Get
        Set(value As String)
            _mCTC_NO = value
        End Set
    End Property

    Public Property _pCTC_PLACE() As String
        Get
            Return _mCTC_PLACE
        End Get
        Set(value As String)
            _mCTC_PLACE = value
        End Set
    End Property

    Public Property _pCTZNCODE() As String
        Get
            Return _mCTZNCODE
        End Get
        Set(value As String)
            _mCTZNCODE = value
        End Set
    End Property

    Public Property _pDate_Acquired() As String
        Get
            Return _mDate_Acquired
        End Get
        Set(value As String)
            _mDate_Acquired = value
        End Set
    End Property

    Public Property _pDate_Approved() As String
        Get
            Return _mDate_Approved
        End Get
        Set(value As String)
            _mDate_Approved = value
        End Set
    End Property

    Public Property _pDATE_ESTA() As String
        Get
            Return _mDATE_ESTA
        End Get
        Set(value As String)
            _mDATE_ESTA = value
        End Set
    End Property

    Public Property _pDate_Reviewed() As String
        Get
            Return _mDate_Reviewed
        End Get
        Set(value As String)
            _mDate_Reviewed = value
        End Set
    End Property

    Public Property _pDISTCODE() As String
        Get
            Return _mDISTCODE
        End Get
        Set(value As String)
            _mDISTCODE = value
        End Set
    End Property

    Public Property _pDOWNLOADED() As String
        Get
            Return _mDOWNLOADED
        End Get
        Set(value As String)
            _mDOWNLOADED = value
        End Set
    End Property

    Public Property _pDTI_DATE() As String
        Get
            Return _mDTI_DATE
        End Get
        Set(value As String)
            _mDTI_DATE = value
        End Set
    End Property

    Public Property _pDTI_NO() As String
        Get
            Return _mDTI_NO
        End Get
        Set(value As String)
            _mDTI_NO = value
        End Set
    End Property

    Public Property _pEDITTEDBY() As String
        Get
            Return _mEDITTEDBY
        End Get
        Set(value As String)
            _mEDITTEDBY = value
        End Set
    End Property

    Public Property _pEDITTEDBYDATE() As String
        Get
            Return _mEDITTEDBYDATE
        End Get
        Set(value As String)
            _mEDITTEDBYDATE = value
        End Set
    End Property

    Public Property _pEMAILADDR() As String
        Get
            Return _mEMAILADDR
        End Get
        Set(value As String)
            _mEMAILADDR = value
        End Set
    End Property

    Public Property _pEMAILADDR2() As String
        Get
            Return _mEMAILADDR2
        End Get
        Set(value As String)
            _mEMAILADDR2 = value
        End Set
    End Property

    Public Property _pevent_date() As String
        Get
            Return _mevent_date
        End Get
        Set(value As String)
            _mevent_date = value
        End Set
    End Property

    Public Property _pevent_id() As String
        Get
            Return _mevent_id
        End Get
        Set(value As String)
            _mevent_id = value
        End Set
    End Property

    Public Property _pEXAMINEDBY() As String
        Get
            Return _mEXAMINEDBY
        End Get
        Set(value As String)
            _mEXAMINEDBY = value
        End Set
    End Property

    Public Property _pEXAMINEDBYDATE() As String
        Get
            Return _mEXAMINEDBYDATE
        End Get
        Set(value As String)
            _mEXAMINEDBYDATE = value
        End Set
    End Property

    Public Property _pFACODE() As String
        Get
            Return _mFACODE
        End Get
        Set(value As String)
            _mFACODE = value
        End Set
    End Property

    Public Property _pFIRST_NAME() As String
        Get
            Return _mFIRST_NAME
        End Get
        Set(value As String)
            _mFIRST_NAME = value
        End Set
    End Property

    Public Property _pFor_Billing() As Boolean
        Get
            Return _mFor_Billing
        End Get
        Set(value As Boolean)
            _mFor_Billing = value
        End Set
    End Property

    Public Property _pFor_Payment() As Boolean
        Get
            Return _mFor_Payment
        End Get
        Set(value As Boolean)
            _mFor_Payment = value
        End Set
    End Property

    Public Property _pFor_Permit() As Boolean
        Get
            Return _mFor_Permit
        End Get
        Set(value As Boolean)
            _mFor_Permit = value
        End Set
    End Property

    Public Property _pGOCC() As Boolean
        Get
            Return _mGOCC
        End Get
        Set(value As Boolean)
            _mGOCC = value
        End Set
    End Property

    Public Property _pGRPBLDG() As String
        Get
            Return _mGRPBLDG
        End Get
        Set(value As String)
            _mGRPBLDG = value
        End Set
    End Property

    Public Property _phost_name() As String
        Get
            Return _mhost_name
        End Get
        Set(value As String)
            _mhost_name = value
        End Set
    End Property

    Public Property _pIFTRANSF() As String
        Get
            Return _mIFTRANSF
        End Get
        Set(value As String)
            _mIFTRANSF = value
        End Set
    End Property

    Public Property _pINCORPORATORS() As String
        Get
            Return _mINCORPORATORS
        End Get
        Set(value As String)
            _mINCORPORATORS = value
        End Set
    End Property

    Public Property _pIP() As String
        Get
            Return _mIP
        End Get
        Set(value As String)
            _mIP = value
        End Set
    End Property

    Public Property _pIS_TERMINAL() As String
        Get
            Return _mIS_TERMINAL
        End Get
        Set(value As String)
            _mIS_TERMINAL = value
        End Set
    End Property

    Public Property _pisADDRESS() As String
        Get
            Return _misADDRESS
        End Get
        Set(value As String)
            _misADDRESS = value
        End Set
    End Property

    Public Property _pIsCHANGECOMM() As String
        Get
            Return _mIsCHANGECOMM
        End Get
        Set(value As String)
            _mIsCHANGECOMM = value
        End Set
    End Property

    Public Property _pIsComprimise() As String
        Get
            Return _mIsComprimise
        End Get
        Set(value As String)
            _mIsComprimise = value
        End Set
    End Property

    Public Property _pIsCompromise() As String
        Get
            Return _mIsCompromise
        End Get
        Set(value As String)
            _mIsCompromise = value
        End Set
    End Property

    Public Property _pIsMarket() As String
        Get
            Return _mIsMarket
        End Get
        Set(value As String)
            _mIsMarket = value
        End Set
    End Property

    Public Property _pisPosted() As Boolean
        Get
            Return _misPosted
        End Get
        Set(value As Boolean)
            _misPosted = value
        End Set
    End Property

    Public Property _pisPrcs() As Boolean
        Get
            Return _misPrcs
        End Get
        Set(value As Boolean)
            _misPrcs = value
        End Set
    End Property

    Public Property _pIsSpecial() As String
        Get
            Return _mIsSpecial
        End Get
        Set(value As String)
            _mIsSpecial = value
        End Set
    End Property

    Public Property _pIsTCampaign() As Boolean
        Get
            Return _mIsTCampaign
        End Get
        Set(value As Boolean)
            _mIsTCampaign = value
        End Set
    End Property

    Public Property _pisTourism() As Boolean
        Get
            Return _misTourism
        End Get
        Set(value As Boolean)
            _misTourism = value
        End Set
    End Property

    Public Property _pLAST_NAME() As String
        Get
            Return _mLAST_NAME
        End Get
        Set(value As String)
            _mLAST_NAME = value
        End Set
    End Property

    Public Property _pMAIN() As String
        Get
            Return _mMAIN
        End Get
        Set(value As String)
            _mMAIN = value
        End Set
    End Property

    Public Property _pMIDDLE_NAME() As String
        Get
            Return _mMIDDLE_NAME
        End Get
        Set(value As String)
            _mMIDDLE_NAME = value
        End Set
    End Property

    Public Property _pNATURE() As String
        Get
            Return _mNATURE
        End Get
        Set(value As String)
            _mNATURE = value
        End Set
    End Property

    Public Property _pNO_EMP() As String
        Get
            Return _mNO_EMP
        End Get
        Set(value As String)
            _mNO_EMP = value
        End Set
    End Property

    Public Property _pOCCUPANCYDATE() As String
        Get
            Return _mOCCUPANCYDATE
        End Get
        Set(value As String)
            _mOCCUPANCYDATE = value
        End Set
    End Property

    Public Property _pOCCUPANCYNO() As String
        Get
            Return _mOCCUPANCYNO
        End Get
        Set(value As String)
            _mOCCUPANCYNO = value
        End Set
    End Property

    Public Property _pOWNCODE() As String
        Get
            Return _mOWNCODE
        End Get
        Set(value As String)
            _mOWNCODE = value
        End Set
    End Property

    Public Property _pOWNERADDR() As String
        Get
            Return _mOWNERADDR
        End Get
        Set(value As String)
            _mOWNERADDR = value
        End Set
    End Property

    Public Property _pOWNERTEL() As String
        Get
            Return _mOWNERTEL
        End Get
        Set(value As String)
            _mOWNERTEL = value
        End Set
    End Property

    Public Property _pP_ADMIN() As String
        Get
            Return _mP_ADMIN
        End Get
        Set(value As String)
            _mP_ADMIN = value
        End Set
    End Property

    Public Property _pP_OWNER() As String
        Get
            Return _mP_OWNER
        End Get
        Set(value As String)
            _mP_OWNER = value
        End Set
    End Property

    Public Property _pP_OWNERADDR() As String
        Get
            Return _mP_OWNERADDR
        End Get
        Set(value As String)
            _mP_OWNERADDR = value
        End Set
    End Property

    Public Property _pP_RENT() As String
        Get
            Return _mP_RENT
        End Get
        Set(value As String)
            _mP_RENT = value
        End Set
    End Property

    Public Property _pP_RENTDATE() As String
        Get
            Return _mP_RENTDATE
        End Get
        Set(value As String)
            _mP_RENTDATE = value
        End Set
    End Property

    Public Property _pP_Reviewing() As String
        Get
            Return _mP_Reviewing
        End Get
        Set(value As String)
            _mP_Reviewing = value
        End Set
    End Property

    Public Property _ppair_id() As String
        Get
            Return _mpair_id
        End Get
        Set(value As String)
            _mpair_id = value
        End Set
    End Property

    Public Property _pPBN() As String
        Get
            Return _mPBN
        End Get
        Set(value As String)
            _mPBN = value
        End Set
    End Property

    Public Property _pPEZA_DATE() As String
        Get
            Return _mPEZA_DATE
        End Get
        Set(value As String)
            _mPEZA_DATE = value
        End Set
    End Property

    Public Property _pPEZA_NO() As String
        Get
            Return _mPEZA_NO
        End Get
        Set(value As String)
            _mPEZA_NO = value
        End Set
    End Property

    Public Property _pPLATENO() As String
        Get
            Return _mPLATENO
        End Get
        Set(value As String)
            _mPLATENO = value
        End Set
    End Property

    Public Property _pREMARKS() As String
        Get
            Return _mREMARKS
        End Get
        Set(value As String)
            _mREMARKS = value
        End Set
    End Property

    Public Property _pReviewing() As String
        Get
            Return _mReviewing
        End Get
        Set(value As String)
            _mReviewing = value
        End Set
    End Property

    Public Property _prg() As String
        Get
            Return _mrg
        End Get
        Set(value As String)
            _mrg = value
        End Set
    End Property

    Public Property _pRowId() As String
        Get
            Return _mRowId
        End Get
        Set(value As String)
            _mRowId = value
        End Set
    End Property

    Public Property _pSEC_DATE() As String
        Get
            Return _mSEC_DATE
        End Get
        Set(value As String)
            _mSEC_DATE = value
        End Set
    End Property

    Public Property _pSEC_NO() As String
        Get
            Return _mSEC_NO
        End Get
        Set(value As String)
            _mSEC_NO = value
        End Set
    End Property

    Public Property _pSSS_DATE() As String
        Get
            Return _mSSS_DATE
        End Get
        Set(value As String)
            _mSSS_DATE = value
        End Set
    End Property

    Public Property _pSSS_NO() As String
        Get
            Return _mSSS_NO
        End Get
        Set(value As String)
            _mSSS_NO = value
        End Set
    End Property

    Public Property _pSTALLNO() As String
        Get
            Return _mSTALLNO
        End Get
        Set(value As String)
            _mSTALLNO = value
        End Set
    End Property

    Public Property _pSTATBY() As String
        Get
            Return _mSTATBY
        End Get
        Set(value As String)
            _mSTATBY = value
        End Set
    End Property

    Public Property _pSTATCODE() As String
        Get
            Return _mSTATCODE
        End Get
        Set(value As String)
            _mSTATCODE = value
        End Set
    End Property

    Public Property _pstatcode1() As String
        Get
            Return _mstatcode1
        End Get
        Set(value As String)
            _mstatcode1 = value
        End Set
    End Property

    Public Property _pSTATDATE() As String
        Get
            Return _mSTATDATE
        End Get
        Set(value As String)
            _mSTATDATE = value
        End Set
    End Property

    Public Property _pSTATDROP() As String
        Get
            Return _mSTATDROP
        End Get
        Set(value As String)
            _mSTATDROP = value
        End Set
    End Property

    Public Property _pSTATDROPBY() As String
        Get
            Return _mSTATDROPBY
        End Get
        Set(value As String)
            _mSTATDROPBY = value
        End Set
    End Property

    Public Property _pSTATDROPDATE() As String
        Get
            Return _mSTATDROPDATE
        End Get
        Set(value As String)
            _mSTATDROPDATE = value
        End Set
    End Property

    Public Property _pSTATDROPREM() As String
        Get
            Return _mSTATDROPREM
        End Get
        Set(value As String)
            _mSTATDROPREM = value
        End Set
    End Property

    Public Property _pSTATDROPTIME() As String
        Get
            Return _mSTATDROPTIME
        End Get
        Set(value As String)
            _mSTATDROPTIME = value
        End Set
    End Property

    Public Property _pSTATHOLD() As String
        Get
            Return _mSTATHOLD
        End Get
        Set(value As String)
            _mSTATHOLD = value
        End Set
    End Property

    Public Property _pSTATREMARKS() As String
        Get
            Return _mSTATREMARKS
        End Get
        Set(value As String)
            _mSTATREMARKS = value
        End Set
    End Property

    Public Property _pSTATUS() As String
        Get
            Return _mSTATUS
        End Get
        Set(value As String)
            _mSTATUS = value
        End Set
    End Property

    Public Property _pSTICKERNO() As String
        Get
            Return _mSTICKERNO
        End Get
        Set(value As String)
            _mSTICKERNO = value
        End Set
    End Property

    Public Property _pSTRTCODE() As String
        Get
            Return _mSTRTCODE
        End Get
        Set(value As String)
            _mSTRTCODE = value
        End Set
    End Property

    Public Property _psys_name() As String
        Get
            Return _msys_name
        End Get
        Set(value As String)
            _msys_name = value
        End Set
    End Property

    Public Property _psys_user() As String
        Get
            Return _msys_user
        End Get
        Set(value As String)
            _msys_user = value
        End Set
    End Property

    Public Property _pTIN_DATE() As String
        Get
            Return _mTIN_DATE
        End Get
        Set(value As String)
            _mTIN_DATE = value
        End Set
    End Property

    Public Property _pTIN_NO() As String
        Get
            Return _mTIN_NO
        End Get
        Set(value As String)
            _mTIN_NO = value
        End Set
    End Property

    Public Property _pUPLOADED() As String
        Get
            Return _mUPLOADED
        End Get
        Set(value As String)
            _mUPLOADED = value
        End Set
    End Property

    Public Property _pVolume_Allow() As String
        Get
            Return _mVolume_Allow
        End Get
        Set(value As String)
            _mVolume_Allow = value
        End Set
    End Property

    Public Property _pXSITE() As String
        Get
            Return _mXSITE
        End Get
        Set(value As String)
            _mXSITE = value
        End Set
    End Property


#End Region

#Region "Routine Data"

    Public Sub _pSubInsert(ByRef _nSuccessful As Boolean, Optional _nCondition As String = "", Optional ByRef _nErrMsg As String = Nothing)
        Try
            _nSuccessful = True

            Dim _nQuery As String = Nothing

            _nQuery = _
               "INSERT INTO " & _
             "[BUSMAST] " & _
             "(" & _
                IIf(String.IsNullOrWhiteSpace(_mACCTNO), "", " [ACCTNO]") & _
                IIf(String.IsNullOrWhiteSpace(_mAPP_DATE), "", ", [APP_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mDATE_ESTA), "", ", [DATE_ESTA]") & _
                IIf(String.IsNullOrWhiteSpace(_mLAST_NAME), "", ", [LAST_NAME]") & _
                IIf(String.IsNullOrWhiteSpace(_mFIRST_NAME), "", ", [FIRST_NAME]") & _
                IIf(String.IsNullOrWhiteSpace(_mMIDDLE_NAME), "", ", [MIDDLE_NAME]") & _
                IIf(String.IsNullOrWhiteSpace(_mCTZNCODE), "", ", [CTZNCODE]") & _
                IIf(String.IsNullOrWhiteSpace(_mOWNERADDR), "", ", [OWNERADDR]") & _
                IIf(String.IsNullOrWhiteSpace(_mOWNERTEL), "", ", [OWNERTEL]") & _
                IIf(String.IsNullOrWhiteSpace(_mPLATENO), "", ", [PLATENO]") & _
                IIf(String.IsNullOrWhiteSpace(_mOWNCODE), "", ", [OWNCODE]") & _
                IIf(String.IsNullOrWhiteSpace(_mBRANCH), "", ", [BRANCH]") & _
                IIf(String.IsNullOrWhiteSpace(_mSTATCODE), "", ", [STATCODE]") & _
                IIf(String.IsNullOrWhiteSpace(_mCOMMNAME), "", ", [COMMNAME]") & _
                IIf(String.IsNullOrWhiteSpace(_mCOMMADDR), "", ", [COMMADDR]") & _
                IIf(String.IsNullOrWhiteSpace(_mSTALLNO), "", ", [STALLNO]") & _
                IIf(String.IsNullOrWhiteSpace(_mCONTACT), "", ", [CONTACT]") & _
                IIf(String.IsNullOrWhiteSpace(_mCONTTEL), "", ", [CONTTEL]") & _
                IIf(String.IsNullOrWhiteSpace(_mCPNO), "", ", [CPNo]") & _
                IIf(String.IsNullOrWhiteSpace(_mCPNO2), "", ", [CPNo2]") & _
                IIf(String.IsNullOrWhiteSpace(_mCPNO3), "", ", [CPNo3]") & _
                IIf(String.IsNullOrWhiteSpace(_mDISTCODE), "", ", [DISTCODE]") & _
                IIf(String.IsNullOrWhiteSpace(_mBRGYCODE), "", ", [BRGYCODE]") & _
                IIf(String.IsNullOrWhiteSpace(_mSTRTCODE), "", ", [STRTCODE]") & _
                IIf(String.IsNullOrWhiteSpace(_mSTICKERNO), "", ", [STICKERNO]") & _
                IIf(String.IsNullOrWhiteSpace(_mGRPBLDG), "", ", [GRPBLDG]") & _
                IIf(String.IsNullOrWhiteSpace(_mTIN_NO), "", ", [TIN_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mTIN_DATE), "", ", [TIN_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mDTI_NO), "", ", [DTI_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mDTI_DATE), "", ", [DTI_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mSEC_NO), "", ", [SEC_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mSEC_DATE), "", ", [SEC_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mSSS_NO), "", ", [SSS_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mSSS_DATE), "", ", [SSS_DATE]") &
                IIf(String.IsNullOrWhiteSpace(_mBC_NO), "", ", [BC_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mBC_DATE), "", ", [BC_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mPEZA_NO), "", ", [PEZA_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mPEZA_DATE), "", ", [PEZA_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mREMARKS), "", ", [REMARKS]") & _
                IIf(String.IsNullOrWhiteSpace(_mINCORPORATORS), "", ", [INCORPORATORS]") & _
                IIf(String.IsNullOrWhiteSpace(_mACR_NO), "", ", [ACR_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mACR_DATE), "", ", [ACR_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mBLDGPERMITNO), "", ", [BLDGPERMITNO]") & _
                IIf(String.IsNullOrWhiteSpace(_mBLDGPERMITDATE), "", ", [BLDGPERMITDATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mOCCUPANCYNO), "", ", [OCCUPANCYNO]") &
                IIf(String.IsNullOrWhiteSpace(_mOCCUPANCYDATE), "", ", [OCCUPANCYDATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mBOI_NO), "", ", [BOI_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mBOI_DATE), "", ", [BOI_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mCDA_NO), "", ", [CDA_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mCDA_DATE), "", ", [CDA_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mCTC_NO), "", ", [CTC_NO]") & _
                IIf(String.IsNullOrWhiteSpace(_mCTC_DATE), "", ", [CTC_DATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mCTC_PLACE), "", ", [CTC_PLACE]") &
                IIf(String.IsNullOrWhiteSpace(_mCTC_AMT), "", ", [CTC_AMT]") & _
                IIf(String.IsNullOrWhiteSpace(_misTourism), "", ", [IsTourism]") & _
                IIf(String.IsNullOrWhiteSpace(_mIsMarket), "", ", [IsMarket]") & _
                IIf(String.IsNullOrWhiteSpace(_mIsCompromise), "", ", [IsCompromise]") & _
                IIf(String.IsNullOrWhiteSpace(_mGOCC), "", ", [GOCC]") & _
                IIf(String.IsNullOrWhiteSpace(_mPBN), "", ", [PBN]") & _
                IIf(String.IsNullOrWhiteSpace(_mEMAILADDR), "", ", [EMAILADDR]") & _
                IIf(String.IsNullOrWhiteSpace(_mEMAILADDR2), "", ", [EMAILADDR2]") & _
                IIf(String.IsNullOrWhiteSpace(_mP_OWNER), "", ", [P_OWNER]") & _
                IIf(String.IsNullOrWhiteSpace(_mP_OWNERADDR), "", ", [P_OWNERADDR]") & _
                IIf(String.IsNullOrWhiteSpace(_mP_RENTDATE), "", ", [P_RENTDATE]") & _
                IIf(String.IsNullOrWhiteSpace(_mP_ADMIN), "", ", [P_ADMIN]") & _
                IIf(String.IsNullOrWhiteSpace(_mP_RENT), "", ", [P_RENT]") & _
             ") " & _
             "VALUES " & _
             "(" & _
                IIf(String.IsNullOrWhiteSpace(_mACCTNO), "", " @_mACCTNO") & _
                IIf(String.IsNullOrWhiteSpace(_mAPP_DATE), "", ", @_mAPP_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mDATE_ESTA), "", ", @_mDATE_ESTA") & _
                IIf(String.IsNullOrWhiteSpace(_mLAST_NAME), "", ", @_mLAST_NAME") & _
                IIf(String.IsNullOrWhiteSpace(_mFIRST_NAME), "", ", @_mFIRST_NAME") & _
                IIf(String.IsNullOrWhiteSpace(_mMIDDLE_NAME), "", ", @_mMIDDLE_NAME") & _
                IIf(String.IsNullOrWhiteSpace(_mCTZNCODE), "", ", @_mCTZNCODE") & _
                IIf(String.IsNullOrWhiteSpace(_mOWNERADDR), "", ", @_mOWNERADDR") & _
                IIf(String.IsNullOrWhiteSpace(_mOWNERTEL), "", ", @_mOWNERTEL") & _
                IIf(String.IsNullOrWhiteSpace(_mPLATENO), "", ", @_mPLATENO") & _
                IIf(String.IsNullOrWhiteSpace(_mOWNCODE), "", ", @_mOWNCODE") & _
                IIf(String.IsNullOrWhiteSpace(_mSTATCODE), "", ", @_mSTATCODE") & _
                IIf(String.IsNullOrWhiteSpace(_mBRANCH), "", ", @_mBRANCH") & _
                IIf(String.IsNullOrWhiteSpace(_mSTATUS), "", ", @_mSTATUS") & _
                IIf(String.IsNullOrWhiteSpace(_mCOMMNAME), "", ", @_mCOMMNAME") & _
                IIf(String.IsNullOrWhiteSpace(_mCOMMADDR), "", ", @_mCOMMADDR") & _
                IIf(String.IsNullOrWhiteSpace(_mSTALLNO), "", ", @_mSTALLNO") & _
                IIf(String.IsNullOrWhiteSpace(_mCONTACT), "", ", @_mCONTACT") & _
                IIf(String.IsNullOrWhiteSpace(_mCONTTEL), "", ", @_mCONTTEL") & _
                IIf(String.IsNullOrWhiteSpace(_mCPNO), "", ", @_mCPNO") & _
                IIf(String.IsNullOrWhiteSpace(_mCPNO2), "", ", @_mCPNO2") & _
                IIf(String.IsNullOrWhiteSpace(_mCPNO3), "", ", @_mCPNO3") & _
                IIf(String.IsNullOrWhiteSpace(_mDISTCODE), "", ", @_mDISTCODE") & _
                IIf(String.IsNullOrWhiteSpace(_mBRGYCODE), "", ", @_mBRGYCODE") & _
                IIf(String.IsNullOrWhiteSpace(_mSTRTCODE), "", ", @_mSTRTCODE") & _
                IIf(String.IsNullOrWhiteSpace(_mSTICKERNO), "", ", @_mSTICKERNO") & _
                IIf(String.IsNullOrWhiteSpace(_mGRPBLDG), "", ", @_mGRPBLDG") & _
                IIf(String.IsNullOrWhiteSpace(_mTIN_NO), "", ", @_mTIN_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mTIN_DATE), "", ", @_mTIN_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mDTI_NO), "", ", @_mDTI_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mDTI_DATE), "", ", @_mDTI_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mSEC_NO), "", ", @_mSEC_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mSEC_DATE), "", ", @_mSEC_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mSSS_NO), "", ", @_mSSS_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mSSS_DATE), "", ", @_mSSS_DATE") &
                IIf(String.IsNullOrWhiteSpace(_mBC_NO), "", ", @_mBC_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mBC_DATE), "", ", @_mBC_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mPEZA_NO), "", ", @_mPEZA_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mPEZA_DATE), "", ", @_mPEZA_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mACR_NO), "", ", @_mACR_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mACR_DATE), "", ", @_mACR_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mBLDGPERMITNO), "", ", @_mBLDGPERMITNO") & _
                IIf(String.IsNullOrWhiteSpace(_mBLDGPERMITDATE), "", ", @_mBLDGPERMITDATE") & _
                IIf(String.IsNullOrWhiteSpace(_mOCCUPANCYNO), "", ", @_mOCCUPANCYNO") &
                IIf(String.IsNullOrWhiteSpace(_mOCCUPANCYDATE), "", ", @_mOCCUPANCYDATE") & _
                IIf(String.IsNullOrWhiteSpace(_mBOI_NO), "", ", @_mBOI_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mBOI_DATE), "", ", @_mBOI_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mCDA_NO), "", ", @_mCDA_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mCDA_DATE), "", ", @_mCDA_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mCTC_NO), "", ", @_mCTC_NO") & _
                IIf(String.IsNullOrWhiteSpace(_mCTC_DATE), "", ", @_mCTC_DATE") & _
                IIf(String.IsNullOrWhiteSpace(_mCTC_PLACE), "", ", @_mCTC_PLACE") &
                IIf(String.IsNullOrWhiteSpace(_mCTC_AMT), "", ", @_mCTC_AMT") & _
                IIf(String.IsNullOrWhiteSpace(_misTourism), "", ", @_misTourism") & _
                IIf(String.IsNullOrWhiteSpace(_mIsMarket), "", ", @_mIsMarket") & _
                IIf(String.IsNullOrWhiteSpace(_mIsCompromise), "", ", @_mIsCompromise") & _
                IIf(String.IsNullOrWhiteSpace(_mGOCC), "", ", @_mGOCC") & _
                IIf(String.IsNullOrWhiteSpace(_mPBN), "", ", @_mPBN") & _
                IIf(String.IsNullOrWhiteSpace(_mEMAILADDR), "", ", @_mEMAILADDR") & _
                IIf(String.IsNullOrWhiteSpace(_mEMAILADDR2), "", ", @_mEMAILADDR2") & _
                IIf(String.IsNullOrWhiteSpace(_mP_RENTDATE), "", ", @_mP_RENTDATE") & _
                IIf(String.IsNullOrWhiteSpace(_mP_ADMIN), "", ", @_mP_ADMIN") & _
                IIf(String.IsNullOrWhiteSpace(_mP_RENT), "", ", @_mP_RENT") & _
") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(")

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mACCTNO) Then .AddWithValue("@_mACCTNO", _mACCTNO)
                If Not String.IsNullOrWhiteSpace(_mAPP_DATE) Then .AddWithValue("@_mAPP_DATE", _mAPP_DATE)
                If Not String.IsNullOrWhiteSpace(_mDATE_ESTA) Then .AddWithValue("@_mDATE_ESTA", _mDATE_ESTA)
                If Not String.IsNullOrWhiteSpace(_mLAST_NAME) Then .AddWithValue("@_mLAST_NAME", _mLAST_NAME)
                If Not String.IsNullOrWhiteSpace(_mFIRST_NAME) Then .AddWithValue("@_mFIRST_NAME", _mFIRST_NAME)
                If Not String.IsNullOrWhiteSpace(_mMIDDLE_NAME) Then .AddWithValue("@_mMIDDLE_NAME", _mMIDDLE_NAME)
                If Not String.IsNullOrWhiteSpace(_mCTZNCODE) Then .AddWithValue("@_mCTZNCODE", _mCTZNCODE)
                If Not String.IsNullOrWhiteSpace(_mOWNERADDR) Then .AddWithValue("@_mOWNERADDR", _mOWNERADDR)
                If Not String.IsNullOrWhiteSpace(_mOWNERTEL) Then .AddWithValue("@_mOWNERTEL", _mOWNERTEL)
                If Not String.IsNullOrWhiteSpace(_mPLATENO) Then .AddWithValue("@_mPLATENO", _mPLATENO)
                If Not String.IsNullOrWhiteSpace(_mOWNCODE) Then .AddWithValue("@_mOWNCODE", _mOWNCODE)
                If Not String.IsNullOrWhiteSpace(_mBRANCH) Then .AddWithValue("@_mBRANCH", _mBRANCH)
                If Not String.IsNullOrWhiteSpace(_mSTATUS) Then .AddWithValue("@_mSTATUS", _mSTATUS)
                If Not String.IsNullOrWhiteSpace(_mCOMMNAME) Then .AddWithValue("@_mCOMMNAME", _mCOMMNAME)
                If Not String.IsNullOrWhiteSpace(_mSTATCODE) Then .AddWithValue("@_mSTATCODE", _mSTATCODE)
                If Not String.IsNullOrWhiteSpace(_mCOMMADDR) Then .AddWithValue("@_mCOMMADDR", _mCOMMADDR)
                If Not String.IsNullOrWhiteSpace(_mSTALLNO) Then .AddWithValue("@_mSTALLNO", _mSTALLNO)
                If Not String.IsNullOrWhiteSpace(_mCONTACT) Then .AddWithValue("@_mCONTACT", _mCONTACT)
                If Not String.IsNullOrWhiteSpace(_mCONTTEL) Then .AddWithValue("@_mCONTTEL", _mCONTTEL)
                If Not String.IsNullOrWhiteSpace(_mCPNO) Then .AddWithValue("@_mCPNO", _mCPNO)
                If Not String.IsNullOrWhiteSpace(_mCPNO2) Then .AddWithValue("@_mCPNO2", _mCPNO2)
                If Not String.IsNullOrWhiteSpace(_mCPNO3) Then .AddWithValue("@_mCPNO3", _mCPNO3)
                If Not String.IsNullOrWhiteSpace(_mDISTCODE) Then .AddWithValue("@_mDISTCODE", _mDISTCODE)
                If Not String.IsNullOrWhiteSpace(_mBRGYCODE) Then .AddWithValue("@_mBRGYCODE", _mBRGYCODE)
                If Not String.IsNullOrWhiteSpace(_mSTRTCODE) Then .AddWithValue("@_mSTRTCODE", _mSTRTCODE)
                If Not String.IsNullOrWhiteSpace(_mSTICKERNO) Then .AddWithValue("@_mSTICKERNO", _mSTICKERNO)
                If Not String.IsNullOrWhiteSpace(_mGRPBLDG) Then .AddWithValue("@_mGRPBLDG", _mGRPBLDG)
                If Not String.IsNullOrWhiteSpace(_mTIN_NO) Then .AddWithValue("@_mTIN_NO", _mTIN_NO)
                If Not String.IsNullOrWhiteSpace(_mTIN_DATE) Then .AddWithValue("@_mTIN_DATE", _mTIN_DATE)
                If Not String.IsNullOrWhiteSpace(_mDTI_NO) Then .AddWithValue("@_mDTI_NO", _mDTI_NO)
                If Not String.IsNullOrWhiteSpace(_mDTI_DATE) Then .AddWithValue("@_mDTI_DATE", _mDTI_DATE)
                If Not String.IsNullOrWhiteSpace(_mSEC_NO) Then .AddWithValue("@_mSEC_NO", _mSEC_NO)
                If Not String.IsNullOrWhiteSpace(_mSEC_DATE) Then .AddWithValue("@_mSEC_DATE", _mSEC_DATE)
                If Not String.IsNullOrWhiteSpace(_mSSS_NO) Then .AddWithValue("@_mSSS_NO", _mSSS_NO)
                If Not String.IsNullOrWhiteSpace(_mSSS_DATE) Then .AddWithValue("@_mSSS_DATE", _mSSS_DATE)
                If Not String.IsNullOrWhiteSpace(_mBC_NO) Then .AddWithValue("@_mBC_NO", _mBC_NO)
                If Not String.IsNullOrWhiteSpace(_mBC_DATE) Then .AddWithValue("@_mBC_DATE", _mBC_DATE)
                If Not String.IsNullOrWhiteSpace(_mPEZA_NO) Then .AddWithValue("@_mPEZA_NO", _mPEZA_NO)
                If Not String.IsNullOrWhiteSpace(_mPEZA_DATE) Then .AddWithValue("@_mPEZA_DATE", _mPEZA_DATE)
                If Not String.IsNullOrWhiteSpace(_mINCORPORATORS) Then .AddWithValue("@_mINCORPORATORS", _mINCORPORATORS)
                If Not String.IsNullOrWhiteSpace(_mACR_NO) Then .AddWithValue("@_mACR_NO", _mACR_NO)
                If Not String.IsNullOrWhiteSpace(_mACR_DATE) Then .AddWithValue("@_mACR_DATE", _mACR_DATE)
                If Not String.IsNullOrWhiteSpace(_mBLDGPERMITNO) Then .AddWithValue("@_mBLDGPERMITNO", _mBLDGPERMITNO)
                If Not String.IsNullOrWhiteSpace(_mBLDGPERMITDATE) Then .AddWithValue("@_mBLDGPERMITDATE", _mBLDGPERMITDATE)
                If Not String.IsNullOrWhiteSpace(_mOCCUPANCYNO) Then .AddWithValue("@_mOCCUPANCYNO", _mOCCUPANCYNO)
                If Not String.IsNullOrWhiteSpace(_mOCCUPANCYDATE) Then .AddWithValue("@_mOCCUPANCYDATE", _mOCCUPANCYDATE)
                If Not String.IsNullOrWhiteSpace(_mBOI_NO) Then .AddWithValue("@_mBOI_NO", _mBOI_NO)
                If Not String.IsNullOrWhiteSpace(_mBOI_DATE) Then .AddWithValue("@_mBOI_DATE", _mBOI_DATE)
                If Not String.IsNullOrWhiteSpace(_mCDA_NO) Then .AddWithValue("@_mCDA_NO", _mCDA_NO)
                If Not String.IsNullOrWhiteSpace(_mCDA_DATE) Then .AddWithValue("@_mCDA_DATE", _mCDA_DATE)
                If Not String.IsNullOrWhiteSpace(_mCTC_NO) Then .AddWithValue("@_mCTC_NO", _mCTC_NO)
                If Not String.IsNullOrWhiteSpace(_mCTC_DATE) Then .AddWithValue("@_mCTC_DATE", _mCTC_DATE)
                If Not String.IsNullOrWhiteSpace(_mCTC_PLACE) Then .AddWithValue("@_mCTC_PLACE", _mCTC_PLACE)
                If Not String.IsNullOrWhiteSpace(_mCTC_AMT) Then .AddWithValue("@_mCTC_AMT", _mCTC_AMT)
                If Not String.IsNullOrWhiteSpace(_misTourism) Then .AddWithValue("@_misTourism", _misTourism)
                If Not String.IsNullOrWhiteSpace(_mIsMarket) Then .AddWithValue("@_mIsMarket", _mIsMarket)
                If Not String.IsNullOrWhiteSpace(_mIsCompromise) Then .AddWithValue("@_mIsCompromise", _mIsCompromise)
                If Not String.IsNullOrWhiteSpace(_mGOCC) Then .AddWithValue("@_mGOCC", _mGOCC)
                If Not String.IsNullOrWhiteSpace(_mPBN) Then .AddWithValue("@_mPBN", _mPBN)
                If Not String.IsNullOrWhiteSpace(_mEMAILADDR) Then .AddWithValue("@_mEMAILADDR", _mEMAILADDR)
                If Not String.IsNullOrWhiteSpace(_mEMAILADDR2) Then .AddWithValue("@_mEMAILADDR2", _mEMAILADDR2)
                If Not String.IsNullOrWhiteSpace(_mP_RENT) Then .AddWithValue("@_mP_RENT", _mP_RENT)
                If Not String.IsNullOrWhiteSpace(_mP_RENTDATE) Then .AddWithValue("@_mP_RENTDATE", _mP_RENTDATE)
                If Not String.IsNullOrWhiteSpace(_mP_ADMIN) Then .AddWithValue("@_mP_ADMIN", _mP_ADMIN)
            End With

            _mSqlCommand.ExecuteNonQuery()


        Catch ex As Exception
            _nSuccessful = False
            _nErrMsg = ex.Message

        End Try
    End Sub

#End Region


End Class
