Imports System.Threading

Public Class CBP_ViewApplicationStatus
    Inherits System.Web.UI.Page
    Dim _nMachineName As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Try
                If Not IsPostBack Then

                    cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR
            
                    'Response.Write("<script>alert('Postback false')</script>")
                    Dim cbp_transaction_number As String = Request.QueryString("cbp_transaction_number")
                    'Response.Write("<script>alert('" & Request.QueryString("cbp_transaction_number") & "')</script>")
                    Dim business_account_number As String = Request.QueryString("business_account_number")
                    ' Response.Write("<script>alert('" & Request.QueryString("business_account_number") & "')</script>")
                    Dim email_address As String = Request.QueryString("email_address")
                    'Response.Write("<script>alert('" & Request.QueryString("email_address") & "')</script>")
                    Dim strBuilder As String = Nothing

                    Dim _nSuccess As Boolean
                    Dim _nErrMsg As String = Nothing
                    '_DisplayCBPAppStat()
                    Dim _nRowCount As Integer = 0
                    cInit_CBPReg._DisplayCBPAppStat(cbp_transaction_number, business_account_number, email_address, strBuilder, _nSuccess, _nErrMsg, _nRowCount)
                    'If _nSuccess = False Then
                    '    Response.Write("<script>alert('" & _nErrMsg & "')</script>")
                    'End If
                    'Response.Write("<script>alert('" & cGlobalConnections._pStrCxn_CR.ToString & "')</script>")

                    'Response.Write("<script>alert('" & cGlobalConnections._pStrCxn_BPLTIMS.ToString & "')</script>")
                    'Response.Write("<script>alert('" & cGlobalConnections._pStrCxn_BPLTAS.ToString & "')</script>")
                    'Response.Write("<script>alert('" & cGlobalConnections._pStrCxn_OAIMS.ToString & "')</script>")


                    'Response.Write("<script>alert('" & _nRowCount.ToString & "')</script>")

                    'Response.Write("<script>alert('cInit_CBPReg._DisplayCBPAppStat')</script>")
                    Response.Write(strBuilder)
                    'Response.Write("<script>alert('strBuilder')</script>")
                    'Response.Write("<script>alert('" & strBuilder & "')</script>")

                    HttpContext.Current.ApplicationInstance.CompleteRequest()  'instead of Response.[End]()
                    'Response.Write("<script>alert('CompleteRequest')</script>")

                    cLoader_CBPAuthRep._pIsRegOAIMS = True
                    cLoader_CBPAuthRep._pemail_address = Request.QueryString("email_address")

                Else

                End If
            Catch ex As ThreadAbortException
                cEventLog._pSubLogError(ex)
            End Try
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try

    End Sub

End Class