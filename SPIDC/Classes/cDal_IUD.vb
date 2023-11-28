#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region


Public Class cDal_IUD
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
    Private _mAction As String
    Private _mSelect As String
    Private _mSelect1 As String
    Private _mCondition As String
    Private _mCondition1 As String
    Private _mSortBy As String
    Private _mFieldName As String
#End Region

#Region "Property Field"
    Public Property _pAction() As String
        Get
            Return _mAction
        End Get
        Set(value As String)
            _mAction = value
        End Set
    End Property

    Public Property _pSelect() As String
        Get
            Return _mSelect
        End Get
        Set(value As String)
            _mSelect = value
        End Set
    End Property

    Public Property _pSelect1() As String
        Get
            Return _mSelect1
        End Get
        Set(value As String)
            _mSelect1 = value
        End Set
    End Property

    Public Property _pCondition() As String
        Get
            Return _mCondition
        End Get
        Set(value As String)
            _mCondition = value
        End Set
    End Property

    Public Property _pCondition1() As String
        Get
            Return _mCondition1
        End Get
        Set(value As String)
            _mCondition1 = value
        End Set
    End Property

    Public Property _pSortBy() As String
        Get
            Return _mSortBy
        End Get
        Set(value As String)
            _mSortBy = value
        End Set
    End Property

    Public Property _pFieldName() As String
        Get
            Return _mFieldName
        End Get
        Set(value As String)
            _mFieldName = value
        End Set
    End Property

#End Region

#Region "Routine"

    Public Sub _pExec(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nOutput As String = ""
            Dim _nStrSql As String

            _nStrSql = "EXEC [sp_IUD_WEB] " & _
              "@Action = '" & _mAction & "' " & _
             ",@Select = '" & _mSelect & "'" & _
             ",@Select1 = N'" & _mSelect1 & "'" & _
             ",@Where = N'" & _mCondition & "'" & _
             ",@Where1 = N'" & _mCondition1 & "'" & _
             ",@Orderby = N'" & _mSortBy & "'" & _
             ",@FieldName = N'" & _mFieldName & "'" & _
             ",@Successful = @Successful output " & _
             ",@ErrMsg = @ErrMsg output  "

            _mSqlCmd = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            _mSqlCmd.Parameters.Add("@Successful", SqlDbType.Bit)
            _mSqlCmd.Parameters("@Successful").Direction = ParameterDirection.Output
            'set paramater Error
            _mSqlCmd.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            _mSqlCmd.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content
            _mSqlCmd.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCmd.ExecuteReader
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            'Get values of parameter output
            _nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            _nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCmd.Dispose()
        Catch ex As Exception
            _nSuccessful = False
            _nErrMsg = ex.Message
        End Try
    End Sub

#End Region

End Class
