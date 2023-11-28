
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.Services
Imports System.Collections
Imports System.Data.SqlClient
Imports VB.NET.Methods
Imports System.IO
Imports System.Data
Imports System.Configuration
Imports System.Net

Public Class AppointmentSetup
    Inherits System.Web.UI.Page

    <WebMethod>
    Public Shared Function GetEvents() As IList
        Dim events As IList = New List(Of [Event])()
        Dim i As Integer = 0
        Dim _nSqlCommand As SqlCommand
        Dim _nDataTable As DataTable
        Dim _nQuery As String = Nothing
        Dim colorselected
        Dim eventselected = cSessionLoader._pSelectedEventID
        Dim Office = cSessionLoader._pSelectedDepartment
        If Office = Nothing Then Office = "BPLO"

        _nQuery = "Select *,getdate() as dnow from AppointmentSlot WHERE OFFICE='" & Trim(Office) & "'  ORDER BY APPDATE"
        Try
            _nSqlCommand = New SqlCommand(_nQuery, cGlobalConnections._pSqlCxn_OAIMS)
            Dim _nSqlDataAdapter As New SqlDataAdapter(_nSqlCommand)
            _nDataTable = New DataTable
            _nSqlDataAdapter.Fill(_nDataTable)

            Dim _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
            For Each row In _nDataTable.Rows
                If _nSqlDr.HasRows Then
                    Do While _nSqlDr.Read()
                        Dim a As Date
                        Dim b As Date
                        Dim d As String
                        Dim m As String
                        If d < 10 Then d = 0 & d
                        If m < 10 Then m = 0 & m
                        Dim y As String
                        Dim EvId As String
                        Dim EvIdAM As String
                        Dim EvIdPM As String
                        Try
                            a = Format(_nSqlDr.Item("AppDate"), "MM-dd-yyyy")
                            b = Format(_nSqlDr.Item("dnow"), "MM-dd-yyyy")
                            d = _nSqlDr.Item("AppDate").day
                            m = _nSqlDr.Item("AppDate").month
                            y = _nSqlDr.Item("AppDate").year
                            EvId = m & d & y
                            EvIdAM = EvId & "AM"
                            EvIdPM = EvId & "PM"
                            err.strERR += ";GetEvents [Declaration] : OK"
                            err.strERR += ";a : " & a
                            err.strERR += ";b : " & b
                            err.strERR += ";d : " & d
                            err.strERR += ";m : " & m
                            err.strERR += ";y : " & y
                        Catch ex As Exception
                            err.strERR += ";GetEvents [Declaration] : " & ex.Message
                        End Try

                        If a < b Then
                            colorselected = "#666669" ' Gray for Past Dates
                        Else
                            colorselected = "#5070DA" ' Blue
                        End If

                        Try
                            If _nSqlDr.Item("AM_Slot") > 0 Then
                                events.Add(New [Event] With {
                                .EventID = EvId & "AM",
                                .EventName = "AM Slots " & _nSqlDr.Item("AM_Slot"),
                                .StartDate = _nSqlDr.Item("AppDate").ToString,
                                .EndDate = _nSqlDr.Item("AppDate").ToString,
                                 .Color = colorselected
                            })

                            End If

                            err.strERR += ";GetEvents [_nSqlDr.Item(AM_Slot)] : OK"
                        Catch ex As Exception
                            err.strERR += ";GetEvents [_nSqlDr.Item(AM_Slot)] : " & ex.Message
                        End Try



                        If a < b Then
                            colorselected = "#666669" ' Gray for Past Dates
                        Else
                            colorselected = "#5070DA" ' Blue
                        End If

                        Try
                            If _nSqlDr.Item("PM_Slot") > 0 Then
                                events.Add(New [Event] With {
                          .EventID = EvId & "PM",
                          .EventName = "PM Slots " & _nSqlDr.Item("PM_Slot"),
                          .StartDate = _nSqlDr.Item("AppDate").ToString,
                          .EndDate = _nSqlDr.Item("AppDate").ToString,
                           .Color = colorselected
                           })
                            End If
                            err.strERR += ";GetEvents [_nSqlDr.Item(PM_Slot)] : OK"
                        Catch ex As Exception
                            err.strERR += ";GetEvents [_nSqlDr.Item(PM_Slot)] : " & ex.Message
                        End Try





                    Loop
                    Return events
                Else
                    Return events
                End If
            Next

        Catch ex As Exception
            err.strERR += ";GetEvents() : " & ex.Message

        End Try


        'Using _nSqlDr As SqlDataReader = _nSqlCommand.ExecuteReader
        '    _nSqlDr.Read()
        '    If _nSqlDr.HasRows Then
        '        Do While _nSqlDr.Read()
        '            Dim a As Date = Format(_nSqlDr.Item("AppDate"), "MM-dd-yyyy")
        '            Dim b As Date = Format(Date.Now, "MM-dd-yyyy")
        '            If a >= b Then
        '                Dim d As String = _nSqlDr.Item("AppDate").day
        '                Dim m As String = _nSqlDr.Item("AppDate").month
        '                If d < 10 Then d = 0 & d
        '                If m < 10 Then m = 0 & m
        '                Dim y As String = _nSqlDr.Item("AppDate").year
        '                Dim EvId As String = m & d & y
        '                Dim EvIdAM As String = EvId & "AM"
        '                Dim EvIdPM As String = EvId & "PM"

        '                If EvIdAM = cSessionLoader._pSelectedEventID Then
        '                    colorseleced = "green"
        '                Else
        '                    colorseleced = "#5070DA"
        '                End If

        '                events.Add(New [Event] With {
        '               .EventID = EvId & "AM",
        '               .EventName = "AM Slots " & _nSqlDr.Item("AM_Slot"),
        '               .StartDate = _nSqlDr.Item("AppDate").ToString,
        '               .EndDate = _nSqlDr.Item("AppDate").ToString,
        '                .Color = colorseleced
        '           })

        '                If EvIdPM = cSessionLoader._pSelectedEventID Then
        '                    colorseleced = "green"
        '                Else
        '                    colorseleced = "#5070DA"
        '                End If

        '                events.Add(New [Event] With {
        '               .EventID = EvId & "PM",
        '               .EventName = "PM Slots " & _nSqlDr.Item("PM_Slot"),
        '               .StartDate = _nSqlDr.Item("AppDate").ToString,
        '               .EndDate = _nSqlDr.Item("AppDate").ToString,
        '                .Color = colorseleced
        '                })

        '            End If
        '        Loop
        '        Return events
        '    Else
        '        Return events
        '    End If
        'End Using
    End Function
    Public Class [Event]
        Public Property EventID As String
        Public Property EventName As String
        Public Property StartDate As String
        Public Property EndDate As String
        Public Property Color As String
        Public Property ImageType As Integer
        Public Property Url As String
    End Class

    Public Class err
        Public Shared strERR As String

    End Class

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '----------------------------------
            If Not IsPostBack Then

                If String.IsNullOrEmpty(cSessionUser._pUserID()) Then
                    Response.Redirect("Register.aspx")
                End If

                Dim dateFrom As String = Request.Form("dateFrom")
                Dim dateTo As String = Request.Form("dateTo")
                Dim Department As String = cSessionLoader._pSelectedDepartment
                Dim dateTime As String = Request.Form("dateTime")
                Dim submitClick As String = Request.Form("hdnClick")


                If submitClick = "TRUE" Then
                    Dim Beg_AM_Slot As Integer = Request.Form("AM_Slot")
                    Dim AM_Slot As Integer = Request.Form("AM_Slot")
                    Dim Beg_PM_Slot As Integer = Request.Form("PM_Slot")
                    Dim PM_Slot As Integer = Request.Form("PM_Slot")
                    Dim DayCondition As String = Request.Form("WeekEnds")

                    Try
                        Dim _nClass As New cDalAppointment
                        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                        _nClass._pSubInsertAAppointment(dateFrom, dateTo, dateTime, Department, Beg_AM_Slot, AM_Slot, Beg_PM_Slot, PM_Slot, DayCondition)
                        err.strERR += ";_pSubInsertAAppointment : OK"
                    Catch ex As Exception
                        err.strERR += ";_pSubInsertAAppointment : " & ex.Message
                    End Try
                End If


                Get_Department()
                cSessionLoader._pSelectedDepartment = Department
            Else
                Dim action = Request("__EVENTTARGET")
                Dim val = Request("__EVENTARGUMENT")
                cSessionLoader._pSelectedDepartment = Trim(val)
                cmbDepartment.SelectedIndex = action



            End If
            '----------------------------------
        Catch ex As Exception
            err.strERR += ex.Message
        End Try

        _Err.Value = err.strERR
    End Sub


    Sub Get_Department()
        Try
            '----------------------------------
            cmbDepartment.DataSourceID = Nothing
            cmbDepartment2.DataSourceID = Nothing
            Dim _nClass As New cDalAppointment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            Try
                _nClass._pSubGetDepartment()
                err.strERR += ";_pSubGetDepartment : OK"
            Catch ex As Exception
                err.strERR += ";_pSubGetDepartment : " & ex.Message
            End Try



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
                cmbDepartment2.Items.Insert(0, New ListItem("Select", ""))
                err.strERR += ";cmbDepartment : OK"
                '----------------------------------
            Catch ex As Exception
                err.strERR += ";cmbDepartment : " & ex.Message
            End Try
            '----------------------------------

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



    Private Sub cmbDepartment_ServerChange(sender As Object, e As EventArgs) Handles cmbDepartment.ServerChange
        cSessionLoader._pSelectedDepartment = cmbDepartment.Value
    End Sub

 

    Private Sub btnSaveChanges_ServerClick(sender As Object, e As EventArgs) Handles btnSaveChanges.ServerClick
        Dim _nClass As New cDalAppointment
        Dim _AM_SLOT As Integer
        Dim _PM_SLOT As Integer
        Dim _Exists As Boolean

        Try
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            _nClass._pSubGetSpecificDate(_date.Value, cmbDepartment2.Value, _AM_SLOT, _PM_SLOT, _Exists)
            If _Exists = True Then
                _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
                _nClass._pSubUpdateSpecificSlot(_date.Value, cmbDepartment2.Value, AM_Slot2.Value, PM_Slot2.Value)
                snackbar("green", "Update Success")
            Else
                snackbar("red", "No Available Slots Found")
            End If

            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal();", True)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnGetSlot_ServerClick(sender As Object, e As EventArgs) Handles btnGetSlot.ServerClick
        Dim _AM_SLOT As Integer
        Dim _PM_SLOT As Integer
        Dim _Exists As Boolean
        Dim _nClass As New cDalAppointment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubGetSpecificDate(_date.Value, cmbDepartment2.Value, _AM_SLOT, _PM_SLOT, _Exists)
        If _Exists = True Then
            AM_Slot2.Value = _AM_SLOT
            PM_Slot2.Value = _PM_SLOT
        Else
            snackbar("red", "No Available Slots Found")
            AM_Slot2.Value = 0
            PM_Slot2.Value = 0
        End If

        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal();", True)
    End Sub

    Private Sub _date_ServerChange(sender As Object, e As EventArgs) Handles _date.ServerChange
        Dim _AM_SLOT As Integer
        Dim _PM_SLOT As Integer
        Dim _Exists As Boolean
        Dim _nClass As New cDalAppointment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
        _nClass._pSubGetSpecificDate(_date.Value, cmbDepartment2.Value, _AM_SLOT, _PM_SLOT, _Exists)
        If _Exists = True Then
            AM_Slot2.Value = _AM_SLOT
            PM_Slot2.Value = _PM_SLOT
        Else
            snackbar("red", "No Available Slots Found")
            AM_Slot2.Value = 0
            PM_Slot2.Value = 0
        End If

        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "popup", "openModal();", True)

    End Sub
End Class