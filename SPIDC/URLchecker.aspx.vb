Imports System.Threading.Tasks

Public Class URLchecker
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim rand As New Random() ' Create a new instance of the Random class    


            Td1.InnerText = HttpContext.Current.Request.Url.AbsoluteUri


            Td2.InnerText = HttpContext.Current.Request.Url.Host

            Td3.InnerText = HttpContext.Current.Request.Url.Authority

            Td4.InnerText = HttpContext.Current.Request.Url.Port
            Td5.InnerText = HttpContext.Current.Request.Url.AbsolutePath
            Td6.InnerText = HttpContext.Current.Request.ApplicationPath
            Td7.InnerText = HttpContext.Current.Request.Url.PathAndQuery
            Td8.InnerText = HttpContext.Current.Request.RawUrl
            Td9.InnerText = HttpContext.Current.Request.Url.AbsoluteUri.Split("//")(0).ToString

        Catch ex As Exception

        End Try
    End Sub

End Class