<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="BP_RequirementsSetup.aspx.vb" Inherits="SPIDC.BP_RequirementsSetup" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
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
        <h5 class="m-2 font-weight-bold text-primary">Business Requirements Setup</h5>
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
    <div class="form-row col-lg-12">


        <div class="form-group col-lg-12" style="border-radius: 1vh; border: 1px solid lightgray">

            <div class="form-row col-lg-12" style="padding-top: 2vh">
                <br />
                <br />

                <div class=" form-group col-lg-12">
                    <div class=" form-group col-lg-6">
                        <a href="#" class="btn btn-success" data-toggle="modal" data-dismiss="modal" data-target="#ModalAdd">
                            <i class="fa fa-plus"></i>&nbsp Add Requirements
                        </a>
                    </div>
                </div>

                <div class="form-group col-lg-2">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">OFFICE</span></span>
                    </label>
                    <select runat="server" id="cmbOFFICEFilter" class="form-control" style="display:none;">
                        <option value="ALL">ALL </option>                      
                    </select>
                </div>

                <div class="form-group col-lg-2">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Type</span></span>
                    </label>
                    <select runat="server" id="cmbTypeFilter" class="form-control">
                        <option value="ALL">ALL </option>
                        <option value="NEW">NEW </option>
                        <option value="RENEWAL">RENEWAL </option>
                    </select>

                </div>
                <div class="form-group col-lg-2">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">COMPLIANT</span></span>
                    </label>
                    <select runat="server" id="cmbCompliantFilter" class="form-control">
                        <option value="ALL">ALL </option>
                        <option value="MANDATORY">MANDATORY </option>
                        <option value="OPTIONAL">OPTIONAL </option>
                    </select>

                </div>

                 <div class="form-group col-lg-2">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Sort By</span></span>
                    </label>
                    <select runat="server" id="cmb_SortBy" class="form-control">                    
                        <option selected value="ReqCode">Code </option>
                        <option value="REQDESC">Description </option>
                    </select>

                </div>

                 <div class="form-group col-lg-2">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Order</span></span>
                    </label>
                    <select runat="server" id="cmb_Order" class="form-control">                       
                        <option selected value="ASC">Ascending </option>
                        <option value="DESC">Descending </option>
                    </select>

                </div>

                <div class=" form-group col-lg-2">
                    <a href="#" class="btn btn-primary" runat="server" id="btnFilter">
                        <i class="fa fa-filter"></i>&nbsp Filter
                    </a>
                </div>

            </div>

            <div class="form-group col-lg-12">
                <asp:GridView ID="_GVRequirements" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                    <Columns>
                        <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("ReqDesc")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center"  >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelSwitch" runat="server" Text='<%# Eval("Switch")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="COMPLIANT" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelCOMPLIANT" runat="server" Text='<%# Eval("WEBCOMPLIANT")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>                            
                                <div class="form-row col-lg-12">
                                     <a href="#" class="btn btn-success form-group  col-lg-6" onclick="get_Edit('<%# Eval("ReqCode")%>','<%# Eval("Switch")%>','<%# Eval("WEBCOMPLIANT")%>','<%# Eval("ReqDesc")%>');"
                                    data-toggle="modal" data-dismiss="modal" data-target="#ModalEdit"><i class="fa fa-Edit"></i>&nbsp Edit</a>
                                <a href="#" class="btn btn-danger form-group  col-lg-6" id="a_Edit" onclick="get_Remove('<%# Eval("ReqCode")%>','<%# Eval("Switch")%>','<%# Eval("WEBCOMPLIANT")%>','<%# Eval("ReqDesc")%>');"
                                   data-toggle="modal" data-dismiss="modal" data-target="#ModalRemove"><i class="fa fa-trash-o"></i>&nbsp Remove</a>
                                </div>
                               
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>





        </div>


    </div>
    <div class="modal fade" id="ModalEdit">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h4 class="modal-title text-white">Edit BP Requirements</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="text-align: left">
                    <div class="form-row col-lg-12">

                        <div class="form-group col-lg-6">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Type</span></span>
                            </label>
                            <select runat="server" id="cmb_EditType" class="form-control">
                                <option value="NEW">NEW </option>
                                <option value="RENEWAL">RENEWAL </option>
                            </select>

                        </div>

                        <div class="form-group col-lg-6">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Compliant</span></span>
                            </label>
                            <select runat="server" id="cmb_EditCompliant" class="form-control">
                                <option value="MANDATORY">MANDATORY </option>
                                <option value="OPTIONAL">OPTIONAL </option>
                            </select>

                        </div>

                        <div class="form-group col-lg-12">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Description</span></span>
                            </label>
                            <textarea runat="server" style="height: 10vh" class="form-control" required id="txt_EditDesc"></textarea>
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
                    <h4 class="modal-title text-white">Add Requirements</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="text-align: left">
                    <div class="form-row col-lg-12">

                        <div class="form-group col-lg-6">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Type</span></span>
                            </label>
                            <select runat="server" id="cmb_AddType" class="form-control">
                                <option value="NEW">NEW </option>
                                <option value="RENEWAL">RENEWAL </option>
                            </select>

                        </div>

                        <div class="form-group col-lg-6">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Compliant</span></span>
                            </label>
                            <select runat="server" id="cmb_AddCompliant" class="form-control">
                                <option value="MANDATORY">MANDATORY </option>
                                <option value="OPTIONAL">OPTIONAL </option>
                            </select>

                        </div>

                        <div class="form-group col-lg-12">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Description</span></span>
                            </label>
                            <textarea runat="server" style="height: 10vh" class="form-control" required id="txt_AddDesc"></textarea>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="form-row col-lg-12">
                        <div class=" form-group col-lg-6">
                            <button type="button" class="btn btn-success" style="width: 100%" id="btnSaveAdd" name="btnSaveAdd" runat="server" onclick="do_Save(this.id,'ADD');">Save</button>
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
                    <h4 class="modal-title text-white">Remove Requirement</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    Are you sure you want to remove this record?<br />
                    <table >
                        <tr>
                            <td>Type</td>
                            <td> : </td>
                            <td> <label runat="server" id="lbl_DelType" ></label></td>
                        </tr>
                        <tr>
                            <td>Compliant</td>
                            <td> : </td>
                            <td> <label runat="server" id="lbl_DelCompliant" ></label></td>
                        </tr>
                        <tr>
                            <td>Description</td>
                            <td> : </td>
                            <td> <label runat="server" id="lbl_DelDesc" ></label></td>
                        </tr>
                    </table>
                 
                
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

    <input type="hidden" runat="server" id="hdn_Code" name="hdn_Code" />
    <input type="hidden" runat="server" id="hdn_Type" name="hdn_Type" />
    <input type="hidden" runat="server" id="hdn_Compliant" name="hdn_Compliant" />
    <input type="hidden" runat="server" id="hdn_DelDesc" name="hdn_DelDesc" />

    <script>
        function do_Save(id) {
            document.getElementById(id).disabled = true;
            document.getElementById(id).value = 'Saving...';
        }

        function get_Remove(id, Type, Compliant, Desc) {          
            document.getElementById('<%= hdn_Code.ClientID%>').value = id;
            document.getElementById('<%= hdn_Type.ClientID%>').value = Type;
            document.getElementById('<%= hdn_Compliant.ClientID%>').value = Compliant;
            document.getElementById('<%= hdn_DelDesc.ClientID%>').value = Desc;


            document.getElementById('<%= lbl_DelType.ClientID%>').innerHTML = Type;
            document.getElementById('<%= lbl_DelCompliant.ClientID%>').innerHTML = Compliant;
            document.getElementById('<%= lbl_DelDesc.ClientID%>').innerHTML = Desc;   


        }

        function get_Edit(id, Type, Compliant, Desc) {         
            document.getElementById('<%= hdn_Code.ClientID%>').value = id;
            document.getElementById('<%= cmb_EditType.ClientID%>').value = Type;
            document.getElementById('<%= cmb_EditCompliant.ClientID%>').value = Compliant;
            document.getElementById('<%= txt_EditDesc.ClientID%>').value = Desc;        
        }







    </script>
</asp:Content>
