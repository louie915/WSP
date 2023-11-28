<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WSPCedula.aspx.vb" Inherits="SPIDC.WSPCedula" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="CSS_JS_IMG/OS-JS-CSS/fontawesome-free/css/all.min.css" rel="stylesheet" />       
  
        <link href="CSS_JS_IMG/OS-JS-CSS/Css/Online-Services.css" rel="stylesheet" />     
        <script src="CSS_JS_IMG/OS-JS-CSS/Js/OS-Mobile-View.js"></script>   
       <link href="CSS_JS_IMG/css/Sticker.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
   
    <style>
#customers {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#customers td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
   text-align: left;
}



#customers th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: CENTER;
  background-color: #f2f2f2;
  color: BLACK;
}
</style>


</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">    </asp:ScriptManager>
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

             
     <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="snackbar" style="position: absolute">
                    <asp:Label runat="server" ID="_oLabelSnackbar" />
                </div>
                <div id="snackbargreen" style="position: absolute">
                    <asp:Label runat="server" ID="_oLabelSnackbargreen" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

               <!-- Modal Complete -->
      <div id="ModalComplete" class="modal fade" style="z-index:1100 !important" >
        <div class="modal-dialog modal-md">
          <div class="modal-content">
            <div class="modal-header  bg-primary">
              <h4 class="modal-title text-white">CEDULA COMPLETE</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
                   <div class="w3-panel w3-pale-green w3-border">
  <h3>Success!</h3>
  <p>You may now Proceed to the counter and Present the Details Below :</p>
                       </div>
   <table id="customers">
       <tr style="color:blue">
           <td>Control Number</td>        
           <td id="tdControlNo" runat="server">  </td>
       </tr>

       <tr>
           <td>Cedula Type</td>         
           <td id="tdCedulaType" runat="server">  </td>
       </tr>

       <tr>
           <td>Name</td>       
           <td id="tdName" runat="server">  </td>
       </tr>

          <tr>
           <td>New Business</td>        
           <td id="tdNewBusiness" runat="server">  </td>
       </tr>

       <tr style="color:blue">
           <td>Amount to Pay</td>      
           <td id="tdAmounttoPay" runat="server" style="text-align:right">  </td>
       </tr>
   </table>
                   <br />
      <center>   
           <input type="button" class="btn btn-primary btn-sm col col-md-5"  value="Done" runat="server" id="btnDone"/>
      </center>    
          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


  <div id="div_Connectivity" runat="server" class="w3-panel w3-pale-yellow w3-border" style="display:none">
  <h3>Network Maintenance</h3>
  <p>We are having Network Maintenance right now. You may experience brief system outage. We apologize for any inconvinience this may cause.</p>
                       </div>


        <br />
   <div class="container" id="div_container" runat="server">
   <center>
    <div class="col-md-10">
 
          <div  style="border:1px solid gray; background-color:white; padding:10px;display:block;">
                <div  style="text-align:center;font-family:Arial;" >
                <h3>Web Service Portal - CEDULA</h3>
                <hr />
                     

 <div class="w3-row">
                     <div class="form-group col-lg-5 " style="display:inline-block">
                       <a href="javascript:void(0)" style="text-decoration: none;"  onclick="openDiv(event, 'div_Individual');">
                        <div class="tablink w3-bottombar w3-hover-light-grey w3-padding w3-border-blue">Cedula-Individual</div>
                       </a>
                    </div>

      <div class="form-group col-lg-6 " style="display:none">
                    <a href="javascript:void(0)" style="text-decoration: none;" onclick="openDiv(event, 'div_Corporation');">
      <div class="tablink w3-bottombar w3-hover-light-grey w3-padding">Cedula-Corporation</div>
    </a>
                    </div>
  </div>              
                     <div class="btn-primary" style="text-align:left"><strong> &nbsp <span id="spanType">CEDULA • INDIVIDUAL</span></strong></div>
                    <div id="div_Individual" class="ctc" style="display:block;width:100%;">
                               <br />        

                        <div class="form-group col-lg-12" style="display:inline-block">
                      
                        <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">First Name <b style="color:red">*</b></span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" onkeypress="return onlyLetters();" onchange="do_Upper(this)" name="txtFname" id="txtFname" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                        </div>
                    </div>

                         <div class="form-group col-lg-3" style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Middle Name </span></span>
                            </label>
                            <input type="text" runat="server" class="form-control ch-size-new" onkeypress="return onlyLetters();" name="txtMname" onchange="do_Upper(this)" id="txtMname" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                        </div>
                    </div>

                         <div class="form-group col-lg-4 " style="display:inline-block;">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Last Name <b style="color:red">*</b></span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" onkeypress="return onlyLetters();" onchange="do_Upper(this)" name="txtLname" id="txtLname" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                        </div>
                    </div>

                          <div class="form-group col-lg-11 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Address <b style="color:red">*</b></span></span>
                            </label>
                             <textarea runat="server" class="form-control ch-size-new" name="txtAddress" id="txtAddress" onchange="do_Upper(this)"/>
                        </div>
                    </div>
                        <div class="form-group col-lg-11 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Birth Place <b style="color:red">*</b></span></span>
                            </label>
                            <textarea type="text"  required runat="server" class="form-control ch-size-new" name="txtBirthPlace" id="txtBirthPlace" onchange="do_Upper(this)"/>
                        </div>
                    </div>

                            <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Citizenship <b style="color:red">*</b></span></span>
                            </label>
                            <select class="form-control ch-size-new" id="txtCitizenship" runat="server">
                                <option selected value="Filipino">Filipino</option>
                            </select>
                             </div>
                    </div>
                        <div class="form-group col-lg-3 " style="display:inline-block">
                              <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Gender <b style="color:red">*</b></span></span>
                            </label>
              
                       <select class="form-control ch-size-new" runat="server" id="txtGender">
                           <option value="M">Male</option>
                           <option value="F">Female</option>
                       </select>
                             </div>                      
                    </div>

                            <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Birthday (must be 18+) <b style="color:red">*</b></span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" min='1899-01-01' max='2000-13-13' onblur="this.reportValidity()" name="txtBirthDay" id="txtBirthDay"/>
                        </div>
                    </div>
                        <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Civil Status <b style="color:red">*</b></span></span>
                            </label>
                           <select runat="server" class="form-control ch-size-new" name="txtCivilStatus" id="txtCivilStatus">
                               <option selected value="Single">Single</option>
                               <option>Married</option>
                               <option>Wodiwed</option>
                               <option>Divorced</option>
                               <option>Separated</option>
                           </select>
                        </div>
                    </div>
                          <div class="form-group col-lg-3 " style="display:inline-block">
                    
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Employment Status <b style="color:red">*</b></span></span>
                            </label>
                             <select class="form-control ch-size-new" onchange="do_EmploymentStatus()" runat="server" id="txtEmploymentStatus">
                                   <option selected  value="Employed" >Employed</option>
                                   <option value="Unemployed">Unemployed</option>                               
                             </select>
                      </div>

                            <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Profession <b style="color:red">*</b> </span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" name="txtProfession" id="txtProfession"/>
                        </div>
                    </div>
                        <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">TIN </span></span>
                            </label>
                           <input type="text"  runat="server" class="form-control ch-size-new" name="txtTIN" id="txtTIN" onkeypress="return onlyNumbers(this);" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                               </div>
                    </div>
                               <div class="form-group col-lg-3 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Height (m)</span></span>
                            </label>
                            <input type="text" runat="server" placeholder="0.00" class="form-control ch-size-new" name="txtHeight" id="txtHeight" style="text-align:right"/>
                        </div>
                    </div>
                        <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Weight (kg) </span></span>
                            </label>
                           <input type="text" runat="server" placeholder="0.00" class="form-control ch-size-new" name="txtWeight" id="txtWeight" style="text-align:right"/>
                        </div>
                    </div>
                          </div>
                        
                         <div class="btn-primary" style="text-align:left"><strong> &nbsp Gross Declaration</strong></div>

                        
                        
                   
                                <table id="customers">                               
                                  <tr>
                                      <td >A. BASIC COMMUNITY TAX (₱ <span id="Basic_Individual" runat="server"></span>)</td>
                                   
                                      <td style="text-align:right;" id="td_Basic_Individual" runat="server"></td>
                                  </tr>
                                  <tr>
                                      <td colspan="2">B. ADDITIONAL COMMUNITY TAX </td>
                                                                   
                                  </tr>
                                  <tr>  
                                      <td>1. GROSS RECEIPTS OR EARNINGS DERIVED FROM BUSINESS DURING THE PRECEDING YEAR
                                         &nbsp [
                                         <input  id="chkNewBP" type="checkbox" onchange="do_NewBP(this.checked);" />    
                                         <label for="chkNewBP"> Check if New Business</label>]
                                      </td>
                                      <td> <input type="text" runat="server" placeholder="0.00" style="text-align:right" onkeypress="return isNumberKey(event)"  value="0.00"  onchange="do_computeCTD('Individual',this.name,'ctd_1',this.value); do_comma(this)" class="form-control " name="txtGrossRB" id="txtGrossRB"/>
                      </td>
                                        <td id="ctd_1" style="text-align:right;display:none" runat="server">0.00</td>
                                  </tr>
                              <tr>  
                                      <td>2. SALARIES OR GROSS RECEIPT OR EARNINGS DERIVED FROM EXERCISE OF PROFESSION OR PURSUIT OF ANY OCCUPATION</td>
                                      <td>        <input type="text" placeholder="0.00" style="text-align:right" value="0.00" onkeypress="return isNumberKey(event)" runat="server"  onchange="do_computeCTD('Individual',this.name,'ctd_2',this.value); do_comma(this)"  class="form-control ch-size-new" name="txtGrossSalary" id="txtGrossSalary"/>
                 </td>
                                         <td id="ctd_2" style="text-align:right;display:none" runat="server">0.00</td>
                                  </tr>

                             <tr>  
                                      <td>3. INCOME FROM REAL PROPERTY</td>
                                      <td>    <input type="text" placeholder="0.00" style="text-align:right" value="0.00" onkeypress="return isNumberKey(event)" runat="server"   onchange="do_computeCTD('Individual',this.name,'ctd_3',this.value); do_comma(this)" class="form-control ch-size-new" name="txtGrossRP" id="txtGrossRP"/>
                    </td>
                                       <td id="ctd_3" style="text-align:right;display:none" runat="server">0.00</td>
                                  </tr>

                                <tr style="text-align:right">                                        
                                    <td style="text-align:right">TOTAL TAX DUE</td>
                                      <td id="ctd_4" style="text-align:right" runat="server">0.00</td>
                                  </tr>
                              <tr style="text-align:right"> 
                                       <td style="text-align:right" >INTEREST</td>
                                      <td id="ctd_5" style="text-align:right" runat="server">0.00</td>
                                  </tr>
                              <tr style="text-align:right; font-size:x-large;color:blue">                                       
                                      <td style="text-align:right" >TOTAL AMOUNT TO PAY </td>
                                     <td id="ctd_6" style="text-align:right" runat="server">0.00</td>
                                  </tr>
                              </table>

                            <div class="w3-panel w3-pale-blue w3-border">
  <h3>Attention!</h3>
  <p>This is just an ESTIMATED amount. <b>[TOTAL AMOUNT TO PAY] </b> may change upon payment.</p>
                       </div>
                        
                         
                           
                    </div>

                    <div id="div_Corporation" class="w3-container ctc" style="display:none">
                         <br />        

                        <div class="form-group col-lg-12" style="display:inline-block">
                      
                        <div class="form-group col-lg-8 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Company Name <b style="color:red">*</b></span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" onkeypress="return onlyLetters();" name="txtFname" id="Text1" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                        </div>
                    </div>

                         <div class="form-group col-lg-3" style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">TIN <b style="color:red">*</b> </span></span>
                            </label>
                            <input type="text"  runat="server" class="form-control ch-size-new" name="txtTIN2" id="txtTIN2" onkeypress="return onlyNumbers(this);" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                          </div>
                    </div>                                                  

                          <div class="form-group col-lg-11 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Address of Principal Business <b style="color:red">*</b></span></span>
                            </label>
                             <textarea runat="server" class="form-control ch-size-new" name="txtAddress" id="Textarea1"/>
                        </div>
                    </div>
                      
                            <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Kind of Organization <b style="color:red">*</b></span></span>
                            </label>
                            <select class="form-control ch-size-new">
                                <option selected value="Association">Association</option>
                                <option selected value="Corporation">Corporation</option>
                                <option selected value="Partnership">Partnership</option>
                            </select>
                             </div>
                    </div>
                        <div class="form-group col-lg-7 " style="display:inline-block">
                              <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Place of Incorporation <b style="color:red">*</b></span></span>
                            </label>
                 <input type="text" runat="server" class="form-control ch-size-new" name="txtAddressofPrincipalBusiness" id="txtAddressofPrincipalBusiness"/>
                    
                     
                             </div>                      
                    </div>

                            <div class="form-group col-lg-4 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Date of Incorporation<b style="color:red">*</b></span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" name="txtDateofIncorporation" id="txtDateofIncorporation"/>
                        </div>
                    </div>
                       <div class="form-group col-lg-7 " style="display:inline-block">
                              <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Kind of Business <b style="color:red">*</b></span></span>
                            </label>
                 <input type="text" runat="server" class="form-control ch-size-new" name="txtAddressofPrincipalBusiness" id="Text3"/>
                    </div>                      
                    </div>                                              
                    
                          </div>
                        
                         <div class="btn-primary" style="text-align:left"><strong> &nbsp Gross Declaration</strong></div>
                               <br />
                          <div class="form-group col-lg-6" style="display:inline-block;">
                                  
                              <div class="form-group col-lg-12 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Gross Receipts from Business </span></span>
                            </label>
                           <input type="text" placeholder="0.00" style="text-align:right"  runat="server" class="form-control ch-size-new" name="txtGrossRB_Corp" id="txtGrossRB_Corp"/>
                        </div>
                    </div>
                              
                               <div class="form-group col-lg-12 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Assessed Value of Real Property Owned </span></span>
                            </label>
                           <input type="text" placeholder="0.00" style="text-align:right"  runat="server" class="form-control ch-size-new" name="txtGrossRP_Corp" id="txtGrossRP_Corp"/>
                        </div>
                    </div>
                               
                               <div class="form-group col-lg-12 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Interest</span></span>
                            </label>
                           <input type="text" placeholder="0.00" style="text-align:right"  runat="server" class="form-control ch-size-new" name="txtInterest_Corp" id="txtInterest_Corp"/>
                        </div>
                    </div>
                               <div class="form-group col-lg-12 " style="display:inline-block">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Amount to Pay </span></span>
                            </label>
                           <label style="text-align:right;font-size:30px"  runat="server" class="form-control ch-size-new" name="txtAmountToPay_Corp" id="txtAmountToPay_Corp">0.00</label>
                        </div>
                    </div>
                                
                              </div>                        
                    </div>
                 <br />
                       <input type="button"  class="btn btn-primary col-lg-2 col-lg-4 m-2 btn-lg"  value="Submit" runat="server" id="btnSubmit" />
                                    </div>
                                      </div>
         
        </div>
    </center>               
     <br />  <br />  <br />
    </div>


              <input type="hidden" runat="server" id="hdn_Gross_Multiplier_Individual"/>                   
              <input type="hidden" runat="server" id="hdn_Basic_Individual"/>    
              <input type="hidden" runat="server" id="hdn_NewBP" value="False"/>     
              <input type="hidden" runat="server" id="hdn_Type" value="Individual"/>  
        
              <input type="hidden" runat="server" id="hdn_B1_Individual" value="0.00" />                   
              <input type="hidden" runat="server" id="hdn_B2_Individual" value="0.00"/>  
              <input type="hidden" runat="server" id="hdn_B3_Individual" value="0.00"/>  
              <input type="hidden" runat="server" id="hdn_B4_Individual" value="0.00"/>
              <input type="hidden" runat="server" id="hdn_B5_Individual" value="0.00"/>
              <input type="hidden" runat="server" id="hdn_B6_Individual" value="0.00"/>

              <input type="hidden" runat="server" id="hdn_NewBP_MinAmount" value="0.00"/>

              <input type="hidden" runat="server" id="hdn_Interest_Multiplier_Individual" value="0.00"/>  
    


                <script src="CSS_JS_IMG/OS-JS-CSS/jquery/jquery.min.js"></script>
        <script src="CSS_JS_IMG/OS-JS-CSS/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="CSS_JS_IMG/OS-JS-CSS/jquery-easing/jquery.easing.min.js"></script>
        <%--<script src="../CSS_JS_IMG/js/newjs/sb-admin-2.min.js"></script>--%>
        <script src="CSS_JS_IMG/OS-JS-CSS/Js/Online-Services.js"></script>
        <script src="CSS_JS_IMG/OS-JS-CSS/Js/OS-MainPage.js"></script>


        <script>         
            document.getElementById('<%= txtBirthDay.ClientID%>').setAttribute("type", "date"); 
            document.getElementById('<%= txtDateofIncorporation.ClientID%>').setAttribute("type", "date"); 
            document.getElementById('<%= txtHeight.ClientID%>').setAttribute("type", "number"); 
            document.getElementById('<%= txtWeight.ClientID%>').setAttribute("type", "number"); 
           // document.getElementById('<%= txtGrossRB.ClientID%>').setAttribute("type", "number"); 
           // document.getElementById('<%= txtGrossRP.ClientID%>').setAttribute("type", "number"); 
           // document.getElementById('<%= txtGrossRB_Corp.ClientID%>').setAttribute("type", "number");
           // document.getElementById('<%= txtGrossRP_Corp.ClientID%>').setAttribute("type", "number"); 
           // document.getElementById('<%= txtGrossSalary.ClientID%>').setAttribute("type", "number"); 
            var today = new Date();
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear() - 18;
            var yyyy2 = today.getFullYear();
            if (dd < 10) {
                dd = '0' + dd;
            }

            if (mm < 10) {
                mm = '0' + mm;
            }

            today = yyyy + '-' + mm + '-' + dd;
           var today2 = yyyy2 + '-' + mm + '-' + dd;
            document.getElementById('<%= txtBirthDay.ClientID%>').setAttribute("max", today);
            document.getElementById('<%= txtDateofIncorporation.ClientID%>').setAttribute("max", today2);

            //-------- Default Values OnLoad
            var employment = 0;         
            quickCompute();
            //--------

            function do_comma(ele) {
                var del_comma = ele.value.replaceAll(',', '');
                del_comma=parseFloat(del_comma).toFixed(2);
                ele.value = del_comma.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }

            function do_Upper(ele) {
                var str = ele.value.toUpperCase();              
                ele.value = str;
            }

            function quickCompute() {
                      
                var basic = document.getElementById('<%= hdn_Basic_Individual.ClientID%>').value;
                var interest = document.getElementById('<%= hdn_Interest_Multiplier_Individual.ClientID%>').value;
            
                var val_ctd1 = parseFloat(document.getElementById('ctd_1').innerText);
                var val_ctd2 = parseFloat(document.getElementById('ctd_2').innerText);
                var val_ctd3 = parseFloat(document.getElementById('ctd_3').innerText);
                var val_ctd4 = parseFloat(employment) + parseFloat(val_ctd1) + parseFloat(val_ctd2) + parseFloat(val_ctd3);
                var interest2 = (parseFloat(interest) * parseFloat(val_ctd4));

                if (val_ctd4 > 5000) {
                    val_ctd4 = 5000; 
                    }
                var val_ctd5 = interest2.toFixed(2);
                var val_ctd6 = parseFloat(val_ctd4) + parseFloat(val_ctd5) + parseFloat(basic);

                var txtGrossRB = document.getElementById('<%= txtGrossRB.ClientID%>').value.replaceAll(',','');
                var txtGrossRP = document.getElementById('<%= txtGrossRP.ClientID%>').value.replaceAll(',', '');
                var txtGrossSalary = document.getElementById('<%= txtGrossSalary.ClientID%>').value.replaceAll(',', '');
                  
       
                document.getElementById('<%= hdn_B1_Individual.ClientID%>').value = txtGrossRB.replaceAll(',','');
                document.getElementById('<%= hdn_B2_Individual.ClientID%>').value = txtGrossSalary.replaceAll(',', '');
                document.getElementById('<%= hdn_B3_Individual.ClientID%>').value = txtGrossRP.replaceAll(',', '');
                document.getElementById('<%= hdn_B4_Individual.ClientID%>').value = val_ctd4.toFixed(2);
                document.getElementById('<%= hdn_B5_Individual.ClientID%>').value = val_ctd5;
                document.getElementById('<%= hdn_B6_Individual.ClientID%>').value = val_ctd6.toFixed(2);

                document.getElementById('ctd_4').innerText = do_money(parseFloat(val_ctd4).toFixed(2));
                document.getElementById('ctd_5').innerText = do_money(parseFloat(val_ctd5).toFixed(2));
                document.getElementById('ctd_6').innerText = '₱ ' + do_money(val_ctd6);

               

            }
            function do_money(val) {
                n = val;
                parts = (+n).toFixed(2).split(".");
                num = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (+parts[1] ? "." + parts[1] : "");
                return num;
            }

         
            function openDiv(evt, Type) {
                if (Type == "div_Individual") {
                    document.getElementById("spanType").innerText = "CEDULA • INDIVIDUAL";
                    document.getElementById('<%= hdn_Type.ClientID%>').value = 'Individual';
                }
                else if (Type == "div_Corporation") {
                    document.getElementById("spanType").innerText = "CEDULA • CORPORATION";
                    document.getElementById('<%= hdn_Type.ClientID%>').value = 'Corporation';
                }
                var i, x, tablinks;
                x = document.getElementsByClassName("ctc");
                for (i = 0; i < x.length; i++) {
                    x[i].style.display = "none";
                }
                tablinks = document.getElementsByClassName("tablink");
                for (i = 0; i < x.length; i++) {
                    tablinks[i].className = tablinks[i].className.replace(" w3-border-blue", "");
                }
                document.getElementById(Type).style.display = "block";
                evt.currentTarget.firstElementChild.className += " w3-border-blue";
            }
            function onlyNumbers(evt) {

                var e = event || evt; // for trans-browser compatibility
                var charCode = e.which || e.keyCode;

                if (charCode < 48 || charCode > 57)
                    return false;

                return true;

            }
            function addHyphen(element) {
                let ele = document.getElementById(element.id);
                ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

                let finalVal = ele.match(/.{1,3}/g).join('-');
                document.getElementById(element.id).value = finalVal;
            }

            function do_EmploymentStatus() {
                var select = document.getElementById('<%= txtEmploymentStatus.ClientID%>');
                var value = select.options[select.selectedIndex].value;         
                if (value == "Employed")
                {
                    employment = 0;
                  
                    document.getElementById('<%= txtProfession.ClientID%>').disabled = false;
                    document.getElementById('<%= txtProfession.ClientID%>').value = "";
                    document.getElementById('<%= txtProfession.ClientID%>').setAttribute("required","true");
                }
                else if (value == "Unemployed")
                {
                    employment = 0;
                 
                    document.getElementById('<%= txtProfession.ClientID%>').disabled = true;
                    document.getElementById('<%= txtProfession.ClientID%>').value = "Unemployed";
                    document.getElementById('<%= txtProfession.ClientID%>').setAttribute("required", "false");
                }
                quickCompute();
            }


            function do_NewBP(val) {
                var NewBPMinAmount = document.getElementById('<%= hdn_NewBP_MinAmount.ClientID%>').value;
                if (val == true) {                   
                    document.getElementById('<%= hdn_NewBP.ClientID%>').value = "True";   
                    if (document.getElementById('txtGrossRB').value.replaceAll(',','') < 5000){
                        document.getElementById('txtGrossRB').value = '5,000.00';   
                    }                                     
                }
                else if (val == false) {
                    document.getElementById('<%= hdn_NewBP.ClientID%>').value = "False";                 
                    document.getElementById('txtGrossRB').value = 0;                
                }
                do_computeCTD('Individual', 'txtGrossRB', 'ctd_1', document.getElementById('txtGrossRB').value);
            }

            function do_computeCTD(Type, elementName, ctd, val) {

                switch (Type) {
                    case 'Individual':
                        var multiplier = document.getElementById('<%= hdn_Gross_Multiplier_Individual.ClientID%>').value;
                        var basic = document.getElementById('<%= hdn_Basic_Individual.ClientID%>').value;
                        var amount = parseFloat((val.replaceAll(',', ''))) * multiplier;
                        amount = parseInt(amount) / 1000;
                        if (val < 1000) {
                            ctd1 = 0
                        }
                       
                        document.getElementById(ctd).innerText = amount.toFixed(2);

                        quickCompute();

                        break;
                    case 'Corporation':
                        // code block
                        break;
                    default:
                        // code block
                }

             

           
            }

            function openModalComplete() {
                $('#ModalComplete').modal('show');
            }
</script>

    </form>
</body>
</html>
