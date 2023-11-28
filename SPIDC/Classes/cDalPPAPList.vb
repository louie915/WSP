

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalPPAPList

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
    Private _mUserID As String
    Private _mControlNo As String
    Private _mForYear As String
    Private _mDeptCode As String
    Private _mRegCode As String
    Private _mAgencyCode As String
    Private _mOUCode As String
    Private _mTier As String
    Private _mDateEncoded As Date
    Private _mEncodedBy As String
    Private _mdeptgrp As String


#End Region

#Region "Properties Field"

    Public Property _pdeptgrp As String
        Get
            Return _mdeptgrp
        End Get
        Set(value As String)
            _mdeptgrp = value
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
    Public Property _pUserID As String
        Get
            Return _mUserID
        End Get
        Set(value As String)
            _mUserID = value
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

#Region "Properties Field Original"

#End Region

#Region "Routine Command"


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
            If _mUserID = Nothing Then
                _mdeptgrp = ""
            End If
            _nSqlDataAdapter.Dispose()


            With _mSqlCommand.Parameters
                If Not String.IsNullOrWhiteSpace(_mfieldsWhere) Then .AddWithValue("@_mfieldsWhere", _mfieldsWhere)

            End With

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubfilterencoder()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            _nQuery = _
                "select   ControlNo,ForYear,department as deptacro,regacro as regacro ,agency as agency ,Operatingunit  as Operatingunit  " & _
                "from vw_ppap where " & _
                " DeptCode = '" & _mDeptCode & "' "


            _mQuery = _nQuery & _nWhere


            '----------------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubfilterReviewer()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            _nQuery = _
              "select   ControlNo,ForYear,department as deptacro,regacro as regacro ,agency as agency ,Operatingunit  as Operatingunit " & _
              "from vw_ppap where isnull(SubmittedBy,'') <> '' " & _
              " and isnull(ApprovedBy,'')=''"


            _mQuery = _nQuery & _nWhere


            '----------------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubfilterapprover()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            _nQuery = _
               "select   ControlNo,ForYear,DeptCode as deptacro,RegCode as regacro ,AgencyCode as agency ,OUCode  as Operatingunit  " & _
               "from vw_ppap where isnull(SubmittedBy,'') <> ''   " & _
               "and isnull(cpdo,'')<>'' "


            _mQuery = _nQuery & _nWhere


            '----------------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubfilterencodersearch()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            _nQuery = _
                "select   ControlNo,ForYear,department as deptacro,regacro as regacro ,agency as agency ,Operatingunit  as Operatingunit  from vw_ppap where isnull(cpdo,'')='' " & _
                "and isnull(ApprovedBy,'')='' and DeptCode = '" & _mDeptCode & "' and  " & _mfields & " LIKE '%" & _mfieldsWhere & "%' "


            _mQuery = _nQuery & _nWhere


            '----------------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubfilterReviewersearch()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            _nQuery = _
              "select   ControlNo,ForYear,department as deptacro,regacro as regacro ,agency as agency ,Operatingunit  as Operatingunit  from vw_ppap where isnull(SubmittedBy,'') <> '' " & _
" and isnull(ApprovedBy,'')='' and  " & _mfields & " LIKE '%" & _mfieldsWhere & "%' "


            _mQuery = _nQuery & _nWhere


            '----------------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubfilterapproversearch()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing



            _nQuery = _
               "select   ControlNo,ForYear,department as deptacro,regacro as regacro ,agency as agency ,Operatingunit  as Operatingunit  from vw_ppap where isnull(SubmittedBy,'') <> ''   " & _
"and isnull(cpdo,'')<>'' and  " & _mfields & " LIKE '%" & _mfieldsWhere & "%'  "


            _mQuery = _nQuery & _nWhere


            '----------------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

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
            "WHERE " & _mfields & " LIKE '%" & _mfieldsWhere & "%'  and deptcode='" & _mDeptCode & "'"



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


#End Region
End Class
