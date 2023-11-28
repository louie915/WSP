
#Region "Imports"
Imports System.Web.HttpContext
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Data
Imports Microsoft.VisualBasic.Devices 'CARL IMPORT


#End Region

Public Class cDalOnlineService

    Inherits System.Web.UI.Page




#Region "Variables Data"
    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Public Shared _mForm As String
    Public Shared _mUser As String
    Public Shared _mEmail As String
    Public Shared _mDate As String
    Public Shared _mTransactionNumber As String
    Public Shared _mTransactionType As String
    Public Shared _mStatus As String
    Public Shared _mName As String
    Public Shared _mAmountPaid As String
    Public Shared _mPaymentChannel As String
    Public Shared _mServerName As String
    Public Shared _mDatabaseName As String
    Public Shared _mTIMSDatabaseName As String
    Public Shared _mBPDatabaseName As String
    Public Shared _mRPTDatabaseName As String
    Public Shared _mOAIMSDatabaseName As String
    Public Shared _mHRIMS_RegLink As String

    Public Shared _mORPrint As String
    Public Shared _mSinglePrint As Boolean

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
    Public Shared Property _pForm() As String
        Get
            Return _mForm
        End Get
        Set(value As String)
            _mForm = value
        End Set
    End Property
    Public Shared Property _pUser() As String
        Get
            Return _mUser
        End Get
        Set(value As String)
            _mUser = value
        End Set
    End Property
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
    Public Shared Property _pHRIMS_RegLink() As String
        Get
            Return _mHRIMS_RegLink
        End Get
        Set(value As String)
            _mHRIMS_RegLink = value
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
    Public Property _pStatus As String
        Get
            Return _mStatus
        End Get
        Set(ByVal value As String)
            _mStatus = value
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
    Public Property _pName As String
        Get
            Return _mName
        End Get
        Set(ByVal value As String)
            _mName = value
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
    Public Property _pServerName As String

        Get

            Return _mServerName

        End Get

        Set(ByVal value As String)

            _mServerName = value

        End Set

    End Property
    Public Property _pDatabaseName As String

        Get

            Return _mDatabaseName

        End Get

        Set(ByVal value As String)

            _mDatabaseName = value

        End Set

    End Property
    Public Property _pTIMSDatabaseName As String

        Get

            Return _mTIMSDatabaseName

        End Get

        Set(ByVal value As String)

            _mTIMSDatabaseName = value

        End Set

    End Property
    Public Property _pBPDatabaseName As String

        Get

            Return _mBPDatabaseName

        End Get

        Set(ByVal value As String)

            _mBPDatabaseName = value

        End Set

    End Property
    Public Property _pRPTDatabaseName As String

        Get

            Return _mRPTDatabaseName

        End Get

        Set(ByVal value As String)

            _mRPTDatabaseName = value

        End Set

    End Property
    Public Property _pOAIMSDatabaseName As String

        Get

            Return _mOAIMSDatabaseName

        End Get

        Set(ByVal value As String)

            _mOAIMSDatabaseName = value

        End Set

    End Property

    Public Property _pORPrint As String

        Get

            Return _mORPrint

        End Get

        Set(ByVal value As String)

            _mORPrint = value

        End Set

    End Property
    Public Property _pSinglePrint As Boolean

        Get

            Return _mSinglePrint

        End Get

        Set(ByVal value As Boolean)

            _mSinglePrint = value

        End Set

    End Property
#End Region





#Region "CARL"

#Region "Variables Data"
    Public Shared DetectTrap As Boolean
#End Region

    Public Sub PopulateRecords(dg As GridView, _fields As String, _table As String, Optional _condition As String = "", Optional _orderBy As String = "")
        Try
            Dim getquery As String = IIf(_fields.Trim <> "", "SELECT " & _fields.Trim, "") & "  " & IIf(_table.Trim <> "", " FROM " & _table.Trim, "") & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "") & IIf(_orderBy.Trim <> "", " ORDER BY " & _orderBy.Trim, "")
            DisplayOutput(getquery)

            _mSqlCommand = New SqlCommand(getquery, cGlobalConnections._pSqlCxn_HRIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(getquery, cGlobalConnections._pSqlCxn_HRIMS)

            dg.Visible = ifHasRows(_fields, _table, _condition)

            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            dg.DataSource = _mDataTable
            dg.DataBind()

        Catch ex As Exception
            DisplayOutput(ex.Message)
        End Try
    End Sub

    Public Sub CUD(action As String, _fields As String, _table As String, Optional _condition As String = "")
        Try
            Dim getquery As String = ""

            Select Case action
                Case "C" ' IF SPECIFIC YUNG FIELD SA INSERT INCLUED IT BESIDE _table parameter ' CARL20190802
                    getquery = "INSERT INTO " & IIf(_table.Trim <> "", _table.Trim, "") & " VALUES(" & IIf(_fields.Trim <> "", _fields.Trim, "") & ")"
                Case "U"
                    getquery = "UPDATE " & IIf(_table.Trim <> "", _table.Trim, "") & " set " & IIf(_fields.Trim <> "", _fields.Trim, "") & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "")
                Case "D"
                    getquery = "DELETE " & IIf(_table.Trim <> "", _table.Trim, "") & " " & IIf(_condition.Trim <> "", " WHERE " & _condition.Trim, "")
                Case Else
            End Select
            DisplayOutput(getquery)

            _pSqlConnection = cGlobalConnections._pSqlCxn_HRIMS
            _mSqlCommand = New SqlCommand(getquery, _mSqlConnection)
            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            DisplayOutput(ex.Message)
        End Try
    End Sub

    Public Function ifHasRows(field As String, table As String, Optional condField As String = "") As Boolean
        Try
            Dim getquery As String = IIf(field.Trim <> "", " SELECT " & field.Trim, "") & "  " & IIf(table.Trim <> "", " FROM " & table.Trim, "") & IIf(condField.Trim <> "", " WHERE " & condField.Trim, "")
            DisplayOutput(getquery)
            Dim _TempCmd As New SqlCommand(getquery, cGlobalConnections._pSqlCxn_HRIMS)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader
            ifHasRows = _TempReader.HasRows
            _TempReader.Close()
            _TempCmd.Dispose()
        Catch ex As Exception
            ifHasRows = False
        End Try
    End Function

    Public Function getRow(FieldToGet As String, field As String, table As String, Optional condField As String = "") As String
        Try
            Dim val As String
            Dim cond As String = IIf(condField.Trim <> "", " where " & condField, "")
            Dim getQuer As String = "select " & field.ToUpper & " from " & table & cond
            DisplayOutput(getQuer)
            Dim _TempCmd As New SqlCommand(getQuer, cGlobalConnections._pSqlCxn_HRIMS)
            Dim _TempReader As SqlDataReader = _TempCmd.ExecuteReader
            _TempReader.Read()
            val = IIf(_TempReader.HasRows, _TempReader.Item(FieldToGet).ToString, "")
            _TempReader.Close()
            _TempCmd.Dispose()
            getRow = val
        Catch ex As Exception
            getRow = ""
        End Try
    End Function

    Public Sub DisplayOutput(text As String)
        Try
            'Dim CARL As Boolean = False ' toggle this to True to toggle copy the text to clipboard
            'If CARL Then
            '    Dim Comp As New Computer
            '    Comp.Clipboard.SetText(text)
            'End If
            Debug.Print(vbNewLine & "[" & My.Computer.Name & "] " & text)

        Catch ex As Exception
            Debug.Print("ERROR: [" & ex.Message & "] " & vbNewLine & vbNewLine & text)
        End Try
    End Sub

    Public Sub NavigatePage(Pos, page)
        Try

            'Select Case Pos
            '    Case "<"
            '        DisplayOutput(Request.ServerVariables("HTTP_REFERER"))
            '        page.Response.Redirect(Request.UrlReferrer.ToString())
            '    Case Else
            page.Response.Redirect(Pos & ".aspx")
            'End Select
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Write(Text, page)
        Try
            page.Response.Write("<script>try{" & Text & "}catch(e){alert(e.message);}</script>")
        Catch ex As Exception
            page.Response.Write("<script>try{alert(" & ex.Message & ");}catch(e){alert(e.message);}")
        End Try
    End Sub

    Public Sub MessageBox(Text, page)
        Try
            page.Response.Write("<script>try{alert('" & Text & "');}catch(e){alert(e.message);}</script>")
        Catch ex As Exception
            page.Response.Write("<script>try{alert(" & ex.Message & ");}catch(e){alert(e.message);}</script>")
        End Try
    End Sub


    Public Function FormatToDate(val As String) As String
        Try
            Dim res = DateTime.ParseExact(val, "yyyy-MM-dd", Nothing).ToString("MM-dd-yyyy")
            Return res
        Catch ex As Exception
            Return val
        End Try
    End Function


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
            _nQuery = "select TransDate, ControlNo, Form, TransactionType, Status, Name, TaxAmount, Or_number, SRS, Bookno,Or_number+' | '+SRS+' | '+Bookno Or_numberSRSBookno from [" & _mEmail & "tmp_table_loadtransaction] order by  TransDate asc "

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
    Public Sub _pSubSelectCreatedTransactions()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select TransDate,  ControlNo, Form, TransactionType, Status, Name, TaxAmount, Or_number, SRS, Bookno,Or_number+' | '+SRS+' | '+Bookno Or_numberSRSBookno from [" & _mEmail & "tmp_table_loadtransaction] where or_number <>'' and srs <> '' and bookno<>'' order by  TransDate asc "
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
    Public Sub _pSubSelectUser()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select loginname from  SysCtrl where Email='" & _mEmail & "'"
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
                    _mUser = _nSqlDr.Item("loginname").ToString
                    ' Loop
                Else
                    _mUser = ""
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectForm()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select Form from FormSetup where TransactionName= '" & _mTransactionType & "'"
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
                    _mForm = _nSqlDr.Item("Form").ToString
                    ' Loop
                Else
                    _mForm = ""
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectBooklet()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------      
            'If _mTransactionType = "CTC Individual" Then
            '    '----------------------------------                
            '    _mForm = "BF906"
            '    '----------------------------------     
            'ElseIf _mTransactionType = "CTC Corporation" Then
            '    '----------------------------------                
            '    _mForm = "BF903"
            '    '----------------------------------     
            'ElseIf _mTransactionType = "Business Certification" Then
            '    '----------------------------------                
            '    _mForm = "AF51"
            '    '----------------------------------     
            'ElseIf _mTransactionType = "RPT Certification" Then
            '    '----------------------------------                
            '    _mForm = "AF56"
            '    '----------------------------------     
            'ElseIf _mTransactionType = "Business Payment" Then
            '    '----------------------------------                
            '    _mForm = "AF51"
            '    '----------------------------------   
            'End If

            _mSqlConnection = cGlobalConnections._pSqlCxn_TIMS
            _pSubSelectForm()
            _mSqlConnection = cGlobalConnections._pSqlCxn_TOIMS

            _nQuery = "select Form from Receipts where [user]='" & _mUser & "' and form='" & _mForm & "'"
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
                    _mForm = _nSqlDr.Item("Form").ToString
                    ' Loop
                Else
                    _mForm = ""
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectPrintOR()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nwhereSingleOR As String

            If _mSinglePrint = True Then
                _nwhereSingleOR = " and Or_number = '" & _mORPrint & "' "
            Else
                _nwhereSingleOR = ""
            End If

            If _mTransactionType = "CTC Individual" Then
                _mTransactionType = "IND"
                '----------------------------------                
                _nQuery = "select Or_number,SRS,YEAR(getdate())Year,'Caloocan City' LGUProfile,CONVERT(varchar, getdate(), 101) DateIssued,LastName,FirstName,MiddleName,Gender,TIN,  " & _
                          "Address,Citizenship, BirthPlace,CivilStatus,BirthDate,Occupation,BasicAmount,TaxAmount,Penalty,TotAmount,DelFee from " & _mDatabaseName & "..CTC_Online " & _
                          "INNER JOIN [" & _mEmail & "tmp_table_or] on CTC_Online.Refno =[" & _mEmail & "tmp_table_or].TransactionNumber " & _
                          "where CTC_Type='" & _mTransactionType & "' and PostedDate=FORMAT (getdate(), 'yyyy/MM/dd ')  " & _nwhereSingleOR
                '----------------------------------     
            ElseIf _mTransactionType = "CTC Corporation" Then
                _mTransactionType = "Corp"
                '----------------------------------                
                _nQuery = "select Or_number,SRS,YEAR(getdate())Year,'Caloocan City' LGUProfile,CONVERT(varchar, getdate(), 101) DateIssued,LastName CompanyName,TIN, " & _
                          "Address,OrgKind, BirthPlace PlaceofIncorporation,BirthDate DateofIncorp,BasicAmount,TaxAmount,Penalty,TotAmount,DelFee,RPTIncome,BusIncome,(RPTIncome / 5000) *2 RPTIncomeComputation,(BusIncome /5000) * 2 BusIncomeComputation from " & _mDatabaseName & "..CTC_Online " & _
                          "INNER JOIN [" & _mEmail & "tmp_table_or] on CTC_Online.Refno =[" & _mEmail & "tmp_table_or].TransactionNumber " & _
                          "where  CTC_Type='Corp' and PostedDate=FORMAT (getdate(), 'yyyy/MM/dd ') " & _nwhereSingleOR
                '----------------------------------      
            ElseIf _mTransactionType = "Business Certification" Then
                '----------------------------------                
                _nQuery = "select Or_number,SRS,YEAR(getdate())Year,'Caloocan City' LGUProfile,CONVERT(varchar, getdate(), 101) DateIssued,LastName CompanyName,TIN, " & _
                          "Address,OrgKind, BirthPlace PlaceofIncorporation,BasicAmount,TaxAmount,Penalty,TotAmount,DelFee from " & _mDatabaseName & "..CTC_Online " & _
                          "INNER JOIN [" & _mEmail & "tmp_table_or] on CTC_Online.ControlNo =tmp_table_or.TransactionNumber " & _
                          "where  CTC_Type='" & _mTransactionType & "' and PostedDate=FORMAT (getdate(), 'yyyy/MM/dd ')" & _nwhereSingleOR
                '----------------------------------     
            ElseIf _mTransactionType = "RPT Certification" Then
                '----------------------------------                
                _nQuery = "select Or_number,SRS,YEAR(getdate())Year,'Caloocan City' LGUProfile,CONVERT(varchar, getdate(), 101) DateIssued,LastName CompanyName,TIN, " & _
                          "Address,OrgKind, BirthPlace PlaceofIncorporation,BasicAmount,TaxAmount,Penalty,TotAmount,DelFee from " & _mDatabaseName & "..CTC_Online " & _
                          "INNER JOIN [" & _mEmail & "tmp_table_or] on CTC_Online.ControlNo =tmp_table_or.TransactionNumber " & _
                          "where  CTC_Type='" & _mTransactionType & "' and PostedDate=FORMAT (getdate(), 'yyyy/MM/dd ')" & _nwhereSingleOR
                '----------------------------------     
            ElseIf _mTransactionType = "Business Payment" Then
                '----------------------------------                
                _nQuery = "Select Or_number,[" & _mEmail & "tmp_table_or].SRS,YEAR(getdate())Year,'Caloocan City' LGUProfile, " &
                        "CONVERT(varchar, getdate(), 101) DateIssued,LEDGER.ACCTNO,LEDGEREXTN.QP, LEDGEREXTN.AcctCode, " &
                        "(select [description] from [" & cGlobalConnections._pSqlCxn_TOIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_TOIMS.Database & "].[dbo].coa " &
                        "where ACCTNO=LEDGEREXTN.AcctCode )[description], LEDGEREXTN.AMOUNTDUE Amount, " &
                        "(select sum(LEDGEREXTN.AMOUNTDUE) from [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].LEDGEREXTN " &
                        "where ACCTNO=LEDGER.ACCTNO and REFERENCENO=LEDGER.REFERENCENO)AMOUNTDUE,  " &
                        "(select sum(LEDGEREXTN.PENDUE) from [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].LEDGEREXTN   " &
                        "where ACCTNO=LEDGER.ACCTNO and REFERENCENO=LEDGER.REFERENCENO)PENDUE  " &
                        "from [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].LEDGER " &
                        "INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].LEDGEREXTN   " &
                        "on  LEDGER.REFERENCENO =LEDGEREXTN.REFERENCENO  and LEDGER.ACCTNO =LEDGEREXTN.ACCTNO    " &
                        "INNER JOIN [" & cGlobalConnections._pSqlCxn_TIMS.Database & "].[dbo].[" & _mEmail & "tmp_table_or]  " &
                        "on  LEDGER.REFERENCENO =[" & _mEmail & "tmp_table_or].TransactionNumber  " &
                        "group by Or_number,[" & _mEmail & "tmp_table_or].SRS,LEDGER.ACCTNO,  " &
                        "LEDGER.REFERENCENO, LEDGEREXTN.AcctCode, LEDGEREXTN.AMOUNTDUE, LEDGEREXTN.QP  " &
                        "UNION select Or_number,[" & _mEmail & "tmp_table_or].SRS,  " &
                        "YEAR(getdate())Year,'Caloocan City' LGUProfile,CONVERT(varchar, getdate(), 101) DateIssued,  " &
                        "LEDGER.ACCTNO,LEDGEREXTN.QP, LEDGEREXTN.PenAcctCode,  " &
                        "(select [description] from [" & cGlobalConnections._pSqlCxn_TOIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_TOIMS.Database & "].[dbo].coa  " &
                        "where ACCTNO=LEDGEREXTN.PenAcctCode )[description],LEDGEREXTN.PENDUE Amount,  " &
                        "(select sum(LEDGEREXTN.AMOUNTDUE) from [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].LEDGEREXTN   " &
                        "where ACCTNO=LEDGER.ACCTNO and REFERENCENO=LEDGER.REFERENCENO)AMOUNTDUE,  " &
                        "(select sum(LEDGEREXTN.PENDUE) from [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].LEDGEREXTN   " &
                        "where ACCTNO=LEDGER.ACCTNO and REFERENCENO=LEDGER.REFERENCENO)PENDUE  " &
                        "from [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].LEDGER INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].LEDGEREXTN   " &
                        "on  LEDGER.REFERENCENO =LEDGEREXTN.REFERENCENO  and LEDGER.ACCTNO =LEDGEREXTN.ACCTNO  " &
                        "INNER JOIN  [" & cGlobalConnections._pSqlCxn_TIMS.Database & "].[dbo].[" & _mEmail & "tmp_table_or] " &
                        "on  LEDGER.REFERENCENO =[" & _mEmail & "tmp_table_or].TransactionNumber   " &
                        "where LEDGEREXTN.PENDUE <> ''  " &
                        " group by Or_number,[" & _mEmail & "tmp_table_or].SRS,LEDGER.ACCTNO,  " &
                        "LEDGER.REFERENCENO,LEDGEREXTN.PenAcctCode,LEDGEREXTN.PENDUE,LEDGEREXTN.QP order by Or_number"
                '----------------------------------     
            End If


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
    Public Sub _pSubCreateLoadRecords()
        Try
            Dim _nQuery As String = Nothing

            _nQuery = " [SP_CreateLoadTransaction] '" & _mTIMSDatabaseName & "','" & _mBPDatabaseName & "','" & _mRPTDatabaseName & "','" & _mOAIMSDatabaseName & "','','" & _mEmail & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCreateSelectedRecord()
        Try
            Dim _nQuery As String = Nothing

            _nQuery = " [SP_CreateTempOR] '" & _mTIMSDatabaseName & "','" & _mBPDatabaseName & "','" & _mRPTDatabaseName & "','" & _mOAIMSDatabaseName & "','','" & _mServerName & "','" & _mDatabaseName & "','" & _mTransactionType & "','" & _mEmail & "' "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubPostOR()
        Try
            Dim _nQuery As String = Nothing
            If _mTransactionType = "CTC Individual" Or _mTransactionType = "IND" Then
                _mTransactionType = "CTC Individual"



                _nQuery = " [SP_PostOR] '" & _mTIMSDatabaseName & "','" & _mBPDatabaseName & "','" & _mRPTDatabaseName & "','" & _mOAIMSDatabaseName & "','','" & _mServerName & "','" & _mDatabaseName & "','" & _mTransactionType & "','" & _mEmail & "' "

            ElseIf _mTransactionType = "CTC Corporation" Or _mTransactionType = "C" Then
                _mTransactionType = "CTC Corporation"

                _nQuery = " [SP_PostOR] '" & _mTIMSDatabaseName & "','" & _mBPDatabaseName & "','" & _mRPTDatabaseName & "','" & _mOAIMSDatabaseName & "','','" & _mServerName & "','" & _mDatabaseName & "','" & _mTransactionType & "','" & _mEmail & "' "
            ElseIf _mTransactionType = "Business Certification" Then
                _nQuery = " [SP_PostOR] '" & _mTIMSDatabaseName & "','" & _mBPDatabaseName & "','" & _mRPTDatabaseName & "','" & _mOAIMSDatabaseName & "','','" & _mServerName & "','" & _mDatabaseName & "','" & _mTransactionType & "','" & _mEmail & "' "
            ElseIf _mTransactionType = "RPT Certification" Then
                _nQuery = " [SP_PostOR] '" & _mTIMSDatabaseName & "','" & _mBPDatabaseName & "','" & _mRPTDatabaseName & "','" & _mOAIMSDatabaseName & "','','" & _mServerName & "','" & _mDatabaseName & "','" & _mTransactionType & "','" & _mEmail & "' "
            ElseIf _mTransactionType = "Business Payment" Then
                _nQuery = " [SP_PostOR] '" & _mTIMSDatabaseName & "','" & _mBPDatabaseName & "','" & _mRPTDatabaseName & "','" & _mOAIMSDatabaseName & "','','" & _mServerName & "','" & _mDatabaseName & "','" & _mTransactionType & "','" & _mEmail & "' "
            End If

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Function _id(idno As String) As String
        Try
            Dim _nQuery As String = Nothing
            Dim _nQuery1 As String = Nothing
            Dim s As String, s1 As String
            _nQuery = "select top 1 right(IDNO,3)   from PDS_VoluntaryWorkorInvolvement   order by IDNO desc "


            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            Dim _read As SqlDataReader

            _read = _nSqlCommand.ExecuteReader()
            If _read.HasRows Then
                While _read.Read
                    If Left(_read.Item(0).ToString, 2) = "00" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "10"
                                s = "VWI - 0" + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "VWI - 00" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    ElseIf Left(_read.Item(0).ToString, 1) = "0" Then
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "100"
                                s = "VWI - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "VWI - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    Else
                        s1 = Right(_read.Item(0).ToString, 3)
                        s1 = s1 + 1
                        Select Case s1
                            Case "1000"
                                s = "VWI - " + "000" + "-" + "001"
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                            Case Else
                                s = "VWI - " + s1
                                idno = s
                                _read.Close()
                                _nSqlCommand.Dispose()
                                Return idno

                                Exit Function
                        End Select
                        s = "VWI - 0" + s1
                        idno = s
                        _read.Close()
                        _nSqlCommand.Dispose()
                    End If
                    'Select Case _read.Item(0).ToString
                    '    Case Left(_read.Item(0).ToString, 2) = "00"
                    '        s1 = Right(_read.Item(0).ToString, 3)
                    '        s1 = s1 + 1
                    '        s = "VWI - 00 " + s1
                    '        idno = s
                    '        _read.Close()
                    '        _nSqlCommand.Dispose()

                    '    Case Left(_read.Item(0).ToString, 1) = "0"
                    '    Case Left(_read.Item(0).ToString, 1) = "009"
                    '    Case Left(_read.Item(0).ToString, 1) = "099"



                    'End Select
                    Return idno

                End While
            Else
                s = "VWI - 001"
                idno = s
                _read.Close()
                _nSqlCommand.Dispose()
                Return idno

                Exit Function
            End If
            _read.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
        Return idno
    End Function




#End Region

#Region "Routines"
    Public Sub _pSubGetSpecificUser()
        Try
            '----------------------------------

            _pSubSelectUser()
            _pSubSelectBooklet()

            'Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

            '    '----------------------------------


            '    'Indexes
            '    With _nSqlDataReader
            '        Dim _iUser As Integer = .GetOrdinal("loginname")

            '        '----------------------------------
            '        Dim _nClassReturnTypes As New ClassReturnTypes
            '        With _nClassReturnTypes

            '            If _nSqlDataReader.HasRows Then
            '                Do While _nSqlDataReader.Read
            '                    _mUser = ._pReturnString(_nSqlDataReader(_iUser))
            '                Loop
            '            Else
            '                _mUser = ""
            '            End If

            '        End With
            '    End With

            '    _nSqlDataReader.Close()
            'End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
