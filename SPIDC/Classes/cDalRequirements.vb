

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports SPIDC.cEventLog
Imports System.Reflection.MethodBase
Imports SPIDC.cGlobalConnections
'Imports IMC.cBllGridView
Imports SPIDC.cRegisterScript

#End Region

Public Class cDalRequirements

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Private _mReqCode As String
    Private _mReqDesc As String
    Private _mIsComp As String
    Private _mReqAttachment As String
    Private _mReqYear As String
    Private _mStatus As String
    Private _mReqFileName As String
    Private _mReqFileType As String
    Private _mReqFileData As Byte()
    Private _mReviewMode As Boolean
    Private _mOwnCode As String
    Private _mUniqueID As String

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
                '_pSubEventLog(ex, 2)
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
                '_pSubEventLog(ex, 2)
                Return Nothing
            End Try
        End Get
    End Property
#End Region

#Region "Variables Field"

    Private _mAccount As String
    Private _mxImageID As String
#End Region

#Region "Properties Field"

    Public Property _pAccount() As String
        Get
            Return _mAccount
        End Get
        Set(ByVal value As String)
            _mAccount = value
        End Set
    End Property

    Public Property _pxImageID() As String
        Get
            Return _mxImageID
        End Get
        Set(ByVal value As String)
            _mxImageID = value
        End Set
    End Property

    Public Property _pReqCode() As String
        Get
            Return _mReqCode
        End Get
        Set(ByVal value As String)
            _mReqCode = value
        End Set
    End Property

    Public Property _pReqDesc() As String
        Get
            Return _mReqDesc
        End Get
        Set(ByVal value As String)
            _mReqDesc = value
        End Set
    End Property

    Public Property _pIsComp() As String
        Get
            Return _mIsComp
        End Get
        Set(ByVal value As String)
            _mIsComp = value
        End Set
    End Property

    Public Property _pReqAttachment() As String
        Get
            Return _mReqAttachment
        End Get
        Set(ByVal value As String)
            _mReqAttachment = value
        End Set
    End Property

    Public Property _pReqYear() As String
        Get
            Return _mReqYear
        End Get
        Set(ByVal value As String)
            _mReqYear = value
        End Set
    End Property
    Public Property _pStatus() As String
        Get
            Return _mStatus
        End Get
        Set(ByVal value As String)
            _mStatus = value
        End Set
    End Property

    Public Property _pReqFileName() As String
        Get
            Return _mReqFileName
        End Get
        Set(ByVal value As String)
            _mReqFileName = value
        End Set
    End Property

    Public Property _pReqFileType() As String
        Get
            Return _mReqFileType
        End Get
        Set(ByVal value As String)
            _mReqFileType = value
        End Set
    End Property

    Public Property _pReqFileData() As Byte()
        Get
            Return _mReqFileData
        End Get
        Set(ByVal value As Byte())
            _mReqFileData = value
        End Set
    End Property

    Public Property _pReviewMode() As Boolean
        Get
            Return _mReviewMode
        End Get
        Set(ByVal value As Boolean)
            _mReviewMode = value
        End Set
    End Property

    Public Property _pOwnCode() As String
        Get
            Return _mOwnCode
        End Get
        Set(ByVal value As String)
            _mOwnCode = value
        End Set
    End Property

    Public Property _pUniqueID() As String
        Get
            Return _mUniqueID
        End Get
        Set(ByVal value As String)
            _mUniqueID = value
        End Set
    End Property

#End Region

#Region "Properties Field Original"


#End Region

#Region "Routine Command"

    Public Sub _pSubSelectReqList_Renew() 'Added 20170918
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            '----------------------------------    
            _nQuery =
              "SELECT *,isnull((SELECT COUNT(*) FROM [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BP_SubmittedReq] B " & _
                    " where B.ReqCode COLLATE DATABASE_DEFAULT = REQ1.REQCODE  COLLATE DATABASE_DEFAULT" & _
                    " and B.Accountno COLLATE DATABASE_DEFAULT =  '" & _mAccount & "'  COLLATE DATABASE_DEFAULT " & _
                    " ),0) as ImageCount FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[REQ1] WHERE ISNULL([SWITCH],'NEW') = '" & _mStatus & "'"

            '_nQuery =
            '"SELECT * FROM [REQ1] WHERE SWITCH = 'RENEWAL' OR ISNULL(SWITCH,'')=''"

            ''"SELECT " & _
            ''"REQCODE, REQDESC " & _
            ''"FROM [REQ1] " & _
            '' " "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                ' _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelectReqList()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog
            ' @ Modified 20170913  Louie -- Add ImageCounter 
            '----------------------------------    

            _nQuery =
                "SELECT  [REQCODE],[REQDESC],[COMPLIANT],ISNULL([SWITCH],'NEW') as SWITCH,[OFFICE],[XSEQ],[XDEFAULT],isnull((SELECT COUNT(*) FROM [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BP_SubmittedReq] B  " & _
                "where B.ReqCode COLLATE DATABASE_DEFAULT = R.REQCODE  COLLATE DATABASE_DEFAULT and B.Foryear  = " & _
                "(SELECT YEAR(GETDATE()) as FORYEAR)  and B.Accountno COLLATE DATABASE_DEFAULT =  '" & _mAccount & "'  COLLATE DATABASE_DEFAULT  ),0) as ImageCount " & _
                "FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[REQ1] as R " & _
                "WHERE ISNULL([SWITCH],'NEW') = '" & _mStatus & "' " & _
                "AND REQCODE NOT IN (Select REQCODE from [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.REQ1EXTN where ISNULL([SWITCH],'NEW') = '" & _mStatus & "' AND OWNCODE COLLATE DATABASE_DEFAULT  <> (Select OWNCODE From [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.BUSMAST WHERE ACCTNO = '" & _mAccount & "')) "


            '"SELECT *,isnull((SELECT COUNT(*) FROM [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BP_SubmittedReq] B " & _
            '" where B.ReqCode COLLATE DATABASE_DEFAULT = REQ1.REQCODE  COLLATE DATABASE_DEFAULT and B.Foryear  = (SELECT YEAR(GETDATE()) as FORYEAR) " & _
            '" and B.Accountno COLLATE DATABASE_DEFAULT =  '" & _mAccount & "'  COLLATE DATABASE_DEFAULT " & _
            '" ),0) as ImageCount FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[REQ1] WHERE SWITCH = '" & _mStatus & "' OR ISNULL(SWITCH,'')=''"



            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                ' _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            '----------------------------------
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pGetRequirementList(ByVal _nUserID As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT [CODE] as REQCODE ,[DESCRIPTION] as REQDESC,[COMPLIANT],ISNULL([SWITCH],'NEW') as SWITCH,[OFFICE],[XSEQ],[XDEFAULT] " & _
                    " ,isnull((SELECT COUNT(*) FROM [BP_SubmittedReq] B  " & _
                    " where B.ReqCode COLLATE DATABASE_DEFAULT = (Select CODE FROM ##Tmp" & _nUserID & " WHERE TABLENAME = 'REQCODE') " & _
                    " COLLATE DATABASE_DEFAULT and B.Foryear  = " & _
                    " (SELECT YEAR(GETDATE()) as FORYEAR)  and B.Accountno COLLATE DATABASE_DEFAULT =  '" & _mAccount & "'  COLLATE DATABASE_DEFAULT  ),0) as ImageCount " & _
                    " from ##Tmp" & _nUserID & " WHERE TABLENAME = 'REQ1' " & _
                    " AND ISNULL([SWITCH],'NEW') = '" & _mStatus & "' AND CODE NOT IN  " & _
                    "(SELECT CODE from ##tmp" & _nUserID & " WHERE TABLENAME ='REQ1EXTN' and ISNULL([SWITCH],'NEW') = '" & _mStatus & "' " & _
                    " AND OWNCODE COLLATE DATABASE_DEFAULT  <> (Select OWNCODE From BUSMAST WHERE ACCTNO = '" & _mAccount & "'))"

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

        Catch ex As Exception

        End Try

    End Sub

    Public Sub _pSubSelectMandatorySubmitted() ' Added 20180306 For Check of Submitted Mandatory requirement
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog
            ' @ Modified 20170913  Louie -- Add ImageCounter 
            '----------------------------------    

            '_nQuery = _
            '    " WITH MANDATORY as ( " & _
            '    " SELECT *,isnull((SELECT COUNT(*) FROM [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BP_SubmittedReq] B " & _
            '    " where B.ReqCode COLLATE DATABASE_DEFAULT = REQ1.REQCODE  COLLATE DATABASE_DEFAULT and B.Foryear  = (SELECT YEAR(GETDATE()) as FORYEAR) " & _
            '    " and B.Accountno COLLATE DATABASE_DEFAULT =  '" & _mAccount & "'  COLLATE DATABASE_DEFAULT " & _
            '    " ),0) as ImageCount FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[REQ1] WHERE ISNULL([SWITCH],'NEW') = '" & _mStatus & "' " & _
            '    " AND REQCODE NOT IN (Select REQCODE from [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].REQ1EXTN where OWNCODE <> '" & _mOwnCode & "') " & _
            '    " AND COMPLIANT = 'COMPLIANCE' " & _
            '    " )SELECT * FROM MANDATORY WHERE ImageCount <> 0 "

            _nQuery = _
           " Select * from [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BP_SubmittedReq] R " & _
            " where R.REQCODE COLLATE DATABASE_DEFAULT in (SELECT REQCODE FROM  [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[REQ1] WHERE COMPLIANT = 'COMPLIANCE' AND ISNULL([SWITCH],'NEW') = '" & _mStatus & "' ) " & _
            " AND R.Foryear = (SELECT YEAR(GETDATE()) as FORYEAR) AND R.AccountNo = '" & _mAccount & "' "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) Then
                ' _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            '----------------------------------
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub
    Public Sub _pSubCheckMandatoryCompletion()
        Try
            'Dim _nQuery As String = Nothing
            'Dim _nWhere As String = Nothing

            Dim _nStrSql As String = Nothing

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            '_nQuery = "Select dbo.fn_CheckMandatoryCompletion('" & _nLiveServerName & "','" & _nLiveDatabaseName & "','" & _mAccount & "','" & _mStatus & "') as Result"
            '_nStrSql = "sp_CheckMandatoryCompletion "

            _nStrSql = "declare @Result as bit " & _
                "EXEC [sp_CheckMandatoryCompletion] " & _
                            "@LiveServer = N'" & _nLiveServerName & "' " & _
                            ",@LiveDatabase = N'" & _nLiveDatabaseName & "' " & _
                            ",@AcctNo = N'" & _mAccount & "' " & _
                            ",@Status = N'" & _mStatus & "' " & _
                            ",@Output = @Result output  " & _
                            "select @Result as Result"

            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            Dim paramOutput As New SqlParameter("@Output", SqlDbType.Bit)
            paramOutput.Direction = ParameterDirection.Output
            _mSqlCommand.Parameters.Add(paramOutput)


            _mSqlCommand.Dispose()

            '_mQuery = _nQuery & _nWhere

            '----------------------------------
            '_mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectMandatoryList() ' Added 20180306 For Check of Submitted Mandatory requirement
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog
            ' @ Modified 20170913  Louie -- Add ImageCounter 
            '----------------------------------    

            '_nQuery = "SELECT * FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[REQ1] WHERE COMPLIANT = 'COMPLIANCE' AND ISNULL([SWITCH],'NEW') = '" & _mStatus & "' " & _
            '        " AND REQCODE NOT IN (Select REQCODE from [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.REQ1EXTN where ISNULL([SWITCH],'NEW')  = '" & _mStatus & "' and  OWNCODE COLLATE DATABASE_DEFAULT <> (Select OWNCODE from  [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.BUSMAST Where ACCTNO = '" & _mAccount & "')) "

            _nQuery = "Select * FROM [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.REQ1 WHERE COMPLIANT = 'COMPLIANCE' AND ISNULL([SWITCH],'NEW') = '" & _mStatus & "' " & _
                        "AND REQCODE COLLATE DATABASE_DEFAULT NOT IN" & _
                        "(Select REQCODE from [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.REQ1EXTN " & _
                        "where ISNULL([SWITCH],'NEW') = '" & _mStatus & "' AND OWNCODE COLLATE DATABASE_DEFAULT  <> " & _
                        "(Select OWNCODE From BUSMAST WHERE ACCTNO = '" & _mAccount & "')) "


            '----------------------------------
            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            '----------------------------------
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub


    Public Sub _pSubSelect()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            '----------------------------------    
            _nQuery =
             "SELECT RSub.AccountNo, RSub.ForYear, RSub.ReqCode, RSet.ReqDesc " & _
            "FROM [" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.[BP_SubmittedReq] AS RSub " & _
            "INNER JOIN [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.[REQ1] AS RSet " & _
            "ON RSub.ReqCode = COLLATE DATABASE_DEFAULT  RSet.ReqCode " & _
            " "

            '"SELECT RSub.AccountNo, RSub.ForYear, RSub.ReqCode, RSet.ReqDesc, RAtt.[FileName] " & _
            '"FROM [BP_SubmittedReq] AS RSub " & _
            '"INNER JOIN [BP_Req_Attachment] AS RAtt " & _
            '"ON RSub.AccountNo = RAtt.AccountNo " & _
            '"INNER JOIN [REQ1] AS RSet " & _
            '"ON RSub.ReqCode = RSet.ReqCode " & _
            '" "
            ''  "SELECT ACCTNO, CODE, [DESCRIPTION], [FileName] FROM [BUS_REQUIREMENTS_WEB_TEMP] "  '@  Remarked 20161206

            ''"SELECT " & _
            ''"REQCODE, REQDESC " & _
            ''"FROM [REQ1] " & _
            '' " "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mAccount) And String.IsNullOrWhiteSpace(_mReqCode) And String.IsNullOrWhiteSpace(_mReqYear) Then
                _nWhere = "WHERE RSub.AccountNo = @_mAccount and RSub.ReqCode = RAtt.ReqCode "
            ElseIf Not String.IsNullOrWhiteSpace(_mAccount) And Not String.IsNullOrWhiteSpace(_mReqCode) And String.IsNullOrWhiteSpace(_mReqYear) Then
                _nWhere = "WHERE RSub.AccountNo = @_mAccount AND RSub.ReqCode = @_mReqCode " '' and RSub.ReqCode = RAtt.ReqCode "
            ElseIf Not String.IsNullOrWhiteSpace(_mAccount) And Not String.IsNullOrWhiteSpace(_mReqCode) And Not String.IsNullOrWhiteSpace(_mReqYear) Then
                _nWhere = "WHERE RSub.AccountNo = @_mAccount AND RSub.ReqCode = @_mReqCode AND RSub.ForYear = @_mReqYear " ' and RSub.ReqCode = RAtt.ReqCode "
            ElseIf Not String.IsNullOrWhiteSpace(_mAccount) And String.IsNullOrWhiteSpace(_mReqCode) And Not String.IsNullOrWhiteSpace(_mReqYear) Then
                _nWhere = "WHERE RSub.AccountNo = @_mAccount AND RSub.ForYear = @_mReqYear and " ' RSub.ReqCode = RAtt.ReqCode "
            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
            End With



            '----------------------------------
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub
    Public Sub _pSubSelectUploadedImages()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "Select AccountNo, ForYear, ReqCode, ImagesID, Name from BP_SubmittedReq "

            If _mReviewMode = False Then
                _nWhere = "Where AccountNo = '" & _mAccount & "' and ReqCode = '" & _mReqCode & "' and ForYear = (SELECT YEAR(GETDATE()) as FORYEAR)"
            Else
                _nWhere = "Where AccountNo = '" & _mAccount & "' and ReqCode = '" & _mReqCode & "' " & _
                    "and (ForYear = (SELECT YEAR(GETDATE()) as FORYEAR)   )"
            End If

            ' OR ForYear = (Select YEAR(APP_DATE) as YearApplied from BUSMAST WHERE ACCTNO = @_mAccount)
            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
            End With

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub


    Public Sub _pSubGetImageID_Temp()
        Try

            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "Select ImageID From Temp_BP_SubmittedReq "

            'If Not String.IsNullOrWhiteSpace(_mAccount) And String.IsNullOrWhiteSpace(_mReqYear) And String.IsNullOrWhiteSpace(_mReqCode) And String.IsNullOrWhiteSpace(_mxImageID) Then
            _nWhere = "Where UniqueID = '" & _mUniqueID & "' and ForYear = '" & _mReqYear & "' and ReqCode = '" & _pReqCode & "'"
            'Else
            '_nWhere = Nothing
            'End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubSelectReviewUploadedImages()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "Select ROW_NUMBER() over (ORDER BY ImagesID) AS Num, AccountNo, ForYear, ReqCode, ImagesID, Name from BP_SubmittedReq "

            _nWhere = "Where AccountNo = '" & _mAccount & "' and ReqCode = '" & _mReqCode & "'"

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
                'If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
            End With

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubSelectReqSubmitted() ' @ Added 20170824
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            'BPLTIMS WEB SERVER
            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            _nQuery = "SELECT RS.ACCOUNTNO, RQ.REQCODE ,RQ.REQDESC, RQ.COMPLIANT, RS.Name " & _
                        "FROM  [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.REQ1 as RQ " & _
                        "INNER JOIN " & _
                        "[" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.BP_SubmittedReq as RS " & _
                        "ON RQ.REQCODE COLLATE DATABASE_DEFAULT = RS.ReqCode COLLATE DATABASE_DEFAULT "

            '"Select * From BP_SubmittedReq "

            'If Not String.IsNullOrWhiteSpace(_mAccount) And String.IsNullOrWhiteSpace(_mReqYear) And String.IsNullOrWhiteSpace(_mReqCode) And String.IsNullOrWhiteSpace(_mxImageID) Then

            _nWhere = "WHERE RS.AccountNo = '" & _mAccount & "' AND RS.ForYear = '" & _mReqYear & "' AND  RQ.COMPLIANT = 'COMPLIANCE' "

            'Else
            '_nWhere = Nothing
            'End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
            End With


            '_nQuery = "Select * From BP_SubmittedReq "

            '_nWhere = "WHERE AccountNo = @_mAccount and ForYear = @_mReqYear "

            '_mQuery = _nQuery & _nWhere

            '_mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'With _mSqlCommand.Parameters
            '    If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            '    If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
            'End With

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub


    Public Sub _pSubSelectReqSubmittedRenewal() ' @ Added 20170824
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            'BPLTIMS WEB SERVER
            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            _nQuery = "SELECT RS.ACCOUNTNO, RQ.REQCODE ,RQ.REQDESC, RQ.COMPLIANT, RS.Name " & _
                        "FROM  [" & _nLiveServerName & "].[" & _nLiveDatabaseName & "].dbo.REQ1 as RQ " & _
                        "INNER JOIN " & _
                        "[" & _nWebServerName & "].[" & _nWebDatabaseName & "].dbo.BP_SubmittedReq as RS " & _
                        "ON RQ.REQCODE COLLATE DATABASE_DEFAULT = RS.ReqCode COLLATE DATABASE_DEFAULT "

            '"Select * From BP_SubmittedReq "

            'If Not String.IsNullOrWhiteSpace(_mAccount) And String.IsNullOrWhiteSpace(_mReqYear) And String.IsNullOrWhiteSpace(_mReqCode) And String.IsNullOrWhiteSpace(_mxImageID) Then
            _nWhere = "WHERE RS.AccountNo = '" & _mAccount & "' AND RS.ForYear = '" & _mReqYear & "' AND  RQ.COMPLIANT = 'COMPLIANCE' AND ISNULL(RQ.SWITCH,'NEW') <> 'NEW'"
            'Else
            '_nWhere = Nothing
            'End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
            End With


            '_nQuery = "Select * From BP_SubmittedReq "

            '_nWhere = "WHERE AccountNo = @_mAccount and ForYear = @_mReqYear "

            '_mQuery = _nQuery & _nWhere

            '_mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'With _mSqlCommand.Parameters
            '    If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            '    If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
            'End With

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubSelectSpecificFilename()
        Try

            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog


            _nQuery = "Select * From BP_SubmittedReq "

            'If Not String.IsNullOrWhiteSpace(_mAccount) And String.IsNullOrWhiteSpace(_mReqYear) And String.IsNullOrWhiteSpace(_mReqCode) And String.IsNullOrWhiteSpace(_mxImageID) Then
            _nWhere = "WHERE AccountNo = '" & _mAccount & "' AND ForYear = '" & _mReqYear & "' AND  Name = '" & _mReqFileName & "' AND  ReqCode = '" & _mReqCode & "'"
            'Else
            '_nWhere = Nothing
            'End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
                If Not String.IsNullOrWhiteSpace(_mReqFileName) Then .AddWithValue("@_mReqFileName", _mReqFileName)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
            End With

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pTemp_SubSelectSpecificFilename()
        Try

            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            _nQuery = "Select * From Temp_BP_SubmittedReq "

            _nWhere = "WHERE UniqueID = '" & _mUniqueID & "' AND ForYear = '" & _mReqYear & "' AND  Name = '" & _mReqFileName & "' AND  ReqCode = '" & _mReqCode & "'"

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub
    Public Sub _pSubSelectImageID()
        Try

            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "Select * From BP_SubmittedReq "

            'If Not String.IsNullOrWhiteSpace(_mAccount) And String.IsNullOrWhiteSpace(_mReqYear) And String.IsNullOrWhiteSpace(_mReqCode) And String.IsNullOrWhiteSpace(_mxImageID) Then
            _nWhere = "Where AccountNo = @_mAccount and ForYear = @_mReqYear and ReqCode = @_mReqCode and ImagesID = @_mxImageID"
            'Else
            '_nWhere = Nothing
            'End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
                If Not String.IsNullOrWhiteSpace(_mxImageID) Then .AddWithValue("@_mxImageID", _mxImageID)
            End With

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pSubSelectReqYear() ' @ Added 20180111 - LOUIE
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = "SELECT MAX(FORYEAR) SUBYEAR, YEAR(GETDATE()) CURYEAR FROM  BP_SubmittedReq WHERE AccountNo = '" & _mAccount & "' "

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            '_mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubInsertPreviousReq() ' @ Added 20180111 - LOUIE
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "INSERT INTO BP_SubmittedReq  " & _
                    "([AccountNo],  [ForYear], [ReqCode], [Remarks], [ToFollow], [RowId], [Name], [Size], [ImageData], [FileExtn]) " & _
                    "SELECT " & _
                    "[AccountNo],  '" & _mReqYear & "' [ForYear]  , [ReqCode], [Remarks], [ToFollow], [RowId], [Name], [Size], [ImageData], [FileExtn] " & _
                    "FROM " & _
                    "BP_SubmittedReq BP2 "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE " & _
                        "BP2.AccountNo = '" & _mAccount & "' AND BP2.FORYEAR = (SELECT MAX(ForYear) FROM BP_SubmittedReq " & _
                        "WHERE AccountNo = '" & _mAccount & "') "
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub


    Public Sub _pSubDeleteFrom_BUSMAST_WEB_Temp()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "DELETE FROM [BUSMAST_WEB_Temp] "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDeleteFrom_BUSMASTEXTN_WEB_Temp()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "DELETE FROM [BusinessInfoExtn] "


            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubDeleteFrom_BUS_REQUIREMENTS_WEB_TEMP()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "DELETE FROM [BUS_REQUIREMENTS_WEB_Temp] "

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With

            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubDeleteFrom_BUS_REQUIREMENTS_WEB()
        Try
            Dim _nQuery As String = Nothing 'Added 20161129
            Dim _nWhere As String = Nothing 'Added 20161129

            _nQuery =
            "DELETE FROM [BUS_REQUIREMENTS_WEB_TEMP] "  '<< FORMER BUS_REQUIREMENTS_WEB_TEMP

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE ACCTNO = @_mAccount AND CODE = @_mReqCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
            End With

            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pSubDeleteFrom_BP_SubmittedReq()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery =
            "DELETE FROM [BP_SubmittedReq] "  '<< FORMER BUS_REQUIREMENTS_WEB_TEMP

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE AccountNo = @_mAccount AND ReqCode = @_mReqCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
            End With

            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pSubDeleteFrom_BP_Req_Attachment()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery =
            "DELETE FROM [BP_Req_Attachment] "  '<< FORMER BUS_REQUIREMENTS_WEB_TEMP

            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE AccountNo = @_mAccount AND ReqCode = @_mReqCode"
            Else
                _nWhere = Nothing
            End If

            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
            End With

            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub


    Public Sub _pSubInsertInto_BUSMASTEXTN_WEB()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "INSERT INTO [BUSMASTEXTN_WEB] " & _
                    "SELECT * FROM [BUSMASTEXTN_WEB_Temp] "


            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubInsertInto_BUS_REQUIREMENTS_WEB()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "INSERT INTO [BUS_REQUIREMENTS_WEB] " & _
                    "SELECT * FROM [BUS_REQUIREMENTS_WEB_TEMP] "


            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubInsertInto_BUSMAST_WEB()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                    "INSERT INTO [BUSMAST_WEB] " & _
                    "SELECT * FROM [BUSMAST_WEB_Temp] "


            If Not String.IsNullOrWhiteSpace(_mAccount) Then

                _nWhere = "WHERE [ACCTNO] = @_mAccount "
            Else
                _nWhere = Nothing
            End If


            _mQuery = _nQuery & _nWhere

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
            End With


            _mSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try
    End Sub

    Public Sub _pSubReqinsert()
        Try
            Dim _nQuery As String = Nothing ' For For Requirements module 20161114

            _nQuery = _
             "INSERT INTO " & _
              "[BP_SubmittedReq] " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " [ACCOUNTNO]") & _
              IIf(String.IsNullOrWhiteSpace(_mReqYear), "", ", [FORYEAR]") & _
              IIf(String.IsNullOrWhiteSpace(_mReqCode), "", ", [REQCODE]") & _
              ") " & _
              "VALUES " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " @_mAccount") & _
              IIf(String.IsNullOrWhiteSpace(_mReqYear), "", ", @_mReqYear") & _
              IIf(String.IsNullOrWhiteSpace(_mReqCode), "", ", @_mReqCode") & _
              ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(") ' INSERT INTO BUSMAST_WEB

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
            End With

            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pSubExecuteDeleteImage()
        Try
            Dim _nQuery As String = Nothing ' For For Requirements module 20170323
            Dim _nWhere As String = Nothing


            _nQuery = _
             "DELETE FROM " & _
              "[BP_SubmittedReq] "

            _nWhere = "Where AccountNo = @_mAccount and ForYear = @_mReqYear and ReqCode = @_mReqCode and ImagesID = @_mxImageID"

            _mQuery = _nQuery & _nWhere


            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
                If Not String.IsNullOrWhiteSpace(_mxImageID) Then .AddWithValue("@_mxImageID", _mxImageID)
            End With

            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            ''_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pSubReqinsert_Attachment()
        Try
            Dim _nQuery As String = Nothing ' For Requirements module 20161114

            _nQuery = _
             "INSERT INTO " & _
              "[BP_Req_Attachment] " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " [ACCOUNTNO]") & _
              IIf(String.IsNullOrWhiteSpace(_mReqYear), "", ", [FORYEAR]") & _
              IIf(String.IsNullOrWhiteSpace(_mReqCode), "", ", [REQCODE]") & _
              IIf(String.IsNullOrWhiteSpace(_mReqAttachment), "", ", [FileName]") & _
              IIf(String.IsNullOrWhiteSpace(_mReqFileType), "", ", [FileType]") & _
              IIf(String.IsNullOrWhiteSpace(_mReqAttachment), "", ", [FileData]") & _
              ") " & _
              "VALUES " & _
              "(" & _
              IIf(String.IsNullOrWhiteSpace(_mAccount), "", " @_mAccount") & _
              IIf(String.IsNullOrWhiteSpace(_mReqYear), "", ", @_mReqYear") & _
              IIf(String.IsNullOrWhiteSpace(_mReqCode), "", ", @_mReqCode") & _
              IIf(String.IsNullOrWhiteSpace(_mReqAttachment), "", ", @_mReqAttachment") &
              IIf(String.IsNullOrWhiteSpace(_mReqFileType), "", ", @_mReqFileType") & _
              IIf(String.IsNullOrWhiteSpace(_mReqAttachment), "", ", @_mReqFileData") & _
              ") "

            _mQuery = _nQuery

            _mQuery = Replace(_mQuery, "(,", "(") ' INSERT INTO BUSMAST_WEB

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mAccount) Then .AddWithValue("@_mAccount", _mAccount)
                If Not String.IsNullOrWhiteSpace(_mReqYear) Then .AddWithValue("@_mReqYear", _mReqYear)
                If Not String.IsNullOrWhiteSpace(_mReqCode) Then .AddWithValue("@_mReqCode", _mReqCode)
                If Not String.IsNullOrWhiteSpace(_mReqAttachment) Then .AddWithValue("@_mReqAttachment", _mReqAttachment)
                If Not String.IsNullOrWhiteSpace(_mReqFileType) Then .AddWithValue("@_mReqFileType", _mReqFileType)
                If Not String.IsNullOrWhiteSpace(_mReqAttachment) Then .AddWithValue("@_mReqFileData", _mReqFileData)
            End With

            _mSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            '_pSubEventLog(ex, 2)
        End Try

    End Sub

    Public Sub _pLoad(Optional _nStatus As String = "", _
                                Optional _nAcctNo As String = "")
        Try


            Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBPLTIMS._pSubRecordSelectSpecific()

            Dim _nWebServerName As String = _nClBPLTIMS._pDBDataSource
            Dim _nWebDatabaseName As String = _nClBPLTIMS._pDBInitialCatalog

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            Dim _nStrSql As String

            'Initialize String SQL

            _nStrSql = "EXEC(sp_SelectReqList)" & _
                     "@LiveServer = N'" & _nLiveServerName & "'" & _
                     ",@LiveDatabase = N'" & _nLiveDatabaseName & "'" & _
                     ",@Websever = N'" & _nWebServerName & "'" & _
                     ",@WebDatabase = N'" & _nWebDatabaseName & "'" & _
                     ",@Status = N'" & _nStatus & "'" & _
                     ",@AcctNo = N'" & _nAcctNo & "'"


            _mSqlCommand = New SqlCommand(_nStrSql, _mSqlCon)

            'set paramater Success
            '_mSqlCommand.Parameters.Add("@Successful", SqlDbType.Bit)
            '_mSqlCommand.Parameters("@Successful").Direction = ParameterDirection.Output
            ''set paramater Error Msg
            '_mSqlCommand.Parameters.Add("@ErrMsg", SqlDbType.NVarChar, 2000)
            '_mSqlCommand.Parameters("@ErrMsg").Direction = ParameterDirection.Output

            'Execute and Read the content with datareader
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then

                    _mDataTable.Clear() 'clear datatable content
                    _mDataTable.Columns.Clear() 'clear datatable columns

                    'Loading Record from datareader to datatable
                    _mDataTable.Load(_nSqlDr)
                End If
            End Using
            'Get values of parameter output
            '_nSuccessful = _mSqlCmd.Parameters("@Successful").Value
            '_nErrMsg = _mSqlCmd.Parameters("@ErrMsg").Value

            _mSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
