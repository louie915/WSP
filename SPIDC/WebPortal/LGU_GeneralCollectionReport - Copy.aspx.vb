Imports SPIDC.Resources
Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient

Public Class LGU_GeneralCollectionReport
    Inherits System.Web.UI.Page

    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Public Shared _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                load_Gateway()
                load_Type()
                load_Status()
                load_datefromto()
            End If
        Catch ex As Exception

        End Try
       
    End Sub


    Protected Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            load_Gridview(cmbGateWay.Value, txtDateFrom.Value, txtDateTo.Value, cmbType.Value, cmbStatus.Value)
            gv_paymentList.PageIndex = e.NewPageIndex
            gv_paymentList.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Sub load_Gridview(ByVal Gateway As String, ByVal dateFrom As Date, ByVal dateTo As Date, ByVal Type As String, ByVal Status As String, Optional ByRef qry As String = Nothing)
        Try
            _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing

            _nQuery = " WITH temporaryTable  as " &
                      " (SELECT AssessNo, COUNT(distinct tdn)ctr FROM [" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.Assess_FrmNewBilling_A  GROUP BY AssessNo)" &
                      " select distinct OPR.TransDate,OPR.txnrefno,OPR.GATEWAYREFNO,OPR.EMAILADDR,OPR.PaymentChannel,OPR.Type,OPR.acctno,OPR.Statusid,OPR.totamount," &
                      " CASE WHEN ctr > 1 THEN 'Various' " &
                      " WHEN ctr = 1 THEN (select distinct tdn from [" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.Assess_FrmNewBilling_A where AssessNo=TT.AssessNo)	" &
                      " END	TDN" &
                      " from temporaryTable TT " &
                      " right join OnlinePaymentRefno OPR on  OPR.ACCTNO=TT.AssessNo" &
                      " where OPR.TransDate >= '" & dateFrom & "' and format(OPR.transdate,'MM/dd/yyyy') <= '" & dateTo & "' "



            If Gateway = "ALL" Then
                _nWhere = ""
            Else
                _nWhere += " and OPR.PaymentChannel='" & Gateway & "'"
            End If

            If Type = "ALL" Then
            Else
                _nWhere += " and OPR.Type='" & Type & "'"
            End If

            If Status = "ALL" Then
            Else
                _nWhere += " and OPR.StatusID='" & Status & "'"
            End If


            _nQuery += _nWhere & " order by " & cmbSortBy.Value & " " & cmbOrder.Value

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            gv_paymentList.DataSource = _mDataTable
            gv_paymentList.DataBind()

            qry = _nQuery
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnFilter_ServerClick(sender As Object, e As EventArgs) Handles btnFilter.ServerClick
        load_Gridview(cmbGateWay.Value, txtDateFrom.Value, txtDateTo.Value, cmbType.Value, cmbStatus.Value)
    End Sub

    Sub load_Gateway()
        Try
            cmbGateWay.DataSourceID = Nothing
            _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _mQuery = " select distinct OPR.paymentchannel as Code,OPS.GatewayName as Description from OnlinePaymentRefno OPR" &
                      " inner join [" & cGlobalConnections._pSqlCxn_CR.Database & "].dbo.OnlinePaymentSetup OPS on OPR.PAYMENTCHANNEL = OPS.Code" &
                      " and  OPR.paymentchannel <> '' order by OPR.paymentchannel asc "
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            Dim _mDataSet = New DataSet()
            _nSqlDataAdapter.Fill(_mDataSet)

            Try
                cmbGateWay.DataSource = _mDataSet
                cmbGateWay.DataTextField = "Description"
                cmbGateWay.DataValueField = "Code"
                cmbGateWay.DataBind()
                cmbGateWay.Items.Insert(0, New ListItem("ALL", "ALL"))
            Catch ex As Exception
            End Try
        Catch ex As Exception
            err.Value += ";load_Gateway:" & ex.Message
        End Try
    End Sub

    Sub load_Type()
        Try
            cmbType.DataSourceID = Nothing
            _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _mQuery = "select distinct type from OnlinePaymentRefno where type <> '' order by type asc"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            Dim _mDataSet = New DataSet()
            _nSqlDataAdapter.Fill(_mDataSet)


            cmbType.DataSource = _mDataSet
            cmbType.DataTextField = "type"
            cmbType.DataValueField = "type"
            cmbType.DataBind()
            cmbType.Items.Insert(0, New ListItem("ALL", "ALL"))
        
        Catch ex As Exception
            err.Value += ";load_Type:" & ex.Message
        End Try
    End Sub

    Sub load_Status()
        Try
            cmbStatus.DataSourceID = Nothing
            _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _mQuery = " select distinct StatusID from onlinepaymentrefno" &
                      " where statusid<> '' order by statusid asc"
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            Dim _mDataSet = New DataSet()
            _nSqlDataAdapter.Fill(_mDataSet)


            cmbStatus.DataSource = _mDataSet
            cmbStatus.DataTextField = "statusid"
            cmbStatus.DataValueField = "statusid"
            cmbStatus.DataBind()
            cmbStatus.Items.Insert(0, New ListItem("ALL", "ALL"))
        
        Catch ex As Exception
            err.Value += ";load_Status:" & ex.Message
        End Try
    End Sub

    Sub load_datefromto()
        Try
            Dim datefrom As Date
            Dim dateto As Date
            _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            _nQuery = " Select DATEADD(day, -1, min(transdate))'From', DATEADD(day, 1, max(transdate))'To'  from OnlinePaymentRefno "
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        datefrom = _nSqlDr("From")
                        dateto = _nSqlDr("To")
                    Loop
                End If
            End Using

            txtDateFrom.Attributes.Add("Type", "date")
            txtDateFrom.Attributes.Add("min", Format(datefrom, "yyyy-MM-dd"))
            txtDateFrom.Attributes.Add("max", Format(dateto, "yyyy-MM-dd"))
            txtDateFrom.Value = Format(datefrom, "yyyy-MM-dd")


            txtDateTo.Attributes.Add("Type", "date")
            txtDateTo.Attributes.Add("min", Format(datefrom, "yyyy-MM-dd"))
            txtDateTo.Attributes.Add("max", Format(dateto, "yyyy-MM-dd"))
            txtDateTo.Value = Format(dateto, "yyyy-MM-dd")


        Catch ex As Exception
            err.Value += ";load_datefromto:" & ex.Message
        End Try

    End Sub

    Protected Sub _oBtnPrint_Click(sender As Object, e As EventArgs) Handles _oBtnPrint.Click
        ' _mSubPrintOR()
        Print2()
    End Sub

    Sub Print2()
        _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        Dim rowCTR As Integer = 0
        Dim _nQuery As String = Nothing
        Dim qry As String = Nothing
        load_Gridview(cmbGateWay.Value, txtDateFrom.Value, txtDateTo.Value, cmbType.Value, cmbStatus.Value, qry)
        _nQuery = qry
        _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
        Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
        Dim _nDataTable = New DataTable
        _nSqlDataAdapter.Fill(_nDataTable)

        If _nDataTable.HasErrors Then
            Return
        End If

        If _nDataTable.Rows.Count <= 0 Then
            _oMSRV.Visible = False
        Else
            _oMSRV.Visible = True
        End If

        rowCTR = _nDataTable.Rows.Count

        _oMSRV.Reset()
        _oMSRV.LocalReport.ReportPath = _gResxRdlc.pPrintGeneralCollection
        _oMSRV.LocalReport.EnableExternalImages = True
        _oMSRV.LocalReport.DataSources.Clear()

        Dim _nReportDataSource As New ReportDataSource
        _nReportDataSource.Name = "DataSet1"
        _nReportDataSource.Value = _nDataTable
        _oMSRV.LocalReport.DataSources.Add(_nReportDataSource)
        Dim paramList As New List(Of ReportParameter)
        paramList.Add(New ReportParameter("ParamGateway", cmbGateWay.Items.Item(cmbGateWay.SelectedIndex).ToString))
        paramList.Add(New ReportParameter("ParamTransaction", cmbType.Items.Item(cmbType.SelectedIndex).ToString))
        paramList.Add(New ReportParameter("ParamDateFrom", txtDateFrom.Value))
        paramList.Add(New ReportParameter("ParamDateTo", txtDateTo.Value))
        paramList.Add(New ReportParameter("ParamStatus", cmbStatus.Items.Item(cmbStatus.SelectedIndex).ToString))
        paramList.Add(New ReportParameter("ParamSortBy", cmbSortBy.Items.Item(cmbSortBy.SelectedIndex).ToString))
        paramList.Add(New ReportParameter("ParamOrder", cmbOrder.Items.Item(cmbOrder.SelectedIndex).ToString))
        paramList.Add(New ReportParameter("ParamCount", rowCTR))
        _oMSRV.LocalReport.SetParameters(paramList)
        _oMSRV.AsyncRendering = True
        _oMSRV.LocalReport.Refresh()
        _oMSRV.Visible = True
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


End Class