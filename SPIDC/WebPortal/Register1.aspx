 <%@ Page EnableEventValidation="false"  Title=""
     Language="vb" AutoEventWireup="false"
     MasterPageFile="~/WebPortal/OAIMS_New.Master"
     CodeBehind="Register1.aspx.vb" Inherits="SPIDC.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    
    <script>
        var CurrentURL = window.location.href;
        CurrentURL = CurrentURL.toUpperCase();


        if (CurrentURL.includes('?')) {
            window.location.replace(CurrentURL.split('?')[0]);
        }



        function do_Download(ID) {
            switch (ID) {
                case 'QG_BP':
                    //  document.getElementById(ID).setAttribute('href', '../Guide_BP.pdf');
                    break;
                case 'QG_RPT':
                    document.getElementById(ID).setAttribute('href', '../Guide_RPT.pdf');
                    break;
                case 'DF_NB':
                    //    document.getElementById(ID).setAttribute('href', '../Application_BP.pdf');
                    break;
                case 'DF_RB':
                    //   document.getElementById(ID).setAttribute('href', '../Application_BP.pdf');
                    break;
            }
        }


        function CheckLGUReg(btnclicked) {

            switch (btnclicked) {

                case "btnTaxPayer":

                    //   document.getElementById("txtLocalUserName").required = false;
                    //   document.getElementById("txtPassKey").required = false;     

                    document.getElementById('LGUDIV').style.display = "none";
                    document.getElementById('btnTaxPayer').style.fontWeight = "bolder";
                    document.getElementById('btnTaxPayer').style.color = "cornflowerblue";
                    document.getElementById('btnTaxPayer').style.borderBottom = "solid 3px cornflowerblue";
                    document.getElementById('btnLGU').style.fontWeight = "normal";
                    document.getElementById('btnLGU').style.color = "gray";
                    document.getElementById('btnLGU').style.borderBottom = "solid 3px gray";
                    document.getElementById('chkLGUReg').value = "TaxPayer";
                    break;

                case "btnLGU":

                    //     document.getElementById("txtLocalUserName").setAttribute("required", "");
                    //     document.getElementById("txtPassKey").setAttribute("required", "");      
                    document.getElementById('LGUDIV').style.display = "flex";
                    document.getElementById('btnLGU').style.fontWeight = "bolder";
                    document.getElementById('btnLGU').style.color = "cornflowerblue";
                    document.getElementById('btnLGU').style.borderBottom = "solid 3px cornflowerblue";
                    document.getElementById('btnTaxPayer').style.fontWeight = "normal";
                    document.getElementById('btnTaxPayer').style.color = "gray";
                    document.getElementById('btnTaxPayer').style.borderBottom = "solid 3px gray";
                    document.getElementById('chkLGUReg').value = "LGU";
                    break;
            }

        };

        function chkPassword(x) {
            var pass = document.getElementById('txtPassword').value;
            var pass2 = document.getElementById('txtConfirmPassword').value
            if (pass == pass2) {
                document.getElementById('PassErr').style.display = 'none';
            }
            else {
                document.getElementById('PassErr').style.display = 'block';
            }
        }

        function SignUpSubmit() {
            document.getElementById("hdnfld_Submit").value = 'true';
            __doPostBack('SignUp', 'btbnSignUp');
        }


        function ResendSubmit() {
            document.getElementById("hdnfld_Resend").value = 'true';
            var x = document.getElementById("ResendEmail").value;
        }

        function ForgotPassword() {
            document.getElementById("hdnfld_Forgot").value = 'true';
            var x = document.getElementById("_oTextboxEmailReset").value;
            NextPage();
        }

        window.onload = function CBPAutoFill() {
            var RegMode = sessionStorage.getItem('RegMode');

            if (RegMode == 'CBP') {
                document.getElementById("txtEmailAddress").value = sessionStorage.getItem('AR_email_address');
                document.getElementById("txtFirstName").value = sessionStorage.getItem('AR_first_name');
                document.getElementById("txtLastName").value = sessionStorage.getItem('AR_last_name');
                document.getElementById("txtBirthDate").value = sessionStorage.getItem('AR_birthday');
                document.getElementById("radGender").value = sessionStorage.getItem('AR_sex');
                document.getElementById("txtMobileNo").value = sessionStorage.getItem('AR_mobile_no');
            };
        }

    </script>
   <div onload="localStorage.clear();">
       
             

      <div class="" >       
                   <div class="row " style="padding-left: 0;padding-right: 0;">
              <div class="col-lg-8 " style="padding-left: 0;padding-right: 0;" >
              
                  
                   <div class="mt-1 " >    
                                             
                          <div class="bd-example" >
                              <div id="carouselExampleCaptions" class="carousel slide ml-1 mr-1" data-ride="carousel" >
<%--                          <ol class="carousel-indicators" id="a1" style="display:none" runat="server"    >
                                      <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
                                      <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
                                     <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
                                      <li data-target="#carouselExampleCaptions" data-slide-to="3"></li>
                                  </ol>--%>
                               
                               <div class="carousel-inner" runat="server" id="divCarousel">
                               <div class="carousel-item active" >
                                        
                                          <img src="../CSS_JS_IMG/img/carousel-1.jpg" class="d-block w-100" alt="..." style="border-radius: 5px;"/>

                                      </div>
                            <div class="carousel-item"  >
                                          <img src="../CSS_JS_IMG/img/carousel-2.jpg" class="d-block w-100" alt="..." style="border-radius: 5px;"/>
   
                                      </div>
                                   <div class="carousel-item"   >
                                          <img src="../CSS_JS_IMG/img/carousel-3.jpg "class="d-block w-100" alt="..." style="border-radius: 5px;"/>
                                      </div>

                                      <div class="carousel-item"  >
                                          <img src="../CSS_JS_IMG/img/carousel-4.jpg" class="d-block w-100" alt="..." style="border-radius: 5px;"/>
                                      </div>

                                </div>
                           <a  class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
                                      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                      <span class="sr-only">Previous</span>
                                  </a>
                                  <a     class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
                                      <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                      <span class="sr-only">Next</span>
                                  </a>
                              </div>
                          </div>

                 <%--         <ul class="fa-ul">
         </ul>--%>
                      </div>

                
   
              </div>
                      
              <div  class="col-lg-4 mt-1" style="padding-left: 0;padding-right: 0;zoom:98%;">
                   <div class="col-sm-12 mx-auto" style="padding-left: 0;padding-right: 0;">
                  <div  class="card shadow-lg" style="padding-left: 0;padding-right: 0;">

                      <div class="card-body col-sm-12 " >
                          <ul class="nav nav-tabs mt-2" id="myTab" role="tablist">
  <li class="nav-item">
    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#Signup" role="tab" aria-controls="home"
      aria-selected="true" onclick="">Sign up</a>
 
  </li>
  <li class="nav-item" id="tabQG">
    <a class="nav-link" id="Guide-tab" data-toggle="tab" href="#Guide" role="tab" aria-controls="profile"
      aria-selected="false" onclick="">Guide</a>
   
  </li>
  <li class="nav-item" id="tabDF" style="display:none;">
    <a class="nav-link" id="DownloadableFile-tab" data-toggle="tab" href="#DownloadableFile" role="tab" aria-controls="profile"
      aria-selected="false" onclick="">Downloadable Forms</a>
     
  
  </li>
  <%--<li class="nav-item">
    <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact"
      aria-selected="false">Contact</a>
  </li>--%>
</ul>     
<div class="tab-content" id="myTabContent">
  <div class="tab-pane fade show active" id="Signup" role="tabpanel" aria-labelledby="home-tab">
      <div class="col-sm-12 text-center text-capitalize mb-3 mt-3" >Create New Account</div>
                          

                          <center>                   
              <button  id="btnTaxPayer" onclick="CheckLGUReg(this.id);" type="button"
                  style="
                  display:none;
                  width:49%;
                  font-weight:bolder; 
                  color:cornflowerblue;                  
                  background-color: Transparent;
                  background-repeat:no-repeat;
                  border: none;
                  cursor: pointer; 
                  border-bottom:solid 3px cornflowerblue; 
                  ">Tax Payer</button>

              <button  id="btnLGU" onclick="CheckLGUReg(this.id);"        type="button"
                  style=" 
                  display:none;
                  width:49%;
                  font-weight: normal;
                  color:gray;
                  background-color: Transparent;
                  background-repeat:no-repeat;
                  border: none;
                  cursor: pointer; 
                  border-bottom:solid 3px cornflowerblue; 
                  border-bottom:solid 3px gray;
                  ">LGU Employee</button>
                   
             <input type="hidden" name="chkLGUReg" id="chkLGUReg" value="Tax Payer" />
                   </center>
                          <form id="frmNone" name="frmNone" method="post"></form>

                          <form id="frmSignUp" name="frmSignUp" method="post" onsubmit="SignUpSubmit();NextPage();" class="form">
                             
                              
                                  <center>
                            <div class="form-group col-md-12" style="background-color:#257CFC;padding-bottom:0.5em;padding-top:0.5em;">                                  
                                  <div>
                                      <label class="input-txt input-txt-active2 ml-2">
                                          <span><span class="m-2"><b>Are you an Agent?</b></span></span>
                                      </label>                                      
                                      <select id="radAgent" name="radAgent" class="form-control CH-size-new">
                                          <option value="AGENT"  >Yes</option>
                                          <option value="OWNER" selected>No</option>
                                      </select>                                    
                                  </div>
                              </div>
                             </center>
                            
                              
                              
                               <div class="form-row">
                                  <div class="form-group col-md-6">

                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2"><b style="color:red">*</b>First Name</span></span>
                                          </label>
                                          
         <input type="text" id="TXTTRAPERROR" name="TXTTRAPERROR" style="display:none !Important" runat="server"/>
                                          
         <input type="text" id="TXTTRAPERROR2" name="TXTTRAPERROR2" style="display:none !Important" runat="server"/>

                                          <input required type="text" name="txtFirstName" class="form-control CH-size-new" id="txtFirstName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                                      </div>



                                  </div>

                                  <div class="form-group form-group-sm col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2"> <b style="color:red">*</b>Last Name</span></span>
                                          </label>
                                          <input required type="text" class="form-control CH-size-new" name="txtLastName" id="txtLastName"  pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                                      </div>
                                  </div>
                              </div>
                              <div class="form-row">
                                  <div class="form-group col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2"><b style="color:red">*</b>Birth Date</span></span>
                                          </label>
                                          <input required type="text" name="txtBirthDate" class="form-control CH-size-new" id="txtBirthDate" min="1900-01-01" max="2018-12-31"  onfocus="(this.type='date')" />
                                      </div>
                                  </div>

                                  <div class="form-group col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2"><b style="color:red">*</b>Gender</span></span>
                                          </label>
                                          <select required id="radGender" name="radGender" class="form-control CH-size-new">
                                              <option value="" disabled selected>Gender</option>
                                              <option value="M">Male</option>
                                              <option value="F">Female</option>
                                          </select>
                                      </div>

                                  </div>

                              </div>
                              <div class="form-group">
                                  <div>
                                      <label class="input-txt input-txt-active2 ml-2">
                                          <span><span class="m-2"><b style="color:red">*</b>Email Address</span></span>
                                      </label>
                                      <input required type="email" class="form-control CH-size-new" id="txtEmailAddress" name="txtEmailAddress"  oninput="this.reportValidity()" title="Email Address">
                                  </div>
                              </div>

                              <div class="form-group">
                                  <div>
                                      <label class="input-txt input-txt-active2 ml-2">
                                          <span><span class="m-2">Complete Address (For Official Receipt Delivery)</span></span>
                                      </label>
                                      <textarea class="form-control CH-size-new" id="txtCompleteAddress" name="txtCompleteAddress" title="txtCompleteAddress"></textarea>
                                  </div>
                              </div>




                              <div class="form-row">
                                  <div class="form-group col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2"><b style="color:red">*</b>Mobile Number</span></span>
                                          </label>
                                          <input required type="text" name="txtMobileNo" class="form-control CH-size-new" id="txtMobileNo"   pattern="[0-9]+" oninput="this.reportValidity()" title="Mobile No." maxlength="11"/>
                                      </div>
                                  </div>

                                   <div class="form-group col-md-6">
                                          <div class="my-auto mx-2"> <asp:CheckBox runat="server" id="_oCBResident"  name="_oCBResident" Checked="true" cssclass="CH-Size my-auto mx-2" Text="&nbsp I am a resident of " Font-Size="14px"/></div>
                                        </div>
                              </div>
                              <label id="PassErr" style="display: none; color: red; font-size: 14px">Password did not match</label>
                              <div class="form-row">                               


                                  <div class="form-group col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2"><b style="color:red">*</b>Password</span></span>
                                          </label>
                                          <input required clientidmode="Static" type="password" class="form-control CH-size-new" name="txtPassword" id="txtPassword"  oninput="chkPassword(this.id)" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters" required>
                                      </div>
                                  </div>

                                  <div class="form-group col-md-6">
                                      <div> 
                                          <label class="input-txt input-txt-active2">
                                              <span>&nbsp<span class="m-2"><b style="color:red">*</b>Confirm Password</span></span>
                                          </label>
                                          <input required clientidmode="Static" type="password" class="form-control CH-size-new" name="txtConfirmPassword" id="txtConfirmPassword"  oninput="chkPassword(this.id)" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters" required>
                                      </div>
                                  </div>
                              </div>
                                


                              <label style="font-size: smaller" class="p-2">This question will help us verify your identity should you forget your password.</label>
                              <div class="form-group">
                                  
                                  <div>
                                      <label class="input-txt input-txt-active2 ml-2">
                                          <span><span class="m-2"><b style="color:red">*</b>Security Question</span></span>
                                      </label>                                      
                                      <select required id="radQuestion" name="radQuestion" class="form-control CH-size-new">
                                          <option value="" disabled selected>Security Question</option>
                                          <option value="1">What's your pet's name?</option>
                                          <option value="2">What primary school did you attend?</option>
                                          <option value="3">In what town or city was your first full time job?</option>
                                          <option value="4">In what town or city did you meet your spouse/partner?</option>
                                          <option value="5">What are the last five digits of your driver's licence number?</option>
                                          <option value="6">What was the house number and street name you lived in as a child?</option>
                                          <option value="7">What were the last four digits of your childhood telephone number?</option>
                                      </select>
                                    
                                  </div>
                              </div>

                              <div class="form-group">
                                  <div>
                                      <label class="input-txt input-txt-active2 ml-2">
                                          <span><span class="m-2"><b style="color:red">*</b>Security Answer</span></span>
                                      </label>
                                      <input required type="text" class="form-control CH-size-new" id="txtSecurityA" name="txtSecurityA"  oninput="this.reportValidity()" title="Security Answer">
                                  </div>
                              </div>

                              <div class="form-row" id="LGUDIV" style="display: none">

                                  <div class="form-group col-md-12">
                                      <select id="cmbUserType" name="cmbUserType" class="form-control">
                                          <option value="" disabled selected>Select User Type</option>
                                          <option value="BPLO">BPLO</option>
                                          <option value="Treasury">Treasury</option>
                                          <option value="Assessor">Assessor</option>
                                      </select>
                                  </div>

                                  <div class="form-group col-md-6">
                                      <input type="text" clientidmode="Static" runat="server" class="form-control" name="txtLocalUserName" id="txtLocalUserName"  />
                                  </div>

                                  <div class="form-group col-md-6">
                                      <input type="password" clientidmode="Static" runat="server" class="form-control" name="txtPassKey" id="txtPassKey"  />
                                  </div>

                              </div>

                              <center>                    

                             

                            <div  class="g-recaptcha col-lg-12 d-flex justify-content-center align-content-center"  id="_oCaptcha" data-sitekey="6LdY5E4UAAAAAIPlTO7r45ku7E9JqBPTJSGXtSRj" ></div>   
                     
                                    <a href="#" data-toggle="modal" data-target="#ResendValidation" data-ticket-type="standard-access"><i>Didn't receive email verification link?</i></a>    

                       
                          <div class="col">
 
                    <label style="font-size:14px">By clicking Sign Up, you agree and that you have read our </label>
                       <a style="font-size:14px" href="#" data-toggle="modal" data-target="#TermsAndConditions" data-ticket-type="standard-access">Privacy Policy</a>
                      </div>
                       <p id="p1" ></p>      
                       <input type="hidden" id="hdnfld_Submit" name="hdnfld_Submit" value="false"/>  
          <div class="col">
                        <button form="frmSignUp" name="btnSignUp" id="btnSignUp" type="submit" class="btn btn-primary " style="font-size:20px;width:100%" >Sign Up</button>
                     
                
              </div>           
                        </center>
                          </form>

  </div>

  <input style="display:none" type="button" id="testclick" runat="server" />
   


  <div class="tab-pane fade" id="Guide" role="tabpanel" aria-labelledby="profile-tab">
      
      <ul><br />
     <div id="caloocan_QG">     
          <li>  <a id="QG_BP" onclick="do_Download(this.id)" href="#">Guide for Business Permit</a></li>
          <li>   <a id="QG_RPT" onclick="do_Download(this.id)" href="#">Guide for Real Property</a></li>
     </div>
             <div id="csjdm_QG" style="display:none">     
           
          <li><a href="../ONLINE-RENEWAL-STEP-BY-STEP-PROCEDURE.pdf">ONLINE RENEWAL STEP-BY-STEP PROCEDURE</a></li>
          <li><a href="../CITIZENS-GUIDE-TO-BUSINESS-REGISTRATION-converted.pdf">CITIZENS GUIDE TO BUSINESS REGISTRATION</a></li>

             </div>   

           </ul>   
   
  </div>
    <div class="tab-pane fade" id="DownloadableFile" role="tabpanel" aria-labelledby="profile-tab">
        <ul> 
            <br />
            <div id="caloocan_DF">
                <li><a id="DF_NB" onclick="do_Download(this.id)" href="#">New Business Application</a></li>
                <li><a id="DF_RB" onclick="do_Download(this.id)" href="#">Business Permit Renewal Application</a></li>
            </div>

        <div id="csjdm_DF" style="display:none">     
            <h3>Application Form</h3>     
          <li><b>Single Proprietorship : </b><a href="../BPLO-F-001-Application_Single-Proprietorship-FIRST-PAGE.pdf">Page 1</a>,<a href="../BPLO-F-001-Application_Single-Proprietorship-LAST-PAGE.pdf">Page 2</a></li>
          <li><b>Corporation : </b><a href="../BPLO-F-002-Application_Corporation-FIRST-PAGE.pdf">Page 1</a>, <a href="../BPLO-F-002-Application_Corporation-LAST-PAGE.pdf">Page 2</a></li>
        </div>        
                </ul>
  </div>
  <%--<div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab"></div>--%>
</div>
                          
                      </div>
                  </div>
                       </div> 
              </div>

                           
          </div>
      
   
            </div>

       <input type="hidden" id="err" runat="server" />
                  
     
      <!-- Modal forgot Form -->
      <div id="Forgot" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Forgot Password</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                <form name="frmForgotPass" method="post" onsubmit="ForgotPassword()">
                <div class="form-group">
                     Enter your email and we'll send you instructions on how to reset your password.
                  <input id="_oTextboxEmailReset" type="email" required class="form-control" name="_oTextboxEmailReset" >
                 <input type="hidden" id="hdnfld_Forgot" name="hdnfld_Forgot" value="false"/>  
               
                </div>              
  
               <div class="text-center">
                  <asp:button runat="server" from="frmForgotPass" ID="btnForgot" type="submit"  cssclass="btn btn-primary small" Text="Reset Password"></asp:button>
              
                </div>
           </form>

              
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->

         <!-- Modal Resend Validation Form -->
      <div id="ResendValidation" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Resend Verification</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                <form name="frmResend" method="post" defaultbutton="btnResend" onsubmit="ResendSubmit()">
                <div class="form-group">

                     We will resend you a verification link to verify your email. 
                     Your verification code may take a few moments to arrive.
                     Do not share the verification link with anyone.

                  <input id="ResendEmail" type="email" required class="form-control" name="ResendEmail"  ClientIDMode="Static" >
                  <input type="hidden" id="hdnfld_Resend" name="hdnfld_Resend" value="false"/>  
                </div>              
  
               <div class="text-center">
                  <asp:button runat="server" from="frmResend" ID="btnResend" type="submit" class="btn btn-primary small" Text="Resend Verification Link"></asp:button>
              
                   
                     </div>
           </form>
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->

         <!-- Modal TNC Form -->
        <div id="TermsAndConditions" class="modal fade">

            <div class="modal-dialog" style="min-width: 50vh; max-width: 80vh" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" runat="server" id="TNC_Title">Terms and Conditions</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="form-group" style="text-align: justify" runat="server" id="TNC_Content">
                            <ol type="1">
                                <li>The information provided is certified as TRUE and CORRECT.</li>
                                <br />
                                <li>Applicants should not create multiple false account</li>
                                <br />
                                <li>Registrant should keep their account confidential and will NOT SHARE to anyone.</li>
                                <br />
                                <li>Applicants should validate their account by clicking the Confirmation link sent to the supplied email address.</li>
                                <br />
                                <li>I hereby agree that all Personal Data (as defined under the Data Privacy Law of 2012 and its implementing rules and regulations), customer data and account or transaction information or records (collectively, the "information") which may be with City Government from time to time relating to us may be processed, profiled or shared to requesting parties or for the purpose of any court, legal process, examination, inquiry, audit or investigation of any Authority. The aforesaid terms shall apply notwithstanding any applicable non-disclosure agreement. We acknowledge that such information may be processed or profiled by or shared with jurisdictions which do not have strict data protection or data privacy laws.</li>
                                <li>The Business Permits and Licensing System reserves the rights to cancel an appointment that uses one (1) email addresses for multiple appointment slots. The appointment schedule is free of charge. No walk-in applications will be attended to.</li>
                                <br />
                            </ol>
                        </div>

                        <div class="text-center">
                            <input id="btnagree" type="button" class="btn btn-primary" data-dismiss="modal" aria-label="Close" value="I Agree" />
                        </div>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
       </div>

        <div class="m-1">
     
       

   </div>


    
     <div style="color:white; background-image: linear-gradient(0deg, #DCDCDC, gray); position: fixed;bottom:0;left:0;border-radius:0px 10px 0px 0px;padding:0px 5px">
         <table style="font-family:Verdana">
             <tr><td><label>Online:</label></td><td><label runat="server" id="OnlineNow"></label></td></tr>
          
         </table>
                   </div>


         <script>

             var CurrentURL = window.location.href;
             CurrentURL = CurrentURL.toUpperCase();

             if (CurrentURL.includes("CSJDM") == true) {
                 document.getElementById('caloocan_DF').style.display = 'none';
                 document.getElementById('caloocan_QG').style.display = 'none';
                 document.getElementById('csjdm_DF').style.display = 'block';
                 document.getElementById('csjdm_QG').style.display = 'block';
             }


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
             document.getElementById("txtBirthDate").setAttribute("max", today);

                </script>


       <asp:button usesubmitbehavior="true" Visible="false" id="testSnackBar" runat="server" text="SHOW SnackBar"/>
</asp:Content>
