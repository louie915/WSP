<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="PaymentPostBack.aspx.vb" Inherits="SPIDC.PaymentPostBack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        document.getElementById("_oLabelMasterCard").style.display = "none";
    </script>
    <div class="" style="width:100%; z-index:-1;margin-top:10px">
  <ul class="list-unstyled multi-steps">
  <li runat="server" id="txtInitial">Start</li>   
    <li >Payment</li>
    <li >Complete</li>
      
  </ul>
</div>
    <div class="form-row form">
        <div class="col-sm-3"></div>
        <div class="col-sm-6 form-group">
            <br />
            <div class="card shadow">
                <div class="card-header" align="center">
                    <h5 class="m-0 font-weight-bold text-primary" runat="server" id="h5">Thank You - Payment Complete</h5>
                </div>
               <div class="card-body">
<div class="row">
<div class="col-sm-12 form-group" align="center">
<br />
<i class="fas fa-check-circle text-success" style="font-size:80px;"></i>
</div>
<div class="col-sm-12 form-group" align="center" runat="server" id="div_OLPayment">
<table>
<tr>
<td><label class="m-0 font-weight-bold text-primary" id="BIN_ASSESSNO" runat="server">Account Number</label></td>
<td><label class="h5 m-0 font-weight-bold" runat="server" id="_oLabelacctID">---</label></td>
</tr>

<tr>
<td><label class="m-0 font-weight-bold text-primary">Transaction Number</label></td>
<td> <label class="h5 m-0 font-weight-bold" runat="server" id="_oLabelTransactionNumber"></label></td>
</tr>

<tr>
<td><label class="m-0 font-weight-bold text-primary">Transaction Type</label></td>
<td> <label class="h5 m-0 font-weight-bold" runat="server" id="_oLabelTransactionType"></label></td>
</tr>

<tr>
<td><label class="m-0 font-weight-bold text-primary" style="display:none">Tax Declaration Number</label></td>
<td> <label class="h5 m-0 font-weight-bold" runat="server" id="_oLabelTDN" style="display:none"></label></td>
</tr>

<tr>
<td><label class="m-0 font-weight-bold text-primary">Period Covered</label></td>
<td> <label class="h5 m-0 font-weight-bold" runat="server" id="_oLabelPeriodCovered"></label></td>
</tr>

<tr>
<td><label class="m-0 font-weight-bold text-primary">Date/Time</label></td>
<td><label class="h5 m-0 font-weight-bold" runat="server" id="_oLabelDateTime"></label></td>
</tr>

<tr>
<td><label class="m-0 font-weight-bold text-primary" runat="server" id="LBLAMOUNT">Amount Paid:</label></td>
<td> <label class="h5 m-0 font-weight-bold" runat="server" id="_oLabelAmount"></label></td>
</tr>

</table>    
    <br><br>
<label class="h5 m-0 font-weight-bold" runat="server" id="LBLnOTE"></label>
<br><br>
    

 <label class="m-0 font-weight-light" style="background-color:green;color:white">&nbsp Please check your Transaction History or <b><strong>Email for the record of this transaction &nbsp</strong></b></label>
        
                                           
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-3"></div>
    </div>
        </div>
</asp:Content>