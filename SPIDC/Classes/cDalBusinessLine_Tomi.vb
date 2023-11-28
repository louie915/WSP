

#Region "Import"
Imports System.Data.SqlClient
#End Region
Public Class cDalBusinessLine_Tomi

#Region "Variable Data"

    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mDataSet As DataSet
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


    Private _mGetBusLine As String
    Private _mSelCatCode As String

#End Region

#Region "Property Field"


    Public Property _pGetBusLine As String
        Get
            Return _mGetBusLine
        End Get
        Set(value As String)
            _mGetBusLine = value
        End Set
    End Property

    Public Property _pSelCatCode As String
        Get
            Return _mSelCatCode
        End Get
        Set(value As String)
            _mSelCatCode = value
        End Set
    End Property

#End Region

#Region "Routine Command"

    Public Sub _pSubSelect(ByVal _nCond As String)
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    
            'If _mGetBusLine = "BUSCODE" Then _nQuery = "select top(1000) description,BUS_CODE as BUSCODE from BUSCODE order by DESCRIPTION asc"
            If _mGetBusLine = "BUSCODE" Then _nQuery = "select top(4000) DESCRIPTION,CATEGORY + '_' + BUS_CODE as CATEGORY_BUSCODE from BUSCODE " & _nCond & " order by DESCRIPTION asc"
            If _mGetBusLine = "CATCODE" Then _nQuery = "select * from CATCODE"
            '---------------------------------- 

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            _mSqlCommand.CommandTimeout = 0
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Routine"



#End Region
End Class
