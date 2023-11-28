<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CR.aspx.vb" Inherits="IMC.CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

  <meta charset="utf-8">
  <title>Central Resource</title>
  <meta content="width=device-width, initial-scale=1.0" name="viewport">

  <!-- Favicons -->
 <link href="../CSS_JS_IMG/img/favicon.png" rel="icon">
 <link href="../CSS_JS_IMG/img/apple-touch-icon.png" rel="apple-touch-icon">
  
  <!-- Google Fonts -->
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Raleway:300,400,500,700,800" rel="stylesheet">

  <!-- Bootstrap CSS File -->
 <link href="../CSS_JS_IMG/lib/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Libraries CSS Files -->
  <link href="../CSS_JS_IMG/lib/font-awesome/css/font-awesome.min.css" rel="stylesheet">
  <link href="../CSS_JS_IMG/lib/venobox/venobox.css" rel="stylesheet">
  <link href="../CSS_JS_IMG/lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet">

  <!-- Main Stylesheet File -->
  <link href="../CSS_JS_IMG/css/style.css" rel="stylesheet">
</head>
<body>
  <div id="snackbar">
            <asp:Label runat="server" id="_oLabelSnackbar" Text="Invalid Email or Password"/>           
        </div>
        <div id="snackbargreen" style="position:absolute">>
            <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
        </div>
    <br />
    <center>
           
          <div class="col-lg-4">
            <div class="card mb-5 mb-lg-0">
              <div class="card-body">      
                  <form method="post">        
            <div class="form-row">
              <div class="form-group col-md-12">                  
                <input required type="password" runat="server" name="Password" class="form-control" id="txtPassword" placeholder="Password" data-rule="minlen:8" data-msg="Please enter at least 4 chars" />
              </div>
            </div>                                              
           
                <div class="text-center">
                  <button type="submit" value="Submit" class="btn" onclick="get_action(this)" >Login</button>
                 
                     </div>
 </form>
                  
              </div>
            </div>
          </div>
                </center>
</body>
      <!-- JavaScript Libraries -->
  
  <script src="../CSS_JS_IMG/lib/jquery/jquery.min.js"></script>
  <script src="../CSS_JS_IMG/lib/jquery/jquery-migrate.min.js"></script>
  <script src="../CSS_JS_IMG/lib/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="../CSS_JS_IMG/lib/easing/easing.min.js"></script>
  <script src="../CSS_JS_IMG/lib/superfish/hoverIntent.js"></script>
  <script src="../CSS_JS_IMG/lib/superfish/superfish.min.js"></script>
  <script src="../CSS_JS_IMG/lib/wow/wow.min.js"></script>
  <script src="../CSS_JS_IMG/lib/venobox/venobox.min.js"></script>
  <script src="../CSS_JS_IMG/lib/owlcarousel/owl.carousel.min.js"></script>
  <script src="../CSS_JS_IMG/js/main.js"></script>
    <script src='https://www.google.com/recaptcha/api.js'></script>
</html>
