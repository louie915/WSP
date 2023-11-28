<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EmailSent.aspx.vb" Inherits="SPIDC.EmailSent" %>

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
            <div>

                    <img src="../CSS_JS_IMG/img/email%20sent.png" />

                <h3 runat="server" id="_oHeader">An email notification has been sent to your email, <br/>
                                                Please see your email for further instruction on how to reset your password.<br />
                                                Thank you!

                </h3>
                <br />
            </div>
         </div>
     
        </center>
   

    </div>
    </form>
</body>
</html>
