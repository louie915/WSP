
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization
Imports System.Net

Public Class BPLOPermitView
    Inherits System.Web.UI.Page
    Public Shared xFileData As Byte()
    Public Shared xFileData64 As String
    Public Shared xFileName As String
    Public Shared xFileData2 As Byte()
    Public Shared xFileName2 As String
    Public Shared n_BRGY As String
    Public Shared n_MPDO As String
    Public Shared n_ENGG As String
    Public Shared n_HO As String
    Public Shared n_CENRO As String
    Public Shared n_FIRE As String
    Public Shared ACCTNO As String
    Dim Email As String
    Dim AppID As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack Then

            Else
                get_BusinessPermit()
                get_ClearanceNo()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub get_BusinessPermit()
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS_F
        _nClass._pSubSelectBP_Permit(ACCTNO, xFileData, xFileData64, xFileName)
        xFileData64 = "data:image/jpeg;base64," & xFileData64
        myimage.Attributes.Add("src", xFileData64)
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubGetAppidEmail(ACCTNO, AppID, Email)
    End Sub
    Sub get_ClearanceNo()
        Dim clearance_no As String = Nothing
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectClearanceNo(ACCTNO, clearance_no)
        hdn_Clearances.Value = clearance_no
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

    Private Sub btn_Send_ServerClick(sender As Object, e As EventArgs) Handles btn_Send.ServerClick
        Dim sent As Boolean = Nothing
        Dim body As String = Nothing

        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS_F
        _nClass._pSubSelectBP_Permit(ACCTNO, xFileData, xFileData64, xFileName)

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubGetAppidEmail(ACCTNO, AppID, Email)



      
        If OR_upload.PostedFile IsNot Nothing Then
            If OR_upload.PostedFile.ContentLength > 0 Then
                Dim FileData As HttpPostedFile = OR_upload.PostedFile
                xFileName2 = OR_upload.PostedFile.FileName
                Dim fs As Stream = FileData.InputStream
                Dim br As New BinaryReader(fs)
                xFileData2 = br.ReadBytes(Convert.ToInt32(fs.Length))
            End If
        End If

        body = txtContent.Value.Replace(Environment.NewLine, " <br> ")

        cDalNewSendEmail.SendEmailwithAttachment(Email, txtSubject.Value, body, sent, xFileData, xFileName, xFileData2, xFileName2)
        If sent = True Then
            snackbar("green", "Notification has been sent")
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS


        Else
            snackbar("red", "Failed to send Email Notification")
        End If
    End Sub
End Class