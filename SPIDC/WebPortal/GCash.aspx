<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GCash.aspx.vb" Inherits="SPIDC.GCash" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>   
<body>
  


    <form id="form1" runat="server" >
       
          <asp:ScriptManager runat="server">
    </asp:ScriptManager>
           <rsweb:reportviewer ID="Report_EOR" 
                        runat="server"
                        AsynRendering="true"
                        SizeToReportContent = "true">
                      </rsweb:reportviewer>
          <asp:UpdatePanel runat="server">
         <ContentTemplate>
                 

             <asp:Timer runat="server" ID="Timer1" OnTick="Timer1_Tick"></asp:Timer>
  <div style="display:none">
        <input type="text" runat="server" id="txtacquirementId" placeholder="acquirementId" />
            <input type="text" runat="server" id="txtmerchantId"  placeholder="merchantId"/>
            <input type="button" runat="server" id="btnCancel" value="Cancel Transaction" />
            
  </div>
          
   
      
       

       
    <div style="width:50%;display:none">
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
        <button onclick="do_preview();">submit</button>
        merctid
        <input type="text" id="merctid" runat="server"/>
        transid
        <input type="text" id="transid" runat="server"/>
        acqid
        <input type="text" id="acqid" runat="server"/>
       
    </div>

                </ContentTemplate>
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"/>
              </Triggers>
     </asp:UpdatePanel>
    </form>
     <script>

     

         function do_preview() {
             __doPostBack("", "");
         }


         function countdown(elementName, minutes, seconds) {
             var element, endTime, hours, mins, msLeft, time;

             function twoDigits(n) {
                 return (n <= 9 ? "0" + n : n);
             }

             function updateTimer() {
                 msLeft = endTime - (+new Date);
                 if (msLeft < 1000) {
                     element.innerHTML = "Time is up!";
                     stopTimer();
                 } else {
                     time = new Date(msLeft);
                     hours = time.getUTCHours();
                     mins = time.getUTCMinutes();
                     element.innerHTML = (hours ? hours + ':' + twoDigits(mins) : mins) + ':' + twoDigits(time.getUTCSeconds());
                     setTimeout(updateTimer, time.getUTCMilliseconds() + 500);
                 }
             }

             element = document.getElementById(elementName);
             endTime = (+new Date) + 1000 * (60 * minutes + seconds) + 500;
             updateTimer();
         }

         countdown("ten-countdown", 10, 0);



        </script>
</body>
</html>
