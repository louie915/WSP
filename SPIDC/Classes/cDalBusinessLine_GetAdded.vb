

#Region "Import"

Imports System.Data.SqlClient

#End Region

Public Class cDalBusinessLine_GetAdded

#Region "Variable Data"

    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

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
    Private _mAcctNo As String
#End Region

#Region "Property Field"

    Public Property _pAcctNo As String
        Get
            Return _mAcctNo
        End Get
        Set(value As String)
            _mAcctNo = value
        End Set
    End Property
#End Region

#Region "Routine Command"

    Public Sub _pSubSelect()
        Try
            '----------------------------------

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nQuery As String = Nothing
            Dim _nTable As String = "[" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.[BUSCODE]"

            '----------------------------------                
            _nQuery = "Select REPLACE(REPLACE(BC.DESCRIPTION,'[',''),']','') DESCRIPTION,BL.BUS_CODE,BL.FORYEAR, BL.AREA,BL.CAPITAL,BL.GROSSREC " & _
                ", CASE when ISNULL(STATCODE,'N') = 'N' then 'NEW' else 'RENEW'  end STATCODE " & _
                "from BUSLINE BL INNER JOIN " & _nTable & _
                " BC ON BL.BUS_CODE COLLATE DATABASE_DEFAULT = BC.BUS_CODE WHERE BL.ACCTNO = '" & _pAcctNo & "'" & _
                " AND ISNULL(BL.NEWSW,0) <> 1 " & _
                " AND isnull(xDeleq,0)  <> 1  " & _
                " AND FORYEAR = (Select MAx(Foryear) FROM BUSLINE WHERE  ACCTNO  COLLATE DATABASE_DEFAULT = '" & _pAcctNo & "' ) "
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
