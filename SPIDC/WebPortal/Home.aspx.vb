Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnBP_ServerClick(sender As Object, e As EventArgs) Handles btnBP.ServerClick
        '  Session("SingleModule") = "BP"
        '  Response.Redirect("Account.aspx")
    End Sub

    Private Sub btnRPT_ServerClick(sender As Object, e As EventArgs) Handles btnRPT.ServerClick
        Session("SingleModule") = "RPT"
        Response.Redirect("Account.aspx")
    End Sub
End Class