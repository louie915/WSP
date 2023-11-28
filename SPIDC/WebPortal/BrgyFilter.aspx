<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BrgyFilter.aspx.vb" Inherits="SPIDC.BrgyFilter" %>
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

         //Added 20211108 Louie
         window.onload = function AutoFill() {
             var RegMode = sessionStorage.getItem('RegMode');
             if (RegMode == 'OAIMS') {
                 document.getElementById('<%=Slide_07_Address.ClientID%>').value = sessionStorage.getItem('business_address');
             }
         };
        </script>
    <%------------------------------%>

     <form  method="post"></form>
        
      <div class="container">
             <center> 
          <div class="col-md-6">
           <div class="details">           
           <!-- Apply for New Business Permit -->
           <!-- SLIDE 1 - Ownership Type || is Rented? -->	  

              

            <form id="frmSlide_01" method="post">  
                
              
		  <div id="Slide_01" style="border:1px solid gray; background-color:white; padding:10px;">

                 
		 <%-- <strong>Welcome to BPTIMS</strong> <br />--%>
              
              <div class="container">
  
  <div class="progress">

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
		  		   
		   </div>

            </form>             

             <!-- SLIDE 7 - Business Address-->
           <form id="frmSlide_07" method="post">	
		   <div id="Slide_07" style="border:1px solid gray; background-color:white; padding:10px;display:block;">
		     <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
                   <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" 
                 style="width:60%"> 
                </div>
              </div>     
               <hr />

              <div style="background-color:#3B7FF2;color:white;"><strong>Business Address</strong></div>
	
                   <br />       
               <div class="form-row">
                   <div class="form-group col-md-6"  style="text-align:left">Barangay<b style="color:red">*</b><br />   
                      <input type="hidden" runat="server" id="Slide_07_SelectedBrgy" />
                       <input type="hidden" runat="server" id="Slide_07_SelectedDistCode"  />
                        <input type="hidden" runat="server" id="Slide_07_SelectedBrgyDesc" /> 
                           <select required runat="server" id="Slide_07_Brgy" class="form-control" onchange="FilterBrgy('FilterBrgy','');"> <%--onchange="getSelected(this.id);"--%>
                      <option value="BRGY_001" >Sample BRGY 001</option>  
                      <option value="BRGY_002">Sample BRGY 002</option>                               
                  </select>                   
              </div>

              <div class="form-group col-md-6"  style="text-align:left">Street<b style="color:red">*</b><br />  
                   <input type="hidden" runat="server" id="Slide_07_SelectedStreet" /> 
                        <input type="hidden" runat="server" id="Slide_07_SelectedStreetDesc" /> 
                      <select required runat="server" id="Slide_07_Street"  class="form-control" onchange="getSelected(this.id)">  
                      <option value="ST_001" >Sample ST 001</option>  
                      <option value="ST_002">Sample ST 002</option>                               
                   </select>                   
              </div>          
            </div>

                <div class="form-row" style="display:none">
                   <div class="form-group col-md-6"  style="text-align:left">Group\Building<br />   
                           <select runat="server" id="Slide_07_GrpBlg"  class="form-control">  
                      <option value="GRPBLG_001" >Sample GRPBLG 001</option>  
                      <option value="GRPBLG_002">Sample GRPBLG 002</option>                               
                  </select>                   
              </div>

                   <div class="form-group col-md-6"  style="text-align:left">Sticker No:<br />   
                           <input   type="text" runat="server" class="form-control" id="Slide_07_StickerNo" placeholder="0" />                   
              </div>          
            </div>

               
                <div class="form-row" style="display:none">
                 
              <div class="form-group col-md-6" style="text-align:left;">        Plate No.<br />                   
                <input   type="text" runat="server" name="No_Male" class="form-control" id="Slide_07_PlateNo" placeholder="0" />
              </div> 
           
              <div class="form-group col-md-6" style="text-align:left;">        Stall No<br />                   
                <input   type="text" runat="server" name="No_Female" class="form-control" id="Slide_07_StallNo" placeholder="0" />
              </div>
            </div>
       
                    <div class="form-group col-md-13"  style="text-align:left">   Address  <b style="color:red">*</b><br />                     
                <textarea   runat="server" required class="form-control" id="Slide_07_Address" placeholder="House No./Bldg. No., Unit No., Building Name, Subdivision" maxlength="150" />
              </div> 
           
		  <hr/>
		
		  <span style="display:flex;justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_07" runat="server" onclick="FnRedirect('Redirect','Back')">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_07" runat="server" onclick="FnRedirect('Redirect','Next')">Next</button>
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
          
          __doPostBack(Action, Val + "_" + document.getElementById('<%=Slide_07_Street.ClientID%>').value + "_" + document.getElementById('<%=Slide_07_Brgy.ClientID%>').value + "_"  + document.getElementById('<%=Slide_07_Address.ClientID%>').value);
          <%--if (Val == "Back") {
              __doPostBack(Action, Val + document.getElementById('<%=Slide_07_Street.ClientID%>').value + document.getElementById('<%=Slide_07_Brgy.ClientID%>').value + document.getElementById('<%=Slide_07_Address.ClientID%>').value);
          }
          if (document.getElementById('<%=Slide_07_Address.ClientID%>').value !== '')
          {
              __doPostBack(Action, Val + document.getElementById('<%=Slide_07_Street.ClientID%>').value + document.getElementById('<%=Slide_07_Brgy.ClientID%>').value + document.getElementById('<%=Slide_07_Address.ClientID%>').value);
          } --%>         
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

      function getSelected(sel) {
          switch (sel) {
              case "Slide_07_Brgy":
                  var sel = document.getElementById('<%=Slide_07_Brgy.ClientID%>')
                      var DistCode_BrgyCode = document.getElementById('<%=Slide_07_Brgy.ClientID%>').value
                      var parts = DistCode_BrgyCode.split('_', 2);
                      var DistCode = parts[0];
                      var BrgyCode = parts[1];

                      localStorage.setItem("Slide_07_Brgy", sel.options[sel.selectedIndex].text);

                      document.getElementById('<%=Slide_07_SelectedDistCode.ClientID%>').value = DistCode;
                          document.getElementById('<%=Slide_07_SelectedBrgy.ClientID%>').value = BrgyCode;

                  var filter = document.getElementById('<%=Slide_07_Brgy.ClientID%>').value;
                      $('#Slide_07_Street option').each(function () {
                          if ($(this).val() == filter) {
                              $(this).show();
                          } else {
                              $(this).hide();
                          }
                          $('#Slide_07_Street').val(filter);
                      });
                      break;

              case "Slide_07_Street":
                  document.getElementById('<%=Slide_07_SelectedStreet.ClientID%>').value = document.getElementById('<%=Slide_07_Street.ClientID%>').value;
                  
                          break;                      
                 }
             }

             function FilterBrgy(Action, Val) {
                 var sel = document.getElementById('<%=Slide_07_Brgy.ClientID%>')
              var DistCode_BrgyCode = document.getElementById('<%=Slide_07_Brgy.ClientID%>').value
              var parts = DistCode_BrgyCode.split('_', 2);
              var DistCode = parts[0];
              var BrgyCode = parts[1];

              localStorage.setItem("Slide_07_Brgy", sel.options[sel.selectedIndex].text);
              
              var filter = document.getElementById('<%=Slide_07_Brgy.ClientID%>').value;
              document.getElementById('<%=Slide_07_SelectedBrgy.ClientID%>').value = filter;             
              __doPostBack(Action, filter)
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