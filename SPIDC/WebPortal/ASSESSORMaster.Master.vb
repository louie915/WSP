Public Class ASSESSORMaster
    Inherits System.Web.UI.MasterPage

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


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

                If (cSessionUser._pOffice = "ASSESSOR" Or cSessionUser._pOffice.ToString.Contains("LANDTAX")) And cSessionUser._pUsertype = "LGU" Then
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

    Sub _GetCTR()
        Dim _nClass As New cDalSOSRPTAS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
        _nClass._getNotificationCtr_RPT()
        ctrAL.InnerText = _nClass._ctrAL  ' Appointment List
        ctrAR.InnerText = _nClass._ctrAR  ' Appointment Requests
        ctrERPT.InnerText = _nClass._ctrERPT ' Enrollment RPT
        ctrNRPT.InnerText = _nClass._ctrNRPT ' New RPT Declaration      

        If ctrAL.InnerText = 0 Then ctrAL.Style.Add("display", "none")
        If ctrAR.InnerText = 0 Then ctrAR.Style.Add("display", "none")
        If ctrERPT.InnerText = 0 Then ctrERPT.Style.Add("display", "none")
        If ctrNRPT.InnerText = 0 Then ctrNRPT.Style.Add("display", "none")
    End Sub
End Class