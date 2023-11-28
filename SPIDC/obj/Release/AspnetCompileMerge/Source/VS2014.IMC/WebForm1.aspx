<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="WebForm1.aspx.vb" Inherits="IMC.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<body>
	<header>
		<style>
		
	.inputGroup {
	  background-color: #fff;
	  display: block;
	  margin: 10px 0;
	  position: relative;
	}
	.inputGroup label {
	  padding: 12px 30px;
	  width: 100%;
	  display: block;
	  text-align: left;
	  color: #3C454C;
	  cursor: pointer;
	  position: relative;
	  z-index: 2;
	  transition: color 200ms ease-in;
	  overflow: hidden;
	}
	.inputGroup label:before {
	  width: 10px;
	  height: 10px;
	  border-radius: 50%;
	  content: '';
	  background-color: #5562eb;
	  position: absolute;
	  left: 50%;
	  top: 50%;
	  -webkit-transform: translate(-50%, -50%) scale3d(1, 1, 1);
			  transform: translate(-50%, -50%) scale3d(1, 1, 1);
	  transition: all 300ms cubic-bezier(0.4, 0, 0.2, 1);
	  opacity: 0;
	  z-index: -1;
	}
	.inputGroup label:after {
	  width: 32px;
	  height: 32px;
	  content: '';
	  border: 2px solid #D1D7DC;
	  background-color: #fff;
	  background-image: url("data:image/svg+xml,%3Csvg width='32' height='32' viewBox='0 0 32 32' xmlns='http://www.w3.org/2000/svg'%3E%3Cpath d='M5.414 11L4 12.414l5.414 5.414L20.828 6.414 19.414 5l-10 10z' fill='%23fff' fill-rule='nonzero'/%3E%3C/svg%3E ");
	  background-repeat: no-repeat;
	  background-position: 2px 3px;
	  border-radius: 50%;
	  z-index: 2;
	  position: absolute;
	  right: 30px;
	  top: 50%;
	  -webkit-transform: translateY(-50%);
			  transform: translateY(-50%);
	  cursor: pointer;
	  transition: all 200ms ease-in;
	}
	.inputGroup input:checked ~ label {
	  color: #fff;
	}
	.inputGroup input:checked ~ label:before {
	  -webkit-transform: translate(-50%, -50%) scale3d(56, 56, 1);
			  transform: translate(-50%, -50%) scale3d(56, 56, 1);
	  opacity: 1;
	}
	.inputGroup input:checked ~ label:after {
	  background-color: #54E0C7;
	  border-color: #54E0C7;
	}
	.inputGroup input {
	  width: 32px;
	  height: 32px;
	  order: 1;
	  z-index: 2;
	  position: absolute;
	  right: 30px;
	  top: 50%;
	  -webkit-transform: translateY(-50%);
			  transform: translateY(-50%);
	  cursor: pointer;
	  visibility: hidden;
	}


	*,
	*::before,
	*::after {
	  box-sizing: inherit;
	}

	html {
	  box-sizing: border-box;
	}

	code {
	  background-color: #9AA3AC;
	  padding: 0 8px;  	  
	 
	}
	
	.button {
  background-color: #5562eb; /* Green */
  border: none;
  color: white;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
 right: 0;
  
}

	</style>
		<link href="https://fonts.googleapis.com/css?family=Fira+Sans" rel="stylesheet">
	</header>
    <center>

	        
		<div class="col-md-5">		
            <br />	    <br />	    <br />	    <br />	 
			<!-- SLIDE 1 -->
			
		   <div id="Slide_01" style="border:1px solid gray; background-color:white; padding:10px;height:585px">
		   Which Onlice Serivice do you want to use?
              
		  <div class="inputGroup">
			<input id="radio1" name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio1">Business Permit</label>
		  </div>
		  <div class="inputGroup">
			<input id="radio2" name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio2">Real Property</label>
		  </div>
		  
		  <input type="hidden" id="SelectedService" name="SelectedService">
		  
		  <hr>
		  
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
    <button type="button" class="button" id="Next_01" onclick="ShowNext(this.id)" disabled=true style="cursor: not-allowed;opacity:0.5">Next</button>
</span>	 		   
		   </div>
		   
		   <!-- SLIDE 2 BPLTIMS-->
		   <div id="Slide_02" style="border:1px solid gray; background-color:white; padding:10px;display:none;height:585px">
		     What do you want to do?
		  <div class="inputGroup">
			<input id="radio3" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio3">Apply for New Business</label>
		  </div>
		  <div class="inputGroup">
			<input id="radio4" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio4">Renew Business Permit</label>
		  </div>
		   <div class="inputGroup">
			<input id="radio5" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio5">Request for Certification</label>
		  </div>
		  <div class="inputGroup">
			<input id="radio6" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio6">Application Status Inquiry</label>
		  </div>
		   <div class="inputGroup">
			<input id="radio7" name="Slide_02" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio7">Online Payment</label>
		  </div>
		  
		  <hr>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="button" id="Back_02" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="button" id="Next_02" onclick="ShowNext(this.id)" style="cursor: not-allowed;opacity:0.5">Proceed</button>
</span>	 		   

		   </div>
		   
		   <!-- SLIDE 3  - RPTIMS-->
		
		   <div id="Slide_03" style="border:1px solid gray; background-color:white; padding:10px;display:none;height:585px">
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
		   
		   
		   
		   
		  
		</div>	
		 </center>
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
	                        location.replace("https://www.google.com")
	                        break;

	                    case "BPRenew":
	                        alert("go to " + document.getElementById("SelectedService").value)
	                        break;
	                    case "BPCertification":
	                        alert("go to " + document.getElementById("SelectedService").value)
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
	

	</body>

</asp:Content>
