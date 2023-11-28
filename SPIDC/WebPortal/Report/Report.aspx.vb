Imports IMC.Resources
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
Imports SPIDC.Resources


Public Class Report
    Inherits System.Web.UI.Page

    Private _mReportType As String
    Public Shared ACCTNO As String
    Dim AppID As String

    Dim Sum_TotAmtDue As Double
    Dim Sum_TotPenDue As Double
    Dim Sum_TotTaxDue As Double
    Dim Sum_TotETC As Double



    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Public Property _pReportType() As String
        Get
            Return _mReportType
        End Get
        Set(value As String)
            _mReportType = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cSessionLoader._pLGU_Name = "" '""
            cSessionLoader._pLGU_Address = "" '"
            'cSessionLoader._pAccountNo = "200219-00001"
            cSessionLoader._pCurrentYear = Year(Now)
            ClassPageSession_pBilling._pBusinessAccountNumber = cSessionLoader._pAccountNo
            If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                Response.Redirect("../register.aspx")
            End If

            Dim _nReportType As String = Request.QueryString("ReportType")

            _oDivPayment.Attributes.Add("style", "display:none")

            Select Case _nReportType
                Case "EnvelopeSeal"
                    _GenerateReport_EnvelopeSeal()
                Case "ApplicationForm"
                    _GenerateReport_ApplicationForm()
                Case "TOP"

                    If _fn_CheckIfHasBillingTemp() = False Then
                        _InsertLivetoWeb_BILLINGTEMP()
                    End If


                    _GenerateReport_TOP_NewFormat()
                    '_GenerateReport_TOP()
                    _oDivPayment.Attributes.Add("style", "display:block")
                    cSessionLoader._pAccountNo = ClassPageSession_pBilling._pBusinessAccountNumber

                    'ClassPageSession_pBilling._pTotalAmountDue = _FnGet_TotalDue()  ' @Remarked 20220613 LOUIE
                    'cSessionLoader._pTotalAmountDue = ClassPageSession_pBilling._pTotalAmountDue  ' @Remarked 20220613 LOUIE
                    cCookieUser._pUserID = cSessionUser._pUserID
                    cSessionLoader._pType = "Business Permit Application (NEW)"
                    cSessionLoader._pService = "BP"
                    _oHyperLinkProceedToPayment.NavigateUrl = "..\PayNow2.aspx"
                    GetCurrentQuarter()
                    _oDivRecomppute.Visible = False
            End Select

            'cSessionLoader._pAccountNo = "190521-00001"
            '     _mSubSendEmail()
            '_GenerateReport_ApplicationForm()
            ' _GenerateReport_EnvelopeSeal()
            'ClassSessionMailContent._pUserID = "lgutaxpayer01@yahoo.com"
            'If Not ClassSessionMailContent._pFuncSendEmailActivation() Then
            '    Label1.Text = "Sending email Failed!"
            'Else
            '    Label1.Text = "Sending email Successful!"
            'End If
            'SavePDFtoDB()
        Else
            _mReportType = Request.QueryString("ReportType")
        End If
    End Sub

    Protected Sub _Initialize_ProceedToPayment()
        Try
            Dim _nClass As New cDalNewBP
            Dim Sum_TotAmtDue As Double
            Dim CTC_AMOUNT As Double
            Dim CTC_REMARK As String
            Dim _GrandTotal As String
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass.Application_ID = AppID
            _nClass._pSubGetACCTNO(cSessionLoader._pAccountNo)

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelectTOP(cSessionLoader._pAccountNo, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, 0)
            _nClass._pSubGetCTC(cSessionLoader._pAccountNo, CTC_AMOUNT, CTC_REMARK)

            Dim _nclassX As New cDalGetModules
            _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclassX._pSubGetAvailableModules("IncludeCTC") <> True Then
                CTC_AMOUNT = 0
            End If

            cSessionLoader._pType = "New Business Permit" 'unique
            cSessionLoader._pService = "BP" 'CTC      
            'cSessionLoader._pAccountNo = ACCTNO
            _GrandTotal = CTC_AMOUNT + Sum_TotAmtDue
            cSessionLoader._pTotalAmountDue = Format(_GrandTotal.ToString, "STANDARD")
            _nClass._pSubGetPeriodCovered(cSessionLoader._pAccountNo, cSessionLoader._pPeriodCovered, cSessionLoader._pPayMode, cSessionLoader._pFORYEAR)



            'PayNow2.ACCTNO = ACCTNO
            'PayNow2.TransactionType = "BP"
            ''  txt_BillingValidityDate.Value = BillingValidityDate
            '' txt_Email.Value = Email
            ''  txt_LName.Value = LNAME
            '' txt_Fname.Value = FNAME
            ''  txt_Mname.Value = MNAME
            ''  txt_Suffix.Value = SUFFIX
            ''  txt_URL_Origin.Value = URL_Origin
            '' lbl_OtherFee.InnerText = OtherFee & PercentageFee_GW
            'PayNow2.RawAmount = cSessionLoader._pTotalAmountDue
            ''lbl_SPIDCFEE.InnerText = SpidcFEE & PercentageFee_SPIDC
            '' PayNow2.TotalAmount = cSessionLoader._pTotalAmountDue
            'Response.Redirect("PayNow2.aspx")

            Dim _nClassGetDate As New cDalGetDate
            _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS



            PayNow2.BillingValidityDate = _nClassGetDate._GetEndOfDay_2() '_nClassGetDate._GetEndOfDay("MMMM dd, yyyy hh:mm tt")
            PayNow2.ACCTNO = ACCTNO
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
            Dim _nRedirection As String
            '_nRedirection = HttpContext.Current.Request.Url.Authority.ToString & "/WebPortal/PayNow2.aspx"

            'PayNow2.URL_Origin = HttpContext.Current.Request.Url.AbsoluteUri
            'Response.Redirect(_nRedirection, False)
            Response.Redirect("..\PayNow2.aspx")
            'Context.ApplicationInstance.CompleteRequest()

        Catch ex As Exception

        End Try
    End Sub

    Private Function _fn_CheckIfHasBillingTemp() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'Dim _nClOAIMS As New cDalGlobalConnectionsDefault
            '_nClOAIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            '_nClOAIMS._pSetupGlobalConnectionsDatabases = "OAIMS"
            '_nClOAIMS._pSubRecordSelectSpecific()

            'Dim _nOAIMSServer As String = _nClOAIMS._pDBDataSource
            'Dim _nOAIMSDatabase As String = _nClOAIMS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM [BILLINGTEMP]  "
                ._pCondition = " WHERE ACCTNO =''" & cSessionLoader._pAccountNo & "'' and Foryear = Year(Getdate()) "
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + _nErrMsg + "');", True)
                End If

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try
    End Function

    Private Function _InsertLivetoWeb_BILLINGTEMP() As Boolean
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT "
                ._pSelect = "INSERT INTO [BILLINGTEMP] " & _
                              " ( Acctno, Foryear, Bus_Code, Desc1, Taxbase, Annualdue, Taxdue, PenDue, Totdue, Amt_Pd, Amt_PenPd, Discount, Taxcode, prevqtr, Qtryr1, Qtryr2, QtrPaid, Pres, Prev, Statcode, Newsw, ModeP, GradFix, Capital, Xsort, ORNo, " & _
                              "   DatePaid, BrgyCode, LocaCode, L_DatePD, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, Amt_Pd1, Amt_PenPd1, NewAmt_Pd, NewAmt_PenPd, NewTaxdue, NewPenDue, FieldName, PrevGMonth, GDateEsta," & _
                              "   GMonthPaid, DATE_ESTA, YearPeriod, NotEdit, NotDel, AssessTotal, UsedTCred, MainAcctCodePen, MainAcctDescPen, SubAcctCodePen, SubAcctDescPen, IsRegBill, ForClose, Area, xTotal, ADUE, xSQUENCELocal," & _
                              "   xSQUENCEPen, xSRS, xORNO, xSQUENCE, RES3, RES4, RES5, RES, RES1, RES2, QAMT, QDUE, PenYear, NotDelete, AAMT, I_DISCOUNT3, I_DISCOUNT4, I_DISCOUNT1, I_DISCOUNT2, I_YEAR2, I_YEAR3, I_YEAR4, I_YEAR1," & _
                              "   APPROVED, DATEAPP, TAXBALANCE, PENBALANCE, ForCompromise, ISPOSTED, EDITTEDBY, APPROVEDBY, EDITEDBY, EDPPrinted, Remarks0, Remarks1, RASSESBY, Remarks, xMainAcctCode, xMainAcctDesc," & _
                              "   xSubAcctCode, xSubAcctDesc, xMainAcctCodePen, xMainAcctDescPen, xSubAcctCodePen, xSubAcctDescPen, NEW1, NEW2, NEW3, NEW4, NEW5, XDEPT, ORIGDUEFEEADJ, TRANSTYPE" & _
                              "  ) "
                ._pSelect1 = " SELECT " & _
                              "  Acctno, Foryear, Bus_Code, Desc1, Taxbase, Annualdue, Taxdue, PenDue, Totdue, Amt_Pd, Amt_PenPd, Discount, Taxcode, prevqtr, Qtryr1, Qtryr2, QtrPaid, Pres, Prev, Statcode, Newsw, ModeP, GradFix, Capital, Xsort, ORNo, " & _
                              "  DatePaid, BrgyCode, LocaCode, L_DatePD, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, Amt_Pd1, Amt_PenPd1, NewAmt_Pd, NewAmt_PenPd, NewTaxdue, NewPenDue, FieldName, PrevGMonth, GDateEsta," & _
                              "  GMonthPaid, DATE_ESTA, YearPeriod, NotEdit, NotDel, AssessTotal, UsedTCred, MainAcctCodePen, MainAcctDescPen, SubAcctCodePen, SubAcctDescPen, IsRegBill, ForClose, Area, xTotal, ADUE, xSQUENCELocal," & _
                              "  xSQUENCEPen, xSRS, xORNO, xSQUENCE, RES3, RES4, RES5, RES, RES1, RES2, QAMT, QDUE, PenYear, NotDelete, AAMT, I_DISCOUNT3, I_DISCOUNT4, I_DISCOUNT1, I_DISCOUNT2, I_YEAR2, I_YEAR3, I_YEAR4, I_YEAR1," & _
                              "  APPROVED, DATEAPP, TAXBALANCE, PENBALANCE, ForCompromise, ISPOSTED, EDITTEDBY, APPROVEDBY, EDITEDBY, EDPPrinted, Remarks0, Remarks1, RASSESBY, Remarks, xMainAcctCode, xMainAcctDesc," & _
                              "  xSubAcctCode, xSubAcctDesc, xMainAcctCodePen, xMainAcctDescPen, xSubAcctCodePen, xSubAcctDescPen, NEW1, NEW2, NEW3, NEW4, NEW5, XDEPT, ORIGDUEFEEADJ, TRANSTYPE  " & _
                             " FROM [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.BILLINGTEMP "
                ._pCondition = " WHERE  ACCTNO = ''" & cSessionLoader._pAccountNo & "'' " & _
                               " AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + _nErrMsg + "');", True)
                End If

            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try
    End Function
    Public Sub GetCurrentQuarter()
        Try
            Dim mth As Integer = DateTime.Now.Month

            If mth <= 3 Then
                '' 1st
                _oDDL_Quarters.Items.Add("4")
                _oDDL_Quarters.Items.Add("3")
                _oDDL_Quarters.Items.Add("2")
                _oDDL_Quarters.Items.Add("1")

            ElseIf mth > 3 AndAlso mth <= 6 Then
                '' 2nd
                _oDDL_Quarters.Items.Add("4")
                _oDDL_Quarters.Items.Add("3")
                _oDDL_Quarters.Items.Add("2")

            ElseIf mth > 6 AndAlso mth <= 9 Then
                '' 3rd
                _oDDL_Quarters.Items.Add("4")
                _oDDL_Quarters.Items.Add("3")

            ElseIf mth > 9 AndAlso mth <= 12 Then
                '' 4th
                _oDivRecomppute.Attributes.Add("style", "display:none;")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub _RecomputeTOP()
        Try

            Dim _nQuarter As String = _oDDL_Quarters.SelectedValue

            'ClassPageSession_pBilling._pSubSessionClear()

            'ClassPageSession_pBilling._pUserId = cSessionUser._pUserID
            'ClassPageSession_pBilling._pReferenceNumber = DirectCast(_ngvrow.FindControl("_oLabelRefNo"), Label).Text
            'ClassPageSession_pBilling._pBusinessAccountNumber = DirectCast(_ngvrow.FindControl("_oLabelAccountNo"), Label).Text
            ClassPageSession_pBilling._pQuarterToPay = _nQuarter
            'ClassPageSession_pBilling._pTransactionType = "REGULAR BILLING" '_oTextBoxTransactionType.Text




            Dim _nResult As Boolean

            Dim _nClass As New ClassInterop_VB6_BPLTAS
            With _nClass
                ._pSubGenerateTOP(_nResult)
            End With

            If _nResult = True Then

                _GenerateReport_TOP()
                _oDivPayment.Attributes.Add("style", "display:block")
                cSessionLoader._pAccountNo = ClassPageSession_pBilling._pBusinessAccountNumber
                ClassPageSession_pBilling._pTotalAmountDue = _FnGet_TotalDue()
                cSessionLoader._pTotalAmountDue = ClassPageSession_pBilling._pTotalAmountDue
                cCookieUser._pUserID = cSessionUser._pUserID
                _oHyperLinkProceedToPayment.NavigateUrl = "..BPLTIMSPayment.aspx"
                '  cUrlRedirects._pSubRedirect(rPages_VS2014WABPLTIMS.pReport & "?ReportType=TOP", , 1)

            End If

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub

    Protected Sub Export(ByVal sender As Object, ByVal e As EventArgs)
        Dim warnings As Warning()
        Dim streamIds As String()
        Dim contentType As String
        Dim encoding As String
        Dim extension As String

        'Export the RDLC Report to Byte Array.
        Dim bytes As Byte() = _oRpt_EnvelopeSeal.LocalReport.Render("PDF" , Nothing, contentType, encoding, extension, streamIds, warnings)
        'Download the RDLC Report in Word, Excel, PDF and Image formats.

        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = contentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & _pReportType & "_" & cSessionLoader._pAccountNo & ".pdf")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()




    End Sub

    Public Sub _GenerateReport_TOP()
        Try
            ' The Report

            Dim _nClass As New cDalPayment
            '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pBPAccountNumber = ClassPageSession_pBilling._pBusinessAccountNumber
            _nClass._pSubSelectBillingReport()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable



            If _nDataTable.HasErrors Then
                Return
            End If

            If _nDataTable.Rows.Count <= 0 Then
                _oRpt_EnvelopeSeal.Visible = False
                'Return

            Else
                _oRpt_EnvelopeSeal.Visible = True
            End If




            _oRpt_EnvelopeSeal.Reset()
            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo

            For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format


            _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pBillingTOPOldversion   ' _gResxRdlc.pBillingTOP
            '_oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_GENERAL_FORMAT.rdlc")
            '_oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_GENERAL_FORMAT.rdlc")
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True


            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
            Dim _nReportDataSource As New ReportDataSource
            _nReportDataSource.Name = "Ds_BP_TOP" ' "dsReportBilling" ' The Name of the dataset in the RDLC Designer.
            ' _nReportDataSource.Name = "DsBP_TOP"
            _nReportDataSource.Value = _nDataTable
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


            Dim paramList As New List(Of ReportParameter)

            Dim _nClass2 As New cDalPayment
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass2._pBPAccountNumber = ClassPageSession_pBilling._pBusinessAccountNumber
            _nClass2._pSubGetParameter2()

            Dim _nNoEmp As Integer = 0
            Dim _nArea As Integer = 0

            _nNoEmp = _FnGetNotEmpTotal()
            _nArea = _FnGetMaxAreaBusLine()


            paramList.Add(New ReportParameter("RptPrmHeader1", "Republic of the Philippines"))
            paramList.Add(New ReportParameter("RptPrmHeader2", cSessionLoader._pLGU_Name))

            If cSessionLGUProfile._pLGU_Name.ToUpper.Contains("CITY") = True Then
                paramList.Add(New ReportParameter("RptPrmHeader3", "Office of the City Treasurer"))
            Else
                paramList.Add(New ReportParameter("RptPrmHeader3", "Office of the Municipal Treasurer"))
            End If

            paramList.Add(New ReportParameter("RptPrmHeader4", "Tax Order of Payment"))
            paramList.Add(New ReportParameter("RptPrmAuthor", "Systems & Plan Integrator & Development Corporation"))

            '  paramList.Add(New ReportParameter("RptReferenceNumber", _nClass2._pReferenceNumber))
            paramList.Add(New ReportParameter("RptPrmProcessingDate", _nClass2._pReferenceDate))
            paramList.Add(New ReportParameter("RptPrmAcctNo", ClassPageSession_pBilling._pBusinessAccountNumber))
            paramList.Add(New ReportParameter("RptPrmTaxpayer", _nClass2._pOwner))
            paramList.Add(New ReportParameter("RptPrmInfoStatus", _nClass2._pStatcode))
            paramList.Add(New ReportParameter("RptPrmInfoOwnership", _nClass2._pOwndesc))
            paramList.Add(New ReportParameter("RptPrmCommercialName", _nClass2._pCommercialName))
            paramList.Add(New ReportParameter("RptPrmInfoCommercialLocation", _nClass2._pCommercialAddress))
            paramList.Add(New ReportParameter("RptPrmInfoTotalAmountDue", ClassPageSession_pBilling._pTotalAmountDue))
            paramList.Add(New ReportParameter("RptPrmNoEmp", _nNoEmp))
            paramList.Add(New ReportParameter("RptPrmArea", _nArea))

            paramList.Add(New ReportParameter("RptPrmModeofPayment", "Annual"))

            ''paramList.Add(New ReportParameter("RptReferenceNumber", _nClass2._pReferenceNumber))
            'paramList.Add(New ReportParameter("RptReferenceDate", _nClass2._pReferenceDate))
            'paramList.Add(New ReportParameter("RptPrmInfoBusinessAccountNumber", ClassPageSession_pBilling._pBusinessAccountNumber))
            'paramList.Add(New ReportParameter("RptPrmInfoOwner", _nClass2._pOwner))
            'paramList.Add(New ReportParameter("RptPrmInfoStatus", _nClass2._pStatcode))
            'paramList.Add(New ReportParameter("RptPrmInfoOwnership", _nClass2._pOwndesc))
            'paramList.Add(New ReportParameter("RptPrmInfoCommercialName", _nClass2._pCommercialName))
            'paramList.Add(New ReportParameter("RptPrmInfoCommercialAddress", _nClass2._pCommercialAddress))
            'paramList.Add(New ReportParameter("RptPrmInfoTotalAmountDue", ClassPageSession_pBilling._pTotalAmountDue))


            ClassPageSession_pBilling._pCommercialName = _nClass2._pCommercialName

            Dim _nCharge As Double : Dim _nInterest As Double
            GetPenaltySetup(_nCharge, _nInterest)

            If _nClass2._pStatcode.ToUpper = "NEW" Then
                '@ Remarked | 20200330 | Louie
                'paramList.Add(New ReportParameter("RptMsg", "This TOP expires at the end of the month of this quarter. Your amount due will be imposed " & _nCharge & "% surcharge + " & _nInterest & "% penalty interest/month on the amount due + surcharge if not paid on time."))

                _oDivRecomppute.Attributes.Add("style", "display:none")

            ElseIf _nClass2._pStatcode.ToUpper = "RENEWAL" Then
                paramList.Add(New ReportParameter("RptMsg", "This TOP expires on the 20th day of billing date. Your amount due will be imposed " & _nCharge & "% surcharge + " & _nInterest & "% penalty interest/month on the amount due + surcharge if not paid on time."))
                _oDivRecomppute.Attributes.Add("style", "display:block")
            End If
            _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

            _oRpt_EnvelopeSeal.AsyncRendering = True

            SavePDFtoDB()
            _oRpt_EnvelopeSeal.LocalReport.Refresh()


            ' _oHyperLinkTOP.NavigateUrl = "~/pages/business/BPLTAS/NewBP/pViewImage.aspx?Settings=7&FileNo=" + ClassPageSession_pBilling._pFileNo
            '----------------------------------
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try
    End Sub


    'Newly Added -----------------------------------------------------------------------------


    Public Sub _GenerateReport_TOP_NewFormat()  '@Added 20220610 |LOUIE
        Try
            ' The Report

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pBPAccountNumber = ClassPageSession_pBilling._pBusinessAccountNumber
            _nClass._pSubSelectBillingTempNew_Caloocan(ClassPageSession_pBilling._pBusinessAccountNumber)

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable



            If _nDataTable.HasErrors Then
                Return
            End If

            If _nDataTable.Rows.Count <= 0 Then
                _oRpt_EnvelopeSeal.Visible = False
                'Return

            Else
                _oRpt_EnvelopeSeal.Visible = True
            End If




            _oRpt_EnvelopeSeal.Reset()
            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo

            For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format


            _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pBillingTOPOldversion   ' _gResxRdlc.pBillingTOP
            '_oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_GENERAL_FORMAT.rdlc")
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True


            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
            Dim _nReportDataSource As New ReportDataSource
            _nReportDataSource.Name = "DsBP_TOP" ' "dsReportBilling" ' The Name of the dataset in the RDLC Designer.
            ' _nReportDataSource.Name = "DsBP_TOP"
            _nReportDataSource.Value = _nDataTable
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


            Dim paramList As New List(Of ReportParameter)

            Dim _nClass2 As New cDalPayment
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass2._pBPAccountNumber = ClassPageSession_pBilling._pBusinessAccountNumber
            _nClass2._pSubGetParameter2()

            Dim _nNoEmp As Integer = 0
            Dim _nArea As Integer = 0

            Dim _nProcessedBy As String = Nothing
            Dim _nProcessedDate As Date

            _nNoEmp = _FnGetNotEmpTotal()
            _nArea = _FnGetMaxAreaBusLine()
            ClassPageSession_pBilling._pTotalAmountDue = _FnGet_BPTotalDue()
            'cSessionLGUProfile()
            'cSessionLoader._pLGU_Name = 

            paramList.Add(New ReportParameter("RptPrmHeader1", "Republic of the Philippines"))
            paramList.Add(New ReportParameter("RptPrmHeader2", cSessionLGUProfile._pLGU_Name))

            If cSessionLGUProfile._pLGU_Name.ToUpper.Contains("CITY") = True Then
                paramList.Add(New ReportParameter("RptPrmHeader3", "Office of the City Treasurer"))
            Else
                paramList.Add(New ReportParameter("RptPrmHeader3", "Office of the Municipal Treasurer"))
            End If

            paramList.Add(New ReportParameter("RptPrmHeader4", "Tax Order of Payment"))
            paramList.Add(New ReportParameter("RptPrmAuthor", "Systems & Plan Integrator & Development Corporation"))


            paramList.Add(New ReportParameter("RptPrmProcessingDate", _nClass2._pReferenceDate))
            paramList.Add(New ReportParameter("RptPrmAcctNo", ClassPageSession_pBilling._pBusinessAccountNumber))
            paramList.Add(New ReportParameter("RptPrmTaxpayer", _nClass2._pOwner))
            paramList.Add(New ReportParameter("RptPrmInfoStatus", _nClass2._pStatcode))
            paramList.Add(New ReportParameter("RptPrmInfoOwnership", _nClass2._pOwndesc))
            paramList.Add(New ReportParameter("RptPrmCommercialName", _nClass2._pCommercialName))
            paramList.Add(New ReportParameter("RptPrmInfoCommercialLocation", _nClass2._pCommercialAddress))
            paramList.Add(New ReportParameter("RptPrmInfoTotalAmountDue", ClassPageSession_pBilling._pTotalAmountDue))
            paramList.Add(New ReportParameter("RptPrmNoEmp", _nNoEmp))
            paramList.Add(New ReportParameter("RptPrmArea", _nArea))
            'paramList.Add(New ReportParameter("RptPrmPeriodCover", _FnGetCoveredPeriod))

            paramList.Add(New ReportParameter("RptPrmModeofPayment", "Annual"))
            Dim _nCTCAmount As Double
            Dim _nGrandTotal As Double
            paramList.Add(New ReportParameter("RptCTCAssessment", _FnGetCTCAssessment(_nCTCAmount, _nGrandTotal) & vbNewLine & "-----------------------------------" & vbNewLine & "Grand Total : ₱" & Format(_nGrandTotal.ToString, "standard")))

            Dim _nDateEsta As String
            _nDateEsta = Format(_nClass2._pDate_Esta, "yyyyMMdd")
            paramList.Add(New ReportParameter("RptPrmWebAssessNo", "WEB-" & ClassPageSession_pBilling._pBusinessAccountNumber & _nDateEsta))

            'Processor Information -------------------------------------------------------
            _FnGetDOC_TRACK(_nProcessedBy, _nProcessedDate)
            paramList.Add(New ReportParameter("RptPrmProcessedBy", _nProcessedBy))
            paramList.Add(New ReportParameter("RptPrmProcessedByDate", Format(_nProcessedDate, "MM/dd/yyyy").ToString))

            'Notices-----------------------------------------------------------------------
            Dim _nNotice1 As String = Nothing
            Dim _nNotice2 As String = Nothing
            Dim _nNotice3 As String = Nothing
            Dim _nNotice4 As String = Nothing
            Dim _nNotice5 As String = Nothing
            Dim _nNotice6 As String = Nothing

            _FnGetTOPSETUP(_nNotice1, _nNotice2, _nNotice3, _nNotice4, _nNotice5, _nNotice6)
            paramList.Add(New ReportParameter("RptPrmNotice1", _nNotice1))
            paramList.Add(New ReportParameter("RptPrmNotice2", _nNotice2))
            paramList.Add(New ReportParameter("RptPrmNotice3", _nNotice3))
            paramList.Add(New ReportParameter("RptPrmNotice4", _nNotice4))
            paramList.Add(New ReportParameter("RptPrmNotice5", _nNotice5))
            paramList.Add(New ReportParameter("RptPrmNotice6", _nNotice6))
            '------------------------------------------------------------------------------

            'Signatories-----------------------------------------------------------------------
            Dim _nSignUserName As String = Nothing
            Dim _nSignPB As String = Nothing
            Dim _nSignRAB As String = Nothing
            Dim _nLeftSignatory As String = Nothing
            Dim _nLeftDesignation As String = Nothing
            Dim _nRightSignatory As String = Nothing
            Dim _nRightDesignation As String = Nothing

            _FnGetSignatory(_nSignUserName, _nSignPB, _nSignRAB, _nLeftSignatory, _nLeftDesignation, _nRightSignatory, _nRightDesignation)

            paramList.Add(New ReportParameter("PrtPrmApprovedPayment", _nRightSignatory))
            paramList.Add(New ReportParameter("RptApprovedPayment_Desig", _nRightDesignation))
            paramList.Add(New ReportParameter("RptPrmRecomApproval_Name", _nLeftSignatory))
            paramList.Add(New ReportParameter("RptPrmRecomApproval_Designation", _nLeftDesignation))
            paramList.Add(New ReportParameter("RptPrmUserName", _nSignUserName))
            paramList.Add(New ReportParameter("RptRABLabel", _nSignRAB))
            '------------------------------------------------------------------------------


            ' -----------------------------------------------------------------------------------------------------------------------
            Dim _nBillDate As Date = Format(_nProcessedDate, "MM/dd/yyyy")


            _FnGetBillingExpiry(paramList, _nBillDate, "", Date.Now, Date.Now, "")


            ClassPageSession_pBilling._pCommercialName = _nClass2._pCommercialName

            Dim _nCharge As Double : Dim _nInterest As Double
            GetPenaltySetup(_nCharge, _nInterest)

            If _nClass2._pStatcode.ToUpper = "NEW" Then

                _oDivRecomppute.Attributes.Add("style", "display:none")

            ElseIf _nClass2._pStatcode.ToUpper = "RENEWAL" Then
                paramList.Add(New ReportParameter("RptMsg", "This TOP expires on the 20th day of billing date. Your amount due will be imposed " & _nCharge & "% surcharge + " & _nInterest & "% penalty interest/month on the amount due + surcharge if not paid on time."))
                _oDivRecomppute.Attributes.Add("style", "display:block")
            End If
            _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

            _oRpt_EnvelopeSeal.AsyncRendering = True

            'SavePDFtoDB()
            _oRpt_EnvelopeSeal.LocalReport.Refresh()


            ' _oHyperLinkTOP.NavigateUrl = "~/pages/business/BPLTAS/NewBP/pViewImage.aspx?Settings=7&FileNo=" + ClassPageSession_pBilling._pFileNo
            '----------------------------------
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try
    End Sub

    Public Function _FnGetCoveredPeriod() As String
        Try

            Dim _nSuccsess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select " & _
                    " ISNULL((Select top(1) Qtryr1 from BILLINGTEMP where Acctno =''" & ClassPageSession_pBilling._pBusinessAccountNumber & "'' and IsRegBill=''1''  order by Foryear, Bus_Code desc, Qtryr1 desc, Qtryr2 ) ,'''') + ''-'' + " & _
                    " (Select top(1) Qtryr2 from BILLINGTEMP  where Acctno =''" & ClassPageSession_pBilling._pBusinessAccountNumber & "''   and IsRegBill=''1''  order by Foryear Desc, Bus_Code desc, Qtryr1 desc, Qtryr2 Desc) as CoverPeriod "

                ._pExec(_nSuccsess, _nErrMsg)


                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable


                _FnGetCoveredPeriod = _nDataTable.Rows("0").Item("CoverPeriod")

            End With

        Catch ex As Exception

        End Try


    End Function


    Public Sub _FnGetDOC_TRACK(ByRef _nProcessedBy As String, ByRef _nProcessDate As Date) '@Added 20220613


        Dim _nSqlCmd As SqlCommand
        Dim _nSqlDtr As SqlDataReader
        Dim _nSqlDataAdpt As SqlDataAdapter
        Dim _nSqllocalCon As SqlConnection
        Dim _nSqlCon As SqlConnection
        Try

            Dim _nClass As New cDal_IUD

            With _nClass
                _nSqlCmd = New SqlCommand("Select top(1) * from [DOC_TRACK" & Year(Now).ToString & "] where acctno = '" & ClassPageSession_pBilling._pBusinessAccountNumber & "' and xTransaction = 'PRINT TOP' order by ProcessTime desc ", cGlobalConnections._pSqlCxn_BPLTAS_D)
                _nSqlDtr = _nSqlCmd.ExecuteReader

                If _nSqlDtr.HasRows Then
                    _nSqlDtr.Read()

                    _nProcessedBy = _nSqlDtr.Item("FullName") '  _nDataTable.Rows("0").Item("FullName").ToString
                    _nProcessDate = _nSqlDtr.Item("ProcessTime") ' _nDataTable.Rows("0").Item("ProcessTime")

                End If


            End With

        Catch ex As Exception

        End Try


    End Sub

    Public Sub _FnGetSignatory(ByRef _nSignUserName As String, _
                               ByRef _nSignPB As String, _
                               ByRef _nSignRAB As String, _
                               ByRef _nLeftSignatory As String, _
                               ByRef _nLeftDesignation As String, _
                               ByRef _nRightSignatory As String, _
                               ByRef _nRightDesignation As String) '@Added 20220614


        Dim _nSqlCmd As SqlCommand
        Dim _nSqlDtr As SqlDataReader
        Dim _nSqlDataAdpt As SqlDataAdapter
        Dim _nSqllocalCon As SqlConnection
        Dim _nSqlCon As SqlConnection
        Try

            Dim _nClass As New cDal_IUD

            With _nClass
                _nSqlCmd = New SqlCommand("    Select top 1 (select top 1 EDPPRINTED from BILLINGTEMP where acctno='" & ClassPageSession_pBilling._pBusinessAccountNumber & "' ) as 'UserName', " & _
                                            "  A.PB, A.RAB, ( Isnull(C.Title,'') + ' ' + Isnull(C.FNAME,'') + ' ' + Isnull(C.MNAME,'') + ' ' + Isnull(C.LNAME,'')) as Left_Signatory, isnull(C.DESIGNATION,'') as Left_Designation " & _
                                            " ,	( Isnull(B.Title,'') + ' ' + Isnull(B.FNAME,'') + ' ' + Isnull(B.MNAME,'') + ' ' + Isnull(B.LNAME,'')) as Right_Signatory, B.DESIGNATION as Right_Designation	from TOPSETUP A  " & _
                                            "  left outer join PERSCODE B on A.SAFP1 = b.DESIGNATION   " & _
                                            "  left outer join PERSCODE C on A.SRAB = C.DESIGNATION ", cGlobalConnections._pSqlCxn_BPLTAS)
                _nSqlDtr = _nSqlCmd.ExecuteReader

                If _nSqlDtr.HasRows Then
                    _nSqlDtr.Read()

                    _nSignUserName = _nSqlDtr.Item("UserName").ToString
                    _nSignPB = _nSqlDtr.Item("PB").ToString
                    _nSignRAB = _nSqlDtr.Item("RAB").ToString
                    _nLeftSignatory = _nSqlDtr.Item("Left_Signatory").ToString
                    _nLeftDesignation = _nSqlDtr.Item("Left_Designation").ToString
                    _nRightSignatory = _nSqlDtr.Item("Right_Signatory").ToString
                    _nRightDesignation = _nSqlDtr.Item("Right_Designation").ToString

                End If


            End With

        Catch ex As Exception

        End Try


    End Sub

    Public Sub _FnGetTOPSETUP(ByRef _nNotice1 As String, ByRef _nNotice2 As String, ByRef _nNotice3 As String, ByRef _nNotice4 As String, ByRef _nNotice5 As String, ByRef _nNotice6 As String) '@Added 20220613


        Dim _nSqlCmd As SqlCommand
        Dim _nSqlDtr As SqlDataReader
        Dim _nSqlDataAdpt As SqlDataAdapter
        Dim _nSqllocalCon As SqlConnection
        Dim _nSqlCon As SqlConnection
        Try

            Dim _nClass As New cDal_IUD

            With _nClass

                _nSqlCmd = New SqlCommand("Select * from TOPSETUP ", cGlobalConnections._pSqlCxn_BPLTAS)

                _nSqlDtr = _nSqlCmd.ExecuteReader

                If _nSqlDtr.HasRows Then
                    _nSqlDtr.Read()

                    _nNotice1 = _nSqlDtr.Item("Notice1").ToString
                    _nNotice2 = _nSqlDtr.Item("Notice2").ToString
                    _nNotice3 = _nSqlDtr.Item("Notice3").ToString
                    _nNotice4 = _nSqlDtr.Item("Notice4").ToString
                    _nNotice5 = _nSqlDtr.Item("Notice5").ToString
                    _nNotice6 = _nSqlDtr.Item("Notice6").ToString

                End If


            End With

        Catch ex As Exception

        End Try


    End Sub

    Public Sub _FnGetBillingExpiry(ByVal paramList As List(Of ReportParameter), ByVal _nBillDate As Date, ByVal _nGetQtr As String, _nSetupExpDate As Date, _nDueDate As Date, _nLastDayOfFeb As String) '@Added 20220613


        Dim _nMonthofFeb As Date = Nothing
        Dim _nlastDayOfMonth As Date = Nothing

        If Month(Format(_nBillDate, "MM/dd/yyyy")) = 2 Then
            _nMonthofFeb = New DateTime(_nBillDate.Year, _nBillDate.Month, 1)
            _nlastDayOfMonth = _nMonthofFeb.AddMonths(1).AddDays(-1)
            _nLastDayOfFeb = _nlastDayOfMonth.Day
        End If

        Dim _nSqlCmd As SqlCommand
        Dim _nSqlDtr As SqlDataReader
        Dim _nSqlDataAdpt As SqlDataAdapter
        Dim _nSqllocalCon As SqlConnection
        Dim _nSqlCon As SqlConnection

        Try

            Dim _nClass As New cDal_IUD

            With _nClass

                _nSqlCmd = New SqlCommand("	SELECT QTREFF as BILL_QTR,Isnull([MONTH],0) as MONTH ,Isnull(EXTNDAY,0) as EXTNDAY, " &
                                            "Isnull(MONTHQ2,'') as MONTHQ2,Isnull(EXTNDAYQ2,'') as EXTNDAYQ2, " &
                                            "	Isnull(MONTHQ3,'') as MONTHQ3,Isnull(EXTNDAYQ3,'') as EXTNDAYQ3, " &
                                            " isnull(MONTHQ4,'') as MONTHQ4,Isnull(EXTNDAYQ4,'') as EXTNDAYQ4," &
                                            " NOMPEN FROM SETUP ", cGlobalConnections._pSqlCxn_BPLTAS)

                _nSqlDtr = _nSqlCmd.ExecuteReader

                If _nSqlDtr.HasRows Then
                    _nSqlDtr.Read()



                    If Left(Format(_nBillDate, "MM/dd/yyyy"), 2) <= 3 Then ''------------------get expiry date parameter in RptOnORBeforeDueDate
                        _nGetQtr = 1
                    ElseIf Left(Format(_nBillDate, "MM/dd/yyyy"), 2) <= 6 Then
                        _nGetQtr = 2
                    ElseIf Left(Format(_nBillDate, "MM/dd/yyyy"), 2) <= 9 Then
                        _nGetQtr = 3
                    ElseIf Left(Format(_nBillDate, "MM/dd/yyyy"), 2) <= 12 Then
                        _nGetQtr = 4
                    End If

                    _nSetupExpDate = _nSqlDtr.Item("Month") & "/" & _nSqlDtr.Item("EXTNDAY") & "/" & Year(_nBillDate)

                    Select Case _nGetQtr
                        Case "1"
                            If _nBillDate <= _nSetupExpDate Then
                                _nDueDate = _nSetupExpDate
                            Else
                                If _nSqlDtr.Item("NOMPEN") = 0 Then

                                    If Month(_nBillDate) = 1 Then
                                        _nDueDate = "2/20/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 2 Then
                                        _nDueDate = "3/20/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 3 Then
                                        _nDueDate = "4/20/" & Year(_nBillDate)
                                    End If
                                Else
                                    If Month(_nBillDate) = 1 Then
                                        _nDueDate = "1/31/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 2 Then
                                        _nDueDate = "2/" & (_nLastDayOfFeb) & "/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 3 Then
                                        _nDueDate = "3/31/" & Year(_nBillDate)
                                    End If
                                End If
                            End If
                        Case "2"
                            If _nBillDate <= _nSetupExpDate Then
                                _nDueDate = _nSetupExpDate
                            Else
                                If _nSqlDtr.Item("NOMPEN") = 0 Then
                                    If Month(_nBillDate) = 4 Then
                                        _nDueDate = "5/20/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 5 Then
                                        _nDueDate = "6/20/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 6 Then
                                        _nDueDate = "7/20/" & Year(_nBillDate)
                                    End If
                                Else
                                    If Month(_nBillDate) = 4 Then
                                        _nDueDate = "4/30/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 5 Then
                                        _nDueDate = "5/31/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 6 Then
                                        _nDueDate = "6/30/" & Year(_nBillDate)
                                    End If
                                End If
                            End If

                        Case "3"
                            If _nBillDate <= _nSetupExpDate Then
                                _nDueDate = _nSetupExpDate
                            Else
                                If _nSqlDtr.Item("NOMPEN") = 0 Then
                                    If Month(_nBillDate) = 7 Then
                                        _nDueDate = "8/20/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 8 Then
                                        _nDueDate = "9/20/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 9 Then
                                        _nDueDate = "10/20/" & Year(_nBillDate)
                                    End If
                                Else
                                    If Month(_nBillDate) = 7 Then
                                        _nDueDate = "7/31/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 8 Then
                                        _nDueDate = "8/31/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 9 Then
                                        _nDueDate = "9/30/" & Year(_nBillDate)
                                    End If
                                End If
                            End If

                        Case "4"

                            If _nBillDate <= _nSetupExpDate Then
                                _nDueDate = _nSetupExpDate
                            Else
                                If _nSqlDtr.Item("NOMPEN") = 0 Then
                                    If Month(_nBillDate) = 10 Then
                                        _nDueDate = "11/20/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 11 Then
                                        _nDueDate = "12/20/" & Year(_nBillDate)

                                    End If
                                Else
                                    If Month(_nBillDate) = 10 Then
                                        _nDueDate = "10/31/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 11 Then
                                        _nDueDate = "11/30/" & Year(_nBillDate)
                                    ElseIf Month(_nBillDate) = 12 Then
                                        _nDueDate = "12/31/" & Year(_nBillDate)
                                    End If
                                End If
                            End If

                    End Select

                    paramList.Add(New ReportParameter("RptOnORBeforeDueDate", Format(CDate(_nDueDate), "MMMM dd, yyyy")))
                    paramList.Add(New ReportParameter("RptPrmModeofPayment", "Annual"))
                    paramList.Add(New ReportParameter("RptRenOnBefore", Format(CDate(_nDueDate), "MMMM dd, yyyy")))
                    paramList.Add(New ReportParameter("RptQtr", _nGetQtr))
                    paramList.Add(New ReportParameter("RptDate", Format(CDate(_nDueDate), "MMMM dd, yyyy")))

                End If

            End With

        Catch ex As Exception

        End Try


    End Sub

    Public Function _FnGetCTCAssessment(ByRef _nCTCAmount As Double, ByRef _nGrandTotal As Double) As String '@Added|LOUIE|20220613
        Try

            Dim _nSuccsess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                ._pAction = "SELECT"
                ._pSelect = "Select * from  BILLINGTEMP where acctno = ''" & ClassPageSession_pBilling._pBusinessAccountNumber & "'' and IsRegBill = ''1''"

                ._pExec(_nSuccsess, _nErrMsg)


                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable


                _FnGetCTCAssessment = _nDataTable.Rows("0").Item("CTC_REMARK")
                _nCTCAmount = _nDataTable.Rows("0").Item("CTC_AMOUNT")

                _nGrandTotal = (ClassPageSession_pBilling._pTotalAmountDue + _nCTCAmount)
                cSessionLoader._pTotalAmountDue = _nGrandTotal
            End With

        Catch ex As Exception

        End Try


    End Function


    Public Function _FnGet_BPTotalDue() As Double
        Try

            'BPLTAS LIVE
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                ._pAction = "SELECT"
                '._pSelect = "SELECT SUM(CAST(Totdue as money)) AS TOTAL_DUE FROM [" & _nOAIMS_Svr & "].[" & _nOAIMS_Db & "].dbo.BILLINGTEMP WHERE Acctno = ''" & ClassPageSession_pBilling._pBusinessAccountNumber & "''"
                ._pSelect = "SELECT SUM(CAST(Totdue as money)) AS TOTAL_DUE FROM BILLINGTEMP WHERE Acctno = ''" & ClassPageSession_pBilling._pBusinessAccountNumber & "''  and IsRegBill = ''1''"
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("TOTAL_DUE")
                Else
                    Return 0
                End If

            End With

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Function
    '--------------------------------------------------------------------------------------------
    Public Function _FnGetNotEmpTotal() As Integer  '@Added | 20200330 | LOUIE
        Try

            Dim _nSuccsess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select (isnull(NO_EMP_F,0) + ISNULL(NO_EMP_M,0)) as NO_EMP_TOTAL from BUSMASTEXTN Where ACCTNO = ''" & ClassPageSession_pBilling._pBusinessAccountNumber & "''"
                ._pExec(_nSuccsess, _nErrMsg)


                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                _FnGetNotEmpTotal = _nDataTable.Rows("0").Item("NO_EMP_TOTAL")

            End With

        Catch ex As Exception

        End Try
    End Function

    Public Function _FnGetMaxAreaBusLine() As Integer  '@Added | 20200330 | LOUIE
        Try

            Dim _nSuccsess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " Select  MAX(AREA) AREA from BUSLINE Where ACCTNO = ''" & ClassPageSession_pBilling._pBusinessAccountNumber & "'' AND FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccsess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                _FnGetMaxAreaBusLine = _nDataTable.Rows("0").Item("AREA")

            End With

        Catch ex As Exception

        End Try
    End Function



    Public Sub GetPenaltySetup(ByRef xCharge As Double, ByRef xInterest As Double)
        Try
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelectPenaltySetup()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable
            If _nDataTable.Rows.Count > 0 Then
                xCharge = _nDataTable.Rows("0").Item("BT_PENALTY").ToString
                xInterest = _nDataTable.Rows("0").Item("BT_INTEREST").ToString

            End If
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try



    End Sub
    Public Sub SavePDFtoDB()
        Dim pdfContent As Byte() = _oRpt_EnvelopeSeal.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        ''Creatr PDF file on disk
        'Dim pdfPath As String = "C:\MyFile\report.pdf"
        'Dim pdfFile As New System.IO.FileStream(pdfPath, System.IO.FileMode.Create)
        'pdfFile.Write(pdfContent, 0, pdfContent.Length)
        'pdfFile.Close()

        Dim _mFileNo As String = _nFnGenerateFileNo()
        Dim _mFileID As String = ClassPageSession_pBilling._pBusinessAccountNumber & "_" & _nFnGenerateFileID()
        ClassPageSession_pBilling._pFileNo = _mFileNo
        Dim _nClass3 As New cDalBilling
        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nClass3._pImageData = pdfContent
        _nClass3._pSubSaveReportImage(_mFileNo, _mFileID, ClassPageSession_pBilling._pBusinessAccountNumber)
    End Sub
    Private Function _nFnGenerateFileID()
        Try
            _nFnGenerateFileID = Nothing
            Dim _nClass As New cDalBilling

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubGenerateFileID()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable2

            Try
                '----------------------------------
                If _nDataTable.Rows.Count <> 0 Then
                    _nFnGenerateFileID = _nDataTable.Rows("0").Item("FileID").ToString
                End If
                '----------------------------------
            Catch ex As Exception

            End Try
            'End If
            '----------------------------------
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Function
    Private Function _nFnGenerateFileNo() As String
        Try
            _nFnGenerateFileNo = Nothing
            '----------------------------------
            Dim _nStringID As String = ""
            Dim _nStrAuto As String = ""
            Dim _nStrAutoExtn As String = ""
            Dim _nIntegerID As String = ""

            Dim _nClass As New cDalBilling

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubSelectFileNo()


            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable2

            Try
                '----------------------------------
                'If _nDataTable.HasErrors Then
                '    _mSubShowEmptyTraningCourseGridView()
                'End If

                If _nDataTable.Rows.Count <> 0 Then

                    _nStringID = _nDataTable.Rows("0").Item("FileID").ToString

                    If _nStringID = "" Then

                        _nIntegerID = "000000000000001"
                    Else
                        _nIntegerID = _nStringID
                        _nIntegerID = Format(_nIntegerID + 1, "000000000000000")
                    End If

                    _nStrAuto = _nIntegerID
                End If

                _nFnGenerateFileNo = _nStrAuto

                '----------------------------------
            Catch ex As Exception

            End Try
            'End If
            '----------------------------------
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Function

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
                    _oRpt_EnvelopeSeal.Enabled = False
                Else
                    _oRpt_EnvelopeSeal.Enabled = True
                End If

                _oRpt_EnvelopeSeal.Reset()
                '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
                Dim info As FieldInfo

                For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                    If extension.Name <> "PDF" Then
                        info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                        info.SetValue(extension, False)
                    End If
                Next
                '--------END (Shows only PDF as EXPORT Extension)-uneditable print format


                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pReportEnvelopeSeal
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "ds_EnvelopeSeal"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("LGUAddress", ""))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True

            End With


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub
    Public Sub _GenerateReport_ApplicationForm()
        'Try

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
                _oRpt_EnvelopeSeal.Enabled = False
            Else
                _oRpt_EnvelopeSeal.Enabled = True
            End If

            _oRpt_EnvelopeSeal.Reset()

            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo

            For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
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

            _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pReportApplicationInfo
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
            Dim _nReportDataSource As New ReportDataSource
            _nReportDataSource.Name = "ds_Application"
            _nReportDataSource.Value = _nDataTable
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

            Dim _TotalEmp As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_TOTAL") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_TOTAL"))
            Dim _NoEmpLGU As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_LGU") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_LGU"))
            Dim paramList As New List(Of ReportParameter)


            paramList.Add(New ReportParameter("Status", cLoader_BPLTIMS._pSTATCODE))
            paramList.Add(New ReportParameter("Emp_Total", _TotalEmp))
            paramList.Add(New ReportParameter("Emp_LGU", _NoEmpLGU))
            _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()
            _oRpt_EnvelopeSeal.Enabled = True



        End With
        _RenderToPDF("ApplicationForm") ' <<<< Render Report to PDF and Save to temporary folder
        _SendEmailNotif()
        'Catch ex As Exception
        '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        'End Try
    End Sub
    Protected Function _mSubSendEmail() As Boolean 'Added 20171120

        Dim _nReturnValue As Boolean
        Try
            'Send Email For the Notification
            '----------------------------------
            Dim _mEmailWebMaster As String
            Dim _mPassword As String
            Dim _mEmailCC As String
            Dim _mEmailBCC As String

            Dim _nclassEmailSetup As New cDalGetWebEmailMaster
            _nclassEmailSetup._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nclassEmailSetup._pSubGetEmailMaster()

            _mEmailWebMaster = _nclassEmailSetup._pEmailMaster
            _mPassword = _nclassEmailSetup._pPassword
            _mEmailCC = _nclassEmailSetup._pEmailCC
            _mEmailBCC = _nclassEmailSetup._pEmailBCC
            '----------------------------------

            '----------------------------------
            'Date
            Dim _nDate As String = FormatDateTime(Now, DateFormat.LongDate)

            Dim _nClass As New ClassEmailGoogle
            Dim _nStrucInfo As New ClassEmailGoogle._InfoEmail

            '----------------------------------
            'From
            _nStrucInfo._pEmailFrom = _mEmailWebMaster

            '----------------------------------
            'To
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(cCookieUser._pUserID)
                _nStrucInfo._pEmailTo = _nArrayList

            Catch ex As Exception

            End Try

            '----------------------------------
            'Cc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailCC)
                _nStrucInfo._pEmailCc = _nArrayList

            Catch ex As Exception

            End Try

            '----------------------------------
            'Bcc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailBCC)
                _nStrucInfo._pEmailBcc = _nArrayList

            Catch ex As Exception

            End Try

            '----------------------------------

            'Subject
            _nStrucInfo._pEmailSubject = "Notification"

            '----------------------------------

            'Body --tomi
            _nStrucInfo._pEmailBody = "Sir/Ma`am: <br> " & _
                                "Your Business account for Account Number " & cSessionLoader._pAccountNo & " is now for review and verification by Business Permit Licensing Officer. <br>" & _
                                "Please wait for 1 working day for approval of application. <br>" & _
                                "Thank you. <br>"
            '----------------------------------

            'Header
            _nStrucInfo._pEmailHeader = cSessionLoader._pLGU_Name & "<br> <br> "

            '----------------------------------

            'Footer
            _nStrucInfo._pEmailFooter = "<br> Date Sent : " & Now.Date & _
            "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."

            '----------------------------------
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nUrlLink]", "")

            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nUserID]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nFirstName]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nLastName]", "")

            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nDate]", _nDate)
            '----------------------------------
            'Mail Client Credential
            _nStrucInfo._pEMailClientUserName = _mEmailWebMaster
            _nStrucInfo._pEMailClientPassword = _mPassword

            '----------------------------------
            _nClass._pStrucInfo = _nStrucInfo

            If _nClass._pFuncSendEmail() Then
                _nReturnValue = True
                Return True
            Else
                _nReturnValue = False
                Return False
            End If

            _nClass = Nothing

            '----------------------------------
        Catch ex As Exception
            Return False
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Function
    Protected Function _FnSenSMS() As Boolean
        _FnSenSMS = True

        Dim apikey As String = "p68YM3B0Zyc-lwnunJCX1FAGkKzXj3lEjyAKbcb7RL"

        Dim SenderName As String = "Mr.Aviles"
        Dim Number As String = ""
        Dim Message As String = "This is an API message"
        Dim URL As String = "https://api.txtlocal.com/send/?"
        Dim PostData As String = "apikey=" & apikey & "&sender=" & SenderName & "&numbers=" & Number & "&message=" & Message
        Dim req As HttpWebRequest = WebRequest.Create(URL)
        req.Method = "POST"
        Dim encoding As New ASCIIEncoding()
        Dim byte1 As Byte() = encoding.GetBytes(PostData)
        req.ContentType = "application/x-www-form-urlencoded"
        req.ContentLength = byte1.Length
        Dim newStream As Stream = req.GetRequestStream()
        newStream.Write(byte1, 0, byte1.Length)

        Try
            Dim resp As HttpWebResponse = req.GetResponse()
            Dim sr As New StreamReader(resp.GetResponseStream())
            Dim results As String = sr.ReadToEnd()
            sr.Close()
            ' Label1.Text = results

        Catch wex As WebException
            Response.Write("SOMETHING WENT AWRY! Status: " & wex.Status & "Message: " & wex.Message & "")
            Return False
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + wex.Message + "');", True)
        End Try

    End Function
    Public Function _FnGet_TotalDue() As Double
        Try

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "OAIMS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nOAIMS_Svr As String = _nClBP._pDBDataSource
            Dim _nOAIMS_Db As String = _nClBP._pDBInitialCatalog

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                '._pSelect = "SELECT SUM(CAST(Totdue as money)) AS TOTAL_DUE FROM [" & _nOAIMS_Svr & "].[" & _nOAIMS_Db & "].dbo.BILLINGTEMP WHERE Acctno = ''" & ClassPageSession_pBilling._pBusinessAccountNumber & "''"
                ._pSelect = "SELECT SUM(CAST(Totdue as money)) AS TOTAL_DUE FROM BILLINGTEMP WHERE Acctno = ''" & ClassPageSession_pBilling._pBusinessAccountNumber & "''"
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("TOTAL_DUE")
                Else
                    Return 0
                End If

            End With

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Function
    Public Sub _RenderToPDF(_nDocName As String)
        Try


            Dim warnings As Warning() = Nothing
            Dim streamids As String() = Nothing
            Dim mimeType As String = Nothing
            Dim encoding As String = Nothing
            Dim extension As String = Nothing
            Dim bytes As Byte()
            Dim _nFileName As String = cSessionLoader._pAccountNo & "_" & _nDocName & ".pdf"

            bytes = _oRpt_EnvelopeSeal.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

            Dim FolderLocation As String = HttpContext.Current.Server.MapPath("~/Temp/")
            'First delete existing file
            Dim filepath As String = FolderLocation & _nFileName
            File.Delete(filepath)
            'Then create new pdf file
            bytes = _oRpt_EnvelopeSeal.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)
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
    Private Sub _SendEmailNotif()
        Try
            Dim _nClass As New cDalSendEmail
            With _nClass
                ._pEmailTo = cSessionUser._pUserID
                ._pBody = "Sample email with Attachment"
                ._pSubject = "Test email with Attachment"
                ._pFooter = "PLease do not reply"
                Dim filepath As String = HttpContext.Current.Server.MapPath("~/Temp/")
                Dim _nFileName As String = cSessionLoader._pAccountNo & "_ApplicationForm.pdf"
                ._pAttachment.Add(filepath & _nFileName)
                If ._FnSendEmail() = False Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('Send Email Notification Failed');", True)
                End If
            End With
        Catch ex As Exception
            cDalLogEvent._pSubLogError(ex)
        End Try


    End Sub

    'For futther enhancement 20191219

    'Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim contentType As String = String.Empty
    '    contentType = "application/pdf"

    '    Dim dsData As DataTable = New DataTable()
    '    dsData = getReportData()
    '    Dim FileName As String = "Sample"
    '    Dim extension As String
    '    Dim encoding As String
    '    Dim mimeType As String
    '    Dim streams As String()
    '    Dim warnings As Warning()
    '    Dim report As LocalReport = New LocalReport()
    '    report.ReportPath = Server.MapPath("~/rptEmployee.rdlc")
    '    Dim rds As ReportDataSource = New ReportDataSource()
    '    rds.Name = "DataSet1"
    '    rds.Value = dsData
    '    report.DataSources.Add(rds)
    '    Dim mybytes As Byte() = report.Render(ddlFileFormat.SelectedItem.Text, Nothing, extension, encoding, mimeType, streams, warnings)

    '    Using fs As FileStream = File.Create(Server.MapPath("~/download/") & FileName)
    '        fs.Write(mybytes, 0, mybytes.Length)
    '    End Using

    '    Response.ClearHeaders()
    '    Response.ClearContent()
    '    Response.Buffer = True
    '    Response.Clear()
    '    Response.ContentType = contentType
    '    Response.AddHeader("Content-Disposition", "attachment; filename=" & FileName)
    '    Response.WriteFile(Server.MapPath("~/download/" & FileName))
    '    Response.Flush()
    '    Response.Close()
    '    Response.[End]()
    'End Sub

    'Private Function getReportData() As DataTable
    '    Dim dsData As DataSet = New DataSet()
    '    Dim sqlCon As SqlConnection = Nothing
    '    Dim sqlCmd As SqlDataAdapter = Nothing

    '    Try

    '        Using CSharpImpl.__Assign(sqlCon, New SqlConnection(ConfigurationManager.ConnectionStrings("connectionString").ConnectionString))
    '            sqlCmd = New SqlDataAdapter("USP_GETEmployeeDetails", sqlCon)
    '            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure
    '            sqlCon.Open()
    '            sqlCmd.Fill(dsData)
    '            sqlCon.Close()
    '        End Using

    '    Catch
    '        Throw
    '    End Try

    '    Return dsData.Tables(0)
    'End Function

End Class