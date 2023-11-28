Imports System.Data.SqlClient
Imports ZXing
Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.IO
Imports QRCoder
Imports System.Web.HttpContext
Imports System.Threading.Tasks

Public Class eOR_Jaka
    Private _DataTable As DataTable
    Public Shared email As String = Nothing
    Private _mSqlCon As SqlConnection
    ' Public Shared Gateway As String = Nothing
    'Public Shared Gateway_Fee As String = Nothing
    'Public Shared Gateway_RefNo As String = Nothing
    'Public Shared Gateway_ConfDate As String = Nothing
    'Public Shared SPIDC_RefNo As String = Nothing
    'Public Shared SPIDC_Fee As String = Nothing
    'Public Shared Bill_Amount As String = Nothing
    'Public Shared GrandTotal As String = Nothing
    'Public Shared AssessNo As String = Nothing

    Public _eORNO As String
    Public _SRS As String
    Public _OR_NO As String
    Public _Book_No As String
    Public __USER As String
    Public _Gateway As String
    Public _or_date As String
    Public _PaymentRefNo As String

#Region "Variables"
    Private Const _sscPrefix As String = "eOR."
    Private Const _sscGateway As String = _sscPrefix & "_sscGateway"
    Private Const _sscGateway_Fee As String = _sscPrefix & "_sscGateway_Fee"
    Private Const _sscGateway_RefNo As String = _sscPrefix & "_sscGateway_RefNo"
    Private Const _sscGateway_ConfDate As String = _sscPrefix & "_sscGateway_ConfDate"
    Private Const _sscSPIDC_RefNo As String = _sscPrefix & "_sscSPIDC_RefNo"
    Private Const _sscSPIDC_Fee As String = _sscPrefix & "_sscSPIDC_Fee"
    Private Const _sscBill_Amount As String = _sscPrefix & "_sscBill_Amount"
    Private Const _sscGrandTotal As String = _sscPrefix & "_sscGrandTotal"
    Private Const _sscAssessNo As String = _sscPrefix & "_sscAssessNo"
    Private Const _sscTaxPayerEmail As String = _sscPrefix & "_sscTaxPayerEmail"
    Private Const _sscTDNBIN As String = _sscPrefix & "_sscTDNBIN"
#End Region

#Region "Properties"

    Shared Property TDNBIN() As String
        Get
            Return Current.Session(_sscTDNBIN)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTDNBIN) = value
        End Set
    End Property
    Shared Property TaxPayerEmail() As String
        Get
            Return Current.Session(_sscTaxPayerEmail)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTaxPayerEmail) = value
        End Set
    End Property
    Shared Property AssessNo() As String
        Get
            Return Current.Session(_sscAssessNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAssessNo) = value
        End Set
    End Property
    Shared Property GrandTotal() As String
        Get
            Return Current.Session(_sscGrandTotal)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGrandTotal) = value
        End Set
    End Property
    Shared Property Bill_Amount() As String
        Get
            Return Current.Session(_sscBill_Amount)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBill_Amount) = value
        End Set
    End Property
    Shared Property SPIDC_Fee() As String
        Get
            Return Current.Session(_sscSPIDC_Fee)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSPIDC_Fee) = value
        End Set
    End Property
    Shared Property SPIDC_RefNo() As String
        Get
            Return Current.Session(_sscSPIDC_RefNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSPIDC_RefNo) = value
        End Set
    End Property
    Shared Property Gateway_ConfDate() As String
        Get
            Return Current.Session(_sscGateway_ConfDate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGateway_ConfDate) = value
        End Set
    End Property
    Shared Property Gateway_RefNo() As String
        Get
            Return Current.Session(_sscGateway_RefNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGateway_RefNo) = value
        End Set
    End Property
    Shared Property Gateway_Fee() As String
        Get
            Return Current.Session(_sscGateway_Fee)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGateway_Fee) = value
        End Set
    End Property
    Shared Property Gateway() As String
        Get
            Return Current.Session(_sscGateway)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGateway) = value
        End Set
    End Property
#End Region

    Public Shared Function _IsEnabledEOR() As Boolean ' @ADDED 20230919 LOUIE
        _IsEnabledEOR = False
        Try
            Dim _nclassGetModules As New cDalGetModules
            Return _nclassGetModules._pSubGetAvailableModules("EOR")

            ''POST PAYMENT TO TOIMS


            '' 

        Catch ex As Exception
            Return False
        End Try
    End Function




    Public Function getTDN(ByVal assessno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "select top 1 '''' + TDN + '''' as TDN from Assess_FrmNewBilling_A where assessno='" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("TDN").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Function getTDN1(ByVal assessno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "select top 1 '''' + TDN + '''' as TDN from AssessFromBilling where assessno='" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("TDN").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public Function getTDN2(ByVal assessno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "select top 1 '''' + TDN + '''' as TDN from Assess_FrmNewBilling_B where assessno='" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("TDN").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public Function getTDN3(ByVal assessno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "select top 1 '''' + TDN + '''' as TDN from Assess_FrmNewBilling_dtls where assessno='" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("TDN").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function





    'New Addedd 11-03-2023 JAY SITJAR
    Public Function getTDNHist(ByVal assessno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "SELECT DISTINCT TDN FROM HistAssess_FrmNewBilling_A WHERE assessno='" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("TDN").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Function getTDNHist1(ByVal assessno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "SELECT DISTINCT TDN FROM HistAssessFromBilling WHERE assessno='" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("TDN").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Function getTDNHist2(ByVal assessno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "SELECT DISTINCT TDN FROM HISTAssess_FrmNewBilling_B WHERE assessno='" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("TDN").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public Function getTDNHist3(ByVal assessno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "select top 1 '''' + TDN + '''' as TDN from HISTAssess_FrmNewBilling_dtls where assessno='" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("TDN").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function


    'New Addedd 11-03-2023 JAY SITJAR
    ' Public Function moveRPTAssessmentFromHistToCurrent(ByVal assessno As String) As Boolean
    '    Try
    '        If moveRPTAssessmentFromHistToCurrent1(assessno) Then

    '            If moveRPTAssessmentFromHistToCurrent2(assessno) Then

    '                If moveRPTAssessmentFromHistToCurrent3(assessno) Then

    '                    If moveRPTAssessmentFromHistToCurrent4(assessno) Then

    '                        Return True

    '                    Else
    '                        Return False
    '                    End If

    '                Else
    '                    Return False
    '                End If

    '            Else
    '                Return False
    '            End If

    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Return False
    '    End Try

    'End Function

    Public Function moveRPTAssessmentFromHistToCurrent1(ByVal assessno As String) As Boolean
        Try
            Dim _Query As String = " INSERT INTO AssessFromBilling(AssessNo, TDN, IsMultiple, AssessDate, ValidDate, Payer, NoOfCtr, PROV, CITY, DISTRICT, Location, UnderProtest, LastQtr, LastYear, LastOR, LastDatePaid, ORNO, SRS, Trans_Condition, TYPE, Date_Paid, CashHand,isEdited, short_Amt, Tax_Credit, isSelected, UserAssess, ISFROMCOMPRO, COMPRONO, IsfrNewBill, TotalAmounttoBill, isWeb) " & _
                                   " SELECT  AssessNo, TDN, IsMultiple, AssessDate, ValidDate, Payer, NoOfCtr, PROV, CITY, DISTRICT, Location, UnderProtest, LastQtr, LastYear, LastOR, LastDatePaid, ORNO, SRS, Trans_Condition, TYPE, Date_Paid, CashHand,isEdited, short_Amt, Tax_Credit, isSelected, UserAssess, ISFROMCOMPRO, COMPRONO, IsfrNewBill, TotalAmounttoBill, isWeb FROM HistAssessFromBilling " & _
                                   " WHERE ASSESSNO = '" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            _SqlCommand.ExecuteNonQuery()
            _SqlCommand.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function moveRPTAssessmentFromHistToCurrent(ByVal assessno As String) As Boolean
        Try
            Dim _Query As String = " INSERT INTO Assess_FrmNewBilling_A(AssessNo, SEQCOUNTER, cmbkey, TDN, PIN, region, prov, city, district, BCODE, Trans_CD, eff_date, dec_date, Other_Remarks, NotOK, source_cmbkey, LastCoveredPaid, LastOR, LastSRS, LastORDate, LastYrQtrPaid, LastYrPaid, LastQtrPaid, LastAmountPaid, LastTaxCreditAmount, LastShortAmount, LastAccumTaxCreditAmount, LastAccumTaxCreditAmt_TaxDue, LastAccumTaxCreditAmt_Pen, LastTaxcreditYrQTR, NewTaxCreditAmt, StartYearQtr, StartYear, StartQtr, SetYear, SetQtr, MaxYear, MaxQtr, TotalAmount, ClassKind, PenaltyAmt, PenaltyAmtWGrantRate, NoofYrDelayed, PercentDisc, IsAbletoGrant, DateBilled, FundType, FundTypeCode, DELFEE,  COMPFEE) " & _
                                   " SELECT AssessNo, SEQCOUNTER, cmbkey, TDN, PIN, region, prov, city, district, BCODE, Trans_CD, eff_date, dec_date, Other_Remarks, NotOK, source_cmbkey, LastCoveredPaid, LastOR, LastSRS, LastORDate, LastYrQtrPaid, LastYrPaid, LastQtrPaid, LastAmountPaid, LastTaxCreditAmount, LastShortAmount, LastAccumTaxCreditAmount, LastAccumTaxCreditAmt_TaxDue, LastAccumTaxCreditAmt_Pen, LastTaxcreditYrQTR, NewTaxCreditAmt, StartYearQtr, StartYear, StartQtr, SetYear, SetQtr, MaxYear, MaxQtr, TotalAmount, ClassKind, PenaltyAmt, PenaltyAmtWGrantRate, NoofYrDelayed, PercentDisc, IsAbletoGrant, DateBilled, FundType, FundTypeCode, DELFEE,  COMPFEE FROM HistAssess_FrmNewBilling_A " & _
                                   " WHERE ASSESSNO = '" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            _SqlCommand.ExecuteNonQuery()
            _SqlCommand.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function moveRPTAssessmentFromHistToCurrent2(ByVal assessno As String) As Boolean
        Try
            Dim _Query As String = " INSERT INTO Assess_FrmNewBilling_B(AssessNo, tdn, pin, region, prov, city, district, BCode, Owner_No, Admin_No, Location, lote_no, block_no, cer_tit_no, eff_date, eff_date_InYrQtr, ENTRY_DATE_InYrQtr, DEC_DATE_InYrQtr, DATEMOVED_InYrQtr, TRANS_CD, PROPTAG, ENTRY_DATE, DEC_DATE, DATEMOVED, provincename, cityname, districtname, barangayname, ownername, adminname, owneraddress, adminaddress, cmbkey, UserID, legalbasis, WithBackTaxes, idx) " & _
                                   " SELECT AssessNo, tdn, pin, region, prov, city, district, BCode, Owner_No, Admin_No, Location, lote_no, block_no, cer_tit_no, eff_date, eff_date_InYrQtr, ENTRY_DATE_InYrQtr, DEC_DATE_InYrQtr, DATEMOVED_InYrQtr, TRANS_CD,  PROPTAG, ENTRY_DATE, DEC_DATE, DATEMOVED, provincename, cityname, districtname, barangayname, ownername, adminname, owneraddress, adminaddress, cmbkey, UserID, legalbasis, WithBackTaxes, idx " & _
                                   " from HistAssess_FrmNewBilling_B WHERE ASSESSNO = '" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            _SqlCommand.ExecuteNonQuery()
            _SqlCommand.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function moveRPTAssessmentFromHistToCurrent3(ByVal assessno As String) As Boolean
        Try
            Dim _Query As String = " INSERT INTO Assess_FrmNewBilling_dtls(AssessNo, posrec, SEQCOUNTER_BILL, isfltr, REGION, PROV, CITY, DISTRICT, TDN, SUBTDN, KIND, CLASSIFICATION, ACTUALUSE, SUBCLASS, AREA, IF_DEFAULT, SQAREA, UNITVALUE, ASSLEVEL, MV, IDLELAND, TAXABILITY, AV, EFF_DATE, DEC_DATE, TRANSCODE, cmbkey_bill, refS, refC, StartToBill_YrAndQtr, proptag, OrigTDN, OrigCmbkey, idx, cmbvalue, YrQtrToBill, YrQtr_SetBill, TaxCode, Tot_AnnualAmtPercmbvalue, TMP_TAXCREDIT, RateForAnnual, Orig_YrQtrToBill, Orig_TaxDue, Orig_PenDue, Orig_Discount, Initial_TaxDue, Initial_PenDue, Initial_Discount, PenDue_Pd, TaxDue_Pd, Amount_paid, NoDisc_PenDue, NoDisc_TaxDue, PercentDisc, Protest, IsCashOnHand, UserID, DateIss, Date_paid, Payer, Time_Posted, Date_Posted, ChckType, ChkPayee, Bank, Check_no, Check_date, CheckAmount, MOrder_no, MOrder_date, MOrder_Amt, CType, CC, PayMode, LGULevel, BillingType, Encoder, isLocked, isPaymentEdited, User_Edit, isOutsideRem, FormUse, SRS, ORNO, BookNo, CmprsNO, SchedSeq, CA_Penalty, bcode, bcode_c, owner_no, owner_no_c, CAO, isPART,  UserAssess, CostSale, OBAmnt, RCost, PPrice, RPrice, ENTRY_FEE, Short_Amt, Prev_ShortAmt, Cash_Amt, Cutoff, Tax_TAXCREDIT, Pen_TAXCREDIT, username, remarks, other_remarks, CURRASSVALUE, PREVASSVALUE, INPUTPREVASSVALUE, TOTCURRASSVALUE, TOTLASTASSVALUE, TOTPREVASSVALUE, LASTASSVALUE, ANNUALTAXDUE, TAXDUE, PENALTY, DISCOUNT, DISCOUNTREGU, DISCOUNTADV, TAXCREDIT, PREV_TAXCREDIT,  TOTALAMT, TAXABLE_OR_EXEMPT_DESC, PENALTY_RATE, DISCOUNTREGU_RATE, DISCOUNTADV_RATE, RATE_APPLIED, EffYrQtrNo_A, EffYrQtrNo_P, EffYrQtrNo_D, EffYrQtrNo_D_ADV, EffYrQtrNo_P_RATE, EffYrQtrNo_D_RATE, EffYrQtrNo_D_ADV_RATE, DELYEAR, delNoofyear, DEC_YRQTR, DEC_YR, DEC_QTR, Diff_DecDtBillDtQtr, RUNNINGQTR, RUNNINGMONTH, CurrActiveMonthInQtr, CurrBillYrQtr, StartToBill_Yr, StartToBill_Qtr, CurrBillYr, CurrBillQtr, CurrBillMonth, StartToBill_YrAndQtr_InDate, YrQtrToBill_InDate, CurrBillYrQtr_InDate, TotalAnnualPerYrQtr, AnnualRate, TaxDueRate, accu_taxcredit_taxdue, accu_taxcredit_pendue,  accu_taxcredit_total, accu_taxcredit_total_taxdue, intFundCode, tmpTotAmt, tmpPercent, tmpPartOfTotAmtA, tmpPartOfTotAmtB, RUNNINGTOTALAMT, RUNNINGTOTAL_COH, LastYRQtrPaid, EndTaxCreditYrQtr, prev_tax_taxcredit, prev_pen_taxcredit, codetype, nox, Istodelete, IsComproLstPay, IsPrtArea, IsFrmBackEnd, DELFEE, COMPFEE) " & _
                                   " SELECT AssessNo, posrec, SEQCOUNTER_BILL, isfltr, REGION, PROV, CITY, DISTRICT, TDN, SUBTDN, KIND, CLASSIFICATION, ACTUALUSE, SUBCLASS, AREA, IF_DEFAULT, SQAREA, UNITVALUE, ASSLEVEL, MV, IDLELAND, TAXABILITY, AV, EFF_DATE, DEC_DATE, TRANSCODE, cmbkey_bill, refS, refC, StartToBill_YrAndQtr, proptag, OrigTDN, OrigCmbkey, idx, cmbvalue, YrQtrToBill, YrQtr_SetBill, TaxCode, Tot_AnnualAmtPercmbvalue, TMP_TAXCREDIT, RateForAnnual, Orig_YrQtrToBill, Orig_TaxDue, Orig_PenDue, Orig_Discount, Initial_TaxDue, Initial_PenDue, Initial_Discount, PenDue_Pd, TaxDue_Pd, Amount_paid, NoDisc_PenDue, NoDisc_TaxDue, " & _
                                   " PercentDisc, Protest, IsCashOnHand, UserID, DateIss, Date_paid, Payer, Time_Posted, Date_Posted, ChckType, ChkPayee, Bank, Check_no, Check_date, CheckAmount, MOrder_no, MOrder_date, MOrder_Amt, CType, CC,  PayMode, LGULevel, BillingType, Encoder, isLocked, isPaymentEdited, User_Edit, isOutsideRem, FormUse, SRS, ORNO, BookNo, CmprsNO, SchedSeq, CA_Penalty, bcode, bcode_c, owner_no, owner_no_c, CAO, isPART, UserAssess, CostSale, OBAmnt, RCost, PPrice, RPrice, ENTRY_FEE, Short_Amt, Prev_ShortAmt, Cash_Amt, Cutoff, Tax_TAXCREDIT, Pen_TAXCREDIT, username, remarks, other_remarks, CURRASSVALUE, PREVASSVALUE, INPUTPREVASSVALUE, TOTCURRASSVALUE, TOTLASTASSVALUE, TOTPREVASSVALUE, LASTASSVALUE, ANNUALTAXDUE, TAXDUE, PENALTY, DISCOUNT, DISCOUNTREGU, DISCOUNTADV, TAXCREDIT, PREV_TAXCREDIT, TOTALAMT, TAXABLE_OR_EXEMPT_DESC, PENALTY_RATE, DISCOUNTREGU_RATE, DISCOUNTADV_RATE, RATE_APPLIED, EffYrQtrNo_A, EffYrQtrNo_P, EffYrQtrNo_D, EffYrQtrNo_D_ADV, EffYrQtrNo_P_RATE,  EffYrQtrNo_D_RATE, EffYrQtrNo_D_ADV_RATE, DELYEAR, delNoofyear, DEC_YRQTR, DEC_YR, DEC_QTR, Diff_DecDtBillDtQtr, RUNNINGQTR, RUNNINGMONTH, CurrActiveMonthInQtr, CurrBillYrQtr, StartToBill_Yr, StartToBill_Qtr, CurrBillYr, CurrBillQtr, CurrBillMonth, StartToBill_YrAndQtr_InDate, YrQtrToBill_InDate, CurrBillYrQtr_InDate, TotalAnnualPerYrQtr, AnnualRate, TaxDueRate, accu_taxcredit_taxdue, accu_taxcredit_pendue, accu_taxcredit_total, accu_taxcredit_total_taxdue, intFundCode, tmpTotAmt, tmpPercent, tmpPartOfTotAmtA, tmpPartOfTotAmtB, RUNNINGTOTALAMT, RUNNINGTOTAL_COH, LastYRQtrPaid, EndTaxCreditYrQtr, prev_tax_taxcredit, prev_pen_taxcredit, codetype, nox, Istodelete, IsComproLstPay, IsPrtArea, IsFrmBackEnd, DELFEE, COMPFEE " & _
                                   " FROM HistAssess_FrmNewBilling_dtls WHERE ASSESSNO = '" & assessno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_RPTIMS)
            _SqlCommand.ExecuteNonQuery()
            _SqlCommand.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function












    Public Function getACCTNO(ByVal txnrefno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "select acctno from onlinepaymentrefno where txnrefno='" & txnrefno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("acctno").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public Function getTransactionType(ByVal txnrefno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "select type from onlinepaymentrefno where txnrefno='" & txnrefno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("type").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public Function getEMAIL(ByVal txnrefno As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "select emailaddr from onlinepaymentrefno where txnrefno='" & txnrefno & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("emailaddr").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Function Print_Template() As DataTable
        _DataTable = New DataTable
        Try
            Dim _Query As String = "SELECT *,(select LGU_LOGO from [" & cGlobalConnections._pSqlCxn_CR.Database & "].dbo.[LGU_Profile]) LGU_LOGO FROM EOR_SETUP"
            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlDataAdapter.Fill(_DataTable)
        Catch ex As Exception
        End Try
        Return _DataTable
    End Function


    Public Function Print_Report(ByVal eORNO As String) As DataTable
        _DataTable = New DataTable
        Try
            Dim _Query As String = "SELECT * FROM EOR WHERE eORNO='" & eORNO & "'"

            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlDataAdapter.Fill(_DataTable)
        Catch ex As Exception
        End Try
        Return _DataTable
    End Function
    Public Function Print_TOP(eORNO) As DataTable
        _DataTable = New DataTable
        Dim _SQLcon As New SqlConnection
        Try
            Dim _Query As String

            If Process.TransactionType = "BP" Or Process.TransactionType = "BUSINESS PERMIT" Then
                _Query = "SELECT * FROM EOR_EXTN WHERE eORNO='" & eORNO & "'"
            ElseIf Process.TransactionType = "RPT" Or Process.TransactionType = "REAL PROPERTY TAX" Then
                _Query =
  "                  SELECT NatureOfCollection, Amount" &
" FROM (" &
"     select 'RPT - BASIC TAX DUE' as NatureOfCollection, SUM(amount) as amount, 1 as SortOrder from eOR_Extn " &
"    where  eORNO='" & eORNO & "' and AccountCode in (" &
"                                '4-01-02-041-01-004'," &
"                                '4-01-02-040-02-004'," &
"                                '4-01-02-040-02-001'," &
"                                '4-01-02-040-02-002'," &
"                                '4-01-02-040-02-003'," &
"                                '4-01-02-040-01-004'," &
"                                '4-01-02-040-01-001'," &
"                                '4-01-02-040-01-002'," &
"                                '4-01-02-040-01-003'," &
"                                '4-06-01-010-09-001'," &
"                                '4-01-02-040-02-008'," &
"                                '4-01-02-040-02-005'," &
"                                '4-01-02-040-02-006'," &
"                                '4-01-02-040-02-007'" &
"    )" &
"    union" &
"    select 'RPT - BASIC DISCOUNT', SUM(amount), 2 from eOR_Extn  " &
"    where  eORNO='" & eORNO & "' and AccountCode in (" &
"                        '4-01-02-041-01-003'," &
"                        '4-01-02-041-01-007'," &
"                        '4-01-02-041-01-008'," &
"                        '4-01-02-041-01-002'," &
"                        '4-01-02-041-01-001'," &
"                        '4-01-02-041-01-009'," &
"                        '4-01-02-041-01-010'," &
"                        '4-01-02-041-01-006'," &
"                        '4-01-02-041-01-005'," &
"                        '4-01-02-041-01-011'," &
"                        '4-01-02-041-01-012'" &
"    )" &
"    union" &
"    select 'RPT - BASIC PENALTY', SUM(amount), 3 from eOR_Extn  " &
"    where  eORNO='" & eORNO & "' and AccountCode in (" &
"                            '4-01-05-020-01-004'," &
"                            '4-01-05-020-01-005'," &
"                            '4-01-05-020-01-006'," &
"                            '4-01-05-020-01-001'," &
"                            '4-01-05-020-01-002'," &
"                            '4-01-05-020-01-003'," &
"                            '4-01-05-020-01-007'," &
"                            '4-01-05-020-01-008'," &
"                            '4-01-05-020-01-009'" &
"    )" &
"    union" &
"     select 'RPT - SEF TAX DUE', SUM(amount), 4 from eOR_Extn  " &
"    where  eORNO='" & eORNO & "' and AccountCode in (" &
"                                            '4-01-02-050-01-004'," &
"                                            '4-01-02-050-01-004'," &
"                                            '4-01-02-050-01-001'," &
"                                            '4-01-02-050-01-002'," &
"                                            '4-01-02-050-01-003'" &
"    )" &
"    union" &
"     select 'RPT - SEF DISCOUNT', SUM(amount), 5 from eOR_Extn " &
"    where  eORNO='" & eORNO & "' and AccountCode in (" &
"                                    '4-01-02-051-01'," &
"                                    '4-01-02-051-01-002'," &
"                                    '4-01-02-051-01-001'," &
"                                    '4-01-02-051-01-003'," &
"                                    '4-01-02-051-01-004'" &
"    )" &
"    union" &
"    select 'RPT - SEF PENALTY', SUM(amount), 6 from eOR_Extn " &
"    where  eORNO='" & eORNO & "' and AccountCode in (" &
"                                        '4-01-05-020-02-001'," &
"                                        '4-01-05-020-02-002'," &
"                                        '4-01-05-020-02-003'" &
"    )" &
") subquery" &
" WHERE Amount IS NOT NULL ORDER BY SortOrder"

            End If

            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlDataAdapter.Fill(_DataTable)
        Catch ex As Exception
        End Try
        Return _DataTable
    End Function
    Public Function Get_PendingEorList(ByRef err As String) As DataTable
        _DataTable = New DataTable
        Try
            Dim cmd As New SqlCommand
            Dim _Query As String = Nothing
            ' _Query = _
            '" Select distinct" &
            '" (PAYFILE.ACCTNO)ds_TDNBIN," &
            '" (PAYFILE.PAYOR)ds_Name," &
            '" (BP_brgyCode.BRGYDESC)ds_Brgy," &
            '" ('BUSINESS PERMIT')ds_TaxType," &
            '" (PAYFILE.PERIODCOVERED)ds_TaxPeriod," &
            '" format(PAYFILE.ORDATE,'MMMM dd, yyyy')ds_DateTime," &
            '" (PAYFILE.orno)ds_eORNO," &
            '" ('')ds_PayMode," &
            '" ('')ds_PayChannel," &
            '" concat(BP_sysctrl.FNAME,' ',BP_sysctrl.mname,' ', BP_sysctrl.LName)ds_Officer," &
            '" (BP_sysctrl.Designation)ds_Designation" &
            '" from [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.PAYFILE" &
            '" inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.sysctrl BP_sysctrl on payfile.[USER_ID] = BP_sysctrl.LOGINNAME" &
            '" inner join [" & cGlobalConnections._pSqlCxn_BPLTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTAS.Database & "].dbo.BRGYCODE BP_brgyCode on payfile.BRGYCODE = BP_brgyCode.BRGYCODE" &
            '" where PAYFILE.acctno in" &
            '" (select acctno from [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.BUSDETAIL)" &
            '" union " &
            '            _Query = _
            '" select distinct" &
            '" (LEDGER.tdn)ds_TDNBIN," &
            '" (LEDGER.PAYER)ds_Name," &
            '" (RP_barangay.[DESCRIPTION])ds_Brgy," &
            '" ('REAL PROPERTY TAX')ds_TaxType," &
            '" concat(" &
            '" (select  MIN(x.for_year) from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.LEDGER x where x.orno=LEDGER.orno),'-'," &
            '" (select  MIN(x.lqp) from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.LEDGER x where x.orno=LEDGER.orno and x.for_year = " &
            '" (select  MIN(x.for_year) from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.LEDGER x where x.orno=LEDGER.orno))," &
            '"                     ' to '," &
            '" (select  MAX(x.for_year) from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.LEDGER x where x.orno=LEDGER.orno),'-'," &
            '" (select  MAX(x.lqp) from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.LEDGER x where x.orno=LEDGER.orno and x.for_year = " &
            '" (select  MAX(x.for_year) from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.LEDGER x where x.orno=LEDGER.orno))" &
            '" )ds_TaxPeriod," &
            '" format(LEDGER.date_paid,'MMMM dd, yyyy')ds_DateTime," &
            '" (LEDGER.orno)ds_eORNO," &
            '" ('')ds_PayMode," &
            '" ('')ds_PayChannel," &
            '" concat(RP_sysctrl.FNAME,' ',RP_sysctrl.mi,' ', RP_sysctrl.LName)ds_Officer," &
            '" (RP_sysctrl.Designation)ds_Designation" &
            '" from [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.LEDGER" &
            '" inner join [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.sysctrl RP_sysctrl on LEDGER.[USER_ID] = RP_sysctrl.LOGINNAME" &
            '" inner join [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.rptmast rptmast on LEDGER.tdn = rptmast.tdn" &
            '" inner join [" & cGlobalConnections._pSqlCxn_RPTAS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTAS.Database & "].dbo.barangay RP_barangay on rptmast.BCODE = RP_barangay.CODE" &
            '" where LEDGER.tdn in" &
            '" (select TDN from  [" & cGlobalConnections._pSqlCxn_RPTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.RPTDETAIL)" &
            '" and LEDGER.ORNO in (select MaxORNO from OnlinePaymentRefNo)"


            '    _Query = "Select * from onlinepaymentrefno where isnull(minORNO,'x') <> 'x' and isnull(maxORNO,'x') <> 'x'"

            _Query = "Select * from eor where isnull(sent,0) = 0 or sent = 0"


            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlDataAdapter.Fill(_DataTable)
        Catch ex As Exception
            err = ex.Message
        End Try
        Return _DataTable
    End Function
    Public Function Get_SentEorList(ByRef err As String, Optional ByVal email As String = Nothing) As DataTable
        _DataTable = New DataTable
        Try
            Dim _Query As String = Nothing

            If String.IsNullOrEmpty(email) = False Then
                '   _Query = "Select * from eor where sent=1 and email='" & email & "' order by sent_date desc"
                _Query = " select * from eor" &
                         " where OnlineID in " &
                         " (" &
                         " 	select distinct TXNREFNO " &
                         " 	from OnlinePaymentRefno" &
                         " 	where EMAILADDR='lugarestom@gmail.com'" &
                         " ) and sent=1 order by sent_date desc"




            Else
                _Query = "Select * from eor where sent=1 order by sent_date desc"
            End If

            Dim _nSqlDataAdapter As New SqlDataAdapter(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            _nSqlDataAdapter.Fill(_DataTable)
        Catch ex As Exception
            err = ex.Message
        End Try
        Return _DataTable
    End Function
    Public Function AmountInWords(ByVal amount As Decimal) As String
        Dim cents As Integer = Math.Round((amount - Math.Truncate(amount)) * 100)
        Dim dollars As Integer = Math.Truncate(amount)
        Dim centavo As String = ""
        Dim dollarText As String = ""

        ' Get centavo text
        If cents > 0 Then
            centavo = " and " & NumberToWords(cents) & " centavos"
        Else
            centavo = " and zero centavos"
        End If

        ' Get dollar text
        If dollars > 0 Then
            dollarText = NumberToWords(dollars)
            If dollars = 1 Then
                dollarText &= " pesos"
            Else
                dollarText &= " pesos"
            End If
        Else
            '  dollarText = "zero dollars"
        End If

        Return dollarText & centavo
    End Function
    ' Helper function to convert numbers to words
    Private Function NumberToWords(ByVal number As Integer) As String
        Dim ones() As String = {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"}
        Dim teens() As String = {"ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"}
        Dim tens() As String = {"", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"}

        If number < 10 Then
            Return ones(number)
        ElseIf number < 20 Then
            Return teens(number - 10)
        ElseIf number < 100 Then
            Return tens(number \ 10) & " " & ones(number Mod 10)
        ElseIf number < 1000 Then
            Return ones(number \ 100) & " hundred " & NumberToWords(number Mod 100)
        ElseIf number < 1000000 Then
            Return NumberToWords(number \ 1000) & " thousand " & NumberToWords(number Mod 1000)
        Else
            Return ""
        End If
    End Function

    Public Shared Function isEORSaved(ByVal orno As String, Optional ByRef err As String = Nothing) As Boolean
        Dim result As Boolean = False
        Dim cmd As New SqlCommand
        Dim _Query As String = Nothing
        Try
            _Query = "SELECT * FROM EOR WHERE eORNO ='" & orno & "'"
            cmd = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Using _nSqlDr As SqlDataReader = cmd.ExecuteReader
                _nSqlDr.Read()
                result = _nSqlDr.HasRows
            End Using
        Catch ex As Exception
            err = ex.Message
        End Try

        Return result

    End Function

    Public Function isEOR_Exists(ByVal txnrefno As String) As Boolean
        Dim result As Boolean = False
        Dim cmd As New SqlCommand
        Dim _Query As String = Nothing
        Try
            _Query = "SELECT * FROM EOR WHERE OnlineID ='" & txnrefno & "'"
            cmd = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Using _nSqlDr As SqlDataReader = cmd.ExecuteReader
                _nSqlDr.Read()
                result = _nSqlDr.HasRows
            End Using
        Catch ex As Exception

        End Try

        Return result

    End Function

    Public Shared Sub Get_Setup(ByRef LGUNAME As String, ByRef OFFICE As String, ByRef OfficerName As String)
        Dim cmd As New SqlCommand
        Dim _Query As String = "Select * from eOR_Setup"
        Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
        Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
        Using _nSqlDr
            If _nSqlDr.HasRows Then
                Do While _nSqlDr.Read
                    LGUNAME = _nSqlDr("Header1").ToString
                    OFFICE = _nSqlDr("Header2").ToString
                    OfficerName = _nSqlDr("Officer_Name").ToString
                Loop
            End If
        End Using

    End Sub
    Public Shared Function Generate_eORno(Optional ByRef err As String = Nothing) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = _
            " select concat(year(getdate()),'-', RIGHT('0' + CONVERT(varchar(2), MONTH(GETDATE())), 2) ,'-'," &
            " (" &
            "  SELECT REPLACE(STR((" &
            " SELECT CASE" &
            "  WHEN ISNULL(" &
            " (SELECT  TOP 1 RIGHT(eorno,5)SEQ FROM eor" &
            " WHERE YEAR([DateTime]) = YEAR(GETDATE())" &
            " ORDER BY RIGHT(eorno,12) DESC),0)=0" &
            " 	THEN  0" &
            " ELSE (" &
            " SELECT  TOP 1 RIGHT(eorno,5)SEQ FROM eor" &
            " WHERE YEAR([DateTime]) = YEAR(GETDATE()) " &
            " ORDER BY RIGHT(eorno,12) DESC)" &
            "  END NEWSEQ)+1,12),' ','0') AS SEQ" &
            "  ))NewEORNO"


            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("NewEORNO").ToString
                    Loop
                End If
            End Using

        Catch ex As Exception
            err = ex.Message
        End Try
        Return result
    End Function
    Public Shared Function Get_EORNO(ByVal ORNO As String) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "SELECT EORNO FROM EOR WHERE ORNO='" & ORNO & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("EORNO").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Shared Function Get_GateWayRefNo(ByVal TDNBIN As String, ByVal ORNO As String, Optional ByRef ERR As String = Nothing) As String
        Dim result As String = Nothing
        Try
            Dim _Query As String = "SELECT * FROM ONLINEPAYMENTREFNO WHERE  MAXORNO='" & ORNO & "' and ACCTNO='" & TDNBIN & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("GateWayRefNo").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception
            ERR = ex.Message
        End Try
        Return result
    End Function

    Public Shared Function Get_EMAIL(ByVal ORNO As String) As String
        email = Nothing
        Dim result As String = Nothing
        Try
            Dim _Query As String = "SELECT emailaddr from onlinepaymentrefno where MAXORNO = '" & ORNO & "'"
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("emailaddr").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Shared Sub Insert_eOR(ByVal eorno As String, Optional ByRef ERR As String = Nothing, Optional ByRef qry As String = Nothing)
        Try
            Dim TAXTYPE As String = Nothing
            Dim _Query1 As String = "INSERT INTO [" & cGlobalConnections._pSqlCxn_OAIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.eOR "
            Dim _Query2 As String = Nothing

            If Process.TransactionType = "BP" Then TAXTYPE = "BUSINESS PERMIT"
            If Process.TransactionType = "RPT" Then TAXTYPE = "REAL PROPERTY TAX"

            If TAXTYPE = "BUSINESS PERMIT" Then
                _Query2 = _
                " Select distinct" &
                " (PAYFILE.PAYOR)PayorName," &
                " (BP_brgyCode.BRGYDESC)Barangay," &
                " ('BUSINESS PERMIT')TaxType," &
                " (PAYFILE.ACCTNO)TDNBIN, " &
                " (Null)PIN, " &
                " (PAYFILE.PERIODCOVERED)PeriodCovered," &
                " (null)AssesssNo," &
                " ('" & eorno & "')eORNO," &
                " CONVERT(varchar(20),  PAYFILE.ORDATE, 107) AS DateTime," &
                " (payfile.[sequence])OnlineID," &
                " ('" & eOR.Gateway & "')Gateway_Selected," &
                " ('" & eOR.Gateway_RefNo & "')Gateway_RefNo," &
                " ('" & eOR.Gateway_ConfDate & "')Gateway_ConfDate," &
                " (" & eOR.Bill_Amount & ")Bill_Amount," &
                " (" & eOR.Gateway_Fee & ")Gateway_fee," &
                " (" & eOR.SPIDC_Fee & ")SPIDC_Fee," &
                " (" & eOR.GrandTotal & ")GrandTotal," &
                " (null)QR_FILE," &
                " (null)QR_STRING," &
                " (null)PrevORNO," &
                " (null)PrevAmountPaid," &
                " (null)[Sent]," &
                " (null)Sent_Date" &
                " from PAYFILE" &
                " inner join BRGYCODE BP_brgyCode on payfile.locacode = BP_brgyCode.BRGYCODE  and payfile.BRGYCODE = BP_brgyCode.distcode" &
                " where" &
                " PAYFILE.acctno='" & Process.ACCTNO & "'" &
                " and year(payfile.ordate)=year(getdate())" &
                " and  PAYFILE.ACCTNO = (SELECT acctno from [" & cGlobalConnections._pSqlCxn_OAIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.onlinepaymentrefno where MAXORNO = '" & eorno & "' and emailaddr='" & Get_EMAIL(eorno) & "'" &
                " and payfile.[sequence] = '" & IIf(String.IsNullOrEmpty(Process.SpidcRefNo), eOR.SPIDC_RefNo, Process.SpidcRefNo) & "')"

                qry = _Query1 & _Query2
                Dim _SqlCommand1 As New SqlCommand(_Query1 & _Query2, cGlobalConnections._pSqlCxn_BPLTAS)
                _SqlCommand1.ExecuteNonQuery()
                _Query1 = Nothing
                _Query2 = Nothing

            ElseIf TAXTYPE = "REAL PROPERTY TAX" Then
                _Query2 =
  "  Select distinct" &
  " (LEDGER.PAYER)PayorName,  " &
  " (RP_barangay.[DESCRIPTION])Barangay,  " &
  " ('REAL PROPERTY TAX')TaxType," &
  " (LEDGER.tdn)TDNBIN, " &
  " (rptmast.pin)PIN,    " &
  " (" &
  " (select  MIN(x.for_year) from LEDGER x where x.orno=LEDGER.orno)" &
        " +'-'" &
        " +(select  MIN(x.lqp) from LEDGER x where x.orno=LEDGER.orno and x.for_year =  (select  MIN(x.for_year) from LEDGER x where x.orno=LEDGER.orno))" &
        " +' to '" &
        " +(select  MAX(x.for_year) from LEDGER x where x.orno=LEDGER.orno)" &
        " +'-'" &
        " +(select  MAX(x.lqp) from LEDGER x where x.orno=LEDGER.orno and x.for_year =  (select  MAX(x.for_year) from LEDGER x where x.orno=LEDGER.orno))" &
   " )PeriodCovered,      " &
  " ('" & Process.ACCTNO & "')AssesssNo," &
  " ('" & eorno & "')eORno, " &
  " CONVERT(varchar(20), LEDGER.date_paid, 107) as [DateTime],  " &
  " (Gen_Or.PAYMENTREFNO)OnlineID, " &
  " ('" & eOR.Gateway & "')Gateway_Selected," &
  " ('" & eOR.Gateway_RefNo & "')Gateway_RefNo," &
  " ('" & eOR.Gateway_ConfDate & "')Gateway_ConfDate," &
  " (" & eOR.Bill_Amount & ")Bill_Amount," &
  " (" & eOR.Gateway_Fee & ")Gateway_fee," &
  " (" & eOR.SPIDC_Fee & ")SPIDC_Fee," &
  " (" & eOR.GrandTotal & ")GrandTotal," &
  " (null)QR_File, " &
  " (null)QR_String, " &
  " (null)PrevORno, " &
  " (null)PrevAmountPaid, " &
  " (null)sent,  " &
  " (null)sent_date  " &
  "  from  LEDGER  " &
  "  inner join [" & cGlobalConnections._pSqlCxn_TOIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_TOIMS.Database & "].dbo.Gen_Or on LEDGER.ORNO=Gen_Or.OR_NO" &
  "  inner join rptmast rptmast on LEDGER.tdn = rptmast.tdn  " &
  "  inner join barangay RP_barangay on rptmast.BCODE = RP_barangay.CODE  " &
  "  where Gen_Or.PAYMENTREFNO='" & SPIDC_RefNo & "'" &
  "  and  LEDGER.tdn = (SELECT AFBB.TDN from [" & cGlobalConnections._pSqlCxn_RPTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.Assess_FrmNewBilling_B AFBB" &
  " inner join [" & cGlobalConnections._pSqlCxn_OAIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.OnlinePaymentRefno OPR ON AFBB.AssessNo = OPR.acctno " &
  " where OPR.MAXORNO = '" & eorno & "' and OPR.emailaddr='" & Get_EMAIL(eorno) & "')"

                qry = _Query1 & _Query2
                Dim _SqlCommand2 As New SqlCommand(_Query1 & _Query2, cGlobalConnections._pSqlCxn_RPTAS)
                _SqlCommand2.ExecuteNonQuery()
                _Query1 = Nothing
                _Query2 = Nothing
            End If

            ERR = Nothing
        Catch ex As Exception
            ERR = ex.Message
        End Try
    End Sub

    Public Shared Sub Update_eOR(ByVal eORno As String, Optional ByRef err As String = Nothing)
        Try
            Dim QR_STRING As String = eOR.GET_QRstring(eORno)
            Dim _Query As String = Nothing

            _Query = "UPDATE eOR set QR_File = @QR_File,QR_STRING='" & QR_STRING & "' where eORno = '" & eORno & "'"
            Dim _SqlCommand As New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            With _SqlCommand.Parameters
                .AddWithValue("@QR_File", GenerateQRcode(QR_STRING))
            End With
            '----------------------------------
            _SqlCommand.ExecuteNonQuery()
            '----------------------------------

        Catch ex As Exception

        End Try

    End Sub



    Public Shared Sub Update_Sent(ByVal eORno As String, Optional ByRef err As String = Nothing)
        Dim _Query As String = "UPDATE eOR set sent = 1 , sent_date=getdate() where eORno = '" & eORno & "'"
        Dim _SqlCommand As New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
        _SqlCommand.ExecuteNonQuery()
    End Sub

    Public Shared Sub Insert_eOR_EXTN(ByVal TAXTYPE As String, ByVal eORno As String, ByVal srs As String, ByVal Seq As String, ByVal TDNBIN As String, Optional ByRef ERR As String = Nothing)
        Dim _SQLcon As New SqlConnection
        Try
            Dim _Query1 As String = "INSERT INTO [" & cGlobalConnections._pSqlCxn_OAIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_OAIMS.Database & "].dbo.eOR_EXTN "
            Dim _Query2 As String = Nothing

            If TAXTYPE = "BP" Then TAXTYPE = "BUSINESS PERMIT"
            If TAXTYPE = "RPT" Then TAXTYPE = "REAL PROPERTY TAX"


            If TAXTYPE = "BUSINESS PERMIT" Then
                _SQLcon = cGlobalConnections._pSqlCxn_BPLTAS
                _Query2 = _
" select '" & eORno & "'eORNO,'" & Seq & "'ORNO,(Acctno)TDNBIN, (SubAcctCode)AccountCode, (SubAcctDesc)NatureOfCollection, sum(convert(money,xAmt_Pd)) as Amount from (" &
" select Acctno, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, xsquence, xsquencepen, " &
" isnull(xsquencelocal,'1') as xsquencelocal, sum(convert(money,Amt_Pd)) as xAmt_Pd, 0 as xRes1, 0 as xRes2,'DUE' as xPay from BILLINGTEMP where Acctno = '" & TDNBIN & "' and IsRegBill = '1' and MainAcctDesc <> '' and isnull(convert(money,Amt_Pd),0) <> 0 and not right(desc1,16) = '(Excess Payment)' and (not left(Desc1,9) = 'TaxCredit' or left(Desc1,17) = 'TaxCredit (Acctng') " &
" group by Acctno, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, xsquence, xsquencepen, xsquencelocal " &
" Union " &
" SELECT Acctno, MainAcctCodePen as MainAcctCode, MainAcctDescPen, SubAcctCodePen as SubAcctCode, SubAcctDescPen, xsquence, " &
" xsquencepen, isnull(xsquencelocal,'1') as xsquencelocal, sum(convert(money,Amt_Penpd)) as xAmt_Pd, sum(convert(money,RES1)) as xRes1, sum(convert(money,RES2)) as xRes2,'PEN' as xPay from BILLINGTEMP where Acctno = '" & TDNBIN & "' and IsRegBill = '1' and MainAcctDescPen <> '' and isnull(convert(money,Amt_Penpd),0) <> 0 and (not left(Desc1,9) = 'TaxCredit' or left(Desc1,17) = 'TaxCredit (Acctng') " &
" group by Acctno, MainAcctCodePen, MainAcctDescPen, SubAcctCodePen, SubAcctDescPen, xsquence, xsquencepen, xsquencelocal " &
" Union " &
" select Acctno, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, xsquence, xsquencepen, " &
" isnull(xsquencelocal,'1') as xsquencelocal, sum(convert(money,Amt_Pd)) as xAmt_Pd, 0 as xRes1, 0 as xRes2,'XDUE' as xPay from BILLINGTEMP where Acctno = '" & TDNBIN & "' and IsRegBill = '1' and MainAcctDesc <> '' and isnull(convert(money,Amt_Pd),0) <> 0 and right(desc1,16) = '(Excess Payment)' " &
" group by Acctno, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, xsquence, xsquencepen, xsquencelocal " &
" Union " &
" select Acctno, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, xsquence, xsquencepen, xsquencelocal, sum(convert(money,xAmt_Pd)) as xAmt_Pd, xRes1, xRes2, xPay from ( " &
"       select Acctno, '---' as MainAcctCode, case when left(isnull(Remarks,'             '),13) = 'Tax Incentive' then 'Total Tax Credit/Incentive' else 'Total TaxCredit' end as MainAcctDesc, '---' as subAcctCode, case when left(isnull(Remarks,'             '),13) = 'Tax Incentive' then 'Total Tax Credit/Incentive' else 'Total TaxCredit' end as SubAcctDesc, xsquence, xsquencepen, 'x'  as xsquencelocal, sum(convert(money,Amt_Pd)) + sum(convert(money,Amt_Penpd)) as xAmt_Pd, 0 as xRes1, 0 as xRes2,'XDUEPEN' as xPay, isnull(Remarks,'') as Remark " &
"       from BILLINGTEMP where Acctno = '" & TDNBIN & "' and IsRegBill = '1' and  MainAcctDesc <> ''  and (isnull(convert(money,Amt_Pd),0) <> 0 or isnull(Amt_Penpd,0) <> 0) and (left(Desc1,9) = 'TaxCredit' and not left(Desc1,17) = 'TaxCredit (Acctng') " &
"       group by Acctno, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, xsquence, xsquencepen, xsquencelocal, Remarks ) as yyy " &
" group by Acctno, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, xsquence, xsquencepen, xsquencelocal, xRes1, xRes2, xPay " &
" ) as xxx group by Acctno, MainAcctCode, MainAcctDesc, SubAcctCode, SubAcctDesc, xsquence, xsquencepen order by MainAcctCode,SubAcctCode"


            ElseIf TAXTYPE = "REAL PROPERTY TAX" Then
                _SQLcon = cGlobalConnections._pSqlCxn_OAIMS
                _Query2 =
            " select '" & eORno & "',or_no,'" & TDNBIN & "',Acctno,(select description from [" & cGlobalConnections._pSqlCxn_TOIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_TOIMS.Database & "].dbo.coa " &
            " where main_code=G.Main_Code and ancestor_code=G.Ancestor and acctno=G.Acctno)description,(Amount)TOTAL" &
            " from [" & cGlobalConnections._pSqlCxn_TOIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_TOIMS.Database & "].dbo.gen_extn as G  where OR_No='" & Seq & "' and srs='" & srs & "'"

            End If

            Dim _SqlCommand As New SqlCommand(_Query1 & _Query2, _SQLcon)
            _SqlCommand.ExecuteNonQuery()

        Catch ex As Exception
            ERR = ex.Message
        End Try
    End Sub

    Public Shared Function GenerateBarcode(code As String) As Byte()
        Dim writer As New BarcodeWriter()
        writer.Format = BarcodeFormat.CODE_128
        Dim bitmap As Bitmap = writer.Write(code)
        Dim stream As New MemoryStream()
        bitmap.Save(stream, ImageFormat.Png)
        Return stream.ToArray()
    End Function

    Public Shared Function GET_QRstring(ByVal ORNO As String) As String
        Dim result As String
        Try
            Dim _Query As String = _
           " select eorno,TaxType,TDNBIN,GrandTotal,gateway_selected,[DateTime] from eor" &
           " where eORNO ='" & ORNO & "'"

            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("eorno").ToString & vbNewLine _
                               & _nSqlDr("TaxType").ToString & vbNewLine _
                               & _nSqlDr("TDNBIN").ToString & vbNewLine _
                               & _nSqlDr("GrandTotal").ToString & vbNewLine _
                               & _nSqlDr("gateway_selected").ToString & vbNewLine _
                               & _nSqlDr("DateTime").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public Shared Function GenerateQRcode(ByVal QR_String As String, Optional err As String = Nothing) As Byte()
        Dim result As Byte()
        Try
            Dim qrGenerator As New QRCodeGenerator
            Dim qrCode = qrGenerator.CreateQrCode(QR_String, QRCodeGenerator.ECCLevel.Q)
            Dim imgBarCode As System.Web.UI.WebControls.Image = New System.Web.UI.WebControls.Image()
            Dim QR_CODE As New QRCode(qrCode)
            imgBarCode.Height = 350
            imgBarCode.Width = 350

            Using bm As Bitmap = QR_CODE.GetGraphic(6)
                Using ms As MemoryStream = New MemoryStream()
                    bm.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                    result = ms.ToArray()
                End Using
            End Using
        Catch ex As Exception
            err = ex.Message
        End Try
        Return result
    End Function

    '0000 ALL IN QUERY
    Function ALL_IN_ONE(ByVal TransactionType As String, ByVal txnrefno As String, ByRef qry As String, ByRef err As String) As Boolean
        Try

            Dim dfrom As String
            Dim joinQRY As String
            Dim OwnerName As String
            Dim Address As String

            Select Case TransactionType
                Case "RPT"
                    dfrom = "RPTASWEB"
                    OwnerName = "RPTDETAIL.OWNERNAME"
                    Address = "RPTDETAIL.LOCATION"
                    joinQRY = " JOIN [" & cGlobalConnections._pSqlCxn_RPTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.RPTDETAIL ON RPTDETAIL.TDN = " & cSessionLoader._pTDN & " AND RPTDETAIL.email2 = '" & TaxPayerEmail & "'"
                Case "BP"
                    dfrom = "BTAXWEB"
                    OwnerName = "BUSDETAIL.OWNER"
                    Address = "BUSDETAIL.BUSADDRESS"
                    joinQRY = " JOIN [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.BUSDETAIL ON BUSDETAIL.ACCTNO = '" & Process.ACCTNO & "' AND BUSDETAIL.email2 = '" & TaxPayerEmail & "'"
            End Select


            Dim _Query1 As String = "INSERT INTO Gen_Or (setup, bookno, or_no, or_date, payor, [address], PayCode, Form_Use, [User], srs, isPrintORPErmanent, paymentrefno, isweb, gateway, GatewayRefNo, dfrom) " & _
                      " SELECT CONVERT(varchar(8), GETDATE(), 112)  AS Setup, " & _
                      " Receipts.Book_No, " & _
                      " (SELECT RIGHT(REPLICATE('0', LEN(Receipts.Beg_OR)) + COALESCE((SELECT TOP 1 CAST(g.or_no + 1 AS VARCHAR(20)) FROM gen_or g " & _
                      " INNER JOIN Receipts r ON g.Form_Use = r.Form " & _
                      " WHERE r.Form = 'eor' AND r.BackEnd = 0 AND (g.or_no BETWEEN r.Beg_OR AND r.End_OR) " & _
                      " ORDER BY g.or_no DESC), Receipts.Beg_OR), LEN(Receipts.Beg_OR)) AS SEQ " & _
                      " FROM Receipts " & _
                      " WHERE Form = 'EOR' AND BackEnd = 0) AS SEQ, " & _
                      " GETDATE() AS or_date, " & _
                      " " & OwnerName & " AS PAYOR, " & _
                      " " & Address & " AS [ADDRESS], " & _
                      " 'COL' AS PayCode, " & _
                      " Receipts.Form, " & _
                      " Receipts.[USER], " & _
                      " Receipts.SRS, " & _
                      " 1 AS isPrintORPErmanent, " & _
                      " '" & txnrefno & "' AS PAYMENTREFNO, " & _
                      " 1 AS isWEB, " & _
                      " '" & Process.Gateway_Selected & "' AS GATEWAY, " & _
                      " '" & Process.GatewayRefNo & "' AS GATEWAYREFNO, " & _
                      " '" & dfrom & "' AS DFROM " & _
                      " FROM Receipts " & _
                      joinQRY & _
                      " WHERE Receipts.Form = 'EOR' AND Receipts.BackEnd = 0;"

            '   Dim _SqlCommand1 As New SqlCommand(_Query1, cGlobalConnections._pSqlCxn_TOIMS)
            '   _SqlCommand1.ExecuteNonQuery()
            '----------------------------------

            Dim _Query2 As String = " UPDATE Receipts SET OR_Used = ( " & _
                      " SELECT COUNT(*) AS ctr " & _
                      " FROM GEN_OR " & _
                      " INNER JOIN Receipts ON Receipts.Form = 'EOR' AND BackEnd = 0 " & _
                      " WHERE GEN_OR.FORM_USE = Receipts.Form " & _
                      " AND GEN_OR.BookNo = Receipts.Book_No " & _
                      " AND GEN_OR.[user] = Receipts.[User] " & _
                      " AND GEN_OR.or_no BETWEEN Receipts.Beg_OR AND Receipts.End_OR " & _
                      " ) " & _
                      " WHERE Form = 'EOR' AND BackEnd = 0;"
            '     Dim _SqlCommand2 As New SqlCommand(_Query2, cGlobalConnections._pSqlCxn_TOIMS)
            '      _SqlCommand2.ExecuteNonQuery()

            '----------------------------------
            Dim _Query3 As String = " SELECT (Receipts.SRS + CONVERT(varchar(6), GETDATE(), 112)  + '-' + gen_or.OR_NO) AS eORNO, Receipts.SRS, gen_or.OR_NO, Receipts.Book_No, Receipts.[user], GEN_OR.PaymentRefno, GEN_OR.Gateway, GEN_OR.or_date " & _
                      " FROM Receipts " & _
                      " INNER JOIN Gen_OR ON Receipts.Form = Gen_Or.Form_Use " & _
                      " AND GEN_OR.BookNo = Receipts.Book_No " & _
                      " AND GEN_OR.[user] = Receipts.[User] " & _
                      " AND GEN_OR.or_no BETWEEN Receipts.Beg_OR AND Receipts.End_OR " & _
                      " WHERE Receipts.Form = 'EOR' AND Receipts.BackEnd = 0 " & _
                      " AND gen_or.PaymentRefno = '" & txnrefno & "'"

            qry = _Query1 & _Query2 & _Query3
            Dim _SqlCommand3 = New SqlCommand(qry, cGlobalConnections._pSqlCxn_TOIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand3.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _eORNO = _nSqlDr("eORNO").ToString
                        _SRS = _nSqlDr("SRS").ToString
                        _OR_NO = _nSqlDr("OR_NO").ToString
                        _Book_No = _nSqlDr("Book_No").ToString
                        __USER = _nSqlDr("USER").ToString
                        _Gateway = _nSqlDr("GateWay").ToString
                        _or_date = _nSqlDr("or_date").ToString
                        _PaymentRefNo = _nSqlDr("PaymentRefno").ToString
                        Process.SRS = _nSqlDr("SRS").ToString
                        Process.SEQ = _nSqlDr("OR_NO").ToString
                    Loop
                End If
            End Using
            Return True


        Catch ex As Exception
            err = ex.Message & ";" & qry & "  Con: " & cGlobalConnections._pSqlCxn_TOIMS.DataSource.ToString & " - " & cGlobalConnections._pSqlCxn_TOIMS.Database
            Return False
        End Try
    End Function
    '0.0 GET > INCREMENT > INSERT




    Function Insert_GenOR2(ByVal TransactionType As String, Optional err As String = Nothing) As Boolean
        Dim qry As String = Nothing
        Try

            Dim dfrom As String
            Dim joinQRY As String
            Dim OwnerName As String
            Dim Address As String

            Select Case TransactionType
                Case "RPT"
                    dfrom = "RPTASWEB"
                    OwnerName = "RPTDETAIL.OWNERNAME"
                    Address = "RPTDETAIL.LOCATION"
                    joinQRY = " JOIN [" & cGlobalConnections._pSqlCxn_RPTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_RPTIMS.Database & "].dbo.RPTDETAIL ON RPTDETAIL.TDN = " & cSessionLoader._pTDN & " AND RPTDETAIL.email2 = '" & TaxPayerEmail & "';"
                Case "BP"
                    dfrom = "BTAXWEB"
                    OwnerName = "BUSDETAIL.OWNER"
                    Address = "BUSDETAIL.BUSADDRESS"
                    joinQRY = " JOIN [" & cGlobalConnections._pSqlCxn_BPLTIMS.DataSource & "].[" & cGlobalConnections._pSqlCxn_BPLTIMS.Database & "].dbo.BUSDETAIL ON BUSDETAIL.ACCTNO = '" & Process.ACCTNO & "' AND BUSDETAIL.email2 = '" & TaxPayerEmail & "';"
            End Select


            Dim _Query As String = _
                " insert into Gen_Or(setup,bookno,or_no,or_date,payor,[address],PayCode,Form_Use,[User],srs,isPrintORPErmanent,paymentrefno,isweb,gateway,GatewayRefNo,dfrom)" &
                " OUTPUT inserted.* " &
                "  SELECT " &
                "  (CONVERT(varchar(8), GETDATE(), 112))Setup," &
                " 	CTE.Book_No," &
                "     (CTE.SEQ)OR_NO, " &
                " 	(getdate())OR_DATE," &
                "     (" & OwnerName & ")PAYOR, " &
                " 	(" & Address & ")[ADDRESS]," &
                " 	'COL'PayCode," &
                " 	CTE.Form," &
                " 	CTE.[USER]," &
                " 	CTE.SRS," &
                " 	(1)isPrintORPErmanent," &
                " 	'" & Process.SpidcRefNo & "'PAYMENTREFNO," &
                " 	(1)isWEB," &
                " 	'" & Process.Gateway_Selected & "'GATEWAY,    " &
                " 	'" & Process.GatewayRefNo & "'GATEWAYREFNO,    " &
                " 	'" & dfrom & "'DFOM" &
                " FROM" &
                " (" &
                "     SELECT RIGHT(REPLICATE('0', LEN(CTE.Beg_OR)) + COALESCE(SEQ, CTE.Beg_OR), LEN(CTE.Beg_OR)) AS SEQ,CTE.Book_No,CTE.Form,CTE.[user],CTE.SRS" &
                "     FROM (" &
                "         SELECT Beg_OR, End_OR, Form, SRS, [USER], Book_No, EnCoder, OR_Issued, OR_Used   " &
                "         FROM Receipts " &
                "         WHERE Form = 'EOR' AND BackEnd = 0" &
                "     ) CTE" &
                "     LEFT JOIN (" &
                "         SELECT TOP 1 CAST(OR_NO + 1 AS VARCHAR(20)) AS SEQ" &
                "         FROM GEN_OR " &
                "         JOIN (" &
                "             SELECT Beg_OR, End_OR, Form, SRS, [USER], Book_No, EnCoder, OR_Issued, OR_Used" &
                "             FROM Receipts " &
                "             WHERE Form = 'EOR' AND BackEnd = 0" &
                "         ) CTE ON GEN_OR.FORM_USE = CTE.Form" &
                "             AND GEN_OR.BookNo = CTE.Book_No" &
                "             AND GEN_OR.[USER] = CTE.[USER]" &
                "             AND GEN_OR.or_no BETWEEN CTE.Beg_OR AND CTE.End_OR" &
                "         ORDER BY OR_No DESC" &
                "     ) GO ON 1=1" &
                " ) CTE " & joinQRY
            qry = _Query
            Dim _SqlCommand As New SqlCommand(_Query, cGlobalConnections._pSqlCxn_TOIMS)
            '----------------------------------
            _SqlCommand.ExecuteNonQuery()
            '----------------------------------
            err = Nothing
            Return True

        Catch ex As Exception
            err += ";Insert_GenOR:" & qry & ";" & ex.Message
            Return False
        End Try
    End Function

    '0.0 GET > INCREMENT > INSERT

    '0.1 Get Owner Name and Address
    Function Select_NameAddress(ByVal _type As String, ByVal _TDNBIN As String, ByRef _OwnerName As String, ByRef _OwnerAddress As String, Optional ByRef err As String = Nothing)
        Dim qry As String = Nothing
        Try
            Dim _Query As String
            If _type = "RPT" Then
                _Query = "Select OwnerName,(Location)OwnerAddress from RPTDETAIL where TDN=" & cSessionLoader._pTDN & " and email2='" & TaxPayerEmail & "' "
                _mSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
            ElseIf _type = "BP" Then
                _Query = "Select (Owner)OwnerName,(BusAddress)OwnerAddress from BUSDETAIL where acctno='" & _TDNBIN & "' and email2='" & TaxPayerEmail & "' "
                _mSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
            End If

            qry = _Query
            Dim _SqlCommand = New SqlCommand(_Query, _mSqlCon)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        _OwnerName = _nSqlDr("OwnerName").ToString
                        _OwnerAddress = _nSqlDr("OwnerAddress").ToString
                    Loop
                End If
            End Using
            Return True
        Catch ex As Exception
            err = ";Select_NameAddress:" & qry & ";" & ex.Message
            Return False
        End Try

    End Function



    '1. GENERATE ORNO
    Function Select_SEQ(Optional ByRef err As String = Nothing) As String
        Dim result As String
        Dim qry As String = Nothing
        Try
            Dim _Query As String = _
           " WITH CTE AS ( " &
           "    SELECT Beg_OR, End_OR, Form, SRS, [USER], Book_No, EnCoder, OR_Issued, OR_Used   " &
           "    FROM Receipts  " &
           "    WHERE Form = 'EOR'  and BackEnd=0" &
           " )" &
           " SELECT " &
           "      RIGHT(REPLICATE('0', LEN(CTE.Beg_OR)) + COALESCE(GO.SEQ, CTE.Beg_OR), LEN(CTE.Beg_OR)) AS SEQ" &
           " FROM CTE" &
           " LEFT JOIN (" &
           "     SELECT TOP 1 CAST(OR_NO + 1 AS VARCHAR(20)) AS SEQ" &
           "     FROM GEN_OR " &
           "     JOIN CTE ON  GEN_OR.FORM_USE = CTE.Form" &
           "         AND GEN_OR.BookNo = CTE.Book_No" &
           "         AND GEN_OR.[USER] = CTE.[USER]" &
           "         AND GEN_OR.or_no BETWEEN CTE.Beg_OR AND CTE.End_OR" &
           "     ORDER BY OR_No DESC" &
           " ) GO ON 1=1;"
            qry = _Query
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_TOIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        result = _nSqlDr("SEQ").ToString
                    Loop
                End If
            End Using
        Catch ex As Exception
            err = ";Select_SEQ:" & qry & ";" & ex.Message
        End Try
        Return result
    End Function


    '2. INSERT GEN_OR
    Function Insert_GenOR(ByVal SEQ As String, ByVal Payor As String, ByVal Address As String, ByVal PaymentRefNo As String, ByVal Gateway As String, ByVal GatewayRefNo As String, ByVal Dfrom As String, Optional err As String = Nothing)
        Dim qry As String = Nothing
        Try
            Dim _Query As String = _
                " WITH CTE AS ( SELECT Beg_OR, End_OR, Form, SRS, [User], Book_No, EnCoder, OR_Issued, OR_Used FROM Receipts WHERE Form = 'EOR' and backend=0)" &
                " insert into Gen_Or(setup,bookno,or_no,or_date,payor,[address],PayCode,Form_Use,[User],srs,isPrintORPErmanent,paymentrefno,isweb,gateway,GatewayRefNo,dfrom)" &
                " select (CONVERT(varchar(8), GETDATE(), 112))" &
                " ,CTE.Book_No" &
                " ,'" & SEQ & "'" &
                " ,getdate()" &
                " ,'" & Payor & "'" &
                " ,'" & Address & "'" &
                " ,'COL'" &
                " ,cte.Form" &
                " ,cte.[user]" &
                " ,cte.SRS" &
                " ,1" &
                " ,'" & PaymentRefNo & "'" &
                " ,1" &
                " ,'" & Gateway & "' " &
                 " ,'" & GatewayRefNo & "' " &
                 " ,'" & Dfrom & "' " &
                " from CTE"
            qry = _Query
            Dim _SqlCommand As New SqlCommand(_Query, cGlobalConnections._pSqlCxn_TOIMS)
            '----------------------------------
            _SqlCommand.ExecuteNonQuery()
            '----------------------------------
            Return True
        Catch ex As Exception
            err = ";Insert_GenOR:" & qry & ";" & ex.Message
            Return False
        End Try
    End Function

    '3. UPDATE Receipts TABLE : Set OR_USED 
    Function Update_Receipts(Optional err As String = Nothing)
        Dim qry As String = Nothing
        Try
            Dim _Query As String = _
                "   WITH CTE AS (" & _
                "       SELECT Beg_OR, End_OR, Form, SRS, [User], Book_No, EnCoder, OR_Issued, OR_Used" & _
                "       FROM Receipts" & _
                "       WHERE Form = 'EOR' AND BackEnd = 0" & _
                "   )" & _
                "   UPDATE R" & _
                "   SET R.OR_Used = (" & _
                "       SELECT COUNT(*) AS ctr" & _
                "       FROM GEN_OR" & _
                "       WHERE GEN_OR.FORM_USE = CTE.Form" & _
                "           AND GEN_OR.BookNo = CTE.Book_No" & _
                "           AND GEN_OR.[user] = CTE.[User]" & _
                "           AND GEN_OR.or_no BETWEEN CTE.Beg_OR AND CTE.End_OR" & _
                "   )" & _
                "   FROM Receipts R" & _
                "   JOIN CTE ON R.Book_No = CTE.Book_No" & _
                "   WHERE R.Form = 'EOR';"
            qry = _Query
            Dim _SqlCommand As New SqlCommand(_Query, cGlobalConnections._pSqlCxn_TOIMS)
            '----------------------------------
            _SqlCommand.ExecuteNonQuery()
            '----------------------------------
            Return True
        Catch ex As Exception
            err = ";Update_Receipts:" & qry & ";" & ex.Message
            Return False
        End Try
    End Function

    ' 4. SELECT GEN_OR Details using PaymentRefNo
    Function Select_GEN_OR(ByVal PaymentRefNo As String, _
                           ByRef eORNO As String, _
                           ByRef SRS As String, _
                           ByRef OR_NO As String, _
                           ByRef Book_No As String, _
                           ByRef _USER As String, _
                           ByRef GateWay As String, _
                           ByRef or_date As String, _
                           Optional ByRef err As String = Nothing)
        Dim qry As String = Nothing

        Try
            Dim _Query As String = _
          " WITH CTE AS (SELECT Beg_OR, End_OR, Form, SRS, [User], Book_No, EnCoder, OR_Issued, OR_Used FROM Receipts WHERE Form = 'EOR') " &
          " select (CTE.SRS + CONVERT(varchar(6), GETDATE(), 112) + '-' + gen_or.OR_NO)eORNO,CTE.SRS,GEN_OR.OR_NO,CTE.Book_No,CTE.[User],GEN_OR.PaymentRefno,GEN_OR.Gateway,GEN_OR.or_date from gen_or   " &
          " JOIN CTE ON  GEN_OR.FORM_USE = CTE.Form " &
          "     AND GEN_OR.BookNo = CTE.Book_No " &
          "     AND GEN_OR.[user] = CTE.[User] " &
          "     AND GEN_OR.or_no BETWEEN CTE.Beg_OR AND CTE.End_OR " &
          " 	where PaymentRefno='" & PaymentRefNo & "'"

            qry = _Query
            Dim _SqlCommand = New SqlCommand(_Query, cGlobalConnections._pSqlCxn_TOIMS)
            Dim _nSqlDr As SqlDataReader = _SqlCommand.ExecuteReader
            Using _nSqlDr
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read
                        eORNO = _nSqlDr("eORNO").ToString
                        SRS = _nSqlDr("SRS").ToString
                        OR_NO = _nSqlDr("OR_NO").ToString
                        Book_No = _nSqlDr("Book_No").ToString
                        _USER = _nSqlDr("USER").ToString
                        GateWay = _nSqlDr("GateWay").ToString
                        or_date = _nSqlDr("or_date").ToString
                    Loop
                End If
            End Using
            Return True
        Catch ex As Exception
            err = ";Select_GEN_OR:" & qry & ";" & ex.Message
            Return False
        End Try

    End Function



    Public Function AutoPost(ByVal TransactionType As String, ByVal TDNBIN As String, ByVal AssessNo As String)
        Try

        Catch ex As Exception

        End Try
    End Function

    'Private Sub START_POSTING(ByRef err As String)
    '    Dim eORNO As String = Nothing
    '    Dim rand As New Random() ' Create a new instance of the Random class    
    '    Task.Delay((rand.Next(1, 20)) * 1000).Wait()

    '    _1PostPayment(err, eORNO)
    '    If String.IsNullOrEmpty(err) = False Then
    '        Exit Sub
    '    Else
    '        _2GetPostedDetails(err, eORNO)
    '        If String.IsNullOrEmpty(err) = False Then
    '            Exit Sub
    '        Else
    '            _3GenerateEORReport()
    '        End If
    '    End If

    'End Sub
    'Private Sub _1PostPayment(ByRef _err As String, ByRef eORNO As String)
    '    Try
    '        Dim _nClassEOR As New eOR
    '        Dim _nClassPP As New cDalPaymentPosting
    '        Dim _nClass As New cDalPayment
    '        Dim _nclassPDSRPTAS As New cDalPDSRPTAS
    '        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
    '        Dim dt As String
    '        Dim Sent As Boolean = False
    '        Dim Body As String = Nothing
    '        Dim _getdate As String = _nClass.Get_Date()
    '        Dim _Seq As String = Nothing
    '        Dim _EORNO As String = Nothing
    '        Dim _SRS As String = Nothing
    '        Dim _OR_NO As String = Nothing
    '        Dim _Book_No As String = Nothing
    '        Dim _User As String = Nothing
    '        Dim _GateWay As String = Nothing
    '        Dim _or_date As String = Nothing


    '        Dim qry As String = Nothing

    '        If _nClassEOR.ALL_IN_ONE(TransactionType, eOR.SPIDC_RefNo, qry, _err) = False Then
    '            Err = ";AIO:" & Err()
    '            Exit Sub
    '        End If

    '        If TransactionType = "RPT" Then
    '            _nClassPP.Taxpayer_Email = eOR.TaxPayerEmail
    '            _nClassPP.do_process(ACCTNO, _nClassEOR._PaymentRefNo, _nClassEOR._Gateway, _nClassEOR._OR_NO, _nClassEOR._SRS, _nClassEOR._Book_No, _nClassEOR.__USER, Err)
    '            ' _nClassPP.do_process(Process.ACCTNO, Process.SpidcRefNo, Process.Gateway_Selected, Process.EORNO, Process.SRS, _Book_No, _User, err)
    '            If String.IsNullOrEmpty(Err) = False Then
    '                Response.Write(Err)
    '                Exit Sub
    '            End If
    '            '     Process.SEQ = _nClassPP.Get_eORno(ACCTNO, TransactionType)

    '        ElseIf TransactionType = "BP" Then
    '            Dim clsBillOL As New BPLTAS_POSTING_ONLINE.clssBilling
    '            clsBillOL.CR_xSERVER = cGlobalConnections._pSqlCxn_CR.DataSource
    '            clsBillOL.CR_xDataBase = cGlobalConnections._pSqlCxn_CR.Database
    '            clsBillOL.CR_xUID = _nClassPP._mSubUIPW("UI", "OAIMS")
    '            clsBillOL.CR_xPW = _nClassPP._mSubUIPW("PW", "OAIMS")
    '            clsBillOL.BPLTAS_xACCTNO = ACCTNO
    '            clsBillOL.BPLTAS_TOTALPAID = CDbl(RawAmount)
    '            clsBillOL.BPLTAS_REFNO = _nClassEOR._PaymentRefNo
    '            clsBillOL.BPLTAS_DATEPAID = _nClass.Get_ServerDate()
    '            clsBillOL.BPLTAS_GATEWAY = _nClassEOR._Gateway
    '            clsBillOL.pORNO = _nClassEOR._OR_NO
    '            clsBillOL.pSRS = _nClassEOR._SRS
    '            clsBillOL.pSubProcessBilling()

    '        End If

    '        _nClass.Update_Transaction("MinORNO", _nClassEOR._eORNO, "txnrefno", _nClassEOR._PaymentRefNo)
    '        _nClass.Update_Transaction("MaxORNO", _nClassEOR._eORNO, "txnrefno", _nClassEOR._PaymentRefNo)

    '        eOR.SPIDC_RefNo = _nClassEOR._PaymentRefNo
    '        eOR.Gateway = _nClass.Get_Details("OnlinePaymentRefNo", "PaymentChannel", "TXNREFNO", _nClassEOR._PaymentRefNo)
    '        eOR.Gateway_RefNo = _nClass.Get_Details("OnlinePaymentRefNo", "GatewayRefNo", "TXNREFNO", _nClassEOR._PaymentRefNo)
    '        eOR.Gateway_ConfDate = _nClass.Get_Date()
    '        eOR.Gateway_Fee = _nClass.Get_Details("OnlinePaymentRefNo", "FeeAmount", "TXNREFNO", _nClassEOR._PaymentRefNo)
    '        eOR.SPIDC_Fee = _nClass.Get_Details("OnlinePaymentRefNo", "FeeAmountSPIDC", "TXNREFNO", _nClassEOR._PaymentRefNo)
    '        eOR.Bill_Amount = _nClass.Get_Details("OnlinePaymentRefNo", "RawAmount", "TXNREFNO", _nClassEOR._PaymentRefNo)
    '        eOR.GrandTotal = CDbl(eOR.Gateway_Fee) + CDbl(eOR.SPIDC_Fee) + CDbl(eOR.Bill_Amount)
    '        eOR.AssessNo = ACCTNO


    '        eORNO = _nClassEOR._eORNO


    '    Catch ex As Exception

    '    End Try
    'End Sub
    'Private Sub _2GetPostedDetails(ByRef _err As String, ByVal eORNO As String)
    '    Dim qry As String = Nothing
    '    Try
    '        Dim _nClassPP As New cDalPaymentPosting
    '        _nClassPP.Print_eOR(eORNO, _err, qry)
    '        If String.IsNullOrEmpty(_err) = False Then
    '            _err += ";" & qry
    '            Exit Sub
    '        End If

    '    Catch ex As Exception
    '        '  Response.Write(_err)
    '    End Try
    'End Sub
    'Private Sub _3GenerateEORReport()
    '    '  Response.Write("<script>window.open('WebPortal/Report/ReportViewer.aspx?ReportType=eOR&Send=1');</script>")
    '    ' Response.Write("<script>alert('Payment Success');window.location.replace('WebPortal/Account.aspx');</script>")
    'End Sub
End Class
