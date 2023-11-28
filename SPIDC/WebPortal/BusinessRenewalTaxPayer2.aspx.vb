Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class BusinessRenewalTaxPayer2
    Inherits System.Web.UI.Page

    Dim reqcount As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim Err As String = Nothing
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubCheckIfAssetExists()
            _nClass._pSubCheckIfWEBASSESSNOExists()

            If _nClass._pSubCheckIfTableExist("BP_Attachment") = False Then
                _nClass._pSubCreateTable("BP_Attachment")
            End If

            If _nClass.CheckSubmitted(cSessionLoader._pAccountNo) = True Then
                Response.Write("<script>")
                Response.Write("alert('Account Already forwarded to BPLO.');")
                Response.Write("window.location.replace('Account.aspx');")
                Response.Write("</script>")
                Exit Sub
            ElseIf _nClass.isDeclined(cSessionLoader._pAccountNo) = True Then
                Load_SubmittedRequirements("RENEW")
                divDeclined.Style.Add("display", "block")
                rmrks.InnerText = _nClass.GetRemarks(cSessionLoader._pAccountNo)
            End If

            Dim _nclass2 As New cDalGetModules
            _nclass2._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclass2._pSubGetAvailableModules("BP_AssetEntry") = False Then
                _GVBusinessLine.Columns(4).HeaderText = ""
                ClientScript.RegisterStartupScript(Me.[GetType](), "hideasset", "hasset();", True)

            End If

            Load_Details(cSessionLoader._pAccountNo, Err)
            Load_Busline(cSessionLoader._pAccountNo, Err)

            Load_Requirements("RENEW", reqcount)
            If reqcount = 0 Then
                div_Requirements.Style.Add("display", "none")
            Else
                div_Requirements.Style.Add("display", "")
            End If

        Catch ex As Exception

        End Try
    End Sub


    Sub Load_Busline(ByVal Acctno As String, ByRef Err As String)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubGetBusLine_GrossAssetEntry_TAXPAYER(Acctno)
            _GVBusinessLine.DataSource = _nClass._mDataTable
            _GVBusinessLine.DataBind()

        Catch ex As Exception
            Err = ex.Message
        End Try

    End Sub

    Sub Load_Details(ByVal Acctno As String, ByRef Err As String)
        Try
            Dim MOP As String = Nothing
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pSubSelect_Details(Acctno, _oLblBusOwner.Text, _oLblBusName.Text, _oLblBusAddress.Text, _oLblBusOwnership.Text, MOP)
            _oLblBusID.Text = Acctno.ToUpper

        Catch ex As Exception

        End Try
    End Sub

    Sub Load_Requirements(ByVal switch As String, Optional ByRef reqCount As Integer = 0)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectRequirements(switch)
            _GVRequirements.DataSource = _nClass._mDataTable
            _GVRequirements.DataBind()
            reqCount = _nClass._mDataTable.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Upload(sender As Object, e As EventArgs)
        Try
            Dim _FileSize As Integer = 0
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim ForYear As String = _nClass.getYear()

            Dim arr_string As String() = hdnAttachment.Value.Split(New String() {";"}, StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer = 0
            For Each ReqCode As String In arr_string
                Do Until i = Request.Files.Count
                    Dim FileData As HttpPostedFile = Request.Files(i)
                    If FileData.ContentLength > 0 Then
                        Dim FileName As String = Request.Files(i).FileName
                        Dim FileType As String = Request.Files(i).ContentType
                        Dim FileSize As String = Request.Files(i).ContentLength
                        Dim fs As Stream = FileData.InputStream
                        Dim br As New BinaryReader(fs)
                        Dim bytes As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                        Dim _nQuery As String = Nothing

                        If _nClass.isAttachmentExists(cSessionLoader._pAccountNo, ForYear, ReqCode, cSessionUser._pUserID) = True Then
                            _nQuery = " Update [BP_Attachment] set " & _
                            " FileName=@FileName," & _
                            " FileType=@FileType," & _
                            " FileSize=@FileSize," & _
                            " FileData=@FileData" & _
                            " where acctno=@acctno" & _
                            " and ForYear=@ForYear" & _
                            " and ReqCode=@ReqCode"
                        Else
                            _nQuery = " insert into [BP_Attachment] values(" & _
                                " @ACCTNO,@ForYear,@ReqCode,@ReqDesc," & _
                                " @FileName,@FileType,@FileData,@FileSize,@Email)"
                        End If
                      
                        Dim _nSqlCommand As New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_BPLTIMS)
                        With _nSqlCommand.Parameters
                            .AddWithValue("@ACCTNO", cSessionLoader._pAccountNo)
                            .AddWithValue("@ForYear", ForYear)
                            .AddWithValue("@ReqCode", ReqCode)
                            .AddWithValue("@ReqDesc", _nClass.getReqDesc(ReqCode))
                            .AddWithValue("@FileName", FileName)
                            .AddWithValue("@FileType", FileType)
                            .AddWithValue("@FileData", bytes)
                            .AddWithValue("@FileSize", FileSize)
                            .AddWithValue("@Email", cSessionUser._pUserID)
                        End With
                        _nSqlCommand.ExecuteNonQuery()
                        i += 1
                        Exit Do
                    End If
                    i += 1
                Loop
            Next
            Dim strerr As String = Nothing
            Save_RenewalEntry(strerr)
            If strerr = Nothing Then
            Else
                Err.Value = strerr
            End If
        Catch ex As Exception
            Err.Value = ex.Message
        End Try
    End Sub

    Sub Load_SubmittedRequirements(ByVal switch As String)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubGetAttachmentsSubmitted(cSessionLoader._pAccountNo)
            gv_SubmittedRequirements.DataSource = _nClass._mDataTable
            gv_SubmittedRequirements.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Sub Save_RenewalEntry(ByRef err As String)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubUpdate_GrossAssetEntry(cSessionLoader._pAccountNo, hdnGrossAsset.Value, cmb_MOP.Value, err)
           _nClass._pSubUpdateRenewalMOP(cSessionLoader._pAccountNo, cmb_MOP.Value)

            Dim _nClassX As New cDalNewBP
            _nClassX._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClassX._pSubUpdateTOPONLINE(cSessionLoader._pAccountNo)
            _nClassX._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClassX._pSubUpdateISASSESS(cSessionLoader._pAccountNo)


            Dim Emails As String
            Dim sent As Boolean
            Dim Body As String = "Taxpayer has applied for Business Renewal with the following details: " & _
                   "<br> Email Address : " & cSessionUser._pUserID & _
                   "<br> BIN : " & cSessionLoader._pAccountNo & _
                   "<br> Please login to your Web Account to Assess the Application. Thank you <br><br>"

            cDalNewSendEmail.get_Emails("BPLO", Emails)
            cDalNewSendEmail.SendEmail(Emails, "Business Renewal Application", Body, sent, , 1)
         
            snackbar("green", "Renewal Application has been submitted.")
            Response.Write("<script>")
            Response.Write("window.location.replace('Account.aspx');")
            Response.Write("</script>")

            'NOTIFY BPLO
        Catch ex As Exception

        End Try
    End Sub

    Sub snackbar(Color As String, Caption As String)
        If Color.ToUpper = "RED" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color.ToUpper = "GREEN" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub

End Class