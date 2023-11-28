<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BusGovRegistration.aspx.vb" Inherits="SPIDC.BusGovRegistration" %>
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
             //alert(RegMode);

             if (RegMode == 'OAIMS') {
                 document.getElementById('<%=Slide_05_TIN.ClientID%>').value = sessionStorage.getItem('tin_number');
             }
         };
        </script>
    <%------------------------------%>
    <div class="container">
             <center> 
          <div class="col-md-6">
           <div class="details"> 

		               <!-- SLIDE 5 - Government Registration-->
            <form id="frmSlide_05" method="post">	
		   <div id="Slide_05" style="border:1px solid gray; background-color:white; padding:10px;display:block;">
		      <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
                <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" 
                 style="width:30%">  
                </div>
              </div>    
                 <hr />

              <div style="background-color:#3B7FF2;color:white;"><strong>Government Registration</strong></div>
	
                   <br />
               <!-- CDA -->
               <div class="form-row" id="frmCDA" runat="server">
                   <div class="form-group col-md-6"  style="text-align:left">        <label runat="server" id="_oLblCDANo">CDA  No.: </label><span style="color:red" id="_oLblAstCDA" runat="server"></span><br />                     
                <input  type="text"  oninput="this.reportValidity()" runat="server" class="form-control" name="CDA_No"  id="Slide_05_CDA" placeholder="0000-00000000" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          <label runat="server" id="_oLblCDANo2">Registration Date: CDA </label><br />        
                <input  type="text"  runat="server" name="CDA_RegDate" class="form-control" id="Slide_05_CDA2" placeholder="CDA Registration Date" onfocus="(this.type='date')" onblur="this.reportvalidity()" />
                 </div>               
            </div>

               <!-- DTI -->
               <div class="form-row" id="frmDTI" runat="server">
                   <div class="form-group col-md-6"  style="text-align:left">        <label runat="server" id="_oLblDTINo">DTI  No.: </label><span style="color:red" id="_oLblAstDTI" runat="server"></span><br />                     
                <input   type="text"  oninput="this.reportValidity()" runat="server" class="form-control" name="DTI_No"  id="Slide_05_DTI" placeholder="0000000" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          <label runat="server" id="_oLblDTINo2">Registration Date: DTI </label><br />        
                <input  type="text"  runat="server" name="DTI_RegDate" class="form-control" id="Slide_05_DTI2" placeholder="DTI Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()"  min="1900-01-01" />
                 </div>               
            </div>
               
               <!-- SEC  -->
               <div class="form-row" id="frmSEC" runat="server">
                   <div class="form-group col-md-6"  style="text-align:left">        <label runat="server" id="_oLblSECNo">SEC  No.: </label><span style="color:red" id="_oLblAstSEC" runat="server"></span><br />                     
                <input   type="text"  oninput="this.reportValidity()" runat="server" class="form-control" name="SEC_No"  id="Slide_05_SEC" placeholder="0000000000" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          <label runat="server" id="_oLblSECNo2">Registration Date: SEC </label><br />        
                <input  type="text"  runat="server" name="SEC_RegDate" class="form-control" id="Slide_05_SEC2" placeholder="SEC Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()" min="1900-01-01"  />
                 </div>               
            </div>

               <!-- TIN  -->
               <div class="form-row" id="frmTIN">
                   <div class="form-group col-md-6"  style="text-align:left">        TIN  No.: <span style="color:red"*</span><br />                     
                <input   type="text" required oninput="this.reportValidity()" runat="server" class="form-control" name="TIN_No"  id="Slide_05_TIN" placeholder="000-000-000-000" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: TIN<br />        
                <input  type="text"  runat="server" name="TIN_RegDate"  class="form-control" id="Slide_05_TIN2" placeholder="TIN Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()" min="1900-01-01" maxlength="10"/>
                 </div>               
            </div>

               <!-- SSS  -->
               <div class="form-row" id="frmSSS">
                   <div class="form-group col-md-6"  style="text-align:left">        SSS  No.: <span style="color:red"></span><br />                     
                <input   type="text"  oninput="this.reportValidity()" runat="server" class="form-control" name="SSS_No"  id="Slide_05_SSS" placeholder="00-0000000-0" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: SSS<br />        
                <input  type="text" required runat="server" name="SSS_RegDate" class="form-control" id="Slide_05_SSS2" placeholder="SSS Registration Date" onfocus="(this.type='date')"   onblur="this.reportvalidity()" min="1900-01-01" />
                 </div>               
            </div>

                             <!-- CTC  -->
               <div class="form-row" id="frmCTC" style="display:none">
                   <div class="form-group col-md-6"  style="text-align:left">        CTC  No.: <span style="color:red"></span><br />                     
                <input type="text"  runat="server" class="form-control" name="CTC_No"  id="Slide_05_CTC" placeholder="CTC No." maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: CTC<br />        
                <input  type="text"  runat="server" name="CTC_RegDate" class="form-control" id="Slide_05_CTC2" placeholder="CTC Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()" min="1900-01-01" />
                 </div>               
            </div>

               <!-- CTC Place  -->
               <div class="form-row" id="frmCTCPlace" style="display:none">
                   <div class="form-group col-md-6"  style="text-align:left">        CTC Place: <span style="color:red"></span><br />                     
                <input   type="text"  runat="server" class="form-control" name="CTC_Place"  id="Slide_05_CTCPlace" placeholder="CTC Place" maxlength="50"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          CTC Amount: <span style="color:red"></span><br />        
                <input  type="text"   runat="server" name="CTC_Amount" class="form-control" id="Slide_05_CTCPlace2" placeholder="CTC Amount" style="text-align:right" pattern="[0-9]+" oninput="this.reportValidity()" title="Amount" maxlength="15"/>
                        </div>               
            </div>

                <!-- BIR  -->
               <div class="form-row" id="frmBIR">
                   <div class="form-group col-md-6"  style="text-align:left">       BIR Registration No.: <span style="color:red"></span><br />                     
                <input   type="text"  oninput="this.reportValidity()" runat="server" class="form-control" name="CTC_Place"  id="Slide_05_BIR" placeholder="BIR" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: BIR<br />        
                <input  type="text"  runat="server" name="BIR_RegDate" class="form-control" id="Slide_05_BIR2" placeholder="BIR Registration Date" onfocus="(this.type='date')"   onblur="this.reportvalidity()" min="1900-01-01" />
               </div>               
            </div>

                <!-- Brgy Clearance  -->
               <div class="form-row" id="frmBrgy">
                   <div class="form-group col-md-6"  style="text-align:left">        Brgy Clearance No.: <br />                     
                <input   type="text"  runat="server" class="form-control" name="Brgy_No"  id="Slide_05_Brgy" placeholder="Barangay Clearance No." maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: Brgy<br />        
                <input  type="text"  runat="server" name="Brgy_RegDate" class="form-control" id="Slide_05_Brgy2" placeholder="Brgy Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()" min="1900-01-01" />
                      <input type="hidden" runat="server" id="HdnOwnershipType"/>
                 </div>               
            </div>
            
            
           
		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_05" onclick="FnRedirect('Redirect','Back')">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_05" onclick="FnRedirect('Redirect','Next')">Next</button>
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
          <%--if (Val == "Back") {
              __doPostBack(Action, Val);
          }
          

          if (document.getElementById('<%=HdnOwnershipType.ClientID%>').value == 'Cooperative')
          {
              if (document.getElementById('<%=Slide_05_CDA.ClientID%>').value !== '' && document.getElementById('<%=Slide_05_CDA2.ClientID%>').value !== '')
              {
                  __doPostBack(Action, Val);
              }
          }
          if (document.getElementById('<%=HdnOwnershipType.ClientID%>').value == 'Single')
          {
              if (document.getElementById('<%=Slide_05_DTI.ClientID%>').value !== '' && document.getElementById('<%=Slide_05_DTI2.ClientID%>').value !== '')
              {
                  __doPostBack(Action, Val);
              }
          }
          if (document.getElementById('<%=HdnOwnershipType.ClientID%>').value == 'Corporation') {
              if (document.getElementById('<%=Slide_05_SEC.ClientID%>').value !== '' && document.getElementById('<%=Slide_05_SEC2.ClientID%>').value !== '') {
                  __doPostBack(Action, Val);
              }
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