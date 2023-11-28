

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Web.HttpContext

#End Region

Public Class cDalDILG

#Region "Variables Data"

    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mSqlDataReader As SqlDataReader
    Public Shared _mDataTable As DataTable
    Public Shared _mRequestDate As String
    Public Shared _mRequestID As String
    Public Shared _mAlreadyRequested As Boolean
    Public Shared _mStatus As String
    Public Shared _mAcctNo As String
    Public Shared _mRemarks As String
    Public Shared _mInspectionDate As String
    Public Shared _mAssessedDate As String
    Public Shared _mAssessedBy As String
    Public Shared _mEmail As String
    Public Shared _mBusinessName As String

    Private _mDataSet As DataSet
    Private Shared _mDbCon As New SqlConnection
    Public Shared _mSqlCon As SqlConnection

#End Region

#Region "Properties Data"
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pEmail() As String
        Get
            Return _mEmail
        End Get
    End Property
    Public ReadOnly Property _pBusinessName() As String
        Get
            Return _mBusinessName
        End Get
    End Property
    Public ReadOnly Property _pAssessedBy() As String
        Get
            Return _mAssessedBy
        End Get
    End Property

    Public ReadOnly Property _pAssessedDate() As String
        Get
            Return _mAssessedDate
        End Get
    End Property
    Public ReadOnly Property _pInspectionDate() As String
        Get
            Return _mInspectionDate
        End Get
    End Property
    Public ReadOnly Property _pRemarks() As String
        Get
            Return _mRemarks
        End Get
    End Property
    Public ReadOnly Property _pAcctNo() As String
        Get
            Return _mAcctNo
        End Get
    End Property
    Public ReadOnly Property _pRequestDate() As String
        Get
            Return _mRequestDate
        End Get
    End Property

    Public ReadOnly Property _pRequestID() As String
        Get
            Return _mRequestID
        End Get
    End Property
    Public ReadOnly Property _pStatus() As String
        Get
            Return _mStatus
        End Get
    End Property
    Public ReadOnly Property _pAlreadyRequested() As Boolean
        Get
            Return _mAlreadyRequested
        End Get
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
#End Region

#Region "Properties Field"
#End Region

#Region "Properties Field Original"
#End Region

#Region "Routine Command"

    Public Sub _pSubInsertSafetySealRequest(RequestID, Email, RequestDate, acctno)

        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO SafetySealRequest([RequestID], [Email], [RequestDate], [acctno], [Status]) VALUES('" & RequestID & "','" & Email & "','" & RequestDate & "','" & acctno & "','PENDING')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
       
    End Sub


    Public Sub _pSubUpdateSafetySealRequest(RequestID, Email, acctno, Status, Remarks, InspectionDate)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update SafetySealRequest SET " & _
                "Status = '" & Status & "'," & _
                " Remarks = '" & Remarks & "'," & _
                " InspectionDate = '" & InspectionDate & "'" & _
                " where Email='" & Email & "' and RequestID='" & RequestID & "' and acctno='" & acctno & "' "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetBIN(Email)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT [BUSNAME] +'_'+ [ACCTNO] as 'BUSNAME_ACCTNO',[ACCTNO],[BUSNAME] FROM [BUSDETAIL] where EMAIL2='" & Email & "' "
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetBusName(BIN)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT BUSNAME FROM [BUSDETAIL] where ACCTNO='" & BIN & "' "
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mBusinessName = _nSqlDr("BUSNAME").ToString()
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetReqDetails(ReqID)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT * from SafetySealRequest where RequestID= '" & ReqID & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mRequestID = _nSqlDr("RequestID").ToString()
                        _mRequestDate = _nSqlDr("RequestDate").ToString()
                        _mAcctNo = _nSqlDr("acctno").ToString()
                        _mStatus = _nSqlDr("Status").ToString()
                        _mRemarks = _nSqlDr("Remarks").ToString()
                        _mInspectionDate = _nSqlDr("InspectionDate").ToString()
                        _mAssessedDate = _nSqlDr("AssessedDate").ToString()
                        _mAssessedBy = _nSqlDr("AssessedBy").ToString()
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGenerateID()
        Try
            Dim _nQuery As String = Nothing

            _nQuery = "SELECT  (select top 1 'SS' + (SELECT CONVERT(VARCHAR(6),GETDATE(),12))+'-' + RIGHT(CONCAT('00000', (select count(*)+1 from SafetySealRequest  where RequestID like '%'+(SELECT CONVERT(VARCHAR(6),GETDATE(),12))+'%')), 5)) as 'ReqID',  (SELECT GETDATE() ) as 'RequestDate'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mRequestID = _nSqlDr("ReqID").ToString()
                        _mRequestDate = _nSqlDr("RequestDate").ToString()
                    Loop
                End If
            End Using


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckIfAlreadyRequested(Email, acctno)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT * from [SafetySealRequest] where Email='" & Email & "' and acctno='" & acctno & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mAlreadyRequested = True
                        _mStatus = _nSqlDr("Status").ToString()
                    Loop
                Else
                    _mAlreadyRequested = False
                End If
                If _mStatus = "DENIED" Then _mAlreadyRequested = False
            End Using
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
