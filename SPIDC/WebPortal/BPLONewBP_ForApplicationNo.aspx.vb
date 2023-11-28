Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Linq
Public Class BPLONewBP_ForApplicationNo
    Inherits System.Web.UI.Page

    Dim strCatCode, strCatDesc, strBusCode, strBusDesc As String
    Dim Application_ID As String
    Dim ACCTNO As String
    Dim Email As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal eQ As System.EventArgs) Handles Me.Load
        Application_ID = Request.QueryString("ApplicationID")
        Email = Request.QueryString("Email")
        Dim _nclass As New cDalNewBP
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        Try

            If Not IsPostBack Then
                cSessionLoader_NEWBP_Draft._pApplication_ID = Application_ID
                cSessionLoader._pAccountNo = cSessionLoader_NEWBP_Draft._pApplication_ID
                cLoader_BPLTIMS._pACCTNO = cSessionLoader_NEWBP_Draft._pApplication_ID
                _LoadInformation(Email)
                '   _LoadBusinessLine(_oGridViewBusLine)
                _nclass.Application_ID = Application_ID
                _LoadAttachments(Email, Application_ID)
                _nclass._pSubGetACCTNO(ACCTNO)

            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")

             

                'If action = "Incomplete" Then
                '    _Initialize_UpdateStatus("Incomplete")
                '    Exit Sub
                'End If

                If action = "Approve" Then
                    Dim nStatus As String
                    Dim exists As Boolean
               
                    _nclass.Application_ID = Application_ID
                    _nclass._pSubGetACCTNO(ACCTNO)
                    _nclass.checkBusMastStatus(nStatus, ACCTNO, exists)
                    If exists = True Then
                        If nStatus.ToUpper.Contains("ACQUIRED") Then
                            'do nothing
                        Else
                            _UpdateBUSMASTStatus("Reviewed/ For Assessment")
                        End If
                    Else
                        _UpdateBUSMASTStatus("Reviewed/ For Assessment")
                    End If
                   

                    lblApplicationID.InnerText = cSessionLoader_NEWBP_Draft._pApplication_ID
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModalSubmit();", True)

                    Exit Sub
                End If

                If action = "Notify" Then
                    Dim nStatus As String
                    Dim exists As Boolean
                    _nclass.Application_ID = Application_ID
                    _nclass._pSubGetACCTNO(ACCTNO)
                    _nclass.checkBusMastStatus(nStatus, ACCTNO, exists)
                    Dim appid As String
                    Dim Emailadd As String

                    If exists = True Then
                        If nStatus.ToUpper.Contains("ACQUIRED") Then
                            Dim Sent As Boolean
                            Dim Body As String
                            Dim _Status As Boolean

                            Dim _nclassGetModules As New cDalGetModules
                            _nclassGetModules._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                            If _nclassGetModules._pSubGetAvailableModules("BP_NRegulatory") = False Then
                                _Initialize_UpdateStatus("Approved - For BPLO Approval")
                                _nclass.Application_ID = Application_ID
                                _nclass._pSubGetACCTNO(ACCTNO)
                                _nclass._pUpdateNewBPDraft_ACCTNO(Application_ID, ACCTNO, cmbWho.Value)
                                _nclass._pSubGetAppidEmail(ACCTNO, appid, Emailadd)
                                _nclass._pSubUpdate_BusmastforTOP(ACCTNO, "Acquired : Approved for Billing-TOP")
                                Response.Redirect("BPLONewBP_ForApproval.aspx?Application_ID=" & Application_ID & "&Email=" & Emailadd)

                            Else
                                _Initialize_UpdateStatus("Approved - For Regulatory")
                                _nclass.Application_ID = Application_ID
                                _nclass._pSubGetACCTNO(ACCTNO)
                                _nclass._pUpdateNewBPDraft_ACCTNO(Application_ID, ACCTNO, cmbWho.Value)
                                _nclass._pSubGetAppidEmail(ACCTNO, appid, Emailadd)

                                Dim _nClassX As New cDalNewBP
                                _nClassX._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                                _nClassX._pSubCheckFastApply(_Status)

                                If _Status = True Then
                                    Body = "Dear Valued Tax Payer, <br> " & _
                                          "Initial Verification of your New Business Application(" & Application_ID & ") has been Approved.<br>" & _
                                          "" & Application_ID & " has been sent to Regulatory Offices for further Assessment.<br>" & _
                                          "Please wait for more updates.<br>" & _
                                          "<br><br>" & _
                                          "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
                                Else
                                    Body = "Dear Valued Tax Payer, <br> " & _
                                           "Your New Business Application is now Approved for Regulatory." & _
                                           "Login to your account, select [Regulatory] and submit Requirements.<br><br>" & _
                                           "Thank you for choosing online transaction. Have a wonderful day! <br><br>"

                                End If
                                cDalNewSendEmail.SendEmail(Emailadd, "New Business Application Status", Body, Sent)
                                If Sent = True Then
                                    snackbar("green", "Email Sent, Taxpayer has been notified")
                                    If _Status = True Then
                                        Response.Redirect("BPLONewBP_ForRegulatory.aspx?Application_ID=" & Application_ID & "&Email=" & Emailadd)
                                    End If
                                Else
                                    snackbar("red", "Failed to send Email, Taxpayer not notified")
                                End If
                            End If
                        End If
                    End If
                    snackbar("red", "Application not yet acquired.")
                    Exit Sub
                End If

                'If action = "ImageReject" Then
                '    _Initialize_UpdateImage("Reject", txt_ImageRemarks.Value, hdn_ImageId.Value)
                '    Exit Sub
                'End If

                'If action = "ImageApprove" Then
                '    _Initialize_UpdateImage("Approved", txt_ImageRemarks.Value, hdn_ImageId.Value)
                '    Exit Sub
                'End If
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub _LoadBusinessLine(_nGridview As GridView)
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nLiveServerName As String = _nClBP._pDBDataSource
            Dim _nLiveDatabaseName As String = _nClBP._pDBInitialCatalog
            Dim application_ID As String = Request.QueryString("Application_ID")

            cSessionLoader._pBPLTAS_SvrName = _nLiveServerName
            cSessionLoader._pBPLTAS_DbName = _nLiveDatabaseName

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT " & _
                        "Bus_code, (Select [description] from " & _
                        " [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].[dbo].[BUSCODE]" & _
                        " where bus_code = BUSLINE.BUS_CODE) as LINE, Capital, Area, Asset, Product,Bustax,Mayors,Garbage,Sanitary,Fire,foryear" & _
                        " from " & _
                        " [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].[dbo].[BUSLINE]"



                ._pCondition = " where acctno = (select acctno from [BUSMAST] where PBN=''" & application_ID & "'')"

                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable
                ' txtqry.InnerHtml = cGlobalConnections._pSqlCxn_BPLTAS.Database
                Try
                    '----------------------------------
                    If _nDataTable.HasErrors Then

                    End If

                    If _nDataTable.Rows.Count > 0 Then
                        _nGridview.DataSource = _nDataTable
                        _nGridview.DataBind()
                    Else
                        cEmptyGridview.pEmpyGridViewWithHeader(_nGridview, _nDataTable, "No record available")
                    End If
                    '----------------------------------
                Catch ex As Exception

                End Try
            End With

        Catch ex As Exception

        End Try
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

    Private Sub btnINC_ServerClick(sender As Object, e As EventArgs) Handles btnINC.ServerClick
        Dim Emailadd As String = td_EmailAddress.InnerText
        Dim Sent As Boolean
        Dim Body As String

        Dim _nclass As New cDalNewBP
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _Initialize_UpdateStatus("Incomplete")
   
        Body = "Dear Valued Tax Payer, <br> " & _
               "Your New Business Application is Incomplete. Please see details below:<br>" & _
               "Remarks : " & IncRemarks.Value & "<br>" & _
               "Login to your account, select your application and Re-Submit your Requirements.<br><br>" & _
               "Thank you for choosing online transaction. Have a wonderful day! <br><br>"

        cDalNewSendEmail.SendEmail(Emailadd, "New Business Application Status", Body, Sent)
        If Sent = True Then
            snackbar("green", "Email Sent, Taxpayer has been notified")
        Else
            snackbar("red", "Failed to send Email, Taxpayer not notified")
        End If
        'btnINC
    End Sub


    Sub _LoadAttachments(ByVal _email As String, ByVal _acctno As String)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            '_nClass._pSubSelectRequirements2("NEW", _email, _acctno)
            _nClass._pSubGetAttachments("NEW", _email, _acctno)
            GV_REQS.DataSource = _nClass._mDataTable
            GV_REQS.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class