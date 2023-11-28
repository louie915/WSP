
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Services
Imports System.Collections
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Net

Imports System.Security.Cryptography.X509Certificates
Imports System.Net.Security

Public Class Calendar
    Inherits System.Web.UI.Page
  

    Public Class [Event]
        Public Property SQLDate As String
        Public Property AppDate As String
        Public Property Office As String
        Public Property Total As Integer
        Public Property Color As String
        Public Property Url As String
    End Class

    <WebMethod>
    Public Shared Function GetEvents() As IList
        Try

            Dim status = False
            Dim events As IList = New List(Of [Event])()
            Dim _nSqlCommand As SqlCommand
            Dim _nDataTable As DataTable
            Dim _nQuery As String = Nothing
            Dim colorselected As String = ""
            '  _nQuery = "SELECT (select replace(convert(varchar,getdate(),102),'.','-')) as 'SQLDate',*,(Time1+time2+time3+time4+time5+time6+time7+time8+time9) as 'Total'   FROM [Appointmentwithtime]  ORDER BY APPDATE"
            _nQuery = "SELECT (select replace(convert(varchar,getdate(),102),'.','-')) as 'SQLDate',*,AM_Slot as 'Total' from [AppointmentSlot] where office='BPLO' order by AppDate desc"

            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _nDataTable = New DataTable
            _nSqlDataAdapter.Fill(_nDataTable)

            Dim _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
            For Each row In _nDataTable.Rows
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read()
                        Dim _SQLDate As Date = _nSqlDr.Item("SQLDate")
                        Dim _AppDate As Date = _nSqlDr.Item("AppDate")

                        If _AppDate < _SQLDate Then
                            colorselected = "#666669" ' Gray for Past Dates
                        Else
                            colorselected = "#5070DA" ' Blue
                        End If

                        events.Add(New [Event] With {
                        .SQLDate = _nSqlDr.Item("SQLDate"),
                        .AppDate = _nSqlDr.Item("AppDate"),
                        .Office = _nSqlDr.Item("Office"),
                        .Total = _nSqlDr.Item("Total"),
                        .Color = colorselected
                    })
                    Loop
                End If
                Return events
            Next


        Catch ex As Exception

        End Try
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim siteContent As String = String.Empty
        Dim url As String = "https://222.127.109.48/epp20200915/api2-status.php"
        Dim Params As String = "?MerchantCode=2020060003&MerchantRefNo=BP210210-00010&SecretKey=416d1fceecdaceb21b600a52b63b526d&Hash=4efc9e5f477349ad6b9d0d7d7e088666"
        Dim request As HttpWebRequest = CType(WebRequest.Create(url + Params), HttpWebRequest)
        request.AutomaticDecompression = DecompressionMethods.GZip
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
        Dim responseStream As Stream = response.GetResponseStream()
        Using streamReader As StreamReader = New StreamReader(responseStream)
            siteContent = streamReader.ReadToEnd()
        End Using
        htmlBody.InnerHtml = siteContent
    End Sub


End Class