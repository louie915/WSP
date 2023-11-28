Imports SPIDC.Resources
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
Imports System.Security.Cryptography
Imports QRCoder
Imports System.Drawing
Imports System.Web.HttpContext

Public Class ReportViewer
    Inherits System.Web.UI.Page
    Private _mReportType As String
    Private _mSqlCommand As SqlCommand
    Public Sum_TotDue As Double
    Public Sum_TotPenDue As Double
    Public Sum_TotTaxDue As Double
    Public Sum_TotETC As Double

    'Public Shared DT0_eOR As DataTable
    'Public Shared DT1_eOR As DataTable
    'Public Shared DT2_eOR As DataTable
    'Public Shared TAXTYPE_eOR As String

    Private Const _sscPrefix As String = "ReportViewer."
    Private Const _sscDT0_eOR As String = _sscPrefix & "_sscDT0_eOR"
    Private Const _sscDT1_eOR As String = _sscPrefix & "_sscDT1_eOR"
    Private Const _sscDT2_eOR As String = _sscPrefix & "_sscDT2_eOR"
    Private Const _sscTAXTYPE_eOR As String = _sscPrefix & "_sscTAXTYPE_eOR"

    Private Const _sscNEWBP_TOP_ACCTNO As String = _sscPrefix & "_sscNEWBP_TOP_ACCTNO"
    Private Const _sscNEWBP_TOP_Email As String = _sscPrefix & "_sscNEWBP_TOP_Email"
    Private Const _sscNEWBP_APPFORM_APPID As String = _sscPrefix & "_sscNEWBP_APPFORM_APPID"
    Private Const _sscNEWBP_APPFORM_Email As String = _sscPrefix & "_sscNEWBP_APPFORM_Email"
    Private Const _sscNEWBP_APPFORM_ACCTNO As String = _sscPrefix & "_sscNEWBP_APPFORM_ACCTNO"

    Shared Property NEWBP_APPFORM_ACCTNO() As String
        Get
            Return Current.Session(_sscNEWBP_APPFORM_ACCTNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscNEWBP_APPFORM_ACCTNO) = value
        End Set
    End Property
    Shared Property NEWBP_APPFORM_Email() As String
        Get
            Return Current.Session(_sscNEWBP_APPFORM_Email)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscNEWBP_APPFORM_Email) = value
        End Set
    End Property
    Shared Property NEWBP_TOP_Email() As String
        Get
            Return Current.Session(_sscNEWBP_TOP_Email)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscNEWBP_TOP_Email) = value
        End Set
    End Property
    Shared Property NEWBP_APPFORM_APPID() As String
        Get
            Return Current.Session(_sscNEWBP_APPFORM_APPID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscNEWBP_APPFORM_APPID) = value
        End Set
    End Property
    Shared Property NEWBP_TOP_ACCTNO() As String
        Get
            Return Current.Session(_sscNEWBP_TOP_ACCTNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscNEWBP_TOP_ACCTNO) = value
        End Set
    End Property

    Shared Property TAXTYPE_eOR() As String
        Get
            Return Current.Session(_sscTAXTYPE_eOR)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTAXTYPE_eOR) = value
        End Set
    End Property
    Shared Property DT2_eOR() As DataTable
        Get
            Return Current.Session(_sscDT2_eOR)
        End Get
        Set(ByVal value As DataTable)
            Current.Session(_sscDT2_eOR) = value
        End Set
    End Property
    Shared Property DT1_eOR() As DataTable
        Get
            Return Current.Session(_sscDT1_eOR)
        End Get
        Set(ByVal value As DataTable)
            Current.Session(_sscDT1_eOR) = value
        End Set
    End Property
    Shared Property DT0_eOR() As DataTable
        Get
            Return Current.Session(_sscDT0_eOR)
        End Get
        Set(ByVal value As DataTable)
            Current.Session(_sscDT0_eOR) = value
        End Set
    End Property
  

    Public Property _pReportType() As String
        Get
            Return _mReportType
        End Get
        Set(value As String)
            _mReportType = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim FileID As String
                Dim Email As String
                Dim DateProcessed As Date
                Dim DocType As String

                Dim _nReportType As String = Request.QueryString("ReportType")
                Dim PayNow As String = Request.QueryString("PayNow")
                Dim AppID As String = Request.QueryString("AppID")
                ' _nReportType = "RPTSOA"
                Select Case _nReportType
                    Case "BPSA"
                        _GenerateReport_BPSA() ' CSJDM / General
                        ''Send_QR(PayNow)
                        '  _GenerateReport_BPSA_2() ' Muntinlupa
                        DocType = "BP_TOP"
                    Case "BPSA_NB"
                        _GenerateReport_BPSA_NB()
                        DocType = "BP_TOP"
                    Case "NEW_BP_TOP" ''----------------------Added 20211211 mean
                        _GenerateReport_NEW_BP_TOP(NEWBP_TOP_ACCTNO, NEWBP_TOP_Email)
                        DocType = "BP_TOP"
                        Send_QR(PayNow)
                    Case "NEW_BP_APPFORM" ''----------------------Added 20211215 mean
                        _mGenerateReport_NEW_BP_APPFORM(NEWBP_APPFORM_APPID, NEWBP_APPFORM_Email, NEWBP_APPFORM_ACCTNO)
                    Case "BPINFO"
                        _GenerateReport_BPINFO()
                        DocType = "BP_Info"
                    Case "RPTAXDEC"
                        _GenerateReport_RPTaxDec()
                        DocType = "RPT_TAXDEC"
                    Case "RPTSOA"
                        _GenerateReport_RPT_SOA()
                        DocType = "RPT_TOP"
                        Send_QR(PayNow)

                    Case "eOR"
                        Response.Write("<script>alert('<br>Generating E-OR Report');</script>")
                        _GenerateReport_eOR(Request.QueryString("Send"))
                        DocType = "eOR"
                        'Send_QR(PayNow)

                    Case "APPFORM"
            ' _GenerateReport_BP_APPFORM()
            ' _GenerateReport_BP_APPFORM2()
            _GenerateReport_BP_APPFORM3(cSessionLoader._pAccountNo, cSessionUser._pUserID)
            DocType = "AppForm"
                    Case "Appointment" 'Gimay 20201027
            _GenerateReport_Appointment()
            DocType = "Appointment"
                    Case "AppointmentSlip"
            _GenerateReport_AppointmentSlip(AppID)
            DocType = "AppointmentSlip"

                    Case "AppointmentList"
            _GenerateReport_AppointmentList()
            DocType = "AppointmentList"

                    Case "TransactionReport"
            _GenerateReport_TransactionReport()
            DocType = "TransactionReport"

                    Case "BP_TOP_2023"
            _GenerateReport_TOP_2023()
            DocType = "BP_TOP"

                    Case "ListingApplication"
            _nGenerateReport_ApplListing()
                    Case "TIMS_Abstract" ' Carl 20200128
            _GenerateReport_Abstract()
            DocType = "Abstract"
                    Case "BPNEW_APPINFO" ' Louie 20210604
            _GenerateReport_ApplicatioForm_New()
            DocType = "AppInfo"
            Send_QR(PayNow)
                End Select

                '     If Request.QueryString("Send") = 1 Then Exit Sub

                If PayNow = Nothing Then
                    If String.IsNullOrEmpty(AppID) Then
                        _ExportToPDF(DocType)
                        ' If DocType = "eOR" Then Response.Write("<script>window.location.replace('WebPortal/Account.aspx');</script>")
                    Else
                        _ExportToPDF(DocType, AppID)
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _GenerateReport_ApplicatioForm_New()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " SELECT  " & _
                            " BM.ACCTNO, BM.STATCODE " & _
                            " ,BM.FIRST_NAME,BM.MIDDLE_NAME,BM.LAST_NAME " & _
                            " ,BM.COMMNAME,BM.COMMADDR,BM.OWNERADDR " & _
                            " ,BM.CPNO,BM.CPNO2,BM.CPNO3,BM.EMAILADDR,BM.EMAILADDR2 " & _
                            " ,BM.APP_DATE,BM.CDA_NO,BM.DTI_NO,BM.SEC_NO,TIN_NO,CDA_NO " & _
                            " ,BM.OWNCODE,BM.P_RENT,BM.P_RENTDATE,BM.P_OWNERADDR " & _
                            " ,BM.P_RENT M_RENTAL , BM.P_RENTDATE " & _
                            " ,BME.FORYEAR,BME.NO_EMP_F,BME.NO_EMP_M,BME.NO_EMP_LGU,CONTACT " & _
                            " ,BME.FIRSTNAME LESSOR_FIRSTNAME ,BME.MIDDLENAME LESSOR_MIDDLENAME,BME.LASTNAME LESSOR_LASTNAME" & _
                            " ,BME.IF_WITH_TAX,BME.TAX_INDIC " & _
                            " ,( ISNULL(BME.LASTNAME,'''') + ISNULL(BME.FIRSTNAME,'''') + ISNULL(BME.MIDDLENAME,'''') ) as LESSOR_FULLNAME " & _
                            " FROM BUSMAST BM " & _
                            " INNER JOIN BUSMASTEXTN BME" & _
                            " ON BM.ACCTNO = BME.ACCTNO "

                ._pCondition = " WHERE BM.Acctno = ''" & cSessionLoader._pAccountNo & "'' AND BME.FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)

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

                Dim info As FieldInfo

                For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                    If extension.Name <> "PDF" Then
                        info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                        info.SetValue(extension, False)
                    End If
                Next

                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pReportAppForm_New
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True
                '==============================================================================================


                'BPLTAS LIVE
                Dim _nClBP As New cDalGlobalConnectionsDefault
                _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                _nClBP._pSubRecordSelectSpecific()

                Dim _nBPLTASServerName As String = _nClBP._pDBDataSource
                Dim _nBPLTASDatabaseName As String = _nClBP._pDBInitialCatalog


                Dim _nClass2 As New cDal_IUD
                With _nClass2
                    ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                    ._pAction = "SELECT"
                    ._pSelect = " Select ACCTNO " & _
                        " ,(SELECT [DESCRIPTION]     FROM  [" & _nBPLTASServerName & "].[" & _nBPLTASDatabaseName & "].dbo.BUSCODE BC  where  BC.BUS_CODE COLLATE DATABASE_DEFAULT  =  BL.BUS_CODE ) as BuslineDesc " & _
                        " , FORYEAR ,CAPITAL,0 Prev_grossRECOAmnt,0 GROSSREC0  " & _
                        " FROM BUSLINE BL "
                    ._pCondition = " WHERE BL.Acctno = ''" & cSessionLoader._pAccountNo & "'' AND BL.FORYEAR = YEAR(GETDATE()) "
                    ._pExec(_nSuccess, _nErrMsg)

                    Dim _nDataTable2 As New DataTable
                    _nDataTable2 = ._pDataTable

                    If _nDataTable2.Rows.Count <> 0 Then

                        _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                        Dim _nReportDataSource As New ReportDataSource
                        _nReportDataSource.Name = "DataSet1"
                        _nReportDataSource.Value = _nDataTable2
                        _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


                    End If

                End With
                '===============================================================================================

                Dim _nClass3 As New cDal_IUD

                'OAIMS LIVE
                Dim _nClBP2 As New cDalGlobalConnectionsDefault
                _nClBP2._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP2._pSetupGlobalConnectionsDatabases = "OAIMS"
                _nClBP2._pSubRecordSelectSpecific()

                Dim _nOAIMSServerName As String = _nClBP2._pDBDataSource
                Dim _nOAIMSDatabaseName As String = _nClBP2._pDBInitialCatalog



                With _nClass3
                    ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                    ._pAction = "SELECT"
                    ._pSelect = " Select " & _
                    " ACCTNO,FORYEAR,BUS_CODE,TAXCODE,DESC1 TAXDESC" & _
                    " ,(Qtryr1 + '' '' + Qtryr2) QTR,''0.00'' GROSSAMT,TAXDUE AMOUNTDUE,  TOTDUE TOTAL, Pendue, ISnull(DISCOUNT,''0'') DISCOUNT " & _
                    " FROM [" & _nOAIMSDatabaseName & "].dbo.[BILLINGTEMP] "
                    ._pCondition = " WHERE Acctno = ''" & cSessionLoader._pAccountNo & "'' AND FORYEAR = YEAR(GETDATE()) AND BUS_CODE <> 0 "
                    ._pExec(_nSuccess, _nErrMsg)

                    Dim _nDataTable3 As New DataTable
                    _nDataTable3 = ._pDataTable

                    If _nDataTable3.HasErrors = False Then
                        '  _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                        Dim _nReportDataSource As New ReportDataSource
                        _nReportDataSource.Name = "DataSet2"
                        _nReportDataSource.Value = _nDataTable3
                        _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                    End If


                End With
                '===============================================================================================

                '===============================================================================================

                Dim _nClass4 As New cDal_IUD

                'OAIMS LIVE
                Dim _nClBP3 As New cDalGlobalConnectionsDefault
                _nClBP3._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP3._pSetupGlobalConnectionsDatabases = "OAIMS"
                _nClBP3._pSubRecordSelectSpecific()


                With _nClass4
                    ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                    ._pAction = "SELECT"
                    ._pSelect = " Select " & _
                    " ACCTNO,FORYEAR,BUS_CODE,TAXCODE,DESC1 TAXDESC" & _
                    " ,(Qtryr1 + '' '' + Qtryr2) QTR,''0.00'' GROSSAMT,TAXDUE AMOUNTDUE,  TOTDUE TOTAL, Pendue, ISnull(DISCOUNT,''0'') DISCOUNT " & _
                    " FROM [" & _nOAIMSDatabaseName & "].dbo.[BILLINGTEMP] "
                    ._pCondition = " WHERE Acctno = ''" & cSessionLoader._pAccountNo & "'' AND FORYEAR = YEAR(GETDATE()) AND BUS_CODE = 0 "
                    ._pExec(_nSuccess, _nErrMsg)

                    Dim _nDataTable4 As New DataTable
                    _nDataTable4 = ._pDataTable

                    If _nDataTable4.HasErrors = False Then

                        Dim _nReportDataSource2 As New ReportDataSource
                        _nReportDataSource2.Name = "DataSet3"
                        _nReportDataSource2.Value = _nDataTable4
                        _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource2)

                    End If


                End With
                '===============================================================================================

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("Param_Year", _nDataTable.Rows(0).Item("FORYEAR").ToString))
                paramList.Add(New ReportParameter("Param_ACCTNO", cSessionLoader._pAccountNo.ToString)) 'GIMAY 20201028  cSessionLoader._pAccountNo.ToString
                paramList.Add(New ReportParameter("Param_STATCODE", _nDataTable.Rows(0).Item("STATCODE").ToString))
                paramList.Add(New ReportParameter("Param_APP_DATE", _nDataTable.Rows(0).Item("APP_DATE").ToString))
                paramList.Add(New ReportParameter("Param_TIN_NO", _nDataTable.Rows(0).Item("TIN_NO").ToString))
                paramList.Add(New ReportParameter("Param_DTI_NO", _nDataTable.Rows(0).Item("DTI_NO").ToString))
                paramList.Add(New ReportParameter("Param_CDA_NO", _nDataTable.Rows(0).Item("CDA_NO").ToString))
                paramList.Add(New ReportParameter("Param_OWNCODE", _nDataTable.Rows(0).Item("OWNCODE").ToString))
                paramList.Add(New ReportParameter("Param_LAST_NAME", UCase(_nDataTable.Rows(0).Item("LAST_NAME").ToString)))
                paramList.Add(New ReportParameter("Param_FIRST_NAME", _nDataTable.Rows(0).Item("FIRST_NAME").ToString))
                paramList.Add(New ReportParameter("Param_MIDDLE_NAME", _nDataTable.Rows(0).Item("MIDDLE_NAME").ToString))
                paramList.Add(New ReportParameter("Param_COMMNAME", UCase(_nDataTable.Rows(0).Item("COMMNAME").ToString)))

                paramList.Add(New ReportParameter("Param_BusiAddr", _nDataTable.Rows(0).Item("COMMADDR").ToString))
                paramList.Add(New ReportParameter("Param_OWNERADDR", _nDataTable.Rows(0).Item("OWNERADDR").ToString))
                paramList.Add(New ReportParameter("Param_CONTACT", _nDataTable.Rows(0).Item("CONTACT").ToString))
                paramList.Add(New ReportParameter("Param_EMAILADDR", LCase(_nDataTable.Rows(0).Item("EMAILADDR").ToString)))
                'paramList.Add(New ReportParameter("Param_BUSIAREA_NO", _nDataTable.Rows(0).Item("BUSIAREA_NO").ToString))
                paramList.Add(New ReportParameter("Param_NO_EMP_F", _nDataTable.Rows(0).Item("NO_EMP_F").ToString))
                paramList.Add(New ReportParameter("Param_NO_EMP_M", _nDataTable.Rows(0).Item("NO_EMP_M").ToString))
                paramList.Add(New ReportParameter("Param_NO_EMP_LGU", UCase(_nDataTable.Rows(0).Item("NO_EMP_LGU").ToString)))

                paramList.Add(New ReportParameter("Param_LESSOR_FULLNAME", _nDataTable.Rows(0).Item("LESSOR_FULLNAME").ToString))
                'paramList.Add(New ReportParameter("Param_LESSOR_ADDRESS", _nDataTable.Rows(0).Item("LESSOR_ADDR").ToString))
                'paramList.Add(New ReportParameter("Param_LESSOR_TELNO", _nDataTable.Rows(0).Item("LESSOR_TELNO").ToString))
                'paramList.Add(New ReportParameter("Param_LESSOR_EMAIL", UCase(_nDataTable.Rows(0).Item("LESSOR_EMAIL").ToString)))
                paramList.Add(New ReportParameter("Param_RENT", _nDataTable.Rows(0).Item("M_RENTAL").ToString))

                'Dim _nLGU_Name As String = cSessionLGUProfile._pLGU_Name
                'Dim _nLGU_TelNo As String = cSessionLGUProfile._pLGU_TelNo
                'Dim _nLGU_Website As String = cSessionLGUProfile._pLGU_Website

                'paramList.Add(New ReportParameter("Param_LGU_Name", _nLGU_Name.ToString))
                '  paramList.Add(New ReportParameter("Param_LGU_TelNo", _nLGU_TelNo))
                '  paramList.Add(New ReportParameter("Param_LGU_Website", _nLGU_Website))

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True


            End With
        Catch ex As Exception

        End Try
    End Sub
    Sub Send_QR(PayNow)
        Try
            Dim strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery
            Dim strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/")
            Dim warnings As Warning()
            Dim streamIds As String()
            Dim FileType As String
            Dim FileID As String
            Dim DateProcessed As Date
            Dim encoding As String
            Dim Hash As String
            Dim FileName As String
            Dim FileExt As String
            Dim BIN_ASSESSNO As String
            Dim IDno As String
            Dim strDate As String
            Dim FileData As Byte() = _oRpt_EnvelopeSeal.LocalReport.Render("PDF", Nothing, FileType, encoding, FileExt, streamIds, warnings)

            Dim _nClass As New cDalNewSendEmail
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetDateProcessed(DateProcessed, strDate)
            _nClass._pSubGetAutoFileID(FileID, strDate)
            FileID = Request.QueryString("ReportType") & FileID

            If Request.QueryString("ReportType") = "BPSA" Then
                BIN_ASSESSNO = cSessionLoader._pAccountNo
                IDno = "BIN : "
            ElseIf Request.QueryString("ReportType") = "RPTSOA" Then
                BIN_ASSESSNO = cSessionLoader._pAssessNo
                IDno = "Assessment No. : "
            End If

            Hash = GetHashMD5(FileID + BIN_ASSESSNO + DateProcessed)
            FileName = Request.QueryString("ReportType") & "_" & BIN_ASSESSNO & ".pdf"

            Dim QR_URL As String
            If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("TEST") = True Then
                QR_URL = strUrl & "Test/DocViewer.aspx?DocID=" & Hash
            Else
                If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("online.spidc.com.ph") = True Then
                    If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("CALOOCAN") = True Then
                        QR_URL = "https://online.spidc.com.ph/caloocan/DocViewer.aspx?DocID=" & Hash
                    ElseIf HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("CAINTA") = True Then
                        QR_URL = "https://online.spidc.com.ph/cainta/DocViewer.aspx?DocID=" & Hash
                    End If
                Else
                    QR_URL = strUrl & "DocViewer.aspx?DocID=" & Hash
                End If
            End If


            Dim qrGenerator As New QRCodeGenerator
            Dim qrCode = qrGenerator.CreateQrCode(QR_URL.ToUpper, QRCodeGenerator.ECCLevel.Q)
            Dim imgBarCode As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
            Dim QR_CODE As New QRCode(qrCode)
            imgBarCode.Height = 350
            imgBarCode.Width = 350
            _nClass._pSubInsertDocuments(FileID, BIN_ASSESSNO, cSessionUser._pUserID, FileName, FileType, FileData, FileExt, DateProcessed, Hash, strDate)

            Using bitMap As Bitmap = QR_CODE.GetGraphic(6)
                Using ms As MemoryStream = New MemoryStream()
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    Dim byteImage As Byte() = ms.ToArray()
                    imgBarCode.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
                End Using
            End Using



            Dim Logo_Data As Byte()
            Dim Logo_Name As String
            Dim Logo_Ext As String
            cDalNewSendEmail.get_Header_DATA(Logo_Data, Logo_Name, Logo_Ext)
            Dim Logo_IMG As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
            Logo_IMG.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(Logo_Data)

            If PayNow.ToString.ToUpper = "TRUE" Then
                Dim amountdesc As String
                Dim title As String
                If cSessionLoader._pPSTransOTCNote <> "" Then
                    amountdesc = "Amount to Pay"
                    title = "Over-The-Counter"
                Else
                    amountdesc = "Amount"
                    title = "bill"
                End If




                Dim Sent As Boolean
                Dim Subject As String = "Statement of Account"
                Dim Body As String = "Dear Valued Tax Payer, <br> " & _
           "Scan QR or check the attached file to view your generated Statement of Account. This confirms your " & title & " transaction with the following details: <br> " & _
           "   <table>" & _
           "       <tr><td>" & cSessionLoader._pPSTransDesc & "</td><td>: " & cSessionLoader._pPSTransID & "</td></tr>" & _
           "       <tr><td>Transaction Number</td><td>: " & cSessionLoader._pPSTransRefNo & "</td></tr>" & _
           "       <tr><td>Period Covered</td><td>: " & cSessionLoader._pPeriodCovered & "</td></tr>" & _
           "       <tr><td>Transaction Type</td><td>: " & cSessionLoader._pPSTransType & "</td></tr>" & _
           "       <tr><td>Date/Time</td><td>: " & Format(Date.Now, "MM-dd-yyyy hh:mm:ss") & " </td>" & _
           "       </tr><tr><td>" & amountdesc & "</td><td>: " & cSessionLoader._pPSTransAmount & "</td></tr>" & _
           "   </table>" & _
           "" & cSessionLoader._pPSTransOTCNote & "<br>" & _
           "Thank you for choosing our Web Service Portal. Have a wonderful day! <br><br>"
                cDalNewSendEmail.SendEmailWithQR(cSessionUser._pUserID, Subject, Body, imgBarCode.ImageUrl, Logo_IMG.ImageUrl, Sent, IDno & BIN_ASSESSNO, FileData, FileName)
                ClientScript.RegisterStartupScript(GetType(Page), "closePage", "<script type='text/JavaScript'>window.close();</script>")
            Else
                Dim Sent As Boolean
                Dim Subject As String = "Statement of Account"
                Dim stime As String
                Dim Body As String = "Dear Valued Tax Payer, <br><br>" & _
                         "Scan QR to view your generated Statement of Account <br> <br>" & _
                         "<br/> Thank you for choosing our Web Service Portal. Have a wonderful day!</td></tr>"
                cDalNewSendEmail.SendEmailWithQR(cSessionUser._pUserID, Subject, Body, imgBarCode.ImageUrl, Logo_IMG.ImageUrl, Sent, IDno & BIN_ASSESSNO, FileData, FileName)
            End If


        Catch ex As Exception

        End Try


    End Sub

    Shared Function GetHashMD5(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function
    Public Sub _GenerateReport_BPSA()
        Try
            Dim _nClass_web As New CDalGenPaymentBusline

            Dim _nC As New cDalBPSOS
            Dim _nSqlCmd As SqlCommand
            Dim _nSqlDtr As SqlDataReader
            Dim _nSqlDataAdpt As SqlDataAdapter
            Dim _nSuccesful As Boolean, ErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            Dim _nDueDate As String = Nothing
            Dim _nSubQtr As String = Nothing
            Dim _nGetFinalQtr As String = Nothing
            Dim _nHasBillingDate As Boolean = False
            Dim _nTOPRenDate As String = Nothing
            Dim _nDataTable As New DataTable
            Dim _nDate1 As String
            Dim _nForyear As String
            Dim _nTempTable As String
            Dim _nAcctNo As String = Nothing
            Dim _nLocServer As String = Nothing
            Dim _nLocDB As String = Nothing
            Dim _nWEBServer As String = Nothing
            Dim _nWEBDB As String = Nothing


            Dim _nSqllocalCon As SqlConnection
            Dim _nSqlCon As SqlConnection
            Dim _nSqlConCR As SqlConnection

            ''---------------------------------------------------------------------SET CONNECTION
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR

            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nLocServer = _nClBP._pDBDataSource
            _nLocDB = _nClBP._pDBInitialCatalog
            _nTempTable = "temp_" & cSessionUser._pUserID.Replace(".", "")


            _nSqllocalCon = cGlobalConnections._pSqlCxn_BPLTAS
            _nSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            _nC._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nWEBServer = _nSqllocalCon.DataSource

            _nWEBDB = _nSqllocalCon.Database
            ''---------------------------------------------------------------------
            _nAcctNo = cSessionLoader._pAccountNo
            _nC._pSubGetCurYear()
            _nForyear = _nC._nCurYear
            _nDate1 = _nC._nCurDate


            With _nClass



                '' ------------------------------------------------------------------------------------------------------------------------sum in mayors,sanitary,fire

                If UCase(_nWEBDB.Contains("CALOOCAN")) Then
                    _nSqlCmd = New SqlCommand("EXEC [SP_UPDATETEMP_TOP] '" & _nAcctNo & "','" & _nForyear & "','" & _nTempTable & "" & "'", _nSqlCon)
                    _nSqlCmd.ExecuteNonQuery()
                    _nSqlCmd.Dispose()

                    _nSqlCmd = New SqlCommand("   WITH XTBL AS  " &
                                               "       ( SELECT ACCTNO," &
                                               "       FORYEAR, taxcode, " &
                                               "        TAXDESC AS DESC1, " &
                                               "       isnull(replace(Qtr,'0','1'),'') Qtr ,     ISNULL(SUM(GROSSAMT),0) AS TAXBASE, ISNULL(SUM(AMOUNTDUE),0) AS TAXDUE  ,  " &
                                               "       ISNULL(SUM(PENDUE),0) PENDUE, ISNULL(SUM(DISCOUNT),0) DISCOUNT,  ISNULL(SUM(TOTAL),0) AS TOTDUE, " &
                                               "       ( Case When ISNULL(QTR,'') <> '' then ISNULL(replace(Qtr,'0','1'),'') + ' Qtr '  + Isnull(FORYEAR,'') else '' end ) as Pres, " &
                                               "       CASE WHEN ISNULL((SELECT TOP 1 TOPSEQ FROM [" & _nLocServer & "].[" & _nLocDB & "].dbo.LABELS  " &
                                               "       WHERE TAXCODE =temptbl.TAXCODE),'') = ''   THEN LEFT(TAXCODE,1)  " &
                                               "       ELSE  " &
                                               "       (SELECT TOP 1 TOPSEQ FROM [" & _nLocServer & "].[" & _nLocDB & "].dbo.LABELS WHERE TAXCODE = temptbl.TAXCODE ) END AS SEQ  " &
                                               "    FROM [" & _nTempTable & "] temptbl  GROUP BY ACCTNO, FORYEAR,QTR,TAXDESC,TAXCODE)" &
                                               "       SELECT ACCTNO,FORYEAR, DESC1, QTR,isnull(SUM(TAXBASE),0) AS TAXBASE, isnull(SUM(TAXDUE),0) AS TAXDUE,   isnull(SUM(PENDUE),0) PENDUE, isnull(SUM(DISCOUNT),0) DISCOUNT , isnull(SUM(TOTDUE),0) TOTDUE,PRES,SEQ  FROM XTBL  " &
                                               "    	where ACCTNO ='" & _nAcctNo & "' and FORYEAR=year(getdate())" &
                                               "   GROUP BY ACCTNO, FORYEAR,DESC1,QTR,SEQ,PRES order by acctno desc,SEQ,TAXBASE desc   ")

                Else
                    _nSqlCmd = New SqlCommand("   WITH XTBL AS  " &
                                              "       ( SELECT ACCTNO," &
                                              "       BUSCODE AS BUS_CODE,  " &
                                              "       FORYEAR,  " &
                                              "       (select top 1 TAXDESC from PAYMENT where ACCTNO  =temptbl.ACCTNO and FORYEAR  =temptbl.FORYEAR and   " &
                                              "       TAXCODE=temptbl.TAXCODE and BUSCODE=temptbl.BUSCODE  ) as DESC1, " &
                                              "         isnull(Qtr,'') Qtr ,  " &
                                              "       GROSSAMT AS TAXBASE,   " &
                                              "       AMOUNTDUE AS TAXDUE  ,  " &
                                              "       PENDUE ,  " &
                                              "       DISCOUNT,  " &
                                              "       TOTAL AS TOTDUE, " &
                                              "       ( Case When ISNULL(QTR,'') <> '' then ISNULL(QTR,'') + ' Qtr '  + Isnull(FORYEAR,'') else '' end)  as Pres, " &
                                              "       CASE WHEN ISNULL((SELECT TOP 1 TOPSEQ FROM [" & _nLocServer & "].[" & _nLocDB & "].dbo.LABELS  " &
                                              "       WHERE TAXCODE =temptbl.TAXCODE),'') = ''   THEN LEFT(TAXCODE,1)  " &
                                              "       ELSE  " &
                                              "       (SELECT TOP 1 TOPSEQ FROM [" & _nLocServer & "].[" & _nLocDB & "].dbo.LABELS WHERE TAXCODE = temptbl.TAXCODE ) END AS SEQ  ," &
                                              "       TAXCODE FROM [" & _nTempTable & "] temptbl)" &
                                             "       SELECT ACCTNO,BUS_CODE,FORYEAR, DESC1, QTR,isnull(SUM(TAXBASE),0) AS TAXBASE, isnull(SUM(TAXDUE),0) AS TAXDUE,   isnull(SUM(PENDUE),0) PENDUE, isnull(SUM(DISCOUNT),0) DISCOUNT , isnull(SUM(TOTDUE),0) TOTDUE,PRES,SEQ,TAXCODE  FROM XTBL  " &
                                                "    	where ACCTNO ='" & _nAcctNo & "' and FORYEAR=year(getdate())" &
                                                "       GROUP BY ACCTNO, FORYEAR,DESC1,QTR,SEQ,BUS_CODE,TAXCODE,PRES order by acctno desc,SEQ,TAXBASE desc   ")

                End If


                txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QR1"
                _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqlCon)
                _nSqlDataAdpt.Fill(_nDataTable)
                _nSqlCmd.Dispose()
                _nSqlDataAdpt.Dispose()

                '  ' order by acctno desc,BUSCODE desc,GROSSAMT desc 
                '' ._pSortBy = " ORDER BY Desc1,TAXBASE desc"
                '._pSortBy = " order by Bus_Code desc, NEWTOPSEQ desc "

                ''._pExec(_nSuccesful, ErrMsg)


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
                Dim mchname As New cHardwareInformation
                Dim _nMachineName As String = Nothing
                _nMachineName = mchname._pMachineName.ToUpper

                'Select Case _nMachineName
                '    Case "WEBSVRCALOOCAN"
                '        _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_CALOOCAN.rdlc")
                '        ''_oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_GENERAL_FORMAT.rdlc")
                '        ''Case "GROTTO"
                '        ''    _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_2.rdlc")
                '        '  Case "GRACEVILLE"
                '        '     _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_CSJDM.rdlc")
                '        ''Case "TALISAYWEBSVR"
                '        ''    _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_TALISAY.rdlc")
                '    Case "HAVANA"

                '        If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("CSJDM") = True Then
                '            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_CSJDM.rdlc")

                '        ElseIf HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("CALOOCAN") = True Then
                '            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_CALOOCAN.rdlc")
                '        Else
                '            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_GENERAL_FORMAT.rdlc")
                '        End If

                '    Case Else
                '        _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_GENERAL_FORMAT.rdlc")
                'End Select

                _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_GENERAL_FORMAT.rdlc")

                ' ---  _nC._pAcctNo 

                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                '   _nReportDataSource.Name = "ds_Payment"
                _nReportDataSource.Name = "DsBP_TOP"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim _nMonthofFeb As Date = Nothing
                Dim _nlastDayOfMonth As Date = Nothing
                Dim _nLastDayOfFeb As String = Nothing
                ''-------------------------------------------------------------------------Formula Modify 20201030
                Dim _nBillDate As String = Nothing
                Dim _nSubDate As String = FormatDateTime(Now, DateFormat.ShortDate)
                Dim _nDate As DateTime = FormatDateTime(Now, DateFormat.ShortDate)

                If Month(_nDate) = 2 Then
                    _nMonthofFeb = New DateTime(_nDate.Year, _nDate.Month, 1)
                    _nlastDayOfMonth = _nMonthofFeb.AddMonths(1).AddDays(-1)
                    _nLastDayOfFeb = _nlastDayOfMonth.Day
                End If

                Dim _nGetQtr As Integer = 1
                Dim _nRowCnt As Integer = 0



                _nBillDate = Format(CDate(_nDate1), "MM/dd/yyyy")

                '      If Left(_nBillDate, 2) <= 3 Then
                '          _nGetQtr = 1
                '      ElseIf Left(_nBillDate, 2) <= 6 Then
                '          _nGetQtr = 2
                '      ElseIf Left(_nBillDate, 2) <= 9 Then
                '          _nGetQtr = 3
                '      ElseIf Left(_nBillDate, 2) <= 12 Then
                '          _nGetQtr = 4
                '      End If

                '  _nGetQtr = Request.QueryString("Qtr") 


                ''uncomment 20220117 mean
                If Left(_nBillDate, 2) <= 3 Then ''------------------get expiry date parameter in RptOnORBeforeDueDate
                    _nGetQtr = 1
                ElseIf Left(_nBillDate, 2) <= 6 Then
                    _nGetQtr = 2
                ElseIf Left(_nBillDate, 2) <= 9 Then
                    _nGetQtr = 3
                ElseIf Left(_nBillDate, 2) <= 12 Then
                    _nGetQtr = 4
                End If
                ''--------------------------------------------------------

                _nSqlCmd = New SqlCommand("	SELECT QTREFF as BILL_QTR,Isnull([MONTH],0) as MONTH ,Isnull(EXTNDAY,0) as EXTNDAY, " &
                                            "Isnull(MONTHQ2,'') as MONTHQ2,Isnull(EXTNDAYQ2,'') as EXTNDAYQ2, " &
                                            "	Isnull(MONTHQ3,'') as MONTHQ3,Isnull(EXTNDAYQ3,'') as EXTNDAYQ3, " &
                                            " isnull(MONTHQ4,'') as MONTHQ4,Isnull(EXTNDAYQ4,'') as EXTNDAYQ4," &
                                            " NOMPEN FROM SETUP ", _nSqllocalCon)

                txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QR3"


                _nSqlDtr = _nSqlCmd.ExecuteReader

                If _nSqlDtr.HasRows Then
                    _nSqlDtr.Read()


                    If _nGetQtr = 1 Then ''(Jan - Mar)
                        If _nGetQtr = 1 And _nBillDate <= _nSqlDtr.Item("Month") & "/" & _nSqlDtr.Item("EXTNDAY") & "/" & Year(_nBillDate) Then
                            _nDueDate = _nSqlDtr.Item("MONTH") & "/" & _nSqlDtr.Item("EXTNDAY") & "/" & Year(_nBillDate)
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
                    ElseIf _nGetQtr = 2 Then ''(April - June)

                        If _nGetQtr = 2 And _nBillDate <= _nSqlDtr.Item("MONTHQ2") & "/" & _nSqlDtr.Item("MONTHQ2") & "/" & Year(_nBillDate) Then
                            _nDueDate = _nSqlDtr.Item("MONTHQ2") & "/" & _nSqlDtr.Item("EXTNDAYQ2") & "/" & Year(_nBillDate)
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

                    ElseIf _nGetQtr = 3 Then ''(July - September)

                        If _nGetQtr = 3 And _nBillDate <= _nSqlDtr.Item("MONTHQ3") & "/" & _nSqlDtr.Item("MONTHQ3") & "/" & Year(_nBillDate) Then
                            _nDueDate = _nSqlDtr.Item("MONTHQ3") & "/" & _nSqlDtr.Item("EXTNDAYQ3") & "/" & Year(_nBillDate)
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
                    ElseIf _nGetQtr = 4 Then ''(October - December)

                        If _nGetQtr = 4 And _nBillDate <= _nSqlDtr.Item("MONTHQ4") & "/" & _nSqlDtr.Item("MONTHQ4") & "/" & Year(_nBillDate) Then
                            _nDueDate = _nSqlDtr.Item("MONTHQ4") & "/" & _nSqlDtr.Item("EXTNDAYQ4") & "/" & Year(_nBillDate)
                            '12/31/[Billing Year]
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
                    End If
                End If

                '   Else
                '_nDueDate = _nSubDate
                '   End If
                _nSqlCmd.Dispose()
                _nSqlDtr.Dispose()
                ''--------------------------------------------------------------------------------




                ''-------------------------------------------------------------------------Formula Bases 20201030

                'If BILL_QTR = 1(Jan - Mar) Then
                '    If Left(Pres, 1) = 1 And billdate <= Setup!Month + "/" + Setup!extnDay + "/" + Year(billdate) Then
                '        Due_Date = Setup!Month + "/" + Setup!extnDay + "/" + Year(billdate)
                '    Else
                '        If Setup!NOMPEN = 0 Then
                '            If Month(billdate) = 1 Then
                '                Due_Date = "2/20/" + Year(billdate)
                '            ElseIf Month(billdate) = 2 Then
                '                Due_Date = "3/20/" + Year(billdate)
                '            ElseIf Month(billdate) = 3 Then
                '                Due_Date = "4/20/" + Year(billdate)
                '            End If
                '        Else
                '            If Month(billdate) = 1 Then
                '                Due_Date = "1/31/" + Year(billdate)
                '            ElseIf Month(billdate) = 2 Then
                '                Due_Date = "2/" + endday + "/" + Year(billdate)
                '            ElseIf Month(billdate) = 3 Then
                '                Due_Date = "3/31/" + Year(billdate)
                '            End If
                '        End If
                '    End If

                'ElseIf BILL_QTR = 2(April - June) Then

                '    If Left(Pres, 1) <= 2 And billdate <= Setup!Month + "/" + Setup!Month + "/" + Year(billdate) Then
                '        Due_Date = Setup!MonthQ2 + "/" + Setup!extnDayQ2 + "/" + Year(billdate)
                '    Else
                '        If Setup!NOMPEN = 0 Then
                '            If Month(billdate) = 4 Then
                '                Due_Date = "5/20/" + Year(billdate)
                '            ElseIf Month(billdate) = 5 Then
                '                Due_Date = "6/20/" + Year(billdate)
                '            ElseIf Month(billdate) = 6 Then
                '                Due_Date = "7/20/" + Year(billdate)
                '            End If
                '        Else
                '            If Month(billdate) = 4 Then
                '                Due_Date = "4/30/" + Year(billdate)
                '            ElseIf Month(billdate) = 5 Then
                '                Due_Date = "5/31/" + Year(billdate)
                '            ElseIf Month(billdate) = 6 Then
                '                Due_Date = "6/30/" + Year(billdate)
                '            End If
                '        End If
                '    End If
            End With


            ''-----------------------------------------------------------------------------------GET CTC ASSESSMENT 20220119
            Dim _nDataTable_CTCAss As New DataTable
            Dim _nHasCTCAss As Boolean = False
            Dim _nCTCAssessment, _nXpiryDate As String

            _nCTCAssessment = ""
            : _nXpiryDate = ""

            _nSqlCmd = New SqlCommand(" Select * from billingtemp where acctno ='" & _nAcctNo & "' And isregbill=1 ", _nSqllocalCon)
            _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
            _nSqlDataAdpt.Fill(_nDataTable_CTCAss)
            _nSqlCmd.Dispose()
            _nSqlDataAdpt.Dispose()

            For _nColCnt As Integer = 0 To _nDataTable_CTCAss.Columns.Count
                If _nDataTable_CTCAss.Columns(_nColCnt).ColumnName = "CTC_REMARK" Then
                    _nHasCTCAss = True
                    Exit For
                End If
            Next



            _nSqlCmd = New SqlCommand(" Select top 1 isnull(DATE_EXPIRE,'')DATE_EXPIRE, isnull(CTC_REMARK,'') CTC_REMARK from billingtemp where acctno ='" & _nAcctNo & "' And isregbill=1 ", _nSqllocalCon)
            _nSqlDtr = _nSqlCmd.ExecuteReader
            _nSqlDtr.Read()

            If _nSqlDtr.HasRows Then
                If _nSqlDtr.Item("DATE_EXPIRE") <> "" Then
                    _nXpiryDate = _nSqlDtr.Item("DATE_EXPIRE")
                Else
                    _nXpiryDate = _nDueDate
                End If
                _nCTCAssessment = _nSqlDtr.Item("CTC_REMARK")
            Else
                _nCTCAssessment = _nSqlDtr.Item("CTC_REMARK")
            End If

            _nSqlCmd.Dispose()
            _nSqlDtr.Dispose()

            If _nXpiryDate = "" Then
                _nXpiryDate = _nDueDate
            End If

            If _nHasCTCAss = True Then
                Dim paramReportHeader As New List(Of ReportParameter)

                paramReportHeader.Add(New ReportParameter("RptCTCAssessment", _nCTCAssessment)) ''---------PARAMETER FOR CTC ASSESSMENT 20220119
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)

            End If




            Dim _nDatatable2 As New DataTable
            Dim _nDatatableNotice As New DataTable
            _GetReportHeader(_nDatatable2)
            ' _GetReportHeader2(_nDatatable2)
            Dim _nNotice As String = Nothing
            Dim mchname1 As New cHardwareInformation
            Dim _nMachineName1 As String = Nothing
            Dim _nxNotice As String = Nothing
            Dim _nParameterCnt As Integer = 0

            _nMachineName1 = mchname1._pMachineName.ToUpper

            If _nDatatable2.Rows.Count > 0 Then
                Dim paramReportHeader As New List(Of ReportParameter)
                paramReportHeader.Add(New ReportParameter("RptPrmHeader1", UCase(_nDatatable2.Rows(0).Item("ReportHeader1").ToString))) ''REPUBLIC PROVINCE
                paramReportHeader.Add(New ReportParameter("RptPrmHeader2", UCase(_nDatatable2.Rows(0).Item("ReportHeader2").ToString))) ''CITY
                paramReportHeader.Add(New ReportParameter("RptPrmHeader3", UCase(_nDatatable2.Rows(0).Item("ReportHeader3").ToString))) ''PROVINCE
                paramReportHeader.Add(New ReportParameter("RptPrmHeader4", UCase(_nDatatable2.Rows(0).Item("ReportHeader4").ToString))) ''Business Permit and Licensing Office
                paramReportHeader.Add(New ReportParameter("RptPrmHeader5", UCase(_nDatatable2.Rows(0).Item("ReportHeader5").ToString))) ''TAX ORDER OF PAYMENT  '' ---comment error here parameter doesn't exists 20211112 mean 


                ''----------------------------------------------------------------------------Display notice 20220119



                ' _nSqlCmd = New SqlCommand(" select isnull(NOTICE1,'')NOTICE1, isnull(NOTICE2,'')NOTICE2, isnull(NOTICE3,'') NOTICE3," & _
                '         "isnull(NOTICE4,'') NOTICE4, isnull(NOTICE5,'')NOTICE5, isnull(NOTICE6,'')NOTICE6 from TOPSETUP  ", _nSqllocalCon)
                '
                _nSqlCmd = New SqlCommand(" SELECT " & _
                                          " isnull((select NOTICE1 where len(NOTICE1) > 0),'1. Please pay the amount due at the Treasury Office on or before')NOTICE1, " & _
                                          " isnull((select NOTICE2 where len(NOTICE2) > 0),'2. Failure to do so shall subject the taxdue to 25% Surcharge & 2% Interest per Month')NOTICE2," & _
                                          " isnull((select NOTICE3 where len(NOTICE3) > 0),'3. For Business Retirement, all dues should be paid in full before retirement')NOTICE3," & _
                                          " isnull((select NOTICE4 where len(NOTICE4) > 0),'4. If Amount Due already paid, please disregard NOTICE 1& 2')NOTICE4," & _
                                          " NOTICE5," & _
                                          " NOTICE6" & _
                                          " from TOPSETUP",
                                          _nSqllocalCon)



                _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
                _nSqlDataAdpt.Fill(_nDatatableNotice)
                _nSqlCmd.Dispose()
                _nSqlDataAdpt.Dispose()

                For xColCnt As Integer = 0 To _nDatatableNotice.Columns.Count - 1
                    If Not _nDatatableNotice.Rows(0).Item(xColCnt).ToString.Contains("_") Or _nDatatableNotice.Rows(0).Item(xColCnt).ToString.Contains(".") Then
                        _nNotice = _nNotice & _nDatatableNotice.Rows(0).Item(xColCnt).ToString
                    End If
                Next
                paramReportHeader.Add(New ReportParameter("RptPrmNotice1", _nDatatableNotice.Rows(0).Item("NOTICE1").ToString))
                paramReportHeader.Add(New ReportParameter("RptPrmNotice2", _nDatatableNotice.Rows(0).Item("NOTICE2").ToString))
                paramReportHeader.Add(New ReportParameter("RptPrmNotice3", _nDatatableNotice.Rows(0).Item("NOTICE3").ToString))
                paramReportHeader.Add(New ReportParameter("RptPrmNotice4", _nDatatableNotice.Rows(0).Item("NOTICE4").ToString))
                paramReportHeader.Add(New ReportParameter("RptPrmNotice5", _nDatatableNotice.Rows(0).Item("NOTICE5").ToString))
                paramReportHeader.Add(New ReportParameter("RptPrmNotice6", _nDatatableNotice.Rows(0).Item("NOTICE6").ToString))

                If _oRpt_EnvelopeSeal.LocalReport.ReportPath.Contains("BP_TOP_GENERAL_FORMAT") = True Then
                    ''------comment current 20220119 mean
                    '' paramReportHeader.Add(New ReportParameter("RptPrmNotice", _nDatatable2.Rows(0).Item("RptNotice").ToString))

                    paramReportHeader.Add(New ReportParameter("RptPrmNotice", _nNotice))
                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
                End If
            End If


            ''--------------------------------------------------SET CONNECTION TO DISPLAY LOGO


            Dim _nClassLOGO As New cDalBPSOS
            With _nClassLOGO
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                ._pDisplayLogo()

                Dim _nDataTableLogo As New DataTable
                _nDataTableLogo = ._pDataTable

                If _nDataTableLogo.Rows.Count > 0 Then
                    Dim _nReportDataSource1 As New ReportDataSource
                    _nReportDataSource1.Name = "DataSet1"
                    _nReportDataSource1.Value = _nDataTableLogo
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource1)

                Else

                End If

            End With

            'Dim _nDataTable6 As New DataTable


            '_nC._pSqlConnection = _nClBP._pCxn
            '_nC._pDisplayLogo()

            '_nDataTable6 = _nC._pDataTable


            'If _nDataTable6.Rows.Count > 0 Then
            '    Dim _nReportDataSource1 As New ReportDataSource
            '    _nReportDataSource1.Name = "DataSet1"
            '    _nReportDataSource1.Value = _nDataTable6
            '    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource1)
            'End If


            Dim _nClass2 As New cDal_IUD
            With _nClass2
                '._pSqlCon = _nClass_web._mSqlCon
                '._pAction = "SELECT"
                _nSqlCmd = New SqlCommand("Select ACCTNo,(ISNULL(LAST_NAME,'') + ' ' + ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'')) as TaxPayer ,COMMNAME,COMMADDR" &
                                        ",(Select isnull(STATDESC,'') from STATCODE S Where S.STATCODE = BUSMAST.STATCODE) as STATCODE," &
                                        "Convert(varchar,GETDATE() ,101) as ProcessDate," &
                                        "(Select isnull(OWNDESC,'') from OWNCODE O Where O.OWNCODE = BUSMAST.OWNCODE ) as OwnCode " &
                                        ",NO_EMP,(Select top 1 AREA from BUSLINE B  Where B.ACCTNO = BUSMAST.ACCTNO  Order by  FORYEAR desc, AREA desc  ) as AREA " &
                                        "from Busmast  where ACCTNO = '" & _nAcctNo & "'", _nSqllocalCon)
                txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QR4"
                _nSqlDtr = _nSqlCmd.ExecuteReader

                '._pExec(_nSuccesful, ErrMsg)
                If _nSqlDtr.HasRows Then
                    _nSqlDtr.Read()

                    Dim _nDataTable3 As New DataTable
                    _nDataTable3 = ._pDataTable

                    'If _nDataTable3.Rows.Count > 0 Then

                    Dim paramList1 As New List(Of ReportParameter)

                    Dim ProperConsStatus As String = StrConv(_nSqlDtr.Item("STATCODE").ToString, VbStrConv.ProperCase)
                    Dim ProperConsOwner As String = StrConv(_nSqlDtr.Item("OwnCode").ToString, VbStrConv.ProperCase)



                    paramList1.Add(New ReportParameter("RptPrmAcctNo", UCase(_nSqlDtr.Item("ACCTNO").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmTaxpayer", UCase(_nSqlDtr.Item("TaxPayer").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmCommercialName", UCase(_nSqlDtr.Item("COMMNAME").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmInfoCommercialLocation", UCase(_nSqlDtr.Item("COMMADDR").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmInfoStatus", ProperConsStatus))
                    paramList1.Add(New ReportParameter("RptPrmProcessingDate", UCase(_nSqlDtr.Item("ProcessDate").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmArea", UCase(_nSqlDtr.Item("AREA").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmInfoOwnership", ProperConsOwner))
                    paramList1.Add(New ReportParameter("RptPrmNoEmp", UCase(_nSqlDtr.Item("NO_EMP").ToString)))


                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList1)

                    ' End If
                End If
            End With
            _nSqlCmd.Dispose()
            _nSqlDtr.Dispose()

            With _nClass2
                Dim _nDataTable4 As New DataTable
                '' ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                ''   ._pAction = "SELECT"

                _nSqlCmd = New SqlCommand(" Select top 1  ORNO1 as ORNo,Convert(varchar,L_DATEPD,101) as ORDate, (Select top 1 (Isnull(sum(CASH_AMT),0) + Isnull(sum(CHECK_AMT),0) + Isnull(sum(MORDER_AMT),0))  " &
                                        " from PAYFILE P Where P.ACCTNO = B.ACCTNO ) as Amount ," &
                                        " (Select top 1 Convert(varchar,CoverPeriod,101) from PAYFILE P Where ACCTNO = B.ACCTNO ) as CoverPeriod" &
                                        " from BUSLINE B where ACCTNO ='" & _nAcctNo & "' and FORYEAR=year(getdate())   ORder by L_DATEPD desc ")
                txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QR5"
                _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
                _nSqlDataAdpt.Fill(_nDataTable4)
                _nSqlCmd.Dispose()
                _nSqlDataAdpt.Dispose()
                ''   ._pExec(_nSuccesful, ErrMsg)



                Dim _nORAmount As Decimal = 0

                If _nDataTable4.Rows.Count > 0 Then

                    Dim _nQtr As String = Request.QueryString("Qtr")
                    Dim _nPeriodCovered As String = _nQtr & " Qtr" & " " & Year(Now)



                    Dim paramList2 As New List(Of ReportParameter)

                    paramList2.Add(New ReportParameter("RptPrmORNo", UCase(_nDataTable4.Rows(0).Item("ORNo").ToString)))
                    paramList2.Add(New ReportParameter("RptPrmORDate", UCase(_nDataTable4.Rows(0).Item("ORDate").ToString)))
                    _nORAmount = IIf(_nDataTable4.Rows(0).Item("Amount").ToString <> "", _nDataTable4.Rows(0).Item("Amount").ToString, 0)
                    paramList2.Add(New ReportParameter("RptPrmORAmount", _nORAmount))
                    paramList2.Add(New ReportParameter("RptPrmPeriodCover", _nPeriodCovered))


                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList2)

                End If

            End With

            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()


            With _nClass2
                Dim _nDataTable5 As New DataTable


                ''  ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                ''  ._pAction = "SELECT"

                '_nSqlCmd = New SqlCommand("	Select ( select  Top 1 isnull(designation,'') from PERSCODE B Where DESIGNATION = A.SAFP1 ) as RecomApprovDesig  , " &
                '                            " (Select top 1 Isnull(Title,'') + ' ' + Isnull(FNAME,'') + ' ' + Isnull(MNAME,'') + ' ' + Isnull(LNAME,'') from PERSCODE  A " &
                '                            " Where DESIGNATION in ('CITY TREASURER' ,  'MUNICIPAL TREASURER')) AS RecomApprovName  " &
                '                            " from TOPSETUP A ")
                '
                _nSqlCmd = New SqlCommand("	Select ( select  Top 1 isnull(designation,'') from PERSCODE B Where DESIGNATION = A.SAFP1 ) as RecomApprovDesig  , " &
                                            " (Select top 1 Isnull(Title,'') + ' ' + Isnull(FNAME,'') + ' ' + Isnull(MNAME,'') + ' ' + Isnull(LNAME,'') from PERSCODE  A " &
                                            " Where  DESIGNATION = SAFP1) AS RecomApprovName  " &
                                            " from TOPSETUP A ")
                txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QR6"



                'Select ( select  Top 1 isnull(designation,'') from PERSCODE B Where DESIGNATION = A.SAFP1 ) as RecomApproved  ,
                '(Select top 1 Isnull(FNAME,'') + ' ' + Isnull(MNAME,'') + ' ' + Isnull(LNAME,'') from PERSCODE  A
                'Where DESIGNATION in ('CITY TREASURER' ,  'MUNICIPAL TREASURER')) AS APPROVEDFORPAYMENT  
                'from [texas\mssql2014].[BPLTAS_CALOOCAN_WEB_2021].dbo.TOPSETUP A

                _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
                _nSqlDataAdpt.Fill(_nDataTable5)
                _nSqlCmd.Dispose()
                _nSqlDataAdpt.Dispose()


                ''----------------------------------------------------------------------------------------


                Dim paramList As New List(Of ReportParameter)

                If _nDataTable5.Rows.Count > 0 Then





                    ''  Dim _nSubDate As String = FormatDateTime(Now, DateFormat.ShortDate)
                    paramList.Add(New ReportParameter("RptPrmExeDate", _nDate1)) ''UCase(Format(CDate(_nDate), "yyyyMMdd-h:mm AM/PM"
                    paramList.Add(New ReportParameter("RptPrmUserName", UCase(cSessionUser._pLastName & "," & cSessionUser._pFirstName & " " & cSessionUser._pMiddleName)))
                    paramList.Add(New ReportParameter("RptPrmProcessedByDate", _nDate1))
                    paramList.Add(New ReportParameter("RptPrmRecomAprroval", UCase(""))) ''_nDataTable5.Rows(0).Item("RecomApproved").ToString
                    paramList.Add(New ReportParameter("RptPrmRecomAprrovalDate", UCase(_nDate1))) ''_nDataTable5.Rows(0).Item("RecommApprovedate").ToString
                    paramList.Add(New ReportParameter("PrtPrmApprovedPayment", UCase(_nDataTable5.Rows(0).Item("RecomApprovName").ToString))) ''_nDataTable5.Rows(0).Item("APPROVEDFORPAYMENT").ToString

                    If _oRpt_EnvelopeSeal.LocalReport.ReportPath.Contains("BP_TOP_GENERAL_FORMAT") = True Then
                        paramList.Add(New ReportParameter("RptApprovedPayment_Desig", UCase(_nDataTable5.Rows(0).Item("RecomApprovDesig").ToString))) ''_nDataTable5.Rows(0).Item("APPROVEDFORPAYMENT").ToString '' comment error here parameter doesn't exists im the report
                    End If
                    ''comment current paramList.Add(New ReportParameter("RptOnORBeforeDueDate", Format(CDate(_nDueDate), "MMMM dd,yyyy")))
                    ''--------20220117 
                    paramList.Add(New ReportParameter("RptOnORBeforeDueDate", Format(CDate(_nXpiryDate), "MMMM dd,yyyy")))

                    paramList.Add(New ReportParameter("RptPrmRenewORBefore", Year(_nDate1)))
                    paramList.Add(New ReportParameter("RptDate", _nDate1))
                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
                Else
                    paramList.Add(New ReportParameter("RptDate", _nDate1))

                End If

                ''------------------------------------------------------------------------------------ROUTINE DISPLAYING RENEWAL ON OR BEFORE AND MODE OF PAYMENT
                If Right(_nDataTable.Rows(0).Item("Qtr"), 1) = 4 Then

                    ''select TOPRENDATE from SETUP
                    _nSqlCmd = New SqlCommand("select TOPRENDATE from  [" & _nLocServer & "].[" & _nLocDB & "].dbo.SETUP", _nSqllocalCon)
                    Dim _nSqlRd As SqlDataReader = _nSqlCmd.ExecuteReader
                    _nSqlRd.Read()
                    If _nSqlRd.HasRows Then
                        _nTOPRenDate = _nSqlRd.Item("TOPRENDATE")
                        _nTOPRenDate = _nTOPRenDate & "," & Year(_nDate1) + 1
                        ''  paramList.Add(New ReportParameter("RptRenOnBefore", ))
                        paramList.Add(New ReportParameter("RptPrmModeofPayment", "Annual"))
                    End If

                    _nSqlCmd.Dispose()
                    _nSqlRd.Dispose()
                End If


                If Right(_nDataTable.Rows(0).Item("Qtr"), 1) = 1 Then
                    _nTOPRenDate = "January 20," & Year(_nDate1)

                ElseIf Right(_nDataTable.Rows(0).Item("Qtr"), 1) = 2 Then
                    _nTOPRenDate = "April 20," & Year(_nDate1)

                ElseIf Right(_nDataTable.Rows(0).Item("Qtr"), 1) = 3 Then
                    _nTOPRenDate = "July 20," & Year(_nDate1)

                End If


                paramList.Add(New ReportParameter("RptRenOnBefore", _nTOPRenDate))

                If Right(_nDataTable.Rows(0).Item("Qtr"), 1) <> 4 Then
                    paramList.Add(New ReportParameter("RptPrmModeofPayment", "Quaterly"))
                End If

                paramList.Add(New ReportParameter("RptQtr", Right(_nDataTable.Rows(0).Item("Qtr"), 1)))

                paramList.Add(New ReportParameter("RptDate", _nDate1))
                '  End If
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
                ' End With

                ''---------------------------------------------------------------------------------------------------------------------------------------



                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()


            End With


        Catch ex As Exception

        End Try

    End Sub

    Public Sub _GenerateReport_BP_APPFORM2()

        Dim _nSqlDataAdpt As New SqlDataAdapter
        Dim _nSqlDataRdr As SqlDataReader
        Dim _nSqlCmd As New SqlCommand
        Dim _nDatatable As New DataTable


        Dim _nClass_web As New CDalGenPaymentBusline
        Dim _nC As New cDalBPSOS

        Dim _nGetTotal As Decimal = 0
        Dim _nTOPRenDate As String = Nothing
        Dim _nNEWSW As String = Nothing
        Dim _nHasRecord As Integer = 0
        Dim _nTempTable As String


        Try


            Dim _nStatCode As String = Request.QueryString("STATCODE")
            Dim _nType As String = Request.QueryString("TYPE")
            Dim _nQTR As String = Request.QueryString("TYPE")
            Dim nDt As New DataTable
            Dim _nAcctNo As String = Nothing
            Dim _nLocServer As String = Nothing
            Dim _nLocDB As String = Nothing
            Dim _nDate1 As String
            Dim _nForyear As String
            Dim _nSqllocalCon As SqlConnection
            Dim _nSqlCon As SqlConnection

            _nTempTable = cSessionUser._pUserID
            ''---------------------------------------------------------------------SET CONNECTION
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR

            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nLocServer = _nClBP._pDBDataSource
            _nLocDB = _nClBP._pDBInitialCatalog

            _nSqllocalCon = cGlobalConnections._pSqlCxn_BPLTAS
            _nSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            _nC._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            ''---------------------------------------------------------------------
            _nAcctNo = cSessionLoader._pAccountNo
            _nC._pSubGetCurYear()
            _nForyear = _nC._nCurYear
            _nDate1 = _nC._nCurDate



            ''-------------------------------------------------------------------------BUSINESS ACTIVITY , Added display in Mode of Payment
            _nSqlCmd = New SqlCommand(" Select Distinct  Case When BUSTAX <> 0  then  MODEPAY else '' end as MODEP , (Select isnull(grossrec0,0) from Busline as xxx where acctno = busline.acctno and foryear = (busline.foryear-1)  and bus_code = busline.bus_code) as Prev_grossRECOAmnt , " & _
                                  "  (Select isnull(grossrec,0) from Busline as xxx where acctno = busline.acctno and foryear = (busline.foryear-1)  and bus_code = busline.bus_code) as Prev_grossAmnt , " & _
                                     " (Select isnull(BUSTAX,0) from Busline as xxx where acctno = busline.acctno and foryear = (busline.foryear-1)  and bus_code = busline.bus_code) as Prev_bustaxAmnt ," &
                                    " (Select isnull([DESCRIPTION],'') + Case When ISNULL(PROVISION,'') <> '' then ' (' + isnull(PROVISION,'')+')' else '' end  from BUSCODE as xxx where BUS_CODE = busline.BUS_CODE  ) as BuslineDesc,* " &
                                    " from BUSLINE Where AcctNo='" & _nAcctNo & "' " &
                                    " and  FORYEAR =cast(YEAR(GETDATE()) as int)")
            '_nSqlDataRdr = _nSqlCmd.ExecuteReader
            _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
            _nSqlDataAdpt.Fill(_nDatatable)

            _nSqlDataAdpt.Dispose()




            If _nDatatable.HasErrors Then
                Return
            End If

            If _nDatatable.Rows.Count <= 0 Then
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
            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_ApplicationForm_NEW.rdlc")
            ' _oRpt_EnvelopeSeal.LocalReport.ReportEmbeddedResource = _gResxRdlc.pReportBP_TOP
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
            Dim _nReportDataSource As New ReportDataSource
            '   _nReportDataSource.Name = "ds_Payment"
            _nReportDataSource.Name = "DataSet1"
            _nReportDataSource.Value = _nDatatable
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)



            If _nDatatable.Rows.Count <> 0 Then
                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("Param_ModePayment", _nDatatable.Rows(0).Item("MODEP").ToString))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

            End If

            ''--------------------------------------------------------------------------------------------ASSESSMENT OF APPLICABLE FEES

            Dim _nDatatable2 As New DataTable

            '               Select ACCTNO, FORYEAR, TAXDESC, isnull(sum(AMOUNTDUE),0) as AMOUNTDUE ,isnull(sum(discount),0) as discount, isnull(sum(PENDUE),0) as PENDUE, 
            '   isnull(sum(TOTAL),0) as TOTAL  FROM  [temp_spidctaxpayer1@gmailcom] Where left(TAXCODE,1) in ('1','2') And acctno='04-002629' 
            'And isnull(TOTAL,'') =''   And Foryear=Year(GetDate()) 
            '  group by ACCTNO,FORYEAR ,TAXDESC 
            '    UNION  
            '	 ( SELECT  ACCTNO,FORYEAR,CATEGORY+  ' (' + CATEGORY1 + ')',
            '	 (select isnull(sum(AMOUNTDUE),0) from [temp_spidctaxpayer1@gmailcom]  where [temp_spidctaxpayer1@gmailcom].BUSCODE =BUSDETAIL_TAXPAYER.BUSCODE  And left(TAXCODE,1)  in ('1','2') ),
            '	(select isnull(sum(DISCOUNT),0) from [temp_spidctaxpayer1@gmailcom]  where [temp_spidctaxpayer1@gmailcom].BUSCODE =BUSDETAIL_TAXPAYER.BUSCODE And left(TAXCODE,1)  in ('1','2') ),
            '	(select isnull(sum(PENDUE),0) from [temp_spidctaxpayer1@gmailcom]  where [temp_spidctaxpayer1@gmailcom].BUSCODE =BUSDETAIL_TAXPAYER.BUSCODE  And left(TAXCODE,1)  in ('1','2') ),
            '	(select isnull(sum(total),0) from [temp_spidctaxpayer1@gmailcom]  where [temp_spidctaxpayer1@gmailcom].BUSCODE =BUSDETAIL_TAXPAYER.BUSCODE And left(TAXCODE,1)  in ('1','2') )
            '   FROM  BUSDETAIL_TAXPAYER where  [ACCTNO] = '04-002629'   And Foryear=Year(GetDate())   ) 


            If _nSqlCon.Database.Contains("CALOOCAN") = True Then

                _nSqlCmd = New SqlCommand("   select ACCTNO, FORYEAR,'BUSINESS TAX'  TAXDESC , " &
                                            " isnull(sum(AMOUNTDUE),0) as AMOUNTDUE ,isnull(sum(discount),0) as discount, isnull(sum(PENDUE),0) as PENDUE,   isnull(sum(TOTAL),0) as TOTAL " &
                                            " from [" & _nTempTable & "_SP_GETPAYMENTBUSLINE]   MainTbl where  [ACCTNO] = '" & _nAcctNo & "'   And Foryear=Year(GetDate()) And left(taxcode,1) in ('1','2') " &
                                            " group by ACCTNO,FORYEAR ---,buscode,taxdesc   order by TAXDESC   ")



            ElseIf _nSqlCon.Database.Contains("SJDM") = True Then

                _nSqlCmd = New SqlCommand(" select ACCTNO, FORYEAR," &
                                            "  Case When isnull(TAXDESC,'') <> '' then isnull(TAXDESC,'') " &
                                            "      Else" &
                                            "   (select top 1 Case when ISNULL([category],'') <> '' then ISNULL([category],'') + ' (' + (ISNULL([category1],'')) + ')'  " &
                                            "       else " &
                                            "   (select Top 1 isnull([description],'') from  [" & _nLocServer & "].[" & _nLocDB & "].dbo.buscode " &
                                            "    where BUSCODE = BUSDETAIL_TAXPAYER.BUSCODE ) end   FROM BUSDETAIL_TAXPAYER " &
                                            "where buscode = MainTbl.buscode and acctno = MainTbl.acctno and FORYEAR = MainTbl.foryear) end TAXDESC , " &
                                            "  isnull(sum(AMOUNTDUE),0) as AMOUNTDUE ,isnull(sum(discount),0) as discount, isnull(sum(PENDUE),0) as PENDUE, " &
                                            "  isnull(sum(TOTAL),0) as TOTAL " &
                                            "  from [" & _nTempTable & "_SP_GETPAYMENTBUSLINE] MainTbl where    [ACCTNO] = '" & _nAcctNo & "'  And Foryear=Year(GetDate()) And left(taxcode,1) in ('1','2')  " &
                                            "  group by ACCTNO,FORYEAR ,buscode,taxdesc                                                                                                         " &
                                            "  order by TAXDESC  ")
            Else
                _nSqlCmd = New SqlCommand(" select ACCTNO, FORYEAR," &
                                          "  Case When isnull(TAXDESC,'') <> '' then isnull(TAXDESC,'') " &
                                          "      Else" &
                                          "   (select top 1 Case when ISNULL([category],'') <> '' then ISNULL([category],'') + ' (' + (ISNULL([category1],'')) + ')'  " &
                                          "       else " &
                                          "   (select Top 1 isnull([description],'') from  [" & _nLocServer & "].[" & _nLocDB & "].dbo.buscode " &
                                          "    where BUSCODE = BUSDETAIL_TAXPAYER.BUSCODE ) end   FROM BUSDETAIL_TAXPAYER " &
                                          "where buscode = MainTbl.buscode and acctno = MainTbl.acctno and FORYEAR = MainTbl.foryear) end TAXDESC , " &
                                          "  isnull(sum(AMOUNTDUE),0) as AMOUNTDUE ,isnull(sum(discount),0) as discount, isnull(sum(PENDUE),0) as PENDUE, " &
                                          "  isnull(sum(TOTAL),0) as TOTAL " &
                                          "  from [" & _nTempTable & "_SP_GETPAYMENTBUSLINE] MainTbl where    [ACCTNO] = '" & _nAcctNo & "'  And Foryear=Year(GetDate()) And left(taxcode,1) in ('1','2')  " &
                                          "  group by ACCTNO,FORYEAR ,buscode,taxdesc                                                                                                         " &
                                          "  order by TAXDESC  ")
            End If





            _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqlCon)
            _nSqlDataAdpt.Fill(_nDatatable2)
            _nSqlDataAdpt.Dispose()


            If _nDatatable2.HasErrors Then
                Return
            End If

            If _nDatatable2.Rows.Count <= 0 Then
                _oRpt_EnvelopeSeal.Enabled = False
            Else
                _oRpt_EnvelopeSeal.Enabled = True
            End If


            Dim _nReportDataSource1 As New ReportDataSource
            '   _nReportDataSource.Name = "ds_Payment"
            _nReportDataSource1.Name = "DataSet2"
            _nReportDataSource1.Value = _nDatatable2
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource1)









            Dim _nDatatable3 As New DataTable



            ''------comment current display

            _nSqlCmd = New SqlCommand("  Select  ACCTNO,FORYEAR,TAXDESC, ISNULL(SUM(AMOUNTDUE),0) AMOUNTDUE, ISNULL(SUM(DISCOUNT),0) DISCOUNT, ISNULL(SUM(PENDUE),0) PENDUE, ISNULL(SUM(TOTAL),0) TOTAL " &
                                        "  from   [" & _nTempTable & "_SP_GETPAYMENTBUSLINE]    WHERE [ACCTNO] = '" & _nAcctNo & "' AND foryear= year(getdate()) " &
                                        " And left(TAXCODE,1) not in ('1','2')  group by ACCTNO, FORYEAR, TAXDESC   " &
                                        "  UNION  	" &
                                        "  	 SELECT '' , '', 'TOTAL FEES for LGU',    " &
                                        "  ISNULL(SUM(AMOUNTDUE),0),  " &
                                         "  ISNULL(SUM(DISCOUNT),0),  " &
                                          "  ISNULL(SUM(PENDUE),0),  " &
                                         "  ISNULL(SUM(TOTAL),0) " &
                                        "from  [" & _nTempTable & "_SP_GETPAYMENTBUSLINE] WHERE [ACCTNO] = '" & _nAcctNo & "' AND foryear= year(getdate()) " &
                                        " order by ACCTNO desc, TAXDESC ")


            '_nSqlCmd = New SqlCommand("WITH XTBL AS ( SELECT ACCTNO, FORYEAR,TAXDESC, QTR,  GROSSAMT,AMOUNTDUE AMOUNTDUE, PENDUE PENDUE, DISCOUNT,TOTAL, " & _
            '             " CASE WHEN ISNULL((SELECT TOP 1 TOPSEQ FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.LABELS WHERE TAXCODE =  [temp_" & cCookieUser._pUserID.Replace(".", "") & "].TAXCODE),'') = ''  " & _
            '             " THEN LEFT(TAXCODE,1) ELSE (SELECT TOP 1 TOPSEQ FROM [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.LABELS WHERE TAXCODE = [temp_" & cCookieUser._pUserID.Replace(".", "") & "].TAXCODE) END AS SEQ " & _
            '             " FROM  [temp_" & cCookieUser._pUserID.Replace(".", "") & "]) " & _
            '             " SELECT ACCTNO, FORYEAR,TAXDESC, QTR,SUM(GROSSAMT) GROSSAMT,SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL,SEQ FROM XTBL  " & _
            '             " where left(SEQ,1) not in ('1','2') " &
            '             " GROUP BY ACCTNO, FORYEAR,TAXDESC,QTR,SEQ " & _
            '             " UNION " & _
            '             " SELECT '' , '', 'TOTAL', '', SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL,'' AS SEQ  FROM  [temp_" & cCookieUser._pUserID.Replace(".", "") & "] WHERE [ACCTNO] = '" & cSessionLoader._pAccountNo & "' AND  Foryear=Year(GetDate()) order by acctno desc,SEQ,GROSSAMT desc ")




            '              WITH XTBL AS ( SELECT ACCTNO, FORYEAR,TAXDESC, QTR,  GROSSAMT, AMOUNTDUE,  PENDUE, DISCOUNT,TOTAL,  CASE WHEN ISNULL((SELECT TOP 1 TOPSEQ 
            'FROM [texas\mssql2014].[BPLTAS_CALOOCAN_WEB_2021].dbo.LABELS WHERE TAXCODE = [temp_spidctaxpayer1@gmailcom].TAXCODE),'') = ''   
            'THEN LEFT(TAXCODE,1) ELSE (SELECT TOP 1 TOPSEQ FROM [texas\mssql2014].[BPLTAS_CALOOCAN_WEB_2021].dbo.LABELS 
            'WHERE TAXCODE = [temp_spidctaxpayer1@gmailcom].TAXCODE) END AS SEQ  FROM [temp_spidctaxpayer1@gmailcom])  
            'SELECT ACCTNO, FORYEAR,TAXDESC, QTR,SUM(GROSSAMT) GROSSAMT,SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , 
            'SUM(TOTAL) TOTAL,SEQ FROM XTBL   GROUP BY ACCTNO, FORYEAR,TAXDESC,QTR,SEQ  UNION  SELECT '' , '', 'TOTAL', '',
            ' SUM(GROSSAMT) GROSSAMT, SUM(AMOUNTDUE) AMOUNTDUE, SUM(PENDUE) PENDUE, SUM(DISCOUNT) DISCOUNT , SUM(TOTAL) TOTAL,'' AS SEQ 
            '  FROM [temp_spidctaxpayer1@gmailcom] 

            '  WHERE [temp_spidctaxpayer1@gmailcom].[ACCTNO] = '04-002629' And [temp_spidctaxpayer1@gmailcom].Foryear=Year(GetDate())
            '      UNION
            '   ( SELECT  ACCTNO,FORYEAR,CATEGORY+  ' (' + CATEGORY1 + ')','',GROSSAMT,'','','','','' FROM  BUSDETAIL_TAXPAYER where  [ACCTNO] = '04-002629' And Foryear=Year(GetDate()) )
            '   order by acctno desc,SEQ,GROSSAMT desc 



            _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqlCon)
            _nSqlDataAdpt.Fill(_nDatatable3)
            _nSqlDataAdpt.Dispose()


            If _nDatatable3.HasErrors Then
                Return
            End If

            If _nDatatable3.Rows.Count <= 0 Then
                _oRpt_EnvelopeSeal.Enabled = False
            Else
                _oRpt_EnvelopeSeal.Enabled = True


            End If


            Dim _nReportDataSource2 As New ReportDataSource
            '   _nReportDataSource.Name = "ds_Payment"
            _nReportDataSource2.Name = "DataSet3"
            _nReportDataSource2.Value = _nDatatable3
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource2)



            Dim paramList1 As New List(Of ReportParameter)


            ''--------------------------------------------------------------------------------------------



            _nSqlCmd = New SqlCommand(" SELECT Case When  isnull(P_OWNER,'') <> '' And  isnull(P_OWNERADDR,'') <> ''  then '1' else '0' end as IsRented , ISNULL(STATCODE,'') AS STATCODE, ISNULL(OWNCODE,'') AS OWNCODE " &
                                        ", isnull(TIN_NO,'') as TIN_NO, isnull(DTI_NO,'') DTI_NO , isnull(CDA_NO,'') CDA_NO " &
                                        " , ISNULL(UPPER(LAST_NAME),'') AS TR_LAST_NAME, ISNULL(UPPER(FIRST_NAME),'') AS TR_FIRST_NAME, ISNULL(UPPER(MIDDLE_NAME),'') AS TR_MIDDLE_NAME " &
                                        " ,ISNULL(UPPER(COMMNAME),'') AS BUSINAME, ISNULL(UPPER(ACCTNO),'') ACCTNO, ISNULL(UPPER(COMMNAME),'') AS TRADENAME,  ISNULL(UPPER(COMMADDR),'') AS BUSIADDR " &
                                        "  ,ISNULL(UPPER(OWNERADDR),'') AS OWNERADDR , ISNULL(UPPER(OWNERTEL),'') AS TEL_MOBILENO,  ISNULL(UPPER(EMAILADDR),'') AS EMAILADDR " &
                                        "  ,(SELECT  TOP 1 ISNULL(SUM(AREA),0)  FROM BUSLINE WHERE BUSLINE.ACCTNO = BUSMAST.ACCTNO GROUP BY FORYEAR ORDER BY FORYEAR DESC ) AS   BUSIAREA_NO " &
                                        "  ,ISNULL(NO_EMP,0) AS NO_EMP, (SELECT Top 1  ISNULL(NO_EMP_LGU,0) FROM BUSMASTEXTN WHERE ACCTNO = BUSMAST.ACCTNO ) AS NO_EMP_LGU  " &
                                        "  ,ISNULL(P_OWNER,'') AS LESSOR_FULLNAME,  ISNULL(P_OWNERADDR,'') AS LESSOR_ADDR " &
                                        "  , (SELECT Top 1 ISNULL(TEL,'') FROM BUSMASTEXTN WHERE ACCTNO = BUSMAST.ACCTNO  ) AS LESSOR_TELNO " &
                                        "  , (SELECT Top 1  ISNULL(EMAIL,'') FROM BUSMASTEXTN WHERE ACCTNO = BUSMAST.ACCTNO) AS LESSOR_EMAIL " &
                                        " ,  ISNULL(P_RENT,'') AS M_RENTAL " &
                                        "   FROM BUSMAST WHERE ACCTNO='" & _nAcctNo & "'", _nSqllocalCon)
            _nSqlDataRdr = _nSqlCmd.ExecuteReader


            If _nSqlDataRdr.HasRows Then
                _nSqlDataRdr.Read()


                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("Param_IsRented", _nSqlDataRdr.Item("IsRented").ToString))
                paramList.Add(New ReportParameter("Param_ACCTNO", cSessionLoader._pAccountNo.ToString))
                paramList.Add(New ReportParameter("Param_APP_DATE", _nDate1))
                paramList.Add(New ReportParameter("Param_TIN_NO", _nSqlDataRdr.Item("TIN_NO").ToString))
                paramList.Add(New ReportParameter("Param_DTI_NO", _nSqlDataRdr.Item("DTI_NO").ToString))
                paramList.Add(New ReportParameter("Param_CDA_NO", _nSqlDataRdr.Item("CDA_NO").ToString))
                paramList.Add(New ReportParameter("Param_OWNCODE", _nSqlDataRdr.Item("OWNCODE").ToString))
                paramList.Add(New ReportParameter("Param_LAST_NAME", UCase(_nSqlDataRdr.Item("TR_LAST_NAME").ToString)))
                paramList.Add(New ReportParameter("Param_FIRST_NAME", _nSqlDataRdr.Item("TR_FIRST_NAME").ToString))
                paramList.Add(New ReportParameter("Param_MIDDLE_NAME", _nSqlDataRdr.Item("TR_MIDDLE_NAME").ToString))
                paramList.Add(New ReportParameter("Param_COMMNAME", UCase(_nSqlDataRdr.Item("BUSINAME").ToString)))

                paramList.Add(New ReportParameter("Param_BusiAddr", _nSqlDataRdr.Item("BUSIADDR").ToString))
                paramList.Add(New ReportParameter("Param_OWNERADDR", _nSqlDataRdr.Item("OWNERADDR").ToString))
                paramList.Add(New ReportParameter("Param_CONTACT", _nSqlDataRdr.Item("TEL_MOBILENO").ToString))
                paramList.Add(New ReportParameter("Param_EMAILADDR", UCase(_nSqlDataRdr.Item("EMAILADDR").ToString)))
                paramList.Add(New ReportParameter("Param_BUSIAREA_NO", _nSqlDataRdr.Item("BUSIAREA_NO").ToString))
                paramList.Add(New ReportParameter("Param_NO_EMP_F", _nSqlDataRdr.Item("NO_EMP").ToString))
                paramList.Add(New ReportParameter("Param_NO_EMP_LGU", UCase(_nSqlDataRdr.Item("NO_EMP_LGU").ToString)))

                paramList.Add(New ReportParameter("Param_LESSOR_FULLNAME", _nSqlDataRdr.Item("LESSOR_FULLNAME").ToString))
                paramList.Add(New ReportParameter("Param_LESSOR_ADDRESS", _nSqlDataRdr.Item("LESSOR_ADDR").ToString))
                paramList.Add(New ReportParameter("Param_LESSOR_TELNO", _nSqlDataRdr.Item("LESSOR_TELNO").ToString))
                paramList.Add(New ReportParameter("Param_LESSOR_EMAIL", UCase(_nSqlDataRdr.Item("LESSOR_EMAIL").ToString)))
                paramList.Add(New ReportParameter("Param_RENT", _nSqlDataRdr.Item("M_RENTAL").ToString))

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

            End If
            _nSqlDataRdr.Dispose()
            _nSqlCmd.Dispose()
            ''--------------------------------------------------------------------------------------------------------------------




            Dim _nDatatable4 As New DataTable
            Dim _n1stPageSignatories As String = Nothing
            Dim _nGetSignatories As String = Nothing
            Dim paramReportHeader As New List(Of ReportParameter)
            _GetReportHeader(_nDatatable4)

            If _nDatatable4.Rows.Count > 0 Then

                paramReportHeader.Add(New ReportParameter("Param_LGUName", UCase(_nDatatable4.Rows(0).Item("ReportHeader2").ToString)))

            End If

            If String.Equals(UCase(_nDatatable4.Rows(0).Item("ReportHeader2").ToString), "CITY OF SAN JOSE DEL MONTE") Then
                paramReportHeader.Add(New ReportParameter("Rpttxt45_LGUName", "City of San Jose del Monte"))
                paramReportHeader.Add(New ReportParameter("Param_TaxOrdinance", "Tax Ordinance No.C-011"))
                paramReportHeader.Add(New ReportParameter("Param_Section", "Sec. 117 of the 2012"))

            ElseIf String.Equals(UCase(_nDatatable4.Rows(0).Item("ReportHeader2").ToString), "CALOOCAN CITY") Then
                paramReportHeader.Add(New ReportParameter("Rpttxt45_LGUName", "Caloocan City"))



            Else
                paramReportHeader.Add(New ReportParameter("Rpttxt45_LGUName", _nDatatable4.Rows(0).Item("ReportHeader2").ToString))
                paramReportHeader.Add(New ReportParameter("Param_TaxOrdinance", "XXXXXX"))
                paramReportHeader.Add(New ReportParameter("XXXXXX"))


            End If

            _n1stPageSignatories = IIf(UCase(_nDatatable4.Rows(0).Item("ReportHeader2").ToString) = "CALOOCAN CITY", "Evangeline M. Garcia", "")

            paramReportHeader.Add(New ReportParameter("Param_STATCODE", _nStatCode))
            paramReportHeader.Add(New ReportParameter("Param_Year", Year(_nDate1)))
            paramReportHeader.Add(New ReportParameter("Param_1stPage_Signatories", _n1stPageSignatories))


            If _nDatatable4.Rows(0).Item("ReportHeader2").ToString.Contains("SAN JOSE DEL MONTE") = True Then
                paramReportHeader.Add(New ReportParameter("Param_SwitchAmntGross", "1"))

            Else
                paramReportHeader.Add(New ReportParameter("Param_SwitchAmntGross", "0"))
            End If

            _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)

            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()


        Catch ex As Exception

        End Try

    End Sub
    Public Sub _GenerateReport_Appointment() 'Gimay 20201027
        Dim _nSortName As String = Request.QueryString("SortBy")
        Try
            Dim _nClass As New cDalAppointment
            With _nClass

                ._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                ._pSubSelectAppointmentReport(cSessionUser._pOffice, Trim(Request.QueryString("AppType")), Trim(Request.QueryString("AppStatus")), Trim(Request.QueryString("From")), Request.QueryString("To"), _nSortName)
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


                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pAppointment
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = False

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "DataSet1"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("PARAM_OFFICE", Request.QueryString("OFFICE")))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True

            End With


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub

    Public Sub _GenerateReport_AppointmentSlip(ByVal AppID As String)
        Try
            Dim _nClass As New cDalAppointment
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

                Dim _nDataTable As New DataTable
                _nDataTable = .Get_AppointmentSlip(AppID)

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

                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pAppointmentSlip
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = False

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "DataSet1"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("ParamSchedulerName", cSessionUser._pLastName & ", " & cSessionUser._pFirstName))

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True

            End With


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub

    Public Sub _GenerateReport_AppointmentList()
        Try
            Dim _nClass As New cDalAppointment
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

                Dim _nDataTable As New DataTable
                _nDataTable = .Get_SchedulerHistory

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

                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pAppointmentList
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = False

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "DataSet1"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("ParamSchedulerName", cSessionUser._pLastName & ", " & cSessionUser._pFirstName))
                paramList.Add(New ReportParameter("ParamDepartment", .Department))
                paramList.Add(New ReportParameter("ParamAppDateFrom", .AppDateFrom))
                paramList.Add(New ReportParameter("ParamAppDateTo", .AppDateTo))
                paramList.Add(New ReportParameter("ParamTransDateFrom", .TransDateFrom))
                paramList.Add(New ReportParameter("ParamTransDateTo", .TransDateTo))
                paramList.Add(New ReportParameter("ParamSortBy", .SortByDesc))
                paramList.Add(New ReportParameter("ParamOrder", .OrderDesc))
                paramList.Add(New ReportParameter("ParamCount", _nDataTable.Rows.Count))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True

            End With


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub
    Public Sub _GenerateReport_TransactionReport()
        Try
            Dim _nClass As New cDalRegistered
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

                Dim _nDataTable As New DataTable
                _nDataTable = cDalRegistered._mDataTable

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

                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pTransactionReport
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = False

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "DataSet1"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("ParamDateFrom", Format(cDalRegistered._DateFrom, "MMM dd, yyyy")))
                paramList.Add(New ReportParameter("ParamDateTo", Format(cDalRegistered._DateTo, "MMM dd, yyyy")))
                paramList.Add(New ReportParameter("ParamSortBy", cDalRegistered._SortBy))
                paramList.Add(New ReportParameter("ParamOrder", cDalRegistered._Order))
                paramList.Add(New ReportParameter("ParamSearchBy", cDalRegistered._SearchBy))
                paramList.Add(New ReportParameter("ParamSearchText", cDalRegistered._SearchText))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True

            End With


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub

    Public Sub _GenerateReport_TOP_2023()
        Try
            Dim DT1 As New DataTable
            Dim DT2 As New DataTable
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            DT1 = _nClass.Get_BusInfo(cSessionLoader._pAccountNo)
            DT2 = _nClass.Get_BillInfo(cSessionLoader._pAccountNo)
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

            _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pBP_TOP_2023
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = False

            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
            Dim rpt_DS1 As New ReportDataSource
            rpt_DS1.Name = "DS_BusInfo"
            rpt_DS1.Value = DT1
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(rpt_DS1)

            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()
            _oRpt_EnvelopeSeal.Enabled = True

            Dim rpt_DS2 As New ReportDataSource
            rpt_DS2.Name = "DS_BillInfo"
            rpt_DS2.Value = DT2
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(rpt_DS2)
            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()
            _oRpt_EnvelopeSeal.Enabled = True

            ' Dim paramList As New List(Of ReportParameter)
            ' paramList.Add(New ReportParameter("ParamDateFrom", Format(cDalRegistered._DateFrom, "MMM dd, yyyy")))
            ' paramList.Add(New ReportParameter("ParamDateTo", Format(cDalRegistered._DateTo, "MMM dd, yyyy")))
            ' paramList.Add(New ReportParameter("ParamSortBy", cDalRegistered._SortBy))
            ' paramList.Add(New ReportParameter("ParamOrder", cDalRegistered._Order))
            ' paramList.Add(New ReportParameter("ParamSearchBy", cDalRegistered._SearchBy))
            ' paramList.Add(New ReportParameter("ParamSearchText", cDalRegistered._SearchText))
            ' _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

            Dim paramList As New List(Of ReportParameter)
            paramList.Add(New ReportParameter("IsTaxbaseHidden", cDalGetModuleSetup.BP_DisplayTaxbase))
            _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub



    Public Sub _GenerateReport_BPSA_NB()
        Try

            Dim _nSuccesful As Boolean, ErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "select * from temp_" & cCookieUser._pUserID.Replace(".", "") & " where ACCTNO = ''" & cSessionLoader._pAccountNo & "'' and FORYEAR = ''" & Year(Now) & "''"
                ._pSortBy = " order by BUSCODE desc, GROSSAMT desc"
                ._pExec(_nSuccesful, ErrMsg)

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
                _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("StatementOfAccount.rdlc") '_gResxRdlc.pBPSA
                '_oRpt_EnvelopeSeal.LocalReport.ReportEmbeddedResource = _gResxRdlc.pReportBPSA
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "ds_Payment"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


                Dim _nClBP As New cDalGlobalConnectionsDefault
                _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                _nClBP._pSubRecordSelectSpecific()


                Dim _nClass2 As New cDal_IUD
                With _nClass2
                    ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                    ._pAction = "SELECT"
                    ._pSelect = " SELECT BM.ACCTNO, (BM.LAST_NAME + '', '' + ISNULL(BM.FIRST_NAME,'''') + '' ''+ ISNULL(BM.MIDDLE_NAME,'''')) as OWNER,BM.COMMNAME AS BUSNAME, BM.COMMADDR  AS BUSADDRESS " & _
                                " ,STUFF((SELECT '' || '' + BC.[DESCRIPTION]  " & _
                                " FROM [" & _nClBP._pDBDataSource & "].[" & _nClBP._pDBInitialCatalog & "].dbo.[BUSCODE] BC " & _
                                " INNER JOIN BUSLINE BL  " & _
                                "  ON BM.ACCTNO = BL.ACCTNO " & _
                                " WHERE BC.[BUS_CODE] = BL.[BUS_CODE] AND BM.ACCTNO = BL.ACCTNO " & _
                             "  FOR XML PATH('''')), 1, 3, '''') AS CATEGORY " & _
                                     " FROM BUSMAST BM  " & _
                                     " INNER JOIN BUSMASTEXTN BMX " & _
                                     " ON BM.ACCTNO = BMX.ACCTNO  " & _
                             " where BM.IsForPayment = 1  " & _
                                    "  AND BMX.FORYEAR = YEAR(GETDATE())  AND BM.[ACCTNO] = ''" & cSessionLoader._pAccountNo & "'' "
                    ._pExec(_nSuccesful, ErrMsg)

                    Dim _nDataTable2 As New DataTable
                    _nDataTable2 = ._pDataTable

                    If _nDataTable2.Rows.Count > 0 Then

                        Dim paramList As New List(Of ReportParameter)

                        Dim _nQtr As String = Request.QueryString("Qtr")
                        Dim _nPeriodCovered As String = Nothing
                        Select Case _nQtr
                            Case "1"
                                _nPeriodCovered = Year(Now) & ", 1"
                            Case "2"
                                _nPeriodCovered = Year(Now) & ", 1 - 2"
                            Case "3"
                                _nPeriodCovered = Year(Now) & ", 1 - 3"
                            Case "4"
                                _nPeriodCovered = Year(Now) & ", 1 - 4"

                        End Select

                        Dim _nDate As String = FormatDateTime(Now, DateFormat.ShortDate)

                        paramList.Add(New ReportParameter("ParamAcctNo", UCase(_nDataTable2.Rows(0).Item("ACCTNO").ToString)))
                        paramList.Add(New ReportParameter("ParamCommName", UCase(_nDataTable2.Rows(0).Item("BUSNAME").ToString)))
                        paramList.Add(New ReportParameter("ParamOwnerName", UCase(_nDataTable2.Rows(0).Item("OWNER").ToString)))
                        paramList.Add(New ReportParameter("ParamCommAddr", UCase(_nDataTable2.Rows(0).Item("BUSADDRESS").ToString)))
                        paramList.Add(New ReportParameter("ParamDateExec", UCase(_nDate)))
                        paramList.Add(New ReportParameter("ParamPeriod", UCase(_nPeriodCovered)))
                        _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                    End If

                End With

                ''Get Report Header

                Dim _nDatatable3 As New DataTable
                _GetReportHeader(_nDatatable3)

                If _nDatatable3.Rows.Count > 0 Then
                    Dim paramReportHeader As New List(Of ReportParameter)

                    paramReportHeader.Add(New ReportParameter("ParamHeader1", UCase(_nDatatable3.Rows(0).Item("ReportHeader1").ToString)))
                    paramReportHeader.Add(New ReportParameter("ParamHeader2", UCase(_nDatatable3.Rows(0).Item("ReportHeader2").ToString)))

                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
                End If



                'Dim paramList As New List(Of ReportParameter)

                'paramList.Add(New ReportParameter("ParamAccountNo", "sample"))
                'paramList.Add(New ReportParameter("ParamCommName", "sample"))
                'paramList.Add(New ReportParameter("ParamOwnerName", "sample"))
                'paramList.Add(New ReportParameter("ParamCommAddr", "sample"))

                '_oReport.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()


            End With


        Catch ex As Exception

        End Try

    End Sub
    Public Sub _GenerateReport_NEW_BP_TOP(ByVal _nAcctNo As String, ByVal _nUSERID As String)
        Dim _nClass_web As New CDalGenPaymentBusline
        Dim _nC As New cDalBPSOS
        Dim _nClass As New cDal_IUD

        Dim _nSqlCmd As SqlCommand
        Dim _nSqlDtr As SqlDataReader
        Dim _nSqlDataAdpt As SqlDataAdapter
        Dim _nSqllocalCon As SqlConnection
        Dim _nSqlCon As SqlConnection
        Dim _nSqlConCR As SqlConnection

        Dim _nSuccesful As Boolean, ErrMsg As String = Nothing
        Dim _nDueDate As String = Nothing
        Dim _nSubQtr As String = Nothing
        Dim _nGetFinalQtr As String = Nothing
        Dim _nHasBillingDate As Boolean = False
        Dim _nTOPRenDate As String = Nothing
        Dim _nDataTable As New DataTable
        Dim _nForyear As String
        Dim _nDate As String

        Dim _nLocServer As String = Nothing
        Dim _nLocDB As String = Nothing
        Dim _nTempTable As String
        Dim _nWEBServer As String = Nothing
        Dim _nWEBDB As String = Nothing
        Dim _nRecCnt As Integer = 0

        Try

            ''---------------------------------------------------------------------SET CONNECTION
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR

            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            _nLocServer = _nClBP._pDBDataSource
            _nLocDB = _nClBP._pDBInitialCatalog
            _nTempTable = "temp_" & _nUSERID.Replace(".", "")


            _nSqllocalCon = cGlobalConnections._pSqlCxn_BPLTAS
            _nSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            _nC._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nWEBServer = _nSqllocalCon.DataSource
            _nWEBDB = _nSqllocalCon.Database
            ''---------------------------------------------------------------------
            _nC._pSubGetCurYear()
            _nForyear = _nC._nCurYear
            _nDate = _nC._nCurDate



            With _nClass
                _nDataTable = _mDtloadTOP(_nSqllocalCon, _nAcctNo)
            End With



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
            Dim mchname As New cHardwareInformation
            Dim _nMachineName As String = Nothing
            _nMachineName = mchname._pMachineName.ToUpper

            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_GENERAL_FORMAT_NEWBP.rdlc")
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()

            Dim _nReportDataSource As New ReportDataSource
            _nReportDataSource.Name = "DsBP_TOP"
            _nReportDataSource.Value = _nDataTable
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

            Dim _nMonthofFeb As Date = Nothing
            Dim _nlastDayOfMonth As Date = Nothing
            Dim _nLastDayOfFeb As String = Nothing
            Dim _nBillDate As String = Nothing
            Dim _nDateNow As DateTime = FormatDateTime(_nDate, DateFormat.ShortDate)

            _nDate = FormatDateTime(_nDate, DateFormat.ShortDate)

            If Month(_nDate) = 2 Then
                _nMonthofFeb = New DateTime(_nDateNow.Year, _nDateNow.Month, 1)
                _nlastDayOfMonth = _nMonthofFeb.AddMonths(1).AddDays(-1)
                _nLastDayOfFeb = _nlastDayOfMonth.Day
            End If

            Dim _nGetQtr As Integer = 1
            Dim _nRowCnt As Integer = 0



            _nBillDate = Format(CDate(_nDate), "MM/dd/yyyy")


            If Left(_nBillDate, 2) <= 3 Then ''------------------get expiry date parameter in RptOnORBeforeDueDate
                _nGetQtr = 1
            ElseIf Left(_nBillDate, 2) <= 6 Then
                _nGetQtr = 2
            ElseIf Left(_nBillDate, 2) <= 9 Then
                _nGetQtr = 3
            ElseIf Left(_nBillDate, 2) <= 12 Then
                _nGetQtr = 4
            End If

            ''  _nGetQtr = Request.QueryString("Qtr")

            _nSqlCmd = New SqlCommand("	SELECT QTREFF as BILL_QTR,Isnull([MONTH],0) as MONTH ,Isnull(EXTNDAY,0) as EXTNDAY, " &
                                      " Isnull(MONTHQ2,'') as MONTHQ2,Isnull(EXTNDAYQ2,'20') as EXTNDAYQ2, " &
                                      "	Isnull(MONTHQ3,'') as MONTHQ3,Isnull(EXTNDAYQ3,'20') as EXTNDAYQ3, " &
                                      " isnull(MONTHQ4,'') as MONTHQ4,Isnull(EXTNDAYQ4,'20') as EXTNDAYQ4," &
                                      " NOMPEN FROM SETUP ", _nSqllocalCon)

            txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QR3"
            Try
                _nSqlDtr = _nSqlCmd.ExecuteReader
            Catch ex As Exception
                txtqr.InnerHtml = "QR3 : " & ex.Message
            End Try



            If _nSqlDtr.HasRows Then
                _nSqlDtr.Read()


                If _nGetQtr = 1 Then ''(Jan - Mar)
                    If _nGetQtr = 1 And _nBillDate <= _nSqlDtr.Item("Month") & "/" & _nSqlDtr.Item("EXTNDAY") & "/" & Year(_nBillDate) Then
                        _nDueDate = _nSqlDtr.Item("MONTH") & "/" & _nSqlDtr.Item("EXTNDAY") & "/" & Year(_nBillDate)
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
                ElseIf _nGetQtr = 2 Then ''(April - June)

                    If _nGetQtr = 2 And _nBillDate <= _nSqlDtr.Item("MONTHQ2") & "/" & _nSqlDtr.Item("MONTHQ2") & "/" & Year(_nBillDate) Then
                        _nDueDate = _nSqlDtr.Item("MONTHQ2") & "/" & _nSqlDtr.Item("EXTNDAYQ2") & "/" & Year(_nBillDate)
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

                ElseIf _nGetQtr = 3 Then ''(July - September)

                    If _nGetQtr = 3 And _nBillDate <= _nSqlDtr.Item("MONTHQ3") & "/" & _nSqlDtr.Item("MONTHQ3") & "/" & Year(_nBillDate) Then
                        _nDueDate = _nSqlDtr.Item("MONTHQ3") & "/" & _nSqlDtr.Item("EXTNDAYQ3") & "/" & Year(_nBillDate)
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
                ElseIf _nGetQtr = 4 Then ''(October - December)

                    If _nGetQtr = 4 And _nBillDate <= _nSqlDtr.Item("MONTHQ4") & "/" & _nSqlDtr.Item("MONTHQ4") & "/" & Year(_nBillDate) Then
                        _nDueDate = _nSqlDtr.Item("MONTHQ4") & "/" & _nSqlDtr.Item("EXTNDAYQ4") & "/" & Year(_nBillDate)
                        '12/31/[Billing Year]
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
                End If
            End If

            _nSqlCmd.Dispose()
            _nSqlDtr.Dispose()






            ''-----------------------------------------------------------------------------------GET CTC ASSESSMENT
            Dim _nDataTable_CTCAss As New DataTable
            Dim _nHasCTCAss As Boolean = False
            Dim _nCTCAssessment, _nXpiryDate As String

            _nCTCAssessment = ""
            : _nXpiryDate = ""

            Try
                _nSqlCmd = New SqlCommand(" select * from BILLINGTEMP where ACCTNO='" & _nAcctNo & "' and isregbill='1' order by (case Taxcode when 'bt' then 0 else 1 end)", _nSqllocalCon)

                ' _nSqlCmd = New SqlCommand(" Select * from billingtemp where acctno ='" & _nAcctNo & "' And isregbill=1 ", _nSqllocalCon)
                _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
                _nSqlDataAdpt.Fill(_nDataTable_CTCAss)
                _nSqlCmd.Dispose()
                _nSqlDataAdpt.Dispose()

                For _nColCnt As Integer = 0 To _nDataTable_CTCAss.Columns.Count
                    If _nDataTable_CTCAss.Columns(_nColCnt).ColumnName = "CTC_REMARK" Then
                        _nHasCTCAss = True
                        Exit For
                    End If
                Next
            Catch ex As Exception
                txtqr.InnerHtml = "QR4 : " & ex.Message
            End Try


            Try

                _nSqlCmd = New SqlCommand(" Select top 1 isnull(DATE_EXPIRE,'')DATE_EXPIRE, isnull(CTC_REMARK,'') CTC_REMARK, CTC_AMOUNT from billingtemp where acctno ='" & _nAcctNo & "' And isregbill='1' ", _nSqllocalCon)
                _nSqlDtr = _nSqlCmd.ExecuteReader
                _nSqlDtr.Read()

                If _nSqlDtr.HasRows Then
                    If _nSqlDtr.Item("DATE_EXPIRE") <> "" Then
                        _nXpiryDate = _nSqlDtr.Item("DATE_EXPIRE")
                    Else
                        _nXpiryDate = _nDueDate
                    End If
                    _nCTCAssessment = _nSqlDtr.Item("CTC_REMARK")
                Else
                    _nCTCAssessment = _nSqlDtr.Item("CTC_REMARK")
                End If

                _nCTCAssessment = _nCTCAssessment.Substring(0, _nCTCAssessment.LastIndexOf("P") + 1)
                ' _nCTCAssessment += String.Format("{0:C}", Sum_TotDue + _nSqlDtr.Item("CTC_AMOUNT")).Replace("$", "")

                _nCTCAssessment += String.Format("{0:C}", _nSqlDtr.Item("CTC_AMOUNT")).Replace("$", "")
                _nSqlCmd.Dispose()
                _nSqlDtr.Dispose()

                If _nXpiryDate = "" Then
                    _nXpiryDate = _nDueDate
                End If

                If _nHasCTCAss = True Then
                    Dim paramReportHeader As New List(Of ReportParameter)

                    paramReportHeader.Add(New ReportParameter("RptCTCAssessment", _nCTCAssessment)) ''---------PARAMETER FOR CTC ASSESSMENT
                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)

                End If

            Catch ex As Exception
                txtqr.InnerHtml = "QR5 : " & ex.Message
            End Try


            Try
                Dim _nDatatable2 As New DataTable
                _GetReportHeader(_nDatatable2)
                Dim _nDatatableNotice As New DataTable
                Dim _nNotice As String = Nothing
                Dim mchname1 As New cHardwareInformation
                Dim _nMachineName1 As String = Nothing
                Dim _nxNotice As String = Nothing
                Dim _nParameterCnt As Integer = 0

                With _nDatatable2
                    Dim paramReportHeader As New List(Of ReportParameter)

                    If .Rows.Count <> 0 Then

                        paramReportHeader.Add(New ReportParameter("RptPrmHeader1", UCase(.Rows(0).Item("ReportHeader1").ToString))) ''REPUBLIC PROVINCE
                        paramReportHeader.Add(New ReportParameter("RptPrmHeader2", UCase(.Rows(0).Item("ReportHeader2").ToString))) ''CITY
                        paramReportHeader.Add(New ReportParameter("RptPrmHeader3", UCase(.Rows(0).Item("ReportHeader3").ToString))) ''PROVINCE
                        paramReportHeader.Add(New ReportParameter("RptPrmHeader4", UCase(.Rows(0).Item("ReportHeader4").ToString))) ''Business Permit and Licensing Office
                        paramReportHeader.Add(New ReportParameter("RptPrmHeader5", UCase(.Rows(0).Item("ReportHeader5").ToString))) ''TAX ORDER OF PAYMENT 

                        ''-------comment current 20220119 mean
                        '    If _oRpt_EnvelopeSeal.LocalReport.ReportPath.Contains("BP_TOP_GENERAL_FORMAT_NEWBP") = True Then
                        '        paramReportHeader.Add(New ReportParameter("RptPrmNotice", .Rows(0).Item("RptNotice").ToString))
                        '    End If
                        '    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
                    End If


                    ''----------------------------------------------------------------------------Display notice



                    '  _nSqlCmd = New SqlCommand(" select isnull(NOTICE1,'')NOTICE1, isnull(NOTICE2,'')NOTICE2, isnull(NOTICE3,'') NOTICE3," & _
                    '          "isnull(NOTICE4,'') NOTICE4, isnull(NOTICE5,'')NOTICE5, isnull(NOTICE6,'')NOTICE6 from TOPSETUP  ", _nSqllocalCon)
                    _nSqlCmd = New SqlCommand(" SELECT " & _
                                 " isnull((select NOTICE1 where len(NOTICE1) > 0),'1. Please pay the amount due at the Treasury Office on or before')NOTICE1, " & _
                                 " isnull((select NOTICE2 where len(NOTICE2) > 0),'2. Failure to do so shall subject the taxdue to 25% Surcharge & 2% Interest per Month')NOTICE2," & _
                                 " isnull((select NOTICE3 where len(NOTICE3) > 0),'3. For Business Retirement, all dues should be paid in full before retirement')NOTICE3," & _
                                 " isnull((select NOTICE4 where len(NOTICE4) > 0),'4. If Amount Due already paid, please disregard NOTICE 1& 2')NOTICE4," & _
                                 " NOTICE5," & _
                                 " NOTICE6" & _
                                 " from TOPSETUP",
                                 _nSqllocalCon)



                    _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
                    _nSqlDataAdpt.Fill(_nDatatableNotice)
                    _nSqlCmd.Dispose()
                    _nSqlDataAdpt.Dispose()

                    For xColCnt As Integer = 0 To _nDatatableNotice.Columns.Count - 1
                        If Not _nDatatableNotice.Rows(0).Item(xColCnt).ToString.Contains("_") Or _nDatatableNotice.Rows(0).Item(xColCnt).ToString.Contains(".") Then
                            _nNotice = _nNotice & _nDatatableNotice.Rows(0).Item(xColCnt).ToString
                        End If
                    Next
                    paramReportHeader.Add(New ReportParameter("RptPrmNotice1", _nDatatableNotice.Rows(0).Item("NOTICE1").ToString))
                    paramReportHeader.Add(New ReportParameter("RptPrmNotice2", _nDatatableNotice.Rows(0).Item("NOTICE2").ToString))
                    paramReportHeader.Add(New ReportParameter("RptPrmNotice3", _nDatatableNotice.Rows(0).Item("NOTICE3").ToString))
                    paramReportHeader.Add(New ReportParameter("RptPrmNotice4", _nDatatableNotice.Rows(0).Item("NOTICE4").ToString))
                    paramReportHeader.Add(New ReportParameter("RptPrmNotice5", _nDatatableNotice.Rows(0).Item("NOTICE5").ToString))
                    paramReportHeader.Add(New ReportParameter("RptPrmNotice6", _nDatatableNotice.Rows(0).Item("NOTICE6").ToString))



                    If _oRpt_EnvelopeSeal.LocalReport.ReportPath.Contains("BP_TOP_GENERAL_FORMAT_NEWBP") = True Then
                        ''------comment current 20220119 mean
                        '' paramReportHeader.Add(New ReportParameter("RptPrmNotice", _nDatatable2.Rows(0).Item("RptNotice").ToString))

                        paramReportHeader.Add(New ReportParameter("RptPrmNotice", _nNotice))
                        _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
                    End If

                End With

            Catch ex As Exception
                txtqr.InnerHtml = "QR6 : " & ex.Message
            End Try






            ''--------------------------------------------------DISPLAY LOGO

            Dim _nClassLOGO As New cDalBPSOS

            With _nClassLOGO
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                ._pDisplayLogo()

                Dim _nDataTableLogo As New DataTable
                _nDataTableLogo = ._pDataTable

                If _nDataTableLogo.Rows.Count > 0 Then
                    Dim _nReportDataSource1 As New ReportDataSource
                    _nReportDataSource1.Name = "DataSet1"
                    _nReportDataSource1.Value = _nDataTableLogo
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource1)

                Else

                End If

            End With

            Dim _nDataTable3 As New DataTable
            Dim _nClass2 As New cDal_IUD
            Dim _nListBusline As String = ""
            With _nClass2
                '._pSqlCon = _nClass_web._mSqlCon
                '._pAction = "SELECT"
                _nSqlCmd = New SqlCommand(" Select ACCTNo,(ISNULL(LAST_NAME,'') + ' ' + ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'')) as TaxPayer ,COMMNAME,COMMADDR" &
                                        " ,(Select isnull(STATDESC,'') from STATCODE S Where S.STATCODE = BUSMAST.STATCODE) as STATCODE," &
                                        " Convert(varchar,GETDATE() ,101) as ProcessDate," &
                                        " (Select isnull(OWNDESC,'') from OWNCODE O Where O.OWNCODE = BUSMAST.OWNCODE ) as OwnCode " &
                                        " ,NO_EMP,(Select top 1 AREA from BUSLINE B  Where B.ACCTNO = BUSMAST.ACCTNO  Order by  FORYEAR desc, AREA desc  ) as AREA " &
                                        " ,(Select top 1 WebAssessNo from [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[BUSDETAIL_TAXPAYER] where acctno='" & _nAcctNo & "') as 'WebAssessNo'" &
                                        " from Busmast  where ACCTNO = '" & _nAcctNo & "'", _nSqllocalCon)
                txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QRX"
                _nSqlDtr = _nSqlCmd.ExecuteReader
                _nSqlDtr.Read()

                If _nSqlDtr.HasRows Then
                    _nDataTable3 = ._pDataTable

                    Dim paramList1 As New List(Of ReportParameter)

                    Dim ProperConsStatus As String = StrConv(_nSqlDtr.Item("STATCODE").ToString, VbStrConv.ProperCase)
                    Dim ProperConsOwner As String = StrConv(_nSqlDtr.Item("OwnCode").ToString, VbStrConv.ProperCase)



                    paramList1.Add(New ReportParameter("RptPrmAcctNo", UCase(_nSqlDtr.Item("ACCTNO").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmTaxpayer", UCase(_nSqlDtr.Item("TaxPayer").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmCommercialName", UCase(_nSqlDtr.Item("COMMNAME").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmInfoCommercialLocation", UCase(_nSqlDtr.Item("COMMADDR").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmInfoStatus", ProperConsStatus))
                    paramList1.Add(New ReportParameter("RptPrmProcessingDate", UCase(_nSqlDtr.Item("ProcessDate").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmArea", UCase(_nSqlDtr.Item("AREA").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmInfoOwnership", ProperConsOwner))
                    paramList1.Add(New ReportParameter("RptPrmNoEmp", UCase(_nSqlDtr.Item("NO_EMP").ToString)))
                    paramList1.Add(New ReportParameter("RptPrmWebAssessNo", UCase(_nSqlDtr.Item("WebAssessNo").ToString)))
                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList1)
                End If


                _nSqlCmd.Dispose()
                _nSqlDtr.Dispose()

                ''-------------------------additional display busline
                Dim _mDatatablelistFees As DataTable

                ''-----------Modified 20220105 
                '_nSqlCmd = New SqlCommand("Select  ((Select [description] from buscode where bus_code = BUSLINE.BUS_CODE)+ ' ' + Bus_code + ': ' + Product) as listProductService,  Bus_code," & _
                '                          "(Select [description] from buscode where bus_code = BUSLINE.BUS_CODE) as LINE," & _
                '                          "Capital, Area, Asset, Product,Bustax,Mayors,Garbage,Sanitary,Fire from BUSLINE where acctno='" & _nAcctNo & "'", _nSqllocalCon)

                ''  with x as (SELECT  count(ACCTNO) as CntBusline ,  ListProductService =     STUFF (        (SELECT    (Select ' | ' + isnull([DESCRIPTION],'') from BUSCODE  where BUS_CODE = busline.BUS_CODE  )		FROM BUSLINE Where AcctNo='L-02396'			FOR XML PATH('')), 1, 1, '' )	 FROM BUSLINE Where    AcctNo='L-02396' GROUP by ACCTNO) select case when CntBusline >=1 then substring(ListProductService,2,len(ListProductService) ) else ListProductService end ListProductService  from x

                _nSqlCmd = New SqlCommand(" with x as (SELECT  count(ACCTNO) as CntBusline ,  ListProductService =     STUFF (        (SELECT    (Select ' | ' + isnull([DESCRIPTION],'') from BUSCODE  where BUS_CODE = busline.BUS_CODE  )		FROM BUSLINE Where AcctNo='" & _nAcctNo & "'			FOR XML PATH('')), 1, 1, '' )	 FROM BUSLINE Where    AcctNo='" & _nAcctNo & "' GROUP by ACCTNO) " & _
                                            "  select case when CntBusline >=1 then substring(ListProductService,2,len(ListProductService) ) else ListProductService end ListProductService  from x ", _nSqllocalCon)


                _mDatatablelistFees = New DataTable
                _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
                _nSqlDataAdpt.Fill(_mDatatablelistFees)
                _nSqlCmd.Dispose()
                _nSqlDataAdpt.Dispose()

                If _mDatatablelistFees.Rows.Count <> 0 Then

                    Dim paramList As New List(Of ReportParameter)

                    paramList.Add(New ReportParameter("RptPrmListBusline", UCase(_mDatatablelistFees.Rows(0).Item("listProductService").ToString)))

                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
                End If

            End With





            With _nClass2
                Dim _nDataTable4 As New DataTable
                Dim _nQtr As String = Request.QueryString("Qtr")
                Dim _nPeriodCovered As String = _nQtr & " Qtr" & " " & _nForyear


                _nSqlCmd = New SqlCommand(" Select top 1  ORNO1 as ORNo,Convert(varchar,L_DATEPD,101) as ORDate, (Select top 1 (Isnull(sum(CASH_AMT),0) + Isnull(sum(CHECK_AMT),0) + Isnull(sum(MORDER_AMT),0))  " &
                                        " from PAYFILE P Where P.ACCTNO = B.ACCTNO ) as Amount ," &
                                        " (Select top 1 Convert(varchar,CoverPeriod,101) from PAYFILE P Where ACCTNO = B.ACCTNO ) as CoverPeriod" &
                                        " from BUSLINE B where ACCTNO ='" & _nAcctNo & "' and FORYEAR=year(getdate())   ORder by L_DATEPD desc ")
                txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QR5"
                _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
                _nSqlDataAdpt.Fill(_nDataTable4)
                _nSqlCmd.Dispose()
                _nSqlDataAdpt.Dispose()




                Dim _nORAmount As Decimal = 0

                If _nDataTable4.Rows.Count > 0 Then

                    With _nDataTable4
                        Dim paramList2 As New List(Of ReportParameter)

                        paramList2.Add(New ReportParameter("RptPrmORNo", UCase(.Rows(0).Item("ORNo").ToString)))
                        paramList2.Add(New ReportParameter("RptPrmORDate", UCase(.Rows(0).Item("ORDate").ToString)))
                        _nORAmount = IIf(.Rows(0).Item("Amount").ToString <> "", .Rows(0).Item("Amount").ToString, 0)
                        paramList2.Add(New ReportParameter("RptPrmORAmount", _nORAmount))
                        paramList2.Add(New ReportParameter("RptPrmPeriodCover", _nPeriodCovered))


                        _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList2)
                        _oRpt_EnvelopeSeal.AsyncRendering = True
                        _oRpt_EnvelopeSeal.LocalReport.Refresh()
                    End With

                End If
            End With



            With _nClass2
                Dim _nDataTable5 As New DataTable

                '
                _nSqlCmd = New SqlCommand("	    select top 1 (select top 1 EDPPRINTED from BILLINGTEMP where acctno='" & _nAcctNo & "' ) as 'UserName',A.PB, A.RAB, ( Isnull(C.Title,'') + ' ' + Isnull(C.FNAME,'') + ' ' + Isnull(C.MNAME,'') + ' ' + Isnull(C.LNAME,'')) as Left_Signatory,C.DESIGNATION as Left_Designation,	( Isnull(B.Title,'') + ' ' + Isnull(B.FNAME,'') + ' ' + Isnull(B.MNAME,'') + ' ' + Isnull(B.LNAME,'')) as Right_Signatory, B.DESIGNATION as Right_Designation	from TOPSETUP A " & _
                                                "left outer join PERSCODE B on A.SAFP1 = b.DESIGNATION    " &
                                                "left outer join PERSCODE C on A.SRAB = C.DESIGNATION  ")
                txtqr.InnerHtml = txtqr.InnerHtml + vbCrLf & "QR6"

                _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd.CommandText, _nSqllocalCon)
                _nSqlDataAdpt.Fill(_nDataTable5)
                _nSqlCmd.Dispose()
                _nSqlDataAdpt.Dispose()

                Dim paramList As New List(Of ReportParameter)





                With _nDataTable5
                    If _nDataTable5.Rows.Count > 0 Then
                        paramList.Add(New ReportParameter("RptPrmExeDate", _nDate))
                        paramList.Add(New ReportParameter("RptPrmUserName", _nDataTable5.Rows(0).Item("UserName").ToString))
                        paramList.Add(New ReportParameter("RptPrmProcessedByDate", _nDate))
                        paramList.Add(New ReportParameter("RptPrmRecomAprroval", UCase("")))
                        paramList.Add(New ReportParameter("RptPrmRecomAprrovalDate", UCase(_nDate)))


                        If _oRpt_EnvelopeSeal.LocalReport.ReportPath.Contains("BP_TOP_GENERAL_FORMAT_NEWBP") = True Then

                            paramList.Add(New ReportParameter("RptPBlabel", _nDataTable5.Rows(0).Item("PB").ToString))
                            paramList.Add(New ReportParameter("RptRABLabel", _nDataTable5.Rows(0).Item("RAB").ToString))

                            paramList.Add(New ReportParameter("RptPrmRecomApproval_Name", UCase(_nDataTable5.Rows(0).Item("Left_Signatory").ToString)))
                            paramList.Add(New ReportParameter("RptPrmRecomApproval_Designation", UCase(_nDataTable5.Rows(0).Item("Left_Designation").ToString)))

                            paramList.Add(New ReportParameter("PrtPrmApprovedPayment", UCase(_nDataTable5.Rows(0).Item("Right_Signatory").ToString)))
                            paramList.Add(New ReportParameter("RptApprovedPayment_Desig", UCase(_nDataTable5.Rows(0).Item("Right_Designation").ToString)))

                        End If
                        If _nDueDate <> "" Then
                            paramList.Add(New ReportParameter("RptOnORBeforeDueDate", Format(CDate(_nXpiryDate), "MMMM dd,yyyy")))
                        End If

                        paramList.Add(New ReportParameter("RptPrmRenewORBefore", Year(_nDate)))
                        paramList.Add(New ReportParameter("RptDate", _nDate))
                        _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
                    Else
                        paramList.Add(New ReportParameter("RptDate", _nDate))

                    End If

                End With

                ''------------------------------------------------------------------------------------ROUTINE DISPLAYING RENEWAL ON OR BEFORE AND MODE OF PAYMENT
                'If Left(_nDataTable.Rows(0).Item("Qtryr1"), 1) = 4 Then

                '    ''select TOPRENDATE from SETUP
                '    _nSqlCmd = New SqlCommand("select TOPRENDATE from  [" & _nLocServer & "].[" & _nLocDB & "].dbo.SETUP", _nSqllocalCon)
                '    Dim _nSqlRd As SqlDataReader = _nSqlCmd.ExecuteReader
                '    _nSqlRd.Read()
                '    If _nSqlRd.HasRows Then
                '        _nTOPRenDate = _nSqlRd.Item("TOPRENDATE")
                '        _nTOPRenDate = _nTOPRenDate & ", " & Year(_nDate) + 1
                '        '         paramList.Add(New ReportParameter("RptPrmModeofPayment", "Annual"))
                '    End If

                '    _nSqlCmd.Dispose()
                '    _nSqlRd.Dispose()
                'End If

                _nSqlCmd = New SqlCommand("select Isnull(TOPRENDATE, 'January 20') as TOPRENDATE from  [" & _nLocServer & "].[" & _nLocDB & "].dbo.SETUP", _nSqllocalCon)
                Dim _nSqlRd As SqlDataReader = _nSqlCmd.ExecuteReader
                _nSqlRd.Read()
                If _nSqlRd.HasRows Then
                    _nTOPRenDate = _nSqlRd.Item("TOPRENDATE")
                    _nTOPRenDate = _nTOPRenDate & ", " & Year(_nDate) + 1
                End If

                _nSqlCmd.Dispose()
                _nSqlRd.Dispose()

                ' If Left(_nDataTable.Rows(0).Item("Pres"), 1) = 1 Then
                '     _nTOPRenDate = "January 20, " & Year(_nDate)
                '
                ' ElseIf Left(_nDataTable.Rows(0).Item("Pres"), 1) = 2 Then
                '     _nTOPRenDate = "April 20, " & Year(_nDate)
                '
                ' ElseIf Left(_nDataTable.Rows(0).Item("Pres"), 1) = 3 Then
                '     _nTOPRenDate = "July 20, " & Year(_nDate)
                '
                ' End If
                Dim _qtr As Integer
                If _nDataTable.Rows(0).Item("Pres") = "1 Qtr" Then
                    _nTOPRenDate = "January 20, " & Year(_nDate)
                    _qtr = 1

                ElseIf _nDataTable.Rows(0).Item("Pres") = "1-2 Qtr" Or
                    _nDataTable.Rows(0).Item("Pres") = "2 Qtr" Then
                    _nTOPRenDate = "April 20, " & Year(_nDate)
                    _qtr = 2

                ElseIf _nDataTable.Rows(0).Item("Pres") = "1-3 Qtr" Or
                    _nDataTable.Rows(0).Item("Pres") = "3 Qtr" Or
                    _nDataTable.Rows(0).Item("Pres") = "2-3 Qtr" Then
                    _nTOPRenDate = "July 20, " & Year(_nDate)
                    _qtr = 3

                ElseIf _nDataTable.Rows(0).Item("Pres") = "1-4 Qtr" Or
                    _nDataTable.Rows(0).Item("Pres") = "2-4 Qtr" Or
                    _nDataTable.Rows(0).Item("Pres") = "3-4 Qtr" Or
                    _nDataTable.Rows(0).Item("Pres") = "4-4 Qtr" Then
                    _nTOPRenDate = "October 20, " & Year(_nDate)
                    _qtr = 4
                End If

                paramList.Add(New ReportParameter("RptRenOnBefore", _nTOPRenDate))

                paramList.Add(New ReportParameter("RptDate", _nDate))
                '  End If

                Dim on_before As String

                If cSessionLoader._pBPQTR = 0 Or cSessionLoader._pBPQTR = Nothing Then
                    paramList.Add(New ReportParameter("RptQtr", _qtr))
                    '---tomi GET MODE OF PAYMENT
                    _nSqlCmd = New SqlCommand(" SELECT top 1 " &
                                              " CASE " &
                                              " WHEN ModeP='A' THEN 'Annual'" &
                                              " WHEN ModeP='S' THEN 'Semi-Annual'" &
                                              " WHEN ModeP='Q' THEN 'Quarterly Installment'" &
                                              " ELSE ModeP" &
                                              " END ModeP" &
                                              " FROM [BILLINGTEMP]" &
                                              " where acctno='" & _nAcctNo & "' and Foryear=year(getdate()) and (taxcode='bt' or taxcode='gf')", _nSqllocalCon)
                    Dim _nSqlRdX As SqlDataReader = _nSqlCmd.ExecuteReader
                    _nSqlRdX.Read()
                    If _nSqlRdX.HasRows Then
                        Dim ModeP As String = _nSqlRdX.Item("ModeP")
                        paramList.Add(New ReportParameter("RptPrmModeofPayment", ModeP))
                    End If
                    _nSqlCmd.Dispose()
                    _nSqlRdX.Dispose()
                    'end tomi
                ElseIf cSessionLoader._pBPQTR = 1 Then
                    paramList.Add(New ReportParameter("RptQtr", 1))
                    paramList.Add(New ReportParameter("RptPrmModeofPayment", "Quarterly Installment"))
                ElseIf cSessionLoader._pBPQTR = 2 Then
                    paramList.Add(New ReportParameter("RptQtr", 2))
                    paramList.Add(New ReportParameter("RptPrmModeofPayment", "Semi-Annual"))
                ElseIf cSessionLoader._pBPQTR = 3 Then
                    paramList.Add(New ReportParameter("RptQtr", 3))
                    paramList.Add(New ReportParameter("RptPrmModeofPayment", "Quarterly Installment"))
                ElseIf cSessionLoader._pBPQTR = 4 Then
                    paramList.Add(New ReportParameter("RptQtr", 4))
                    paramList.Add(New ReportParameter("RptPrmModeofPayment", "Annual"))
                End If


                paramList.Add(New ReportParameter("IsTaxbaseHidden", cDalGetModuleSetup.BP_DisplayTaxbase))

                ' '' '' Access the column you want to hide by its name
                '' ''Dim column As ReportParameterInfo = _oRpt_EnvelopeSeal.LocalReport.GetParameters()("Taxbase")

                ' '' '' Set visibility expression for the column
                '' ''Dim visibilityExpression As String = "=IIF(Parameters!HideColumn.Value = True, True, False)" ' Assuming HideColumn is a boolean parameter controlling visibility

                ' '' '' Apply visibility expression to the column
                '' ''_oRpt_EnvelopeSeal.LocalReport.SetParameters(New ReportParameter("HideColumn", visibilityExpression))




                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
                ' End With

                ''---------------------------------------------------------------------------------------------------------------------------------------



                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()


            End With





        Catch ex As Exception

        End Try

    End Sub


    Public Sub _GenerateReport_BP_APPFORM3(ByVal ACCTNO As String, ByVal Email As String)
        Try
            '----------------------------------
            Dim _nSqlStr As String
            Dim _mDatatable As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = " Select  (Select [description] from buscode where bus_code = BUSLINE.BUS_CODE) as DESCRIPTION,  Bus_code, " & _
                       " (Select [description] from buscode where bus_code = BUSLINE.BUS_CODE) as LINE," & _
                       " Capital, Area, Asset, Product,Bustax,Mayors,Garbage,Sanitary,Fire from BUSLINE where acctno='" & ACCTNO & "'"

            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatable)

            Try
                '----------------------------------
                ' cmb_Brgy.DataSource = _mDatatable
                ' cmb_Brgy.DataTextField = "BRGYDESC"
                ' cmb_Brgy.DataValueField = "DISTCODE_BRGYCODE"
                ' cmb_Brgy.DataBind()

                '----------------------------------
            Catch ex As Exception

            End Try
            '----------------------------------
        Catch ex As Exception

        End Try


    End Sub

    Public Sub _mGenerateReport_NEW_BP_APPFORM(ByVal _nAppID As String, ByVal _nUSERID As String, Optional _nAcctNo As String = "")

        Dim _nClass_web As New CDalGenPaymentBusline

        Dim _nC As New cDalBPSOS

        Dim _nClass As New cDal_IUD


        Dim _nSqlCmd As SqlCommand

        Dim _nSqlDtr As SqlDataReader

        Dim _nSqlDataAdpt As SqlDataAdapter

        Dim _nSqllocalCon As SqlConnection

        Dim _nSqlCon As SqlConnection

        Dim _nSqlConCR As SqlConnection


        Dim _nSuccesful As Boolean, ErrMsg As String = Nothing

        Dim _nDueDate As String = Nothing

        Dim _nSubQtr As String = Nothing

        Dim _nGetFinalQtr As String = Nothing

        Dim _nHasBillingDate As Boolean = False

        Dim _nTOPRenDate As String = Nothing

        Dim _nDataTable As New DataTable

        Dim _nForyear As String

        Dim _nDate As String


        Dim _nLocServer As String = Nothing

        Dim _nLocDB As String = Nothing

        Dim _nTempTable As String

        Dim _nWEBServer As String = Nothing

        Dim _nWEBDB As String = Nothing

        Dim _nRecCnt As Integer = 0

        Try

            ''---------------------------------------------------------------------SET CONNECTION

            Dim _nClBP As New cDalGlobalConnectionsDefault

            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR


            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"

            _nClBP._pSubRecordSelectSpecific()


            _nLocServer = _nClBP._pDBDataSource

            _nLocDB = _nClBP._pDBInitialCatalog

            _nTempTable = "temp_" & _nUSERID.Replace(".", "")



            _nSqllocalCon = cGlobalConnections._pSqlCxn_BPLTAS

            _nSqlCon = cGlobalConnections._pSqlCxn_BPLTAS

            _nC._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS


            _nWEBServer = _nSqllocalCon.DataSource

            _nWEBDB = _nSqllocalCon.Database

            ''---------------------------------------------------------------------

            _nC._pSubGetCurYear()

            _nForyear = _nC._nCurYear

            _nDate = _nC._nCurDate







            '_nSqlCmd = New SqlCommand(" SELECT H_Nature as DESCRIPTION from [NewBP_Draft]  " & _
            '                             "     where Application_ID = '" & _nAppID & "' And UserID='" & _nUSERID & "' ", _nSqlCon)

            _nSqlCmd = New SqlCommand(" Select  (Select [description] from buscode where bus_code = BUSLINE.BUS_CODE) as DESCRIPTION,  Bus_code, " & _
                                        "(Select [description] from buscode where bus_code = BUSLINE.BUS_CODE) as LINE," & _
                                        "Capital, Area, Asset, Product,Bustax,Mayors,Garbage,Sanitary,Fire from BUSLINE where acctno='" & _nAcctNo & "'", _nSqlCon)


            _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd)

            _nDataTable = New DataTable

            _nSqlDataAdpt.Fill(_nDataTable)

            _nSqlCmd.Dispose()

            _nSqlDataAdpt.Dispose()


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


            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_AppForm_New2021.rdlc")


            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()


            Dim _nReportDataSource As New ReportDataSource

            _nReportDataSource.Name = "dsBusInfoDITC"

            _nReportDataSource.Value = _nDataTable

            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)





            _nSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

            _nSqlCmd = New SqlCommand("Select * from [NewBP_Draft] Where Application_ID='" & _nAppID & "' And UserID ='" & _nUSERID & "'", _nSqlCon)

            _nSqlDataAdpt = New SqlDataAdapter(_nSqlCmd)

            _nDataTable = New DataTable

            _nSqlDataAdpt.Fill(_nDataTable)

            _nSqlCmd.Dispose()

            _nSqlDataAdpt.Dispose()

            If _nDataTable.Rows.Count <> 0 Then


                With _nDataTable

                    Dim paramReportHeader As New List(Of ReportParameter)

                    paramReportHeader.Add(New ReportParameter("Param_TrackingNo", ""))

                    paramReportHeader.Add(New ReportParameter("Param_OwnershipType", Trim(.Rows(0).Item("A_OWNCODE").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_DTI_SEC_CDA", (.Rows(0).Item("A_DtiSecCda").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_TIN", (.Rows(0).Item("A_TIN").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusinessName", (.Rows(0).Item("A_BusName").ToString)))

                    ' paramReportHeader.Add(New ReportParameter("Param_TradeName", (.Rows(0).Item("ReportHeader1").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainBldgNo", (.Rows(0).Item("B_HouseNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainBldgName", (.Rows(0).Item("B_BldgName").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainLotNo", (.Rows(0).Item("B_LotNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainBlkNo", (.Rows(0).Item("B_BlockNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainStreet", (.Rows(0).Item("B_Street").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainBrgy", (.Rows(0).Item("B_Brgy").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainSubdivision", (.Rows(0).Item("B_Subd").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainCityMunicipality", (.Rows(0).Item("B_CityMunicipality").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainProvince", (.Rows(0).Item("B_Province").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MainZipCode", (.Rows(0).Item("B_ZipCode").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_TelephoneNo", (.Rows(0).Item("C_TelNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_MobileNo", (.Rows(0).Item("C_MobileNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_EmailAddress", (.Rows(0).Item("C_Email").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_OwnerSurname", (.Rows(0).Item("D_Lname").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_OwnerGivenName", (.Rows(0).Item("D_Fname").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_OwnerMiddleName", (.Rows(0).Item("D_Mname").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_OwnerSuffix", (.Rows(0).Item("D_Suffix").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_PresSurname", (.Rows(0).Item("E_Lname").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_PresGivenName", (.Rows(0).Item("E_Fname").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_PresMiddleName", (.Rows(0).Item("E_Mname").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_PresSuffix", (.Rows(0).Item("E_Suffix").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusinessAreaSqm", (.Rows(0).Item("F_BusArea").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_TotalFlrAreaSqm", (.Rows(0).Item("F_FlrArea").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_NoEmpMale", (.Rows(0).Item("F_MaleEmpNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_NoEmpFemale", (.Rows(0).Item("F_FemaleEmpNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_NoEmpLGU", (.Rows(0).Item("F_ResideEmpNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_NoVanTruck", (.Rows(0).Item("F_VanTruckNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_NoMotorcycle", (.Rows(0).Item("F_MotorNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocBldgNo", (.Rows(0).Item("G_HouseNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocBldgName", (.Rows(0).Item("G_BldgName").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocLotNo", (.Rows(0).Item("G_LotNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocBlkNo", (.Rows(0).Item("G_BlockNo").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocStreet", (.Rows(0).Item("G_Street").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocBrgy", (.Rows(0).Item("G_Brgy").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocSubdivision", (.Rows(0).Item("G_Subd").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocCityMunicipality", (.Rows(0).Item("G_CityMunicipality").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocProvince", (.Rows(0).Item("G_Province").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_BusLocZipCode", (.Rows(0).Item("G_ZipCode").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_Owned", (.Rows(0).Item("H_Owned").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_TaxDecNo", (.Rows(0).Item("H_TDN").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_PropIDNo", (.Rows(0).Item("H_PIN").ToString)))

                    paramReportHeader.Add(New ReportParameter("Param_TotalCapitalization", (.Rows(0).Item("H_Capital").ToString)))


                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)

                End With


            End If

















            _oRpt_EnvelopeSeal.AsyncRendering = True

            _oRpt_EnvelopeSeal.LocalReport.Refresh()

        Catch ex As Exception


        End Try


    End Sub


    Public Function _mDtloadTOP(ByVal _nLocalCon As SqlConnection, ByVal _nAcctNo As String) As DataTable ''-------------Additional 20211211 mean
        Dim _nDt As DataTable
        Dim _nSqlCmd As SqlCommand
        Dim _nSqlDataAdapter As SqlDataAdapter

        Try
            _mDtloadTOP = New DataTable
            ' If cSessionLoader._pBPQTR = 1 Or
            '    cSessionLoader._pBPQTR = 2 Or
            '    cSessionLoader._pBPQTR = 3 Or
            '    cSessionLoader._pBPQTR = 4 Then
            '
            '
            '     Dim q_head As String = "select [Acctno],[Foryear],[Bus_Code],[Desc1],[Taxbase],[Annualdue], cast(PenDue as float)PenDue,Amt_Pd,[Amt_PenPd],[Discount],[Taxcode],[prevqtr],[Qtryr1],[Qtryr2],[QtrPaid],[Prev],[Statcode],[Newsw],[ModeP],[GradFix],[Capital],[Xsort],[ORNo],[DatePaid],[BrgyCode],[LocaCode],[L_DatePD],[MainAcctCode],[MainAcctDesc],[SubAcctCode],[SubAcctDesc],[Amt_Pd1],[Amt_PenPd1],[NewAmt_Pd],[NewAmt_PenPd],[NewTaxdue],[NewPenDue],[FieldName],[PrevGMonth],[GDateEsta],[GMonthPaid],[DATE_ESTA],[YearPeriod],[NotEdit],[NotDel],[AssessTotal],[UsedTCred],[MainAcctDescPen],[NotDelete],[SubAcctCodePen],[SubAcctDescPen],[MainAcctCodePen],[IsRegBill],[ForClose],[Area],[xTotal],[ADUE],[xSQUENCELocal],[xSQUENCEPen],[xSRS],[xORNO],[xSQUENCE],[RES3],[RES4],[RES5],[RES],[RES1],[RES2],[QAMT],[QDUE],[PenYear],[AAMT],[I_DISCOUNT3],[I_DISCOUNT4],[I_DISCOUNT1],[I_DISCOUNT2],[I_YEAR2],[I_YEAR3],[I_YEAR4],[I_YEAR1],[EDITEDBY],[APPROVED],[DATEAPP],[ForCompromise],[ISPOSTED],[EDITTEDBY],[APPROVEDBY],[TAXBALANCE],[PENBALANCE],[xMainAcctCode],[xMainAcctDesc],[xSubAcctCode],[xSubAcctDesc],[xMainAcctCodePen],[xMainAcctDescPen],[xSubAcctCodePen],[xSubAcctDescPen],[NEW1],[NEW2],[NEW3],[NEW4],[NEW5],[RASSESBY],[Remarks],[Remarks0],[Remarks1],[XDEPT],[ORIGDUEFEEADJ],[TRANSTYPE],[EDPPrinted],[BILLVIEW],[ASSESSNO],[BILLTYPE],[CTC_REMARK],[DATE_EXPIRE],[CTC_AMOUNT],"
            '     Dim q_footer = " from BILLINGTEMP  where acctno='" & _nAcctNo & "' and isregbill='1' order by (case Taxcode when 'bt' then 0 else 1 end)"
            '     Dim q_string As String
            '     If cSessionLoader._pBPQTR = 1 Then
            '         q_string = q_head &
            '         "CASE Taxcode  " &
            '         "       WHEN 'bt' THEN  ((cast(Annualdue as money) / 4)) " &
            '         "       WHEN 'gf' THEN  ((cast(Annualdue as money) / 4)) " &
            '         "       ELSE Taxdue" &
            '         "END Taxdue,																			  " &
            '         "CASE Taxcode" &
            '         "       WHEN 'bt' THEN (cast(Annualdue as money) / 4) +  [Amt_PenPd] " &
            '         "       WHEN 'gf' THEN (cast(Annualdue as money) / 4) +  [Amt_PenPd] " &
            '         "       ELSE Totdue																	  " &
            '         "END [Totdue],																		      " &
            '         "pres=STUFF(pres, 3, 1, '1')  														      " &
            '        q_footer
            '     ElseIf cSessionLoader._pBPQTR = 2 Then
            '         q_string = q_head &
            '         "CASE Taxcode  " &
            '         "       WHEN 'bt' THEN (cast(Annualdue as float) / 2 ) " &
            '         "       WHEN 'gf' THEN (cast(Annualdue as float) / 2 ) " &
            '         "       ELSE Taxdue																	  " &
            '         "END Taxdue,																			  " &
            '         "CASE Taxcode  																		  " &
            '         "       WHEN 'bt' THEN  (cast(Annualdue as float) / 2 ) +  [Amt_PenPd]  " &
            '         "       WHEN 'gf' THEN (cast(Annualdue as float) / 2 )  +  [Amt_PenPd] " &
            '         "       ELSE Totdue																	  " &
            '         "END [Totdue],																		      " &
            '         "pres=STUFF(pres, 3, 1, '2')  														      " &
            '        q_footer
            '     ElseIf cSessionLoader._pBPQTR = 3 Then
            '         q_string = q_head &
            '         "CASE Taxcode  " &
            '         "       WHEN 'bt' THEN  (cast(Annualdue as float) / 2 ) + (cast(Annualdue as money) / 4)  " &
            '         "       WHEN 'gf' THEN (cast(Annualdue as float) / 2 ) + (cast(Annualdue as money) / 4)   " &
            '         "       ELSE Taxdue																	  " &
            '         "END Taxdue,																			  " &
            '         "CASE Taxcode  																		  " &
            '         "       WHEN 'bt' THEN ((cast(Annualdue as float) / 2 ) + (cast(Annualdue as money) / 4)) +  [Amt_PenPd] " &
            '         "       WHEN 'gf' THEN ((cast(Annualdue as float) / 2 ) + (cast(Annualdue as money) / 4)) +  [Amt_PenPd] " &
            '         "       ELSE Totdue																	  " &
            '         "END [Totdue],																		      " &
            '         "pres=STUFF(pres, 3, 1, '3')  														      " &
            '        q_footer
            '     ElseIf cSessionLoader._pBPQTR = 4 Then
            '         q_string = q_head &
            '         "CASE Taxcode  " &
            '         "       WHEN 'bt' THEN  cast(Annualdue as float)  " &
            '         "       WHEN 'gf' THEN  cast(Annualdue as float)  " &
            '         "       ELSE Taxdue																	  " &
            '         "END Taxdue,																			  " &
            '         "CASE Taxcode  																		  " &
            '         "       WHEN 'bt' THEN (cast(Annualdue as float)) +  [Amt_PenPd] " &
            '         "       WHEN 'gf' THEN (cast(Annualdue as float)) +  [Amt_PenPd] " &
            '         "       ELSE Totdue																	  " &
            '         "END [Totdue],																		      " &
            '         "pres=STUFF(pres, 3, 1, '4')  														      " &
            '        q_footer
            '     End If
            '
            '
            '     _nSqlCmd = New SqlCommand(q_string)
            ' Else
            cSessionLoader._pBPQTR = 0
            _nSqlCmd = New SqlCommand(" select Bus_Code,Desc1,cast(taxbase as float)taxbase,cast(taxdue as float)Taxdue, cast(PenDue as float)PenDue,  cast(Totdue as float)Totdue,Pres,prev, Discount from BILLINGTEMP where ACCTNO='" & _nAcctNo & "' and isregbill='1' order by (case Taxcode when 'bt' then 0 else 1 end),(case Taxcode when 'gf' then 0 else 1 end)")
            '  End If


            '      _nSqlCmd = New SqlCommand(" Select * from (select Acctno, Foryear, Bus_Code, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, sum(convert(money,Amt_Pd)) as TaxDue,           " & _
            '        "   sum(convert(money,Amt_PenPd)) as Pendue, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount                       " & _
            '        "   from (select Acctno, Foryear, Bus_Code, case when xxx is null then Desc1 else XXX end as Desc1, Taxbase, Pres, Prev, AssessTotal,                          " & _
            '        "   Taxcode, Qtryr1, Amt_Pd, Amt_PenPd, Totdue, Discount from ( select Acctno, Foryear, '' as Bus_Code, upper(MainAcctDesc) as Desc1, '' as Taxbase,           " & _
            '        "   Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd,           " & _
            '        "   Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount, subacctcode , (Select taxdesc from acctlink                      " & _
            '        "   where subacctcode =  billingtemp.SubAcctCode and taxcode = 'BT') as XXX from billingtemp where acctno = '" & _nAcctNo & "' and                               " & _
            '        "   substring(desc1, 1, 9) <> 'TaxCredit' and substring(desc1, 1, 8) <> 'Discount' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and     " & _
            '        "   taxcode = 'bt  '  group by  Acctno, Foryear, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,''), MainAcctDesc, subacctcode) as y) as x group by  Acctno,  " & _
            '        "   Foryear, Bus_Code, desc1, taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1                                                                                " & _
            '       " Union All                                                                                                                                                     " & _
            '     "  select Acctno, Foryear, Bus_Code, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd,                                  " & _
            '     "  sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue,                                                                                  " & _
            '     "  sum(isnull(Discount,0)) as Discount from (select Acctno, Foryear, Bus_Code, 'DISCOUNT ON ' + case when xxx is null then Desc1 else XXX end as Desc1,               " & _
            '     "  Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, Amt_Pd, Amt_PenPd, Totdue, Discount from ( select Acctno, Foryear, '' as Bus_Code,                              " & _
            '     "  upper(MainAcctDesc) as Desc1, '' as Taxbase, '' Pres, '' Prev,  'A02' AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd,     " & _
            '     "  sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount, subacctcode ,                " & _
            '     "  (Select taxdesc from acctlink where subacctcode =  billingtemp.SubAcctCode and taxcode = 'BT') as XXX from billingtemp where acctno = '" & _nAcctNo & "' and         " & _
            '     "  substring(desc1, 1, 8) = 'Discount' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'bt  '                                       " & _
            '     "  group by  Acctno, Foryear, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,''), MainAcctDesc, subacctcode) as y) as x group by  Acctno, Foryear, Bus_Code, desc1,  " & _
            '     "  taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1                                                                                                                  " & _
            '       " Union All                                                                                                                                                          " & _
            '   "    select Acctno, Foryear, Bus_Code, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd,                                  " & _
            '   "    sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount from                          " & _
            '   "    (select Acctno, Foryear, Bus_Code, 'TAX CREDIT ON ' + case when xxx is null then Desc1 else XXX end as Desc1, Taxbase, Pres, Prev,                                 " & _
            '   "    AssessTotal, Taxcode, Qtryr1, Amt_Pd, Amt_PenPd, Totdue, Discount from ( select Acctno, Foryear, '' as Bus_Code, upper(MainAcctDesc) as Desc1, '' as Taxbase,      " & _
            '   "        '' Pres, '' Prev, 'A03' AssessTotal, Taxcode,isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd,                                                " & _
            '   "    sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount, subacctcode ,                " & _
            '   "    (Select taxdesc from acctlink where subacctcode =  billingtemp.SubAcctCode and taxcode = 'BT') as XXX from billingtemp              " & _
            '   "    where acctno = '" & _nAcctNo & "' and substring(desc1, 1, 9) = 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and                   " & _
            '   "    taxcode = 'bt  '  group by  Acctno, Foryear, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,''), MainAcctDesc, subacctcode) as y) as x group by  Acctno,          " & _
            '   "    Foryear, Bus_Code, desc1, taxbase, Pres, Prev, AssessTotal, Taxcode, Qtryr1                                                                                        " & _
            '   "    Union All                                                                                                                                                        " & _
            '   "    select Acctno, Foryear, '' as Bus_Code, 'MAYORS PERMIT FEES' as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1,                     " & _
            '   "    sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue,                                            " & _
            '   "    sum(isnull(convert(money,Discount),0)) as Discount from billingtemp where acctno = '" & _nAcctNo & "' and substring(desc1, 1, 9) <> 'TaxCredit' and                  " & _
            '   "    isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'mf  '  group by  Acctno, Foryear, Taxbase, Pres, Prev, AssessTotal, Taxcode,        " & _
            '   "    isnull(Qtryr1,'')                                                                                                                                                 " & _
            '   "    union all                                                                                                                                                        " & _
            '   "    select Acctno, Foryear, '' as Bus_Code, 'SANITARY FEES' as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1,           " & _
            '   "    sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd,Sum(convert(money,Totdue)) as Totdue,                              " & _
            '   "    sum(isnull(convert(money,Discount),0)) as Discount from billingtemp where acctno = '" & _nAcctNo & "' and substring(desc1, 1, 9) <> 'TaxCredit' and   " & _
            '   "    isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and taxcode = 'sf  '  group by  Acctno, Foryear, Taxbase, Pres, Prev, AssessTotal,  " & _
            '   "    Taxcode, isnull(Qtryr1,'')                                                                                                                          " & _
            '   "    union all                                                                                                                                           " & _
            '    "   select Acctno, Foryear, '' as Bus_Code, 'REFUSE FEE' as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1,                                     " & _
            '    "   sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd,Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount  " & _
            '    "   from billingtemp where acctno = '" & _nAcctNo & "' and substring(desc1, 1, 9) <> 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and         " & _
            '    "   taxcode = 'gf  '  group by  Acctno, Foryear, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'')                                                                  " & _
            '    "   union all                                                                                                                                                                  " & _
            '    "   select Acctno, Foryear, '' as Bus_Code, 'FIRE SAFETY INSP. FEE' as Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1,                            " & _
            '    "   sum(convert(money,Amt_Pd)) as Amt_Pd, sum(convert(money,Amt_PenPd)) as Amt_PenPd,Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount    " & _
            '    "   from billingtemp where acctno = '" & _nAcctNo & "' and substring(desc1, 1, 9) <> 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and           " & _
            '    "   taxcode = 'ff  '  group by  Acctno, Foryear, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'')                                                                    " & _
            '    "   union all                                                                                                                                                                 " & _
            '    "   select Acctno, Foryear, '' as Bus_Code, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'') as Qtryr1, sum(convert(money,Amt_Pd)) as Amt_Pd,         " & _
            '    "   sum(convert(money,Amt_PenPd)) as Amt_PenPd, Sum(convert(money,Totdue)) as Totdue, sum(isnull(convert(money,Discount),0)) as Discount                                 " & _
            '    "   from billingtemp where acctno = '" & _nAcctNo & "' and substring(desc1, 1, 9) <> 'TaxCredit' and isnull(I_YEAR1,'') = '' and not (isnull(REMARKS,'') = 'DELETE') and   " & _
            '    "   not taxcode in ('bt  ','mf  ','sf  ','gf  ','ff  ') group by  Acctno, Foryear, Desc1, Taxbase, Pres, Prev, AssessTotal, Taxcode, isnull(Qtryr1,'')) as xxx           " & _
            '    "   order by Foryear desc, AssessTotal, Bus_Code,  Taxbase, isnull(Qtryr1,'x')")

            _nSqlDataAdapter = New SqlDataAdapter(_nSqlCmd.CommandText, _nLocalCon)
            _nSqlDataAdapter.Fill(_mDtloadTOP)

            For Each dr As DataRow In _mDtloadTOP.Rows
                Sum_TotDue += Convert.ToDouble(dr("Totdue"))
                Sum_TotPenDue += Convert.ToDouble(dr("PenDue"))
                Sum_TotTaxDue += Convert.ToDouble(dr("Taxdue"))
                Sum_TotETC += Convert.ToDouble(IIf(dr("Discount").ToString.Length = 0, 0, dr("Discount")))
            Next
            _nSqlCmd.Dispose()
            _nSqlDataAdapter.Dispose()





        Catch ex As Exception

        End Try


    End Function
    Public Sub _GenerateReport_BPSA_2()
        Try

            Dim _nSuccesful As Boolean, ErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"

                '._pSelect = "Select Isnull(BusCode,'''') as Bus_Code, TAXDESC as Desc1 ,Isnull(GrossAmt,0) as Taxbase, Isnull(Amountdue,0) as Taxdue, " &
                '                   " Isnull(PenDue,'''') as PenDue, Total as totDue ,( Case When QTR <> '''' then QTR + '''' + '' Qtr '' end + Isnull(FORYEAR,'''')) as Pres,discount as Discount  " &
                '                    "  from temp_" & cSessionUser._pUserID.Replace(".", "") &
                '           " where ACCTNO = ''" & cSessionLoader._pAccountNo & "''"
                '._pSortBy = " Order by TaxCode"

                ._pSelect = " Select *" &
                      " ,isnull(case when isnull(TOPSEQ,'''') = '''' then (select top 1 TOPSEQMAIN from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.ACCTLINK where isnull(TAXCODE,'''') = isnull(newTable.TAXCODE,'''')) " &
                      "else TOPSEQ end,''X'') as NEWTOPSEQ from (" &
                      " Select Isnull(BusCode,'''') as Bus_Code, TAXDESC as Desc1 ,Isnull(GrossAmt,0) as Taxbase, Isnull(Amountdue,0) as Taxdue," &
                      "  Isnull(PenDue,'''') as PenDue, Total as totDue ,( Case When QTR <> '''' then QTR + '''' + '' Qtr '' end + Isnull(FORYEAR,'''')) as Pres,  discount as Discount    " &
                       " , (select top 1 TOPSEQ from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.labels where dname = temp_" & cSessionUser._pUserID.Replace(".", "") & ".TAXDESC) as TOPSEQ" &
                       " ,case when TAXDESC = ''GARBAGE FEE''  then ''GF'' when TAXDESC = ''SANITARY FEE'' then ''SF''  " &
                      "	when TAXDESC = ''FIRE FEE'' then ''FF'' when TAXDESC = ''MAYORS FEE'' and isnull(BusCode,'''') <> '''' then ''MF'' " &
                      "	else case when isnull(BusCode,'''') <> ''''  then ''BT'' end 	end as TAXCODE" &
                      " from [" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.[temp_" & cSessionUser._pUserID.Replace(".", "") & "] where ACCTNO = ''" & cSessionLoader._pAccountNo & "'' And Foryear=YEAR(GETDATE())" &
                      " ) as newTable "
                ._pSortBy = " order by Bus_Code desc, NEWTOPSEQ desc "
                ._pExec(_nSuccesful, ErrMsg)

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
                _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_TOP_2.rdlc") '_gResxRdlc.pBPSA
                ' _oRpt_EnvelopeSeal.LocalReport.ReportEmbeddedResource = _gResxRdlc.pReportBP_TOP
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                '   _nReportDataSource.Name = "ds_Payment"
                _nReportDataSource.Name = "DsBP_TOP"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


                'Dim _nClBP As New cDalGlobalConnectionsDefault
                '_nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                '_nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                '_nClBP._pSubRecordSelectSpecific()

                Dim _nDatatable2 As New DataTable
                _GetReportHeader(_nDatatable2)

                If _nDatatable2.Rows.Count > 0 Then
                    Dim paramReportHeader As New List(Of ReportParameter)
                    paramReportHeader.Add(New ReportParameter("RptPrmHeader1", UCase(_nDatatable2.Rows(0).Item("ReportHeader1").ToString)))
                    paramReportHeader.Add(New ReportParameter("RptPrmHeader2", UCase(_nDatatable2.Rows(0).Item("ReportHeader2").ToString)))
                    paramReportHeader.Add(New ReportParameter("RptPrmHeader3", "Business Permit and Licensing Office"))
                    paramReportHeader.Add(New ReportParameter("RptPrmHeader4", "TAX ORDER OF PAYMENT"))
                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
                End If

                Dim _nClass2 As New cDal_IUD
                With _nClass2
                    ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                    ._pAction = "SELECT"
                    ._pSelect = "Select ACCTNo,(LAST_NAME + '' '' + FIRST_NAME + '' '' + MIDDLE_NAME) as TaxPayer ,COMMNAME,COMMADDR" &
",(Select STATDESC from STATCODE S Where S.STATCODE = BUSMAST.STATCODE) as STATCODE," &
"Convert(varchar,GETDATE() ,101) as ProcessDate," &
"(Select OWNDESC from OWNCODE O Where O.OWNCODE = BUSMAST.OWNCODE ) as OwnCode " &
",NO_EMP,(Select top 1 AREA from BUSLINE B  Where B.ACCTNO = BUSMAST.ACCTNO  Order by  FORYEAR desc, AREA desc  ) as AREA " &
"from Busmast  where ACCTNO = ''" & cSessionLoader._pAccountNo & "''"
                    ._pExec(_nSuccesful, ErrMsg)

                    Dim _nDataTable3 As New DataTable
                    _nDataTable3 = ._pDataTable

                    If _nDataTable3.Rows.Count > 0 Then

                        Dim paramList As New List(Of ReportParameter)

                        Dim ProperConsStatus As String = StrConv(_nDataTable3.Rows(0).Item("STATCODE").ToString, VbStrConv.ProperCase)
                        Dim ProperConsOwner As String = StrConv(_nDataTable3.Rows(0).Item("OwnCode").ToString, VbStrConv.ProperCase)
                        Dim _nDate As String = FormatDateTime(Now, DateFormat.ShortDate)

                        paramList.Add(New ReportParameter("RptPrmAcctNo", UCase(_nDataTable3.Rows(0).Item("ACCTNO").ToString)))
                        paramList.Add(New ReportParameter("RptPrmTaxpayer", UCase(_nDataTable3.Rows(0).Item("TaxPayer").ToString)))
                        paramList.Add(New ReportParameter("RptPrmCommercialName", UCase(_nDataTable3.Rows(0).Item("COMMNAME").ToString)))
                        paramList.Add(New ReportParameter("RptPrmInfoCommercialLocation", UCase(_nDataTable3.Rows(0).Item("COMMADDR").ToString)))
                        paramList.Add(New ReportParameter("RptPrmInfoStatus", ProperConsStatus))
                        paramList.Add(New ReportParameter("RptPrmProcessingDate", UCase(_nDataTable3.Rows(0).Item("ProcessDate").ToString)))
                        paramList.Add(New ReportParameter("RptPrmArea", UCase(_nDataTable3.Rows(0).Item("AREA").ToString)))
                        paramList.Add(New ReportParameter("RptPrmInfoOwnership", ProperConsOwner))
                        paramList.Add(New ReportParameter("RptPrmNoEmp", UCase(_nDataTable3.Rows(0).Item("NO_EMP").ToString)))

                        _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                    End If

                End With
            End With
            Dim paramList1 As New List(Of ReportParameter)

            paramList1.Add(New ReportParameter("RptPrmOnlineServiceFee", 5))
            paramList1.Add(New ReportParameter("RptPrmDPB", 115.44))

            paramList1.Add(New ReportParameter("RptPrmGcashOnlineConv", 5))
            paramList1.Add(New ReportParameter("RptPrmGcashFee", 35))


            _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList1)


            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()




        Catch ex As Exception

        End Try

    End Sub


    Public Sub _GenerateReport_BP_APPFORM()
        Try

            Dim _nStatCode As String = Request.QueryString("STATCODE")
            Dim _nType As String = Request.QueryString("TYPE")

            If _nType = "TAXPAYER" Then
                _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_ApplicationFormPage1.rdlc")
            Else
                _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_ApplicationForm.rdlc")
            End If

            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

            Dim info As FieldInfo

            For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next

            _ApplicantAndOtherInfo()

            If _nStatCode = "N" Then
                _BusinessActivity_New()
            Else
                Select Case _nType
                    Case "TAXPAYER"
                        _BusinessActivity_RenewalTaxpayer()
                    Case "BPLO"
                        _BusinessActivity_RenewaBPLO()

                    Case "PAYMENT"
                        _BusinessActivity_RenewalPayment()

                End Select
            End If
            _ApplicableFees()
            ''Get Report Header
            Dim _nDatatable3 As New DataTable
            _GetReportHeader(_nDatatable3)

            If _nDatatable3.Rows.Count > 0 Then
                Dim paramReportHeader As New List(Of ReportParameter)

                paramReportHeader.Add(New ReportParameter("Param_LGUName", UCase(_nDatatable3.Rows(0).Item("ReportHeader2").ToString)))
                paramReportHeader.Add(New ReportParameter("Param_Year", Year(Now)))

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
            End If

            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetAccountInfo_New(ByRef _nDataTable As DataTable)
        Try
            Dim _nSuccesful As Boolean, ErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "Select BM.ACCTNO,BM.STATCODE " & _
                            " ,UPPER(BM.LAST_NAME)LAST_NAME,UPPER(BM.FIRST_NAME)FIRST_NAME,UPPER(BM.MIDDLE_NAME)MIDDLE_NAME,UPPER(BM.COMMNAME)COMMNAME " & _
                            " ,CAST(GETDATE()as date)APP_DATE,BM.TIN_NO,BM.DTI_NO,BM.SEC_NO,BM.CDA_NO,BM.OWNCODE " & _
                            " ,BME.TAX_INDIC,BME.IF_WITH_TAX " & _
                            " ,BM.COMMADDR,BM.EMAILADDR,BM.CPNO,BM.CPNO2,BM.CPNO3,BM.OWNERADDR " & _
                            " ,BM.CONTACT,BM.CONTTEL " & _
                            " ,ISNULL(BME.NO_EMP_F,0)NO_EMP_F, ISNULL(BME.NO_EMP_M,0)NO_EMP_M,ISNULL(BME.NO_EMP_LGU,0)NO_EMP_LGU  " & _
                            " ,UPPER(BME.FIRSTNAME)LESSOR_FIRSTNAME, UPPER(BME.MIDDLENAME)LESSOR_MIDDLENAME, UPPER(BME.LASTNAME)LESSOR_LASTNAME,UPPER(BME.SUBD)LESSOR_ADDRESS,BME.TEL LESSOR_TELNO,BME.EMAIL LESSOR_EMAIL, BM.P_RENT RENT " & _
                            " FROM BUSMAST BM  " & _
                            " INNER JOIN BUSMASTEXTN BME " & _
                            " ON BM.ACCTNO = BME.ACCTNO " & _
                            " where BM.ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND BME.FORYEAR = YEAR(GETDATE()) "
                ._pSortBy = ""
                ._pExec(_nSuccesful, ErrMsg)

                _nDataTable = ._pDataTable
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetAccountInfo_ReNew(ByRef _nDataTable As DataTable)
        Try
            Dim _nSuccesful As Boolean, ErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                ._pAction = "SELECT"
                ._pSelect = "Select BM.ACCTNO,BM.STATCODE " & _
                            " ,UPPER(BM.LAST_NAME)LAST_NAME,UPPER(BM.FIRST_NAME)FIRST_NAME,UPPER(BM.MIDDLE_NAME)MIDDLE_NAME,UPPER(BM.COMMNAME)COMMNAME " & _
                            " ,CAST(GETDATE()as date)APP_DATE,BM.TIN_NO,BM.DTI_NO,BM.SEC_NO,BM.CDA_NO,BM.OWNCODE " & _
                            " ,BME.TAX_INDIC,BME.IF_WITH_TAX " & _
                            " ,BM.COMMADDR,BM.EMAILADDR,BM.CPNO,BM.CPNO2,BM.CPNO3,BM.OWNERADDR " & _
                            " ,BM.CONTACT,BM.CONTTEL " & _
                            " ,ISNULL(BME.NO_EMP_F,0)NO_EMP_F, ISNULL(BME.NO_EMP_M,0)NO_EMP_M,ISNULL(BME.NO_EMP_LGU,0)NO_EMP_LGU  " & _
                            " ,UPPER(BME.FIRSTNAME)LESSOR_FIRSTNAME, UPPER(BME.MIDDLENAME)LESSOR_MIDDLENAME, UPPER(BME.LASTNAME)LESSOR_LASTNAME,UPPER(BME.SUBD)LESSOR_ADDRESS,BME.TEL LESSOR_TELNO,BME.EMAIL LESSOR_EMAIL, BM.P_RENT RENT " & _
                            " FROM BUSMAST BM  " & _
                            " INNER JOIN BUSMASTEXTN BME " & _
                            " ON BM.ACCTNO = BME.ACCTNO " & _
                            " where BM.ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND BME.FORYEAR = YEAR(GETDATE()) - 1 "
                ._pSortBy = ""
                ._pExec(_nSuccesful, ErrMsg)

                _nDataTable = ._pDataTable
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _ApplicantAndOtherInfo()
        Try

            Dim _nStatCode As String = Request.QueryString("STATCODE")

            Dim _nDataTable As New DataTable

            If _nStatCode = "N" Then
                _GetAccountInfo_New(_nDataTable)
            Else
                _GetAccountInfo_ReNew(_nDataTable)
            End If

            If _nDataTable.HasErrors Then
                Return
            End If

            If _nDataTable.Rows.Count <= 0 Then
                _oRpt_EnvelopeSeal.Enabled = False
            Else

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("Param_ACCTNO", UCase(_nDataTable.Rows(0).Item("ACCTNO").ToString)))
                paramList.Add(New ReportParameter("Param_STATCODE", _nStatCode))
                paramList.Add(New ReportParameter("Param_LAST_NAME", UCase(_nDataTable.Rows(0).Item("LAST_NAME").ToString)))
                paramList.Add(New ReportParameter("Param_FIRST_NAME", UCase(_nDataTable.Rows(0).Item("FIRST_NAME").ToString)))
                paramList.Add(New ReportParameter("Param_MIDDLE_NAME", UCase(_nDataTable.Rows(0).Item("MIDDLE_NAME").ToString)))
                paramList.Add(New ReportParameter("Param_COMMNAME", UCase(_nDataTable.Rows(0).Item("COMMNAME").ToString)))
                paramList.Add(New ReportParameter("Param_APP_DATE", UCase(_nDataTable.Rows(0).Item("APP_DATE").ToString)))
                paramList.Add(New ReportParameter("Param_TIN_NO", UCase(_nDataTable.Rows(0).Item("TIN_NO").ToString)))
                paramList.Add(New ReportParameter("Param_DTI_NO", UCase(_nDataTable.Rows(0).Item("DTI_NO").ToString)))
                paramList.Add(New ReportParameter("Param_SEC_NO", UCase(_nDataTable.Rows(0).Item("SEC_NO").ToString)))
                paramList.Add(New ReportParameter("Param_CDA_NO", UCase(_nDataTable.Rows(0).Item("CDA_NO").ToString)))
                paramList.Add(New ReportParameter("Param_OWNCODE", UCase(_nDataTable.Rows(0).Item("OWNCODE").ToString)))
                paramList.Add(New ReportParameter("Param_TAX_INDIC", UCase(_nDataTable.Rows(0).Item("TAX_INDIC").ToString)))
                paramList.Add(New ReportParameter("Param_IF_WITH_TAX", UCase(_nDataTable.Rows(0).Item("IF_WITH_TAX").ToString)))
                paramList.Add(New ReportParameter("Param_COMMADDR", UCase(_nDataTable.Rows(0).Item("COMMADDR").ToString)))
                paramList.Add(New ReportParameter("Param_EMAILADDR", UCase(_nDataTable.Rows(0).Item("EMAILADDR").ToString)))
                paramList.Add(New ReportParameter("Param_CPNO", UCase(_nDataTable.Rows(0).Item("CPNO").ToString)))
                paramList.Add(New ReportParameter("Param_CPNO2", UCase(_nDataTable.Rows(0).Item("CPNO2").ToString)))
                paramList.Add(New ReportParameter("Param_CPNO3", UCase(_nDataTable.Rows(0).Item("CPNO3").ToString)))
                paramList.Add(New ReportParameter("Param_OWNERADDR", UCase(_nDataTable.Rows(0).Item("OWNERADDR").ToString)))
                paramList.Add(New ReportParameter("Param_CONTACT", UCase(_nDataTable.Rows(0).Item("CONTACT").ToString)))
                paramList.Add(New ReportParameter("Param_CONTTEL", UCase(_nDataTable.Rows(0).Item("CONTTEL").ToString)))
                paramList.Add(New ReportParameter("Param_NO_EMP_F", UCase(_nDataTable.Rows(0).Item("NO_EMP_F").ToString)))
                paramList.Add(New ReportParameter("Param_NO_EMP_M", UCase(_nDataTable.Rows(0).Item("NO_EMP_M").ToString)))
                paramList.Add(New ReportParameter("Param_NO_EMP_LGU", UCase(_nDataTable.Rows(0).Item("NO_EMP_LGU").ToString)))
                paramList.Add(New ReportParameter("Param_LESSOR_FIRSTNAME", UCase(_nDataTable.Rows(0).Item("LESSOR_FIRSTNAME").ToString)))
                paramList.Add(New ReportParameter("Param_LESSOR_MIDDLENAME", UCase(_nDataTable.Rows(0).Item("LESSOR_MIDDLENAME").ToString)))
                paramList.Add(New ReportParameter("Param_LESSOR_LASTNAME", UCase(_nDataTable.Rows(0).Item("LESSOR_LASTNAME").ToString)))
                paramList.Add(New ReportParameter("Param_LESSOR_ADDRESS", UCase(_nDataTable.Rows(0).Item("LESSOR_ADDRESS").ToString)))
                paramList.Add(New ReportParameter("Param_LESSOR_TELNO", UCase(_nDataTable.Rows(0).Item("LESSOR_TELNO").ToString)))
                paramList.Add(New ReportParameter("Param_LESSOR_EMAIL", UCase(_nDataTable.Rows(0).Item("LESSOR_EMAIL").ToString)))
                paramList.Add(New ReportParameter("Param_RENT", UCase(_nDataTable.Rows(0).Item("RENT").ToString)))

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub _BusinessActivity_New()
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
                ._pForYear = Year(Now)
                ._pLiveSvr = cSessionLoader._pBPLTAS_SvrName
                ._pLiveDb = cSessionLoader._pBPLTAS_DbName

                ._pExec(_nSuccessfull, _nErrMsg)
                Dim _nDataTable2 As New DataTable
                _nDataTable2 = ._pDataTable

                If _nDataTable2.Rows.Count > 0 Then

                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "dsBusinessActivity"
                    _nReportDataSource.Value = _nDataTable2
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _BusinessActivity_RenewalTaxpayer()
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing


            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT ACCTNO, FORYEAR,(CATEGORY)[DESCRIPTION], CAPITAL, GROSSAMT as GROSSREC, AREA" & _
                            " FROM BUSDETAIL_TAXPAYER "
                ._pCondition = " WHERE Acctno = ''" & cSessionLoader._pAccountNo & "'' and FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccessfull, _nErrMsg)
                Dim _nDataTable2 As New DataTable
                _nDataTable2 = ._pDataTable

                If _nDataTable2.Rows.Count > 0 Then

                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "dsBusinessActivity"
                    _nReportDataSource.Value = _nDataTable2
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _BusinessActivity_RenewaBPLO()
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing


            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT ACCTNO, FORYEAR,(CATEGORY)[DESCRIPTION], CAPITAL, GROSSNEW as GROSSREC, AREA" & _
                            " FROM BUSDETAIL_TAXPAYER "
                ._pCondition = " WHERE Acctno = ''" & cSessionLoader._pAccountNo & "'' and FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccessfull, _nErrMsg)
                Dim _nDataTable2 As New DataTable
                _nDataTable2 = ._pDataTable

                If _nDataTable2.Rows.Count > 0 Then

                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "dsBusinessActivity"
                    _nReportDataSource.Value = _nDataTable2
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _ApplicableFees()
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing


            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " Select * from PAYMENT "
                ._pCondition = " WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' and FORYEAR = YEAR(GETDATE()) "
                ._pSortBy = " ORDER BY BUSCODE DESC, TAXCODE "
                ._pExec(_nSuccessfull, _nErrMsg)
                Dim _nDataTable2 As New DataTable
                _nDataTable2 = ._pDataTable

                If _nDataTable2.HasErrors = False Then

                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "ds_ApplicableFees"
                    _nReportDataSource.Value = _nDataTable2
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _BusinessActivity_RenewalPayment()
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing


            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT ACCTNO, FORYEAR,(CATEGORY)[DESCRIPTION], CAPITAL, GROSSNEW as GROSSREC, AREA" & _
                            " FROM BUSDETAIL_TAXPAYER "
                ._pCondition = " WHERE Acctno = ''" & cSessionLoader._pAccountNo & "'' and FORYEAR = YEAR(GETDATE()) "
                ._pExec(_nSuccessfull, _nErrMsg)
                Dim _nDataTable2 As New DataTable
                _nDataTable2 = ._pDataTable

                If _nDataTable2.Rows.Count > 0 Then

                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "dsBusinessActivity"
                    _nReportDataSource.Value = _nDataTable2
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _GenerateReport_BPINFO()
        Try

            'cSessionLoader._pAccountNo = Request.QueryString("AcctNo")
            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_AccountInformation.rdlc")
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

            Dim info As FieldInfo
            For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next


            _GetBP_Info()
            _GetBP_Destail()
            _GetBP_PaymentHistory()

            ''Get Report Header

            Dim _nDatatable3 As New DataTable
            _GetReportHeader(_nDatatable3)
            If _nDatatable3.Rows.Count > 0 Then
                Dim paramReportHeader As New List(Of ReportParameter)
                paramReportHeader.Add(New ReportParameter("ParamHeader1", UCase(_nDatatable3.Rows(0).Item("ReportHeader1").ToString)))
                paramReportHeader.Add(New ReportParameter("ParamHeader2", UCase(_nDatatable3.Rows(0).Item("ReportHeader2").ToString)))

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
            End If


            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    Private Function _FnGetQtr() As String
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT QTR from Temp_" & cCookieUser._pUserID.Replace(".", "")
                ._pCondition = " WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND FORYEAR = YEAR(GETDATE()) AND isnull(QTR,'''')<>'''' "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.HasErrors Then
                    Return Nothing
                End If

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("QTR").ToString
                Else
                    Return Nothing
                End If

            End With
        Catch ex As Exception

        End Try
    End Function
    Private Sub _GetBP_Info()
        Try

            Dim _nClass As New cDalBPSOS

            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
                ._pAcctNo = cSessionLoader._pAccountNo
                ._pSubGetInformation()

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable


                If _nDataTable.Rows.Count > 0 Then

                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "ds_BusDetail"
                    _nReportDataSource.Value = _nDataTable
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


                End If

            End With




        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetBP_Destail()
        Try
            Dim _nClass As New cDalBPSOS

            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAcctNo = cSessionLoader._pAccountNo
                ._pSubGetDetail()

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable


                If _nDataTable.Rows.Count > 0 Then

                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "ds_BusDetail_Web"
                    _nReportDataSource.Value = _nDataTable
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


                End If

            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetBP_PaymentHistory()
        Try
            Dim _nClass As New cDalBPSOS

            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
                ._pAcctNo = cSessionLoader._pAccountNo
                ._pSubSelectPaymentInquiry_Report()

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable


                If _nDataTable.Rows.Count > 0 Then

                    Dim _nReportDataSource As New ReportDataSource
                    _nReportDataSource.Name = "ds_PaymentInquiry"
                    _nReportDataSource.Value = _nDataTable
                    _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


                End If

            End With

        Catch ex As Exception

        End Try
    End Sub


    Public Sub _GenerateReport_RPTaxDec()
        Try
            'cSessionLoader._pTDN = "02-011-00110-12-R"
            _oRpt_EnvelopeSeal.Reset()

            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("TaxDeclaration.rdlc")
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

            Dim info As FieldInfo
            For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next

            _GetTaxDecInfo()
            _GetAssessmentInfo()
            _GetPaymentHistory()

            ''Get Report Header

            Dim _nDatatable3 As New DataTable
            _GetReportHeader(_nDatatable3)

            If _nDatatable3.Rows.Count > 0 Then
                Dim paramReportHeader As New List(Of ReportParameter)

                paramReportHeader.Add(New ReportParameter("ParamHeader1", UCase(_nDatatable3.Rows(0).Item("ReportHeader1").ToString)))
                paramReportHeader.Add(New ReportParameter("ParamHeader2", UCase(_nDatatable3.Rows(0).Item("ReportHeader2").ToString)))

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
            End If

            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetReportHeader(ByRef _nDataTable As DataTable)

        Try

            Dim _nSuccess As Boolean : Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_CR
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM ReportHeaderSetup "
                ._pExec(_nSuccess, _nErrMsg)

                _nDataTable = ._pDataTable

            End With


        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetReportHeaderRPT(ByRef _nDataTable As DataTable)

        Try

            Dim _nSuccess As Boolean : Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_CR
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM ReportHeaderSetup where ReportType = ''RPT_SOA'' "
                ._pExec(_nSuccess, _nErrMsg)

                _nDataTable = ._pDataTable

            End With


        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetReportHeader2(ByRef _nDataTable As DataTable)
        Try

            Dim _nSuccess As Boolean : Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_CR
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM LGU_Profile "
                ._pExec(_nSuccess, _nErrMsg)

                _nDataTable = ._pDataTable

            End With


        Catch ex As Exception

        End Try
    End Sub


    Private Sub _GetAssessmentInfo()
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
                ._pTDN = cSessionLoader._pTDN
                ._pSubRptInformationAssessment()


                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.HasErrors Then
                    Return
                End If

                If _nDataTable.Rows.Count <= 0 Then
                    _oRpt_EnvelopeSeal.Enabled = False
                Else
                    _oRpt_EnvelopeSeal.Enabled = True

                    Dim paramList As New List(Of ReportParameter)
                    paramList.Add(New ReportParameter("ParamPropKind", UCase(_nDataTable.Rows(0).Item("KIND").ToString)))
                    paramList.Add(New ReportParameter("ParamPropDesc", _nDataTable.Rows(0).Item("CLASSIFICATION").ToString))
                    paramList.Add(New ReportParameter("ParamPropMarket", _nDataTable.Rows(0).Item("MARKET_VAL").ToString))
                    paramList.Add(New ReportParameter("ParamPropActUsage", _nDataTable.Rows(0).Item("ACTUAL_USE").ToString))
                    paramList.Add(New ReportParameter("ParamPropAssLevel", _nDataTable.Rows(0).Item("ASS_LEVEL").ToString))
                    paramList.Add(New ReportParameter("ParamPropAssValue", _nDataTable.Rows(0).Item("ASS_VALUE").ToString))
                    paramList.Add(New ReportParameter("ParamPropArea", _nDataTable.Rows(0).Item("SQAREA").ToString))

                    Dim _nTaxable As Boolean = _nDataTable.Rows(0).Item("TAXABILITY").ToString
                    paramList.Add(New ReportParameter("ParamTaxbility", _nTaxable))


                    Dim _nAssVal As String = _nDataTable.Rows(0).Item("ASS_VALUE").ToString
                    paramList.Add(New ReportParameter("ParamAssAmountInWords", UCase(_FnAmountInWords(_nAssVal))))

                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                End If

            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetPaymentHistory()
        Try
            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            _nClass._pTDN = cSessionLoader._pTDN

            _nClass._pSubRptInformationPay()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable


            If _nDataTable.Rows.Count > 0 Then

                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "ds_PaymentHist"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Function _FnAmountInWords(_nValue As String) As String
        Try
            Dim _nClass2 As New cDalNumberToWords
            With _nClass2
                ._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                ._pValue = _nValue
                ._ConvertNumberToWords()

                Dim _nDataTable As New DataTable

                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("Result")
                End If
            End With
        Catch ex As Exception

        End Try
    End Function
    Private Sub _GetTaxDecInfo()
        Try
            Dim _nClass As New cDalPDSRPTAS
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
                ._pTDN = cSessionLoader._pTDN

                ._pSubRptInformation()

                Dim _nDataTable As New DataTable

                _nDataTable = ._pDataTable

                If _nDataTable.HasErrors Then
                    Return
                End If

                If _nDataTable.Rows.Count <= 0 Then
                    _oRpt_EnvelopeSeal.Enabled = False
                Else
                    _oRpt_EnvelopeSeal.Enabled = True

                    Dim paramList As New List(Of ReportParameter)

                    paramList.Add(New ReportParameter("ParamTDN", UCase(_nDataTable.Rows(0).Item("TDN").ToString)))
                    paramList.Add(New ReportParameter("ParamPropID", UCase(_nDataTable.Rows(0).Item("PIN").ToString)))
                    paramList.Add(New ReportParameter("ParamOwner", UCase(_nDataTable.Rows(0).Item("OWNERNAME").ToString)))
                    paramList.Add(New ReportParameter("ParamOnwerAddress", UCase(_nDataTable.Rows(0).Item("OWNERADDRESS").ToString)))
                    paramList.Add(New ReportParameter("ParamOwnerTIN", UCase(_nDataTable.Rows(0).Item("OWNERTIN").ToString)))
                    paramList.Add(New ReportParameter("ParamOwnerTelNo", UCase(_nDataTable.Rows(0).Item("OWNERTELNO").ToString)))
                    paramList.Add(New ReportParameter("ParamAdmin", UCase(_nDataTable.Rows(0).Item("ADMNAME").ToString)))
                    paramList.Add(New ReportParameter("ParamAdminAddr", UCase(_nDataTable.Rows(0).Item("ADMADDRESS").ToString)))
                    paramList.Add(New ReportParameter("ParamAdminTIN", UCase(_nDataTable.Rows(0).Item("ADMINTIN").ToString)))
                    paramList.Add(New ReportParameter("ParamAdminTelNo", UCase(_nDataTable.Rows(0).Item("ADMTELNO").ToString)))

                    Dim _nPropLoc As String = _nDataTable.Rows(0).Item("LOCATION").ToString & " " & _nDataTable.Rows(0).Item("BARANGAY").ToString

                    paramList.Add(New ReportParameter("ParamPropLoc", UCase(_nPropLoc)))
                    paramList.Add(New ReportParameter("ParamCCT", UCase(_nDataTable.Rows(0).Item("TCT").ToString)))
                    paramList.Add(New ReportParameter("ParamSurveyNo", UCase(_nDataTable.Rows(0).Item("SURVEYNO").ToString)))
                    paramList.Add(New ReportParameter("ParamDated", UCase(_nDataTable.Rows(0).Item("TCT_DATE").ToString)))
                    paramList.Add(New ReportParameter("ParamLotNo", UCase(_nDataTable.Rows(0).Item("LOTE_NO").ToString)))
                    paramList.Add(New ReportParameter("ParamBlkNo", UCase(_nDataTable.Rows(0).Item("BLOCK_NO").ToString)))

                    Dim _nEffDate As Date = _nDataTable.Rows(0).Item("EFF_DATE").ToString

                    Dim _nQtr As String = ((_nEffDate.Month - 1) \ 3) + 1
                    Dim _nEffYear As String = _nEffDate.Year

                    paramList.Add(New ReportParameter("ParamEffQtr", _nQtr))
                    paramList.Add(New ReportParameter("ParamEffYear", _nEffYear))
                    'paramList.Add(New ReportParameter("ParamLandPIN", _nDataTable.Rows(0).Item("ADMTELNO").ToString))
                    'paramList.Add(New ReportParameter("ParamLandAssVal", _nDataTable.Rows(0).Item("ADMTELNO").ToString))
                    'paramList.Add(New ReportParameter("ParamBldgOwner", _nDataTable.Rows(0).Item("ADMTELNO").ToString))
                    'paramList.Add(New ReportParameter("ParamBldgArea", _nDataTable.Rows(0).Item("ADMTELNO").ToString))
                    'paramList.Add(New ReportParameter("ParamBldgPIN", _nDataTable.Rows(0).Item("ADMTELNO").ToString))
                    'paramList.Add(New ReportParameter("ParamBldgAssVal", _nDataTable.Rows(0).Item("ADMTELNO").ToString))

                    _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GenerateReport_RPT_SOA()
        Try

            _oRpt_EnvelopeSeal.Reset()

            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("RPT_SOA_Modified.rdlc")
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

            Dim info As FieldInfo
            For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next

            _GetRPT_Billing()


            ''Get Report Header

            Dim _nDatatable3 As New DataTable
            _GetReportHeaderRPT(_nDatatable3)

            If _nDatatable3.Rows.Count > 0 Then
                Dim paramReportHeader As New List(Of ReportParameter)
                paramReportHeader.Add(New ReportParameter("ParamHeader1", UCase(_nDatatable3.Rows(0).Item("ReportHeader1").ToString)))
                paramReportHeader.Add(New ReportParameter("ParamHeader2", UCase(_nDatatable3.Rows(0).Item("ReportHeader2").ToString)))
                paramReportHeader.Add(New ReportParameter("ParamHeader3", UCase(_nDatatable3.Rows(0).Item("ReportHeader3").ToString)))
                paramReportHeader.Add(New ReportParameter("ParamHeader4", UCase(_nDatatable3.Rows(0).Item("ReportHeader4").ToString)))
                paramReportHeader.Add(New ReportParameter("ParamHeader5", UCase(_nDatatable3.Rows(0).Item("ReportHeader5").ToString)))
                paramReportHeader.Add(New ReportParameter("ParamFooter", UCase(_nDatatable3.Rows(0).Item("ReportFooter").ToString)))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
            End If



            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()


        Catch ex As Exception

        End Try
    End Sub

    Public Sub _GenerateReport_eOR(ByVal _send As String)
        Try
            Dim _nDataTable0 As New DataTable
            _nDataTable0 = ReportViewer.DT0_eOR

            Dim _nDataTable1 As New DataTable
            _nDataTable1 = ReportViewer.DT1_eOR

            Dim _nDataTable2 As New DataTable
            _nDataTable2 = ReportViewer.DT2_eOR






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
            If TAXTYPE_eOR = "REAL PROPERTY TAX" Or TAXTYPE_eOR = "RPT" Then
                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pEOR_RPT2
            ElseIf TAXTYPE_eOR = "BUSINESS PERMIT" Or TAXTYPE_eOR = "BP" Then
                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pEOR_BP2
            End If

            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = False

            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()

            Dim _nReportDataSource0 As New ReportDataSource
            _nReportDataSource0.Name = "DataSet0"
            _nReportDataSource0.Value = _nDataTable0
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource0)

            Dim _nReportDataSource1 As New ReportDataSource
            _nReportDataSource1.Name = "DataSet1"
            _nReportDataSource1.Value = _nDataTable1
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource1)

            Dim _nReportDataSource2 As New ReportDataSource
            _nReportDataSource2.Name = "DataSet2"
            _nReportDataSource2.Value = _nDataTable2
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource2)


            Dim ds_TotalAmount As String
            For Each row As DataRow In DT2_eOR.Rows
                ds_TotalAmount += CDec(row("Amount"))
            Next

            Dim _eOr As New eOR
            Dim strAmount As String = Nothing
            strAmount = _eOr.AmountInWords(ds_TotalAmount)

            Dim paramList As New List(Of ReportParameter)
            paramList.Add(New ReportParameter("AmountInWords", strAmount.ToUpper))

            _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()
            _oRpt_EnvelopeSeal.Enabled = True


            If _send = 1 Then
                Dim bytes As Byte() = _oRpt_EnvelopeSeal.LocalReport.Render("PDF")
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

                cDalNewSendEmail.Send_eOR(eOR.email, "Electronic Official Receipt", body, bytes, sent, err)

                If String.IsNullOrEmpty(err) = True Then
                    eOR.Update_Sent(_nDataTable1.Rows(0)("eORNO"), err)
                    '   ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                    ' ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');window.location.replace('../Account.aspx');", True)
                    Exit Sub
                End If

                'If sent = True Then
                '    Response.Clear()
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                'Else
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + err + "');", True)
                'End If

            End If


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub

    Private Sub _GetRPT_Billing()
        Try
            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
            Dim usertmp As String = cSessionUser._pUserID.Replace(".", "")
            _nClass._pUseTableTmpBill = "tmp0001" & usertmp & "_" & cPageSession_Billing_EntryView._pOrigSrvDateValue '"tmp0001lauroamarquez@gmailcom_20200518143613090" '"tmp0001cercado0427@gmailcom_20200519100606647" '  
            _nClass._pEmail = usertmp
            _nClass._pSubPrint()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Dim _nDataTable1 As New DataTable

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pDisplayLogo()
            _nDataTable1 = _nClass._pDataTable


            If _nDataTable1.Rows.Count > 0 Then
                Dim _nReportDataSource1 As New ReportDataSource
                _nReportDataSource1.Name = "ds_RPT_LGU_PROFILE"
                _nReportDataSource1.Value = _nDataTable1
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource1)
            End If


            If _nDataTable.Rows.Count > 0 Then

                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "ds_RPT_Billing"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim _nEffDate As Date = _nDataTable.Rows(0).Item("EffectDate").ToString

                Dim _nQtr As String = ((_nEffDate.Month - 1) \ 3) + 1
                Dim _nEffYear As String = _nEffDate.Year

                Select Case _nQtr
                    Case "1"
                        _nQtr = "1st"
                    Case "2"
                        _nQtr = "2nd"
                    Case "3"
                        _nQtr = "3rd"
                    Case "4"
                        _nQtr = "4th"

                End Select

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("ParamTDNEffDate", UCase(_nDataTable.Rows(0).Item("TDN").ToString) & " (" & _nQtr & " - " & _nEffYear & ")"))
                paramList.Add(New ReportParameter("ParamRunDate", Date.Now))

                If cSessionLoader._pDEL = "DELIVERY" Then
                    paramList.Add(New ReportParameter("ParamDeliveryFee", 250))
                Else
                    paramList.Add(New ReportParameter("ParamDeliveryFee", 0))
                End If

                Dim _nCompFee As Double = 0
                _nCompFee = cAdditionalFees.GetComputerFee()

                If _nCompFee > 0 Then
                    paramList.Add(New ReportParameter("ParamCompFee", _nCompFee))
                    paramList.Add(New ReportParameter("ParamCompuratizationFee", "Computerization Fee  : "))
                Else
                    paramList.Add(New ReportParameter("ParamCompFee", 0))
                    paramList.Add(New ReportParameter("ParamCompuratizationFee", ""))
                End If

                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub _nGenerateReport_ApplListing()
        Try
            ''  Dim usertmp As String = cSessionUser._pUserID.Replace(".", "")

            Dim _nDatatable As New DataTable
            Dim _nSqlDataAdpt As SqlDataAdapter

            Dim _nsqlCmd = New SqlCommand(cDalVerifications._mSubQuery)
            _nSqlDataAdpt = New SqlDataAdapter(_nsqlCmd.CommandText, cGlobalConnections._pSqlCxn_BPLTIMS)
            _nSqlDataAdpt.Fill(_nDatatable)
            _nSqlDataAdpt.Dispose()

            If _nDatatable.HasErrors Then
                Return
            End If
            _oRpt_EnvelopeSeal.Reset()
            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("BP_EnrollmentList.rdlc")
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
            Dim _nReportDataSource As New ReportDataSource
            _nReportDataSource.Name = "DataSet1"
            _nReportDataSource.Value = _nDatatable
            _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)


            'Dim paramList As New List(Of ReportParameter)
            '_oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _ExportToPDF(ByVal DocType As String, Optional ByVal ID As String = Nothing)
        Try
            Dim warnings As Warning()
            Dim streamIds As String()
            Dim contentType As String
            Dim encoding As String
            Dim extension As String

            'Export the RDLC Report to Byte Array.
            Dim bytes As Byte() = _oRpt_EnvelopeSeal.LocalReport.Render("PDF", Nothing, contentType, encoding, extension, streamIds, warnings)
            'Download the RDLC Report in Word, Excel, PDF and Image formats.
            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.Buffer = True
            HttpContext.Current.Response.Charset = ""
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache)
            HttpContext.Current.Response.ContentType = contentType
            If String.IsNullOrEmpty(ID) Then
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & DocType & "_" & cSessionLoader._pAccountNo & ".pdf")
            Else
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" & DocType & "_" & ID & ".pdf")
            End If

            HttpContext.Current.Response.BinaryWrite(bytes)
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.End()
        Catch ex As Exception
            HttpContext.Current.Response.Write(ex.Message)
        End Try

        '
    End Sub

    Private Sub _GenerateReport_Abstract()
        Try


            _oRpt_EnvelopeSeal.Reset()

            _oRpt_EnvelopeSeal.LocalReport.ReportPath = Server.MapPath("TIMSAbstractReport.rdlc")
            _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

            'Dim info As FieldInfo
            'For Each extension As RenderingExtension In _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions
            '    If extension.Name <> "PDF" Then
            '        info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
            '        info.SetValue(extension, False)
            '    End If
            'Next

            _GetToims_Abstract()

            ''Get Report Header

            Dim _nDatatable3 As New DataTable
            _GetReportHeader(_nDatatable3)

            If _nDatatable3.Rows.Count > 0 Then
                Dim paramReportHeader As New List(Of ReportParameter)
                paramReportHeader.Add(New ReportParameter("ParamHeader1", UCase(_nDatatable3.Rows(0).Item("ReportHeader1").ToString)))
                paramReportHeader.Add(New ReportParameter("ParamHeader2", UCase(_nDatatable3.Rows(0).Item("ReportHeader2").ToString)))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramReportHeader)
            End If



            _oRpt_EnvelopeSeal.AsyncRendering = True
            _oRpt_EnvelopeSeal.LocalReport.Refresh()
            Exit Sub

        Catch ex As Exception

        End Try
    End Sub


    Private Sub _GetToims_Abstract()
        Try
            Dim _mSqlCon As SqlConnection = cGlobalConnections._pSqlCxn_TOIMS


            Dim _nQuery As String = Nothing

            _nQuery = "select * from genabstracttable where idno ='" & cSessionUser._pIDNo & "' order by amount desc"

            Dim _mSqlCommand As SqlCommand = New SqlCommand(_nQuery, _mSqlCon)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_mSqlCommand)
            Dim _mDataTable As DataTable = New DataTable

            _nSqlDataAdapter.Fill(_mDataTable)

            Dim _nDataTable As New DataTable
            _nDataTable = _mDataTable

            If _nDataTable.Rows.Count > 0 Then

                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "TIMSGEN_ABSTRACT_DS"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("paramreport", AbstractReport.ReportType))
                paramList.Add(New ReportParameter("paramdr", "Date: " & AbstractReport.daterange))
                paramList.Add(New ReportParameter("paramrd", "Run Date: " & Date.Now))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class