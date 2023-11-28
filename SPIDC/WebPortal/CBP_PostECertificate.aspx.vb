Imports System.IO
Imports RestSharp
Imports System.Net

Imports System.Collections.Generic
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Web.Services

Public Class CBP_PostECertificate
    Inherits System.Web.UI.Page


    Dim _mPermitNo As String = Nothing
    Dim _mCommName As String = Nothing
    Dim _mAcctNo As String = Nothing
    Dim _mCBP_transaction_no As String = Nothing
    Dim _mEmailAddr As String
    Dim _mAppDate As String
    Dim ctrmod As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            _BindGridview(GridView4)
            _BindGridviewRevoked(_oGridViewRevoked)
            'Dim action = Request("__EVENTTARGET")
            'Dim val = Request("__EVENTARGUMENT")
            'action = "Post"


            'Dim _nStr() As String
            'Dim valAccount As String
            'Dim valStatus As String
            'If Request("__EVENTARGUMENT").Contains("|") Then
            '    _nStr = Request("__EVENTARGUMENT").Split("|")
            '    valAccount = _nStr(0).ToString
            '    valStatus = _nStr(1).ToString
            'Else
            '    valAccount = Request("__EVENTARGUMENT")
            'End If

        Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            Dim _nStr() As String

            If Request("__EVENTARGUMENT").Contains("|") Then
                _nStr = Request("__EVENTARGUMENT").Split("|")
                _mAcctNo = _nStr(0).ToString
                _mEmailAddr = _nStr(1).ToString
                _mAppDate = _nStr(2).ToString
                _mPermitNo = _nStr(3).ToString
                _mCommName = _nStr(4).ToString
                _mCBP_transaction_no = _nStr(5).ToString
            Else
                _mAcctNo = Request("__EVENTARGUMENT")
            End If

            If action = "Notify" Then
                do_notify()
            End If
        End If
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

    Public Sub _BindGridview(_nGridview As GridView)
        Try
            _nGridview.DataSource = Nothing

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nSvrBPLTAS As String
            Dim _nDBBPLTAS As String

            _nSvrBPLTAS = _nClBP._pDBDataSource
            _nDBBPLTAS = _nClBP._pDBInitialCatalog

            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS_F"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nSvrBPLTAS_F As String
            Dim _nDBBPLTAS_F As String

            _nSvrBPLTAS_F = _nClBP._pDBDataSource
            _nDBBPLTAS_F = _nClBP._pDBInitialCatalog

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                '._pSelect = "SELECT BP.ACCTNO,BM.cbp_transaction_no,BM.COMMNAME,BM.APP_DATE,BP.PERMITNO,BP.DATERELEASED, BM.EMAILADDR, xBase64 ARXFile " & _
                '            "FROM [" & _nSvrBPLTAS & "].[" & _nDBBPLTAS & "].dbo.[BusinessPermit]  BP " & _
                '            "INNER Join " & _
                '            "BUSMAST BM " & _
                '            "ON BP.ACCTNO = BM.ACCTNO  " & _
                '            "AND BP.FORYEAR = Year(getdate()) " & _
                '            "AND BP.Released = 1 " & _
                '            "INNER Join " & _
                '            "[" & _nSvrBPLTAS_F & "].[" & _nDBBPLTAS_F & "].dbo.[BPfile] BF " & _
                '            "cross apply (select BF.ARXfile ''*'' for xml path('''')) T (xBase64) " & _
                '            "ON BF.ACCTNO = BM.ACCTNO  " & _
                '            "AND BF.FORYEAR = Year(getdate()) " & _
                '            "WHERE ISNULL(BM.IsECertPosted,0) = 0" & _
                '            "ORDER BY BF.xFileNo Desc "
                ._pSelect = " Select BM.ACCTNO, BM.cbp_transaction_no,BM.COMMNAME,BM.EMAILADDR,BM.APP_DATE,BP.PERMITNO,BP.ISSUANCEDATE,BP.EXPIRATIONDATE,(FORMAT(BP.DATEPAID,''yyMMdd'') + ''-''+ BP.ORNO) AS PaymentRefNo " & _
                            " from BUSMAST   BM " & _
                            " INNER JOIN " & _
                            " [" & _nSvrBPLTAS & "].[" & _nDBBPLTAS & "].dbo.[BUSINESSPERMIT] BP " & _
                            " ON BM.ACCTNO = BP.ACCTNO  " & _
                            " WHERE ISNULL(BM.IsECertPosted,0)= 0 "
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then
                    snackbar("red", " Error occured,  " & _nErrMsg)
                End If

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    _nGridview.DataSource = _nDataTable
                    _nGridview.DataBind()
                    _oButtonPost.Enabled = True
                Else
                    cGridview.pEmptyGridView(_nDataTable, _nGridview, "-- NO RECORD AVAILABLE --")
                    _oButtonPost.Enabled = False
                End If

            End With

        Catch ex As Exception
            snackbar("red", " Error occured,  " & ex.Message)
        End Try
    End Sub

    Public Sub _BindGridviewRevoked(_nGridview As GridView)
        Try
            _nGridview.DataSource = Nothing

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nSvrBPLTIMS As String
            Dim _nDBBPLTIMS As String

            _nSvrBPLTIMS = _nClBP._pDBDataSource
            _nDBBPLTIMS = _nClBP._pDBInitialCatalog

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTAS
                ._pAction = "SELECT"
                ._pSelect = "SELECT Acctno " & _
                            " ,(Select cbp_transaction_no from [" & _nSvrBPLTIMS & "].[" & _nDBBPLTIMS & "].dbo.BUSMAST where ACCTNO = BP.ACCTNO) cbp_transaction_no " & _
                            " ,(Select COMMNAME from BUSMAST where ACCTNO = BP.ACCTNO) as COMMNAME " & _
                            " ,(Select Emailaddr from BUSMAST where ACCTNO = BP.ACCTNO) as EMAILADDR " & _
                            " ,(Select App_Date from BUSMAST where ACCTNO = BP.ACCTNO) as APP_DATE " & _
                            " , PermitNo " & _
                            " ,DateCancelled as DateRevoked " & _
                            " ,UserCancelled as RevokedBy " & _
                            " from BusinessPermit BP "
                ._pCondition = " WHERE " & _
                            " ACCTNO IN (Select ACCTNO from [" & _nSvrBPLTIMS & "].[" & _nDBBPLTIMS & "].dbo.BUSMAST Where ISNULL(cbp_transaction_no,'''')<>''''  AND ISNULL(IsNotifiedRevoke,0) <> 1) " & _
                " AND ISNULL(IsCancel,0) <> 0 "

                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = False Then
                    snackbar("red", " Error occured,  " & _nErrMsg)
                End If

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    _nGridview.DataSource = _nDataTable
                    _nGridview.DataBind()
                    '_oButtonPost.Enabled = True
                Else
                    cGridview.pEmptyGridView(_nDataTable, _nGridview, "-- NO RECORD AVAILABLE --")
                    '_oButtonPost.Enabled = False
                End If

            End With

        Catch ex As Exception
            snackbar("red", " Error occured,  " & ex.Message)
        End Try
    End Sub

    <WebMethod> _
    Public Shared Function CalculateSum(Num1 As Int32, Num2 As Int32) As String
        Dim Result As Int32 = Num1 + Num2
        Return Result.ToString()
    End Function


    Protected Sub _oButton_Click(sender As Object, e As EventArgs) Handles _
            _oButtonPost.Click
        Try
            ' === SAVE IMAGE REQUIREMENTS ===============================================================================================
            _PosUploadedCert(sender, e)
            '============================================================================================================================

        Catch ex As Exception
            'snackbar("red", "Error Occured: " & ex.Message)
        End Try

    End Sub

    Protected Sub _PosUploadedCert(ByVal sender As Object, e As EventArgs)

        Try


            'Dim index As Integer = Integer.Parse((CType(sender, Button)).CommandArgument)
            'Dim file As FileUpload = CType(_oGridViewRequirementsList.Rows(index).FindControl("_oFileUploadRequirements"), FileUpload)

            Dim FileCtr As Integer = 0
            For Each row As GridViewRow In GridView4.Rows
                Dim file As FileUpload = CType(row.FindControl("_oFileUpload"), FileUpload)
                Dim Acctno As Label = CType(row.FindControl("oLabelACCTNO"), Label)
                Dim cbp_transaction_no As Label = CType(row.FindControl("oLabelcbp_transaction_no"), Label)
                Dim application_date As Label = CType(row.FindControl("oLabelAPP_DATE"), Label)
                Dim email_address As Label = CType(row.FindControl("oLabelEMAILADDR"), Label)
                Dim permit_no As Label = CType(row.FindControl("oLabelPERMITNO"), Label)
                Dim expiry_date As Label = CType(row.FindControl("oLabelEXPIRATIONDATE"), Label)
                Dim issuance_date As Label = CType(row.FindControl("oLabelDATERELEASED"), Label)
                Dim payment_refno As Label = CType(row.FindControl("oLabelPaymentRefNo"), Label)

                Dim _nFileLoc As String = Convert.ToString(file.PostedFile)

                If file.HasFile Then
                    FileCtr = FileCtr + 1
                    Dim postedFile = file
                    Dim _nFileDirectory = Path.Combine(HttpContext.Current.Server.MapPath("~/Temp/"), cbp_transaction_no.Text)
                    Dim _nFilePath As String = _nFileDirectory & "\" & postedFile.FileName
                    If Directory.Exists(_nFileDirectory) Then
                        FileIO.FileSystem.DeleteDirectory(HttpContext.Current.Server.MapPath("~/Temp/" & cbp_transaction_no.Text), FileIO.DeleteDirectoryOption.DeleteAllContents) ' Delete Temporary Folder
                    End If

                    Directory.CreateDirectory(_nFileDirectory)
                    'Dim _nPostedFile As HttpPostedFile = file.PostedFile
                    'Dim _nFileSize As Integer = _nPostedFile.ContentLength
                    'Dim _nMaxFileSize As Integer = 10485760 ' < Maximum File Size is 10 MB
                    'Dim br As New BinaryReader(_nPostedFile.InputStream)
                    'Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(_nPostedFile.InputStream.Length))
                    'Dim fs As System.IO.Stream = file.PostedFile.InputStream
                    postedFile.SaveAs(_nFilePath)

                    If cInit_CBPReg._PostECert(cbp_transaction_no.Text, _nFilePath) = True Then
                        Dim _nAppDate As Date = application_date.Text
                        cSessionLoader._pAccountNo = Acctno.Text
                        cLoader_CBPBusinessInfo._pcbp_transaction_no = cbp_transaction_no.Text
                        cLoader_CBPAuthRep._pcbp_transaction_no = cbp_transaction_no.Text
                        cLoader_BPLTIMS._pEMAILADDR = email_address.Text
                        cLoader_BPLTIMS._pCOMMNAME = ""
                        Dim _PaymentMode As String = cInit_CBPReg._Fn_PaymentMode
                        cInit_CBPReg.UpdateCBPAppStatus("ISSUED-BUSINESS-PERMIT", "New", _nAppDate, _PaymentMode, issuance_date.Text, permit_no.Text, expiry_date.Text, payment_refno.Text)
                        cInit_CBPReg._InsertAppStatLog("ISSUED-BUSINESS-PERMIT")
                        cInit_CBPReg._TagAsECertPosted() ' Tag As ECert Posted
                        snackbar("green", "E Certificate Sucessfully Posted for CBP transaction No. " & cbp_transaction_no.Text)
                    Else
                        ' cEventLog._pSubEventLog("Post Failed!")
                        snackbar("red", "Failure posting E Cetificate for CBP transaction No. " & cbp_transaction_no.Text)
                    End If

                    If Directory.Exists(_nFileDirectory) Then
                        FileIO.FileSystem.DeleteDirectory(HttpContext.Current.Server.MapPath("~/Temp/" & cbp_transaction_no.Text), FileIO.DeleteDirectoryOption.DeleteAllContents) ' Delete Temporary Folder
                    End If
                Else

                End If

            Next
            If FileCtr = 0 Then
                snackbar("red", "No file was to posted")
                Exit Sub
            End If

            _BindGridview(GridView4)
            '  OnRowDataBound(sender)
            'snackbar("green", "Files Successfully uploaded!")

        Catch ex As Exception
            snackbar("red", " Error occured,  " & ex.Message)
        End Try
        'Dim _nBtn As Button = TryCast(sender, Button)
        'Dim _nGridRow As GridViewRow = CType(_nBtn.NamingContainer, GridViewRow)

        'Dim _nFileName = DirectCast(_nGridRow.FindControl("_oFileUploadRequirements"), FileUpload).FileName

    End Sub

    Private Sub do_notify()
        Try

            cSessionLoader._pAccountNo = _mAcctNo
            cLoader_BPLTIMS._pEMAILADDR = _mEmailAddr
            cLoader_BPLTIMS._pAPP_DATE = _mAppDate
            cLoader_CBPAuthRep._pcbp_transaction_no = _mCBP_transaction_no
            cLoader_BPLTIMS._pCOMMNAME = _mCommName

            If _SendEmailNotification() = True Then
                _TagAsNotified()


                Dim _nStatCode As String = "BUSINESS-PERMIT-REVOKED"
                '"VERIFIED-BUSINESS-PERMIT"
                cInit_CBPReg.UpdateCBPAppStatus(_nStatCode, "New", cLoader_BPLTIMS._pAPP_DATE)
                cInit_CBPReg._InsertAppStatLog(_nStatCode)
                'UpdateBusMastRemarks(_nRemarks)

                'If _nRemarks = "Reviewed/ For Assessment Billing" Then
                '    UpdateBusMastForPayment()
                'End If
                'SNACK BAR GREEN 
                'MESSAGE "Taxtpayer Sucessfully notified."
                _BindGridviewRevoked(_oGridViewRevoked)
                _BindGridview(GridView4)
                snackbar("green", "Notification sent for account no. " & cSessionLoader._pAccountNo & ".")

                'Response.Write("<script language='javascript'>window.alert('Taxpayer successfully Notified');</script>")
                'Response.Redirect("NotificationPages/BPLONotification.aspx")
                Exit Sub
            Else
                snackbar("green", "Nofification failed to send for account  no. " & cSessionLoader._pAccountNo & ",please try again.")
                'Response.Write("<script language='javascript'>window.alert('Send notification failed, please try again.');</script>")
                'SNACK BAR RED 
                'MESSAGE "Failed sending notification, please check your internet connection and try again."

                Exit Sub
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub _TagAsNotified()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BUSMAST SET IsNotifiedRevoke = 1 "
                ._pCondition = "Where Acctno = ''" & cSessionLoader._pAccountNo & "''"
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Function _SendEmailNotification() As Boolean

        'Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        'Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        'Dim PageName As String = System.IO.Path.GetFileName(PagePath)
        'Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")

        Dim Sent As Boolean
        Dim Subject As String = "BUSINESS PERMIT REVOCATION"
        Dim Body As String


        Body = _
            " <br> Sir/Ma`am: <br> <br>" & _
            " This is to notify that " & _mCommName & " with Business Permit No. " & _mPermitNo & " has been revoked and is no longer permitted to operate its business transaction. <br>" & _
            " For inquiries regarding the revocation of your business permit, you may contact us through the following. <br> <br>" & _
            " Telephone No.:  " & cSessionLGUProfile._pLGU_TelNo & " <br> " & _
            " Email address: " & cSessionLGUProfile._pLGU_EmailAddress & " <br> " & _
            " <br> " & _
            " You may also visit the BPLO office at " & cSessionLGUProfile._pLGU_Address & " . <br> <br> " & _
            " Thank you!  <br> "
        Try
            cDalNewSendEmail.SendEmail(cLoader_BPLTIMS._pEMAILADDR, Subject, Body, Sent)
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function


    'Protected Sub _oButtonPost_Click(sender As Object, e As EventArgs) Handles _o.Click
    '    Try

    '    Catch ex As Exception

    '    End Try

    'End Sub

End Class