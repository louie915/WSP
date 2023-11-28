Public Class Regulatory
    Inherits System.Web.UI.Page
    Dim RowCounter As Integer = Nothing
    Dim RowCounterVerify As Integer = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                loaddata()
                loadHistory()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub loaddata()
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectApplicants(cSessionUser._pOffice, "Approved - For Regulatory")
        GridView1.DataSource = _nClass._mDataTable
        GridView1.DataBind()
    End Sub

    Protected Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata()
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub loadHistory()
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectHistory(cSessionUser._pOffice)
        GridView2.DataSource = _nClass._mDataTable
        GridView2.DataBind()
    End Sub

    Protected Sub datagrid_PageIndexChanging_History(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataBind()
        Catch ex As Exception
        End Try
    End Sub



End Class