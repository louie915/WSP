<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PaymentConfirmation_LBP1.aspx.vb" Inherits="SPIDC.PaymentConfirmation_LBP1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <rsweb:reportviewer ID="Report_EOR" 
                        runat="server"
                        AsynRendering="true"
                        SizeToReportContent = "true">
                      </rsweb:reportviewer>

        <div runat="server" id="div_Result" style="display:none;"></div>
    <input type="hidden" id="err" />
    </div>
    </form>
</body>
</html>
