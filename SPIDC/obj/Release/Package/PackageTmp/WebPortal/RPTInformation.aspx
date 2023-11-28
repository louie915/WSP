<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="RPTInformation.aspx.vb" Inherits="SPIDC.RPTInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Real Property Information</h5>
    </div>

    <div class="card shadow">
        <div class="m-2">
            <div class="form-row form mt-3 mx-auto col-lg-10">
                <div class="form-group col-md-5">
                    <div>

                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Tax Declaration No. </span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtTaxDecNo" disabled>
                    </div>
                </div>

                <div class="form-group col-md-5">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span>Property Identification No.</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtPropertyIdentificationNumber" disabled>
                    </div>

                </div>
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Updated Cd.</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtUpdatedCd" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>
            <div class="form-row form mx-auto col-lg-10">
                <div class="form-group col-md-10">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Property Owner</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtPropOwner" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">TIN</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtTIN1" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>
            <div class="form-row form mx-auto col-lg-10">
                <div class="form-group col-md-10">
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
                            <span><span class="m-2">Tel. No</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" runat="server" id="_oTxtOwnerTelNo" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>

            <div class="form-row form mx-auto col-lg-10">

                <div class="form-group col-md-10">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Administrator/Beneficial User</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtAdministrator" disabled>
                    </div>

                </div>

                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">TIN</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtTIN2" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

            </div>
            <div class="form-row form mx-auto col-lg-10">
                <div class="form-group col-md-10">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Administrator Address</span></span>
                        </label>
                        <textarea class="form-control CH-Size-New" runat="server" id="_oTxtAdminAddress" disabled></textarea>
                    </div>

                </div>
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Tel. No</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" runat="server" id="_oTxtAdminTelNo" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>
            <div class="form-row form mx-auto col-lg-10">
                <div class="form-group col-md-4 font-weight-bold">Property Location</div>
            </div>
            <div class="form-row form mx-auto col-lg-10">

                <div class="form-group col-md-10">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">Number and Street</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtNoSt" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Barangay</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtBarangay" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>
            <div class="form-row form mx-auto col-lg-10">

                <div class="form-group col-md-8">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">OCT/TCT No./CLOA TCT</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtOCT_TCT" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Date</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtOCTDate" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Survey No.</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtSurveyNo" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

            </div>

            <div class="form-row form mx-auto col-lg-10">

                <div class="form-group col-md-6">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">CCT</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtCCT" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Date</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_TxtCCTDate" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Lot No.</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_TxtLotNo" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-2">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Block No.</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtBlockNo" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

            </div>
            <div class="form-row form mx-auto col-lg-10">
                <div class="form-group col-md-4 font-weight-bold">Property Boundary</div>
            </div>
            <div class="form-row form mx-auto col-lg-10">

                <div class="form-group col-md-6">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">North</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtNorth" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-6">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">South</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtSouth" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>
            <div class="form-row form mx-auto col-lg-10">

                <div class="form-group col-md-6">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">East</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtEast" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-6">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">West</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtWest" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>


            <div class="form-row form mx-auto col-lg-10">
                <div class="form-group col-md-4 font-weight-bold">Kind of Property</div>
            </div>
            <div class="form-row form mx-auto col-lg-10">
                <div class="form-group col-md-2">
                    <div class="row mx-auto">
                        <input type="checkbox" class=" my-auto " autocomplete="off" runat="server" id="_oCbLand" disabled>
                        <span class=" my-auto ml-1">Land</span>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-4">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">Brief Description</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtLandDesc" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-2">
                    <div class="row mx-auto">
                        <input type="checkbox" class=" my-auto " autocomplete="off" runat="server" id="_oCbMachinery" disabled>
                        <span class=" my-auto ml-1">Machinery</span>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-4">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Brief Description</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtMachineryDesc" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>
            <div class="form-row form mx-auto col-lg-10">
                <div class="form-group col-md-2">
                    <div class="row mx-auto">
                        <input type="checkbox" class=" my-auto " autocomplete="off" runat="server" id="_oCbBuilding" disabled>
                        <span class=" my-auto ml-1">Building</span>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-4">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">Brief Description</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtBuildingDesc" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-2">
                    <div class="row mx-auto">
                        <input type="checkbox" class=" my-auto " autocomplete="off" runat="server" id="_oCbOthers" disabled>
                        <span class=" my-auto ml-1">Others:</span>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
                <div class="form-group col-md-4">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Specify</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtOther" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

            </div>

            <div class=" d-flex justify-content-center table-responsive">

                <div class="col-md-10">

                    <asp:GridView ID="_oGVRPT" runat="server" CssClass="GridViewStyle mgrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center"
                        Width="100%">
                        <Columns>

                            <asp:TemplateField HeaderText="Classification" ItemStyle-HorizontalAlign="center" ItemStyle-Width="120">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelClassification" runat="server" Text='<%# Eval("CLASSIFICATION").ToString()%>' />
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Class" ItemStyle-HorizontalAlign="center" ItemStyle-Width="120">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelSubClass" runat="server" Text='<%# Eval("SUB_CLASS").ToString()%>' />
                                </ItemTemplate>

                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Area" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelArea" runat="server" Text='<%# Eval("SQAREA").ToString()%>' />

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Market Value" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelMarketValue" runat="server" Text='<%# Eval("MARKET_VAL", "{0:C}").ToString().Replace("$", "")%>' />

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actual Use" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelActualUse" runat="server" Text='<%# Eval("ACTUAL_USE").ToString()%>' />

                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Ass Level" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelAssLVL" runat="server" Text='<%# Eval("ASS_LEVEL").ToString()%>' />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Assessed Val." ItemStyle-HorizontalAlign="Right" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelAssVal" runat="server" Text='<%# Eval("ASS_VALUE", "{0:C}").ToString().Replace("$", "")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>




                        </Columns>
                        <FooterStyle></FooterStyle>
                    </asp:GridView>
                    <br>
                </div>
            </div>

            <div class="form-row form mx-auto col-lg-10">

                <div class="form-group col-md-4">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">Prev. TDN</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtPrevTDN" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-4">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Prev. PIN</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtPrevPIN" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

                <div class="form-group col-md-4">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Prev. Assessed</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtPrevAss" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>

            </div>



            <div class="form-row form mx-auto col-lg-10">

                <div class="form-group col-md-12">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-8">Prev. Owner</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-New" autocomplete="off" runat="server" id="_oTxtPrevOwner" disabled>
                    </div>

                    <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-New" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>

            <div class=" d-flex justify-content-center table-responsive">

                <div class="col-md-10">

                    <asp:GridView ID="_oGVRPTPay" runat="server" CssClass="mGrid" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                        <Columns>

                            <asp:TemplateField HeaderText="OR No" ItemStyle-HorizontalAlign="center" ItemStyle-Width="120">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelClassification" runat="server" Text='<%# Eval("ORNo").ToString()%>' />
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Kind" ItemStyle-HorizontalAlign="center" ItemStyle-Width="120">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelSubClass" runat="server" Text='<%# Eval("kind").ToString()%>' />
                                </ItemTemplate>

                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Classification" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelArea" runat="server" Text='<%# Eval("Classification").ToString()%>' />

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Actual Use" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelMarketValue" runat="server" Text='<%# Eval("ACTUAL_USE").ToString()%>' />

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sub Class" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelActualUse" runat="server" Text='<%# Eval("SUBCLASS").ToString()%>' />

                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="For Year" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelAssLVL" runat="server" Text='<%# Eval("For_year").ToString()%>' />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Period Covered" ItemStyle-HorizontalAlign="center" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelAssVal" runat="server" Text='<%# Eval("PERIODCOVERED").ToString()%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="150">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelAssVal" runat="server" Text='<%# Eval("AMOUNT", "{0:C}").ToString().Replace("$", "")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>




                        </Columns>
                        <FooterStyle></FooterStyle>
                    </asp:GridView>

                </div>
            </div>
            <br>
            <br>
            <div class="my-2 col-lg-11" style="display:none">
                <button name="_obtnPrint" runat="server" id="_obtnPrint" type="submit" class="btn btn-primary btn-icon-split" style="position: absolute; bottom: 0; right: 0; width: 100px">
                    <span class="text">Print</span>
                    <span class="icon text-white-50">
                        <i class="fas fa-print mt-1"></i>
                    </span>
                </button>

            </div>


        </div>

    </div>

</asp:Content>

