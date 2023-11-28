#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
#End Region



Public Class cDalStreet

#Region "Variable Field"

    Private _mAdd As Boolean
    Private _mBRGYCODE As String
    Private _mDISTCODE As String
    Private _mSTRTCODE As String
    Private _mSTRTDESC As String

#End Region
#Region "Property Field"

    Public Property _pBRGYCODE() As String
        Get
            Return _mBRGYCODE
        End Get
        Set(value As String)
            _mBRGYCODE = value
        End Set
    End Property

    Public Property _pDISTCODE() As String
        Get
            Return _mDISTCODE
        End Get
        Set(value As String)
            _mDISTCODE = value
        End Set
    End Property

    Public Property _pSTRTCODE() As String
        Get
            Return _mSTRTCODE
        End Get
        Set(value As String)
            _mSTRTCODE = value
        End Set
    End Property

    Public Property _pSTRTDESC() As String
        Get
            Return _mSTRTDESC
        End Get
        Set(value As String)
            _mSTRTDESC = value
        End Set
    End Property


#End Region


#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataSet As DataSet
    Private _mSqlDataReader As SqlDataReader

#End Region

#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
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

#Region "Routine Command"


    Public Sub _pSubSelect(Optional _nColumns As String = "*", Optional _nCondition As String = Nothing, Optional ByRef _nRecCount As Integer = 0)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "SELECT " & _nColumns & " FROM STRTCODE order by STRTDESC ASC"



            '----------------------------------
            _mQuery = _nQuery & _nCondition

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region


End Class