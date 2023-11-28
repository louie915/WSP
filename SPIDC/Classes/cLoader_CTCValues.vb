Imports System.Data.SqlClient

Public Class cLoader_CTCValues
#Region "Variable Object"
    Private Shared _mSqlCon As New SqlConnection
    Private Shared _mSqlCmd As SqlCommand
    Private Shared _mDataTable As New DataTable
    Dim _mStrSql As String


#End Region

#Region "Property Object"
    Public Shared ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                Return _mDataTable
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public Shared Property _pSqlCon() As SqlConnection
        Get
            Try
                Return _mSqlCon
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
#End Region

#Region "Variable Field"
    Private Shared _mAmount As String
    Private Shared _mRealProperty As String
    Private Shared _mAddress As String
    Private Shared _mBirthDate As String
    Private Shared _mBirthPlace As String
    Private Shared _mCitizenship As String
    Private Shared _mCivilStatus As String
    Private Shared _mControlNo As String
    Private Shared _mCTC_Type As String
    Private Shared _mFirstName As String
    Private Shared _mGender As String
    Private Shared _mGross As String
    Private Shared _mIncome As String
    Private Shared _mLastName As String
    Private Shared _mMiddleName As String
    Private Shared _mOccupation As String
    Private Shared _mTIN As String
    Private Shared _mPenalty As String
    Private Shared _mHeight As String
    Private Shared _mWeight As String

    Private Shared _mBasicAmount As String
    Private Shared _mDelFee As String
    Private Shared _mTotAmount As String
    Private Shared _mBusKind As String
    Private Shared _mOrgKind As String
    Private Shared _mForYear As String
#End Region
#Region "Property Field"
    Public Shared Property _pHeight() As String
        Get
            Return _mHeight
        End Get
        Set(value As String)
            _mHeight = value
        End Set
    End Property
    Public Shared Property _pWeight() As String
        Get
            Return _mWeight
        End Get
        Set(value As String)
            _mWeight = value
        End Set
    End Property
    Public Shared Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(value As String)
            _mForYear = value
        End Set
    End Property
    Public Shared Property _pOrgKind() As String
        Get
            Return _mOrgKind
        End Get
        Set(value As String)
            _mOrgKind = value
        End Set
    End Property
    Public Shared Property _pBusKind() As String
        Get
            Return _mBusKind
        End Get
        Set(value As String)
            _mBusKind = value
        End Set
    End Property
    Public Shared Property _pTotAmount() As String
        Get
            Return _mTotAmount
        End Get
        Set(value As String)
            _mTotAmount = value
        End Set
    End Property
    Public Shared Property _pDelFee() As String
        Get
            Return _mDelFee
        End Get
        Set(value As String)
            _mDelFee = value
        End Set
    End Property
    Public Shared Property _pBasicAmount() As String
        Get
            Return _mBasicAmount
        End Get
        Set(value As String)
            _mBasicAmount = value
        End Set
    End Property

    Public Shared Property _pAmount() As String
        Get
            Return _mAmount
        End Get
        Set(value As String)
            _mAmount = value
        End Set
    End Property
    Public Shared Property _pPenalty() As String
        Get
            Return _mPenalty
        End Get
        Set(value As String)
            _mPenalty = value
        End Set
    End Property
    Public Shared Property _pRealProperty() As String
        Get
            Return _mRealProperty
        End Get
        Set(value As String)
            _mRealProperty = value
        End Set
    End Property
    Public Shared Property _pAddress() As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
        End Set
    End Property

    Public Shared Property _pBirthDate() As String
        Get
            Return _mBirthDate
        End Get
        Set(value As String)
            _mBirthDate = value
        End Set
    End Property

    Public Shared Property _pBirthPlace() As String
        Get
            Return _mBirthPlace
        End Get
        Set(value As String)
            _mBirthPlace = value
        End Set
    End Property

    Public Shared Property _pCitizenship() As String
        Get
            Return _mCitizenship
        End Get
        Set(value As String)
            _mCitizenship = value
        End Set
    End Property

    Public Shared Property _pCivilStatus() As String
        Get
            Return _mCivilStatus
        End Get
        Set(value As String)
            _mCivilStatus = value
        End Set
    End Property

    Public Shared Property _pControlNo() As String
        Get
            Return _mControlNo
        End Get
        Set(value As String)
            _mControlNo = value
        End Set
    End Property

    Public Shared Property _pCTC_Type() As String
        Get
            Return _mCTC_Type
        End Get
        Set(value As String)
            _mCTC_Type = value
        End Set
    End Property

    Public Shared Property _pFirstName() As String
        Get
            Return _mFirstName
        End Get
        Set(value As String)
            _mFirstName = value
        End Set
    End Property

    Public Shared Property _pGender() As String
        Get
            Return _mGender
        End Get
        Set(value As String)
            _mGender = value
        End Set
    End Property

    Public Shared Property _pGross() As String
        Get
            Return _mGross
        End Get
        Set(value As String)
            _mGross = value
        End Set
    End Property

    Public Shared Property _pIncome() As String
        Get
            Return _mIncome
        End Get
        Set(value As String)
            _mIncome = value
        End Set
    End Property

    Public Shared Property _pLastName() As String
        Get
            Return _mLastName
        End Get
        Set(value As String)
            _mLastName = value
        End Set
    End Property

    Public Shared Property _pMiddleName() As String
        Get
            Return _mMiddleName
        End Get
        Set(value As String)
            _mMiddleName = value
        End Set
    End Property

    Public Shared Property _pOccupation() As String
        Get
            Return _mOccupation
        End Get
        Set(value As String)
            _mOccupation = value
        End Set
    End Property

    Public Shared Property _pTIN() As String
        Get
            Return _mTIN
        End Get
        Set(value As String)
            _mTIN = value
        End Set
    End Property


#End Region
End Class
