Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Imports System.IO
Imports RestSharp
Imports System.Web.Script.Serialization
Imports System.Web.HttpContext
Imports System.Data.SqlClient

Public Class PayNow2
    Inherits System.Web.UI.Page
    'Public Shared RawAmount As String
    'Public Shared SpidcFEE As String
    'Public Shared OtherFee As String
    'Public Shared TotalAmount As String
    'Public Shared LNAME As String
    'Public Shared FNAME As String
    'Public Shared MNAME As String
    'Public Shared SUFFIX As String
    'Public Shared BillingValidityDate As String
    'Public Shared Email As String 'PAYOR EMAIL
    'Public Shared SpidcRefNo As String 'TXNREFNO
    'Public Shared ACCTNO As String ' BIN, TDN , Account Number
    'Public Shared TransactionType As String 'RPT, BP, OBO, LCR, MISC
    'Public Shared Gateway_Selected As String 'LBP1, LBP2, DBP, OTC, PAYMAYA, PAYMAYA2, GCASH, ITBS, SPIDCPAY
    'Public Shared URL_Origin As String 'URL BEFORE FORM POST

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
    Private Const _sscACCTNO As String = _sscPrefix & "_sscACCTNO"
    Private Const _sscTransactionType As String = _sscPrefix & "_sscTransactionType"
    Private Const _sscGateway_Selected As String = _sscPrefix & "_sscGateway_Selected"
    Private Const _sscURL_Origin As String = _sscPrefix & "_sscURL_Origin"
    Private Const _sscOwnerName As String = _sscPrefix & "_sscOwnerName"
    Private Const _sscOwnerAddress As String = _sscPrefix & "_sscOwnerAddress"

#End Region

#Region "Properties"
    Shared Property OwnerAddress() As String
        Get
            Return Current.Session(_sscOwnerAddress)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOwnerAddress) = value
        End Set
    End Property
    Shared Property OwnerName() As String
        Get
            Return Current.Session(_sscOwnerName)
        End Get
        Set(ByVal value As String)
            Current.Session(_sscOwnerName) = value
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
            If Not IsPostBack Then
                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                    Exit Sub
                End If

                Dim _nClass As New cDalPayment
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                PayNow2.SpidcRefNo = _nClass.Generate_SPIDCREFNO(TransactionType)
                Load_PaymentOptions()
                '11/06/2023 Jay Sitjar 
                If CheckOutLoadCount() = 1 Then
                    PayNow2.SpidcRefNo = _nClass.Generate_SPIDCREFNO(TransactionType)
                    Load_PaymentSummary(1)
                Else
                    Load_PaymentSummary(2)
                End If
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

    '11/06/2023 Jay Sitjar 
    Public Function CheckOutLoadCount() As String
        ' Check if the "PageloadCount" Session variable exists
        If Session("PageloadCount") IsNot Nothing Then
            ' Increment the page load count
            Dim pageLoadCount As Integer = CInt(Session("PageloadCount"))
            pageLoadCount += 1
            Session("PageloadCount") = pageLoadCount
        Else
            ' If the Session variable doesn't exist, create it and set it to 1
            Session("PageloadCount") = 1
        End If

        ' The page load count is now stored in the "PageloadCount" Session variable
        Dim loadCount As Integer = CInt(Session("PageloadCount"))
        Return loadCount
    End Function


    Sub Load_PaymentOptions()
        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        cmb_PaymentOptions.Items.Clear()
        cmb_PaymentOptions.DataSource = _nClass.Get_PaymentOptions()
        cmb_PaymentOptions.DataTextField = "GatewayName"
        cmb_PaymentOptions.DataValueField = "Code"
        cmb_PaymentOptions.DataBind()
        cmb_PaymentOptions.Items.Insert(0, New ListItem("Select", "", True))
    End Sub
    Sub Gateway_Changed()
        Try
            Dim _nClass As New cDalPayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            Dim code As String = cmb_PaymentOptions.SelectedValue
            _nClass.Get_GatewayFee(code, OtherFee, SpidcFEE)
            Load_PaymentSummary(True)
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_PaymentSummary(Optional ByVal PageLoadCount As String = Nothing)
        'CHEAT HERE
        'RawAmount = 1
        '11/06/2023 JAY SITJAR
        'Optional ByVal PageLoadCount As String = Nothing
        '  Sub Load_PaymentSummary(Optional ChangeGateway As Boolean = False) Original in Parameters Optional ChangeGateway As Boolean = False
        Dim ChangeGateway As Boolean = False

        Dim _nClass As New cDalPayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        Dim _acctno As String
        _nClass._pSubGetACCTNO(SpidcRefNo, _acctno)
        Dim PercentageFee_GW As String = Nothing
        Dim PercentageFee_SPIDC As String = Nothing
        If SpidcFEE.Contains("%") Then
            PercentageFee_SPIDC = " (" & SpidcFEE & ")"
            SpidcFEE = RawAmount * (CDbl(SpidcFEE.Replace("%", "")) / 100)
        End If

        If OtherFee.Contains("%") Then
            PercentageFee_GW = " (" & OtherFee & ")"
            OtherFee = RawAmount * (CDbl(OtherFee.Replace("%", "")) / 100)
        End If

        RawAmount = FormatNumber(RawAmount, 2)
        SpidcFEE = FormatNumber(SpidcFEE, 2)
        OtherFee = FormatNumber(OtherFee, 2)
        TotalAmount = CDbl(RawAmount) + CDbl(SpidcFEE) + CDbl(OtherFee)
        TotalAmount = FormatNumber(TotalAmount, 2)
        PayNow2.TotalAmount = TotalAmount

        If ChangeGateway = True Then
            _nClass.Update_Transaction("FeeAmountSPIDC", SpidcFEE, "TXNREFNO", SpidcRefNo)
            _nClass.Update_Transaction("FeeAmount", OtherFee, "TXNREFNO", SpidcRefNo)
            _nClass.Update_Transaction("TotAmount", TotalAmount, "TXNREFNO", SpidcRefNo)
        Else
            '11/06/2023 JAY SITJAR
            'Check If Page is Second Load 
            If PageLoadCount = 2 Then
                'Do Nothing
            Else
                'If Not Second Load Insert new transacton 
                Dim err As String = Nothing
                _nClass.Insert_Transaction(SpidcRefNo, ACCTNO, TransactionType, RawAmount, TotalAmount, OtherFee, SpidcFEE, err)
                If String.IsNullOrEmpty(err) = False Then
                    hdnErr.Value = err
                End If

            End If
        End If



        txt_SPIDCREFNO.Value = SpidcRefNo
        txt_ACCTNO.Value = ACCTNO
        txt_TransactionType.Value = TransactionType
        txt_BillingValidityDate.Value = BillingValidityDate
        txt_Email.Value = Email
        txt_LName.Value = LNAME
        txt_Fname.Value = FNAME
        txt_Mname.Value = MNAME
        txt_Suffix.Value = SUFFIX
        txt_URL_Origin.Value = URL_Origin
        lbl_OtherFee.InnerText = OtherFee & PercentageFee_GW
        lbl_RawAmount.InnerText = RawAmount
        lbl_SPIDCFEE.InnerText = SpidcFEE & PercentageFee_SPIDC
        lbl_TotalAmount.InnerText = TotalAmount
    End Sub


    Sub PROCEED()

        'eOR.SPIDC_RefNo = Nothing
        'eOR.Gateway = Nothing
        'eOR.Gateway_RefNo = Nothing
        'eOR.Gateway_ConfDate = Nothing
        'eOR.Gateway_Fee = Nothing
        'eOR.SPIDC_Fee = Nothing
        'eOR.Bill_Amount = Nothing
        'eOR.GrandTotal = Nothing
        'eOR.AssessNo = Nothing

        'Process.RawAmount = Nothing
        'Process.SpidcFEE = Nothing
        'Process.OtherFee = Nothing
        'Process.TotalAmount = Nothing
        'Process.LNAME = Nothing
        'Process.FNAME = Nothing
        'Process.MNAME = Nothing
        'Process.SUFFIX = Nothing
        'Process.BillingValidityDate = Nothing
        'Process.Email = Nothing
        'Process.SpidcRefNo = Nothing
        'Process.ACCTNO = Nothing
        'Process.TransactionType = Nothing
        'Process.Gateway_Selected = Nothing
        'Process.URL_Origin = Nothing

        ' Process.GatewayRefNo = PayNow2.RawAmount
        Process.RawAmount = PayNow2.RawAmount
        Process.SpidcFEE = PayNow2.SpidcFEE
        Process.OtherFee = PayNow2.OtherFee
        Process.TotalAmount = PayNow2.TotalAmount
        Process.LNAME = PayNow2.LNAME
        Process.FNAME = PayNow2.FNAME
        Process.MNAME = PayNow2.MNAME
        Process.SUFFIX = PayNow2.SUFFIX
        Process.BillingValidityDate = PayNow2.BillingValidityDate
        Process.Email = PayNow2.Email
        Process.SpidcRefNo = PayNow2.SpidcRefNo
        Process.ACCTNO = PayNow2.ACCTNO
        Process.TransactionType = PayNow2.TransactionType
        Process.Gateway_Selected = PayNow2.Gateway_Selected
        Process.URL_Origin = PayNow2.URL_Origin
        Process.OwnerName = PayNow2.OwnerName
        Process.OwnerAddress = PayNow2.OwnerAddress
        '   Response.Redirect("../Process.aspx")

        ' Dim baseUrl As String = Request.Url.Scheme + "://" + Request.Url.Host + Request.ApplicationPath.TrimEnd("/") + "/"
        Dim baseUrl As String = HttpContext.Current.Request.Url.AbsoluteUri.Split("//")(0).ToString & "//" & HttpContext.Current.Request.Url.Host & "/"
        URL_Origin = HttpContext.Current.Request.Url.AbsoluteUri
        Response.Clear()
        ' Response.Write("Redirecting to Payment Gateway, please wait...")

        Dim sb = New System.Text.StringBuilder()
        sb.Append("<html>")
        sb.AppendFormat("<body onload='document.forms[0].submit()'>")

        sb.AppendFormat(" <p>Redirecting to Payment Gateway in <span id='countdown'>20</span> seconds, please wait...: </p>")

        ' sb.AppendFormat("<body>                                     ")
        ' If HttpContext.Current.Request.Url.AbsoluteUri.ToUpper.Contains("TEST") = True Then
        '     sb.AppendFormat("<form action='{0}' method='post'>", "/TEST/Process.aspx")
        ' Else
        sb.AppendFormat("<form action='{0}' method='post'>", "../Process.aspx")
        '  End If
        '   sb.AppendFormat("<form action='{0}' method='post'>", baseUrl + "Process.aspx")
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='RawAmount' />", PayNow2.RawAmount)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='SpidcFEE' />", PayNow2.SpidcFEE)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='OtherFee' />", PayNow2.OtherFee)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='TotalAmount' />", PayNow2.TotalAmount)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='LNAME' />", PayNow2.LNAME)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='FNAME' />", PayNow2.FNAME)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='MNAME' />", PayNow2.MNAME)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='SUFFIX' />", PayNow2.SUFFIX)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='BillingValidityDate' />", PayNow2.BillingValidityDate)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='Email' />", PayNow2.Email)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='SpidcRefNo' />", PayNow2.SpidcRefNo)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='ACCTNO' />", PayNow2.ACCTNO)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='TransactionType' />", PayNow2.TransactionType)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='Gateway_Selected' />", PayNow2.Gateway_Selected)
        sb.AppendFormat("<input style='display:none' value='{0}' type='text' name='URL_Origin' />", URL_Origin)
        sb.AppendFormat("<input style='display:none' value='{0}' type='submit' name='btnSubmit' />", "Submit")
        sb.Append("</form>")


        sb.Append("  <script>")
        sb.Append(" function countdown() {")
        sb.Append(" var seconds = 20;")
        sb.Append(" var countdownElement = document.getElementById('countdown');")
        sb.Append(" var countdownInterval = setInterval(function() {")
        sb.Append(" countdownElement.textContent = seconds;")
        sb.Append(" seconds--;")
        sb.Append("  if (seconds < 0) {")
        sb.Append(" clearInterval(countdownInterval);")
        sb.Append(" countdownElement.textContent = 'Please Wait';")
        sb.Append(" }")
        sb.Append(" }, 1000);")
        sb.Append(" }")
        sb.Append("  </script>")

        sb.Append(" <script>")
        sb.Append(" countdown();")
        sb.Append(" </script>")

       


            sb.Append("</body>")
            sb.Append("</html>")
            Response.Write(sb.ToString())
            Response.[End]()

    End Sub
    Private Sub btn_Paynow_ServerClick(sender As Object, e As EventArgs) Handles btn_Paynow.ServerClick
        Try
            If String.IsNullOrEmpty(cmb_PaymentOptions.SelectedValue) Then
                snackbar("red", "Please Select Payment Option")
            Else
                PayNow2.Gateway_Selected = cmb_PaymentOptions.SelectedValue

                Dim qry As String = Nothing
                Dim err As String = Nothing

                Dim _nClass As New cDalPayment
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                If _nClass.IsTransactionExist("TXNREFNO", PayNow2.SpidcRefNo, qry, err) = False Then
                    _nClass.Insert_Transaction(SpidcRefNo, ACCTNO, TransactionType, RawAmount, TotalAmount, OtherFee, SpidcFEE, err)
                End If

                _nClass.Update_Transaction("PaymentChannel", PayNow2.Gateway_Selected, "TXNREFNO", PayNow2.SpidcRefNo, qry, err)
                _nClass.Update_Transaction("StatusID", "PENDING", "TXNREFNO", PayNow2.SpidcRefNo, qry, err)
                '   _nClass.Insert_History(PayNow2.SpidcRefNo, PayNow2.TransactionType, PayNow2.Gateway_Selected, PayNow2.ACCTNO, PayNow2.RawAmount, PayNow2.OtherFee, PayNow2.TotalAmount, PayNow2.SpidcFEE, "PENDING")
                _nClass.Insert_History2("PENDING")




                If PayNow2.Gateway_Selected = "GCASH" Then
                    GCash.PayorEmail = cSessionUser._pUserID
                    GCash.Amount = PayNow2.TotalAmount
                    GCash.TransType = PayNow2.TransactionType
                    GCash.SPIDCRefNo = PayNow2.SpidcRefNo
                    GCash.PaymentDesc = PayNow2.TransactionType & " Payment"
                    GCash.ACCTNO = PayNow2.ACCTNO


                    Response.Redirect("GCash.aspx")

                ElseIf PayNow2.Gateway_Selected = "PAYMAYA" Or PayNow2.Gateway_Selected = "PAYMAYA2" Then
                    _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
                    _nClass._pSubGetGatewayCredentials(PayNow2.Gateway_Selected)

                    PayMaya.PayorEmail = cSessionUser._pUserID
                    PayMaya.Amount = PayNow2.TotalAmount
                    PayMaya.TransType = PayNow2.TransactionType
                    PayMaya.SPIDCRefNo = PayNow2.SpidcRefNo
                    PayMaya.PaymentDesc = PayNow2.TransactionType & " Payment"
                    PayMaya.ACCTNO = PayNow2.ACCTNO
                    PayMaya.API_Type = "Create Checkout Payment - POST"
                    Response.Redirect("PayMaya.aspx")

                Else
                    PROCEED()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub snackbar(ByVal color As String, ByVal msg As String)
        Try
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "login", "ShowSnackBar('" & color & "','" & msg & "');", True)
        Catch ex As Exception

        End Try
    End Sub
End Class