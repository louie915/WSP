<%@ Page Title="" EnableEventValidation="false" 
    Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" 
    CodeBehind="BusApplicationSummary.aspx.vb" Inherits="SPIDC.BusApplicationSummary" %>
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

           <!-- SLIDE End - Application Summary -->
          <div id="Slide_End" style="border:1px solid gray; background-color:white; padding:10px;display:block;">
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
               <div class="form-row" id="Slide_End_frmCDA" runat="server">
                       
                  
                   <div class="form-group col-md-6"  style="text-align:left">        CDA No.: *<br />                     
                <input   type="text"  runat="server" readonly="true" class="form-control" name="CDA_No"  id="S5_CDA" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: CDA <br />        
                <input  type="text" runat="server" readonly="true" name="CDA_RegDate" class="form-control" id="S5_CDA2" />
                 </div>               
            </div>
               <!-- DTI -->
               <div class="form-row" id="Slide_End_frmDTI"  runat="server">
                   <div class="form-group col-md-6"  style="text-align:left">        DTI No.: *<br />                     
                <input   type="text" runat="server" readonly="true" class="form-control" name="DTI_No"  id="S5_DTI" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: DTI <br />        
                <input  type="text" runat="server" readonly="true" name="DTI_RegDate" class="form-control" id="S5_DTI2" />
                 </div>               
            </div>
               <!-- SEC  -->
               <div class="form-row" id="Slide_End_frmSEC"  runat="server">
                   <div class="form-group col-md-6"  style="text-align:left">        SEC  No.: *<br />                     
                <input   type="text" runat="server" readonly="true" class="form-control" name="SEC_No"  id="S5_SEC"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: SEC<br />        
                <input  type="text" runat="server" readonly="true" name="SEC_RegDate" class="form-control" id="S5_SEC2" />
                 </div>               
            </div>
               <!-- TIN  -->
               <div class="form-row" id="Slide_End_frmTIN">
                   <div class="form-group col-md-6"  style="text-align:left">        TIN  No.: *<br />                     
                <input   type="text" runat="server" readonly="true" class="form-control" name="TIN_No"  id="S5_TIN" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: TIN<br />        
                <input  type="text" runat="server" readonly="true" name="TIN_RegDate" class="form-control" id="S5_TIN2" />
                 </div>               
            </div>
               <!-- SSS  -->
               <div class="form-row" id="Slide_End_frmSSS">
                   <div class="form-group col-md-6"  style="text-align:left">        SSS  No.: *<br />                     
                <input   type="text" runat="server" readonly="true" class="form-control" name="SSS_No"  id="S5_SSS" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: SSS<br />        
                <input  type="text" runat="server" readonly="true" name="SSS_RegDate" class="form-control" id="S5_SSS2" />
                 </div>               
            </div>
               <!-- Brgy Clearance  -->
               <div class="form-row" id="Slide_End_frmBrgy">
                   <div class="form-group col-md-6"  style="text-align:left">        Brgy Clearance No.: *<br />                     
                <input   type="text" runat="server" readonly="true" class="form-control" name="Brgy_No"  id="S5_Brgy" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: Brgy<br />        
                <input  type="text" runat="server" readonly="true" name="Brgy_RegDate" class="form-control" id="S5_Brgy2" />
                 </div>               
            </div>

               <!-- CTC  -->
               <div class="form-row" id="Slide_End_frmCTC" style="text-align:left;display:none">
                   <div class="form-group col-md-6"  style="text-align:left">        CTC  No.: *<br />                     
                <input   type="text" runat="server" readonly="true" class="form-control" name="CTC_No"  id="S5_CTC" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: CTC<br />        
                <input  type="text" runat="server" readonly="true" name="CTC_RegDate" class="form-control" id="S5_CTC2" />
                 </div>               
            </div>

               <!-- CTC Place  -->
               <div class="form-row" id="Slide_End_frmCTCPlace" style="text-align:left;display:none">
                   <div class="form-group col-md-6"  style="text-align:left">        CTC Place: *<br />                     
                <input   type="text" runat="server" readonly="true" class="form-control" name="CTC_Place"  id="S5_CTCPlace" />
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          CTC Amount:<br />        
                <input  type="text" runat="server" readonly="true" name="CTC_Amount" class="form-control" id="S5_CTCPlace2" style="text-align:right" pattern="[0-9]+" oninput="this.reportValidity()" title="Amount"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                        </div>               
            </div>

                <!-- BIR  -->
               <div class="form-row" id="Slide_End_frmBIR">
                   <div class="form-group col-md-6"  style="text-align:left">       BIR Registration No.: *<br />                     
                <input   type="text" runat="server" readonly="true" class="form-control" name="S5_BIR"  id="S5_BIR"/>
              </div>

                  <div class="form-group col-md-6" style="text-align:left">          Registration Date: BIR<br />        
                <input  type="text" runat="server" readonly="true" name="S5_BIR2" class="form-control" id="S5_BIR2"/>
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
	<button type="button" class="btn btn-primary" id="Back_12" onclick="FnRedirect('Redirect','Back')">Back</button> &nbsp
    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#Confirm" data-ticket-type="standard-access">Confirm</button>
 
   
                  </span>	 		 
                            
          </div>
          </div> 

               </div>
                   </div>
                 </center>
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