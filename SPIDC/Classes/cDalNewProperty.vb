#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region
Public Class cDalNewProperty
#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

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
    Private _mEmail As String
    Private _mFieldsWhere As String
    Private _mLocServer As String
    Private _mLocDB As String
    Private Shared _mTDN As String
    Private Shared _mPIN As String
    Private Shared _mCCN As String
    Private Shared _mUserID As String
    Private Shared _mPropID As String
    Private Shared _mOwnerName As String
    Private Shared _mOwnerAddress As String
    Private Shared _mAdministrator As String
    Private Shared _mAdministratorAddress As String
    Private Shared _mLocProperty As String
    Private Shared _mBrgy As String
    Private Shared _mDistrict As String
    Private Shared _mCityMunicipality As String
    Private Shared _mProvince As String
    Private Shared _mOCT As String
    Private Shared _mSurveyNo As String
    Private Shared _mLotNo As String
    Private Shared _mBlkNo As String
    Private Shared _mNorth As String
    Private Shared _mSouth As String
    Private Shared _mEast As String
    Private Shared _mWest As String
    Private Shared _mArea As String
    Private Shared _mAmountSold As String
    Private Shared _mResidential As String
    Private Shared _mCommercial As String
    Private Shared _mDofSName As String
    Private Shared _mDofSType As String
    Private Shared _mDofSData As Byte()
    Private Shared _mCofTName As String
    Private Shared _mCofTType As String
    Private Shared _mCofTData As Byte()
    Private Shared _mPofPName As String
    Private Shared _mPofPType As String
    Private Shared _mPofPData As Byte()
    Private Shared _mTCName As String
    Private Shared _mTCType As String
    Private Shared _mTCData As Byte()
    Private Shared _mDCName As String
    Private Shared _mDCType As String
    Private Shared _mDCData As Byte()
    Private Shared _mCPName As String
    Private Shared _mCPType As String
    Private Shared _mCPData As Byte()
    Private Shared _mVIdName As String
    Private Shared _mVIdType As String
    Private Shared _mVIdData As Byte()
    Private Shared _mPropNewID As String
    Private Shared _mMineral As String
    Private Shared _mAgricultural As String
    Private Shared _mSpecial As String
    Private Shared _mTimberland As String
    Private Shared _mIndustrial As String
    Private Shared _mRemarks As String
    Private Shared _mStatus As String
#End Region

#Region "Properties Field"
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

    Public Shared Property _pTDN() As String
        Get
            Return _mTDN
        End Get
        Set(value As String)
            _mTDN = value
        End Set
    End Property

    Public Shared Property _pPIN() As String
        Get
            Return _mPIN
        End Get
        Set(value As String)
            _mPIN = value
        End Set
    End Property

    Public Shared Property _pCCN() As String
        Get
            Return _mCCN
        End Get
        Set(value As String)
            _mCCN = value
        End Set
    End Property

    Public Shared Property _pOwnerName() As String
        Get
            Return _mOwnerName
        End Get
        Set(value As String)
            _mOwnerName = value
        End Set
    End Property

    Public Shared Property _pOwnerAddress() As String
        Get
            Return _mOwnerAddress
        End Get
        Set(value As String)
            _mOwnerAddress = value
        End Set
    End Property

    Public Shared Property _pAdministrator() As String
        Get
            Return _mAdministrator
        End Get
        Set(value As String)
            _mAdministrator = value
        End Set
    End Property

    Public Shared Property _pAdministratorAddress() As String
        Get
            Return _mAdministratorAddress
        End Get
        Set(value As String)
            _mAdministratorAddress = value
        End Set
    End Property

    Public Shared Property _pLocProperty() As String
        Get
            Return _mLocProperty
        End Get
        Set(value As String)
            _mLocProperty = value
        End Set
    End Property

    Public Shared Property _pBrgy() As String
        Get
            Return _mBrgy
        End Get
        Set(value As String)
            _mBrgy = value
        End Set
    End Property

    Public Shared Property _pDistrict() As String
        Get
            Return _mDistrict
        End Get
        Set(value As String)
            _mDistrict = value
        End Set
    End Property

    Public Shared Property _pOCT() As String
        Get
            Return _mOCT
        End Get
        Set(value As String)
            _mOCT = value
        End Set
    End Property

    Public Shared Property _pSurveyNo() As String
        Get
            Return _mSurveyNo
        End Get
        Set(value As String)
            _mSurveyNo = value
        End Set
    End Property

    Public Shared Property _pLotNo() As String
        Get
            Return _mLotNo
        End Get
        Set(value As String)
            _mLotNo = value
        End Set
    End Property

    Public Shared Property _pBlkNo() As String
        Get
            Return _mBlkNo
        End Get
        Set(value As String)
            _mBlkNo = value
        End Set
    End Property

    Public Shared Property _pNorth() As String
        Get
            Return _mNorth
        End Get
        Set(value As String)
            _mNorth = value
        End Set
    End Property

    Public Shared Property _pSouth() As String
        Get
            Return _mSouth
        End Get
        Set(value As String)
            _mSouth = value
        End Set
    End Property

    Public Shared Property _pEast() As String
        Get
            Return _mEast
        End Get
        Set(value As String)
            _mEast = value
        End Set
    End Property

    Public Shared Property _pWest() As String
        Get
            Return _mWest
        End Get
        Set(value As String)
            _mWest = value
        End Set
    End Property

    Public Shared Property _pArea() As String
        Get
            Return _mArea
        End Get
        Set(value As String)
            _mArea = value
        End Set
    End Property

    Public Shared Property _pAmountSold() As String
        Get
            Return _mAmountSold
        End Get
        Set(value As String)
            _mAmountSold = value
        End Set
    End Property

    Public Shared Property _pResidential() As String
        Get
            Return _mResidential
        End Get
        Set(value As String)
            _mResidential = value
        End Set
    End Property

    Public Shared Property _pCommercial() As String
        Get
            Return _mCommercial
        End Get
        Set(value As String)
            _mCommercial = value
        End Set
    End Property

    Public Shared Property _pDofSName() As String
        Get
            Return _mDofSName
        End Get
        Set(value As String)
            _mDofSName = value
        End Set
    End Property

    Public Shared Property _pDofSType() As String
        Get
            Return _mDofSType
        End Get
        Set(value As String)
            _mDofSType = value
        End Set
    End Property

    Public Shared Property _pDofSData() As Byte()
        Get
            Return _mDofSData
        End Get
        Set(value As Byte())
            _mDofSData = value
        End Set
    End Property
    Public Shared Property _pCofTName() As String
        Get
            Return _mCofTName
        End Get
        Set(value As String)
            _mCofTName = value
        End Set
    End Property
    Public Shared Property _pCofType() As String
        Get
            Return _mCofTType
        End Get
        Set(value As String)
            _mCofTType = value
        End Set
    End Property
    Public Shared Property _pCofData() As Byte()
        Get
            Return _mCofTData
        End Get
        Set(value As Byte())
            _mCofTData = value
        End Set
    End Property

    Public Shared Property _pPofPName() As String
        Get
            Return _mPofPName
        End Get
        Set(value As String)
            _mPofPName = value
        End Set
    End Property

    Public Shared Property _pPofPType() As String
        Get
            Return _mPofPType
        End Get
        Set(value As String)
            _mPofPType = value
        End Set
    End Property

    Public Shared Property _pPofPData() As Byte()
        Get
            Return _mPofPData
        End Get
        Set(value As Byte())
            _mPofPData = value
        End Set
    End Property
    Public Shared Property _pTCName() As String
        Get
            Return _mTCName
        End Get
        Set(value As String)
            _mTCName = value
        End Set
    End Property
    Public Shared Property _pTCType() As String
        Get
            Return _mTCType
        End Get
        Set(value As String)
            _mTCType = value
        End Set
    End Property
    Public Shared Property _pTCData() As Byte()
        Get
            Return _mTCData
        End Get
        Set(value As Byte())
            _mTCData = value
        End Set
    End Property
    Public Shared Property _pDCName() As String
        Get
            Return _mDCName
        End Get
        Set(value As String)
            _mDCName = value
        End Set
    End Property
    Public Shared Property _pDCType() As String
        Get
            Return _mDCType
        End Get
        Set(value As String)
            _mDCType = value
        End Set
    End Property
    Public Shared Property _pDCData() As Byte()
        Get
            Return _mDCData
        End Get
        Set(value As Byte())
            _mDCData = value
        End Set
    End Property
    Public Shared Property _pCPName() As String
        Get
            Return _mCPName
        End Get
        Set(value As String)
            _mCPName = value
        End Set
    End Property
    Public Shared Property _pCPType() As String
        Get
            Return _mCPType
        End Get
        Set(value As String)
            _mCPType = value
        End Set
    End Property
    Public Shared Property _pCPData() As Byte()
        Get
            Return _mCPData
        End Get
        Set(value As Byte())
            _mCPData = value
        End Set
    End Property
    Public Shared Property _pVIdName() As String
        Get
            Return _mVIdName
        End Get
        Set(value As String)
            _mVIdName = value
        End Set
    End Property
    Public Shared Property _pVIdType() As String
        Get
            Return _mVIdType
        End Get
        Set(value As String)
            _mVIdType = value
        End Set
    End Property
    Public Shared Property _pVIdData() As Byte()
        Get
            Return _mVIdData
        End Get
        Set(value As Byte())
            _mVIdData = value
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
    Public Property _pUserID() As String
        Get
            Return _mUserID
        End Get
        Set(ByVal value As String)
            _mUserID = value
        End Set
    End Property
    Public Property _pPropID() As String
        Get
            Return _mPropID
        End Get
        Set(ByVal value As String)
            _mPropID = value
        End Set
    End Property
    Public Shared Property _pCityMunicipality() As String
        Get
            Return _mCityMunicipality
        End Get
        Set(ByVal value As String)
            _mCityMunicipality = value
        End Set
    End Property

    Public Shared Property _pProvince() As String
        Get
            Return _mProvince
        End Get
        Set(ByVal value As String)
            _mProvince = value
        End Set
    End Property
    Public Shared Property _pMineral() As String
        Get
            Return _mMineral
        End Get
        Set(value As String)
            _mMineral = value
        End Set
    End Property

    Public Shared Property _pAgricultural() As String
        Get
            Return _mAgricultural
        End Get
        Set(value As String)
            _mAgricultural = value
        End Set
    End Property

    Public Shared Property _pSpecial() As String
        Get
            Return _mSpecial
        End Get
        Set(value As String)
            _mSpecial = value
        End Set
    End Property

    Public Shared Property _pTimberland() As String
        Get
            Return _mTimberland
        End Get
        Set(value As String)
            _mTimberland = value
        End Set
    End Property

    Public Shared Property _pIndustrial() As String
        Get
            Return _mIndustrial
        End Get
        Set(value As String)
            _mIndustrial = value
        End Set
    End Property

    Public Shared Property _pRemarks() As String
        Get
            Return _mRemarks
        End Get
        Set(value As String)
            _mRemarks = value
        End Set
    End Property

    Public Shared Property _pIsForPayment() As String
        Get
            Return _mStatus
        End Get
        Set(value As String)
            _mStatus = value
        End Set
    End Property

#End Region

#Region "Routine Command"

    Public Sub _pGenCode()
        Dim _mSqlReader As SqlDataReader
        Dim temp As String
        Try
            Dim _nQuery As String = "SELECT MAX(propid) 'propid' FROM RPTASMastNew "
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            _mSqlReader = _nSqlCommand.ExecuteReader
            If _mSqlReader.HasRows Then
                While _mSqlReader.Read()
                    If IsDBNull(_mSqlReader.Item("propid")) Then
                        temp = 1
                    Else
                        temp = _mSqlReader.Item("propid") + 1
                    End If
                End While
            End If
            For index As Integer = temp.Length To 3
                temp = "0" & temp
            Next
            _mPropNewID = temp
            _mSqlReader.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubInsertAttachFiles()
        Try
            Dim _nQuery As String = Nothing
            _pGenCode()
            _nQuery = "INSERT INTO RPTASMastNew" & _
                            "( " & _
                            " userID " & _
                            " ,PropId " & _
                            " ,OwnerName " & _
                            " ,OwnerAddress " & _
                            " ,Administrator " & _
                            " ,AdministratorAddress " & _
                            " ,District " & _
                            " ,Brgy " & _
                            " ,LocProperty " & _
                            " ,OCT " & _
                            " ,SurveyNo " & _
                            " ,LotNo " & _
                            " ,BlkNo " & _
                            " ,Area " & _
                            " ,AmountSold " & _
                            " ,Residential " & _
                            " ,Commercial " & _
                            " ,DeedSaleName " & _
                            " ,DeedSaleType " & _
                            " ,DeedSaleData " & _
                            " ,CopyTitleName " & _
                            " ,CopyTitleType " & _
                            " ,CopyTitleData " & _
                            " ,ProofPaymentName " & _
                            " ,ProofPaymentType " & _
                            " ,ProofPaymentData " & _
                            " ,TaxClearanceName " & _
                            " ,TaxClearanceType " & _
                            " ,TaxClearanceData " & _
                            " ,DeclarationCopyName " & _
                            " ,DeclarationCopyType " & _
                            " ,DeclarationCopyData " & _
                            " ,CorpPropName " & _
                            " ,CorpPropType " & _
                            " ,CorpPropData " & _
                            " ,ValidIdName " & _
                            " ,ValidIdType " & _
                            " ,ValidIdData " & _
                            " ,TransDate " & _
                            " ,CityMunicipality " & _
                            " ,Province " & _
                            " ,Agricultural " & _
                            " ,Mineral " & _
                            " ,Special " & _
                            " ,Timberland " & _
                            " ,Industrial " & _
                            " ,Status" & _
                            " ) " & _
                            "VALUES " & _
                            "( " & _
                            "'" & cSessionUser._pUserID & "'" & _
                            ",'" & _mPropNewID & "'" & _
                            ",'" & _mOwnerName & "'" & _
                            ",'" & _mOwnerAddress & "'" & _
                            ",'" & _mAdministrator & "'" & _
                            ",'" & _mAdministratorAddress & "'" & _
                            ",'" & _mDistrict & "'" & _
                            ",'" & _mBrgy & "'" & _
                            ",'" & _mLocProperty & "'" & _
                            ",'" & _mOCT & "'" & _
                            ",'" & _mSurveyNo & "'" & _
                            ",'" & _mLotNo & "'" & _
                            ",'" & _mBlkNo & "'" & _
                            ",'" & _mArea & "'" & _
                            ",'" & _mAmountSold & "'" & _
                            ",'" & _mResidential & "'" & _
                            ",'" & _mCommercial & "'" & _
                            ",'" & _mDofSName & "'" & _
                            ",'" & _mDofSType & "'" & _
                            ", @DeedSaleData " & _
                            ",'" & _mCofTName & "'" & _
                            ",'" & _mCofTType & "'" & _
                            ", @CopyTitleData " & _
                            ",'" & _mPofPName & "'" & _
                            ",'" & _mPofPType & "'" & _
                            ", @ProofPaymentData " & _
                            ",'" & _mTCName & "'" & _
                            ",'" & _mTCType & "'" & _
                            ", @TaxClearanceData " & _
                            ",'" & _mDCName & "'" & _
                            ",'" & _mDCType & "'" & _
                            ", @DeclarationCopyData " & _
                            ",'" & _mCPName & "'" & _
                            ",'" & _mCPType & "'" & _
                            ", @CorpPropData " & _
                            ",'" & _mVIdName & "'" & _
                            ",'" & _mVIdType & "'" & _
                            ", @ValidIdData " & _
                            ",'" & DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") & "'" & _
                            ",'" & _mCityMunicipality & "'" & _
                            ",'" & _mProvince & "'" & _
                            ",'" & _mAgricultural & "'" & _
                            ",'" & _mMineral & "'" & _
                            ",'" & _mSpecial & "'" & _
                            ",'" & _mTimberland & "'" & _
                            ",'" & _mIndustrial & "'" & _
                            ",'" & If(_mStatus Is Nothing, "0", _mStatus) & "'" & _
                            " )"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@DeedSaleData", _mDofSData)
                .AddWithValue("@CopyTitleData", _mCofTData)
                .AddWithValue("@ProofPaymentData", _mPofPData)
                .AddWithValue("@TaxClearanceData", _mTCData)
                .AddWithValue("@DeclarationCopyData", _mDCData)
                .AddWithValue("@CorpPropData", _mCPData)
                .AddWithValue("@ValidIdData", _mVIdData)
            End With
            '----------------------------------
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _pSubSelect(_nTable As String, _nCondition As String)

        Try
            '----------------------------------
            'TODO: Perform Checking of Primary Keys to be inserted here if is nothing.

            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = _nCondition

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
               "FROM " & _nTable & _
               " "
            '----------------------------------    [RPTASMastNew]


            '_nWhere = "WHERE [IDNo] = @_mIDNo "
            '_nWhere += "OR [IDNoRegistered] = @_mIDNoRegistered "
            If Not String.IsNullOrEmpty(_mPropID) And Not String.IsNullOrEmpty(_mUserID) Then
                If Not String.IsNullOrEmpty(_nWhere) Then
                    _nWhere = (_nWhere.ToUpper()).Replace("WHERE", "")
                    _nWhere = "where userid = '" & _mUserID & "' and propid = '" & _mPropID & "' and " + _nWhere

                Else
                    _nWhere += "where userid = '" & _mUserID & "' and propid = '" & _mPropID & "' "
                End If

            End If

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

#End Region
End Class

