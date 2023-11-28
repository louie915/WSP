<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="certification.aspx.vb" Inherits="SPIDC.certification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script>
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };
    </script>
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
    <div class="form-row justify-content-center align-items-center form mb-0">
        <div class="col-sm-8">
            <br />
            <br />
            <br />
            <div class="card shadow">
                <div class="card-header">
                    <div class="form-row form">
                        <div class="col-sm-6">
                            <h1 class="h5 mb-0 text-gray-800" id="_oLabelSwitch">Request Certification</h1>
                        </div>
                        <div class="col-sm-6">
                            <div class="custom-control custom-checkbox float-right">
                                <input type="checkbox" class="custom-control-input" id="_oCheckBoxGetCert" value="ticked"/>
                                <label class="custom-control-label font-weight-light text-primary mb-1" for="_oCheckBoxGetCert">I am getting this certification for myself</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="form-row form">
                        <div class="col-sm-6">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Fullname</p>
                            <input runat="server" type="text" class="form-control form-control-user CH-size" id="_oTextFirstName" placeholder="Enter Fullname" required/>
                            <br />
                        </div>
                        <div class="col-sm-6">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Email Address</p>
                            <input runat="server" type="text" class="form-control form-control-user CH-size" id="_oTextEmail" placeholder="Enter Email Address" required/>
                            <br />
                        </div>
                        <div class="col-sm-6">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Gender</p>
                            <select runat="server" class="form-control CH-size" id="oSelectGender">
                                <option>Please select gender</option>
                                <option value="M">Male</option>
                                <option value="F">Female</option>
                            </select>
                            <br />
                        </div>
                        <div class="col-sm-6">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Contact Number</p>
                            <input runat="server" type="text" class="form-control form-control-user CH-size" id="_oTextContactNumber" placeholder="+63000-000-0000" required/>
                            <br />
                        </div>
                        <div class="col-sm-12">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Address</p>
                            <textarea runat="server" class="form-control form-control-user CH-size" id="_oTextAddress" name="_oTextAddress" placeholder="Enter Address" rows="2" required></textarea>
                            <br />
                        </div>
                        <div class="col-sm-7">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Select number of copies (Php 100.00 per copy)</p>
                            <select class="form-control CH-size" onchange="selectChange()" id="_oSelectNumberOfCopies" style="font-size: 13px;">
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                                <option value="6">6</option>
                                <option value="7">7</option>
                                <option value="8">8</option>
                                <option value="9">9</option>
                                <option value="10">10</option>
                            </select>
                            <br />
                        </div>
                        <div class="col-sm-5">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Official Receipt Delivery</p>
                            <div class="custom-control custom-radio mb-3 custom-control-inline">
                                <input name="_oRadioReceiptDelivery" class="custom-control-input" id="_oRadioDeliveryPickUp" type="radio" checked/>
                                <label class="custom-control-label radio-inline" for="_oRadioDeliveryPickUp">
                                    <span><strong>Pick-Up</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3 custom-control-inline">
                                <input name="_oRadioReceiptDelivery" class="custom-control-input" id="_oRadioDeliveryDel" type="radio" />
                                <label class="custom-control-label radio-inline" for="_oRadioDeliveryDel">
                                    <span><strong>Delivery Php 250.00</strong></span>
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <br />
                            <label class="mx-2 text-capitalize font-weight-bold" style="font-size:20px;text-align:right">Total Amount Due:<label class="mx-2 my-auto border border-bottom-light rounded-lg" id="_oLabelTotalAmount" style="font-size:25px;" runat="server">0000.00</label></label>
                        </div>
                        <div class="col-sm-6" align="center">
                            <br />
                            <a runat="server" onclick="enableControls(); noOfCop();" href="#" class="btn btn-primary btn-sm btn-icon-split col-xl-6" id="_oBtnNext">
                                <span class="text">Proceed to Payment</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="amt" runat="server"/>
    <asp:HiddenField ID="noOfCop" runat="server"/>
    <asp:HiddenField ID="totAmount" runat="server"/>
    <asp:HiddenField ID="checkedDelFee" runat="server"/>
    <asp:HiddenField ID="checkSwitch" runat="server" />
    <script>
        var swtch = window.location.search.substr(1);
        var dFee = 250;
        var checkedDF = false;

        if (swtch == 'switch=RPT') {
            document.getElementById('_oLabelSwitch').innerText = 'Request for Certificate of No Real Property';
            document.getElementById('<%=checkSwitch.ClientID%>').value = 'RPT';
        } else if (swtch == 'switch=BP') {
            document.getElementById('_oLabelSwitch').innerText = 'Request for Certificate of No Business';
            document.getElementById('<%=checkSwitch.ClientID%>').value = 'BP';
        }
        
        var a = "<%= pAmount %>";
        a = parseFloat(a).toFixed(2).toLocaleString();
        document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerText = a;

        document.getElementById('_oCheckBoxGetCert').addEventListener("change", chkBox);
        document.getElementById('_oRadioDeliveryDel').addEventListener("change", delFee);
        document.getElementById('_oRadioDeliveryPickUp').addEventListener("change", minusDelFee);
        document.getElementById('_oSelectNumberOfCopies').addEventListener("change", noOfCop);

        function chkBox() {
            var x = document.getElementById('_oCheckBoxGetCert');
            if (x.checked) {
                document.getElementById('<%=_oTextFirstName.ClientID%>').value = "<%= pFName%>";
                document.getElementById('<%=_oTextFirstName.ClientID%>').disabled = true;
                document.getElementById('<%=oSelectGender.ClientID%>').value = "<%= pGender%>";
                document.getElementById('<%=oSelectGender.ClientID%>').disabled = true;
                document.getElementById('<%=_oTextEmail.ClientID%>').value = "<%= pEmail%>";
                document.getElementById('<%=_oTextEmail.ClientID%>').disabled = true;
                document.getElementById('<%=_oTextContactNumber.ClientID%>').value = "<%= pContactNo%>";
                document.getElementById('<%=_oTextContactNumber.ClientID%>').disabled = true;
                document.getElementById('<%=_oTextAddress.ClientID%>').value = "<%= pAddress%>";
                document.getElementById('<%=_oTextAddress.ClientID%>').disabled = true;
            } else {
                document.getElementById('<%=_oTextFirstName.ClientID%>').value = "";
                document.getElementById('<%=_oTextFirstName.ClientID%>').disabled = false;
                document.getElementById('<%=oSelectGender.ClientID%>').value = "Please select gender";
                document.getElementById('<%=oSelectGender.ClientID%>').disabled = false;
                document.getElementById('<%=_oTextEmail.ClientID%>').value = "";
                document.getElementById('<%=_oTextEmail.ClientID%>').disabled = false;
                document.getElementById('<%=_oTextContactNumber.ClientID%>').value = "";
                document.getElementById('<%=_oTextContactNumber.ClientID%>').disabled = false;
                document.getElementById('<%=_oTextAddress.ClientID%>').value = "";
                document.getElementById('<%=_oTextAddress.ClientID%>').disabled = false;
            }
        }

        function enableControls(){
            document.getElementById('<%=_oTextFirstName.ClientID%>').disabled = false;
            document.getElementById('<%=oSelectGender.ClientID%>').disabled = false;
            document.getElementById('<%=_oTextEmail.ClientID%>').disabled = false;
            document.getElementById('<%=_oTextContactNumber.ClientID%>').disabled = false;
            document.getElementById('<%=_oTextAddress.ClientID%>').disabled = false;
        }

        function delFee(){
            var parAmt = document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML;
            parAmt = parseInt(parAmt, 10);
            var tot = (parAmt += dFee);
            document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML = parseFloat(tot).toFixed(2).toLocaleString();
            document.getElementById('<%=totAmount.ClientID%>').value = parseFloat(tot).toFixed(2).toLocaleString();
            checkedDF = true;
            document.getElementById('<%=checkedDelFee.ClientID%>').value = checkedDF;
        }

        function minusDelFee() {
            var parAmt = document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML;
            parAmt = parseInt(parAmt, 10);
            var tot = (parAmt -= dFee);
            document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML = parseFloat(tot).toFixed(2).toLocaleString();
            document.getElementById('<%=totAmount.ClientID%>').value = parseFloat(tot).toFixed(2).toLocaleString();
            checkedDF = false;
            document.getElementById('<%=checkedDelFee.ClientID%>').value = checkedDF;
        }

        function noOfCop() {
            var amtValue = "<%= pAmount %>";
            var cop = event.target.value;
            if (cop == undefined) {
                cop = document.getElementById("_oSelectNumberOfCopies").value;
                document.getElementById('<%=noOfCop.ClientID%>').value = cop;
            }
            var tot = cop * amtValue;
            var df = document.getElementById("_oRadioDeliveryDel");
            if (df.checked == true) {
                tot = tot + dFee;
            }
            document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML = parseFloat(tot).toFixed(2).toLocaleString();
            document.getElementById('<%=totAmount.ClientID%>').value = parseFloat(tot).toFixed(2).toLocaleString();
        }

        function selectChange() {
            x = document.getElementById("_oSelectNumberOfCopies").value;
            document.getElementById('<%=noOfCop.ClientID%>').value = x;
        }
    </script>
 
</asp:Content>