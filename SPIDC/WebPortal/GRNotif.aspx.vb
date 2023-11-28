Public Class GRNotif
    Inherits System.Web.UI.Page
    Dim usertmp As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Load_GVGR()
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Load_GVGR()
        Try
            Dim _nClass As New cDalSOSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            _nClass._pSubSelect_GVGR()
            '  GVGR.DataSource = cDalSOSRPTAS._mDataTable
            '  GVGR.DataBind()
            lbl_RecCount.InnerText = cDalSOSRPTAS._mDataTable.Rows.Count
        Catch ex As Exception
            Response.Write("<script>alert(Load_GVGR : " & ex.Message & ")</script>")
        End Try


    End Sub

    Protected Sub datagrid_PageIndexChanging_GVGR(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            '  Load_GVGR()
            '  GVGR.PageIndex = e.NewPageIndex
            '  GVGR.DataBind()
        Catch ex As Exception
            Response.Write("<script>alert(datagrid_PageIndexChanging_GVGR : " & ex.Message & ")</script>")
        End Try
    End Sub

    Private Sub btnSendEmail_ServerClick(sender As Object, e As EventArgs) Handles btnSendEmail.ServerClick
        Try
            Dim err As String = Nothing
            Dim _nClass As New cDalSOSRPTAS
            Dim Testemail As String = txtTestEmail.Value
            Dim SkipTDN As String = txtSKipTDN.value
            If String.IsNullOrEmpty(Testemail) Then
                Testemail = Nothing
            End If

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            _nClass.Process_GR(txtCount.Value, err, Testemail, SkipTDN)
            If String.IsNullOrEmpty(err) = False Then
                Response.Write("<script>alert(Process_GR : " & err & ")</script>")
            End If
            txterr.InnerText = err
        Catch ex As Exception
            txterr.InnerText = ex.Message
        End Try
    End Sub
End Class