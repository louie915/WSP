Public Class RPTInformation
    Inherits System.Web.UI.Page

    '  Dim usertmp As String = cCookieUser._pUserID.Replace(".", "")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Me.IsPostBack Then
        '    Dim dt As New DataTable()
        '    dt.Columns.AddRange(New DataColumn() {New DataColumn("Id", GetType(Integer)), _
        '                                           New DataColumn("Name", GetType(String)), _
        '                                           New DataColumn("Country", GetType(String))})
        '    dt.Rows.Add(1, "John Hammond", "United States")
        '    _oGVRpt.DataSource = dt
        '    _oGVRpt.DataBind()
        'End If

        Try
            '----------------------------------
            If Not IsPostBack Then
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                End If

                Try
                    _mGetInformation()
                Catch ex As Exception
                    Response.Write("<script>alert('_mGetInformation: " & ex.Message & "')</script>")
                End Try
                Try
                    _mGetInformationAssessment()
                Catch ex As Exception
                    Response.Write("<script>alert('_mGetInformationAssessment: " & ex.Message & "')</script>")
                End Try
                Try
                    _mGetPrevInformation()
                Catch ex As Exception
                    Response.Write("<script>alert('_mGetPrevInformation: " & ex.Message & "')</script>")
                End Try
                Try
                    _mGetInformationPay()
                Catch ex As Exception
                    Response.Write("<script>alert('_mGetInformationPay: " & ex.Message & "')</script>")
                End Try



            Else
             


            End If
            '----------------------------------
        Catch ex As Exception


        End Try
    End Sub
    Private Sub _mGetInformation()

        Dim _nClass As New cDalPDSRPTAS
        Dim _mdatatable As New DataTable
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
        _nClass._pTDN = cSessionLoader._pTDN

        _nClass._pSubRptInformation()
        _mdatatable = _nClass._pDataTable
        _oTxtTaxDecNo.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("TDN")), "", _mdatatable.Rows(0).Item("TDN"))
        _oTxtPropertyIdentificationNumber.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("PIN")), "", _mdatatable.Rows(0).Item("PIN"))
        _oTxtUpdatedCd.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("TRANS_CD")), "", _mdatatable.Rows(0).Item("TRANS_CD"))
        _oTxtPropOwner.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("OWNERNAME")), "", _mdatatable.Rows(0).Item("OWNERNAME"))
        _oTxtTIN1.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("OWNERTIN")), "", _mdatatable.Rows(0).Item("OWNERTIN"))
        _oTxtOwnerAddress.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("OWNERADDRESS")), "", _mdatatable.Rows(0).Item("OWNERADDRESS"))
        _oTxtOwnerTelNo.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("OWNERTELNO")), "", _mdatatable.Rows(0).Item("OWNERTELNO"))
        _oTxtAdministrator.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("ADMNAME")), "", _mdatatable.Rows(0).Item("ADMNAME"))
        _oTxtTIN2.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("ADMINTIN")), "", _mdatatable.Rows(0).Item("ADMINTIN"))
        _oTxtAdminAddress.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("ADMADDRESS")), "", _mdatatable.Rows(0).Item("ADMADDRESS"))
        _oTxtAdminTelNo.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("ADMTELNO")), "", _mdatatable.Rows(0).Item("ADMTELNO"))
        _oTxtNoSt.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("LOCATION")), "", _mdatatable.Rows(0).Item("LOCATION"))
        _oTxtBarangay.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("BARANGAY")), "", _mdatatable.Rows(0).Item("BARANGAY"))
        _oTxtOCT_TCT.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("TCT")), "", _mdatatable.Rows(0).Item("TCT"))
        _oTxtOCTDate.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("TCT_DATE")), "", _mdatatable.Rows(0).Item("TCT_DATE"))
        _oTxtSurveyNo.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("SURVEYNO")), "", _mdatatable.Rows(0).Item("SURVEYNO"))
        _oTxtCCT.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("TCT")), "", _mdatatable.Rows(0).Item("TCT"))
        _TxtCCTDate.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("TCT_DATE")), "", _mdatatable.Rows(0).Item("TCT_DATE"))
        _TxtLotNo.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("LOTE_NO")), "", _mdatatable.Rows(0).Item("LOTE_NO"))
        _oTxtBlockNo.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("BLOCK_NO")), "", _mdatatable.Rows(0).Item("BLOCK_NO"))
        _oTxtNorth.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("NORTH")), "", _mdatatable.Rows(0).Item("NORTH"))
        _oTxtSouth.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("SOUTH")), "", _mdatatable.Rows(0).Item("SOUTH"))
        _oTxtEast.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("EAST")), "", _mdatatable.Rows(0).Item("EAST"))
        _oTxtWest.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("WEST")), "", _mdatatable.Rows(0).Item("WEST"))
         


        Try
            '----------------------------------


        Catch ex As Exception


        End Try
        '----------------------------------

    End Sub
    Private Sub _mGetPrevInformation()

        Dim _nClass As New cDalPDSRPTAS
        Dim _mdatatable As New DataTable
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
        _nClass._pTDN = cSessionLoader._pTDN

        _nClass._pSubRptPrevInformation()
        _mdatatable = _nClass._pDataTable
        _oTxtPrevTDN.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("CANCELS")), "", _mdatatable.Rows(0).Item("CANCELS"))
        _oTxtPrevPIN.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("PIN")), "", _mdatatable.Rows(0).Item("PIN"))
        _oTxtPrevAss.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("Pass_value")), "", _mdatatable.Rows(0).Item("Pass_value"))
        _oTxtPrevOwner.Value = IIf(IsDBNull(_mdatatable.Rows(0).Item("Name")), "", _mdatatable.Rows(0).Item("Name"))
         


        Try
            '----------------------------------


        Catch ex As Exception


        End Try
        '----------------------------------

    End Sub
    Private Sub _mGetInformationAssessment()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = _oGVRPT
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            ' _nClass._pUserID = cCookieUser._pUserID.Replace(".", "")
            ' _nClass._pSubSelect()


            'usertmp = cCookieUser._pUserID.Replace(".", "")
            _nClass._pTDN = cSessionLoader._pTDN
            '_nClass._pUseTableTmpBill = "tmp0001" & usertmp & "_" & cPageSession_Billing_EntryView._pOrigSrvDateValue
            '_nClass._pEmail = usertmp
            _nClass._pSubRptInformationAssessment()

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
                    Dim KND As String
                    KND = IIf(IsDBNull(_nDataTable.Rows(0).Item("KIND")), "", _nDataTable.Rows(0).Item("KIND"))
                    If KND = "Land" Then
                        _oCbLand.Checked = True
                    ElseIf KND = "Building" Then
                        _oCbBuilding.Checked = True
                    ElseIf KND = "Machinery" Then
                        _oCbMachinery.Checked = True
                    Else
                        _oCbOthers.Checked = True
                    End If
                Else
                    '   snackbar("red", "No Records Found.")
                End If
                '----------------------------------
            Catch ex As Exception
                '  snackbar("red", ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try
    End Sub
    Private Sub _mGetInformationPay()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = _oGVRPTPay
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            ' _nClass._pUserID = cCookieUser._pUserID.Replace(".", "")
            ' _nClass._pSubSelect()


            'usertmp = cCookieUser._pUserID.Replace(".", "")
            _nClass._pTDN = cSessionLoader._pTDN
            '_nClass._pUseTableTmpBill = "tmp0001" & usertmp & "_" & cPageSession_Billing_EntryView._pOrigSrvDateValue
            '_nClass._pEmail = usertmp
            _nClass._pSubRptInformationPay()

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
                    '   snackbar("red", "No Records Found.")
                End If
                '----------------------------------
            Catch ex As Exception
                '  snackbar("red", ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try
    End Sub


    Private Sub _obtnPrintStatement_ServerClick(sender As Object, e As EventArgs) Handles _obtnPrint.ServerClick
        Try

            '' Display report in New Tab
            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=RPTAXDEC" + "&TDN=" + cSessionLoader._pTDN + "','_blank');</script>")

            '' Display report in Current Tab
            Catch ex As Exception

        End Try

    End Sub
End Class