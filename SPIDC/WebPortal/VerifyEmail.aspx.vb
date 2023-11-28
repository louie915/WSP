Public Class VerifyEmail
    Inherits System.Web.UI.Page
    Dim txEmail As String
    Dim txCode As String
    Dim check1 As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txEmail = Request.QueryString("email")
        txCode = Request.QueryString("code")
        Dim loginURL As String = "Register.aspx?email=" & txEmail '"login.html"
        ValidateEmail()

        link1.HRef = loginURL

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
                lblHeader.Text = "Account Already Activated!"
            End If

            If cBllRegistered._pFuncValidateEmail(txEmail, txCode) = True Then
                If check1 = "Not Yet Activated" Then
                    activate_Account(txEmail)

                End If

            Else
                lblHeader.Text = "Invalid Credentials!"
                lblOK.Text = "Email or code incorrect, click "
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub activate_Account(_mUserId As String)
        If Not cBllRegistered._pFuncActivateAccount(_mUserId) Then
            lblHeader.Text = "Something went wrong"
            lblOK.Text = "Your email " & txEmail & " activation failed. Click "
        Else
            lblHeader.Text = "You're all set!"
            lblOK.Text = "Your email " & txEmail & " has been activated, Thank you for signing up. Click "
        End If
    End Sub
End Class