Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.ComponentModel
Imports Microsoft.Reporting.WebForms
Imports System.Web.UI
Imports VB.NET.Email

Public Class Register
    Inherits System.Web.UI.Page
    Private _mUserID As String = Nothing
    Private _mUserKey As String = Nothing
    Private _mUserKeySalt As Byte()
    Private _mUserType As String
    Private _mKeyToken As String = Nothing
    Private _mFirstName As String
    Private _mMiddleName As String
    Private _mAgent As String

    Private _mLastName As String
    Private _mBirthDate As Date
    Private _mGender As String
    '----for register.aspx
    Private _mSecurityQ As String
    Private _mSecurityA As String
    Private _mContact_Cp As String
    Private _mResident As String

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
    Dim radAgent As String
    Dim txtEmailAddress As String
    Dim txtPassword As String
    Dim txtConfirmPassword As String

    Dim txtSecurityQ As String
    Dim txtSecurityA As String
    Dim txtContact_Cp As String

    'LGU fields
    Dim cmbUserType As String
    'Dim txtLocalUserName As String
    'Dim txtPassKey As String

    Dim action As String
    Dim htmlID As String

    Dim _nMachineName As String = Nothing




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OnlineNow.InnerText = Application("OnlineUsers").ToString()
        cSessionUser._pUsertype = ""

        Dim linkEmail As String = Request.QueryString("email")
        String.IsNullOrEmpty(linkEmail)



        Try
            '----------------------------------
            If Not IsPostBack Then
                GetCarousel()
                err.Value = "GetCarousel"
                '  GetLinkAttachment()
                GetDLForms()
                err.Value = "GetDLForms"
                GetTNC()
                err.Value = "GetTNC"
                Check_Agent()
                err.Value = "Check_Agent"
                Get_logo()
                err.Value = "Get_logo"
                GetMasking()
                err.Value = "GetMasking"
                GetANNOUNCEMENT()
                err.Value = "GetANNOUNCEMENT"

                GetPROFILE() '--FOR RPTAS EOR POSTING
                err.Value = "GetPROFILE"

                Dim _nClass_Appointment As New cDalAppointment
                _nClass_Appointment.Update_Table()



                Dim _nClass As New cHardwareInformation
                _nMachineName = _nClass._pMachineName.ToUpper

                '   TXTTRAPERROR2.Value = _nMachineName

                Dim _nCR As String = cGlobalConnections._pStrCxn_CR


                Dim LGUName As String
                Dim ctrmod As String
                cSessionLGUProfile._pGetLGUProfile(ctrmod)

                LGUName = cSessionLGUProfile._pLGU_Name



                '    TXTTRAPERROR2.Value = ctrmod & " : " & _nCR
                _oCBResident.Text = "Resident of " & LGUName

                If Request.Form("hdnfld_Submit") = "true" Then
                    ' Request.Form.Set("hdnfld_Submit", "false")
                    chkLGUReg = "TaxPayer" ' Request.Form("chkLGUReg")
                    txtFirstname = Request.Form("txtFirstName")
                    txtLastName = Request.Form("txtLastName")
                    txtBirthDate = Request.Form("txtBirthDate")
                    radGender = Request.Form("radGender")
                    radAgent = Request.Form("radAgent")
                    txtEmailAddress = Request.Form("txtEmailAddress")
                    txtPassword = Request.Form("txtPassword")
                    txtConfirmPassword = Request.Form("txtConfirmPassword")
                    txtSecurityQ = Request.Form("radQuestion")
                    txtSecurityA = Request.Form("txtSecurityA")
                    txtContact_Cp = Request.Form("txtMobileNo")
                    'Check Confirm Password
                    If txtPassword <> txtConfirmPassword Then
                        SnackBar("red", "Password did not match")
                        'Response.Write("<script>alert('Password did not match')</script>")
                        Exit Sub
                    End If

                    'do Tax Payer    
                    Dim _nResult As Boolean : Dim _nMsg As String : Dim _nColor As String
                    err.Value = "do : SignUp"
                    SignUp(_nResult, _nColor, _nMsg)
                    SnackBar(_nColor, _nMsg)
                    Exit Sub
                    ' Response.Write("<script>alert('" & _nMsg & "')</script>")

                ElseIf Request.Form("hdnfld_Resend") = "true" Then
                    _mSubResendVerificationLink(Request.Form("ResendEmail"))
                    cSessionUser._pUsertype = ""
                ElseIf Request.Form("hdnfld_Forgot") = "true" Then
                    Dim email As String = Request.Form("_oTextboxEmailReset")
                    _mSendPasswordResetLink(email)
                    Exit Sub
                End If

                Dim strBody As String
                Dim strTrigger As String = Nothing
                cInit_CBPReg._InitCBP_AutorizeRep(strTrigger, strBody)
                Response.Write("<script>" & strTrigger & strBody & "</script>")



                If cLoader_CBPAuthRep._pIsRegOAIMS = True Then
                    LoginEmail.Value = cLoader_CBPAuthRep._pemail_address
                    cSessionUser._pUserID = cLoader_CBPAuthRep._pemail_address
                ElseIf Request.QueryString("email") IsNot Nothing Then
                    cSessionUser._pUserID = Request.QueryString("email")
                End If
                LoginEmail.Value = cSessionUser._pUserID
            Else


                action = Request("__EVENTTARGET")
                htmlID = Request("__EVENTARGUMENT")
                If action = "SignUp" Then

                    'Dim _nResult As Boolean : Dim _nMsg As String

                    'SignUp(_nResult, _nMsg)

                    'If _nResult = False Then
                    '    snackbar("red", _nMsg)
                    'Else
                    '    snackbar("green", _nMsg)
                    'End If

                ElseIf action = "Resend" Then
                    _mSubResendVerificationLink(htmlID)
                End If



            End If

            '----------------------------------
        Catch ex As Exception

            TXTTRAPERROR.Value = ex.Message
        End Try
    End Sub
    Sub Check_Agent()
        Dim _nclass As New cDalGetModules
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        If _nclass._pSubGetAvailableModules("OAIMS_Agent") = False Then
            div_agent.Style.Add("display", "none")
        Else
            div_agent.Style.Add("display", "")
        End If

    End Sub
    Public Sub SnackBar(ByVal color As String, ByVal msg As String)
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "login", "ShowSnackBar('" & color & "','" & msg & "');", True)
    End Sub

    'GOOGLE RECAPTCHA  ----------START
    Public Class MyObject

        Public Property success As String
    End Class
    Public Function Validate_Recaptcha() As Boolean
        If _nMachineName.ToUpper = "MUNTI-SVR17" Or _nMachineName.ToUpper = "WEBSVRCALOOCAN" Then
            Return True
        End If
        Dim Response As String = Request("g-recaptcha-response")
        Dim Valid As Boolean = False
        'Change the link here depending private key to be used.
        Dim req As HttpWebRequest = CType(WebRequest.Create(" https://www.google.com/recaptcha/api/siteverify?secret=6LdY5E4UAAAAAJ9JkoRwya8T11ig9eC3Sb-dEk3P&response=" & Response), HttpWebRequest)
        Try
            Using wResponse As WebResponse = req.GetResponse()
                Using readStream As StreamReader = New StreamReader(wResponse.GetResponseStream())
                    Dim jsonResponse As String = readStream.ReadToEnd()
                    Dim js As JavaScriptSerializer = New JavaScriptSerializer()
                    Dim data As MyObject = js.Deserialize(Of MyObject)(jsonResponse)
                    Valid = Convert.ToBoolean(data.success)
                End Using
            End Using

            Return Valid
        Catch ex As WebException
            Throw ex
        End Try
    End Function
    'GOOGLE RECAPTCHA  ----------End   
    Sub _mSubResendVerificationLink(txemail)

        cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

        If Not cBllRegistered._pFuncVerifyIfAccountIsRegistered(txemail) Then
            SnackBar("red", "Unregistered Email Address")
            Exit Sub
        End If

        'check if account is already activated
        If cBllRegistered._pFuncVerifyIfAccountIsActivated(txemail, "") = True Then
            'check if email and code are existing and correct 
            SnackBar("red", "Account Already Activated!")
            Exit Sub
        End If

        ClassSessionMailContent._pUserID = txemail
        Dim errMsg As String

        If Not ClassSessionMailContent._pFuncGetUserDetails() Then
            SnackBar("red", "Something went wrong, Please try again.")

            Exit Sub
        End If

        'Send Email For the Notification
        '----------------------------------
        Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim PageName As String = System.IO.Path.GetFileName(PagePath)

        Dim loginURL As String


        Dim verifyurl As String
        If _nMachineName = "BIZPORTAL" Then
            verifyurl = "https://bizportal.silaycity.gov.ph/WebPortal/VerifyEmail.aspx?email=" & txemail & "&code=" & ClassSessionMailContent._mKeyToken
            loginURL = "https://bizportal.silaycity.gov.ph/"
        Else
            verifyurl = Replace(UCase(HttpContext.Current.Request.Url.AbsoluteUri), "REGISTER", "VerifyEmail") & "?email=" & txemail & "&code=" & ClassSessionMailContent._mKeyToken
            loginURL = FullUrl.Replace(PageName, "Register.aspx")
        End If

        Dim Sent As Boolean
        Dim Subject As String = "Welcome to Web Service Portal"
        Dim Body As String
        Select Case _nMachineName

            Case "GRACEVILLE"
                Body = "Congratulations, <br/><br/>" _
                          & "Thank you for signing up. Please click the link below to verify your email address. <br/><br/>" _
                          & "<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Verify your Email</a><br/><br/>" _
                          & "If you cannot see verification link then please use this link instead : " & verifyurl _
                          & " <br/><br/> Once you verify your email address you will be ready to login! <br/><br/>" _
                          & "<a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a><br/><br/>" _
                          & "Instruction for Business Enrollment:<br>" _
                          & "<ol type='1'>" _
                          & " <br><li> You will be asked to enroll Business you wish to transact online by entering the Business Account Number and corresponding Official Receipt Number (OR) of the last payment;</li>" _
                          & " <br><li> We strongly suggest to ready the reference documents such as Business Tax Order of Payment including Official Receipt Number (OR) of last payment that will be needed during enrollment.</li>" _
                          & " <br><li> Submit and wait for the notification email message regarding approval of Business enrolled. </li>" _
                          & "</ol>"

            Case Else
                Body = "Congratulations, <br/><br/>" _
                            & "Thank you for signing up. Please click the link below to verify your email address. <br/><br/>" _
                            & "<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Verify your Email</a><br/><br/>" _
                            & "If you cannot see verification link then please use this link instead : " & verifyurl _
                            & " <br/><br/> Once you verify your email address you will be ready to login! <br/><br/>" _
                            & "<a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a><br/><br/>" _
                            & "Instruction for Business and Real Property Enrollment:<br>" _
                            & "<ol type='1'>" _
                            & " <br><li> You will be asked to enroll Business and/or property(ies) you wish to transact online by entering the the Business Account Number and Tax Declaration Number (TDN) and corresponding Official Receipt Number (OR) of the last payment;</li>" _
                            & " <br><li> We strongly suggest to ready the reference documents such as Business Tax Order of Payment and Latest Taxdeclaration including Official Receipt Number (OR) of last payment that will be needed during enrollment.</li>" _
                            & " <br><li> Submit and wait for the notification email message regarding approval of Business and or properties enrolled. </li>" _
                            & "</ol>"
        End Select


        Dim Err As String

        cDalNewSendEmail.SendEmail(txemail, Subject, Body, Sent, Err)
        If Sent = True Then
            SnackBar("green", "Email Verification has been sent.")
        Else
            SnackBar("red", "Failed to send Email Notification. " & Err)

        End If


        Exit Sub

    End Sub

    Private Sub _mSubRegister(ByRef _mResult As Boolean, ByRef _nMsg As String, ByRef _nColor As String)
        Try
            _mResult = False
            _mFirstName = txtFirstname
            _mLastName = txtLastName
            _mUserID = txtEmailAddress
            _mBirthDate = Convert.ToDateTime(txtBirthDate)
            _mGender = radGender
            _mAgent = radAgent
            _mSecurityQ = txtSecurityQ
            _mSecurityA = txtSecurityA
            _mContact_Cp = txtContact_Cp
            If _oCBResident.Checked = True Then
                _mResident = 1
            Else
                _mResident = 0
            End If
            _mUserType = "TAXPAYER"
            _mUserKey = txtPassword
            _mKeyToken = Nothing


            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

            '--------------- SIGN UP VALDIATION -------------------



            Dim erra As String
            Dim _mIDNo As String = Nothing
            Dim _nclass As New cBllRegistered
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nclass._pSubGetAutoIDno(_mIDNo)
            Err.Value = "00 : " & _mIDNo


            If cBllRegistered._pFuncVerifyIfAccountIsRegistered(_mUserID) Then
                _nMsg = "Email already registered"
                _nColor = "red"
                Err.Value = "01Err"
                Exit Sub
            End If
            Err.Value = "01OK"

            If Not cBllRegistered._pFuncInsertNewAccount(_mIDNo, _mAgent, _mUserID, _mFirstName, _mMiddleName, _mLastName, _mBirthDate, _mGender, _mGender, _mSecurityQ, _mSecurityA, _mContact_Cp, _mResident, erra) Then
                _nMsg = erra
                _nColor = "red"
                Err.Value = "02Err"
                Exit Sub
            End If
            Err.Value = "02OK"

            If Not cBllRegistered._pFuncGetUserKeySalt(_mUserID, _mUserKeySalt) Then
                _nMsg = "Failed to Get Key Salt."
                _nColor = "red"
                Err.Value = "03Err"
                Exit Sub
            End If
            Err.Value = "03OK"
            If Not cBllRegistered._pFuncUpdateUserKey(_mUserID, _mUserKey, UCase(_mUserType), _mUserKeySalt) Then
                _nMsg = "Failed to Update User Key."
                _nColor = "red"
                Err.Value = "04Err"
                Exit Sub
            End If
            Err.Value = "04OK"
            ClassSessionMailContent._pUserID = _mUserID
            If Not ClassSessionMailContent._pFuncGetUserDetails() Then
                _nMsg = "Failed to send Verification Link. Please try to use [Resend Link] below the captcha."
                _nColor = "red"
                Err.Value = "05Err"
                Exit Sub
            End If
            Err.Value = "05OK"
            'Send Email For the Notification
            '----------------------------------
            Dim verifyurl As String
            If _nMachineName = "BIZPORTAL" Then
                verifyurl = Replace(UCase("https://bizportal.silaycity.gov.ph/WebPortal/Register.aspx"), "REGISTER", "VerifyEmail") & "?email=" & _mUserID & "&code=" & ClassSessionMailContent._mKeyToken

            Else
                verifyurl = Replace(UCase(HttpContext.Current.Request.Url.AbsoluteUri), "REGISTER", "VerifyEmail") & "?email=" & _mUserID & "&code=" & ClassSessionMailContent._mKeyToken
            End If

            Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
            Dim PageName As String = System.IO.Path.GetFileName(PagePath)

            Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")
            Dim Sent As Boolean
            Dim Subject As String = "Welcome to Web Service Portal"
            Dim Body As String
            Select Case _nMachineName

                Case "GRACEVILLE"
                    Body = "Congratulations, <br/><br/>" _
                              & "Thank you for signing up. Please click the link below to verify your email address. <br/><br/>" _
                              & "<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Verify your Email</a><br/><br/>" _
                              & "If you cannot see verification link then please use this link instead : " & verifyurl _
                              & " <br/><br/> Once you verify your email address you will be ready to login! <br/><br/>" _
                              & "<a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a><br/><br/>" _
                              & "Instruction for Business Enrollment:<br>" _
                              & "<ol type='1'>" _
                              & " <br><li> You will be asked to enroll Business you wish to transact online by entering the Business Account Number and corresponding Official Receipt Number (OR) of the last payment;</li>" _
                              & " <br><li> We strongly suggest to ready the reference documents such as Business Tax Order of Payment including Official Receipt Number (OR) of last payment that will be needed during enrollment.</li>" _
                              & " <br><li> Submit and wait for the notification email message regarding approval of Business enrolled. </li>" _
                              & "</ol>"

                Case Else
                    Body = "Congratulations, <br/><br/>" _
                                & "Thank you for signing up. Please click the link below to verify your email address. <br/><br/>" _
                                & "<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Verify your Email</a><br/><br/>" _
                                & "If you cannot see verification link then please use this link instead : " & verifyurl _
                                & " <br/><br/> Once you verify your email address you will be ready to login! <br/><br/>" _
                                & "<a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a><br/><br/>" _
                                & "Instruction for Business and Real Property Enrollment:<br>" _
                                & "<ol type='1'>" _
                                & " <br><li> You will be asked to enroll Business and/or property(ies) you wish to transact online by entering the the Business Account Number and Tax Declaration Number (TDN) and corresponding Official Receipt Number (OR) of the last payment;</li>" _
                                & " <br><li> We strongly suggest to ready the reference documents such as Business Tax Order of Payment and Latest Taxdeclaration including Official Receipt Number (OR) of last payment that will be needed during enrollment.</li>" _
                                & " <br><li> Submit and wait for the notification email message regarding approval of Business and or properties enrolled. </li>" _
                                & "</ol>"
            End Select


            Try
                cDalNewSendEmail.SendEmail(_mUserID, Subject, Body, Sent)
                _nMsg = "Email Verification has been sent."
                _nColor = "green"
                Err.Value = "06OK"
            Catch ex As Exception
                _nColor = "red"
                _nMsg = ex.Message
                Err.Value = "06" & ex.Message
            End Try


            '----------------------------------
        Catch ex As Exception
            _nMsg = ex.Message
            _nColor = "red"
            Err.Value = "07" & ex.Message

        End Try
    End Sub



    Private Sub SignUp(ByRef _nResult As Boolean, ByRef _nColor As String, ByRef _nMsg As String)
        '-----Validate Google ReCaptcha

        _nResult = False
        Err.Value = "do : Validate_Recaptcha"
        If Validate_Recaptcha() = True Then
            '------------Validate Fields
            If txtBirthDate = "" _
                Or txtPassword = "" _
                Or txtConfirmPassword = "" _
                Or txtEmailAddress = "" _
                Or txtFirstname = "" _
                Or radGender = "" _
                Or txtLastName = "" _
                 Then
                Err.Value = "err : Validate Fields"
                SnackBar("red", "Incomplete Details")
                Exit Sub
            End If
            Err.Value = "OK : Validate Fields"
            '------------Confirm Password Validaiton
            If txtPassword <> txtConfirmPassword Then
                Err.Value = "err : confirmPass"
                SnackBar("red", "Password did not match")
                Exit Sub
            End If
            Err.Value = "OK : confirmPass"

            '-------Continue Registration
            Err.Value = "do : _mSubRegister"
            _mSubRegister(_nResult, _nMsg, _nColor)
            SnackBar(_nColor, _nMsg)
            '@Added 20211109 Louie
            If cLoader_CBPAuthRep._pIsFromCBP = True Then
                cLoader_CBPAuthRep._pIsRegOAIMS = True
            End If
        Else '----Invalid ReCaptcha

            SnackBar("red", "Invalid Captcha")
            Err.Value = "err : Validate_Recaptcha"
            ' _nMsg = "Invalid Captcha"
            '  _nColor = "red"
        End If

    End Sub
    Private Sub _mSendPasswordResetLink(email)

        _mUserID = email

        cSessionUser._pUserID = ""
        ClassSessionMailContent._pUserID = _mUserID

        cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS
        TXTTRAPERROR2.Value = cGlobalConnections._pSqlCxn_OAIMS.DataSource
        'Verify If UserID Email Exists.
        If Not cBllRegistered._pFuncVerifyIfAccountIsRegistered(_mUserID) Then
            SnackBar("red", "Unregistered Email")
            Exit Sub
        End If



        If Not cBllRegistered._pFuncVerifyIfAccountIsActivated(_mUserID) Then
            SnackBar("red", "Account is not yet activated")
            Exit Sub
        End If

        If Not cBllRegistered._pFuncGenerateKeyToken(_mUserID) Then
            'Reset KeyToken to prevent user to use it again in the activation page.
            'TODO: Notify User that the system was unable to process the transaction...
            SnackBar("red", "Failed to Generate Token. Please try again.")
            Exit Sub
        End If

        If Not cBllRegistered._pFuncGetKeyToken(_mUserID, _mKeyToken) Then
            'TODO: Notify User that the system was unable to process the transaction...
            SnackBar("red", "Failed to Get Key Token. Please try again.")
            Exit Sub
        End If

        'If Not ClassSessionMailContent._pFuncSendEmailUserKeyReset() Then
        '    snackbar("red", "Failed to Send Email Confirmation Link. Please refresh the page and try again.")
        '    Exit Sub
        'End If

        'Send Email For the Notification
        '----------------------------------
        Dim _nResetKey As Boolean = True
        Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim PageName As String = System.IO.Path.GetFileName(PagePath)
        Dim _nUrlParameter As String = Nothing
        _nUrlParameter = "?_nUserID=" & email & "&_nKeyToken=" & _mKeyToken & "&_nResetKey=" & _nResetKey
        Dim verifyurl As String
        If _nMachineName = "BIZPORTAL" Then
            verifyurl = "https://bizportal.silaycity.gov.ph/WebPortal/ResetPassword.aspx" & _nUrlParameter
        Else
            verifyurl = FullUrl.Replace(PageName, "ResetPassword.aspx" & _nUrlParameter)
        End If


        Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")
        Dim Sent As Boolean
        Dim Subject As String = "Forgot Password"
        Dim Body As String = "Hi, <br/><br/>" _
                              & "We have sent you this email in response to your request to reset your password. <br/><br/>" _
                              & "To reset your password for " & email & ", please click this link [<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Confirm Reset</a>]<br/><br/>" _
                              & "If you cannot see verification link then please use this link instead : " & verifyurl _
                              & "  <br/><br/> We recommend that you keep your password secure and not share it with anyone.<br/><br/>"
        Try
            Dim Err As String
            cDalNewSendEmail.SendEmail(email, Subject, Body, Sent, Err)
            If Sent = False Then
                SnackBar("red", "Failed to Send Email Confirmation Link. " & Err)
            ElseIf Sent = True Then
                SnackBar("green", "Password Reset Link has been sent.")
                Exit Sub
            End If



        Catch ex As Exception
            ' snackbar("red", "Failed to Send Email Confirmation Link. Please refresh the page and try again.")
            SnackBar("red", ex.Message)

        End Try

        '  _mSubUpdateSessionVariables()

        '  Response.Redirect("EmailSent.aspx")
        ' snackbar("green", "Email confirmation has been sent")

    End Sub
    Private Sub _mSubUpdateSessionVariables()
        Try
            '----------------------------------

            cSessionUser._pSubSessionClear()
            cSessionUser._pUserID = _mUserID
            cSessionUser._pKeyToken = _mKeyToken
            cSessionUser._pUsertype = _mUserType
            cSessionUser._pSubSessionFillUserDetails()
            'Pass session to the cookie
            cCookieUser._pSubPassSessionToCookie()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Sub testSnackBar_Click(sender As Object, e As EventArgs) Handles testSnackBar.Click
        SnackBar("red", "testing")
    End Sub

    Private Sub testclick_ServerClick(sender As Object, e As EventArgs) Handles testclick.ServerClick
        Response.Write("<script>alert('oh shoot');</script>")
    End Sub

    Sub GetCarousel()
        Try
            Dim HTMLString As String
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

            If _nClass._pSubCheckIfTableExist("Carousel") = True Then
                HTMLString = _nClass._pSubDisplayCarousel()
                If HTMLString.Length > 0 Then
                    divCarousel.InnerHtml = HTMLString
                End If
            Else
                _nClass._pSubCreateTable("CAROUSEL")
                _nClass._pSubAlterTableAutoNum("CAROUSEL", "FileID")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub GetLinkAttachment()
        Try
            Dim HTMLString As String
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

            If _nClass._pSubCheckIfTableExist("LinkAttachment") = True Then
                '  lnkAbout = _nClass._pSubDisplayLINKATTACHMENT("About")
                '  lnkHowTo = _nClass._pSubDisplayLINKATTACHMENT("HowTo")
                '  lnkFAQs = _nClass._pSubDisplayLINKATTACHMENT("FAQs")
                '  lnkPP = _nClass._pSubDisplayLINKATTACHMENT("PP")

            Else
                _nClass._pSubCreateTable("LINKATTACHMENT")
                _nClass._pSubAlterTableAutoNum("LINKATTACHMENT", "FileID")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetDLForms()
        Try
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nClass._pSubCheckIfTableExist("DLForms") = True Then
                _nClass._pSubSelectDLForms()
                gv_DLForms.DataSource = _nClass._mDataTable
                gv_DLForms.DataBind()
            Else
                _nClass._pSubCreateTable("DLForms")
                _nClass._pSubAlterTableAutoNum("DLForms", "FileID")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub GetTNC()
        Try
            Dim TITLE As String
            Dim CONTENT As String
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

            If _nClass._pSubCheckIfTableExist("POLICY") = True Then
                _nClass._pSubDisplayTNC(TITLE, CONTENT)
                If CONTENT = Nothing Or TITLE = Nothing Then
                    'DO NOTHING, SHOW DEFAULT TERMS AND CONDITIONS
                Else
                    TNC_Title.InnerHtml = TITLE
                    TNC_Content.InnerHtml = CONTENT
                End If
            Else
                _nClass._pSubCreateTable("POLICY")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Sub GetMasking()
        Try
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

            If _nClass._pSubCheckIfTableExist("MASKING") = False Then
                _nClass._pSubCreateTable("MASKING")
            End If

        Catch ex As Exception

        End Try
    End Sub

   

    Sub GetANNOUNCEMENT()
        Try
            Dim _TITLE As String
            Dim _DATE As String
            Dim _CONTENT As String
            Dim _STATUS As Boolean
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

            If _nClass._pSubCheckIfTableExist("ANNOUNCEMENT") = True Then
                _nClass._pSubDisplayANN(_TITLE, _CONTENT, _DATE, _STATUS)
                If _STATUS = False Then
                    'DO NOTHING, ANNOUNCEMENT DISABLED
                Else
                    ANN_TITLE.InnerHtml = _TITLE
                    ANN_DATE.InnerHtml = _DATE
                    ANN_CONTENT.InnerHtml = _CONTENT
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal('DIV_ANN');", True)
                End If
            Else

                _nClass._pSubCreateTable("ANNOUNCEMENT")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub GetPROFILE()
        Try
            Dim _STATUS As Boolean
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            If _nClass._pSubCheckIfTableExist("RPTPROFILE") = False Then
                _nClass._pSubCreateTable("RPTPROFILE")
            End If

        Catch ex As Exception

        End Try
    End Sub


    Sub Get_logo()
        Try
            Dim _nClass As New cDalImageSetup
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            imgLogoHere.Src = _nClass._pSubDisplayLogo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _btnLogin_ServerClick(sender As Object, e As EventArgs) Handles _btnLogin.ServerClick
        do_Login()
    End Sub
    Sub do_Login()
        Dim Email As String = LoginEmail.Value
        Dim Password As String = LoginPassword.Value

        Dim _nClass As New cDalNewLogin
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        If _nClass._isEmailExists(Email) = True Then
            If _nClass._isEmailActivated(Email) = True Then
                If _nClass._isPasswordCorrect(Email, Password, _nClass.Get_UserKeySalt(Email)) = True Then
                    _nClass.Get_UserDetails(Email)
                    cSessionUser._pUserID = Email

                    Dim _nUserType As String = cSessionUser._pUsertype.ToUpper
                    Dim _nOffice As String = cSessionUser._pOffice.ToUpper

                    Select Case _nUserType
                        Case "LGU"

                            Select Case _nOffice
                                Case "BPLO"
                                    postbackurl = "BPLOEnrollmentVerification.aspx"
                                Case "ASSESSOR", "LANDTAX"
                                    postbackurl = "ASSESSOREnrollmentVerification.aspx"
                                Case "TREASURY"
                                    postbackurl = "LGU_GeneralCollectionReport.aspx"
                                Case "ADMIN"
                                    postbackurl = "UserAccountManagement.aspx"
                                Case Else
                                    postbackurl = "AppointmentApproval.aspx"
                            End Select

                        Case "REGULATORY"
                            postbackurl = "Regulatory.aspx"

                        Case "TAXPAYER"
                            If cSessionUser._pUserLevel = 0 Then
                                postbackurl = "UserProfile.aspx"
                            Else
                                Dim _nClass2 As New cDalGetModules
                                _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                                If _nClass2._pSubGetAvailableModules("Separate_Home") = True Then
                                    postbackurl = "Home.aspx"
                                Else
                                    postbackurl = "Account.aspx"
                                End If

                            End If

                    End Select


                    If String.IsNullOrEmpty(postbackurl) = True Then
                        SnackBar("red", "Invalid User Type")
                        Exit Sub
                    Else
                        Response.Redirect(postbackurl)
                    End If
                Else
                    SnackBar("red", "Invalid Credentials")

                    Exit Sub
                End If
            Else
                SnackBar("red", "Email is not yet Activated")
                Exit Sub
            End If
        Else
            SnackBar("red", "Unregistered Email Address")
            Exit Sub
        End If

    End Sub

    Private Sub _UserRedirectCase_xxx()

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
            End If


        ElseIf UCase(cSessionUser._pUsertype) = "REGULATORY" Then
            postbackurl = "Regulatory.aspx"

        ElseIf UCase(cSessionUser._pUsertype) = "TAXPAYER" Then
            If cSessionUser._pUserLevel = 0 Then
                postbackurl = "UserProfile.aspx"
            Else
                Dim _nClass2 As New cDalGetModules
                _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                If _nClass2._pSubGetAvailableModules("Separate_Home") = True Then
                    postbackurl = "Home.aspx"
                Else
                    postbackurl = "Account.aspx"
                End If

            End If
        End If
    End Sub
End Class
