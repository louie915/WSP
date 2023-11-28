Imports System.IO

Public Class Regulatory_ReviewHistory
    Inherits System.Web.UI.Page
    Dim Status As String
    Dim FileData1, FileData2, FileData3, FileData4, FileData5, FileData6 As Byte()
    Dim Info1, Info2, Info3, Info4, Info5 As String
    Dim acctno As String
    Dim appid As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                appid = Request.QueryString("Application_ID")
                get_Info(Request.QueryString("Application_ID"), Request.QueryString("Email"), cSessionUser._pOffice)
                _LoadBusinessLine(_oGridViewBusLine)
                Dim _nClass As New cDalNewBP
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                _nClass.Application_ID = AppID
                _nClass._pSubGetACCTNO(acctno)
                td_AcctNo.InnerText = acctno
                loaddata()
                If Request.QueryString("00") = 1 Then
                    snackbar("green", "Assessment Complete, Taxpayer has been notified")
                End If

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
        _nClass._pSubSelectRequirements_Submitted2_History(Request.QueryString("Application_ID"), cSessionUser._pOffice, txt_Info1.Value, txt_Info2.Value, txt_Info3.Value, txt_Info4.Value, txt_Info5.Value, txt_Status.InnerText, txt_Remarks.InnerText, txt_Date_Assessed.InnerText, txt_Assessed_by.InnerText, txt_Clearance_No.Value)

        Dim _nClass2 As New cDalNewBP
        _nClass2._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
        _nClass2._pSubSelectFees(cSessionUser._pOffice, acctno)
        GridView2.DataSource = _nClass2._mDataTable
        GridView2.DataBind()
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

    


End Class