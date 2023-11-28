<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UnderMaintenance.aspx.vb" Inherits="SPIDC.UnderMaintenance" %>

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
<body style="background-image: url('/CSS_JS_IMG/img/Construction/mpallpic.png');background-repeat: no-repeat;
  background-size: 100%;background-color:#c55a11">
    <form id="form1" runat="server">
    <div class="row d-flex align-content-center justify-content-center align-items-center">           
        <div class="row align-content-center justify-content-center align-items-center d-flex col-11 here">   
            <%--<a>sa</a>--%>
            <span style="font-size:100px">&#9888;</span>
            <div class="p-2"><a class="m-2 font-weight-bold text-white f-1 h4">Page Under Construction</a><h5 class="m-2 font-weight-bold text-white f-2">We are currently working on this page.</h5></div>            
        </div>    
        <div class="align-content-center justify-content-center align-items-center d-flex col-11">   
            <%--<img src="../CSS_JS_IMG/img/Construction/cworker.png" style="height:250px"/>
            <img src="../CSS_JS_IMG/img/Construction/cbarrier.png" style="height:150px"/>
            <img src="../CSS_JS_IMG/img/Construction/ccone.png" style="height:80px"/>    --%>     <%--<img src="../CSS_JS_IMG/img/Construction/mpallpic.png" />--%>
        </div> 
        </div>         
        
        <style>
/*a:after {
  content: ' \2713';
}*/

            @media only screen and (max-width: 872px), (min-device-width: 200px) and (max-device-width: 760px) {

                .here {
                
                    margin-top:50% !Important;
                
                }
                f-1 {
                    
                    font-size: 1rem !Important;

                }
            
            }


</style>   
    </form>
    <script src="../CSS_JS_IMG/OS-JS-CSS/jquery/jquery.min.js"></script>
        <script src="../CSS_JS_IMG/OS-JS-CSS/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="../CSS_JS_IMG/OS-JS-CSS/jquery-easing/jquery.easing.min.js"></script>
        <%--<script src="../CSS_JS_IMG/js/newjs/sb-admin-2.min.js"></script>--%>
        <script src="../CSS_JS_IMG/OS-JS-CSS/Js/Online-Services.js"></script>
        <%--<script src="../CSS_JS_IMG/OS-JS-CSS/Js/OS-MainPage.js"></script>--%>
</body>
</html>
