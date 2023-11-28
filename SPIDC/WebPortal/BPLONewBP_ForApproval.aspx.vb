Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Linq
Public Class BPLONewBP_ForApproval
    Inherits System.Web.UI.Page
    Dim AppID As String
    Dim Email As String
    Dim acctno As String
    Dim Status As String
    Dim FileData1, FileData2, FileData3, FileData4, FileData5, FileData6 As Byte()
    Dim Fee1, Fee2, Fee3, Fee4, Fee5, Fee6, Fee7, Fee8 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AppID = Request.QueryString("Application_ID")
        Email = Request.QueryString("Email")
        Dim _err As String = Nothing
        Dim _err1 As String = Nothing
        Dim _err2 As String = Nothing
        Dim _err3 As String = Nothing
        Dim _err4 As String = Nothing
        Dim ctr As Integer = 0
        If Not IsPostBack Then
            Try
                ' err.Value = "START get_Info:" & AppID & ":" & Email
                get_Info(AppID, Email, _err1)
                '  Response.Write(";1:" & AppID & ":" & Email)
                '  _err += ";get_Info:" & AppID & ":" & Email & ":" & _err1 & ":" & "CTR:" & ctr
                '   Response.Write(";2:" & _err1 & ":" & ctr)
                Dim _nClass As New cDalNewBP
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nClass.Application_ID = AppID
                ' _err += ";APPID:" & AppID
                _nClass._pSubGetACCTNO(acctno, _err2)
                '  _err += ";_pSubGetACCTNO:" & _err2
                ' _err += ";ACCTNO:" & acctno
                td_AcctNo.InnerText = acctno
                _LoadBusinessLine(_oGridViewBusLine, _err3)
                '  _err += ";_LoadBusinessLine:" & _err3

                loadGrid_TOP(_err4)
                '  _err += ";loadGrid_TOP:" & _err4

                ' err.Value += _err
            Catch ex As Exception
                err.Value += ex.Message
            End Try
        End If
    End Sub

    Sub loaddata(ByVal Office As String)
        Dim _nClass As New cDalNewBP
        Dim AmtDue As String = Nothing
        Dim Clearance_No As String = Nothing
        Dim Status As String = Nothing

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelectRegulatory_Fees2(Request.QueryString("Application_ID"), Office, AmtDue, Clearance_No, Status)

    

    End Sub
    Public Sub loadGrid_TOP(Optional ByRef err As String = Nothing)
        Try
            Dim Sum_TotAmtDue As Double
            Dim Sum_TotPenDue As Double
            Dim Sum_TotTaxDue As Double
            Dim Sum_TotETC As Double

            Dim qry As String = Nothing
            Dim _err As String = Nothing

            Dim _nClass1 As New cDalNewBP
            _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            '  _nClass1.Application_ID = AppID
            _nClass1._pSubGetACCTNO(acctno)

            Dim _nClass2 As New cDalNewBP
            _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass2._pSubSelectTOP(acctno, Sum_TotAmtDue, Sum_TotPenDue, Sum_TotTaxDue, Sum_TotETC, 0, qry, _err)

            err = qry & ";" & _err

            GridViewTOP.DataSource = _nClass2._mDataTable
            GridViewTOP.DataBind()

            TotAmtDue.InnerText = String.Format("{0:C}", Sum_TotAmtDue).Replace("$", "PHP ") 'Sum_TotAmtDue.ToString("0.00")
            GridViewTOP.FooterRow.Cells(0).ColumnSpan = 3
            GridViewTOP.FooterRow.Cells(0).Font.Bold = True
            GridViewTOP.FooterRow.Cells(0).Text = "T O T A L    D U E :"
            GridViewTOP.FooterRow.Cells(0).HorizontalAlign = HorizontalAlign.Center

            GridViewTOP.FooterRow.Cells(1).Font.Bold = True
            GridViewTOP.FooterRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(1).Text = Sum_TotTaxDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(2).Font.Bold = True
            GridViewTOP.FooterRow.Cells(2).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(2).Text = Sum_TotPenDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(3).Font.Bold = True
            GridViewTOP.FooterRow.Cells(3).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(3).Text = Sum_TotAmtDue.ToString("N2")

            GridViewTOP.FooterRow.Cells(5).Font.Bold = True
            GridViewTOP.FooterRow.Cells(5).HorizontalAlign = HorizontalAlign.Right
            GridViewTOP.FooterRow.Cells(5).Text = Sum_TotETC.ToString("N2")

            GridViewTOP.FooterRow.Cells(6).Visible = False
            GridViewTOP.FooterRow.Cells(7).Visible = False


        Catch ex As Exception
            err += ";loadGrid_TOP:" & ex.Message
            Console.WriteLine(err)
            '  err.Value()
        End Try
    End Sub

    Sub get_Info(ByVal AppID As String, ByVal Email As String, ByRef _err As String, Optional ByRef ctr As Integer = 0)
        Try
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
          , Status, _err, ctr)
            td_ApplicationNo.InnerText = AppID
            td_EmailAddress.InnerText = Email

            td_FileData1.InnerText = "data:" & td_FileType1.InnerText & ";base64," & Convert.ToBase64String(FileData1)
            td_FileData2.InnerText = "data:" & td_FileType2.InnerText & ";base64," & Convert.ToBase64String(FileData2)
            td_FileData3.InnerText = "data:" & td_FileType3.InnerText & ";base64," & Convert.ToBase64String(FileData3)
            td_FileData4.InnerText = "data:" & td_FileType4.InnerText & ";base64," & Convert.ToBase64String(FileData4)
            td_FileData5.InnerText = "data:" & td_FileType5.InnerText & ";base64," & Convert.ToBase64String(FileData5)
            td_FileData6.InnerText = "data:" & td_FileType6.InnerText & ";base64," & Convert.ToBase64String(FileData6)
        Catch ex As Exception
            _err = ";get_Info:" & ex.Message & ":" & _err & ":" & ctr
            snackbar("red", _err)
        End Try
      

    End Sub

    Private Sub _LoadBusinessLine(ByRef _nGridview As GridView, ByRef err As String)
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
                    err = ";_LoadBusinessLineHasErrors:" & ex.Message
                End Try
            End With

        Catch ex As Exception
            err = ";_LoadBusinessLine:" & ex.Message
            snackbar("red", err)
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

    Private Sub btn_TOP_ServerClick(sender As Object, e As EventArgs) Handles btn_TOP.ServerClick
        Dim _nClass1 As New cDalNewBP
        _nClass1._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass1.Application_ID = AppID
        _nClass1._pSubGetACCTNO(acctno)
        ReportViewer.NEWBP_TOP_ACCTNO = acctno
        ReportViewer.NEWBP_TOP_Email = Email
        Response.Redirect("Report/ReportViewer.aspx?ReportType=NEW_BP_TOP")
   End Sub

    Private Sub btnApproveForBilling_ServerClick(sender As Object, e As EventArgs) Handles btnApproveForBilling.ServerClick
        Try

      
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        Dim _err As String = Nothing
            '     err.Value = ";Start : ApproveForBilling"
        _nClass.Application_ID = AppID
            '        err.Value += ";Application_ID : " & AppID
        _nClass._pSubGetACCTNO(acctno)
            '      err.Value += ";acctno : " & acctno
        _nClass._pSubUpdateIsForPayment(acctno, _err)
            '   err.Value += ";_pSubUpdateIsForPayment : " & _err
        _nClass._pSubUpdateNewBPDraftStatus(AppID, "Approved - For Payment", _err)
            '    err.Value += ";_pSubUpdateNewBPDraftStatus : " & _err
        _nClass._pSubInsertToBUSDETAIL(Email, acctno, "Approved - For Payment", _err)
            '    err.Value += ";_pSubInsertToBUSDETAIL : " & _err
        Dim Sent As Boolean
        Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                             "Your New Business Application is now Approved for Payment." & _
                             "<br>" & _
                             "Application ID : " & AppID & _
                             "<br>" & _
                             "Business Account No. : " & acctno & _
                             "<br><br>" & _
                             "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
        cDalNewSendEmail.SendEmail(Email, "New Business Application Status", Body, Sent)
        If Sent = True Then
            snackbar("green", "Email Sent, Taxpayer has been notified")
        Else
            snackbar("red", "Failed to send Email, Taxpayer not notified")
        End If

            '    err.Value += ";SendEmail : " & Sent

            '    err.Value += ";END : ApproveForBilling"
        Catch ex As Exception

        End Try
    End Sub
End Class