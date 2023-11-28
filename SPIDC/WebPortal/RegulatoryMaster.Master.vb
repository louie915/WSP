Public Class RegulatoryMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            _GetCTR()
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

                If cSessionUser._pUsertype = "REGULATORY" Then
                    _oLabelUserName.Text = cSessionUser._pFirstName & " " & cSessionUser._pLastName & "&nbsp <i class='fa fa-user-circle'></i>"
                    _oLabelEmail.Text = cSessionUser._pUserID & "&nbsp <i class='fa fa-envelope'></i><br>"
                    _oLabelOffice.Text = cSessionUser._pOffice & "&nbsp <i class='fa fa-ID-card'></i><br>"

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

    Sub _GetCTR()
        Dim _nClass As New cDalAppointment
        Dim ctr2 As Integer
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        ctrAL.InnerText = _nClass._getNotificationCtr_Regulatory(cSessionUser._pOffice, ctr2)
        ctrAR.InnerText = ctr2 ' Appointment Requests
        If ctrAL.InnerText = 0 Then ctrAL.Style.Add("display", "none")
        If ctrAR.InnerText = 0 Then ctrAR.Style.Add("display", "none")
    End Sub


End Class