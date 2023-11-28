Public Class LGUappointmentMaster
    Inherits System.Web.UI.MasterPage

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        Try
            cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

            If Not IsPostBack Then
                If cSessionUser._pUsertype = "LGU" Then
                    _oLabelUserName.Text = "Welcome " & cSessionUser._pFirstName & " " & cSessionUser._pLastName
                    _oLabelEmail.Text = cSessionUser._pUserID & "[" & cSessionUser._pOffice & "]"
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

End Class