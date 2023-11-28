Imports System.ComponentModel

Imports System.IO
Imports VB.NET.Email
Imports System.Net.Mail
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System
Imports System.Text
Imports System.Security.Cryptography

Public Class NewCedula
    Inherits System.Web.UI.Page

    Dim postbackurl As String


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

            'Dim Basic As Double = 20.5
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

            GetUserInfor()
        Else

            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "PayNow" Then
                'If _oTxtBusinessIncome.Value = "0.00" And _oTxtSalary.Value = "0.00" And _oTxtPropertySale.Value = "0.00" Then
                'Exit Sub
                'End If
                _oPayNow()
            End If
        End If
    End Sub



    Public Sub ChckedChanged()
        Try

            If chkSelect.Checked = True Then
                PassValueToTextfields()

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

                radioProfession.Value = ""
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
                _oTxtHeight.Value = ""
                _oTxtWeight.Value = ""
                _oTxtSalary.Value = "0.00"
                _oTxtSalary.Disabled = True
                Dim Bus As Double = 0.0
                Dim Sal As Double = 0.0
                Dim RP As Double = 0.0

                Dim Basic As Double = 20.5

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


                'If radioProfession.Value = "" Then

                '    If _oTxtBusinessIncome.Value <> "0.00" Or _oTxtBusinessIncome.Value <> "" Then
                '        _oLblKindly.Visible = False
                '    End If
                '    If _oTxtBusinessIncome.Value = "0.00" Or _oTxtBusinessIncome.Value = "" Then
                '        _oLblKindly.Visible = True
                '    End If
                'End If

                'If radioProfession.Value <> "" Then

                '    If _oTxtBusinessIncome.Value <> "0.00" Or _oTxtBusinessIncome.Value <> "" Then
                '        _oLblKindly.Visible = False
                '    End If

                '    If _oTxtBusinessIncome.Value = "0.00" Or _oTxtBusinessIncome.Value = "" Then
                '        _oLblKindly.Visible = True
                '    End If

                '    If _oTxtSalary.Value <> "0.00" Or _oTxtSalary.Value <> "" Then
                '        _oLblKindly.Visible = False
                '    End If

                '    If _oTxtSalary.Value = "0.00" Or _oTxtSalary.Value = "" Then
                '        _oLblKindly.Visible = True
                '    End If
                'End If

                'If chkSelect.Checked = True And radioProfession.Value <> "" Then

                '    If _oTxtPropertySale.Value <> "0.00" Or _oTxtPropertySale.Value <> "" Then
                '        _oLblKindly.Visible = False
                '    End If

                '    If _oTxtPropertySale.Value = "0.00" Or _oTxtPropertySale.Value = "" Then
                '        _oLblKindly.Visible = True
                '    End If
                'End If
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub PassValueToTextfields()
        'GetUserInfor()
        '_oTxtLastName.Value = cLoader_CTCValues._pLastName
        '_oTxtMiddleName.Value = cLoader_CTCValues._pMiddleName
        '_oTxtFirstName.Value = cLoader_CTCValues._pFirstName
        '_oTxtAddress.Value = cLoader_CTCValues._pAddress
        'radGender.Value = cLoader_CTCValues._pGender
        '_oTxtHeight.Value = cLoader_CTCValues._pHeight
        '_oTxtWeight.Value = cLoader_CTCValues._pWeight
        'Dim _nBDate As Date = cLoader_CTCValues._pBirthDate
        '_oTxtBirthDate.Value = _nBDate.ToShortDateString

        '_oTxtBirthPlace.Value = cLoader_CTCValues._pBirthPlace
        '_oTxtTIN.Value = cLoader_CTCValues._pTIN

        'radCitizenship.Value = cLoader_CTCValues._pCitizenship

        'Dim _nStatus As String = cLoader_CTCValues._pCivilStatus

        'Select Case _nStatus
        '    Case Is = "Single"
        '        radCivilstat.Value = "Single"
        '    Case Is = "Married"
        '        radCivilstat.Value = "Married"
        '    Case Is = "Divorced"
        '        radCivilstat.Value = "Divorced"
        '    Case Is = "Separated"
        '        radCivilstat.Value = "Separated"
        'End Select

        'radioProfession.Value = cLoader_CTCValues._pOccupation

        Dim _nSqlCmd As New SqlCommand
        Dim _mRdr As SqlDataReader

        'BPLTAS LIVE
        Dim _nClBP As New cDalGlobalConnectionsDefault
        _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
        _nClBP._pSetupGlobalConnectionsDatabases = "OAIMS"
        _nClBP._pSubRecordSelectSpecific()

        Dim _nOAIMSServerName As String = _nClBP._pDBDataSource
        Dim _nOAIMSDatabaseName As String = _nClBP._pDBInitialCatalog

        'Dim _nClass As New cDal_IUD
        'With _nClass
        '._pSqlCon = cGlobalConnections._pSqlCxn_TIMS
        '._pAction = "SELECT"
        '._pSelect = "Select  IDNo,LastName, FirstName, MiddleName, ExtnName, BirthDate, BirthPlace, [Address], Profession, TIN, Gender, CivilStatus, Citizenship, Height, Weight"
        '._pCondition = "from   [" & _nOAIMSServerName & "].[" & _nOAIMSDatabaseName & "].dbo.Registered where UserID = ''" & cSessionUser._pUserID & "'' "
        '._pExec(_nSuccessful, _nErrMsg)

        _nSqlCmd = New SqlCommand("Select IDNo,LastName, FirstName, MiddleName, ExtnName, BirthDate, BirthPlace, [Address], Profession, TIN, Gender, CivilStatus, Citizenship, Height, Weight from   [" & _nOAIMSServerName & "].[" & _nOAIMSDatabaseName & "].dbo.Registered where UserID = '" & cSessionUser._pUserID & "' ", cGlobalConnections._pSqlCxn_TIMS)
        _mRdr = _nSqlCmd.ExecuteReader
        _mRdr.Read()
        If _mRdr.HasRows Then
            _oTxtLastName.Value = _mRdr.Item("LastName").ToString
            _oTxtMiddleName.Value = _mRdr.Item("MiddleName").ToString
            _oTxtFirstName.Value = _mRdr.Item("FirstName").ToString
            _oTxtAddress.Value = _mRdr.Item("Address").ToString
            radGender.Value = _mRdr.Item("Gender").ToString
            _oTxtHeight.Value = _mRdr.Item("Height").ToString
            _oTxtWeight.Value = _mRdr.Item("Weight").ToString
            Dim _nBDate As Date = _mRdr.Item("BirthDate")
            _oTxtBirthDate.Value = _nBDate.ToShortDateString

            _oTxtBirthPlace.Value = _mRdr.Item("BirthPlace").ToString
            _oTxtTIN.Value = _mRdr.Item("TIN").ToString

            radCitizenship.Value = _mRdr.Item("Citizenship").ToString

            Dim _nStatus As String = _mRdr.Item("CivilStatus").ToString

            Select Case _nStatus
                Case Is = "Single"
                    radCivilstat.Value = "Single"
                Case Is = "Married"
                    radCivilstat.Value = "Married"
                Case Is = "Divorced"
                    radCivilstat.Value = "Divorced"
                Case Is = "Separated"
                    radCivilstat.Value = "Separated"
            End Select

            radioProfession.Value = _mRdr.Item("Profession").ToString
        End If

        _nSqlCmd.Dispose()
        _mRdr.Dispose()

        If radioProfession.Value <> "" Then

            _oTxtSalary.Disabled = False
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

        End If

        'If radioProfession.Value = "" Then

        '    If _oTxtBusinessIncome.Value <> "0.00" Or _oTxtBusinessIncome.Value <> "" Then
        '        _oLblKindly.Visible = False
        '    End If
        '    If _oTxtBusinessIncome.Value = "0.00" Or _oTxtBusinessIncome.Value <> "0.00" = "" Then
        '        _oLblKindly.Visible = True
        '    End If
        'End If

        'If radioProfession.Value <> "" Then

        '    If _oTxtBusinessIncome.Value <> "0.00" Or _oTxtBusinessIncome.Value <> "" Then
        '        _oLblKindly.Visible = False
        '    End If

        '    If _oTxtBusinessIncome.Value = "0.00" Or _oTxtBusinessIncome.Value = "" Then
        '        _oLblKindly.Visible = True
        '    End If

        '    If _oTxtSalary.Value <> "0.00" Or _oTxtSalary.Value <> "" Then
        '        _oLblKindly.Visible = False
        '    End If

        '    If _oTxtSalary.Value = "0.00" Or _oTxtSalary.Value = "" Then
        '        _oLblKindly.Visible = True
        '    End If
        'End If

        'If chkSelect.Checked = True And radioProfession.Value <> "" Then

        '    If _oTxtPropertySale.Value <> "0.00" Or _oTxtPropertySale.Value <> "" Then
        '        _oLblKindly.Visible = False
        '    End If

        '    If _oTxtPropertySale.Value = "0.00" Or _oTxtPropertySale.Value = "" Then
        '        _oLblKindly.Visible = True
        '    End If
        'End If
    End Sub

    Private Sub GetUserInfor()
        Try
            Dim _nSuccessful As Boolean, _nErrMsg As String = Nothing
            Dim _nSqlCmd As New SqlCommand
            Dim _mRdr As SqlDataReader

            'BPLTAS LIVE
            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "OAIMS"
            _nClBP._pSubRecordSelectSpecific()

            Dim _nOAIMSServerName As String = _nClBP._pDBDataSource
            Dim _nOAIMSDatabaseName As String = _nClBP._pDBInitialCatalog

            'Dim _nClass As New cDal_IUD
            'With _nClass
            '._pSqlCon = cGlobalConnections._pSqlCxn_TIMS
            '._pAction = "SELECT"
            '._pSelect = "Select  IDNo,LastName, FirstName, MiddleName, ExtnName, BirthDate, BirthPlace, [Address], Profession, TIN, Gender, CivilStatus, Citizenship, Height, Weight"
            '._pCondition = "from   [" & _nOAIMSServerName & "].[" & _nOAIMSDatabaseName & "].dbo.Registered where UserID = ''" & cSessionUser._pUserID & "'' "
            '._pExec(_nSuccessful, _nErrMsg)

            _nSqlCmd = New SqlCommand("Select IDNo,LastName, FirstName, MiddleName, ExtnName, BirthDate, BirthPlace, [Address], Profession, TIN, Gender, CivilStatus, Citizenship, Height, Weight from   [" & _nOAIMSServerName & "].[" & _nOAIMSDatabaseName & "].dbo.Registered where UserID = ''" & cSessionUser._pUserID & "'' ", cGlobalConnections._pSqlCxn_TIMS)
            _mRdr = _nSqlCmd.ExecuteReader
            _mRdr.Read()
            If _mRdr.HasRows Then
                cLoader_CTCValues._pLastName = _mRdr.Item("LastName").ToString
                cLoader_CTCValues._pMiddleName = _mRdr.Item("MiddleName").ToString
                cLoader_CTCValues._pFirstName = _mRdr.Item("FirstName").ToString
                cLoader_CTCValues._pAddress = _mRdr.Item("Address").ToString
                cLoader_CTCValues._pGender = _mRdr.Item("Gender").ToString
                cLoader_CTCValues._pHeight = _mRdr.Item("Height").ToString
                cLoader_CTCValues._pWeight = _mRdr.Item("Weight").ToString
                Dim _nBDate As Date = _mRdr.Item("BirthDate")
                cLoader_CTCValues._pBirthDate = _nBDate.ToShortDateString

                cLoader_CTCValues._pBirthPlace = _mRdr.Item("BirthPlace").ToString
                cLoader_CTCValues._pTIN = _mRdr.Item("TIN").ToString

                cLoader_CTCValues._pCitizenship = _mRdr.Item("Citizenship").ToString

                Dim _nStatus As String = _mRdr.Item("CivilStatus").ToString

                Select Case _nStatus
                    Case Is = "Single"
                        cLoader_CTCValues._pCivilStatus = "Single"
                    Case Is = "Married"
                        cLoader_CTCValues._pCivilStatus = "Married"
                    Case Is = "Divorced"
                        cLoader_CTCValues._pCivilStatus = "Divorced"
                    Case Is = "Separated"
                        cLoader_CTCValues._pCivilStatus = "Separated"
                End Select

                cLoader_CTCValues._pOccupation = _mRdr.Item("Profession").ToString
            End If

            _nSqlCmd.Dispose()
            _mRdr.Dispose()

            'Dim _nDataTable As New DataTable
            '_nDataTable = ._pDataTable

            'If _nDataTable.Rows.Count > 0 Then

            '    cLoader_CTCValues._pLastName = _nDataTable.Rows("0").Item("LastName").ToString
            '    cLoader_CTCValues._pMiddleName = _nDataTable.Rows("0").Item("MiddleName").ToString
            '    cLoader_CTCValues._pFirstName = _nDataTable.Rows("0").Item("FirstName").ToString
            '    cLoader_CTCValues._pAddress = _nDataTable.Rows("0").Item("Address").ToString
            '    cLoader_CTCValues._pGender = _nDataTable.Rows("0").Item("Gender").ToString
            '    cLoader_CTCValues._pHeight = _nDataTable.Rows("0").Item("Height").ToString
            '    cLoader_CTCValues._pWeight = _nDataTable.Rows("0").Item("Weight").ToString
            '    Dim _nBDate As Date = _nDataTable.Rows("0").Item("BirthDate")
            '    cLoader_CTCValues._pBirthDate = _nBDate.ToShortDateString

            '    cLoader_CTCValues._pBirthPlace = _nDataTable.Rows("0").Item("BirthPlace").ToString
            '    cLoader_CTCValues._pTIN = _nDataTable.Rows("0").Item("TIN").ToString

            '    cLoader_CTCValues._pCitizenship = _nDataTable.Rows("0").Item("Citizenship").ToString

            '    Dim _nStatus As String = _nDataTable.Rows("0").Item("CivilStatus").ToString

            '    Select Case _nStatus
            '        Case Is = "Single"
            '            cLoader_CTCValues._pCivilStatus = "Single"
            '        Case Is = "Married"
            '            cLoader_CTCValues._pCivilStatus = "Married"
            '        Case Is = "Divorced"
            '            cLoader_CTCValues._pCivilStatus = "Divorced"
            '        Case Is = "Separated"
            '            cLoader_CTCValues._pCivilStatus = "Separated"
            '    End Select

            '    cLoader_CTCValues._pOccupation = _nDataTable.Rows("0").Item("Profession").ToString

            'If radioProfession.Value <> "" Then

            '    _oTxtSalary.Disabled = False
            '    Dim Bus As Double = 0.0
            '    Dim Sal As Double = 0.0
            '    Dim RP As Double = 0.0

            '    Dim Basic As Double = 5.5

            '    Dim Month As Integer = CInt(DateTime.Now.Month.ToString())
            '    Dim Penalty As Double = 0.02 * (Month)

            '    Dim TotGross As Double = Bus + Sal + RP

            '    Dim Remainder As Double = TotGross Mod 1000
            '    Dim Subtract As Double = TotGross - Remainder
            '    Dim quotient As Double = Subtract / 1000

            '    Dim TaxDue As Double = quotient

            '    Dim ComputedTaxDue As Double = TaxDue + Basic
            '    Dim Interest As Double = ComputedTaxDue * Penalty
            '    Dim tot_amount As Double = TaxDue + Basic + Interest

            '    AmountToPay.Value = tot_amount



            'End If

            'End If
            'End With
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
            'If _oTxtBusinessIncome.Value = "" Then Exit Sub
            If _oTxtFirstName.Value = "" Then Exit Sub

            If _oTxtLastName.Value = "" Then Exit Sub
            'If _oTxtMiddleName.Value = "" Then Exit Sub
            'If _oTxtPropertySale.Value = "" Then Exit Sub
            'If _oTxtSalary.Value = "" Then Exit Sub
            If _oTxtTIN.Value = "" Then Exit Sub

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
            'cSessionLoader._pAccountNo = cLoader_CTCApp._pControlNo 'unique
            'cSessionLoader._pType = IndCorp '"CEDULA INDIVIDUAL" 'unique
            'cSessionLoader._pTotalAmountDue = cLoader_CTCApp._pTotAmount 'totamount
            'cSessionLoader._pTotalAmountDue = Format(cSessionLoader._pTotalAmountDue, "STANDARD")
            'cSessionLoader._pService = "CTC" 'CTC            
            'Response.Redirect("PayNow.aspx")
            Dim _nClassGetDate As New cDalGetDate
            _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            PayNow2.ACCTNO = cLoader_CTCApp._pControlNo
            PayNow2.BillingValidityDate = _nClassGetDate._GetEndOfDay_2 '_nClassGetDate._GetEndOfDay("MMMM dd, yyyy hh:mm tt")
            PayNow2.Email = cSessionUser._pUserID
            PayNow2.FNAME = cSessionUser._pFirstName
            PayNow2.LNAME = cSessionUser._pLastName
            PayNow2.MNAME = cSessionUser._pMiddleName
            PayNow2.OtherFee = 0.0
            PayNow2.RawAmount = cLoader_CTCApp._pTotAmount
            PayNow2.SpidcFEE = 0.0
            PayNow2.SUFFIX = Nothing
            PayNow2.TotalAmount = cLoader_CTCApp._pTotAmount
            PayNow2.TransactionType = "CTC"
            PayNow2.URL_Origin = HttpContext.Current.Request.Url.AbsoluteUri
            Response.Redirect("PayNow2.aspx")


            Exit Sub
        Else

            Exit Sub
        End If

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

End Class