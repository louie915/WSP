Public Class UserAccountManagement
    Inherits System.Web.UI.Page
    Dim usertmp As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Get_UserAccount_Data()
            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")


                If action = "EditRecord" Then
                    cDalUserAccountManagement._pSelected_IDNO = Request("__EVENTARGUMENT")
                    Response.Redirect("UserAccountManagementCU.aspx")
                End If

                If action = "DeleteRecord" Then
                    cDalUserAccountManagement._pSelected_IDNO = Request("__EVENTARGUMENT")
                End If
                If action = "ConfirmDelete" Then
                    Confirm_Click()
                    Response.Redirect("UserAccountManagement.aspx")
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub Get_UserAccount_Data()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = GV_UserAccount
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalUserAccountManagement
            _nClass._pCxn = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDt

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()

                Else
                    ' snackbar("red", "No Records Found.")
                End If
                '----------------------------------
            Catch ex As Exception
                'snackbar("red", "Transaction : " & ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try

    End Sub

    Sub Get_TaxPayers()
        Try
            '----------------------------------

            Dim _nGridView As New GridView
            _nGridView = GV_TaxPayer
            _nGridView.DataSourceID = Nothing

            Dim _nClass As New cDalUserAccountManagement
            _nClass._pCxn = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubSelect()

            Dim _nDataTable As New DataTable
            _nDataTable = _nClass._pDt

            Try
                '----------------------------------
                If _nDataTable.HasErrors Then
                    'Griderr = True
                    '_mSubShowBlank()
                End If

                If _nDataTable.Rows.Count > 0 Then
                    _nGridView.DataSource = _nDataTable
                    _nGridView.DataBind()

                Else
                    ' snackbar("red", "No Records Found.")
                End If
                '----------------------------------
            Catch ex As Exception
                'snackbar("red", "Transaction : " & ex.Message)
                'GridErr = True
                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception



        End Try

    End Sub
    Public Function UserLevel_Value_Filter(ByVal UserLevel As String) As String
        Dim value = UserLevel
        Select Case UserLevel
            Case ""
                value = "Not Assigned"
            Case "1"
                value = "User"
            Case "100"
                value = "Administrator"
        End Select
        Return value
    End Function

    Public Function Office_Value_Filter(ByVal Office As String) As String
        Dim value = Office
        Select Case Office
            Case ""
                value = "Not Assigned"            
        End Select
        Return value
    End Function



    Private Sub Confirm_Click()
        Try                        
            Dim _nClass As New cDalUserAccountManagement
            _nClass._pCxn = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubDelete()
            'snackbar("green", "Profile changes successfully saved")
        Catch ex As Exception
            'snackbar("red", "Error on saving profile changes")
        End Try
    End Sub

    Private Sub btnDelete_ServerClick(sender As Object, e As EventArgs) Handles btnDelete.ServerClick
        cDalUserAccountManagement._pSelected_IDNO = hdnID.Value
        Confirm_Click()
        Get_UserAccount_Data()
        Response.Write("<script>alert('Delete Success');</script>")
    End Sub
End Class