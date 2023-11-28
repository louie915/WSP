<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BusLessorInfo.aspx.vb" Inherits="SPIDC.BusLessorInfo" %>
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
        document.getElementById('<%= Slide_02_Email.ClientID%>').type='email';

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

		   <!-- SLIDE 2 - Lessor Information-->
            <form id="frmSlide_02" method="post">
		   <div id="Slide_02" style="border:1px solid gray; background-color:white; padding:10px;display:block;">
		     <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
               <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" style="width:20%">
             
                </div>
              </div>
                  <hr />

              <div style="background-color:#3B7FF2;color:white;"><strong>Lease Information :</strong> Please complete the form</div>	
                   <br />

             <div class="form-row">
                 
                  <div class="form-group col-md-6" style="text-align:left">    Date Rented <b style="color:red">*</b><br />        
                <input  type="text" required runat="server" name="DateRented" class="form-control" id="Slide_02_DateRented" min="1900-01-01" max="2018-12-31"  placeholder="Date Rented" onfocus="(this.type='date')" onblur="ChangeDate(this.id);" />
                <input  type="hidden" runat="server"  name="Slide_02_DateRented_Formatted" id="Slide_02_DateRented_Formatted"/>             

                       </div>  
           
              <div class="form-group col-md-6" style="text-align:left">        Rent Per Month <b style="color:red">*</b><br />                   
                <input  type="text" required runat="server" name="RentPerMonth" class="form-control" id="Slide_02_RentPerMonth" oninput="this.reportValidity()" pattern="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" title="Currency" placeholder="0.00" style="text-align:right" maxlength="25" onblur="formatMoney(this.value);" onfocus="removeComma(this.value);"/>
               
              </div>
            </div>    
               
                 
             <div style="background-color:#F5F5F5;">
                      <hr />
                  
                <div class="form-row">
              <div class="form-group col-md-6"  style="text-align:left">          Lessor First Name <b style="color:red">*</b><br />                    
                <input   type="text" required runat="server" class="form-control" name="LessorFirstName"  id="Slide_02_LessorFname" placeholder="Lessor First Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor First Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); "  mmaxlength="25"/>
              </div>

              <div class="form-group col-md-6"  style="text-align:left">          Lessor Last Name <b style="color:red">*</b><br />                   
                <input  type="text" required runat="server" class="form-control" name="LessorLastName" id="Slide_02_LessorLname"  placeholder="Lessor Last Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
              </div>
            </div>
                <div style="text-align:left;"><strong>Lessor Address</strong></div>
                    <div class="form-row">
              <div class="form-group col-md-6"  style="text-align:left">          Barangay<br />                     
                <input   type="text"  runat="server" class="form-control" name="LessorBarangay"  id="Slide_02_Brgy" placeholder="Brgy"  title="Lessor Barangay"  onblur="this.style.textTransform  = 'capitalize'; " maxlength="50" />
              </div>

              <div class="form-group col-md-6"  style="text-align:left">          Street<br />                    
                <input  type="text"  runat="server" class="form-control" name="LessorStreet" id="Slide_02_Street" placeholder="St." title="Lessor Street"  onblur="this.style.textTransform  = 'capitalize';" maxlength="50" />
              </div>
            </div>

              <div class="form-group col-md-13" style="text-align:left">          Address<br />                       
                <textarea runat="server" class="form-control" name="LessorAddress"  id="Slide_02_Address" placeholder="Building No., Subdivision ..." title="Lessor Address"  onblur="this.style.textTransform  = 'capitalize';" maxlength="100" />
              </div>
                     <div class="form-row">
            <div class="form-group col-md-6" style="text-align:left">          Tel. No.<br /> 
                <input  type="text" runat="server" class="form-control"  id="Slide_02_TelNo" placeholder="8###-##-##"  onkeyup="return addHyphen(event)" title="Telephone No." maxlength="10" />
                </div>
                      <div class="form-group col-md-6" style="text-align:left">          Email<br /> 
                 <input  type="text" runat="server"  class="form-control" id="Slide_02_Email" name="EmailAddress" placeholder="Lessor Email Address" oninput="this.reportValidity()" title="Email Address" maxlength="25" />
                </div>
		        </div>

                     <div class="form-group col-md-13"  style="text-align:left">          Building Administrator<br />                                        
                <input   type="text" runat="server" class="form-control" name="LessorAdministrator"  id="Slide_02_Administrator" placeholder="Administrator" title="Lessor Administrator"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="50" />
              </div>
               
		
               </div>
        
               
		  
		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_02" onclick="FnRedirect('Redirect','Back')">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_02" onclick="FnRedirect('Redirect','Next')">Next</button>


          


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
      function addHyphen(evt) {
          var charCode = (evt.which) ? evt.which : evt.keyCode;
          if ((charCode > 47 && charCode < 58) || (charCode > 95 && charCode < 106)) {

              var ele = document.getElementById("Slide_02_TelNo");
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
          else {
              return false;
          }
      }

      function formatMoney(val) {

          var formatter = new Intl.NumberFormat('en-US', {
              style: 'currency',
              currency: 'PHP',
          });

          var x = formatter.format(val);
          x = x.split('PHP').join('');
          x = x.replace(/\s/g, '');
          x = x.replace('₱', '');
          document.getElementById('<%=Slide_02_RentPerMonth.ClientID%>').value = x;
      }

      function removeComma(x) {
          document.getElementById('<%=Slide_02_RentPerMonth.ClientID%>').value = x.replace(/,/g, '');


           }

      function FnRedirect(Action, Val)
      {
          __doPostBack(Action, Val);
          <%--if (Val == "Back")
          {
              __doPostBack(Action, Val);
          }
          if (document.getElementById('<%=Slide_02_RentPerMonth.ClientID%>').value !== "" && document.getElementById('<%=Slide_02_LessorFname.ClientID%>').value !== "" && document.getElementById('<%=Slide_02_LessorLname.ClientID%>').value !== "")
          {
              __doPostBack(Action, Val);
          }--%>          
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