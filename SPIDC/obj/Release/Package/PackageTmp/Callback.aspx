<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Callback.aspx.vb" Inherits="SPIDC.Callback" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html>
<head>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

</head>
<body>
<form id='form1' action='https://222.127.109.48/epp20200915/api2-status.php' method='post' >
<table>
	<tr>
	<td>MerchantCode</td><td><input  type='text' name='MerchantCode' value='2020060003'></td>
	</tr>
				<tr>
					<td>MerchantRefNo</td>
					<td>
						<input  type='text' name='MerchantRefNo' value='BP210125-00003'>
					</td>
				</tr>
				<tr>
					<td>Hash</td>
					<td>
		<input  type='text' name='Hash' value='891bbc3c7f89539de2af43ebc3a8be76'>
					</td>
				</tr>
			</table>
	<input type='submit'/>
		</form>



 <button>Get External Content</button>

 <script>
     $("button").click(function () {
         $.ajax({
             type: "POST",
             headers: {
                 'Accept': 'application/json'
             },
             url: "https://222.127.109.48/epp20200915/api2-status.php",
             data: $("#form1").serialize(),
             complete: function (data) {                   
                 console.log(data.responseText);
              
               
             }

         })
     });
</script>
</body>
</html>
