<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ApplicationSuccess.aspx.vb" Inherits="SPIDC.ApplicationSuccess" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
     
        <!-- Page Container -->
<div class="w3-container w3-content" style="max-width:1400px;margin-top:80px">    
  <!-- The Grid -->

  <div class="w3-row">
    <!-- Left Column -->
    <div class="w3-col m12">
      <!-- Profile -->
      <div class="w3-card w3-round w3-white">
        <div class="w3-container w3-center">
          <br>  <br>  <br>
               <img src="../../CSS_JS_IMG/img/complete.png" /><br />
         <h2><asp:Label ID="lblHeader" runat="server" Text="Application Successful"></asp:Label></h2>
      <div id="OK">
          <asp:Label ID="lblOK" runat="server" Text="Your Business Application has been forwarded to Business Permit & Licensing Office for review. Please check the email notification sent to your registered email for further instruction. Thank you!"></asp:Label>
           <br /><br />
          <div style="display:none;">
	
          <asp:UpdatePanel runat="server" >
              <ContentTemplate>
                    <rsweb:ReportViewer ID="_oReportPreview"
	
                      runat="server"
	
                      Height="600px" Width="100%"
	
                      ZoomMode ="PageWidth"
	
                      Font-Names="Verdana"
	
                      Font-Size="8pt"
	
                      InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
	
                      WaitMessageFont-Size="14pt">
	
                    </rsweb:ReportViewer>
              </ContentTemplate>
	
	
	
              <Triggers>
	
                  <asp:PostBackTrigger ControlID="_oReportPreview"/>
	
              </Triggers>
	
          </asp:UpdatePanel>
	
	
           <br />      
	
          
	
      </div>
	
	
        <br />
	
          <div style="display:none;">


          <asp:Button runat="server"  Text="Generate Envelope Seal" UseSubmitBehavior="False" onclick="_GenerateEnvelopeSeal" OnClientClick="target='_blank';"/>
           <asp:Button runat="server"  Text="Generate Application Form" UseSubmitBehavior="False" onclick="_GenerateApplicationForm" OnClientClick="target='_blank';"/>
              </div>    
	
         <br />
           <div style="display:none;">
               <asp:Button ID="btnExportApplicationForm" Text="Dowload Application Form" runat="server" OnClick="ExportEnvelopeApplicationForm" />
               <asp:Button ID="btnExportEnvelopSeal" Text="DownLoad Envelope Seal" runat="server" OnClick="ExportEnvelopeSeal" />
           </div>
              
      <br /> <br />
          <center>        
              <a href="../Account.aspx">Return to Home Page</a>
          </center>
          <center>
            <br /> <br />
           <div runat="server">
               <a href="https://dev.business.gov.ph/dashboard">Go to CBP Portal</a>
           </div>
              </center>   
            <%--  <button class="button"  runat="server" id="_oButtonPrint_EnvelopeSeal" onclick="_oButton_Click"  UseSubmitBehavior="False" >Print Envelope Seal</button>
          <button class="button"  runat="server" id="_oButtonPrint_AppForm" onclick="" >Print Application Form</button>--%>
      </div>
    
    
      <br/>  
     
        </div>
      </div>
      <br/>


  <!-- End Grid -->
  </div>
  
<!-- End Page Container -->
</div>
<br>



    </div>
    </form>
</body>
</html>
