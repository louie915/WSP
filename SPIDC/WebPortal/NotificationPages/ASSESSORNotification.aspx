<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ASSESSORNotification.aspx.vb" Inherits="SPIDC.ASSESSORNotification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <a href="../AssessorNewProperty.aspx">Review another Account</a>
                <br />
                <a href="../Register.aspx">Logout</a>
            </div>
         </div>
        </center>
    </div>
    </form>
</body>
</html>
