Public Class UserManagementMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR
        cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

        Dim tst As String
        cSessionLGUProfile._pGetLGUProfile(tst)
        titleLGU.Text = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"
        '  lblLGU.InnerText = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"
        _oLabelUserName.Text = cSessionUser._pLastName & ", " & cSessionUser._pFirstName
        _oLabelEmail.Text = "[" & cSessionUser._pOffice & "] : " & cSessionUser._pUserID


        If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
            Response.Redirect("Register.aspx")
            Exit Sub
        End If
        '--------START: Check if someone has logged using the same ID
        Dim _mKeyToken As String = Nothing
        cBllRegistered._pFuncGetKeyToken(cSessionUser._pUserID, _mKeyToken)
        If cSessionLoader._pKeyToken <> _mKeyToken Then
            Response.Write("<script>alert('Someone has logged on this ID. You will be logged out.');location.replace('Register.aspx');</script>")
            cCookieUser._pSubCookieClear()
            cSessionUser._pSubSessionClear()
            cAuthenticate._pSubSignOut()
            Exit Sub
        ElseIf cSessionUser._pOffice <> "ADMIN" Then
            Response.Write("<script>alert('Unauthorized Access.');location.replace('Register.aspx');</script>")
            cCookieUser._pSubCookieClear()
            cSessionUser._pSubSessionClear()
            cAuthenticate._pSubSignOut()
            Exit Sub
        End If
    End Sub

    Private Sub _oBtnLogout_ServerClick(sender As Object, e As EventArgs) Handles _oBtnLogout.ServerClick
        cCookieUser._pSubCookieClear()
        cSessionUser._pSubSessionClear()
        cAuthenticate._pSubSignOut()
        Response.Redirect("Register.aspx")
    End Sub
End Class