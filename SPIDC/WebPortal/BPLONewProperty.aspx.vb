Public Class BPLONewProperty
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")
            If Not IsPostBack Then


            Else
                If action = "ViewDetails" Then
                    View_Details()
                End If
            End If
            Get_Property()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Get_Property()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = _oGVProperty
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalNewProperty
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pSubSelect("[RPTASMastNew]", "order by propid asc")

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()
                Else
                    ' snackbar("red", "No Records Found.")
                End If
                '----------------------------------
            Catch ex As Exception
                'snackbar("red", ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try
    End Sub
    Private Sub View_Details()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = _oGVProperty
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalNewProperty
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            _nClass._pEmail = cSessionUser._pUserID.Replace(".", "")
            _nClass._pUserID = hdnuserid.Value
            _nClass._pPropID = hdnpropid.Value
            _nClass._pSubSelect("[RPTASMastNew]", "order by propid asc")

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable
            _oTxtOwner.Value = _nDataTable.Rows(0)("OwnerName").ToString()
            _oTxtOwnerAddress.Value = _nDataTable.Rows(0)("OwnerAddress").ToString()
            _oTxtAdministrator.Value = _nDataTable.Rows(0)("Administrator").ToString()
            _oTxtAdminAddress.Value = _nDataTable.Rows(0)("AdministratorAddress").ToString()
            _oTxtNoSt.Value = _nDataTable.Rows(0)("Locproperty").ToString()
            _oTxtBarangay.Value = _nDataTable.Rows(0)("Brgy").ToString()
            _oTxtDistrict.Value = _nDataTable.Rows(0)("District").ToString()
            _oTxtOCT_TCT.Value = _nDataTable.Rows(0)("OCT").ToString()
            _oTxtSurveyNo.Value = _nDataTable.Rows(0)("SurveyNo").ToString()
            _TxtLotNo.Value = _nDataTable.Rows(0)("LotNo").ToString()
            _oTxtBlockNo.Value = _nDataTable.Rows(0)("BlkNo").ToString()
            _oTxtArea.Value = _nDataTable.Rows(0)("Area").ToString()
            _oTxtAmountSold.Value = _nDataTable.Rows(0)("AmountSold").ToString()
            _oTxtResidentialArea.Value = _nDataTable.Rows(0)("Residential").ToString()
            _oTxtCommercialArea.Value = _nDataTable.Rows(0)("Commercial").ToString()
            _oTxtDeedofsale.Value = _nDataTable.Rows(0)("DeedSaleName").ToString()
            _oTxtCopyofTitle.Value = _nDataTable.Rows(0)("CopyTitleName").ToString()
            _oTxtProofofPayment.Value = _nDataTable.Rows(0)("ProofPaymentName").ToString()
            _oTxtTaxClearance.Value = _nDataTable.Rows(0)("TaxClearanceName").ToString()
            _oTxtDeclarationCopy.Value = _nDataTable.Rows(0)("DeclarationCopyName").ToString()
            _oTxtCorporateProperty.Value = _nDataTable.Rows(0)("CorpPropName").ToString()
            _oTxtValidID.Value = _nDataTable.Rows(0)("ValididName").ToString()
            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()
                Else
                    ' snackbar("red", "No Records Found.")
                End If
                '----------------------------------
                _nClass._pUserID = Nothing
                _nClass._pPropID = Nothing
            Catch ex As Exception
                'snackbar("red", ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try
    End Sub
End Class