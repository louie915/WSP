<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RPTReport.aspx.vb" Inherits="SPIDC.RPTReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>


</head>
<body>
    <form id="form1" runat="server">
       
    <div>
         <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
         
        <div>
          
           <rsweb:ReportViewer ID="_oMSRV" 
                        runat="server" 
                        Height="600px" Width="100%"
                        ZoomMode ="PageWidth" 
                        Font-Names="Verdana" 
                        Font-Size="8pt" 
                        WaitMessageFont-Names="Verdana" 
                        WaitMessageFont-Size="14pt">
                      </rsweb:ReportViewer>

        </div>
        <div id="_oDivPayment" runat="server" style="display:none">
            <br />
            <%--<asp:HyperLink ID="_oHyperLinkProceedToPayment" runat="server"> Proceed to Payment </asp:HyperLink>--%>

        </div>
          <br />
    </div>
    </form>
</body>
</html>
