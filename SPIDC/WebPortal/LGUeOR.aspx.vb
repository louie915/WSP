Imports System.IO
Imports Microsoft.Reporting.WebForms

Public Class LGUeOR
    Inherits System.Web.UI.Page
    Dim err As String = Nothing
    Dim ORNO As String = Nothing
    Dim TAXTYPE As String = Nothing
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Load_Gridview()
        Catch ex As Exception

        End Try
    End Sub
    Sub Load_Gridview()
        Try
            Dim _Class As New eOR

            gv_Pending.DataSource = _Class.Get_PendingEorList(err)
            gv_Pending.DataBind()

            gv_Sent.DataSource = _Class.Get_SentEorList(err)
            gv_Sent.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub PageIndexChanging_Sent(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            gv_Sent.PageIndex = e.NewPageIndex
            gv_Sent.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub PageIndexChanging_Pending(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Try
            gv_Pending.PageIndex = e.NewPageIndex
            gv_Pending.DataBind()
        Catch ex As Exception
        End Try
    End Sub

   

    Private Sub btn_View_ServerClick(sender As Object, e As EventArgs) Handles btn_View.ServerClick
        Try
            ' ORNO = hdnEORno.Value
            Dim _class As New eOR
            Dim eORNO As String = hdnEORno.Value
            Process.TransactionType = hdnTAXTYPE.Value
            ReportViewer.TAXTYPE_eOR = hdnTAXTYPE.Value
            ReportViewer.DT0_eOR = Nothing
            ReportViewer.DT1_eOR = Nothing
            ReportViewer.DT2_eOR = Nothing

            ReportViewer.DT0_eOR = _class.Print_Template
            ReportViewer.DT1_eOR = _class.Print_Report(eORNO)
            ReportViewer.DT2_eOR = _class.Print_TOP(eORNO)

            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=eOR','_blank');</script>")

            ' Load_Report()
        Catch ex As Exception

        End Try
    End Sub

  
  

  
    Private Sub btn_Send_ServerClick(sender As Object, e As EventArgs) Handles btn_Send.ServerClick
        Try
            ORNO = hdnEORno.Value
            Dim TDNBIN As String = hdnTDNBIN.Value
            Dim TAXTYPE As String = hdnTAXTYPE.Value
            Dim _class As New eOR
            Dim eORNO As String = Nothing
            Dim ERR As String

            If eOR.isEORSaved(ORNO, ERR) = False Then
                If String.IsNullOrEmpty(ERR) = False Then
                    'show err
                Else
                    eORNO = eOR.Generate_eORno()
                    '  eOR.Insert_eOR(TAXTYPE, eORNO, ERR)
                    eOR.Update_eOR(eORNO, ERR)
                    ' eOR.Insert_eOR_EXTN(TAXTYPE, eORNO, TDNBIN, ERR)
                End If
            End If



            eOR.email = eOR.Get_EMAIL(ORNO)

            ReportViewer.TAXTYPE_eOR = TAXTYPE
            ReportViewer.DT0_eOR = Nothing
            ReportViewer.DT1_eOR = Nothing
            ReportViewer.DT2_eOR = Nothing

            ReportViewer.DT0_eOR = Nothing
            ReportViewer.DT1_eOR = _class.Print_Report(ORNO)
            ReportViewer.DT2_eOR = _class.Print_TOP(ORNO)
            ReportViewer.DT0_eOR = _class.Print_Template



            Response.Write("<script>window.open ('Report/ReportViewer.aspx?ReportType=eOR&Send=1');</script>")
            ' Load_Report()
        Catch ex As Exception

        End Try
    End Sub
End Class