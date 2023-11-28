Public Class NewProperty
    Inherits System.Web.UI.Page
    Dim _nSuccessful As Boolean
    Dim _nErrMsg As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'snackbar("green", "Welcome")
        If IsPostBack Then
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "Save" Then
                _oSave()
            End If
        End If
    End Sub
    Private Sub _oSave()
        Try
            _PassValuetoLoader()
            _SaveInformation(_nSuccessful, _nErrMsg)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub _PassValuetoLoader()
        Try
            'cLoader_NewProperty._pTDN = _oTxtTaxDecNo.Value
            'cLoader_NewProperty._pPIN = _oTxtPropertyIdentificationNumber.Value
            'cLoader_NewProperty._pCCN = _oTxtCCN.Value
            cDalNewProperty._pOwnerName = _oTxtOwner.Value
            cDalNewProperty._pOwnerAddress = _oTxtOwnerAddress.Value
            cDalNewProperty._pAdministrator = _oTxtAdministrator.Value
            cDalNewProperty._pAdministratorAddress = _oTxtAdminAddress.Value
            cDalNewProperty._pLocProperty = _oTxtNoSt.Value
            cDalNewProperty._pBrgy = _oTxtBarangay.Value
            cDalNewProperty._pDistrict = _oTxtDistrict.Value
            cDalNewProperty._pOCT = _oTxtOCT_TCT.Value
            cDalNewProperty._pSurveyNo = _oTxtSurveyNo.Value
            cDalNewProperty._pLotNo = _TxtLotNo.Value
            cDalNewProperty._pBlkNo = _oTxtBlockNo.Value
            'cLoader_NewProperty._pNorth = _oTxtNorth.Value
            'cLoader_NewProperty._pSouth = _oTxtSouth.Value
            'cLoader_NewProperty._pEast = _oTxtEast.Value
            'cLoader_NewProperty._pWest = _oTxtWest.Value
            cDalNewProperty._pArea = _oTxtArea.Value
            cDalNewProperty._pAmountSold = _oTxtAmountSold.Value
            cDalNewProperty._pResidential = _oTxtResidentialArea.Value
            cDalNewProperty._pCommercial = _oTxtCommercialArea.Value
            cDalNewProperty._pIndustrial = _oTxtIndustrial.Value
            cDalNewProperty._pAgricultural = _oTxtAgricultural.Value
            cDalNewProperty._pMineral = _oTxtMineral.Value
            cDalNewProperty._pSpecial = _oTxtSpecial.Value
            cDalNewProperty._pTimberland = _oTxtTimberland.Value
            cDalNewProperty._pCityMunicipality = _oTxtCityMunicipality.Value
            cDalNewProperty._pProvince = _oTxtProvince.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub _SaveInformation(ByRef _nSuccessful As Boolean, Optional ByRef _nErrMsg As String = Nothing)
        Try
            Dim _nclass As New cDalNewProperty
            _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nclass._pSubInsertAttachFiles()
            snackbar("green", "Record Saved!")
            Response.AddHeader("REFRESH", "3;URL=Account.aspx")
               Catch ex As Exception

        End Try

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