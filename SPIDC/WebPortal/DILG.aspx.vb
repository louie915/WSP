Imports System.IO

Public Class DILG
    Inherits System.Web.UI.Page
    Dim Email_Subject As String
    Dim Email_Body As String
    Dim Sent As Boolean
    Dim Particulars As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Get_BIN()

            Dim embed As String = "<object data=""{0}"" type=""application/pdf"" width=""100%"" height=""600px"">"
            embed += "If you are unable to view file, you can download from <a href = ""{0}"">here</a>"
            embed += "</object>"
            ltEmbed.Text = String.Format(embed, ResolveUrl("dilg-memo.pdf"))
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModalChecklist();", True)

        Else
            Dim _nClass As New cDalDILG
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubCheckIfAlreadyRequested(cSessionUser._pUserID, cmbBIN.Value)
            If _nClass._pAlreadyRequested = True Then
                div_Modal.InnerHtml = "<h1 style='color:green'>" & _nClass._pStatus & "</h1> " & _
                    "Your Request for this BIN is already " & _nClass._pStatus & "."
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
            Else
                _nClass._pSubGenerateID()
                _nClass._pSubInsertSafetySealRequest(_nClass._pRequestID, cSessionUser._pUserID, _nClass._pRequestDate, cmbBIN.Value)
                Particulars = "Request ID=" & _nClass._pRequestID & _
                                      ";BIN=" & cmbBIN.Value & _
                                      ";Business Name=" & cmbBIN.Items.Item(cmbBIN.SelectedIndex).ToString & ";"

                Dim _nClass3 As New cDalTransactionHistory
                _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass3._pSubInsertHistory(_nClass._pRequestID,
                                            cSessionUser._pUserID,
                                            "Safety Seal",
                                            "Request",
                                            "Inspection Request",
                                            Particulars,
                                            "PENDING")

                div_Modal.InnerHtml = "<h1 style='color:green'>PENDING</h1> Your Request has been sent to LGU for verification."
                Email_Subject = "Safety Seal - Inspection Request"
                Email_Body = "<h1 style='color:green'>PENDING</h1>Request ID: " & _nClass._pRequestID & "<br> Your inspection request for BIN:" & cmbBIN.Value & " has been sent to LGU. You will be notified with further instructions after we verify your request."
                cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Email_Subject, Email_Body, Sent)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
            End If
                End If
      

    End Sub

    Sub Get_BIN()
        '----------------------------------
        cmbBIN.DataSourceID = Nothing
        Dim _nClass As New cDalDILG
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubGetBIN(cSessionUser._pUserID)

        Dim _nDataSet As New DataSet()
        _nDataSet = _nClass._pDataSet

        Try
            '----------------------------------
            If _nDataSet.HasErrors Then
                '_mSubShowBlank()
            End If

            cmbBIN.DataSource = _nDataSet
            cmbBIN.DataTextField = "BUSNAME_ACCTNO"
            cmbBIN.DataValueField = "ACCTNO"
            cmbBIN.DataBind()
            cmbBIN.Items.Insert(0, New ListItem("Select", ""))

            '----------------------------------
        Catch ex As Exception

            '_mSubShowBlank()
        End Try
        '----------------------------------
       

    End Sub

    Sub GEnerate()

    End Sub

End Class