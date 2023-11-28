Public Class WSPCedula
    Inherits System.Web.UI.Page
    Dim FormUse_Individual As String = "BF0016"
    Dim FormUse_Corporation As String = "BF907"
    Dim BasicAmount_Individual As Double
    Dim BasicAmount_Corporation As Double
    Dim Gross_Multiplier_Individual As Double
    Dim Gross_Multiplier_Corporation As Double
    Dim Interest_Multiplier As Double
    Dim NewBP_MinAmount As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Check Connectivity to TOIMS
        Dim err As String = Nothing
        Dim _nClass As New cDalNewCedula
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TOIMS(err)
        If err = Nothing Then
            div_Connectivity.Style.Add("display", "none")
            div_container.Style.Add("display", "block")
        Else
            div_Connectivity.Style.Add("display", "block")
            div_container.Style.Add("display", "none")
            Exit Sub
        End If
        get_Basic()
    End Sub
   
    Sub get_Basic()
        Dim _nClass As New cDalNewCedula
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TOIMS
        _nClass._pSubGetBasicAmount("Individual", FormUse_Individual, BasicAmount_Individual)
        _nClass._pSubGetBasicAmount("Corporation", FormUse_Corporation, BasicAmount_Corporation)

        _nClass._pSubGetGrossMultiplier("CTCINDIVIDUAL", Gross_Multiplier_Individual)
        _nClass._pSubGetGrossMultiplier("CTCCORPORATION", Gross_Multiplier_Corporation)
        Interest_Multiplier = _nClass._pSubGetInterestMultiplier()
        NewBP_MinAmount = _nClass._pSubGetNewBPMinAmount("CTCINDIVIDUAL")
        Basic_Individual.InnerText = Format(BasicAmount_Individual, "STANDARD")
        td_Basic_Individual.InnerText = Format(BasicAmount_Individual, "STANDARD")
        hdn_Gross_Multiplier_Individual.Value = Format(Gross_Multiplier_Individual, "STANDARD")
        hdn_Basic_Individual.Value = Format(BasicAmount_Individual, "STANDARD")
        hdn_Interest_Multiplier_Individual.Value = Format(Interest_Multiplier, "STANDARD")
        hdn_NewBP_MinAmount.Value = Format(NewBP_MinAmount, "STANDARD")
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
    Private Sub btnSubmit_ServerClick(sender As Object, e As EventArgs) Handles btnSubmit.ServerClick
        Dim FName As String
        Dim MName As String
        Dim LName As String
        Dim Email As String = " "
        Dim Address As String
        Dim BirthPlace As String
        Dim BirthDate As String
        Dim Occupation As String

        Dim ControlNo As String = _FnAutoGenID("ControlNumber")
        Dim CTC_Type As String
        If hdn_Type.Value = "Individual" Then
            CTC_Type = "IND"
            FName = Trim(txtFname.Value)
            MName = Trim(txtMname.Value)
            LName = Trim(txtLname.Value)
            Address = Trim(txtAddress.Value)
            BirthPlace = Trim(txtBirthPlace.Value)
            BirthDate = txtBirthDay.Value
            Occupation = Trim(txtProfession.Value)
            If FName = Nothing Then
                snackbar("red", "First Name cannot be empty.")
                clearGross()
                Exit Sub
            End If
            If LName = Nothing Then
                snackbar("red", "Last Name cannot be empty.")
                clearGross()
                Exit Sub
            End If

            If Address = Nothing Then
                snackbar("red", "Address cannot be empty.")
                clearGross()
                Exit Sub
            End If

            If BirthPlace = Nothing Then
                snackbar("red", "Birth Place cannot be empty.")
                clearGross()
                Exit Sub
            End If

            If BirthDate = Nothing Then
                snackbar("red", "Birth Day cannot be empty.")
                clearGross()
                Exit Sub
            End If

            If txtEmploymentStatus.Value = "Employed" Then
                If Occupation = Nothing Then
                    snackbar("red", "Profession cannot be empty.")
                    clearGross()
                    Exit Sub
                End If
            End If
          


        End If


        If hdn_Type.Value = "Corporation" Then CTC_Type = "CORP"

        Dim OrgKind As String = " "



        Dim CivilStatus As String = txtCivilStatus.Value
        Dim Citizenship As String = txtCitizenship.Value
        Dim Gender As String = txtGender.Value

        Dim TIN As String = IIf(txtTIN.Value = "", "000-000-000-000", txtTIN.Value)
        Dim BusIncome As String = hdn_B1_Individual.Value
        Dim ProfIncome As String = hdn_B2_Individual.Value
        Dim RPTIncome As String = hdn_B3_Individual.Value
        Dim BasicAmount As String = hdn_Basic_Individual.Value
        Dim TaxAmount As String = hdn_B4_Individual.Value
        Dim Penalty As String = hdn_B5_Individual.Value
        Dim DelFee As String = 0
        Dim TotAmount As String = hdn_B6_Individual.Value
        Dim Status As String = "Pending"
        Dim RefNo As String = ControlNo
        Dim Height As String = IIf(txtHeight.Value = "", "0", txtHeight.Value)
        Dim Weight As String = IIf(txtWeight.Value = "", "0", txtWeight.Value)

        Dim OTC As String = 1

        Dim _nClass As New cDalNewCedula
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
        _nClass._pSubInsertCedula(Email, ControlNo, CTC_Type, FName, MName, LName, OrgKind, Address, BirthPlace, BirthDate, CivilStatus, Citizenship, Gender, Occupation, TIN, BusIncome, ProfIncome, RPTIncome, BasicAmount, TaxAmount, Penalty, DelFee, TotAmount, Status, RefNo, Height, Weight, OTC)
        tdAmounttoPay.InnerText = TotAmount
        tdCedulaType.InnerText = hdn_Type.Value
        tdNewBusiness.InnerText = hdn_NewBP.Value
        tdControlNo.InnerText = ControlNo
        If hdn_Type.Value = "Individual" Then
            tdName.InnerText = LName & ", " & FName & " " & MName
        Else
            tdName.InnerText = Nothing  ' companyname
        End If
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup1", " addLoadEvent(openModalComplete());", True)

    End Sub

    Sub clearGross()
        txtGrossRB.Value = 0
        txtGrossRP.Value = 0
        txtGrossSalary.Value = 0
        hdn_NewBP.Value = "False"
    End Sub

    Private Sub btnDone_ServerClick(sender As Object, e As EventArgs) Handles btnDone.ServerClick
        'clear all
        'refresh Page
        Response.Redirect(Request.RawUrl)
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
End Class