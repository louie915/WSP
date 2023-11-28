<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BusInformation.aspx.vb" Inherits="SPIDC.BusInformation" %>
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
        document.getElementById('<%=Slide_06_NoMale.ClientID%>').type = 'number';
        document.getElementById('<%=Slide_06_NoFemale.ClientID%>').type = 'number';
        document.getElementById('<%=Slide_06_NoTotal.ClientID%>').type = 'number';
        document.getElementById('<%=Slide_06_NoLGU.ClientID%>').type = 'number';

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
                 document.getElementById('<%=Slide_06_TradeName.ClientID%>').value = sessionStorage.getItem('verified_company_name') + ' ' + sessionStorage.getItem('tradename');
             }
         };
        </script>
    <%------------------------------%>
    <div class="container">
             <center> 
          <div class="col-md-6">
           <div class="details"> 

		    <!-- SLIDE 6 - Business Information-->
            <form id="frmSlide_06" method="post">	
		   <div id="Slide_06" style="border:1px solid gray; background-color:white; padding:10px;display:block;">
		      <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
               <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" 
                 style="width:40%">
                </div>
              </div>    
          
                  <hr />

              <div style="background-color:#3B7FF2;color:white;"><strong>Business Information</strong></div>
	
                   <br />       
               <div class="form-row">
                   <div class="form-group col-md-6"  style="text-align:left">Is your Business a branch? <b style="color:red">*</b><br />   
                           <select required runat="server" id="Slide_06_Branch" name="cmbOwnership" class="form-control">  
                      <option value="Yes" >Yes</option>  
                      <option value="No">No</option>                               
                  </select>                   
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Date Established <b style="color:red">*</b><br />        
                <input  type="text" required runat="server" name="Date_Established" class="form-control" id="Slide_06_DateEstablished" placeholder="Date"  onfocus="(this.type='date')" onblur="ChangeDate(this.id);"   min="1900-01-01"/>
                <input  type="hidden" runat="server"  name="Slide_06_DateEstablished_Formatted" id="Slide_06_DateEstablished_Formatted"/>
                       </div>               
            </div>

       
              <div class="form-group col-md-12"  style="text-align:left">          Business Tradename <i>(Pangalan ng Negosyo)</i> <b style="color:red">*</b><br />                     
                <input   type="text" required runat="server" class="form-control" name="BusinessTradename"  id="Slide_06_TradeName" placeholder="Business Tradename" title="Business Tradename"  maxlength="100" />
              </div>
                            
               <hr />
               Number of Employees including the owner:<i>(Bilang ng Empleyado kabilang ang may-ari) </i>

                <div class="form-row">
                 
              <div class="form-group col-md-12" style="text-align:left">        No. of Male<i>(Bilang ng Empleyado na Lalaki) </i><br />                   
                <input   type="text" min="0" required runat="server" value="0" name="No_Male" class="form-control" id="Slide_06_NoMale" placeholder="0" 
                    style="text-align:right" oninput="this.reportValidity()" onblur="get_sum()" title="Number of Male"  maxlength="5"  
                      onkeypress="validate(event);"
                    />
              </div> 
           
              <div class="form-group col-md-12" style="text-align:left">        No. of Female <i>(Bilang ng Empleyado na Babae) </i><br />                   
                <input   type="text"  min="0" required runat="server" value="0" name="No_Female" class="form-control" id="Slide_06_NoFemale" placeholder="0" 
                    style="text-align:right"   oninput="this.reportValidity()" onblur="get_sum()" title="Number of Female" maxlength="5"
                     onkeypress="validate(event);"
                     />
              </div>
                    <div class="form-group col-md-12" style="text-align:left">      Total <i>(Kabuoang bilang ng mga Empleyado) </i><br />                   
                <input   type="text"  min="0" runat="server" value="0" name="No_total" class="form-control" id="Slide_06_NoTotal" placeholder="0" style="text-align:right" readonly="true" />
              </div>
                    <div class="form-group col-md-12" style="text-align:left">No. of Employees residing within the City/Municipality<br />
                           <i>(Bilang ng Empleyado na nakatira sa loob ng lungsod / munisipalidad) </i>                   <br />
                <input   type="text" min="0"  runat="server" value="0" name="No_LGU" class="form-control" id="Slide_06_NoLGU" placeholder="0" style="text-align:right"  title="No. of Employess residing within the City/Municipality" maxlength="6" />
              </div>
                    
                     <script>

                         function get_sum()
                         {
                             var M = parseInt(document.getElementById('<%=Slide_06_NoMale.ClientID%>').value);
                             if (document.getElementById('<%=Slide_06_NoMale.ClientID%>').value == "")
                             {
                                 M = 0
                             }
                             var F = parseInt(document.getElementById('<%=Slide_06_NoFemale.ClientID%>').value);
                             if (document.getElementById('<%=Slide_06_NoFemale.ClientID%>').value == "") {
                                 F = 0
                             }
                             document.getElementById('<%=Slide_06_NoTotal.ClientID%>').value = M + F
                         }

                         <%--function compare_TOTAL(x)
                         {
                             var total = parseInt(document.getElementById('<%=Slide_06_NoTotal.ClientID%>').value);
                             var lgu = parseInt(x.value);
                             var y = x.id
                             
                             if (parseInt(total) < parseInt(lgu))
                             {
                                 alert("Cannot be greated than the Total number of employees");
                                 y.setCustomValidity("Cannot be greated than the Total number of employees");
                             }
                             else
                             {
                                 y.setCustomValidity("");
                             }
                         }--%>

                    </script>                                                       
            </div>           
		  <hr/>		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_06" onclick="FnRedirect('Redirect','Back')">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_06" onclick="FnRedirect('Redirect','Next')">Next</button>
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

      function FnRedirect(Action, Val) {
          var total = parseInt(document.getElementById('<%=Slide_06_NoTotal.ClientID%>').value);
          var lgu = parseInt(document.getElementById('<%=Slide_06_NoLGU.ClientID%>').value);
          __doPostBack(Action, Val);
          <%--if (Val == "Back") {
              __doPostBack(Action, Val);
          }
          if (document.getElementById('<%=Slide_06_DateEstablished.ClientID%>').value !== '' && document.getElementById('<%=Slide_06_TradeName.ClientID%>').value !== '')
          {
              __doPostBack(Action, Val);
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