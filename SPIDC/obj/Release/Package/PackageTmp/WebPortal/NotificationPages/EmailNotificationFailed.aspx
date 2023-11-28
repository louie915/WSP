<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmailNotificationFailed.aspx.vb" Inherits="SPIDC.EmailNotificationFailed" %>

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
                <h3 runat="server" id="_oHeader"> Email Sending Failed. </h3>
                <br />
                <asp:Label ID="_oLabel_Content" runat="server" Text="Please check if your internet connection is stable then click try again."></asp:Label>
                <br />
                <br />
                     <button type="button" runat="server" class="button" id="Finish_End"  autopostback="true" >Try Again</button>
                <br />
               
            </div>
         </div>
        </center>
    </div>
    </form>
</body>
</html>
