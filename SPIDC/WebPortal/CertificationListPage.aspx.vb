Public Class CertificationListPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'cDalRPT_Cert._mCertType = "0001"
            'If cDalRPT_Cert._mCertType = "0001" Then
            '    _oLabelTypeOfCertification.InnerText = "Certified True Copy(Real Property)"
            'ElseIf cDalRPT_Cert._mCertType = "0002" Then
            '    _oLabelTypeOfCertification.InnerText = "Certificate of No Improvement(Real Property)"
            'ElseIf cDalRPT_Cert._mCertType = "0003" Then
            '    _oLabelTypeOfCertification.InnerText = "Certificate of ***"
            'End If
            Load_Record(cDalRPT_Cert._mCertType)

        Catch ex As Exception

        End Try
    End Sub

    Sub Load_Record(ByVal CertType As String)
        Try
            Dim _nClass As New cDalRPT_Cert
            cDalRPT_Cert._mSqlCon = cGlobalConnections._pSqlCxn_RPTIMS
            _nClass._pSubSelectCertRPT("")
            GridView4.DataSource = cDalRPT_Cert._mDataTable
            GridView4.DataBind()

            _nClass._pSubSelectRPT("0001")
            GridView5.DataSource = cDalRPT_Cert._mDataTable
            GridView5.DataBind()

            _nClass._pSubSelectRPT("0002")
            GridView6.DataSource = cDalRPT_Cert._mDataTable
            GridView6.DataBind()

            _nClass._pSubSelectRPT("0003")
            GridView7.DataSource = cDalRPT_Cert._mDataTable
            GridView7.DataBind()
        Catch ex As Exception

        End Try
    End Sub

End Class