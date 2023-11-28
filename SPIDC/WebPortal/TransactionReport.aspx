<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="TransactionReport.aspx.vb" Inherits="SPIDC.TransactionReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div id="snackbar" style="z-index: 1200;">Some text some message..</div>

    <!-- Modal Apointment Summary -->
    <div id="AppointmentSummary" class="modal fade">
        <div class="modal-dialog" style="min-width: 50vh; max-width: 80vh" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title"> Summary</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <div class="card-footer">
                            <div class="row">
                                <div class="col-sm-6 align-content-center">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Appointment ID</p>
                                    <p class="h6 font-weight-light" id="lblAppID" runat="server"></p>
                                    <br />
                                </div>
                                <div class="col-sm-6 align-content-center">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Remarks</p>
                                    <p class="h6 font-weight-light" id="lblRemarks" runat="server"></p>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Name</p>
                                    <p class="h6 font-weight-light" id="lblName" runat="server"></p>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Contact</p>
                                    <p class="h6 font-weight-light" id="lblContact" runat="server"></p>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Department</p>
                                    <p class="h6 font-weight-light" id="lblDepartment" runat="server"></p>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Transaction Type</p>
                                    <p class="h6 font-weight-light" id="lblType" runat="server"></p>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Appointment Date</p>
                                    <p class="h6 font-weight-light" id="lblAppDate" runat="server"></p>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Purpose(if Type is [OTHERS])</p>
                                    <p class="h6 font-weight-light" id="lblPurpose" runat="server"></p>
                                    <br />
                                </div>
                            </div>
                            <center> 
                                <a href="#" class="btn btn-success  col-6" onclick="do_Print()"><i class="fa fa-print"></i>&nbsp Print Slip</a>
                            </center>


                        </div>
                    </div>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Taxpayer Report</h5>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row col-lg-6">
                <div class="form-group col-lg-4">
                    <div>
                        <label class="input-txt input-txt-active2 ml-2">
                            <span><span class="m-2">Search By</span></span>
                        </label>
                        <select class="form-control" runat="server" id="cmbSearch">                           
                            <option value="UserID" selected>Email</option>
                            <option value="FullName">Name</option>
                            <option value="Address">Address</option>
                        </select>
                    </div>
                </div>
                <div class="form-group col-lg-4">
                    <div>
                        <input type="text" class="form-control" runat="server" id="txtSearch" />
                    </div>
                </div>
                <div class="form-group col-lg-4">
                    <div>
                        <input type="button" class="form-control btn btn-primary" runat="server" id="btnSearch" value="Search" />
                    </div>
                </div>
            </div>   
   
                      
                        <div class="form-row col-lg-12">
                           
                        <div class="form-group col-md-2">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">(Registration Date) From</span></span>
                                </label>
                                <input runat="server" id="txtDateFrom" type="text" class="form-control" />

                            </div>
                        </div>
                        <div class="form-group col-md-2">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">(Registration Date) To</span></span>
                                </label>
                                <input runat="server" id="txtDateTo" type="text" class="form-control" />

                            </div>
                        </div>
                         <div class="form-group col-md-2">
                            <div>
                                <label class="input-txt input-txt-active2 ml-2">
                                    <span><span class="m-2">Sort By</span></span>
                                </label>
                                <select class="form-control" runat="server" id="cmbSortBy">
                                    <option selected value="IDNo">Date Registered</option>
                                    <option value="USERID">Email</option>
                                    <option value="FullName">Name</option>             
                                    <option value="BirthDate">Birth Date</option>                         
                                </select>
                            </div>
                        </div>
                        <div class="form-group col-md-2">
                            <div>
                                <label class="input-txt input-txt-active2 ml-2">
                                    <span><span class="m-2">Order</span></span>
                                </label>
                                <select class="form-control" runat="server" id="cmbOrder">
                                    <option value="ASC">Ascending</option>
                                    <option selected value="DESC">Descending</option>
                                </select>
                            </div>
                        </div>
                       <div class=" form-group col-md-2">
                       
                        <input type="button" runat="server" id="btnFilter" class="form-group col-md-12 btn btn-primary" value="Filter" />
                    </div>
                      </div>
                      
                 
                    


                </div>
                <div class="form-group col-lg-12">
                    <asp:GridView ID="gv_List" runat="server" CssClass="mGrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging"
                        PageSize="15">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />

                        <Columns>
                            <asp:TemplateField HeaderText="Date Registered" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("DateRegistered")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("USERID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Lastname, Firstname" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("FullName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Birth Date" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("BirthDate")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Gender" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Gender")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Contact_Cp")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="Address" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Address")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>


                         

                        </Columns>

                    </asp:GridView>
                      <center> 
                           <a href="#" class="form-group col-md-4 btn btn-primary " onclick="window.open('Report/ReportViewer.aspx?ReportType=TransactionReport');"><i class="fa fa-print"></i>&nbsp Print Report</a>
                </center>
                </div>

              
            </div>
        </ContentTemplate>
    </asp:UpdatePanel> 
    <input type="hidden" id="err" runat="server" />
    <script>
        function ShowSnackBar(color, msg) {
            var x = document.getElementById("snackbar");
            x.style.backgroundColor = color;
            x.innerText = msg;
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        }

     




    </script>
</asp:Content>
