<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="RPTOTC.aspx.vb" Inherits="SPIDC.RPTOTC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };
    </script>
    <style>
        select{
            width: 400px; 
            text-align-last:center;
        }
    </style>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <div id="snackbar" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbar"/>           
                </div>
                <div id="snackbargreen" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="form-row form">
        <div class="col-sm-3"></div>
        <div class="col-sm-6" align="center">
            <br />
            <br />
            <br />
            <div class="card shadow">
                <div class="card-header">
                    <h1 class="h5 mb-0 text-gray-800">Post Payment Made Over-the-Counter</h1>
                </div>
                <div class="card-body">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Payment Channel: </p>
                    <select class="form-control text-center CH-size col-xl-9" id="_oSelectPaymentChannel" runat="server">
                        <option>Please select a payment channel</option>
                        <option value="7/11">7/11</option>
                        <option value="Bayad Center">Bayad Center</option>
                        <option value="Palawan">Palawan</option>
                    </select>
                    <br />
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Transaction Number: </p>
                    <input class="form-control CH-size text-center col-xl-9" type="text" id="_oTextTransNo" name="_oTextTransNo" placeholder="Enter transaction number" runat="server"/>
                    <br />
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Amount: </p>
                    <input class="form-control CH-size text-center col-xl-9" type="number" id="_oTextAmount" name="_oTextAmount" runat="server"/>
                    <br />
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Official Receipt Number: </p>
                    <input class="form-control CH-size text-center col-xl-9" type="text" id="_oTextOR" name="_oTextOR" placeholder="Enter OR number" runat="server"/>
                </div>
                <div class="card-footer">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <button runat="server" type="button" class="btn btn-primary btn-sm btn-icon-split" id="_oBtnSubmit">
                        <span class="icon text-white-50">
                            <i class="fas fa-check-circle"></i>
                        </span>
                        <span class="text">Submit</span>
                    </button>
                </div>
            </div>
        </div>
        <div class="col-sm-3">
        </div>
    </div>
     
</asp:Content>