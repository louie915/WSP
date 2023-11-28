<%@ Page EnableEventValidation="false" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/ASSESSORMaster.Master" CodeBehind="ASSESSORCertificationList.aspx.vb" Inherits="SPIDC.ASSESSORCertificationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-row form col-lg-12">
        <div class="col-lg-12" align="center">
            <br />
            <h4><label class=" font-weight-bold text-primary mb-1">Assessor Certifications</label></h4>
        </div>
        
        <div class="col-lg-12 d-flex align-content-center justify-content-center">
            <div class="card shadow col-lg-11">
                <div class="card-header">
                    <h5 class="m-0 font-weight-bold text-primary">Certification List</h5>
                </div>
                <div class="card-body">
                    <a href="#Application" data-toggle="collapse" data-dismiss="collapse" data-target="#ApplicationTraining" data-ticket-type="standard-access" style="float: left" onclick="txtchange(this.id,innerHTML)" id="hdshw4"><h6 class="m-0 font-weight-light text-primary" id="_oLabelTypeOfCertification" runat="server">Certificate of No Property</h6>   </a>
                    <br />
                    <div id="ApplicationTraining" class="collapse">                
                    <asp:GridView ID="GridView4" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Number"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelTransNo" runat="server" Text='<%# Eval("Transaction Number")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certification Type"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCertType" runat="server" Text='<%# Eval("CERTTYPE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certification Type"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <a href="#" title="View">View</a>&emsp;
                                    <a href="#" title="View">Process</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>              
                    </asp:GridView>
                        </div>
                    
                    <br/>

                    <a href="#Application" data-toggle="collapse" data-dismiss="collapse" data-target="#ApplicationTraining1" data-ticket-type="standard-access" style="float: left" onclick="txtchange(this.id,innerHTML)" id="hdshw5"><h6 class="m-0 font-weight-light text-primary" id="H1" runat="server">Certified True Copy(Real Property)</h6></a>   
                                    <div id="ApplicationTraining1" class="collapse">  
                                        <br />

                    <asp:GridView ID="GridView5" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True">
                                        <Columns>
                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Number"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelTransNo" runat="server" Text='<%# Eval("Transaction Number")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certification Type"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCertType" runat="server" Text='<%# Eval("CERTTYPE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certification Type"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <a href="#" title="View">View</a>&emsp;
                                    <a href="#" title="View">Process</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>              
                    </asp:GridView>    
                    </div>                   
                    <br/>
                    <br />
                    <a href="#Application" data-toggle="collapse" data-dismiss="collapse" data-target="#ApplicationTraining2" data-ticket-type="standard-access" style="float: left" onclick="txtchange(this.id,innerHTML)" id="hdshw6"><h6 class="m-0 font-weight-light text-primary" id="H2" runat="server">Certificate Of Land Holdings</h6></a>   
                                    <div id="ApplicationTraining2" class="collapse">  
                                        <br />
                    <asp:GridView ID="GridView6" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Number"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelTransNo" runat="server" Text='<%# Eval("Transaction Number")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certification Type"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCertType" runat="server" Text='<%# Eval("CERTTYPE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certification Type"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <a href="#" title="View">View</a>&emsp;
                                    <a href="#" title="View">Process</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>              
                    </asp:GridView>  
                                        </div>
                    
            <br />
                    <br/>


                    <a href="#Application" data-toggle="collapse" data-dismiss="collapse" data-target="#ApplicationTraining3" data-ticket-type="standard-access" style="float: left" onclick="txtchange(this.id,innerHTML)" id="hdshw7"><h6 class="m-0 font-weight-light text-primary" id="H3" runat="server">Certificate of No Improvement</h6>   </a>
                                    <div id="ApplicationTraining3" class="collapse"> 
                                        <br/>
                    <asp:GridView ID="GridView7" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transaction Number"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelTransNo" runat="server" Text='<%# Eval("Transaction Number")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certification Type"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCertType" runat="server" Text='<%# Eval("CERTTYPE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certification Type"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <a href="#" title="View">View</a>&emsp;
                                    <a href="#" title="View">Process</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>              
                    </asp:GridView>
                    </div>
                    <br/>
                    <br/>
                </div>
                <div class="card-footer" align="right" >
                    <button class="btn btn-primary btn-sm" id="_oBtnPrintAll" runat="server">Email All</button>
                    &emsp;
                    <button class="btn btn-primary btn-sm" id="_oBtnEmailAll" runat="server">Print All</button>
                </div>
            </div>
        </div>
       
    </div>
</asp:Content>