Public Class LGUVerifyEmail
    Inherits System.Web.UI.Page
    Dim txEmail As String
    Dim txCode As String
    Dim txoffice As String
    Dim check1 As String
    Dim reg As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
        Try
            If Not IsPostBack Then
                txEmail = Request.QueryString("email")
                txCode = Request.QueryString("code")
                txoffice = Request.QueryString("Office")
                reg = Request.QueryString("R")
                _otxt_EmailAddress.Text = txEmail
                _otxt_code.Text = txCode
                _otxt_Office.Text = txoffice
                _otxt_R.Text = reg
            Else
                Dim loginURL As String = "Register.aspx"
                Dim email As String = Request.Form("_otxt_EmailAddress")
                Dim code As String = Request.Form("_otxt_code")
                Dim office As String = Request.Form("_otxt_Office")

                If email <> Nothing Then
                    txCode = Request.Form("_otxt_code")
                    txEmail = Request.Form("_otxt_EmailAddress")
                    reg = Request.Form("_otxt_R")
                    activate_Account(email)
                Else
                    ValidateEmail()
                End If

            End If

        Catch ex As Exception

        End Try


      


     

        '  link1.HRef = loginURL
    End Sub

    Sub ValidateEmail()
        Try
            check1 = Nothing
            'check if account is already activated

            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

            If cBllRegistered._pFuncVerifyIfAccountIsActivated(txEmail, "") = False Then
                'check if email and code are existing and correct 
                check1 = "Not Yet Activated"
            Else
                DivOK.Visible = False
                DivErr.Visible = True
                txtErr.InnerText = "Account Already Activated!"


                lnkLogin.HRef = "Register.aspx"
                lnkLogin.InnerText = "Click here to Login"

                Response.Write("<script>alert('Account Already Activated!');window.location('Register.aspx');</script>")

                ' lblHeader.Text = "Account Already Activated!"
                Exit Sub
            End If

            If cBllRegistered._pFuncValidateEmail(txEmail, txCode) = True Then
                If check1 = "Not Yet Activated" Then
                    DivOK.Visible = True
                    DivErr.Visible = False
                    ' activate_Account(txEmail)


                End If

            Else
                DivOK.Visible = False
                DivErr.Visible = True
                txtErr.InnerText = "Invalid Credentials!"
                lnkLogin.HRef = "Register.aspx"
                lnkLogin.InnerText = "Click here to Login"
                Response.Write("<script>alert('Invalid Credentials!');window.location('Register.aspx');</script>")
                Exit Sub
            
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub activate_Account(_mUserId As String)

        cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

        If Not cBllRegistered._pFuncActivateAccount(_mUserId) Then
            DivOK.Visible = True
            DivErr.Visible = False
            txtErr.InnerText = "Something went wrong. Your email " & txEmail & " activation failed. Please Contact your admin."
            lnkLogin.HRef = "Register.aspx"
            lnkLogin.InnerText = "Click here to Login"
            Response.Write("<script>alert('Something went wrong. Your email " & txEmail & " activation failed. Please Contact your admin.');window.location('Register.aspx');</script>")

        Else
            Dim _mFirstName As String = Request.Form("txtFirstname")
            Dim _mLastName As String = Request.Form("txtLastname")
            Dim _mMiddleName As String = Request.Form("txtMiddlename")
            Dim _mBirthDate As String = Request.Form("txtBirthDate")
            Dim _mGender As String = Request.Form("txtGender")
            Dim _mSecurityQ As String = Request.Form("radQuestion")
            Dim _mSecurityA As String = Request.Form("txtSecurityA")
            Dim _mContact_Cp As String = Request.Form("txtContactNumber")
            Dim _mResident As String = 1
            Dim _mUserType = "LGU"
            If reg = 1 Then
                _mUserType = "REGULATORY"
            End If
            Dim _mUserKey As String = Request.Form("txtPassword")
            Dim _mPassKey As String = Request.Form("_oTxtPassKey")
            Dim _mKeyToken As String = txCode
            Dim _mUserKeySalt As Byte() = Nothing
            Dim _mPassKeySalt As Byte() = Nothing

            If Not cBllRegistered._pFuncUpdateNewAccount(txEmail, _mUserId, _mFirstName, _mMiddleName, _mLastName, _mBirthDate, _mGender, _mGender, _mSecurityQ, _mSecurityA, _mContact_Cp, _mResident, _mUserType) Then
                Response.Write("<script>alert('Failed to Insert New Account');</script>")
                Exit Sub
            End If

            If Not cBllRegistered._pFuncGetUserKeySalt(_mUserId, _mUserKeySalt) Then
                Response.Write("<script>alert('Failed to Get Key Salt.');</script>")
                Exit Sub
            End If

            If Not cBllRegistered._pFuncUpdateLGUUserKey(_mUserId, _mUserKey, _mUserKeySalt) Then
                Response.Write("<script>alert('Failed to Update User Key.');</script>")
                Exit Sub
            End If

            If Not cBllRegistered._pFuncGetPassKeySalt(_mUserId, _mPassKeySalt) Then
                Response.Write("<script>alert('Failed to Get Key Salt.');</script>")
                Exit Sub
            End If

            If Request.QueryString("Office") = "EXECUTIVE" Then
                If Not cBllRegistered._pFuncUpdateLGUPassKey(_mUserId, _mPassKey, _mPassKeySalt) Then
                    Response.Write("<script>alert('Failed to Update User Key.');</script>")
                    Exit Sub
                End If
            End If


            DivOK.Visible = False
            DivErr.Visible = True
            txtErr.InnerText = "You're all set! Your email has been activated, Thank you for signing up."

            If Request.Form("_otxt_Office").Substring(0, 3) = "OBO" Then
                Dim NewLogin As String = Nothing
                Select Case System.Environment.MachineName
                    Case "HAVANA"
                        NewLogin = HttpContext.Current.Request.Url.AbsoluteUri.Split("//")(0).ToString & "//" & HttpContext.Current.Request.Url.Host & "/engineering/WebPortal/Register.aspx"
                    Case "WEBSVRCALOOCAN"
                        If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("TEST") = True Then
                            NewLogin = HttpContext.Current.Request.Url.AbsoluteUri.Split("//")(0).ToString & "//" & HttpContext.Current.Request.Url.Host & "/TEST_OCBO/WebPortal/Register.aspx"
                        Else
                            NewLogin = HttpContext.Current.Request.Url.AbsoluteUri.Split("//")(0).ToString & "//" & HttpContext.Current.Request.Url.Host & "/engineering/WebPortal/Register.aspx"
                        End If
                End Select

                lnkLogin.HRef = NewLogin
                lnkLogin.InnerText = "Click here to Login"
                Response.Write("<script>alert('Your email has been activated, Thank you for signing up.');window.location('" & NewLogin & "');</script>")

            Else
                lnkLogin.HRef = "Register.aspx"
                lnkLogin.InnerText = "Click here to Login"
                Response.Write("<script>alert('Your email has been activated, Thank you for signing up.');window.location('Register.aspx');</script>")
            End If
           

        End If
    End Sub


End Class