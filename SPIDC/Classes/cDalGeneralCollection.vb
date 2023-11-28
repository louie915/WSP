
#Region "Imports"
Imports System.Web.HttpContext
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Data
Imports Microsoft.VisualBasic.Devices 'CARL IMPORT


#End Region

Public Class cDalGeneralCollection

    Inherits System.Web.UI.Page





#Region "Variables Data"
    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Public Shared _mEmail As String
    Public Shared _mDate As String
    Public Shared _mTime As String
    Public Shared _mCheckBoxValue As String
    Public Shared _mTransactionNumber As String
    Public Shared _mTransactionType As String
    Public Shared _mPaymentChannel As String
    Public Shared _mOwner As String
    Public Shared _mAmountPaid As String
    Public Shared _mCountSPIDCPAY As String
    Public Shared _mCountDBP As String
    Public Shared _mCountLandBank As String
    Public Shared _mCountPostedLandBank As String
    Public Shared _mCountPostedDBP As String
    Public Shared _mCountALL As String
    Public Shared _mCountPostedSPIDCPay As String
    Public Shared _mTotalSPIDCPAY As String
    Public Shared _mTotalPostedSPIDCPAY As String
    Public Shared _mTotalPostedDBP As String
    Public Shared _mTotalDBP As String
    Public Shared _mTotalLandBank As String
    Public Shared _mTotalPostedLandBank As String
    Public Shared _mTotalAll As String
    Public Shared _mstrdt As String


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


#End Region

#Region "Properties Field"
    Public Shared Property _pEmail() As String
        Get
            Return _mEmail
        End Get
        Set(value As String)
            _mEmail = value
        End Set
    End Property
    Public Shared Property _pDate() As String
        Get
            Return _mDate
        End Get
        Set(value As String)
            _mDate = value
        End Set
    End Property
    Public Shared Property _pTime() As String
        Get
            Return _mTime
        End Get
        Set(value As String)
            _mTime = value
        End Set
    End Property
    Public Property _pCheckBoxValue As String
        Get
            Return _mCheckBoxValue
        End Get
        Set(ByVal value As String)
            _mCheckBoxValue = value
        End Set
    End Property
    Public Property _pTransactionNumber As String
        Get
            Return _mTransactionNumber
        End Get
        Set(ByVal value As String)
            _mTransactionNumber = value
        End Set
    End Property
    Public Property _pTransactionType As String
        Get
            Return _mTransactionType
        End Get
        Set(ByVal value As String)
            _mTransactionType = value
        End Set
    End Property
    Public Property _pOwner As String
        Get
            Return _mOwner
        End Get
        Set(ByVal value As String)
            _mOwner = value
        End Set
    End Property
    Public Property _pAmountPaid As String

        Get

            Return _mAmountPaid

        End Get

        Set(ByVal value As String)

            _mAmountPaid = value

        End Set

    End Property
    Public Property _pPaymentChannel As String

        Get

            Return _mPaymentChannel

        End Get

        Set(ByVal value As String)

            _mPaymentChannel = value

        End Set

    End Property
    Public Property _pTotalSPIDCPAY As String

        Get

            Return _mTotalSPIDCPAY

        End Get

        Set(ByVal value As String)

            _mTotalSPIDCPAY = value

        End Set

    End Property

    Public Property _pTotalDBP As String

        Get

            Return _mTotalDBP

        End Get

        Set(ByVal value As String)

            _mTotalDBP = value

        End Set

    End Property
    Public Property _pTotalLandBank As String

        Get

            Return _mTotalLandBank

        End Get

        Set(ByVal value As String)

            _mTotalLandBank = value

        End Set

    End Property
    Public Property _pTotalPostedLandBank As String

        Get

            Return _mTotalPostedLandBank

        End Get

        Set(ByVal value As String)

            _mTotalPostedLandBank = value

        End Set

    End Property
    Public Property _pTotalPostedSPIDCPay As String

        Get

            Return _mTotalPostedSPIDCPay

        End Get

        Set(ByVal value As String)

            _mTotalPostedSPIDCPay = value

        End Set

    End Property

    Public Property _pTotalPostedDBP As String

        Get

            Return _mTotalPostedDBP

        End Get

        Set(ByVal value As String)

            _mTotalPostedDBP = value

        End Set

    End Property
    Public Property _pTotalAll As String

        Get

            Return _mTotalAll

        End Get

        Set(ByVal value As String)

            _mTotalAll = value

        End Set

    End Property
    Public Property _pCountSPIDCPAY As String

        Get

            Return _mCountSPIDCPAY

        End Get

        Set(ByVal value As String)

            _mCountSPIDCPAY = value

        End Set

    End Property
    Public Property _pCountPostedSPIDCPAY As String

        Get

            Return _mCountPostedSPIDCPAY

        End Get

        Set(ByVal value As String)

            _mCountPostedSPIDCPAY = value

        End Set

    End Property
    Public Property _pCountDBP As String

        Get

            Return _mCountDBP

        End Get

        Set(ByVal value As String)

            _mCountDBP = value

        End Set

    End Property
    Public Property _pCountLandBank As String

        Get

            Return _mCountLandBank

        End Get

        Set(ByVal value As String)

            _mCountLandBank = value

        End Set

    End Property
    Public Property _pCountPostedLandBank As String

        Get

            Return _mCountPostedLandBank

        End Get

        Set(ByVal value As String)

            _mCountPostedLandBank = value

        End Set

    End Property
    Public Property _pCountPostedDBP As String

        Get

            Return _mCountPostedDBP

        End Get

        Set(ByVal value As String)

            _mCountPostedDBP = value

        End Set

    End Property
    Public Property _pCountALL As String

        Get

            Return _mCountALL

        End Get

        Set(ByVal value As String)

            _mCountALL = value

        End Set

    End Property
    Public Property _pstrdt As String

        Get

            Return _mstrdt

        End Get

        Set(ByVal value As String)

            _mstrdt = value

        End Set

    End Property

#End Region





#Region "NYONYIE"

    Public Sub _pSubSelectTransactions()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            '_nQuery = "select TransDate,ControlNo,'BF0016' Form,'CTC Individual' TransactionType,Status,FirstName + ' ' + MiddleName + ' ' + LastName Name,TaxAmount from SOS_TIMS..CTC_Online where CTC_Type='IND' and Status='SUCCESS' " & _
            '    "UNION " & _
            '    "select TransDate,ControlNo,'BF0017' Form,'CTC Corporation' TransactionType,Status,FirstName + ' ' + MiddleName + '' + LastName Name,TaxAmount from SOS_TIMS..CTC_Online where CTC_Type='C' and Status='SUCCESS' " & _
            '    "UNION " & _
            '    "select TransDate,RefNo ControlNo,'AF51' Form,'Business Certification' TransactionType,Status,Owner Name,AMOUNT + DELFEE TaxAmount from SOS_BP..BP_CERT where  STATUS='SUCCESS'"
            _nQuery = "select TransDate, ControlNo, Form, TransactionType, Status, Name, TaxAmount, Or_number, SRS, Bookno,Or_number+' | '+SRS+' | '+Bookno Or_numberSRSBookno from tmp_table_loadtransaction order by  TransDate asc "

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectSPIDCPayTransactions()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select format(TransDate,('MM/dd/yyyy'))Date,format(TransDate,('hh:mm:ss tt'))Time,TXNREFNO TransactionNumber,PAYMENTCHANNEL TransactionType,EMAILADDR Owner,totAmount AmountPaid,isnull(PostStatus,1)PostStatus from OnlinePaymentRefno where PAYMENTCHANNEL='SPIDCPay' and TransDate <> '' and StatusID='SUCCESS' And isnull(PostedDate,'') =''  order by  TransDate desc  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            _mstrdt = ""
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(2).ToString & ":" & "true;"
                    Loop
                End If



            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectPostedSPIDCPayTransactions()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select format(TransDate,('MM/dd/yyyy'))Date,format(TransDate,('hh:mm:ss tt'))Time,TXNREFNO TransactionNumber,PAYMENTCHANNEL TransactionType,EMAILADDR Owner,totAmount AmountPaid,isnull(PostStatus,1)PostStatus from OnlinePaymentRefno where PAYMENTCHANNEL='SPIDCPay' and TransDate <> '' and StatusID='SUCCESS' And isnull(PostedDate,'') <> ''  order by  TransDate desc  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            _mstrdt = ""
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(2).ToString & ":" & "true;"
                    Loop
                End If



            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectLandBankTransactions()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select format(TransDate,('MM/dd/yyyy'))Date,format(TransDate,('hh:mm:ss tt'))Time,TXNREFNO TransactionNumber,PAYMENTCHANNEL TransactionType,EMAILADDR Owner,totAmount AmountPaid,isnull(PostStatus,1)PostStatus from OnlinePaymentRefno where PAYMENTCHANNEL='LBP' and TransDate <> '' and StatusID='SUCCESS' And isnull(PostedDate,'') =''  order by  TransDate desc  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            _mstrdt = ""
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(2).ToString & ":" & "true;"
                    Loop
                End If



            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectPostedLandBankTransactions()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select format(TransDate,('MM/dd/yyyy'))Date,format(TransDate,('hh:mm:ss tt'))Time,TXNREFNO TransactionNumber,PAYMENTCHANNEL TransactionType,EMAILADDR Owner,totAmount AmountPaid,isnull(PostStatus,1)PostStatus from OnlinePaymentRefno where PAYMENTCHANNEL='LBP' and TransDate <> '' and StatusID='SUCCESS' And isnull(PostedDate,'') <> ''  order by  TransDate desc  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            _mstrdt = ""
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(2).ToString & ":" & "true;"
                    Loop
                End If



            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectPostedDBPTransactions()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select format(TransDate,('MM/dd/yyyy'))Date,format(TransDate,('hh:mm:ss tt'))Time,TXNREFNO TransactionNumber,PAYMENTCHANNEL TransactionType,EMAILADDR Owner,totAmount AmountPaid,isnull(PostStatus,1)PostStatus from OnlinePaymentRefno where PAYMENTCHANNEL='DBP' and TransDate <> '' and StatusID='SUCCESS' And isnull(PostedDate,'') <> ''  order by  TransDate desc  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            _mstrdt = ""
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(2).ToString & ":" & "true;"
                    Loop
                End If



            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectAll()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select format(TransDate,('MM/dd/yyyy'))Date,format(TransDate,('hh:mm:ss tt'))Time,TXNREFNO TransactionNumber,PAYMENTCHANNEL TransactionType,EMAILADDR Owner,totAmount AmountPaid from OnlinePaymentRefno where PAYMENTCHANNEL='SPIDCPay' and TransDate <> '' and StatusID='SUCCESS'  " & _
                      "Union " & _
                      "select format(TransDate,('MM/dd/yyyy'))Date,format(TransDate,('hh:mm:ss tt'))Time,TXNREFNO TransactionNumber,PAYMENTCHANNEL TransactionType,EMAILADDR Owner,totAmount AmountPaid from OnlinePaymentRefno where PAYMENTCHANNEL='DBP' and TransDate <> '' and StatusID='SUCCESS'  " & _
                      "order by TransactionType,Date desc,time desc  "

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectCountTotalSPIDCPay()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Count(TXNREFNO)xCount,Sum(totAmount)Total from OnlinePaymentRefno where PAYMENTCHANNEL='SPIDCPay' and TransDate <> '' and isnull(PostedDate,'') =''  and StatusID='SUCCESS'  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectCountTotalLandBank()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Count(TXNREFNO)xCount,Sum(totAmount)Total from OnlinePaymentRefno where PAYMENTCHANNEL='LBP' and TransDate <> '' and isnull(PostedDate,'') =''  and StatusID='SUCCESS'  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectCountTotalPostedLandBank()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Count(TXNREFNO)xCount,Sum(totAmount)Total from OnlinePaymentRefno where PAYMENTCHANNEL='LBP' and TransDate <> '' and isnull(PostedDate,'') <>''  and StatusID='SUCCESS'  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectCountTotalPostedDBP()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Count(TXNREFNO)xCount,Sum(totAmount)Total from OnlinePaymentRefno where PAYMENTCHANNEL='DBP' and TransDate <> '' and isnull(PostedDate,'') <>''  and StatusID='SUCCESS'  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectDBPTransactions()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select format(TransDate,('MM/dd/yyyy'))Date,format(TransDate,('hh:mm:ss tt'))Time,TXNREFNO TransactionNumber,PAYMENTCHANNEL TransactionType,EMAILADDR Owner,totAmount AmountPaid,PostStatus from OnlinePaymentRefno where PAYMENTCHANNEL='DBP' and TransDate <> '' and isnull(PostedDate,'') ='' and StatusID='SUCCESS'  order by  TransDate desc  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectCountTotalDBP()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Count(TXNREFNO)xCount,Sum(totAmount)Total from OnlinePaymentRefno where PAYMENTCHANNEL='DBP' and TransDate <> '' and isnull(PostedDate,'') =''  and StatusID='SUCCESS'  "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectCountTotalPostedSPIDCPay()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Count(TXNREFNO)xCount,Sum(totAmount)Total from OnlinePaymentRefno where PAYMENTCHANNEL='SPIDCPay' and TransDate <> '' and isnull(PostedDate,'') <>'' and StatusID='SUCCESS'   "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectCountTotaLandBank()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Count(TXNREFNO)xCount,Sum(totAmount)Total from OnlinePaymentRefno where PAYMENTCHANNEL='SPIDCPay' and TransDate <> '' and isnull(PostedDate,'') <>'' and StatusID='SUCCESS'   "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectCountTotalAll()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Count(TXNREFNO)xCount,Sum(totAmount)Total from OnlinePaymentRefno where TransDate <> '' and StatusID='SUCCESS'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    '_nOwner = _nSqlDr.Item("OWNER").ToString
                    ' Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub _pSubUpdateReferenceNumber()

    '    Try
    '        Dim _nQuery As String = Nothing

    '        _nQuery = "Update OnlinePaymentRefno set PostStatus='" & _mCheckBoxValue & "' where TXNREFNO ='" & _mTransactionNumber & "'  "
    '        Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
    '        _nSqlCommand.ExecuteNonQuery()
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Sub _pSubUpdateReferenceNumber()

        Try
            Dim _nQuery As String = Nothing

            _nQuery = "exec [SP_GETMULTIPLE] '" & _mstrdt & "','" & _mEmail & "' "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "Routines Specific"

    Public Sub _pSubGetCountTotalSPIDCPAY()
        Try
            '----------------------------------
            _pSubSelectCountTotalSPIDCPay()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iCount As Integer = .GetOrdinal("xCount")
                    Dim _iTotal As Integer = .GetOrdinal("Total")


                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mCountSPIDCPAY = ._pReturnString(_nSqlDataReader(_iCount))
                                _mTotalSPIDCPAY = Format(._pReturnString(_nSqlDataReader(_iTotal)), "standard")

                            Loop
                        Else
                            _mCountSPIDCPAY = ""
                            _mCountSPIDCPAY = ""

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetCountTotalPostedSPIDCPay()
        Try
            '----------------------------------
            _pSubSelectCountTotalPostedSPIDCPay()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iCount As Integer = .GetOrdinal("xCount")
                    Dim _iTotal As Integer = .GetOrdinal("Total")


                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mCountPostedSPIDCPay = ._pReturnString(_nSqlDataReader(_iCount))
                                _mTotalPostedSPIDCPAY = Format(._pReturnString(_nSqlDataReader(_iTotal)), "standard")

                            Loop
                        Else
                            _mCountPostedSPIDCPay = ""
                            _mTotalPostedSPIDCPAY = ""

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetCountTotalLandBank()
        Try
            '----------------------------------
            _pSubSelectCountTotalLandBank()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iCount As Integer = .GetOrdinal("xCount")
                    Dim _iTotal As Integer = .GetOrdinal("Total")


                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mCountLandBank = ._pReturnString(_nSqlDataReader(_iCount))
                                _mTotalLandBank = Format(._pReturnString(_nSqlDataReader(_iTotal)), "standard")

                            Loop
                        Else
                            _mCountLandBank = ""
                            _mTotalLandBank = ""

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetCountTotalPostedLandBank()
        Try
            '----------------------------------
            _pSubSelectCountTotalPostedLandBank()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iCount As Integer = .GetOrdinal("xCount")
                    Dim _iTotal As Integer = .GetOrdinal("Total")


                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mCountPostedLandBank = ._pReturnString(_nSqlDataReader(_iCount))
                                _mTotalPostedLandBank = Format(._pReturnString(_nSqlDataReader(_iTotal)), "standard")

                            Loop
                        Else
                            _mCountPostedLandBank = ""
                            _mTotalPostedLandBank = ""

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetCountTotalDBP()
        Try
            '----------------------------------
            _pSubSelectCountTotalDBP()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iCount As Integer = .GetOrdinal("xCount")
                    Dim _iTotal As Integer = .GetOrdinal("Total")


                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mCountDBP = ._pReturnString(_nSqlDataReader(_iCount))
                                _mTotalDBP = Format(._pReturnString(_nSqlDataReader(_iTotal)), "standard")

                            Loop
                        Else
                            _mCountDBP = ""
                            _mTotalDBP = ""

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetCountTotalPostedDBP()
        Try
            '----------------------------------
            _pSubSelectCountTotalPostedDBP()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iCount As Integer = .GetOrdinal("xCount")
                    Dim _iTotal As Integer = .GetOrdinal("Total")


                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mCountPostedDBP = ._pReturnString(_nSqlDataReader(_iCount))
                                _mTotalPostedDBP = Format(._pReturnString(_nSqlDataReader(_iTotal)), "standard")

                            Loop
                        Else
                            _mCountPostedDBP = ""
                            _mTotalPostedDBP = ""

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetCountTotalAll()
        Try
            '----------------------------------
            _pSubSelectCountTotalAll()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iCount As Integer = .GetOrdinal("xCount")
                    Dim _iTotal As Integer = .GetOrdinal("Total")


                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mCountALL = ._pReturnString(_nSqlDataReader(_iCount))
                                _mTotalAll = Format(._pReturnString(_nSqlDataReader(_iTotal)), "standard")

                            Loop
                        Else
                            _mCountALL = ""
                            _mTotalAll = ""

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
