#Region "Import"

Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

#End Region

Partial Public Class BPLTIMS_BPLOReview

    Private Sub _LoadInformation()
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

            Dim _nClass As New cDalBusinessInfoSummary
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAcctNo = cSessionLoader._pAccountNo
                ._pForYear = cSessionLoader._pCurrentYear
                ._pLiveSvr = cSessionLoader._pBPLTAS_SvrName
                ._pLiveDb = cSessionLoader._pBPLTAS_DbName

                ._pExec(_nSuccessfull, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.HasErrors Then
                    Return
                End If

                If _nDataTable.Rows.Count <= 0 Then

                Else
                    _GetData(_nDataTable)
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _GetData(_nDataTable As DataTable)
        Try
            '_oLabelApplicationDate.Text = Replace(_nDataTable.Rows("0").Item("APP_DATE").ToString, "12:00:00 AM", "")
            _oLabelDateEstablish.Text = Replace(_nDataTable.Rows("0").Item("DATE_ESTA").ToString, "12:00:00 AM", "")
            _oLabelOwnership.Text = _nDataTable.Rows("0").Item("OWNCODE").ToString

            If _oLabelOwnership.Text = "S" Then
                _oLabelOwnerName.Text = _nDataTable.Rows("0").Item("LAST_NAME").ToString & ", " & _nDataTable.Rows("0").Item("FIRST_NAME").ToString & " " & _nDataTable.Rows("0").Item("MIDDLE_NAME").ToString
            Else
                _oLabelOwnerName.Text = _nDataTable.Rows("0").Item("PRES_NAME").ToString
            End If
            _oLabelTreasurer.Text = _nDataTable.Rows("0").Item("TREAS_NAME").ToString
            _oLabelGender.Text = _nDataTable.Rows("0").Item("PRES_GENDER").ToString
            _oLabelCitizenship.Text = _nDataTable.Rows("0").Item("CTZNCODE").ToString
            _oLabelOwnerAddress.Text = _nDataTable.Rows("0").Item("OWNERADDR").ToString
            _oLabelTelNo.Text = _nDataTable.Rows("0").Item("OWNERTEL").ToString
            _oLabelPlateNo.Text = _nDataTable.Rows("0").Item("PLATENO").ToString
            _oLabelEmail.Text = _nDataTable.Rows("0").Item("EMAILADDR").ToString
            cLoader_BPLTIMS._pEMAILADDR = _oLabelEmail.Text
            _oLabelAltEmail.Text = _nDataTable.Rows("0").Item("EMAILADDR2").ToString
            cLoader_BPLTIMS._pEMAILADDR2 = _oLabelAltEmail.Text
            cLoader_BPLTIMS._pNO_EMP = _nDataTable.Rows("0").Item("NO_EMP_M") + _nDataTable.Rows("0").Item("NO_EMP_F")

            ''Ismarket IsBranch to Follow //
            '' Business Information =====
            _oLabelBusinessName.Text = _nDataTable.Rows("0").Item("COMMNAME").ToString
            _oLabelCommAdd.Text = _nDataTable.Rows("0").Item("COMMADDR").ToString
            _oLabelStallNo.Text = _nDataTable.Rows("0").Item("STALLNO").ToString
            _oLabelStickerNo.Text = _nDataTable.Rows("0").Item("STICKERNO").ToString
            '' Contact Information ====
            _oLabelContactName.Text = _nDataTable.Rows("0").Item("CONTACT").ToString
            _oLabelContactTelNo.Text = _nDataTable.Rows("0").Item("CONTTEL").ToString
            _oLabelContactGlobeTM.Text = _nDataTable.Rows("0").Item("CPNO").ToString
            _oLabelContactSmartTNT.Text = _nDataTable.Rows("0").Item("CPNO2").ToString
            _oLabelContactSun.Text = _nDataTable.Rows("0").Item("CPNO3").ToString
            '' Emergency ContactName ====
            _oLabelLessorTelNo.Text = _nDataTable.Rows("0").Item("TEL").ToString
            _oLabelLessorEmailAdd.Text = _nDataTable.Rows("0").Item("EMAIL").ToString

            _oLabelE_ContactName.Text = _nDataTable.Rows("0").Item("EMRGNCY_CONTACT").ToString
            _oLabelE_ContactTelNo.Text = _nDataTable.Rows("0").Item("EMRGNCY_TEL").ToString
            _oLabelE_ContactMobileNo.Text = _nDataTable.Rows("0").Item("EMRGNCY_MOBILE").ToString
            _oLabelE_EmailAdd.Text = _nDataTable.Rows("0").Item("EMRGNCY_EMAIL").ToString

            ''=======================================
            _oLabelTaxIncentives.Text = _nDataTable.Rows("0").Item("IF_WITH_TAX").ToString

            _oLabelRep.Text = _nDataTable.Rows("0").Item("AUTHO_REP").ToString
            _oLabelRepPos.Text = _nDataTable.Rows("0").Item("AUTHO_REP_POS").ToString

            _oLabelMale.Text = _nDataTable.Rows("0").Item("NO_EMP_M").ToString
            _oLabelFemale.Text = _nDataTable.Rows("0").Item("NO_EMP_F").ToString
            _oLabelLGURes.Text = _nDataTable.Rows("0").Item("NO_EMP_LGU").ToString

            _oLabelGrpBldg.Text = _nDataTable.Rows("0").Item("GRPBLDG").ToString
            '' Business Registrations
            _oLabelTIN.Text = _nDataTable.Rows("0").Item("TIN_NO").ToString
            _oLabelTINDate.Text = Replace(_nDataTable.Rows("0").Item("TIN_DATE").ToString, "12:00:00 AM", "")
            _oLabelDTI.Text = _nDataTable.Rows("0").Item("DTI_NO").ToString
            _oLabelDTIDate.Text = Replace(_nDataTable.Rows("0").Item("DTI_DATE").ToString, "12:00:00 AM", "")
            _oLabelSEC.Text = _nDataTable.Rows("0").Item("SEC_NO").ToString
            _oLabelSECDate.Text = Replace(_nDataTable.Rows("0").Item("SEC_DATE").ToString, "12:00:00 AM", "")
            _oLabelSSS.Text = _nDataTable.Rows("0").Item("SSS_NO").ToString
            _oLabelSSSDate.Text = Replace(_nDataTable.Rows("0").Item("SSS_DATE").ToString, "12:00:00 AM", "")
            _oLabelBrgyClearance.Text = _nDataTable.Rows("0").Item("BC_NO").ToString
            _oLabelBrgyClearanceDate.Text = Replace(_nDataTable.Rows("0").Item("BC_DATE").ToString, "12:00:00 AM", "")
            _oLabelPEZA.Text = _nDataTable.Rows("0").Item("PEZA_NO").ToString
            _oLabelPEZADate.Text = Replace(_nDataTable.Rows("0").Item("PEZA_DATE").ToString, "12:00:00 AM", "")
            _oLabelARC.Text = _nDataTable.Rows("0").Item("ACR_NO").ToString
            _oLabelARCDate.Text = Replace(_nDataTable.Rows("0").Item("ACR_DATE").ToString, "12:00:00 AM", "")
            _oLabelBldgNo.Text = _nDataTable.Rows("0").Item("BLDGPERMITNO").ToString
            _oLabelBldgNoDate.Text = Replace(_nDataTable.Rows("0").Item("BLDGPERMITDATE").ToString, "12:00:00 AM", "")
            _oLabelCertificate.Text = _nDataTable.Rows("0").Item("OCCUPANCYNO").ToString
            _oLabelCertificateDate.Text = Replace(_nDataTable.Rows("0").Item("OCCUPANCYDATE").ToString, "12:00:00 AM", "")
            _oLabelBOI.Text = _nDataTable.Rows("0").Item("BOI_NO").ToString
            _oLabelBOIDate.Text = Replace(_nDataTable.Rows("0").Item("BOI_DATE").ToString, "12:00:00 AM", "")
            _oLabelCDA.Text = _nDataTable.Rows("0").Item("CDA_NO").ToString
            _oLabelCDADate.Text = Replace(_nDataTable.Rows("0").Item("CDA_DATE").ToString, "12:00:00 AM", "")
            _oLabelCTCReg.Text = _nDataTable.Rows("0").Item("CTC_NO").ToString
            _oLabelCTCRegDate.Text = Replace(_nDataTable.Rows("0").Item("DTI_DATE").ToString, "12:00:00 AM", "")
            _oLabelCTCPlace.Text = _nDataTable.Rows("0").Item("CTC_PLACE").ToString
            _oLabelCTCPlaceAmt.Text = _nDataTable.Rows("0").Item("CTC_AMT").ToString

            _oLabelPBN.Text = _nDataTable.Rows("0").Item("PBN").ToString
            '' To Follow    _oCheckBoxMarket.Checked = IIf(_nDataTable.Rows("0").Item("IsMarket").ToString = "0", False, True)

            _oLabelLessorName.Text = _nDataTable.Rows("0").Item("LESSOR_FULLNAME").ToString
            _oLabelLessorAddress.Text = _nDataTable.Rows("0").Item("LESSOR_ADDR").ToString
            _oLabelDateRented.Text = Replace(_nDataTable.Rows("0").Item("RENTEDDATE").ToString, "12:00:00 AM", "")
            _oLabelAdmin.Text = _nDataTable.Rows("0").Item("LESSORADMIN").ToString
            _oLabelRentPerMonth.Text = _nDataTable.Rows("0").Item("RENTEDAMOUNT").ToString

            _oLabelDistrict.Text = _nDataTable.Rows("0").Item("DISTRICT").ToString
            _oLabelBarangay.Text = _nDataTable.Rows("0").Item("BRGY").ToString
            _oLabelStreet.Text = _nDataTable.Rows("0").Item("STREET").ToString

            If _oLabelGrpBldg.Text = "" Or _oLabelGrpBldg.Text = Nothing Then
                GrpBldg.Visible = False
            End If

            If _oLabelStickerNo.Text = "" Or _oLabelStickerNo.Text = Nothing Then
                StickerNum.Visible = False
            End If

            If _oLabelPlateNo.Text = "" Or _oLabelPlateNo.Text = Nothing Then
                PlateNo.Visible = False
            End If

            If _oLabelStallNo.Text = "" Or _oLabelStallNo.Text = Nothing Then
                StallNo.Visible = False
            End If

            If _oLabelDateEstablish.Text = "" Or _oLabelDateEstablish.Text = Nothing Then
                DateEstablished.visible = False
            End If

            If _oLabelOwnership.Text = "" Or _oLabelOwnership.Text = Nothing Then
                OwnershipType.Visible = False
            End If

            If _oLabelCommAdd.Text = "" Or _oLabelCommAdd.Text = Nothing Then
                BusinessAddress.Visible = False
            End If

            If _oLabelDistrict.Text = "" Or _oLabelDistrict.Text = Nothing Then
                District.Visible = False
            End If

            If _oLabelBarangay.Text = "" Or _oLabelBarangay.Text = Nothing Then
                Barangay.Visible = False
            End If

            If _oLabelStreet.Text = "" Or _oLabelStreet.Text = Nothing Then
                Street.Visible = False
            End If

            If _oLabelMale.Text = "" Or _oLabelMale.Text = Nothing Then
                Male.Visible = False
            End If

            If _oLabelFemale.Text = "" Or _oLabelFemale.Text = Nothing Then
                Female.Visible = False
            End If

            If _oLabelLGURes.Text = "" Or _oLabelLGURes.Text = Nothing Then
                Resident.Visible = False
            End If

            If _oLabelLessorName.Text = "" Or _oLabelLessorName.Text = Nothing Then
                LessorFullName.Visible = False
            End If

            If _oLabelLessorAddress.Text = "" Or _oLabelLessorAddress.Text = Nothing Then
                LessorAddress.Visible = False
            End If

            If _oLabelAdmin.Text = "" Or _oLabelAdmin.Text = Nothing Then
                Administrator.Visible = False
            End If

            If _oLabelDateRented.Text = "" Or _oLabelDateRented.Text = Nothing Then
                DateRented.Visible = False
            End If

            If _oLabelLessorTelNo.Text = "" Or _oLabelLessorTelNo.Text = Nothing Then
                LessorTelNo.Visible = False
            End If

            If _oLabelRentPerMonth.Text = "" Or _oLabelRentPerMonth.Text = Nothing Then
                RentPerMonth.Visible = False
            End If

            If _oLabelLessorEmailAdd.Text = "" Or _oLabelLessorEmailAdd.Text = Nothing Then
                EmailAddress.Visible = False
            End If




            If _oLabelTIN.Text = "" Or _oLabelTIN.Text = Nothing Then
                TIN.Visible = False
            End If

            If _oLabelDTI.Text = "" Or _oLabelDTI.Text = Nothing Then
                DTI.Visible = False
            End If

            If _oLabelSEC.Text = "" Or _oLabelSEC.Text = Nothing Then
                SEC.Visible = False
            End If

            If _oLabelSSS.Text = "" Or _oLabelSSS.Text = Nothing Then
                SSS.Visible = False
            End If

            If _oLabelBrgyClearance.Text = "" Or _oLabelBrgyClearance.Text = Nothing Then
                BrgyClearance.Visible = False
            End If

            If _oLabelPEZA.Text = "" Or _oLabelPEZA.Text = Nothing Then
                PEZA.Visible = False
            End If

            If _oLabelARC.Text = "" Or _oLabelARC.Text = Nothing Then
                ARC.Visible = False
            End If

            If _oLabelBldgNo.Text = "" Or _oLabelBldgNo.Text = Nothing Then
                BldgNo.Visible = False
            End If

            If _oLabelCertificate.Text = "" Or _oLabelCertificate.Text = Nothing Then
                CertOccupancy.Visible = False
            End If

            If _oLabelBOI.Text = "" Or _oLabelBOI.Text = Nothing Then
                BOI.Visible = False
            End If

            If _oLabelCDA.Text = "" Or _oLabelCDA.Text = Nothing Then
                CDA.Visible = False
            End If

            If _oLabelCTCReg.Text = "" Or _oLabelCTCReg.Text = Nothing Then
                CTC.Visible = False
            End If

            If _oLabelCTCPlace.Text = "" Or _oLabelCTCPlace.Text = Nothing Then
                CTCPlace.Visible = False
            End If

            If _oLabelPBN.Text = "" Or _oLabelPBN.Text = Nothing Then
                PBN.Visible = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DownloadFile1(sender As Object, e As EventArgs) ' 20180320

        Response.Clear()


        Dim BtnArg As Integer = Integer.Parse(TryCast(sender, LinkButton).CommandArgument)
        Dim id As String = cSessionLoader._pAccountNo
        Dim bytes As Byte()
        Dim fileName As String, contentType As String

        'BPLTIMS

        Dim _nClBPLTIMS As New cDalGlobalConnectionsDefault
        _nClBPLTIMS._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBPLTIMS._pSetupGlobalConnectionsDatabases = "BPLTIMS"
        _nClBPLTIMS._pSubRecordSelectSpecific()

        Dim xServer As String : Dim xDatabase As String : Dim xUser As String : Dim xPass As String

        xServer = _nClBPLTIMS._pDBDataSource 'cGlobalConnections._pSqlCxn_BPLTIMS.DataSource.ToString
        xDatabase = _nClBPLTIMS._pDBInitialCatalog 'cGlobalConnections._pSqlCxn_BPLTIMS.Database.ToString
        xUser = _nClBPLTIMS._pDBUserID '"juan.dela.cruz"
        xPass = _nClBPLTIMS._pDBUserKey '"#P@ssw0rd#"

        Dim constr As String = "Data Source=" & xServer & ";Initial Catalog=" & xDatabase & ";User ID=" & xUser & "; PASSWORD=" & xPass & ";"
        Using con As New SqlConnection(constr)

            Select Case BtnArg
                Case 1

                    Using cmd As New SqlCommand()
                        cmd.CommandText = "SELECT  TOP 1 ID,PIC_OWNER,O_FileType,O_FileName FROM BPLTAS_PICTURES WHERE ACCTNO = @id AND ISNULL(O_FileType,'')<>'' ORDER BY XCODE DESC "
                        cmd.Parameters.AddWithValue("@Id", id)
                        cmd.Connection = con
                        con.Open()
                        Using sdr As SqlDataReader = cmd.ExecuteReader()
                            sdr.Read()
                            bytes = DirectCast(sdr("PIC_OWNER"), Byte())
                            contentType = sdr("O_FileType").ToString()
                            fileName = id & "O " & sdr("O_FileName").ToString()
                            'id & " Owner Picture" 'sdr("O_FileType").ToString()
                        End Using
                        con.Close()
                    End Using

                Case 2

                    Using cmd As New SqlCommand()
                        cmd.CommandText = " SELECT  TOP 1 ID,PICTURE,E_FileType,E_FileName  FROM BPLTAS_PICTURES WHERE ACCTNO =  @id AND ISNULL(E_FileType,'')<>'' ORDER BY XCODE DESC "
                        cmd.Parameters.AddWithValue("@Id", id)
                        cmd.Connection = con
                        con.Open()
                        Using sdr As SqlDataReader = cmd.ExecuteReader()
                            sdr.Read()
                            bytes = DirectCast(sdr("PICTURE"), Byte())
                            contentType = sdr("E_FileType").ToString()
                            fileName = id & "E " & sdr("E_FileName").ToString()
                            'sdr("O_FileType").ToString()
                        End Using
                        con.Close()
                    End Using

                Case 3

                    Using cmd As New SqlCommand()
                        cmd.CommandText = "SELECT  TOP 1 ID,PIC_LOCATION,M_FileType,M_FileName FROM BPLTAS_PICTURES WHERE ACCTNO =  @id AND ISNULL(M_FileType,'')<>'' ORDER BY XCODE DESC "
                        cmd.Parameters.AddWithValue("@Id", id)
                        cmd.Connection = con
                        con.Open()
                        Using sdr As SqlDataReader = cmd.ExecuteReader()
                            sdr.Read()
                            bytes = DirectCast(sdr("PIC_LOCATION"), Byte())
                            contentType = sdr("M_FileType").ToString()
                            fileName = id & "M " & sdr("M_FileName").ToString()
                            'sdr("O_FileType").ToString()
                        End Using
                        con.Close()
                    End Using

            End Select


        End Using
        Response.Clear()
        Response.Buffer = True
        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = contentType
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName)
        Response.BinaryWrite(bytes)
        Response.Flush()
        Response.End()

    End Sub

    Private Function _SendEmailNotification(_nResponse As String, _nComment As String) As Boolean

        Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim PageName As String = System.IO.Path.GetFileName(PagePath)

        Dim loginURL As String = FullUrl.Replace(PageName, "Register.aspx")
        Dim Sent As Boolean
        Dim Subject As String = "BUSINESS PERMIT APPLICATION STATUS"
        Dim Body As String

        Select Case _nResponse

            Case "Reviewed/ For Assessment Billing"

                Body = _
                    "<br> Sir/Ma`am: <br> <br>" & _
                    "Your Business account for BIN " & cSessionLoader._pAccountNo & " is now approved and ready for billing and payment. " & _
                    "Please to pay your bill online please do the following: <br> <br>" & _
                    " 1. Login to Web Service Portal <br>" & _
                    " 2. Once Logged in, Goto Accounts and find the BIN that you want to process for payment.<br>" & _
                    " 3. Click Payment link on the right most column. Once clicked, Billing TOP will display. <br>" & _
                    " 4. Click Proceed to Payment. <br>" & _
                    " 5. Select the desired payment channel then click the (Pay Now) button. <br> <br> " & _
                    " <a href='" & loginURL & "'" & " target='_blank' style='text-decoration:none;font-weight:bold'>Login Here</a> <br>" & _
                    "You can pay online by providing your payment details or visit the License Treasury Office. <br> <br>" & _
                     IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                    "Thank you. <br>"

            Case "Lacks Mandatory Requirements"

                Body = _
                    "<br> Sir/Ma`am: <br> <br>" & _
                    "Your Business account for Account Number " & cSessionLoader._pAccountNo & " is now pending until you submit all mandatory requirements. " & _
                     IIf(_nComment <> "", "<br> <br> BPLO COMMENT: <br> <br> " & _nComment & "<br>", "<br>") & _
                    "Thank you. <br>"

            Case "VERIFIED-BUSINESS-PERMIT" ' @Added 20220114 | LOUIE
                Body = _
                    "<br> Sir/Ma`am: <br> <br>" & _
                    "Your Business account for Account Number " & cSessionLoader._pAccountNo & " has been verified and approved by Business Permit and Licensing Office.  " & _
                    "Please wait for further notification on how you can proceed with your business permit transaction." & _
                    "<br> <br> Thank you. <br>"

        End Select


        Try
            cDalNewSendEmail.SendEmail(cLoader_BPLTIMS._pEMAILADDR, Subject, Body, Sent)
            Return Sent
        Catch ex As Exception
            Return False
        End Try


    End Function

    Private Sub _BindGridviewBusinessLine(_nGridview As GridView)
        Try
            Dim _nSuccessfull As Boolean
            Dim _nErrMsg As String = Nothing

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

                ._pCondition = " WHERE BL.ACCTNO =  ''" & cSessionLoader._pAccountNo & "'' COLLATE DATABASE_DEFAULT and foryear = ''" & cSessionLoader._pCurrentYear & "''"

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

    Public Function _mSubSaveGatheredInfo() As Boolean 'Added 20170629
        _mSubSaveGatheredInfo = True
        Try
            Dim _nClass As New cDalBusinessLine
            Dim timeFormat As String = "yyyy-MM-dd"

            Dim STATUS As String = "N"
            cLoader_BPLTIMS._pSTATCODE = STATUS

            With _nClass
                ._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
                ._pAccount = cSessionLoader._pAccountNo
                '._pDate_Estab = Convert.ToDateTime(cPageSession_BPLTASnew._pDate_Estab).ToString(timeFormat)
                ._pBusCode = cLoader_BPLTIMS._pBUS_CODE
                ._pBusYear = cLoader_BPLTIMS._pFORYEAR


                ._pBCHOICE_Row = cPageSession_BusinessLine._pBCODE_Option_RowNo
                ._pMCHOICE_Row = cPageSession_BusinessLine._pMCODE_Option_RowNo
                ._pGCHOICE_Row = cPageSession_BusinessLine._pGCODE_Option_RowNo
                ._pSCHOICE_Row = cPageSession_BusinessLine._pSCODE_Option_RowNo
                ._pFCHOICE_Row = cPageSession_BusinessLine._pFCODE_Option_RowNo

                '--------------------------------------------------------------------
                '._pBCHOICE1 = cPageSession_BusinessLine._pBCODE_Option_TaxCode
                ._pBRANGE_QTY = cPageSession_BusinessLine._pBCODE_GRASKHDG_Val
                ._pBQTY1 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val1
                ._pBQTY2 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val2
                ._pBQTY3 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val3
                ._pBQTY4 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val4
                ._pBQTY5 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val5
                ._pBQTY6 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val6
                ._pBQTY7 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val7
                ._pBQTY8 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val8
                ._pBQTY9 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val9
                ._pBQTY10 = cPageSession_BusinessLine._pBCODE_GRASKQTY_Val10

                If ._pBQTY1 <> 0 Or ._pBQTY2 <> 0 Or ._pBQTY3 <> 0 Or ._pBQTY4 <> 0 Or ._pBQTY5 <> 0 _
                    Or ._pBQTY6 <> 0 Or ._pBQTY7 <> 0 Or ._pBQTY8 <> 0 Or ._pBQTY9 <> 0 Or ._pBQTY10 <> 0 Then
                    ._pBQTY = 1
                Else
                    ._pBQTY = 0
                End If

                ._pMRANGE_QTY = cPageSession_BusinessLine._pMCODE_GRASKHDG_Val
                ._pMQTY1 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val1
                ._pMQTY2 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val2
                ._pMQTY3 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val3
                ._pMQTY4 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val4
                ._pMQTY5 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val5
                ._pMQTY6 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val6
                ._pMQTY7 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val7
                ._pMQTY8 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val8
                ._pMQTY9 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val9
                ._pMQTY10 = cPageSession_BusinessLine._pMCODE_GRASKQTY_Val10


                If ._pMQTY1 <> 0 Or ._pMQTY2 <> 0 Or ._pMQTY3 <> 0 Or ._pMQTY4 <> 0 Or ._pMQTY5 <> 0 _
                    Or ._pMQTY6 <> 0 Or ._pMQTY7 <> 0 Or ._pMQTY8 <> 0 Or ._pMQTY9 <> 0 Or ._pMQTY10 <> 0 Then
                    ._pMQTY = 1
                Else
                    ._pMQTY = 0
                End If


                ._pGRANGE_QTY = cPageSession_BusinessLine._pGCODE_GRASKHDG_Val
                ._pGQTY1 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val1
                ._pGQTY2 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val2
                ._pGQTY3 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val3
                ._pGQTY4 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val4
                ._pGQTY5 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val5
                ._pGQTY6 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val6
                ._pGQTY7 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val7
                ._pGQTY8 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val8
                ._pGQTY9 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val9
                ._pGQTY10 = cPageSession_BusinessLine._pGCODE_GRASKQTY_Val10

                If ._pGQTY1 <> 0 Or ._pGQTY2 <> 0 Or ._pGQTY3 <> 0 Or ._pGQTY4 <> 0 Or ._pGQTY5 <> 0 _
                    Or ._pGQTY6 <> 0 Or ._pGQTY7 <> 0 Or ._pGQTY8 <> 0 Or ._pGQTY9 <> 0 Or ._pGQTY10 <> 0 Then
                    ._pGQTY = 1
                Else
                    ._pGQTY = 0
                End If

                ._pSRANGE_QTY = cPageSession_BusinessLine._pSCODE_GRASKHDG_Val
                ._pSQTY1 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val1
                ._pSQTY2 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val2
                ._pSQTY3 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val3
                ._pSQTY4 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val4
                ._pSQTY5 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val5
                ._pSQTY6 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val6
                ._pSQTY7 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val7
                ._pSQTY8 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val8
                ._pSQTY9 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val9
                ._pSQTY10 = cPageSession_BusinessLine._pSCODE_GRASKQTY_Val10

                If ._pSQTY1 <> 0 Or ._pSQTY2 <> 0 Or ._pSQTY3 <> 0 Or ._pSQTY4 <> 0 Or ._pSQTY5 <> 0 _
                    Or ._pSQTY6 <> 0 Or ._pSQTY7 <> 0 Or ._pSQTY8 <> 0 Or ._pSQTY9 <> 0 Or ._pSQTY10 <> 0 Then
                    ._pSQTY = 1
                Else
                    ._pSQTY = 0
                End If

                ._pFRANGE_QTY = cPageSession_BusinessLine._pFCODE_GRASKHDG_Val
                ._pFQTY1 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val1
                ._pFQTY2 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val2
                ._pFQTY3 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val3
                ._pFQTY4 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val4
                ._pFQTY5 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val5
                ._pFQTY6 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val6
                ._pFQTY7 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val7
                ._pFQTY8 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val8
                ._pFQTY9 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val9
                ._pFQTY10 = cPageSession_BusinessLine._pFCODE_GRASKQTY_Val10

                If ._pFQTY1 <> 0 Or ._pFQTY2 <> 0 Or ._pFQTY3 <> 0 Or ._pFQTY4 <> 0 Or ._pFQTY5 <> 0 _
                    Or ._pFQTY6 <> 0 Or ._pFQTY7 <> 0 Or ._pFQTY8 <> 0 Or ._pFQTY9 <> 0 Or ._pFQTY10 <> 0 Then
                    ._pFQTY = 1
                Else
                    ._pFQTY = 0
                End If

                ._pBUSTAX = 0
                ._pMAYORS = 0
                ._pGARBAGE = 0
                ._pSANITARY = 0
                ._pFIRE = 0
                ._pGarbage_O = 0
                ._pSanitary_O = 0
                ._pFire_O = 0
                ._pNewsw = "0"

                ''''--------------------------------------------
                ._pELECfee = cPageSession_BusinessLine._pELECCODE_FEE
                ._pMECHfee = cPageSession_BusinessLine._pMECHCODE_FEE
                ._pBLDGfee = cPageSession_BusinessLine._pBLDGCODE_FEE
                ._pSIGNfee = cPageSession_BusinessLine._pSIGNCODE_FEE
                ._pEPOfee = cPageSession_BusinessLine._pEPOCODE_FEE
                ._pEIFfee = cPageSession_BusinessLine._pEIFCODE_FEE
                ._pPLATfee = cPageSession_BusinessLine._pPLATECODE_FEE
                ''''--------------------------------------------

                '_FnRemoveBusExtn()
                '_FnInsertBusExtn()
                _mSubUpdateAIF()


                ._pSubSaveGatheredInfo()    '@  Added 20170630

                ._mSubCheckChoiceValue()    '@  Added 20170630          
                Dim _nDataTable As New DataTable
                _nDataTable = _nClass._pDataTable

                'Select Case True
                '    Case cPageSession_BusinessLine._pBCHOICE_HasValue
                If _nClass._pBCHOICE1 = Nothing Then
                    ._pCHOICE_Col = "BCHOICE1"
                    ._pSaveSelectedOption_BCHOICE()
                Else
                    If _nClass._pBCHOICE2 = Nothing Then
                        ._pCHOICE_Col = "BCHOICE2"
                        ._pSaveSelectedOption_BCHOICE()
                    Else
                        If _nClass._pBCHOICE3 = Nothing Then
                            ._pCHOICE_Col = "BCHOICE3"
                            ._pSaveSelectedOption_BCHOICE()
                        Else
                            ._pCHOICE_Col = "BCHOICE4"
                            ._pSaveSelectedOption_BCHOICE()
                        End If
                    End If
                End If
                ' Case cPageSession_BusinessLine._pMCHOICE_HasValue
                If _nClass._pMCHOICE1 = Nothing Then
                    ._pCHOICE_Col = "MCHOICE1"
                    ._pSaveSelectedOption_MCHOICE()
                Else
                    If _nClass._pMCHOICE2 = Nothing Then
                        ._pCHOICE_Col = "MCHOICE2"
                        ._pSaveSelectedOption_MCHOICE()
                    Else
                        If _nClass._pMCHOICE3 = Nothing Then
                            ._pCHOICE_Col = "MCHOICE3"
                            ._pSaveSelectedOption_MCHOICE()
                        Else
                            ._pCHOICE_Col = "MCHOICE4"
                            ._pSaveSelectedOption_MCHOICE()
                        End If
                    End If
                End If
                'Case cPageSession_BusinessLine._pGCHOICE_HasValue
                If _nClass._pGCHOICE1 = Nothing Then
                    ._pCHOICE_Col = "GCHOICE1"
                    ._pSaveSelectedOption_GCHOICE()
                Else
                    If _nClass._pGCHOICE2 = Nothing Then
                        ._pCHOICE_Col = "GCHOICE2"
                        ._pSaveSelectedOption_GCHOICE()
                    Else
                        If _nClass._pGCHOICE3 = Nothing Then
                            ._pCHOICE_Col = "GCHOICE3"
                            ._pSaveSelectedOption_GCHOICE()
                        Else
                            ._pCHOICE_Col = "GCHOICE4"
                            ._pSaveSelectedOption_GCHOICE()
                        End If
                    End If
                End If
                'Case cPageSession_BusinessLine._pSCHOICE_HasValue
                If _nClass._pSCHOICE1 = Nothing Then
                    ._pCHOICE_Col = "SCHOICE1"
                    ._pSaveSelectedOption_SCHOICE()
                Else
                    If _nClass._pSCHOICE2 = Nothing Then
                        ._pCHOICE_Col = "SCHOICE2"
                        ._pSaveSelectedOption_SCHOICE()
                    Else
                        If _nClass._pSCHOICE3 = Nothing Then
                            ._pCHOICE_Col = "SCHOICE3"
                            ._pSaveSelectedOption_SCHOICE()
                        Else
                            ._pCHOICE_Col = "SCHOICE4"
                            ._pSaveSelectedOption_SCHOICE()
                        End If
                    End If
                End If
                'Case cPageSession_BusinessLine._pFCHOICE_HasValue
                If _nClass._pFCHOICE1 = Nothing Then
                    ._pCHOICE_Col = "FCHOICE1"
                    ._pSaveSelectedOption_FCHOICE()
                Else
                    If _nClass._pFCHOICE2 = Nothing Then
                        ._pCHOICE_Col = "FCHOICE2"
                        ._pSaveSelectedOption_FCHOICE()
                    Else
                        If _nClass._pFCHOICE3 = Nothing Then
                            ._pCHOICE_Col = "FCHOICE3"
                            ._pSaveSelectedOption_FCHOICE()
                        Else
                            ._pCHOICE_Col = "FCHOICE4"
                            ._pSaveSelectedOption_FCHOICE()
                        End If
                    End If
                End If

                _oBusinessLineTextArea.Value = ""

                'Get_Added_Busline()
                'snackbar("green", "Business Line added successfully")


                'End Select


                If IfRecordExist("BUSEXTN", "WHERE Acctno = ''" & ._pAccount & "'' AND ForYear = ''" & cLoader_BPLTIMS._pFORYEAR & "'' AND STATCODE = ''" & STATUS & "''") = True Then
                    _FnRemoveBusExtn()
                    _FnInsertBusExtn()
                End If

                'Saving AIF FEES
                ' _mFnCallClssAIF_PROCESS(._pAccount, STATUS, cLoader_BPLTIMS._pDATE_ESTA, cLoader_BPLTIMS._pFORYEAR)
                ''SAVING BUSLINE FEES
                _mFnCallClssLINE_PROCESS(._pAccount, STATUS, cLoader_BPLTIMS._pDATE_ESTA, cLoader_BPLTIMS._pFORYEAR, _
                                             STATUS, ._pBusCode, cPageSession_BusinessLine._pBCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pMCODE_GRADTABL_TaxCode, _
                                             cPageSession_BusinessLine._pGCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pSCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pFCODE_GRADTABL_TaxCode, cPageSession_BusinessLine._pBCODE_GRADTABL_EffMonth, _
                                            cPageSession_BusinessLine._pMCODE_GRADTABL_EffMonth, cPageSession_BusinessLine._pGCODE_GRADTABL_EffMonth, cPageSession_BusinessLine._pSCODE_GRADTABL_EffMonth, cPageSession_BusinessLine._pFCODE_GRADTABL_EffMonth, _
                                            cPageSession_BusinessLine._pBCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pMCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pGCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pSCODE_GRADTABL_EffYear, cPageSession_BusinessLine._pFCODE_GRADTABL_EffYear)

                ''SAVING AIF PER LINE (False) 
                _mFnCallClssAIF_LINE_PROCESS(._pAccount, ._pAccount, cLoader_BPLTIMS._pFORYEAR, _
                                         ._pBusCode)


                If _FnUpdateBussinessLine(cLoader_BPLTIMS._pBUS_CODE, cLoader_BPLTIMS._pFORYEAR, cLoader_BPLTIMS._pAREA, cLoader_BPLTIMS._pCAPITAL) = True Then

                    'Messege "Business Line successfully updated."

                End If
                _BindGridviewBusinessLine(_oGridViewBusLine)


                cPageSession_BusinessLine._pELECCODE_processed = False
                cPageSession_BusinessLine._pMECHCODE_processed = False
                cPageSession_BusinessLine._pBLDGCODE_processed = False
                cPageSession_BusinessLine._pSIGNCODE_processed = False
                cPageSession_BusinessLine._pEPOCODE_processed = False
                cPageSession_BusinessLine._pEIFCODE_processed = False
                cPageSession_BusinessLine._pPLATECODE_processed = False
                cPageSession_BusinessLine._pBCODE_processed = False
                cPageSession_BusinessLine._pMCODE_processed = False
                cPageSession_BusinessLine._pGCODE_processed = False
                cPageSession_BusinessLine._pSCODE_processed = False
                cPageSession_BusinessLine._pFCODE_processed = False

                If _FnIsLineProcessComplete() = True Then
                    _ImgBtn_oButtonNotify.Disabled = False
                Else
                    _ImgBtn_oButtonNotify.Disabled = True
                End If

                _GenerateTOP()

                '     _mSubPopulateYearDropDown()
                If cLoader_BPLTIMS._pIsProcessAll = True Then
                    _UpdateProcessAllIndicator()
                    _InitProcessAllLineComputation()
                End If

        

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


                Console.WriteLine("BPLTAS_SERVER = " & _nClBPLTIMS._pDBDataSource)
                Console.WriteLine("BPLTAS_xDataBase = " & _nClBPLTIMS._pDBInitialCatalog)
                Console.WriteLine("BPLTAS_xUID = " & _nClBPLTIMS._pDBUserID)
                Console.WriteLine("BPLTAS_xPW = " & _nClBPLTIMS._pDBUserKey)

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

                Debug.Print("BPLTAS_SERVER = " & _nClBPLTIMS._pDBDataSource)
                Debug.Print("BPLTAS_xDataBase = " & _nClBPLTIMS._pDBInitialCatalog)
                Debug.Print("BPLTAS_xUID = " & _nClBPLTIMS._pDBUserID)
                Debug.Print("BPLTAS_xPW = " & _nClBPLTIMS._pDBUserKey)
                Debug.Print("LIVE_BPLTAS_SERVER = " & _nClBP._pDBDataSource)
                Debug.Print("LIVE_BPLTAS_xDataBase = " & _nClBP._pDBInitialCatalog)
                Debug.Print("LIVE_BPLTAS_xUID = " & _nClBP._pDBUserID)
                Debug.Print("LIVE_BPLTAS_xPW = " & _nClBP._pDBUserKey)
                Debug.Print("BPLTAS_xAcctno = " & xAcctno)
                Debug.Print("BPLTAS_xStatcodeMain = " & xStatcodeMain)
                Debug.Print("BPLTAS_xDate_Esta = " & xDate_Esta)
                Debug.Print("BPLTAS_xForyear = " & BPLTAS_xForyear)
                Debug.Print("BPLTAS_xStatcodeLine = " & xStatcodeLine)
                Debug.Print("BPLTAS_xBuscode = " & xBuscode)
                Debug.Print("BPLTAS_xBCODE = " & IIf(xBCODE = Nothing, "", xBCODE))
                Debug.Print("BPLTAS_xMCODE = " & IIf(xMCODE = Nothing, "", xMCODE))
                Debug.Print("BPLTAS_xGCODE = " & IIf(xGCODE = Nothing, "", xGCODE))
                Debug.Print("BPLTAS_xSCODE = " & IIf(xSCODE = Nothing, "", xSCODE))
                Debug.Print("BPLTAS_xFCODE = " & IIf(xFCODE = Nothing, "", xFCODE))
                Debug.Print("BPLTAS_xEFFMO_B = " & IIf(xEFFMO_B = Nothing, "", xEFFMO_B))
                Debug.Print("BPLTAS_xEFFMO_M = " & IIf(xEFFMO_M = Nothing, "", xEFFMO_M))
                Debug.Print("BPLTAS_xEFFMO_G = " & IIf(xEFFMO_G = Nothing, "", xEFFMO_G))
                Debug.Print("BPLTAS_xEFFMO_S = " & IIf(xEFFMO_S = Nothing, "", xEFFMO_S))
                Debug.Print("BPLTAS_xEFFMO_F = " & IIf(xEFFMO_F = Nothing, "", xEFFMO_F))
                Debug.Print("BPLTAS_xEFFYR_B = " & IIf(xEFFYR_B = Nothing, "", xEFFYR_B))
                Debug.Print("BPLTAS_xEFFYR_M = " & IIf(xEFFYR_M = Nothing, "", xEFFYR_M))
                Debug.Print("BPLTAS_xEFFYR_G = " & IIf(xEFFYR_G = Nothing, "", xEFFYR_G))
                Debug.Print("BPLTAS_xEFFYR_S = " & IIf(xEFFYR_S = Nothing, "", xEFFYR_S))
                Debug.Print("BPLTAS_xEFFYR_F = " & IIf(xEFFYR_F = Nothing, "", xEFFYR_F))
                Debug.Print("pSub_PROCESS_LINE()")


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


End Class
