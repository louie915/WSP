

#Region "Imports"

Imports System.Web
Imports System.Web.HttpContext

#End Region

Public Class cCookieUser

#Region "Variables"

    '_ssc = Session String Constant
    Private Const _sscPrefix As String = "cCookieUser."

    Private Const _sscIDNo As String = _sscPrefix & "_sscIDNo"
    Private Const _sscUserID As String = _sscPrefix & "_sscUserID"
    Private Const _sscKeyToken As String = _sscPrefix & "_sscKeyToken"
    Private Const _sscClearText As String = _sscPrefix & "_sscClearText"
    Private Const _sscReviewMode As String = _sscPrefix & "_sscReviewMode"
    Private Const _sscEmailAdd As String = _sscPrefix & "_sscEmailAdd" '@ Added 20180118
    Private Const _sscUserType As String = _sscPrefix & "_sscUserType" '@ Added 20180703
    Private Const _sscLGUName As String = _sscPrefix & "_sscLGUName" '@ Added 20180829
#End Region

#Region "Properties"
    Shared Property _pIDNo() As String
        Get
            Return Current.Request.Cookies(_sscIDNo).Value
        End Get
        Set(ByVal value As String)
            Dim _nCookie As HttpCookie
            _nCookie = New HttpCookie(_sscIDNo)
            _nCookie.Value = value
            Current.Response.Cookies.Add(_nCookie)
        End Set
    End Property
    Shared Property _pUserID() As String
        Get
            Return Current.Request.Cookies(_sscUserID).Value
        End Get
        Set(ByVal value As String)
            Dim _nCookie As HttpCookie
            _nCookie = New HttpCookie(_sscUserID)
            _nCookie.Value = value
            Current.Response.Cookies.Add(_nCookie)
        End Set
    End Property

    Shared Property _pKeyToken() As String
        Get
            Return Current.Request.Cookies(_sscKeyToken).Value
        End Get
        Set(ByVal value As String)
            Dim _nCookie As HttpCookie
            _nCookie = New HttpCookie(_sscKeyToken)
            _nCookie.Value = value
            Current.Response.Cookies.Add(_nCookie)
        End Set
    End Property

    Shared Property _pClearText() As String
        Get
            Return Current.Request.Cookies(_sscClearText).Value
        End Get
        Set(ByVal value As String)
            Dim _nCookie As HttpCookie
            _nCookie = New HttpCookie(_sscClearText)
            _nCookie.Value = value
            Current.Response.Cookies.Add(_nCookie)
        End Set
    End Property

    Shared Property _pReviewMode() As Boolean
        Get
            Return Current.Request.Cookies(_sscReviewMode).Value
        End Get
        Set(ByVal value As Boolean)
            Dim _nCookie As HttpCookie
            _nCookie = New HttpCookie(_sscReviewMode)
            _nCookie.Value = value
            Current.Response.Cookies.Add(_nCookie)
        End Set
    End Property

    Shared Property _pEmailAdd() As String  '@ Added 20180118
        Get
            Return Current.Request.Cookies(_sscEmailAdd).Value
        End Get
        Set(ByVal value As String)
            Dim _nCookie As HttpCookie
            _nCookie = New HttpCookie(_sscEmailAdd)
            _nCookie.Value = value
            Current.Response.Cookies.Add(_nCookie)
        End Set
    End Property

    Shared Property _pUserType() As String  '@ Added 20180703
        Get
            Return Current.Request.Cookies(_sscUserType).Value
        End Get
        Set(ByVal value As String)
            Dim _nCookie As HttpCookie
            _nCookie = New HttpCookie(_sscUserType)
            _nCookie.Value = value
            Current.Response.Cookies.Add(_nCookie)
        End Set
    End Property


    Shared Property _pLGUName() As String  '@ Added 20180829
        Get
            Return Current.Request.Cookies(_sscLGUName).Value
        End Get
        Set(ByVal value As String)
            Dim _nCookie As HttpCookie
            _nCookie = New HttpCookie(_sscLGUName)
            _nCookie.Value = value
            Current.Response.Cookies.Add(_nCookie)
        End Set
    End Property

#End Region

#Region "Routines"
    Public Shared Sub _pSubCookieClear()
        Try
            '----------------------------------
            _pIDNo = Nothing
            _pUserID = Nothing
            _pKeyToken = Nothing

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub _pSubPassSessionToCookie()
        Try
            '----------------------------------
            _pSubCookieClear()
            _pIDNo = cSessionUser._pIDNo
            _pUserID = cSessionUser._pUserID
            _pUserType = cSessionUser._pUsertype
            _pKeyToken = cSessionUser._pKeyToken

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Class
