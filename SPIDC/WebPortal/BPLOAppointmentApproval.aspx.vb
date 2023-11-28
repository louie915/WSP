
Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Imports System.Security.Cryptography
Imports QRCoder
Imports System.Drawing
Public Class BPLOAppointmentApproval
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim _nClass As New cDalAppointment
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                load_GridView()
                load_GridViewHistory()
                Get_Type(cSessionUser._pOffice)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub do_View(ByVal str As String)
        Try

        Catch ex As Exception

        End Try
        ' Your VB.NET code for the "do_View" functionality here
        ' This subroutine will be triggered when the "View" link is clicked
        ' You can implement any desired functionality here
    End Sub

    Sub load_GridView()
        Try
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.Get_AppointmentRequests(cSessionUser._pOffice, cmbTypeFilter.Value, cmb_SortBy.Value, cmb_Order.Value)
            _GVRequests.DataSource = _nClass._mDataTable
            _GVRequests.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Sub load_GridViewHistory()
        Try
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.Get_AppointmentRequestsHistory()
            _GVHistory.DataSource = _nClass._mDataTable
            _GVHistory.DataBind()
        Catch ex As Exception

        End Try
    End Sub


  

    Sub Get_Type(ByVal Office As String)
        Try
            '----------------------------------
            cmbTypeFilter.DataSourceID = Nothing
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetTypeWithAppointment(Office)

            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            cmbTypeFilter.DataSource = _nDataSet
            cmbTypeFilter.DataTextField = "Type"
            cmbTypeFilter.DataValueField = "Type"
            cmbTypeFilter.DataBind()
            cmbTypeFilter.Items.Insert(0, New ListItem("ALL", "ALL"))

        Catch ex As Exception

        End Try

    End Sub


    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Private Sub btnFilter_ServerClick(sender As Object, e As EventArgs) Handles btnFilter.ServerClick
        Try
            load_GridView()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub datagrid_PageIndexChanging_GVRequests(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            load_GridView()
            _GVRequests.PageIndex = e.NewPageIndex
            _GVRequests.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_GVHistory(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            load_GridViewHistory()
            _GVHistory.PageIndex = e.NewPageIndex
            _GVHistory.DataBind()
        Catch ex As Exception
        End Try
    End Sub



    Sub get_Uploaded(ByVal AppID As String)
        Try

            Dim FileData As Byte() = Nothing
            Dim FileName As String = Nothing
            Dim FileType As String = Nothing
            Dim ProcessedBy As String = Nothing
            Dim Remarks As String = Nothing
            Dim Status As String = Nothing
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.Get_UploadedSupDoc(AppID, FileData, FileName, FileType, ProcessedBy, Remarks, Status)

            If String.IsNullOrEmpty(Status) Then
                a_SupDoc.Attributes.Add("download", AppID & "_" & FileName)
                a_SupDoc.HRef = "data:" & FileType & ";base64," & Convert.ToBase64String(FileData)
                a_SupDoc.InnerHtml = AppID & "_" & FileName
            Else
                a_SupDoc_History.Attributes.Add("download", AppID & "_" & FileName)
                a_SupDoc_History.HRef = "data:" & FileType & ";base64," & Convert.ToBase64String(FileData)
                a_SupDoc_History.InnerHtml = AppID & "_" & FileName
            End If


            lbl_ProcessedBy.InnerText = ProcessedBy
            lbl_Status_History.InnerText = Status
            lbl_Remarks_History.InnerText = Remarks
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnApprove_ServerClick(sender As Object, e As EventArgs) Handles btnApprove.ServerClick
        Try
            Dim _err As String = Nothing
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim RemSlots As Integer = _nClass.get_RemainingSlot(hdnAppID.Value)
            If RemSlots > 0 Then
                If String.IsNullOrEmpty(Trim(txt_Remarks.Value)) = True Then
                    snackbar("red", "Remarks cannot be emtpy.")
                Else
                    _nClass._pSubUpdateAppointmentSlot(hdnAppDate.Value, hdnTime.Value, hdnOffice.Value, _err)
                    If String.IsNullOrEmpty(_err) = True Then
                        _nClass.Update_AppointmentRequest(hdnAppID.Value, txt_Remarks.Value, "Approved", "Pending")
                        Dim Hash As String = GetHashMD5(hdnEmail.Value + hdnType.Value + Trim(hdnTime.Value) + hdnOffice.Value + hdnAppID.Value)
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

                        Dim Particulars As String = "Appointment ID=" & hdnAppID.Value & _
                                                    ";Appointment Type=" & hdnType.Value & _
                                                    ";Appointment Date=" & hdnAppDate.Value & " " & hdnTime.Value & ";"

                        Dim _nClass3 As New cDalTransactionHistory
                        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                        _nClass3._pSubInsertHistory(hdnAppID.Value,
                                                    hdnEmail.Value,
                                                    "Appointment",
                                                    hdnType.Value,
                                                    "Office: " & hdnOffice.Value,
                                                    Particulars,
                                                    "Approved")



                        Dim Sent As Boolean
                        Dim Subject As String = "Appointment Schedule Confirmation"
                        Dim stime As String
                        If Trim(hdnTime.Value) = "AM" Then stime = "8AM - 12NN"
                        If Trim(hdnTime.Value) = "PM" Then stime = "1PM - 5PM"
                        Dim Body As String = "Dear Valued Tax Payer, <br><br>" & _
                                 "This confirms your appointment with the following details: <br> <br>" & _
                                 "<table>" & _
                                 "<tr><td>Name</td> <td>:</td>" & _
                                 "    <td>" & cSessionUser._pFirstName & " " & cSessionUser._pLastName & "</td> </tr>" & _
                                 "<tr><td>Department</td> <td>:</td>" & _
                                 "    <td>" & hdnOffice.Value & "</td> </tr>" & _
                                 "<tr><td>Transaction Type</td> <td>:</td>" & _
                                 "    <td>" & hdnType.Value & "</td> </tr>" & _
                                 "<tr><td>Appointment ID</td><td>:</td>" & _
                                 "    <td>" & hdnAppID.Value & "</td></tr>" & _
                                 "<tr><td>Date</td><td>:</td>" & _
                                 "    <td>" & hdnAppDate.Value & "</td></tr>" & _
                                 "<tr> <td>Time</td><td>:</td>" & _
                                 "    <td>" & stime & "</td></tr>" & _
                                 "</table>" & _
                                 "<b><i>Please arrive within the given time and save a copy of this email including the Attached QR code and present it on your appointment date/time.</i></b>" & _
                                 "<br/> Thank you for choosing our Web Service Portal. Have a wonderful day!</td></tr>"

                        Dim IDno As String = "Appointment ID : " & hdnAppID.Value


                        Dim Logo_Data As Byte()
                        Dim Logo_Name As String
                        Dim Logo_Ext As String
                        cDalNewSendEmail.get_Header_DATA(Logo_Data, Logo_Name, Logo_Ext)
                        Dim Logo_IMG As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
                        Logo_IMG.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(Logo_Data)

                        cDalNewSendEmail.SendEmailWithQR(hdnEmail.Value, Subject, Body, imgBarCode.ImageUrl, Logo_IMG.ImageUrl, Sent, IDno, Nothing, "")

                        If Sent = True Then
                            snackbar("green", "Appointment has been Approved.")
                        Else
                            snackbar("red", "Appointment has been Approved. But Failed to send Email Notification.")
                        End If


                    Else
                        snackbar("red", _err)
                    End If

                    load_GridViewHistory()
                    load_GridView()


                    Exit Sub
                End If
            Else
                snackbar("red", "No Slots left")
            End If
            lbl_Slot.InnerHtml = RemSlots

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Sub



    Private Sub btnReject_ServerClick(sender As Object, e As EventArgs) Handles btnReject.ServerClick
        Try
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            If String.IsNullOrEmpty(Trim(txt_Remarks.Value)) = True Then
                snackbar("red", "Remarks cannot be emtpy.")
                Exit Sub
            Else
                Dim ReqStatus As String = "Rejected"
                _nClass.Update_AppointmentRequest(hdnAppID.Value, txt_Remarks.Value, "Rejected", "Rejected")

                'send email to taxpayer

                Dim Emails As String
                Dim sent As Boolean
                Dim body As String = "Your Request for Appointment has been Rejected. Please see the details below: <br/> " & _
                         "<table> " &
                         "<tr>" &
                         "   <td>Appointment ID</td>" &
                         "   <td>:</td>" &
                         "   <td>" & hdnAppID.Value & "</td>" &
                         "</tr> " &
                         "<tr>" &
                         "   <td>Appointment Type</td>" &
                         "   <td>:</td>" &
                         "   <td>" & hdnType.Value & "</td>" &
                         "</tr> " &
                         "<tr>" &
                         "   <td>Appointment Date</td>" &
                         "   <td>:</td>" &
                         "   <td>" & hdnAppDate.Value & "</td>" &
                         "</tr> " &
                         "<tr>" &
                         "   <td>Request Status</td>" &
                         "   <td>:</td>" &
                         "   <td>" & ReqStatus & "</td>" &
                         "</tr> " &
                         "<tr>" &
                         "   <td>Remarks</td>" &
                         "   <td>:</td>" &
                         "   <td>" & txt_Remarks.Value & "</td>" &
                         "</tr> " &
                         "</table> <br/>"
                cDalNewSendEmail.SendEmail(hdnEmail.Value, "Appointment Request", body, sent)
                If sent = True Then
                    snackbar("green", "Appointment has been Rejected.")
                Else
                    snackbar("red", "Appointment has been Rejected. But Failed to send Email Notification.")
                End If

            End If

            load_GridViewHistory()
            load_GridView()

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Sub
    Private Sub btnView_ServerClick(sender As Object, e As EventArgs) Handles btnView.ServerClick

        Dim _nClass As New cDalAppointment
        lbl_Date.InnerHtml = Nothing
        lbl_Email.InnerHtml = Nothing
        lbl_Office.InnerHtml = Nothing
        lbl_Time.InnerHtml = Nothing
        lbl_Type.InnerHtml = Nothing
        lbl_Slot.InnerHtml = Nothing
        a_SupDoc.HRef = "#"

        lbl_Date.InnerHtml = hdnAppDate.Value
        lbl_Email.InnerHtml = hdnEmail.Value
        lbl_Office.InnerHtml = hdnOffice.Value
        lbl_Time.InnerHtml = hdnTime.Value
        lbl_Type.InnerHtml = hdnType.Value
        lbl_Slot.InnerHtml = _nClass.get_RemainingSlot(hdnAppID.Value)
        get_Uploaded(hdnAppID.Value)

        load_GridView()
        ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal('ModalView');", True)
    End Sub
    Private Sub btnView_History_ServerClick(sender As Object, e As EventArgs) Handles btnView_History.ServerClick
        Dim _nClass As New cDalAppointment
        lbl_Date.InnerHtml = Nothing
        lbl_Email.InnerHtml = Nothing
        lbl_Office.InnerHtml = Nothing
        lbl_Time.InnerHtml = Nothing
        lbl_Type.InnerHtml = Nothing
        lbl_Slot.InnerHtml = Nothing
        a_SupDoc_History.HRef = "#"
        lbl_ProcessedBy.InnerHtml = Nothing
        lbl_Remarks_History.InnerHtml = Nothing
        lbl_Status_History.InnerHtml = Nothing


        lbl_Date_history.InnerHtml = hdnAppDate_History.Value
        lbl_Email_History.InnerHtml = hdnEmail_History.Value
        lbl_Office_History.InnerHtml = hdnOffice_History.Value
        lbl_Time_History.InnerHtml = hdnTime_History.Value
        lbl_Type_History.InnerHtml = hdnType_History.Value
        get_Uploaded(hdnAppID_History.Value)
        load_GridViewHistory()
        ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal('ModalView_History');", True)
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