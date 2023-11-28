Imports SPIDC.Resources
Imports Microsoft.Reporting.WebForms

Public Class LGU_GeneralCollectionReportOLD
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            _mSubDataLoadSPIDCPAY()
            _mSubDataLoadPostedSPIDCPay()
            _mSubDataLoadLandBank()
            _mSubDataLoadPostedLandBank()
            _mSubDataLoadDBP()
            _mSubDataLoadPostedDBP()
            _mSubDataLoadGetCountTotalSPIDCPAY()
            _mSubDataLoadGetCountTotalPostedSPIDCPay()
            _mSubDataLoadGetCountTotalLandBank()
            _mSubDataLoadGetCountTotalPostedLandBank()
            _mSubDataLoadGetCountTotalDBP()
            _mSubDataLoadGetCountTotalPostedDBP()
            _mSubDataLoadGetCountTotalAll()
        Else

            Dim Action As String = Request("__EVENTTARGET")


            If Action = "UpdateCheck" Then
                UpdateReferenceNumber()


            End If
        End If
    End Sub
    Protected Sub OnRowCancelEdit(sender As Object, e As GridViewCancelEditEventArgs)
        _oGridViewSPIDCPay.EditIndex = -1
        _mSubDataLoadSPIDCPAY()
    End Sub
    Protected Sub OnRowEditing(sender As Object, e As GridViewEditEventArgs)

        _oGridViewSPIDCPay.EditIndex = e.NewEditIndex
        _mSubDataLoadSPIDCPAY()
    End Sub
    Protected Sub OnRowUpdating(sender As Object, e As GridViewUpdateEventArgs)
        'Get the GridView Row.
        Dim row As GridViewRow = _oGridViewSPIDCPay.Rows(e.RowIndex)
        Dim xReferenceNumbers As String
        Dim xCheckStatus As Boolean
        Dim _nGridView As GridView = DirectCast(sender, GridView)




        If _nGridView.Rows.Count <= 0 Then
            Return
        End If

        _nGridView.SelectedIndex = e.RowIndex

        If _nGridView.SelectedRow IsNot Nothing Then
            xCheckStatus = DirectCast(_nGridView.SelectedRow.FindControl("Checkbox"), CheckBox).Checked
            xReferenceNumbers = DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTransactionNumber"), Label).Text

        End If
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pTransactionNumber = xReferenceNumbers
        _nclass._pCheckBoxValue = IIf(xCheckStatus = "true", 1, 0)
        _nclass._pSubUpdateReferenceNumber()


        _oGridViewSPIDCPay.EditIndex = -1
        _mSubDataLoadSPIDCPAY()
    End Sub

    Private Sub UpdateReferenceNumber()
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pTransactionNumber = actid.Value
        _nclass._pCheckBoxValue = ButtonValue.Value
        _nclass._pSubUpdateReferenceNumber()

    End Sub


    'Sub _mSubDataLoadSPIDCPAY()
    '    Dim _nGridView As New GridView
    '    _nGridView = _oGridViewSPIDCPay
    '    _nGridView.DataSourceID = Nothing
    '    Dim _nclass As New cDalGeneralCollection
    '    _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
    '    _nclass._pSubSelectSPIDCPayTransactions()
    '    _nGridView.DataSource = _nclass._mDataTable
    '    _nGridView.DataBind()
    'End Sub
    Sub _mSubDataLoadSPIDCPAY()
        Dim _nGridView As New GridView
        _nGridView = _oGridViewSPIDCPay
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectSPIDCPayTransactions()
        cSessionUser._pStrDt = _nclass._pstrdt
        _nGridView.DataSource = _nclass._mDataTable

        _nGridView.DataBind()
    End Sub
    Sub _mSubDataLoadPostedSPIDCPay()
        Dim _nGridView As New GridView
        _nGridView = _oGridViewPostedSPIDCPay
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectPostedSPIDCPayTransactions()
        _nGridView.DataSource = _nclass._mDataTable
        _nGridView.DataBind()
    End Sub
    Sub _mSubDataLoadLandBank()
        Dim _nGridView As New GridView
        _nGridView = _oGridViewUnpaidLandBank
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectLandBankTransactions()
        cSessionUser._pStrDt = _nclass._pstrdt
        _nGridView.DataSource = _nclass._mDataTable

        _nGridView.DataBind()
    End Sub
    Sub _mSubDataLoadPostedLandBank()
        Dim _nGridView As New GridView
        _nGridView = _oGridViewPostedLandBank
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectPostedLandBankTransactions()
        _nGridView.DataSource = _nclass._mDataTable
        _nGridView.DataBind()
    End Sub
    Sub _mSubDataLoadDBP()
        Dim _nGridView As New GridView
        _nGridView = _oGridViewUnpaidDBP
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectDBPTransactions()
        cSessionUser._pStrDt = _nclass._pstrdt
        _nGridView.DataSource = _nclass._mDataTable

        _nGridView.DataBind()
    End Sub
    Sub _mSubDataLoadPostedDBP()
        Dim _nGridView As New GridView
        _nGridView = _oGridViewPostedDBP
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubSelectPostedDBPTransactions()
        _nGridView.DataSource = _nclass._mDataTable
        _nGridView.DataBind()
    End Sub

    Sub _mSubDataLoadGetCountTotalSPIDCPAY()
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetCountTotalSPIDCPAY()
        _oLblCountSPIDCPAY.Text = _nclass._pCountSPIDCPAY
        _oLblTotalSPIDCPAY.Text = _nclass._pTotalSPIDCPAY

    End Sub
    Sub _mSubDataLoadGetCountTotalPostedSPIDCPay()
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetCountTotalPostedSPIDCPay()
        _oLblCountPostedSPIDCPay.Text = _nclass._pCountPostedSPIDCPAY
        _oLblTotalPostedSPIDCPay.Text = _nclass._pTotalPostedSPIDCPay

    End Sub
    Sub _mSubDataLoadGetCountTotalLandBank()
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetCountTotalLandBank()
        _oLblCountLandBank.Text = _nclass._pCountLandBank
        _oLblTotalLandBank.Text = _nclass._pTotalLandBank

    End Sub
    Sub _mSubDataLoadGetCountTotalPostedLandBank()
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetCountTotalPostedLandBank()
        _oLblCountPostedLandBank.Text = _nclass._pCountPostedLandBank
        _oLblTotalPostedLandBank.Text = _nclass._pTotalPostedLandBank

    End Sub
    Sub _mSubDataLoadGetCountTotalDBP()
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetCountTotalDBP()
        _oLblCountUnpaidDBP.Text = _nclass._pCountDBP
        _oLblTotalUnpaidDBP.Text = _nclass._pTotalDBP

    End Sub
    Sub _mSubDataLoadGetCountTotalPostedDBP()
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetCountTotalPostedDBP()
        _oLblCountPostedDBP.Text = _nclass._pCountPostedDBP
        _oLblTotalPostedDBP.Text = _nclass._pTotalPostedDBP

    End Sub
    Sub _mSubDataLoadGetCountTotalAll()
        Dim _nclass As New cDalGeneralCollection
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetCountTotalAll()
        _oLBLCOUNTALL.Text = _nclass._pCountALL
        _oLBLGrandTotal.Text = _nclass._pTotalAll

    End Sub

    Protected Sub _oBtnPrint_Click(sender As Object, e As EventArgs) Handles _oBtnPrint.Click
        _mSubPrintOR()
    End Sub


    Sub _mSubPrintOR()

        Dim _nclass As New cDalGeneralCollection

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

        _nclass._pSubSelectAll()
        Dim _nDataTable As New DataTable
        Dim NotProcess As Boolean
        _nDataTable = _nclass._pDataTable

        '_nClass = Nothing


        If _nDataTable.HasErrors Then
            Return
        End If

        If _nDataTable.Rows.Count <= 0 Then
            _oMSRV.Visible = False
            'Return
            NotProcess = True
        Else

            _oMSRV.Visible = True
        End If

        _oMSRV.Reset()


        _oMSRV.LocalReport.ReportPath = _gResxRdlc.pPrintGeneralCollection


        _oMSRV.LocalReport.EnableExternalImages = True

        _oMSRV.LocalReport.DataSources.Clear()
        Dim _nReportDataSource As New ReportDataSource
        _nReportDataSource.Name = "DataSet1" ' The Name of the dataset in the RDLC Designer.
        _nReportDataSource.Value = _nDataTable
        _oMSRV.LocalReport.DataSources.Add(_nReportDataSource)

        Dim paramList As New List(Of ReportParameter)
        'paramList.Add(New ReportParameter("Name", _lblFIRST.Text & " " & _lblMI.Text & " " & _lblLAST.Text))
        _oMSRV.LocalReport.SetParameters(paramList)


        _oMSRV.AsyncRendering = True

        _oMSRV.LocalReport.Refresh()
        _oMSRV.Visible = True


    End Sub



    Private Sub _obtnProceed_ServerClick(sender As Object, e As EventArgs) Handles _obtnProceed.ServerClick

        Dim multitdn As String
        Dim svr As String
        Dim dtb As String


        multitdn = cSessionUser._pStrDt & Request.Form("txarea")


        Dim _nclass As New cDalGeneralCollection

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pstrdt = multitdn
        _nclass._pEmail = cSessionUser._pUserID
        _nclass._pSubUpdateReferenceNumber()

        Response.Redirect("LGUMainPage.aspx")
        '----------------------------------
    End Sub

    Private Sub _obtnProceedLBP_ServerClick(sender As Object, e As EventArgs) Handles _oBtnProceedLBP.ServerClick

        Dim multitdn As String
        Dim svr As String
        Dim dtb As String


        multitdn = cSessionUser._pStrDt & Request.Form("txarea")


        Dim _nclass As New cDalGeneralCollection

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pstrdt = multitdn
        _nclass._pEmail = cSessionUser._pUserID
        _nclass._pSubUpdateReferenceNumber()

        Response.Redirect("LGUMainPage.aspx")
        '----------------------------------
    End Sub

End Class