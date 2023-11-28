<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="AccountOtherTransaction.aspx.vb" Inherits="SPIDC.AccountOtherTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
    <div class="CH-NavBar p-2"><h6 class=m-2 ">Account Information</h6></div>
    <div class="row justify-content-center align-items-center card form mb-0 ">
        <div class="col-xl-12 col-lg-12">
            
            <div class="mb-2">
                
                <a class="nav-link dropdown-toggle font-weight-bold text-primary" href="#" id="searchDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Business Permit Account <i class="fas fa-search fa-fw"></i>
                        </a>
                        <!-- Dropdown - Messages -->
                        <div class="dropdown-menu p-2 shadow" aria-labelledby="searchDropdown">
                            <form class="form-inline mr-auto navbar-search">
                                <div class="input-group">
                                    <input type="text" class="form-control bg-light border-0 small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
                                    <div class="input-group-append">
                                        <button class="btn btn-primary" type="button">
                                            <i class="fas fa-search fa-sm"></i>
                                        </button>
                                    </div>
                                </div>
                            </form>
                        </div>
                <div class="">
                    <div>
                        <asp:GridView ID="GridView1"  runat="server" CssClass="GridViewStyle "  AllowSorting="true" 
                            AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true" >     

                     <%--<FooterStyle CssClass="GridViewFooterStyle" />
                     <RowStyle CssClass="GridViewRowStyle"  />
                     <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                     <PagerStyle CssClass="GridViewPagerStyle" />
                     <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                     <HeaderStyle CssClass="GridViewHeaderStyle" />--%>


                    <Columns >

                     <asp:TemplateField HeaderText="Bus. ID Number" >
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusIDNumber" runat="server" Text='<%# Eval("Bus. ID Number")%>'  />
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Bus. Owner/Manager">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# Eval("Bus. Owner/Manager")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>    

                       <asp:TemplateField HeaderText="Business Name">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Eval("Business Name")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>       

                        <asp:TemplateField HeaderText="Business Address">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# Eval("Business Address")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>  

                       <asp:TemplateField HeaderText="Category">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusCategory" runat="server" Text='<%# Eval("Category")%>' />
                         </ItemTemplate>
                       </asp:TemplateField>        

                        <asp:TemplateField HeaderText="Action1">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusAction1" runat="server" Text='<%# Eval("Action1")%>' />
                         </ItemTemplate>
                       </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Action2">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusAction2" runat="server" Text='<%# Eval("Action2")%>' />
                         </ItemTemplate>
                       </asp:TemplateField>  

                        <asp:TemplateField HeaderText="Action3">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusAction3" runat="server" Text='<%# Eval("Action3")%>' />
                         </ItemTemplate>
                       </asp:TemplateField>  

              

         
                                                                  
                      </Columns>

                    </asp:GridView> 
                        <%--<div id="dataTable_wrapper">
                            
                            <div class=" ">
                                <table>
                                    <thead>
                                        <tr role="row">
                                            <th id="_othBusIDNumber" class="sorting_asc bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Bus. ID Number: activate to sort column descending" style="width: 300px; font-size: 15px">Bus. ID Number</th>
                                            <th id="_othBusOwnerManager" class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus. Owner/Manager: activate to sort column ascending" style="width: 300px; font-size: 15px">Bus. Owner/Manager</th>
                                            <th id="_othBusName" class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Business Name: activate to sort column ascending" style="width: 300px; font-size: 15px">Business Name</th>
                                            <th id="_othBusCategory" class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus Addres: activate to sort column ascending" style="width: 600px; font-size: 15px">Bus Address</th>
                                            <th id="_othBusAddress" class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Category: activate to sort column ascending" style="width: 150px; font-size: 15px">Category</th>
                                            <th id="_othBusAction1" class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action1: activate to sort column ascending" style="width: 200px; font-size: 15px"></th>
                                            <th id="_othBusAction2" class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action2: activate to sort column ascending" style="width: 300px; font-size: 15px">Action</th>
                                            <th id="_othBusAction3" class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Action3: activate to sort column ascending" style="width: 200px; font-size: 15px"></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr role="row" class="odd">
                                            <td id="_otdBusIDNumber" class="bpa">B-01902</td>
                                            <td id="_otdBusOwnerManager" class="bpa">Archie Escober</td>
                                            <td id="_otdBusName" class="bpa">Chiechie's Shop</td>
                                            <td id="_otdBusCategory" class="bpa">Bagbaguin, Sta. Maria Bulacan</td>
                                            <td id="_otdBusAddress" class="bpa">Services</td>
                                            <td id="_otdBusAction1" class="bpa"><a href="../SOS-WEB-PAGES/AccountInformation.aspx">Information</a></td>
                                            <td id="_otdBusAction2" class="bpa"><a href="../SOS-WEB-PAGES/AccountOtherTransaction.aspx">Other Trans</a></td>
                                            <td id="_otdBusAction3" class="bpa"><a href="../SOS-WEB-PAGES/BusinessRenewal.aspx">Renew</a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!--div class="row"><div class="col-sm-12 col-md-5"><div class="dataTables_info" id="dataTable_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div></div><div class="col-sm-12 col-md-7">v</div></!--div></div-->
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="col-xl-12 col-lg-12">
            
            <div class="card shadow mb-4">
                <div class="mb-2">
                
                <a class="nav-link dropdown-toggle font-weight-bold text-primary" href="#" id="searchDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Other Transactions(Business License Related) <i class="fas fa-search fa-fw"></i>
                        </a>
                        <!-- Dropdown - Messages -->
                        <div class="dropdown-menu p-2 shadow" aria-labelledby="searchDropdown">
                            <form class="form-inline mr-auto navbar-search">
                                <div class="input-group">
                                    <input type="text" class="form-control bg-light border-0 small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
                                    <div class="input-group-append">
                                        <button class="btn btn-primary" type="button">
                                            <i class="fas fa-search fa-sm"></i>
                                        </button>
                                    </div>
                                </div>
                            </form>
                        </div>
                <div class="">
                    <div >

                        <asp:GridView ID="GridView2"  runat="server" CssClass="GridViewStyle "  AllowSorting="true" 
                            AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true" >     

                     <%--<FooterStyle CssClass="GridViewFooterStyle" />
                     <RowStyle CssClass="GridViewRowStyle"  />
                     <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                     <PagerStyle CssClass="GridViewPagerStyle" />
                     <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                     <HeaderStyle CssClass="GridViewHeaderStyle" />--%>


                    <Columns >

                     <asp:TemplateField HeaderText="Certifications" >
                         <ItemTemplate>
                          <asp:Label ID="_oLabelCertifications" runat="server" Text='<%# Eval("Certifications")%>'  />
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Business Account Modification">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelBusAccModification" runat="server" Text='<%# Eval("Business Account Modification")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>    
                                                                                                                
                      </Columns>

                    </asp:GridView> 
                        <%--<div id="">
                            
                            <div class=" ">
                                <table>
                                    <thead>
                                        <tr role="row">
                                            <th id="_othOTCertifications"class="sorting_asc bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Bus. ID Number: activate to sort column descending" style="width: 500px; font-size: 15px">Certifications</th>
                                            <th id="_othOTModifications" class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus. Owner/Manager: activate to sort column ascending" style="width: 500px; font-size: 15px">Business Account Modification</th>                                            
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr role="row" class="odd">
                                            <td id="_otdOTCertifications"><a href="#">Certificate of Delinquency</a></td>
                                            <td id="_otdOTModifications" ><a href="#">Additional Line of Business</a></td>                                            
                                        </tr>
                                        <tr role="row" class="even">
                                            <td class="ot"><a href="#">Certificate of Transfer of Ownership</a></td>
                                            <td class="ot"><a href="#">Change Owner Address</a></td>                                            
                                        </tr>
                                        <tr role="row" class="odd">
                                            <td class="ot"><a href="#">Certificate of Existing Records</a></td>
                                            <td class="ot"><a href="#">Change/Update Contact Informations</a></td>                                            
                                        </tr>
                                        <tr role="row" class="even">
                                            <td class="ot"><a href="#">Application for Business Retirement</a></td>
                                            <td class="ot"><a href="#">Business Retirement</a></td>                                            
                                        </tr>                                                                              
                                    </tbody>
                                </table>
                            </div>
                            <!--div class="row"><div class="col-sm-12 col-md-5"><div class="dataTables_info" id="dataTable_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div></div><div class="col-sm-12 col-md-7">v</div></!--div></div-->
                        </div>--%>
                    </div>
                </div>
            </div>                
            </div>
            
            </div>
        
    </div>
   
</asp:Content>
