<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="LGU_GeneralCollectionReport.aspx.vb" Inherits="SPIDC.LGU_GeneralCollectionReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <asp:ScriptManager runat="server"></asp:ScriptManager>



    <textarea id="txarea" name="txarea" style="visibility: hidden; display: none;"></textarea><br>
    <textarea id="txareaall" name="txareaall" style="visibility: hidden; display: none;"></textarea><br>
    <input id="ifchckall" type="hidden" runat="server" />
    <script>
        function MULTITDN(TDN, ifchk) {
            document.getElementById("txarea").value = document.getElementById("txarea").value + ifchk + ":" + TDN + ";";
        }

    </script>

    <script>
        function SELECTALLTDN(IFCHK) {
            var ele = document.getElementsByName("_oCBSelectProperty");
            for (var i = 0; i < ele.length; i++) {
                ele[i].checked = IFCHK
            }
        }
    </script>


    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">GENERAL COLLECTION REPORT</h5>
    </div>

    <div class="card shadow col-lg-12">


        <div class="card-body">
            <div class="form-row col-lg-9">
                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Gateway</span></span>
                        </label>
                        <select runat="server" required name="cmbGateWay" class="form-control" id="cmbGateWay">
                        </select>

                    </div>
                </div>

                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Transaction</span></span>
                        </label>
                        <select runat="server" required name="cmbType" class="form-control" id="cmbType">
                        </select>

                    </div>
                </div>

                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Date From</span></span>
                        </label>
                        <input runat="server" id="txtDateFrom" type="text" class="form-control" />

                    </div>
                </div>

                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Date to</span></span>
                        </label>
                        <input runat="server" id="txtDateTo" type="text" class="form-control" />

                    </div>
                </div>
                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Status</span></span>
                        </label>
                        <select runat="server" required name="cmbStatus" class="form-control" id="cmbStatus">
                        </select>

                    </div>
                </div>

                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Sort by</span></span>
                        </label>
                        <select runat="server" required name="cmbSortBy" class="form-control" id="cmbSortBy">
                            <option value="OPR.TransDate">Date</option>
                            <option value="OPR.PaymentChannel">Gateway</option>
                            <option value="OPR.TxnRefNo">WSP RefNo</option>
                            <option value="OPR.Type">Type</option>
                            <option value="OPR.Acctno">Acctno/AssessNo</option>
                            <option value="TDN">TDN</option>
                            <option value="OPR.TotAmount">Amount</option>
                            <option value="OPR.StatusID">Status</option>
                        </select>

                    </div>
                </div>

                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Order</span></span>
                        </label>
                        <select runat="server" required name="cmbOrder" class="form-control" id="cmbOrder">
                            <option value="ASC" selected>Ascending</option>
                            <option value="DESC" >Descending</option>
                        </select>

                    </div>
                </div>

                <div class="form-group col-md-3">
                    <div>
                        <input type="button" runat="server" id="btnFilter" class="form-control btn btn-success" value="Filter" />

                    </div>
                </div>

            </div>
        </div>

        <div class="col-sm-12" align="center">

            <asp:GridView ID="gv_paymentList" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                AutoGenerateColumns="false"
                RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging"
                PageSize="15">
                <PagerSettings Mode="NumericFirstLast"
                    FirstPageText="First"
                    LastPageText="Last"
                    PageButtonCount="3"
                    Position="Bottom"
                    Visible="true" />
                <PagerStyle CssClass="paging" HorizontalAlign="Center" />

                <Columns>
                    <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("TransDate")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gateway" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelGateway" runat="server" Text='<%# Eval("PaymentChannel")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="WSP RefNo" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabeltxnRefNo" runat="server" Text='<%# Eval("txnRefNo")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Gateway RefNo" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelGatewayRefNo" runat="server" Text='<%# Eval("GatewayRefNo")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelType" runat="server" Text='<%# Eval("Type")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="AcctNo/AssessNo" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelAcctNo" runat="server" Text='<%# Eval("AcctNo")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="TDN" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelTDN" runat="server" Text='<%# Eval("TDN")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelAmount" runat="server" Text='<%# Eval("totAmount", "{0:N2}")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="center">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelStatus" runat="server" Text='<%# Eval("StatusID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>


            <asp:Button class="btn btn-primary btn-sm col-md-2" ID="_oBtnPrint" runat="server" Text="Print" />
            <center>
                 
                        <%--REPORTVIEWER _MSRV--%>
                        <rsweb:reportviewer ID="_oMSRV" runat="server"  SizeToReportContent="false"
                            Width="100%" ZoomMode="PageWidth" Height="650px">
                        </rsweb:reportviewer>
                    </center>

        </div>


     <%--   <div class="card-footer">
            <div class="row">
                <div class="col-sm-10 float-right">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="_oLabelTotalTransactions">
                        Total Number of Transactions:&nbsp;&nbsp;&nbsp;  
                        <asp:Label ID="_oLBLCOUNTALL" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="col-sm-2">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1 float-left" id="_oLabelGrandTotal">
                        Grand Total:  &nbsp;  
                        <asp:Label ID="_oLBLGrandTotal" runat="server"></asp:Label>
                    </p>
                </div>
            </div>
        </div>--%>


    </div>
    <div id="Verify" class="modal fade">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Verification </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <form name="frmForgotPass" method="post" onsubmit="ForgotPassword()">
                        <div class="form-group" style="text-align: center">

                            <label id="lblTransactionNumber"></label>

                        </div>

                        <div class="text-center">
                            <input type="button" style="background-color: #a5eb67" value="Verify" onclick="update(this.value)" />
                            <input type="button" style="background-color: #dd6363" value="Unverified" onclick="update(this.value)" />
                            <input type="hidden" id="actid" runat="server" />
                            <input type="hidden" id="ButtonValue" runat="server" />
                        </div>
                    </form>
                </div>
            </div>
            <script>
                function update(val) {
                    if (val == "Verified") {
                        document.getElementById('<%=ButtonValue.ClientID%>').value = 1
                    }
                    else {
                        document.getElementById('<%=ButtonValue.ClientID%>').value = 0
                    }
                    __doPostBack('UpdateCheck');

                }
            </script>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <input type="hidden" id="err" runat="server" />

    <script>
        function txtchange(id, value) {
            var element = document.getElementById(id);

            if (element.classList.value == "fas fa-minus-circle" || element.classList.value == "fas fa-minus-circle collapsed") {

                element.classList.add("fa-plus-circle");
                element.classList.add("fas");
                element.classList.remove("fa-minus-circle")
                element.classList.value = "fas fa-plus-circle"
                document.getElementById(id).title = "Collapsed"

            } else {

                element.classList.add("fa-minus-circle");
                element.classList.add("fas");
                element.classList.remove("fa-plus-circle")
                element.classList.value = "fas fa-minus-circle"
                document.getElementById(id).title = "Expand"




            }

        }

        function ClickUpdate(id) {
            document.getElementById('<%=actid.ClientID%>').value = id
            document.getElementById('lblTransactionNumber').innerHTML = id

           <%--  alert(id + value)
             var grid = document.getElementById("<%= _oGridViewSPIDCPay.ClientID%>");
             for (var i = 0; i < grid.rows.length - 1; i++) {
                 var txtAmountReceive = $("_oLabelTransactioNumber1]")
                 alert(txtAmountReceive)
                 if (txtAmountReceive[i].value != '') {
                     alert(txtAmountReceive[i].value);
                 }
             }

             var element = document.getElementById(id);
             __doPostBack('UpdateCheck');--%>
        }


    </script>

</asp:Content>
