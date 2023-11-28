Public Class BusInformation
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _nTotal As Integer
        If Not IsPostBack Then

            Slide_06_Branch.Value = Session("BusBranch")
            Slide_06_DateEstablished.Value = Session("BusDateEsta")
            Slide_06_TradeName.Value = Session("BusTradeName")
            Slide_06_NoMale.Value = Session("BusMale")
            Slide_06_NoFemale.Value = Session("BusFemale")
            Slide_06_NoTotal.Value = Session("BusTotal")
            Slide_06_NoLGU.Value = Session("BusResident")

        Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "Redirect" Then

                If val = "Back" Then

                    Session("BusBranch") = Slide_06_Branch.Value
                    Session("BusDateEsta") = Slide_06_DateEstablished.Value
                    Session("BusTradeName") = Slide_06_TradeName.Value
                    Session("BusMale") = Slide_06_NoMale.Value
                    Session("BusFemale") = Slide_06_NoFemale.Value
                    Session("BusTotal") = Slide_06_NoTotal.Value
                    Session("BusResident") = Slide_06_NoLGU.Value

                    'cLoaderNewBusinessApplication._pBusBranch = Slide_06_Branch.Value
                    'cLoaderNewBusinessApplication._pBusDateEsta = Slide_06_DateEstablished.Value
                    'cLoaderNewBusinessApplication._pBusTradeName = Slide_06_TradeName.Value
                    'cLoaderNewBusinessApplication._pBusMale = Slide_06_NoMale.Value
                    'cLoaderNewBusinessApplication._pBusFemale = Slide_06_NoFemale.Value
                    'cLoaderNewBusinessApplication._pBusTotal = Slide_06_NoTotal.Value
                    'cLoaderNewBusinessApplication._pBusResident = Slide_06_NoLGU.Value

                    Response.Redirect("BusGovRegistration.aspx")
                ElseIf val = "Next" Then

                    Session("BusBranch") = Slide_06_Branch.Value
                    Session("BusDateEsta") = Slide_06_DateEstablished.Value
                    Session("BusTradeName") = Slide_06_TradeName.Value
                    Session("BusMale") = Slide_06_NoMale.Value
                    Session("BusFemale") = Slide_06_NoFemale.Value
                    Session("BusTotal") = Slide_06_NoTotal.Value
                    Session("BusResident") = Slide_06_NoLGU.Value

                    'cLoaderNewBusinessApplication._pBusBranch = Slide_06_Branch.Value
                    'cLoaderNewBusinessApplication._pBusDateEsta = Slide_06_DateEstablished.Value
                    'cLoaderNewBusinessApplication._pBusTradeName = Slide_06_TradeName.Value
                    'cLoaderNewBusinessApplication._pBusMale = Slide_06_NoMale.Value
                    'cLoaderNewBusinessApplication._pBusFemale = Slide_06_NoFemale.Value
                    'cLoaderNewBusinessApplication._pBusTotal = Slide_06_NoTotal.Value
                    'cLoaderNewBusinessApplication._pBusResident = Slide_06_NoLGU.Value

                    _nTotal = CInt(IIf(Slide_06_NoMale.Value = "", 0, Slide_06_NoMale.Value)) + CInt(IIf(Slide_06_NoFemale.Value = "", 0, Slide_06_NoFemale.Value))
                    If Slide_06_DateEstablished.Value = "" Then
                        snackbar("red", "Date Established must not be empty.")
                        Exit Sub
                    End If
                    If Slide_06_TradeName.Value = "" Then
                        snackbar("red", "Business Tradename must not be empty.")
                        Exit Sub
                    End If
                    If Slide_06_NoMale.Value = "" And Slide_06_NoFemale.Value = "" Then
                        snackbar("red", "Please input number of Employees.")
                        Exit Sub
                    End If
                    If _nTotal < CInt(IIf(Slide_06_NoLGU.Value = "", 0, Slide_06_NoLGU.Value)) Then
                        snackbar("red", "LGU Residents must not be greater than total of employees.")
                        Exit Sub
                    End If
                    Response.Redirect("BrgyFilter.aspx")
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