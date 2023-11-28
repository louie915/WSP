
Imports System.Data.SqlClient
Imports VB.NET.Methods
Public Class cDalNumberToWords

#Region "Variables Data"
  Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Private _mValue As String
#End Region

#Region "Properties Data"

    Public Property _pValue() As String
        Get
            Return _mValue
        End Get
        Set(value As String)
            _mValue = value
        End Set
    End Property

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

    Public Sub _ConvertNumberToWords()
        Try

            _mQuery = "SELECT Result = dbo.fnNumberToWords(" & _mValue & ")"

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


        Catch ex As Exception

        End Try
    End Sub

End Class
