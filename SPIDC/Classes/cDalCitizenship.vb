#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region



Public Class cDalCitizenship

#Region "Variable Field"

    Private Shared _mAdd As Boolean
    Private Shared _mCTZNCODE As String
    Private Shared _mCTZNDESC As String

#End Region
#Region "Property Field"

    Public Shared Property _pCTZNCODE() As String
        Get
            Return _mCTZNCODE
        End Get
        Set(value As String)
            _mCTZNCODE = value
        End Set
    End Property

    Public Shared Property _pCTZNDESC() As String
        Get
            Return _mCTZNDESC
        End Get
        Set(value As String)
            _mCTZNDESC = value
        End Set
    End Property


#End Region


#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataset As DataSet
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
    Public ReadOnly Property _pDataset() As DataSet
        Get
            Try
                '----------------------------------
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataset = New DataSet
                _nSqlDataAdapter.Fill(_mDataset)

                Return _mDataset
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
            _nQuery = "SELECT " & _nColumns & " FROM CTZNCODE "

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
