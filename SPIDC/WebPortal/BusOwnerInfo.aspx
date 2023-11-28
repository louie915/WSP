<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BusOwnerInfo.aspx.vb" Inherits="SPIDC.BusOwnerInfo" %>
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

         function validate(evt)
         {
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
                 document.getElementById('<%=Slide_08_Fname.ClientID%>').value = sessionStorage.getItem('AR_first_name');
                 document.getElementById('<%=Slide_08_Mname.ClientID%>').value = sessionStorage.getItem('AR_middle_name');
                 document.getElementById('<%=Slide_08_Lname.ClientID%>').value = sessionStorage.getItem('AR_last_name');
                 document.getElementById('<%=Slide_08_Suffix.ClientID%>').value = sessionStorage.getItem('AR_suffix');

                 if (sessionStorage.getItem('AR_sex') == 'M') {
                     document.getElementById('<%=Slide_08_Gender.ClientID%>').value = 'Male';
                 }
                 else {
                     document.getElementById('<%=Slide_08_Gender.ClientID%>').value = 'Female';
                 };

                 //alert(sessionStorage.getItem('AR_nationality'));

                 if (sessionStorage.getItem('AR_nationality') == 'Filipino') {
                     document.getElementById('<%=Slide_08_Citizenship.ClientID%>').value = 'FIL'
                 };

                 document.getElementById('<%=Slide_08_Email.ClientID%>').value = sessionStorage.getItem('AR_email_address');
                 document.getElementById('<%=Slide_08_AlternateEmail.ClientID%>').value = sessionStorage.getItem('AR_alternate_email_address');
                 document.getElementById('<%=Slide_08_Address.ClientID%>').value = sessionStorage.getItem('AR_address');

             }
         };
        </script>
    <%------------------------------%>
        
      <div class="container">
             <center> 
          <div class="col-md-6">
           <div class="details">           
           <!-- Apply for New Business Permit -->
           <!-- SLIDE 1 - Ownership Type || is Rented? -->	  

              

<%--<%--            <form id="frmSlide_01" method="post">  
                
              
		  <div id="Slide_01" style="border:1px solid gray; background-color:white; padding:10px;">

                 
		 <%-- <strong>Welcome to BPTIMS</strong> <br />--%>
              
              <%--<div class="container">
  
  <div class="progress">

  </div>     
</div>--%>
 <%--<hr />--%>
              
                <%--<div class="instruct">
                    <ul style="padding:0px 0px 0px 35px;">
                        <li> Fill out all neccesary information.</li>
                        <li> Fields with (<span style="color:red;font-size:large">*</span>) indicator are required. </li>
                    </ul>
                </div>--%>
              <%--<br />--%>
		  		   
		   <%--</div>--%>

            <%--</form>   --%>        

             <!-- SLIDE 7 - Business Address-->
                      <!-- SLIDE 8 - Business Owner Information-->
            <form id="frmSlide_08" method="post" onsubmit="SaveAll()">	
		   <div id="Slide_08" style="border:1px solid gray; background-color:white; padding:10px;display:block;">
		      <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
                 <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" 
                 style="width:80%">
                </div>
              </div>      
                <hr />

              <div style="background-color:#3B7FF2;color:white;"><strong>Business Owner Information</strong></div>
	
                   <br />       
          
              <div class="form-group col-md-13"  style="text-align:left">          First Name<b style="color:red">*</b><br />                     
                <input type="text" required runat="server" class="form-control" id="Slide_08_Fname" name="Slide_08_Fname" placeholder="First Name" title="First Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" CausesValidation="False" maxlength="25"/>
                <input type="hidden" id="Slide_08_FnameHdn" name="Slide_08_FnameHdn"/>
             
                   </div>

                <div class="form-group col-md-13"  style="text-align:left">          Middle Name<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_08_Mname" placeholder="Middle Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Middle Name" maxlength="25" />
              <input type="hidden" id="Slide_08_MnameHdn" name="Slide_08_MnameHdn"/>
                </div>

              <div class="form-group col-md-13"  style="text-align:left">          Last Name<b style="color:red">*</b><br />                    
                <input  type="text" required runat="server" class="form-control"  id="Slide_08_Lname" placeholder="Last Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name" maxlength="25" />
              <input type="hidden" id="Slide_08_LnameHdn" name="Slide_08_LnameHdn"/>
              </div>

               <div class="form-group col-md-13"  style="text-align:left">          Suffix<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_08_Suffix" placeholder="Jr., Sr., VI" pattern="[\s a-zA-ZñÑ .]+" oninput="this.reportValidity()" title="Suffix" maxlength="10" />
              <input type="hidden" id="Slide_08_SuffixHdn" name="Slide_08_SuffixHdn"/>
               </div>
          

                <div class="form-row">
                <div class="form-group col-md-6"  style="text-align:left">Gender<b style="color:red">*</b><br />   
                           <select required runat="server" id="Slide_08_Gender"  class="form-control">  
                      <option value="Male" >Male</option>  
                      <option value="Female">Female</option>                               
                  </select> 
                    <input type="hidden" id="Slide_08_GenderHdn" name="Slide_08_GenderHdn"/>                  
                </div>

                <div class="form-group col-md-6"  style="text-align:left">Citizenship<b style="color:red">*</b><br />   
                    <input type="hidden" runat="server" id="Slide_08_SelectedCitizenship" /> 
                  <select required runat="server" id="Slide_08_Citizenship"  class="form-control">  
                      <option value="Filipino">Filipino</option> 
                      <option value="American" >American</option>  
                      <option value="Chinese" >Chinese</option>                       
                      <option value="Japanese">Japanese</option>                                     
                  </select>  
                    <input type="hidden" id="Slide_08_CitizenshipHdn" name="Slide_08_CitizenshipHdn"/>                 
              </div>       
            </div>
        
                <div class="form-group col-md-13"  style="text-align:left">          Address<b style="color:red"> *</b><br />
                   &nbsp <input type="checkbox" runat="server" id="Slide_08_Check" onchange="GetAddress();">  <label id="Label2" onclick="document.getElementById('Slide_08_Check').click();"  class="mt-1 ml-1" runat="server">check if Business Address is the same as Owner Address</label>
                  <textarea required runat="server" class="form-control"  id="Slide_08_Address" placeholder="Address" maxlength="150" />
                    <input type="hidden" runat="server" id="Slide_08_AddressHdn" name="Slide_08_AddressHdn"/>
              </div>
         
                <div class="form-group col-md-13"  style="text-align:left">          Telephone No.<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_08_TelNo" placeholder="8###-##-##"  onkeyup="return addHyphen(event)" title="Telephone No." maxlength="10" />
              <input type="hidden" id="Slide_08_TelNoHdn" name="Slide_08_TelNoHdn"/>  
                </div>
               
                <div class="form-row">
                 
              <div class="form-group col-md-6" style="text-align:left;display:none">        Email Address<br />                   
                <input   type="text" runat="server" class="form-control" id="Slide_08_Email" placeholder="Sample@email.com" maxlength="100" />
              <input type="hidden" id ="Slide_08_EmailHdn" name="Slide_08_EmailHdn"/> 
              </div> 
           
              <div class="form-group col-md-6" style="text-align:left">       Alternate Email<br />                   
                <input   type="text" runat="server" class="form-control" id="Slide_08_AlternateEmail" placeholder="SampleAlternate@email.com" maxlength="100" />
              <input type="hidden" id="Slide_08_AlternateEmailHdn" name="Slide_08_AlternateEmailHdn"/> 
              </div>
            </div>           
		  <hr/>
		
		  <span style="display:flexbox; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_08" onclick="FnRedirect('Redirect','Back')">Back</button> &nbsp

              <%--<input type="submit" class="btn btn-success" name="Next" value="Next" onclick="GetBtnName(this.name)"/>
              <input type="hidden" runat="server" id="TxtBtnName" name="TxtBtnName"/> 
              <input type="hidden" id="TxtBtnNamee" name="TxtBtnNamee"/> --%>

    <button type="button" class="btn btn-success" id="Next_08" onclick="FnRedirect('Redirect','Next')">Next</button>
         
 
                    
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

                    
      <!-- Modal Confirm Form (Save) -->     
      <div id="Confirm" class="modal fade" >
        <div class="modal-dialog" role="document" >
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Confirmation</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>

            <asp:panel runat="server" cssclass="modal-body" >
               <div>                
                <div class="form-group">  
                               One more step and we're done! Complete the entry on the next page and your application will be sent to BPLO for further verification.
              </div>    
       
               <div class="text-center">                          
                   <button type="button" runat="server" class="btn btn-success" id="Confirm_12">Save and Proceed</button>
         
                </div>
               </div>
              
            </asp:panel>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
          <%--<script>

              $(document).ready(function () {
                  $('input[type="checkbox"]').click(function () {
                      if ($(this).prop("checked") == true) {
                          document.getElementById('<%=Slide_08_Address.ClientID%>').value = "asdf";
                      document.getElementById('<%=Slide_08_Address.ClientID%>').disabled = true;
                  }
                  else if ($(this).prop("checked") == false) {
                      document.getElementById('<%=Slide_08_Address.ClientID%>').value = "";
                      document.getElementById('<%=Slide_08_Address.ClientID%>').disabled = false;

                  }
              });
              });
              </script>--%>
        

  <script>
      function addHyphen(evt)
      {
          var charCode = (evt.which) ? evt.which : evt.keyCode;          
              if ((charCode > 47 && charCode < 58) || (charCode > 95 && charCode < 106))
              {

                  var ele = document.getElementById("Slide_08_TelNo");
                  var str = String(ele.value);
                  if (str.length <= 1) {
                      ele.value = "8" + ele.value;
                  }
                  if (str.length == 4) {
                      ele.value = ele.value + "-";
                  }
                  if (str.length == 7) {
                      ele.value = ele.value + "-";
                  }
              }
              else
              {
                  return false;
              }
      }
      

      function GetBtnName(BtnName)
      {
          alert(BtnName);
          <%--document.getElementById('<%=TxtBtnName.ClientID%>').value = BtnName;
          document.getElementById('TxtBtnNamee').value = document.getElementById('<%=TxtBtnName.ClientID%>').value--%>
          
      }

      function SaveAll()
      {
          document.getElementById('Slide_08_FnameHdn').value = document.getElementById('<%=Slide_08_Fname.ClientID%>').value;
          document.getElementById('Slide_08_MnameHdn').value = document.getElementById('<%=Slide_08_Mname.ClientID%>').value;
          document.getElementById('Slide_08_LnameHdn').value = document.getElementById('<%=Slide_08_Lname.ClientID%>').value;
          document.getElementById('Slide_08_SuffixHdn').value = document.getElementById('<%=Slide_08_Suffix.ClientID%>').value;
          document.getElementById('Slide_08_GenderHdn').value = document.getElementById('<%=Slide_08_Gender.ClientID%>').value;
          document.getElementById('Slide_08_CitizenshipHdn').value = document.getElementById('<%=Slide_08_Citizenship.ClientID%>').value;
          document.getElementById('Slide_08_CheckHdn').checked = document.getElementById('<%=Slide_08_Check.ClientID%>').checked;
          document.getElementById('Slide_08_AddressHdn').value = document.getElementById('<%=Slide_08_Address.ClientID%>').value;
          document.getElementById('Slide_08_TelNoHdn').value = document.getElementById('<%=Slide_08_TelNo.ClientID%>').value;
          document.getElementById('Slide_08_EmailHdn').value = document.getElementById('<%=Slide_08_Email.ClientID%>').value;
          document.getElementById('Slide_08_AlternateEmailHdn').value = document.getElementById('<%=Slide_08_AlternateEmail.ClientID%>').value;                    
          document.getElementById('Slide_08_CheckHdn').value = document.getElementById('<%=Slide_08_Check.ClientID%>').value;
      }

      function FnRedirect(Action, Val)
      {
          __doPostBack(Action, Val);
          <%--if (Val == "Back") {
              __doPostBack(Action, Val);
          }
          if (document.getElementById('<%=Slide_08_Fname.ClientID%>').value !== '' && document.getElementById('<%=Slide_08_Lname.ClientID%>').value !== '' && document.getElementById('<%=Slide_08_Address.ClientID%>').value !== '')
          {
              __doPostBack(Action, Val);
          }--%>          
      }

      function GetAddress() {
          
          
          if(document.getElementById("Slide_08_Check").checked == true)
          {
              document.getElementById('<%=Slide_08_Address.ClientID%>').value = document.getElementById('<%=Slide_08_AddressHdn.ClientID%>').value
          }
          if (document.getElementById("Slide_08_Check").checked == false) 
              {
              document.getElementById('<%=Slide_08_Address.ClientID%>').value = "";
          }
          document.getElementById('<%=Slide_08_Address.ClientID%>').disabled = document.getElementById("Slide_08_Check").checked;

          <%--  __doPostBack(Action, document.getElementById('<%=Slide_08_Check.ClientID%>').checked);--%>
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


      function ShowConfirm() {
          $("#Confirm").modal("show");
      }
      function OwnershipChange(type) {
          //clear all entry on ownership type change
          localStorage.clear();
          localStorage.setItem("Slide_01_OwnershipType", type);
      }

      function goHome() {
          location.replace("../VS2014.IMC/Main.aspx");
      }




      function getSelected(sel) {
          switch (sel) {
              case "Slide_08_Citizenship":
                  document.getElementById('<%=Slide_08_SelectedCitizenship.ClientID%>').value = sel.value;
                  var CTZ = document.getElementById('<%=Slide_08_Citizenship.ClientID%>');
                  document.getElementById('<%=Slide_08_SelectedCitizenship.ClientID%>').value = CTZ.options[CTZ.selectedIndex].value;
                  break;
              }
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