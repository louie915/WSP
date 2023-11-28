
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization
Imports System.Net

Public Class BPLOEnrollmentVerification
    Inherits System.Web.UI.Page
    Dim RowCounter As Integer = Nothing
    Dim RowCounterVerify As Integer = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'CreateBadge("demo", "10+")
            If IsPostBack Then
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")

                If action = "Verify" Then

                    Select Case ver.Value

                        Case "Approve"

                            If _oTextRemarks.InnerText = "" Or _oTextRemarks.InnerText Is Nothing Then
                                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('Please enter remarks.');", True)
                                Exit Sub
                            End If

                            Dim _nClass As New cDalVerifications
                            _nClass._pUserEmail = hdnEmail.Value ' userEmail.Value
                            _nClass._pAccountNo = hdnACCTNO.Value
                            _nClass._pOrNo = hdnORNO.Value
                            _nClass._pRemarks = _oTextRemarks.InnerText

                            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

                            _pGetCon(_nClass, "BPLTIMS")
                            _pGetCon(_nClass, "OAIMS")

                            _nClass._pUpdateVerification(True, cSessionUser._pUserID)

                            Dim _nClass3 As New cDalBPSOS
                            _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
                            If _nClass3._checkHasBillingTemp(cSessionLoader._pAccountNo) = True Then
                                _nClass3.ApproveForPayment(cSessionLoader._pAccountNo)
                                _nClass3.GenerateWebAssessNo(cSessionLoader._pAccountNo)
                            End If

                            loaddata()
                            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal1('" & _nClass._pAccountNo & "','Approved');", True)

                        Case "Disapprove"
                            If _oTextRemarks.InnerText = "" Or _oTextRemarks.InnerText Is Nothing Then

                                Exit Sub
                            End If

                            Dim _nClass As New cDalVerifications
                            _nClass._pUserEmail = hdnEmail.Value 'userEmail.Value
                            _nClass._pAccountNo = hdnACCTNO.Value 'acctNo.Value
                            _nClass._pOrNo = hdnORNO.Value 'OrNo.Value
                            _nClass._pRemarks = _oTextRemarks.InnerText

                            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

                            _pGetCon(_nClass, "BPLTIMS")
                            _pGetCon(_nClass, "OAIMS")

                            _nClass._pUpdateVerification(False, cSessionUser._pUserID)
                            Dim _nClass1 As New cDalBPSOS
                            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                            _nClass1._pAcctNo = hdnACCTNO.Value
                            _nClass1._pSubDECLINEENROLLMENT()

                            loaddata()
                            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal1('" & _nClass._pAccountNo & "','Disapproved');", True)

                    End Select
                    Dim Particulars As String
                    Dim _nClass2 As New cDalTransactionHistory
                    _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass2._pSubSelectBUSDETAIL(hdnEmail.Value, hdnACCTNO.Value, Particulars)
                    _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    _nClass2._pSubInsertHistory("-", hdnEmail.Value, "BP", "Enrollment", "BIN:" & hdnACCTNO.Value, _
                            Particulars, _
                            UCase(ver.Value & "D"))

                    '  Dim subject As String = "Business Account Enrollment"
                    '
                    '  Dim Sent As Boolean
                    '  Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                    '                       "Your Business Enrollment has been " & ver.Value & "d. <br>" & _
                    '                       "Account No : " & hdnACCTNO.Value & "<br>" & _
                    '                       "Remarks : " & _oTextRemarks.InnerText & " <br>" & _
                    '                       "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
                    '  Dim err As String
                    '  cDalNewSendEmail.SendEmail(hdnEmail.Value, subject, Body, Sent, Err)
                    '  If Sent = True Then
                    '      snackbar("green", "Taxpayer has been Notified")
                    '  Else
                    '      snackbar("red", "Failed : " & err)
                    '  End If
                    Exit Sub



                ElseIf action = "View" Then
                    Dim _nClass3 As New cDalBPSOS
                    _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
                    If _nClass3._checkHasBillingTemp(hdnACCTNO.Value) = True Then
                        div_AssessedNotice.Style.Add("display", "block")
                    Else
                        div_AssessedNotice.Style.Add("display", "none")
                    End If
                    AttentionBIN.InnerText = hdnACCTNO.Value

                    Session("SsEmail") = val
                    Dim _nSqlCmd As SqlCommand
                    Dim _nSqlDtr As SqlDataReader
                    Dim _nOwnerNo As String = Nothing
                    Dim _nDataTable As New DataTable

                    '  ._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS

                    _nSqlCmd = New SqlCommand("  Select (FirstName + ' ' + LastName) as UP_Name,  [Address] as UP_Addr, Contact_Cp as UP_ContactNo , " &
                    " UserID as UP_EmailAddr,Office  from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].[dbo].[Registered] " &
                    " where USERID='" & Session("SsEmail") & "'", cGlobalConnections._pSqlCxn_OAIMS)

                    _nSqlDtr = _nSqlCmd.ExecuteReader
                    If _nSqlDtr.HasRows Then
                        While _nSqlDtr.Read

                            _oLabelFullname.InnerText = _nSqlDtr.Item("UP_Name").ToString
                            _oLabelUserEmailAddress.InnerText = _nSqlDtr.Item("UP_EmailAddr").ToString
                            _oLabelAddress.InnerText = _nSqlDtr.Item("UP_Addr").ToString
                            _oLabelUserContactNo.InnerText = _nSqlDtr.Item("UP_ContactNo").ToString
                            lblAgent.InnerText = _nSqlDtr.Item("Office").ToString

                        End While
                    End If


                    _nSqlCmd.Dispose()
                    _nSqlDtr.Dispose()


                    _nSqlCmd = New SqlCommand("Select (ISNULL([FIRST_NAME],'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL([LAST_NAME],'')) as UP_Name ,ISNULL([EMAILADDR],'') as EMAILADDR, " & _
                                              "ISNULL([OWNERADDR],'') as  OWNERADDR ,ISNULL([COMMNAME],'') as COMMNAME,COMMADDR,  (ISNULL(([CONTACT]),'') + ISNULL(' ' + [CONTTEL],'') + ISNULL(' ' + [OWNERTEL],'')" & _
                                              " + ISNULL(' ' + [CPNO],'') + ISNULL(' ' + [CPNO2],'') + ISNULL(' ' + [CPNO3],'') ) as UP_Contact  from [BUSMAST] " & _
                                              "Where [ACCTNO] = '" & hdnACCTNO.Value & "'", cGlobalConnections._pSqlCxn_BPLTAS)

                    _nSqlDtr = _nSqlCmd.ExecuteReader
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
                    Dim coun As Integer = 0
                    Dim oldval As String = _oLabelOwnerContactNo.InnerText
                    For value As Integer = 0 To _oLabelOwnerContactNo.InnerText.Length - 1
                        If oldval(value) = "|" And value = 0 Then
                            _oLabelOwnerContactNo.InnerText = oldval.Replace("|", "")
                        End If
                        If oldval(value) = "|" Then
                            coun += 1
                        End If
                    Next
                    If coun = 1 Then
                        _oLabelOwnerContactNo.InnerText = oldval.Replace("|", "")
                    End If
                    _nSqlCmd.Dispose()
                    _nSqlDtr.Dispose()






                    ' hdnEmail.Value
                    ' hdnORNO.Value
                    ' hdnTDN.Value

                    ' _oLabelTDN.InnerText = hdnTDN.Value




                    GetFiles(Session("SsEmail"))
                    Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                    sb.Append("<script language='javascript'>")
                    sb.Append("$('#myModal').modal('show');")
                    sb.Append("</script>")
                    ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

                End If

                If action = "GetFile" Then
                    GetFiles(hdnUserEmail.Value)
                    ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal2();", True)
                End If

                If action = "SearchApp" Then
                    Try
                        '---------------------------------- Added by Archie 01222021                                 
                        ShowApplicationSearch(val)
                        _oHdnTopCounterApp.Value = val
                    Catch ex As Exception
                    End Try
                End If
                If action = "SearchVerify" Then
                    Try
                        '----------------------------------   Added by Archie 01222021                                  
                        ShowVerificationSearch(val)
                        _oHdnTopCounterVerify.Value = val
                    Catch ex As Exception
                    End Try
                End If

                'If action = "DownloadFiles" Then
                '    Download_Selected_New(val, cSessionLoader._pAccountNo)
                '    'Download_Selected(cSessionLoader._pAccountNo)
                '    'Response.Write("<script>window.open('Sample.aspx','_blank');</script>")                    
                '    'chie = True
                'End If


                If action = "DownloadFiles" Then
                    Download_Selected(val, Session("SsEmail"))
                End If
            Else
                loaddata()
                _oTxtShowEntriesHdnApp.Value = RowCounter
                _oTtlEntriesApp.InnerHtml = RowCounter
                _oTxtShowEntriesHdnVerify.Value = RowCounterVerify
                _oTtlEntriesVerify.InnerHtml = RowCounterVerify
                If RowCounter < 5 Then _oLblShowingValueApp.InnerHtml = RowCounter _
                Else _oLblShowingValueApp.InnerHtml = 5
                If RowCounterVerify < 5 Then _oLblShowingValueVerify.InnerHtml = RowCounterVerify _
                Else _oLblShowingValueVerify.InnerHtml = 5
                _mLoadGridview()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_Application(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            'loaddata()
            ShowApplicationSearch(_oHdnTopCounterApp.Value)
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataBind()

            GetFiles(hdnEmail.Value)

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_History(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            'loaddata()
            ShowVerificationSearch(_oHdnTopCounterVerify.Value)
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataBind()

            GetFiles(hdnEmail.Value)

        Catch ex As Exception
        End Try
    End Sub

    Public Sub GetFiles(Email)

        Dim _nclass As New cDalProfileLoader
        _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        cDalVerifications._pSPAName = Nothing
        cDalVerifications._pSPAType = Nothing
        cDalVerifications._pSPAData = Nothing
        cDalVerifications._pGIdName = Nothing
        cDalVerifications._pGIdType = Nothing
        cDalVerifications._pGIdData = Nothing
        cDalVerifications._pBRSecName = Nothing
        cDalVerifications._pBRSecType = Nothing
        cDalVerifications._pBRSecData = Nothing
        _oTxtGovernmentID.Value = Nothing
        _oTxtSPA.Value = Nothing
        _oTxtBRSec.Value = Nothing

        _nclass._pSubSelect("Attachment", "where EMAIL = '" & Email & "' and  SeqID = '001'  and ModuleID = 'Change/Update Contact Informations' ;")
        Dim _nDataTable As New DataTable

        _nDataTable = _nclass._pDataTable

        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            '_oPGIDView.Visible = Not _oPGIDView.Visible
            '_oPGIDUpload.Visible = Not _oPGIDUpload.Visible
            _oTxtGovernmentID.Value = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pGIdName = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pGIdType = _nDataTable.Rows(0)("FileType").ToString()
            cDalVerifications._pGIdData = _nDataTable.Rows(0)("FileData")
        End If

        _nclass._pSubSelect("Attachment", " where EMAIL = '" & Email & "' and  SeqID = '002'  and ModuleID = 'Change/Update Contact Informations' ;")
        _nDataTable = _nclass._pDataTable
        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            '_oPSPAView.Visible = Not _oPSPAView.Visible
            '_oPSPAUpload.Visible = Not _oPSPAUpload.Visible
            _oTxtSPA.Value = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pSPAName = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pSPAType = _nDataTable.Rows(0)("FileType").ToString()
            cDalVerifications._pSPAData = _nDataTable.Rows(0)("FileData")
        End If

        _nclass._pSubSelect("Attachment", " where EMAIL = '" & Email & "' and  SeqID = '003'  and ModuleID = 'Change/Update Contact Informations' ;")
        _nDataTable = _nclass._pDataTable
        If _nDataTable IsNot Nothing AndAlso _nDataTable.Rows.Count > 0 Then
            '_oPSPAView.Visible = Not _oPSPAView.Visible
            '_oPSPAUpload.Visible = Not _oPSPAUpload.Visible
            _oTxtBRSec.Value = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pBRSecName = _nDataTable.Rows(0)("FileName").ToString()
            cDalVerifications._pBRSecType = _nDataTable.Rows(0)("FileType").ToString()
            cDalVerifications._pBRSecData = _nDataTable.Rows(0)("FileData")
        End If

        '_oFileSPA.Name = _nDataTable.Rows(0)("FileData").ToString()
        '_nClass._pSPAType = _nDataTable.Rows(0)("FileType").ToString()
        '_nClass._pSPAData = _nDataTable.Rows(0)("FileData")
        If _oTxtGovernmentID.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then _oTxtGovernmentID.Value = "No Attached File"
        If _oTxtSPA.Value Is Nothing Or String.IsNullOrEmpty(_oTxtSPA.Value) Then _oTxtSPA.Value = "No Attached File"
        If _oTxtBRSec.Value Is Nothing Or String.IsNullOrEmpty(_oTxtBRSec.Value) Then _oTxtBRSec.Value = "No Attached File"
    End Sub

    Public Sub loaddata()
        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

        _pGetCon(_nClass, "BPLTIMS")
        _pGetCon(_nClass, "OAIMS")

        _nClass._pLoadApplicationRecords()
        _nClass._pLoadVerificationHistoryRecords()

        GridView1.DataSource = _nClass._pDataTable1
        GridView1.DataBind()

        If _nClass._pDataTable1 IsNot Nothing Then RowCounter = _nClass._pDataTable1.Rows.Count

        GridView2.DataSource = _nClass._pDataTable
        GridView2.DataBind()

        If _nClass._pDataTable IsNot Nothing Then RowCounterVerify = _nClass._pDataTable.Rows.Count        

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>")
        sb.Append("sessionStorage.setItem('CmbEntries1', '" & RowCounter & "');")
        sb.Append("sessionStorage.setItem('CmbEntries2', '" & RowCounterVerify & "');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

    End Sub
    Private Sub _mLoadGridview()


        If cDalVerifications._mRecordCount <> 0 Then
            BtnPrintAll.Visible = True
            LabelTotalRecCnt.InnerText = "Record total Count: " & cDalVerifications._mRecordCount
        Else
            BtnPrintAll.Visible = False
            LabelTotalRecCnt.InnerText = "Record total Count:" & " 0" '- MEANN : brain100
        End If

        BtnPrintAll.Visible = True
        LabelTotalRecCnt.InnerText = ""
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

    Public Sub _pGetCon(cls As cDalVerifications, dbname As String)
        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = dbname
        _nClBP._pSubRecordSelectSpecific()

        '----------------------------------
        'Specify Blank to Select Nothing but Column Names
        Select Case dbname
            Case "RPTIMS"
                cls._pLocalServer = _nClBP._pDBDataSource
                cls._pLocalDb = _nClBP._pDBInitialCatalog
            Case "OAIMS"
                cls._pLocalServer1 = _nClBP._pDBDataSource
                cls._pLocalDb1 = _nClBP._pDBInitialCatalog
            Case "BPLTIMS"
                cls._pLocalServer = _nClBP._pDBDataSource
                cls._pLocalDb = _nClBP._pDBInitialCatalog
        End Select
    End Sub

    Sub Download_Selected(seqid, userid)
        Try

            If seqid = "001" Then
                If _oTxtGovernmentID.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then
                    snackbar("red", "No Attached file")
                    Exit Sub
                End If
            Else
                If _oTxtSPA.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then
                    snackbar("red", "No Attached file")
                    Exit Sub
                End If
            End If

            Dim _nclass As New cDalProfileLoader
            _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim filetype As String
            Dim bytes As Byte()
            Dim _nFileExtn As String
            Dim _mFilename As String
            _nQuery = "select * from attachment where SEQID ='" & seqid & "' and EMAIL ='" & userid & "' and OFFICE <> 'BPLO' "
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_OAIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))
                    If _nFileExtn = "TEXT/PLAIN" Then
                        _nFileExtn = ".TXT"
                    End If
                    If _nFileExtn = "APPLICATION/PDF" Then
                        _nFileExtn = ".PDF"
                    End If
                    If _nFileExtn = "IMAGE/PNG" Then
                        _nFileExtn = ".PNG"
                    End If
                    If _nFileExtn = "IMAGE/JPEG" Then
                        _nFileExtn = ".JPG"
                    End If

                End If
                If _nFileExtn = ".PDF" Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()

                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Response.Clear()
                    Response.ContentType = "image/png"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Then
                    Response.Clear()
                    Response.ContentType = "image/jpeg"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CreateBadge(TargetID, Counter)
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script>")
        sb.Append("var block_to_insert;var container_block;block_to_insert = document.createElement('span');" & _
                  "block_to_insert.classList.add('badge', 'badge-danger', 'badge-counter', 'float-right');" & _
                  "block_to_insert.innerHTML = '" + Counter + "';container_block = document.getElementById('" + TargetID + "');" & _
                  "container_block.appendChild(block_to_insert);" & _
                  "")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
    End Sub

    Sub Download_Selected_New(seqid, AcctNo)
        Try
            'Select Case seqid
            '    Case "001"
            '        If _oTxtGovernmentID.Value Is Nothing Or String.IsNullOrEmpty(_oTxtGovernmentID.Value) Then
            '            snackbar("red", "No Attached file")
            '            Exit Sub
            '        End If
            '    Case "002"
            '        If _oTxtSPA.Value Is Nothing Or String.IsNullOrEmpty(_oTxtSPA.Value) Then
            '            snackbar("red", "No Attached file")
            '            Exit Sub
            '        End If
            '    Case "003"
            '        If _oTxtBRSec.Value Is Nothing Or String.IsNullOrEmpty(_oTxtBRSec.Value) Then
            '            snackbar("red", "No Attached file")
            '            Exit Sub
            '        End If
            'End Select

            Dim _nclass As New cDalBPSOS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim filetype As String
            Dim bytes As Byte()
            Dim _nFileExtn As String
            Dim _mFilename As String
            _nQuery = "select * from BUSDETAIL_ATTACHMENTS_NEW where SEQID ='" & seqid & "' and ACCTNO ='" & AcctNo & "'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))
                    If _nFileExtn = "TEXT/PLAIN" Then
                        _nFileExtn = ".TXT"
                    End If
                    If _nFileExtn = "APPLICATION/PDF" Then
                        _nFileExtn = ".PDF"
                    End If
                    If _nFileExtn = "IMAGE/PNG" Then
                        _nFileExtn = ".PNG"
                    End If
                    If _nFileExtn = "IMAGE/JPEG" Then
                        _nFileExtn = ".JPG"
                    End If

                End If
                If _nFileExtn = ".PDF" Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()

                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Response.Clear()
                    Response.ContentType = "image/png"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Then
                    Response.Clear()
                    Response.ContentType = "image/jpeg"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPrintAll_ServerClick(sender As Object, e As EventArgs) Handles BtnPrintAll.ServerClick
        Try
            Try
                '' Display report in New Tab
                Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=ListingApplication','_blank');</script>")
                '' Display report in Current Tab
            Catch ex As Exception
            End Try

        Catch ex As Exception
        End Try
    End Sub
    Public Sub ShowApplicationSearch(val)

        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

        _pGetCon(_nClass, "BPLTIMS")
        _pGetCon(_nClass, "OAIMS")

        Dim SELECTTOPVAL = Nothing
        If Not val = Nothing Then SELECTTOPVAL = " TOP " & val : _oTxtShowEntriesApp.Value = val : If val < 5 Then _oTxtShowEntriesApp.Value = val : _oLblShowingValueApp.InnerHtml = val _
            Else _oTxtShowEntriesApp.Value = 5
        _nClass._pLoadApplicationRecordsSearch(" " & _oTxtSearchFilterApp.Value & " LIKE " & " '%" & _oTxtSearchKeyApp.Value & "%' AND ", SELECTTOPVAL)

        GridView1.DataSource = _nClass._pDataTable1
        GridView1.DataBind()

        If _nClass._pDataTable1 IsNot Nothing Then RowCounter = _nClass._pDataTable1.Rows.Count

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>")
        sb.Append("sessionStorage.setItem('CmbEntries1', '" & val & "');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
    End Sub

    Public Sub ShowVerificationSearch(val)

        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

        _pGetCon(_nClass, "BPLTIMS")
        _pGetCon(_nClass, "OAIMS")

        Dim SELECTTOPVAL = Nothing
        If Not val = Nothing Then SELECTTOPVAL = " TOP " & val : _oTxtShowEntriesApp.Value = val : If val < 5 Then _oTxtShowEntriesApp.Value = val : _oLblShowingValueApp.InnerHtml = val _
            Else _oTxtShowEntriesApp.Value = 5
        '_nClass._pLoadApplicationRecordsSearch(" " & _oTxtSearchFilterApp.Value & " LIKE " & " '%" & _oTxtSearchKeyApp.Value & "%' AND ", SELECTTOPVAL)
        _nClass._pLoadVerificationHistoryRecordsSearch(" " & _oTxtSearchFilterVerify.Value & " LIKE " & " '%" & _oTxtSearchKeyVerify.Value & "%' ", SELECTTOPVAL)

        GridView2.DataSource = _nClass._pDataTable
        GridView2.DataBind()

        If _nClass._pDataTable IsNot Nothing Then RowCounterVerify = _nClass._pDataTable.Rows.Count

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>")
        sb.Append("sessionStorage.setItem('CmbEntries2', '" & val & "');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
    End Sub


    Private Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

        _pGetCon(_nClass, "BPLTIMS")
        _pGetCon(_nClass, "OAIMS")

        _nClass._pLoadApplicationRecords()

        ShowApplicationSearch(_oHdnTopCounterApp.Value)
        Dim dt As DataTable = DirectCast(GridView1.DataSource, DataTable)
        Dim dv As New DataView(dt)
        Dim direction As SortDirection
        Try


            If GridView1.Attributes("dir") = direction.Ascending Then
                dv.Sort = e.SortExpression & " DESC"
                GridView1.Attributes("dir") = direction.Descending

            Else
                GridView1.Attributes("dir") = direction.Ascending
                dv.Sort = e.SortExpression & " ASC"

            End If

            GridView1.DataSource = dv
            GridView1.DataBind()

            'RowCounter = GridView1.Rows.Count

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>")
            sb.Append("sessionStorage.setItem('CmbEntries1', '" & _oHdnTopCounterApp.Value & "');")
            sb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
        Catch ex As Exception

        End Try
    End Sub


    Private Sub GridView2_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView2.Sorting
        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

        _pGetCon(_nClass, "BPLTIMS")
        _pGetCon(_nClass, "OAIMS")

        _nClass._pLoadVerificationHistoryRecords()

        ShowVerificationSearch(_oHdnTopCounterVerify.Value)
        Dim dt As DataTable = DirectCast(GridView2.DataSource, DataTable)
        Dim dv As New DataView(dt)
        Dim direction As SortDirection
        Try
            If GridView2.Attributes("dir") = direction.Ascending Then
                dv.Sort = e.SortExpression & " DESC"
                GridView2.Attributes("dir") = direction.Descending
            Else
                GridView2.Attributes("dir") = direction.Ascending
                dv.Sort = e.SortExpression & " ASC"
            End If

            GridView2.DataSource = dv
            GridView2.DataBind()

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>")
            sb.Append("sessionStorage.setItem('CmbEntries2', '" & _oHdnTopCounterVerify.Value & "');")
            sb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

        Catch ex As Exception

        End Try
    End Sub
End Class