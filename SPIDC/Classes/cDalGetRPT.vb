

#Region "Import"
Imports System.Data.SqlClient
#End Region

Public Class cDalGetRPT
#Region "Variable Data"

    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mDataSet As DataSet
    Private _mSqlDataReader As SqlDataReader

    Private _mfieldsWhere As String
    Private _mfields As String
    Private _mEmail As String

#End Region

#Region "Property Data"

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

    Public Sub _pSubSelect()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            _mEmail = _mUserID
            '----------------------------------                  
            _nQuery = _
                    "SELECT  " & _
                    "R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
                    "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
                    "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE  " & _
                    "FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO  " & _
                    "WHERE (R.REGION+R.PROV+R.CITY in (select REGION+PROV+CODE from city))   " & _
                    " and R.TDN in (select TDN from tdnperemail ) " & _
                    "union " & _
                    "SELECT  R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
                    "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
                    "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE  " & _
                    "FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO  " & _
                    "where R.region+R.PROV+R.CITY+R.tdn in  " & _
                    "(select region+PROV+CITY+reference_tdn " & _
                    "from PROPERTY_OTHERLAND_REF where region+PROV+CITY+tdn  in  " & _
                    "(SELECT  R.region+R.PROV+R.CITY+R.TDN   FROM  RPTMAST R  " & _
                    "WHERE (R.REGION+R.PROV+R.CITY in (select REGION+PROV+CODE from city))  )) " & _
                    " and R.TDN in (select TDN from tdnperemail WHERE EMAILADDRESS = '" & _mEmail & "') " & _
                    " order by R.PIN " & _
                    ""



            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Routine"



#End Region


End Class
