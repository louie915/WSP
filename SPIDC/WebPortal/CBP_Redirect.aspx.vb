Imports RestSharp
Imports System.Net

Public Class Redirect_CBP
    Inherits System.Web.UI.Page
    Dim CBPGUID As String = Nothing
    Dim email_address As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                CBPGUID = Request.QueryString("id")

                cLoader_CBPAuthRep._pIsFromCBP = False
                cLoader_CBPAuthRep._pIsRegCBP = False
                cLoader_CBPAuthRep._pIsRegOAIMS = False
                'Check If Exists in CBP Authorized Rep.
                lblProcess.InnerText = "Initializing Data..."
                If cInit_CBPReg._Fn_CheckIfExist_CBP_AuthRep(CBPGUID) = True Then
                    cInit_CBPReg._Get_CBP_BusinessInfo()   '_Get_CBP_BusinessInfo()
                    ' Reset CBP Session
                    cInit_CBPReg._ClearSession(cLoader_CBPAuthRep._pemail_address)
                    cInit_CBPReg._SetSession(cLoader_CBPAuthRep._pemail_address, CBPGUID)

                    'Check If Exixts in OAIMS Registered Table.
                    If cInit_CBPReg._Fn_CheckIfExist_OAIMS_Registered() = True Then  '_Fn_CheckIfExist_OAIMS_Registered()
                        ' Redirect to Login Page\
                        cLoader_CBPAuthRep._pIsRegOAIMS = True '< Indicate that account is registered in CBP Data Bank Only
                        Response.Redirect("Register.aspx", False)
                    Else
                        ' Register online account page
                        cLoader_CBPAuthRep._pIsRegCBP = True '< Indicate that account is registered in OAIMS
                        Response.Redirect("Register.aspx", False)
                    End If
                Else
                    'Redirect to Unathorized Access.
                End If
                lblProcess.InnerText = "Redirecting..."

            Else

            End If
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try

    End Sub

  

End Class