Imports System.Drawing

Public Class RPTIMSCertification
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Get_Certifications()
            Get_RPTAccountCMB()
            Get_Status()
        End If
    End Sub
    Private Sub Get_Status()
        Try
            '----------------------------------
            Dim _nGridView As New GridView
            _nGridView = _oGridViewRequestStatus
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalRPTIMS_CERTGetStatus
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            _nClass._pUserAccountEmail = cCookieUser._pUserID
            _nClass._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDataTable

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    '  _mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()
                Else
                    ' _mSubShowBlank()
                End If
                '----------------------------------
            Catch ex As Exception
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception
            '   _mSubShowBlank()
        End Try

    End Sub
    Private Sub _oGridViewRequestStatus_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles _oGridViewRequestStatus.PageIndexChanging
        _oGridViewRequestStatus.PageIndex = e.NewPageIndex
        Get_Status()
    End Sub
    Protected Sub OnRowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = ClientScript.GetPostBackClientHyperlink(Me._oGridViewRequestStatus, "Select$" & e.Row.RowIndex)
        End If
    End Sub


    Protected Sub OnSelectedIndexChanged(sender As Object, e As EventArgs)
        For Each row As GridViewRow In _oGridViewRequestStatus.Rows
            If row.RowIndex = _oGridViewRequestStatus.SelectedIndex Then
                row.BackColor = ColorTranslator.FromHtml("#A1DCF2")
            Else
                row.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            End If
        Next
    End Sub

    Private Sub Get_RPTAccountCMB()
        Try
            '----------------------------------
            cmbRPTAccount.DataSourceID = Nothing

            Dim _nClass As New cDalBPLTIMS_CERTGetBusinessAccount
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pGetEmail = cCookieUser._pUserID
            _nClass._pSubSelect()

            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                cmbRPTAccount.DataSource = _nDataSet
                cmbRPTAccount.DataTextField = "Name"
                cmbRPTAccount.DataValueField = "TDN"
                cmbRPTAccount.DataBind()

                cmbRPTAccount.Items.Insert(0, New ListItem("Select Business", ""))



                '----------------------------------
            Catch ex As Exception
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Get_Certifications()
        Try
            '----------------------------------
            cmbCertifications.DataSourceID = Nothing

            Dim _nClass As New cDalRPTIMS_CERTGetCertification
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            _nClass._pSubSelect()


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then
                    'Shoiw Blank Table
                    '  _mSubShowBlank()
                End If

                cmbCertifications.DataSource = _nDataSet
                cmbCertifications.DataTextField = "CERTDESC"
                cmbCertifications.DataValueField = "CERTCODE"
                cmbCertifications.DataBind()

                cmbCertifications.Items.Insert(0, New ListItem("Select Certificate", ""))

                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Add_Request()

        Try
            '----------------------------------
            Dim _nClass As New cDalRPTIMS_CERTGetStatus
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            _nClass._pUserAccountEmail = cCookieUser._pUserID
            _nClass._pCertificateFor = "RPTAS"
            _nClass._pCertificateCode = txtSelectedCertificate.Value
            _nClass._pCertificateName = txtSelectedCertificateName.Value
            _nClass._pBusinessAccountNo = txtSelectedRPT.Value
            _nClass._pBusinessName = txtSelectedRPTName.Value
            _nClass._pRequestStatus = "Pending"
            _nClass._pRequestDate = Date.Today
            _nClass._pRequestRefNo = "xxxxxx"
            _nClass._pSubInsert()

        Catch ex As Exception

        End Try
        'add code to refresh table after adding record
    End Sub



End Class