Public Class AccountInformation
    Inherits System.Web.UI.Page
    Dim _nIsNewBusiness As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            'cSessionLoader._pAccountNo pang call ng naselect na account no.
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pAcctNo = cSessionLoader._pAccountNo

            Dim _nClBP1 As New cDalGlobalConnectionsDefault
            _nClBP1._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP1._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP1._pSubRecordSelectSpecific()

            _nClass._pSubGetInformation()
            _oTxtFirstName.Value = _nClass._nFirstName
            _oTxtMiddleName.Value = _nClass._nMidName
            _oTxtLastName.Value = _nClass._nLastName
            _oTxtOwnerAddress.Value = _nClass._nOwnerAdd
            _oTxtBarangay1.Value = _nClass._nBrgy
            _oTxtCommercialName.Value = _nClass._nCommName
            _oTxtCommercialAddress.Value = _nClass._nCommAdd
            _oTxtBarangay2.Value = _nClass._nBrgy
            _oTxtMobileNumber.Value = _nClass._nCpNo
            _oTxtTelNumber.Value = _nClass._nTelNo
            _oTxtEmailAddress.Value = _nClass._nEmailNo

            _mSubCheckIfNewBusiness()


            If _nIsNewBusiness = "1" Then
                Dim _nClass1 As New cDalBPSOS
                _nClass1._pAcctNo = cSessionLoader._pAccountNo
                _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS


                _nClass1._pLocServer = _nClBP1._pDBDataSource
                _nClass1._pLocDB = _nClBP1._pDBInitialCatalog

                _nClass1._pSubGetInformationNew()

                _oTxtFirstName.Value = _nClass1._nFirstName
                _oTxtMiddleName.Value = _nClass1._nMidName
                _oTxtLastName.Value = _nClass1._nLastName
                _oTxtOwnerAddress.Value = _nClass1._nOwnerAdd
                _oTxtBarangay1.Value = _nClass1._nBrgy
                _oTxtCommercialName.Value = _nClass1._nCommName
                _oTxtCommercialAddress.Value = _nClass1._nCommAdd
                _oTxtBarangay2.Value = _nClass1._nBrgy
                _oTxtMobileNumber.Value = _nClass1._nCpNo
                _oTxtTelNumber.Value = _nClass1._nTelNo
                _oTxtEmailAddress.Value = _nClass1._nEmailNo

            End If




            _nClass._pSubSelectPaymentInquiry()
            ' GridView1.AutoGenerateColumns = True
            GridView2.DataSource = _nClass._mDataTable
            GridView2.DataBind()


            Dim _nClass2 As New cDalBPSOS
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass2._pAcctNo = cSessionLoader._pAccountNo

            _nClass2._pLocServer = _nClBP1._pDBDataSource
            _nClass2._pLocDB = _nClBP1._pDBInitialCatalog

            _nClass2._pSubGetDetail()
            If _nIsNewBusiness = "1" Then
                _nClass2._pSubGetDetailNewBusiness()

            End If
            _oLblBusID.Text = cSessionLoader._pAccountNo
            _oLblBusOwner.Text = _nClass2._nOwner
            _oLblBusName.Text = _nClass2._nBusName
            _oLblBusAddress.Text = _nClass2._nBusAddress
            _oLblBusCategory.Text = _nClass2._nBusCategory
         
            ' GridView1.AutoGenerateColumns = True
            'GridView1.DataSource = _nClass1._mDataTable
            'GridView1.DataBind()

        End If
    End Sub

    Private Sub _obtnPrintInformation_ServerClick(sender As Object, e As EventArgs) Handles _obtnPrint.ServerClick
        Try

            '' Display report in New Tab
            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=BPINFO" + "&AcctNo=" + cSessionLoader._pAccountNo + "','_blank');</script>")

           Catch ex As Exception

        End Try

    End Sub

    Private Sub _mSubCheckIfNewBusiness()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS


            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblASKHDG = "tempASKHDG_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblQTY = "tempASKQTY_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pnTempTblOPT = "tempASKOPTION_" & cSessionUser._pUserID.Replace(".", "")

            _nClass._pForYear = Year(Now)
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            '  _nClass._pQtr 
            _nIsNewBusiness = "0"
            _nClass._pSubCheckNewBusiness()
            _nIsNewBusiness = _nClass._nOutput

        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

End Class