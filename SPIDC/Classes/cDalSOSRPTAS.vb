

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalSOSRPTAS

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mQuery2 As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader


    'Private connetionString As String
    'Private Shared connection As SqlConnection
    'Private Shared sql As String

    Public Shared _ctrAL As Integer
    Public Shared _ctrERPT As Integer
    Public Shared _ctrNRPT As Integer
    Public Shared _ctrAR As Integer

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

#Region "Variables Field"


    Private _mOrigTDN As String
    Private _mTDN As String
    Private _mORNO As String
    Private _mStatus As String
    Private _mEmail As String
    Private _mFieldsWhere As String
    Private _mLocServer As String
    Private _mLocDB As String
    Private _mstrdt As String
#End Region

#Region "Properties Field"
    Public Property _pstrdt() As String
        Get
            Return _mstrdt
        End Get
        Set(ByVal value As String)
            _mstrdt = value
        End Set
    End Property
    Public Property _pLocServer() As String
        Get
            Return _mLocServer
        End Get
        Set(ByVal value As String)
            _mLocServer = value
        End Set
    End Property
    Public Property _pLocDB() As String
        Get
            Return _mLocDB
        End Get
        Set(ByVal value As String)
            _mLocDB = value
        End Set
    End Property
    Public Property _pFieldsWhere() As String
        Get
            Return _mFieldsWhere
        End Get
        Set(ByVal value As String)
            _mFieldsWhere = value
        End Set
    End Property

    Public Property _pOrigTDN() As String
        Get
            Return _mOrigTDN
        End Get
        Set(ByVal value As String)
            _mOrigTDN = value
        End Set
    End Property

    Public Property _pTDN() As String
        Get
            Return _mTDN
        End Get
        Set(ByVal value As String)
            _mTDN = value
        End Set
    End Property
    Public Property _pORNO() As String
        Get
            Return _mORNO
        End Get
        Set(ByVal value As String)
            _mORNO = value
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
    Public Property _pEmail() As String
        Get
            Return _mEmail
        End Get
        Set(ByVal value As String)
            _mEmail = value
        End Set
    End Property
#End Region

#Region "Routine Command"

    Public Sub _pSubSelectAddress()
        'Try
        '    '----------------------------------
        '    'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------    
        '    _nQuery = _
        '       "SELECT " & _
        '       "* " & _
        '       "FROM [PDSAddress] " & _
        '        " "

        '    '----------------------------------    
        '    If Not String.IsNullOrWhiteSpace(_mIDNo) Then

        '        _nWhere = "WHERE [IDNo] = @_mIDNo "

        '    Else
        '        _nWhere = Nothing
        '    End If

        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere


        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

        '    End With

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubInsert()
        'Try
        '    '----------------------------------
        '    If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub


        '    '----------------------------------
        '    Dim _nQuery As String = Nothing

        '    '----------------------------------
        '    _nQuery = _
        '     "INSERT INTO " & _
        '     "[PDSAddress] " & _
        '     "(" & _
        '        IIf(String.IsNullOrWhiteSpace(_mIDNo), "", " [IDNo]") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress1), "", ", [Address1]") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", [Address2]") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", [Address3]") & _
        '        IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", [ZipCode]") & _
        '        IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", [TelNo]") & _
        '            IIf((_mDefault) = Nothing, "", ", [Default]") & _
        '     ") " & _
        '     "VALUES " & _
        '     "(" & _
        '        IIf(String.IsNullOrWhiteSpace(_mIDNo), "", " @_mIDNo") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress1), "", ", @_mAddress1") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", @_mAddress2") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", @_mAddress3") & _
        '        IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", @_mZipCode") & _
        '        IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", @_mTelNo") & _
        '            IIf((_mDefault) = Nothing, "", ", @_mDefault") & _
        '     ") "

        '    '----------------------------------
        '    _mQuery = _nQuery

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

        '        If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
        '        If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
        '        If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)

        '        If Not String.IsNullOrWhiteSpace(_mZipCode) Then .AddWithValue("@_mZipCode", _mZipCode)
        '        If Not String.IsNullOrWhiteSpace(_mTelNo) Then .AddWithValue("@_mTelNo", _mTelNo)

        '        If Not (_mDefault) = Nothing Then .AddWithValue("@_mDefault", _mDefault)

        '    End With

        '    _mSqlCommand.ExecuteNonQuery()



        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubUpdate()
        'Try
        '    '----------------------------------
        '    'Check Required Fields...
        '    If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress2) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress3) Then Exit Sub

        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------
        '    _nQuery = _
        '        "UPDATE " & _
        '        "[PDSAddress] " & _
        '        "SET " & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress1), "", " [Address1] = @_mAddress1") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", [Address2] = @_mAddress2") & _
        '            IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", [Address3] = @_mAddress3") & _
        '                IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", [ZipCode] = @_mZipCode") & _
        '                IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", [TelNo] = @_mTelNo") & _
        '            IIf((_mDefault) = Nothing, "", ", [Default] = @_mDefault") & _
        '        " "

        '    '----------------------------------

        '    If Not String.IsNullOrWhiteSpace(_mIDNo) Then

        '        _nWhere = "WHERE [IDNo] = @_mIDNo "
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress1) Then _nWhere += "AND [Address1] = @_mOrigAddress1 "
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress2) Then _nWhere += "AND [Address2] = @_mOrigAddress2 "
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress3) Then _nWhere += "AND [Address3] = @_mOrigAddress3 "

        '    Else
        '        _nWhere = Nothing

        '    End If



        '    '----------------------------------
        '    'Prevent Bulk Update.
        '    If _nWhere = Nothing Then
        '        Exit Sub
        '    End If

        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)
        '        If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
        '        If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
        '        If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)
        '        If Not String.IsNullOrWhiteSpace(_mZipCode) Then .AddWithValue("@_mZipCode", _mZipCode)
        '        If Not String.IsNullOrWhiteSpace(_mTelNo) Then .AddWithValue("@_mTelNo", _mTelNo)
        '        If Not String.IsNullOrWhiteSpace(_mDefault) Then .AddWithValue("@_mDefault", _mDefault)

        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress1) Then .AddWithValue("@_mOrigAddress1", _mOrigAddress1)
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress2) Then .AddWithValue("@_mOrigAddress2", _mOrigAddress2)
        '        If Not String.IsNullOrWhiteSpace(_mOrigAddress3) Then .AddWithValue("@_mOrigAddress3", _mOrigAddress3)
        '        If Not String.IsNullOrWhiteSpace(_mOrigZipCode) Then .AddWithValue("@_mOrigZipCode", _mOrigZipCode)
        '        If Not String.IsNullOrWhiteSpace(_mOrigTelNo) Then .AddWithValue("@_mOrigTelNo", _mOrigTelNo)
        '        'If Not String.IsNullOrWhiteSpace(_mOrigName) Then .AddWithValue("@_mOrigName", _mOrigName)

        '    End With


        '    _mSqlCommand.ExecuteNonQuery()

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubDelete()
        'Try
        '    '----------------------------------
        '    If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress2) Then Exit Sub
        '    If String.IsNullOrWhiteSpace(_mAddress3) Then Exit Sub

        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------
        '    _nQuery = _
        '        "DELETE FROM " & _
        '        "[PDSAddress] " & _
        '        " "

        '    '----------------------------------
        '    If Not String.IsNullOrWhiteSpace(_mIDNo) Then

        '        _nWhere = "WHERE [IDNo] = @_mIDNo "
        '        If Not String.IsNullOrWhiteSpace(_mAddress1) Then _nWhere += "AND [Address1] = @_mAddress1 "
        '        If Not String.IsNullOrWhiteSpace(_mAddress2) Then _nWhere += "AND [Address2] = @_mAddress2 "
        '        If Not String.IsNullOrWhiteSpace(_mAddress3) Then _nWhere += "AND [Address3] = @_mAddress3 "

        '    Else
        '        _nWhere = Nothing
        '    End If

        '    '----------------------------------
        '    'Prevent Bulk Deletion.
        '    If _nWhere = Nothing Then
        '        Exit Sub
        '    End If

        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

        '        If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
        '        If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
        '        If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)

        '    End With

        '    _mSqlCommand.ExecuteNonQuery()

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubGetServerDate()

        'Try
        '    '----------------------------------
        '    'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------    

        '    ''  SELECT convert(nvarchar(8),getdate(),112) +  replace(convert(nvarchar(15),getdate(),114),':','') AS ServerDateTime
        '    _nQuery = _
        '                     "SELECT " & _
        '       " convert(nvarchar(8),getdate(),112) +  replace(convert(nvarchar(15),getdate(),114),':','') AS ServerDateTime " & _
        '       " "
        '    '----------------------------------    


        '    '_nWhere = "WHERE [IDNo] = @_mIDNo "
        '    '_nWhere += "OR [IDNoRegistered] = @_mIDNoRegistered "
        '    'If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then
        '    '    _nWhere += "AND [BusinessAccountNumber] = @BusinessAccountNumber "
        '    'End If



        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters


        '        '.AddWithValue("@_mIDNo", IIf(String.IsNullOrWhiteSpace(_mIDNo), "", _mIDNo))
        '        '.AddWithValue("@_mIDNoRegistered", IIf(String.IsNullOrWhiteSpace(_mIDNoRegistered), "", _mIDNoRegistered))


        '    End With

        '    '----------------------------------
        'Catch ex As Exception

        'End Try

    End Sub


    Public Sub _pValidateTdn(Optional ByRef Err As String = Nothing, Optional ByRef Qry As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = ""

            _nQuery = " EXEC [SP_VALIDATETDN] @TDN = '" & _mTDN & "' ,@ORNO = '" & _mORNO & "' ,@EMAIL = '" & Replace(_mEmail, ".", "") & "',@RP_SERVERDB='" & _mLocServer & "',@RP_LOCALDB='" & _pLocDB & "',@EMAIL2 = '" & _mEmail & "' ,@STATUS = @STATUS output "
            '_nQuery = " EXEC [SP_VALIDATETDN] @TDN = '" & _mTDN & "' ,@ORNO = '" & _mORNO & "' ,@EMAIL = '" & _mEmail & "',@RP_SERVERDB='" & _mLocServer & "',@RP_LOCALDB='" & _pLocDB & "' ,@STATUS = @STATUS output "

            Qry = _nQuery

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)



            _mSqlCommand.Parameters.Add("@STATUS", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@STATUS").Direction = ParameterDirection.Output
            'Execute and Read the content

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _mTDN = _nSqlDr.Item(0).ToString
                    Loop
                End If

            End Using
            'Get values of parameter output


            _mStatus = _mSqlCommand.Parameters("@STATUS").Value

            _mSqlCommand.Dispose()
        Catch ex As Exception
            Err = ex.Message
        End Try


    End Sub
    Public Sub _pSubSelect()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '                 "SELECT " & _
            '   " * " & _
            '   "FROM [rptdetail] where email='" & _mEmail & "' " & _
            '   " "

            'rhogiel20200706
            _nQuery = _
                             "SELECT " & _
               " * " & _
               "FROM [rptdetail] where email='" & _mEmail & "' " & _
               "AND VERIFIED = '1'" & _
               " "
            '----------------------------------    


            '_nWhere = "WHERE [IDNo] = @_mIDNo "
            '_nWhere += "OR [IDNoRegistered] = @_mIDNoRegistered "
            'If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then
            '    _nWhere += "AND [BusinessAccountNumber] = @BusinessAccountNumber "
            'End If



            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            _mstrdt = ""

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader

                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _mstrdt = _mstrdt & _nSqlDr.Item(1).ToString & ":" & "true;"
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectPending()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = "select * from OnlinePaymentRefno where ACCTNO in(select assessno from " & _mLocDB & ".dbo.Assess_FrmNewBilling_A where tdn in (" & _mTDN & ")) and replace(EMAILADDR,'.','') ='" & _mEmail & "' and year(transdate) =  Year(getdate()) and isnull(PostedDate,'1900/01/01') = '1900/01/01' and StatusID <> 'SUCCESS' "
            ' _nQuery = "select * from OnlinePaymentRefno where ACCTNO in(select assessno from " & _mLocDB & ".dbo.Assess_FrmNewBilling_b where tdn in (" & _mTDN & ")) and replace(EMAILADDR,'.','') ='" & _mEmail & "' and year(transdate) =  Year(getdate()) and isnull(PostedDate,'1900/01/01') = '1900/01/01' and StatusID='SUCCESS' "
            '         "select * from OnlinePaymentRefno where ACCTNO in(select assessno from " & _mLocDB & ".dbo.Assess_FrmNewBilling_b where tdn in (" & _mTDN & ")) and replace(EMAILADDR,'.','') ='" & _mEmail & "' and isnull(PostedDate,'1900/01/01') = '1900/01/01' and StatusID='SUCCESS' "


            '     "select * from OnlinePaymentRefno where ACCTNO = '" & _mTDN & "' and replace(EMAILADDR,'.','') ='" & _mEmail & "' and [Status] = 'Pending' " & _
            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubfilter()

        'Try
        '    '----------------------------------
        '    'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

        '    '   If _mTDN = "" Then Exit Sub
        '    '----------------------------------
        '    Dim _nQuery As String = Nothing
        '    Dim _nWhere As String = Nothing

        '    '----------------------------------    
        '    _nQuery = _
        '            "SELECT  " & _
        '            "R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
        '            "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
        '            "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE  " & _
        '            "FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO  " & _
        '            "WHERE (R.REGION+R.PROV+R.CITY in (select REGION+PROV+CODE from city)) " & _
        '            " and R.TDN in (select TDN from tdnperemail where EMAILADDRESS='" & _mEmail & "') " & _
        '            "union " & _
        '            "SELECT  R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
        '            "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
        '            "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE  " & _
        '            "FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO  " & _
        '            "where R.region+R.PROV+R.CITY+R.tdn in  " & _
        '            "(select region+PROV+CITY+reference_tdn " & _
        '            "from PROPERTY_OTHERLAND_REF where region+PROV+CITY+tdn  in  " & _
        '            "(SELECT  R.region+R.PROV+R.CITY+R.TDN   FROM  RPTMAST R  " & _
        '            "WHERE (R.REGION+R.PROV+R.CITY in (select REGION+PROV+CODE from city)) )) " & _
        '            " and R.TDN in (select TDN from tdnperemail where EMAILADDRESS='" & _mEmail & "') " & _
        '            " order by R.PIN " & _
        '            ""





        '    '----------------------------------
        '    _mQuery = _nQuery & _nWhere

        '    '----------------------------------
        '    _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

        '    With _mSqlCommand.Parameters

        '        If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)



        '    End With

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub


    Public Sub _pSubGetSpecificRecord_getid()
        'Try
        '    '----------------------------------
        '    _pSubGetServerDate()

        '    Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

        '        '----------------------------------
        '        'Indexes
        '        With _nSqlDataReader
        '            Dim _ServerDateTime As Integer = .GetOrdinal("ServerDateTime")

        '            '----------------------------------
        '            Dim _nClassReturnTypes As New ClassReturnTypes
        '            With _nClassReturnTypes

        '                If _nSqlDataReader.HasRows Then
        '                    Do While _nSqlDataReader.Read

        '                        _mctr_no = ._pReturnString(_nSqlDataReader(_ServerDateTime))


        '                    Loop
        '                Else
        '                    _mctr_no = 1
        '                End If



        '            End With
        '        End With

        '        _nSqlDataReader.Close()
        '    End Using

        '    '----------------------------------
        'Catch ex As Exception

        'End Try
    End Sub
    Public Sub _pSubGetGross() 'Get Gross 
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETMULTIPLE] '" & _mTDN & "','" & _mEmail & "'"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing
            ''End If

            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _getNotificationCtr_RPT()
        Try
            Dim _nQuery As String =
                " select " & _
                " (select count(*) from 	(" & _
                " SELECT *,  CASE WHEN GENDER = 'M' THEN 'Male'  ELSE 'Female' END AS GENDERCOMPLETE FROM SOS_RPT_CAINTA.dbo.RPTDETAIL b " & _
                " INNER JOIN [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.Registered r ON b.EMAIL2 = r.UserID WHERE b.Verified = '0' or b.Verified IS NULL " & _
                " )as subq)ctrERPT," & _
                " (SELECT  COUNT(*) FROM [RPTASMastNew] )ctrNRPT," & _
                " (select count(*) from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.Appointment where office='ASSESSOR' and Status='Pending' and appdate = format(getdate(),'yyyy-MM-dd'))ctrAL," &
                "  (select count(*) from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.Appointment where office='ASSESSOR' and Status='Pending Approval')ctrAR"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _ctrAL = _nSqlDr("ctrAL").ToString
                        _ctrERPT = _nSqlDr("ctrERPT").ToString
                        _ctrNRPT = _nSqlDr("ctrNRPT").ToString
                        _ctrAR = _nSqlDr("ctrAR").ToString
                    Loop
                End If
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Public Function _getNameEmail(ByVal acctno As String, ByRef TPName As String, ByRef TPEmail As String) As Boolean
        Dim hasRows As Boolean = False
        Try
            Dim _nQuery As String =
                " SELECT EMAIL2,OWNERNAME FROM RPTDETAIL WHERE TDN='" & acctno & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasRows = True
                    Do While _nSqlDr.Read
                        TPName = _nSqlDr("OWNERNAME").ToString
                        TPEmail = _nSqlDr("EMAIL2").ToString
                    Loop
                Else
                    hasRows = False
                End If
            End Using
            Return hasRows
        Catch ex As Exception
            Return hasRows
        End Try
    End Function

    '------------TOMI START
    Public Function isDelinquent(ByVal TDN As String, ByRef Err As String) As Boolean
        Dim Delinquent As Boolean
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            ' _nQuery = " SELECT top 1 L.TDN,P.ORNO,L.FOR_YEAR,L.LQP FROM LEDGER  L" & _
            '           " INNER JOIN PAYMENT P ON L.TDN=P.TDN" & _
            '           " WHERE L.TAX_CODE='BASIC' AND L.FOR_YEAR=YEAR(GETDATE())-1 AND L.LQP='4' AND L.TDN=" & TDN & " order by p.orno desc"

            _nQuery = " SELECT top 1 L.TDN,P.ORNO,L.FOR_YEAR,L.LQP FROM LEDGER  L" &
                      " INNER JOIN PAYMENT P ON L.TDN=P.TDN" &
                      " WHERE L.TAX_CODE='BASIC'  AND L.TDN=" & TDN &
                      " AND (L.FOR_YEAR=YEAR(GETDATE())-1 AND L.LQP='4') OR " &
                      " L.FOR_YEAR=YEAR(GETDATE())" &
                      " order by p.orno desc"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    Delinquent = False
                Else
                    Delinquent = True
                End If
            End Using
            Err = "OK"
            _mSqlCommand.Dispose()
        Catch ex As Exception
            Delinquent = True
            Err = ex.Message
        End Try
        Return Delinquent
    End Function

    Public Function hasTaxCredit(ByVal TDN As String, ByRef Err As String) As Boolean
        Dim _hasTaxCredit As Boolean
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = " select tdn from ledger where Tax_credit > 0 and tdn=" & TDN & "" &
                      " group by tdn,For_year" &
                      " having for_year = max(for_year)"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    _hasTaxCredit = True
                Else
                    _hasTaxCredit = False
                End If
            End Using
            Err = Nothing
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _hasTaxCredit = False
            Err = ex.Message
        End Try
        Return _hasTaxCredit
    End Function

    Public Function hasSHORT(ByVal TDN As String, ByRef Err As String) As Boolean
        Dim _hasSHORT As Boolean
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = " select tdn from ledger where Short_Amt > 0 and tdn=" & TDN & "" &
                      " group by tdn,For_year" &
                      " having for_year = max(for_year)"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    _hasSHORT = True
                Else
                    _hasSHORT = False
                End If
            End Using
            Err = Nothing
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _hasSHORT = False
            Err = ex.Message
        End Try
        Return _hasSHORT
    End Function

    Public Function hasTag(ByVal TDN As String, ByVal TAG As String, ByRef Err As String) As Boolean
        Dim _hasTag As Boolean
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = " select *  from rptmast" &
                      " where PROP_TAG IN (SELECT CODE FROM PROPTAG_tbl where Description like '%" & TAG & "%')" &
                      " and tdn=" & TDN & ""
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    _hasTag = True
                Else
                    _hasTag = False
                End If
            End Using
            Err = Nothing
            _mSqlCommand.Dispose()
        Catch ex As Exception
            _hasTag = False
            Err = ex.Message
        End Try
        Return _hasTag
    End Function

    Public Sub _pSubSelect_GVGR()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "" &
                " select distinct R.TDN as new_TDN,R.cancels as old_TDN,W.Email,W.Email2 " &
                " from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.mastextn R" &
                " INNER JOIN [" & cGlobalConnections._pSqlCxn_RPTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.RPTDETAIL W" &
                " on R.cancels = W.TDN" &
                " and R.region = 'NCR'" &
                " and isnull(W.Old_TDN,'0') = '0'" &
                " and len(w.email2) > 0" &
                " order by w.Email2"


            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Process_GR(ByVal ctr As Integer, Optional ByRef MainErr As String = Nothing, Optional ByVal TestEmail As String = Nothing, Optional ByVal SkipTDN As String = Nothing)
        Try
            Dim err As String = Nothing
            Dim Sent As Boolean = False
            Dim Old_TDN As String = Nothing
            Dim New_TDN As String = Nothing
            Dim Email2 As String = Nothing

            Dim skipcondition As String = Nothing
            If String.IsNullOrEmpty(SkipTDN) = False Then
                skipcondition = " and R.Cancels not in (" & SkipTDN & ")"
            End If

            Dim _nQuery As String =
                " select distinct top " & ctr & "  R.TDN as new_TDN,R.cancels as old_TDN,W.Email,W.Email2 " &
                " from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.mastextn R" &
                " INNER JOIN [" & cGlobalConnections._pSqlCxn_RPTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.RPTDETAIL W" &
                " on R.cancels = W.TDN" &
                " and R.region = 'NCR'" &
                " and isnull(W.Old_TDN,'0') = '0'" &
                " and len(w.email2) > 0" &
                skipcondition &
                " order by w.Email2"
            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        Old_TDN = _nSqlDr("old_TDN").ToString
                        New_TDN = _nSqlDr("new_TDN").ToString
                        If String.IsNullOrEmpty(TestEmail) Then
                            Email2 = _nSqlDr("Email2").ToString
                        Else
                            Email2 = TestEmail
                        End If

                        If Email2 = TestEmail Then

                        Else
                            Dim _nClassHistory As New cDalTransactionHistory
                            _nClassHistory._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                            _nClassHistory._pSubInsertHistory("-", Email2, "RPT", "General Revision", "TDN:" & Old_TDN, _
                                    "Changed TDN from [" & Old_TDN & "] to [" & New_TDN & "]", _
                                    "SUCCESS")
                            Update_TDN(Old_TDN, New_TDN, Email2, err)
                        End If


                        If String.IsNullOrEmpty(err) Then
                            'do notify taxpayer
                            Dim txtContent As String =
                                "Dear Valued Taxpayer, <br>" &
                                "We would like to inform you that we made General Revision for your Real Property: <br>" &
                                "We updated your  TDN from [" & Old_TDN & "] to [" & New_TDN & "]  <br>" &
                                "Your New TDN is : [<b>" & New_TDN & "<b>]"

                            cDalNewSendEmail.SendEmail(Email2, "TDN Adjustment", txtContent, Sent, err)
                            If Sent = False Then
                                MainErr = "SendEmail Err : " & err
                                Exit Sub
                            End If
                        Else
                            MainErr += err
                            '    Exit Sub
                        End If
                    Loop
                End If
            End Using
        Catch ex As Exception
            MainErr = "Process_GR : " & ex.Message
        End Try


    End Sub
    Public Sub Update_TDN(ByVal Old_TDN As String, ByVal New_TDN As String, ByVal Email As String, Optional ByRef ERR As String = Nothing)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                 " update [" & cGlobalConnections._pSqlCxn_RPTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.RPTDETAIL set tdn = '" & New_TDN & "',OLD_TDN = '" & Old_TDN & "' where Email2='" & Email & "' and TDN='" & Old_TDN & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            ERR = "Update_TDN(" & Old_TDN & "," & New_TDN & "," & Email & ") : ERR " & ex.Message
        End Try
    End Sub


    Public Function ExistsInRPTMAST(ByVal TDN As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim _xQuery As String = _
             " select * from RPTMAST where tdn=" & TDN & ""
            _mSqlCommand = New SqlCommand(_xQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then result = True
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function

#End Region

End Class
