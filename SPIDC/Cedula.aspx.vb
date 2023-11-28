Imports System.Data.SqlClient

Public Class Cedula
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            cSessionLoader._pWeb = "NEW"
            _oRadAssociation.Checked = True

            _oTxtHdnCedulaInd.Value = "1"
            _oTxtHdnCedulaCorp.Value = "0"
            _oTxtSalary.Disabled = True
            Dim Bus As Double = 0.0
            Dim Sal As Double = 0.0
            Dim RP As Double = 0.0

            Dim Basic As Double = 5.5

            Dim Month As Integer = CInt(DateTime.Now.Month.ToString())
            Dim Penalty As Double = 0.02 * (Month)

            Dim TotGross As Double = Bus + Sal + RP

            Dim Remainder As Double = TotGross Mod 1000
            Dim Subtract As Double = TotGross - Remainder
            Dim quotient As Double = Subtract / 1000

            Dim TaxDue As Double = quotient

            Dim ComputedTaxDue As Double = TaxDue + Basic
            Dim Interest As Double = ComputedTaxDue * Penalty
            Dim tot_amount As Double = TaxDue + Basic + Interest

            AmountToPay.Value = tot_amount
            cLoader_CTCApp._pTotAmount = AmountToPay.Value
            cLoader_CTCApp._pPenalty = Penalty
        Else

        End If
    End Sub
    

    Private Sub _oPayNow()
        '_Click(sender As Object, e As EventArgs) Handles _oPayNow.ServerClick, _
        '        _oBtnPaymentCorp.ServerClick

        Dim IndCorp As String = "CEDULA INDIVIDUAL"
        If _oTxtHdnCedulaInd.Value = "1" Then
            IndCorp = "CEDULA INDIVIDUAL"
            If _oTxtAddress.Value = "" Then Exit Sub
            If _oTxtBirthDate.Value = "" Then Exit Sub
            _oTxtHdnBirthDate.Value = _oTxtBirthDate.Value
            If _oTxtHdnBirthDate.Value = "" Then Exit Sub
            If _oTxtBirthPlace.Value = "" Then Exit Sub
            If _oTxtFirstName.Value = "" Then Exit Sub

            If _oTxtLastName.Value = "" Then Exit Sub
            If _oTxtTIN.Value = "" Then _oTxtTIN.Value = "000-000-000-000"

            If radioProfession.Value = "" Then radioProfession.Value = "Unemployed"
            If radGender.Value = "" Then Exit Sub
            If radCitizenship.Value = "" Then Exit Sub
            If radCivilstat.Value = "" Then Exit Sub

        ElseIf _oTxtHdnCedulaCorp.Value = "1" Then
            IndCorp = "CEDULA CORPORATION"
            If _oTxtCompanyName.Value = "" Then Exit Sub
            If _oTxtGrossReceipt.Value = "" Then Exit Sub
            If _oTxtAddressPrincipal.Value = "" Then Exit Sub
            If _oTxtPlaceofIncorporation.Value = "" Then Exit Sub
            If _oTxtDateIncorporation.Value = "" Then Exit Sub

            If Trim(_oTxtKindBusiness.Value) = "" Then Exit Sub
            If _oTxtCorpTIN.Value = "" Then Exit Sub
        End If

        _PassValuetoLoader()
        Dim _nSuccessful As Boolean
        Dim _nErrMsg As String = Nothing

        _SaveInformation(_nSuccessful, _nErrMsg)
        If _nSuccessful = True Then
            Dim ctrlNo = cLoader_CTCApp._pControlNo
            cSessionLoader._pTotalAmountDue = cLoader_CTCApp._pTotAmount 'totamount
            tdAmounttoPay.InnerText = Format(cSessionLoader._pTotalAmountDue, "STANDARD")
            tdCedulaType.InnerText = IndCorp
            tdControlNo.InnerText = ctrlNo
            If _oTxtHdnCedulaInd.Value = "1" Then
                tdName.InnerText = _oTxtLastName.Value & ", " & _oTxtFirstName.Value
            ElseIf _oTxtHdnCedulaCorp.Value = "1" Then
                tdName.InnerText = _oTxtCompanyName.Value
            End If

            Dim _nclass As New cDalPayment
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nclass._pSubInsertPaymentRefNo(ctrlNo, "StandAloneCedula", "OTC", ctrlNo, "CTC")
            _mSubUpdateCTC_OTC()

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModalComplete();", True)

            Exit Sub
        Else

            Exit Sub
        End If

    End Sub

    Private Sub _mSubUpdateCTC_OTC()
        Try
            Dim _nStatusID As String
            Dim _nClass As New cDalPayment
            '----------------------------------
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
            _nStatusID = "PENDING"
            _nClass._pRemarks = "PENDING"
            _nClass._pisPosted = "0"
            _nClass._pSubUpdateCTC_OTC("", _nStatusID, cLoader_CTCApp._pControlNo, cLoader_CTCApp._pControlNo)


            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _PassValuetoLoader()

        cLoader_CTCApp._pControlNo = _FnAutoGenID("ControlNumber")


        If _oTxtHdnCedulaInd.Value = "1" Then
            cLoader_CTCApp._pCTC_Type = "IND"
            cLoader_CTCApp._pIncome = _oTxtSalary.Value.Replace(",", "")
            cLoader_CTCApp._pRealProperty = _oTxtPropertySale.Value.Replace(",", "")
            If _oTxtBusinessIncome.Value.Replace(",", "") = "" Then
                cLoader_CTCApp._pGross = 0
            Else
                cLoader_CTCApp._pGross = _oTxtBusinessIncome.Value.Replace(",", "")
            End If
            If _oTxtSalary.Value.Replace(",", "") = "" Then
                cLoader_CTCApp._pIncome = 0
            Else
                cLoader_CTCApp._pIncome = _oTxtSalary.Value.Replace(",", "")
            End If

            cLoader_CTCApp._pBasicAmount = _oTxtHiddenBasicAmount.Value
            cLoader_CTCApp._pAmount = _oTxtHiddenAmountDue.Value
            cLoader_CTCApp._pPenalty = _oTxtHiddenPenalty.Value
            cLoader_CTCApp._pDelFee = _oTxtHiddenDelivery.Value
            cLoader_CTCApp._pTotAmount = _oTxtHiddenTotAmount.Value
            If cLoader_CTCApp._pDelFee.ToString <> "" Then
                cLoader_CTCApp._pDelFee += CDec(cLoader_CTCApp._pDelFee)
            Else
                cLoader_CTCApp._pDelFee = "0.00"
            End If
            cLoader_CTCApp._pForYear = _oDpForYear.Value
            cLoader_CTCApp._pFirstName = _oTxtFirstName.Value
            cLoader_CTCApp._pMiddleName = _oTxtMiddleName.Value
            cLoader_CTCApp._pLastName = _oTxtLastName.Value
            cLoader_CTCApp._pAddress = _oTxtAddress.Value
            cLoader_CTCApp._pBirthPlace = _oTxtBirthPlace.Value
            cLoader_CTCApp._pBirthDate = _oTxtBirthDate.Value
            cLoader_CTCApp._pCivilStatus = radCivilstat.Value
            cLoader_CTCApp._pCitizenship = radCitizenship.Value
            cLoader_CTCApp._pGender = radGender.Value
            cLoader_CTCApp._pOccupation = Trim(radioProfession.Value)
            cLoader_CTCApp._pTIN = _oTxtTIN.Value
            cLoader_CTCApp._pHeight = _oTxtHeight.Value
            cLoader_CTCApp._pWeight = _oTxtWeight.Value
            cLoader_CTCApp._pOrgKind = ""
            cLoader_CTCApp._pBusKind = ""
            cSessionLoader._pType = "Cedula - Individual"
            cLoader_CTCApp._pTransDate = Date.Now
        ElseIf _oTxtHdnCedulaCorp.Value = "1" Then
            cLoader_CTCApp._pCTC_Type = "CORP"
            cLoader_CTCApp._pIncome = 0
            cLoader_CTCApp._pGross = _oTxtGrossReceipt.Value.Replace(",", "")
            cLoader_CTCApp._pRealProperty = _oTxtAssValue.Value.Replace(",", "")

            cLoader_CTCApp._pBasicAmount = _oTxtHiddenBasicAmount.Value
            cLoader_CTCApp._pAmount = _oTxtHiddenAmountDue.Value.ToString
            cLoader_CTCApp._pPenalty = _oTxtHiddenPenalty.Value.ToString
            cLoader_CTCApp._pDelFee = _oTxtHiddenDelivery.Value
            If cLoader_CTCApp._pDelFee.ToString <> "" Then
                cLoader_CTCApp._pDelFee = CDec(cLoader_CTCApp._pDelFee)
            Else
                cLoader_CTCApp._pDelFee = "0.00"
            End If
            cLoader_CTCApp._pTotAmount = CDec(cLoader_CTCApp._pBasicAmount) + CDec(cLoader_CTCApp._pAmount) + CDec(cLoader_CTCApp._pPenalty) + CDec(cLoader_CTCApp._pDelFee)

            cLoader_CTCApp._pFirstName = ""
            cLoader_CTCApp._pMiddleName = ""
            cLoader_CTCApp._pLastName = _oTxtCompanyName.Value

            cLoader_CTCApp._pForYear = _oDpForYearCorp.Value
            cLoader_CTCApp._pAddress = _oTxtAddressPrincipal.Value
            cLoader_CTCApp._pBirthPlace = _oTxtPlaceofIncorporation.Value
            cLoader_CTCApp._pBirthDate = _oTxtDateIncorporation.Value
            cLoader_CTCApp._pCivilStatus = ""
            cLoader_CTCApp._pCitizenship = ""
            cLoader_CTCApp._pGender = ""
            cLoader_CTCApp._pOccupation = Trim(_oTxtKindBusiness.Value)
            cLoader_CTCApp._pTIN = _oTxtCorpTIN.Value
            If _oRadAssociation.Checked = True Then
                cLoader_CTCApp._pOrgKind = "Association"
            ElseIf _oRadCorporation.Checked = True Then
                cLoader_CTCApp._pOrgKind = "Corporation"
            ElseIf _oRadPartnership.Checked = True Then
                cLoader_CTCApp._pOrgKind = "Partnership"
            End If
            cLoader_CTCApp._pBusKind = _oTxtKindBusiness.Value
            cLoader_CTCApp._pHeight = ""
            cLoader_CTCApp._pWeight = ""
            cSessionLoader._pType = "Cedula - Corporation"
            cLoader_CTCApp._pTransDate = Date.Now
        End If





    End Sub

    Private Sub _SaveInformation(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = Nothing)
        Try

            Dim _nClass As New cDal_IUD
            With _nClass

                ._pSqlCon = cGlobalConnections._pSqlCxn_TIMS
                ._pAction = "INSERT"
                ._pSelect = "INSERT INTO CTC_Online " & _
                            " ( " & _
                            " ControlNo" & _
                            " ,CTC_Type " & _
                            " ,FirstName " & _
                            " ,MiddleName " & _
                            " ,LastName " & _
                            " ,[Address] " & _
                            " ,BirthPlace " & _
                            " ,BirthDate " & _
                            " ,CivilStatus " & _
                            " ,Citizenship " & _
                            " ,Gender " & _
                            " ,Occupation " & _
                            " ,TIN " & _
                            " ,ProfIncome " & _
                            " ,BusIncome " & _
                            " ,RPTIncome " & _
                            " ,TaxAmount " & _
                            " ,EMAIL " & _
                            " ,Penalty " & _
                            " ,Status " & _
                            " ,TransDate " & _
                            " ,OrgKind " & _
                            " ,BasicAmount " & _
                            " ,DelFee " & _
                            " ,TotAmount " & _
                            " ,ForYear " & _
                            " ,Height " & _
                            " ,Weight " & _
                            " ,OTC " & _
                            " ) " & _
                            "VALUES " & _
                            "( " & _
                            " ''" & cLoader_CTCApp._pControlNo & "''" & _
                            ",''" & cLoader_CTCApp._pCTC_Type & "''" & _
                            ",''" & cLoader_CTCApp._pFirstName & "''" & _
                            ",''" & cLoader_CTCApp._pMiddleName & "''" & _
                            ",''" & cLoader_CTCApp._pLastName & "''" & _
                            ",''" & cLoader_CTCApp._pAddress & "''" & _
                            ",''" & cLoader_CTCApp._pBirthPlace & "''" & _
                            ",''" & cLoader_CTCApp._pBirthDate & "''" & _
                            ",''" & cLoader_CTCApp._pCivilStatus & "''" & _
                            ",''" & cLoader_CTCApp._pCitizenship & "''" & _
                            ",''" & cLoader_CTCApp._pGender & "''" & _
                            ",''" & cLoader_CTCApp._pOccupation & "''" & _
                            ",''" & cLoader_CTCApp._pTIN & "''" & _
                            "," & cLoader_CTCApp._pIncome & "" & _
                            "," & cLoader_CTCApp._pGross & "" & _
                            "," & cLoader_CTCApp._pRealProperty & "" & _
                            "," & IIf(cLoader_CTCApp._pAmount = "", 0, cLoader_CTCApp._pAmount) & "" & "" & _
                            ",''" & cSessionUser._pUserID & "''" & _
                            "," & IIf(cLoader_CTCApp._pPenalty = "", 0, cLoader_CTCApp._pPenalty) & "" & _
                            ",''Pending''" & _
                            ",''" & cLoader_CTCApp._pTransDate & "''" & _
                            ",''" & IIf(cLoader_CTCApp._pOrgKind = "", 0, cLoader_CTCApp._pOrgKind) & "" & "''" & _
                            "," & cLoader_CTCApp._pBasicAmount & "" & _
                            "," & cLoader_CTCApp._pDelFee & "" & _
                            "," & cLoader_CTCApp._pTotAmount & "" & _
                            ",''" & cLoader_CTCApp._pForYear & "''" & _
                            ",''" & cLoader_CTCApp._pHeight & "''" & _
                            ",''" & cLoader_CTCApp._pWeight & "''" & _
                            ",''" & 0 & "''" & _
                            " )"
                ._pExec(_nSuccessful, _nErrMsg)

            End With

        Catch ex As Exception

        End Try
    End Sub


    Public Shared Function _FnAutoGenID(ByVal _nModuleID As String, Optional _nRefCode As String = Nothing) As String
        _FnAutoGenID = Nothing
        Try

            Dim _nClass As New cDalAutoGenID
            _nClass._pSqlCon = cGlobalConnections._pSqlCxn_TIMS
            Dim _nResult = _nClass._FnAutoGenID(_nModuleID, _nRefCode)
            Return _nResult

        Catch ex As Exception

        End Try
    End Function

    Private Sub btnPayNowCorp_ServerClick(sender As Object, e As EventArgs) Handles btnPayNowCorp.ServerClick
        _oPayNow()
    End Sub

    Private Sub btnPayNowInd_ServerClick(sender As Object, e As EventArgs) Handles btnPayNowInd.ServerClick
        _oPayNow()
    End Sub
End Class