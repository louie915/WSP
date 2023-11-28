Public Class UserAccountManagementRegister
    Inherits System.Web.UI.Page
    Dim _nMachineName As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim Email As String = Request.Form("txtEmail")
                Dim Department As String = Request.Form("txtDesc")
                Dim Submit As String = Request.Form("hdnSubmit")
                If Submit = "TRUE" Then
                    _mSubRegister(Email, Department)
                End If
                Get_Department()
            Else

            End If
        Catch ex As Exception

        End Try
      
    End Sub
    Sub Get_Department()
        Try
            '----------------------------------
            cmbDepartment.DataSourceID = Nothing

            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nClass._pSubGetDepartment()


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then

                    '_mSubShowBlank()
                End If

                cmbDepartment.DataSource = _nDataSet
                cmbDepartment.DataTextField = "Department"
                cmbDepartment.DataValueField = "Usertype"
                cmbDepartment.DataBind()

                '----------------------------------
            Catch ex As Exception

                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

  
    Private Sub _mSubRegister(ByVal Email As String, ByVal Office As String)
        Try
            Dim _mFirstName As String = " "
            Dim _mLastName As String = " "
            Dim _mMiddleName As String = " "
            Dim _mUserID = Email
            Dim _mBirthDate As String = Date.Now
            Dim _mGender As String = "M"
            Dim _mSecurityQ As String = " "
            Dim _mSecurityA As String = " "
            Dim _mContact_Cp As String = " "
            Dim _mResident As String = 0
            Dim _mUserType As String = "LGU"
            Dim _mOffice As String = Office
            Dim _mUserLevel As String = 1
            Dim _mUserKey As String = Nothing
            Dim _mKeyToken As String = Nothing
            Dim _mUserKeySalt As Byte() = Nothing

            If Office = "ADMIN" Then _mUserLevel = 100

            Dim Regulatory As Boolean = False
            Dim reg As Integer = 0
            Dim _nClass1 As New cDalAppointment
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
           

            _nClass1._pSubcheckIfRegulatory(Office, Regulatory)

            If Regulatory = True Then
                _mUserType = "REGULATORY"
                reg = 1
            End If


        
            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

            If cBllRegistered._pFuncVerifyIfAccountIsRegistered(_mUserID) Then
                ' Response.Write("<script>alert('Email already registered');</script>")

                snackbar("red", "Email already registered")
                Exit Sub
            End If


            Dim _mIDNo As String = Nothing
            Dim _nclass As New cBllRegistered
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nclass._pSubGetAutoIDno(_mIDNo)
            Dim _Xerr As String
            If Not cBllRegistered._pFuncInsertLGUAccount(_mIDNo, _mUserID, _mFirstName, _mMiddleName, _mLastName, _mBirthDate, _mGender, _mGender, _mSecurityQ, _mSecurityA, _mContact_Cp, _mResident, _mUserType, _mOffice, _mUserLevel, _Xerr) Then
                '  Response.Write("<script>console.log('Error : " & _err & "');</script>")
                '  Response.Write("<script>alert('Error : " & _err & "');</script>")
                _err.Value = "Error : " & _Xerr
                snackbar("red", "Failed to Insert New Account")
                Exit Sub
            End If


            If Not cBllRegistered._pFuncGetUserKeySalt(_mUserID, _mUserKeySalt) Then
                ' snackbar("red", "Failed to Get Key Salt.")
                Response.Write("<script>alert('Failed to Get Key Salt.');</script>")

                Exit Sub
            End If


            ClassSessionMailContent._pUserID = _mUserID
            If Not ClassSessionMailContent._pFuncGetUserDetails() Then
                Response.Write("<script>alert('Failed to Send Email Confirmation Link.');</script>")
                Exit Sub
            End If



            cDalUserAccountManagement._pAdmin_RegLink = "OK"
            cDalUserAccountManagement._pAdmin_SelectedOffice = Office

            Dim _nClass2 As New cHardwareInformation
            _nMachineName = _nClass2._pMachineName.ToUpper

            Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
            Dim PageName As String = System.IO.Path.GetFileName(PagePath)
            Dim verifyurl As String
            If _nMachineName = "BIZPORTAL" Then
                verifyurl = Replace(UCase("https://bizportal.silaycity.gov.ph/WebPortal/Register.aspx"), "REGISTER", "LGUVerifyEmail") & "?email=" & _mUserID & "&code=" & ClassSessionMailContent._mKeyToken & "&office=" & cDalUserAccountManagement._pAdmin_SelectedOffice & "&R=" & reg
            Else
                verifyurl = FullUrl.Replace(PageName, "LGUVerifyEmail.aspx?email=" & _mUserID & "&code=" & ClassSessionMailContent._mKeyToken & "&office=" & cDalUserAccountManagement._pAdmin_SelectedOffice & "&R=" & reg)
            End If


            Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")
            Dim Sent As Boolean
            Dim Subject As String = "Welcome to Web Service Portal"
            Dim Body As String = "<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Verify your Email</a><br/><br/>" _
                                & "If you cannot see verification link then please use this link instead : " & verifyurl _
                                & " <br/><br/> Once you verify your email address you will be ready to login! <br/><br/>" _
                                & "<a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a><br/><br/>"

            cDalNewSendEmail.SendEmail(_mUserID, Subject, Body, Sent)

            If Sent = True Then
                snackbar("green", "Email Verification has been sent.")
            Else
                snackbar("red", "Failed to Send Email Verification, Please try again.")
                'snackbar("red", cSessionLoader._pErrMSG)
            End If


            '----------------------------------
        Catch ex As Exception


        End Try
    End Sub
    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub


End Class