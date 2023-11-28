Imports System.IO
Imports System.Data.SqlClient

Partial Public Class BusApplicationSummary

    Private Sub _SetDefault()
        cLoader_BPLTIMS._pAPP_DATE = _FnGetCurrentDate()
    End Sub

    Public Sub _PassValuetoClassLoader()

        'Dim _nOwnership As String = S1_Ownershiptype.Value 'Slide_01_OwnershipType.Value
        'Select Case UCase(_nOwnership)
        '    Case UCase("Single")
        '        cLoader_BPLTIMS._pOWNCODE = "S"
        '    Case UCase("Corporation")
        '        cLoader_BPLTIMS._pOWNCODE = "C"
        '    Case UCase("Partnership")
        '        cLoader_BPLTIMS._pOWNCODE = "P"
        '    Case UCase("Cooperative")
        '        cLoader_BPLTIMS._pOWNCODE = "A"
        '    Case UCase("Foreign")
        '        cLoader_BPLTIMS._pOWNCODE = "F"
        'End Select

        cLoader_BPLTIMS._pOWNCODE = Session("OwnershipType") ' modified Louie 20210702

        cSessionLoader._pCurrentYear = Date.Today.Year

        cLoader_BPLTIMS._pSUBD = S2_Address.Value 'Slide_02_Address.Value
        cLoader_BPLTIMS._pP_ADMIN = S2_Administrator.Value ' Slide_02_Administrator.Value
        cLoader_BPLTIMS._pBRGY = S2_Brgy.Value ' Slide_02_Brgy.Value
        cLoader_BPLTIMS._pP_RENTDATE = S2_DateRented.Value ' Slide_02_DateRented.Value
        cLoader_BPLTIMS._pEMAIL = S2_Email.Value ' Slide_02_Email.Value
        cLoader_BPLTIMS._pFIRSTNAME = S2_FName.Value ' Slide_02_LessorFname.Value
        cLoader_BPLTIMS._pLASTNAME = S2_LName.Value ' Slide_02_LessorLname.Value
        cLoader_BPLTIMS._pP_RENT = S2_RentPerMonth.Value '  Slide_02_RentPerMonth.Value
        cLoader_BPLTIMS._pSTREET = S2_Street.Value ' Slide_02_Street.Value
        cLoader_BPLTIMS._pTEL = S2_TelNo.Value ' Slide_02_TelNo.Value

        'cLoader_BPLTIMS	=	'Slide_03_OwnerImg.value 			 
        'cLoader_BPLTIMS	=	'Slide_03_EstablishmentIMG.value 	 
        'cLoader_BPLTIMS	=	'Slide_03_MapIMG.value 				 

        cLoader_BPLTIMS._pCDA_NO = S5_CDA.Value ' Slide_05_CDA.Value
        cLoader_BPLTIMS._pCDA_DATE = S5_CDA2.Value ' Slide_05_CDA2.Value
        cLoader_BPLTIMS._pDTI_NO = S5_DTI.Value ' Slide_05_DTI.Value
        cLoader_BPLTIMS._pDTI_DATE = S5_DTI2.Value ' Slide_05_DTI2.Value
        cLoader_BPLTIMS._pSEC_NO = S5_SEC.Value ' Slide_05_SEC.Value
        cLoader_BPLTIMS._pSEC_DATE = S5_SEC2.Value ' Slide_05_SEC2.Value
        cLoader_BPLTIMS._pTIN_NO = S5_TIN.Value ' Slide_05_TIN.Value
        cLoader_BPLTIMS._pTIN_DATE = S5_TIN2.Value ' Slide_05_TIN2.Value
        cLoader_BPLTIMS._pSSS_NO = S5_SSS.Value ' Slide_05_SSS.Value
        cLoader_BPLTIMS._pSSS_DATE = S5_SSS2.Value ' Slide_05_SSS2.Value
        cLoader_BPLTIMS._pBC_NO = S5_Brgy.Value ' Slide_05_Brgy.Value
        cLoader_BPLTIMS._pBC_DATE = S5_Brgy2.Value ' Slide_05_Brgy2.Value
        cLoader_BPLTIMS._pCTC_NO = S5_CTC.Value ' Slide_05_CTC.Value
        cLoader_BPLTIMS._pCTC_DATE = S5_CTC2.Value ' Slide_05_CTC2.Value
        cLoader_BPLTIMS._pCTC_PLACE = S5_CTCPlace.Value ' Slide_05_CTCPlace.Value
        cLoader_BPLTIMS._pCTC_AMT = S5_CTCPlace2.Value ' Slide_05_CTCPlace2.Value


        cLoader_BPLTIMS._pPEZA_NO = ""
        cLoader_BPLTIMS._pPEZA_DATE = ""

        cLoader_BPLTIMS._pACR_NO = ""
        cLoader_BPLTIMS._pACR_DATE = ""

        cLoader_BPLTIMS._pBLDGPERMITNO = ""
        cLoader_BPLTIMS._pBLDGPERMITDATE = ""

        cLoader_BPLTIMS._pOCCUPANCYNO = ""
        cLoader_BPLTIMS._pOCCUPANCYDATE = ""

        cLoader_BPLTIMS._pBOI_NO = ""
        cLoader_BPLTIMS._pBOI_DATE = ""





        'cLoader_BPLTIMS._p	=	'Slide_05_BIR.Value 				 
        'cLoader_BPLTIMS	=	'Slide_05_BIR2.Value 				 
        cLoader_BPLTIMS._pDATE_ESTA = S6_DateEstablished.Value ' Slide_06_DateEstablished.Value
        cLoader_BPLTIMS._pCOMMNAME = S6_TradeName.Value ' Slide_06_TradeName.Value
        'cLoader_BPLTIMS._p	=	'Slide_06_Description.Value 		 
        cLoader_BPLTIMS._pBRANCH = S6_Branch.Value ' Slide_06_Branch.Value
        cLoader_BPLTIMS._pNO_EMP_M = S6_NoMale.Value ' Slide_06_NoMale.Value
        cLoader_BPLTIMS._pNO_EMP_F = S6_NoFemale.Value ' Slide_06_NoFemale.Value
        cLoader_BPLTIMS._pNO_EMP = CInt(IIf(S6_NoFemale.Value = "", 0, S6_NoFemale.Value)) + CInt(IIf(S6_NoFemale.Value = "", 0, S6_NoMale.Value))
        cLoader_BPLTIMS._pNO_EMP_LGU = S6_NoLGU.Value

        cLoader_BPLTIMS._pDISTCODE = S7_DistCode.Value 'Left(S7_Brgy_code.Value, 4)
        cLoader_BPLTIMS._pBRGYCODE = S7_Brgy_code.Value
        cLoader_BPLTIMS._pSTRTCODE = _FnGetStrtCode(cLoader_BPLTIMS._pBRGYCODE, S7_Street.Value) ' S7_Street_code.Value
        cLoader_BPLTIMS._pGRPBLDG = "" ' S7_GrpBlg.Value ' Slide_07_GrpBlg.Value


        cLoader_BPLTIMS._pSTICKERNO = S7_StickerNo.Value ' Slide_07_StickerNo.Value
        cLoader_BPLTIMS._pPLATENO = S7_PlateNo.Value 'Slide_07_PlateNo.Value
        cLoader_BPLTIMS._pSTALLNO = S7_StallNo.Value 'Slide_07_StallNo.Value
        cLoader_BPLTIMS._pCOMMADDR = S7_Address.Value 'Slide_07_Address.Value
        cLoader_BPLTIMS._pEMAILADDR2 = S8_AlternateEmail.Value ' Slide_08_AlternateEmail.Value
        If S8_Suffix.Value = "" Then
            cLoader_BPLTIMS._pLAST_NAME = S8_Lname.Value
        Else
            cLoader_BPLTIMS._pLAST_NAME = S8_Lname.Value + " " + S8_Suffix.Value ' Slide_08_Lname.Value
        End If
        cLoader_BPLTIMS._pFIRST_NAME = S8_Fname.Value ' Slide_08_Fname.Value
        cLoader_BPLTIMS._pMIDDLE_NAME = S8_Mname.Value ' Slide_08_Mname.Value
        cLoader_BPLTIMS._pCTZNCODE = S8_Citizenship.Value

        Dim _nGender As String = S8_Gender.Value
        Select Case UCase(_nGender)
            Case "MALE"
                cLoader_BPLTIMS._pPRES_GENDER = "M"
                cLoader_BPLTIMS._pP_Gender = "M"
            Case "FEMALE"
                cLoader_BPLTIMS._pPRES_GENDER = "F"
                cLoader_BPLTIMS._pP_Gender = "F"
        End Select

        'cLoader_BPLTIMS._pCTZNCODE = Slide_08_Citizenship.Value
        cLoader_BPLTIMS._pOWNERADDR = S8_Address.Value
        cLoader_BPLTIMS._pOWNERTEL = S8_TelNo.Value
        cLoader_BPLTIMS._pEMAILADDR = cSessionUser._pUserID()
        cLoader_BPLTIMS._pP_ADMIN = S2_Administrator.Value
        cLoader_BPLTIMS._pP_RENT = S2_RentPerMonth.Value
        cLoader_BPLTIMS._pP_RENTDATE = S2_DateRented.Value
        cLoader_BPLTIMS._pPres_FName = ""
        cLoader_BPLTIMS._pPres_MName = ""
        cLoader_BPLTIMS._pPres_LName = ""
        cLoader_BPLTIMS._pPRES_NAME = ""


        cLoader_BPLTIMS._pSTATCODE = "N"
    End Sub

    Public Sub _mSaveBusMast(ByRef _nSuccessful As Boolean, ByRef _nCode As String, Optional ByRef _nErrMsg As String = "", Optional ByRef _nCondition As String = Nothing)
        Try
            Dim _nClass As New cDalBusMast
            With _nClass
                '._pAdd()
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

                ._pACCTNO = cSessionLoader._pAccountNo
                ._pAPP_DATE = Date.Now 'cLoader_BPLTIMS._pAPP_DATE

                ' == BUSINESS INFO
                ._pDATE_ESTA = cLoader_BPLTIMS._pDATE_ESTA '_oHidden_DateEstablish.Value.ToString
                ._pOWNCODE = cLoader_BPLTIMS._pOWNCODE '_oHidden_OwnCode.Value

                ._pCOMMNAME = cLoader_BPLTIMS._pCOMMNAME
                ._pCOMMADDR = cLoader_BPLTIMS._pCOMMADDR
                ._pSTICKERNO = cLoader_BPLTIMS._pSTICKERNO
                ._pBRGYCODE = cLoader_BPLTIMS._pBRGYCODE
                ._pSTRTCODE = cLoader_BPLTIMS._pSTRTCODE
                ._pDISTCODE = cLoader_BPLTIMS._pDISTCODE
                ._pGRPBLDG = "" 'cLoader_BPLTIMS._pGRPBLDG

                ._pNO_EMP = cLoader_BPLTIMS._pNO_EMP
                ._pPLATENO = cLoader_BPLTIMS._pPLATENO
                ._pSTALLNO = cLoader_BPLTIMS._pSTALLNO

                ._pLAST_NAME = cLoader_BPLTIMS._pLAST_NAME
                ._pFIRST_NAME = cLoader_BPLTIMS._pFIRST_NAME
                ._pMIDDLE_NAME = cLoader_BPLTIMS._pMIDDLE_NAME
                ._pOWNERADDR = cLoader_BPLTIMS._pOWNERADDR
                ._pCTZNCODE = cLoader_BPLTIMS._pCTZNCODE

                ._pOWNERTEL = cLoader_BPLTIMS._pOWNERTEL
                ._pEMAILADDR = cLoader_BPLTIMS._pEMAILADDR
                ._pEMAILADDR2 = cLoader_BPLTIMS._pEMAILADDR2

                ._pCONTACT = cLoader_BPLTIMS._pCONTACT
                ._pCONTTEL = cLoader_BPLTIMS._pCONTTEL
                ._pCPNO = cLoader_BPLTIMS._pCPNO
                ._pCPNO2 = cLoader_BPLTIMS._pCPNO2
                ._pCPNO2 = cLoader_BPLTIMS._pCPNO2

                ._pCPNoGTM = cLoader_BPLTIMS._pCPNoGTM
                ._pCPNoSMTNT = cLoader_BPLTIMS._pCPNoSMTNT
                ._pCPNoSun = cLoader_BPLTIMS._pCPNoSun

                ._pTIN_NO = cLoader_BPLTIMS._pTIN_NO
                ._pTIN_DATE = cLoader_BPLTIMS._pTIN_DATE

                ._pSSS_NO = cLoader_BPLTIMS._pSSS_NO
                ._pSSS_DATE = cLoader_BPLTIMS._pSSS_DATE

                ._pBC_NO = cLoader_BPLTIMS._pBC_NO
                ._pBC_DATE = cLoader_BPLTIMS._pBC_DATE

                ._pPEZA_NO = cLoader_BPLTIMS._pPEZA_NO
                ._pPEZA_DATE = cLoader_BPLTIMS._pPEZA_DATE

                ._pACR_NO = cLoader_BPLTIMS._pACR_NO
                ._pACR_DATE = cLoader_BPLTIMS._pACR_DATE

                ._pBLDGPERMITNO = cLoader_BPLTIMS._pBLDGPERMITNO
                ._pBLDGPERMITDATE = cLoader_BPLTIMS._pBLDGPERMITDATE

                ._pOCCUPANCYNO = cLoader_BPLTIMS._pOCCUPANCYNO
                ._pOCCUPANCYDATE = cLoader_BPLTIMS._pOCCUPANCYDATE

                ._pBOI_NO = cLoader_BPLTIMS._pBOI_NO
                ._pBOI_DATE = cLoader_BPLTIMS._pBOI_DATE

                ._pCTC_NO = cLoader_BPLTIMS._pCTC_NO
                ._pCTC_DATE = cLoader_BPLTIMS._pCTC_DATE
                ._pCTC_PLACE = cLoader_BPLTIMS._pCTC_PLACE
                ._pCTC_AMT = cLoader_BPLTIMS._pCTC_AMT

                ._pCDA_NO = cLoader_BPLTIMS._pCDA_NO
                ._pCDA_DATE = cLoader_BPLTIMS._pCDA_DATE
                ._pDTI_NO = cLoader_BPLTIMS._pDTI_NO
                ._pDTI_DATE = cLoader_BPLTIMS._pDTI_DATE
                ._pSEC_NO = cLoader_BPLTIMS._pSEC_NO
                ._pSEC_DATE = cLoader_BPLTIMS._pSEC_DATE

                ._pSTATCODE = cLoader_BPLTIMS._pSTATCODE
                ._pP_ADMIN = cLoader_BPLTIMS._pP_ADMIN
                ._pP_RENT = cLoader_BPLTIMS._pP_RENT
                ._pP_RENTDATE = cLoader_BPLTIMS._pP_RENTDATE

                '._pSave(_nSuccessful, _nCondition, _nErrMsg)
                ._pSubInsert(_nSuccessful, _nCondition, _nErrMsg)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mSaveBusMastExtn(ByRef _nSuccessful As Boolean, ByRef _nCode As String, Optional ByRef _nErrMsg As String = "", Optional ByRef _nCondition As String = Nothing)
        Try
            Dim _nClass As New cDalBusMastExtn
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                '._pAdd()
                ._pACCTNO = cSessionLoader._pAccountNo
                ._pAUTHO_REP = cLoader_BPLTIMS._pAUTHO_REP
                ._pAUTHO_REP_POS = cLoader_BPLTIMS._pAUTHO_REP_POS
                ._pBLDG = cLoader_BPLTIMS._pBLDG
                ._pBRGY = cLoader_BPLTIMS._pBRGY
                ._pCITY = cLoader_BPLTIMS._pCITY
                ._pDOWNLOADED = cLoader_BPLTIMS._pDOWNLOADED
                ._pEMAIL = cLoader_BPLTIMS._pEMAIL
                ._pEMRGNCY_CONTACT = cLoader_BPLTIMS._pEMRGNCY_EMAIL
                ._pEMRGNCY_EMAIL = cLoader_BPLTIMS._pEMRGNCY_EMAIL
                ._pEMRGNCY_MOBILE = cLoader_BPLTIMS._pEMRGNCY_MOBILE
                ._pEMRGNCY_TEL = cLoader_BPLTIMS._pEMRGNCY_TEL
                ._pFIRSTNAME = cLoader_BPLTIMS._pFIRSTNAME
                ._pFORYEAR = cSessionLoader._pCurrentYear
                ._pIF_WITH_TAX = cLoader_BPLTIMS._pIF_WITH_TAX
                ._pLASTNAME = cLoader_BPLTIMS._pLASTNAME
                ._pMIDDLENAME = cLoader_BPLTIMS._pMIDDLENAME
                ._pNO_EMP_F = cLoader_BPLTIMS._pNO_EMP_F
                ._pNO_EMP_M = cLoader_BPLTIMS._pNO_EMP_M
                ._pNO_EMP_LGU = cLoader_BPLTIMS._pNO_EMP_LGU
                ._pP_Gender = cLoader_BPLTIMS._pP_Gender
                ._pP_Treasurer = cLoader_BPLTIMS._pP_Treasurer
                ._pPres_FName = cLoader_BPLTIMS._pPres_FName
                ._pPRES_GENDER = cLoader_BPLTIMS._pPRES_GENDER
                ._pP_Gender = cLoader_BPLTIMS._pP_Gender
                ._pPres_LName = cLoader_BPLTIMS._pPres_LName
                ._pPres_MName = cLoader_BPLTIMS._pPRES_NAME
                ._pPRES_NAME = cLoader_BPLTIMS._pPRES_NAME
                ._pPROVINCE = cLoader_BPLTIMS._pPROVINCE
                ._pSTREET = cLoader_BPLTIMS._pSTREET
                ._pSUBD = cLoader_BPLTIMS._pSUBD
                ._pTAX_INDIC = cLoader_BPLTIMS._pTAX_INDIC
                ._pTEL = cLoader_BPLTIMS._pTEL
                ._pTREAS_NAME = cLoader_BPLTIMS._pTREAS_NAME
                ._pUPLOADED = cLoader_BPLTIMS._pUPLOADED

                '._pSave(_nSuccessful, _nCondition, _nErrMsg)
                ._pSubInsert(_nSuccessful, _nCondition, _nErrMsg)
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Sub _SaveInformation(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        'cSessionLoader._pAccountNo = _FnAutoGenID("NewBusinessPermit") ' @Remarked 20211102 Louie
        cSessionLoader._pAccountNo = _FnAutoGenID_NEW() ' @Added 20211102 Louie
        cLoader_BPLTIMS._pACCTNO = cSessionLoader._pAccountNo
        _mSaveBusMast(_nSuccessful, "", _nErrMsg, "")
        If _nSuccessful = True Then
            _mSaveBusMastExtn(_nSuccessful, "", _nErrMsg, "")
        End If

    End Sub

    Public Function _FnAutoGenID(ByVal _nModuleID As String, Optional _nRefCode As String = Nothing) As String
        _FnAutoGenID = Nothing
        Try

            Dim _nClass As New cDalAutoGenID
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim _nResult = _nClass._FnAutoGenID(_nModuleID, _nRefCode)
            Return _nResult

        Catch ex As Exception

        End Try
    End Function

    Public Function _FnAutoGenID_NEW() As String
        _FnAutoGenID_NEW = Nothing
        Try
            Dim _nSuccessful As Boolean, _nErrMsg As String = Nothing

            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "SELECT"
                ._pSelect = " SELECT FORMAT (GETDATE(), ''yyMMdd-HHmmssff'') as TempID "
                ._pExec(_nSuccessful, _nErrMsg)

                Dim _nDataTable As DataTable

                _nDataTable = ._pDataTable
                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("TempID").ToString()
                Else
                    Return ""
                End If



            End With



        Catch ex As Exception
            cDalLogEvent._pSubLogError(ex)
            Return ""
        End Try
    End Function

    Public Function _FnGetCurrentDate() As Date
        _FnGetCurrentDate = Nothing
        Try
            Dim _nClass As New cDalGetCurrentDate
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim _nResult = _nClass._FnGetCurrentDate()
            Return _nResult

        Catch ex As Exception

        End Try

    End Function

    Public Shared Sub ResizeImage(ByVal image As String, ByVal Okey As String, ByVal key As String, ByVal width As Integer, ByVal height As Integer, ByVal newimagename As String)

        Try

            Dim oImg As System.Drawing.Image = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/" & ConfigurationManager.AppSettings(Okey) & image))
            Dim oThumbNail As System.Drawing.Image = New System.Drawing.Bitmap(width, height)
            Dim oGraphic As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(oThumbNail)
            oGraphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality
            oGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
            oGraphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            oGraphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
            Dim oRectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, width, height)
            oGraphic.DrawImage(oImg, oRectangle)

            If image.Substring(newimagename.LastIndexOf(".")) <> ".png" Then
                oThumbNail.Save(HttpContext.Current.Server.MapPath("~/images/" & ConfigurationManager.AppSettings(Okey) & image), System.Drawing.Imaging.ImageFormat.Jpeg)
            Else : oThumbNail.Save(HttpContext.Current.Server.MapPath("~/images/" & ConfigurationManager.AppSettings(Okey) & image), System.Drawing.Imaging.ImageFormat.Png)
            End If

            oImg.Dispose()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub _mAcquireAttachmentTemp(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            Dim _nClass As New cDal_IUD
            Dim _nAcctno As String = cSessionLoader._pAccountNo

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO " & _
                             "[BPLTAS_PICTURES] " & _
                             " (ID, ACCTNO, FORYEAR, REMARKS, PICTURE, XDEFAULT, XCODE, PIC_OWNER, TMNO, TMDATE, BOOKACCUSED, DSALESRECEIPT, TMREMARKS, INSPECTOR, PIC_LOCATION, DOWNLOADED, UPLOADED, O_FileType " & _
                             " ,E_FileType, M_FileType, O_FileName, E_FileName, M_FileName) " & _
                             " SELECT " & _
                             " ''" & cSessionLoader._pAccountNo & "-0001'', ''" & cSessionLoader._pAccountNo & "'', FORYEAR, REMARKS, PICTURE, XDEFAULT, XCODE, PIC_OWNER, TMNO, TMDATE, BOOKACCUSED, DSALESRECEIPT, TMREMARKS, INSPECTOR, PIC_LOCATION, DOWNLOADED, UPLOADED, O_FileType,  " & _
                             " E_FileType, M_FileType, O_FileName, E_FileName, M_FileName " & _
                             " FROM BPLTAS_PICTURES_TEMP " & _
                             " WHERE ID = ''" & cSessionLoader._pControlNo & "'' "
                ._pExec(_nSuccessful, _nErrMsg)

            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _AcquireRequirementSubmittedTemp(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Try
            Dim _nClass As New cDal_IUD
            Dim _nAcctno As String = cSessionLoader._pAccountNo

            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAction = "INSERT"
                ._pSelect =
                    "SET IDENTITY_INSERT BP_SubmittedReq ON " & _
                    " INSERT INTO " & _
                        " BP_SubmittedReq " & _
                        " (AccountNo, ForYear, ReqCode, Remarks, ToFollow, RowId, ImagesID, Name, Size, ImageData, FileExtn) " & _
                        " SELECT " & _
                        " 	''" & cSessionLoader._pAccountNo & "'', ForYear, ReqCode, Remarks, ToFollow, RowId, ImagesID, Name, Size, ImageData, FileExtn " & _
                        " FROM  " & _
                        " 	BP_SubmittedReq_Temp " & _
                        " Where UniqueID = ''" & cSessionLoader._pControlNo & "'' " & _
                    " SET IDENTITY_INSERT BP_SubmittedReq OFF "
                ._pExec(_nSuccessful, _nErrMsg)

            End With
        Catch ex As Exception

        End Try
    End Sub

    Public Sub _mSaveImageAttachment(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = "")
        Dim _nClass As New cDal_IUD
        Dim _nAcctno As String = cSessionLoader._pAccountNo

        With _nClass
            ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            ._pAction = "INSERT"
            ._pSelect = "INSERT INTO " & _
                          "[BPLTAS_PICTURES] " & _
                          " (id,FORYEAR,ACCTNO,XCODE,XDEFAULT) " & _
                          " VALUES " & _
                          " (''" & _nAcctno & "-0001'', CONVERT(DATE, GETDATE()),''" & _nAcctno & "'',''0001'',''1'') "

            ._pExec(_nSuccessful, _nErrMsg)

        End With

    End Sub

    Private Sub _mSubSaveResizedImage(ByVal FileName As String, ByVal ImageKind As String, xFile As FileUpload, ByVal _nAcctNo As String)
        Try
            Dim _nClass As New cdalpicture
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pACCTNO = _nAcctNo


                ._pFileExtn = System.IO.Path.GetExtension(xFile.PostedFile.FileName)
                ._ppicdata = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/images/" & FileName))
                ._pFileName = FileName

                Select Case ImageKind

                    Case "O"
                        ._pSubUpdateImageowner()

                    Case "E"
                        ._pSubUpdateImageestab()

                    Case "M"
                        ._pSubUpdateImagemap()

                End Select



            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub _mSubSaveImages(ByVal FileName As String, ByVal ImageKind As String, xFile As FileUpload, ByVal _nAcctNo As String)
        Try
            Dim _nClass As New cdalpicture
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pACCTNO = _nAcctNo

                ._pFileExtn = System.IO.Path.GetExtension(xFile.PostedFile.FileName)
                ._ppicdata = xFile.FileBytes
                ._pFileName = FileName

                Select Case ImageKind

                    Case "O"
                        ._pSubUpdateImageowner()

                    Case "E"
                        ._pSubUpdateImageestab()

                    Case "M"
                        ._pSubUpdateImagemap()

                End Select

            End With

        Catch ex As Exception

        End Try


    End Sub

    Public Sub _SaveFileImage(_nAccountNo As String, _oImgFile As FileUpload, _nImageKind As String)
        Try
            Dim iMinAircraftImgWidth As Integer = 10000
            Dim iMinAircraftImgHeight As Integer = 10000
            Dim MaxFileSize As Integer = 10485760 ' < Maximum File Size is 10 MB

            If _oImgFile.HasFile = True Then

                Dim postedFile As HttpPostedFile = _oImgFile.PostedFile
                Dim fileName As String = _nAccountNo + _nImageKind + "_" + Path.GetFileName(postedFile.FileName)
                Dim fileExtension As String = Path.GetExtension(fileName)
                Dim fileSize As Integer = postedFile.ContentLength
                Dim strNewFileName As String = "Px" + fileName

                If fileExtension.ToLower() = ".jpg" Or fileExtension.ToLower() = ".jpeg" Or fileExtension.ToLower() = ".png" Or fileExtension.ToLower() = ".gif" Or fileExtension.ToLower() = ".bmp" Or fileExtension.ToLower() = ".zip" Or fileExtension.ToLower = ".rar" Then

                    If fileSize > MaxFileSize Then

                        '_oPanelErrMsgOwner.Visible = True
                        '_oLabelErrMsgOwner.Text = "Cannot upload image, file exceeds the maximum limit of 10 MB."
                        '_oLabelErrMsgOwner.ForeColor = Drawing.Color.Red

                    Else

                        If fileSize > (MaxFileSize / 2) And (fileExtension.ToLower() <> ".zip" And fileExtension.ToLower <> ".rar") Then

                            _oImgFile.SaveAs(Server.MapPath("~/" & Path.GetFileName(fileName))) '< Save Image to Temporary folder

                            ResizeImage(fileName, "imagepath", "imagepath", iMinAircraftImgWidth, iMinAircraftImgHeight, strNewFileName) ' < Initialize Resize Image
                            _mSubSaveResizedImage(fileName, _nImageKind, _oImgFile, _nAccountNo)

                            File.Delete(HttpContext.Current.Server.MapPath("~/images/" & fileName)) '< Drop Image from Temporary Folder
                            File.Delete(HttpContext.Current.Server.MapPath("~/" & fileName))

                        Else
                            _mSubSaveImages(fileName, _nImageKind, _oImgFile, _nAccountNo)

                        End If

                        '_oPanelErrMsgOwner.Visible = False

                    End If

                Else
                    '_oPanelErrMsgOwner.Visible = True
                    '_oLabelErrMsgOwner.Text = "Invalid File Format!"
                    '_oLabelErrMsgOwner.ForeColor = Drawing.Color.Red

                End If

            End If

        Catch ex As Exception

        End Try


    End Sub

    Public Function _ValidateImage(
                               _nFilename As String _
                                 , _nFileExtension As String _
                                     , _nAccountNo As String _
                                         , _nUniqueID As String _
                                             , _nReqCode As String _
                                                 , _nForYear As String _
                                                     , _nFileSize As Integer _
                                                         , _nMaxFileSize As Integer _
                                                             , ByRef _nMsg As String
                              ) As Boolean
        _ValidateImage = True

        Select Case True

            Case _nFilename = ""
                _nMsg = "No file selected!"
                Return False
            Case _nFileExtension.ToLower <> ".jpg" And _nFileExtension.ToLower() <> ".jpeg" And _nFileExtension.ToLower() <> ".gif" And _nFileExtension.ToLower() <> ".png" And _nFileExtension.ToLower() <> ".pdf" And _nFileExtension.ToLower() <> ".bmp" And _nFileExtension.ToLower() <> ".rar" And _nFileExtension.ToLower() <> ".zip"
                _nMsg = "Invalid File Format!"
                Return False
            Case CheckIfFileExist(_nAccountNo, _nReqCode, _nForYear, _nFilename) 'Check If Exist in Table (BP_SubmittedReq)
                _nMsg = "Cannot upload same image file within the same requirement!"
                Return False

            Case _nFileSize > _nMaxFileSize
                _nMsg = "Cannot upload image, file exceeds the maximum size of 10 MB!"
                Return False
            Case Else
                Return True

        End Select

    End Function

    Public Sub _SaveImageRequirements(ByVal _nAcctno As String, ByVal ForYear As String, ByVal ReqCode As String, ByVal FileName As String, ByVal FileSize As Integer, ByVal Bytes As Byte(), ByVal FileExtension As String, ByRef _nImageID As String)
        Try

            'Using con As New SqlConnection(cGlobalConnections._pSqlCxn_BPLTIMS.ToString)
            Dim cmd As New SqlCommand("spUploadImageReqImages", cGlobalConnections._pSqlCxn_BPLTIMS)
            cmd.CommandType = CommandType.StoredProcedure

            Dim paramAcctno As New SqlParameter("@AccountNo", SqlDbType.NVarChar)
            paramAcctno.Value = _nAcctno
            cmd.Parameters.Add(paramAcctno)

            Dim paramForYear As New SqlParameter("@ForYear", SqlDbType.Int)
            paramForYear.Value = ForYear
            cmd.Parameters.Add(paramForYear)

            Dim paramReqCode As New SqlParameter("@ReqCode", SqlDbType.NVarChar)
            paramReqCode.Value = ReqCode
            cmd.Parameters.Add(paramReqCode)

            Dim paramRemarks As New SqlParameter("@Remarks", SqlDbType.NVarChar)
            paramRemarks.Value = " "
            cmd.Parameters.Add(paramRemarks)

            Dim paramToFollow As New SqlParameter("@ToFollow", SqlDbType.Bit)
            paramToFollow.Value = 1
            cmd.Parameters.Add(paramToFollow)

            '/////// For Image Data
            Dim paramName As New SqlParameter("@Name", SqlDbType.VarChar)
            paramName.Value = FileName
            cmd.Parameters.Add(paramName)

            Dim paramSize As New SqlParameter("@Size", SqlDbType.Int)
            paramSize.Value = FileSize
            cmd.Parameters.Add(paramSize)

            Dim paramImageData As New SqlParameter("@ImageData", SqlDbType.VarBinary)
            paramImageData.Value = Bytes
            cmd.Parameters.Add(paramImageData)

            Dim paramFileExtn As New SqlParameter("@FileExtn", SqlDbType.NVarChar)
            paramFileExtn.Value = FileExtension
            cmd.Parameters.Add(paramFileExtn)

            Dim paramNewId As New SqlParameter("@ImagesID", SqlDbType.Int)
            paramNewId.Value = -1 ' _FnAutoGenID("ReqImageID") 
            _nImageID = paramNewId.Value
            cmd.Parameters.Add(paramNewId)

            'cmd.Open()
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub _ResizeAndSaveImage(_nFile As FileUpload _
                               , _nFileName As String _
                               , _nFileExtension As String _
                               , _nFileSize As Integer _
                               , iMinAircraftImgWidth As Integer _
                               , iMinAircraftImgHeight As Integer _
                               , strNewFileName As String _
                                , _nAccountNo As String _
                                , _nUniqueID As String _
                                 , _nReqCode As String _
                                   , _nForYear As String
                               )
        _nFile.SaveAs(Server.MapPath("~/" & Path.GetFileName(_nFileName)))
        ResizeImage(_nFileName, "imagepath", "imagepath", iMinAircraftImgWidth, iMinAircraftImgHeight, strNewFileName)

        _nFileExtension = System.IO.Path.GetExtension(_nFile.PostedFile.FileName)
        Dim stream As Stream = _nFile.PostedFile.InputStream
        Dim BinaryReader As New BinaryReader(stream)
        Dim bytes As Byte() = BinaryReader.ReadBytes(CInt(stream.Length))
        bytes = System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/images/" & _nFileName))

        Dim _nImageID As String = Nothing
        _SaveImageRequirements(_nUniqueID, _nReqCode, _nForYear, _nFileName, _nFileSize, bytes, _nFileExtension, _nImageID)
        cSessionLoader._pImageID = _nImageID
    End Sub

    Private Function CheckIfFileExist_Temp(xUniqueID As String, xReqCode As String, xYear As String, xFileName As String) As Boolean
        Try
            CheckIfFileExist_Temp = False

            Dim _nClass As New cDalRequirements
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pUniqueID = xUniqueID
                ._pReqCode = xReqCode
                ._pReqYear = xYear
                ._pReqFileName = xFileName

                ._pTemp_SubSelectSpecificFilename()

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

                If _nDataTable.Rows.Count <> 0 Then
                    Return True
                Else
                    Return False
                End If

            End With
        Catch ex As Exception
            CheckIfFileExist_Temp = False
        End Try

    End Function

    Private Function CheckIfFileExist(xAcctNo As String, xReqCode As String, xYear As String, xFileName As String) As Boolean
        Try
            CheckIfFileExist = False

            Dim _nClass As New cDalRequirements
            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAccount = xAcctNo
                ._pReqCode = xReqCode
                ._pReqYear = xYear
                ._pReqFileName = xFileName

                ._pSubSelectSpecificFilename()

                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

                If _nDataTable.Rows.Count <> 0 Then
                    Return True
                Else
                    Return False
                End If

            End With
        Catch ex As Exception
            CheckIfFileExist = False
        End Try

    End Function

    Public Function _FnGetStrtCode(_nBrgyCode As String, _nStrDesc As String) As String
        Try
            Dim _nSuccess As Boolean, _nErrMsg As String = Nothing

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
                ._pSelect = "SELECT STRTCODE FROM [" & cSessionLoader._pBPLTAS_SvrName & "].[" & cSessionLoader._pBPLTAS_DbName & "].dbo.STRTCODE "
                ._pCondition = " WHERE BRGYCODE = ''" & _nBrgyCode & "'' AND STRTDESC = ''" & _nStrDesc & "'' "
                ._pExec(_nSuccess, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then
                    Return _nDataTable.Rows(0).Item("STRTCODE").ToString
                Else
                    Return S7_Street_code.Value
                End If

            End With
        Catch ex As Exception
            Return ""
        End Try
    End Function


End Class
