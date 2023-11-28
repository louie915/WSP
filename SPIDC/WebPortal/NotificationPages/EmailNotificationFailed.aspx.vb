Imports System.IO

Public Class EmailNotificationFailed
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Finish_End_ServerClick(sender As Object, e As EventArgs) Handles Finish_End.ServerClick
        Try

            If _SendEmailNotif_Taxpayer() = True Then
                _FnNotify_BPLO()
                UpdateBusMastRemarks(UCase("For Review"))
                Response.Redirect("~/WebPortal/NotificationPages/ApplicationSuccess.aspx")
                Exit Sub
            Else
                Response.Redirect(Request.Url.AbsoluteUri)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function _SendEmailNotif_Taxpayer() As Boolean
        _SendEmailNotif_Taxpayer = False
        Try
            Dim _nClass As New cDalSendEmail



            With _nClass
                ._pEmailTo = cSessionUser._pUserID
                ._pSubject = "BUSINESS PERMIT APPLICATION STATUS"
                ._pHeader = cSessionLoader._pLGU_Name
                ._pBody = "Sir/Ma`am: <br/> " & _
                            "Attached herewith are the soft copies of Application form and Envelope Seal containing information of business being applied. <br/>" & _
                            "Download and print these attachments to be used as reference once the application has been approved. <br/> <br/> " & _
                            "Business Account Number " & cSessionLoader._pAccountNo & " is now for review and verification by Business Permit Licensing Officer. <br/> " & _
                            "Please wait for 1 working day for approval of application. <br/> <br/> " & _
                            "Thank you."

                ._pFooter = " Date Sent : " & Now.Date & _
                            "<br/> <br/>" & _
                            "THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."

                '' ===== GET FILE FROM TEMPORARY FOLDER AND ADD TO EMAIL ATTACHMENT
                Dim filepath As String = HttpContext.Current.Server.MapPath("~/Temp/")
                Dim _nFileName As String = cSessionLoader._pAccountNo & "_EnvelopeSeal.pdf"
                Dim _nFileName2 As String = cSessionLoader._pAccountNo & "_ApplicationForm.pdf"


                Try
                    ._pAttachment.Add(filepath & _nFileName)
                    ._pAttachment.Add(filepath & _nFileName2)


                Catch ex As Exception

                End Try

                '' ========================================================================

                If ._FnSendEmail() = True Then
                    '' DELETE Temporary file once email has been sent successfuly
                    Try


                        File.Delete(filepath & _nFileName)
                        File.Delete(filepath & _nFileName2)

                    Catch dirNotFound As DirectoryNotFoundException
                        'Console.WriteLine(dirNotFound.Message)
                    End Try
                    '' ====================================================================
                    Return True
                Else
                    Try

                        File.Delete(filepath & _nFileName)
                        File.Delete(filepath & _nFileName2)

                    Catch dirNotFound As DirectoryNotFoundException
                        ' Console.WriteLine(dirNotFound.Message)
                    End Try

                End If
            End With
        Catch ex As Exception

            '' ====================================================================
            cDalLogEvent._pSubLogError(ex)
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" & ex.Message & "');", True)

        End Try

    End Function

    Private Function _FnNotify_BPLO()
        Try
            Dim _nClass As New cDalSendEmail
            With _nClass
                ._pEmailTo = "BPLO"
                ._pSubject = "Account Number: " & cSessionLoader._pAccountNo & " - Business Permit Application (NEW)"
                ._pHeader = cSessionLoader._pLGU_Name
                ._pBody = "Sir/Ma`am: <br> " & _
                            "Business Account Number " & cSessionLoader._pAccountNo & " has been processed and is now ready for Assessment Review. <br>" & _
                            "Please review and verify the account to continue the online process. <br>" & _
                            "Thank you. <br>"

                ._pFooter = "<br> Date Sent : " & Now.Date & _
                            "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."
                If ._pSubSendEmail() = True Then
                    Return True
                Else
                    Return False
                End If

            End With

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub UpdateBusMastRemarks(_nRemarks As String)
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pSelect = "UPDATE BUSMAST Set REMARKS = ''" & _nRemarks & "''"
                ._pCondition = " Where AcctNo = ''" & cSessionLoader._pAccountNo & "''"
                ._pAction = "UPDATE"
                ._pExec(_nSuccessfull, _nErrMsg)

            End With

        Catch ex As Exception

        End Try



    End Sub

End Class