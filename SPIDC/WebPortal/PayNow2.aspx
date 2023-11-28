<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="PayNow2.aspx.vb" Inherits="SPIDC.PayNow2" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
         #snackbar {
            visibility: hidden;
            max-width: 300px;
            margin-left: -125px;
            background-color: #333;
            color: #fff;
            text-align: center;
            border-radius: 2px;
            padding: 10px;
            position: fixed;
            z-index: 1;
            left: 50%;
            top: 30px;
            font-size: 17px;
        }

            #snackbar.show {
                visibility: visible;
                -webkit-animation: fadein 0.5s, fadeout 0.5s 3s;
                animation: fadein 0.5s, fadeout 0.5s 3s;
            }
    </style>
     <div id="snackbar" style="z-index: 1200;">Some text some message..</div>
    <div class="container">
        <div class="row">
            <div class="col-lg-7 mx-auto">
                <h5 class="m-2 font-weight-bold text-primary">Online Payment</h5>
                <div class="card card-signin mb-5">
                    <div class="card-body">

                        <div class="row">
                            <div style="display: none;">
                                <input type="text" runat="server" id="txt_LName" class="form-control" readonly />
                                <input type="text" runat="server" id="txt_Fname" class="form-control" readonly />
                                <input type="text" runat="server" id="txt_Mname" class="form-control" readonly />
                                <input type="text" runat="server" id="txt_Suffix" class="form-control" readonly />
                                <input type="text" runat="server" id="txt_Email" class="form-control" readonly />
                                <input type="text" runat="server" id="txt_BillingValidityDate" class="form-control" readonly />
                                <input type="text" runat="server" id="txt_URL_Origin" class="form-control" readonly />
                            </div>


                            <div class=" form-group  col-lg-6">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Payment Reference No.</span></span>
                                </label>
                                <input type="text" runat="server" id="txt_SPIDCREFNO" class="form-control" readonly />
                            </div>
                            <div class=" form-group  col-lg-6" >
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Transaction Type</span></span>
                                </label>
                                <input type="text" runat="server" id="txt_TransactionType" class="form-control" readonly />
                            </div>
                            <div class=" form-group  col-lg-12">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Account Number</span></span>
                                </label>
                                <input type="text" runat="server" id="txt_ACCTNO" class="form-control" readonly />
                            </div>                            

                            <div class=" form-group  col-lg-12" style="background-color:#257CFC;padding-bottom:0.5em;padding-top:0.5em;">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Payment Options</span></span>
                                </label>
                              
                                  <asp:DropDownList ID="cmb_PaymentOptions" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Gateway_Changed" runat="server">
                                        </asp:DropDownList>
                                  </div>

                            <div class=" form-group  col-lg-12">
                                <table class="col-lg-12" style="font-size: small">
                                    <tr>
                                        <td style="padding: 1vh">Convenience Fee</td>
                                        <td style="text-align: right">₱ &nbsp<label id="lbl_SPIDCFEE" runat="server">0.00</label>
                                            &nbsp</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 1vh">Gateway Fee</td>
                                        <td style="text-align: right">₱ &nbsp<label id="lbl_OtherFee" runat="server">0.00</label>
                                            &nbsp</td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 1vh">Billing Amount</td>
                                        <td style="text-align: right">₱ &nbsp<label id="lbl_RawAmount" runat="server">0.00</label>
                                            &nbsp</td>
                                    </tr>
                                    <tr style="border-top: solid 3px black; border-bottom: solid 3px black">
                                        <td style="padding: 1vh">Total Amount to Pay</td>
                                        <td style="text-align: right;font-weight:bolder;">₱ &nbsp<label id="lbl_TotalAmount" runat="server">0.00</label>
                                            &nbsp</td>
                                    </tr>
                                </table>
                            </div>

                            <div class="w3-panel w3-pale-yellow" style="padding: 1vh; font-size: small">
                                <i>Please be advised that some Payment Options may require additional fees upon payment.</i>
                                <i>&nbsp Gateway Fees are not collected by the LGU. For this reason, Gateway Fees will not show up in your Official Receipt </i>
                            </div>


                            <input type="button" runat="server" name="btn_Paynow" class="btn btn-primary col-lg-12" id="btn_Paynow" value="Proceed" />


                            <input type="hidden" runat="server" id="hdnErr" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
   

    <script> 
        
        //11/06/2023
        //Prevent the back button in browser
        function preventBack() {
            window.history.forward();
        }
        setTimeout("preventBack()", 0);
        window.onunload = function () {
            null;
        };
        //End Prevent the back button in browser

        function ShowSnackBar(color, msg) {
            var x = document.getElementById("snackbar");
            x.style.backgroundColor = color;
            x.innerText = msg;
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }    
    </script>
</asp:Content>
