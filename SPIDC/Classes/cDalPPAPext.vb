

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalPPAPext

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader




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

    Public ReadOnly Property _pIDNo() As String
        Get
            Return _mIDNo
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

    Private _mIDNo As String = Nothing
    Private _mfieldsWhere As String
    Private _mfields As String
    Private _mEmail As String
    Private _mWebServer As String
    Private _mDatabase As String
    Private _mStatus As String
    Private _mUserType As String
    Private _mForYear As String
    Private _mDeptCode As String
    Private _mRegCode As String
    Private _mAgencyCode As String
    Private _mOUCode As String
    Private _mTier As String
    Private _mDateEncoded As Date
    Private _mEncodedBy As String
    Private _mAcro As String
    Private _mIncrement As String
    Private _mCode As String
    Private _mDescription As String
    Private _mBoolean As Boolean
    Private _mUserID As String
    Private _mSpecificProject As String
    Private _mSpecificProgram As String

    Private _mControlNo As String
    Private _mcoststrcode As String
    Private _mSpecificActivity As String
    Private _mProjectcode As String
    Private _mSpecificCode As String

    Private _mFundingSource As String
    Private _mTargetBeneficiary As String
    Private _mExpectedOutput As String
    Private _mOutputIndicator As String
    Private _mschedfrom As Date
    Private _mschedto As Date


    Private _mjustification As String
    Private _mjan As String
    Private _mfeb As String
    Private _mmar As String
    Private _mapril As String
    Private _mmay As String
    Private _mjun As String
    Private _mjul As String
    Private _maug As String
    Private _msep As String
    Private _moct As String
    Private _mnov As String
    Private _mdecember As String
    Private _mcctypology As String
    Private _madaptation As String
    Private _mmitigation As String
    Private _mPPMP As String
    Private _mEXPcode As String

#End Region

#Region "Properties Field"
    Public Property _pEXPcode As String
        Get
            Return _mEXPcode
        End Get
        Set(value As String)
            _mEXPcode = value
        End Set
    End Property
    Public Property _pPPMP As String
        Get
            Return _mPPMP
        End Get
        Set(value As String)
            _mPPMP = value
        End Set
    End Property
    Public Property _padaptation As String
        Get
            Return _madaptation
        End Get
        Set(value As String)
            _madaptation = value
        End Set
    End Property
    Public Property _pmitigation As String
        Get
            Return _mmitigation
        End Get
        Set(value As String)
            _mmitigation = value
        End Set
    End Property
    Public Property _pcctypology As String
        Get
            Return _mcctypology
        End Get
        Set(value As String)
            _mcctypology = value
        End Set
    End Property
    Public Property _pdecember As String
        Get
            Return _mdecember
        End Get
        Set(value As String)
            _mdecember = value
        End Set
    End Property
    Public Property _pnov As String
        Get
            Return _mnov
        End Get
        Set(value As String)
            _mnov = value
        End Set
    End Property
    Public Property _poct As String
        Get
            Return _moct
        End Get
        Set(value As String)
            _moct = value
        End Set
    End Property
    Public Property _psep As String
        Get
            Return _msep
        End Get
        Set(value As String)
            _msep = value
        End Set
    End Property
    Public Property _paug As String
        Get
            Return _maug
        End Get
        Set(value As String)
            _maug = value
        End Set
    End Property
    Public Property _pjul As String
        Get
            Return _mjul
        End Get
        Set(value As String)
            _mjul = value
        End Set
    End Property
    Public Property _pjun As String
        Get
            Return _mjun
        End Get
        Set(value As String)
            _mjun = value
        End Set
    End Property
    Public Property _pmay As String
        Get
            Return _mmay
        End Get
        Set(value As String)
            _mmay = value
        End Set
    End Property
    Public Property _papril As String
        Get
            Return _mapril
        End Get
        Set(value As String)
            _mapril = value
        End Set
    End Property
    Public Property _pmar As String
        Get
            Return _mmar
        End Get
        Set(value As String)
            _mmar = value
        End Set
    End Property
    Public Property _pfeb As String
        Get
            Return _mfeb
        End Get
        Set(value As String)
            _mfeb = value
        End Set
    End Property
    Public Property _pjan As String
        Get
            Return _mjan
        End Get
        Set(value As String)
            _mjan = value
        End Set
    End Property
    Public Property _pjustification As String
        Get
            Return _mjustification
        End Get
        Set(value As String)
            _mjustification = value
        End Set
    End Property
    Public Property _pschedto As Date
        Get
            Return _mschedto
        End Get
        Set(value As Date)
            _mschedto = value
        End Set
    End Property
    Public Property _pschedfrom As Date
        Get
            Return _mschedfrom
        End Get
        Set(value As Date)
            _mschedfrom = value
        End Set
    End Property
    Public Property _pOutputIndicator As String
        Get
            Return _mOutputIndicator
        End Get
        Set(value As String)
            _mOutputIndicator = value
        End Set
    End Property
    Public Property _pExpectedOutput As String
        Get
            Return _mExpectedOutput
        End Get
        Set(value As String)
            _mExpectedOutput = value
        End Set
    End Property
    Public Property _ptargetbeneficiary As String
        Get
            Return _mTargetBeneficiary
        End Get
        Set(value As String)
            _mTargetBeneficiary = value
        End Set
    End Property
    Public Property _pBoolean As Boolean
        Get
            Return _mBoolean
        End Get
        Set(value As Boolean)
            _mBoolean = value
        End Set
    End Property
    Public Property _pSpecificActivity As String
        Get
            Return _mSpecificActivity
        End Get
        Set(value As String)
            _mSpecificActivity = value
        End Set
    End Property
    Public Property _pSpecificCode As String
        Get
            Return _mSpecificCode
        End Get
        Set(value As String)
            _mSpecificCode = value
        End Set
    End Property
    Public Property _pSpecificproject As String
        Get
            Return _mSpecificProject
        End Get
        Set(value As String)
            _mSpecificProject = value
        End Set
    End Property
    Public Property _pProjectCode As String
        Get
            Return _mProjectcode
        End Get
        Set(value As String)
            _mProjectcode = value
        End Set
    End Property
    Public Property _pFundingSource As String
        Get
            Return _mFundingSource
        End Get
        Set(value As String)
            _mFundingSource = value
        End Set
    End Property
    Public Property _pUserID As String
        Get
            Return _mUserID
        End Get
        Set(value As String)
            _mUserID = value
        End Set
    End Property
    Public Property _pSpecificProgram As String
        Get
            Return _mSpecificProgram
        End Get
        Set(value As String)
            _mSpecificProgram = value
        End Set
    End Property
    Public Property _pCostStrcode As String
        Get
            Return _mcoststrcode
        End Get
        Set(value As String)
            _mcoststrcode = value
        End Set
    End Property
    Public Property _pDescription As String
        Get
            Return _mDescription
        End Get
        Set(value As String)
            _mDescription = value
        End Set
    End Property


    Public Property _pCode As String
        Get
            Return _mCode
        End Get
        Set(value As String)
            _mCode = value
        End Set
    End Property

    Public Property _pfields As String
        Get
            Return _mfields
        End Get
        Set(value As String)
            _mfields = value
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
    Public Property _pfieldsWhere As String
        Get
            Return _mfieldsWhere
        End Get
        Set(value As String)
            _mfieldsWhere = value
        End Set
    End Property
    Public Property _pUserType As String
        Get
            Return _mUserType
        End Get
        Set(value As String)
            _mUserType = value
        End Set
    End Property

    Public Property _pControlNo As String
        Get
            Return _mControlNo
        End Get
        Set(value As String)
            _mControlNo = value
        End Set
    End Property
    Public Property _pForYear As String
        Get
            Return _mForYear
        End Get
        Set(value As String)
            _mForYear = value
        End Set
    End Property
    Public Property _pDeptCode As String
        Get
            Return _mDeptCode
        End Get
        Set(value As String)
            _mDeptCode = value
        End Set
    End Property
    Public Property _pRegCode As String
        Get
            Return _mRegCode
        End Get
        Set(value As String)
            _mRegCode = value
        End Set
    End Property
    Public Property _pAgencyCode As String
        Get
            Return _mAgencyCode
        End Get
        Set(value As String)
            _mAgencyCode = value
        End Set
    End Property
    Public Property _pOUCode As String
        Get
            Return _mOUCode
        End Get
        Set(value As String)
            _mOUCode = value
        End Set
    End Property
    Public Property _pTier As String
        Get
            Return _mTier
        End Get
        Set(value As String)
            _mTier = value
        End Set
    End Property
    Public Property _pDateEncoded As Date
        Get
            Return _mDateEncoded
        End Get
        Set(value As Date)
            _mDateEncoded = value
        End Set
    End Property
    Public Property _pEncodedBy As String
        Get
            Return _mEncodedBy
        End Get
        Set(value As String)
            _mEncodedBy = value
        End Set
    End Property


#End Region

#Region "Routine Command"
    '"SELECT ACRO FROM DEPARTMENTS WHERE FORYEAR = '" & AcctYear & "' AND DEPTCODE = '" & txtBox(0).Text & "' "
    'SELECT ACRO FROM DEPARTMENTS WHERE FORYEAR = '2018' AND DEPTCODE = '1011-1-000'
    'select  from   and RegCode = '04'  and AgencyCode = '001'  and OUCode = '001'  and DeptCode = '1011-1-000'  AND CHARINDEX('a-',CONTROLNO) <> 0  order by 
    'Public Sub _pSubAutoIncrement(nTable As String, nFieldName As String, nDigit As String, Optional nCondition As String = "")
    Public Sub _pSubAutoIncrement()

        'select muna acro sa department tsaka i increment--------------

        Dim _nQuery As String = Nothing
        Dim _mQuery As String = Nothing
        Dim _nWhere As String = Nothing
        _nQuery = _
           "SELECT " & _
           " ACRO  " & _
           "FROM [DEPARTMENTS] WHERE FORYEAR = '" & _mForYear & "' AND DEPTCODE = '" & _mDeptCode & "'" & _
            " "

        Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
        '---------------------------------- 
        Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
        _mDataTable = New DataTable

        _nSqlDataAdapter.Fill(_mDataTable)
        If _mDataTable.Rows.Count > 0 Then
            If IsDBNull(_mDataTable.Rows(0).Item("ACRO")) Then
                _mAcro = ""
            Else
                _mAcro = _mDataTable.Rows(0).Item("ACRO")
            End If
        End If

        _nSqlDataAdapter.Dispose()



        If _mAcro = "" Then
            _pControlNo = ""
        Else
            _mQuery = _
          "SELECT " & _
          " CONTROLNO  " & _
          "FROM [PPAP] WHERE CHARINDEX('" & _mAcro & "-',CONTROLNO) <> 0  order by CONTROLNO desc" & _
           " "



            Dim _nSqlCommand2 As New SqlCommand(_mQuery, _mSqlCon)
            '---------------------------------- 
            Dim _nSqlDataAdapter2 As New SqlDataAdapter(_nSqlCommand2)
            _mDataTable = New DataTable

            _nSqlDataAdapter2.Fill(_mDataTable)



            _mIncrement = Right(Format(Right((_mDataTable.Rows(0).Item("CONTROLNO")), 5) + 1, "0000000000"), 5)
            _pControlNo = _mAcro + "-" + _mIncrement

        End If




    End Sub


    Public Sub _pSubSearchBudget()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
               "SELECT " & _
               "  ControlNo,ForYear,DeptCode,RegCode,AgencyCode,OUCode " & _
               "FROM [PPAP] WHERE " & _mfields & " LIKE '%" & _mfieldsWhere & "%' "



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)
                'If Not String.IsNullOrWhiteSpace(_mfields) Then .AddWithValue("@_mfields", _mfields)
            End With

            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Public Sub _pSubSearchPlanning()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
               "SELECT " & _
               "  ControlNo,ForYear,DeptCode,RegCode,AgencyCode,OUCode " & _
               "FROM [PPAP] WHERE " & _mfields & " LIKE '%" & _mfieldsWhere & "%' and  submittedby is NULL "



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub


    Public Sub _pSubSearch()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            'for improve of filtering 20171012
            '_nQuery = _
            '   "SELECT " & _
            '   "  ControlNo,ForYear,DeptCode,RegCode,AgencyCode,OUCode " & _
            '   "FROM [PPAP] WHERE " & _mfields & " LIKE '%" & _mfieldsWhere & "%' and  DeptCode = '" & _mUserType & "' "

            '_nQuery = _
            ' "SELECT     ControlNo,  Foryear, " & _
            '"(select [Acro] from DBO.Departments as D where D.DeptCode = P.DeptCode and D.foryear = year(P.Foryear) ) as dep, " & _
            '"  (Select Acronym from DBO.Region as R where R.Code = P.RegCode) as RegAcro, " & _
            '"  (Select [Description] from DBO.Agency as A where A.Code = P.AgencyCode) as AgencyAcro, " & _
            '"  (Select [Description] from DBO.LOU_Classification as L where L.Code = P.OUCode) as OUCodeAcro " & _
            '"FROM [PPAP] as P WHERE " & _mfields & " LIKE '%" & _mfieldsWhere & "%' "

            _nQuery = _
            "select controlno,foryear,deptacro,RegAcro,Agency,Operatingunit from vw_ppap " & _
            "WHERE " & _mfields & " LIKE '%" & _mfieldsWhere & "%' "



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
    Public Sub _pSubIfExist()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            'for improve of filtering 20171012
            '_nQuery = _
            '   "SELECT " & _
            '   "  ControlNo,ForYear,DeptCode,RegCode,AgencyCode,OUCode " & _
            '   "FROM [PPAP] WHERE " & _mfields & " LIKE '%" & _mfieldsWhere & "%' and  DeptCode = '" & _mUserType & "' "

            '_nQuery = _
            ' "SELECT     ControlNo,  Foryear, " & _
            '"(select [Acro] from DBO.Departments as D where D.DeptCode = P.DeptCode and D.foryear = year(P.Foryear) ) as dep, " & _
            '"  (Select Acronym from DBO.Region as R where R.Code = P.RegCode) as RegAcro, " & _
            '"  (Select [Description] from DBO.Agency as A where A.Code = P.AgencyCode) as AgencyAcro, " & _
            '"  (Select [Description] from DBO.LOU_Classification as L where L.Code = P.OUCode) as OUCodeAcro " & _
            '"FROM [PPAP] as P WHERE " & _mfields & " LIKE '%" & _mfieldsWhere & "%' "

            _nQuery = _
            "select controlno,foryear,deptacro,RegAcro,Agency,Operatingunit from vw_ppap " & _
            "WHERE FORYEAR = '" & _mForYear & "' and deptcode = '" & _mDeptCode & "' "
            '20171018 need to add oucode for filtering


            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                _mBoolean = True
            Else
                _mBoolean = False
            End If
        Catch ex As Exception

        End Try



    End Sub



    Public Sub _pSubinsertRecord()
        Try
            Dim dte As Date = Now.Date
            _mQuery = _
             "INSERT INTO " & _
              "[PPAP] " & _
              " (controlno,foryear,deptcode,regcode,agencycode,oucode,tier,dateencoded,encodedby) " & _
              " VALUES " & _
              " ('" & _mControlNo & "','" & _mForYear & "','" & _mDeptCode & "','" & _mRegCode & "','" & _mAgencyCode & "','" & _mOUCode & "','TIER I','" & dte & "','" & _mEncodedBy & "') "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Function _mSubSelectRegion() As String
        Try
            _mSubSelectRegion = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            _nQuery = _
                  "SELECT " & _
                  "* " & _
                  "FROM [REGION] " & _
                   " "


            '----------------------------------

            _mSubSelectRegion = _nQuery
            '----------------------------------
        Catch ex As Exception
            _mSubSelectRegion = Nothing
        End Try

    End Function

    Public Function _mSubSelectOperatingUnit() As String
        Try
            _mSubSelectOperatingUnit = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            _nQuery = _
                  "SELECT " & _
                  "* " & _
                  "FROM [lou_classification] " & _
                   "  "


            '----------------------------------

            _mSubSelectOperatingUnit = _nQuery
            '----------------------------------
        Catch ex As Exception
            _mSubSelectOperatingUnit = Nothing
        End Try

    End Function

    Public Function _mSubSelectOffice() As String
        Try
            _mSubSelectOffice = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            _nQuery = _
                  "SELECT " & _
                  "* " & _
                  "FROM [Departments] " & _
                   " WHERE ETYPE='MAIN' and foryear= '" & _mForYear & "' "


            '----------------------------------

            _mSubSelectOffice = _nQuery
            '----------------------------------
        Catch ex As Exception
            _mSubSelectOffice = Nothing
        End Try

    End Function
    Public Function _mSubSelectAgency() As String
        Try
            _mSubSelectAgency = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            _nQuery = _
                  "SELECT " & _
                  "* " & _
                  "FROM [Agency] " & _
                   " "


            '----------------------------------

            _mSubSelectAgency = _nQuery
            '----------------------------------
        Catch ex As Exception
            _mSubSelectAgency = Nothing
        End Try

    End Function
#End Region

#Region "Routine Sub Select"


    Public Sub _pSubSelectrecord()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
            "select SubmittedBy,controlno,foryear,department,RegAcro,Agency,Operatingunit,DeptCode from vw_ppap " & _
            "WHERE ControlNo = '" & _mfieldsWhere & "' "

            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
    Public Sub _pSubSelectactivity()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing









            _nQuery = _
            "SELECT distinct ControlNo,specificcode,projcode,actvcode,coststrcode,csdesc,GenProgram,ActvDesc,ProjDesc, " & _
            "SpecificProj,FundSource,TargetBeneficiary,ExpectedOutput, " & _
            "OutputIndicator, SchedFrom, SchedTo,justification " & _
            "from vw_PPAPEXT " & _
            "WHERE ControlNo = '" & _mfieldsWhere & "' " & _
            "and CoststrCode='" & _mcoststrcode & "' and ActvCode='" & _mSpecificProgram & "' and ProjCode='" & _mProjectcode & "' and SpecificCode='" & _mSpecificActivity & "' "




            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub

    Public Sub _pSubSelectBudgetaappropriationPS()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing









            _nQuery = _
            "SELECT        ControlNo,Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep, October " & _
            ", Nov, December, TotalAmount, CCTypology, TypologyDesc, Adaptation, Mitigation,justification " & _
            "FROM            vw_PPAPEXT  " & _
            "where expcode='PS' and ControlNo = '" & _mfieldsWhere & "' " & _
            "and CoststrCode='" & _mcoststrcode & "' and ActvCode='" & _mSpecificProgram & "' and ProjCode='" & _mProjectcode & "' and SpecificCode='" & _mSpecificActivity & "' "




            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
    Public Sub _pSubSelectBudgetaappropriationCO()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing









            _nQuery = _
            "SELECT        ControlNo,Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep, October " & _
            ", Nov, December, TotalAmount, CCTypology, TypologyDesc, Adaptation, Mitigation,justification  " & _
            "FROM            vw_PPAPEXT  " & _
            "where expcode='CO' and ControlNo = '" & _mfieldsWhere & "' " & _
            "and CoststrCode='" & _mcoststrcode & "' and ActvCode='" & _mSpecificProgram & "' and ProjCode='" & _mProjectcode & "' and SpecificCode='" & _mSpecificActivity & "' "




            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
    Public Sub _pSubSelectBudgetaappropriationMOOE()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing









            _nQuery = _
            "SELECT        ControlNo,Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep, October " & _
            ", Nov, December, TotalAmount, CCTypology, TypologyDesc, Adaptation, Mitigation,justification " & _
            "FROM            vw_PPAPEXT  " & _
            "where expcode='MOOE'  and ppmp='1' and ControlNo = '" & _mfieldsWhere & "' " & _
            "and CoststrCode='" & _mcoststrcode & "' and ActvCode='" & _mSpecificProgram & "' and ProjCode='" & _mProjectcode & "' and SpecificCode='" & _mSpecificActivity & "' "




            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
    Public Sub _pSubSelectBudgetaappropriationMOOENONPPMP()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing








            _nQuery = _
                        "SELECT        ControlNo,Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep, October " & _
                        ", Nov, December, TotalAmount, CCTypology, TypologyDesc, Adaptation, Mitigation,justification  " & _
                        "FROM            vw_PPAPEXT  " & _
                        "where expcode='MOOE'  and ppmp='0' and ControlNo = '" & _mfieldsWhere & "' " & _
                        "and CoststrCode='" & _mcoststrcode & "' and ActvCode='" & _mSpecificProgram & "' and ProjCode='" & _mProjectcode & "' and SpecificCode='" & _mSpecificActivity & "' "






            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub

#End Region

#Region "Cost Structure"

    Public Function _mSubSelectCostStructure() As String
        Try
            _mSubSelectCostStructure = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            _nQuery = _
                  "SELECT " & _
                  "* " & _
                  "FROM [CostStructure] " & _
                   " "


            '----------------------------------

            _mSubSelectCostStructure = _nQuery
            '----------------------------------
        Catch ex As Exception
            _mSubSelectCostStructure = Nothing
        End Try

    End Function
    Public Sub _pSubIfExistCostStructure()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select coststrcode from tempbudgetweb " & _
            "WHERE controlno = '" & _mControlNo & "' and UserID = '" & _mUserID & "' and coststrcode = '" & _mcoststrcode & "' "



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                _mBoolean = True
            Else
                _mBoolean = False
            End If
        Catch ex As Exception

        End Try



    End Sub

    Public Sub _pSubinsertCostStructure()
        Try

            _mQuery = _
             "INSERT INTO " & _
              "[tempbudgetweb] " & _
              " (coststrcode,controlno,UserID) " & _
              " VALUES " & _
              " ('" & _mCode & "','" & _mControlNo & "','" & _mUserID & "') "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubSelectCostStructure()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select distinct coststrcode,(select description from CostStructure where code = tempbudgetweb.coststrcode) as coststrdesc " & _
            "from tempbudgetweb " & _
            "where UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' " & _
            ""



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub

#End Region

#Region "Specific Program / General Program"

    Public Function _mSubSelectFundingsource() As String
        Try
            _mSubSelectFundingsource = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            _nQuery = _
                  "SELECT " & _
                  "* " & _
                  "FROM [Fund_Source_Code] " & _
                   " "


            '----------------------------------

            _mSubSelectFundingsource = _nQuery
            '----------------------------------
        Catch ex As Exception
            _mSubSelectFundingsource = Nothing
        End Try

    End Function
    Public Function _mSubSelectSpecificProgram() As String
        Try
            _mSubSelectSpecificProgram = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            _nQuery = _
                  "SELECT " & _
                  "* " & _
                  "FROM [activity] " & _
                   " "


            '----------------------------------

            _mSubSelectSpecificProgram = _nQuery
            '----------------------------------
        Catch ex As Exception
            _mSubSelectSpecificProgram = Nothing
        End Try

    End Function


    Public Sub _pSubIfExistSpecificProgram()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select actvcode from tempbudgetweb " & _
            "WHERE controlno = '" & _mControlNo & "' and UserID = '" & _mUserID & "' and actvcode = '" & _mSpecificProgram & "' and CoststrCode = '" & _mcoststrcode & "' "



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                _mBoolean = True
            Else
                _mBoolean = False
            End If
        Catch ex As Exception

        End Try



    End Sub

    Public Sub _pSubinsertSPecificProgram()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "


            _mQuery = _
             "INSERT INTO " & _
              "[tempbudgetweb] " & _
              " (coststrcode,controlno,UserID,actvcode) " & _
              " VALUES " & _
              " ('" & _mcoststrcode & "','" & _mControlNo & "','" & _mUserID & "','" & _mSpecificProgram & "') "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub


    Public Sub _pSubinsertFundingSource()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "

            '20171024
            _mQuery = _
               "INSERT INTO " & _
                "[tempbudgetweb] " & _
                " (userid,coststrcode,controlno,actvcode,ProjCode,FundSourceCode) " & _
                " VALUES " & _
                " ('" & _mUserID & "','" & _mcoststrcode & "','" & _mControlNo & "','" & _mSpecificProgram & "','" & _mProjectcode & "','" & _mFundingSource & "') "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubinsertSPecificActivity()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "

            '20171024

            '_mQuery = _
            ' "INSERT INTO " & _
            '  "[tempbudgetweb] " & _
            '  " (userid,coststrcode,controlno,actvcode,ProjCode,specificcode,specificproj) " & _
            '  " VALUES " & _
            '  " ('" & _mUserID & "','" & _mcoststrcode & "','" & _mControlNo & "','" & _mSpecificProgram & "','" & _mProjectcode & "','" & _mSpecificCode & "','" & _mSpecificProject & "') "
            _mQuery = _
             "INSERT INTO " & _
              "[tempbudgetweb] " & _
              " (userid,coststrcode,controlno,actvcode,ProjCode,specificcode,specificproj) " & _
              " VALUES " & _
              " ('" & _mUserID & "','" & _mcoststrcode & "','" & _mControlNo & "','" & _mSpecificProgram & "','" & _mProjectcode & "','" & _mSpecificCode & "','" & _mSpecificProject & "') "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub



    Public Sub _pSubSelectExistspecificactivity()

        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select specificcode " & _
            "from tempbudgetweb " & _
            "where UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "'  and CoststrCode = '" & _mcoststrcode & "' and actvcode='" & _mSpecificProgram & "' and projcode='" & _mProjectcode & "'  order by SpecificCode desc "


            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count = 0 Then
                _mSpecificCode = "001"
                Exit Sub
            End If
            If IsDBNull(_mDataTable.Rows(0).Item("specificcode")) Then
                _mSpecificCode = "001"
                Exit Sub
            Else
                _mSpecificCode = Val(_mDataTable.Rows(0).Item("specificcode")) + 1
            End If



            Dim _nXCode As String
            Dim _nCode As Integer = 0
            Dim _nValue As String = ""
            Dim _nDigit As Integer = 3
            _nXCode = ""

            _nCode = _mSpecificCode

            _nValue = String.Format("{0:00000000}", _nCode)
            _nValue = _nValue.Substring(Len(_nValue) - _nDigit)
            _mSpecificCode = _nValue



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



    Public Sub _pSubSelectSpecificProgram()

        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select distinct  actvcode,(select description from Activity where code = tempbudgetweb.actvcode) as actvdesc " & _
            "from tempbudgetweb " & _
            "where UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "'  and CoststrCode = '" & _mcoststrcode & "' and isnull(ActvCode,'') <> ''"


            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectGeneralProgram()

        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select distinct (select genprog from activity where code = tempbudgetweb.actvcode) as genprogcode,  " & _
            "(select description from GenProgram where code = (select genprog from activity where code = tempbudgetweb.actvcode)) as genprogdesc  " & _
            "from tempbudgetweb " & _
            "where UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "'   and CoststrCode = '" & _mcoststrcode & "' and isnull(ActvCode,'') <> ''"

            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Project / specific activity"

    Public Sub _pSubSelectProject()

        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            '_nQuery = _
            '        " Select DISTINCT CODE,UACS ,DESCRIPTION " & _
            '        ",(select distinct FundSourceCode  FROM tempbudgetweb P  " & _
            '        " WHERE CONTROLNO = '" & _mControlNo & "' AND COSTSTRCODE = '" & _mcoststrcode & "' AND  " & _
            '        " P.PROJCODE = C.CODE AND P.ACTVCODE = C.PROGCODE and isnull(FundSourceCode,'')<>'') as fundsource " & _
            '        " ,ISNULL(( " & _
            '        " SELECT TOP 1 1 AS SPECIFIC " & _
            '        " FROM tempbudgetweb P  " & _
            '        " WHERE CONTROLNO = '" & _mControlNo & "' AND COSTSTRCODE = '" & _mcoststrcode & "' AND  " & _
            '        " P.PROJCODE = C.CODE AND P.ACTVCODE = C.PROGCODE ),0) AS nStatus  " & _
            '        " FROM COMMITTEEPROJECTACTIVITY C  " & _
            '        " WHERE PROGCODE = '" & _mSpecificProgram & "' AND DEPTCODE = '" & _mDeptCode & "' AND ISNULL(CODE,'') <> ''  " & _
            '        " ORDER BY CODE "

            _nQuery = _
                  " Select DISTINCT CODE,UACS ,DESCRIPTION " & _
                  " ,ISNULL(( " & _
                  " SELECT TOP 1 1 AS SPECIFIC " & _
                  " FROM tempbudgetweb P  " & _
                  " WHERE CONTROLNO = '" & _mControlNo & "' AND COSTSTRCODE = '" & _mcoststrcode & "' AND  " & _
                  " P.PROJCODE = C.CODE AND P.ACTVCODE = C.PROGCODE ),0) AS nStatus  " & _
                  " FROM COMMITTEEPROJECTACTIVITY C  " & _
                  " WHERE PROGCODE = '" & _mSpecificProgram & "' AND DEPTCODE = '" & _mDeptCode & "' AND ISNULL(CODE,'') <> ''  " & _
                  " ORDER BY CODE "




            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubSelectSpecificActivity()

        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "Select DISTINCT SPECIFICPROJ,SPECIFICCODE,AIPCODE " & _
            "FROM tempbudgetweb  " & _
            "WHERE CONTROLNO =  '" & _mControlNo & "'   AND ISNULL(COSTSTRCODE,'') = '" & _mcoststrcode & "'  AND  " & _
            "ISNULL(ACTVCODE,'') = '" & _mSpecificProgram & "'   AND ISNULL(PROJCODE,'') = '" & _mProjectcode & "'   AND  " & _
            "ISNULL(SPECIFICPROJ,'') <> ''  " & _
            "ORDER BY specificcode  "


            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


#End Region
    Public Sub _pSubupdatedata()
        Try

            _mQuery = _
               "UPDATE ppapext " & _
                "Set FundSourceCode='" & _mFundingSource & "',TargetBeneficiary='" & _mTargetBeneficiary & "', " & _
                "ExpectedOutput='" & _mExpectedOutput & "',outputindicator='" & _mOutputIndicator & "' ,SchedFrom='" & _mschedfrom & "',SchedTo='" & _mschedto & "' " & _
                ",Justification='" & _mjustification & "',jan='" & _mjan & "',feb='" & _mfeb & "',Mar='" & _mmar & "',April='" & _mapril & "' " & _
                ",may='" & _mmay & "',Jun='" & _mjun & "',jul='" & _mjul & "',Aug='" & _maug & "',Sep='" & _msep & "',October='" & _moct & "' " & _
                ",Nov='" & _mnov & "',December='" & _mdecember & "', CCTypology='" & _mcctypology & "',Adaptation='" & _madaptation & "',Mitigation='" & _mmitigation & "' " & _
                "where controlno='" & _mControlNo & "' and ExpCode='" & _mEXPcode & "' and ppmp='" & _mPPMP & "' and CoststrCode='" & _mcoststrcode & "' " & _
                " and ActvCode='" & _mSpecificProgram & "' and SpecificCode='" & _mSpecificCode & "' and ProjCode='" & _mProjectcode & "' and specificproj='" & _mSpecificActivity & "'"


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub



    Public Sub _pSubAquiretoweb()
        '20171020

        Try
            _mQuery = _
             "Delete from " & _
              "[tempbudgetweb] " & _
              "WHERE controlno = '" & _mControlNo & "' and UserID = '" & _mUserID & "'  "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            _mQuery = _
            "insert into tempbudgetweb " & _
            "(UserID, ControlNo, AIPCode, SpecificProj, Justification, ExpectedOutput,  " & _
            "OutputIndicator, TargetBeneficiary, CoststrCode, ActvCode, MFOCode, FundSourceCode,  " & _
            "ProjCode, Approve, SpecificCode)  " & _
            "(select UserID = '" & _mUserID & "', ControlNo, AIPCode, SpecificProj, Justification, ExpectedOutput, " & _
            "OutputIndicator, TargetBeneficiary, CoststrCode, ActvCode, MFOCode, FundSourceCode,  " & _
            "ProjCode, Approve, SpecificCode from PPAPEXT where ControlNo = '" & _mControlNo & "') "



            Dim _nSqlCommand2 As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand2.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

End Class
