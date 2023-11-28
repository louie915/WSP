<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="RPTIMSPayment.aspx.vb" Inherits="SPIDC.RPTIMSPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
          <br />    <br />    <br /> <br /> <br />
   

    

       <div class="container">
            <div class="section-header">
          <h2>Online Payment</h2>
            <p>RPTIMS - Payment</p>
        </div>  
                 <center>  
          <div class="col-md-6">
           <div class="details">           
             
          <!-- SLIDE 1 Certification - Select Service-->			
		  <div id="Slide_01" style="border:1px solid gray; background-color:white; padding:10px;">

        <div class="form-row">
             
              <%--  <div class="form-group col-md-12" style="text-align:left">    Transaction Number.<br />        
                <input  type="text" required runat="server" name="_oTextBoxRefNo" class="form-control" id="_oTextBoxRefNo"/>
            </div>            --%>
                

               <div class="form-group col-md-12" style="text-align:left;">    Assessment No.<br />        
                <input  type="text"  runat="server" name="_oTextBoxAssessmentNumber" readonly="true" class="form-control" id="_oTextBoxAssessmentNumber"/>
            </div>  
            
                 
            <div class="form-group col-md-12" style="text-align:left;display:none">    Transaction Date<br />        
                <input  type="text"  runat="server" name="_oTextBoxReferenceDate" class="form-control" id="_oTextBoxReferenceDate"/>
            </div>  

                 
            <div class="form-group col-md-12" style="text-align:right">    Amount<br />        
                <input  type="text"  runat="server" name="_oTextBoxAmount" readonly="true" class="form-control" style="text-align:right" id="_oTextBoxAmount"/>
            </div>           
           
           
            </div>                 
                
                   
     
              <hr />          
         
              
<div style="text-align:left;">                  Select Payment Method   <b style="color:red">*</b></div>
              <div>
              	  <div class="inputGroup">
			<input id="radio1" name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio1">Internet Payment Gateway
                 <br />
                     <i style="color:blue">Development Bank of the Philippines</i>                          
			</label>
           
		  </div>
            
		  <div class="inputGroup" style="display:none">
			<input id="radio2" name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio2">Link.BizPortal
                   <br /><i style="color:forestgreen">Land Bank of the Philippines</i>
              
			</label>
		  </div>

                   
		  <div class="inputGroup" style="display:none">
			<input id="radio3" name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio3">SPIDC Pay
                   <br /><i>Payment Testing </i>
              
			</label>
		  </div>

                  </div>
            <div class="form-row">              

                


                   <div class="form-group col-md-12" style="display:none">                                       
         
                <asp:DropDownList runat="server" ID="_oDropDownListGateWay" CssClass="form-control" >
                            
                                <asp:ListItem Value="DBP">DBP - Internet Payment Gateway</asp:ListItem>
                             <asp:ListItem Value="LBP">LBP - ePayment Portal</asp:ListItem>
                             <asp:ListItem Value="DeveloperTest">(Developer Test)</asp:ListItem>

                                                             </asp:DropDownList>
                </div>             
             </div>                    
                     


       <input runat="server" type="hidden" id="SelectedService" name="SelectedService"/>


		  <hr>
		
	<span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
    <button type="button" class="button" id="Back" onclick=" window.history.back();" >Back</button> &nbsp
    <input type="button" class="button" id="btnPayNow" onclick=" fnPayNow();" disable="false" style="cursor: not-allowed;opacity:0.5" value="Pay Now" />
    
         </span>	 		   
		   </div>
		   
		

          
                 </div>
            </div>
          
     
                    </center>
      </div>
        <script>
            function fnPayNow() {
                var gateway = document.getElementById('<%=SelectedService.ClientID%>').value
                __doPostBack(gateway, 'paynow');
            }
            function ShowNext(NextID) {
          
                switch (NextID) {

                    case "radio1":                  
                        document.getElementById('btnPayNow').style.opacity = "1";
                        document.getElementById('btnPayNow').style.cursor = "default";
                        document.getElementById('btnPayNow').disabled = false;
                        document.getElementById('<%=SelectedService.ClientID%>').value = "DBP";                       
                        break;

                    case "radio2":
                        document.getElementById('btnPayNow').style.opacity = "1";
                        document.getElementById('btnPayNow').style.cursor = "default";
                        document.getElementById('btnPayNow').disabled = false;
                        document.getElementById('<%=SelectedService.ClientID%>').value = "LBP";
                        break;

                    case "radio3":
                        document.getElementById('btnPayNow').style.opacity = "1";
                        document.getElementById('btnPayNow').style.cursor = "default";
                        document.getElementById('btnPayNow').disabled = false;
                        document.getElementById('<%=SelectedService.ClientID%>').value = "SPIDC";
                        break;
                }
            }
            </script>

</asp:Content>
