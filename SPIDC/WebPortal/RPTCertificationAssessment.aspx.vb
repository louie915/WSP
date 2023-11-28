Imports System.Web.Services

Public Class RPTCertificationAssessment
    Inherits System.Web.UI.Page
    Public Shared certName As String
    Public Shared certAmt As String
    Public Shared certCode As String
    Public Shared certTag As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _oLabelAccountCode.InnerText = certCode
        _oLabelAccountDesc.InnerText = certName
        _oLabelAmount.InnerText = certAmt
        _oLabelTotalAmount.InnerText = "Total Amount: " & certAmt

    End Sub

    Protected ReadOnly Property _pAmount As String
        Get
            Return _oLabelAmount.InnerText
        End Get
    End Property

    Private Sub _oBtnProceedtoPayment_ServerClick(sender As Object, e As EventArgs) Handles _oBtnProceedtoPayment.ServerClick
        Try
            Dim _nClass As New cDalCertificationAss
            Dim delfee As String = Nothing
            Dim totAmt As String = Nothing

            If checkedDelFee.Value = "true" Then
                delfee = 250
                totAmt = totAmount.Value - delfee
            Else
                delfee = 0
                totAmt = totAmount.Value
            End If

            If certTag = "RPT" Then
                cDalCertificationAss._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS

                cDalCertificationAss._pEmail = cSessionUser._pUserID
                cDalCertificationAss._pTDN = cSessionLoader._pTDN
                cDalCertificationAss._pOwner = cSessionLoader._pRPTOwnerName
                cDalCertificationAss._pCertType = certCode
                cDalCertificationAss._pNoOfCopies = Val(noOfCop.Value)
                cDalCertificationAss._pAmount = totAmt
                cDalCertificationAss._pDelFee = delfee

                cSessionLoader._pType = _oLabelAccountDesc.InnerText
                cSessionLoader._pService = "1CertRPT"
                cSessionLoader._pUniqueID = cSessionLoader._pTDN
                cSessionLoader._pTotalAmountDue = CDbl(totAmt) + CDbl(delfee)
                Response.Redirect("Paynow.aspx")

            ElseIf certTag = "BP" Then
                Dim owner As String = Nothing

                cDalCertificationAss._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

                'get Business Owner
                owner = cDalCertificationAss.getBusinessOwner(cSessionLoader._pAccountNo)

                cDalCertificationAss._pEmail = cSessionUser._pUserID
                cDalCertificationAss._pBIN = cSessionLoader._pAccountNo
                cDalCertificationAss._pOwner = owner
                cDalCertificationAss._pCertType = certCode
                cDalCertificationAss._pNoOfCopies = Val(noOfCop.Value)
                cDalCertificationAss._pAmount = totAmt
                cDalCertificationAss._pDelFee = delfee

                cSessionLoader._pType = _oLabelAccountDesc.InnerText
                cSessionLoader._pService = "1CertBP"
                cSessionLoader._pUniqueID = cSessionLoader._pTDN
                cSessionLoader._pTotalAmountDue = CDbl(totAmt) + CDbl(delfee)
                Response.Redirect("Paynow.aspx")
            End If

            _oLabelTotalAmount.InnerText = "Total Amount: " & String.Format("{0:n}", totAmount.Value)
        Catch ex As Exception

        End Try
    End Sub
End Class