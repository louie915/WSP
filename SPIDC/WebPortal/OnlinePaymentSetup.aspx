<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="OnlinePaymentSetup.aspx.vb" Inherits="SPIDC.OnlinePaymentSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        //SNACKBAR - Welcome       
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

    <div class=" p-1">
        <h5 class="m-1 font-weight-bold text-primary">Online Payment Setup</h5>
    </div>
    <div class="row justify-content-center align-items-center form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
            <div class="card shadow">
                <div class="">
                    <div class=" m-2">
                        <asp:GridView ID="GridView_Gateway" runat="server" CssClass="mgrid" AllowSorting="true"
                            AutoGenerateColumns="FALSE" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AlternatingRowStyle-BackColor="">

                            <Columns>
                                <asp:TemplateField HeaderText="CODE" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="CODE" runat="server" Text='<%# Eval("CODE")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="GATEWAY NAME" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="GATEWAYNAME" runat="server" Text='<%# Eval("GATEWAYNAME")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Gateway Fee" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                        <asp:Label ID="GatewayFee" runat="server" Text='<%# Eval("GatewayFee")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="STATUS" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="STATUS" Style="font-weight: bold" runat="server" Text='<%# Eval("STATUS2")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" class="btn btn-primary col-lg-12"
                                              onclick="do_select('<%# Eval("CODE")%>','<%# Eval("GATEWAYNAME")%>','<%# Eval("GatewayFee")%>','<%# Eval("STATUS2")%>')"
                                            data-toggle="modal" data-dismiss="modal" data-target="#Modal_Modify" data-ticket-type="standard-access"
                                          >Modify</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>




                    </div>
                </div>
            </div>
        </div>

    </div>

    <!-- Modal Modify Form -->
    <div id="Modal_Modify" class="modal  fade">
        <div class="modal-dialog" style="min-width: 30vh; max-width: 50vh" role="document">
            <div class="modal-content ">
                <div class="modal-header">

                    <h4 class="modal-title">Modify Gateway</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body form-row">
                    <div class="form-group col-md-12 card shadow-lg" style="padding: 20px;">

                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Gateway Name</span></span>
                            </label>
                            <input required type="text" class="form-control" runat="server" name="txtCode" id="txtGw_Name" />
                        </div>
                        <br />
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Gateway Fee (Just add % for Percentage Fee, ex: 1.5%)</span></span>
                            </label>
                            <input required type="text" class="form-control" name="txtGw_Fee" runat="server" id="txtGw_Fee" />
                        </div>
                         <br />
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Gateway Status</span></span>
                            </label>                           
                            <select class="form-control" runat="server" id="cmbStatus">
                                <option value="DISABLED">Disabled</option>
                                <option value="ENABLED">Enabled</option>
                            </select>
                            


                        </div>
                         <br />
                        <input type="button" class="btn btn-primary form-control" runat="server" id="btnSave" value="Save"/>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- /.modal -->

    <input type="hidden" runat="server" id="hdnCode"/>
    <script>
        function do_select(GW_Code,GW_Name, GW_Fee, GW_Status) {
            document.getElementById('<%= hdnCode.ClientID%>').value = GW_Code;
            document.getElementById('<%= txtGw_Name.ClientID%>').value = GW_Name;
            document.getElementById('<%= txtGw_Fee.ClientID%>').value = GW_Fee;
            document.getElementById('<%= cmbStatus.ClientID%>').value = GW_Status;
        }

    </script>
</asp:Content>
