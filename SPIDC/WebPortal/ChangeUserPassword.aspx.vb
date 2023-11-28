Imports System.Data.SqlClient

Public Class ChangeUserPassword
    Inherits System.Web.UI.Page
    Dim _mUserID As String
    Dim _mUserKey As String
    Dim _mKeyToken As String
    Dim _mResetKey As String
    Dim _mUserKeySalt As Byte()
    Dim _mSqlCmd As New SqlCommand
    Dim _mSqlDataReader As SqlDataReader

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

            Dim _nClass As New cDalProfileLoader
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pEmail = cSessionUser._pUserID
            _oTextSecurityQuestion.Value = _nClass.getSecurityQuestion()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mSubProceed()
        Try
            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

            '----------------------------------       
            Dim message As String

            If pw.Value <> cfrmpw.Value Then
                message = "Passwords do not match"
                snackbar("red", message)
                Exit Sub
            ElseIf pw.Value = "" Or cfrmpw.Value = "" Then
                message = "Password cannot be empty"
                snackbar("red", message)
                Exit Sub
            End If

            If _oTextAnswer.Value = "" Then
                message = "Please answer the question before proceeding"
                snackbar("red", message)
            End If

            If Not SecQuestion() Then
                message = "Wrong answer"
                snackbar("red", message)
                Exit Sub
            End If

            If Not cBllRegistered._pFuncGetUserKeySalt(_mUserID, _mUserKeySalt) Then
                message = "Failed to get Key Salt: Please try again."
                snackbar("red", message)
                'Response.Write("<script language='javascript'> alert('Failed to get Key Salt: Please try again'); </script>")
                Exit Sub
            End If
            If Not cBllRegistered._pFuncUpdateUserKey(_mUserID, _mUserKey, "", _mUserKeySalt) Then
                message = "Failed to Save New Password: Please try again."
                snackbar("red", message)
                'Response.Write("<script language='javascript'> alert('Failed to Save New Password: Please try again'); </script>")
                Exit Sub
            End If

            If Not cBllRegistered._pFuncGenerateKeyToken(_mUserID) Then
                'Reset KeyToken to prevent user to use it again in the activation page.   
                message = "Failed to generate new Key Token: Please try again."
                snackbar("red", message)
                'Response.Write("<script language='javascript'> alert('Failed to generate new Key Token: Please try again'); </script>")
                Exit Sub
            End If

            cSessionUser._pSubSessionClear()
            message = "Your password has been successfully updated! Please login again."
            Dim Script As String = "<script type='text/javascript'> alert('" + message + "');  location.replace('Register.aspx');</script>"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "AlertBox", Script)
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Private Function SecQuestion() As Boolean
        Dim res As Boolean
        Dim ans As String = Nothing

        Dim _nClass As New cDalProfileLoader
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pEmail = cSessionUser._pUserID
        ans = _nClass.getSecurityAnswer()

        If _oTextAnswer.Value = ans Then
            res = True
        Else
            res = False
        End If

        Return res
    End Function

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