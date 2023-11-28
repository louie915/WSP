<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="BPOtherTransaction.aspx.vb" Inherits="SPIDC.BPOtherTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
  
    <div class=" p-2"><h5 class="m-2 font-weight-bold text-primary">Other Transactions</h5></div>
    <div class="form-row form">
        
        
        <%--<div class="col-sm-12">
            <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle "  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:TemplateField HeaderText="Bus. ID Number">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("Bus. ID Number")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bus. Owner/Manager">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("Bus. Owner/Manager")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Business Name">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("Business Name")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Business Address">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("Business Address")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("Category")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action 1">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelBusAction1" runat="server" Text='<%# Eval("Action 1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action 2">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelBusAction2" runat="server" Text='<%# Eval("Action 2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action 3">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelBusAction3" runat="server" Text='<%# Eval("Action 3")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>--%>
        <div class="col-sm-12">

            <div class="form-row form">
            <div class="form-group mx-4 my-2">
                <div>

                    <label class="text-capitalize font-weight-bold text-primary">
                        Bus. ID Number: &nbsp
                            <br>
                        <asp:Label ID="_oLblBusID" runat="server" Text="" />
                    </label>

                </div>
            </div>

            <div class="form-group mx-4 my-2">
                <div>

                    <label class="text-capitalize font-weight-bold text-primary">
                        Bus. Owner/Manager: &nbsp
                            <br>
                        <asp:Label ID="_oLblBusOwner" runat="server" Text="" />
                    </label>

                </div>
            </div>

            <div class="form-group mx-4 my-2">
                <div>


                    <label class="text-capitalize font-weight-bold text-primary">
                        Business Name: &nbsp
                            <br>
                        <asp:Label ID="_oLblBusName" runat="server" Text="" />
                    </label>

                </div>
            </div>


            <div class="form-group mx-4 my-2">
                <div>

                    <label class="text-capitalize font-weight-bold text-primary">
                        Business Address: &nbsp

                            <br>
                        <asp:Label ID="_oLblBusAddress" runat="server" Text="" />
                    </label>

                </div>
            </div>


                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Business Line: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusCategory" runat="server" Text="" />
                        </label>
                        
                    </div>
                </div>



            <div class="form-group mx-4 my-2">
                <div>

                    <label class="text-capitalize font-weight-bold text-primary">
                        Category: &nbsp
                            <br>
                        <asp:Label ID="_oLblBusCategory1" runat="server" Text="" />
                    </label>

                </div>
            </div>

        </div>
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
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioCertificateofDelinquency" type="radio" value="CertificateofDelinquency" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioCertificateofDelinquency" style="opacity: 100; font-size: 16px;">
                                    <span><strong>Certificate of Delinquency</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioCertificateOfTransferOfOwnership" type="radio" value="CertificateOfTransferOfOwnership" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioCertificateOfTransferOfOwnership" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Certificate of Transfer of Ownership</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioCertificateOfExistingRecords" type="radio" value="CertificateOfExistingRecords" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioCertificateOfExistingRecords" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Certificate of Existing Records</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioApplicationforBusinessRetirement" type="radio" value="ApplicationforBusinessRetirement" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioApplicationforBusinessRetirement" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Application for Business Retirement</strong></span>
                                </label>
                            </div>
                            <br />
                        </div>
                        <div class="col-sm-5">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">For Appointment:</p>
                            <br />
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioAdditionalLineOfBusiness" type="radio" value="Additional Line of Business" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioAdditionalLineOfBusiness" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Additional Line of Business</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioChangeOwnerAddress" type="radio" value="Change Owner Address" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioChangeOwnerAddress" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Change Owner Address</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioChangeUpdateContactInformations" type="radio" value="Change/Update Contact Informations" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioChangeUpdateContactInformations" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Change/Update Contact Informations</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioBusinessRetirement" type="radio" value="Business Retirement" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioBusinessRetirement" style="color: gray; opacity: 100; font-size: 16px">
                                    <span><strong>Business Retirement</strong></span>
                                </label>
                            </div>
                            <div class="custom-control custom-radio mb-3" style="display:none;">
                                <input name="_oRadioTransactions" class="custom-control-input" id="_oRadioPostPayment" type="radio" value="RPTOTC.aspx" onclick="radioSelect(this);" />
                                <label class="custom-control-label" for="_oRadioPostPayment" style="color: gray; opacity: 100; font-size: 16px;">
                                    <span><strong>Payment Made Over-the-Counter/7-11/etc.</strong></span>
                                </label>
                            </div>
                        </div>
                        <div class="col-sm-12" align="center" style="display:none;">
                            <br />
                            <a class="btn btn-link text-sm font-weight-bold text-primary text-uppercase mb-1 h5" href="#" data-toggle="modal" data-target="#OTCModal">Payment Made Over-the-Counter/7-11/etc.</a>
                            <br />
                            <br />
                        </div>
                        <div class="col-md-12 row mx-auto d-flex justify-content-center mb-2">
                            <a runat="server" href="Account.aspx" class="btn btn-primary m-1 btn-sm" id="_oBtnCancel">
                                <span class="text">Cancel</span>                                
                            </a>                                                  
                            <a runat="server" href="#" class="btn btn-success btn-icon-split m-1 btn-sm" id="_oBtnNext">
                                <span class="text">Next</span>
                                <span class="icon text-white-50">
                                    <i class="fas fa-arrow-alt-circle-right mt-1"></i>
                                </span>
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