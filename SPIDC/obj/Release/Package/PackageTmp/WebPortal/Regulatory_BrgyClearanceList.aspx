<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/Regulatory_BrgyClearance.Master"  CodeBehind="Regulatory_BrgyClearanceList.aspx.vb" Inherits="SPIDC.Regulatory_BrgyClearanceList"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="col-sm-12">
         <div class="card shadow">
              <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">New Business (Barangay Clearance Application Review)</label>
                </div>

                <div class="card-body">
                          <div class="card-body">
                    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging"
                        PageSize="5">
                        <pagersettings mode="NumericFirstLast"
                            firstpagetext="First"
                            lastpagetext="Last"
                            pagebuttoncount="10"  
                            position="Bottom"
                            Visible="true"/>         
                        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Application ID"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelApplication_ID" runat="server" Text='<%# Eval("Application_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("APP_DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAILADDR")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("OwnerName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Commercial Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>                           
                             <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                             <asp:ImageButton runat="server" title="Review" ID="_oButtonForAppNo" src="../CSS_JS_IMG/img/reviewIcon.png" OnClick="ImageButton_Click2" style="width:20px;height:20px"/>
                                   View/Process
                                
                    <%--        <a href="#"><img src="../CSS_JS_IMG/img/reviewIcon.png" style="width:20px;height:20px"/>  View/Process</a>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                          </div>
                </div>
         </div>
    </div>
</asp:Content>

