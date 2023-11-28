<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Report.aspx.vb" Inherits="SPIDC.Report" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>

  <%--    <link href=" ../../CSS_JS_IMG/css/style.css" rel="stylesheet">--%>
   

     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

        <script>
            //SNACKBAR - Welcome       
            function SnackbarGreen() {
                var x = document.getElementById("snackbargreen");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
            }
            function Snackbar() {
                var x = document.getElementById("snackbar");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
          <center>
    <div>
         <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
         
         <div id="snackbar" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbar"/>           
        </div>
        <div id="snackbargreen" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
        </div>
            
        <br />

        <div>

            <div>
                 <asp:UpdatePanel runat="server" >
                    <ContentTemplate>
                          <rsweb:ReportViewer ID="_oRpt_EnvelopeSeal" 
                           runat="server"
                            AsynRendering="true"
                            SizeToReportContent = "true">
                          </rsweb:ReportViewer>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="_oRpt_EnvelopeSeal"/>
                    </Triggers>
                </asp:UpdatePanel>
                    <br />
                 <div>
                     <div id ="_oDivRecomppute" runat="server">
                         Select Number of Quarters to Pay &nbsp 
                        <asp:DropDownList ID="_oDDL_Quarters" runat="server" CssClass="input" >
                        </asp:DropDownList>
                         &nbsp &nbsp 
                         <asp:Button ID="_oButtonRecompute" class="button"  runat="server" OnClick="_RecomputeTOP" Text="Re-Compute Billing" CssClass="input"  />
                         <br />
                     </div>
                     <br />
                     <div>
                         <asp:ImageButton  ID="btnExport" CssClass="buttons" runat="server" ImageUrl="../../CSS_JS_IMG/img/DownloadPDF.png" OnClick="Export" />
                        <%--  <asp:Button ID="btnExport" CssClass="buttons"  Text="Download" runat="server" OnClick="Export" />--%>
                     </div>
                        <br />
                     <div id="_oDivPayment" runat="server" style="display:none">
                            <asp:HyperLink ID="_oHyperLinkProceedToPayment" Visible="false" CssClass="button" runat="server"> Proceed to Payment </asp:HyperLink>
                          <asp:Button ID="_oBtnPaymentNewBP" class="button"  runat="server" OnClick="_Initialize_ProceedToPayment" Text="Proceed to Payment" CssClass="input"  />

                    </div>
                     <br />

                        <%--FOR DELIVERY--%>
                                   <div id="_oDivDeliver" style="display:none;" >
                                       
                                       <p style="font-style:italic">
                                           The original business permit certificate, receipt, barangay clearance and other documents that will be issued by BPLO will be delivered by KERIDELIVERY using the details submitted to their platform.
                                       </p>
                                        <p style="font-style:italic"> Click on the link provided below to proceed to KERIDELIVERY platform. <br /> Use the Tax Order of Payment (T.O.P) account number as your delivery reference number.</p>
                                     
                                       <asp:HyperLink 
                                           ID="HyperLink1"  
                                           runat="server" 
                                           Target="_blank"  
                                           NavigateUrl="https://kericity-portal.keridelivery.com/?department=muntinlupa_bplo&redirect_url=https://best.muntinlupacity.gov.ph" 
                                           > GO TO KERI COURIER SERVICE >> </asp:HyperLink>

                                       <br />
                                       <br />

                                          <div  >
                                             <asp:HyperLink ID="_oHyperLinkProceedToPayment2" CssClass="button" runat="server" > PROCEED TO PAYMENT </asp:HyperLink>
                                           </div>
                                   </div>

                    
                 </div>
                
            </div>

        </div>
        
          <br />
    </div>
               </center>
    </form>
</body>
</html>
