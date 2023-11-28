


#Region "Import"
Imports System.Data.SqlClient
#End Region
Public Class cDalUpdates
#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
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
#End Region
#Region "Property Field"


#End Region
#Region "Routine Command"
    Public Sub CreateTable(ByVal tblName As String)
        Try
            Dim _nQuery As String = Nothing
            If tblName.ToUpper = "CAROUSEL" Then
                _nQuery = "CREATE TABLE [dbo].[Carousel]([FileName] [nvarchar](max) NULL,	[FileType] [nvarchar](max) NULL,	[FileData] [varbinary](max) NULL,	[FileSize] [nvarchar](max) NULL)"
            ElseIf tblName.ToUpper = "POLICY" Then
                _nQuery = "CREATE TABLE [dbo].[POLICY]([Title] [nvarchar](max) NULL,	[Content] [nvarchar](max) NULL)"
            ElseIf tblName.ToUpper = "ANNOUNCEMENT" Then
                _nQuery = "CREATE TABLE [dbo].[ANNOUNCEMENT]([Title] [nvarchar](max) NULL,	[Content] [nvarchar](max) NULL,	[DATE] [nvarchar](max) NULL,[STATUS] [bit])"
            End If
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AlterTableAutoNum(ByVal tblName As String, ByVal ParamName As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "ALTER TABLE dbo." & tblName & "   ADD " & ParamName & " INT IDENTITY       CONSTRAINT PK_" & tblName & " PRIMARY KEY CLUSTERED"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Function isExists(ByVal tblName As String) As Boolean
        Dim Exists As Boolean = False
        Try
            '----------------------------------      
            Dim _nQuery As String = "If exists (select * from sys.tables where name = '" & tblName.ToUpper & "')    select '1' as [Exists]	else (select '0' as [Exists])"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlCon.Open()
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    Exists = _mSqlDataReader("Exists")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception
            Exists = False
        End Try
        Return Exists
    End Function



#End Region
#Region "Routine"



#End Region





End Class
