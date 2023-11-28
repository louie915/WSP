<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BPLTIMSNewBusinessApplication.aspx.vb" Inherits="SPIDC.BPLTIMSNewBusinessApplication" %>
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

     <form  method="post"></form>
        
      <div class="container">
             <center> 
          <div class="col-md-6">
           <div class="details">           
           <!-- Apply for New Business Permit -->
           <!-- SLIDE 1 - Ownership Type || is Rented? -->	               
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
                      <option value="" selected disabled>Select Type</option>  
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

			<input id="radio1" required name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio1">Yes 
              
			</label>
		  </div>

		  <div class="inputGroup">
			<input id="radio2" required name="Slide_01" type="radio" onclick="ShowNext(this.id)"/>
			<label for="radio2">No
       
			</label>
		  </div>
		  
		  <input type="hidden" runat="server" id="SelectedYesNo" name="SelectedYesNo"/>
		  <input type="hidden" runat="server" id="SelectedOwnership" name="SelectedOwnership"/>

		  <hr/>
		  
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
              <button type="button" class="btn btn-primary" id="Home_01" onclick="javascript:history.back()" >Back</button> &nbsp
              <button type="button" class="btn btn-success" id="Next_01" onclick="ShowNext(this.id)" disabled=true style="cursor: not-allowed;opacity:0.5">Next</button>
          
</span>	 		   
		   </div>
            </form>    
		   <!-- SLIDE 2 - Lessor Information-->
            <form id="frmSlide_02" method="post">
		   <div id="Slide_02" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
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
                <input  type="text" required runat="server" name="RentPerMonth" class="form-control" id="Slide_02_RentPerMonth" oninput="this.reportValidity()" pattern="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" title="Currency" placeholder="0" style="text-align:right" maxlength="25" onblur="formatMoney(this.value);" onfocus="removeComma(this.value);" />
               
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
                <input   type="text" runat="server" name="LessorTelNo" class="form-control" id="Slide_02_TelNo" placeholder="Lessor Tel No." pattern="[0-9]+" oninput="this.reportValidity()" title="Telephone No." maxlength="11" />
                </div>
                      <div class="form-group col-md-6" style="text-align:left">          Email<br /> 
                 <input  type="email" runat="server"  class="form-control" id="Slide_02_Email" name="EmailAddress" placeholder="Lessor Email Address" oninput="this.reportValidity()" title="Email Address" maxlength="25" />
                </div>
		        </div>

                     <div class="form-group col-md-13"  style="text-align:left">          Building Administrator<br />                                        
                <input   type="text" runat="server" class="form-control" name="LessorAdministrator"  id="Slide_02_Administrator" placeholder="Administrator" title="Lessor Administrator"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="50" />
              </div>
               
		
               </div>
        
               
		  
		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_02" onclick="ShowNext(this.id);">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_02" onclick="ShowNext(this.id);">Next</button>


          


</span>	 		   
               </div>	
		   </form>
		
            <!-- SLIDE 5 - Government Registration-->
            <form id="frmSlide_05" method="post">	
		   <div id="Slide_05" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
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
               <div class="form-row" id="frmCDA">
                   <div class="form-group col-md-6"  style="text-align:left">        CDA No.: <span style="color:red">*</span><br />                     
                <input  type="text"  runat="server" class="form-control" name="CDA_No"  id="Slide_05_CDA" placeholder="0000-00000000" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: CDA <br />        
                <input  type="text"  runat="server" name="CDA_RegDate" class="form-control" id="Slide_05_CDA2" placeholder="CDA Registration Date" onfocus="(this.type='date')" onblur="this.reportvalidity()" />
                 </div>               
            </div>

               <!-- DTI -->
               <div class="form-row" id="frmDTI">
                   <div class="form-group col-md-6"  style="text-align:left">        DTI No.: <span style="color:red">*</span><br />                     
                <input   type="text"  runat="server" class="form-control" name="DTI_No"  id="Slide_05_DTI" placeholder="0000000" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: DTI <br />        
                <input  type="text"  runat="server" name="DTI_RegDate" class="form-control" id="Slide_05_DTI2" placeholder="DTI Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()"  min="1900-01-01" />
                 </div>               
            </div>

               <!-- SEC  -->
               <div class="form-row" id="frmSEC">
                   <div class="form-group col-md-6"  style="text-align:left">        SEC  No.: <span style="color:red">*</span><br />                     
                <input   type="text"  runat="server" class="form-control" name="SEC_No"  id="Slide_05_SEC" placeholder="0000000000" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: SEC<br />        
                <input  type="text"  runat="server" name="SEC_RegDate" class="form-control" id="Slide_05_SEC2" placeholder="SEC Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()" min="1900-01-01"  />
                 </div>               
            </div>

               <!-- TIN  -->
               <div class="form-row" id="frmTIN">
                   <div class="form-group col-md-6"  style="text-align:left">        TIN  No.: <span style="color:red">*</span><br />                     
                <input   type="text"  runat="server" class="form-control" name="TIN_No"  id="Slide_05_TIN" placeholder="000-000-000-000" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: TIN<br />        
                <input  type="text"  runat="server" name="TIN_RegDate" class="form-control" id="Slide_05_TIN2" placeholder="TIN Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()" min="1900-01-01" />
                 </div>               
            </div>

               <!-- SSS  -->
               <div class="form-row" id="frmSSS">
                   <div class="form-group col-md-6"  style="text-align:left">        SSS  No.: <span style="color:red">*</span><br />                     
                <input   type="text"  runat="server" class="form-control" name="SSS_No"  id="Slide_05_SSS" placeholder="00-0000000-0" maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: SSS<br />        
                <input  type="text"  runat="server" name="SSS_RegDate" class="form-control" id="Slide_05_SSS2" placeholder="SSS Registration Date" onfocus="(this.type='date')"   onblur="this.reportvalidity()" min="1900-01-01" />
                 </div>               
            </div>

                             <!-- CTC  -->
               <div class="form-row" id="frmCTC" style="display:none">
                   <div class="form-group col-md-6"  style="text-align:left">        CTC  No.: <span style="color:red">*</span><br />                     
                <input   type="text"  runat="server" class="form-control" name="CTC_No"  id="Slide_05_CTC" placeholder="CTC No." maxlength="15"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: CTC<br />        
                <input  type="text"  runat="server" name="CTC_RegDate" class="form-control" id="Slide_05_CTC2" placeholder="CTC Registration Date" onfocus="(this.type='date')"  onblur="this.reportvalidity()" min="1900-01-01" />
                 </div>               
            </div>

               <!-- CTC Place  -->
               <div class="form-row" id="frmCTCPlace" style="display:none">
                   <div class="form-group col-md-6"  style="text-align:left">        CTC Place: <span style="color:red">*</span><br />                     
                <input   type="text"  runat="server" class="form-control" name="CTC_Place"  id="Slide_05_CTCPlace" placeholder="CTC Place" maxlength="50"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          CTC Amount: <span style="color:red">*</span><br />        
                <input  type="text"   runat="server" name="CTC_Amount" class="form-control" id="Slide_05_CTCPlace2" placeholder="CTC Amount" style="text-align:right" pattern="[0-9]+" oninput="this.reportValidity()" title="Amount" maxlength="15"/>
                        </div>               
            </div>

                <!-- BIR  -->
               <div class="form-row" id="frmBIR">
                   <div class="form-group col-md-6"  style="text-align:left">       BIR Registration No.: <span style="color:red">*</span><br />                     
                <input   type="text"  runat="server" class="form-control" name="CTC_Place"  id="Slide_05_BIR" placeholder="BIR" maxlength="15"/>
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
                 </div>               
            </div>
            
            
           
		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_05" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_05" onclick="ShowNext(this.id)">Next</button>
</span>	 		   
               </div>	
         </form>
            <!-- SLIDE 6 - Business Information-->
            <form id="frmSlide_06" method="post">	
		   <div id="Slide_06" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
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
                <input   type="number" min="0" required runat="server" value="0" name="No_Male" class="form-control" id="Slide_06_NoMale" placeholder="0" 
                    style="text-align:right" oninput="this.reportValidity()" onblur="get_sum()" title="Number of Male"  maxlength="5"  
                      onkeypress="validate(event);"
                    />
              </div> 
           
              <div class="form-group col-md-12" style="text-align:left">        No. of Female <i>(Bilang ng Empleyado na Babae) </i><br />                   
                <input   type="number"  min="0" required runat="server" value="0" name="No_Female" class="form-control" id="Slide_06_NoFemale" placeholder="0" 
                    style="text-align:right"   oninput="this.reportValidity()" onblur="get_sum()" title="Number of Female" maxlength="5"
                     onkeypress="validate(event);"
                     />
              </div>
                    <div class="form-group col-md-12" style="text-align:left">      Total <i>(Kabuoang bilang ng mga Empleyado) </i><br />                   
                <input   type="number"  min="0" runat="server" value="0" name="No_total" class="form-control" id="Slide_06_NoTotal" placeholder="0" style="text-align:right" readonly="true" />
              </div>
                    <div class="form-group col-md-12" style="text-align:left">No. of Employess residing within the City/Municipality<br />
                           <i>(Bilang ng Empleyado na nakatira sa loob ng lungsod / munisipalidad) </i>                   <br />
                <input   type="number" min="0"  runat="server" value="0" name="No_LGU" oninput="compare_TOTAL(this)" class="form-control" id="Slide_06_NoLGU" placeholder="0" style="text-align:right"  title="No. of Employess residing within the City/Municipality" maxlength="6" />
              </div>
                    
                     <script>
                         function get_sum() {
                             var M = parseInt(document.getElementById('<%=Slide_06_NoMale.ClientID%>').value);
                             var F = parseInt(document.getElementById('<%=Slide_06_NoFemale.ClientID%>').value);
                             document.getElementById('<%=Slide_06_NoTotal.ClientID%>').value = M + F
                         }
                         function compare_TOTAL(x) {
                             var total = parseInt(document.getElementById('<%=Slide_06_NoTotal.ClientID%>').value);
                            var lgu = parseInt(x.value);

                            if (parseInt(total) < parseInt(lgu)) {
                                x.setCustomValidity("Cannot be greated than the Total number of employees");
                            }
                            else {
                                x.setCustomValidity("");
                            }

                        }

                    </script>
              
                      
                    
            </div>           
		  <hr/>		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_06" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_06" onclick="ShowNext(this.id)">Next</button>
</span>	 		   
               </div>	
           </form>
             <!-- SLIDE 7 - Business Address-->
           <form id="frmSlide_07" method="post">	
		   <div id="Slide_07" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
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
                           <select required runat="server" id="Slide_07_Brgy"  class="form-control" onchange="getSelected(this.id);">  
                      <option value="BRGY_001" >Sample BRGY 001</option>  
                      <option value="BRGY_002">Sample BRGY 002</option>                               
                  </select>                   
              </div>

              <div class="form-group col-md-6"  style="text-align:left">Street<b style="color:red">*</b><br />  
                   <input type="hidden" runat="server" id="Slide_07_SelectedStreet" /> 
                      <select required runat="server" id="Slide_07_Street"  class="form-control" onchange="getSelected(this.id);">  
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
	<button type="button" class="btn btn-primary" id="Back_07" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_07" onclick="ShowNext(this.id)">Next</button>
</span>	 		   
               </div>	
           </form>
           <!-- SLIDE 8 - Business Owner Information-->
            <form id="frmSlide_08" method="post">	
		   <div id="Slide_08" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
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
                <input   type="text" required runat="server"  class="form-control" id="Slide_08_Fname" placeholder="First Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
              </div>

                <div class="form-group col-md-13"  style="text-align:left">          Middle Name<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_08_Mname" placeholder="Middle Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Middle Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
              </div>

              <div class="form-group col-md-13"  style="text-align:left">          Last Name<b style="color:red">*</b><br />                    
                <input  type="text" required runat="server" class="form-control"  id="Slide_08_Lname" placeholder="Last Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
              </div>

               <div class="form-group col-md-13"  style="text-align:left">          Suffix<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_08_Suffix" placeholder="Jr., Sr., VI" pattern="[\s a-zA-ZñÑ .]+" oninput="this.reportValidity()" title="Suffix"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="10" />
              </div>
          

                <div class="form-row">
                <div class="form-group col-md-6"  style="text-align:left">Gender<b style="color:red">*</b><br />   
                           <select required runat="server" id="Slide_08_Gender"  class="form-control">  
                      <option value="Male" >Male</option>  
                      <option value="Female">Female</option>                               
                  </select>                   
                </div>

                <div class="form-group col-md-6"  style="text-align:left">Citizenship<b style="color:red">*</b><br />   
                    <input type="hidden" runat="server" id="Slide_08_SelectedCitizenship" /> 
                           <select required runat="server" id="Slide_08_Citizenship"  class="form-control" onchange="getSelected(this.id);">  
                      <option value="American" >American</option>  
                      <option value="Chinese" >Chinese</option> 
                      <option value="Filipino">Filipino</option> 
                      <option value="Japanese">Japanese</option>                                     
                  </select>                   
              </div>       
            </div>

                <div class="form-group col-md-13"  style="text-align:left">          Address<b style="color:red">*</b><br /> 
                   <input type="checkbox" name="chkSame">  check if Business Address is the same as Owner Address  <br>    
                     
                <textarea  required runat="server" class="form-control"  id="Slide_08_Address" placeholder="Address" maxlength="150" />
              </div>

                <div class="form-group col-md-13"  style="text-align:left">          Telephone No.<br />                    
                <input  type="text" runat="server" class="form-control"  id="Slide_08_TelNo" placeholder="123-45-67" pattern="[0-9]+" title="Telephone No." maxlength="11" />
              </div>

               
                <div class="form-row">
                 
              <div class="form-group col-md-6" style="text-align:left;display:none">        Email Address<br />                   
                <input   type="text" readonly="true"  runat="server" class="form-control" id="Slide_08_Email" placeholder="Sample@email.com" maxlength="100" />
              </div> 
           
              <div class="form-group col-md-6" style="text-align:left">       Alternate Email<br />                   
                <input   type="text" runat="server" class="form-control" id="Slide_08_AlternateEmail" placeholder="SampleAlternate@email.com" maxlength="100" />
              </div>
            </div>           
		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_08" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_08" onclick="ShowNext(this.id)">Next</button>
         
 

</span>	 		   
               </div>	
            </form>
           <!-- SLIDE 9 - Incorporator-->
		   <div id="Slide_09" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
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
                <input   type="text" runat="server" class="form-control" id="Text1" placeholder="First Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor First Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>

                <div class="form-group col-md-13"  style="text-align:left">          Middle Name<br />                    
                <input  type="text" runat="server" class="form-control"  id="Text2" placeholder="Middle Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>

              <div class="form-group col-md-13"  style="text-align:left">          Last Name<br />                    
                <input  type="text" runat="server" class="form-control"  id="Text3" placeholder="Last Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>
                       

                <div class="form-group col-md-13"  style="text-align:left">          Address<br />                    
                <input  type="text" runat="server" class="form-control"  id="Text4" placeholder="Address" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>
           
           
		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_09" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_09" onclick="ShowNext(this.id)">Next</button>
</span>	 		   
               </div>	
           <!-- SLIDE 10 - Incorporator - Additional Info-->
		   <div id="Slide_10" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
		     <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
                   <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" 
                 style="width:90%">
                </div>
              </div>    
                <hr />

              <div style="background-color:#3B7FF2;color:white;"><strong>Incorporator - Additional Info</strong></div>
	
                   <br />       
          
              <div class="form-group col-md-13"  style="text-align:left">          Treasurer's Name<br />                     
                <input   type="text" runat="server" class="form-control" id="Text5" placeholder="Treasurer's Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor First Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>

                <div class="form-group col-md-13"  style="text-align:left">          Autorized Representative Name<br />                    
                <input  type="text" runat="server" class="form-control"  id="Text33" placeholder="Representative Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>

              <div class="form-group col-md-13"  style="text-align:left">          Authorized Representative's Position<br />                    
                <input  type="text" runat="server" class="form-control"  id="Text38" placeholder="Position" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Lessor Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>
          
           
		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">
	<button type="button" class="btn btn-primary" id="Back_10" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="btn btn-success" id="Next_10" onclick="ShowNext(this.id)">Next</button>
</span>	 		   
               </div>	

      

           <!-- SLIDE End - Application Summary -->
          <div id="Slide_End" style="border:1px solid gray; background-color:white; padding:10px;display:none;">
		      <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >New Business Permit Application</h2>
                </div> 
                   <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" 
                 style="width:90%"> 
                </div>
              </div>    
                <hr />

              <div style="background-color:#3B7FF2;color:white;"><strong>Application Summary</strong></div>
	  <strong><i> * Please confirm if all the entries are correct </i></strong>
                   <br />       
                      <div style="font-size:small;" >
               <!-- S1 -->
               <div class="form-row" id="Slide_End_S1">
                   <div class="form-group col-md-6"  style="text-align:left">    Ownership Type                    
                            <input   type="text" runat="server"  class="form-control" id="S1_Ownershiptype"  readonly="true" value="Single"/>           
                   </div>
                  <div class="form-group col-md-6" style="text-align:left">  Rented   
                      <input   type="text" runat="server" class="form-control" id="S1_IsRented"  readonly="true" value="No"/>   
                  </div>                              
                </div>
               <!-- S2 -->
               <div id="Slide_End_S2">
                   
                    <div class="form-group col-md-12"  style="text-align:center">   <strong><i>--- Lessor Information --- </i></strong>                   
                            
                   </div> 
                   <div class="form-row">
                   <div class="form-group col-md-6"  style="text-align:left">    Date Rented                    
                            <input   type="text" runat="server" class="form-control" id="S2_DateRented"  readonly="true" value=""/>           
                   </div>
                  <div class="form-group col-md-6" style="text-align:left">  Rent Per Month   
                      <input   type="text" runat="server" class="form-control" id="S2_RentPerMonth"  readonly="true" value=""  onblur="FormatCurrency(this);" onkeypress="validate(event);"/>   
                  </div>  
                     <div class="form-group col-md-6" style="text-align:left">  Lessor First Name   
                      <input   type="text" runat="server" class="form-control" id="S2_FName"  readonly="true" value=""/>   
                  </div> 
                     <div class="form-group col-md-6" style="text-align:left">  Lessor Last Name   
                      <input   type="text" runat="server" class="form-control" id="S2_LName"  readonly="true" value=""/>   
                  </div>       
                        <div class="form-group col-md-6" style="text-align:left">  Barangay   
                      <input   type="text" runat="server" class="form-control" id="S2_Brgy"  readonly="true" value=""/>   
                  </div>    
                      <div class="form-group col-md-6" style="text-align:left">  Street   
                      <input   type="text" runat="server" class="form-control" id="S2_Street"  readonly="true" value=""/>   
                  </div>    
                      <div class="form-group col-md-6" style="text-align:left">  Address   
                      <input   type="text" runat="server" class="form-control" id="S2_Address"  readonly="true" value=""/>   
                  </div>    
                     <div class="form-group col-md-6" style="text-align:left">  Tel No.   
                      <input   type="text" runat="server" class="form-control" id="S2_TelNo"  readonly="true" value=""/>   
                  </div>  
                       <div class="form-group col-md-6" style="text-align:left">  Email   
                      <input   type="text" runat="server" class="form-control" id="S2_Email"  readonly="true" value=""/>   
                  </div>                 
                      
                         <div class="form-group col-md-6" style="text-align:left">  Administrator   
                      <input   type="text" runat="server" class="form-control" id="S2_Administrator"  readonly="true" value=""/>   
                  </div>            
                </div>
                   </div>
               <!-- S3
                <div class="form-row" id="Slide_End_S3">
                   <div class="form-group col-md-6"  style="text-align:left">    Owner Picture                    
                            <input   type="text" runat="server" class="form-control" id="S3_OwnerIMG"  readonly="true" value="Single"/>           
                   </div>
                  <div class="form-group col-md-6" style="text-align:left">  Establishment Picture   
                      <input   type="text" runat="server" class="form-control" id="S3_EstablishmentIMG"  readonly="true" value="No"/>   
                  </div>                              
                     <div class="form-group col-md-6" style="text-align:left">  Map Location Picture
                      <input   type="text" runat="server" class="form-control" id="S3_MapIMG"  readonly="true" value="No"/>   
                  </div>
                </div>
               -- S4 --
                <div class="form-row" id="Slide_End_S4">
                   <div class="form-group col-md-6"  style="text-align:left">    Re                  
                            <input   type="text" runat="server" class="form-control" id="S4_OwnerIMG"  readonly="true" value="Single"/>           
                   </div>                 
          </div>
            -->
               <!-- S5 -->  
               <div>
                     <div class="form-group col-md-12"  style="text-align:center">   <strong><i>--- Government Registration --- </i></strong>     </div>        
                <!-- CDA -->
               <div class="form-row" id="Slide_End_frmCDA">
                       
                  
                   <div class="form-group col-md-6"  style="text-align:left">        CDA No.: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="CDA_No"  id="S5_CDA" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: CDA <br />        
                <input  type="text" runat="server" readonly="true" name="CDA_RegDate" class="form-control" id="S5_CDA2" />
                 </div>               
            </div>
               <!-- DTI -->
               <div class="form-row" id="Slide_End_frmDTI">
                   <div class="form-group col-md-6"  style="text-align:left">        DTI No.: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="DTI_No"  id="S5_DTI" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: DTI <br />        
                <input  type="text" runat="server" readonly="true" name="DTI_RegDate" class="form-control" id="S5_DTI2" />
                 </div>               
            </div>
               <!-- SEC  -->
               <div class="form-row" id="Slide_End_frmSEC">
                   <div class="form-group col-md-6"  style="text-align:left">        SEC  No.: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="SEC_No"  id="S5_SEC"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: SEC<br />        
                <input  type="text" runat="server" readonly="true" name="SEC_RegDate" class="form-control" id="S5_SEC2" />
                 </div>               
            </div>
               <!-- TIN  -->
               <div class="form-row" id="Slide_End_frmTIN">
                   <div class="form-group col-md-6"  style="text-align:left">        TIN  No.: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="TIN_No"  id="S5_TIN" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: TIN<br />        
                <input  type="text" runat="server" readonly="true" name="TIN_RegDate" class="form-control" id="S5_TIN2" />
                 </div>               
            </div>
               <!-- SSS  -->
               <div class="form-row" id="Slide_End_frmSSS">
                   <div class="form-group col-md-6"  style="text-align:left">        SSS  No.: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="SSS_No"  id="S5_SSS" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: SSS<br />        
                <input  type="text" runat="server" readonly="true" name="SSS_RegDate" class="form-control" id="S5_SSS2" />
                 </div>               
            </div>
               <!-- Brgy Clearance  -->
               <div class="form-row" id="Slide_End_frmBrgy">
                   <div class="form-group col-md-6"  style="text-align:left">        Brgy Clearance No.: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="Brgy_No"  id="S5_Brgy" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: Brgy<br />        
                <input  type="text" runat="server" readonly="true" name="Brgy_RegDate" class="form-control" id="S5_Brgy2" />
                 </div>               
            </div>

               <!-- CTC  -->
               <div class="form-row" id="Slide_End_frmCTC">
                   <div class="form-group col-md-6"  style="text-align:left">        CTC  No.: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="CTC_No"  id="S5_CTC" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: CTC<br />        
                <input  type="text" runat="server" readonly="true" name="CTC_RegDate" class="form-control" id="S5_CTC2" />
                 </div>               
            </div>

               <!-- CTC Place  -->
               <div class="form-row" id="Slide_End_frmCTCPlace">
                   <div class="form-group col-md-6"  style="text-align:left">        CTC Place: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="CTC_Place"  id="S5_CTCPlace" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          CTC Amount:<br />        
                <input  type="text" runat="server" readonly="true" name="CTC_Amount" class="form-control" id="S5_CTCPlace2" style="text-align:right" pattern="[0-9]+" oninput="this.reportValidity()" title="Amount"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                        </div>               
            </div>

                <!-- BIR  -->
               <div class="form-row" id="Slide_End_frmBIR">
                   <div class="form-group col-md-6"  style="text-align:left">       BIR Registration No.: *<br />                     
                <input   type="text" runat="server" runat="server" readonly="true" class="form-control" name="CTC_Place"  id="S5_BIR"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: BIR<br />        
                <input  type="text" runat="server" readonly="true" name="BIR_RegDate" class="form-control" id="S5_BIR2"/>
               </div>               
            </div>                 
        </div>                
               <!-- S6 -->
               <div>
                      <div class="form-group col-md-12"  style="text-align:center">   <strong><i>--- Business Information --- </i></strong> </div>
                      <div class="form-row" >
                   <div class="form-group col-md-6"  style="text-align:left">        Date Established<br />                     
                <input   type="text" runat="server"  readonly="true" class="form-control"  id="S6_DateEstablished" />
              </div>
                    <div class="form-group col-md-6" style="text-align:left">          Branch <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S6_Branch" />
                 </div>  
                             <div class="form-group col-md-12" style="text-align:left">        Business Trade Name <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S6_TradeName" />
                     
                    </div>
                      
                     <div class="form-group col-md-12"  style="text-align:center">  <i>--- Number of Employees --- </i> </div>
                    
                      <div class="form-group col-md-12" style="text-align:left">          No. of Male <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S6_NoMale" /></div>

                            <div class="form-group col-md-12" style="text-align:left">          No. of female <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S6_NoFemale" />
                 </div>   

                          
                            <div class="form-group col-md-12" style="text-align:left">          No. of Employees residing within the City/Municipality <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S6_NoLGU" />
                 </div>   
                        </div>        
                        </div>
               <!-- S7 -->
               <div>
                      <div class="form-group col-md-12"  style="text-align:center">   <strong><i>--- Business Address --- </i></strong> </div>
                     <div class="form-row" >
                     <div class="form-group col-md-6" style="text-align:left">          Barangay <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S7_Brgy" />
                         <input  type="hidden" runat="server" class="form-control" id="S7_DistCode" />
                         <input  type="hidden" runat="server" class="form-control" id="S7_Brgy_code" />
                     </div>

                            <div class="form-group col-md-6" style="text-align:left">         Street <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S7_Street" />
                                <input  type="hidden" runat="server" class="form-control" id="S7_Street_code" />
                 </div>   

                     <div class="form-group col-md-6" style="text-align:left;display:none">         GrpBlg <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S7_GrpBlg" />
                 </div>   

                     <div class="form-group col-md-6" style="text-align:left;display:none">         Sticker No. <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S7_StickerNo" />
                 </div>   

                     <div class="form-group col-md-6" style="text-align:left;display:none">         Plate No. <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S7_PlateNo" />
                 </div>   

                     <div class="form-group col-md-6" style="text-align:left;display:none">         Stall No. <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S7_StallNo" />
                 </div>   

                     <div class="form-group col-md-12" style="text-align:left">         Address <br />        
                <textarea   type="text" runat="server" readonly="true"  class="form-control" id="S7_Address" />
                 </div>   
   </div>
                    
                </div>
               <!-- S8 -->
               <div>
                      <div class="form-group col-md-12"  style="text-align:center">   <strong><i>--- Owner Information --- </i></strong> </div>
                             <div class="form-row" >
                      <div class="form-group col-md-6" style="text-align:left">         Last Name <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_Lname" />
                 </div>   

                      <div class="form-group col-md-6" style="text-align:left">         First Name <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_Fname" />
                 </div>   

                      <div class="form-group col-md-6" style="text-align:left">         Middle Name <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_Mname" />
                 </div>   

                                  <div class="form-group col-md-6" style="text-align:left">         Suffix <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_Suffix" />
                 </div> 

                      <div class="form-group col-md-6" style="text-align:left">         Gender <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_Gender" />
                 </div>   

                      <div class="form-group col-md-6" style="text-align:left">         Citizenship <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_Citizenship" />
                 </div>   

                      <div class="form-group col-md-12" style="text-align:left">         Address <br />        
                <textarea  runat="server" readonly="true"  class="form-control" id="S8_Address" />
                 </div>   

                      <div class="form-group col-md-6" style="text-align:left">         Tel No. <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_TelNo" />
                 </div>   

                      <div class="form-group col-md-6" style="text-align:left;display:none">         Email Address <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_Email" />
                 </div>   

                      <div class="form-group col-md-12" style="text-align:left">         Alternate Email Address <br />        
                <input  type="text" runat="server" readonly="true"  class="form-control" id="S8_AlternateEmail" />
    </div>   
    </div>
    </div>

		  <hr/>
		
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">            
	<button type="button" class="btn btn-primary" id="Back_12" onclick="ShowNext(this.id)">Back</button> &nbsp
    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#Confirm" data-ticket-type="standard-access">Confirm</button>
 
   
                  </span>	 		 
                            
          </div>
          </div> 
          </div>
                   </div>
                 </center>
      </div>

      <div id="snackbar">
            <asp:Label runat="server" id="_oLabelSnackbar"/>           
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
  <script>
      var today = new Date();
      var dd = today.getDate();
      var mm = today.getMonth() + 1; //January is 0!
      var yyyy = today.getFullYear();
      if (dd < 10) {
          dd = '0' + dd
      }
      if (mm < 10) {
          mm = '0' + mm
      }

      today = yyyy + '-' + mm + '-' + dd;
      document.getElementById('<%=Slide_02_DateRented.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_05_CDA2.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_05_DTI2.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_05_SEC2.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_05_TIN2.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_05_SSS2.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_05_CTC2.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_05_BIR2.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_05_BRGY2.ClientID%>').setAttribute("max", today);
      document.getElementById('<%=Slide_06_DateEstablished.ClientID%>').setAttribute("max", today);
 

				 
			 

                </script>

      <script>

          $(document).ready(function () {
              $('input[type="checkbox"]').click(function () {
                  if ($(this).prop("checked") == true) {
                      document.getElementById('<%=Slide_08_Address.ClientID%>').value = localStorage.getItem("Slide_07_Address");
                      document.getElementById('<%=Slide_08_Address.ClientID%>').disabled = true;
                  }
                  else if ($(this).prop("checked") == false) {
                      document.getElementById('<%=Slide_08_Address.ClientID%>').value = "";
                      document.getElementById('<%=Slide_08_Address.ClientID%>').disabled = false;

                  }
              });
          });

      function numberWithCommas(x) {
          return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
      }

      function removeComma(x) {
          document.getElementById('<%=Slide_02_RentPerMonth.ClientID%>').value = x.replace(/,/g, '');


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
                  case "Slide_07_Brgy":
                      var sel = document.getElementById('<%=Slide_07_Brgy.ClientID%>')
                          var DistCode_BrgyCode = document.getElementById('<%=Slide_07_Brgy.ClientID%>').value
                          var parts = DistCode_BrgyCode.split('_', 2);
                          var DistCode = parts[0];
                          var BrgyCode = parts[1];

                          localStorage.setItem("Slide_07_Brgy", sel.options[sel.selectedIndex].text);

                          document.getElementById('<%=Slide_07_SelectedDistCode.ClientID%>').value = DistCode;
                         document.getElementById('<%=Slide_07_SelectedBrgy.ClientID%>').value = BrgyCode;



                          var filter = BrgyCode;
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
                          var sel = document.getElementById('<%=Slide_07_Street.ClientID%>')
                         localStorage.setItem("Slide_07_Street", sel.options[sel.selectedIndex].text);

                         document.getElementById('<%=Slide_07_SelectedStreet.ClientID%>').value = sel.value;


                         var STR = document.getElementById('<%=Slide_07_Street.ClientID%>');
                         document.getElementById('<%=Slide_07_SelectedStreet.ClientID%>').value = STR.options[STR.selectedIndex].value;
                         break;

                     case "Slide_08_Citizenship":
                         document.getElementById('<%=Slide_08_SelectedCitizenship.ClientID%>').value = sel.value;
                         var CTZ = document.getElementById('<%=Slide_08_Citizenship.ClientID%>');
                         document.getElementById('<%=Slide_08_SelectedCitizenship.ClientID%>').value = CTZ.options[CTZ.selectedIndex].value;
                         break;
                 }
             }



             function ShowNext(NextID) {

                 if (NextID.substring(0, 4) == 'Next') {
                     var formID = $("#" + NextID).closest("form").attr("id");
                     var form = document.querySelector("#" + formID);
                     var reportButton = document.querySelector("#" + NextID);
                     var validation = form.reportValidity();
                     if (validation != true) {
                         return false;
                     }
                 }
                 switch (NextID) {

                     case "radio1":
                         document.getElementById("Next_01").style.opacity = "1";
                         document.getElementById("Next_01").style.cursor = "default";
                         document.getElementById("Next_01").disabled = false;
                         document.getElementById("SelectedYesNo").value = "Slide_01 Yes";
                         break;

                     case "radio2":
                         document.getElementById("Next_01").style.opacity = "1";
                         document.getElementById("Next_01").style.cursor = "default";
                         document.getElementById("Next_01").disabled = false;
                         document.getElementById("SelectedYesNo").value = "Slide_01 No";
                         break;

                     case "Next_01":
                         //  alert(localStorage.getItem("Slide_01_OwnershipType"));
                         switch (localStorage.getItem("Slide_01_OwnershipType")) {
                             case null:
                                 alert("Please select Ownership Type.");
                                 return false;
                         }
                         document.getElementById("Next_02").disabled = false;
                         //  document.getElementById("Next_03").disabled = false;  

                         //  switch(localStorage.getItem("Slide_01_OwnershipType")){
                         //      case "";
                         //  }
                         switch (document.getElementById("SelectedYesNo").value) {
                             case "Slide_01 Yes":
                                 //show next slide
                                 document.getElementById("Slide_01").style.display = "none";
                                 document.getElementById("Slide_02").style.display = "block";
                                 document.getElementById("Slide_End_S2").style.display = "block";

                                 //temp save data on prev slide
                                 localStorage.setItem("Slide_01_IsRented", "Yes");
                                 localStorage.setItem("Progress", 10);
                                 break;

                             case "Slide_01 No":
                                 //show next slide
                                 document.getElementById("Slide_01").style.display = "none";
                                 //  document.getElementById("Slide_011_S2").style.display = "none";
                                 document.getElementById("Slide_05").style.display = "block";
                                 document.getElementById("Slide_End_S2").style.display = "none";
                                 //temp save data on prev slide
                                 localStorage.setItem("Slide_01_IsRented", "No");
                                 localStorage.setItem("Progress", 20);

                                 var ownershiptype = localStorage.getItem('Slide_01_OwnershipType');
                                 // alert(ownershiptype);
                                 switch (ownershiptype) {
                                     case "Single":
                                         document.getElementById("frmCDA").style.display = "none";
                                         document.getElementById("frmSEC").style.display = "none";
                                         document.getElementById('<%=Slide_05_CDA.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_SEC.ClientID%>').required = false;



                                         document.getElementById("frmBIR").style.display = "flex";
                                         document.getElementById("frmDTI").style.display = "flex";
                                         document.getElementById("frmTIN").style.display = "flex";
                                         document.getElementById("frmSSS").style.display = "flex";
                                         document.getElementById("frmBrgy").style.display = "flex";
                                         document.getElementById('<%=Slide_05_BIR.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_DTI.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_TIN.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_SSS.ClientID%>').required = true;

                                         //-----------------
                                         document.getElementById("Slide_End_frmCDA").style.display = "none";
                                         document.getElementById("Slide_End_frmDTI").style.display = "flex";
                                         document.getElementById("Slide_End_frmSEC").style.display = "none";
                                         document.getElementById("Slide_End_frmTIN").style.display = "flex";
                                         document.getElementById("Slide_End_frmSSS").style.display = "flex";
                                         document.getElementById("Slide_End_frmBrgy").style.display = "flex";
                                         document.getElementById("Slide_End_frmCTC").style.display = "none";
                                         document.getElementById("Slide_End_frmCTCPlace").style.display = "none";
                                         document.getElementById("Slide_End_frmBIR").style.display = "flex";
                                         //-----------------
                                         // document.getElementById("Slide_04").style.display = "none";
                                         document.getElementById("Slide_05").style.display = "block";
                                         break;

                                     case "Corporation":
                                         document.getElementById("frmCDA").style.display = "none";
                                         document.getElementById("frmDTI").style.display = "none";
                                         document.getElementById("frmTIN").style.display = "none";
                                         document.getElementById('<%=Slide_05_CDA.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_DTI.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_TIN.ClientID%>').required = false;

                                         document.getElementById("frmSEC").style.display = "flex";
                                         document.getElementById("frmSSS").style.display = "flex";
                                         document.getElementById("frmBrgy").style.display = "flex";
                                         document.getElementById("frmBIR").style.display = "flex";
                                         document.getElementById('<%=Slide_05_SEC.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_SSS.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_BIR.ClientID%>').required = true;
                                         //-----------------
                                         document.getElementById("Slide_End_frmCDA").style.display = "none";
                                         document.getElementById("Slide_End_frmDTI").style.display = "none";
                                         document.getElementById("Slide_End_frmSEC").style.display = "flex";
                                         document.getElementById("Slide_End_frmTIN").style.display = "none";
                                         document.getElementById("Slide_End_frmSSS").style.display = "flex";
                                         document.getElementById("Slide_End_frmBrgy").style.display = "flex";
                                         document.getElementById("Slide_End_frmCTC").style.display = "none";
                                         document.getElementById("Slide_End_frmCTCPlace").style.display = "none";
                                         document.getElementById("Slide_End_frmBIR").style.display = "flex";
                                         //-----------------
                                         //  document.getElementById("Slide_04").style.display = "none";
                                         document.getElementById("Slide_05").style.display = "block";
                                         break;

                                     case "Cooperative":
                                         document.getElementById("frmDTI").style.display = "none";
                                         document.getElementById("frmTIN").style.display = "none";
                                         document.getElementById("frmSSS").style.display = "none";
                                         document.getElementById("frmBIR").style.display = "none";
                                         document.getElementById('<%=Slide_05_DTI.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_TIN.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_SSS.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_BIR.ClientID%>').required = false;

                                         document.getElementById("frmCDA").style.display = "flex";
                                         document.getElementById("frmSEC").style.display = "flex";
                                         document.getElementById("frmBrgy").style.display = "flex";
                                         document.getElementById('<%=Slide_05_CDA.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_SEC.ClientID%>').required = true;

                                         //-----------------
                                         document.getElementById("Slide_End_frmCDA").style.display = "flex";
                                         document.getElementById("Slide_End_frmDTI").style.display = "none";
                                         document.getElementById("Slide_End_frmSEC").style.display = "flex";
                                         document.getElementById("Slide_End_frmTIN").style.display = "none";
                                         document.getElementById("Slide_End_frmSSS").style.display = "none";
                                         document.getElementById("Slide_End_frmBrgy").style.display = "flex";
                                         document.getElementById("Slide_End_frmCTC").style.display = "none";
                                         document.getElementById("Slide_End_frmCTCPlace").style.display = "none";
                                         document.getElementById("Slide_End_frmBIR").style.display = "none";

                                         //-----------------


                                         document.getElementById("Slide_05").style.display = "block";
                                         break;

                                     case "Partnership":
                                         document.getElementById("frmCDA").style.display = "none";
                                         document.getElementById("frmDTI").style.display = "none";
                                         document.getElementById("frmTIN").style.display = "none"; document.getElementById("frmBrgy").style.display = "none";
                                         document.getElementById("frmBIR").style.display = "none";
                                         document.getElementById('<%=Slide_05_CDA.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_DTI.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_TIN.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_BIR.ClientID%>').required = false;

                                         document.getElementById("frmSEC").style.display = "flex";
                                         document.getElementById("frmSSS").style.display = "flex";
                                         document.getElementById('<%=Slide_05_SEC.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_SSS.ClientID%>').required = true;

                                         //-----------------
                                         document.getElementById("Slide_End_frmCDA").style.display = "none";
                                         document.getElementById("Slide_End_frmDTI").style.display = "none";
                                         document.getElementById("Slide_End_frmSEC").style.display = "flex";
                                         document.getElementById("Slide_End_frmTIN").style.display = "none";
                                         document.getElementById("Slide_End_frmSSS").style.display = "flex";
                                         document.getElementById("Slide_End_frmBrgy").style.display = "none";
                                         document.getElementById("Slide_End_frmCTC").style.display = "none";
                                         document.getElementById("Slide_End_frmCTCPlace").style.display = "none";
                                         document.getElementById("Slide_End_frmBIR").style.display = "none";

                                         //-----------------

                                         document.getElementById("Slide_05").style.display = "block";
                                         break;
                                 }


                                 break;
                         }


                         break;

                     case "Next_02":
                         //show next slide                     
                         document.getElementById("SelectedYesNo").value = "Slide_01 Yes";
                         document.getElementById("Slide_02").style.display = "none";
                         document.getElementById("Slide_05").style.display = "block";
                         //temp save data on prev slide          
                         localStorage.setItem("Slide_02_DateRented", document.getElementById("Slide_02_DateRented").innerHTML);
                         localStorage.setItem("Slide_02_RentPerMonth", document.getElementById('<%=Slide_02_RentPerMonth.ClientID%>').value);
                         localStorage.setItem("Slide_02_LessorFname", document.getElementById('<%=Slide_02_LessorFname.ClientID%>').value);
                         localStorage.setItem("Slide_02_LessorLname", document.getElementById('<%=Slide_02_LessorLname.ClientID%>').value);
                         localStorage.setItem("Slide_02_Brgy", document.getElementById('<%=Slide_02_Brgy.ClientID%>').value);
                         localStorage.setItem("Slide_02_Street", document.getElementById('<%=Slide_02_Street.ClientID%>').value);
                         localStorage.setItem("Slide_02_Address", document.getElementById('<%=Slide_02_Address.ClientID%>').value);
                         localStorage.setItem("Slide_02_TelNo", document.getElementById('<%=Slide_02_TelNo.ClientID%>').value);
                         localStorage.setItem("Slide_02_Email", document.getElementById('<%=Slide_02_Email.ClientID%>').value);
                         localStorage.setItem("Slide_02_Administrator", document.getElementById('<%=Slide_02_Administrator.ClientID%>').value);

                         var ownershiptype = localStorage.getItem('Slide_01_OwnershipType');
                         // alert(ownershiptype);
                         switch (ownershiptype) {
                             case "Single":
                                 document.getElementById("frmCDA").style.display = "none";
                                 document.getElementById("frmSEC").style.display = "none";
                                 document.getElementById('<%=Slide_05_CDA.ClientID%>').required = false;
                                 document.getElementById('<%=Slide_05_SEC.ClientID%>').required = false;



                                 document.getElementById("frmBIR").style.display = "flex";
                                 document.getElementById("frmDTI").style.display = "flex";
                                 document.getElementById("frmTIN").style.display = "flex";
                                 document.getElementById("frmSSS").style.display = "flex";
                                 document.getElementById("frmBrgy").style.display = "flex";
                                 document.getElementById('<%=Slide_05_BIR.ClientID%>').required = true;
                                document.getElementById('<%=Slide_05_DTI.ClientID%>').required = true;
                                 document.getElementById('<%=Slide_05_TIN.ClientID%>').required = true;
                                 document.getElementById('<%=Slide_05_SSS.ClientID%>').required = true;

                                 //-----------------
                                 document.getElementById("Slide_End_frmCDA").style.display = "none";
                                 document.getElementById("Slide_End_frmDTI").style.display = "flex";
                                 document.getElementById("Slide_End_frmSEC").style.display = "none";
                                 document.getElementById("Slide_End_frmTIN").style.display = "flex";
                                 document.getElementById("Slide_End_frmSSS").style.display = "flex";
                                 document.getElementById("Slide_End_frmBrgy").style.display = "flex";
                                 document.getElementById("Slide_End_frmCTC").style.display = "none";
                                 document.getElementById("Slide_End_frmCTCPlace").style.display = "none";
                                 document.getElementById("Slide_End_frmBIR").style.display = "flex";
                                 //-----------------
                                 // document.getElementById("Slide_04").style.display = "none";
                                 document.getElementById("Slide_05").style.display = "block";
                                 break;

                             case "Corporation":
                                 document.getElementById("frmCDA").style.display = "none";
                                 document.getElementById("frmDTI").style.display = "none";
                                 document.getElementById("frmTIN").style.display = "none";
                                 document.getElementById('<%=Slide_05_CDA.ClientID%>').required = false;
                                document.getElementById('<%=Slide_05_DTI.ClientID%>').required = false;
                                document.getElementById('<%=Slide_05_TIN.ClientID%>').required = false;

                                document.getElementById("frmSEC").style.display = "flex";
                                document.getElementById("frmSSS").style.display = "flex";
                                document.getElementById("frmBrgy").style.display = "flex";
                                document.getElementById("frmBIR").style.display = "flex";
                                document.getElementById('<%=Slide_05_SEC.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_SSS.ClientID%>').required = true;
                                document.getElementById('<%=Slide_05_BIR.ClientID%>').required = true;
                                //-----------------
                                document.getElementById("Slide_End_frmCDA").style.display = "none";
                                document.getElementById("Slide_End_frmDTI").style.display = "none";
                                document.getElementById("Slide_End_frmSEC").style.display = "flex";
                                document.getElementById("Slide_End_frmTIN").style.display = "none";
                                document.getElementById("Slide_End_frmSSS").style.display = "flex";
                                document.getElementById("Slide_End_frmBrgy").style.display = "flex";
                                document.getElementById("Slide_End_frmCTC").style.display = "none";
                                document.getElementById("Slide_End_frmCTCPlace").style.display = "none";
                                document.getElementById("Slide_End_frmBIR").style.display = "flex";
                                //-----------------
                                //  document.getElementById("Slide_04").style.display = "none";
                                document.getElementById("Slide_05").style.display = "block";
                                break;

                            case "Cooperative":
                                document.getElementById("frmDTI").style.display = "none";
                                document.getElementById("frmTIN").style.display = "none";
                                document.getElementById("frmSSS").style.display = "none";
                                document.getElementById("frmBIR").style.display = "none";
                                document.getElementById('<%=Slide_05_DTI.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_TIN.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_SSS.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_BIR.ClientID%>').required = false;

                                         document.getElementById("frmCDA").style.display = "flex";
                                         document.getElementById("frmSEC").style.display = "flex";
                                         document.getElementById("frmBrgy").style.display = "flex";
                                         document.getElementById('<%=Slide_05_CDA.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_SEC.ClientID%>').required = true;

                                         //-----------------
                                         document.getElementById("Slide_End_frmCDA").style.display = "flex";
                                         document.getElementById("Slide_End_frmDTI").style.display = "none";
                                         document.getElementById("Slide_End_frmSEC").style.display = "flex";
                                         document.getElementById("Slide_End_frmTIN").style.display = "none";
                                         document.getElementById("Slide_End_frmSSS").style.display = "none";
                                         document.getElementById("Slide_End_frmBrgy").style.display = "flex";
                                         document.getElementById("Slide_End_frmCTC").style.display = "none";
                                         document.getElementById("Slide_End_frmCTCPlace").style.display = "none";
                                         document.getElementById("Slide_End_frmBIR").style.display = "none";

                                         //-----------------


                                         document.getElementById("Slide_05").style.display = "block";
                                         break;

                                     case "Partnership":
                                         document.getElementById("frmCDA").style.display = "none";
                                         document.getElementById("frmDTI").style.display = "none";
                                         document.getElementById("frmTIN").style.display = "none"; document.getElementById("frmBrgy").style.display = "none";
                                         document.getElementById("frmBIR").style.display = "none";
                                         document.getElementById('<%=Slide_05_CDA.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_DTI.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_TIN.ClientID%>').required = false;
                                         document.getElementById('<%=Slide_05_BIR.ClientID%>').required = false;

                                         document.getElementById("frmSEC").style.display = "flex";
                                         document.getElementById("frmSSS").style.display = "flex";
                                         document.getElementById('<%=Slide_05_SEC.ClientID%>').required = true;
                                         document.getElementById('<%=Slide_05_SSS.ClientID%>').required = true;

                                         //-----------------
                                         document.getElementById("Slide_End_frmCDA").style.display = "none";
                                         document.getElementById("Slide_End_frmDTI").style.display = "none";
                                         document.getElementById("Slide_End_frmSEC").style.display = "flex";
                                         document.getElementById("Slide_End_frmTIN").style.display = "none";
                                         document.getElementById("Slide_End_frmSSS").style.display = "flex";
                                         document.getElementById("Slide_End_frmBrgy").style.display = "none";
                                         document.getElementById("Slide_End_frmCTC").style.display = "none";
                                         document.getElementById("Slide_End_frmCTCPlace").style.display = "none";
                                         document.getElementById("Slide_End_frmBIR").style.display = "none";

                                         //-----------------

                                         document.getElementById("Slide_05").style.display = "block";
                                         break;
                                 }



                                 break;

                             case "Next_03":
                                 break;
                             case "Next_04":
                                 break;

                             case "Next_05":
                                 //temp save data on prev slide        
                                 localStorage.setItem("Slide_05_CDA", document.getElementById("Slide_05_CDA").value);
                                 localStorage.setItem("Slide_05_CDA2", document.getElementById("Slide_05_CDA2").value);
                                 localStorage.setItem("Slide_05_DTI", document.getElementById("Slide_05_DTI").value);
                                 localStorage.setItem("Slide_05_DTI2", document.getElementById("Slide_05_DTI2").value);
                                 localStorage.setItem("Slide_05_SEC", document.getElementById("Slide_05_SEC").value);
                                 localStorage.setItem("Slide_05_SEC2", document.getElementById("Slide_05_SEC2").value);
                                 localStorage.setItem("Slide_05_TIN", document.getElementById("Slide_05_TIN").value);
                                 localStorage.setItem("Slide_05_TIN2", document.getElementById("Slide_05_TIN2").value);
                                 localStorage.setItem("Slide_05_SSS", document.getElementById("Slide_05_SSS").value);
                                 localStorage.setItem("Slide_05_SSS2", document.getElementById("Slide_05_SSS2").value);
                                 localStorage.setItem("Slide_05_Brgy", document.getElementById("Slide_05_Brgy").value);
                                 localStorage.setItem("Slide_05_Brgy2", document.getElementById("Slide_05_Brgy2").value);
                                 localStorage.setItem("Slide_05_CTC", document.getElementById("Slide_05_CTC").value);
                                 localStorage.setItem("Slide_05_CTC2", document.getElementById("Slide_05_CTC2").value);
                                 localStorage.setItem("Slide_05_CTCPlace", document.getElementById("Slide_05_CTCPlace").value);
                                 localStorage.setItem("Slide_05_CTCPlace2", document.getElementById("Slide_05_CTCPlace2").value);
                                 localStorage.setItem("Slide_05_BIR", document.getElementById("Slide_05_BIR").value);
                                 localStorage.setItem("Slide_05_BIR2", document.getElementById("Slide_05_BIR2").value);

                                 document.getElementById("Slide_05").style.display = "none";
                                 document.getElementById("Slide_06").style.display = "block";
                                 break;

                             case "Next_06":
                                 localStorage.setItem("Slide_06_DateEstablished", document.getElementById("Slide_06_DateEstablished").value);
                                 localStorage.setItem("Slide_06_TradeName", document.getElementById("Slide_06_TradeName").value);

                                 localStorage.setItem("Slide_06_Branch", document.getElementById("Slide_06_Branch").value);
                                 localStorage.setItem("Slide_06_NoMale", document.getElementById("Slide_06_NoMale").value);
                                 localStorage.setItem("Slide_06_NoFemale", document.getElementById("Slide_06_NoFemale").value);
                                 localStorage.setItem("Slide_06_NoLGU", document.getElementById("Slide_06_NoLGU").value);

                                 document.getElementById("Slide_06").style.display = "none";
                                 document.getElementById("Slide_07").style.display = "block";
                                 break;
                             case "Next_07":
                                 localStorage.setItem("Slide_07_DistCode", document.getElementById("Slide_07_SelectedDistCode").value);
                                 localStorage.setItem("Slide_07_GrpBlg", document.getElementById("Slide_07_GrpBlg").value);
                                 localStorage.setItem("Slide_07_StickerNo", document.getElementById("Slide_07_StickerNo").value);
                                 localStorage.setItem("Slide_07_PlateNo", document.getElementById("Slide_07_PlateNo").value);
                                 localStorage.setItem("Slide_07_StallNo", document.getElementById("Slide_07_StallNo").value);
                                 localStorage.setItem("Slide_07_Address", document.getElementById("Slide_07_Address").value);

                                 document.getElementById("Slide_07").style.display = "none";
                                 document.getElementById("Slide_08").style.display = "block";
                                 break;
                             case "Next_08":
                                 localStorage.setItem("Slide_08_Lname", document.getElementById("Slide_08_Lname").value);
                                 localStorage.setItem("Slide_08_Fname", document.getElementById("Slide_08_Fname").value);
                                 localStorage.setItem("Slide_08_Mname", document.getElementById("Slide_08_Mname").value);
                                 localStorage.setItem("Slide_08_Suffix", document.getElementById("Slide_08_Suffix").value);
                                 localStorage.setItem("Slide_08_Gender", document.getElementById("Slide_08_Gender").value);
                                 localStorage.setItem("Slide_08_Citizenship", document.getElementById("Slide_08_SelectedCitizenship").value);
                                 localStorage.setItem("Slide_08_Address", document.getElementById("Slide_08_Address").value);
                                 localStorage.setItem("Slide_08_TelNo", document.getElementById("Slide_08_TelNo").value);
                                 localStorage.setItem("Slide_08_AlternateEmail", document.getElementById("Slide_08_AlternateEmail").value);

                                 // Get Summary
                                 //S1
                                 document.getElementById('<%=S1_OwnershipType.ClientID%>').value = localStorage.getItem("Slide_01_OwnershipType");
                                 document.getElementById('<%=S1_IsRented.ClientID%>').value = localStorage.getItem("Slide_01_IsRented");
                                 //s2
                                 document.getElementById('<%=S2_DateRented.ClientID%>').value = localStorage.getItem("Slide_02_DateRented_Formatted");
                                 document.getElementById('<%=S2_RentPerMonth.ClientID%>').value = localStorage.getItem("Slide_02_RentPerMonth");
                                 document.getElementById('<%=S2_FName.ClientID%>').value = localStorage.getItem("Slide_02_LessorFname");
                                 document.getElementById('<%=S2_LName.ClientID%>').value = localStorage.getItem("Slide_02_LessorLname");
                                 document.getElementById('<%=S2_Brgy.ClientID%>').value = localStorage.getItem("Slide_02_Brgy");
                                 document.getElementById('<%=S2_Street.ClientID%>').value = localStorage.getItem("Slide_02_Street");
                                 document.getElementById('<%=S2_Address.ClientID%>').value = localStorage.getItem("Slide_02_Address");
                                 document.getElementById('<%=S2_TelNo.ClientID%>').value = localStorage.getItem("Slide_02_TelNo");
                                 document.getElementById('<%=S2_Email.ClientID%>').value = localStorage.getItem("Slide_02_Email");
                                 document.getElementById('<%=S2_Administrator.ClientID%>').value = localStorage.getItem("Slide_02_Administrator");

                                 //s5
                                 document.getElementById('<%=S5_CDA.ClientID%>').value = localStorage.getItem("Slide_05_CDA");
                                 document.getElementById('<%=S5_CDA2.ClientID%>').value = localStorage.getItem("Slide_05_CDA2");
                                 document.getElementById('<%=S5_DTI.ClientID%>').value = localStorage.getItem("Slide_05_DTI");
                                 document.getElementById('<%=S5_DTI2.ClientID%>').value = localStorage.getItem("Slide_05_DTI2");
                                 document.getElementById('<%=S5_SEC.ClientID%>').value = localStorage.getItem("Slide_05_SEC");
                                 document.getElementById('<%=S5_SEC2.ClientID%>').value = localStorage.getItem("Slide_05_SEC2");
                                 document.getElementById('<%=S5_TIN.ClientID%>').value = localStorage.getItem("Slide_05_TIN");
                                 document.getElementById('<%=S5_TIN2.ClientID%>').value = localStorage.getItem("Slide_05_TIN2");
                                 document.getElementById('<%=S5_SSS.ClientID%>').value = localStorage.getItem("Slide_05_SSS");
                                 document.getElementById('<%=S5_SSS2.ClientID%>').value = localStorage.getItem("Slide_05_SSS2");
                                 document.getElementById('<%=S5_Brgy.ClientID%>').value = localStorage.getItem("Slide_05_Brgy");
                                 document.getElementById('<%=S5_Brgy2.ClientID%>').value = localStorage.getItem("Slide_05_Brgy2");
                                 document.getElementById('<%=S5_CTC.ClientID%>').value = localStorage.getItem("Slide_05_CTC");
                                 document.getElementById('<%=S5_CTC2.ClientID%>').value = localStorage.getItem("Slide_05_CTC2");
                                 document.getElementById('<%=S5_CTCPlace.ClientID%>').value = localStorage.getItem("Slide_05_CTCPlace");
                                 document.getElementById('<%=S5_CTCPlace2.ClientID%>').value = localStorage.getItem("Slide_05_CTCPlace2");
                                 document.getElementById('<%=S5_BIR.ClientID%>').value = localStorage.getItem("Slide_05_BIR");
                                 document.getElementById('<%=S5_BIR2.ClientID%>').value = localStorage.getItem("Slide_05_BIR2");

                                 //s6
                                 document.getElementById('<%=S6_DateEstablished.ClientID%>').value = localStorage.getItem("Slide_06_DateEstablished_Formatted");
                                 document.getElementById('<%=S6_TradeName.ClientID%>').value = localStorage.getItem("Slide_06_TradeName");
                                 document.getElementById('<%=S6_Branch.ClientID%>').value = localStorage.getItem("Slide_06_Branch");
                                 document.getElementById('<%=S6_NoMale.ClientID%>').value = localStorage.getItem("Slide_06_NoMale");
                                 document.getElementById('<%=S6_NoFemale.ClientID%>').value = localStorage.getItem("Slide_06_NoFemale");
                                 document.getElementById('<%=S6_NoLGU.ClientID%>').value = localStorage.getItem("Slide_06_NoLGU");

                                 //s7                                                 

                                 document.getElementById('<%=S7_Street_code.ClientID%>').value = document.getElementById('<%=Slide_07_Street.ClientID%>').value
                                 document.getElementById('<%=S7_Brgy_code.ClientID%>').value = document.getElementById('<%=Slide_07_SelectedBrgy.ClientID%>').value

                                 document.getElementById('<%=S7_DistCode.ClientID%>').value = localStorage.getItem("Slide_07_DistCode");
                                 document.getElementById('<%=S7_Brgy.ClientID%>').value = localStorage.getItem("Slide_07_Brgy");
                                 document.getElementById('<%=S7_Street.ClientID%>').value = localStorage.getItem("Slide_07_Street");
                                 document.getElementById('<%=S7_GrpBlg.ClientID%>').value = localStorage.getItem("Slide_07_GrpBlg");
                                 document.getElementById('<%=S7_StickerNo.ClientID%>').value = localStorage.getItem("Slide_07_StickerNo");
                                 document.getElementById('<%=S7_PlateNo.ClientID%>').value = localStorage.getItem("Slide_07_PlateNo");
                                 document.getElementById('<%=S7_StallNo.ClientID%>').value = localStorage.getItem("Slide_07_StallNo");
                                 document.getElementById('<%=S7_Address.ClientID%>').value = localStorage.getItem("Slide_07_Address");

                                 //s8
                                 document.getElementById('<%=S8_Lname.ClientID%>').value = localStorage.getItem("Slide_08_Lname");
                                 document.getElementById('<%=S8_Fname.ClientID%>').value = localStorage.getItem("Slide_08_Fname");
                                 document.getElementById('<%=S8_Mname.ClientID%>').value = localStorage.getItem("Slide_08_Mname");
                                 document.getElementById('<%=S8_Suffix.ClientID%>').value = localStorage.getItem("Slide_08_Suffix");
                                 document.getElementById('<%=S8_Gender.ClientID%>').value = localStorage.getItem("Slide_08_Gender");
                                 document.getElementById('<%=S8_Citizenship.ClientID%>').value = localStorage.getItem("Slide_08_Citizenship");
                                 document.getElementById('<%=S8_Address.ClientID%>').value = localStorage.getItem("Slide_08_Address");
                                 document.getElementById('<%=S8_TelNo.ClientID%>').value = localStorage.getItem("Slide_08_TelNo");
                                 document.getElementById('<%=S8_AlternateEmail.ClientID%>').value = localStorage.getItem("Slide_08_AlternateEmail");

                                 // show next Slide
                                 document.getElementById("Slide_08").style.display = "none";
                                 //document.getElementById("Slide_09").style.display = "block";
                                 document.getElementById("Slide_End").style.display = "block";
                                 break;
                             case "Next_09":
                                 document.getElementById("Slide_09").style.display = "none";
                                 document.getElementById("Slide_10").style.display = "block";
                                 break;
                                 //    case "Next_10":
                                 //        document.getElementById("Slide_10").style.display = "none";
                                 //        document.getElementById("Slide_End").style.display = "block";
                                 //         break;

                             case "Next_10":
                                 // Get Summary
                                 //S1
                                 document.getElementById('<%=S1_OwnershipType.ClientID%>').value = localStorage.getItem("Slide_01_OwnershipType");
                         document.getElementById('<%=S1_IsRented.ClientID%>').value = localStorage.getItem("Slide_01_IsRented");
                         //s2
                         document.getElementById('<%=S2_DateRented.ClientID%>').value = localStorage.getItem("Slide_02_DateRented_Formatted");
                         document.getElementById('<%=S2_RentPerMonth.ClientID%>').value = localStorage.getItem("Slide_02_RentPerMonth");
                         document.getElementById('<%=S2_FName.ClientID%>').value = localStorage.getItem("Slide_02_LessorFname");
                         document.getElementById('<%=S2_LName.ClientID%>').value = localStorage.getItem("Slide_02_LessorLname");
                         document.getElementById('<%=S2_Brgy.ClientID%>').value = localStorage.getItem("Slide_02_Brgy");
                         document.getElementById('<%=S2_Street.ClientID%>').value = localStorage.getItem("Slide_02_Street");
                         document.getElementById('<%=S2_Address.ClientID%>').value = localStorage.getItem("Slide_02_Address");
                         document.getElementById('<%=S2_TelNo.ClientID%>').value = localStorage.getItem("Slide_02_TelNo");
                         document.getElementById('<%=S2_Email.ClientID%>').value = localStorage.getItem("Slide_02_Email");
                         document.getElementById('<%=S2_Administrator.ClientID%>').value = localStorage.getItem("Slide_02_Administrator");

                         //s5
                         document.getElementById('<%=S5_CDA.ClientID%>').value = localStorage.getItem("Slide_05_CDA");
                         document.getElementById('<%=S5_CDA2.ClientID%>').value = localStorage.getItem("Slide_05_CDA2");
                         document.getElementById('<%=S5_DTI.ClientID%>').value = localStorage.getItem("Slide_05_DTI");
                         document.getElementById('<%=S5_DTI2.ClientID%>').value = localStorage.getItem("Slide_05_DTI2");
                         document.getElementById('<%=S5_SEC.ClientID%>').value = localStorage.getItem("Slide_05_SEC");
                         document.getElementById('<%=S5_SEC2.ClientID%>').value = localStorage.getItem("Slide_05_SEC2");
                         document.getElementById('<%=S5_TIN.ClientID%>').value = localStorage.getItem("Slide_05_TIN");
                         document.getElementById('<%=S5_TIN2.ClientID%>').value = localStorage.getItem("Slide_05_TIN2");
                         document.getElementById('<%=S5_SSS.ClientID%>').value = localStorage.getItem("Slide_05_SSS");
                         document.getElementById('<%=S5_SSS2.ClientID%>').value = localStorage.getItem("Slide_05_SSS2");
                         document.getElementById('<%=S5_Brgy.ClientID%>').value = localStorage.getItem("Slide_05_Brgy");
                         document.getElementById('<%=S5_Brgy2.ClientID%>').value = localStorage.getItem("Slide_05_Brgy2");
                         document.getElementById('<%=S5_CTC.ClientID%>').value = localStorage.getItem("Slide_05_CTC");
                         document.getElementById('<%=S5_CTC2.ClientID%>').value = localStorage.getItem("Slide_05_CTC2");
                         document.getElementById('<%=S5_CTCPlace.ClientID%>').value = localStorage.getItem("Slide_05_CTCPlace");
                         document.getElementById('<%=S5_CTCPlace2.ClientID%>').value = localStorage.getItem("Slide_05_CTCPlace2");
                         document.getElementById('<%=S5_BIR.ClientID%>').value = localStorage.getItem("Slide_05_BIR");
                         document.getElementById('<%=S5_BIR2.ClientID%>').value = localStorage.getItem("Slide_05_BIR2");

                         //s6
                         document.getElementById('<%=S6_DateEstablished.ClientID%>').value = localStorage.getItem("Slide_06_DateEstablished_Formatted");
                         document.getElementById('<%=S6_TradeName.ClientID%>').value = localStorage.getItem("Slide_06_TradeName");
                         document.getElementById('<%=S6_Branch.ClientID%>').value = localStorage.getItem("Slide_06_Branch");
                         document.getElementById('<%=S6_NoMale.ClientID%>').value = localStorage.getItem("Slide_06_NoMale");
                         document.getElementById('<%=S6_NoFemale.ClientID%>').value = localStorage.getItem("Slide_06_NoFemale");
                         document.getElementById('<%=S6_NoLGU.ClientID%>').value = localStorage.getItem("Slide_06_NoLGU");

                         //s7
                         document.getElementById('<%=S7_DistCode.ClientID%>').value = localStorage.getItem("Slide_07_DistCode");
                         document.getElementById('<%=S7_Brgy.ClientID%>').value = localStorage.getItem("Slide_07_Brgy");
                         document.getElementById('<%=S7_Street.ClientID%>').value = localStorage.getItem("Slide_07_Street");
                         document.getElementById('<%=S7_GrpBlg.ClientID%>').value = localStorage.getItem("Slide_07_GrpBlg");
                         document.getElementById('<%=S7_StickerNo.ClientID%>').value = localStorage.getItem("Slide_07_StickerNo");
                         document.getElementById('<%=S7_PlateNo.ClientID%>').value = localStorage.getItem("Slide_07_PlateNo");
                         document.getElementById('<%=S7_StallNo.ClientID%>').value = localStorage.getItem("Slide_07_StallNo");
                         document.getElementById('<%=S7_Address.ClientID%>').value = localStorage.getItem("Slide_07_Address");

                         //s8
                         document.getElementById('<%=S8_Lname.ClientID%>').value = localStorage.getItem("Slide_08_Lname");
                         document.getElementById('<%=S8_Fname.ClientID%>').value = localStorage.getItem("Slide_08_Fname");
                         document.getElementById('<%=S8_Mname.ClientID%>').value = localStorage.getItem("Slide_08_Mname");
                         document.getElementById('<%=S8_Suffix.ClientID%>').value = localStorage.getItem("Slide_08_Suffix");
                         document.getElementById('<%=S8_Gender.ClientID%>').value = localStorage.getItem("Slide_08_Gender");
                         document.getElementById('<%=S8_Citizenship.ClientID%>').value = localStorage.getItem("Slide_08_Citizenship");
                         document.getElementById('<%=S8_Address.ClientID%>').value = localStorage.getItem("Slide_08_Address");
                         document.getElementById('<%=S8_TelNo.ClientID%>').value = localStorage.getItem("Slide_08_TelNo");
                         document.getElementById('<%=S8_AlternateEmail.ClientID%>').value = localStorage.getItem("Slide_08_AlternateEmail");

                         cument.getElementById("Slide_10").style.display = "none";
                         document.getElementById("Slide_End").style.display = "block";
                         break;

                     case "Home_01":
                         location.replace("../VS2014.IMC/Main.aspx")
                         break;

                     case "Back_02":
                         document.getElementById("Slide_01").style.display = "block";
                         document.getElementById("Slide_02").style.display = "none";
                         //   document.getElementById("Next_01").style.opacity = "0.5";
                         //   document.getElementById("Next_01").style.cursor = "not-allowed";
                         document.getElementById("Next_01").disabled = false;
                         //  document.getElementById("SelectedYesNo").value = "";
                         //  document.getElementById("SelectedOwnership").value = "";
                         break;
                     case "Back_03":
                         switch (document.getElementById("SelectedYesNo").value) {
                             case "Slide_01 Yes":
                                 document.getElementById("Slide_03").style.display = "none";
                                 document.getElementById("Slide_02").style.display = "block";
                                 break;

                             case "Slide_01 No":
                                 document.getElementById("Slide_03").style.display = "none";
                                 document.getElementById("Slide_01").style.display = "block";
                                 //   document.getElementById("SelectedYesNo").value = "";
                                 //  document.getElementById("SelectedOwnership").value = "";
                                 document.getElementById("Slide_01").style.display = "block";
                                 document.getElementById("Slide_02").style.display = "none";
                                 document.getElementById("Next_01").disabled = false;
                                 //   document.getElementById("Next_01").style.opacity = "0.5";
                                 //   document.getElementById("Next_01").style.cursor = "not-allowed";
                                 break;
                         }
                         break;

                     case "Back_04":
                         document.getElementById("Slide_04").style.display = "none";
                         document.getElementById("Slide_03").style.display = "block";
                         break;

                     case "Back_05":
                         switch (document.getElementById("SelectedYesNo").value) {
                             case "Slide_01 Yes":
                                 document.getElementById("Slide_05").style.display = "none";
                                 document.getElementById("Slide_02").style.display = "block";
                                 break;

                             case "Slide_01 No":
                                 document.getElementById("Slide_05").style.display = "none";
                                 document.getElementById("Slide_01").style.display = "block";
                                 //  document.getElementById("SelectedYesNo").value = "";
                                 // document.getElementById("SelectedOwnership").value = "";
                                 document.getElementById("Slide_01").style.display = "block";
                                 document.getElementById("Slide_02").style.display = "none";
                                 document.getElementById("Next_01").disabled = false;
                                 //   document.getElementById("Next_01").style.opacity = "0.5";
                                 //   document.getElementById("Next_01").style.cursor = "not-allowed";
                                 break;
                         }
                         break;

                     case "Back_06":
                         document.getElementById("Slide_06").style.display = "none";
                         document.getElementById("Slide_05").style.display = "block";
                         break;

                     case "Back_07":
                         document.getElementById("Slide_07").style.display = "none";
                         document.getElementById("Slide_06").style.display = "block";
                         break;

                     case "Back_08":
                         document.getElementById("Slide_08").style.display = "none";
                         document.getElementById("Slide_07").style.display = "block";
                         break;

                     case "Back_09":
                         document.getElementById("Slide_09").style.display = "none";
                         document.getElementById("Slide_08").style.display = "block";
                         break;
                     case "Back_10":
                         document.getElementById("Slide_10").style.display = "none";
                         document.getElementById("Slide_09").style.display = "block";
                         break;
                     case "Back_11":
                         document.getElementById("Slide_11").style.display = "none";
                         document.getElementById("Slide_08").style.display = "block";
                         break;
                     case "Back_12":
                         document.getElementById("Slide_End").style.display = "none";
                         document.getElementById("Slide_08").style.display = "block";
                         break;

                     default:
                         // code block
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