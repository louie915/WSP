
#Region "Imports"
Imports System.Web.HttpContext
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Data
Imports Microsoft.VisualBasic.Devices 'CARL IMPORT
Imports System.IO
Imports System.Drawing


#End Region

Public Class cDalAccountMaintenance

    Inherits System.Web.UI.Page

#Region "Variables Data" ' 10012020
    Private _mSqlConnection As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader
    Private _mAccess As String
    Private _mTag As Boolean
    Private _mLoginName As String
    Dim userkey As String
    Public Shared _mSession As String
    Public Shared _mLogout As Boolean
    Public Shared _mxchangep As String
    Public Shared _mxchangepasskey As String



    Public _key As String ' 10022020
    Public _Passkey As String ' 10022020

#End Region
#Region "Properties Data"
    Public Property _pxchangep() As String
        Get
            Return _mxchangep
        End Get
        Set(ByVal value As String)
            _mxchangep = value
        End Set
    End Property
    Public Property _pxchangepasskey() As String
        Get
            Return _mxchangepasskey
        End Get
        Set(ByVal value As String)
            _mxchangepasskey = value
        End Set
    End Property

    Public Property _pLogout() As Boolean
        Get
            Return _mLogout
        End Get
        Set(ByVal value As Boolean)
            _mLogout = value
        End Set
    End Property
    Public Property _pSession() As String
        Get
            Return _mSession
        End Get
        Set(ByVal value As String)
            _mSession = value
        End Set
    End Property

    Public Property _pTag() As String
        Get
            Return _mTag
        End Get
        Set(ByVal value As String)
            _mTag = value
        End Set
    End Property
    Public Property _pAccess() As String
        Get
            Return _mAccess
        End Get
        Set(ByVal value As String)
            _mAccess = value
        End Set
    End Property
    Public Property _pLoginName() As String
        Get
            Return _mLoginName
        End Get
        Set(ByVal value As String)
            _mLoginName = value
        End Set
    End Property
    Public WriteOnly Property _pSqlConnection() As SqlConnection
        Set(value As SqlConnection)
            _mSqlConnection = value
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
    Public Sub Write(Text, page)
        Try
            page.Response.Write("<script>try{" & Text & "}catch(e){alert(e.message);}</script>")
        Catch ex As Exception
            page.Response.Write("<script>try{alert(" & ex.Message & ");}catch(e){alert(e.message);}")
        End Try
    End Sub

    Public Sub _pSubInsertNewAccount(LoginName, ConfirmPassword, LastName, FirstName, TxtMI, UserLevel, EmailAdd, Department, access, Code, PassKey, ConPassKey)
        Try

            _mkey()
            _mpasskey()
            Dim _nEncryptor As New cEncryption_2
            Dim _nQuery As String = Nothing
            _nQuery = " insert into UserRegistration values('" & LoginName & "','" & System.DateTime.Now & "','" & _key & "', '" & _nEncryptor.Encrypt(ConfirmPassword) & "', '" & LastName & "', '" & FirstName & "', '" & TxtMI & "','', '" & UserLevel & "', '" & EmailAdd & "', '" & Department & "','" & access & "', '" & Code & "', '" & _Passkey & "', '" & _nEncryptor.EncryptPassKey(ConPassKey) & "')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _pSubInsertAccess(LoginName, Access)
        Try
            _mkey()
            Dim _nEncryptor As New cEncryption_2
            Dim _nQuery As String = Nothing
            _nQuery = " insert into UserControl values('" & LoginName & "','" & Access & "')"
            Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Sub _mkey()
        If _mTag = True Then
            cEncryption_2._Pwd = ""
        End If
        Dim s As String = cEncryption_2._Pwd
        If s = "" Then
            s = cEncryption_2._xPwd
        Else
            s = cEncryption_2._Pwd
        End If
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 62
            Dim idx As Integer = r.Next(0, 62)
            sb.Append(s.Substring(idx, 1))
        Next
        _key = sb.ToString
        cEncryption_2._Pwd = _key
    End Sub

    Sub _mpasskey()
        If _mTag = True Then
            cEncryption_2._PKey = ""
        End If
        Dim s As String = cEncryption_2._PKey
        If s = "" Then
            s = cEncryption_2._xPwd
        Else
            s = cEncryption_2._PKey
        End If
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 62
            Dim idx As Integer = r.Next(0, 62)
            sb.Append(s.Substring(idx, 1))
        Next
        _Passkey = sb.ToString
        cEncryption_2._PKey = _Passkey
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
               "exec [SP_SETACCESS] '" & _mAccess & "','" & _mLoginName & "'"

            '----------------------------------    
            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlConnection)

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


    Public Sub _pSubSelectTApplicantOBTO()

        Try

            '----------------------------------


            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing


            '----------------------------------                

            _nQuery = "select* from UserRegistration"
            '----------------------------------

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)

            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon

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
    'Public Sub _pSubSelectAccount(Lname, pwd)

    '    Try


    '        Dim _nQuery As String = Nothing
    '        Dim _nWhere As String = Nothing
    '        Dim _nEncryptor As New cEncryption_2
    '        _nQuery = "select * from UserRegistration where LoginName ='" & Lname & "'"
    '        '----------------------------------
    '        _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
    '        Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
    '        _mDataTable = New DataTable
    '        _nSqlDataAdapter.Fill(_mDataTable)

    '        '----------------------------------
    '        Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
    '            _nSqlDr.Read()
    '            If _nSqlDr.HasRows Then
    '                SSLoginPage.errmsg = False

    '                '_pSubSelectAccountPass(pwd)
    '                cEncryption_2._Pwd = _nSqlDr.Item(2).ToString
    '                userkey = _nEncryptor.Decrypt(_nSqlDr.Item(3).ToString)
    '                If pwd = "" Then
    '                    Exit Sub
    '                End If
    '                If userkey = pwd Then
    '                    SSLoginPage.errmsgpass = False
    '                Else
    '                    SSLoginPage.errmsgpass = True
    '                    SSLoginPage.success = False

    '                End If
    '                _mSession = _nSqlDr.Item(0).ToString
    '                SSLoginPage.success = True
    '                Session.Item("UserLastName") = IIf(_nSqlDr.Item("LastName").ToString = "", "", _nSqlDr.Item("LastName").ToString)
    '                Session.Item("UserFirstName") = IIf(_nSqlDr.Item("FirstName").ToString = "", "", _nSqlDr.Item("FirstName").ToString)
    '                Session.Item("UserMiddleName") = IIf(_nSqlDr.Item("MiddleName").ToString = "", "", _nSqlDr.Item("MiddleName").ToString)
    '                Session.Item("UserPOS") = IIf(_nSqlDr.Item("Department").ToString = "", "", _nSqlDr.Item("Department").ToString)
    '                Session.Item("UserFullName") = IIf(_nSqlDr.Item("LastName").ToString = "", "", _nSqlDr.Item("LastName").ToString) + ", " + IIf(_nSqlDr.Item("FirstName").ToString = "", "", _nSqlDr.Item("FirstName").ToString) + " " + IIf(_nSqlDr.Item("MiddleName").ToString = "", "", _nSqlDr.Item("MiddleName").ToString)
    '            Else
    '                SSLoginPage.errmsg = True
    '                SSLoginPage.errmsgpass = False
    '                Exit Sub
    '            End If
    '        End Using
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Public Sub _pSubSelectPassKey(Lname, pwd)

        Try


            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _nEncryptor As New cEncryption_2
            _nQuery = "select * from Registered where UserID ='" & Lname & "'"
            '----------------------------------
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlConnection) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)

            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    PABusinessPermit.errmsg = False

                    '_pSubSelectAccountPass(pwd)
                    cEncryption_2._Pwd = _nSqlDr.Item(13).ToString
                    userkey = _nEncryptor.Decrypt(_nSqlDr.Item(14).ToString)
                    If pwd = "" Then
                        Exit Sub
                    End If
                    If userkey = pwd Then
                        PABusinessPermit.errmsgpass = False
                    Else
                        PABusinessPermit.errmsgpass = True
                        PABusinessPermit.success = False

                    End If
                    _mSession = _nSqlDr.Item(0).ToString
                    PABusinessPermit.success = True
                    Session.Item("UserLastName") = IIf(_nSqlDr.Item("LastName").ToString = "", "", _nSqlDr.Item("LastName").ToString)
                    Session.Item("UserFirstName") = IIf(_nSqlDr.Item("FirstName").ToString = "", "", _nSqlDr.Item("FirstName").ToString)
                    Session.Item("UserMiddleName") = IIf(_nSqlDr.Item("MiddleName").ToString = "", "", _nSqlDr.Item("MiddleName").ToString)
                    Session.Item("UserPOS") = IIf(_nSqlDr.Item("Department").ToString = "", "", _nSqlDr.Item("Department").ToString)
                    Session.Item("UserFullName") = IIf(_nSqlDr.Item("LastName").ToString = "", "", _nSqlDr.Item("LastName").ToString) + ", " + IIf(_nSqlDr.Item("FirstName").ToString = "", "", _nSqlDr.Item("FirstName").ToString) + " " + IIf(_nSqlDr.Item("MiddleName").ToString = "", "", _nSqlDr.Item("MiddleName").ToString)
                Else
                    PABusinessPermit.errmsg = True
                    PABusinessPermit.errmsgpass = False
                    Exit Sub
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub


    Public Sub _pSubUpdate(LoginName, confirmpass, LastName, FirstName, TxtMI, UserLevel, EmailAdd, Department, access, code, conpasskey)
        Try
            Dim _nQuery As String = Nothing
            Dim _nclass As New cEncryption_2
            If _mxchangep = "no" And _mxchangepasskey = "no" Then
                _nQuery = "update UserRegistration set LastName='" & LastName & "',FirstName='" & FirstName & "',MiddleName='" & TxtMI & "',UserLevel='" & UserLevel & "',Email='" & EmailAdd & "',Department='" & Department & "',SystemAccess='" & access & "' where Code='" & code & "'"
                Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()
                Exit Sub
            End If
            If _mxchangep = "yes" And _mxchangepasskey = "yes" Then
                Dim xpasskey As String = Nothing
                xpasskey = GetString("select UserKey from UserRegistration where LoginName='" & LoginName & "'", _mSqlConnection, 0, "", 1)
                cEncryption_2._PKey = xpasskey
                _nQuery = "update UserRegistration set UserKeySalt='" & _nclass.Encrypt(confirmpass) & "',LastName='" & LastName & "',FirstName='" & FirstName & "',MiddleName='" & TxtMI & "',UserLevel='" & UserLevel & "',Email='" & EmailAdd & "',Department='" & Department & "',SystemAccess='" & access & "' where LoginName='" & LoginName & "'"
                Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()
                Dim xkey As String = Nothing
                xkey = GetString("select UserKey from UserRegistration where LoginName='" & LoginName & "'", _mSqlConnection, 0, "", 1)
                cEncryption_2._Pwd = xkey
                _nQuery = "update UserRegistration set PassKeySalt='" & _nclass.EncryptPassKey(conpasskey) & "',LastName='" & LastName & "',FirstName='" & FirstName & "',MiddleName='" & TxtMI & "',UserLevel='" & UserLevel & "',Email='" & EmailAdd & "',Department='" & Department & "',SystemAccess='" & access & "' where LoginName='" & LoginName & "'"
                _nSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()
                _nQuery = "update UserRegistration set LastName='" & LastName & "',FirstName='" & FirstName & "',MiddleName='" & TxtMI & "',UserLevel='" & UserLevel & "',Email='" & EmailAdd & "',Department='" & Department & "',SystemAccess='" & access & "' where Code='" & code & "'"
                _nSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()
                Exit Sub
            End If
            If _mxchangep = "yes" Then                
                Dim xkey As String = Nothing
                xkey = GetString("select UserKey from UserRegistration where LoginName='" & LoginName & "'", _mSqlConnection, 0, "", 1)
                cEncryption_2._Pwd = xkey
                _nQuery = "update UserRegistration set UserKeySalt='" & _nclass.Encrypt(confirmpass) & "',LastName='" & LastName & "',FirstName='" & FirstName & "',MiddleName='" & TxtMI & "',UserLevel='" & UserLevel & "',Email='" & EmailAdd & "',Department='" & Department & "',SystemAccess='" & access & "' where LoginName='" & LoginName & "'"
                Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()
                _nQuery = "update UserRegistration set LastName='" & LastName & "',FirstName='" & FirstName & "',MiddleName='" & TxtMI & "',UserLevel='" & UserLevel & "',Email='" & EmailAdd & "',Department='" & Department & "',SystemAccess='" & access & "' where Code='" & code & "'"
                _nSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()
                Exit Sub
            End If
            If _mxchangepasskey = "yes" Then
                Dim xpasskey As String = Nothing
                xpasskey = GetString("select UserKey from UserRegistration where LoginName='" & LoginName & "'", _mSqlConnection, 0, "", 1)
                cEncryption_2._PKey = xpasskey
                _nQuery = "update UserRegistration set PassKeySalt='" & _nclass.EncryptPassKey(conpasskey) & "',LastName='" & LastName & "',FirstName='" & FirstName & "',MiddleName='" & TxtMI & "',UserLevel='" & UserLevel & "',Email='" & EmailAdd & "',Department='" & Department & "',SystemAccess='" & access & "' where LoginName='" & LoginName & "'"
                Dim _nSqlCommand As New SqlCommand(_nQuery, _mSqlConnection)
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()
                _nQuery = "update UserRegistration set LastName='" & LastName & "',FirstName='" & FirstName & "',MiddleName='" & TxtMI & "',UserLevel='" & UserLevel & "',Email='" & EmailAdd & "',Department='" & Department & "',SystemAccess='" & access & "' where Code='" & code & "'"
                _nSqlCommand = New SqlCommand(_nQuery, _mSqlConnection)
                _nSqlCommand.ExecuteNonQuery()
                _nSqlCommand.Dispose()
                Exit Sub
            End If

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

End Class
