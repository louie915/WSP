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
    Dim DefaultDate As String = DateTime.Now.ToString("MM/dd/yyyy")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            load_Gateway()
            load_Type()
            load_Status()
            load_datefromto()
            _pSubCheckIfORNOExists()
        End If

        _oMSRV.Visible = True
    End Sub


    Protected Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            load_Gridview(cmbGateWay.Value, IIf(txtDateFrom.Value = Nothing, DefaultDate, txtDateFrom.Value), IIf(txtDateTo.Value = Nothing, DefaultDate, txtDateTo.Value), cmbType.Value, cmbStatus.Value)
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

            _nQuery = _
                    " WITH temporaryTable  as  " &
                    " ( SELECT AssessNo,TDN FROM [" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.Assess_FrmNewBilling_A GROUP BY AssessNo,TDN union" &
                    " SELECT AssessNo,TDN FROM [" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.HistAssess_FrmNewBilling_A GROUP BY AssessNo,TDN ) " &
                    " SELECT distinct OPR.TransDate,OPR.txnrefno,OPR.GatewayRefno,OPR.EMAILADDR,OPR.PaymentChannel,OPR.Type,OPR.acctno,OPR.Statusid,OPR.Rawamount,OPR.Feeamount,OPR.totamount, tT.AssessNo, " &
                    "   (SELECT tT2.TDN + '; '" &
                    "   from temporaryTable tT2" &
                    "    WHERE tT.AssessNo = tT2.AssessNo" &
                    "    FOR XML PATH(''))TDN" &
                    " FROM temporaryTable tT" &
                    " right join OnlinePaymentRefno OPR on  OPR.ACCTNO=TT.AssessNo " &
                    " where OPR.TransDate >= '" & dateFrom.ToString("MM/dd/yyyy") & "' and OPR.transdate <= '" & dateTo.ToString("MM/dd/yyyy") & "' "

            ' " WITH temporaryTable  as " &
            '       " (SELECT AssessNo, COUNT(distinct tdn)ctr FROM [" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.Assess_FrmNewBilling_A  GROUP BY AssessNo)" &
            '       " select distinct OPR.TransDate,OPR.txnrefno,OPR.EMAILADDR,OPR.PaymentChannel,OPR.Type,OPR.acctno,OPR.Statusid,OPR.totamount," &
            '       " CASE WHEN ctr > 1 THEN 'Various' " &
            '       " WHEN ctr = 1 THEN (select distinct tdn from [" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.Assess_FrmNewBilling_A where AssessNo=TT.AssessNo)	" &
            '       " END	TDN" &
            '       " from temporaryTable TT " &
            '       " right join OnlinePaymentRefno OPR on  OPR.ACCTNO=TT.AssessNo" &
            '       " where OPR.TransDate >= '" & dateFrom & "' and format(OPR.transdate,'MM/dd/yyyy') <= '" & dateTo & "' "





            If Gateway = "ALL" Then
                _nWhere = ""
            Else
                _nWhere += " and OPR.PaymentChannel='" & Gateway & "'"
            End If

            If Type = "ALL" Then
            Else
                _nWhere += " and OPR.Type='" & Type & "'"
            End If

            'If Status = "ALL" Then
            'Else
            '    _nWhere += " and OPR.StatusID='" & Status & "'"
            'End If

            _nWhere += " and UPPER(OPR.StatusID)='SUCCESS' "



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
        load_Gridview(cmbGateWay.Value, IIf(txtDateFrom.Value = Nothing, DefaultDate, txtDateFrom.Value), IIf(txtDateTo.Value = Nothing, DefaultDate, txtDateTo.Value), cmbType.Value, cmbStatus.Value)
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
            Err.Value += ";load_Gateway:" & ex.Message
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
            Err.Value += ";load_Type:" & ex.Message
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
            Err.Value += ";load_Status:" & ex.Message
        End Try
    End Sub

    Sub load_datefromto()
        Try
            txtDateFrom.Attributes.Add("Type", "date")
            txtDateTo.Attributes.Add("Type", "date")
            Dim datefrom As Date = Nothing
            Dim dateto As Date = Nothing
            _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            _nQuery = " SELECT " & _
                        " RIGHT('00' + CAST(MONTH(MIN(transdate)) AS VARCHAR(2)), 2) + '/' +  " & _
                        " RIGHT('00' + CAST(DAY(MIN(transdate)) AS VARCHAR(2)), 2) + '/' +    " & _
                        " CAST(YEAR(MIN(transdate)) AS VARCHAR(4)) AS [From] " & _
                        " , " & _
                        " RIGHT('00' + CAST(MONTH(MAX(transdate)) AS VARCHAR(2)), 2) + '/' + " & _
                        " RIGHT('00' + CAST(DAY(MAX(transdate)) AS VARCHAR(2)), 2) + '/' +    " & _
                        " CAST(YEAR(MAX(transdate)) AS VARCHAR(4)) AS [To] " & _
                        "FROM OnlinePaymentRefno "

            '' "select  format(min(transdate),'MM-dd-yyyy') as 'From',format(max(transdate),'MM-dd-yyyy') as 'To' from OnlinePaymentRefno "
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        datefrom = _nSqlDr("From").ToString()
                        dateto = _nSqlDr("To").ToString()
                    Loop
                End If
            End Using

            txtDateFrom.Value = datefrom
            txtDateTo.Value = dateto

            txtDateFrom.Attributes.Add("min", txtDateFrom.Value)
            txtDateFrom.Attributes.Add("max", txtDateTo.Value)

            txtDateTo.Attributes.Add("min", txtDateFrom.Value)
            txtDateTo.Attributes.Add("max", txtDateTo.Value)


        Catch ex As Exception
            Err.Value += ";load_datefromto:" & ex.Message
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
        load_Gridview(cmbGateWay.Value, IIf(txtDateFrom.Value = Nothing, DefaultDate, txtDateFrom.Value), IIf(txtDateTo.Value = Nothing, DefaultDate, txtDateTo.Value), cmbType.Value, cmbStatus.Value, qry)
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
        paramList.Add(New ReportParameter("ParamDateFrom", IIf(txtDateFrom.Value = Nothing, DefaultDate, txtDateFrom.Value).ToString))
        paramList.Add(New ReportParameter("ParamDateTo", IIf(txtDateTo.Value = Nothing, DefaultDate, txtDateTo.Value).ToString))
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


    Public Sub _pSubCheckIfORNOExists()
        Try
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim EXISTS As Boolean = 0

            _nQuery = _
              " SELECT count(*)[Exists] from ( " & _
              " select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='ONLINEPAYMENTREFNO' " & _
              " and COLUMN_NAME='MINORNO') as ctr"
            _mQuery = _nQuery
            _mSqlCommand = New SqlCommand(_mQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    EXISTS = _nSqlDr.Item("Exists")
                End If
            End Using

            If EXISTS = 0 Then
                _pSubAlterTableAddORNO()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Sub _pSubAlterTableAddORNO()
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "ALTER TABLE ONLINEPAYMENTREFNO  ADD MINORNO NVARCHAR(MAX),MAXORNO NVARCHAR(MAX)"
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlCommand.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub


End Class