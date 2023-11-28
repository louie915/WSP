

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalPDSRPTAS

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader



    Private _mDataSet As DataSet
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
#End Region

#Region "Variables Field"

    Private _mIDNo As String
    Private _mImgfile As Byte()
    Private _mAddress1 As String
    Private _mAddress2 As String
    Private _mAddress3 As String
    Private _mZipCode As String
    Private _mTelNo As String
    Private _mTDN As String

    Private _mOrigIDNo As String
    Private _mOrigAddress1 As String
    Private _mOrigAddress2 As String
    Private _mOrigAddress3 As String
    Private _mOrigZipCode As String
    Private _mOrigTelNo As String
    Private _mOrigTDN As String


    Private _mDefault As Boolean = Nothing

    Private _mRegion As String
    Private _mProv As String
    Private _mCity As String
    Private _mDistrict As String
    Private _mDateValue As String

    Private _mMode As String

    Public _mctr_no As String


    Private _mUseTableTmpBill As String

    Private _mEmail As String
    Private _mdbUI As String
    Private _mdbPW As String
    Private _mFieldsWhere As String
    Private _mAssessNo As String
    Private _mGrandTotal As String


    Private _mPIN As String
    Private _mKIND As String
    Private _mOWNER As String
    Private _mLOCATION As String

    Private _mLocServer As String
    Private _mLocDB As String

    Private _mYr As String
    Private _mQtr As String
#End Region

#Region "Properties Field"

    Public Property _pYr() As String
        Get
            Return _mYr
        End Get
        Set(ByVal value As String)
            _mYr = value
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
    Public Property _pOWNER() As String
        Get
            Return _mOWNER
        End Get
        Set(ByVal value As String)
            _mOWNER = value
        End Set
    End Property
    Public Property _pLOCATION() As String
        Get
            Return _mLOCATION
        End Get
        Set(ByVal value As String)
            _mLOCATION = value
        End Set
    End Property
    Public Property _pKIND() As String
        Get
            Return _mKIND
        End Get
        Set(ByVal value As String)
            _mKIND = value
        End Set
    End Property
    Public Property _pPIN() As String
        Get
            Return _mPIN
        End Get
        Set(ByVal value As String)
            _mPIN = value
        End Set
    End Property
    Public Property _pGrandTotal() As String
        Get
            Return _mGrandTotal
        End Get
        Set(ByVal value As String)
            _mGrandTotal = value
        End Set
    End Property
    Public Property _pAssessNo() As String
        Get
            Return _mAssessNo
        End Get
        Set(ByVal value As String)
            _mAssessNo = value
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
    Public Property _pdbPW() As String
        Get
            Return _mdbPW
        End Get
        Set(ByVal value As String)
            _mdbPW = value
        End Set
    End Property
    Public Property _pimgfile As Byte()
        Get
            Return _mImgfile
        End Get
        Set(ByVal value As Byte())
            _mImgfile = value
        End Set
    End Property
    Public Property _pdbUI() As String
        Get
            Return _mdbUI
        End Get
        Set(ByVal value As String)
            _mdbUI = value
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

    Public Property _pUseTableTmpBill() As String
        Get
            Return _mUseTableTmpBill
        End Get
        Set(ByVal value As String)
            _mUseTableTmpBill = value
        End Set
    End Property

    Public Property _pctr_no() As String
        Get
            Return _mctr_no
        End Get
        Set(ByVal value As String)
            _mctr_no = value
        End Set
    End Property

    Public Property _pMode() As String
        Get
            Return _mMode
        End Get
        Set(ByVal value As String)
            _mMode = value
        End Set
    End Property



    Public Property _pRegion() As String
        Get
            Return _mRegion
        End Get
        Set(ByVal value As String)
            _mRegion = value
        End Set
    End Property

    Public Property _pProv() As String
        Get
            Return _mProv
        End Get
        Set(ByVal value As String)
            _mProv = value
        End Set
    End Property
    Public Property _pCity() As String
        Get
            Return _mCity
        End Get
        Set(ByVal value As String)
            _mCity = value
        End Set
    End Property

    Public Property _pDateValue() As String
        Get
            Return _mDateValue
        End Get
        Set(ByVal value As String)
            _mDateValue = value
        End Set
    End Property

    Public Property _pDistrict() As String
        Get
            Return _mDistrict
        End Get
        Set(ByVal value As String)
            _mDistrict = value
        End Set
    End Property


    Public Property _pIDNo() As String
        Get
            Return _mIDNo
        End Get
        Set(ByVal value As String)
            _mIDNo = value
        End Set
    End Property
    Public Property _pAddress1() As String
        Get
            Return _mAddress1
        End Get
        Set(ByVal value As String)
            _mAddress1 = value
        End Set
    End Property
    Public Property _pAddress2() As String
        Get
            Return _mAddress2
        End Get
        Set(ByVal value As String)
            _mAddress2 = value
        End Set
    End Property
    Public Property _pAddress3() As String
        Get
            Return _mAddress3
        End Get
        Set(ByVal value As String)
            _mAddress3 = value
        End Set
    End Property
    Public Property _pZipCode() As String
        Get
            Return _mZipCode
        End Get
        Set(ByVal value As String)
            _mZipCode = value
        End Set
    End Property
    Public Property _pTelNo() As String
        Get
            Return _mTelNo
        End Get
        Set(ByVal value As String)
            _mTelNo = value
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
    Public Property _pDefault() As Boolean
        Get
            Return _mDefault
        End Get
        Set(ByVal value As Boolean)
            _mDefault = value
        End Set
    End Property


    Public Property _pOrigAddress1() As String
        Get
            Return _mOrigAddress1
        End Get
        Set(ByVal value As String)
            _mOrigAddress1 = value
        End Set
    End Property
    Public Property _pOrigAddress2() As String
        Get
            Return _mOrigAddress2
        End Get
        Set(ByVal value As String)
            _mOrigAddress2 = value
        End Set
    End Property
    Public Property _pOrigAddress3() As String
        Get
            Return _mOrigAddress3
        End Get
        Set(ByVal value As String)
            _mOrigAddress3 = value
        End Set
    End Property
    Public Property _pOrigZipCode() As String
        Get
            Return _mOrigZipCode
        End Get
        Set(ByVal value As String)
            _mOrigZipCode = value
        End Set
    End Property
    Public Property _pOrigTelNo() As String
        Get
            Return _mOrigTelNo
        End Get
        Set(ByVal value As String)
            _mOrigTelNo = value
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
#End Region

#Region "Routine Command"

    Public Sub _pSubRptInformation()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT TDN,PIN,TRANS_CD,OWN.Name OWNERNAME,OWN.TIN OWNERTIN,OWN.Address OWNERADDRESS,OWN.Tel_no OWNERTELNO, " & _
                "ADM.Name ADMNAME,ADM.TIN ADMINTIN,ADM.Address ADMADDRESS,ADM.Tel_no ADMTELNO, LOCATION,BRGY.DESCRIPTION BARANGAY,CER_TIT_NO TCT,TCT_DATE " & _
                ",ASS_LOT_NO SURVEYNO,LOTE_NO,BLOCK_NO,NORTH,SOUTH,EAST,WEST,RPT.EFF_DATE FROM RPTMAST RPT LEFT OUTER JOIN RPTOWNER OWN on RPT.OWNER_NO = own.Owner_No " & _
                "LEFT OUTER JOIN RPTOWNER ADM on RPT.ADMIN_NO = ADM.Owner_No LEFT OUTER JOIN BARANGAY BRGY ON BRGY.REGION = RPT.REGION  " & _
                "AND BRGY.PROV = RPT.PROV AND BRGY.CITY = RPT.CITY AND BRGY.DISTRICT = RPT.DIST_NO AND BRGY.CODE = RPT.BCODE   " & _
                "WHERE        (TDN = '" & _mTDN & "')  "



            _mQuery = _nQuery & _nWhere


            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubRptPrevInformation()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "select CANCELS,Pin,sum(Pass_value)Pass_value,Name from MASTEXTN " & _
                 "left outer join Rptowner on Rptowner.Owner_No = MASTEXTN.Powner_no " & _
                 "where tdn = '" & _mTDN & "' " & _
                 "group by CANCELS,Pin,Name "



            _mQuery = _nQuery & _nWhere


            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubRptInformationAssessment()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "Select CLASSIFICATION,SUB_CLASS,ASS_LEVEL, SUM(SQAREA)SQAREA, SUM(MARKET_VAL)MARKET_VAL ,ACTUAL_USE,SUM(ASS_VALUE)ASS_VALUE,KIND,TAXABILITY " & _
               " from rpt_ass where tdn = '" & _mTDN & "'  Group By  CLASSIFICATION,ACTUAL_USE,KIND,SUB_CLASS,ASS_LEVEL,TAXABILITY "



            _mQuery = _nQuery & _nWhere


            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubRptInformationPay()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "select ORNo,kind,Classification,ACTUAL_USE,SUBCLASS,For_year,Prev_period +' '+ Pres_period PERIODCOVERED,isnull(Cash_Amt,0)+isnull(Check_Amt,0) AMOUNT " & _
               " from payment where tdn='" & _mTDN & "' order by For_year desc "



            _mQuery = _nQuery & _nWhere


            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectAddress()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT " & _
               "* " & _
               "FROM [PDSAddress] " & _
                " "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mIDNo) Then

                _nWhere = "WHERE [IDNo] = @_mIDNo "

            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsert()
        Try
            '----------------------------------
            If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
            If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub


            '----------------------------------
            Dim _nQuery As String = Nothing

            '----------------------------------
            _nQuery = _
             "INSERT INTO " & _
             "[PDSAddress] " & _
             "(" & _
                IIf(String.IsNullOrWhiteSpace(_mIDNo), "", " [IDNo]") & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress1), "", ", [Address1]") & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", [Address2]") & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", [Address3]") & _
                IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", [ZipCode]") & _
                IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", [TelNo]") & _
                    IIf((_mDefault) = Nothing, "", ", [Default]") & _
             ") " & _
             "VALUES " & _
             "(" & _
                IIf(String.IsNullOrWhiteSpace(_mIDNo), "", " @_mIDNo") & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress1), "", ", @_mAddress1") & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", @_mAddress2") & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", @_mAddress3") & _
                IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", @_mZipCode") & _
                IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", @_mTelNo") & _
                    IIf((_mDefault) = Nothing, "", ", @_mDefault") & _
             ") "

            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

                If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
                If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
                If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)

                If Not String.IsNullOrWhiteSpace(_mZipCode) Then .AddWithValue("@_mZipCode", _mZipCode)
                If Not String.IsNullOrWhiteSpace(_mTelNo) Then .AddWithValue("@_mTelNo", _mTelNo)

                If Not (_mDefault) = Nothing Then .AddWithValue("@_mDefault", _mDefault)

            End With

            _mSqlCommand.ExecuteNonQuery()



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubUpdate()
        Try
            '----------------------------------
            'Check Required Fields...
            If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
            If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub
            If String.IsNullOrWhiteSpace(_mAddress2) Then Exit Sub
            If String.IsNullOrWhiteSpace(_mAddress3) Then Exit Sub

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------
            _nQuery = _
                "UPDATE " & _
                "[PDSAddress] " & _
                "SET " & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress1), "", " [Address1] = @_mAddress1") & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress2), "", ", [Address2] = @_mAddress2") & _
                    IIf(String.IsNullOrWhiteSpace(_mAddress3), "", ", [Address3] = @_mAddress3") & _
                        IIf(String.IsNullOrWhiteSpace(_mZipCode), "", ", [ZipCode] = @_mZipCode") & _
                        IIf(String.IsNullOrWhiteSpace(_mTelNo), "", ", [TelNo] = @_mTelNo") & _
                    IIf((_mDefault) = Nothing, "", ", [Default] = @_mDefault") & _
                " "

            '----------------------------------

            If Not String.IsNullOrWhiteSpace(_mIDNo) Then

                _nWhere = "WHERE [IDNo] = @_mIDNo "
                If Not String.IsNullOrWhiteSpace(_mOrigAddress1) Then _nWhere += "AND [Address1] = @_mOrigAddress1 "
                If Not String.IsNullOrWhiteSpace(_mOrigAddress2) Then _nWhere += "AND [Address2] = @_mOrigAddress2 "
                If Not String.IsNullOrWhiteSpace(_mOrigAddress3) Then _nWhere += "AND [Address3] = @_mOrigAddress3 "

            Else
                _nWhere = Nothing

            End If



            '----------------------------------
            'Prevent Bulk Update.
            If _nWhere = Nothing Then
                Exit Sub
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)
                If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
                If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
                If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)
                If Not String.IsNullOrWhiteSpace(_mZipCode) Then .AddWithValue("@_mZipCode", _mZipCode)
                If Not String.IsNullOrWhiteSpace(_mTelNo) Then .AddWithValue("@_mTelNo", _mTelNo)
                If Not String.IsNullOrWhiteSpace(_mDefault) Then .AddWithValue("@_mDefault", _mDefault)

                If Not String.IsNullOrWhiteSpace(_mOrigAddress1) Then .AddWithValue("@_mOrigAddress1", _mOrigAddress1)
                If Not String.IsNullOrWhiteSpace(_mOrigAddress2) Then .AddWithValue("@_mOrigAddress2", _mOrigAddress2)
                If Not String.IsNullOrWhiteSpace(_mOrigAddress3) Then .AddWithValue("@_mOrigAddress3", _mOrigAddress3)
                If Not String.IsNullOrWhiteSpace(_mOrigZipCode) Then .AddWithValue("@_mOrigZipCode", _mOrigZipCode)
                If Not String.IsNullOrWhiteSpace(_mOrigTelNo) Then .AddWithValue("@_mOrigTelNo", _mOrigTelNo)
                'If Not String.IsNullOrWhiteSpace(_mOrigName) Then .AddWithValue("@_mOrigName", _mOrigName)

            End With


            _mSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDelete()
        Try
            '----------------------------------
            If String.IsNullOrWhiteSpace(_mIDNo) Then Exit Sub
            If String.IsNullOrWhiteSpace(_mAddress1) Then Exit Sub
            If String.IsNullOrWhiteSpace(_mAddress2) Then Exit Sub
            If String.IsNullOrWhiteSpace(_mAddress3) Then Exit Sub

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------
            _nQuery = _
                "DELETE FROM " & _
                "[PDSAddress] " & _
                " "

            '----------------------------------
            If Not String.IsNullOrWhiteSpace(_mIDNo) Then

                _nWhere = "WHERE [IDNo] = @_mIDNo "
                If Not String.IsNullOrWhiteSpace(_mAddress1) Then _nWhere += "AND [Address1] = @_mAddress1 "
                If Not String.IsNullOrWhiteSpace(_mAddress2) Then _nWhere += "AND [Address2] = @_mAddress2 "
                If Not String.IsNullOrWhiteSpace(_mAddress3) Then _nWhere += "AND [Address3] = @_mAddress3 "

            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            'Prevent Bulk Deletion.
            If _nWhere = Nothing Then
                Exit Sub
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

                If Not String.IsNullOrWhiteSpace(_mAddress1) Then .AddWithValue("@_mAddress1", _mAddress1)
                If Not String.IsNullOrWhiteSpace(_mAddress2) Then .AddWithValue("@_mAddress2", _mAddress2)
                If Not String.IsNullOrWhiteSpace(_mAddress3) Then .AddWithValue("@_mAddress3", _mAddress3)

            End With

            _mSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetServerDate()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    

            ''  SELECT convert(nvarchar(8),getdate(),112) +  replace(convert(nvarchar(15),getdate(),114),':','') AS ServerDateTime
            _nQuery = _
                             "SELECT " & _
               " convert(nvarchar(8),getdate(),112) +  replace(convert(nvarchar(15),getdate(),114),':','') AS ServerDateTime " & _
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

            With _mSqlCommand.Parameters


                '.AddWithValue("@_mIDNo", IIf(String.IsNullOrWhiteSpace(_mIDNo), "", _mIDNo))
                '.AddWithValue("@_mIDNoRegistered", IIf(String.IsNullOrWhiteSpace(_mIDNoRegistered), "", _mIDNoRegistered))


            End With

            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    'deay 20150227
    Public Sub _pSubSelect()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                             "SELECT " & _
               "top 10 * " & _
               "FROM [rptmast]" & _
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

            With _mSqlCommand.Parameters


                '.AddWithValue("@_mIDNo", IIf(String.IsNullOrWhiteSpace(_mIDNo), "", _mIDNo))
                '.AddWithValue("@_mIDNoRegistered", IIf(String.IsNullOrWhiteSpace(_mIDNoRegistered), "", _mIDNoRegistered))


            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectAssessment()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _mTDN.Replace("'", "")
            If _mTDN.ToUpper.Contains("SELECT") = False Then
                _mTDN = "'" & _mTDN & "'"
            End If


            _nQuery = _
                            "with dt as ( " & _
                            "select  AssessNo,left(Orig_YrQtrToBill,4)Yr,right(Orig_YrQtrToBill,1)Qtr " & _
                            ",av Ass_value,sum(TAXDUE)BTAXDUE,sum(isnull(PENALTY,0)-isnull(DISCOUNT,0))BPENDIS,0 STAXDUE,0 SPENDIS,0 ITAXDUE,0 IPENDIS,sum(TAXDUE+(isnull(PENALTY,0)-isnull(DISCOUNT,0)))TOTAL,TDN  " & _
                            "from Assess_FrmNewBilling_dtls where assessno in (select top 1 AssessFromBilling.AssessNo " & _
                            "from  AssessFromBilling  " & _
                            "left join Assess_FrmNewBilling_A on AssessFromBilling.AssessNo = Assess_FrmNewBilling_A.AssessNo  " & _
                            "where isnull(Trans_Condition,'') = '' and isdate(AssessDate)=1  " & _
                            "and convert(nvarchar(10),convert(datetime,ValidDate),101)>= convert(nvarchar(10),getdate(),101) " & _
                            "  " & _
                            "and Assess_FrmNewBilling_A.tdn in (" & _mTDN & ") " & _
                            "order by convert(datetime,AssessDate) desc,AssessFromBilling.assessno desc) and TaxCode = 'BASIC' " & _
                            "group by  AssessNo,left(Orig_YrQtrToBill,4),right(Orig_YrQtrToBill,1) ,av,TDN " & _
                            "union all " & _
                            "select  AssessNo,left(Orig_YrQtrToBill,4),right(Orig_YrQtrToBill,1) " & _
                            ",av,0,0,sum(TAXDUE),sum(isnull(PENALTY,0)-isnull(DISCOUNT,0)),0,0,sum(TAXDUE+(isnull(PENALTY,0)-isnull(DISCOUNT,0))),TDN  " & _
                            "from Assess_FrmNewBilling_dtls where assessno in (select top 1 AssessFromBilling.AssessNo " & _
                            "from  AssessFromBilling  " & _
                            "left join Assess_FrmNewBilling_A on AssessFromBilling.AssessNo = Assess_FrmNewBilling_A.AssessNo  " & _
                            "where isnull(Trans_Condition,'') = '' and isdate(AssessDate)=1  " & _
                            "and convert(nvarchar(10),convert(datetime,ValidDate),101)>= convert(nvarchar(10),getdate(),101) " & _
                            "   " & _
                            "and Assess_FrmNewBilling_A.tdn in (" & _mTDN & ") " & _
                            "order by convert(datetime,AssessDate) desc,AssessFromBilling.assessno desc) and TaxCode = 'SEF'  " & _
                            "group by  AssessNo,left(Orig_YrQtrToBill,4),right(Orig_YrQtrToBill,1) ,av,TDN " & _
                            "union all " & _
                            "select  AssessNo,left(Orig_YrQtrToBill,4),right(Orig_YrQtrToBill,1) " & _
                            ",av,0,0,0,0,sum(TAXDUE),sum(isnull(PENALTY,0)-isnull(DISCOUNT,0)),sum(TAXDUE+(isnull(PENALTY,0)-isnull(DISCOUNT,0))),TDN  " & _
                            "from Assess_FrmNewBilling_dtls where assessno in (select top 1 AssessFromBilling.AssessNo " & _
                            "from  AssessFromBilling  " & _
                            "left join Assess_FrmNewBilling_A on AssessFromBilling.AssessNo = Assess_FrmNewBilling_A.AssessNo  " & _
                            "where isnull(Trans_Condition,'') = '' and isdate(AssessDate)=1  " & _
                            "and convert(nvarchar(10),convert(datetime,ValidDate),101)>= convert(nvarchar(10),getdate(),101) " & _
                            "   " & _
                            "and Assess_FrmNewBilling_A.tdn in (" & _mTDN & ") " & _
                            "order by convert(datetime,AssessDate) desc,AssessFromBilling.assessno desc) and TaxCode = 'IDLE'  " & _
                            "group by  AssessNo,left(Orig_YrQtrToBill,4),right(Orig_YrQtrToBill,1) ,av,TDN" & _
                            ") " &
                            " select a.AssessNo,a.Yr,												 " &
                            " CASE  WHEN a.Yr < year(getdate()) THEN 								 " &
                            " (select top 1 qtr from dt where a.yr < yr order by qtr asc ) + '-' +   " &
                            " (select top 1 qtr from dt where a.yr < yr order by qtr desc) 			 " &
                            " WHEN a.Yr = year(getdate()) THEN 										 " &
                            " (select top 1 qtr from dt where a.yr = yr order by qtr asc ) + '-' +   " &
                            " (select top 1 qtr from dt where a.yr = yr order by qtr desc) 			 " &
                            " WHEN a.Yr > year(getdate()) THEN 										 " &
                            " (select top 1 qtr from dt where a.yr > yr order by qtr asc ) + '-' +   " &
                            " (select top 1 qtr from dt where a.yr > yr order by qtr desc) 			 " &
                            " END AS Qtr,a.Ass_value,sum(a.BTAXDUE)BTAXDUE,sum(a.BPENDIS)BPENDIS,	 " &
                            " sum(a.STAXDUE)STAXDUE,sum(a.SPENDIS)SPENDIS,sum(a.ITAXDUE)ITAXDUE,	 " &
                            " sum(a.IPENDIS)IPENDIS,sum(a.TOTAL)TOTAL,a.TDN from dt a				 " &
                            " group by a.AssessNo,a.Yr,a.Ass_value,a.TDN order by a.yr asc			 "

            '"select AssessNo,Yr," & _
                            '"   CASE" & _
                            '"       WHEN Yr = year(getdate()) THEN" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate()) order by qtr asc) + '-' +" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate()) order by qtr desc) 	 " & _
                            '"       WHEN Yr = year(getdate())+1 THEN" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate())+1 order by qtr asc) + '-' +" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate())+1 order by qtr desc) 	 " & _
                            '"   	WHEN Yr = year(getdate())+2 THEN" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate())+2  order by qtr asc) + '-' +" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate())+2  order by qtr desc) 	 " & _
                            '"   	WHEN Yr = year(getdate())+3 THEN" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate())+3 order by qtr asc) + '-' +" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate())+3 order by qtr desc) 	 " & _
                            ' "   	WHEN Yr = year(getdate())+4 THEN" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate())+4 order by qtr asc) + '-' +" & _
                            '"   		(select top 1 qtr from dt where yr=year(getdate())+4 order by qtr desc) 	 " & _
                            '"   END AS Qtr" & _
                            '",Ass_value,sum(BTAXDUE)BTAXDUE,sum(BPENDIS)BPENDIS,sum(STAXDUE)STAXDUE,sum(SPENDIS)SPENDIS,sum(ITAXDUE)ITAXDUE,sum(IPENDIS)IPENDIS,sum(TOTAL)TOTAL,TDN from dt  " & _
                            '"group by AssessNo,Yr,Ass_value,TDN " & _
                            '"order by yr asc"

            '  "select AssessNo,Yr,Qtr,Ass_value,sum(BTAXDUE)BTAXDUE,sum(BPENDIS)BPENDIS,sum(STAXDUE)STAXDUE,sum(SPENDIS)SPENDIS,sum(ITAXDUE)ITAXDUE,sum(IPENDIS)IPENDIS,sum(TOTAL)TOTAL,TDN from dt  " & _
            '                "group by AssessNo,Yr,Qtr,Ass_value,TDN " & _
            '                "order by yr desc,qtr desc "





            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            '20200730

            Dim gtotal As Double
            Dim assno As String




            gtotal = 0
            assno = ""
            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader
                With _nSqlDataReader

                    If _nSqlDataReader.HasRows Then
                        'insert short payment assessment
                        Do While _nSqlDataReader.Read
                            gtotal = gtotal + _nSqlDataReader.Item("TOTAL").ToString()
                            assno = _nSqlDataReader.Item(0).ToString()

                        Loop
                    End If
                End With
                _nSqlDataReader.Close()
            End Using
            _mAssessNo = assno
            _mGrandTotal = gtotal
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubSelectAssessmentNo()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                    "select distinct AssessNo from Assess_FrmNewBilling_A where tdn in ('" & _mTDN & "') order by AssessNo desc "





            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            '20200730


            Dim assno As String

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                assno = _mDataTable.Rows(0).Item("assessno")
            Else
                assno = ""
            End If


            _mAssessNo = assno

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pShortpayment()
        Dim _nQuery As String = Nothing
        Dim _nWhere As String = Nothing

        '----------------------------------    
        _nQuery = ""

        _nQuery = " EXEC [SP_CHECKSHORTAMT] @ASSESSNO = '" & _mAssessNo & "'   , @TDN = '" & _mTDN & "'   ,@RP_SERVERDB='" & _mLocServer & "',@RP_LOCALDB='" & _pLocDB & "'  "
        '_nQuery = " EXEC [SP_VALIDATETDN] @TDN = '" & _mTDN & "' ,@ORNO = '" & _mORNO & "' ,@EMAIL = '" & _mEmail & "',@RP_SERVERDB='" & _mLocServer & "',@RP_LOCALDB='" & _pLocDB & "' ,@STATUS = @STATUS output "



        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()


        '_mSqlCommand.Parameters.Add("@STATUS", SqlDbType.NVarChar, 50)
        '_mSqlCommand.Parameters("@STATUS").Direction = ParameterDirection.Output
        ''Execute and Read the content

        'Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
        '    _nSqlDr.Read()
        '    If _nSqlDr.HasRows Then
        '        'Getting Record using reader
        '        Do While _nSqlDr.Read
        '            _mTDN = _nSqlDr.Item(0).ToString
        '        Loop
        '    End If

        'End Using
        ''Get values of parameter output


        '_mStatus = _mSqlCommand.Parameters("@STATUS").Value

        '_mSqlCommand.Dispose()

    End Sub

    Public Sub _pSubSelectUIPW(ByVal ConDB As String)

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            'karlo 20180412
            '----------------------------------    
            _nQuery = _
                "SELECT " & _
                "DBUserID,DBUserKey " & _
                "FROM [GlobalConnectionsDefault] " & _
                "Where SetupGlobalConnectionsDatabases='" & ConDB & "' "
            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("DBUserID")) Then
                    _mdbUI = ""
                Else
                    _mdbUI = _mDataTable.Rows(0).Item("DBUserID")
                End If

                If IsDBNull(_mDataTable.Rows(0).Item("DBUserKey")) Then
                    _mdbPW = ""
                Else
                    _mdbPW = _mDataTable.Rows(0).Item("DBUserKey")
                End If

            Else
                _mdbUI = ""
                _mdbPW = ""
            End If


            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectUIPWWEB()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            'karlo 20180412
            '----------------------------------    
            _nQuery = _
                "SELECT " & _
                "DBUserID,DBUserKey " & _
                "FROM [GlobalConnectionsDefault] " & _
                "Where SetupGlobalConnectionsDatabases='RPTIMS' "
            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("DBUserID")) Then
                    _mdbUI = ""
                Else
                    _mdbUI = _mDataTable.Rows(0).Item("DBUserID")
                End If

                If IsDBNull(_mDataTable.Rows(0).Item("DBUserKey")) Then
                    _mdbPW = ""
                Else
                    _mdbPW = _mDataTable.Rows(0).Item("DBUserKey")
                End If

            Else
                _mdbUI = ""
                _mdbPW = ""
            End If


            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelectUIPWTOIMS()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            'karlo 20180412
            '----------------------------------    
            _nQuery = _
                "SELECT " & _
                "DBUserID,DBUserKey " & _
                "FROM [GlobalConnectionsDefault] " & _
                "Where SetupGlobalConnectionsDatabases='TOIMS' "
            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("DBUserID")) Then
                    _mdbUI = ""
                Else
                    _mdbUI = _mDataTable.Rows(0).Item("DBUserID")
                End If

                If IsDBNull(_mDataTable.Rows(0).Item("DBUserKey")) Then
                    _mdbPW = ""
                Else
                    _mdbPW = _mDataTable.Rows(0).Item("DBUserKey")
                End If

            Else
                _mdbUI = ""
                _mdbPW = ""
            End If


            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubREGION()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            'karlo 20180412
            '----------------------------------    
            _nQuery = _
                "SELECT " & _
                "region " & _
                "FROM [PROVINCE] " & _
                ""

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("REGION")) Then
                    _mRegion = ""
                Else
                    _mRegion = _mDataTable.Rows(0).Item("REGION")
                End If



            Else
                _mRegion = ""

            End If


            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetAssessno()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            'karlo 20180412
            '----------------------------------    
            _nQuery = _
             " select ','+ACCTNO from onlinepaymentrefno " & _
                " where PostStatus=1	and left(TXNREFNO,3)='RPT'and isnull(PostedDate,'1900/01/01') = '1900/01/01' " & _
                " for xml path ('') "

            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item(0)) Then
                    _mAssessNo = ""
                Else
                    _mAssessNo = _mDataTable.Rows(0).Item(0)
                End If



            Else
                _mAssessNo = ""

            End If


            _nSqlDataAdapter.Dispose()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubPrint()


        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            ''comment 20210119
            '_nQuery = _
            '  "SELECT " & _
            '          "*" & _
            '    " FROM [RPTASTEMP].[dbo]." & _mUseTableTmpBill & "_tmp_Billing_TOP_HORZTAL " & _
            '    " Order by origtdn,part "
            'forcheck

            '_nWhere = " where tdn in (select tdn from tmpR0001_" & _mEmail & "BrHlp) ORDER BY Origtdn, part,for_year, minlnkYrQtr,EffectDate ,Actual_use"
            '----------------------------------

            '            _nQuery = _
            '              " SELECT        SeqCtr, Cmbkey, Part, region, prov, city, district, Tdn, Pin, Kind, Actual_use, Classification, SubClass, Area, Ass_value, OrigTDN, OrigCmbkey, SUBPIN, Barangay, BCode, OwnerNo, OwnerName, OwnerAddress, AdminNo, " &
            '         " AdminName, AdminAddress, LastOR, LastORDate, paid_yrqtr, Lqp, LYP, TOT_AMT, EffectDate, InputSeq, LotNo, BlockNo, Location, For_year, TitleNo, PeriodCovered, PeriodCovered_new, MinQtr, MaxQtr," &
            '         " MinQtr_InWord, MaxQtr_InWord, Remarks, ClassDesc, ActualUseDesc, SubClassDesc, PrevOwner, PrevTdn, AreaVal, Trans_Cd, Cur_Area, CurPIN, CurAUSE, CurClass, CurSubClass, NOOFTDN, AssessmentNo, ProcessDate," &
            '        "  VALIDITYDATE, BAS_AnnualTax, SEF_AnnualTax, IDLE_AnnualTax, LEVY_AnnualTax, BAS_AmPen, SEF_AmPen, IDLE_AmPen, LEVY_AmPen, BAS_PenWaive, SEF_PenWaive, IDLE_PenWaive, LEVY_PenWaive," &
            '         " BAS_TaxDue_PrevTaxcredit, SEF_TaxDue_PrevTaxcredit, IDLE_TaxDue_PrevTaxcredit, LEVY_TaxDue_PrevTaxcredit, BAS_Pendue_PrevTaxcredit, SEF_Pendue_PrevTaxcredit, IDLE_Pendue_PrevTaxcredit," &
            '         " LEVY_Pendue_PrevTaxcredit, BAS_PrevTaxcredit, SEF_PrevTaxcredit, IDLE_PrevTaxcredit, LEVY_PrevTaxcredit, TotAmtPrevTaxcredit, BAS_TaxDue_PrevShortAmt, SEF_TaxDue_PrevShortAmt, IDLE_TaxDue_PrevShortAmt," &
            '        "  LEVY_TaxDue_PrevShortAmt, BAS_Pendue_PrevShortAmt, SEF_Pendue_PrevShortAmt, IDLE_Pendue_PrevShortAmt, LEVY_Pendue_PrevShortAmt, BAS_PrevShortAmt, SEF_PrevShortAmt, IDLE_PrevShortAmt," &
            '        "  LEVY_PrevShortAmt, TotalAmt_PrevShortAmt, BAS_TaxDue, BAS_Pendue, BAS_Disc, SEF_TaxDue, SEF_Pendue, SEF_Disc, IDLE_TaxDue, IDLE_Pendue, IDLE_Disc, LEVY_TaxDue, LEVY_Pendue, LEVY_Disc," &
            '        "  BAS_TOTALDUES, SEF_TOTALDUES, IDLE_TOTALDUES, LEVY_TOTALDUES, BAS_TOTALAMOUNT, SEF_TOTALAMOUNT, IDLE_TOTALAMOUNT, LEVY_TOTALAMOUNT, Total_TaxDue, Total_PenDue, Total_Disc," &
            '         " Total_TOTALDUES, TOTALAMOUNT, BAS_TaxDue_NewTaxcredit, SEF_TaxDue_NewTaxcredit, IDLE_TaxDue_NewTaxcredit, LEVY_TaxDue_NewTaxcredit, BAS_Pendue_NewTaxcredit, SEF_Pendue_NewTaxcredit," &
            '        "  IDLE_Pendue_NewTaxcredit, LEVY_Pendue_NewTaxcredit, BAS_NewTaxcredit, SEF_NewTaxcredit, IDLE_NewTaxcredit, LEVY_NewTaxcredit, TotalAmt_NewTaxcredit, BAS_Pendue_NewShortAmt, SEF_Pendue_NewShortAmt," &
            '        "  IDLE_Pendue_NewShortAmt, LEVY_Pendue_NewShortAmt, BAS_TaxDue_NewShortAmt, SEF_TaxDue_NewShortAmt, IDLE_TaxDue_NewShortAmt, LEVY_TaxDue_NewShortAmt, BAS_NewShortAmt, SEF_NewShortAmt," &
            '         " IDLE_NewShortAmt, LEVY_NewShortAmt, TotalAmt_NewShortAmt, codetype, LastPeriod, PercentDisc, Percent_Disc, Special_DiscVal, CASHONHAND, ComproNo, ISCOMPRO, ISCOH, EXTNDATE, CA_penalty, GarbageAmt," &
            '         " totalamount_other, BAS_TAXDUE_WOPENDISC, BAS_PENDISC, SEF_TAXDUE_WOPENDISC, SEF_PENDISC, IDLE_TAXDUE_WOPENDISC, IDLE_PENDISC, LEVY_TAXDUE_WOPENDISC, LEVY_PENDISC, Total_TOTALDUES_A," &
            '        "  MinYrQtr, MaxYrQtr, minlnkYrQtr, maxlnkYrQtr, PERIODCOVERED_A, NoOfOwnerName " &
            '          "			 , (   select TOP 1 min(SUBSTRING(convert(nvarchar(100),minlnkYrQtr),LEN(minlnkYrQtr),1)) + '-' + " &
            '" min(SUBSTRING(convert(nvarchar(200),minlnkYrQtr),0,LEN(minlnkYrQtr)))    + ' to ' + " &
            '"  max(SUBSTRING(convert(nvarchar(100),maxlnkYrQtr),LEN(maxlnkYrQtr),1)) + '-' +  " &
            '     "     max(SUBSTRING(Convert(nvarchar(200), maxlnkYrQtr), 0, Len(maxlnkYrQtr)))  " &
            '"	FROM [RPTASTEMP].[dbo]." & _mUseTableTmpBill & "_tmp_Billing_TOP_HORZTAL  B    " &
            '  " Where  B.OrigTDN = A.OrigTDN   )  LastPeriodCovered  " &
            '"   FROM [RPTASTEMP].[dbo]." & _mUseTableTmpBill & "_tmp_Billing_TOP_HORZTAL  a  Order by origtdn,part   "


            _nQuery = _
              " SELECT        SeqCtr, Cmbkey, Part, region, prov, city, district, Tdn, Pin, Kind, Actual_use, Classification, SubClass, Area, Ass_value, OrigTDN, OrigCmbkey, SUBPIN, Barangay, BCode, OwnerNo, OwnerName, OwnerAddress, AdminNo, " &
         " AdminName, AdminAddress, LastOR, LastORDate, paid_yrqtr, Lqp, LYP, TOT_AMT, EffectDate, InputSeq, LotNo, BlockNo, Location, For_year, TitleNo, PeriodCovered, PeriodCovered_new, MinQtr, MaxQtr," &
         " MinQtr_InWord, MaxQtr_InWord, Remarks, ClassDesc, ActualUseDesc, SubClassDesc, PrevOwner, PrevTdn, AreaVal, Trans_Cd, Cur_Area, CurPIN, CurAUSE, CurClass, CurSubClass, NOOFTDN, AssessmentNo, ProcessDate," &
        "  VALIDITYDATE, BAS_AnnualTax, SEF_AnnualTax, IDLE_AnnualTax, LEVY_AnnualTax, BAS_AmPen, SEF_AmPen, IDLE_AmPen, LEVY_AmPen, BAS_PenWaive, SEF_PenWaive, IDLE_PenWaive, LEVY_PenWaive," &
         " BAS_TaxDue_PrevTaxcredit, SEF_TaxDue_PrevTaxcredit, IDLE_TaxDue_PrevTaxcredit, LEVY_TaxDue_PrevTaxcredit, BAS_Pendue_PrevTaxcredit, SEF_Pendue_PrevTaxcredit, IDLE_Pendue_PrevTaxcredit," &
         " LEVY_Pendue_PrevTaxcredit, BAS_PrevTaxcredit, SEF_PrevTaxcredit, IDLE_PrevTaxcredit, LEVY_PrevTaxcredit, TotAmtPrevTaxcredit, BAS_TaxDue_PrevShortAmt, SEF_TaxDue_PrevShortAmt, IDLE_TaxDue_PrevShortAmt," &
        "  LEVY_TaxDue_PrevShortAmt, BAS_Pendue_PrevShortAmt, SEF_Pendue_PrevShortAmt, IDLE_Pendue_PrevShortAmt, LEVY_Pendue_PrevShortAmt, BAS_PrevShortAmt, SEF_PrevShortAmt, IDLE_PrevShortAmt," &
        "  LEVY_PrevShortAmt, TotalAmt_PrevShortAmt, BAS_TaxDue, BAS_Pendue, BAS_Disc, SEF_TaxDue, SEF_Pendue, SEF_Disc, IDLE_TaxDue, IDLE_Pendue, IDLE_Disc, LEVY_TaxDue, LEVY_Pendue, LEVY_Disc," &
        "  BAS_TOTALDUES, SEF_TOTALDUES, IDLE_TOTALDUES, LEVY_TOTALDUES, BAS_TOTALAMOUNT, SEF_TOTALAMOUNT, IDLE_TOTALAMOUNT, LEVY_TOTALAMOUNT, Total_TaxDue, Total_PenDue, Total_Disc," &
         " Total_TOTALDUES, TOTALAMOUNT, BAS_TaxDue_NewTaxcredit, SEF_TaxDue_NewTaxcredit, IDLE_TaxDue_NewTaxcredit, LEVY_TaxDue_NewTaxcredit, BAS_Pendue_NewTaxcredit, SEF_Pendue_NewTaxcredit," &
        "  IDLE_Pendue_NewTaxcredit, LEVY_Pendue_NewTaxcredit, BAS_NewTaxcredit, SEF_NewTaxcredit, IDLE_NewTaxcredit, LEVY_NewTaxcredit, TotalAmt_NewTaxcredit, BAS_Pendue_NewShortAmt, SEF_Pendue_NewShortAmt," &
        "  IDLE_Pendue_NewShortAmt, LEVY_Pendue_NewShortAmt, BAS_TaxDue_NewShortAmt, SEF_TaxDue_NewShortAmt, IDLE_TaxDue_NewShortAmt, LEVY_TaxDue_NewShortAmt, BAS_NewShortAmt, SEF_NewShortAmt," &
         " IDLE_NewShortAmt, LEVY_NewShortAmt, TotalAmt_NewShortAmt, codetype, LastPeriod, PercentDisc, Percent_Disc, Special_DiscVal, CASHONHAND, ComproNo, ISCOMPRO, ISCOH, EXTNDATE, CA_penalty, GarbageAmt," &
         " totalamount_other, BAS_TAXDUE_WOPENDISC, BAS_PENDISC, SEF_TAXDUE_WOPENDISC, SEF_PENDISC, IDLE_TAXDUE_WOPENDISC, IDLE_PENDISC, LEVY_TAXDUE_WOPENDISC, LEVY_PENDISC, Total_TOTALDUES_A," &
        "  MinYrQtr, MaxYrQtr, minlnkYrQtr, maxlnkYrQtr, PERIODCOVERED_A, NoOfOwnerName " &
          "			 , (select TOP 1 Case when right(isnull(paid_yrqtr,''),1) = 4 then '1-' +  substring(paid_yrqtr,0,len(paid_yrqtr)) +  ' to ' + '4-' +  substring(paid_yrqtr,0,len(paid_yrqtr))" &
 " when right(isnull(paid_yrqtr,''),1) = 3 then '1-' +  substring(paid_yrqtr,0,len(paid_yrqtr)) +  ' to ' + '3-' +  substring(paid_yrqtr,0,len(paid_yrqtr)) " &
"  when right(isnull(paid_yrqtr,''),1) = 2 then '1-' +  substring(paid_yrqtr,0,len(paid_yrqtr)) +  ' to ' + '2-' +  substring(paid_yrqtr,0,len(paid_yrqtr)) " &
 "  when right(isnull(paid_yrqtr,''),1) = 1 then '1-' +  substring(paid_yrqtr,0,len(paid_yrqtr)) +  ' to ' + '0-' +  substring(paid_yrqtr,0,len(paid_yrqtr)) " &
" else " &
 " (   select TOP 1 min(SUBSTRING(convert(nvarchar(100),minlnkYrQtr),LEN(minlnkYrQtr),1)) + '-' +  min(SUBSTRING(convert(nvarchar(200),minlnkYrQtr),0,LEN(minlnkYrQtr)))  " &
  "  + ' to ' + " &
 "           max(SUBSTRING(Convert(nvarchar(100), maxlnkYrQtr), Len(maxlnkYrQtr), 1))" &
"	   + '-' +  " &
  "          max(SUBSTRING(Convert(nvarchar(200), maxlnkYrQtr), 0, Len(maxlnkYrQtr)))" &
"				FROM [RPTASTEMP].[dbo]." & _mUseTableTmpBill & "_tmp_Billing_TOP_HORZTAL  B     Where  B.OrigTDN = A.OrigTDN   ) end ) LastPeriodCovered " &
"   FROM [RPTASTEMP].[dbo]." & _mUseTableTmpBill & "_tmp_Billing_TOP_HORZTAL  a  Order by origtdn,part   "


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

    Public Sub _pSubDataSearch()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                             "SELECT " & _
                                  "SEQCOUNTER,OTHER_REMARKS,TDN," & _
                                  "FUNDTYPE,PIN,TRANS_CD,LASTCOVEREDPAID ," & _
                                  "LASTAMOUNTPAID,LASTOR,LASTSRS,LASTORDATE,TOTALAMOUNT " & _
                            "FROM [RPTASTEMP].[dbo].[" & _mUseTableTmpBill & "_LstRecord]" & _
                            " "
            '----------------------------------    


            If _mTDN <> "" Then
                _nWhere = "WHERE [TDN] = @_mTDN "
            End If
            '_nWhere += "OR [IDNoRegistered] = @_mIDNoRegistered "
            'If Not String.IsNullOrWhiteSpace(_mTDN) Then _nWhere += "where [TDN] = @_mTDN "




            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)



            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubDataSearchIsPostBack()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                    "SELECT " & _
                    "SEQCOUNTER,OTHER_REMARKS,TDN," & _
                    "FUNDTYPE,PIN,TRANS_CD,LASTCOVEREDPAID ," & _
                    "LASTAMOUNTPAID,LASTOR,LASTSRS,LASTORDATE,TOTALAMOUNT " & _
                    "FROM [RPTASTEMP].[dbo].[TOP_WEB_Billing" & _mEmail & "]" & _
                    " "
            '----------------------------------    


            If _mTDN <> "" Then
                _nWhere = "WHERE [TDN] = @_mTDN "
            End If
            '_nWhere += "OR [IDNoRegistered] = @_mIDNoRegistered "
            'If Not String.IsNullOrWhiteSpace(_mTDN) Then _nWhere += "where [TDN] = @_mTDN "




            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)



            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub




    Public Sub _pSubfilter()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '   If _mTDN = "" Then Exit Sub
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                    "SELECT  " & _
                    "R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
                    "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
                    "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE  " & _
                    "FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO  " & _
                    "WHERE (R.REGION+R.PROV+R.CITY in (select REGION+PROV+CODE from city)) " & _
                    " and R.TDN in (select TDN from tdnperemail where EMAILADDRESS='" & _mEmail & "') " & _
                    "union " & _
                    "SELECT  R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
                    "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
                    "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE  " & _
                    "FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO  " & _
                    "where R.region+R.PROV+R.CITY+R.tdn in  " & _
                    "(select region+PROV+CITY+reference_tdn " & _
                    "from PROPERTY_OTHERLAND_REF where region+PROV+CITY+tdn  in  " & _
                    "(SELECT  R.region+R.PROV+R.CITY+R.TDN   FROM  RPTMAST R  " & _
                    "WHERE (R.REGION+R.PROV+R.CITY in (select REGION+PROV+CODE from city)) )) " & _
                    " and R.TDN in (select TDN from tdnperemail where EMAILADDRESS='" & _mEmail & "') " & _
                    " order by R.PIN " & _
                    ""





            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)



            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubBrHlp()

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
                    "SELECT  " & _
                    "* from tmpR0001_" & _mEmail & "BrHlp" & _
                    ""

            '               ' "SELECT " & _
            '      "R.TDN,  R.OWNER_NO, O.Name, R.PIN, R.CAD_LOT_NO, R.LOTE_NO, " & _
            '      "R.BLOCK_NO,R.CER_TIT_NO, R.ARP , R.CITY, R.DIST_NO, " & _
            '      "R.LOCATION,R.LOTE_NO+','+ R.BLOCK_NO as LOTBLOCK, O.Address, R.BCODE " & _
            '"FROM  RPTMAST R LEFT OUTER JOIN rptowner O ON R.OWNER_No = O.OWNER_NO " & _
            '" "
            '----------------------------------    
            ' WHERE (R.REGION = 'VI') and (R.PROV = '042')  and (R.city = '184')  and (R.PIN LIKE '%184-03%')  

            '_nWhere = " "
            '_nWhere += "OR [IDNoRegistered] = @_mIDNoRegistered "
            'If Not String.IsNullOrWhiteSpace(_mBusinessAccountNumber) Then
            '    _nWhere += "AND [BusinessAccountNumber] = @BusinessAccountNumber "
            'End If


            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'With _mSqlCommand.Parameters

            '    If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)



            'End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubDeleteBrHlp()
        Try
            '----------------------------------

            If _pMode = False Then
                If String.IsNullOrWhiteSpace(_mRegion) Then Exit Sub
                If String.IsNullOrWhiteSpace(_mProv) Then Exit Sub
                If String.IsNullOrWhiteSpace(_mCity) Then Exit Sub
                If String.IsNullOrWhiteSpace(_mDistrict) Then Exit Sub
                If String.IsNullOrWhiteSpace(_mTDN) Then Exit Sub
            End If
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------
            _nQuery = _
                "DELETE FROM " & _
                "[tmpR0001_" & _mEmail & "BrHlp] " & _
                " "

            '----------------------------------
            If _pMode = False Then
                If Not String.IsNullOrWhiteSpace(_mRegion) Then
                    _nWhere = "WHERE  [TDN] = @_mTDN  "
                    '_nWhere = "WHERE [Region] = @_mRegion "
                    'If Not String.IsNullOrWhiteSpace(_mProv) Then _nWhere += "AND [Prov] = @_mProv "
                    'If Not String.IsNullOrWhiteSpace(_mCity) Then _nWhere += "AND [City] = @_mCity "
                    'If Not String.IsNullOrWhiteSpace(_mDistrict) Then _nWhere += "AND [District] = @_mDistrict "
                    'If Not String.IsNullOrWhiteSpace(_mTDN) Then _nWhere += "AND [TDN] = @_mTDN "
                Else
                    _nWhere = Nothing
                End If
            End If
            '----------------------------------
            'Prevent Bulk Deletion.
            If _pMode = False Then
                If _nWhere = Nothing Then
                    Exit Sub
                End If
            End If
            '----------------------------------
            _mQuery = _nQuery & _nWhere

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            If _pMode = False Then
                With _mSqlCommand.Parameters

                    If Not String.IsNullOrWhiteSpace(_mRegion) Then .AddWithValue("@_mRegion", _mRegion)

                    If Not String.IsNullOrWhiteSpace(_mProv) Then .AddWithValue("@_mProv", _mProv)
                    If Not String.IsNullOrWhiteSpace(_mCity) Then .AddWithValue("@_mCity", _mCity)
                    If Not String.IsNullOrWhiteSpace(_mDistrict) Then .AddWithValue("@_mDistrict", _mDistrict)
                    If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)
                End With
            End If
            _mSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubInsertBrHlp()
        Try
            '----------------------------------
            'karlo 20180412
            Dim _nQuery As String = Nothing

            '----------------------------------
            _nQuery = _
             "INSERT INTO " & _
             "rptastemp.dbo.[tmpR0001_" & _mEmail & "BrHlp] " & _
             "(" & _
                "REGION,PROV,CITY,DISTRICT,TDN,DateValue " & _
             ") " & _
             " select distinct REGION,PROV,CITY,DIST_NO,TDN,'" & Format(Now, "MM/dd/yyyy") & "' from rptmast where tdn in ( " & IIf(_mTDN.Contains("select") = False, "'" & _mTDN & "'", _mTDN) & ") " & _
             " "

            '  NCR	000	113	26	26-177-16053-R	177

            '      _nQuery = _
            '"INSERT INTO " & _
            '"[tmpR0001_" & _mEmail & "BrHlp] " & _
            '"(" & _
            '   "REGION,PROV,CITY,DISTRICT,TDN,DateValue " & _
            '") " & _
            '"VALUES " & _
            '"(" & _
            '   "'" & _mRegion & "', " & _
            '   "'" & _mProv & "', " & _
            '   "'" & _mCity & "', " & _
            '   "'" & _mDistrict & "', " & _
            '   "'" & _mTDN & "', " & _
            '   "'" & _mDateValue & "' " & _
            '") "




            '    _mRegion_mProv_mCity_mDistrict
            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                'If Not String.IsNullOrWhiteSpace(_mRegion) Then .AddWithValue("@_mRegion", _mRegion)

                'If Not String.IsNullOrWhiteSpace(_mProv) Then .AddWithValue("@_mProv", _mProv)
                'If Not String.IsNullOrWhiteSpace(_mCity) Then .AddWithValue("@_mCity", _mCity)
                'If Not String.IsNullOrWhiteSpace(_mDistrict) Then .AddWithValue("@_mDistrict", _mDistrict)

                'If Not String.IsNullOrWhiteSpace(_mTDN) Then .AddWithValue("@_mTDN", _mTDN)
                'If Not String.IsNullOrWhiteSpace(_mDateValue) Then .AddWithValue("@_mDateValue", _mDateValue)


            End With

            _mSqlCommand.ExecuteNonQuery()



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubInsertimage()
        Try
            '----------------------------------
            'karlo 20180412
            Dim _nQuery As String = Nothing

            '----------------------------------
            _nQuery = _
             "INSERT INTO " & _
             "[imagetable] " & _
             "(" & _
                " imgfile2 " & _
             ") " & _
             "VALUES " & _
             "(" & _
                "@_mFileData " & _
             ") "


            '    _mRegion_mProv_mCity_mDistrict
            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            With _mSqlCommand.Parameters

                .AddWithValue("@_mFileData", _mImgfile)

            End With

            _mSqlCommand.ExecuteNonQuery()



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubregionprovcitydistrict()
        Try
            '----------------------------------
            'karlo 20180412
            Dim _nQuery2 As String = Nothing
            _nQuery2 = _
          "SELECT TOP 1 " & _
          " REGION,PROV,CITY,DIST_NO  " & _
          "FROM [RPTMAST] WHERE tdn = '" & _mTDN & "'" & _
           " "

            Dim _nSqlCommand As New SqlCommand(_nQuery2, _mSqlCon)
            '---------------------------------- 
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("REGION")) Then
                    _mRegion = ""
                Else
                    _mRegion = _mDataTable.Rows(0).Item("REGION")
                End If

                If IsDBNull(_mDataTable.Rows(0).Item("PROV")) Then
                    _mProv = ""
                Else
                    _mProv = _mDataTable.Rows(0).Item("PROV")
                End If

                If IsDBNull(_mDataTable.Rows(0).Item("DIST_NO")) Then
                    _mDistrict = ""
                Else
                    _mDistrict = _mDataTable.Rows(0).Item("DIST_NO")
                End If

                If IsDBNull(_mDataTable.Rows(0).Item("CITY")) Then
                    _mCity = ""
                Else
                    _mCity = _mDataTable.Rows(0).Item("CITY")
                End If
            Else
                _mRegion = ""
                _mProv = ""
                _mDistrict = ""
                _mCity = ""
            End If


            _nSqlDataAdapter.Dispose()
            '----------------------------------

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubCreateTableBrHlp()
        Try

            '----------------------------------
            Dim _nQuery As String = Nothing

            '----------------------------------
            _nQuery = _
                    "IF exists(select name from sys.tables where name = 'tmpR0001_" & _mEmail & "BrHlp') DROP TABLE tmpR0001_" & _mEmail & "BrHlp CREATE TABLE [dbo].[tmpR0001_" & _mEmail & "BrHlp]([Region] [nvarchar](15) NULL,[Prov] [nvarchar](15) NULL," & _
                    " [City] [nvarchar](15) NULL,[District] [nvarchar](15) NULL,[TDN] [nvarchar](50) NULL,[DateValue] [nvarchar](30) NULL) " & _
                    " ON [PRIMARY]"
            '    _mRegion_mProv_mCity_mDistrict
            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mEmail) Then .AddWithValue("@_mEmail", _mEmail)
            End With

            _mSqlCommand.ExecuteNonQuery()



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubGetYear()
        Try

            '----------------------------------
            Dim _nQuery As String = Nothing
            '----------------------------------
            _nQuery = _
                    "with dt as (select year(GETDATE()) as Yr union all select yr+1 from dt where yr < year(GETDATE())+1) select yr,datepart(q,getdate())QTR,year(getdate())CURYR from dt"
            '    _mRegion_mProv_mCity_mDistrict
            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)




            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                '_nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    _nSqlDr.Read()
                    '_mTDN = _nSqlDr.Item(1).ToString
                    _mQtr = _nSqlDr.Item("QTR").ToString
                    _mYr = _nSqlDr.Item("CURYR").ToString


                End If

            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Function _pSubGetDateTime() As Date
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "SELECT FORMAT (getdate(), 'MM/dd/yyyy')  as D"
            '  _nQuery = "SELECT CAST(FORMAT (getdate(), 'MM/dd/yyyy') AS smalldatetime) as D"

            '  _nQuery = "select format(cast(getdate() as smalldatetime),'MM/dd/yyyy')  as D"
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                If _nSqlDr.HasRows Then
                    _nSqlDr.Read()
                    Return _nSqlDr.Item("D")
                End If
            End Using
        Catch ex As Exception

        End Try
    End Function


    Public Sub _pSubSelectTrapIfExist()
        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------    
            _nQuery = _
               "SELECT " & _
               "* " & _
               "FROM [PDSAddress] WHERE [IDNo] = @_mIDNo " & _
                " "

            '----------------------------------    
            If Not String.IsNullOrWhiteSpace(_mIDNo) Then

                _nWhere = "WHERE [IDNo] = @_mIDNo "

            Else
                _nWhere = Nothing
            End If

            '----------------------------------
            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters

                If Not String.IsNullOrWhiteSpace(_mIDNo) Then .AddWithValue("@_mIDNo", _mIDNo)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    'deay 20150227
    Public Sub _pSubGetSpecificRecordAddress()
        Try
            '----------------------------------
            _pSubSelect()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _iIDNo As Integer = .GetOrdinal("IDNo")
                    Dim _iaddress1 As Integer = .GetOrdinal("address1")

                    Dim _iaddress2 As Integer = .GetOrdinal("address2")
                    Dim _iaddress3 As Integer = .GetOrdinal("address3")
                    Dim _iZipCode As Integer = .GetOrdinal("ZipCode")
                    Dim _iTelNo As Integer = .GetOrdinal("TelNo")


                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mIDNo = ._pReturnString(_nSqlDataReader(_iIDNo))
                                _mAddress1 = ._pReturnString(_nSqlDataReader(_iaddress1))

                                _mAddress2 = ._pReturnString(_nSqlDataReader(_iaddress2))
                                _mAddress3 = ._pReturnString(_nSqlDataReader(_iaddress3))
                                _mZipCode = ._pReturnString(_nSqlDataReader(_iZipCode))
                                _mTelNo = ._pReturnString(_nSqlDataReader(_iTelNo))


                            Loop
                        Else
                            _mIDNo = ""
                            _mAddress1 = ""

                            _mAddress2 = ""
                            _mAddress3 = ""
                            _mZipCode = ""
                            _mTelNo = ""

                        End If

                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pGetinfo()
        Dim _nQuery As String = Nothing
        Dim _nWhere As String = Nothing

        '----------------------------------    

        _nQuery = "select * from rptdetail where tdn in ('" & _mTDN & "')"



        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)



        'Execute and Read the content

        Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            '_nSqlDr.Read()
            If _nSqlDr.HasRows Then
                'Getting Record using reader
                Do While _nSqlDr.Read
                    '_mTDN = _nSqlDr.Item(1).ToString
                    _mPIN = _nSqlDr.Item("PIN").ToString
                    _mKIND = _nSqlDr.Item("KIND").ToString
                    _mOWNER = _nSqlDr.Item("OWNERNAME").ToString
                    _mLOCATION = _nSqlDr.Item("LOCATION").ToString
                Loop
            End If

        End Using
        'Get values of parameter output



        _mSqlCommand.Dispose()

    End Sub
    Public Sub _pSubDatagetServerDate()
        Try
            _pSubGetServerDate()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubGetSpecificRecord_getid()
        Try
            '----------------------------------
            _pSubGetServerDate()

            Using _nSqlDataReader As SqlDataReader = _pSqlDataReader

                '----------------------------------
                'Indexes
                With _nSqlDataReader
                    Dim _ServerDateTime As Integer = .GetOrdinal("ServerDateTime")

                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then
                            Do While _nSqlDataReader.Read

                                _mctr_no = _nSqlDataReader(_ServerDateTime).ToString


                            Loop
                        Else
                            _mctr_no = 1
                        End If



                    End With
                End With

                _nSqlDataReader.Close()
            End Using

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectRPTOR()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------                
            _nQuery = "select TransDate,ACCTNO ControlNo,'AF56'FORM,'RPT PAYMENT'TransactionType,StatusID [STATUS],rawamount TaxAmount " & _
                    ",(select FirstName + ' ' + LastName  from [dbo].Registered where UserID =  [dbo].OnlinePaymentRefno.EMAILADDR )Name, " & _
                    "ortemp+' | '+orSRS+' | '+bk Or_numberSRSBookno,ortemp OR_NUMBER from rptastemp..tmpR0001" & _mEmail & "_" & _mctr_no & "_tmprcptX  " & _
                    "inner join dbo.OnlinePaymentRefno on assessno = ACCTNO "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon) '_gDBCon
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
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            'Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            '_mDataTable = New DataTable
            '_nSqlDataAdapter.Fill(_mDataTable)
            ''----------------------------------

            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    '  Do While _nSqlDr.Read
                    _mEmail = _nSqlDr.Item("loginname").ToString
                    ' Loop
                Else
                    _mEmail = ""
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubAcquireData()
        Dim _nQuery As String = Nothing
        Dim _nQuery2 As String = Nothing
        _nQuery = ""
        _nQuery2 = ""
        _nQuery = "insert into [" & _mLocServer & "].[" & _mLocDB & "].dbo.ledger ( " & _
"REGION, PROV, CITY, DISTRICT, TDN, Tax_code, Kind, Classification, Actual_use, SubClass, Ass_value, Annual_tax, Tax_due, Pen_due, Pen_Waived, Discount, Tax_credit, Short_Amt, Amount_paid, Lqp, For_year, " & _
"Bas_or, Sef_or, Date_paid, Payer, Time_Posted, Protest, Bank, Check_no, MOrder_no, Check_date, MOrder_date, CheckAmount, MOrder_Amt, User_ID, Date_Posted, CType, TotalAmount, Current_Tax_credit, CC, SHORT_P,  " & _
"Is_Appraised, PayMode, PenDue_Pd, TaxDue_Pd, S_TaxDue, S_PenDue, S_Total, RefFormUse, RefSRS, RefORNO, FormUse, SRS, ORNO, Fr_Lqp, ChkPayee, Remarks, DateIss, B_Code, IsMigrated, LGULevel, Encoder,  " & _
"Prev_TaxCredit, Prev_ShortAmt, CAO, Cur_TDN, isOutsideRem, isLocked, CmprsNO, SchedSeq, Initial_PenDue, Initial_Discount, isPaymentEdited, BillingType, User_Edit, isPART, Initial_TaxDue, BookNo, CostSale, OBAmnt,  " & _
"RCost, Tax_TAXCREDIT, Pen_TAXCREDIT, rem, NoDisc_PenDue, NoDisc_TaxDue, ChckType, SUB_TDN, UserAssess, PercentDisc, ENTRY_FEE, PPrice, RPrice, CA_Penalty, isComproCancelled, taxornumber, taxdecid, tdn_1,  " & _
"classification_1, assessedvalue, taxassessedvalue, taxscope, taxPeriod, dominantuse, ownername, userlogname, BasicTax, SEFTax, BasicPenalty, SEFPenalty, yearfr, yearto, frLqp, toLqp, taxscopeA, idx, tdn001, cmbkey,  " & _
"datepaid, ispayhistory, rem_frompayhist, Basicdiscount, SEFdiscount, BasicPenalty_A, SEFPenalty_A, identNo, ActualUse_GetOne, ActualUse_GetOneF, frmLqp_f, ToLqp_f, yearfr_f, yearto_f, frmtable001, StartYear, StartQtr,  " & _
"EndYear, EndQtr, AssessedValue_A, BasicTax_A, BasicDiscount_A, SEFTax_A, SEFDiscount_A, FireServiceFee, TotalTax, PayAmount, PayDate, TenderedAmount, RefYear, RefQtr, PayMode_1, PayType_1, NonCashNumber,  " & _
"Bank_1, NonCashDate, CheckType, CollectorCode, AssessorsName, Payee, Status, KindOfProperty, PayCode, PartialPaid, PartialBalance, PartialTotal, AddPaid, AddBalance, AddTotal, WithAdjustment, UnderCA, CAPenalty_1,  " & _
"DiscountOnPenalty, Getthis, GetValue, new_Partial, new_AddPaid, ComputeAmt, CodeType, New_Remarks, PrefixTag, AssessNo, Orig_TaxDue, Orig_PenDue, Orig_Discount, GARBAGE_FEE, IsPrtArea, IsFrmBackEnd,  " & _
"garbageamt, OverageAmt, DteOfTrans, xACCTNO, xADDRESS, xdateedited, xFIRE_BASIC, xFIRE_SEF, xLOCATION, xMACH, xMACHINE, xmachineedited, xmachineniya, xMODE, xmode_am, xPARTIAL, xPARTIAL_TOT, xPDATE,  " & _
"xPORNUM, xtimeedited, xTOT_AMT, xdateencoded, xtimeencoded, xINPUT, xCHECK, xuniquekey) "


        _nQuery2 = "SELECT      REGION, PROV, CITY, DISTRICT, TDN, Tax_code, Kind, Classification, Actual_use, SubClass, Ass_value, Annual_tax, Tax_due, Pen_due, Pen_Waived, Discount, Tax_credit, Short_Amt, Amount_paid, Lqp, For_year,  " & _
"Bas_or, Sef_or, Date_paid, Payer, Time_Posted, Protest, Bank, Check_no, MOrder_no, Check_date, MOrder_date, CheckAmount, MOrder_Amt, User_ID, Date_Posted, CType, TotalAmount, Current_Tax_credit, CC, SHORT_P,  " & _
"Is_Appraised, PayMode, PenDue_Pd, TaxDue_Pd, S_TaxDue, S_PenDue, S_Total, RefFormUse, RefSRS, RefORNO, FormUse, SRS, ORNO, Fr_Lqp, ChkPayee, Remarks, DateIss, B_Code, IsMigrated, LGULevel, Encoder,  " & _
"Prev_TaxCredit, Prev_ShortAmt, CAO, Cur_TDN, isOutsideRem, isLocked, CmprsNO, SchedSeq, Initial_PenDue, Initial_Discount, isPaymentEdited, BillingType, User_Edit, isPART, Initial_TaxDue, BookNo, CostSale, OBAmnt,  " & _
"RCost, Tax_TAXCREDIT, Pen_TAXCREDIT, rem, NoDisc_PenDue, NoDisc_TaxDue, ChckType, SUB_TDN, UserAssess, PercentDisc, ENTRY_FEE, PPrice, RPrice, CA_Penalty, isComproCancelled, taxornumber, taxdecid, tdn_1,  " & _
"classification_1, assessedvalue, taxassessedvalue, taxscope, taxPeriod, dominantuse, ownername, userlogname, BasicTax, SEFTax, BasicPenalty, SEFPenalty, yearfr, yearto, frLqp, toLqp, taxscopeA, idx, tdn001, cmbkey,  " & _
"datepaid, ispayhistory, rem_frompayhist, Basicdiscount, SEFdiscount, BasicPenalty_A, SEFPenalty_A, identNo, ActualUse_GetOne, ActualUse_GetOneF, frmLqp_f, ToLqp_f, yearfr_f, yearto_f, frmtable001, StartYear, StartQtr,  " & _
"EndYear, EndQtr, AssessedValue_A, BasicTax_A, BasicDiscount_A, SEFTax_A, SEFDiscount_A, FireServiceFee, TotalTax, PayAmount, PayDate, TenderedAmount, RefYear, RefQtr, PayMode_1, PayType_1, NonCashNumber,  " & _
"Bank_1, NonCashDate, CheckType, CollectorCode, AssessorsName, Payee, Status, KindOfProperty, PayCode, PartialPaid, PartialBalance, PartialTotal, AddPaid, AddBalance, AddTotal, WithAdjustment, UnderCA, CAPenalty_1,  " & _
"DiscountOnPenalty, Getthis, GetValue, new_Partial, new_AddPaid, ComputeAmt, CodeType, New_Remarks, PrefixTag, AssessNo, Orig_TaxDue, Orig_PenDue, Orig_Discount, GARBAGE_FEE, IsPrtArea, IsFrmBackEnd,  " & _
"garbageamt, OverageAmt, DteOfTrans, xACCTNO, xADDRESS, xdateedited, xFIRE_BASIC, xFIRE_SEF, xLOCATION, xMACH, xMACHINE, xmachineedited, xmachineniya, xMODE, xmode_am, xPARTIAL, xPARTIAL_TOT, xPDATE,  " & _
"xPORNUM, xtimeedited, xTOT_AMT, xdateencoded, xtimeencoded, xINPUT, xCHECK, xuniquekey " & _
"FROM            LEDGER where User_ID = '" & _mEmail & "'"

        _mSqlCommand = New SqlCommand(_nQuery & _nQuery2, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()


        _nQuery = ""
        _nQuery2 = ""
        _nQuery = "insert into [" & _mLocServer & "].[" & _mLocDB & "].dbo.ledger ( " & _
"REGION, PROV, CITY, DISTRICT, TDN, Tax_code, Kind, Classification, Actual_use, SubClass, Ass_value, Annual_tax, Tax_due, Pen_due, Pen_Waived, Discount, Tax_credit, Short_Amt, Amount_paid, Lqp, For_year, " & _
"Bas_or, Sef_or, Date_paid, Payer, Time_Posted, Protest, Bank, Check_no, MOrder_no, Check_date, MOrder_date, CheckAmount, MOrder_Amt, User_ID, Date_Posted, CType, TotalAmount, Current_Tax_credit, CC, SHORT_P,  " & _
"Is_Appraised, PayMode, PenDue_Pd, TaxDue_Pd, S_TaxDue, S_PenDue, S_Total, RefFormUse, RefSRS, RefORNO, FormUse, SRS, ORNO, Fr_Lqp, ChkPayee, Remarks, DateIss, B_Code, IsMigrated, LGULevel, Encoder,  " & _
"Prev_TaxCredit, Prev_ShortAmt, CAO, Cur_TDN, isOutsideRem, isLocked, CmprsNO, SchedSeq, Initial_PenDue, Initial_Discount, isPaymentEdited, BillingType, User_Edit, isPART, Initial_TaxDue, BookNo, CostSale, OBAmnt,  " & _
"RCost, Tax_TAXCREDIT, Pen_TAXCREDIT, rem, NoDisc_PenDue, NoDisc_TaxDue, ChckType, SUB_TDN, UserAssess, PercentDisc, ENTRY_FEE, PPrice, RPrice, CA_Penalty, isComproCancelled, taxornumber, taxdecid, tdn_1,  " & _
"classification_1, assessedvalue, taxassessedvalue, taxscope, taxPeriod, dominantuse, ownername, userlogname, BasicTax, SEFTax, BasicPenalty, SEFPenalty, yearfr, yearto, frLqp, toLqp, taxscopeA, idx, tdn001, cmbkey,  " & _
"datepaid, ispayhistory, rem_frompayhist, Basicdiscount, SEFdiscount, BasicPenalty_A, SEFPenalty_A, identNo, ActualUse_GetOne, ActualUse_GetOneF, frmLqp_f, ToLqp_f, yearfr_f, yearto_f, frmtable001, StartYear, StartQtr,  " & _
"EndYear, EndQtr, AssessedValue_A, BasicTax_A, BasicDiscount_A, SEFTax_A, SEFDiscount_A, FireServiceFee, TotalTax, PayAmount, PayDate, TenderedAmount, RefYear, RefQtr, PayMode_1, PayType_1, NonCashNumber,  " & _
"Bank_1, NonCashDate, CheckType, CollectorCode, AssessorsName, Payee, Status, KindOfProperty, PayCode, PartialPaid, PartialBalance, PartialTotal, AddPaid, AddBalance, AddTotal, WithAdjustment, UnderCA, CAPenalty_1,  " & _
"DiscountOnPenalty, Getthis, GetValue, new_Partial, new_AddPaid, ComputeAmt, CodeType, New_Remarks, PrefixTag, AssessNo, Orig_TaxDue, Orig_PenDue, Orig_Discount, GARBAGE_FEE, IsPrtArea, IsFrmBackEnd,  " & _
"garbageamt, OverageAmt, DteOfTrans, xACCTNO, xADDRESS, xdateedited, xFIRE_BASIC, xFIRE_SEF, xLOCATION, xMACH, xMACHINE, xmachineedited, xmachineniya, xMODE, xmode_am, xPARTIAL, xPARTIAL_TOT, xPDATE,  " & _
"xPORNUM, xtimeedited, xTOT_AMT, xdateencoded, xtimeencoded, xINPUT, xCHECK, xuniquekey) "


        _nQuery2 = "SELECT      REGION, PROV, CITY, DISTRICT, TDN, Tax_code, Kind, Classification, Actual_use, SubClass, Ass_value, Annual_tax, Tax_due, Pen_due, Pen_Waived, Discount, Tax_credit, Short_Amt, Amount_paid, Lqp, For_year,  " & _
"Bas_or, Sef_or, Date_paid, Payer, Time_Posted, Protest, Bank, Check_no, MOrder_no, Check_date, MOrder_date, CheckAmount, MOrder_Amt, User_ID, Date_Posted, CType, TotalAmount, Current_Tax_credit, CC, SHORT_P,  " & _
"Is_Appraised, PayMode, PenDue_Pd, TaxDue_Pd, S_TaxDue, S_PenDue, S_Total, RefFormUse, RefSRS, RefORNO, FormUse, SRS, ORNO, Fr_Lqp, ChkPayee, Remarks, DateIss, B_Code, IsMigrated, LGULevel, Encoder,  " & _
"Prev_TaxCredit, Prev_ShortAmt, CAO, Cur_TDN, isOutsideRem, isLocked, CmprsNO, SchedSeq, Initial_PenDue, Initial_Discount, isPaymentEdited, BillingType, User_Edit, isPART, Initial_TaxDue, BookNo, CostSale, OBAmnt,  " & _
"RCost, Tax_TAXCREDIT, Pen_TAXCREDIT, rem, NoDisc_PenDue, NoDisc_TaxDue, ChckType, SUB_TDN, UserAssess, PercentDisc, ENTRY_FEE, PPrice, RPrice, CA_Penalty, isComproCancelled, taxornumber, taxdecid, tdn_1,  " & _
"classification_1, assessedvalue, taxassessedvalue, taxscope, taxPeriod, dominantuse, ownername, userlogname, BasicTax, SEFTax, BasicPenalty, SEFPenalty, yearfr, yearto, frLqp, toLqp, taxscopeA, idx, tdn001, cmbkey,  " & _
"datepaid, ispayhistory, rem_frompayhist, Basicdiscount, SEFdiscount, BasicPenalty_A, SEFPenalty_A, identNo, ActualUse_GetOne, ActualUse_GetOneF, frmLqp_f, ToLqp_f, yearfr_f, yearto_f, frmtable001, StartYear, StartQtr,  " & _
"EndYear, EndQtr, AssessedValue_A, BasicTax_A, BasicDiscount_A, SEFTax_A, SEFDiscount_A, FireServiceFee, TotalTax, PayAmount, PayDate, TenderedAmount, RefYear, RefQtr, PayMode_1, PayType_1, NonCashNumber,  " & _
"Bank_1, NonCashDate, CheckType, CollectorCode, AssessorsName, Payee, Status, KindOfProperty, PayCode, PartialPaid, PartialBalance, PartialTotal, AddPaid, AddBalance, AddTotal, WithAdjustment, UnderCA, CAPenalty_1,  " & _
"DiscountOnPenalty, Getthis, GetValue, new_Partial, new_AddPaid, ComputeAmt, CodeType, New_Remarks, PrefixTag, AssessNo, Orig_TaxDue, Orig_PenDue, Orig_Discount, GARBAGE_FEE, IsPrtArea, IsFrmBackEnd,  " & _
"garbageamt, OverageAmt, DteOfTrans, xACCTNO, xADDRESS, xdateedited, xFIRE_BASIC, xFIRE_SEF, xLOCATION, xMACH, xMACHINE, xmachineedited, xmachineniya, xMODE, xmode_am, xPARTIAL, xPARTIAL_TOT, xPDATE,  " & _
"xPORNUM, xtimeedited, xTOT_AMT, xdateencoded, xtimeencoded, xINPUT, xCHECK, xuniquekey " & _
"FROM            LEDGER where User_ID = '" & _mEmail & "'"

        _mSqlCommand = New SqlCommand(_nQuery & _nQuery2, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()



        _nQuery = ""
        _nQuery2 = ""
        _nQuery = "insert into [" & _mLocServer & "].[" & _mLocDB & "].dbo.payment  "


        _nQuery2 = "SELECT      * " & _
"FROM            PAYMENT where User_ID = '" & _mEmail & "'"

        _mSqlCommand = New SqlCommand(_nQuery & _nQuery2, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()



        _nQuery = ""
        _nQuery2 = ""
        _nQuery = "insert into [" & _mLocServer & "].[" & _mLocDB & "].dbo.BRGYSHARES  "


        _nQuery2 = "SELECT      * " & _
"FROM            BRGYSHARES where User_ID = '" & _mEmail & "'"

        _mSqlCommand = New SqlCommand(_nQuery & _nQuery2, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()



        _nQuery = ""
        _nQuery2 = ""
        _nQuery = "delete from LEDGER where User_ID = '" & _mEmail & "' "
        _mSqlCommand = New SqlCommand(_nQuery & _nQuery2, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()


        _nQuery = ""
        _nQuery2 = ""
        _nQuery = "delete from PAYMENT where User_ID = '" & _mEmail & "' "
        _mSqlCommand = New SqlCommand(_nQuery & _nQuery2, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()


        _nQuery = ""
        _nQuery2 = ""
        _nQuery = "delete from BRGYSHARES where User_ID = '" & _mEmail & "' "
        _mSqlCommand = New SqlCommand(_nQuery & _nQuery2, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()






    End Sub

    Public Sub _pSubUpdatePostedData()
        Dim _nQuery As String = Nothing
        Dim _nQuery2 As String = Nothing




        _nQuery = ""
        _nQuery2 = ""
        _nQuery = "update OnlinePaymentRefno set PostedDate =  getdate() where ACCTNO in (select assessno from [" & _pLocDB & "].dbo.ledger where user_id='" & _pEmail & "') "
        _mSqlCommand = New SqlCommand(_nQuery & _nQuery2, _mSqlCon)
        _mSqlCommand.ExecuteNonQuery()






    End Sub
   

    '------------TOMI END


#End Region

End Class
