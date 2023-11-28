
Imports Microsoft.Reporting.WebForms
Imports System.Reflection
Imports System.IO
Imports SPIDC.Resources

Public Class ApplicationSuccess
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            cSessionLoader._pLGU_Name = "[LGU NAME]"
            cSessionLoader._pLGU_Address = ""
            'cSessionLoader._pAccountNo = "200324-00001"
            'cSessionLoader._pCurrentYear = Year(Now)
            'cLoader_BPLTIMS._pSTATCODE = "N"
            '_GenerateReport_EnvelopeSeal()
            '_RenderToPDF("EnvelopeSeal")
            '_GenerateReport_ApplicationForm()
            '_RenderToPDF("ApplicationForm")

            '_SendEmailNotif()
        End If

    End Sub

    Public Sub _SendEmailNotif()

        Try
            Dim _nClass As New cDalSendEmail
            With _nClass
                ._pEmailTo = cSessionUser._pUserID
                ._pSubject = "BUSINESS PERMIT APPLICATION STATUS"
                ._pHeader = cSessionLoader._pLGU_Name
                ._pBody = "Sir/Ma`am: <br> " & _
                            "Your Business Account Number " & cSessionLoader._pAccountNo & " is now for review and verification by Business Permit Licensing Officer. <br>" & _
                            "Please wait for 1 working day for approval of application. <br>" & _
                            "Thank you. <br>"
                ._pFooter = "<br> Date Sent : " & Now.Date & _
                            "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."

                Dim filepath As String = HttpContext.Current.Server.MapPath("~/Temp/")
                Dim _nFileName As String = cSessionLoader._pAccountNo & "_EnvelopeSeal.pdf"
                Dim _nFileName2 As String = cSessionLoader._pAccountNo & "_ApplicationForm.pdf"

                ._pAttachment.Add(filepath & _nFileName)
                ._pAttachment.Add(filepath & _nFileName2)


                If ._FnSendEmail() = True Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('email success');", True)
                Else
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('email failed');", True)
                End If
            End With
        Catch ex As Exception
            cDalLogEvent._pSubLogError(ex)
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" & ex.Message & "');", True)
        End Try


    End Sub


    Protected Sub _Export(_nReportType As String)
        Try
            Dim warnings As Warning()
            Dim streamIds As String()
            Dim contentType As String
            Dim encoding As String
            Dim extension As String

            Dim bytes As Byte() = _oReportPreview.LocalReport.Render("PDF", Nothing, contentType, encoding, extension, streamIds, warnings)

            'Export the RDLC Report to Byte Array.

            'Download the RDLC Report in Word, Excel, PDF and Image formats.
            Response.Clear()
            Response.Buffer = True
            Response.Charset = ""
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = contentType
            Response.AppendHeader("Content-Disposition", "attachment; filename=" & _nReportType & "_" & cSessionLoader._pAccountNo & "." & ".pdf")
            Response.BinaryWrite(bytes)
            Response.Flush()
            Response.End()


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub


    Public Sub _RenderToPDF(_nDocName As String)
        Try
            Dim warnings As Warning() = Nothing
            Dim streamids As String() = Nothing
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim extension As String = Nothing
            Dim bytes As Byte()
            Dim _nFileName As String = cSessionLoader._pAccountNo & "_" & _nDocName & ".pdf"

            bytes = _oReportPreview.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

            Dim FolderLocation As String = HttpContext.Current.Server.MapPath("~/Temp/")
            'First delete existing file
            Dim filepath As String = FolderLocation & _nFileName
            File.Delete(filepath)
            'Then create new pdf file
            bytes = _oReportPreview.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)
            Dim fs As New FileStream(FolderLocation & _nFileName, FileMode.Create)
            fs.Write(bytes, 0, bytes.Length)
            fs.Close()
            'Set the appropriate ContentType.
            Response.ContentType = "Application/pdf"
            'Write the file directly to the HTTP output stream.
            Response.WriteFile(filepath)
            HttpContext.Current.ApplicationInstance.CompleteRequest()
            ' Response.End()

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ExportEnvelopeSeal(ByVal sender As Object, ByVal e As EventArgs)
        Try
            _GenerateReport_EnvelopeSeal()
            ' _Export("EnvelopeSeal")


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub

    Protected Sub ExportEnvelopeApplicationForm(ByVal sender As Object, ByVal e As EventArgs)
        Try
            _GenerateReport_ApplicationForm()
            _Export("ApplicationForm")

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub
    Public Sub _GenerateReport_EnvelopeSeal()
        Try
            Dim _nClass As New cDalEnvelopeSeal
            With _nClass

                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                cSessionLoader._pAccountNo = cSessionLoader._pAccountNo '"190521-00001"

                ._pSubSelect(, " WHERE ACCTNO = '" & cSessionLoader._pAccountNo & "'")

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.HasErrors Then
                    Return
                End If

                If _nDataTable.Rows.Count <= 0 Then
                    _oReportPreview.Enabled = False
                Else
                    _oReportPreview.Enabled = True
                End If

                _oReportPreview.Reset()
                '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
                Dim info As FieldInfo

                For Each extension As RenderingExtension In _oReportPreview.LocalReport.ListRenderingExtensions
                    If extension.Name <> "PDF" Then
                        info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                        info.SetValue(extension, False)
                    End If
                Next
                '--------END (Shows only PDF as EXPORT Extension)-uneditable print format


                _oReportPreview.LocalReport.ReportPath = _gResxRdlc.pReportEnvelopeSeal
                _oReportPreview.LocalReport.EnableExternalImages = True

                _oReportPreview.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "ds_EnvelopeSeal"
                _nReportDataSource.Value = _nDataTable
                _oReportPreview.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("LGUAddress", cSessionLoader._pLGU_Address))
                _oReportPreview.LocalReport.SetParameters(paramList)

                _oReportPreview.AsyncRendering = True
                _oReportPreview.LocalReport.Refresh()
                _oReportPreview.Enabled = True

            End With


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub
    Public Sub _GenerateReport_ApplicationForm()
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog

            cSessionLoader._pBPLTAS_SvrName = _nLiveServerName
            cSessionLoader._pBPLTAS_DbName = _nLiveDatabaseName

            Dim _nClass As New cDalApplicationInfo
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAcctNo = cSessionLoader._pAccountNo
                ._pForYear = cSessionLoader._pCurrentYear
                ._pLiveSvr = cSessionLoader._pBPLTAS_SvrName
                ._pLiveDb = cSessionLoader._pBPLTAS_DbName

                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.HasErrors Then
                    Return
                End If

                If _nDataTable.Rows.Count <= 0 Then
                    _oReportPreview.Enabled = False
                Else
                    _oReportPreview.Enabled = True
                End If

                _oReportPreview.Reset()

                '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
                Dim info As FieldInfo

                For Each extension As RenderingExtension In _oReportPreview.LocalReport.ListRenderingExtensions
                    If extension.Name <> "PDF" Then
                        info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                        info.SetValue(extension, False)
                    End If
                Next
                '--------END (Shows only PDF as EXPORT Extension)-uneditable print format


                'Dim exportOption1 As String = "Excel"
                'Dim exportOption2 As String = "Word"
                'Dim extension1 As RenderingExtension = _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption1, StringComparison.CurrentCultureIgnoreCase))
                'Dim extension2 As RenderingExtension = _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption2, StringComparison.CurrentCultureIgnoreCase))
                'If extension1 IsNot Nothing And extension2 IsNot Nothing Then
                '    Dim fieldInfo As System.Reflection.FieldInfo = extension1.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
                '    fieldInfo.SetValue(extension1, False)
                '    Dim fieldInfo2 As System.Reflection.FieldInfo = extension2.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
                '    fieldInfo2.SetValue(extension2, False)
                'End If

                _oReportPreview.LocalReport.ReportPath = _gResxRdlc.pReportApplicationInfo
                _oReportPreview.LocalReport.EnableExternalImages = True

                _oReportPreview.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "ds_Application"
                _nReportDataSource.Value = _nDataTable
                _oReportPreview.LocalReport.DataSources.Add(_nReportDataSource)

                Dim _TotalEmp As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_TOTAL") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_TOTAL"))
                Dim _NoEmpLGU As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_LGU") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_LGU"))
                Dim paramList As New List(Of ReportParameter)


                paramList.Add(New ReportParameter("Status", cLoader_BPLTIMS._pSTATCODE))
                paramList.Add(New ReportParameter("Emp_Total", _TotalEmp))
                paramList.Add(New ReportParameter("Emp_LGU", _NoEmpLGU))
                _oReportPreview.LocalReport.SetParameters(paramList)

                _oReportPreview.AsyncRendering = True
                _oReportPreview.LocalReport.Refresh()
                _oReportPreview.Enabled = True

            End With
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try
    End Sub

    Protected Sub _GenerateEnvelopeSeal()
        Try

            Response.Redirect("Report/Report.aspx?ReportType=EnvelopeSeal" & "&AccountNo=" & cSessionLoader._pAccountNo)

            ' cUrlRedirects._pSubRedirect(rPages_VS2014WABPLTIMS.pReport & "?ReportType=EnvelopeSeal" & "&AccountNo=" & cSessionLoader._pAccountNo, , 1)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub

    Protected Sub _GenerateApplicationForm()
        Try
            Response.Redirect("Report/Report.aspx?ReportType=ApplicationForm" & "&AccountNo=" & cSessionLoader._pAccountNo & "&ForYear=" & cSessionLoader._pCurrentYear)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub

End Class