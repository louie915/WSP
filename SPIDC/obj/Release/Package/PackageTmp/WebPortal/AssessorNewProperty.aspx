<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/ASSESSORMaster.Master" CodeBehind="AssessorNewProperty.aspx.vb" Inherits="SPIDC.AssessorNewProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
    </div>
    <div class="row col-lg-12 d-flex align-content-center justify-content-center">
        <div class="col-lg-12" align="center">
            <br />
            <h4>
                <label class=" font-weight-bold text-primary mb-1">Declare New Property List</label></h4>
        </div>

        <div class="col-lg-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Declare New Property</label>
                </div>

                <div class="card-body">
                    <asp:GridView ID="_oGVProperty" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("TRANSDATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" HeaderStyle-Width="25%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("USERID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property ID" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("PROPID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Property" HeaderStyle-Width="25%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("LOCPROPERTY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelStatus" runat="server" Text='<%# If(IsDBNull(Eval("Status")), "Pending", IIf(Eval("Status") = False, "Pending", "Notified"))%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%--<asp:ImageButton runat="server" title="Review" ID="_oButtonReview" src="../CSS_JS_IMG/img/reviewIcon.png"  /> onclick="NPViewDetails('<%# Eval("USERID")%>','<%# Eval("PROPID")%>')" --%>
                                    <a style="width: 20px; height: 20px" href="#" onclick="NPViewDetails('<%# Eval("USERID")%>','<%# Eval("PROPID")%>');SetModalActive();">Show Details</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <input type="hidden" runat="server" id="hdntdn" />
                    <input type="hidden" runat="server" id="hdnuserid" />
                    <input type="hidden" runat="server" id="hdnpropid" />
                    <input type="hidden" runat="server" id="hdnName" />
                    <input type="hidden" runat="server" id="hdnType" />
                    <input type="hidden" runat="server" id="hdnData" />

                    <script>
                        function NPViewDetails(userid, propid) {
                            document.getElementById('<%=hdnuserid.ClientID%>').value = userid;
                            document.getElementById('<%=hdnpropid.ClientID%>').value = propid;
                            __doPostBack('ViewDetails', '');
                        }
                        function NPViewFiles(Name, Type, Data) {
                            document.getElementById('<%=hdnName.ClientID%>').value = Name;
                            document.getElementById('<%=hdnType.ClientID%>').value = Type;
                            document.getElementById('<%=hdnData.ClientID%>').value = Data;
                            __doPostBack('DownloadFiles', '');
                        }
                        function opennewtab() {
                            window.document.forms[0].target = '_blank';
                            setTimeout(function () { window.document.forms[0].target = ''; }, 0);

                        }
                        function SendEmail() {
                            __doPostBack('EmailNotification', '');
                        }
                    </script>
                </div>

            </div>
        </div>
    </div>

    <a id="hbtn" data-toggle="modal" data-dismiss="modal" data-target="#PropertyDetails" style="display: none;"></a>
    <div class="modal fade" id="PropertyDetails">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;">Details</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row mx-auto col-lg-12">
                        <div class="form-group col-md-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Owner Name</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtOwner" name="_oTxtOwner" required disabled />
                            </div>
                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                        <div class="form-group col-md-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Owner Address</span></span>
                                </label>
                                <textarea class="form-control CH-Size-new" runat="server" id="_oTxtOwnerAddress" disabled></textarea>
                            </div>

                        </div>
                    </div>
                    <div class="row mx-auto col-lg-12">
                        <div class="form-group col-md-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Administrator/Beneficial User</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtAdministrator" required disabled />
                            </div>

                        </div>
                        <div class="form-group col-md-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Administrator Address</span></span>
                                </label>
                                <textarea class="form-control CH-Size-new" runat="server" id="_oTxtAdminAddress" disabled></textarea>
                            </div>

                        </div>
                    </div>
                    <div class="row mx-auto col-lg-12">
                        <div class="form-group col-md-4 font-weight-bold">Property Location</div>
                    </div>
                    <div class="row mx-auto col-lg-12">
                        <div class="form-group col-md-3">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Number and Street</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNoSt" disabled />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                        <div class="form-group col-md-3">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Barangay</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBarangay" disabled />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                        <div class="form-group col-md-3">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">District</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtDistrict" disabled />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                    </div>
                    <div class="row mx-auto col-lg-12">

                        <div class="form-group col-md-3">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">OCT/TCT No./CLOA TCT</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtOCT_TCT" required disabled />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>



                        <div class="form-group col-md-3">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Survey No.</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSurveyNo" required disabled />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                        <div class="form-group col-md-3">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Lot No.</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_TxtLotNo" disabled />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                        <div class="form-group col-md-3">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Block No.</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlockNo" disabled />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>

                    </div>
                    <div class="row mx-auto col-lg-12">
                        <div class="form-group col-md-4 font-weight-bold">Property Boundary</div>
                    </div>

                    <%--<div class="row mx-auto col-lg-10">--%>
                    <%--<div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">North</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNorth">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>--%>

                    <%--<div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">South</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSouth">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>--%>
                    <%--</div>--%>
                    <%--<div class="row mx-auto col-lg-10">

            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">East</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtEast">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>

            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">West</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtWest">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
        </div>  --%>
                    <%--<div class="my-2 col-lg-11">
            <button name="_obtnPrint" runat="server" id="_obtnPrint" type="submit" class="btn btn-primary m-2 col-md-5 btn-sm mr-3" style="position: absolute; bottom: 0; right: 0; width: 100px">Print </button>

        </div>--%>
                    <div class="row mt-3 mx-auto col-lg-12">
                        <div class="form-group col-md-3">
                            <div>

                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Area</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtArea" onfocus="(this.type='number')" required disabled />
                            </div>
                        </div>

                        <div class="form-group col-md-3">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Amount Sold</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" onfocus="(this.type='number')" onblur="formatAmountSold(this.value)" runat="server" id="_oTxtAmountSold" disabled />
                            </div>

                        </div>
                        <div class="form-group col-md-6">


                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                    </div>
                    <div class="row mx-auto col-lg-12">
                        <div class="form-group col-md-4 font-weight-bold">Actual Usage</div>
                    </div>
                    <div class="row mt-1 mx-auto col-lg-12">
                        <div class="col-lg-4 row">
                            <div class="form-group col-md-6">
                                <label class="ml-3">Residential</label>
                            </div>
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Area</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtResidentialArea" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required disabled />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 row">
                            <div class="form-group col-md-6">
                                <label class="ml-3">Agricultural</label>
                            </div>
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Area</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtAgricultural" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required disabled />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 row">
                            <div class="form-group col-md-6">
                                <label class="ml-3">Commercial</label>
                            </div>
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Area</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCommercialArea" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required disabled />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 row">
                            <div class="form-group col-md-6">
                                <label class="ml-3">Industrial</label>
                            </div>
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Area</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtIndustrial" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required disabled />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 row">
                            <div class="form-group col-md-6">
                                <label class="ml-3">Mineral</label>
                            </div>
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Area</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtMineral" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required disabled />
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-4 row">
                            <div class="form-group col-md-6">
                                <label class="ml-3">Timberland</label>
                            </div>
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Area</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTimberland" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required disabled />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 row">
                            <div class="form-group col-md-6">
                                <label class="ml-3">Special</label>
                            </div>
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Area</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSpecial" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required disabled />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 row">
                            <div class="form-group col-md-6">
                                <label class="ml-3">Total Area</label>
                            </div>
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <%--<span><span class="m-2">Area</span></span>--%>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTotalArea" disabled />
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--<div class="modal-footer">
                    <button type="button" class="btn btn-primary btn-sm pull-center" data-dismiss="modal" id="_obtnProceed" runat="server">Proceed</button>
                </div>--%>
                    <div class="row  mx-auto col-lg-12">
                        <div class="p-1 col-12 mb-2">
                            <p class="m-2 font-weight-bold">Uploaded files: </p>
                        </div>
                        <div class="form-group col-md-8">

                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Deed of sale </span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtDeedofsale" required disabled />

                            </div>

                        </div>
                        <div class="form-group col-md-4 ">
                            <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();NPViewFiles('DeedSaleName','DeedSaleType','DeedSaleData');">View</a>
                        </div>
                        <div class="form-group col-md-8 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Copy of Title</span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtCopyofTitle" required disabled />
                            </div>

                        </div>
                        <div class="form-group col-md-4 ">
                            <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();NPViewFiles('CopyTitleName','CopyTitleType','CopyTitleData');">View</a>
                        </div>

                        <div class="form-group col-md-8 ">

                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">ECAR (BIR) Proof of Payment</span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtProofofPayment" required disabled />
                            </div>


                        </div>
                        <div class="form-group col-md-4 ">
                            <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();NPViewFiles('ProofPaymentName','ProofPaymentType','ProofPaymentData');">View</a>
                        </div>
                        <div class="form-group col-md-8 ">

                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Tax Clearance</span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtTaxClearance" required disabled />
                            </div>


                        </div>
                        <div class="form-group col-md-4 ">
                            <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();NPViewFiles('TaxClearanceName','TaxClearanceType','TaxClearanceData');">View</a>
                        </div>
                        <div class="form-group col-md-8 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Declaration Copy</span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtDeclarationCopy" required disabled />
                            </div>
                        </div>

                        <div class="form-group col-md-4 ">
                            <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();NPViewFiles('DeclarationCopyName','DeclarationCopyType','DeclarationCopyData');">View</a>
                        </div>
                        <div class="form-group col-md-8 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Secretary Certificate for Corporate property</span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtCorporateProperty" required disabled />
                            </div>
                        </div>

                        <div class="form-group col-md-4 ">
                            <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();NPViewFiles('CorpPropName','CorpPropType','CorpPropData');">View</a>
                        </div>

                        <div class="form-group col-md-8 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Valid ID</span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtValidID" required disabled />
                            </div>
                        </div>

                        <div class="form-group col-md-4 ">
                            <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab();NPViewFiles('ValidIdName','ValidIdType','ValidIdData');">View</a>
                        </div>

                    </div>

                </div>
                <div class="form-group col-md-12 d-flex justify-content-center align-content-center">
                    <a href="#" style="font-size: 14px !Important; height: 35px !Important;" class=" btn btn-warning">FAAS Entry &nbsp<span class="fa fa-book "></span></a>
                    &nbsp &nbsp 
                        <a href="#" style="font-size: 14px !Important; height: 35px !Important;" class=" btn btn-success" data-toggle="modal" data-target="#SendEmailView" data-dismiss="modal">Send Email &nbsp<span class="fa fa-mail-bulk "></span></a>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="SendEmailView">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;">Send Email</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" onclick="timeFunction()" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="col-lg-12 mt-2">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Email Address</span></span>
                            </label>
                            <input type="text" class="form-control CH-Size-new" runat="server" id="_oTxtSEmailAddress" />
                        </div>
                    </div>
                    <div class="col-lg-12 mt-3">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Remarks</span></span>
                            </label>
                            <select id="_oTxtRemarks" class="form-control CH-Size-new" style="height: 30px; padding: 1px 1px 1px 1px;" runat="server">
                                <option value="Notify Taxpayer">Notify Taxpayer</option>
                                <option value="Lacks Mandatory Requirements">Lacks Mandatory Requirements</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-lg-12 mt-3">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Message</span></span>
                            </label>
                            <textarea class="form-control CH-Size-new" runat="server" id="_oTxtSEmail"></textarea>
                        </div>
                    </div>
                    <div class="col-lg-12 mt-3 d-flex align-content-center justify-content-center">
                        <a class="btn btn-danger text-white" onclick="timeFunction()" data-dismiss="modal">Cancel</a>
                        &nbsp&nbsp 
                        <a class="btn btn-success text-white" onclick="SendEmail()">Send</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function timeFunction() {
            setTimeout(function () { var sbtn = document.getElementById('hbtn'); sbtn.click(); }, 500);
        }
        document.addEventListener("DOMContentLoaded", function () {

            if (sessionStorage.getItem("ShowModal")) {
                var sbtn = document.getElementById('hbtn');
                sbtn.click();
                sessionStorage.setItem("ShowModal", "");
            }
            ComputeTotalArea()
        });
        function SetModalActive() {
            sessionStorage.setItem("ShowModal", "ere");
        }


        function ComputeTotalArea() {
            if (document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value == "") {
                document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = 0 + parseFloat(document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value);
            }

            if (document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value == "") {
                document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = parseFloat(document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value) + 0;
            }

            if (document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value == "" && document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value == "") {
                document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = "0.00";
            }

            if (document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value !== "" && document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value !== "") {
                document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = parseFloat(document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value) + parseFloat(document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value);
            }

        };
    </script>
</asp:Content>

