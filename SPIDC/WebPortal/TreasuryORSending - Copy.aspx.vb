Imports System.IO

Public Class TreasuryORSending
    Inherits System.Web.UI.Page

    Dim _Type As String = Nothing
    Dim _TPName As String = Nothing
    Dim _TPEmail As String = Nothing
    Dim _AcctNo As String = Nothing
    Dim _Subject As String = Nothing
    Dim _Body As String = Nothing

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub _btnSearch_ServerClick(sender As Object, e As EventArgs) Handles _btnSearch.ServerClick
        Dim _nClassBP As New cDalBPSOS
        _nClassBP._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        Dim _nClassRPT As New cDalSOSRPTAS
        _nClassRPT._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
        _AcctNo = txtAcctNo.Value
        Dim isValid As Boolean = False
        _Type = hdnType.Value

        If _Type = "BP" Then
            If _nClassBP._getNameEmail(_AcctNo, _TPName, _TPEmail) Then
                isValid = True
            Else
                isValid = False
            End If
        ElseIf _Type = "RPT" Then
            If _nClassRPT._getNameEmail(_AcctNo, _TPName, _TPEmail) Then
                isValid = True
            Else
                isValid = False
            End If
        End If

        If isValid = False Then
            'NO RECORDS FOUND
            divNotice.InnerText = "Invalid Account"
            divNotice.Style.Add("display", "")
        Else
            'RECORDS FOUND
            divNotice.Style.Add("display", "none")
            lblTaxpayerName.InnerText = _TPName
            txtEmail.Value = _TPEmail
        End If
    End Sub

    Protected Sub Upload(sender As Object, e As EventArgs) Handles _btnSend.ServerClick
        Try
            _AcctNo = txtAcctNo.Value
            _TPName = lblTaxpayerName.InnerText
            _TPEmail = txtEmail.Value
            _Type = hdnType.Value
            _Subject = txtSubject.Value
            _Body = txtBody.Value

            Dim bytes As Byte() = Nothing
            Dim FileName As String = Nothing
            Dim FileType As String = Nothing
            Dim FileSize As String = Nothing

            Dim Sent As Boolean = False

            Dim strSize As String = Nothing
            Dim intSize As Integer = Nothing
            Dim err As String = Nothing
            Dim _FileSize As Integer = 0
            For x As Integer = 0 To Request.Files.Count - 1
                Dim FileData As HttpPostedFile = Request.Files(x)
                If FileData.ContentLength > 0 Then
                    _FileSize += Request.Files(x).ContentLength
                End If
            Next

            Dim _nClass As New cDalNewSendEmail
            '   _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            '  _nClass._pSubGetTotFileSize(strSize, intSize, err)

            If (_FileSize + intSize) < 10485760 Then ' 10485760 = 10 MB
                For i As Integer = 0 To Request.Files.Count - 1
                    Dim FileData As HttpPostedFile = Request.Files(i)
                    If FileData.ContentLength > 0 Then
                        FileName = Request.Files(i).FileName
                        FileType = Request.Files(i).ContentType
                        FileSize = Request.Files(i).ContentLength
                        Dim fs As Stream = FileData.InputStream
                        Dim br As New BinaryReader(fs)
                        bytes = br.ReadBytes(Convert.ToInt32(fs.Length))

                        cDalNewSendEmail.SendEmailwithAttachment(_TPEmail, _Subject, _Body, Sent, bytes, FileName)
                        _nClass._pSubInsertHistory_ORSending(_Type, _AcctNo, _TPName, _TPEmail, _Subject, _Body, bytes, FileName, FileType, FileSize, Sent, cSessionUser._pUserID)

                        Dim LGU_Emails As String = Nothing
                        Dim LGU_Body As String = Nothing
                        Dim Office As String = Nothing

                        If _Type = "BP" Then
                            Office = "BPLO"
                            LGU_Body = "The following account is already paid and is ready for permit sending through email. " & _
                                "<br/> BIN : " & _AcctNo
                            'ElseIf _Type = "RPT" Then
                            '    Office = "ASSESSOR"""
                            '    LGU_Body = "The following account is already paid and is ready for permit sending through email. " & _
                            '       "<br/> BIN : " & _AcctNo

                            cDalNewSendEmail.get_Emails(Office, LGU_Emails)
                            cDalNewSendEmail.SendEmail(LGU_Emails, "Account Paid", LGU_Body, Sent, , 1)
                        End If


                       


                    End If
                Next
                Response.Write("<script>")
                Response.Write("alert('Email has been sent to Taxpayer');")
                Response.Write("</script>")
            Else
                Response.Write("<script>")
                Response.Write("alert('Over Max Size');")
                Response.Write("</script>")
            End If

            
        Catch ex As Exception

        End Try

    End Sub
End Class