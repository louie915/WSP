Partial Public Class BPLONewBP_ForApplicationNo

    Private Sub _LoadInformation(Optional ByRef email As String = Nothing)
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
                    email = _nDataTable.Rows(0).Item("UserID").ToString()
                    td_OwnershipType.InnerText = _nDataTable.Rows(0).Item("A_Ownership").ToString()
                    td_DTI_SEC_CDA.InnerText = _nDataTable.Rows(0).Item("A_DtiSecCda").ToString()
                    td_BusinessName.InnerText = _nDataTable.Rows(0).Item("A_BusName").ToString()
                    td_TIN.InnerText = _nDataTable.Rows(0).Item("A_TIN").ToString()
                    td_MainAddress.InnerText = _nDataTable.Rows(0).Item("B_HouseNo").ToString() & " " & _nDataTable.Rows(0).Item("B_BldgName").ToString() & " " & _nDataTable.Rows(0).Item("B_LotNo").ToString() & " " & _nDataTable.Rows(0).Item("B_BlockNo").ToString() & " " & _nDataTable.Rows(0).Item("B_Street").ToString() & " " & _nDataTable.Rows(0).Item("B_Brgy").ToString() & " " & _nDataTable.Rows(0).Item("B_Subd").ToString() & " " & _nDataTable.Rows(0).Item("B_CityMunicipality").ToString() & " " & _nDataTable.Rows(0).Item("B_Province").ToString() & " " & _nDataTable.Rows(0).Item("B_ZipCode").ToString()
                    td_TelephoneNo.InnerText = _nDataTable.Rows(0).Item("C_TelNo").ToString()
                    td_MobileNo.InnerText = _nDataTable.Rows(0).Item("C_MobileNo").ToString()
                    td_EmailAddress.InnerText = _nDataTable.Rows(0).Item("C_Email").ToString()
                    cLoader_BPLTIMS._pEMAILADDR = td_EmailAddress.InnerText
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
                    td_Nature.InnerText = _nDataTable.Rows(0).Item("H_Nature").ToString()
                    NatureHTML.InnerHtml = _nDataTable.Rows(0).Item("H_Nature").ToString()
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
            'Dim up_FileData1 As Byte()
            'Dim up_FileName1, up_FileType1, up_FileStatus1, up_FileRemarks1 As String
            'Dim up_FileData2 As Byte()
            'Dim up_FileName2, up_FileType2, up_FileStatus2, up_FileRemarks2 As String
            'Dim up_FileData3 As Byte()
            'Dim up_FileName3, up_FileType3, up_FileStatus3, up_FileRemarks3 As String
            'Dim up_FileData4 As Byte()
            'Dim up_FileName4, up_FileType4, up_FileStatus4, up_FileRemarks4 As String
            'Dim up_FileData5 As Byte()
            'Dim up_FileName5, up_FileType5, up_FileStatus5, up_FileRemarks5 As String
            'Dim up_FileData6 As Byte()
            'Dim up_FileName6, up_FileType6, up_FileStatus6, up_FileRemarks6 As String

            ''Owner Pic
            'up_FileData1 = _nDataTable.Rows(0).Item("I_OwnerPicFileData")
            'up_FileName1 = _nDataTable.Rows(0).Item("I_OwnerPicFileName").ToString
            'up_FileType1 = _nDataTable.Rows(0).Item("I_OwnerPicFileType").ToString
            'up_FileStatus1 = _nDataTable.Rows(0).Item("I_OwnerPicStatus").ToString
            'up_FileRemarks1 = _nDataTable.Rows(0).Item("I_OwnerPicRemarks").ToString
            'td_OwnPicFileName.InnerText = up_FileName1
            'td_OwnPicStatus.InnerText = up_FileStatus1
            'hdn_ImageRemarks1.Value = up_FileRemarks1

            ''Business Establishment
            'up_FileData2 = _nDataTable.Rows(0).Item("I_BusEstPicFileData")
            'up_FileName2 = _nDataTable.Rows(0).Item("I_BusEstPicFileName").ToString
            'up_FileType2 = _nDataTable.Rows(0).Item("I_BusEstPicFileType").ToString
            'up_FileStatus2 = _nDataTable.Rows(0).Item("I_BusEstPicStatus").ToString
            'up_FileRemarks2 = _nDataTable.Rows(0).Item("I_BusEstPicRemarks").ToString
            'td_EstPicFileName.InnerText = up_FileName2
            'td_EstPicStatus.InnerText = up_FileStatus2
            'hdn_ImageRemarks2.Value = up_FileRemarks2
            ''Map Location
            'up_FileData3 = _nDataTable.Rows(0).Item("I_BusMapPicFileData")
            'up_FileName3 = _nDataTable.Rows(0).Item("I_BusMapPicFileName").ToString
            'up_FileType3 = _nDataTable.Rows(0).Item("I_BusMapPicFileType").ToString
            'up_FileStatus3 = _nDataTable.Rows(0).Item("I_BusMapPicStatus").ToString
            'up_FileRemarks3 = _nDataTable.Rows(0).Item("I_BusMapPicRemarks").ToString
            'td_MapPicFileName.InnerText = up_FileName3
            'td_MapPicStatus.InnerText = up_FileStatus3
            'hdn_ImageRemarks3.Value = up_FileRemarks3

            ''Application Form
            'up_FileData4 = _nDataTable.Rows(0).Item("I_AppFormFileData")
            'up_FileName4 = _nDataTable.Rows(0).Item("I_AppFormFileName").ToString
            'up_FileType4 = _nDataTable.Rows(0).Item("I_AppFormFileType").ToString
            'up_FileStatus4 = _nDataTable.Rows(0).Item("I_AppFormStatus").ToString
            'up_FileRemarks4 = _nDataTable.Rows(0).Item("I_AppFormRemarks").ToString
            'td_AppFormFileName.InnerText = up_FileName4
            'td_AppFormStatus.InnerText = up_FileStatus4
            'hdn_ImageRemarks4.Value = up_FileRemarks4

            ''DtiSecCda
            'up_FileData5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileData")
            'up_FileName5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileName").ToString
            'up_FileType5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileType").ToString
            'up_FileStatus5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileStatus").ToString
            'up_FileRemarks5 = _nDataTable.Rows(0).Item("I_DtiSecCdaFileRemarks").ToString
            'td_DtiSecCdaFileName.InnerText = up_FileName5
            'td_DtiSecCdaStatus.InnerText = up_FileStatus5
            'hdn_ImageRemarks5.Value = up_FileRemarks5

            ''TIN
            'up_FileData6 = _nDataTable.Rows(0).Item("I_TINFileData")
            'up_FileName6 = _nDataTable.Rows(0).Item("I_TINFileName").ToString
            'up_FileType6 = _nDataTable.Rows(0).Item("I_TINFileType").ToString
            'up_FileStatus6 = _nDataTable.Rows(0).Item("I_TINFileStatus").ToString
            'up_FileRemarks6 = _nDataTable.Rows(0).Item("I_TINFileRemarks").ToString
            'td_TINFileName.InnerText = up_FileName6
            'td_TINStatus.InnerText = up_FileStatus6
            'hdn_ImageRemarks6.Value = up_FileRemarks6

            'Dim script_hide As String
            'If up_FileName1 <> Nothing Then
            '    hdn_1.Value = "data:" & up_FileType1 & ";base64," & Convert.ToBase64String(up_FileData1)
            'Else
            '    script_hide += "sessionStorage.setItem('up_FileName1', '" & up_FileName1 & "');"
            'End If
            'If up_FileName2 <> Nothing Then
            '    hdn_2.Value = "data:" & up_FileType2 & ";base64," & Convert.ToBase64String(up_FileData2)
            'Else
            '    script_hide += "sessionStorage.setItem('up_FileName2', '" & up_FileName2 & "');"
            'End If
            'If up_FileName3 <> Nothing Then
            '    hdn_3.Value = "data:" & up_FileType3 & ";base64," & Convert.ToBase64String(up_FileData3)
            'Else
            '    script_hide += "sessionStorage.setItem('up_FileName3', '" & up_FileName3 & "');"
            'End If
            'If up_FileName4 <> Nothing Then
            '    hdn_4.Value = "data:" & up_FileType4 & ";base64," & Convert.ToBase64String(up_FileData4)
            'Else
            '    script_hide += "sessionStorage.setItem('up_FileName4', '" & up_FileName4 & "');"
            'End If
            'If up_FileName5 <> Nothing Then
            '    hdn_5.Value = "data:" & up_FileType5 & ";base64," & Convert.ToBase64String(up_FileData5)
            'Else
            '    script_hide += "sessionStorage.setItem('up_FileName5', '" & up_FileName5 & "');"
            'End If
            'If up_FileName6 <> Nothing Then
            '    hdn_6.Value = "data:" & up_FileType6 & ";base64," & Convert.ToBase64String(up_FileData6)
            'Else
            '    script_hide += "sessionStorage.setItem('up_FileName6', '" & up_FileName6 & "');"
            'End If

            'Response.Write("<script>" & script_hide & "</script>")

            'ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "display", "do_display();", True)



        Catch ex As Exception

        End Try
    End Sub
    
    

    Protected Sub ShowPopup()
        Dim title As String = ""
        ' Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Popup", "ShowPopup('" & title & "')", True)
        ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "ShowPopup('" & title & "');", True)
    End Sub
    Protected Sub HidePopup()
        Try
            '   Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Popup", "HidePopup();", True)
            ClientScript.RegisterStartupScript(Me.GetType(), "Popup", "HidePopup();", True)
        Catch ex As Exception

        End Try

    End Sub
    

    

    Private Function _mFnValidateIfExist() As Boolean
        Try
            '----------------------------------
            _mFnValidateIfExist = False


            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnValidateIfExist = True
                Else
                    _mFnValidateIfExist = False
                End If
                '----------------------------------
            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _mFnValidateIfExist_BUSLINE() As Boolean       '@  Added 20210722
        Try
            '----------------------------------
            _mFnValidateIfExist_BUSLINE = False




            Dim _nClass As New cDalBusinessLine
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            _nClass._pAccount = cSessionLoader._pAccountNo
            _nClass._pBusYear = cLoader_BPLTIMS._pFORYEAR
            _nClass._pBusCode = cLoader_BPLTIMS._pBUS_CODE
            _nClass._pSubSelect_BUSLINE()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try

                If _nDataTable.Rows.Count <> 0 Then
                    _mFnValidateIfExist_BUSLINE = True
                Else
                    _mFnValidateIfExist_BUSLINE = False
                End If
                '----------------------------------
            Catch ex As Exception
                Return False
            End Try

            '----------------------------------
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function _FnRemoveBusExtn() As Boolean
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BUSEXTN "
                ._pCondition = " WHERE AcctNo = ''" & cSessionLoader._pAccountNo & "'' "
                '" AND FORYEAR = ''" & cLoader_BPLTIMS._pFORYEAR & "'' "
                ._pExec(_nSuccessfull, _nErrMsg)
                Return _nSuccessfull
            End With

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function _FnInsertBusExtn() As Boolean
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO BUSEXTN " & _
                    " (ACCTNO,FORYEAR,STATCODE ) " & _
                    " VALUES " & _
                    " (''" & cSessionLoader._pAccountNo & "'',''" & cLoader_BPLTIMS._pFORYEAR & "'',''" & cLoader_BPLTIMS._pSTATCODE & "'') "


                ._pExec(_nSuccessfull, _nErrMsg)
                Return _nSuccessfull
            End With

        Catch ex As Exception
            Return False
        End Try

    End Function

    

    Private Function _FnRemoveBussinessLine(_nBusCode As String, _nForYear As String) As Boolean
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "DELETE"
                ._pSelect = "DELETE FROM BUSLINE "
                ._pCondition = " WHERE AcctNo = ''" & cSessionLoader._pAccountNo & "'' " & _
                                " AND BUS_CODE = ''" & _nBusCode & "'' " & _
                                " AND FORYEAR = ''" & _nForYear & "'' "
                ._pExec(_nSuccessfull, _nErrMsg)
                Return _nSuccessfull
            End With

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Function _FnUpdateBussinessLine(_nBusCode As String, _nForYear As String, _nArea As Double, _nCapital As Double) As Boolean
        Try

            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "UPDATE"
                ._pSelect = "UPDATE BUSLINE SET AREA=''" & _nArea & "'' ,CAPITAL =''" & _nCapital & "'' , isPrcs = 1 "
                ._pCondition = " WHERE AcctNo = ''" & cSessionLoader._pAccountNo & "'' " & _
                                " AND BUS_CODE = ''" & _nBusCode & "'' " & _
                                " AND FORYEAR = ''" & _nForYear & "'' "
                ._pExec(_nSuccessfull, _nErrMsg)
                Return _nSuccessfull
            End With

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub _mFnCallClssAIF_PROCESS(ByVal xAcctno As String, ByVal xStatcodeMain As String, ByVal xDate_Esta As Date, ByVal BPLTAS_xForyear As String)
        Try
            Dim _nClass As New cDalBusinessLine
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

                Dim _nClssBPLTAS As New BPLTASAIFPROCESS_OL.clsProcessAIF
                Dim x As String = Nothing

                '_nClssBPLTAS.BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                '_nClssBPLTAS.BPLTAS_xUID = "juan.dela.cruz"
                '_nClssBPLTAS.BPLTAS_xPW = "#P@ssw0rd#"


                '_nClssBPLTAS.LIVE_BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                '_nClssBPLTAS.LIVE_BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                '_nClssBPLTAS.LIVE_BPLTAS_xUID = "sa"
                '_nClssBPLTAS.LIVE_BPLTAS_xPW = "P@ssw0rd"

                'BPLTIMS
                Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
                _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
                _nClBPLTIMS._pSubRecordSelectSpecific()

                _nClssBPLTAS.BPLTAS_SERVER = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                _nClssBPLTAS.BPLTAS_xDataBase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                _nClssBPLTAS.BPLTAS_xUID = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
                _nClssBPLTAS.BPLTAS_xPW = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"

                'BPLTAS LIVE
                Dim _nClBP As New cDalGlobalConnectionsDefault
                _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                _nClBP._pSubRecordSelectSpecific()

                _nClssBPLTAS.LIVE_BPLTAS_SERVER = _nClBP._pDBDataSource ' cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                _nClssBPLTAS.LIVE_BPLTAS_xDataBase = _nClBP._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                _nClssBPLTAS.LIVE_BPLTAS_xUID = _nClBP._pDBUserID '"sa"
                _nClssBPLTAS.LIVE_BPLTAS_xPW = _nClBP._pDBUserKey '"P@ssw0rd"

                '"128.1.14.4\MSSQL2012DEV"
                '"R&D.BPLTIMS"
                _nClssBPLTAS.BPLTAS_xAcctno = xAcctno
                _nClssBPLTAS.BPLTAS_xStatcodeMain = xStatcodeMain
                _nClssBPLTAS.BPLTAS_xDate_Esta = xDate_Esta
                _nClssBPLTAS.BPLTAS_xForyear = BPLTAS_xForyear

                _nClssBPLTAS.pSub_PROCESS_AIF()

            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _mFnCallClssLINE_PROCESS(ByVal xAcctno As String, ByVal xStatcodeMain As String, ByVal xDate_Esta As Date, ByVal BPLTAS_xForyear As String, _
                                       ByVal xStatcodeLine As String, ByVal xBuscode As String, ByVal xBCODE As String, ByVal xMCODE As String, _
                                       ByVal xGCODE As String, ByVal xSCODE As String, ByVal xFCODE As String, ByVal xEFFMO_B As String, _
                                       ByVal xEFFMO_M As String, ByVal xEFFMO_G As String, ByVal xEFFMO_S As String, ByVal xEFFMO_F As String, _
                                       ByVal xEFFYR_B As String, ByVal xEFFYR_M As String, ByVal xEFFYR_G As String, ByVal xEFFYR_S As String, ByVal xEFFYR_F As String)
        Try
            Dim _nClass As New cDalBusinessLine
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

                Dim _nClssBPLTAS As New BPLTASLINEPROCESS_OL.clsProcessLINE
                Dim x As String = Nothing

                '_nClssBPLTAS.BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                '_nClssBPLTAS.BPLTAS_xUID = "juan.dela.cruz"
                '_nClssBPLTAS.BPLTAS_xPW = "#P@ssw0rd#"


                '_nClssBPLTAS.LIVE_BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                '_nClssBPLTAS.LIVE_BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                '_nClssBPLTAS.LIVE_BPLTAS_xUID = "sa"
                '_nClssBPLTAS.LIVE_BPLTAS_xPW = "P@ssw0rd"

                'BPLTIMS
                Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
                _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
                _nClBPLTIMS._pSubRecordSelectSpecific()

                _nClssBPLTAS.BPLTAS_SERVER = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                _nClssBPLTAS.BPLTAS_xDataBase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                _nClssBPLTAS.BPLTAS_xUID = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
                _nClssBPLTAS.BPLTAS_xPW = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"

                'BPLTAS LIVE
                Dim _nClBP As New cDalGlobalConnectionsDefault
                _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                _nClBP._pSubRecordSelectSpecific()

                _nClssBPLTAS.LIVE_BPLTAS_SERVER = _nClBP._pDBDataSource ' cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                _nClssBPLTAS.LIVE_BPLTAS_xDataBase = _nClBP._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                _nClssBPLTAS.LIVE_BPLTAS_xUID = _nClBP._pDBUserID '"sa"
                _nClssBPLTAS.LIVE_BPLTAS_xPW = _nClBP._pDBUserKey '"P@ssw0rd"


                ' "128.1.14.4\MSSQL2012DEV"
                '"R&D.BPLTIMS"
                _nClssBPLTAS.BPLTAS_xAcctno = xAcctno
                _nClssBPLTAS.BPLTAS_xStatcodeMain = xStatcodeMain
                _nClssBPLTAS.BPLTAS_xDate_Esta = xDate_Esta
                _nClssBPLTAS.BPLTAS_xForyear = BPLTAS_xForyear

                _nClssBPLTAS.BPLTAS_xStatcodeLine = xStatcodeLine
                _nClssBPLTAS.BPLTAS_xBuscode = xBuscode
                _nClssBPLTAS.BPLTAS_xBCODE = IIf(xBCODE = Nothing, "", xBCODE)
                _nClssBPLTAS.BPLTAS_xMCODE = IIf(xMCODE = Nothing, "", xMCODE)
                _nClssBPLTAS.BPLTAS_xGCODE = IIf(xGCODE = Nothing, "", xGCODE)
                _nClssBPLTAS.BPLTAS_xSCODE = IIf(xSCODE = Nothing, "", xSCODE)
                _nClssBPLTAS.BPLTAS_xFCODE = IIf(xFCODE = Nothing, "", xFCODE)
                _nClssBPLTAS.BPLTAS_xEFFMO_B = IIf(xEFFMO_B = Nothing, "", xEFFMO_B)
                _nClssBPLTAS.BPLTAS_xEFFMO_M = IIf(xEFFMO_M = Nothing, "", xEFFMO_M)
                _nClssBPLTAS.BPLTAS_xEFFMO_G = IIf(xEFFMO_G = Nothing, "", xEFFMO_G)
                _nClssBPLTAS.BPLTAS_xEFFMO_S = IIf(xEFFMO_S = Nothing, "", xEFFMO_S)
                _nClssBPLTAS.BPLTAS_xEFFMO_F = IIf(xEFFMO_F = Nothing, "", xEFFMO_F)
                _nClssBPLTAS.BPLTAS_xEFFYR_B = IIf(xEFFYR_B = Nothing, "", xEFFYR_B)
                _nClssBPLTAS.BPLTAS_xEFFYR_M = IIf(xEFFYR_M = Nothing, "", xEFFYR_M)
                _nClssBPLTAS.BPLTAS_xEFFYR_G = IIf(xEFFYR_G = Nothing, "", xEFFYR_G)
                _nClssBPLTAS.BPLTAS_xEFFYR_S = IIf(xEFFYR_S = Nothing, "", xEFFYR_S)
                _nClssBPLTAS.BPLTAS_xEFFYR_F = IIf(xEFFYR_F = Nothing, "", xEFFYR_F)

                _nClssBPLTAS.pSub_PROCESS_LINE()

            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _mFnCallClssAIF_LINE_PROCESS_ORIG(ByVal xIDLogName As String, ByVal xAcctno As String, ByVal BPLTAS_xForyear As String, _
                                     ByVal xBuscode As String, ByVal xELECFEE As Double, ByVal xMECHFEE As Double, _
                                     ByVal xBLDGFEE As Double, ByVal xSIGNFEE As Double, ByVal xEPOFEE As Double, ByVal xEIFFEE As Double, _
                                     ByVal xPLATEFEE As Double, ByVal xSwitch As Integer)
        Try
            Dim _nClass As New cDalBusinessLine
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

                Dim _nClssBPLTAS As New BPLTASAIF_PERLINE_OL.clsAIF_PerLine_NEW
                Dim x As String = Nothing

                '_nClssBPLTAS.BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                '_nClssBPLTAS.BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
                '_nClssBPLTAS.BPLTAS_xUID = "juan.dela.cruz"
                '_nClssBPLTAS.BPLTAS_xPW = "#P@ssw0rd#"
                '_nClssBPLTAS.BPLTASDOC_xDataBase = "BPLTASDOC_fortest"

                '_nClssBPLTAS.LIVE_BPLTAS_SERVER = cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                '_nClssBPLTAS.LIVE_BPLTAS_xDataBase = cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                '_nClssBPLTAS.LIVE_BPLTAS_xUID = "sa"
                '_nClssBPLTAS.LIVE_BPLTAS_xPW = "P@ssw0rd"

                'BPLTIMS
                Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
                _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
                _nClBPLTIMS._pSubRecordSelectSpecific()

                _nClssBPLTAS.BPLTAS_SERVER = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                _nClssBPLTAS.BPLTAS_xDataBase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToStrin
                _nClssBPLTAS.BPLTAS_xUID = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
                _nClssBPLTAS.BPLTAS_xPW = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"

                'BPLTAS LIVE
                Dim _nClBP As New cDalGlobalConnectionsDefault
                _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
                _nClBP._pSubRecordSelectSpecific()

                _nClssBPLTAS.LIVE_BPLTAS_SERVER = _nClBP._pDBDataSource ' cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
                _nClssBPLTAS.LIVE_BPLTAS_xDataBase = _nClBP._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
                _nClssBPLTAS.LIVE_BPLTAS_xUID = _nClBP._pDBUserID '"sa"
                _nClssBPLTAS.LIVE_BPLTAS_xPW = _nClBP._pDBUserKey '"P@ssw0rd"

                Dim _nClDoc As New cDalGlobalConnectionsDefault
                _nClDoc._pCxn = cGlobalConnections._pSqlCxn_CR
                _nClDoc._pSetupGlobalConnectionsDatabases = "BPLTAS_D"
                _nClDoc._pSubRecordSelectSpecific()

                _nClssBPLTAS.BPLTAS_SERVER = _nClDoc._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
                _nClssBPLTAS.BPLTASDOC_xDataBase = _nClDoc._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToStrin
                '_nClssBPLTAS.BPLTAS_xUID = _nClDoc._pDBUserID '"juan.dela.cruz"
                '_nClssBPLTAS.BPLTAS_xPW = _nClDoc._pDBUserKey '"#P@ssw0rd#"



                ' "128.1.14.4\MSSQL2012DEV"
                '"R&D.BPLTIMS"
                _nClssBPLTAS.BPLTAS_xLoginName = xAcctno
                _nClssBPLTAS.BPLTAS_xAcctno = xAcctno
                _nClssBPLTAS.BPLTAS_xForyear = BPLTAS_xForyear
                _nClssBPLTAS.BPLTAS_xBuscode = xBuscode
                '_nClssBPLTAS.BPLTAS_xELECFEE = xELECFEE
                '_nClssBPLTAS.BPLTAS_xMECHFEE = xMECHFEE
                '_nClssBPLTAS.BPLTAS_xBLDGFEE = xBLDGFEE
                '_nClssBPLTAS.BPLTAS_xSIGNFEE = xSIGNFEE
                '_nClssBPLTAS.BPLTAS_xEPOFEE = xEPOFEE
                '_nClssBPLTAS.BPLTAS_xEIFFEE = xEIFFEE
                '_nClssBPLTAS.BPLTAS_xPLATEFEE = xPLATEFEE
                '_nClssBPLTAS.BPLTAS_xIfFinalSave = xSwitch
                _nClssBPLTAS.pSub_PROCESS_AIF_PerLine()


            End With
        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Sub

    Private Sub _mFnCallClssAIF_LINE_PROCESS(ByVal xIDLogName As String, ByVal xAcctno As String, ByVal BPLTAS_xForyear As String, _
                                   ByVal xBuscode As String)
        Try
            'Dim _nClass As New VS2014.CL.BPLTIMS.cDalBusinessLine
            'With _nClass
            '    ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            '    Dim _nClssBPLTAS As New BPLTASAIF_PERLINE_OL.clsAIF_PerLine_NEW
            '    Dim x As String = Nothing


            '    'BPLTIMS
            '    Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
            '    _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
            '    _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
            '    _nClBPLTIMS._pSubRecordSelectSpecific()

            '    _nClssBPLTAS.BPLTAS_SERVER = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
            '    _nClssBPLTAS.BPLTAS_xDataBase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToStrin
            '    _nClssBPLTAS.BPLTAS_xUID = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
            '    _nClssBPLTAS.BPLTAS_xPW = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"

            '    'BPLTAS LIVE
            '    Dim _nClBP As New cDalGlobalConnectionsDefault
            '    _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            '    _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            '    _nClBP._pSubRecordSelectSpecific()

            '    _nClssBPLTAS.LIVE_BPLTAS_SERVER = _nClBP._pDBDataSource ' cGlobalConnections._pSqlCxn_BPLTAS.DataSource.ToString
            '    _nClssBPLTAS.LIVE_BPLTAS_xDataBase = _nClBP._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTAS.Database.ToString ''"BPLTAS_TABUK_201702089" '
            '    _nClssBPLTAS.LIVE_BPLTAS_xUID = _nClBP._pDBUserID '"sa"
            '    _nClssBPLTAS.LIVE_BPLTAS_xPW = _nClBP._pDBUserKey '"P@ssw0rd"

            '    Dim _nClDoc As New cDalGlobalConnectionsDefault
            '    _nClDoc._pCxn = cGlobalConnections._pSqlCxn_CR
            '    _nClDoc._pSetupGlobalConnectionsDatabases = "BPLTAS_D"
            '    _nClDoc._pSubRecordSelectSpecific()

            '    _nClssBPLTAS.BPLTAS_SERVER = _nClDoc._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
            '    _nClssBPLTAS.BPLTASDOC_xDataBase = _nClDoc._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToStrin
            '    '_nClssBPLTAS.BPLTAS_xUID = _nClDoc._pDBUserID '"juan.dela.cruz"
            '    '_nClssBPLTAS.BPLTAS_xPW = _nClDoc._pDBUserKey '"#P@ssw0rd#"

            '    ' "128.1.14.4\MSSQL2012DEV"
            '    '"R&D.BPLTIMS"
            '    _nClssBPLTAS.BPLTAS_xLoginName = xAcctno
            '    _nClssBPLTAS.BPLTAS_xAcctno = xAcctno
            '    _nClssBPLTAS.BPLTAS_xForyear = BPLTAS_xForyear
            '    _nClssBPLTAS.BPLTAS_xBuscode = xBuscode

            '    _nClssBPLTAS.pSub_PROCESS_AIF_PerLine()

            'End With
        Catch ex As Exception

        End Try
    End Sub

    Public Function IfRecordExist(ByVal _nTableName As String, ByVal _nCondition As String) As Boolean
        Try
            IfRecordExist = False
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing
            Dim _nclass As New cDal_IUD
            With _nclass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = "SELECT * FROM " & _nTableName
                ._pCondition = _nCondition
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return True
                End If

            End With


        Catch ex As Exception
            cEventLog._pSubLogError(ex)
        End Try
    End Function
    Private Sub _LogData(ByVal _nAsk As String, ByRef _nInfo As String)
        Try

            Dim _nSuccessful As Boolean
            Dim _nErrMsg As String = Nothing
            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = " INSERT INTO BusinessLineDataLog " & _
                            " ( " & _
                            " ACCTNO, BUSCODE, FORYEAR, DATA, INFO " & _
                            " ) " & _
                            " VALUES " & _
                            " ( ''" & cLoader_BPLTIMS._pACCTNO & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pBUS_CODE & "'' " & _
                            " ,''" & cLoader_BPLTIMS._pFORYEAR & "'' " & _
                            " ,''" & _nAsk & "'' " & _
                            " ,''" & _nInfo & "'') "

                ._pExec(_nSuccessful, _nErrMsg)
            End With

        Catch ex As Exception

        End Try

    End Sub
End Class
