Public Class AssetTest
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubGetBusLine_GrossAssetEntry("Z-00216")
        _GVBusinessLine.DataSource = _nClass._mDataTable
        _GVBusinessLine.DataBind()
    End Sub

    Private Sub btnSave_ServerClick(sender As Object, e As EventArgs) Handles btnSave.ServerClick
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        Dim err As String
        _nClass._pSubUpdate_GrossAssetEntry("Z-00216", hdnGrossAsset.Value, "MOP", err)
    End Sub
End Class