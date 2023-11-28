#Region "IMPORTS REGION"
Imports System.Data.SqlClient

Imports Microsoft.Reporting.WebForms
Imports System
Imports System.IO

Imports System.Net
Imports System.Net.Mail
Imports SPIDC.Resources

#End Region

Public Class Permit
    Inherits System.Web.UI.Page

#Region "VARIABLES REGION"
    Dim CDL As New cDalPermit
    Dim accNo As String = "04-001406"

    Private _mSqlCommanStoredProc As New SqlCommand
    Private _mSqlCon As New SqlConnection

    Private tempPermit As String
    Private tempByteNo As String
    Private STATUS As String = Nothing
    Private BAN As String = Nothing
    Private Date_Issuance As String = Nothing
    Private Date_Expire As String = Nothing
    Private OR_No As String = Nothing
    Private OR_Date As String = Nothing
    Private Amount_Paid As String = Nothing
    Private Taxpayer_Name As String = Nothing
    Private Business_Name As String = Nothing
    Private Nature_Business As String = Nothing
    Private Address As String = Nothing

    Private FORYEAR As Integer = DateTime.Now.Year
    Private myByte As Byte()
#End Region

#Region "ACTIONS"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GenerateDisplayTempPermit()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub GenerateDisplayTempPermit()
        Dim script As String = Nothing

        _GeneratePermit(cSessionLoader._pAccountNo)

        script = "if (document.getElementById('ContentPlaceHolder1_SendEmailButton')) { setTimeout(function () {document.getElementById('ContentPlaceHolder1_SendEmailButton').click() } , 5000); }"

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ClickButtonScript", script, True)

    End Sub

    'Private Sub SendEmailButton_ServerClick(sender As Object, e As EventArgs) Handles SendEmailButton.ServerClick

    '    Dim sent As Boolean


    '    Export()



    '    If sent = True Then

    '        '-alert successfully send
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alert", "alert('Successfully Sent!')", True)
    '    Else
    '        '-alert failed send
    '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Alert", "alert('Sending Failed! Please press print again!!')", True)

    '    End If

    'End Sub
#End Region

#Region "FUNCTIONS REGION"
    Public Sub _GeneratePermit(ByVal Acctno As String) 'Showing Permit Parameters in Report
        Try
            'If IsPostBack Then Exit Sub

            Dim table As String = "PAYFILE LEFT OUTER JOIN BUSMAST ON PAYFILE.ACCTNO = BUSMAST.ACCTNO"
            Dim condition As String = "BUSMAST.ACCTNO = '" & Acctno & "' AND FORYEAR = '" & FORYEAR & "' "
            tempPermit = _GenTempPermitNum()

            ' Create a list of ReportParameters
            Dim paramList As New List(Of ReportParameter)

            ' Retrieve values for report parameters

            STATUS = CDL.getRowPermit("STATCODE", "(SELECT statdesc FROM STATCODE WHERE STATCODE = BUSMAST.STATCODE) AS STATCODE", table, condition)
            BAN = CDL.getRowPermit("BAN", "BUSMAST.ACCTNO AS BAN", table, condition)
            Date_Issuance = CDL.getRowPermit("ISSUANCEDATE", "CONVERT(NVARCHAR(20),GETDATE(),107) AS ISSUANCEDATE", table, condition)
            Date_Expire = CDL.getRowPermit("DATE_EXPIRED", "CONVERT(NVARCHAR(20), DATEADD(DAY, 30, GETDATE()), 107) AS DATE_EXPIRED", table, condition)
            OR_No = CDL.getRowPermit("OR_NO", "PAYFILE.ORNO AS OR_NO", table, condition)
            OR_Date = CDL.getRowPermit("ORDATE", "CONVERT(NVARCHAR(20),PAYFILE.ORDATE,107) AS ORDATE", table, condition)
            Amount_Paid = CDL.getRowPermit("TOTALPAID", "(SELECT CONVERT(varchar, CAST( SUM(stamt) AS money), 1) FROM [vw_PayfileSummary_Tanay] WHERE ORNO = PAYFILE.ORNO AND FORYEAR = PAYFILE.FORYEAR) AS TOTALPAID", table, condition)
            Taxpayer_Name = CDL.getRowPermit("OwnerName", "ISNULL(BUSMAST.LAST_NAME, '') + ISNULL(',  ' + BUSMAST.FIRST_NAME, '') + ISNULL('  ' + BUSMAST.MIDDLE_NAME, '') AS OwnerName, ISNULL(BUSMAST.FIRST_NAME, '') + ISNULL('  ' + BUSMAST.MIDDLE_NAME, '') + ISNULL('  ' + BUSMAST.LAST_NAME, '') AS OwnerName1", table, condition)
            Business_Name = CDL.getRowPermit("COMMERCIALNAME", "BUSMAST.COMMNAME AS COMMERCIALNAME", table, condition)
            Nature_Business = CDL.getRowPermit("BusinessLine", "[dbo].[Get_LOB_PAYFILE](BUSMAST.ACCTNO, PAYFILE.FORYEAR, PAYFILE.ORNO, '0') as [BusinessLine]", table, condition)
            Address = CDL.getRowPermit("COMMERCIALADDRESS", "BUSMAST.COMMADDR AS COMMERCIALADDRESS", table, condition)

            ' Add report parameters to the list
            paramList.Add(New ReportParameter("Status", STATUS))
            paramList.Add(New ReportParameter("BAN", BAN))
            paramList.Add(New ReportParameter("Date_Issuance", Date_Issuance))
            paramList.Add(New ReportParameter("Date_Expire", Date_Expire))
            paramList.Add(New ReportParameter("OR_No", OR_No))
            paramList.Add(New ReportParameter("OR_Date", OR_Date))
            paramList.Add(New ReportParameter("Amount_Paid", Amount_Paid))
            paramList.Add(New ReportParameter("Temp_Permit_No", "Temp Permit No: " & tempPermit))
            cSessionLoader._pTemporaryPermitNo = tempPermit
            paramList.Add(New ReportParameter("Taxpayer_Name", Taxpayer_Name))
            paramList.Add(New ReportParameter("Business_Name", Business_Name))
            paramList.Add(New ReportParameter("Nature_Business", Nature_Business))
            paramList.Add(New ReportParameter("Address", Address))


            ' Optionally, enable other report settings
            _oMSRV.LocalReport.ReportPath = _gResxRdlc.pPermit2
            _oMSRV.LocalReport.EnableExternalImages = True
            _oMSRV.LocalReport.DataSources.Clear()

            ' Set report parameters
            _oMSRV.LocalReport.SetParameters(paramList)


            myByte = _oMSRV.LocalReport.Render("PDF")
            ' Refresh the report
            _oMSRV.AsyncRendering = True
            _oMSRV.LocalReport.Refresh()
            _oMSRV.Enabled = True


            SavePermit()

            Dim IsaveImage As Boolean = exportToByte()


            'Dim pdfBytes As Byte() = _oMSRV.LocalReport.Render("PDF")

            FORYEAR = Nothing

        Catch ex As Exception
            'Err.Value = err_indicator & ":" & ex.Message
        End Try
    End Sub
    Public Sub SavePermit() 'Saving Report Permit to Database
        Try
            Dim _nQuery As String = Nothing
            _nQuery = " insert into  BUSINESSPERMITTEMP (PERMITNO,ACCTNO,FORYEAR,ISSUANCEDATE,DATEPAID,ORNO,ORDATE) values ('" & tempPermit & "','" & BAN & "', '" & FORYEAR & "', '" & Date_Issuance & "', '" & Date_Issuance & "', '" & OR_No & "' ,  '" & OR_Date & "') "
            Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            ' = ex.Message
        End Try
    End Sub
    Private Function exportToByte() 'Saving Image Byte to Database
        tempByteNo = _GenNewxFileNo()

        Try
            If myByte.Length > 0 Then

                Dim newFileName As String = "BP_LPWEB" & tempByteNo & "-" & BAN & "-" & "user" & DateTime.Now.ToString("MMddyyyyHHmmss") & ".JPG" '2023-10-000001
                Dim _nQuery2 As String =
             "INSERT INTO " &
             " [BUSINESSPERMITTEMPGENIMAGEBYTES] " &
             " ([xFileNo] " &
             " ,[xFileName] " &
             " ,[AcctNo] " &
             " ,[ForYear] " &
             " ,[ARXFile]) " &
             " " &
            "VALUES " &
            " ( @xFileNo " &
            " , @xFileName " &
            " , @AcctNo " &
            " , @ForYear " &
            " , @ARXFile)" &
            " ; "
                '----------------------------------

                '----------------------------------
                Dim _nSqlCommand As New SqlCommand(_nQuery2, cGlobalConnections._pSqlCxn_BPLTAS)

                With _nSqlCommand.Parameters

                    .AddWithValue("@xFileNo", tempByteNo)
                    .AddWithValue("@xFileName", newFileName)
                    .AddWithValue("@AcctNo", BAN)
                    .AddWithValue("@ForYear", FORYEAR)
                    .Add("@ARXFile", SqlDbType.VarBinary, myByte.Length).Value = myByte
                End With
                _nSqlCommand.ExecuteNonQuery()

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub Notify_Taxpayer(ByVal AccNo As String, ByRef sent As Boolean) 'Notify Taxpayer in Email

        Dim mailTempPermitNo As String = CDL.getRowPermit("PERMITNO", " TOP 1 PERMITNO", "BUSINESSPERMITTEMP", "ACCTNO = '" & AccNo & "' ORDER BY PERMITNO DESC")
        ' Set up the email message

        Dim clr As String = "CornflowerBlue"
        Dim subjtype As String = "TEMPORARY PERMIT NOTICE"
        Dim emailsubj As String = "TEMPORARY PERMIT NOTICE"
        Dim emailbody As String = "To our Valued Taxpayer," &
        "<br>" &
        "Please be informed that your Temporary Permit<b> </b> No. <b> " & cSessionLoader._pTemporaryPermitNo & " </b>" &
        "is released But subject to actual Verification/Validation & Conduct of Business Operation ." &
        "<br> Thank you. <br>" &
        "<br>"

        Dim picfiller As String = Nothing
        Dim loginURL As String = Nothing
        Dim Footer As String = Nothing


        Dim mail As New MailMessage()
        mail.From = New MailAddress("noreply.spidc@gmail.com")
        mail.[To].Add(cSessionUser._pUserID)
        mail.Subject = emailsubj
        mail.Body = " <style>.panel1{color:black; width:60%;}" &
                   " @media screen and (max-width: 360px) {.panel1 {width: width:100%;}}" &
                   " </style>" &
                   " <center style='font-size:x-large;'> " &
                   " <div style='border:2px solid white;background-color:#EAEAEA;font-family:calibri;padding:20px';>" &
                   " <div class='panel1'>" &
                   " <div style='font-size:large;padding:5px;border:2px solid white;color:white;background-color:" & clr & "'>" &
                   " <img   style='object-fit: contain;width:100%;' src='cid:" & picfiller & "'/>" &
                   " <p><strong>" & emailsubj & "  </strong> </p>" &
                   " <div style='text-align:left;padding:10px;background-color:white;color:black;'>" & emailbody & "<br>" & loginURL & " <br>" &
                   " <br> <p></p> <br>" &
                   " </div></br></br>*** This is an electronic message please do not reply ***<div></div></div></center>"


        '"To our Valued Taxpayer, <br> <br>" & _
        '                    "Please be informed that your Temporary Permit<b> </b> No. <b> " & mailTempPermitNo & " </b>" & _
        '                "<br>  is released But subject to actual Verification/Validation & Conduct of Business Operation  <br>" & _
        '                "Thank you. <br> "

        mail.IsBodyHtml = True


        Dim renderBytes As Byte() = _oMSRV.LocalReport.Render("PDF")
        ' Add the attachment
        Dim attachment As Attachment = New Attachment(New MemoryStream(renderBytes), "TemporaryPermit_" & cSessionLoader._pTemporaryPermitNo & ".pdf")
        mail.Attachments.Add(attachment)

        ' Configure the SMTP client
        Dim smtpClient As New SmtpClient("smtp.gmail.com")
        smtpClient.Port = 587 ' Use the appropriate SMTP port
        smtpClient.Credentials = New NetworkCredential("noreply.spidc@gmail.com", "uupdirgpdxsfmuab")
        smtpClient.EnableSsl = True

        ' Send the email
        Try
            smtpClient.Send(mail)
            sent = True


            'snackbar("green", "Email sent successfully.")
        Catch ex As Exception
            sent = False
            'snackbar("red", "Email sending failed. Error: " + ex.Message)

        End Try
    End Sub
    Public Sub Notify_BPLO()

    End Sub
    Public Function _GenTempPermitNum() As String 'Function that Generate new Temporary Permit No.
        _GenTempPermitNum = Nothing
        _mSqlCon = cGlobalConnections._pSqlCxn_BPLTAS

        Try
            _mSqlCommanStoredProc = New SqlCommand("GENERATETEMPPERMITNO", _mSqlCon)
            _mSqlCommanStoredProc.CommandType = CommandType.StoredProcedure
            _GenTempPermitNum = _mSqlCommanStoredProc.ExecuteScalar().ToString()
        Catch ex As Exception
            Return _GenTempPermitNum
        End Try

    End Function
    Public Function _GenNewxFileNo() As String 'Generate New File No for ImageByte
        _GenNewxFileNo = Nothing
        _mSqlCon = cGlobalConnections._pSqlCxn_BPLTAS

        Try
            _mSqlCommanStoredProc = New SqlCommand("IncrementLatestID", _mSqlCon)
            _mSqlCommanStoredProc.CommandType = CommandType.StoredProcedure
            _GenNewxFileNo = _mSqlCommanStoredProc.ExecuteScalar().ToString()
        Catch ex As Exception
            Return _GenNewxFileNo
        End Try

    End Function

    Protected Sub Export()


        Dim mimeType As String
        Dim encoding As String
        Dim fileNameExtension As String
        Dim streams As String()
        Dim warnings As Warning()
        ' Render the report
        Dim renderBytes As Byte() = _oMSRV.LocalReport.Render("PDF", Nothing, mimeType, encoding, fileNameExtension, streams, warnings)

        ' Save the rendered report to a PDF file
        'Using fs As New FileStream("output.pdf", FileMode.Create)
        '    fs.Write(renderBytes, 0, renderBytes.Length)
        'End Using
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = ContentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" & "TemporaryPermit_" & cSessionLoader._pTemporaryPermitNo & ".pdf")
        Response.BinaryWrite(renderBytes)
        Response.Flush()



        Dim sent As Boolean
        Notify_Taxpayer(accNo, sent)
        If sent = True Then
            Console.WriteLine("Report exported to PDF successfully.")
        End If

        Response.End()

    End Sub

    Protected Sub _SendEmailNofifcation()
        Try

        Catch ex As Exception

        End Try
    End Sub

#End Region
End Class