Public Class BusIncorporator
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            'Slide_09_FName.Value = cLoaderNewBusinessApplication._pIncFName
            'Slide_09_MName.Value = cLoaderNewBusinessApplication._pIncMName
            'Slide_09_LName.Value = cLoaderNewBusinessApplication._pIncLName
            'Slide_09_Address.Value = cLoaderNewBusinessApplication._pIncAddress
            Slide_09_FName.Value = Session("IncFName") 'cLoaderNewBusinessApplication._pIncFName
            Slide_09_MName.Value = Session("IncMName") 'cLoaderNewBusinessApplication._pIncMName
            Slide_09_LName.Value = Session("IncLName") 'cLoaderNewBusinessApplication._pIncLName
            Slide_09_Address.Value = Session("IncAddress") 'cLoaderNewBusinessApplication._pIncAddress

        Else

            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "Redirect" Then

                If val = "Back" Then
                    'cLoaderNewBusinessApplication._pIncFName = Slide_09_FName.Value
                    'cLoaderNewBusinessApplication._pIncMName = Slide_09_MName.Value
                    'cLoaderNewBusinessApplication._pIncLName = Slide_09_LName.Value
                    'cLoaderNewBusinessApplication._pIncAddress = Slide_09_Address.Value
                    Session("IncFName") = Slide_09_FName.Value
                    Session("IncMName") = Slide_09_MName.Value
                    Session("IncLName") = Slide_09_LName.Value
                    Session("IncAddress") = Slide_09_Address.Value
                    Response.Redirect("BusOwnerInfo.aspx")
                End If
                If val = "Next" Then
                    Session("IncFName") = Slide_09_FName.Value
                    Session("IncMName") = Slide_09_MName.Value
                    Session("IncLName") = Slide_09_LName.Value
                    Session("IncAddress") = Slide_09_Address.Value
                    Response.Redirect("BusIncorporatorAddInfo.aspx")
                End If
            End If

        End If
    End Sub

End Class