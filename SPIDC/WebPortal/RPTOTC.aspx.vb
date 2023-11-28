Imports System.Web.UI
Imports System.ComponentModel

Public Class RPTOTC
    Inherits System.Web.UI.Page
    Dim paymentChannel As String
    Dim transactionNumber As String
    Dim amtPaid As String
    Dim oRno As String
    Dim _nMsg As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub _oBtnSubmit_ServerClick(sender As Object, e As EventArgs) Handles _oBtnSubmit.ServerClick
        Try
            paymentChannel = _oSelectPaymentChannel.Value
            transactionNumber = _oTextTransNo.Value
            amtPaid = _oTextAmount.Value
            oRno = _oTextOR.Value

            If paymentChannel = "Please select a payment channel" Then
                _nMsg = "Choose a payment channel"
                snackbar("red", _nMsg)
                Exit Sub
            ElseIf transactionNumber = "" Then
                _nMsg = "Please enter transaction number"
                snackbar("red", _nMsg)
                Exit Sub
            ElseIf amtPaid = "" Then
                _nMsg = "Please enter amount"
                snackbar("red", _nMsg)
                Exit Sub
            ElseIf oRno = "" Then
                _nMsg = "Please enter Official Receipt Number"
                snackbar("red", _nMsg)
                Exit Sub
            End If

            _nSaveOTC()
            sendOTCMail()

            _oSelectPaymentChannel.Value = ""
            _oTextAmount.Value = ""
            _oTextOR.Value = ""
            _oTextTransNo.Value = ""

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

    Public Sub _nSaveOTC()
        Dim _nClass As New cDalOTC

        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS

        _nClass._pPaymentChannel = paymentChannel
        _nClass._pTransactionNo = transactionNumber
        _nClass._pAmount = amtPaid
        _nClass._pOrNumber = oRno

        If _nClass.checkTransOTC = True Then
            _nMsg = "Transaction Number Already Exists"
            snackbar("red", _nMsg)
        Else
            _nClass.saveOTC()
            _nMsg = "Entry successfully saved. Please check your email."
            snackbar("green", _nMsg)
        End If

    End Sub

    Public Sub sendOTCMail()
        Try
            Dim _nClass As New cDalSendEmail
            Dim _nClass1 As New cDalOTC

            _nClass._pEmailTo = cSessionUser._pUserID
            _nClass._pSubject = "Payment Made Over-The-Counter"
            _nClass._pBody = "Dear Valued Tax Payer," & vbNewLine + vbNewLine & "Thank you for paying your dues!" & vbNewLine + vbNewLine & "" & _
                "This confirms your bill payment transaction with the following details:" & vbNewLine & "" & _
                "Payment Channel: " & _nClass1._pPaymentChannel + vbNewLine & "" & _
                "Transaction Number: " & _nClass1._pTransactionNo + vbNewLine & "" & _
                "Amount Paid: " & _nClass1._pAmount + vbNewLine & "" & _
                "Official Receipt Number: " & _nClass1._pOrNumber + vbNewLine + vbNewLine & "" & _
                "Thank you for choosing online transaction. Have a wonderful day!"

            _nClass._pSubSendEmail()
        Catch ex As Exception

        End Try
    End Sub
End Class