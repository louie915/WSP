Imports System.Data.SqlClient

Public Class ASSESSOREnrollmentVerification
    Inherits System.Web.UI.Page
    Dim RowCounter As Integer = Nothing
    Dim RowCounterVerify As Integer = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack Then
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")

                If action = "Verify" Then

                    Select Case ver.Value

                        Case "Approve"
                            If _oTextRemarks.InnerText = "" Or _oTextRemarks.InnerText Is Nothing Then
                                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('Please enter remarks.');", True)
                                'Response.Redirect("ASSESSOREnrollmentVerification.aspx")
                                Exit Sub
                            End If

                            Dim _nClass As New cDalVerifications
                            _nClass._pUserEmail = hdnEmail.Value
                            _nClass._pAccountNo = hdnTDN.Value
                            _nClass._pOrNo = hdnORNO.Value
                            _nClass._pRemarks = _oTextRemarks.InnerText

                            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS

                            _pGetCon(_nClass, "RPTIMS")
                            _pGetCon(_nClass, "OAIMS")

                            _nClass._pUpdateVerificationAssessor(True, cSessionUser._pUserID)
                            loaddata()
                            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal1('" & _nClass._pAccountNo & "','Approved');", True)

                        Case "Disapprove"
                            If _oTextRemarks.InnerText = "" Or _oTextRemarks.InnerText Is Nothing Then
                                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('Please enter remarks.');", True)
                                'Response.Redirect("ASSESSOREnrollmentVerification.aspx")
                                Exit Sub
                            End If

                            Dim _nClass As New cDalVerifications
                            _nClass._pUserEmail = hdnEmail.Value
                            _nClass._pAccountNo = hdnTDN.Value
                            _nClass._pOrNo = hdnORNO.Value
                            _nClass._pRemarks = _oTextRemarks.InnerText

                            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS

                            _pGetCon(_nClass, "RPTIMS")
                            _pGetCon(_nClass, "OAIMS")

                            _nClass._pUpdateVerificationAssessor(False, cSessionUser._pUserID)
                            loaddata()
                            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal1('" & _nClass._pAccountNo & "', 'Disapproved');", True)

                    End Select
      
                    Dim Particulars As String
                    Dim _nClass2 As New cDalTransactionHistory
                    _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS

                    Select Case ver.Value
                        Case "Approve"
                            _nClass2._pSubSelectRPTDETAIL(hdnEmail.Value, hdnTDN.Value, Particulars)
                        Case "Disapprove"
                            _nClass2._pSubSelectRPTDETAIL_HISTORY(hdnEmail.Value, hdnTDN.Value, Particulars)
                    End Select

                    _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    _nClass2._pSubInsertHistory("-", hdnEmail.Value, "RPT", "Enrollment", "TDN:" & hdnTDN.Value, _
                            Particulars, _
                            UCase(ver.Value))

                ElseIf action = "View" Then

                    Dim _nSqlCmd As SqlCommand
                    Dim _nSqlDtr As SqlDataReader
                    Dim _nOwnerNo As String = Nothing
                    Dim _nDataTable As New DataTable

                    ' _nClass._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
                    Try

                    
                    _nSqlCmd = New SqlCommand("  Select (FirstName + ' ' + LastName) as UP_Name,  [Address] as UP_Addr, Contact_Cp as UP_ContactNo , " &
                    " UserID as UP_EmailAddr,Office  from [" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].[dbo].[Registered] " &
                    " where USERID='" & hdnEmail.Value & "'", cGlobalConnections._pSqlCxn_OAIMS)

                    _nSqlDtr = _nSqlCmd.ExecuteReader
                    If _nSqlDtr.HasRows Then
                        While _nSqlDtr.Read

                            _oLabelFullname.InnerText = _nSqlDtr.Item("UP_Name").ToString
                            _oLabelEmailAddress.InnerText = _nSqlDtr.Item("UP_EmailAddr").ToString
                            _oLabelUSAddress.InnerText = _nSqlDtr.Item("UP_Addr").ToString
                            _oLabelContact.InnerText = _nSqlDtr.Item("UP_ContactNo").ToString
                            lblAgent.InnerText = _nSqlDtr.Item("Office").ToString
                        End While
                    End If


                    _nSqlCmd.Dispose()
                        _nSqlDtr.Dispose()

                    Catch ex As Exception
                        err.Value = ex.Message & " : " & _nSqlCmd.CommandText
                    End Try
                    Try

                 
                    _nSqlCmd = New SqlCommand("  Select A.PIN as OwnerPIN , A.TDN as OwnerTDN,A.LOCATION as PropLocAddr, " &
                 " B.Name as OwnerName, B.[Address] as OwnerAddr , B.[Tel_no] as OwnerContact " &
                 " from [RPTMAST] A left outer join [Rptowner] B " &
                 " ON A.OWNER_NO = B.Owner_No Where  A.TDN='" & hdnTDN.Value & "'", cGlobalConnections._pSqlCxn_RPTAS)

                    _nSqlDtr = _nSqlCmd.ExecuteReader
                    If _nSqlDtr.HasRows Then
                        While _nSqlDtr.Read

                            _oLabelOwner.InnerText = _nSqlDtr.Item("OwnerName").ToString
                            _olabelPropLocAddress.InnerText = _nSqlDtr.Item("PropLocAddr").ToString
                            _oLabelOwnerAddr.InnerText = _nSqlDtr.Item("OwnerAddr").ToString
                            _olabelOwnerContNo.InnerText = _nSqlDtr.Item("OwnerContact").ToString
                            _olabelPin.InnerText = _nSqlDtr.Item("OwnerPIN").ToString
                            _olabelTDN.InnerText = _nSqlDtr.Item("OwnerTDN").ToString
                        End While
                    End If
                    _nSqlCmd.Dispose()
                    _nSqlDtr.Dispose()


                    Catch ex As Exception
                        err.Value = ex.Message & " : " & _nSqlCmd.CommandText
                    End Try



                    ' hdnEmail.Value
                    ' hdnORNO.Value
                    ' hdnTDN.Value

                    ' _oLabelTDN.InnerText = hdnTDN.Value


                    Dim GFerr As String = Nothing
                    Try
                        GetFiles(hdnEmail.Value, GFerr)
                        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                        sb.Append("<script language='javascript'>")
                        sb.Append("$('#myModal').modal('show');")
                        sb.Append("</script>")
                        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
                    Catch ex As Exception
                        err.Value = ex.Message & ":" & GFerr
                    End Try
                 
                End If
                If action = "GetFile" Then
                    GetFiles(hdnUserEmail.Value)
                    ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal2();", True)
                End If
                If action = "DownloadFiles" Then
                    Download_Selected(val, hdnEmail.Value)
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
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_Application(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata()
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_Verification(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata()
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataBind()
        Catch ex As Exception
        End Try
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
            _nQuery = "select * from attachment where SEQID ='" & seqid & "' and EMAIL ='" & userid & "'"
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

    Public Sub GetFiles(ByVal Email As String, Optional ByRef err As String = Nothing)
        Dim errCtr As String = Nothing
        Try
            Dim _nclass As New cDalProfileLoader
            _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            cDalVerifications._pSPAName = Nothing
            cDalVerifications._pSPAType = Nothing
            cDalVerifications._pSPAData = Nothing
            cDalVerifications._pGIdName = Nothing
            cDalVerifications._pGIdType = Nothing
            cDalVerifications._pGIdData = Nothing
            _oTxtGovernmentID.Value = Nothing
            _oTxtSPA.Value = Nothing

            errCtr = "001"
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

            errCtr = "002"
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

            errCtr = "003"
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

        Catch ex As Exception
            err = ex.Message & ":" & errCtr
        End Try

    End Sub


    Public Sub loaddata()
        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS

        _pGetCon(_nClass, "RPTIMS")
        _pGetCon(_nClass, "OAIMS")

        _nClass._pLoadApplicationRecordsAssessor()
        _nClass._pLoadVerificationHistoryRecordsAssessor()

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

        _nClass._pSqlCon.Close()

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

    Public Sub ShowApplicationSearch(val)

        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS

        _pGetCon(_nClass, "RPTIMS")
        _pGetCon(_nClass, "OAIMS")

        Dim SELECTTOPVAL = Nothing
        If Not val = Nothing Then SELECTTOPVAL = " TOP " & val : _oTxtShowEntriesApp.Value = val : If val < 5 Then _oTxtShowEntriesApp.Value = val : _oLblShowingValueApp.InnerHtml = val _
            Else _oTxtShowEntriesApp.Value = 5
        _nClass._pLoadApplicationRecordsAssessorSearch(" WHERE " & _oTxtSearchFilterApp.Value & " LIKE " & " '%" & _oTxtSearchKeyApp.Value & "%' ", SELECTTOPVAL)

        GridView1.DataSource = _nClass._pDataTable1
        GridView1.DataBind()

        If _nClass._pDataTable1 IsNot Nothing Then RowCounter = _nClass._pDataTable1.Rows.Count

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>")
        sb.Append("sessionStorage.setItem('CmbEntries1', '" & val & "');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

        _nClass._pSqlCon.Close()

    End Sub

    Public Sub ShowVerificationSearch(val)

        Dim _nClass As New cDalVerifications
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS

        _pGetCon(_nClass, "RPTIMS")
        _pGetCon(_nClass, "OAIMS")

        Dim SELECTTOPVAL = Nothing
        If Not val = Nothing Then SELECTTOPVAL = " TOP " & val : _oTxtShowEntriesApp.Value = val : If val < 5 Then _oTxtShowEntriesApp.Value = val : _oLblShowingValueApp.InnerHtml = val _
            Else _oTxtShowEntriesApp.Value = 5
        '_nClass._pLoadApplicationRecordsSearch(" " & _oTxtSearchFilterApp.Value & " LIKE " & " '%" & _oTxtSearchKeyApp.Value & "%' AND ", SELECTTOPVAL)
        _nClass._pLoadVerificationHistoryRecordsAssessorSearch(" WHERE " & _oTxtSearchFilterVerify.Value & " LIKE " & " '%" & _oTxtSearchKeyVerify.Value & "%' ", SELECTTOPVAL)

        GridView2.DataSource = _nClass._pDataTable
        GridView2.DataBind()

        If _nClass._pDataTable IsNot Nothing Then RowCounterVerify = _nClass._pDataTable.Rows.Count

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>")
        sb.Append("sessionStorage.setItem('CmbEntries2', '" & val & "');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

        _nClass._pSqlCon.Close()

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

        Finally
            _nClass._pSqlCon.Close()
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

        Finally
            _nClass._pSqlCon.Close()
        End Try
    End Sub



End Class