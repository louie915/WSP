<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BusIncorporator.aspx.vb" Inherits="SPIDC.BusIncorporator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
 
      <!-- DropDown -->  
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

     <%--handles numeric validation--%>
     <script type="text/javascript">
         function FormatCurrency(ctrl) {
             //Check if arrow keys are pressed - we want to allow navigation around textbox using arrow keys
             if (event.keyCode == 37 || event.keyCode == 16 || event.keyCode == 38 || event.keyCode == 39 || event.keyCode == 40) {
                 return;
             }

             var val = ctrl.value;

             val = val.replace(/,/g, "")
             ctrl.value = "";
             val += '';
             x = val.split('.');
             x1 = x[0];
             x2 = x.length > 1 ? '.' + x[1] : '';

             var rgx = /(\d+)(\d{3})/;

             while (rgx.test(x1)) {
                 x1 = x1.replace(rgx, '$1' + ',' + '$2');
             }

             ctrl.value = x1 + x2;

         };

         function validate(evt) {
             var theEvent = evt || window.event;

             // Handle paste
             if (theEvent.type === 'paste') {
                 key = event.clipboardData.getData('text/plain');
             } else {
                 // Handle key press
                 var key = theEvent.keyCode || theEvent.which;
                 key = String.fromCharCode(key);
             }
             var regex = /[0-9]|\./;
             if (!regex.test(key)) {
                 theEvent.returnValue = false;
                 if (theEvent.preventDefault) theEvent.preventDefault();
             }
         };
        </script>
    <%------------------------------%>
    <div class="container">
             <center> 
          <div class="col-md-6">
           <div class="details"> 

		    <!-- SLIDE 6 - Business Information-->
            <!-- SLIDE 9 - Incorporator-->
		   <div id="Slide_09" style="border:1px solid gray; background-color:white; padding:10px;display:block;">
		      <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
                 
                 <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" 
                 style="width:80%"> 
                </div>

              </div>     <hr />

              <div style="background-color:#3B7FF2;color:white;"><strong>Incorporator's Entry</strong></div>	
                   <br />                 
              <div class="form-group col-md-13"  style="text-align:left">          First Name<br />                     
                <input   type="text" runat="server" class="form-control" id="Slide_09_FName" placeholder="First Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor First Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>

                <div class="form-group col-md-13"  style="text-align:left">          Middle Name<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_09_MName" placeholder="Middle Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>

              <div class="form-group col-md-13"  style="text-align:left">          Last Name<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_09_LName" placeholder="Last Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>
                       

                <div class="form-group col-md-13"  style="text-align:left">          Address<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_09_Address" placeholder="Address" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>
           
           
		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_09" onclick="FnRedirect('Redirect','Back')">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_09" onclick="FnRedirect('Redirect','Next')">Next</button>
</span>	 		   
               </div>	

               </div>
                   </div>
                 </center>
      </div>

      <div id="snackbar">
            <asp:Label runat="server" id="_oLabelSnackbar"/>           
        </div>    
                   
  <script>

      function FnRedirect(Action, Val)
      {

          __doPostBack(Action, Val);
      }

      function ChangeDate(x) {
          var date = new Date(document.getElementById(x).value);
          day = date.getDate();
          month = date.getMonth() + 1;
          year = date.getFullYear();
          var formatted = [month, day, year].join('/');
          localStorage.setItem(x + "_Formatted", formatted);
          document.getElementById(x).reportvalidity();
      }



	</script>         
     
      <script>
          // when page is refreshed ---------------
          if (performance.navigation.type == 1) {
              localStorage.clear();

              //    
          }
</script>

      <!-- Business Line Scripts -->  

</asp:Content>