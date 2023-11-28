

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalPPAP

#Region "Variables Data"
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataSet As DataSet
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
    Private _mRegion As String
    Private _mBoolean As Boolean
    Private _mMaindept As String
    Private _mUserid As String
#End Region

#Region "Properties Field"
    Public Property _puserid As String
        Get
            Return _mUserid
        End Get
        Set(value As String)
            _mUserid = value
        End Set
    End Property
    Public Property _pMaindept As String
        Get
            Return _mMaindept
        End Get
        Set(value As String)
            _mMaindept = value
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

    Public Property _pRegion As String
        Get
            Return _mRegion
        End Get
        Set(value As String)
            _mRegion = value
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
    'Public Sub _pSubAutoIncrement()

    '    'select muna acro sa department tsaka i increment--------------

    '    Dim _nQuery As String = Nothing
    '    Dim _mQuery As String = Nothing
    '    Dim _nWhere As String = Nothing
    '    _nQuery = _
    '       "SELECT " & _
    '       " ACRO  " & _
    '       "FROM [DEPARTMENTS] WHERE FORYEAR = '" & _mForYear & "' AND MAINDEPT = '" & _mDeptCode & "'" & _
    '        " "

    '    Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlCon)
    '    '---------------------------------- 
    '    Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
    '    _mDataSet = New DataSet

    '    _nSqlDataAdapter.Fill(_mDataSet)
    '    If _mDataSet.Rows.Count > 0 Then
    '        If IsDBNull(_mDataSet.Rows(0).Item("ACRO")) Then
    '            _mAcro = ""
    '        Else
    '            _mAcro = _mDataSet.Rows(0).Item("ACRO")
    '        End If
    '    End If

    '    _nSqlDataAdapter.Dispose()



    '    If _mAcro = "" Then
    '        _pControlNo = ""
    '    Else
    '        _mQuery = _
    '      "SELECT " & _
    '      " CONTROLNO  " & _
    '      "FROM [PPAP] " & _
    '       "WHERE SUBSTRING(CONTROLNO,0,LEN(CONTROLNO) - 5) = '" & _mAcro & "'  order by CONTROLNO desc  "

    '        'WHERE CHARINDEX('" & _mAcro & "-',CONTROLNO) <> 0  order by CONTROLNO desc" & _

    '        Dim _nSqlCommand2 As New SqlCommand(_mQuery, _mSqlCon)
    '        '---------------------------------- 
    '        Dim _nSqlDataAdapter2 As New SqlDataAdapter(_nSqlCommand2)
    '        _mDataSet = New DataSet

    '        _nSqlDataAdapter2.Fill(_mDataSet)
    '        If _mDataSet.Rows.Count > 0 Then


    '            If _mDataSet.Rows(0).Item("CONTROLNO") <> "" Then


    '                _mIncrement = Right(Format(Right((_mDataSet.Rows(0).Item("CONTROLNO")), 5) + 1, "0000000000"), 5)
    '                _pControlNo = _mAcro + "-" + _mIncrement
    '            End If
    '        Else
    '            _pControlNo = _mAcro + "-00001"
    '        End If


    '    End If




    'End Sub
    Public Sub _pSubSelect()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing





            _nQuery = _
            "select controlno,foryear,department,RegAcro,Agency,Operatingunit from vw_ppap " & _
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
    Public Sub _pSubSearchblank()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
               "SELECT " & _
               "  ControlNo,ForYear,DeptCode as deptacro,RegCode as regacro ,AgencyCode as agency ,OUCode  as Operatingunit " & _
               "FROM [PPAP] WHERE ControlNo = ''"




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
            "WHERE FORYEAR = '" & _mForYear & "' and deptcode = '" & _mDeptCode & "' and oucode='" & _mOUCode & "'"
            '20171018 need to add oucode for filtering


            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataSet = New DataSet

            _nSqlDataAdapter.Fill(_mDataSet)
            'If _mDataSet.Rows.Count > 0 Then
            '    _mBoolean = True
            'Else
            '    _mBoolean = False
            'End If
        Catch ex As Exception

        End Try



    End Sub


    'not in use ------------------------------------------------------------------------
    'not in use ------------------------------------------------------------------------
    'not in use ------------------------------------------------------------------------
    Public Sub _pSubUpdateRecord()
        'Try

        '    _mQuery = _
        '     "UPDATE " & _
        '      "[BPLTAS_PICTURES] SET " & _
        '      " pic_location = @pic , M_FileType = @extn " & _
        '      "WHERE [ACCTNO] = '" & _mACCTNO & "' "

        '    Dim _nSqlCommand As New SqlCommand(_mQuery, _mSqlCon)
        '    With _nSqlCommand.Parameters
        '        .AddWithValue("@pic", _mpicdata)
        '        .AddWithValue("@extn", _mFileExtn)
        '    End With
        '    '----------------------------------
        '    _nSqlCommand.ExecuteNonQuery()
        '    '----------------------------------
        'Catch ex As Exception
        'End Try
    End Sub
    'Public Sub _pSubfilterloginname()
    '    Try
    '        '----------------------------------
    '        Dim _nQuery As String = Nothing
    '        Dim _nWhere As String = Nothing




    '        _nQuery = _
    '           "SELECT " & _
    '           "loginname " & _
    '           "FROM [sysctrl] WHERE email = '" & _mUserid & "'"




    '        _mQuery = _nQuery & _nWhere


    '        '----------------------------------------
    '        _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
    '        Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
    '        _mDataSet = New DataSet

    '        _nSqlDataAdapter.Fill(_mDataSet)
    '        If _mDataSet.Rows.Count > 0 Then
    '            If IsDBNull(_mDataSet.Rows(0).Item("loginname")) Then
    '                _mEncodedBy = ""
    '            Else
    '                _mEncodedBy = _mDataSet.Rows(0).Item("loginname")
    '            End If
    '        End If

    '        _nSqlDataAdapter.Dispose()



    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub
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
                  "FROM [Departments] "

            If Not String.IsNullOrWhiteSpace(_mMaindept) Then

                _nWhere = " WHERE ETYPE='MAIN' and foryear= '" & _mForYear & "' and maindept='" & _mMaindept & "' "
            Else
                _nWhere = " WHERE ETYPE='MAIN' and foryear= '" & _mForYear & "' "
            End If

            '20171026
            '" WHERE ETYPE='MAIN' and foryear= '" & _mForYear & "' and deptcode='" ?? "' "
            '----------------------------------

            _mSubSelectOffice = _nQuery + _nWhere
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
    Public Sub _pSubSelectDefaultRegion()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
            "select regcode, " & _
            "(select description from region where code = LGUSettings.RegCode) as descr  " & _
            "from LGUSettings where UseRegion='1' "
            '20171025


            _mQuery = _nQuery & _nWhere


            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataSet = New DataSet

            _nSqlDataAdapter.Fill(_mDataSet)

            'If _mDataSet.Count > 0 Then
            '    If IsDBNull(_mDataSet.Rows(0).Item("descr")) Then
            '        _mRegion = ""
            '    Else
            '        _mRegion = _mDataSet.Rows(0).Item("descr")

            '    End If
            'End If




            _nSqlDataAdapter.Dispose()
        Catch ex As Exception

        End Try



    End Sub
#End Region


End Class
