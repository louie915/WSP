<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="UserAccountManagement.aspx.vb" Inherits="SPIDC.UserAccountManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../CSS_JS_IMG/css/newcss/TableResponsiveMB.css" rel="stylesheet" />
    <script>
        //SNACKBAR - Welcome       
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };
    </script>
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>
    <div class=" p-1">
        <h5 class="m-1 font-weight-bold text-primary">User Accounts Management</h5>
    </div>
    <div class="row justify-content-center align-items-center form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
            <div class="card shadow">
                <div class="">
                    <div class=" m-2">
                        <asp:GridView ID="GV_UserAccount" runat="server" CssClass="mgrid" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AlternatingRowStyle-BackColor="">

                            <%--<FooterStyle CssClass="GridViewFooterStyle" />
                     <RowStyle CssClass="GridViewRowStyle"  />
                     <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                     <PagerStyle CssClass="GridViewPagerStyle" />
                     <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                     <HeaderStyle CssClass="GridViewHeaderStyle" />--%>


                            <Columns>

                                <asp:TemplateField HeaderText="Email Address" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" style="color: blue" onclick="Select('EditRecord','<%# Eval("IDNO")%>')"><%# Eval("UserID")%></a><asp:LinkButton ID="_oLabelBusIDNumber" runat="server" Text='' CssClass="link-label" /></a>                   
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# String.Format("{0} {1} {2}", Eval("FirstName"), Eval("MiddleName"), Eval("LastName"))%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Office" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Office_Value_Filter(Eval("Office").ToString())%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="User Level" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# UserLevel_Value_Filter(Eval("UserLevel").ToString())%>' />

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Activated" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelIsActivated" runat="server" Text='<%# Eval("IsActivated")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <%--  <a id="ShowDeleteModal" class="btn btn-danger btn-sm d-flex align-content-center justify-content-center" style="height:25px;width:25px" onclick="setActive(this.id);Select('DeleteRecord','<%# Eval("IDNO")%>')"><i class="fa fa-remove icon" style="color:white"></i></a>                                        --%>

                                        <a href="#" data-toggle="modal" data-dismiss="modal" data-target="#DeleteConfirmation" data-ticket-type="standard-access" onclick="do_Delete('<%# Eval("IDNO")%>')"><b class="fa fa-trash" style="color: red"></b></a>
                                  
                                    </ItemTemplate>
                                </asp:TemplateField>

                              
                            </Columns>

                        </asp:GridView>
                        <br />
                        <br />
                        <asp:GridView ID="GV_TaxPayer" runat="server" CssClass="mgrid" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AlternatingRowStyle-BackColor="">


                            <Columns>

                                <asp:TemplateField HeaderText="Email Address" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a href="#" style="color: blue" onclick="Select('EditRecord','<%# Eval("IDNO")%>')"><%# Eval("UserID")%></a><asp:LinkButton ID="_oLabelBusIDNumber" runat="server" Text='' CssClass="link-label" /></a>                   
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusOwnerManager" runat="server" Text='<%# String.Format("{0} {1} {2}", Eval("FirstName"), Eval("MiddleName"), Eval("LastName"))%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Office" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusName" runat="server" Text='<%# Office_Value_Filter(Eval("Office").ToString())%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="User Level" HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelBusAddress" runat="server" Text='<%# UserLevel_Value_Filter(Eval("UserLevel").ToString())%>' />

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Activated" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelIsActivated" runat="server" Text='<%# Eval("IsActivated")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <a id="ShowDeleteModal" class="btn btn-danger btn-sm d-flex align-content-center justify-content-center" style="height: 25px; width: 25px" onclick="setActive(this.id);Select('DeleteRecord','<%# Eval("IDNO")%>')"><i class="fa fa-remove icon" style="color: white"></i></a>


                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>

                        </asp:GridView>

                              <input type="hidden" id="hdnID" runat="server" />
                        <script>
                            function do_Delete(ID) {
                                document.getElementById('<%= hdnID.ClientID%>').value = ID;
                            }

                            function Select(Action, Val) {
                                __doPostBack(Action, Val);
                            }
                            function SelectDel(Action, Val) {

                            }


                        </script>
                        <div class="col-12" style="color: #7e7e7e">
                            <div class="m-2 col-12 d-flex justify-content-center align-content-center">
                                <a href="UserAccountManagementRegister.aspx" class="btn btn-success btn-sm">Create New Account  <i class="fa fa-plus icon"></i></a>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

    <div id="DeleteConfirmation" class="modal fade show">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Delete Record</h4>
                    <button id="CancelDeletion2" class="close" data-dismiss="modal" aria-label="Close" onclick="setActive(this.id);">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        Do you want to delete this record?                                
                    </div>
                  <br /><br />
                    <div class="form-row col-sm-12">
                          <input type="button" class="btn btn-success col-sm-6" value="Yes" runat="server" id="btnDelete" />
                            <input type="button" class="btn btn-danger col-sm-6" value="No" />
                    </div>
                 




                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <div id="ModalBG" class='modal-backdrop fade show' style="display: none"></div>
</asp:Content>
