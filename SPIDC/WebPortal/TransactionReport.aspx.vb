Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Security.Cryptography
Imports SPIDC.Resources
Imports Microsoft.Reporting.WebForms

Public Class TransactionReport
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Load_DateFromTo()
                Load_GridView()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub ShowModal(ByVal ModalName As String)
        Try
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script>$('#" & ModalName & "').modal('show');</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "ShowModal", sb.ToString())
        Catch ex As Exception

        End Try
    End Sub

  

    Protected Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            Load_GridView()
            gv_List.PageIndex = e.NewPageIndex
            gv_List.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Sub Load_GridView()
        Try
            Dim _nClass As New cDalRegistered
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            gv_List.DataSource = _nClass.Get_Registered(txtDateFrom.Value, txtDateTo.Value, cmbSortBy.Value, cmbOrder.Value)
            cDalRegistered._DateFrom = txtDateFrom.Value
            cDalRegistered._DateTo = txtDateTo.Value
            cDalRegistered._SortBy = cmbSortBy.Items.Item(cmbSortBy.SelectedIndex).ToString
            cDalRegistered._Order = cmbOrder.Items.Item(cmbOrder.SelectedIndex).ToString
            cDalRegistered._SearchBy = Nothing
            cDalRegistered._SearchText = Nothing
            gv_List.DataBind()
        Catch ex As Exception
            err.Value += ";Load_GridView:" & ex.Message
        End Try
    End Sub

    Sub Load_DateFromTo()
        Try
            Dim DateFrom As Date
            Dim DateTo As Date

            Dim _nClass As New cDalRegistered
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.Get_DateRange(DateFrom, DateTo)

            txtDateFrom.Attributes.Add("Type", "Date")
            txtDateFrom.Attributes.Add("min", Format(DateFrom, "yyyy-MM-dd"))
            txtDateFrom.Attributes.Add("max", Format(DateTo, "yyyy-MM-dd"))
            txtDateFrom.Value = Format(DateFrom, "yyyy-MM-dd")

            txtDateTo.Attributes.Add("Type", "Date")
            txtDateTo.Attributes.Add("min", Format(DateFrom, "yyyy-MM-dd"))
            txtDateTo.Attributes.Add("max", Format(DateTo, "yyyy-MM-dd"))
            txtDateTo.Value = Format(DateTo, "yyyy-MM-dd")

        Catch ex As Exception
            err.Value += ";Load_DateFromTo:" & ex.Message
        End Try
    End Sub

    Private Sub btnSearch_ServerClick(sender As Object, e As EventArgs) Handles btnSearch.ServerClick
        Try
            Dim _nClass As New cDalRegistered
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            gv_List.DataSource = _nClass.Get_Registered(txtDateFrom.Value, txtDateTo.Value, cmbSortBy.Value, cmbOrder.Value, cmbSearch.Value, txtSearch.Value)
            cDalRegistered._DateFrom = txtDateFrom.Value
            cDalRegistered._DateTo = txtDateTo.Value
            cDalRegistered._SortBy = cmbSortBy.Items.Item(cmbSortBy.SelectedIndex).ToString
            cDalRegistered._Order = cmbOrder.Items.Item(cmbOrder.SelectedIndex).ToString
            cDalRegistered._SearchBy = cmbSearch.Items.Item(cmbSearch.SelectedIndex).ToString
            cDalRegistered._SearchText = txtSearch.Value
            gv_List.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFilter_ServerClick(sender As Object, e As EventArgs) Handles btnFilter.ServerClick
        Try
            Load_GridView()
        Catch ex As Exception

        End Try
    End Sub
End Class