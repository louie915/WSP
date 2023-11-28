Imports System.Data.SqlClient

Public Class cDalRPT_Cert

#Region "Variable Object"
    Public Shared _mDataTable As DataTable
    Private Shared _mDbCon As New SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mSqlCon As SqlConnection
    Public Shared _mCertType As String

    Dim _mStrSql As String
    Dim _mSqlCmd As SqlCommand
#End Region

#Region "Routine Data"

    Public Sub _pSubSelectCertRPT(ByVal CertType As String)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing


            _nQuery = "select convert(varchar, TransDate, 1) as [Date] ,convert(varchar, TransDate, 8) as [Time], RefNo as [Transaction Number], TDN as [Account/TD Number], [Owner] as [Declared Owner], case WHEN CERTTYPE = '0001' THEN 'Certified True Copy(Real Property)' WHEN CERTTYPE = '0002' THEN 'Certificate of No Improvement' WHEN CERTTYPE = '0003' THEN 'Certificate of ***' end as CERTTYPE,'' as [Other Action] from RPT_CERT order by CERTTYPE desc"


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using






            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectRPT(ByVal CertType As String)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing


            _nQuery = "select convert(varchar, TransDate, 1) as [Date] , email, convert(varchar, TransDate, 8) as [Time], RefNo as [Transaction Number], TDN as [Account/TD Number], [Owner] as [Declared Owner], case WHEN CERTTYPE = '0000' THEN 'Certificate of No Property' WHEN CERTTYPE = '0001' THEN 'Certified True Copy(Real Property)' WHEN CERTTYPE = '0002' THEN 'Certificate Of Land Holdings' WHEN CERTTYPE = '0003' THEN 'Certificate of No Improvement' end as CERTTYPE,'' as [Other Action] from RPT_CERT where CERTTYPE = '" & CertType & "' order by CERTTYPE desc"


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using






            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region
End Class
