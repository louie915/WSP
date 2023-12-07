Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Linq
Imports System.Data.SqlClient
Imports VB.NET.Methods

Public Class NewBP_Register
    Inherits System.Web.UI.Page
    Dim A, B, C, D, E, F, G, H, I As String
    Dim H_FileData1, I_FileData1, I_FileData2, I_FileData3, I_FileData4, I_FileData5, I_FileData6 As Byte()
    Dim H_FileName1, I_FileName1, I_FileName2, I_FileName3, I_FileName4, I_FileName5, I_FileName6 As String
    Dim H_FileType1, I_FileType1, I_FileType2, I_FileType3, I_FileType4, I_FileType5, I_FileType6 As String
    Dim exists As Boolean
    Dim Application_ID As String
    Dim quick As Boolean
    Dim _nClass As New cDalNewBP
    Dim changed_Attachments As Boolean
    Dim changed_Nature As Boolean
    Dim _Nature As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal eQ As System.EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                Get_CityProvince()
                Get_BRGY()
                Get_OWNERSHIP()
                Get_Nationality()
                Get_Gender()
                Load_Requirements("NEW")
                hdnReUpload.Value = 1

                txt_DateEsta.Attributes("value") = DateTime.Now.ToString("MM/dd/yyyy")

                If isQuick() = True Then
                    get_RegReq()
                    For Each row As GridViewRow In Grid_RegReq.Rows
                        Dim file As HtmlInputFile = CType(row.FindControl("File_up"), HtmlInputFile)
                        file.Attributes.Add("required", "true")
                    Next
                    divRegReq.Style.Add("display", "block")
                Else
                    divRegReq.Style.Add("display", "none")
                End If

                Dim valid As Boolean = False
                If Request.QueryString("AppID") <> Nothing Then
                    validate(Request.QueryString("AppID"), valid)
                    If valid = True Then
                        _LoadAttachments(cSessionUser._pUserID, Request.QueryString("AppID"))
                        divUploaded.Style.Add("display", "")
                        divUpload.Style.Add("display", "none")

                        NatureHTML.Style.Add("display", "")
                        divInputNature.Style.Add("display", "none")
                        btnChangeNature.Style.Add("display", "")
                    Else
                        Response.Redirect("Account.aspx")
                    End If
                  
                Else
                    NatureHTML.Style.Add("display", "none")
                    divInputNature.Style.Add("display", "")
                    btnChangeNature.Style.Add("display", "none")
                    '    call_setScript()
                    '  ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal();", True)
                End If

                Exit Sub
            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")
                If action = "BRGY" Then
                    Dim strArr() As String
                    strArr = val.Split("_")
                    Get_Street(strArr(1))
                End If

            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub _LoadAttachments(ByVal _email As String, ByVal _acctno As String)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            '  _nClass._pSubSelectRequirements2("NEW", _email, _acctno)
            _nClass._pSubGetAttachments("NEW", _email, _acctno)
            GVSubmittedReqs.DataSource = _nClass._mDataTable
            GVSubmittedReqs.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_Requirements(ByVal switch As String, Optional ByRef reqCount As Integer = 0)
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pSubSelectRequirements2(switch, cSessionUser._pUserID, Request.QueryString("AppID"))

            '_nClass._pSubSelectRequirements(switch)
            _GVRequirements.DataSource = _nClass._mDataTable
            _GVRequirements.DataBind()
            reqCount = _nClass._mDataTable.Rows.Count
        Catch ex As Exception

        End Try
    End Sub

    Function isQuick() As Boolean
        Dim Status As Boolean
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nClass._pSubCheckFastApply(Status)
        Return Status
    End Function
    Sub Get_CityProvince()
        Dim City_Municipality As String
        Dim Province As String

        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nClass._pSubGet_CityProvince(City_Municipality, Province)
        txt_B_CityMunicipality.Value = City_Municipality
        txt_B_Province.Value = Province
    End Sub
    Sub validate(ByVal AppID As String, ByRef valid As Boolean)

        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubCheckIfExist(exists, AppID)
        valid = exists
        If exists = True Then
            _nClass.Application_ID = AppID
            do_exists(AppID, _Nature)
        End If



    End Sub

    Sub do_exists(ByVal AppID As String, Optional ByRef _Nature As String = Nothing)
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubDisplayInfo(AppID)

        '  txt_DateEsta.Value = String.Format("{0:MM/dd/yyyy}", _nClass.Date_Esta)


        Dim dateEsta As DateTime = DateTime.Parse(_nClass.Date_Esta)
        txt_DateEsta.Value = dateEsta.ToString("MM/dd/yyyy")

        'txt_DateEsta.Attributes("value") = dateEsta.ToString("MM/dd/yyyy")


        cmb_OwnershipType.Value = Trim(_nClass.A_OWNCODE)
        txt_DtiSecCda.Value = _nClass.A_DtiSecCda
        txt_BusinessName.Value = _nClass.A_BusName
        txt_TIN.Value = _nClass.A_TIN

        txt_B_HouseNo.Value = _nClass.B_HouseNo
        txt_B_BldgName.Value = _nClass.B_BldgName
        txt_B_LotNo.Value = _nClass.B_LotNo
        txt_B_BlockNo.Value = _nClass.B_BlockNo

        For Each Item As ListItem In cmb_Brgy.Items
            If Item.Value = _nClass.B_DISTCODE & "_" & _nClass.B_BRGYCODE Then
                Item.Selected = True
                Exit For
            End If
        Next


        '  cmb_Brgy.selectedValue = _nClass.B_DISTCODE & "_" & _nClass.B_BRGYCODE


        Get_Street(_nClass.B_BRGYCODE)

        For Each Item As ListItem In cmb_Street.Items
            If Item.Value = _nClass.B_DISTCODE & "_" & _nClass.B_BRGYCODE & "_" & _nClass.B_STRTCODE Then
                Item.Selected = True
                Exit For
            End If
        Next

        '      cmb_Street.Value = _nClass.B_DISTCODE & "_" & _nClass.B_BRGYCODE & "_" & _nClass.B_STRTCODE


        txt_B_Subd.Value = _nClass.B_Subd
        txt_B_CityMunicipality.Value = _nClass.B_CityMunicipality
        txt_B_Province.Value = _nClass.B_Province
        txt_B_ZipCode.Value = _nClass.B_ZipCode

        txt_TelNo.Value = _nClass.C_TelNo
        txt_MobileNo.Value = _nClass.C_MobileNo

        txt_Sole_Lname.Value = _nClass.D_Lname
        txt_Sole_Fname.Value = _nClass.D_Fname
        txt_Sole_Mname.Value = _nClass.D_Mname
        txt_Sole_Suffix.Value = _nClass.D_Suffix
        cmb_Nationality.Value = _nClass.D_CTZNCODE

        ' _nClass.E_Lname As String = txt_Sole_Lname.Value 'txt_CorpCoopPart_Lname.Value
        ' _nClass.E_Fname As String = txt_Sole_Fname.Value 'txt_CorpCoopPart_Fname.Value
        ' _nClass.E_Mname As String = txt_Sole_Mname.Value 'txt_CorpCoopPart_Mname.Value
        ' _nClass.E_Suffix As String = txt_Sole_Suffix.Value 'txt_CorpCoopPart_Suffix.Value
        ' _nClass.E_Nationality As String = cmb_Nationality.Items(cmb_Nationality.SelectedIndex).Text

        txt_BusArea.Value = _nClass.F_BusArea
        txt_TotFlrArea.Value = _nClass.F_FlrArea
        txt_NoMaleEmp.Value = _nClass.F_MaleEmpNo
        txt_NoFemaleEmp.Value = _nClass.F_FemaleEmpNo
        txt_NoResidingEmp.Value = _nClass.F_ResideEmpNo
        txt_DelVanTruck.Value = _nClass.F_VanTruckNo
        txt_DelMotor.Value = _nClass.F_MotorNo

        txt_HouseNo.Value = _nClass.G_HouseNo
        txt_BldgName.Value = _nClass.G_BldgName
        txt_LotNo.Value = _nClass.G_LotNo
        txt_BlockNo.Value = _nClass.G_BlockNo
        txt_Street.Value = _nClass.G_Street
        txt_Brgy.Value = _nClass.G_Brgy
        txt_Subd.Value = _nClass.G_Subd
        txt_CityMunicipality.Value = _nClass.G_CityMunicipality
        txt_Province.Value = _nClass.G_Province
        txt_Zip.Value = _nClass.G_ZipCode

        txt_Capital.InnerText = _nClass.H_Capital
        txt_Nature.Value = _nClass.H_Nature
        NatureHTML.InnerHtml = _nClass.H_Nature
        _Nature = _nClass.H_Nature

        cmb_Owned.Value = _nClass.H_Owned
        txt_TDN.Value = _nClass.H_TDN
        txt_PIN.Value = _nClass.H_PIN
        cmb_Incentive.Value = _nClass.H_GovIncentive
        ' _nClass.H_BusAct As String = "Main Office" 'txt_BusActSpecify.Value

        Dim Submitted As Boolean = _nClass.Submitted
        Dim Status As String = _nClass.Status


        '   Dim H_FileData164 As String = "data:" & H_FileType1 & ";base64," & Convert.ToBase64String(H_FileData1)
        '   Dim I_FileData164 As String = "data:" & I_FileType1 & ";base64," & Convert.ToBase64String(I_FileData1)
        '   Dim I_FileData264 As String = "data:" & I_FileType2 & ";base64," & Convert.ToBase64String(I_FileData2)
        '   Dim I_FileData364 As String = "data:" & I_FileType3 & ";base64," & Convert.ToBase64String(I_FileData3)
        '   Dim I_FileData464 As String = "data:" & I_FileType4 & ";base64," & Convert.ToBase64String(I_FileData4)
        '   Dim I_FileData564 As String = "data:" & I_FileType5 & ";base64," & Convert.ToBase64String(I_FileData5)
        '   Dim I_FileData664 As String = "data:" & I_FileType6 & ";base64," & Convert.ToBase64String(I_FileData6)


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
    Private Sub Get_OWNERSHIP()
        Try
            '----------------------------------
            cmb_OwnershipType.DataSourceID = Nothing

            Dim _nSqlStr As String
            Dim _mDatatableStrt As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT * FROM OWNCODE ORDER BY (CASE WHEN OWNCODE = 'S' THEN 0 ELSE 1 END), OWNDESC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableStrt)

            Try
                '----------------------------------
                cmb_OwnershipType.DataSource = _mDatatableStrt
                cmb_OwnershipType.DataTextField = "OWNDESC"
                cmb_OwnershipType.DataValueField = "OWNCODE"
                cmb_OwnershipType.DataBind()

                '----------------------------------
            Catch ex As Exception

            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Get_BRGY()
        Try
            '----------------------------------
            cmb_Brgy.DataSourceID = Nothing

            Dim _nSqlStr As String
            Dim _mDatatableStrt As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT BRGYDESC, DISTCODE + '_' + BRGYCODE as DISTCODE_BRGYCODE from BRGYCODE order by BRGYDESC ASC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableStrt)

            Try
                '----------------------------------
                cmb_Brgy.DataSource = _mDatatableStrt
                cmb_Brgy.DataTextField = "BRGYDESC"
                cmb_Brgy.DataValueField = "DISTCODE_BRGYCODE"
                cmb_Brgy.DataBind()

                If Request.QueryString("AppID") = Nothing Then
                    cmb_Brgy.Items.Insert(0, New ListItem("Select", "", True))
                End If
        
                '----------------------------------
            Catch ex As Exception

            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Get_Nationality()
        Try
            '----------------------------------
            cmb_Nationality.DataSourceID = Nothing

            Dim _nSqlStr As String
            Dim _mDatatableStrt As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT * FROM [CTZNCODE] ORDER BY (CASE WHEN CTZNCODE = 'FIL' THEN 0 ELSE 1 END), CTZNDESC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableStrt)

            Try
                '----------------------------------
                cmb_Nationality.DataSource = _mDatatableStrt
                cmb_Nationality.DataTextField = "CTZNDESC"
                cmb_Nationality.DataValueField = "CTZNCODE"
                cmb_Nationality.DataBind()

                '----------------------------------
            Catch ex As Exception

            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Get_Gender()
        Try
            '----------------------------------
            cmb_Gender.DataSourceID = Nothing

            Dim _nSqlStr As String
            Dim _mDatatableStrt As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT * FROM [SEXCODE] ORDER BY (CASE WHEN SEXCODE = 'M' THEN 0 ELSE 1 END), SEXDESC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableStrt)

            Try
                '----------------------------------
                cmb_Gender.DataSource = _mDatatableStrt
                cmb_Gender.DataTextField = "SEXDESC"
                cmb_Gender.DataValueField = "SEXCODE"
                cmb_Gender.DataBind()

                '----------------------------------
            Catch ex As Exception

            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Get_Street(ByVal brgycode As String)
        Try
            '----------------------------------
            cmb_Street.DataSourceID = Nothing

            Dim _nSqlStr As String
            Dim _mDatatableStrt As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            ' _nSqlStr = "SELECT STRTDESC, DISTCODE + '_' + BRGYCODE + '_' + STRTCODE as DISTCODE_BRGYCODE_STRTCODE from STRTCODE where BRGYCODE='" & brgycode & "' order by STRTDESC ASC"

            _nSqlStr = "" & _
                " IF ((select count(*) from STRTCODE where BRGYCODE='" & brgycode & "') > 0)" & _
                " BEGIN" & _
                " SELECT STRTDESC, DISTCODE + '_' + BRGYCODE + '_' + STRTCODE as DISTCODE_BRGYCODE_STRTCODE from STRTCODE where BRGYCODE='" & brgycode & "' order by STRTDESC ASC" & _
                " END" & _
                " ELSE IF ((select count(*) from STRTCODE where BRGYCODE='" & brgycode & "') = 0)" & _
                " BEGIN" & _
                " SELECT 'N/A' as STRTDESC,'0000_0000_0000' as DISTCODE_BRGYCODE_STRTCODE" & _
                " END"


            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableStrt)

            Try
                '----------------------------------
                cmb_Street.DataSource = _mDatatableStrt
                cmb_Street.DataTextField = "STRTDESC"
                cmb_Street.DataValueField = "DISTCODE_BRGYCODE_STRTCODE"
                cmb_Street.DataBind()



                '----------------------------------
            Catch ex As Exception

            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub


    Sub upload()
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
                            .AddWithValue("@ReqDesc", cDalBPSOS.getReqDescNEW(ReqCode, "NEW"))
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
        Catch ex As Exception

        End Try
    End Sub
    Function Complete_RegReq() As Boolean
        For Each row As GridViewRow In Grid_RegReq.Rows
            Dim file As HtmlInputFile = CType(row.FindControl("File_up"), HtmlInputFile)
            If file.PostedFile.ContentLength = 0 Then
                Return False
                Exit Function
            End If
        Next
        Return True

    End Function
    Sub Upload_RegReq()
        If isQuick() = True Then
            For Each row As GridViewRow In Grid_RegReq.Rows
                Dim file As HtmlInputFile = CType(row.FindControl("File_up"), HtmlInputFile)
                Dim OFCCODE = DirectCast(row.FindControl("lbl_OFCCODE"), Label).Text
                Dim OFCDESC = DirectCast(row.FindControl("lbl_OFCDESC"), Label).Text
                Dim REQCODE = DirectCast(row.FindControl("lbl_REQCODE"), Label).Text
                Dim REQDESC = DirectCast(row.FindControl("lbl_REQDESC"), Label).Text
                Dim Status = DirectCast(row.FindControl("_oLabelStatus"), Label).Text
                Dim Remarks = DirectCast(row.FindControl("_oLabelRemarks"), Label).Text

                If Status = "Approved" Or Status = "Pending" Then
                    Exit Sub
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
                        _nClass._pSubInsertRegAttachment(Application_ID, OFCCODE, REQCODE, REQDESC, File_Name, File_Type, File_Data64, "Pending")

                        If _nClass._pSubExistRegInfo(Application_ID, OFCCODE) = False Then
                            _nClass._pSubInsertRegInfo(Application_ID, OFCCODE, "", "", "", "", "", "Pending")
                        End If
                    Else
                        Exit Sub
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub CheckExisitngRecord()
        Try

        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnNewSubmit_ServerClick(sender As Object, e As EventArgs) Handles btnNewSubmit.ServerClick
        Try
            Dim _nClassReturnTypes As New ClassReturnTypes

            Dim DraftExists As Boolean
            Dim UserID As String = cSessionUser._pUserID

            If txt_DateEsta.Value = Nothing Then
                snackbar("red", "Date of Establishment cannot be empty")
                Exit Sub
            End If

            If isQuick() = True Then
                If Complete_RegReq() = False Then
                    snackbar("red", "Regulatory Requirements cannot be empty")
                    Exit Sub
                End If
            End If

            Dim Date_Esta As Date = CDate(txt_DateEsta.Value)
            Dim A_Ownership As String = cmb_OwnershipType.Items(cmb_OwnershipType.SelectedIndex).Text
            Dim A_OWNCODE As String = cmb_OwnershipType.Value
            Dim A_DtiSecCda As String = txt_DtiSecCda.Value
            Dim A_BusName As String = txt_BusinessName.Value
            Dim A_TIN As String = txt_TIN.Value

            Dim B_HouseNo As String = IIf(String.IsNullOrEmpty(txt_B_HouseNo.Value), " ", txt_B_HouseNo.Value)
            Dim B_BldgName As String = txt_B_BldgName.Value
            Dim B_LotNo As String = txt_B_LotNo.Value
            Dim B_BlockNo As String = txt_B_BlockNo.Value
            Dim B_Street As String = cmb_Street.Items(cmb_Street.SelectedIndex).Text
            Dim B_STRTCODE As String = cmb_Street.Value
            Dim STRTArr() As String
            STRTArr = B_STRTCODE.Split("_")
            B_STRTCODE = STRTArr(2)
            Dim B_Brgy As String = cmb_Brgy.Items(cmb_Brgy.SelectedIndex).Text
            Dim B_BRGYCODE As String = cmb_Brgy.Value
            Dim brgyArr() As String
            brgyArr = B_BRGYCODE.Split("_")
            B_BRGYCODE = brgyArr(1)
            Dim B_DISTCODE As String = brgyArr(0)
            Dim B_Subd As String = txt_B_Subd.Value
            Dim B_CityMunicipality As String = txt_B_CityMunicipality.Value
            Dim B_Province As String = txt_B_Province.Value
            Dim B_ZipCode As String = txt_B_ZipCode.Value

            Dim C_TelNo As String = IIf(String.IsNullOrEmpty(txt_TelNo.Value), " ", txt_TelNo.Value)
            Dim C_MobileNo As String = txt_MobileNo.Value
            Dim C_Email As String = cSessionUser._pUserID

            Dim D_Lname As String = txt_Sole_Lname.Value
            Dim D_Fname As String = txt_Sole_Fname.Value
            Dim D_Mname As String = txt_Sole_Mname.Value
            Dim D_Suffix As String = txt_Sole_Suffix.Value
            Dim D_CTZNDESC As String = cmb_Nationality.Items(cmb_Nationality.SelectedIndex).Text
            Dim D_CTZNCODE As String = cmb_Nationality.Value

            Dim E_Lname As String = txt_Sole_Lname.Value 'txt_CorpCoopPart_Lname.Value
            Dim E_Fname As String = txt_Sole_Fname.Value 'txt_CorpCoopPart_Fname.Value
            Dim E_Mname As String = txt_Sole_Mname.Value 'txt_CorpCoopPart_Mname.Value
            Dim E_Suffix As String = txt_Sole_Suffix.Value 'txt_CorpCoopPart_Suffix.Value
            Dim E_Nationality As String = cmb_Nationality.Items(cmb_Nationality.SelectedIndex).Text

            Dim F_BusArea As String = txt_BusArea.Value
            Dim F_FlrArea As String = txt_TotFlrArea.Value
            Dim F_MaleEmpNo As String = txt_NoMaleEmp.Value
            Dim F_FemaleEmpNo As String = txt_NoFemaleEmp.Value
            Dim F_ResideEmpNo As String = txt_NoResidingEmp.Value
            Dim F_VanTruckNo As String = txt_DelVanTruck.Value
            Dim F_MotorNo As String = txt_DelMotor.Value

            Dim G_HouseNo, G_BldgName, G_LotNo, G_BlockNo, G_Street, G_Brgy, G_Subd, G_CityMunicipality, G_Province, G_ZipCode As String

            ' If String.IsNullOrEmpty(hdnSame.Value) = True Then hdnSame.Value = False

            If IIf(String.IsNullOrEmpty(hdnSame.Value) = False, True, False) = True Then
                G_HouseNo = B_HouseNo
                G_BldgName = B_BldgName
                G_LotNo = B_LotNo
                G_BlockNo = B_BlockNo
                G_Street = B_Street
                G_Brgy = B_Brgy
                G_Subd = B_Subd
                G_CityMunicipality = B_CityMunicipality
                G_Province = B_Province
                G_ZipCode = B_ZipCode
            Else
                G_HouseNo = txt_HouseNo.Value
                G_BldgName = txt_BldgName.Value
                G_LotNo = txt_LotNo.Value
                G_BlockNo = txt_BlockNo.Value
                G_Street = txt_Street.Value
                G_Brgy = txt_Brgy.Value
                G_Subd = txt_Subd.Value
                G_CityMunicipality = txt_CityMunicipality.Value
                G_Province = txt_Province.Value
                G_ZipCode = txt_Zip.Value
            End If



            Dim H_Capital As String = txt_Capital.InnerText.Replace(",", "")
            Dim H_Nature As String = txt_Nature.Value
            Dim H_Owned As String = cmb_Owned.Value
            Dim H_TDN As String = txt_TDN.Value
            Dim H_PIN As String = txt_PIN.Value
            Dim H_GovIncentive As String = cmb_Incentive.Value
            Dim H_BusAct As String = "Main Office" 'txt_BusActSpecify.Value

            Dim Submitted As Boolean = True
            Dim Date_Created As DateTime
            Dim Date_LastEdit As DateTime
            Dim Date_Submitted As DateTime
            Dim Status As String = "Submitted/Pending"

            Dim getdate As DateTime
            Dim getYear As String



            Dim _nClass As New cDalNewBP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._pSubGetDate(getdate)
            _nClass._pSubGetYear(getYear)
            If exists = True Then
                Date_LastEdit = getdate
                _nClass._pSubApplicationID(Application_ID)
                If changed_Nature = True Then
                    H_Nature = _Nature
                End If
                _nClass._pSubUpdate_NewSubmit(
                       Application_ID, UserID, Date_Esta, A_Ownership, A_OWNCODE, A_DtiSecCda, A_BusName, A_TIN, _
                       B_HouseNo, B_BldgName, B_LotNo, B_BlockNo, B_Street, B_STRTCODE, B_Brgy, B_BRGYCODE, B_DISTCODE, B_Subd, B_CityMunicipality, B_Province, B_ZipCode, _
                       C_TelNo, C_MobileNo, C_Email, _
                       D_Lname, D_Fname, D_Mname, D_Suffix, D_CTZNCODE, D_CTZNDESC, _
                       E_Lname, E_Fname, E_Mname, E_Suffix, E_Nationality, _
                       F_BusArea, F_FlrArea, F_MaleEmpNo, F_FemaleEmpNo, F_ResideEmpNo, F_VanTruckNo, F_MotorNo, _
                       G_HouseNo, G_BldgName, G_LotNo, G_BlockNo, G_Street, G_Brgy, G_Subd, G_CityMunicipality, G_Province, G_ZipCode, _
                       H_Capital, H_Nature, H_Owned, H_TDN, H_PIN, H_GovIncentive, H_BusAct, _
                       Submitted, Date_Created, Date_LastEdit, Date_Submitted, Status)
                cSessionLoader._pAccountNo = Application_ID
                If changed_Attachments = True Then
                    upload()
                    Upload_RegReq()
                End If


            Else
                Date_Created = getdate
                Date_LastEdit = getdate
                Date_Submitted = getdate

                _nClass._pSubApplicationID(Application_ID)
                _nClass._pSubInsert_NewSubmit(
                       Application_ID, UserID, Date_Esta, A_Ownership, A_OWNCODE, A_DtiSecCda, A_BusName, A_TIN, _
                       B_HouseNo, B_BldgName, B_LotNo, B_BlockNo, B_Street, B_STRTCODE, B_Brgy, B_BRGYCODE, B_DISTCODE, B_Subd, B_CityMunicipality, B_Province, B_ZipCode, _
                       C_TelNo, C_MobileNo, C_Email, _
                       D_Lname, D_Fname, D_Mname, D_Suffix, D_CTZNCODE, D_CTZNDESC, _
                       E_Lname, E_Fname, E_Mname, E_Suffix, E_Nationality, _
                       F_BusArea, F_FlrArea, F_MaleEmpNo, F_FemaleEmpNo, F_ResideEmpNo, F_VanTruckNo, F_MotorNo, _
                       G_HouseNo, G_BldgName, G_LotNo, G_BlockNo, G_Street, G_Brgy, G_Subd, G_CityMunicipality, G_Province, G_ZipCode, _
                       H_Capital, H_Nature, H_Owned, H_TDN, H_PIN, H_GovIncentive, H_BusAct, _
                       Submitted, Date_Created, Date_LastEdit, Date_Submitted, Status)
                cSessionLoader._pAccountNo = Application_ID
                upload()
                Upload_RegReq()

            End If

            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String



            '--------------------------------
            'INSERT INTO BUSMAST
            Try
                Dim _nClass2 As New cDalBusMast
                With _nClass2
                    '._pAdd()
                    ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

                    ._pACCTNO = Application_ID
                    ._pAPP_DATE = getdate

                    ' == BUSINESS INFO
                    ._pDATE_ESTA = Date_Esta
                    ._pOWNCODE = A_OWNCODE

                    ._pCOMMNAME = A_BusName


                    Dim strCOMMADDR As String = B_HouseNo & " " & B_BldgName & " " & B_LotNo & " " & B_BlockNo & " " & B_Street & " " & B_Brgy & " " & B_Subd & " " & B_CityMunicipality & " " & B_Province & " " & B_ZipCode
                    Dim strOWNERADDR As String = G_HouseNo & " " & G_BldgName & " " & G_LotNo & " " & G_BlockNo & " " & G_Street & " " & G_Brgy & " " & G_Subd & " " & G_CityMunicipality & " " & G_Province & " " & G_ZipCode
                    Dim COMMADDR As String = Regex.Replace(strCOMMADDR, "/\s\s+/g", "")
                    Dim OWNERADDR As String = Regex.Replace(strOWNERADDR, "/\s\s+/g", "")

                    ._pCOMMADDR = COMMADDR

                    ._pSTICKERNO = Nothing
                    ._pBRGYCODE = B_BRGYCODE
                    ._pSTRTCODE = B_STRTCODE
                    ._pDISTCODE = B_DISTCODE
                    ._pGRPBLDG = Nothing

                    ._pNO_EMP = F_MaleEmpNo + F_FemaleEmpNo
                    ._pPLATENO = Nothing
                    ._pSTALLNO = Nothing

                    If A_OWNCODE = "S" Then
                        ._pLAST_NAME = D_Lname
                        ._pFIRST_NAME = D_Fname
                        ._pMIDDLE_NAME = D_Mname
                    Else
                        ._pLAST_NAME = A_BusName
                    End If

                    ._pOWNERADDR = OWNERADDR
                    ._pCTZNCODE = D_CTZNCODE
                
                    ._pOWNERTEL = C_TelNo
                    ._pEMAILADDR = C_Email
                    ._pEMAILADDR2 = Nothing

                    ._pCONTACT = Nothing
                    ._pCONTTEL = C_TelNo
                    ._pCPNO = C_MobileNo
                    ._pCPNO2 = Nothing


                    ._pCPNoGTM = Nothing
                    ._pCPNoSMTNT = Nothing
                    ._pCPNoSun = Nothing

                    ._pTIN_NO = A_TIN
                    ._pTIN_DATE = Nothing

                    ._pSSS_NO = Nothing
                    ._pSSS_DATE = Nothing

                    ._pBC_NO = Nothing
                    ._pBC_DATE = Nothing

                    ._pPEZA_NO = Nothing
                    ._pPEZA_DATE = Nothing

                    ._pACR_NO = Nothing
                    ._pACR_DATE = Nothing

                    ._pBLDGPERMITNO = Nothing
                    ._pBLDGPERMITDATE = Nothing

                    ._pOCCUPANCYNO = Nothing
                    ._pOCCUPANCYDATE = Nothing

                    ._pBOI_NO = Nothing
                    ._pBOI_DATE = Nothing

                    ._pCTC_NO = Nothing
                    ._pCTC_DATE = Nothing
                    ._pCTC_PLACE = Nothing
                    ._pCTC_AMT = Nothing

                    Select Case True
                        Case A_Ownership.Contains("SINGLE"), A_Ownership.Contains("SOLE"), A_Ownership.Contains("PARTNERSHIP")
                            ._pDTI_NO = A_DtiSecCda
                            ._pDTI_DATE = Nothing
                        Case A_Ownership.Contains("CORP"), A_Ownership.Contains("FOUNDATION")
                            ._pSEC_NO = A_DtiSecCda
                            ._pSEC_DATE = Nothing
                        Case A_Ownership.Contains("COOPERATIVE")
                            ._pCDA_NO = A_DtiSecCda
                            ._pCDA_DATE = Nothing
                    End Select

                    '._pCDA_NO = A_DtiSecCda
                    '._pCDA_DATE = Nothing
                    '._pDTI_NO = A_DtiSecCda
                    '._pDTI_DATE = Nothing
                    '._pSEC_NO = A_DtiSecCda
                    '._pSEC_DATE = Nothing

                    ._pSTATCODE = "N"

                    ._pSubInsert(_nSuccessful, Nothing, _nErrMsg)
                End With
            Catch ex As Exception
                snackbar("red", "Error Code : NCLS002")
            End Try
            '--------------------------------
            'INSERT INTO BUSMAST-EXTN
            Try
                Dim _nClass3 As New cDalBusMastExtn

                With _nClass3
                    ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                    ._pACCTNO = Application_ID

     

                    ._pAUTHO_REP = Nothing
                    ._pAUTHO_REP_POS = Nothing
                    ._pBLDG = B_BldgName
                    ._pBRGY = B_Brgy
                    ._pCITY = B_CityMunicipality
                    ._pDOWNLOADED = Nothing
                    ._pEMAIL = C_Email
                    ._pEMRGNCY_CONTACT = Nothing
                    ._pEMRGNCY_EMAIL = Nothing
                    ._pEMRGNCY_MOBILE = Nothing
                    ._pEMRGNCY_TEL = Nothing
                    ._pFIRSTNAME = D_Fname
                    ._pFORYEAR = getYear
                    ._pIF_WITH_TAX = Nothing
                    ._pLASTNAME = D_Lname
                    ._pMIDDLENAME = D_Mname
                    ._pNO_EMP_F = F_FemaleEmpNo
                    ._pNO_EMP_M = F_MaleEmpNo
                    ._pNO_EMP_LGU = F_ResideEmpNo

                    If A_OWNCODE <> "S" Then
                        Dim Gender As String = cmb_Gender.Items(cmb_Gender.SelectedIndex).Text

                        ._pPRES_GENDER = Gender(0)
                        ._pPres_FName = D_Fname
                        ._pPres_LName = D_Lname
                        ._pPres_MName = D_Mname
                        ._pPRES_NAME = D_Lname & IIf(D_Lname <> "", ", " & D_Fname, "") & IIf(D_Lname <> "", " " & D_Mname, "")
                    End If


                    ._pP_Gender = cmb_Gender.Items(cmb_Gender.SelectedIndex).Text
                    ._pP_Treasurer = Nothing
                  
                    ._pPROVINCE = B_Province
                    ._pSTREET = B_Street
                    ._pSUBD = B_Subd
                    ._pTAX_INDIC = Nothing
                    ._pTEL = C_TelNo
                    ._pTREAS_NAME = Nothing
                    ._pUPLOADED = Nothing

                    ._pSubInsert(_nSuccessful, Nothing, _nErrMsg)
                End With
            Catch ex As Exception
                snackbar("red", "Error Code : NCLS003")
            End Try




            Dim Sent As Boolean
            Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                                 "Your New Business Application is now submitted to BPLO for further verification." & _
                                 "Thank you for choosing online transaction. Have a wonderful day! <br><br>"
            cDalNewSendEmail.SendEmail(cSessionUser._pUserID, "New Business Application Status", Body, Sent)

            Dim Emails As String
            Body = "Taxpayer has applied for New Business with the following details: <br>" & _
                   "Email Address : " & cSessionUser._pUserID & _
                   "<br>" & H_Nature & _
                   "<br> Please login to your Web Account to Assess the Application. Thank you <br><br>"

            cDalNewSendEmail.get_Emails("BPLO", Emails)
            cDalNewSendEmail.SendEmail(Emails, "New Business Application", Body, Sent)

            snackbar("green", "Application Submitted")
            Response.Redirect("./NotificationPages/ApplicationSuccess.aspx")

            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModalSubmit();", True)

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Sub

    Private Sub cmb_Owned_ServerChange(sender As Object, e As EventArgs) Handles cmb_Owned.ServerChange
        If cmb_Owned.Value = 0 Then
            txt_TDN.Attributes.Add("disabled", "true")
        Else
            txt_TDN.Attributes.Add("disabled", "false")
        End If
    End Sub

    Private Sub cmb_Incentive_ServerChange(sender As Object, e As EventArgs) Handles cmb_Incentive.ServerChange
        If cmb_Incentive.Value = 0 Then
            up_Incentive.Attributes.Add("disabled", "true")
        Else
            up_Incentive.Attributes.Add("disabled", "false")
        End If
    End Sub

    Sub get_RegReq(Optional APPID As String = Nothing)
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass.Application_ID = APPID
        _nClass._pSubSelectRequirements("ALL")
        Grid_RegReq.DataSource = _nClass._mDataTable
        Grid_RegReq.DataBind()
    End Sub

    Protected Sub datagrid_PageIndexChanging_RegReq(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            get_RegReq()
            Grid_RegReq.PageIndex = e.NewPageIndex
            Grid_RegReq.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub datagrid_PageIndexChanging_GVReq(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            Load_Requirements("NEW")
            _GVRequirements.PageIndex = e.NewPageIndex
            _GVRequirements.DataBind()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnChangeNature_ServerClick(sender As Object, e As EventArgs) Handles btnChangeNature.ServerClick
        changed_Nature = True
        NatureHTML.Style.Add("display", "none")
        divInputNature.Style.Add("display", "")
        btnChangeNature.Style.Add("display", "none")
    End Sub

    Private Sub btnReUpload_ServerClick(sender As Object, e As EventArgs) Handles btnReUpload.ServerClick
        changed_Attachments = False
        divUploaded.Style.Add("display", "none")
        divUpload.Style.Add("display", "")
        hdnReUpload.Value = 0
    End Sub
End Class