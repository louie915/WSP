Public Class certification
    Inherits System.Web.UI.Page

    Public Shared fName As String
    Public Shared mName As String
    Public Shared lName As String
    Public Shared suffix As String
    Public Shared email As String
    Public Shared gender As String
    Public Shared contactNo As String
    Public Shared address As String

    Private CertRate As Integer = 100

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nClass As New cDalProfileLoader
        _nClass._pEmail = cSessionUser._pUserID
        _nClass._pSqlCon = cGlobalConnections._pSqlCxn_OAIMS
        _nClass.loadProfile()

        email = cSessionUser._pUserID
        fName = _nClass._pFirstName + " " + _nClass._pMiddleName + " " + _nClass._pLastName + " " + _nClass._pExt
        gender = _nClass._pGender
        contactNo = _nClass._pContactNumber2
        address = _nClass._pAddress
    End Sub

    Public ReadOnly Property pFName As String
        Get
            Return fName
        End Get
    End Property

    Public ReadOnly Property pMName As String
        Get
            Return mName
        End Get
    End Property

    Public ReadOnly Property pLName As String
        Get
            Return lName
        End Get
    End Property

    Public ReadOnly Property pSuffix As String
        Get
            Return suffix
        End Get
    End Property

    Public ReadOnly Property pEmail As String
        Get
            Return email
        End Get
    End Property

    Public ReadOnly Property pGender As String
        Get
            Return gender
        End Get
    End Property

    Public ReadOnly Property pContactNo As String
        Get
            Return contactNo
        End Get
    End Property

    Public ReadOnly Property pAddress As String
        Get
            Return address
        End Get
    End Property

    Public ReadOnly Property pAmount As Integer
        Get
            Return CertRate
        End Get
    End Property

    Private Sub _oBtnNext_ServerClick(sender As Object, e As EventArgs) Handles _oBtnNext.ServerClick
        Try

            If _oTextFirstName.Value = "" Then
                snackbar("red", "Please enter your fullname")
            ElseIf _oTextEmail.Value = "" Then
                snackbar("red", "Please enter your email")
            ElseIf oSelectGender.Value = "" Then
                snackbar("red", "Please enter your gender")
            ElseIf _oTextAddress.Value = "" Then
                snackbar("red", "Please enter your address")
            End If

            Dim _nClass As New cDalCertificationAss
            Dim delfee As String = Nothing
            Dim totAmt As String = Nothing
            Dim serviceType As String = Nothing
            Dim type As String = Nothing

            If checkedDelFee.Value = "true" Then
                delfee = 250
                totAmt = totAmount.Value - delfee
            Else
                delfee = 0
                totAmt = totAmount.Value
            End If

            If checkSwitch.Value = "BP" Then
                cDalCertificationAss._pSqlCon = cGlobalConnections._pSqlCxn_BPLTIMS
                cDalCertificationAss._pBIN = "NONE"
                serviceType = "Certificate of No Business"
                type = "CertBP"
            ElseIf checkSwitch.Value = "RPT" Then
                cDalCertificationAss._pSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
                cDalCertificationAss._pTDN = "NONE"
                serviceType = "Certificate of No Property"
                type = "CertRPT"
            End If

            cDalCertificationAss._pFullname = _oTextFirstName.Value
            cDalCertificationAss._pEmail = _oTextEmail.Value
            cDalCertificationAss._pGender = oSelectGender.Value
            cDalCertificationAss._pContactNo = _oTextContactNumber.Value
            cDalCertificationAss._pAddress = _oTextAddress.Value
            cDalCertificationAss._pNoOfCopies = Val(noOfCop.Value)
            cDalCertificationAss._pAmount = totAmt
            cDalCertificationAss._pDelFee = delfee
            cDalCertificationAss._pCertType = "0000"
            cDalCertificationAss._pStatus = "Pending"

            cDalCertificationAss.saveCertRequestNoRPBP(checkSwitch.Value)
            cDalCertificationAss.updateNoBPRPTCertificate(checkSwitch.Value)

            cSessionLoader._pType = serviceType
            cSessionLoader._pService = type
            cSessionLoader._pUniqueID = cDalCertificationAss._pUnique
            cSessionLoader._pTotalAmountDue = CDbl(totAmt) + CDbl(delfee)
            Response.Redirect("Paynow.aspx")

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