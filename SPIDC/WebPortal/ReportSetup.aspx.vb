Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Net.Mime

Public Class ReportSetup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

            Else
                '      
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub PreviewEmail(ByVal [ModuleCode] As String, ByVal [Receiver] As String)
        Dim [ModuleDesc] As String = Nothing
        Dim [Subject] As String = Nothing
        Dim [Header] As String = Nothing
        Dim [Body] As String = Nothing
        Dim [Footer] As String = Nothing
        Dim [Description] As String = Nothing
        Dim _nclass As New cDalNewSendEmail
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nclass.SelectEmailSetup([ModuleCode], [ModuleDesc], [Receiver], [Subject], [Header], [Body], [Footer], [Description])

        txtSubject.Value = [Subject]
        txtHeader.Value = [Header]
        txtBody.Value = [Body]
        txtFooter.Value = [Footer]
        ' txtDescription.value = [Description]

        Dim EmailContent As String = [Header] & "</br></br>" & [Body] & "</br>" & [Footer] & "</br>"

        Dim TN As String = "<b>SAMPLE TAXPAYER NAME</b>"
        Dim VL As String = "<a href='Register.aspx'> <u> //Sample Verification Link </u> </a>"
        Dim VB As String = "<a href='Register.aspx' target='_blank' style='text-decoration:none;display: block;width: 200px;height: 40px;background: @CLR;padding: 10px;text-align: center;border-radius: 5px;color: white;font-weight: bold;line-height: 25px;'> Click to Verify </a>"
        Dim CLR As String = "#4768D3"
        Dim TDN As String = "<b>TDN-00000</b>"
        Dim BIN As String = "<b>BIN-00000</b>"
        Dim RMK As String = "<b>SAMPLE REMARKS</b>"
        Dim EA As String = "<b>Sample@Email.com</b>"
        Dim AI As String = "<b>AppID-00000</b>"

        EmailContent = Replace(EmailContent, "@VL", VL)
        EmailContent = Replace(EmailContent, "@VB", VB)
        EmailContent = Replace(EmailContent, "@TN", TN)
        EmailContent = Replace(EmailContent, "@TDN", TDN)
        EmailContent = Replace(EmailContent, "@BIN", BIN)
        EmailContent = Replace(EmailContent, "@RMK", RMK)
        EmailContent = Replace(EmailContent, "@EA", EA)
        EmailContent = Replace(EmailContent, "@AI", AI)

        Dim Logo_Data As Byte()
        Dim Logo_Name As String
        Dim Logo_Ext As String
        Dim LoginURL As String = "https://online.spidc.com.ph/cainta/"

        cDalNewSendEmail.get_Header_DATA(Logo_Data, Logo_Name, Logo_Ext)

        Dim Logo_IMG As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
        Logo_IMG.ImageUrl = "data:" & Logo_Ext & ";base64," & Convert.ToBase64String(Logo_Data)

        divPreview.InnerHtml =
         "<center style='font-size:x-large;'> " & _
         "  <div style='border:2px solid white;background-color:#EAEAEA;font-family:calibri;padding:20px';>" & _
         "  <div class='panel1'>" & _
         "  <div style='font-size:large;padding:5px;border:2px solid white;color:white;background-color:@CLR'>" & _
         " <img   style='object-fit: contain;width:100%;' src='" & Logo_IMG.ImageUrl & "'/>" & _
         "  <p><strong>" & _
         Subject & _
         "  </strong> </p>" & _
         "  <div style='text-align:left;padding:10px;background-color:white;color:black;'>" & _
         EmailContent & _
         "<a href='" & LoginURL & "'" & " target='_blank' style='text-decoration:none;display: block;width: 200px;height: 40px;background: @CLR;padding: 10px;text-align: center;border-radius: 5px;color: white;font-weight: bold;line-height: 25px;'> Visit Web Service Portal </a><br/><br/>" & _
         "  </div>*** This is an electronic message please do not reply ***<div></div></div></center>"

        'Default Theme
        Session("divPreview") = divPreview.InnerHtml
        divPreview.InnerHtml = Replace(divPreview.InnerHtml, "@CLR", CLR)
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


    Private Sub btnModule_ServerClick(sender As Object, e As EventArgs) Handles btnModule.ServerClick
        Dim Receiver As String = hdnReceiver.Value
        Dim ModuleCode As String = hdnModule.Value
        PreviewEmail(ModuleCode, Receiver)
    End Sub


    Private Sub btnColor_ServerClick(sender As Object, e As EventArgs) Handles btnColor.ServerClick
        divPreview.InnerHtml = Replace(Session("divPreview"), "@CLR", hdnColor.Value)
    End Sub
End Class