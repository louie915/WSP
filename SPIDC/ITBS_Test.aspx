<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ITBS_Test.aspx.vb" Inherits="SPIDC.ITBS_Test" %>

<!DOCTYPE html>


<html>

<head>
   <title>Test</title>   
    <style>
        table, th, td {
  border: 1px solid black;
}
    </style>
</head>
    <body>
        <form runat="server">
         <table>
             <tr><td>URL</td>
                 <td>
                     <select runat="server" id="cmbURL" onchange="getSample(this.value)">
                       
                         <option value="/cpps/api/connectivityTest">https://devuat.smartcountry.ph/cpps/api/connectivityTest</option>
                         <option value="/cpps/api/itbsGetTokenKey">https://devuat.smartcountry.ph/cpps/api/itbsGetTokenKey</option>
                         <option value="/cpps/api/itbsGetTransactionStatus">https://devuat.smartcountry.ph/cpps/api/itbsGetTransactionStatus</option>
                     </select>                     
                 </td></tr>

             <tr>
                 <td>Post Data (JSON)</td>
                 <td><textarea runat="server" id="txtJSON" style='width:550px; height:200px' name="txtJSON"></textarea></td>
             </tr>
             <tr>
                 <td colspan="2"><input type="button" style='width:100%' runat="server" id="btnSubmit" value="POST"/></td>
             </tr>

             <tr>
                 <td>Result</td>
                 <td> <div runat="server" id="divResult"></div></td>
             </tr>
         </table>   
           
        </form>

        <script>
            function getSample(val) {
                document.getElementsByName('txtJSON').value = '';              
                switch (val) {                 
                    case '/cpps/api/connectivityTest':                      
                        document.getElementById('<%= txtJSON.ClientID%>').value= '';
                        document.getElementById('<%= txtJSON.ClientID%>').placeholder = 'No Data Required';
                        break;
                    case '/cpps/api/itbsGetTokenKey':
                        var data = '{"apiKey":"4f8b4e8d72f395d3bb0bb8bc2019cb44","mode":"API","sourceTransID":"CTC","amount":5.10,"paymentDesc":"CTC","payorName":"JACOB ISLA","email": "spidctaxpayer1@gmail.com","contactNo":"09000000000","returnURL":"http://online.spidc.com.ph/tarlac/PaymentConfirmation.aspx"}';
                        document.getElementById('<%= txtJSON.ClientID%>').value = JSON.stringify(JSON.parse(data), null, 2);
                        document.getElementById('<%= txtJSON.ClientID%>').placeholder = 'Data Required';
                        break;
                    case '/cpps/api/itbsGetTransactionStatus':
                        var data = '{"apiKey":"4f8b4e8d72f395d3bb0bb8bc2019cb44","transID":14,"mode":"API"}';                        
                        document.getElementById('<%= txtJSON.ClientID%>').value =JSON.stringify(JSON.parse(data), null, 2);
                        document.getElementById('<%= txtJSON.ClientID%>').placeholder = 'Data Required';
                        break;
                }                  
            }
        </script>
</body>
</html>
