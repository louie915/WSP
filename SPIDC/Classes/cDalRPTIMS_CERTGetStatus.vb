



#Region "Import"

Imports System.Data.SqlClient
'Imports cReturnDataType

#End Region

Public Class cDalRPTIMS_CERTGetStatus

#Region "Variable Data"

    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

#End Region

#Region "Property Data"

    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlConnection = value
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
    Private _mUserAccountEmail As String
    Private _mCertificateFor As String
    Private _mBusinessAccountNo As String
    Private _mBusinessName As String
    Private _mCertificateCode As String
    Private _mCertificateName As String
    Private _mRequestDate As String
    Private _mRequestStatus As String
    Private _mRequestRefNo As String
#End Region

#Region "Property Field"
    Public Property _pUserAccountEmail As String
        Get
            Return _mUserAccountEmail
        End Get
        Set(value As String)
            _mUserAccountEmail = value
        End Set
    End Property

    Public Property _pCertificateFor As String
        Get
            Return _mCertificateFor
        End Get
        Set(value As String)
            _mCertificateFor = value
        End Set
    End Property

    Public Property _pCertificateCode As String
        Get
            Return _mCertificateCode
        End Get
        Set(value As String)
            _mCertificateCode = value
        End Set
    End Property
    Public Property _pBusinessAccountNo As String
        Get
            Return _mBusinessAccountNo
        End Get
        Set(value As String)
            _mBusinessAccountNo = value
        End Set
    End Property
    Public Property _pBusinessName As String
        Get
            Return _mBusinessName
        End Get
        Set(value As String)
            _mBusinessName = value
        End Set
    End Property
    Public Property _pCertificateName As String
        Get
            Return _mCertificateName
        End Get
        Set(value As String)
            _mCertificateName = value
        End Set
    End Property
    Public Property _pRequestDate As String
        Get
            Return _mRequestDate
        End Get
        Set(value As String)
            _mRequestDate = value
        End Set
    End Property
    Public Property _pRequestStatus As String
        Get
            Return _mRequestStatus
        End Get
        Set(value As String)
            _mRequestStatus = value
        End Set
    End Property

    Public Property _pRequestRefNo As String
        Get
            Return _mRequestRefNo
        End Get
        Set(value As String)
            _mRequestRefNo = value
        End Set
    End Property



#End Region

#Region "Routine Command"


    Public Sub _pSubSelect()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------       
            _nQuery = "SELECT * from Web_CertReq "

            '----------------------------------    

            If Not String.IsNullOrWhiteSpace(_mUserAccountEmail) Then
                _nWhere += "where [UserAccountEmail] = @_mUserAccountEmail "
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlConnection)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mUserAccountEmail) Then .AddWithValue("@_mUserAccountEmail", _mUserAccountEmail)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubInsert()
        Try

            Dim _nQuery As String = Nothing

            '----------------------------------
            _nQuery = _
             "INSERT INTO Web_CertReq " & _
             "(" & _
                IIf(String.IsNullOrEmpty(_mUserAccountEmail), "", " [UserAccountEmail]") & _
                IIf(String.IsNullOrEmpty(_mCertificateFor), "", ", [CertificateFor]") & _
                IIf(String.IsNullOrEmpty(_mBusinessAccountNo), "", ", [BusinessAccountNo]") & _
                IIf(String.IsNullOrEmpty(_mBusinessName), "", ", [BusinessName]") & _
                IIf(String.IsNullOrEmpty(_mCertificateCode), "", ", [CertificateCode]") & _
                IIf(String.IsNullOrEmpty(_mCertificateName), "", ", [CertificateName]") & _
                IIf(String.IsNullOrEmpty(_mRequestDate), "", ", [RequestDate]") & _
                IIf(String.IsNullOrEmpty(_mRequestStatus), "", ", [RequestStatus]") & _
                IIf(String.IsNullOrEmpty(_mRequestRefNo), "", ", [RequestRefNo]") & _
             ") " & _
             "VALUES " & _
             "(" & _
                IIf(String.IsNullOrEmpty(_mUserAccountEmail), "", " @_mUserAccountEmail") & _
                IIf(String.IsNullOrEmpty(_mCertificateFor), "", ", @_mCertificateFor") & _
                IIf(String.IsNullOrEmpty(_mBusinessAccountNo), "", ", @_mBusinessAccountNo") & _
                IIf(String.IsNullOrEmpty(_mBusinessName), "", ", @_mBusinessName") & _
                IIf(String.IsNullOrEmpty(_mCertificateCode), "", ", @_mCertificateCode") & _
                IIf(String.IsNullOrEmpty(_mCertificateName), "", ", @_mCertificateName") & _
                IIf(String.IsNullOrEmpty(_mRequestDate), "", ", @_mRequestDate") & _
                IIf(String.IsNullOrEmpty(_mRequestStatus), "", ", @_mRequestStatus") & _
                IIf(String.IsNullOrEmpty(_mRequestRefNo), "", ", @_mRequestRefNo") & _
             ") "

            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlConnection)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrEmpty(_mUserAccountEmail) Then .AddWithValue("@_mUserAccountEmail", _mUserAccountEmail)
                If Not String.IsNullOrEmpty(_mCertificateFor) Then .AddWithValue("@_mCertificateFor", _mCertificateFor)
                If Not String.IsNullOrEmpty(_mCertificateCode) Then .AddWithValue("@_mCertificateCode", _mCertificateCode)
                If Not String.IsNullOrEmpty(_mBusinessAccountNo) Then .AddWithValue("@_mBusinessAccountNo", _mBusinessAccountNo)
                If Not String.IsNullOrEmpty(_mBusinessName) Then .AddWithValue("@_mBusinessName", _mBusinessName)
                If Not String.IsNullOrEmpty(_mCertificateName) Then .AddWithValue("@_mCertificateName", _mCertificateName)
                If Not String.IsNullOrEmpty(_mRequestDate) Then .AddWithValue("@_mRequestDate", _mRequestDate)
                If Not String.IsNullOrEmpty(_mRequestStatus) Then .AddWithValue("@_mRequestStatus", _mRequestStatus)
                If Not String.IsNullOrEmpty(_mRequestRefNo) Then .AddWithValue("@_mRequestRefNo", _mRequestRefNo)

            End With

            _mSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



#End Region

#Region "Routine"



#End Region

End Class

