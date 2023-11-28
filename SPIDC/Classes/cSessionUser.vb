

#Region "Imports"

Imports System.Web.HttpContext
Imports System.Data.SqlClient
#End Region

Public Class cSessionUser

#Region "Variables"

    '_ssc = Session String Constant
    Private Const _sscPrefix As String = "cSessionUser."

    Private Const _sscIDNo As String = _sscPrefix & "_sscIDNo"
    Private Const _sscUserID As String = _sscPrefix & "_sscUserID"
    Private Const _sscSPIDCREFNO As String = _sscPrefix & "_sscSPIDCREFNO"
    Private Const _sscKeyToken As String = _sscPrefix & "_sscKeyToken"
    Private Const _sscMachineName As String = _sscPrefix & "_sscMachineName"

    Private Const _sscFirstName As String = _sscPrefix & "_sscFirstName"
    Private Const _sscLastName As String = _sscPrefix & "_sscLastName"
    Private Const _sscMiddleName As String = _sscPrefix & "_sscMiddleName"
    Private Const _sscExtnName As String = _sscPrefix & "_sscExtnName"



    Private Const _sscOffice As String = _sscPrefix & "_sscOffice"
    Private Const _sscUserLevel As String = _sscPrefix & "_sscUserLevel"


    Private Const _sscBirthDate As String = _sscPrefix & "_sscBirthDate"
    Private Const _sscBirthPlace As String = _sscPrefix & "_sscBirthPlace"

    Private Const _sscSetupGender As String = _sscPrefix & "_sscSetupGender"
    Private Const _sscSetupGenderDetail As String = _sscPrefix & "_sscSetupGenderDetail"

    Private Const _sscSetupCivilStatus As String = _sscPrefix & "_sscSetupCivilStatus"
    Private Const _sscSetupCivilStatusDetail As String = _sscPrefix & "_sscSetupCivilStatusDetail"

    Private Const _sscSetupCitizenship As String = _sscPrefix & "_sscSetupCitizenship"
    Private Const _sscSetupCitizenshipDetail As String = _sscPrefix & "_sscSetupCitizenshipDetail"

    Private Const _sscIsActivated As String = _sscPrefix & "_sscIsActivated"
    Private Const _sscUsertype As String = _sscPrefix & "_sscUsertype"
    Private Const _sscResetPass As String = _sscPrefix & "_sscResetPass"
    Private Const _sscStrDt As String = _sscPrefix & "_sscStrDt"

    Private Const _sscQtr As String = _sscPrefix & "_sscQtr"
    Private Const _sscYr As String = _sscPrefix & "_sscYr"

    Private Const _sscNewAcc As String = _sscPrefix & "_sscNewAcc"

#End Region

#Region "Properties"
    Shared Property _pNewAcc() As String
        Get
            Return Current.Session(_sscNewAcc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscNewAcc) = value
        End Set
    End Property

    Shared Property _pYr() As String
        Get
            Return Current.Session(_sscYr)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscYr) = value
        End Set
    End Property

    Shared Property _pQtr() As String
        Get
            Return Current.Session(_sscQtr)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscQtr) = value
        End Set
    End Property
    Shared Property _pStrDt() As String
        Get
            Return Current.Session(_sscStrDt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscStrDt) = value
        End Set
    End Property
    Shared Property _pUserLevel() As String
        Get
            Return Current.Session(_sscUserLevel)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscUserLevel) = value
        End Set
    End Property

    Shared Property _pOffice() As String
        Get
            Return Current.Session(_sscOffice)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOffice) = value
        End Set
    End Property
    Shared Property _pMachineName() As String
        Get
            Return Current.Session(_sscMachineName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMachineName) = value
        End Set
    End Property
    Shared Property _pIDNo() As String
        Get
            Return Current.Session(_sscIDNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscIDNo) = value
        End Set
    End Property
    Shared Property _pUserID() As String
        Get
            Return Current.Session(_sscUserID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscUserID) = value
        End Set
    End Property

    Shared Property _pSPIDCREFNO() As String
        Get
            Return Current.Session(_sscSPIDCREFNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSPIDCREFNO) = value
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

    Shared Property _pFirstName() As String
        Get
            Return Current.Session(_sscFirstName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFirstName) = value
        End Set

    End Property
    Shared Property _pLastName() As String
        Get
            Return Current.Session(_sscLastName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLastName) = value
        End Set
    End Property
    Shared Property _pMiddleName() As String
        Get
            Return Current.Session(_sscMiddleName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMiddleName) = value
        End Set
    End Property
    Shared Property _pExtnName() As String
        Get
            Return Current.Session(_sscExtnName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscExtnName) = value
        End Set
    End Property

    Shared Property _pBirthDate() As String
        Get
            Return Current.Session(_sscBirthDate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBirthDate) = value
        End Set
    End Property
    Shared Property _pBirthPlace() As String
        Get
            Return Current.Session(_sscBirthPlace)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBirthPlace) = value
        End Set
    End Property

    Shared Property _pSetupGender() As String
        Get
            Return Current.Session(_sscSetupGender)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSetupGender) = value
        End Set
    End Property
    Shared Property _pSetupGenderDetail() As String
        Get
            Return Current.Session(_sscSetupGenderDetail)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSetupGenderDetail) = value
        End Set
    End Property

    Shared Property _pSetupCivilStatus() As String
        Get
            Return Current.Session(_sscSetupCivilStatus)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSetupCivilStatus) = value
        End Set
    End Property
    Shared Property _pSetupCivilStatusDetail() As String
        Get
            Return Current.Session(_sscSetupCivilStatusDetail)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSetupCivilStatusDetail) = value
        End Set
    End Property

    Shared Property _pSetupCitizenship() As String
        Get
            Return Current.Session(_sscSetupCitizenship)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSetupCitizenship) = value
        End Set
    End Property
    Shared Property _pSetupCitizenshipDetail() As String
        Get
            Return Current.Session(_sscSetupCitizenshipDetail)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSetupCitizenshipDetail) = value
        End Set
    End Property

    Shared Property _pIsActivated() As Boolean
        Get
            Return Current.Session(_sscIsActivated)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscIsActivated) = value
        End Set
    End Property
    Shared Property _pUsertype() As String
        Get
            Return Current.Session(_sscUsertype)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscUsertype) = value
        End Set
    End Property

    Shared Property _pResetPass() As Boolean
        Get
            Return Current.Session(_sscResetPass)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscResetPass) = value
        End Set
    End Property

#End Region

#Region "Routines"
    Public Shared Sub _pSubSessionClear()
        Try
            '----------------------------------
            'Avoid exposing the Password.
            'Just use the KeyToken to verify Access.

            _pIDNo = Nothing
            _pUserID = Nothing
            _pKeyToken = Nothing

            _pFirstName = Nothing
            _pLastName = Nothing
            _pMiddleName = Nothing
            _pExtnName = Nothing

            _pBirthDate = Nothing
            _pBirthPlace = Nothing

            _pSetupGender = Nothing
            _pSetupGenderDetail = Nothing

            _pSetupCivilStatus = Nothing
            _pSetupCivilStatusDetail = Nothing

            _pSetupCitizenship = Nothing
            _pSetupCitizenshipDetail = Nothing

            _pIsActivated = Nothing
            _pUsertype = Nothing
            _pOffice = Nothing

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSubPassCookieToSession()
        Try
            '----------------------------------

            _pSubSessionClear()
            _pIDNo = cCookieUser._pIDNo
            _pUserID = cCookieUser._pUserID
            _pKeyToken = cCookieUser._pKeyToken

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSubSessionFillUserDetails()
        Try
            '----------------------------------
            Dim _nDal As New cDalRegistered
            _nDal._pCxn = cGlobalConnections._pSqlCxn_OAIMS

            _nDal._pUserID = cSessionUser._pUserID
            _nDal._pSubSelectSpecificRecord()

            _pIDNo = _nDal._pIDNo
            _pKeyToken = _nDal._pKeyToken

            _pFirstName = _nDal._pFirstName
            _pLastName = _nDal._pLastName
            _pMiddleName = _nDal._pMiddleName
            _pExtnName = _nDal._pExtnName

            cSessionUser._pOffice = Trim(_nDal._pOffice)
            cSessionUser._pUserLevel = _nDal._pUserLevel

            _pBirthDate = _nDal._pBirthDate
            _pBirthPlace = _nDal._pBirthPlace

            _pSetupGender = _nDal._pSetupGender
            _pSetupGenderDetail = _nDal._pSetupGenderDetail

            _pSetupCivilStatus = _nDal._pSetupCivilStatus
            _pSetupCivilStatusDetail = _nDal._pSetupCivilStatusDetail

            _pSetupCitizenship = _nDal._pSetupCitizenship
            _pSetupCitizenshipDetail = _nDal._pSetupCitizenshipDetail

            _pIsActivated = CType(_nDal._pIsActivated, Boolean)
            _pUsertype = _nDal._puserType
            _nDal = Nothing

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
