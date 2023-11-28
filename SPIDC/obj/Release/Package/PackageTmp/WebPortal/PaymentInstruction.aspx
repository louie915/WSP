<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="PaymentInstruction.aspx.vb" Inherits="SPIDC.PaymentInstruction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
    
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
  background-color: #5373DB;
  color: white;
}
</style>
    <center>
         <div class="form-group col-md-6">
           
               <div class="w3-panel  w3-pale-blue">              
                <p>Please complete your LandBank Payment using the following details:</p>
              </div> 
              <br />

           <table id="customers">
                <tr>
                    <th colspan="2"><center>Payment Details</center> </th>                    
                </tr>
                <tr>
                    <td>Transaction Type</td>
                    <td runat="server" id="td_TransactionType"></td>
                </tr>
                <tr>
                    <td>Amount</td>
                    <td runat="server" id="td_Amount"></td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td runat="server" id="td_Description"></td>
                </tr>
                <tr>
                    <td>Tax Declaration Number</td>
                    <td runat="server" id="td_AssessmentNo"></td>
                </tr>
                <tr>
                    <td>Online ID</td>
                    <td runat="server" id="td_OnlineID"></td>
                </tr>
            </table>    
           
           </div>      
    </center>
    
</asp:Content>

