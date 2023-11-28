
Imports RestSharp
Imports System.Net
Imports System.IO
Imports System.Web
Imports System.Web.Script.Serialization
Imports System
Imports Newtonsoft.Json.Linq
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Net.Mail
Imports RestSharp.Serializers
Imports Newtonsoft.Json
Imports Microsoft.Reporting.WebForms
Imports System.Reflection
Imports SPIDC.Resources
Imports System.Web.UI


Public Class cInit_eOR

    Private Shared SelectedGateway As String
    Private Shared SPIDCRefNo As String
    Private Shared PAYMENT_ID As String
    Private Shared Report_EOR = New ReportViewer
    Private Shared ClientScript As ClientScriptManager

    Public Shared Function IsEOR_Enabled() As Boolean
        Dim _nclassGetModules As New cDalGetModules
        Return _nclassGetModules._pSubGetAvailableModules("EOR")
    End Function

    Public Shared Function Initialize_EOR(ByVal xSPIDCRefNo, ByVal xReport_EOR, ByVal xSelectedGateway, ByVal xPAYMENT_ID) As Boolean
        Initialize_EOR = True


        SelectedGateway = xSelectedGateway
        SPIDCRefNo = xSPIDCRefNo
        Report_EOR = xReport_EOR
        PAYMENT_ID = xPAYMENT_ID

        Dim TaxpayerEmail As String = Nothing
        Dim ACCTNO As String = Nothing
        Dim StatusId As String = Nothing
        Dim PaymentFor As String = Nothing
        Dim _nclass As New cDalPayment
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

        Dim _nclassGetModules As New cDalGetModules
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

        Dim eorno As String = Nothing
        Dim isTaxpayer As Boolean = True
        Dim _nclasseOR As New eOR_Jaka
        Dim _nClassPost As New Process
        Dim err As String = Nothing

        If _nclassGetModules._pSubGetAvailableModules("EOR") = True Then
            If _nclasseOR.isEOR_Exists(SPIDCRefNo) = False Then


                If _nclasseOR.getTransactionType(SPIDCRefNo) <> "RPT" Then Return False

                Process.ACCTNO = _nclasseOR.getACCTNO(SPIDCRefNo)

                '-----New Addedd 11-03-2023 JAY SITJAR-----
                cSessionLoader._pTDN = _nclasseOR.getTDN1(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclasseOR.getTDNHist1(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclasseOR.moveRPTAssessmentFromHistToCurrent1(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclasseOR.getTDN(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclasseOR.getTDNHist(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclasseOR.moveRPTAssessmentFromHistToCurrent(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclasseOR.getTDN2(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclasseOR.getTDNHist2(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclasseOR.moveRPTAssessmentFromHistToCurrent2(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclasseOR.getTDN3(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclasseOR.getTDNHist3(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclasseOR.moveRPTAssessmentFromHistToCurrent3(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If


                End If
                '-----End Addedd 11-03-2023 JAY SITJAR-----

                Process.Gateway_Selected = SelectedGateway
                Process.GatewayRefNo = PAYMENT_ID
                eOR.Gateway_RefNo = PAYMENT_ID
                eOR.TaxPayerEmail = _nclasseOR.getEMAIL(SPIDCRefNo) 'TaxpayerEmail
                Process.TransactionType = _nclasseOR.getTransactionType(SPIDCRefNo)
                eOR.SPIDC_RefNo = SPIDCRefNo
                _nClassPost.START_POSTING(err, eorno, isTaxpayer, SPIDCRefNo)
                _GenerateReport_eOR(1, Process.TransactionType, eorno)
                'Response.Write("<script>alert('E-OR has been sent to your EMAIL.');</script>")

            End If
        End If
    End Function

    Public Shared Sub _GenerateReport_eOR(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String)

        Try


            Dim _nclassEOR As New eOR

            Dim _nDataTable0 As New DataTable
            _nDataTable0 = _nclassEOR.Print_Template

            Dim _nDataTable1 As New DataTable
            _nDataTable1 = _nclassEOR.Print_Report(eORNO)

            Dim _nDataTable2 As New DataTable
            _nDataTable2 = _nclassEOR.Print_TOP(eORNO)

            Report_EOR.reset()
            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo

            For Each extension As RenderingExtension In Report_EOR.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format
            If TAXTYPE_eOR = "REAL PROPERTY TAX" Or TAXTYPE_eOR = "RPT" Then
                Report_EOR.LocalReport.ReportPath = _gResxRdlc.pEOR_RPT2
            ElseIf TAXTYPE_eOR = "BUSINESS PERMIT" Or TAXTYPE_eOR = "BP" Then
                Report_EOR.LocalReport.ReportPath = _gResxRdlc.pEOR_BP2
            End If

            Report_EOR.LocalReport.EnableExternalImages = False

            Report_EOR.LocalReport.DataSources.Clear()

            Dim _nReportDataSource0 As New ReportDataSource
            _nReportDataSource0.Name = "DataSet0"
            _nReportDataSource0.Value = _nDataTable0
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource0)

            Dim _nReportDataSource1 As New ReportDataSource
            _nReportDataSource1.Name = "DataSet1"
            _nReportDataSource1.Value = _nDataTable1
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource1)

            Dim _nReportDataSource2 As New ReportDataSource
            _nReportDataSource2.Name = "DataSet2"
            _nReportDataSource2.Value = _nDataTable2
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource2)


            Dim ds_TotalAmount As String
            For Each row As DataRow In _nDataTable2.Rows
                ds_TotalAmount += CDec(row("Amount"))
            Next

            Dim _eOr As New eOR
            Dim strAmount As String = Nothing
            strAmount = _eOr.AmountInWords(ds_TotalAmount)

            Dim paramList As New List(Of ReportParameter)
            paramList.Add(New ReportParameter("AmountInWords", strAmount.ToUpper))

            Report_EOR.LocalReport.SetParameters(paramList)

            Report_EOR.AsyncRendering = True
            Report_EOR.LocalReport.Refresh()
            Report_EOR.Enabled = True


            If _send = 1 Then
                Dim bytes As Byte() = Report_EOR.LocalReport.Render("PDF")
                Dim sent As Boolean = False
                Dim err As String = Nothing
                Dim body As String

                body = "Dear Valued Tax Payer, <br> " & _
                       "This confirms your bill payment transaction with the following details: <br> " & _
                       "Transaction Number: " & _nDataTable1.Rows(0)("OnlineId") & "<br>" & _
                       "Transaction Type: " & _nDataTable1.Rows(0)("TaxType") & " Payment<br>" & _
                       "Account No. : " & _nDataTable1.Rows(0)("TDNBIN") & "<br>" & _
                       "Amount Paid : " & _nDataTable1.Rows(0)("GrandTotal") & "<br> <br>" & _
                       "Your Electronic Official Receipt is attached in this e-mail."

                cDalNewSendEmail.Send_eOR(eOR.TaxPayerEmail, "Electronic Official Receipt", body, bytes, sent, err)

                If String.IsNullOrEmpty(err) = True Then
                    eOR.Update_Sent(_nDataTable1.Rows(0)("eORNO"), err)
                    '   ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                    ClientScript.RegisterStartupScript(GetType(cInit_eOR), "myScript", "window.alert('E-OR Sent Successfully');", True)
                    Exit Sub
                End If

                'If sent = True Then
                '    Response.Clear()
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                'Else
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + err + "');", True)
                'End If

            End If


        Catch ex As Exception
            ClientScript.RegisterStartupScript(GetType(cInit_eOR), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub


End Class
