<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NewRegisterPage.aspx.vb" Inherits="SPIDC.NewRegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
        <meta name="description" content="">
        <meta name="author" content="">
        <link href="../CSS_JS_IMG/OS-JS-CSS/fontawesome-free/css/all.min.css" rel="stylesheet" />       
        <title runat="server" id="titleLGU">SPIDC Web Portal</title>    
        <link href="../CSS_JS_IMG/OS-JS-CSS/Css/Online-Services.css" rel="stylesheet" />     
        <script src="../CSS_JS_IMG/OS-JS-CSS/Js/OS-Mobile-View.js"></script>   
       <link href="../CSS_JS_IMG/css/Sticker.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="d-flex justify-content-center align-content-end mt-5">
        <div  class="col-lg-5 mt-1">
                   <div class="col-sm-12 mx-auto" >
                  <div  class="card shadow-lg" >
                      <div class="card-body col-sm-12 " >
                          <div class="col-sm-12 text-center text-capitalize mb-3" ><i class="fa fa-user"></i> &nbsp Register / Signup</div>
                          
                          <div class="col mb-3 d-flex align-content-center justify-content-center">
 
                    <label style="font-size:16px">You have already agreed to the &nbsp</label>
                       <a style="font-size:16px" href="#" data-toggle="modal" data-target="#TermsAndConditions" data-ticket-type="standard-access">Terms and Conditions &nbsp<input type="checkbox" id="_oCBTermandConditions" name="_oCBTermandConditions" class="my-auto mt-2" style="height:15px;width:15px" /></a>                                                      
                      </div>


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
                              <div class="form-row">
                                  <div class="form-group col-md-6">

                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2">First Name</span></span>
                                          </label>

                                          <input required type="text" name="txtFirstName" class="form-control CH-size-new" id="txtFirstName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                                      </div>



                                  </div>

                                  <div class="form-group form-group-sm col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2">Last Name</span></span>
                                          </label>
                                          <input required type="text" class="form-control CH-size-new" name="txtLastName" id="txtLastName"  pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                                      </div>
                                  </div>
                              </div>
                              <div class="form-row">
                                  <div class="form-group col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2">Birth Date</span></span>
                                          </label>
                                          <input required type="text" name="txtBirthDate" class="form-control CH-size-new" id="txtBirthDate" min="1900-01-01" max="2018-12-31"  onfocus="(this.type='date')" />
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
                                          <span><span class="m-2">Email Address</span></span>
                                      </label>
                                      <input required type="email" class="form-control CH-size-new" id="txtEmailAddress" name="txtEmailAddress"  oninput="this.reportValidity()" title="Email Address">
                                  </div>
                              </div>
                              <div class="form-row">
                                  <div class="form-group col-md-6">

                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2">Mobile Number</span></span>
                                          </label>

                                          <input required type="text" name="txtMobileNo" class="form-control CH-size-new" id="txtMobileNo"   pattern="[0-9]+" oninput="this.reportValidity()" title="Mobile No." maxlength="11"/>
                                      </div>



                                  </div>

                                   <div class="form-group col-md-6">
                                          <div class="my-auto mx-2"> <asp:CheckBox runat="server" id="_oCBResident"  name="_oCBResident" Checked="true" cssclass="CH-Size my-auto mx-2" Text="&nbsp I am a resident of SPIDC" Font-Size="14px"/></div>
                                        </div>
                              </div>
                              <label id="PassErr" style="display: none; color: red; font-size: 14px">Password did not match</label>
                              <div class="form-row">
                                  

                                      
                                  

                                  <div class="form-group col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span><span class="m-2">Password</span></span>
                                          </label>
                                          <input required clientidmode="Static" type="password" class="form-control CH-size-new" name="txtPassword" id="txtPassword"  oninput="chkPassword(this.id)" />
                                      </div>
                                  </div>

                                  <div class="form-group col-md-6">
                                      <div>
                                          <label class="input-txt input-txt-active2">
                                              <span>&nbsp<span class="m-2">Confirm Password</span></span>
                                          </label>
                                          <input required clientidmode="Static" type="password" class="form-control CH-size-new" name="txtConfirmPassword" id="txtConfirmPassword"  oninput="chkPassword(this.id)" />
                                      </div>
                                  </div>

                              </div>

                              <label style="font-size: smaller" class="p-2">This question will help us verify your identity should you forget your password.</label>
                              <div class="form-group">
                                  
                                  <div>
                                      <label class="input-txt input-txt-active2 ml-2">
                                          <span><span class="m-2">Security Question</span></span>
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
                                          <span><span class="m-2">Security Answer</span></span>
                                      </label>
                                      <input required type="text" class="form-control CH-size-new" id="txtSecurityA" name="txtSecurityA"  oninput="this.rep+ortValidity()" title="Security Answer">
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

                             

                            <div  class="g-recaptcha col-lg-12 d-flex justify-content-center align-content-center"  id="_oCaptcha" data-sitekey="6LdY5E4UAAAAAIPlTO7r45ku7E9JqBPTJSGXtSRj" style="zoom:120%"></div>   
                     
                                    <a href="#" data-toggle="modal" data-target="#ResendValidation" data-ticket-type="standard-access"><i>Didn't receive email verification link</i></a>    
                                                 
                       <p id="p1" ></p>      
                       <input type="hidden" id="hdnfld_Submit" name="hdnfld_Submit" value="false"/>  
          <div class="col">                                                                                                
                        <button form="frmSignUp" name="btnSignUp" id="btnSignUp" type="submit" class="btn btn-success btn-icon-split ml-2 my-2" style="font-size:20px">
                            <span class="text">Sign Up</span>
                <span class="icon text-white">
                    <i class="fas fa-sign-in-alt"></i>
                </span>                
            </button>
              </div>                        
                        </center>
                          </form>                           
                      </div>
                  </div>
                       </div> 
              </div>
    </div>
        <div id="TermsAndConditions" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Terms and Conditions</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               
                <div class="col-12 d-flex align-content-center align-items-center justify-content-center">
                   <ol type="1" class="justify-content-center">
                      <li>The information provided is certified as TRUE and CORRECT.</li><br />
                      <li>Registrant should keep their account confidential and will NOT SHARE to anyone.</li><br />
                      <li>I hereby agree that all Personal Data (as defined under the Data Privacy Law of 2012 and its implementing rules and regulations), customer data and account or transaction information or records (collectively, the "information") which may be with City Government from time to time relating to us may be processed, profiled or shared to requesting parties or for the purpose of any court, legal process, examination, inquiry, audit or investigation of any Authority. The aforesaid terms shall apply notwithstanding any applicable non-disclosure agreement. We acknowledge that such information may be processed or profiled by or shared with jurisdictions which do not have strict data protection or data privacy laws.</li>
                    </ol>                

                </div>              
  
               <div class="text-center">                 
                 <div class="col">                        
                        <button id = "btnagree" type="button" data-dismiss="modal" class="btn btn-success btn-icon-split ml-2 my-2" value="I Agree" onclick="document.getElementById('_oCBTermandConditions').checked = true;">
                            <span class="text">I Agree</span>
                <span class="icon text-white">
                    <i class="fas fa-check-circle"></i>
                </span>                
            </button>
              </div>   
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->
        <script src="../CSS_JS_IMG/OS-JS-CSS/jquery/jquery.min.js"></script>
        <script src="../CSS_JS_IMG/OS-JS-CSS/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="../CSS_JS_IMG/OS-JS-CSS/jquery-easing/jquery.easing.min.js"></script>
        <%--<script src="../CSS_JS_IMG/js/newjs/sb-admin-2.min.js"></script>--%>
        <script src="../CSS_JS_IMG/OS-JS-CSS/Js/Online-Services.js"></script>
        <script src="../CSS_JS_IMG/OS-JS-CSS/Js/OS-MainPage.js"></script>  
    </form>
</body>
</html>
