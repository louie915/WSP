
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Services
Imports System.Collections
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Net
Imports System.Security
Imports System.Security.Cryptography
Imports QRCoder
Imports System.Drawing
Imports javax.mail.util.ByteArrayDataSource
Imports org.apache.commons.mail.ImageHtmlEmail

Public Class AppointmentOthers
    Inherits System.Web.UI.Page

    Dim Office As String = cDalAppointment._mDepartmentAbbrev
    <WebMethod>
    Public Shared Function GetEvents() As IList
        Dim events As IList = New List(Of [Event])()

        Dim _nSqlCommand As SqlCommand
        Dim _nDataTable As DataTable
        Dim _nQuery As String = Nothing
        Dim colorseleced
        Dim eventselected = cSessionLoader._pSelectedEventID
        Dim office As String = cDalAppointment._mDepartmentAbbrev
        '_nQuery = "Select * from AppointmentSlot WHERE OFFICE='" & office & "' AND dateadd(d,1,appdate) >=  (SELECT GETDATE()) ORDER BY APPDATE"
        _nQuery = "SELECT        AppDate, Beg_AM_Slot, case when AppDate =convert(varchar, getdate(), 1) and datepart(hour,getdate())>12 then 0   else  AM_Slot end as 'AM_Slot' , Beg_PM_Slot, case when AppDate =convert(varchar, getdate(), 1) and datepart(hour,getdate())>=17 then 0   else  PM_Slot end as 'PM_Slot', Color, Office FROM AppointmentSlot WHERE        (Office = '" & office & "') AND (DATEADD(d, 1, AppDate) >= (SELECT        GETDATE() AS Expr1)) ORDER BY AppDate"



        _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
        Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
        _nDataTable = New DataTable
        _nSqlDataAdapter.Fill(_nDataTable)

        Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
            If _nSqlDr.HasRows Then
                Do While _nSqlDr.Read()
                    Dim d As String = _nSqlDr.Item("AppDate").day
                    Dim m As String = _nSqlDr.Item("AppDate").month
                    If d < 10 Then d = 0 & d
                    If m < 10 Then m = 0 & m
                    Dim y As String = _nSqlDr.Item("AppDate").year
                    Dim EvId As String = m & d & y
                    Dim EvIdAM As String = EvId & "AM"
                    Dim EvIdPM As String = EvId & "PM"

                    If EvIdAM = cSessionLoader._pSelectedEventID Then
                        colorseleced = "green"
                    Else
                        colorseleced = "#5070DA"
                    End If
                    If _nSqlDr.Item("AM_Slot") > 0 Then
                        events.Add(New [Event] With {
                       .EventID = EvId & "AM",
                       .EventName = "AM Slots " & _nSqlDr.Item("AM_Slot"),
                       .StartDate = _nSqlDr.Item("AppDate").ToString,
                       .EndDate = _nSqlDr.Item("AppDate").ToString,
                       .Url = "AppointmentOthers.aspx?EventID=" & EvId & "AM&EventDate=" & Format(_nSqlDr.Item("AppDate"), "yyyy-MM-dd") & "&EventTime=AM",
                       .Color = colorseleced
                   })
                    End If

                    If EvIdPM = cSessionLoader._pSelectedEventID Then
                        colorseleced = "green"
                    Else
                        colorseleced = "#5070DA"
                    End If

                    If _nSqlDr.Item("PM_Slot") > 0 Then
                        events.Add(New [Event] With {
                       .EventID = EvId & "PM",
                       .EventName = "PM Slots " & _nSqlDr.Item("PM_Slot"),
                       .StartDate = _nSqlDr.Item("AppDate").ToString,
                       .EndDate = _nSqlDr.Item("AppDate").ToString,
                       .Url = "AppointmentOthers.aspx?EventID=" & EvId & "PM&EventDate=" & Format(_nSqlDr.Item("AppDate"), "yyyy-MM-dd") & "&EventTime=PM",
                        .Color = colorseleced
                        })
                    End If

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
            If Not IsPostBack Then

                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                End If


                txtDepartment.InnerText = cDalAppointment._mDepartment
                txtTransType.InnerText = cDalAppointment._mTransType
                txtPurpose.InnerText = cDalAppointment._mPurpose

                _oLabelTransType.InnerText = cDalAppointment._mTransType
                _oLabelDepartment.InnerText = cDalAppointment._mDepartment
                _oLabelPurpose.InnerText = cDalAppointment._mPurpose

                If String.IsNullOrEmpty(Request.QueryString("EventID")) Then
                    cSessionLoader._pSelectedEventID = ""
                    cSessionLoader._pSelectedEventDate = ""
                    cSessionLoader._pSelectedEventTime = ""

                Else
                    cSessionLoader._pSelectedEventID = Request.QueryString("EventID")
                    cSessionLoader._pSelectedEventDate = Request.QueryString("EventDate")
                    cSessionLoader._pSelectedEventTime = Request.QueryString("EventTime")
                    _oLabelAppDate.InnerText = Convert.ToDateTime(Request.QueryString("EventDate")).ToString("MMMM dd, yyyy") & " " & Request.QueryString("EventTime") '-ex: January 1, 2020

                End If

            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")
                If action = "btnUpload" Then
                    '      upload_Docs()
                End If


            End If
            '----------------------------------
        Catch ex As Exception



        End Try
    End Sub
    Sub upload_Docs(ByVal APPID As String)
        Dim _nclass As New cDalAppointment
        Dim EventID As String = cSessionLoader._pSelectedEventID
        Dim EventDate As String = cSessionLoader._pSelectedEventDate
        Dim EventTime As String = cSessionLoader._pSelectedEventTime

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubAutoID(EventDate, EventTime)

        Dim Exists As Boolean
        Dim Email As String = cSessionUser._pUserID
        Dim RefNo As String = APPID
        Dim ModuleID As String = cSessionLoader._pSelectedEventID
        Dim AcctID As String = cDalAppointment._mTransType
        Dim Office As String = cDalAppointment._mDepartmentAbbrev

        If up1.PostedFile IsNot Nothing And up1.PostedFile.ContentLength > 0 Then
            Dim SeqID As String = "010" 'appointmentUploadSeqNo
            Dim ReqDesc As String = "Appointment Attachment"
            Dim FileData As HttpPostedFile = up1.PostedFile
            Dim FileName As String = up1.PostedFile.FileName
            Dim FileType As String = up1.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(Email, ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            cDalAppointment._pFile001 = FileName
            lblup1.InnerText = FileName
        End If


    End Sub
    Private Function _FnNotify_Taxpayer(ImgUrl, Hash) As Boolean
        Try
            Dim Sent As Boolean
            Dim Subject As String = "Appointment Schedule Confirmation"
            Dim stime As String
            If cSessionLoader._pSelectedEventTime = "AM" Then stime = "8AM - 12NN"
            If cSessionLoader._pSelectedEventTime = "PM" Then stime = "1PM - 5PM"
            Dim Body As String = "Dear Valued Tax Payer, <br><br>" & _
                     "This confirms your appointment with the following details: <br> <br>" & _
                     "<table>" & _
                     "<tr><td>Name</td> <td>:</td>" & _
                     "    <td>" & cSessionUser._pFirstName & " " & cSessionUser._pLastName & "</td> </tr>" & _
                     "<tr><td>Department</td> <td>:</td>" & _
                     "    <td>" & cDalAppointment._mDepartment & "</td> </tr>" & _
                     "<tr><td>Transaction Type</td> <td>:</td>" & _
                     "    <td>" & cSessionLoader._pService & "</td> </tr>" & _
                     "<tr><td>Appointment ID</td><td>:</td>" & _
                     "    <td>" & cSessionLoader._pAppID & "</td></tr>" & _
                     "<tr><td>Date</td><td>:</td>" & _
                     "    <td>" & _oLabelAppDate.InnerText & "</td></tr>" & _
                     "<tr> <td>Time</td><td>:</td>" & _
                     "    <td>" & stime & "</td></tr>" & _
                     "</table>" & _
                     "<b><i>Please save a copy of this email including the Attached QR code and present it on your appointment date/time.</i></b>" & _
                     "<br/> Thank you for choosing our Web Service Portal. Have a wonderful day!</td></tr>"

            Dim IDno As String = "Appointment ID : " & cSessionLoader._pAppID


            Dim Logo_Data As Byte()
            Dim Logo_Name As String
            Dim Logo_Ext As String
            cDalNewSendEmail.get_Header_DATA(Logo_Data, Logo_Name, Logo_Ext)
            Dim Logo_IMG As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
            Logo_IMG.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(Logo_Data)



            cDalNewSendEmail.SendEmailWithQR(cSessionUser._pUserID, Subject, Body, ImgUrl, Logo_IMG.ImageUrl, Sent, IDno, Nothing, "")
            Return Sent

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
    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If up1.PostedFile IsNot Nothing And up1.PostedFile.ContentLength > 0 Then
            Dim _nclass As New cDalAppointment
            Dim EventID As String = cSessionLoader._pSelectedEventID
            Dim EventDate As String = cSessionLoader._pSelectedEventDate
            Dim EventTime As String = cSessionLoader._pSelectedEventTime
            Dim valid As Boolean
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nclass._pSubValidateAppointment(cSessionLoader._pSelectedEventDate, cSessionLoader._pSelectedEventTime, cDalAppointment._mDepartmentAbbrev, valid)

            If valid = True Then
                _nclass._pSubAutoID(EventDate, EventTime)
                cSessionLoader._pAppID = _nclass._pEventID
                cSessionLoader._pService = cDalAppointment._mTransType

                Dim AppID As String = _nclass._pEventID
                Dim email As String = cSessionUser._pUserID
                Dim Appdate As String = cSessionLoader._pSelectedEventDate
                Dim AppTime As String = cSessionLoader._pSelectedEventTime
                Dim Owner As String = cSessionUser._pFirstName & " " & cSessionUser._pMiddleName & " " & cSessionUser._pLastName
                Dim Status As String = "Pending Approval"
                Dim Remarks As String = ""
                Dim Department As String = cDalAppointment._mDepartment
                Dim TransType As String = cDalAppointment._mTransType
                Dim Purpose As String = cDalAppointment._mPurpose
                Dim DeptAbbrev As String = cDalAppointment._mDepartmentAbbrev
                Dim RefNo As String = cSessionLoader._pAppID
                Dim ModuleID As String = cSessionLoader._pSelectedEventID
                Dim AcctID As String = "Appointment"

                Try
                    upload_Docs(AppID)
                Catch ex As Exception

                End Try

                Dim Hash As String = GetHashMD5(email + TransType + EventTime + DeptAbbrev + AppID)
                Dim code As String = Hash

                Dim qrGenerator As New QRCodeGenerator
                Dim qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q)
                Dim imgBarCode As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
                Dim QR_CODE As New QRCode(qrCode)
                imgBarCode.Height = 350
                imgBarCode.Width = 350

                Using bitMap As Bitmap = QR_CODE.GetGraphic(6)
                    Using ms As MemoryStream = New MemoryStream()
                        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                        Dim byteImage As Byte() = ms.ToArray()
                        imgBarCode.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
                    End Using
                    'imgBarCode
                End Using
                Dim newDate As String = Format(CDate(Appdate), "MMMM dd, yyyy")


                Dim Particulars As String = "Appointment ID=" & AppID & _
                                            ";Appointment Type=" & TransType & _
                                            ";Purpose(if others)=" & Purpose & _
                                            ";Appointment Date=" & newDate & " " & AppTime & ";"

                Dim _nClass3 As New cDalTransactionHistory
                _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass3._pSubInsertHistory(AppID,
                                            email,
                                            AcctID,
                                            TransType,
                                            "Office: " & DeptAbbrev,
                                            Particulars,
                                            Status)

                Dim _err As String = Nothing
                Dim _errALL As String = Nothing
                '     If _FnNotify_Taxpayer(imgBarCode.ImageUrl, Hash) = True Then

                _oLabelPurpose.InnerText = cDalAppointment._mPurpose
                _nclass._pSubInsertAppointmentOTHERS(email, TransType, Appdate, AppTime, AppID, Owner, AcctID, Status, Remarks, DeptAbbrev, Purpose, Hash, _err)
                _errALL += _err
                '  _nclass._pSubUpdateAppointmentSlot(Appdate, AppTime, DeptAbbrev, _err)
                '   _errALL += _err
                _nclass._pSubUpdateAttachRefNo(email, RefNo, ModuleID, AcctID, Appdate, AppTime, _err)
                _errALL += _err
                '   _nclass._pSubUpdateAppointmentCode(email, cSessionLoader._pCode, _err)
                '  _errALL += _err

                'If String.IsNullOrEmpty(_errALL) = False Then
                '    hdnErr.Value = _errALL
                '    '  Response.Write("<script>alert('Failed to send email confirmation, Pleace check your connection and try again.')</script>")
                '    snackbar("red", "Something went wrong, Please contact Administrator.")
                '    Exit Sub
                'End If

                Dim Emails As String
                Dim sent As Boolean
                Dim Body As String = "Taxpayer has applied for Appointment with the following details: <br/> " & _
                        "<table> " &
                        "<tr>" &
                        "   <td>Email Address</td>" &
                        "   <td>:</td>" &
                        "   <td>" & cSessionUser._pUserID & "</td>" &
                        "</tr> " &
                        "<tr>" &
                        "   <td>Appointment ID</td>" &
                        "   <td>:</td>" &
                        "   <td>" & AppID & "</td>" &
                        "</tr> " &
                        "<tr>" &
                        "   <td>Appointment Type</td>" &
                        "   <td>:</td>" &
                        "   <td>" & TransType & "</td>" &
                        "</tr> " &
                        "<tr>" &
                        "   <td>Purpose (if others)</td>" &
                        "   <td>:</td>" &
                        "   <td>" & Purpose & "</td>" &
                        "</tr> " &
                        "<tr>" &
                        "   <td>Appointment Date</td>" &
                        "   <td>:</td>" &
                        "   <td>" & newDate & " " & AppTime & "</td>" &
                        "</tr> " &
                        "<tr>" &
                        "   <td>Request Status</td>" &
                        "   <td>:</td>" &
                        "   <td>" & Status & "</td>" &
                        "</tr> " &
                        "</table> <br/>" &
                        "<br> Please login to your Web Account to Check the Appointment Request. Thank you <br><br>"

                cDalNewSendEmail.get_Emails(DeptAbbrev, Emails)
                cDalNewSendEmail.SendEmail(Emails, "Taxpayer Appointment", Body, sent, , 1)

                Emails = Nothing
                sent = Nothing
                Body = "You have applied for Appointment with the following details: <br/> " & _
                        "<table> " &
                        "<tr>" &
                        "   <td>Appointment ID</td>" &
                        "   <td>:</td>" &
                        "   <td>" & AppID & "</td>" &
                        "</tr> " &
                        "<tr>" &
                        "   <td>Appointment Type</td>" &
                        "   <td>:</td>" &
                        "   <td>" & TransType & "</td>" &
                        "</tr> " &
                        "<tr>" &
                        "   <td>Purpose (if others)</td>" &
                        "   <td>:</td>" &
                        "   <td>" & Purpose & "</td>" &
                        "</tr> " &
                        "<tr>" &
                        "   <td>Appointment Date</td>" &
                        "   <td>:</td>" &
                        "   <td>" & newDate & " " & AppTime & "</td>" &
                        "</tr> " &
                         "<tr>" &
                        "   <td>Request Status</td>" &
                        "   <td>:</td>" &
                        "   <td>" & Status & "</td>" &
                        "</tr> " &
                        "</table> <br/>" &
                        "<br> Please wait for our Staff to validate your Appointment Request. Thank you <br><br>"


                cDalNewSendEmail.SendEmail(cSessionUser._pUserID, "Appointment Request", Body, sent)


                Response.Redirect("AppointmentNotification.aspx")
                '  Else
                ' snackbar("red", "Failed to send email confirmation, Pleace check your connection and try again.")
                'Response.Write("<script>alert('Failed to send email confirmation, Pleace check your connection and try again.')</script>")
                'failed to send Email
                '  End If

            End If
        Else

            snackbar("red", "Please Upload supporting documents")

        End If

    End Sub

   
    Shared Function GetHashMD5(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function


End Class