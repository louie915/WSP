Imports System.IO

Public Class Regulatory_Review
    Inherits System.Web.UI.Page
    Dim AppID As String
    Dim TaxpayerEmail As String
    Dim Status As String
    Dim FileData1, FileData2, FileData3, FileData4, FileData5, FileData6 As Byte()
    Dim Info1, Info2, Info3, Info4, Info5 As String
    Dim ACCTNO As String
    Dim BRGY_remarks, CPDO_remarks, HO_remarks, CENRO_remarks, BLDG_remarks, FIRE_remarks As String
    Dim BRGY_status, CPDO_status, HO_status, CENRO_status, BLDG_status, FIRE_status As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AppID = Request.QueryString("Application_ID")
        TaxpayerEmail = Request.QueryString("Email")

        If Not IsPostBack Then
            Try
                get_Info(AppID, TaxpayerEmail, cSessionUser._pOffice)
                Dim _nClass As New cDalNewBP
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nClass.Application_ID = AppID
                _nClass._pSubGetACCTNO(ACCTNO)
                td_AcctNo.InnerText = ACCTNO

                _LoadBusinessLine(_oGridViewBusLine)
                loaddata()

            Catch ex As Exception

            End Try
        End If
    End Sub

    Sub loaddata()
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectRequirements_Submitted(Request.QueryString("Application_ID"), cSessionUser._pOffice)
        GridView1.DataSource = _nClass._mDataTable
        GridView1.DataBind()
        _nClass._pSubSelectRequirements_Submitted2(Request.QueryString("Application_ID"), cSessionUser._pOffice, txt_Info1.Value, txt_Info2.Value, txt_Info3.Value, txt_Info4.Value, txt_Info5.Value, txt_Status.Value, txt_Remarks.Value)


        Dim ACCTNO As String
        _nClass.Application_ID = AppID
        _nClass._pSubGetACCTNO(ACCTNO)


        If cSessionUser._pOffice <> "FIRE" Then
            Dim _nClass2 As New cDalNewBP
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass2._pSubSelectFees(cSessionUser._pOffice, ACCTNO)
            GridView2.DataSource = _nClass2._mDataTable
            GridView2.DataBind()
        End If

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


    Private Sub btnApprove_ServerClick(sender As Object, e As EventArgs) Handles btnApprove.ServerClick
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubUpdateAttachmentStatus(hdnAppID.Value, cSessionUser._pOffice, hdnCode.Value, "Approved", txt_ImageRemarks.Value)
        loaddata()
    End Sub

    Private Sub btnReject_ServerClick(sender As Object, e As EventArgs) Handles btnReject.ServerClick
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubUpdateAttachmentStatus(hdnAppID.Value, cSessionUser._pOffice, hdnCode.Value, "Rejected", txt_ImageRemarks.Value)
        loaddata()
    End Sub

    Private Sub btnSubmit_ServerClick(sender As Object, e As EventArgs) Handles btnSubmit.ServerClick
        Try
            Dim ACCTNO As String
            Dim _nClass As New cDalNewBP

            Dim Clerance_No As String = Nothing
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubGenerate_ClearanceNo(cSessionUser._pOffice, Clerance_No)
            _nClass._pSubUpdate_Status(Request.QueryString("Application_ID"), cSessionUser._pOffice, txt_Status.Value, Clerance_No, txt_Remarks.Value)

            '-- GET BPLTAS ACCTNO using WEB APPLICATION_ID
            _nClass.Application_ID = Request.QueryString("Application_ID")
            _nClass._pSubGetACCTNO(ACCTNO)



            Dim Exist As Boolean
            If GridView2.Rows.Count > 0 Then
                For Each row As GridViewRow In GridView2.Rows
                    Dim FNAME = DirectCast(row.FindControl("FNAME"), Label).Text
                    Dim FDESC = DirectCast(row.FindControl("FDESC"), Label).Text
                    Dim FeeAMT = DirectCast(row.FindControl("txtFeeAmt"), HtmlInputText).Value

                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
                    _nClass._pSubUpdate_FeesBPLTAS(ACCTNO, FNAME, FeeAMT)

                    '   _nClass._pSubSelect_Fees(Request.QueryString("Application_ID"), cSessionUser._pOffice, DNAME, Exist)
                    '   If Exist = True Then
                    '       _nClass._pSubUpdate_Fees(Request.QueryString("Application_ID"), cSessionUser._pOffice, FNAME, FDESC, DNAME, TAXCODE, FeeAMT)
                    '   Else
                    '       _nClass._pSubInsert_Fees(Request.QueryString("Application_ID"), cSessionUser._pOffice, FNAME, FDESC, DNAME, TAXCODE, FeeAMT)
                    '   End If


                Next
                '   Else
                '       Dim FNAME = "N/A"
                '       Dim FDESC = "N/A"
                '       Dim DNAME = "N/A"
                '       Dim TAXCODE = "N/A"
                '       Dim FeeAMT = "0.00"
                '       _nClass._pSubSelect_Fees(Request.QueryString("Application_ID"), cSessionUser._pOffice, DNAME, Exist)
                '       If Exist = True Then
                '           _nClass._pSubUpdate_Fees(Request.QueryString("Application_ID"), cSessionUser._pOffice, FNAME, FDESC, DNAME, TAXCODE, FeeAMT)
                '       Else
                '           _nClass._pSubInsert_Fees(Request.QueryString("Application_ID"), cSessionUser._pOffice, FNAME, FDESC, DNAME, TAXCODE, FeeAMT)
                '       End If
            End If

            check_if_complete(Request.QueryString("Application_ID"))
            Response.Redirect("Regulatory_ReviewHistory.aspx?Application_ID=" + Request.QueryString("Application_ID") + "&Email=" + Request.QueryString("Email") + "&00=1")

        Catch ex As Exception

        End Try





    End Sub

    Function GetAbbrv(ByVal office As String) As String
        Dim _nClass As New cDalNewBP
        Dim result As String
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass._pSubGetAbbrv(office, result)
        Return result.ToUpper
    End Function

    Sub check_if_complete(AppID)
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        Dim BRGY, CPDO, HO, CENRO, BLDG, FIRE As Boolean

        _nClass._pSubGet_REgulatoryStatus(AppID, "BRGY", BRGY, BRGY_status, BRGY_remarks)
        _nClass._pSubGet_REgulatoryStatus(AppID, GetAbbrv("PDO"), CPDO, CPDO_status, CPDO_remarks)
        _nClass._pSubGet_REgulatoryStatus(AppID, "HO", HO, HO_status, HO_remarks)
        _nClass._pSubGet_REgulatoryStatus(AppID, GetAbbrv("ENRO"), CENRO, CENRO_status, CENRO_remarks)
        _nClass._pSubGet_REgulatoryStatus(AppID, GetAbbrv("ENG"), BLDG, BLDG_status, BLDG_remarks)
        _nClass._pSubGet_REgulatoryStatus(AppID, "FIRE", FIRE, FIRE_status, FIRE_remarks)

        sendEmail()

        If BRGY = True And CPDO = True And HO = True And
           CENRO = True And BLDG = True And FIRE = True Then
            _nClass._pSubUpdate_CompleteRegulatory(AppID, "Approved - For BPLO Approval")
            _nClass.Application_ID = AppID
            _nClass._pSubGetACCTNO(ACCTNO)
            _nClass._pSubUpdate_BusmastforTOP(ACCTNO, "Acquired : Approved for Billing-TOP")
            '--send email for Complete Regulatory Notif
        End If

    End Sub


    Sub sendEmail()
        Dim Sent As Boolean
        Dim Body As String =
            "Dear Valued Tax Payer, <br> " & _
            "We have updated your New Business Application, please see the details below.<br/> <br/>" & _
            "<table style='border-collapse: collapse;width: 100%;text-align:center'>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><th style=' border: 1px solid #ddd;padding: 8px;' colspan='3'>Application ID : " & AppID & "</th></tr>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><th style=' border: 1px solid #ddd;padding: 8px;'>Clearance Requirement</th><th style=' border: 1px solid #ddd;padding: 8px;'>Status</th><th style=' border: 1px solid #ddd;padding: 8px;'>Remarks</th></tr>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><td style=' border: 1px solid #ddd;padding: 8px;'>Barangay</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & BRGY_status & "</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & BRGY_remarks & "</td></tr>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><td style=' border: 1px solid #ddd;padding: 8px;'>Zoning</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & CPDO_status & "</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & CPDO_remarks & "</td></tr>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><td style=' border: 1px solid #ddd;padding: 8px;'>Building Official</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & BLDG_status & "</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & BLDG_remarks & "</td></tr>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><td style=' border: 1px solid #ddd;padding: 8px;'>Health</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & HO_status & "</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & HO_remarks & "</td></tr>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><td style=' border: 1px solid #ddd;padding: 8px;'>Environmental</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & CENRO_status & "</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & CENRO_remarks & "</td></tr>" & _
                "<tr style=' border: 1px solid #ddd;padding: 8px;'><td style=' border: 1px solid #ddd;padding: 8px;'>Bureau of Fire Protection</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & FIRE_status & "</td><td style=' border: 1px solid #ddd;padding: 8px;'>" & FIRE_remarks & "</td></tr>" & _
            "</table><br/> <br/>" & _
            "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
        cDalNewSendEmail.SendEmail(TaxpayerEmail, "New Business Application Status", Body, Sent)

    End Sub



End Class