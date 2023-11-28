

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalPPAPActivity

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
    Private _mControlNo As String
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
    Private _mUserID As String
    Private _mcoststrcode As String
    Private _mProjectcode As String
    Private _mSpecificProgram As String
    Private _mFundingSource As String
    Private _mSpecificProject As String
    Private _mSpecificCode As String
    Private _mBoolean As Boolean
    Private _mBoolean2 As Boolean
    Private _mAIPCode As String
    Private _mAIPSubSecCode As String
    Private _mAIPLGUlvl As String
    Private _mAIPDept As String
    Private _mMFOCODE As String
    Private _mCondition As String
    Private _mdeptgrp As String
    Private _mcomment As String
    Private _mloginname As String
#End Region

#Region "Properties Field"
    Public Property _ploginname As String
        Get
            Return _mloginname
        End Get
        Set(value As String)
            _mloginname = value
        End Set
    End Property
    Public Property _pcomment As String
        Get
            Return _mcomment
        End Get
        Set(value As String)
            _mcomment = value
        End Set
    End Property
    Public Property _pdeptgrp As String
        Get
            Return _mdeptgrp
        End Get
        Set(value As String)
            _mdeptgrp = value
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
    Public Property _pBoolean2 As Boolean
        Get
            Return _mBoolean2
        End Get
        Set(value As Boolean)
            _mBoolean2 = value
        End Set
    End Property
    Public Property _pCondition As String
        Get
            Return _mCondition
        End Get
        Set(value As String)
            _mCondition = value
        End Set
    End Property
    Public Property _pMFOCODE As String
        Get
            Return _mMFOCODE
        End Get
        Set(value As String)
            _mMFOCODE = value
        End Set
    End Property
    Public Property _pAIPdept As String
        Get
            Return _mAIPDept
        End Get
        Set(value As String)
            _mAIPDept = value
        End Set
    End Property
    Public Property _pAIPLGUlvl As String
        Get
            Return _mAIPLGUlvl
        End Get
        Set(value As String)
            _mAIPLGUlvl = value
        End Set
    End Property
    Public Property _pAIPCode As String
        Get
            Return _mAIPCode
        End Get
        Set(value As String)
            _mAIPCode = value
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

    Public Sub _pSubfilterdeptgrp()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
               "SELECT " & _
               "deptgrp,deptcode " & _
               "FROM [sysctrl] WHERE email = '" & _mUserID & "'"




            _mQuery = _nQuery & _nWhere


            '----------------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("deptcode")) Then
                    _mDeptCode = ""
                Else
                    _mDeptCode = _mDataTable.Rows(0).Item("deptcode")
                End If
                If IsDBNull(_mDataTable.Rows(0).Item("deptgrp")) Then
                    _mdeptgrp = ""
                Else
                    _mdeptgrp = _mDataTable.Rows(0).Item("deptgrp")
                End If
            End If

            _nSqlDataAdapter.Dispose()


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubSelect()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select okprint_sw,comment_sw,cpdocomment,SubmittedBy,cpdo,ApprovedBy,controlno,foryear,department,RegAcro,Agency,Operatingunit,DeptCode, (select lgulvl from LGUSettings where regcode=vw_ppap.regcode ) as lgulvl,deptuacs" & _
            " from vw_ppap " & _
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

    Public Sub _pSubIfinlikedetailssubmit()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "	select SubmittedBy from ppap where SubmittedBy = '" & _mloginname & "' and controlno='" & _mControlNo & "'" & _
            ""



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("SubmittedBy")) Then
                    _mCondition = "1"
                Else
                    _mCondition = "1"
                End If




            Else
                _mCondition = "3"
            End If
        Catch ex As Exception

        End Try



    End Sub
    Public Sub _pSubbtnoktoprint()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            '20171213

            _nQuery = _
            "	select okprint_sw from ppap where controlno='" & _mControlNo & "'" & _
            ""



            _mQuery = _nQuery


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("okprint_sw")) Then
                    _mBoolean = False
                ElseIf _mDataTable.Rows(0).Item("okprint_sw").ToString = True Then
                    _mBoolean = True
                Else
                    _mBoolean = False
                End If
            Else
                _mBoolean = False
            End If
        Catch ex As Exception

        End Try



    End Sub
    Public Sub _pSubIfinlikedetailsreview()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "	select cpdo from ppap where cpdo = '" & _mloginname & "' and controlno='" & _mControlNo & "'" & _
            ""



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("cpdo")) Then
                    _mCondition = "1"
                Else
                    _mCondition = "1"
                End If




            Else
                _mCondition = "3"
            End If
        Catch ex As Exception

        End Try



    End Sub
    Public Sub _pSubIfinlikedetailsapprove()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "	select approvedby from ppap where approvedby = '" & _mloginname & "' and controlno='" & _mControlNo & "'" & _
            ""



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("approvedby")) Then
                    _mCondition = "1"
                Else
                    _mCondition = "1"
                End If




            Else
                _mCondition = "3"
            End If
        Catch ex As Exception

        End Try



    End Sub
    Public Sub _pSubIfExistdetails()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select * from tempbudgetweb " & _
            "WHERE controlno = '" & _mControlNo & "' "



            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)


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
    Public Sub _pSubremoveCostStructure()
        Try

            _mQuery = _
                "delete " & _
                "[tempbudgetweb] " & _
                "where  coststrcode='" & _mCode & "' and " & _
                "controlno='" & _mControlNo & "' " & _
                "delete " & _
                "[tempPPAPEXT] " & _
                "where  coststrcode='" & _mCode & "' and " & _
                "controlno='" & _mControlNo & "' "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubremoveSpecificprogram()
        Try

            _mQuery = _
                "delete " & _
                "[tempbudgetweb] " & _
                "where  coststrcode='" & _mCode & "' and " & _
                "controlno='" & _mControlNo & "' and actvcode='" & _mSpecificProgram & "'" & _
                "delete " & _
                "[tempPPAPEXT] " & _
                "where  coststrcode='" & _mCode & "' and " & _
                "controlno='" & _mControlNo & "' and actvcode='" & _mSpecificProgram & "' "

            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubremoveSpecificactivity()
        Try

            _mQuery = _
                "delete " & _
                "[tempbudgetweb] " & _
                "where  coststrcode='" & _mCode & "' and " & _
                "controlno='" & _mControlNo & "' and actvcode='" & _mSpecificProgram & "'" & _
                 "and projcode='" & _mProjectcode & "' and specificcode='" & _mSpecificProject & "'  " & _
                "delete " & _
                "[tempPPAPEXT] " & _
                "where  coststrcode='" & _mCode & "' and " & _
                "controlno='" & _mControlNo & "' and actvcode='" & _mSpecificProgram & "' " & _
                "and projcode='" & _mProjectcode & "' and specificcode='" & _mSpecificProject & "'  "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _mSubCountcoststructure()
        Try

            _mQuery = _
                "Select distinct CoststrCode from " & _
                "[PPAPEXT] " & _
                "where   " & _
                "controlno='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 1 Then
                _mBoolean = False
            Else
                _mBoolean = True
            End If
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _mSubActivedit()
        Try

            _mQuery = _
                "select * from tempppapactiveedit " & _
                "where controlno='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 1 Then
                _mBoolean = True
                _mUserID = _mDataTable.Rows(0).Item("email").ToString
            Else
                _mBoolean = False
            End If
            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _mSubCountSpecificprogram()
        Try

            _mQuery = _
                "Select distinct ActvCode from " & _
                "[tempbudgetweb] " & _
                "where   " & _
                "controlno='" & _mControlNo & "' and CoststrCode='" & _mcoststrcode & "' and isnull(actvcode,'')<>'' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 1 Then
                _mBoolean = False
            Else
                _mBoolean = True
            End If
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
    Public Function _mSubSelectcctypology() As String
        Try
            _mSubSelectcctypology = Nothing
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nWhere1 As String = Nothing
            Dim _nOrderBy As String = Nothing
            '----------------------------------    
            _nQuery = _
                  "SELECT " & _
                  "* " & _
                  "FROM [Typology] " & _
                   " "


            '----------------------------------

            _mSubSelectcctypology = _nQuery
            '----------------------------------
        Catch ex As Exception
            _mSubSelectcctypology = Nothing
        End Try

    End Function
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
    Public Sub _pSubfilterloginname()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
               "SELECT " & _
               "loginname " & _
               "FROM [sysctrl] WHERE email = '" & _mUserID & "'"




            _mQuery = _nQuery & _nWhere


            '----------------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("loginname")) Then
                    _mloginname = ""
                Else
                    _mloginname = _mDataTable.Rows(0).Item("loginname")
                End If
            End If

            _nSqlDataAdapter.Dispose()



            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubsavecomment()
        Try

            Dim dte As Date = Now.Date

            _mQuery = _
            "UPDATE " & _
            "[PPAP] " & _
            "set CPDOComment= '" & _mcomment & "' , Comment_sw = '" & _mBoolean & "', CPDOComment_Encoder='" & _mloginname & "',OkPrint_sw='" & _mBoolean2 & "' " & _
            " where controlno ='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubsaveoktoprint()
        Try

            Dim dte As Date = Now.Date

            _mQuery = _
            "UPDATE " & _
            "[PPAP] " & _
            "set OkPrint_sw='" & _mBoolean2 & "' " & _
            " where controlno ='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _pSubupdatedissubmit()
        Try

            Dim dte As Date = Now.Date

            _mQuery = _
             "UPDATE " & _
              "[PPAP] " & _
              "set datesubmitted= null , submittedby = null " & _
              " where controlno ='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubupdateSubmit()
        Try

            Dim dte As Date = Now.Date

            _mQuery = _
             "UPDATE " & _
              "[PPAP] " & _
              "set datesubmitted='" & dte & "' , submittedby ='" & _mloginname & "' " & _
              " where controlno ='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubupdatedisreview()
        Try

            Dim dte As Date = Now.Date

            _mQuery = _
             "UPDATE " & _
              "[PPAP] " & _
              "set datereviewed= null , CPDO = null " & _
              " where controlno ='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubupdatereview()
        Try

            Dim dte As Date = Now.Date

            _mQuery = _
             "UPDATE " & _
              "[PPAP] " & _
              "set datereviewed='" & dte & "' , CPDO ='" & _mloginname & "' " & _
              " where controlno ='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubupdatedisapproved()
        Try

            Dim dte As Date = Now.Date

            _mQuery = _
             "UPDATE " & _
              "[PPAP] " & _
              "set dateApproved= null , approvedby = null " & _
              " where controlno ='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubupdateapproved()
        Try

            Dim dte As Date = Now.Date

            _mQuery = _
             "UPDATE " & _
              "[PPAP] " & _
              "set dateApproved='" & dte & "' , approvedby ='" & _mloginname & "' " & _
              " where controlno ='" & _mControlNo & "' "


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
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
    Public Sub _pSubActivateedit()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "
            Dim dateac As Date = Date.Now
            _mQuery = _
             "INSERT INTO " & _
              "[tempppapactiveedit] " & _
              " (controlno,email,dateedit) values ('" & _mControlNo & "','" & _mUserID & "','" & dateac & "')"


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubaquireppapexptoweb()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "
            Dim dateac As Date = Date.Now
            _mQuery = _
                "insert into tempPPAPEXT (ControlNo, AIPCode, SpecificProj, Justification, " & _
                "ExpCode, PPMP, Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep,  " & _
                "October, Nov, December, CCTypology, Adaptation, Mitigation,  " & _
                "ExpectedOutput, OutputIndicator, TargetBeneficiary, CoststrCode, " & _
                "ActvCode, MFOCode, FundSourceCode, ProjCode, Approve, SpecificCode, " & _
                "SchedFrom,  " & _
                "SchedTo) " & _
                "(SELECT    ControlNo, AIPCode, SpecificProj, Justification,  " & _
                "ExpCode, PPMP, Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep,  " & _
                "October, Nov, December, CCTypology, Adaptation, Mitigation,  " & _
                "ExpectedOutput, OutputIndicator, TargetBeneficiary, CoststrCode, " & _
                "ActvCode, MFOCode, FundSourceCode, ProjCode, Approve, SpecificCode, " & _
                "SchedFrom,  " & _
                "SchedTo " & _
                "FROM   PPAPEXT  where ControlNo='" & _pControlNo & "')"


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubaquireppapexpmain()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "
            Dim dateac As Date = Date.Now
            _mQuery = _
                "insert into PPAPEXT (ControlNo, AIPCode, SpecificProj, Justification, " & _
                "ExpCode, PPMP, Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep,  " & _
                "October, Nov, December, CCTypology, Adaptation, Mitigation,  " & _
                "ExpectedOutput, OutputIndicator, TargetBeneficiary, CoststrCode, " & _
                "ActvCode, MFOCode, FundSourceCode, ProjCode, Approve, SpecificCode, " & _
                "SchedFrom,  " & _
                "SchedTo) " & _
                "(SELECT    ControlNo, AIPCode, SpecificProj, Justification,  " & _
                "ExpCode, PPMP, Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep,  " & _
                "October, Nov, December, CCTypology, Adaptation, Mitigation,  " & _
                "ExpectedOutput, OutputIndicator, TargetBeneficiary, CoststrCode, " & _
                "ActvCode, MFOCode, FundSourceCode, ProjCode, Approve, SpecificCode, " & _
                "SchedFrom,  " & _
                "SchedTo " & _
                "FROM   tempPPAPEXT  where ControlNo='" & _pControlNo & "')"


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubdeleteppapexttoweb()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "
            Dim dateac As Date = Date.Now
            _mQuery = _
             "delete from tempPPAPEXT where controlno='" & _mControlNo & "'"


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubdeleteppapextmain()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "
            Dim dateac As Date = Date.Now
            _mQuery = _
             "delete from PPAPEXT where controlno='" & _mControlNo & "'"


            Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub
    Public Sub _pSubdeleteActiveedit()
        Try

            '_mQuery = _
            '"update tempbudgetweb " & _
            '"set ActvCode = '" & _mSpecificProgram & "'  " & _
            '"where  UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "' and coststrcode = '" & _mcoststrcode & "' "

            _mQuery = _
             "delete from tempppapactiveedit where controlno='" & _mControlNo & "'"


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
            Dim datefrom As String
            Dim dateto As String
            datefrom = "1/1/" + _mForYear
            dateto = "12/31/" + _mForYear
            _mQuery = _
                "INSERT INTO [tempPPAPEXT] " & _
                "([ControlNo],[AIPCode],[SpecificProj],[SpecificCode],[ExpCode],[PPMP],  " & _
                "[Jan],[Feb],[Mar],[April],[May],[Jun],[Jul],[Aug],[Sep],[October],[Nov],[December], " & _
                "[Adaptation],[Mitigation] ,[CoststrCode],[ActvCode],[MFOCode],[FundSourceCode],[ProjCode], " & _
                "[Approve],SchedFrom,SchedTo)  " & _
                "values " & _
                "('" & _mControlNo & "','" & _mAIPCode & "','" & _mSpecificProject & "','" & _mSpecificCode & "','PS',0, " & _
                "0,0,0,0,0,0,0,0,0,0,0,0, " & _
                "0,0,'" & _mcoststrcode & "','" & _mSpecificProgram & "','" & _mMFOCODE & "','','" & _mProjectcode & "', " & _
                "0,'" & datefrom & "','" & dateto & "') " & _
                ", " & _
                "('" & _mControlNo & "','" & _mAIPCode & "','" & _mSpecificProject & "','" & _mSpecificCode & "','CO',0, " & _
                "0,0,0,0,0,0,0,0,0,0,0,0, " & _
                "0,0,'" & _mcoststrcode & "','" & _mSpecificProgram & "','" & _mMFOCODE & "','','" & _mProjectcode & "', " & _
                "0,'" & datefrom & "','" & dateto & "') " & _
                ", " & _
                "('" & _mControlNo & "','" & _mAIPCode & "','" & _mSpecificProject & "','" & _mSpecificCode & "','MOOE',0, " & _
                "0,0,0,0,0,0,0,0,0,0,0,0, " & _
                "0,0,'" & _mcoststrcode & "','" & _mSpecificProgram & "','" & _mMFOCODE & "','','" & _mProjectcode & "', " & _
                "0,'" & datefrom & "','" & dateto & "') " & _
                ", " & _
                "('" & _mControlNo & "','" & _mAIPCode & "','" & _mSpecificProject & "','" & _mSpecificCode & "','MOOE',1, " & _
                "0,0,0,0,0,0,0,0,0,0,0,0, " & _
                "0,0,'" & _mcoststrcode & "','" & _mSpecificProgram & "','" & _mMFOCODE & "','','" & _mProjectcode & "', " & _
                "0,'" & datefrom & "','" & dateto & "') " & _
                " " & _
                "" & _
                "INSERT INTO [tempbudgetweb] " & _
                "(UserID, ControlNo, AIPCode, SpecificProj,  " & _
                "CoststrCode, ActvCode, " & _
                "MFOCode, FundSourceCode, ProjCode, Approve, SpecificCode) " & _
                "Values " & _
                "('" & _mUserID & "','" & _mControlNo & "','" & _mAIPCode & "','" & _mSpecificProject & "','" & _mcoststrcode & "', " & _
                "'" & _mSpecificProgram & "','" & _mMFOCODE & "','','" & _mProjectcode & "','0','" & _mSpecificCode & "') "

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




            '20171102
            _nQuery = _
            "select specificcode,(select subseccode from activity where code=tempbudgetweb.actvcode) " & _
            "from tempbudgetweb " & _
            "where UserId= '" & _mUserID & "' and controlno = '" & _mControlNo & "'  and CoststrCode = '" & _mcoststrcode & "' and actvcode='" & _mSpecificProgram & "' and projcode='" & _mProjectcode & "'  order by SpecificCode desc "


            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count = 0 Then
                _mSpecificCode = "001"


            ElseIf IsDBNull(_mDataTable.Rows(0).Item("specificcode")) Then
                _mSpecificCode = "001"

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




            _mQuery = _
           "select SubSecCode,MFOCODE " & _
           "from activity " & _
           "where code='" & _mSpecificProgram & "' "



            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            Dim _nSqlDataAdapter2 As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter2.Fill(_mDataTable)


            _mAIPSubSecCode = _mDataTable.Rows(0).Item("subseccode").ToString
            _mMFOCODE = _mDataTable.Rows(0).Item("MFOCODE").ToString






            '20171102
            _mAIPCode = _mAIPSubSecCode + "-" + _mAIPLGUlvl + "-" + _mAIPDept + "-" + _mSpecificProgram + "-" + _mProjectcode + "-" + _mSpecificCode


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
            "select distinct actvcode,(select description from Activity where code = tempbudgetweb.actvcode) as actvdesc " & _
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
            "ISNULL(SPECIFICPROJ,'') <> ''  and userid='" & _mUserID & "' " & _
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



    '20171027
    'Public Sub _pSubinserttoPPAPEXT()
    '    Try

    '        _mQuery = _
    '          "INSERT INTO " & _
    '           "[tempbudgetweb] " & _
    '           " (webuser,coststrcode,controlno,actvcode,ProjCode,specificcode,specificproj) " & _
    '           " VALUES " & _
    '           " ('" & _mUserID & "','" & _mcoststrcode & "','" & _mControlNo & "','" & _mSpecificProgram & "','" & _mProjectcode & "','" & _mSpecificCode & "','" & _mSpecificProject & "') "

    '        Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
    '        _nSqlCommand.ExecuteNonQuery()

    '        '----------------------------------
    '    Catch ex As Exception
    '    End Try
    'End Sub

#End Region




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
