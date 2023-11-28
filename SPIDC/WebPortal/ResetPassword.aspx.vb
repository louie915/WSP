Public Class ResetPassword
    Inherits System.Web.UI.Page
    Dim _mUserID As String
    Dim _mUserKey As String
    Dim _mKeyToken As String
    Dim _mResetKey As String
    Dim _mUserKeySalt As Byte()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            _mUserID = Request.QueryString("_nUserID")
            _mKeyToken = Request.QueryString("_nKeyToken")
            _mResetKey = Request.QueryString("_nResetKey")
            validate_TOken()

        Catch ex As Exception
            '  Response.Redirect("/login.html")
        End Try
     


    End Sub
    Sub validate_TOken()
        cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS
        If Not cBllRegistered._pFuncVerifyIfValidKeyToken(_mUserID, _mKeyToken) Then
            '  snackbar("red", "Unable to Process Transaction: Failed to Validate Key Token.")
            Response.Write("<script language='javascript'> alert('Invalid Key Token: You will be redirected to Login Page'); </script>")
            ' Response.Redirect("/VS2014.IMC/Main.aspx")
            Response.Redirect("Register.aspx")
            Exit Sub
        End If


    End Sub

    Private Sub _mSubResetUserKey()
        Try

            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

            '----------------------------------
            cSessionUser._pSubSessionClear()
            cSessionUser._pUserID = _mUserID
            cSessionUser._pKeyToken = _mKeyToken

            If _oTextboxNewPass.Value = "" Or _oTextboxConfirmNewPass.Value = "" Then
                Response.Write("<script language='javascript'> alert('Please Enter New Password'); </script>")
                Exit Sub
            End If

            If _oTextboxNewPass.Value <> _oTextboxConfirmNewPass.Value Then
                Response.Write("<script language='javascript'> alert('Password didn't match. Please try again'); </script>")
                Exit Sub
            Else
                _mUserKey = _oTextboxNewPass.Value
            End If


            If _
                String.IsNullOrWhiteSpace(_mUserID.Trim()) Or String.IsNullOrWhiteSpace(_mKeyToken.Trim()) Then
                'Put Security measures here to avoid Hacks.
                'send back to home

            End If

            If Not cBllRegistered._pFuncVerifyIfValidKeyToken(_mUserID, _mKeyToken) Then
                Response.Write("<script language='javascript'> alert('Invalid Key Token: You will be redirected to Login Page'); </script>")
                '   Response.Redirect("/VS2014.IMC/Main.aspx")
                Response.Redirect("Register.aspx")
                Exit Sub
            End If

            If Not cBllRegistered._pFuncResetUserKey(_mUserID) Then
                Response.Write("<script language='javascript'> alert('Invalid Key Token: You will be redirected to Login Page'); </script>")
                '  Response.Redirect("/VS2014.IMC/Main.aspx")
                Response.Redirect("Register.aspx")
                Exit Sub
            End If

            If Not cBllRegistered._pFuncGenerateKeyToken(_mUserID) Then
                ''Reset KeyToken to prevent user to use it again in the activation page.     
                Response.Write("<script language='javascript'> alert('Failed to generate new Key Token: You will be redirected to Login Page'); </script>")
                'Response.Redirect("/VS2014.IMC/Main.aspx")
                Response.Redirect("Register.aspx")
                Exit Sub
            End If

            If Not cBllRegistered._pFuncGetKeyToken(_mUserID, _mKeyToken) Then
                Response.Write("<script language='javascript'> alert('Failed to get Key Token: You will be redirected to Login Page'); </script>")
                ' Response.Redirect("/VS2014.IMC/Main.aspx")
                Response.Redirect("Register.aspx")
                Exit Sub
            End If

            '----------------------------------
            'Update Session Variables
            cSessionUser._pSubSessionClear()
            cSessionUser._pUserID = _mUserID
            cSessionUser._pKeyToken = _mKeyToken
            '----------------------------------
            'Redirect to Password Creation Page.
            'Delay in seconds before showing the next page.


            _mSubProceed()

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mSubProceed()
        Try

            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS
            '----------------------------------       
            If Not cBllRegistered._pFuncGetUserKeySalt(_mUserID, _mUserKeySalt) Then
                Response.Write("<script language='javascript'> alert('Failed to get Key Salt: Please try again'); </script>")
                Exit Sub
            End If
            If Not cBllRegistered._pFuncUpdateUserKey(_mUserID, _mUserKey, "", _mUserKeySalt) Then
                Response.Write("<script language='javascript'> alert('Failed to Save New Password: Please try again'); </script>")
                Exit Sub
            End If

            If Not cBllRegistered._pFuncGenerateKeyToken(_mUserID) Then
                'Reset KeyToken to prevent user to use it again in the activation page.              
                Response.Write("<script language='javascript'> alert('Failed to generate new Key Token: Please try again'); </script>")
                Exit Sub
            End If

            cSessionUser._pSubSessionClear()
            Response.Write("<script language='javascript'> alert('Your password has been successfully updated!'); </script>")
            ' Response.Redirect("/VS2014.IMC/Main.aspx")
            Response.Redirect("Register.aspx")

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

 
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        _mSubResetUserKey()

    End Sub
End Class