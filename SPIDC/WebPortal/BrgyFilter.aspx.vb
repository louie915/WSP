Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.IO
Imports VB.NET.Email
Imports System.Net.Mail
Imports System.Data
Imports System.Configuration
Imports System
Imports System.Text
Imports System.Security.Cryptography

Public Class BrgyFilter
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Session("BusBrgy") <> "" Or Session("BusBrgy") <> Nothing Then
                Get_Brgy("")
                Get_Street(Session("BusBrgy"))
                ' Load_Brgy("Where DistCode = '" & Session("BusDist") & "' and BrgyCode = '" & Session("BusBrgy") & "' ")
                'Get_BrgyDesc(Session("BusDist"), Session("BusBrgy"))
                'Get_StreetDesc(Session("BusDist"), Session("BusBrgy"))
                Slide_07_Brgy.Value = Session("BusBrgy")
                Slide_07_Street.Value = Session("BusStrt")
                Slide_07_Address.Value = Session("BusAddress")
            Else
                Get_Brgy("")


                Dim StrBrgyDist() As String
                StrBrgyDist = Slide_07_Brgy.Value.Split("_") 'Slide_07_Brgy.Value.Split("_")

                Get_Street(StrBrgyDist(1))
                'Get_Street(Right(Slide_07_Brgy.Value, 4))
            End If

            'If cLoaderNewBusinessApplication._pBusBrgy <> "" Or cLoaderNewBusinessApplication._pBusBrgy <> Nothing Then
            '    Get_Brgy("")
            '    Get_Street(Right(cLoaderNewBusinessApplication._pBusBrgy, 4))
            '    Slide_07_Brgy.Value = cLoaderNewBusinessApplication._pBusBrgy
            '    Slide_07_Street.Value = cLoaderNewBusinessApplication._pBusStrt
            '    Slide_07_Address.Value = cLoaderNewBusinessApplication._pBusAddress
            'Else
            '    Get_Brgy("")
            '    Get_Street(Right(Slide_07_Brgy.Value, 4))
            'End If

            'Get_Street()
        Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "FilterBrgy" Then

                Dim StrBrgyDist() As String
                StrBrgyDist = val.Split("_") 'Slide_07_Brgy.Value.Split("_")


                Get_Street(StrBrgyDist(1))
                Slide_07_Brgy.Value = val
                'Session("BusBrgy") = val


                'cLoaderNewBusinessApplication._pBusBrgy = val
            End If

            If action = "Redirect" Then
                If Left(val, 4) = "Back" Then
                    'cLoaderNewBusinessApplication._pBusBrgy = Slide_07_Brgy.Value
                    If val.Length = 4 Then
                        val = val + Session("BusStrt")
                    End If

                    Slide_07_Brgy.Value = Session("BusBrgy") ' Slide_07_Brgy.Value ' val.Substring(8, 9)
                    Slide_07_Street.Value = Session("BusStrt") ' = ' val.Substring(4, 4)
                    Slide_07_Address.Value = Session("BusAddress") '=  ' val.Substring(17, val.Length - 17)
                    Response.Redirect("BusInformation.aspx")
                End If
                'If Left(val, 4) = "Back" Then
                '    'cLoaderNewBusinessApplication._pBusBrgy = Slide_07_Brgy.Value
                '    If val.Length = 4 Then
                '        val = val + cLoaderNewBusinessApplication._pBusStrt
                '    End If
                '    cLoaderNewBusinessApplication._pBusBrgy = val.Substring(8, 9)
                '    cLoaderNewBusinessApplication._pBusStrt = val.Substring(4, 4)
                '    cLoaderNewBusinessApplication._pBusAddress = val.Substring(17, val.Length - 17)
                '    Response.Redirect("BusInformation.aspx")
                'End If
                If Left(val, 4) = "Next" Then
                    'cLoaderNewBusinessApplication._pBusBrgy = Slide_07_Brgy.Value
                    'Slide_07_Address.Value = val.Substring(17, val.Length - 17)

                    Dim StrArr() As String
                    StrArr = val.Split("_")

                    Dim _nLocation() As String
                    Dim _nAddress As String
                    _nLocation = val.Split("_")

                    _nAddress = _nLocation(4)

                    Dim StrBrgyDist() As String
                    StrBrgyDist = val.Split("_") 'Slide_07_Brgy.Value.Split("_")

                    Dim nDistCode As String = StrBrgyDist(2)
                    Dim nBrgyCode As String = StrBrgyDist(3)
                    Dim nStrtCode As String = StrBrgyDist(1)
                    If _nAddress = "" Then
                        snackbar("red", "Please input Business Address")
                        Exit Sub
                    End If

                    If val.Length = 4 Then
                        val = val + Session("BusStrt")
                    End If
                    Session("BusDist") = nDistCode  'Added 20210701  
                    Session("BusBrgy") = nBrgyCode ' val.Substring(8, 9)
                    Session("BusStrt") = nStrtCode 'Slide_07_Street.Value ' val.Substring(4, 4)
                    Session("BusAddress") = _nAddress ' val.Substring(17, val.Length - 17)

                    Response.Redirect("BusOwnerInfo.aspx")
                End If
                'If Left(val, 4) = "Next" Then
                '    'cLoaderNewBusinessApplication._pBusBrgy = Slide_07_Brgy.Value
                '    If val.Length = 4 Then
                '        val = val + cLoaderNewBusinessApplication._pBusStrt
                '    End If
                '    cLoaderNewBusinessApplication._pBusBrgy = val.Substring(8, 9)
                '    cLoaderNewBusinessApplication._pBusStrt = val.Substring(4, 4)
                '    cLoaderNewBusinessApplication._pBusAddress = val.Substring(17, val.Length - 17)
                '    Response.Redirect("BusOwnerInfo.aspx")
                'End If
            End If

        End If

    End Sub

    Sub snackbar(Color As String, Caption As String)
        Try
            If Color = "red" Then
                _oLabelSnackbar.Text = Caption
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "Snackbar();", True)

            ElseIf Color = "green" Then
                _oLabelSnackbargreen.Text = Caption
                ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "SnackbarGreen();", True)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Get_Brgy(ByVal _nCond As String)
        Try
            'cGlobalConnections._pSqlCxn_BPLTAS

            Dim _nSqlStr As String
            Dim _mDatatableBrgy As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT BRGYDESC, DISTCODE + '_' + BRGYCODE as DISTCODE_BRGYCODE from BRGYCODE " & _nCond & " order by BRGYDESC ASC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableBrgy)

            Try
                '----------------------------------

                Slide_07_Brgy.DataSource = _mDatatableBrgy
                Slide_07_Brgy.DataTextField = "BRGYDESC"
                Slide_07_Brgy.DataValueField = "DISTCODE_BRGYCODE"

                Slide_07_Brgy.DataBind()

                If Session("BusBrgy") <> "" Or Not Session("BusBrgy") = Nothing Then
                    Slide_07_Brgy.Value = Session("BusBrgy")
                End If
                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Load_Brgy(ByVal _nCond As String) ' Added By Louie 20210705
        Try
            'cGlobalConnections._pSqlCxn_BPLTAS

            Dim _nSqlStr As String
            Dim _mDatatableBrgy As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT BRGYDESC, DISTCODE + '_' + BRGYCODE as DISTCODE_BRGYCODE from BRGYCODE " & _nCond & " order by BRGYDESC ASC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableBrgy)

            Try
                '----------------------------------

                Slide_07_Brgy.DataSource = _mDatatableBrgy
                Slide_07_Brgy.DataTextField = "BRGYDESC"
                Slide_07_Brgy.DataValueField = "DISTCODE_BRGYCODE"
                Slide_07_Brgy.DataBind()
                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Get_BrgyDesc(ByVal DistCode As String, ByVal BrgyCode As String) '20210618 Added by Louie
        Try
            '----------------------------------
            Dim _nSqlStr As String
            Dim _mDatatableBrgy As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _mSqlDataReader As SqlDataReader
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT BRGYDESC from BRGYCODE  WHERE DISTCODE = '" & DistCode & "' AND BRGYCODE = '" & BrgyCode & "'"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableBrgy)

            _mSqlDataReader = _mSqlCommand.ExecuteReader

            Try
                '----------------------------------
                Slide_07_Brgy.Value = _mSqlDataReader.Item("BRGYDESC").ToString
                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Get_Street(ByVal BrgyCode As String)
        Try
            '----------------------------------
            Slide_07_Street.DataSourceID = Nothing

            Dim _nSqlStr As String
            Dim _mDatatableStrt As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT * FROM STRTCODE Where BrgyCode = '" & BrgyCode & "' order by STRTDESC ASC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableStrt)

            Try
                '----------------------------------
                Slide_07_Street.DataSource = _mDatatableStrt
                Slide_07_Street.DataTextField = "STRTDESC"
                Slide_07_Street.DataValueField = "STRTCODE"
                Slide_07_Street.DataBind()

                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Get_StreetDesc(ByVal DistCode As String, ByVal BrgyCode As String) '20210618 Added by Louie
        Try
            '----------------------------------

            Dim _nSqlStr As String
            Dim _mDatatableStrt As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _mSqlDataReader As SqlDataReader
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "SELECT * FROM STRTCODE Where BrgyCode = '" & BrgyCode & "' AND DistCode = '" & DistCode & "'"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableStrt)

            _mSqlDataReader = _mSqlCommand.ExecuteReader

            Try
                '----------------------------------
                Slide_07_SelectedStreetDesc.Value = _mSqlDataReader.Item("STRTDESC").ToString
                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
        Catch ex As Exception

        End Try

    End Sub

End Class