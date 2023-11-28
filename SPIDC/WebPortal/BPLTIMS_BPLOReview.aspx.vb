Imports System.Web.Services
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WebForms
Imports SPIDC.Resources
Imports System.Reflection



Public Class BPLTIMS_BPLOReview
    Inherits System.Web.UI.Page

    Dim strCatCode, strCatDesc, strBusCode, strBusDesc As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Not IsPostBack Then
                If Session("Remarks") = "Reviewed/ For Assessment Billing" Then
                    _obuttonregulatoryEdit.Visible = False
                    _obuttonregulatorySave.Visible = False
                    _obuttonregulatoryCancel.Visible = False
                    ActionButtons.Visible = False
                    PreviewTOP.Visible = False
                    CommRem.Visible = False
                    _oGridViewBusLine.Columns(12).Visible = False
                    _oGridViewBusLine.Columns(13).Visible = False
                    _oGridViewBusLine.Columns(14).Visible = False
                    _obtnaddlineb.Visible = False
                    NatureBusiness.Visible = False
                End If

                cSessionLoader._pAccountNo = Request.QueryString("AccountNo")
                cSessionLoader._pCurrentYear = Request.QueryString("ForYear")
                cLoader_BPLTIMS._pIsProcessAll = False
                'Get_BusCode()


                _LoadInformation()
                _LoadImageAttachment()
                _BindRequirementsList()

                _BindBussinessDetails()  '@Added 20211102 louie
                '_PopulateAIF()
                'PassAIFvaluetoHiddenText()
                '_mSubvalueFormat()

                '_mSubLabelLocked()
                '   @Remarked 20211029
                '_LockRegulatoryInput()
                '_BindGridviewBusinessLine(_oGridViewBusLine)
                _GetBusinessNarative()

                If cInit_CBPReg._Fn_CheckIfCBPApplicant() = True Then
                    cInit_CBPReg._Get_CBP_BusinessInfo()
                    cLoader_BPLTIMS._pAPP_DATE = cInit_CBPReg._Fn_GetBUSMASTAppDate
                    cLoader_CBPAuthRep._pIsFromCBP = True
                Else
                    cLoader_CBPAuthRep._pIsFromCBP = False
                End If


                'If _FnIsLineProcessComplete() = True Then
                '    _ImgBtn_oButtonNotify.Disabled = False
                'Else
                '    _ImgBtn_oButtonNotify.Disabled = True
                'End If

                'cLoader_BPLTIMS._pFORYEAR = cSessionLoader._pCurrentYear
                'cLoader_BPLTIMS._pSTATCODE = "N"
                'If IfRecordExist("BUSEXTN", "WHERE Acctno = ''" & cSessionLoader._pAccountNo & "'' AND ForYear = ''" & cSessionLoader._pCurrentYear & "'' AND STATCODE = ''N''") = True Then
                '    _FnRemoveBusExtn()
                '    _FnInsertBusExtn()
                'End If

                '_GenerateTOP()



            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")
                If action = "PayNow" Then
                    _oPayNow("")
                    Response.Write("<script>sessionStorage.setItem('modaltrigger', 'true');</script>")

                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _oPayNow(ByVal _nCondition As String)
        Try

            Get_BusCode()

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _BindBussinessDetails()
        Try

            Dim _nGridView As New GridView

            _nGridView = _oGridViewBusinessDetailsNew
            _nGridView.DataSourceID = Nothing


            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog


            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT Acctno, ForYear, BusinessId, CatCode " & _
                            ",(SELECT CATDESC from [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.[CATCODE]  WHERE CatCode = BDN.CatCode) Category " & _
                            " , ProductsServices, Capital, Area, Vehicles, Capacity, Asset " & _
                            " FROM BusinessDetailsNew BDN "
                ._pCondition = " WHERE BDN.ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND BDN.FORYEAR = YEAR(GETDATE()) "

                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = True Then

                    Dim _nDataTable As New DataTable
                    _nDataTable = ._pDataTable

                    Try
                        '----------------------------------
                        If _nDataTable.HasErrors Then

                            'Griderr = True
                            '_mSubShowBlank()
                        End If



                        If _nDataTable.Rows.Count > 0 Then
                            _nGridView.DataSource = _nDataTable
                            _nGridView.DataBind()
                        Else
                            cEmptyGridview.pEmpyGridViewWithHeader(_nGridView, _nDataTable, "-- NO RECORD AVAILABLE --")
                        End If
                        '----------------------------------
                    Catch ex As Exception
                        'GridErr = True
                        '_mSubShowBlank()
                    End Try

                End If

            End With

        Catch ex As Exception

        End Try
    End Sub
    'Private Sub _oBtnSearchh(sender As Object, e As EventArgs) Handles _oBtnSearch.ServerClick
    '    Try


    '        Get_BusCode()


    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub _GetBusinessNarative()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT BusDescription from BusinessDescription "
                ._pCondition = " Where Acctno = ''" & cSessionLoader._pAccountNo & "'' and Foryear = Year(GETDATE())"
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    _otextBusinessNature.Text = _nDataTable.Rows("0").Item("BusDescription").ToString
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Get_BusCode()
        Try
            '----------------------------------
            cmbBusCode.DataSourceID = Nothing
            Dim _nClass As New cDalBusinessLine_Tomi
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSelCatCode = strCatCode
            _nClass._pGetBusLine = "BUSCODE"
            _nClass._pSubSelect("WHERE Description like '%" & _oTxtSearchBusLine.Text & "%'")

            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try

                cmbBusCode.Items.Clear()
                cmbBusCode.DataSource = _nDataSet
                cmbBusCode.DataTextField = "DESCRIPTION"
                cmbBusCode.DataValueField = "CATEGORY_BUSCODE"
                cmbBusCode.DataBind()

                'cmbBusCode.Items.Add()

                cmbBusCode.Items.Insert(0, New ListItem("Business Line", ""))

                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception
        End Try

    End Sub

    Private Sub _LoadImageAttachment()
        Try
            Dim _nClass As New cdalpicture
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pACCTNO = cSessionLoader._pAccountNo

                '=== Load Owner Picture
                ._pSubSelectowner()
                If ._pDataTable.Rows.Count <> 0 Then
                    If IsDBNull(._pDataTable.Rows(0).Item("O_FileType")) Then

                    Else
                        _oHyperLinkowner.Visible = True
                        _oHyperLinkowner.Enabled = True
                        _oHyperLinkowner.NavigateUrl = "viewimage/ViewImage.aspx?Id=" + cSessionLoader._pAccountNo + "&Settings=1&Switch=A"

                    End If
                Else
                    _oHyperLinkowner.Visible = False

                End If
                '================================
                '=== Load Establishment Picture
                ._pSubSelectestab()
                If ._pDataTable.Rows.Count <> 0 Then
                    If IsDBNull(._pDataTable.Rows(0).Item("E_FileType")) Then

                    Else
                        _oHyperLinkestablishment.Visible = True
                        _oHyperLinkestablishment.Enabled = True
                        _oHyperLinkestablishment.NavigateUrl = "viewimage/ViewImage.aspx?Id=" + cSessionLoader._pAccountNo + "&Settings=2&Switch=A"

                    End If
                Else
                    _oHyperLinkestablishment.Visible = False

                End If
                '================================
                '=== Load Map Location Picture
                ._pSubSelectmap()
                If ._pDataTable.Rows.Count <> 0 Then
                    If IsDBNull(._pDataTable.Rows(0).Item("M_FileType")) Then

                    Else
                        _oHyperLinkmaplocation.Visible = True
                        _oHyperLinkmaplocation.Enabled = True
                        _oHyperLinkmaplocation.NavigateUrl = "viewimage/ViewImage.aspx?Id=" + cSessionLoader._pAccountNo + "&Settings=3&Switch=A"

                    End If
                Else
                    _oHyperLinkmaplocation.Visible = False

                End If
                '================================

            End With

        Catch ex As Exception

        End Try

    End Sub

    Private Sub _BindRequirementsList()
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nGridView As New GridView
            _nGridView = _oGridviewRequirements
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalGetRequirements
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAcctNo = cSessionLoader._pAccountNo
                ._pStatus = "NEW"
                ._pLiveSvr = cSessionLoader._pBPLTAS_SvrName
                ._pLiveDb = cSessionLoader._pBPLTAS_DbName
                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

                Try
                    '----------------------------------
                    If _nDataTable.HasErrors Then
                        '  _mSubShowEmptyTraningCourseGridView()
                    End If

                    If _nDataTable.Rows.Count > 0 Then
                        _nGridView.DataSource = _nDataTable
                        _nGridView.DataBind()

                    Else

                        Dim dt As DataTable = New DataTable()
                        _nGridView.DataSource = dt
                        _nGridView.DataBind()


                    End If
                    '----------------------------------
                Catch ex As Exception
                    '_mSubShowEmptyTraningCourseGridView()
                End Try
            End With


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub OnRowDataBound(sender As Object, e As GridViewRowEventArgs)
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ReqCode As String = _oGridviewRequirements.DataKeys(e.Row.RowIndex).Value.ToString()
                Dim _nGridviewsub As GridView = TryCast(e.Row.FindControl("_oGridviewReqSubmitted"), GridView)
                _nGridviewsub.DataSource = GetData_SubmittedReq(ReqCode, e)
                _nGridviewsub.DataBind()

            End If
        Catch ex As Exception

        End Try

    End Sub

    <WebMethod()> _
    Public Shared Function GetData_SubmittedReq(ReqCode As String, e As GridViewRowEventArgs) As DetailsClass()
        Try
            Dim _nGridviewsub As GridView = CType(e.Row.FindControl("_oGridviewReqSubmitted"), GridView)
            Dim Detail As List(Of DetailsClass) = New List(Of DetailsClass)()
            Dim SelectString As String = "SELECT * FROM BP_SubmittedReq where AccountNo = '" & cSessionLoader._pAccountNo & "' and ReqCode ='" & ReqCode & "' "
            Dim cn As SqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim cmd As SqlCommand = New SqlCommand(SelectString, cn)
            'cn.Open()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            Dim dtGetData As DataTable = New DataTable()
            da.Fill(dtGetData)

            For Each dtRow As DataRow In dtGetData.Rows
                Dim DataObj As DetailsClass = New DetailsClass()
                DataObj.AcctNo = dtRow("AccountNo").ToString()
                DataObj.ReqCode = dtRow("ReqCode").ToString()
                DataObj.ImageID = dtRow("ImagesID").ToString()
                DataObj.ForYear = dtRow("ForYear").ToString()
                DataObj.Name = dtRow("Name").ToString()
                Detail.Add(DataObj)

            Next

            Return Detail.ToArray()
        Catch ex As Exception

        End Try

    End Function

    Public Class DetailsClass
        Public Property AcctNo As String
        Public Property ReqCode As String
        Public Property ImageID As String
        Public Property ForYear As String
        Public Property Name As String
    End Class

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class

    Private Sub UpdateBusMastRemarks(_nRemarks As String)
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pSelect = "UPDATE BUSMAST Set REMARKS = ''" & _nRemarks & "''"
                ._pCondition = " Where (ACCTNO = ''" & cSessionLoader._pAccountNo & "'' or PBN = ''" & cSessionLoader._pAccountNo & "'') and EMAILADDR = ''" & cLoader_BPLTIMS._pEMAILADDR & "''"
                '._pCondition = " Where AcctNo = ''" & cSessionLoader._pAccountNo & "''"
                ._pAction = "UPDATE"
                ._pExec(_nSuccessfull, _nErrMsg)
            End With

        Catch ex As Exception

        End Try


    End Sub

    Private Sub UpdateBusMastForPayment()
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pSelect = "UPDATE BUSMAST Set IsForPayment = 1 "
                ._pCondition = " Where (ACCTNO = ''" & cSessionLoader._pAccountNo & "'' or PBN = ''" & cSessionLoader._pAccountNo & "'') and EMAILADDR = ''" & cLoader_BPLTIMS._pEMAILADDR & "''"
                '._pCondition = " Where AcctNo = ''" & cSessionLoader._pAccountNo & "''"
                ._pAction = "UPDATE"
                ._pExec(_nSuccessfull, _nErrMsg)
            End With

        Catch ex As Exception

        End Try


    End Sub

    Private Sub _LogData(ByVal _nAsk As String, ByRef _nInfo As String)
        Try

            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = " INSERT INTO BusinessLineDataLog " & _
                            " ( " & _
                            " ACCTNO, BUSCODE, FORYEAR, DATA, INFO " & _
                            " ) " & _
                            " VALUES " & _
                            " ( ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pBUS_CODE & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " ,''" & _nAsk & "'' " & _
                            " ,''" & _nInfo & "'') "

                ._pExec(_nSuccessful, _nErrMsg)
            End With

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ShowPopup()
        Dim title As String = ""
        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" & title & "');", True)
    End Sub

    Protected Sub HidePopup()
        Try
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "HidePopup();", True)
        Catch ex As Exception

        End Try

    End Sub


    Public Sub _GenerateTOP()
        Try
            ClassPageSession_pBilling._pSubSessionClear()

            ClassPageSession_pBilling._pUserId = cLoader_BPLTIMS._pEMAILADDR
            ClassPageSession_pBilling._pReferenceNumber = ""
            ClassPageSession_pBilling._pBusinessAccountNumber = cSessionLoader._pAccountNo
            ClassPageSession_pBilling._pQuarterToPay = "4"
            ClassPageSession_pBilling._pTransactionType = "REGULAR BILLING" '_oTextBoxTransactionType.Text

            Dim _nResult As Boolean

            Dim _nClass As New ClassInterop_VB6_BPLTAS
            With _nClass
                ._pSubGenerateTOP(_nResult)

                Dim _nTopTotal As String = Format(_FnGet_TotalDue(), "standard")

                _oTxtboxTOPTotalAmount.Value = _nTopTotal
                _oTxtTotalAmountDue.Value = _nTopTotal

            End With

            If _nResult = True Then
                '_PopulateTOPGridview(_oGridViewTOP)
                _GenerateReport_TOP()

            End If

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub

    Public Sub _PopulateTOPGridview(_nGridview As GridView)
        Try
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nClass._pBPAccountNumber = ClassPageSession_pBilling._pBusinessAccountNumber
            _nClass._pSubSelectBillingReport()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            If _nDataTable.HasErrors Then
                Return
            End If

            If _nDataTable.Rows.Count > 0 Then
                _nGridview.DataSource = _nDataTable
                _nGridview.DataBind()
            Else
                cEmptyGridview.pEmpyGridViewWithHeader(_nGridview, _nDataTable, "No record available")
            End If


        Catch ex As Exception

        End Try

    End Sub


    Public Function _FnGet_TotalDue() As String
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
                ._pSelect = "SELECT SUM(CAST(Totdue as money)) AS TOTAL_DUE FROM [" & _nOAIMS_Svr & "].[" & _nOAIMS_Db & "].dbo.BILLINGTEMP WHERE Acctno = ''" & ClassPageSession_pBilling._pBusinessAccountNumber & "''"
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("TOTAL_DUE").ToString
                Else
                    Return "0"
                End If

            End With

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Function

    Public Sub _GenerateReport_TOP()
        Try
            cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR
            ' The Report\

            Dim tst As String
            cSessionLGUProfile._pGetLGUProfile(tst)

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nClass._pBPAccountNumber = ClassPageSession_pBilling._pBusinessAccountNumber
            _nClass._pSubSelectBillingReport()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable



            If _nDataTable.HasErrors Then
                Return
            End If

            If _nDataTable.Rows.Count <= 0 Then
                _oRpt_Top.Visible = False
                _oButtonPrintTOP.Attributes.CssStyle.Add("display", "none")
                'Return

            Else
                _oRpt_Top.Visible = True
                _oButtonPrintTOP.Attributes.CssStyle.Add("display", "block")
            End If

            _oRpt_Top.Reset()
            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo



            For Each extension As RenderingExtension In _oRpt_Top.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format

            _oRpt_Top.ShowExportControls = False

            _oRpt_Top.LocalReport.ReportPath = "WebPortal\Report\BillingTOP.rdlc" '_gResxRdlc.pBillingTOP
            _oRpt_Top.LocalReport.EnableExternalImages = True

            _oRpt_Top.LocalReport.DataSources.Clear()
            Dim _nReportDataSource As New ReportDataSource
            _nReportDataSource.Name = "dsReportBilling" ' The Name of the dataset in the RDLC Designer.
            _nReportDataSource.Value = _nDataTable
            _oRpt_Top.LocalReport.DataSources.Add(_nReportDataSource)


            Dim paramList As New List(Of ReportParameter)

            Dim _nClass2 As New cDalPayment
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass2._pBPAccountNumber = ClassPageSession_pBilling._pBusinessAccountNumber
            _nClass2._pSubGetParameter2()



            paramList.Add(New ReportParameter("RptPrmHeader1", "Republic of the Philippines"))
            paramList.Add(New ReportParameter("RptPrmHeader2", cSessionLGUProfile._pLGU_Name))
            If cSessionLGUProfile._pLGU_Name.ToUpper.Contains("CITY") = True Then
                paramList.Add(New ReportParameter("RptPrmHeader3", "Office of the City Treasurer"))
            Else
                paramList.Add(New ReportParameter("RptPrmHeader3", "Office of the Municipal Treasurer"))
            End If


            paramList.Add(New ReportParameter("RptPrmHeader4", "Tax Order of Payment"))
            paramList.Add(New ReportParameter("RptPrmAuthor", "Systems & Plan Integrator & Development Corporation"))

            '  paramList.Add(New ReportParameter("RptReferenceNumber", _nClass2._pReferenceNumber))
            paramList.Add(New ReportParameter("RptReferenceDate", _nClass2._pReferenceDate))
            paramList.Add(New ReportParameter("RptPrmInfoBusinessAccountNumber", ClassPageSession_pBilling._pBusinessAccountNumber))
            paramList.Add(New ReportParameter("RptPrmInfoOwner", _nClass2._pOwner))
            paramList.Add(New ReportParameter("RptPrmInfoStatus", _nClass2._pStatcode))
            paramList.Add(New ReportParameter("RptPrmInfoOwnership", _nClass2._pOwndesc))
            paramList.Add(New ReportParameter("RptPrmInfoCommercialName", _nClass2._pCommercialName))
            paramList.Add(New ReportParameter("RptPrmInfoCommercialAddress", _nClass2._pCommercialAddress))
            paramList.Add(New ReportParameter("RptPrmInfoTotalAmountDue", ClassPageSession_pBilling._pTotalAmountDue))

            ClassPageSession_pBilling._pCommercialName = _nClass2._pCommercialName

            Dim _nCharge As Double : Dim _nInterest As Double
            GetPenaltySetup(_nCharge, _nInterest)

            If _nClass2._pStatcode.ToUpper = "NEW" Then
                paramList.Add(New ReportParameter("RptMsg", "This TOP expires at the end of the month of this quarter. Your amount due will be imposed " & _nCharge & "% surcharge + " & _nInterest & "% penalty interest/month on the amount due + surcharge if not paid on time."))
            ElseIf _nClass2._pStatcode.ToUpper = "RENEWAL" Then
                'paramList.Add(New ReportParameter("RptMsg", "This TOP expires on the 20th day of billing date. Your amount due will be imposed " & _nCharge & "% surcharge + " & _nInterest & "% penalty interest/month on the amount due + surcharge if not paid on time."))
            End If
            _oRpt_Top.LocalReport.SetParameters(paramList)


            '_ServiceFees()

            _oRpt_Top.AsyncRendering = True

            _oRpt_Top.LocalReport.Refresh()


            ' _oHyperLinkTOP.NavigateUrl = "~/pages/business/BPLTAS/NewBP/pViewImage.aspx?Settings=7&FileNo=" + ClassPageSession_pBilling._pFileNo
            '----------------------------------
        Catch ex As Exception
            _oButtonPrintTOP.Attributes.CssStyle.Add("display", "none")
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try
    End Sub

    Public Sub _ServiceFees()
        Try

            Dim _nCF As Double = 5.0
            Dim _DBPFee As Double = (ClassPageSession_pBilling._pTotalAmountDue + _nCF) * 0.01
            Dim _nGCashFee As Double
            If ClassPageSession_pBilling._pTotalAmountDue <= 999 Then
                _nGCashFee = 25.0
            Else
                _nGCashFee = 35.0
            End If

            Dim paramList As New List(Of ReportParameter)
            paramList.Add(New ReportParameter("Param_LGUTotalDue", ClassPageSession_pBilling._pTotalAmountDue))
            paramList.Add(New ReportParameter("Param_CF", 5.0))
            paramList.Add(New ReportParameter("Param_DBPFee", _DBPFee))
            paramList.Add(New ReportParameter("Param_GCash", _nGCashFee))
            _oRpt_Top.LocalReport.SetParameters(paramList)


        Catch ex As Exception

        End Try
    End Sub



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

    Protected Sub _oButtonPrintTOP_Click(sender As Object, e As EventArgs) Handles _
       _oButtonPrintTOP.ServerClick

        Dim warnings As Warning()
        Dim streamIds As String()
        Dim contentType As String
        Dim encoding As String
        Dim extension As String

        'Export the RDLC Report to Byte Array.
        Dim bytes As Byte() = _oRpt_Top.LocalReport.Render("PDF", Nothing, contentType, encoding, extension, streamIds, warnings)
        'Download the RDLC Report in Word, Excel, PDF and Image formats.

        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = contentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=TOP" & "_" & cSessionLoader._pAccountNo & ".pdf")
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()
    End Sub

    Public Function _FnGenerateReport_ApplicationForm() As Boolean
        'Try
        _FnGenerateReport_ApplicationForm = False
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
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('Unexpected Error while generating Appication Form');", True)
                    Return False
                End If

                If _nDataTable.Rows.Count <= 0 Then
                    _oRpt_Top.Enabled = False
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('No record found to Generate Appication Form');", True)
                    Return False
                Else
                    _oRpt_Top.Enabled = True

                    _oRpt_Top.Reset()

                    '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
                    Dim info As FieldInfo

                    For Each extension As RenderingExtension In _oRpt_Top.LocalReport.ListRenderingExtensions
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

                    _oRpt_Top.LocalReport.ReportPath = _gResxRdlc.pReportApplicationInfo
                    _oRpt_Top.LocalReport.EnableExternalImages = True

                    _oRpt_Top.LocalReport.DataSources.Clear()
                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "ds_Application"
                    _nReportDataSource.Value = _nDataTable
                    _oRpt_Top.LocalReport.DataSources.Add(_nReportDataSource)

                    Dim _TotalEmp As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_TOTAL") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_TOTAL"))
                    Dim _NoEmpLGU As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_LGU") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_LGU"))
                    Dim paramList As New List(Of ReportParameter)


                    paramList.Add(New ReportParameter("Status", "N"))
                    paramList.Add(New ReportParameter("Emp_Total", _TotalEmp))
                    paramList.Add(New ReportParameter("Emp_LGU", _NoEmpLGU))
                    paramList.Add(New ReportParameter("Param_LGU_Name", cSessionLGUProfile._pLGU_Name))
                    _oRpt_Top.LocalReport.SetParameters(paramList)

                    _oRpt_Top.AsyncRendering = True
                    _oRpt_Top.LocalReport.Refresh()
                    _oRpt_Top.Enabled = True

                    Return True
                End If

            End With
            ' _RenderToPDF("ApplicationForm") ' <<<< Render Report to PDF and Save to temporary folder
            '_SendEmailNotif()
            'Catch ex As Exception
            '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
            'End Try
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Function


    Private Function _FnGetTotalCapitalization() As String
        Try

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT SUM(CAPITAL) as ToTalCapital FROM BUSLINE "
                ._pCondition = "  where Acctno = ''" & cSessionLoader._pAccountNo & "'' and FORYEAR = ''" & cSessionLoader._pCurrentYear & "'' "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDatable As New DataTable
                _nDatable = ._pDataTable

                If _nDatable.Rows.Count > 0 Then
                    Return _nDatable.Rows(0).Item("ToTalCapital").ToString
                Else
                    Return "0.00"
                End If

            End With


        Catch ex As Exception

        End Try
    End Function

    Public Function _FnGenerateReport_ApplicationFormDITC() As Boolean
        'Try
        _FnGenerateReport_ApplicationFormDITC = False
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

                ._pExec2(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.HasErrors Then
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('Unexpected Error while generating Appication Form');", True)
                    Return False
                End If

                If _nDataTable.Rows.Count <= 0 Then
                    _oRpt_Top.Enabled = False
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('No record found to Generate Appication Form');", True)
                    Return False
                Else
                    _oRpt_Top.Enabled = True

                    _oRpt_Top.Reset()

                    '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
                    Dim info As FieldInfo

                    For Each extension As RenderingExtension In _oRpt_Top.LocalReport.ListRenderingExtensions
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

                    _oRpt_Top.LocalReport.ReportPath = _gResxRdlc.pAppFormNewDITC
                    _oRpt_Top.LocalReport.EnableExternalImages = True

                    _oRpt_Top.LocalReport.DataSources.Clear()
                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "dsBusInfoDITC"
                    _nReportDataSource.Value = _nDataTable
                    _oRpt_Top.LocalReport.DataSources.Add(_nReportDataSource)

                    Dim _NoEmpMale As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_M") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_M"))
                    Dim _NoEmpFemale As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_F") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_F"))
                    Dim _NoEmpLGU As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_LGU") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_LGU"))
                    Dim paramList As New List(Of ReportParameter)

                    Dim _nDTI As String = IIf(_nDataTable.Rows(0).Item("DTI_NO").ToString = Nothing, "", _nDataTable.Rows(0).Item("DTI_NO").ToString)
                    Dim _nSEC As String = IIf(_nDataTable.Rows(0).Item("SEC_NO").ToString = Nothing, "", "/" & _nDataTable.Rows(0).Item("SEC_NO").ToString)
                    Dim _nCDA As String = IIf(_nDataTable.Rows(0).Item("CDA_NO").ToString = Nothing, "", "/" & _nDataTable.Rows(0).Item("CDA_NO").ToString)

                    Dim _DTI_SEC_CDE As String = _nDTI & _nSEC & _nCDA

                    Dim _nCPNo As String = IIf(_nDataTable.Rows(0).Item("CPNO").ToString = Nothing, "", _nDataTable.Rows(0).Item("CPNO").ToString)
                    Dim _nCPNo2 As String = IIf(_nDataTable.Rows(0).Item("CPNO2").ToString = Nothing, "", "/" & _nDataTable.Rows(0).Item("CPNO2").ToString)
                    Dim _nCPNo3 As String = IIf(_nDataTable.Rows(0).Item("CPNO3").ToString = Nothing, "", "/" & _nDataTable.Rows(0).Item("CPNO").ToString)

                    Dim _nMobileNo As String = _nCPNo & _nCPNo2 & _nCPNo3

                    'paramList.Add(New ReportParameter("Status", "N"))

                    'paramList.Add(New ReportParameter("Param_NoEmpMale", _NoEmpMale))
                    'paramList.Add(New ReportParameter("Param_NoEmpFemale", _NoEmpFemale))
                    'paramList.Add(New ReportParameter("Param_NoEmpLGU", _NoEmpLGU))


                    'paramList.Add(New ReportParameter("Param_DateOfReceipt", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_TrackingNo", _nDataTable.Rows(0).Item("ACCTNO").ToString))
                    'paramList.Add(New ReportParameter("Param_BusinessID", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_OwnershipType", _nDataTable.Rows(0).Item("OWNCODE").ToString))
                    paramList.Add(New ReportParameter("Param_OwnershipTypeGender", _nDataTable.Rows(0).Item("PRES_GENDER").ToString))
                    paramList.Add(New ReportParameter("Param_DTI_SEC_CDA", _DTI_SEC_CDE))
                    paramList.Add(New ReportParameter("Param_TIN", _nDataTable.Rows(0).Item("TIN_NO").ToString))
                    paramList.Add(New ReportParameter("Param_BusinessName", _nDataTable.Rows(0).Item("COMMNAME").ToString))
                    paramList.Add(New ReportParameter("Param_TradeName", _nDataTable.Rows(0).Item("COMMNAME").ToString))

                    'paramList.Add(New ReportParameter("Param_MainBldgNo", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_MainBldgName", _nDataTable.Rows(0).Item("COMMADDR").ToString))
                    'paramList.Add(New ReportParameter("Param_MainLotNo", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_MainBlkNo", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_MainBrgy", _nDataTable.Rows(0).Item("BRGYDESC").ToString))
                    paramList.Add(New ReportParameter("Param_MainStreet", _nDataTable.Rows(0).Item("STRTDESC").ToString))
                    'paramList.Add(New ReportParameter("Param_MainSubdivision", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_MainCityMunicipality", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_MainProvince", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_MainZipCode", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))

                    paramList.Add(New ReportParameter("Param_TelephoneNo", _nDataTable.Rows(0).Item("CONTTEL").ToString))
                    paramList.Add(New ReportParameter("Param_MobileNo", _nMobileNo))
                    paramList.Add(New ReportParameter("Param_EmailAddress", _nDataTable.Rows(0).Item("EMAILADDR").ToString))

                    Dim _nOwnCode As String = _nDataTable.Rows(0).Item("OWNCODE").ToString


                    If _nOwnCode = "S" Then
                        paramList.Add(New ReportParameter("Param_OwnerSurname", _nDataTable.Rows(0).Item("LAST_NAME").ToString))
                        paramList.Add(New ReportParameter("Param_OwnerGivenName", _nDataTable.Rows(0).Item("FIRST_NAME").ToString))
                        paramList.Add(New ReportParameter("Param_OwnerMiddleName", _nDataTable.Rows(0).Item("MIDDLE_NAME").ToString))
                        ' paramList.Add(New ReportParameter("Param_OwnerSuffix", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    Else
                        paramList.Add(New ReportParameter("Param_PresSurname", _nDataTable.Rows(0).Item("LAST_NAME").ToString))
                        paramList.Add(New ReportParameter("Param_PresGivenName", _nDataTable.Rows(0).Item("FIRST_NAME").ToString))
                        paramList.Add(New ReportParameter("Param_PresMiddleName", _nDataTable.Rows(0).Item("MIDDLE_NAME").ToString))
                        ' paramList.Add(New ReportParameter("Param_PresSuffix", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    End If

                    paramList.Add(New ReportParameter("Param_Citizenship", _nDataTable.Rows(0).Item("CTZNCODE").ToString))
                    'paramList.Add(New ReportParameter("Param_BusinessAreaSqm", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_TotalFlrAreaSqm", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_NoEmpMale", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_NoEmpFemale", _nDataTable.Rows(0).Item("NO_EMP_F").ToString))
                    paramList.Add(New ReportParameter("Param_NoEmpLGU", _nDataTable.Rows(0).Item("NO_EMP_LGU").ToString))
                    'paramList.Add(New ReportParameter("Param_NoVanTruck", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_NoMotorcycle", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))

                    'paramList.Add(New ReportParameter("Param_BusLocBldgNo", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_BusLocBldgName", _nDataTable.Rows(0).Item("COMMADDR").ToString))
                    'paramList.Add(New ReportParameter("Param_BusLocLotN", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_BusLocBlkNo", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_BusLocBrgy", _nDataTable.Rows(0).Item("BRGYDESC").ToString))
                    paramList.Add(New ReportParameter("Param_BusLocStreet", _nDataTable.Rows(0).Item("STRTDESC").ToString))
                    'paramList.Add(New ReportParameter("Param_BusLocSubdivision", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_BusLocCityMunicipality", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_BusLocProvince", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_BusLocZipCode", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))

                    paramList.Add(New ReportParameter("Param_Owned", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_TaxDecNo", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    paramList.Add(New ReportParameter("Param_PropIDNo", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))

                    paramList.Add(New ReportParameter("Param_TotalCapitalization", _FnGetTotalCapitalization))
                    paramList.Add(New ReportParameter("Param_TaxIncentives", _nDataTable.Rows(0).Item("TAX_INDIC").ToString))
                    'paramList.Add(New ReportParameter("Param_BusinessActivity", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                    'paramList.Add(New ReportParameter("Param_BusinessActivitySpecify", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))

                    ' paramList.Add(New ReportParameter("Param_LGU_Name", cSessionLGUProfile._pLGU_Name))
                    _oRpt_Top.LocalReport.SetParameters(paramList)

                    _oRpt_Top.AsyncRendering = True
                    _oRpt_Top.LocalReport.Refresh()
                    _oRpt_Top.Enabled = True

                    Return True
                End If

            End With
            ' _RenderToPDF("ApplicationForm") ' <<<< Render Report to PDF and Save to temporary folder
            '_SendEmailNotif()
            'Catch ex As Exception
            '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
            'End Try
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Function
    Protected Sub ExportAppForm(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If _FnGenerateReport_ApplicationFormDITC() = True Then
                Dim warnings As Warning()
                Dim streamIds As String()
                Dim contentType As String
                Dim encoding As String
                Dim extension As String

                'Export the RDLC Report to Byte Array.
                Dim bytes As Byte() = _oRpt_Top.LocalReport.Render("PDF", Nothing, contentType, encoding, extension, streamIds, warnings)
                'Download the RDLC Report in Word, Excel, PDF and Image formats.

                Response.Clear()
                Response.Buffer = True
                Response.Charset = ""
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = contentType
                Response.AppendHeader("Content-Disposition", "attachment; filename=ApplicationForm" & "_" & cSessionLoader._pAccountNo & ".pdf")
                Response.BinaryWrite(bytes)
                Response.Flush()
                Response.End()

            End If

        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    'Protected Sub ExportAppForm(ByVal sender As Object, ByVal e As EventArgs)
    '    Try
    '        If _FnGenerateReport_ApplicationForm() = True Then
    '            Dim warnings As Warning()
    '            Dim streamIds As String()
    '            Dim contentType As String
    '            Dim encoding As String
    '            Dim extension As String

    '            'Export the RDLC Report to Byte Array.
    '            Dim bytes As Byte() = _oRpt_Top.LocalReport.Render("PDF", Nothing, contentType, encoding, extension, streamIds, warnings)
    '            'Download the RDLC Report in Word, Excel, PDF and Image formats.

    '            Response.Clear()
    '            Response.Buffer = True
    '            Response.Charset = ""
    '            Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '            Response.ContentType = contentType
    '            Response.AppendHeader("Content-Disposition", "attachment; filename=ApplicationForm" & "_" & cSessionLoader._pAccountNo & ".pdf")
    '            Response.BinaryWrite(bytes)
    '            Response.Flush()
    '            Response.End()

    '        End If

    '    Catch ex As Exception
    '        cEventLog._pSubLogError(ex)
    '    End Try
    'End Sub



End Class