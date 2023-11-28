Public Class ARX_Viewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim FileData As Byte()
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS_F
        _nClass._pSubSelectARX("21-M1210-00001", FileData)
        embed_Here2.Attributes.Add("type", "application/octet-stream")
        embed_Here2.Attributes.Add("src", "data:application/octet-stream;base64," & Convert.ToBase64String(FileData))
        Response.Write(Convert.ToBase64String(FileData))
    End Sub

End Class