Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Net.Mail
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class SendEmailWithAttachment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub SendEmail(sender As Object, e As EventArgs)
        Try
            Using mm As New MailMessage(txtEmail.Text, txtTo.Text)
                mm.Subject = txtSubject.Text
                mm.Body = txtBody.Text
                If fuAttachment.HasFile Then
                    Dim FileName As String = Path.GetFileName(fuAttachment.PostedFile.FileName)
                    mm.Attachments.Add(New Attachment(fuAttachment.PostedFile.InputStream, FileName))
                End If
                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient(txtHost.Text)
                ' smtp.Host = txtHost.Text
                If txtSSL.Text = 1 Then
                    smtp.EnableSsl = True
                ElseIf txtSSL.Text = 0 Then
                    smtp.EnableSsl = False
                End If
                Dim NetworkCred As New NetworkCredential(txtEmail.Text, txtPassword.Text)
                smtp.UseDefaultCredentials = False
                smtp.Credentials = NetworkCred
                smtp.Port = txtPort.Text
                smtp.Send(mm)
                ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email sent.');", True)
            End Using
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('" & ex.Message & "');", True)
        End Try

        '   Try
        '       Dim _nclass As New cDalNewSendEmail
        '       _nclass._pOAIMSDatabaseName = cGlobalConnections._pSqlCxn_OAIMS.Database
        '       _nclass._pCRDatabaseName = cGlobalConnections._pSqlCxn_CR.Database
        '       _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        '       _nclass._pSubGetEmailMaster()
        '
        '       Using mm As New MailMessage(_nclass._pSenderEmailAddress, txtTo.Text)
        '           mm.Subject = txtSubject.Text
        '           mm.Body = txtBody.Text
        '
        '           Dim CarbonCopy As MailAddress = New MailAddress(_nclass._pCC)
        '           Dim BlindCarbonCopy As MailAddress = New MailAddress(_nclass._pBCC)
        '           mm.CC.Add(CarbonCopy)
        '           mm.Bcc.Add(BlindCarbonCopy)
        '
        '           mm.IsBodyHtml = True
        '           Dim smtp As New SmtpClient()
        '           smtp.Host = _nclass._pHost
        '           smtp.EnableSsl = True
        '           Dim NetworkCred As New NetworkCredential(_nclass._pSenderEmailAddress, _nclass._pSenderEmailPassword)
        '           smtp.UseDefaultCredentials = False
        '           smtp.Credentials = NetworkCred
        '           smtp.Port = _nclass._pPort
        '           smtp.Send(mm)
        '       End Using
        '   Catch ex As Exception
        '
        '   End Try
    End Sub
End Class