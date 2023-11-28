Imports Microsoft.Reporting.WebForms
Imports System.Reflection
Imports SPIDC.Resources

Public Class PaymentConfirmation_LBP2
    Inherits System.Web.UI.Page
    Public Property Checksum As String
    Public Property ErrorCode As String
    Public Property LBPConfDate As String
    Public Property LBPConfNum As String
    Public Property LBPRefNum As String
    Public Property MerchantRefNum As String
    Public Property TrxnAmount As String
    Public Property OriginURL As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim statusID As String = Nothing
            Dim ACCTNO As String = Nothing
            Checksum = Request.QueryString("Checksum")
            ErrorCode = Request.QueryString("ErrorCode")
            LBPConfDate = Request.QueryString("LBPConfDate")
            LBPConfNum = Request.QueryString("LBPConfNum")
            LBPRefNum = Request.QueryString("LBPRefNum")
            MerchantRefNum = Request.QueryString("MerchantRefNum")
            TrxnAmount = Request.QueryString("TrxnAmount")



            Response.Clear()
            Response.Write("Checking status, please wait...")
            Dim sb = New System.Text.StringBuilder()
            sb.Append("<html>")
            sb.AppendFormat("<body onload='document.forms[0].submit()'>")
            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            If _nClass.isCheckSumExists(Checksum, MerchantRefNum) = False Then
                sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", "INVALID TRANSACTION")
            Else
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubGetACCTNO(MerchantRefNum, ACCTNO)

                Dim Sent As Boolean = False
                Dim Body As String = Nothing
                If _ErrorCode = "0000" Then

                    statusID = "SUCCESS"

                    Dim isTaxpayer As Boolean = True
                    Dim err As String = Nothing
                    Dim eORNO As String = Nothing

                    Dim _nclassGetModules As New cDalGetModules
                    Dim _nclassEOR As New eOR
                    Dim _nClassPost As New Process

                    If _nclassGetModules._pSubGetAvailableModules("EOR") = True Then ' Check If EOR is Enabled

                        If cInit_eOR.Initialize_EOR(MerchantRefNum, Report_EOR, "LBP2", Process.GatewayRefNo) = True Then GoTo jumphere


                        If _nclassEOR.isEOR_Exists(MerchantRefNum) = False Then
                            Process.ACCTNO = _nclassEOR.getACCTNO(MerchantRefNum)
                            cSessionLoader._pTDN = _nclassEOR.getTDN(_nClass.Get_PaymentDetails("ACCTNO", "TXNREFNO", MerchantRefNum))
                            Process.Gateway_Selected = "LBP2"
                            Process.GatewayRefNo = LBPRefNum
                            eOR.Gateway_RefNo = LBPRefNum
                            eOR.TaxPayerEmail = _nclassEOR.getEMAIL(MerchantRefNum)
                            Process.TransactionType = _nclassEOR.getTransactionType(MerchantRefNum)
                            eOR.SPIDC_RefNo = MerchantRefNum
                            _nClassPost.START_POSTING(err, eORNO, isTaxpayer, LBPRefNum) ' 'Perform Auto Posting
                            _GenerateReport_eOR(1, Process.TransactionType, eORNO)  'Generate and Send Email with EOR Attachment

jumphere:
                        End If


                    Else

                        '0000  = Transaction Completed Successfully    
                        Body = "Dear Valued Tax Payer, <br> " & _
                               "This confirms your bill payment transaction with the following details: <br> " & _
                               "Transaction Number: " & MerchantRefNum & "<br>" & _
                               "Transaction Type: " & _nClass.Get_PaymentDetails("TYPE", "TXNREFNO", MerchantRefNum) & " Payment<br>" & _
                               "Account No. : " & ACCTNO & "<br>" & _
                               "Amount Paid : " & TrxnAmount & "<br> <br>"

                        cDalNewSendEmail.SendEmail(_nClass.Get_PaymentDetails("EMAILADDR", "TXNREFNO", MerchantRefNum), "Online Payment Confirmation", Body, Sent)

                    End If

                Else
                    statusID = "FAILED"
                End If

                _nClass._pSubUpdateOnlinePaymentInfo(_MerchantRefNum _
                , _nClass.Get_EPS_ERRCODES(_ErrorCode) _
                , LBPRefNum _
                , Checksum _
                , LBPConfDate _
                , _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", _MerchantRefNum) _
                , _nClass.Get_PaymentDetails("FeeAmount", "TXNREFNO", MerchantRefNum) _
                , _nClass.Get_PaymentDetails("totAmount", "TXNREFNO", _MerchantRefNum) _
                , statusID _
                , "LBP2")

                Dim type As String = String.Concat(MerchantRefNum.Where(AddressOf Char.IsLetter))
                _nClass.Insert_History(MerchantRefNum, type, "LBP2", ACCTNO, TrxnAmount, TrxnAmount, 0, _nClass.Get_EPS_ERRCODES(_ErrorCode), LBPRefNum, eOR.TaxPayerEmail)

                sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", MerchantRefNum)
                sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", TrxnAmount)
                sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", _nClass.Get_EPS_ERRCODES(_ErrorCode))
                sb.AppendFormat("<input type='hidden' name='LBPRefNum' value='{0}'>", LBPRefNum)
                sb.AppendFormat("<input type='hidden' name='Date' value='{0}'>", LBPConfDate)
                sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='LBP2'>")
                sb.AppendFormat("<input type='hidden' name='OriginURL' value='{0}'>", _nClass.get_OriginURL(MerchantRefNum))
            End If

            sb.Append("</form>")
            sb.Append("</body>")
            sb.Append("</html>")
            Response.Write(sb.ToString())
            Response.[End]()



        Catch ex As Exception

        End Try
    End Sub


    Public Sub _GenerateReport_eOR(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String)
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

                    ' ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                    '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');window.location.replace('../Account.aspx');", True)
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
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub
    Sub do_test()
        Response.Write("<h1>THIS IS A TEST PAGE</h1>")
        Response.Write("<table>")
        For Each key As String In Request.Form.Keys
            If Request.Form(key) <> Nothing Then
                Response.Write("<tr>")
                Response.Write("<td>")
                Response.Write("<label class='m-0 font-weight-bold text-primary'>" & key & "</label>")
                Response.Write("</td>")

                Response.Write("<td>")
                Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form(key) & "</label>")
                Response.Write("</td>")
                Response.Write("</tr>")
            End If
        Next
        Response.Write("</table>")
        '---------------------------
    End Sub

End Class