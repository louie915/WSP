<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BPLOEnrollmentVerification.aspx.vb" Inherits="SPIDC.BPLOEnrollmentVerification" %>

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
    <form id="frmNone"></form>
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
            <h3>
                <label class=" font-weight-bold text-primary mb-1">Account Enrollment</label></h3>
        </div>
        <div class="col-sm-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Applications</label>
                    <a href="BPLODirectEnrollment.aspx"  class="btn btn-primary" style="float: right;">Direct Enrollment</a>

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
                <option value="B.EMAIL2">Email</option>
                <option value="B.ACCTNO">ACCTNO</option>
                <option value="B.ReqDate">ReqDate</option>
                <option value="B.ORNo">ORNo</option>
                <option value="B.OWNER">OWNER</option>
                <option value="B.LASTNAME">Lastname</option>
                <option value="B.FIRSTNAME">Firstname</option>
                <option value="B.MIDDLENAME">Middlename</option>
                <option value="B.BUSNAME">BUSNAME</option>
                <option value="B.BUSADDRESS">BUSADDRESS</option>
                <option value="B.CATEGORY">CATEGORY</option>
                <option value="B.TIN">TIN</option>
                <option value="B.VerifiedBy">VerifiedBy</option>
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
                            <asp:TemplateField HeaderText="BIN" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ACCTNO" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="OR No" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ORNO" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelOrNo" runat="server" Text='<%# Eval("ORNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Commercial Name" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("BUSNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Commercial Address" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialAddress" runat="server" Text='<%# Eval("BUSADDRESS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelOwner" runat="server" Text='<%# Eval("OWNER")%>' />
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
                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <a href="#" onclick="do_view('<%# Eval("EMAIL2")%>', '<%# Eval("ACCTNO")%>', '<%# Eval("ORNO")%>');" data-toggle="modal" data-target="#myModal" title="Verify">Verify</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    showing 1 -
                    <label id="_oLblShowingValueApp" runat="server"></label>
                    of
                    <label id="_oTtlEntriesApp" runat="server">20</label>
                    <div style="text-align: right">
                        <label class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="LabelTotalRecCnt" runat="server"></label>
                    </div>

                    <div style="text-align: right">
                        <button name="BtnPrintAll" runat="server" id="BtnPrintAll" type="submit">PRINT ALL</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <br />
            <div class="card shadow">
                <div class="card-header">
                    <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">Verification History</label>
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
                <option value="S.ACCTNO">ACCTNO</option>
                <option value="S.ReqDate">ReqDate</option>
                <option value="S.ORNo">ORNo</option>
                <option value="S.OWNER">OWNER</option>
                <option value="S.LASTNAME">Lastname</option>
                <option value="S.FIRSTNAME">Firstname</option>
                <option value="S.MIDDLENAME">Middlename</option>
                <option value="S.BUSNAME">BUSNAME</option>
                <option value="S.BUSADDRESS">BUSADDRESS</option>
                <option value="S.CATEGORY">CATEGORY</option>
                <option value="S.TIN">TIN</option>
                <option value="S.VerifiedBy">VerifiedBy</option>
            </select>
                    <%--<button type="button" onclick="__doPostBack('Sort','');">Sort</button>--%>
                    <input type="text" runat="server" id="_oTxtSearchKeyVerify" onblur="RecordReset('Verify');">
                    <button type="button" onclick="__doPostBack('SearchVerify',document.getElementById('<%=_oTxtShowEntriesVerify.ClientID%>').value);">Search</button>
                    <hr />
                    <asp:GridView ID="GridView2" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_History"
                        PageSize="5">
                        <PagerSettings Mode="NumericFirstLast"
                            FirstPageText="First"
                            LastPageText="Last"
                            PageButtonCount="3"
                            Position="Bottom"
                            Visible="true" />
                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Date Verified" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="VERIFIEDDATE" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmailVerified" runat="server" Text='<%# Eval("VERIFIEDDATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="EMAIL" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmailVerified" runat="server" Text='<%# Eval("EMAIL")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIN" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ACCTNO" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBINlVerified" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Owner" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="OWNER" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelOwnerVerified" runat="server" Text='<%# Eval("OWNER")%>' />
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
                            <asp:TemplateField HeaderText="Verified By" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="VERIFIEDBY" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelVerifiedBy" runat="server" Text='<%# Eval("VERIFIEDBY")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    showing 1 -
                    <label id="_oLblShowingValueVerify" runat="server"></label>
                    of
                    <label id="_oTtlEntriesVerify" runat="server">20</label>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-thumbs-up text-white float-right" style="font-size: 30px;"></i>
                    <h4 class="modal-title text-white" id="myModalLabel">&nbsp;&nbsp;Verify Business Application</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                     <div runat="server" id="div_AssessedNotice" style="display:none;">
                            <center>
                <div class="w3-panel  w3-pale-yellow"> 
                 <h3>Attention! </h3>
                 <p>
                      BIN : [<label id="AttentionBIN" runat="server"></label>] is already Assessed for renewal.<br />
                      Please proceed to BPLTAS and update Billing TOP before you approve.<br>
                 </p>
                      </div> 

                </center>
                        </div>
                    <div class="form-row form">                     

                        <div class="col-sm-6 border-right">
                            <div align="center">
                                <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">User Profile</label>
                            </div>

                            <div align="right" style="float: right">
                                <label class="btn btn-primary" runat="server" id="lblAgent"></label>
                                &nbsp &nbsp &nbsp &nbsp &nbsp
                            </div>
                            <br />
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Name:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelFullname"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Email Address:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelUserEmailAddress"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Address:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelAddress"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Contact Number:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelUserContactNo"></p>
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
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Owner:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelOwner"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Business Ownership:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelBusOwnership"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Email Registered:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelOwnerEmail"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Address:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelOwnerAddress"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Commercial Name:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelCommercialName"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Commercial Address:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelCommercialAddress"></p>
                            </div>
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Contact Number:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelOwnerContactNo"></p>
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

    <asp:HiddenField runat="server" ID="hdnFullname" />
    <asp:HiddenField runat="server" ID="hdnUserEmail" />
    <asp:HiddenField runat="server" ID="hdnAddress" />
    <asp:HiddenField runat="server" ID="hdnUserContactNo" />
    <asp:HiddenField runat="server" ID="hdnOwner" />
    <asp:HiddenField runat="server" ID="hdnOwnerEmail" />
    <asp:HiddenField runat="server" ID="hdnOwnerAddress" />
    <asp:HiddenField runat="server" ID="hdnCommercialName" />
    <asp:HiddenField runat="server" ID="hdnCommercialAddress" />
    <asp:HiddenField runat="server" ID="hdnOwnerContactNo" />


    <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hdnseqid" />
    <input type="hidden" runat="server" id="hdnName" />
    <input type="hidden" runat="server" id="hdnType" />
    <input type="hidden" runat="server" id="hdnData" />


    <input type="hidden" runat="server" id="hdnEmail" />
    <input type="hidden" runat="server" id="hdnACCTNO" />
    <input type="hidden" runat="server" id="hdnORNO" />

    <script>


        function do_view(Email, ACCTNO, ORNO) {
            document.getElementById('<%= hdnEmail.ClientID%>').value = Email;
            document.getElementById('<%= hdnACCTNO.ClientID%>').value = ACCTNO;
            document.getElementById('<%= hdnORNO.ClientID%>').value = ORNO;
          

            __doPostBack('View', Email);
        }


            <%--function ViewSPA(Name, Type, Data, seqid, sample) {
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
            }--%>

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
        function SendEmail() {
            __doPostBack('EmailNotification', '');
        }
    </script>

    <script>
        <%--document.getElementById('_oLabelFullname').innerText = document.getElementById('<%= hdnFullname.ClientID%>').value;
        alert(document.getElementById('_oLabelFullname').innerText = document.getElementById('<%= hdnFullname.ClientID%>').value);
        document.getElementById('_oLabelUserEmailAddress').innerText = document.getElementById('<%= hdnUserEmail.ClientID%>').value;
        alert(document.getElementById('_oLabelUserEmailAddress').innerText = document.getElementById('<%= hdnUserEmail.ClientID%>').value);
        document.getElementById('_oLabelAddress').innerText = document.getElementById('<%= hdnAddress.ClientID%>').value;
        alert(document.getElementById('_oLabelAddress').innerText = document.getElementById('<%= hdnAddress.ClientID%>').value);
        document.getElementById('_oLabelUserContactNo').innerText = document.getElementById('<%= hdnUserContactNo.ClientID%>').value;
        alert(document.getElementById('_oLabelUserContactNo').innerText = document.getElementById('<%= hdnUserContactNo.ClientID%>').value);
        document.getElementById('_oLabelOwner').innerText = document.getElementById('<%= hdnOwner.ClientID%>').value;
        alert(document.getElementById('_oLabelOwner').innerText = document.getElementById('<%= hdnOwner.ClientID%>').value);
        document.getElementById('_oLabelOwnerEmail').innerText = document.getElementById('<%= hdnOwnerEmail.ClientID%>').value;
        alert(document.getElementById('_oLabelOwnerEmail').innerText = document.getElementById('<%= hdnOwnerEmail.ClientID%>').value);
        document.getElementById('_oLabelOwnerAddress').innerText = document.getElementById('<%= hdnOwnerAddress.ClientID%>').value;
        alert(document.getElementById('_oLabelOwnerAddress').innerText = document.getElementById('<%= hdnOwnerAddress.ClientID%>').value);
        document.getElementById('_oLabelCommercialName').innerText = document.getElementById('<%= hdnCommercialName.ClientID%>').value;
        alert(document.getElementById('_oLabelCommercialName').innerText = document.getElementById('<%= hdnCommercialName.ClientID%>').value);
        document.getElementById('_oLabelCommercialAddress').innerText = document.getElementById('<%= hdnCommercialAddress.ClientID%>').value;
        alert(document.getElementById('_oLabelCommercialAddress').innerText = document.getElementById('<%= hdnCommercialAddress.ClientID%>').value);
        document.getElementById('_oLabelOwnerContactNo').innerText = document.getElementById('<%= hdnOwnerContactNo.ClientID%>').value;        
        alert(document.getElementById('_oLabelOwnerContactNo').innerText = document.getElementById('<%= hdnOwnerContactNo.ClientID%>').value);--%>
    </script>
    <script>
        <%--document.getElementById('<%= _oBtnDisapprove.ClientID%>').disabled = false;
        document.getElementById('<%= _oBtnVerify.ClientID%>').disabled = false;--%>

        function verify(Action, Val) {
            __doPostBack(Action, Val);
        }

        function verifyAccount(lastname, firstname, middlename, extnname, email, tin, commercialName, commercialAddress,
            owner, userEmail, AccountNo, Orno, address, usercontactno, owneremail) {

            document.getElementById('<%= hdnFullname.ClientID%>').value = firstname + ' ' + middlename + ' ' + lastname + ' ' + extnname;
                document.getElementById('<%= hdnUserEmail.ClientID%>').value = email;
            document.getElementById('<%= hdnAddress.ClientID%>').value = (address ? address : "");
            document.getElementById('<%= hdnUserContactNo.ClientID%>').value = (usercontactno ? usercontactno : "");
            document.getElementById('<%= hdnOwner.ClientID%>').value = (owner ? owner : "");
            document.getElementById('<%= hdnOwnerEmail.ClientID%>').value = (owneremail ? owneremail : "");
            document.getElementById('<%= hdnOwnerAddress.ClientID%>').value = (commercialAddress ? commercialAddress : "");
            document.getElementById('<%= hdnCommercialName.ClientID%>').value = (commercialName ? commercialName : "");
            document.getElementById('<%= hdnCommercialAddress.ClientID%>').value = (commercialAddress ? commercialAddress : "");
            document.getElementById('<%= hdnOwnerContactNo.ClientID%>').value = (usercontactno ? usercontactno : "");
            //alert(email);
            document.getElementById('<%= userEmail.ClientID%>').value = userEmail;
            document.getElementById('<%= acctNo.ClientID%>').value = AccountNo;
            document.getElementById('<%= OrNo.ClientID%>').value = Orno;
            __doPostBack('GetFile', '');


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
                headerText = 'Approved'
            } else {
                headerText = 'Disapproved'
            }
            document.getElementById('modalVerificationActionlLabel').innerText = 'Verification Complete - ' + headerText;
            document.getElementById('mess1').innerText = 'Verification for account ' + acctno + ' has been completed';
            $('#modalVerificationAction').modal('show');
        }
        function openModal2() {
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
