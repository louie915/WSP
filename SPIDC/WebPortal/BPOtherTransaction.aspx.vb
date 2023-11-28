Public Class BPOtherTransaction
    Inherits System.Web.UI.Page
    Dim certName As String
    Dim certCode As String
    Dim certAmt As String
    Dim certTag As String
    Dim _nIsNewBusiness As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then


            Dim _nClass2 As New cDalBPSOS
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass2._pAcctNo = cSessionLoader._pAccountNo

            Dim _nClBP1 As New cDalGlobalConnectionsDefault
            _nClBP1._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP1._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP1._pSubRecordSelectSpecific()
            _nClass2._pLocServer = _nClBP1._pDBDataSource
            _nClass2._pLocDB = _nClBP1._pDBInitialCatalog

            _nClass2._pSubGetDetail()
            _mSubCheckIfNewBusiness()
            If _nIsNewBusiness = "1" Then
                _nClass2._pSubGetDetailNewBusiness()

            End If

            _oLblBusID.Text = cSessionLoader._pAccountNo
            _oLblBusOwner.Text = _nClass2._nOwner
            _oLblBusName.Text = _nClass2._nBusName
            _oLblBusAddress.Text = _nClass2._nBusAddress
            _oLblBusCategory.Text = _nClass2._nBusCategory
            _oLblBusCategory1.Text = _nClass2._nBusCategory1
        End If


    End Sub

    Private Sub _oBtnNext_ServerClick(sender As Object, e As EventArgs) Handles _oBtnNext.ServerClick
        If radioValue.Value = "CertificateofDelinquency" Then
            certName = "Certificate of Delinquency"
            certAmt = "100.00"
            certCode = "0001"
            certTag = "BP"
            RPTCertificationAssessment.certTag = certTag
            RPTCertificationAssessment.certAmt = certAmt
            RPTCertificationAssessment.certCode = certCode
            RPTCertificationAssessment.certName = certName
            Response.Redirect("RPTCertificationAssessment.aspx")
        ElseIf radioValue.Value = "CertificateOfTransferOfOwnership" Then
            certName = "Certificate of Transfer of Ownership"
            certAmt = "270.00"
            certCode = "0002"
            certTag = "BP"
            RPTCertificationAssessment.certAmt = certAmt
            RPTCertificationAssessment.certCode = certCode
            RPTCertificationAssessment.certName = certName
            RPTCertificationAssessment.certTag = certTag
            Response.Redirect("RPTCertificationAssessment.aspx")
        ElseIf radioValue.Value = "CertificateOfExistingRecords" Then
            certName = "Certificate Of Existing Records"
            certAmt = "120.00"
            certCode = "0003"
            certTag = "BP"
            RPTCertificationAssessment.certAmt = certAmt
            RPTCertificationAssessment.certCode = certCode
            RPTCertificationAssessment.certName = certName
            RPTCertificationAssessment.certTag = certTag
            Response.Redirect("RPTCertificationAssessment.aspx")
        ElseIf radioValue.Value = "RPTOTC.aspx" Then
            Response.Redirect("RPTOTC.aspx")

        ElseIf radioValue.Value = Nothing Then
            Response.Write("<script>alert('Please select a transaction.')</script>")
        Else
            cSessionLoader._pService = radioValue.Value
            Response.Redirect("AppointmentBP.aspx")
        End If
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