<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="BPLTIMSCertifications.aspx.vb" Inherits="IMC.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS_JS_IMG/css/multi-slide-div.css" rel="stylesheet" />
    <br /> <br /> <br /> <br />  
 
       <div class="container">
                 
      <div class="row">      
          <div class="col-md-6">
           <div class="details">           
             
          <!-- SLIDE 1 -->			
		  <div id="Slide_01" style="border:1px solid gray; background-color:white; padding:10px;">
          <center>
		     <Strong>Welcome to BPTIMS Certification</Strong> <br />Which Onlice Serivice do you want to use?
          </center>
              
		  <div class="inputGroup">
			<input id="radio1" name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio1">Request Business Certification 
                   <br /><i>Translate Here</i>
			</label>
           
		  </div>
		  <div class="inputGroup">
			<input id="radio2" name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio2">Check Certification Status
                   <br /><i>Translate Here</i>
			</label>
		  </div>
		  
		  <input type="hidden" id="SelectedService" name="SelectedService">
		  
		  <hr>
		  
	<span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
    <button type="button" class="button" id="Home_01" onclick="ShowNext(this.id)" >Home</button> &nbsp
    <button type="button" class="button" id="Next_01" onclick="ShowNext(this.id)" disabled=true style="cursor: not-allowed;opacity:0.5">Next</button>
    </span>	 		   
		   </div>
		   
		   <!-- SLIDE 2 BPLTIMS-->
		   <div id="Slide_02" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
		     Select the Business you want to apply for Certification:
		  <div class="inputGroup">

			<input id="radio3" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio3">Apply for New Business Permit 
                   <br /><i>Mag-apply para sa Bagong Negosyo</i>
			</label>
		  </div>

		  <div class="inputGroup">
			<input id="radio4" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio4">Renew Business Permit
                   <br /><i>Translate Here</i>
			</label>
		  </div>

		   <div class="inputGroup">
			<input id="radio5" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio5">Request for Certification
                   <br /><i>Translate Here</i>
			</label>
		  </div>

		  <div class="inputGroup">
			<input id="radio6" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio6">Application Status Inquiry
                   <br /><i>Translate Here</i>
			</label>
		  </div>

		   <div class="inputGroup">
			<input id="radio7" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio7">Online Payment
                   <br /><i>Translate Here</i>
			</label>
		  </div>
               		  
		  <hr>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="button" id="Back_02" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="button" id="Next_02" onclick="ShowNext(this.id)" style="cursor: not-allowed;opacity:0.5">Proceed</button>
</span>	 		   

		   </div>
		   
		   <!-- SLIDE 3  - RPTIMS-->
		
		   <div id="Slide_03" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
		          What do you want to do?
		  <div class="inputGroup">
			<input id="radio8" name="Slide_03" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio8">Request Certification</label>
		  </div>
		  <div class="inputGroup">
			<input id="radio9" name="Slide_03" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio9">Assessment Billing</label>
		  </div>		 
		   <div class="inputGroup">
			<input id="radio10" name="Slide_03" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio10">Online Payment</label>
		  </div>
		  
		  <hr>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="button" id="Back_03" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="button" id="Next_03" onclick="ShowNext(this.id)" style="cursor: not-allowed;opacity:0.5">Proceed</button>
</span>	 		   

		   </div>
               	<script>
               	    function ShowNext(NextID) {
               	        switch (NextID) {

               	            case "radio1":
               	                document.getElementById("Next_01").style.opacity = "1";
               	                document.getElementById("Next_01").style.cursor = "default";
               	                document.getElementById("Next_01").disabled = false;
               	                document.getElementById("SelectedService").value = "BPLTIMS";
               	                break;

               	            case "radio2":
               	                document.getElementById("Next_01").style.opacity = "1";
               	                document.getElementById("Next_01").style.cursor = "default";
               	                document.getElementById("Next_01").disabled = false;
               	                document.getElementById("SelectedService").value = "RPTIMS";
               	                break;
               	            case "radio3":
               	                document.getElementById("Next_02").style.opacity = "1";
               	                document.getElementById("Next_02").style.cursor = "default";
               	                document.getElementById("Next_02").disabled = false;
               	                document.getElementById("SelectedService").value = "BPNew";
               	                break;
               	            case "radio4":
               	                document.getElementById("Next_02").style.opacity = "1";
               	                document.getElementById("Next_02").style.cursor = "default";
               	                document.getElementById("Next_02").disabled = false;
               	                document.getElementById("SelectedService").value = "BPRenew";
               	                break;
               	            case "radio5":
               	                document.getElementById("Next_02").style.opacity = "1";
               	                document.getElementById("Next_02").style.cursor = "default";
               	                document.getElementById("Next_02").disabled = false;
               	                document.getElementById("SelectedService").value = "BPCertification";
               	                break;
               	            case "radio6":
               	                document.getElementById("Next_02").style.opacity = "1";
               	                document.getElementById("Next_02").style.cursor = "default";
               	                document.getElementById("Next_02").disabled = false;
               	                document.getElementById("SelectedService").value = "BPInquiry";
               	                break;
               	            case "radio7":
               	                document.getElementById("Next_02").style.opacity = "1";
               	                document.getElementById("Next_02").style.cursor = "default";
               	                document.getElementById("Next_02").disabled = false;
               	                document.getElementById("SelectedService").value = "BPPayment";
               	                break;
               	            case "radio8":
               	                document.getElementById("Next_03").style.opacity = "1";
               	                document.getElementById("Next_03").style.cursor = "default";
               	                document.getElementById("Next_03").disabled = false;
               	                document.getElementById("SelectedService").value = "RPCertification";
               	                break;
               	            case "radio9":
               	                document.getElementById("Next_03").style.opacity = "1";
               	                document.getElementById("Next_03").style.cursor = "default";
               	                document.getElementById("Next_03").disabled = false;
               	                document.getElementById("SelectedService").value = "RPBilling";
               	                break;
               	            case "radio10":
               	                document.getElementById("Next_03").style.opacity = "1";
               	                document.getElementById("Next_03").style.cursor = "default";
               	                document.getElementById("Next_03").disabled = false;
               	                document.getElementById("SelectedService").value = "RPPayment";
               	                break;


               	            case "Next_01":
               	                document.getElementById("Next_02").disabled = false;
               	                document.getElementById("Next_03").disabled = false;
               	                switch (document.getElementById("SelectedService").value) {
               	                    case "BPLTIMS":
               	                        document.getElementById("Slide_01").style.display = "none";
               	                        document.getElementById("Slide_02").style.display = "block";
               	                        break;

               	                    case "RPTIMS":
               	                        document.getElementById("Slide_01").style.display = "none";
               	                        document.getElementById("Slide_03").style.display = "block";
               	                        break;
               	                }

               	                break;

               	            case "Next_02":
               	                switch (document.getElementById("SelectedService").value) {
               	                    case "BPNew":
               	                        alert("go to " + document.getElementById("SelectedService").value)
               	                        //location.replace("https://www.google.com")
               	                        break;

               	                    case "BPRenew":
               	                        alert("go to " + document.getElementById("SelectedService").value)
               	                        break;
               	                    case "BPCertification":
               	                        //alert("go to " + document.getElementById("SelectedService").value)
               	                        location.replace("../VS2014.BPLTIMS/BPLTIMSCertifications.aspx")

               	                        break;
               	                    case "BPInquiry":
               	                        alert("go to " + document.getElementById("SelectedService").value)
               	                        break;
               	                    case "BPPayment":
               	                        alert("go to " + document.getElementById("SelectedService").value)
               	                        break;
               	                }
               	                break;

               	            case "Next_03":
               	                switch (document.getElementById("SelectedService").value) {
               	                    case "RPCertification":
               	                        alert("go to " + document.getElementById("SelectedService").value)
               	                        //location.replace("https://www.google.com")					  
               	                        break;
               	                    case "RPBilling":
               	                        alert("go to " + document.getElementById("SelectedService").value)
               	                        break;
               	                    case "RPPayment":
               	                        alert("go to " + document.getElementById("SelectedService").value)
               	                        break;
               	                }
               	                break;


               	            case "Back_02":
               	            case "Back_03":
               	                document.getElementById("Slide_01").style.display = "block";
               	                document.getElementById("Slide_02").style.display = "none";
               	                document.getElementById("Slide_03").style.display = "none";
               	                document.getElementById("Next_01").style.opacity = "0.5";
               	                document.getElementById("Next_01").style.cursor = "not-allowed";
               	                document.getElementById("Next_01").disabled = true;
               	                document.getElementById("SelectedService").value = "";
               	                break;


               	            default:
               	                // code block
               	        }

               	    }
	</script>
            </div>
          </div>     
                
      </div>
          
      </div>
   
</asp:Content>
