Imports SPIDC.Resources
Imports System.ComponentModel
Imports Microsoft.Reporting.WebForms
Imports System.Web.UI
Imports VB.NET.Email
Imports System.Net
Imports System.IO
Imports System.Reflection
Imports System.Net.Mail
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports QRCoder
Imports System.Drawing
Imports System.Web.HttpContext

Public Class ReportViewer2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                _GenerateReport_AppointmentSlip()
                _ExportToPDF()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _GenerateReport_AppointmentSlip(ByVal AppID As String)
        Try
            Dim _nClass As New cDalAppointment
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

                Dim _nDataTable As New DataTable
                _nDataTable = .Get_AppointmentSlip(AppID)

                If _nDataTable.HasErrors Then
                    Return
                End If

                If _nDataTable.Rows.Count <= 0 Then
                    _oRpt_EnvelopeSeal.Enabled = False
                Else
                    _oRpt_EnvelopeSeal.Enabled = True
                End If

                _oRpt_EnvelopeSeal.Reset()
                '-------- (Shows only PDF as EXPORT Extension)-uneditable print format
                Dim info As FieldInfo

                For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                    If extension.Name <> "PDF" Then
                        info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                        info.SetValue(extension, False)
                    End If
                Next
                '--------END (Shows only PDF as EXPORT Extension)-uneditable print format

                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pAppointmentSlip
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = False

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "DataSet1"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("ParamSchedulerName", cSessionUser._pLastName & ", " & cSessionUser._pFirstName))

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True

            End With


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub
    Public Sub _ExportToPDF(ByVal DocType As String, Optional ByVal ID As String = Nothing)
        Try
            Dim warnings As Warning()
            Dim streamIds As String()
            Dim contentType As String
            Dim encoding As String
            Dim extension As String

            'Export the RDLC Report to Byte Array.
            Dim bytes As Byte() = _oRpt_EnvelopeSeal.LocalReport.Render("PDF", Nothing, contentType, encoding, extension, streamIds, warnings)
            'Download the RDLC Report in Word, Excel, PDF and Image formats.
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.Charset = ""
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
            HttpContext.Current.Response.ContentType = contentType
            If String.IsNullOrEmpty(ID) Then
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & DocType & "_" & cSessionLoader._pAccountNo & ".pdf")
            Else
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & DocType & "_" & ID & ".pdf")
            End If

            HttpContext.Current.Response.BinaryWrite(bytes)
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.End()
        Catch ex As Exception
            HttpContext.Current.Response.Write(ex.Message)
        End Try

        '
    End Sub
End Class