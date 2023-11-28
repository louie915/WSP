Imports System.Data.SqlClient
Imports System.Web.Services

Public Class BPLOAppointmentReq
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then

                get_Requests()


            Else
                Dim _nclass As New cDalAppointment
                _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                Dim AppointmentType As String
                Dim Remarks As String
                Dim Code As String
                Dim StatusID As String
                Dim Email_Subject As String
                Dim Email_Body As String
                Dim Sent As Boolean

                Dim Email As String
                Dim Status = Request("__EVENTTARGET")

                If Request("__EVENTARGUMENT").Contains(":") Then
                    AppointmentType = Request("__EVENTARGUMENT").Split(":")(0)
                    Email = Request("__EVENTARGUMENT").Split(":")(1)
                Else
                    Email = hdnEmail.Value
                    AppointmentType = hdnTranstype.Value
                    Remarks = txtRemarks.Value
                End If




                If Status = "Approve" Then
                    get_Code(Code)
                    StatusID = "Approved"
                End If

                _nclass._pSubAppointmentRequest(Status, AppointmentType, Email, Code, Remarks)

                If Status = "Deny" Then StatusID = "Denied"

                Dim _nClass3 As cDalTransactionHistory
                _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass3._pSubInsertHistory("-", _
                                            cSessionUser._pUserID, _
                                            "BP", _
                                            "Appointment", _
                                            AppointmentType, _
                                            "", _
                                            StatusID)
                If Status = "Approve" Then
                    Email_Body = "To our Valued Taxpayer, <br><br>" & _
                           "We are happy to inform you that your Appontment Request for " & AppointmentType & " has been verified and approved. " & _
                           "You can now continue your Appointment by entering the Code below:<br>" & _
                               "<h1>" & Code & "</h1> <br>" & _
                               "<br>" & _
                           "Thank you for using our Web Service Portal"

                ElseIf Status = "Deny" Then
                    Email_Body = "To our Valued Taxpayer, <br><br>" & _
                          "We sincerely apologized that your Appointment Request for " & AppointmentType & " was denied due to the following reasons:<br>" & _
                              "- " & Remarks & "<br><br>" & _
                           "<br>" & _
                           " Thank you for using our Web Service Portal <br>"

                End If

                cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Email_Subject, Email_Body, Sent)
                Response.Write("<script>alert('Email Notification has been sent to tax payer');</script>")



                get_requests()



            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub Download_Selected(SeqID)
        Dim FileData As Byte()
        Dim FileName As String
        Dim FileType As String
        Dim _nClass As New cDalAppointment
        cDalAppointment._mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubSelectSpecificAttachment(hdnEmail.Value, "Appointment Attachment", hdnTranstype.Value, "011", FileData, FileType, FileName)
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = FileType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName)
        Response.BinaryWrite(FileData)
        Response.Flush()
        Response.End()
    End Sub


    Sub get_requests()
        Dim _nclass As New cDalAppointment
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectAllRequest("Business Permits and Licensing Office")
        GV_AppList.DataSource = Nothing
        GV_AppList.DataSource = cDalAppointment._mDataTable
        GV_AppList.DataBind()
    End Sub

    Private Shared random As Random = New Random()



    Public Shared Function GenerateCode(ByVal length As Integer) As String
        Const chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Return New String(Enumerable.Repeat(chars, length).[Select](Function(s) s(random.[Next](s.Length))).ToArray())
    End Function

    Sub get_Code(ByRef NewCode As String)
        Dim _nclass As New cDalAppointment
        Dim GenCode As String
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGenCode(GenCode)
        NewCode = GenCode
    End Sub

End Class