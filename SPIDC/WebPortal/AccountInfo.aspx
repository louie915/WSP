<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="AccountInfo.aspx.vb" Inherits="SPIDC.AccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>
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
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>


    <h5 class="m-2 font-weight-bold text-primary">Account Information</h5>
    <div class="row justify-content-center align-items-center mb-0 m-1">
        <div class="row m-2" style="background-color: white">

            <div class="col-md-6 row " runat="server" id="div_BP_enroll">
                <div class="col-lg-12 m-2 mb-3">
                    <h6 class="m-0 font-weight-bold text-primary">Enroll Business:<span class="text-xs" style="color: red; display: none;" id="invalid">Please complete fields before proceeding</span></h6>

                </div>
                <div class="form-group col">
                    <div>

                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Enter Bin </span></span>

                        </label>
                        <input id="_otxtEnterBusinessBIN" required type="text" class="form-control CH-Size-New" runat="server" />
                        <%--<asp:RequiredFieldValidator runat="server" id="reqName" controltovalidate="_otxtEnterBusinessBIN" errormessage="Please enter your name!" />--%>
                    </div>
                </div>

                <div class="form-group col">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Enter OR No.</span></span>
                        </label>
                        <input id="_otxtEnterBusinessORNo" required type="text" class="form-control CH-Size-New" runat="server" />

                    </div>

                </div>
                <div class="form-group col-md-5">
                    <button name="btnEnroll" id="btnEnroll" type="button" class="btn btn-primary btn-sm col right" runat="server" onclick="BusinessEnrollment('BusinessEnroll','');">Enroll</button>

                </div>

                <i style="font-size: small; color: cornflowerblue;">* Registered Business wanting to apply for renewal or pay their quarterly dues, enroll your business account number(BIN) and latest Official Receipt Number(O.R) for verification
                </i>

            </div>



            <div class="col-md-6 row " runat="server" id="div_RPT_enroll">
                <div class="col-lg-12 m-2 mb-3">
                    <h6 class="m-0 font-weight-bold text-primary">Enroll Property:<span class="text-xs" style="color: red; display: none;" id="invalid1">Please complete fields before proceeding</span></h6>
                </div>
                <div class="form-group col">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Enter TDN </span></span>
                        </label>
                        <input id="_otxtEnterPropTDN" type="text" class="form-control CH-Size-New" required runat="server" />

                    </div>
                </div>
                <div class="form-group col">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Enter OR No.</span></span>
                        </label>
                        <input id="_otxtEnterPropORNo" type="text" class="form-control CH-Size-New" required runat="server" />

                    </div>
                </div>
                <div class="form-group col-md-5">
                    <button name="btnEnrollProp" id="btnEnrollProp" type="button" class="btn btn-primary btn-sm col right" runat="server" onclick="PropertyEnrollment('PropertyEnroll','');">Enroll</button>
                </div>

                <i style="font-size: small; color: cornflowerblue">* Registered / Declared Property(ies) wanting to pay annual & quarterly dues, enroll your Tax Declaration number(TDN) and latest Official Receipt Number(O.R) for verification</i>
            </div>


        </div>

        <div class="card shadow m-2" style="width:100%">
            <%-- Business Permit --%>
              <%--FOR RENEWAL--%>
            <div class="mb-2" runat="server" id="div_BP_Renewal">             
                <a class="nav-link font-weight-bold text-primary" data-toggle="collapse" href="#Pnl_ForRenewal" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('Ico_ForRenewal')">Business Permit Account (for Renewal)<i class="fas fa-minus-circle fa-fw" id="Ico_ForRenewal"></i>
                </a>
                <!-- Dropdown - Messages -->
                <div class="collapse show" id="Pnl_ForRenewal">
                    <asp:GridView ID="GV_ForRenewal" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="TRUE" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_BPR"
                        PageSize="10">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Business ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Bus. Owner/Manager" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("OWNER")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Business Name" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("BUSNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Business Address" HeaderStyle-Width="17%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("BUSADDRESS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Category" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("CATEGORY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <a href="#" onclick="Select('Information','<%# Eval("ACCTNO")%>')" title="Information">Information</a>
                                    &nbsp
                                        <a href="#" style="display: none;" onclick="Select('Other Trans','<%# Eval("ACCTNO")%>')" title="Other Trans">Other Transaction </a>
                                    &nbsp
                                        <a href="#" data-toggle="modal" data-target="#loading" data-ticket-type="standard-access" onclick="Select('Renew','<%# Eval("ACCTNO")%>')" title="Renew">Renew </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>             
                </div>
            </div>
              <%--FOR PAYMENT--%>
            <div class="mb-2" runat="server" id="div_BP_Payment">             
                <a class="nav-link font-weight-bold text-primary" data-toggle="collapse" href="#Pnl_ForPayment" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('Ico_ForPayment')">Business Permit Account (for Payment)<i class="fas fa-minus-circle fa-fw" id="Ico_ForPayment"></i>
                </a>
                <!-- Dropdown - Messages -->
                <div class="collapse show" id="Pnl_ForPayment">
                    <asp:GridView ID="GV_ForPayment" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="TRUE" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_BPP"
                        PageSize="10">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Business ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Bus. Owner/Manager" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("OWNER")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Business Name" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("BUSNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Business Address" HeaderStyle-Width="17%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("BUSADDRESS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Category" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("CATEGORY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" onclick="Select('Information','<%# Eval("ACCTNO")%>')" title="Information">Information</a>
                                        &nbsp
                                        <a href="#" style="display: none;" onclick="Select('Other Trans','<%# Eval("ACCTNO")%>')" title="Other Trans">Other Transaction </a>
                                        &nbsp
                                  <a href="#"  class="btn btn-primary" title="Payment">Payment</a>
                             
                               
                                         </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>             
                </div>
            </div>

              <%--ISSUED--%>
            <div class="mb-2" runat="server" id="div_BP_Issued">             
                <a class="nav-link font-weight-bold text-primary" data-toggle="collapse" href="#Pnl_Issued" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('Ico_Issued')">Business Permit(Issued)<i class="fas fa-minus-circle fa-fw" id="Ico_Issued"></i>
                </a>
                <!-- Dropdown - Messages -->
                <div class="collapse show" id="Pnl_Issued">
                    <asp:GridView ID="GV_Issued" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="TRUE" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_BPI"
                        PageSize="10">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Business ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Bus. Owner/Manager" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("OWNER")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Business Name" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("BUSNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Business Address" HeaderStyle-Width="17%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("BUSADDRESS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Category" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("CATEGORY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" onclick="Select('Information','<%# Eval("ACCTNO")%>')" title="Information">Information</a>
                                        &nbsp
                                        <a href="#" style="display: none;" onclick="Select('Other Trans','<%# Eval("ACCTNO")%>')" title="Other Trans">Other Transaction </a>
                                        &nbsp
                                  <a href="#"  class="btn btn-primary" title="Payment">Payment</a>
                             
                               
                                         </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>             
                </div>
            </div>
        </div>
    </div>

    <script>
        function GridCollapse(val) {
            if (document.getElementById(val).classList.contains("fa-minus-circle")) {
                document.getElementById(val).classList.remove("fa-minus-circle");
                document.getElementById(val).classList.add("fa-plus-circle");
            }
            else {
                document.getElementById(val).classList.remove("fa-plus-circle");
                document.getElementById(val).classList.add("fa-minus-circle");
            }
        }
    </script>
</asp:Content>

