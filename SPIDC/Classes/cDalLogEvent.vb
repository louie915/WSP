Imports System.IO
Imports System.Reflection
Imports System.Reflection.MethodBase
Imports System.Web.HttpContext
Imports System.Text
Imports System.Web.Hosting
Public Class cDalLogEvent

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


    'Create Log File Sequence ID /// Added By Louie: 20200630
    Shared Function _FnDateSequence() As String
        _FnDateSequence = Nothing
        Try
            Dim _nDateNow As String = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt")
            Return _nDateNow.Replace("/", "").Replace(" ", "").Replace(":", "")
        Catch ex As Exception

        End Try

    End Function

    'Log Error to Text File  ///  Added By Louie: 20200630
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
        'message += String.Format("Dll Date Complied: {0}", _mDateCompiled)
        'message += Environment.NewLine
        message += "-----------------------------------------------------------"
        message += Environment.NewLine


        Dim _nErrorTxt As String = _FnDateSequence()

        Dim path As String = HttpContext.Current.Server.MapPath("~/ErrorLog/" & _nErrorTxt & ".txt")
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



    'Shared Sub _pSubLogError(msg As String)

    '    Dim message As String = String.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))
    '    message += Environment.NewLine
    '    message += "-----------------------------------------------------------"
    '    'message += Environment.NewLine
    '    'message += String.Format("Message: {0}", ex.Message.ToString)
    '    'message += Environment.NewLine
    '    'message += String.Format("StackTrace: {0}", ex.StackTrace.ToString)
    '    'message += Environment.NewLine
    '    'message += String.Format("Source: {0}", ex.Source.ToString)
    '    'message += Environment.NewLine
    '    'message += String.Format("Exception: {0}", ex.GetType.ToString)
    '    'message += Environment.NewLine
    '    'message += String.Format("TargetSite: {0}", ex.TargetSite.ToString)
    '    'message += Environment.NewLine
    '    'message += String.Format("Dll Date Complied: {0}", _mDateCompiled)
    '    'message += Environment.NewLine
    '    message += msg
    '    message += Environment.NewLine
    '    message += "-----------------------------------------------------------"
    '    message += Environment.NewLine


    '    Dim _nErrorTxt As String = _FnDateSequence()

    '    Dim path As String = HttpContext.Current.Server.MapPath("~/ErrorLog/" & _nErrorTxt & ".txt")
    '    Dim path2 As String = HostingEnvironment.MapPath("~/ErrorLog/" & _nErrorTxt & ".txt")

    '    If ModeDebug Then
    '        Using writer As New StreamWriter(path2, True)
    '            writer.WriteLine(message)
    '            writer.Close()
    '        End Using
    '    Else
    '        Using writer As New StreamWriter(path, True)
    '            writer.WriteLine(message)
    '            writer.Close()
    '        End Using
    '    End If

    'End Sub
End Class
