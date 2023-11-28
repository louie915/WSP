<%@ Page EnableEventValidation="false"  Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.OAIMS/OAIMS.Master" CodeBehind="Login.aspx.vb" Inherits="IMC.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" EnableEventValidation="true">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
.switch {
  position: relative;
  display: inline-block;
  width: 60px;
  height: 34px;
}

.switch input { 
  opacity: 0;
  width: 0;
  height: 0;
}

.slider {
  position: absolute;
  cursor: pointer;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: #ccc;
  -webkit-transition: .4s;
  transition: .4s;
}

.slider:before {
  position: absolute;
  content: "";
  height: 26px;
  width: 26px;
  left: 4px;
  bottom: 4px;
  background-color: white;
  -webkit-transition: .4s;
  transition: .4s;
}

input:checked + .slider {
  background-color: #2196F3;
}

input:focus + .slider {
  box-shadow: 0 0 1px #2196F3;
}

input:checked + .slider:before {
  -webkit-transform: translateX(26px);
  -ms-transform: translateX(26px);
  transform: translateX(26px);
}

/* Rounded sliders */
.slider.round {
  border-radius: 34px;
}

.slider.round:before {
  border-radius: 50%;
}
</style>
    <script>
            function CheckLGUReg() {
                if (document.getElementById('<%=chkLGUReg.ClientID%>').checked == true) {
                
                    document.getElementById('LGUDIV').style.visibility = "visible";                    
                    document.getElementById('lblcheck').innerHTML = 'LGU';                    
                    document.getElementById("PassKey").required = true;                    
                    document.getElementById("UserType").required = true;
                    
                   
                
                } else {
                    document.getElementById('LGUDIV').style.visibility = "hidden";
                    document.getElementById('lblcheck').innerHTML = 'Tax Payer';
                    document.getElementById("PassKey").required = false;
                    document.getElementById("UserType").required = false;
                   
                }
               
            }

            //SNACKBAR - Invalid Email/Password
            function Snackbar() {
                var x = document.getElementById("snackbar");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
            }
            function SnackbarGreen() {
                var x = document.getElementById("snackbargreen");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
            }
        </script>  
    <script>
        $(document).ready(function () {
            $("Login").focus(function () {
                var div = document.getElementById("Login");
                div.addEventListener("keyup", function (event) {
                    if (event.keyCode === 13) {
                        event.preventDefault();
                        document.getElementById("btnSignIn").click();
                    }
                });
            });
        });
</script>       
    <section id="Main-Page" class="section-with-bg wow fadeInUp">
      <div class="container">
<br /><br />
            
            <div id="snackbar">
            <asp:Label runat="server" id="_oLabelSnackbar" Text="Invalid Email or Password"/>           
        </div>
        <div id="snackbargreen" style="position:absolute">>
            <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
        </div>
        <div class="row">
          <div class="col-lg-5">
            <div class="card mb-5 mb-lg-0">
              <div class="card-body">
           
                  
              </div>
            </div>
          </div>
     
     
          <div class="col-lg-7">
            <div class="card">
              <div class="card-body">
                <h5 class="card-title text-muted text-uppercase text-center">Web App Desc</h5>
   
                <hr>
                <ul class="fa-ul">
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Online Registration</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Online Assessment</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Online Status Monitoring</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Online Payment</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Online Business Registration</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Online Real Property Assessment</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Sample</li>
                <li><span class="fa-li"><i class="fa fa-check"></i></span>Sample</li>
     

                </ul>
                        
               
              </div>
            </div>
          </div>
        </div>
          <br /> <br /> <br /> <br /> <br />
      </div>

                  
      <!-- Modal Login Form -->     
      <div id="Login" class="modal fade" >
        <div class="modal-dialog" role="document" >
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Login</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>

            <asp:panel runat="server" cssclass="modal-body" defaultbutton="btnSignIn" >
               <div  >
                <div class="form-group">                    
                     <asp:textbox runat="server" id="txtLoginEmail"  class="form-control" placeholder ="Email Address" />                   
                </div>
                <div class="form-group">                
                  <asp:TextBox runat="server" ID="txtLoginPassword"  CssClass="form-control" PlaceHolder="Password" TextMode="Password"/>       
                     </div>    
            <a href="#" tabindex="99" data-toggle="modal" data-dismiss="modal" data-target="#Forgot" data-ticket-type="standard-access">Forgot password</a>
               <div class="text-center">         
                   <asp:Button ID="btnSignIn" UseSubmitBehavior="false" runat="server" Text ="Sign In" cssclass="btn"/>
                </div>
               </div>
              
            </asp:panel>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->

         <!-- Modal Register Form -->     
      <div id="Register" class="modal fade" >
        <div class="modal-dialog" role="document" >
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Register Account</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>

            <asp:panel runat="server" cssclass="modal-body"  >
                 
                  <label class="switch"> 
                      <input runat="server" type="checkbox" onclick="CheckLGUReg()" id="chkLGUReg">
                      <span class="slider round"></span>
                 </label>
                  <label id="lblcheck" class="card-title text-muted text-uppercase text-center"  >Tax Payer</label>
      
         
                  <form method="post">
  
                        
            <div class="form-row">
              <div class="form-group col-md-6">                  
                <input required  type="text" runat="server" name="FirstName" class="form-control" id="txtFirstName" placeholder="First Name" pattern="[\s A-Za-z]+" oninput="this.reportValidity()" title="First Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
             
             
                   </div>

              <div class="form-group col-md-6">            
                <input required type="text" runat="server" class="form-control" name="LastName" id="txtLastName" placeholder="LastName" pattern="[\s A-Za-z]+" oninput="this.reportValidity()" title="Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>
            </div>

            <div class="form-row">

                  <div class="form-group col-md-6">                  
                <input required type="text" runat="server" name="BirthDate" class="form-control" id="txtBirthDate" max="2019-01-01" placeholder="Birth Date" onfocus="(this.type='date')" />
   
              </div>   
                
                   <div class="form-group col-md-6">            
                  <select required runat="server" id="radGender" name="Gender" class="form-control" >   
                    <option value="" disabled selected>Gender</option>               
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                  </select>
                </div>
             </div>

            <div class="form-group">
                    <input required type="email" runat="server"  class="form-control" id="txtEmailAddress" name="EmailAddress" placeholder="Email Address" oninput="this.reportValidity()" title="Email Address">
                </div>

            <div class="form-row">

              <div class="form-group col-md-6">                  
                <input required type="password" runat="server" name="Password" class="form-control" id="txtPassword" placeholder="Password" data-rule="minlen:8" data-msg="Please enter at least 4 chars" />
              </div>

              <div class="form-group col-md-6">            
                <input required type="password" class="form-control" runat="server" name="email" id="txtConfirmPassword" placeholder="Confirm Password" data-rule="email" data-msg="Please enter a valid email" />
              </div>
            </div>  
                                            
            <div class="form-row" id="LGUDIV" style="visibility:hidden" >
              <div class="form-group col-md-12">                  
                <select required id="cmbUserType" runat="server" name="Gender" class="form-control" >   
                    <option value="" disabled selected>Select User Type</option>               
                    <option value="BPLO">BPLO</option>
                    <option value="Treasury">Treasury</option>
                  </select>

              </div>

              <div class="form-group col-md-6">            
                <input required type="text" runat="server" class="form-control" name="LocalUserName" id="txtLocalUserName" placeholder="Local Username" />
              </div>

              <div class="form-group col-md-6">            
                <input required type="password" runat="server" class="form-control" name="PassKey" id="txtPassKey" placeholder="Pass Key" />
              </div>
            </div>      
                                
              
            <div class="form-group">
                         <center>

                    <div onclick="get_action(this)" class="g-recaptcha" data-sitekey="6LdY5E4UAAAAAIPlTO7r45ku7E9JqBPTJSGXtSRj" ></div>
                              <script>
                                  function get_action(form) {
                                      var FName = document.getElementById('<% =txtFirstName.ClientId %>').value;
                                      var LName = document.getElementById('<% =txtLastName.ClientID%>').value;
                                      var BDate = document.getElementById('<% =txtBirthDate.ClientID%>').value;
                                      var Gender = document.getElementById('<% =radGender.ClientID%>').value;
                                      var Email = document.getElementById('<% =txtEmailAddress.ClientID%>').value;
                                      var Password = document.getElementById('<% =txtPassword.ClientID%>').value;


                                      var v = grecaptcha.getResponse();

                                      if (v.length == 0) {
                                          alert('Invalid Captcha')
                                          return false;

                                      }
                                      else if (fname.length == 0) {
                                          alert('shit')
                                      }
                                  }
                              </script>                            
                             </center>             
                        
                </div>     
       
                <div class="text-center">
                  <button type="submit" value="Submit" class="btn" onclick="get_action(this)" >Sign up</button>
                 
                     </div>
 </form>
              
            </asp:panel>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->
        

                 
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
                <form action="" method="post">
                <div class="form-group">
                  <input type="email" required class="form-control" name="your-name" placeholder="Email Address">
                </div>              
  
               <div class="text-center">
                  <button type="submit" class="btn">Reset Password</button>
                </div>
           </form>
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->

    </section>          
</asp:Content>
