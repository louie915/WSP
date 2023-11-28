
Imports System.ComponentModel
Imports Microsoft.Reporting.WebForms
Imports System.Web.UI
Imports VB.NET.Email
Imports System.Net
Imports System.IO
Imports System.Net.Mail

Public Class cDalSendEmail

#Region "Variable Field"
    Private _mSubject As String
    Private _mHeader As String
    Private _mBody As String
    Private _mFooter As String
    Private _mEmailTo As String
    Private _mAttachment As ArrayList = New ArrayList
#End Region

#Region "Property Field"
    Public Property _pSubject() As String
        Get
            Return _mSubject
        End Get
        Set(value As String)
            _mSubject = value
        End Set
    End Property

    Public Property _pHeader() As String
        Get
            Return _mHeader
        End Get
        Set(value As String)
            _mHeader = value
        End Set
    End Property

    Public Property _pBody() As String
        Get
            Return _mBody
        End Get
        Set(value As String)
            _mBody = value
        End Set
    End Property

    Public Property _pFooter() As String
        Get
            Return _mFooter
        End Get
        Set(value As String)
            _mFooter = value
        End Set
    End Property

    Public Property _pEmailTo() As String
        Get
            Return _mEmailTo
        End Get
        Set(value As String)
            _mEmailTo = value
        End Set
    End Property

    Public Property _pAttachment() As ArrayList
        Get
            Return _mAttachment
        End Get
        Set(value As ArrayList)
            _mAttachment = value
        End Set
    End Property
#End Region

    Public Function _pSubSendEmail() As Boolean 'Added 20171120

        Dim _nReturnValue As Boolean
        Try
            'Send Email For the Notification
            '----------------------------------
            Dim _mEmailWebMaster As String
            Dim _mPassword As String
            Dim _mEmailCC As String
            Dim _mEmailBCC As String

            Dim _nclassEmailSetup As New cDalGetWebEmailMaster
            _nclassEmailSetup._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nclassEmailSetup._pSubGetEmailMaster()

            _mEmailWebMaster = _nclassEmailSetup._pEmailMaster
            _mPassword = _nclassEmailSetup._pPassword
            _mEmailCC = _nclassEmailSetup._pEmailCC
            _mEmailBCC = _nclassEmailSetup._pEmailBCC
            '----------------------------------

            '----------------------------------
            'Date
            Dim _nDate As String = FormatDateTime(Now, DateFormat.LongDate)

            Dim _nClass As New ClassEmailGoogle
            Dim _nStrucInfo As New ClassEmailGoogle._InfoEmail

            '----------------------------------
            'From
            _nStrucInfo._pEmailFrom = _mEmailWebMaster

            '----------------------------------
            'To
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailTo)

                Select Case _mEmailTo

                    Case UCase("BPLO")

                        Dim _nclassEmail As New cDalGetBploEmail
                        _nclassEmail._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                        _nclassEmail._pSubGetEmailBplo()
                        _nStrucInfo._pEmailTo = _nclassEmail._pArrayListBploEmail

                    Case Else

                        _nStrucInfo._pEmailTo = _nArrayList

                End Select

            Catch ex As Exception

            End Try

            '----------------------------------
            'Cc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailCC)
                _nStrucInfo._pEmailCc = _nArrayList


            Catch ex As Exception

            End Try

            '----------------------------------
            'Bcc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailBCC)
                _nStrucInfo._pEmailBcc = _nArrayList

            Catch ex As Exception

            End Try

            '----------------------------------

            'Subject
            _nStrucInfo._pEmailSubject = _mSubject
            '"Notification"

            '----------------------------------

            'Body --tomi
            _nStrucInfo._pEmailBody = _mBody
            '                "Sir/Ma`am: <br> " & _
            '                "Your Business account for Account Number " & cSessionLoader._pAccountNo & " is now for review and verification by Business Permit Licensing Officer. <br>" & _
            '                "Please wait for 1 working day for approval of application. <br>" & _
            '                "Thank you. <br>"
            '----------------------------------

            'Header
            _nStrucInfo._pEmailHeader = _mHeader & "<br> <br> "
            '  cSessionLoader._pLGU_Name 

            '----------------------------------

            'Footer
            _nStrucInfo._pEmailFooter = _mFooter
            '    "<br> Date Sent : " & Now.Date & _
            '    "<br> <br> THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL."

            '----------------------------------
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nUrlLink]", "")

            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nUserID]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nFirstName]", "")
            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nLastName]", "")

            _nStrucInfo._pEmailBody = _nStrucInfo._pEmailBody.Replace("[Replace:_nDate]", _nDate)
            '----------------------------------
            'Mail Client Credential
            _nStrucInfo._pEMailClientUserName = _mEmailWebMaster
            _nStrucInfo._pEMailClientPassword = _mPassword

            '----------------------------------
            _nClass._pStrucInfo = _nStrucInfo

            If _nClass._pFuncSendEmail() Then
                _nReturnValue = True
                Return True
            Else
                _nReturnValue = False
                Return False
            End If

            _nClass = Nothing

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function _FnSendEmail() As Boolean ' Added 20200626 Louie
        Try
            '----------------------------------
            Dim _mEmailWebMaster As String
            Dim _mPassword As String
            Dim _mEmailCC As String
            Dim _mEmailBCC As String

            Dim _nclassEmailSetup As New cDalGetWebEmailMaster
            _nclassEmailSetup._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nclassEmailSetup._pSubGetEmailMaster()

            _mEmailWebMaster = _nclassEmailSetup._pEmailMaster
            _mPassword = _nclassEmailSetup._pPassword
            _mEmailCC = _nclassEmailSetup._pEmailCC
            _mEmailBCC = _nclassEmailSetup._pEmailBCC

            Using mm As New MailMessage(_mEmailWebMaster, _mEmailTo)
                mm.IsBodyHtml = True
                mm.Subject = _mSubject
                mm.Body = _mHeader + "<br/> <br/>" & _
                           _mBody + "<br/> <br/>" & _
                          _mFooter + "<br/>"

                Dim i, iCnt As Integer

                iCnt = _mAttachment.Count - 1
                For i = 0 To iCnt
                    If FileExists(_mAttachment(i)) Then
                        Dim data As Attachment = New Attachment(_mAttachment(i))
                        mm.Attachments.Add(data)
                    End If
                Next

                Dim _nclass2 As New cDalNewSendEmail
                _nclass2._pOAIMSDatabaseName = cGlobalConnections._pSqlCxn_OAIMS.Database
                _nclass2._pCRDatabaseName = cGlobalConnections._pSqlCxn_CR.Database
                _nclass2._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                _nclass2._pSubGetEmailMaster()

                Dim smtp As New SmtpClient()
                smtp.Host = _nclass2._pHost
                smtp.EnableSsl = True
                Dim NetworkCred As New NetworkCredential(_nclass2._pSenderEmailAddress, _nclass2._pSenderEmailPassword)
                smtp.UseDefaultCredentials = True
                smtp.Credentials = NetworkCred
                smtp.Port = _nclass2._pPort
                smtp.Send(mm)
                Return True
                'ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('Email sent.');", True)
            End Using
        Catch ex As Exception
            cDalLogEvent._pSubLogError(ex)
            Return False
            'ClientScript.RegisterStartupScript(Me.GetType, "alert", "alert('" & ex.Message & "');", True)
        End Try
    End Function

    Private Function FileExists(ByVal FileFullPath As String) _
    As Boolean
        If Trim(FileFullPath) = "" Then Return False

        Dim f As New IO.FileInfo(FileFullPath)
        Return f.Exists

    End Function

End Class
