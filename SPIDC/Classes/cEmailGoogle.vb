

#Region "Imports"
Imports System.Net
Imports System.Net.Mail
Imports System.Threading.Tasks

#End Region

Public Class cEmailGoogle
    Implements IDisposable

    Private _mStrucInfo As _InfoEmail
    Public Structure _InfoEmail

        Public _pEmailFrom As MailAddress
        Public _pEmailTo As MailAddressCollection
        Public _pEmailCc As MailAddressCollection
        Public _pEmailBcc As MailAddressCollection
        Public _pEmailSubject As String

        Public _pEmailBody As String
        Public _pEmailHeader As String
        Public _pEmailFooter As String

        Public _pEmailBodyIsHtml As Boolean
        Public _pEMailClientUserName As String
        Public _pEMailClientPassword As String

        Shared _pDefaultEMailClientUserName1 As String = "web.master.spidc@gmail.com"
        Shared _pDefaultEMailClientPassword1 As String = "#@VeryStr0ngS@P@ssw0rd102476"

        Shared _pDefaultEMailClientUserName2 As String = "ccimswebmaster@gmail.com"
        Shared _pDefaultEMailClientPassword2 As String = "@VeryStr0ngP@ssw0rd"


    End Structure

    Public Property _pStrucInfo As _InfoEmail
        Get
            Return _mStrucInfo
        End Get
        Set(ByVal value As _InfoEmail)
            _mStrucInfo = value
        End Set
    End Property

    '----------------------------------------
    'Below are Accounts used for CCIMS

    'ccimswebmaster@gmail.com
    '@VeryStr0ngP@ssw0rd

    'ccims.help.desk@gmail.com
    '@VeryStr0ngP@ssw0rd   
    '----------------------------------------
    'Below are Acounts used for SPIDC

    '----------------------------------------
    'smtp Server: smtp.gmail.com
    'smtp ports: 587 or 465

    Public Function _pFuncSendEmail() As Boolean

        Dim _nMethod As String = Reflection.MethodBase.GetCurrentMethod.Name
        '_gLog._WriteEvent(_gAssemblyInfo._pProduct, _nMethod, "Begin")

        Try
            '----------------------------------
            'divert the user to enable this application to use this account.
            'https://accounts.google.com/DisplayUnlockCaptcha

            '----------------------------------
            Dim _nMailMessage As New MailMessage()
            Dim _nSmtpClient As New System.Net.Mail.SmtpClient
            Dim _nNetworkCredential As New System.Net.NetworkCredential

            '----------------------------------
            'From/ Sender
            _nMailMessage.From = New MailAddress(_mStrucInfo._pEmailFrom.ToString)

            '----------------------------------
            'To
            Try
                For Each _nMailAddress As MailAddress In _mStrucInfo._pEmailTo
                    _nMailMessage.To.Add(_nMailAddress)
                Next
            Catch ex As Exception

            End Try

            '----------------------------------
            'Cc
            Try
                For Each _nMailAddress As MailAddress In _mStrucInfo._pEmailCc
                    _nMailMessage.CC.Add(_nMailAddress)
                Next
            Catch ex As Exception

            End Try

            '----------------------------------
            'Bcc
            Try
                For Each _nMailAddress As MailAddress In _mStrucInfo._pEmailBcc
                    _nMailMessage.Bcc.Add(_nMailAddress)
                Next
            Catch ex As Exception

            End Try

            '----------------------------------
            'Subject
            _nMailMessage.Subject = _mStrucInfo._pEmailSubject

            '----------------------------------
            'Body
            _nMailMessage.IsBodyHtml = _mStrucInfo._pEmailBodyIsHtml
            _nMailMessage.Body = _
                _mStrucInfo._pEmailHeader & _
                _mStrucInfo._pEmailBody & _
                _mStrucInfo._pEmailFooter

            '----------------------------------
            'Credential
            _nNetworkCredential.UserName = _mStrucInfo._pEMailClientUserName
            _nNetworkCredential.Password = _mStrucInfo._pEMailClientPassword

            'Smtp Client
            _nSmtpClient.Host = "smtp.gmail.com"
            _nSmtpClient.Port = CInt("587") 'or CInt(465)
            _nSmtpClient.UseDefaultCredentials = False
            _nSmtpClient.Credentials = _nNetworkCredential
            _nSmtpClient.EnableSsl = True

            '----------------------------------
            'Send Email
            _nSmtpClient.Send(_nMailMessage)
            Return True

            '----------------------------------
        Catch ex As Exception

            Return False
        Finally

        End Try
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class

'TODO: 
'


