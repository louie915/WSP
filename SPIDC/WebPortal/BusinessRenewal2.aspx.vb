Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class BusinessRenewal2
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim Err As String = Nothing
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubCheckIfAssetExists()
            _nClass._pSubCheckIfWEBASSESSNOExists()


            If _nClass._pSubCheckIfTableExist("BP_Attachment") = False Then
                _nClass._pSubCreateTable("BP_Attachment")
            End If

            Dim _nclass2 As New cDalGetModules
            _nclass2._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclass2._pSubGetAvailableModules("BP_AssetEntry") = False Then
                _GVBusinessLine.Columns(6).HeaderText = ""
                _GVBusinessLine.Columns(7).HeaderText = ""
                _GVBusinessLine.Columns(8).HeaderText = ""
                ClientScript.RegisterStartupScript(Me.[GetType](), "hideasset", "hasset();", True)

            End If

            Load_Details(cSessionLoader._pAccountNo, Err)
            Load_Busline(cSessionLoader._pAccountNo, Err)
            Load_Requirements("RENEW")


         

          

            Dim _nclassX As New cDalGetModules
            _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclassX._pSubGetAvailableModules("BPLO_BPAssessment") = True Then
               
                If _nClass.check_ApproveOnlineTOP() = 1 Then
                    loadGrid_TOP(cSessionLoader._pAccountNo)
                    div_TOP.Style.Add("display", "block")
                    div_AssessNoticeBPLO.Style.Add("display", "none")

                Else
                    div_AssessNoticeBPLO.Style.Add("display", "block")
                    div_TOP.Style.Add("display", "none")
                End If
                div_AssessNoticeTreasury.Style.Add("display", "none")

            ElseIf _nclassX._pSubGetAvailableModules("Treasury_BPAssessment") = True Then
                If _nClass._nOutput = 1 Then
                    div_TOP.Style.Add("display", "none")
                    div_AssessNoticeBPLO.Style.Add("display", "none")
                    div_AssessNoticeTreasury.Style.Add("display", "none")
                Else
                    div_AssessNoticeBPLO.Style.Add("display", "none")
                    div_AssessNoticeTreasury.Style.Add("display", "block")
                    div_TOP.Style.Add("display", "none")
                End If
            Else
                div_AssessNoticeBPLO.Style.Add("display", "block")
                div_AssessNoticeTreasury.Style.Add("display", "none")
                loadGrid_TOP(cSessionLoader._pAccountNo)
                div_TOP.Style.Add("display", "block")
            End If


          


        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadGrid_TOP(ByVal acctno As String)
        Try
            Dim Sum_TotAmtDue As Double
            Dim Sum_TotPenDue As Double
            Dim Sum_TotTaxDue As Double
            Dim Sum_TotETC As Double
            Dim CTC_AMOUNT As Double
            Dim CTC_REMARK As String
            Dim _GrandTotal As Double
            Dim _nClass2 As New cDalNewBP

            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass2._pSubSelectTOP(acctno, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, 0)
            GridViewTOP.DataSource = _nClass2._mDataTable
            GridViewTOP.DataBind()

            _nClass2._pSubGetCTC(acctno, CTC_AMOUNT, CTC_REMARK)
            Dim _nclassX As New cDalGetModules
            _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclassX._pSubGetAvailableModules("IncludeCTC") <> True Then
                CTC_AMOUNT = 0
                trCTC.Style.Add("display", "none")
            End If

            lblCTCAmount.InnerText = String.Format("{0:C}", CTC_AMOUNT).Replace("$", "")
            TotAmtDue.InnerText = String.Format("{0:C}", Sum_TotAmtDue).Replace("$", "")
            _GrandTotal = CTC_AMOUNT + Sum_TotAmtDue
            GrandTotal.InnerText = String.Format("{0:C}", _GrandTotal).Replace("$", "")

            cSessionLoader._pTotalAmountDue = Format(_GrandTotal.ToString, "STANDARD")

            GridViewTOP.FooterRow.Cells(0).ColumnSpan = 3
            GridViewTOP.FooterRow.Cells(0).Font.Bold = True
            GridViewTOP.FooterRow.Cells(0).Text = "T O T A L    D U E :"
            GridViewTOP.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Center

            GridViewTOP.FooterRow.Cells(1).Font.Bold = True
            GridViewTOP.FooterRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(1).Text = Sum_TotTaxDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(2).Font.Bold = True
            GridViewTOP.FooterRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(2).Text = Sum_TotPenDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(3).Font.Bold = True
            GridViewTOP.FooterRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(3).Text = Sum_TotAmtDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(5).Font.Bold = True
            GridViewTOP.FooterRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(5).Text = Sum_TotETC.ToString("N2")

            GridViewTOP.FooterRow.Cells(6).Visible = False
            GridViewTOP.FooterRow.Cells(7).Visible = False
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_Busline(ByVal Acctno As String, ByRef Err As String)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubGetBusLine_GrossAssetEntry(Acctno)
            _GVBusinessLine.DataSource = _nClass._mDataTable
            _GVBusinessLine.DataBind()

        Catch ex As Exception
            Err = ex.Message
        End Try

    End Sub

    Sub Load_Details(ByVal Acctno As String, ByRef Err As String)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelect_Details(Acctno, _oLblBusOwner.Text, _oLblBusName.Text, _oLblBusAddress.Text, _oLblBusOwnership.Text, lblMOP.Text)
            _oLblBusID.Text = Acctno.ToUpper

        Catch ex As Exception

        End Try
    End Sub

    Sub Load_Requirements(ByVal switch As String)
        Try
            Dim reqCount As Integer
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubGetAttachmentsSubmitted(cSessionLoader._pAccountNo, reqCount)
            If reqCount = 0 Then
                div_Requirements.style.add("display", "none")
            Else
                div_Requirements.style.add("display", "")
                _GVRequirements.DataSource = _nClass._mDataTable
                _GVRequirements.DataBind()
            End If
           
        Catch ex As Exception

        End Try
    End Sub

    

    

    Sub snackbar(Color As String, Caption As String)
        If Color.ToUpper = "RED" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color.ToUpper = "GREEN" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Private Sub btnDecline_ServerClick(sender As Object, e As EventArgs) Handles btnDecline.ServerClick
        Try
            Dim _nClass As New cDalBPSOS
            Dim err As String = Nothing
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            If _nClass.DeclineApplication(cSessionLoader._pAccountNo, _oTextRemarks.Value, err) Then
                'send email to taxpayer for declined renewal application
                ' snackbar()
                Response.Redirect("BusinessRenewalTaxPayer2.aspx", False)
            Else
                'something went wrong while updating renewal status
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_TOP_ServerClick(sender As Object, e As EventArgs) Handles btn_TOP.ServerClick
        Dim _nClass As New cDalBPSOS
        Dim _nTPEmail As String
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubTPEmail()
        _nTPEmail = _nClass._nOutput

        ReportViewer.NEWBP_TOP_ACCTNO = cSessionLoader._pAccountNo
        ReportViewer.NEWBP_TOP_Email = _nTPEmail
        Response.Redirect("Report/ReportViewer.aspx?ReportType=BP_TOP_2023")
    End Sub

    Private Sub btnApprove_ServerClick(sender As Object, e As EventArgs) Handles btnApprove.ServerClick
        _mSubApprovePayment()
    End Sub

    Sub _mSubApprovePayment()
        Try
            Dim _nTPEmail As String
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass.ApproveForPayment(cSessionLoader._pAccountNo)
            _nClass.GenerateWebAssessNo(cSessionLoader._pAccountNo)
            _nClass._pSubTPEmail()
            _nTPEmail = _nClass._nOutput

            Dim Sent As Boolean
            Dim Subject As String
            Dim Body As String

            Subject = "Account Ready for Payment"

            Body = "Dear Valued Tax Payer, <br>" & _
                    "Your Business Renewal Application for Account : " & cSessionLoader._pAccountNo & " is now ready for payment. <br>" & _
                    "Please always check your email. <br><br>" & _
                    "Thank you for choosing online transaction. Have a wonderful day!<br>"
            cDalNewSendEmail.SendEmail(_nTPEmail, Subject, Body, Sent)
            If Sent = True Then
                snackbar("green", "Email notification has been sent to tax payer")
            Else
                snackbar("red", "Failed to send email notification to tax payer")
            End If

            btnApprove.Disabled = True
            '   _obtnSaveEdit.Disabled = True
        Catch ex As Exception

        End Try
    End Sub
     
    Private Sub btnApproveApplication_ServerClick(sender As Object, e As EventArgs) Handles btnApproveApplication.ServerClick
        ' SEND EMAIL to TAXPAYER
        Dim _nTPEmail As String
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubTPEmail()
        _nTPEmail = _nClass._nOutput
        _nClass._pSubApproveForTreasury(cSessionLoader._pAccountNo)
        Dim Sent As Boolean
        Dim Subject As String
        Dim Body As String

        Subject = "Business Renewal Application - For Billing Assessment"
        Body = "Dear Valued Tax Payer, <br>" & _
                "Your Business Renewal Application for Account : " & cSessionLoader._pAccountNo & " is now sent to Treasury Office for Billing Assessment. <br>" & _
                "You will be notified when the office is done with assessment. Please always check your email. <br><br>" & _
                "Thank you.<br>"
        cDalNewSendEmail.SendEmail(_nTPEmail, Subject, Body, Sent)

        If Sent = True Then
            snackbar("green", "Taxpayer has been Notified")
        Else
            snackbar("green", "Failed to send Notification-Taxpayer")
        End If


        '------------------------------
        ' SEND EMAIL to ALL TREASURY
        Dim Emails As String
        cDalNewSendEmail.get_Emails("TREASURY", Emails)
        Subject = "For Billing Assessment"
        Body = "Taxpayer's Application for Business Renewal Application has been approved by BPLO with the following details: <br>" & _
                "Account No. : " & cSessionLoader._pAccountNo & "<br>" & _
                "You may Login to Web Portal using [Treasury Account] to view more details regarding the Application. <br><br>" & _
                "Thank you.<br>"
        cDalNewSendEmail.SendEmail(Emails, Subject, Body, Sent)
        If Sent = True Then
            snackbar("green", "Treasury Office has been Notified")
        Else
            snackbar("green", "Failed to send Notification-Treasury")
        End If

    End Sub
End Class