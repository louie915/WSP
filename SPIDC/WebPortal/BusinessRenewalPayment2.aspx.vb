Imports System.Data.SqlClient

Public Class BusinessRenewalPayment2
    Inherits System.Web.UI.Page

    Dim usertmp As String
    Dim xTotalDue As Double
    Dim nTempGross As String
    Dim nHasPayment As Boolean = False
    Dim nFullyPaid As Boolean = False
    Dim nLQP As Integer
    Dim _nIsNewBusiness As String
    Dim nLGUName As String
    Dim radqtr As Integer = 0

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim Err As String = Nothing
                Dim _nClass As New cDalBPSOS
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

                Load_Details(cSessionLoader._pAccountNo, Err)
                Load_Requirements("RENEW")
                Load_Busline(cSessionLoader._pAccountNo, Err, _GVBusinessLine)

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._getModeP(cSessionLoader._pAccountNo)
            LblMOP.Text = cSessionLoader._pPayMode
            lblPeriodCovered.Text = cSessionLoader._pPeriodCovered
            loadGrid_TOP(cSessionLoader._pAccountNo)

                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                If _nClass.PaymentAttemptFound() Then
                    div_PaymentFound.Style.Add("display", "")
                Else
                    div_PaymentFound.Style.Add("display", "none")
                End If

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
            Dim CTC_REMARK As String = Nothing
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

            GridViewTOP.FooterRow.Cells(0).ColumnSpan = 2
            'GridViewTOP.FooterRow.Cells(0).ColumnSpan = 3
            GridViewTOP.FooterRow.Cells(0).Font.Bold = True
            GridViewTOP.FooterRow.Cells(0).Text = "T O T A L    D U E :"
            GridViewTOP.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Center

            'GridViewTOP.FooterRow.Cells(1).ColumnSpan = 2


            GridViewTOP.FooterRow.Cells(1).Font.Bold = True
            GridViewTOP.FooterRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(1).Text = Sum_TotTaxDue.ToString("N2")


            GridViewTOP.FooterRow.Cells(2).Font.Bold = True
            GridViewTOP.FooterRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(2).Text = Sum_TotPenDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(3).ColumnSpan = 2
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
    Sub Load_Requirements(ByVal switch As String)
        Try
            Dim hasRecord As Boolean
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            hasRecord = _nClass.hasSubmittedRequirements(cSessionLoader._pAccountNo)

            If hasRecord = True Then
                _nClass._pSubGetAttachmentsSubmitted(cSessionLoader._pAccountNo)
                div_SubmittedRequirements.Style.Add("display", "block")
                _GVRequirements.DataSource = _nClass._mDataTable
                _GVRequirements.DataBind()
            Else
                div_SubmittedRequirements.Style.Add("display", "none")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Sub Load_Busline(ByVal Acctno As String, ByRef Err As String, ByVal gvName As GridView)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubGetBusLine_GrossAssetEntry_TAXPAYER(Acctno)
            gvName.DataSource = _nClass._mDataTable
            gvName.DataBind()

        Catch ex As Exception
            Err = ex.Message
        End Try

    End Sub
    Sub Load_Details(ByVal Acctno As String, ByRef Err As String)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelect_Details(Acctno, PayNow2.OwnerName, _oLblBusName.Text, PayNow2.OwnerAddress, _oLblBusOwnership.Text, LblMOP.Text)
            _oLblBusID.Text = Acctno.ToUpper
            _oLblBusOwner.Text = PayNow2.OwnerName
            _oLblBusAddress.Text = PayNow2.OwnerAddress
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_TOP_ServerClick(sender As Object, e As EventArgs) Handles btn_TOP.ServerClick
        ReportViewer.NEWBP_TOP_ACCTNO = cSessionLoader._pAccountNo
        ReportViewer.NEWBP_TOP_Email = cSessionUser._pUserID
        Response.Redirect("Report/ReportViewer.aspx?ReportType=BP_TOP_2023")
    End Sub
    Private Sub btnPayNow_ServerClick(sender As Object, e As EventArgs) Handles btnPayNow.ServerClick
        Dim acctno As String = cSessionLoader._pAccountNo
        Dim Sum_TotAmtDue As Double
        Dim Sum_TotPenDue As Double
        Dim Sum_TotTaxDue As Double
        Dim Sum_TotETC As Double
        Dim CTC_AMOUNT As Double
        Dim CTC_REMARK As String = Nothing
        Dim _GrandTotal As String
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubSelectTOP(acctno, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, cSessionLoader._pBPQTR)
        _nClass._pSubGetCTC(acctno, CTC_AMOUNT, CTC_REMARK)
        cSessionLoader._pType = "Business Permit Renewal" 'unique
        cSessionLoader._pService = "BP" 'CTC       

        Dim _nclassX As New cDalGetModules
        _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        If _nclassX._pSubGetAvailableModules("IncludeCTC") <> True Then
            CTC_AMOUNT = 0
        End If

        _GrandTotal = CTC_AMOUNT + Sum_TotAmtDue
        cSessionLoader._pTotalAmountDue = Format(_GrandTotal.ToString, "STANDARD")



        Dim _nClassGetDate As New cDalGetDate
        _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        PayNow2.ACCTNO = cSessionLoader._pAccountNo
        PayNow2.BillingValidityDate = _nClassGetDate._GetEndOfDay_2 ' _nClassGetDate._GetEndOfDay("MMMM dd, yyyy hh:mm tt")
        PayNow2.Email = cSessionUser._pUserID
        PayNow2.FNAME = cSessionUser._pFirstName
        PayNow2.LNAME = cSessionUser._pLastName
        PayNow2.MNAME = cSessionUser._pMiddleName
        PayNow2.OtherFee = 0.0
        PayNow2.RawAmount = cSessionLoader._pTotalAmountDue
        PayNow2.SpidcFEE = 0.0
        PayNow2.SUFFIX = Nothing
        PayNow2.TotalAmount = cSessionLoader._pTotalAmountDue
        PayNow2.TransactionType = "BP"
        PayNow2.URL_Origin = HttpContext.Current.Request.Url.AbsoluteUri

        Response.Redirect("PayNow2.aspx")
    End Sub

    Private Sub btn_AppForm_ServerClick(sender As Object, e As EventArgs) Handles btn_AppForm.ServerClick
        Response.Redirect("Report/ReportViewer.aspx?ReportType=APPFORM" + "&ACCTNO=" + cSessionLoader._pAccountNo + "&STATCODE=R&TYPE=PAYMENT'")
    End Sub
End Class