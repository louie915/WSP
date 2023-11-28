

#Region "Imports"

Imports System.Reflection.MethodBase
Imports System.Web.HttpContext
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.ScriptManager
Imports System.Web.UI.WebControls
Imports System.Text

#End Region

Public Class cRegisterScript

#Region "Variables"

    Private Shared _mPrefix As String = GetCurrentMethod.DeclaringType.FullName

#End Region

    Public Shared Sub _pSubControlShowHide(
       _oControl As Control,
       _nVisible As Boolean
       )
        Try
            '----------------------------------
            'ContentPlaceHolder1_ContentPlaceHolder1__oPanelEvents
            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            Dim _nSb As New StringBuilder
            _nSb.Append(
                "<script type = ""text/javascript""> " &
                "" &
                "   function SubControlShowHide() { " &
                "       document.getElementById('" & _oControl.ClientID & "').visible = " & _nVisible.ToString.ToLower & "; " &
                "   }" &
                "" &
                "</script>"
                )

            _nPage.ClientScript.RegisterClientScriptBlock(
              _nPage.GetType,
              _nPage.UniqueID,
              _nSb.ToString,
              False)

            ScriptManager.RegisterClientScriptBlock(
                _nPage,
                _nPage.GetType,
                _nPage.UniqueID & "SubControlShowHide",
                "SubControlShowHide();",
                False)

            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' This will enable the Control to Automatically Scroll Down.
    ''' </summary>
    ''' <param name="_nControl">The control to enable Automatic Scroll Down.</param>
    ''' <remarks>The Control can be a TextBox, Panel...</remarks>
    Public Shared Sub _pSubSetAutoScrollDown(
        _oControl As Control
        )
        Try
            '----------------------------------
            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            Dim _nSb As New StringBuilder
            _nSb.Append(
                "<script type = ""text/javascript""> " & _
                "window.onload = Scroll; " & _
                "var prm = Sys.WebForms.PageRequestManager.getInstance(); " & _
                "if (prm != null) {prm.add_endRequest(function (sender, e) { " & _
                "       if (sender._postBackSettings.panelsToUpdate != null) { " & _
                "           Scroll(); " & _
                "           } " & _
                "       }); " & _
                "   }; " & _
                "function Scroll() { " & _
                "       var _nControl = document.getElementById('" & _oControl.ClientID & "'); " & _
                "       _nControl.scrollTop = _nControl.scrollHeight; " & _
                "   } " & _
                "</script>"
                )

            _nPage.ClientScript.RegisterStartupScript(
                _nPage.GetType,
                _nPage.UniqueID,
                _nSb.ToString,
                False)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' This will open the specified URL in a New Tab or New Window.
    ''' </summary>
    ''' <param name="_nUrl">The URL of the page to open.</param>
    ''' <param name="_nTarget">The Target or Name of the window. (1=_blank|2=_parent|3=_self|4=_top|"Name").</param>
    ''' <param name="_nHeight">The Height(px) of the window. Minimum value is 100.</param>
    ''' <param name="_nWidth">The Width(px) of the window. Minimum value is 100.</param>
    ''' <param name="_nTop">The Top(px) position of the window.</param>
    ''' <param name="_nLeft">The Left(px) position of the window.</param>
    ''' <param name="_nFullScreen">Whether or not to display the browser in full-screen mode. (1|0|yes|no).</param>
    ''' <param name="_nLocation">Whether or not to display the address field. (1|0|yes|no).</param>
    ''' <param name="_nMenuBar">Whether or not to display the menu bar. (1|0|yes|no).</param>
    ''' <param name="_nResizable">Whether or not the window is resizable. (1|0|yes|no).</param>
    ''' <param name="_nScrollBars">Whether or not to display scroll bars. (1|0|yes|no).</param>
    ''' <param name="_nStatus">Whether or not to add a status bar. (1|0|yes|no).</param>
    ''' <param name="_nTitleBar">Whether or not to display the title bar. (1|0|yes|no).</param>
    ''' <param name="_nToolBar">Whether or not to display the browser toolbar. (1|0|yes|no).</param>
    ''' <param name="_nChannelMode">Whether or not to display the window in theater mode. (1|0|yes|no).</param>
    ''' <param name="_nDirectories">Whether or not to add directory buttons. (1|0|yes|no) (Obselete).</param>
    Public Shared Sub _pSubOpenInNewWindow(
        _nUrl As String,
        Optional _nTarget As String = Nothing,
        Optional _nHeight As String = Nothing,
        Optional _nWidth As String = Nothing,
        Optional _nTop As String = Nothing,
        Optional _nLeft As String = Nothing,
        Optional _nFullScreen As String = Nothing,
        Optional _nLocation As String = Nothing,
        Optional _nMenuBar As String = Nothing,
        Optional _nResizable As String = Nothing,
        Optional _nScrollBars As String = Nothing,
        Optional _nStatus As String = Nothing,
        Optional _nTitleBar As String = Nothing,
        Optional _nToolBar As String = Nothing,
        Optional _nChannelMode As String = Nothing,
        Optional _nDirectories As String = Nothing
        )
        Try
            '----------------------------------
            Select Case _nTarget
                Case "1"
                    _nTarget = "_blank"
                Case "2"
                    _nTarget = "_parent"
                Case "3"
                    _nTarget = "_self"
                Case "4"
                    _nTarget = "_top"
            End Select

            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            _nUrl = _nUrl.Replace("~", "")

            Dim _nSb As New StringBuilder
            _nSb.Append("<script type='text/javascript'>")
            _nSb.Append("window.open(")
            _nSb.Append("'" & _nUrl & "'")
            If _nTarget IsNot Nothing Then _nSb.Append(", '" & _nTarget & "'")

            Dim _nList As New List(Of String)

            If _nHeight IsNot Nothing Then _nList.Add("height=" & _nHeight)
            If _nWidth IsNot Nothing Then _nList.Add("width=" & _nWidth)
            If _nTop IsNot Nothing Then _nList.Add("top=" & _nTop)
            If _nLeft IsNot Nothing Then _nList.Add("left=" & _nLeft)
            If _nFullScreen IsNot Nothing Then _nList.Add("fullscreen=" & _nFullScreen) 'IE 
            If _nLocation IsNot Nothing Then _nList.Add("location=" & _nLocation) 'Opera 
            If _nMenuBar IsNot Nothing Then _nList.Add("menubar=" & _nMenuBar)
            If _nResizable IsNot Nothing Then _nList.Add("resizable=" & _nResizable) 'IE only
            If _nScrollBars IsNot Nothing Then _nList.Add("scrollbars=" & _nScrollBars) 'IE, Firefox, Opera 
            If _nStatus IsNot Nothing Then _nList.Add("status=" & _nStatus)
            If _nTitleBar IsNot Nothing Then _nList.Add("titlebar=" & _nTitleBar)
            If _nToolBar IsNot Nothing Then _nList.Add("toolbar=" & _nToolBar) 'IE, Firefox 
            If _nChannelMode IsNot Nothing Then _nList.Add("channelmode=" & _nChannelMode) 'IE 
            If _nDirectories IsNot Nothing Then _nList.Add("directories=" & _nDirectories) 'IE (Obselete)

            If _nList.Count <> 0 Then
                _nSb.Append(", '" & String.Join(",", _nList.ToArray) & "'")
            End If

            _nSb.Append(");")
            _nSb.Append("</script>")

            ScriptManager.RegisterClientScriptBlock(
                 _nPage,
                 _nPage.GetType,
                 _nPage.UniqueID,
                 _nSb.ToString,
                  False)

            'OK
            'RegisterStartupScript(
            '    _nPage,
            '    _nPage.GetType,
            '    _nPage.UniqueID,
            '    _nScript.ToString,
            '    False)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' This will enable getting new Captcha image
    ''' when Recaptcha is inside an Update Panel.
    ''' </summary>
    ''' <param name="_nReaptchaContainer">The Update Panel control containing the ReCaptcha control.</param>
    Public Shared Sub _pSubGetReCaptcha(
        _oRecaptchaContainer As Object
        )
        Try
            '----------------------------------
            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            Dim _nSb As New StringBuilder
            _nSb.Append(
               "Recaptcha._init_options(RecaptchaOptions);" & _
                "if ( RecaptchaOptions && ""custom"" == RecaptchaOptions.theme )" & _
                "{" & _
                "  if ( RecaptchaOptions.custom_theme_widget )" & _
                "  {" & _
                "    Recaptcha.widget = Recaptcha.$(RecaptchaOptions.custom_theme_widget);" & _
                "    Recaptcha.challenge_callback();" & _
                "  }" & _
                 "} else {" & _
                 "  if ( Recaptcha.widget == null || !document.getElementById(""recaptcha_widget_div"") )" & _
                 "  {" & _
                 "    jQuery(""#" & _
                 _oRecaptchaContainer.ClientID & _
                 """).html('<div id=""recaptcha_widget_div"" style=""display:none""></div>');" & _
                 "    Recaptcha.widget = Recaptcha.$(""recaptcha_widget_div"");" & _
                 "  }" & _
                 "  Recaptcha.reload();" & _
                 "  Recaptcha.challenge_callback();" & _
                 "}"
                 )

            ScriptManager.RegisterClientScriptBlock(
                _nPage,
                _nPage.GetType,
                _nPage.UniqueID,
                _nSb.ToString,
                True)

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

End Class
