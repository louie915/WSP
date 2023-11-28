Public Class SchedulerMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS
        cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

        _oLabelUserName.Text = "Welcome " & cSessionUser._pFirstName
        _oLabelEmail.Text = cSessionUser._pUserID
        Dim tst As String
        cSessionLGUProfile._pGetLGUProfile(tst)
        titleLGU.Text = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"
        lguname.InnerText = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"

        lguname.Visible = False
        '  titleLGU.Visible = False

        Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim PageName As String = System.IO.Path.GetFileName(PagePath)


        Try
            '----------------------------------
            If Not IsPostBack Then
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
                ElseIf cSessionUser._pOffice <> "APPT" Then
                    Response.Write("<script>alert('Unauthorized Access.');location.replace('Register.aspx');</script>")
                    cCookieUser._pSubCookieClear()
                    cSessionUser._pSubSessionClear()
                    cAuthenticate._pSubSignOut()
                    Exit Sub
                End If
                '-------- END

            Else


            End If
            '----------------------------------
        Catch ex As Exception


        End Try
    End Sub

    
    Private Sub _oBtnLogout_ServerClick(sender As Object, e As EventArgs) Handles _oBtnLogout.ServerClick
        cDalProfileLoader.pIsupload = False
        cCookieUser._pSubCookieClear()
        cSessionUser._pSubSessionClear()
        cAuthenticate._pSubSignOut()
        Response.Redirect("Register.aspx")
    End Sub

    Private Sub _oBtnProfile_ServerClick(sender As Object, e As EventArgs) Handles _oBtnProfile.ServerClick
        cDalProfileLoader.pIsupload = False
        'Gimay 20201124
        Session("BRSecChanged") = True
        Session("SPAChanged") = True
        Session("GIDChanged") = True

        Response.Redirect("UserProfile.aspx")
    End Sub

    Private Sub _oBtnChangePass_ServerClick(sender As Object, e As EventArgs) Handles _oBtnChangePass.ServerClick
        cDalProfileLoader.pIsupload = False
        Response.Redirect("ChangeUserPassword.aspx")
    End Sub
End Class