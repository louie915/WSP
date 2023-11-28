

#Region "Imports"

Imports System.Web
Imports System.Web.HttpContext
Imports System.Data.SqlClient
Imports System.Threading

#End Region

Public Class cAuthenticate

    Public Shared Function _mSubDisplaySessionUser() As Boolean
        Try
            '----------------------------------
            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS
            'If String.IsNullOrWhiteSpace(cSessionUser._pUserID) Then
            cSessionUser._pSubPassCookieToSession()
            'End If

            'If ClassSessionUser is nothing.
            If String.IsNullOrWhiteSpace(cSessionUser._pUserID) _
                Or String.IsNullOrWhiteSpace(cSessionUser._pKeyToken) Then

                Return False
            End If

            If Not cBllRegistered._pFuncVerifyIfValidKeyToken( _
                cSessionUser._pUserID, cSessionUser._pKeyToken _
                ) Then

                Return False
            End If

            Return True

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Sub _pSubVerifySession()
        Try
            '----------------------------------
            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

            If String.IsNullOrWhiteSpace(cSessionUser._pUserID) Or (cSessionUser._pUserID <> cCookieUser._pUserID) Or (cSessionUser._pKeyToken <> cCookieUser._pKeyToken) Then
                'If Session Variable Is Nothing, Get From Ccookie.

                cSessionUser._pSubPassCookieToSession()
            End If


            If String.IsNullOrWhiteSpace(cSessionUser._pKeyToken) Then
                'If KeyToken Is Nothing, Redirect to Sign In Page.

                _pSubSignIn()

                Exit Sub

            End If

            If Not cBllRegistered._pFuncVerifyIfValidKeyToken( _
                cSessionUser._pUserID _
                , cSessionUser._pKeyToken _
                ) Then
                'If KeyToken is InvalidCastException.

                'TODO: Put security measures here to avoid Hacks.
                _pSubSignIn()

                Exit Sub

            End If

            '----------------------------------
        Catch ex As Exception
            _pSubSignIn()
        End Try
    End Sub

    Public Shared Sub _pSubVeryfyLogIN()
        Try
            '----------------------------------


            If String.IsNullOrWhiteSpace(cCookieUser._pIDNo) Then
                'If KeyToken is InvalidCastException.

                'TODO: Put security measures here to avoid Hacks.
                'cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
                'rPages_VS2014WAOAIMS_Business.pSignIn)
            Else
                cCookieUser._pSubCookieClear()
                cSessionUser._pSubSessionClear()
                cAuthenticate._pSubSignIn()
                'cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
                'rPages_VS2014WAOAIMS_Business.pInformation)
                'cCookiePrevPage._pUrl = HttpContext.Current.Request.Url.AbsoluteUri
                'cUrlRedirects._pSubRedirect(cCookiePrevPage._pUrl)

                Exit Sub

            End If

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub _pSubSignOut()
        Try
            '----------------------------------
            'If Not cBllRegistered._pFuncGenerateKeyToken(cSessionUser._pUserID) Then
            'Reset KeyToken to prevent user to use it again in the activation page.
            'TODO: Notify User that the system was unable to process the transaction...

            'cUrlRedirects._pSubRedirect( vs2014.wa. _gResxPagesNotes.pUnderConstruction)
            'cUrlRedirects._pSubRedirect_VS2014WACR(
            'rPages_VS2014WAOAIMS_Notes.pUnderConstruction)

            'End If

            cCookieUser._pSubCookieClear()
            cSessionUser._pSubSessionClear()
            '  cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
            '           rPages_VS2014WAOAIMS_Business.pSignIn)
            '_pSubSignIn()
            'Save Url in case of returning back after Signing-In.
            'cCookiePrevPage._pUrl = HttpContext.Current.Request.Url.AbsoluteUri

            'cUrlRedirects._pSubRedirect(
            '    rPages_VS2014WAOAIMS_Business.pSignOut)
            'cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
            '    rPages_VS2014WAOAIMS_Business.pSignIn)
            'cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
            '    rPages_VS2014WAOAIMS_Business.pInformation)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub _pSubSignIn()
        Try

            'Save Url in case of returning back after Signing-In.

            'cCookiePrevPage._pUrl = HttpContext.Current.Request.Url.AbsoluteUri

            'cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
            '    rPages_VS2014WAOAIMS_Business.pSignIn)

            '     cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
            '       rPages_VS2014WAOAIMS_Business.pLogin)

        Catch ex As Exception

        End Try
    End Sub


    Public Shared Sub _pSubSignUp()
        Try

            '  cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
            '       rPages_VS2014WAOAIMS_Business.pSignUp)

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub _pSubUser()
        Try

            '    cUrlRedirects._pSubRedirect_VS2014WAOAIMS(
            '         rPages_VS2014WAOAIMS_Overture.pHome)

        Catch ex As Exception

        End Try
    End Sub

End Class
