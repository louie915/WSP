Partial Public Class BPLONewBP_ForApplicationNo

#Region "Properties"

#End Region

    

    

    

    '    Protected Sub _oButtonRemoveBusinessLine_Click(sender As Object, e As EventArgs) _
    'Handles _
    ' _oButtonBuslineRemove.ServerClick

    '        If _FnRemoveBussinessLine(_oTextboxBusinessLineBusCodeRemove.Value, _oTextboxBusinessLineYearRemove.Value) = True Then
    '            _LoadBusinessLine(_oGridViewBusLine)
    '            '_GenerateTOP()
    '        End If
    '    End Sub

    

    Protected Sub _Initialize_UpdateStatus(_nStatus As String)
        Try

            If _SendEmailNotification(_nStatus, "") = True Then '# 1 Send Email Notification
                _UpdateStatus(_nStatus) ' # 2 Update Status

                '#3 Redirect to Landing Page "Succesfuly Notified"
                '  Response.Redirect("NotificationPages/BPLONotification.aspx")
            Else
                'Message Email Notification Failed
                snackbar("red", "Send notification failed, please try again.")
                'ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('Something went wrong, please try again.');", True)
            End If



        Catch ex As Exception

        End Try
    End Sub
    Private Function UpdateImageStatus(_nStatus As String, _nRemarks As String, _nImageType As String, Optional ByRef _nErrMsg As String = Nothing) As Boolean

        Try
            Dim _nStatusField, _nRemarksField As String

            Select Case _nImageType
                Case "1"
                    _nStatusField = "I_OwnerPicStatus"
                    _nRemarksField = "I_OwnerPicRemarks"

                Case "2"
                    _nStatusField = "I_BusEstPicStatus"
                    _nRemarksField = "I_BusEstPicRemarks"

                Case "3"
                    _nStatusField = "I_BusMapPicStatus"
                    _nRemarksField = "I_BusMapPicRemarks"

                Case "4"
                    _nStatusField = "I_AppFormStatus"
                    _nRemarksField = "I_AppFormRemarks"

                Case "5"
                    _nStatusField = "I_DtiSecCdaFileStatus"
                    _nRemarksField = "I_DtiSecCdaFileRemarks"

                Case "6"
                    _nStatusField = "I_TINFileStatus"
                    _nRemarksField = "I_TINFileRemarks"

            End Select

            Dim _nSuccess As Boolean
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE NewBP_Draft set " & _nStatusField & " = ''" & _nStatus & "'', " & _nRemarksField & " = ''" & _nRemarks & "'' "
                ._pCondition = "  where Application_ID = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' "
                ._pExec(_nSuccess, _nErrMsg)

                Return _nSuccess

            End With

        Catch ex As Exception
            _nErrMsg = ex.Message
            Return False

        End Try
    End Function

    Protected Sub _Initialize_UpdateImage(_nStatus As String, _nRemarks As String, _nImageType As String)
        Try
            Dim _nErrMsg As String
            If UpdateImageStatus(_nStatus, _nRemarks, _nImageType, _nErrMsg) = True Then
                _LoadImageAttachment()
                snackbar("green", "Image Status successfuly updated.")
            Else
                snackbar("red", "Image Status Update failed : " & _nErrMsg)
            End If

        Catch ex As Exception
            snackbar("red", "Image Status Update failed : " & ex.Message)
        End Try
    End Sub

    Private Function _SendEmailNotification(_nStatus As String, _nComment As String) As Boolean

        Dim Sent As Boolean
        Dim Subject As String = "NEW BUSINESS PERMIT APPLICATION STATUS"
        Dim Body As String

        Select Case _nStatus

            Case "Approve"

                Body = _
                    "<br> Sir/Ma`am: <br> <br>" & _
                    "Your business permit application with application no. [" & cSessionLoader_NEWBP_Draft._pApplication_ID & "] is now approved by BPLO office. <br>" & _
                    "You can now proceed submmitting other regulatory requirements ... [ Please see Instruction ] " & _
                     IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                    "Thank you. <br>"

            Case "Incomplete"

                Body = _
                    "<br> Sir/Ma`am: <br> <br>" & _
                    "Your business permit application with application no.  " & cSessionLoader_NEWBP_Draft._pApplication_ID & " is now pending until you submit all mandatory requirements." & _
                     IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                    "Thank you. <br>"

        End Select

        Try
            cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)

            Return Sent
        Catch ex As Exception
            Return False
        End Try

    End Function

    Protected Sub _UpdateStatus(_nStatus As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE NewBP_Draft set [Status] = ''" & _nStatus & "'' "
                ._pCondition = "  where Application_ID = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' "
                ._pExec(_nSuccess, _nErrMsg)

            End With

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub _UpdateBUSMASTStatus(_nStatus As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BUSMAST set [remarks] = ''" & _nStatus & "'' "
                ._pCondition = "  where ACCTNO = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' "
                ._pExec(_nSuccess, _nErrMsg)

            End With

        Catch ex As Exception

        End Try
    End Sub

End Class
