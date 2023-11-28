Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Public Class BP_RequirementsSetup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Load_GridView()
            End If
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

    Sub Load_GridView()
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            If _nClass._pSubCheckIfTableExist("BP_Requirements") = False Then
                _nClass._pSubCreateTable("BP_Requirements")
            End If
            Dim TypeFilter As String = cmbTypeFilter.Value
            Dim CompliantFilter As String = cmbCompliantFilter.Value
            Dim SortByFilter As String = cmb_SortBy.Value
            Dim OrderFilter As String = cmb_Order.Value
            Dim OfficeFilter As String = cmbOFFICEFilter.Value

            _GVRequirements.DataSource = _nClass.Get_WebRequirements(TypeFilter, CompliantFilter, SortByFilter, OrderFilter, OfficeFilter)
            _GVRequirements.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Public Function Generate_ReqCode() As String
        Dim ReqCode As String = Nothing
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            ReqCode = _nClass.Generate_ReqCode()
        Catch ex As Exception

        End Try
        Return ReqCode
    End Function

    Private Sub btnFilter_ServerClick(sender As Object, e As EventArgs) Handles btnFilter.ServerClick
        Try
            Load_GridView()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveAdd_ServerClick(sender As Object, e As EventArgs) Handles btnSaveAdd.ServerClick
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._BPRequirements("Add", _nClass.Generate_ReqCode(), cmb_addType.value, cmb_AddCompliant.value, txt_AddDesc.value)
            clear()
            Load_GridView()
            snackbar("green", "Record Added Successfully")
        Catch ex As Exception
            snackbar("red", "Failed to Add Record")
        End Try
    End Sub

    Private Sub btnEditSave_ServerClick(sender As Object, e As EventArgs) Handles btnEditSave.ServerClick
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._BPRequirements("Edit", hdn_Code.Value, cmb_EditType.Value, cmb_EditCompliant.Value, txt_EditDesc.Value)
            clear()
            Load_GridView()
            snackbar("green", "Record Updated Successfully")
        Catch ex As Exception
            snackbar("red", "Failed to Edit Record")
        End Try
    End Sub

    Private Sub btnRemove_ServerClick(sender As Object, e As EventArgs) Handles btnRemove.ServerClick
        Try
            Dim _nClass As New cDalBPSOS
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            _nClass._BPRequirements("Delete", hdn_Code.Value, hdn_Type.Value, hdn_Compliant.Value, hdn_DelDesc.Value)
            clear()
            Load_GridView()
            snackbar("green", "Record Removed Successfully")
        Catch ex As Exception
            snackbar("red", "Failed to Remove Record")
        End Try
    End Sub
    Sub clear()
        hdn_Code.Value = Nothing
        lbl_DelType.InnerText = Nothing
        lbl_DelCompliant.InnerText = Nothing
        lbl_DelDesc.InnerText = Nothing
        cmb_EditType.Value = Nothing
        cmb_EditCompliant.Value = Nothing
        txt_EditDesc.Value = Nothing
        cmb_AddType.Value = Nothing
        cmb_AddCompliant.Value = Nothing
        txt_AddDesc.Value = Nothing
    End Sub
End Class