<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="CertificationListPage.aspx.vb" Inherits="SPIDC.CertificationListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <div class="form-row form">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <br />
            <br />
            <h4 class="m-0 font-weight-bold text-primary">Certifications</h4>
        </div>
        <div class="col-sm-1"></div>
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <div class="card shadow"> 
                <div class="card-header">
                    <h6 class="m-0 font-weight-bold text-primary">Certification List</h6>
                </div>
                <div class="card-body">
                    <h6 class="m-0 font-weight-light text-primary" id="_oLabelTypeOfCertification" runat="server"></h6>                   
                    <asp:GridView ID="GridView4"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("Date")%>' />
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Time")%>' />
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Number" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTransactioNumber" runat="server" Text='<%# Eval("Transaction Number")%>' />
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account/TD Number" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelAccountTDNumber" runat="server" Text='<%# Eval("Account/TD Number")%>' />
                                    </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Declared Owner" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("Declared Owner")%>' />
                                    </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Certification Type" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("CERTTYPE")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Action" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelOtherAction" runat="server" Text='<%# Eval("Other Action")%>' />
                                        <div align="center">
                                            <a href="#" onclick="" title="Email">Email</a>&nbsp;&nbsp;
                                            <a href="#" onclick="" title="Print">Print</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>              
                    </asp:GridView>
                    <br>
                    <h6 class="m-0 font-weight-light text-primary" id="H1" runat="server">Certified True Copy(Real Property)</h6>   
                                    <asp:GridView ID="GridView5"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("Date")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Time")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Number" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTransactioNumber" runat="server" Text='<%# Eval("Transaction Number")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account/TD Number" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelAccountTDNumber" runat="server" Text='<%# Eval("Account/TD Number")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Declared Owner" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("Declared Owner")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                             <asp:TemplateField HeaderText="Certification Type" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("CERTTYPE")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Action" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelOtherAction" runat="server" Text='<%# Eval("Other Action")%>' />
                                        <div align="center">
                                            <a href="#" onclick="" title="Email">Email</a>&nbsp;&nbsp;
                                            <a href="#" onclick="" title="Print">Print</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>              
                    </asp:GridView>    
                    
                    <br>
                    <h6 class="m-0 font-weight-light text-primary" id="H2" runat="server">Certificate of No Improvement(Real Property)</h6>   
                                    <asp:GridView ID="GridView6"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("Date")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Time")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Number" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTransactioNumber" runat="server" Text='<%# Eval("Transaction Number")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account/TD Number" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelAccountTDNumber" runat="server" Text='<%# Eval("Account/TD Number")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Declared Owner" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("Declared Owner")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                             <asp:TemplateField HeaderText="Certification Type" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("CERTTYPE")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Action" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelOtherAction" runat="server" Text='<%# Eval("Other Action")%>' />
                                        <div align="center">
                                            <a href="#" onclick="" title="Email">Email</a> &nbsp;&nbsp;
                                            <a href="#" onclick="" title="Print">Print</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>              
                    </asp:GridView>  
            
                    <br>
                    <h6 class="m-0 font-weight-light text-primary" id="H3" runat="server">Certificate of ***</h6>   
                                    <asp:GridView ID="GridView7"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("Date")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Time")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Number" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTransactioNumber" runat="server" Text='<%# Eval("Transaction Number")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Account/TD Number" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelAccountTDNumber" runat="server" Text='<%# Eval("Account/TD Number")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Declared Owner" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("Declared Owner")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                             <asp:TemplateField HeaderText="Certification Type" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDeclaredOwner" runat="server" Text='<%# Eval("CERTTYPE")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Other Action" ItemStyle-Width="15%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelOtherAction" runat="server" Text='<%# Eval("Other Action")%>' />
                                        <div align="center">
                                            <a href="#" onclick="" title="Email">Email</a> &nbsp;&nbsp;
                                            <a href="#" onclick="" title="Print">Print</a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>              
                    </asp:GridView>                   
                </div>
                <div class="card-footer">
                    <div class="row">
                        <div class="col-sm-12" align="center">
                            <br />
                            <br />
                            <div class="float-right">
                                <button class="btn btn-primary btn-sm" id="_oBtnPrintAll" runat="server">Email All</button>
                                &emsp;
                                <button class="btn btn-primary btn-sm" id="_oBtnEmailAll" runat="server">Print All</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
