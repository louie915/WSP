Imports System.Data.SqlClient

Public Class BusOwnershipType
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Get_OWNDESC("")

            Slide_01_OwnershipType.Value = Session("OwnerShipType")
            If Session("Rent") = "True" Then
                radio1.Checked = True
                radio2.Checked = False
            Else
                radio1.Checked = False
                radio2.Checked = True
            End If

        Else

            Dim action = Request("__EVENTTARGET")
            Dim val = Request("__EVENTARGUMENT")

            If action = "Redirect" Then

                If val = "Home" Then
                    Session("OwnerShipType") = ""
                    Session("Rent") = "False"
                    'cLoaderNewBusinessApplication._pOwnershipType = ""
                    'cLoaderNewBusinessApplication._pRent = False
                    Response.Redirect("Account.aspx")
                ElseIf val = "Next" Then
                    Session("OwnerShipType") = Slide_01_OwnershipType.Value
                    If radio1.Checked = True Then
                        Session("Rent") = "True"
                    Else
                        Session("Rent") = "False"
                    End If
                    'cLoaderNewBusinessApplication._pOwnershipType = Slide_01_OwnershipType.Value
                    'If radio1.Checked = True Then
                    '    cLoaderNewBusinessApplication._pRent = True
                    'Else
                    '    cLoaderNewBusinessApplication._pRent = False
                    'End If
                    If radio1.Checked = True Then
                        If Slide_01_OwnershipType.Value = "" Then
                            snackbar("red", "Please select Ownership Type.")
                            Exit Sub
                        End If
                        Session("Rent") = "True"
                        Response.Redirect("BusLessorInfo.aspx")
                    Else
                        If Slide_01_OwnershipType.Value = "" Then
                            snackbar("red", "Please select Ownership Type.")
                            Exit Sub
                        End If
                        Session("Rent") = "False"
                        Response.Redirect("BusGovRegistration.aspx")
                    End If

                End If

            End If

        End If
    End Sub

    Protected Sub Get_OWNDESC(ByVal _nCond As String)
        Try
            'cGlobalConnections._pSqlCxn_BPLTAS

            Dim _nSqlStr As String
            Dim _mDatatableBrgy As New DataTable
            Dim _mSqlCommand As New SqlCommand
            Dim _nSqlDataAdapter As New SqlDataAdapter

            _nSqlStr = "Select * from OWNCODE " & _nCond & " order by OWNDESC ASC"
            _mSqlCommand = New SqlCommand(_nSqlStr, cGlobalConnections._pSqlCxn_BPLTAS)
            _nSqlDataAdapter = New SqlDataAdapter(_mSqlCommand)
            _nSqlDataAdapter.Fill(_mDatatableBrgy)

            Try
                '----------------------------------

                Slide_01_OwnershipType.DataSource = _mDatatableBrgy
                Slide_01_OwnershipType.DataTextField = "OWNDESC"
                Slide_01_OwnershipType.DataValueField = "OWNCODE"
                Slide_01_OwnershipType.DataBind()
                '----------------------------------
            Catch ex As Exception
                'Shoiw Blank Table
                '  _mSubShowBlank()
            End Try
            '----------------------------------
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

End Class