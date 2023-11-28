<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Process.aspx.vb" Inherits="SPIDC.Process" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body >  
   


    <form id="form1" runat="server">
         <asp:ScriptManager runat="server">
    </asp:ScriptManager>

          <%--REPORTVIEWER Report_EOR--%>
                        <rsweb:reportviewer ID="Report_EOR" runat="server" style="display:none;"  SizeToReportContent="false"
                            Width="100%" ZoomMode="PageWidth" Height="650px">
                        </rsweb:reportviewer>
    <div>
        <input type="button" runat="server" value="Post Payment" style="display:none;" id="btn_PostPayment"  />
        <input type="button" runat="server" value="Get Posted Details" id="btn_GetPostedDetails" style="display:none;"/>
        <input type="button" runat="server" value="Generate E-OR Report and Send to Email" id="btn_GenerateEORReport" style="display:none;"/>
        <input type="button" runat="server" value="Back to Home Page" id="btn_Home" style="display:none;"/>
    </div>
    </form>
</body>
</html>
