Imports System.Net
Imports RestSharp
Imports System.Web.Script.Serialization
Imports System.Security.Cryptography
Imports System.Web.HttpContext
Imports System.Threading.Tasks
Imports System.Reflection
Imports Microsoft.Reporting.WebForms
Imports SPIDC.Resources

Public Class Process
    Inherits System.Web.UI.Page
    'Public Property RawAmount As String
    'Public Property SpidcFEE As String
    'Public Property OtherFee As String
    'Public Property TotalAmount As String
    'Public Property LNAME As String
    'Public Property FNAME As String
    'Public Property MNAME As String
    'Public Property SUFFIX As String
    'Public Property BillingValidityDate As String
    'Public Property Email As String 'PAYOR EMAIL
    'Public Property SpidcRefNo As String 'TXNREFNO
    'Public Property ACCTNO As String ' BIN, TDN , Account Number
    'Public Property TransactionType As String 'RPT, BP, OBO, LCR, MISC
    'Public Property Gateway_Selected As String 'LBP1, LBP2, DBP, OTC, PAYMAYA, PAYMAYA2, GCASH, ITBS, SPIDCPAY
    'Public Property URL_Origin As String 'URL BEFORE FORM POST

    'Dim _EORNO As String = Nothing
    'Dim _SRS As String = Nothing
    'Dim _SEQ As String = Nothing
    Dim err As String
    Dim _SPIDCREFNO As String


#Region "Variables"
    '_ssc = Session String Constant
    Private Const _sscPrefix As String = "PayNow2."
    Private Const _sscRawAmount As String = _sscPrefix & "_sscRawAmount"
    Private Const _sscSpidcFEE As String = _sscPrefix & "_sscSpidcFEE"
    Private Const _sscOtherFee As String = _sscPrefix & "_sscOtherFee"
    Private Const _sscTotalAmount As String = _sscPrefix & "_sscTotalAmount"
    Private Const _sscLNAME As String = _sscPrefix & "_sscLNAME"
    Private Const _sscFNAME As String = _sscPrefix & "_sscFNAME"
    Private Const _sscMNAME As String = _sscPrefix & "_sscMNAME"
    Private Const _sscSUFFIX As String = _sscPrefix & "_sscSUFFIX"
    Private Const _sscBillingValidityDate As String = _sscPrefix & "_sscBillingValidityDate"
    Private Const _sscEmail As String = _sscPrefix & "_sscEmail"
    Private Const _sscSpidcRefNo As String = _sscPrefix & "_sscSpidcRefNo"
    Private Const _sscGatewayRefNo As String = _sscPrefix & "_sscGatewayRefNo"
    Private Const _sscACCTNO As String = _sscPrefix & "_sscACCTNO"
    Private Const _sscTransactionType As String = _sscPrefix & "_sscTransactionType"
    Private Const _sscGateway_Selected As String = _sscPrefix & "_sscGateway_Selected"
    Private Const _sscURL_Origin As String = _sscPrefix & "_sscURL_Origin"

    Private Const _sscEORNO As String = _sscPrefix & "_sscEORNO"
    Private Const _sscSRS As String = _sscPrefix & "_sscSRS"
    Private Const _sscSEQ As String = _sscPrefix & "_sscSEQ"
    Private Const _sscParamOK As String = _sscPrefix & "_sscParamOK"

    Private Const _sscOwnerName As String = _sscPrefix & "_sscOwnerName"
    Private Const _sscOwnerAddress As String = _sscPrefix & "_sscOwnerAddress"
#End Region

#Region "Properties"

    Shared Property OwnerName() As String
        Get
            Return Current.Session(_sscOwnerName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOwnerName) = value
        End Set
    End Property

    Shared Property OwnerAddress() As String
        Get
            Return Current.Session(_sscOwnerAddress)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOwnerAddress) = value
        End Set
    End Property


    Shared Property ParamOK() As String
        Get
            Return Current.Session(_sscParamOK)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscParamOK) = value
        End Set
    End Property
    Shared Property SEQ() As String
        Get
            Return Current.Session(_sscSEQ)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSEQ) = value
        End Set
    End Property
    Shared Property SRS() As String
        Get
            Return Current.Session(_sscSRS)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSRS) = value
        End Set
    End Property
    Shared Property EORNO() As String
        Get
            Return Current.Session(_sscEORNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEORNO) = value
        End Set
    End Property
    Shared Property URL_Origin() As String
        Get
            Return Current.Session(_sscURL_Origin)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscURL_Origin) = value
        End Set
    End Property
    Shared Property Gateway_Selected() As String
        Get
            Return Current.Session(_sscGateway_Selected)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGateway_Selected) = value
        End Set
    End Property
    Shared Property TransactionType() As String
        Get
            Return Current.Session(_sscTransactionType)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTransactionType) = value
        End Set
    End Property
    Shared Property ACCTNO() As String
        Get
            Return Current.Session(_sscACCTNO)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscACCTNO) = value
        End Set
    End Property
    Shared Property SpidcRefNo() As String
        Get
            Return Current.Session(_sscSpidcRefNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSpidcRefNo) = value
        End Set
    End Property
    Shared Property GatewayRefNo() As String
        Get
            Return Current.Session(_sscGatewayRefNo)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscGatewayRefNo) = value
        End Set
    End Property
    Shared Property Email() As String
        Get
            Return Current.Session(_sscEmail)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscEmail) = value
        End Set
    End Property
    Shared Property BillingValidityDate() As String
        Get
            Return Current.Session(_sscBillingValidityDate)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscBillingValidityDate) = value
        End Set
    End Property
    Shared Property SUFFIX() As String
        Get
            Return Current.Session(_sscSUFFIX)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSUFFIX) = value
        End Set
    End Property
    Shared Property MNAME() As String
        Get
            Return Current.Session(_sscMNAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscMNAME) = value
        End Set
    End Property
    Shared Property FNAME() As String
        Get
            Return Current.Session(_sscFNAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscFNAME) = value
        End Set
    End Property
    Shared Property LNAME() As String
        Get
            Return Current.Session(_sscLNAME)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscLNAME) = value
        End Set
    End Property
    Shared Property TotalAmount() As String
        Get
            Return Current.Session(_sscTotalAmount)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscTotalAmount) = value
        End Set
    End Property
    Shared Property OtherFee() As String
        Get
            Return Current.Session(_sscOtherFee)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOtherFee) = value
        End Set
    End Property
    Shared Property SpidcFEE() As String
        Get
            Return Current.Session(_sscSpidcFEE)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscSpidcFEE) = value
        End Set
    End Property
    Shared Property RawAmount() As String
        Get
            Return Current.Session(_sscRawAmount)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscRawAmount) = value
        End Set
    End Property
#End Region


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
            If Not IsPostBack Then

                'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                'If ParamOK = "1" Then
                '    Exit Sub
                'End If

                If isParamsOK(err) Then
                    Process.ParamOK = "1"
                    Response.Write(Gateway_Selected)
                    If Gateway_Selected = "LBP1" Then
                        do_post()
                    ElseIf Gateway_Selected = "LBP2" Then
                        do_LBP2(err)
                    ElseIf Gateway_Selected = "SPIDCPAY" Then
                        do_SPIDCPAY()
                    ElseIf Gateway_Selected = "PAYMAYA" Then
                        do_MAYA()
                    ElseIf Gateway_Selected = "GCASH" Then
                        do_GCASH()
                    ElseIf Gateway_Selected = "OTC" Then
                        do_OTC()
                    ElseIf Gateway_Selected = "ITBS" Then
                        do_ITBS()
                    Else
                        Response.Write("Unknown Gateway : " & Gateway_Selected)
                    End If

                    If err IsNot Nothing Then
                        Response.Write(err)
                    End If
                Else
                    Process.ParamOK = "0"
                    Response.Write(err)
                    Exit Sub
                End If

            Else

            End If

        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Function isParamsOK(ByRef _err As String) As Boolean
        _err = Nothing
        RawAmount = Page.Request.Form("RawAmount")
        SpidcFEE = Page.Request.Form("SpidcFEE")
        OtherFee = Page.Request.Form("OtherFee")
        TotalAmount = Page.Request.Form("TotalAmount")
        LNAME = Page.Request.Form("LNAME")
        FNAME = Page.Request.Form("FNAME")
        MNAME = Page.Request.Form("MNAME")
        SUFFIX = Page.Request.Form("SUFFIX")
        Email = Page.Request.Form("Email")
        SpidcRefNo = Page.Request.Form("SpidcRefNo")
        ACCTNO = Page.Request.Form("ACCTNO")
        TransactionType = Page.Request.Form("TransactionType")
        Gateway_Selected = Page.Request.Form("Gateway_Selected")
        BillingValidityDate = Page.Request.Form("BillingValidityDate")
        URL_Origin = Page.Request.Form("URL_Origin")

        If String.IsNullOrEmpty(RawAmount) Then _err += " RawAmount"
        If String.IsNullOrEmpty(SpidcFEE) Then _err += " SpidcFEE"
        If String.IsNullOrEmpty(OtherFee) Then _err += " OtherFee"
        If String.IsNullOrEmpty(TotalAmount) Then _err += " TotalAmount"
        If String.IsNullOrEmpty(LNAME) Then _err += " LNAME"
        If String.IsNullOrEmpty(FNAME) Then _err += " FNAME"
        If String.IsNullOrEmpty(Email) Then _err += " Email"
        If String.IsNullOrEmpty(SpidcRefNo) Then _err += " SpidcRefNo"
        If String.IsNullOrEmpty(ACCTNO) Then _err += " ACCTNO"
        If String.IsNullOrEmpty(TransactionType) Then _err += " TransactionType"
        If String.IsNullOrEmpty(Gateway_Selected) Then _err += " Gateway_Selected"
        If String.IsNullOrEmpty(BillingValidityDate) Then _err += " BillingValidityDate"
        If String.IsNullOrEmpty(URL_Origin) Then _err += " URL_Origin"

        If _err = Nothing Then
            Return True
        Else
            Return False
        End If

    End Function

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
    Private Sub do_post()
        Dim URI As String
        Dim RUO As String 'Return URL OK
        Dim RUE As String 'Return URL Error
        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nClass._pSubGetGatewayCredentials(Gateway_Selected)

        If cDalPayment.gw_LIVE = True Then
            URI = cDalPayment.gw_ProdURL
            RUO = cDalPayment.gw_ProdURL_Return
            RUE = cDalPayment.gw_ProdURL_Return
        Else
            URI = cDalPayment.gw_TestURL
            RUO = cDalPayment.gw_TestURL_Return
            RUE = cDalPayment.gw_TestURL_Return
        End If

        Dim P As String = Nothing
        Dim A As String = FormatNumber(TotalAmount, 2)
        Dim Ax As String = A.Replace(".", "")
        Dim Ay As String = Ax.Replace(",", "")
        Dim H As String = GetHashMD5(cDalPayment.gw_MerchantCode & SpidcRefNo & Ay).ToLower

        Dim _nClass2 As New cHardwareInformation
        Dim _nMachineName As String = Nothing
        _nMachineName = _nClass2._pMachineName.ToUpper

        Select Case _nMachineName
            Case "WEBSVRCALOOCAN"
                If TransactionType = "RPT" Then
                    P = _
                    "transaction_type=Real Property Tax;" &
                    "Description=Real Property Payment;" &
                    "Tax Declaration Number=" & ACCTNO & ";" &
                    "Online ID=" & SpidcRefNo & ";" &
                    "Payor Name=" & FNAME & " " & LNAME & ";" &
                    "Email Address=" & Email
                ElseIf TransactionType = "BP" Then
                    Dim BIN2 As New String(ACCTNO.Where(Function(c) Char.IsDigit(c)).ToArray())
                    P = _
                    "transaction_type=Business Permit;" &
                    "Description=BIN : " & ACCTNO & ";" &
                    "Business Identification Number=" & BIN2 & ";" &
                    "Online ID=" & SpidcRefNo & ";" &
                    "Payor Name=" & FNAME & " " & LNAME & ";" &
                    "Email Address=" & Email
                End If

            Case "MANDAUEWEBSVR"
                P = _
                "transaction_type=Real Property Tax;" &
                "Description=Real Property Payment;" &
                "Tax Declaration Number=" & ACCTNO & ";" &
                "Online ID=" & SpidcRefNo & ";" &
                "Payor Name=" & FNAME & " " & LNAME & ";" &
                "E-mail Address=" & Email & ";"

        End Select


        Dim myParameters As String = "MerchantCode=" & cDalPayment.gw_MerchantCode &
                                            "&MerchantRefNo=" & SpidcRefNo &
                                            "&Particulars=" & P &
                                            "&Amount=" & A &
                                            "&PayorName=" & FNAME & " " & LNAME &
                                            "&PayorEmail=" & Email &
                                            "&ReturnURLOK=" & RUO &
                                            "&ReturnURLError=" & RUE &
                                            "&Hash=" & H

        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubInsertLBPLogs(cDalPayment.gw_MerchantCode,
                                   SpidcRefNo,
                                   P,
                                   TotalAmount.Replace(",", ""),
                                   FNAME & " " & LNAME,
                                   Email,
                                   "PENDING",
                                   "",
                                   "",
                                   "",
                                   "PENDING", URI & "?" & myParameters)

        Response.Clear()
        Response.Write("Redirecting to Land Bank Payment Portal...")
        Dim sb = New System.Text.StringBuilder()
        sb.Append("<html>")
        sb.AppendFormat("<body onload='document.forms[0].submit()'>")
        sb.AppendFormat("<body>")
        sb.AppendFormat("<form action='" & URI & "' method='post'>")
        sb.AppendFormat("<br><input type='hidden' width='300px' name='MerchantCode' value='{0}'>", cDalPayment.gw_MerchantCode)
        sb.AppendFormat("<br><input type='hidden' width='300px' name='MerchantRefNo' value='{0}'>", SpidcRefNo)
        sb.AppendFormat("<br><input type='hidden' width='300px' name='Particulars' value='{0}'>", P)
        sb.AppendFormat("<br><input type='hidden' width='300px' name='Amount' value='{0}'>", A.Replace(",", ""))
        sb.AppendFormat("<br><input type='hidden' width='300px' name='PayorName' value='{0}'>", FNAME & " " & LNAME)
        sb.AppendFormat("<br><input type='hidden' width='300px' name='PayorEmail' value='{0}'>", Email)
        sb.AppendFormat("<br><input type='hidden' width='300px' name='ReturnURLOK' value='{0}'>", RUO)
        sb.AppendFormat("<br><input type='hidden' width='300px' name='ReturnURLError' value='{0}'>", RUE)
        sb.AppendFormat("<br><input type='hidden' width='300px' name='Hash' value='{0}'>", H)
        sb.Append("</form>")
        sb.Append("</body>")
        sb.Append("</html>")
        Response.Write(sb.ToString())
        Response.[End]()

    End Sub

    Sub do_LBP1(ByRef err As String)
        Dim _err As String = Nothing
        Try
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubGetGatewayCredentials(Gateway_Selected)

            Dim URI As String
            Dim RUO As String 'Return URL OK
            Dim RUE As String 'Return URL Error
            Dim FixedAmount As String = FormatNumber(TotalAmount, 2).Replace(",", "")
            Dim Hash As String = _nClass.GetHashMD5(cDalPayment.gw_MerchantCode & SpidcRefNo & FixedAmount.Replace(".", "")).ToLower()
            Dim Particulars As String = Nothing
            Dim _nClass2 As New cHardwareInformation
            Dim _nMachineName As String = Nothing
            _nMachineName = _nClass2._pMachineName.ToUpper


            Select Case _nMachineName
                Case "WEBSVRCALOOCAN"
                    If TransactionType = "RPT" Then
                        Particulars = "transaction_type=Real Property Tax;" &
                        "Description=Real Property Payment;" &
                        "Tax Declaration Number=" & ACCTNO & ";" &
                        "Online ID=" & SpidcRefNo & ";" &
                        "Payor Name=" & FNAME & " " & LNAME & ";" &
                        "Email Address=" & Email & ";"

                    ElseIf TransactionType = "BP" Then
                        Particulars = "transaction_type=Business Permit;" &
                       "Description=Business Permit Payment;" &
                       "Business Identification Number=" & ACCTNO & ";" &
                       "Online ID=" & SpidcRefNo & ";" &
                       "Payor Name=" & FNAME & " " & LNAME & ";" &
                       "Email Address=" & Email & ";"
                    End If

                Case "MANDAUEWEBSVR", "MADRID"
                    If TransactionType = "RPT" Then
                        Particulars = "transaction_type=Real Property Tax;" &
                        "Description=Real Property Tax Payment;" &
                        "Tax Declaration Number=" & ACCTNO & ";" &
                        "Online ID=" & SpidcRefNo & ";" &
                        "Payor Name=" & FNAME & " " & LNAME & ";" &
                        "E-mail Address=" + cSessionUser._pUserID + ";"

                    ElseIf TransactionType = "BP" Then
                        Particulars = "transaction_type=Business Permit;" &
                       "Description=Business Permit Payment;" &
                       "Business Identification Number=" & ACCTNO & ";" &
                       "Online ID=" & SpidcRefNo & ";" &
                       "Payor Name=" & FNAME & " " & LNAME & ";" &
                       "E-mail Address=" + cSessionUser._pUserID + ";"

                    ElseIf TransactionType = "CTC" Then
                        Particulars = "transaction_type=Miscellaneous Fees;" &
                       "Description=Cedula Payment;" &
                       "Control Number=" & ACCTNO & ";" &
                       "Online ID=" & SpidcRefNo & ";" &
                       "Payor Name=" & FNAME & " " & LNAME & ";" &
                       "E-mail Address=" + cSessionUser._pUserID + ";"
                    End If
            End Select


            If cDalPayment.gw_LIVE = True Then
                URI = cDalPayment.gw_ProdURL
                RUO = cDalPayment.gw_ProdURL_Return
                RUE = cDalPayment.gw_ProdURL_Return
            Else
                URI = cDalPayment.gw_TestURL
                RUO = cDalPayment.gw_TestURL_Return
                RUE = cDalPayment.gw_TestURL_Return
            End If

            Dim myParameters As String = "MerchantCode=" & cDalPayment.gw_MerchantCode &
                                         "&MerchantRefNo=" & SpidcRefNo &
                                         "&Particulars=" & Particulars &
                                         "&Amount=" & FixedAmount &
                                         "&PayorName=" & FNAME & " " & LNAME &
                                         "&PayorEmail=" & Email &
                                         "&ReturnURLOK=" & RUO &
                                         "&ReturnURLError=" & RUE &
                                         "&Hash=" & Hash

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubInsertLBPLogs(cDalPayment.gw_MerchantCode,
                                       SpidcRefNo,
                                       Particulars,
                                       FixedAmount,
                                       FNAME & " " & LNAME,
                                       Email,
                                       "PENDING",
                                       "",
                                       "",
                                       "",
                                       "PENDING", URI & "?" & myParameters)

            Response.Clear()
            Response.Write(URI + "?" + myParameters)
            Response.Write("Redirecting to Land Bank Payment Portal...")
            Response.Redirect(URI + "?" + myParameters)
        Catch ex As Exception
        End Try
    End Sub
    Sub do_LBP2(ByRef err As String)
        Try
            Dim _nClass2 As New cHardwareInformation
            Dim _nMachineName As String = _nClass2._pMachineName.ToUpper

            Select Case TransactionType
                Case "BP"
                    If _nMachineName = "MANOLOWEBSVR" Then
                        TransactionType = "Business Tax Payment"
                    Else
                        TransactionType = "Business Permit"
                    End If
                Case "RPT"
                    TransactionType = "Real Property Tax"
                Case "CTC"
                    TransactionType = "Cedula"
                Case "OBO"
                    TransactionType = "OBO Permit"
                Case "LCR"
                    TransactionType = "Registry Certificate"
            End Select

            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass._pSubGetGatewayCredentials(Gateway_Selected)
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim trxnamt As String = FormatNumber(TotalAmount, 2).Replace(",", "")
            Dim merchantcodex As String = cDalPayment.gw_MerchantCode
            Dim bankcode As String = "B000"
            Dim trxndetails As String = TransactionType
            Dim trandetail1 As String = SpidcRefNo ' Online ID
            Dim trandetail2 As String = FNAME & " " & LNAME 'Payor Name
            Dim trandetail3 As String = ACCTNO ' TDN or BIN
            Dim trandetail4 As String = Email 'Email ADdress
            Dim trandetail5 As String = BillingValidityDate 'Billing Validity Date
            Dim trandetail6 As String = Nothing
            Dim trandetail7 As String = Nothing
            Dim trandetail8 As String = Nothing
            Dim trandetail9 As String = Nothing
            Dim trandetail10 As String = Nothing
            Dim trandetail11 As String = 0
            Dim trandetail12 As String = 0
            Dim trandetail13 As String = 0
            Dim trandetail14 As String = 0
            Dim trandetail15 As String = 0
            Dim trandetail16 As String = 0
            Dim trandetail17 As String = 0
            Dim trandetail18 As String = 0
            Dim trandetail19 As String = 0
            Dim trandetail20 As String = Nothing
            Dim callbackURL As String
            Dim checksum As String = Nothing
            Dim username As String = cDalPayment.gw_UserName
            Dim password As String = cDalPayment.gw_Password
            Dim SecretKey As String = cDalPayment.gw_SecretKey
            Dim LBPDomain As String


            If cDalPayment.gw_LIVE = True Then
                callbackURL = cDalPayment.gw_ProdURL_Return
                LBPDomain = cDalPayment.gw_ProdURL

            Else
                callbackURL = cDalPayment.gw_TestURL_Return
                LBPDomain = cDalPayment.gw_TestURL
            End If



            Dim _nClassMachine As New cHardwareInformation

            Dim _nLGU As String = cSessionLGUProfile._pLGU_Name()

            If _nLGU.Contains("SAN JOSE DEL MONTE") Then
                '' trandetail4 is equivalent to  Description
                cPaymentParameters.LBP(trxnamt, merchantcodex, TransactionType, SpidcRefNo, FNAME & " " & LNAME, ACCTNO,
                  TransactionType & " Online Payment", Email, BillingValidityDate, trandetail7, trandetail8, trandetail9,
                  trandetail10, trandetail11, trandetail12, trandetail13, trandetail14, trandetail15,
                  trandetail16, trandetail17, trandetail18, trandetail19, trandetail20)

            Else

                cPaymentParameters.LBP(trxnamt, merchantcodex, trxndetails, trandetail1, trandetail2, trandetail3,
                  trandetail4, trandetail5, trandetail6, trandetail7, trandetail8, trandetail9,
                  trandetail10, trandetail11, trandetail12, trandetail13, trandetail14, trandetail15,
                  trandetail16, trandetail17, trandetail18, trandetail19, trandetail20)

            End If

            'callbackURL = cDalPayment.gw_TestURL_Return
            'LBPDomain = cDalPayment.gw_TestURL

            checksum = cPaymentParameters._LBP_Cheksum & username & password
            'trxnamt & merchantcodex & trxndetails & trandetail1 & trandetail2 & trandetail3 &
            '   trandetail4 & trandetail5 & trandetail6 & trandetail7 & trandetail8 & trandetail9 &
            '   trandetail10 & trandetail11 & trandetail12 & trandetail13 & trandetail14 & trandetail15 &
            '   trandetail16 & trandetail17 & trandetail18 & trandetail19 & trandetail20 & username & password

            checksum = _nClass.GenerateSHA256String(checksum & SecretKey).ToUpper

            Dim post_data As String = "?trxnamt=" & cPaymentParameters._ptrxnamt &
                                  "&merchantcode=" & cPaymentParameters._pmerchantcodex &
                                  "&bankcode=" & bankcode &
                                  "&trxndetails=" & cPaymentParameters._ptrxndetails &
                                  "&trandetail1=" & cPaymentParameters._ptrandetail1 &
                                  "&trandetail2=" & cPaymentParameters._ptrandetail2 &
                                  "&trandetail3=" & cPaymentParameters._ptrandetail3 &
                                  "&trandetail4=" & cPaymentParameters._ptrandetail4 &
                                  "&trandetail5=" & cPaymentParameters._ptrandetail5 &
                                  "&trandetail6=" & cPaymentParameters._ptrandetail6 &
                                  "&trandetail7=" & cPaymentParameters._ptrandetail7 &
                                  "&trandetail8=" & cPaymentParameters._ptrandetail8 &
                                  "&trandetail9=" & cPaymentParameters._ptrandetail9 &
                                  "&trandetail10=" & cPaymentParameters._ptrandetail10 &
                                  "&trandetail11=" & cPaymentParameters._ptrandetail11 &
                                  "&trandetail12=" & cPaymentParameters._ptrandetail12 &
                                  "&trandetail13=" & cPaymentParameters._ptrandetail13 &
                                  "&trandetail14=" & cPaymentParameters._ptrandetail14 &
                                  "&trandetail15=" & cPaymentParameters._ptrandetail15 &
                                  "&trandetail16=" & cPaymentParameters._ptrandetail16 &
                                  "&trandetail17=" & cPaymentParameters._ptrandetail17 &
                                  "&trandetail18=" & cPaymentParameters._ptrandetail18 &
                                  "&trandetail19=" & cPaymentParameters._ptrandetail19 &
                                  "&trandetail20=" & cPaymentParameters._ptrandetail20 &
                                  "&callbackurl=" & callbackURL &
                                  "&checksum=" & checksum &
                                  "&username=" & username &
                                  "&password=" & password

            '@Remarked 20231115
            ' ''Dim post_data As String = "?trxnamt=" & trxnamt &
            ' ''                      "&merchantcode=" & merchantcodex &
            ' ''                      "&bankcode=" & bankcode &
            ' ''                      "&trxndetails=" & trxndetails &
            ' ''                      "&trandetail1=" & trandetail1 &
            ' ''                      "&trandetail2=" & trandetail2 &
            ' ''                      "&trandetail3=" & trandetail3 &
            ' ''                      "&trandetail4=" & trandetail4 &
            ' ''                      "&trandetail5=" & trandetail5 &
            ' ''                      "&trandetail6=" & trandetail6 &
            ' ''                      "&trandetail7=" & trandetail7 &
            ' ''                      "&trandetail8=" & trandetail8 &
            ' ''                      "&trandetail9=" & trandetail9 &
            ' ''                      "&trandetail10=" & trandetail10 &
            ' ''                      "&trandetail11=" & trandetail11 &
            ' ''                      "&trandetail12=" & trandetail12 &
            ' ''                      "&trandetail13=" & trandetail13 &
            ' ''                      "&trandetail14=" & trandetail14 &
            ' ''                      "&trandetail15=" & trandetail15 &
            ' ''                      "&trandetail16=" & trandetail16 &
            ' ''                      "&trandetail17=" & trandetail17 &
            ' ''                      "&trandetail18=" & trandetail18 &
            ' ''                      "&trandetail19=" & trandetail19 &
            ' ''                      "&trandetail20=" & trandetail20 &
            ' ''                      "&callbackurl=" & callbackURL &
            ' ''                      "&checksum=" & checksum &
            ' ''                      "&username=" & username &
            ' ''                      "&password=" & password

            Dim string_to_Post As String = LBPDomain & post_data
            Response.Write(string_to_Post)

            Dim client = New RestClient(string_to_Post)
            client.Timeout = -1
            Dim request = New RestRequest(Method.POST)
            Dim _response As IRestResponse = client.Execute(request)

            _nClass.LBP_EPS_InsertLog(string_to_Post, _response.Content, SpidcRefNo, ACCTNO, TransactionType)
            Response.Write(_response.Content)

            Dim errdesc As String = Nothing
            Dim str As String = _response.Content
            Dim strArr() As String
            strArr = str.Split("|")
            If strArr(0) = "00" Then
                Response.Clear()
                Response.Redirect(strArr(1))
            Else
                _nClass._pSubGetEpsErrorCode(strArr(0), errdesc)
                '  Response.Clear()
                Response.Write(errdesc)


            End If

            ' Response.Clear()
            ' Response.Write(_response.Content)

        Catch ex As Exception
            '  Response.Clear()
            Response.Write(ex.Message)
        End Try

        Dim errMsg As String

        ' Dim request As WebRequest = WebRequest.Create(LBPDomain)
        ' request.Method = "POST"





    End Sub
    Sub do_OTC()
        Try
            Dim _nClass As New cDalPayment

            Response.Clear()
            Response.Write("Checking status, please wait...")
            Dim sb = New System.Text.StringBuilder()
            sb.Append("<html>")
            sb.AppendFormat("<body onload='document.forms[0].submit()'>")
            sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
            sb.AppendFormat("<input type='hidden' name='PaymentRefNo' value='{0}'>", SpidcRefNo)
            sb.AppendFormat("<input type='hidden' name='BillingValidityDate' value='{0}'>", BillingValidityDate)
            sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", "Pending")
            sb.AppendFormat("<input type='hidden' name='PaymentOption' value='Over-The-Counter'>")
            sb.AppendFormat("<input type='hidden' name='ConvinienceFee' value='{0}'>", SpidcFEE)
            sb.AppendFormat("<input type='hidden' name='BillingAmt' value='{0}'>", RawAmount)
            sb.AppendFormat("<input type='hidden' name='TotalAmount' value='{0}'>", TotalAmount)
            sb.AppendFormat("<input type='hidden' name='OriginUrl' value='{0}'>", _nClass.get_OriginURL(SpidcRefNo))
            sb.AppendFormat("<input type='hidden' name='Note' value='Please proceed to Treasury Office and present your Statement of Account(SOA) to settle your payment.'>")
            sb.Append("</form>")
            sb.Append("</body>")
            sb.Append("</html>")
            Response.Write(sb.ToString())
            Response.[End]()


        Catch ex As Exception

        End Try
    End Sub
    Sub do_SPIDCPAY()
        Try
            '--add delay
            'Dim random As New Random()
            'Dim delay As Integer = random.Next(0, 10000)
            'Thread.Sleep(delay)

            Dim err As String = Nothing

            'Dim srs As String = Nothing 'Series ex: CAL2023-04
            'Dim seq As String = Nothing 'Sequence ex : 9000000000001
            'Dim eORNO As String = Nothing 'srs & seq ex: CAL2023-04-9000000000001

            ' Dim _nClassPP As New cDalPaymentPosting
            Dim _nClass As New cDalPayment
            '    Dim _nclassPDSRPTAS As New cDalPDSRPTAS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            '   Dim dt As String
            '  _nClass._pSubGetDate(dt)
            '    Dim Sent As Boolean = False
            '    Dim Body As String = Nothing
            Dim _getdate As String = _nClass.Get_Date()
            Process.GatewayRefNo = "SPIDCPAY - " & Process.SpidcRefNo
            _nClass._pSubUpdateOnlinePaymentInfo(Process.SpidcRefNo _
            , "Successful Payment" _
            , GatewayRefNo _
            , "AutoPaid-" & Process.SpidcRefNo _
            , _getdate _
            , CDbl(Process.RawAmount) _
            , CDbl(Process.SpidcFEE) _
            , CDbl(Process.TotalAmount) _
            , "SUCCESS" _
            , Process.Gateway_Selected, err)

            If String.IsNullOrEmpty(err) = False Then
                Response.Write(err)
                Exit Sub
            End If

            _nClass.Update_History(Process.SpidcRefNo, Process.TransactionType, Process.Gateway_Selected, Process.ACCTNO, Process.TotalAmount, 0, "Successful Payment", "SPIDCPAY-" & Process.SpidcRefNo, err)
            If String.IsNullOrEmpty(err) = False Then
                Response.Write(err)
                Exit Sub
            End If

            _SPIDCREFNO = Process.SpidcRefNo

            eOR.TaxPayerEmail = _nClass.Get_Details("OnlinePaymentRefNo", "EMAILADDR", "TXNREFNO", _SPIDCREFNO)
            eOR.SPIDC_RefNo = _SPIDCREFNO
            eOR.Gateway_RefNo = Process.GatewayRefNo

            Dim _nclassGetModules As New cDalGetModules
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            If _nclassGetModules._pSubGetAvailableModules("EOR") = True Then

                If cInit_eOR.Initialize_EOR(_SPIDCREFNO, Report_EOR, Process.Gateway_Selected, Process.GatewayRefNo) = True Then GoTo jumphere


                Response.Clear()
                Dim Posting_err As String = Nothing

                '    Response.Write("START_POSTING")
                Dim strChecker As String
                START_POSTING(Posting_err, EORNO, , , strChecker)
                _GenerateReport_eOR(1, Process.TransactionType, EORNO)
                '  Response.Write(strChecker)
                If String.IsNullOrEmpty(Posting_err) = False Then
                    Response.Write(Posting_err)
                    Exit Sub
                Else
                    Response.Redirect("WEBPORTAL/Account.aspx")
                End If
                Exit Sub
            End If

            Dim sent As Boolean = False
            Dim Body As String = "Dear Valued Tax Payer, <br> " & _
                   "This confirms your bill payment transaction with the following details: <br> " & _
                   "Transaction Number: " & SpidcRefNo & "<br>" & _
                   "Transaction Type: " & TransactionType & " Payment<br>" & _
                   "Account No. : " & ACCTNO & "<br>" & _
                   "Amount Paid : " & TotalAmount & "<br> <br>"
            cDalNewSendEmail.SendEmail(Email, "Online Payment Confirmation", Body, sent)

jumphere:

            Response.Redirect("WEBPORTAL/Account.aspx")


            ''Response.Clear()
            ''Response.Write("Checking status, please wait...")

            ''Dim sb = New System.Text.StringBuilder()
            ''sb.Append("<html>")
            ''sb.AppendFormat("<body onload='document.forms[0].submit()'>")
            ''sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
            ''sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", SpidcRefNo)
            ''sb.AppendFormat("<input type='hidden' name='AssessmentNo' value='{0}'>", ACCTNO)
            ''sb.AppendFormat("<input type='hidden' name='BillingValidityDate' value='{0}'>", BillingValidityDate)
            ''sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", "SUCCESS")
            ''sb.AppendFormat("<input type='hidden' name='PaymentOption' value='{0}'>", Gateway_Selected)
            ''sb.AppendFormat("<input type='hidden' name='Gateway_Fee' value='{0}'>", eOR.Gateway_Fee)
            ''sb.AppendFormat("<input type='hidden' name='ConvinienceFee' value='{0}'>", eOR.SPIDC_Fee)
            ''sb.AppendFormat("<input type='hidden' name='BillingAmt' value='{0}'>", eOR.Bill_Amount)
            ''sb.AppendFormat("<input type='hidden' name='TotalAmount' value='{0}'>", eOR.GrandTotal)
            ''sb.AppendFormat("<input type='hidden' name='OriginUrl' value='{0}'>", _nClass.get_OriginURL(SpidcRefNo))
            ''sb.AppendFormat("<input type='hidden' name='Note' value='Successful Payment'>")
            ''sb.Append("</form>")
            ''sb.Append("</body>")
            ''sb.Append("</html>")
            ''Response.Write(sb.ToString())
            ''Response.[End]()
            ''Exit Sub



        Catch ex As Exception
            err = ";do_SPIDCPAY:" & ex.Message
            Console.Write(err)
        End Try

        'If TransactionType = "RPT" Then
        '    _nClassPP.Taxpayer_Email = cSessionUser._pUserID
        '    '         _nClassPP.do_process(ACCTNO, SpidcRefNo, Gateway_Selected, err)
        '    If String.IsNullOrEmpty(err) = False Then
        '        Response.Write(err)
        '        Exit Sub
        '    End If
        '    SEQ = _nClassPP.Get_eORno(ACCTNO, TransactionType)

        'ElseIf TransactionType = "BP" Then
        '    Dim clsBillOL As New BPLTAS_POSTING_ONLINE.clssBilling
        '    clsBillOL.CR_xSERVER = cGlobalConnections._pSqlCxn_CR.DataSource
        '    clsBillOL.CR_xDataBase = cGlobalConnections._pSqlCxn_CR.Database
        '    clsBillOL.CR_xUID = _nClassPP._mSubUIPW("UI", "OAIMS")
        '    clsBillOL.CR_xPW = _nClassPP._mSubUIPW("PW", "OAIMS")

        '    clsBillOL.BPLTAS_xACCTNO = ACCTNO
        '    clsBillOL.BPLTAS_TOTALPAID = CDbl(RawAmount)
        '    clsBillOL.BPLTAS_REFNO = SpidcRefNo
        '    clsBillOL.BPLTAS_DATEPAID = _nClass.Get_ServerDate()

        '    clsBillOL.BPLTAS_GATEWAY = Gateway_Selected

        '    clsBillOL.pSubProcessBilling()

        '    SEQ = clsBillOL.pSRSORNO
        'Else
        '    Body = "Dear Valued Tax Payer, <br> " & _
        '           "This confirms your bill payment transaction with the following details: <br> " & _
        '           "Transaction Number: " & SpidcRefNo & "<br>" & _
        '           "Transaction Type: " & TransactionType & " Payment<br>" & _
        '           "Account No. : " & ACCTNO & "<br>" & _
        '           "Amount Paid : " & TotalAmount & "<br> <br>"
        '    cDalNewSendEmail.SendEmail(Email, "Online Payment Confirmation", Body, Sent)

        '    Response.Clear()
        '    Response.Write("Checking status, please wait...")

        '    Dim sb = New System.Text.StringBuilder()
        '    sb.Append("<html>")
        '    sb.AppendFormat("<body onload='document.forms[0].submit()'>")
        '    sb.AppendFormat("<form action='{0}' method='post'>", "PaymentNotification.aspx")
        '    sb.AppendFormat("<input type='hidden' name='MerchantRefNo' value='{0}'>", SpidcRefNo)
        '    sb.AppendFormat("<input type='hidden' name='AssessmentNo' value='{0}'>", ACCTNO)
        '    sb.AppendFormat("<input type='hidden' name='BillingValidityDate' value='{0}'>", BillingValidityDate)
        '    sb.AppendFormat("<input type='hidden' name='Status' value='{0}'>", "SUCCESS")
        '    sb.AppendFormat("<input type='hidden' name='PaymentOption' value='{0}'>", Gateway_Selected)
        '    sb.AppendFormat("<input type='hidden' name='Gateway_Fee' value='{0}'>", eOR.Gateway_Fee)
        '    sb.AppendFormat("<input type='hidden' name='ConvinienceFee' value='{0}'>", eOR.SPIDC_Fee)
        '    sb.AppendFormat("<input type='hidden' name='BillingAmt' value='{0}'>", eOR.Bill_Amount)
        '    sb.AppendFormat("<input type='hidden' name='TotalAmount' value='{0}'>", eOR.GrandTotal)
        '    '  sb.AppendFormat("<input type='hidden' name='OriginUrl' value='{0}'>", _nClass.get_OriginURL(SpidcRefNo))
        '    sb.AppendFormat("<input type='hidden' name='Note' value='Successful Payment'>")
        '    sb.Append("</form>")
        '    sb.Append("</body>")
        '    sb.Append("</html>")
        '    Response.Write(sb.ToString())
        '    Response.[End]()
        '    Exit Sub
        'End If

        'Response.Write("<br>Transaction has been Posted.")

        'SRS = _nClassPP.get_SRS
        'EORNO = SRS & "-" & SEQ

        'If String.IsNullOrEmpty(EORNO) = True Then
        '    Response.Write("eOR is Empty")
        '    Exit Sub
        'End If

        '_nClass.Update_Transaction("MinORNO", EORNO, "txnrefno", SpidcRefNo)
        '_nClass.Update_Transaction("MaxORNO", EORNO, "txnrefno", SpidcRefNo)

        'If String.IsNullOrEmpty(err) = True Then
        '    eOR.SPIDC_RefNo = SpidcRefNo
        '    eOR.Gateway = _nClass.Get_Details("OnlinePaymentRefNo", "PaymentChannel", "TXNREFNO", SpidcRefNo)
        '    eOR.Gateway_RefNo = _nClass.Get_Details("OnlinePaymentRefNo", "GatewayRefNo", "TXNREFNO", SpidcRefNo)
        '    eOR.Gateway_ConfDate = _nClass.Get_Date()
        '    eOR.Gateway_Fee = _nClass.Get_Details("OnlinePaymentRefNo", "FeeAmount", "TXNREFNO", SpidcRefNo)
        '    eOR.SPIDC_Fee = _nClass.Get_Details("OnlinePaymentRefNo", "FeeAmountSPIDC", "TXNREFNO", SpidcRefNo)
        '    eOR.Bill_Amount = _nClass.Get_Details("OnlinePaymentRefNo", "RawAmount", "TXNREFNO", SpidcRefNo)
        '    eOR.GrandTotal = CDbl(eOR.Gateway_Fee) + CDbl(eOR.SPIDC_Fee) + CDbl(eOR.Bill_Amount)
        '    eOR.AssessNo = ACCTNO


        '    '    Response.Write("<br>Getting Posted Transaction")
        '    _nClassPP.Print_eOR(err)
        '    If String.IsNullOrEmpty(err) = False Then
        '        Response.Write(err)
        '        Exit Sub
        '    End If

        '    Response.Write("<br>Sending E-OR")
        '    ' Response.Write("<script>window.open ('WebPortal/Report/ReportViewer.aspx?ReportType=eOR&Send=1','_blank');</script>")
        '    Response.Write("<script>window.location.replace('WebPortal/Report/ReportViewer.aspx?ReportType=eOR&Send=1');</script>")


        '    '   Exit Sub
        'Else
        '    Response.Write(err)
        '    Exit Sub
        'End If



    End Sub
    Sub _1UPDATE_OAIMS_STATUS()
        Try
            Dim err As String = Nothing
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim dt As String
            _nClass._pSubGetDate(dt)
            Dim Sent As Boolean = False
            Dim Body As String = Nothing
            Dim _getdate As String = _nClass.Get_Date()
            _nClass._pSubUpdateOnlinePaymentInfo(SpidcRefNo _
            , "Successful Payment" _
            , "SPIDCPAY-" & SpidcRefNo _
            , "AutoPaid-" & SpidcRefNo _
            , _getdate _
            , CDbl(RawAmount) _
            , CDbl(SpidcFEE) _
            , CDbl(TotalAmount) _
            , "SUCCESS" _
            , Gateway_Selected)
            _nClass.Update_History(SpidcRefNo, TransactionType, Gateway_Selected, ACCTNO, TotalAmount, 0, "Successful Payment", "SPIDCPAY-" & SpidcRefNo)
            Response.Clear()
            Response.Write("<script>alert('Payment Successful.');</script>")
        Catch ex As Exception

        End Try
    End Sub
    Sub do_ITBS()
        Dim returnUrl As String
        Dim URI As String
        If cDalPayment.gw_LIVE = True Then
            URI = cDalPayment.gw_ProdURL
            returnUrl = cDalPayment.gw_ProdURL_Return
        Else
            URI = cDalPayment.gw_TestURL
            returnUrl = cDalPayment.gw_TestURL_Return
        End If

        '---------ITBS API - START
        Dim client = New RestClient("https://devuat.smartcountry.ph/")
        client.Timeout = -1
        Dim request = New RestRequest("/cpps/api/itbsGetTokenKey", Method.POST)
        Dim body = " {" & _
                    """apiKey"":" & cDalPayment.gw_apiKey & "," & _
                    """mode"":""API"", " & _
                    """sourceTransID"":""" & SpidcRefNo & """," & _
                    """amount"":" & TotalAmount & "," & _
                    """paymentDesc"":""" & TransactionType & """," & _
                    """payorName"":""" & LNAME & ", " & FNAME & """," & _
                    """email"": """ & Email & """," & _
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
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubInsertPaymentRefNo(SpidcRefNo, Email, Gateway_Selected, ACCTNO, TransactionType)
            Response.Redirect(res("paymentLink") & "/" & res("tokenID"))
            Exit Sub
        End If
        Response.Write("<script>alert('" & message & "');</script>")
    End Sub
    Sub do_GCASH()

    End Sub
    Sub do_MAYA()

    End Sub
    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
    Private Sub btn_PostPayment_ServerClick(sender As Object, e As EventArgs) Handles btn_PostPayment.ServerClick
        '  _1PostPayment()
    End Sub
    Private Sub btn_GetPostedDetails_ServerClick(sender As Object, e As EventArgs) Handles btn_GetPostedDetails.ServerClick
        '  _2GetPostedDetails()
    End Sub
    Private Sub btn_GenerateEORReport_ServerClick(sender As Object, e As EventArgs) Handles btn_GenerateEORReport.ServerClick
        '  _3GenerateEORReport()
    End Sub
    Private Sub btn_Home_ServerClick(sender As Object, e As EventArgs) Handles btn_Home.ServerClick
        '  Response.Redirect("WebPortal/Account.aspx")
    End Sub
    Private Sub _1PostPayment(ByRef _err As String, ByRef eORNO As String, Optional ByRef strChecker As String = Nothing)
        Dim qry As String = Nothing
        Try
            'Dim err As String = Nothing
            'Dim srs As String = Nothing 'Series ex: CAL2023-04
            'Dim seq As String = Nothing 'Sequence ex : 9000000000001
            'Dim eORNO As String = Nothing 'srs & seq ex: CAL2023-04-9000000000001
            Dim _nClassEOR As New eOR
            Dim _nClassPP As New cDalPaymentPosting
            Dim _nClass As New cDalPayment
            Dim _nclassPDSRPTAS As New cDalPDSRPTAS

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim dt As String
            Dim Sent As Boolean = False
            Dim Body As String = Nothing
            Dim _getdate As String = _nClass.Get_Date()
            Dim _Seq As String = Nothing
            Dim _EORNO As String = Nothing
            Dim _SRS As String = Nothing
            Dim _OR_NO As String = Nothing
            Dim _Book_No As String = Nothing
            Dim _User As String = Nothing
            Dim _GateWay As String = Nothing
            Dim _or_date As String = Nothing


            Process.TransactionType = Trim(_nClassEOR.getTransactionType(eOR.SPIDC_RefNo))

            If _nClassEOR.ALL_IN_ONE(Process.TransactionType, eOR.SPIDC_RefNo, qry, _err) = False Then
                '  _err = _err & ";" & Process.TransactionType & ";" & eOR.SPIDC_RefNo & ";" & qry
                '  err = ";AIO:" & err
                Exit Sub
            End If
            strChecker += ";TEST 0:" & Trim(Process.TransactionType)
            If Trim(Process.TransactionType) = "RPT" Then
                strChecker += ";TEST 1:" & Trim(Process.TransactionType)
                _nClassPP.Taxpayer_Email = eOR.TaxPayerEmail
                _nClassPP.do_process(ACCTNO, _nClassEOR._PaymentRefNo, _nClassEOR._Gateway, _nClassEOR._OR_NO, _nClassEOR._SRS, _nClassEOR._Book_No, _nClassEOR.__USER, _err, strChecker)
                strChecker += ";TEST 1.1:" & _err
                '_err = strChecker
                'Exit Sub
                ' _nClassPP.do_process(Process.ACCTNO, Process.SpidcRefNo, Process.Gateway_Selected, Process.EORNO, Process.SRS, _Book_No, _User, err)
                If String.IsNullOrEmpty(_err) = False Then
                    '   Response.Write(err)
                    Exit Sub
                End If
                '     Process.SEQ = _nClassPP.Get_eORno(ACCTNO, TransactionType)

            ElseIf Trim(Process.TransactionType) = "BP" Then
                strChecker += ";TEST 2:" & Trim(Process.TransactionType)

                Dim clsBillOL As New BPLTAS_POSTING_ONLINE.clssBilling
                clsBillOL.CR_xSERVER = cGlobalConnections._pSqlCxn_CR.DataSource
                clsBillOL.CR_xDataBase = cGlobalConnections._pSqlCxn_CR.Database
                clsBillOL.CR_xUID = _nClassPP._mSubUIPW("UI", "OAIMS")
                clsBillOL.CR_xPW = _nClassPP._mSubUIPW("PW", "OAIMS")
                clsBillOL.BPLTAS_xACCTNO = ACCTNO
                clsBillOL.BPLTAS_TOTALPAID = CDbl(RawAmount)
                clsBillOL.BPLTAS_REFNO = _nClassEOR._PaymentRefNo
                clsBillOL.BPLTAS_DATEPAID = _nClass.Get_ServerDate()
                clsBillOL.BPLTAS_GATEWAY = _nClassEOR._Gateway
                clsBillOL.pORNO = _nClassEOR._OR_NO
                clsBillOL.pSRS = _nClassEOR._SRS


                'Dim rand As New Random() ' Create a new instance of the Random class    
                'Task.Delay((rand.Next(1, 5)) * 1000).Wait()

                'strChecker += ";pSubProcessBilling:Start"
                'Response.Write("<script>alert('Start Posting')</script>")
                clsBillOL.pSubProcessBilling()
                'Response.Write("<script>alert('Posting Done')</script>")
                'Response.Write("<script>alert('Monitor_Message : " & clsBillOL.Monitor_Message & "')</script>")
                'Response.Write("<script>alert('Error_Message : " & clsBillOL.Error_Message & "')</script>")
                'strChecker += ";pSubProcessBilling:End"

                'strChecker += ";clsBillOL.CR_xSERVER:" & cGlobalConnections._pSqlCxn_CR.DataSource
                'strChecker += ";clsBillOL.CR_xDataBase:" & cGlobalConnections._pSqlCxn_CR.Database
                'strChecker += ";clsBillOL.CR_xUID:" & _nClassPP._mSubUIPW("UI", "OAIMS")
                'strChecker += ";clsBillOL.CR_xPW:" & _nClassPP._mSubUIPW("PW", "OAIMS")
                'strChecker += ";clsBillOL.BPLTAS_xACCTNO:" & ACCTNO
                'strChecker += ";clsBillOL.BPLTAS_TOTALPAID:" & CDbl(RawAmount)
                'strChecker += ";clsBillOL.BPLTAS_REFNO:" & _nClassEOR._PaymentRefNo
                'strChecker += ";clsBillOL.BPLTAS_DATEPAID:" & _nClass.Get_ServerDate()
                'strChecker += ";clsBillOL.BPLTAS_GATEWAY:" & _nClassEOR._Gateway
                'strChecker += ";clsBillOL.pORNO:" & _nClassEOR._OR_NO
                'strChecker += ";clsBillOL.pSRS:" & _nClassEOR._SRS
                'strChecker += ";Monitor_Message:" & clsBillOL.Monitor_Message
                'strChecker += ";Error_Message:" & clsBillOL.Error_Message

                'If String.IsNullOrEmpty(clsBillOL.Monitor_Message) = False Then
                '    _err += ";Monitor_Message" & clsBillOL.Monitor_Message

                'End If

                If String.IsNullOrEmpty(clsBillOL.Error_Message) = False Then
                    _err += ";Error_Message" & clsBillOL.Error_Message

                End If







                ' _err += strChecker
            End If
            '  _err += ";TEST 3:" & Trim(Process.TransactionType)
            strChecker += ";TEST 3:"
            _nClass.Update_Transaction("MinORNO", _nClassEOR._eORNO, "txnrefno", _nClassEOR._PaymentRefNo)
            _nClass.Update_Transaction("MaxORNO", _nClassEOR._eORNO, "txnrefno", _nClassEOR._PaymentRefNo)
            strChecker += ";TEST 4:"
            eOR.SPIDC_RefNo = _nClassEOR._PaymentRefNo
            eOR.Gateway = _nClass.Get_Details("OnlinePaymentRefNo", "PaymentChannel", "TXNREFNO", _nClassEOR._PaymentRefNo)
            eOR.Gateway_RefNo = _nClass.Get_Details("OnlinePaymentRefNo", "GatewayRefNo", "TXNREFNO", _nClassEOR._PaymentRefNo)
            eOR.Gateway_ConfDate = _nClass.Get_Date()
            eOR.Gateway_Fee = _nClass.Get_Details("OnlinePaymentRefNo", "FeeAmount", "TXNREFNO", _nClassEOR._PaymentRefNo)
            eOR.SPIDC_Fee = _nClass.Get_Details("OnlinePaymentRefNo", "FeeAmountSPIDC", "TXNREFNO", _nClassEOR._PaymentRefNo)
            eOR.Bill_Amount = _nClass.Get_Details("OnlinePaymentRefNo", "RawAmount", "TXNREFNO", _nClassEOR._PaymentRefNo)
            eOR.GrandTotal = CDbl(eOR.Gateway_Fee) + CDbl(eOR.SPIDC_Fee) + CDbl(eOR.Bill_Amount)
            eOR.AssessNo = ACCTNO


            eORNO = _nClassEOR._eORNO
            strChecker += ";TEST 5:"
            ' btn_PostPayment.Style.Add("display", "none")
            'btn_GetPostedDetails.Style.Add("display", "")
            'Response.Write("<br>Type : " & Process.TransactionType)
            'Response.Write("<br>EOR : " & Process.EORNO)
            'Response.Write("<br>SpidcRefNo : " & Process.SpidcRefNo)
            'Response.Write("<br>TDN/BIN : " & Process.ACCTNO)
            'Response.Write("<br>Raw Amount : " & Process.RawAmount)
            'Response.Write("<br>Total Amount : " & Process.TotalAmount)
            'Response.Write("<script>alert('Posting Successful.');</script>")

        Catch ex As Exception
            ' Response.Write(";_1PostPayment:" & _err)
            _err += strChecker & ex.Message
            strChecker += ";_1PostPayment ERR:" & ex.Message

            '_err = _err & ";" & Process.TransactionType & ";" & eOR.SPIDC_RefNo & ";" & qry
        End Try
    End Sub
    Private Sub _2GetPostedDetails(ByRef _err As String, ByVal eORNO As String, Optional ByVal gatewayRefNo As String = Nothing)
        Dim qry As String = Nothing
        Try
            Dim _nClassPP As New cDalPaymentPosting
            eOR.Gateway_RefNo = gatewayRefNo
            _nClassPP.Print_eOR(eORNO, _err, qry)
            If String.IsNullOrEmpty(_err) = False Then
                _err += ";" & qry
                Exit Sub
            End If

            ''   eOR.Update_Sent(eORNO, ERR)
            'eOR.email = eOR.Get_EMAIL(eORNO)



        Catch ex As Exception
            Response.Write(_err)
        End Try
    End Sub
    Private Sub _3GenerateEORReport()
        'btn_PostPayment.Style.Add("display", "none")
        'btn_GetPostedDetails.Style.Add("display", "none")
        'btn_GenerateEORReport.Style.Add("display", "none")
        'btn_Home.Style.Add("display", "")

        '  Response.Write("<script>window.open('WebPortal/Report/ReportViewer.aspx?ReportType=eOR&Send=1', '_blank');</script>")

        HttpContext.Current.Response.Redirect("Report/ReportViewer.aspx?ReportType=eOR&Send=1")

        ' Response.Write("<script>window.open('WebPortal/Report/ReportViewer.aspx?ReportType=eOR&Send=1');</script>")
        ' Response.Write("<script>alert('Payment Success');window.location.replace('WebPortal/Account.aspx');</script>")
        '  Response.Redirect("WebPortal/Account.aspx")
    End Sub

    Public Sub _GenerateReport_eOR(ByVal _send As String, ByVal TAXTYPE_eOR As String, ByVal eORNO As String, Optional ByRef xerr As String = Nothing)
        Try


            Dim _nclassEOR As New eOR
            Dim _nDataTable0 As New DataTable
            _nDataTable0 = _nclassEOR.Print_Template
            Dim _nDataTable1 As New DataTable
            _nDataTable1 = _nclassEOR.Print_Report(eORNO)
            Dim _nDataTable2 As New DataTable
            _nDataTable2 = _nclassEOR.Print_TOP(eORNO)

            Report_EOR.Reset()
            xerr += ";1:OK"

            '--------tomi (Shows only PDF as EXPORT Extension)-uneditable print format
            Dim info As FieldInfo

            For Each extension As RenderingExtension In Report_EOR.LocalReport.ListRenderingExtensions
                If extension.Name <> "PDF" Then
                    info = extension.[GetType]().GetField("m_isVisible", BindingFlags.Instance Or BindingFlags.NonPublic)
                    info.SetValue(extension, False)
                End If
            Next
            '--------END (Shows only PDF as EXPORT Extension)-uneditable print format

            xerr += ";2:OK"


            If TAXTYPE_eOR = "REAL PROPERTY TAX" Or TAXTYPE_eOR = "RPT" Then
                Report_EOR.LocalReport.ReportPath = _gResxRdlc.pEOR_RPT2
            ElseIf TAXTYPE_eOR = "BUSINESS PERMIT" Or TAXTYPE_eOR = "BP" Then
                Report_EOR.LocalReport.ReportPath = _gResxRdlc.pEOR_BP2
            End If

            Report_EOR.LocalReport.EnableExternalImages = False

            Report_EOR.LocalReport.DataSources.Clear()

            xerr += ";3:OK:" & TAXTYPE_eOR

            Dim _nReportDataSource0 As New ReportDataSource
            _nReportDataSource0.Name = "DataSet0"
            _nReportDataSource0.Value = _nDataTable0
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource0)

            Dim _nReportDataSource1 As New ReportDataSource
            _nReportDataSource1.Name = "DataSet1"
            _nReportDataSource1.Value = _nDataTable1
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource1)

            Dim _nReportDataSource2 As New ReportDataSource
            _nReportDataSource2.Name = "DataSet2"
            _nReportDataSource2.Value = _nDataTable2
            Report_EOR.LocalReport.DataSources.Add(_nReportDataSource2)

            xerr += ";4:OK:"

            Dim ds_TotalAmount As String
            For Each row As DataRow In _nDataTable2.Rows
                ds_TotalAmount += CDec(row("Amount"))
            Next

            Dim _eOr As New eOR
            Dim strAmount As String = Nothing
            strAmount = _eOr.AmountInWords(ds_TotalAmount)

            Dim paramList As New List(Of ReportParameter)
            paramList.Add(New ReportParameter("AmountInWords", strAmount.ToUpper))

            Report_EOR.LocalReport.SetParameters(paramList)

            Report_EOR.AsyncRendering = True
            Report_EOR.LocalReport.Refresh()
            Report_EOR.Enabled = True

            xerr += ";5:OK:"

            If _send = 1 Then
                Dim bytes As Byte() = Report_EOR.LocalReport.Render("PDF")
                Dim sent As Boolean = False
                Dim err As String = Nothing
                Dim body As String

                Dim StrBillAmount As String = IIf(_nDataTable1.Rows(0)("Bill_Amount") = Nothing, "0.00", _nDataTable1.Rows(0)("Bill_Amount").ToString)

                Dim DecBillAmount As Decimal

                Dim FormattedAmount

                If Decimal.TryParse(StrBillAmount, DecBillAmount) Then
                    FormattedAmount = DecBillAmount.ToString("C")
                End If



                body = "Dear Valued Tax Payer, <br> " & _
                       "This confirms your bill payment transaction with the following details: <br> " & _
                       "Transaction Number: " & _nDataTable1.Rows(0)("OnlineId") & "<br>" & _
                       "Transaction Type: " & _nDataTable1.Rows(0)("TaxType") & " Payment<br>" & _
                       "Account No. : " & _nDataTable1.Rows(0)("TDNBIN") & "<br>" & _
                       "Amount Paid : " & FormattedAmount.ToString.Replace("$", "PHP ") & "<br> <br>" & _
                       "Your Electronic Official Receipt is attached in this e-mail."

                cDalNewSendEmail.Send_eOR(eOR.TaxPayerEmail, "Electronic Official Receipt", body, bytes, sent, err)
                If String.IsNullOrEmpty(err) = True Then
                    eOR.Update_Sent(_nDataTable1.Rows(0)("eORNO"), err)

                    ' ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully')", True)
                    Exit Sub
                End If

                'If sent = True Then
                '    Response.Clear()
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('E-OR Sent Successfully');", True)
                'Else
                '    ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + err + "');", True)
                'End If

            End If

            xerr += ";6:_send:" & _send
            xerr += ";END"

        Catch ex As Exception
            xerr += ex.Message
            ClientScript.RegisterStartupScript(Me.GetType(), "myScript", "window.alert('" + ex.Message + "');", True)
        End Try


    End Sub
    Public Sub START_POSTING(ByRef err As String, Optional ByRef eORNO As String = Nothing, Optional ByVal isTaxpayer As Boolean = Nothing, Optional ByVal gatewayRefNo As String = Nothing, Optional ByRef strChecker As String = Nothing)
        Dim qry As String = Nothing
        Dim rand As New Random() ' Create a new instance of the Random class    
        Task.Delay((rand.Next(1, 10)) * 1000).Wait()

        _1PostPayment(err, eORNO, strChecker)
        '    Response.Write(strChecker)
        If String.IsNullOrEmpty(err) = False Then
            Response.Write(";_1PostPayment:" & err)
            Exit Sub
        Else
            _2GetPostedDetails(err, eORNO, gatewayRefNo)

            If String.IsNullOrEmpty(err) = False Then
                Response.Write(";_2GetPostedDetails:" & err)
                Exit Sub
            End If
        End If
        'Dim HomeURL As String
        If isTaxpayer = True Then
            Exit Sub
        Else
            ' _GenerateReport_eOR(1, Process.TransactionType, eORNO)
            ' _3GenerateEORReport()
        End If

    End Sub





End Class