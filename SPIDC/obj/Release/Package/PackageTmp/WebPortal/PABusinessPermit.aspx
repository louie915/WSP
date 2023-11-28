<%@ Page Title="" EnableEventValidation="false" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/AbstractReportMaster.Master" CodeBehind="PABusinessPermit.aspx.vb" Inherits="SPIDC.PABusinessPermit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js"></script>
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
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
        };

    </script>
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="col-lg-12 row">
        <div class=" col-lg-12 mt-5 row">
            <div class="col-lg-12 row">
                <div class="col-3">
                    <div style="display: none">
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Year </span></span>
                        </label>
                        <input type="text" runat="server" class="form-control ch-size-new" value="2020" />
                    </div>
                </div>
                <div class="col-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Search Filter </span></span>
                        </label>
                        <%--<input type="text" runat="server" class="form-control ch-size-new" />--%>
                        <select class="form-control ch-size-new" id="_oCmbFilter" runat="server">
                            <option>BIN</option>
                            <option>OWNER</option>
                            <option>TRADE NAME</option>
                        </select>
                    </div>
                </div>
                <div class="col-4">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Search Key</span></span>
                        </label>
                        <input type="text" id="_oTxtSearch" runat="server" class="form-control ch-size-new" />

                    </div>
                </div>
                <div>
                    <div>
                        <%--<asp:UpdatePanel runat="server">
                            <ContentTemplate>--%>


                        <a href="#" class="btn btn-primary btn-icon-split ml-2 my-2" onclick="handleEnter()" id="_obtnSearch" runat="server">
                            <span class="icon text-white">
                                <i class="fas fa-search mt-1"></i>
                            </span>
                            <span class="text">Browse Record</span>
                        </a>
                        <%--<asp:Button runat="server" ID="_obtnSearch" CssClass="btn btn-primary btn-icon-split ml-2 my-2" Text="Browse Record" OnClick="_obtnSearch_Click" />--%>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class=" col-lg-12 mt-2">
            <ul class="nav nav-tabs mt-2" id="myTab" runat="server" role="tablist">
                <%--                <li class="nav-item" runat="server">
                    <a class="nav-link active" id="forreviewtabb" data-toggle="tab" href="#ForReviewtab" role="tab" aria-controls="ForReviewtab"
                        aria-selected="true" onclick="getID(this.id)" runat="server">For Review</a>--%>
                <%--<input type="hidden" runat="server" id="_oTxtHdnCedulaInd" />--%>
                <%--</li>--%>
                <li class="nav-item">
                    <a class="nav-link active" id="forapprovaltabb" data-toggle="tab" href="#ForApprovaltab" role="tab" aria-controls="ForApprovaltab"
                        aria-selected="false" onclick="getID(this.id)" runat="server">For Approval</a>
                    <%--<input type="hidden" runat="server" id="_oTxtHdnCedulaCorp" />--%>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="approvedtabb" data-toggle="tab" href="#ApprovedTab" role="tab" aria-controls="Approvedtab"
                        aria-selected="false" onclick="getID(this.id)" runat="server">Approved</a>
                    <%--<input type="hidden" runat="server" id="_oTxtHdnCedulaCorp" />--%>
                </li>
                <%--<li class="nav-item">
    <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact"
      aria-selected="false">Contact</a>
  </li>--%>
            </ul>
            <input type="hidden" id="_oHdnTabID" runat="server" />
            <div class="tab-content" id="myTabContent">
                <%------------------------------------------------------------------------------------------------------------------------------------------%>
                <%--                <div class="tab-pane fade show active" runat="server" id="ForReviewtab" role="tabpanel" aria-labelledby="ForReviewtab">                     
                    <div class="mx-1 d-flex justify-content-center">
                        <div class="row mt-3 mx-auto col-lg-12 table-responsive">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                            <asp:GridView ID="_oGVProperty1" runat="server" CssClass="mgrid Table-MobileView col-lg-12" AllowSorting="true"
                                AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" OnPageIndexChanging="datagrid_PageIndexForReview"
                                HeaderStyle-HorizontalAlign="Center" AllowPaging="True" PageSize="5">
                                <pagersettings mode="NumericFirstLast"
                            firstpagetext="First"
                            lastpagetext="Last"
                            pagebuttoncount="10"  
                            position="Bottom"
                            Visible="true"/>         
                        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="_oLblDate" runat="server" Text='<%# Eval("ISSUANCEDATE")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="BIN">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="_oLblBIN" runat="server" Text='<%# Eval("ACCTNO")%>' href="#" data-toggle="modal" data-dismiss="modal" data-target="#DisplayDetails" data-ticket-type="standard-access"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Owner">
                                        <ItemTemplate>
                                            <asp:Label ID="_oLblOwner" runat="server" Text='<%# Eval("OWNERNAME")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="TradeName">
                                        <ItemTemplate>
                                            <asp:Label ID="_oLblTradeName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField HeaderText="Actions" ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true" HeaderStyle-Width="3%"/>
                                </Columns>
                            </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
                        </div>
                    </div>                    
                </div>--%>
                <%------------------------------------------------------------------------------------------------------------------------------------------%>
                <div class="tab-pane fade show active" id="ForApprovaltab" runat="server" role="tabpanel" aria-labelledby="ForApprovaltab">
                    <div class="mx-1 d-flex justify-content-center">
                        <div class="row mt-3 mx-auto col-lg-12 table-responsive">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel2" ClientIDMode="Static">
                                <ContentTemplate>
                                    <asp:GridView ID="_oGvForApproval" runat="server" CssClass="mgrid Table-MobileView col-lg-12" AllowSorting="true"
                                        AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" OnPageIndexChanging="datagrid_PageIndexForApproval"
                                        HeaderStyle-HorizontalAlign="Center" AllowPaging="True" PageSize="5">
                                        <PagerSettings Mode="NumericFirstLast"
                                            FirstPageText="First"
                                            LastPageText="Last"
                                            PageButtonCount="10"
                                            Position="Bottom"
                                            Visible="true" />
                                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLblDate" runat="server" Text='<%# Eval("ISSUANCEDATE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="BIN">
                                                <ItemTemplate>
                                                    <a href="#" id="LinkAcctNoForApproval" data-toggle="modal" data-dismiss="modal" data-target="#DisplayDetails" data-ticket-type="standard-access" onclick="GetAcctNo('<%# Eval("ACCTNO")%>')">
                                                        <asp:Label ID="_oLblBINForApproval" runat="server" Text='<%# Eval("ACCTNO")%>' /></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Owner">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLblOwner" runat="server" Text='<%# Eval("OWNERNAME")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="TradeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLblTradeName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="BIN">
                                                <ItemTemplate>
                                                    <a href="#" onclick="document.getElementById('<%=HdnTxtAttachment.ClientID%>').value = '<%# Eval("ACCTNO")%>';document.getElementById('testclick').click();" data-toggle="modal" data-dismiss="modal" data-target="#DisplayAttachments" data-ticket-type="standard-access">View Attachment/s</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <asp:Button runat="server" ID="testclick" Style="display: none;" />
                <input type="hidden" runat="server" id="HdnTxtAttachment" />
                <asp:Button ID="HdnBtnAttachment" runat="server" Visible="false" />
                <%------------------------------------------------------------------------------------------------------------------------------------------%>
                <div class="tab-pane fade" id="ApprovedTab" runat="server" role="tabpanel" aria-labelledby="ApprovedTab">
                    <div class="mx-1 d-flex justify-content-center">
                        <div class="row mt-3 mx-auto col-lg-12 table-responsive">
                            <asp:UpdatePanel runat="server" ID="UpdatePanel4" ClientIDMode="Static">
                                <ContentTemplate>
                                    <asp:GridView ID="_oGVProperty3" runat="server" CssClass="mgrid Table-MobileView col-lg-12" AllowSorting="true"
                                        AutoGenerateColumns="False" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" OnPageIndexChanging="datagrid_PageIndexApproved"
                                        HeaderStyle-HorizontalAlign="Center" AllowPaging="True" PageSize="5">
                                        <PagerSettings Mode="NumericFirstLast"
                                            FirstPageText="First"
                                            LastPageText="Last"
                                            PageButtonCount="10"
                                            Position="Bottom"
                                            Visible="true" />
                                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLblDate" runat="server" Text='<%# Eval("ISSUANCEDATE")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="BIN">
                                                <ItemTemplate>
                                                    <a href="#" id="LinkAcctNoApproved" data-toggle="modal" data-dismiss="modal" data-target="#DisplayDetails" data-ticket-type="standard-access" onclick="GetAcctNo('<%# Eval("ACCTNO")%>')">
                                                        <asp:Label ID="_oLblBINApproved" runat="server" Text='<%# Eval("ACCTNO")%>' /></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Owner">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLblOwner" runat="server" Text='<%# Eval("OWNERNAME")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="TradeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLblTradeName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <%------------------------------------------------------------------------------------------------------------------------------------------%>
            </div>
        </div>
    </div>
    <a id="hbtn" data-toggle="modal" data-dismiss="modal" data-target="#DisplayDetails" data-ticket-type="standard-access" style="display: none"></a>
    <div class="modal fade" id="DisplayDetails">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;">Details</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body ">
                    <div class="row mx-auto col-lg-12 ">
                        <div class="form-group col-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">BIN:</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBIN" name="_oTxtBIN" required readonly />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                        <div class="form-group col-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Permit No.:</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPermitNo" name="_oTxtPermitNo" required readonly />
                            </div>
                        </div>
                    </div>

                    <div class="row mx-auto col-lg-12">
                        <div class="form-group col-md-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Owner</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtOwner" required readonly />
                            </div>

                        </div>
                        <div class="form-group col-md-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Trade Name:</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTradeName" required readonly />
                            </div>

                        </div>
                        <div class="form-group col-md-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Business Location:</span></span>
                                </label>
                                <textarea class="form-control CH-Size-new" runat="server" id="_oTxtBusinessLoc" readonly></textarea>
                            </div>
                        </div>

                        <div class="form-group col-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">OR Number:</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtORNo" name="_oTxtORNumber" required readonly />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                        <div class="form-group col-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Reviewed By:</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtReviewedBy" name="_oTxtReviewedBy" required readonly />
                            </div>

                            <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                        </div>
                        <div class="form-group col-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">O.R. Date:</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtDate" name="_oTxtDate" required readonly />
                            </div>
                        </div>
                        <div class="form-group col-6">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Total Amount Paid:</span></span>
                                </label>
                                <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtAmount" name="_oTxtAmount" required readonly />
                            </div>
                        </div>
                    </div>

                    <div class="row col-lg-12 ">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server" class="col-lg-12" ClientIDMode="Static">
                            <ContentTemplate>
                                <asp:GridView ID="_oGVPaymentDetails" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChangingSPTrans"
                                    PageSize="25">
                                    <PagerSettings Mode="NumericFirstLast"
                                        FirstPageText="First"
                                        PageButtonCount="10"
                                        Position="Bottom"
                                        Visible="true" />
                                    <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Font-Size="Smaller" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="FEE DESCRIPTION">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="_oTxtDESCRIPTION" runat="server" Text='<%# Eval("DESCRIPTION")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Font-Size="Smaller" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="FEE CATEGORY">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="_oTxtCATEGORY" runat="server" Text='<%# Eval("CATEGORY")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Font-Size="Smaller" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="AMOUNT PAID">
                                            <ItemTemplate>
                                                <asp:Label ID="_oTxtAMTPD" runat="server" Text='<%# Eval("AMTPD", "{0:n}")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Font-Size="Smaller" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="PENALTY AMOUNT">
                                            <ItemTemplate>
                                                <asp:Label ID="_oTxtAMTPEN" runat="server" Text='<%# Eval("AMTPEN", "{0:n}")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Font-Size="Smaller" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%" HeaderText="TOTAL">
                                            <ItemTemplate>
                                                <asp:Label ID="_oTxtTOTAL" runat="server" Text='<%# Eval("TOTAL", "{0:n}")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>

                    <br />
                    <div class="row mx-auto col-lg-12 d-flex align-content-center justify-content-center">
                        <a runat="server" id="_oBtnApprove" data-toggle="modal" data-target="#PINModal" class="btn btn-success text-white">Approve</a> &nbsp &nbsp
                        <a data-dismiss="modal" class="btn btn-danger text-white">Close</a>
                    </div>

                </div>
            </div>
        </div>
    </div>



    <div class="modal fade" id="DisplayAttachments">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;">Details</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body ">

                    <div class="row col-lg-12 ">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" class="col-lg-12" ClientIDMode="Static">
                            <ContentTemplate>
                                <asp:GridView ID="_oGvAttachments" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChangingSPTrans"
                                    PageSize="25">
                                    <PagerSettings Mode="NumericFirstLast"
                                        FirstPageText="First"
                                        PageButtonCount="10"
                                        Position="Bottom"
                                        Visible="true" />
                                    <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Font-Size="Smaller" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="FEE DESCRIPTION">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="_oTxtDESCRIPTION" runat="server" Text='<%# Eval("AcctNo")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Font-Size="Smaller" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="FEE DESCRIPTION">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="_oTxtDESCRIPTION" runat="server" Text='<%# Eval("xFileName")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Action">
                                            <ItemTemplate>
                                                <a href="#" onclick="opennewtab();ViewSPA('xFileName','FileType','ARXFile','<%# Eval("AcctNo")%>', '<%# Eval("xFileName")%>');">View Attachment/s</a>
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
    </div>


    <div class="modal fade " id="PINModal">
        <div class="modal-dialog" style="margin-top: 50% !Important;">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <a class="text-white float-right" style="font-size: 20px;">Enter PIN</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                    <button type="button" class="close text-white" onclick="$('#PINModal').modal('hide');$('#DisplayDetails').modal('show');" aria-hidden="false">&times;</button>
                </div>
                <div class="modal-body" style=".row {text-align: center}">
                    <input type="hidden" name="formType" value="confirmPassword">

                    <div class="form-group col-12 align-content-center justify-content-center d-flex">
                        <input name="firstdigit" class="digit text-center m-2" type="password" required id="pin1" size="1" maxlength="1" tabindex="0" disabled>
                        <input name="secondtdigit" class="digit text-center m-2" type="password" required id="pin2" size="1" maxlength="1" tabindex="1" disabled>
                        <input name="thirddigit" class="digit text-center m-2" type="password" required id="pin3" size="1" maxlength="1" tabindex="2" disabled>
                        <input name="fourthdigit" class="digit text-center m-2" type="password" required id="pin4" size="1" maxlength="1" tabindex="3" disabled>
                    </div>
                    <br />
                    <div class="form-group col-12 align-content-center justify-content-center d-flex">
                        <label id="lblusererror" runat="server"></label>
                    </div>
                    <br />
                    <div class="col-12 d-flex align-content-center justify-content-center">
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('1')">1</button>
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('2')">2</button>
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('3')">3</button>
                    </div>
                    <div class="col-12 d-flex align-content-center justify-content-center">
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('4')">4</button>
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('5')">5</button>
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('6')">6</button>
                    </div>
                    <div class="col-12 d-flex align-content-center justify-content-center">
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('7')">7</button>
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('8')">8</button>
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('9')">9</button>
                    </div>
                    <div class="col-12 d-flex align-content-center justify-content-center">
                        <button type="button" class="btn btn-success col-3 m-2 btn-pin" onclick="EnterPin('C')">✓</button>
                        <button type="button" class="btn btn-primary col-3 m-2 btn-pin" onclick="EnterPin('0')">0</button>
                        <button type="button" class="btn btn-danger col-3 m-2 btn-pin" onclick="EnterPin('x')">❌</button>
                    </div>

                    <style>
                        .btn-pin {
                            max-width: 73px !Important;
                        }
                    </style>

                    <input type="hidden" id="_oHdnPermitNo" runat="server" />
                    <input type="hidden" id="_oHdnORNo" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hdnseqid" />
    <input type="hidden" runat="server" id="hdnName" />
    <input type="hidden" runat="server" id="hdnType" />
    <input type="hidden" runat="server" id="hdnData" />
    <input type="hidden" runat="server" id="hdnFileName" />
    <script>

        function opennewtab() {
            
            //alert(Checkival)
            
                window.document.forms[0].target = '_blank';
                setTimeout(function () { window.document.forms[0].target = ''; }, 0);
            

        }

        function ViewSPA(Name, Type, Data, seqid, FileName) {

            document.getElementById('<%=hdnFileName.ClientID%>').value = FileName;
            document.getElementById('<%=hdnName.ClientID%>').value = Name;
            document.getElementById('<%=hdnType.ClientID%>').value = Type;
            document.getElementById('<%=hdnData.ClientID%>').value = Data;
            __doPostBack('DownloadFiles', seqid);
        }

        function EnterPin(val) {

            if (val == 'x') {
                for (var a = 4; a >= 1; a--) {
                    var pin = document.getElementById("pin" + a);
                    if (String(pin.value) != '') {
                        pin.value = '';
                        break;
                    }
                }
            }
            else if (val == 'C') {
                var PIN;
                var Setpin = document.getElementById("pin" + 4);
                if (Setpin.value != '') {
                    PIN = document.getElementById("pin1").value + document.getElementById("pin2").value + document.getElementById("pin3").value + document.getElementById("pin4").value;
                    __doPostBack('Passkey', PIN);
                }
            }
            else {
                for (var a = 1; a <= 4; a++) {
                    var Setpin = document.getElementById("pin" + a);

                    if (!Setpin.value.length) {
                        Setpin.value = val;
                        break;
                    }
                }
            }


        }

        function getID(id) {;
            document.getElementById("_oHdnTabID").value = id;
            sessionStorage.setItem('TabName', id);
            document.getElementById('<%=_oTxtSearch.ClientID%>').value = '';

        }

        function handleEnter() {
            if (document.getElementById("_oHdnTabID").value == "") {
                document.getElementById("_oHdnTabID").value = "forapprovaltabb"
                sessionStorage.setItem('TabName', document.getElementById("_oHdnTabID").value);
            }
            __doPostBack("Search", document.getElementById("_oHdnTabID").value)
        }

        function GetAcctNo(AcctNo) {
            document.getElementById('<%=_oHdnPermitNo.ClientID%>').value = document.getElementById('<%=_oTxtPermitNo.ClientID%>').value
            document.getElementById('<%=_oHdnORNo.ClientID%>').value = document.getElementById('<%=_oTxtORNo.ClientID%>').value
                        <%--alert(document.getElementById('<%=_oHdnPermitNo.ClientID%>').value);
                        alert(document.getElementById('<%=_oHdnORNo.ClientID%>').value);--%>
            __doPostBack('Insert', AcctNo);
        }

        function clickAttachment(AcctNo) {
            document.getElementById('<%=HdnTxtAttachment.ClientID%>').value() = AcctNo;
        }
        //addLoadEvent(getID('forapprovaltabb'));

    </script>

    <style>
        .modal {
            overflow: auto !Important;
        }
    </style>
</asp:Content>

