Imports System.Data
Imports System.Data.SqlClient
Public Class DILGInspectionRequest
    Inherits System.Web.UI.Page
    Dim Email_Subject As String
    Dim Email_Body As String
    Dim Sent As Boolean
    Dim Particulars As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loaddata_req()
        loaddata_History()
    End Sub
    Public Sub loaddata_req()
        Try
            Dim _nClass As New cDalDILG
            Dim _nQuery As String = Nothing
            _nQuery = "select * from SafetySealRequest where status = 'PENDING' order by requestdate asc"

            Dim _pSqlCmd = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _mDataAdapter1 = New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _mDataTable1 = New DataTable
            _mDataAdapter1.Fill(_mDataTable1)
            GridView1.DataSource = _mDataTable1
            GridView1.DataBind()
            'Dim _pSqlDataReader As SqlDataReader = _pSqlCmd.ExecuteReader            
            'If _pSqlDataReader.HasRows Then

            '    'ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub loaddata_History(Optional ByVal Filter As String = Nothing)
        Try
            Dim _nClass As New cDalDILG
            Dim _nQuery As String = Nothing
            _nQuery = "select * from SafetySealRequest " & _
                " where " & IIf(Not Filter = Nothing, IIf(Filter = "ALL", "status in ('APPROVED','DENIED')", _
                                IIf(Filter = "APPROVED", "status = 'APPROVED'", "status = 'DENIED'")), "status in ('APPROVED','DENIED')") & " order by assesseddate desc"
            Dim _pSqlCmd = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _mDataAdapter1 = New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _mDataTable1 = New DataTable
            _mDataAdapter1.Fill(_mDataTable1)
            GridView2.DataSource = _mDataTable1
            GridView2.DataBind()
            'Dim _pSqlDataReader As SqlDataReader = _pSqlCmd.ExecuteReader            
            'If _pSqlDataReader.HasRows Then

            '    'ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub loaddata_viewdetails(ByVal Acctno As String)        
        Dim _nQuery As String = Nothing
        _nQuery = "Select (ISNULL([FIRST_NAME],'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL([LAST_NAME],'')) as UP_Name ,ISNULL([EMAILADDR],'') as EMAILADDR, " & _
                                              "ISNULL([OWNERADDR],'') as  OWNERADDR ,ISNULL([COMMNAME],'') as COMMNAME,COMMADDR,  (ISNULL(([CONTACT]),'') + ISNULL(' ' + [CONTTEL],'') + ISNULL(' ' + [OWNERTEL],'')" & _
                                              " + ISNULL(' ' + [CPNO],'') + ISNULL(' ' + [CPNO2],'') + ISNULL(' ' + [CPNO3],'') ) as UP_Contact  from [BUSMAST] " & _
                                              "Where [ACCTNO] = @Acctno ;"
        Dim _nSqlCmd = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTAS)
        With _nSqlCmd.Parameters
            .AddWithValue("@Acctno", Acctno)
        End With
        Dim _nSqlDtr As SqlDataReader = _nSqlCmd.ExecuteReader
        If _nSqlDtr.HasRows Then
            While _nSqlDtr.Read

                _oLabelOwner.InnerText = _nSqlDtr.Item("UP_Name").ToString
                _oLabelOwnerEmail.InnerText = _nSqlDtr.Item("EMAILADDR").ToString
                _oLabelOwnerAddress.InnerText = _nSqlDtr.Item("OWNERADDR").ToString
                _oLabelCommercialName.InnerText = _nSqlDtr.Item("COMMNAME").ToString
                _oLabelCommercialAddress.InnerText = _nSqlDtr.Item("COMMADDR").ToString
                _oLabelOwnerContactNo.InnerText = _nSqlDtr.Item("UP_Contact").ToString.Replace(" ", "|")
            End While
        End If
    End Sub

    Public Sub ClearFields()
        _oLabelOwner.InnerText = ""
        _oLabelOwnerEmail.InnerText = ""
        _oLabelOwnerAddress.InnerText = ""
        _oLabelCommercialName.InnerText = ""
        _oLabelCommercialAddress.InnerText = ""
        _oLabelOwnerContactNo.InnerText = ""
    End Sub

    Public Sub Btn_Verify_click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim btn As Button = CType(sender, Button)
            ClearFields()
            _hdnAcctNo.Value = btn.CommandArgument
            Dim _nQuery As String = Nothing
            _nQuery = "select distinct * from  SafetySealRequest where acctno = @Acctno and RequestID = @RequestID;"
            Dim _nSqlCmd = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            With _nSqlCmd.Parameters
                .AddWithValue("@Acctno", btn.CommandArgument)
                .AddWithValue("@RequestID", btn.CommandName)
            End With
            Dim _nSqlDtr As SqlDataReader = _nSqlCmd.ExecuteReader
            If _nSqlDtr.HasRows Then
                While _nSqlDtr.Read
                    _hdnDateInspect.Value = _nSqlDtr.Item("INSPECTIONDATE").ToString
                    _hdnemail.Value = _nSqlDtr.Item("EMAIL").ToString
                    _hdnrequestid.Value = btn.CommandName
                    _hdnAcctNo.Value = btn.CommandArgument
                End While
            End If
            loaddata_viewdetails(btn.CommandArgument)
        Catch ex As Exception

        End Try
        
    End Sub


    Public Sub Btn_Action_click(ByVal sender As Object, ByVal e As EventArgs)        
        Dim btn As Button = CType(sender, Button)
        'CSession._pssubNo = btn.CommandArgument
        Try
            If Not cReturnDataType._pYieldStringChecker(_oTextRemarks.Value) Then snackbar("red", "Please complete all required fields") _
                : Exit Sub
            Dim _nQuery As String = Nothing
            _nQuery = "update SafetySealRequest set " &
                IIf(UCase(btn.CommandArgument) = "APPROVED", " Remarks = @Remarks, InspectionDate = @InspectionDate ,", "") &
                " Status = @Status, Assesseddate =  GETDATE(), Assessedby = '" & cSessionUser._pUserID & "' where email = @Email and requestid = @RequestID ; "
            Dim _nSqlCon As SqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nSqlCommand As New SqlCommand(_nQuery, _nSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@RequestID", _hdnrequestid.Value)
                .AddWithValue("@Status", btn.CommandArgument)
                .AddWithValue("@Email", _hdnemail.Value)
                If UCase(btn.CommandArgument) = "APPROVED" Then .AddWithValue("@InspectionDate", _oTextDateInspect.Value) : .AddWithValue("@Remarks", _oTextRemarks.Value)
            End With
            _nSqlCommand.ExecuteNonQuery()
            snackbar(IIf(UCase(btn.CommandArgument) = "APPROVED", "green", "red"), "The request has been " & LCase(btn.CommandArgument) & ".")



            'GET TAXPAYER REQUEST DETAILS
            Dim _nClass As New cDalDILG
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetReqDetails(_hdnrequestid.Value)

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubGetBusName(_nClass._pAcctNo)

            If UCase(btn.CommandArgument) = "APPROVED" Then 'APPROVED
                Particulars = "Request ID=" & _hdnrequestid.Value & _
                            ";BIN=" & _hdnAcctNo.Value & _
                            ";Business Name=" & _nClass._pBusinessName & _
                            ";Assessed Date=" & _nClass._pAssessedDate & _
                            ";Assessed By=" & _nClass._pAssessedBy & _
                            ";Remarks=" & _nClass._pRemarks & _
                            ";"
                Email_Body = "<h1 style='color:green'>" & _nClass._pStatus & "</h1>" & _
      "<br> Your inspection request for BIN:" & _nClass._pAcctNo & " has been " & _nClass._pStatus & _
       "<br> <table>" & _
            "<tr><td>Request ID</td><td>" & _nClass._pRequestID & "</td></tr>" & _
            "<tr><td>Business Name</td><td>" & _nClass._pBusinessName & "</td></tr>" & _
            "<tr><td>Remarks</td><td>" & _nClass._pRemarks & "</td></tr>" & _
            "<tr><td>Schedule of Inspection</td><td>" & _nClass._pInspectionDate & "</td></tr>" & _
       "</table>"
            Else 'DENIED
                Particulars = "Request ID=" & _hdnrequestid.Value & _
                            ";BIN=" & _hdnAcctNo.Value & _
                            ";Business Name=" & _nClass._pBusinessName & _
                            ";Assessed Date=" & _nClass._pAssessedDate & _
                            ";Assessed By=" & _nClass._pAssessedBy & _
                            ";Remarks=" & _nClass._pRemarks & _
                            ";Schedule of Inspection=" & _nClass._pInspectionDate & _
                            ";"
                Email_Body = "<h1 style='color:red'>" & _nClass._pStatus & "</h1>" & _
      "<br> Your inspection request for BIN:" & _nClass._pAcctNo & " has been " & _nClass._pStatus & _
       "<br> <table>" & _
            "<tr><td>Request ID</td><td>" & _nClass._pRequestID & "</td></tr>" & _
            "<tr><td>Business Name</td><td>" & _nClass._pBusinessName & "</td></tr>" & _
            "<tr><td>Remarks</td><td>" & _nClass._pRemarks & "</td></tr>" & _
       "</table>"

            End If
            

            ' INSERT to TAXPAYER HISTORY         
            Dim _nClass3 As New cDalTransactionHistory
            _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass3._pSubInsertHistory(_nClass._pRequestID,
                                        _nClass._pEmail,
                                        "Safety Seal",
                                        "Request",
                                        "Inspection Request",
                                        Particulars,
                                         _nClass._pStatus)

            ' SEND EMAIL NOTIF to TAXPAYER HISTORY           
            Email_Subject = "Safety Seal - [Status] Inspection Request"
            cDalNewSendEmail.SendEmail(_nClass._pEmail, Email_Subject, Email_Body, Sent)

            If Sent = True Then
                snackbar("green", "Email Notification has been sent to Taxpayer")
            Else
                snackbar("red", "Failed to Send Email Notification")
            End If




        Catch ex As Exception
        End Try
        loaddata_req()
        loaddata_History()        
        'ClientScript.RegisterStartupScript(Me.[GetType](), "CHScript", "here")
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


    Protected Sub datagrid_PageIndexChanging_req(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata_req()
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_history(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata_History()
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub _oRadiobtn_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As RadioButton = CType(sender, RadioButton)
        loaddata_History(UCase(Trim((btn.Text).Replace("&nbsp", ""))))        
    End Sub
End Class