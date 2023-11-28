
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization
Imports System.Net

Public Class BPLOPermitIssuance
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack Then
         
            Else
                loadIssuance()
                loadIssued()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub loadIssuance()
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelectBP_Issuance_BPLO()



            GV_Issuance.DataSource = _nClass._mDataTable
            GV_Issuance.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub loadIssued()
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectBP_Issued_BPLO()
            GV_Issued.DataSource = _nClass._mDataTable
            GV_Issued.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_Issuance(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loadIssuance()
            GV_Issuance.PageIndex = e.NewPageIndex
            GV_Issuance.DataBind()

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub datagrid_PageIndexChanging_Issued(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loadIssued()
            GV_Issued.PageIndex = e.NewPageIndex
            GV_Issued.DataBind()
        Catch ex As Exception
        End Try
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

    Private Sub btn_view_Issuance_ServerClick(sender As Object, e As EventArgs) Handles btn_view_Issuance.ServerClick
        BPLOPermitView.ACCTNO = hdn_ACCTNO.Value
        Response.Redirect("BPLOPermitView.aspx")
        ' ClientScript.RegisterStartupScript(Me.[GetType](), "OpenWindow", "window.open('BPLOPermitView.aspx','_newtab');", True)


    End Sub
End Class