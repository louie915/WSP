<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestGcash.aspx.vb" Inherits="SPIDC.TestGcash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
#customers {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#customers td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
}

#customers tr:nth-child(even){background-color: #f2f2f2;}

#customers tr:hover {background-color: #ddd;}

#customers th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #04AA6D;
  color: white;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divImportPEM" style="border:1px solid black;">
              <table id="customers">
                   <tr>                   
                   <th>Private Key</th>
                   <th>Message</th>
               </tr>
                <tr>                    
                    <td><textarea id="td_PrivateKey0" runat="server" rows="15" cols="50"></textarea></td>
                    <td><textarea id="td_Message0" runat="server" rows="15" cols="50"></textarea></td>
                </tr>
                <tr style="text-align:center">
                    <td colspan="2"><input type="button" runat="server" id="btnProcess" value="Import, Sign and Verify"/> </td>
                </tr>
                  <tr>
                      <td colspan="2"><textarea runat="server" id="td_Result0" rows="50" cols="110"></textarea></td>
                  </tr>
            </table>
        </div>


        <div id="divGenerateKey" style="border:1px solid black;">
          Generate Keypair
            <table id="customers">
               <tr>
                   <th>Public Key</th>
                   <th>Private Key</th>
               </tr>
                <tr>                    
                    <td><textarea id="td_PublicKey" runat="server" rows="15" cols="50"></textarea></td>
                    <td><textarea id="td_PrivateKey" runat="server" rows="15" cols="50"></textarea></td>
                </tr>
                <tr style="text-align:center">
                    <td colspan="2"><input type="button" runat="server" id="btnGenerateKey" value="Generate Keypair"/> </td>
                </tr>
            </table>
        </div>
        <br /><br />

    <div id="divSignMessage"  style="border:1px solid black;">    
        Sign Message
         <table id="customers">
               <tr>
                   <th>Private Key</th>
                   <th>Message to Sign</th>
               </tr>
                <tr>                    
                    <td><textarea id="td_PrivateKey2" runat="server" rows="15" cols="50"></textarea></td>
                    <td><textarea id="td_Message" runat="server" rows="15" cols="50"></textarea></td>
                </tr>
                <tr style="text-align:center">
                    <td colspan="2"><input type="button" runat="server" id="btnSign" value="Sign Message"/> </td>
              
                    </tr>
             <tr>
                 <td colspan="2"><textarea runat="server" rows="4" cols="110" id="td_SignedMessage" readonly placeholder="Signed Message will be displayed here.."> </textarea></td>
             </tr>
            </table>
    </div>
           <br /><br />

    <div id="divVerifySignedMessage"  style="border:1px solid black;">    
        Verify Signed Message
         <table id="customers">
               <tr>
                   <th>Public Key</th>
                   <th>Original Message</th>
                   <th>Signed Message</th>
               </tr>
                <tr>                    
                    <td><textarea id="td_PublicKey2" runat="server" rows="15" cols="30"></textarea></td>
                    <td><textarea id="td_Message2" runat="server" rows="15" cols="30"></textarea></td>
                    <td><textarea id="td_SignedMessage2" runat="server" rows="15" cols="30"></textarea></td>
                </tr>
                <tr style="text-align:center">
                    <td colspan="3"><input type="button" runat="server" id="btnVerify" value="Verify Signed Message"/> </td>
              
                    </tr>
             <tr>
                 <td colspan="3"><textarea runat="server" rows="4" cols="110" id="td_VerificationResult" readonly placeholder="Verification Result.."> </textarea></td>
             </tr>
            </table>
    </div>

        <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />   <br />
    </form>    

</body>
</html>
