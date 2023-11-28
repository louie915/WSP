Imports System.Net.Mail
Imports System.Net.Mime

Public Class PaymentNotification
    Inherits System.Web.UI.Page
    Dim StatusDesc As String = Nothing
    Dim statusID As String = Nothing
    Dim subject As String = Nothing
    Dim NumDesc As String = Nothing
    Dim acctno As String = Nothing
    Dim _nClass As New cDalPayment
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim Header_Data As Byte()
            Dim Header_Name As String
            Dim Header_Ext As String
            Dim HostURL As String
            If Request.Form("OriginURL").ToUpper.Contains("ENGINEERING") Then
                HostURL = (HttpContext.Current.Request.Url.AbsoluteUri).Replace(HttpContext.Current.Request.Url.AbsolutePath, "")
                HostURL += "/" & Request.Form("OriginURL")
            Else
                HostURL = Request.Form("OriginURL")
            End If

            cDalNewSendEmail.get_Header_DATA(Header_Data, Header_Name, Header_Ext)
            Dim Header_IMG As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
            Header_IMG.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(Header_Data)


            Response.Write("<div class='form-row form'>" & _
            "   <div class='col-sm-3'></div><div class='col-sm-6 form-group'> <center> " & _
            " <img   style='object-fit: contain;width:100%;float:right;border:2px solid white;' src='" & Header_IMG.ImageUrl & "' />" & _
            "</center> <br /><div class='card shadow'><div class='card-header' align='center'>" & _
            "<h5 class='m-0 font-weight-bold text-primary'>Payment Confirmation</h5>" & _
            "</div><div class='card-body'><div class='row'><div class='col-sm-12 form-group' align='center'>" & _
            "<table>")
            For Each key As String In Request.Form.Keys
                If Request.Form(key) <> Nothing Then
                    Response.Write("<tr>")
                    Response.Write("<td>")
                    Response.Write("<label class='m-0 font-weight-bold text-primary'>" & cPaymentParameters._ParamDisplay(key) & "</label>")
                    Response.Write("</td>")

                    Response.Write("<td>")
                    Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form(key) & "</label>")
                    Response.Write("</td>")
                    Response.Write("</tr>")
                End If
            Next
            Response.Write("</table>")
            Response.Write(" <label class='h5 m-0 font-weight-bold'>" & StatusDesc & "</label><br />")
            Response.Write("<br /><center><a href='" & HostURL & "' class='btn btn-primary col-lg-12'>Done</a></center>")
            Response.Write("</div></div></div></div></div>")

            ''@ADDED 20231006 LOUIE
            _oDivCourier.Visible = cCourier._Init_Courier(_oHl_Keri)
            ''@ADDED 20231006 LOUIE

        Catch ex As Exception

        End Try


    End Sub

    Sub old()

        Dim Header_Data As Byte()
        Dim Header_Name As String
        Dim Header_Ext As String
        cDalNewSendEmail.get_Header_DATA(Header_Data, Header_Name, Header_Ext)
        Dim Header_IMG As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
        Header_IMG.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(Header_Data)


        Response.Write("<div class='form-row form'>" & _
"   <div class='col-sm-3'></div><div class='col-sm-6 form-group'> <center> " & _
     " <img   style='object-fit: contain;width:100%;float:right;border:2px solid white;' src='" & Header_IMG.ImageUrl & "' />" & _
     "</center><br /><div class='card shadow'><div class='card-header' align='center'>" & _
"<h5 class='m-0 font-weight-bold text-primary'>Payment Confirmation</h5>" & _
"</div><div class='card-body'><div class='row'><div class='col-sm-12 form-group' align='center'>")

        If Request.Form("GateWayUsed") = "LBP" Then

            If Request.Form("Status") = "00" Then
                Response.Write("<label class='m-0 font-weight-bold text-primary'>MerchantRefNo</label><br />")
                Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form("MerchantRefNo") & "</label><br />")

                Response.Write("<label class='m-0 font-weight-bold text-primary'>EppRefNo</label><br />")
                Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form("EppRefNo") & "</label><br />")

                Response.Write("<label class='m-0 font-weight-bold text-primary'>Amount</label><br />")
                Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form("Amount") & "</label><br />")

                Response.Write("<label class='m-0 font-weight-bold text-primary'>PaymentOption</label><br />")
                Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form("PaymentOption") & "</label><br />")

                Response.Write("<label class='m-0 font-weight-bold text-primary'>Datestamp</label><br />")
                Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form("Datestamp") & "</label><br />")
            Else
                For Each key As String In Request.Form.Keys
                    If Request.Form(key) <> Nothing And key <> "Status" Then
                        Response.Write("<label class='m-0 font-weight-bold text-primary'>" & key & "</label><br />")
                        Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form(key) & "</label><br />")
                    End If
                Next
            End If

        ElseIf Request.Form("GateWayUsed") = "DBP" Then
            StatusDesc = Request.Form("message")
            For Each key As String In Request.Form.Keys
                If Request.Form(key) <> Nothing Then
                    Response.Write("<label class='m-0 font-weight-bold text-primary'>" & key & "</label><br />")
                    Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form(key) & "</label><br />")
                End If
            Next

        ElseIf Request.Form("GateWayUsed") = "GCASH" Then
            StatusDesc = Request.Form("message")
            For Each key As String In Request.Form.Keys
                If Request.Form(key) <> Nothing Then
                    Response.Write("<label class='m-0 font-weight-bold text-primary'>" & key & "</label><br />")
                    Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form(key) & "</label><br />")
                End If
            Next

        Else
            For Each key As String In Request.Form.Keys
                If Request.Form(key) <> Nothing Then
                    Response.Write("<label class='m-0 font-weight-bold text-primary'>" & key & "</label><br />")
                    Response.Write(" <label class='h5 m-0 font-weight-bold'>" & Request.Form(key) & "</label><br />")
                End If
            Next
        End If

        Response.Write("<label class='m-0 font-weight-bold text-primary'>Status</label><br />")
        If Request.Form("GateWayUsed") = "LBP2" Then
            StatusDesc = Request.Form("Status")
        Else
            get_statusDesc()
        End If

        Response.Write(" <label class='h5 m-0 font-weight-bold'>" & StatusDesc & "</label><br />")
        Response.Write("<br /><center><a href='WebPortal/Account.aspx'>Done</a></center>")
        Response.Write("</div></div></div></div></div>")

    End Sub
    Sub get_statusDesc()
        Select Case Request.Form("Status")
            Case "00"
                StatusDesc = "Successful"
            Case "01"
                StatusDesc = "Invalid merchant code"
            Case "02"
                StatusDesc = "Invalid merchant reference number"
            Case "03"
                StatusDesc = "0 or negative amount"
            Case "04"
                StatusDesc = "Null payors name"
            Case "05"
                StatusDesc = "Null returnURLok"
            Case "06"
                StatusDesc = "Null returnURLerror"
            Case "07"
                StatusDesc = "invalid(hash)"
            Case "08"
                StatusDesc = "Service unavailable"
            Case "09"
                StatusDesc = "Transaction in process"
            Case "10"
                StatusDesc = "Cancelled transaction"
            Case "11"
                StatusDesc = "EPP offline"
            Case "12"
                StatusDesc = "Invalid transaction type"
            Case "13"
                StatusDesc = "invalid(Particulars)"
            Case "14"
                StatusDesc = "Duplicate transaction"
        End Select
        Return
    End Sub
End Class