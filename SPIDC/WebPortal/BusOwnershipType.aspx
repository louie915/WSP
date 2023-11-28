<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BusOwnershipType.aspx.vb" Inherits="SPIDC.BusOwnershipType" %>
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
    <script>
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };
    </script>
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

            <form id="frmSlide_01" method="post">  
                
              
		  <div id="Slide_01" style="border:1px solid gray; background-color:white; padding:10px;">

                 <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
		 <%-- <strong>Welcome to BPTIMS</strong> <br />--%>
              
              <div class="container">
  
  <div class="progress">
    <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width:10%">
    </div>
  </div>     
</div>
 <hr />
              
                <div class="instruct">
                    <ul style="padding:0px 0px 0px 35px;">
                        <li> Fill out all neccesary information.</li>
                        <li> Fields with (<span style="color:red;font-size:large">*</span>) indicator are required. </li>
                    </ul>
                </div>
              <br />
              <div style="text-align:left;">Select Ownership Type <b style="color:red">*</b></div>
              
                              
            <div class="form-row">              
                   <div class="form-group col-md-12">            
                  <select required runat="server" id="Slide_01_OwnershipType" onchange="OwnershipChange(this.value)" class="form-control">   
                      <option value="" selected>Select Type</option>  
                      <option value="Cooperative" >Cooperative</option>  
                      <option value="Corporation">Corporation</option>  
                      <option value="Foreign" >Foreign</option>  
                      <option value="Partnership" >Partnership</option>     
                      <option value="Single" >Single Proprietorship</option>                                
                  </select>
                </div>             
             </div>                              

              <hr />
                <div style="text-align:left;">Is your Business Establishment Rented? <b style="color:red">*</b></div>
            <div class="inputGroup">

			<input id="radio1" runat="server" required name="Slide_01" type="radio"/>
			<label for="radio1">Yes 
              
			</label>
		  </div>

		  <div class="inputGroup">
			<input id="radio2" runat="server" required name="Slide_01" type="radio"/>
			<label for="radio2">No
       
			</label>
		  </div>
		  
		  <input type="hidden" runat="server" id="SelectedYesNo" name="SelectedYesNo"/>
		  <input type="hidden" runat="server" id="SelectedOwnership" name="SelectedOwnership"/>

		  <hr/>
		  
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
              <button type="button" class="btn btn-primary" id="Home_01" onclick="javascript:history.back()">Back</button> &nbsp
              <button type="button" class="btn btn-success" id="Next_01" onclick="FnRedirect('Redirect','Next')">Next</button>
          
</span>	 		   
		   </div>
            </form>  

               </div>
                   </div>
                 </center>
      </div>

      <div style="z-index:1 !Important;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <div id="snackbar" style="position:absolute;z-index:1 !Important;">
                    <asp:Label runat="server" id="_oLabelSnackbar"/>           
                    </div>
                    <div id="snackbargreen" style="position:absolute;z-index:1 !Important;">
                        <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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