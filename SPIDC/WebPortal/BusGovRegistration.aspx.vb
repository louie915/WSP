Public Class BusGovRegistration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            HdnOwnershipType.Value = Session("OwnerShipType")
            If Session("OwnerShipType") = "Cooperative" Or Session("OwnerShipType") = "C" Then
                frmDTI.Attributes.Add("style", "display:none;")
                _oLblDTINo.Attributes.Add("style", "display:none;")
                _oLblAstDTI.Attributes.Add("style", "display:none;")
                _oLblDTINo2.Attributes.Add("style", "display:none;")
                Slide_05_DTI.Attributes.Add("style", "display:none;")
                Slide_05_DTI2.Attributes.Add("style", "display:none;")
                Slide_05_DTI.Value = ""
                Slide_05_DTI2.Value = ""

                frmSEC.Attributes.Add("style", "display:none;")
                _oLblSECNo.Attributes.Add("style", "display:none;")
                _oLblAstSEC.Attributes.Add("style", "display:none;")
                _oLblSECNo2.Attributes.Add("style", "display:none;")
                Slide_05_SEC.Attributes.Add("style", "display:none;")
                Slide_05_SEC2.Attributes.Add("style", "display:none;")
                Slide_05_SEC.Value = ""
                Slide_05_SEC2.Value = ""
            ElseIf Session("OwnerShipType") = "Single" Or Session("OwnerShipType") = "S" Then
                frmCDA.Attributes.Add("style", "display:none;")
                _oLblCDANo.Attributes.Add("style", "display:none;")
                _oLblAstCDA.Attributes.Add("style", "display:none;")
                _oLblCDANo2.Attributes.Add("style", "display:none;")
                Slide_05_CDA.Attributes.Add("style", "display:none;")
                Slide_05_CDA2.Attributes.Add("style", "display:none;")
                Slide_05_CDA.Value = ""
                Slide_05_CDA2.Value = ""

                frmSEC.Attributes.Add("style", "display:none;")
                _oLblSECNo.Attributes.Add("style", "display:none;")
                _oLblAstSEC.Attributes.Add("style", "display:none;")
                _oLblSECNo2.Attributes.Add("style", "display:none;")
                Slide_05_SEC.Attributes.Add("style", "display:none;")
                Slide_05_SEC2.Attributes.Add("style", "display:none;")
                Slide_05_SEC.Value = ""
                Slide_05_SEC2.Value = ""
            ElseIf Session("OwnerShipType") = "Corporation" Or Session("OwnerShipType") = "C" Then
                frmCDA.Attributes.Add("style", "display:none;")
                _oLblCDANo.Attributes.Add("style", "display:none;")
                _oLblAstCDA.Attributes.Add("style", "display:none;")
                _oLblCDANo2.Attributes.Add("style", "display:none;")
                Slide_05_CDA.Attributes.Add("style", "display:none;")
                Slide_05_CDA2.Attributes.Add("style", "display:none;")
                Slide_05_CDA.Value = ""
                Slide_05_CDA2.Value = ""

                frmDTI.Attributes.Add("style", "display:none;")
                _oLblDTINo.Attributes.Add("style", "display:none;")
                _oLblAstDTI.Attributes.Add("style", "display:none;")
                _oLblDTINo2.Attributes.Add("style", "display:none;")
                Slide_05_DTI.Attributes.Add("style", "display:none;")
                Slide_05_DTI2.Attributes.Add("style", "display:none;")
                Slide_05_DTI.Value = ""
                Slide_05_DTI2.Value = ""
            End If

            Slide_05_CDA.Value = Session("GovCDANo")
            Slide_05_CDA2.Value = Session("GovRegDateCDA")
            Slide_05_DTI.Value = Session("GovDTINo")
            Slide_05_DTI2.Value = Session("GovRegDateDTI")
            Slide_05_SEC.Value = Session("GovSECNo")
            Slide_05_SEC2.Value = Session("GovRegDateSEC")
            Slide_05_TIN.Value = Session("GovTINNo")
            Slide_05_TIN2.Value = Session("GovRegDateTIN")
            Slide_05_SSS.Value = Session("GovSSS")
            Slide_05_SSS2.Value = Session("GovRegDateSSS")
            Slide_05_BIR.Value = Session("GovBIR")
            Slide_05_BIR2.Value = Session("GovRegDateBIR")
            Slide_05_Brgy.Value = Session("GovBrgyClearance")
            Slide_05_Brgy2.Value = Session("GovRegDateBrgyClearance")



            'If cLoader_CBPAuthRep._pIsRegOAIMS = True Then '@Added 20211108 LOUIE
            '    _Init_CBPOAIMSReg()
            'End If

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

            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "Redirect" Then

                If val = "Back" Then

                    Session("GovCDANo") = Slide_05_CDA.Value
                    Session("GovRegDateCDA") = Slide_05_CDA2.Value
                    Session("GovDTINo") = Slide_05_DTI.Value
                    Session("GovRegDateDTI") = Slide_05_DTI2.Value
                    Session("GovSECNo") = Slide_05_SEC.Value
                    Session("GovRegDateSEC") = Slide_05_SEC2.Value
                    Session("GovTINNo") = Slide_05_TIN.Value
                    Session("GovRegDateTIN") = Slide_05_TIN2.Value
                    Session("GovSSS") = Slide_05_SSS.Value
                    Session("GovRegDateSSS") = Slide_05_SSS2.Value
                    Session("GovBIR") = Slide_05_BIR.Value
                    Session("GovRegDateBIR") = Slide_05_BIR2.Value
                    Session("GovBrgyClearance") = Slide_05_Brgy.Value
                    Session("GovRegDateBrgyClearance") = Slide_05_Brgy2.Value

                    'cLoaderNewBusinessApplication._pGovCDANo = Slide_05_CDA.Value
                    'cLoaderNewBusinessApplication._pGovRegDateCDA = Slide_05_CDA2.Value
                    'cLoaderNewBusinessApplication._pGovDTINo = Slide_05_DTI.Value
                    'cLoaderNewBusinessApplication._pGovRegDateDTI = Slide_05_DTI2.Value
                    'cLoaderNewBusinessApplication._pGovSECNo = Slide_05_SEC.Value
                    'cLoaderNewBusinessApplication._pGovRegDateSEC = Slide_05_SEC2.Value
                    'cLoaderNewBusinessApplication._pGovTINNo = Slide_05_TIN.Value
                    'cLoaderNewBusinessApplication._pGovRegDateTIN = Slide_05_TIN2.Value
                    'cLoaderNewBusinessApplication._pGovSSS = Slide_05_SSS.Value
                    'cLoaderNewBusinessApplication._pGovRegDateSSS = Slide_05_SSS2.Value
                    'cLoaderNewBusinessApplication._pGovBIR = Slide_05_BIR.Value
                    'cLoaderNewBusinessApplication._pGovRegDateBIR = Slide_05_BIR2.Value
                    'cLoaderNewBusinessApplication._pGovBrgyClearance = Slide_05_Brgy.Value
                    'cLoaderNewBusinessApplication._pGovRegDateBrgyClearance = Slide_05_Brgy2.Value
                    If Session("Rent") = "True" Then
                        Response.Redirect("BusLessorInfo.aspx")
                    Else
                        Response.Redirect("BusOwnerShipType.aspx")
                    End If

                ElseIf val = "Next" Then

                    Session("GovCDANo") = Slide_05_CDA.Value
                    Session("GovRegDateCDA") = Slide_05_CDA2.Value
                    Session("GovDTINo") = Slide_05_DTI.Value
                    Session("GovRegDateDTI") = Slide_05_DTI2.Value
                    Session("GovSECNo") = Slide_05_SEC.Value
                    Session("GovRegDateSEC") = Slide_05_SEC2.Value
                    Session("GovTINNo") = Slide_05_TIN.Value
                    Session("GovRegDateTIN") = Slide_05_TIN2.Value
                    Session("GovSSS") = Slide_05_SSS.Value
                    Session("GovRegDateSSS") = Slide_05_SSS2.Value
                    Session("GovBIR") = Slide_05_BIR.Value
                    Session("GovRegDateBIR") = Slide_05_BIR2.Value
                    Session("GovBrgyClearance") = Slide_05_Brgy.Value
                    Session("GovRegDateBrgyClearance") = Slide_05_Brgy2.Value
                    'cLoaderNewBusinessApplication._pGovCDANo = Slide_05_CDA.Value
                    'cLoaderNewBusinessApplication._pGovRegDateCDA = Slide_05_CDA2.Value
                    'cLoaderNewBusinessApplication._pGovDTINo = Slide_05_DTI.Value
                    'cLoaderNewBusinessApplication._pGovRegDateDTI = Slide_05_DTI2.Value
                    'cLoaderNewBusinessApplication._pGovSECNo = Slide_05_SEC.Value
                    'cLoaderNewBusinessApplication._pGovRegDateSEC = Slide_05_SEC2.Value
                    'cLoaderNewBusinessApplication._pGovTINNo = Slide_05_TIN.Value
                    'cLoaderNewBusinessApplication._pGovRegDateTIN = Slide_05_TIN2.Value
                    'cLoaderNewBusinessApplication._pGovSSS = Slide_05_SSS.Value
                    'cLoaderNewBusinessApplication._pGovRegDateSSS = Slide_05_SSS2.Value
                    'cLoaderNewBusinessApplication._pGovBIR = Slide_05_BIR.Value
                    'cLoaderNewBusinessApplication._pGovRegDateBIR = Slide_05_BIR2.Value
                    'cLoaderNewBusinessApplication._pGovBrgyClearance = Slide_05_Brgy.Value
                    'cLoaderNewBusinessApplication._pGovRegDateBrgyClearance = Slide_05_Brgy2.Value                    

                    '          If Session("OwnerShipType") = "Cooperative" And Slide_05_CDA.Value = "" Then
                    '              snackbar("red", "Please input CDA No.")
                    '              Exit Sub
                    '          End If
                    '          If Session("OwnerShipType") = "Cooperative" And Slide_05_CDA2.Value = "" Then
                    '              snackbar("red", "Please input CDA No. registration date")
                    '              Exit Sub
                    '          End If
                    '          If Session("OwnerShipType") = "Single" And Slide_05_DTI.Value = "" Then
                    '              snackbar("red", "Please input DTI No.")
                    '              Exit Sub
                    '          End If
                    '          If Session("OwnerShipType") = "Single" And Slide_05_DTI2.Value = "" Then
                    '              snackbar("red", "Please input DTI No. registration date")
                    '              Exit Sub
                    '          End If
                    '          If Session("OwnerShipType") = "Corporation" And Slide_05_SEC.Value = "" Then
                    '              snackbar("red", "Please input SEC No.")
                    '              Exit Sub
                    '          End If
                    '          If Session("OwnerShipType") = "Corporation" And Slide_05_SEC2.Value = "" Then
                    '              snackbar("red", "Please input SEC No. registration date")
                    '              Exit Sub
                    '          End If
                    '
                    '          If Slide_05_TIN.Value = "" Then
                    '              snackbar("red", "Please input TIN No.")
                    '              Exit Sub
                    '          End If
                    '          If Slide_05_TIN2.Value = "" Then
                    '              snackbar("red", "Please input TIN No. registration date")
                    '              Exit Sub
                    '          End If
                    '
                    '          If Slide_05_SSS.Value = "" Then
                    '              snackbar("red", "Please input SSS No.")
                    '              Exit Sub
                    '          End If
                    '          If Slide_05_SSS2.Value = "" Then
                    '              snackbar("red", "Please input SSS No. registration date")
                    '              Exit Sub
                    '          End If
                    '
                    '          If Slide_05_BIR.Value = "" Then
                    '              snackbar("red", "Please input BIR No.")
                    '              Exit Sub
                    '          End If
                    '          If Slide_05_BIR2.Value = "" Then
                    '              snackbar("red", "Please input BIR No. registration date")
                    '              Exit Sub
                    '          End If

                    Response.Redirect("BusInformation.aspx")

                    End If

            End If

        End If
    End Sub

    Public Sub _Init_CBPOAIMSReg()
        Dim strTrigger = Nothing, strTrigger2 = Nothing
        Dim strBody = Nothing, strBody2 = Nothing
        cInit_CBPReg._InitCBP_BussinessInfo(strTrigger, strBody)
        Response.Write("<script>" & strTrigger + strBody & "</script>")
        cInit_CBPReg._InitCBP_AutorizeRep(strTrigger2, strBody2)
        Response.Write("<script>" & strTrigger2 + strBody2 & "</script>")
    End Sub
    Sub snackbar(Color As String, Caption As String)
        Try
            If Color = "red" Then
                _oLabelSnackbar.Text = Caption
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

            ElseIf Color = "green" Then
                _oLabelSnackbargreen.Text = Caption
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
            End If

        Catch ex As Exception

        End Try
    End Sub

End Class