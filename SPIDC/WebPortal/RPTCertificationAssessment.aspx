<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="RPTCertificationAssessment.aspx.vb" Inherits="SPIDC.RPTCertificationAssessment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-row form">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <br />
            <br />
            <h4 class="m-0 font-weight-bold text-primary">Certifications Assessment</h4>
        </div>
        <div class="col-sm-1"></div>
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <div class="card shadow">
                <div class="card-header py-3">
                    <%--<p class="m-0 font-weight-bold text-primary float-right" id="_oLabelTotalAmount" runat="server">Total Amount: 00.00</p>--%>
                    <h6 class="m-0 font-weight-bold text-primary">Assessment</h6>
                    <p class="small" style="font-style: italic">Amount due for the certification</p>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-4" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Account Code</p>
                            <h5 class="m-0 font-weight-bold" id="_oLabelAccountCode" runat="server">1234</h5>
                        </div>
                        <div class="col-sm-4" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Account Description</p>
                            <h5 class="m-0 font-weight-bold" id="_oLabelAccountDesc" runat="server">Desc</h5>
                        </div>
                        <div class="col-sm-4" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Amount</p>
                            <h5 class="m-0 font-weight-bold" id="_oLabelAmount" runat="server">00.00</h5>
                        </div>
                    </div>
                    <asp:GridView ID="GridView1"  runat="server" CssClass="GridViewStyle "  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Account Code">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelAccountCode" runat="server" Text='<%# Eval("Account Code")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account Description">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelAccountDescription" runat="server" Text='<%# Eval("Account Description")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelAmount" runat="server" Text='<%# Eval("Amount")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="card-footer">
                    <div class="row form-group">
                        <idv class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">No. Of Copies</p>
                            <select onchange="selectChange()" class="form-control CH-Size col-xl-2" id="_oSelectNoOfCopies">
                                <option value="1">1</option>
                            </select>
                        </idv>
                        <script>
                            var i;
                            for (i = 2; i < 100; i++) {
                                var x = document.getElementById("_oSelectNoOfCopies");
                                var option = document.createElement("option");
                                option.text = i;
                                x.add(option);
                            }
</script>
                        <div class="col-sm-6" align="center">
                            <label for="_oSelectORDelivery" class="text-xs font-weight-bold text-primary text-uppercase mb-1">Official Receipt Delivery</label>
                            <br />
                            <div class="custom-control custom-radio mb-3 custom-control-inline">
                                <input name="_oRadioReceiptDelivery" class="custom-control-input" id="_oRadioDeliveryPickUp" type="radio" checked/>
                                <label class="custom-control-label radio-inline" for="_oRadioDeliveryPickUp">
                                    <span><strong>Pick-Up</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3 custom-control-inline">
                                <input name="_oRadioReceiptDelivery" class="custom-control-input" id="_oRadioDeliveryDel" type="radio"/>
                                <label class="custom-control-label radio-inline" for="_oRadioDeliveryDel">
                                    <span><strong>Delivery Php 250.00</strong></span>
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12" align="center">
                            <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">Note: </label>
                            &nbsp;
                            <label class="small" style="font-style: italic">• For Delivery Services - Certification shall be delivered with the Official Receipt</label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <label class="small" style="font-style: italic">• For Pick-up - Certifications will be available in 3 working days at the Assessor Office</label>
                        </div>
                        <div class="col-sm-6">
                            <br>
                            <%--<label class="mx-2 text-capitalize font-weight-bold" style="font-size:20px;text-align:right" id="_oLabelTotalAmount" runat="server">Total Amount: 00.00</label>--%>
                            <label class="mx-2 text-capitalize font-weight-bold" style="font-size:20px;text-align:right"><label class="mx-2 my-auto border border-bottom-light rounded-lg" id="_oLabelTotalAmount" style="font-size:25px;" runat="server">Total Amount: 00.00</label></label>
                        </div>
                        <div class="col-sm-6" align="center">
                            <br />
                            <a runat="server" onclick="noOfCop()" href="#" class="btn btn-primary btn-sm btn-icon-split" id="_oBtnProceedtoPayment">
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
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" EnablePageMethods="True" />

    <script type="text/javascript">
        var x = '';
        var total = '';
        var dFee = 250;
        var checkedDF = false;

        document.getElementById("_oSelectNoOfCopies").addEventListener("change", noOfCop);
        document.getElementById("_oRadioDeliveryDel").addEventListener("change", delFee);
        document.getElementById("_oRadioDeliveryPickUp").addEventListener("change", minusDelFee);

        function minusDelFee() {
            var parAmt = document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML
            parAmt = parAmt.substring(13, parAmt.length - 3);
            parAmt = parseInt(parAmt, 10);
            var tot = (parAmt -= dFee);
            document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML = "Total Amount: " + parseFloat(tot).toFixed(2).toLocaleString();
            document.getElementById('<%=totAmount.ClientID%>').value = parseFloat(tot).toFixed(2).toLocaleString();
            checkedDF = false;
            document.getElementById('<%=checkedDelFee.ClientID%>').value = checkedDF;
        }

        function delFee() {
            var parAmt = document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML
            parAmt = parAmt.substring(13, parAmt.length - 3);
            parAmt = parseInt(parAmt, 10);
            var tot = (parAmt += dFee);
            document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML = "Total Amount: " + parseFloat(tot).toFixed(2).toLocaleString();
            document.getElementById('<%=totAmount.ClientID%>').value = parseFloat(tot).toFixed(2).toLocaleString();
            checkedDF = true;
            document.getElementById('<%=checkedDelFee.ClientID%>').value = checkedDF;
        }

        function noOfCop() {
            var amtValue = "<%= _pAmount %>";
            var cop = event.target.value;
            if (cop == undefined) {
                cop = document.getElementById("_oSelectNoOfCopies").value;
                document.getElementById('<%=noOfCop.ClientID%>').value = cop;
            }
            var tot = cop * amtValue;
            var df = document.getElementById("_oRadioDeliveryDel");
            if (df.checked == true) {
                tot = tot + dFee;
            }
            document.getElementById('<%=_oLabelTotalAmount.ClientID%>').innerHTML = "Total Amount: " + parseFloat(tot).toFixed(2).toLocaleString();
            document.getElementById('<%=totAmount.ClientID%>').value = parseFloat(tot).toFixed(2).toLocaleString();
        }

        function selectChange() {
            x = document.getElementById("_oSelectNoOfCopies").value;
            document.getElementById('<%=noOfCop.ClientID%>').value = x;
        }

        function retSelectVal() {
            document.getElementById("_oSelectNoOfCopies").value = document.getElementById('<%=noOfCop.ClientID%>').value
        }
    </script>

</asp:Content>