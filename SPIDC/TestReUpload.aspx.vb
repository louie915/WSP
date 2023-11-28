Public Class TestReUpload
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Load_Requirements("NEW")
    End Sub
    Sub Load_Requirements(ByVal switch As String, Optional ByRef reqCount As Integer = 0)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectRequirements2(switch, "lugarestom@gmail.com", "NBP20230609-00002")
            gv_test.DataSource = _nClass._mDataTable
            gv_test.DataBind()
            reqCount = _nClass._mDataTable.Rows.Count
        Catch ex As Exception

        End Try
    End Sub
End Class