Public Class NewBP_Information
    Inherits System.Web.UI.Page
    Dim AppID As String
    Dim TaxpayerEmail As String
    Dim Status As String
    Dim FileData1, FileData2, FileData3, FileData4, FileData5, FileData6 As Byte()
    Dim Info1, Info2, Info3, Info4, Info5 As String
    Dim ACCTNO As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AppID = Request.QueryString("AppID")

        If Not IsPostBack Then
            Try
                get_Info(AppID, cSessionUser._pUserID, cSessionUser._pOffice)
                Dim _nClass As New cDalNewBP
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nClass.Application_ID = AppID
                _nClass._pSubGetACCTNO(ACCTNO)
                td_AcctNo.InnerText = ACCTNO
                _LoadBusinessLine(_oGridViewBusLine)
                Load_Regulatory()
                check_if_complete2(AppID)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub Load_Regulatory()
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubGetAllRegulatory(AppID)
        GridView1.DataSource = _nClass._mDataTable
        GridView1.DataBind()
    End Sub


    Sub get_Info(ByVal AppID As String, ByVal Email As String, ByVal Switch As String)
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubcheckIfValidInfo( _
       AppID _
      , Email _
      , td_OwnershipType.InnerText _
      , td_DtiSecCda.InnerText _
      , td_TIN.InnerText _
      , td_BusinessName.InnerText _
      , td_MainOfficeAddress.InnerText _
      , td_TelNo.InnerText _
      , td_MobileNo.InnerText _
      , td_OwnerName.InnerText _
      , td_Nationality.InnerText _
      , td_Area.InnerText _
      , td_FloorArea.InnerText _
      , td_MaleEmpNo.InnerText _
      , td_FemaleEmpNo.InnerText _
      , td_ResidingEmpNo.InnerText _
      , td_VanTruckNo.InnerText _
      , td_MotorNo.InnerText _
      , td_BusinessLocationAddress.InnerText _
      , td_Capital.InnerText _
      , NatureHTML.InnerHtml _
      , FileData1 _
      , td_FileName1.InnerText _
      , td_FileType1.InnerText _
      , td_FileStatus1.InnerText _
      , td_FileRemarks1.InnerText _
      , FileData2 _
      , td_FileName2.InnerText _
      , td_FileType2.InnerText _
      , td_FileStatus2.InnerText _
      , td_FileRemarks2.InnerText _
      , FileData3 _
      , td_FileName3.InnerText _
      , td_FileType3.InnerText _
      , td_FileStatus3.InnerText _
      , td_FileRemarks3.InnerText _
      , FileData4 _
      , td_FileName4.InnerText _
      , td_FileType4.InnerText _
      , td_FileStatus4.InnerText _
      , td_FileRemarks4.InnerText _
      , FileData5 _
      , td_FileName5.InnerText _
      , td_FileType5.InnerText _
      , td_FileStatus5.InnerText _
      , td_FileRemarks5.InnerText _
      , FileData6 _
      , td_FileName6.InnerText _
      , td_FileType6.InnerText _
      , td_FileStatus6.InnerText _
      , td_FileRemarks6.InnerText _
      , Status)
        td_ApplicationNo.InnerText = AppID
        td_EmailAddress.InnerText = Email

        td_FileData1.InnerText = "data:" & td_FileType1.InnerText & ";base64," & Convert.ToBase64String(FileData1)
        td_FileData2.InnerText = "data:" & td_FileType2.InnerText & ";base64," & Convert.ToBase64String(FileData2)
        td_FileData3.InnerText = "data:" & td_FileType3.InnerText & ";base64," & Convert.ToBase64String(FileData3)
        td_FileData4.InnerText = "data:" & td_FileType4.InnerText & ";base64," & Convert.ToBase64String(FileData4)
        td_FileData5.InnerText = "data:" & td_FileType5.InnerText & ";base64," & Convert.ToBase64String(FileData5)
        td_FileData6.InnerText = "data:" & td_FileType6.InnerText & ";base64," & Convert.ToBase64String(FileData6)

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
            Dim application_ID As String = Request.QueryString("AppID")

            cSessionLoader._pBPLTAS_SvrName = _nLiveServerName
            cSessionLoader._pBPLTAS_DbName = _nLiveDatabaseName

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT " & _
                        "Bus_code, (Select [description] from " & _
                        " [" & cSessionLoader._pBPLTAS_SvrName & "].[" & cSessionLoader._pBPLTAS_DbName & "].[dbo].[BUSCODE]" & _
                        " where bus_code = BUSLINE.BUS_CODE) as LINE, Capital, Area, Asset, Product,Bustax,Mayors,Garbage,Sanitary,Fire,foryear" & _
                        " from " & _
                        " [" & cSessionLoader._pBPLTAS_SvrName & "].[" & cSessionLoader._pBPLTAS_DbName & "].[dbo].[BUSLINE]"



                ._pCondition = " where acctno = (select acctno from [BUSMAST] where PBN=''" & application_ID & "'')"

                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

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




    Private Sub btnSelect_ServerClick(sender As Object, e As EventArgs) Handles btnSelect.ServerClick
        reload_Modal()
    End Sub
    Sub reload_Modal()
        Dim Code As String = hdnCode.Value
        Dim Desc As String = hdnDesc.Value
        Dim AppID As String = hdnAppID.Value
        ModalRegulatoryTitle.InnerText = Desc
        get_Requirements(AppID, Code)
        get_ACCTNO(AppID, ACCTNO)
        get_Fees(Code, ACCTNO)

        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal();", True)

    End Sub

    Sub get_Requirements(AppID, Code)
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectRequirements_Submitted(AppID, Code)
        GridView2.DataSource = _nClass._mDataTable
        GridView2.DataBind()
        _nClass._pSubSelectRequirements_Submitted2(AppID, Code, txt_Info1.Value, txt_Info2.Value, txt_Info3.Value, txt_Info4.Value, txt_Info5.Value, txt_Status.Value, txt_Remarks.Value)

    End Sub
    Sub get_ACCTNO(ByVal AppID As String, ByRef ACCTNO As String)
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass.Application_ID = AppID
        _nClass._pSubGetACCTNO(ACCTNO)
    End Sub

    Sub get_Fees(Code, ACCTNO)
        Dim _nClass2 As New cDalNewBP
        _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass2._pSubSelectFees(Code, ACCTNO)
        GridView3.DataSource = _nClass2._mDataTable
        GridView3.DataBind()
    End Sub
  

   

    
    Sub check_if_complete(ByVal AppID As String)
        Dim complete As Boolean
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubCheckIfAllRegReqIsApproved(AppID, complete)

        If complete = True Then
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubUpdate_CompleteRegulatory(AppID, "Approved - For BPLO Approval")
            _nClass.Application_ID = AppID
            _nClass._pSubGetACCTNO(ACCTNO)
            _nClass._pSubUpdate_BusmastforTOP(ACCTNO, "Acquired : Approved for Billing-TOP")

            divComplete.InnerHtml = "All [Regulatory Requirements] has been approved. You can now go to BPLTAS and proceed to Billing TOP with the following details:<br>" & _
                                    "AcctNo : " & ACCTNO & "<br>" & _
                                    "<hr>" & _
                                    "<center><a href='BPLONewBP_ForApproval.aspx?Application_ID=" & AppID & "&Email=" & TaxpayerEmail & "'>" & _
                                    "Click Here after Billing TOP" & _
                                    "</a></center>"

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModalComplete();", True)

        Else
            Exit Sub
        End If



    End Sub
    Sub check_if_complete2(ByVal AppID As String)
        Dim complete As Boolean
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubCheckIfAllRegReqIsApproved(AppID, complete)

        If complete = True Then
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass.Application_ID = AppID
            _nClass._pSubGetACCTNO(ACCTNO)

            divComplete.InnerHtml = "<strong>All Regulatory Requirements has been APPROVED.</strong> <br>" & _
                                    "You can now go to BPLTAS and proceed to Billing TOP with the following details:<br>" & _
                                    "AcctNo : " & ACCTNO & "<br>" & _
                                    "<hr>" & _
                                    "<center><a href='BPLONewBP_ForApproval.aspx?Application_ID=" & AppID & "&Email=" & TaxpayerEmail & "'>" & _
                                    "Click Here after Billing TOP" & _
                                    "</a></center><br>"
        Else
            Exit Sub
        End If



    End Sub
    Sub sendEmail(ByVal AppID As String)
        Dim Sent As Boolean
        Dim Content As String
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubGetContent(AppID, Content)

        Dim Body As String =
            "Dear Valued Tax Payer, <br> " & _
            "We have updated your New Business Application, please see the details below.<br/> <br/>" & _
            "<table style='border-collapse: collapse;width: 100%;text-align:center'>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><th style=' border: 1px solid #ddd;padding: 8px;' colspan='3'>Application ID : " & AppID & "</th></tr>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><th style=' border: 1px solid #ddd;padding: 8px;'>Clearance Requirement</th><th style=' border: 1px solid #ddd;padding: 8px;'>Status</th><th style=' border: 1px solid #ddd;padding: 8px;'>Remarks</th></tr>" & _
               Content & _
               "</table><br/> <br/>" & _
            "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
        cDalNewSendEmail.SendEmail(TaxpayerEmail, "New Business Application Status", Body, Sent)

    End Sub


End Class