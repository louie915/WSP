


#Region "Imports"

Imports System.Data.SqlClient
Imports System.Data
Imports VB.NET.Methods

#End Region

Public Class cDalBilling

#Region "Variables Data"

    Private _mQuery As String = Nothing
    Private _mSqlCon As SqlConnection
    Private _mDataTable As DataTable
    Private _mSqlCommand As SqlCommand
#End Region

#Region "Properties Data"

    Public Property _pDataTable() As DataTable
        Get
            Return _mDataTable
        End Get
        Set(value As DataTable)
            _mDataTable = value
        End Set
    End Property
    Public Property _pQuery() As String
        Get
            Return _mQuery
        End Get
        Set(value As String)
            _mQuery = value
        End Set
    End Property
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlCon = value
        End Set
    End Property
    Public ReadOnly Property _pSqlCommand() As SqlCommand
        Get
            Return _mSqlCommand
        End Get
    End Property
    Public ReadOnly Property _pDataTable2() As DataTable
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

#End Region

#Region "Variables Field"

    Private _mBusinessAccountNumber As String
    Private _mForYear As String
    Private _mTaxCode As String
    Private _mTaxDescription As String
    Private _mTaxBase As String
    Private _mTaxDue As String
    Private _mPenalty As String
    Private _mTotal As String
    Private _mCoveredQuarter As String
    Private _mLastQuarterPaid As String
    Private _mCoveredPeriod As String
    Private _mExcessCreditAmount As String
    Private _mPaymentMode As String
    Private _mImageData As Byte()
    Private _mFileNo As String
    Private _mFileID As String
    Private _mAcctNo As String
#End Region

#Region "Properties Field"
    Public Property _pBusinessAccountNumber() As String
        Get
            Return _mBusinessAccountNumber
        End Get
        Set(value As String)
            _mBusinessAccountNumber = value
        End Set
    End Property
    Public Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(value As String)
            _mForYear = value
        End Set
    End Property
    Public Property _pTaxCode() As String
        Get
            Return _mTaxCode
        End Get
        Set(value As String)
            _mTaxCode = value
        End Set
    End Property
    Public Property _pTaxDescription() As String
        Get
            Return _mTaxDescription
        End Get
        Set(value As String)
            _mTaxDescription = value
        End Set
    End Property
    Public Property _pTaxBase() As String
        Get
            Return _mTaxBase
        End Get
        Set(value As String)
            _mTaxBase = value
        End Set
    End Property
    Public Property _pTaxDue() As String
        Get
            Return _mTaxDue
        End Get
        Set(value As String)
            _mTaxDue = value
        End Set
    End Property
    Public Property _pPenalty() As String
        Get
            Return _mPenalty
        End Get
        Set(value As String)
            _mPenalty = value
        End Set
    End Property
    Public Property _pTotal() As String
        Get
            Return _mTotal
        End Get
        Set(value As String)
            _mTotal = value
        End Set
    End Property
    Public Property _pCoveredQuarter() As String
        Get
            Return _mCoveredQuarter
        End Get
        Set(value As String)
            _mCoveredQuarter = value
        End Set
    End Property
    Public Property _pLastQuarterPaid() As String
        Get
            Return _mLastQuarterPaid
        End Get
        Set(value As String)
            _mLastQuarterPaid = value
        End Set
    End Property
    Public Property _pCoveredPeriod() As String
        Get
            Return _mCoveredPeriod
        End Get
        Set(value As String)
            _mCoveredPeriod = value
        End Set
    End Property
    Public Property _pExcessCreditAmount() As String
        Get
            Return _mExcessCreditAmount
        End Get
        Set(value As String)
            _mExcessCreditAmount = value
        End Set
    End Property
    Public Property _pPaymentMode() As String
        Get
            Return _mPaymentMode
        End Get
        Set(value As String)
            _mPaymentMode = value
        End Set
    End Property
    Public Property _pImageData() As Byte()
        Get
            Return _mImageData
        End Get
        Set(ByVal value As Byte())
            _mImageData = value
        End Set
    End Property
    Public Property _pFileNo() As String
        Get
            Return _mFileNo
        End Get
        Set(value As String)
            _mFileNo = value
        End Set
    End Property
    Public Property _pFileID() As String
        Get
            Return _mFileID
        End Get
        Set(value As String)
            _mFileID = value
        End Set
    End Property
    Public Property _pAcctNo() As String
        Get
            Return _mAcctNo
        End Get
        Set(value As String)
            _mAcctNo = value
        End Set
    End Property

#End Region

#Region "Routines"
    Public Sub _pSubSelect()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------
            _nQuery = _
            "SELECT Acctno AS BusinessAccountNumber, ForYear," & _
                "Bus_Code as TaxCode, Desc1 as TaxDescription," & _
                "TaxBase, Amt_pd as TaxDue, Amt_PenPd as Penalty, Totdue as Total," & _
                "Qtryr2 as CoveredQuarter, Qtryr1 as LastQuarterPaid," & _
                "(Qtryr2 + '' + Qtryr1) as CoveredPeriod, " & _
                "Discount as ExcessCreditAmount,  ModeP as PaymentMode FROM " & _
                "[BILLINGTEMP]"

            ''_nQuery = _
            ''    "SELECT " & _
            ''    "* " & _
            ''    "FROM " & _
            ''    "[R&D.OAIMS].[dbo].[BILLINGTEMP]"

            '"[uvw.VS2014.WA.BPLTIMS.OPS.BILLINGTEMP.Data.Read] "

            _nWhere = "WHERE [AcctNo] = '" & _mBusinessAccountNumber & "' " '@BusinessAccountNumber"

            'If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then
            '    _nWhere = "WHERE [AcctNo] = '170809-00010' " '@BusinessAccountNumber"
            '    '_nWhere = "WHERE [BusinessAccountNumber] = @BusinessAccountNumber"
            'Else
            '    _nWhere = Nothing
            'End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            'Dim _nSqlCommand As New SqlCommand(_mQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Dim _nSqlCommand As New SqlCommand(_mQuery, cGlobalConnections._pSqlCxn_OAIMS)

            With _nSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then .AddWithValue("@AcctNo", _mBusinessAccountNumber)
                'If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then .AddWithValue("@BusinessAccountNumber", _mBusinessAccountNumber)

            End With

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSumAmount()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _OrderBy As String = Nothing
            '----------------------------------

            _mBusinessAccountNumber = _pBusinessAccountNumber
            _nQuery = _
                "SELECT Acctno AS BusinessAccountNumber, " & _
                "SUM(ISNULL(cast(TaxBase as numeric(18,4)),0.00)) as TaxBase,  " & _
                "SUM(ISNULL(cast(Amt_pd as numeric(18,4)),0.00)) as TaxDue,  " & _
                "SUM(ISNULL(cast(Amt_PenPd as numeric(18,4)),0.00)) as Penalty, " & _
                "SUM(ISNULL(cast(Totdue as numeric(18,4)),0.00)) as Total, " & _
                "SUM(ISNULL(cast(Discount as numeric(18,4)),0.00)) as TaxCredit FROM " & _
                "[BILLINGTEMP] "
            _nWhere = "WHERE [AcctNo] = '" & _mBusinessAccountNumber & "' " '@BusinessAccountNumber"
            _OrderBy = "GROUP BY Acctno"
            _mQuery = _nQuery & _nWhere & _OrderBy

            '----------------------------------
            Dim _nSqlCommand As New SqlCommand(_mQuery, cGlobalConnections._pSqlCxn_OAIMS)

            With _nSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then .AddWithValue("@AcctNo", _mBusinessAccountNumber)
            End With

            ' _nSqlCommand.Dispose()
            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)

            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSaveReportImage(xFileNo As String, xFileID As String, xAcctNo As String)
        Try

            _mFileNo = xFileNo
            _mFileID = xFileID
            _mAcctNo = xAcctNo
            'BPLTAS FILE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTIMS_F"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nFileServerName As String = _nClBP._pDBDataSource
            Dim _nFileDatabaseName As String = _nClBP._pDBInitialCatalog

            _mQuery = _
             "INSERT INTO" & _
                "[" & _nFileServerName & "].[" & _nFileDatabaseName & "].[dbo].[TOPFile] " & _
                " (xFileNo, xFileName,AcctNo,ForYear,ARXFile) " & _
                "VALUES " & _
                "('" & _mFileNo & "', '" & _mFileID & ".PDF','" & _mAcctNo & "',(SELECT YEAR(getdate()) as xYear), @ImageData) "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@ImageData", _mImageData)
            End With

            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectFileNo()

        Try
            'BPLTAS FILE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTIMS_F"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nFileServerName As String = _nClBP._pDBDataSource
            Dim _nFileServerDatabaseName As String = _nClBP._pDBInitialCatalog

            Dim _nQuery As String
            _nQuery = "SELECT TOP 1 MAX(xFileNo) FileID FROM [" & _nFileServerName & "].[" & _nFileServerDatabaseName & "].[dbo].[TOPFile]"

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()


        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSubGenerateFileID()

        Try
            'BPLTAS FILE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTIMS_F"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nFileServerName As String = _nClBP._pDBDataSource
            Dim _nFileDatabaseName As String = _nClBP._pDBInitialCatalog

            Dim _nQuery As String
            _nQuery = "WITH XTable " & _
                "AS (SELECT (CONVERT(varchar(6), GETDATE(), 12) + " & _
                "REPLACE(CONVERT(varchar, GETDATE(), 108), ':','')) AS SvrDate) " & _
                "SELECT SUBSTRING(SvrDate, 3, 4) + LEFT(SvrDate,2) + '_' + SUBSTRING(SvrDate, 7, 2) + '-' + " & _
                "SUBSTRING(SvrDate, 9, 2) + '-' + SUBSTRING(SvrDate, 11, 2)  " & _
                "AS FileID FROM XTable "

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            _mSqlCommand.ExecuteNonQuery()


        Catch ex As Exception

        End Try

    End Sub

#End Region

End Class
