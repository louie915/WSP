<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VerifyEmail.aspx.vb" Inherits="SPIDC.VerifyEmail" %>

<!DOCTYPE html>
<html>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">


<body class="w3-theme-l5">
<!-- Page Container -->
<div class="w3-container w3-content" style="max-width:1400px;margin-top:80px">    
  <!-- The Grid -->

  <div class="w3-row">
    <!-- Left Column -->
    <div class="w3-col m12">
      <!-- Profile -->
      <div class="w3-card w3-round w3-white">
        <div class="w3-container w3-center">
          <br>  <br>  <br>
         <h2><asp:Label ID="lblHeader" runat="server" Text="You're All Set"></asp:Label></h2>
      <div id="OK">
          <asp:Label ID="lblOK" runat="server" Text=""></asp:Label>
    <i><a id="link1" runat="server" style="color:blue;text-decoration:none" href="" >here</a></i> and start using our Online Services!
      </div>
    
    
      <br>  <br>  <br> <br>  <br>
     
        </div>
      </div>
      <br>


  <!-- End Grid -->
  </div>
  
<!-- End Page Container -->
</div>
<br>

 
</body>
</html> 
