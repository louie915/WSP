<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="DepartmentSetup.aspx.vb" Inherits="SPIDC.DepartmentSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };


    </script>
    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Web Department Setup</h5>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="snackbar" style="position: absolute">
                <asp:Label runat="server" ID="_oLabelSnackbar" />
            </div>
            <div id="snackbargreen" style="position: absolute">
                <asp:Label runat="server" ID="_oLabelSnackbargreen" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="form-row col-lg-16">


        <div class="form-group col-lg-12" style="border-radius: 1vh; border: 1px solid lightgray">

            <div class="form-row col-lg-6" style="padding-top: 2vh">
                <br />
                <br />
                <div class=" form-group col-lg-6">
                    <a href="#" class="btn btn-primary" data-toggle="modal" data-dismiss="modal" data-target="#ModalAdd">
                        <i class="fa fa-plus"></i>&nbsp  Add Department
                    </a>
                </div>

            </div>

            <div class="form-group col-lg-12">
                <asp:GridView ID="gv_Department" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                    <Columns>
                        <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("DepartmentCode")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("Department")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="User Type" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelUserType" runat="server" Text='<%# Eval("UserType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Regulatory" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelRegulatory" runat="server" Text='<%# Eval("Regulatory")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <a href="#" class="btn btn-success" onclick="get_Edit('<%# Eval("DepartmentCode")%>','<%# Eval("Department")%>','<%# Eval("UserType")%>','<%# Eval("Regulatory")%>');"
                                    style="width: 100%; font-size: small; text-align: left" data-toggle="modal" data-dismiss="modal" data-target="#ModalEdit"><i class="fa fa-Edit"></i>&nbsp Edit</a>
                                <a href="#" class="btn btn-danger" onclick="get_Remove('<%# Eval("DepartmentCode")%>','<%# Eval("UserType")%>');"
                                    style="width: 100%; font-size: small; text-align: left" data-toggle="modal" data-dismiss="modal" data-target="#ModalRemove"><i class="fa fa-remove"></i>&nbsp Remove</a>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>





        </div>

        <input type="hidden" runat="server" id="hdnDept2" />



        <div style="display: none">

            <asp:HiddenField ID="_ohdnAppType" runat="server" />
            <asp:HiddenField ID="_ohdnAppType2" runat="server" />
            <h6 class="m-0 font-weight-bold text-primary">Select Department:</h6>
            <select name="test1" id="test1" runat="server" class="form-control">
                <%--onchange="filter();">--%>
            </select>
            <br />
            <h6 class="m-0 font-weight-bold text-primary">Select Appointment Type:</h6>

        </div>

    </div>
    <div class="modal fade" id="ModalEdit">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h4 class="modal-title text-white">Edit Department</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="text-align: left">
                      <div class="form-group col-lg-6">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Department Code</span></span>
                            </label>
                            <input required type="text" class="form-control" runat="server" readonly id="Edit_DepartmentCode" />
                        </div>

                    <div class="form-row col-lg-12">
                        <div class="form-group col-lg-12">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Department Description</span></span>
                            </label>
                            <input required type="text" class="form-control" runat="server" id="Edit_Department" />
                        </div>

                        <div class="form-group col-lg-6">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">User Type</span></span>
                            </label>
                            <input required type="text" class="form-control" runat="server" id="Edit_Usertype" />
                        </div>

                        <div class="form-group col-lg-6">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Regulatory</span></span>
                            </label>
                            <select runat="server" class="form-control" id="Edit_Regulatory">                                
                                <option selected value="0">No</option>
                                <option value="1">Yes</option>
                            </select>
                        </div>

                    </div>

                </div>
                <div class="modal-footer">
                    <div class="form-row col-lg-12">
                        <div class="form-group col-lg-6">
                            <input type="button" id="btnEditSave" runat="server" value="Save" class="btn btn-success" style="width: 100%" />
                        </div>
                        <div class="form-group col-lg-6">
                            <input type="button" value="Cancel" class="btn btn-danger" data-dismiss="modal" style="width: 100%" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalAdd">
        <div class="modal-dialog modal-md">
            <div class="modal-content ">
                <div class="modal-header bg-primary">
                    <h4 class="modal-title text-white">Add Department</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="text-align: left">
                    <div class="form-row col-lg-12">      
                             <div class="form-group col-lg-6">
                                <h6 class="m-0 font-weight-bold ">Department Code</h6>                               
                                 <input type="text" runat="server" class="form-control" required id="_oTxtDepartmentCode" />
                            </div>
                                                                  
                            <div class="form-group col-lg-12">
                                <h6 class="m-0 font-weight-bold ">Department Description</h6>
                                <input type="text" runat="server" class="form-control" required id="_oTxtDepartment" />

                            </div>

                            <div class="form-group col-lg-6">
                                <h6 class="m-0 font-weight-bold ">User Type</h6>                               
                                 <input type="text" runat="server" class="form-control" required id="_oTxtUsertype" />
                            </div>

                            <div class="form-group form-group col-lg-6">
                                <h6 class="m-0 font-weight-bold ">Regulatory</h6>
                                <select runat="server" class="form-control" id="_oTxtRegulatory">
                                       <option selected value="0">No</option>
                                    <option value="1">Yes</option>
                                 
                                </select>

                            </div>


                   

                    </div>
                </div>
                <div class="modal-footer">
                    <div class="form-row col-lg-12">
                        <div class=" form-group col-lg-6">
                            <button type="button" class="btn btn-success" style="width: 100%" data-toggle="modal" id="_obtnProceed" runat="server">Save</button>
                        </div>
                        <div class=" form-group col-lg-6">
                            <input type="button" value="Cancel" class="btn btn-danger" data-dismiss="modal" style="width: 100%" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="ModalRemove">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h4 class="modal-title text-white">Remove Department</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <b><i>All web accounts associated with this department will also be REMOVED.</i></b><br />
                    Are you sure you want to remove this record?<br />
                    User Type :
                            <label id="lbl_Usertype"></label>
                </div>
                <div class="modal-footer">
                    <div class="form-row col-lg-12">
                        <div class=" form-group col-lg-6">
                            <button type="button" class="btn btn-success" style="width: 100%" data-toggle="modal" id="btnRemove" runat="server">Yes</button>
                        </div>
                        <div class=" form-group col-lg-6">
                            <input type="button" value="No" class="btn btn-danger" data-dismiss="modal" style="width: 100%" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




    <input type="hidden" id="hdnDepartmentCode" runat="server" />
    <input type="hidden" id="hdnDepartment" runat="server" />
    <input type="hidden" id="hdnUsertype" runat="server" />
    <input type="hidden" id="hdnRegulatory" runat="server" />


    <script>

        function get_Remove(DepartmentCode, Usertype) {
            document.getElementById("<%=hdnDepartmentCode.ClientID%>").value = DepartmentCode;
            document.getElementById("<%=hdnUsertype.ClientID%>").value = Usertype;
            document.getElementById('lbl_Usertype').innerText = Usertype;
        }
        function get_Edit(DepartmentCode, Department, Usertype, Regulatory) {
            document.getElementById("<%=hdnDepartmentCode.ClientID%>").value = DepartmentCode;
            document.getElementById("<%=hdnDepartment.ClientID%>").value = Department;
            document.getElementById("<%=hdnUsertype.ClientID%>").value = Usertype;
            document.getElementById("<%=hdnRegulatory.ClientID%>").value = Regulatory;

            document.getElementById("<%=Edit_DepartmentCode.ClientID%>").value = DepartmentCode;
            document.getElementById("<%=Edit_Department.ClientID%>").value = Department;
            document.getElementById("<%=Edit_Usertype.ClientID%>").value = Usertype;
            document.getElementById("<%=Edit_Regulatory.ClientID%>").value = Regulatory;

        }

    </script>
</asp:Content>
