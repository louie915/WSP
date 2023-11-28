Public Class AccountInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoaddataBPR()
        LoaddataBPP()
        LoaddataBPI()
    End Sub

    Public Sub LoaddataBPR()
        Try
            Dim _Class As New cDalBP
            _Class._SqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _Class._pSubSelect_BPR()
            GV_ForRenewal.DataSource = _Class._DataTable
            GV_ForRenewal.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoaddataBPP()
        Try
            Dim _Class As New cDalBP
            _Class._SqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _Class._pSubSelect_BPP()
            GV_ForPayment.DataSource = _Class._DataTable
            GV_ForPayment.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub LoaddataBPI()
        Try
            Dim _Class As New cDalBP
            _Class._SqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _Class._pSubSelect_BPI()
            GV_Issued.DataSource = _Class._DataTable
            GV_Issued.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_BPR(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBPR()
            GV_ForRenewal.PageIndex = e.NewPageIndex
            GV_ForRenewal.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_BPP(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBPP()
            GV_ForPayment.PageIndex = e.NewPageIndex
            GV_ForPayment.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_BPI(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            LoaddataBPI()
            GV_Issued.PageIndex = e.NewPageIndex
            GV_Issued.DataBind()
        Catch ex As Exception
        End Try
    End Sub
End Class