Imports System.IO
Imports System.Data.SqlClient
Imports System.Data
Public Class AppointmentTypeSetup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Not IsPostBack Then
                Get_Department()
                Dim _nClass As New cDalAppointment
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                load_GridView(_nClass._pSubGetTOP1Department())
                'div_Reqs.InnerHtml = CreateReqTag("Sampalan", "chie;not;kalbo", "samplelang")                
            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")                
            End If



        Catch ex As Exception

        End Try
    End Sub

    Public Sub AP_Save(department As String, aptype As String, apheader As String, apfooter As String, aprequirements As String)
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "insert into [dbo].[AppointmentRequirements](department, type, header, body, footer, availability) VALUES(@department,@type,@header,@body,@footer,'1');"
            Dim _nSqlCon As SqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nSqlCommand As New SqlCommand(_nQuery, _nSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@department", department)
                .AddWithValue("@type", aptype)
                .AddWithValue("@header", apheader)
                .AddWithValue("@body", aprequirements)
                .AddWithValue("@footer", apfooter)
            End With
            _nSqlCommand.ExecuteNonQuery()
            '----------------------------------
        Catch ex As Exception

        End Try
    End Sub

    Sub load_GridView(ByVal Department As String)
        Dim _nClass As New cDalAppointment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass.Get_AppointmentTypes(Department)
        gv_AppointmentReq.DataSource = _nClass._mDataTable
        gv_AppointmentReq.DataBind()
    End Sub


    Sub Get_Department()
        Try
            '----------------------------------
            cmbDepartment.DataSourceID = Nothing
            cmbDepartment2.DataSourceID = Nothing

            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS

            _nClass._pSubGetDepartmentAppointmentType()


            Dim _nDataSet As New DataSet()
            _nDataSet = _nClass._pDataSet

            Try
                '----------------------------------
                If _nDataSet.HasErrors Then

                    '_mSubShowBlank()
                End If

                cmbDepartment.DataSource = _nDataSet
                cmbDepartment.DataTextField = "Department"
                cmbDepartment.DataValueField = "UserType"
                cmbDepartment.DataBind()
                cmbDepartment.Items.Insert(0, New ListItem("Select", ""))

                cmbDepartment2.DataSource = _nDataSet
                cmbDepartment2.DataTextField = "Department"
                cmbDepartment2.DataValueField = "UserType"
                cmbDepartment2.DataBind()

                '----------------------------------
            Catch ex As Exception

                '_mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Public Function CreateReqTag(body As String) As String
        Dim strArr() As String
        Dim Result As String = Nothing
        strArr = body.Split(";")
        'Result += "<span>" + header + "</span>"
        Result += "<ul id='list'>"
        For count As Integer = 0 To strArr.Length - 1
            'Console.WriteLine(strArr(count))
            Result += "<li>" + strArr(count) + "</li>"
        Next
        Result += "</ul>"
        'If footer IsNot Nothing Then Result += "<span>" + footer + "</span>"
        Return Result
    End Function

    Public Sub obtnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Dim btn As Button = CType(sender, Button)
        'CSession._pssubNo = btn.CommandArgument
        Try
            Dim _nQuery As String = Nothing
            _nQuery = "select * from AppointmentRequirements where department = @department and type = @type;"
            Dim _nSqlCon As SqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nSqlCommand As New SqlCommand(_nQuery, _nSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@department", cmbDepartment.Value)
                .AddWithValue("@type", _oTxtType.Value)
            End With
            _nSqlCommand.ExecuteNonQuery()
            Dim _nSqlDReader As SqlDataReader = _nSqlCommand.ExecuteReader
            If Not _nSqlDReader.HasRows Then AP_Save(cmbDepartment.Value, _oTxtType.Value, _oTxtHeader.Value, _oTxtFooter.Value, _ohdnAppType.Value) _
                  : snackbar("green", "Record Saved!") _
                Else snackbar("red", "Appointment type already exist!")
            _nSqlDReader.Close()
            _nSqlCommand.Dispose()            
        Catch ex As Exception

        End Try

        load_GridView(cmbDepartment.Value.ToUpper)
        div_Reqs.InnerHtml = "<a id='_opheader'></a><a id='_opbody'></a><a id='_opfooter'></a>"

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

    Private Sub cmbDepartment2_ServerChange(sender As Object, e As EventArgs) Handles cmbDepartment2.ServerChange
        load_GridView(cmbDepartment2.Value.ToUpper)
    End Sub


    Protected Sub Department2_OnChange(sender As Object, e As EventArgs)
        Try
            '      load_GridView(hdnDept2.Value.ToUpper)
        Catch ex As Exception

        End Try
    End Sub

 

    Private Sub _obtnProceed_ServerClick(sender As Object, e As EventArgs) Handles _obtnProceed.ServerClick
        Try
            If String.IsNullOrEmpty(cmbDepartment.Value) Then
                snackbar("red", "Missing Department")
                Exit Sub
            ElseIf String.IsNullOrEmpty(_oTxtType.Value) Then
                snackbar("red", "Missing Type")
                Exit Sub
            ElseIf String.IsNullOrEmpty(_oTxtHeader.Value) Then
                snackbar("red", "Missing Header")
                Exit Sub
            ElseIf String.IsNullOrEmpty(_oTxtTypeR.Value) Then
                snackbar("red", "Missing Requirements")
                Exit Sub
            ElseIf String.IsNullOrEmpty(_oTxtFooter.Value) Then
                snackbar("red", "Missing Footer")
                Exit Sub
            End If
            Dim _nQuery As String = Nothing
            _nQuery = "select * from AppointmentRequirements where department = @department and type = @type;"
            Dim _nSqlCon As SqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nSqlCommand As New SqlCommand(_nQuery, _nSqlCon)
            With _nSqlCommand.Parameters
                .AddWithValue("@department", cmbDepartment.Value)
                .AddWithValue("@type", _oTxtType.Value)
            End With
            _nSqlCommand.ExecuteNonQuery()
            Dim _nSqlDReader As SqlDataReader = _nSqlCommand.ExecuteReader
            If Not _nSqlDReader.HasRows Then AP_Save(cmbDepartment.Value, _oTxtType.Value, _oTxtHeader.Value, _oTxtFooter.Value, _ohdnAppType.Value) _
                  : snackbar("green", "Record Saved!") _
                Else snackbar("red", "Appointment type already exist!")
            _nSqlDReader.Close()
            _nSqlCommand.Dispose()
        Catch ex As Exception

        End Try
        cmbDepartment2.Value = cmbDepartment.Value
        load_GridView(cmbDepartment.Value.ToUpper)
        div_Reqs.InnerHtml = "<a id='_opheader'></a><a id='_opbody'></a><a id='_opfooter'></a>"

    End Sub

    Private Sub btnRemove_ServerClick(sender As Object, e As EventArgs) Handles btnRemove.ServerClick
        Try
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass.Remove_AppointmentTypes(hdnDepartment.Value, hdnType.Value)
            load_GridView(hdnDepartment.Value.ToUpper)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEditSave_ServerClick(sender As Object, e As EventArgs) Handles btnEditSave.ServerClick
        Try
            If String.IsNullOrEmpty(Edit_Type.Value) Then
                snackbar("red", "Missing Type")
                Exit Sub
            ElseIf String.IsNullOrEmpty(Edit_Header.Value) Then
                snackbar("red", "Missing Header")
                Exit Sub
            ElseIf String.IsNullOrEmpty(Edit_Body.Value) Then
                snackbar("red", "Missing Requirements")
                Exit Sub
            ElseIf String.IsNullOrEmpty(Edit_Footer.Value) Then
                snackbar("red", "Missing Footer")
                Exit Sub
            End If
            Dim _nQuery As String = Nothing
            _nQuery = "Update AppointmentRequirements set [Type] ='" & Edit_Type.Value & "' , [Header]='" & Edit_Header.Value & "' , [Body]='" & _ohdnAppType2.Value & "' , [Footer]='" & Edit_Footer.Value & "'" &
                " where [Department]='" & cmbDepartment2.Value & "' and [Type]='" & hdnType.Value & "';"
            Dim _nSqlCon As SqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Dim _nSqlCommand As New SqlCommand(_nQuery, _nSqlCon)
            _nSqlCommand.ExecuteNonQuery()

            snackbar("green", "Record Saved!")
            _nSqlCommand.Dispose()
        Catch ex As Exception

        End Try


        load_GridView(cmbDepartment2.Value.ToUpper)
        div_Reqs2.InnerHtml = "<a id='_opheader2'></a><a id='_opbody2'></a><a id='_opfooter2'></a>"
    End Sub
End Class