<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BPLONewProperty.aspx.vb" Inherits="SPIDC.BPLONewProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <div id="snackbar" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbar"/>           
                </div>
                <div id="snackbargreen" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row">
         <div class="col-sm-12" align="center">
            <br />
            <h3><label class="text-xs font-weight-bold text-primary mb-1">Declare New Property List</label></h3>
        </div>

         <div class="col-sm-12">
             <div class="card shadow">
                 <div class="card-header">
                    <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">Declare New Property</label>
                </div>

                      <div class="card-body">
                    <asp:GridView ID="_oGVProperty" runat="server" CssClass="mGrid" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True">
                        <Columns>
                            <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="bpa" HeaderStyle-CssClass="bpa" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("TRANSDATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" ItemStyle-CssClass="bpa" HeaderStyle-CssClass="bpa" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("USERID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Property ID" ItemStyle-CssClass="bpa" HeaderStyle-CssClass="bpa" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("PROPID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location Property" ItemStyle-CssClass="bpa" HeaderStyle-CssClass="bpa" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("LOCPROPERTY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>                                                        
                             <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="bpa" HeaderStyle-CssClass="bpa" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                   <%--<asp:ImageButton runat="server" title="Review" ID="_oButtonReview" src="../CSS_JS_IMG/img/reviewIcon.png"  /> onclick="NPViewDetails('<%# Eval("USERID")%>','<%# Eval("PROPID")%>')" --%>
                                    <a style="width:20px;height:20px" href="#" data-toggle="modal" data-dismiss="modal" data-target="#PropertyDetails" data-ticket-type="standard-access" onclick="SetModalActive();NPViewDetails('<%# Eval("USERID")%>','<%# Eval("PROPID")%>');">Show Details</a> 
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                          <input type="hidden" runat="server" id="hdntdn" />
                    <input type="hidden" runat="server" id="hdnuserid" />
                    <input type="hidden" runat="server" id="hdnpropid" />                    

                    <script>                        
                        function NPViewDetails(userid, propid) {
                            document.getElementById('<%=hdnuserid.ClientID%>').value = userid;
                            document.getElementById('<%=hdnpropid.ClientID%>').value = propid;                            
                            __doPostBack('ViewDetails', '');
                        }

                    </script>
                </div>

             </div>
         </div>
    </div>
    <a id="hbtn" data-toggle="modal" data-dismiss="modal" data-target="#PropertyDetails" data-ticket-type="standard-access" style="display:none"></a>
    <div class="modal fade" id="PropertyDetails">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;">Details</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="row mx-auto col-lg-12">
            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Owner Name</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtOwner" name="_oTxtOwner" required/>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Owner Address</span></span>
                    </label>
                    <textarea class="form-control CH-Size-new" runat="server" id="_oTxtOwnerAddress"></textarea>
                </div>

            </div>
        </div>        

        <div class="row mx-auto col-lg-12">

            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Administrator/Beneficial User</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtAdministrator" required/>
                </div>

            </div>
            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Administrator Address</span></span>
                    </label>
                    <textarea class="form-control CH-Size-new" runat="server" id="_oTxtAdminAddress"></textarea>
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
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNoSt"/>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>

            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Barangay</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBarangay"/>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div><div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">District</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtDistrict"/>
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
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtOCT_TCT" required/>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>

            

            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Survey No.</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSurveyNo" required/>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Lot No.</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_TxtLotNo"/>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Block No.</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlockNo"/>
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
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtArea" onfocus="(this.type='number')" required/>
                </div>
            </div>

            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Amount Sold</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" onfocus="(this.type='number')" onblur="formatAmountSold(this.value)" runat="server" id="_oTxtAmountSold"/>
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
            <label class="ml-3">Residential</label>
            <div class="form-group col-md-2">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Area</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtResidentialArea" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required/>
                </div>
            </div>
            <label class="ml-3">Commercial</label>
            <div class="form-group col-md-2">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Area</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCommercialArea" onfocus="(this.type='number')" onkeyup="ComputeTotalArea();" required/>
                </div>
            </div>
            <label class="ml-3">Total Area</label>
            <div class="form-group col-md-2">
                <div>
                    <label class="input-txt input-txt-active2">
                        <%--<span><span class="m-2">Area</span></span>--%>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTotalArea" disabled/>
                    
                </div>
            </div>
                </div>

                <%--<div class="modal-footer">
                    <button type="button" class="btn btn-primary btn-sm pull-center" data-dismiss="modal" id="_obtnProceed" runat="server">Proceed</button>
                </div>--%>
            </div>
                <div class="row  mx-auto col-lg-12">
                    <div class="p-1 col-12 mb-2">
                        <p class="m-2 font-weight-bold">Uploaded files: </p>
                    </div>
                    <div class="form-group col-md-8 ">

                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Deed of sale </span></span>
                            </label>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtDeedofsale" required />

                        </div>
                        
                    </div>          
                    <a href="#" style="font-size:14px !Important;height:30px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary">Open</a>     
                    <div class="form-group col-md-8 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Copy of Title</span></span>
                            </label>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtCopyofTitle" required />
                        </div>
                        
                    </div>  
                    <a href="#" style="font-size:14px !Important;height:30px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary">Open</a>                                  
                    <div class="form-group col-md-8 ">

                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">ECAR (BIR) Proof of Payment</span></span>
                            </label>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtProofofPayment" required />
                        </div>


                    </div>
                    <a href="#" style="font-size:14px !Important;height:30px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary">Open</a> 
                    <div class="form-group col-md-8 ">

                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Tax Clearance</span></span>
                            </label>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtTaxClearance" required />
                        </div>


                    </div>
                    <a href="#" style="font-size:14px !Important;height:30px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary">Open</a> 
                    <div class="form-group col-md-8 ">

                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Declaration Copy</span></span>
                            </label>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtDeclarationCopy" required />
                        </div>


                    </div>
                    <a href="#" style="font-size:14px !Important;height:30px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary">Open</a> 
                    <div class="form-group col-md-8 ">

                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Secretary Certificate for Corporate property</span></span>
                            </label>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtCorporateProperty" required />
                        </div>


                    </div>
                    <a href="#" style="font-size:14px !Important;height:30px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary">Open</a> 
                    <div class="form-group col-md-8 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Valid ID</span></span>
                            </label>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtValidID" required />
                        </div>
                    </div>
                    <a href="#" style="font-size:14px !Important;height:30px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary">Open</a> 
       
                </div>
        </div>
    </div>
        </div> 
    <script>

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
