Imports Microsoft.Reporting.WebForms
Imports SPIDC.Resources
Imports System.Reflection
Imports System.Data.SqlClient

Public Class runEORandPosting
    Inherits System.Web.UI.Page
    Public Shared _mSqlCon As New SqlConnection
    Public Shared _mSqlCmd As SqlCommand
    Public Shared _mDataTable As New DataTable
    Public Shared _mDataAdapter As New SqlDataAdapter
    Public Shared _mDataset As New DataSet
    Public Shared _mStrSql As String
    Public Shared _mStrSql1 As String
    Public Shared _mStrSql2 As String
    Public Shared _mStrSql3 As String
    Private Property _URL As String = HttpContext.Current.Request.Url.AbsoluteUri


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'PayMaya FIELD

        PayMayaField()
        'GCash FIELD
        GcashField()
        'LBP1 FIELD
        LBP1Field()
        'LBP2 FIELD
        LBP2Field()
        Response.Write("<script>sessionStorage.setItem('_gateWay', '" & Session("runEORandPostingPaymentGateway") & "');</script>")
    End Sub

    'RUN THE EOR AND POSTING AND OTHER PAYMAYA
    Private Sub _btnRunEORandPostingPaymaya_ServerClick(sender As Object, e As EventArgs) Handles _btnRunEORandPostingPaymaya.ServerClick
        'Check EOR Is Active
        If _checkEORMOduleIsActive() Then
            Dim GatewayStatusPaymaya As String = _GatewayStatusPaymaya.Value
            Dim PaymentReferencePaymaya As String = Nothing
            Dim GatewayReferencePaymaya As String = Nothing
            If Not String.IsNullOrEmpty(Session("runEORandPostingPaymentRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingGatewayRefNo")) Then
                PaymentReferencePaymaya = Session("runEORandPostingPaymentRefNo")
                GatewayReferencePaymaya = Session("runEORandPostingGatewayRefNo")
            Else
                PaymentReferencePaymaya = _PaymentReferencePaymaya.Value
                GatewayReferencePaymaya = _GatewayReferencePaymaya.Value
            End If
            'Response.Write("<script>setTimeout(function() {document.getElementsByClassName('loader-title')[0].textContent = 'Please wait while processing...'; loader.show();}, 1000);</script>")
            runEORAndPostingPaymaya(GatewayStatusPaymaya, PaymentReferencePaymaya, GatewayReferencePaymaya)
        Else
            Response.Write("<script>alert('EOR AND POSTING IS DISABLED');</script>")
        End If

    End Sub

    'RUN THE EOR AND POSTING AND OTHER GCASH
    Private Sub _btnRunEORandPostingGcash_ServerClick(sender As Object, e As EventArgs) Handles _btnRunEORandPostingGcash.ServerClick
        'Check EOR Is Active
        If _checkEORMOduleIsActive() Then
            Dim GatewayStatusGcash As String = _GatewayStatusGcash.Value
            Dim PaymentReferenceGcash As String = Nothing
            Dim GatewayReferenceGcash As String = Nothing

            If Not String.IsNullOrEmpty(Session("runEORandPostingPaymentRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingGatewayRefNo")) Then
                PaymentReferenceGcash = Session("runEORandPostingPaymentRefNo")
                GatewayReferenceGcash = Session("runEORandPostingGatewayRefNo")
            Else
                PaymentReferenceGcash = _PaymentReferenceGcash.Value
                GatewayReferenceGcash = _GatewayReferenceGcash.Value
            End If
            'Response.Write("<script>setTimeout(function() {document.getElementsByClassName('loader-title')[0].textContent = 'Please wait while processing...'; loader.show();}, 1000);</script>")
            runEORAndPostingGcash(GatewayStatusGcash, PaymentReferenceGcash, GatewayReferenceGcash)
        Else
            Response.Write("<script>alert('EOR AND POSTING IS DISABLED');</script>")
        End If

    End Sub

    'RUN THE EOR AND POSTING AND OTHER LB1
    Private Sub _btnRunEORandPostingLBP1_ServerClick(sender As Object, e As EventArgs) Handles _btnRunEORandPostingLBP1.ServerClick
        'Check EOR Is Active
        If _checkEORMOduleIsActive() Then
            Dim GatewayStatusLBP1 As String = _GatewayStatusLBP1.Value
            Dim PaymentReferenceLBP1 As String = Nothing
            Dim GatewayReferenceLBP1 As String = Nothing
            If Not String.IsNullOrEmpty(Session("runEORandPostingPaymentRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingGatewayRefNo")) Then
                PaymentReferenceLBP1 = Session("runEORandPostingPaymentRefNo")
                GatewayReferenceLBP1 = Session("runEORandPostingGatewayRefNo")
            Else
                PaymentReferenceLBP1 = _PaymentReferenceLBP1.Value
                GatewayReferenceLBP1 = _GatewayReferenceLBP1.Value
            End If
            'Response.Write("<script>setTimeout(function() {document.getElementsByClassName('loader-title')[0].textContent = 'Please wait while processing...'; loader.show();}, 1000);</script>")
            runEORAndPostingLBP1(GatewayStatusLBP1, PaymentReferenceLBP1, GatewayReferenceLBP1)
        Else
            Response.Write("<script>alert('EOR AND POSTING IS DISABLED');</script>")
        End If

    End Sub

    'RUN THE EOR AND POSTING AND OTHER LB2
    Private Sub _btnRunEORandPostingLBP2_ServerClick(sender As Object, e As EventArgs) Handles _btnRunEORandPostingLBP2.ServerClick
        'Check EOR Is Active
        If _checkEORMOduleIsActive() Then
            Dim GatewayStatusLBP2 As String = _GatewayStatusLBP2.Value
            Dim PaymentReferenceLBP2 As String = Nothing
            Dim GatewayReferenceLBP2 As String = Nothing
            If Not String.IsNullOrEmpty(Session("runEORandPostingPaymentRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingGatewayRefNo")) Then
                PaymentReferenceLBP2 = Session("runEORandPostingPaymentRefNo")
                GatewayReferenceLBP2 = Session("runEORandPostingGatewayRefNo")
            Else
                PaymentReferenceLBP2 = _PaymentReferenceLBP2.Value
                GatewayReferenceLBP2 = _GatewayReferenceLBP2.Value
            End If
            'Response.Write("<script>setTimeout(function() {document.getElementsByClassName('loader-title')[0].textContent = 'Please wait while processing...'; loader.show();}, 1000);</script>")
            runEORAndPostingLBP2(GatewayStatusLBP2, PaymentReferenceLBP2, GatewayReferenceLBP2)
        Else
            Response.Write("<script>alert('EOR AND POSTING IS DISABLED');</script>")
        End If

    End Sub



    'PayMaya FIELD
    Private Sub PayMayaField()
        If Not String.IsNullOrEmpty(Session("runEORandPostingPaymentRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingGatewayRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingPaymentGateway")) Then
            If Session("runEORandPostingPaymentGateway") = "PAYMAYA" Then
                _PaymentReferencePaymaya.Value = Session("runEORandPostingPaymentRefNo")
                _GatewayReferencePaymaya.Value = Session("runEORandPostingGatewayRefNo")
            Else
                'Do Nothing
            End If

        Else
            _PaymentReferencePaymaya.Value = ""
            _GatewayReferencePaymaya.Value = ""
        End If
    End Sub


    'RUN THE EOR AND POSTING AND OTHER PAYMAYA
    Sub runEORAndPostingPaymaya(GatewaySTatus As String, SPIDCREFNO As String, gatewayRefNo As String)
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
            If _nclasseOR.isEOR_Exists(SPIDCREFNO) = False Then
                Process.ACCTNO = _nclasseOR.getACCTNO(SPIDCREFNO)

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

                Process.Gateway_Selected = "PAYMAYA"
                Process.GatewayRefNo = gatewayRefNo
                eOR.Gateway_RefNo = gatewayRefNo
                eOR.TaxPayerEmail = _nclasseOR.getEMAIL(SPIDCREFNO) 'TaxpayerEmail
                Process.TransactionType = _nclasseOR.getTransactionType(SPIDCREFNO)
                eOR.SPIDC_RefNo = SPIDCREFNO
                _nClassPost.START_POSTING(err, eorno, isTaxpayer, SPIDCREFNO)
                _GenerateReport_eORPaymaya(1, Process.TransactionType, eorno)
                'Response.Write("<script>alert('E-OR has been sent to your EMAIL.');</script>")
            End If
        End If


    End Sub

    'PAYMAYA
    Public Sub _GenerateReport_eORPaymaya(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String)
        Try
            Dim _nclassEOR As New eOR

            Dim _nDataTable0 As New DataTable
            _nDataTable0 = _nclassEOR.Print_Template

            Dim _nDataTable1 As New DataTable
            _nDataTable1 = _nclassEOR.Print_Report(eORNO)

            Dim _nDataTable2 As New DataTable
            _nDataTable2 = _nclassEOR.Print_TOP(eORNO)



            Report_EOR.Reset()
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


            Dim ds_TotalAmount As String = Nothing
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

                '11/06/2023 JAY SITJAR
                'Set TO Nothning runeor session
                Session("runEORandPostingGatewayRefNo") = Nothing
                Session("runEORandPostingPaymentRefNo") = Nothing
                Session("runEORandPostingPaymentGateway") = Nothing
                'End JAY SITJAR

                If String.IsNullOrEmpty(err) = True Then
                    eOR.Update_Sent(_nDataTable1.Rows(0)("eORNO"), err)
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", " loader.hide(); window.alert('E-OR Sent Successfully'); setTimeout(function() { window.location.replace('" & _URL.Replace("/runEORandPosting.aspx", "/LGU_OPL.aspx") & "'); }, 1000); ", True)
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try
    End Sub



    'GCASH FIELD
    Private Sub GcashField()
        If Not String.IsNullOrEmpty(Session("runEORandPostingPaymentRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingGatewayRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingPaymentGateway")) Then
            If Session("runEORandPostingPaymentGateway") = "GCASH" Then
                _PaymentReferenceGcash.Value = Session("runEORandPostingPaymentRefNo")
                _GatewayReferenceGcash.Value = Session("runEORandPostingGatewayRefNo")
            Else
                'Do Nothing
            End If
        Else
            _PaymentReferenceGcash.Value = ""
            _GatewayReferenceGcash.Value = ""
        End If
    End Sub

    'RUN THE EOR AND POSTING AND OTHER GCASH
    Sub runEORAndPostingGcash(GatewaySTatus As String, SPIDCREFNO As String, gatewayRefNo As String)
        Try
            Dim isTaxpayer As Boolean = True
            Dim err As String = Nothing
            Dim eORNO As String = Nothing
            Dim _nclass As New cDalPayment
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nclassGetModules As New cDalGetModules
            Dim _nclassEOR As New eOR_Jaka
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            Dim _nClassPost As New Process

            If _nclassEOR.isEOR_Exists(SPIDCREFNO) = False Then
                Process.ACCTNO = _nclassEOR.getACCTNO(SPIDCREFNO)
                '-----New Addedd 11-03-2023 JAY SITJAR-----
                cSessionLoader._pTDN = _nclassEOR.getTDN1(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist1(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent1(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN2(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist2(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent2(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN3(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist3(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent3(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If


                End If
                '-----End Addedd 11-03-2023 JAY SITJAR-----



                Process.Gateway_Selected = "GCASH"
                Process.GatewayRefNo = gatewayRefNo
                eOR.Gateway_RefNo = gatewayRefNo
                eOR.TaxPayerEmail = _nclassEOR.getEMAIL(SPIDCREFNO)
                Process.TransactionType = _nclassEOR.getTransactionType(SPIDCREFNO)
                eOR.SPIDC_RefNo = SPIDCREFNO
                _nClassPost.START_POSTING(err, eORNO, isTaxpayer, gatewayRefNo)
                _GenerateReport_eORGcash(1, Process.TransactionType, eORNO)
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
    'GCASH
    Public Sub _GenerateReport_eORGcash(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String)
        Try
            Dim _nclassEOR As New eOR

            Dim _nDataTable0 As New DataTable
            _nDataTable0 = _nclassEOR.Print_Template

            Dim _nDataTable1 As New DataTable
            _nDataTable1 = _nclassEOR.Print_Report(eORNO)

            Dim _nDataTable2 As New DataTable
            _nDataTable2 = _nclassEOR.Print_TOP(eORNO)



            Report_EOR.Reset()
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


            Dim ds_TotalAmount As String = Nothing
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
                '11/06/2023 JAY SITJAR
                'Set TO Nothning runeor session
                Session("runEORandPostingGatewayRefNo") = Nothing
                Session("runEORandPostingPaymentRefNo") = Nothing
                Session("runEORandPostingPaymentGateway") = Nothing
                'End JAY SITJAR
                If String.IsNullOrEmpty(err) = True Then
                    eOR.Update_Sent(_nDataTable1.Rows(0)("eORNO"), err)
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", " loader.hide(); window.alert('E-OR Sent Successfully'); setTimeout(function() { window.location.replace('" & _URL.Replace("/runEORandPosting.aspx", "/LGU_OPL.aspx") & "'); }, 1000); ", True)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub



    'LBP1 FIELD
    Private Sub LBP1Field()
        If Not String.IsNullOrEmpty(Session("runEORandPostingPaymentRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingGatewayRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingPaymentGateway")) Then
            If Session("runEORandPostingPaymentGateway") = "LBP1" Then
                _PaymentReferenceLBP1.Value = Session("runEORandPostingPaymentRefNo")
                _GatewayReferenceLBP1.Value = Session("runEORandPostingGatewayRefNo")
            Else
                'Do Nothing
            End If

        Else
            _PaymentReferenceLBP1.Value = ""
            _GatewayReferenceLBP1.Value = ""
        End If
    End Sub

    'RUN THE EOR AND POSTING AND OTHER LBP1
    Sub runEORAndPostingLBP1(GatewaySTatus As String, SPIDCREFNO As String, gatewayRefNo As String)
        Try
            Dim isTaxpayer As Boolean = True
            Dim err As String = Nothing
            Dim eORNO As String = Nothing
            Dim _nclass As New cDalPayment
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nclassGetModules As New cDalGetModules
            Dim _nclassEOR As New eOR_Jaka
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            Dim _nClassPost As New Process

            If _nclassEOR.isEOR_Exists(SPIDCREFNO) = False Then
                Process.ACCTNO = _nclassEOR.getACCTNO(SPIDCREFNO)
                '-----New Addedd 11-03-2023 JAY SITJAR-----
                cSessionLoader._pTDN = _nclassEOR.getTDN1(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist1(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent1(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN2(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist2(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent2(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN3(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist3(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent3(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If


                End If
                '-----End Addedd 11-03-2023 JAY SITJAR-----



                Process.Gateway_Selected = "LBP1"
                Process.GatewayRefNo = gatewayRefNo
                eOR.Gateway_RefNo = gatewayRefNo
                eOR.TaxPayerEmail = _nclassEOR.getEMAIL(SPIDCREFNO)
                Process.TransactionType = _nclassEOR.getTransactionType(SPIDCREFNO)
                eOR.SPIDC_RefNo = SPIDCREFNO
                _nClassPost.START_POSTING(err, eORNO, isTaxpayer, gatewayRefNo)
                _GenerateReport_eORLBP1(1, Process.TransactionType, eORNO)
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
    'LBP1
    Public Sub _GenerateReport_eORLBP1(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String)
        Try
            Dim _nclassEOR As New eOR

            Dim _nDataTable0 As New DataTable
            _nDataTable0 = _nclassEOR.Print_Template

            Dim _nDataTable1 As New DataTable
            _nDataTable1 = _nclassEOR.Print_Report(eORNO)

            Dim _nDataTable2 As New DataTable
            _nDataTable2 = _nclassEOR.Print_TOP(eORNO)



            Report_EOR.Reset()
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


            Dim ds_TotalAmount As String = Nothing
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
                '11/06/2023 JAY SITJAR
                'Set TO Nothning runeor session
                Session("runEORandPostingGatewayRefNo") = Nothing
                Session("runEORandPostingPaymentRefNo") = Nothing
                Session("runEORandPostingPaymentGateway") = Nothing
                'End JAY SITJAR
                If String.IsNullOrEmpty(err) = True Then
                    eOR.Update_Sent(_nDataTable1.Rows(0)("eORNO"), err)
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", " loader.hide(); window.alert('E-OR Sent Successfully'); setTimeout(function() { window.location.replace('" & _URL.Replace("/runEORandPosting.aspx", "/LGU_OPL.aspx") & "'); }, 1000); ", True)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub





    'LBP2 FIELD
    Private Sub LBP2Field()
        If Not String.IsNullOrEmpty(Session("runEORandPostingPaymentRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingGatewayRefNo")) And Not String.IsNullOrEmpty(Session("runEORandPostingPaymentGateway")) Then
            If Session("runEORandPostingPaymentGateway") = "LBP2" Then
                _PaymentReferenceLBP2.Value = Session("runEORandPostingPaymentRefNo")
                _GatewayReferenceLBP2.Value = Session("runEORandPostingGatewayRefNo")
            Else
                'Do Nothing
            End If

        Else
            _PaymentReferenceLBP2.Value = ""
            _GatewayReferenceLBP2.Value = ""
        End If
    End Sub

    'RUN THE EOR AND POSTING AND OTHER LBP2
    Sub runEORAndPostingLBP2(GatewaySTatus As String, SPIDCREFNO As String, gatewayRefNo As String)
        Try
            Dim isTaxpayer As Boolean = True
            Dim err As String = Nothing
            Dim eORNO As String = Nothing
            Dim _nclass As New cDalPayment
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nclassGetModules As New cDalGetModules
            Dim _nclassEOR As New eOR_Jaka
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            Dim _nClassPost As New Process

            If _nclassEOR.isEOR_Exists(SPIDCREFNO) = False Then
                Process.ACCTNO = _nclassEOR.getACCTNO(SPIDCREFNO)
                '-----New Addedd 11-03-2023 JAY SITJAR-----
                cSessionLoader._pTDN = _nclassEOR.getTDN1(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist1(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent1(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN2(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist2(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent2(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If
                End If

                cSessionLoader._pTDN = _nclassEOR.getTDN3(Process.ACCTNO)
                If cSessionLoader._pTDN Is Nothing Or cSessionLoader._pTDN = "" Then
                    cSessionLoader._pTDN = _nclassEOR.getTDNHist3(Process.ACCTNO)
                    If Not (cSessionLoader._pTDN Is Nothing) Then
                        'Move RPT AssessmentFrom History To Current
                        _nclassEOR.moveRPTAssessmentFromHistToCurrent3(Process.ACCTNO)
                    Else
                        'Do Nothing
                    End If


                End If
                '-----End Addedd 11-03-2023 JAY SITJAR-----



                Process.Gateway_Selected = "LBP2"
                Process.GatewayRefNo = gatewayRefNo
                eOR.Gateway_RefNo = gatewayRefNo
                eOR.TaxPayerEmail = _nclassEOR.getEMAIL(SPIDCREFNO)
                Process.TransactionType = _nclassEOR.getTransactionType(SPIDCREFNO)
                eOR.SPIDC_RefNo = SPIDCREFNO
                _nClassPost.START_POSTING(err, eORNO, isTaxpayer, gatewayRefNo)
                _GenerateReport_eORLBP2(1, Process.TransactionType, eORNO)
            Else
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
    'LBP2
    Public Sub _GenerateReport_eORLBP2(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String)
        Try
            Dim _nclassEOR As New eOR

            Dim _nDataTable0 As New DataTable
            _nDataTable0 = _nclassEOR.Print_Template

            Dim _nDataTable1 As New DataTable
            _nDataTable1 = _nclassEOR.Print_Report(eORNO)

            Dim _nDataTable2 As New DataTable
            _nDataTable2 = _nclassEOR.Print_TOP(eORNO)



            Report_EOR.Reset()
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


            Dim ds_TotalAmount As String = Nothing
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
                '11/06/2023 JAY SITJAR
                'Set TO Nothning runeor session
                Session("runEORandPostingGatewayRefNo") = Nothing
                Session("runEORandPostingPaymentRefNo") = Nothing
                Session("runEORandPostingPaymentGateway") = Nothing
                'End JAY SITJAR
                If String.IsNullOrEmpty(err) = True Then
                    eOR.Update_Sent(_nDataTable1.Rows(0)("eORNO"), err)
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", " loader.hide(); window.alert('E-OR Sent Successfully'); setTimeout(function() { window.location.replace('" & _URL.Replace("/runEORandPosting.aspx", "/LGU_OPL.aspx") & "'); }, 1000); ", True)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub


    'Check EOR Is Active
    Private Function _checkEORMOduleIsActive() As Boolean
        Dim _nclassGetModules As New cDalGetModules
        _nclassGetModules._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        If _nclassGetModules._pSubGetAvailableModules("EOR") = True Then
            Return True
        Else
            Return False
        End If
    End Function





End Class