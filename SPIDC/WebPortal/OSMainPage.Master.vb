Public Class OSMainPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim _nClass2 As New cHardwareInformation
        Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
        Dim curr_url As String = HttpContext.Current.Request.Url.AbsoluteUri

        Get_Modules()

        'Dim _nClass As New cDalGetModules
        '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        'If _nClass._pSubGetAvailableModules("FB_CHAT") = True Then
        '    Response.Write("<script>")
        '    Response.Write("var elemDiv1 = document.createElement('div');")
        '    Response.Write("var elemDiv2 = document.createElement('div');")
        '    Response.Write("elemDiv1.id = 'fb-root';")
        '    Response.Write("elemDiv2.id = 'fb-customer-chat';")
        '    Response.Write("elemDiv2.classList.add('fb-customerchat');")
        '    Response.Write("document.body.appendChild(elemDiv);")
        '    Response.Write("document.body.appendChild(elemDiv2);")
        '    Response.Write("var chatbox = document.getElementById('fb-customer-chat');")
        '    Response.Write("chatbox.setAttribute('page_id', '" & _nClass._pSubGetFBChatID() & "');")
        '    Response.Write("chatbox.setAttribute('attribution', 'biz_inbox');")
        '    Response.Write("window.fbAsyncInit = function () {")
        '    Response.Write("FB.init({")
        '    Response.Write("xfbml: true,")
        '    Response.Write("version: 'v13.0'")
        '    Response.Write("}); };")
        '    Response.Write(" (function (d, s, id) {")
        '    Response.Write("var js, fjs = d.getElementsByTagName(s)[0];")
        '    Response.Write("if (d.getElementById(id)) return;")
        '    Response.Write(" js = d.createElement(s); js.id = id;")
        '    Response.Write("js.src = 'https://connect.facebook.net/en_US/sdk/xfbml.customerchat.js';")
        '    Response.Write("fjs.parentNode.insertBefore(js, fjs);")
        '    Response.Write(" }(document, 'script', 'facebook-jssdk'));")
        '    Response.Write("</script>")
        'End If



        cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS
        cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

        _oLabelUserName.Text = "Welcome " & cSessionUser._pFirstName
        _oLabelEmail.Text = cSessionUser._pUserID
        Dim tst As String
        cSessionLGUProfile._pGetLGUProfile(tst)
        titleLGU.Text = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"
        lguname.InnerText = cSessionLGUProfile._pLGU_Header2 & " Web Service Portal"

        If _nMachineName = "MANDAUEWEBSVR" Then
            titleLGU.Text = "Mandaue City E-Services Portal"
        End If

        lguname.Visible = False
        '  titleLGU.Visible = False

        Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim PageName As String = System.IO.Path.GetFileName(PagePath)


        Dim _nDal As New cDalRegistered
        _nDal._pCxn = cGlobalConnections._pSqlCxn_OAIMS
        _nDal._pUserID = cSessionUser._pUserID
        _nDal._pSubSelectSpecificRecord()
        cSessionUser._pUserLevel = _nDal._pUserLevel

        _oLabelUserName.Text = cSessionUser._pLastName & ", " & cSessionUser._pFirstName
        '  _oLabelEmail.Text = "[" & cSessionUser._pOffice & "] : " & cSessionUser._pUserID

        If cSessionUser._pUserLevel = 0 And UCase(PageName) <> "USERPROFILE.ASPX" Then
            cSessionUser._pNewAcc = 1
            Response.Write("<script>alert('Please complete your profile.');location.replace('USERPROFILE.aspx');</script>")

        End If

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
                ElseIf cSessionUser._pUsertype <> "TAXPAYER" Then
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

    Sub Get_Modules()

        Dim _nclass As New cDalGetModules
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        If _nclass._pSubGetAvailableModules("BP_ApplicationV1") = False Then SetModules("BP_ApplicationV1")
        If _nclass._pSubGetAvailableModules("BP_ApplicationV2") = False Then SetModules("BP_ApplicationV2")
        If _nclass._pSubGetAvailableModules("RPT_Application") = False Then SetModules("RPT_Application")
        If _nclass._pSubGetAvailableModules("Cedula") = False Then SetModules("Cedula")
        If _nclass._pSubGetAvailableModules("Appointment") = False Then SetModules("Appointment")
        If _nclass._pSubGetAvailableModules("BP_CPB") = False Then SetModules("BP_CPB")
        If _nclass._pSubGetAvailableModules("RequestSafetySeal") = False Then SetModules("RequestSafetySeal")
        If _nclass._pSubGetAvailableModules("DownloadableForms") = False Then SetModules("DownloadableForms")
        If _nclass._pSubGetAvailableModules("Separate_Home") = True Then SetModules("Separate_Home")
      
    End Sub

    Sub SetModules(ByVal SubModule As String)
        Select Case SubModule
            Case "BP_ApplicationV1"
                liNB.Attributes.CssStyle.Add("pointer-events", "none")
                liNB.Attributes.CssStyle.Add("display", "none")
                liNB.Attributes.CssStyle.Add("opacity", "0.4")
            Case "BP_ApplicationV2"
                li1.Attributes.CssStyle.Add("pointer-events", "none")
                li1.Attributes.CssStyle.Add("display", "none")
                li1.Attributes.CssStyle.Add("opacity", "0.4")
            Case "RPT_Application"
                liNP.Attributes.CssStyle.Add("pointer-events", "none")
                liNP.Attributes.CssStyle.Add("opacity", "0.4")
                liNP.Attributes.CssStyle.Add("display", "none")
            Case "Cedula"
                liCedula.Attributes.CssStyle.Add("opacity", "0.4")
                liCedula.Attributes.CssStyle.Add("pointer-events", "none")
                liCedula.Attributes.CssStyle.Add("display", "none")
            Case "Appointment"
                liAppointment.Attributes.CssStyle.Add("opacity", "0.4")
                liAppointment.Attributes.CssStyle.Add("pointer-events", "none")
                liAppointment.Attributes.CssStyle.Add("display", "none")
            Case "RequestSafetySeal"
                liDILG.Attributes.CssStyle.Add("opacity", "0.4")
                liDILG.Attributes.CssStyle.Add("pointer-events", "none")
                liDILG.Attributes.CssStyle.Add("display", "none")
            Case "BP_CPB"
                liCBP.Attributes.CssStyle.Add("opacity", "0.4")
                liCBP.Attributes.CssStyle.Add("pointer-events", "none")
                liCBP.Attributes.CssStyle.Add("display", "none")

            Case "DownloadableForms"
                liDL1.Attributes.CssStyle.Add("opacity", "0.4")
                liDL1.Attributes.CssStyle.Add("pointer-events", "none")
                liDL1.Attributes.CssStyle.Add("display", "none")

            Case "Separate_Home"
                liAccounts.Attributes.CssStyle.Add("opacity", "0.4")
                liAccounts.Attributes.CssStyle.Add("pointer-events", "none")
                liAccounts.Attributes.CssStyle.Add("display", "none")

                liHome.Attributes.CssStyle.Add("display", "block")


        End Select
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