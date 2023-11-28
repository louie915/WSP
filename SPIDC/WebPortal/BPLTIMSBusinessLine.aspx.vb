Imports System.Net.Mail
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web.Services
Imports Microsoft.Reporting.WebForms
Imports SPIDC.Resources
Imports System.Reflection


Public Class BPLTIMSBusinessLine
    Inherits System.Web.UI.Page
    Dim strCatCode, strCatDesc, strBusCode, strBusDesc As String
    Dim AccountNumber As String
    Dim ctr_addedBusLine As Integer

    Dim gridAction As String
    Dim gridBusCode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '----------------------------------
            If Not IsPostBack Then
                '  cSessionUser._pUserID = "tomi24"
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then

                    Response.Redirect("Register.aspx")

                End If
                'cLoader_BPLTIMS._pDATE_ESTA = "2020-07-22"
                'cLoader_BPLTIMS._pACCTNO = "200722-00004"
                cSessionLoader._pAccountNo = cLoader_BPLTIMS._pACCTNO
                'cLoader_BPLTIMS._pACCTNO = Session("AccountNumber")
                cLoader_BPLTIMS._pFORYEAR = DateTime.Now.Year.ToString

                'Get_BusCode()
                Get_Added_Busline()
                'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "HidePopup", "$('#MyPopup').modal('hide')", True)
                HidePopup()
            Else

                gridAction = Request("__EVENTTARGET")
                gridBusCode = Request("__EVENTARGUMENT")
                If gridAction = "Remove" Then
                    Dim _nSuccessful As Boolean
                    Dim _nErrMsg As String = ""
                    _DeleteBusLine(_nSuccessful, _nErrMsg)
                    Get_Added_Busline()
                End If


            End If

            '----------------------------------
        Catch ex As Exception
        End Try
    End Sub

    Private Sub _oBtnSearchh(sender As Object, e As EventArgs) Handles _oBtnSearch.ServerClick
        Try


            Get_BusCode()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Get_BusCode()
        Try
            '----------------------------------
            cmbBusCode.DataSourceID = Nothing
            Dim _nClass As New cDalBusinessLine_Tomi
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSelCatCode = strCatCode
            _nClass._pGetBusLine = "BUSCODE"
            _nClass._pSubSelect("WHERE Description like '%" & _oTxtSearchBusLine.Text & "%'")

            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try

                cmbBusCode.DataSource = _nDataSet
                cmbBusCode.DataTextField = "DESCRIPTION"
                'cmbBusCode.DataValueField = "CATEGORY_BUSCODE"
                cmbBusCode.DataValueField = "CATEGORY_BUSCODE"
                cmbBusCode.DataBind()

                cmbBusCode.Items.Insert(0, New ListItem("Business Line", ""))

                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Get_Added_Busline()
        Try
            '----------------------------------

            Dim _nGridView As New GridView

            _nGridView = _oGridViewAddedBusline
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalBusinessLine_GetAdded
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pAcctNo = cLoader_BPLTIMS._pACCTNO
            _nClass._pSubSelect()

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
                    _nGridView.DataBind()
                End If
                '----------------------------------
            Catch ex As Exception
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Sub

    Protected Sub ShowPopup()
        Dim title As String = ""
        ' Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Popup", "ShowPopup('" & title & "')", True)
        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" & title & "');", True)
    End Sub

    Protected Sub HidePopup()
        Try
            '   Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Popup", "HidePopup();", True)
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "HidePopup();", True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSaveBusLine_ServerClick(sender As Object, e As EventArgs) Handles btnSaveBusLine.ServerClick

        Try
            '----------------------------------
            If Not IsPostBack Then

            Else

                If _otextArea.Text = "" Then
                    snackbar("red", "Please Enter Area")
                    _otextArea.BorderColor = Drawing.Color.Red
                    Exit Sub
                Else
                    _otextArea.BorderColor = Drawing.Color.FromName("#CCCCCC")
                End If

                If _otextCapital.Text = "" Then
                    snackbar("red", "Please Enter Capital")
                    _otextCapital.BorderColor = Drawing.Color.Red
                    Exit Sub
                Else
                    _otextCapital.BorderColor = Drawing.Color.FromName("#CCCCCC")
                End If

                If cmbBusCode.SelectedIndex = 0 Or cmbBusCode.SelectedIndex = -1 Then
                    snackbar("red", "Please select Business Line")
                    Exit Sub
                End If

                '-------Pass Value to cLoader
                cLoader_BPLTIMS._pAREA = _otextArea.Text
                cLoader_BPLTIMS._pCAPITAL = _otextCapital.Text
                cLoader_BPLTIMS._pGROSSREC = "0.00"

                cLoader_BPLTIMS._pBusinessDescription = _otextBusinessNature.Text
                ''== For BusExtn
                cLoader_BPLTIMS._pSTATCODE = "N"

                '----------Save Selected Busline
                Dim _nSuccessful As Boolean
                Dim _nErrMsg As String = ""

                Dim BUSCODE As String = cmbBusCode.Value.Substring(cmbBusCode.Value.IndexOf("_"c) + 1)

                cLoader_BPLTIMS._pBUS_CODE = cmbBusCode.Items(cmbBusCode.SelectedIndex).Value.Substring(cmbBusCode.Value.IndexOf("_"c) + 1)

                _ProcessBuslineDataGathering()

                If cPageSession_BusinessLine._pELECCODE_processed = True And _
                  cPageSession_BusinessLine._pMECHCODE_processed = True And _
                   cPageSession_BusinessLine._pBLDGCODE_processed = True And _
                    cPageSession_BusinessLine._pSIGNCODE_processed = True And _
                     cPageSession_BusinessLine._pEPOCODE_processed = True And _
                      cPageSession_BusinessLine._pEIFCODE_processed = True And _
                       cPageSession_BusinessLine._pPLATECODE_processed = True And _
                       cPageSession_BusinessLine._pBCODE_processed = True And _
                       cPageSession_BusinessLine._pMCODE_processed = True And _
                       cPageSession_BusinessLine._pGCODE_processed = True And _
                       cPageSession_BusinessLine._pSCODE_processed = True And _
                       cPageSession_BusinessLine._pFCODE_processed = True Then
                    _mSubBusLineUpdate()
                    _mSubSaveGatheredInfo()
                Else
                    _mFnContinueDataGather()
                End If



            End If



            '----------------------------------
        Catch ex As Exception



        End Try


    End Sub

    Private Sub _mSubBusLineUpdate()        ' @ Added   20161129

        Dim _nClass As New cDalBusinessLine
        With _nClass
            ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            ._pAccount = cSessionLoader._pAccountNo
            ._pBusDistCode = cLoader_BPLTIMS._pDISTCODE
            ._pBusBRGYCode = cLoader_BPLTIMS._pBRGYCODE
            ._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            ._pBusDesc = Trim(cmbBusCode.Value)
            ._pBusYear = cLoader_BPLTIMS._pFORYEAR
            ._pBusArea = cLoader_BPLTIMS._pAREA
            ._pBusCap = cLoader_BPLTIMS._pCAPITAL
            ._pBusGrossRec = cLoader_BPLTIMS._pGROSSREC
            ._pBusNRC = "N"
            cPageSession_BPLTASnew._pStatus = "N"
            ._pDate_Estab = cLoader_BPLTIMS._pDATE_ESTA

            If _mFnValidateIfExist() = False Then
                '_oPanelMsg.Visible = False
                '  ._pSubInserInto_BUSEXTN_WEB()
                If cPageSession_BPLTASnew._pStatus = "N" Then
                    ._pSubDeleteFrom_BUSEXTN_WEB()
                    ._pSubInserInto_BUSEXTN_WEB() ' Reused 20180622
                    ._pSubInserInto_BUSLINE_WEB()
                    ._pSub_DeleteBuslineZeroVal()
                End If


            Else
                If _mFnValidateIfExist_BUSLINE() = False Then
                    '_oPanelMsg.Visible = False
                    If cPageSession_BPLTASnew._pStatus = "N" Then
                        ._pSubInserInto_BUSLINE_WEB()
                        ._pSub_DeleteBuslineZeroVal()
                    End If
                Else
                    '_oPanelMsg.Visible = True
                    '_oLabelMsg.Text = "Double entry on Line of Business is not allowed."
                End If

            End If



        End With
    End Sub
    Private Function _mFnValidateIfExist() As Boolean
        Try
            '----------------------------------
            _mFnValidateIfExist = False


            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnValidateIfExist = True
                Else
                    _mFnValidateIfExist = False
                End If
                '----------------------------------
            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function _mFnValidateIfExist_BUSLINE() As Boolean       '@  Added 20161202
        Try
            '----------------------------------
            _mFnValidateIfExist_BUSLINE = False




            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pSubSelect_BUSLINE()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnValidateIfExist_BUSLINE = True
                Else
                    _mFnValidateIfExist_BUSLINE = False
                End If
                '----------------------------------
            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub _mSubSaveGatheredInfo() 'Added 20170629

        Dim _nClass As New cDalBusinessLine
        Dim timeFormat As String = "yyyy-MM-dd"

        Dim STATUS As String = "N"

        With _nClass
            ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            ._pAccount = cSessionLoader._pAccountNo
            '._pDate_Estab = Convert.ToDateTime(cPageSession_BPLTASnew._pDate_Estab).ToString(timeFormat)
            ._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            ._pBusYear = cLoader_BPLTIMS._pFORYEAR


            ._pBCHOICE_Row = cPageSession_BusinessLine._pBCODE_Option_RowNo
            ._pMCHOICE_Row = cPageSession_BusinessLine._pMCODE_Option_RowNo
            ._pGCHOICE_Row = cPageSession_BusinessLine._pGCODE_Option_RowNo
            ._pSCHOICE_Row = cPageSession_BusinessLine._pSCODE_Option_RowNo
            ._pFCHOICE_Row = cPageSession_BusinessLine._pFCODE_Option_RowNo

            '--------------------------------------------------------------------
            '._pBCHOICE1 = cPageSession_BusinessLine._pBCODE_Option_TaxCode
            ._pBRANGE_QTY = cPageSession_BusinessLine._pBCODE_GRASKHDG_Val
            ._pBQTY1 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val1
            ._pBQTY2 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val2
            ._pBQTY3 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val3
            ._pBQTY4 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val4
            ._pBQTY5 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val5
            ._pBQTY6 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val6
            ._pBQTY7 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val7
            ._pBQTY8 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val8
            ._pBQTY9 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val9
            ._pBQTY10 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val10

            If ._pBQTY1 <> 0 Or ._pBQTY2 <> 0 Or ._pBQTY3 <> 0 Or ._pBQTY4 <> 0 Or ._pBQTY5 <> 0 _
                Or ._pBQTY6 <> 0 Or ._pBQTY7 <> 0 Or ._pBQTY8 <> 0 Or ._pBQTY9 <> 0 Or ._pBQTY10 <> 0 Then
                ._pBQTY = 1
            Else
                ._pBQTY = 0
            End If

            ._pMRANGE_QTY = cPageSession_BusinessLine._pMCODE_GRASKHDG_Val
            ._pMQTY1 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val1
            ._pMQTY2 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val2
            ._pMQTY3 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val3
            ._pMQTY4 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val4
            ._pMQTY5 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val5
            ._pMQTY6 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val6
            ._pMQTY7 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val7
            ._pMQTY8 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val8
            ._pMQTY9 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val9
            ._pMQTY10 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val10


            If ._pMQTY1 <> 0 Or ._pMQTY2 <> 0 Or ._pMQTY3 <> 0 Or ._pMQTY4 <> 0 Or ._pMQTY5 <> 0 _
                Or ._pMQTY6 <> 0 Or ._pMQTY7 <> 0 Or ._pMQTY8 <> 0 Or ._pMQTY9 <> 0 Or ._pMQTY10 <> 0 Then
                ._pMQTY = 1
            Else
                ._pMQTY = 0
            End If


            ._pGRANGE_QTY = cPageSession_BusinessLine._pGCODE_GRASKHDG_Val
            ._pGQTY1 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val1
            ._pGQTY2 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val2
            ._pGQTY3 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val3
            ._pGQTY4 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val4
            ._pGQTY5 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val5
            ._pGQTY6 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val6
            ._pGQTY7 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val7
            ._pGQTY8 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val8
            ._pGQTY9 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val9
            ._pGQTY10 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val10

            If ._pGQTY1 <> 0 Or ._pGQTY2 <> 0 Or ._pGQTY3 <> 0 Or ._pGQTY4 <> 0 Or ._pGQTY5 <> 0 _
                Or ._pGQTY6 <> 0 Or ._pGQTY7 <> 0 Or ._pGQTY8 <> 0 Or ._pGQTY9 <> 0 Or ._pGQTY10 <> 0 Then
                ._pGQTY = 1
            Else
                ._pGQTY = 0
            End If

            ._pSRANGE_QTY = cPageSession_BusinessLine._pSCODE_GRASKHDG_Val
            ._pSQTY1 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val1
            ._pSQTY2 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val2
            ._pSQTY3 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val3
            ._pSQTY4 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val4
            ._pSQTY5 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val5
            ._pSQTY6 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val6
            ._pSQTY7 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val7
            ._pSQTY8 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val8
            ._pSQTY9 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val9
            ._pSQTY10 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val10

            If ._pSQTY1 <> 0 Or ._pSQTY2 <> 0 Or ._pSQTY3 <> 0 Or ._pSQTY4 <> 0 Or ._pSQTY5 <> 0 _
                Or ._pSQTY6 <> 0 Or ._pSQTY7 <> 0 Or ._pSQTY8 <> 0 Or ._pSQTY9 <> 0 Or ._pSQTY10 <> 0 Then
                ._pSQTY = 1
            Else
                ._pSQTY = 0
            End If

            ._pFRANGE_QTY = cPageSession_BusinessLine._pFCODE_GRASKHDG_Val
            ._pFQTY1 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val1
            ._pFQTY2 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val2
            ._pFQTY3 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val3
            ._pFQTY4 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val4
            ._pFQTY5 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val5
            ._pFQTY6 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val6
            ._pFQTY7 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val7
            ._pFQTY8 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val8
            ._pFQTY9 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val9
            ._pFQTY10 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val10

            If ._pFQTY1 <> 0 Or ._pFQTY2 <> 0 Or ._pFQTY3 <> 0 Or ._pFQTY4 <> 0 Or ._pFQTY5 <> 0 _
                Or ._pFQTY6 <> 0 Or ._pFQTY7 <> 0 Or ._pFQTY8 <> 0 Or ._pFQTY9 <> 0 Or ._pFQTY10 <> 0 Then
                ._pFQTY = 1
            Else
                ._pFQTY = 0
            End If

            ._pBUSTAX = 0
            ._pMAYORS = 0
            ._pGARBAGE = 0
            ._pSANITARY = 0
            ._pFIRE = 0
            ._pGarbage_O = 0
            ._pSanitary_O = 0
            ._pFire_O = 0
            ._pNewsw = "0"

            ''''--------------------------------------------
            ._pELECfee = cPageSession_BusinessLine._pELECCODE_FEE
            ._pMECHfee = cPageSession_BusinessLine._pMECHCODE_FEE
            ._pBLDGfee = cPageSession_BusinessLine._pBLDGCODE_FEE
            ._pSIGNfee = cPageSession_BusinessLine._pSIGNCODE_FEE
            ._pEPOfee = cPageSession_BusinessLine._pEPOCODE_FEE
            ._pEIFfee = cPageSession_BusinessLine._pEIFCODE_FEE
            ._pPLATfee = cPageSession_BusinessLine._pPLATECODE_FEE
            ''''--------------------------------------------

            '  _mSubBusLineUpdate()


            ._pSubSaveGatheredInfo()    '@  Added 20170630

            ._mSubCheckChoiceValue()    '@  Added 20170630          
            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            'Select Case True
            '    Case cPageSession_BusinessLine._pBCHOICE_HasValue
            If _nClass._pBCHOICE1 = Nothing Then
                ._pCHOICE_Col = "BCHOICE1"
                ._pSaveSelectedOption_BCHOICE()
            Else
                If _nClass._pBCHOICE2 = Nothing Then
                    ._pCHOICE_Col = "BCHOICE2"
                    ._pSaveSelectedOption_BCHOICE()
                Else
                    If _nClass._pBCHOICE3 = Nothing Then
                        ._pCHOICE_Col = "BCHOICE3"
                        ._pSaveSelectedOption_BCHOICE()
                    Else
                        ._pCHOICE_Col = "BCHOICE4"
                        ._pSaveSelectedOption_BCHOICE()
                    End If
                End If
            End If
            ' Case cPageSession_BusinessLine._pMCHOICE_HasValue
            If _nClass._pMCHOICE1 = Nothing Then
                ._pCHOICE_Col = "MCHOICE1"
                ._pSaveSelectedOption_MCHOICE()
            Else
                If _nClass._pMCHOICE2 = Nothing Then
                    ._pCHOICE_Col = "MCHOICE2"
                    ._pSaveSelectedOption_MCHOICE()
                Else
                    If _nClass._pMCHOICE3 = Nothing Then
                        ._pCHOICE_Col = "MCHOICE3"
                        ._pSaveSelectedOption_MCHOICE()
                    Else
                        ._pCHOICE_Col = "MCHOICE4"
                        ._pSaveSelectedOption_MCHOICE()
                    End If
                End If
            End If
            'Case cPageSession_BusinessLine._pGCHOICE_HasValue
            If _nClass._pGCHOICE1 = Nothing Then
                ._pCHOICE_Col = "GCHOICE1"
                ._pSaveSelectedOption_GCHOICE()
            Else
                If _nClass._pGCHOICE2 = Nothing Then
                    ._pCHOICE_Col = "GCHOICE2"
                    ._pSaveSelectedOption_GCHOICE()
                Else
                    If _nClass._pGCHOICE3 = Nothing Then
                        ._pCHOICE_Col = "GCHOICE3"
                        ._pSaveSelectedOption_GCHOICE()
                    Else
                        ._pCHOICE_Col = "GCHOICE4"
                        ._pSaveSelectedOption_GCHOICE()
                    End If
                End If
            End If
            'Case cPageSession_BusinessLine._pSCHOICE_HasValue
            If _nClass._pSCHOICE1 = Nothing Then
                ._pCHOICE_Col = "SCHOICE1"
                ._pSaveSelectedOption_SCHOICE()
            Else
                If _nClass._pSCHOICE2 = Nothing Then
                    ._pCHOICE_Col = "SCHOICE2"
                    ._pSaveSelectedOption_SCHOICE()
                Else
                    If _nClass._pSCHOICE3 = Nothing Then
                        ._pCHOICE_Col = "SCHOICE3"
                        ._pSaveSelectedOption_SCHOICE()
                    Else
                        ._pCHOICE_Col = "SCHOICE4"
                        ._pSaveSelectedOption_SCHOICE()
                    End If
                End If
            End If
            'Case cPageSession_BusinessLine._pFCHOICE_HasValue
            If _nClass._pFCHOICE1 = Nothing Then
                ._pCHOICE_Col = "FCHOICE1"
                ._pSaveSelectedOption_FCHOICE()
            Else
                If _nClass._pFCHOICE2 = Nothing Then
                    ._pCHOICE_Col = "FCHOICE2"
                    ._pSaveSelectedOption_FCHOICE()
                Else
                    If _nClass._pFCHOICE3 = Nothing Then
                        ._pCHOICE_Col = "FCHOICE3"
                        ._pSaveSelectedOption_FCHOICE()
                    Else
                        ._pCHOICE_Col = "FCHOICE4"
                        ._pSaveSelectedOption_FCHOICE()
                    End If
                End If
            End If

            _otextCapital.Text = ""
            cmbBusCode.Value = ""
            Get_Added_Busline()

            _SaveBusinessNaration()
            snackbar("green", "Business Line added successfully")


            'End Select

            'Saving AIF FEES
            '_mFnCallClssAIF_PROCESS(._pAccount, STATUS, _oTextBoxDateEstablish.Text, _oTextBoxBusLineYear.Text)
            ''SAVING BUSLINE FEES
            '_mFnCallClssLINE_PROCESS(._pAccount, STATUS, _oTextBoxDateEstablish.Text, _oTextBoxBusLineYear.Text, _
            '                             _oTextBoxNRC.Text, ._pBusCode, cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode, _
            '                             cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBCODE_GRADTABL_EffMonth, _
            '                            cPageSession_BusinessLine._pMCODE_GRADTABL_EffMonth, cPageSession_BusinessLine._pGCODE_GRADTABL_EffMonth, cPageSession_BusinessLine._pSCODE_GRADTABL_EffMonth, cPageSession_BusinessLine._pFCODE_GRADTABL_EffMonth, _
            '                            cPageSession_BusinessLine._pBCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pFCODE_GRADTABL_EffYear)

            ''SAVING AIF PER LINE (False) 
            '_mFnCallClssAIF_LINE_PROCESS(._pAccount, ._pAccount, _oTextBoxBusLineYear.Text, _
            '                         ._pBusCode)


            '     _mSubPopulateYearDropDown()


            cPageSession_BusinessLine._pELECCODE_processed = False
            cPageSession_BusinessLine._pMECHCODE_processed = False
            cPageSession_BusinessLine._pBLDGCODE_processed = False
            cPageSession_BusinessLine._pSIGNCODE_processed = False
            cPageSession_BusinessLine._pEPOCODE_processed = False
            cPageSession_BusinessLine._pEIFCODE_processed = False
            cPageSession_BusinessLine._pPLATECODE_processed = False
            cPageSession_BusinessLine._pBCODE_processed = False
            cPageSession_BusinessLine._pMCODE_processed = False
            cPageSession_BusinessLine._pGCODE_processed = False
            cPageSession_BusinessLine._pSCODE_processed = False
            cPageSession_BusinessLine._pFCODE_processed = False

        End With

    End Sub


    Private Sub _SaveBusinessNaration()
        Try
            If _FnCheckExistingBusinessDescription() = False Then
                _SaveNewBusinessNaration()
            Else
                _UpdateBusinessNaration()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _SaveNewBusinessNaration()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO BusinessDescription (AcctNo,BusDescription ,ForYear) values (''" & cLoader_BPLTIMS._pACCTNO & "'' , ''" & cLoader_BPLTIMS._pBusinessDescription & "'' , Year(GETDATE()) )"
                ._pCondition = ""
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _UpdateBusinessNaration()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BusinessDescription SET BusDescription = ''" & cLoader_BPLTIMS._pBusinessDescription & "'' "
                ._pCondition = " Where ACCTNO = ''" & cLoader_BPLTIMS._pACCTNO & "'' AND FORYEAR =  Year(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Function _FnCheckExistingBusinessDescription() As Boolean
        Try

            Dim _nSuccess As Boolean, _nErrMsg As String

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM BusinessDescription "
                ._pCondition = " Where ACCTNO = ''" & cLoader_BPLTIMS._pACCTNO & "'' AND FORYEAR =  Year(GETDATE()) "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            End With

        Catch ex As Exception

        End Try
    End Function


    Private Sub _ProcessBuslineDataGathering()
        Try

            _pSetDefaults()

            _mAskELECCODE()

            If cPageSession_BusinessLine._pExit_ELECCODE = False Then
                _mAskMECHCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_MECHCODE = False Then
                _mAskBLDGCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_BLDGCODE = False Then
                _mAskSIGNCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_SIGNCODE = False Then
                _mAskEPOCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_EPOCODE = False Then
                _mAskEIFCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_EIFCODE = False Then
                _mAskPLATECODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_PLATECODE = False Then
                GoTo Basic_Fees
            Else
                Exit Sub
            End If

Basic_Fees:
            '--------------------------------------------------------------------------------------------------------
            _mAskBCODE()

            If cPageSession_BusinessLine._pExit_BCODE = False Then
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskMCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_MCODE = False Then
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskGCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_GCODE = False Then
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskSCODE()

            Else
                Exit Sub
            End If
            If cPageSession_BusinessLine._pExit_SCODE = False Then
                cPageSession_BusinessLine._pOptionTaxCode2 = Nothing
                _mAskFCODE()

            Else
                Exit Sub
            End If


        Catch ex As Exception

        End Try



    End Sub

    Private Sub _LogData(ByVal _nAsk As String, ByRef _nInfo As String)
        Try

            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = " INSERT INTO BusinessLineDataLog " & _
                            " ( " & _
                            " ACCTNO, BUSCODE, FORYEAR, DATA, INFO " & _
                            " ) " & _
                            " VALUES " & _
                            " ( ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pBUS_CODE & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " ,''" & _nAsk & "'' " & _
                            " ,''" & _nInfo & "'') "

                ._pExec(_nSuccessful, _nErrMsg)
            End With

        Catch ex As Exception

        End Try

    End Sub

    Public Sub _SaveBusExtn(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            _nSuccessful = True

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = " INSERT INTO BUSEXTN " & _
                            " ( " & _
                            " ACCTNO " & _
                            " ,FORYEAR " & _
                            " ,STATCODE " & _
                            " ) " & _
                            " VALUES " & _
                            " ( ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pSTATCODE & "'') "

                ._pExec(_nSuccessful, _nErrMsg)

            End With


        Catch ex As Exception
            _nSuccessful = False
        End Try

    End Sub
    Public Sub _DeleteBusExtn(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            _nSuccessful = True

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = " DELETE FROM BUSEXTN  " & _
                            " WHERE ACCTNO = ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " AND FORYEAR = ''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " AND STATCODE = ''" & cLoader_BPLTIMS._pSTATCODE & "'' "

                ._pExec(_nSuccessful, _nErrMsg)

            End With


        Catch ex As Exception
            _nSuccessful = False
        End Try

    End Sub
    Public Sub _SaveBusLine(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            _nSuccessful = True

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = " INSERT INTO BUSLINE " & _
                            " ( " & _
                            " ACCTNO " & _
                            " ,FORYEAR " & _
                            " ,BUS_CODE " & _
                            " ,AREA " & _
                            " ,CAPITAL " & _
                            " ,GROSSREC " & _
                            " ) " & _
                            " VALUES " & _
                            " ( ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pBUS_CODE & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pAREA & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pCAPITAL & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pGROSSREC & "'')"

                ._pExec(_nSuccessful, _nErrMsg)

            End With


        Catch ex As Exception
            _nSuccessful = False
        End Try

    End Sub

    Public Sub _DeleteBusLine(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            _nSuccessful = True

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pCondition = "where ACCTNO=''" & cLoader_BPLTIMS._pACCTNO & "'' and BUS_CODE=''" & gridBusCode & "''"
                ._pSelect = " DELETE from BUSLINE "
                ._pExec(_nSuccessful, _nErrMsg)

            End With

        Catch ex As Exception
            _nSuccessful = False
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

    Private Sub Finish_End_ServerClick(sender As Object, e As EventArgs) Handles Finish_End.ServerClick
        ctr_addedBusLine = _oGridViewAddedBusline.Rows.Count()



        If _oGridViewAddedBusline.Rows.Count = 0 Then
            snackbar("red", "Please add atleast 1 Line of Business.")
            Exit Sub
        Else
            ' snackbar("green", "Sending Email notification. Please wait...")
            'If _FnNotify_Taxpayer() = True Then
            '    _FnNotify_BPLO()
            '    UpdateBusMastRemarks(UCase("For Review"))
            '    snackbar("green", "Email Sent. Redirecting...")

            '    Response.Redirect("/VS2014.BPLTIMS/NotificationPages/ApplicationSuccess.aspx")
            '    Exit Sub
            'Else
            '    snackbar("red", "Failed to send Email, please try again")
            '    Exit Sub
            'End If

            cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

            Dim tst As String
            cSessionLGUProfile._pGetLGUProfile(tst)

            '    _GenerateReport_EnvelopeSeal()
            '    _RenderToPDF("EnvelopeSeal")
            '    _GenerateReport_ApplicationForm()
            '    _RenderToPDF("ApplicationForm")

            Dim _nClass3 As New cDalTransactionHistory

            Dim Particulars As String
            Dim Full As String = cLoaderNewBusinessApplication._pOwnerFName & " " & cLoaderNewBusinessApplication._pOwnerMName & " " & cLoaderNewBusinessApplication._pOwnerLName

            Particulars = "Business Name=" & cLoaderNewBusinessApplication._pBusTradeName & ";" _
                        & "Ownership Type=" & cLoaderNewBusinessApplication._pOwnershipType & ";" _
                        & "Owner Name=" & Full & ";"

            _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nClass3._pSubInsertHistory(cSessionLoader._pAccountNo, _
                                        cSessionUser._pUserID, _
                                        "Business Permit", _
                                        "Application", _
                                        "New Business Application", _
                                        Particulars, _
                                        "For Review")


            Dim Sent As Boolean
            Dim Subject As String = "New Business Application"
            Dim Body As String = "Sir/Ma`am: <br/> " & _
                            "Your Temporary Account Number: [" & cSessionLoader._pAccountNo & "] is now for review and verification by Business Permit Licensing Officer. <br/> " & _
                            "Further instructions will be sent thru email once the application has been reviewed. <br/> <br/> " & _
                            "Thank you."

            Try
                cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)

                If Sent = False Then
                    'snackbar("red", "Failed to Send Email Confirmation Link. Please refresh the page and try again.")
                    Response.Write("<script>alert('Failed to Send Email notification. Please check your internet connection and try again.');</script>")
                ElseIf Sent = True Then
                    email_success()
                    'Response.Write("<script>alert('You application has been sent to BPLO for further verification. Please check your email for more details.');</script>")
                    'Response.Redirect("Account.aspx", False)

                    'Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=BPNEW_APPINFO','_blank');</script>")
                    Response.Redirect("NotificationPages/ApplicationSuccess.aspx", False)
                    Exit Sub
                End If


            Catch ex As Exception
                Response.Write("<script>alert('" & ex.Message & "');</script>")
                'snackbar("red", "Failed to Send Email Confirmation. Please make sure that you are connected to the internet.")
                '  snackbar("red", ex.Message)
            End Try


            '   If _SendEmailNotif_Taxpayer() = True Then
            '       email_success()
            '       Exit Sub
            '   Else
            '       Response.Redirect("~/WebPortal/NotificationPages/EmailNotificationFailed.aspx")
            '       ' Response.Redirect(Request.Url.AbsoluteUri)
            '       ' Response.End()
            '   End If

        End If

    End Sub

    Sub email_success()
        UpdateBusMastRemarks(UCase("For Review"))
        cLoaderNewBusinessApplication._pOwnershipType = ""
        cLoaderNewBusinessApplication._pRent = False
        cLoaderNewBusinessApplication._pLessorDateRented = ""
        cLoaderNewBusinessApplication._pLessorRatePerMonth = ""
        cLoaderNewBusinessApplication._pLessorFirstName = ""
        cLoaderNewBusinessApplication._pLessorLastName = ""
        cLoaderNewBusinessApplication._pLessorBarangay = ""
        cLoaderNewBusinessApplication._pLessorStreet = ""
        cLoaderNewBusinessApplication._pLessorAddress = ""
        cLoaderNewBusinessApplication._pLessorTelNo = ""
        cLoaderNewBusinessApplication._pLessorEmail = ""
        cLoaderNewBusinessApplication._pBuildingAdministrator = ""
        cLoaderNewBusinessApplication._pGovCDANo = ""
        cLoaderNewBusinessApplication._pGovRegDateCDA = ""
        cLoaderNewBusinessApplication._pGovDTINo = ""
        cLoaderNewBusinessApplication._pGovRegDateDTI = ""
        cLoaderNewBusinessApplication._pGovSECNo = ""
        cLoaderNewBusinessApplication._pGovRegDateSEC = ""
        cLoaderNewBusinessApplication._pGovTINNo = ""
        cLoaderNewBusinessApplication._pGovRegDateTIN = ""
        cLoaderNewBusinessApplication._pGovSSS = ""
        cLoaderNewBusinessApplication._pGovRegDateSSS = ""
        cLoaderNewBusinessApplication._pGovBIR = ""
        cLoaderNewBusinessApplication._pGovRegDateBIR = ""
        cLoaderNewBusinessApplication._pGovBrgyClearance = ""
        cLoaderNewBusinessApplication._pGovRegDateBrgyClearance = ""
        cLoaderNewBusinessApplication._pBusBranch = ""
        cLoaderNewBusinessApplication._pBusDateEsta = ""
        cLoaderNewBusinessApplication._pBusTradeName = ""
        cLoaderNewBusinessApplication._pBusMale = ""
        cLoaderNewBusinessApplication._pBusFemale = ""
        cLoaderNewBusinessApplication._pBusTotal = ""
        cLoaderNewBusinessApplication._pBusResident = ""
        cLoaderNewBusinessApplication._pBusBrgy = ""
        cLoaderNewBusinessApplication._pBusStrt = ""
        cLoaderNewBusinessApplication._pBusAddress = ""
        cLoaderNewBusinessApplication._pOwnerFName = ""
        cLoaderNewBusinessApplication._pOwnerLName = ""
        cLoaderNewBusinessApplication._pOwnerMName = ""
        cLoaderNewBusinessApplication._pOwnerSuffix = ""
        cLoaderNewBusinessApplication._pOwnerGender = ""
        cLoaderNewBusinessApplication._pOwnerCitizenship = ""
        cLoaderNewBusinessApplication._pOwnerCheck = False
        cLoaderNewBusinessApplication._pOwnerAddress = ""
        cLoaderNewBusinessApplication._pOwnerTelNo = ""
        cLoaderNewBusinessApplication._pOwnerEmail = ""
        cLoaderNewBusinessApplication._pOwnerAltEmail = ""
        cLoaderNewBusinessApplication._pIncFName = ""
        cLoaderNewBusinessApplication._pIncMName = ""
        cLoaderNewBusinessApplication._pIncLName = ""
        cLoaderNewBusinessApplication._pIncAddress = ""
        cLoaderNewBusinessApplication._pIncAddTName = ""
        cLoaderNewBusinessApplication._pIncAddRName = ""
        cLoaderNewBusinessApplication._pIncAddPosition = ""

        Session("OwnershipType") = ""
        Session("Rent") = ""

        Session("LessorDateRented") = ""
        Session("LessorRatePerMonth") = ""
        Session("LessorFirstName") = ""
        Session("LessorLastName") = ""
        Session("LessorBarangay") = ""
        Session("LessorStreet") = ""
        Session("LessorAddress") = ""
        Session("LessorTelNo") = ""
        Session("LessorEmail") = ""
        Session("BuildingAdministrator") = ""

        Session("GovCDANo") = ""
        Session("GovRegDateCDA") = ""
        Session("GovDTINo") = ""
        Session("GovRegDateDTI") = ""
        Session("GovSECNo") = ""
        Session("GovRegDateSEC") = ""
        Session("GovTINNo") = ""
        Session("GovRegDateTIN") = ""
        Session("GovSSS") = ""
        Session("GovRegDateSSS") = ""
        Session("GovBrgyClearance") = ""
        Session("GovRegDateBrgyClearance") = ""
        Session("GovBIR") = ""
        Session("GovRegDateBIR") = ""

        Session("BusDateEsta") = ""
        Session("BusBranch") = ""
        Session("BusTradeName") = ""
        Session("BusMale") = ""
        Session("BusFemale") = ""
        Session("BusResident") = ""

        Session("BusBrgy") = ""
        Session("BusStrt") = ""
        Session("BusAddress") = ""

        Session("OwnerCheck") = ""
        Session("OwnerLName") = ""
        Session("OwnerFName") = ""
        Session("OwnerMName") = ""
        Session("OwnerSuffix") = ""
        Session("OwnerGender") = ""
        Session("OwnerCitizenship") = ""
        Session("OwnerAddress") = ""
        Session("OwnerTelNo") = ""
        Session("OwnerAltEmail") = ""


    End Sub

    Public Function _SendEmailNotif_Taxpayer() As Boolean
        _SendEmailNotif_Taxpayer = False
        Try
            Dim _nClass As New cDalSendEmail
            With _nClass
                ._pEmailTo = cSessionUser._pUserID
                ._pSubject = "BUSINESS PERMIT APPLICATION STATUS"
                ._pHeader = cSessionLGUProfile._pLGU_Name
                ._pBody = "Sir/Ma`am: <br/> " & _
                            "Attached herewith are the soft copies of Application form and Envelope Seal containing information of business being applied. <br/>" & _
                            "Download and print these attachments to be used as reference once the application has been approved. <br/> <br/> " & _
                            "Business Account Number " & cSessionLoader._pAccountNo & " is now for review and verification by Business Permit Licensing Officer. <br/> " & _
                            "Please wait for 1 working day for approval of application. <br/> <br/> " & _
                            "Thank you."

                ._pFooter = " Date Sent : " & Now.Date & _
                            "<br/> <br/>" & _
                            "THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."

                '' ===== GET FILE FROM TEMPORARY FOLDER AND ADD TO EMAIL ATTACHMENT

                Dim filepath As String = HttpContext.Current.Server.MapPath("~/Temp/")
                Dim _nFileName As String = cSessionLoader._pAccountNo & "_EnvelopeSeal.pdf"
                Dim _nFileName2 As String = cSessionLoader._pAccountNo & "_ApplicationForm.pdf"

                ._pAttachment.Add(filepath & _nFileName)
                ._pAttachment.Add(filepath & _nFileName2)
                '' ========================================================================

                If ._FnSendEmail() = True Then
                    '' DELETE Temporary file once email has been sent successfuly
                    File.Delete(filepath & _nFileName)
                    File.Delete(filepath & _nFileName2)
                    '' ====================================================================
                    Return True

                End If
            End With
        Catch ex As Exception
            '    cDalLogEvent._pSubLogError(ex)
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" & ex.Message & "');", True)
            Return False
        End Try


    End Function


    Protected Sub _oButton_Click(sender As Object, e As EventArgs) _
Handles _
        _oButtonTaxSave.Click

        _oPanel_Ask.Visible = False
        _nFnHide_PanelAsk()
        _mFnExitTrigger_False_AIF()
        _mFnExitTrigger_False()
        '_oButtonAdd.Text = "Yes"
        '_oButtonTaxSave.Text = "Saving" ' Added 20170831
        '_oButtonTaxSave.Enabled = False
        '_oTextBoxArea.CssClass = "input"
        '_oTextBoxCapital.CssClass = "input"
        '_oTextBoxGrossRec.CssClass = "input"

        Select Case True
            Case cPageSession_BusinessLine._pHeadingMode
                _mCheckInputedData()    ' @ Added 20170428
            Case cPageSession_BusinessLine._pOptionMode
                _mSubSaveSelectedValue() ' Edited 20170915 with _MCODE
            Case cPageSession_BusinessLine._pQtyMode
                _mCheckInputedData()    ' @ Added 20170503
        End Select

        If cPageSession_BusinessLine._pExit_BCODE = True Or _
            cPageSession_BusinessLine._pExit_MCODE = True Or _
            cPageSession_BusinessLine._pExit_GCODE = True Or _
            cPageSession_BusinessLine._pExit_SCODE = True Or _
            cPageSession_BusinessLine._pExit_FCODE = True Then
            _oPanel_Ask.Visible = True
            Exit Sub
        ElseIf cPageSession_BusinessLine._pExit_ELECCODE = True Or _
            cPageSession_BusinessLine._pExit_MECHCODE = True Or _
            cPageSession_BusinessLine._pExit_BLDGCODE = True Or _
            cPageSession_BusinessLine._pExit_SIGNCODE = True Or _
            cPageSession_BusinessLine._pExit_EPOCODE = True Or _
            cPageSession_BusinessLine._pExit_EIFCODE = True Or _
            cPageSession_BusinessLine._pExit_PLATECODE = True Then
            _oPanel_Ask.Visible = True
            Exit Sub
        Else
            '_nFnHide_PanelAsk()
            '_mSubBusLineUpdate()
            If cPageSession_BusinessLine._pELECCODE_processed = True And _
                 cPageSession_BusinessLine._pMECHCODE_processed = True And _
                  cPageSession_BusinessLine._pBLDGCODE_processed = True And _
                   cPageSession_BusinessLine._pSIGNCODE_processed = True And _
                    cPageSession_BusinessLine._pEPOCODE_processed = True And _
                     cPageSession_BusinessLine._pEIFCODE_processed = True And _
                      cPageSession_BusinessLine._pPLATECODE_processed = True And _
                      cPageSession_BusinessLine._pBCODE_processed = True And _
                      cPageSession_BusinessLine._pMCODE_processed = True And _
                      cPageSession_BusinessLine._pGCODE_processed = True And _
                      cPageSession_BusinessLine._pSCODE_processed = True And _
                      cPageSession_BusinessLine._pFCODE_processed = True Then
                _mSubBusLineUpdate()
                _mSubSaveGatheredInfo()
            Else
                _mFnContinueDataGather()
            End If
        End If

    End Sub
    Private Sub UpdateBusMastRemarks(_nRemarks As String)
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pSelect = "UPDATE BUSMAST Set REMARKS = ''" & _nRemarks & "''"
                ._pCondition = " Where AcctNo = ''" & cSessionLoader._pAccountNo & "''"
                ._pAction = "UPDATE"
                ._pExec(_nSuccessfull, _nErrMsg)

            End With

        Catch ex As Exception

        End Try



    End Sub
    Private Function _FnNotify_Taxpayer() As Boolean
        Try
            Dim _nClass As New cDalSendEmail
            With _nClass
                ._pEmailTo = cSessionUser._pUserID
                ._pSubject = "BUSINESS PERMIT APPLICATION STATUS"
                ._pHeader = cSessionLGUProfile._pLGU_Name
                ._pBody = "Sir/Ma`am: <br> " & _
                            "Your Business Account Number " & cSessionLoader._pAccountNo & " is now for review and verification by Business Permit Licensing Officer. <br>" & _
                            "Please wait for 1 working day for approval of application. <br>" & _
                            "Thank you. <br>"
                ._pFooter = "<br> Date Sent : " & Now.Date & _
                            "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."
                If ._pSubSendEmail() = True Then
                    Return True
                Else
                    Return False
                End If

            End With

        Catch ex As Exception
            Return False
        End Try


    End Function
    Private Function _FnNotify_BPLO()
        Try
            Dim _nClass As New cDalSendEmail
            With _nClass
                ._pEmailTo = "BPLO"
                ._pSubject = "Account Number: " & cSessionLoader._pAccountNo & " - Business Permit Application (NEW)"
                ._pHeader = cSessionLGUProfile._pLGU_Name
                ._pBody = "Sir/Ma`am: <br> " & _
                            "Business Account Number " & cSessionLoader._pAccountNo & " has been processed and is now ready for Assessment Review. <br>" & _
                            "Please review and verify the account to continue the online process. <br>" & _
                            "Thank you. <br>"

                ._pFooter = "<br> Date Sent : " & Now.Date & _
                            "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."
                If ._pSubSendEmail() = True Then
                    Return True
                Else
                    Return False
                End If

            End With

        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub _GenerateReport_EnvelopeSeal()
        Try
            Dim _nClass As New cDalEnvelopeSeal
            With _nClass

                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                cSessionLoader._pAccountNo = cSessionLoader._pAccountNo '"190521-00001"

                ._pSubSelect(, " WHERE ACCTNO = '" & cSessionLoader._pAccountNo & "'")

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


                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pReportEnvelopeSeal
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "ds_EnvelopeSeal"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim paramList As New List(Of ReportParameter)
                paramList.Add(New ReportParameter("LGUAddress", cSessionLGUProfile._pLGU_Address))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True

            End With


        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try

    End Sub
    Public Sub _GenerateReport_ApplicationForm()
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
                ._pForYear = cSessionLoader._pCurrentYear
                ._pLiveSvr = cSessionLoader._pBPLTAS_SvrName
                ._pLiveDb = cSessionLoader._pBPLTAS_DbName

                ._pExec(_nSuccessfull, _nErrMsg)

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


                'Dim exportOption1 As String = "Excel"
                'Dim exportOption2 As String = "Word"
                'Dim extension1 As RenderingExtension = _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption1, StringComparison.CurrentCultureIgnoreCase))
                'Dim extension2 As RenderingExtension = _oRpt_EnvelopeSeal.LocalReport.ListRenderingExtensions().ToList().Find(Function(x) x.Name.Equals(exportOption2, StringComparison.CurrentCultureIgnoreCase))
                'If extension1 IsNot Nothing And extension2 IsNot Nothing Then
                '    Dim fieldInfo As System.Reflection.FieldInfo = extension1.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
                '    fieldInfo.SetValue(extension1, False)
                '    Dim fieldInfo2 As System.Reflection.FieldInfo = extension2.GetType().GetField("m_isVisible", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
                '    fieldInfo2.SetValue(extension2, False)
                'End If

                _oRpt_EnvelopeSeal.LocalReport.ReportPath = _gResxRdlc.pReportApplicationInfo
                _oRpt_EnvelopeSeal.LocalReport.EnableExternalImages = True

                _oRpt_EnvelopeSeal.LocalReport.DataSources.Clear()
                Dim _nReportDataSource As New ReportDataSource
                _nReportDataSource.Name = "ds_Application"
                _nReportDataSource.Value = _nDataTable
                _oRpt_EnvelopeSeal.LocalReport.DataSources.Add(_nReportDataSource)

                Dim _TotalEmp As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_TOTAL") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_TOTAL"))
                Dim _NoEmpLGU As Integer = IIf(_nDataTable.Rows(0).Item("NO_EMP_LGU") = Nothing, 0, _nDataTable.Rows(0).Item("NO_EMP_LGU"))
                Dim paramList As New List(Of ReportParameter)

                Dim _nLGU_Name As String = cSessionLGUProfile._pLGU_Name
                Dim _nLGU_TelNo As String = cSessionLGUProfile._pLGU_TelNo
                Dim _nLGU_Website As String = cSessionLGUProfile._pLGU_Website

                paramList.Add(New ReportParameter("Param_LGU_Name", _nLGU_Name))
                paramList.Add(New ReportParameter("Param_LGU_TelNo", _nLGU_TelNo))
                paramList.Add(New ReportParameter("Param_LGU_Website", _nLGU_Website))


                paramList.Add(New ReportParameter("Status", cLoader_BPLTIMS._pSTATCODE))
                paramList.Add(New ReportParameter("Emp_Total", _TotalEmp))
                paramList.Add(New ReportParameter("Emp_LGU", _NoEmpLGU))
                _oRpt_EnvelopeSeal.LocalReport.SetParameters(paramList)

                _oRpt_EnvelopeSeal.AsyncRendering = True
                _oRpt_EnvelopeSeal.LocalReport.Refresh()
                _oRpt_EnvelopeSeal.Enabled = True

                '_RenderToPDF("ApplicationForm") ' <<<< Render Report to PDF and Save to temporary folder

            End With
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try
    End Sub

    Public Sub _RenderToPDF(_nDocName As String)

        'Dim warnings As Warning() = Nothing
        'Dim streamids As String() = Nothing
        'Dim mimeType As String = Nothing
        'Dim encoding As String = Nothing
        'Dim extension As String = Nothing
        'Dim bytes As Byte()
        'Dim _nFileName As String = cSessionLoader._pAccountNo & "_" & _nDocName & ".pdf"

        'bytes = _oRpt_EnvelopeSeal.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)

        'Dim FolderLocation As String = HttpContext.Current.Server.MapPath("~/Temp/")
        ''First delete existing file
        'Dim filepath As String = FolderLocation & _nFileName
        'File.Delete(filepath)
        ''Then create new pdf file
        'bytes = _oRpt_EnvelopeSeal.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamids, warnings)
        'Dim fs As New FileStream(FolderLocation & _nFileName, FileMode.Create)
        'fs.Write(bytes, 0, bytes.Length)
        'fs.Close()
        ''Set the appropriate ContentType.
        'Response.ContentType = "Application/pdf"
        ''Write the file directly to the HTTP output stream.
        'Response.WriteFile(filepath)
        'HttpContext.Current.ApplicationInstance.CompleteRequest()

    End Sub

    Public Sub _SendEmailWithAttachment(ByVal _nSenderEmail As String _
                                        , ByVal _nSenderPass As String _
                                        , ByVal _nSubject As String _
                                        , ByVal _nBody As String _
                                        , Optional ByVal AttachmentFiles As ArrayList = Nothing _
                                        , Optional _nBcc As String = Nothing _
                                        , Optional _nCc As String = Nothing)
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New  _
             Net.NetworkCredential(_nSenderEmail, _nSenderPass)
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New MailAddress(_nSenderEmail)
            mail.To.Add(cSessionUser._pUserID)
            mail.CC.Add(_nCc)
            mail.Bcc.Add(_nBcc)
            mail.Subject = _nSubject
            mail.Body = _nBody

            Dim i, iCnt As Integer

            If Not AttachmentFiles Is Nothing Then
                iCnt = AttachmentFiles.Count - 1
                For i = 0 To iCnt
                    Dim data As Attachment = New Attachment(AttachmentFiles(i))
                    mail.Attachments.Add(data)
                    'If FileExists(AttachmentFiles(i)) Then _
                    'mail.Attachments.Add(AttachmentFiles(i))
                Next
            End If
            SmtpServer.Send(mail)
            '  MsgBox("mail sent")
        Catch ex As Exception
            cDalLogEvent._pSubLogError(ex)
        End Try
    End Sub

    Private Function FileExists(ByVal FileFullPath As String) _
     As Boolean
        If Trim(FileFullPath) = "" Then Return False

        Dim f As New IO.FileInfo(FileFullPath)
        Return f.Exists

    End Function

    '   Public Sub SendMailMultipleAttachments(ByVal From As String, _
    'ByVal sendTo As String, ByVal Subject As String, _
    'ByVal Body As String, _
    'Optional ByVal AttachmentFiles As ArrayList = Nothing, _
    'Optional ByVal CC As String = "", _
    'Optional ByVal BCC As String = "", _
    'Optional ByVal SMTPServer As String = "")

    '       Dim myMessage As MailMessage
    '       Dim i, iCnt As Integer

    '       Try

    '           myMessage.To = sendTo
    '           myMessage.From = From
    '           myMessage.Subject = Subject
    '           myMessage.Body = Body
    '           myMessage.BodyFormat = MailFormat.Text
    '           'CAN USER MAILFORMAT.HTML if you prefer

    '           If CC <> "" Then .CC = CC
    '           If BCC <> "" Then .Bcc = ""

    '           If Not AttachmentFiles Is Nothing Then
    '               iCnt = AttachmentFiles.Count - 1
    '               For i = 0 To iCnt
    '                   If FileExists(AttachmentFiles(i)) Then _
    '                     myMessage.Attachments.Add(AttachmentFiles(i))
    '               Next

    '           End If

    '           If SMTPServer <> "" Then _
    '             SmtpMail.SmtpServer = SMTPServer
    '           SmtpMail.Send(myMessage)


    '       Catch myexp As Exception
    '           Throw myexp
    '       End Try
    '   End Sub

End Class