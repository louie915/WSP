Imports System.Data
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Security

Public Class RPTIMSPayment
    Inherits System.Web.UI.Page

    Dim merchantid As String
    Dim txnid As String
    Public amount As Double
    Dim paymentswitchurl As String
    Dim description As String
    Dim email As String
    Dim procid As String
    Dim ccy As String
    Dim checking As String
    Dim ctr As String
    Dim message As String
    Dim digest As String
    Dim redirectString As String
    Dim merchantpwd As String
    Dim random As New Random

    Public transactionKey As String
    Public terminalID As String
    Public referenceCode As String
    Public serviceType As String
    Public securityToken As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not IsPostBack Then

                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("//Login.aspx")
                End If

                Dim _nclass As New cDalPayment
                _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
                _nclass._pSubGetRPTpaymentDetails()

                _oTextBoxAssessmentNumber.Value = cSessionLoader._pAssessmentNo
                _oTextBoxAmount.Value = cSessionLoader._pRPTtotal
            Else
                subPayNow()
            End If


        Catch ex As Exception

        End Try

    End Sub


    Sub subPayNow()
        Select Case SelectedService.Value

            Case "DBP"
                Dim _nclass As New cDalPayment
                Dim mytext As String = _oTextBoxAssessmentNumber.Value
                Dim myChars() As Char = mytext.ToCharArray()
                Dim AssessmentNo As String = cSessionLoader._pAssessmentNo

                For Each ch As Char In myChars
                    If Char.IsDigit(ch) Then
                        referenceCode = referenceCode & ch
                    End If
                Next

                _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nclass._pSubGetAutoPaymentRefNo()
                referenceCode = "RPT" & _nclass._pReferenceNumber
                transactionKey = "{b845acffc21949ba98f23a19d90a8cc53a5e5c0e}"
                terminalID = "92"
                securityToken = getSHA1Hash(terminalID & referenceCode & transactionKey)
                Dim qs As String = "?terminalID=" + terminalID + "&referenceCode=" + referenceCode + "&amount=" + Replace(cSessionLoader._pRPTtotal, ",", "") + "&securityToken=" + securityToken

                _nclass._pSubInsertPaymentRefNo(referenceCode, cSessionUser._pUserID, SelectedService.Value, cSessionLoader._pAssessmentNo, "RPT")

                Response.Redirect("rpt_DBPPayment.aspx" + qs)
        End Select
    End Sub

    Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function

    Private Sub btnPayNow_ServerClick(sender As Object, e As EventArgs)
        subPayNow()
    End Sub
End Class