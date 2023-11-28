Imports System.ComponentModel
Imports SPIDC.Resources
Imports System.IO
Imports VB.NET.Email
Imports System.Net.Mail
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System
Imports System.Text
Imports System.Security.Cryptography

Public Class CedulaPage
    Inherits System.Web.UI.Page

    Dim postbackurl As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            cSessionLoader._pWeb = "NEW"

            'cSessionUser._pUserID = "avileslouiejay915@gmail.com"

            CedulaIndi.Checked = True
            ' _oTxtBusinessIncome.Value = "0.0"
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
        Else

        End If
    End Sub



    Public Sub ChckedChanged()
        Try

            If chkSelect.Checked = True Then
                GetUserInfor()

                _oTxtLastName.Disabled = True
                _oTxtMiddleName.Disabled = True
                _oTxtFirstName.Disabled = True
                _oTxtAddress.Disabled = True
                _oTxtBirthDate.Disabled = True
                _oTxtBirthPlace.Disabled = True
                _oTxtTIN.Disabled = True
                radGender.Disabled = True
                ' radProfession.Disabled = True
                radCivilstat.Disabled = True
                radCitizenship.Disabled = True

                If _oTxtLastName.Value = "" Then
                    _oTxtLastName.Disabled = False
                End If
                If _oTxtMiddleName.Value = "" Then
                    _oTxtMiddleName.Disabled = False
                End If
                If _oTxtFirstName.Value = "" Then
                    _oTxtFirstName.Disabled = False
                End If
                If _oTxtAddress.Value = "" Then
                    _oTxtAddress.Disabled = False
                End If
                If _oTxtBirthDate.Value = "" Then
                    _oTxtBirthDate.Disabled = False
                End If
                If _oTxtBirthPlace.Value = "" Then
                    _oTxtBirthPlace.Disabled = False
                End If
                If _oTxtTIN.Value = "" Then
                    _oTxtTIN.Disabled = False
                End If
                If radGender.Value = "" Then
                    radGender.Disabled = False
                End If
                If radCivilstat.Value = "" Then
                    radCivilstat.Disabled = False
                End If
                If radCitizenship.Value = "" Then
                    radCitizenship.Disabled = False
                End If
            Else

                _oTxtLastName.Disabled = False
                _oTxtMiddleName.Disabled = False
                _oTxtFirstName.Disabled = False
                _oTxtAddress.Disabled = False
                _oTxtBirthDate.Disabled = False
                _oTxtBirthPlace.Disabled = False
                _oTxtTIN.Disabled = False
                radGender.Disabled = False
                ' radProfession.Disabled = False
                radCivilstat.Disabled = False
                radCitizenship.Disabled = False

                _oTxtLastName.Value = ""
                _oTxtMiddleName.Value = ""
                _oTxtFirstName.Value = ""
                _oTxtAddress.Value = ""
                _oTxtBirthDate.Value = ""
                _oTxtBirthPlace.Value = ""
                _oTxtTIN.Value = ""
                radGender.Value = ""
                radProfession.Value = ""

            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetUserInfor()
        Try
            Dim _nSuccessful As Boolean, _nErrMsg As String = Nothing

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "OAIMS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nOAIMSServerName As String = _nClBP._pDBDataSource
            Dim _nOAIMSDatabaseName As String = _nClBP._pDBInitialCatalog




            Dim _nClass As New cDal_IUD
            With _nClass
                ._pSqlCon = cGlobalConnections._pSqlCxn_TIMS
                ._pAction = "SELECT"
                ._pSelect = "Select  IDNo,LastName, FirstName, MiddleName, ExtnName, BirthDate, BirthPlace, [Address], Profession, TIN, Gender, CivilStatus, Citizenship "
                ._pCondition = "from   [" & _nOAIMSServerName & "].[" & _nOAIMSDatabaseName & "].dbo.Registered where UserID = ''" & cSessionUser._pUserID & "'' "
                ._pExec(_nSuccessful, _nErrMsg)

                Dim _nDataTable As New DataTable
                _nDataTable = ._pDataTable

                If _nDataTable.Rows.Count > 0 Then

                    _oTxtLastName.Value = _nDataTable.Rows("0").Item("LastName").ToString
                    _oTxtMiddleName.Value = _nDataTable.Rows("0").Item("MiddleName").ToString
                    _oTxtFirstName.Value = _nDataTable.Rows("0").Item("FirstName").ToString
                    _oTxtAddress.Value = _nDataTable.Rows("0").Item("Address").ToString
                    radGender.Value = _nDataTable.Rows("0").Item("Gender").ToString

                    Dim _nBDate As Date = _nDataTable.Rows("0").Item("BirthDate")
                    _oTxtBirthDate.Value = _nBDate.ToShortDateString

                    _oTxtBirthPlace.Value = _nDataTable.Rows("0").Item("BirthPlace").ToString
                    _oTxtTIN.Value = _nDataTable.Rows("0").Item("TIN").ToString

                    radCitizenship.Value = _nDataTable.Rows("0").Item("Citizenship").ToString

                    Dim _nStatus As String = _nDataTable.Rows("0").Item("CivilStatus").ToString

                    Select Case _nStatus
                        Case Is = "SI"
                            radCivilstat.Value = "Single"
                        Case Is = "MA"
                            radCivilstat.Value = "Married"
                        Case Is = "DV"
                            radCivilstat.Value = "Devorced"
                        Case Is = "LS"
                            radCivilstat.Value = "Separated"

                    End Select

                 


                    radGender.Value = _nDataTable.Rows("0").Item("Gender").ToString


                    radProfession.Value = _nDataTable.Rows("0").Item("Profession").ToString


                    _oTxtHeight.Value = ""
                    _oTxtWeight.Value = ""


                End If


            End With
        Catch ex As Exception

        End Try


    End Sub

    Private Sub _oPayLayter_Click(sender As Object, e As EventArgs) Handles _oPayLayter.ServerClick

        _PassValuetoLoader()
        Dim _nSuccessful As Boolean
        Dim _nErrMsg As String = Nothing

        _SaveInformation(_nSuccessful, _nErrMsg)
        If _nSuccessful = True Then

            ClientScript.RegisterStartupScript(Me.GetType(), "AlertScript", "alert('Your Reference Number is: " & cLoader_CTCApp._pControlNo & "');", True)
            '_oLabelControlNo.Value = cLoader_CTCApp._pControlNo
            ' _Proceed("END")
            Exit Sub
        Else
            ' _Proceed("ERROR")
            Exit Sub
        End If
    End Sub
    Private Sub _oPayNow_Click(sender As Object, e As EventArgs) Handles _oPayNow.ServerClick

        If _oTxtAddress.Value = "" Then Exit Sub
        If _oTxtBirthDate.Value = "" Then Exit Sub
        If _oTxtBirthPlace.Value = "" Then Exit Sub
        If _oTxtBusinessIncome.Value = "" Then Exit Sub
        If _oTxtFirstName.Value = "" Then Exit Sub
        If _oTxtHeight.Value = "" Then Exit Sub
        If _oTxtLastName.Value = "" Then Exit Sub
        If _oTxtMiddleName.Value = "" Then Exit Sub
        If _oTxtPropertySale.Value = "" Then Exit Sub
        If _oTxtSalary.Value = "" Then Exit Sub
        If _oTxtTIN.Value = "" Then Exit Sub
        If _oTxtWeight.Value = "" Then Exit Sub
        If radProfession.Value = "" Then Exit Sub
        If radGender.Value = "" Then Exit Sub
        If radCitizenship.Value = "" Then Exit Sub
        If radCivilstat.Value = "" Then Exit Sub

        _PassValuetoLoader()
        Dim _nSuccessful As Boolean
        Dim _nErrMsg As String = Nothing

        ' _SaveInformation(_nSuccessful, _nErrMsg)
        ' If _nSuccessful = True Then
        cSessionLoader._pAccountNo = cLoader_CTCApp._pControlNo 'unique
        cSessionLoader._pType = "CEDULA INDIVIDUAL" 'unique
        cSessionLoader._pTotalAmountDue = CDbl(cLoader_CTCApp._pAmount) + CDbl(cLoader_CTCApp._pPenalty) 'totamount
        cSessionLoader._pService = "CTC" 'CTC

        ' cSessionLoader._pAccountNo = cLoader_CTCApp._pControlNo
        ' ClassPageSession_pBilling._pCommercialName = "CEDULA INDIVIDUAL"
        'ClassPageSession_pBilling._pTotalAmountDue = _FnGet_TotalDue()
        ' ClassPageSession_pBilling._pTotalAmountDue = AmountToPay.Value


        Response.Redirect("PayNow.aspx")

        '_oLabelControlNo.Value = cLoader_CTCApp._pControlNo
        ' _Proceed("END")
        Exit Sub
        '  Else
        ' _Proceed("ERROR")
        Exit Sub
        '  End If







    End Sub



    Private Sub _PassValuetoLoader()




        cLoader_CTCApp._pControlNo = _FnAutoGenID("ControlNumber")


        If CedulaIndi.Checked = True Then
            cLoader_CTCApp._pCTC_Type = "IE"
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
            cLoader_CTCApp._pAmount = _oTxtHiddenAmountDue.Value.ToString
            cLoader_CTCApp._pPenalty = _oTxtHiddenPenalty.Value.ToString
        Else
            cLoader_CTCApp._pCTC_Type = "C"
            cLoader_CTCApp._pIncome = 0
            cLoader_CTCApp._pGross = _oTxtBusinessIncome.Value.Replace(",", "")
            cLoader_CTCApp._pRealProperty = _oTxtPropertySale.Value.Replace(",", "")
            cLoader_CTCApp._pAmount = _oTxtHiddenAmountDue.Value.ToString
            cLoader_CTCApp._pPenalty = _oTxtHiddenPenalty.Value.ToString
        End If

        cLoader_CTCApp._pFirstName = _oTxtFirstName.Value
        cLoader_CTCApp._pMiddleName = _oTxtMiddleName.Value
        cLoader_CTCApp._pLastName = _oTxtLastName.Value

        cLoader_CTCApp._pAddress = _oTxtAddress.Value
        cLoader_CTCApp._pBirthPlace = _oTxtBirthPlace.Value
        cLoader_CTCApp._pBirthDate = _oTxtBirthDate.Value
        cLoader_CTCApp._pCivilStatus = radCivilstat.Value
        cLoader_CTCApp._pCitizenship = radCitizenship.Value
        cLoader_CTCApp._pGender = radGender.Value
        cLoader_CTCApp._pOccupation = radProfession.Value
        cLoader_CTCApp._pTIN = _oTxtTIN.Value



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
                            "," & cLoader_CTCApp._pAmount & "" & _
                            ",''" & cSessionUser._pUserID & "''" & _
                            "," & cLoader_CTCApp._pPenalty & "" & _
                            ",''Pending''" & _
                            ",''" & Format(Date.Now, "MMMM dd, yyyy hh:mm:ss tt") & "''" & _
                            " )"
                ._pExec(_nSuccessful, _nErrMsg)

            End With

        Catch ex As Exception

        End Try
    End Sub

End Class