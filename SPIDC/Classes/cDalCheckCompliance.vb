#Region "Imports"

Imports System.Data.SqlClient

#End Region


Public Class cDalCheckCompliance


#Region "Variable Object"
    Private _mSqlCon As New SqlConnection
    Private _mSqlCmd As SqlCommand
    Private _mDataTable As New DataTable
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
#End Region

#Region "Variables"



#End Region

#Region "Property Field"

   

#End Region

#Region "Routines"

    Public Function _FnCheckCompliance(ByVal _nControlNo As String, ByVal _nStatCode As String, ByVal _nLiveSvr As String, ByVal _nLiveDB As String) As Boolean
        _FnCheckCompliance = False
        Try
            Dim _nErrMsg As String = ""
            'Dim _nOutput As String = ""
            Dim _nStrSql As String
            Dim _nSelectCond As String = ""
            'Initialize String SQL
            '_nSelectCond = Replace(_nCondition, "'", "''")
            _nStrSql = "exec [sp_CheckCompliance]" & _
                            "@ControlNo = N'" & _nControlNo & "' " & _
                            ",@StatCode = N'" & _nStatCode & "' " & _
                            ",@LiveSvr = N'" & _nLiveSvr & "' " & _
                            ",@LiveDB = N'" & _nLiveDB & "' "


            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'Execute and Read the content
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nStrSql, _mSqlCon) '_gDBCon
            _mDataTable.Clear()
            _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        Return _nSqlDr.Item("Result")
                    Loop
                End If
            End Using

            'Get values of parameter output

            _mSqlCmd.Dispose()

        Catch ex As Exception
            Return False

        End Try

    End Function
#End Region


End Class
