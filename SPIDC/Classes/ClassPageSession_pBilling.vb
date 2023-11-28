

#Region "Imports"

Imports System.Web.HttpContext

#End Region

Public Class ClassPageSession_pBilling

#Region "Variables"
    '_ssc = Session String Constant
    Private Const _sscPrefix As String = "ClassPageSession_pBilling."

    Private Shared _sscUserId As String = _sscPrefix & "_sscUserId"
    Private Shared _sscLocGovUnit As String = _sscPrefix & "_sscLocGovUnit"
    Private Shared _sscReferenceNumber As String = _sscPrefix & "_sscReferenceNumber"
    Private Shared _sscBusinessAccountNumber As String = _sscPrefix & "_sscBusinessAccountNumber"

    Private Shared _sscQuarterToPay As String = _sscPrefix & "_sscQuarterToPay"
    Private Shared _sscTransactionType As String = _sscPrefix & "_sscTransactionType"

    Private Shared _sscTotalTaxDue As String = _sscPrefix & "_sscTotalTaxDue"
    Private Shared _sscTotalPenalty As String = _sscPrefix & "_sscTotalPenalty"
    Private Shared _sscTotalExcessCredit As String = _sscPrefix & "_sscTotalExcessCredit"
    Private Shared _sscTotalTaxCredit As String = _sscPrefix & "_sscTotalTaxCredit"
    Private Shared _sscTotalAmountDue As String = _sscPrefix & "_sscTotalAmountDue"

    Private Shared _sscResultGrossReceiptIsNeeded As String = _sscPrefix & "_sscResultGrossReceiptIsNeeded"
    Private Shared _sscResultTransactionDidNotProceed As String = _sscPrefix & "_sscResultTransactionDidNotProceed"
    Private Shared _sscResultAccountCleared As String = _sscPrefix & "_sscResultAccountCleared"
    Private Shared _sscResultTransactionPaid As String = _sscPrefix & "_sscResultTransactionPaid"
    Private Shared _sscAcctno As String = _sscPrefix & "_sscAcctno"
    Private Shared _sscCommercialName As String = _sscPrefix & "_sscCommercialName"
    Private Shared _sscFileNo As String = _sscPrefix & "_sscFileNo"
#End Region

#Region "Properties"

    Shared Property _pFileNo() As String
        Get
            Return Current.Session(_sscFileNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFileNo) = value
        End Set
    End Property

    Shared Property _pAcctno() As String
        Get
            Return Current.Session(_sscAcctno)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAcctno) = value
        End Set
    End Property

    Shared Property _pUserId() As String
        Get
            Return Current.Session(_sscUserId)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscUserId) = value
        End Set
    End Property
    Shared Property _pLocGovUnit() As String
        Get
            Return Current.Session(_sscLocGovUnit)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLocGovUnit) = value
        End Set
    End Property
    Shared Property _pBusinessAccountNumber() As String
        Get
            Return Current.Session(_sscBusinessAccountNumber)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBusinessAccountNumber) = value
        End Set
    End Property
    Shared Property _pReferenceNumber() As String
        Get
            Return Current.Session(_sscReferenceNumber)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscReferenceNumber) = value
        End Set
    End Property
    Shared Property _pCommercialName() As String
        Get
            Return Current.Session(_sscCommercialName)
        End Get
        Set(value As String)
            Current.Session(_sscCommercialName) = value
        End Set
    End Property

    Shared Property _pQuarterToPay() As String
        Get
            Return Current.Session(_sscQuarterToPay)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscQuarterToPay) = value
        End Set
    End Property
    Shared Property _pTransactionType() As String
        Get
            Return Current.Session(_sscTransactionType)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTransactionType) = value
        End Set
    End Property

    Shared Property _pTotalTaxDue() As Double
        Get
            Return Current.Session(_sscTotalTaxDue)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscTotalTaxDue) = value
        End Set
    End Property
    Shared Property _pTotalPenalty() As Double
        Get
            Return Current.Session(_sscTotalPenalty)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscTotalPenalty) = value
        End Set
    End Property
    Shared Property _pTotalExcessCredit() As Double
        Get
            Return Current.Session(_sscTotalExcessCredit)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscTotalExcessCredit) = value
        End Set
    End Property
    Shared Property _pTotalTaxCredit() As Double
        Get
            Return Current.Session(_sscTotalTaxCredit)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscTotalTaxCredit) = value
        End Set
    End Property
    Shared Property _pTotalAmountDue() As Double
        Get
            Return Current.Session(_sscTotalAmountDue)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscTotalAmountDue) = value
        End Set
    End Property

    Shared Property _pResultGrossReceiptIsNeeded() As Boolean
        Get
            Return Current.Session(_sscResultGrossReceiptIsNeeded)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscResultGrossReceiptIsNeeded) = value
        End Set
    End Property
    Shared Property _pResultTransactionDidNotProceed() As Boolean
        Get
            Return Current.Session(_sscResultTransactionDidNotProceed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscResultTransactionDidNotProceed) = value
        End Set
    End Property
    Shared Property _pResultAccountCleared() As Boolean
        Get
            Return Current.Session(_sscResultAccountCleared)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscResultAccountCleared) = value
        End Set
    End Property
    Shared Property _pResultTransactionPaid() As Boolean
        Get
            Return Current.Session(_sscResultTransactionPaid)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscResultTransactionPaid) = value
        End Set
    End Property

#End Region

#Region "Routines"
    Public Shared Sub _pSubSessionClear()
        Try
            '----------------------------------
            _pUserId = Nothing
            _pLocGovUnit = Nothing
            _pBusinessAccountNumber = Nothing
            _pReferenceNumber = Nothing
            _pQuarterToPay = Nothing
            _pTransactionType = Nothing

            _pTotalTaxDue = Nothing
            _pTotalPenalty = Nothing
            _pTotalExcessCredit = Nothing
            _pTotalTaxCredit = Nothing
            _pTotalAmountDue = Nothing

            _pResultGrossReceiptIsNeeded = False
            _pResultTransactionDidNotProceed = False
            _pResultAccountCleared = False
            _pResultTransactionPaid = False

            _pCommercialName = Nothing

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
