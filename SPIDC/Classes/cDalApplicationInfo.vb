#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region


Public Class cDalApplicationInfo

#Region "Variable Object"
    Private _mSqlCon As New SqlConnection
    Private _mSqlCmd As SqlCommand
    Private _mDataTable As New DataTable
    Dim _mStrSql As String
#End Region

#Region "Property Object"
    Public ReadOnly Property _pDataTable() As DataTable
        Get

            Try
                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCmd)
                _mDataTable = New DataTable
                _nSqlDataAdapter.Fill(_mDataTable)

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

#Region "Variable Field"
    Private _mAcctNo As String
    Private _mForYear As String
    Private _mLiveSvr As String
    Private _mLiveDb As String

#End Region

#Region "Property Field"
    Public Property _pAcctNo() As String
        Get
            Return _mAcctNo
        End Get
        Set(value As String)
            _mAcctNo = value
        End Set
    End Property

    Public Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(value As String)
            _mForYear = value
        End Set
    End Property

    Public Property _pLiveSvr() As String
        Get
            Return _mLiveSvr
        End Get
        Set(value As String)
            _mLiveSvr = value
        End Set
    End Property

    Public Property _pLiveDb() As String
        Get
            Return _mLiveDb
        End Get
        Set(value As String)
            _mLiveDb = value
        End Set
    End Property

#End Region


#Region "Routine"

    Public Sub _pExec(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = Nothing)
        Try
            _nSuccessful = True

            Dim _nOutput As String = ""
            Dim _nStrSql As String

            _nStrSql = "EXEC [sp_ApplicationInfo] " & _
              "@Acctno = '" & _mAcctNo & "' " & _
             ",@ForYear = '" & _mForYear & "'" & _
             ",@LiveSvr = N'" & _mLiveSvr & "'" & _
             ",@LiveDb = N'" & _mLiveDb & "'"

            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'Execute and Read the content
            Using _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using

            _mSqlCmd.Dispose()

        Catch ex As Exception
            _nSuccessful = False
            _nErrMsg = ex.Message
        End Try
    End Sub

    Public Sub _pExec2(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = Nothing)
        Try
            _nSuccessful = True

            Dim _nOutput As String = ""
            Dim _nStrSql As String

            _nStrSql = "EXEC [sp_DITC_ApplicationInfo] " & _
              "@Acctno = '" & _mAcctNo & "' " & _
             ",@ForYear = '" & _mForYear & "'" & _
             ",@LiveSvr = N'" & _mLiveSvr & "'" & _
             ",@LiveDb = N'" & _mLiveDb & "'"

            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'Execute and Read the content
            Using _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using

            _mSqlCmd.Dispose()
        Catch ex As Exception
            cDalLogEvent._pSubLogError(ex)
            _nSuccessful = False
            _nErrMsg = ex.Message
        End Try
    End Sub

#End Region



End Class
