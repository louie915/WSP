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

Public Class RPTReport
    Inherits System.Web.UI.Page

    Private _mReportType As String

    Public Property _pReportType() As String
        Get
            Return _mReportType
        End Get
        Set(value As String)
            _mReportType = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                Response.Redirect("Register.aspx")
            End If

            Dim _nReportType As String = Request.QueryString("ReportType")

            _oDivPayment.Attributes.Add("style", "display:none")

            Select Case _nReportType
                Case "TOP"
                    _mSubDataPrint()
                    _oDivPayment.Attributes.Add("style", "display:block")
                    'cSessionLoader._pAssessmentNo  = 
                    'cSessionLoader._pRPTtotal = 
                    '_oHyperLinkProceedToPayment.NavigateUrl = "~/VS2014.RPTIMS/RPTIMSPayment.aspx"
            End Select

        Else
            _mReportType = Request.QueryString("ReportType")
        End If
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

        End Try



    End Sub
    Public Sub SavePDFtoDB()
        Dim pdfContent As Byte() = _oMSRV.LocalReport.Render("PDF", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        ''Creatr PDF file on disk
        'Dim pdfPath As String = "C:\MyFile\report.pdf"
        'Dim pdfFile As New System.IO.FileStream(pdfPath, System.IO.FileMode.Create)
        'pdfFile.Write(pdfContent, 0, pdfContent.Length)
        'pdfFile.Close()

        Dim _mFileNo As String = _nFnGenerateFileNo()
        Dim _mFileID As String = cSessionLoader._pAssessmentNo & "_" & _nFnGenerateFileID()
        ClassPageSession_pBilling._pFileNo = _mFileNo
        Dim _nClass3 As New cDalBilling
        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nClass3._pImageData = pdfContent
        _nClass3._pSubSaveReportImage(_mFileNo, _mFileID, cSessionLoader._pAssessmentNo)
    End Sub
    Private Function _nFnGenerateFileID()
        Try
            _nFnGenerateFileID = Nothing
            Dim _nClass As New cDalBilling

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubGenerateFileID()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable2

            Try
                '----------------------------------
                If _nDataTable.Rows.Count <> 0 Then
                    _nFnGenerateFileID = _nDataTable.Rows("0").Item("FileID").ToString
                End If
                '----------------------------------
            Catch ex As Exception

            End Try
            'End If
            '----------------------------------
        Catch ex As Exception

        End Try

    End Function
    Private Function _nFnGenerateFileNo() As String
        Try
            _nFnGenerateFileNo = Nothing
            '----------------------------------
            Dim _nStringID As String = ""
            Dim _nStrAuto As String = ""
            Dim _nStrAutoExtn As String = ""
            Dim _nIntegerID As String = ""

            Dim _nClass As New cDalBilling

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubSelectFileNo()


            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable2

            Try
                '----------------------------------
                'If _nDataTable.HasErrors Then
                '    _mSubShowEmptyTraningCourseGridView()
                'End If

                If _nDataTable.Rows.Count <> 0 Then

                    _nStringID = _nDataTable.Rows("0").Item("FileID").ToString

                    If _nStringID = "" Then

                        _nIntegerID = "000000000000001"
                    Else
                        _nIntegerID = _nStringID
                        _nIntegerID = Format(_nIntegerID + 1, "000000000000000")
                    End If

                    _nStrAuto = _nIntegerID
                End If

                _nFnGenerateFileNo = _nStrAuto

                '----------------------------------
            Catch ex As Exception

            End Try
            'End If
            '----------------------------------
        Catch ex As Exception

        End Try

    End Function
    Protected Function _mSubSendEmail() As Boolean 'Added 20171120

        Dim _nReturnValue As Boolean
        Try
            'Send Email For the Notification
            '----------------------------------
            Dim _mEmailWebMaster As String
            Dim _mPassword As String
            Dim _mEmailCC As String
            Dim _mEmailBCC As String

            Dim _nclassEmailSetup As New cDalGetWebEmailMaster
            _nclassEmailSetup._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nclassEmailSetup._pSubGetEmailMaster()

            _mEmailWebMaster = _nclassEmailSetup._pEmailMaster
            _mPassword = _nclassEmailSetup._pPassword
            _mEmailCC = _nclassEmailSetup._pEmailCC
            _mEmailBCC = _nclassEmailSetup._pEmailBCC
            '----------------------------------

            '----------------------------------
            'Date
            Dim _nDate As String = FormatDateTime(Now, DateFormat.LongDate)

            Dim _nClass As New ClassEmailGoogle
            Dim _nStrucInfo As New ClassEmailGoogle._InfoEmail

            '----------------------------------
            'From
            _nStrucInfo._pEmailFrom = _mEmailWebMaster

            '----------------------------------
            'To
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(cCookieUser._pUserID)
                _nStrucInfo._pEmailTo = _nArrayList

            Catch ex As Exception

            End Try

            '----------------------------------
            'Cc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailCC)
                _nStrucInfo._pEmailCc = _nArrayList

            Catch ex As Exception

            End Try

            '----------------------------------
            'Bcc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailBCC)
                _nStrucInfo._pEmailBcc = _nArrayList

            Catch ex As Exception

            End Try

            '----------------------------------

            'Subject
            _nStrucInfo._pEmailSubject = "Notification"

            '----------------------------------

            'Body --tomi
            _nStrucInfo._pEmailBody = "Sir/Ma`am: <br> " & _
                                "Assessment No. : " & cSessionLoader._pAssessmentNo & _
                                "<br>Grand Total : " & cSessionLoader._pRPTtotal
            '----------------------------------

            'Header
            _nStrucInfo._pEmailHeader = cSessionLoader._pLGU_Name & "<br> <br> "

            '----------------------------------

            'Footer
            _nStrucInfo._pEmailFooter = "<br> Date Sent : " & Now.Date & _
            "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."

            '----------------------------------
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nUrlLink]", "")

            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nUserID]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nFirstName]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nLastName]", "")

            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nDate]", _nDate)
            '----------------------------------
            'Mail Client Credential
            _nStrucInfo._pEMailClientUserName = _mEmailWebMaster
            _nStrucInfo._pEMailClientPassword = _mPassword

            '----------------------------------
            _nClass._pStrucInfo = _nStrucInfo

            If _nClass._pFuncSendEmail() Then
                _nReturnValue = True
                Return True
            Else
                _nReturnValue = False
                Return False
            End If

            _nClass = Nothing

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub _mSubDataPrint()
        Try
            ' The Report

            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS_T
            Dim usertmp As String = cSessionUser._pUserID.Replace(".", "")
            _nClass._pUseTableTmpBill = "tmp0001" & usertmp & "_" & cPageSession_Billing_EntryView._pOrigSrvDateValue
            _nClass._pEmail = usertmp
            _nClass._pSubPrint()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable



            If _nDataTable.HasErrors Then
                Return
            End If

            If _nDataTable.Rows.Count <= 0 Then
                _oMSRV.Enabled = False
                'Return

            Else
                _oMSRV.Enabled = True
            End If
            _oMSRV.Reset()
            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo

            For Each extension As RenderingExtension In _oMSRV.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format


            _oMSRV.LocalReport.ReportPath = _gResxRdlc._pReportBilling
            _oMSRV.LocalReport.EnableExternalImages = True

            _oMSRV.LocalReport.DataSources.Clear()

            Dim _nReportDataSource As New ReportDataSource
            _nReportDataSource.Name = "DataSet1" ' The Name of the dataset in the RDLC Designer.
            _nReportDataSource.Value = _nDataTable
            _oMSRV.LocalReport.DataSources.Add(_nReportDataSource)


            Dim paramList As New List(Of ReportParameter)
            paramList.Add(New ReportParameter("ReportParameter1", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter2", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter3", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter4", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter5", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter6", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter7", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter8", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter9", "Republika ng Pilipinas"))
            paramList.Add(New ReportParameter("ReportParameter10", cSessionLoader._pDEL))
            _oMSRV.LocalReport.SetParameters(paramList)


            _oMSRV.AsyncRendering = True

            _oMSRV.LocalReport.Refresh()
            _oMSRV.Enabled = True

        Catch ex As Exception

        End Try
    End Sub
End Class