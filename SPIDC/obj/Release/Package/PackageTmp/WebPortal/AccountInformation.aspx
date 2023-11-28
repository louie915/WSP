<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="AccountInformation.aspx.vb" Inherits="SPIDC.AccountInformation" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <script>

   </script>
    
     <div class=" p-2"><h5 class="m-2 font-weight-bold text-primary">Account Information</h5></div>

    <div class="card shadow">
        <div class="form-row form">
                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Bus. ID Number: &nbsp
                            <br>
                           <asp:Label ID="_oLblBusID" runat="server" Text=""  />
                        </label>
                        
                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Bus. Owner/Manager: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusOwner" runat="server" Text="" />
                        </label>
                        
                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>


                        <label class="text-capitalize font-weight-bold text-primary">Business Name: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusName" runat="server" Text="" />
                        </label>
                        
                    </div>
                </div>


                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Business Address: &nbsp

                            <br>
                            <asp:Label ID="_oLblBusAddress" runat="server" Text="" />
                        </label>
                        
                    </div>
                </div>

            <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Business Line: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusCategory" runat="server" Text="" />
                        </label>
                        
                    </div>
                </div>



                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Category: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusCategory1" runat="server" Text="" />
                        </label>
                        
                    </div>
                </div>
                
            </div>
        <div class="my-2 mr-2 ml-2">
            
            <div class="mb-2 mx-2">
                

                

                <%--<a class="nav-link dropdown-toggle font-weight-bold text-primary" href="#" id="searchDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Business Permit Account <i class="fas fa-search fa-fw"></i>
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
                <div class="">--%>
                    <div>


                       <%-- <div class="table-responsive">

                        <asp:GridView ID="GridView1"  runat="server" CssClass="GridViewStyle "  AllowSorting="true" 
                            AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true" >     

                     <%--<FooterStyle CssClass="GridViewFooterStyle" />
                     <RowStyle CssClass="GridViewRowStyle"  />
                     <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                     <PagerStyle CssClass="GridViewPagerStyle" />
                     <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                     <HeaderStyle CssClass="GridViewHeaderStyle" />--%>


<%--                    <Columns >

                     <asp:TemplateField HeaderText="Bus. ID Number" >
                         <ItemTemplate>
                          
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Bus. Owner/Manager">
                         <ItemTemplate>
                         
                         </ItemTemplate>
                     </asp:TemplateField>    

                       <asp:TemplateField HeaderText="Business Name">
                         <ItemTemplate>
                          
                         </ItemTemplate>
                     </asp:TemplateField>       

                        <asp:TemplateField HeaderText="Business Address">
                         <ItemTemplate>
                          
                         </ItemTemplate>
                     </asp:TemplateField>  

                       <asp:TemplateField HeaderText="Category">
                         <ItemTemplate>
                          
                         </ItemTemplate>
                       </asp:TemplateField>        --%>

<%--                        <asp:TemplateField HeaderText="Action1">
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
                       </asp:TemplateField>  --%>

              

         
                  <%--                                                
                      </Columns>

                    </asp:GridView> --%>

                         <%--   </div> --%>
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
            <div class="mx-3">
                <div class="form-row form">
                <div class="form-group col-md-2">
                    <div>

                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">First Name </span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtFirstName" disabled>
                    </div>
                </div>

                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Middle Name</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off"  runat="server" id="_oTxtMiddleName" disabled>
                    </div>

                </div>
                
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Last Name</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtLastName" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-sm-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Suffix</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtSufix" disabled >
                         
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-sm-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Gender</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtGender" disabled >
                         
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>
            <div class="form-row form">
                <div class="form-group col-md-8">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Owner Address</span></span>
                        </label>
                        <textarea class="form-control CH-Size-New" runat="server" id="_oTxtOwnerAddress" disabled></textarea>
                    </div>

                </div>
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Barangay</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtBarangay1" disabled >
                         
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">ZIP/Postal Code</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtZIPPostalCode1" disabled >
                         
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>

            <div class="form-row form">

                <div class="form-group col-md-8">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Commercial Name</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtCommercialName" disabled>
                    </div>

                </div>
                

            </div>
            <div class="form-row form">

                <div class="form-group col-md-8">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Commercial Address</span></span>
                        </label>
                        <textarea class="form-control CH-Size-New" runat="server" id="_oTxtCommercialAddress" disabled></textarea>
                    </div>

                </div>
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Barangay</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtBarangay2" disabled >
                         
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">ZIP/Postal Code</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New"  autocomplete="off" runat="server" id="_oTxtZIPPostalCode2" disabled >
                         
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>


            </div>
            <div class="form-row form">

                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Mobile Number</span></span>
                        </label>
                        <input class="form-control CH-Size-New"  onclick="this.type = 'tel'"  autocomplete="off" runat="server" id="_oTxtMobileNumber" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Tel. Number</span></span>
                        </label>
                        <input class="form-control CH-Size-New" onclick="this.type = 'tel'"  autocomplete="off" runat="server" id="_oTxtTelNumber" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Email Address</span></span>
                        </label>
                        <input class="form-control CH-Size-New" onclick="this.type = 'email'"  autocomplete="off" runat="server" id="_oTxtEmailAddress" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

            </div>

                 <div class="mb-2 mx-2">
                <div class="card row">
                    
                        <a class="nav-link dropdown-toggle font-weight-bold text-primary" href="#" id="searchDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Payment History <i class="fas fa-search fa-fw"></i>
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
                    </div>
                
            </div>
            <div class="table-responsive mb-5 d-flex justify-content-center">
                <div style="overflow-y: scroll;height: 400px; width:800px;">
                    <div>
                        <div id="dataTable_wrapper1">
                            <asp:GridView ID="GridView2"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true" 
                            AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="center">     

                     <%--<FooterStyle CssClass="GridViewFooterStyle" />
                     <RowStyle CssClass="GridViewRowStyle"  />
                     <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                     <PagerStyle CssClass="GridViewPagerStyle" />
                     <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                     <HeaderStyle CssClass="GridViewHeaderStyle" />--%>


                    <Columns >

                     <asp:TemplateField HeaderText="Period" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelPeriod" runat="server" Text='<%# Eval("PERIODCOVERED")%>'  />
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="OR Number" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelORNumber" runat="server" Text='<%# Eval("ORNO")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>    

                       <asp:TemplateField HeaderText="Type of Payment" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("Remarks2")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>       

                        <asp:TemplateField HeaderText="Amount Paid" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="right">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelAmountPaid" runat="server" Text='<%# Eval("TOTALAMT", "{0:C}").ToString().Replace("$", "")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>  

              
                                                                           
                      </Columns>
                               
                    </asp:GridView> 
                            
                            <%--<div class=" ">
                                <table>
                                    <thead>
                                        <tr role="row">
                                            <th class="sorting_asc bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-sort="ascending" aria-label="Bus. ID Number: activate to sort column descending" style="width: 300px; font-size: 15px">Period</th>
                                            <th class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus. Owner/Manager: activate to sort column ascending" style="width: 300px; font-size: 15px">OR Number</th>
                                            <th class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Business Name: activate to sort column ascending" style="width: 300px; font-size: 15px">Description</th>
                                            <th class="sorting bg-primary text-white" tabindex="0" aria-controls="dataTable" rowspan="1" colspan="1" aria-label="Bus Addres: activate to sort column ascending" style="width: 600px; font-size: 15px">Amount Paid</th>                                            
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr role="row" class="odd">
                                            <td class="ph">Sample Period</td>
                                            <td class="ph">Sample OR Number</td>
                                            <td class="ph">Sample description</td>
                                            <td class="ph">Sample Amount Paid</td>                                            
                                        </tr>
                                    </tbody>
                                </table>
                            </div>--%>
                            <!--div class="row"><div class="col-sm-12 col-md-5"><div class="dataTables_info" id="dataTable_info" role="status" aria-live="polite">Showing 1 to 10 of 57 entries</div></div><div class="col-sm-12 col-md-7">v</div></!--div></div-->
                            
                        </div>
                        
                    </div>
                    
                </div>
                </div> 
            </div> 
           
        
       <%--<button name="_obtnPrint" runat="server" id="_obtnPrint" type="submit"  class="btn btn-primary m-2 col-md-5 btn-sm" style="position:absolute;bottom:0;right:0;width:100px" >Print </button>--%>
        <button name="_obtnPrint" runat="server" id="_obtnPrint" type="submit" class="btn btn-primary btn-icon-split m-2 col-md-5" style="position: absolute; bottom: 0; right: 0; width: 100px">                           
            <span class="text">Print</span>
            <span class="icon text-white-50">
                <i class="fas fa-print mt-1"></i>
            </span>
        </button> 
            </div>
         
                 

</asp:Content>
