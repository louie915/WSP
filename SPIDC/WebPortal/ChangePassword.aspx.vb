Public Class ChangePassword
    Inherits System.Web.UI.Page
    Dim _mUserID As String
    Dim _mUserKey As String
    Dim _mKeyToken As String
    Dim _mResetKey As String
    Dim _mUserKeySalt As Byte()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                End If

            End If

            If Request("__EVENTTARGET") = "Save" Then
                _mUserID = cSessionUser._pUserID
                _mUserKey = Request("__EVENTARGUMENT")
                _mSubProceed()
            End If

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
            Dim message As String = "Your password has been successfully updated! Please login again."
            Dim Script As String = "<script type='text/javascript'> alert('" + message + "');  location.replace('Register.aspx');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", Script)
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
End Class