<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="AppointmentTypeSetup.aspx.vb" Inherits="SPIDC.AppointmentTypeSetup" EnableEventValidation="false" %>

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
        <h5 class="m-2 font-weight-bold text-primary">Appointment Type Setup</h5>
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

            <div class="form-row col-lg-6" style="padding-top: 2vh">
                <br />
                <br />
                <div class="form-group col-lg-6">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Select Department</span></span>
                    </label>
                    <select runat="server" onchange="do_Change(this.value)" name="cmbDepartment2" id="cmbDepartment2" class="form-control">
                    </select>
                    <asp:Button runat="server" ID="btnOnChange" OnClick="Department2_OnChange" UseSubmitBehavior="false" Style="display: none;" />
                </div>

                <div class=" form-group col-lg-6">
                    <a href="#" class="btn btn-primary" data-toggle="modal" data-dismiss="modal" data-target="#ModalAdd">
                        <i class="fa fa-plus"></i>&nbsp  Add Appointment Type
                    </a>
                </div>

            </div>

            <div class="form-group col-lg-12">
                <asp:GridView ID="gv_AppointmentReq" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                    <Columns>
                        <asp:TemplateField HeaderText="Appointment Type" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelType" runat="server" Text='<%# Eval("Type")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Header" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelHeader" runat="server" Text='<%# Eval("Header")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Body" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelBody" runat="server" Text='<%# Eval("Display")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Footer" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelFooter" runat="server" Text='<%# Eval("Footer")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <a href="#" class="btn btn-success" onclick="get_Edit('<%# Eval("Type")%>','<%# Eval("Header")%>','<%# Eval("Body")%>','<%# Eval("Footer")%>');"
                                    style="width: 100%; font-size: small; text-align: left" data-toggle="modal" data-dismiss="modal" data-target="#ModalEdit"><i class="fa fa-Edit"></i>&nbsp Edit</a>
                                <a href="#" class="btn btn-danger" onclick="get_Remove('<%# Eval("Department")%>','<%# Eval("Type")%>');"
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
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h4 class="modal-title text-white">Edit Appointment Type</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="text-align: left">
                    <div class="form-row col-lg-12">
                        <div class="form-group col-lg-6">
                            <div class="form-row col-lg-12">
                                <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Appointment Type</span></span>
                                    </label>
                                    <input required type="text" class="form-control" runat="server" id="Edit_Type" />
                                </div>
                                <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Header</span></span>
                                    </label>
                                    <input required type="text" class="form-control" runat="server" id="Edit_Header" />
                                </div>
                                <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Requirements (Separated by New line)</span></span>
                                    </label>
                                    <textarea required rows="5" class="form-control" runat="server" id="Edit_Body"></textarea>
                                </div>
                                <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Footer</span></span>
                                    </label>
                                    <input required type="text" class="form-control" runat="server" id="Edit_Footer" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group col-lg-6" style="border: 1px solid lightgray; min-height: 100%">
                            <h6 class="m-0 font-weight-bold text-primary">Preview:</h6>
                            <div id="div_Reqs2" runat="server">
                                <a id="_opheader2"></a>
                                <div id="_opbody2"></div>
                                <a id="_opfooter2"></a>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="modal-footer">
                    <div class="form-row col-lg-12">
                        <div class="form-group col-lg-6">
                            <input type="button" id="btnEditSave" runat="server" value="Save" class="btn btn-success" style="width: 100%" />
                        </div>
                        <div class="form-group col-lg-6">
                            <input type="button" value="Cancel" class="btn btn-danger"  data-dismiss="modal"  style="width: 100%" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="ModalAdd">
        <div class="modal-dialog modal-lg">
            <div class="modal-content ">
                <div class="modal-header bg-primary">
                    <h4 class="modal-title text-white">Add Appointment Type</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="text-align: left">
                    <div class="form-row col-lg-12">
                        <div class="form-group col-lg-6">
                            <div class="col-lg-12">
                                <h6 class="m-0 font-weight-bold text-primary">Select Department:</h6>
                                <select name="cmbDepartment" required id="cmbDepartment" runat="server" class="form-control">
                                </select>
                            </div>

                            <div class="col-lg-12">
                                <h6 class="m-0 font-weight-bold text-primary">Enter Appointment Type:</h6>
                                <input type="text" runat="server" class="form-control" required id="_oTxtType" />

                            </div>

                            <div class="col-lg-12">
                                <h6 class="m-0 font-weight-bold ">Enter Header:</h6>
                                <input type="text" runat="server" class="form-control" required id="_oTxtHeader" />

                            </div>

                            <div class="col-lg-12">
                                <h6 class="m-0 font-weight-bold ">Enter Requirements:</h6>
                                <textarea runat="server" class="form-control h-25" required id="_oTxtTypeR"></textarea>


                            </div>
                            <div class="form-group col-lg-12">
                                <h6 class="m-0 font-weight-bold ">Enter Footer:</h6>
                                <input type="text" runat="server" class="form-control" required id="_oTxtFooter" />

                            </div>


                        </div>
                        <div class="form-group col-lg-6" style="border: 1px solid lightgray; min-height: 100%">
                            <h6 class="m-0 font-weight-bold text-primary">Preview:</h6>
                            <div id="div_Reqs" runat="server">
                                <a id="_opheader"></a>
                                <div id="_opbody"></div>
                                <a id="_opfooter"></a>
                            </div>
                        </div>

                        <textarea id="Purpose" name="Purpose" class="form-control CH-size" style="display: none; height: 100px" placeholder="Please state your purpose of Appointment"></textarea>
                        <input name="DepartmentDesc" id="DepartmentDesc" type="hidden" />
                        <input name="DepartmentValue" id="DepartmentValue" type="hidden" />
                        <input name="AppointmentType" id="AppointmentType" type="hidden" />
                        <input name="xSubmit" id="xSubmit" type="hidden" value="False" />
                        <input name="xPurpose" id="xPurpose" type="hidden" />

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
                    <h4 class="modal-title text-white">Remove Appointment Type</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    Are you sure you want to remove this record?<br />
                    Appointment Type :
                            <label id="lbl_Type"></label>
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




    <input type="hidden" id="hdnType" runat="server" />
    <input type="hidden" id="hdnDepartment" runat="server" />
    <input type="hidden" id="hdnHeader" runat="server" />
    <input type="hidden" id="hdnBody" runat="server" />
    <input type="hidden" id="hdnFooter" runat="server" />


    <script>
        function do_Change(val) {
            document.getElementById("<%=hdnDept2.ClientID%>").value = val;
                document.getElementById("<%=btnOnChange.ClientID%>").click();
            }

            function get_Remove(Department, val) {
                document.getElementById("<%=hdnType.ClientID%>").value = val;
                document.getElementById("<%=hdnDepartment.ClientID%>").value = Department;
                document.getElementById('lbl_Type').innerText = val;
            }
            function get_Edit(Type, Header, Body, Footer) {
                document.getElementById("<%=hdnType.ClientID%>").value = Type;
                document.getElementById("<%=hdnHeader.ClientID%>").value = Header;
                document.getElementById("<%=hdnBody.ClientID%>").value = Body;
                document.getElementById("<%=hdnFooter.ClientID%>").value = Footer;

                document.getElementById("<%=Edit_Type.ClientID%>").value = Type;
                document.getElementById("<%=Edit_Header.ClientID%>").value = Header;
                document.getElementById("<%=Edit_Body.ClientID%>").innerHTML = Body.replaceAll(';', '\n');;
                document.getElementById("<%=Edit_Footer.ClientID%>").value = Footer;

                var orig_Text = document.getElementById("<%=Edit_Body.ClientID%>").value;
                var new_Text = '';
                var mod_Text = orig_Text
                var arr = mod_Text.split('\n')
                mod_Text = '';
                for (var i = 0; i < arr.length ; i++) {
                    mod_Text += '<li>' + arr[i] + '</li>';
                    new_Text += arr[i] + ';'
                }
                document.getElementById("_opbody2").innerHTML = '<ul> ' + mod_Text + '</ul>';
                document.getElementById('<%=_ohdnAppType2.ClientID%>').value = new_Text;

                    document.getElementById("_opheader2").innerHTML = document.getElementById("<%=Edit_Header.ClientID%>").value;
                document.getElementById("_opfooter2").innerHTML = document.getElementById("<%=Edit_Footer.ClientID%>").value;

            }

            document.getElementById("<%=_oTxtHeader.ClientID%>").onkeyup = function () {
            document.getElementById("_opheader").innerHTML = document.getElementById("<%=_oTxtHeader.ClientID%>").value;
                }
                document.getElementById("<%=_oTxtFooter.ClientID%>").onkeyup = function () {
            document.getElementById("_opfooter").innerHTML = document.getElementById("<%=_oTxtFooter.ClientID%>").value;
                }

                document.getElementById("<%=_oTxtTypeR.ClientID%>").onkeyup = function () {
            var orig_Text = document.getElementById("<%=_oTxtTypeR.ClientID%>").value;
                    var new_Text = '';
                    var mod_Text = orig_Text
                    var arr = mod_Text.split('\n')
                    mod_Text = '';
                    for (var i = 0; i < arr.length ; i++) {
                        mod_Text += '<li>' + arr[i] + '</li>';
                        new_Text += arr[i] + ';'
                    }
                    document.getElementById("_opbody").innerHTML = '<ul> ' + mod_Text + '</ul>';
                    document.getElementById('<%=_ohdnAppType.ClientID%>').value = new_Text;
                }

                document.getElementById("<%=Edit_Header.ClientID%>").onkeyup = function () {
            document.getElementById("_opheader2").innerHTML = document.getElementById("<%=Edit_Header.ClientID%>").value;
                }
                document.getElementById("<%=Edit_Footer.ClientID%>").onkeyup = function () {
            document.getElementById("_opfooter2").innerHTML = document.getElementById("<%=Edit_Footer.ClientID%>").value;
            }
            document.getElementById("<%=Edit_Body.ClientID%>").onkeyup = function () {
            var orig_Text = document.getElementById("<%=Edit_Body.ClientID%>").value;
                var new_Text = '';
                var mod_Text = orig_Text
                var arr = mod_Text.split('\n')
                mod_Text = '';
                for (var i = 0; i < arr.length ; i++) {
                    mod_Text += '<li>' + arr[i] + '</li>';
                    new_Text += arr[i] + ';'
                }
                document.getElementById("_opbody2").innerHTML = '<ul> ' + mod_Text + '</ul>';
                document.getElementById('<%=_ohdnAppType2.ClientID%>').value = new_Text;
            }


            function doSelectDept(Action, Val) {
                __doPostBack(Action, Val);
            }

            function AfterSaving() {

            }






    </script>
</asp:Content>
