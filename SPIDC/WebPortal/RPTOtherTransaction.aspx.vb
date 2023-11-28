Public Class RPTOtherTransaction
    Inherits System.Web.UI.Page
    Dim certName As String
    Dim certCode As String
    Dim certAmt As String
    Dim certTag As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            _oLblTDN.Text = cSessionLoader._pTDN
            _oLblPIN.Text = cSessionLoader._pRPTPIN
            _oLblKind.Text = cSessionLoader._pRPTKIND
            _oLblOwner.Text = cSessionLoader._pRPTOWNERNAME
            _oLblLocation.Text = cSessionLoader._pRPTLocation
        Else
          


        End If
      
    End Sub

    Private Sub _oBtnNext_ServerClick(sender As Object, e As EventArgs) Handles _oBtnNext.ServerClick
        Dim output As String
        output = radioValue.Value

        If output = "RPTOTC.aspx" Then
            Response.Redirect("RPTOTC.aspx")
        ElseIf output = "CertifiedTrueCopy" Then
            certName = "Certified True Copy"
            certAmt = "100.00"
            certCode = "0001"
            certTag = "RPT"
            RPTCertificationAssessment.certAmt = certAmt
            RPTCertificationAssessment.certCode = certCode
            RPTCertificationAssessment.certName = certName
            RPTCertificationAssessment.certTag = certTag
            Response.Redirect("RPTCertificationAssessment.aspx")
        ElseIf output = "CertificateOfLandHoldings" Then
            certName = "Certificate Of Land Holdings"
            certAmt = "200.00"
            certCode = "0002"
            certTag = "RPT"
            RPTCertificationAssessment.certAmt = certAmt
            RPTCertificationAssessment.certCode = certCode
            RPTCertificationAssessment.certName = certName
            RPTCertificationAssessment.certTag = certTag
            Response.Redirect("RPTCertificationAssessment.aspx")
        ElseIf output = "CertificateOfNoImprovement" Then
            certName = "Certificate of No Improvement"
            certAmt = "150.00"
            certCode = "0003"
            certTag = "RPT"
            RPTCertificationAssessment.certAmt = certAmt
            RPTCertificationAssessment.certCode = certCode
            RPTCertificationAssessment.certName = certName
            RPTCertificationAssessment.certTag = certTag
            Response.Redirect("RPTCertificationAssessment.aspx")

        ElseIf output = Nothing Then
            Response.Write("<script>alert('Please select a transaction.')</script>")

        Else
            cSessionLoader._pService = output
            Response.Redirect("Appointment.aspx")
        End If
    End Sub
End Class