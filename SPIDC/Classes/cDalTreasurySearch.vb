

#Region "Import"
Imports System.Data.SqlClient
#End Region

Public Class cDalTreasurySearch





#Region "Variable Data"

    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mDataSet As DataSet
    Private _mSqlDataReader As SqlDataReader

    Private _mfieldsWhere As String
    Private _mfields As String
    Private _mEmail As String

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

    Public ReadOnly Property _pDataSet() As DataSet
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataSet = New DataSet
                _nSqlDataAdapter.Fill(_mDataSet)
                Return _mDataSet
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


    Private _mUserID As String


#End Region

#Region "Property Field"


    Public Property _pUserID As String
        Get
            Return _mUserID
        End Get
        Set(value As String)
            _mUserID = value
        End Set
    End Property

#End Region

#Region "Routine Command"

    Public Sub _pSubSelect()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            _mEmail = _mUserID
            '----------------------------------                  
            _nQuery = _
           " SELECT * from BUSMAST " & _
           " where REMARKS = 'Paid/For Treasury Verification'"
            ' "select * from BUSMAST where REMARKS = 'Paid/For Treasury Verification' "

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Routine"



#End Region




End Class
