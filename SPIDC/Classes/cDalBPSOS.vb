
#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods

#End Region
Public Class cDalBPSOS

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mQuery2 As String = Nothing
    Private _mTempTblBT As String
    Private _mSqlCommand As SqlCommand
    Private _mSqlCommand2 As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader
    Public Shared _nOutput As String
    Public Shared _nOutDesc As String '@Added by Louie
    Public Shared _nBusDesc As String
    Public Shared _nOwner As String
    Public Shared _nEmail As String
    Public Shared _nMOP As String
    Public Shared _nBusName As String
    Public Shared _nBusAddress As String
    Public Shared _nBusCategory As String
    Public Shared _nBusCategory1 As String
    Public Shared _nPrevGross As Double
    Public Shared _nArea As Double
    Public Shared _nTotalDue As Double
    Public Shared _nBusCode As String
    Public Shared _nLastName As String
    Public Shared _nFirstName As String
    Public Shared _nMidName As String
    Public Shared _nGender As String
    Public Shared _nSuffix As String
    Public Shared _nOwnerAdd As String
    Public Shared _nCommAdd As String
    Public Shared _nCommName As String
    Public Shared _nBrgy As String
    Public Shared _nCommBrgy As String
    Public Shared _nZipCode As String
    Public Shared _nCommZipCode As String
    Public Shared _nCpNo As String
    Public Shared _nTelNo As String
    Public Shared _nEmailNo As String
    Public Shared _nTotalGross As String
    Public Shared _nSTQuery As String
    Public Shared _nCurYear As String
    Public Shared _nCurMonth As String
    Public Shared _nCurDate As String
    Public Shared _mShareAcctNo As String

    Public Shared _ctrEBP As Integer
    Public Shared _ctrRBP As Integer
    Public Shared _ctrNBP As Integer
    Public Shared _ctrAL As Integer
    Public Shared _ctrAR As Integer
    Public Shared _ctrBPI As Integer
    Public Shared _ctrBRL As Integer


    Public Shared _Query As String
    ''Public Shared _nTempTbl As String = "temp_" & cSessionUser._pUserID.Replace(".", "")
    ''Public Shared _nTempTblASKHDG As String = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
    ''Public Shared _nTempTblQTY As String = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
    ''Public Shared _nTempTblOPT As String = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

    'Private connetionString As String
    'Private Shared connection As SqlConnection
    'Private Shared sql As String
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

    Private _mFieldsWhere As String
    Private _mAcctNo As String
    Private _mORNo As String
    Private _mBusCode As String
    Private _mTaxCode As String
    Private _mEmail As String
    Private _mEmail2 As String
    Private _mLocServer As String
    Private _mLocDB As String
    Private _mStatus As String
    Private _mGross As Double
    Private _mPrevGross As Double
    Private _mArea As Double
    Private _mForYear As String
    Private _mQtr As String
    Private _mDeliver As String
    Private _mPeriod As String
    Private _mRemarks As String
    Private _mGrossDetail As String
    Private _mTempGross As String
    Private _mReferenceNo As String
    Private _mAmountPaid As Double
    Private _mLQP As String
    Private _mDatePaid As String
    Private _mQtrPaid As String
    Private _mMonth As String
    Private _mTempTbl As String
    Private _mASKHDG As String
    Private _mXValue As String
    Private _mXSelected As String
    Private _mSOAno As String
    Private _nTempTbl As String
    Private _nTempTblASKHDG As String
    Private _nTempTblQTY As String
    Private _nTempTblOPT As String
    Private _mToimsServer As String
    Private _mToimsDB As String
    Private _mMOP As String
    '---- Added by Archie 20200915
    Private Shared _mFile1Name As String
    Private Shared _mFile1Type As String
    Private Shared _mFile1Data As Byte()
    Private Shared _mFile2Name As String
    Private Shared _mFile2Type As String
    Private Shared _mFile2Data As Byte()
    Private Shared _mFile3Name As String
    Private Shared _mFile3Type As String
    Private Shared _mFile3Data As Byte()
    Private Shared _mFile4Name As String
    Private Shared _mFile4Type As String
    Private Shared _mFile4Data As Byte()


#End Region

#Region "Properties Field"


    Public Property _pMOP() As String
        Get
            Return _mMOP
        End Get
        Set(ByVal value As String)
            _mMOP = value
        End Set
    End Property

    Public Property _pToimsServer() As String
        Get
            Return _mToimsServer
        End Get
        Set(ByVal value As String)
            _mToimsServer = value
        End Set
    End Property
    Public Property _pEmail2() As String
        Get
            Return _mEmail2
        End Get
        Set(ByVal value As String)
            _mEmail2 = value
        End Set
    End Property
    Public Property _pToimsDB() As String
        Get
            Return _mToimsDB
        End Get
        Set(ByVal value As String)
            _mToimsDB = value
        End Set
    End Property

    Public Property _pnTempTbl() As String
        Get
            Return _nTempTbl
        End Get
        Set(ByVal value As String)
            _nTempTbl = value
        End Set
    End Property

    Public Property _pnTempTblASKHDG() As String
        Get
            Return _nTempTblASKHDG
        End Get
        Set(ByVal value As String)
            _nTempTblASKHDG = value
        End Set
    End Property

    Public Property _pnTempTblQTY() As String
        Get
            Return _nTempTblQTY
        End Get
        Set(ByVal value As String)
            _nTempTblQTY = value
        End Set
    End Property

    Public Property _pnTempTblOPT() As String
        Get
            Return _nTempTblOPT
        End Get
        Set(ByVal value As String)
            _nTempTblOPT = value
        End Set
    End Property

    Public Property _pSOAno() As String
        Get
            Return _mSOAno
        End Get
        Set(ByVal value As String)
            _mSOAno = value
        End Set
    End Property


    Public Property _pXValue() As String
        Get
            Return _mXValue
        End Get
        Set(ByVal value As String)
            _mXValue = value
        End Set
    End Property

    Public Property _pXSelected() As String
        Get
            Return _mXSelected
        End Get
        Set(ByVal value As String)
            _mXSelected = value
        End Set
    End Property


    Public Property _pASKHDG() As String
        Get
            Return _mASKHDG
        End Get
        Set(ByVal value As String)
            _mASKHDG = value
        End Set
    End Property

    Public Property _pTempTbl() As String
        Get
            Return _mTempTbl
        End Get
        Set(ByVal value As String)
            _mTempTbl = value
        End Set
    End Property


    Public Property _pMonth() As String
        Get
            Return _mMonth
        End Get
        Set(ByVal value As String)
            _mMonth = value
        End Set
    End Property

    Public Property _pTaxCode() As String
        Get
            Return _mTaxCode
        End Get
        Set(ByVal value As String)
            _mTaxCode = value
        End Set
    End Property


    Public Property _pQtrPaid() As String
        Get
            Return _mQtrPaid
        End Get
        Set(ByVal value As String)
            _mQtrPaid = value
        End Set
    End Property

    Public Property _pDatePaid() As String
        Get
            Return _mDatePaid
        End Get
        Set(ByVal value As String)
            _mDatePaid = value
        End Set
    End Property

    Public Property _pLQP() As String
        Get
            Return _mLQP
        End Get
        Set(ByVal value As String)
            _mLQP = value
        End Set
    End Property
    Public Property _pAmountPaid() As Double
        Get
            Return _mAmountPaid
        End Get
        Set(ByVal value As Double)
            _mAmountPaid = value
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

    Public Property _pAcctNo() As String
        Get
            Return _mAcctNo
        End Get
        Set(ByVal value As String)
            _mAcctNo = value
        End Set
    End Property

    Public Property _pORNo() As String
        Get
            Return _mORNo
        End Get
        Set(ByVal value As String)
            _mORNo = value
        End Set
    End Property


    Public Property _pQtr() As String
        Get
            Return _mQtr
        End Get
        Set(ByVal value As String)
            _mQtr = value
        End Set
    End Property
    Public Property _pReferenceNo() As String
        Get
            Return _mReferenceNo
        End Get
        Set(ByVal value As String)
            _mReferenceNo = value
        End Set
    End Property
    Public Property _pGrossDetail() As String
        Get
            Return _mGrossDetail
        End Get
        Set(ByVal value As String)
            _mGrossDetail = value
        End Set
    End Property
    Public Property _pTempGross() As String
        Get
            Return _mTempGross
        End Get
        Set(ByVal value As String)
            _mTempGross = value
        End Set
    End Property


    Public Property _pDeliver() As String
        Get
            Return _mDeliver
        End Get
        Set(ByVal value As String)
            _mDeliver = value
        End Set
    End Property

    Public Property _pForYear() As String
        Get
            Return _mForYear
        End Get
        Set(ByVal value As String)
            _mForYear = value
        End Set
    End Property
    Public Property _pPeriod() As String
        Get
            Return _mPeriod
        End Get
        Set(ByVal value As String)
            _mPeriod = value
        End Set
    End Property
    Public Property _pRemarks() As String
        Get
            Return _mRemarks
        End Get
        Set(ByVal value As String)
            _mRemarks = value
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
    Public Property _pLocServer() As String
        Get
            Return _mLocServer
        End Get
        Set(ByVal value As String)
            _mLocServer = value
        End Set
    End Property
    Public Property _pTempTblBT() As String
        Get
            Return _mTempTblBT
        End Get
        Set(ByVal value As String)
            _mTempTblBT = value
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

    Public Property _pStatus() As String
        Get
            Return _mStatus
        End Get
        Set(ByVal value As String)
            _mStatus = value
        End Set
    End Property


    Public Property _pBusCode() As String
        Get
            Return _mBusCode
        End Get
        Set(ByVal value As String)
            _mBusCode = value
        End Set
    End Property

    Public Property _pGross() As Double
        Get
            Return _mGross
        End Get
        Set(ByVal value As Double)
            _mGross = value
        End Set
    End Property

    Public Property _pPrevGross() As Double
        Get
            Return _mPrevGross
        End Get
        Set(ByVal value As Double)
            _mPrevGross = value
        End Set
    End Property
    Public Property _pArea() As Double
        Get
            Return _mArea
        End Get
        Set(ByVal value As Double)
            _mArea = value
        End Set
    End Property
    '----------- Added by Archie 20200916
    Public Shared Property _pFile1Name() As String
        Get
            Return _mFile1Name
        End Get
        Set(value As String)
            _mFile1Name = value
        End Set
    End Property
    Public Shared Property _pFile1Type() As String
        Get
            Return _mFile1Type
        End Get
        Set(value As String)
            _mFile1Type = value
        End Set
    End Property
    Public Shared Property _pFile1Data() As Byte()
        Get
            Return _mFile1Data
        End Get
        Set(value As Byte())
            _mFile1Data = value
        End Set
    End Property

    Public Shared Property _pFile2Name() As String
        Get
            Return _mFile2Name
        End Get
        Set(value As String)
            _mFile2Name = value
        End Set
    End Property
    Public Shared Property _pFile2Type() As String
        Get
            Return _mFile2Type
        End Get
        Set(value As String)
            _mFile2Type = value
        End Set
    End Property
    Public Shared Property _pFile2Data() As Byte()
        Get
            Return _mFile2Data
        End Get
        Set(value As Byte())
            _mFile2Data = value
        End Set
    End Property

    Public Shared Property _pFile3Name() As String
        Get
            Return _mFile3Name
        End Get
        Set(value As String)
            _mFile3Name = value
        End Set
    End Property
    Public Shared Property _pFile3Type() As String
        Get
            Return _mFile3Type
        End Get
        Set(value As String)
            _mFile3Type = value
        End Set
    End Property
    Public Shared Property _pFile3Data() As Byte()
        Get
            Return _mFile3Data
        End Get
        Set(value As Byte())
            _mFile3Data = value
        End Set
    End Property

    Public Shared Property _pFile4Name() As String
        Get
            Return _mFile4Name
        End Get
        Set(value As String)
            _mFile4Name = value
        End Set
    End Property
    Public Shared Property _pFile4Type() As String
        Get
            Return _mFile4Type
        End Get
        Set(value As String)
            _mFile4Type = value
        End Set
    End Property
    Public Shared Property _pFile4Data() As Byte()
        Get
            Return _mFile4Data
        End Get
        Set(value As Byte())
            _mFile4Data = value
        End Set
    End Property
#End Region

    Public Shared Sub ClearAttachedFile()
        _pFile1Name = Nothing
        _pFile1Type = Nothing
        _pFile1Data = Nothing
        _pFile2Name = Nothing
        _pFile2Type = Nothing
        _pFile2Data = Nothing
        _pFile3Name = Nothing
        _pFile3Type = Nothing
        _pFile3Data = Nothing
        _pFile4Name = Nothing
        _pFile4Type = Nothing
        _pFile4Data = Nothing
    End Sub

    ''-----------------------------------------------------------------------May 12,2021 

    Public Sub _pDisplayLogo()


        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = _
              " Select LGU_LOGO from LGU_Profile "


            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            '_mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'With _mSqlCommand.Parameters

            '    If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)

            'End With

            'karlo 20180411
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Public Sub _pSubSelectPrevGross()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            ' ''----------------------------------    
            ''_nQuery = _
            ''   "SELECT  top 1 ACCTNO,GROSSREC,AREA,BUSCODE.DESCRIPTION  as BUSDESC,BUSLINE.BUS_CODE from BUSLINE " & _
            ''    " INNER JOIN BUSCODE " & _
            ''    " ON BUSLINE.BUS_CODE = BUSCODE.BUS_CODE " & _
            ''    " WHERE ACCTNO = '" & _mAcctNo & "' and foryear < '" & Year(Today) & "' " & _
            ''    " order by foryear desc "


            '----------------------------------    
            _nQuery = _
               "SELECT   ACCTNO,SUM(GROSSREC) GROSSREC,SUM(AREA) AREA,dbo.Get_Category_Line_Ledger(ACCTNO,FORYEAR,'2')  as BUSDESC from BUSLINE " & _
                " INNER JOIN BUSCODE " & _
                " ON BUSLINE.BUS_CODE = BUSCODE.BUS_CODE " & _
                " WHERE ACCTNO = '" & _mAcctNo & "' and foryear  = (select top 1 foryear from busline where acctno = '" & _mAcctNo & "' and foryear <  Year(getdate())  order by foryear desc ) " & _
                " GROUP BY ACCTNO,FORYEAR"



            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nPrevGross = CDbl(_nSqlDr.Item("GROSSREC").ToString)
                    _nArea = CDbl(_nSqlDr.Item("AREA").ToString)
                    _nBusDesc = _nSqlDr.Item("BUSDESC").ToString
                    '_nBusCode = _nSqlDr.Item("BUS_CODE").ToString
                    ' Loop
                End If

            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubCheckEnroll()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [sp_GETACCT] '" & _mAcctNo & "','" & _mORNo & "','" & _mLocServer & "','" & _pLocDB & "','" & _mEmail & "','" & _mEmail2 & "',@_mStatus OUTPUT , @_mStatusdesc  OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters.Add("@_mStatusdesc ", SqlDbType.NVarChar, 400)

            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output
            _mSqlCommand.Parameters("@_mStatusdesc ").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _nOutDesc = _mSqlCommand.Parameters("@_mStatusdesc").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubCheckBusline()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKBUSLINE] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "','" & _mTempTbl & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output


            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckAssessment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKPOSTING] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output


            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckSubmit()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKHASSUBMIT] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckhasPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKHASPAYMENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckGarbage()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKGARBAGE] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "','" & _mTempTbl & "'"

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

    Public Sub _pSubComputeTax()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nNewGross As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT BUSCODE, GROSS FROM [" & _mTempGross & "]"


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
            _mDataTable = New DataTable

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    _mDataTable.Load(_nSqlDr)
                    'Getting Record using reader

                    Dim i As Integer
                    For i = 0 To _mDataTable.Rows.Count - 1
                        _nNewGross = CDbl(_mDataTable.Rows(i).Item("GROSS").ToString)

                        _nQuery = _
                            "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mDataTable.Rows(i).Item("BUSCODE").ToString & "','" & _nNewGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "','" & _nTempTblASKHDG & "','" & _nTempTblQTY & "','" & _nTempTblOPT & "','" & _mQtrPaid & "','" & _mDataTable.Rows.Count & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                    Next


                    'Do While _nSqlDr.Read

                    'Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubGetPenalty()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nBusCode As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT DISTINCT BUSCODE FROM [PAYMENT] WHERE ACCTNO = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' AND ISNULL(BUSCODE,'') <> ''  "


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
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nBusCode = _nSqlDr.Item("BUSCODE").ToString

                        _nQuery = _
                            "exec [SP_GETPENALTY] '" & _mAcctNo & "','" & _mForYear & "','" & _nBusCode & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mQtrPaid & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetPayFileExtn()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim nRefNo As String
            Dim nORNo As String
            Dim nSRS As String
            Dim nForyear As String
            Dim nAcctNo As String
            '----------------------------------    



            _nQuery = _
                      "SELECT *,year(Date) as Foryear,(Select AcctNo from ledger where referenceno = TransactionNumber) as AcctNo FROM  [" & _mToimsServer & "].[" & _mToimsDB & "].dbo.[tmp_table_or] "


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

            _mSqlCommand.CommandTimeout = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        nRefNo = _nSqlDr.Item("TransactionNumber").ToString
                        nORNo = _nSqlDr.Item("Or_number").ToString
                        nSRS = _nSqlDr.Item("SRS").ToString
                        nForyear = _nSqlDr.Item("Foryear").ToString
                        nAcctNo = _nSqlDr.Item("AcctNo").ToString

                        _nQuery = _
                            "exec [SP_SAVEPAYFILEEXTN] '" & cSessionUser._pUserID.Replace(".", "") & "','" & nAcctNo & "','" & nForyear & "','" & nORNo & "','" & nSRS & "','" & nRefNo & "','" & _mLocServer & "','" & _mLocDB & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlCommand2.CommandTimeout = 0
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    ''Public Sub _pSubGetPayFile()
    ''    Try
    ''        '----------------------------------
    ''        'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

    ''        '----------------------------------
    ''        Dim _nQuery As String = Nothing
    ''        Dim _nWhere As String = Nothing
    ''        Dim nRefNo As String
    ''        Dim nORNo As String
    ''        Dim nSRS As String
    ''        Dim nForyear As String
    ''        Dim nAcctNo As String
    ''        '----------------------------------    



    ''        _nQuery = _
    ''                  "SELECT *,year(Date) as Foryear,(Select AcctNo from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.ledger where referenceno = TransactionNumber) as AcctNo FROM  [" & _mToimsServer & "].[" & _mToimsDB & "].dbo.[tmp_table_or] "


    ''        '----------------------------------    
    ''        ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

    ''        ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

    ''        ''Else
    ''        ''    _nWhere = Nothing
    ''        ''End If

    ''        '----------------------------------
    ''        _mQuery = _nQuery


    ''        '----------------------------------
    ''        _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

    ''        'Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
    ''        '_mDataTable = New DataTable
    ''        '_nSqlDataAdapter.Fill(_mDataTable)


    ''        Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
    ''            ''  _nSqlDr.Read()
    ''            If _nSqlDr.HasRows Then
    ''                'Getting Record using reader
    ''                Do While _nSqlDr.Read
    ''                    nRefNo = _nSqlDr.Item("TransactionNumber").ToString
    ''                    nORNo = _nSqlDr.Item("Or_number").ToString
    ''                    nSRS = _nSqlDr.Item("SRS").ToString
    ''                    nForyear = _nSqlDr.Item("Foryear").ToString
    ''                    nAcctNo = _nSqlDr.Item("AcctNo").ToString

    ''                    _nQuery = _
    ''                        "exec [SP_SAVEPAYFILE] '','" & nAcctNo & "','" & nForyear & "','" & nORNo & "','" & nSRS & "','" & nRefNo & "','','','','','" & _mLocServer & "','" & _mLocDB & "'"
    ''                    _mQuery = _nQuery
    ''                    _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
    ''                    _mSqlDataReader = _mSqlCommand2.ExecuteReader
    ''                    _mSqlDataReader.Read()
    ''                    _mSqlCommand2.Dispose()

    ''                Loop
    ''            End If

    ''        End Using
    ''        _mSqlCommand.Dispose()


    ''        '----------------------------------
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

    Public Sub _pSubSAVETPGROSS()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nNewGross As String
            Dim _nBUSCODE As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT BUSCODE, GROSS FROM [" & _mTempGross & "]"


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
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nNewGross = CDbl(_nSqlDr.Item("GROSS").ToString)
                        _nBUSCODE = _nSqlDr.Item("BUSCODE").ToString

                        _nQuery = _
                            "exec [SP_SAVETAXPAYERGROSS] '" & _mAcctNo & "','" & _nBUSCODE & "','" & _mForYear & "','" & _nNewGross & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSAVEBPLOGROSS()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nNewGross As String
            Dim _nBUSCODE As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT BUSCODE, GROSS FROM [" & _mTempGross & "]"


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
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nNewGross = CDbl(_nSqlDr.Item("GROSS").ToString)
                        _nBUSCODE = _nSqlDr.Item("BUSCODE").ToString

                        _nQuery = _
                            "exec [SP_SAVEBPLORGROSS] '" & _mAcctNo & "','" & _nBUSCODE & "','" & _mForYear & "','" & _nNewGross & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubTotalGross()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nNewGross As String
            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT BUSCODE, GROSS FROM [" & _mTempGross & "]"


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

            _nTotalGross = 0
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nTotalGross = _nTotalGross + CDbl(_nSqlDr.Item("GROSS").ToString)
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect_wRemainingQtr()
        Try
            Dim _Query As String = Nothing
            _Query = _
            " SELECT distinct [BUSDETAIL].*,billingtemp.QtrPaid FROM [BUSDETAIL]     " &
            " inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.billingtemp on [BUSDETAIL].acctno = billingtemp.acctno and billingtemp.Taxcode='bt' and billingtemp.QtrPaid < 4" &
            " WHERE [BUSDETAIL].[Email2] = '" & cSessionUser._pUserID & "' AND [BUSDETAIL].VERIFIED = '1'  and BILLINGTEMP.Foryear=year(getdate())" &
            "  and [BUSDETAIL].Status <> 'Approved - For Payment'"
            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_BPLTIMS)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectEnroll()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '  _nQuery = _
            '     "SELECT * FROM [BUSDETAIL] WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' AND VERIFIED = '1' " & _
            '     "AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM BUSDETAIL_TAXPAYER WHERE isnull(ISASSESS,0) ='1' AND FORYEAR = YEAR(GETDATE())) " & _
            '     "AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE FORYEAR = YEAR(GETDATE()) AND ISNULL(APPRV_TOP_ONLINE,0) = 1 ) " & _
            '    "AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.PAYFILE WHERE FORYEAR =  YEAR(GETDATE())) "

            '====
            _nQuery = _
" SELECT * FROM [BUSDETAIL] WHERE [Email2] = '" & cSessionUser._pUserID & "' AND VERIFIED = '1' " & _
"    AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM BUSDETAIL_TAXPAYER WHERE isnull(ISASSESS,0) ='1' AND FORYEAR = YEAR(GETDATE()))                                                  " & _
"    AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE FORYEAR = YEAR(GETDATE()) AND ISNULL(APPRV_TOP_ONLINE,0) = 1 )  " & _
"    AND ACCTNO NOT IN (SELECT DISTINCT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.billingtemp WHERE FORYEAR =  YEAR(GETDATE()))                                 " & _
"union select * FROM [BUSDETAIL] WHERE acctno in                                                                                                                                     " & _
"(                                                                                                                                                                                   " & _
"select distinct bt.acctno from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.busmast bm                                                                                        " & _
"inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.billingtemp bt on bm.acctno=bt.acctno                                                                                 " & _
"where bm.acctno  in                                                                                                                                                                 " & _
"(select acctno from BUSDETAIL where email2='" & cSessionUser._pUserID & "'                                                                                                                  " & _
"union select acctno from NewBP_Draft where [UserID]='" & cSessionUser._pUserID & "')                                                                                                        " & _
"and bt.foryear <  year(getdate())                                                                                                                                                   " & _
"and bm.acctno not in                                                                                                                                                                " & _
"(select acctno from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.billingtemp where foryear = year(getdate()))                                                                 " & _
") and   VERIFIED = '1'                                                                                                                                                                                    " & _
"union                                                                                                                                                                               " & _
"select distinct REPLACE(nbpd.UserID, '.', '') EMAIL,bm.ACCTNO, nbpd.Date_Submitted ReqDate,bl.orno1 ORNo,                                                                           " & _
"bm.Last_name + ' ' + bm.First_Name + ' ' + bm.middle_Name OWNER, bm.commname BUSNAME, bm.COMMADDR BUSADDRESS,                                                                       " & _
"(STUFF((SELECT distinct ' || ' + BC.[DESCRIPTION]                                                                                                                                   " & _
"	FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[BUSCODE] BC                                                                                                             " & _
" WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND	BM.ACCTNO = BL.ACCTNO   FOR XML PATH('')), 1, 3, '')) CATEGORY,1 as Verified,                                                            " & _
" null VerifiedBy,null VerifiedDate,null Remarks,nbpd.status,nbpd.UserID Email2,                                                                                                     " & _
"(select cc.catdesc from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.busline  bl                                                                                              " & _
"inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.buscode bc on bc.bus_code=bl.bus_code                                                                                 " & _
"inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.catcode cc on cc.catcode=bc.category                                                                                  " & _
"where bl.acctno =bm.acctno)CATEGORY1         ,null MOP                                                                                                                              " & _
"from  [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.busmast  bm                                                                                                                " & _
"inner join NewBP_Draft nbpd on nbpd.acctno=bm.acctno                                                                                                                                " & _
"inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.busline bl on bl.acctno=bm.acctno                                                                                     " & _
"inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.billingtemp bt on bm.acctno=bt.acctno                                                                                 " & _
"where nbpd.UserID = '" & cSessionUser._pUserID & "'                                                                                                                                         " & _
"and bt.foryear <  year(getdate())                                                                                                                                                   " & _
"and bm.acctno not in                                                                                                                                                                " & _
"(select acctno from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.billingtemp where foryear = year(getdate()))                                                                 "



            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery

            _Query = _mQuery 'used for Query Checking on Live Servers

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

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    ''Public Sub _pSubSelectForPayment()
    ''    Try
    ''        '----------------------------------
    ''        'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

    ''        '----------------------------------
    ''        Dim _nQuery As String = Nothing
    ''        Dim _nWhere As String = Nothing

    ''        '----------------------------------    
    ''        ''_nQuery = _
    ''        ''   "SELECT * FROM [BUSDETAIL] WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' AND VERIFIED = '1'  " & _
    ''        ''   "AND (ACCTNO IN (SELECT DISTINCT ACCTNO FROM BUSDETAIL_TAXPAYER WHERE isnull(ISASSESS,0) ='1' AND FORYEAR = '" & Year(Now) & "') " & _
    ''        ''   " OR ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE FORYEAR = '" & Year(Now) & "' ))"


    ''        _nQuery = _
    ''                 " SELECT BM.ACCTNO, (BM.LAST_NAME + ', ' + ISNULL(BM.FIRST_NAME,'') + ' '+ ISNULL(BM.MIDDLE_NAME,'')) as OWNER,BM.COMMNAME AS BUSNAME, BM.COMMADDR  AS BUSADDRESS " & _
    ''                 " ,STUFF((SELECT ' || ' + BC.[DESCRIPTION]  " & _
    ''                                   " FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[BUSCODE] BC " & _
    ''                                   " INNER JOIN BUSLINE BL  " & _
    ''                                  "  ON BM.ACCTNO = BL.ACCTNO " & _
    ''                                   " WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND BM.ACCTNO = BL.ACCTNO " & _
    ''                                  "  FOR XML PATH('')), 1, 3, '') AS CATEGORY,'NEW' as STATUS " & _
    ''                         " FROM BUSMAST BM  " & _
    ''                         " INNER JOIN BUSMASTEXTN BMX " & _
    ''                         " ON BM.ACCTNO = BMX.ACCTNO  " & _
    ''                 " where BM.IsForPayment = 1  " & _
    ''                        "  AND BMX.FORYEAR = YEAR(GETDATE()) AND BM.EMAILADDR = '" & cSessionUser._pUserID & "'   " & _
    ''                 "  UNION " & _
    ''                      "    SELECT ACCTNO,OWNER,BUSNAME,BUSADDRESS,CATEGORY,  ISNULL((SELECT DISTINCT CASE WHEN STATCODE ='N' THEN 'NEW' ELSE 'RENEW' END as STATUS FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ACCTNO = [BUSDETAIL].ACCTNO  AND FORYEAR =  YEAR(GETDATE())),'RENEW') as STATUS  FROM [BUSDETAIL]  " & _
    ''                      "    WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' AND VERIFIED = '1'  AND (ACCTNO IN (SELECT DISTINCT ACCTNO FROM  " & _
    ''                 " BUSDETAIL_TAXPAYER " & _
    ''                       "   WHERE isnull(ISASSESS,0) ='1' AND FORYEAR = YEAR(GETDATE()))  OR  " & _
    ''                       "   ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE FORYEAR =  YEAR(GETDATE())))"

    ''        '----------------------------------    


    ''        '----------------------------------
    ''        _mQuery = _nQuery


    ''        '----------------------------------
    ''        _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

    ''        Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
    ''        _mDataTable = New DataTable
    ''        _nSqlDataAdapter.Fill(_mDataTable)

    ''        'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
    ''        'Using _nSqlDr
    ''        '    If _nSqlDr.HasRows Then
    ''        '        'Getting Record using reader
    ''        '        ' Do While _nSqlDr.Read
    ''        '        _mDataTable.Load(_nSqlDr)
    ''        '        '  Loop
    ''        '    End If
    ''        'End Using

    ''        Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
    ''            _nSqlDr.Read()
    ''            If _nSqlDr.HasRows Then
    ''                'Getting Record using reader
    ''                '  Do While _nSqlDr.Read
    ''                _nOwner = _nSqlDr.Item("OWNER").ToString
    ''                _nBusName = _nSqlDr.Item("BUSNAME").ToString
    ''                _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
    ''                _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
    ''                ' Loop
    ''            End If

    ''        End Using





    ''        '----------------------------------
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub
    Public Sub _pSubSelectForPayment(Optional ByRef err As String = Nothing)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    

            _nQuery = _
            "   SELECT DISTINCT " & _
            "	BM.Acctno,  " & _
            "	(BM.LAST_NAME + ', ' + ISNULL(BM.FIRST_NAME,'') + ' '+ ISNULL(BM.MIDDLE_NAME,'')) as OWNER,  " & _
            "	BM.COMMNAME AS BUSNAME,  " & _
            "	BM.COMMADDR  AS BUSADDRESS ,  " & _
            "	STUFF((SELECT distinct ' || ' + BC.[DESCRIPTION]   FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[BUSCODE] BC  " & _
            "		INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE BL    ON BM.ACCTNO = BL.ACCTNO    " & _
            "		WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND	BM.ACCTNO = BL.ACCTNO  " & _
            "       FOR XML PATH('')), 1, 3, '') AS CATEGORY,  " & _
            "	'NEW' as STATUS from BUSMAST BM	 " & _
            "	INNER JOIN " & _
            "		[" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BILLINGTEMP BT ON BM.ACCTNO= BT.ACCTNO   AND BM.EMAILADDR = '" & cSessionUser._pUserID & "'  " & _
            "   union  " & _
            "	SELECT DISTINCT " & _
            "   BD.ACCTNO,BD.OWNER,BD.BUSNAME,BD.BUSADDRESS,BD.CATEGORY,  'RENEW' as STATUS  FROM [BUSDETAIL]   BD " & _
            "	INNER JOIN	[" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BILLINGTEMP BT ON BD.ACCTNO= BT.ACCTNO     " & _
            "   INNER JOIN  [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSMAST BM" & _
            "   ON BT.ACCTNO = BM.ACCTNO  " & _
            "	WHERE BD.[Email2] = '" & cSessionUser._pUserID & "' AND BD.VERIFIED= '1'  " & _
            "	and  BD.ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 )  " & _
            "	and BD.ACCTNO IN (select acctno from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE where (bqtrind < 4 or gqtrind < 4) or newsw = 0 and foryear=year(getdate()))   AND BM.STATCODE = 'R' "



            '_nQuery = _
            '"   select  " & _
            '"	BM.Acctno,  " & _
            '"	(BM.LAST_NAME + ', ' + ISNULL(BM.FIRST_NAME,'') + ' '+ ISNULL(BM.MIDDLE_NAME,'')) as OWNER,  " & _
            '"	BM.COMMNAME AS BUSNAME,  " & _
            '"	BM.COMMADDR  AS BUSADDRESS ,  " & _
            '"	STUFF((SELECT distinct ' || ' + BC.[DESCRIPTION]   FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[BUSCODE] BC  " & _
            '"		INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE BL    ON BM.ACCTNO = BL.ACCTNO    " & _
            '"		WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND	BM.ACCTNO = BL.ACCTNO   FOR XML PATH('')), 1, 3, '') AS CATEGORY,  " & _
            '"	'NEW' as STATUS, BT.L_DATEPD from BUSMAST BM	 " & _
            '"	INNER JOIN " & _
            '"		[" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BILLINGTEMP BT ON BM.ACCTNO= BT.ACCTNO     " & _
            '"   where bm.acctno in (select acctno from  [BUSDETAIL]      WHERE [Email2] = '" & cSessionUser._pUserID & "' AND VERIFIED= '1'  union select acctno from NewBP_Draft where status='Approved - For Payment' and UserID = '" & cSessionUser._pUserID & "')  " & _
            '"   union  " & _
            '"	SELECT BD.ACCTNO,BD.OWNER,BD.BUSNAME,BD.BUSADDRESS,BD.CATEGORY,  'RENEW' as STATUS, BT.L_DATEPD  FROM [BUSDETAIL]   BD " & _
            '"	INNER JOIN	[" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BILLINGTEMP BT ON BD.ACCTNO= BT.ACCTNO     " & _
            '"	WHERE BD.[Email2] = '" & cSessionUser._pUserID & "' AND BD.VERIFIED= '1'  " & _
            '"	and  BD.ACCTNO IN (SELECT DISTINCT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 )  " & _
            '"	and BD.ACCTNO IN (select acctno from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE where (bqtrind < 4 or gqtrind < 4) or newsw = 0 and foryear=year(getdate()))"

            '_nQuery = _
            '    " select DISTINCT BL.APPRV_TOP_ONLINE,BT.ACCTNO,BD.EMAIL2,BD.OWNER,BD.BUSNAME,BD.BUSADDRESS,BD.CATEGORY,BD.Status FROM BUSDETAIL BD " & _
            '    " INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[billingtemp] BT ON BD.ACCTNO=BT.ACCTNO" & _
            '    " INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[busline] BL ON BD.ACCTNO=BL.ACCTNO" & _
            '    " WHERE BL.APPRV_TOP_ONLINE = '1' AND BD.EMAIL2='" & cSessionUser._pUserID & "'  and isnull(bt.isposted,0)=0 and BT.foryear=year(getdate())"


            ' and BD.status like '%for Payment%'"




            '----------------------------------
            _mQuery = _nQuery
            _Query = _mQuery 'used for Query Checking on Live Servers

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            ' _Query += "--" & _mSqlCon.ToString & "--"

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    '    _Query += "-- HASROWS=TRUE --"
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                Else
                    '   _Query += "-- HASROWS=FALSE --"
                End If

            End Using





            '----------------------------------
        Catch ex As Exception
            '    _Query += "--errr " & ex.Message
            err = "ForPayment : " & ex.Message

        End Try
    End Sub


    Public Sub _pSubSelectForTemporaryPermit()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
            " Select DISTINCT BM.ACCTNO , BM.COMMNAME , OPR.TransDate from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSMAST BM " & _
            " INNER JOIN OnlinePaymentRefno OPR " & _
            " ON BM.Acctno = OPR.ACCTNO " & _
            " WHERE OPR.Status = 'SUCCESS' AND OPR.EMAILADDR = '" & cSessionUser._pUserID & "' "
            '" and BM. Acctno not in ( " & _
            '"		 Select Acctno from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSINESSPERMIT  " & _
            '"		 WHERE FORYEAR =  Year(GETDATE()) " & _
            '"	) "

            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, cGlobalConnections._pSqlCxn_OAIMS)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, cGlobalConnections._pSqlCxn_OAIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectSubmitAcct()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '    "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) "
            ' _nQuery = _
            '"SELECT DISTINCT  B.*,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)   group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2 ORDER BY max(BT.DATESUBMIT)  "

            _nQuery = _
            "SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "') and (B.Status='Approved' or B.status='SUBMITTED FOR RENEWAL')    group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1 ORDER BY max(BT.DATESUBMIT)  asc"

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

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectSubmitAcct_Treasury()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '    "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) "
            ' _nQuery = _
            '"SELECT DISTINCT  B.*,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)   group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2 ORDER BY max(BT.DATESUBMIT)  "

            _nQuery = _
            "SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "') and b.Status like '%TREASURY%'   group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1 ORDER BY max(BT.DATESUBMIT)  "

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

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectAssessAcct()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) DESC "
            '_nQuery = _
            '       "SELECT DISTINCT  B.*,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS   " & _
            '       " UNION SELECT DISTINCT  B.*,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE  BT.FORYEAR = '" & _mForYear & "'  AND BT.ACCTNO IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS ORDER BY max(BT.DATESUBMIT) DESC "
            '_nQuery = _
            '   "SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2, B.CATEGORY1,BT.ISASSESS   " & _
            '   " UNION SELECT DISTINCT B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE  BT.FORYEAR = '" & _mForYear & "'  AND BT.ACCTNO IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS, B.CATEGORY1 ORDER BY max(BT.DATESUBMIT) DESC "

            _nQuery = _
               "SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2, B.CATEGORY1,BT.ISASSESS   " & _
               " UNION SELECT DISTINCT B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B LEFT OUTER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE B.ACCTNO IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS, B.CATEGORY1 ORDER BY max(BT.DATESUBMIT) DESC "


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

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectEnrollInfo()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT * FROM [BUSDETAIL] WHERE [Email] = '" & cSessionUser._pUserID.Replace(".", "") & "' and ACCTNO = '" & _mAcctNo & "' "

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

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetDetail()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT * FROM [BUSDETAIL] WHERE [ACCTNO] = '" & _mAcctNo & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    _nBusCategory1 = _nSqlDr.Item("CATEGORY1").ToString
                    _nEmail = _nSqlDr.Item("EMAIL2").ToString
                    _nMOP = _nSqlDr.Item("MOP").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetDetailNewBusiness()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '   "SELECT * FROM [BUSDETAIL] WHERE [ACCTNO] = '" & _mAcctNo & "'"

            _nQuery = _
         " SELECT BM.ACCTNO, (BM.LAST_NAME + ', ' + ISNULL(BM.FIRST_NAME,'') + ' '+ ISNULL(BM.MIDDLE_NAME,'')) as OWNER,BM.COMMNAME AS BUSNAME, BM.COMMADDR  AS BUSADDRESS " & _
         " ,STUFF((SELECT ' || ' + BC.[DESCRIPTION]  " & _
                           " FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.[BUSCODE] BC " & _
                           " INNER JOIN BUSLINE BL  " & _
                          "  ON BM.ACCTNO = BL.ACCTNO " & _
                           " WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND BM.ACCTNO = BL.ACCTNO " & _
                          "  FOR XML PATH('')), 1, 3, '') AS CATEGORY,'NEW' as STATUS " & _
                 " FROM BUSMAST BM  " & _
                 " INNER JOIN BUSMASTEXTN BMX " & _
                 " ON BM.ACCTNO = BMX.ACCTNO  " & _
         " where BM.IsForPayment = 1  " & _
                "  AND BMX.FORYEAR = YEAR(GETDATE()) AND BM.EMAILADDR = '" & cSessionUser._pUserID & "' AND BM.[ACCTNO] = '" & _mAcctNo & "'   "

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubShowBusDetailExtn()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,'' as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "' order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
            _nQuery = _
              "SELECT *,(SELECT GROSSAMT  FROM PAYMENT WHERE FORYEAR =  '" & _mForYear & "' AND ACCTNO = [BUSDETAIL_TAXPAYER].ACCTNO AND BUSCODE = [BUSDETAIL_TAXPAYER].BUSCODE AND GROSSAMT <> 0) as GROSSINPUT,'0.00'  ASSESSEDGROSS FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "


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
    Public Sub _pSubShowBusDetailExtn_PAYMENT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,'' as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "' order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
            '_nQuery = _
            '  "SELECT * FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "

            _nQuery = _
             " SELECT *,BL.GrossRec as 'BPLOGross' FROM [BUSDETAIL_TAXPAYER] BDT" & _
             " inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE BL on BDT.acctno=BL.acctno and BL.foryear='" & _mForYear & "'" & _
             " WHERE BDT.ACCTNO = '" & _mAcctNo & "' and BDT.foryear =   '" & _mForYear & "'  ORDER BY BDT.acctno desc,BUSCODE desc,GROSSAMT desc "

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

    Public Sub _pSubShowBusDetailExtn3()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,'' as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "' order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
            ' _nQuery = _
            '   "SELECT ACCTNO, FORYEAR, BUSCODE, CATEGORY,CATEGORY1, CAPITAL, PREVGROSS, GROSSAMT, AREA, DATESUBMIT, ISASSESS, GROSSNEW  as GROSSINPUT FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "

            _nQuery = _
                "  SELECT BDT.ACCTNO, BDT.FORYEAR, BDT.BUSCODE, BDT.CATEGORY,BDT.CATEGORY1, BDT.CAPITAL, BDT.PREVGROSS, BDT.GROSSAMT, BDT.AREA, BDT.DATESUBMIT, BDT.ISASSESS, BDT.GROSSNEW  as GROSSINPUT, BL.Grossrec as 'AssessedGross' FROM [BUSDETAIL_TAXPAYER] BDT " & _
                "  inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE BL on BDT.acctno=BL.acctno and BL.foryear='" & _mForYear & "'" & _
                "  WHERE BDT.ACCTNO = '" & _mAcctNo & "' and BDT.foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
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
    Public Sub _pSubShowBusDetailExtn_TAXPAYER()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,'' as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "' order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "
            _nQuery = _
              "SELECT *,'' as GROSSINPUT FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "


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


    Public Sub _pSubShowBusDetail_TAXPAYER()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT  ACCTNO, FORYEAR, BUSCODE, CATEGORY,CATEGORY1, CAPITAL, PREVGROSS, GROSSAMT,ASSET, AREA FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,PREVGROSS desc "


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


    Public Sub _pSubPaymentGross()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT *,(SELECT GROSSAMT  FROM PAYMENT WHERE FORYEAR = '" & _mForYear & "' AND ACCTNO = [BUSDETAILEXTN].ACCTNO AND BUSCODE = [BUSDETAILEXTN].BUSCODE AND GROSSAMT <> 0) as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "'  order by foryear desc)  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "

            _nQuery = _
             "SELECT *,(SELECT GROSSAMT  FROM PAYMENT WHERE FORYEAR = '" & _mForYear & "' AND ACCTNO = [BUSDETAIL_TAXPAYER].ACCTNO AND BUSCODE = [BUSDETAIL_TAXPAYER].BUSCODE AND GROSSAMT <> 0) as GROSSINPUT,GROSSAMT as 'AssessedGross' FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear =   '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "


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
    Public Sub _pSubShowBusDetailExtn2()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            '_nQuery = _
            '   "SELECT *,(SELECT GROSS FROM [" & _mTempGross & "] WHERE BUSCODE = [BUSDETAILEXTN].BUSCODE) as GROSSINPUT FROM [BUSDETAILEXTN] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = (select top 1 foryear from BUSDETAILEXTN where acctno = '" & _mAcctNo & "' and FORYEAR < '" & _mForYear & "'  order by foryear desc) ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "

            _nQuery = _
               "SELECT *,(SELECT GROSS FROM [" & _mTempGross & "] WHERE BUSCODE = [BUSDETAIL_TAXPAYER].BUSCODE) as GROSSINPUT FROM [BUSDETAIL_TAXPAYER] WHERE ACCTNO = '" & _mAcctNo & "' and foryear = '" & _mForYear & "'  ORDER BY acctno desc,BUSCODE desc,GROSSAMT desc "



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
    Public Sub _pSubGetInformation()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT * FROM [VW_WEBINFO] WHERE [ACCTNO] = '" & _mAcctNo & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nLastName = _nSqlDr.Item("LAST_NAME").ToString
                    _nFirstName = _nSqlDr.Item("FIRST_NAME").ToString
                    _nMidName = _nSqlDr.Item("MIDDLE_NAME").ToString
                    _nOwnerAdd = _nSqlDr.Item("OWNERADDR").ToString
                    _nBrgy = _nSqlDr.Item("BARANGAY").ToString
                    _nCommAdd = _nSqlDr.Item("COMMADDR").ToString
                    _nCommName = _nSqlDr.Item("COMMNAME").ToString
                    _nCpNo = _nSqlDr.Item("CPNO").ToString
                    _nTelNo = _nSqlDr.Item("CONTTEL").ToString
                    _nEmailNo = _nSqlDr.Item("EMAILADDR").ToString
                    _nGender = _nSqlDr.Item("GENDER").ToString
                    ' Loop
                End If

            End Using




            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetInformationNew()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                       "select ACCTNO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,OWNERADDR, " & _
                        " (SELECT top 1 PRES_GENDER FROM BUSMASTEXTN WHERE ACCTNO = B.ACCTNO order by foryear desc) as GENDER, " & _
                        " (SELECT BRGYDESC FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BRGYCODE WHERE BRGYCODE = B.BRGYCODE and DISTCODE = B.DISTCODE) as BARANGAY, " & _
                        "  COMMADDR, COMMNAME, CPNO, EMAILADDR, CONTTEL " & _
                        " from busmast as B WHERE B.ACCTNO = '" & _mAcctNo & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            'Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            'Using _nSqlDr
            '    If _nSqlDr.HasRows Then
            '        'Getting Record using reader
            '        ' Do While _nSqlDr.Read
            '        _mDataTable.Load(_nSqlDr)
            '        '  Loop
            '    End If
            'End Using

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nLastName = _nSqlDr.Item("LAST_NAME").ToString
                    _nFirstName = _nSqlDr.Item("FIRST_NAME").ToString
                    _nMidName = _nSqlDr.Item("MIDDLE_NAME").ToString
                    _nOwnerAdd = _nSqlDr.Item("OWNERADDR").ToString
                    _nBrgy = _nSqlDr.Item("BARANGAY").ToString
                    _nCommAdd = _nSqlDr.Item("COMMADDR").ToString
                    _nCommName = _nSqlDr.Item("COMMNAME").ToString
                    _nCpNo = _nSqlDr.Item("CPNO").ToString
                    _nTelNo = _nSqlDr.Item("CONTTEL").ToString
                    _nEmailNo = _nSqlDr.Item("EMAILADDR").ToString
                    _nGender = _nSqlDr.Item("GENDER").ToString
                    ' Loop
                End If

            End Using




            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubSelectPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL FROM [PAYMENT] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' " & _
               " UNION " & _
               " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [PAYMENT] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' order by acctno desc,BUSCODE desc,GROSSAMT desc "

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


    Public Sub _pSubSelectPaymentPerQtr()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing




            '----------------------------------    
            _nQuery = _
               "exec [SP_GETQTRPAYMENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mQtr & "','" & _mTempTbl & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


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


            _nQuery = _
               "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL  FROM [" & _mTempTbl & "] " & _
               " UNION " & _
               " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' order by acctno desc,BUSCODE desc,GROSSAMT desc "

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


    Public Sub _pSubGetTotalDue()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               " SELECT SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "'" ' AND FORYEAR = '" & _mForYear & "' "


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nTotalDue = 0
                    _nTotalDue = CDbl(_nSqlDr.Item("TOTAL").ToString)

                    ' Loop
                End If

            End Using

            '----------------------------------
        Catch ex As Exception
            _nTotalDue = 0
        End Try
    End Sub

    Public Sub _pSubSelectPaymentInquiry()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               " select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars " & _
                 " from vw_PayfileHistorySummary_Tanay where isnull(Particulars,'') <> '' and acctno = src.acctno  " & _
                 " and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)  " & _
                 " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TOTALAMT,Remarks2 from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'')  " & _
                 " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT as TOTALAMT,(SELECT TOP 1 CASE WHEN STATCODE = 'R' THEN 'Renewal' WHEN STATCODE = 'N' THEN 'New' WHEN STATCODE = 'C' THEN 'Closed' " & _
                " ELSE '' END AS STATCODE  FROM BUSLINE WHERE ACCTNO  = vw_PayfileHistorySummary_Tanay.acctno and foryear = vw_PayfileHistorySummary_Tanay.foryear ) as Remarks2 " & _
                 "  From vw_PayfileHistorySummary_Tanay Where Acctno ='" & _mAcctNo & "'  group by Foryear,PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') , " & _
                " ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  ) as src " & _
                "  UNION " & _
                " select  'TOTAL','','','','','','','','','','','','', SUM(TOTALAMT) as TOTALAMT,''  from ( " & _
                " select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars  from vw_PayfileHistorySummary_Tanay  " & _
                " where isnull(Particulars,'') <> '' and acctno = src.acctno   and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)    " & _
                " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TOTALAMT,Remarks2 from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') " & _
                " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT as TOTALAMT,(SELECT TOP 1 CASE WHEN STATCODE = 'R' THEN 'Renewal' WHEN STATCODE = 'N' THEN 'New' WHEN STATCODE = 'C' THEN 'Closed' " & _
                " ELSE '' END AS STATCODE  FROM BUSLINE WHERE ACCTNO  = vw_PayfileHistorySummary_Tanay.acctno and foryear = vw_PayfileHistorySummary_Tanay.foryear ) as Remarks2    From vw_PayfileHistorySummary_Tanay " & _
                " Where Acctno = '" & _mAcctNo & "'  group by Foryear,PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') ,  ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  )" & _
                " as src ) as x " & _
                " order by ordate desc, orno desc "


            '   '" select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars " & _
            ''  " from vw_PayfileHistorySummary_Tanay where isnull(Particulars,'') <> '' and acctno = src.acctno  " & _
            ''  " and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)  " & _
            ''  " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TOTALAMT from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'')  " & _
            ''  " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT as TOTALAMT " & _
            ''  "  From vw_PayfileHistorySummary_Tanay Where Acctno ='" & _mAcctNo & "'  group by PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') , " & _
            '' " ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  ) as src " & _
            '' "  UNION " & _
            '' " select  'TOTAL','','','','','','','','','','','','', SUM(TOTALAMT) as TOTALAMT  from ( " & _
            '' " select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars  from vw_PayfileHistorySummary_Tanay  " & _
            '' " where isnull(Particulars,'') <> '' and acctno = src.acctno   and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)    " & _
            '' " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TOTALAMT from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') " & _
            '' " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT as TOTALAMT   From vw_PayfileHistorySummary_Tanay " & _
            '' " Where Acctno = '" & _mAcctNo & "'  group by PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') ,  ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  )" & _
            '' " as src ) as x " & _
            '' " order by ordate desc, orno desc "
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

    Public Sub _pSubSelectPaymentInquiry_Report()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               " select PERIODCOVERED,ACCTNO,Remarks0,replace(Remarks1,'MOP: ','') Remarks1,(select top 1 Particulars " & _
                 " from vw_PayfileHistorySummary_Tanay where isnull(Particulars,'') <> '' and acctno = src.acctno  " & _
                 " and isnull(orno,'')+isnull(srs,'') = isnull(src.orno,'')+isnull(src.srs,'') and ORDATE = src.ORDATE)  " & _
                 " as Particulars,OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,XSWITCH,REMARKS,TAMT from( Select PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'')  " & _
                 " as OLD_ORNOSRS,ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,'') as XSWITCH, isnull(XSWITCH,'') as REMARKS, TAMT  " & _
                 "  From vw_PayfileHistorySummary_Tanay Where Acctno ='" & _mAcctNo & "'  group by PERIODCOVERED,ACCTNO,Remarks0,Remarks1,isnull(OLD_ORNOSRS,'') , " & _
                " ISBOUNCE,ORNO,SRS,DATEPAID,ORDATE,isnull(XSWITCH,''), TAMT  ) as src order by ordate desc, orno desc "

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

    Public Sub _pSubDelFee() 'Delivery
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_DELIVERYFEE] '" & _mAcctNo & "','" & _mForYear & "','" & _mDeliver & "'"

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


    Public Sub _pSubPosAssessment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_POSTASSESSMENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mQtr & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mTempGross & "' "

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

            _mSqlCommand.CommandTimeout = 0
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



    Public Sub _pSubRemoveTempTbl()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "DROP TABLE [" & _mTempTbl & "] "

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


    Public Sub _pSubPaymentPosting()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "EXEC [SP_PAYMENTPOSTING]  '" & _mAcctNo & "','" & _mForYear & "','" & _mAmountPaid & "','" & _mLQP & "','" & _mQtr & "','" & _mReferenceNo & "','" & _mTempTbl & "' "

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

    Public Sub _pSubUPDATELEDGERACCT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "EXEC [SP_UPDATELEDGERACCT]  '" & _mAcctNo & "','" & _mForYear & "','" & _mReferenceNo & "','" & _mLocServer & "','" & _mLocDB & "' "

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



    Public Sub _pSubGetBusDetailExtn()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "EXEC [SP_GETBUSDETAILEXTN]  '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "'  "

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
    Public Sub _pSubGetBusDetail_TAXPAYER()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "EXEC [SP_GETBUSDETAILEXTN_TAXPAYER]  '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "'  "

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


    Public Sub _pSubGetGross() 'Get Gross 
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETGROSS] '" & _mGrossDetail & "','" & _mTempGross & "'"

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


    Public Sub _pSubSavePaymentDetail() 'Get Gross 
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_SAVEPAYMENTDETAIL] '" & _mAcctNo & "','" & _mEmail & "','" & _mForYear & "','" & _mReferenceNo & "','" & _mAmountPaid & "','" & _mDatePaid & "','" & _mRemarks & "' "

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

    Public Sub _pSubCheckPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKPAYMENT] '" & _mAcctNo & "','" & _mForYear & "',@_mQTRPAY OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mQTRPAY", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mQTRPAY").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mQTRPAY").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCheckNewBusiness()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKNEWBUSINESS] '" & _mAcctNo & "','" & _mForYear & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectPaymentPerQtrPaid()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing




            '----------------------------------    
            _nQuery = _
               "exec [SP_GETQTRPAYMENTPAID] '" & _mAcctNo & "','" & _mForYear & "','" & _mQtr & "','" & _mQtrPaid & "','" & _mTempTbl & "'"

            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


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


            _nQuery = _
               "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL  FROM [" & _mTempTbl & "] " & _
               " UNION " & _
               " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' order by acctno desc,BUSCODE desc,GROSSAMT desc "

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



    Public Sub _pSubCREATE_TEMPASKHDG()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_CREATE_TEMPASKHDG] '" & _mTempTbl & "'"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCREATE_TEMPASKQTY()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_CREATE_TEMPASKQTY] '" & _mTempTbl & "'"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCREATE_TEMPOPTION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_CREATE_TEMPOPTION] '" & _mTempTbl & "'"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubGET_ASKHDG()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
                         "select BUS_CODE, DESCRIPTION, CATEGORY, ISNULL(BCODE,'') BCODE, ISNULL(MCODE,'') MCODE,ISNULL(GCODE,'') GCODE, ISNULL(SCODE,'') SCODE, ISNULL(FCODE,'') FCODE from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSCODE " & _
                         "where BUS_CODE IN (SELECT DISTINCT BUSCODE FROM BUSDETAILEXTN WHERE ACCTNO = '" & _mAcctNo & "' and foryear < '" & _mForYear & "')"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                        _mTaxCode = _nSqlDr.Item("BCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("MCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("GCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("SCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("FCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKHDG] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGET_ASKQTY()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    




            _nQuery = _
                         "select BUS_CODE, DESCRIPTION, CATEGORY, ISNULL(BCODE,'') BCODE, ISNULL(MCODE,'') MCODE,ISNULL(GCODE,'') GCODE, ISNULL(SCODE,'') SCODE, ISNULL(FCODE,'') FCODE from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSCODE " & _
                          "where BUS_CODE IN (SELECT DISTINCT BUSCODE FROM BUSDETAILEXTN WHERE ACCTNO = '" & _mAcctNo & "' and foryear < '" & _mForYear & "')"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                        _mTaxCode = _nSqlDr.Item("BCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("MCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("GCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("SCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("FCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_ASKQTY] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGET_OPTION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
              "select BUS_CODE, DESCRIPTION, CATEGORY, ISNULL(BCODE,'') BCODE, ISNULL(MCODE,'') MCODE,ISNULL(GCODE,'') GCODE, ISNULL(SCODE,'') SCODE, ISNULL(FCODE,'') FCODE from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSCODE " & _
               "where BUS_CODE IN (SELECT DISTINCT BUSCODE FROM BUSDETAILEXTN WHERE ACCTNO = '" & _mAcctNo & "' and foryear < '" & _mForYear & "')"


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                        _mTaxCode = _nSqlDr.Item("BCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("MCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("GCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                        _mTaxCode = _nSqlDr.Item("SCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()


                        _mTaxCode = _nSqlDr.Item("FCODE").ToString

                        _nQuery = _
                              "exec [SP_GET_OPTION] '" & _mTaxCode & "','" & _mForYear & "','" & _mMonth & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "','" & _mAcctNo & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGETVALUE_TEMPASKHDG()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_GETVALUE_TEMPASKHDG] '" & _mTempTbl & "','" & _mASKHDG & "','" & _mXValue & "' "


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGETVALUE_TEMPASKOPT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '----------------------------------    



            _nQuery = _
               "exec [SP_GETVALUE_TEMPASKOPT] '" & _mTempTbl & "','" & _mASKHDG & "','" & _mTaxCode & "' "


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read

                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetSOANo()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETSOANO] '" & _mForYear & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubRemoveTemp()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_REMOVETEMP] '" & _mEmail & "'"

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


    Public Sub _pSubGetNewBusiness()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETNEWBUSINESS] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "',@_mStatus1 OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing 
            ''End If

            '----------------------------------
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.Parameters.Add("@_mStatus1", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus1").Direction = ParameterDirection.Output


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '_mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus1").Value
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetGarbage()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETGARBAGE] '" & _mAcctNo & "','" & _mForYear & "'"

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

    Public Sub _pSubInsertAttachFiles()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO BUSDETAIL_ATTACHMENTS" & _
                            "( " & _
                            " ACCTNO " & _
                            " ,FORYEAR " & _
                            " ,FILE1Name " & _
                            " ,FILE1Type " & _
                            IIf(_mFile1Data Is Nothing, "", ",FILE1Data ") & _
                            " ,FILE2Name " & _
                            " ,FILE2Type " & _
                            IIf(_mFile2Data Is Nothing, "", ",FILE2Data ") & _
                            " ,FILE3Name " & _
                            " ,FILE3Type " & _
                            IIf(_mFile3Data Is Nothing, "", ",FILE3Data ") & _
                            " ,FILE4Name " & _
                            " ,FILE4Type " & _
                            IIf(_mFile4Data Is Nothing, "", ",FILE4Data ") & _
                            " ) " & _
                            "VALUES " & _
                            "( '" & _mAcctNo & "'" & _
                            ",'" & _mForYear & "'" & _
                            ",'" & _mFile1Name & "'" & _
                            ",'" & _mFile1Type & "'" & _
                            IIf(_mFile1Data Is Nothing, "", ",@File1Data") & _
                            ",'" & _mFile2Name & "'" & _
                            ",'" & _mFile2Type & "'" & _
                            IIf(_mFile2Data Is Nothing, "", ",@File2Data") & _
                            ",'" & _mFile3Name & "'" & _
                            ",'" & _mFile3Type & "'" & _
                            IIf(_mFile3Data Is Nothing, "", ",@File3Data") & _
                            ",'" & _mFile4Name & "'" & _
                            ",'" & _mFile4Type & "'" & _
                            IIf(_mFile4Data Is Nothing, "", ",@File4Data") & _
                            " )"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                If _mFile1Data IsNot Nothing Then .AddWithValue("@File1Data", _mFile1Data)
                If _mFile2Data IsNot Nothing Then .AddWithValue("@File2Data", _mFile2Data)
                If _mFile3Data IsNot Nothing Then .AddWithValue("@File3Data", _mFile3Data)
                If _mFile4Data IsNot Nothing Then .AddWithValue("@File4Data", _mFile4Data)


                '.AddWithValue("@File2Data", _mFile2Data)
                '.AddWithValue("@File3Data", _mFile3Data)
                '.AddWithValue("@File4Data", _mFile4Data)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDeleteAttachFiles()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "DELETE FROM BUSDETAIL_ATTACHMENTS WHERE ACCTNO = '" & _mAcctNo & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubInsertAttachFiles1()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO BUSDETAIL_ATTACHMENTS_NEW" & _
                            "( " & _
                            " ACCTNO " & _
                            " ,FORYEAR " & _
                            " ,FILE1Name " & _
                            " ,FILE1Type " & _
                            IIf(_mFile1Data Is Nothing, "", ",FILE1Data ") & _
                            " ,FILE2Name " & _
                            " ,FILE2Type " & _
                            IIf(_mFile2Data Is Nothing, "", ",FILE2Data ") & _
                            " ,FILE3Name " & _
                            " ,FILE3Type " & _
                            IIf(_mFile3Data Is Nothing, "", ",FILE3Data ") & _
                            " ,FILE4Name " & _
                            " ,FILE4Type " & _
                            IIf(_mFile4Data Is Nothing, "", ",FILE4Data ") & _
                            " ) " & _
                            "VALUES " & _
                            "( '" & _mAcctNo & "'" & _
                            ",'" & _mForYear & "'" & _
                            ",'" & _mFile1Name & "'" & _
                            ",'" & _mFile1Type & "'" & _
                            IIf(_mFile1Data Is Nothing, "", ",@File1Data") & _
                            ",'" & _mFile2Name & "'" & _
                            ",'" & _mFile2Type & "'" & _
                            IIf(_mFile2Data Is Nothing, "", ",@File2Data") & _
                            ",'" & _mFile3Name & "'" & _
                            ",'" & _mFile3Type & "'" & _
                            IIf(_mFile3Data Is Nothing, "", ",@File3Data") & _
                            ",'" & _mFile4Name & "'" & _
                            ",'" & _mFile4Type & "'" & _
                            IIf(_mFile4Data Is Nothing, "", ",@File4Data") & _
                            " )"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                If _mFile1Data IsNot Nothing Then .AddWithValue("@File1Data", _mFile1Data)
                If _mFile2Data IsNot Nothing Then .AddWithValue("@File2Data", _mFile2Data)
                If _mFile3Data IsNot Nothing Then .AddWithValue("@File3Data", _mFile3Data)
                If _mFile4Data IsNot Nothing Then .AddWithValue("@File4Data", _mFile4Data)


                '.AddWithValue("@File2Data", _mFile2Data)
                '.AddWithValue("@File3Data", _mFile3Data)
                '.AddWithValue("@File4Data", _mFile4Data)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    '----------------------- Added by archie 20200916
    Public Sub _pSubSelect(_nTable As String, _nCondition As String)

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = _nCondition

            _nQuery = _
                             "SELECT " & _
               " * " & _
               "FROM " & _nTable & _
               " "
            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters


                '.AddWithValue("@_mIDNo", IIf(String.IsNullOrWhiteSpace(_mIDNo), "", _mIDNo))
                '.AddWithValue("@_mIDNoRegistered", IIf(String.IsNullOrWhiteSpace(_mIDNoRegistered), "", _mIDNoRegistered))


            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSAVEASKHDG()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_SAVEASKHDG] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "'"

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

    Public Sub _pSubSAVEASKOPTION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_SAVEASKOPTION] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "'"

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
    Public Sub _pSubTPEmail()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                "exec [SP_GETEMAIL] '" & cSessionLoader._pAccountNo & "',@_mStatus1 OUTPUT"

            ' "exec [SP_GETEMAIL] '" & _mAcctNo & "',@_mStatus1 OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing 
            ''End If

            '----------------------------------
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.Parameters.Add("@_mStatus1", SqlDbType.NVarChar, 150)
            _mSqlCommand.Parameters("@_mStatus1").Direction = ParameterDirection.Output


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '_mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus1").Value
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSAVEASKQTY()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_SAVEASKQTY] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "'"

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

    Public Sub _pSubGETAPPRV_TOP_ONLINE()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETAPPRV_TOP_ONLINE] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "',@_mStatus1 OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing 
            ''End If

            '----------------------------------
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.Parameters.Add("@_mStatus1", SqlDbType.NVarChar, 150)
            _mSqlCommand.Parameters("@_mStatus1").Direction = ParameterDirection.Output


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '_mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus1").Value
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception
            _nOutput = 0
        End Try
    End Sub
    Public Sub _pSubAPPROVEPAYMENT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_APPROVEPAYMENT] '" & _mAcctNo & "','" & _mForYear & "'"

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

            _mSqlCommand.CommandTimeout = 0
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
    Public Sub _pSubCHECKISASSESS()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKISASSESS] '" & _mAcctNo & "','" & _mForYear & "',@_mStatus1 OUTPUT"

            '----------------------------------    
            ''If Not String.IsNullOrWhiteSpace(_mAcctNo) Then

            ''    _nWhere = "WHERE [AcctNo] = @_mAcctNo "

            ''Else
            ''    _nWhere = Nothing 
            ''End If

            '----------------------------------
            _mQuery = _nQuery

            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            _mSqlCommand.Parameters.Add("@_mStatus1", SqlDbType.NVarChar, 150)
            _mSqlCommand.Parameters("@_mStatus1").Direction = ParameterDirection.Output


            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '_mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus1").Value
            _mSqlCommand.Dispose()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCheckIsOnHold()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKISONHOLD] '" & _mAcctNo & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCheckIsDelinquent()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKISDELINQUENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCHECKDESCRIPTION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKDESCRIPTION] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "'"

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

            _mSqlCommand.CommandTimeout = 0
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

            '_nQuery = _
            '   "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL  FROM [" & _mTempTbl & "] " & _
            '   " UNION " & _
            '   " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "' AND FORYEAR = '" & _mForYear & "' order by acctno desc,BUSCODE desc,GROSSAMT desc "

            _nQuery = _
               "WITH XTBL AS ( SELECT ACCTNO, FORYEAR,TAXDESC, QTR,  GROSSAMT,AMOUNTDUE AMOUNTDUE, PENDUE PENDUE, DISCOUNT,TOTAL, " & _
               " CASE WHEN ISNULL((SELECT TOP 1 TOPSEQ FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.LABELS WHERE TAXCODE = [" & _mTempTbl & "].TAXCODE),'') = ''  " & _
               " THEN LEFT(TAXCODE,1) ELSE (SELECT TOP 1 TOPSEQ FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.LABELS WHERE TAXCODE = [" & _mTempTbl & "].TAXCODE) END AS SEQ " & _
               " FROM [" & _mTempTbl & "]) " & _
               " SELECT ACCTNO, FORYEAR,TAXDESC, QTR,SUM(GROSSAMT) GROSSAMT,SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL,SEQ FROM XTBL  " & _
               " GROUP BY ACCTNO, FORYEAR,TAXDESC,QTR,SEQ " & _
               " UNION " & _
               " SELECT '' , '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL,'' AS SEQ  FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "'  order by foryear desc,acctno desc,SEQ,GROSSAMT desc "


            '----------------------------------    


            '----------------------------------
            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubDELINQUENT_NYP()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_DELINQUENT_NYP] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "'"

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
    Public Sub _pSubDECLINEAPPLICATION()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_DECLINEAPPLICATION] '" & _mAcctNo & "','" & _mForYear & "','" & _mTempTbl & "'"

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
    Public Sub _pSubDECLINEENROLLMENT()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_DECLINEENROLLMENT] '" & _mAcctNo & "'"

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
    Public Sub _pSubGETOWNCODE()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETOWNCODE] '" & _mAcctNo & "','" & _mLocServer & "','" & _pLocDB & "',@XOUTPUT OUTPUT"

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



            _mSqlCommand.Parameters.Add("@XOUTPUT", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@XOUTPUT").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@XOUTPUT").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsertAttachFiles(Acctno, Foryear, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType, ReqDesc, Office)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "INSERT INTO BUSDETAIL_ATTACHMENTS_NEW(ACCTNO, FORYEAR, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType, ReqDesc, Office) VALUES(@Acctno,@Foryear,@RefNo,@ModuleID,@AcctID,@SeqID,@FileData,@FileName,@FileType,@ReqDesc,@Office)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Acctno", Acctno)
                .AddWithValue("@Foryear", Foryear)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@ModuleID", ModuleID)
                .AddWithValue("@AcctID", AcctID)
                .AddWithValue("@SeqID", SeqID)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
                .AddWithValue("@ReqDesc", ReqDesc)
                .AddWithValue("@Office", Office)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateAttachFiles(Acctno, Foryear, RefNo, ModuleID, AcctID, SeqID, FileData, FileName, FileType)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSDETAIL_ATTACHMENTS_NEW SET FileData = @FileData, FileName = @FileName, FileType = @FileType " & _
                      " where ACCTNO = @Acctno and FORYEAR = @Foryear and ModuleID=@ModuleID and AcctID=@AcctID and SeqID=@SeqID"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Acctno", Acctno)
                .AddWithValue("@Foryear", Foryear)
                .AddWithValue("@RefNo", RefNo)
                .AddWithValue("@ModuleID", ModuleID)
                .AddWithValue("@AcctID", AcctID)
                .AddWithValue("@SeqID", SeqID)
                .AddWithValue("@FileData", FileData)
                .AddWithValue("@FileName", FileName)
                .AddWithValue("@FileType", FileType)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Sub _pSubApproveForTreasury(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSDETAIL SET Status = @Status where ACCTNO = @ACCTNO"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Status", "SUBMITTED TO TREASURY")
                .AddWithValue("@ACCTNO", ACCTNO)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Sub _pSubResetStatus(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSDETAIL SET Status = @Status,MOP=@MOP where ACCTNO = @ACCTNO"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@Status", "Approved")
                .AddWithValue("@ACCTNO", ACCTNO)
                .AddWithValue("@MOP", Nothing)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdateRenewalMOP(ByVal ACCTNO As String, ByVal MOP As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "Update BUSDETAIL SET MOP = @MOP where ACCTNO = @ACCTNO"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)

            With _nSqlCommand.Parameters
                .AddWithValue("@MOP", MOP)
                .AddWithValue("@ACCTNO", ACCTNO)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectImage(ByVal ACCTNO As String, ByVal FORYEAR As String, ByVal ModuleID As String, ByVal AcctID As String, ByVal SeqID As String, ByRef Exists As Boolean)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            _nQuery = " SELECT * from [BUSDETAIL_ATTACHMENTS_NEW] "
            _nWhere = " where ACCTNO =  '" & ACCTNO & "' and FORYEAR =  '" & FORYEAR & "' and ModuleID='" & ModuleID & "' and AcctID='" & AcctID & "' and SeqID= '" & SeqID & "'"

            _mQuery = _nQuery & _nWhere
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Exists = True
                Else
                    Exists = False

                End If
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubCheckIsClosed()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_CHECKISCLOSED] '" & _mAcctNo & "','" & _mLocServer & "','" & _pLocDB & "',@_mStatus OUTPUT"

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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGETBILLINGTEMP()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                    "exec [SP_GETBILLINGTEMP] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTblBT & "','" & _mTempTbl & "','" & _mMOP & "'"
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


    Public Sub _pSubGetCurYear()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "Select year(getdate()) as curYear,month(getdate()) as curMonth, getdate() as CurrDate "

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

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '   Do While _nSqlDr.Read
                    _nCurYear = _nSqlDr.Item(0).ToString
                    _nCurMonth = _nSqlDr.Item(1).ToString
                    _nCurDate = _nSqlDr.Item(2).ToString
                    '  Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    '----------------------------------------------------------- Added by Archie 20201214
    Public Sub _pSearchOnBP(SearchKey, TopCounter)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be in serted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = SearchKey

            '----------------------------------    
            '_nQuery = _
            '    "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) "
            ' _nQuery = _
            '"SELECT DISTINCT  B.*,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)   group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2 ORDER BY max(BT.DATESUBMIT)  "


            _nQuery =
            " SELECT " & _
            TopCounter & _
            " * FROM (" & _
            " SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT " & _
            " FROM BUSDETAIL B " & _
            " INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO " & _
            " WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "') " & _
            " group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY,Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1  ) S " & _
            _nWhere

            '_nQuery = _
            '"SELECT DISTINCT  " & _
            'TopCounter & _
            '" B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT " & _
            '" FROM BUSDETAIL_TAXPAYER " & _
            '" WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT " & _
            '" FROM BUSDETAIL B " & _
            '" INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO " & _
            '" WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = '" & _mForYear & "' AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')   " & _
            '_nWhere & _
            '" group by MAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1 ORDER BY max(BT.DATESUBMIT)  "

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

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSearchOnBPAssessAcct(SearchKey, TopCounter)
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = SearchKey

            '----------------------------------    
            ''_nQuery = _
            ''   "SELECT DISTINCT  B.*,cast(BT.DATESUBMIT as date)  DATESUBMIT  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "'  ORDER BY cast(BT.DATESUBMIT as date) DESC "
            '_nQuery = _
            '       "SELECT DISTINCT  B.*,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS   " & _
            '       " UNION SELECT DISTINCT  B.*,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE  BT.FORYEAR = '" & _mForYear & "'  AND BT.ACCTNO IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1)  group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS ORDER BY max(BT.DATESUBMIT) DESC "


            _nQuery = " SELECT " & _
                TopCounter & _
                " * FROM ( " & _
                " SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT " & _
                " FROM BUSDETAIL_TAXPAYER " & _
                " WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS   " & _
                " FROM BUSDETAIL B " & _
                " INNER JOIN BUSDETAIL_TAXPAYER BT " & _
                " ON B.ACCTNO = BT.ACCTNO " & _
                " WHERE ISNULL(BT.ISASSESS,0) = 1 AND BT.FORYEAR = '" & _mForYear & "' " & _
                " group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2, B.CATEGORY1,BT.ISASSESS " & _
                " UNION  " & _
                " SELECT DISTINCT B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  " &
                " DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  FROM BUSDETAIL B LEFT OUTER JOIN BUSDETAIL_TAXPAYER " & _
                " BT ON B.ACCTNO = BT.ACCTNO WHERE B.ACCTNO IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = '" & _mForYear & "')  " & _
                " group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS, B.CATEGORY1 ) S " & _
                _nWhere



            '_nQuery = _
            '   "SELECT DISTINCT  " & _
            'TopCounter & _
            '"B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 1 AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  " & _
            '"FROM BUSDETAIL B " & _
            '"INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO " & _
            '"WHERE ISNULL(BT.ISASSESS,0) = 1 " & _
            '"AND BT.FORYEAR = '" & _mForYear & "' " & _
            '_nWhere & _
            '" group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2, B.CATEGORY1,BT.ISASSESS " & _
            '" UNION " & _
            '" SELECT DISTINCT " & _
            ' TopCounter & _
            '" B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)  DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND FORYEAR = '" & _mForYear & "' ) AS DATESUBMIT,ISNULL(BT.ISASSESS,0) AS ISASSESS  " & _
            '" FROM BUSDETAIL B " & _
            '" INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO " & _
            '" WHERE  BT.FORYEAR = '" & _mForYear & "'  AND BT.ACCTNO IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 " & _
            '" AND FORYEAR = '" & _mForYear & "')  " & _
            '_nWhere & _
            '" group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,BT.ISASSESS, B.CATEGORY1 ORDER BY max(BT.DATESUBMIT) DESC "

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

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _nOwner = _nSqlDr.Item("OWNER").ToString
                    _nBusName = _nSqlDr.Item("BUSNAME").ToString
                    _nBusAddress = _nSqlDr.Item("BUSADDRESS").ToString
                    _nBusCategory = _nSqlDr.Item("CATEGORY").ToString
                    ' Loop
                End If

            End Using





            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDELINQUENT_NYP_PREVYR()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nPrevYr As String
            _nPrevYr = _mForYear - 1
            '----------------------------------    
            _nQuery = _
               "exec [SP_DELINQUENT_NYP_PREVYR] '" & _mAcctNo & "','" & _nPrevYr & "','" & _mLocServer & "','" & _mLocDB & "','" & _mTempTbl & "'"

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


    Public Sub _pSubGetDelinquent()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "exec [SP_GETDELINQUENT] '" & _mAcctNo & "','" & _mForYear & "','" & _mLocServer & "','" & _pLocDB & "','" & _mTempTbl & "'"


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



            _mSqlCommand.Parameters.Add("@_mStatus", SqlDbType.NVarChar, 50)
            _mSqlCommand.Parameters("@_mStatus").Direction = ParameterDirection.Output



            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    'Do While _nSqlDr.Read
                    '    _mCode = _nSqlDr.Item(0).ToString
                    'Loop
                End If

            End Using
            _nOutput = _mSqlCommand.Parameters("@_mStatus").Value
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectRecordPayment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nQtrCond As String = Nothing







            _nQuery = _
               "SELECT ACCTNO, FORYEAR,BUSCODE, TAXCODE, TAXDESC, QTR, GROSSAMT, AMOUNTDUE, PENDUE,DISCOUNT, TOTAL  FROM [" & _mTempTbl & "] " & _
               " UNION " & _
               " SELECT '' , '','', '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL FROM [" & _mTempTbl & "] WHERE [ACCTNO] = '" & _mAcctNo & "' order by foryear desc,acctno desc,BUSCODE desc,GROSSAMT desc "

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

    Public Sub _pSubGetPenalty_PrevYr()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nBusCode As String
            Dim _nPrevYr As String
            _nPrevYr = _mForYear - 1


            '----------------------------------    


            '_nQuery = _
            '   "exec [SP_COMPUTEBUSTAX] '" & _mAcctNo & "','" & _mForYear & "','" & _mBusCode & "','" & _mGross & "','" & _mArea & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mTempTbl & "'"
            ''_nQuery = _
            ''         "select DISTINCT BUS_CODE,GROSSREC FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE " & _
            ''         " WHERE ACCTNO = '" & _mAcctNo & "'  " & _
            ''         " and foryear = (select top 1 foryear from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE where acctno = '" & _mAcctNo & "' and foryear < '" & _mForYear & "' order by foryear desc )"
            _nQuery = _
                      "SELECT DISTINCT BUSCODE FROM [PAYMENT] WHERE ACCTNO = '" & _mAcctNo & "' AND FORYEAR = '" & _nPrevYr & "' AND ISNULL(BUSCODE,'') <> ''  "


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
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nBusCode = _nSqlDr.Item("BUSCODE").ToString

                        _nQuery = _
                            "exec [SP_GETPENALTY_PREVYR] '" & _mAcctNo & "','" & _nPrevYr & "','" & _nBusCode & "','" & _mLocServer & "','" & _mLocDB & "','" & _mQtr & "','" & Month(Today) & "','" & _mQtrPaid & "'"
                        _mQuery = _nQuery
                        _mSqlCommand2 = New SqlCommand(_mQuery, _mSqlCon)
                        _mSqlDataReader = _mSqlCommand2.ExecuteReader
                        _mSqlDataReader.Read()
                        _mSqlCommand2.Dispose()
                    Loop
                End If

            End Using
            _mSqlCommand.Dispose()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    '-----------TOMI START

    Public Sub _pSubGetBusLine_Enroll(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = _
                " select bl.BUS_CODE,bc.DESCRIPTION,cc.CATDESC from busline bl" & _
                " inner join BUSCODE bc on bl.BUS_CODE=bc.BUS_CODE" & _
                " inner join catcode cc on bc.CATEGORY = cc.CATCODE" & _
                " where acctno='" & ACCTNO & "' and foryear=" & _
                " (select top 1 foryear from busline where acctno='" & ACCTNO & "' order by FORYEAR desc)"

            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetBusLine_GrossAssetEntry_TAXPAYER(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = _
                " select bl.ACCTNO,bc.BUS_CODE,(bc.description)BUSLINE,(cc.catdesc)CATEGORY,BL.AREA,BL.CAPITAL,(0)TAXPAYERGROSS,(0)TAXPAYERASSET from busline bl " & _
                " inner join buscode bc on bl.BUS_CODE=bc.BUS_CODE   " & _
                " inner join catcode cc on bc.CATEGORY=cc.CATCODE " & _
                " where  bl.acctno='" & ACCTNO & "' and bl.foryear=(select top 1 foryear from BUSLINE " & _
                " where acctno='" & ACCTNO & "' AND FORYEAR < YEAR(GETDATE())  order by foryear desc)"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetBusLine_GrossAssetEntry(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = _
                " select DISTINCT  bl.ACCTNO,bc.BUS_CODE,(bc.description)BUSLINE,(cc.catdesc)CATEGORY," & _
                " (BL.GROSSREC)PrevGross,(bdt.GROSSAMT)TaxpayerGross," & _
                " isnull((SELECT GROSSREC FROM BUSLINE WHERE FORYEAR=YEAR(GETDATE()) AND ACCTNO=BL.ACCTNO AND BUS_CODE=BL.BUS_CODE),0)AssessedGross," & _
                " (BL.ASSET)PrevAsset,ISNULL(bdt.ASSET,0)TaxpayerAsset," & _
                " isnull((SELECT Asset FROM BUSLINE WHERE FORYEAR=YEAR(GETDATE()) AND ACCTNO=BL.ACCTNO AND BUS_CODE=BL.BUS_CODE),0)AssessedAsset" & _
                " from busline bl  " & _
                " inner join buscode bc on bl.BUS_CODE=bc.BUS_CODE  " & _
                " inner join catcode cc on bc.CATEGORY=cc.CATCODE  " & _
                " inner join [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[dbo].BUSDETAIL_TAXPAYER bdt on BL.acctno=BDT.acctno   and BDT.BUSCODE = bl.BUS_CODE " & _
                " where  bl.acctno='" & ACCTNO & "' and bl.foryear=(select top 1 foryear from BUSLINE " & _
                " where acctno='" & ACCTNO & "' AND FORYEAR < YEAR(GETDATE()) " & _
                " order by foryear desc)"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetBusLine_BRTP(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = _
                " SELECT BL.ACCTNO,BL.BUS_CODE ,(bc.description)BUSLINE,(cc.catdesc)CATEGORY,(0)TAXPAYERGROSS,(0)TAXPAYERASSET FROM BUSLINE BL" & _
                " inner join buscode bc on bl.BUS_CODE=bc.BUS_CODE   " & _
                " inner join catcode cc on bc.CATEGORY=cc.CATCODE " & _
                " WHERE ACCTNO = '" & ACCTNO & "' AND " & _
                " FORYEAR=(SELECT TOP 1 FORYEAR FROM BUSLINE WHERE ACCTNO='" & ACCTNO & "' ORDER BY FORYEAR DESC)"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubUpdate_GrossAssetEntry(ByVal ACCTNO As String, ByVal Str As String, ByVal MOP As String, ByRef err As String)
        Try
            Dim _nQuery As String = Nothing
            Dim arr_string As String() = Str.Split(New String() {";"}, StringSplitOptions.RemoveEmptyEntries)
            For Each s As String In arr_string
                Dim arr_string2 As String() = s.Split(New String() {":"}, StringSplitOptions.None)
                Dim bcode As String = arr_string2(0)
                Dim Gross As String = arr_string2(1)
                Dim Asset As String = arr_string2(2)
                _nQuery += _
                " Update BUSDETAIL_TAXPAYER set ASSET='" & Asset & "',GROSSAMT='" & Gross & "',GROSSNEW='" & Gross & "'" & _
                " where BUSCODE='" & bcode & "' and acctno='" & ACCTNO & "' and foryear=year(getdate());"
            Next
            _nQuery += "UPDATE BUSDETAIL SET STATUS='SUBMITTED FOR RENEWAL',MOP='" & MOP & "' WHERE ACCTNO='" & ACCTNO & "' AND EMAIL2 = '" & cSessionUser._pUserID & "';"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
            err = ex.Message
        End Try
    End Sub
    Public Function ExistsOnBusdetailTaxpayer(ByVal acctno As String) As Boolean
        Dim hasRow As Boolean = False
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                " select * from BUSDETAIL_TAXPAYER where acctno='" & acctno & "' and foryear = year(getdate())"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    hasRow = True
                Else
                    hasRow = False
                End If
            End Using
            Return hasRow
        Catch ex As Exception
            Return False
        End Try
    End Function

  

    Public Sub _pSubSelect_Details(ByVal ACCTNO As String, _
                                   ByRef OWNER As String, _
                                   ByRef COMMNAME As String, _
                                   ByRef COMMADDR As String, _
                                   ByRef OWNERSHIP As String, _
                                   ByRef MOP As String)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                " select bm.acctno,bm.LAST_NAME,bm.FIRST_NAME,bm.MIDDLE_NAME,bm.COMMNAME,bm.COMMADDR," & _
                " (select oc.owndesc from owncode oc where  oc.OWNCODE=bm.OWNCODE)OWNERSHIP,sos.MOP from BUSMAST bm " & _
                " inner join [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[BUSDETAIL] sos on bm.ACCTNO=sos.acctno" & _
                "  where bm.acctno='" & ACCTNO & "'"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read                   
                    OWNER = _nSqlDr.Item("LAST_NAME").ToString.ToUpper() & " " & _nSqlDr.Item("FIRST_NAME").ToString.ToUpper() & " " & _nSqlDr.Item("MIDDLE_NAME").ToString.ToUpper()
                    COMMNAME = _nSqlDr.Item("COMMNAME").ToString.ToUpper()
                    COMMADDR = _nSqlDr.Item("COMMADDR").ToString.ToUpper()
                    OWNERSHIP = _nSqlDr.Item("OWNERSHIP").ToString.ToUpper()
                    OWNER = Trim(OWNER)
                    MOP = _nSqlDr.Item("MOP").ToString.ToUpper()

                    ' Loop
                End If


            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectRequirements(ByVal switch As String)
        Try
            If switch = "RENEW" Then switch = "RENEWAL"
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            '_nQuery = _
            '  " SELECT " & _
            '  " R1.REQCODE,R1.REQDESC,R1.COMPLIANT,R1.SWITCH,R1.OFFICE,R1E.OWNCODE, " & _
            '  " CASE" & _
            '  " WHEN  LEN(R1.COMPLIANT)>0 THEN 'MANDATORY'" & _
            '  " ELSE 'OPTIONAL'" & _
            '  " END 'WEBCOMPLIANT'" & _
            '  " FROM REQ1 R1" & _
            '  " FULL JOIN [REQ1EXTN] R1E ON R1.REQCODE=R1E.OWNCODE " & _
            '  " WHERE R1.SWITCH='" & switch & "' order by WEBCOMPLIANT asc"
            _nQuery = "Select * from BP_Requirements where switch='" & switch & "' order by ReqCode asc"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectRequirements2(ByVal switch As String, ByVal Email As String, ByVal acctno As String)
        Try
            If switch = "RENEW" Then switch = "RENEWAL"
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
        
            _nQuery = _
                " SELECT" &
                "     REQ.REQCODE, REQ.REQDESC , REQ.COMPLIANT WEBCOMPLIANT," &
                "     Att.FileName, " &
                " 	 (CASE" &
                "         WHEN Att.FileSize < 1024 THEN CONCAT(Att.FileSize, ' Bytes')" &
                "         WHEN Att.FileSize < 1048576 THEN CONCAT(FORMAT(CONVERT(NUMERIC(18, 2), Att.FileSize) / 1024, '0.00'), ' KB')" &
                "         WHEN Att.FileSize < 1073741824 THEN CONCAT(FORMAT(CONVERT(NUMERIC(18, 2), Att.FileSize) / 1048576, '0.00'), ' MB')" &
                " " &
                "     END) AS FileSize," &
                " 	(CASE " &
                " 		WHEN isnull(att.filename,'0')='0' then null" &
                " 		else" &
                " 		concat('data:',Att.FileType,';base64,',baze64)" &
                " 	END )File64" &
                " " &
                " 	   FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.REQ1  Req	" &
                " LEFT JOIN ( " &
                "     SELECT * " &
                "     FROM BP_Attachment " &
                " " &
                "     WHERE email = '" & Email & "' AND acctno = '" & acctno & "'" &
                " ) Att ON REQ.REQCODE = Att.ReqCode " &
                " cross apply (select Att.FileData as '*' for xml path('')) T (baze64) " &
                " WHERE REQ.SWITCH = '" & switch & "' and ISNULL(ARTA,0)=1 " &
                " ORDER BY REQ.REQDESC ASC "

            '' @ ADDED 20231010
            '" SELECT" &
            '"     REQ.REQCODE, REQ.REQDESC, REQ.WEBCOMPLIANT," &
            '"     Att.FileName, " &
            '" 	 (CASE" &
            '"         WHEN Att.FileSize < 1024 THEN CONCAT(Att.FileSize, ' Bytes')" &
            '"         WHEN Att.FileSize < 1048576 THEN CONCAT(FORMAT(CONVERT(NUMERIC(18, 2), Att.FileSize) / 1024, '0.00'), ' KB')" &
            '"         WHEN Att.FileSize < 1073741824 THEN CONCAT(FORMAT(CONVERT(NUMERIC(18, 2), Att.FileSize) / 1048576, '0.00'), ' MB')" &
            '" " &
            '"     END) AS FileSize," &
            '" 	(CASE " &
            '" 		WHEN isnull(att.filename,'0')='0' then null" &
            '" 		else" &
            '" 		concat('data:',Att.FileType,';base64,',baze64)" &
            '" 	END )File64" &
            '" " &
            '" 	   FROM BP_Requirements Req	" &
            '" LEFT JOIN ( " &
            '"     SELECT * " &
            '"     FROM BP_Attachment " &
            '" " &
            '"     WHERE email = '" & Email & "' AND acctno = '" & acctno & "'" &
            '" ) Att ON REQ.REQCODE = Att.ReqCode" &
            '" cross apply (select Att.FileData as '*' for xml path('')) T (baze64) " &
            '" WHERE REQ.SWITCH = '" & switch & "'" &
            '" ORDER BY REQ.REQCODE ASC "

            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubGetAttachments(ByVal switch As String, ByVal email As String, ByVal acctno As String)
        Try
      

            If switch = "RENEW" Then switch = "RENEWAL"
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = _
                " SELECT" &
                "     REQ.REQCODE, REQ.REQDESC , REQ.COMPLIANT WEBCOMPLIANT," &
                "     Att.FileName, " &
                " 	 (CASE" &
                "         WHEN Att.FileSize < 1024 THEN CONCAT(Att.FileSize, ' Bytes')" &
                "         WHEN Att.FileSize < 1048576 THEN CONCAT(FORMAT(CONVERT(NUMERIC(18, 2), Att.FileSize) / 1024, '0.00'), ' KB')" &
                "         WHEN Att.FileSize < 1073741824 THEN CONCAT(FORMAT(CONVERT(NUMERIC(18, 2), Att.FileSize) / 1048576, '0.00'), ' MB')" &
                " " &
                "     END) AS FileSize," &
                " 	(CASE " &
                " 		WHEN isnull(att.filename,'0')='0' then null" &
                " 		else" &
                " 		concat('data:',Att.FileType,';base64,',baze64)" &
                " 	END )File64" &
                " " &
                " 	   FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.REQ1  Req	" &
                " LEFT JOIN ( " &
                "     SELECT * " &
                "     FROM BP_Attachment " &
                " " &
                "     WHERE email = '" & email & "' AND acctno = '" & acctno & "'" &
                " ) Att ON REQ.REQCODE = Att.ReqCode " &
                " cross apply (select Att.FileData as '*' for xml path('')) T (baze64) " &
                " WHERE REQ.SWITCH = '" & switch & "' and ISNULL(ARTA,0)=1  and ISNULL(FileName,'') <> '' " &
                " ORDER BY REQ.REQDESC ASC "


            ''_nQuery = _
            ''    " Select [ACCTNO],[ReqCode],[ReqDesc],[FileType],  " & _
            ''    " concat(foryear,'_',acctno,'_',reqdesc)[FileName]," & _
            ''    " concat('data:',[FileType],';base64,',baze64)File64 from [BP_Attachment] " & _
            ''    " cross apply (select [FileData] as '*' for xml path('')) T (baze64) " & _
            ''    " where acctno='" & acctno & "' and  foryear =  (select top 1 foryear from bp_attachment where acctno='" & acctno & "' order by foryear desc)" & _
            ''    " and Email='" & email & "'"

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckIfAssetExists()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim EXISTS As Boolean = 0

            _nQuery = _
              " SELECT count(*)[Exists] from ( " & _
              " select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='BUSDETAIL_TAXPAYER' " & _
              " and COLUMN_NAME='ASSET') as ctr"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    EXISTS = _nSqlDr.Item("Exists")
                End If
            End Using

            If EXISTS = 0 Then
                _pSubAlterTableAddASSET()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubAlterTableAddASSET()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "ALTER TABLE BUSDETAIL_TAXPAYER  ADD ASSET MONEY"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubCheckIfWEBASSESSNOExists()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim EXISTS As Boolean = 0

            _nQuery = _
              " SELECT count(*)[Exists] from ( " & _
              " select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='BUSDETAIL_TAXPAYER' " & _
              " and COLUMN_NAME='WEBASSESSNO') as ctr"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    EXISTS = _nSqlDr.Item("Exists")
                End If
            End Using

            If EXISTS = 0 Then
                _pSubAlterTableAddWEBASSESSNO()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubAlterTableAddWEBASSESSNO()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "ALTER TABLE BUSDETAIL_TAXPAYER  ADD WEBASSESSNO NVARCHAR(MAX)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Function getYear() As String
        Try
            Dim _nQuery As String = "select YEAR(GETDATE()) AS [YEAR];"
            Dim STRYEAR As String = Nothing
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    STRYEAR = _nSqlDr.Item("YEAR")
                End If
            End Using
            Return STRYEAR
        Catch ex As Exception
            Return Now.Year
        End Try
    End Function

    Function getReqDesc(ByVal ReqCode As String) As String
        Try
            Dim _nQuery As String = "select ReqDesc from BP_Requirements where ReqCode = '" & ReqCode & "'"
            Dim ReqDesc As String = Nothing
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    ReqDesc = _nSqlDr.Item("ReqDesc")
                End If
            End Using
            Return ReqDesc
        Catch ex As Exception

        End Try
    End Function


    Public Shared Function getReqDescNEW(ByVal ReqCode As String, ByVal Status As String) As String ' @ADDED 20231118 LOUIE
        Try
            Dim _mSqlCommand As SqlCommand
            Dim _nQuery As String = "Select REQDESC from REQ1 WHERE SWITCH = '" & Status & "' and ARTA = 1 "
            Dim ReqDesc As String = Nothing
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTAS)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    ReqDesc = _nSqlDr.Item("ReqDesc").ToString
                End If
            End Using
            Return ReqDesc
        Catch ex As Exception

        End Try
    End Function



    Public Function _pSubCheckIfTableExist(ByVal tblName As String) As Boolean
        Dim Exists As Boolean = False
        Try
            '----------------------------------      
            Dim _nQuery As String = "If exists (select * from " & cGlobalConnections._pSqlCxn_BPLTIMS.Database & ".sys.tables where name = '" & tblName.ToUpper & "')    select '1' as [Exists]	else (select '0' as [Exists])"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlCon.Open()
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    Exists = _mSqlDataReader("Exists")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception
            Exists = False
        End Try


        Return Exists


    End Function


    Public Sub _pSubCreateTable(ByVal tblName As String)
        Try
            Dim _nQuery As String
            If tblName = "BP_Attachment" Then
                _nQuery = "CREATE TABLE [dbo].[BP_Attachment](	[ACCTNO] [nvarchar](max) NULL,	[ForYear] [nvarchar](max) NULL,	[ReqCode] [nvarchar](max) NULL,	[ReqDesc] [nvarchar](max) NULL,	[FileName] [nvarchar](max) NULL,	[FileType] [nvarchar](max) NULL,	[FileData] [varbinary](max) NULL,	[FileSize] [nvarchar](max) NULL,	[Email] [nvarchar](max) NULL)"

            ElseIf tblName = "BP_Requirements" Then
                _nQuery = "CREATE TABLE [dbo].[BP_Requirements](	[REQCODE] [nvarchar](max) NULL,	[REQDESC] [nvarchar](max) NULL,	[SWITCH] [nvarchar](max) NULL,	[WEBCOMPLIANT] [nvarchar](max) NULL,[OFFICE] [nvarchar](max) NULL)"

            End If

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            With _mSqlCommand.Parameters
            End With
        Catch ex As Exception

        End Try
    End Sub



    Public Function CheckSubmitted(ByVal acctno As String) As Boolean
        Dim Exists As Boolean = False
        Try
            '----------------------------------      
            Dim _nQuery As String = "select count(*)[Exists] from [BUSDETAIL] where acctno='" & acctno & "' and status='SUBMITTED FOR RENEWAL' AND EMAIL2='" & cSessionUser._pUserID & "'"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    Exists = _mSqlDataReader("Exists")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
        Return Exists
    End Function


    Public Sub _pSubcheckIfValidInfo( _
                                    ByVal acctno As String _
                                     , ByRef _ReqCode As String _
                                     , ByRef _ReqDesc As String _
                                     , ByRef _FileName As String _
                                     , ByRef _FileType As String _
                                     , ByRef _FileData As Byte() _
                                     , ByRef _FileSize As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = ""
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            Using _nSqlDataReader As SqlDataReader = _mSqlCommand.ExecuteReader
                With _nSqlDataReader
                    Dim _iReqCode As Integer = .GetOrdinal("ReqCode")
                    Dim _iReqDesc As Integer = .GetOrdinal("ReqDesc")
                    Dim _iFileName As Integer = .GetOrdinal("FileName")
                    Dim _iFileType As Integer = .GetOrdinal("FileType")
                    Dim _iFileData As Integer = .GetOrdinal("FileData")
                    Dim _iFileSize As Integer = .GetOrdinal("FileSize")
                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes
                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read
                                _ReqCode = ._pReturnString(_nSqlDataReader(_iReqCode))
                                _ReqDesc = ._pReturnString(_nSqlDataReader(_iReqDesc))
                                _FileName = ._pReturnString(_nSqlDataReader(_iFileName))
                                _FileType = ._pReturnString(_nSqlDataReader(_iFileType))
                                _FileData = ._pReturnByteArray(_nSqlDataReader(_iFileData))
                                _FileSize = ._pReturnString(_nSqlDataReader(_iFileSize))
                            Loop
                        End If
                    End With
                End With
                _nSqlDataReader.Close()
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetAttachmentsSubmitted(ByVal ACCTNO As String, Optional ByRef reqCount As Integer = 0)
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = _
              " Select [ACCTNO],[ReqCode],[ReqDesc],[FileType],  " & _
              " concat(foryear,'_',acctno,'_',reqdesc)[FileName]," & _
              " concat('data:',[FileType],';base64,',baze64)File64 from [BP_Attachment] " & _
              " cross apply (select [FileData] as '*' for xml path('')) T (baze64) " & _
              " where acctno='" & ACCTNO & "' and  foryear =  (select top 1 foryear from bp_attachment where acctno='" & ACCTNO & "' order by foryear desc)"


            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            reqCount = _mDataTable.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Public Function hasSubmittedRequirements(ByVal acctno As String) As Boolean
        Dim Exists As Boolean = False
        Try
            '----------------------------------      
            Dim _nQuery As String = "select count(*)[Exists] from [BP_Attachment] where acctno='" & acctno & "' and  foryear =  (select top 1 foryear from bp_attachment where acctno='" & acctno & "' order by foryear desc)"
            Dim _nSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            _mSqlDataReader = _nSqlCommand.ExecuteReader
            If _mSqlDataReader.HasRows Then
                Do Until _mSqlDataReader.Read = False
                    Exists = _mSqlDataReader("Exists")
                Loop
            End If
            _mSqlDataReader.Close()
            _nSqlCommand.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try

        Return Exists
    End Function

    Public Function check_ApproveOnlineTOP() As Integer
        Dim int As Integer = 0
        Try
            Dim _nQuery As String =
                " select top 1 ISNULL(APPRV_TOP_ONLINE,0) APPRV_TOP_ONLINE  FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE" & _
                " WHERE ACCTNO = '" & cSessionLoader._pAccountNo & "' AND FORYEAR = year(getdate())"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        int = _nSqlDr("APPRV_TOP_ONLINE").ToString
                    Loop
                End If
            End Using

            Return int

        Catch ex As Exception
            Return int
        End Try
    End Function
    Public Function isReqExists(ByVal acctno As String, ByVal foryear As String, ByVal reqcode As String) As Boolean
        Dim Exists As Boolean = False
        Try
            Dim _nQuery As String =
                " Select * from [BP_Attachment] where Acctno='" & acctno & "' and foryear='" & foryear & "' and reqcode='" & reqcode & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Exists = True
                Else
                    Exists = False
                End If
            End Using
            Return Exists
        Catch ex As Exception
            Return Exists
        End Try
    End Function

    Public Function DeclineApplication(ByVal acctno As String, ByVal rmrks As String, ByVal err As String) As Boolean
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                " UPDATE [BUSDETAIL] SET STATUS='DECLINED RENEWAL APPLICATION',REMARKS='" & rmrks & "' WHERE ACCTNO='" & acctno & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            Return True
            err = Nothing
        Catch ex As Exception
            Return False
            err = ex.Message
        End Try
    End Function

    Public Function isDeclined(ByVal acctno As String) As Boolean
        Dim _status As String = Nothing
        Try
            Dim _nQuery As String =
                " select * from BUSDETAIL where acctno='" & acctno & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _status = _nSqlDr("Status").ToString
                    Loop
                End If
            End Using
            If _status = "DECLINED RENEWAL APPLICATION" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetRemarks(ByVal acctno As String) As String
        Dim _Remarks As String = Nothing
        Try
            Dim _nQuery As String =
                " select * from BUSDETAIL where acctno='" & acctno & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _Remarks = _nSqlDr("Remarks").ToString
                    Loop
                End If
            End Using
            Return _Remarks
        Catch ex As Exception
            Return _Remarks
        End Try
    End Function

    Public Sub ApproveForPayment(ByVal acctno As String)
        Try
            Dim _nQuery As String = Nothing
            ' _nQuery = _
            '    " UPDATE BUSDETAIL_TAXPAYER SET ISASSESS = 1, STATUS='APPROVED FOR PAYMENT' WHERE ACCTNO='" & acctno & "' and foryear=cast(year(getdate()) as nvarchar(MAX))"

            _nQuery = _
                " Update BUSDETAIL_TAXPAYER" & _
                " SET ISASSESS = 1" & _
                " WHERE" & _
                " ACCTNO='" & acctno & "' " & _
                " and foryear=cast(year(getdate()) as nvarchar(MAX));" & _
                " Update BUSDETAIL" & _
                " SET STATUS='APPROVED FOR PAYMENT' " & _
                " WHERE" & _
                " ACCTNO='" & acctno & "' "


            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub GenerateWebAssessNo(ByVal acctno As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = _
                " update BUSDETAIL_TAXPAYER set webassessno = (" &
                " select concat((select isnull(Masking,'WEB-') from [" & cGlobalConnections._pSqlCxn_CR.Database & "].dbo.[MASKING] where module='BP'),year(getdate()),'-',(" &
                " SELECT REPLACE(STR((" &
                " SELECT CASE WHEN ISNULL((" &
                " SELECT  TOP 1 RIGHT(WebAssessNo,6) FROM [BUSDETAIL_TAXPAYER]" &
                " WHERE YEAR(datesubmit) = YEAR(GETDATE()) and ISASSESS = 1" &
                " ORDER BY WebAssessNo DESC),'0')='0' THEN  '0'" &
                " ELSE ( SELECT  TOP 1 RIGHT(WebAssessNo,6) FROM [BUSDETAIL_TAXPAYER]" &
                " WHERE YEAR(datesubmit) = YEAR(GETDATE()) and ISASSESS = 1" &
                " ORDER BY WebAssessNo DESC)" &
                " END NEWSEQ)+1,6),' ','0')))WebAssessNo)" &
                " where acctno = '" & acctno & "'"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _getModeP(ByVal ACCTNO As String)
        Try
            Dim _nQuery As String =
                " select top 1 (Pres +' '+ Prev) as 'PeriodCovered', " & _
                " CASE WHEN ModeP='A' THEN 'Annual' WHEN ModeP='S' THEN 'Semi-Annual' WHEN ModeP='Q' THEN 'Quarterly' ELSE ModeP	END  as 'PayMode'," & _
                " foryear from BILLINGTEMP where acctno='" & ACCTNO & "' and foryear=cast(year(getdate())as nvarchar(max)) order by modep desc"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        cSessionLoader._pPayMode = _nSqlDr("PayMode").ToString
                        cSessionLoader._pPeriodCovered = _nSqlDr("PeriodCovered").ToString
                        cSessionLoader._pFORYEAR = _nSqlDr("Foryear").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Public Function _checkHasBillingTemp(ByVal ACCTNO As String) As Boolean
        Dim hasrow As Boolean = False
        Try
            Dim _nQuery As String =
                "  select * from BILLINGTEMP where acctno='" & ACCTNO & "' and isnull(isposted,0)=0 and IsRegBill='1' and foryear=cast(year(getdate()) as nvarchar(max))"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasrow = True
                Else
                    hasrow = False
                End If
            End Using
            Return hasrow
        Catch ex As Exception
            Return hasrow
        End Try
    End Function

    Public Function _isValid(ByVal ACCTNO As String, _
                             ByRef DateEsta As String, _
                             ByRef BusName As String, _
                             ByRef ownership As String, _
                             ByRef BusAddress As String, _
                             ByRef OwnerName As String, _
                             ByRef OwnerAddress As String) As Boolean
        Dim hasrow As Boolean = False
        Try
            Dim fname, lname, mname As String
            Dim _nQuery As String =
                "  Select oc.owndesc,* from busmast bm" & _
                "  inner join  owncode OC on bm.owncode=oc.owncode" & _
                "  where bm.acctno='" & ACCTNO & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasrow = True
                    Do While _nSqlDr.Read
                        DateEsta = _nSqlDr("Date_Esta").ToString
                        BusName = _nSqlDr("COMMNAME").ToString.ToUpper
                        ownership = _nSqlDr("OWNDESC").ToString.ToUpper
                        BusAddress = _nSqlDr("COMMADDR").ToString
                        lname = IIf(_nSqlDr("LAST_NAME").ToString = Nothing, Nothing, _nSqlDr("LAST_NAME").ToString.ToUpper & ", ")
                        fname = IIf(_nSqlDr("FIRST_NAME").ToString = Nothing, Nothing, _nSqlDr("FIRST_NAME").ToString.ToUpper & " ")
                        mname = IIf(_nSqlDr("MIDDLE_NAME").ToString = Nothing, Nothing, _nSqlDr("MIDDLE_NAME").ToString.ToUpper)
                        OwnerAddress = _nSqlDr("OWNERADDR").ToString.ToUpper
                        OwnerName = lname & fname & mname
                    Loop
                Else
                    hasrow = False
                End If
            End Using
            Return hasrow
        Catch ex As Exception
            Return hasrow
        End Try
    End Function

    Public Function _isEnrolled(ByVal ACCTNO As String, ByRef EMAIL As String) As Boolean
        Dim hasrow As Boolean = False
        Try
            Dim fname, lname, mname As String
            Dim _nQuery As String =
                "  SELECT * FROM BUSDETAIL " & _
                "  where ACCTNO='" & ACCTNO & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasrow = True
                    Do While _nSqlDr.Read
                        EMAIL = _nSqlDr("EMAIL2").ToString
                    Loop
                Else
                    hasrow = False
                End If
            End Using
            Return hasrow
        Catch ex As Exception
            Return hasrow
        End Try
    End Function

    Public Function _isClosed(ByVal ACCTNO As String) As Boolean
        Dim hasrow As Boolean = False
        Try
            Dim fname, lname, mname As String
            Dim _nQuery As String =
                "  SELECT * FROM HISTORYBUSMAST " & _
                "  where ACCTNO='" & ACCTNO & "' AND REMARK='CLOSED'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasrow = True
                Else
                    hasrow = False
                End If
            End Using
            Return hasrow
        Catch ex As Exception
            Return hasrow
        End Try
    End Function

    Public Function _DirectEnroll(ByVal ACCTNO As String, ByVal email2 As String, ByRef ERR As String) As Boolean
        Try
            Dim email As String = Replace(email2, ".", "")

            Dim _nQuery As String = "" & _
                           "INSERT INTO [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].[DBO].[BUSDETAIL]" & _
                           " SELECT                                                                                                               " & _
                           "	'" & email & "'EMAIL,                                                                                     " & _
                           "		BM.ACCTNO , 	                                                                                              " & _
                           "		GETDATE()REQDATE,		                                                                                      " & _
                           "		(SELECT top 1 ORNO1 FROM BUSLINE WHERE ACCTNO='" & ACCTNO & "' AND ORNO1 IS NOT NULL ORDER BY FORYEAR DESC)ORNO	, " & _
                           "	CONCAT(                                                                                                           " & _
                           "	IIF((ISNULL(BM.LAST_NAME,'0'))='0','',CONCAT(BM.LAST_NAME,' ')),                                                  " & _
                           "	IIF((ISNULL(BM.FIRST_NAME,'0'))='0','',CONCAT(BM.FIRST_NAME,' ')),                                                " & _
                           "	IIF((ISNULL(BM.MIDDLE_NAME,'0'))='0','',CONCAT(BM.MIDDLE_NAME,' ')))OWNER,	                                      " & _
                           "	BM.COMMNAME AS BUSNAME,	                                                                                          " & _
                           "	BM.COMMADDR AS BUSADDRESS,                                                                                        " & _
                           "	STUFF((SELECT distinct ' || ' + BC.[DESCRIPTION]   FROM [BUSCODE] BC                                              " & _
                           "		INNER JOIN BUSLINE BL    ON BM.ACCTNO = BL.ACCTNO                                                             " & _
                           "		WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND	BM.ACCTNO = BL.ACCTNO                                                 " & _
                           "		 AND BL.FORYEAR = (SELECT TOP 1 FORYEAR FROM BUSLINE WHERE ACCTNO='" & ACCTNO & "' ORDER BY FORYEAR DESC)            " & _
                           "		FOR XML PATH('')), 1, 3, '') AS CATEGORY,                                                                     " & _
                           "			'1'VERIFIED,                                                                                              " & _
                           "			'" & cSessionUser._pUserID & "'VERIFIEDBY,                                                                                    " & _
                           "			GETDATE()VERIFIEDDATE,                                                                                    " & _
                           "			'DIRECT ENROLLMENT'REMARKS,                                                                                         " & _
                           "			'APPROVED'STATUS,                                                                                         " & _
                           "			'" & email2 & "'EMAIL2,                                                                            " & _
                           "	STUFF((SELECT DISTINCT ' || ' + CC.CATDESC FROM BUSLINE BL                                                        " & _
                           "		INNER JOIN BUSMAST BM ON BL.ACCTNO=BM.ACCTNO                                                                  " & _
                           "		INNER JOIN BUSCODE BC ON BL.BUS_CODE=BC.BUS_CODE                                                              " & _
                           "		INNER JOIN CATCODE CC ON BC.CATEGORY = CC.CATCODE                                                             " & _
                           "		where BM.ACCTNO='" & ACCTNO & "'                                                                                     " & _
                           "		AND BL.FORYEAR = (SELECT TOP 1 FORYEAR FROM BUSLINE WHERE ACCTNO='" & ACCTNO & "' ORDER BY FORYEAR DESC)             " & _
                           "		FOR XML PATH('')), 1, 3, '') AS CATEGORY1,                                                                    " & _
                           "		(SELECT TOP 1                                                                                                 " & _
                           "		CASE                                                                                                          " & _
                           "			WHEN ModeP='A' THEN 'Annual'                                                                              " & _
                           "			WHEN ModeP='S' THEN 'Semi-Annual'                                                                         " & _
                           "			WHEN ModeP='Q' THEN 'Quarterly'                                                                           " & _
                           "			ELSE ModeP	END                                                                                           " & _
                           "		FROM BILLINGTEMP WHERE ACCTNO='" & ACCTNO & "' AND FORYEAR=YEAR(GETDATE()) AND (TAXCODE='BT' OR TAXCODE='GF')        " & _
                           "		ORDER BY TAXCODE DESC, MODEP DESC)MOP	                                                                      " & _
                           " FROM BUSMAST BM where BM.ACCTNO='" & ACCTNO & "'"
            _mQuery = _nQuery
            '----------------------------------
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Return False
            ERR = ex.Message
        End Try
    End Function


    Public Sub _getNotificationCtr_BPLO()
        Try
            Dim fname, lname, mname As String
            Dim _nQuery As String =
                " select  " & _
                " 	(select count(*) from BUSDETAIL where Verified = 0)ctrEBP ,  " & _
                " 	(select count(*) from " & _
                " 	( " & _
                " 	SELECT DISTINCT   B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = year(getdate()) ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = year(getdate()) AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = year(getdate())) and (B.Status='Approved' or B.status='SUBMITTED FOR RENEWAL')    group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1 " & _
                " 	) as subq)ctrRBP, " & _
                " 	(select count(*) from ( " & _
                " 	SELECT  Status,Application_ID,Date_Submitted as 'APP_DATE',userid as 'EMAILADDR',IIF(A_OWNERSHIP='Single',D_Lname + ' ' + D_FName +' ' + D_Mname + ' ' + D_Suffix,E_Lname + ' ' + E_FName +' ' + E_Mname + ' ' + E_Suffix) AS 'OwnerName', A_BusName as 'COMMNAME' FROM NEWBP_DRAFT WHERE STATUS ='Submitted/Pending'  " & _
                " 	) as subq " & _
                " )ctrNBP, " & _
                " (select count(*) from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.Appointment where office='BPLO' and Status='Pending' and  appdate = getdate())ctrAL, " & _
                " (select count(*) from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.Appointment where office='BPLO' and Status='Pending Approval')ctrAR, " & _
                " (select count(*) from ( " & _
                "  SELECT BM.ACCTNO, BD.EMAIL2, BM.COMMNAME, convert(varchar, BP.DATEPAID, 107)DATEPAID, convert(varchar, BP.ISSUANCEDATE, 107)ISSUANCEDATE, convert(varchar, BP.EXPIRATIONDATE, 107)EXPIRATIONDATE   " & _
                "  FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].[dbo].BUSMAST BM  " & _
                "  INNER JOIN [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].[dbo].BUSINESSPERMIT BP ON BM.ACCTNO=BP.ACCTNO 	  " & _
                "  INNER JOIN [busdetail] BD ON bd.ACCTNO=BP.ACCTNO 	  " & _
                "  where bm.ACCTNO in (select acctno from [busdetail] where status <> 'Issued/Sent') and BP.foryear=year(getdate())  " & _
                "  ) as subq)ctrBPI," & _
                " (select count(*) from (" & _
                " SELECT DISTINCT  B.EMAIL, B.ACCTNO, B.ReqDate, B.ORNo, B.OWNER, B.BUSNAME, B.BUSADDRESS, B.CATEGORY, B.Verified, B.VerifiedBy, B.VerifiedDate, B.Remarks, B.Status, B.EMAIL2, B.CATEGORY1,max(BT.DATESUBMIT)   DATESUBMIT2,(SELECT TOP 1 DATESUBMIT FROM BUSDETAIL_TAXPAYER WHERE ACCTNO = B.ACCTNO AND ISNULL(ISASSESS,0) = 0 AND FORYEAR = year(getdate())  ) AS DATESUBMIT FROM BUSDETAIL B INNER JOIN BUSDETAIL_TAXPAYER BT ON B.ACCTNO = BT.ACCTNO WHERE ISNULL(BT.ISASSESS,0) = 0 AND BT.FORYEAR = year(getdate())  AND BT.GROSSNEW IS NOT NULL AND BT.ACCTNO NOT IN (SELECT ACCTNO FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BUSLINE WHERE ISNULL(APPRV_TOP_ONLINE,0) = 1 AND FORYEAR = year(getdate()) ) and b.Status='Approved for Treasury'   group by EMAIL, B.ACCTNO, ReqDate, ORNo, OWNER, BUSNAME, BUSADDRESS,B.CATEGORY, Verified, VerifiedBy, VerifiedDate, Remarks, Status, EMAIL2,B.CATEGORY1 " & _
                " ) as subq)ctrBRL"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _ctrEBP = _nSqlDr("ctrEBP").ToString
                        _ctrRBP = _nSqlDr("ctrRBP").ToString
                        _ctrNBP = _nSqlDr("ctrNBP").ToString
                        _ctrAL = _nSqlDr("ctrAL").ToString
                        _ctrAR = _nSqlDr("ctrAR").ToString
                        _ctrBPI = _nSqlDr("ctrBPI").ToString
                        _ctrBRL = _nSqlDr("ctrBRL").ToString
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
                " SELECT EMAIL2,OWNER FROM BUSDETAIL WHERE ACCTNO='" & acctno & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasRows = True
                    Do While _nSqlDr.Read
                        TPName = _nSqlDr("OWNER").ToString
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

    Public Function isAttachmentExists(ByVal acctno As String, ByVal foryear As String, ByVal ReqCode As String, ByVal Email As String) As Boolean
        Dim hasRows As Boolean = False
        Try
            Dim _nQuery As String =
                " SELECT * from BP_ATTACHMENT where " &
                " acctno='" & acctno & "' and " &
                " foryear='" & foryear & "' and " &
                " ReqCode='" & ReqCode & "' and " &
                " Email='" & Email & "'"
            _mQuery = _nQuery
            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    hasRows = True
                Else
                    hasRows = False
                End If
            End Using
            Return hasRows
        Catch ex As Exception
            hasRows = False
        End Try
        Return hasRows
    End Function
   
    Public Function Get_WebRequirements(ByVal Switch As String, ByVal Compliant As String, ByVal SortBy As String, ByVal Order As String, ByVal Office As String) As DataTable
        _mDataTable = New DataTable
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            If Office = "ALL" And Switch = "ALL" And Compliant = "ALL" Then                 'NO FILTER
                _nWhere = Nothing

            ElseIf Office <> "ALL" And Switch = "ALL" And Compliant = "ALL" Then            'FILTER BY OFFICE
                _nWhere = " where OFFICE='" & Office & "'"

            ElseIf Office = "ALL" And Switch <> "ALL" And Compliant = "ALL" Then            'FILTER BY SWITCH
                _nWhere = " where SWITCH='" & Switch & "'"

            ElseIf Office = "ALL" And Switch = "ALL" And Compliant <> "ALL" Then            'FILTER BY COMPLIANT
                _nWhere = " where Compliant='" & Compliant & "'"

            ElseIf Office <> "ALL" And Switch <> "ALL" And Compliant = "ALL" Then           'FILTER BY OFFICE and SWITCH
                _nWhere = " where OFFICE='" & Office & "' and SWITCH='" & Switch & "'"

            ElseIf Office <> "ALL" And Switch = "ALL" And Compliant <> "ALL" Then           'FILTER BY OFFICE and COMPLIANT
                _nWhere = " where OFFICE='" & Office & "' and Compliant='" & Compliant & "'"

            ElseIf Office = "ALL" And Switch <> "ALL" And Compliant <> "ALL" Then           'FILTER BY SWITCH and COMPLIANT
                _nWhere = " where SWITCH='" & Switch & "' and Compliant='" & Compliant & "'"

            ElseIf Office <> "ALL" And Switch <> "ALL" And Compliant <> "ALL" Then          'FILTER BY OFFICE, SWITCH and COMPLAINT
                _nWhere = " where OFFICE='" & Office & "' and SWITCH='" & Switch & "' and COMPLIANT='" & Compliant & "'"
            End If

            'If Switch = "ALL" And Compliant = "ALL" Then
            '    _nWhere = Nothing
            'ElseIf Switch = "ALL" And Compliant <> "ALL" Then
            '    _nWhere = " where WebCompliant='" & Compliant & "'"
            'ElseIf Switch <> "ALL" And Compliant = "ALL" Then
            '    _nWhere = " where Switch='" & Switch & "'"
            'ElseIf Switch <> "ALL" And Compliant <> "ALL" Then
            '    _nWhere = " where Switch='" & Switch & "' and  WebCompliant='" & Compliant & "'"
            'End If

            _mQuery = "Select * from BP_Requirements " & _nWhere & " Order by " & SortBy & " " & Order
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mQuery, _mSqlCon)
            _nSqlDataAdapter.Fill(_mDataTable)
        Catch ex As Exception
        End Try
        Return _mDataTable
    End Function

    Public Function Generate_ReqCode() As String
        Dim ReqCode As String
        Try
            _mQuery = " SELECT REPLACE(STR((SELECT CASE WHEN ISNULL((SELECT  TOP 1 ReqCode FROM BP_Requirements ORDER BY ReqCode DESC),0)=0 THEN  0 ELSE (SELECT  TOP 1 ReqCode FROM BP_Requirements ORDER BY ReqCode DESC) END )+1,4),' ','0') AS NewReqCode"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        ReqCode = _nSqlDr("NewReqCode").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception
        End Try
        Return ReqCode
    End Function


    Sub _BPRequirements(ByVal Qry As String, ByVal Code As String, ByVal Switch As String, ByVal Compliant As String, ByVal Desc As String)
        Try
            Dim _nQuery As String

            Select Case Qry.ToUpper
                Case "ADD"
                    _nQuery = "Insert Into BP_Requirements Values('" & Code & "','" & Desc & "','" & Switch & "','" & Compliant & "')"
                Case "EDIT"
                    _nQuery = "Update BP_Requirements Set Switch='" & Switch & "',WebCompliant='" & Compliant & "',ReqDesc='" & Desc & "' where ReqCode='" & Code & "'"
                Case "DELETE"
                    _nQuery = "Delete from BP_Requirements where ReqCode='" & Code & "'"
            End Select

            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try

    End Sub

    Public Function Get_BusInfo(ByVal Acctno As String)
        Dim Result As New DataTable
        Try
            Dim _xQuery As String = Nothing
            _xQuery = _
                " select top 1 BM.acctno,SOS.Owner,BM.COMMNAME,bm.COMMADDR," &
                         " (case when BT.STATCODE = 'R' then 'Renewal' when BT.STATCODE = 'N' then 'New' end)STATCODE," &
                         " BT.DATEAPP,(Select OWNDESC from OWNCODE Where OWNCODE = BM.OWNCODE )OwnCode," &
                         " BT.Area,BM.NO_EMP,BT.EDPPRINTED," &
                         " (case when BT.ModeP ='A' then 'Annual'" &
                         " when BT.ModeP='Q' then 'Quarterly Installment'" &
                         " when BT.ModeP='S' then 'Semi-Anual' end)ModeP," &
                         " BT.CTC_REMARK,BT.CTC_AMOUNT,BT.Date_Expire," &
                         " TS.notice1,TS.notice2,TS.notice3,TS.notice4,TS.notice5,TS.notice6," &
                         " Isnull(PC_L.title,'') + ' ' + Isnull(PC_L.FNAME,'') + ' ' + Isnull(PC_L.MNAME,'') + ' ' + Isnull(PC_L.LNAME,'') as L_Signatory,(PC_L.DESIGNATION)L_Designation, " &
                         " (TS.BPLA)BPLA,(cr.rpt_Header2)LGU_NAME,cr.LGU_LOGO" &
                         " from billingtemp BT" &
                         " CROSS JOIN TOPSETUP TS" &
                         " CROSS JOIN [" & cGlobalConnections._pSqlCxn_CR.DataSource & "].[" & cGlobalConnections._pSqlCxn_CR.Database & "].dbo.LGU_Profile CR" &
                         " inner JOIN PersCode PC_L on " &
                         " (CASE WHEN (TS.SRAB IS NULL OR TS.SRAB = '')  " &
                         " THEN TS.SAFP1        ELSE TS.SRAB    END ) = PC_L.DESIGNATION " &
                         " inner join busmast BM on BT.acctno=BM.acctno " &
                         " inner join [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.Busdetail SOS ON BT.acctno=SOS.acctno" &
                         " where BT.acctno='" & Acctno & "'  and BT.isregbill='1'"
            _mSqlCommand = New SqlCommand(_xQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_xQuery, _mSqlCon)
            _nSqlDataAdapter.Fill(Result)
        Catch

        End Try
        Return Result
    End Function

    Public Function Get_BillInfo(ByVal Acctno As String)
        Dim Result As New DataTable
        Try

            Dim _xQuery As String = Nothing
            _xQuery = _
             " select Bus_Code,Desc1,cast(taxbase as money)taxbase,cast(taxdue as money)Taxdue," &
             " cast(PenDue as money)PenDue,  cast(Totdue as money)Totdue,Pres,prev, Discount " &
             " from BILLINGTEMP where ACCTNO='" & Acctno & "' and isregbill='1'" &
             " order by (case Taxcode when 'bt' then 0 else 1 end)," &
             " (case Taxcode when 'gf' then 0 else 1 end)"
            _mSqlCommand = New SqlCommand(_xQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_xQuery, _mSqlCon)
            _nSqlDataAdapter.Fill(Result)
        Catch

        End Try
        Return Result
    End Function

    Public Function PaymentAttemptFound() As Boolean
        Dim result As Boolean = False
        Try
            Dim _xQuery As String = _
              "select * from OnlinePaymentRefno where acctno='" & cSessionLoader._pAccountNo & "' and year(TransDate) = year(getdate())"
            _mSqlCommand = New SqlCommand(_xQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then result = True
            End Using
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function


    '-------------TOMI END

End Class



