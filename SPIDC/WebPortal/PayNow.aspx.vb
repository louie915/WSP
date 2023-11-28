Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.IO
Imports RestSharp
Imports System.Web.Script.Serialization

Public Class PayNow
    Inherits System.Web.UI.Page
    Dim action As String
    Dim val As String
    Public transactionKey As String
    Public terminalID As String
    Public referenceCode As String
    Public serviceType As String
    Public securityToken As String
    Dim acctno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                    Exit Sub
                End If

                get_PaymentGateways()

                Dim _nClass2 As New cHardwareInformation
                Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
                ' If _nMachineName = "MANDAUEWEBSVR" Then
                '     divPayImg.Style.Add("display", "block")
                ' End If

                If _nMachineName = "MANOLOWEBSVR" Then
                    lbl_OTC.InnerHtml = "&nbsp OVER-THE-COUNTER (MUNICIPAL HALL)"
                End If



                serviceType = cSessionLoader._pService
                _oTxtTransacType.Value = cSessionLoader._pType
                txtInitial.InnerText = cSessionLoader._pType

                If Request.Form("Service") = "Miscellaneous" Then
                    serviceType = "Misc"
                    _oTxtTransacType.Value = Request.Form("PackageList")
                    _oTxtAmount.Value = Request.Form("totalAmount")
                    _oTxtAccNo.Value = GetHashMD5(Request.Form("datetime") & Request.Form("PackageList") & Request.Form("totalAmount") & Request.Form("Quantity")).Substring(0, 8)

                    cSessionLoader._pTotalAmountDue = Request.Form("totalAmount")
                    cSessionLoader._pService = "Miscellaneous"
                    Exit Sub
                End If

                If serviceType = "RPT" Then
                    _oTxtAccNo.Value = cSessionLoader._pAssessNo
                    BIN_ASSSESSNO.InnerText = "Assessment Number"

                ElseIf serviceType = "CertRPT" Then 'Certificate of No Real Property rhogiel05212020
                    _oTxtAccNo.Value = cDalCertificationAss._pUnique

                ElseIf serviceType = "CertRPT" Then
                    _oTxtAccNo.Value = cSessionLoader._pTDN

                ElseIf serviceType = "1CertRPT" Then
                    _oTxtAccNo.Value = cSessionLoader._pTDN

                ElseIf serviceType = "BP" Or serviceType = "1CertBP" Then 'BP Certificate with account attached

                    If cSessionLoader._pStatus = "NEW" Then
                        'cSessionLoader._pTotalAmountDue = ClassPageSession_pBilling._pTotalAmountDue
                        _oTxtAccNo.Value = cSessionLoader._pAccountNo
                    Else
                        _oTxtAccNo.Value = cSessionLoader._pAccountNo
                    End If


                ElseIf serviceType = "CertBP" Then 'Certificate of No Business rhogiel05212020
                    _oTxtAccNo.Value = cDalCertificationAss._pUnique
                Else
                    _oTxtAccNo.Value = cSessionLoader._pAccountNo
                End If

                _oTxtAmount.Value = cSessionLoader._pTotalAmountDue
            Else
                'action = Request("__EVENTARGUMENT")
                'val = Request("__EVENTTARGET")

                'If action = "PayNow" Then
                '    subPayNow(val, cSessionLoader._pService)
                'End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Sub subPayNow(SelectedBank, SelectedService)
        Dim _nClass As New cDalPayment
        Dim _nClass2 As New cHardwareInformation
        Dim _nMachineName As String = Nothing
        _nMachineName = _nClass2._pMachineName.ToUpper


        Dim _nClass3 As New cDalTransactionHistory
        Dim qs As String
        Dim Particulars As String
        Dim FullUrl As String = HttpContext.Current.Request.Url.AbsoluteUri
        Dim PagePath As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim PageName As String = System.IO.Path.GetFileName(Request.Url.AbsolutePath)
        Dim returnUrl As String = FullUrl.Replace(PageName, "PaymentPostback.aspx")
        Dim acctDesc As String
        Dim transType As String
        Dim transDesc As String

        Select Case SelectedService
            Case "BP"
                acctno = cSessionLoader._pAccountNo
                acctDesc = "Account Number"
                transType = "Business Permit"
                transDesc = "Business Permit Payment"

            Case "1CertBP"
                acctno = cSessionLoader._pAccountNo
                acctDesc = "Account Number"
                transType = "Business Certification"
                transDesc = "Business Certification Payment"

            Case "RPT"
                acctno = cSessionLoader._pAssessNo
                acctDesc = "Assessment Number"
                transType = "Real Property"
                transDesc = "Real Property Payment"

            Case "1CertRPT"
                acctno = cSessionLoader._pTDN
                acctDesc = "Assessment Number"
                transType = "Real Property Certification"
                transDesc = "Real Property Certification Payment"

            Case "CTC"
                acctno = cLoader_CTCApp._pControlNo

                acctDesc = "Control Number"
                transType = "Cedula"
                transDesc = "Cedula Payment"

            Case "Miscellaneous"
                SelectedService = "Misc"
                acctno = _oTxtAccNo.Value
            Case Else
                acctno = cDalCertificationAss._pUnique

        End Select
        cSessionLoader._pPSTransDesc = acctDesc
        cSessionLoader._pPSTransID = acctno
        cSessionLoader._pPSTransType = transDesc
        cSessionLoader._pPSTransAmount = cSessionLoader._pTotalAmountDue
        cSessionLoader._pPSTransOTCNote = ""

    


        Select Case SelectedBank
            Case "PayMaya", "PayMaya2"
                do_PAYMAYA(SelectedService, transDesc, SelectedBank)
                Exit Sub

            Case "GCash"
                If _cbredirect.Checked = True Then
                    GCash.RedirectURLCounter = False
                Else
                    GCash.RedirectURLCounter = True
                End If

                GCash.PayorEmail = cSessionUser._pUserID
                GCash.Amount = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "")
                GCash.TransType = SelectedService
                GCash.SPIDCRefNo = referenceCode
                GCash.PaymentDesc = transDesc
                GCash.ACCTNO = acctno

                'GCash.API_Type = "Create Checkout Payment - POST"
                Dim _TXNREFNO As String = referenceCode
                Dim _EMAILADDR As String = cSessionUser._pUserID
                Dim _PAYMENTCHANNEL As String = "GCash"
                Dim _ACCTNO As String = acctno
                Dim _strDATE As String = "PENDING"
                Dim _STATUSID As String = "PENDING"
                Dim _STATUS As String = "Pending"
                Dim _GATEWAYREFNO As String = Nothing
                Dim _SECURITY As String = Nothing
                Dim _TYPE As String = SelectedService
                Dim _TRANSDATE As String = Nothing
                Dim _TRXDATE As String = Nothing
                Dim _RAWAMOUNT As String = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "")
                Dim _TOTAMOUNT As String = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "")
                Dim _FEEAMOUNT As String = "0.00"
                Dim _DATEVERIFIED As String = Nothing
                Dim _VERIFIEDBY As String = Nothing
                Dim _VERIFYING As String = Nothing
                Dim _VIA As String = "GCash"
                Dim _POSTEDDATE As String = Nothing
                Dim _POSTSTATUS As String = Nothing

                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubInsertPaymentPaymaya(_TXNREFNO, _EMAILADDR, _PAYMENTCHANNEL, _ACCTNO, _strDATE, _STATUSID, _STATUS, _GATEWAYREFNO, _SECURITY, _TYPE, _TRANSDATE, _TRXDATE, _RAWAMOUNT, _TOTAMOUNT, _FEEAMOUNT, _DATEVERIFIED, _VERIFIEDBY, _VERIFYING, _VIA, _POSTEDDATE, _POSTSTATUS)
                Response.Redirect("GCash.aspx")

            Case "DBP"
                If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("ILOILO") = True Then
                    transactionKey = "{8ffbfc064944871267e3ec26dc3a83292c11928e}"
                    terminalID = "122"
                Else
                    transactionKey = "{b845acffc21949ba98f23a19d90a8cc53a5e5c0e}"
                    terminalID = "92"
                End If

                cSessionLoader._pPSTransRefNo = referenceCode
                securityToken = getSHA1Hash(terminalID & referenceCode & transactionKey)

                Dim LGU As String
                Dim strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery
                Dim strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/")
                If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("ILOILO") = True Then
                    'LGU = "ILOILO"
                    ' returnUrl = strUrl & LGU & "/PaymentConfirmation.aspx"
                    returnUrl = strUrl & "/PaymentConfirmation.aspx"
                End If

                cDalPayment.DBP_terminalID = terminalID
                cDalPayment.DBP_referenceCode = referenceCode
                cDalPayment.DBP_amount = Replace(cSessionLoader._pTotalAmountDue, ",", "")
                cDalPayment.DBP_securityToken = securityToken
                cDalPayment.DBP_returnURL = returnUrl
                cDalPayment.DBP_serviceType = cSessionLoader._pType

                _nclass._pSubInsertPaymentRefNo(referenceCode, cSessionUser._pUserID, SelectedBank, acctno, SelectedService)

            Case "LBP"
                '  If _nMachineName <> "WEBSVRCALOOCAN" Then
                do_LBP(SelectedService, transType, transDesc, acctno, _nMachineName)
                Exit Sub
                '  End If

                Dim MerchantCode As String
                Dim MD5Hash As String = Nothing

                Dim x As String = cSessionLoader._pTotalAmountDue.Replace(",", "")
                x = FormatNumber(x, 2)
                x = x.Replace(",", "")
                Dim Amount As String = x.Replace(".", "")
                _nMachineName = _nClass2._pMachineName.ToUpper
                cSessionLoader._pPSTransRefNo = referenceCode
                Dim retURLok As String
                Dim retURLerr As String


                Select Case _nMachineName
                    Case "WEBSVRCALOOCAN"
                        If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("TEST") = True Then
                            MerchantCode = 2020060003 ' CALOOCAN TEST CODE
                            retURLok = "https://online.caloocancity.gov.ph/Test/PaymentConfirmation.aspx"
                            retURLerr = "https://online.caloocancity.gov.ph/Test/PaymentConfirmation.aspx"
                        Else
                            MerchantCode = 2020100016 ' CALOOCAN LIVE CODE
                            retURLok = "https://online.caloocancity.gov.ph/PaymentConfirmation.aspx"
                            retURLerr = "https://online.caloocancity.gov.ph/PaymentConfirmation.aspx"
                        End If

                        If SelectedService = "RPT" Then
                            cDalPayment.LBP_TransType = "Real Property"
                            Particulars = "transaction_type=Real Property Tax;" & _
                                          "Description=" & transDesc & ";" & _
                                          "Tax Declaration Number=" & acctno & ";" & _
                                          "Online ID=" & referenceCode & ";" & _
                                          "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                                          "Email Address=" + cSessionUser._pUserID + ";"
                        ElseIf SelectedService = "BP" Then
                            cDalPayment.LBP_TransType = "Business Permit"
                            Particulars = "transaction_type=Business Permit;" & _
                                          "Description=" & transDesc & ";" & _
                                          "Business Identification Number=" & acctno & ";" & _
                                          "Online ID=" + referenceCode + ";" & _
                                          "Payor Name=" + cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                                          "Email Address=" + cSessionUser._pUserID + ";"

                        ElseIf SelectedService = "CTC" Then
                            cDalPayment.LBP_TransType = "Cedula"
                            Particulars = "" & _
                             "transaction_type=Real Property Tax;" & _
                             "Description=" & transType & ";" & _
                             "Tax Declaration Number=" & "N/A" & ";" & _
                             "Online ID=" & referenceCode & ";" & _
                             "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                             "Email Address=" + cSessionUser._pUserID + ";"
                        End If


                    Case "GROTTO"
                        MerchantCode = 2018070339 ' MUNTINLUPA
                        Particulars = "Transaction_type=Business Registration;Tax Reference Number=TRN-" + referenceCode + ";Payor Name=" + cSessionUser._pFirstName + ";Email Address=" + cSessionUser._pUserID + ";"

                    Case "MANDAUEWEBSVR"
                        ' MerchantCode = 2020101154
                        ' production L2021060676
                        ' retURLok = "http://122.53.27.82/PaymentConfirmation.aspx"
                        ' retURLerr = "http://122.53.27.82/PaymentConfirmation.aspx"


                        If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("TEST") = True Then
                            MerchantCode = 2021070015 ' MANDAUE TEST CODE
                            retURLok = "https://mandauecity.online/Test/PaymentConfirmation.aspx"
                            retURLerr = "https://mandauecity.online/Test/PaymentConfirmation.aspx"
                        Else
                            MerchantCode = 2021070015 ' MANDAUE LIVE CODE
                            retURLok = "https://mandauecity.online/PaymentConfirmation.aspx"
                            retURLerr = "https://mandauecity.online/PaymentConfirmation.aspx"
                        End If


                        If SelectedService = "RPT" Then
                            Particulars = "transaction_type=Real Property Tax;" & _
                            "Description=" & transType & ";" & _
                            "Tax Declaration Number=" & acctno & ";" & _
                            "Online ID=" & referenceCode & ";" & _
                            "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                            "E-mail Address=" + cSessionUser._pUserID + ";"

                        ElseIf SelectedService = "BP" Then
                            Particulars = "transaction_type=Business Tax;" & _
                            "Description=" & transType & ";" & _
                            "Business Identification Number=" & acctno & ";" & _
                            "Online ID=" & referenceCode & ";" & _
                            "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                            "E-mail Address=" + cSessionUser._pUserID + ";"

                        ElseIf SelectedService = "CTC" Then
                            Particulars = "transaction_type=Miscellaneous Fees;" & _
                            "Description=" & transType & ";" & _
                            "Control Number=" & acctno & ";" & _
                            "Online ID=" & referenceCode & ";" & _
                            "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                            "E-mail Address=" + cSessionUser._pUserID + ";"
                        End If




                    Case "TALISAYWEBSVR"
                        MerchantCode = 2020101154
                        retURLok = "http://58.69.116.217/PaymentConfirmation.aspx"
                        retURLerr = "http://58.69.116.217/PaymentConfirmation.aspx"
                        Particulars = "transaction_type=Real Property Tax;" & _
                                    "Description=" & transType & ";" & _
                                    "Tax Declaration Number=" & acctno & ";" & _
                                    "Online ID=" & referenceCode & ";" & _
                                    "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                                    "Email Address=" + cSessionUser._pUserID + ";"


                    Case "HAVANA"
                        Dim LGU As String
                        Dim strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery
                        Dim strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/")
                        LGU = Split(HttpContext.Current.Request.Url.AbsoluteUri, "/")(3).ToUpper

                        If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("CALOOCAN") = True Then
                            LGU = "CALOOCAN"
                            MerchantCode = 2020060003 '         

                        ElseIf HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("MANDAUE") = True Then
                            LGU = "MANDAUE"
                            MerchantCode = 2021070015

                        End If

                        retURLok = strUrl & LGU & "/PaymentConfirmation.aspx"
                        retURLerr = strUrl & LGU & "/PaymentConfirmation.aspx"

                        If SelectedService = "RPT" Then
                            cDalPayment.LBP_TransType = "Real Property"
                            Particulars = "transaction_type=Real Property Tax;" & _
                                "Description=" & transType & ";" & _
                                "Tax Declaration Number=" & acctno & ";" & _
                                "Online ID=" & referenceCode & ";" & _
                                "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                                "Email Address=" + cSessionUser._pUserID + ";"
                        ElseIf SelectedService = "BP" Then
                            cDalPayment.LBP_TransType = "Business Permit"
                            Particulars = "transaction_type=Business Permit;" & _
                               "Description=" & transType & ";" & _
                               "Business Identification Number=" & acctno & ";" & _
                               "Online ID=" + referenceCode + ";" & _
                               "Payor Name=" + cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                               "Email Address=" + cSessionUser._pUserID + ";"

                        ElseIf SelectedService = "CTC" Then
                            cDalPayment.LBP_TransType = "Cedula"
                            Particulars = "transaction_type=Real Property Tax;" & _
                             "Description=" & transType & ";" & _
                             "Tax Declaration Number=" & acctno & ";" & _
                             "Online ID=" & referenceCode & ";" & _
                             "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                             "Email Address=" + cSessionUser._pUserID + ";"
                        End If

                    Case "GRACEVILLE"
                        MerchantCode = "0322"
                        Dim trxndetails As String
                        If SelectedService = "RPT" Then
                            trxndetails = "Real Property Tax"
                        ElseIf SelectedService = "BP" Then
                            trxndetails = "Business Permit"
                        End If
                        Dim AllParams As String = "" & _
                            FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "") & _
                            MerchantCode & trxndetails & _
                            referenceCode & cSessionUser._pFirstName & " " & cSessionUser._pLastName & acctno & trxndetails & " Payment" & cSessionUser._pUserID & _
                            Nothing & Nothing & Nothing & Nothing & Nothing & _
                            0 & 0 & 0 & 0 & 0 & _
                            0 & 0 & 0 & 0 & Nothing & _
                            "username" & "password"
                        Particulars = GenerateSHA256String(AllParams & "N\HWJUKFHQX").ToUpper

                    Case "MANOLOWEBSVR"
                        MerchantCode = "0465"
                        Dim trxndetails As String
                        If SelectedService = "RPT" Then
                            trxndetails = "Real Property Tax"
                        ElseIf SelectedService = "BP" Then
                            trxndetails = "Business Permit"
                        End If
                        Dim AllParams As String = "" & _
                            FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "") & _
                            MerchantCode & _
                            trxndetails & _
                            referenceCode & _
                            cSessionUser._pFirstName & " " & cSessionUser._pLastName & _
                            acctno & _
                            cSessionUser._pUserID & _
                            Now.Date() & _
                            Nothing & Nothing & Nothing & Nothing & Nothing & _
                            0 & 0 & 0 & 0 & 0 & _
                            0 & 0 & 0 & 0 & Nothing & _
                            "username" & "password"
                        Particulars = GenerateSHA256String(AllParams & "N\HWJUKFHQX").ToUpper
                    Case "TKQWEBSERVER"
                        MerchantCode = "0493"
                        Dim trxndetails As String
                        If SelectedService = "RPT" Then
                            trxndetails = "Real Property Tax"
                        ElseIf SelectedService = "BP" Then
                            trxndetails = "Business Permit"
                        End If
                        Dim AllParams As String = "" & _
                            FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "") & _
                            MerchantCode & _
                            trxndetails & _
                            referenceCode & _
                            cSessionUser._pFirstName & " " & cSessionUser._pLastName & _
                            acctno & _
                            cSessionUser._pUserID & _
                            Now.Date() & _
                            Nothing & Nothing & Nothing & Nothing & Nothing & _
                            0 & 0 & 0 & 0 & 0 & _
                            0 & 0 & 0 & 0 & Nothing & _
                            "username" & "password"
                        Particulars = GenerateSHA256String(AllParams & "N\HWJUKFHQX").ToUpper

                    Case "MADRID" 'MANOLO CREDENTIALS
                        MerchantCode = "0465"
                        Dim trxndetails As String
                        If SelectedService = "RPT" Then
                            trxndetails = "Real Property Tax"
                        ElseIf SelectedService = "BP" Then
                            trxndetails = "Business Permit"
                        End If
                        Dim AllParams As String = "" & _
                            FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "") & _
                            MerchantCode & _
                            trxndetails & _
                            referenceCode & _
                            cSessionUser._pFirstName & " " & cSessionUser._pLastName & _
                            acctno & _
                            cSessionUser._pUserID & _
                            Now.Date() & _
                            Nothing & Nothing & Nothing & Nothing & Nothing & _
                            0 & 0 & 0 & 0 & 0 & _
                            0 & 0 & 0 & 0 & Nothing & _
                            "username" & "password"
                        Particulars = GenerateSHA256String(AllParams & "N\HWJUKFHQX").ToUpper

                End Select


                If retURLok = Nothing Then
                    Dim LGU As String
                    Dim strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery
                    Dim strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/")
                    retURLok = strUrl & "/PaymentConfirmation.aspx"
                End If
                cDalPayment.LBP_ReturnURLOK = retURLok
                cDalPayment.LBP_OnlineID = referenceCode
                cDalPayment.LBP_Amount = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "")
                cDalPayment.LBP_MerchantCode = MerchantCode
                cDalPayment.LBP_MerchantRefNo = referenceCode
                cDalPayment.LBP_Particulars = Particulars
                cDalPayment.LBP_PayorEmail = cSessionUser._pUserID
                cDalPayment.LBP_PayorName = cSessionUser._pFirstName & " " & cSessionUser._pLastName
                cDalPayment.LBP_ReturnURLError = retURLok
                cDalPayment.LBP_ReturnURLOK = retURLerr
                cDalPayment.LBP_ACCTNO = acctno
                MD5Hash = GetHashMD5(MerchantCode & referenceCode & Amount)

                If _nMachineName = "GRACEVILLE" Or
                    _nMachineName = "MANOLOWEBSVR" Or
                     _nMachineName = "TKQWEBSERVER" Or
                    _nMachineName = "MADRID" Then
                    MD5Hash = Particulars
                End If

                _nClass._pSubInsertPaymentLBP(referenceCode, cSessionUser._pUserID, SelectedBank, acctno, SelectedService, cSessionLoader._pTotalAmountDue, LCase(MD5Hash))

            Case "SPIDCPay"
                returnUrl = "PaymentPostback.aspx"
                'check if payment exists
                Dim Found As Boolean
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubCheckIfTransactionExists(acctno, SelectedService, cSessionLoader._pTotalAmountDue, Found)
                If Found = True Then
                    snackbar("red", "Payment for this transaction already exists")
                    Exit Sub
                Else
                    _nClass._pSubGetAutoPaymentRefNo()
                    referenceCode = SelectedService & _nClass._pReferenceNumber
                    cSessionLoader._pPSTransRefNo = referenceCode
                    acctno = Replace(acctno, "'", "")

                    qs = "?terminalID=" & terminalID & _
                        "&referenceCode=" & referenceCode & _
                        "&amount=" & Replace(cSessionLoader._pTotalAmountDue, ",", "") & _
                        "&securityToken=" & securityToken & _
                        "&returnURL=" & returnUrl & _
                        "&serviceType=" & cSessionLoader._pType & _
                        "&SelectedBank=" & SelectedBank & _
                        "&ACCTNO=" & acctno

                    _nClass._pSubInsertPaymentRefNo(referenceCode, cSessionUser._pUserID, SelectedBank, acctno, SelectedService)

                End If

            Case "ITBS"

                Dim strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery
                Dim strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/")
                returnUrl = strUrl & "PaymentConfirmation.aspx"
                cSessionLoader._pPSTransRefNo = referenceCode
                acctno = Replace(acctno, "'", "")
                '---------ITBS API - START
                Dim client = New RestClient("https://devuat.smartcountry.ph/")
                client.Timeout = -1
                Dim request = New RestRequest("/cpps/api/itbsGetTokenKey", Method.POST)
                Dim body = " {" & _
                            """apiKey"":""4f8b4e8d72f395d3bb0bb8bc2019cb44""," & _
                            """mode"":""API"", " & _
                            """sourceTransID"":""" & referenceCode & """," & _
                            """amount"":" & Replace(cSessionLoader._pTotalAmountDue, ",", "") & "," & _
                            """paymentDesc"":""" & SelectedService & """," & _
                            """payorName"":""" & cSessionUser._pFirstName & " " & cSessionUser._pLastName & """," & _
                            """email"": """ & cSessionUser._pUserID & """," & _
                            """contactNo"":""""," & _
                            """returnURL"":""" & returnUrl & """" & _
                            "}"

                request.AddParameter("application/json", body, ParameterType.RequestBody)
                Dim response1 As IRestResponse = client.Execute(request)
                Response.Write(response1.Content)

                Dim res As Object = New JavaScriptSerializer().Deserialize(Of Object)(response1.Content)
                Dim message As String
                message = res("message")
                If message = "success" Then
                    _nClass._pSubInsertPaymentRefNo(referenceCode, cSessionUser._pUserID, SelectedBank, acctno, SelectedService)
                    Response.Redirect(res("paymentLink") & "/" & res("tokenID"))
                    Exit Sub
                End If

                Response.Write("<script>alert('" & message & "');</script>")

            Case "OTC"
                returnUrl = "PaymentPostback.aspx"
                'check if payment exists
                Dim Found As Boolean
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubCheckIfTransactionExists(acctno, SelectedService, cSessionLoader._pTotalAmountDue, Found)
                If Found = True Then
                    snackbar("red", "Payment for this transaction already exists")
                    Exit Sub
                Else
                    cSessionLoader._pPSTransRefNo = referenceCode
                    acctno = Replace(acctno, "'", "")
                    qs = "?terminalID=" & terminalID & _
                        "&referenceCode=" + referenceCode & _
                        "&amount=" + Replace(cSessionLoader._pTotalAmountDue, ",", "") & _
                        "&securityToken=" + securityToken & _
                        "&returnURL=" + returnUrl & _
                        "&serviceType=" + cSessionLoader._pType & _
                        "&SelectedBank=" + SelectedBank & _
                        "&ACCTNO=" & acctno

                    _nClass._pSubInsertPaymentRefNo(referenceCode, cSessionUser._pUserID, SelectedBank, acctno, SelectedService)

                    'update billing s
                    ' If SelectedService = "BP" Then
                    '   _mSubGETBILLINGTEMP()
                    ' End If



                    'update OTC on TIMS to 1

                End If





        End Select


        Dim strID As String
        Dim statusID As String = "PENDING"
        If SelectedService = "BP" Then
            strID = ";BIN"
            cDalPayment.LBP_TransType = "Business Permit"
        ElseIf SelectedService = "RPT" Then
            strID = ";TDN"
            cDalPayment.LBP_TransType = "Real Property"
            acctno = cSessionLoader._pTDN.Replace("'", "")
        Else
            strID = ";CtrlNo"
            cDalPayment.LBP_TransType = "Cedula"
        End If

        If SelectedBank = "SPIDCPay" Then
            statusID = "SUCCESS"
        End If

        If Particulars = "" Then Particulars = "Payment Method=" & SelectedBank
        _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass3._pSubInsertHistory(cSessionLoader._pPSTransID, _
                                    cSessionUser._pUserID, _
                                    SelectedService, _
                                    "Payment", _
                                    SelectedBank, _
                                    "ID=" & cSessionLoader._pPSTransID & _
                                    ";Description=" & transType & _
                                    strID & "=" & acctno & ";" & Particulars & _
                                    ";TotalAmount=" & cSessionLoader._pTotalAmountDue & ";", _
                                    statusID)

        If SelectedBank = "DBP" Then
            Response.Redirect("DBPPayNow.aspx" + qs)
        ElseIf SelectedBank = "LBP" Then
            If _nMachineName = "MANDAUEWEBSVR" Then

            Else
                Response.Redirect("LBPPayNow.aspx")
            End If


            ElseIf SelectedBank = "OTC" Then
                Response.Redirect(returnUrl + qs)
            ElseIf SelectedBank = "SPIDCPay" Then
                Response.Redirect(returnUrl + qs)
            End If


    End Sub


    Shared Function GetHashMD5(theInput As String) As String

        Using hasher As MD5 = MD5.Create()    ' create hash object

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function
    Function getSHA1Hash(ByVal strToHash As String) As String

        Dim sha1Obj As New Cryptography.SHA1CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = sha1Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next

        Return strResult

    End Function
    Public Shared Function GenerateSHA256String(ByVal inputString) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(inputString)
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim stringBuilder As New StringBuilder()

        For i As Integer = 0 To hash.Length - 1
            stringBuilder.Append(hash(i).ToString("X2"))
        Next

        Return stringBuilder.ToString()
    End Function
    Sub snackbar(Color As String, Caption As String)
        If Color = "red" Then
            _oLabelSnackbar.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

        ElseIf Color = "green" Then
            _oLabelSnackbargreen.Text = Caption
            ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
        End If
    End Sub
    Private Sub btnPayNow_ServerClick(sender As Object, e As EventArgs) Handles btnPayNow.ServerClick
        Dim _nclass As New cDalPayment
        _nclass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nclass._pSubGetAutoPaymentRefNo()
        referenceCode = cSessionLoader._pService & _nclass._pReferenceNumber
        Dim _ACCTNO As String = Nothing
        subPayNow(hdnSelectedBank.Value, cSessionLoader._pService)

        '----------------------- New Paymennt Via API



        Dim _nClassGetDate As New cDalGetDate
        If cSessionLoader._pService = "BP" Then
            _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _ACCTNO = cSessionLoader._pAccountNo
            cDalPayment.Date_Expire = _nclass.Get_DateExpire_BP(cSessionLoader._pAccountNo)
        ElseIf cSessionLoader._pService = "RPT" Then
            _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            cDalPayment.Date_Expire = _nclass.Get_DateExpire_RP(cSessionLoader._pAccountNo)
            _ACCTNO = cSessionLoader._pAssessNo
        ElseIf cSessionLoader._pService = "OCBO" Then
            _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _ACCTNO = cSessionLoader._pAccountNo
        ElseIf cSessionLoader._pService = "LCR" Then
            _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _ACCTNO = cSessionLoader._pAccountNo
        End If

        If String.IsNullOrEmpty(cDalPayment.Date_Expire) Then
            _nClassGetDate._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            cDalPayment.Date_Expire = _nClassGetDate._GetEndOfDay_2 ' _nClassGetDate._GetEndOfDay("MMMM dd, yyyy hh:mm tt")
        End If

        Dim RawAmount As String = cSessionLoader._pTotalAmountDue
        Dim SpidcFEE As String = 0
        Dim OtherFee As String = 0
        Dim TotalAmount As String = cSessionLoader._pTotalAmountDue
        Dim LNAME As String = cSessionUser._pLastName
        Dim FNAME As String = cSessionUser._pFirstName
        Dim MNAME As String = cSessionUser._pMiddleName
        Dim SUFFIX As String = ""
        Dim BillingValidityDate As String = cDalPayment.Date_Expire
        Dim Email As String = cSessionUser._pUserID 'PAYOR EMAIL
        Dim SpidcRefNo As String = referenceCode 'TXNREFNO
        Dim ACCTNO As String = _ACCTNO ' BIN, TDN , Account Number
        Dim TransactionType As String = cSessionLoader._pService 'RPT, BP, OBO, LCR, MISC
        Dim Gateway_Selected As String = hdnSelectedBank.Value 'LBP1, LBP2, DBP, OTC, PAYMAYA, PAYMAYA2, GCASH, ITBS, SPIDCPAY
        Dim URL_Origin As String = HttpContext.Current.Request.Url.AbsoluteUri 'URL BEFORE FORM POST

        '--------INSERT TO TRANSACTION HISTORY
        Dim _nClassTransactionHistory As New cDalTransactionHistory
        _nClassTransactionHistory._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClassTransactionHistory._pSubInsertHistory(cSessionLoader._pPSTransID, _
                                    cSessionUser._pUserID, _
                                    TransactionType, _
                                    "Online Payment", _
                                    Gateway_Selected, _
                                    "ID=" & SpidcRefNo & _
                                    "ACCTNO=" & _ACCTNO & ";" & _
                                    ";TotalAmount=" & cSessionLoader._pTotalAmountDue & ";", _
                                    "PENDING")

        Dim PostURL As String = HttpContext.Current.Request.Url.Host & "/Process.aspx"


        Dim sb = New System.Text.StringBuilder()
        Response.Clear()
        sb.Append("<html>")
        sb.AppendFormat("<body onload='document.forms[0].submit()'>")
        sb.AppendFormat("<form target='_blank' action='" & PostURL & "' method='post'>")
        sb.AppendFormat("<input type='text' name='RawAmount' value='{0}'>", RawAmount)
        sb.AppendFormat("<input type='text' name='SpidcFEE' value='{0}'>", SpidcFEE)
        sb.AppendFormat("<input type='text' name='OtherFee' value='{0}'>", OtherFee)
        sb.AppendFormat("<input type='text' name='TotalAmount' value='{0}'>", TotalAmount)
        sb.AppendFormat("<input type='text' name='LNAME' value='{0}'>", LNAME)
        sb.AppendFormat("<input type='text' name='FNAME' value='{0}'>", FNAME)
        sb.AppendFormat("<input type='text' name='MNAME' value='{0}'>", MNAME)
        sb.AppendFormat("<input type='text' name='SUFFIX' value='{0}'>", SUFFIX)
        sb.AppendFormat("<input type='text' name='BillingValidityDate' value='{0}'>", BillingValidityDate)
        sb.AppendFormat("<input type='text' name='Email' value='{0}'>", Email)
        sb.AppendFormat("<input type='text' name='SpidcRefNo' value='{0}'>", SpidcRefNo)
        sb.AppendFormat("<input type='text' name='ACCTNO' value='{0}'>", ACCTNO)
        sb.AppendFormat("<input type='text' name='TransactionType' value='{0}'>", TransactionType)
        sb.AppendFormat("<input type='text' name='Gateway_Selected' value='{0}'>", Gateway_Selected)
        sb.AppendFormat("<input type='text' name='URL_Origin' value='{0}'>", URL_Origin)
        sb.Append("</form>")
        sb.Append("</body>")
        sb.Append("</html>")
        Response.Write(sb.ToString())
        Response.[End]()
    End Sub
    Private Sub _mSubGETBILLINGTEMP()
        Try
            '----------------------------------
            Dim _nClass As New cDalBPSOS
            Dim myOutPut As String

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS

            Dim _nClBP As New cDalGlobalConnectionsDefault
            _nClBP._pCxn = cGlobalConnections._pSqlCxn_CR
            _nClBP._pSetupGlobalConnectionsDatabases = "BPLTAS"
            _nClBP._pSubRecordSelectSpecific()

            '----------------------------------
            'Specify Blank to Select Nothing but Column Names
            _nClass._pSubGetCurYear()
            _nClass._pForYear = _nClass._nCurYear
            _nClass._pAcctNo = cSessionLoader._pAccountNo
            _nClass._pLocServer = _nClBP._pDBDataSource
            _nClass._pLocDB = _nClBP._pDBInitialCatalog
            _nClass._pTempTblBT = "tempBT_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pTempTbl = "temp_" & cSessionUser._pUserID.Replace(".", "")
            _nClass._pMOP = cSessionLoader._pPayMode
            '----------------------------------

            _nClass._pSubGETBILLINGTEMP()





        Catch ex As Exception

        End Try

        '----------------------------------

    End Sub

    Sub get_PaymentGateways()
        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR

        hdnSelectedBank.Value = "OTC"

        If _nClass._pSubGetGatewayStatus("SPIDCPAY") = False Then
            div_SPIDCPay.Attributes.CssStyle.Add("pointer-events", "none")
            div_SPIDCPay.Attributes.CssStyle.Add("opacity", "0.4")
            div_SPIDCPay.Attributes.CssStyle.Add("display", "none")
        End If

        If _nClass._pSubGetGatewayStatus("LBP1") = False Then
            div_LBP.Attributes.CssStyle.Add("pointer-events", "none")
            div_LBP.Attributes.CssStyle.Add("opacity", "0.4")
            div_LBP.Attributes.CssStyle.Add("display", "none")
        End If

        If _nClass._pSubGetGatewayStatus("LBP2") = False Then
            div_LBP2.Attributes.CssStyle.Add("pointer-events", "none")
            div_LBP2.Attributes.CssStyle.Add("opacity", "0.4")
            div_LBP2.Attributes.CssStyle.Add("display", "none")
        End If

        If _nClass._pSubGetGatewayStatus("DBP") = False Then
            div_DBP.Attributes.CssStyle.Add("pointer-events", "none")
            div_DBP.Attributes.CssStyle.Add("opacity", "0.4")
            div_DBP.Attributes.CssStyle.Add("display", "none")
        End If

        ' If _nClass._pSubGetGatewayStatus("OTC") = False Then
        '     div_OTC.Attributes.CssStyle.Add("pointer-events", "none")
        '     div_OTC.Attributes.CssStyle.Add("opacity", "0.4")
        '     div_OTC.Attributes.CssStyle.Add("display", "none")
        ' End If

        If _nClass._pSubGetGatewayStatus("PAYMAYA") = False Then
            div_PayMaya.Attributes.CssStyle.Add("pointer-events", "none")
            div_PayMaya.Attributes.CssStyle.Add("opacity", "0.4")
            div_PayMaya.Attributes.CssStyle.Add("display", "none")
        End If

        If _nClass._pSubGetGatewayStatus("PAYMAYA2") = False Then
            div_PayMaya2.Attributes.CssStyle.Add("pointer-events", "none")
            div_PayMaya2.Attributes.CssStyle.Add("opacity", "0.4")
            div_PayMaya2.Attributes.CssStyle.Add("display", "none")
        End If

        If _nClass._pSubGetGatewayStatus("GCASH") = False Then
            div_GCASH.Attributes.CssStyle.Add("pointer-events", "none")
            div_GCASH.Attributes.CssStyle.Add("opacity", "0.4")
            div_GCASH.Attributes.CssStyle.Add("display", "none")
        End If

        If _nClass._pSubGetGatewayStatus("ITBS") = False Then
            div_ITBS.Attributes.CssStyle.Add("pointer-events", "none")
            div_ITBS.Attributes.CssStyle.Add("opacity", "0.4")
            div_ITBS.Attributes.CssStyle.Add("display", "none")
        End If



    End Sub

    Private Sub btnProceed_ServerClick(sender As Object, e As EventArgs) Handles btnProceed.ServerClick
        subPayNow(hdnSelectedBank.Value, cSessionLoader._pService)
        '   ClientScript.RegisterStartupScript(Me.[GetType](), "OpenWindow", "window.open('','_blank');", True)
        Response.Redirect("PaymentInstruction.aspx")
    End Sub

    Sub do_PAYMAYA(ByVal SelectedService As String, ByVal transType As String, ByVal SelectedBank As String)
        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nClass._pSubGetGatewayCredentials(SelectedBank.ToUpper)

        PayMaya.PayorEmail = cSessionUser._pUserID
        PayMaya.Amount = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "")
        PayMaya.TransType = SelectedService
        PayMaya.SPIDCRefNo = referenceCode
        PayMaya.PaymentDesc = transType
        PayMaya.ACCTNO = acctno
        PayMaya.API_Type = "Create Checkout Payment - POST"

        Dim _TXNREFNO As String = referenceCode
        Dim _EMAILADDR As String = cSessionUser._pUserID
        Dim _PAYMENTCHANNEL As String = "PayMaya"
        Dim _ACCTNO As String = acctno
        Dim _strDATE As String = "PENDING"
        Dim _STATUSID As String = "PENDING"
        Dim _STATUS As String = "Pending"
        Dim _GATEWAYREFNO As String = Nothing
        Dim _SECURITY As String = Nothing
        Dim _TYPE As String = SelectedService
        Dim _TRANSDATE As String = Nothing
        Dim _TRXDATE As String = Nothing
        Dim _RAWAMOUNT As String = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "")
        Dim _TOTAMOUNT As String = FormatNumber(cSessionLoader._pTotalAmountDue, 2).Replace(",", "")
        Dim _FEEAMOUNT As String = "0.00"
        Dim _DATEVERIFIED As String = Nothing
        Dim _VERIFIEDBY As String = Nothing
        Dim _VERIFYING As String = Nothing
        Dim _VIA As String = "PayMaya"
        Dim _POSTEDDATE As String = Nothing
        Dim _POSTSTATUS As String = Nothing
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubInsertPaymentPaymaya(_TXNREFNO, _EMAILADDR, _PAYMENTCHANNEL, _ACCTNO, _strDATE, _STATUSID, _STATUS, _GATEWAYREFNO, _SECURITY, _TYPE, _TRANSDATE, _TRXDATE, _RAWAMOUNT, _TOTAMOUNT, _FEEAMOUNT, _DATEVERIFIED, _VERIFIEDBY, _VERIFYING, _VIA, _POSTEDDATE, _POSTSTATUS)
        Response.Redirect("PayMaya.aspx")

    End Sub

    Sub do_LBP(ByVal SelectedService As String, ByVal transType As String, ByVal TransDesc As String, ByVal acctno As String, ByVal ServerName As String)
        Dim particulars As String
        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nClass._pSubGetGatewayCredentials("LBP1")
        Dim _nClass2 As New cHardwareInformation
        Dim _nMachineName As String = _nClass2._pMachineName.ToUpper
        'gw_Status As Boolean
        'gw_MerchantCode As String
        'gw_TestURL As String
        'gw_TestURL_Return As String
        'gw_ProdURL As String
        'gw_ProdURL_Return As String
        'gw_UserName As String
        'gw_Password As String
        'gw_SecretKey As String
        'gw_apiKey As String
        'gw_SecretApiKey As String
        'gw_PublicApiKey As String
        'gw_DateNow As DateTime
        'gw_LIVE As Boolean

        ' _mDate_Esta As String
        ' _mEmail As String
        '
        ' RPT_Single_TDN As String
        '
        '
        ' Date_Expire As String

        If _nClass.gw_Status = True Then
            'do EPP
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubInsertPaymentLBP(referenceCode, cSessionUser._pUserID, "LBP1", acctno, SelectedService, cSessionLoader._pTotalAmountDue, Nothing)
            LBPPayNow.transType = transType
            LBPPayNow.referenceCode = referenceCode
            LBPPayNow.BIN_TDN = acctno
            LBPPayNow.SelectedService = SelectedService
            Response.Redirect("LBPPayNow.aspx")
            Exit Sub
        End If

        _nClass._pSubGetGatewayCredentials("LBP2")
        If _nClass.gw_Status = True Then
            'do EPS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubInsertPaymentLBP(referenceCode, cSessionUser._pUserID, "LBP2", acctno, SelectedService, cSessionLoader._pTotalAmountDue, Nothing)

            If SelectedService = "RPT" Then
                transType = "Real Property Tax"
                ' _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
                ' cDalPayment.Date_Expire = _nClass.Get_DateExpire_RP(acctno)

                Dim _nClass3 As New cDalGetDate
                _nClass3._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
                cDalPayment.Date_Expire = _nClass3._GetEndOfDay_2 ' _nClass3._GetEndOfDay("MMMM dd, yyyy hh:mm tt")

                If LBPPayNow2.Multiple_TDN = True Then
                    acctno = "Various"
                Else
                    acctno = cDalPayment.RPT_Single_TDN
                End If
            ElseIf SelectedService = "BP" Then
                transType = "Business Permit"
                If _nMachineName = "MANOLOWEBSVR" Or _
                    transType = "Business Tax Payment" Then
                End If



                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
                cDalPayment.Date_Expire = _nClass.Get_DateExpire_BP(acctno)
            End If
            LBPPayNow2.transType = transType
            LBPPayNow2.referenceCode = referenceCode
            LBPPayNow2.BIN_TDN = acctno

            Response.Redirect("LBPPayNow2.aspx")
        End If

        Exit Sub
        '---------------------------

        Dim MerchantCode As String
        Dim MD5Hash As String = Nothing

        Dim x As String = cSessionLoader._pTotalAmountDue.Replace(",", "")
        x = FormatNumber(x, 2)
        x = x.Replace(",", "")
        Dim Amount As String = x.Replace(".", "")

        cSessionLoader._pPSTransRefNo = referenceCode
        Dim retURLok As String
        Dim retURLerr As String


        If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("TEST") = True Then
            MerchantCode = 2020060003 ' CALOOCAN TEST CODE
            retURLok = "https://online.caloocancity.gov.ph/Test/PaymentConfirmation.aspx"
            retURLerr = "https://online.caloocancity.gov.ph/Test/PaymentConfirmation.aspx"
        Else
            MerchantCode = 2020100016 ' CALOOCAN LIVE CODE
            retURLok = "https://online.caloocancity.gov.ph/PaymentConfirmation.aspx"
            retURLerr = "https://online.caloocancity.gov.ph/PaymentConfirmation.aspx"
        End If

        If SelectedService = "RPT" Then
            cDalPayment.LBP_TransType = "Real Property"
            particulars = "transaction_type=Real Property Tax;" & _
                          "Description=" & transType & ";" & _
                          "Tax Declaration Number=" & acctno & ";" & _
                          "Online ID=" & referenceCode & ";" & _
                          "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                          "Email Address=" + cSessionUser._pUserID + ";"
        ElseIf SelectedService = "BP" Then
            cDalPayment.LBP_TransType = "Business Permit"
            particulars = "transaction_type=Business Permit;" & _
                          "Description=" & transType & ";" & _
                          "Business Identification Number=" & acctno & ";" & _
                          "Online ID=" + referenceCode + ";" & _
                          "Payor Name=" + cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
                          "Email Address=" + cSessionUser._pUserID + ";"

        ElseIf SelectedService = "CTC" Then
            cDalPayment.LBP_TransType = "Cedula"
            particulars = "" & _
             "transaction_type=Real Property Tax;" & _
             "Description=" & transType & ";" & _
             "Tax Declaration Number=" & "N/A" & ";" & _
             "Online ID=" & referenceCode & ";" & _
             "Payor Name=" & cSessionUser._pFirstName & " " & cSessionUser._pLastName + ";" & _
             "Email Address=" + cSessionUser._pUserID + ";"
        End If


    End Sub

  
End Class