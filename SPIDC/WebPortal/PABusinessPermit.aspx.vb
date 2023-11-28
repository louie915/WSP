Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient


Public Class PABusinessPermit
    Inherits System.Web.UI.Page
    Public Shared errmsg As Boolean
    Public Shared errmsgpass As Boolean
    Public Shared success As Boolean
    Public Shared loginpage As Boolean
    Dim _nTabName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ApprovedTab.Attributes.Add("class", "tab-pane fade")
            ForApprovaltab.Attributes.Add("class", "tab-pane fade show active")
            'ForReviewtab.Attributes.Add("class", "tab-pane fade")

            'forreviewtabb.Attributes.Add("class", "nav-link")
            approvedtabb.Attributes.Add("class", "nav-link")
            forapprovaltabb.Attributes.Add("class", "nav-link active")

            'forreviewtabb.Attributes.Add("aria-selected", "false")
            approvedtabb.Attributes.Add("aria-selected", "false")
            forapprovaltabb.Attributes.Add("aria-selected", "true")
            _oHdnTabID.Value = "forapprovaltabb"
            _oBtnApprove.Visible = True
        Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")
            Session("TabName") = _oHdnTabID.Value

            If action = "DownloadFiles" Then
                Download_Selected(val, cSessionUser._pUserID, hdnFileName.Value)
            End If

            If val = "forreviewtabb" Then
                '_mSubDataLoadForReview()

                ApprovedTab.Attributes.Add("class", "tab-pane fade")
                ForApprovaltab.Attributes.Add("class", "tab-pane fade")
                'ForReviewtab.Attributes.Add("class", "tab-pane fade show active")

                approvedtabb.Attributes.Add("class", "nav-link")
                forapprovaltabb.Attributes.Add("class", "nav-link")
                'forreviewtabb.Attributes.Add("class", "nav-link active")

                approvedtabb.Attributes.Add("aria-selected", "false")
                forapprovaltabb.Attributes.Add("aria-selected", "false")
                'forreviewtabb.Attributes.Add("aria-selected", "true")
                _oHdnTabID.Value = val
            End If
            If val = "forapprovaltabb" Then
                _mSubDataLoadForApproval()
                ApprovedTab.Attributes.Add("class", "tab-pane fade")
                ForApprovaltab.Attributes.Add("class", "tab-pane fade show active")
                'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                'forreviewtabb.Attributes.Add("class", "nav-link")
                approvedtabb.Attributes.Add("class", "nav-link")
                forapprovaltabb.Attributes.Add("class", "nav-link active")

                'forreviewtabb.Attributes.Add("aria-selected", "false")
                approvedtabb.Attributes.Add("aria-selected", "false")
                forapprovaltabb.Attributes.Add("aria-selected", "true")
                _oHdnTabID.Value = val
                _oBtnApprove.Visible = True
            End If
            If val = "approvedtabb" Then
                _mSubDataLoadApproved()
                ApprovedTab.Attributes.Add("class", "tab-pane fade show active")
                ForApprovaltab.Attributes.Add("class", "tab-pane fade")
                'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                'forreviewtabb.Attributes.Add("class", "nav-link")
                forapprovaltabb.Attributes.Add("class", "nav-link")
                approvedtabb.Attributes.Add("class", "nav-link active")

                'forreviewtabb.Attributes.Add("aria-selected", "false")
                forapprovaltabb.Attributes.Add("aria-selected", "false")
                approvedtabb.Attributes.Add("aria-selected", "true")
                _oHdnTabID.Value = val
                _oBtnApprove.Visible = False
            End If

            If action = "Insert" Then
                _mGetAcctNoInformation(val)
                _mSubDataLoadPaymentDetails(val)
                Session.Item("ACCTNO") = val
                If Session("TabName") = "forreviewtabb" Then
                    ApprovedTab.Attributes.Add("class", "tab-pane fade")
                    ForApprovaltab.Attributes.Add("class", "tab-pane fade")
                    'ForReviewtab.Attributes.Add("class", "tab-pane fade show active")

                    approvedtabb.Attributes.Add("class", "nav-link")
                    forapprovaltabb.Attributes.Add("class", "nav-link")
                    'forreviewtabb.Attributes.Add("class", "nav-link active")

                    approvedtabb.Attributes.Add("aria-selected", "false")
                    forapprovaltabb.Attributes.Add("aria-selected", "false")
                    'forreviewtabb.Attributes.Add("aria-selected", "true")
                ElseIf Session("TabName") = "forapprovaltabb" Then
                    ApprovedTab.Attributes.Add("class", "tab-pane fade")
                    ForApprovaltab.Attributes.Add("class", "tab-pane fade show active")
                    'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                    ' forreviewtabb.Attributes.Add("class", "nav-link")
                    approvedtabb.Attributes.Add("class", "nav-link")
                    forapprovaltabb.Attributes.Add("class", "nav-link active")

                    ' forreviewtabb.Attributes.Add("aria-selected", "false")
                    approvedtabb.Attributes.Add("aria-selected", "false")
                    forapprovaltabb.Attributes.Add("aria-selected", "true")
                    _oBtnApprove.Visible = True
                    _oBtnApprove.InnerText = "Approve"
                Else
                    ApprovedTab.Attributes.Add("class", "tab-pane fade show active")
                    ForApprovaltab.Attributes.Add("class", "tab-pane fade")
                    ' ForReviewtab.Attributes.Add("class", "tab-pane fade")

                    ' forreviewtabb.Attributes.Add("class", "nav-link")
                    forapprovaltabb.Attributes.Add("class", "nav-link")
                    approvedtabb.Attributes.Add("class", "nav-link active")

                    ' forreviewtabb.Attributes.Add("aria-selected", "false")
                    forapprovaltabb.Attributes.Add("aria-selected", "false")
                    approvedtabb.Attributes.Add("aria-selected", "true")
                    _oBtnApprove.Visible = True
                    _oBtnApprove.InnerText = "Disapprove"
                End If
                Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                sb.Append("<script>")
                sb.Append("setTimeout(function() {$('#DisplayDetails').modal('show');}, 50);</script>")
                ClientScript.RegisterStartupScript(Me.[GetType](), "JSSScript", sb.ToString())
                Session.Item("AppACCTNO") = val
            End If

            If action = "View" Then

            End If

            If action = "Passkey" Then
                If _oBtnApprove.InnerText = "Approve" Then
                    authenticate(val)
                    '_mInsertSearchedAcctNo(Session.Item("AppACCTNO"))
                    '_mSubDataLoadForApproval()
                    'ApprovedTab.Attributes.Add("class", "tab-pane fade")
                    'ForApprovaltab.Attributes.Add("class", "tab-pane fade show active")
                    'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                    'forreviewtabb.Attributes.Add("class", "nav-link")
                    'approvedtabb.Attributes.Add("class", "nav-link")
                    'forapprovaltabb.Attributes.Add("class", "nav-link active")

                    'forreviewtabb.Attributes.Add("aria-selected", "false")
                    'approvedtabb.Attributes.Add("aria-selected", "false")
                    'forapprovaltabb.Attributes.Add("aria-selected", "true")
                End If
                If _oBtnApprove.InnerText = "Disapprove" Then
                    authenticate(val)
                    '_mUpdateApprovedAcctNo(Session.Item("AppACCTNO"))
                    '_mSubDataLoadForApproval()
                    'ApprovedTab.Attributes.Add("class", "tab-pane fade show active")
                    'ForApprovaltab.Attributes.Add("class", "tab-pane fade")
                    'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                    'forreviewtabb.Attributes.Add("class", "nav-link")
                    'approvedtabb.Attributes.Add("class", "nav-link active")
                    'forapprovaltabb.Attributes.Add("class", "nav-link")

                    'forreviewtabb.Attributes.Add("aria-selected", "false")
                    'approvedtabb.Attributes.Add("aria-selected", "true")
                    'forapprovaltabb.Attributes.Add("aria-selected", "false")
                End If
            End If
        End If
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

    Sub authenticate(ByVal PassKey As String)
        Try
            Dim _nclass As New cDalAccountMaintenance
            _nclass._pTag = False
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nclass._pSubSelectPassKey(cSessionUser._pUserID, PassKey)
            If errmsg = True Then
                lblusererror.Visible = True
                lblusererror.InnerHtml = "Username Not found"
            Else
                lblusererror.Visible = False
            End If
            If PassKey = "" Then
                lblusererror.InnerHtml = "Please Input a Data "
                Exit Sub
            End If
            If errmsgpass = True Then
                lblusererror.Visible = True
                lblusererror.InnerHtml = "Incorrect Password "
            Else
                If errmsg = True Then lblusererror.Visible = False : Exit Sub
                lblusererror.Visible = False
                If _oBtnApprove.InnerText = "Approve" Then
                    _oHdnPermitNo.Value = _oTxtPermitNo.Value
                    _oHdnORNo.Value = _oTxtORNo.Value
                    _mInsertSearchedAcctNo(Session.Item("AppACCTNO"), _oHdnPermitNo.Value, _oHdnORNo.Value, _oBtnApprove.InnerText)
                    _mSubDataLoadForApproval()
                    ApprovedTab.Attributes.Add("class", "tab-pane fade")
                    ForApprovaltab.Attributes.Add("class", "tab-pane fade show active")
                    'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                    ' forreviewtabb.Attributes.Add("class", "nav-link")
                    approvedtabb.Attributes.Add("class", "nav-link")
                    forapprovaltabb.Attributes.Add("class", "nav-link active")

                    ' forreviewtabb.Attributes.Add("aria-selected", "false")
                    approvedtabb.Attributes.Add("aria-selected", "false")
                    forapprovaltabb.Attributes.Add("aria-selected", "true")
                    snackbar("green", "Business Permit approved!")
                ElseIf _oBtnApprove.InnerText = "Disapprove" Then
                    _oHdnPermitNo.Value = _oTxtPermitNo.Value
                    _oHdnORNo.Value = _oTxtORNo.Value
                    _mInsertSearchedAcctNo(Session.Item("AppACCTNO"), _oHdnPermitNo.Value, _oHdnORNo.Value, _oBtnApprove.InnerText)
                    _mSubDataLoadApproved()
                    ApprovedTab.Attributes.Add("class", "tab-pane fade show active")
                    ForApprovaltab.Attributes.Add("class", "tab-pane fade")
                    'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                    'forreviewtabb.Attributes.Add("class", "nav-link")
                    approvedtabb.Attributes.Add("class", "nav-link active")
                    forapprovaltabb.Attributes.Add("class", "nav-link")

                    'forreviewtabb.Attributes.Add("aria-selected", "false")
                    approvedtabb.Attributes.Add("aria-selected", "true")
                    forapprovaltabb.Attributes.Add("aria-selected", "false")
                    snackbar("green", "Business Permit disapproved!")
                End If
            End If

        Catch ex As Exception
            snackbar("red", "An error occured!")
        End Try
    End Sub
    Private Sub _mGetAcctNoInformation(ByVal _nAcctNo As String)
        Try
            Dim _nSqlCmd As New SqlCommand
            Dim _mRdr As SqlDataReader
            If Session("TabName") = "forreviewtabb" Then
                _nSqlCmd = New SqlCommand("SELECT * from VW_BPForReview where ACCTNO = '" & _nAcctNo & "'", cGlobalConnections._pSqlCxn_BPLTAS)
                _mRdr = _nSqlCmd.ExecuteReader
                _mRdr.Read()
                If _mRdr.HasRows Then
                    _oTxtBIN.Value = _mRdr.Item("ACCTNO").ToString
                    _oTxtPermitNo.Value = _mRdr.Item("PERMITNO").ToString
                    _oTxtOwner.Value = _mRdr.Item("OWNERNAME").ToString
                    _oTxtTradeName.Value = _mRdr.Item("COMMNAME").ToString
                    _oTxtBusinessLoc.Value = _mRdr.Item("COMMADDR").ToString
                    _oTxtORNo.Value = _mRdr.Item("ORNO").ToString
                    _oTxtReviewedBy.Value = _mRdr.Item("REVIEWEDBY").ToString
                    _oTxtDate.Value = String.Format("{0:MMM,d, yyyy}", _mRdr.Item("ISSUANCEDATE").ToString) ' _mRdr.Item("ISSUANCEDATE").ToString("yyyy/MM/dd")

                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                Else
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                End If
            ElseIf Session("TabName") = "forapprovaltabb" Then
                _nSqlCmd = New SqlCommand("SELECT * from VW_BPForApproval where ACCTNO = '" & _nAcctNo & "'", cGlobalConnections._pSqlCxn_BPLTAS)
                _mRdr = _nSqlCmd.ExecuteReader
                _mRdr.Read()
                If _mRdr.HasRows Then
                    _oTxtBIN.Value = _mRdr.Item("ACCTNO").ToString
                    _oTxtPermitNo.Value = _mRdr.Item("PERMITNO").ToString
                    _oTxtOwner.Value = _mRdr.Item("OWNERNAME").ToString
                    _oTxtTradeName.Value = _mRdr.Item("COMMNAME").ToString
                    _oTxtBusinessLoc.Value = _mRdr.Item("COMMADDR").ToString
                    _oTxtORNo.Value = _mRdr.Item("ORNO").ToString
                    _oTxtReviewedBy.Value = _mRdr.Item("REVIEWEDBY").ToString
                    _oTxtDate.Value = String.Format("{0:MMM,d, yyyy}", _mRdr.Item("ISSUANCEDATE").ToString) ' _mRdr.Item("ISSUANCEDATE").ToString("yyyy/MM/dd")

                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                Else
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                End If
            Else
                _nSqlCmd = New SqlCommand("SELECT * from VW_BPApproved where ACCTNO = '" & _nAcctNo & "'", cGlobalConnections._pSqlCxn_BPLTAS)
                _mRdr = _nSqlCmd.ExecuteReader
                _mRdr.Read()
                If _mRdr.HasRows Then
                    _oTxtBIN.Value = _mRdr.Item("ACCTNO").ToString
                    _oTxtPermitNo.Value = _mRdr.Item("PERMITNO").ToString
                    _oTxtOwner.Value = _mRdr.Item("OWNERNAME").ToString
                    _oTxtTradeName.Value = _mRdr.Item("COMMNAME").ToString
                    _oTxtBusinessLoc.Value = _mRdr.Item("COMMADDR").ToString
                    _oTxtORNo.Value = _mRdr.Item("ORNO").ToString
                    _oTxtReviewedBy.Value = _mRdr.Item("REVIEWEDBY").ToString
                    _oTxtDate.Value = String.Format("{0:MMM,d, yyyy}", _mRdr.Item("ORDATE").ToString) ' _mRdr.Item("ISSUANCEDATE").ToString("yyyy/MM/dd")

                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                Else
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                End If
            End If


            _nSqlCmd = New SqlCommand("select BUS_CODE, ACCTNO, ORNO,SUM(TAMT + STAMT) AS tot_amt from vw_PayfileSummary_Tanay WHERE BUS_CODE <> '0' and ACCTNO = '" & _nAcctNo & "' group by BUS_CODE, ACCTNO, ORNO", cGlobalConnections._pSqlCxn_BPLTAS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                _oTxtAmount.Value = String.Format("{0:n}", _mRdr.Item("tot_amt")) '_mRdr.Item("tot_amt").ToString
                _nSqlCmd.Dispose()
                _mRdr.Dispose()
            Else
                _nSqlCmd.Dispose()
                _mRdr.Dispose()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub _mInsertSearchedAcctNo(ByVal _nAcctNo As String, ByVal _nPermitNo As String, ByVal _nORNo As String, ByVal _nMode As String)

        Try
            Dim _nSqlCmd As New SqlCommand
            Dim _mRdr As SqlDataReader
            Dim _nBool As Boolean
            If _nMode = "Approve" Then

                _nSqlCmd = New SqlCommand("SELECT * FROM BUSINESSPERMIT WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE()) and isnull(REVIEWEDBY,'') <> '' and isnull(APPROVEDBY,'') = ''", cGlobalConnections._pSqlCxn_BPLTIMS)
                _mRdr = _nSqlCmd.ExecuteReader
                _mRdr.Read()
                If _mRdr.HasRows Then
                    _nBool = True
                Else
                    _nBool = False
                End If
                _nSqlCmd.Dispose()
                _mRdr.Dispose()
                If _nBool = False Then
                    _nSqlCmd = New SqlCommand("INSERT INTO BUSINESSPERMIT " & _
                                          "SELECT * FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "]." & cGlobalConnections._pSqlCxn_BPLTAS.Database & ".dbo.BUSINESSPERMIT " & _
                                          "WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE()) and isnull(REVIEWEDBY,'') <> '' and isnull(APPROVEDBY,'') = ''", cGlobalConnections._pSqlCxn_BPLTIMS)
                    _nSqlCmd.ExecuteNonQuery()
                    _nSqlCmd.Dispose()

                    _nSqlCmd = New SqlCommand("UPDATE BUSINESSPERMIT SET APPROVEDBY = '" & cSessionUser._pUserID & "', APPROVEDPOS = '" & cSessionUser._pUsertype & "', APPROVEDDATE = GETDATE(), APPROVED = 1 " & _
                                              "WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE()) and isnull(REVIEWEDBY,'') <> '' and isnull(APPROVEDBY,'') = ''", cGlobalConnections._pSqlCxn_BPLTIMS)
                    _nSqlCmd.ExecuteNonQuery()
                    _nSqlCmd.Dispose()
                Else
                    _nSqlCmd = New SqlCommand("UPDATE BUSINESSPERMIT SET APPROVEDBY = '" & cSessionUser._pUserID & "', APPROVEDPOS = '" & cSessionUser._pUsertype & "', APPROVEDDATE = GETDATE(), APPROVED = 1 " & _
                                              "WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE()) and isnull(REVIEWEDBY,'') <> '' and isnull(APPROVEDBY,'') = ''", cGlobalConnections._pSqlCxn_BPLTIMS)
                    _nSqlCmd.ExecuteNonQuery()
                    _nSqlCmd.Dispose()
                End If
            Else
                _nSqlCmd = New SqlCommand("SELECT * FROM BUSINESSPERMIT WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE()) and isnull(REVIEWEDBY,'') <> '' and isnull(APPROVEDBY,'') <> ''", cGlobalConnections._pSqlCxn_BPLTIMS)
                _mRdr = _nSqlCmd.ExecuteReader
                _mRdr.Read()
                If _mRdr.HasRows Then
                    _nBool = True
                Else
                    _nBool = False
                End If
                _nSqlCmd.Dispose()
                _mRdr.Dispose()
                If _nBool = False Then
                    _nSqlCmd = New SqlCommand("INSERT INTO BUSINESSPERMIT " & _
                                          "SELECT * FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "]." & cGlobalConnections._pSqlCxn_BPLTAS.Database & ".dbo.BUSINESSPERMIT " & _
                                          "WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE()) and isnull(REVIEWEDBY,'') <> '' and isnull(APPROVEDBY,'') <> ''", cGlobalConnections._pSqlCxn_BPLTIMS)
                    _nSqlCmd.ExecuteNonQuery()
                    _nSqlCmd.Dispose()

                    _nSqlCmd = New SqlCommand("UPDATE BUSINESSPERMIT SET APPROVEDBY = '', APPROVEDPOS = '', APPROVEDDATE = Null, APPROVED = 0 " & _
                                              "WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE()) and isnull(REVIEWEDBY,'') <> '' and isnull(APPROVEDBY,'') <> ''", cGlobalConnections._pSqlCxn_BPLTIMS)
                    _nSqlCmd.ExecuteNonQuery()
                    _nSqlCmd.Dispose()
                Else
                    _nSqlCmd = New SqlCommand("UPDATE BUSINESSPERMIT SET APPROVEDBY = '', APPROVEDPOS = '', APPROVEDDATE = Null, APPROVED = 0 " & _
                                              "WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE()) and isnull(REVIEWEDBY,'') <> '' and isnull(APPROVEDBY,'') <> ''", cGlobalConnections._pSqlCxn_BPLTIMS)
                    _nSqlCmd.ExecuteNonQuery()
                    _nSqlCmd.Dispose()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _mUpdateApprovedAcctNo(ByVal _nAcctNo As String, ByVal _nPermitNo As String, ByVal _nORNo As String)
        Try
            Dim _nSqlCmd As New SqlCommand
            _nSqlCmd = New SqlCommand("UPDATE BUSINESSPERMIT SET APPROVED = 0 WHERE ACCTNO = '" & _nAcctNo & "' AND PERMITNO = '" & _nPermitNo & "' AND ORNO = '" & _nORNo & "' AND FORYEAR = YEAR(GETDATE())", cGlobalConnections._pSqlCxn_BPLTIMS)
            _nSqlCmd.ExecuteNonQuery()
            _nSqlCmd.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetInitialRow() '------------- for gridview sample data only
        Try

        Catch ex As Exception

        End Try

    End Sub
    'Sub _mSubDataLoadForReview()
    '    Try


    '    Dim _nGridView As New GridView
    '    _nGridView = _oGVProperty1
    '    _nGridView.DataSourceID = Nothing
    '    Dim _nclass As New cDalBusinessPermit
    '    _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
    '    _nclass._pSubSelectForReview(_oCmbFilter.Value, _oTxtSearch.Value)
    '    cSessionUser._pStrDt = _nclass._pstrdt
    '    _nGridView.DataSource = cDalBusinessPermit._mDataTableForReview
    '        _nGridView.DataBind()
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Sub _mSubDataLoadForApproval()
        Try


            Dim _nGridView As New GridView
            _nGridView = _oGvForApproval
            _nGridView.DataSourceID = Nothing
            Dim _nclass As New cDalBusinessPermit
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nclass._pSubSelectForApproval(_oCmbFilter.Value, _oTxtSearch.Value)
            cSessionUser._pStrDt = _nclass._pstrdt
            _nGridView.DataSource = cDalBusinessPermit._mDataTableForApproval
            _nGridView.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub _mSubDataLoadApproved()
        Try


            Dim _nGridView As New GridView
            _nGridView = _oGVProperty3
            _nGridView.DataSourceID = Nothing
            Dim _nclass As New cDalBusinessPermit
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nclass._pSubSelectApproved(_oCmbFilter.Value, _oTxtSearch.Value)
            cSessionUser._pStrDt = _nclass._pstrdt
            _nGridView.DataSource = cDalBusinessPermit._mDataTableApproved
            _nGridView.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub _mSubDataLoadPaymentDetails(ByVal _nAcctNo As String)
        Try
            Dim _nSrs As String
            Dim _nxSwitch As String
            Dim _nxORNO As String
            Dim _nSqlCmd As New SqlCommand
            Dim _mRdr As SqlDataReader
            _nSqlCmd = New SqlCommand("select SRS,xSWITCH, ORNO, ACCTNO from PAYFILE where ACCTNO = '" & _nAcctNo & "'", cGlobalConnections._pSqlCxn_BPLTAS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                _nSrs = _mRdr.Item("SRS").ToString
                _nxSwitch = _mRdr.Item("xSWITCH").ToString
                _nxORNO = _mRdr.Item("ORNO").ToString
            Else
                _nSrs = ""
                _nxSwitch = ""
                _nxORNO = ""
            End If

            Dim _nGridView As New GridView
            _nGridView = _oGVPaymentDetails
            _nGridView.DataSourceID = Nothing
            Dim _nclass As New cDalBusinessPermit
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nclass._pSubSelectPaymentDetails(_nxSwitch, _nxORNO, _nSrs, _nAcctNo)
            cSessionUser._pStrDt = _nclass._pstrdt
            _nGridView.DataSource = cDalBusinessPermit._mDataTablePaymentDetails
            _nGridView.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    'Protected Sub datagrid_PageIndexForReview(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    Try
    '        _mSubDataLoadForReview()
    '        _oGVProperty1.PageIndex = e.NewPageIndex
    '        _oGVProperty1.DataBind()

    '    Catch ex As Exception
    '    End Try
    'End Sub
    Protected Sub datagrid_PageIndexForApproval(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            _mSubDataLoadForApproval()
            _oGvForApproval.PageIndex = e.NewPageIndex
            _oGvForApproval.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexApproved(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            _mSubDataLoadApproved()
            _oGVProperty3.PageIndex = e.NewPageIndex
            _oGVProperty3.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChangingSPTrans(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try

            _mSubDataLoadPaymentDetails(Session.Item("ACCTNO"))
            _oGVPaymentDetails.PageIndex = e.NewPageIndex
            _oGVPaymentDetails.DataBind()

        Catch ex As Exception
        End Try
    End Sub


    Protected Sub _obtnSearch_Click(sender As Object, e As EventArgs)
        Try

            If _oHdnTabID.Value = "" Then
                _oHdnTabID.Value = "forapprovaltabb"
            End If
            If Session("TabName") = Nothing Then
                Session("TabName") = _oHdnTabID.Value
            End If
            If _oHdnTabID.Value = "approvedtabb" Then
                Session("TabName") = _oHdnTabID.Value
            End If
            If Session("TabName") = "forapprovaltabb" Then
                _mSubDataLoadForApproval()
                ApprovedTab.Attributes.Add("class", "tab-pane fade")
                ForApprovaltab.Attributes.Add("class", "tab-pane fade show active")
                'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                'forreviewtabb.Attributes.Add("class", "nav-link")
                approvedtabb.Attributes.Add("class", "nav-link")
                forapprovaltabb.Attributes.Add("class", "nav-link active")

                'forreviewtabb.Attributes.Add("aria-selected", "false")
                approvedtabb.Attributes.Add("aria-selected", "false")
                forapprovaltabb.Attributes.Add("aria-selected", "true")
                '_oHdnTabID.Value = Val()
                _oBtnApprove.Visible = True
            ElseIf Session("TabName") = "approvedtabb" Then
                _mSubDataLoadApproved()
                ApprovedTab.Attributes.Add("class", "tab-pane fade show active")
                ForApprovaltab.Attributes.Add("class", "tab-pane fade")
                'ForReviewtab.Attributes.Add("class", "tab-pane fade")

                'forreviewtabb.Attributes.Add("class", "nav-link")
                forapprovaltabb.Attributes.Add("class", "nav-link")
                approvedtabb.Attributes.Add("class", "nav-link active")

                'forreviewtabb.Attributes.Add("aria-selected", "false")
                forapprovaltabb.Attributes.Add("aria-selected", "false")
                approvedtabb.Attributes.Add("aria-selected", "true")
                '_oHdnTabID.Value = Val()
                _oBtnApprove.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Sub _mSubDataLoadAttachments(ByVal _nAcctNo As String)
    '    Try
    '        Dim _nGridView As New GridView
    '        _nGridView = _oGvAttachments
    '        _nGridView.DataSourceID = Nothing
    '        Dim _nclass As New cDalBusinessPermit
    '        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS_F
    '        _nclass._pSubSelectAttachments(_nAcctNo)
    '        cSessionUser._pStrDt = _nclass._pstrdt
    '        _nGridView.DataSource = cDalBusinessPermit._mDataTablePaymentDetails
    '        _nGridView.DataBind()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    '  Protected Sub _oLblAttachmentsForApproval_Click(sender As Object, e As EventArgs)
    '      Try
    '
    '          Dim _nGridView As New GridView
    '          _nGridView = _oGvAttachments
    '          _nGridView.DataSourceID = Nothing
    '          Dim _nclass As New cDalBusinessPermit
    '          _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS_F
    '          _nclass._pSubSelectAttachments(Session("AcctNo"))
    '          cSessionUser._pStrDt = _nclass._pstrdt
    '          _nGridView.DataSource = cDalBusinessPermit._mDataTablePaymentDetails
    '          _nGridView.DataBind()
    '
    '      Catch ex As Exception
    '
    '      End Try
    '  End Sub

    Private Sub HdnBtnAttachment_Click(sender As Object, e As EventArgs) Handles HdnBtnAttachment.Click
        Try

            Dim _nGridView As New GridView
            _nGridView = _oGvAttachments
            _nGridView.DataSourceID = Nothing
            Dim _nclass As New cDalBusinessPermit
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS_F
            _nclass._pSubSelectAttachments(Session("AcctNo"))
            cSessionUser._pStrDt = _nclass._pstrdt
            _nGridView.DataSource = cDalBusinessPermit._mDataTableAttachments
            _nGridView.DataBind()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub testclick_Click(sender As Object, e As EventArgs) Handles testclick.Click
        Try


            Dim _nGridView As New GridView
            _nGridView = _oGvAttachments
            _nGridView.DataSourceID = Nothing
            Dim _nclass As New cDalBusinessPermit
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS_F
            _nclass._pSubSelectAttachments(HdnTxtAttachment.Value)
            cSessionUser._pStrDt = _nclass._pstrdt
            _nGridView.DataSource = cDalBusinessPermit._mDataTableAttachments
            _nGridView.DataBind()

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script>")
            sb.Append("setTimeout(function() {$('#DisplayAttachments').modal('show');}, 50);</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "JSSScript", sb.ToString())

        Catch ex As Exception

        End Try
    End Sub
    Sub Download_Selected(seqid, userid, FileName)
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

            Dim _nclass As New cDalProfileLoader
            _nclass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim filetype As String
            Dim bytes As Byte()
            Dim _nFileExtn As String = ""
            Dim _mFilename As String = ""
            Dim _nLength As Integer
            _nQuery = "select * from BPFile where AcctNo ='" & seqid & "' and xFileName ='" & FileName & "'"
            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTAS_F)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_BPLTAS_F) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))
                    '_nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _nLength = Len(Right(_mFilename, (_mFilename.Length - _mFilename.IndexOf("."))))
                    _nFileExtn = _mFilename.ToString.Substring(_mFilename.IndexOf("."), _nLength)
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
End Class