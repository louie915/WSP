Imports System.Data.SqlClient

Public Class DepartmentSetup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                load_GridView()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AP_Save(DepartmentCode As String, Department As String, Usertype As String, Regulatory As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "insert into DEPARTMENT(DepartmentCode,Department,Usertype,Regulatory)" &
                " VALUES(@DepartmentCode,@Department,@Usertype,@Regulatory);"
            Dim _nSqlCon As SqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nSqlCommand As New SqlCommand(_nQuery, _nSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@DepartmentCode", DepartmentCode)
                .AddWithValue("@Department", Department)
                .AddWithValue("@Usertype", Usertype)
                .AddWithValue("@Regulatory", Regulatory)
            End With
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Sub load_GridView()
        Dim _nClass As New cDalAppointment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass.Get_Departments()
        gv_Department.DataSource = _nClass._mDataTable
        gv_Department.DataBind()
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


    Private Sub _obtnProceed_ServerClick(sender As Object, e As EventArgs) Handles _obtnProceed.ServerClick
        Try
            If String.IsNullOrEmpty(_oTxtDepartmentCode.Value) Then
                snackbar("red", "Missing Department Code")
                Exit Sub
            ElseIf String.IsNullOrEmpty(_oTxtDepartment.Value) Then
                snackbar("red", "Missing Description")
                Exit Sub
            ElseIf String.IsNullOrEmpty(_oTxtUsertype.Value) Then
                snackbar("red", "Missing User Type")
                Exit Sub

                'ElseIf _oTxtUsertype.Value.Length > 10 Then
                '    snackbar("red", "UserType must be less than 10 characters")
                '    Exit Sub
            End If

            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            If _nClass.isExists(_oTxtDepartmentCode.Value, _oTxtDepartment.Value, _oTxtUsertype.Value) = False Then
                '_nClass.Insert_Department(_nClass.Gen_DeptCode(), _oTxtDepartment.Value, _oTxtUsertype.Value, _oTxtRegulatory.Value)
                _nClass.Insert_Department(_oTxtDepartmentCode.Value, _oTxtDepartment.Value, _oTxtUsertype.Value, _oTxtRegulatory.Value)
                snackbar("green", "Record Saved!")
            Else
                snackbar("red", "Either Department Code or Department  already exists")
            End If

            load_GridView()
        Catch ex As Exception
            snackbar("red", ex.Message)
        End Try

    End Sub

    Private Sub btnRemove_ServerClick(sender As Object, e As EventArgs) Handles btnRemove.ServerClick
        Try
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.Remove_Department(hdnDepartmentCode.Value, hdnUsertype.Value)
            load_GridView()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEditSave_ServerClick(sender As Object, e As EventArgs) Handles btnEditSave.ServerClick
        Try
            If String.IsNullOrEmpty(Edit_Department.Value) Then
                snackbar("red", "Missing Description")
                Exit Sub
            ElseIf String.IsNullOrEmpty(Edit_Usertype.Value) Then
                snackbar("red", "Missing User Type")
                Exit Sub
            End If

            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            If _nClass.isExists(_oTxtDepartmentCode.Value, _oTxtDepartment.Value, _oTxtUsertype.Value) = False Then

                Dim _nQuery As String = Nothing
                _nQuery = "Update Department set [Department]='" & Edit_Department.Value.ToUpper & "' , [Usertype]='" & Edit_Usertype.Value.ToUpper & "' , [Regulatory]='" & Edit_Regulatory.Value & "'" &
                    " where [DepartmentCode]='" & hdnDepartmentCode.Value.ToUpper & "' and [UserType]='" & hdnUsertype.Value.ToUpper & "';"
                Dim _nSqlCon As SqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                Dim _nSqlCommand As New SqlCommand(_nQuery, _nSqlCon)
                _nSqlCommand.ExecuteNonQuery()

                snackbar("green", "Record Saved!")
                _nSqlCommand.Dispose()


            Else
                snackbar("red", "Either Department Code or Department  already exists")
            End If


         

        Catch ex As Exception

        End Try
        load_GridView()
    End Sub
End Class