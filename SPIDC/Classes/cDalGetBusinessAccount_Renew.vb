

#Region "Import"
Imports System.Data.SqlClient
#End Region
Public Class cDalGetBusinessAccount_Renew

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
            Dim _nWhere As String = Nothing
            _mEmail = _mUserID
            '----------------------------------        
            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBP._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBP._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClOAIMS As New cDalGlobalConnectionsDefault
            _nClOAIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClOAIMS._pSetupGlobalConnectionsDatabases = "OAIMS"
            _nClOAIMS._pSubRecordSelectSpecific()

            Dim _nOIMSServerName As String = _nClOAIMS._pDBDataSource
            Dim _nOIMSDatabaseName As String = _nClOAIMS._pDBInitialCatalog

            _nQuery = _
                " SELECT " & _
                " ACCTNO,COMMNAME ,dbo.fn_RenewalStatus(ACCTNO) AS AcctStatus  " & _
                " FROM BUSMAST AS B WHERE EMAILADDR COLLATE DATABASE_DEFAULT = " & _
                " (SELECT Distinct [UserID] COLLATE DATABASE_DEFAULT FROM [" & _nOIMSServerName & "].[" & _nOIMSDatabaseName & "].dbo.Registered where [UserID] = '" & _mEmail & "') " & _
                " and (STATCODE ='R' OR YEAR(DATE_ESTA) < (Select datepart(year,getdate()) AS SvrYear)) " & _
                " AND ACCTNO COLLATE DATABASE_DEFAULT NOT IN " & _
                " (Select ACCTNO from [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.BUSMAST where ISNULL(REMARKS,'') <> '' " & _
                " AND STATCODE ='R') " & _
                " "
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
