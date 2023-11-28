Imports System.IO

Public Class AppointmentScheduler
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim _nClass As New cDalAppointment

            If Not IsPostBack Then
                'Dim txtcode As String = Trim(Request.Form("txtCode"))
                'If txtcode <> Nothing Then
                '    Dim isValid As Boolean
                '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                '    _nClass._pSubGetCodeParameters(txtcode, isValid)

                '    If isValid = True Then
                '        cSessionLoader._pCode = txtcode
                '        Response.Redirect("AppointmentOthers.aspx", False)
                '        Exit Sub
                '    Else
                '        'alert invalid code
                '        Response.Write("<script>alert('Invalid Code');</script>")
                '        Exit Sub
                '    End If
                'End If

                Get_Department()
                '  Get_DepartmentTEST()
                '  Get_AppointmentTypeTEST()

            
                '    Else

                'If Request.Form("xSubmit") = "True" Then
                '    cDalAppointment._mDepartment = Request.Form("DepartmentDesc")
                '    cDalAppointment._mTransType = Request.Form("AppointmentType")
                '    cDalAppointment._mPurpose = Request.Form("Purpose")
                '    cDalAppointment._mDepartmentAbbrev = Request.Form("DepartmentValue")
                '    Response.Redirect("AppointmentOthers.aspx")
                'End If

                'Dim action = Request("__EVENTTARGET")
                'Dim val = Request("__EVENTARGUMENT")
                'Dim Enrolled_Accounts As Integer



                ''  If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("CSJDM") = True Then

                '' If val = "CAO" Then
                ''     _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
                '' ElseIf val = "BPLO" Then
                ''     _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                '' End If
                ''
                '' _nClass._pSubGetEnrolledAccounts(val, Enrolled_Accounts)
                ''
                '' If Enrolled_Accounts > 0 Then
                ''     Get_AppointmentType(val)
                ''
                '' Else
                ''     If val = "BPLO" Then
                ''         Get_AppointmentTypeNewBPonly()
                ''     End If
                '' End If

                ''  Else
                'Get_AppointmentType(val)
                ''  End If

                'cmbDepartment.SelectedIndex = action

            End If



        Catch ex As Exception
            If ex.HResult = "-2147467259" Then
                Dim _nClass As New cDalAppointment
                _nClass._pSubSetFlag(cSessionUser._pUserID, ex.Message, ex.HResult)
                Response.Write("<script>alert('Invalid Code');</script>")
            End If
        End Try




    End Sub

    Sub upload_Docs()
        Dim _nclass As New cDalAppointment
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

        Dim Exists As Boolean
        Dim Email As String = cSessionUser._pUserID
        Dim RefNo As String = 0
        Dim ModuleID As String = "Appointment Request"
        Dim AcctID As String = cDalAppointment._mTransType
        Dim Office As String = cDalAppointment._mDepartmentAbbrev

        If up1.PostedFile IsNot Nothing And up1.PostedFile.ContentLength > 0 Then
            Dim SeqID As String = "011" 'appointmentRequestSeqNo
            Dim ReqDesc As String = "Appointment Attachment"
            Dim FileData As HttpPostedFile = up1.PostedFile
            Dim FileName As String = up1.PostedFile.FileName
            Dim FileType As String = up1.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
            'upload new file
            _nclass._pSubInsertAttachFiles(Email, RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)

        End If


    End Sub
   
    Sub Get_AppointmentTypeNewBPonly()
        Try
            '----------------------------------
            cmbType.DataSourceID = Nothing

            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetRequirementsNewBPonly()


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then

                    '_mSubShowBlank()
                End If

                cmbType.DataSource = _nDataSet
                cmbType.DataTextField = "Type"
                cmbType.DataValueField = "Content"
                cmbType.DataBind()
                cmbType.Items.Insert(0, New ListItem("Select", ""))

                '----------------------------------
            Catch ex As Exception

                '_mSubShowBlank()
            End Try
            '----------------------------------
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

                '----------------------------------
            Catch ex As Exception

                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    'Sub Get_DepartmentTEST()
    '    Try
    '        '----------------------------------
    '        test1.DataSourceID = Nothing

    '        Dim _nClass As New cDalAppointment
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

    '        _nClass._pSubGetDepartmentAppointment()


    '        Dim _nDataSet As New DataSet()
    '        _nDataSet = _nClass._pDataSet

    '        Try
    '            '----------------------------------
    '            If _nDataSet.HasErrors Then

    '                '_mSubShowBlank()
    '            End If

    '            test1.DataSource = _nDataSet
    '            test1.DataTextField = "Department"
    '            test1.DataValueField = "UserType"
    '            test1.DataBind()
    '            test1.Items.Insert(0, New ListItem("Select", ""))

    '            '----------------------------------
    '        Catch ex As Exception

    '            '_mSubShowBlank()
    '        End Try
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try

    'End Sub

    'Sub Get_AppointmentTypeTEST()
    '    Try
    '        '----------------------------------
    '        test2.DataSourceID = Nothing

    '        Dim _nClass As New cDalAppointment
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
    '        _nClass._pSubGetRequirementsTEST()


    '        Dim _nDataSet As New DataSet()
    '        _nDataSet = _nClass._pDataSet

    '        Try
    '            '----------------------------------
    '            If _nDataSet.HasErrors Then

    '                '_mSubShowBlank()
    '            End If

    '            test2.DataSource = _nDataSet
    '            test2.DataTextField = "Type"
    '            test2.DataValueField = "Department"
    '            test2.DataBind()
    '            test2.Items.Insert(0, New ListItem("Select", ""))

    '            If _nDataSet.Tables(0).Rows.Count = 0 Then
    '                test2.Items.Insert(1, New ListItem("Others", "Others"))
    '            End If





    '            '----------------------------------
    '        Catch ex As Exception

    '            '_mSubShowBlank()
    '        End Try
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try

    'End Sub
    Sub Get_AppointmentType(Department)
        Try
            '----------------------------------
            cmbType.DataSourceID = Nothing

            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetRequirements(Department)


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then

                    '_mSubShowBlank()
                End If

                cmbType.DataSource = _nDataSet
                cmbType.DataTextField = "Type"
                cmbType.DataValueField = "Content"
                cmbType.DataBind()
                cmbType.Items.Insert(0, New ListItem("Select", ""))

                If _nDataSet.Tables(0).Rows.Count = 0 Then
                    cmbType.Items.Insert(1, New ListItem("Others", "Others"))
                End If





                '----------------------------------
            Catch ex As Exception

                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnNext_ServerClick(sender As Object, e As EventArgs) Handles btnNext.ServerClick
        If String.IsNullOrEmpty(xDeptDesc.Value) Then
            Response.Write("<script>alert('Appointment Type cannot be empty.');</script>")
            Exit Sub
        End If

        If String.IsNullOrEmpty(xAppType.Value) Then
            Response.Write("<script>alert('Appointment Type cannot be empty.');</script>")
            Exit Sub
        End If

        cDalAppointment._mDepartment = xDeptDesc.Value
        cDalAppointment._mTransType = xAppType.Value
        cDalAppointment._mPurpose = xAppPurpose.Value
        cDalAppointment._mDepartmentAbbrev = xDeptVal.Value
        Response.Redirect("AppointmentOthers.aspx")

        '     Dim _nClass As New cDalAppointment
        '   _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '     '    Dim isOK As Boolean
        '  _nClass._pSubIfAlreadyRequested(cSessionUser._pUserID, cDalAppointment._mTransType, cDalAppointment._mDepartment, cDalAppointment._mPurpose, isOK)

        '    If isOK = True Then
        'upload_Docs()
        '_nClass._pSubInsertAppointmentRequest(cSessionUser._pUserID, cDalAppointment._mTransType, cDalAppointment._mDepartment, cDalAppointment._mPurpose)
        'Dim Particulars As String = "Appointment Type=" & cDalAppointment._mTransType & _
        '                ";Purpose(if others)=" & cDalAppointment._mPurpose & _
        '                ";Request Status=Pending Approval;"

        'Dim _nClass3 As New cDalTransactionHistory
        '_nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '_nClass3._pSubInsertHistory("-",
        '                            cSessionUser._pUserID,
        '                            "Appointment Request",
        '                            cDalAppointment._mTransType,
        '                            "Office: " & cDalAppointment._mDepartment,
        '                            Particulars,
        '                            "Pending Approval")


        'Response.Write("<script>alert('You appointment request has been sent to designated office for Approval. You will be notified through your registered email address together with Appointment Code once approved.');window.location.href = 'Account.aspx';</script>")

        '    Else
        '    Response.Write("<script>alert('You have pending appointment request, please wait for the approval of you request.');</script>")
        '   End If
    End Sub

    Private Sub cmbDepartment_ServerChange(sender As Object, e As EventArgs) Handles cmbDepartment.ServerChange
        Get_AppointmentType(cmbDepartment.Value)
    End Sub
End Class