
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization
Imports System.Net

Public Class BPLODirectEnrollment
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack Then

            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _btnSearch_ServerClick(sender As Object, e As EventArgs) Handles _btnSearch.ServerClick
        cSessionLoader._pAccountNo = Trim(txtBIN.Value)

        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        lblBIN.Value = Nothing
        lblDateEsta.Value = Nothing
        lblBusName.Value = Nothing
        lblBusAddress.Value = Nothing
        lblOwnerName.Value = Nothing
        lblOwnerAddress.Value = Nothing
        lblOwnershipType.Value = Nothing

        If _nClass._isValid(cSessionLoader._pAccountNo, lblDateEsta.Value, lblBusName.Value, lblOwnershipType.Value, lblBusAddress.Value, lblOwnerName.Value, lblOwnerAddress.Value) = True Then
            lblBIN.Value = cSessionLoader._pAccountNo
            div_BusInfo.Style.Add("display", "")
            lbl_Invalid.Style.Add("display", "none")
            Dim ENROLLED_EMAIL As String = Nothing
            div_Notice.Attributes("class") = ""

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            Load_Busline(cSessionLoader._pAccountNo, _GVBusinessLine)

            If _nClass._isEnrolled(cSessionLoader._pAccountNo, ENROLLED_EMAIL) = True Then
                div_Notice.Attributes.Add("class", "w3-pale-yellow col-sm-12")
                div_Notice.InnerText = "This BIN is already Enrolled to : " & ENROLLED_EMAIL
                div_Enroll.Style.Add("display", "none")
            Else
                div_Notice.Attributes.Add("class", "w3-pale-green col-sm-12")
                div_Notice.InnerText = "This BIN is available for Enrollment"
                div_Enroll.Style.Add("display", "")
            End If


        Else
            div_BusInfo.Style.Add("display", "none")
            lbl_Invalid.Style.Add("display", "")


        End If
    End Sub

    Sub Load_Busline(ByVal Acctno As String, ByVal gvName As GridView)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubGetBusLine_Enroll(Acctno)
            gvName.DataSource = _nClass._mDataTable
            gvName.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub _btnEnrollNow_ServerClick(sender As Object, e As EventArgs) Handles _btnEnrollNow.ServerClick
        Dim strErr As String
        Dim _nClass As New cDalBPSOS
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        If _nClass._DirectEnroll(cSessionLoader._pAccountNo, txtEmail.Value, strErr) = True Then
            'enroll ok          
            Dim email As String = txtEmail.Value
            Dim subject As String = "Business Enrollment"
            Dim body As String =
                "To our Valued Taxpayer,</br></br>" & _
                "We are happy to inform you that your online enrollment application for Business Account No.: [" & cSessionLoader._pAccountNo & "] has been verified and approved. You may now Register on our Web Service Portal for Online Transactions <br>" & _
                "• Business Renewal <br>" & _
                "• Registration of New Business <br>" & _
                "• Appointment <br>" & _
                "<br>"

            Dim sent As Boolean = False
            cDalNewSendEmail.SendEmail(email, subject, body, sent)
            Dim msg As String
            If sent = True Then
                div_BusInfo.Style.Add("display", "none")
                lbl_Invalid.Style.Add("display", "")
                txtEmail.Value = Nothing
                msg = "Enrollment Success. Email has been sent to Taxpayer Email Address"
            Else
                msg = "Enrollment Success. "
            End If
            Response.Write("<script>")
            Response.Write(msg)
            Response.Write("</script>")
        Else

            err.Value = strErr
            'enroll failed
        End If
    End Sub
End Class