
#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region

Public Class cDalGetTreasurerEmail

#Region "Variables Data"
    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader



#End Region

#Region "Properties Data"
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
    Private _mArrayListBploEmail As ArrayList

#End Region

#Region "Properties Field"
    Public Property _pArrayListBploEmail As ArrayList
        Get
            Return _mArrayListBploEmail
        End Get
        Set(value As ArrayList)
            _mArrayListBploEmail = value
        End Set
    End Property

#End Region

#Region "Properties Field Original"



#End Region

#Region "Routine Command"
    Public Sub _pSubSelectGetEmailTreasurer()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------          
            _nQuery = _
                "select USERID from registered  "

            _nWhere = "where UserType= 'TREASURY' "

            '----------------------------------
            _mQuery = _nQuery & _nWhere & _
                ""

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlConnection)

            'With _mSqlCommand.Parameters
            '    If Not String.IsNullOrWhiteSpace(_mAccountNo) Then .AddWithValue("@_mAccountNo", _mAccountNo)
            'End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Routines"



    Public Sub _pSubGetEmailTreasurer()
        Try
            '----------------------------------

            _pSubSelectGetEmailTreasurer()

            Dim _nDRead As SqlDataReader = _mSqlCommand.ExecuteReader

            'Using _nDRead As SqlDataReader = _pSqlDataReader

            '----------------------------------
            'Indexes
            With _nDRead
                Dim _iEmail As Integer = .GetOrdinal("USERID")


                '----------------------------------
                Dim _nClassReturnTypes As New ClassReturnTypes
                With _nClassReturnTypes
                    Dim _nArrayListBploEmail As New ArrayList
                    If _nDRead.HasRows Then
                        Do While _nDRead.Read

                            _nArrayListBploEmail.Add(._pReturnString(_nDRead(_iEmail)))


                        Loop
                        _mArrayListBploEmail = _nArrayListBploEmail
                    End If

                End With
            End With

            _nDRead.Close()
            _mSqlCommand.Dispose()
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
