
#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region

Public Class cDalSetupWebEmailMaster

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
    Private _mEmailMaster As String
    Private _mPassword As String
    Private _mEmailCC As String
    Private _mEmailBCC As String
#End Region

#Region "Properties Field"
    Public Property _pEmailMaster As String
        Get
            Return _mEmailMaster
        End Get
        Set(value As String)
            _mEmailMaster = value
        End Set
    End Property
    Public Property _pPassword As String
        Get
            Return _mPassword
        End Get
        Set(value As String)
            _mPassword = value
        End Set
    End Property
    Public Property _pEmailCC As String
        Get
            Return _mEmailCC
        End Get
        Set(value As String)
            _mEmailCC = value
        End Set
    End Property
    Public Property _pEmailBCC As String
        Get
            Return _mEmailBCC
        End Get
        Set(value As String)
            _mEmailBCC = value
        End Set
    End Property
#End Region

#Region "Properties Field Original"



#End Region

#Region "Routine Command"
    Public Sub _pSubSelectGetEmailMaster()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------          
            _nQuery = _
                "select * from SetupWebEmailMaster  "

            '_nWhere = "where UserType= 'BPLO' "

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


    Public Sub _pSubUpdate()    ' @Added 20170410
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery =
            "Update " & _
            "SetupWebEmailMaster " & _
            "set EmailAddress = '" & _mEmailMaster & "', " & _
            "[Password] = '" & _mPassword & "', " & _
            "[EmailCC] = '" & _mEmailCC & "', " & _
            "[EmailBCC] = '" & _mEmailBCC & "' " & _
            " "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlConnection)

            _mSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Routines"

    Public Sub _pSubGetEmailMaster()
        Try
            '----------------------------------

            _pSubSelectGetEmailMaster()

            Dim _nDRead As SqlDataReader = _mSqlCommand.ExecuteReader

            'Using _nDRead As SqlDataReader = _pSqlDataReader

            '----------------------------------
            'Indexes
            With _nDRead
                Dim _iEmailMaster As Integer = .GetOrdinal("EmailAddress")
                Dim _iPassword As Integer = .GetOrdinal("Password")
                Dim _iEmailCC As Integer = .GetOrdinal("EmailCC")
                Dim _iEmailBCC As Integer = .GetOrdinal("EmailBCC")


                '----------------------------------
                Dim _nClassReturnTypes As New ClassReturnTypes
                With _nClassReturnTypes

                    If _nDRead.HasRows Then
                        Do While _nDRead.Read

                            _mEmailMaster = (._pReturnString(_nDRead(_iEmailMaster)))
                            _mPassword = (._pReturnString(_nDRead(_iPassword)))
                            _mEmailCC = (._pReturnString(_nDRead(_iEmailCC)))
                            _mEmailBCC = (._pReturnString(_nDRead(_iEmailBCC)))

                        Loop

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
