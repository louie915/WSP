Public Class NewBP_Payment
    Inherits System.Web.UI.Page
    Public Shared ACCTNO As String
    Dim AppID As String
    Dim Email As String
    Dim Status As String
    Dim FileData1, FileData2, FileData3, FileData4, FileData5, FileData6 As Byte()
    Dim Fee1, Fee2, Fee3, Fee4, Fee5, Fee6, Fee7, Fee8 As String
    Dim Sum_TotAmtDue As Double
    Dim Sum_TotPenDue As Double
    Dim Sum_TotTaxDue As Double
    Dim Sum_TotETC As Double


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubGetAppidEmail(ACCTNO, AppID, Email)

        If Not IsPostBack Then
            Try
                get_Info(AppID, Email)
                _nClass.Application_ID = AppID
                _nClass._pSubGetACCTNO(ACCTNO)
                td_AcctNo.InnerText = ACCTNO
                _LoadBusinessLine(_oGridViewBusLine)
                loadGrid_TOP()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub loaddata(ByVal Office As String)
        Dim _nClass As New cDalNewBP
        Dim AmtDue As String = Nothing
        Dim Clearance_No As String = Nothing
        Dim Status As String = Nothing

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectRegulatory_Fees2(Request.QueryString("Application_ID"), Office, AmtDue, Clearance_No, Status)



    End Sub
    Public Sub loadGrid_TOP()
        Try
            Dim CTC_AMOUNT As Double
            Dim CTC_REMARK As String
            Dim _GrandTotal As Double

            Dim _nClass1 As New cDalNewBP
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass1.Application_ID = AppID
            _nClass1._pSubGetACCTNO(ACCTNO)

            Dim _nClass2 As New cDalNewBP
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass2._pSubSelectTOP(ACCTNO, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, 0)
            GridViewTOP.DataSource = _nClass2._mDataTable
            GridViewTOP.DataBind()

            Dim _nclassX As New cDalGetModules
            _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclassX._pSubGetAvailableModules("IncludeCTC") = True Then
                _nClass2._pSubGetCTC(ACCTNO, CTC_AMOUNT, CTC_REMARK)
            Else
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

    Sub get_Info(ByVal AppID As String, ByVal Email As String)
        Try
            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubcheckIfValidInfo( _
           AppID _
          , Email _
          , td_OwnershipType.InnerText _
          , td_DtiSecCda.InnerText _
          , td_TIN.InnerText _
          , td_BusinessName.InnerText _
          , td_MainOfficeAddress.InnerText _
          , td_TelNo.InnerText _
          , td_MobileNo.InnerText _
          , td_OwnerName.InnerText _
          , td_Nationality.InnerText _
          , td_Area.InnerText _
          , td_FloorArea.InnerText _
          , td_MaleEmpNo.InnerText _
          , td_FemaleEmpNo.InnerText _
          , td_ResidingEmpNo.InnerText _
          , td_VanTruckNo.InnerText _
          , td_MotorNo.InnerText _
          , td_BusinessLocationAddress.InnerText _
          , td_Capital.InnerText _
          , NatureHTML.InnerHtml _
          , FileData1 _
          , td_FileName1.InnerText _
          , td_FileType1.InnerText _
          , td_FileStatus1.InnerText _
          , td_FileRemarks1.InnerText _
          , FileData2 _
          , td_FileName2.InnerText _
          , td_FileType2.InnerText _
          , td_FileStatus2.InnerText _
          , td_FileRemarks2.InnerText _
          , FileData3 _
          , td_FileName3.InnerText _
          , td_FileType3.InnerText _
          , td_FileStatus3.InnerText _
          , td_FileRemarks3.InnerText _
          , FileData4 _
          , td_FileName4.InnerText _
          , td_FileType4.InnerText _
          , td_FileStatus4.InnerText _
          , td_FileRemarks4.InnerText _
          , FileData5 _
          , td_FileName5.InnerText _
          , td_FileType5.InnerText _
          , td_FileStatus5.InnerText _
          , td_FileRemarks5.InnerText _
          , FileData6 _
          , td_FileName6.InnerText _
          , td_FileType6.InnerText _
          , td_FileStatus6.InnerText _
          , td_FileRemarks6.InnerText _
          , Status)
            td_ApplicationNo.InnerText = AppID
            td_EmailAddress.InnerText = Email

            td_FileData1.InnerText = "data:" & td_FileType1.InnerText & ";base64," & Convert.ToBase64String(FileData1)
            td_FileData2.InnerText = "data:" & td_FileType2.InnerText & ";base64," & Convert.ToBase64String(FileData2)
            td_FileData3.InnerText = "data:" & td_FileType3.InnerText & ";base64," & Convert.ToBase64String(FileData3)
            td_FileData4.InnerText = "data:" & td_FileType4.InnerText & ";base64," & Convert.ToBase64String(FileData4)
            td_FileData5.InnerText = "data:" & td_FileType5.InnerText & ";base64," & Convert.ToBase64String(FileData5)
            td_FileData6.InnerText = "data:" & td_FileType6.InnerText & ";base64," & Convert.ToBase64String(FileData6)

        Catch ex As Exception

        End Try
       
    End Sub

    Private Sub _LoadBusinessLine(_nGridview As GridView)
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
            Dim application_ID As String = AppID

            cSessionLoader._pBPLTAS_SvrName = _nLiveServerName
            cSessionLoader._pBPLTAS_DbName = _nLiveDatabaseName

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT " & _
                        "Bus_code, (Select [description] from " & _
                        " [" & cSessionLoader._pBPLTAS_SvrName & "].[" & cSessionLoader._pBPLTAS_DbName & "].[dbo].[BUSCODE]" & _
                        " where bus_code = BUSLINE.BUS_CODE) as LINE, Capital, Area, Asset, Product,Bustax,Mayors,Garbage,Sanitary,Fire,foryear" & _
                        " from " & _
                        " [" & cSessionLoader._pBPLTAS_SvrName & "].[" & cSessionLoader._pBPLTAS_DbName & "].[dbo].[BUSLINE]"



                ._pCondition = " where acctno = (select acctno from [BUSMAST] where PBN=''" & application_ID & "'')"

                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

                Try
                    '----------------------------------
                    If _nDataTable.HasErrors Then

                    End If

                    If _nDataTable.Rows.Count > 0 Then
                        _nGridview.DataSource = _nDataTable
                        _nGridview.DataBind()
                    Else
                        cEmptyGridview.pEmpyGridViewWithHeader(_nGridview, _nDataTable, "No record available")
                    End If
                    '----------------------------------
                Catch ex As Exception

                End Try
            End With

        Catch ex As Exception

        End Try
    End Sub

    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

    Private Sub btn_TOP_ServerClick(sender As Object, e As EventArgs) Handles btn_TOP.ServerClick
        Dim _nClass1 As New cDalNewBP
        _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass1.Application_ID = AppID
        _nClass1._pSubGetACCTNO(ACCTNO)
        ReportViewer.NEWBP_TOP_ACCTNO = ACCTNO
        ReportViewer.NEWBP_TOP_Email = Email
        Response.Redirect("Report/ReportViewer.aspx?ReportType=NEW_BP_TOP")
    End Sub

    Private Sub btnPayment_ServerClick(sender As Object, e As EventArgs) Handles btnPayment.ServerClick
        Dim _nClass As New cDalNewBP
        Dim Sum_TotAmtDue As Double
        Dim CTC_AMOUNT As Double
        Dim CTC_REMARK As String
        Dim _GrandTotal As String
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass.Application_ID = AppID
        _nClass._pSubGetACCTNO(acctno)

      

      

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubSelectTOP(ACCTNO, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, 0)
        _nClass._pSubGetCTC(ACCTNO, CTC_AMOUNT, CTC_REMARK)

        Dim _nclassX As New cDalGetModules
        _nclassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        If _nclassX._pSubGetAvailableModules("IncludeCTC") <> True Then
            CTC_AMOUNT = 0
        End If

        cSessionLoader._pType = "New Business Permit" 'unique
        cSessionLoader._pService = "BP" 'CTC      
        cSessionLoader._pAccountNo = ACCTNO
        _GrandTotal = CTC_AMOUNT + Sum_TotAmtDue
        cSessionLoader._pTotalAmountDue = Format(_GrandTotal.ToString, "STANDARD")
        _nClass._pSubGetPeriodCovered(acctno, cSessionLoader._pPeriodCovered, cSessionLoader._pPayMode, cSessionLoader._pFORYEAR)



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
        ' PayNow2.URL_Origin = HttpContext.Current.Request.Url.AbsoluteUri
        Response.Redirect("PayNow2.aspx")





    End Sub

    Private Sub btnAppForm_ServerClick(sender As Object, e As EventArgs) Handles btnAppForm.ServerClick

        Dim _nClass1 As New cDalNewBP
        _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass1.Application_ID = AppID
        _nClass1._pSubGetACCTNO(ACCTNO)
        ReportViewer.NEWBP_APPFORM_ACCTNO = ACCTNO
        ReportViewer.NEWBP_APPFORM_APPID = AppID
        ReportViewer.NEWBP_APPFORM_Email = Email

        Response.Redirect("Report/ReportViewer.aspx?ReportType=NEW_BP_APPFORM")
    End Sub
End Class