Public Class Sample
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetInitialRow()
        
    End Sub
    Private Sub SetInitialRow()
        Dim dt As DataTable = New DataTable()
        Dim dr As DataRow = Nothing
        dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
        dt.Columns.Add(New DataColumn("Column1", GetType(String)))
        dt.Columns.Add(New DataColumn("Column2", GetType(String)))
        dt.Columns.Add(New DataColumn("Column3", GetType(String)))
        dr = dt.NewRow()
        dr("RowNumber") = 1
        dr("Column1") = String.Empty
        dr("Column2") = String.Empty
        dr("Column3") = String.Empty
        dt.Rows.Add(dr)
        ViewState("CurrentTable") = dt
        Gridview1.DataSource = dt
        Gridview1.DataBind()
    End Sub
End Class