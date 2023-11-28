<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Base64.aspx.vb" Inherits="SPIDC.Base64" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<input id="submitButton" type="button" value="Submit" />
  
    <script>
     //   var encode = btoa('pk-Z0OSzLvIcOI2UIvDhdTGVVfRSSeiGStnceqwUE7n0Ah:');      
      //  var decode = atob('cGstWjBPU3pMdkljT0kyVUl2RGhkVEdWVmZSU1NlaUdTdG5jZXF3VUU3bjBBaDo=');
        //https://pg-sandbox.paymaya.com/payments/v1/payment-tokens
        //https://pg-sandbox.paymaya.com/checkout/v1/checkouts

        $('#submitButton').on('click', function () {
            $.ajax({
                type: "POST",
                url: "https://pg-sandbox.paymaya.com/payments/v1/payment-tokens",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader('Content-type', 'application/json');
                    xhr.setRequestHeader('Authorization', 'Basic cGstWjBPU3pMdkljT0kyVUl2RGhkVEdWVmZSU1NlaUdTdG5jZXF3VUU3bjBBaDo=');
                },
                success: function (result) {
                    //set your variable to the result 
                },
                error: function (result) {
                    //handle the error 
                }
            });
        });

    </script>
</body>
</html>
