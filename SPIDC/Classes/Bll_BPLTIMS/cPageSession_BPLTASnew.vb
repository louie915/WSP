

#Region "Imports"

Imports System.Web.HttpContext

#End Region

Public Class cPageSession_BPLTASnew

#Region "Variables"
    '_ssc = Session String Constant
    Private Const _sscPrefix As String = "cPageSession_Sample."

    Private Const _sscAddMode As String = _sscPrefix & "_sscAddMode"
    Private Const _sscEditMode As String = _sscPrefix & "_sscEditMode"

    Private Const _sscIsProceed As String = _sscPrefix & "_sscIsProceed"

    Private Const _sscUserId As String = _sscPrefix & "UserId"
    Private Const _sscAccountNo As String = _sscPrefix & "_sscAccountNo"
    Private Const _sscClearText As String = _sscPrefix & "_sscClearText"
    Private Const _sscOrigSample As String = _sscPrefix & "_sscOrigSample"

    Private Const _sscSvrDate As String = _sscPrefix & "_sscSvrDate"
    Private Const _sscSvrYear As String = _sscPrefix & "_sscSvrYear"
    Private Const _sscSvrCurrentDate As String = _sscPrefix & "_sscSvrCurrentDate"
    Private Const _sscDistCode As String = _sscPrefix & "_sscDistCode"
    Private Const _sscBrgyCode As String = _sscPrefix & "_sscBrgyCode"
    Private Const _sscDistrictCode As String = _sscPrefix & "_sscDistrictCode"
    Private Const _sscStatus As String = _sscPrefix & "_sscStatus"

    Private Const _sscxIncCode As String = _sscPrefix & "_sscxIncCode"
    Private Const _ssctype As String = _sscPrefix & "_sscxtype" '20170920
    Private Const _sscDate_Estab As String = _sscPrefix & "_sscDate_Estab"  '@ Added 20170705
    Private Const _sscRemarks As String = _sscPrefix & "_sscRemarks"

    Private Const _sscCurrentTab As String = _sscPrefix & "_sscCurrentTab"

    Private Const _sscField As String = _sscPrefix & "_sscField"
    Private Const _sscFieldWhere As String = _sscPrefix & "_sscFieldWhere"
    Private Const _sscReviewMode As String = _sscPrefix & "_sscReviewMode"
    Private Const _sscEmailAdd As String = _sscPrefix & "_sscEmailAdd"

    Private Const _sscIsPosted As String = _sscPrefix & "_sscIsPosted"
    Private Const _sscAcquiredBy As String = _sscPrefix & "_sscAcquiredBy"
    Private Const _sscXCODE As String = _sscPrefix & "_sscXCODE"
    Private Const _sscReviewingBy As String = _sscPrefix & "_sscReviewingBy"
    Private Const _sscFileNo As String = "_sscFileNo."

#End Region

    Shared Property _pFileNo() As String
        Get
            Return Current.Session(_sscFileNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFileNo) = value
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

    Shared Property _pDate_Estab() As Date
        Get
            Return Current.Session(_sscDate_Estab)
        End Get
        Set(ByVal value As Date)
            Current.Session(_sscDate_Estab) = value
        End Set
    End Property

#Region "Properties"


    Shared Property _pAddMode() As Boolean
        Get
            Return Current.Session(_sscAddMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscAddMode) = value
        End Set
    End Property

    Shared Property _pSvrDate() As String
        Get
            Return Current.Session(_sscSvrDate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSvrDate) = value
        End Set
    End Property

    Shared Property _pSvrYear() As String
        Get
            Return Current.Session(_sscSvrYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSvrYear) = value
        End Set
    End Property

    Shared Property _pSvrCurrentDate() As String
        Get
            Return Current.Session(_sscSvrCurrentDate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSvrCurrentDate) = value
        End Set
    End Property

    Shared Property _pEditMode() As Boolean
        Get
            Return Current.Session(_sscEditMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscEditMode) = value
        End Set
    End Property






#End Region

#Region "Properties Field Original"

    Shared Property _pId() As String
        Get
            Return Current.Session(_sscOrigSample)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigSample) = value
        End Set
    End Property


    Shared Property _pDistCode() As String
        Get
            Return Current.Session(_sscDistCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscDistCode) = value
        End Set
    End Property

    Shared Property _pBrgyCode() As String
        Get
            Return Current.Session(_sscBrgyCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBrgyCode) = value
        End Set
    End Property

    Shared Property _pIsProceed() As String
        Get
            Return Current.Session(_sscIsProceed)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscIsProceed) = value
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

    Shared Property _pAccountNo() As String
        Get
            Return Current.Session(_sscAccountNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAccountNo) = value
        End Set
    End Property

    Shared Property _pClearText() As Boolean
        Get
            Return Current.Session(_sscClearText)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscClearText) = value
        End Set
    End Property

    Shared Property _pDistrictCode() As String
        Get
            Return Current.Session(_sscDistrictCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscDistrictCode) = value
        End Set
    End Property

    Shared Property _pStatus() As String
        Get
            Return Current.Session(_sscStatus)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscStatus) = value
        End Set
    End Property


    Shared Property _pxIncCode() As String
        Get
            Return Current.Session(_sscxIncCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscxIncCode) = value
        End Set
    End Property
    Shared Property _ptype() As String
        Get
            Return Current.Session(_ssctype)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssctype) = value
        End Set
    End Property

    Shared Property _pCurrentTab() As String
        Get
            Return Current.Session(_sscCurrentTab)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscCurrentTab) = value
        End Set
    End Property

    Shared Property _pField() As String
        Get
            Return Current.Session(_sscField)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscField) = value
        End Set
    End Property

    Shared Property _pFieldWhere() As String
        Get
            Return Current.Session(_sscFieldWhere)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFieldWhere) = value
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

    Shared Property _pEmailAdd() As String
        Get
            Return Current.Session(_sscEmailAdd)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEmailAdd) = value
        End Set
    End Property

    Shared Property _pIsPosted() As Boolean
        Get
            Return Current.Session(_sscIsPosted)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscIsPosted) = value
        End Set
    End Property
    Shared Property _pAcquiredBy() As String
        Get
            Return Current.Session(_sscAcquiredBy)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAcquiredBy) = value
        End Set
    End Property

    Shared Property _pXCODE() As String
        Get
            Return Current.Session(_sscXCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscXCODE) = value
        End Set
    End Property

    Shared Property _pReviewingBy() As String
        Get
            Return Current.Session(_sscReviewingBy)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscReviewingBy) = value
        End Set
    End Property

#End Region

#Region "Routines"
    Public Shared Sub _pSubSessionClear()
        Try
            '----------------------------------

            _pAddMode = False
            _pEditMode = False

            _pId = Nothing

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region



End Class
