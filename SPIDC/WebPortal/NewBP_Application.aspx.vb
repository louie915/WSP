Imports System.IO

Public Class NewBP_Application
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                display_Existing()
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal();", True)

                Exit Sub
            Else

            End If

        Catch ex As Exception

        End Try





    End Sub

    Sub display_Existing()
        Dim _nClass As New cDalNewBP
        Dim ApplicationNo As String = Nothing
        Dim DraftExists As Boolean
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        _nClass._pSubCheckIfExist2(DraftExists, ApplicationNo)
        If DraftExists = True Then
            Dim Bus_Name, Capital, Area, Bus_Address, Bus_Brgy, Bus_Street, Bus_Nature, DtiSecCda_No, TIN_No, SSS_No, Contact_No, Email, FName, LName, MName As String
            Dim Resident As Boolean
            Dim Own_Address, Own_Brgy, Own_Street, Own_CityMun As String
            Dim up_FileData1 As Byte()
            Dim up_FileName1, up_FileType1, up_FileStatus1, up_FileRemarks1 As String
            Dim up_FileData2 As Byte()
            Dim up_FileName2, up_FileType2, up_FileStatus2, up_FileRemarks2 As String
            Dim up_FileData3 As Byte()
            Dim up_FileName3, up_FileType3, up_FileStatus3, up_FileRemarks3 As String
            Dim up_FileData4 As Byte()
            Dim up_FileName4, up_FileType4, up_FileStatus4, up_FileRemarks4 As String
            Dim up_FileData5 As Byte()
            Dim up_FileName5, up_FileType5, up_FileStatus5, up_FileRemarks5 As String
            Dim up_FileData6 As Byte()
            Dim up_FileName6, up_FileType6, up_FileStatus6, up_FileRemarks6 As String
            Dim Date_Created, Last_Edit, Date_Submitted As Date
            Dim Status As String

            _nClass._pSubSelectNewBP2(ApplicationNo, Bus_Name, Capital, Area, Bus_Address _
                     , Bus_Brgy, Bus_Street, Bus_Nature, DtiSecCda_No, TIN_No, SSS_No _
                     , Contact_No, Email, FName, LName, MName, Resident, Own_Address, Own_Brgy _
                     , Own_Street, Own_CityMun _
                     , up_FileData1, up_FileName1, up_FileType1, up_FileStatus1, up_FileRemarks1 _
                     , up_FileData2, up_FileName2, up_FileType2, up_FileStatus2, up_FileRemarks2 _
                     , up_FileData3, up_FileName3, up_FileType3, up_FileStatus3, up_FileRemarks3 _
                     , up_FileData4, up_FileName4, up_FileType4, up_FileStatus4, up_FileRemarks4 _
                     , up_FileData5, up_FileName5, up_FileType5, up_FileStatus5, up_FileRemarks5 _
                     , up_FileData6, up_FileName6, up_FileType6, up_FileStatus6, up_FileRemarks6 _
                     , Date_Created, Last_Edit, Date_Submitted, Status)

            td_Bus_Name.Value = Bus_Name
            td_capital.Value = Capital
            td_Area.Value = Area
            td_Bus_Address.Value = Bus_Address
            td_Bus_Brgy.Value = Bus_Brgy
            td_Bus_Street.Value = Bus_Street
            td_Bus_Nature.Value = Bus_Nature
            td_DtiSecCda_No.Value = DtiSecCda_No
            td_TIN_No.Value = TIN_No
            td_SSS_No.Value = SSS_No
            td_Contact_No.Value = Contact_No
            td_FName.Value = FName
            td_LName.Value = LName
            td_MName.Value = MName
            td_Resident.Value = Resident
            td_Own_Address.Value = Own_Address
            td_Own_Brgy.Value = Own_Brgy
            td_Own_Street.Value = Own_Street
            td_Own_CityMun.Value = Own_CityMun

            Dim script_hide As String
            If up_FileName1 <> Nothing Then
                hdn_1.Value = "data:" & up_FileType1 & ";base64," & Convert.ToBase64String(up_FileData1)
            Else
                script_hide += "sessionStorage.setItem('up_FileName1', '" & up_FileName1 & "');"
            End If
            If up_FileName2 <> Nothing Then
                hdn_2.Value = "data:" & up_FileType2 & ";base64," & Convert.ToBase64String(up_FileData2)
            Else
                script_hide += "sessionStorage.setItem('up_FileName2', '" & up_FileName2 & "');"
            End If
            If up_FileName3 <> Nothing Then
                hdn_3.Value = "data:" & up_FileType3 & ";base64," & Convert.ToBase64String(up_FileData3)
            Else
                script_hide += "sessionStorage.setItem('up_FileName3', '" & up_FileName3 & "');"
            End If
            If up_FileName4 <> Nothing Then
                hdn_4.Value = "data:" & up_FileType4 & ";base64," & Convert.ToBase64String(up_FileData4)
            Else
                script_hide += "sessionStorage.setItem('up_FileName4', '" & up_FileName4 & "');"
            End If
            If up_FileName5 <> Nothing Then
                hdn_5.Value = "data:" & up_FileType5 & ";base64," & Convert.ToBase64String(up_FileData5)
            Else
                script_hide += "sessionStorage.setItem('up_FileName5', '" & up_FileName5 & "');"
            End If
            If up_FileName6 <> Nothing Then
                hdn_6.Value = "data:" & up_FileType6 & ";base64," & Convert.ToBase64String(up_FileData6)
            Else
                script_hide += "sessionStorage.setItem('up_FileName6', '" & up_FileName6 & "');"
            End If

            Response.Write("<script>" & script_hide & "</script>")

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "display", "do_display();", True)

                  End If
    End Sub

    Private Sub btn_Save_ServerClick(sender As Object, e As EventArgs) Handles btn_Save.ServerClick
        Dim _nClass As New cDalNewBP
        Dim ApplicationNo As String = Nothing
        Dim DraftExists As Boolean
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        _nClass._pSubCheckIfExist2(DraftExists, ApplicationNo)
        If DraftExists = True Then
            _nClass._pSubUpdateDraft2(ApplicationNo, td_Bus_Name.Value, td_capital.Value, td_Area.Value, td_Bus_Address.Value, _
                                     td_Bus_Brgy.Value, td_Bus_Street.Value, td_Bus_Nature.Value, td_DtiSecCda_No.Value, td_TIN_No.Value, _
                                     td_SSS_No.Value, td_Contact_No.Value, cSessionUser._pUserID, td_FName.Value, td_LName.Value, td_MName.Value, td_Resident.Value, _
                                     td_Own_Address.Value, td_Own_Brgy.Value, td_Own_Street.Value, td_Own_CityMun.Value, "Incomplete")
        Else
            _nClass._pSubApplicationNo(ApplicationNo)
            _nClass._pSubInsertDraft2(ApplicationNo, td_Bus_Name.Value, td_capital.Value, td_Area.Value, td_Bus_Address.Value, _
                                     td_Bus_Brgy.Value, td_Bus_Street.Value, td_Bus_Nature.Value, td_DtiSecCda_No.Value, td_TIN_No.Value, _
                                     td_SSS_No.Value, td_Contact_No.Value, cSessionUser._pUserID, td_FName.Value, td_LName.Value, td_MName.Value, td_Resident.Value, _
                                     td_Own_Address.Value, td_Own_Brgy.Value, td_Own_Street.Value, td_Own_CityMun.Value, "Incomplete")

        End If
       upload_Docs(cSessionUser._pUserID, ApplicationNo)

    End Sub

    Private Sub btn_Submit_ServerClick(sender As Object, e As EventArgs) Handles btn_Submit.ServerClick
        Dim _nClass As New cDalNewBP
        Dim ApplicationNo As String = Nothing
        Dim DraftExists As Boolean
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

        _nClass._pSubCheckIfExist2(DraftExists, ApplicationNo)
        If DraftExists = True Then
            _nClass._pSubUpdateDraft2(ApplicationNo, td_Bus_Name.Value, td_capital.Value, td_Area.Value, td_Bus_Address.Value, _
                                     td_Bus_Brgy.Value, td_Bus_Street.Value, td_Bus_Nature.Value, td_DtiSecCda_No.Value, td_TIN_No.Value, _
                                     td_SSS_No.Value, td_Contact_No.Value, cSessionUser._pUserID, td_FName.Value, td_LName.Value, td_MName.Value, td_Resident.Value, _
                                     td_Own_Address.Value, td_Own_Brgy.Value, td_Own_Street.Value, td_Own_CityMun.Value, "Pending")
        Else
            _nClass._pSubApplicationNo(ApplicationNo)
            _nClass._pSubInsertDraft2(ApplicationNo, td_Bus_Name.Value, td_capital.Value, td_Area.Value, td_Bus_Address.Value, _
                                     td_Bus_Brgy.Value, td_Bus_Street.Value, td_Bus_Nature.Value, td_DtiSecCda_No.Value, td_TIN_No.Value, _
                                     td_SSS_No.Value, td_Contact_No.Value, cSessionUser._pUserID, td_FName.Value, td_LName.Value, td_MName.Value, td_Resident.Value, _
                                     td_Own_Address.Value, td_Own_Brgy.Value, td_Own_Street.Value, td_Own_CityMun.Value, "Pending")

        End If
        upload_Docs(cSessionUser._pUserID, ApplicationNo)
        _nClass._pSubUpdateSubmit2(ApplicationNo, cSessionUser._pUserID, "Pending")

        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModalSubmit();", True)

        ''Send Email
        'Dim Sent As Boolean
        'Dim subject As String = "New Business Application"
        'Dim Body As String = ""
        'cDalNewSendEmail.SendEmail(cSessionUser._pUserID, subject, Body, Sent)

    End Sub

    Sub upload_Docs(Email, ApplicationNo)
        Dim _nClass As New cDalNewBP
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
        Dim FileName, FileType As String
        Dim FileData As Byte()

        If up_OwnPic.PostedFile IsNot Nothing Then
            If up_OwnPic.PostedFile.ContentLength > 0 Then
                Dim File As HttpPostedFile = up_OwnPic.PostedFile
                FileName = up_OwnPic.PostedFile.FileName
                FileType = up_OwnPic.PostedFile.ContentType
                Dim fs As Stream = File.InputStream
                Dim br As New BinaryReader(fs)
                FileData = br.ReadBytes(Convert.ToInt32(fs.Length))
                _nClass._pSubUpdateAttachment2(1, Email, _
                                             ApplicationNo, _
                                             FileData, _
                                             FileName, _
                                             FileType)
            End If
        End If

        If up_EstPic.PostedFile IsNot Nothing Then
            If up_EstPic.PostedFile.ContentLength > 0 Then
                Dim File As HttpPostedFile = up_EstPic.PostedFile
                FileName = up_EstPic.PostedFile.FileName
                FileType = up_EstPic.PostedFile.ContentType
                Dim fs As Stream = File.InputStream
                Dim br As New BinaryReader(fs)
                FileData = br.ReadBytes(Convert.ToInt32(fs.Length))
                _nClass._pSubUpdateAttachment2(2, Email, _
                                             ApplicationNo, _
                                             FileData, _
                                             FileName, _
                                             FileType)
            End If
        End If

        If up_MapPic.PostedFile IsNot Nothing Then
            If up_MapPic.PostedFile.ContentLength > 0 Then
                Dim File As HttpPostedFile = up_MapPic.PostedFile
                FileName = up_MapPic.PostedFile.FileName
                FileType = up_MapPic.PostedFile.ContentType
                Dim fs As Stream = File.InputStream
                Dim br As New BinaryReader(fs)
                FileData = br.ReadBytes(Convert.ToInt32(fs.Length))
                _nClass._pSubUpdateAttachment2(3, Email, _
                                             ApplicationNo, _
                                             FileData, _
                                             FileName, _
                                             FileType)
            End If
        End If

        If up_AppForm.PostedFile IsNot Nothing Then
            If up_AppForm.PostedFile.ContentLength > 0 Then
                Dim File As HttpPostedFile = up_AppForm.PostedFile
                FileName = up_AppForm.PostedFile.FileName
                FileType = up_AppForm.PostedFile.ContentType
                Dim fs As Stream = File.InputStream
                Dim br As New BinaryReader(fs)
                FileData = br.ReadBytes(Convert.ToInt32(fs.Length))
                _nClass._pSubUpdateAttachment2(4, Email, _
                                             ApplicationNo, _
                                             FileData, _
                                             FileName, _
                                             FileType)
            End If
        End If

        If up_DtiSecCda.PostedFile IsNot Nothing Then
            If up_DtiSecCda.PostedFile.ContentLength > 0 Then
                Dim File As HttpPostedFile = up_DtiSecCda.PostedFile
                FileName = up_DtiSecCda.PostedFile.FileName
                FileType = up_DtiSecCda.PostedFile.ContentType
                Dim fs As Stream = File.InputStream
                Dim br As New BinaryReader(fs)
                FileData = br.ReadBytes(Convert.ToInt32(fs.Length))
                _nClass._pSubUpdateAttachment2(5, Email, _
                                             ApplicationNo, _
                                             FileData, _
                                             FileName, _
                                             FileType)
            End If
        End If

        If up_TIN.PostedFile IsNot Nothing Then
            If up_TIN.PostedFile.ContentLength > 0 Then
                Dim File As HttpPostedFile = up_TIN.PostedFile
                FileName = up_TIN.PostedFile.FileName
                FileType = up_TIN.PostedFile.ContentType
                Dim fs As Stream = File.InputStream
                Dim br As New BinaryReader(fs)
                FileData = br.ReadBytes(Convert.ToInt32(fs.Length))
                _nClass._pSubUpdateAttachment2(6, Email, _
                                             ApplicationNo, _
                                             FileData, _
                                             FileName, _
                                             FileType)
            End If
        End If

    End Sub
End Class