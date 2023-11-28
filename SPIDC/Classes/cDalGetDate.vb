
#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region
Public Class cDalGetDate

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mSqlCommand2 As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader
    Public Shared _Query As String
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

#Region "Variables Field"

#End Region

#Region "Properties Field"

#End Region

    '-----------TOMI START
    Function getYear() As String
        Try
            Dim _nQuery As String = "select YEAR(GETDATE()) AS [YEAR];"
            Dim STRYEAR As String = Nothing
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    STRYEAR = _nSqlDr.Item("YEAR")
                End If
            End Using
            Return STRYEAR
        Catch ex As Exception
            Return Now.Year
        End Try
    End Function

    Function _GetDate_MMddyyyy() As Date
        Dim strDate As String = Nothing
        Try
            Dim _nQuery As String = "SELECT " &
                                      "  RIGHT('00' + CAST(MONTH(GETDATE()) AS VARCHAR(2)), 2) + '/' +   " &
                                      "  RIGHT('00' + CAST(DAY(GETDATE()) AS VARCHAR(2)), 2) + '/' +      " &
                                      "  CAST(YEAR(GETDATE()) AS VARCHAR(4)) AS strDate;            "

            Dim STRYEAR As String = Nothing
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    strDate = _nSqlDr.Item("strDate")
                End If
            End Using
            Return strDate
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Function _GetDate(ByVal _format As String) As Date
        Dim strDate As String = Nothing
        Try
            Dim _nQuery As String = "select format(getdate(),'" & _format & "')strDate"
            Dim STRYEAR As String = Nothing
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    strDate = _nSqlDr.Item("strDate")
                End If
            End Using
            Return strDate
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Function _GetYear() As String
        Dim strYr As String = Nothing
        Try
            Dim _nQuery As String = "select year(GETDATE())strYr"
            Dim STRYEAR As String = Nothing
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    strYr = _nSqlDr.Item("strYr")
                End If
            End Using
            Return strYr
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Function _GetEndOfDay_2() As Date 'added 2023 09 21 louie
        Dim strDate As String = Nothing
        Try

            Dim _nQuery As String = " SELECT " & _
                                    " DATENAME(MONTH, SYSDATETIME())+ ' ' + RIGHT('0' + DATENAME(DAY, SYSDATETIME()), 2) + ', ' + DATENAME(YEAR, SYSDATETIME())  +  " & _
                                    " RIGHT(CONVERT(VARCHAR(25), ' 11:59 PM', 22),12 ) strDate "

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    strDate = _nSqlDr.Item("strDate")
                End If
            End Using
            Return strDate
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    Function _GetEndOfDay_x(ByVal _format As String) As Date
        Dim strDate As String = Nothing
        Try
            Dim _nQuery As String = "select format((DATEADD(DAY, DATEDIFF(DAY, '19000101', GETDATE()), '23:59:59')),'" & _format & "')strDate"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    strDate = _nSqlDr.Item("strDate")
                End If
            End Using
            Return strDate
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    '-------------TOMI END

End Class



