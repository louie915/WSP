<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rpt_DBPPayment.aspx.vb" Inherits="SPIDC.rpt_DBPPayment" %>





<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>



<script type="text/javascript">
    function querySt(ji) {
        hu = window.location.search.substring(1);
        gy = hu.split("&");
        for (i = 0; i < gy.length; i++) {
            ft = gy[i].split("=");
            if (ft[0] == ji) {
                return ft[1];
            }
        }
    }

    function onLoadSubmit() {

        $("referenceCode").value = querySt("referenceCode");
        $("terminalID").value = querySt("terminalID");       
        $("amount").value = querySt("amount");     
        $("securityToken").value = querySt("securityToken");      

        document.frm.submit();
    }
       
</script>

 
<script>
    function $(s) {
        return document.getElementById(s);
    }
      
    function setAction(sURL) {
        $("frm").action = sURL;
        console.log(sURL);
    }

    function setAction2(sURL) {
        $("frm2").action = sURL;
        console.log(sURL);
    }
  
</script>
</head>
<body onload="onLoadSubmit()">
Redirecting to DBP Payment Portal...
   <%-- 
        https://ptsv2.com/t/6yota-1560223081/post
        http://122.55.65.13/VS2014.WA.BPLTIMS/pages/business/BPLTAS/Payment/pPostback.aspx
        http://localhost:34829/pages/business/BPLTAS/Payment/pPostback.aspx
        http://120.28.92.33/VS2014.BPLTIMS/PaymentConfirmation.aspx
        http://localhost:50101/VS2014.BPLTIMS/PaymentConfirmation.aspx
       2020
       http://120.28.92.33/PaymentPostBack/OnlinePaymentConfirmation.aspx
       http://localhost:50101/PaymentPostBack/OnlinePaymentConfirmation.aspx
   --%>
        <table style="display: none;">
            <form id="frm" name="frm" action="https://testipg.apollo.com.ph:8443/transaction/verify" method="POST" > 
                 <tr><td>terminalID</td><td><input type="text" id="terminalID" name="terminalID"></td></tr>
                 <tr><td>referenceCode</td><td><input type="text" id="referenceCode" name="referenceCode"></td></tr>
                 <tr><td>amount</td><td><input type="text" id="amount" name="amount" ></td></tr>
                 <tr><td>serviceType</td><td><input type="text" id="serviceType" name="serviceType" value="Real Property" ></td></tr>                 
                 <tr><td>securityToken</td><td><input type="text" id="securityToken" name="securityToken"></td></tr>                 
                 <tr><td>returnURL</td><td><input type="text" name="returnURL" value="http://120.28.92.33/PaymentPostBack/OnlinePaymentConfirmation.aspx"></td></tr>
                 <tr><td></td><td><input type="submit" value="POST"></td></tr>
            </form>
        </table>
  
</body>
</html>
