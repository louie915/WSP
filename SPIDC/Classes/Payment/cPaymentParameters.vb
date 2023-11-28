Public Class cPaymentParameters

    Public Shared _ptrxnamt As String
    Public Shared _pmerchantcodex As String
    Public Shared _pbankcode As String = "B000"
    Public Shared _ptrxndetails As String
    Public Shared _ptrandetail1 As String
    Public Shared _ptrandetail2 As String
    Public Shared _ptrandetail3 As String
    Public Shared _ptrandetail4 As String
    Public Shared _ptrandetail5 As String
    Public Shared _ptrandetail6 As String = Nothing
    Public Shared _ptrandetail7 As String = Nothing
    Public Shared _ptrandetail8 As String = Nothing
    Public Shared _ptrandetail9 As String = Nothing
    Public Shared _ptrandetail10 As String = Nothing
    Public Shared _ptrandetail11 As String = 0
    Public Shared _ptrandetail12 As String = 0
    Public Shared _ptrandetail13 As String = 0
    Public Shared _ptrandetail14 As String = 0
    Public Shared _ptrandetail15 As String = 0
    Public Shared _ptrandetail16 As String = 0
    Public Shared _ptrandetail17 As String = 0
    Public Shared _ptrandetail18 As String = 0
    Public Shared _ptrandetail19 As String = 0
    Public Shared _ptrandetail20 As String = Nothing
    Public Shared _pcallbackURL As String
    Public Shared _pchecksum As String = Nothing
    Public Shared _pusername As String
    Public Shared _ppassword As String
    Public Shared _pSecretKey As String
    Public Shared _pLBPDomain As String

 
    Public Shared Sub LBP(trxnamt As String _
       , merchantcodex As String _
       , trxndetails As String _
       , trandetail1 As String _
       , trandetail2 As String _
       , trandetail3 As String _
       , trandetail4 As String _
       , trandetail5 As String _
       , trandetail6 As String _
       , trandetail7 As String _
       , trandetail8 As String _
       , trandetail9 As String _
       , trandetail10 As String _
       , trandetail11 As String _
       , trandetail12 As String _
       , trandetail13 As String _
       , trandetail14 As String _
       , trandetail15 As String _
       , trandetail16 As String _
       , trandetail17 As String _
       , trandetail18 As String _
       , trandetail19 As String _
       , trandetail20 As String )

        _ptrxnamt = trxnamt
        _pmerchantcodex = merchantcodex
        _ptrxndetails = trxndetails
        _ptrandetail1 = trandetail1
        _ptrandetail2 = trandetail2
        _ptrandetail3 = trandetail3
        _ptrandetail4 = trandetail4
        _ptrandetail5 = trandetail5
        _ptrandetail6 = trandetail6
        _ptrandetail7 = trandetail7
        _ptrandetail8 = trandetail8
        _ptrandetail9 = trandetail9
        _ptrandetail10 = trandetail10
        _ptrandetail11 = trandetail11
        _ptrandetail12 = trandetail12
        _ptrandetail13 = trandetail13
        _ptrandetail14 = trandetail14
        _ptrandetail15 = trandetail15
        _ptrandetail16 = trandetail16
        _ptrandetail17 = trandetail17
        _ptrandetail18 = trandetail18
        _ptrandetail19 = trandetail19
        _ptrandetail20 = trandetail20

    End Sub
    Public Shared Function _LBP_Cheksum() As String

        Return _ptrxnamt & _
        _pmerchantcodex & _
        _ptrxndetails & _
        _ptrandetail1 & _
        _ptrandetail2 & _
        _ptrandetail3 & _
        _ptrandetail4 & _
        _ptrandetail5 & _
        _ptrandetail6 & _
        _ptrandetail7 & _
        _ptrandetail8 & _
        _ptrandetail9 & _
        _ptrandetail10 & _
        _ptrandetail11 & _
        _ptrandetail12 & _
        _ptrandetail13 & _
        _ptrandetail14 & _
        _ptrandetail15 & _
        _ptrandetail16 & _
        _ptrandetail17 & _
        _ptrandetail18 & _
        _ptrandetail19 & _
        _ptrandetail20 

    End Function


    Public Shared Function _ParamDisplay(_nParamStr As String) As String

        '# Function:  Replace display to parameter description instead of parameter Key

        Select Case _nParamStr
            Case "PaymentRefNo"
                Return "Payment Reference No. "
            Case "BillingValidityDate"
                Return "Billing Validity Date "
            Case "Status"
                Return "Status "
            Case "PaymentOption"
                Return "Payment Option "
            Case "ConvinienceFee"
                Return "Convenience Fee "
            Case "BillingAmt"
                Return "Billing Amount "
            Case "TotalAmount"
                Return "Total Amount "
            Case "OriginUrl"
                Return "Origin URL "
            Case "Note"
                Return "Note "
            Case Else
                Return _nParamStr
        End Select


    End Function

End Class
