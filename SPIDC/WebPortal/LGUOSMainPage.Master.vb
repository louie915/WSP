Public Class LGUOSMainPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _oLabelUserName.Text = "Welcome " & cSessionUser._pFirstName
        _oLabelEmail.Text = cSessionUser._pUserID
        Dim tst As String
        cSessionLGUProfile._pGetLGUProfile(tst)
        titleLGU.Text = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"
        lbllGU.InnerText = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"


        Try
            _GetCTR()
            cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

            '----------------------------------
            If Not IsPostBack Then
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Or UCase(cSessionUser._pOffice) <> "TREASURY" Then
                    Response.Redirect("Register.aspx")
                    Exit Sub
                End If

                Dim _nclassGetModules As New cDalGetModules
                If _nclassGetModules._pSubGetAvailableModules("EOR") = False Then
                    lieORList.Attributes.CssStyle.Add("pointer-events", "none")
                    lieORList.Attributes.CssStyle.Add("display", "none")
                    lieORList.Attributes.CssStyle.Add("opacity", "0.4")

                    lieORPOSTING.Attributes.CssStyle.Add("pointer-events", "none")
                    lieORPOSTING.Attributes.CssStyle.Add("display", "none")
                    lieORPOSTING.Attributes.CssStyle.Add("opacity", "0.4")
                End If
            End If
                '----------------------------------
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

    Private Sub _oBtnChangePassword_ServerClick(sender As Object, e As EventArgs) Handles _oBtnChangePass.ServerClick
        Response.Redirect("ChangeUserPassword.aspx")
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