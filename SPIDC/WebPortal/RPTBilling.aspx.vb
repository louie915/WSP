Imports System.Data
Imports System.Drawing
Imports Microsoft.Reporting.WebForms
Imports SPIDC.Resources
Imports System.Reflection

Imports RPTIMS_DLL

Public Class RPTBilling
    Inherits System.Web.UI.Page

    Dim total As Double = 0
    Dim qry As Integer = 0
    Dim NoofcountTDN As Long
    Dim _nMode As String
    Dim _nSvrDateValue As String
    Dim checkedItems
    Dim usertmp As String
    Dim isMultiple As Boolean = False
    Dim tdn As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Me.IsPostBack Then
        '    Dim dt As New DataTable()
        '    dt.Columns.AddRange(New DataColumn() {New DataColumn("Id", GetType(Integer)), _
        '                                           New DataColumn("Name", GetType(String)), _
        '                                           New DataColumn("Country", GetType(String))})
        '    dt.Rows.Add(1, "John Hammond", "United States")
        '    _oGVRpt.DataSource = dt
        '    _oGVRpt.DataBind()
        'End If

        Dim _nClass2 As New cHardwareInformation
        Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
        'Select Case _nMachineName
        '    Case "MANDAUEWEBSVR"
        '        _radYear.Enabled = False
        'End Select



        Try
            '----------------------------------
            If Not IsPostBack Then

                TXTTRAPERROR.Value = "FORM START"
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                End If




          
                '_oTextBoxYear.Text = Now.Year
                ' Get_RPTAccounts()
                '_oTextBoxBillingDate.Text = Format(Now, "MM/dd/yyyy")
                TXTTRAPERROR.Value = "FORM START CREATING TEMP"
                _mCreate_temp_per_Email()
                TXTTRAPERROR.Value = "FORM START THROWING SESSION"
                Dim tdn As String = IIf(cSessionLoader._pTDN.Contains("select") = False, cSessionLoader._pTDN.ToString.Replace("'", ""), cSessionLoader._pTDN)
                cSessionLoader._pTDN = tdn

                TXTTRAPERROR.Value = "FORM START INSERTING TO TEMP"
                _mInsertBrHlp(cSessionLoader._pTDN)
                TXTTRAPERROR.Value = "FORM START GETTING INFO"
                getinfo(cSessionLoader._pTDN)
                RadioButton4.Checked = True
                _oRadioPickup.Checked = True


                _mGetYear()
                Dim qtr As Integer
                qtr = cSessionUser._pQtr

                If qtr = 2 Then
                    RadioButton1.Enabled = False
                ElseIf qtr = 3 Then
                    RadioButton1.Enabled = False
                    RadioButton2.Enabled = False
                ElseIf qtr = 4 Then
                    RadioButton1.Enabled = False
                    RadioButton2.Enabled = False
                    RadioButton3.Enabled = False

                End If

                Dim _nClassPayment As New cDalPayment
                _nClassPayment._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                If _nClassPayment.hasPayment_RPT(cSessionLoader._pTDN, cSessionUser._pQtr, cSessionUser._pYr) Then
                    _obtnPrintStatement.Style.Add("display", "none")
                    _obtnPayment.Style.Add("display", "none")
                    div_Notice.Style.Add("display", "")
                    div_Notice.InnerHtml =
                        "  <br />" &
                        " <i>Selected Year and Quarter is already Paid.</i> " &
                        " <br />"
                Else
                    div_Notice.Style.Add("display", "none")
                    do_process(cSessionLoader._pTDN)
                End If

              



                '_oRadio4thQ.Checked = True
                '_radYear

            Else
                ' do_process(tdn)
                'Dim action As String = Request("__EVENTTARGET")
                ''response.Redirect("//Login.aspx")

                'If action = "RPTINFORMATION" Then
                '    cSessionUser._pTDN = Request("__EVENTARGUMENT")

                'ElseIf action = "RPTTRANS" Then
                '    cSessionUser._pTDN = Request("__EVENTARGUMENT")
                'ElseIf action = "RPTBILLING" Then
                '    cSessionUser._pTDN = Request("__EVENTARGUMENT")
                '    Response.Redirect("RPTBilling.aspx")
                'End If

                '   
            End If
            '----------------------------------
        Catch ex As Exception
            TXTTRAPERROR.Value = ex.Message

        End Try
    End Sub

    Private Sub getinfo(TDS As String)
        Dim _nClass As New cDalPDSRPTAS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
        _nClass._pTDN = TDS
        _nClass._pGetinfo()
        PayNow2.OwnerName = _nClass._pOWNER
        PayNow2.OwnerAddress = _nClass._pLOCATION
        If InStr(cSessionLoader._pTDN, "select") = 0 Then
            _oLblTDN.Text = Replace(TDS, "'", "")
            _oLblPIN.Text = _nClass._pPIN
            _oLblKind.Text = _nClass._pKIND
            _oLblOwner.Text = _nClass._pOWNER
            _oLblLocation.Text = _nClass._pLOCATION
            isMultiple = False
        Else
            isMultiple = True
            _oLblTDN.Text = "Multiple TDN"
            _oLblPIN.Text = ""
            _oLblKind.Text = ""
            _oLblOwner.Text = ""
            _oLblLocation.Text = ""
        End If

    End Sub
    Private Sub _mGetYear()

        Dim _nClass As New cDalPDSRPTAS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T


        _nClass._pSubGetYear()
        cSessionUser._pQtr = _nClass._pQtr
        cSessionUser._pYr = _nClass._pYr
        _radYear.DataSource = Nothing


        _radYear.DataSourceID = Nothing




        Dim _nDataSet As New DataSet()
        _nDataSet = _nClass._pDataSet

        Try
            '----------------------------------
            If _nDataSet.HasErrors Then
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End If

            _radYear.DataSource = _nDataSet
            _radYear.DataTextField = "Yr"
            _radYear.DataValueField = "Yr"
            _radYear.DataBind()

            '_radYear.Items.Insert(0, New ListItem("Select Street", ""))

            '----------------------------------
        Catch ex As Exception
            'Shoiw Blank Table
            '  _mSubShowBlank()
        End Try
        '----------------------------------

    End Sub
    Private Sub _mCreate_temp_per_Email()
        usertmp = cSessionUser._pUserID.Replace(".", "")
        usertmp = usertmp.Replace("-", "")
        ' usertmp = usertmp.Replace("-", "")
        Dim _nClass As New cDalPDSRPTAS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
        _nClass._pEmail = usertmp
        _nClass._pSubCreateTableBrHlp()
    End Sub
    Private Sub _mInsertBrHlp(tdn)
        usertmp = cSessionUser._pUserID.Replace(".", "")
        usertmp = usertmp.Replace("-", "")
        'usertmp = cSessionUser._pUserID.Replace("-", "")
        Dim _nClass As New cDalPDSRPTAS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
        _nClass._pEmail = usertmp
        _nClass._pTDN = tdn
        _nClass._pSubInsertBrHlp()
    End Sub
    Private Sub Get_RPTAccounts(Optional ByRef GrandTotal As Double = 0)
        Try
            '----------------------------------
            Dim _nClassMachine As New cHardwareInformation


            Dim _nGridView As New GridView
            _nGridView = _oGridViewRPT
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalPDSRPTAS
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "RPTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names

            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            _nClass._pTDN = cSessionLoader._pTDN.ToString.Replace("'", "")
            _nClass._pSubSelectAssessmentNo()
            'uncomment once done and tested na ang multi tdn
            'If InStr(cSessionLoader._pTDN.Replace("'", ""), "select") = 0 Then
            _nClass._pShortpayment()
            'End If
            _nClass._pSubSelectAssessment()
            cSessionLoader._pAssessNo = _nClass._pAssessNo
            '====================================================
            ' COMPUTE WEB ADDITIONAL FEES

            Dim AmountDue As Double = IIf(_nClass._pGrandTotal = Nothing, 0, _nClass._pGrandTotal)
            Dim TatolDueWithAddFees As Double

            TatolDueWithAddFees = AmountDue + cAdditionalFees.GetComputerFee()
            _nClass._pGrandTotal = TatolDueWithAddFees.ToString

            _oDivAddFee.InnerHtml = cAdditionalFees.Str_ComputerFee

            '_oLabelComputerFee.Text = FormatCurrency(cAdditionalFees.TotalAdditionalFee()).Replace("$", "")

            '====================================================

            Dim amt As Double = FormatNumber(_nClass._pGrandTotal, 2)

            GrandTotal = FormatCurrency(amt).Replace("$", "")
            _oLabelTotalAmountDue.Text = FormatCurrency(amt).Replace("$", "")
            _oLabelOrigTotalAmountDue.Text = FormatCurrency(amt).Replace("$", "")


            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                    TXTTRAPERROR.Value = "_nDataTable.HasErrors"
                End If

                If _oRadioDelivered.Checked Then
                    _oLabelTotalAmountDue.Text = _oLabelOrigTotalAmountDue.Text + 250
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()

                    ' cmb_Brgy.DataSource = _mDatatableStrt
                    ' cmb_Brgy.DataTextField = "BRGYDESC"
                    ' cmb_Brgy.DataValueField = "DISTCODE_BRGYCODE"
                    ' cmb_Brgy.DataBind()

                    '  _nGridView.FooterRow.Cells(0).ColumnSpan = 3
                    '_nGridView.FooterRow.Cells(0).Font.Bold = True
                    '  _nGridView.FooterRow.Cells(0).Text.data = "T O T A L    D U E :"
                    '  _nGridView.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Center

                    _obtnPrintStatement.Style.Add("display", "")
                    _obtnPayment.Style.Add("display", "")
                Else
                    _nGridView.DataSource = Nothing
                    _nGridView.DataBind()
                    snackbar("green", "Selected Year & Quarter is Already Paid.")
                    _obtnPrintStatement.Style.Add("display", "none")
                    _obtnPayment.Style.Add("display", "none")
                End If

                'If _nClassMachine._pMachineName = "BIZPORTAL" Then
                '    _obtnPayment.Style.Add("display", "none")
                '    div_Notice.Style.Add("display", "")
                '    div_Notice.InnerHtml =
                '  "  <br />" &
                '  "  <h3>" &
                '  " You can pay your Real Property Tax Assessment at :<br /> " &
                '  " Silay City Hall, City Treasurer's Office<br>" &
                '  " </h3>" &
                '  " <br />"
                'Else
                '    div_Notice.Style.Add("display", "none")
                'End If


                '----------------------------------
            Catch ex As Exception
                TXTTRAPERROR.Value = ex.Message
                snackbar("red", ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try
    End Sub

    Sub do_process(tdn)
        Dim getdate As Date

        Try
            TXTTRAPERROR.Value += "Initializing DLL"
            Dim _nclass As New cDalPDSRPTAS
            Dim _nclass2 As New cDalGetDate
            _nclass2._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS

            TXTTRAPERROR.Value += "Initializing DLL 2.0"

            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            TXTTRAPERROR.Value += "Initializing DLL 2.1"
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
            TXTTRAPERROR.Value += "Initializing DLL 2.2"
            _nclass._pSubGetSpecificRecord_getid()
            TXTTRAPERROR.Value += "Initializing DLL 2.3"
            _msubGetServerDate()
            TXTTRAPERROR.Value += "Initializing DLL 2.4"
            _nclass._mctr_no = cPageSession_Billing_EntryView._pOrigSrvDateValue






            ' _mSubLoadBrHlp()
            TXTTRAPERROR.Value += "Initializing DLL 3.0"
            Dim cls_rptas As New clsRPT

            'set TOIMS CONNECTION
            cls_rptas.TOIMS_Server = cGlobalConnections._pSqlCxn_TOIMS.DataSource
            cls_rptas.TOIMS_xDataBase = cGlobalConnections._pSqlCxn_TOIMS.Database
            cls_rptas.TOIMS_xUID = _mSubUIPW("UI", "TOIMS")
            cls_rptas.TOIMS_xPW = _mSubUIPWWEB("PW")
            'SET OAIMS CONNECTION
            cls_rptas.RPTASOAIMS_xDataBase = cGlobalConnections._pSqlCxn_OAIMS.Database

            TXTTRAPERROR.Value += "Initializing SERVER"
            cls_rptas.RPTAS_SERVER = cGlobalConnections._pSqlCxn_RPTAS.DataSource
            TXTTRAPERROR.Value += "Initializing SERVER1"
            cls_rptas.RPTASWEB_SERVER = cGlobalConnections._pSqlCxn_RPTIMS.DataSource
            TXTTRAPERROR.Value += "Initializing SERVER2"

            cls_rptas.RPTAS_xDataBase = cGlobalConnections._pSqlCxn_RPTAS.Database
            TXTTRAPERROR.Value += "Initializing SERVER3"
            cls_rptas.RPTASWEB_xDataBase = cGlobalConnections._pSqlCxn_RPTIMS.Database
            TXTTRAPERROR.Value += "Initializing SERVER4"

            cls_rptas.RPTAS_xUID = _mSubUIPW("UI", "RPTAS")
            TXTTRAPERROR.Value += "Initializing SERVER5"
            cls_rptas.RPTASWEB_xUID = _mSubUIPWWEB("UI")
            TXTTRAPERROR.Value += "Initializing SERVER6"

            cls_rptas.RPTAS_xPW = _mSubUIPW("PW", "RPTAS")
            TXTTRAPERROR.Value += "Initializing SERVER7"
            cls_rptas.RPTASWEB_xPW = _mSubUIPWWEB("PW")
            TXTTRAPERROR.Value += "Initializing SERVER8"

            cls_rptas.Region_TMP = _mSubREGION()
            TXTTRAPERROR.Value += "Initializing SERVER9"
            ' TXTTRAPERROR.Value = "Initializing USER"
            usertmp = cSessionUser._pUserID.Replace(".", "")
            usertmp = usertmp.Replace("-", "")
            'usertmp = cSessionUser._pUserID.Replace("-", "")
            TXTTRAPERROR.Value += "Initializing SERVER10"
            cls_rptas.User_TMP = usertmp 'remove the "." 
            TXTTRAPERROR.Value += "Initializing SERVER11"
            cls_rptas.MultiTDN = 1
            TXTTRAPERROR.Value += "Initializing SERVER12"
            cls_rptas.Tdn = tdn
            '  cls_rptas.Tdn = tdn

            ' TXTTRAPERROR.Value = "Initializing DATE"
            '  TXTTRAPERROR.Value += "Initializing DATE" + ";CDate :" & CDate(_nclass2._GetDate("MM/dd/yyyy"))
            ' getdate = CDate(Format(_nclass2._GetDate("MM/dd/yyyy"), "MM/dd/yyyy")) 'CDate(_nclass2._GetDate("MM/dd/yyyy"))
            ' _nclass2._GetDate("MM/dd/yyyy")

            TXTTRAPERROR.Value += "Initializing DATE:" & CDate(_nclass2._GetDate_MMddyyyy())
            cls_rptas.bill_date = CDate(_nclass2._GetDate_MMddyyyy())

            'CDate(_nclass2._GetDate("MM/dd/yyyy"))
            '_nclass2._GetDate("MM/dd/yyyy") 
            'Format(_nclass2._pSubGetDateTime(), "MM/dd/yyyy") 
            'Format(Date.Now, "MM/dd/yyyy") 
            ' Format(_nclass._pSubGetDateTime(), "MM/dd/yyyy")  
            '_nclass._pSubGetDateTime()  
            'CDate(Format(_nclass._pSubGetDateTime(), "MM/dd/yyyy")) 


            cls_rptas.SvrDateValue = cPageSession_Billing_EntryView._pOrigSrvDateValue
            'cls_rptas.Quater_set = _oTextBoxAdvSetQuater.Text
            'IIf(gpub_IsBackEncoding, "tmp0002", "tmp0001") & gSysUser & "_" & mvar_Time
            If RadioButton1.Checked = True Then
                cls_rptas.Quater_set = "1"
            End If
            If RadioButton2.Checked = True Then
                cls_rptas.Quater_set = "2"
            End If
            If RadioButton3.Checked = True Then
                cls_rptas.Quater_set = "3"
            End If
            If RadioButton4.Checked = True Then
                cls_rptas.Quater_set = "4"
            End If

            cls_rptas.RPTAS_ForYear = _radYear.Text
            'Trim(Str(((Month(Now) - 1) \ 3) + 1))
            cls_rptas.SvrDateValue = _nclass._mctr_no
            '  _oTextBoxTDN.Text = "6.2" & tdn
            'gang dito lang ayaw magloadform
            ' TXTTRAPERROR.Value = "Initializing DATA"
            TXTTRAPERROR.Value += "Initializing SERVER13"
            cls_rptas.LoadForm()

            '  cls_rptas.toimsposting(assessmentno)

            '  _oTextBoxTDN.Text = "6.3" & tdn
            '   _mSubDataBindSearch(True)
            '_oButtonTOP.Enabled = True
            '_oButtonProcess.Enabled = False
            '_oButtonSet.Enabled = False
            '  Response.Redirect("/VS2014.RPTIMS/RPTReport.aspx?ReportType=TOP")
            ' TXTTRAPERROR.Value = "Initializing GRID"
            ' _mSubDataPrint()
            TXTTRAPERROR.Value += "Initializing SERVER14"

            Get_RPTAccounts(cSessionLoader._pTotalAmountDue)

        Catch ex As Exception
            'MsgBox("")
            TXTTRAPERROR.Value += ex.ToString
        End Try

        Response.Write("<script>" & _
                 "if (document.readyState !== ""complete"") {   " & _
                     "document.querySelector( " & _
                       """#loading"").style.visibility = ""visible""; " & _
                " } else { " & _
                    " document.querySelector( " & _
                     " ""#loading"").style.display = ""none""; " & _
                 "}" & _
             "</script>")


    End Sub


    Private Sub _mSubDataPrint()
        Try
            ' The Report

            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
            usertmp = cSessionUser._pUserID.Replace(".", "")
            usertmp = usertmp.Replace("-", "")
            'usertmp = cSessionUser._pUserID.Replace("-", "")
            '_nClass._pTDN =
            _nClass._pUseTableTmpBill = "tmp0001" & usertmp & "_" & cPageSession_Billing_EntryView._pOrigSrvDateValue
            _nClass._pEmail = usertmp
            _nClass._pSubPrint()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable



            If _nDataTable.HasErrors Then
                Return
            End If

            If _nDataTable.Rows.Count <= 0 Then
                ' _oMSRV.Enabled = False
                'Return

            Else
                '_oMSRV.Enabled = True
            End If
            '_oMSRV.Reset()
            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            'Dim info As FieldInfo

            'For Each extension As RenderingExtension In _oMSRV.LocalReport.ListRenderingExtensions
            '    If extension.Name <> "PDF" Then
            '        info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
            '        info.SetValue(extension, False)
            '    End If
            'Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format


            '_oMSRV.LocalReport.ReportPath = _gResxRdlc._pReportBilling
            '_oMSRV.LocalReport.EnableExternalImages = True

            '_oMSRV.LocalReport.DataSources.Clear()

            'Dim _nReportDataSource As New ReportDataSource
            '_nReportDataSource.Name = "DataSet1" ' The Name of the dataset in the RDLC Designer.
            '_nReportDataSource.Value = _nDataTable
            '_oMSRV.LocalReport.DataSources.Add(_nReportDataSource)


            'Dim paramList As New List(Of ReportParameter)
            'paramList.Add(New ReportParameter("ReportParameter1", "Republika ng Pilipinas"))
            'paramList.Add(New ReportParameter("ReportParameter2", "Republika ng Pilipinas"))
            'paramList.Add(New ReportParameter("ReportParameter3", "Republika ng Pilipinas"))
            'paramList.Add(New ReportParameter("ReportParameter4", "Republika ng Pilipinas"))
            'paramList.Add(New ReportParameter("ReportParameter5", "Republika ng Pilipinas"))
            'paramList.Add(New ReportParameter("ReportParameter6", "Republika ng Pilipinas"))
            'paramList.Add(New ReportParameter("ReportParameter7", "Republika ng Pilipinas"))
            'paramList.Add(New ReportParameter("ReportParameter8", "Republika ng Pilipinas"))
            'paramList.Add(New ReportParameter("ReportParameter9", "Republika ng Pilipinas"))
            '_oMSRV.LocalReport.SetParameters(paramList)


            '_oMSRV.AsyncRendering = True

            '_oMSRV.LocalReport.Refresh()
            '_oMSRV.Enabled = True
            'renderedBytes = _oMSRV.LocalReport.Render("Image", "<DeviceInfo><OutputFormat>JPG</OutputFormat></DeviceInfo>")

            '---------------------------------- 
            '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS


            '_nClass._pimgfile = renderedBytes
            ' _nClass._pSubInsertimage()
            '_oMSRV.Visible = True
        Catch ex As Exception
            '  _oTextBoxTDN.Text = ex.Message
        End Try
    End Sub

#Region "FUNCTIONS"
    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub


    Function _mSubUIPW(cndtn As String, ConDB As String) As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR

                ._pSubSelectUIPW(ConDB)

                If cndtn = "UI" Then
                    Return ._pdbUI
                ElseIf cndtn = "PW" Then
                    Return ._pdbPW
                Else
                    Return Nothing
                End If

            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Private Sub _msubGetServerDate()
        Dim _nclass As New cDalPDSRPTAS
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
        ''_nclass._pSubGetSpecificRecord_getid().
        _nclass._pSubGetServerDate()

        Dim _nDataTable As New DataTable
        _nDataTable = _nclass._pDataTable

        Try
            '----------------------------------
            If _nDataTable.Rows.Count > 0 Then

                _nclass._mctr_no = _nDataTable.Rows("0").Item("ServerDateTime").ToString
                cPageSession_Billing_EntryView._pOrigSrvDateValue = _nclass._mctr_no
            Else
                ' _mSubShowBlankApplicationProcess()

            End If


            '_mSubGetApplicationAddress()
            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub
    Function _mSubUIPWWEB(cndtn As String) As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR

                ._pSubSelectUIPWWEB()

                If cndtn = "UI" Then
                    Return ._pdbUI
                ElseIf cndtn = "PW" Then
                    Return ._pdbPW
                Else
                    Return Nothing
                End If

            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Function _mSubREGION() As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS

                ._pSubREGION()

                Return ._pRegion
            End With

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
#End Region



    'Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
    '    'Dim tdn As String = cSessionUser._pTDN
    '    '  _mInsertBrHlp(tdn)
    '    do_process(cSessionUser._pTDN)
    'End Sub

    Private Sub _obtnPrintStatement_Click(sender As Object, e As EventArgs) Handles _obtnPrintStatement.Click

        ' Response.Redirect("RPTReport.aspx?ReportType=TOP", False)
        If _oRadioDelivered.Checked Then
            cSessionLoader._pDEL = "DELIVERY"
        Else
            cSessionLoader._pDEL = "PICKUP"
        End If

        'Response.Write("<script>window.open ('RPTReport.aspx?ReportType=TOP','_blank');</script>")
        Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=RPTSOA','_blank');</script>")


    End Sub

    Private Sub _obtnPayment_Click(sender As Object, e As EventArgs) Handles _obtnPayment.Click
        'cSessionLoader._pTDN = ""
        ' If _oRadioDelivered.Checked Then
        '     cSessionLoader._pDEL = "DELIVERY"
        '     cSessionLoader._pTotalAmountDue = total ' _oLabelOrigTotalAmountDue.Text + 250
        ' Else
        cSessionLoader._pDEL = "PICKUP"
        ' cSessionLoader._pTotalAmountDue = total '_oLabelOrigTotalAmountDue.Text
        '  End If

        cSessionLoader._pType = "RPTPAYMENT"
        cSessionLoader._pService = "RPT"

        Dim _nClassGetDate As New cDalGetDate
        _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

        'If isMultiple = True Then
        '    PayNow2.ACCTNO = "Various" ' cSessionLoader._pAssessNo 'cSessionLoader._pTDN.Replace("'", Nothing) & " / " & cSessionLoader._pAssessNo
        'Else
        '    PayNow2.ACCTNO = cSessionLoader._pTDN.Replace("'", Nothing) ' & " / " & cSessionLoader._pAssessNo
        'End If

        PayNow2.ACCTNO = cSessionLoader._pAssessNo
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
        PayNow2.TransactionType = "RPT"
        PayNow2.URL_Origin = HttpContext.Current.Request.Url.AbsoluteUri
        Response.Redirect("PayNow2.aspx")
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged, RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
        If RadioButton1.Checked = True Then
            cSessionUser._pQtr = "1"
        End If
        If RadioButton2.Checked = True Then
            cSessionUser._pQtr = "2"
        End If
        If RadioButton3.Checked = True Then
            cSessionUser._pQtr = "3"
        End If
        If RadioButton4.Checked = True Then
            cSessionUser._pQtr = "4"
        End If

        Dim _nClassPayment As New cDalPayment
        _nClassPayment._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        If _nClassPayment.hasPayment_RPT(cSessionLoader._pTDN, cSessionUser._pQtr, _radYear.SelectedValue) Then

            _obtnPrintStatement.Style.Add("display", "none")
            _obtnPayment.Style.Add("display", "none")
            div_Notice.Style.Add("display", "")
            div_Notice.InnerHtml =
                "  <br />" &
                " <i>Selected Year and Quarter is already Paid.</i> " &
                " <br />"
        Else
            div_Notice.Style.Add("display", "none")
            do_process(cSessionLoader._pTDN)
        End If

        'If _oRadioPickup.Checked = False Then
        '    _oLabelTotalAmountDue.Text = _oLabelTotalAmountDue.Text + 250
        'End If
    End Sub

    Private Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _radYear.SelectedIndexChanged
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = True

        Dim yr As Integer

        Dim qtr As Integer
        qtr = cSessionUser._pQtr
        yr = cSessionUser._pYr
        If yr = _radYear.SelectedValue Then
            If qtr = 2 Then
                RadioButton1.Enabled = False

            ElseIf qtr = 3 Then
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False

            ElseIf qtr = 4 Then
                RadioButton1.Enabled = False
                RadioButton2.Enabled = False
                RadioButton3.Enabled = False

            End If
        Else
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            RadioButton3.Enabled = True
        End If



        'cSessionUser._pYr
        Dim _nClassPayment As New cDalPayment
        _nClassPayment._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        If _nClassPayment.hasPayment_RPT(cSessionLoader._pTDN, cSessionUser._pQtr, _radYear.SelectedValue) Then

            _obtnPrintStatement.Style.Add("display", "none")
            _obtnPayment.Style.Add("display", "none")
            div_Notice.Style.Add("display", "")
            div_Notice.InnerHtml =
                "  <br />" &
                " <i>Selected Year and Quarter is already Paid.</i> " &
                " <br />"
        Else
            div_Notice.Style.Add("display", "none")
            do_process(cSessionLoader._pTDN)
        End If


        'If _oRadioPickup.Checked = False Then
        '    _oLabelTotalAmountDue.Text = _oLabelTotalAmountDue.Text + 250
        'End If

    End Sub

    Function hasPayment(ByVal tdn As String, ByVal qtr As Integer, ByVal yr As Integer) As Boolean
        Try
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

        Catch ex As Exception

        End Try
    End Function

End Class