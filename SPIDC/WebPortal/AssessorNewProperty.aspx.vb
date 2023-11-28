Imports System.Data.SqlClient
Public Class AssessorNewProperty
    Inherits System.Web.UI.Page
    Public Shared chie As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")
            If Not IsPostBack Then



            Else
                If action = "ViewDetails" Then
                    View_Details()
                End If
                If action = "DownloadFiles" Then
                    Download_Selected(hdnpropid.Value, hdnuserid.Value)
                    'Response.Write("<script>window.open('Sample.aspx','_blank');</script>")                    
                    'chie = True
                End If
                If action = "EmailNotification" Then
                    If _SendEmailNotification(_oTxtRemarks.Value, _oTxtSEmail.Value) = True Then
                        UpdateBusMastRemarks(_oTxtRemarks.Value)
                        If _oTxtRemarks.Value = "Notify Taxpayer" Then
                            UpdateBusMastForPayment()
                        End If
                        'SNACK BAR GREEN 
                        'MESSAGE "Taxtpayer Sucessfully notified."
                        Response.Redirect("NotificationPages/ASSESSORNotification.aspx")
                        Exit Sub
                    End If

                End If




            End If
            Get_Property()
        Catch ex As Exception


        End Try

    End Sub
    Private Sub Get_Property()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = _oGVProperty
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalNewProperty
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubSelect("[RPTASMastNew]", " order by propid asc ") 'where ISNULL(IsForPayment, '') = ''

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()
                Else
                    ' snackbar("red", "No Records Found.")
                End If
                '----------------------------------
            Catch ex As Exception
                'snackbar("red", ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try
    End Sub
    Private Sub View_Details()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = _oGVProperty
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalNewProperty
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pUserID = hdnuserid.Value
            _nClass._pPropID = hdnpropid.Value
            _nClass._pSubSelect("[RPTASMastNew]", "")

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable
            _oTxtOwner.Value = _nDataTable.Rows(0)("OwnerName").ToString()
            _oTxtOwnerAddress.Value = _nDataTable.Rows(0)("OwnerAddress").ToString()
            _oTxtAdministrator.Value = _nDataTable.Rows(0)("Administrator").ToString()
            _oTxtAdminAddress.Value = _nDataTable.Rows(0)("AdministratorAddress").ToString()
            _oTxtNoSt.Value = _nDataTable.Rows(0)("Locproperty").ToString()
            _oTxtBarangay.Value = _nDataTable.Rows(0)("Brgy").ToString()
            _oTxtDistrict.Value = _nDataTable.Rows(0)("District").ToString()
            _oTxtOCT_TCT.Value = _nDataTable.Rows(0)("OCT").ToString()
            _oTxtSurveyNo.Value = _nDataTable.Rows(0)("SurveyNo").ToString()
            _TxtLotNo.Value = _nDataTable.Rows(0)("LotNo").ToString()
            _oTxtBlockNo.Value = _nDataTable.Rows(0)("BlkNo").ToString()
            _oTxtArea.Value = _nDataTable.Rows(0)("Area").ToString()
            _oTxtAmountSold.Value = _nDataTable.Rows(0)("AmountSold").ToString()
            _oTxtResidentialArea.Value = _nDataTable.Rows(0)("Residential").ToString()
            _oTxtCommercialArea.Value = _nDataTable.Rows(0)("Commercial").ToString()
            _oTxtDeedofsale.Value = _nDataTable.Rows(0)("DeedSaleName").ToString()
            _oTxtCopyofTitle.Value = _nDataTable.Rows(0)("CopyTitleName").ToString()
            _oTxtProofofPayment.Value = _nDataTable.Rows(0)("ProofPaymentName").ToString()
            _oTxtTaxClearance.Value = _nDataTable.Rows(0)("TaxClearanceName").ToString()
            _oTxtDeclarationCopy.Value = _nDataTable.Rows(0)("DeclarationCopyName").ToString()
            _oTxtCorporateProperty.Value = _nDataTable.Rows(0)("CorpPropName").ToString()
            _oTxtValidID.Value = _nDataTable.Rows(0)("ValididName").ToString()
            _oTxtIndustrial.Value = _nDataTable.Rows(0)("Industrial").ToString()
            _oTxtAgricultural.Value = _nDataTable.Rows(0)("Agricultural").ToString()
            _oTxtMineral.Value = _nDataTable.Rows(0)("Mineral").ToString()
            _oTxtSpecial.Value = _nDataTable.Rows(0)("Special").ToString()
            _oTxtTimberland.Value = _nDataTable.Rows(0)("Timberland").ToString()
            _oTxtSEmailAddress.Value = hdnuserid.Value
            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()
                Else
                    ' snackbar("red", "No Records Found.")
                End If
                '----------------------------------
                _nClass._pUserID = Nothing
                _nClass._pPropID = Nothing
            Catch ex As Exception
                'snackbar("red", ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
            ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "showpop();", True)
        Catch ex As Exception



        End Try
    End Sub
    'Sub Download_Selected(SeqID)
    '    Try
    '        Dim _nClass As New cDalNewProperty
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
    '        Dim _nQuery As String = Nothing
    '        Dim _nWhere As String = Nothing
    '        Dim _mSqlCommand = _nClass._pSqlCommand
    '        Dim _mDataTable As DataTable
    '        Dim filetype As String
    '        Dim bytes As Byte()
    '        Dim _nFileExtn As String
    '        '----------------------------------    

    '        Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")

    '        _nQuery = "select * from PDS_Attachment where SeqID='" & SeqID & "' and IDNO ='" & hndeduc.Value & "'"

    '        '---------------------------------- 
    '        _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_RPTIMS)
    '        Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_RPTIMS) '_gDBCon
    '        _mDataTable = New DataTable
    '        _nSqlDataAdapter.Fill(_mDataTable)
    '        '----------------------------------

    '        Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
    '            _nSqlDr.Read()
    '            If _nSqlDr.HasRows Then
    '                bytes = DirectCast(_nSqlDr.Item(4), Byte())
    '                _nFileExtn = UCase(_nSqlDr.Item(6))
    '                If _nFileExtn = "TEXT/PLAIN" Then
    '                    _nFileExtn = ".TXT"
    '                End If
    '                If _nFileExtn = "APPLICATION/PDF" Then
    '                    _nFileExtn = ".PDF"
    '                End If
    '                If _nFileExtn = "IMAGE/PNG" Then
    '                    _nFileExtn = ".PNG"
    '                End If
    '                If _nFileExtn = "IMAGE/JPEG" Then
    '                    _nFileExtn = ".JPG"
    '                End If

    '            End If

    '            If _nFileExtn = ".PDF" Then
    '                ''Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")


    '                Response.Clear()
    '                Response.ContentType = "application/pdf"
    '                Response.AddHeader("name", "value")
    '                Response.BinaryWrite(bytes)
    '                Response.Flush()
    '                Response.End()
    '                'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('ApplicationRequest.aspx','_blank');</script>", True)
    '            End If
    '            If _nFileExtn = ".TXT" Then

    '                Response.Clear()
    '                Response.ContentType = "text/plain"
    '                Response.AddHeader("name", "value")
    '                Response.BinaryWrite(bytes)
    '                Response.Flush()
    '                Response.End()
    '                'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
    '            End If
    '            If _nFileExtn = ".PNG" Then

    '                Response.Clear()
    '                Response.ContentType = "image/png"
    '                Response.AddHeader("name", "value")
    '                Response.BinaryWrite(bytes)

    '                Response.Flush()
    '                Response.End()
    '            End If

    '            If _nFileExtn = ".JPG" Then

    '                Response.Clear()
    '                Response.ContentType = "image/jpeg"
    '                Response.AddHeader("name", "value")
    '                Response.BinaryWrite(bytes)

    '                Response.Flush()
    '                Response.End()
    '            End If
    '        End Using




    '        '_oLabel_FileName.Text = _nCls._pFileName & _nFileExtn.ToLower


    '    Catch ex As Exception

    '    End Try
    '    _idnostatus = hndeduc.Value
    '    _mxseqid = SeqID



    '    'Dim FileData As Byte()
    '    'Dim FileName As String
    '    'Dim FileType As String

    '    'cDalAppointment._mSqlCon = cGlobalConnections._pSqlCxn_HRIMS
    '    '_pSubSelectSpecificAttachment(hdnmodulename.Value, hdnfilename.Value, hdnseqid.Value, FileData, FileName, FileType)
    '    'Response.Clear()
    '    'Response.Buffer = True
    '    'Response.Charset = ""
    '    'Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '    'Response.ContentType = FileType
    '    'Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName)
    '    'Response.BinaryWrite(FileData)
    '    'Response.Flush()
    '    'Response.End()
    'End Sub

    Sub Download_Selected(propid, userid)
        Try
            Dim _nclass As New cDalNewProperty
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            Dim _nQuery As String = Nothing
            Dim _nWhere As String = Nothing
            Dim _mSqlCommand As SqlCommand
            Dim _mDataTable As DataTable
            Dim filetype As String
            Dim bytes As Byte()
            Dim _nFileExtn As String
            Dim _mFilename As String

            '----------------------------------    
            'If chie = True Then
            '    Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")

            'Else

            _nQuery = "select * from RPTASMastNew where propid='" & propid & "' and userid ='" & userid & "'"

            '---------------------------------- 
            _mSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nQuery, cGlobalConnections._pSqlCxn_RPTIMS) '_gDBCon
            _mDataTable = New DataTable
            _nSqlDataAdapter.Fill(_mDataTable)
            '----------------------------------
            Using _nSqlDr As SqlDataReader = _mSqlCommand.ExecuteReader
                _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    bytes = DirectCast(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnData.Value)), Byte())
                    _nFileExtn = UCase(_nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnType.Value)))
                    _mFilename = _nSqlDr.GetValue(_nSqlDr.GetOrdinal(hdnName.Value))
                    If _nFileExtn = "TEXT/PLAIN" Then
                        _nFileExtn = ".TXT"
                    End If
                    If _nFileExtn = "APPLICATION/PDF" Then
                        _nFileExtn = ".PDF"
                    End If
                    If _nFileExtn = "IMAGE/PNG" Then
                        _nFileExtn = ".PNG"
                    End If
                    If _nFileExtn = "IMAGE/JPEG" Then
                        _nFileExtn = ".JPG"
                    End If

                End If
                If _nFileExtn = ".PDF" Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()

                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('AssessorNewProperty.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".TXT" Then
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                    'Response.Write("<script>window.open('ApplicationRequest.aspx','_blank');</script>")
                End If
                If _nFileExtn = ".PNG" Then
                    Response.Clear()
                    Response.ContentType = "image/png"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If

                If _nFileExtn = ".JPG" Then
                    Response.Clear()
                    Response.ContentType = "image/jpeg"
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" & _mFilename)
                    Response.BinaryWrite(bytes)
                    Response.Flush()
                    Response.End()
                    'ClientScript.RegisterStartupScript(Me.[GetType](), "", "<script>window.open('AssessorNewProperty.aspx','_blank');</script>", True)
                End If
            End Using






            '_oLabel_FileName.Text = _nCls._pFileName & _nFileExtn.ToLower


        Catch ex As Exception

        End Try
        '_idnostatus = hndeduc.Value
        '_mxseqid = SeqID



        'Dim FileData As Byte()
        'Dim FileName As String
        'Dim FileType As String

        'cDalAppointment._mSqlCon = cGlobalConnections._pSqlCxn_HRIMS
        '_pSubSelectSpecificAttachment(hdnmodulename.Value, hdnfilename.Value, hdnseqid.Value, FileData, FileName, FileType)
        'Response.Clear()
        'Response.Buffer = True
        'Response.Charset = ""
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.ContentType = FileType
        'Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName)
        'Response.BinaryWrite(FileData)
        'Response.Flush()
        'Response.End()
    End Sub
    Private Function _SendEmailNotification(_nResponse As String, _nComment As String) As Boolean
        Try

       
        Dim Sent As Boolean
        Dim Subject As String = "REAL PROPERTY APPLICATION STATUS"
        Dim Body As String
        Select Case _nResponse
            Case "Notifity Taxpayer"
                Body = _
                        "<br> Sir/Ma`am: <br> <br>" & _
                        "Your Real Property for Property ID " & hdnpropid.Value & " is now approved. " & _
                        "Please go to WEB PORTAL to file schedule of appointment. <br>" & _
                        "Please bring all requirements you have submitted online. <br> <br>" & _
                         IIf(_nComment <> "", "<br> <br> ASSESSOR COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                        "Thank you. <br>"

            Case "Lacks Mandatory Requirements"
                Body = _
                        "<br> Sir/Ma`am: <br> <br>" & _
                        "Your Real Property for Property ID " & hdnpropid.Value & " is now pending until you submit all mandatory requirements. " & _
                         IIf(_nComment <> "", "<br> <br> ASSESSOR COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                        "Thank you. <br>"
        End Select
           
            cDalNewSendEmail.SendEmail(hdnuserid.Value, Subject, Body, Sent)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub UpdateBusMastRemarks(_nRemarks As String)
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
                ._pSelect = "UPDATE [RPTASMastNew] Set REMARKS = ''" & _nRemarks & "''"
                ._pCondition = " Where propid = ''" & hdnpropid.Value & "''"
                ._pAction = "UPDATE"
                ._pExec(_nSuccessfull, _nErrMsg)
            End With

        Catch ex As Exception

        End Try


    End Sub
    Private Sub UpdateBusMastForPayment()
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
                ._pSelect = "UPDATE [RPTASMastNew] Set Status = 1 "
                ._pCondition = " Where propid = ''" & hdnpropid.Value & "''"
                ._pAction = "UPDATE"
                ._pExec(_nSuccessfull, _nErrMsg)
            End With

        Catch ex As Exception

        End Try


    End Sub
End Class