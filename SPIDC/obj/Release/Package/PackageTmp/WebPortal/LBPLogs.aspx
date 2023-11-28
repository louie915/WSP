<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="LBPLogs.aspx.vb" Inherits="SPIDC.LBPLogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <asp:GridView ID="_oGVLogs" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                             
<Columns>

    <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("Date")%>' />
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="EppRefNo"  ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelEppRefNo" runat="server" Text='<%# Eval("EppRefNo")%>' />
        </ItemTemplate>
    </asp:TemplateField>

        <asp:TemplateField HeaderText="TransType"   ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelTransType" runat="server" Text='<%# Eval("TransType")%>' />
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Description"   ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("Description")%>' />
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="BIN_ASSESSNO"  ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelBIN_ASSESSNO" runat="server" Text='<%# Eval("BIN_ASSESSNO")%>' />
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="OnlineID"  ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelOnlineID" runat="server" Text='<%# Eval("OnlineID")%>' />
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Amount"  ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelAmount" runat="server" Text='<%# Eval("Amount")%>' />
        </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Status"  ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelStatus" runat="server" Text='<%# Eval("Status")%>' />
        </ItemTemplate>
    </asp:TemplateField>

        <asp:TemplateField HeaderText="PaymentOption"  ItemStyle-HorizontalAlign="center">
        <ItemTemplate>
            <asp:Label ID="_oLabelPaymentOption" runat="server" Text='<%# Eval("PaymentOption")%>' />
        </ItemTemplate>
    </asp:TemplateField>
</Columns>

                        </asp:GridView>


</asp:Content>
