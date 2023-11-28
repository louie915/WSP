<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="GRNotif.aspx.vb" Inherits="SPIDC.GRNotif" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS_JS_IMG/css/newcss/TableResponsiveMB.css" rel="stylesheet" />
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
        <h5 class="m-1 font-weight-bold text-primary">GR Notification</h5>
    </div>
    <div class="row justify-content-center align-items-center form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
            <div class="card shadow">
                <div class="">
                    <div class=" m-2">                   
                        <input type="text" runat="server" id="txtTestEmail" placeholder="Test EMail" />
                        <input type="text" runat="server" id="txtCount" placeholder="Count" value="0" />
                        <input type="button" runat="server" id="btnSendEmail" class="btn btn-primary" value="Send Email Notification"/>
                        <br />
                        <label runat="server" id="lbl_RecCount"></label>
                         <textarea runat="server" id="txtSkipTDN"></textarea>
                        <textarea runat="server" id="txterr"></textarea>
                        <asp:GridView ID="GVGR" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_GVGR"
                            PageSize="50">
                            <PagerSettings Mode="NumericFirstLast"
                                FirstPageText="First"
                                LastPageText="Last"
                                PageButtonCount="3"
                                Position="Bottom"
                                Visible="true" />
                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />

                            <Columns>
                                <asp:TemplateField HeaderText="Email Address" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="Email2" runat="server" Text='<%# Eval("Email2").ToString()%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Old TDN" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="Old_TDN" runat="server" Text='<%# Eval("Old_TDN").ToString()%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="New TDN" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="New_TDN" runat="server" Text='<%# Eval("New_TDN").ToString()%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />                      <br />
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
