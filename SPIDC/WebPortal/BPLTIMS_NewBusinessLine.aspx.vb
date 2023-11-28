Imports System.Data.SqlClient

Public Class BPLTIMS_NewBusinessLine
    Inherits System.Web.UI.Page
    Dim gridAction As String
    Dim gridBusinessID As String
    Dim _nBusCount As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            _LoadBusinessInfo()
            _BindCategory()
            _BindBussinessDetails()
        Else
            gridAction = Request("__EVENTTARGET")
            gridBusinessID = Request("__EVENTARGUMENT")
            If gridAction = "Remove" Then
                Dim _nSuccessful As Boolean
                Dim _nErrMsg As String = ""
                _RemoveBusinessDetails()

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
    'Private Sub Get_CATCODE()
    '    Try
    '        '----------------------------------
    '        _oDDL_Category.DataSourceID = Nothing
    '        Dim _nClass As New cDalBusinessLine_Tomi
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
    '        _nClass._pGetBusLine = "CATCODE"
    '        _nClass._pSubSelect("WHERE Description like '%" & _oTxtSearchBusLine.Text & "%'")

    '        Dim _nDataSet As New DataSet()
    '        _nDataSet = _nClass._pDataSet

    '        Try

    '            _oDDL_Category.DataSource = _nDataSet
    '            _oDDL_Category.DataTextField = "DESCRIPTION"
    '            'cmbBusCode.DataValueField = "CATEGORY_BUSCODE"
    '            _oDDL_Category.DataValueField = "CATEGORY_BUSCODE"
    '            _oDDL_Category.DataBind()

    '            _oDDL_Category.Items.Insert(0, New ListItem("Select Category", ""))

    '            '----------------------------------
    '        Catch ex As Exception
    '            'Shoiw Blank Table
    '            '  _mSubShowBlank()
    '        End Try
    '        '----------------------------------
    '    Catch ex As Exception
    '    End Try

    'End Sub

    Private Sub _LoadBusinessInfo()
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT ACCTNO,COMMNAME FROM BUSMAST "
                ._pCondition = " Where AcctNo = ''" & cSessionLoader._pAccountNo & "''"
                ._pExec(_nSuccessfull, _nErrMsg)


                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    _oLabelAcctNo.InnerText = _nDataTable.Rows("0").Item("ACCTNO").ToString
                    _oLabelBussinessName.InnerText = _nDataTable.Rows("0").Item("COMMNAME").ToString
                End If
            End With



        Catch ex As Exception

        End Try



    End Sub

    Public Sub _BindCategory()
        Try
            'cGlobalConnections._pSqlCxn_BPLTAS

            Dim _nSqlStr As String
            Dim _mDatatableBrgy As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT CATCODE, CATDESC FROM CATCODE ORDER BY CATDESC "
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableBrgy)


            Try
                '----------------------------------
                _oDDL_Category.DataSource = _mDatatableBrgy
                _oDDL_Category.DataTextField = "CATDESC"
                _oDDL_Category.DataValueField = "CATCODE"

                _oDDL_Category.DataBind()
                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub


    Public Function _Fn_CountRec(_Select As String, _nCondition As String) As Integer

        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = _Select
                ._pCondition = _nCondition

                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = True Then

                    Dim _nDataTable As New DataTable
                    _nDataTable = ._pDataTable

                    Try
                        '----------------------------------
                        If _nDataTable.HasErrors Then
                            Return 0
                            'Griderr = True
                            '_mSubShowBlank()
                        End If

                        Return _nDataTable.Rows.Count


                        '----------------------------------
                    Catch ex As Exception
                        Return 0
                    End Try

                End If

            End With
        Catch ex As Exception

        End Try
    End Function
    Public Sub _BindBussinessDetails()
        Try

            Dim _nGridView As New GridView

            _nGridView = _oGridViewBusinessDetailsNew
            _nGridView.DataSourceID = Nothing


            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog


            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT Acctno, ForYear, BusinessId, CatCode " & _
                            ",(SELECT CATDESC from [" & _nLiveSvr & "].[" & _nLiveDB & "].dbo.[CATCODE]  WHERE CatCode = BDN.CatCode) Category " & _
                            " , ProductsServices, Capital, Area, Vehicles, Capacity, Asset " & _
                            " FROM BusinessDetailsNew BDN "
                ._pCondition = " WHERE BDN.ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND BDN.FORYEAR = YEAR(GETDATE()) "

                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = True Then

                    Dim _nDataTable As New DataTable
                    _nDataTable = ._pDataTable

                    Try
                        '----------------------------------
                        If _nDataTable.HasErrors Then
                            _nBusCount = 0
                            'Griderr = True
                            '_mSubShowBlank()
                        End If

                        _nBusCount = _nDataTable.Rows.Count

                        If _nDataTable.Rows.Count > 0 Then
                            _nGridView.DataSource = _nDataTable
                            _nGridView.DataBind()
                        Else
                            cEmptyGridview.pEmpyGridViewWithHeader(_nGridView, _nDataTable, "-- NO RECORD AVAILABLE --")
                        End If
                        '----------------------------------
                    Catch ex As Exception
                        'GridErr = True
                        '_mSubShowBlank()
                    End Try

                End If

            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _PassValueToSession()
        'cLoader_BusinessDetailsNew._pCatCode = _oDDL_Category.InnerText.ToString
        cLoader_BusinessDetailsNew._pCatCode = _oDDL_Category.Value.ToString
        cLoader_BusinessDetailsNew._pProductsServices = Request.Form("_otxt_ProdSrvcs")
        cLoader_BusinessDetailsNew._pArea = Request.Form("_oTxt_Area")
        cLoader_BusinessDetailsNew._pCapital = Request.Form("_otxt_Capital").Replace(",", "")

    End Sub

    Public Sub _SaveBusinessDetails()
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO  BusinessDetailsNew " & _
                            " (Acctno, ForYear, BusinessId, CatCode, ProductsServices, Capital, Area) " & _
                           " VALUES (''" & cLoader_BPLTIMS._pACCTNO & "'',YEAR(GETDATE()),  FORMAT(getdate(), ''yyyyMMddhhmmssfff'') , ''" & cLoader_BusinessDetailsNew._pCatCode & "'', ''" & cLoader_BusinessDetailsNew._pProductsServices & "'', ''" & cLoader_BusinessDetailsNew._pCapital & "'', ''" & cLoader_BusinessDetailsNew._pArea & "'') "
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = True Then

                    _BindBussinessDetails()
                    snackbar("green", "Saved Successful!")
                End If

            End With


        Catch ex As Exception

        End Try
    End Sub

    Private Sub _BtnSave(sender As Object, e As EventArgs) Handles _oBtnSave.ServerClick
        Try


            _PassValueToSession()
            If _Fn_CountRec("SELECT BusinessId FROM BusinessDetailsNew ", " WHERE ACCTNO = ''" & cLoader_BPLTIMS._pACCTNO & "'' AND FORYEAR = YEAR(GETDATE()) AND CatCode = ''" & cLoader_BusinessDetailsNew._pCatCode & "'' ") <> 0 Then
                snackbar("red", "Category already exists!")
                Exit Sub
            End If
            _SaveBusinessDetails()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub _BtnSubmit(sender As Object, e As EventArgs) Handles _oBtnSubmit.ServerClick
        Try
            If _Fn_CountRec("SELECT BusinessId FROM BusinessDetailsNew ", " WHERE ACCTNO = ''" & cLoader_BPLTIMS._pACCTNO & "'' AND FORYEAR = YEAR(GETDATE())") = 0 Then
                snackbar("red", "Please declare at least 1 business details.")
                Exit Sub
            End If
            If _Fn_SendEmailNotification() = True Then
                _SaveToHistoryTransaction()
                email_success()

                ' @added 20211108 Louie
                ' @added 20211108 Louie
                If cLoader_CBPAuthRep._pIsFromCBP = True And cLoader_CBPAuthRep._pIsRegOAIMS = True Then

                    Dim status_code As String = "SUBMITTED-BUSINESS-PERMIT-APPLICATION" ' << Set Status code.
                    'cLoader_CBPAuthRep._pBearerToken = cInit_CBPReg._FnGetBearerToken ' << Generate Token Bearer for update trasaction to CBP API.
                    cInit_CBPReg.UpdateCBPAppStatus(status_code, "New", cInit_CBPReg._Fn_GetBUSMASTAppDate) ' << Update status of application to CBP API.
                    cInit_CBPReg._InsertAppStatLog(status_code) '<< Log Transaction status to WSP.
                    cInit_CBPReg._SetBusMastCBPTransNo()
                End If

                Response.Redirect("NotificationPages/ApplicationSuccess.aspx", False)
                Exit Sub
            Else
                Response.Write("<script>alert('Failed to Send Email notification. Please check your internet connection and try again.');</script>")
            End If

         
        Catch ex As Exception

        End Try
    End Sub

    Private Function _Fn_SendEmailNotification() As Boolean

        Dim Sent As Boolean
        Dim Subject As String = "New Business Application"
        Dim Body As String = "Sir/Ma`am: <br/> " & _
                        "Your Temporary Account Number: [" & cSessionLoader._pAccountNo & "] is now for review and verification by Business Permit Licensing Officer. <br/> " & _
                        "Further instructions will be sent thru email once the application has been reviewed. <br/> <br/> " & _
                        "Thank you."

        Try
            cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)

            If Sent = False Then
                Return False
            ElseIf Sent = True Then
                Return True
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub _SaveToHistoryTransaction()
        Dim _nClass3 As New cDalTransactionHistory

        Dim Particulars As String
        Dim Full As String = cLoader_BPLTIMS._pFIRST_NAME & " " & cLoader_BPLTIMS._pMIDDLE_NAME & " " & cLoader_BPLTIMS._pLAST_NAME

        Particulars = "Business Name=" & cLoader_BPLTIMS._pCOMMNAME & ";" _
                    & "Ownership Type=" & cLoader_BPLTIMS._pOWNCODE & ";" _
                    & "Owner Name=" & Full & ";"

        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

        _nClass3._pSubInsertHistory(cSessionLoader._pAccountNo, _
                                    cSessionUser._pUserID, _
                                    "Business Permit", _
                                    "Application", _
                                    "New Business Application", _
                                    Particulars, _
                                    "For Review")

    End Sub
    Public Sub _UpdateBusinessDetails()
        Try

            _BindBussinessDetails()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _RemoveBusinessDetails()
        Try

            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BusinessDetailsNew "
                ._pCondition = " WHERE ACCTNO = ''" & cSessionLoader._pAccountNo & "'' AND FORYEAR = YEAR(GETDATE()) AND BusinessId = ''" & gridBusinessID & "''"
                ._pExec(_nSuccess, _nErrMsg)

                If _nSuccess = True Then

                    _BindBussinessDetails()
                    snackbar("green", "Removed Successful!")
                End If

            End With




        Catch ex As Exception

        End Try
    End Sub

    Public Sub _EditBusinessDetails()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub UpdateBusMastRemarks(_nRemarks As String)
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BUSMAST Set REMARKS = ''" & _nRemarks & "''"
                ._pCondition = " Where AcctNo = ''" & cSessionLoader._pAccountNo & "''"
                ._pExec(_nSuccessfull, _nErrMsg)
            End With

        Catch ex As Exception

        End Try



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

End Class