<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="TreasuryBusinessRenewalList.aspx.vb" Inherits="SPIDC.TreasuryBusinessRenewalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-12" align="center">
            <br />
            <h3><label class=" font-weight-bold text-primary mb-1">Business Renewal</label></h3>
        </div>
        <div class="col-sm-12 mb-2">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Business Renewal  - Approved by BPLO</label>
                </div>
                <div class="card-body">
                    <span class="">Show</span>
                    <select runat="server" id="_oTxtShowEntries" onchange="__doPostBack('SearchBP',this.value);" class="">
                    </select>
                    Entries
            <input type="hidden" runat="server" id="_oTxtShowEntriesHdn" />
                    <script>
                        var dropdown = document.getElementById("<%=_oTxtShowEntries.ClientID%>");
                        var TotalRow = document.getElementById("<%=_oTxtShowEntriesHdn.ClientID%>").value;
                        for (var i = TotalRow; i >= 1; i--) {
                            var newOption = document.createElement('option');
                            newOption.value = i;
                            newOption.innerHTML = i;
                            //alert(i);
                            dropdown.add(newOption);
                        }
                        addLoadEvent(LoadEntries);
                        function LoadEntries() {
                            //alert(sessionStorage.getItem('CmbEntries1'));
                            document.getElementById("<%=_oTxtShowEntries.ClientID%>").value = sessionStorage.getItem('CmbEntries1');
                        }
                    </script>
                    &nbsp&nbsp
                    Filter By:
            <select runat="server" id="_oTxtSearchFilter">
                <option value="S.EMAIL">Email</option>
                <option value="S.ACCTNO">ACCTNO</option>
                <option value="S.ReqDate">ReqDate</option>
                <option value="S.ORNo">ORNo</option>
                <option value="S.OWNER">OWNER</option>
                <option value="S.BUSNAME">BUSNAME</option>
                <option value="S.BUSADDRESS">BUSADDRESS</option>
                <option value="S.CATEGORY">CATEGORY</option>
                <option value="S.VerifiedBy">VerifiedBy</option>
            </select>
                    <input type="hidden" runat="server" id="_oHdnTopCounterKey">
                    <input type="hidden" runat="server" id="_oHdnTopCounterAssess">
                    <%--<button type="button" onclick="__doPostBack('Sort','');">Sort</button>--%>
                    <input type="text" runat="server" id="_oTxtSearchKey" onblur="RecordReset('BP');">
                    <script>
                        function RecordReset(filter) {
                            var Checkvalue;
                            var TopCounter
                            if (filter == 'BP') {
                                Checkvalue = document.getElementById('<%=_oTxtSearchKey.ClientID%>').value;
                                TopCounter = document.getElementById('<%=_oTxtShowEntries.ClientID%>').value;
                                document.getElementById('<%=_oHdnTopCounterKey.ClientID%>').value = TopCounter;
                            }
                            else {
                                Checkvalue = document.getElementById('<%=_oTxtSearchKeyAssess.ClientID%>').value;
                                TopCounter = document.getElementById('<%=_oTxtShowEntriesAssess.ClientID%>').value;
                                document.getElementById('<%=_oHdnTopCounterAssess.ClientID%>').value = TopCounter;
                            }

                            if (!Checkvalue.length > 0) {
                                if (filter == 'BP') {
                                    __doPostBack('SearchBP', TopCounter);
                                }
                                else {
                                    __doPostBack('SearchAssess', TopCounter);
                                }

                            }
                        }
                        function SetAllTopValues1() {
                            var CheckAppvalue = document.getElementById('<%=_oHdnTopCounterKey.ClientID%>').value;
                            var CheckVerifyvalue = document.getElementById('<%=_oHdnTopCounterAssess.ClientID%>').value;
                            if (!CheckAppvalue.length > 0) { document.getElementById('<%=_oHdnTopCounterKey.ClientID%>').value = document.getElementById('<%=_oTxtShowEntries.ClientID%>').value; }
                            if (!CheckVerifyvalue.length > 0) { document.getElementById('<%=_oHdnTopCounterAssess.ClientID%>').value = document.getElementById('<%=_oTxtShowEntriesAssess.ClientID%>').value; }
                        }
                        addLoadEvent(SetAllTopValues1);
                    </script>
                    <button type="button" onclick="__doPostBack('SearchBP',document.getElementById('<%=_oTxtShowEntries.ClientID%>').value);">Search</button>
                    <hr/>
                    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_BP"
                        PagerStyle-Height="45" PagerSettings-LastPageText="" PageSize="5" EnableViewState="true">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="5"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Date Submit" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="DATESUBMIT" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("DATESUBMIT")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ACCTNO" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bus. Owner/Manager" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="Center" SortExpression="OWNER" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("OWNER")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business Name" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" SortExpression="BUSNAME" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("BUSNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business Address" HeaderStyle-Width="17%" ItemStyle-HorizontalAlign="center" SortExpression="BUSADDRESS" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("BUSADDRESS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business Line" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" SortExpression="CATEGORY" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("CATEGORY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" SortExpression="CATEGORY1" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY1")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <a href="#" onclick="assess('Assess','<%# Eval("ACCTNO")%>');" title="Assess">Assess</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    showing 1 -
                    <label id="_oLblShowingValue" runat="server"></label>
                    of
                    <label id="_oTtlEntries" runat="server">20</label>                 
                    
                </div>
            </div>
            </div>
            <div class="col-sm-12"  >
            <div class="card shadow" >
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Assessed Business</label>
                </div>
                <div class="card-body m-1" >
                    <span class="">Show</span>
                    <select runat="server" id="_oTxtShowEntriesAssess" onchange="__doPostBack('SearchAssess',this.value);" class="">
                    </select>
                    Entries
            <input type="hidden" runat="server" id="_oTxtShowEntriesHdnAssess" />
                    <script>
                        var dropdown = document.getElementById("<%=_oTxtShowEntriesAssess.ClientID%>");
                        var TotalRow = document.getElementById("<%=_oTxtShowEntriesHdnAssess.ClientID%>").value;
                        for (var i = TotalRow; i >= 1; i--) {
                            var newOption = document.createElement('option');
                            newOption.value = i;
                            newOption.innerHTML = i;
                            //alert(i);
                            dropdown.add(newOption);
                        }
                        addLoadEvent(LoadEntries);
                        function LoadEntries() {
                            //alert(sessionStorage.getItem('CmbEntries1'));
                            document.getElementById("<%=_oTxtShowEntriesAssess.ClientID%>").value = sessionStorage.getItem('CmbEntries2');
                        }
                    </script>
                    &nbsp&nbsp
                    Filter By:
            <select runat="server" id="_oTxtSearchFilterAssess">
                <option value="S.EMAIL">Email</option>
                <option value="S.ACCTNO">ACCTNO</option>
                <option value="S.ReqDate">ReqDate</option>
                <option value="S.ORNo">ORNo</option>
                <option value="S.OWNER">OWNER</option>
                <option value="S.BUSNAME">BUSNAME</option>
                <option value="S.BUSADDRESS">BUSADDRESS</option>
                <option value="S.CATEGORY">CATEGORY</option>
                <option value="S.VerifiedBy">VerifiedBy</option>
            </select>
                    <%--<button type="button" onclick="__doPostBack('Sort','');">Sort</button>--%>
                    <input type="text" runat="server" id="_oTxtSearchKeyAssess" onblur="RecordReset('Assess');">
                    <script>                       
                    </script>
                    <button type="button" onclick="__doPostBack('SearchAssess',document.getElementById('<%=_oTxtShowEntriesAssess.ClientID%>').value);">Search</button>
                    <hr/>
                    <asp:GridView ID="GridView2"   runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_Assess"
                        PageSize="5">
                        <pagersettings mode="NumericFirstLast"
                            firstpagetext="First"
                            lastpagetext="Last"
                            pagebuttoncount="5"  
                            position="Bottom"
                            Visible="true"/>         
                        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Date Submit"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="DATESUBMIT" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("DATESUBMIT")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business ID"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ACCTNO" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bus. Owner/Manager"  HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="Center" SortExpression="OWNER" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("OWNER")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business Name"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" SortExpression="BUSNAME" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("BUSNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business Address"  HeaderStyle-Width="17%" ItemStyle-HorizontalAlign="center" SortExpression="BUSADDRESS" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("BUSADDRESS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business Line"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" SortExpression="CATEGORY" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("CATEGORY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" SortExpression="CATEGORY1" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY1")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <a href="#" onclick="assess('Payment','<%# Eval("ACCTNO")%>');" title="Assess">View</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notified"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelTotal" runat="server" Text='<%# If(Eval("ISASSESS"), "Yes", "No")%> ' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    showing 1 - 
                    <label id="_oLblShowingValueAssess" runat="server"></label>
                    of
                    <label id="_oTtlEntriesAssess" runat="server">20</label>
                </div>
            </div>
                
        </div>
    </div>
    <script>
        function assess(Action, Value) {
            __doPostBack(Action, Value);
        }
    </script>
</asp:Content>