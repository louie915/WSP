Public Class BusLessorInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Slide_02_DateRented.Value = Session("LessorDateRented")
            Slide_02_RentPerMonth.Value = Session("LessorRatePerMonth")
            Slide_02_LessorFname.Value = Session("LessorFirstName")
            Slide_02_LessorLname.Value = Session("LessorLastName")
            Slide_02_Brgy.Value = Session("LessorBarangay")
            Slide_02_Street.Value = Session("LessorStreet")
            Slide_02_Address.Value = Session("LessorAddress")
            Slide_02_TelNo.Value = Session("LessorTelNo")
            Slide_02_Email.Value = Session("LessorEmail")
            Slide_02_Administrator.Value = Session("BuildingAdministrator")

            'Slide_02_DateRented.Value = cLoaderNewBusinessApplication._pLessorDateRented
            'Slide_02_RentPerMonth.Value = cLoaderNewBusinessApplication._pLessorRatePerMonth
            'Slide_02_LessorFname.Value = cLoaderNewBusinessApplication._pLessorFirstName
            'Slide_02_LessorLname.Value = cLoaderNewBusinessApplication._pLessorLastName
            'Slide_02_Brgy.Value = cLoaderNewBusinessApplication._pLessorBarangay
            'Slide_02_Street.Value = cLoaderNewBusinessApplication._pLessorStreet
            'Slide_02_Address.Value = cLoaderNewBusinessApplication._pLessorAddress
            'Slide_02_TelNo.Value = cLoaderNewBusinessApplication._pLessorTelNo
            'Slide_02_Email.Value = cLoaderNewBusinessApplication._pLessorEmail
            'Slide_02_Administrator.Value = cLoaderNewBusinessApplication._pBuildingAdministrator

        Else

            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "Redirect" Then

                If val = "Back" Then
                    'cLoaderNewBusinessApplication._pLessorDateRented = Slide_02_DateRented.Value
                    'cLoaderNewBusinessApplication._pLessorRatePerMonth = Slide_02_RentPerMonth.Value
                    'cLoaderNewBusinessApplication._pLessorFirstName = Slide_02_LessorFname.Value
                    'cLoaderNewBusinessApplication._pLessorLastName = Slide_02_LessorLname.Value
                    'cLoaderNewBusinessApplication._pLessorBarangay = Slide_02_Brgy.Value
                    'cLoaderNewBusinessApplication._pLessorStreet = Slide_02_Street.Value
                    'cLoaderNewBusinessApplication._pLessorAddress = Slide_02_Address.Value
                    'cLoaderNewBusinessApplication._pLessorTelNo = Slide_02_TelNo.Value
                    'cLoaderNewBusinessApplication._pLessorEmail = Slide_02_Email.Value
                    'cLoaderNewBusinessApplication._pBuildingAdministrator = Slide_02_Administrator.Value

                    Session("LessorDateRented") = Slide_02_DateRented.Value
                    Session("LessorRatePerMonth") = Slide_02_RentPerMonth.Value
                    Session("LessorFirstName") = Slide_02_LessorFname.Value
                    Session("LessorLastName") = Slide_02_LessorLname.Value
                    Session("LessorBarangay") = Slide_02_Brgy.Value
                    Session("LessorStreet") = Slide_02_Street.Value
                    Session("LessorAddress") = Slide_02_Address.Value
                    Session("LessorTelNo") = Slide_02_TelNo.Value
                    Session("LessorEmail") = Slide_02_Email.Value
                    Session("BuildingAdministrator") = Slide_02_Administrator.Value

                    Response.Redirect("BusOwnerShipType.aspx")
                ElseIf val = "Next" Then
                    Session("LessorDateRented") = Slide_02_DateRented.Value
                    Session("LessorRatePerMonth") = Slide_02_RentPerMonth.Value
                    Session("LessorFirstName") = Slide_02_LessorFname.Value
                    Session("LessorLastName") = Slide_02_LessorLname.Value
                    Session("LessorBarangay") = Slide_02_Brgy.Value
                    Session("LessorStreet") = Slide_02_Street.Value
                    Session("LessorAddress") = Slide_02_Address.Value
                    Session("LessorTelNo") = Slide_02_TelNo.Value
                    Session("LessorEmail") = Slide_02_Email.Value
                    Session("BuildingAdministrator") = Slide_02_Administrator.Value

                    'cLoaderNewBusinessApplication._pLessorDateRented = Slide_02_DateRented.Value
                    'cLoaderNewBusinessApplication._pLessorRatePerMonth = Slide_02_RentPerMonth.Value
                    'cLoaderNewBusinessApplication._pLessorFirstName = Slide_02_LessorFname.Value
                    'cLoaderNewBusinessApplication._pLessorLastName = Slide_02_LessorLname.Value
                    'cLoaderNewBusinessApplication._pLessorBarangay = Slide_02_Brgy.Value
                    'cLoaderNewBusinessApplication._pLessorStreet = Slide_02_Street.Value
                    'cLoaderNewBusinessApplication._pLessorAddress = Slide_02_Address.Value
                    'cLoaderNewBusinessApplication._pLessorTelNo = Slide_02_TelNo.Value
                    'cLoaderNewBusinessApplication._pLessorEmail = Slide_02_Email.Value
                    'cLoaderNewBusinessApplication._pBuildingAdministrator = Slide_02_Administrator.Value
                    If Slide_02_DateRented.Value = "" Then
                        snackbar("red", "Please input Date Rented.")
                        Exit Sub
                    End If
                    If Slide_02_RentPerMonth.Value = "" Or Slide_02_RentPerMonth.Value = "0.00" Then
                        snackbar("red", "Please input rent per month.")
                        Exit Sub
                    End If
                    If Slide_02_LessorFname.Value = "" Then
                        snackbar("red", "Please input Lessor's First Name.")
                        Exit Sub
                    End If
                    If Slide_02_LessorLname.Value = "" Then
                        snackbar("red", "Please input Lessor's Last Name.")
                        Exit Sub
                    End If

                    Response.Redirect("BusGovRegistration.aspx")
                End If

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

End Class