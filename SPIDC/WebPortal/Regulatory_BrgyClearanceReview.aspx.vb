Imports System
Imports System.Text
Imports System.Security.Cryptography
Imports System.IO
Imports System.Linq
Imports System.Web.Script.Serialization
Public Class Regulatory_BrgyClearanceReview
    Inherits System.Web.UI.Page


    Dim strCatCode, strCatDesc, strBusCode, strBusDesc As String
    Protected Values As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal eQ As System.EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then
                cSessionLoader_NEWBP_Draft._pApplication_ID = "NBP20210712-00001"
                cSessionLoader._pAccountNo = cSessionLoader_NEWBP_Draft._pApplication_ID
                cLoader_BPLTIMS._pACCTNO = cSessionLoader_NEWBP_Draft._pApplication_ID
                _LoadInformation()
                _LoadBusinessLine(_oGridViewBusLine)
                _LoadFees(_oGridView_Fees)
            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")

                If action = "Incomplete" Then
                    _Initialize_UpdateStatus("Incomplete")
                    Exit Sub
                End If

                If action = "Approve" Then
                    _Initialize_UpdateStatus("Approve")
                    Exit Sub
                End If

                If action = "ImageReject" Then
                    _Initialize_UpdateImage("Reject", txt_ImageRemarks.Value, hdn_ImageId.Value)
                    Exit Sub
                End If

                If action = "ImageApprove" Then
                    _Initialize_UpdateImage("Approved", txt_ImageRemarks.Value, hdn_ImageId.Value)
                    Exit Sub
                End If

                If action = "SaveFeesDue" Then
                    _SaveFeesDue()
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Post(sender As Object, e As EventArgs)
        Dim textboxValues As String() = Request.Form.GetValues("DynamicTextBox")
        Dim serializer As New JavaScriptSerializer()
        Me.Values = serializer.Serialize(textboxValues)
        Dim message As String = ""
        For Each textboxValue As String In textboxValues
            message += textboxValue & "\n"
        Next
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", "alert('" & message & "');", True)
    End Sub
    Private Sub _LoadInformation()
        Try
            Dim _nSuccessful As Boolean, _mErrMsg As String
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM NewBP_Draft "
                ._pCondition = " WHERE Application_ID = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' "
                ._pExec(_nSuccessful, _mErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then

                    td_ApplicationNo.InnerText = _nDataTable.Rows(0).Item("Application_ID").ToString()
                    td_EmailAddress.InnerText = _nDataTable.Rows(0).Item("UserID").ToString()
                    td_OwnershipType.InnerText = _nDataTable.Rows(0).Item("A_Ownership").ToString()
                    td_DTI_SEC_CDA.InnerText = _nDataTable.Rows(0).Item("A_DtiSecCda").ToString()
                    td_BusinessName.InnerText = _nDataTable.Rows(0).Item("A_BusName").ToString()
                    td_TIN.InnerText = _nDataTable.Rows(0).Item("A_TIN").ToString()
                    td_MainAddress.InnerText = _nDataTable.Rows(0).Item("B_HouseNo").ToString() & " " & _nDataTable.Rows(0).Item("B_BldgName").ToString() & " " & _nDataTable.Rows(0).Item("B_LotNo").ToString() & " " & _nDataTable.Rows(0).Item("B_BlockNo").ToString() & " " & _nDataTable.Rows(0).Item("B_Street").ToString() & " " & _nDataTable.Rows(0).Item("B_Brgy").ToString() & " " & _nDataTable.Rows(0).Item("B_Subd").ToString() & " " & _nDataTable.Rows(0).Item("B_CityMunicipality").ToString() & " " & _nDataTable.Rows(0).Item("B_Province").ToString() & " " & _nDataTable.Rows(0).Item("B_ZipCode").ToString()
                    td_TelephoneNo.InnerText = _nDataTable.Rows(0).Item("C_TelNo").ToString()
                    td_MobileNo.InnerText = _nDataTable.Rows(0).Item("C_MobileNo").ToString()
                    td_EmailAddress.InnerText = _nDataTable.Rows(0).Item("C_Email").ToString()
                    If _nDataTable.Rows(0).Item("A_Ownership").ToString() = "Single" Then
                        td_PresOwnerFullname.InnerText = _nDataTable.Rows(0).Item("D_Fname").ToString() & " " & _nDataTable.Rows(0).Item("D_Mname").ToString() & " " & _nDataTable.Rows(0).Item("D_Lname").ToString() & " " & _nDataTable.Rows(0).Item("D_Suffix").ToString()
                    Else
                        td_PresOwnerFullname.InnerText = _nDataTable.Rows(0).Item("E_Fname").ToString() & " " & _nDataTable.Rows(0).Item("E_Mname").ToString() & " " & _nDataTable.Rows(0).Item("E_Lname").ToString() & " " & _nDataTable.Rows(0).Item("E_Suffix").ToString()
                    End If
                    td_Nationality.InnerText = _nDataTable.Rows(0).Item("E_Nationality").ToString()
                    td_BusinessArea.InnerText = _nDataTable.Rows(0).Item("F_BusArea").ToString()
                    td_TotalFlrArea.InnerText = _nDataTable.Rows(0).Item("F_FlrArea").ToString()
                    td_NoEmpMale.InnerText = _nDataTable.Rows(0).Item("F_MaleEmpNo").ToString()
                    td_NoEmpFemale.InnerText = _nDataTable.Rows(0).Item("F_FemaleEmpNo").ToString()
                    td_LGUResiding.InnerText = _nDataTable.Rows(0).Item("F_ResideEmpNo").ToString()
                    td_DeliveryVanTruck.InnerText = _nDataTable.Rows(0).Item("F_VanTruckNo").ToString()
                    td_DeliveryMotorcycle.InnerText = _nDataTable.Rows(0).Item("F_MotorNo").ToString()
                    td_BusinessLocAddress.InnerText = _nDataTable.Rows(0).Item("G_HouseNo").ToString() & " " & _nDataTable.Rows(0).Item("G_BldgName").ToString() & " " & _nDataTable.Rows(0).Item("G_LotNo").ToString() & " " & _nDataTable.Rows(0).Item("G_BlockNo").ToString() & " " & _nDataTable.Rows(0).Item("G_Street").ToString() & " " & _nDataTable.Rows(0).Item("G_Brgy").ToString() & " " & _nDataTable.Rows(0).Item("G_Subd").ToString() & " " & _nDataTable.Rows(0).Item("G_CityMunicipality").ToString() & " " & _nDataTable.Rows(0).Item("G_Province").ToString() & " " & _nDataTable.Rows(0).Item("G_ZipCode").ToString()
                    Dim _nCapital As Integer = _nDataTable.Rows(0).Item("H_Capital")
                    td_Capitalization.InnerText = _nCapital.ToString("C").Replace("$", "")
                    '_nDataTable.Rows(0).Item("H_Nature").ToString()
                    If _nDataTable.Rows(0).Item("H_Owned").ToString().ToLower = "true" Then
                        td_Owned.InnerText = "Yes"
                    Else
                        td_Owned.InnerText = "No"
                    End If

                    td_TDN.InnerText = _nDataTable.Rows(0).Item("H_TDN").ToString()
                    td_PIN.InnerText = _nDataTable.Rows(0).Item("H_PIN").ToString()
                    If _nDataTable.Rows(0).Item("H_GovIncentive").ToString().ToLower = "true" Then
                        td_EnjoyingTaxIncentives.InnerText = "Yes"
                    Else
                        td_EnjoyingTaxIncentives.InnerText = "No"
                    End If
                    td_BusinessActivity.InnerText = _nDataTable.Rows(0).Item("H_BusAct").ToString()
                    td_BusinessNature.InnerText = _nDataTable.Rows(0).Item("H_Nature").ToString()
                    _LoadImageAttachment(_nDataTable)

                End If

            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _LoadImageAttachment()
        Try
            Dim _nSuccessful As Boolean, _mErrMsg As String
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT " & _
                        " I_OwnerPicFileData, I_OwnerPicFileName, I_OwnerPicFileType, I_OwnerPicStatus, I_OwnerPicRemarks " & _
                        " , I_BusEstPicFileData, I_BusEstPicFileName, I_BusEstPicFileType, I_BusEstPicStatus, I_BusEstPicRemarks " & _
                        " , I_BusMapPicFileData, I_BusMapPicFileName, I_BusMapPicFileType, I_BusMapPicStatus, I_BusMapPicRemarks " & _
                        " , I_AppFormFileData, I_AppFormFileName, I_AppFormFileType, I_AppFormStatus, I_AppFormRemarks " & _
                        " , I_DtiSecCdaFileData, I_DtiSecCdaFileName, I_DtiSecCdaFileType, I_DtiSecCdaFileStatus, I_DtiSecCdaFileRemarks " & _
                        " , I_TINFileData, I_TINFileName, I_TINFileType, I_TINFileStatus, I_TINFileRemarks " & _
                        " FROM NewBP_Draft "
                ._pCondition = " WHERE Application_ID = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' "
                ._pExec(_nSuccessful, _mErrMsg)


                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    _LoadImageAttachment(_nDataTable)
                End If



            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _LoadImageAttachment(_nDataTable As DataTable)
        Try
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

            'Owner Pic
            up_FileData1 = _nDataTable.Rows(0).Item("I_OwnerPicFileData")
            up_FileName1 = _nDataTable.Rows(0).Item("I_OwnerPicFileName").ToString
            up_FileType1 = _nDataTable.Rows(0).Item("I_OwnerPicFileType").ToString
            up_FileStatus1 = _nDataTable.Rows(0).Item("I_OwnerPicStatus").ToString
            up_FileRemarks1 = _nDataTable.Rows(0).Item("I_OwnerPicRemarks").ToString
            td_OwnPicFileName.InnerText = up_FileName1
            td_OwnPicStatus.InnerText = up_FileStatus1
            hdn_ImageRemarks1.Value = up_FileRemarks1

            'Business Establishment
            up_FileData2 = _nDataTable.Rows(0).Item("I_BusEstPicFileData")
            up_FileName2 = _nDataTable.Rows(0).Item("I_BusEstPicFileName").ToString
            up_FileType2 = _nDataTable.Rows(0).Item("I_BusEstPicFileType").ToString
            up_FileStatus2 = _nDataTable.Rows(0).Item("I_BusEstPicStatus").ToString
            up_FileRemarks2 = _nDataTable.Rows(0).Item("I_BusEstPicRemarks").ToString
            td_EstPicFileName.InnerText = up_FileName2
            td_EstPicStatus.InnerText = up_FileStatus2
            hdn_ImageRemarks2.Value = up_FileRemarks2
            'Map Location
            up_FileData3 = _nDataTable.Rows(0).Item("I_BusMapPicFileData")
            up_FileName3 = _nDataTable.Rows(0).Item("I_BusMapPicFileName").ToString
            up_FileType3 = _nDataTable.Rows(0).Item("I_BusMapPicFileType").ToString
            up_FileStatus3 = _nDataTable.Rows(0).Item("I_BusMapPicStatus").ToString
            up_FileRemarks3 = _nDataTable.Rows(0).Item("I_BusMapPicRemarks").ToString
            td_MapPicFileName.InnerText = up_FileName3
            td_MapPicStatus.InnerText = up_FileStatus3
            hdn_ImageRemarks3.Value = up_FileRemarks3

            'Application Form
            up_FileData4 = _nDataTable.Rows(0).Item("I_AppFormFileData")
            up_FileName4 = _nDataTable.Rows(0).Item("I_AppFormFileName").ToString
            up_FileType4 = _nDataTable.Rows(0).Item("I_AppFormFileType").ToString
            up_FileStatus4 = _nDataTable.Rows(0).Item("I_AppFormStatus").ToString
            up_FileRemarks4 = _nDataTable.Rows(0).Item("I_AppFormRemarks").ToString
            td_AppFormFileName.InnerText = up_FileName4
            td_AppFormStatus.InnerText = up_FileStatus4
            hdn_ImageRemarks4.Value = up_FileRemarks4

            'DtiSecCda
            up_FileData5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileData")
            up_FileName5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileName").ToString
            up_FileType5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileType").ToString
            up_FileStatus5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileStatus").ToString
            up_FileRemarks5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileRemarks").ToString
            td_DtiSecCdaFileName.InnerText = up_FileName5
            td_DtiSecCdaStatus.InnerText = up_FileStatus5
            hdn_ImageRemarks5.Value = up_FileRemarks5

            'TIN
            up_FileData6 = _nDataTable.Rows(0).Item("I_TINFileData")
            up_FileName6 = _nDataTable.Rows(0).Item("I_TINFileName").ToString
            up_FileType6 = _nDataTable.Rows(0).Item("I_TINFileType").ToString
            up_FileStatus6 = _nDataTable.Rows(0).Item("I_TINFileStatus").ToString
            up_FileRemarks6 = _nDataTable.Rows(0).Item("I_TINFileRemarks").ToString
            td_TINFileName.InnerText = up_FileName6
            td_TINStatus.InnerText = up_FileStatus6
            hdn_ImageRemarks6.Value = up_FileRemarks6

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

            cSessionLoader._pBPLTAS_SvrName = _nLiveServerName
            cSessionLoader._pBPLTAS_DbName = _nLiveDatabaseName

            Dim _nClass As New cDal_IUD

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT " & _
                            " BC.BUS_CODE, BC.[DESCRIPTION], BL.FORYEAR, BL.GROSSREC, BL.CAPITAL, BL.AREA, " & _
                            " BL.BUSTAX, BL.MAYORS,BL.SANITARY,BL.GARBAGE,BL.FIRE, BL.STATCODE, " & _
                            " CASE WHEN ISNULL(BL.ISPRCS,0) = 0 " & _
                            " then '''' " & _
                            " else ''DONE'' " & _
                            " end ISPRCS " & _
                            " FROM [BUSLINE] AS BL " & _
                            " INNER JOIN [" & cSessionLoader._pBPLTAS_SvrName & "].[" & cSessionLoader._pBPLTAS_DbName & "].dbo.[BUSCODE] AS BC " & _
                            " ON " & _
                            " BL.BUS_CODE = BC.BUS_CODE COLLATE DATABASE_DEFAULT "

                ._pCondition = " WHERE BL.ACCTNO =  ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' COLLATE DATABASE_DEFAULT and foryear = Year(GETDATE())"

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

    Private Sub _LoadFees(_nGridview As GridView)
        Dim _nClass As New cDalRegulatoryFees
        With _nClass
            ._pDeptCode = "0001"
            ._pLoadFeesGridview(_nGridview)
            Dim nTotalDue As Decimal = ._GetFeesTotal()
            TxtRegFeesTotalDue.Value = nTotalDue.ToString("C").Replace("$", "")
        End With
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

    Protected Sub _Initialize_UpdateStatus(_nStatus As String)
        Try

            If _SendEmailNotification(_nStatus, "") = True Then '# 1 Send Email Notification
                _UpdateStatus(_nStatus, _oTxtRemarks.Value) ' # 2 Update Status
                '#3 Redirect to Landing Page "Succesfuly Notified"
                Response.Redirect("NotificationPages/BPLONotification.aspx")
            Else
                'Message Email Notification Failed
                snackbar("red", "Send notification failed, please try again.")
                'ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('Something went wrong, please try again.');", True)
            End If



        Catch ex As Exception

        End Try
    End Sub
    Private Function UpdateImageStatus(_nStatus As String, _nRemarks As String, _nImageType As String, Optional ByRef _nErrMsg As String = Nothing) As Boolean

        Try
            Dim _nStatusField, _nRemarksField As String

            Select Case _nImageType
                Case "1"
                    _nStatusField = "I_OwnerPicStatus"
                    _nRemarksField = "I_OwnerPicRemarks"

                Case "2"
                    _nStatusField = "I_BusEstPicStatus"
                    _nRemarksField = "I_BusEstPicRemarks"

                Case "3"
                    _nStatusField = "I_BusMapPicStatus"
                    _nRemarksField = "I_BusMapPicRemarks"

                Case "4"
                    _nStatusField = "I_AppFormStatus"
                    _nRemarksField = "I_AppFormRemarks"

                Case "5"
                    _nStatusField = "I_DtiSecCdaFileStatus"
                    _nRemarksField = "I_DtiSecCdaFileRemarks"

                Case "6"
                    _nStatusField = "I_TINFileStatus"
                    _nRemarksField = "I_TINFileRemarks"

            End Select

            Dim _nSuccess As Boolean
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE NewBP_Draft set " & _nStatusField & " = ''" & _nStatus & "'', " & _nRemarksField & " = ''" & _nRemarks & "'' "
                ._pCondition = "  where Application_ID = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' "
                ._pExec(_nSuccess, _nErrMsg)

                Return _nSuccess

            End With

        Catch ex As Exception
            _nErrMsg = ex.Message
            Return False

        End Try
    End Function

    Protected Sub _Initialize_UpdateImage(_nStatus As String, _nRemarks As String, _nImageType As String)
        Try
            Dim _nErrMsg As String
            If UpdateImageStatus(_nStatus, _nRemarks, _nImageType, _nErrMsg) = True Then
                _LoadImageAttachment()
                snackbar("green", "Image Status successfuly updated.")
            Else
                snackbar("red", "Image Status Update failed : " & _nErrMsg)
            End If

        Catch ex As Exception
            snackbar("red", "Image Status Update failed : " & ex.Message)
        End Try
    End Sub

    Private Function _SendEmailNotification(_nStatus As String, _nComment As String) As Boolean

        Dim Sent As Boolean
        Dim Subject As String = "NEW BUSINESS PERMIT APPLICATION STATUS"
        Dim Body As String

        Select Case _nStatus

            Case "Approve"

                Body = _
                    "<br> Sir/Ma`am: <br> <br>" & _
                    "Your business permit application with application no. [" & cSessionLoader_NEWBP_Draft._pApplication_ID & "] is now approved by BPLO office. <br>" & _
                    "You can now proceed submmitting other regulatory requirements ... [ Please see Instruction ] " & _
                     IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                    "Thank you. <br>"

            Case "Incomplete"

                Body = _
                    "<br> Sir/Ma`am: <br> <br>" & _
                    "Your business permit application with application no.  " & cSessionLoader_NEWBP_Draft._pApplication_ID & " is now pending until you submit all mandatory requirements." & _
                     IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                    "Thank you. <br>"

        End Select

        Try
            cDalNewSendEmail.SendEmail(cSessionUser._pUserID, Subject, Body, Sent)

            Return Sent
        Catch ex As Exception
            Return False
        End Try

    End Function
    Protected Sub _UpdateStatus(_nStatus As String, _Remarks As String)
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE NewBP_Draft set [Reg_BrgyClarance_Status] = ''" & _nStatus & "'' , Reg_BrgyClarance_Remarks = ''" & _Remarks & "'' "
                ._pCondition = "  where Application_ID = ''" & cSessionLoader_NEWBP_Draft._pApplication_ID & "'' "
                ._pExec(_nSuccess, _nErrMsg)

            End With

        Catch ex As Exception

        End Try
    End Sub



    Protected Sub _oButtonAddBusinessLine_Click(sender As Object, e As EventArgs) Handles _
    _btnSaveFees.ServerClick
        _SaveFeesDue()
    End Sub

    Protected Sub _oButtonRegFeesEdit_Click(sender As Object, e As EventArgs) Handles _
        btnEditRegFees.ServerClick
        _EditFees()
    End Sub

    Protected Sub _oButtonRegFeesRemove_Click(sender As Object, e As EventArgs) Handles _
    btnRemoveRegFees.ServerClick

        _RemoveFees()

    End Sub
    Protected Sub _EditFees()
        Try
            Dim _nClass As New cDalRegulatoryFees
            With _nClass
                ._pDeptCode = "0001"
                ._pTaxCode = txtEditFeesCode.Value
                ._pFeesDue = txtEditFeesAmount.Value
                ._pUpdateFees()
                ._pLoadFeesGridview(_oGridView_Fees)
                Dim nTotalDue As Decimal = ._GetFeesTotal()
                TxtRegFeesTotalDue.Value = nTotalDue.ToString("C").Replace("$", "")
            End With
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub _RemoveFees()
        Try
            Dim _nClass As New cDalRegulatoryFees
            With _nClass
                ._pDeptCode = "0001"
                ._pTaxCode = _oTextboxRegFeesItemCodeRemove.Value
                ._pRemoveFees()
                ._pLoadFeesGridview(_oGridView_Fees)
                Dim nTotalDue As Decimal = ._GetFeesTotal()
                TxtRegFeesTotalDue.Value = nTotalDue.ToString("C").Replace("$", "")
            End With
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub _SaveFeesDue()
        Try
            Dim _nClass As New cDalRegulatoryFees
            With _nClass
                ._pDeptCode = "0001"
                ._pTaxCode = cmbItemFees.Value
                ._pTaxDesc = cmbItemFees.Items(cmbItemFees.SelectedIndex).Text
                ._pFeesDue = txtFeesDue.Value
                ._pSaveFees()
                ._pLoadFeesGridview(_oGridView_Fees)
                Dim nTotalDue As Decimal = ._GetFeesTotal()
                TxtRegFeesTotalDue.Value = nTotalDue.ToString("C").Replace("$", "")
            End With

        Catch ex As Exception

        End Try
    End Sub

End Class