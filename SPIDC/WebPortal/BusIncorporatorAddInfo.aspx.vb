Public Class BusIncorporatorAddInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'Slide_10_TName.Value = cLoaderNewBusinessApplication._pIncAddTName
            'Slide_10_RName.Value = cLoaderNewBusinessApplication._pIncAddRName
            'Slide_10_Position.Value = cLoaderNewBusinessApplication._pIncAddPosition
            Slide_10_TName.Value = Session("IncAddTName") 'cLoaderNewBusinessApplication._pIncAddTName
            Slide_10_RName.Value = Session("IncAddRName") 'cLoaderNewBusinessApplication._pIncAddRName
            Slide_10_Position.Value = Session("IncAddPosition") ' cLoaderNewBusinessApplication._pIncAddPosition
        Else
            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "Redirect" Then

                If val = "Back" Then
                    'cLoaderNewBusinessApplication._pIncAddTName = Slide_10_TName.Value
                    'cLoaderNewBusinessApplication._pIncAddRName = Slide_10_RName.Value
                    'cLoaderNewBusinessApplication._pIncAddPosition = Slide_10_Position.Value
                    Session("IncAddTName") = Slide_10_TName.Value
                    Session("IncAddRName") = Slide_10_RName.Value
                    Session("IncAddPosition") = Slide_10_Position.Value
                    Response.Redirect("BusIncorporator.aspx")
                End If
                If val = "Next" Then
                    Session("IncAddTName") = Slide_10_TName.Value
                    Session("IncAddRName") = Slide_10_RName.Value
                    Session("IncAddPosition") = Slide_10_Position.Value
                    Response.Redirect("BusApplicationSummary.aspx")
                End If
            End If

            End If

    End Sub

End Class