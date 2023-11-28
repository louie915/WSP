
Imports Microsoft.Reporting.WebForms
Imports System.IO
Imports SPIDC.Resources
Imports RPTIMS_TOIMS_DLL
Public Class LGUMainPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '----------------------------------
            If Not IsPostBack Then
                _mSubDataLoadTransactions()
                'BtnCancel.Visible = False

            Else
                Dim Action As String = Request("__EVENTTARGET")
                Dim Val As String = Request("__EVENTARGUMENT")


                If Action = "PrintOR" Then
                    _mSubPrintOR(Val)
                End If
                'If Action = "BtnOrPrint" Then
                '    _mSubDataLoadSelectedTransactions()
                '    radFilterOptionTrasactionType.Disabled = True
                '    radFilterOptionForm.Disabled = True
                '    BtnCancel.Visible = True
                '    BtnPost.Disabled = False

                'ElseIf Action = "BtnCancel" Then
                '    _mSubDataLoadTransactions()
                '    radFilterOptionTrasactionType.Disabled = False
                '    radFilterOptionForm.Disabled = False
                '    BtnCancel.Visible = False
                '    BtnPost.Disabled = True
                '    _oMSRV.Visible = False
                'ElseIf Action = "BtnPost" Then
                '    BtnPost.Disabled = True
                '    _mSubPrintOR()

                '    Dim _nClBP As New cDalGlobalConnectionsDefault
                '    _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                '    _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                '    _nClBP._pSubRecordSelectSpecific()

                '    Dim _nClass As New cDalBPSOS

                '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                '    _nClass._pToimsServer = cGlobalConnections._pSqlCxn_TIMS.DataSource
                '    _nClass._pToimsDB = cGlobalConnections._pSqlCxn_TIMS.Database
                '    _nClass._pLocServer = _nClBP._pDBDataSource
                '    _nClass._pLocDB = _nClBP._pDBInitialCatalog

                '    _nClass._pSubGetPayFileExtn()

                'End If

            End If
        Catch ex As Exception

        End Try
    End Sub


    Sub _mSubDataLoadTransactions()
        Dim _nGridView As New GridView
        _nGridView = _oGVTransaction
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalOnlineService
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nclass._pTIMSDatabaseName = cGlobalConnections._pSqlCxn_TIMS.Database
        _nclass._pBPDatabaseName = cGlobalConnections._pSqlCxn_BPLTIMS.Database
        _nclass._pRPTDatabaseName = cGlobalConnections._pSqlCxn_RPTIMS.Database
        _nclass._pOAIMSDatabaseName = cGlobalConnections._pSqlCxn_OAIMS.Database
        _nclass._pEmail = cSessionUser._pUserID
        _nclass._pSubCreateLoadRecords()
        _nclass._pSubSelectCreatedTransactions()
        _nclass._pSubSelectTransactions()
        _nGridView.DataSource = _nclass._mDataTable
        _nGridView.DataBind()
    End Sub
    Sub _mSubDataLoadSelectedTransactions()

        Dim _nclass As New cDalOnlineService

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TOIMS
        _nclass._pEmail = cSessionUser._pUserID
        _nclass._pTransactionType = radFilterOptionTrasactionType.Value
        _nclass._pSubGetSpecificUser()
        If _nclass._pUser = "" Then
            snackbar("red", "No Account User Link in TOIMS") '------------ green red 
            BtnCancel2.Enabled = False
            BtnOrPrint2.Enabled = True
            BtnPost2.Enabled = False
            Exit Sub
        End If

        If _nclass._pForm = "" Then
            snackbar("red", "No Booklet Assign to this User") '------------ green red 
            BtnCancel2.Visible = False
            BtnOrPrint2.Enabled = False
            BtnPost2.Enabled = False
            radFilterOptionTrasactionType.Disabled = False
            radFilterOptionTrasactionType.Value = ""
            Exit Sub
        End If

        BtnCancel2.Visible = True
        BtnPost2.Enabled = True

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nclass._pServerName = cGlobalConnections._pSqlCxn_TOIMS.DataSource
        _nclass._pDatabaseName = cGlobalConnections._pSqlCxn_TOIMS.Database
        _nclass._pTIMSDatabaseName = cGlobalConnections._pSqlCxn_TIMS.Database
        _nclass._pBPDatabaseName = cGlobalConnections._pSqlCxn_BPLTIMS.Database
        _nclass._pRPTDatabaseName = cGlobalConnections._pSqlCxn_RPTIMS.Database
        _nclass._pOAIMSDatabaseName = cGlobalConnections._pSqlCxn_OAIMS.Database
        _nclass._pTransactionType = radFilterOptionTrasactionType.Value
        _nclass._pEmail = cSessionUser._pUserID

        _nclass._pSubCreateSelectedRecord()
        _mSubDataLoadCreatedTransactions()
    End Sub
    Sub _mSubDataLoadCreatedTransactions()
        Dim _nGridView As New GridView
        _nGridView = _oGVTransaction
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalOnlineService
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nclass._pSubSelectCreatedTransactions()
        _nGridView.DataSource = _nclass._mDataTable
        _nGridView.DataBind()
    End Sub

    Sub _mSubPrintOR(Optional ByVal xORNumber As String = "")

        Dim _nclass As New cDalOnlineService

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nclass._pServerName = cGlobalConnections._pSqlCxn_TOIMS.DataSource
        _nclass._pDatabaseName = cGlobalConnections._pSqlCxn_TOIMS.Database
        _nclass._pOAIMSDatabaseName = cGlobalConnections._pSqlCxn_OAIMS.Database
        _nclass._pTransactionType = radFilterOptionTrasactionType.Value
        _nclass._pEmail = cSessionUser._pUserID
        _nclass._pSubPostOR()

        'BtnPost2.Enabled = False

        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        If radFilterOptionTrasactionType.Value = "Business Payment" Then
            _nclass._pDatabaseName = cGlobalConnections._pSqlCxn_TOIMS.Database
        Else
            _nclass._pDatabaseName = cGlobalConnections._pSqlCxn_TIMS.Database
        End If
        _nclass._pTransactionType = radFilterOptionTrasactionType.Value
        _nclass._pEmail = cSessionUser._pUserID
        '_nclass._pSubSelectCreatedTransactions()
        _nclass._pORPrint = xORNumber
        If xORNumber <> "" Then
            _nclass._pSinglePrint = True
        Else
            _nclass._pSinglePrint = False
        End If

        _nclass._pSubSelectPrintOR()
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

            '_oMSRV.Visible = True
        End If

        _oMSRV.Reset()




        If radFilterOptionTrasactionType.Value = "CTC Individual" Then
            _oMSRV.LocalReport.ReportPath = _gResxRdlc.pPrintIndividualOR
        ElseIf radFilterOptionTrasactionType.Value = "CTC Corporation" Then
            _oMSRV.LocalReport.ReportPath = _gResxRdlc.pPrintCorporationOR
        ElseIf radFilterOptionTrasactionType.Value = "Business Payment" Then
            _oMSRV.LocalReport.ReportPath = _gResxRdlc.pPrintBusinessPayment
        End If


        _oMSRV.LocalReport.EnableExternalImages = True

        _oMSRV.LocalReport.DataSources.Clear()
        Dim _nReportDataSource As New ReportDataSource
        _nReportDataSource.Name = "DataSet1" ' The Name of the dataset in the RDLC Designer.
        _nReportDataSource.Value = _nDataTable
        _oMSRV.LocalReport.DataSources.Add(_nReportDataSource)

        Dim _nDate As String = FormatDateTime(Now, DateFormat.ShortDate)
        Dim _nDateTime As String = FormatDateTime(Now, DateFormat.ShortTime)

        Dim paramList As New List(Of ReportParameter)
        Dim xTotalAmount As Double
        Dim xAmountInWord As String

        If radFilterOptionTrasactionType.Value = "Business Payment" Then
            xTotalAmount = Val(_nDataTable.Rows(0).Item("AMOUNTDUE").ToString) + Val(_nDataTable.Rows(0).Item("PENDUE").ToString)
            xAmountInWord = ConvertNum(xTotalAmount)
            paramList.Add(New ReportParameter("RptORNO_SRSTIME_COLLECOFFICER_RDATE_SEQ",
                                 _nDataTable.Rows(0).Item("SRS").ToString & "-" & _nDateTime & "-" & "COLLECTINGOFFICER" & Format(CDate(_nDate), "mmddyyyy") & "SEQ"))
            paramList.Add(New ReportParameter("AmountInWord", xAmountInWord))
        End If
        _oMSRV.LocalReport.SetParameters(paramList)


        '_oMSRV.AsyncRendering = True

        '_oMSRV.LocalReport.Refresh()
        '_oMSRV.Visible = True
        _oMSRV.Visible = False

        'Dim warnings As Microsoft.Reporting.WebForms.Warning() = Nothing
        'Dim streamids As String() = Nothing
        'Dim mimeType As String = Nothing
        'Dim encoding As String = Nothing
        'Dim extension As String = Nothing
        ''Dim bytes As Byte() = Nothing
        ''bytes = _oMSRV.LocalReport.Render("PDF", "", mimeType, encoding, extension, streamids, warnings)
        ''Dim fs As FileStream = New FileStream("c:\report.pdf", FileMode.OpenOrCreate)
        ''Dim data As Byte() = New Byte(fs.Length - 1) {}
        ''fs.Write(bytes, 0, bytes.Length)
        ''fs.Close()
        'Dim oPagesettup As System.Drawing.Printing.PageSettings = New System.Drawing.Printing.PageSettings()
        'oPagesettup.Landscape = False
        '_oMSRV.SetPageSettings(oPagesettup)


        'Dim ps As System.Drawing.Printing.PageSettings = New System.Drawing.Printing.PageSettings()
        'ps.Landscape = False
        'ps.PaperSize = New System.Drawing.Printing.PaperSize("A4", 827, 1170)
        '_oMSRV.SetPageSettings(ps)

        ConvertReportToPDF(_oMSRV.LocalReport)
        'HiddenPath.Value = AppDomain.CurrentDomain.BaseDirectory & "sample" & ".pdf"
        'Export(_oMSRV.LocalReport, "c:\filename (51).pdf")

        If BtnPost2.Enabled = False Then
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>")
            sb.Append("isLoaded();")
            sb.Append("</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "PrintScript", sb.ToString())
        End If

        BtnPost2.Enabled = False



        'Dim bytes As Byte() = _oMSRV.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)
        'Response.Buffer = True
        'Response.Clear()
        'Response.ContentType = mimeType
        'Response.AddHeader("content-disposition", "attachment; filename= filename" & "." & extension)
        'Response.OutputStream.Write(bytes, 0, bytes.Length)
        'Response.Flush()
        ''Response.[End]()


    End Sub

    Private Function ConvertReportToPDF(ByVal rep As LocalReport) As String
        Dim reportType As String = "PDF"
        Dim mimeType As String
        Dim encoding As String
        Dim deviceInfo As String = "<DeviceInfo>" & "  <OutputFormat>PDF</OutputFormat>" & "  <MarginTop>0.2in</MarginTop>" & "  <MarginLeft>0.2in</MarginLeft>" & "  <MarginRight>0.2in</MarginRight>" & "  <MarginBottom>0.2in</MarginBottom>" & "</DeviceInfo>"
        Dim warnings As Warning()
        Dim streamIds As String()
        Dim extension As String = String.Empty
        Dim bytes As Byte() = rep.Render(reportType, deviceInfo, mimeType, encoding, extension, streamIds, warnings)
        Dim localPath As String = AppDomain.CurrentDomain.BaseDirectory
        'Dim fileName As String = Guid.NewGuid().ToString() & ".pdf"
        Dim fileName As String = "ORPrint" & ".pdf"
        localPath = localPath & "Temp/" & fileName
        System.IO.File.WriteAllBytes(localPath, bytes)
        Return localPath
    End Function
    Public Function Export(ByVal rpt As LocalReport, ByVal filePath As String) As String
        Dim ack As String = ""

        Try
            Dim warnings As Warning()
            Dim streamids As String()
            Dim mimeType As String
            Dim encoding As String
            Dim extension As String
            Dim bytes As Byte() = rpt.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

            Using stream As FileStream = File.OpenWrite(filePath)
                stream.Write(bytes, 0, bytes.Length)
            End Using

            Return ack
        Catch ex As Exception
            ack = ex.InnerException.Message
            Return ack
        End Try
    End Function




    'Private Sub BtnPost_ServerClick(sender As Object, e As EventArgs) Handles BtnPost2.ServerClick
    '    BtnPost2.Enabled = False
    '    _mSubPrintOR()

    '    Dim _nClBP As New cDalGlobalConnectionsDefault
    '    _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
    '    _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
    '    _nClBP._pSubRecordSelectSpecific()

    '    Dim _nClass As New cDalBPSOS

    '    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
    '    _nClass._pToimsServer = cGlobalConnections._pSqlCxn_TIMS.DataSource
    '    _nClass._pToimsDB = cGlobalConnections._pSqlCxn_TIMS.Database
    '    _nClass._pLocServer = _nClBP._pDBDataSource
    '    _nClass._pLocDB = _nClBP._pDBInitialCatalog

    '    _nClass._pSubGetPayFileExtn()
    'End Sub


    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub
    Protected Sub BtnClick(sender As Object, e As EventArgs) Handles _
    BtnCancel2.Click,
    BtnPost2.Click,
    BtnOrPrint2.Click
        Try
            '----------------------------------
            Select Case DirectCast(sender, Button).ID

                Case BtnCancel2.ID
                    _mSubDataLoadTransactions()
                    radFilterOptionTrasactionType.Disabled = False
                    radFilterOptionForm.Disabled = False
                    BtnCancel2.Visible = False
                    BtnPost2.Enabled = False
                    _oMSRV.Visible = False
                    radFilterOptionTrasactionType.Value = ""
                Case BtnOrPrint2.ID
                    If radFilterOptionTrasactionType.Value = "RPT Payment" Then
                        _mSubDataLoadSelectedTransactionRPT()

                    Else
                        _mSubDataLoadSelectedTransactions()
                    End If
                Case BtnPost2.ID
                    If radFilterOptionTrasactionType.Value = "RPT Payment" Then
                        _mPostRPT()
                    Else
                        _mSubPrintOR()

                        If radFilterOptionTrasactionType.Value = "Business Payment" Then
                            Dim _nClBP As New cDalGlobalConnectionsDefault
                            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                            _nClBP._pSubRecordSelectSpecific()

                            Dim _nClass As New cDalBPSOS

                            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                            _nClass._pToimsServer = cGlobalConnections._pSqlCxn_TIMS.DataSource
                            _nClass._pToimsDB = cGlobalConnections._pSqlCxn_TIMS.Database
                            _nClass._pLocServer = _nClBP._pDBDataSource
                            _nClass._pLocDB = _nClBP._pDBInitialCatalog

                            _nClass._pSubGetPayFileExtn()
                            BtnOrPrint2.Enabled = False
                        End If
                    End If
                    Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                    sb.Append("<script language='javascript'>")
                    sb.Append("sessionStorage.setItem('_oGVTransaction','table-cell')")
                    sb.Append("</script>")
                    ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())
            End Select
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Sub _mPostRPT()
        Try
            Dim _nclass As New cDalPDSRPTAS
            ''_nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            ''_nclass._pSubGetAssessno()
            ''_msubGetServerDate()
            ''_nclass._mctr_no = cPageSession_Billing_EntryView._pOrigSrvDateValue

            Dim cls_rptas As New clsRPT_TOIMS

            cls_rptas.TOIMS_Server = cGlobalConnections._pSqlCxn_TOIMS.DataSource
            cls_rptas.TOIMS_xDataBase = cGlobalConnections._pSqlCxn_TOIMS.Database
            cls_rptas.TOIMS_xUID = _mSubUIPWTOIMS("UI")
            cls_rptas.TOIMS_xPW = _mSubUIPWTOIMS("PW")

            cls_rptas.RPTASWEB_xUID = _mSubUIPW("UI", "RPTIMS")
            cls_rptas.RPTAS_xUID = _mSubUIPWWEB("UI")

            cls_rptas.RPTASWEB_xPW = _mSubUIPW("PW", "RPTIMS")
            cls_rptas.RPTAS_xPW = _mSubUIPWWEB("PW")

            cls_rptas.RPTASTEMP_xDataBase = "RPTASTEMP"


            cls_rptas.Region_TMP = _mSubREGION()


            cls_rptas.RPTAS_SERVER = cGlobalConnections._pSqlCxn_RPTIMS.DataSource
            cls_rptas.RPTASWEB_SERVER = cGlobalConnections._pSqlCxn_RPTAS.DataSource

            cls_rptas.RPTAS_xDataBase = cGlobalConnections._pSqlCxn_RPTIMS.Database
            cls_rptas.RPTASWEB_xDataBase = cGlobalConnections._pSqlCxn_RPTAS.Database





            cls_rptas.User_TMP = cSessionUser._pUserID.Replace(".", "") 'remove the "." 
            cls_rptas.User_TMP2 = cSessionUser._pUserID
            'cls_rptas.MultiTDN = 1

            '            cls_rptas.Tdn = Replace(tdn, "'", "")

            ' TXTTRAPERROR.Value = "Initializing DATE"
            cls_rptas.bill_date = Format(Now, "MM/dd/yyyy")

            'cls_rptas.SvrDateValue = cPageSession_Billing_EntryView._pOrigSrvDateValue
            cls_rptas.SvrDateValue = cPageSession_Billing_EntryView._pOrigSrvDateValue
            'cls_rptas.ASSESSNO = Mid(_nclass._pAssessNo, 2)

            cls_rptas.POST_PAYMENT()

            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_TOIMS
            _nclass._pEmail = cSessionUser._pUserID
            _nclass._pSubSelectUser()


            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nclass._pLocDB = cGlobalConnections._pSqlCxn_RPTIMS.Database
            _nclass._pSubUpdatePostedData()

            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nclass._pLocDB = cGlobalConnections._pSqlCxn_RPTAS.Database
            _nclass._pLocServer = cGlobalConnections._pSqlCxn_RPTAS.DataSource
            _nclass._pSubAcquireData()


        Catch ex As Exception
        End Try
    End Sub
    Sub _mAcquiredataRPT()

    End Sub
    Sub _mSubDataLoadSelectedTransactionRPT()
        Dim _nclass As New cDalPDSRPTAS
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetAssessno()
        _msubGetServerDate()
        _nclass._mctr_no = cPageSession_Billing_EntryView._pOrigSrvDateValue

        Dim cls_rptas As New clsRPT_TOIMS

        cls_rptas.TOIMS_Server = cGlobalConnections._pSqlCxn_TOIMS.DataSource
        cls_rptas.TOIMS_xDataBase = cGlobalConnections._pSqlCxn_TOIMS.Database
        cls_rptas.TOIMS_xUID = _mSubUIPWTOIMS("UI")
        cls_rptas.TOIMS_xPW = _mSubUIPWTOIMS("PW")

        cls_rptas.RPTASWEB_xUID = _mSubUIPW("UI", "RPTIMS")
        cls_rptas.RPTAS_xUID = _mSubUIPWWEB("UI")

        cls_rptas.RPTASWEB_xPW = _mSubUIPW("PW", "RPTIMS")
        cls_rptas.RPTAS_xPW = _mSubUIPWWEB("PW")

        cls_rptas.RPTASTEMP_xDataBase = "RPTASTEMP"


        cls_rptas.Region_TMP = _mSubREGION()


        cls_rptas.RPTAS_SERVER = cGlobalConnections._pSqlCxn_RPTIMS.DataSource
        cls_rptas.RPTASWEB_SERVER = cGlobalConnections._pSqlCxn_RPTAS.DataSource

        cls_rptas.RPTAS_xDataBase = cGlobalConnections._pSqlCxn_RPTIMS.Database
        cls_rptas.RPTASWEB_xDataBase = cGlobalConnections._pSqlCxn_RPTAS.Database





        cls_rptas.User_TMP = cSessionUser._pUserID.Replace(".", "") 'remove the "." 
        cls_rptas.User_TMP2 = cSessionUser._pUserID
        'cls_rptas.MultiTDN = 1

        '            cls_rptas.Tdn = Replace(tdn, "'", "")

        ' TXTTRAPERROR.Value = "Initializing DATE"
        cls_rptas.bill_date = Format(Now, "MM/dd/yyyy")

        'cls_rptas.SvrDateValue = cPageSession_Billing_EntryView._pOrigSrvDateValue
        cls_rptas.SvrDateValue = _nclass._mctr_no
        cls_rptas.ASSESSNO = Mid(_nclass._pAssessNo, 2)

        cls_rptas.PROCESS_ASSESSNO()

        _mSubDataLoadRPT()
        BtnCancel2.Visible = True
        BtnPost2.Enabled = True
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

    Function _mSubUIPWTOIMS(cndtn As String) As String
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR

                ._pSubSelectUIPWTOIMS()

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

    Sub _mSubDataLoadRPT()
        Dim _nGridView As New GridView
        _nGridView = _oGVTransaction
        _nGridView.DataSourceID = Nothing
        Dim _nclass As New cDalPDSRPTAS
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        ' _nclass._pLocDB = cGlobalConnections._pSqlCxn_OAIMS.Database
        _nclass._mctr_no = cPageSession_Billing_EntryView._pOrigSrvDateValue
        _nclass._pEmail = cSessionUser._pUserID.Replace(".", "")
        _nclass._pSubSelectRPTOR()
        _nGridView.DataSource = _nclass._pDataTable
        _nGridView.DataBind()
    End Sub

    'Protected Sub BtnClick(sender As Object, e As EventArgs) Handles _
    'BtnCancel2.Click,
    'BtnPost2.Click,
    'BtnOrPrint2.Click
    '    Try
    '        '----------------------------------
    '        Select Case DirectCast(sender, Button).ID

    '            Case BtnCancel2.ID
    '                _mSubDataLoadTransactions()
    '                radFilterOptionTrasactionType.Disabled = False
    '                radFilterOptionForm.Disabled = False
    '                BtnCancel2.Visible = False
    '                BtnPost2.Enabled = False
    '                _oMSRV.Visible = False
    '                radFilterOptionTrasactionType.Value = ""
    '            Case BtnPost2.ID

    '                If radFilterOptionTrasactionType.Value = "RPT Payment" Then
    '                    _mPostRPT()
    '                Else
    '                    _mSubPrintOR()

    '                    If radFilterOptionTrasactionType.Value = "Business Payment" Then
    '                        Dim _nClBP As New cDalGlobalConnectionsDefault
    '                        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
    '                        _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
    '                        _nClBP._pSubRecordSelectSpecific()

    '                        Dim _nClass As New cDalBPSOS

    '                        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
    '                        _nClass._pToimsServer = cGlobalConnections._pSqlCxn_TIMS.DataSource
    '                        _nClass._pToimsDB = cGlobalConnections._pSqlCxn_TIMS.Database
    '                        _nClass._pLocServer = _nClBP._pDBDataSource
    '                        _nClass._pLocDB = _nClBP._pDBInitialCatalog

    '                        _nClass._pSubGetPayFileExtn()
    '                        BtnOrPrint2.Enabled = False
    '                    End If
    '                End If

    '            Case BtnOrPrint2.ID
    '                If radFilterOptionTrasactionType.Value = "RPT Payment" Then
    '                    _mSubDataLoadSelectedTransactionRPT()

    '                Else
    '                    _mSubDataLoadSelectedTransactions()
    '                End If

    '                'radFilterOptionTrasactionType.Disabled = True
    '                'radFilterOptionForm.Disabled = False

    '        End Select
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Shared Function ConvertNum(ByVal Input As Decimal) As String


        Dim formatnumber As String
        Dim numparts(10) As String ' break the number into parts
        Dim suffix(10) As String 'trillion, billion .million etc
        Dim Wordparts(10) As String  'add the number parts and suffix

        Dim output As String = Nothing

        Dim T, B, M, TH, H, C As String

        formatnumber = Format(Input, "0000000000000.00") 'format the input number to a 16 characters string by suffixing and prefixing 0s
        '
        numparts(0) = primWord(Mid(formatnumber, 1, 1)) 'Trillion

        numparts(1) = primWord(Mid(formatnumber, 2, 1)) 'hundred billion..x
        numparts(2) = primWord(Mid(formatnumber, 3, 2)) 'billion

        numparts(3) = primWord(Mid(formatnumber, 5, 1)) 'hundred million...x
        numparts(4) = primWord(Mid(formatnumber, 6, 2)) 'million

        numparts(5) = primWord(Mid(formatnumber, 8, 1)) 'hundred thousand....x
        numparts(6) = primWord(Mid(formatnumber, 9, 2)) 'thousand


        numparts(7) = primWord(Mid(formatnumber, 11, 1)) 'hundred
        numparts(8) = primWord(Mid(formatnumber, 12, 2)) 'Tens

        numparts(9) = primWord(Mid(formatnumber, 15, 2)) 'cents



        suffix(0) = " Trillion "
        suffix(1) = " Hundred "  '....x
        suffix(2) = " Billion "
        suffix(3) = " Hundred " '  ....x
        suffix(4) = " Million "
        suffix(5) = " Hundred " ' .....x
        suffix(6) = " Thousand "
        suffix(7) = " Hundred "
        suffix(8) = " "
        suffix(9) = ""

        For i = 0 To 9
            If numparts(i) <> "" Then
                Wordparts(i) = numparts(i) & suffix(i)
            End If

            T = Wordparts(0)

            If Wordparts(1) <> "" And Wordparts(2) = "" Then
                B = Wordparts(1) & " Billion "
            Else
                B = Wordparts(1) & Wordparts(2)
            End If

            If Wordparts(3) <> "" And Wordparts(4) = "" Then
                M = Wordparts(3) & " Million "
            Else
                M = Wordparts(3) & Wordparts(4)
            End If

            If Wordparts(5) <> "" And Wordparts(6) = "" Then

                TH = Wordparts(5) & " Thousand "
            Else
                TH = Wordparts(5) & Wordparts(6)
            End If

            H = Wordparts(7) & Wordparts(8)
            If Wordparts(9) = "" Then
                C = " and  Zero Cents "
            Else
                C = " and " & Wordparts(9) & " Cents "
            End If
        Next
        output = T & B & M & TH & H & C
        Return output


    End Function
    Private Shared Function primWord(ByVal Num As Integer) As String

        'This two dimensional array store the primary word convertion of numbers 0 to 99
        primWord = ""
        Dim wordList(,) As Object = {{1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, {5, "Five"},
    {6, "Six "}, {7, "Seven "}, {8, "Eight "}, {9, "Nine "}, {10, "Ten "}, {11, "Eleven "}, {12, "Twelve "}, {13, "Thirteen "},
    {14, "Fourteen "}, {15, "Fifteen "}, {16, "Sixteen "}, {17, "Seventeen "}, {18, "Eighteen "}, {19, "Nineteen "},
    {20, "Twenty "}, {21, "Twenty One "}, {22, "Twenty Two"}, {23, "Twenty Three"}, {24, "Twenty Four"}, {25, "Twenty Five"},
    {26, "Twenty Six"}, {27, "Twenty Seven"}, {28, "Twenty Eight"}, {29, "Twenty Nine"}, {30, "Thirty "}, {31, "Thirty One "},
    {32, "Thirty Two"}, {33, "Thirty Three"}, {34, "Thirty Four"}, {35, "Thirty Five"}, {36, "Thirty Six"}, {37, "Thirty Seven"},
    {38, "Thirty Eight"}, {39, "Thirty Nine"}, {40, "Forty "}, {41, "Forty One "}, {42, "Forty Two"}, {43, "Forty Three"},
    {44, "Forty Four"}, {45, "Forty Five"}, {46, "Forty Six"}, {47, "Forty Seven"}, {48, "Forty Eight"}, {49, "Forty Nine"},
    {50, "Fifty "}, {51, "Fifty One "}, {52, "Fifty Two"}, {53, "Fifty Three"}, {54, "Fifty Four"}, {55, "Fifty Five"},
    {56, "Fifty Six"}, {57, "Fifty Seven"}, {58, "Fifty Eight"}, {59, "Fifty Nine"}, {60, "Sixty "}, {61, "Sixty One "},
    {62, "Sixty Two"}, {63, "Sixty Three"}, {64, "Sixty Four"}, {65, "Sixty Five"}, {66, "Sixty Six"}, {67, "Sixty Seven"}, {68, "Sixty Eight"},
    {69, "Sixty Nine"}, {70, "Seventy "}, {71, "Seventy One "}, {72, "Seventy Two"}, {73, "Seventy Three"}, {74, "Seventy Four"},
    {75, "Seventy Five"}, {76, "Seventy Six"}, {77, "Seventy Seven"}, {78, "Seventy Eight"}, {79, "Seventy Nine"},
    {80, "Eighty "}, {81, "Eighty One "}, {82, "Eighty Two"}, {83, "Eighty Three"}, {84, "Eighty Four"}, {85, "Eighty Five"},
    {86, "Eighty Six"}, {87, "Eighty Seven"}, {88, "Eighty Eight"}, {89, "Eighty Nine"}, {90, "Ninety "}, {91, "Ninety One "},
    {92, "Ninety Two"}, {93, "Ninety Three"}, {94, "Ninety Four"}, {95, "Ninety Five"}, {96, "Ninety Six"}, {97, "Ninety Seven"},
    {98, "Ninety Eight"}, {99, "Ninety Nine"}}

        Dim i As Integer
        For i = 0 To UBound(wordList)
            If Num = wordList(i, 0) Then
                primWord = wordList(i, 1)
                Exit For
            End If
        Next
        Return primWord
    End Function
End Class