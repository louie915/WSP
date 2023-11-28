Public Class Regulatory_BrgyClearance
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            '----------------------------------
            If Not IsPostBack Then
                _oLabelEmail.Text = cSessionUser._pUserID
                _oLabelUserName.Text = cSessionUser._pFirstName.Substring(0, 1) & ". " & cSessionUser._pLastName
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
                ElseIf cSessionUser._pUsertype <> "LGU" And cSessionUser._pOffice <> "PLANNING" Then
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