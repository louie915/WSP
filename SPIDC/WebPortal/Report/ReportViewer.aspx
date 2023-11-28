<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportViewer.aspx.vb" Inherits="SPIDC.ReportViewer" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
  
       <asp:ScriptManager ID="ScriptManager1" runat="server" />
         
            <%-- <asp:UpdatePanel runat="server" >
                <ContentTemplate>--%>

        <center>

              <rsweb:ReportViewer ID="_oRpt_EnvelopeSeal" 
                        runat="server"
                        AsynRendering="true"
                        SizeToReportContent = "true">
                      </rsweb:ReportViewer>
        </center>

       

        <textarea runat="server" id="txtqr" style="display:none"></textarea>


  
    </form>
</body>
</html>
