Imports System.Web.Services


Public Class UploadDocs
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal();", True)

                cSessionLoader._pControlNo = _FnAutoGenGUID()
                _mcheckdata()
                _BindRequirements(_oGridViewRequirementsList)

                _CheckCompliance()

                Session("OwnershipType") = ""
                Session("Rent") = ""

                Session("LessorDateRented") = ""
                Session("LessorRatePerMonth") = ""
                Session("LessorFirstName") = ""
                Session("LessorLastName") = ""
                Session("LessorBarangay") = ""
                Session("LessorStreet") = ""
                Session("LessorAddress") = ""
                Session("LessorTelNo") = ""
                Session("LessorEmail") = ""
                Session("BuildingAdministrator") = ""

                Session("GovCDANo") = ""
                Session("GovRegDateCDA") = ""
                Session("GovDTINo") = ""
                Session("GovRegDateDTI") = ""
                Session("GovSECNo") = ""
                Session("GovRegDateSEC") = ""
                Session("GovTINNo") = ""
                Session("GovRegDateTIN") = ""
                Session("GovSSS") = ""
                Session("GovRegDateSSS") = ""
                Session("GovBrgyClearance") = ""
                Session("GovRegDateBrgyClearance") = ""
                Session("GovBIR") = ""
                Session("GovRegDateBIR") = ""

                Session("BusDateEsta") = ""
                Session("BusBranch") = ""
                Session("BusTradeName") = ""
                Session("BusMale") = ""
                Session("BusFemale") = ""
                Session("BusResident") = ""

                Session("BusBrgy") = ""
                Session("BusStrt") = ""
                Session("BusAddress") = ""

                Session("OwnerLName") = ""
                Session("OwnerFName") = ""
                Session("OwnerMName") = ""
                Session("OwnerSuffix") = ""
                Session("OwnerGender") = ""
                Session("OwnerCitizenship") = ""
                Session("OwnerAddress") = ""
                Session("OwnerTelNo") = ""
                Session("OwnerAltEmail") = ""


                cLoader_CBPAuthRep._pguid = cInit_CBPReg._FnGetSession(cSessionUser._pUserID)
                If cLoader_CBPAuthRep._pguid <> Nothing Then
                    If cInit_CBPReg._Fn_CheckIfExist_CBP_AuthRep(cLoader_CBPAuthRep._pguid) = True Then
                        cInit_CBPReg._Get_CBP_BusinessInfo()   '_Get_CBP_BusinessInfo()
                        cLoader_CBPAuthRep._pIsRegCBP = False
                        cLoader_CBPAuthRep._pIsRegOAIMS = True
                        _Init_CBPOAIMSReg()
                    End If
                End If

                'cLoader_CBPAuthRep._pguid = cInit_CBPReg._FnGetSession(cSessionUser._pUserID)
                'If cLoader_CBPAuthRep._pguid <> Nothing Then

                '    If cInit_CBPReg._Fn_CheckIfExist_CBP_AuthRep(cLoader_CBPAuthRep._pguid) = True Then
                '        cInit_CBPReg._Get_CBP_BusinessInfo()   '_Get_CBP_BusinessInfo()
                '        _Init_CBPOAIMSReg()
                '    End If
                'End If
            Else

            End If
        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try


    End Sub

    Public Sub _Init_CBPOAIMSReg()
        Dim strTrigger = Nothing, strTrigger2 = Nothing
        Dim strBody = Nothing, strBody2 = Nothing
        cInit_CBPReg._InitCBP_BussinessInfo(strTrigger, strBody)
        Response.Write("<script>" & strTrigger + strBody & "</script>")
        cInit_CBPReg._InitCBP_AutorizeRep(strTrigger2, strBody2)
        Response.Write("<script>" & strTrigger2 + strBody2 & "</script>")
    End Sub

    Private Sub _CheckCompliance()
        If _FnCheckCompliance() = True Then
            Next_01.Enabled = True
        Else
            Next_01.Enabled = False
        End If
    End Sub

    Protected Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles _
      Next_01.Click
        Try
            If _FnCheckCompliance() = True Then
                Response.Redirect("BusOwnerShipType.aspx")
                Exit Sub
            Else
                snackbar("red", "Please upload mandatory requirements")
            End If

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try

    End Sub
    Public Function _FnCheckCompliance() As Boolean
        _FnCheckCompliance = False
        Try
            Dim _nClass As New cDalCheckCompliance
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS

            'BPLTAS
            Dim _nBPLTAS As New cDalGlobalConnectionsDefault
            _nBPLTAS._pCxn = cGlobalConnections._pSqlCxn_CR
            _nBPLTAS._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nBPLTAS._pSubRecordSelectSpecific()

            Dim _nLiveSvr As String = _nBPLTAS._pDBDataSource
            Dim _nLiveDB As String = _nBPLTAS._pDBInitialCatalog

            Dim _nResult = _nClass._FnCheckCompliance(cSessionLoader._pControlNo, "NEW", _nLiveSvr, _nLiveDB)
            Return _nResult

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Function

    Public Function _FnAutoGenGUID() As String
        _FnAutoGenGUID = Nothing
        Try
            Dim _nClass As New cDalGenerateGUID
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim _nResult = _nClass._FnAutoGenGUID()
            Return _nResult

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Function

    Public Function _FnAutoGenID(ByVal _nModuleID As String, Optional _nRefCode As String = Nothing) As String
        _FnAutoGenID = Nothing
        Try
            Dim _nClass As New cDalAutoGenID
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            Dim _nResult = _nClass._FnAutoGenID(_nModuleID, _nRefCode)
            Return _nResult

        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Function


    <WebMethod()> _
    Protected Function _FnLoadImage() As String '@ Added 20170914  - Louie
        _FnLoadImage = Nothing
        Try
            '----------------------------------


            _FnLoadImage = "~/CSS_JS_IMG/img/Asterisk.png" '"/images/gif/processing.gif"
            '----------------------------------
        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try
    End Function

    Protected Function showImageIfCalled(val As String) As Boolean '@ Added 20170914  - Louie
        If val = "COMPLIANCE" Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub _oButton_Click(sender As Object, e As EventArgs) Handles _
 _oButtonUploadImages.Click
        Try

            ' === SAVE IMAGE REQUIREMENTS ===============================================================================================
            _UploadAttachment()
            _UploadRequirements(sender, e)
            _CheckCompliance()
            '============================================================================================================================

        Catch ex As Exception
            snackbar("red", "Error Occured: " & ex.Message)
        End Try

    End Sub

End Class