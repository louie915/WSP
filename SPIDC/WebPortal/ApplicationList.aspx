<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/RegulatoryMaster.Master" CodeBehind="ApplicationList.aspx.vb" Inherits="SPIDC.ApplicationList" EnableEventValidation="false" %>

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
    <div class="row col-lg-12 mx-auto">
        <div class="col-sm-12" align="center">
            <br />
            <h3>
                <label class=" font-weight-bold text-primary mb-1">Inspection Request</label></h3>
        </div>
        <div class="col-sm-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Applications</label>
                </div>
                <div class="card-body">            
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_req"
                                PageSize="5">
                                <PagerSettings Mode="NumericFirstLast"
                                    FirstPageText="First"
                                    LastPageText="Last"
                                    PageButtonCount="3"
                                    Position="Bottom"
                                    Visible="true" />
                                <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Request ID" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Center" SortExpression="REQUESTID" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("REQUESTID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="EMAIL" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Request Date" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="REQUESTDATE" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("REQUESTDATE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ACCTNO" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelOrNo" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("STATUS")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelCommercialAddress" runat="server" Text='<%# Eval("REMARKS")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspection Date" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelOwner" runat="server" Text='<%# Eval("INSPECTIONDATE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                <ContentTemplate>
                                                    <asp:Button ID="test" runat="server" CommandArgument='<%# Eval("ACCTNO")%>' CommandName='<%# Eval("REQUESTID")%>' OnClientClick="setTimeout(function(){$('#myModalApprove').modal('show');},500);" OnClick="Btn_Verify_click" Text="Verify/Approve" CssClass="btn btn-link p-0" value="" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <%--<button type="button" id="delete_rd" runat="server" name="" onserverclick="Btn_Verify_click" onclientclick="setTimeout(function here(){$('#myModalApprove').modal('show');},500);" class="btn btn-link p-0">Verify/Approve</button>--%>
                                            <%--<button type="button" class="btn btn-success m-0 px-1 py-0"
                                        onclick="SaveAction('<%# Eval("REQUESTID")%>', '<%# Eval("EMAIL")%>','APPROVED')" data-toggle="modal" data-target="#myModal">
                                        <i class="fas fa-check text-white"></i>
                                    </button>
                                    <button type="button" class="btn btn-danger m-0 px-2 py-0"
                                        onclick="SaveAction('<%# Eval("REQUESTID")%>', '<%# Eval("EMAIL")%>' ,'DENIED')" data-toggle="modal" data-target="#myModal">
                                        <i class="fas fa-close text-white"></i>
                                    </button>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                        <ContentTemplate>
                            <asp:HiddenField ID="_hdnrequestid" runat="server" />
                            <asp:HiddenField ID="_hdnemail" runat="server" />
                            <asp:HiddenField ID="_hdnaction" runat="server" />
                            <asp:HiddenField ID="_hdnDateInspect" runat="server" />
                            <asp:HiddenField ID="_hdnAcctNo" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <script>
                        function SaveAction(_hdnrequestid, _hdnemail, _hdnaction) {
                            document.getElementById('<%=_hdnemail.ClientID%>').value = _hdnemail;
                            document.getElementById('<%=_hdnrequestid.ClientID%>').value = _hdnrequestid;
                            document.getElementById('<%=_hdnaction.ClientID%>').value = _hdnaction;
                            //document.getElementById('<%=_hdnDateInspect.ClientID%>').value = _hdnDateInspect;
                        }
                    </script>
                    <%--showing 1 -
                    <label id="_oLblShowingValueApp" runat="server"></label>
                    of
                    <label id="_oTtlEntriesApp" runat="server">20</label>
                    <div style="text-align: right">
                        <label class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="LabelTotalRecCnt" runat="server"></label>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="row col-lg-12 mx-auto">
        <div class="col-sm-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">History</label>
                </div>
                <div class="card-body">
                    <%--<div class="col-lg-12 row align-content-center align-items-center d-flex m-2">
                        <span class="form-group">Show</span>
                        <div class="col-lg-1 form-group">
                            <select runat="server" id="_oTxtShowEntriesApp" onchange="__doPostBack('SearchApp',this.value);" class="form-control">
                            </select>
                        </div>
                        <span class="form-group">Entries</span>
                        <input type="hidden" runat="server" id="_oTxtShowEntriesHdnApp" />
                        <script>
                            var dropdown = document.getElementById("<%=_oTxtShowEntriesApp.ClientID%>");
                            var TotalRow = document.getElementById("<%=_oTxtShowEntriesHdnApp.ClientID%>").value;
                            for (var i = TotalRow; i >= 1; i--) {
                                var newOption = document.createElement('option');
                                newOption.value = i;
                                newOption.innerHTML = i;                                
                                dropdown.add(newOption);
                            }
                            addLoadEvent(LoadEntries);
                            function LoadEntries() {                                
                                document.getElementById("<%=_oTxtShowEntriesApp.ClientID%>").value = sessionStorage.getItem('CmbEntries1');
                            }
                        </script>
                        &nbsp&nbsp
                    <span class="form-group">Filter By:</span>                                                                       
                        <div class="col-lg-3 form-group">
                            <input type="text" runat="server" id="_oTxtSearchKeyApp" onblur="RecordReset('App');" class="form-control">
                        </div>                        
                        <button type="button" onclick="__doPostBack('SearchApp',document.getElementById('<%=_oTxtShowEntriesApp.ClientID%>').value);" class="btn btn-primary form-group">Search</button>
                    </div>--%>
                    <%--<hr />--%>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:RadioButton ID="RadioButton1" GroupName="QTR" runat="server" AutoPostBack="true" Text="&nbsp All" CssClass="my-auto col-md-3" Checked="true" OnCheckedChanged="_oRadiobtn_CheckedChanged" />
                            <asp:RadioButton ID="_oRadio3rdQ" GroupName="QTR" runat="server" AutoPostBack="true" Text="&nbsp Approved" CssClass="my-auto col-md-3" OnCheckedChanged="_oRadiobtn_CheckedChanged" />
                            <asp:RadioButton ID="_oRadio4thQ" GroupName="QTR" runat="server" AutoPostBack="true" Text="&nbsp Denied" CssClass="my-auto col-md-3" OnCheckedChanged="_oRadiobtn_CheckedChanged" />

                            <asp:GridView ID="GridView2" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_history"
                                PageSize="5">
                                <PagerSettings Mode="NumericFirstLast"
                                    FirstPageText="First"
                                    LastPageText="Last"
                                    PageButtonCount="3"
                                    Position="Bottom"
                                    Visible="true" />
                                <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Request ID" HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="Center" SortExpression="REQUESTID" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <a id="oLabelRequestID" href="#" data-target="#myModalDetails" data-toggle="modal" onclick="viewdetails('<%# IIf(Not IsDBNull(Eval("REQUESTID")), Eval("REQUESTID"), "")%>',
                                                '<%# IIf(Not IsDBNull(Eval("ACCTNO")), Eval("ACCTNO"), "")%>',
                                                '<%# IIf(Not IsDBNull(Eval("REQUESTDATE")), Eval("REQUESTDATE"), "")%>',
                                                '<%# IIf(Not IsDBNull(Eval("INSPECTIONDATE")), Eval("INSPECTIONDATE"), "")%>',
                                                '<%# IIf(Not IsDBNull(Eval("STATUS")), Eval("STATUS"), "")%>',
                                                '<%# IIf(Not IsDBNull(Eval("EMAIL")), Eval("EMAIL"), "")%>',
                                                '<%# IIf(Not IsDBNull(Eval("REMARKS")), Eval("REMARKS"), "")%>',
                                                '<%# IIf(Not IsDBNull(Eval("ASSESSEDBY")), Eval("ASSESSEDBY"), "")%>',
                                                '<%# IIf(Not IsDBNull(Eval("ASSESSEDDATE")), Eval("ASSESSEDDATE"), "")%>')"><%# Eval("REQUESTID")%></a>
                                            <%--<asp:LinkButton ID="oLabelDate" runat="server" Text='<%# Eval("REQUESTID")%>' 
                                                OnClientClick="viewdetails(<%# Eval("REQUESTID")%>,<%# Eval("ACCTNO")%>,<%# Eval("REQUESTDATE")%>,<%# Eval("INSPECTIONDATE")%>,<%# Eval("STATUS")%>,
                                                <%# Eval("EMAIL")%>,<%# Eval("REMARKS")%>,<%# Eval("ASSESSEDBY")%>,<%# Eval("ASSESSEDDATE")%>)"/>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Account No." HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ACCTNO" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelACCTNO" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Request Date" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="REQUESTDATE" HeaderStyle-ForeColor="White" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelREQUESTDATE" runat="server" Text='<%# Eval("REQUESTDATE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inspection Date" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" Visible="false ">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelINSPECTIONDATE" runat="server" Text='<%# Eval("INSPECTIONDATE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelSTATUS" runat="server" Text='<%# Eval("STATUS")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="EMAIL" HeaderStyle-ForeColor="White" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAIL")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="REMARKS" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelREMARKS" runat="server" Text='<%# Eval("REMARKS")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Assessed by" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ASSESSEDBY" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelASSESSEDBY" runat="server" Text='<%# Eval("ASSESSEDBY")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Assessed Date" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ASSESSEDDATE" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="oLabelASSESSEDDATE" runat="server" Text='<%# Eval("ASSESSEDDATE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script>
        function viewdetails(REQUESTID, ACCTNO, REQUESTDATE, INSPECTIONDATE, STATUS, EMAIL, REMARKS, ASSESSEDBY, ASSESSEDDATE) {
            //alert(REQUESTID + ACCTNO + REQUESTDATE + INSPECTIONDATE + STATUS + EMAIL + REMARKS + ASSESSEDBY + ASSESSEDDATE);
            document.getElementById('<%= _odRequestID.ClientID%>').innerHTML = REQUESTID
            document.getElementById('<%= _odEmail.ClientID%>').innerHTML = EMAIL
            document.getElementById('<%= _odAccountNo.ClientID%>').innerHTML = ACCTNO
            document.getElementById('<%= _odStatus.ClientID%>').innerHTML = STATUS
            document.getElementById('<%= _odRemarks.ClientID%>').innerHTML = REMARKS
            document.getElementById('<%= _odInspectionDate.ClientID%>').innerHTML = INSPECTIONDATE
            document.getElementById('<%= _odAssessedDate.ClientID%>').innerHTML = ASSESSEDDATE
            document.getElementById('<%= _odAssessedBy.ClientID%>').innerHTML = ASSESSEDBY

        }
    </script>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-thumbs-up text-white float-right" style="font-size: 30px;"></i>
                    <h4 class="modal-title text-white" id="myModalLabel">&nbsp;&nbsp;Verify Request Inspection</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-sm ml-auto" id="_oBtnDisapprove" onclick="" runat="server">Cancel</button>
                    <%--<asp:Button runat="server" ID="here" OnClick="Btn_Action_click" CssClass="btn btn-success btn-sm" Text="Confirm" />--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModalApprove" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-thumbs-up text-white float-right" style="font-size: 30px;"></i>
                    <h4 class="modal-title text-white" id="myModalLabelApprove">&nbsp;&nbsp;Verify Inspection Request</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-row form">
                                <div class="col-sm-12">
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer col-lg-12 row mx-0">
                    <div class="col-lg-12 row">
                        <div class="col-lg-6">
                            <label id="_oLblDateInspect2" class="text-xs font-weight-light text-primary text-uppercase">Inspection Date:&nbsp</label>
                            <input type="date" id="_oTextDateInspect" runat="server" rows="1" class="form-control" />
                        </div>
                        <div class="col-lg-6">
                            <label class="text-xs font-weight-light text-primary text-uppercase">Remarks:&nbsp</label>
                            <textarea id="_oTextRemarks" runat="server" rows="1" class="form-control"></textarea>
                        </div>
                    </div>
                    <div class="col-lg-12 m-2 d-flex justify-content-center">
                        <%--<button type="button" class="btn btn-success btn-sm ml-auto " id="_oBtnVerify" runat="server" onserverclick="Btn_Action_click" name="Approved">Approve</button>                                --%>
                        <asp:Button runat="server" ID="Button2" OnClick="Btn_Action_click" CssClass="btn btn-danger btn-sm m-1" Text="Deny" CommandArgument="Denied" />
                        <asp:Button runat="server" ID="Button3" OnClick="Btn_Action_click" CssClass="btn btn-success btn-sm m-1" Text="Approve" CommandArgument="Approved" />

                        <%--<asp:Button runat="server" ID="here" OnClick="Btn_Action_click" CssClass="btn btn-success btn-sm" Text="Confirm" />--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModalDetails" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-thumbs-up text-white float-right" style="font-size: 30px;"></i>
                    <h4 class="modal-title text-white" id="myModalLabelDetails">&nbsp;&nbsp;Details</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="form-row form">
                                <div class="col-sm-12">
                                    <%--<div align="center">
                                        <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">Details</label>
                                    </div>--%>
                                    <br />
                                    <div>
                                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">RequestID:&nbsp</label>
                                        <p class="h6 font-weight-light" runat="server" id="_odRequestID"></p>
                                    </div>
                                    <div>
                                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Email:&nbsp</label>
                                        <p class="h6 font-weight-light" runat="server" id="_odEmail"></p>
                                    </div>
                                    <div>
                                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Account No.:&nbsp</label>
                                        <p class="h6 font-weight-light" runat="server" id="_odAccountNo"></p>
                                    </div>
                                    <div>
                                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Status:&nbsp</label>
                                        <p class="h6 font-weight-light" runat="server" id="_odStatus"></p>
                                    </div>
                                    <div>
                                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Remarks:&nbsp</label>
                                        <p class="h6 font-weight-light" runat="server" id="_odRemarks"></p>
                                    </div>
                                    <div>
                                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Inspection Date:&nbsp</label>
                                        <p class="h6 font-weight-light" runat="server" id="_odInspectionDate"></p>
                                    </div>
                                    <div>
                                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Assessed Date:&nbsp</label>
                                        <p class="h6 font-weight-light" runat="server" id="_odAssessedDate"></p>
                                    </div>
                                    <div>
                                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Assessed By:&nbsp</label>
                                        <p class="h6 font-weight-light" runat="server" id="_odAssessedBy"></p>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer col-lg-12 row mx-0">
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
</asp:Content>
