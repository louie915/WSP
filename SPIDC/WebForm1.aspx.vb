Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Services
Public Class WebForm1
    Inherits System.Web.UI.Page
    <WebMethod()>
    Public Shared Sub DeleteBookMark(ByVal BookmnarkID As String())
        For Each id As String In BookmnarkID
            ' DeleteBookMark(id)
        Next
    End Sub

    Public Shared Sub DeleteBookMark(ByVal BookmarkID As Integer)
        Dim conn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("connString").ConnectionString)
        conn.Open()
        Dim cmd As SqlCommand = New SqlCommand()
        cmd.Connection = conn
        cmd.CommandText = "usp_RemoveBookmark"
        cmd.CommandType = CommandType.StoredProcedure
        Dim param1 As SqlParameter = New SqlParameter("@IN_BookmarkID", BookmarkID)
        cmd.Parameters.Add(param1)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class