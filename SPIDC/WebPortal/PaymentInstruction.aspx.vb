Public Class PaymentInstruction
    Inherits System.Web.UI.Page
    Public Shared TransactionType As String = Nothing
    Public Shared Amt As String = Nothing
    Public Shared Desc As String = Nothing
    Public Shared TDN As String = Nothing
    Public Shared OID As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        td_Amount.InnerText = Amt
        td_AssessmentNo.InnerText = TDN
        td_Description.InnerText = Desc
        td_OnlineID.InnerText = OID
        td_TransactionType.InnerText = TransactionType

        Dim url = "https://epaymentportal.landbank.com/pay1.php?code=c240SFQlMkJyZzV2TzlldlppaEJ3bmF2VTlUTUVtS0h2c2x6Z2s2c3JISVBNPQ=="
        Dim s As String = "window.open('" & url & "', '_blank');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertscript", s, True)

    End Sub

End Class