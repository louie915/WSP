#Region "Imports"
Imports System.Web.HttpContext
Imports System.Data.SqlClient
'Imports VS2015.Classes
Imports SPIDC.cReturnDataType

#End Region
Public Class cDalUserAccountManagement

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader


#End Region
#Region "Variables Data"

    Private _mCxn As SqlConnection = Nothing
    Private _mQry As String = Nothing
    Private _mCmd As SqlCommand = Nothing
    Private _mDt As DataTable = Nothing
    Private _mDr As SqlDataReader = Nothing
#End Region

#Region "Property Data"

    Public WriteOnly Property _pCxn() As SqlConnection
        Set(value As SqlConnection)
            _mCxn = value
        End Set
    End Property

    Public ReadOnly Property _pQry() As String
        Get
            Return _mQry
        End Get
    End Property

    Public ReadOnly Property _pCmd() As SqlCommand
        Get
            Return _mCmd
        End Get
    End Property

    Public ReadOnly Property _pDt() As DataTable
        Get
            Try
                '----------------------------------
                _mDt = New DataTable
                _mDt.Load(_mCmd.ExecuteReader)
                _mCmd.Dispose()
                Return _mDt
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property _pDr() As SqlDataReader
        Get
            Try
                '----------------------------------
                _mDr = _mCmd.ExecuteReader
                _mCmd.Dispose()
                Return _mDr
                '----------------------------------
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

#End Region

#Region "Variables Field"

    Private Const _mTableName As String = "Registered"

    Private _mIDNo As String  'Has Default Binding Property
    Private _mUserID As String

    Private _mDateRegistered As String 'Has Default Binding Property
    Private _mUserKey As String
    Private _mUserKeySalt As Byte() = Nothing

    Private _mLastName As String
    Private _mFirstName As String
    Private _mMiddleName As String
    Private _mExtnName As String

    Private _mBirthDate As String
    Private _mBirthPlace As String
    Private _mAddress As String

    Private _mProfession As String
    Private _mTIN As String

    Private _mSetupGender As String
    Private _mSetupGenderDetail As String

    Private _mCivilStatus As String

    Private _mSetupCivilStatus As String
    Private _mSetupCivilStatusDetail As String

    Private _mCitizenship As String


    Private _mSetupCitizenship As String
    Private _mSetupCitizenshipDetail As String

    Private _mIsActivated As Boolean = Nothing

    Private _mResident As Boolean = Nothing
    Private _mBarangay As String
    Private _mContactTel As String
    Private _mContactCp As String
    Private _mContactCpAlt As String
    Private _mHeight As String
    Private _mWeight As String

    Private _mOffice As String
    Private _mUserLevel As String

    Private _mKeyToken As String

    Private _mOrigIDNo As String
    Private _mUserType As String

    Private Const _sscPrefix As String = "cSessionLoader."
    Private Const _mSelected_IDNO As String = _sscPrefix & "_sscSelected_IDNO"
#End Region

#Region "Properties Field"
    Private Shared _mAdmin_RegLink As String
    Private Shared _mAdmin_SelectedOffice As String
    Public Shared Property _pAdmin_RegLink() As String
        Get
            Return _mAdmin_RegLink
        End Get
        Set(value As String)
            _mAdmin_RegLink = value
        End Set
    End Property

    Public Shared Property _pAdmin_SelectedOffice() As String
        Get
            Return _mAdmin_SelectedOffice
        End Get
        Set(value As String)
            _mAdmin_SelectedOffice = value
        End Set
    End Property
    Public Property _pIDNo() As String
        Get
            Return _mIDNo
        End Get
        Set(value As String)
            _mIDNo = value
        End Set
    End Property
    Public Property _pUserID() As String
        Get
            Return _mUserID
        End Get
        Set(value As String)
            _mUserID = value
        End Set
    End Property

    Public Property _pDateRegistered() As String
        Get
            Return _mDateRegistered
        End Get
        Set(value As String)
            _mDateRegistered = value
        End Set
    End Property
    Public Property _pUserKey() As String
        Get
            Return _mUserKey
        End Get
        Set(value As String)
            _mUserKey = value
        End Set
    End Property
    Public Property _pUserKeySalt() As Byte()
        Get
            Return _mUserKeySalt
        End Get
        Set(value As Byte())
            _mUserKeySalt = value
        End Set
    End Property

    Public Property _pLastName() As String
        Get
            Return _mLastName
        End Get
        Set(value As String)
            _mLastName = value
        End Set
    End Property
    Public Property _pFirstName() As String
        Get
            Return _mFirstName
        End Get
        Set(value As String)
            _mFirstName = value
        End Set
    End Property
    Public Property _pMiddleName() As String
        Get
            Return _mMiddleName
        End Get
        Set(value As String)
            _mMiddleName = value
        End Set
    End Property
    Public Property _pExtnName() As String
        Get
            Return _mExtnName
        End Get
        Set(value As String)
            _mExtnName = value
        End Set
    End Property

    Public Property _pBirthDate() As String
        Get
            Return _mBirthDate
        End Get
        Set(value As String)
            _mBirthDate = value
        End Set
    End Property
    Public Property _pBirthPlace() As String
        Get
            Return _mBirthPlace
        End Get
        Set(value As String)
            _mBirthPlace = value
        End Set
    End Property

    Public Property _pSetupGender() As String
        Get
            Return _mSetupGender
        End Get
        Set(value As String)
            _mSetupGender = value
        End Set
    End Property
    Public ReadOnly Property _pSetupGenderDetail() As String
        Get
            Return _mSetupGenderDetail
        End Get
    End Property
    Public Property _pCivilStatus() As String
        Get
            Return _mCivilStatus
        End Get
        Set(value As String)
            _mCivilStatus = value
        End Set
    End Property
    Public Property _pSetupCivilStatus() As String
        Get
            Return _mSetupCivilStatus
        End Get
        Set(value As String)
            _mSetupCivilStatus = value
        End Set
    End Property
    Public ReadOnly Property _pSetupCivilStatusDetail() As String
        Get
            Return _mSetupCivilStatusDetail
        End Get
    End Property
    Public Property _pCitizenship() As String
        Get
            Return _mCitizenship
        End Get
        Set(value As String)
            _mCitizenship = value
        End Set
    End Property

    Public Property _pSetupCitizenship() As String
        Get
            Return _mSetupCitizenship
        End Get
        Set(value As String)
            _mSetupCitizenship = value
        End Set
    End Property
    Public ReadOnly Property _pSetupCitizenshipDetail() As String
        Get
            Return _mSetupCitizenshipDetail
        End Get
    End Property

    Public Property _pIsActivated() As Boolean
        Get
            Return _mIsActivated
        End Get
        Set(value As Boolean)
            _mIsActivated = value
        End Set
    End Property
    Public Property _pKeyToken() As String
        Get
            Return _mKeyToken
        End Get
        Set(value As String)
            _mKeyToken = value
        End Set
    End Property
    Public Property _pUserType() As String
        Get
            Return _mUserType
        End Get
        Set(value As String)
            _mUserType = value
        End Set
    End Property

    Public Property _pProfession() As String
        Get
            Return _mProfession
        End Get
        Set(value As String)
            _mProfession = value
        End Set
    End Property
    Public Property _pTIN() As String
        Get
            Return _mTIN
        End Get
        Set(value As String)
            _mTIN = value
        End Set
    End Property
    Public Property _pResident() As String
        Get
            Return _mResident
        End Get
        Set(value As String)
            _mResident = value
        End Set
    End Property

    Public Property _pBarangay() As String
        Get
            Return _mBarangay
        End Get
        Set(value As String)
            _mBarangay = value
        End Set
    End Property
    Public Property _pContactTel() As String
        Get
            Return _mContactTel
        End Get
        Set(value As String)
            _mContactTel = value
        End Set
    End Property
    Public Property _pContactCp() As String
        Get
            Return _mContactCp
        End Get
        Set(value As String)
            _mContactCp = value
        End Set
    End Property
    Public Property _pContactCpAlt() As String
        Get
            Return _mContactCpAlt
        End Get
        Set(value As String)
            _mContactCpAlt = value
        End Set
    End Property
    Public Property _pHeight() As String
        Get
            Return _mHeight
        End Get
        Set(value As String)
            _mHeight = value
        End Set
    End Property
    Public Property _pWeight() As String
        Get
            Return _mWeight
        End Get
        Set(value As String)
            _mWeight = value
        End Set
    End Property
    Public Property _pOffice() As String
        Get
            Return _mOffice
        End Get
        Set(value As String)
            _mOffice = value
        End Set
    End Property
    Public Property _pUserLevel() As String
        Get
            Return _mUserLevel
        End Get
        Set(value As String)
            _mUserLevel = value
        End Set
    End Property
    Public Property _pAddress() As String
        Get
            Return _mAddress
        End Get
        Set(value As String)
            _mAddress = value
        End Set
    End Property
    Shared Property _pSelected_IDNO() As String
        Get
            Return Current.Session(_mSelected_IDNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_mSelected_IDNO) = value
        End Set
    End Property
#End Region

#Region "Propertiy Field Original"

    Public WriteOnly Property _pOrigIDNo() As String
        Set(value As String)
            _mOrigIDNo = value
        End Set
    End Property

#End Region

#Region "Routine Command"

    Public Sub _pSubGetTaxPayer()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT * from [Department] "

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelect()
        Try

            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------
            _nQuery = _
                "SELECT " & _
                " [R].[IDNo] " & _
                ", [R].[UserID] " & _
                ", CONVERT(VARCHAR, [R].[DateRegistered], 111) AS [DateRegistered] " & _
                ", [R].[UserKey] " & _
                ", [R].[UserKeySalt] " & _
                ", [R].[LastName] " & _
                ", [R].[FirstName] " & _
                ", [R].[MiddleName] " & _
                ", [R].[ExtnName] " & _
                ", CONVERT(VARCHAR, [R].[BirthDate], 111) AS [BirthDate] " & _
                ", [R].[BirthPlace] " & _
                ", [R].[Address]" & _
                ", [R].[Profession]" & _
                ", [R].[TIN]" & _
                ", [R].[Gender] " & _
                ", [R].[CivilStatus] " & _
                ", [R].[Citizenship] " & _
                ", [R].[Resident] " & _
                ", [R].[Barangay] " & _
                ", [R].[Contact_Tel] " & _
                ", [R].[Contact_Cp] " & _
                ", [R].[SecurityQ] " & _
                ", [R].[SecurityA] " & _
                ", [R].[Contact_Cp_Alt] " & _
                ", [R].[SetupGender] " & _
                ", [R].[SetupCivilStatus] " & _
                ", [R].[Office] " & _
                ", [R].[SetupCitizenship] " & _
                ", [R].[IsActivated] " & _
                ", [R].[USERTYPE] " & _
                ", [R].[KeyToken] " & _
                ", [R].[UserLevel] " & _
                ", [R].[Height] " & _
                ", [R].[Weight] " & _
                "FROM " & _
                "[" & _mTableName & "] [R] "

            '----------------------------------    
            _nWhere = "WHERE [IDNo] IN (SELECT [IDNo] FROM [" & _mTableName & "]) AND [R].[USERTYPE] <> 'TAXPAYER' and office is not null "

            If Not String.IsNullOrEmpty(_mIDNo) Then

                _nWhere += "AND [R].[IDNo] = @_mIDNo OR [R].[UserID] = @_mUserID "

            End If

            '----------------------------------
            _mQry = _nQuery & _nWhere

            '----------------------------------
            _mCmd = New SqlCommand(_mQry, _mCxn)

            With _mCmd.Parameters

                .AddWithValue("@_mIDNo", IIf(String.IsNullOrEmpty(_mIDNo), "", _mIDNo))
                .AddWithValue("@_mUserID", IIf(String.IsNullOrEmpty(_mUserID), "", _mUserID))

            End With

            ''----------------------------------
            'Dim _nQuery As String = Nothing

            ''----------------------------------
            '_nQuery = "select * from Registered where USERTYPE <> 'TAXPAYER' and office is not null"

            ''----------------------------------               

            ''----------------------------------            

            ''----------------------------------
            '_mCmd = New SqlCommand(_nQuery, _mCxn)



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsert()
        Try
            '----------------------------------
            'TODO:
            'Create sub procedure to generate UserKeySalt.

            '----------------------------------
            'Check if Primary Key(s) is not empty/ null/ whitespace.
            If String.IsNullOrEmpty(_mIDNo) And String.IsNullOrEmpty(_mUserID) Then
                Exit Sub
            End If

            '----------------------------------
            Dim _nQuery As String = Nothing

            '----------------------------------
            _nQuery = _
             "INSERT INTO " & _
             "[" & _mTableName & "] " & _
             "(" & _
                IIf(String.IsNullOrEmpty(_mIDNo), "", "[IDNo]") & _
                IIf(String.IsNullOrEmpty(_mUserID), "", ", [UserID]") & _
                    IIf(String.IsNullOrEmpty(_mDateRegistered), "", ", [DateRegistered]") & _
                    IIf(String.IsNullOrEmpty(_mUserKey), "", ", [UserKey]") & _
                    IIf((_mUserKeySalt) Is Nothing, "", ", [UserKeySalt]") & _
                IIf(String.IsNullOrEmpty(_mLastName), "", ", [LastName]") & _
                IIf(String.IsNullOrEmpty(_mFirstName), "", ", [FirstName]") & _
                IIf(String.IsNullOrEmpty(_mMiddleName), "", ", [MiddleName]") & _
                IIf(String.IsNullOrEmpty(_mExtnName), "", ", [ExtnName]") & _
                    IIf(String.IsNullOrEmpty(_mBirthDate), "", ", [BirthDate]") & _
                    IIf(String.IsNullOrEmpty(_mBirthPlace), "", ", [BirthPlace]") & _
                IIf(String.IsNullOrEmpty(_mSetupGender), "", ", [SetupGender]") & _
                IIf(String.IsNullOrEmpty(_mSetupCivilStatus), "", ", [SetupCivilStatus]") & _
                IIf(String.IsNullOrEmpty(_mSetupCitizenship), "", ", [SetupCitizenship]") & _
                    IIf((_mIsActivated) = Nothing, "", ", [IsActivated]") & _
                    IIf(String.IsNullOrEmpty(_mKeyToken), "", ", [KeyToken]") & _
             ") " & _
             "VALUES " & _
             "(" & _
                IIf(String.IsNullOrEmpty(_mIDNo), "", "@_mIDNo") & _
                IIf(String.IsNullOrEmpty(_mUserID), "", ", @_mUserID") & _
                    IIf(String.IsNullOrEmpty(_mDateRegistered), "", ", @_mDateRegistered") & _
                    IIf(String.IsNullOrEmpty(_mUserKey), "", ", @_mUserKey") & _
                    IIf((_mUserKeySalt) Is Nothing, "", ", @_mUserKeySalt") & _
                IIf(String.IsNullOrEmpty(_mLastName), "", ", @_mLastName") & _
                IIf(String.IsNullOrEmpty(_mFirstName), "", ", @_mFirstName") & _
                IIf(String.IsNullOrEmpty(_mMiddleName), "", ", @_mMiddleName") & _
                IIf(String.IsNullOrEmpty(_mExtnName), "", ", @_mExtnName") & _
                    IIf(String.IsNullOrEmpty(_mBirthDate), "", ", @_mBirthDate") & _
                    IIf(String.IsNullOrEmpty(_mBirthPlace), "", ", @_mBirthPlace") & _
                IIf(String.IsNullOrEmpty(_mSetupGender), "", ", @_mSetupGender") & _
                IIf(String.IsNullOrEmpty(_mSetupCivilStatus), "", ", @_mSetupCivilStatus") & _
                IIf(String.IsNullOrEmpty(_mSetupCitizenship), "", ", @_mSetupCitizenship") & _
                    IIf((_mIsActivated) = Nothing, "", ", @_mIsActivated") & _
                    IIf(String.IsNullOrEmpty(_mKeyToken), "", ", @_mKeyToken") & _
             ") "

            '----------------------------------
            _mQry = _nQuery

            '----------------------------------
            _mCmd = New SqlCommand(_mQry, _mCxn)

            With _mCmd.Parameters

                If Not String.IsNullOrEmpty(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)
                If Not String.IsNullOrEmpty(_mUserID) Then .AddWithValue("@_mUserID", _mUserID)

                If Not String.IsNullOrEmpty(_mDateRegistered) Then .AddWithValue("@_mDateRegistered", _mDateRegistered)
                If Not String.IsNullOrEmpty(_mUserKey) Then .AddWithValue("@_mUserKey", _mUserKey)
                If Not (_mUserKeySalt) Is Nothing Then .AddWithValue("@_mUserKeySalt", _mUserKeySalt)

                If Not String.IsNullOrEmpty(_mLastName) Then .AddWithValue("@_mLastName", _mLastName)
                If Not String.IsNullOrEmpty(_mFirstName) Then .AddWithValue("@_mFirstName", _mFirstName)
                If Not String.IsNullOrEmpty(_mMiddleName) Then .AddWithValue("@_mMiddleName", _mMiddleName)
                If Not String.IsNullOrEmpty(_mExtnName) Then .AddWithValue("@_mExtnName", _mExtnName)

                If Not String.IsNullOrEmpty(_mBirthDate) Then .AddWithValue("@_mBirthDate", _mBirthDate)
                If Not String.IsNullOrEmpty(_mBirthPlace) Then .AddWithValue("@_mBirthPlace", _mBirthPlace)

                If Not String.IsNullOrEmpty(_mSetupGender) Then .AddWithValue("@_mSetupGender", _mSetupGender)
                If Not String.IsNullOrEmpty(_mSetupCivilStatus) Then .AddWithValue("@_mSetupCivilStatus", _mSetupCivilStatus)
                If Not String.IsNullOrEmpty(_mSetupCitizenship) Then .AddWithValue("@_mSetupCitizenship", _mSetupCitizenship)

                If Not (_mIsActivated) = Nothing Then .AddWithValue("@_mIsActivated", _mIsActivated)
                If Not String.IsNullOrEmpty(_mKeyToken) Then .AddWithValue("@_mKeyToken", _mKeyToken)

            End With

            _mCmd.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdate()
        Try
            '----------------------------------
            'Check if Primary Key(s) is not empty/ null/ whitespace.
            If String.IsNullOrEmpty(_mSelected_IDNO) Then
                Exit Sub
            End If
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------
            _nQuery = _
             "UPDATE " & _
             "[" & _mTableName & "] " & _
             "SET " & _
                    IIf(String.IsNullOrEmpty(_mLastName), "", " [LastName] = '" & _mLastName & "'") & _
                    IIf(String.IsNullOrEmpty(_mFirstName), "", ", [FirstName] = '" & _mFirstName & "'") & _
                    ", [MiddleName] = '" & _mMiddleName & "'" & _
                    ", [ExtnName] = '" & _mExtnName & "'" & _
                IIf(String.IsNullOrEmpty(_mBirthDate), "", ", [BirthDate] = '" & _mBirthDate & "'") & _
                ", [BirthPlace] = '" & _mBirthPlace & "'" & _
                ", [Address] = '" & _mAddress & "'" & _
                ", [Profession] = '" & _mProfession & "'" & _
                 ", [TIN] = '" & _mTIN & "'" & _
                    IIf(String.IsNullOrEmpty(_mSetupGender), "", ", [Gender] = '" & _mSetupGender & "'") & _
                    IIf(String.IsNullOrEmpty(_mCivilStatus), "", ", [CivilStatus] = '" & _mCivilStatus & "'") & _
                    IIf(String.IsNullOrEmpty(_mCitizenship), "", ", [Citizenship] = '" & _mCitizenship & "'") & _
                     ", [Contact_CP] = '" & _mContactCp & "'" & _
                    ", [Contact_CP_Alt] = '" & _mContactCpAlt & "'" & _
                     ", [Contact_Tel] = '" & _mContactTel & "'" & _
                    IIf(String.IsNullOrEmpty(_mHeight), "", ", [Height] = '" & _mHeight & "'") & _
                    IIf(String.IsNullOrEmpty(_mWeight), "", ", [Weight] = '" & _mWeight & "'") & _
                    IIf(String.IsNullOrEmpty(_mUserLevel), "", ", [UserLevel] = '" & _mUserLevel & "'") & _
                     ", [Office] = '" & _mOffice & "'" & _
                " "

            '----------------------------------
            If Not String.IsNullOrEmpty(_mSelected_IDNO) Then

                _nWhere = "WHERE [IDNo] = '" & _pSelected_IDNO & "' "

            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            'Prevent Bulk Update.
            If _nWhere = Nothing Then
                Exit Sub
            End If

            '----------------------------------
            _mQry = _nQuery & _nWhere

            '----------------------------------
            _mCmd = New SqlCommand(_mQry, _mCxn)

            'With _mCmd.Parameters

            '    'Original Primary Key(s).
            '    'If Not String.IsNullOrEmpty(_mIDNo) Then .AddWithValue("@_mOrigIDNo", _mOrigIDNo)

            '    'New Values.
            '    'If Not String.IsNullOrEmpty(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)
            '    'If Not String.IsNullOrEmpty(_mUserID) Then .AddWithValue("@_mUserID", _mUserID)

            '    'If Not String.IsNullOrEmpty(_mDateRegistered) Then .AddWithValue("@_mDateRegistered", _mDateRegistered)
            '    'If Not String.IsNullOrEmpty(_mUserKey) Then .AddWithValue("@_mUserKey", _mUserKey)

            '    If Not String.IsNullOrEmpty(_mLastName) Then .AddWithValue("@_mLastName", _mLastName)
            '    If Not String.IsNullOrEmpty(_mFirstName) Then .AddWithValue("@_mFirstName", _mFirstName)
            '    If Not String.IsNullOrEmpty(_mMiddleName) Then .AddWithValue("@_mMiddleName", _mMiddleName)
            '    If Not String.IsNullOrEmpty(_mExtnName) Then .AddWithValue("@_mExtnName", _mExtnName)

            '    If Not String.IsNullOrEmpty(_mBirthDate) Then .AddWithValue("@_mBirthDate", _mBirthDate)
            '    If Not String.IsNullOrEmpty(_mBirthPlace) Then .AddWithValue("@_mBirthPlace", _mBirthPlace)
            '    If Not String.IsNullOrEmpty(_mAddress) Then .AddWithValue("@_mAddress", _mAddress)

            '    If Not String.IsNullOrEmpty(_mProfession) Then .AddWithValue("@_mProfession", _mProfession)
            '    If Not String.IsNullOrEmpty(_mTIN) Then .AddWithValue("@_mTIN", _mTIN)

            '    If Not String.IsNullOrEmpty(_mSetupGender) Then .AddWithValue("@_mSetupGender", _mSetupGender)
            '    If Not String.IsNullOrEmpty(_mSetupCivilStatus) Then .AddWithValue("@_mSetupCivilStatus", _mSetupCivilStatus)
            '    If Not String.IsNullOrEmpty(_mSetupCitizenship) Then .AddWithValue("@_mSetupCitizenship", _mSetupCitizenship)

            '    If Not String.IsNullOrEmpty(_mContactCp) Then .AddWithValue("@_mContactCp", _mContactCp)
            '    If Not String.IsNullOrEmpty(_mContactCpAlt) Then .AddWithValue("@_mContactCpAlt", _mContactCpAlt)
            '    If Not String.IsNullOrEmpty(_mContactTel) Then .AddWithValue("@_mContactTel", _mContactTel)
            '    If Not String.IsNullOrEmpty(_mHeight) Then .AddWithValue("@_mHeight", _mHeight)
            '    If Not String.IsNullOrEmpty(_mWeight) Then .AddWithValue("@_mWeight", _mWeight)
            '    If Not String.IsNullOrEmpty(_mUserLevel) Then .AddWithValue("@_mUserLevel", _mUserLevel)
            '    If Not String.IsNullOrEmpty(_mOffice) Then .AddWithValue("@_mOffice", _mOffice)

            '    'If Not (_mIsActivated) = Nothing Then .AddWithValue("@_mIsActivated", _mIsActivated)
            '    'If Not String.IsNullOrEmpty(_mKeyToken) Then .AddWithValue("@_mKeyToken", _mKeyToken)

            'End With

            _mCmd.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDelete()
        Try
            '----------------------------------
            'Check if Primary Key(s) is not empty/ null/ whitespace.
            If String.IsNullOrEmpty(_pSelected_IDNO) Then
                'Prevent Bulk Deletion.
                Exit Sub
            End If

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------
            _nQuery = _
                "DELETE FROM " & _
                "[" & _mTableName & "] " & _
                " "

            '----------------------------------
            _nWhere = "WHERE [IDNo] = '" & _pSelected_IDNO & "'"

            '----------------------------------
            _mQry = _nQuery & _nWhere

            '----------------------------------
            _mCmd = New SqlCommand(_mQry, _mCxn)

            _mCmd.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Routines"

    Public Sub _pSubSelectSpecificRecord()
        Try
            '----------------------------------
            'Check if Primary Key(s) is not empty/ null/ whitespace.
            If String.IsNullOrEmpty(_mIDNo) Then
                Exit Sub
            End If

            '----------------------------------
            _pSubSelect()

            Using _nDr As SqlDataReader = _pDr

                '----------------------------------
                'Declare Indexes for Fast Retrieval of Data.

                Dim _iIDNo As Integer = _nDr.GetOrdinal("IDNo")
                Dim _iUserID As Integer = _nDr.GetOrdinal("UserID")
                Dim _iKeyToken As Integer = _nDr.GetOrdinal("KeyToken")

                Dim _iTIN As Integer = _nDr.GetOrdinal("TIN")

                Dim _iFirstName As Integer = _nDr.GetOrdinal("FirstName")
                Dim _iLastName As Integer = _nDr.GetOrdinal("LastName")
                Dim _iMiddleName As Integer = _nDr.GetOrdinal("MiddleName")
                Dim _iExtnName As Integer = _nDr.GetOrdinal("ExtnName")

                Dim _iBirthDate As Integer = _nDr.GetOrdinal("BirthDate")
                Dim _iBirthPlace As Integer = _nDr.GetOrdinal("BirthPlace")

                Dim _iGender As Integer = _nDr.GetOrdinal("Gender")
                'Dim _iGenderDetail As Integer = _nDr.GetOrdinal("SetupGenderDetail")

                Dim _iCivilStatus As Integer = _nDr.GetOrdinal("CivilStatus")
                'Dim _iCivilStatusDetail As Integer = _nDr.GetOrdinal("SetupCivilStatusDetail")

                Dim _iCitizenship As Integer = _nDr.GetOrdinal("Citizenship")
                'Dim _iCitizenshipDetail As Integer = _nDr.GetOrdinal("SetupCitizenshipDetail")

                Dim _iIsActivated As Integer = _nDr.GetOrdinal("IsActivated")

                Dim _iUserType As Integer = _nDr.GetOrdinal("UserType")

                Dim _iOffice As Integer = _nDr.GetOrdinal("Office")
                Dim _iUserLevel As Integer = _nDr.GetOrdinal("UserLevel")
                Dim _iAddress As Integer = _nDr.GetOrdinal("Address")
                Dim _iProfession As Integer = _nDr.GetOrdinal("Profession")
                Dim _iResident As Integer = _nDr.GetOrdinal("Resident")
                Dim _iContact_Tel As Integer = _nDr.GetOrdinal("Contact_Tel")
                Dim _iBarangay As Integer = _nDr.GetOrdinal("Barangay")
                Dim _iContact_Cp As Integer = _nDr.GetOrdinal("Contact_Cp")
                Dim _iContact_Cp_Alt As Integer = _nDr.GetOrdinal("Contact_Cp_Alt")
                Dim _iHeight As Integer = _nDr.GetOrdinal("Height")
                Dim _iWeight As Integer = _nDr.GetOrdinal("Weight")

                '----------------------------------

                If _nDr.HasRows Then
                    _nDr.Read()

                    _mIDNo = _pYieldString(_nDr(_iIDNo))
                    _mUserID = _pYieldString(_nDr(_iUserID))
                    _mKeyToken = _pYieldString(_nDr(_iKeyToken))

                    _mTIN = _pYieldString(_nDr(_iTIN))

                    _mFirstName = _pYieldString(_nDr(_iFirstName))
                    _mLastName = _pYieldString(_nDr(_iLastName))
                    _mMiddleName = _pYieldString(_nDr(_iMiddleName))
                    _mExtnName = _pYieldString(_nDr(_iExtnName))

                    _mBirthDate = _pYieldString(_nDr(_iBirthDate))
                    _mBirthPlace = _pYieldString(_nDr(_iBirthPlace))

                    _mSetupGender = _pYieldString(_nDr(_iGender))
                    '_mSetupGenderDetail = _pYieldString(_nDr(_iGenderDetail))

                    _mCivilStatus = _pYieldString(_nDr(_iCivilStatus))
                    '_mSetupCivilStatusDetail = _pYieldString(_nDr(_iCivilStatusDetail))

                    _mCitizenship = _pYieldString(_nDr(_iCitizenship))
                    '_mSetupCitizenshipDetail = _pYieldString(_nDr(_iCitizenshipDetail))

                    _mIsActivated = CType(_nDr(_iIsActivated), Boolean)
                    _mUserType = _pYieldString(_nDr(_iUserType))


                    _mOffice = _pYieldString(_nDr(_iOffice))
                    _mUserLevel = _pYieldString(_nDr(_iUserLevel))
                    _mAddress = _pYieldString(_nDr(_iAddress))
                    _mProfession = _pYieldString(_nDr(_iProfession))
                    _mResident = _pYieldString(_nDr(_iResident))
                    _mContactTel = _pYieldString(_nDr(_iContact_Tel))
                    _mContactCp = _pYieldString(_nDr(_iContact_Cp))
                    _mContactCpAlt = _pYieldString(_nDr(_iContact_Cp_Alt))
                    _mBarangay = _pYieldString(_nDr(_iBarangay))
                    _mWeight = _pYieldString(_nDr(_iWeight))
                    _mHeight = _pYieldString(_nDr(_iHeight))

                End If

            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region
End Class
