Imports System.Data.SqlClient

Public Class BusApplicationSummary
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'S1_Ownershiptype.Value = cLoaderNewBusinessApplication._pOwnershipType
            'S1_IsRented.Value = cLoaderNewBusinessApplication._pRent

            'S2_DateRented.Value = cLoaderNewBusinessApplication._pLessorDateRented
            'S2_RentPerMonth.Value = cLoaderNewBusinessApplication._pLessorRatePerMonth
            'S2_FName.Value = cLoaderNewBusinessApplication._pLessorFirstName
            'S2_LName.Value = cLoaderNewBusinessApplication._pLessorLastName
            'S2_Brgy.Value = cLoaderNewBusinessApplication._pLessorBarangay
            'S2_Street.Value = cLoaderNewBusinessApplication._pLessorStreet
            'S2_Address.Value = cLoaderNewBusinessApplication._pLessorAddress
            'S2_TelNo.Value = cLoaderNewBusinessApplication._pLessorTelNo
            'S2_Email.Value = cLoaderNewBusinessApplication._pLessorEmail
            'S2_Administrator.Value = cLoaderNewBusinessApplication._pBuildingAdministrator

            'S5_CDA.Value = cLoaderNewBusinessApplication._pGovCDANo
            'S5_CDA2.Value = cLoaderNewBusinessApplication._pGovRegDateCDA
            'S5_DTI.Value = cLoaderNewBusinessApplication._pGovDTINo
            'S5_DTI2.Value = cLoaderNewBusinessApplication._pGovRegDateDTI
            'S5_SEC.Value = cLoaderNewBusinessApplication._pGovSECNo
            'S5_SEC2.Value = cLoaderNewBusinessApplication._pGovRegDateSEC
            'S5_TIN.Value = cLoaderNewBusinessApplication._pGovTINNo
            'S5_TIN2.Value = cLoaderNewBusinessApplication._pGovRegDateTIN
            'S5_SSS.Value = cLoaderNewBusinessApplication._pGovSSS
            'S5_SSS2.Value = cLoaderNewBusinessApplication._pGovRegDateSSS
            'S5_Brgy.Value = cLoaderNewBusinessApplication._pGovBrgyClearance
            'S5_Brgy2.Value = cLoaderNewBusinessApplication._pGovRegDateBrgyClearance
            'S5_Brgy.Value = cLoaderNewBusinessApplication._pGovBrgyClearance
            'S5_Brgy2.Value = cLoaderNewBusinessApplication._pGovRegDateBrgyClearance
            'S5_BIR.Value = cLoaderNewBusinessApplication._pGovBIR
            'S5_BIR2.Value = cLoaderNewBusinessApplication._pGovRegDateBIR

            'S6_DateEstablished.Value = cLoaderNewBusinessApplication._pBusDateEsta
            'S6_Branch.Value = cLoaderNewBusinessApplication._pBusBranch
            'S6_TradeName.Value = cLoaderNewBusinessApplication._pBusTradeName
            'S6_NoMale.Value = cLoaderNewBusinessApplication._pBusMale
            'S6_NoFemale.Value = cLoaderNewBusinessApplication._pBusFemale
            'S6_NoLGU.Value = cLoaderNewBusinessApplication._pBusResident

            'S7_DistCode.Value = Left(cLoaderNewBusinessApplication._pBusBrgy, 4)
            'S7_Brgy_code.Value = Right(cLoaderNewBusinessApplication._pBusBrgy, 4)
            'S7_Street_code.Value = cLoaderNewBusinessApplication._pBusStrt
            'S7_Address.Value = cLoaderNewBusinessApplication._pBusAddress
            'S7_Street.Value = _mSubRetrieve("STREET")
            'S7_Brgy.Value = _mSubRetrieve("BARANGAY")

            'S8_Lname.Value = cLoaderNewBusinessApplication._pOwnerLName
            'S8_Fname.Value = cLoaderNewBusinessApplication._pOwnerFName
            'S8_Mname.Value = cLoaderNewBusinessApplication._pOwnerMName
            'S8_Suffix.Value = cLoaderNewBusinessApplication._pOwnerSuffix
            'S8_Gender.Value = cLoaderNewBusinessApplication._pOwnerGender
            'S8_Citizenship.Value = cLoaderNewBusinessApplication._pOwnerCitizenship
            'S8_Address.Value = cLoaderNewBusinessApplication._pOwnerAddress
            'S8_TelNo.Value = cLoaderNewBusinessApplication._pOwnerTelNo
            'S8_AlternateEmail.Value = cLoaderNewBusinessApplication._pOwnerAltEmail
            If Session("OwnerShipType") = "Cooperative" Then
                Slide_End_frmDTI.Attributes.Add("style", "display:none;")
                Slide_End_frmSEC.Attributes.Add("style", "display:none;")
            End If
            If Session("OwnerShipType") = "Single" Then
                Slide_End_frmCDA.Attributes.Add("style", "display:none;")
                Slide_End_frmSEC.Attributes.Add("style", "display:none;")
            End If
            If Session("OwnerShipType") = "Corporation" Then
                Slide_End_frmCDA.Attributes.Add("style", "display:none;")
                Slide_End_frmDTI.Attributes.Add("style", "display:none;")
            End If

            Dim _nOwnDesc As String
            _nOwnDesc = _mSubRetrieve("OWNERSHIPTYPE")
            S1_Ownershiptype.Value = _nOwnDesc 'Session("OwnershipType")
            S1_IsRented.Value = IIf(Session("Rent") = "True", "Yes", "No")

            S2_DateRented.Value = Session("LessorDateRented")
            S2_RentPerMonth.Value = Session("LessorRatePerMonth")
            S2_FName.Value = Session("LessorFirstName") 'cLoaderNewBusinessApplication._pLessorFirstName
            S2_LName.Value = Session("LessorLastName") 'cLoaderNewBusinessApplication._pLessorLastName
            S2_Brgy.Value = Session("LessorBarangay") 'cLoaderNewBusinessApplication._pLessorBarangay
            S2_Street.Value = Session("LessorStreet") 'cLoaderNewBusinessApplication._pLessorStreet
            S2_Address.Value = Session("LessorAddress") 'cLoaderNewBusinessApplication._pLessorAddress
            S2_TelNo.Value = Session("LessorTelNo") 'cLoaderNewBusinessApplication._pLessorTelNo
            S2_Email.Value = Session("LessorEmail") 'cLoaderNewBusinessApplication._pLessorEmail
            S2_Administrator.Value = Session("BuildingAdministrator") 'cLoaderNewBusinessApplication._pBuildingAdministrator

            S5_CDA.Value = Session("GovCDANo") 'cLoaderNewBusinessApplication._pGovCDANo
            S5_CDA2.Value = Session("GovRegDateCDA") 'cLoaderNewBusinessApplication._pGovRegDateCDA
            S5_DTI.Value = Session("GovDTINo") 'cLoaderNewBusinessApplication._pGovDTINo
            S5_DTI2.Value = Session("GovRegDateDTI") 'cLoaderNewBusinessApplication._pGovRegDateDTI
            S5_SEC.Value = Session("GovSECNo") 'cLoaderNewBusinessApplication._pGovSECNo
            S5_SEC2.Value = Session("GovRegDateSEC") 'cLoaderNewBusinessApplication._pGovRegDateSEC
            S5_TIN.Value = Session("GovTINNo") 'cLoaderNewBusinessApplication._pGovTINNo
            S5_TIN2.Value = Session("GovRegDateTIN") 'cLoaderNewBusinessApplication._pGovRegDateTIN
            S5_SSS.Value = Session("GovSSS") 'cLoaderNewBusinessApplication._pGovSSS
            S5_SSS2.Value = Session("GovRegDateSSS") 'cLoaderNewBusinessApplication._pGovRegDateSSS
            S5_Brgy.Value = Session("GovBrgyClearance") 'cLoaderNewBusinessApplication._pGovBrgyClearance
            S5_Brgy2.Value = Session("GovRegDateBrgyClearance") 'cLoaderNewBusinessApplication._pGovRegDateBrgyClearance
            S5_BIR.Value = Session("GovBIR") 'cLoaderNewBusinessApplication._pGovBIR
            S5_BIR2.Value = Session("GovRegDateBIR") 'cLoaderNewBusinessApplication._pGovRegDateBIR

            S6_DateEstablished.Value = Session("BusDateEsta") 'cLoaderNewBusinessApplication._pBusDateEsta
            S6_Branch.Value = Session("BusBranch") 'cLoaderNewBusinessApplication._pBusBranch
            S6_TradeName.Value = Session("BusTradeName") 'cLoaderNewBusinessApplication._pBusTradeName
            S6_NoMale.Value = IIf(Session("BusMale") = "", "0", Session("BusMale")) 'cLoaderNewBusinessApplication._pBusMale
            S6_NoFemale.Value = IIf(Session("BusFemale") = "", "0", Session("BusFemale")) 'cLoaderNewBusinessApplication._pBusFemale
            S6_NoLGU.Value = IIf(Session("BusResident") = "", "0", Session("BusResident")) 'cLoaderNewBusinessApplication._pBusResident

            S7_DistCode.Value = Session("BusDist") 'Left(Session("BusBrgy"), 4)
            S7_Brgy_code.Value = Session("BusBrgy")
            S7_Street_code.Value = Session("BusStrt")
            S7_Address.Value = Session("BusAddress")
            S7_Street.Value = _mSubRetrieve("STREET")
            S7_Brgy.Value = _mSubRetrieve("BARANGAY")

            S8_Lname.Value = Session("OwnerLName") 'cLoaderNewBusinessApplication._pOwnerLName
            S8_Fname.Value = Session("OwnerFName") 'cLoaderNewBusinessApplication._pOwnerFName
            S8_Mname.Value = Session("OwnerMName") 'cLoaderNewBusinessApplication._pOwnerMName
            S8_Suffix.Value = Session("OwnerSuffix") 'cLoaderNewBusinessApplication._pOwnerSuffix
            S8_Gender.Value = Session("OwnerGender") 'cLoaderNewBusinessApplication._pOwnerGender
            S8_Citizenship.Value = Session("OwnerCitizenship") 'cLoaderNewBusinessApplication._pOwnerCitizenship
            S8_Address.Value = Session("OwnerAddress") 'cLoaderNewBusinessApplication._pOwnerAddress
            S8_TelNo.Value = Session("OwnerTelNo") 'cLoaderNewBusinessApplication._pOwnerTelNo
            S8_AlternateEmail.Value = Session("OwnerAltEmail") 'cLoaderNewBusinessApplication._pOwnerAltEmail

        Else

            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "Redirect" Then

                If val = "Back" Then
                    If Session("OwnerShipType") = "Corporation" Then
                        Response.Redirect("BusIncorporatorAddInfo.aspx")
                    Else
                        Response.Redirect("BusOwnerInfo.aspx")
                    End If
                End If

            End If

        End If
    End Sub



    Private Function _mSubRetrieve(ByVal AddressCode As String) As String
        Dim _nSqlCmd As New SqlCommand
        Dim _mRdr As SqlDataReader
        Try

            If AddressCode = "STREET" Then
                _nSqlCmd = New SqlCommand("Select STRTDESC from STRTCODE where DISTCODE = '" & S7_DistCode.Value & "' AND BRGYCODE = '" & S7_Brgy_code.Value & "' AND STRTCODE = '" & S7_Street_code.Value & "'", cGlobalConnections._pSqlCxn_BPLTAS)
                _mRdr = _nSqlCmd.ExecuteReader
                _mRdr.Read()
                If _mRdr.HasRows Then
                    Return _mRdr.Item("STRTDESC").ToString
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                Else
                    Return ""
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                End If
            End If

            If AddressCode = "BARANGAY" Then
                _nSqlCmd = New SqlCommand("Select BRGYDESC from BRGYCODE where DISTCODE = '" & S7_DistCode.Value & "' AND BRGYCODE = '" & S7_Brgy_code.Value & "'", cGlobalConnections._pSqlCxn_BPLTAS)
                _mRdr = _nSqlCmd.ExecuteReader
                _mRdr.Read()
                If _mRdr.HasRows Then
                    Return _mRdr.Item("BRGYDESC").ToString
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                Else
                    Return ""
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                End If
            End If

            If AddressCode = "OWNERSHIPTYPE" Then ' Added By Louie 20210702
                _nSqlCmd = New SqlCommand("Select * from OWNCODE where OWNCODE = '" & Session("OwnershipType") & "'", cGlobalConnections._pSqlCxn_BPLTAS)
                _mRdr = _nSqlCmd.ExecuteReader
                _mRdr.Read()
                If _mRdr.HasRows Then
                    Return _mRdr.Item("OWNDESC").ToString
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                Else
                    Return ""
                    _nSqlCmd.Dispose()
                    _mRdr.Dispose()
                End If
            End If


        Catch ex As Exception
            Return ""
        End Try

    End Function

    Protected Sub _oButton_Click(sender As Object, e As EventArgs) Handles Confirm_12.ServerClick

        Dim _nSuccessful As Boolean
        Dim _nErrMsg As String = ""
        Dim _nMsg As String = Nothing

        _PassValuetoClassLoader()
        _SaveInformation(_nSuccessful, _nErrMsg)
        If _nSuccessful = True Then
            ' === SAVE IMAGE ATTACHMENT =================================================================================================
            _mAcquireAttachmentTemp(_nSuccessful, _nErrMsg)

            ' === SAVE IMAGE REQUIREMENTS ===============================================================================================
            _AcquireRequirementSubmittedTemp(_nSuccessful, _nErrMsg)
            '============================================================================================================================

            Session("AccountNumber") = cSessionLoader._pAccountNo
            'Response.Redirect("BPLTIMSBusinessLine.aspx") '@Remarked 20211102 Louie
            Response.Redirect("BPLTIMS_NewBusinessLine.aspx") '@Modified 20211102 Louie

        Else
            ScriptManager.RegisterStartupScript(Me, Page.[GetType](), "alert", "alert('Failed to Save Information:'  + _nErrMsg);", True)
            Exit Sub
        End If
      
    End Sub

End Class