Imports System.Data.SqlClient

Public Class BPLOCertificationList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Load_Record("")


    End Sub
    Sub Load_Record(ByVal CertType As String)
        Try
            Dim _nClass As New cDalRPT_Cert
            cDalRPT_Cert._mSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
            _nClass._pSubSelectRPT("0000")
            GridView4.DataSource = cDalRPT_Cert._mDataTable
            GridView4.DataBind()

            _nClass._pSubSelectRPT("0001")
            GridView5.DataSource = cDalRPT_Cert._mDataTable
            GridView5.DataBind()

            _nClass._pSubSelectRPT("0002")
            GridView6.DataSource = cDalRPT_Cert._mDataTable
            GridView6.DataBind()

            _nClass._pSubSelectRPT("0003")
            GridView7.DataSource = cDalRPT_Cert._mDataTable
            GridView7.DataBind()

            Dim _nClasss As New cDalBP_Cert
            cDalBP_Cert._mSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClasss._pSubSelectBP("0000")
            GridView8.DataSource = cDalBP_Cert._mDataTable
            GridView8.DataBind()

            _nClasss._pSubSelectBP("0001")
            GridView9.DataSource = cDalBP_Cert._mDataTable
            GridView9.DataBind()

            _nClasss._pSubSelectBP("0002")
            GridView10.DataSource = cDalBP_Cert._mDataTable
            GridView10.DataBind()

            _nClasss._pSubSelectBP("0003")
            GridView11.DataSource = cDalBP_Cert._mDataTable
            GridView11.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            Dim _nClass As New cDalRPT_Cert
            cDalRPT_Cert._mSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
            _nClass._pSubSelectRPT("0000")
            GridView4.DataSource = cDalRPT_Cert._mDataTable

            GridView4.PageIndex = e.NewPageIndex
            GridView4.DataBind()

            _nClass._pSubSelectRPT("0001")
            GridView5.DataSource = cDalRPT_Cert._mDataTable
            GridView5.DataBind()

            GridView5.PageIndex = e.NewPageIndex
            GridView5.DataBind()

            _nClass._pSubSelectRPT("0002")
            GridView6.DataSource = cDalRPT_Cert._mDataTable
            GridView6.DataBind()

            GridView6.PageIndex = e.NewPageIndex
            GridView6.DataBind()

            _nClass._pSubSelectRPT("0003")
            GridView7.DataSource = cDalRPT_Cert._mDataTable
            GridView7.DataBind()

            GridView7.PageIndex = e.NewPageIndex
            GridView7.DataBind()

            Dim _nClasss As New cDalBP_Cert
            cDalBP_Cert._mSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClasss._pSubSelectBP("0000")
            GridView8.DataSource = cDalBP_Cert._mDataTable
            GridView8.DataBind()

            GridView8.PageIndex = e.NewPageIndex
            GridView8.DataBind()

            _nClasss._pSubSelectBP("0001")
            GridView9.DataSource = cDalBP_Cert._mDataTable
            GridView9.DataBind()

            GridView9.PageIndex = e.NewPageIndex
            GridView9.DataBind()

            _nClasss._pSubSelectBP("0002")
            GridView10.DataSource = cDalBP_Cert._mDataTable
            GridView10.DataBind()

            GridView10.PageIndex = e.NewPageIndex
            GridView10.DataBind()

            _nClasss._pSubSelectBP("0003")
            GridView11.DataSource = cDalBP_Cert._mDataTable
            GridView11.DataBind()

            GridView11.PageIndex = e.NewPageIndex
            GridView11.DataBind()

        Catch ex As Exception
        End Try
    End Sub

End Class