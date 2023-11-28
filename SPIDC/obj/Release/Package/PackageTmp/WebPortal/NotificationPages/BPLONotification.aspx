<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BPLONotification.aspx.vb" Inherits="SPIDC.BPLONotification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>

         <div class="w3-container w3-content" style="max-width: 1400px; margin-top: 80px">
            <div id="_oDiv_BPLO_Notification">
                <h3 runat="server" id="_oHeader"> Taxpayer Successfully Notified. </h3>
                <br />
                <asp:Label ID="_oLabel_Content" runat="server" Text="Please click on action below."></asp:Label>
                <br />
                <br />
                <a href="../BPLONewBusinessList.aspx">Review another Account</a>
                <br />
                <a href="../Register.aspx">Logout</a>
            </div>
         </div>
        </center>
    </div>
    </form>
</body>
</html>
