

#Region "Imports"
Imports System.IO
Imports System.Reflection
Imports System.Reflection.MethodBase
Imports System.Web.HttpContext
Imports System.Text
Imports System.Web.Hosting

#End Region

Public Class cEventLog

#Region "Variables"

    Private Shared _mPrefix As String = GetCurrentMethod.DeclaringType.FullName

    Private Shared _mDateCompiled As String

#End Region

#Region "Properties"

    Shared Property _pLiteral() As Literal
        Get
            Return Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4))
        End Get
        Set(ByVal value As Literal)
            Current.Session(_mPrefix & GetCurrentMethod.Name.Substring(4)) = value
        End Set
    End Property

    Shared ReadOnly Property ModeDebug() As Boolean
        Get
            If Current.Request.Url.AbsoluteUri.StartsWith("http://localhost:") _
               Or Current.Request.Url.AbsoluteUri.StartsWith("https://localhost:") Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Shared Property _pDateCompiled() As String ' For DLL 
        Get
            Return _mDateCompiled
        End Get
        Set(ByVal value As String)
            _mDateCompiled = value
        End Set
    End Property

#End Region


    'Log Clear.
    Shared Sub _pSubEventLog()
        Try
            '---------- ---------- ---------- ----------
            _pLiteral.Text = Nothing
            '---------- ---------- ---------- ----------
        Catch ex As Exception
        End Try
    End Sub

    'Log Normal Routine.
    Shared Sub _pSubEventLog(_nMessage As String, Optional _nNewLines As Integer = 1)
        Try
            '---------- ---------- ---------- ----------
            'If _pLiteral.Text = "" Then Exit Sub
            '---------- ---------- ---------- ----------
            Dim _nSb As New StringBuilder
            _nSb.Append("<font style='font-size:small;'><b>@</b>" & DateTime.Now.ToString("'D.'MM.dd.yyyy'.T.'HH:mm:ss.fff':'") & " </font>")
            _nSb.Append("<font style='color:dimgray;'>" & _nMessage & "</font>")
            For _nI As Integer = 1 To _nNewLines
                _nSb.Append("<br/>")
            Next
            _pLiteral.Text += _nSb.ToString
            '---------- ---------- ---------- ----------
        Catch ex As Exception
        End Try
    End Sub

    'Log TimeSpan.
    Shared Sub _pSubEventLog(_nTimeSpan As TimeSpan, Optional _nNewLines As Integer = 1)
        Try
            '---------- ---------- ---------- ----------
            Dim _nSb As New StringBuilder
            _nSb.Append("<b>TimeSpan: </b>" & _nTimeSpan.ToString("dd'd 'hh'h 'mm'm 'ss's 'fff'ms'"))
            _pSubEventLog(_nSb.ToString, _nNewLines)
            '---------- ---------- ---------- ----------
        Catch ex As Exception
        End Try
    End Sub

    'Log Exception.
    Shared Sub _pSubEventLog(_nException As Exception, Optional _nNewLines As Integer = 1)
        Try
            '---------- ---------- ---------- ----------
            Dim _nSb As New StringBuilder
            Dim _nHostLoc As String = HostingEnvironment.MapPath("~/ErrorLog/LOG.txt")
            _nSb.Append("<font style='color:crimson;'><b>Error: </b><br/>")
            _nSb.Append("<b>Source: </b>" & _nException.Source.ToString & "<br/>")
            _nSb.Append("<b>Message: </b>" & _nException.Message.ToString & "<br/>")
            _nSb.Append("<b>Exception: </b>" & _nException.GetType.ToString & "<br/>")
            _nSb.Append("<b>StackTrace: </b>" & _nException.StackTrace.ToString & "</font>")
            _nSb.Append("<b>HostingLocation: </b>" & _nHostLoc & "</font>")
            _nSb.Append("<b>DLL Compiled Date: </b>" & _mDateCompiled & "</font>")
            _pSubEventLog(_nSb.ToString, _nNewLines)

            cBllChronicleError._pFnLogError(_nException)

            _pSubLogError(_nException)

            '---------- ---------- ---------- ----------
        Catch ex As Exception
        End Try
    End Sub

    'Log Control Event.
    Shared Sub _pSubEventLog(_nMethod As MethodBase, _nControl As Object, Optional _nIsBegin As Boolean = False)
        Try
            '---------- ---------- ---------- ----------

            Select Case _nIsBegin
                Case True
                    _pSubEventLog("Begin: <b>[Sender]</b> " & _nControl.ID & " <b>[Event]</b> " & _nMethod.Name)
                Case Else
                    _pSubEventLog("End: <b>[Sender]</b> " & _nControl.ID & " <b>[Event]</b> " & _nMethod.Name)
            End Select


            '---------- ---------- ---------- ----------
        Catch ex As Exception
        End Try
    End Sub

    'Create Log File Sequence ID /// Added By Louie: 20180928 
    Shared Function _FnDateSequence() As String
        _FnDateSequence = Nothing
        Try
            Dim _nClass As New cDalChronicleError
            _nClass._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubGetSeq()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDt

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    '_mSubShowEmptyTraningCourseGridView()
                End If

                If _nDataTable.Rows.Count <> 0 Then
                    _FnDateSequence = _nDataTable.Rows("0").Item("DateSeq").ToString
                End If

            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try

        ''
    End Function

    'Log Error to Text File  ///  Added By Louie: 20180927
    Shared Sub _pSubLogError(ex As Exception)



        Dim message As String = String.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
        message += Environment.NewLine
        message += "-----------------------------------------------------------"
        message += Environment.NewLine
        message += String.Format("Message: {0}", ex.Message.ToString)
        message += Environment.NewLine
        message += String.Format("StackTrace: {0}", ex.StackTrace.ToString)
        message += Environment.NewLine
        message += String.Format("Source: {0}", ex.Source.ToString)
        message += Environment.NewLine
        message += String.Format("Exception: {0}", ex.GetType.ToString)
        message += Environment.NewLine
        message += String.Format("TargetSite: {0}", ex.TargetSite.ToString)
        message += Environment.NewLine
        message += String.Format("Dll Date Complied: {0}", _mDateCompiled)
        message += Environment.NewLine
        message += "-----------------------------------------------------------"
        message += Environment.NewLine


        Dim _nErrorTxt As String = _FnDateSequence()
        Dim path As String = "C:\inetpub\logs\ErrorLog\" & _nErrorTxt & ".txt"
        Dim path2 As String = HostingEnvironment.MapPath("~/ErrorLog/" & _nErrorTxt & ".txt")

        If ModeDebug Then
            Using writer As New StreamWriter(path2, True)
                writer.WriteLine(message)
                writer.Close()
            End Using
        Else
            Using writer As New StreamWriter(path, True)
                writer.WriteLine(message)
                writer.Close()
            End Using
        End If

    End Sub

End Class
