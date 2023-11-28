Partial Public Class BPLONewBP_ForApplicationNo

    

    'Private Sub _oGridViewOption_SelectedIndexChanged(sender As Object, e As System.EventArgs) _
    '    Handles _oGridViewOption.SelectedIndexChanged

    '    Try
    '        '----------------------------------


    '        ShowPopup()

    '        Dim _nGridView As GridView = DirectCast(sender, GridView)


    '        If _nGridView.Rows.Count <= 0 Then
    '            Return
    '        End If

    '        If _nGridView.SelectedRow IsNot Nothing Then
    '            '_mpAsk.Show()
    '            cPageSession_BusinessLine._pRowCountBuslineOption = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
    '            cPageSession_BusinessLine._pOptionTaxCode = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
    '            cPageSession_BusinessLine._pOptionBusDesc = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelOption"), Label).Text)
    '            cPageSession_BusinessLine._pOptionTaxCode2 = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxCode2"), Label).Text)
    '            cPageSession_BusinessLine._pOptionTaxRate = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxRate"), Label).Text)
    '            cPageSession_BusinessLine._pOptionTaxAmt = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
    '            ''''''   Added   20170511
    '            cPageSession_BusinessLine._pEff_Month = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelEff_Month"), Label).Text)
    '            cPageSession_BusinessLine._pEff_Year = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
    '            ''''''   Added   20170616
    '            Select Case True

    '                Case cPageSession_BusinessLine._pELECCODE
    '                    cPageSession_BusinessLine._pELECCODE_FEE = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
    '                Case cPageSession_BusinessLine._pMECHCODE
    '                    cPageSession_BusinessLine._pMECHCODE_FEE = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
    '                Case cPageSession_BusinessLine._pBLDGCODE
    '                    cPageSession_BusinessLine._pBLDGCODE_FEE = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
    '                Case cPageSession_BusinessLine._pSIGNCODE
    '                    cPageSession_BusinessLine._pSIGNCODE_FEE = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
    '                Case cPageSession_BusinessLine._pEPOCODE
    '                    cPageSession_BusinessLine._pEPOCODE_FEE = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
    '                Case cPageSession_BusinessLine._pEIFCODE
    '                    cPageSession_BusinessLine._pEIFCODE_FEE = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)
    '                Case cPageSession_BusinessLine._pPLATECODE
    '                    cPageSession_BusinessLine._pPLATECODE_FEE = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxAmt"), Label).Text)

    '                Case cPageSession_BusinessLine._pBCODE
    '                    cPageSession_BusinessLine._pBCODE_Option_RowNo = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
    '                    cPageSession_BusinessLine._pBCODE_Option_TaxCode = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
    '                    cPageSession_BusinessLine._pBCODE_Option_TaxDesc = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelOption"), Label).Text)
    '                    cPageSession_BusinessLine._pBCODE_Option_TaxYear = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
    '                    cPageSession_BusinessLine._pBCHOICE_trg = True
    '                Case cPageSession_BusinessLine._pMCODE
    '                    cPageSession_BusinessLine._pMCODE_Option_RowNo = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
    '                    cPageSession_BusinessLine._pMCODE_Option_TaxCode = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
    '                    cPageSession_BusinessLine._pMCODE_Option_TaxDesc = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelOption"), Label).Text)
    '                    cPageSession_BusinessLine._pMCODE_Option_TaxYear = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
    '                    cPageSession_BusinessLine._pMCHOICE_trg = True
    '                Case cPageSession_BusinessLine._pGCODE
    '                    cPageSession_BusinessLine._pGCODE_Option_RowNo = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
    '                    cPageSession_BusinessLine._pGCODE_Option_TaxCode = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
    '                    cPageSession_BusinessLine._pGCODE_Option_TaxDesc = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelOption"), Label).Text)
    '                    cPageSession_BusinessLine._pGCODE_Option_TaxYear = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
    '                    cPageSession_BusinessLine._pGCHOICE_trg = True
    '                Case cPageSession_BusinessLine._pSCODE
    '                    cPageSession_BusinessLine._pSCODE_Option_RowNo = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
    '                    cPageSession_BusinessLine._pSCODE_Option_TaxCode = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
    '                    cPageSession_BusinessLine._pSCODE_Option_TaxDesc = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelOption"), Label).Text)
    '                    cPageSession_BusinessLine._pSCODE_Option_TaxYear = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
    '                    cPageSession_BusinessLine._pSCHOICE_trg = True
    '                Case cPageSession_BusinessLine._pFCODE
    '                    cPageSession_BusinessLine._pFCODE_Option_RowNo = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelRowNo"), Label).Text)
    '                    cPageSession_BusinessLine._pFCODE_Option_TaxCode = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelTaxCode"), Label).Text)
    '                    cPageSession_BusinessLine._pFCODE_Option_TaxDesc = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelOption"), Label).Text)
    '                    cPageSession_BusinessLine._pFCODE_Option_TaxYear = Trim(DirectCast(_nGridView.SelectedRow.FindControl("_oLabelEff_Year"), Label).Text)
    '                    cPageSession_BusinessLine._pFCHOICE_trg = True
    '            End Select

    '        Else

    '        End If
    '        '----------------------------------
    '    Catch ex As Exception

    '    End Try

    'End Sub

    



End Class
