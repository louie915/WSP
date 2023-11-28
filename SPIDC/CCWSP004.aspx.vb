Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports System.Net.WebUtility.HtmlDecode



Public Class CCWSP004
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sb = New System.Text.StringBuilder()
        For Each key As String In Request.QueryString.Keys
            If Request.QueryString(key) <> Nothing Then
                sb.AppendFormat("<input type='text' name='" & key & "' value='{0}'>", Request.QueryString(key))
            End If
        Next

        '  Dim a As Object = Request.Form
        ' Dim b As String = HttpUtility.HtmlDecode(Trim(Request.Form("data").ToString))
        ' 'Response.Write(a)
        '   b = b.ToString.Replace("\", "")
        ' b = b.ToString.Replace("%22", """")
        ' b = b.ToString.Replace("%5c", "")
        '
        ' ' b = b.ToString.Replace("=&", "}")
        ' ' b = b.ToString.Replace("%2c", ",")
        ' b = b.ToString.Replace("%3a", ":")
        ' ' b = b.ToString.Replace("%7d", "")
        ' '
        ' b = b.ToString.Replace("+", " ")
        ' ' Response.Write(a)
        ' Response.Write("<br>")
        ' Response.Write(b)
        '  Dim jsonstr As String = "{""company_information"":{""id"": 1, ""title"": ""foo"", ""data"":""bar""}}"
        '  
        '
        '  Dim resultT As test = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of test)(jsonstr)
        '  Dim a As String = resultT.company_information.ToString()
        '  Response.Write(b)

        ' Dim json As String = System.IO.File.ReadAllText(Server.MapPath("~/JSON.txt")).Replace(System.Environment.NewLine, "")
        ' Dim result As JsonResult = New System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of JsonResult)(json)


    End Sub
    Public Class test
        Public Property id As String
        Public Property company_information As List(Of company_information1)
    End Class

    Public Class company_information1
        Public Property id As String
        Public Property title As String
        Public Property data As String

    End Class

   


End Class