Imports System.Net
Imports System.Net.Mail
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.ComponentModel
Imports Microsoft.Reporting.WebForms
Imports System.Web.UI
Imports VB.NET.Email

Public Class OAIMS_New
    Inherits System.Web.UI.MasterPage
    Private _mUserID As String = Nothing
    Private _mUserLevel As String = Nothing
    Private _mUserKey As String = Nothing
    Private _mUserKeySalt As Byte()
    Private _mUserType As String
    Private _mKeyToken As String = Nothing
    Private _mFirstName As String
    Private _mMiddleName As String
    Private _mLastName As String
    Private _mBirthDate As Date
    Private _mSetupGender As String

    Dim _mWebMailer As String
    Dim _mWebMailerPass As String
    Dim _mWebMailSubject As String
    Dim _mWebMailBody As String
    Dim _mWebMailCC As String
    Dim postbackurl As String

    '--------- Registration Entry ----
    Dim chkLGUReg As String
    Dim txtFirstname As String
    Dim txtLastName As String
    Dim txtBirthDate As String
    Dim radGender As String
    Dim txtEmailAddress As String
    Dim txtPassword As String
    Dim txtConfirmPassword As String

    'LGU fields
    Dim cmbUserType As String
    Dim txtLocalUserName As String
    Dim txtPassKey As String

    Dim action As String
    Dim htmlID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR
            Dim tst As String
            cSessionLGUProfile._pGetLGUProfile(tst)

            Dim _nClass2 As New cHardwareInformation
            Dim _nMachineName As String = Nothing
            _nMachineName = _nClass2._pMachineName.ToUpper

            If _nMachineName = "MANDAUEWEBSVR" Then
                titleLGU.InnerText = "Mandaue City E-Services Portal"
                _About.Style.Add("display", "inline-block")
                _HowTo.Style.Add("display", "inline-block")
                _FAQs.Style.Add("display", "inline-block")
                _PrivacyPolicy.Style.Add("display", "inline-block")

            ElseIf _nMachineName = "MRVLSWEBSVR" Then
                titleLGU.InnerText = "MARIVELES eAssist"
            Else
                titleLGU.InnerText = cSessionLGUProfile._pLGU_Name & " Web Service Portal"
            End If




            '----------------------------------
            If Not IsPostBack Then



                If Request.Form("hdnfld_Forgot") = "true" Or _
                 Request.Form("hdnfld_Resend") = "true" Or _
                 Request.Form("hdnfld_Submit") = "true" Then
                    Exit Sub
                End If
                If UCase(cSessionUser._pUsertype) = "LGU" Then
                    If UCase(cSessionUser._pOffice) = "BPLO" Then
                        postbackurl = "BPLOEnrollmentVerification.aspx"
                    ElseIf UCase(cSessionUser._pOffice) = "ASSESSOR" Or UCase(cSessionUser._pOffice) = "LANDTAX" Then
                        postbackurl = "ASSESSOREnrollmentVerification.aspx"
                    ElseIf UCase(cSessionUser._pOffice) = "TREASURY" Then
                        postbackurl = "LGU_GeneralCollectionReport.aspx"
                    ElseIf UCase(cSessionUser._pOffice) = "ADMIN" Then
                        postbackurl = "UserAccountManagement.aspx"
                    ElseIf UCase(cSessionUser._pOffice) = "APPT" Then
                        postbackurl = "Scheduler.aspx"
                        'ElseIf UCase(cSessionUser._pOffice) = "EXECUTIVE" Then
                        '    postbackurl = "AbstractReport.aspx"
                        'ElseIf UCase(cSessionUser._pOffice) = "DILG" Then
                        '    postbackurl = "DILGInspectionRequest.aspx"
                        'ElseIf UCase(cSessionUser._pOffice) = "PLANNING" Then
                        '    postbackurl = "Regulatory_Zoning.aspx"
                    End If


                ElseIf UCase(cSessionUser._pUsertype) = "REGULATORY" Then
                    postbackurl = "Regulatory.aspx"

                ElseIf UCase(cSessionUser._pUsertype) = "TAXPAYER" Then
                    If cSessionUser._pUserLevel = 0 Then
                        postbackurl = "UserProfile.aspx"
                    Else
                        Dim _nClass As New cDalGetModules
                        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                        If _nClass._pSubGetAvailableModules("Separate_Home") = True Then
                            postbackurl = "Home.aspx"
                        Else
                            postbackurl = "Account.aspx"
                        End If

                    End If

                End If

                If postbackurl <> Nothing Then
                    Response.Redirect(postbackurl)
                End If

                'If cLoader_CBPAuthRep._pIsRegOAIMS = True Then
                '    txtLoginEmail.Value = cLoader_CBPAuthRep._pemail_address
                'ElseIf Request.QueryString("email") IsNot Nothing Then
                '    cSessionUser._pUserID = Request.QueryString("email")
                'End If
                '
                '  txtLoginEmail.Value = cSessionUser._pUserID



                cDBUpdate.Init_DBUpdate()
            Else
                '  If Request.QueryString("email").Length > 0 Then
                '      txtLoginEmail.Value = Request.QueryString("email")
                '      cSessionUser._pUserID = Request.QueryString("email")
                '  End If
                '
                '  txtLoginEmail.Value = cSessionUser._pUserID

            End If



        Catch ex As Exception

        End Try



    End Sub

    'Public Sub snackbar(Color As String, Caption As String)
    '    If Color = "red" Then
    '        _oLabelSnackbar.Text = Caption
    '        Page.ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

    '    ElseIf Color = "green" Then
    '        _oLabelSnackbargreen.Text = Caption
    '        Page.ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
    '    End If
    'End Sub


    'Private Sub btnSignIn_Click(sender As Object, e As EventArgs) Handles btnSignIn.ServerClick
    '    Try
    '        cCookieUser._pSubCookieClear()
    '        cSessionUser._pSubSessionClear()
    '        cAuthenticate._pSubSignOut()


    '        cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS


    '        '------------- Incomplete Validation -------------
    '        If txtLoginEmail.Value = Nothing Or txtLoginPassword.Value = Nothing Then
    '            snackbar("red", "Invalid Email / Password")
    '            Response.Write("<script>alert('Invalid Email / Password')</script>")
    '            Exit Sub
    '        End If

    '        '------------- Get LOGIN CREDENTIALS -------------          
    '        _mUserID = txtLoginEmail.Value
    '        _mUserKey = txtLoginPassword.Value
    '        '------------- LOGIN Validation ------------- 
    '        Dim _nCR As String = cGlobalConnections._pStrCxn_OAIMS

    '        'Response.Write("<script>alert(" & _nCR & ")</script>")

    '        ''Verify If UserID Email Exists.
    '        If Not cBllRegistered._pFuncVerifyIfAccountIsRegistered(_mUserID) Then
    '            snackbar("red", "Invalid Email or Password")
    '            Response.Write("<script>alert('Unregistered Email Address')</script>")
    '            Exit Sub
    '        End If

    '        If Not cBllRegistered._pFuncVerifyIfAccountIsActivated(_mUserID) Then
    '            snackbar("red", "Email is not  yet Activated")
    '            Response.Write("<script>alert('Email is not  yet Activated')</script>")
    '            Exit Sub
    '        End If

    '        If Not cBllRegistered._pFuncGetUserKeySalt(_mUserID, _mUserKeySalt) Then
    '            snackbar("red", "Failed to get Key. Please Try again.")
    '            Response.Write("<script>alert('Failed to get Key. Please Try again.')</script>")
    '            Exit Sub
    '        End If

    '        If Not cBllRegistered._pFuncVerifyUserIDUserKey(_mUserID, _mUserKey, _mUserKeySalt) Then
    '            snackbar("red", "Invalid Email or Password")
    '            Response.Write("<script>alert('Invalid Email or Password')</script>")
    '            Exit Sub
    '        End If

    '        If Not cBllRegistered._pFuncGenerateKeyToken(_mUserID) Then
    '            snackbar("red", "Failed to Generate Token. Please Try Again")
    '            Response.Write("<script>alert('Failed to Generate Token. Please Try Again')</script>")
    '            Exit Sub
    '        End If

    '        If Not cBllRegistered._pFuncGetKeyToken(_mUserID, _mKeyToken) Then
    '            snackbar("red", "Failed to Get Token. Please Try Again")
    '            Response.Write("<script>alert('Failed to Get Token. Please Try Again')</script>")
    '            Exit Sub
    '        End If




    '        '------------------login success-----------------------
    '        cSessionUser._pSubSessionClear()
    '        cSessionUser._pUserID = _mUserID
    '        cSessionUser._pKeyToken = _mKeyToken
    '        ' cSessionUser._pUsertype = _mUserType
    '        cSessionUser._pSubSessionFillUserDetails()
    '        'Pass session to the cookie
    '        cCookieUser._pSubPassSessionToCookie()
    '        cSessionLoader._pKeyToken = _mKeyToken


    '        '  Dim _nclass As New cBllRegistered
    '        '_nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
    '        '      cBllRegistered._pSubUpdateLogin(cSessionUser._pUserID, System.Net.Dns.GetHostEntry(Request.ServerVariables("REMOTE_HOST")).HostName)

    '        'DO Login Success! Redirecting...

    '        Dim verifyurl As String = UCase(HttpContext.Current.Request.Url.AbsoluteUri)
    '        Dim IsMatch As Match = Regex.Match(verifyurl, "REGISTER.ASPX")

    '        If UCase(cSessionUser._pUsertype) = "LGU" Then
    '            If UCase(cSessionUser._pOffice) = "BPLO" Then
    '                postbackurl = "BPLOEnrollmentVerification.aspx"
    '            ElseIf UCase(cSessionUser._pOffice) = "ASSESSOR" Or UCase(cSessionUser._pOffice) = "LANDTAX" Then
    '                postbackurl = "ASSESSOREnrollmentVerification.aspx"
    '            ElseIf UCase(cSessionUser._pOffice) = "TREASURY" Then
    '                postbackurl = "LGU_GeneralCollectionReport.aspx"
    '            ElseIf UCase(cSessionUser._pOffice) = "ADMIN" Then
    '                postbackurl = "UserAccountManagement.aspx"
    '            ElseIf UCase(cSessionUser._pOffice) = "EXECUTIVE" Then
    '                postbackurl = "AbstractReport.aspx"
    '            ElseIf UCase(cSessionUser._pOffice) = "DILG" Then
    '                postbackurl = "DILGInspectionRequest.aspx"
    '            ElseIf UCase(cSessionUser._pOffice) = "PLANNING" Then
    '                postbackurl = "Regulatory_Zoning.aspx"
    '            Else
    '                postbackurl = "LGUAppointment.aspx"
    '            End If

    '        ElseIf UCase(cSessionUser._pUsertype) = "REGULATORY" Then
    '            postbackurl = "Regulatory.aspx"

    '        ElseIf UCase(cSessionUser._pUsertype) = "TAXPAYER" Then
    '            If cSessionUser._pUserLevel = 0 Then
    '                postbackurl = "UserProfile.aspx"
    '            Else
    '                If cLoader_CBPAuthRep._pIsFromCBP = True Then
    '                    postbackurl = "UploadDocs.aspx"
    '                Else
    '                    Dim _nClass As New cDalGetModules
    '                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
    '                    If _nClass._pSubGetAvailableModules("Separate_Home") = True Then
    '                        postbackurl = "Home.aspx"
    '                    Else
    '                        postbackurl = "Account.aspx"
    '                    End If

    '                End If

    '            End If

    '        Else
    '            cCookieUser._pSubCookieClear()
    '            cSessionUser._pSubSessionClear()
    '            cAuthenticate._pSubSignOut()
    '            Response.Write("<script>alert('Unauthorized Access.')</script>")
    '            postbackurl = "Register.aspx"
    '        End If

    '        Response.Redirect(postbackurl)


    '    Catch ex As Exception
    '    End Try
    'End Sub

End Class