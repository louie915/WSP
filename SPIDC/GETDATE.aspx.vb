Public Class GETDATE
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
    End Sub

    Private Sub btnGetDate_ServerClick(sender As Object, e As EventArgs) Handles btnGetDate.ServerClick
        Try
            Dim _nClass As New cDalGetDate
            '   Dim _Date As Date
            '    _Date = CDate(_nClass._GetDate(txtFormat.Value))

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTIMS
            SOS_BP.InnerText = _nClass._GetDate(txtFormat.Value)
            SOS_BP_Con.InnerText = cGlobalConnections._pStrCxn_BPLTIMS

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_CR
            SOS_CR.InnerText = _nClass._GetDate(txtFormat.Value)
            SOS_CR_Con.InnerText = cGlobalConnections._pStrCxn_CR

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_OAIMS
            SOS_OAIMS.InnerText = _nClass._GetDate(txtFormat.Value)
            SOS_OAIMS_Con.InnerText = cGlobalConnections._pStrCxn_OAIMS

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTIMS
            SOS_RPT.InnerText = _nClass._GetDate(txtFormat.Value)
            SOS_RPT_con.InnerText = cGlobalConnections._pStrCxn_RPTIMS

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TIMS
            SOS_TIMS.InnerText = _nClass._GetDate(txtFormat.Value)
            SOS_TIMS_con.InnerText = cGlobalConnections._pStrCxn_TIMS

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_BPLTAS
            BPLTAS.InnerText = _nClass._GetDate(txtFormat.Value)
            BPLTAS_con.InnerText = cGlobalConnections._pStrCxn_BPLTAS

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_RPTAS
            RPTAS.InnerText = _nClass._GetDate(txtFormat.Value)
            RPTAS_Con.InnerText = cGlobalConnections._pStrCxn_RPTAS

            _nClass._pSqlConnection = cGlobalConnections._pSqlCxn_TOIMS
            TOIMS.InnerText = _nClass._GetDate(txtFormat.Value)
            TOIMS_Con.InnerText = cGlobalConnections._pStrCxn_TOIMS


        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub
End Class