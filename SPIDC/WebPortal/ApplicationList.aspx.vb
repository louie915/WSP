Imports System.Data
Imports System.Data.SqlClient
Public Class ApplicationList
    Inherits System.Web.UI.Page
    Dim Email_Subject As String
    Dim Email_Body As String
    Dim Sent As Boolean
    Dim Particulars As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loaddata_req()
        loaddata_History()
    End Sub
    Public Sub loaddata_req()
        Try
            '    Dim _nClass As New cDal[NAME]
            '    Dim _nQuery As String = Nothing
            '    _nQuery = "QUERY"
            '
            '    Dim _pSqlCmd = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            '    Dim _mDataAdapter1 = New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            '    Dim _mDataTable1 = New DataTable
            '    _mDataAdapter1.Fill(_mDataTable1)
            '    GridView1.DataSource = _mDataTable1
            '    GridView1.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Public Sub loaddata_History(Optional ByVal Filter As String = Nothing)
        Try
            '   Dim _nClass As New cDal[NAME]
            '   Dim _nQuery As String = Nothing
            '   _nQuery = "QUERY" 
            '   Dim _pSqlCmd = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            '   Dim _mDataAdapter1 = New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            '   Dim _mDataTable1 = New DataTable
            '   _mDataAdapter1.Fill(_mDataTable1)
            '   GridView2.DataSource = _mDataTable1
            '   GridView2.DataBind()
          
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


    Protected Sub datagrid_PageIndexChanging_req(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata_req()
            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_history(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            loaddata_History()
            GridView2.PageIndex = e.NewPageIndex
            GridView2.DataBind()
        Catch ex As Exception
        End Try
    End Sub
   
End Class