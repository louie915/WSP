Imports System.Globalization
Imports System.Net
Public Class TreasuryBusinessRenewalList
    Inherits System.Web.UI.Page
    Dim usertmp As String
    Dim nHasPayment As Boolean = False
    Dim nFullyPaid As Boolean = False
    Dim nHasSubmit As Boolean = False
    Dim nLQP As Integer
    Dim RowCounter As Integer = Nothing
    Dim RowCounterAssess As Integer = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim myOutPut As String

            If Not IsPostBack Then

                Dim _nClass As New cDalBPSOS
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
                _nClass._pSubRemoveTemp()

                Dim _nClass1 As New cDalBPSOS
                _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nClass1._pEmail = cSessionUser._pUserID
                _nClass1._pSubRemoveTemp()


                _mSubGetSubmitAcct()
                _mSubGetAssessAcct()
                _oTxtShowEntriesHdn.Value = RowCounter
                _oTtlEntries.InnerHtml = RowCounter
                _oTxtShowEntriesHdnAssess.Value = RowCounterAssess
                _oTtlEntriesAssess.InnerHtml = RowCounterAssess
                If RowCounter < 5 Then _oLblShowingValue.InnerHtml = RowCounter _
            Else _oLblShowingValue.InnerHtml = 5
                If RowCounterAssess < 5 Then _oLblShowingValueAssess.InnerHtml = RowCounterAssess _
            Else _oLblShowingValueAssess.InnerHtml = 5

                Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                sb.Append("<script language='javascript'>")
                sb.Append("sessionStorage.setItem('CmbEntries1', '" & RowCounter & "');")
                sb.Append("sessionStorage.setItem('CmbEntries2', '" & RowCounterAssess & "');")
                sb.Append("</script>")
                ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")

                If action = "Assess" Or action = "Payment" Then
                    Dim _nClass As New cDalBPSOS
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    Dim _nClBP As New cDalGlobalConnectionsDefault
                    _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                    _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                    _nClBP._pSubRecordSelectSpecific()

                    '----------------------------------
                    'Specify Blank to Select Nothing but Column Names
                    _nClass._pAcctNo = val
                    _nClass._pLocServer = _nClBP._pDBDataSource
                    _nClass._pLocDB = _nClBP._pDBInitialCatalog
                    _nClass._pSubGetCurYear()
                    _nClass._pForYear = _nClass._nCurYear
                    _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
                    _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
                    _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
                    _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
                    '----------------------------------
                    _nClass._pSubGetBusDetailExtn()

                    cSessionLoader._pAccountNo = val
                    BusinessRenewal.ngrossvisibility = action

                    Response.Redirect("BusinessRenewalTreasury.aspx")

                End If
                If action = "SearchBP" Then
                    Try
                        '----------------------------------                        
                        ShowBPRenewalSearch(val)
                        _oHdnTopCounterKey.Value = val
                    Catch ex As Exception
                    End Try
                End If
                If action = "SearchAssess" Then
                    Try
                        '----------------------------------                        
                        ShowBPAssessedSearch(val)
                        _oHdnTopCounterAssess.Value = val
                    Catch ex As Exception
                    End Try
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _mSubGetSubmitAcct()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS


            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            '----------------------------------

            _nClass._pSubSelectSubmitAcct_Treasury()
            ' GridView1.AutoGenerateColumns = True
            GridView1.DataSource = _nClass._mDataTable
            GridView1.DataBind()

            RowCounter = _nClass._mDataTable.Rows.Count


        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Private Sub _mSubGetAssessAcct()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS


            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            '----------------------------------

            _nClass._pSubSelectAssessAcct()
            ' GridView1.AutoGenerateColumns = True
            GridView2.DataSource = _nClass._mDataTable
            GridView2.DataBind()

            RowCounterAssess = _nClass._mDataTable.Rows.Count


        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Protected Sub datagrid_PageIndexChanging_BP(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            '_mSubGetSubmitAcct()
            ShowBPRenewalSearch(_oHdnTopCounterKey.Value)
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_Assess(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            '_mSubGetAssessAcct()
            ShowBPAssessedSearch(_oHdnTopCounterAssess.Value)
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Private Property SortDirection As String
        Get
            Return IIf(ViewState("SortDirection") IsNot Nothing, Convert.ToString(ViewState("SortDirection")), "ASC")
        End Get
        Set(value As String)
            ViewState("SortDirection") = value
        End Set
    End Property

    Private Sub GridView1_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView1.Sorting
        ShowBPRenewalSearch(_oHdnTopCounterKey.Value)
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

            RowCounter = _oHdnTopCounterKey.Value

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>")
            sb.Append("sessionStorage.setItem('CmbEntries1', '" & _oHdnTopCounterKey.Value & "');")
            sb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

        Catch ex As Exception

        End Try
    End Sub


    Private Sub GridView2_Sorting(sender As Object, e As GridViewSortEventArgs) Handles GridView2.Sorting
        ShowBPAssessedSearch(_oHdnTopCounterAssess.Value)
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

            RowCounterAssess = _oHdnTopCounterAssess.Value

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>")
            sb.Append("sessionStorage.setItem('CmbEntries2', '" & _oHdnTopCounterAssess.Value & "');")
            sb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

        Catch ex As Exception

        End Try
    End Sub


    Public Sub ShowBPRenewalSearch(val)
        Dim _nClass As New cDalBPSOS


        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
        _nClBP._pSubRecordSelectSpecific()

        '----------------------------------
        'Specify Blank to Select Nothing but Column Names
        _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
        _nClass._pSubGetCurYear()
        _nClass._pForYear = _nClass._nCurYear
        _nClass._pLocServer = _nClBP._pDBDataSource
        _nClass._pLocDB = _nClBP._pDBInitialCatalog

        Dim SelectTopVal = Nothing
        If Not val = Nothing Then SelectTopVal = " TOP " & val : _oTxtShowEntries.Value = val : If val < 5 Then _oTxtShowEntries.Value = val : _oLblShowingValue.InnerHtml = val _
            Else _oTxtShowEntries.Value = 5
        _nClass._pSearchOnBP(" WHERE " & _oTxtSearchFilter.Value & " LIKE " & " '%" & _oTxtSearchKey.Value & "%' ", SelectTopVal)
        '----------------------------------                        
        '_nClass._pSubSelectAssessAcct()
        ' gridview1.autogeneratecolumns = true
        GridView1.DataSource = _nClass._mDataTable
        GridView1.DataBind()

        RowCounter = _nClass._pDataTable.Rows.Count

        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>")
        sb.Append("sessionStorage.setItem('CmbEntries2', '" & val & "');")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())


    End Sub

    Private Sub ShowBPAssessedSearch(val)
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS


            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            '----------------------------------

            '_nClass._pSubSelectAssessAcct()
            ' GridView1.AutoGenerateColumns = True

            Dim SelectTopVal = Nothing
            If Not val = Nothing Then SelectTopVal = " TOP " & val : _oTxtShowEntriesAssess.Value = val : If val < 5 Then _oTxtShowEntriesAssess.Value = val : _oLblShowingValueAssess.InnerHtml = val _
                Else _oTxtShowEntriesAssess.Value = 5
            _nClass._pSearchOnBPAssessAcct(" WHERE " & _oTxtSearchFilterAssess.Value & " LIKE " & " '%" & _oTxtSearchKeyAssess.Value & "%' ", SelectTopVal)
            ' GridView1.AutoGenerateColumns = True
            GridView2.DataSource = _nClass._mDataTable
            GridView2.DataBind()

            RowCounterAssess = _nClass._pDataTable.Rows.Count

            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>")
            sb.Append("sessionStorage.setItem('CmbEntries2', '" & val & "');")
            sb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

End Class