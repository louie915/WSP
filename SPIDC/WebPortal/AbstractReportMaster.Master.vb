Imports System.Drawing
Public Class AbstractReportMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS
            cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR
            If Not IsPostBack Then

                '--------START: Check if someone has logged using the same ID
                Dim _mKeyToken As String = Nothing
                cBllRegistered._pFuncGetKeyToken(cSessionUser._pUserID, _mKeyToken)
                If cSessionLoader._pKeyToken <> _mKeyToken Then
                    Response.Write("<script>alert('Someone has logged on this ID. You will be logged out.');location.replace('Register.aspx');</script>")
                    cCookieUser._pSubCookieClear()
                    cSessionUser._pSubSessionClear()
                    cAuthenticate._pSubSignOut()
                    Exit Sub
                End If
                '-------- END

                If cSessionUser._pOffice = "EXECUTIVE" And cSessionUser._pUsertype = "LGU" Then
                    _oLabelUserName.Text = "Welcome " & cSessionUser._pFirstName
                    _oLabelEmail.Text = cSessionUser._pUserID
                    Dim tst As String
                    cSessionLGUProfile._pGetLGUProfile(tst)
                    titleLGU.Text = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"
                    lblLGU.InnerText = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"

                Else
                    cCookieUser._pSubCookieClear()
                    cSessionUser._pSubSessionClear()
                    cAuthenticate._pSubSignOut()
                    Response.Redirect("Register.aspx")
                End If


            Else

            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub _oBtnLogout_ServerClick(sender As Object, e As EventArgs) Handles _oBtnLogout.ServerClick
        cCookieUser._pSubCookieClear()
        cSessionUser._pSubSessionClear()
        cAuthenticate._pSubSignOut()
        Response.Redirect("Register.aspx")
    End Sub

    Private Sub _oBtnProfile_ServerClick(sender As Object, e As EventArgs) Handles _oBtnProfile.ServerClick
        Response.Redirect("UserProfile.aspx")
    End Sub

End Class