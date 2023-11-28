Imports System.Data.SqlClient

Public Class BusOwnerInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

       
        If Not IsPostBack Then
            Load_Citizenship("")
            'cLoaderNewBusinessApplication._pOwnerFName = Request.Form("Slide_08_FnameHdn")
            'cLoaderNewBusinessApplication._pOwnerMName = Request.Form("Slide_08_MnameHdn")
            'cLoaderNewBusinessApplication._pOwnerLName = Request.Form("Slide_08_LnameHdn")
            'cLoaderNewBusinessApplication._pOwnerSuffix = Request.Form("Slide_08_SuffixHdn")
            'cLoaderNewBusinessApplication._pOwnerGender = Request.Form("Slide_08_GenderHdn")
            'cLoaderNewBusinessApplication._pOwnerCitizenship = Request.Form("Slide_08_CitizenshipHdn")
            ''cLoaderNewBusinessApplication._pOwnerCheck = IIf(Request.Form("Slide_08_CheckHdn") = "", False, Request.Form("Slide_08_CheckHdn"))
            'cLoaderNewBusinessApplication._pOwnerAddress = Request.Form("Slide_08_AddressHdn")
            'cLoaderNewBusinessApplication._pOwnerTelNo = Request.Form("Slide_08_TelNoHdn")
            'cLoaderNewBusinessApplication._pOwnerEmail = Request.Form("Slide_08_EmailHdn")
            'cLoaderNewBusinessApplication._pOwnerAltEmail = Request.Form("Slide_08_AlternateEmailHdn")

            'Slide_08_Fname.Value = cLoaderNewBusinessApplication._pOwnerFName
            'Slide_08_Mname.Value = cLoaderNewBusinessApplication._pOwnerMName
            'Slide_08_Lname.Value = cLoaderNewBusinessApplication._pOwnerLName
            'Slide_08_Suffix.Value = cLoaderNewBusinessApplication._pOwnerSuffix
            'Slide_08_Gender.Value = cLoaderNewBusinessApplication._pOwnerGender
            'Slide_08_Citizenship.Value = cLoaderNewBusinessApplication._pOwnerCitizenship
            'Slide_08_Check.Checked = cLoaderNewBusinessApplication._pOwnerCheck
            'Slide_08_Address.Value = cLoaderNewBusinessApplication._pOwnerAddress
            'Slide_08_TelNo.Value = cLoaderNewBusinessApplication._pOwnerTelNo
            'Slide_08_Email.Value = cLoaderNewBusinessApplication._pOwnerEmail
            'Slide_08_AlternateEmail.Value = cLoaderNewBusinessApplication._pOwnerAltEmail
            Slide_08_AddressHdn.Value = Session("BusAddress")
            Slide_08_Fname.Value = Session("OwnerFName")
            Slide_08_Mname.Value = Session("OwnerMName")
            Slide_08_Lname.Value = Session("OwnerLName")
            Slide_08_Suffix.Value = Session("OwnerSuffix")
            Slide_08_Gender.Value = Session("OwnerGender")
            Slide_08_Citizenship.Value = Session("OwnerCitizenship")
            Slide_08_Check.Checked = IIf(Session("OwnerCheck") = "", False, True)
            Slide_08_Address.Value = Session("OwnerAddress")
            Slide_08_TelNo.Value = Session("OwnerTelNo")
            Slide_08_Email.Value = Session("OwnerEmail")
            Slide_08_AlternateEmail.Value = Session("OwnerAltEmail")

        Else

            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")


            If action = "GetAddress" Then
                If val = "true" Then
                    Session("OwnerFName") = Slide_08_Fname.Value
                    Session("OwnerMName") = Slide_08_Mname.Value
                    Session("OwnerLName") = Slide_08_Lname.Value
                    Session("OwnerSuffix") = Slide_08_Suffix.Value
                    Session("OwnerGender") = Slide_08_Gender.Value
                    Session("OwnerCitizenship") = Slide_08_Citizenship.Value
                    Session("OwnerCheck") = Slide_08_Check.Checked
                    Session("OwnerAddress") = Slide_08_Address.Value
                    Session("OwnerTelNo") = Slide_08_TelNo.Value
                    Session("OwnerEmail") = Slide_08_Email.Value
                    Session("OwnerAltEmail") = Slide_08_AlternateEmail.Value
                    Slide_08_Fname.Value = Session("OwnerFName")
                    Slide_08_Mname.Value = Session("OwnerMName")
                    Slide_08_Lname.Value = Session("OwnerLName")
                    Slide_08_Suffix.Value = Session("OwnerSuffix")
                    Slide_08_Gender.Value = Session("OwnerGender")
                    Slide_08_Citizenship.Value = Session("OwnerCitizenship")
                    Slide_08_Check.Checked = Session("OwnerCheck")
                    Slide_08_Address.Value = Session("BusAddress")
                    'Slide_08_Address.Value = Session("OwnerAddress")
                    Slide_08_TelNo.Value = Session("OwnerTelNo")
                    Slide_08_Email.Value = Session("OwnerEmail")
                    Slide_08_AlternateEmail.Value = Session("OwnerAltEmail")
                    'cLoaderNewBusinessApplication._pOwnerFName = Slide_08_Fname.Value
                    'cLoaderNewBusinessApplication._pOwnerLName = Slide_08_Mname.Value
                    'cLoaderNewBusinessApplication._pOwnerMName = Slide_08_Lname.Value
                    'cLoaderNewBusinessApplication._pOwnerSuffix = Slide_08_Suffix.Value
                    'cLoaderNewBusinessApplication._pOwnerGender = Slide_08_Gender.Value
                    'cLoaderNewBusinessApplication._pOwnerCitizenship = Slide_08_Citizenship.Value
                    'cLoaderNewBusinessApplication._pOwnerCheck = Slide_08_Check.Checked
                    'cLoaderNewBusinessApplication._pOwnerAddress = Slide_08_Address.Value
                    'cLoaderNewBusinessApplication._pOwnerTelNo = Slide_08_TelNo.Value
                    'cLoaderNewBusinessApplication._pOwnerEmail = Slide_08_Email.Value
                    'cLoaderNewBusinessApplication._pOwnerAltEmail = Slide_08_AlternateEmail.Value
                    'Slide_08_Address.Value = cLoaderNewBusinessApplication._pBusAddress
                    'Slide_08_Fname.Value = cLoaderNewBusinessApplication._pOwnerFName
                    'Slide_08_Mname.Value = cLoaderNewBusinessApplication._pOwnerMName
                    'Slide_08_Lname.Value = cLoaderNewBusinessApplication._pOwnerLName
                    'Slide_08_Suffix.Value = cLoaderNewBusinessApplication._pOwnerSuffix
                    'Slide_08_Gender.Value = cLoaderNewBusinessApplication._pOwnerGender
                    'Slide_08_Citizenship.Value = cLoaderNewBusinessApplication._pOwnerCitizenship
                    'Slide_08_Check.Checked = cLoaderNewBusinessApplication._pOwnerCheck
                    ''Slide_08_Address.Value = cLoaderNewBusinessApplication._pOwnerAddress
                    'Slide_08_TelNo.Value = cLoaderNewBusinessApplication._pOwnerTelNo
                    'Slide_08_Email.Value = cLoaderNewBusinessApplication._pOwnerEmail
                    'Slide_08_AlternateEmail.Value = cLoaderNewBusinessApplication._pOwnerAltEmail
                Else
                    Session("OwnerFName") = Slide_08_Fname.Value
                    Session("OwnerMName") = Slide_08_Mname.Value
                    Session("OwnerLName") = Slide_08_Lname.Value
                    Session("OwnerSuffix") = Slide_08_Suffix.Value
                    Session("OwnerGender") = Slide_08_Gender.Value
                    Session("OwnerCitizenship") = Slide_08_Citizenship.Value
                    Session("OwnerCheck") = Slide_08_Check.Checked
                    Session("OwnerAddress") = Slide_08_Address.Value
                    Session("OwnerTelNo") = Slide_08_TelNo.Value
                    Session("OwnerEmail") = Slide_08_Email.Value
                    Session("OwnerAltEmail") = Slide_08_AlternateEmail.Value
                    Slide_08_Fname.Value = Session("OwnerFName")
                    Slide_08_Mname.Value = Session("OwnerMName")
                    Slide_08_Lname.Value = Session("OwnerLName")
                    Slide_08_Suffix.Value = Session("OwnerSuffix")
                    Slide_08_Gender.Value = Session("OwnerGender")
                    Slide_08_Citizenship.Value = Session("OwnerCitizenship")
                    Slide_08_Check.Checked = Session("OwnerCheck")
                    Slide_08_Address.Value = ""
                    Slide_08_TelNo.Value = Session("OwnerTelNo")
                    Slide_08_Email.Value = Session("OwnerEmail")
                    Slide_08_AlternateEmail.Value = Session("OwnerAltEmail")
                End If

            End If

            If action = "Redirect" Then

                If val = "Back" Then
                    Session("OwnerFName") = Slide_08_Fname.Value
                    Session("OwnerMName") = Slide_08_Mname.Value
                    Session("OwnerLName") = Slide_08_Lname.Value
                    Session("OwnerSuffix") = Slide_08_Suffix.Value
                    Session("OwnerGender") = Slide_08_Gender.Value
                    Session("OwnerCitizenship") = Slide_08_Citizenship.Value
                    Session("OwnerCheck") = Slide_08_Check.Checked
                    If Slide_08_Check.Checked = True Then
                        Session("OwnerAddress") = Slide_08_AddressHdn.Value
                        Slide_08_Address.Value = Slide_08_AddressHdn.Value
                    Else
                        Session("OwnerAddress") = Slide_08_Address.Value
                    End If
                    Session("OwnerTelNo") = Slide_08_TelNo.Value
                    Session("OwnerEmail") = Slide_08_Email.Value
                    Session("OwnerAltEmail") = Slide_08_AlternateEmail.Value

                    Response.Redirect("BrgyFilter.aspx")
                ElseIf val = "Next" Then
                    Session("OwnerFName") = Slide_08_Fname.Value
                    Session("OwnerMName") = Slide_08_Mname.Value
                    Session("OwnerLName") = Slide_08_Lname.Value
                    Session("OwnerSuffix") = Slide_08_Suffix.Value
                    Session("OwnerGender") = Slide_08_Gender.Value
                    Session("OwnerCitizenship") = Slide_08_Citizenship.Value
                    Session("OwnerCheck") = Slide_08_Check.Checked
                    If Slide_08_Check.Checked = True Then
                        Session("OwnerAddress") = Slide_08_AddressHdn.Value
                        Slide_08_Address.Value = Slide_08_AddressHdn.Value
                    Else
                        Session("OwnerAddress") = Slide_08_Address.Value
                    End If
                    Session("OwnerTelNo") = Slide_08_TelNo.Value
                    Session("OwnerEmail") = Slide_08_Email.Value
                    Session("OwnerAltEmail") = Slide_08_AlternateEmail.Value
                    If Session("OwnerShipType") = "Corporation" Then
                        If Slide_08_Fname.Value = "" Then
                            snackbar("red", "Please input First Name")
                            Exit Sub
                        End If
                        If Slide_08_Lname.Value = "" Then
                            snackbar("red", "Please input Last Name")
                            Exit Sub
                        End If
                        If Slide_08_Address.Value = "" Then
                            snackbar("red", "Please input Address")
                            Exit Sub
                        End If
                        Response.Redirect("BusIncorporator.aspx")
                    Else
                        If Slide_08_Fname.Value = "" Then
                            snackbar("red", "Please input First Name")
                            Exit Sub
                        End If
                        If Slide_08_Lname.Value = "" Then
                            snackbar("red", "Please input Last Name")
                            Exit Sub
                        End If
                        If Slide_08_Address.Value = "" Then
                            snackbar("red", "Please input Address")
                            Exit Sub
                        End If
                        Response.Redirect("BusApplicationSummary.aspx")
                    End If


                End If

            End If

            End If
        Catch ex As Exception

        End Try
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


    Protected Sub Load_Citizenship(ByVal _nCond As String)
        Try
            'cGlobalConnections._pSqlCxn_BPLTAS

            Dim _nSqlStr As String
            Dim _mDatatableBrgy As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "Select * from CTZNCODE " & _nCond & " order by CTZNDESC ASC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableBrgy)

            Try
                '----------------------------------

                Slide_08_Citizenship.DataSource = _mDatatableBrgy
                Slide_08_Citizenship.DataTextField = "CTZNDESC"
                Slide_08_Citizenship.DataValueField = "CTZNCODE"
                Slide_08_Citizenship.DataBind()
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