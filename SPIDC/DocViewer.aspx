<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DocViewer.aspx.vb" Inherits="SPIDC.DocViewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body >
   
    <form id="form1" runat="server">
    <div>
        <input type="text" id="txtHash" onchange="AutoSearch(this.value);" />
        <input type="button" id="btnSearch" runat="server"  style="display:none;"/>
        <input type="hidden" runat="server" id="hdnHash" />
    </div>
    </form>

    <script>
        function AutoSearch(val) {
            if (val.length == 32) {
                document.getElementById('<%= hdnHash.ClientID%>').value = val;
                document.getElementById('<%= btnSearch.ClientID%>').click();
            }
        }
    </script>
</body>
</html>
