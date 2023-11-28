

#Region "Imports"

Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports Aris_Dll


#End Region

Public Class cDalBPCheckAuthentication

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

    Dim _mAris As New Aris

    Private Const _mCryptPass As String = "BplT@$"
    Private Const _mOldCryptPass As String = "ArisAbion"
    Private _mLoginname As String
    Private _mPassword As String
    Private _mUSAGES As String 'Level
    Private _mOffice As String 'Office Switch
    Private _MtESTING As String


#End Region

#Region "Properties Field"
    Public Property _pLoginname() As String
        Get
            Return _mLoginname
        End Get
        Set(ByVal value As String)
            _mLoginname = value
        End Set
    End Property
    'Public ReadOnly Property _pOffice() As String
    '    Get
    '        Dim _nResult As String = ""
    '        _pSubDecrypt(_mOffice, _nResult)
    '        Return _nResult
    '    End Get

    'End Property
    Public Property _pOffice() As String
        Get
            Return _mOffice
        End Get
        Set(value As String)
            _mOffice = value
        End Set
    End Property
    Public ReadOnly Property _pUSAGES() As String
        Get
            Dim _nResult As String = ""
            _pSubDecrypt(_mUSAGES, _nResult)
            Return _nResult
        End Get

    End Property
    'Public ReadOnly Property _pPassword() As String
    '    Get
    '        Dim _nResult As String = ""
    '        _pSubDecrypt(_mPassword, _nResult, True)
    '        Return _nResult
    '    End Get

    'End Property
    Public Property _pPassword() As String
        Get
            Return _mPassword
        End Get
        Set(value As String)
            _mPassword = value
        End Set
    End Property
    Public Property _PTesting() As String
        Get
            Return _MtESTING
        End Get
        Set(value As String)
            _MtESTING = value
        End Set
    End Property

#End Region

#Region "Routine Command"


    Public Sub _pSubDecrypt(ByVal _nValue As String, ByRef _nResult As String, Optional IsPassword As Boolean = False)
        If _nValue = "" Then _nResult = "" : Exit Sub
        If IsPassword Then
            Dim _nBPLen As Integer
            Dim _nBPPW As String
            _nBPPW = _mAris.DecryptData(_nValue, _mCryptPass)
            _nBPLen = Len("BPLTAS" & _mLoginname)

            _nResult = _nBPPW.Substring(_nBPLen)
        Else
            _nResult = _mAris.DecryptData(_nValue, _mOldCryptPass)
        End If

    End Sub
    Public Sub _pSubEncrypt()

    End Sub
    Public Sub _pSubSelect()
        Try
            '----------------------------------
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            '----------------------------------
            _nQuery = _
               "Select LoginName, " & _
                "webpassword, weboffice, [STATUS], " & _
                "WebEmailAdd, WebUser " & _
                "from SYSCTRL " & _
                "where loginname = '" & _mLoginname & "'"

            '----------------------------------
            _mQuery = _nQuery

            '----------------------------------
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)

            'Dim _nDR As SqlDataReader = _mSqlCommand.ExecuteReader
            'If _nDR.HasRows Then
            '    Do While _nDR.Read
            '        _MtESTING = _nDR.Item("PW").ToString
            '            '_mPassword = _nDR.Item("PW").ToString
            '        _mPassword = _nDR.Item("webpassword").ToString
            '        _mUSAGES = _nDR.Item("USAGES").ToString
            '            '_mOffice = _nDR.Item("SWITCH").ToString
            '        _mOffice = _nDR.Item("weboffice").ToString
            '    Loop
            'Else
            '    _mPassword = ""
            '    _mUSAGES = ""
            '    _mOffice = ""
            '    End If
            '_nDR.Close()


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub



#End Region

End Class
