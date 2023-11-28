Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Security.Cryptography
Imports SPIDC.Resources
Imports Microsoft.Reporting.WebForms

Public Class SchedulerHistory
    Inherits System.Web.UI.Page

  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Load_DateFromTo()
                load_CMB(cmbScheduledBy)
                load_CMB(cmbDepartment)
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

    Public Sub SnackBar(ByVal color As String, ByVal msg As String)
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Appointment", "ShowSnackBar('" & color & "','" & msg & "');", True)

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
            Dim _nClass As New cDalAppointment
            _nClass.ScheduledBy = cmbScheduledBy.Value
            _nClass.AppDateFrom = txtAppDateFrom.Value
            _nClass.AppDateTo = txtAppDateTo.Value
            _nClass.TransDateFrom = txtTransDateFrom.Value
            _nClass.TransDateTo = txtTransDateTo.Value
            _nClass.Department = cmbDepartment.Value
            _nClass.SortByCode = cmbSortBy.Value
            _nClass.OrderCode = cmbOrder.Value
            _nClass.SortByDesc = cmbSortBy.Items.Item(cmbSortBy.SelectedIndex).ToString
            _nClass.OrderDesc = cmbOrder.Items.Item(cmbOrder.SelectedIndex).ToString

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            gv_List.DataSource = _nClass.Get_SchedulerHistory()
            gv_List.DataBind()
        Catch ex As Exception
            err.Value += ";Load_GridView:" & ex.Message
        End Try
    End Sub

    Sub Load_DateFromTo()
        Try
            Dim AppDateFrom As Date
            Dim AppDateTo As Date
            Dim TransDateFrom As Date
            Dim transDateTo As Date

            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.Get_DateRange(AppDateFrom, AppDateTo, TransDateFrom, transDateTo)

            txtAppDateFrom.Attributes.Add("Type", "Date")
            txtAppDateFrom.Attributes.Add("min", Format(AppDateFrom, "yyyy-MM-dd"))
            txtAppDateFrom.Attributes.Add("max", Format(AppDateTo, "yyyy-MM-dd"))
            txtAppDateFrom.Value = Format(AppDateFrom, "yyyy-MM-dd")

            txtAppDateTo.Attributes.Add("Type", "Date")
            txtAppDateTo.Attributes.Add("min", Format(AppDateFrom, "yyyy-MM-dd"))
            txtAppDateTo.Attributes.Add("max", Format(AppDateTo, "yyyy-MM-dd"))
            txtAppDateTo.Value = Format(AppDateTo, "yyyy-MM-dd")

            txtTransDateFrom.Attributes.Add("Type", "Date")
            txtTransDateFrom.Attributes.Add("min", Format(TransDateFrom, "yyyy-MM-dd"))
            txtTransDateFrom.Attributes.Add("max", Format(transDateTo, "yyyy-MM-dd"))
            txtTransDateFrom.Value = Format(TransDateFrom, "yyyy-MM-dd")

            txtTransDateTo.Attributes.Add("Type", "Date")
            txtTransDateTo.Attributes.Add("min", Format(TransDateFrom, "yyyy-MM-dd"))
            txtTransDateTo.Attributes.Add("max", Format(transDateTo, "yyyy-MM-dd"))
            txtTransDateTo.Value = Format(transDateTo, "yyyy-MM-dd")

        Catch ex As Exception
            err.Value += ";Load_DateFromTo:" & ex.Message
        End Try
    End Sub
    Sub load_CMB(ByVal cmbName As HtmlControls.HtmlSelect)
        Try
            cmbName.DataSourceID = Nothing
            Dim _mDataSet = New DataSet()
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            cmbName.DataSource = _nClass.Get_DataSet(cmbName.ID)
            cmbName.DataTextField = "Description"
            cmbName.DataValueField = "Code"
            cmbName.DataBind()
            If cmbName.ID = "cmbScheduledBy" Then
                cmbName.Items.Insert(0, New ListItem("ALL (Including Taxpayers)", "ALL"))
                cmbName.Items.Insert(1, New ListItem("ALL (Schedulers Only)", "ALL2"))
            ElseIf cmbName.ID = "cmbDepartment" Then
                cmbName.Items.Insert(0, New ListItem("ALL", "ALL"))
            End If


        Catch ex As Exception
            err.Value += ";load_CMB " & cmbName.ID & ":" & ex.Message
        End Try
    End Sub
  
    Private Sub btnSearch_ServerClick(sender As Object, e As EventArgs) Handles btnSearch.ServerClick
        Try
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            gv_List.DataSource = _nClass.Get_SchedulerHistory(cmbSearch.Value, txtSearch.Value)
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