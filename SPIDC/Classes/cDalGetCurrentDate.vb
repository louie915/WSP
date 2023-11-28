#Region "Imports"
Imports System.Data.SqlClient
#End Region

Public Class cDalGetCurrentDate

#Region "Variable Object"
    Private _mSqlCon As New SqlConnection
    Private _mSqlCmd As SqlCommand
    Private _mDataTable As New DataTable
    Private _mQuery As String = Nothing
#End Region

#Region "Property Object"
    Public ReadOnly Property _pDataTable() As DataTable
        Get
            Try
                Return _mDataTable
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public Property _pSqlCon() As SqlConnection
        Get
            Try
                Return _mSqlCon
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pQuery() As String
        Get
            Return _mQuery
        End Get
    End Property
#End Region

    Public Function _FnGetCurrentDate() As String
        _FnGetCurrentDate = Nothing
        Try

            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT GETDATE() as xResult "
            '----------------------------------   
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCmd = New SqlCommand(_mQuery, _mSqlCon)
            'set paramater Success
            '_mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            '_mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output

            'Execute and Read the content
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                        _FnGetCurrentDate = _nSqlDr.Item("xResult").ToString
                    Loop
                End If
            End Using

            _nSqlDataAdapter.Dispose()

            '----------------------------------

        Catch ex As Exception

        End Try

    End Function

End Class
