Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.Services
Imports Microsoft.Reporting.WebForms
Imports System.Security.Cryptography
Imports SPIDC.Resources

Public Class Scheduler
    Inherits System.Web.UI.Page
    <WebMethod>
    Public Shared Function GetEvents() As IList
        Dim events As IList = New List(Of [Event])()

        Dim _nSqlCommand As SqlCommand
        Dim _nDataTable As DataTable
        Dim _nQuery As String = Nothing
        Dim colorseleced
        Dim eventselected = cSessionLoader._pSelectedEventID
        Dim office As String = cDalAppointment._mDepartmentAbbrev
        _nQuery = "SELECT AppDate, Beg_AM_Slot, case when AppDate =convert(varchar, getdate(), 1) and datepart(hour,getdate())>12 then 0   else  AM_Slot end as 'AM_Slot' , Beg_PM_Slot, case when AppDate =convert(varchar, getdate(), 1) and datepart(hour,getdate())>=17 then 0   else  PM_Slot end as 'PM_Slot', Color, Office FROM AppointmentSlot WHERE        (Office = '" & office & "') AND (DATEADD(d, 1, AppDate) >= (SELECT        GETDATE() AS Expr1)) ORDER BY AppDate"

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
                       .Url = "Scheduler.aspx?EventID=" & EvId & "AM&EventDate=" & Format(_nSqlDr.Item("AppDate"), "yyyy-MM-dd") & "&EventTime=AM",
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
                       .Url = "Scheduler.aspx?EventID=" & EvId & "PM&EventDate=" & Format(_nSqlDr.Item("AppDate"), "yyyy-MM-dd") & "&EventTime=PM",
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

            If Not IsPostBack Then
                '  cDalAppointment._mDepartmentAbbrev = ""
                txtName.Value = cDalAppointment.TaxpayerName
                txtContact.Value = cDalAppointment.TaxpayerContact
                txtAcctNo.Value = cSessionLoader._pAccountNo
                txtPurpose.Value = cDalAppointment._mPurpose
                Get_Department()
                If String.IsNullOrEmpty(Request.QueryString("EventID")) Then
                    cSessionLoader._pSelectedEventID = ""
                    cSessionLoader._pSelectedEventDate = ""
                    cSessionLoader._pSelectedEventTime = ""
                Else
                    cSessionLoader._pSelectedEventID = Request.QueryString("EventID")
                    cSessionLoader._pSelectedEventDate = Request.QueryString("EventDate")
                    cSessionLoader._pSelectedEventTime = Request.QueryString("EventTime")

                    cDalAppointment.TaxpayerName = txtName.Value
                    cDalAppointment.TaxpayerContact = txtContact.Value
                    cDalAppointment._mPurpose = txtPurpose.Value
                    cDalAppointment._mTransType = cmbType.SelectedItem.Text
                    cDalAppointment._mDepartmentAbbrev = cmbDepartment.SelectedValue
                    cDalAppointment._mDepartment = cmbDepartment.SelectedItem.Text
                    cSessionLoader._pAccountNo = txtAcctNo.Value

                    txtName.Attributes.Add("disabled", "disabled")
                    txtContact.Attributes.Add("disabled", "disabled")
                    txtAcctNo.Attributes.Add("disabled", "disabled")
                    cmbDepartment.Attributes.Add("disabled", "disabled")
                    cmbType.Attributes.Add("disabled", "disabled")
                    txtPurpose.Attributes.Add("disabled", "disabled")

                    div_Calendar.Style.Add("display", "")
                    btnNext.Style.Add("display", "none")
                    btnReset.Style.Add("display", "")
                End If
            End If


        Catch ex As Exception

        End Try




    End Sub
    Sub Get_Department()
        Try
            '----------------------------------
            cmbDepartment.DataSourceID = Nothing

            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nClass._pSubGetDepartmentAppointment()


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then

                    '_mSubShowBlank()
                End If

                cmbDepartment.DataSource = _nDataSet
                cmbDepartment.DataTextField = "Department"
                cmbDepartment.DataValueField = "UserType"
                cmbDepartment.DataBind()
                cmbDepartment.Items.Insert(0, New ListItem("Select", ""))

                If String.IsNullOrEmpty(cDalAppointment._mDepartmentAbbrev) Then
                    'do nothing
                Else
                    cmbDepartment.SelectedValue = cDalAppointment._mDepartmentAbbrev
                    Department_Changed()
                End If




                '----------------------------------
            Catch ex As Exception

                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Sub Department_Changed()
        Try
            cDalAppointment.TaxpayerName = txtName.Value
            cDalAppointment.TaxpayerContact = txtContact.Value
            cSessionLoader._pAccountNo = txtAcctNo.Value
            cDalAppointment._mPurpose = txtPurpose.Value
            cDalAppointment._mDepartmentAbbrev = cmbDepartment.SelectedValue
            cDalAppointment._mDepartment = cmbDepartment.SelectedItem.Text
            cmbType.DataSourceID = Nothing
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetRequirements(cmbDepartment.SelectedValue)
            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet
            cmbType.DataSource = _nDataSet
            cmbType.DataTextField = "Type"
            cmbType.DataValueField = "Content"
            cmbType.DataBind()

            If _nDataSet.Tables(0).Rows.Count > 0 Then
                cmbType.Items.Insert(0, New ListItem("Select", ""))
            End If


            If String.IsNullOrEmpty(cDalAppointment._mTransType) Then

            Else
                cmbType.SelectedValue = cmbType.Items.FindByText(cDalAppointment._mTransType).Value
                Type_Changed()
            End If
            '    cDalAppointment._mTransType = ""



        Catch ex As Exception

        End Try
    End Sub

    Sub Type_Changed()
        cDalAppointment.TaxpayerName = txtName.Value
        cDalAppointment.TaxpayerContact = txtContact.Value
        cDalAppointment._mTransType = cmbType.SelectedItem.Text

        'If String.IsNullOrEmpty(cDalAppointment._mTransType) Then
        'Else
        '    cmbType.SelectedValue = cDalAppointment._mTransType
        'End If

        cDalAppointment._mDepartmentAbbrev = cmbDepartment.SelectedValue
        div_Reqs.InnerHtml = cmbType.SelectedValue
    End Sub

    Sub ShowModal(ByVal ModalName As String)
        Try
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script>$('#" & ModalName & "').modal('show');</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "ShowModal", sb.ToString())
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _btnSave_ServerClick(sender As Object, e As EventArgs) Handles _btnSave.ServerClick
        Try
            cDalAppointment.TaxpayerName = txtName.Value
            cDalAppointment.TaxpayerContact = txtContact.Value
            cDalAppointment._mPurpose = txtPurpose.Value
            cDalAppointment._mTransType = cmbType.SelectedItem.Text
            cDalAppointment._mDepartmentAbbrev = cmbDepartment.SelectedValue
            cDalAppointment._mDepartment = cmbDepartment.SelectedItem.Text
            cSessionLoader._pSelectedEventID = Request.QueryString("EventID")
            cSessionLoader._pSelectedEventDate = Request.QueryString("EventDate")
            cSessionLoader._pSelectedEventTime = Request.QueryString("EventTime")
            cSessionLoader._pAccountNo = txtAcctNo.Value

            'Save Appointment
            Dim _nclass As New cDalAppointment
            _nclass._pSubAutoID(cSessionLoader._pSelectedEventDate, cSessionLoader._pSelectedEventTime)
            cSessionLoader._pAppID = _nclass._pEventID

            _nclass._pSubInsertAppointmentOTHERS(
                cSessionUser._pUserID,
                cDalAppointment._mTransType,
                cSessionLoader._pSelectedEventDate,
                cSessionLoader._pSelectedEventTime,
                cSessionLoader._pAppID,
                cDalAppointment.TaxpayerName & ";" & cDalAppointment.TaxpayerContact,
                cSessionLoader._pAccountNo,
                "Pending",
                "[ON-PREMISE SCHEDULED APPOINTMENT] <br> BIN/TDN : " & cSessionLoader._pAccountNo,
                cDalAppointment._mDepartmentAbbrev,
                cDalAppointment._mPurpose,
                GetHashMD5(cSessionUser._pUserID + cDalAppointment._mTransType + cSessionLoader._pSelectedEventTime + cDalAppointment._mDepartmentAbbrev + cSessionLoader._pAppID))
            _nclass._pSubUpdateAppointmentSlot(cSessionLoader._pSelectedEventDate, cSessionLoader._pSelectedEventTime, cDalAppointment._mDepartmentAbbrev)

            'Save to History
            Dim Particulars As String = "Appointment ID=" & cSessionLoader._pAppID & _
                                            ";Appointment Type=" & cDalAppointment._mTransType & _
                                            ";Purpose(if others)=" & cDalAppointment._mPurpose = "" & _
                                            ";Appointment Date=" & Format(CDate(cSessionLoader._pSelectedEventDate), "MMMM dd, yyyy") & " " & cSessionLoader._pSelectedEventTime & ";"


            Dim _nClass3 As New cDalTransactionHistory
            _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass3._pSubInsertHistory(cSessionLoader._pAppID,
                                        cSessionUser._pUserID,
                                        cSessionLoader._pAccountNo,
                                        cDalAppointment._mTransType,
                                        "Office: " & cDalAppointment._mDepartmentAbbrev,
                                        Particulars,
                                        "Pending")

            Dim Emails As String = Nothing
            Dim sent As Boolean
            Dim Body As String = "Taxpayer has applied for Appointment with the following details: <br/> " & _
                    "<table> " &
                    "<tr>" &
                    "   <td>Name</td>" &
                    "   <td>" & cDalAppointment.TaxpayerName & "</td>" &
                    "</tr> " &
                    "<tr>" &
                    "   <td>Appointment ID</td>" &
                    "   <td>" & cSessionLoader._pAppID & "</td>" &
                    "</tr> " &
                    "<tr>" &
                    "   <td>Appointment Type</td>" &
                    "   <td>" & cDalAppointment._mTransType & "</td>" &
                    "</tr> " &
                    "<tr>" &
                    "   <td>Purpose (if selected Type is [OTHERS])</td>" &
                    "   <td>" & cDalAppointment._mPurpose & "</td>" &
                    "</tr> " &
                    "<tr>" &
                    "   <td>Appointment Date</td>" &
                    "   <td>" & Format(CDate(cSessionLoader._pSelectedEventDate), "MMMM dd, yyyy") & " " & cSessionLoader._pSelectedEventTime & "</td>" &
                    "</tr> " &
                    "</table> <br/>" &
                    "<i style='color:blue'><b>[On-Premise Scheduled Appointment]</b></i>" &
                    "<br> Please login to your Web Account to Check the Appointment. Thank you <br><br>"

            cDalNewSendEmail.get_Emails(cDalAppointment._mDepartmentAbbrev, Emails)
            cDalNewSendEmail.SendEmail(Emails, "Taxpayer Appointment", Body, sent, , 1)


            lblAppDate.InnerText = Format(CDate(cSessionLoader._pSelectedEventDate), "MMMM dd, yyyy") & " " & cSessionLoader._pSelectedEventTime
            lblAppID.InnerText = cSessionLoader._pAppID
            lblContact.InnerText = cDalAppointment.TaxpayerContact
            lblDepartment.InnerText = cDalAppointment._mDepartment
            lblName.InnerText = cDalAppointment.TaxpayerName
            lblPurpose.InnerText = cDalAppointment._mPurpose
            lblType.InnerText = cDalAppointment._mTransType
            lblRemarks.InnerHtml = "[ON-PREMISE SCHEDULED APPOINTMENT] <br> BIN/TDN : " & cSessionLoader._pAccountNo
            'Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=AppointmentSlip&AppID=" & cSessionLoader._pAppID & "','_blank');</script>")
            ShowModal("AppointmentSummary")
            Clear()
            Exit Sub

        Catch ex As Exception

        End Try
    End Sub

    Sub Clear()
        cDalAppointment.TaxpayerName = Nothing
        cDalAppointment.TaxpayerContact = Nothing
        cDalAppointment.REMARKS = Nothing
        cDalAppointment._mPurpose = Nothing
        cDalAppointment._mTransType = Nothing
        cDalAppointment._mDepartmentAbbrev = Nothing
        cDalAppointment._mDepartment = Nothing
        cSessionLoader._pSelectedEventID = Request.QueryString("EventID")
        cSessionLoader._pSelectedEventDate = Request.QueryString("EventDate")
        cSessionLoader._pSelectedEventTime = Request.QueryString("EventTime")
        cSessionLoader._pAccountNo = Nothing
        cSessionLoader._pAppID = Nothing

        txtName.Value = Nothing
        txtContact.Value = Nothing
        txtPurpose.Value = Nothing
        cmbDepartment.Items.Clear()
        cmbType.Items.Clear()
        txtAcctNo.Value = Nothing
        div_Reqs.InnerHtml = Nothing
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

    Public Sub SnackBar(ByVal color As String, ByVal msg As String)
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Appointment", "ShowSnackBar('" & color & "','" & msg & "');", True)

    End Sub

    Private Sub btnDone_ServerClick(sender As Object, e As EventArgs) Handles btnDone.ServerClick
        Response.Redirect("Scheduler.aspx")
    End Sub

    Private Sub btnNext_ServerClick(sender As Object, e As EventArgs) Handles btnNext.ServerClick
        Try
            cDalAppointment.TaxpayerName = txtName.Value
            cDalAppointment.TaxpayerContact = txtContact.Value
            cDalAppointment._mPurpose = txtPurpose.Value
            cDalAppointment._mTransType = cmbType.SelectedItem.Text
            cDalAppointment._mDepartmentAbbrev = cmbDepartment.SelectedValue
            cDalAppointment._mDepartment = cmbDepartment.SelectedItem.Text
            cSessionLoader._pAccountNo = txtAcctNo.Value

            txtName.Attributes.Add("disabled", "disabled")
            txtContact.Attributes.Add("disabled", "disabled")
            txtAcctNo.Attributes.Add("disabled", "disabled")
            cmbDepartment.Attributes.Add("disabled", "disabled")
            cmbType.Attributes.Add("disabled", "disabled")
            txtPurpose.Attributes.Add("disabled", "disabled")

            div_Calendar.Style.Add("display", "")
            btnNext.Style.Add("display", "none")
            btnReset.Style.Add("display", "")

            'cSessionLoader._pSelectedEventID = Request.QueryString("EventID")
            'cSessionLoader._pSelectedEventDate = Request.QueryString("EventDate")
            'cSessionLoader._pSelectedEventTime = Request.QueryString("EventTime")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReset_ServerClick(sender As Object, e As EventArgs) Handles btnReset.ServerClick
        Clear()
        Response.Redirect("Scheduler.aspx")
    End Sub


End Class