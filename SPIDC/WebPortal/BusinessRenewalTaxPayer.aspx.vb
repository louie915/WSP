Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class BusinessRenewalTaxPayer
    Inherits System.Web.UI.Page
    Dim Office As String = "TAXPAYER"
    Dim nTempGross As String
    Dim usertmp As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nQtrPay As String
        Dim _nSelectedQtr As Integer
        Try

      
        If Not Me.IsPostBack Then

            usertmp = cSessionUser._pUserID.Replace(".", "")


            'cSessionLoader._pAccountNo pang call ng naselect na account no.
            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo

            '_nClass1._pSubSelectPrevGross()
            '_oTxtPreviousGross.Value = Format(_nClass1._nPrevGross, "###,###,##0.00")
            '_oTxtBusLine.Value = _nClass1._nBusDesc



            Dim _nClass2 As New cDalBPSOS
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass2._pAcctNo = cSessionLoader._pAccountNo
            _nClass2._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass2._pSubGetDetail()

            _oLblBusID.Text = cSessionLoader._pAccountNo
            _oLblBusOwner.Text = _nClass2._nOwner
            _oLblBusName.Text = _nClass2._nBusName
            _oLblBusAddress.Text = _nClass2._nBusAddress
            _oLblBusCategory.Text = _nClass2._nBusCategory
            _oLblBusCategory1.Text = _nClass2._nBusCategory1

            '_nClass2._pForYear = Year(Now)
            _nClass2._pSubGetCurYear()
            _nClass2._pForYear = _nClass2._nCurYear

            '_nClass2._pSubShowBusDetailExtn()
            _nClass2._pSubShowBusDetail_TAXPAYER()
            _GVBusinessLine.DataSource = _nClass2._mDataTable
            _GVBusinessLine.DataBind()


            TextAskHead()
            TextAsk()
            DropDownAsk()

                GetTypeWOwnCode()


                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal();", True)

        Else

            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "fileupload" Then
                'upload_Docs_New()
                upload_Docs(val)
                'TextAskHeadInit()
                'TextAskInit()
                'DropDownAskInit()
                GETGROSSAMT2()
                'GETGROSSAMT()

                _mSubGetGrValue()

                'Dim _nClass2 As New cDalBPSOS
                '_nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                '_nClass2._pAcctNo = cSessionLoader._pAccountNo
                '_nClass2._pForYear = Year(Now)

                '_nClass2._pTempTbl = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
                '_nClass2._pSubSAVEASKHDG()

                '_nClass2._pTempTbl = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
                '_nClass2._pSubSAVEASKQTY()

                '_nClass2._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
                '_nClass2._pSubSAVEASKOPTION()


                'Response.Write("<script>alert('Gross amount successfully forwarded to BPLO.! \n Note: Entered Gross amount is/are subject for approval. ');</script>")
                'ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal();", True)

                '_obtnSaveEdit.Disabled = True

                Dim _nClass As New cDalBPSOS
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nClass._pAcctNo = cSessionLoader._pAccountNo
                _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")

                ' _nClass._pForYear = Year(Now)
                _nClass._pSubGetCurYear()
                _nClass._pForYear = _nClass._nCurYear
                _nClass._pSubShowBusDetail_TAXPAYER()
                _GVBusinessLine.DataSource = _nClass._mDataTable
                _GVBusinessLine.DataBind()
                Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                sb.Append("<script language='javascript'>")
                sb.Append("document.getElementById('txarea').value = sessionStorage.getItem('txarea');</script>")
                ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

                TextAskHeadInit()
                TextAskInit()
                DropDownAskInit()


            End If
            If action = "Save" Then
                _obtnSaveEdit_ServerClick()
                Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
                sb.Append("<script language='javascript'>")
                sb.Append(cDalBPSOS._nSTQuery)
                sb.Append("document.getElementById('txarea').value = sessionStorage.getItem('txarea');</script>")
                ClientScript.RegisterStartupScript(Me.[GetType](), "NJSScript", sb.ToString())
            End If
            End If
        Catch ex As Exception

        End Try
    End Sub
   

  
    Public Sub GetTypeWOwnCode()

        Dim _nClass As New cDalBPSOS
        Dim myOutPut As String

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
        _nClBP._pSubRecordSelectSpecific()

        '----------------------------------
        'Specify Blank to Select Nothing but Column Names
        _nClass._pAcctNo = cSessionLoader._pAccountNo
        _nClass._pLocServer = _nClBP._pDBDataSource
        _nClass._pLocDB = _nClBP._pDBInitialCatalog
        '----------------------------------

        _nClass._pSubGETOWNCODE()
        myOutPut = UCase(_nClass._nOutput)
        'myOutPut = "CORPORATION" '_nClass._nOutput
        'myOutPut = "PARTNERSHIP" '_nClass._nOutput
        'myOutPut = "SINGLE" '_nClass._nOutput

        _oLblBusOwnership.Text = myOutPut

        Select Case myOutPut
            Case "COOPERATIVE"
                _oLblTypeTitle.InnerHtml = " For Cooperative"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnFile7.Visible = Not _oPnFile7.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile7", "file7")
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + "document.getElementById('_oLblFile11').innerHTML = (sessionStorage.getItem('file11') ? sessionStorage.getItem('file11') : 'No file chosen'); "
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile9", "file9")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile4", "file4")
            Case "CORPORATION"
                _oLblTypeTitle.InnerHtml = " For Corporation"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnFile7.Visible = Not _oPnFile7.Visible

                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + "document.getElementById('_oLblFile4').innerHTML = (sessionStorage.getItem('file4') ? sessionStorage.getItem('file4') : 'No file chosen'); "
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile9", "file9")
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + "document.getElementById('_oLblFile11').innerHTML = (sessionStorage.getItem('file11') ? sessionStorage.getItem('file11') : 'No file chosen'); "
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")

                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile2", "file2")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile7", "file7")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile4", "file4")


            Case "AMUSEMENT"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile2", "file2")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")

            Case "FOREIGN"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                _oPnFile11.Visible = Not _oPnFile11.Visible
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile9", "file9")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile11", "file11")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")

                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile2", "file2")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")

            Case "PARTNERSHIP"
                _oLblTypeTitle.InnerHtml = " For Partnership"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                '_oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnFile8.Visible = Not _oPnFile8.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile9", "file9")
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + "document.getElementById('_oLblFile11').innerHTML = (sessionStorage.getItem('file11') ? sessionStorage.getItem('file11') : 'No file chosen'); "
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")

                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile2", "file2")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile8", "file8")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile4", "file4")

            Case "SINGLE"
                _oLblTypeTitle.InnerHtml = " For Single Proprietorship"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnFile5.Visible = Not _oPnFile5.Visible
                _oPnFile6.Visible = Not _oPnFile6.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile9", "file9")
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + "document.getElementById('_oLblFile11').innerHTML = (sessionStorage.getItem('file11') ? sessionStorage.getItem('file11') : 'No file chosen'); "
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile4", "file4")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile2", "file2")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile5", "file5")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile6", "file6")
            Case "SINGLE PROPRIETORSHIP"
                _oLblTypeTitle.InnerHtml = " For Single Proprietorship"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnFile5.Visible = Not _oPnFile5.Visible
                _oPnFile6.Visible = Not _oPnFile6.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile9", "file9")
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + "document.getElementById('_oLblFile11').innerHTML = (sessionStorage.getItem('file11') ? sessionStorage.getItem('file11') : 'No file chosen'); "
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile4", "file4")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile2", "file2")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile5", "file5")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile6", "file6")
            Case "FOUNDATION"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile2", "file2")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")

            Case "ASSOCIATION"

                _oLblTypeTitle.InnerHtml = " For Association"
                _oPnFile1.Visible = Not _oPnFile1.Visible
                _oPnFile2.Visible = Not _oPnFile2.Visible
                _oPnFile3.Visible = Not _oPnFile3.Visible
                _oPnFile4.Visible = Not _oPnFile4.Visible
                _oPnFile7.Visible = Not _oPnFile7.Visible
                _oPnFile9.Visible = Not _oPnFile9.Visible
                _oPnFile10.Visible = Not _oPnFile10.Visible
                '_oPnFile11.Visible = Not _oPnFile11.Visible
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile1", "file1")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile2", "file2")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile3", "file3")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile10", "file10")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile7", "file7")
                'cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + "document.getElementById('_oLblFile11').innerHTML = (sessionStorage.getItem('file11') ? sessionStorage.getItem('file11') : 'No file chosen'); "
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile9", "file9")
                cDalBPSOS._nSTQuery = cDalBPSOS._nSTQuery + SBforFileUp("_oLblFile4", "file4")

        End Select
    End Sub

    Public Function SBforFileUp(FileObj, SsFile) As String
        Dim UpQuery As String = ""
        UpQuery = " document.getElementById('" & FileObj & "').innerHTML = (sessionStorage.getItem('" & SsFile & "') ? sessionStorage.getItem('" & SsFile & "') : 'No file chosen'); "
        Return UpQuery
    End Function


    Private Sub GETGROSSAMT2()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pAcctNo = cSessionLoader._pAccountNo


            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pArea = _nClass1._nArea
            ' _nClass._pForYear = Year(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")

            nTempGross = Request.Form("txarea")

            _nClass._pGrossDetail = nTempGross
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubGetGross()

            _nClass._pSubSAVETPGROSS()

            '------------ Added by archie 20200915
            'upload_Docs()


        Catch ex As Exception

        End Try


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

    Private Sub _obtnPrintApplication_ServerClick(sender As Object, e As EventArgs) Handles _obtnPrintApplication.ServerClick
        Try
            '' Display report in New Tab
            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=APPFORM" + "&ACCTNO=" + cSessionLoader._pAccountNo + "&STATCODE=R&TYPE=TAXPAYER','_blank');</script>")
            '' Display report in Current Tab
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _obtnSaveEdit_ServerClick()

        ' If _oTxtFile3.PostedFile.FileName = Nothing Then snackbar("red", "Please complete the required fields!") : Exit Sub

        GETGROSSAMT()
        _mSubGetGrValue()

        Dim _nClass2 As New cDalBPSOS
        _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass2._pAcctNo = cSessionLoader._pAccountNo
        '_nClass2._pForYear = Year(Now)
        _nClass2._pSubGetCurYear()
        _nClass2._pForYear = _nClass2._nCurYear

        _nClass2._pTempTbl = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
        _nClass2._pSubSAVEASKHDG()

        _nClass2._pTempTbl = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
        _nClass2._pSubSAVEASKQTY()

        _nClass2._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
        _nClass2._pSubSAVEASKOPTION()


        'Response.Write("<script>alert('Gross amount successfully forwarded to BPLO.! \n Note: Entered Gross amount is/are subject for approval. ');</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "Pop", "openModal();", True)

        '_obtnSaveEdit.Disabled = True

        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pAcctNo = cSessionLoader._pAccountNo
        _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")

        ' _nClass._pForYear = Year(Now)
        _nClass._pSubGetCurYear()
        _nClass._pForYear = _nClass._nCurYear
        _nClass._pSubShowBusDetail_TAXPAYER()
        _GVBusinessLine.DataSource = _nClass._mDataTable
        _GVBusinessLine.DataBind()

        cDalBPSOS.ClearAttachedFile()

        _nClass._pSubUpdateRenewalMOP(cSessionLoader._pAccountNo, cmb_MOP.Value)
        'upload_Docs_New()


        Dim _nClassX As New cDalNewBP
        _nClassX._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClassX._pSubUpdateTOPONLINE(cSessionLoader._pAccountNo)
        _nClassX._pSubUpdateISASSESS(cSessionLoader._pAccountNo)
        '---------------
        Dim Emails As String
        Dim sent As Boolean
        Dim Body As String
        Dim subject As String
        cDalNewSendEmail.get_Emails("BPLO", Emails)
        Dim _nClassZ As New cDalBPSOS
        _nClassZ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClassZ._pSubGETAPPRV_TOP_ONLINE()
        If _nClassZ._nOutput = 2 Then
            _nClassX._pSubUpdateISASSESS(cSessionLoader._pAccountNo)
            Body = "Taxpayer is Requesting for Updated Statement of Account with the following details: " & _
                   "<br> Email Address : " & cSessionUser._pUserID & _
                   "<br> BIN : " & cSessionLoader._pAccountNo & _
                   "<br> Mode of Payment : " & cmb_MOP.Value & _
                   "<br> Please login to your Web Account to Assess the Application. Thank you <br><br>"
        Else
            Body = "Taxpayer has applied for Business Renewal with the following details:  " & _
                 "<br> Email Address : " & cSessionUser._pUserID & _
                 "<br> BIN : " & cSessionLoader._pAccountNo & _
                 "<br> Please login to your Web Account to Assess the Application. Thank you <br><br>"
        End If
        cDalNewSendEmail.SendEmail(Emails, subject & " : " & cSessionLoader._pAccountNo, Body, sent)
        '-----------------------
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
        sb.Append("<script language='javascript'>document.getElementById('_obtnSaveEdit').disabled = 'false';")
        sb.Append("</script>")
        ClientScript.RegisterStartupScript(Me.[GetType](), "JSScript", sb.ToString())

        snackbar("green", "Record Saved!")

    End Sub

    Private Sub GETGROSSAMT()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectPrevGross()
            _nClass._pAcctNo = cSessionLoader._pAccountNo


            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()


            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pArea = _nClass1._nArea
            ' _nClass._pForYear = Year(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")

            nTempGross = Request.Form("txarea")

            If Trim(nTempGross) = "" Then
                snackbar("red", "Please input Gross Amount!")
                Exit Sub
            End If

            'Get Gross Amount

            _nClass._pGrossDetail = nTempGross
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubGetGross()

            _nClass._pSubSAVETPGROSS()

            '------------ Added by archie 20200915
            'upload_Docs()
            '_SaveInformation()
            upload_Docs_New()


        Catch ex As Exception

        End Try


    End Sub



    Sub upload_Docs_New()
        Dim _nclass As New cDalBPSOS
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        Dim Exists As Boolean
        Dim Email As String = cSessionUser._pUserID
        Dim RefNo As String = "0" 'Appointment ID
        Dim ModuleID As String = "BPTaxpayerUploadedFiles" ' Appointment Desc


        If _oTxtFile1.PostedFile IsNot Nothing And _oTxtFile1.Visible = True Then
            Dim AcctID As String = "Certified True Copy of Quarterly VAT for calendar year 2020" 'cSessionLoader._pTDN
            Dim SeqID As String = "001" 'image ID
            Dim ReqDesc As String = "Requirement 1"
            Dim FileData As HttpPostedFile = _oTxtFile1.PostedFile
            Dim FileName As String = _oTxtFile1.PostedFile.FileName
            Dim FileType As String = _oTxtFile1.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If

        If _oTxtFile2.PostedFile IsNot Nothing And _oTxtFile2.Visible = True Then
            Dim AcctID As String = "Certified True Copy of Monthly VAT for calendar year 2020"
            Dim SeqID As String = "002" 'image ID
            Dim ReqDesc As String = "Requirement 2"
            Dim FileData As HttpPostedFile = _oTxtFile2.PostedFile
            Dim FileName As String = _oTxtFile2.PostedFile.FileName
            Dim FileType As String = _oTxtFile2.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If

        If _oTxtFile3.PostedFile IsNot Nothing And _oTxtFile3.Visible = True Then
            Dim AcctID As String = "Barangay Tax Order of Payment"
            Dim SeqID As String = "003" 'image ID
            Dim ReqDesc As String = "Requirement 3"
            Dim FileData As HttpPostedFile = _oTxtFile3.PostedFile
            Dim FileName As String = _oTxtFile3.PostedFile.FileName
            Dim FileType As String = _oTxtFile3.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If
        If _oTxtFile4.PostedFile IsNot Nothing And _oTxtFile4.Visible = True Then
            Dim AcctID As String = "Breakdown of sales per city/municipality and attach business/permit application for those cities"
            Dim SeqID As String = "004" 'image ID
            Dim ReqDesc As String = "Requirement 4"
            Dim FileData As HttpPostedFile = _oTxtFile4.PostedFile
            Dim FileName As String = _oTxtFile4.PostedFile.FileName
            Dim FileType As String = _oTxtFile4.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If
        If _oTxtFile5.PostedFile IsNot Nothing And _oTxtFile5.Visible = True Then
            Dim AcctID As String = "Notarized Written Authorization Letter"
            Dim SeqID As String = "005" 'image ID
            Dim ReqDesc As String = "Requirement 5"
            Dim FileData As HttpPostedFile = _oTxtFile5.PostedFile
            Dim FileName As String = _oTxtFile5.PostedFile.FileName
            Dim FileType As String = _oTxtFile5.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If
        If _oTxtFile6.PostedFile IsNot Nothing And _oTxtFile6.Visible = True Then
            Dim AcctID As String = "ID of Registered Owner and Company ID of representative"
            Dim SeqID As String = "006" 'image ID
            Dim ReqDesc As String = "Requirement 6"
            Dim FileData As HttpPostedFile = _oTxtFile6.PostedFile
            Dim FileName As String = _oTxtFile6.PostedFile.FileName
            Dim FileType As String = _oTxtFile6.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If
        If _oTxtFile7.PostedFile IsNot Nothing And _oTxtFile7.Visible = True Then
            Dim AcctID As String = "Secretary Certificate"
            Dim SeqID As String = "007" 'image ID
            Dim ReqDesc As String = "Requirement 7"
            Dim FileData As HttpPostedFile = _oTxtFile7.PostedFile
            Dim FileName As String = _oTxtFile7.PostedFile.FileName
            Dim FileType As String = _oTxtFile7.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If
        If _oTxtFile8.PostedFile IsNot Nothing And _oTxtFile8.Visible = True Then
            Dim AcctID As String = "Notarized Written Authorization from one of the partners"
            Dim SeqID As String = "008" 'image ID
            Dim ReqDesc As String = "Requirement 8"
            Dim FileData As HttpPostedFile = _oTxtFile8.PostedFile
            Dim FileName As String = _oTxtFile8.PostedFile.FileName
            Dim FileType As String = _oTxtFile8.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If
        If _oTxtFile9.PostedFile IsNot Nothing And _oTxtFile9.Visible = True Then
            Dim AcctID As String = "Duly accomplished business application form, indicating gross sales/receipt"
            Dim SeqID As String = "009" 'image ID
            Dim ReqDesc As String = "Requirement 9"
            Dim FileData As HttpPostedFile = _oTxtFile9.PostedFile
            Dim FileName As String = _oTxtFile9.PostedFile.FileName
            Dim FileType As String = _oTxtFile9.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If
        If _oTxtFile10.PostedFile IsNot Nothing And _oTxtFile10.Visible = True Then
            Dim AcctID As String = "Public Liability Insurance"
            Dim SeqID As String = "010" 'image ID
            Dim ReqDesc As String = "Requirement 10"
            Dim FileData As HttpPostedFile = _oTxtFile10.PostedFile
            Dim FileName As String = _oTxtFile10.PostedFile.FileName
            Dim FileType As String = _oTxtFile10.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If
        If _oTxtFile11.PostedFile IsNot Nothing And _oTxtFile11.Visible = True Then
            Dim AcctID As String = "Barangay Clearance"
            Dim SeqID As String = "011" 'image ID
            Dim ReqDesc As String = "Requirement 11"
            Dim FileData As HttpPostedFile = _oTxtFile11.PostedFile
            Dim FileName As String = _oTxtFile11.PostedFile.FileName
            Dim FileType As String = _oTxtFile11.PostedFile.ContentType
            Dim fs As Stream = FileData.InputStream
            Dim br As New BinaryReader(fs)
            Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))

            'check if file already exists
            _nclass._pSubSelectImage(cSessionLoader._pAccountNo, Year(Now), ModuleID, AcctID, SeqID, Exists)
            If Exists = True Then
                'update uploaded file
                _nclass._pSubUpdateAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType)
            Else
                'upload new file
                _nclass._pSubInsertAttachFiles(cSessionLoader._pAccountNo, Year(Now), RefNo, ModuleID, AcctID, SeqID, bytes, FileName, FileType, ReqDesc, Office)
            End If
            'cDalAppointment._pFile001 = FileName
            'lblup1.InnerText = FileName
        End If


    End Sub

    Sub upload_Docs(fileno)


        If fileno = "file1" Then
            Dim FileData As HttpPostedFile = _oTxtFile1.PostedFile
            Dim FileName As String = _oTxtFile1.PostedFile.FileName
            Dim FileType As String = _oTxtFile1.PostedFile.ContentType
            If FileType = "image/png" Or FileType = "application/pdf" Or FileType = "image/jpeg" Or FileType = "image/jpg" Then
                Dim fs As Stream = FileData.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                cDalBPSOS._pFile1Name = FileName
                cDalBPSOS._pFile1Type = FileType
                cDalBPSOS._pFile1Data = bytes
            Else
                filecheck(fileno)
            End If
        End If
        If fileno = "file2" Then
            Dim FileData As HttpPostedFile = _oTxtFile2.PostedFile
            Dim FileName As String = _oTxtFile2.PostedFile.FileName
            Dim FileType As String = _oTxtFile2.PostedFile.ContentType
            If FileType = "image/png" Or FileType = "application/pdf" Or FileType = "image/jpeg" Or FileType = "image/jpg" Then
                Dim fs As Stream = FileData.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                cDalBPSOS._pFile2Name = FileName
                cDalBPSOS._pFile2Type = FileType
                cDalBPSOS._pFile2Data = bytes
            Else
                filecheck(fileno)
            End If

        End If
        If fileno = "file3" Then
            Dim FileData As HttpPostedFile = _oTxtFile3.PostedFile
            Dim FileName As String = _oTxtFile3.PostedFile.FileName
            Dim FileType As String = _oTxtFile3.PostedFile.ContentType
            If FileType = "image/png" Or FileType = "application/pdf" Or FileType = "image/jpeg" Or FileType = "image/jpg" Then
                Dim fs As Stream = FileData.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                cDalBPSOS._pFile3Name = FileName
                cDalBPSOS._pFile3Type = FileType
                cDalBPSOS._pFile3Data = bytes
            Else
                filecheck(fileno)
            End If
        End If
        If fileno = "file4" Then
            Dim FileData As HttpPostedFile = _oTxtFile4.PostedFile
            Dim FileName As String = _oTxtFile4.PostedFile.FileName
            Dim FileType As String = _oTxtFile4.PostedFile.ContentType
            If FileType = "image/png" Or FileType = "application/pdf" Or FileType = "image/jpeg" Or FileType = "image/jpg" Then
                Dim fs As Stream = FileData.InputStream
                Dim br As New BinaryReader(fs)
                Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                cDalBPSOS._pFile4Name = FileName
                cDalBPSOS._pFile4Type = FileType
                cDalBPSOS._pFile4Data = bytes
            Else
                filecheck(fileno)
            End If

        End If

        'Response.Redirect("NewProperty.aspx")
    End Sub

    Public Sub filecheck(fileno)
        snackbar("red", "Invalid file!")
        If fileno = "file1" Then
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>sessionStorage.setItem('file1','No file chosen');")
            sb.Append("document.getElementById('_oLblFile1').innerHTML = sessionStorage.getItem('file1');</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "FJSScript", sb.ToString())
        End If
        If fileno = "file2" Then
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>sessionStorage.setItem('file2','No file chosen');")
            sb.Append("document.getElementById('_oLblFile2').innerHTML = sessionStorage.getItem('file2');</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "FJSScript", sb.ToString())
        End If
        If fileno = "file3" Then
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>sessionStorage.setItem('file3','No file chosen');")
            sb.Append("document.getElementById('_oLblFile3').innerHTML = sessionStorage.getItem('file3');</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "FJSScript", sb.ToString())
        End If
        If fileno = "file4" Then
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            sb.Append("<script language='javascript'>sessionStorage.setItem('file4','No file chosen');")
            sb.Append("document.getElementById('_oLblFile4').innerHTML = sessionStorage.getItem('file4');</script>")
            ClientScript.RegisterStartupScript(Me.[GetType](), "FJSScript", sb.ToString())
        End If
    End Sub


    Private Sub _SaveInformation()
        Try
            Dim _nclass As New cDalBPSOS
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nclass._pAcctNo = cSessionLoader._pAccountNo
            '  _nclass._pForYear = Year(Today)
            _nclass._pSubGetCurYear()
            _nclass._pForYear = _nclass._nCurYear
            'upload_Docs_New()
            _nclass._pSubDeleteAttachFiles()
            _nclass._pSubInsertAttachFiles()
            snackbar("green", "Record Saved!")
            'Response.AddHeader("REFRESH", "3;URL=Account.aspx")
        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetAllAttachedFile()

    End Sub

    Private Sub TextAskInit()
        Try
            'askquestion
            Dim I As Integer

            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            ' _nClass._pForYear = Year(Today)
            ' _nClass._pMonth = Month(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPASKQTY()
            _nClass._pSubGET_ASKQTY()
            _nAskhdg = ""
            _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE xvalue is null"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("ASKHDG").ToString

                        'Dim keys As List(Of String) = Request.Form.AllKeys.Where(Function(key) key.Contains("_oTxtAskQ")).ToList()
                        'Dim i As Integer = 1
                        'For Each key As String In keys
                        '    Me.CreateTextBox("_oTxtAskQ" & i)
                        '    i += 1
                        'Next



                        'Dim keys1 As List(Of String) = Request.Form.AllKeys.Where(Function(key1) key1.Contains("_oLblAskQ")).ToList()
                        'Dim j As Integer = 1
                        'For Each key1 As String In keys1
                        '    Me.CreateLabel("_oLblAskQ" & j, _nAskhdg)
                        '    j += 1
                        'Next

                        I = I + 1


                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlTextAskQ.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlTextAskQ.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:90%'>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------

                        Me.CreateLabel("_oLblAskQ" & I, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:10%'>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Me.CreateTextBox("_oTxtAskQ" & I)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlTextAskQ.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlTextAskQ.Controls.Add(_oLTtTable1)


                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()





        Catch ex As Exception

        End Try
    End Sub
    Private Sub TextAskHeadInit()
        Try


            'askheading
            Dim I As Integer
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            '_nClass._pForYear = Year(Today)
            '_nClass._pMonth = Month(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPASKHDG()
            _nClass._pSubGET_ASKHDG()
            _nAskhdg = ""
            _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE xvalue is null"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("ASKHDG").ToString

                        'Dim keys As List(Of String) = Request.Form.AllKeys.Where(Function(key) key.Contains("_oTxtAskHP")).ToList()
                        'Dim i As Integer = 1
                        'For Each key As String In keys
                        '    Me.CreateTextBoxHead("_oTxtAskHP" & i)
                        '    i += 1
                        'Next

                        'Dim keys1 As List(Of String) = Request.Form.AllKeys.Where(Function(key1) key1.Contains("_oLblAskHP")).ToList()
                        'Dim j As Integer = 1
                        'For Each key1 As String In keys1
                        '    Me.CreateLabelHead("_oLblAskHP" & j, _nAskhdg)
                        '    j += 1
                        'Next


                        I = I + 1

                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlAllAskHeading.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:85%'>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------

                        Me.CreateLabelHead("_oLblAskHP" & I, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:15%'>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Me.CreateTextBoxHead("_oTxtAskHP" & I)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlAllAskHeading.Controls.Add(_oLTtTable1)


                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()

        Catch ex As Exception

        End Try


    End Sub
    Private Sub DropDownAskInit()
        Try


            Dim I As Integer
            Dim askOptDesc As String
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            '_nClass._pForYear = Year(Today)
            '_nClass._pMonth = Month(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPOPTION()
            _nClass._pSubGET_OPTION()
            _nAskhdg = ""
            _nQuery = "SELECT DISTINCT TAXCODE FROM [" & _nClass._pTempTbl & "]"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("TAXCODE").ToString


                        'Dim keys As List(Of String) = Request.Form.AllKeys.Where(Function(key) key.Contains("_oLblOpt")).ToList()
                        'Dim i As Integer = 1
                        'For Each key As String In keys
                        '    Me.CreateLabelDropDown("_oLblOpt" & i, _nAskhdg)
                        '    i += 1
                        'Next

                        'Dim keys1 As List(Of String) = Request.Form.AllKeys.Where(Function(key1) key1.Contains("_oSelectOpt")).ToList()
                        'Dim j As Integer = 1
                        'For Each key1 As String In keys1
                        '    Me.CreateSelect("_oSelectOpt" & j, _nAskhdg, j)
                        '    j += 1
                        'Next



                        I = I + 1

                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:50%'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------
                        If Left(_nAskhdg, 1) = "1" Or Left(_nAskhdg, 1) = "2" Then
                            askOptDesc = "Business Tax Option"
                        ElseIf Left(_nAskhdg, 1) = "3" Then
                            askOptDesc = "Garbage Option"
                        ElseIf Left(_nAskhdg, 1) = "4" Then
                            askOptDesc = "Mayors Permit Option"
                        ElseIf Left(_nAskhdg, 1) = "5" Then
                            askOptDesc = "Sanitary Option"
                        ElseIf Left(_nAskhdg, 1) = "6" Then
                            askOptDesc = "Fire Fee Option"
                        End If

                        Me.CreateLabelDropDown("_oLblOpt" & I, askOptDesc)
                        Me.CreateLabelDropDown2("_oLblOpt2" & I, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:50%'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Me.CreateSelect("_oSelectOpt" & I, _nAskhdg, I)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLTtTable1)

                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub TextAsk()
        Try
            'askquestion
            Dim I As Integer

            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            '_nClass._pForYear = Year(Today)
            '_nClass._pMonth = Month(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPASKQTY()
            _nClass._pSubGET_ASKQTY()
            _nAskhdg = ""
            _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE xvalue is null"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("ASKHDG").ToString



                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlTextAskQ.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlTextAskQ.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:90%'>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------

                        Dim index1 As Integer = _opnlTextAskQ.Controls.OfType(Of Label)().ToList().Count + 1
                        Me.CreateLabel("_oLblAskQ" & index1, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:10%'>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Dim index As Integer = _opnlTextAskQ.Controls.OfType(Of TextBox)().ToList().Count + 1
                        Me.CreateTextBox("_oTxtAskQ" & index)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlTextAskQ.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlTextAskQ.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlTextAskQ.Controls.Add(_oLTtTable1)
                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextAskHead()
        Try


            'askheading
            Dim I As Integer
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            '_nClass._pForYear = Year(Today)
            '_nClass._pMonth = Month(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPASKHDG()
            _nClass._pSubGET_ASKHDG()
            _nAskhdg = ""
            ' _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "]"
            _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE xvalue is null"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("ASKHDG").ToString


                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlAllAskHeading.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:85%'>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------

                        Dim index1 As Integer = _opnlAllAskHeading.Controls.OfType(Of Label)().ToList().Count + 1
                        Me.CreateLabelHead("_oLblAskHP" & index1, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:15%'>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Dim index As Integer = _opnlAllAskHeading.Controls.OfType(Of TextBox)().ToList().Count + 1
                        Me.CreateTextBoxHead("_oTxtAskHP" & index)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlAllAskHeading.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlAllAskHeading.Controls.Add(_oLTtTable1)

                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()

        Catch ex As Exception

        End Try


    End Sub
    Private Sub DropDownAsk()
        Try


            Dim I As Integer
            Dim askOptDesc As String
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            '_nClass._pForYear = Year(Today)
            '_nClass._pMonth = Month(Today)
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pMonth = _nClass._nCurMonth
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubTotalGross()

            '----------------------------------

            Dim _nClass1 As New cDalBPSOS
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass1._pAcctNo = cSessionLoader._pAccountNo
            _nClass1._pSubSelectPrevGross()
            Dim _nSqlCommand As SqlCommand
            Dim _nQuery As String = Nothing
            Dim _nSqlDataReader As SqlDataReader
            Dim _nAskhdg As String
            Dim _nTaxCode As String

            _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubCREATE_TEMPOPTION()
            _nClass._pSubGET_OPTION()
            _nAskhdg = ""
            _nQuery = "SELECT DISTINCT TAXCODE FROM [" & _nClass._pTempTbl & "]"
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
            Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
                ''  _nSqlDr.Read()
                If _nSqlDr.HasRows Then
                    'Getting Record using reader
                    Do While _nSqlDr.Read
                        _nAskhdg = _nSqlDr.Item("TAXCODE").ToString


                        '------------------------------------------------------
                        Dim _oLTtTable = New Literal()
                        _oLTtTable.Text = "<table border='0'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLTtTable)

                        Dim _oLtTableRow = New Literal()
                        _oLtTableRow.Text = "<tr>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableRow)

                        Dim _oLtTableCell = New Literal()
                        _oLtTableCell.Text = "<td style='width:50%'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell)
                        '------------------------------------------------------

                        Dim index As Integer = _opnlDrpDownAskOpt.Controls.OfType(Of Label)().ToList().Count + 1

                        If Left(_nAskhdg, 1) = "1" Or Left(_nAskhdg, 1) = "2" Then
                            askOptDesc = "Business Tax Option"
                        ElseIf Left(_nAskhdg, 1) = "3" Then
                            askOptDesc = "Garbage Option"
                        ElseIf Left(_nAskhdg, 1) = "4" Then
                            askOptDesc = "Mayors Permit Option"
                        ElseIf Left(_nAskhdg, 1) = "5" Then
                            askOptDesc = "Sanitary Option"
                        ElseIf Left(_nAskhdg, 1) = "6" Then
                            askOptDesc = "Fire Fee Option"
                        End If


                        Me.CreateLabelDropDown("_oLblOpt" & index, askOptDesc)
                        Me.CreateLabelDropDown2("_oLblOpt2" & index, _nAskhdg)

                        '------------------------------------------------------
                        Dim _oLtTableCell1 = New Literal()
                        _oLtTableCell1.Text = "</td>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell1)

                        Dim _oLtTableCell2 = New Literal()
                        _oLtTableCell2.Text = "<td style='width:50%'>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell2)

                        '------------------------------------------------------

                        Dim index1 As Integer = _opnlDrpDownAskOpt.Controls.OfType(Of DropDownList)().ToList().Count + 1
                        Me.CreateSelect("_oSelectOpt" & index1, _nAskhdg, index1)

                        '----------------------------------------------------

                        Dim _oLtTableCell3 = New Literal()
                        _oLtTableCell3.Text = "</td>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableCell3)

                        Dim _oLtTableRow1 = New Literal()
                        _oLtTableRow1.Text = "</tr>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLtTableRow1)

                        Dim _oLTtTable1 = New Literal()
                        _oLTtTable1.Text = "</table>"
                        _opnlDrpDownAskOpt.Controls.Add(_oLTtTable1)

                    Loop
                End If

            End Using
            _nSqlCommand.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateLabel(id As String, txt As String)
        'askquestion
        Dim lbl = New Label()
        lbl.ID = id
        lbl.CssClass = "col"
        lbl.Text = txt
        _opnlTextAskQ.Controls.Add(lbl)
    End Sub

    Private Sub CreateLabelHead(id As String, txt As String)
        'askheading
        Dim lbl = New Label()
        lbl.ID = id
        lbl.CssClass = "col"
        lbl.Text = txt
        _opnlAllAskHeading.Controls.Add(lbl)
    End Sub



    Private Sub CreateTextBox(id As String)
        'askquestion
        Dim txt = New TextBox()
        txt.ID = id
        txt.CssClass = "col-12"
        _opnlTextAskQ.Controls.Add(txt)

        Dim lt = New Literal()
        lt.Text = "<br />"
        _opnlTextAskQ.Controls.Add(lt)
    End Sub

    Private Sub CreateTextBoxHead(id As String)

        'askheading
        Dim txt = New TextBox()
        txt.ID = id
        txt.CssClass = "col-12"
        txt.Attributes.Add("style", "font-size:11px;")
        _opnlAllAskHeading.Controls.Add(txt)

        Dim lt = New Literal()
        lt.Text = "<br />"
        _opnlAllAskHeading.Controls.Add(lt)
    End Sub
    Private Sub CreateTextBoxHead1(id As String, txtval As String)
        'askheading
        Dim txt = New TextBox()
        txt.ID = id
        txt.Text = txtval
        txt.Width = 50
        _opnlAllAskHeading.Controls.Add(txt)

        Dim lt = New Literal()
        lt.Text = "<br />"
        _opnlAllAskHeading.Controls.Add(lt)
    End Sub
    Private Sub CreateLabelDropDown(id As String, txt As String)
        Dim lbl = New Label()
        lbl.ID = id
        lbl.CssClass = "col"
        lbl.Text = txt
        lbl.Visible = True
        _opnlDrpDownAskOpt.Controls.Add(lbl)

    End Sub
    Private Sub CreateLabelDropDown2(id As String, txt As String)
        Dim lbl = New Label()
        lbl.ID = id
        lbl.CssClass = "col"
        lbl.Text = txt
        lbl.Visible = False
        _opnlDrpDownAskOpt.Controls.Add(lbl)

    End Sub
    Private Sub CreateSelect(id As String, xTaxCode As String, xindex As Integer)

        Dim index As Integer
        Dim j As Integer


        'For j = 1 To noOfItem

        Dim _nClass As New cDalBPSOS
        Dim myOutPut As String

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
        _nClBP._pSubRecordSelectSpecific()

        '----------------------------------
        'Specify Blank to Select Nothing but Column Names
        '_nClass._pForYear = Year(Today)
        '_nClass._pMonth = Month(Today)
        _nClass._pSubGetCurYear()
        _nClass._pForYear = _nClass._nCurYear
        _nClass._pMonth = _nClass._nCurMonth
        _nClass._pAcctNo = cSessionLoader._pAccountNo
        _nClass._pLocServer = _nClBP._pDBDataSource
        _nClass._pLocDB = _nClBP._pDBInitialCatalog
        _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pTempGross = "tempGross_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pSubTotalGross()

        '----------------------------------

        Dim _nClass1 As New cDalBPSOS
        _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass1._pAcctNo = cSessionLoader._pAccountNo
        _nClass1._pSubSelectPrevGross()
        Dim _nSqlCommand As SqlCommand
        Dim _nQuery As String = Nothing
        Dim _nSqlDataReader As SqlDataReader
        Dim _nAskhdg As String
        Dim _nTaxCode As String

        _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")
        _nClass._pSubCREATE_TEMPOPTION()
        _nClass._pSubGET_OPTION()
        _nAskhdg = ""
        _nQuery = "SELECT * FROM [" & _nClass._pTempTbl & "] WHERE TAXCODE = '" & xTaxCode & "'"

        Dim listvalue As String
        ' Dim MyLI As New ListItem

        Dim MyDDL = New DropDownList()
        MyDDL.ID = id
        MyDDL.CssClass = "col-12"

        _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
        Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
            ''  _nSqlDr.Read()
            If _nSqlDr.HasRows Then
                'Getting Record using reader

                Do While _nSqlDr.Read

                    listvalue = _nSqlDr.Item("OPTHDG1").ToString
                    MyDDL.Items.Add(New ListItem(listvalue, listvalue))
                Loop
            End If

        End Using
        _nSqlCommand.Dispose()


        _opnlDrpDownAskOpt.Controls.Add(MyDDL)

        Dim MyLiteral = New LiteralControl
        MyLiteral.Text = "<BR>"
        _opnlDrpDownAskOpt.Controls.Add(MyLiteral)
    End Sub

    Private Sub _mSubGetGrValue()
        Dim index As Integer
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        _nClass._pTempTbl = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")


        For Each textBox As TextBox In _opnlAllAskHeading.Controls.OfType(Of TextBox)()

            index = index + 1
            Dim label As New Label
            Dim txtbox As New TextBox
            label = _opnlAllAskHeading.FindControl("_oLblAskHP" & index)
            '  txtbox = _opnlAllAskHeading.FindControl("_oTxtAskHP" & index)

            If textBox.ID = "_oTxtAskHP" & index Then
                _nClass._pASKHDG = label.Text
                _nClass._pXValue = textBox.Text
                _nClass._pSubGETVALUE_TEMPASKHDG()
            End If
        Next


        'For index = 0 To 100




        Dim index1 As Integer
        _nClass._pTempTbl = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")


        For Each textBox1 As TextBox In _opnlTextAskQ.Controls.OfType(Of TextBox)()

            index1 = index1 + 1
            Dim label1 As New Label
            label1 = _opnlTextAskQ.FindControl("_oLblAskQ" & index1)


            If textBox1.ID = "_oTxtAskQ" & index1 Then
                _nClass._pASKHDG = label1.Text
                _nClass._pXValue = textBox1.Text
                _nClass._pSubGETVALUE_TEMPASKHDG()
            End If
        Next


        Dim index2 As Integer
        _nClass._pTempTbl = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

        For Each DropDown As DropDownList In _opnlDrpDownAskOpt.Controls.OfType(Of DropDownList)()

            index2 = index2 + 1
            Dim label2 As New Label
            label2 = _opnlDrpDownAskOpt.FindControl("_oLblOpt2" & index2)


            If DropDown.ID = "_oSelectOpt" & index2 Then
                _nClass._pASKHDG = DropDown.Text
                _nClass._pTaxCode = label2.Text
                _nClass._pSubGETVALUE_TEMPASKOPT()
            End If
        Next


    End Sub

End Class