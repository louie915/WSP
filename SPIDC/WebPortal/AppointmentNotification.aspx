<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AppointmentNotification.aspx.vb" Inherits="SPIDC.AppointmentNotification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS_JS_IMG/css/newcss/CssMain.css" rel="stylesheet" />
<link href="../CSS_JS_IMG/css/newcss/sb-admin-2.css" rel="stylesheet" />
<script src="../CSS_JS_IMG/vendor/jquery/jquery.min.js"></script>
        <script src="../CSS_JS_IMG/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <script src="../CSS_JS_IMG/vendor/jquery-easing/jquery.easing.min.js"></script>
        <script src="../CSS_JS_IMG/js/newjs/sb-admin-2.min.js"></script>
</head>
<body>

    <script>
        function startTimer(duration, display) {
            var timer = duration, minutes, seconds;
            var end = setInterval(function () {
                minutes = parseInt(timer / 60, 10)
                seconds = parseInt(timer % 60, 10);

                minutes = minutes < 10 ?  + minutes : minutes;
                seconds = seconds < 10 ? + seconds : seconds;

                display.textContent = seconds;

                if (--timer < 0) {
                    window.location = "account.aspx";
                    clearInterval(end);
                }
            }, 1000);
        }

        window.onload = function () {
            var fiveMinutes = 5,
                display = document.querySelector('#time');
            startTimer(fiveMinutes, display);
        };
</script>


    <div class="d-flex justify-content-center ">
<div class="card m-5 shadow" style="width:400px;height:600px">

  <div class="card-body">
    <h4 class="card-title">Appointment Notification</h4>
    <p class="card-text">Appointment Request has been submitted, you will be notified via email once we verified your request.</p>

      <div>You will be redirected to Main Page in <span id="time">5</span> ...</div>

    </div>
</div>
        </div> 

</body>
</html>
