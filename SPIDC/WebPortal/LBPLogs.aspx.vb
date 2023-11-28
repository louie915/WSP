Public Class LBPLogs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nGridView As New GridView
        _nGridView = _oGVLogs
        _nGridView.DataSourceID = Nothing

        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubSelectLBPLOGS()

        Dim _nDataTable As New DataTable
        _nDataTable = _nClass._pDataTable

        '----------------------------------
        If _nDataTable.HasErrors Then
     
        End If

        If _nDataTable.Rows.Count > 0 Then
            _nGridView.DataSource = _nDataTable
            _nGridView.DataBind()
        End If
    End Sub

End Class