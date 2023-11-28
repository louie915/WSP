<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" CodeBehind="ChangePassword.aspx.vb" Inherits="SPIDC.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /> <br /> <br /> <br /> <br />
     <center>
         
          <strong>Change Password</strong> <br />
         
             <hr />             
           
          <div class="container col-md-6"  style="border:1px solid gray; background-color:white; padding:10px; border-radius:10px">
               

            <div class="form-row">                 
                <div class="form-group col-md-12" style="text-align:left">   New Password <span style="color:red">*</span><br />        
                  <input  type="password" required  style="text-align:center"  name="_oTextboxNewPass" class="form-control" id="_oTextboxNewPass" />
                </div>  
            </div>                                

           <div class="form-row">                 
                <div class="form-group col-md-12" style="text-align:left">   Confirm New Password <span style="color:red">*</span><br />        
                  <input  type="password" required  style="text-align:center" name="_oTextboxNewPass2" class="form-control" id="_oTextboxNewPass2" />
                </div>             
            </div>    
                <hr/>
		
		
	<button type="submit" class="button" id="btnSave" onclick="do_save('Save');" style="background-color:forestgreen">Save</button>
 		 
       
             </div>

  </center>

    <script>
        function do_save(Action) {
            var p1 = document.getElementById('_oTextboxNewPass').value
            var p2 = document.getElementById('_oTextboxNewPass2').value
            var result = p1.localeCompare(p2);          
            switch (result) {
                case 0: // Password OK                    
                    document.getElementById('_oTextboxNewPass2').setCustomValidity("");
                    __doPostBack(Action, p2);
                    break;
               default: // Passwords don't match             
                  document.getElementById('_oTextboxNewPass2').setCustomValidity("Passwords don't match");
                  document.getElementById('_oTextboxNewPass2').reportValidity()
             
            }
        }
    </script>


</asp:Content>
