#Region "Imports"
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Mail
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region


Public Class cDalGetModules

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
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

#Region "Variables Field"

#End Region

#Region "Properties Field"
   

#End Region

#Region "Routine Command"

    Public Function _pSubGetAvailableModules(ByVal SubModule As String) As Boolean
        Try
            Dim _nQuery As String = Nothing
            Dim result As Boolean
            _nQuery = _
           "select Status from ModuleSetup where SubModule='" & SubModule & "' and Status=1"
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_CR)
            '----------------------------------
            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader

                Try
                    While _nSqlDataReader.Read()
                        If _nSqlDataReader.HasRows Then
                            result = True
                        Else
                            result = False
                        End If
                    End While
                Finally
                    ' Always call Close when done reading.
                    _nSqlDataReader.Close()
                End Try

            End Using
            _mSqlCommand.Dispose()
            Return result
        Catch ex As Exception
            _mSqlCommand.Dispose()
        End Try

    End Function

    Public Function _pSubGetFBChatID() As String
        Try
            '----------------------------------       
            Dim _nQuery As String = Nothing
            _nQuery = "select Description from ModuleSetup where SubModule='FB_CHAT' and Status=1"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iDescription As Integer = .GetOrdinal("Description")
                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                Return ._pReturnString(_nSqlDataReader(_iDescription))
                            Loop
                        Else
                            Return 0
                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Function


  

#End Region
End Class
