<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PayMaya.aspx.vb" Inherits="SPIDC.PayMaya" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
#Response {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#Response td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
}

#Response tr:nth-child(even){background-color: #f2f2f2;}

#Response tr:hover {background-color: #ddd;}

#Response th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #04AA6D;
  color: white;
}
</style>
</head>   
<body>
   
    <form id="form1" runat="server">
         <asp:ScriptManager runat="server">
    </asp:ScriptManager>
          <rsweb:reportviewer ID="Report_EOR" 
                        runat="server"
                        AsynRendering="true"
                        SizeToReportContent = "true">
                      </rsweb:reportviewer>

    <div style="width:50%">
        <div style="display:none" >
             <textarea runat="server" id="txtArea"></textarea>
        <input type="button" id="btnSubmit" runat="server" value="Submit"/>
        </div>       

        <table id="Response">
            <tr style="text-align:center"><th colspan="2">Payment Details</th></tr>
            <tr><td>id</td><td id="txt_ID" runat="server"></td></tr>
            <tr><td>isPaid</td><td id="txt_isPaid" runat="server"></td></tr>
            <tr><td>status</td><td id="txt_status" runat="server"></td></tr>
            <tr><td>amount</td><td id="txt_amount" runat="server"></td></tr>
            <tr><td>currency</td><td id="txt_currency" runat="server"></td></tr>
            <tr><td>canVoid</td><td id="txt_canVoid" runat="server"></td></tr>
            <tr><td>canRefund</td><td id="txt_canRefund" runat="server"></td></tr>
            <tr><td>canCapture</td><td id="txt_canCapture" runat="server"></td></tr>
            <tr><td>createdAt</td><td id="txt_createdAt" runat="server"></td></tr>
            <tr><td>updatedAt</td><td id="txt_updatedAt" runat="server"></td></tr>
            <tr><td>description</td><td id="txt_description" runat="server"></td></tr> 
            <tr><td>requestReferenceNumber</td><td id="txt_requestReferenceNumber" runat="server"></td></tr>
            <tr style="text-align:center"><td colspan="2"><a href="Account.aspx">Return to Home Page</a></td></tr>
        </table>
   
    </div>
    </form>
</body>
</html>
