

#Region "Imports"

Imports System.Web.HttpContext
Imports VB.NET.Email
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.Web.Mail
Imports System.Net.Mail
Imports System.Net
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq

Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

#End Region

Public Class ClassSessionMailContent

#Region "Variables"

    '_ssc = Session String Constant
    Private Const _sscPrefix As String = "ClassSessionMailContent."

    Private Const _sscUserID As String = _sscPrefix & "_sscUserID"
    'Private Shared _sscInfoEmailActivation As String = _mSessionPrefix & "_sscInfoEmailActivation"

    Public Shared _mKeyToken As String
    Private Shared _mFirstName As String
    Private Shared _mLastName As String
    Private Shared _mResetPass As Boolean

#End Region

#Region "Properties"

    Shared Property _pUserID() As String
        Get
            Return Current.Session(_sscUserID)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscUserID) = value
        End Set
    End Property

    'Shared Property _pInfoEmailActivation() As ClassEmailActivationGoogle._InfoEmail
    '    Get
    '        Return Current.Session(_sscInfoEmailActivation)
    '    End Get
    '    Set(ByVal value As ClassEmailActivationGoogle._InfoEmail)
    '        Current.Session(_sscInfoEmailActivation) = value
    '    End Set
    'End Property

#End Region

#Region "Routines"

    Public Shared Function _pFuncSendEmailActivation() As Boolean

        Dim _nReturnValue As Boolean
        Dim _nResetKey As Boolean = False
        Try
            '----------------------------------
            If String.IsNullOrWhiteSpace(_pUserID) Then
                '"Return" command automatically exits routine.
                Return False
            End If

            'Get User Details
            If Not _pFuncGetUserDetails() Then
                '"Return" command automatically exits routine.
                Return False
            End If

            '----------------------------------
            'Url Link
            '---------------------------------- Removed 20180614
            'Dim _nUrlLink As String = cUrlRedirects._pFuncGetUrlLink(
            '    rPages_VS2014WAOAIMS_Business.pVerifyLinkAccountActivation)
            '---------------------------------- 

            'temporary comment'      Dim _nUrlLink As String = cUrlRedirects._pFuncGetUrlLink(rPages_VS2014WAOAIMS_Business.pEmailVerification)

            Dim _nUrlParameter As String = Nothing
            _nUrlParameter = "?_nUserID=" & _pUserID & "&_nKeyToken=" & _mKeyToken & "&_nResetKey=" & _nResetKey

            'temporary comment'   _nUrlLink = _nUrlLink & _nUrlParameter
            '----------------------------------
            'Date
            Dim _nDate As String = FormatDateTime(Now, DateFormat.LongDate)

            Dim _nClass As New ClassEmailGoogle
            Dim _nStrucInfo As New ClassEmailGoogle._InfoEmail


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
            'From
            _nStrucInfo._pEmailFrom = _mEmailWebMaster 'Resources._gResxMailContentActivation.EmailFrom

            '----------------------------------
            'To
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_pUserID)
                _nStrucInfo._pEmailTo = _nArrayList

            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
            'Cc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailCC) '(Resources._gResxMailContentActivation.EmailCc01)
                _nStrucInfo._pEmailCc = _nArrayList

            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
            'Bcc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailBCC) '(Resources._gResxMailContentActivation.EmailBcc01)
                _nStrucInfo._pEmailBcc = _nArrayList

            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
            ' - Email Content By Tomi
            'Subject
            cSessionLGUProfile._pSqlConCR = cGlobalConnections._pSqlCxn_CR

            Dim tst As String
            cSessionLGUProfile._pGetLGUProfile(tst)
            _nStrucInfo._pEmailSubject = "Welcome to " & cSessionLGUProfile._pLGU_Header2 & " Web Services"

            '----------------------------------
            'Header

            Dim verifyurl As String = Replace(UCase(HttpContext.Current.Request.Url.AbsoluteUri), "REGISTER", "VerifyEmail") & "?email=" & _pUserID & "&code=" & _mKeyToken


            _nStrucInfo._pEmailHeader = "Congratulations " & _mFirstName & ", <br/><br/>" _
                                      & "Thank you for signing up. Please click the link below to verify your email address. <br/><br/>"

            '----------------------------------
            'Body
            Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
            Dim PageName As String = System.IO.Path.GetFileName(PagePath)

            Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")
            _nStrucInfo._pEmailBody = "<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Verify your Email</a><br/><br/>" _
                                      & "If you cannot see verification link then please use this link instead : " & verifyurl _
                                      & " <br/><br/> Once you verify your email address you will be ready to login! <br/><br/>" _
                                      & "<a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a><br/><br/>" _
                                      & "Instruction for Business and Real Property Enrollment:<br>" _
                                      & "<ol type='1'>" _
                                      & " <br><li> You will be asked to enroll Business and/or property(ies) you wish to transact online by entering the the Business Account Number and Tax Declaration Number (TDN) and corresponding Official Receipt Number (OR) of the last payment;</li>" _
                                      & " <br><li> We strongly suggest to ready the reference documents such as Business Tax Order of Payment and Latest Taxdeclaration including Official Receipt Number (OR) of last payment that will be needed during enrollment.</li>" _
                                      & " <br><li> Submit and wait for the notification email message regarding approval of Business and or properties enrolled. </li>" _
                                      & "</ol>"

            If cDalHRIMS._pHRIMS_RegLink = "OK" Then
                cDalHRIMS._pHRIMS_RegLink = Nothing
                loginURL = "http://" & HttpContext.Current.Request.Url.Authority & "/PMIPS/PMIPS_Login.aspx "
                verifyurl = "http://" & HttpContext.Current.Request.Url.Authority & "/PMIPS/PMIPS_VerifyEmail.aspx?email=" & _pUserID & "&code=" & _mKeyToken

                _nStrucInfo._pEmailBody = "<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Verify your Email</a><br/><br/>" _
                                    & "If you cannot see verification link then please use this link instead : " & verifyurl _
                                    & " <br/><br/> Once you verify your email address you will be ready to login! <br/><br/>" _
                                    & "<a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a><br/><br/>"

            ElseIf cDalUserAccountManagement._pAdmin_RegLink = "OK" Then
                cDalUserAccountManagement._pAdmin_RegLink = Nothing
                verifyurl = FullUrl.Replace(PageName, "LGUVerifyEmail.aspx?email=" & _pUserID & "&code=" & _mKeyToken & "&office=" & cDalUserAccountManagement._pAdmin_SelectedOffice)
                _nStrucInfo._pEmailBody = "<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Verify your Email</a><br/><br/>" _
                                    & "If you cannot see verification link then please use this link instead : " & verifyurl _
                                    & " <br/><br/> Once you verify your email address you will be ready to login! <br/><br/>" _
                                    & "<a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a><br/><br/>"
            End If

            cSessionLoader._pErrMSG = verifyurl

            'Mail Client Credential
            _nStrucInfo._pEMailClientUserName = _mEmailWebMaster  'Resources._gResxMailContentActivation.EmailClientUserName
            _nStrucInfo._pEMailClientPassword = _mPassword 'Resources._gResxMailContentActivation.EmailClientPassword

            '----------------------------------
            _nClass._pStrucInfo = _nStrucInfo

            If _nClass._pFuncSendEmail() Then
                _nReturnValue = True
            Else
                _nReturnValue = False
            End If

            _nClass = Nothing

            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function _pFuncSendEmailUserKeyReset() As Boolean

        Dim _nReturnValue As Boolean
        Dim _nResetKey As Boolean = True
        Try
            '----------------------------------
            If String.IsNullOrWhiteSpace(_pUserID) Then
                '"Return" command automatically exits routine.
                Return False
            End If

            'Get User Details
            If Not _pFuncGetUserDetails() Then
                '"Return" command automatically exits routine.
                Return False
            End If

            '----------------------------------
            'Url Link
            'temporary comment'   Dim _nUrlLink As String = cUrlRedirects._pFuncGetUrlLink(rPages_VS2014WAOAIMS_Business.pEmailVerification)

            Dim _nUrlParameter As String = Nothing
            _nUrlParameter = "?_nUserID=" & _pUserID & "&_nKeyToken=" & _mKeyToken & "&_nResetKey=" & _nResetKey

            'temporary comment'     _nUrlLink = _nUrlLink & _nUrlParameter

            '----------------------------------
            'Date
            Dim _nDate As String = FormatDateTime(Now, DateFormat.LongDate)

            Dim _nClass As New ClassEmailGoogle
            Dim _nStrucInfo As New ClassEmailGoogle._InfoEmail

            '----------------------------------
            'Send Email For the Notification
            '----------------------------------
            Dim _mEmailWebMaster As String
            Dim _mPassword As String
            Dim _mEmailCC As String
            Dim _mEmailBCC As String
            Dim _mPort As String
            Dim _mHost As String


            Dim _nclassEmailSetup As New cDalGetWebEmailMaster
            _nclassEmailSetup._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nclassEmailSetup._pSubGetEmailMaster()

            _mEmailWebMaster = _nclassEmailSetup._pEmailMaster
            _mPassword = _nclassEmailSetup._pPassword
            _mEmailCC = _nclassEmailSetup._pEmailCC
            _mEmailBCC = _nclassEmailSetup._pEmailBCC
            _mPort = _nclassEmailSetup._pPort
            _mHost = _nclassEmailSetup._pHost



            '----------------------------------
            'From
            _nStrucInfo._pEmailFrom = _mEmailWebMaster 'Resources._gResxMailContentActivation.EmailFrom

            '----------------------------------
            'To
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_pUserID)
                _nStrucInfo._pEmailTo = _nArrayList

            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
            'Cc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailCC) '(Resources._gResxMailContentActivation.EmailCc01)
                _nStrucInfo._pEmailCc = _nArrayList

            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
            'Bcc
            Try
                Dim _nArrayList As New ArrayList
                _nArrayList.Add(_mEmailBCC) '(Resources._gResxMailContentActivation.EmailBcc01)
                _nStrucInfo._pEmailBcc = _nArrayList

            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
            ' - Email Content By Tomi
            'Subject
            _nStrucInfo._pEmailSubject = "Forgot Password"
            '----------------------------------
            'Header
            Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
            Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
            Dim PageName As String = System.IO.Path.GetFileName(PagePath)

            Dim verifyurl As String = FullUrl.Replace(PageName, "ResetPassword.aspx" & _nUrlParameter)
            _nStrucInfo._pEmailHeader = "Hi " & _mFirstName & "!, <br/><br/>" _
                                      & "We have sent you this email in response to your request to reset your password. <br/><br/>"

            '----------------------------------
            'Body
            Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")

            _nStrucInfo._pEmailBody = "To reset your password for " & _pUserID & ", please click this link [<a href='" & verifyurl & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Confirm Reset</a>]<br/><br/>" _
                                     & "If you cannot see Reset Password link then please use this link instead : " & verifyurl _
                                     & " <br/><br/> We recommend that you keep your password secure and not share it with anyone.<br/><br/>"

            _nStrucInfo._pEMailClientUserName = _mEmailWebMaster  'Resources._gResxMailContentActivation.EmailClientUserName
            _nStrucInfo._pEMailClientPassword = _mPassword 'Resources._gResxMailContentActivation.EmailClientPassword

            '----------------------------------
            _nClass._pStrucInfo = _nStrucInfo

            If _nClass._pFuncSendEmail() Then
                _nReturnValue = True
            Else
                _nReturnValue = False
            End If

            _nClass = Nothing

            Return _nReturnValue

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
     
    End Function

    Public Shared Function _pFuncGetUserDetails() As Boolean

        Try
            '----------------------------------
            If String.IsNullOrWhiteSpace(_pUserID) Then
                '"Return" command automatically exits routine.
                Return False
            End If

            '----------------------------------
            Dim _nQuery As String = Nothing
            _nQuery = _
                "SELECT " & _
                "* " & _
                "FROM " & _
                "[uvw.VS2014.WA.OAIMS.Registered.Data.Read.Detailed.A] " & _
                "WHERE " & _
                "[UserID] = @UserID"
            '----------------------------------
            Using _nCommand As New SqlCommand

                _nCommand.Connection = cGlobalConnections._pSqlCxn_OAIMS
                _nCommand.CommandText = _nQuery
                _nCommand.CommandType = CommandType.Text

                _nCommand.Parameters.AddWithValue("@UserID", _pUserID)

                Using _nSqlDataReader As SqlDataReader = _nCommand.ExecuteReader

                    '----------------------------------
                    'Indexes
                    Dim _intKeyToken As Integer = _nSqlDataReader.GetOrdinal("KeyToken")

                    Dim _intFirstName As Integer = _nSqlDataReader.GetOrdinal("FirstName")
                    Dim _intLastName As Integer = _nSqlDataReader.GetOrdinal("LastName")

                    '----------------------------------
                    Dim _nClassReturnTypes As New ClassReturnTypes
                    With _nClassReturnTypes

                        If _nSqlDataReader.HasRows Then

                            Do While _nSqlDataReader.Read

                                _mKeyToken = ._pReturnString(_nSqlDataReader(_intKeyToken))

                                _mFirstName = ._pReturnString(_nSqlDataReader(_intFirstName))
                                _mLastName = ._pReturnString(_nSqlDataReader(_intLastName))

                                '_mKeyToken = _nSqlDataReader.Item("KeyToken").ToString
                                '_mFirstName = _nSqlDataReader.Item("FirstName").ToString
                                '_mLastName = _nSqlDataReader.Item("LastName").ToString

                            Loop

                        End If

                    End With

                    _nSqlDataReader.Close()
                End Using '_nSqlDataReader

            End Using '_nCommand

            '----------------------------------

            Return True
            '----------------------------------
        Catch ex As Exception
            Return False
        End Try







    End Function

#End Region

End Class
