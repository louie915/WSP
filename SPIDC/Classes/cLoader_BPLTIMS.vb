Imports System.Web.HttpContext

Public Class cLoader_BPLTIMS

#Region "BUSMAST"

#Region "Variable Field"

    Private Const _sscPrefix As String = "cLoader_BPLTIMS."

    Private Const _ssc_Add As String = _sscPrefix & "_ssc_Add"
    Private Const _ssc_ACCTNO As String = _sscPrefix & "_ssc_ACCTNO"

    Private Const _ssc_Acquired_By As String = _sscPrefix & "_ssc_Acquired_By"
    Private Const _ssc_ACR_DATE As String = _sscPrefix & "_ssc_ACR_DATE"
    Private Const _ssc_ACR_NO As String = _sscPrefix & "_ssc_ACR_NO"
    Private Const _ssc_Additional_Vol As String = _sscPrefix & "_ssc_Additional_Vol"
    Private Const _ssc_APP_DATE As String = _sscPrefix & "_ssc_APP_DATE"
    Private Const _ssc_AppModule As String = _sscPrefix & "_ssc_AppModule"
    Private Const _ssc_APPROVEDBY As String = _sscPrefix & "_ssc_APPROVEDBY"
    Private Const _ssc_AppUser As String = _sscPrefix & "_ssc_AppUser"
    Private Const _ssc_AppUser1 As String = _sscPrefix & "_ssc_AppUser1"
    Private Const _ssc_AppUserName As String = _sscPrefix & "_ssc_AppUserName"
    Private Const _ssc_AppUserName1 As String = _sscPrefix & "_ssc_AppUserName1"
    Private Const _ssc_BC_DATE As String = _sscPrefix & "_ssc_BC_DATE"
    Private Const _ssc_BC_NO As String = _sscPrefix & "_ssc_BC_NO"
    Private Const _ssc_BLDGPERMITDATE As String = _sscPrefix & "_ssc_BLDGPERMITDATE"
    Private Const _ssc_BLDGPERMITNO As String = _sscPrefix & "_ssc_BLDGPERMITNO"
    Private Const _ssc_BOI_DATE As String = _sscPrefix & "_ssc_BOI_DATE"
    Private Const _ssc_BOI_NO As String = _sscPrefix & "_ssc_BOI_NO"
    Private Const _ssc_BRANCH As String = _sscPrefix & "_ssc_BRANCH"
    Private Const _ssc_BRGYCODE As String = _sscPrefix & "_ssc_BRGYCODE"
    Private Const _ssc_CDA_DATE As String = _sscPrefix & "_ssc_CDA_DATE"
    Private Const _ssc_CDA_NO As String = _sscPrefix & "_ssc_CDA_NO"
    Private Const _ssc_COMMADDR As String = _sscPrefix & "_ssc_COMMADDR"
    Private Const _ssc_COMMNAME As String = _sscPrefix & "_ssc_COMMNAME"
    Private Const _ssc_CONTACT As String = _sscPrefix & "_ssc_CONTACT"
    Private Const _ssc_CONTTEL As String = _sscPrefix & "_ssc_CONTTEL"
    Private Const _ssc_CPNO As String = _sscPrefix & "_ssc_CPNO"
    Private Const _ssc_CPNO2 As String = _sscPrefix & "_ssc_CPNO2"
    Private Const _ssc_CPNO3 As String = _sscPrefix & "_ssc_CPNO3"
    Private Const _ssc_CPNoGTM As String = _sscPrefix & "_ssc_CPNoGTM"
    Private Const _ssc_CPNoSMTNT As String = _sscPrefix & "_ssc_CPNoSMTNT"
    Private Const _ssc_CPNoSun As String = _sscPrefix & "_ssc_CPNoSun"
    Private Const _ssc_CTC_AMT As String = _sscPrefix & "_ssc_CTC_AMT"
    Private Const _ssc_CTC_DATE As String = _sscPrefix & "_ssc_CTC_DATE"
    Private Const _ssc_CTC_NO As String = _sscPrefix & "_ssc_CTC_NO"
    Private Const _ssc_CTC_PLACE As String = _sscPrefix & "_ssc_CTC_PLACE"
    Private Const _ssc_CTZNCODE As String = _sscPrefix & "_ssc_CTZNCODE"
    Private Const _ssc_Date_Acquired As String = _sscPrefix & "_ssc_Date_Acquired"
    Private Const _ssc_Date_Approved As String = _sscPrefix & "_ssc_Date_Approved"
    Private Const _ssc_DATE_ESTA As String = _sscPrefix & "_ssc_DATE_ESTA"
    Private Const _ssc_Date_Reviewed As String = _sscPrefix & "_ssc_Date_Reviewed"
    Private Const _ssc_DISTCODE As String = _sscPrefix & "_ssc_DISTCODE"
    Private Const _ssc_DOWNLOADED As String = _sscPrefix & "_ssc_DOWNLOADED"
    Private Const _ssc_DTI_DATE As String = _sscPrefix & "_ssc_DTI_DATE"
    Private Const _ssc_DTI_NO As String = _sscPrefix & "_ssc_DTI_NO"
    Private Const _ssc_EDITTEDBY As String = _sscPrefix & "_ssc_EDITTEDBY"
    Private Const _ssc_EDITTEDBYDATE As String = _sscPrefix & "_ssc_EDITTEDBYDATE"
    Private Const _ssc_EMAILADDR As String = _sscPrefix & "_ssc_EMAILADDR"
    Private Const _ssc_EMAILADDR2 As String = _sscPrefix & "_ssc_EMAILADDR2"
    Private Const _ssc_event_date As String = _sscPrefix & "_ssc_event_date"
    Private Const _ssc_event_id As String = _sscPrefix & "_ssc_event_id"
    Private Const _ssc_EXAMINEDBY As String = _sscPrefix & "_ssc_EXAMINEDBY"
    Private Const _ssc_EXAMINEDBYDATE As String = _sscPrefix & "_ssc_EXAMINEDBYDATE"
    Private Const _ssc_FACODE As String = _sscPrefix & "_ssc_FACODE"
    Private Const _ssc_FIRST_NAME As String = _sscPrefix & "_ssc_FIRST_NAME"
    Private Const _ssc_For_Billing As String = _sscPrefix & "_ssc_For_Billing"
    Private Const _ssc_For_Payment As String = _sscPrefix & "_ssc_For_Payment"
    Private Const _ssc_For_Permit As String = _sscPrefix & "_ssc_For_Permit"
    Private Const _ssc_GOCC As String = _sscPrefix & "_ssc_GOCC"
    Private Const _ssc_GRPBLDG As String = _sscPrefix & "_ssc_GRPBLDG"
    Private Const _ssc_host_name As String = _sscPrefix & "_ssc_host_name"
    Private Const _ssc_IFTRANSF As String = _sscPrefix & "_ssc_IFTRANSF"
    Private Const _ssc_INCORPORATORS As String = _sscPrefix & "_ssc_INCORPORATORS"
    Private Const _ssc_IP As String = _sscPrefix & "_ssc_IP"
    Private Const _ssc_IS_TERMINAL As String = _sscPrefix & "_ssc_IS_TERMINAL"
    Private Const _ssc_isADDRESS As String = _sscPrefix & "_ssc_isADDRESS"
    Private Const _ssc_IsCHANGECOMM As String = _sscPrefix & "_ssc_IsCHANGECOMM"
    Private Const _ssc_IsComprimise As String = _sscPrefix & "_ssc_IsComprimise"
    Private Const _ssc_IsCompromise As String = _sscPrefix & "_ssc_IsCompromise"
    Private Const _ssc_IsMarket As String = _sscPrefix & "_ssc_IsMarket"
    Private Const _ssc_isPosted As String = _sscPrefix & "_ssc_isPosted"
    Private Const _ssc_isPrcs As String = _sscPrefix & "_ssc_isPrcs"
    Private Const _ssc_IsSpecial As String = _sscPrefix & "_ssc_IsSpecial"
    Private Const _ssc_IsTCampaign As String = _sscPrefix & "_ssc_IsTCampaign"
    Private Const _ssc_isTourism As String = _sscPrefix & "_ssc_isTourism"
    Private Const _ssc_LAST_NAME As String = _sscPrefix & "_ssc_LAST_NAME"
    Private Const _ssc_MAIN As String = _sscPrefix & "_ssc_MAIN"
    Private Const _ssc_MIDDLE_NAME As String = _sscPrefix & "_ssc_MIDDLE_NAME"
    Private Const _ssc_NATURE As String = _sscPrefix & "_ssc_NATURE"
    Private Const _ssc_NO_EMP As String = _sscPrefix & "_ssc_NO_EMP"
    Private Const _ssc_OCCUPANCYDATE As String = _sscPrefix & "_ssc_OCCUPANCYDATE"
    Private Const _ssc_OCCUPANCYNO As String = _sscPrefix & "_ssc_OCCUPANCYNO"
    Private Const _ssc_OWNCODE As String = _sscPrefix & "_ssc_OWNCODE"
    Private Const _ssc_OWNERADDR As String = _sscPrefix & "_ssc_OWNERADDR"
    Private Const _ssc_OWNERTEL As String = _sscPrefix & "_ssc_OWNERTEL"
    Private Const _ssc_P_ADMIN As String = _sscPrefix & "_ssc_P_ADMIN"
    Private Const _ssc_P_OWNER As String = _sscPrefix & "_ssc_P_OWNER"
    Private Const _ssc_P_OWNERADDR As String = _sscPrefix & "_ssc_P_OWNERADDR"
    Private Const _ssc_P_RENT As String = _sscPrefix & "_ssc_P_RENT"
    Private Const _ssc_P_RENTDATE As String = _sscPrefix & "_ssc_P_RENTDATE"
    Private Const _ssc_P_Reviewing As String = _sscPrefix & "_ssc_P_Reviewing"
    Private Const _ssc_pair_id As String = _sscPrefix & "_ssc_pair_id"
    Private Const _ssc_PBN As String = _sscPrefix & "_ssc_PBN"
    Private Const _ssc_PEZA_DATE As String = _sscPrefix & "_ssc_PEZA_DATE"
    Private Const _ssc_PEZA_NO As String = _sscPrefix & "_ssc_PEZA_NO"
    Private Const _ssc_PLATENO As String = _sscPrefix & "_ssc_PLATENO"
    Private Const _ssc_REMARKS As String = _sscPrefix & "_ssc_REMARKS"
    Private Const _ssc_Reviewing As String = _sscPrefix & "_ssc_Reviewing"
    Private Const _ssc_rg As String = _sscPrefix & "_ssc_rg"
    Private Const _ssc_RowId As String = _sscPrefix & "_ssc_RowId"
    Private Const _ssc_SEC_DATE As String = _sscPrefix & "_ssc_SEC_DATE"
    Private Const _ssc_SEC_NO As String = _sscPrefix & "_ssc_SEC_NO"
    Private Const _ssc_SSS_DATE As String = _sscPrefix & "_ssc_SSS_DATE"
    Private Const _ssc_SSS_NO As String = _sscPrefix & "_ssc_SSS_NO"
    Private Const _ssc_STALLNO As String = _sscPrefix & "_ssc_STALLNO"
    Private Const _ssc_STATBY As String = _sscPrefix & "_ssc_STATBY"
    Private Const _ssc_STATCODE As String = _sscPrefix & "_ssc_STATCODE"
    Private Const _ssc_statcode1 As String = _sscPrefix & "_ssc_statcode1"
    Private Const _ssc_STATDATE As String = _sscPrefix & "_ssc_STATDATE"
    Private Const _ssc_STATDROP As String = _sscPrefix & "_ssc_STATDROP"
    Private Const _ssc_STATDROPBY As String = _sscPrefix & "_ssc_STATDROPBY"
    Private Const _ssc_STATDROPDATE As String = _sscPrefix & "_ssc_STATDROPDATE"
    Private Const _ssc_STATDROPREM As String = _sscPrefix & "_ssc_STATDROPREM"
    Private Const _ssc_STATDROPTIME As String = _sscPrefix & "_ssc_STATDROPTIME"
    Private Const _ssc_STATHOLD As String = _sscPrefix & "_ssc_STATHOLD"
    Private Const _ssc_STATREMARKS As String = _sscPrefix & "_ssc_STATREMARKS"
    Private Const _ssc_STATUS As String = _sscPrefix & "_ssc_STATUS"
    Private Const _ssc_STICKERNO As String = _sscPrefix & "_ssc_STICKERNO"
    Private Const _ssc_STRTCODE As String = _sscPrefix & "_ssc_STRTCODE"
    Private Const _ssc_sys_name As String = _sscPrefix & "_ssc_sys_name"
    Private Const _ssc_sys_user As String = _sscPrefix & "_ssc_sys_user"
    Private Const _ssc_TIN_DATE As String = _sscPrefix & "_ssc_TIN_DATE"
    Private Const _ssc_TIN_NO As String = _sscPrefix & "_ssc_TIN_NO"
    Private Const _ssc_UPLOADED As String = _sscPrefix & "_ssc_UPLOADED"
    Private Const _ssc_Volume_Allow As String = _sscPrefix & "_ssc_Volume_Allow"
    Private Const _ssc_XSITE As String = _sscPrefix & "_ssc_XSITE"

    Private Const _ssc_BusinessDescription As String = _sscPrefix & "_ssc_BusinessDescription"
    Private Const _ssc_IsProcessAll As String = _sscPrefix & "_ssc_IsProcessAll"
#End Region

#Region "Property Field"




    Shared Property _pACCTNO() As String
        Get
            Return Current.Session(_ssc_ACCTNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_ACCTNO) = value
        End Set
    End Property
    'Shared Property _pACCTNO() As String
    '    Get
    '         Return Current.Session(_ssc_ACCTNO
    '    End Get
    '    Set(ByVal value As String)
    '        _mACCTNO = value
    '    End Set
    'End Property

    Shared Property _pAcquired_By() As String
        Get
            Return Current.Session(_ssc_Acquired_By)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Acquired_By) = value
        End Set
    End Property

    Shared Property _pACR_DATE() As String
        Get
            Return Current.Session(_ssc_ACR_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_ACR_DATE) = value
        End Set
    End Property

    Shared Property _pACR_NO() As String
        Get
            Return Current.Session(_ssc_ACR_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_ACR_NO) = value
        End Set
    End Property

    Shared Property _pAdditional_Vol() As String
        Get
            Return Current.Session(_ssc_Additional_Vol)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Additional_Vol) = value
        End Set
    End Property

    Shared Property _pAPP_DATE() As String
        Get
            Return Current.Session(_ssc_APP_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_APP_DATE) = value
        End Set
    End Property

    Shared Property _pAppModule() As String
        Get
            Return Current.Session(_ssc_AppModule)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_AppModule) = value
        End Set
    End Property

    Shared Property _pAPPROVEDBY() As String
        Get
            Return Current.Session(_ssc_APPROVEDBY)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_APPROVEDBY) = value
        End Set
    End Property

    Shared Property _pAppUser() As String
        Get
            Return Current.Session(_ssc_AppUser)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_AppUser) = value
        End Set
    End Property

    Shared Property _pAppUser1() As String
        Get
            Return Current.Session(_ssc_AppUser1)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_AppUser1) = value
        End Set
    End Property

    Shared Property _pAppUserName() As String
        Get
            Return Current.Session(_ssc_AppUserName)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_AppUserName) = value
        End Set
    End Property

    Shared Property _pAppUserName1() As String
        Get
            Return Current.Session(_ssc_AppUserName1)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_AppUserName1) = value
        End Set
    End Property

    Shared Property _pBC_DATE() As String
        Get
            Return Current.Session(_ssc_BC_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BC_DATE) = value
        End Set
    End Property

    Shared Property _pBC_NO() As String
        Get
            Return Current.Session(_ssc_BC_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BC_NO) = value
        End Set
    End Property

    Shared Property _pBLDGPERMITDATE() As String
        Get
            Return Current.Session(_ssc_BLDGPERMITDATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BLDGPERMITDATE) = value
        End Set
    End Property

    Shared Property _pBLDGPERMITNO() As String
        Get
            Return Current.Session(_ssc_BLDGPERMITNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BLDGPERMITNO) = value
        End Set
    End Property

    Shared Property _pBOI_DATE() As String
        Get
            Return Current.Session(_ssc_BOI_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BOI_DATE) = value
        End Set
    End Property

    Shared Property _pBOI_NO() As String
        Get
            Return Current.Session(_ssc_BOI_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BOI_NO) = value
        End Set
    End Property

    Shared Property _pBRANCH() As String
        Get
            Return Current.Session(_ssc_BRANCH)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BRANCH) = value
        End Set
    End Property

    Shared Property _pBRGYCODE() As String
        Get
            Return Current.Session(_ssc_BRGYCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BRGYCODE) = value
        End Set
    End Property

    Shared Property _pCDA_DATE() As String
        Get
            Return Current.Session(_ssc_CDA_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CDA_DATE) = value
        End Set
    End Property

    Shared Property _pCDA_NO() As String
        Get
            Return Current.Session(_ssc_CDA_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CDA_NO) = value
        End Set
    End Property

    Shared Property _pCOMMADDR() As String
        Get
            Return Current.Session(_ssc_COMMADDR)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_COMMADDR) = value
        End Set
    End Property

    Shared Property _pCOMMNAME() As String
        Get
            Return Current.Session(_ssc_COMMNAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_COMMNAME) = value
        End Set
    End Property

    Shared Property _pCONTACT() As String
        Get
            Return Current.Session(_ssc_CONTACT)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CONTACT) = value
        End Set
    End Property

    Shared Property _pCONTTEL() As String
        Get
            Return Current.Session(_ssc_CONTTEL)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CONTTEL) = value
        End Set
    End Property

    Shared Property _pCPNO() As String
        Get
            Return Current.Session(_ssc_CPNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CPNO) = value
        End Set
    End Property

    Shared Property _pCPNO2() As String
        Get
            Return Current.Session(_ssc_CPNO2)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CPNO2) = value
        End Set
    End Property

    Shared Property _pCPNO3() As String
        Get
            Return Current.Session(_ssc_CPNO3)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CPNO3) = value
        End Set
    End Property

    Shared Property _pCPNoGTM() As String
        Get
            Return Current.Session(_ssc_CPNoGTM)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CPNoGTM) = value
        End Set
    End Property

    Shared Property _pCPNoSMTNT() As String
        Get
            Return Current.Session(_ssc_CPNoSMTNT)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CPNoSMTNT) = value
        End Set
    End Property

    Shared Property _pCPNoSun() As String
        Get
            Return Current.Session(_ssc_CPNoSun)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CPNoSun) = value
        End Set
    End Property

    Shared Property _pCTC_AMT() As String
        Get
            Return Current.Session(_ssc_CTC_AMT)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CTC_AMT) = value
        End Set
    End Property

    Shared Property _pCTC_DATE() As String
        Get
            Return Current.Session(_ssc_CTC_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CTC_DATE) = value
        End Set
    End Property

    Shared Property _pCTC_NO() As String
        Get
            Return Current.Session(_ssc_CTC_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CTC_NO) = value
        End Set
    End Property

    Shared Property _pCTC_PLACE() As String
        Get
            Return Current.Session(_ssc_CTC_PLACE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CTC_PLACE) = value
        End Set
    End Property

    Shared Property _pCTZNCODE() As String
        Get
            Return Current.Session(_ssc_CTZNCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CTZNCODE) = value
        End Set
    End Property

    Shared Property _pDate_Acquired() As String
        Get
            Return Current.Session(_ssc_Date_Acquired)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Date_Acquired) = value
        End Set
    End Property

    Shared Property _pDate_Approved() As String
        Get
            Return Current.Session(_ssc_Date_Approved)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Date_Approved) = value
        End Set
    End Property

    Shared Property _pDATE_ESTA() As String
        Get
            Return Current.Session(_ssc_DATE_ESTA)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_DATE_ESTA) = value
        End Set
    End Property

    Shared Property _pDate_Reviewed() As String
        Get
            Return Current.Session(_ssc_Date_Reviewed)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Date_Reviewed) = value
        End Set
    End Property

    Shared Property _pDISTCODE() As String
        Get
            Return Current.Session(_ssc_DISTCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_DISTCODE) = value
        End Set
    End Property

    Shared Property _pDOWNLOADED() As String
        Get
            Return Current.Session(_ssc_DOWNLOADED)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_DOWNLOADED) = value
        End Set
    End Property

    Shared Property _pDTI_DATE() As String
        Get
            Return Current.Session(_ssc_DTI_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_DTI_DATE) = value
        End Set
    End Property

    Shared Property _pDTI_NO() As String
        Get
            Return Current.Session(_ssc_DTI_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_DTI_NO) = value
        End Set
    End Property

    Shared Property _pEDITTEDBY() As String
        Get
            Return Current.Session(_ssc_EDITTEDBY)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EDITTEDBY) = value
        End Set
    End Property

    Shared Property _pEDITTEDBYDATE() As String
        Get
            Return Current.Session(_ssc_EDITTEDBYDATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EDITTEDBYDATE) = value
        End Set
    End Property

    Shared Property _pEMAILADDR() As String
        Get
            Return Current.Session(_ssc_EMAILADDR)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EMAILADDR) = value
        End Set
    End Property

    Shared Property _pEMAILADDR2() As String
        Get
            Return Current.Session(_ssc_EMAILADDR2)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EMAILADDR2) = value
        End Set
    End Property

    Shared Property _pevent_date() As String
        Get
            Return Current.Session(_ssc_event_date)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_event_date) = value
        End Set
    End Property

    Shared Property _pevent_id() As String
        Get
            Return Current.Session(_ssc_event_id)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_event_id) = value
        End Set
    End Property

    Shared Property _pEXAMINEDBY() As String
        Get
            Return Current.Session(_ssc_EXAMINEDBY)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EXAMINEDBY) = value
        End Set
    End Property

    Shared Property _pEXAMINEDBYDATE() As String
        Get
            Return Current.Session(_ssc_EXAMINEDBYDATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EXAMINEDBYDATE) = value
        End Set
    End Property

    Shared Property _pFACODE() As String
        Get
            Return Current.Session(_ssc_FACODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_FACODE) = value
        End Set
    End Property

    Shared Property _pFIRST_NAME() As String
        Get
            Return Current.Session(_ssc_FIRST_NAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_FIRST_NAME) = value
        End Set
    End Property

    Shared Property _pFor_Billing() As Boolean
        Get
            Return Current.Session(_ssc_For_Billing)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_For_Billing) = value
        End Set
    End Property

    Shared Property _pFor_Payment() As Boolean
        Get
            Return Current.Session(_ssc_For_Payment)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_For_Payment) = value
        End Set
    End Property

    Shared Property _pFor_Permit() As Boolean
        Get
            Return Current.Session(_ssc_For_Permit)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_For_Permit) = value
        End Set
    End Property

    Shared Property _pGOCC() As Boolean
        Get
            Return Current.Session(_ssc_GOCC)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_GOCC) = value
        End Set
    End Property

    Shared Property _pGRPBLDG() As String
        Get
            Return Current.Session(_ssc_GRPBLDG)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_GRPBLDG) = value
        End Set
    End Property

    Shared Property _phost_name() As String
        Get
            Return Current.Session(_ssc_host_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_host_name) = value
        End Set
    End Property

    Shared Property _pIFTRANSF() As String
        Get
            Return Current.Session(_ssc_IFTRANSF)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IFTRANSF) = value
        End Set
    End Property

    Shared Property _pINCORPORATORS() As String
        Get
            Return Current.Session(_ssc_INCORPORATORS)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_INCORPORATORS) = value
        End Set
    End Property

    Shared Property _pIP() As String
        Get
            Return Current.Session(_ssc_IP)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IP) = value
        End Set
    End Property

    Shared Property _pIS_TERMINAL() As String
        Get
            Return Current.Session(_ssc_IS_TERMINAL)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IS_TERMINAL) = value
        End Set
    End Property

    Shared Property _pisADDRESS() As String
        Get
            Return Current.Session(_ssc_isADDRESS)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_isADDRESS) = value
        End Set
    End Property

    Shared Property _pIsCHANGECOMM() As String
        Get
            Return Current.Session(_ssc_IsCHANGECOMM)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IsCHANGECOMM) = value
        End Set
    End Property

    Shared Property _pIsComprimise() As String
        Get
            Return Current.Session(_ssc_IsComprimise)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IsComprimise) = value
        End Set
    End Property

    Shared Property _pIsCompromise() As String
        Get
            Return Current.Session(_ssc_IsCompromise)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IsCompromise) = value
        End Set
    End Property

    Shared Property _pIsMarket() As String
        Get
            Return Current.Session(_ssc_IsMarket)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IsMarket) = value
        End Set
    End Property

    Shared Property _pisPosted() As Boolean
        Get
            Return Current.Session(_ssc_isPosted)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_isPosted) = value
        End Set
    End Property

    Shared Property _pisPrcs() As Boolean
        Get
            Return Current.Session(_ssc_isPrcs)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_isPrcs) = value
        End Set
    End Property

    Shared Property _pIsSpecial() As String
        Get
            Return Current.Session(_ssc_IsSpecial)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IsSpecial) = value
        End Set
    End Property

    Shared Property _pIsTCampaign() As Boolean
        Get
            Return Current.Session(_ssc_IsTCampaign)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_IsTCampaign) = value
        End Set
    End Property

    Shared Property _pisTourism() As Boolean
        Get
            Return Current.Session(_ssc_isTourism)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_isTourism) = value
        End Set
    End Property

    Shared Property _pLAST_NAME() As String
        Get
            Return Current.Session(_ssc_LAST_NAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_LAST_NAME) = value
        End Set
    End Property

    Shared Property _pMAIN() As String
        Get
            Return Current.Session(_ssc_MAIN)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_MAIN) = value
        End Set
    End Property

    Shared Property _pMIDDLE_NAME() As String
        Get
            Return Current.Session(_ssc_MIDDLE_NAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_MIDDLE_NAME) = value
        End Set
    End Property

    Shared Property _pNATURE() As String
        Get
            Return Current.Session(_ssc_NATURE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_NATURE) = value
        End Set
    End Property

    Shared Property _pNO_EMP() As String
        Get
            Return Current.Session(_ssc_NO_EMP)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_NO_EMP) = value
        End Set
    End Property

    Shared Property _pOCCUPANCYDATE() As String
        Get
            Return Current.Session(_ssc_OCCUPANCYDATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_OCCUPANCYDATE) = value
        End Set
    End Property

    Shared Property _pOCCUPANCYNO() As String
        Get
            Return Current.Session(_ssc_OCCUPANCYNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_OCCUPANCYNO) = value
        End Set
    End Property

    Shared Property _pOWNCODE() As String
        Get
            Return Current.Session(_ssc_OWNCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_OWNCODE) = value
        End Set
    End Property

    Shared Property _pOWNERADDR() As String
        Get
            Return Current.Session(_ssc_OWNERADDR)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_OWNERADDR) = value
        End Set
    End Property

    Shared Property _pOWNERTEL() As String
        Get
            Return Current.Session(_ssc_OWNERTEL)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_OWNERTEL) = value
        End Set
    End Property

    Shared Property _pP_ADMIN() As String
        Get
            Return Current.Session(_ssc_P_ADMIN)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_P_ADMIN) = value
        End Set
    End Property

    Shared Property _pP_OWNER() As String
        Get
            Return Current.Session(_ssc_P_OWNER)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_P_OWNER) = value
        End Set
    End Property

    Shared Property _pP_OWNERADDR() As String
        Get
            Return Current.Session(_ssc_P_OWNERADDR)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_P_OWNERADDR) = value
        End Set
    End Property

    Shared Property _pP_RENT() As String
        Get
            Return Current.Session(_ssc_P_RENT)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_P_RENT) = value
        End Set
    End Property

    Shared Property _pP_RENTDATE() As String
        Get
            Return Current.Session(_ssc_P_RENTDATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_P_RENTDATE) = value
        End Set
    End Property

    Shared Property _pP_Reviewing() As String
        Get
            Return Current.Session(_ssc_P_Reviewing)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_P_Reviewing) = value
        End Set
    End Property

    Shared Property _ppair_id() As String
        Get
            Return Current.Session(_ssc_pair_id)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_pair_id) = value
        End Set
    End Property

    Shared Property _pPBN() As String
        Get
            Return Current.Session(_ssc_PBN)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_PBN) = value
        End Set
    End Property

    Shared Property _pPEZA_DATE() As String
        Get
            Return Current.Session(_ssc_PEZA_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_PEZA_DATE) = value
        End Set
    End Property

    Shared Property _pPEZA_NO() As String
        Get
            Return Current.Session(_ssc_PEZA_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_PEZA_NO) = value
        End Set
    End Property

    Shared Property _pPLATENO() As String
        Get
            Return Current.Session(_ssc_PLATENO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_PLATENO) = value
        End Set
    End Property

    Shared Property _pREMARKS() As String
        Get
            Return Current.Session(_ssc_REMARKS)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_REMARKS) = value
        End Set
    End Property

    Shared Property _pReviewing() As String
        Get
            Return Current.Session(_ssc_Reviewing)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Reviewing) = value
        End Set
    End Property

    Shared Property _prg() As String
        Get
            Return Current.Session(_ssc_rg)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_rg) = value
        End Set
    End Property

    Shared Property _pSEC_DATE() As String
        Get
            Return Current.Session(_ssc_SEC_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_SEC_DATE) = value
        End Set
    End Property

    Shared Property _pSEC_NO() As String
        Get
            Return Current.Session(_ssc_SEC_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_SEC_NO) = value
        End Set
    End Property

    Shared Property _pSSS_DATE() As String
        Get
            Return Current.Session(_ssc_SSS_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_SSS_DATE) = value
        End Set
    End Property

    Shared Property _pSSS_NO() As String
        Get
            Return Current.Session(_ssc_SSS_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_SSS_NO) = value
        End Set
    End Property

    Shared Property _pSTALLNO() As String
        Get
            Return Current.Session(_ssc_STALLNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STALLNO) = value
        End Set
    End Property

    Shared Property _pSTATBY() As String
        Get
            Return Current.Session(_ssc_STATBY)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATBY) = value
        End Set
    End Property

    Shared Property _pSTATCODE() As String
        Get
            Return Current.Session(_ssc_STATCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATCODE) = value
        End Set
    End Property

    Shared Property _pstatcode1() As String
        Get
            Return Current.Session(_ssc_statcode1)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_statcode1) = value
        End Set
    End Property

    Shared Property _pSTATDATE() As String
        Get
            Return Current.Session(_ssc_STATDATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATDATE) = value
        End Set
    End Property

    Shared Property _pSTATDROP() As String
        Get
            Return Current.Session(_ssc_STATDROP)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATDROP) = value
        End Set
    End Property

    Shared Property _pSTATDROPBY() As String
        Get
            Return Current.Session(_ssc_STATDROPBY)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATDROPBY) = value
        End Set
    End Property

    Shared Property _pSTATDROPDATE() As String
        Get
            Return Current.Session(_ssc_STATDROPDATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATDROPDATE) = value
        End Set
    End Property

    Shared Property _pSTATDROPREM() As String
        Get
            Return Current.Session(_ssc_STATDROPREM)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATDROPREM) = value
        End Set
    End Property

    Shared Property _pSTATDROPTIME() As String
        Get
            Return Current.Session(_ssc_STATDROPTIME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATDROPTIME) = value
        End Set
    End Property

    Shared Property _pSTATHOLD() As String
        Get
            Return Current.Session(_ssc_STATHOLD)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATHOLD) = value
        End Set
    End Property

    Shared Property _pSTATREMARKS() As String
        Get
            Return Current.Session(_ssc_STATREMARKS)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATREMARKS) = value
        End Set
    End Property

    Shared Property _pSTATUS() As String
        Get
            Return Current.Session(_ssc_STATUS)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STATUS) = value
        End Set
    End Property

    Shared Property _pSTICKERNO() As String
        Get
            Return Current.Session(_ssc_STICKERNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STICKERNO) = value
        End Set
    End Property

    Shared Property _pSTRTCODE() As String
        Get
            Return Current.Session(_ssc_STRTCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STRTCODE) = value
        End Set
    End Property

    Shared Property _psys_name() As String
        Get
            Return Current.Session(_ssc_sys_name)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_sys_name) = value
        End Set
    End Property

    Shared Property _psys_user() As String
        Get
            Return Current.Session(_ssc_sys_user)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_sys_user) = value
        End Set
    End Property

    Shared Property _pTIN_DATE() As String
        Get
            Return Current.Session(_ssc_TIN_DATE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_TIN_DATE) = value
        End Set
    End Property

    Shared Property _pTIN_NO() As String
        Get
            Return Current.Session(_ssc_TIN_NO)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_TIN_NO) = value
        End Set
    End Property

    Shared Property _pUPLOADED() As String
        Get
            Return Current.Session(_ssc_UPLOADED)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_UPLOADED) = value
        End Set
    End Property

    Shared Property _pVolume_Allow() As String
        Get
            Return Current.Session(_ssc_Volume_Allow)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Volume_Allow) = value
        End Set
    End Property

    Shared Property _pXSITE() As String
        Get
            Return Current.Session(_ssc_XSITE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_XSITE) = value
        End Set
    End Property


#End Region

#End Region

#Region "BusMastExtn"

#Region "Variable Field"


    Private Const _ssc_AUTHO_REP As String = _sscPrefix & "_ssc_AUTHO_REP"
    Private Const _ssc_AUTHO_REP_POS As String = _sscPrefix & "_ssc_AUTHO_REP_POS"
    Private Const _ssc_BLDG As String = _sscPrefix & "_ssc_BLDG"
    Private Const _ssc_BRGY As String = _sscPrefix & "_ssc_BRGY"
    Private Const _ssc_CITY As String = _sscPrefix & "_ssc_CITY"
    Private Const _ssc_EMAIL As String = _sscPrefix & "_ssc_EMAIL"
    Private Const _ssc_EMRGNCY_CONTACT As String = _sscPrefix & "_ssc_EMRGNCY_CONTACT"
    Private Const _ssc_EMRGNCY_EMAIL As String = _sscPrefix & "_ssc_EMRGNCY_EMAIL"
    Private Const _ssc_EMRGNCY_MOBILE As String = _sscPrefix & "_ssc_EMRGNCY_MOBILE"
    Private Const _ssc_EMRGNCY_TEL As String = _sscPrefix & "_ssc_EMRGNCY_TEL"
    Private Const _ssc_FIRSTNAME As String = _sscPrefix & "_ssc_FIRSTNAME"
    Private Const _ssc_FORYEAR As String = _sscPrefix & "_ssc_FORYEAR"
    Private Const _ssc_IF_WITH_TAX As String = _sscPrefix & "_ssc_IF_WITH_TAX"
    Private Const _ssc_LASTNAME As String = _sscPrefix & "_ssc_LASTNAME"
    Private Const _ssc_MIDDLENAME As String = _sscPrefix & "_ssc_MIDDLENAME"
    Private Const _ssc_NO_EMP_F As String = _sscPrefix & "_ssc_NO_EMP_F"
    Private Const _ssc_NO_EMP_LGU As String = _sscPrefix & "_ssc_NO_EMP_LGU"
    Private Const _ssc_NO_EMP_M As String = _sscPrefix & "_ssc_NO_EMP_M"
    Private Const _ssc_P_Gender As String = _sscPrefix & "_ssc_P_Gender"
    Private Const _ssc_P_Treasurer As String = _sscPrefix & "_ssc_P_Treasurer"
    Private Const _ssc_Pres_FName As String = _sscPrefix & "_ssc_Pres_FName"
    Private Const _ssc_PRES_GENDER As String = _sscPrefix & "_ssc_PRES_GENDER"
    Private Const _ssc_Pres_LName As String = _sscPrefix & "_ssc_Pres_LName"
    Private Const _ssc_Pres_MName As String = _sscPrefix & "_ssc_Pres_MName"
    Private Const _ssc_PRES_NAME As String = _sscPrefix & "_ssc_PRES_NAME"
    Private Const _ssc_PROVINCE As String = _sscPrefix & "_ssc_PROVINCE"
    Private Const _ssc_STREET As String = _sscPrefix & "_ssc_STREET"
    Private Const _ssc_SUBD As String = _sscPrefix & "_ssc_SUBD"
    Private Const _ssc_TAX_INDIC As String = _sscPrefix & "_ssc_TAX_INDIC"
    Private Const _ssc_TEL As String = _sscPrefix & "_ssc_TEL"
    Private Const _ssc_TREAS_NAME As String = _sscPrefix & "_ssc_TREAS_NAME"

#End Region
#Region "Property Field"

    Shared Property _pAUTHO_REP() As String
        Get
            Return Current.Session(_ssc_AUTHO_REP)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_AUTHO_REP) = value
        End Set
    End Property

    Shared Property _pAUTHO_REP_POS() As String
        Get
            Return Current.Session(_ssc_AUTHO_REP_POS)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_AUTHO_REP_POS) = value
        End Set
    End Property

    Shared Property _pBLDG() As String
        Get
            Return Current.Session(_ssc_BLDG)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BLDG) = value
        End Set
    End Property

    Shared Property _pBRGY() As String
        Get
            Return Current.Session(_ssc_BRGY)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BRGY) = value
        End Set
    End Property

    Shared Property _pCITY() As String
        Get
            Return Current.Session(_ssc_CITY)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CITY) = value
        End Set
    End Property

    Shared Property _pEMAIL() As String
        Get
            Return Current.Session(_ssc_EMAIL)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EMAIL) = value
        End Set
    End Property

    Shared Property _pEMRGNCY_CONTACT() As String
        Get
            Return Current.Session(_ssc_EMRGNCY_CONTACT)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EMRGNCY_CONTACT) = value
        End Set
    End Property

    Shared Property _pEMRGNCY_EMAIL() As String
        Get
            Return Current.Session(_ssc_EMRGNCY_EMAIL)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EMRGNCY_EMAIL) = value
        End Set
    End Property

    Shared Property _pEMRGNCY_MOBILE() As String
        Get
            Return Current.Session(_ssc_EMRGNCY_MOBILE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EMRGNCY_MOBILE) = value
        End Set
    End Property

    Shared Property _pEMRGNCY_TEL() As String
        Get
            Return Current.Session(_ssc_EMRGNCY_TEL)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_EMRGNCY_TEL) = value
        End Set
    End Property

    Shared Property _pFIRSTNAME() As String
        Get
            Return Current.Session(_ssc_FIRSTNAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_FIRSTNAME) = value
        End Set
    End Property

    Shared Property _pFORYEAR() As String
        Get
            Return Current.Session(_ssc_FORYEAR)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_FORYEAR) = value
        End Set
    End Property

    Shared Property _pIF_WITH_TAX() As String
        Get
            Return Current.Session(_ssc_IF_WITH_TAX)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_IF_WITH_TAX) = value
        End Set
    End Property

    Shared Property _pLASTNAME() As String
        Get
            Return Current.Session(_ssc_LASTNAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_LASTNAME) = value
        End Set
    End Property

    Shared Property _pMIDDLENAME() As String
        Get
            Return Current.Session(_ssc_MIDDLENAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_MIDDLENAME) = value
        End Set
    End Property

    Shared Property _pNO_EMP_F() As String
        Get
            Return Current.Session(_ssc_NO_EMP_F)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_NO_EMP_F) = value
        End Set
    End Property

    Shared Property _pNO_EMP_LGU() As String
        Get
            Return Current.Session(_ssc_NO_EMP_LGU)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_NO_EMP_LGU) = value
        End Set
    End Property

    Shared Property _pNO_EMP_M() As String
        Get
            Return Current.Session(_ssc_NO_EMP_M)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_NO_EMP_M) = value
        End Set
    End Property

    Shared Property _pP_Gender() As String
        Get
            Return Current.Session(_ssc_P_Gender)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_P_Gender) = value
        End Set
    End Property

    Shared Property _pP_Treasurer() As String
        Get
            Return Current.Session(_ssc_P_Treasurer)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_P_Treasurer) = value
        End Set
    End Property

    Shared Property _pPres_FName() As String
        Get
            Return Current.Session(_ssc_Pres_FName)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Pres_FName) = value
        End Set
    End Property

    Shared Property _pPRES_GENDER() As String
        Get
            Return Current.Session(_ssc_PRES_GENDER)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_PRES_GENDER) = value
        End Set
    End Property

    Shared Property _pPres_LName() As String
        Get
            Return Current.Session(_ssc_Pres_LName)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Pres_LName) = value
        End Set
    End Property

    Shared Property _pPres_MName() As String
        Get
            Return Current.Session(_ssc_Pres_MName)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_Pres_MName) = value
        End Set
    End Property

    Shared Property _pPRES_NAME() As String
        Get
            Return Current.Session(_ssc_PRES_NAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_PRES_NAME) = value
        End Set
    End Property

    Shared Property _pPROVINCE() As String
        Get
            Return Current.Session(_ssc_PROVINCE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_PROVINCE) = value
        End Set
    End Property

    Shared Property _pRowId() As String
        Get
            Return Current.Session(_ssc_RowId)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_RowId) = value
        End Set
    End Property

    Shared Property _pSTREET() As String
        Get
            Return Current.Session(_ssc_STREET)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_STREET) = value
        End Set
    End Property

    Shared Property _pSUBD() As String
        Get
            Return Current.Session(_ssc_SUBD)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_SUBD) = value
        End Set
    End Property

    Shared Property _pTAX_INDIC() As String
        Get
            Return Current.Session(_ssc_TAX_INDIC)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_TAX_INDIC) = value
        End Set
    End Property

    Shared Property _pTEL() As String
        Get
            Return Current.Session(_ssc_TEL)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_TEL) = value
        End Set
    End Property

    Shared Property _pTREAS_NAME() As String
        Get
            Return Current.Session(_ssc_TREAS_NAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_TREAS_NAME) = value
        End Set
    End Property

#End Region

#End Region

#Region "Image Attachment"


    'Private Const _ssc_OwnerPic As FileUpload

    'Shared Property _pOwnerPic() As FileUpload
    '    Get
    '         Return Current.Session(_ssc_OwnerPic
    '    End Get
    '    Set(ByVal value As FileUpload)
    '        _mOwnerPic = value
    '    End Set
    'End Property

#End Region

#Region "BUSLINE"

    Private Const _ssc_BUS_CODE As String = _sscPrefix & "_ssc_BUS_CODE"
    Private Const _ssc_AREA As String = _sscPrefix & "_ssc_AREA"
    Private Const _ssc_CAPITAL As String = _sscPrefix & "_ssc_CAPITAL"
    Private Const _ssc_GROSSREC As String = _sscPrefix & "_ssc_GROSSREC"
    Private Const _ssc_BUSDESC As String = _sscPrefix & "_ssc_BUSDESC"

    Shared Property _pBUS_CODE() As String
        Get
            Return Current.Session(_ssc_BUS_CODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BUS_CODE) = value
        End Set
    End Property

    Shared Property _pAREA() As String
        Get
            Return Current.Session(_ssc_AREA)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_AREA) = value
        End Set
    End Property

    Shared Property _pCAPITAL() As String
        Get
            Return Current.Session(_ssc_CAPITAL)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_CAPITAL) = value
        End Set
    End Property

    Shared Property _pGROSSREC() As String
        Get
            Return Current.Session(_ssc_GROSSREC)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_GROSSREC) = value
        End Set
    End Property

    Shared Property _pBUSDESC() As String
        Get
            Return Current.Session(_ssc_BUSDESC)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BUSDESC) = value
        End Set
    End Property

#End Region

#Region "BUSINESS DECRIPTION"

    Shared Property _pBusinessDescription() As String
        Get
            Return Current.Session(_ssc_BusinessDescription)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_BusinessDescription) = value
        End Set
    End Property

#End Region

#Region "Process Indicator"
    Shared Property _pIsProcessAll() As Boolean
        Get
            Return Current.Session(_ssc_IsProcessAll)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_ssc_IsProcessAll) = value
        End Set
    End Property

#End Region
End Class
