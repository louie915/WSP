<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="certificationTOP.aspx.vb" Inherits="SPIDC.certificationTOP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="form-row justify-content-center align-items-center form mb-0">
        <div class="col-sm-8">
            <br />
            <br />
            <br />
            <div class="card shadow">
                <div class="card-header">
                    <div class="form-row form">
                        <div class="col-sm-6">
                            <h1 class="h5 mb-0 text-gray-800">Tax Order of Payment</h1>
                        </div>
                    </div>
                </div>
                <div class="card-body">
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
                    <div class="row">
                        <div class="col-sm-12" align="center">
                            <br />
                            <a runat="server" href="#" class="btn btn-primary btn-sm btn-icon-split" id="_oBtnConfirm">
                                <span class="icon text-white-50">
                                    <i class="fas fa-check-circle"></i>
                                </span>
                                <span class="text">Confirm</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        
</asp:Content>