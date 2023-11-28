Imports System.Data
Imports System.Drawing
Imports Microsoft.Reporting.WebForms
Imports SPIDC.Resources
Imports System.Reflection

Imports RPTIMS_DLL

Public Class RPTIMSAssessmentBilling
    Inherits System.Web.UI.Page
    'Dim total As Double = 0
    'Dim qry As Integer = 0
    Dim NoofcountTDN As Long
    'Dim _nMode As String
    'Dim _nSvrDateValue As String
    'Dim checkedItems
    'Dim usertmp As String = cCookieUser._pUserID.Replace(".", "")

    'Dim tdn As String
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    Try
    '        '----------------------------------
    '        If Not IsPostBack Then
    '            If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
    '                Response.Redirect("//Login.aspx")
    '            End If
    '            _oTextBoxYear.Text = Now.Year
    '            Get_RPTAccounts()
    '            _oTextBoxBillingDate.Text = Format(Now, "MM/dd/yyyy")
    '        Else
    '            _oTextBoxTDN.Text = "1"
    '            tdn = Request("__EVENTARGUMENT")
    '            _oTextBoxTDN.Text = "2"
    '            Dim action As String = Request("__EVENTTARGET")
    '            _oTextBoxTDN.Text = "3"
    '            If action = "Process" Then
    '                _oTextBoxTDN.Text = "4"
    '                _mCreate_temp_per_Email()
    '                _oTextBoxTDN.Text = "5"
    '                _mInsertBrHlp(tdn)
    '                _oTextBoxTDN.Text = "6" & tdn
    '                'kala ko nabalik mona ? pero ok na muna yan nkita na d error 
    '                do_process(tdn)

    '            End If

    '        End If
    '        '----------------------------------
    '    Catch ex As Exception
    '        _oTextBoxTDN.Text = ex.ToString


    '    End Try
    'End Sub

    'Private Sub _mCreate_temp_per_Email()
    '    usertmp = cCookieUser._pUserID.Replace(".", "")
    '    Dim _nClass As New cDalPDSRPTAS
    '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
    '    _nClass._pEmail = usertmp
    '    _nClass._pSubCreateTableBrHlp()
    'End Sub
    'Private Sub _mInsertBrHlp(tdn)
    '    usertmp = cCookieUser._pUserID.Replace(".", "")
    '    Dim _nClass As New cDalPDSRPTAS
    '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
    '    _nClass._pEmail = usertmp
    '    _nClass._pTDN = tdn
    '    _nClass._pSubInsertBrHlp()
    'End Sub
    'Private Sub Get_RPTAccounts()
    '    Try
    '        '----------------------------------

    '        Dim _nGridView As New GridView
    '        _nGridView = _oGridViewRPT
    '        _nGridView.DataSourceID = Nothing

    '        Dim _nClass As New cDalGetRPT
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
    '        _nClass._pUserID = cCookieUser._pUserID.Replace(".", "")
    '        _nClass._pSubSelect()

    '        Dim _nDataTable As New DataTable
    '        _nDataTable = _nClass._pDataTable

    '        Try
    '            '----------------------------------
    '            If _nDataTable.HasErrors Then
    '                'Griderr = True
    '                '_mSubShowBlank()
    '            End If

    '            If _nDataTable.Rows.Count > 0 Then
    '                _nGridView.DataSource = _nDataTable
    '                _nGridView.DataBind()

    '            Else
    '                snackbar("red", "No Records Found.")
    '            End If
    '            '----------------------------------
    '        Catch ex As Exception
    '            snackbar("red", ex.Message)
    '            'GridErr = True
    '            '_mSubShowBlank()
    '        End Try
    '        '----------------------------------
    '    Catch ex As Exception



    '    End Try
    'End Sub

    'Sub do_process(tdn)
    '    Try

    '        Dim _nclass As New cDalPDSRPTAS
    '        _oTextBoxTDN.Text = "6.1" & tdn
    '        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
    '        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
    '        _nclass._pSubGetSpecificRecord_getid()
    '        _msubGetServerDate()
    '        _nclass._mctr_no = cPageSession_Billing_EntryView._pOrigSrvDateValue

    '        ' _mSubLoadBrHlp()

    '        Dim cls_rptas As New clsRPT

    '        cls_rptas.RPTAS_SERVER = cGlobalConnections._pSqlCxn_RPTAS.DataSource
    '        cls_rptas.RPTASWEB_SERVER = cGlobalConnections._pSqlCxn_RPTIMS.DataSource

    '        cls_rptas.RPTAS_xDataBase = cGlobalConnections._pSqlCxn_RPTAS.Database
    '        cls_rptas.RPTASWEB_xDataBase = cGlobalConnections._pSqlCxn_RPTIMS.Database

    '        cls_rptas.RPTAS_xUID = _mSubUIPW("UI")
    '        cls_rptas.RPTASWEB_xUID = _mSubUIPWWEB("UI")

    '        cls_rptas.RPTAS_xPW = _mSubUIPW("PW")
    '        cls_rptas.RPTASWEB_xPW = _mSubUIPWWEB("PW")

    '        cls_rptas.Region_TMP = _mSubREGION()


    '        cls_rptas.User_TMP = usertmp 'remove the "." 

    '        cls_rptas.MultiTDN = 1

    '        cls_rptas.Tdn = tdn

    '        cls_rptas.bill_date = _oTextBoxBillingDate.Text

    '        cls_rptas.SvrDateValue = cPageSession_Billing_EntryView._pOrigSrvDateValue
    '        'cls_rptas.Quater_set = _oTextBoxAdvSetQuater.Text
    '        'IIf(gpub_IsBackEncoding, "tmp0002", "tmp0001") & gSysUser & "_" & mvar_Time
    '        If RadioQtr1.Checked = True Then
    '            cls_rptas.Quater_set = "1"
    '        End If
    '        If RadioQtr2.Checked = True Then
    '            cls_rptas.Quater_set = "2"
    '        End If
    '        If RadioQtr3.Checked = True Then
    '            cls_rptas.Quater_set = "3"
    '        End If
    '        If RadioQtr4.Checked = True Then
    '            cls_rptas.Quater_set = "4"
    '        End If

    '        cls_rptas.RPTAS_ForYear = _oTextBoxYear.Text
    '        'Trim(Str(((Month(Now) - 1) \ 3) + 1))
    '        cls_rptas.SvrDateValue = _nclass._mctr_no
    '        _oTextBoxTDN.Text = "6.2" & tdn
    '        'gang dito lang ayaw magloadform
    '        cls_rptas.LoadForm()
    '        _oTextBoxTDN.Text = "6.3" & tdn
    '        '   _mSubDataBindSearch(True)
    '        '_oButtonTOP.Enabled = True
    '        '_oButtonProcess.Enabled = False
    '        '_oButtonSet.Enabled = False
    '        Response.Redirect("/VS2014.RPTIMS/RPTReport.aspx?ReportType=TOP")

    '        ' _mSubDataPrint()
    '    Catch ex As Exception
    '        _oTextBoxTDN.Text = ex.ToString
    '    End Try

    'End Sub
    'Private Sub _mSubDataPrint()
    '    Try
    '        ' The Report

    '        Dim _nClass As New cDalPDSRPTAS
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
    '        usertmp = cCookieUser._pUserID.Replace(".", "")
    '        '_nClass._pTDN =
    '        _nClass._pUseTableTmpBill = "tmp0001" & usertmp & "_" & cPageSession_Billing_EntryView._pOrigSrvDateValue
    '        _nClass._pEmail = usertmp
    '        _nClass._pSubPrint()

    '        Dim _nDataTable As New DataTable
    '        _nDataTable = _nClass._pDataTable



    '        If _nDataTable.HasErrors Then
    '            Return
    '        End If

    '        If _nDataTable.Rows.Count <= 0 Then
    '            _oMSRV.Enabled = False
    '            'Return

    '        Else
    '            _oMSRV.Enabled = True
    '        End If
    '        _oMSRV.Reset()
    '        '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
    '        Dim info As FieldInfo

    '        For Each extension As RenderingExtension In _oMSRV.LocalReport.ListRenderingExtensions
    '            If extension.Name <> "PDF" Then
    '                info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
    '                info.SetValue(extension, False)
    '            End If
    '        Next
    '        '--------END (Shows only PDF as EXPORT Extension)-uneditable print format


    '        _oMSRV.LocalReport.ReportPath = _gResxRdlc._pReportBilling
    '        _oMSRV.LocalReport.EnableExternalImages = True

    '        _oMSRV.LocalReport.DataSources.Clear()

    '        Dim _nReportDataSource As New ReportDataSource
    '        _nReportDataSource.Name = "DataSet1" ' The Name of the dataset in the RDLC Designer.
    '        _nReportDataSource.Value = _nDataTable
    '        _oMSRV.LocalReport.DataSources.Add(_nReportDataSource)


    '        Dim paramList As New List(Of ReportParameter)
    '        paramList.Add(New ReportParameter("ReportParameter1", "Republika ng Pilipinas"))
    '        paramList.Add(New ReportParameter("ReportParameter2", "Republika ng Pilipinas"))
    '        paramList.Add(New ReportParameter("ReportParameter3", "Republika ng Pilipinas"))
    '        paramList.Add(New ReportParameter("ReportParameter4", "Republika ng Pilipinas"))
    '        paramList.Add(New ReportParameter("ReportParameter5", "Republika ng Pilipinas"))
    '        paramList.Add(New ReportParameter("ReportParameter6", "Republika ng Pilipinas"))
    '        paramList.Add(New ReportParameter("ReportParameter7", "Republika ng Pilipinas"))
    '        paramList.Add(New ReportParameter("ReportParameter8", "Republika ng Pilipinas"))
    '        paramList.Add(New ReportParameter("ReportParameter9", "Republika ng Pilipinas"))
    '        _oMSRV.LocalReport.SetParameters(paramList)


    '        _oMSRV.AsyncRendering = True

    '        _oMSRV.LocalReport.Refresh()
    '        _oMSRV.Enabled = True
    '        'renderedBytes = _oMSRV.LocalReport.Render("Image", "<DeviceInfo><OutputFormat>JPG</OutputFormat></DeviceInfo>")

    '        '---------------------------------- 
    '        '_nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS


    '        '_nClass._pimgfile = renderedBytes
    '        ' _nClass._pSubInsertimage()
    '        '_oMSRV.Visible = True
    '    Catch ex As Exception
    '        _oTextBoxTDN.Text = ex.Message
    '    End Try
    'End Sub


    'Sub snackbar(Color As String, Caption As String)
    '    If Color = "red" Then
    '        _oLabelSnackbar.Text = Caption
    '        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

    '    ElseIf Color = "green" Then
    '        _oLabelSnackbargreen.Text = Caption
    '        ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
    '    End If
    'End Sub
End Class

