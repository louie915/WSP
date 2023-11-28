﻿
Imports System.Data.SqlClient
Imports System.Web.Services

Public Class ASSESSORAppointmentList
    Inherits System.Web.UI.Page
    Dim Office As String

    <WebMethod>
    Public Shared Function GetEvents() As IList
        Dim events As IList = New List(Of [Event])()

        Dim _nSqlCommand As SqlCommand
        Dim _nDataTable As DataTable
        Dim _nQuery As String = Nothing
        Dim colorselected
        Dim eventselected = cSessionLoader._pSelectedEventID

        '  _nQuery = "Select * from Appointment WHERE OFFICE='" & cSessionUser._pOffice & "' AND APPDATE> (SELECT GETDATE()) ORDER BY APPDATE"


        _nQuery = "Select AppDate, Slot, COUNT(*) Ctr from Appointment WHERE isnull(RequestStatus,'0')<>'0' and OFFICE='" & cSessionUser._pOffice & "' group by appdate, slot having COUNT(*) > 0 order by appdate,slot"

        _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
        Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
        _nDataTable = New DataTable
        _nSqlDataAdapter.Fill(_nDataTable)

        Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader

            If _nSqlDr.HasRows Then
                Do While _nSqlDr.Read()
                    Dim a As Date = Format(_nSqlDr.Item("AppDate"), "MM-dd-yyyy")
                    Dim b As Date = Format(Date.Now, "MM-dd-yyyy")

                    Dim d As String = _nSqlDr.Item("AppDate").day
                    Dim m As String = _nSqlDr.Item("AppDate").month
                    If d < 10 Then d = 0 & d
                    If m < 10 Then m = 0 & m
                    Dim y As String = _nSqlDr.Item("AppDate").year
                    Dim EvId As String = m & d & y & _nSqlDr.Item("Slot")


                    If a < b Then
                        colorselected = "#666669" ' Gray for Past Dates
                    Else
                        colorselected = "#5070DA" ' Blue
                    End If

                    events.Add(New [Event] With {
                   .EventID = EvId,
                   .EventName = _nSqlDr.Item("Slot") & _nSqlDr.Item("Ctr"),
                   .StartDate = _nSqlDr.Item("AppDate").ToString,
                   .EndDate = _nSqlDr.Item("AppDate").ToString,
                   .Url = "ASSESSORAppointmentList.aspx?EventID=" & Trim(EvId) & "&EventDate=" & Format(_nSqlDr.Item("AppDate"), "yyyy-MM-dd") & "&EventTime=" & _nSqlDr.Item("Slot"),
                    .Color = colorselected
               })
                    ' "ASSESSORAppointmentList?EventID=" & Trim(EvId) & "&EventDate=" & Format(_nSqlDr.Item("AppDate"), "yyyy-MM-dd") & "&EventTime=" & _nSqlDr.Item("Slot"),


                Loop
                Return events
            Else
                Return events
            End If
        End Using
    End Function
    Public Class [Event]
        Public Property EventID As String
        Public Property EventName As String
        Public Property StartDate As String
        Public Property EndDate As String
        Public Property Color As String
        Public Property ImageType As Integer
        Public Property Url As String
    End Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            '----------------------------------
            cBllRegistered._pSqlConOAIMS = cGlobalConnections._pSqlCxn_OAIMS

            If Not IsPostBack Then
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                    Exit Sub
                End If
                '--------START: Check if someone has logged using the same ID
                Dim _mKeyToken As String = Nothing
                cBllRegistered._pFuncGetKeyToken(cSessionUser._pUserID, _mKeyToken)
                If cSessionLoader._pKeyToken <> _mKeyToken Then
                    Response.Write("<script>alert('Someone has logged on this ID. You will be logged out.');location.replace('Register.aspx');</script>")
                    cCookieUser._pSubCookieClear()
                    cSessionUser._pSubSessionClear()
                    cAuthenticate._pSubSignOut()
                    Exit Sub
                ElseIf cSessionUser._pUsertype <> "LGU" Then
                    Response.Write("<script>alert('Unauthorized Access.');location.replace('Register.aspx');</script>")
                    cCookieUser._pSubCookieClear()
                    cSessionUser._pSubSessionClear()
                    cAuthenticate._pSubSignOut()
                    Exit Sub
                End If
                '-------- END


                If String.IsNullOrEmpty(Request.QueryString("EventID")) Then
                    'do nothing
                    cSessionLoader._pSelectedEventID = ""
                    cSessionLoader._pSelectedEventDate = ""
                    cSessionLoader._pSelectedEventTime = ""

                Else
                    'Get Selected Date Details
                    cSessionLoader._pSelectedEventID = Request.QueryString("EventID")
                    cSessionLoader._pSelectedEventDate = Request.QueryString("EventDate")
                    cSessionLoader._pSelectedEventTime = Request.QueryString("EventTime")


                    Dim _nclass As New cDalAppointment
                    _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    _nclass._pSubSelectSpecificAppDate(cSessionLoader._pSelectedEventDate, cSessionLoader._pSelectedEventTime, cSessionUser._pOffice)
                    GV_AppList.DataSource = Nothing
                    GV_AppList.DataSource = cDalAppointment._mDataTable
                    GV_AppList.DataBind()

                    Get_Attachments(cSessionUser._pOffice)



                    Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                    sb.Append("<script language='javascript'>")
                    sb.Append("$('#AppointmentSummary').modal('show');")
                    sb.Append("</script>")
                    ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

                End If


                Get_AppType(cSessionUser._pOffice)

            Else
                If Request("__EVENTTARGET") = "View" Then
                    Download_Selected(Request("__EVENTARGUMENT"))
                    Exit Sub
                End If

                Dim AppID = Request("__EVENTTARGET")
                Dim Status = Request("__EVENTARGUMENT")
                Dim servedby As String = _otxtAppServedBy.Text
                Dim remarks As String = _otxtAppRemarks.Text
                If Status <> "" Then
                    Dim Sent As Boolean
                    Dim Subject As String = "APPOINTMENT STATUS"
                    Dim Body As String = "" & _
                        "To our Valued Taxpayer, </br>" & _
                        "Your appointment is now " & Status & "</br>" & _
                        "Below are the details regarding your appointment:</br>" & _
                        " <table style='border: 1px solid black;border-collapse: collapse;'> " & _
                        " <tr><th colspan='2' style='padding: 5px;text-align: center;'>Appointment Details</th></tr>" & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Email Address</td><td>" & hdnEmail.Value & "</td></tr>" & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Name</td><td>" & hdnName.Value & "</td></tr>  " & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Appointment ID</td><td>" & hdnAppID.Value & "</td></tr>  " & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Appointment Date</td><td>" & hdnAppDate.Value & "</td></tr>  " & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Appointment Type</td><td>" & hdnAppType.Value & "</td></tr>  " & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Appointment Purpose</td><td>" & hdnPurpose.Value & "</td></tr>" & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Appointment Status</td><td>" & Status & "</td></tr>" & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Served By</td><td>" & _otxtAppServedBy.Text & "</td></tr>" & _
                        " <tr style='border: 1px solid black;'><td style='padding: 5px;text-align: left;border: 1px solid black;'>Remarks</td><td>" & _otxtAppRemarks.Text & "</td></tr>" & _
                        " </table> <br><br>"


                    cDalNewSendEmail.SendEmail(hdnEmail.Value, Subject, Body, Sent)
                    If Sent = True Then
                        Dim _nclass As New cDalAppointment
                        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                        _nclass._pSubUpdateAppStatus(Status, AppID, servedby, remarks)
                        snackbar("green", "Email Verification has been sent.")

                        Dim newDate As String = Format(CDate(hdnAppDate.Value), "MMMM dd, yyyy")
                        Dim time As String = Strings.Right(Trim(hdnAppDate.Value), 2)
                        Dim Particulars As String =
                        "Appointment ID=" & hdnAppID.Value & _
                        ";Appointment Date=" & newDate & " " & time & _
                        ";Appointment Type=" & hdnAppType.Value & _
                        ";Purpose(if others)=" & hdnPurpose.Value & _
                        ";Appointment Status=" & Status & _
                        ";Served By=" & _otxtAppServedBy.Text & _
                        ";Remarks=" & _otxtAppRemarks.Text & ";"


                        Dim _nClass2 As New cDalTransactionHistory
                        _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                        _nClass2._pSubInsertHistory(AppID, hdnEmail.Value, "Appointment", hdnAppType.Value, "City Assessors Office", _
                                Particulars, _
                                UCase(Status))
                    Else
                        snackbar("red", "Something went wrong, Please try again.")

                    End If
                End If





            End If
            '----------------------------------
        Catch ex As Exception


        End Try

    End Sub

    Protected Sub DownloadFile()
        Dim FileData As Byte()
        Dim FileName As String
        Dim FileType As String

        Dim _nclass As New cDalAppointment
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectSpecificAttachment(cSessionUser._pUserID, cSessionLoader._pService, cSessionLoader._pTDN, "001", FileData, FileType, FileName)

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

    Private Function _FnNotify_Taxpayer() As Boolean
        Try
            Dim Sent As Boolean
            Dim Subject As String = "Appointment Schedule Confirmation"
            Dim Body As String = ""
            cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)
            Return True
        Catch ex As Exception
            Return False
        End Try
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

    Sub Get_AppType(Office)

        Try

            '----------------------------------

            cmbAppType.DataSourceID = Nothing



            Dim _nClass As New cDalAppointment

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS


            _nClass._pSubGetAppType(Office)



            Dim _nDataSet As New DataSet()

            _nDataSet = _nClass._pDataSet


            Try

                '----------------------------------    

                cmbAppType.DataSource = _nDataSet

                cmbAppType.DataTextField = "TransType"

                cmbAppType.DataValueField = "TransType"

                cmbAppType.DataBind()

                cmbAppType.Items.Insert(0, New ListItem("All", "All"))

                '----------------------------------

            Catch ex As Exception


            End Try

            '----------------------------------

        Catch ex As Exception


        End Try


    End Sub


    Sub Get_Attachments(Office)

        Try

            '----------------------------------


            Dim _nGridView As New GridView

            _nGridView = GridViewDetails

            _nGridView.DataSourceID = Nothing


            Dim _nClass As New cDalAppointment

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nClass._pSubSelectAttachments(Office)


            Dim _nDataTable As New DataTable

            _nDataTable = _nClass._pDataTable


            Try

                '----------------------------------        

                If _nDataTable.Rows.Count > 0 Then

                    _nGridView.DataSource = _nDataTable

                    _nGridView.DataBind()

                Else


                End If

                '----------------------------------

            Catch ex As Exception


            End Try

            '----------------------------------

        Catch ex As Exception




        End Try


    End Sub

    Sub Download_Selected(SeqID)

        Dim FileData As Byte()

        Dim FileName As String

        Dim FileType As String

        Dim _nClass As New cDalAppointment

        cDalAppointment._mSqlCon = cGlobalConnections._pSqlCxn_OAIMS

        _nClass._pSubSelectSpecificAttachment(hdnEmail.Value, hdnReqDesc.Value, hdnAcctID.Value, SeqID, FileData, FileType, FileName)

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


    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            '' Display report in New Tab
            Response.Write("<script>window.open ('Report/ReportViewer.aspx?" & _
               "ReportType=Appointment" & _
                "&OFFICE=" + cSessionUser._pOffice & _
                "&AppType=" & cmbAppType.Value & _
                 "&AppStatus= " & cmbAppStatus.Value & _
                  "&From= " & AppFrom.Value & _
                   "&To=" & AppTo.Value & "','_blank');</script>")

        Catch ex As Exception
        End Try
    End Sub

End Class