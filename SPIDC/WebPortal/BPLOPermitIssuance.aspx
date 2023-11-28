<%@ Page EnableEventValidation ="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind ="BPLOPermitIssuance.aspx.vb" Inherits="SPIDC.BPLOPermitIssuance" %>

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
       <form id="frmNone"></form>
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
    <div class="row col-lg-12">
        <div class="col-sm-12" align="center">
            <br />
            <h3><label class=" font-weight-bold text-primary mb-1">Business Permit Issuance</label></h3>
        </div>
        <div class="col-sm-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">For Issuance</label>
                </div>
                <div class="card-body">
        
                    <asp:GridView ID="GV_Issuance" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"  OnPageIndexChanging="datagrid_PageIndexChanging_Issuance"
                        PageSize="10">
                        <pagersettings mode="NumericFirstLast"
            firstpagetext="First"
            lastpagetext="Last"
            pagebuttoncount="3"  
            position="Bottom"
            Visible="true"/>         
        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Date of Payment"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="REQDATE" HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDateOfPayment" runat="server" Text='<%# Eval("DATEPAID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="EMAIL2" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL2")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIN" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ACCTNO" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Commercial Name" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("commname")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>                      
                    
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <a href="#" onclick="do_view('<%# Eval("ACCTNO")%>')">View</a>                                 
                                   <%-- //;'<%# Eval("xFileData")%>', '<%# Eval("BRGY")%>'), '<%# Eval("MPDO")%>'), '<%# Eval("ENGG")%>'), '<%# Eval("HO")%>'), '<%# Eval("CENRO")%>'), '<%# Eval("FIRE")%>'--%>
                                   <%-- &nbsp 
                                    <a href="#" onclick="do_issue('<%# Eval("ACCTNO")%>', '<%# Eval("EMAIL2")%>');">Issue</a>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>         

                </div>
            </div>
        </div>
  
          <div class="col-sm-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Permits Issued</label>
                </div>
                <div class="card-body">
        
                    <asp:GridView ID="GV_Issued" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True"  OnPageIndexChanging="datagrid_PageIndexChanging_Issued"
                        PageSize="10">
                        <pagersettings mode="NumericFirstLast"
            firstpagetext="First"
            lastpagetext="Last"
            pagebuttoncount="3"  
            position="Bottom"
            Visible="true"/>         
        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Date of Payment"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDateOfPayment" runat="server" Text='' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center"  HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL2")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIN" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center"  HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Commercial Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("Commname")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>                      
                    
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <a href="#" onclick="do_view('<%# Eval("ACCTNO")%>', '<%# Eval("EMAIL2")%>');">View</a>                                 
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>         

                </div>
            </div>
        </div>
        
    </div>
    
    <input type="hidden" runat="server" id="hdn_xFileData" />
    <input type="hidden" runat="server" id="hdn_BRGY" />
    <input type="hidden" runat="server" id="hdn_MPDO" />
    <input type="hidden" runat="server" id="hdn_ENGG" />
    <input type="hidden" runat="server" id="hdn_HO" />
    <input type="hidden" runat="server" id="hdn_CENRO" />
    <input type="hidden" runat="server" id="hdn_FIRE" />
    <input type="button" runat="server" id="btn_view_Issuance" style="display:none"/>

     <input type="hidden" runat="server" id="hdn_ACCTNO" />

        <script>


            function do_view(ACCTNO) {
                document.getElementById('<%= hdn_ACCTNO.ClientID%>').value = ACCTNO;
                document.getElementById('<%= btn_view_Issuance.ClientID%>').click();
            }
            
            function do_issue() {
            }
    </script>

 
</asp:Content>