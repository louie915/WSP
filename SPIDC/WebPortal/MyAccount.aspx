<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="MyAccount.aspx.vb" Inherits="SPIDC.MyAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
        <br />   <br />  
       <section id="Home-Page" >
        <div class="container">
           
     <div class="row">
          <div class="col-lg-12">
                       
            <div class="card mb-5 mb-lg-0">
              <div class="card-body">    
                

              <form id="frmAccount" name="frmAccount" method="post" onsubmit="UpdateInfo();">
              <h5 class="card-title text-muted text-uppercase text-center"  style="display:inline-block">Account  Information</h5><input type="button"value="Edit Info" style="display:inline-block;float:right" /> <input type="button"value="Change Password" onclick="window.location='changepassword.aspx';" style="display:inline-block;float:right" />
                   <hr>                  
                      <div class="form-row">
                  <div class="form-group col-md-4"> <span style="font-size:smaller;color:cornflowerblue">First Name</span>  <span style="color:red">*</span>           
                    <input required type="text" name="txtFirstName" class="form-control" id="txtFirstName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
              </div>

                  <div class="form-group col-md-4">  <span style="font-size:smaller;color:cornflowerblue">Middle Name</span>     
                    <input  type="text" class="form-control" name="txtMiddleName" id="txtMiddleName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Middle Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                  </div>

                  <div class="form-group col-md-4">   <span style="font-size:smaller;color:cornflowerblue">Last Name</span>  <span style="color:red">*</span>        
                    <input required  type="text" class="form-control" name="txtLastName" id="txtLastName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                  </div>
                </div>                     
                      <div class="form-row">
                  <div class="form-group col-md-4"> <span style="font-size:smaller;color:cornflowerblue">Birth Date</span>  <span style="color:red">*</span>           
                 <input required type="text" name="txtBirthDate" class="form-control" id="txtBirthDate" min="1900-01-01" max="2018-12-31" placeholder="Birth Date" onfocus="(this.type='date')" />
                </div>

                  <div class="form-group col-md-4">  <span style="font-size:smaller;color:cornflowerblue">Gender</span>  <span style="color:red">*</span>     
                         <select required  id="radGender" name="radGender" class="form-control" >   
                        <option value="" disabled selected>Gender</option>               
                        <option value="M">Male</option>
                        <option value="F">Female</option>
                      </select>  </div>

                  <div class="form-group col-md-4">   <span style="font-size:smaller;color:cornflowerblue">Civil Status</span>  <span style="color:red">*</span>        
                    <input required  type="text" class="form-control" name="txtCivilStatus" id="txtCivilStatus" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                  </div>


                </div>                                
                      <div class="form-row">
                  <div class="form-group col-md-4"> <span style="font-size:smaller;color:cornflowerblue">TIN</span> 
                    <input type="text" name="txtTIN" class="form-control" id="txtTIN" oninput="this.reportValidity()" title="TIN"/>
              </div>

                  <div class="form-group col-md-4">  <span style="font-size:smaller;color:cornflowerblue">Mobile Number</span>     
                    <input  type="number" class="form-control" name="txtMobileNo" id="txtMobileNo" oninput="this.reportValidity()" title="Mobile Number" />
                  </div>

                  <div class="form-group col-md-4">   <span style="font-size:smaller;color:cornflowerblue">Phone Number</span> 
                    <input required  type="number" class="form-control" name="txtPhoneNo" id="txtPhoneNo" oninput="this.reportValidity()" title="Mobile Number" />
                  </div>
                </div>  
                      <div class="form-group"><span style="font-size:smaller;color:cornflowerblue">Mailing Address</span>  <span style="color:red">*</span>           
                        <textarea required class="form-control" id="txtaddressLine1" name="txtaddressLine1" title="Address Line 1"> </textarea>
                    </div>           
                   <center>                    
                 
                    
                    
                       <input type="hidden" id="hdnfld_Submit" name="hdnfld_Submit" value="false"/>  
                       <button form="frmSignUp" name="btnSignUp" id="btnSignUp" type="submit" class="button col-md-12" >Sign Up</button>
                  
                        
                        </center>                     
                       </form>	

                      </div>
            </div>
          </div>    
     </div>
            </div>
             </section>

   
</asp:Content>
