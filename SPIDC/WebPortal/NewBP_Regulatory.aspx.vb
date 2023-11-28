Imports System.IO

Public Class NewBP_Regulatory
    Inherits System.Web.UI.Page
    Dim AppID As String
    Dim BusName, BusAdd, brgy As String
    Dim Date_Assessed, SWITCH, ClearanceNo, Info1, Info2, Info3, Info4, Info5 As String
    Dim File_Name1, FIle_Name2, File_Type1, File_Type2, File_Status1, File_Status2, File_Remarks1, File_Remarks2 As String
    Dim File_Data1, File_Data2 As Byte()
    Dim txInfo1, txInfo2, txInfo3, txInfo4, txInfo5 As String
    Dim Status, Remarks As String
    Dim stBRGY As Boolean
    Dim stCPDO As Boolean
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AppID = Request.QueryString("AppID")
        Try
            If Not IsPostBack Then
                get_Draft(Request.QueryString("AppID"), cSessionUser._pUserID)
                get_requirements()
                'get_DisplaySubmitted("BLDG")
                'get_DisplaySubmitted("CENRO")
                'get_DisplaySubmitted("CPDO")
                'get_DisplaySubmitted("BRGY")
                'get_DisplaySubmitted("FIRE")
                'get_DisplaySubmitted("HO")

                'get_DisplaySubmitted("BRGY")    'Barangay - BRGY
                'get_DisplaySubmitted("CZAO")    'ZONING - CZAO
                'get_DisplaySubmitted("OCBO")    'building - OCBO
                'get_DisplaySubmitted("HO")      'Health  - HO
                'get_DisplaySubmitted("CENRO")   'Environment - CENRO
                'get_DisplaySubmitted("FIRE")    'Fire - FIRE
               
                get_DisplaySubmitted("BRGY")   'Barangay 
                get_DisplaySubmitted(GetAbbrv("PDO"))   'ZONING
                get_DisplaySubmitted(GetAbbrv("ENG"))   'building
                get_DisplaySubmitted("HO")     'Health 
                get_DisplaySubmitted(GetAbbrv("ENRO"))   'Environment 
                get_DisplaySubmitted("FIRE")   'Fire



                If stBRGY = True And stCPDO = True Then
                Else
                    ' div_BLDG.Style.Add("cursor", "not-allowed")
                    ' div_BLDG.Style.Add(" pointer-events", "none")
                    ' BLDG_LOCK.InnerText = "Locked"
                    '
                    ' div_CENRO.Style.Add("cursor", "not-allowed")
                    ' div_CENRO.Style.Add(" pointer-events", "none")
                    ' CENRO_LOCK.InnerText = "Locked"
                    '
                    ' div_FIRE2.Style.Add("cursor", "not-allowed")
                    ' div_FIRE2.Style.Add(" pointer-events", "none")
                    ' FIRE_LOCK.InnerText = "Locked"
                    '
                    ' div_HO.Style.Add("cursor", "not-allowed")
                    ' div_HO.Style.Add(" pointer-events", "none")
                    ' HO_LOCK.InnerText = "Locked"
                End If
            Else
             
            End If
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
   
    Sub get_Draft(AppID, Email)
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubSelect4(AppID, BusName, BusAdd, brgy)
        txt_AppNo.Value = AppID
        txt_BusTradeName.Value = BusName
        txt_BusAddress.Value = BusAdd
        txt_Brgy.Value = brgy
    End Sub

    Sub get_requirements()
        'BPLTAS LIVE
        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
        _nClBP._pSubRecordSelectSpecific()

        cSessionLoader._pBPLTAS_SvrName = _nClBP._pDBDataSource
        cSessionLoader._pBPLTAS_DbName = _nClBP._pDBInitialCatalog

        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        _nClass.Application_ID = AppID
        'Barangay - BRGY
        'ZONING - CZAO
        'building - OCBO
        'Health  - HO
        'Environment - CENRO
        'Fire - FIRE

        _nClass._pSubSelectRequirements("BRGY")
        Grid_BRGY.DataSource = _nClass._mDataTable
        Grid_BRGY.DataBind()

        _nClass._pSubSelectRequirements(GetAbbrv("PDO"))
        Grid_CPDO.DataSource = _nClass._mDataTable
        Grid_CPDO.DataBind()

        _nClass._pSubSelectRequirements(GetAbbrv("ENG"))
        Grid_BLDG.DataSource = _nClass._mDataTable
        Grid_BLDG.DataBind()

        _nClass._pSubSelectRequirements("HO")
        Grid_HO.DataSource = _nClass._mDataTable
        Grid_HO.DataBind()

        _nClass._pSubSelectRequirements(GetAbbrv("ENRO"))
        Grid_CENRO.DataSource = _nClass._mDataTable
        Grid_CENRO.DataBind()

        _nClass._pSubSelectRequirements("FIRE")
        Grid_FIRE.DataSource = _nClass._mDataTable
        Grid_FIRE.DataBind()


    End Sub



    Sub get_DisplaySubmitted(SWITCH)
        Try
            ClearanceNo = Nothing
            Info1 = Nothing
            Info2 = Nothing
            Info3 = Nothing
            Info4 = Nothing
            Info5 = Nothing
            Status = Nothing
            Remarks = Nothing
            Date_Assessed = Nothing


            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubSelectSubmitted(AppID, cSessionUser._pUserID, SWITCH, ClearanceNo, Info1, Info2, Info3, Info4, Info5, Status, Remarks, Date_Assessed)
            Select Case (SWITCH)
                Case GetAbbrv("PDO")
                    CPDO_LOCK.InnerText = Status
                    If Status = "Approved" Then
                        stCPDO = True
                        CPDO_LOCK.Style.Add("color", "green")
                        btn_CPDO.Visible = False
                        For Each row As GridViewRow In Grid_CPDO.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("CPDO_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        CPDO_Info1.Attributes.Add("readonly", "readonly")
                        CPDO_Info2.Attributes.Add("readonly", "readonly")
                        CPDO_Info3.Attributes.Add("readonly", "readonly")
                        CPDO_Info4.Attributes.Add("readonly", "readonly")
                        CPDO_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Pending" Then
                        stCPDO = False
                        CPDO_LOCK.Style.Add("color", "blue")
                        btn_CPDO.Visible = False
                        For Each row As GridViewRow In Grid_CPDO.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("CPDO_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        CPDO_Info1.Attributes.Add("readonly", "readonly")
                        CPDO_Info2.Attributes.Add("readonly", "readonly")
                        CPDO_Info3.Attributes.Add("readonly", "readonly")
                        CPDO_Info4.Attributes.Add("readonly", "readonly")
                        CPDO_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Rejected" Then
                        stCPDO = False
                        CPDO_LOCK.Style.Add("color", "red")
                    Else

                    End If

                    CPDO_ClearanceNo.Value = ClearanceNo
                    CPDO_Info1.Value = Info1
                    CPDO_Info2.Value = Info2
                    CPDO_Info3.Value = Info3
                    CPDO_Info4.Value = Info4
                    CPDO_Info5.Value = Info5



                    CPDO_Status.Value = Status
                    CPDO_Remarks.Value = Remarks
                Case "HO"
                    HO_LOCK.InnerText = Status
                    If Status = "Approved" Then
                        HO_LOCK.Style.Add("color", "green")
                        btn_HO.Visible = False
                        For Each row As GridViewRow In Grid_HO.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("HO_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        HO_Info1.Attributes.Add("readonly", "readonly")
                        HO_Info2.Attributes.Add("readonly", "readonly")
                        HO_Info3.Attributes.Add("readonly", "readonly")
                        HO_Info4.Attributes.Add("readonly", "readonly")
                        HO_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Pending" Then
                        HO_LOCK.Style.Add("color", "blue")
                        btn_HO.Visible = False
                        For Each row As GridViewRow In Grid_HO.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("HO_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        HO_Info1.Attributes.Add("readonly", "readonly")
                        HO_Info2.Attributes.Add("readonly", "readonly")
                        HO_Info3.Attributes.Add("readonly", "readonly")
                        HO_Info4.Attributes.Add("readonly", "readonly")
                        HO_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Rejected" Then
                        HO_LOCK.Style.Add("color", "red")
                    End If

                    HO_ClearanceNo.Value = ClearanceNo
                    HO_Info1.Value = Info1
                    HO_Info2.Value = Info2
                    HO_Info3.Value = Info3
                    HO_Info4.Value = Info4
                    HO_Info5.Value = Info5
                    HO_Status.Value = Status
                    HO_Remarks.Value = Remarks

                  
                Case "BRGY"
                    BRGY_LOCK.InnerText = Status
                    If Status = "Approved" Then
                        stBRGY = True
                        BRGY_LOCK.Style.Add("color", "green")
                        btn_BRGY.Visible = False
                        For Each row As GridViewRow In Grid_BRGY.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("BRGY_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                    ElseIf Status = "Pending" Then
                        stBRGY = False
                        BRGY_LOCK.Style.Add("color", "blue")
                        btn_BRGY.Visible = False
                        For Each row As GridViewRow In Grid_BRGY.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("BRGY_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                    ElseIf Status = "Rejected" Then
                        stBRGY = False
                        BRGY_LOCK.Style.Add("color", "red")
                    End If

                    '    btn_BRGY.Visible = False
                    BRGY_ClearanceNo.Value = ClearanceNo
                    '  = BRGY_Info1.Value = txInfo1
                    '  = BRGY_Info2.Value =txInfo2
                    '  = BRGY_Info3.Value =txInfo3
                    '  = BRGY_Info4.Value =txInfo4
                    '  = BRGY_Info5.Value =txInfo5
                    BRGY_Status.Value = Status
                    BRGY_Remarks.Value = Remarks

                    'BRGY_Info1.Attributes.Add("readonly", "readonly")
                    'BRGY_Info2.Attributes.Add("readonly", "readonly")
                    'BRGY_Info3.Attributes.Add("readonly", "readonly")
                    'BRGY_Info4.Attributes.Add("readonly", "readonly")
                    'BRGY_Info5.Attributes.Add("readonly", "readonly")

                Case GetAbbrv("ENRO")
                    CENRO_LOCK.InnerText = Status
                    If Status = "Approved" Then
                        CENRO_LOCK.Style.Add("color", "green")
                        btn_CENRO.Visible = False
                        For Each row As GridViewRow In Grid_CENRO.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("CENRO_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        CENRO_Info1.Attributes.Add("readonly", "readonly")
                        CENRO_Info2.Attributes.Add("readonly", "readonly")
                        CENRO_Info3.Attributes.Add("readonly", "readonly")
                        CENRO_Info4.Attributes.Add("readonly", "readonly")
                        CENRO_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Pending" Then
                        CENRO_LOCK.Style.Add("color", "blue")
                        btn_CENRO.Visible = False
                        For Each row As GridViewRow In Grid_CENRO.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("CENRO_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        CENRO_Info1.Attributes.Add("readonly", "readonly")
                        CENRO_Info2.Attributes.Add("readonly", "readonly")
                        CENRO_Info3.Attributes.Add("readonly", "readonly")
                        CENRO_Info4.Attributes.Add("readonly", "readonly")
                        CENRO_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Rejected" Then
                        CENRO_LOCK.Style.Add("color", "red")
                    End If
                    CENRO_ClearanceNo.Value = ClearanceNo
                    CENRO_Info1.Value = Info1
                    CENRO_Info2.Value = Info2
                    CENRO_Info3.Value = Info3
                    CENRO_Info4.Value = Info4
                    CENRO_Info5.Value = Info5
                    CENRO_Status.Value = Status
                    CENRO_Remarks.Value = Remarks

                   


                Case GetAbbrv("ENG")
                    BLDG_LOCK.InnerText = Status
                    If Status = "Approved" Then
                        BLDG_LOCK.Style.Add("color", "green")
                        btn_BLDG.Visible = False
                        For Each row As GridViewRow In Grid_BLDG.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("BLDG_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        BLDG_Info1.Attributes.Add("readonly", "readonly")
                        BLDG_Info2.Attributes.Add("readonly", "readonly")
                        BLDG_Info3.Attributes.Add("readonly", "readonly")
                        BLDG_Info4.Attributes.Add("readonly", "readonly")
                        BLDG_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Pending" Then
                        BLDG_LOCK.Style.Add("color", "blue")
                        btn_BLDG.Visible = False
                        For Each row As GridViewRow In Grid_BLDG.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("BLDG_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        BLDG_Info1.Attributes.Add("readonly", "readonly")
                        BLDG_Info2.Attributes.Add("readonly", "readonly")
                        BLDG_Info3.Attributes.Add("readonly", "readonly")
                        BLDG_Info4.Attributes.Add("readonly", "readonly")
                        BLDG_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Rejected" Then
                        BLDG_LOCK.Style.Add("color", "red")
                    End If

                    BLDG_ClearanceNo.Value = ClearanceNo
                    BLDG_Info1.Value = Info1
                    BLDG_Info2.Value = Info2
                    BLDG_Info3.Value = Info3
                    BLDG_Info4.Value = Info4
                    BLDG_Info5.Value = Info5
                    BLDG_Status.Value = Status
                    BLDG_Remarks.Value = Remarks

                    


                Case "FIRE"
                    FIRE_LOCK.InnerText = Status
                    If Status = "Approved" Then
                        FIRE_LOCK.Style.Add("color", "green")
                        btn_FIRE.Visible = False
                        For Each row As GridViewRow In Grid_FIRE.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("FIRE_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        FIRE_Info1.Attributes.Add("readonly", "readonly")
                        FIRE_Info2.Attributes.Add("readonly", "readonly")
                        FIRE_Info3.Attributes.Add("readonly", "readonly")
                        FIRE_Info4.Attributes.Add("readonly", "readonly")
                        FIRE_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Pending" Then
                        FIRE_LOCK.Style.Add("color", "blue")
                        btn_FIRE.Visible = False
                        For Each row As GridViewRow In Grid_FIRE.Rows
                            Dim file As HtmlInputFile = CType(row.FindControl("FIRE_up"), HtmlInputFile)
                            file.Visible = False
                        Next
                        FIRE_Info1.Attributes.Add("readonly", "readonly")
                        FIRE_Info2.Attributes.Add("readonly", "readonly")
                        FIRE_Info3.Attributes.Add("readonly", "readonly")
                        FIRE_Info4.Attributes.Add("readonly", "readonly")
                        FIRE_Info5.Attributes.Add("readonly", "readonly")
                    ElseIf Status = "Rejected" Then
                        FIRE_LOCK.Style.Add("color", "red")
                    End If
                    FIRE_ClearanceNo.Value = ClearanceNo
                    FIRE_Info1.Value = Info1
                    FIRE_Info2.Value = Info2
                    FIRE_Info3.Value = Info3
                    FIRE_Info4.Value = Info4
                    FIRE_Info5.Value = Info5
                    FIRE_Status.Value = Status
                    FIRE_Remarks.Value = Remarks

                  

            End Select
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnSubmit()
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        Dim Exists As Boolean
        _nClass._pCheckifBrgyExists(Exists, AppID)
        If Exists = True Then
            Exit Sub
        Else
            _nClass._pInsertBrgy(AppID)
            snackbar("green", "Barangay Clearance Submitted")
        End If


    End Sub

    Sub Submit_Info(Office As String)

        Select Case (Office)
            Case GetAbbrv("PDO")
                txInfo1 = CPDO_Info1.Value
                txInfo2 = CPDO_Info2.Value
                txInfo3 = CPDO_Info3.Value
                txInfo4 = CPDO_Info4.Value
                txInfo5 = CPDO_Info5.Value
            Case "HO"
                txInfo1 = HO_Info1.Value
                txInfo2 = HO_Info2.Value
                txInfo3 = HO_Info3.Value
                txInfo4 = HO_Info4.Value
                txInfo5 = HO_Info5.Value
            Case "BRGY"
                txInfo1 = ""
                txInfo2 = ""
                txInfo3 = ""
                txInfo4 = ""
                txInfo5 = ""
            Case GetAbbrv("ENRO")
                txInfo1 = CENRO_Info1.Value
                txInfo2 = CENRO_Info2.Value
                txInfo3 = CENRO_Info3.Value
                txInfo4 = CENRO_Info4.Value
                txInfo5 = CENRO_Info5.Value
            Case GetAbbrv("ENG")
                txInfo1 = BLDG_Info1.Value
                txInfo2 = BLDG_Info2.Value
                txInfo3 = BLDG_Info3.Value
                txInfo4 = BLDG_Info4.Value
                txInfo5 = BLDG_Info5.Value
            Case "FIRE"
                txInfo1 = FIRE_Info1.Value
                txInfo2 = FIRE_Info2.Value
                txInfo3 = FIRE_Info3.Value
                txInfo4 = FIRE_Info4.Value
                txInfo5 = FIRE_Info5.Value
        End Select

        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubInsertRegInfo(Request.QueryString("AppID"), Office, txInfo1, txInfo2, txInfo3, txInfo4, txInfo5, "Pending")
        Response.Redirect(Request.RawUrl)
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

    Private Sub btn_CPDO_ServerClick(sender As Object, e As EventArgs) Handles btn_CPDO.ServerClick
        For Each row As GridViewRow In Grid_CPDO.Rows
            Dim file As HtmlInputFile = CType(row.FindControl("CPDO_up"), HtmlInputFile)
            Dim ReqDesc = DirectCast(row.FindControl("_oLabelRequirements"), Label).Text
            Dim ReqCode = DirectCast(row.FindControl("_oLabelCode"), Label).Text
            Dim Status = DirectCast(row.FindControl("_oLabelStatus"), Label).Text
            If Status = "Approved" Or Status = "Pending" Then
            Else
                If file.PostedFile.ContentLength > 0 Then
                    Dim FD As HttpPostedFile = file.PostedFile
                    Dim File_Name As String = file.PostedFile.FileName
                    Dim File_Type As String = file.PostedFile.ContentType
                    Dim fs As Stream = FD.InputStream
                    Dim br As New BinaryReader(fs)
                    Dim File_Data As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                    Dim _nClass As New cDalNewBP
                    Dim File_Data64 As String = "data:" & File_Type & ";base64," & Convert.ToBase64String(File_Data)
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass._pSubInsertRegAttachment(AppID, GetAbbrv("PDO"), ReqCode, ReqDesc, File_Name, File_Type, File_Data64, "Pending")
                End If
            End If
        Next

        Submit_Info(GetAbbrv("PDO"))
        get_requirements()

    End Sub

    Private Sub btn_HO_ServerClick(sender As Object, e As EventArgs) Handles btn_HO.ServerClick
        For Each row As GridViewRow In Grid_HO.Rows
            Dim file As HtmlInputFile = CType(row.FindControl("HO_up"), HtmlInputFile)
            Dim ReqDesc = DirectCast(row.FindControl("_oLabelRequirements"), Label).Text
            Dim ReqCode = DirectCast(row.FindControl("_oLabelCode"), Label).Text
            Dim Status = DirectCast(row.FindControl("_oLabelStatus"), Label).Text
            If Status <> "Approved" Or Status <> "Pending" Then
                If file.PostedFile.ContentLength > 0 Then
                    Dim FD As HttpPostedFile = file.PostedFile
                    Dim File_Name As String = file.PostedFile.FileName
                    Dim File_Type As String = file.PostedFile.ContentType
                    Dim fs As Stream = FD.InputStream
                    Dim br As New BinaryReader(fs)
                    Dim File_Data As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                    Dim _nClass As New cDalNewBP
                    Dim File_Data64 As String = "data:" & File_Type & ";base64," & Convert.ToBase64String(File_Data)
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass._pSubInsertRegAttachment(AppID, "HO", ReqCode, ReqDesc, File_Name, File_Type, File_Data64, "Pending")
                End If
            End If
        Next
        Submit_Info("HO")
        get_requirements()
    End Sub

    Private Sub btn_BRGY_ServerClick(sender As Object, e As EventArgs) Handles btn_BRGY.ServerClick
        For Each row As GridViewRow In Grid_BRGY.Rows
            Dim file As HtmlInputFile = CType(row.FindControl("BRGY_up"), HtmlInputFile)
            Dim ReqDesc = DirectCast(row.FindControl("_oLabelRequirements"), Label).Text
            Dim ReqCode = DirectCast(row.FindControl("_oLabelCode"), Label).Text
            Dim Status = DirectCast(row.FindControl("_oLabelStatus"), Label).Text
            If Status <> "Approved" Or Status <> "Pending" Then
                If file.PostedFile.ContentLength > 0 Then
                    Dim FD As HttpPostedFile = file.PostedFile
                    Dim File_Name As String = file.PostedFile.FileName
                    Dim File_Type As String = file.PostedFile.ContentType
                    Dim fs As Stream = FD.InputStream
                    Dim br As New BinaryReader(fs)
                    Dim File_Data As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                    Dim _nClass As New cDalNewBP
                    Dim File_Data64 As String = "data:" & File_Type & ";base64," & Convert.ToBase64String(File_Data)
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass._pSubInsertRegAttachment(AppID, "BRGY", ReqCode, ReqDesc, File_Name, File_Type, File_Data64, "Pending")
                End If
            End If
        Next
        Submit_Info("BRGY")
        get_requirements()
    End Sub

    Private Sub btn_CENRO_ServerClick(sender As Object, e As EventArgs) Handles btn_CENRO.ServerClick
        For Each row As GridViewRow In Grid_CENRO.Rows
            Dim file As HtmlInputFile = CType(row.FindControl("CENRO_up"), HtmlInputFile)
            Dim ReqDesc = DirectCast(row.FindControl("_oLabelRequirements"), Label).Text
            Dim ReqCode = DirectCast(row.FindControl("_oLabelCode"), Label).Text
            Dim Status = DirectCast(row.FindControl("_oLabelStatus"), Label).Text
            If Status <> "Approved" Or Status <> "Pending" Then
                If file.PostedFile.ContentLength > 0 Then
                    Dim FD As HttpPostedFile = file.PostedFile
                    Dim File_Name As String = file.PostedFile.FileName
                    Dim File_Type As String = file.PostedFile.ContentType
                    Dim fs As Stream = FD.InputStream
                    Dim br As New BinaryReader(fs)
                    Dim File_Data As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                    Dim _nClass As New cDalNewBP
                    Dim File_Data64 As String = "data:" & File_Type & ";base64," & Convert.ToBase64String(File_Data)
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass._pSubInsertRegAttachment(AppID, GetAbbrv("ENRO"), ReqCode, ReqDesc, File_Name, File_Type, File_Data64, "Pending")
                End If
            End If
        Next
        Submit_Info(GetAbbrv("ENRO"))
        get_requirements()
    End Sub
    Private Sub btn_BLDG_ServerClick(sender As Object, e As EventArgs) Handles btn_BLDG.ServerClick
        For Each row As GridViewRow In Grid_BLDG.Rows
            Dim file As HtmlInputFile = CType(row.FindControl("BLDG_up"), HtmlInputFile)
            Dim ReqDesc = DirectCast(row.FindControl("_oLabelRequirements"), Label).Text
            Dim ReqCode = DirectCast(row.FindControl("_oLabelCode"), Label).Text
            Dim Status = DirectCast(row.FindControl("_oLabelStatus"), Label).Text
            If Status <> "Approved" Or Status <> "Pending" Then
                If file.PostedFile.ContentLength > 0 Then
                    Dim FD As HttpPostedFile = file.PostedFile
                    Dim File_Name As String = file.PostedFile.FileName
                    Dim File_Type As String = file.PostedFile.ContentType
                    Dim fs As Stream = FD.InputStream
                    Dim br As New BinaryReader(fs)
                    Dim File_Data As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                    Dim _nClass As New cDalNewBP
                    Dim File_Data64 As String = "data:" & File_Type & ";base64," & Convert.ToBase64String(File_Data)
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass._pSubInsertRegAttachment(AppID, GetAbbrv("ENG"), ReqCode, ReqDesc, File_Name, File_Type, File_Data64, "Pending")
                End If
            End If
        Next
        Submit_Info(GetAbbrv("ENG"))
        get_requirements()
    End Sub

    Private Sub btn_FIRE_ServerClick(sender As Object, e As EventArgs) Handles btn_FIRE.ServerClick
        For Each row As GridViewRow In Grid_FIRE.Rows
            Dim file As HtmlInputFile = CType(row.FindControl("FIRE_up"), HtmlInputFile)
            Dim ReqDesc = DirectCast(row.FindControl("_oLabelRequirements"), Label).Text
            Dim ReqCode = DirectCast(row.FindControl("_oLabelCode"), Label).Text
            Dim Status = DirectCast(row.FindControl("_oLabelStatus"), Label).Text
            If Status <> "Approved" Or Status <> "Pending" Then
                If file.PostedFile.ContentLength > 0 Then
                    Dim FD As HttpPostedFile = file.PostedFile
                    Dim File_Name As String = file.PostedFile.FileName
                    Dim File_Type As String = file.PostedFile.ContentType
                    Dim fs As Stream = FD.InputStream
                    Dim br As New BinaryReader(fs)
                    Dim File_Data As Byte() = br.ReadBytes(Convert.ToInt32(fs.Length))
                    Dim _nClass As New cDalNewBP
                    Dim File_Data64 As String = "data:" & File_Type & ";base64," & Convert.ToBase64String(File_Data)
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    _nClass._pSubInsertRegAttachment(AppID, "FIRE", ReqCode, ReqDesc, File_Name, File_Type, File_Data64, "Pending")
                End If
            End If
        Next
        Submit_Info("FIRE")
        get_requirements()
    End Sub
End Class