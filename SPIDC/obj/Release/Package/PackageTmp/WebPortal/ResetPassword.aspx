<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ResetPassword.aspx.vb" Inherits="SPIDC.ResetPassword" %>

<!DOCTYPE html>
<html>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">


<body class="w3-theme-l5">
 
<!-- Page Container -->
<div class="w3-container w3-content" >    
  <!-- The Grid -->

  <div class="w3-row">
    <!-- Left Column -->
    <div class="w3-col m6">
      <!-- Profile -->
      <div class="w3-card w3-round w3-white">
        <div class="w3-container w3-center">
          <br>  <br>  <br>
         <h2><asp:Label ID="lblHeader" runat="server" Text="Reset Password"></asp:Label></h2>
     
          <form runat="server">
          <div class="form-row col-md-12">                 
                <div class="form-group col-md-12" style="text-align:left">New Password<br />        
                  <input  type="password"  runat="server" name="_oTextboxNewPass" class="form-control" id="_oTextboxNewPass" />
                </div>  
           
              <div class="form-group col-md-12" style="text-align:left">Confirm New Password<br />                   
                <input   type="password"  runat="server" name="_oTextboxConfirmNewPass" class="form-control" id="_oTextboxConfirmNewPass"/>
              </div>
                <asp:button runat="server" cssclass="button" id="btnSave" text="Change my password"></asp:button>
            </div>    
        
 </form>
    
    
      <br>  
     
        </div>
      </div>
      <br>


  <!-- End Grid -->
  </div>
  
<!-- End Page Container -->
</div>
<br>

 <script>
     function Snackbar() {
         var x = document.getElementById("snackbar");
         x.className = "show";
         setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
     }
     function SnackbarGreen() {
         var x = document.getElementById("snackbargreen");
         x.className = "show";
         setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);

     }
        </script>  
 </script>
</body>
</html> 
