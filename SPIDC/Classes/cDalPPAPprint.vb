

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods


#End Region

Public Class cDalPPAPprint

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
    Private _mPlanning As String
    Private _mMayor As String
    Private _mprepared As String
#End Region

#Region "Properties Field"
    Public Property _pprepared As String
        Get
            Return _mprepared
        End Get
        Set(value As String)
            _mprepared = value
        End Set
    End Property
    Public Property _pMayor As String
        Get
            Return _mMayor
        End Get
        Set(value As String)
            _mMayor = value
        End Set
    End Property
    Public Property _pplanning As String
        Get
            Return _mPlanning
        End Get
        Set(value As String)
            _mPlanning = value
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
    Public Sub _pSubppapprint()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
               "SELECT * FROM [dbo].[PPAP_REPORT]('" & _mForYear & "','" & _mControlNo & "')   " & _
               "  ORDER BY COSTSTRCODE,ACTVCODE,MFOCODE,PROJCODE,AIPCODE,SPECIFICPROJ"




            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            '---------------------------------- 


            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub

    Public Sub _pSubppapsignatories()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
               "select Planning,govpos,Governor,planpos from SignatorySetup"





            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            '---------------------------------- 

            '---------------------------------- 
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("Planning")) Then
                    _mPlanning = ""
                Else
                    _mPlanning = _mDataTable.Rows(0).Item("Planning").ToString
                End If
                If IsDBNull(_mDataTable.Rows(0).Item("Governor")) Then
                    _mMayor = ""
                Else
                    _mMayor = _mDataTable.Rows(0).Item("Governor").ToString
                End If
            End If

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
    Public Sub _pSubppappreparedby()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing




            _nQuery = _
               "select (select (fname+ ' ' +LName) from SysCtrl where LoginName=SubmittedBy) as fullname,SubmittedBy from ppap where ControlNo = '" & _mControlNo & "'"





            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)

            '---------------------------------- 

            '---------------------------------- 
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            _mDataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)
            If _mDataTable.Rows.Count > 0 Then
                If IsDBNull(_mDataTable.Rows(0).Item("fullname")) Then
                    _mprepared = ""
                Else
                    _mprepared = _mDataTable.Rows(0).Item("fullname").ToString
                End If

            End If

            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
#End Region
End Class
