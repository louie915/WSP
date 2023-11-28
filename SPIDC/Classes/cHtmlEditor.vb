

#Region "Imports"

Imports System.Reflection.MethodBase
Imports System.Web.HttpContext
Imports System.Web
Imports System.Web.UI
Imports _oSm = System.Web.UI.ScriptManager
Imports System.Web.UI.WebControls
Imports System.Text

#End Region

Public Class cHtmlEditor

    'NOTE:
    'If Icons are not showing, Place the js near the Form.

#Region "Variables"

    Private Shared _mPrefix As String = GetCurrentMethod.DeclaringType.FullName

#End Region

    ''' <summary>
    ''' Configure the Control as Html Editor in Basic Mode.
    ''' </summary>
    ''' <param name="_oControl">The control to convert as Html Editor.</param>
    ''' <param name="_nReadOnly">if set to <c>true</c> [Html Editor is read only].</param>
    ''' <param name="_nInitialize">if set to <c>true</c> [Html Editor is initialized].</param>
    Public Shared Sub _pSubAdd_HtmlEditor_Basic(
        _oControl As Object,
        Optional _nReadOnly As Boolean = False,
        Optional _nInitialize As Boolean = False
        )
        Try
            '----------------------------------
            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            Dim _nSb As New StringBuilder
            _nSb.Append(
                "<script type='text/javascript'>" &
                "" &
                "   function EditorInitialize() {" &
                "       tinymce.init({ " &
                "   /* selector : 'textarea#" & _oControl.ClientID & "' */ " &
                "   mode : 'exact' " &
                "   , elements : '" & _oControl.ClientID & "' " &
                "   , toolbar_items_size : 'small' " &
                "   , elementpath : false " &
                "   , readonly : " & _nReadOnly.ToString.ToLower & " " &
                "   , setup: function (editor) { " &
                "       editor.on('change', function (editor) {    " &
                "           document.getElementById('" & _oControl.ClientID & "').value " &
                "               = editor.target.getContent();  " &
                "       }); " &
                "   }" &
                "" &
                "       });" &
                "   }" &
                "" &
                "   function EditorRemove() { " &
                "       tinyMCE.execCommand('mceFocus', false, '" & _oControl.ClientID & "');" &
                "       tinyMCE.execCommand('mceRemoveEditor', false, '" & _oControl.ClientID & "');" &
                "   }" &
                "" &
                "   function EditorAdd() { " &
                "       tinyMCE.execCommand('mceAddEditor', false, '" & _oControl.ClientID & "'); " &
                "   } " &
                "" &
                "   function EditorSave() { " &
                "       tinyMCE.execCommand('mceSave'); " &
                "   } " &
                "" &
                "   function EditorTriggerSave() { " &
                "       tinyMCE.triggerSave(false, true); " &
                "   }" &
                "" &
                "</script>"
                )


            ScriptManager.RegisterClientScriptBlock(
                _nPage,
                _nPage.GetType,
                _nPage.UniqueID & _oControl.UniqueID,
                _nSb.ToString,
                False)

            ScriptManager.RegisterClientScriptBlock(
                _nPage,
                _nPage.GetType,
                _nPage.UniqueID & "EditorInitialize",
                "EditorInitialize();",
                True)

            If Not _nInitialize Then

                ScriptManager.RegisterClientScriptBlock(
                    _nPage,
                    _nPage.GetType,
                    _nPage.UniqueID & "EditorRemove",
                    "EditorRemove();",
                    True)

                ScriptManager.RegisterClientScriptBlock(
                    _nPage,
                    _nPage.GetType,
                    _nPage.UniqueID & "EditorAdd",
                    "EditorAdd();",
                    True)

            End If

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Configure the Control as Html Editor in Advance Mode.
    ''' </summary>
    ''' <param name="_oControl">The control to convert as Html Editor.</param>
    ''' <param name="_nReadOnly">if set to <c>true</c> [Html Editor is read only].</param>
    ''' <param name="_nInitialize">if set to <c>true</c> [Html Editor is initialized].</param>
    Public Shared Sub _pSubAdd_HtmlEditor_Advance(
        _oControl As Object,
        Optional _nReadOnly As Boolean = False,
        Optional _nInitialize As Boolean = False
        )
        Try
            '----------------------------------
            Dim _nPage As Page = DirectCast(HttpContext.Current.Handler, Page)

            Dim _nSb As New StringBuilder
            _nSb.Append(
                "<script type='text/javascript'>" &
                "   function EditorInitialize() {" &
                "       tinymce.init({ " &
                "    mode : 'exact' " &
                "   , elements : '" & _oControl.ClientID & "' " &
                "   , toolbar_items_size : 'small' " &
                "   , elementpath : false /* disable the element path within the status bar at the bottom of the editor. */ " &
                "   , readonly : " & _nReadOnly.ToString.ToLower & " " &
                "   /*, inline : true */ " &
                "   /*, contenteditable : false */ " &
                "   /*, image_advtab : true */ " &
                "   /*, menubar : false */ " &
                "   /*, statusbar : false */ " &
                "   /*, dialog_type : 'modal' */ " &
                "   /*, theme : 'modern' */ " &
                "   , setup: function (editor) { " &
                "       editor.on('change', function (editor) {    " &
                "           document.getElementById('" & _oControl.ClientID & "').value " &
                "               = editor.target.getContent();  " &
                "       }); " &
                "   }" &
                "" &
                "   , plugins : " &
                "       [" &
                "       ' advlist ' /* extends the core bullist and numlist toolbar */ " &
                "       , ' anchor ' /* adds an anchor/bookmark button to the toolbar */ " &
                "       , ' autolink ' /* automatically creates hyperlinks when a user inputs a valid, complete URL */ " &
                "       /*, ' autoresize ' */ /* automatically resizes the editor to the content inside it */ " &
                "       , ' autosave ' /* gives the user a warning if they made modifications to the content within an editor instance but didn't submit the changes */ " &
                "       /*, ' bbcode ' */ /* makes it possible for editor to edit BBCode syntax in a WYSIWYG form by converting tags like [b] into <strong> and then <strong> back to [b] when the user submits the content */ " &
                "       , ' charmap ' /* adds a charmap toolbar button that enables users to insert special characters into their text */ " &
                "       , ' code ' /* adds a toolbar button that allows a user to edit the HTML code hidden by the WYSIWYG view */ " &
                "       , ' codesample ' /* lets a user insert and embed syntax color highlighted code snippets into the editable area */ " &
                "       , ' colorpicker ' /* adds an HSV color picker dialog to the editor (in conjunction with the textcolor plugin) */ " &
                "       , ' contextmenu ' /* adds a configurable context menu that appears when a user (typically) right clicks in the editable area */ " &
                "       , ' directionality ' /* adds directionality controls to the toolbar, enabling TinyMCE to better handle languages written from right to left */ " &
                "       , ' emoticons ' /* adds a toolbar control that lets users insert smiley images into TinyMCE's editable area */ " &
                "       , ' fullpage ' /* allows a user to edit certain document properties (such as title, keywords, description) via a dialog box after pressing a control added to the toolbar */ " &
                "       , ' fullscreen ' /* adds full screen editing capabilities */ " &
                "       , ' hr ' /* allows a user to insert a horizontal rule on the page at the cursor insertion point */ " &
                "       , ' image ' /* enables the user to insert an image into TinyMCE's editable area */ " &
                "       , ' imagetools ' /* adds a contextual image editing toolbar to images inserted into the editable area */ " &
                "       /*, ' importcss ' */ /* adds the ability to automatically import CSS classes from the CSS file specified in the content_css configuration setting */ " &
                "       , ' insertdatetime ' /* provides a toolbar control and menu item Insert date/time (under the Insert menu) that lets a user easily insert the current date and/or time into the editable area at the cursor insertion point */ " &
                "       /*, ' layer ' */ /* adds some layer controls. It only works on some browsers and will probably be removed in the future */ " &
                "       /*, ' legacyoutput ' */ /* changes TinyMCE's output, producing legacy elements such as font, b, i, u, strike and use align attributes */ " &
                "       , ' link ' /* allows a user to link external resources, such as website URLs, to selected text in their document */ " &
                "       , ' lists ' /* normalizes list behavior between browsers. Enable it if you have problems with consistency making lists */ " &
                "       , ' media ' /* adds the ability for users to be able to add HTML5 video and audio elements to the editable area */ " &
                "       /*, ' MoxieManager ' */ /* premium upgrade) enables users to insert files located externally to the editor (e.g. on their client desktop) into their document */ " &
                "       , ' nonbreaking ' /* adds a button for inserting nonbreaking space entities &nbsp; at the current caret location (cursor insert point) */ " &
                "       /*, ' noneditable ' */ /* enables you to prevent users from being able to change (i.e. edit) content within elements assigned the mceNonEditable class */ " &
                "       , ' pagebreak ' /* adds page break support and enables a user to insert page breaks in the editable area */ " &
                "       , ' paste ' /* will filter/cleanup content pasted from Microsoft Word */ " &
                "       /*, ' powerpaste ' */ /* premium upgrade) automatically cleans up content from Microsoft Word and other HTML sources to ensure clean, compliant content that matches the look and feel of the site  */" &
                "       , ' preview ' /* adds a preview button to the toolbar. Pressing the button opens a dialog box showing the current content in a preview mode */ " &
                "       , ' print ' /* adds a print button to the toolbar */ " &
                "       /*, ' save ' */ /* adds a save button to the TinyMCE toolbar */ " &
                "       , ' searchreplace ' /* adds search/replace dialogs to TinyMCE */ " &
                "       , ' spellchecker ' /*  enables spellcheck functionality  */ " &
                "       /*, ' spellcheckerpro ' */ /* (premium upgrade) adds spell check as-you-type capabilities */ " &
                "       /*, ' tabfocus ' */ /* adds the possibility to tab in/out of the editor */ " &
                "       , ' table ' /* adds table management functionality */  " &
                "       , ' template ' /* adds support for custom templates */ " &
                "       , ' textcolor ' /* adds the forecolor/backcolor button controls that enable you to pick colors from a color picker and apply these to text */ " &
                "       , ' textpattern ' /* matches special patterns in the text and applies formats or executed commands on these patterns */ " &
                "       , ' visualblocks ' /* allows a user to see block level elements in the editable area */ " &
                "       , ' visualchars ' /* adds the ability for users to see invisible characters like &nbsp; displayed in the editable area */ " &
                "       , ' wordcount ' /* adds word count functionality */ " &
                "       ]" &
                "" &
                "   , toolbar1 : " &
                "       '| newdocument searchreplace | cut copy paste | undo redo ' " &
                "       + '| print fullpage fullscreen preview ' " &
                "       + '| spellchecker ' " &
                "       + '| link unlink anchor image media insertdatetime ' " &
                "" &
                "   , toolbar2 : " &
                "       '| bold italic underline strikethrough ' " &
                "       + '| alignleft aligncenter alignright alignjustify '   " &
                "       + '| styleselect formatselect fontselect fontsizeselect ' " &
                "       + '| forecolor backcolor ' " &
                "" &
                "   , toolbar3 : " &
                "       '| table | hr removeformat | subscript superscript ' " &
                "       + '| charmap emoticons ' " &
                "       + '| bullist numlist | outdent indent blockquote' " &
                "       + '| ltr rtl  ' " &
                "       + '| visualchars visualblocks nonbreaking template pagebreak restoredraft code ' " &
                "" &
                "       });" &
                "   }" &
                "" &
                "   function EditorRemove() { " &
                "       tinyMCE.execCommand('mceFocus', false, '" & _oControl.ClientID & "');" &
                "       tinyMCE.execCommand('mceRemoveEditor', false, '" & _oControl.ClientID & "');" &
                "   }" &
                "" &
                "   function EditorAdd() { " &
                "       tinyMCE.execCommand('mceAddEditor', false, '" & _oControl.ClientID & "'); " &
                "   } " &
                "" &
                "   function EditorSave() { " &
                "       tinyMCE.execCommand('mceSave'); " &
                "   } " &
                "" &
                "   function EditorTriggerSave() { " &
                "       tinyMCE.triggerSave(false, true); " &
                "   }" &
                "" &
                "</script>"
                )

            ScriptManager.RegisterClientScriptBlock(
                _nPage,
                _nPage.GetType,
                _nPage.UniqueID & _oControl.UniqueID,
                _nSb.ToString,
                False)

            ScriptManager.RegisterClientScriptBlock(
                _nPage,
                _nPage.GetType,
                _nPage.UniqueID & "EditorInitialize",
                "EditorInitialize();",
                True)

            If Not _nInitialize Then

                ScriptManager.RegisterClientScriptBlock(
                    _nPage,
                    _nPage.GetType,
                    _nPage.UniqueID & "EditorRemove",
                    "EditorRemove();",
                    True)

                ScriptManager.RegisterClientScriptBlock(
                    _nPage,
                    _nPage.GetType,
                    _nPage.UniqueID & "EditorAdd",
                    "EditorAdd();",
                    True)

            End If

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub


End Class
