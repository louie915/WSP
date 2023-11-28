﻿<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/ASSESSORMaster.Master" CodeBehind="ASSESSOREnrollmentVerification.aspx.vb" Inherits="SPIDC.ASSESSOREnrollmentVerification" %>

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
    <div class="row col-lg-12">
        <div class="col-sm-12" align="center">
            <br />
            <h4>
                <label class="font-weight-bold text-primary mb-1">Real Property Enrollment</label></h4>
        </div>
        <div class="col-sm-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class="font-weight-bold text-primary text-uppercase mb-1">Applications</label>
                </div>
                <div class="card-body">
                    <span class="">Show</span>
                    <select runat="server" id="_oTxtShowEntriesApp" onchange="__doPostBack('SearchApp',this.value);" class="">
                    </select>
                    Entries
            <input type="hidden" runat="server" id="_oTxtShowEntriesHdnApp" />
                    <script>
                        var dropdown = document.getElementById("<%=_oTxtShowEntriesApp.ClientID%>");
                        var TotalRow = document.getElementById("<%=_oTxtShowEntriesHdnApp.ClientID%>").value;
                        for (var i = TotalRow; i >= 1; i--) {
                            var newOption = document.createElement('option');
                            newOption.value = i;
                            newOption.innerHTML = i;
                            //alert(i);
                            dropdown.add(newOption);
                        }
                        addLoadEvent(LoadEntries);
                        function LoadEntries() {
                            //alert(sessionStorage.getItem('CmbEntries1'));
                            document.getElementById("<%=_oTxtShowEntriesApp.ClientID%>").value = sessionStorage.getItem('CmbEntries1');
                        }
                    </script>
                    &nbsp&nbsp
                    Filter By:
            <select runat="server" id="_oTxtSearchFilterApp">
                <option value="S.EMAIL2">Email</option>
                <option value="S.TDN">TDN</option>
                <option value="S.ReqDate">ReqDate</option>
                <option value="S.ORNO">ORNO</option>
                <option value="S.OWNERNAME">Ownername</option>
                <option value="S.LASTNAME">Lastname</option>
                <option value="S.FIRSTNAME">Firstname</option>
                <option value="S.MIDDLENAME">Middlename</option>
                <option value="S.EXTNNAME">Extnname</option>
                <option value="S.ADDRESS">ADDRESS</option>
                <option value="S.TIN">TIN</option>
                <%--<option value="S.VerifiedBy">VerifiedBy</option>--%>
            </select>
                    <input type="hidden" runat="server" id="_oHdnTopCounterApp">
                    <input type="hidden" runat="server" id="_oHdnTopCounterVerify">
                    <%--<button type="button" onclick="__doPostBack('Sort','');">Sort</button>--%>
                    <input type="text" runat="server" id="_oTxtSearchKeyApp" onblur="RecordReset('App');">
                    <script>
                        function RecordReset(filter) {
                            var Checkvalue;
                            var TopCounter
                            if (filter == 'App') {
                                Checkvalue = document.getElementById('<%=_oTxtSearchKeyApp.ClientID%>').value;
                                TopCounter = document.getElementById('<%=_oTxtShowEntriesApp.ClientID%>').value;
                                document.getElementById('<%=_oHdnTopCounterApp.ClientID%>').value = TopCounter;
                            }
                            else {
                                Checkvalue = document.getElementById('<%=_oTxtSearchKeyVerify.ClientID%>').value;
                                TopCounter = document.getElementById('<%=_oTxtShowEntriesVerify.ClientID%>').value;
                                document.getElementById('<%=_oHdnTopCounterVerify.ClientID%>').value = TopCounter;
                            }

                            if (!Checkvalue.length > 0) {
                                if (filter == 'App') {
                                    __doPostBack('SearchApp', TopCounter);
                                }
                                else {
                                    __doPostBack('SearchVerify', TopCounter);
                                }

                            }
                        }
                        function SetAllTopValues() {
                            var CheckAppvalue = document.getElementById('<%=_oHdnTopCounterApp.ClientID%>').value;
                            var CheckVerifyvalue = document.getElementById('<%=_oHdnTopCounterVerify.ClientID%>').value;
                            if (!CheckAppvalue.length > 0) { document.getElementById('<%=_oHdnTopCounterApp.ClientID%>').value = document.getElementById('<%=_oTxtShowEntriesApp.ClientID%>').value; }
                            if (!CheckVerifyvalue.length > 0) { document.getElementById('<%=_oHdnTopCounterVerify.ClientID%>').value = document.getElementById('<%=_oTxtShowEntriesVerify.ClientID%>').value; }
                        }
                        addLoadEvent(SetAllTopValues);
                    </script>
                    <button type="button" onclick="__doPostBack('SearchApp',document.getElementById('<%=_oTxtShowEntriesApp.ClientID%>').value);">Search</button>
                    <hr />
                    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_Application"
                        PageSize="5">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Date" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="REQDATE" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("REQDATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="EMAIL2" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL2")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TDN" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="TDN" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("TDN")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OR No" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="ORNO" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelOrNo" runat="server" Text='<%# Eval("ORNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelOwner" runat="server" Text='<%# Eval("OWNERNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Last Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelLastName" runat="server" Text='<%# Eval("LASTNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="First Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelFirstName" runat="server" Text='<%# Eval("FIRSTNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Middle Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelMiddleName" runat="server" Text='<%# Eval("MIDDLENAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Extension Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelExtensionName" runat="server" Text='<%# Eval("EXTNNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelAddress" runat="server" Text='<%# Eval("ADDRESS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TIN" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelTIN" runat="server" Text='<%# Eval("TIN")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%--lastname, firstname, middlename, extnname, address, tin, owner, userEmail, tdn, Orno--%>
                                    <%-- <a href="#" onclick="verifyAccount('<%# Eval("LASTNAME")%>', '<%# Eval("FIRSTNAME")%>', '<%# Eval("MIDDLENAME")%>', '<%# Eval("EXTNNAME")%>', '<%# Eval("ADDRESS")%>', '<%# Eval("TIN")%>', '<%# Eval("OWNERNAME")%>', '<%# Eval("EMAIL")%>', '<%# Eval("TDN")%>', '<%# Eval("ORNO")%>')" data-toggle="modal" data-target="#myModal" title="Verify">Verify</a>
                                    --%>

                                    <a href="#" onclick="do_view('<%# Eval("EMAIL2")%>', '<%# Eval("TDN")%>', '<%# Eval("ORNO")%>');">Verify</a>




                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    showing 1 -
                    <label id="_oLblShowingValueApp" runat="server"></label>
                    of
                    <label id="_oTtlEntriesApp" runat="server">20</label>                    
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <br />
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Verification History</label>
                </div>
                <div class="card-body">
                    <span class="">Show</span>
                    <select runat="server" id="_oTxtShowEntriesVerify" onchange="__doPostBack('SearchVerify',this.value);" class="">
                    </select>
                    Entries
            <input type="hidden" runat="server" id="_oTxtShowEntriesHdnVerify" />
                    <script>
                        var dropdown = document.getElementById("<%=_oTxtShowEntriesVerify.ClientID%>");
                        var TotalRow = document.getElementById("<%=_oTxtShowEntriesHdnVerify.ClientID%>").value;
                        for (var i = TotalRow; i >= 1; i--) {
                            var newOption = document.createElement('option');
                            newOption.value = i;
                            newOption.innerHTML = i;
                            //alert(i);
                            dropdown.add(newOption);
                        }
                        addLoadEvent(LoadEntriesVerify);
                        function LoadEntriesVerify() {
                            //alert(sessionStorage.getItem('CmbEntries1'));
                            document.getElementById("<%=_oTxtShowEntriesVerify.ClientID%>").value = sessionStorage.getItem('CmbEntries2');
                        }
                    </script>
                    &nbsp&nbsp
                    Filter By:
            <select runat="server" id="_oTxtSearchFilterVerify">
                <option value="S.EMAIL">Email</option>
                <option value="S.VERIFIEDDATE">Verified Date</option>
                <option value="S.TDN">TDN</option>
                <option value="S.OWNERNAME">Ownername</option>
                <option value="S.STATUS">STATUS</option>
                <option value="S.FIRSTNAME">Firstname</option>
                <option value="S.REMARKS">Remarks</option>
                <option value="S.VerifiedBy">Verified By</option>
                <%--<option value="S.VerifiedBy">BUSADDRESS</option>
                <option value="S.CATEGORY">CATEGORY</option>
                <option value="S.TIN">TIN</option>
                <option value="S.VerifiedBy">VerifiedBy</option>--%>
            </select>
                    <%--<button type="button" onclick="__doPostBack('Sort','');">Sort</button>--%>
                    <input type="text" runat="server" id="_oTxtSearchKeyVerify" onblur="RecordReset('Verify');">
                    <button type="button" onclick="__doPostBack('SearchVerify',document.getElementById('<%=_oTxtShowEntriesVerify.ClientID%>').value);">Search</button>
                    <hr />
                    <asp:GridView ID="GridView2" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_Verification"
                        PageSize="5">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Requested Date" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="ORNO" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmailVerified" runat="server" Text='<%# Eval("VERIFIEDDATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="EMAIL" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmailVerified" runat="server" Text='<%# Eval("EMAIL")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="TDN" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="TDN" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBINlVerified" runat="server" Text='<%# Eval("TDN")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="OWNERNAME" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelOwnerVerified" runat="server" Text='<%# Eval("OWNERNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="STATUS" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelAddressVerified" runat="server" Text='<%# Eval("STATUS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="REMARKS" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelRemarksVerified" runat="server" Text='<%# Eval("REMARKS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="VerifiedBy" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="VerifiedBy" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelRemarksVerified" runat="server" Text='<%# Eval("VerifiedBy")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    showing 1 - 
                    <label id="_oLblShowingValueVerify" runat="server"></label>
                    of
                    <label id="_oTtlEntriesVerify" runat="server">20</label>                   )
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-thumbs-up text-white float-right" style="font-size: 30px;"></i>
                    <h4 class="modal-title text-white" id="myModalLabel">&nbsp;&nbsp;Verify Real Property Application</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="form-row form">
                        <div class="col-sm-6 border-right">
                            <div align="center">
                                <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">User Profile</label>
                            </div>
                            <br />
                              <div align="right" style="float:right">
                                <label class="btn btn-primary" runat="server" id="lblAgent"></label>&nbsp &nbsp &nbsp &nbsp &nbsp
                            </div> 
                              <br />       
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Name:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelFullname"></p>
                            </div>

                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Address:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelUSAddress"></p>
                            </div>


                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Contact #:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelContact"></p>
                            </div>

                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Email Address:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelEmailAddress"></p>
                            </div>


                            <div class="row  mx-auto col-lg-12">
                                <div class="p-1 col-12 mb-2">
                                    <p class="m-2 font-weight-bold">Uploaded files: </p>
                                </div>
                                <div class="form-group col-lg-8">

                                    <div>
                                        <label class="input-txt input-txt-active2">
                                            <span><span class="m-2">Government ID </span></span>
                                        </label>
                                        <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtGovernmentID" disabled />

                                    </div>

                                </div>
                                <div class="form-group col-lg-4 ">
                                    <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtGovernmentID.ClientID%>');ViewSPA('FileName','FileType','FileData','001','<%=_oTxtGovernmentID.ClientID%>');">View</a>
                                </div>
                                <div class="form-group col-lg-8 ">
                                    <div>
                                        <label class="input-txt input-txt-active2">
                                            <span><span class="m-2">Special Power of Attorney</span></span>
                                        </label>
                                        <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtSPA" required disabled />
                                    </div>

                                </div>

                                <div class="form-group col-lg-4 ">
                                    <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtSPA.ClientID%>');ViewSPA('FileName','FileType','FileData','002','<%=_oTxtSPA.ClientID%>');">View</a>
                                </div>

                                <div class="form-group col-lg-8 ">
                                    <div>
                                        <label class="input-txt input-txt-active2">
                                            <span><span class="m-2">Board Resolution/Secretary Certificate</span></span>
                                        </label>
                                        <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtBRSec" required disabled />
                                    </div>

                                </div>

                                <div class="form-group col-lg-4 ">
                                    <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtBRSec.ClientID%>');ViewSPA('FileName','FileType','FileData','003','<%=_oTxtBRSec.ClientID%>');">View</a>
                                </div>

                            </div>


                        </div>

                        <div class="col-sm-6 border-left">
                            <div align="center">
                                <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">Account Details</label>
                            </div>
                            <br />

                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Owner Name:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelOwner"></p>
                            </div>

                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Owner Address:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelOwnerAddr"></p>
                            </div>


                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Contact Number:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_olabelOwnerContNo"></p>
                            </div>


                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Property Location Address:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_olabelPropLocAddress"></p>
                            </div>


                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">PIN:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_olabelPin"></p>
                            </div>

                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">TDN:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_olabelTDN"></p>
                            </div>



                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Remarks:&nbsp</label>
                    <textarea id="_oTextRemarks" runat="server" rows="1" class="form-control"></textarea>
                    <button type="button" class="btn btn-danger btn-sm mr-auto" id="_oBtnDisapprove" onclick="openModal(false);" runat="server">Disapprove</button>
                    <button type="button" class="btn btn-success btn-sm" id="_oBtnVerify" runat="server" onclick="openModal(true);">Approve</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalVerification">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-warning">
                    <i class="fa fa-question-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="modalVerificationlLabel">Verification Confirmation</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center">
                    <label class="font-weight-light text-gray mb-1" id="mess"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" id="_oBtnCancel" runat="server">Cancel</button>
                    <button type="button" class="btn btn-success btn-sm" data-dismiss="modal" id="_oBtnOkay" runat="server" onclick="verify('Verify','')">Confirm</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalVerificationAction">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-exclamation-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="modalVerificationActionlLabel">Verification Complete</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <label class="font-weight-light text-gray mb-1" id="mess1"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success btn-sm" data-dismiss="modal" id="Button1" runat="server">Confirm</button>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="userEmail" />
    <asp:HiddenField runat="server" ID="acctNo" />
    <asp:HiddenField runat="server" ID="OrNo" />
    <asp:HiddenField runat="server" ID="ver" />

    <asp:HiddenField runat="server" ID="hdnUserEmail" />

    <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hdnseqid" />
    <input type="hidden" runat="server" id="hdnName" />
    <input type="hidden" runat="server" id="hdnType" />
    <input type="hidden" runat="server" id="hdnData" />

    <input type="hidden" runat="server" id="Hidden1" />
    <input type="hidden" runat="server" id="hdnEmail" />
    <input type="hidden" runat="server" id="hdnTDN" />
    <input type="hidden" runat="server" id="hdnORNO" />

    <input type="hidden" runat="server" id="err" />

    <script>

        function ViewSPA(Name, Type, Data, seqid, sample) {
            var Checkival = document.getElementById(sample).value;
            if (Checkival != "No Attached File") {
                document.getElementById('<%=hdnName.ClientID%>').value = Name;
                document.getElementById('<%=hdnType.ClientID%>').value = Type;
                document.getElementById('<%=hdnData.ClientID%>').value = Data;
                __doPostBack('DownloadFiles', seqid);
            }
            else {
                document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "No Attached File";
                Snackbar();

            }
        }
        function opennewtab(fileid) {
            var Checkival = document.getElementById(fileid).value;
            //alert(Checkival)
            if (Checkival != "No Attached File") {
                window.document.forms[0].target = '_blank';
                setTimeout(function () { window.document.forms[0].target = ''; }, 0);
            }

        }

       // document.getElementById('_oLabelUserEmailAddress').innerText = document.getElementById('<%= hdnUserEmail.ClientID%>').value;
        function do_view(Email, TDN, ORNO) {
            document.getElementById('<%= hdnEmail.ClientID%>').value = Email;
            document.getElementById('<%= hdnTDN.ClientID%>').value = TDN;
            document.getElementById('<%= hdnORNO.ClientID%>').value = ORNO;
            __doPostBack('View', Email);
        }

        function verify(Action, Val) {
            __doPostBack(Action, Val);
        }

        function verifyAccount(lastname, firstname, middlename, extnname, address, tin, owner, userEmail, tdn, Orno) {
            document.getElementById('_oLabelFullname').innerText = firstname + ' ' + middlename + ' ' + lastname + ' ' + extnname;
            document.getElementById('_oLabelTDN').innerText = tdn;
            document.getElementById('_oLabelOwner').innerText = owner;
            document.getElementById('_oLabelAddress').innerText = address;
            document.getElementById('<%= userEmail.ClientID%>').value = userEmail;
            document.getElementById('<%= acctNo.ClientID%>').value = tdn;
            document.getElementById('<%= OrNo.ClientID%>').value = Orno;
            document.getElementById('<%= hdnUserEmail.ClientID%>').value = email;
        }

        function openModal(approve) {

            if (approve === true) {
                document.getElementById('<%= ver.ClientID%>').value = 'Approve';
                    document.getElementById('mess').innerText = 'Approve this account?';
                    $('#modalVerification').modal('show');
                } else {
                    document.getElementById('<%= ver.ClientID%>').value = 'Disapprove';
                    document.getElementById('mess').innerText = 'Disapprove this account?';
                    $('#modalVerification').modal('show');
                }
            }

            function openModal1(acctno, verificationAction) {
                var headerText;
                if (verificationAction == 'Approved') {
                    headerText = 'Approved';
                } else {
                    headerText = 'Disapproved';
                }
                document.getElementById('modalVerificationActionlLabel').innerText = 'Verification Complete - ' + headerText;
                document.getElementById('mess1').innerText = 'Verification for account ' + acctno + ' has been completed';
                $('#modalVerificationAction').modal('show');
            }
    </script>
</asp:Content>
