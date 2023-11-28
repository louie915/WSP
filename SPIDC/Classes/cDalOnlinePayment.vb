


#Region "Import"
Imports System.Data.SqlClient
#End Region
Public Class cDalOnlinePayment

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
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

#Region "Variable Field"


    Private _mUserID As String


#End Region

#Region "Property Field"


    Public Property _pUserID As String
        Get
            Return _mUserID
        End Get
        Set(value As String)
            _mUserID = value
        End Set
    End Property

#End Region

#Region "Routine Command"

    Public Sub _pSubSelectGATEWAY()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT CASE WHEN STATUS=1 THEN 'ENABLED' WHEN STATUS=0 THEN 'DISABLED' ELSE 'N/A' END AS STATUS2, GatewayName,code, isnull(GATEWAYFEE,'0')GATEWAYFEE FROM ONLINEPAYMENTSETUP"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ModifyGateway(ByVal code As String, ByVal GW_Name As String, ByVal GW_Fee As String, ByVal GW_Status As String)
        Try
            IIf(GW_Status.ToUpper = "ENABLED", 1, 0)
            Dim _nQuery As String = "Update OnlinePaymentSetup set GatewayName='" & GW_Name & "',GatewayFee='" & GW_Fee & "',Status=" & IIf(GW_Status = "ENABLED", 1, 0) & " where code='" & code & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try

    End Sub
     


#End Region

#Region "Routine"



#End Region





End Class
