<%@ Page Language="vb" EnableEventValidation="true" AutoEventWireup="false" CodeBehind="LBP_EPS.aspx.vb" 
    Inherits="SPIDC.LBP_EPS" %>

<!DOCTYPE html>
<html>
    <head>
<style>
#Params {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#Params td, #Params th {
  border: 1px solid #ddd;
  padding: 8px;
}

#Params tr:nth-child(even){background-color: #f2f2f2;}

#Params tr:hover {background-color: #ddd;}

#Params th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #04AA6D;
  color: white;
}
input[type=text], select {
  width: 100%;
  padding: 12px 20px;
  margin: 8px 0;
  display: inline-block;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}
input[type=button] {
  width: 100%;
  background-color: #4CAF50;
  color: white;
  padding: 14px 20px;
  margin: 8px 0;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

input[type=button]:hover {
  background-color: #45a049;
}

div {
  border-radius: 5px;
  background-color: #f2f2f2;
  padding: 20px;
}

</style>
</head>
<body>
   
    <form runat="server" >
         <asp:ScriptManager runat="server"></asp:ScriptManager>
       <select id="cmb_Transaction" onclick="do_select(this.value)" >
           <option value="PerformEcho">Perform Echo</option>
           <option value="PostPayments">Post Payments</option>    
       </select>           

        <div id="div_PerformEcho">
             <table id="Params">
                 <tr>
    <th>Parameter</th>
    <th>Value</th>

  </tr>

            <tr>
                <td>
                    Input
                </td>
                <td>
                    <input type="text" id="PerformEcho_Input" runat="server" placeholder="Input"/>
                </td>
            </tr>
        </table>
        </div>

  <div id="div_PostPayments" style="display:none">
  <table id="Params">
                 <tr>
    <th>Parameter</th>
    <th>Value</th>

  </tr>
            <tr>
                <td>
                    trxnamt
                </td>
                <td>
                    <input type="text" id="PostPayments_trxnamt" runat="server" placeholder="0.00"/>
                </td>
            </tr>
      <tr>
                <td>
                    merchantcode
                </td>
                <td>                   
                      <select id="PostPayments_merchantcode" runat="server">
                        <option value="0465">MANOLO - TEST</option>
                        <option value="0322">CSJDM - TEST</option>
                    </select>
                </td>
            </tr>

         <tr>
                <td>
                    bankcode
                </td>
                <td>
                    <input type="text" id="PostPayments_bankcode" runat="server" value="B000" readonly />
                </td>
            </tr>

        <tr>
                <td>
                    trxndetails
                </td>
                <td>
                    <select id="PostPayments_trxndetails" runat="server">
                        <option value="Real Property Tax">Real Property Tax</option>
                        <option value="Business Permit">Business Permit</option>
                    </select>
                </td>
            </tr>

        <tr>
                <td>
                    trandetail1
                </td>
                <td>
                   <input type="text" id="PostPayments_trandetail1" runat="server"  placeholder="Online ID" />
             
                </td>
            </tr>

      <tr>
                <td>
                    trandetail2
                </td>
                <td>
                   <input type="text" id="PostPayments_trandetail2" runat="server"  placeholder="Payor Name" />
             
                </td>
            </tr>

      <tr>
                <td>
                    trandetail3
                </td>
                <td>
                   <input type="text" id="PostPayments_trandetail3" runat="server"  placeholder="TDN/BIN" />
             
                </td>
            </tr>

       <tr>
                <td>
                    trandetail4
                </td>
                <td>
                   <input type="text" id="PostPayments_trandetail4" runat="server"  placeholder="Email Address" />
             
                </td>
            </tr>

        <tr>
                <td>
                    trandetail5
                </td>
                <td>
                   <input type="text" id="PostPayments_trandetail5" runat="server"  placeholder="Billing Validity Date" />
             
                </td>
            </tr>

       <tr>
                <td>
                    username
                </td>
                <td>
                   <input type="text" id="PostPayments_username" runat="server" value="username"  placeholder="username" />
             
                </td>
            </tr>

        <tr>
                <td>
                    password
                </td>
                <td>
                   <input type="text" id="PostPayments_password" runat="server" value="password"  placeholder="password" />
             
                </td>
            </tr>
        <tr>
                <td>
                    secretKey
                </td>
                <td>
                   <input type="text" id="PostPayments_secretKey" runat="server" value="N\HWJUKFHQX" />
             
                </td>
            </tr>

    


    </table>
    </div>

    <input type="button" id="btn_Submit" runat="server" value="Submit"/>
    <div id="txt_Result" runat="server" >

    </div>

 
   </form>
    <input type="hidden" runat="server" id="hdn_transaction" />
    <script>
        function do_select(val) {
          
            document.getElementById('<%= hdn_transaction.ClientID%>').value = val;
    

            switch (val) {
                case "PerformEcho":
                    document.getElementById('div_PerformEcho').style.display = 'block';
                    document.getElementById('div_PostPayments').style.display = 'none';
                    break;
                case "PostPayments":
                    document.getElementById('div_PerformEcho').style.display = 'none';
                    document.getElementById('div_PostPayments').style.display = 'block';
                    break;              
            }
        }
    </script>
</body>
</html>