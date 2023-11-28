<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PaymentNotification.aspx.vb" Inherits="SPIDC.PaymentNotification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Notification</title>
     <link href="../CSS_JS_IMG/OS-JS-CSS/Css/Online-Services.css" rel="stylesheet" />     
</head>
<body> 
   
</body>

     <%-- KERIDELIVERY--%>
    <center>
         <div id="_oDivCourier" runat="server"  >
                                       
                                       <p style="font-style:italic">
                                           The original business permit certificate, receipt, barangay clearance and other documents that will be issued by BPLO will be delivered by KERIDELIVERY using the details submitted to their platform.
                                       </p>
                                        <p style="font-style:italic"> Click on the link provided below to proceed to KERIDELIVERY platform. <br /> Use the Tax Order of Payment (T.O.P) account number as your delivery reference number.</p>
                                     
                                       <asp:HyperLink ID="_oHl_Keri" CssClass="nav-link font-weight-bold text-primary "  runat="server" Target="_blank" > GO TO KERI COURIER SERVICE >> </asp:HyperLink>

                                       <br />
                                       <br />

                                         
     </div>

    </center>
     <%-- KERIDELIVERY--%>
</html>
