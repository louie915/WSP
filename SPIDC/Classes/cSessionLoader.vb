#Region "Imports"
Imports System.Web.HttpContext
Imports System.Data.SqlClient
#End Region
Public Class cSessionLoader

#Region "Variables"

    Private Const _sscPrefix As String = "cSessionLoader."
    Private Const _sscLGU_Name As String = _sscPrefix & "_sscLGU_Name"
    Private Const _sscLGU_Address As String = _sscPrefix & "_sscLGU_Address"
    Private Const _sscCurrentYear As String = _sscPrefix & "_sscCurrentYear"
    Private Const _sscUniqueID As String = _sscPrefix & "_sscUniqueID"
    Private Const _sscAccountNo As String = _sscPrefix & "_sscAccountNo"
    Private Const _sscImageID As String = _sscPrefix & "_sscImageID"
    Private Const _sscReviewMode As String = _sscPrefix & "_sscImageID"
    Private Const _sscBPLTAS_SvrName As String = _sscPrefix & "_sscBPLTAS_SvrName"
    Private Const _sscBPLTAS_DbName As String = _sscPrefix & "_sscBPLTAS_DbName"
    Private Const _sscControlNo As String = _sscPrefix & "_sscControlNo"
    Private Const _sscRemarks As String = _sscPrefix & "_sscRemarks"

    Private Const _sscErrMSG As String = _sscPrefix & "_sscErrMSG"

    '-------------------- for Payment

    Private Const _sscAssessNo As String = _sscPrefix & "_sscAssessNo"
    Private Const _sscPeriodCovered As String = _sscPrefix & "_sscPeriodCovered"
    Private Const _sscPayMode As String = _sscPrefix & "_sscPayMode"
    Private Const _sscTDN As String = _sscPrefix & "_sscTDN"
    Private Const _sscDEL As String = _sscPrefix & "_sscDEL"
    Private Const _sscTotalAmountDue As String = _sscPrefix & "_sscTotalAmountDue"
    Private Const _sscService As String = _sscPrefix & "_sscService"
    Private Const _sscType As String = _sscPrefix & "_sscType"
    Private Const _sscTXNREFNO As String = _sscPrefix & "_sscTXNREFNO"
    Private Const _sscSelectedEmail As String = _sscPrefix & "_sscSelectedEmail"

    Private Const _sscBTAnnualDue As String = _sscPrefix & "_sscBTAnnualDue"
    Private Const _sscGFAnnualDue As String = _sscPrefix & "_sscGFAnnualDue"

    '--------for GCASH ORDER QUERY
    Private Const _ssctransactionId As String = _sscPrefix & "_ssctransactionId"
    Private Const _sscmerchantTransId As String = _sscPrefix & "_sscmerchantTransId"
    Private Const _sscacquirementId As String = _sscPrefix & "_sscacquirementId"

    '-------------------- for RPT
    Private Const _sscAssessmentNo As String = _sscPrefix & "_sscAssessmentNo"
    Private Const _sscRPTtotal As String = _sscPrefix & "_sscRPTtotal"
    Private Const _sscPayor As String = _sscPrefix & "_sscPayor"
    '-------------------- for treasury
    Private Const _sscVerifying As String = _sscPrefix & "_sscVerifying"


    '-------------------- for payment with SOA
    Private Const _sscPSTransRefNo As String = _sscPrefix & "_sscPSTransRefNo"
    Private Const _sscPSTransType As String = _sscPrefix & "_sscPSTransType"
    Private Const _sscPSTransDesc As String = _sscPrefix & "_sscPSTransDesc"
    Private Const _sscPSTransID As String = _sscPrefix & "_sscPSTransID"
    Private Const _sscPSTransAmount As String = _sscPrefix & "_sscPSTransAmount"
    Private Const _sscPSTransOTCNote As String = _sscPrefix & "_sscPSTransOTCNote"

    '----- FOR BP
    Private Const _sscBPQTR As String = _sscPrefix & "_sscBPQTR"
    Private Const _sscFORYEAR As String = _sscPrefix & "_sscFORYEAR"
    '----- Web Page Indicator if NEW or OLD
    Private Const _sscWeb As String = _sscPrefix & "_sscWeb"
    Private Const _sscStatus As String = _sscPrefix & "_sscWStatus"

    '--------For Appointment
    Private Const _sscAppID As String = _sscPrefix & "_sscAppID"
    Private Const _sscSelectedDepartment As String = _sscPrefix & "_sscSelectedDepartment"
    Private Const _sscSelectedEventID As String = _sscPrefix & "_sscSelectedEventID"
    Private Const _sscSelectedEventDate As String = _sscPrefix & "_sscSelectedEventDate"
    Private Const _sscSelectedEventTime As String = _sscPrefix & "_sscSelectedEventTime"
    Private Const _sscCode As String = _sscPrefix & "_sscCode"
    Private Const _sscRPTPin As String = _sscPrefix & "_sscRPTPin"
    Private Const _sscRPTKind As String = _sscPrefix & "_sscRPTKind"
    Private Const _sscRPTLocation As String = _sscPrefix & "_sscRPTLocation"
    Private Const _sscRPTOwnerName As String = _sscPrefix & "_sscRPTOwnerName"
    '-------- Same Account Login Prevention
    Private Const _sscKeyToken As String = _sscPrefix & "_sscKeyToken"

    Private Const _sscTemporaryPermitNo As String = _sscPrefix & "_sscTemporaryPermitNo"


#End Region

#Region "Properties"
    Shared Property _pBTAnnualDue() As String
        Get
            Return Current.Session(_sscBTAnnualDue)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBTAnnualDue) = value
        End Set
    End Property

    Shared Property _pGFAnnualDue() As String
        Get
            Return Current.Session(_sscGFAnnualDue)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGFAnnualDue) = value
        End Set
    End Property

    Shared Property _ptransactionId() As String
        Get
            Return Current.Session(_ssctransactionId)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssctransactionId) = value
        End Set
    End Property

    Shared Property _pmerchantTransId() As String
        Get
            Return Current.Session(_sscmerchantTransId)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscmerchantTransId) = value
        End Set
    End Property

    Shared Property _pacquirementId() As String
        Get
            Return Current.Session(_sscacquirementId)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscacquirementId) = value
        End Set
    End Property




    Shared Property _pPSTransRefNo() As String
        Get
            Return Current.Session(_sscPSTransRefNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPSTransRefNo) = value
        End Set
    End Property
    Shared Property _pPSTransType() As String
        Get
            Return Current.Session(_sscPSTransType)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPSTransType) = value
        End Set
    End Property

    Shared Property _pPSTransDesc() As String
        Get
            Return Current.Session(_sscPSTransDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPSTransDesc) = value
        End Set
    End Property

    Shared Property _pPSTransID() As String
        Get
            Return Current.Session(_sscPSTransID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPSTransID) = value
        End Set
    End Property

    Shared Property _pPSTransAmount() As String
        Get
            Return Current.Session(_sscPSTransAmount)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPSTransAmount) = value
        End Set
    End Property

    Shared Property _pPSTransOTCNote() As String
        Get
            Return Current.Session(_sscPSTransOTCNote)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPSTransOTCNote) = value
        End Set
    End Property




    Shared Property _pErrMSG() As String
        Get
            Return Current.Session(_sscErrMSG)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscErrMSG) = value
        End Set
    End Property
    Shared Property _pKeyToken() As String
        Get
            Return Current.Session(_sscKeyToken)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscKeyToken) = value
        End Set
    End Property
    Shared Property _pRPTPin() As String
        Get
            Return Current.Session(_sscRPTPin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRPTPin) = value
        End Set
    End Property

    Shared Property _pAppID() As String
        Get
            Return Current.Session(_sscAppID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAppID) = value
        End Set
    End Property


    Shared Property _pRPTKind() As String
        Get
            Return Current.Session(_sscRPTKind)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRPTKind) = value
        End Set
    End Property

    Shared Property _pRPTLocation() As String
        Get
            Return Current.Session(_sscRPTLocation)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRPTLocation) = value
        End Set
    End Property

    Shared Property _pRPTOwnerName() As String
        Get
            Return Current.Session(_sscRPTOwnerName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRPTOwnerName) = value
        End Set
    End Property
    Shared Property _pSelectedDepartment() As String
        Get
            Return Current.Session(_sscSelectedDepartment)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSelectedDepartment) = value
        End Set
    End Property
    Shared Property _pSelectedEventID() As String
        Get
            Return Current.Session(_sscSelectedEventID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSelectedEventID) = value
        End Set
    End Property
    Shared Property _pSelectedEventDate() As String
        Get
            Return Current.Session(_sscSelectedEventDate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSelectedEventDate) = value
        End Set
    End Property
    Shared Property _pSelectedEventTime() As String
        Get
            Return Current.Session(_sscSelectedEventTime)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSelectedEventTime) = value
        End Set
    End Property

    Shared Property _pCode() As String
        Get
            Return Current.Session(_sscCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscCode) = value
        End Set
    End Property

    Shared Property _pPeriodCovered() As String
        Get
            Return Current.Session(_sscPeriodCovered)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPeriodCovered) = value
        End Set
    End Property



    Shared Property _pPayMode() As String
        Get
            Return Current.Session(_sscPayMode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPayMode) = value
        End Set
    End Property

    Shared Property _pAssessNo() As String
        Get
            Return Current.Session(_sscAssessNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAssessNo) = value
        End Set
    End Property
    Shared Property _pLGU_Name() As String
        Get
            Return Current.Session(_sscLGU_Name)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Name) = value
        End Set
    End Property

    Shared Property _pLGU_Address() As String
        Get
            Return Current.Session(_sscLGU_Address)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLGU_Address) = value
        End Set
    End Property

    Shared Property _pCurrentYear() As String
        Get
            Return Current.Session(_sscCurrentYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscCurrentYear) = value
        End Set
    End Property

    Shared Property _pUniqueID() As String
        Get
            Return Current.Session(_sscUniqueID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscUniqueID) = value
        End Set
    End Property

    Shared Property _pAccountNo() As String
        Get
            Return Current.Session(_sscAccountNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAccountNo) = value
        End Set
    End Property

    Shared Property _pBPQTR() As String
        Get
            Return Current.Session(_sscBPQTR)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBPQTR) = value
        End Set
    End Property
    Shared Property _pFORYEAR() As String
        Get
            Return Current.Session(_sscFORYEAR)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFORYEAR) = value
        End Set
    End Property
    Shared Property _pImageID() As String
        Get
            Return Current.Session(_sscImageID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscImageID) = value
        End Set
    End Property

    Shared Property _pReviewMode() As Boolean
        Get
            Return Current.Session(_sscReviewMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscReviewMode) = value
        End Set
    End Property

    Shared Property _pRemarks() As String
        Get
            Return Current.Session(_sscRemarks)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRemarks) = value
        End Set
    End Property

    Shared Property _pBPLTAS_SvrName() As String
        Get
            Return Current.Session(_sscBPLTAS_SvrName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBPLTAS_SvrName) = value
        End Set
    End Property

    Shared Property _pBPLTAS_DbName() As String
        Get
            Return Current.Session(_sscBPLTAS_DbName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBPLTAS_DbName) = value
        End Set
    End Property

    Shared Property _pControlNo() As String
        Get
            Return Current.Session(_sscControlNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscControlNo) = value
        End Set
    End Property

    Shared Property _pTDN() As String
        Get
            Return Current.Session(_sscTDN)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTDN) = value
        End Set
    End Property

    Shared Property _pDEL() As String
        Get
            Return Current.Session(_sscDEL)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscDEL) = value
        End Set
    End Property
    Shared Property _pTotalAmountDue() As String
        Get
            Return Current.Session(_sscTotalAmountDue)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTotalAmountDue) = value
        End Set
    End Property
    Shared Property _pType() As String
        Get
            Return Current.Session(_sscType)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscType) = value
        End Set
    End Property
    Shared Property _pService() As String
        Get
            Return Current.Session(_sscService)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscService) = value
        End Set
    End Property
    Shared Property _pTXNREFNO() As String
        Get
            Return Current.Session(_sscTXNREFNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTXNREFNO) = value
        End Set
    End Property

    Shared Property _pAssessmentNo() As String
        Get
            Return Current.Session(_sscAssessmentNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAssessmentNo) = value
        End Set
    End Property
    Shared Property _pPayor() As String
        Get
            Return Current.Session(_sscPayor)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPayor) = value
        End Set
    End Property
    Shared Property _pRPTtotal() As String
        Get
            Return Current.Session(_sscRPTtotal)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRPTtotal) = value
        End Set
    End Property

    Shared Property _pSelectedEmail() As String
        Get
            Return Current.Session(_sscSelectedEmail)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSelectedEmail) = value
        End Set
    End Property

    Shared Property _pVerifying() As String
        Get
            Return Current.Session(_sscVerifying)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscVerifying) = value
        End Set
    End Property



    Shared Property _pWeb() As String
        Get
            Return Current.Session(_sscWeb)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscWeb) = value
        End Set
    End Property


    Shared Property _pStatus() As String ' Added 20210525
        Get
            Return Current.Session(_sscStatus)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscStatus) = value
        End Set
    End Property

    Shared Property _pTemporaryPermitNo() As String  ' Added 20231024
        Get
            Return Current.Session(_sscTemporaryPermitNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTemporaryPermitNo) = value
        End Set
    End Property

#End Region
End Class
