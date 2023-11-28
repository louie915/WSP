

#Region "Imports"

Imports System.Reflection
Imports System.Reflection.MethodBase
Imports System.Web.HttpContext

#End Region

Public Class cSessionNotice1

#Region "Variables"

    Private Shared _mPrefix As String = GetCurrentMethod.DeclaringType.FullName

#End Region

#Region "Properties"

    Shared Property _pTitle() As String
        Get
            Return Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4))
        End Get
        Set(ByVal value As String)
            Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4)) = value
        End Set
    End Property

    Shared Property _pMessage() As String
        Get
            Return Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4))
        End Get
        Set(ByVal value As String)
            Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4)) = value
        End Set
    End Property

#End Region

#Region "Routines"

    Public Shared Sub _pSubSessionClear()
        Try
            '----------------------------------
            _pMessage = Nothing
            _pMessage = Nothing

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region


End Class
