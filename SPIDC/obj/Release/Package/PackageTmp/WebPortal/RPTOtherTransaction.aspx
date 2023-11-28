<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="RPTOtherTransaction.aspx.vb" Inherits="SPIDC.RPTOtherTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" p-2"><h5 class="m-2 font-weight-bold text-primary">Other Transactions</h5></div>
    <div class="form-row form">
        <div class="col-sm-12">
            <div class="form-row form" >
                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Tax Declaration Number: &nbsp
                                <br>
                            <asp:Label ID="_oLblTDN" runat="server" Text="" />
                        </label>

                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Property ID Number: &nbsp
                                <br>
                            <asp:Label ID="_oLblPIN" runat="server" Text="" />
                        </label>

                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>


                        <label class="text-capitalize font-weight-bold text-primary">
                            Kind: &nbsp
                                <br>
                            <asp:Label ID="_oLblKind" runat="server" Text="" />
                        </label>

                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Property Owner: &nbsp
                                <br>
                            <asp:Label ID="_oLblOwner" runat="server" Text="" />
                        </label>

                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Property Location: &nbsp

                                <br>
                            <asp:Label ID="_oLblLocation" runat="server" Text="" />
                        </label>

                    </div>
                </div>

            </div>
        </div>
        <%--<div class="col-sm-12">
            <h4 class="m-0 font-weight-bold text-primary">Other Transactions</h4>
            <br />
        </div>--%>
        <%--<div class="col-sm-12">
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle "  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:TemplateField HeaderText="PIN">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelPIN" runat="server" Text='<%# Eval("PIN")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="TDN">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTDN" runat="server" Text='<%# Eval("TDN")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Declared Owner">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("Declared Owner")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Address of Property">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelAddressOfProperty" runat="server" Text='<%# Eval("Address of Property")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action 1">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelAction1" runat="server" Text='<%# Eval("Action 1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action 2">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelAction2" runat="server" Text='<%# Eval("Action 2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action 3">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelAction3" runat="server" Text='<%# Eval("Action 3")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>--%>
        <div class="col-sm-12">
            <br />
            <br />
            <div class="card">
                <div class="card-header">
                    <h6 class="m-0 font-weight-bold text-primary">Transactions</h6>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-sm-5">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Certifications:</p>
                            <br />
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioCertifiedTrueCopy" type="radio" value="CertifiedTrueCopy" onclick="radioSelect(this);"/>
                                <label class="custom-control-label" for="_oRadioCertifiedTrueCopy" style="opacity: 100; font-size: 16px;">
                                    <span><strong>Certified True Copy</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioLandHoldings" type="radio" value="CertificateOfLandHoldings" onclick="radioSelect(this);"/>
                                <label class="custom-control-label" for="_oRadioLandHoldings" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Certificate of Land Holdings</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioCertificateOfNoImprovement" type="radio" value="CertificateOfNoImprovement" onclick="radioSelect(this);"/>
                                <label class="custom-control-label" for="_oRadioCertificateOfNoImprovement" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Certificate of No Improvement</strong></span>
                                </label>
                            </div>
                            <br />
                        </div>
                        <div class="col-sm-5">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">For Appointment:</p>
                            <br />
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioTransferOfProperty" type="radio" value="Transfer of Property" onclick="radioSelect(this);"/>
                                <label class="custom-control-label" for="_oRadioTransferOfProperty" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Transfer of Property</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioChangeOfInformation" type="radio" value="Change of Information" onclick="radioSelect(this);"/>
                                <label class="custom-control-label" for="_oRadioChangeOfInformation" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Change of Information</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioConsolidation" type="radio" value="Subdivision/Consolidation" onclick="radioSelect(this);"/>
                                <label class="custom-control-label" for="_oRadioConsolidation" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Subdivision/Consolidation</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3" style="display:none;">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioPostPayment" type="radio" value="RPTOTC.aspx" onclick="radioSelect(this);"/>
                                <label class="custom-control-label" for="_oRadioPostPayment" style="color: gray; opacity: 100; font-size: 16px;">
                                    <span><strong>Payment Made Over-the-Counter/7-11/etc.</strong></span>
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12" align="center">
                            <a class="btn btn-link text-sm font-weight-bold text-primary text-uppercase mb-1 h5" href="#" data-toggle="modal" data-target="#OTCModal">Payment Made Over-the-Counter/7-11/etc.</a>
                        </div>
                        <div class="col-sm-12 form-group" align="center">
                            <br />
                            <a runat="server" href="Account.aspx" class="btn btn-primary col-md-1 col-lg-1 m-1 btn-sm" id="_oBtnCancel">
                                <span class="text">Cancel</span>
                            </a>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <a runat="server" href="#" class="btn btn-primary col-md-1 col-lg-1 m-1 btn-sm" id="_oBtnNext">
                                <span class="text">Next</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="OTCModal" tabindex="-1" role="dialog" aria-labelledby="OTCModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-md">
                    <div class="modal-content">
                        <div class="modal-header bg-primary">
                            <i class="fas fa-money-bill-alt text-white float-right" style="font-size: 25px;"></i> &nbsp;&nbsp;
                            <h4 class="modal-title text-white" id="myModalLabel">Payment made Over-the-Counter</h4>
                            <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="form-row form">
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Reference No</p>
                                    <select class="form-control text-center CH-size" id="_oSelectReferenceNo" runat="server">
                                        <option>Select a reference number</option>
                                    </select>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Amount</p>
                                    <label class="text-gray text-capitalize border border-primary form-control CH-size" align="right">0000.00</label>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Payment Channel</p>
                                    <select class="form-control text-center CH-size" id="_oSelectPaymentChannel" runat="server">
                                        <option>Select a payment channel</option>
                                        <option value="7/11">7/11</option>
                                        <option value="Bayad Center">Bayad Center</option>
                                        <option value="Palawan">Palawan</option>
                                    </select>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Official Receipt Number</p>
                                    <input class="form-control CH-size text-center" type="text" id="_oTextOR" name="_oTextOR" placeholder="Enter OR number" runat="server"/>
                                    <br />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary btn-sm" id="_oBtnSubmit" runat="server">Submit</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="radioValue" runat="server"/>
    <script type="text/javascript">
        var radioVal = '';

        function radioSelect(radio) {
            radioVal = radio.value;
            document.getElementById('<%=radioValue.ClientID%>').value = radioVal;
        }
    </script>
        
</asp:Content>