Public Class OnlinePaymentSetup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        get_Gateway()
    End Sub


    Sub get_Gateway()
        Dim _nClass As New cDalOnlinePayment
        _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
        _nClass._pSubSelectGATEWAY()
        GridView_Gateway.DataSource = cDalOnlinePayment._mDataTable
        GridView_Gateway.DataBind()

        For Each row As GridViewRow In GridView_Gateway.Rows
            Dim STATUS = DirectCast(row.FindControl("STATUS"), Label).Text


            If STATUS = "ENABLED" Then
                DirectCast(row.FindControl("STATUS"), Label).Style.Add("color", "green")
            Else
                DirectCast(row.FindControl("STATUS"), Label).Style.Add("color", "lightgray")
            End If
        Next
    End Sub

    Private Sub btnSave_ServerClick(sender As Object, e As EventArgs) Handles btnSave.ServerClick
        Try
            Dim _nClass As New cDalOnlinePayment
            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            _nClass.ModifyGateway(hdnCode.value, txtGw_Name.Value, txtGw_Fee.Value, cmbStatus.Value)
            get_Gateway()
        Catch ex As Exception

        End Try
    End Sub
End Class