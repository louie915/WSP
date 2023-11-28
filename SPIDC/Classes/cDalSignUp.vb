

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Web.HttpContext

#End Region

Public Class cDalSignUp

#Region "Variables Data"
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mSqlDataReader As SqlDataReader
    Private _mDataSet As DataSet
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

    Public ReadOnly Property _pDataSet() As DataSet
        Get
            Try
                '----------------------------------

                Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
                _mDataSet = New DataSet
                _nSqlDataAdapter.Fill(_mDataSet)
                Return _mDataSet
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
    Private _mEventID As String
    Private _mEventTime As String
#End Region

#Region "Properties Field"
    Public Property _pEventID As String
        Get
            Return _mEventID
        End Get
        Set(value As String)
            _mEventID = value
        End Set
    End Property

    Public Property _pEventTime As String
        Get
            Return _mEventTime
        End Get
        Set(value As String)
            _mEventTime = value
        End Set
    End Property

#End Region


#Region "Routine Command"

    Public Sub _pSubSelectImage(ByVal Email As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [Registered] "
            _nWhere = " where UserID =  '" & Email & "'"

            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Exists = True
                Else
                    Exists = False

                End If
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
  
    Public Sub _pSubInsertAppointment(Email, TransType, AppDate, AppTime, AppId, Owner, AcctID, Status, Remarks, Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO [Appointment]([Email], [TransType], [AppDate], [Slot], [Remarks],[AppID],[Owner],[AcctID],[Status],[Office],[TransDate]) VALUES('" & Email & "','" & TransType & "','" & AppDate & "','" & AppTime & "','" & Remarks & "','" & AppId & "','" & Owner & "','" & AcctID & "','" & Status & "','" & Office & "','" & Date.Now & "')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdateAppStatus(Status, AppID, ServedBy, Remarks)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "update [Appointment] set  Status = '" & Status & "', ServedBy = '" & ServedBy & "', Remarks = '" & Remarks & "' where AppID='" & AppID & "'"

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region

End Class
