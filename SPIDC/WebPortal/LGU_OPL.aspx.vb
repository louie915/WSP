Imports SPIDC.Resources
Imports Microsoft.Reporting.WebForms
Imports System.Data.SqlClient
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.IO
Imports RestSharp
Imports System.Web.Script.Serialization
Imports System.Web.HttpContext
Imports Org.BouncyCastle.OpenSsl
Imports Org.BouncyCastle.Crypto
Imports Org.BouncyCastle.Security
Imports Org.BouncyCastle.Crypto.Parameters
Imports System.Reflection
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ResponseData
    Public Property MerchantCode As String
    Public Property MerchantRefNo As String
    Public Property Particulars As String
    Public Property Amount As String
    Public Property PayorName As String
    Public Property PayorEmail As String
    Public Property EPPRefNo As String
    Public Property PaymentOption As String
    Public Property EPPTimestamp As String
    Public Property Status As String
End Class
Public Class ErrorResponse
    Public Property Errors As List(Of ErrorDetail)
End Class
Public Class ErrorDetail
    Public Property Code As String
    Public Property Message As String
End Class
Public Class LGU_OPL
    Inherits System.Web.UI.Page
    Private _mSqlCon As SqlConnection
    Private _mQuery As String = Nothing
    Private _mSqlCommand As SqlCommand
    Private _mDataTable As DataTable
    Private _mSqlDataReader As SqlDataReader
    Private btnClicked As String

    Public Shared PayMayaDomain As String = "https://pg.paymaya.com"

#Region "Payment Inquiry Variables"
    Dim encoder As New UTF8Encoding
    Dim serializer As System.Web.Script.Serialization.JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer()
    Private GCashDomain As String = "https://api.saas.mynt.xyz/"

    Private PublicKey_XML As String
    Private PrivateKey_XML As String
    Private PublicKey_PEM As String
    Private PrivateKey_PEM As String
    Private ClientId As String
    Private ClientSecret As String
    Private MerchantID As String
    Private ProductCode As String
    Private GCASH_PublicKey_PEM As String
    Private ReqMsgID As String
    Private GCASH_PubKey As String
    ' Private SPIDCREFNO As String

    Dim Q_acquirementStatus As String
    Public Q_TXNREFNO, Q_Status, Q_GateWayRefNo, Q_Security, Q_trxdate, Q_amount, Q_fee, Q_total, Q_statusID, Q_PaymentOption As String
    Public Q_JSON As String
    Public Q_acquirementId As String
    Public Q_merchantTransId As String
    Public Q_shortTransId As String

    Dim _status As String

#End Region

    Private Const _sscPrefix As String = "LGU_OPL."
    Private Const _ssc_qry As String = _sscPrefix & "_ssc_qry"
    Private Const _sscGatewayStatus As String = _sscPrefix & "_sscGatewayStatus"
    Private Const _sscGatewayStatusID As String = _sscPrefix & "_sscGatewayStatusID"
    Private Const _sscSPIDCREFNO As String = _sscPrefix & "_sscSPIDCREFNO"

    Dim DefaultDate As String = DateTime.Now.ToString("MM/dd/yyyy")
#Region "Properties"
    Shared Property SPIDCREFNO() As String
        Get
            Return Current.Session(_sscSPIDCREFNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSPIDCREFNO) = value
        End Set
    End Property
    Shared Property GatewayStatusID() As String
        Get
            Return Current.Session(_sscGatewayStatusID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGatewayStatusID) = value
        End Set
    End Property
    Shared Property GatewayStatus() As String
        Get
            Return Current.Session(_sscGatewayStatus)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGatewayStatus) = value
        End Set
    End Property
    Shared Property _qry() As String
        Get
            Return Current.Session(_ssc_qry)
        End Get
        Set(ByVal value As String)
            Current.Session(_ssc_qry) = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then


            txtDateFrom.Value = DefaultDate
            txtDateTo.Value = DefaultDate

            load_Gateway()
            load_Type()
            load_Status()
            load_datefromto()
            _pSubCheckIfORNOExists()
        End If
    End Sub


    Protected Sub datagrid_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            load_GridviewPaging()
            gv_paymentList.PageIndex = e.NewPageIndex
            gv_paymentList.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Sub load_GridviewPaging()
        Try
            _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            _nQuery = _qry
            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            gv_paymentList.DataSource = _mDataTable
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
                    " ,  'INQUIRE'   AS [Action] " &
                    " FROM temporaryTable tT" &
                    " right join OnlinePaymentRefno OPR on  OPR.ACCTNO=TT.AssessNo " &
                    " where OPR.TransDate >= '" & dateFrom & "' and format(OPR.transdate,'MM/dd/yyyy') <= '" & dateTo & "' " &
                    "  and opr.TXNREFNO not in (select OnlineID from eOR) "

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

            _nWhere += " and OPR.StatusID<> 'SUCCESS' "

            _nQuery += _nWhere & " order by " & cmbSortBy.Value & " " & cmbOrder.Value

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            gv_paymentList.DataSource = _mDataTable
            gv_paymentList.DataBind()

            qry = _nQuery

            btnClicked = _nQuery
        Catch ex As Exception

        End Try
    End Sub

    Sub load_GridviewSearch(ByVal SearchBy As String, ByVal SeachText As String, Optional ByRef qry As String = Nothing)
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
                     " , (CASE WHEN OPR.statusID='PENDING'  THEN 'INQUIRE'  ELSE null  END) AS [Action] " &
                    " FROM temporaryTable tT" &
                    " right join OnlinePaymentRefno OPR on  OPR.ACCTNO=TT.AssessNo " &
                    " where " & SearchBy & " like '%" & SeachText & "%'"

            _mSqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, _mSqlCon)
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            gv_paymentList.DataSource = _mDataTable
            gv_paymentList.DataBind()

            qry = _nQuery
            btnClicked = _nQuery
        Catch ex As Exception

        End Try
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
            txtDateFrom.Attributes.Add("Type", "date")
            txtDateTo.Attributes.Add("Type", "date")
            Dim datefrom As Date = Nothing
            Dim dateto As Date = Nothing
            _mSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nQuery As String = Nothing
            _nQuery = "select  format(min(transdate),'MM-dd-yyyy') as 'From',format(max(transdate),'MM-dd-yyyy') as 'To' from OnlinePaymentRefno "
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
        'If btnClicked = "FILTER" Then
        '    load_Gridview(cmbGateWay.Value, txtDateFrom.Value, txtDateTo.Value, cmbType.Value, cmbStatus.Value, qry)
        'ElseIf btnClicked = "SEARCH" Then
        '    load_GridviewSearch(cmbSearch.Value, txtSearch.Value, qry)
        'End If

        '   _nQuery = qry
        _nQuery = btnClicked
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

    Private Sub btnFilter_ServerClick(sender As Object, e As EventArgs) Handles btnFilter.ServerClick
        load_Gridview(cmbGateWay.Value, IIf(txtDateFrom.Value = Nothing, DefaultDate, txtDateFrom.Value), IIf(txtDateTo.Value = Nothing, DefaultDate, txtDateTo.Value), cmbType.Value, cmbStatus.Value, _qry)
    End Sub
    Private Sub btnSearch_ServerClick(sender As Object, e As EventArgs) Handles btnSearch.ServerClick
        load_GridviewSearch(cmbSearch.Value, txtSearch.Value, _qry)
    End Sub


#Region "Payment Inquiry Functions"
    Private Sub btnInquire_ServerClick(sender As Object, e As EventArgs) Handles btnInquire.ServerClick
        Dim res As String
        PaymentInquiry(hdnTxnRefNo.Value, hdnGateWay.Value, res)
        load_GridviewPaging()
        If res <> "POSTED" Then
            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal('modalInquiry');", True)
        End If

    End Sub


    Sub PaymentInquiry(ByVal SPIDCREFNO As String, ByVal SelectedGateway As String, ByRef Result As String)
        Try

            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            Dim _nClass2 As New cDalPayment
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_CR

            Dim _nClass0 As New eOR
            'If _nClass0.isEOR_Exists(SPIDCREFNO) = True Then
            '    Response.Write("<script>alert('Record already Posted.');</script>")
            '    Exit Sub
            'End If
            Dim eORNO As String = Nothing
            Dim isTaxpayer As Boolean = False

            Dim GatewayRefNo As String = Nothing
            Dim GatewaySecurity As String = Nothing
            GatewayStatus = Nothing
            GatewayStatusID = Nothing

            Dim LBPDomain As String
            Dim Gateway As String = SelectedGateway
            Dim str As String
            Dim strArr() As String
            Dim count As Integer
            str = SPIDCREFNO
            strArr = str.Split(";")
            btnPostAnyway.Style.Add("display", "none")



            For count = 0 To strArr.Length - 1
                SPIDCREFNO = strArr(count)
                SPIDCREFNO = Replace(SPIDCREFNO, ";", "")
                Gateway = _nClass.Get_GateWayUsed(SPIDCREFNO)
                _nClass2._pSubGetGatewayCredentials(Gateway)
                Result = Nothing
                _status = Nothing
                Select Case Gateway.ToUpper

                    Case "GCASH"
                        SetCredentials()
                        Dim acquirementId As String
                        Dim shortTransId As String
                        Dim signature As String = "signature string"
                        _nClass.Get_GcashLog(SPIDCREFNO, acquirementId, shortTransId)
                        GatewaySecurity = acquirementId
                        CreateQuery(SPIDCREFNO, shortTransId, acquirementId, Result, _status, GatewayRefNo)
                        GatewayStatus = _status

                    Case "LBP1"
                        _nClass2._pSubGetGatewayCredentials("LBP1")
                        Dim Hash As String = _nClass.GetHashMD5(cDalPayment.gw_MerchantCode & Trim(SPIDCREFNO).ToUpper & cDalPayment.gw_SecretKey).ToLower()
                        Dim URI As String
                        If cDalPayment.gw_LIVE = True Then
                            URI = cDalPayment.gw_ProdURL
                        Else
                            URI = cDalPayment.gw_TestURL
                        End If
                        Dim post_data As String = "?MerchantCode=" & cDalPayment.gw_MerchantCode &
                                                  "&MerchantRefNo=" & Trim(SPIDCREFNO).ToUpper &
                                                  "&Hash=" & Hash
                        Dim string_to_Post As String = URI.Replace("ws-pay1.php", "api2-status.php") & post_data
                        '  Dim string_to_Post As String = URI.Replace("", "api2-status.php") &  & post_data
                        'Dim client = New RestClient(string_to_Post)
                        'client.Timeout = -1
                        'Dim request = New RestRequest(Method.POST)
                        'Dim _response As IRestResponse = client.Execute(request)
                        ''  Response.Write(_response.Content)

                        'Result += "string_to_Post : " & string_to_Post & "<br>"
                        'Result += "MerchantCode : " & cDalPayment.gw_MerchantCode & "<br>"
                        'Result += "MerchantRefNo : " & Trim(SPIDCREFNO).ToUpper & "<br>"
                        'Result += "SecretKey : " & cDalPayment.gw_SecretKey & "<br>"
                        'Result += "Hash : " & Hash & "<br><br>"
                        'Result += "Result : <br> " & _response.Content

                        'GatewayStatus = "FAILED TO INQUIRE"
                        'GatewayStatusID = "FAILED TO INQUIRE"


                        Dim client_EPP As New RestClient(URI.Replace("ws-pay1.php", "api2-status.php"))
                        Dim request_EPP As New RestRequest(Method.POST)

                        ' Add parameters to the request
                        request_EPP.AddParameter("MerchantCode", cDalPayment.gw_MerchantCode)
                        request_EPP.AddParameter("MerchantRefNo", Trim(SPIDCREFNO).ToUpper)
                        request_EPP.AddParameter("Hash", Hash)

                        Dim response_EPP As IRestResponse = client_EPP.Execute(request_EPP)

                        Dim jsonResponse As String = response_EPP.Content

                        Dim json As JObject = JObject.Parse(jsonResponse)

                        Dim responseData As ResponseData = JsonConvert.DeserializeObject(Of ResponseData)(jsonResponse)

                        Dim errorResponse As ErrorResponse = JsonConvert.DeserializeObject(Of ErrorResponse)(jsonResponse)
                        'If errorResponse.Errors IsNot Nothing Then
                        '    For Each err_EPP In errorResponse.Errors
                        '        GatewayStatus = err_EPP.Message
                        '        GatewayStatusID = "FAILED"
                        '    Next

                        If json("Error") IsNot Nothing Then
                            GatewayStatus = json("Error")(0)("message").ToString
                            GatewayStatusID = "FAILED"
                        Else



                            GatewayStatus = responseData.Status.ToUpper
                            GatewayStatusID = responseData.Status.ToUpper

                            If GatewayStatus = "SUCCESSFUL" Then
                                GatewayStatusID = "SUCCESS"
                                GatewayStatus = "SUCCESS"
                            End If

                            GatewayRefNo = responseData.EPPRefNo
                            GatewaySecurity = Hash
                        End If



                        If response_EPP.StatusCode >= 200 AndAlso response_EPP.StatusCode <= 299 Then
                            Response.Write("Request Successful!")
                            Response.Write("Response Content:")
                            Response.Write(response_EPP.Content)
                        Else
                            Response.Write("Request Failed!")
                            Response.Write("Status Code: " & response_EPP.StatusCode)
                            Response.Write("Error Message: " & response_EPP.ErrorMessage)
                        End If


                    Case "LBP2"
                        If cDalPayment.gw_LIVE = True Then
                            LBPDomain = cDalPayment.gw_ProdURL.Replace("postpayment", "inquirestatus")
                        Else
                            LBPDomain = cDalPayment.gw_TestURL.Replace("postpayment", "inquirestatus")
                        End If
                        Dim checksum As String = Nothing
                        Dim username As String = cDalPayment.gw_UserName
                        Dim password As String = cDalPayment.gw_Password
                        Dim SecretKey As String = cDalPayment.gw_SecretKey

                        checksum = cDalPayment.gw_MerchantCode & Nothing & SPIDCREFNO & username & password
                        checksum = _nClass.GenerateSHA256String(checksum & SecretKey).ToUpper

                        Dim post_data As String = "?merchantcode=" & cDalPayment.gw_MerchantCode &
                                                  "&refnum=" & Nothing &
                                                  "&trandetail1=" & SPIDCREFNO &
                                                  "&checksum=" & checksum &
                                                  "&username=" & username &
                                                  "&password=" & password
                        Dim string_to_Post As String = LBPDomain & post_data
                        Dim client = New RestClient(string_to_Post)
                        client.Timeout = -1
                        Dim request = New RestRequest(Method.POST)
                        Dim _response As IRestResponse = client.Execute(request)


                        Result = "Posted String <br/>" & string_to_Post &
                                                "<br/><br/>" &
                                                "Response String <br/>" & _response.Content

                        Dim LBP_errDesc As String = Nothing
                        Dim LBP_str As String = _response.Content
                        Dim LBP_strArr() As String
                        LBP_strArr = LBP_str.Split("|")
                        _nClass._pSubGetEpsErrorCode(LBP_strArr(1), LBP_errDesc)
                        If LBP_strArr(1) = "0000" Then
                            _nClass._pSubUpdateOnlinePaymentInfo2("LBP2", SPIDCREFNO _
                                    , LBP_errDesc _
                                    , LBP_strArr(2) _
                                    , LBP_strArr(4) _
                                    , "SUCCESS")
                            GatewayStatus = "SUCCESS"

                        Else
                            _nClass._pSubUpdateOnlinePaymentInfo2("LBP2", SPIDCREFNO _
                                   , IIf(LBP_errDesc = Nothing, "Err: " & LBP_strArr(1), LBP_errDesc) _
                                   , LBP_strArr(2) _
                                   , LBP_strArr(4) _
                                   , "FAILED")
                            GatewayStatus = IIf(LBP_errDesc = Nothing, "Err: " & LBP_strArr(1), LBP_errDesc)
                        End If
                        Dim LBP_ACCTNO As String
                        _nClass._pSubGetACCTNO(SPIDCREFNO, LBP_ACCTNO)
                        _nClass.LBP_EPS_InsertLog(string_to_Post, _response.Content, SPIDCREFNO, LBP_ACCTNO, _nClass.Get_Details("OnlinePaymentRefNo", "Type", "TXNREFNO", SPIDCREFNO))

                    Case "PAYMAYA"
                        GetPaymentsviaRRN_GET(SPIDCREFNO, GatewayStatus, GatewayRefNo)
                        If GatewayStatus = "PAYMENT_SUCCESS" Then GatewayStatus = "SUCCESS"
                    Case Else
                        GatewayStatus = "FAILED TO INQUIRE"
                        GatewayStatusID = "FAILED TO INQUIRE"
                        btnPostAnyway.Style.Add("display", "")
                End Select



                '  GatewayRefNo
                '  GatewaySecurity 
                '  GatewayStatusID

                If GatewayStatus = "SUCCESS" Then
                    GatewayStatusID = "SUCCESS"
                    _nClass._pSubUpdateOnlinePaymentInfo2(Gateway, SPIDCREFNO _
                                  , GatewayStatus _
                                  , GatewayRefNo _
                                  , GatewaySecurity _
                                  , GatewayStatusID)
                ElseIf GatewayStatus = "FAILED TO INQUIRE" Then
                    GatewayStatusID = "FAILED TO INQUIRE"
                    btnPostAnyway.Style.Add("display", "")
                    SPIDCREFNO = SPIDCREFNO

                Else
                    GatewayStatusID = "FAILED"
                    _nClass._pSubUpdateOnlinePaymentInfo2(Gateway, SPIDCREFNO _
                                  , GatewayStatus _
                                  , GatewayRefNo _
                                  , GatewaySecurity _
                                  , GatewayStatusID)
                End If



                lblWSPREFNO.InnerText = SPIDCREFNO
                lblGatewaySelected.InnerText = Gateway
                lblGatewayRefNo.InnerText = GatewayRefNo
                lblStatus.InnerText = GatewayStatusID

                '11-06-2023 JAY SITJAR
                Session("runEORandPostingGatewayRefNo") = GatewayRefNo
                Session("runEORandPostingPaymentRefNo") = SPIDCREFNO
                Session("runEORandPostingPaymentGateway") = Gateway.ToUpper()
                'End JAY SITJAR



                Dim _nclassGetModules As New cDalGetModules
                Dim _nclassEOR As New eOR
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                Dim _nClassPost As New Process
                Dim err As String = Nothing
                If GatewayStatusID = "SUCCESS" And _nclassGetModules._pSubGetAvailableModules("EOR") = True Then
                    Response.Redirect("runEORandPosting.aspx")
                    ' ''                    If cInit_eOR.Initialize_EOR(SPIDCREFNO, Report_EOR, Gateway, GatewayRefNo) = True Then GoTo jumphere

                    ' ''                    If _nclassEOR.isEOR_Exists(SPIDCREFNO) = False Then
                    ' ''                        Process.ACCTNO = _nclassEOR.getACCTNO(SPIDCREFNO)
                    ' ''                        cSessionLoader._pTDN = _nclassEOR.getTDN(Process.ACCTNO)
                    ' ''                        Process.Gateway_Selected = Gateway
                    ' ''                        Process.GatewayRefNo = GatewayRefNo
                    ' ''                        eOR.Gateway_RefNo = GatewayRefNo
                    ' ''                        eOR.TaxPayerEmail = _nclassEOR.getEMAIL(SPIDCREFNO)
                    ' ''                        Process.TransactionType = _nclassEOR.getTransactionType(SPIDCREFNO)
                    ' ''                        eOR.SPIDC_RefNo = SPIDCREFNO
                    ' ''                        _nClassPost.START_POSTING(err, eORNO, isTaxpayer, Process.GatewayRefNo)
                    ' ''                        _GenerateReport_eOR(1, Process.TransactionType, eORNO)

                    ' ''jumphere:
                    ' ''                    Else
                    ' ''                        Response.Write("<script>alert('Record already Posted.');</script>")
                    ' ''                        Result = "POSTED"
                    ' ''                        Exit Sub
                    ' ''                    End If
                Else
                    Exit Sub
                End If

              
               

            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub GetPaymentsviaRRN_GET(ByVal rrn As String, ByRef GatewayStatus As String, ByRef GatewayRefNo As String)
        Try


            Dim _nC As New cDalPayment
            Dim classMaya As New PayMaya
            Dim PK As String = _nC.gw_PublicApiKey
            Dim SK As String = _nC.gw_SecretApiKey
            Dim PKPASS As String = ""
            Dim SKPASS As String = ""

            Dim client = New RestClient(PayMayaDomain & "/payments/v1/payment-rrns/" & rrn)
            client.Timeout = -1
            '     ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            Dim request = New RestRequest(Method.[GET])
            request.AddHeader("Authorization", "Basic " & PayMaya.Base64Encode(SK & ":" & SKPASS))


            Dim responseX As IRestResponse = client.Execute(request)

            Dim resStr As String = responseX.Content

            Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(responseX.Content)

            Dim valueType As Type = res.[GetType]()
            Dim PAYMENT_STATUS As String
            Dim PAYMENT_RRN As String
            Dim PAYMENT_ID As String

            Dim xx As String = """code"":"
            If resStr.ToLower.Contains("""code"":") Then
                Dim res2 As Object = New JavaScriptSerializer().Deserialize(Of Object)(resStr)
                PAYMENT_STATUS = res2("message")
                PAYMENT_ID = Nothing
            Else
                If valueType.IsArray Then
                    PAYMENT_STATUS = res(res.length - 1)("status")
                    PAYMENT_RRN = res(res.length - 1)("requestReferenceNumber")
                    PAYMENT_ID = res(res.length - 1)("id")
                Else
                    PAYMENT_STATUS = res("status")
                    PAYMENT_RRN = res("requestReferenceNumber")
                    PAYMENT_ID = res("id")
                End If
            End If


            GatewayStatus = PAYMENT_STATUS
            GatewayRefNo = PAYMENT_ID
            If PAYMENT_STATUS = "PAYMENT_SUCCESS" Then
                GatewayStatus = "SUCCESS"
                Dim TaxpayerEmail As String = Nothing
                Dim ACCTNO As String = Nothing
                Dim StatusId As String = Nothing
                Dim PaymentFor As String = Nothing
                Dim _nclass As New cDalPayment
                _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub
    Public Function GenerateSHA256String(ByVal inputString) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function
    Function Do_Sign(ByVal StringToSign As String) As String
        Try
            Dim originalData As Byte() = encoder.GetBytes(StringToSign)
            Dim signedData As Byte()
            Dim rsa As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            Dim XML_PrivateKey As String = PrivateKey_XML
            rsa.FromXmlString(XML_PrivateKey)
            Dim key As RSAParameters = rsa.ExportParameters(True)
            signedData = HashAndSignBytes(originalData, key)
            Return Convert.ToBase64String(signedData)
        Catch ex As Exception

        End Try
    End Function
    Public Shared Function HashAndSignBytes(ByVal DataToSign As Byte(), ByVal Key As RSAParameters) As Byte()
        Try
            Dim RSAalg As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            RSAalg.ImportParameters(Key)
            Return RSAalg.SignData(DataToSign, SHA256.Create())
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
            Return Nothing
        End Try
    End Function
    Public Sub SetCredentials()
        Try
            Dim _nClass1 As New cDalGCash
            _nClass1._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
            _nClass1.loadcredentials()
            ReqMsgID = _nClass1.Gen_MD5(SPIDCREFNO)
            PublicKey_XML = _nClass1._pPublicKey_XML
            PrivateKey_XML = _nClass1._pPrivateKey_XML
            PublicKey_PEM = _nClass1._pPublicKey_PEM
            PrivateKey_PEM = _nClass1._pPrivateKey_PEM
            ClientId = _nClass1._pClientId
            ClientSecret = _nClass1._pClientSecret
            MerchantID = _nClass1._pMerchantID
            Session("MerchantID") = _nClass1._pMerchantID
            ProductCode = _nClass1._pProductCode
            GCASH_PubKey = "-----BEGIN PUBLIC KEY-----" & vbCrLf & _nClass1._pGCASH_PublicKey_PEM & vbCrLf & "-----END PUBLIC KEY-----"
        Catch ex As Exception
            err.Value += ";SetCredentials : " & ex.Message
        End Try

    End Sub
    Sub CreateQuery(ByVal _merchantTransId As String, ByVal _shortTransId As String, ByVal _acquirementId As String, Optional ByRef Result As String = Nothing, Optional ByRef Status As String = Nothing, Optional ByRef GatewayRefNo As String = Nothing)
        Try
            Dim objReq As New GCash_OrderQuery0.GCash_OrderQuery
            objReq.request = New GCash_OrderQuery0.Request()
            objReq.request.head = New GCash_OrderQuery0.Head()
            objReq.request.body = New GCash_OrderQuery0.Body()
            Dim _sqlDateNow As DateTime
            Dim _sqlDateNow10 As DateTime
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GetsqlDateNow(_sqlDateNow, _sqlDateNow10)

            'Head
            objReq.request.head.version = "2.0"
            objReq.request.head._function = "gcash.acquiring.order.query"
            objReq.request.head.clientId = ClientId
            objReq.request.head.clientSecret = ClientSecret
            objReq.request.head.reqTime = _sqlDateNow.ToString("yyyy-MM-dd'T'HH:mm:ssK")
            objReq.request.head.reqMsgId = ReqMsgID

            objReq.request.body.acquirementId = _acquirementId
            objReq.request.body.merchantTransId = _merchantTransId
            objReq.request.body.shortTransId = _shortTransId

            objReq.signature = "signature string"

            Dim client = New RestClient(GCashDomain)
            client.Timeout = -1
            Dim request = New RestRequest("gcash/acquiring/order/query.htm", Method.POST)
            Dim body = serializer.Serialize(objReq)

            body = body.Replace("_function", "function")

            Dim StringToSign As String = Nothing
            StringToSign = body.Remove(0, 11) ' Remove "request":
            StringToSign = StringToSign.Replace(",""signature"":""signature string""}", "")
            Dim signedString As String = Do_Sign(StringToSign)
            body = body.Replace("signature string", signedString)
            request.AddParameter("application/json", body, ParameterType.RequestBody)

            Dim _function As String = objReq.request.head._function
            Dim _transactionId As String = _shortTransId
            Dim _signature As String = signedString


            Dim response1 As IRestResponse = client.Execute(request)
            Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(response1.Content)

            '   div_Result.InnerText += "<br/><br/>" & body & "<br/><br/>" & response1.Content

            Dim Response_OriginalString
            Dim index As Integer = response1.Content.LastIndexOf(","c)
            Response_OriginalString = response1.Content.Remove(index)
            Response_OriginalString = Response_OriginalString.Remove(0, 12) ' Remove "response":

            err.Value += ";Response_OriginalString:" & Response_OriginalString

            ' If VerifySignature(Response_OriginalString, res("signature")) = True Then
            '  Try
            Q_acquirementStatus = res("response")("body")("statusDetail")("acquirementStatus")
            'err.Value += ";Q_acquirementStatus:" & Q_acquirementStatus
            '  Catch ex As Exception
            '      err.Value += ";Q_acquirementStatus: " & ex.Message
            '   End Try

            '  Try
            Q_Security = res("response")("body")("acquirementId")
            'err.Value += ";Q_Security: " & Q_Security
            ' Catch ex As Exception
            '      err.Value += ";Q_Security: " & ex.Message
            '  End Try

            '   Try
            Q_GateWayRefNo = res("response")("body")("transactionId")
            'err.Value += ";Q_GateWayRefNo: " & Q_GateWayRefNo
            '  Catch ex As Exception
            '      err.Value += ";Q_GateWayRefNo: " & ex.Message
            '  End Try

            GatewayRefNo = Q_GateWayRefNo

            'SAVE REQUEST FROM SPIDC
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GCASH_InsertLog(_function, _transactionId, _merchantTransId, body, "Request from SPIDC", _acquirementId, _signature)

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubUpdateOnlinePaymentInfo2("GCASH", SPIDCREFNO _
                , Q_acquirementStatus _
                , Q_GateWayRefNo _
                , Q_Security _
                , Q_acquirementStatus)

            body = response1.Content
            _function = res("response")("head")("function")
            _transactionId = res("response")("body")("transactionId")
            _merchantTransId = res("response")("body")("merchantTransId")
            _acquirementId = res("response")("body")("acquirementId")
            _signature = res("signature")

            'SAVE RESPONSE FROM GCASH
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.GCASH_InsertLog(_function, _transactionId, _merchantTransId, body, "Response from GCASH", _acquirementId, _signature)

            Result = body
            Status = Q_acquirementStatus
            Exit Sub
            '   Else
            '   err.Value += ";VerifySignature: False"
            '    End If

        Catch ex As Exception
            err.Value += ";CreateQuery:" & ex.Message
            Result = err.Value
        End Try

    End Sub
    Sub WriteLogs(ByVal _function As String, ByVal _Type As String, ByVal _JSON As String)
        Response.Write("<table style='border-collapse: collapse;width: 800px;'>")
        Response.Write("<tr>")
        Response.Write("<th style='border: 1px solid #ddd;padding: 8px;text-align: left;background-color: gray;color: white;'>")
        Response.Write(_function & " : " & _Type)
        Response.Write("</th>")
        Response.Write("</tr>")
        Response.Write("<tr>")
        Response.Write("<td style='border: 1px solid #ddd;padding: 8px;'>")
        Response.Write(_JSON)
        Response.Write("</th>")
        Response.Write("</tr>")
        Response.Write("</table>")
        Response.Write("</br></br>")
        Response.Write("<script>")
        Response.Write("console.log('" & _function & " : " & _Type & "')")
        Response.Write("console.log('" & _JSON & "')")
        Response.Write("</script>")


    End Sub
    Function VerifySignature(ByVal OriginalString As String, ByVal SignedString As String) As Boolean
        Try
            Dim initialProvider As RSACryptoServiceProvider = New RSACryptoServiceProvider(2048)
            Dim privateKey As String = ExportPrivateKey(initialProvider)
            Dim publicKey As String = ExportPublicKey(initialProvider)

            Dim importedProvider As RSACryptoServiceProvider = ImportPublicKey(GCASH_PubKey)
            publicKey = ExportPublicKey(importedProvider)

            Dim pubKey As RSAParameters = importedProvider.ExportParameters(False)

            Dim encoder = New UTF8Encoding()
            Dim bytesToVerify As Byte() = encoder.GetBytes(OriginalString)
            Dim signedBytes As Byte() = Convert.FromBase64String(SignedString)

            Return importedProvider.VerifyData(bytesToVerify, SHA256.Create(), signedBytes)


        Catch ex As Exception

        End Try
    End Function
    Public Shared Function ExportPrivateKey(ByVal csp As RSACryptoServiceProvider) As String
        Dim outputStream As StringWriter = New StringWriter()
        If csp.PublicOnly Then Throw New ArgumentException("CSP does not contain a private key", "csp")
        Dim parameters = csp.ExportParameters(True)

        Using stream = New MemoryStream()
            Dim writer = New BinaryWriter(stream)
            writer.Write(CByte(&H30))

            Using innerStream = New MemoryStream()
                Dim innerWriter = New BinaryWriter(innerStream)
                EncodeIntegerBigEndian(innerWriter, New Byte() {&H0})
                EncodeIntegerBigEndian(innerWriter, parameters.Modulus)
                EncodeIntegerBigEndian(innerWriter, parameters.Exponent)
                EncodeIntegerBigEndian(innerWriter, parameters.D)
                EncodeIntegerBigEndian(innerWriter, parameters.P)
                EncodeIntegerBigEndian(innerWriter, parameters.Q)
                EncodeIntegerBigEndian(innerWriter, parameters.DP)
                EncodeIntegerBigEndian(innerWriter, parameters.DQ)
                EncodeIntegerBigEndian(innerWriter, parameters.InverseQ)
                Dim length = CInt(innerStream.Length)
                EncodeLength(writer, length)
                writer.Write(innerStream.GetBuffer(), 0, length)
            End Using

            Dim base64 = Convert.ToBase64String(stream.GetBuffer(), 0, CInt(stream.Length)).ToCharArray()
            outputStream.Write("-----BEGIN RSA PRIVATE KEY-----" & vbLf)

            For i = 0 To base64.Length - 1 Step 64
                outputStream.Write(base64, i, Math.Min(64, base64.Length - i))
                outputStream.Write(vbLf)
            Next

            outputStream.Write("-----END RSA PRIVATE KEY-----")
        End Using

        Return outputStream.ToString()
    End Function

    Private Shared Sub EncodeIntegerBigEndian(ByVal stream As BinaryWriter, ByVal value As Byte(), Optional ByVal forceUnsigned As Boolean = True)
        stream.Write(CByte(&H2))
        Dim prefixZeros = 0

        For i = 0 To value.Length - 1
            If value(i) <> 0 Then Exit For
            prefixZeros += 1
        Next

        If value.Length - prefixZeros = 0 Then
            EncodeLength(stream, 1)
            stream.Write(CByte(0))
        Else

            If forceUnsigned AndAlso value(prefixZeros) > &H7F Then
                EncodeLength(stream, value.Length - prefixZeros + 1)
                stream.Write(CByte(0))
            Else
                EncodeLength(stream, value.Length - prefixZeros)
            End If

            For i = prefixZeros To value.Length - 1
                stream.Write(value(i))
            Next
        End If
    End Sub

    Private Shared Sub EncodeLength(ByVal stream As BinaryWriter, ByVal length As Integer)
        If length < 0 Then Throw New ArgumentOutOfRangeException("length", "Length must be non-negative")

        If length < &H80 Then
            stream.Write(CByte(length))
        Else
            Dim temp = length
            Dim bytesRequired = 0

            While temp > 0
                temp >>= 8
                bytesRequired += 1
            End While

            stream.Write(CByte((bytesRequired Or &H80)))

            For i = bytesRequired - 1 To 0
                stream.Write(CByte((length >> (8 * i) & &HFF)))
            Next
        End If
    End Sub

    Public Shared Function ExportPublicKey(ByVal csp As RSACryptoServiceProvider) As String
        Dim outputStream As StringWriter = New StringWriter()
        Dim parameters = csp.ExportParameters(False)

        Using stream = New MemoryStream()
            Dim writer = New BinaryWriter(stream)
            writer.Write(CByte(&H30))

            Using innerStream = New MemoryStream()
                Dim innerWriter = New BinaryWriter(innerStream)
                innerWriter.Write(CByte(&H30))
                EncodeLength(innerWriter, 13)
                innerWriter.Write(CByte(&H6))
                Dim rsaEncryptionOid = New Byte() {&H2A, &H86, &H48, &H86, &HF7, &HD, &H1, &H1, &H1}
                EncodeLength(innerWriter, rsaEncryptionOid.Length)
                innerWriter.Write(rsaEncryptionOid)
                innerWriter.Write(CByte(&H5))
                EncodeLength(innerWriter, 0)
                innerWriter.Write(CByte(&H3))

                Using bitStringStream = New MemoryStream()
                    Dim bitStringWriter = New BinaryWriter(bitStringStream)
                    bitStringWriter.Write(CByte(&H0))
                    bitStringWriter.Write(CByte(&H30))

                    Using paramsStream = New MemoryStream()
                        Dim paramsWriter = New BinaryWriter(paramsStream)
                        EncodeIntegerBigEndian(paramsWriter, parameters.Modulus)
                        EncodeIntegerBigEndian(paramsWriter, parameters.Exponent)
                        Dim paramsLength = CInt(paramsStream.Length)
                        EncodeLength(bitStringWriter, paramsLength)
                        bitStringWriter.Write(paramsStream.GetBuffer(), 0, paramsLength)
                    End Using

                    Dim bitStringLength = CInt(bitStringStream.Length)
                    EncodeLength(innerWriter, bitStringLength)
                    innerWriter.Write(bitStringStream.GetBuffer(), 0, bitStringLength)
                End Using

                Dim length = CInt(innerStream.Length)
                EncodeLength(writer, length)
                writer.Write(innerStream.GetBuffer(), 0, length)
            End Using

            Dim base64 = Convert.ToBase64String(stream.GetBuffer(), 0, CInt(stream.Length)).ToCharArray()
            outputStream.Write("-----BEGIN PUBLIC KEY-----" & vbLf)

            For i = 0 To base64.Length - 1 Step 64
                outputStream.Write(base64, i, Math.Min(64, base64.Length - i))
                outputStream.Write(vbLf)
            Next

            outputStream.Write("-----END PUBLIC KEY-----")
        End Using

        Return outputStream.ToString()
    End Function

    Public Shared Function ImportPublicKey(ByVal pem As String) As RSACryptoServiceProvider
        Dim pr As PemReader = New PemReader(New StringReader(pem))
        Dim publicKey As AsymmetricKeyParameter = CType(pr.ReadObject(), AsymmetricKeyParameter)
        Dim rsaParams As RSAParameters = DotNetUtilities.ToRSAParameters(CType(publicKey, RsaKeyParameters))
        Dim csp As RSACryptoServiceProvider = New RSACryptoServiceProvider()
        csp.ImportParameters(rsaParams)
        Return csp
    End Function
#End Region


    Private Sub btnPostAnyway_ServerClick(sender As Object, e As EventArgs) Handles btnPostAnyway.ServerClick
        Dim err As String = Nothing
        Dim errctr As Integer = 0
        Dim xerr As String = Nothing
        Dim strChecker As String = Nothing
        Try

            Dim _nclassEOR As New eOR
            Dim _nClassPost As New Process
            Dim eORNO As String = Nothing
            Dim isTaxpayer As Boolean = False

            '    btnPostAnyway.Attributes.Add("display", "")
            SPIDCREFNO = hdnTxnRefNo.Value

            If _nclassEOR.isEOR_Exists(SPIDCREFNO) = False And GatewayStatus = "FAILED TO INQUIRE" And GatewayStatusID = "FAILED TO INQUIRE" Then
                If _nclassEOR.isEOR_Exists(SPIDCREFNO) = False Then
                    Process.ACCTNO = _nclassEOR.getACCTNO(SPIDCREFNO)
                    cSessionLoader._pTDN = "'" & hdnTDN.Value.Replace("; ", "") & "'" '_nclassEOR.getTDN(Process.ACCTNO)
                    Process.Gateway_Selected = hdnGateWay.Value
                    Process.GatewayRefNo = "Manually Confirmed"
                    eOR.Gateway_RefNo = "Manually Confirmed"
                    eOR.TaxPayerEmail = _nclassEOR.getEMAIL(SPIDCREFNO)
                    Process.TransactionType = _nclassEOR.getTransactionType(SPIDCREFNO)
                    eOR.SPIDC_RefNo = SPIDCREFNO
                    '   _nClassPost.START_POSTING(err,)
                    errctr = 1

                    _nClassPost.START_POSTING(err, eORNO, isTaxpayer, Process.GatewayRefNo, strChecker)

                    ' Response.Write(strChecker)
                    hdnErr.Value = strChecker
                    hdnErr2.Value = strChecker


                    Exit Sub
                    If String.IsNullOrEmpty(err) = False Then
                        Response.Write(errctr & ";" & err)
                        Exit Sub
                    End If
                    errctr = 2

                    hdnErr3.Value = ";START: _GenerateReport_eOR"
                    _GenerateReport_eOR(1, Process.TransactionType, eORNO, xerr)
                    hdnErr3.Value += ";_GenerateReport_eOR: " & xerr
                    errctr = 3
                    Dim _nClass As New cDalPayment
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                    GatewayStatus = "Manually Confirmed"
                    GatewayStatusID = "SUCCESS"
                    _nClass._pSubUpdateOnlinePaymentInfo2(hdnGateWay.Value, SPIDCREFNO _
                                  , GatewayStatus _
                                  , Process.GatewayRefNo _
                                  , cSessionUser._pUserID _
                                  , GatewayStatusID)
                    errctr = 4

                    _nClass.Insert_History2(GatewayStatusID, GatewayStatus)


                    load_GridviewPaging()
                    errctr = 5
                End If


            End If

            ' hdnErr3.Value = ";errctr:" & errctr & ";xerr:" & xerr
        Catch ex As Exception
            Response.Write(errctr & ";" & err & ";" & ex.Message & strChecker)
        End Try
    End Sub

    Public Sub _GenerateReport_eOR(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String, Optional ByRef xerr As String = Nothing)
        Try


            Dim _nclassEOR As New eOR
            Dim _nDataTable0 As New DataTable
            _nDataTable0 = _nclassEOR.Print_Template
            Dim _nDataTable1 As New DataTable
            _nDataTable1 = _nclassEOR.Print_Report(eORNO)
            Dim _nDataTable2 As New DataTable
            _nDataTable2 = _nclassEOR.Print_TOP(eORNO)

            Report_EOR.Reset()
            xerr += ";1:OK"

            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo

            For Each extension As RenderingExtension In Report_EOR.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format

            xerr += ";2:OK"


            If TAXTYPE_eOR = "REAL PROPERTY TAX" Or TAXTYPE_eOR = "RPT" Then
                Report_EOR.LocalReport.ReportPath = _gResxRdlc.pEOR_RPT2
            ElseIf TAXTYPE_eOR = "BUSINESS PERMIT" Or TAXTYPE_eOR = "BP" Then
                Report_EOR.LocalReport.ReportPath = _gResxRdlc.pEOR_BP2
            End If

            Report_EOR.LocalReport.EnableExternalImages = False

            Report_EOR.LocalReport.DataSources.Clear()

            xerr += ";3:OK:" & TAXTYPE_eOR

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

            xerr += ";4:OK:"

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

            xerr += ";5:OK:"

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
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully')", True)
                    Exit Sub
                End If

                'If sent = True Then
                '    Response.Clear()
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                'Else
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + err + "');", True)
                'End If

            End If

            xerr += ";6:_send:" & _send
            xerr += ";END"

        Catch ex As Exception
            xerr += ex.Message
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub
End Class