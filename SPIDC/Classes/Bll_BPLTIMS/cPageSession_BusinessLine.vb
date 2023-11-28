

#Region "Imports"

Imports System.Web.HttpContext

#End Region

Public Class cPageSession_BusinessLine

#Region "Variables"
    '_ssc = Session String Constant
    Private Const _sscPrefix As String = "cPageSession_Sample."

    Private Const _sscAddMode As String = _sscPrefix & "_sscAddMode"
    Private Const _sscEditMode As String = _sscPrefix & "_sscEditMode"

    Private Const _sscAccountNo As String = _sscPrefix & "_sscAccountNo"
    Private Const _sscOrigSample As String = _sscPrefix & "_sscOrigSample"

    Private Const _sscSvrDate As String = _sscPrefix & "_sscSvrDate"
    Private Const _sscDistCode As String = _sscPrefix & "_sscDistCode"
    Private Const _sscBrgyCode As String = _sscPrefix & "_sscBrgyCode"
    Private Const _sscxAccountNo As String = _sscPrefix & "_sscxAccountNo"
    Private Const _sscxForYear As String = _sscPrefix & "_sscxForYear"
    Private Const _sscxBusCode As String = _sscPrefix & "_sscxBusCode"
    Private Const _sscBUSCODE As String = _sscPrefix & "_sscBUSCODE"
    Private Const _sscLabelFee As String = "_sscLabelFee."

    '   @   Added 20170502  ------------------------------------------------
    Private Const _sscHeadingMode As String = _sscPrefix & "_sscHeadingMode"
    Private Const _sscOptionMode As String = _sscPrefix & "_sscOptionMode"
    Private Const _sscOptionBusDesc As String = _sscPrefix & "_sscOptionBusDesc"
    Private Const _sscOptionTaxCode As String = _sscPrefix & "_sscOptionTaxCode"
    Private Const _sscOptionTaxCode2 As String = _sscPrefix & "_sscOptionTaxCode2"
    Private Const _sscOptionTaxAmt As String = _sscPrefix & "_sscOptionTaxAmt"
    Private Const _sscOptionTaxRate As String = _sscPrefix & "_sscOptionTaxRate"

    '   @   Added 20170503  ------------------------------------------------
    Private Const _sscTaxField As String = _sscPrefix & "_sscTaxField"
    Private Const _sscTblCode As String = _sscPrefix & "_sscTblCode"
    Private Const _sscQtyMode As String = _sscPrefix & "_sscQtyMode"

    '   @   Added 20170509  ------------------------------------------------
    Private Const _sscTaxCode2Mode As String = _sscPrefix & "_sscTaxCode2Mode"

    '   @   Added 20170511  ------------------------------------------------
    Private Const _sscEff_Month As String = _sscPrefix & "_sscEff_Month"
    Private Const _sscEff_Year As String = _sscPrefix & "_sscEff_Year"

    '   @   Added 20170515  ------------------------------------------------
    Private Const _sscBCODE As String = _sscPrefix & "_sscBCODE"
    Private Const _sscMCODE As String = _sscPrefix & "_sscMCODE"
    Private Const _sscGCODE As String = _sscPrefix & "_sscGCODE"
    Private Const _sscSCODE As String = _sscPrefix & "_sscSCODE"
    Private Const _sscFCODE As String = _sscPrefix & "_sscFCODE"

    '   @   Added 20170811  ------------------------------------------------
    Private Const _sscELECCODE As String = _sscPrefix & "_sscELECCODE"
    Private Const _sscMECHCODE As String = _sscPrefix & "_sscMECHCODE"
    Private Const _sscBLDGCODE As String = _sscPrefix & "_sscBLDGCODE"
    Private Const _sscSIGNCODE As String = _sscPrefix & "_sscSIGNCODE"
    Private Const _sscEPOCODE As String = _sscPrefix & "_sscEPOCODE"
    Private Const _sscEIFCODE As String = _sscPrefix & "_sscEIFCODE"
    Private Const _sscPLATECODE As String = _sscPrefix & "_sscPLATECODE"

    '   @   Added 20170519  ------------------------------------------------
    Private Const _sscExit_BCODE As String = _sscPrefix & "_sscExit_BCODE"
    Private Const _sscExit_MCODE As String = _sscPrefix & "_sscExit_MCODE"
    Private Const _sscExit_GCODE As String = _sscPrefix & "_sscExit_GCODE"
    Private Const _sscExit_SCODE As String = _sscPrefix & "_sscExit_SCODE"
    Private Const _sscExit_FCODE As String = _sscPrefix & "_sscExit_FCODE"

    '   @   Added 20170811  ------------------------------------------------
    Private Const _sscExit_ELECCODE As String = _sscPrefix & "_sscExit_ELECCODE"
    Private Const _sscExit_MECHCODE As String = _sscPrefix & "_sscExit_MECHCODE"
    Private Const _sscExit_BLDGCODE As String = _sscPrefix & "_sscExit_BLDGCODE"
    Private Const _sscExit_SIGNCODE As String = _sscPrefix & "_sscExit_SIGNCODE"
    Private Const _sscExit_EPOCODE As String = _sscPrefix & "_sscExit_EPOCODE"
    Private Const _sscExit_EIFCODE As String = _sscPrefix & "_sscExit_EIFCODE"
    Private Const _sscExit_PLATECODE As String = _sscPrefix & "_sscExit_PLATECODE"

    Private Const _sscELECCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscELECCODE_TaxCode"
    Private Const _sscELECCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscELECCODE_EffMonth"
    Private Const _sscELECCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscELECCODE_EffYear"
    Private Const _sscELECCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscELECCODE_TaxAmt"
    Private Const _sscELECCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscELECCODE_TaxRate"
    Private Const _sscELECCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscELECCODE_TaxMin"
    Private Const _sscELECCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscELECCODE_TaxMax"
    Private Const _sscELECCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscELECCODE_FinalTax"

    Private Const _sscMECHCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscMECHCODE_TaxCode"
    Private Const _sscMECHCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscMECHCODE_EffMonth"
    Private Const _sscMECHCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscMECHCODE_EffYear"
    Private Const _sscMECHCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscMECHCODE_TaxAmt"
    Private Const _sscMECHCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscMECHCODE_TaxRate"
    Private Const _sscMECHCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscMECHCODE_TaxMin"
    Private Const _sscMECHCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscMECHCODE_TaxMax"
    Private Const _sscMECHCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscMECHCODE_FinalTax"

    Private Const _sscBLDGCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscBLDGCODE_TaxCode"
    Private Const _sscBLDGCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscBLDGCODE_EffMonth"
    Private Const _sscBLDGCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscBLDGCODE_EffYear"
    Private Const _sscBLDGCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscBLDGCODE_TaxAmt"
    Private Const _sscBLDGCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscBLDGCODE_TaxRate"
    Private Const _sscBLDGCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscBLDGCODE_TaxMin"
    Private Const _sscBLDGCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscBLDGCODE_TaxMax"
    Private Const _sscBLDGCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscBLDGCODE_FinalTax"

    Private Const _sscSIGNCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscSIGNCODE_TaxCode"
    Private Const _sscSIGNCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscSIGNCODE_EffMonth"
    Private Const _sscSIGNCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscSIGNCODE_EffYear"
    Private Const _sscSIGNCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscSIGNCODE_TaxAmt"
    Private Const _sscSIGNCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscSIGNCODE_TaxRate"
    Private Const _sscSIGNCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscSIGNCODE_TaxMin"
    Private Const _sscSIGNCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscSIGNCODE_TaxMax"
    Private Const _sscSIGNCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscSIGNCODE_FinalTax"

    Private Const _sscEPOCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscEPOCODE_TaxCode"
    Private Const _sscEPOCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscEPOCODE_EffMonth"
    Private Const _sscEPOCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscEPOCODE_EffYear"
    Private Const _sscEPOCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscEPOCODE_TaxAmt"
    Private Const _sscEPOCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscEPOCODE_TaxRate"
    Private Const _sscEPOCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscEPOCODE_TaxMin"
    Private Const _sscEPOCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscEPOCODE_TaxMax"
    Private Const _sscEPOCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscEPOCODE_FinalTax"

    Private Const _sscEIFCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscEIFCODE_TaxCode"
    Private Const _sscEIFCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscEIFCODE_EffMonth"
    Private Const _sscEIFCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscEIFCODE_EffYear"
    Private Const _sscEIFCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscEIFCODE_TaxAmt"
    Private Const _sscEIFCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscEIFCODE_TaxRate"
    Private Const _sscEIFCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscEIFCODE_TaxMin"
    Private Const _sscEIFCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscEIFCODE_TaxMax"
    Private Const _sscEIFCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscEIFCODE_FinalTax"

    Private Const _sscPLATECODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscPLATECODE_TaxCode"
    Private Const _sscPLATECODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscPLATECODE_EffMonth"
    Private Const _sscPLATECODE_GRADTABL_EffYear As String = _sscPrefix & "_sscPLATECODE_EffYear"
    Private Const _sscPLATECODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscPLATECODE_TaxAmt"
    Private Const _sscPLATECODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscPLATECODE_TaxRate"
    Private Const _sscPLATECODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscPLATECODE_TaxMin"
    Private Const _sscPLATECODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscPLATECODE_TaxMax"
    Private Const _sscPLATECODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscPLATECODE_FinalTax"

    Private Const _sscELECCODE_GRADTABL_RTaxRate As String = _sscPrefix & "_sscELECCODE_RTaxRate"
    Private Const _sscMECHCODE_GRADTABL_RTaxRate As String = _sscPrefix & "_sscMECHCODE_RTaxRate"
    Private Const _sscBLDGCODE_GRADTABL_RTaxRate As String = _sscPrefix & "_sscBLDGCODE_RTaxRate"
    Private Const _sscSIGNCODE_GRADTABL_RTaxRate As String = _sscPrefix & "_sscSIGNCODE_RTaxRate"
    Private Const _sscEPOCODE_GRADTABL_RTaxRate As String = _sscPrefix & "_sscEPOCODE_RTaxRate"
    Private Const _sscEIFCODE_GRADTABL_RTaxRate As String = _sscPrefix & "_sscEIFCODE_RTaxRate"
    Private Const _sscPLATECODE_GRADTABL_RTaxRate As String = _sscPrefix & "_sscPLATECO_RTaxRate"

    Private Const _sscELECCODE_GRADTABL_RTaxAmt As String = _sscPrefix & "_sscELECCODE_RTaxAmt"
    Private Const _sscMECHCODE_GRADTABL_RTaxAmt As String = _sscPrefix & "_sscMECHCODE_RTaxAmt"
    Private Const _sscBLDGCODE_GRADTABL_RTaxAmt As String = _sscPrefix & "_sscBLDGCODE_RTaxAmt"
    Private Const _sscSIGNCODE_GRADTABL_RTaxAmt As String = _sscPrefix & "_sscSIGNCODE_RTaxAmt"
    Private Const _sscEPOCODE_GRADTABL_RTaxAmt As String = _sscPrefix & "_sscEPOCODE_RTaxAmt"
    Private Const _sscEIFCODE_GRADTABL_RTaxAmt As String = _sscPrefix & "_sscEIFCODE_RTaxAmt"
    Private Const _sscPLATECODE_GRADTABL_RTaxAmt As String = _sscPrefix & "_sscPLATECODE_RTaxAmt"



    Private Const _sscELECCODE_GRASKQTY_TaxAmt As String = _sscPrefix & "_sscELECCODE_RTaxAmt"
    Private Const _sscMECHCODE_GRASKQTY_TaxAmt As String = _sscPrefix & "_sscMECHCODE_RTaxAmt"
    Private Const _sscBLDGCODE_GRASKQTY_TaxAmt As String = _sscPrefix & "_sscBLDGCODE_RTaxAmt"
    Private Const _sscSIGNCODE_GRASKQTY_TaxAmt As String = _sscPrefix & "_sscSIGNCODE_RTaxAmt"
    Private Const _sscEPOCODE_GRASKQTY_TaxAmt As String = _sscPrefix & "_sscEPOCODE_RTaxAmt"
    Private Const _sscEIFCODE_GRASKQTY_TaxAmt As String = _sscPrefix & "_sscEIFCODE_RTaxAmt"
    Private Const _sscPLATECODE_GRASKQTY_TaxAmt As String = _sscPrefix & "_sscPLATECODE_RTaxAmt"

    Private Const _sscFEE_GRASKQTY_TaxAmt1 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt1"
    Private Const _sscFEE_GRASKQTY_TaxAmt2 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt2"
    Private Const _sscFEE_GRASKQTY_TaxAmt3 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt3"
    Private Const _sscFEE_GRASKQTY_TaxAmt4 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt4"
    Private Const _sscFEE_GRASKQTY_TaxAmt5 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt5"
    Private Const _sscFEE_GRASKQTY_TaxAmt6 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt6"
    Private Const _sscFEE_GRASKQTY_TaxAmt7 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt7"
    Private Const _sscFEE_GRASKQTY_TaxAmt8 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt8"
    Private Const _sscFEE_GRASKQTY_TaxAmt9 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt9"
    Private Const _sscFEE_GRASKQTY_TaxAmt10 As String = _sscPrefix & "_sscFEE_GRASKQTY_TaxAmt10"

    Private Const _sscSTATCODE As String = _sscPrefix & "_sscSTATCODE"
    Private Const _sscELECCODE_FEE As String = _sscPrefix & "_sscELECCODE_FEE"
    Private Const _sscMECHCODE_FEE As String = _sscPrefix & "_sscMECHCODE_FEE"
    Private Const _sscBLDGCODE_FEE As String = _sscPrefix & "_sscBLDGCODE_FEE"
    Private Const _sscSIGNCODE_FEE As String = _sscPrefix & "_sscSIGNCODE_FEE"
    Private Const _sscEPOCODE_FEE As String = _sscPrefix & "_sscEPOCODE_FEE"
    Private Const _sscEIFCODE_FEE As String = _sscPrefix & "_sscEIFCODE_FEE"
    Private Const _sscPLATECODE_FEE As String = _sscPrefix & "_sscPLATECODE_FEE"

    Private Const _sscBCODE_FEE As String = _sscPrefix & "_sscBCODE_FEE"
    Private Const _sscMCODE_FEE As String = _sscPrefix & "_sscBCODE_FEE"
    Private Const _sscGCODE_FEE As String = _sscPrefix & "_sscBCODE_FEE"
    Private Const _sscSCODE_FEE As String = _sscPrefix & "_sscBCODE_FEE"
    Private Const _sscFCODE_FEE As String = _sscPrefix & "_sscBCODE_FEE"


    Private Const _sscAREA As String = _sscPrefix & "_sscAREA"
    Private Const _sscCAPITAL As String = _sscPrefix & "_sscCAPITAL"
    Private Const _sscGROSS As String = _sscPrefix & "_sscGROSS"

    '   @   Added 20170614  ------------------------------------------------------------------
    Private Const _sscBCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscBCODE_TaxCode"
    Private Const _sscBCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscBCODE_EffMonth"
    Private Const _sscBCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscBCODE_EffYear"
    Private Const _sscBCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscBCODE_TaxAmt"
    Private Const _sscBCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscBCODE_TaxRate"
    Private Const _sscBCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscBCODE_TaxMin"
    Private Const _sscBCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscBCODE_TaxMax"
    Private Const _sscBCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscBCODE_FinalTax"

    Private Const _sscMCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscMCODE_TaxCode"
    Private Const _sscMCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscMCODE_EffMonth"
    Private Const _sscMCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscMCODE_EffYear"
    Private Const _sscMCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscMCODE_TaxAmt"
    Private Const _sscMCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscMCODE_TaxRate"
    Private Const _sscMCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscMCODE_TaxMin"
    Private Const _sscMCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscMCODE_TaxMax"
    Private Const _sscMCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscBCODE_FinalTax"

    Private Const _sscGCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscGCODE_TaxCode"
    Private Const _sscGCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscGCODE_EffMonth"
    Private Const _sscGCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscGCODE_EffYear"
    Private Const _sscGCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscGCODE_TaxAmt"
    Private Const _sscGCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscGCODE_TaxRate"
    Private Const _sscGCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscGCODE_TaxMin"
    Private Const _sscGCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscGCODE_TaxMax"
    Private Const _sscGCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscBCODE_FinalTax"

    Private Const _sscSCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscSCODE_TaxCode"
    Private Const _sscSCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscSCODE_EffMonth"
    Private Const _sscSCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscSCODE_EffYear"
    Private Const _sscSCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscSCODE_TaxAmt"
    Private Const _sscSCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscSCODE_TaxRate"
    Private Const _sscFCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscFCODE_TaxMin"
    Private Const _sscSCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscSCODE_TaxMax"
    Private Const _sscSCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscBCODE_FinalTax"

    Private Const _sscFCODE_GRADTABL_TaxCode As String = _sscPrefix & "_sscFCODE_TaxCode"
    Private Const _sscFCODE_GRADTABL_EffMonth As String = _sscPrefix & "_sscFCODE_EffMonth"
    Private Const _sscFCODE_GRADTABL_EffYear As String = _sscPrefix & "_sscFCODE_EffYear"
    Private Const _sscFCODE_GRADTABL_TaxAmt As String = _sscPrefix & "_sscFCODE_TaxAmt"
    Private Const _sscFCODE_GRADTABL_TaxRate As String = _sscPrefix & "_sscFCODE_TaxRate"
    Private Const _sscSCODE_GRADTABL_TaxMin As String = _sscPrefix & "_sscSCODE_TaxMin"
    Private Const _sscFCODE_GRADTABL_TaxMax As String = _sscPrefix & "_sscFCODE_TaxMax"
    Private Const _sscFCODE_GRADTABL_FinalTax As String = _sscPrefix & "_sscBCODE_FinalTax"

    '   @   Added 20170812  ------------------------------------------------------------------
    Private Const _sscELECCODE_GRASKHDG_Val As String = _sscPrefix & "_sscELECCODE_GRASKHDG_Val"
    Private Const _sscELECCODE_GRASKHDG_Year As String = _sscPrefix & "_sscELECCODE_GRASKHDG_Year"
    Private Const _sscELECCODE_GRASKHDG_Month As String = _sscPrefix & "_sscELECCODE_GRASKHDG_Month"

    Private Const _sscMECHCODE_GRASKHDG_Val As String = _sscPrefix & "_sscMECHCODE_GRASKHDG_Val"
    Private Const _sscMECHCODE_GRASKHDG_Year As String = _sscPrefix & "_sscMECHCODE_GRASKHDG_Year"
    Private Const _sscMECHCODE_GRASKHDG_Month As String = _sscPrefix & "_sscMECHCODE_GRASKHDG_Month"

    Private Const _sscBLDGCODE_GRASKHDG_Val As String = _sscPrefix & "_sscBLDGCODE_GRASKHDG_Val"
    Private Const _sscBLDGCODE_GRASKHDG_Year As String = _sscPrefix & "_sscBLDGCODE_GRASKHDG_Year"
    Private Const _sscBLDGCODE_GRASKHDG_Month As String = _sscPrefix & "_sscBLDGCODE_GRASKHDG_Month"

    Private Const _sscSIGNCODE_GRASKHDG_Val As String = _sscPrefix & "_sscSIGNCODE_GRASKHDG_Val"
    Private Const _sscSIGNCODE_GRASKHDG_Year As String = _sscPrefix & "_sscSIGNCODE_GRASKHDG_Year"
    Private Const _sscSIGNCODE_GRASKHDG_Month As String = _sscPrefix & "_sscSIGNCODE_GRASKHDG_Month"

    Private Const _sscEPOCODE_GRASKHDG_Val As String = _sscPrefix & "_sscEPOCODE_GRASKHDG_Val"
    Private Const _sscEPOCODE_GRASKHDG_Year As String = _sscPrefix & "_sscEPOCODE_GRASKHDG_Year"
    Private Const _sscEPOCODE_GRASKHDG_Month As String = _sscPrefix & "_sscEPOCODE_GRASKHDG_Month"

    Private Const _sscEIFCODE_GRASKHDG_Val As String = _sscPrefix & "_sscEIFCODE_GRASKHDG_Val"
    Private Const _sscEIFCODE_GRASKHDG_Year As String = _sscPrefix & "_sscEIFCODE_GRASKHDG_Year"
    Private Const _sscEIFCODE_GRASKHDG_Month As String = _sscPrefix & "_sscEIFCODE_GRASKHDG_Month"

    Private Const _sscPLATECODE_GRASKHDG_Val As String = _sscPrefix & "_sscPLATECODE_GRASKHDG_Val"
    Private Const _sscPLATECODE_GRASKHDG_Year As String = _sscPrefix & "_sscPLATECODE_GRASKHDG_Year"
    Private Const _sscPLATECODE_GRASKHDG_Month As String = _sscPrefix & "_sscPLATECODE_GRASKHDG_Month"

    Private Const _sscTempLogName As String = _sscPrefix & "_sscTempLogName"
    Private Const _sscStatMain As String = _sscPrefix & "_sscStatMain"

    '   @   Added 20170616  ------------------------------------------------------------------
    Private Const _sscBCODE_GRASKHDG_Val As String = _sscPrefix & "_sscBCODE_GRASKHDG_Val"
    Private Const _sscMCODE_GRASKHDG_Val As String = _sscPrefix & "_sscMCODE_GRASKHDG_Val"
    Private Const _sscGCODE_GRASKHDG_Val As String = _sscPrefix & "_sscGCODE_GRASKHDG_Val"
    Private Const _sscSCODE_GRASKHDG_Val As String = _sscPrefix & "_sscSCODE_GRASKHDG_Val"
    Private Const _sscFCODE_GRASKHDG_Val As String = _sscPrefix & "_sscFCODE_GRASKHDG_Val"

    Private Const _sscBCODE_GRASKHDG_Year As String = _sscPrefix & "_sscBCODE_GRASKHDG_Year"
    Private Const _sscMCODE_GRASKHDG_Year As String = _sscPrefix & "_sscMCODE_GRASKHDG_Year"
    Private Const _sscGCODE_GRASKHDG_Year As String = _sscPrefix & "_sscGCODE_GRASKHDG_Year"
    Private Const _sscSCODE_GRASKHDG_Year As String = _sscPrefix & "_sscSCODE_GRASKHDG_Year"
    Private Const _sscFCODE_GRASKHDG_Year As String = _sscPrefix & "_sscFCODE_GRASKHDG_Year"

    Private Const _sscBCODE_GRASKHDG_Month As String = _sscPrefix & "_sscBCODE_GRASKHDG_Month"
    Private Const _sscMCODE_GRASKHDG_Month As String = _sscPrefix & "_sscMCODE_GRASKHDG_Month"
    Private Const _sscGCODE_GRASKHDG_Month As String = _sscPrefix & "_sscGCODE_GRASKHDG_Month"
    Private Const _sscSCODE_GRASKHDG_Month As String = _sscPrefix & "_sscSCODE_GRASKHDG_Month"
    Private Const _sscFCODE_GRASKHDG_Month As String = _sscPrefix & "_sscFCODE_GRASKHDG_Month"

    '-----------------------------------------------------------------------------------------
    Private Const _sscBCODE_Option_TaxCode As String = _sscPrefix & "_sscBCODE_Option_TaxCode"
    Private Const _sscMCODE_Option_TaxCode As String = _sscPrefix & "_sscMCODE_Option_TaxCode"
    Private Const _sscSCODE_Option_TaxCode As String = _sscPrefix & "_sscSCODE_Option_TaxCode"
    Private Const _sscGCODE_Option_TaxCode As String = _sscPrefix & "_sscGCODE_Option_TaxCode"
    Private Const _sscFCODE_Option_TaxCode As String = _sscPrefix & "_sscFCODE_Option_TaxCode"

    Private Const _sscBCODE_Option_TaxDesc As String = _sscPrefix & "_sscBCODE_Option_TaxDesc"
    Private Const _sscMCODE_Option_TaxDesc As String = _sscPrefix & "_sscMCODE_Option_TaxDesc"
    Private Const _sscSCODE_Option_TaxDesc As String = _sscPrefix & "_sscSCODE_Option_TaxDesc"
    Private Const _sscGCODE_Option_TaxDesc As String = _sscPrefix & "_sscGCODE_Option_TaxDesc"
    Private Const _sscFCODE_Option_TaxDesc As String = _sscPrefix & "_sscFCODE_Option_TaxDesc"

    Private Const _sscBCODE_Option_TaxYear As String = _sscPrefix & "_sscBCODE_Option_TaxCode"
    Private Const _sscMCODE_Option_TaxYear As String = _sscPrefix & "_sscMCODE_Option_TaxCode"
    Private Const _sscSCODE_Option_TaxYear As String = _sscPrefix & "_sscSCODE_Option_TaxCode"
    Private Const _sscGCODE_Option_TaxYear As String = _sscPrefix & "_sscGCODE_Option_TaxCode"
    Private Const _sscFCODE_Option_TaxYear As String = _sscPrefix & "_sscFCODE_Option_TaxCode"

    Private Const _sscBCODE_Option_RowNo As String = _sscPrefix & "_sscBCODE_Option_RowNo"
    Private Const _sscMCODE_Option_RowNo As String = _sscPrefix & "_sscMCODE_Option_RowNo"
    Private Const _sscSCODE_Option_RowNo As String = _sscPrefix & "_sscSCODE_Option_RowNo"
    Private Const _sscGCODE_Option_RowNo As String = _sscPrefix & "_sscGCODE_Option_RowNo"
    Private Const _sscFCODE_Option_RowNo As String = _sscPrefix & "_sscFCODE_Option_RowNo"

    Private Const _sscOption_RowNo As String = _sscPrefix & "_ssOption_RowNo"
    '-----------------------------------------------------------------------------------------
    Private Const _sscELECCODE_Option_RowNo As String = _sscPrefix & "_sscELECCODE_Option_RowNo"
    Private Const _sscMECHCODE_Option_RowNo As String = _sscPrefix & "_sscMECHCODE_Option_RowNo"
    Private Const _sscBLDGCODE_Option_RowNo As String = _sscPrefix & "_sscBLDGCODE_Option_RowNo"
    Private Const _sscSIGNCODE_Option_RowNo As String = _sscPrefix & "_sscSIGNCODE_Option_RowNo"
    Private Const _sscEPOCODE_Option_RowNo As String = _sscPrefix & "_sscEPOCODE_Option_RowNo"
    Private Const _sscEIFCODE_Option_RowNo As String = _sscPrefix & "_sscEIFCODE_Option_RowNo"
    Private Const _sscPLATECODE_Option_RowNo As String = _sscPrefix & "_sscPLATECODE_Option_RowNo"

    Private Const _sscELECCODE_Option_TaxYear As String = _sscPrefix & "_sscELECCODE_Option_TaxYear"
    Private Const _sscMECHCODE_Option_TaxYear As String = _sscPrefix & "_sscMECHCODE_Option_TaxYear"
    Private Const _sscBLDGCODE_Option_TaxYear As String = _sscPrefix & "_sscBLDGCODE_Option_TaxYear"
    Private Const _sscSIGNCODE_Option_TaxYear As String = _sscPrefix & "_sscSIGNCODE_Option_TaxYear"
    Private Const _sscEPOCODE_Option_TaxYear As String = _sscPrefix & "_sscEPOCODE_Option_TaxYear"
    Private Const _sscEIFCODE_Option_TaxYear As String = _sscPrefix & "_sscEIFCODE_Option_TaxYear"
    Private Const _sscPLATECODE_Option_TaxYear As String = _sscPrefix & "_sscPLATECODE_Option_TaxYear"

    Private Const _sscELECCODE_Option_TaxDesc As String = _sscPrefix & "_sscELECCODE_Option_TaxDesc"
    Private Const _sscMECHCODE_Option_TaxDesc As String = _sscPrefix & "_sscMECHCODE_Option_TaxDesc"
    Private Const _sscBLDGCODE_Option_TaxDesc As String = _sscPrefix & "_sscBLDGCODE_Option_TaxDesc"
    Private Const _sscSIGNCODE_Option_TaxDesc As String = _sscPrefix & "_sscSIGNCODE_Option_TaxDesc"
    Private Const _sscEPOCODE_Option_TaxDesc As String = _sscPrefix & "_sscEPOCODE_Option_TaxDesc"
    Private Const _sscEIFCODE_Option_TaxDesc As String = _sscPrefix & "_sscEIFCODE_Option_TaxDesc"
    Private Const _sscPLATECODE_Option_TaxDesc As String = _sscPrefix & "_sscPLATECODE_Option_TaxDesc"

    Private Const _sscELECCODE_Option_TaxCode As String = _sscPrefix & "_sscELECCODE_Option_TaxCode"
    Private Const _sscMECHCODE_Option_TaxCode As String = _sscPrefix & "_sscMECHCODE_Option_TaxCode"
    Private Const _sscBLDGCODE_Option_TaxCode As String = _sscPrefix & "_sscBLDGCODE_Option_TaxCode"
    Private Const _sscSIGNCODE_Option_TaxCode As String = _sscPrefix & "_sscSIGNCODE_Option_TaxCode"
    Private Const _sscEPOCODE_Option_TaxCode As String = _sscPrefix & "_sscEPOCODE_Option_TaxCode"
    Private Const _sscEIFCODE_Option_TaxCode As String = _sscPrefix & "_sscEIFCODE_Option_TaxCode"
    Private Const _sscPLATECODE_Option_TaxCode As String = _sscPrefix & "_sscPLATECODE_Option_TaxCode"

    '-----------------------------------------------------------------------------------------

    Private Const _sscELECCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val1"
    Private Const _sscELECCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val2"
    Private Const _sscELECCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val3"
    Private Const _sscELECCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val4"
    Private Const _sscELECCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val5"
    Private Const _sscELECCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val6"
    Private Const _sscELECCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val7"
    Private Const _sscELECCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val8"
    Private Const _sscELECCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val9"
    Private Const _sscELECCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscELECCODE_ GRASKQTY_Val0"

    Private Const _sscMECHCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val1"
    Private Const _sscMECHCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val2"
    Private Const _sscMECHCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val3"
    Private Const _sscMECHCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val4"
    Private Const _sscMECHCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val5"
    Private Const _sscMECHCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val6"
    Private Const _sscMECHCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val7"
    Private Const _sscMECHCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val8"
    Private Const _sscMECHCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val9"
    Private Const _sscMECHCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscMECHCODE_ GRASKQTY_Val0"

    Private Const _sscBLDGCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val1"
    Private Const _sscBLDGCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val2"
    Private Const _sscBLDGCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val3"
    Private Const _sscBLDGCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val4"
    Private Const _sscBLDGCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val5"
    Private Const _sscBLDGCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val6"
    Private Const _sscBLDGCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val7"
    Private Const _sscBLDGCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val8"
    Private Const _sscBLDGCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val9"
    Private Const _sscBLDGCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscBLDGCODE_ GRASKQTY_Val0"

    Private Const _sscSIGNCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val1"
    Private Const _sscSIGNCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val2"
    Private Const _sscSIGNCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val3"
    Private Const _sscSIGNCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val4"
    Private Const _sscSIGNCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val5"
    Private Const _sscSIGNCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val6"
    Private Const _sscSIGNCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val7"
    Private Const _sscSIGNCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val8"
    Private Const _sscSIGNCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val9"
    Private Const _sscSIGNCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscSIGNCODE_ GRASKQTY_Val0"

    Private Const _sscEPOCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val1"
    Private Const _sscEPOCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val2"
    Private Const _sscEPOCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val3"
    Private Const _sscEPOCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val4"
    Private Const _sscEPOCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val5"
    Private Const _sscEPOCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val6"
    Private Const _sscEPOCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val7"
    Private Const _sscEPOCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val8"
    Private Const _sscEPOCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val9"
    Private Const _sscEPOCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscEPOCODE_ GRASKQTY_Val0"

    Private Const _sscEIFCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val1"
    Private Const _sscEIFCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val2"
    Private Const _sscEIFCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val3"
    Private Const _sscEIFCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val4"
    Private Const _sscEIFCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val5"
    Private Const _sscEIFCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val6"
    Private Const _sscEIFCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val7"
    Private Const _sscEIFCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val8"
    Private Const _sscEIFCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val9"
    Private Const _sscEIFCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscEIFCODE_ GRASKQTY_Val0"

    Private Const _sscPLATECODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val1"
    Private Const _sscPLATECODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val2"
    Private Const _sscPLATECODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val3"
    Private Const _sscPLATECODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val4"
    Private Const _sscPLATECODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val5"
    Private Const _sscPLATECODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val6"
    Private Const _sscPLATECODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val7"
    Private Const _sscPLATECODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val8"
    Private Const _sscPLATECODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val9"
    Private Const _sscPLATECODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscPLATECODE_ GRASKQTY_Val0"

    Private Const _sscBCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val1"
    Private Const _sscBCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val2"
    Private Const _sscBCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val3"
    Private Const _sscBCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val4"
    Private Const _sscBCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val5"
    Private Const _sscBCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val6"
    Private Const _sscBCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val7"
    Private Const _sscBCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val8"
    Private Const _sscBCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val9"
    Private Const _sscBCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscBCODE_ GRASKQTY_Val0"

    Private Const _sscMCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val1"
    Private Const _sscMCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val2"
    Private Const _sscMCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val3"
    Private Const _sscMCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val4"
    Private Const _sscMCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val5"
    Private Const _sscMCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val6"
    Private Const _sscMCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val7"
    Private Const _sscMCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val8"
    Private Const _sscMCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val9"
    Private Const _sscMCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscMCODE_ GRASKQTY_Val0"

    Private Const _sscGCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val1"
    Private Const _sscGCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val2"
    Private Const _sscGCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val3"
    Private Const _sscGCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val4"
    Private Const _sscGCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val5"
    Private Const _sscGCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val6"
    Private Const _sscGCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val7"
    Private Const _sscGCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val8"
    Private Const _sscGCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val9"
    Private Const _sscGCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscGCODE_ GRASKQTY_Val0"

    Private Const _sscSCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val1"
    Private Const _sscSCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val2"
    Private Const _sscSCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val3"
    Private Const _sscSCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val4"
    Private Const _sscSCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val5"
    Private Const _sscSCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val6"
    Private Const _sscSCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val7"
    Private Const _sscSCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val8"
    Private Const _sscSCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val9"
    Private Const _sscSCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscSCODE_ GRASKQTY_Val0"

    Private Const _sscFCODE_GRASKQTY_Val1 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val1"
    Private Const _sscFCODE_GRASKQTY_Val2 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val2"
    Private Const _sscFCODE_GRASKQTY_Val3 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val3"
    Private Const _sscFCODE_GRASKQTY_Val4 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val4"
    Private Const _sscFCODE_GRASKQTY_Val5 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val5"
    Private Const _sscFCODE_GRASKQTY_Val6 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val6"
    Private Const _sscFCODE_GRASKQTY_Val7 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val7"
    Private Const _sscFCODE_GRASKQTY_Val8 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val8"
    Private Const _sscFCODE_GRASKQTY_Val9 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val9"
    Private Const _sscFCODE_GRASKQTY_Val10 As String = _sscPrefix & "_sscFCODE_ GRASKQTY_Val0"
    '------------------------------------------------------------------------------------------
    Private Const _sscBCHOICE As String = _sscPrefix & "_sscBCHOICE "
    Private Const _sscMCHOICE As String = _sscPrefix & "_sscMCHOICE "
    Private Const _sscGCHOICE As String = _sscPrefix & "_sscGCHOICE "
    Private Const _sscSCHOICE As String = _sscPrefix & "_sscSCHOICE "
    Private Const _sscFCHOICE As String = _sscPrefix & "_sscFCHOICE "

    Private Const _sscBCHOICE_trg As String = _sscPrefix & "_sscBCHOICE_trg "
    Private Const _sscMCHOICE_trg As String = _sscPrefix & "_sscMCHOICE_trg "
    Private Const _sscGCHOICE_trg As String = _sscPrefix & "_sscGCHOICE_trg "
    Private Const _sscSCHOICE_trg As String = _sscPrefix & "_sscSCHOICE_trg "
    Private Const _sscFCHOICE_trg As String = _sscPrefix & "_sscFCHOICE_trg "

    Private Const _sscBUSTAX As String = _sscPrefix & "_sscBUSTAX "
    Private Const _sscMAYORS As String = _sscPrefix & "_sscMAYORS "
    Private Const _sscGARBAGE As String = _sscPrefix & "_sscGARBAGE "
    Private Const _sscSANITARY As String = _sscPrefix & "_sscSANITARY "
    Private Const _sscFIRE As String = _sscPrefix & "_sscFIRE "

    Private Const _sscGARBAGE_o As String = _sscPrefix & "_sscGARBAGE_o "
    Private Const _sscSANITARY_o As String = _sscPrefix & "_sscSANITARY_o "
    Private Const _sscFIRE_o As String = _sscPrefix & "_sscFIRE_o "
    Private Const _sscNewsw_o As String = _sscPrefix & "_sscFIRE_o "

    Private Const _sscTempYr As String = _sscPrefix & "_sscTempYr " '@ Added 20170710
    Private Const _sscTempMo As String = _sscPrefix & "_sscTempMo " '@ Added 20170710
    Private Const _sscTAXBASE As String = _sscPrefix & "_sscTAXBASE " '@ Added 20170710
    Private Const _sscTaxDueMin As String = _sscPrefix & "_sscTaxDueMin " '@ Added 20170710
    Private Const _sscTaxDueMax As String = _sscPrefix & "_sscTaxDueMax " '@ Added 20170710
    Private Const _sscMTaxCode As String = _sscPrefix & "_sscMTaxCode " '@ Added 20170710

    Private Const _sscBCODE_Val As String = _sscPrefix & "_sscBCODE_o " '@ Added 20170713
    Private Const _sscMCODE_Val As String = _sscPrefix & "_sscMCODE_o " '@ Added 20170713
    Private Const _sscGCODE_Val As String = _sscPrefix & "_sscGCODE_o " '@ Added 20170713
    Private Const _sscSCODE_Val As String = _sscPrefix & "_sscSCODE_o " '@ Added 20170713
    Private Const _sscFCODE_Val As String = _sscPrefix & "_sscFCODE_o " '@ Added 20170713

    Private Const _sscExitProcedure As String = _sscPrefix & "_sscExitProcedure " '@ Added 20170808

    Private Const _ssc_RowCountBusline As String = _sscPrefix & "_ssc_RowCountBusline "
    Private Const _ssc_RowCountBuslineList As String = _sscPrefix & "_ssc_RowCountBuslineList "
    Private Const _ssc_RowCountBuslineOption As String = _sscPrefix & "_ssc_RowCountBuslineOption "

    Private Const _sscELECCODE_processed As String = _sscPrefix & "_sscELECCODE_processed" '@ Added 20180716
    Private Const _sscMECHCODE_processed As String = _sscPrefix & "_sscMECHCODE_processed" '@ Added 20180716
    Private Const _sscBLDGCODE_processed As String = _sscPrefix & "_sscBLDGCODE_processed" '@ Added 20180716
    Private Const _sscSIGNCODE_processed As String = _sscPrefix & "_sscSIGNCODE_processed" '@ Added 20180716
    Private Const _sscEPOCODE_processed As String = _sscPrefix & "_sscEPOCODE_processed" '@ Added 20180716
    Private Const _sscEIFCODE_processed As String = _sscPrefix & "_sscEIFCODE_processed" '@ Added 20180716
    Private Const _sscPLATECODE_processed As String = _sscPrefix & "_sscPLATECODE_processed" '@ Added 20180716
    Private Const _sscBCODE_processed As String = _sscPrefix & "_sscBCODE_processed" '@ Added 20180716
    Private Const _sscMCODE_processed As String = _sscPrefix & "_sscMCODE_processed" '@ Added 20180716
    Private Const _sscGCODE_processed As String = _sscPrefix & "_sscGCODE_processed" '@ Added 20180716
    Private Const _sscSCODE_processed As String = _sscPrefix & "_sscSCODE_processed" '@ Added 20180716
    Private Const _sscFCODE_processed As String = _sscPrefix & "_sscFCODE_processed" '@ Added 20180716

    Private Const _sscBCOMPSW As String = _sscPrefix & "_sscBCOMPSW"
    Private Const _sscMCOMPSW As String = _sscPrefix & "_sscMCOMPSW"
    Private Const _sscGCOMPSW As String = _sscPrefix & "_sscGCOMPSW"
    Private Const _sscSCOMPSW As String = _sscPrefix & "_sscSCOMPSW"
    Private Const _sscFCOMPSW As String = _sscPrefix & "_sscFCOMPSW"

#End Region

    ' @ ADDED 20170811 FOR POP-UP AIF HEADER
    Shared Property _pLabelFee() As String
        Get
            Return Current.Session(_sscLabelFee)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLabelFee) = value
        End Set
    End Property

#Region "Fee Code" '@ Added 20170713
    Shared Property _pBCODE_Val() As String
        Get
            Return Current.Session(_sscBCODE_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_Val) = value
        End Set
    End Property

    Shared Property _pMCODE_Val() As String
        Get
            Return Current.Session(_sscMCODE_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_Val) = value
        End Set
    End Property

    Shared Property _pGCODE_Val() As String
        Get
            Return Current.Session(_sscGCODE_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_Val) = value
        End Set
    End Property

    Shared Property _pSCODE_Val() As String
        Get
            Return Current.Session(_sscSCODE_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_Val) = value
        End Set
    End Property

    Shared Property _pFCODE_Val() As String
        Get
            Return Current.Session(_sscFCODE_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_Val) = value
        End Set
    End Property
#End Region


#Region "BUSLINE VARIABLE"


    Shared Property _pBUSTAX() As Integer
        Get
            Return Current.Session(_sscBUSTAX)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscBUSTAX) = value
        End Set
    End Property

    Shared Property _pMAYORS() As Integer
        Get
            Return Current.Session(_sscMAYORS)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscMAYORS) = value
        End Set
    End Property

    Shared Property _pGARBAGE() As Integer
        Get
            Return Current.Session(_sscGARBAGE)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscGARBAGE) = value
        End Set
    End Property

    Shared Property _pSANITARY() As Integer
        Get
            Return Current.Session(_sscSANITARY)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscSANITARY) = value
        End Set
    End Property

    Shared Property _pFIRE() As Integer
        Get
            Return Current.Session(_sscFIRE)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscFIRE) = value
        End Set
    End Property

    Shared Property _pGARBAGE_o() As Integer
        Get
            Return Current.Session(_sscGARBAGE_o)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscGARBAGE_o) = value
        End Set
    End Property

    Shared Property _pSANITARY_o() As Integer
        Get
            Return Current.Session(_sscSANITARY_o)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscSANITARY_o) = value
        End Set
    End Property

    Shared Property _pFIRE_o() As Integer
        Get
            Return Current.Session(_sscFIRE_o)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscFIRE_o) = value
        End Set
    End Property

    Shared Property _pNewsw_o() As Integer
        Get
            Return Current.Session(_sscNewsw_o)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscNewsw_o) = value
        End Set
    End Property

#End Region

#Region ""

    Shared Property _pTempYr() As Integer
        Get
            Return Current.Session(_sscTempYr)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscTempYr) = value
        End Set
    End Property

    Shared Property _pTempMo() As Integer
        Get
            Return Current.Session(_sscTempMo)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscTempMo) = value
        End Set
    End Property

    Shared Property _pTAXBASE() As Integer
        Get
            Return Current.Session(_sscTAXBASE)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscTAXBASE) = value
        End Set
    End Property

    Shared Property _pTaxDueMin() As Integer
        Get
            Return Current.Session(_sscTaxDueMin)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscTaxDueMin) = value
        End Set
    End Property

    Shared Property _pTaxDueMax() As Integer
        Get
            Return Current.Session(_sscTaxDueMax)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscTaxDueMax) = value
        End Set
    End Property

    Shared Property _pMTaxCode() As Integer
        Get
            Return Current.Session(_sscMTaxCode)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscMTaxCode) = value
        End Set
    End Property

#End Region

#Region "Properties"

    Shared Property _pAddMode() As Boolean
        Get
            Return Current.Session(_sscAddMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscAddMode) = value
        End Set
    End Property

    Shared Property _pSvrDate() As String
        Get
            Return Current.Session(_sscSvrDate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSvrDate) = value
        End Set
    End Property

    Shared Property _pHeadingMode() As Boolean
        Get
            Return Current.Session(_sscHeadingMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscHeadingMode) = value
        End Set
    End Property

    Shared Property _pOptionMode() As Boolean
        Get
            Return Current.Session(_sscOptionMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscOptionMode) = value
        End Set
    End Property

    Shared Property _pOptionBusDesc() As String
        Get
            Return Current.Session(_sscOptionBusDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOptionBusDesc) = value
        End Set
    End Property

    Shared Property _pOptionTaxCode() As String
        Get
            Return Current.Session(_sscOptionTaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOptionTaxCode) = value
        End Set
    End Property

    Shared Property _pOptionTaxCode2() As String
        Get
            Return Current.Session(_sscOptionTaxCode2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOptionTaxCode2) = value
        End Set
    End Property

    Shared Property _pOptionTaxAmt() As String
        Get
            Return Current.Session(_sscOptionTaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOptionTaxAmt) = value
        End Set
    End Property

    Shared Property _pOptionTaxRate() As String
        Get
            Return Current.Session(_sscOptionTaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOptionTaxRate) = value
        End Set
    End Property

    Shared Property _pTaxField() As String
        Get
            Return Current.Session(_sscTaxField)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTaxField) = value
        End Set
    End Property

    Shared Property _pTblCode() As String
        Get
            Return Current.Session(_sscTblCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTblCode) = value
        End Set
    End Property

    Shared Property _pQtyMode() As Boolean
        Get
            Return Current.Session(_sscQtyMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscQtyMode) = value
        End Set
    End Property

    Shared Property _pTaxCode2Mode() As Boolean
        Get
            Return Current.Session(_sscTaxCode2Mode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscTaxCode2Mode) = value
        End Set
    End Property

    Shared Property _pEff_Month() As String
        Get
            Return Current.Session(_sscEff_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEff_Month) = value
        End Set
    End Property

    Shared Property _pEff_Year() As String
        Get
            Return Current.Session(_sscEff_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEff_Year) = value
        End Set
    End Property

    Shared Property _pELECCODE() As Boolean
        Get
            Return Current.Session(_sscELECCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscELECCODE) = value
        End Set
    End Property

    Shared Property _pMECHCODE() As Boolean
        Get
            Return Current.Session(_sscMECHCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscMECHCODE) = value
        End Set
    End Property

    Shared Property _pBLDGCODE() As Boolean
        Get
            Return Current.Session(_sscBLDGCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscBLDGCODE) = value
        End Set
    End Property

    Shared Property _pSIGNCODE() As Boolean
        Get
            Return Current.Session(_sscSIGNCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscSIGNCODE) = value
        End Set
    End Property

    Shared Property _pEPOCODE() As Boolean
        Get
            Return Current.Session(_sscEPOCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscEPOCODE) = value
        End Set
    End Property

    Shared Property _pEIFCODE() As Boolean
        Get
            Return Current.Session(_sscEIFCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscEIFCODE) = value
        End Set
    End Property

    Shared Property _pPLATECODE() As Boolean
        Get
            Return Current.Session(_sscPLATECODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscPLATECODE) = value
        End Set
    End Property

    Shared Property _pBCODE() As Boolean
        Get
            Return Current.Session(_sscBCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscBCODE) = value
        End Set
    End Property

    Shared Property _pMCODE() As Boolean
        Get
            Return Current.Session(_sscMCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscMCODE) = value
        End Set
    End Property

    Shared Property _pGCODE() As Boolean
        Get
            Return Current.Session(_sscGCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscGCODE) = value
        End Set
    End Property

    Shared Property _pSCODE() As Boolean
        Get
            Return Current.Session(_sscSCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscSCODE) = value
        End Set
    End Property

    Shared Property _pFCODE() As Boolean
        Get
            Return Current.Session(_sscFCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscFCODE) = value
        End Set
    End Property

    Shared Property _pExit_ELECCODE() As Boolean
        Get
            Return Current.Session(_sscExit_ELECCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_ELECCODE) = value
        End Set
    End Property

    Shared Property _pExit_MECHCODE() As Boolean
        Get
            Return Current.Session(_sscExit_MECHCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_MECHCODE) = value
        End Set
    End Property

    Shared Property _pExit_BLDGCODE() As Boolean
        Get
            Return Current.Session(_sscExit_BLDGCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_BLDGCODE) = value
        End Set
    End Property

    Shared Property _pExit_SIGNCODE() As Boolean
        Get
            Return Current.Session(_sscExit_SIGNCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_SIGNCODE) = value
        End Set
    End Property

    Shared Property _pExit_EPOCODE() As Boolean
        Get
            Return Current.Session(_sscExit_EPOCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_EPOCODE) = value
        End Set
    End Property

    Shared Property _pExit_EIFCODE() As Boolean
        Get
            Return Current.Session(_sscExit_EIFCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_EIFCODE) = value
        End Set
    End Property

    Shared Property _pExit_PLATECODE() As Boolean
        Get
            Return Current.Session(_sscExit_PLATECODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_PLATECODE) = value
        End Set
    End Property

    Shared Property _pExit_BCODE() As Boolean
        Get
            Return Current.Session(_sscExit_BCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_BCODE) = value
        End Set
    End Property

    Shared Property _pExit_MCODE() As Boolean
        Get
            Return Current.Session(_sscExit_MCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_MCODE) = value
        End Set
    End Property

    Shared Property _pExit_GCODE() As Boolean
        Get
            Return Current.Session(_sscExit_GCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_GCODE) = value
        End Set
    End Property

    Shared Property _pExit_SCODE() As Boolean
        Get
            Return Current.Session(_sscExit_SCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_SCODE) = value
        End Set
    End Property

    Shared Property _pExit_FCODE() As Boolean
        Get
            Return Current.Session(_sscExit_FCODE)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExit_FCODE) = value
        End Set
    End Property

    Shared Property _pBCOMPSW() As Integer
        Get
            Return Current.Session(_sscBCOMPSW)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscBCOMPSW) = value
        End Set
    End Property

    Shared Property _pMCOMPSW() As Integer
        Get
            Return Current.Session(_sscMCOMPSW)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscMCOMPSW) = value
        End Set
    End Property

    Shared Property _pGCOMPSW() As Integer
        Get
            Return Current.Session(_sscGCOMPSW)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscGCOMPSW) = value
        End Set
    End Property

    Shared Property _pSCOMPSW() As Integer
        Get
            Return Current.Session(_sscSCOMPSW)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscSCOMPSW) = value
        End Set
    End Property

    Shared Property _pFCOMPSW() As Integer
        Get
            Return Current.Session(_sscFCOMPSW)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_sscFCOMPSW) = value
        End Set
    End Property

#End Region

#Region "AIF FEES"

    Shared Property _pStatMain() As String
        Get
            Return Current.Session(_sscStatMain)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscStatMain) = value
        End Set
    End Property


    Shared Property _pTempLogName() As Double
        Get
            Return Current.Session(_sscTempLogName)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscTempLogName) = value
        End Set
    End Property

    Shared Property _pSTATCODE() As String
        Get
            Return Current.Session(_sscSTATCODE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSTATCODE) = value
        End Set
    End Property

    Shared Property _pELECCODE_FEE() As Double
        Get
            Return Current.Session(_sscELECCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscELECCODE_FEE) = value
        End Set
    End Property

    Shared Property _pMECHCODE_FEE() As Double
        Get
            Return Current.Session(_sscMECHCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscMECHCODE_FEE) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_FEE() As Double
        Get
            Return Current.Session(_sscBLDGCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscBLDGCODE_FEE) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_FEE() As Double
        Get
            Return Current.Session(_sscSIGNCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscSIGNCODE_FEE) = value
        End Set
    End Property

    Shared Property _pEPOCODE_FEE() As Double
        Get
            Return Current.Session(_sscEPOCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscEPOCODE_FEE) = value
        End Set
    End Property

    Shared Property _pEIFCODE_FEE() As Double
        Get
            Return Current.Session(_sscEIFCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscEIFCODE_FEE) = value
        End Set
    End Property


    Shared Property _pPLATECODE_FEE() As Double
        Get
            Return Current.Session(_sscPLATECODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscPLATECODE_FEE) = value
        End Set
    End Property

    Shared Property _pBCODE_FEE() As Double
        Get
            Return Current.Session(_sscBCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscBCODE_FEE) = value
        End Set
    End Property

    Shared Property _pMCODE_FEE() As Double
        Get
            Return Current.Session(_sscMCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscMCODE_FEE) = value
        End Set
    End Property

    Shared Property _pGCODE_FEE() As Double
        Get
            Return Current.Session(_sscGCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscGCODE_FEE) = value
        End Set
    End Property

    Shared Property _pFCODE_FEE() As Double
        Get
            Return Current.Session(_sscFCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscFCODE_FEE) = value
        End Set
    End Property

    Shared Property _pSCODE_FEE() As Double
        Get
            Return Current.Session(_sscSCODE_FEE)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscSCODE_FEE) = value
        End Set
    End Property



    Shared Property _pAREA() As Double
        Get
            Return Current.Session(_sscAREA)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscAREA) = value
        End Set
    End Property

    Shared Property _pCAPITAL() As Double
        Get
            Return Current.Session(_sscCAPITAL)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscCAPITAL) = value
        End Set
    End Property


    Shared Property _pGROSS() As Double
        Get
            Return Current.Session(_sscGROSS)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscGROSS) = value
        End Set
    End Property

    Shared Property _pEditMode() As Boolean
        Get
            Return Current.Session(_sscEditMode)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscEditMode) = value
        End Set
    End Property
#End Region

#Region "Fees processed"
    Shared Property _pELECCODE_processed() As Boolean
        Get
            Return Current.Session(_sscELECCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscELECCODE_processed) = value
        End Set
    End Property

    Shared Property _pMECHCODE_processed() As Boolean
        Get
            Return Current.Session(_sscMECHCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscMECHCODE_processed) = value
        End Set
    End Property
    Shared Property _pBLDGCODE_processed() As Boolean
        Get
            Return Current.Session(_sscBLDGCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscBLDGCODE_processed) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_processed() As Boolean
        Get
            Return Current.Session(_sscSIGNCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscSIGNCODE_processed) = value
        End Set
    End Property
    Shared Property _pEPOCODE_processed() As Boolean
        Get
            Return Current.Session(_sscEPOCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscEPOCODE_processed) = value
        End Set
    End Property
    Shared Property _pEIFCODE_processed() As Boolean
        Get
            Return Current.Session(_sscEIFCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscEIFCODE_processed) = value
        End Set
    End Property
    Shared Property _pPLATECODE_processed() As Boolean
        Get
            Return Current.Session(_sscPLATECODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscPLATECODE_processed) = value
        End Set
    End Property
    Shared Property _pBCODE_processed() As Boolean
        Get
            Return Current.Session(_sscBCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscBCODE_processed) = value
        End Set
    End Property

    Shared Property _pMCODE_processed() As Boolean
        Get
            Return Current.Session(_sscMCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscMCODE_processed) = value
        End Set
    End Property

    Shared Property _pGCODE_processed() As Boolean
        Get
            Return Current.Session(_sscGCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscGCODE_processed) = value
        End Set
    End Property

    Shared Property _pSCODE_processed() As Boolean
        Get
            Return Current.Session(_sscSCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscSCODE_processed) = value
        End Set
    End Property

    Shared Property _pFCODE_processed() As Boolean
        Get
            Return Current.Session(_sscFCODE_processed)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscFCODE_processed) = value
        End Set
    End Property

#End Region

#Region "Option trigger"

    Shared Property _pBCHOICE_trg() As Boolean
        Get
            Return Current.Session(_sscBCHOICE_trg)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscBCHOICE_trg) = value
        End Set
    End Property

    Shared Property _pMCHOICE_trg() As Boolean
        Get
            Return Current.Session(_sscMCHOICE_trg)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscMCHOICE_trg) = value
        End Set
    End Property

    Shared Property _pGCHOICE_trg() As Boolean
        Get
            Return Current.Session(_sscGCHOICE_trg)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscGCHOICE_trg) = value
        End Set
    End Property

    Shared Property _pSCHOICE_trg() As Boolean
        Get
            Return Current.Session(_sscSCHOICE_trg)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscSCHOICE_trg) = value
        End Set
    End Property

    Shared Property _pFCHOICE_trg() As Boolean
        Get
            Return Current.Session(_sscFCHOICE_trg)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscFCHOICE_trg) = value
        End Set
    End Property

#End Region

#Region "CHOICE"

    Shared Property _pBCHOICE() As String
        Get
            Return Current.Session(_sscBCHOICE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCHOICE) = value
        End Set
    End Property

    Shared Property _pMCHOICE() As String
        Get
            Return Current.Session(_sscMCHOICE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCHOICE) = value
        End Set
    End Property

    Shared Property _pGCHOICE() As String
        Get
            Return Current.Session(_sscGCHOICE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCHOICE) = value
        End Set
    End Property

    Shared Property _pSCHOICE() As String
        Get
            Return Current.Session(_sscSCHOICE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCHOICE) = value
        End Set
    End Property

    Shared Property _pFCHOICE() As String
        Get
            Return Current.Session(_sscFCHOICE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCHOICE) = value
        End Set
    End Property

#End Region

#Region "AIF"

    Shared Property _pELECCODE_GRADTABL_RTaxAmt() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_RTaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_RTaxAmt) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_RTaxAmt() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_RTaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_RTaxAmt) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_RTaxAmt() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_RTaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_RTaxAmt) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_RTaxAmt() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_RTaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_RTaxAmt) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_RTaxAmt() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_RTaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_RTaxAmt) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_RTaxAmt() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_RTaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_RTaxAmt) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_RTaxAmt() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_RTaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_RTaxAmt) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_RTaxRate() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_RTaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_RTaxRate) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_RTaxRate() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_RTaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_RTaxRate) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_RTaxRate() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_RTaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_RTaxRate) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_RTaxRate() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_RTaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_RTaxRate) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_RTaxRate() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_RTaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_RTaxRate) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_RTaxRate() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_RTaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_RTaxRate) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_RTaxRate() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_RTaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_RTaxRate) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_TaxCode) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_TaxCode) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_EffYear) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_EffYear) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_EffMonth) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_EffMonth) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_TaxAmt() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_TaxAmt() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_TaxAmt() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_TaxAmt() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_TaxAmt() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_TaxAmt() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_TaxAmt() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_TaxRate() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_TaxRate) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_TaxRate() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_TaxRate) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_TaxRate() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_TaxRate() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_TaxRate() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_TaxRate() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_TaxRate() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_TaxMin() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_TaxMin) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_TaxMin() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_TaxMin) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_TaxMin() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_TaxMin() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_TaxMin() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_TaxMin() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_TaxMin() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_TaxMax() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_TaxMax) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_TaxMax() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_TaxMax) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_TaxMax() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_TaxMax() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_TaxMax() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_TaxMax() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_TaxMax() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRADTABL_FinalTax() As String
        Get
            Return Current.Session(_sscELECCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRADTABL_FinalTax) = value
        End Set
    End Property
    Shared Property _pMECHCODE_GRADTABL_FinalTax() As String
        Get
            Return Current.Session(_sscMECHCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRADTABL_FinalTax) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRADTABL_FinalTax() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRADTABL_FinalTax() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRADTABL_FinalTax() As String
        Get
            Return Current.Session(_sscEPOCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRADTABL_FinalTax() As String
        Get
            Return Current.Session(_sscEIFCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRADTABL_FinalTax() As String
        Get
            Return Current.Session(_sscPLATECODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRADTABL_FinalTax) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRADTABL"
    Shared Property _pBCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscBCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pMCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscMCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pGCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscGCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pSCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscSCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pFCODE_GRADTABL_TaxCode() As String
        Get
            Return Current.Session(_sscFCODE_GRADTABL_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRADTABL_TaxCode) = value
        End Set
    End Property

    Shared Property _pBCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscBCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pMCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscMCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pGCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscGCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pSCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscSCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pFCODE_GRADTABL_EffMonth() As String
        Get
            Return Current.Session(_sscFCODE_GRADTABL_EffMonth)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRADTABL_EffMonth) = value
        End Set
    End Property

    Shared Property _pBCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscBCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pMCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscMCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pGCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscGCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pSCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscSCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pFCODE_GRADTABL_EffYear() As String
        Get
            Return Current.Session(_sscFCODE_GRADTABL_EffYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRADTABL_EffYear) = value
        End Set
    End Property

    Shared Property _pBCODE_GRADTABL_TaxAmt() As Double ' @ Added   20170713
        Get
            Return Current.Session(_sscBCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscBCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pMCODE_GRADTABL_TaxAmt() As Double ' @ Added   20170713
        Get
            Return Current.Session(_sscMCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscMCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pGCODE_GRADTABL_TaxAmt() As Double ' @ Added   20170713
        Get
            Return Current.Session(_sscGCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscGCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pSCODE_GRADTABL_TaxAmt() As Double ' @ Added   20170713
        Get
            Return Current.Session(_sscSCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscSCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pFCODE_GRADTABL_TaxAmt() As Double ' @ Added   20170713
        Get
            Return Current.Session(_sscFCODE_GRADTABL_TaxAmt)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscFCODE_GRADTABL_TaxAmt) = value
        End Set
    End Property

    Shared Property _pBCODE_GRADTABL_TaxRate() As Double ' @ Added   20170714
        Get
            Return Current.Session(_sscBCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscBCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pMCODE_GRADTABL_TaxRate() As Double ' @ Added   20170714
        Get
            Return Current.Session(_sscMCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscMCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pGCODE_GRADTABL_TaxRate() As Double ' @ Added   20170714
        Get
            Return Current.Session(_sscGCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscGCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pSCODE_GRADTABL_TaxRate() As Double ' @ Added   20170714
        Get
            Return Current.Session(_sscSCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscSCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pFCODE_GRADTABL_TaxRate() As Double ' @ Added   20170714
        Get
            Return Current.Session(_sscFCODE_GRADTABL_TaxRate)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscFCODE_GRADTABL_TaxRate) = value
        End Set
    End Property

    Shared Property _pBCODE_GRADTABL_TaxMin() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscBCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscBCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pMCODE_GRADTABL_TaxMin() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscMCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscMCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pGCODE_GRADTABL_TaxMin() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscGCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscGCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pSCODE_GRADTABL_TaxMin() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscSCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscSCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pFCODE_GRADTABL_TaxMin() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscFCODE_GRADTABL_TaxMin)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscFCODE_GRADTABL_TaxMin) = value
        End Set
    End Property

    Shared Property _pBCODE_GRADTABL_TaxMax() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscBCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscBCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pMCODE_GRADTABL_TaxMax() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscMCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscMCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pGCODE_GRADTABL_TaxMax() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscGCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscGCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pSCODE_GRADTABL_TaxMax() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscSCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscSCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pFCODE_GRADTABL_TaxMax() As Double ' @ Added   20170717
        Get
            Return Current.Session(_sscFCODE_GRADTABL_TaxMax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscFCODE_GRADTABL_TaxMax) = value
        End Set
    End Property

    Shared Property _pBCODE_GRADTABL_FinalTax() As Double ' @ Added   20170718
        Get
            Return Current.Session(_sscBCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscBCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

    Shared Property _pMCODE_GRADTABL_FinalTax() As Double ' @ Added   20170718
        Get
            Return Current.Session(_sscMCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscMCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

    Shared Property _pGCODE_GRADTABL_FinalTax() As Double ' @ Added   20170718
        Get
            Return Current.Session(_sscGCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscGCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

    Shared Property _pSCODE_GRADTABL_FinalTax() As Double ' @ Added   20170718
        Get
            Return Current.Session(_sscSCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscSCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

    Shared Property _pFCODE_GRADTABL_FinalTax() As Double ' @ Added   20170718
        Get
            Return Current.Session(_sscFCODE_GRADTABL_FinalTax)
        End Get
        Set(ByVal value As Double)
            Current.Session(_sscFCODE_GRADTABL_FinalTax) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRASKHDG AIF"
    Shared Property _pELECCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKHDG_Val) = value
        End Set
    End Property


    Shared Property _pELECCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKHDG_Val) = value
        End Set
    End Property


    Shared Property _pMECHCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKHDG_Val) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKHDG_Val) = value
        End Set
    End Property


    Shared Property _pSIGNCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKHDG_Val) = value
        End Set
    End Property


    Shared Property _pEPOCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKHDG_Val) = value
        End Set
    End Property


    Shared Property _pEIFCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKHDG_Val) = value
        End Set
    End Property


    Shared Property _pPLATECODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKHDG_Month) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRASKHDG"
    Shared Property _pBCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscBCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKHDG_Val) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscMCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKHDG_Val) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscGCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKHDG_Val) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscSCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKHDG_Val) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKHDG_Val() As String
        Get
            Return Current.Session(_sscFCODE_GRASKHDG_Val)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKHDG_Val) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscBCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscMCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscGCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscSCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKHDG_Year() As String
        Get
            Return Current.Session(_sscFCODE_GRASKHDG_Year)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKHDG_Year) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscBCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscMCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscGCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscSCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKHDG_Month) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKHDG_Month() As String
        Get
            Return Current.Session(_sscFCODE_GRASKHDG_Month)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKHDG_Month) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GROPTION TAXCODE"

    Shared Property _pBCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscBCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_Option_TaxCode) = value
        End Set
    End Property

    Shared Property _pMCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscMCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_Option_TaxCode) = value
        End Set
    End Property

    Shared Property _pGCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscGCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_Option_TaxCode) = value
        End Set
    End Property

    Shared Property _pSCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscSCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_Option_TaxCode) = value
        End Set
    End Property

    Shared Property _pFCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscFCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_Option_TaxCode) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GROPTION TAXDESC"

    Shared Property _pBCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscBCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_Option_TaxDesc) = value
        End Set
    End Property

    Shared Property _pMCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscMCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_Option_TaxDesc) = value
        End Set
    End Property

    Shared Property _pGCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscGCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_Option_TaxDesc) = value
        End Set
    End Property

    Shared Property _pSCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscSCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_Option_TaxDesc) = value
        End Set
    End Property

    Shared Property _pFCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscFCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_Option_TaxDesc) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GROPTION TAXYEAR"

    Shared Property _pBCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscBCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_Option_TaxYear) = value
        End Set
    End Property

    Shared Property _pMCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscMCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_Option_TaxYear) = value
        End Set
    End Property

    Shared Property _pGCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscGCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_Option_TaxYear) = value
        End Set
    End Property

    Shared Property _pSCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscSCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_Option_TaxYear) = value
        End Set
    End Property

    Shared Property _pFCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscFCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_Option_TaxYear) = value
        End Set
    End Property

#End Region

#Region ""

    Shared Property _pELECCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscELECCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_Option_RowNo) = value
        End Set
    End Property
    Shared Property _pMECHCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscMECHCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_Option_RowNo) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscBLDGCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_Option_RowNo) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscSIGNCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_Option_RowNo) = value
        End Set
    End Property

    Shared Property _pEPOCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscEPOCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_Option_RowNo) = value
        End Set
    End Property

    Shared Property _pEIFCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscEIFCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_Option_RowNo) = value
        End Set
    End Property

    Shared Property _pPLATECODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscPLATECODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_Option_RowNo) = value
        End Set
    End Property

    '------------------------------------------------------------------------------

    Shared Property _pELECCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscELECCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_Option_TaxYear) = value
        End Set
    End Property
    Shared Property _pMECHCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscMECHCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_Option_TaxYear) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscBLDGCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_Option_TaxYear) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscSIGNCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_Option_TaxYear) = value
        End Set
    End Property

    Shared Property _pEPOCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscEPOCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_Option_TaxYear) = value
        End Set
    End Property

    Shared Property _pEIFCODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscEIFCODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_Option_TaxYear) = value
        End Set
    End Property

    Shared Property _pPLATECODE_Option_TaxYear() As String
        Get
            Return Current.Session(_sscPLATECODE_Option_TaxYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_Option_TaxYear) = value
        End Set
    End Property


    Shared Property _pELECCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscELECCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_Option_TaxDesc) = value
        End Set
    End Property
    Shared Property _pMECHCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscMECHCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_Option_TaxDesc) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscBLDGCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_Option_TaxDesc) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscSIGNCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_Option_TaxDesc) = value
        End Set
    End Property

    Shared Property _pEPOCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscEPOCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_Option_TaxDesc) = value
        End Set
    End Property

    Shared Property _pEIFCODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscEIFCODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_Option_TaxDesc) = value
        End Set
    End Property

    Shared Property _pPLATECODE_Option_TaxDesc() As String
        Get
            Return Current.Session(_sscPLATECODE_Option_TaxDesc)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_Option_TaxDesc) = value
        End Set
    End Property


    Shared Property _pELECCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscELECCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_Option_TaxCode) = value
        End Set
    End Property
    Shared Property _pMECHCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscMECHCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_Option_TaxCode) = value
        End Set
    End Property


    Shared Property _pBLDGCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscBLDGCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_Option_TaxCode) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscSIGNCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_Option_TaxCode) = value
        End Set
    End Property

    Shared Property _pEPOCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscEPOCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_Option_TaxCode) = value
        End Set
    End Property

    Shared Property _pEIFCODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscEIFCODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_Option_TaxCode) = value
        End Set
    End Property

    Shared Property _pPLATECODE_Option_TaxCode() As String
        Get
            Return Current.Session(_sscPLATECODE_Option_TaxCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_Option_TaxCode) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GROPTION RowNo"

    Shared Property _pBCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscBCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_Option_RowNo) = value
        End Set
    End Property

    Shared Property _pMCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscMCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_Option_RowNo) = value
        End Set
    End Property

    Shared Property _pGCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscGCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_Option_RowNo) = value
        End Set
    End Property

    Shared Property _pSCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscSCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_Option_RowNo) = value
        End Set
    End Property

    Shared Property _pFCODE_Option_RowNo() As String
        Get
            Return Current.Session(_sscFCODE_Option_RowNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_Option_RowNo) = value
        End Set
    End Property

#End Region

#Region "AIF GRASKQTY Amt"


    Shared Property _pFEE_GRASKQTY_TaxAmt1() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt1) = value
        End Set
    End Property


    Shared Property _pFEE_GRASKQTY_TaxAmt2() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt2) = value
        End Set
    End Property


    Shared Property _pFEE_GRASKQTY_TaxAmt3() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt3) = value
        End Set
    End Property


    Shared Property _pFEE_GRASKQTY_TaxAmt4() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt4) = value
        End Set
    End Property


    Shared Property _pFEE_GRASKQTY_TaxAmt5() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt5) = value
        End Set
    End Property



    Shared Property _pFEE_GRASKQTY_TaxAmt6() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt6) = value
        End Set
    End Property


    Shared Property _pFEE_GRASKQTY_TaxAmt7() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt7) = value
        End Set
    End Property

    Shared Property _pFEE_GRASKQTY_TaxAmt8() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt8) = value
        End Set
    End Property

    Shared Property _pFEE_GRASKQTY_TaxAmt9() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt9) = value
        End Set
    End Property


    Shared Property _pFEE_GRASKQTY_TaxAmt10() As String
        Get
            Return Current.Session(_sscFEE_GRASKQTY_TaxAmt10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFEE_GRASKQTY_TaxAmt10) = value
        End Set
    End Property


#End Region

#Region "Temp Variable GRASKQTY ELECCODE"
    Shared Property _pELECCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pELECCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscELECCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscELECCODE_GRASKQTY_Val10) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRASKQTY MECHCODE"
    Shared Property _pMECHCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pMECHCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscMECHCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMECHCODE_GRASKQTY_Val10) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRASKQTY BLDGCODE"
    Shared Property _pBLDGCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pBLDGCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscBLDGCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBLDGCODE_GRASKQTY_Val10) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRASKQTY SIGNCODE"
    Shared Property _pSIGNCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pSIGNCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscSIGNCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSIGNCODE_GRASKQTY_Val10) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRASKQTY EPOCODE"
    Shared Property _pEPOCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pEPOCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscEPOCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEPOCODE_GRASKQTY_Val10) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRASKQTY EIFCODE"
    Shared Property _pEIFCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pEIFCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscEIFCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEIFCODE_GRASKQTY_Val10) = value
        End Set
    End Property

#Region "Temp Variable GRASKQTY PLATECODE"
    Shared Property _pPLATECODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pPLATECODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscPLATECODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscPLATECODE_GRASKQTY_Val10) = value
        End Set
    End Property

#End Region

#End Region



#Region "Temp Variable GRASKQTY BCODE"
    Shared Property _pBCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pBCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscBCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBCODE_GRASKQTY_Val10) = value
        End Set
    End Property

#End Region

#Region "Exit Trigger"
    Shared Property _pExitProcedure() As Boolean
        Get
            Return Current.Session(_sscExitProcedure)
        End Get
        Set(ByVal value As Boolean)
            Current.Session(_sscExitProcedure) = value
        End Set
    End Property
#End Region

#Region "Temp Variable GRASKQTY MCODE"

    Shared Property _pMCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pMCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscMCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMCODE_GRASKQTY_Val10) = value
        End Set
    End Property

#End Region

#Region "Temp Variable GRASKQTY GCODE"

    Shared Property _pGCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pGCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscGCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGCODE_GRASKQTY_Val10) = value
        End Set
    End Property
#End Region

#Region "Temp Variable GRASKQTY SCODE"

    Shared Property _pSCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pSCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscSCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSCODE_GRASKQTY_Val10) = value
        End Set
    End Property
#End Region

#Region "Temp Variable GRASKQTY FCODE"

    Shared Property _pFCODE_GRASKQTY_Val1() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val1)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val1) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val2() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val2)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val2) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val3() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val3)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val3) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val4() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val4)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val4) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val5() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val5)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val5) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val6() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val6)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val6) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val7() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val7)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val7) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val8() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val8)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val8) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val9() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val9)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val9) = value
        End Set
    End Property

    Shared Property _pFCODE_GRASKQTY_Val10() As String
        Get
            Return Current.Session(_sscFCODE_GRASKQTY_Val10)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFCODE_GRASKQTY_Val10) = value
        End Set
    End Property
#End Region

#Region "Row Count" '@ Added 20170908

    Shared Property _pRowCountBusline() As Integer
        Get
            Return Current.Session(_ssc_RowCountBusline)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_ssc_RowCountBusline) = value
        End Set
    End Property

    Shared Property _pRowCountBuslineList() As Integer
        Get
            Return Current.Session(_ssc_RowCountBuslineList)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_ssc_RowCountBuslineList) = value
        End Set
    End Property

    Shared Property _pRowCountBuslineOption() As Integer
        Get
            Return Current.Session(_ssc_RowCountBuslineOption)
        End Get
        Set(ByVal value As Integer)
            Current.Session(_ssc_RowCountBuslineOption) = value
        End Set
    End Property
#End Region

#Region "Properties Field Original"

    Shared Property _pId() As String
        Get
            Return Current.Session(_sscOrigSample)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOrigSample) = value
        End Set
    End Property

    Shared Property _pDistCode() As String
        Get
            Return Current.Session(_sscDistCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscDistCode) = value
        End Set
    End Property

    Shared Property _pBrgyCode() As String
        Get
            Return Current.Session(_sscBrgyCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBrgyCode) = value
        End Set
    End Property

    Shared Property _pAccountNo() As String
        Get
            Return Current.Session(_sscAccountNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscAccountNo) = value
        End Set
    End Property

    Shared Property _pxAccountNo() As String
        Get
            Return Current.Session(_sscxAccountNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscxAccountNo) = value
        End Set
    End Property

    Shared Property _pxForYear() As String
        Get
            Return Current.Session(_sscxForYear)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscxForYear) = value
        End Set
    End Property

    Shared Property _pxBusCode() As String
        Get
            Return Current.Session(_sscxBusCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscxBusCode) = value
        End Set
    End Property

    Shared Property _pBUSCODE() As String
        Get
            Return Current.Session(_sscxBusCode)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscxBusCode) = value
        End Set
    End Property
#End Region

#Region "Routines"
    Public Shared Sub _pSubSessionClear()
        Try
            '----------------------------------

            _pAddMode = False
            _pEditMode = False

            _pId = Nothing

            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

#End Region



End Class
