Imports System.Reflection
Imports Microsoft.Reporting.WebForms
Imports SPIDC.Resources

Public Class PaymentConfirmation_LBP1
    Inherits System.Web.UI.Page
    Public Property MerchantCode As String
    Public Property MerchantRefNo As String
    Public Property Particulars As String
    Public Property Amount As String
    Public Property PayorName As String
    Public Property PayorEmail As String
    Public Property Status As String
    Public Property EppRefNo As String
    Public Property PaymentOption As String
    Dim err As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Try
                MerchantRefNo = Request.Form("MerchantRefNo")
                Status = Request.Form("Status")
                MerchantCode = Request.Form("MerchantCode")
                Particulars = Request.Form("Particulars")
                Amount = Request.Form("Amount")
                PayorName = Request.Form("PayorName")
                PayorEmail = Request.Form("PayorEmail")
                EppRefNo = Request.Form("EppRefNo")
                PaymentOption = Request.Form("PaymentOption")
                div_Result.InnerHtml += "<br>1 - OK"
            Catch ex As Exception
                div_Result.InnerHtml += "<br>1 - " + ex.Message
                Exit Sub
            End Try
            '---------------------------
            Dim _nclassGetDate As New cDalGetDate
            Dim _nClass As New cDalPayment
            Dim ACCTNO As String = Nothing
            Dim StatusID As String = Nothing

            Try
                _nclassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                div_Result.InnerHtml += "_nclassGetDate._pSqlConnection - OK"
            Catch ex As Exception
                div_Result.InnerHtml += "_nclassGetDate._pSqlConnection - " + ex.Message
                Exit Sub
            End Try
            Try
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                div_Result.InnerHtml += "_nClass._pSqlConnection - OK"
            Catch ex As Exception
                div_Result.InnerHtml += "_nClass._pSqlConnection - " + ex.Message
                Exit Sub
            End Try

            Try
                _nClass._pSubGetACCTNO(MerchantRefNo, ACCTNO)
                div_Result.InnerHtml += "_pSubGetACCTNO - OK"
            Catch ex As Exception
                div_Result.InnerHtml += "_pSubGetACCTNO - " + ex.Message
                Exit Sub
            End Try


            div_Result.InnerHtml += "<br>2"
            Dim sb = New System.Text.StringBuilder()
            sb.Append("<html>")
            sb.AppendFormat("<body onload='document.forms[0].submit()'>")
            '  sb.AppendFormat("<body >")
            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
            If _nClass.isEPPExists(MerchantRefNo, Particulars) = True Then
                Dim Sent As Boolean = False
                Dim Body As String = Nothing

                sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", MerchantRefNo)


                If Status = "00" Then
                    StatusID = "SUCCESS"
                    Dim isTaxpayer As Boolean = True
                    Dim err As String = Nothing
                    Dim eORNO As String = Nothing
                    Dim _nclasscDalPayment As New cDalPayment
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    Dim _nclassGetModules As New cDalGetModules
                    Dim _nclassEOR As New eOR
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                    Dim _nClassPost As New Process

                    If _nclassGetModules._pSubGetAvailableModules("EOR") = True Then

                        If cInit_eOR.Initialize_EOR(MerchantRefNo, Report_EOR, "LBP1", Process.GatewayRefNo) = True Then GoTo jumphere

                        If _nclassEOR.isEOR_Exists(MerchantRefNo) = False Then
                            Process.ACCTNO = _nclassEOR.getACCTNO(MerchantRefNo)
                            cSessionLoader._pTDN = _nclassEOR.getTDN(_nClass.Get_PaymentDetails("ACCTNO", "TXNREFNO", MerchantRefNo))
                            Process.Gateway_Selected = "LBP1"
                            Process.GatewayRefNo = EppRefNo
                            eOR.Gateway_RefNo = EppRefNo
                            eOR.TaxPayerEmail = _nclassEOR.getEMAIL(MerchantRefNo)
                            Process.TransactionType = _nclassEOR.getTransactionType(MerchantRefNo)
                            eOR.SPIDC_RefNo = MerchantRefNo
                            _nClassPost.START_POSTING(err, eORNO, isTaxpayer, EppRefNo)
                            _GenerateReport_eOR(1, Process.TransactionType, eORNO)

                   
                        End If
jumphere:
                     
                    Else
                        Body = "Dear Valued Tax Payer, <br> " & _
                               "This confirms your bill payment transaction with the following details: <br> " & _
                               "Transaction Number: " & MerchantRefNo & "<br>" & _
                               "Transaction Type: " & _nClass.Get_PaymentDetails("TYPE", "TXNREFNO", MerchantRefNo) & " Payment<br>" & _
                               "Account No. : " & ACCTNO & "<br>" & _
                               "Amount Paid : " & Amount & "<br> <br>"
                        cDalNewSendEmail.SendEmail(_nClass.Get_PaymentDetails("EMAILADDR", "TXNREFNO", MerchantRefNo), "Online Payment Confirmation", Body, Sent)
                    End If
                    'sb.AppendFormat("<input type='hidden' name='Particulars' value='{0}'>", Particulars)
                    'sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", Amount)
                    'sb.AppendFormat("<input type='hidden' name='EppRefNo' value='{0}'>", EppRefNo)
                    'sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='LBP1'>")
                    'sb.AppendFormat("<input type='hidden' name='PaymentOption' value='{0}'>", PaymentOption)              

                    For Each key As String In Request.Form.Keys
                        If Request.Form(key) <> Nothing Then
                            sb.AppendFormat("<input type='hidden' name='" & key & "' value='{0}'>", Request.Form(key))
                        End If
                    Next
                    sb.AppendFormat("<input type='hidden' name='OriginURL' value='{0}'>", _nClass.get_OriginURL(MerchantRefNo))



                Else
                    StatusID = "FAILED"
                    For Each key As String In Request.Form.Keys
                        If Request.Form(key) <> Nothing Then
                            sb.AppendFormat("<input type='hidden' name='" & key & "' value='{0}'>", Request.Form(key))
                        End If
                    Next
                End If


                Try
                    _nClass._pSubUpdateOnlinePaymentInfo(MerchantRefNo _
                  , get_statusDesc(Status) _
                  , EppRefNo _
                  , Particulars _
                  , _nclassGetDate._GetDate_MMddyyyy() _
                  , _nClass.Get_PaymentDetails("rawAmount", "TXNREFNO", MerchantRefNo) _
                  , _nClass.Get_PaymentDetails("FeeAmount", "TXNREFNO", MerchantRefNo) _
                  , _nClass.Get_PaymentDetails("TotAmount", "TXNREFNO", MerchantRefNo) _
                  , StatusID _
                  , "LBP1")
                    div_Result.InnerHtml += "_pSubUpdateOnlinePaymentInfo - OK"


                Catch ex As Exception
                    div_Result.InnerHtml += "_pSubUpdateOnlinePaymentInfo - " + ex.Message
                    Exit Sub
                End Try


                Try
                    MerchantCode = IIf(String.IsNullOrEmpty(MerchantCode), _nClass.Get_Details("LBP_LOGS", "MerchantCode", "MerchantRefNo", MerchantRefNo), MerchantCode)
                    Particulars = IIf(String.IsNullOrEmpty(Particulars), _nClass.Get_Details("LBP_LOGS", "Particulars", "MerchantRefNo", MerchantRefNo), Particulars)
                    PayorName = IIf(String.IsNullOrEmpty(PayorName), _nClass.Get_Details("LBP_LOGS", "PayorName", "MerchantRefNo", MerchantRefNo), PayorName)
                    PayorEmail = IIf(String.IsNullOrEmpty(PayorEmail), _nClass.Get_Details("LBP_LOGS", "PayorEmail", "MerchantRefNo", MerchantRefNo), PayorEmail)
                    Amount = IIf(String.IsNullOrEmpty(Amount), _nClass.Get_Details("OnlinePaymentRefNo", "TotAmount", "TXNREFNO", MerchantRefNo), Amount)

                    _nClass._pSubInsertLBPLogs(MerchantCode,
                                          MerchantRefNo,
                                          Particulars,
                                          Amount,
                                          PayorName,
                                          PayorEmail,
                                          Status,
                                          EppRefNo,
                                          PaymentOption,
                                          _nclassGetDate._GetDate_MMddyyyy(),
                                          get_statusDesc(Status))
                    div_Result.InnerHtml += "_pSubInsertLBPLogs - OK"
                Catch ex As Exception
                    div_Result.InnerHtml += "_pSubInsertLBPLogs - " + ex.Message
                    Exit Sub
                End Try




                Dim type As String
                If MerchantRefNo.Contains("BP") Then type = "BP"
                If MerchantRefNo.Contains("RPT") Then type = "RPT"
                If MerchantRefNo.Contains("OBO") Then type = "OBO"
                If MerchantRefNo.Contains("CTC") Then type = "CTC"
                If MerchantRefNo.Contains("LCR") Then type = "LCR"

                '= String.Concat(MerchantRefNo.Where(AddressOf Char.IsLetter))
                Try
                    _nClass.Insert_History(MerchantRefNo, type, "LBP1", ACCTNO, Amount, Amount, 0, get_statusDesc(Status), , PayorEmail)
                    div_Result.InnerHtml += "Insert_History - OK"
                Catch ex As Exception
                    div_Result.InnerHtml += "Insert_History - " + ex.Message
                    Exit Sub
                End Try


                Try
                    sb.AppendFormat("<input type='hidden' name='OriginURL' value='{0}'>", _nClass.get_OriginURL(MerchantRefNo))
                    div_Result.InnerHtml += "get_OriginURL - OK"
                Catch ex As Exception
                    div_Result.InnerHtml += "get_OriginURL - " + ex.Message
                    Exit Sub
                End Try


            Else
                For Each key As String In Request.Form.Keys
                    If Request.Form(key) <> Nothing Then
                        sb.AppendFormat("<input type='hidden' name='" & key & "' value='{0}'>", Request.Form(key))
                    End If
                Next
                sb.AppendFormat("<input type='hidden' name='MESSAGE' value='{0}'>", "INVALID TRANSACTION")
                sb.AppendFormat("<input type='hidden' name='OriginURL' value='{0}'>", "WebPortal/Account.aspx")
            End If
            sb.Append("</form>")
            sb.Append("</body>")
            sb.Append("</html>")
            Response.Write(sb.ToString())
            Response.[End]()

        Catch ex As Exception
            div_Result.InnerHtml += ";" + ex.Message
            Exit Sub
        End Try



        'Try
        '    Dim ACCTNO As String = Nothing
        '    Dim StatusID As String = Nothing
        '    MerchantCode = Request.Form("MerchantCode")
        '    MerchantRefNo = Request.Form("MerchantRefNo")
        '    Particulars = Request.Form("Particulars")
        '    Amount = Request.Form("Amount")
        '    PayorName = Request.Form("PayorName")
        '    PayorEmail = Request.Form("PayorEmail")
        '    Status = Request.Form("Status")
        '    EppRefNo = Request.Form("EppRefNo")
        '    PaymentOption = Request.Form("PaymentOption")
        '    get_statusDesc(Status)


        '    Response.Clear()
        '    Response.Write("Checking status, please wait...")
        '    Dim sb = New System.Text.StringBuilder()
        '    sb.Append("<html>")
        '    sb.AppendFormat("<body onload='document.forms[0].submit()'>")

        '        sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")



        '    Dim _nClass As New cDalPayment
        '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '    If _nClass.isEPPExists(MerchantRefNo, Particulars) = False Then
        '        sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", "INVALID TRANSACTION")
        '        For Each key As String In Request.Form.Keys
        '            If Request.Form(key) <> Nothing Then
        '                sb.AppendFormat("<input type='hidden' name='" & key & "' value='{0}'>", Request.Form(key))
        '            End If
        '        Next
        '    Else
        '        Dim _nclassGetDate As cDalGetDate
        '        _nclassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

        '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        '        _nClass._pSubGetACCTNO(MerchantRefNo, ACCTNO)

        '        Dim Sent As Boolean = False
        '        Dim Body As String = Nothing
        '        If Status = "00" Then
        '            StatusID = "SUCCESS"
        '            '0000  = Transaction Completed Successfully    
        '            Body = "Dear Valued Tax Payer, <br> " & _
        '                   "This confirms your bill payment transaction with the following details: <br> " & _
        '                   "Transaction Number: " & MerchantRefNo & "<br>" & _
        '                   "Transaction Type: " & _nClass.Get_PaymentDetails("TYPE", "TXNREFNO", MerchantRefNo) & " Payment<br>" & _
        '                   "Account No. : " & ACCTNO & "<br>" & _
        '                   "Amount Paid : " & Amount & "<br> <br>"
        '            cDalNewSendEmail.SendEmail(_nClass.Get_PaymentDetails("EMAILADDR", "TXNREFNO", MerchantRefNo), "Online Payment Confirmation", Body, Sent)
        '        Else
        '            StatusID = "FAILED"
        '        End If

        '        _nClass._pSubInsertLBPLogs(MerchantCode,
        '                                   MerchantRefNo,
        '                                   Particulars,
        '                                   Amount,
        '                                   PayorName,
        '                                   PayorEmail,
        '                                   Status,
        '                                   EppRefNo,
        '                                   PaymentOption,
        '                                   _nclassGetDate._GetDate(""),
        '                                   get_statusDesc(Status))

        '        _nClass._pSubUpdateOnlinePaymentInfo(MerchantRefNo _
        '            , get_statusDesc(Status) _
        '            , EppRefNo _
        '            , Particulars _
        '            , _nclassGetDate._GetDate("") _
        '            , Amount _
        '            , _nClass.Get_PaymentDetails("FeeAmt", "TXNREFNO", MerchantRefNo) _
        '            , Amount _
        '            , StatusID _
        '            , "LBP1")
        '        Dim type As String = String.Concat(MerchantRefNo.Where(AddressOf Char.IsLetter))
        '        _nClass.Insert_History(MerchantRefNo, type, "LBP1", ACCTNO, Amount, 0, get_statusDesc(Status))

        '        sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", MerchantRefNo)
        '        sb.AppendFormat("<input type='hidden' name='Particulars' value='{0}'>", Particulars)
        '        sb.AppendFormat("<input type='hidden' name='Amount' value='{0}'>", Amount)
        '        sb.AppendFormat("<input type='hidden' name='EppRefNo' value='{0}'>", EppRefNo)
        '        sb.AppendFormat("<input type='hidden' name='GateWayUsed' value='LBP1'>")
        '        sb.AppendFormat("<input type='hidden' name='PaymentOption' value='{0}'>", PaymentOption)
        '        sb.AppendFormat("<input type='hidden' name='OriginURL' value='{0}'>", _nClass.get_OriginURL(MerchantRefNo))

        '    End If
        '    sb.Append("</form>")
        '    sb.Append("</body>")
        '    sb.Append("</html>")
        '    Response.Write(sb.ToString())
        '    Response.[End]()


        'Catch ex As Exception
        '    err += ex.Message
        'End Try
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
    Function get_statusDesc(ByVal StatusCOde As String) As String
        Dim desc As String = Nothing
        Select Case StatusCOde
            Case "00"
                desc = "Successful"
            Case "01"
                desc = "Invalid merchant code"
            Case "02"
                desc = "Invalid merchant reference number"
            Case "03"
                desc = "0 or negative amount"
            Case "04"
                desc = "Null payors name"
            Case "05"
                desc = "Null returnURLok"
            Case "06"
                desc = "Null returnURLerror"
            Case "07"
                desc = "Invalid hash"
            Case "08"
                desc = "Service unavailable"
            Case "09"
                desc = "Transaction in process"
            Case "10"
                desc = "Cancelled transaction"
            Case "11"
                desc = "EPP offline"
            Case "12"
                desc = "Invalid transaction type"
            Case "13"
                desc = "Invalid particulars"
            Case "14"
                desc = "Duplicate transaction"
            Case "15"
                desc = "Third Party Gateway Transaction Failed"
            Case "16"
                desc = "Invalid Credit Amount"
        End Select
        Return desc
    End Function
End Class