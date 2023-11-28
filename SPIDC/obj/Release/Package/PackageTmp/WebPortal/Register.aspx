<%@ Page EnableEventValidation="false" Title=""
    Language="vb" AutoEventWireup="false"
    MasterPageFile="~/WebPortal/OAIMS_New.Master"
    CodeBehind="Register.aspx.vb" Inherits="SPIDC.Register" %>

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
            var CurrentURL = window.location.href;
            CurrentURL = CurrentURL.toUpperCase();
            if (CurrentURL.includes("CALOOCAN") == true) {
                switch (ID) {
                    case 'QG_BP':
                        document.getElementById(ID).setAttribute('href', '../Guide_BP.pdf');
                        break;
                    case 'QG_RPT':
                        document.getElementById(ID).setAttribute('href', '../Guide_RPT.pdf');
                        break;
                    case 'DF_NB':
                        document.getElementById(ID).setAttribute('href', '../Application_BP_New.pdf');
                        break;
                    case 'DF_RB':
                        document.getElementById(ID).setAttribute('href', '../Application_BP_Renewal.pdf');
                        break;
                }
            }
            else if (CurrentURL.includes("MONTALBAN") == true) {
                switch (ID) {
                    case 'QG_BP':
                        document.getElementById(ID).setAttribute('href', '../Guide_BP.pdf');
                        break;
                    case 'QG_RPT':
                        document.getElementById(ID).setAttribute('href', '#');                       
                        break;               
                }

            }
            else if (CurrentURL.includes("CAINTA") == true) {
                switch (ID) {
                    case 'QG_BP':
                        document.getElementById(ID).setAttribute('href', '#');
                        break;
                    case 'QG_RPT':
                        document.getElementById(ID).setAttribute('href', '../Guide_RPT.pdf');
                        break;
                    case 'DF_NB':
                        document.getElementById(ID).setAttribute('href', '../Application_BP.pdf');
                        break;
                    case 'DF_RB':
                        document.getElementById(ID).setAttribute('href', '../Application_BP.pdf');
                        break;
                }

            }
            else if (CurrentURL.includes("122.53.27.82") == true) {
                switch (ID) {
                    case 'QG_BP':
                           document.getElementById(ID).setAttribute('href', '../Guide_BP.pdf');
                        break;
                    case 'QG_RPT':
                        document.getElementById(ID).setAttribute('href', '../Guide_RPT.pdf');
                        break;          
                }

            }
            else {
                switch (ID) {
                    case 'QG_BP':
                           document.getElementById(ID).setAttribute('href', '../Guide_BP.pdf');
                        break;
                    case 'QG_RPT':
                        document.getElementById(ID).setAttribute('href', '../Guide_RPT.pdf');
                        break;
                    case 'DF_NB':
                        document.getElementById(ID).setAttribute('href', '../DICT_ApplicationForm_New.pdf');
                        break;
                    case 'DF_RB':
                        document.getElementById(ID).setAttribute('href', '../DICT_ApplicationForm_Renewal.pdf');
                        break;


                }

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
            // NextPage();
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
        <div id="snackbar" style="z-index: 1200;">Some text some message..</div>
        <!-- Modal Create New Account Form -->
        <div id="Modal_SignUp" class="modal  fade">
            <div class="modal-dialog" style="min-width: 50vh; max-width: 80vh" role="document">
                <div class="modal-content ">
                    <div class="modal-header">

                        <h4 class="modal-title">Create New Account</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <div class="modal-body form-row">
                        <div class="form-group col-md-12 card shadow-lg" style="padding: 20px; min-height: 80vh;">

                            <ul class="nav nav-tabs mt-2" id="myTab" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#Signup" role="tab" aria-controls="home"
                                        aria-selected="true" onclick="">Sign up</a>

                                </li>
                                <li class="nav-item" id="tabQG">
                                    <a class="nav-link" id="Guide-tab" data-toggle="tab" href="#Guide" role="tab" aria-controls="profile"
                                        aria-selected="false" onclick="">Guide</a>

                                </li>
                                <li class="nav-item" id="tabDF" style="display: none;">
                                    <a class="nav-link" id="DownloadableFile-tab" data-toggle="tab" href="#DownloadableFile" role="tab" aria-controls="profile"
                                        aria-selected="false" onclick="">Downloadable Forms</a>


                                </li>
                            </ul>
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="Signup" role="tabpanel" aria-labelledby="home-tab">
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

                                        <br />
                                        <center>
                            <div runat="server" id="div_agent" class="form-group col-md-12" style="background-color:#257CFC;padding-bottom:0.5em;padding-top:0.5em;">                                  
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
                                                        <span><span class="m-2"><b style="color: red; font-size: larger">*</b>First Name</span></span>
                                                    </label>

                                                    <input type="text" id="TXTTRAPERROR" name="TXTTRAPERROR" style="display: none !Important" runat="server" />

                                                    <input type="text" id="TXTTRAPERROR2" name="TXTTRAPERROR2" style="display: none !Important" runat="server" />

                                                    <input required type="text" name="txtFirstName" class="form-control CH-size-new" id="txtFirstName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                                                </div>



                                            </div>

                                            <div class="form-group form-group-sm col-md-6">
                                                <div>
                                                    <label class="input-txt input-txt-active2">
                                                        <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Last Name</span></span>
                                                    </label>
                                                    <input required type="text" class="form-control CH-size-new" name="txtLastName" id="txtLastName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="form-group col-md-6">
                                                <div>
                                                    <label class="input-txt input-txt-active2">
                                                        <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Birth Date</span></span>
                                                    </label>
                                                    <input required type="text" name="txtBirthDate" class="form-control CH-size-new" id="txtBirthDate" min="1900-01-01" max="2018-12-31" onfocus="(this.type='date')" />
                                                </div>
                                            </div>

                                            <div class="form-group col-md-6">
                                                <div>
                                                    <label class="input-txt input-txt-active2">
                                                        <span><span class="m-2">Gender</span></span>
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
                                                    <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Email Address</span></span>
                                                </label>
                                                <input required type="text" class="form-control CH-size-new" id="txtEmailAddress" name="txtEmailAddress" onfocus="(this.type='email')" oninput="this.reportValidity()" title="Email Address">
                                            </div>
                                        </div>

                                        <div class="form-row">
                                            <div class="form-group col-md-6">
                                                <div>
                                                    <label class="input-txt input-txt-active2">
                                                        <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Mobile Number</span></span>
                                                    </label>
                                                    <input required type="text" name="txtMobileNo" class="form-control CH-size-new" id="txtMobileNo" pattern="[0-9]+" oninput="this.reportValidity()" title="Mobile No." maxlength="11" />
                                                </div>
                                            </div>

                                            <div class="form-group col-md-6">
                                                <div class="my-auto mx-2">
                                                    <asp:CheckBox runat="server" ID="_oCBResident" name="_oCBResident" Checked="true" CssClass="CH-Size my-auto mx-2" Text="&nbsp I am a resident of " Font-Size="14px" />
                                                </div>
                                            </div>
                                        </div>
                                        <label id="PassErr" style="display: none; color: red; font-size: 14px">Password did not match</label>
                                        <div class="form-row">

                                            <div class="form-group col-md-6">
                                                <div>
                                                    <label class="input-txt input-txt-active2">
                                                        <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Password</span></span>
                                                    </label>
                                                    <input required clientidmode="Static" type="password" class="form-control CH-size-new" name="txtPassword" id="txtPassword" oninput="chkPassword(this.id)" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters" required>
                                                </div>
                                            </div>

                                            <div class="form-group col-md-6">
                                                <div>
                                                    <label class="input-txt input-txt-active2">
                                                        <span>&nbsp<span class="m-2"><b style="color: red; font-size: larger">*</b>Confirm Password</span></span>
                                                    </label>
                                                    <input required clientidmode="Static" type="password" class="form-control CH-size-new" name="txtConfirmPassword" id="txtConfirmPassword" oninput="chkPassword(this.id)" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" title="Must contain at least one number and one uppercase and lowercase letter, and at least 8 or more characters" required>
                                                </div>
                                            </div>

                                        </div>


                                        <label style="font-size: smaller" class="p-2">This question will help us verify your identity should you forget your password.</label>
                                        <div class="form-row">

                                            <div class="form-group col-md-6">
                                                <div>
                                                    <label class="input-txt input-txt-active2">
                                                        <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Security Question</span></span>
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

                                            <div class="form-group col-md-6">
                                                <div>
                                                    <label class="input-txt input-txt-active2">
                                                        <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Security Answer</span></span>
                                                    </label>
                                                    <input required type="text" class="form-control CH-size-new" id="txtSecurityA" name="txtSecurityA" oninput="this.reportValidity()" title="Security Answer">
                                                </div>
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
                                                <input type="text" clientidmode="Static" runat="server" class="form-control" name="txtLocalUserName" id="txtLocalUserName" />
                                            </div>

                                            <div class="form-group col-md-6">
                                                <input type="password" clientidmode="Static" runat="server" class="form-control" name="txtPassKey" id="txtPassKey" />
                                            </div>

                                        </div>

                                        <center>                    

                             

                            <div  class="g-recaptcha col-lg-12 d-flex justify-content-center align-content-center"  id="_oCaptcha" data-sitekey="6LdY5E4UAAAAAIPlTO7r45ku7E9JqBPTJSGXtSRj" ></div>   
                     
                                    <a href="#" data-toggle="modal" data-target="#ResendValidation" data-ticket-type="standard-access"><i>Didn't receive email verification link?</i></a>    

                       
                          <div class="col">
 
                    <label style="font-size:14px">By clicking Sign Up, you agree and that you have read our </label>
                       <a style="font-size:14px" href="#" data-toggle="modal" data-target="#TermsAndConditions" data-ticket-type="standard-access">Terms and Conditions</a>
                      </div>
                       <p id="p1" ></p>      
                       <input type="hidden" id="hdnfld_Submit" name="hdnfld_Submit" value="false"/>  
          <div class="col">
                        <button form="frmSignUp" name="btnSignUp" id="btnSignUp" type="submit" class="btn btn-primary " style="font-size:20px" >Sign Up</button>
              </div>           
                        </center>
                                    </form>

                                </div>

                                <input style="display: none" type="button" id="testclick" runat="server" />



                                <div class="tab-pane fade" id="Guide" role="tabpanel" aria-labelledby="profile-tab">
                                     <br />        
                                    <ul>                                                                      
                                            <li><a id="QG_BP"  href="../Guide_BP.pdf" target="_blank">Guide for Business Permit </a></li>
                                            <li><a id="QG_RPT"  href="../Guide_RPT.pdf" target="_blank">Guide for Real Property</a></li>                                           
                                    </ul>

                                </div>
                              
                                <%--<div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab"></div>--%>
                            </div>


                        </div>

                    </div>


                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->


        <div class="form-row" style="padding: 10px;">
            <div class="form-group col-lg-9  ">
                <div class=" form-group col-md-12 card shadow-lg">
                    <div class="bd-example">
                        <div id="carouselExampleCaptions" class="carousel slide ml-1 mr-1" data-ride="carousel">
                            <%--<ol class="carousel-indicators" id="a1" style="display:none" runat="server"    >
                                      <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
                                      <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
                                     <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
                                      <li data-target="#carouselExampleCaptions" data-slide-to="3"></li>
                                  </ol>--%>
                            <center>
                            <div class="carousel-inner" runat="server" id="divCarousel" style="max-height:80vh">
                                <div class="carousel-item active">                                                                     
                                     <img src="../CSS_JS_IMG/img/carousel-1.jpg" style="max-height: 80vh; max-width: 100%" />
                                </div>
                                <div class="carousel-item">
                                    <img src="../CSS_JS_IMG/img/carousel-2.jpg" style="max-height: 80vh; max-width: 100%" />

                                </div>
                                <div class="carousel-item">
                                    <img src="../CSS_JS_IMG/img/carousel-3.jpg " style="max-height: 80vh; max-width: 100%" />
                                </div>

                                <div class="carousel-item">
                                    <img src="../CSS_JS_IMG/img/carousel-4.jpg"style="max-height: 80vh; max-width: 100%" />
                                </div>

                            </div>
                                </center>
                            <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>
                    </div>

                </div>
            </div>
            <div class="form-group col-lg-3 ">

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="form-group col-md-12 card shadow-lg" style="padding: 20px; min-height: 80vh;">
                            <div style="height: 10vh;">
                                <img runat="server" id="imgLogoHere" src="#" style="height: 100%" />                                
                            </div>
                            
                            <b style="font-size: 40px">Welcome!</b>
                            Sign in to continue
                <br />
                            <br />
                            <br />
                            <br />
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Email Address</span></span>
                                </label>
                                <input required type="text" runat="server" name="LoginEmail" class="form-control CH-size-new" id="LoginEmail" onfocus="(this.type=email;)" oninput="this.reportValidity();" />
                            </div>
                            <br />
                            <div>

                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Password</span></span>
                                </label>
                                <input required type="password" runat="server" name="LoginPassword" class="form-control CH-size-new" id="LoginPassword" />

                                <div style="padding: 10px 0px">
                                    <div class="col-lg-6"></div>
                                    <a href="#" class="col-lg-6" style="float: right; font-size: small; text-align: right" data-toggle="modal" data-dismiss="modal" data-target="#Forgot" data-ticket-type="standard-access">Forgot password</a>
                                </div>
                                <input type="button" id="btnLogin" onclick="do_Login();" class="btn btn-primary col-lg-7" value="Login" />
                                <input type="button" id="_btnLogin" runat="server" style="display: none;" />


                            </div>
                            <br />
                            <br />                            
                            <a href="#" class="col-md-12 text-center" data-toggle="modal" data-dismiss="modal" data-target="#DLForms" data-ticket-type="standard-access">Downloadable Forms</a>
                            <hr />
                            <br />
                            <br />
                            <center>
                      <input type="button" class="btn btn-success col-lg-8" value="Create New Account" data-toggle="modal" data-dismiss="modal" data-target="#Modal_SignUp" data-ticket-type="standard-access"/>
        
                                 

                </center>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <%--
        <div class="">
            <div class="row " style="padding-left: 0; padding-right: 0;">
                <div class="col-lg-8 " style="padding-left: 0; padding-right: 0;">


                    <div class="mt-1 ">



                               
                    </div>



                </div>

                <div class="col-lg-4 mt-1" style="padding-left: 0; padding-right: 0; zoom: 98%;">
                    <div class="col-sm-12 mx-auto" style="padding-left: 0; padding-right: 0;">
                        <div class="card shadow-lg" style="padding-left: 0; padding-right: 0;">

                            
                        </div>
                    </div>
                </div>


            </div>


        </div>--%>

        <!-- Modal Login Form 
        <div id="Login" class="modal fade">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Sign In</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>

                    <asp:Panel runat="server" CssClass="modal-body" DefaultButton="btnSignIn">
                        <div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtLoginEmail" class="form-control" />
                            </div>
                            <div class="form-group">
                                <asp:TextBox runat="server" ID="txtLoginPassword" CssClass="form-control" TextMode="Password" />
                            </div>
                            <a href="#" tabindex="99" data-toggle="modal" data-dismiss="modal" data-target="#Forgot" data-ticket-type="standard-access">Forgot password</a>
                            <div class="text-center">
                                <asp:Button ID="btnSignIn" UseSubmitBehavior="false" runat="server" Text="Sign In" CssClass="button" />
                            </div>
                        </div>

                    </asp:Panel>
                </div>             
            </div>       
        </div>
        /.modal -->

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
                  <input id="_oTextboxEmailReset" type="text" required class="form-control" onfocus="(this.type='email')" name="_oTextboxEmailReset">
                                <input type="hidden" id="hdnfld_Forgot" name="hdnfld_Forgot" value="false" />

                            </div>

                            <div class="text-center">
                                <asp:Button runat="server" from="frmForgotPass" ID="btnForgot" type="submit" CssClass="btn btn-primary small" Text="Reset Password"></asp:Button>

                            </div>
                        </form>


                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

        <!-- Modal DL Form -->
        <div id="DLForms" class="modal fade">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Downloadable Forms</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                           <asp:GridView ID="gv_DLForms" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                        <Columns>        

                             <asp:TemplateField HeaderText="File Size" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                     <asp:Label ID="_oLabelFileSize" runat="server" Text='<%# Eval("strSize")%>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="File Name (Click to Download)" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>                                
                       <a download="<%# Eval("FileName")%>" class="form-group"
                               href="<%# Eval("File64")%>"   
                              target="_blank">
                               <%# Eval("FileName")%>
                            </a>
                    </ItemTemplate>
                </asp:TemplateField>          

            </Columns>
        </asp:GridView>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

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

                  <input id="ResendEmail" type="text" required class="form-control" name="ResendEmail" onfocus="(this.type='email')" clientidmode="Static" />
                                <input type="hidden" id="hdnfld_Resend" name="hdnfld_Resend" value="false" />
                            </div>

                            <div class="text-center">
                                <asp:Button runat="server" from="frmResend" ID="btnResend" type="submit" class="btn btn-primary small" Text="Resend Verification Link"></asp:Button>


                            </div>
                        </form>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->

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

        <!-- Modal ANN Form -->
        <div id="DIV_ANN" class="modal fade">

            <div class="modal-dialog" style="min-width: 50vh; max-width: 80vh" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" runat="server" id="ANN_TITLE">Terms and Conditions</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <label runat="server" id="ANN_DATE"></label>
                        <div class="form-group" style="text-align: justify" runat="server" id="ANN_CONTENT">
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



    <div style="color: white; background-image: linear-gradient(0deg, #DCDCDC, gray); position: fixed; bottom: 0; left: 0; border-radius: 0px 10px 0px 0px; padding: 0px 5px">
        <table style="font-family: Verdana">
            <tr>
                <td>
                    <label>Online:</label></td>
                <td>
                    <label runat="server" id="OnlineNow"></label>
                </td>
            </tr>

        </table>
    </div>

      <input type="hidden" id="err" runat="server" />

    <script>
        //  document.getElementsByClassName('LoginEmail')[0].;

        document.getElementById('<%= LoginEmail.ClientID%>').attributes["type"].value = "text";


        var LoginEmail = document.getElementById('<%= LoginEmail.ClientID%>');
        var LoginPassword = document.getElementById('<%= LoginPassword.ClientID%>');
        LoginEmail.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                document.getElementById("btnLogin").click();
            }
        });
        LoginPassword.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                document.getElementById("btnLogin").click();
            }
        });

        function openModal(val) {
            $('#' + val).modal('show');
        }


        function ShowSnackBar(color, msg) {
            var x = document.getElementById("snackbar");
            x.style.backgroundColor = color;
            x.innerText = msg;
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }

        function do_Login() {
            var isValid;
            isValid = document.getElementById('<%= LoginEmail.ClientID%>').reportValidity();
            if (isValid == false) {
                return;
            }
            isValid = document.getElementById('<%= LoginPassword.ClientID%>').reportValidity();
            if (isValid == false) { return; }

            if (isValid == true) {
                document.getElementById('btnLogin').disabled = true;
                document.getElementById('btnLogin').value = 'Logging in ... ';
                document.getElementById('<%= _btnLogin.ClientID%>').click();


                //Cedela App Config
                cedulaAppConfig();
                //End Cedela App Config

            }
        }
        var CurrentURL = window.location.href;
        CurrentURL = CurrentURL.toUpperCase();

     


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


        //Cedula App Config
        function cedulaAppConfig() {
            //THIS CODE IS FOR CEDULA APP
            localStorage.setItem('LoginEmail', document.getElementById('LoginEmail').value);
            localStorage.setItem('LoginPassword', document.getElementById('LoginPassword').value);
            //App Config
            $.ajax({
                url: "https://online.spidc.com.ph/spidc_web_api/Configuration/client-side-config.json",
                type: "GET",
                async: true,
                cache: false,
                dataType: "json",
                success: function (data) {
                    localStorage.setItem('url', data.url);
                    localStorage.setItem('webPortalURLLogin', data.webPortalURLLogin);
                    localStorage.setItem('webPortalURLTaxpayer', data.webPortalURLTaxpayer);
                    localStorage.setItem('webPortalURLTreasury', data.webPortalURLTreasury);
                    localStorage.setItem('apiKey', data.apiKey);
                },
                error: function (xhr, status, error) {
                    console.log(error);
                }
            });
            //END THIS CODE IS FOR CEDULA APP
        }
    </script>


    <asp:Button UseSubmitBehavior="true" Visible="false" ID="testSnackBar" runat="server" Text="SHOW SnackBar" />
</asp:Content>
