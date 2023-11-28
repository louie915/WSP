<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/WebPortal/SchedulerMaster.Master" CodeBehind="SchedulerHistory.aspx.vb" Inherits="SPIDC.SchedulerHistory" %>

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
                    <h4 class="modal-title">Appointment Summary</h4>
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
        <h5 class="m-2 font-weight-bold text-primary">Appointment History</h5>
    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row col-lg-12">
                <div class="form-group col-lg-2">
                    <div>
                        <label class="input-txt input-txt-active2 ml-2">
                            <span><span class="m-2">Search By</span></span>
                        </label>
                        <select class="form-control" runat="server" id="cmbSearch">
                            <option value="AppID" selected>Appointment ID</option>
                            <option value="Email">Email</option>
                            <option value="Owner">Name</option>
                        </select>
                    </div>
                </div>
                <div class="form-group col-lg-2">
                    <div>
                        <input type="text" class="form-control" runat="server" id="txtSearch" />
                    </div>
                </div>
                <div class="form-group col-lg-1">
                    <div>
                        <input type="button" class="form-control btn btn-primary" runat="server" id="btnSearch" value="Search" />
                    </div>
                </div>
                <div class="form-row col-lg-12">

                    <div class=" form-row form-group col-md-6">
                        <div class="form-group col-md-4">
                            <div>
                                <label class="input-txt input-txt-active2 ml-2">
                                    <span><span class="m-2">Scheduled By</span></span>
                                </label>
                                <select class="form-control" runat="server" id="cmbScheduledBy">
                                </select>
                            </div>
                        </div>
                        <div class="form-group col-md-4">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">(Appointment) Date From</span></span>
                                </label>
                                <input runat="server" id="txtAppDateFrom" type="text" class="form-control" />

                            </div>
                        </div>
                        <div class="form-group col-md-4">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">(Appointment) Date To</span></span>
                                </label>
                                <input runat="server" id="txtAppDateTo" type="text" class="form-control" />

                            </div>
                        </div>
                        <div class="form-group col-md-4">
                            <div>
                                <label class="input-txt input-txt-active2 ml-2">
                                    <span><span class="m-2">Department</span></span>
                                </label>
                                <select class="form-control" runat="server" id="cmbDepartment">
                                </select>
                            </div>
                        </div>
                        <div class="form-group col-md-4">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">(Transaction) Date From</span></span>
                                </label>
                                <input runat="server" id="txtTransDateFrom" type="text" class="form-control" />

                            </div>
                        </div>
                        <div class="form-group col-md-4">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">(Transaction) Date To</span></span>
                                </label>
                                <input runat="server" id="txtTransDateTo" type="text" class="form-control" />

                            </div>
                        </div>
                    </div>
                    <div class=" form-row form-group col-md-3">
                        <div class="form-group col-md-6">
                            <div>
                                <label class="input-txt input-txt-active2 ml-2">
                                    <span><span class="m-2">Sort By</span></span>
                                </label>
                                <select class="form-control" runat="server" id="cmbSortBy">
                                    <option value="A.AppDate">Appointment Date</option>
                                    <option value="A.AppID">Appointment ID</option>
                                    <option value="A.NewName">Name</option>
                                    <option selected value="A.TransDate">Transaction Date</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group col-md-6">
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
                        <input type="button" runat="server" id="btnFilter" class="form-group col-md-12 btn btn-primary" value="Filter" />
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
                            <asp:TemplateField HeaderText="Scheduled By" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Email")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Appointment ID" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("AppID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("NewName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Appointment Date" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("NewAppDate")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Transaction Date" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("NewTransDate")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>

                                    <a href="#" class="btn btn-primary  col-12" onclick="do_Info('<%# Eval("AppID")%>', '<%# Eval("NewName")%>', '<%# Eval("NewContact")%>', '<%# Eval("Department")%>', '<%# Eval("TransType")%>', '<%# Eval("NewAppDate")%>', '<%# Eval("Purpose")%>', '<%# Eval("Remarks")%>')">Details</a>

                                    <a href="#" style="display: none;" id="aShowModal" data-toggle="modal" data-dismiss="modal" data-target="#AppointmentSummary" data-ticket-type="standard-access">test</a>

                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>

                    </asp:GridView>
                      <center> 
                           <a href="#" class="form-group col-md-4 btn btn-primary " onclick="window.open('Report/ReportViewer.aspx?ReportType=AppointmentList');"><i class="fa fa-print"></i>&nbsp Print Report</a>
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

        function do_Info(AppID, NAME, CONTACT, DEPARTMENT, TYPE, AppDate, PURPOSE, Remarks) {
            document.getElementById('<%= lblAppDate.ClientID%>').innerText = AppDate;
            document.getElementById('<%= lblAppID.ClientID%>').innerText = AppID;
            document.getElementById('<%= lblContact.ClientID%>').innerText = CONTACT;
            document.getElementById('<%= lblDepartment.ClientID%>').innerText = DEPARTMENT;
            document.getElementById('<%= lblName.ClientID%>').innerText = NAME;
            document.getElementById('<%= lblPurpose.ClientID%>').innerText = PURPOSE;
            document.getElementById('<%= lblType.ClientID%>').innerText = TYPE;
            document.getElementById('<%= lblRemarks.ClientID%>').innerHTML = Remarks;
            document.getElementById('aShowModal').click();
        }

        function do_Print() {
            var AppID = document.getElementById('<%= lblAppID.ClientID%>').innerText;
            window.open('Report/ReportViewer.aspx?ReportType=AppointmentSlip&AppID=' + AppID);
        }




    </script>
</asp:Content>
