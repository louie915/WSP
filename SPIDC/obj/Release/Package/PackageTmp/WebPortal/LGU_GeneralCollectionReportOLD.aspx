<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="LGU_GeneralCollectionReportOLD.aspx.vb" Inherits="SPIDC.LGU_GeneralCollectionReportOLD" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <asp:ScriptManager runat="server">    </asp:ScriptManager>



<textarea id="txarea" name ="txarea" style="visibility: hidden; display: none;"  ></textarea><br>
    <textarea id="txareaall" name ="txareaall" style="visibility: hidden; display: none;"  ></textarea><br>
            <input id="ifchckall" type="hidden" runat="server" />
            <script>
                function MULTITDN(TDN, ifchk) {
                    //alert(ifchk)
                    document.getElementById("txarea").value = document.getElementById("txarea").value + ifchk + ":" + TDN + ";";
                    //document.getElementById("txarea").value = id;
                    //alert(gross + " - " + uniqueID);
                    //alert(document.getElementById("txarea").value)

                }

            </script>

    <script>
        function SELECTALLTDN(IFCHK) {
            //alert(IFCHK)
            //alert(document.getElementByName("_oCBSelectProperty").checked)

            //document.getElementById("_oCBSelectProperty").checked = IFCHK


            var ele = document.getElementsByName("_oCBSelectProperty");
            //alert(IFCHK)
            for (var i = 0; i < ele.length; i++) {
                ele[i].checked = IFCHK
            }

        }

        </script>

    

    <div class="card shadow col-lg-12">        
        <div class=" p-2"><h5 class="m-2 font-weight-bold text-primary">GENERAL COLLECTION REPORT</h5></div>
        <a data-toggle="collapse" data-dismiss="collapse" data-target="#SPIDCPAYLIST" data-ticket-type="standard-access" style="float: left; color: blueviolet" onclick="txtchange(this.id,innerHTML)" id="hdshw1" title="Expand" class="text-primary fas fa-minus-circle mt-4  "> SPIDC PAY
        </a>&nbsp
        <div id="SPIDCPAYLIST" class="collapsed show" >
<%--            <asp:GridView ID="_oGridViewSPIDCPay"  runat="server" CssClass="GridViewStyle "  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("Date")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Time")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Number">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTransactioNumber" runat="server" Text='<%# Eval("TransactionNumber")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Type">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTransactioType" runat="server" Text='<%# Eval("TransactionType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Owner">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelOwner" runat="server" Text='<%# Eval("Owner")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount Paid" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelAmountPaid" runat="server" Text='<%#Eval("AmountPaid", "{0:C}").ToString().Replace("$", "")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Verify"  ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
<%--                            <%--<asp:Label ID="_oLabelAmountPaid" runat="server"  />--%>
<%--                                <center>

                        <asp:CheckBox ID="chkChild" runat="server"   Checked=  '<%# Eval("PostStatus")%>' value='<%# Eval("TransactionNumber")%>'  onclick="ClickUpdate(this.value,)" />  
      
                                    </center>
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <input type ="hidden" id="_htmlReferenceNumber" runat ="server">
            <input type ="hidden" id="_htmlCheckValue" runat ="server">
        </div>--%>







    <asp:GridView ID="_oGridViewSPIDCPay" runat="server" AutoGenerateColumns="false" DataKeyNames="TransactionNumber"
        OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelEdit" OnRowUpdating="OnRowUpdating" CssClass="mgrid"  ShowHeaderWhenEmpty="false">
        <Columns>


                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Date")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Time">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Time")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TransactionNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransactionNumber" runat="server" Text='<%# Eval("TransactionNumber")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="TransactionType">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransactionType" runat="server" Text='<%# Eval("TransactionType")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Owner">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelOwner" runat="server" Text='<%# Eval("Owner")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelAmountPaid" runat="server" Text='<%#Eval("AmountPaid", "{0:C}").ToString().Replace("$", "")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

<%--                                <asp:TemplateField HeaderText="Verify">
                                    <ItemTemplate>
                                        <center>
                                        <asp:CheckBox ID="Checkbox" runat="server"   Checked=  '<%# Eval("PostStatus")%>'  />  
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="" HeaderStyle-CssClass="" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>                                                            
                                    <div class="col-lg-12 ml-2">
                                        <div class="row">
                                            <input type="checkbox"   class="m-1" checked  value ='<%# Eval("TransactionNumber")%>'  id="_oCBSelectProperty" Name="_oCBSelectProperty" onchange="MULTITDN(this.checked,this.value);"/>
                                        </div>
                                    </div>                                                         
                                </ItemTemplate>                                              
                            </asp:TemplateField>

        </Columns>
    </asp:GridView>


<%--<input type="checkbox"  ID="chkSelect" name="chkSelect"  class ="m-1" onchange="SELECTALLTDN(this.checked);chkindicator(this.checked)" />--%>

            <div class="col-lg-12 d-flex justify-content-end align-content-end">
<button href="LGU_MainPage.aspx" type="button" class="btn btn-primary btn-sm my-3 " data-dismiss="modal" id="_obtnProceed" runat="server">Proceed</button>
                </div>
    </div>  

        <div class="card-footer">
            <div class="row">
                <div class="col-sm-10 float-right">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="_oLabelTransaction1">Number of Transactions:   &nbsp  <asp:Label ID="_oLblCountSPIDCPAY" runat="server" ></asp:Label>  </p>
                </div>
                <div class="col-sm-2">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1 float-left" id="_oLabelTotal1">Total: &nbsp  <asp:Label ID="_oLblTotalSPIDCPAY" runat="server" ></asp:Label> </p>
                </div>
            </div>
        </div>

        <div class="card-footer">
        </div>

        <a data-toggle="collapse" data-dismiss="collapse" data-target="#PostedSPIDCPay" data-ticket-type="standard-access" style="float: left; color: blueviolet" onclick="txtchange(this.id,innerHTML)" id="hdshw2" title="Expand" class="text-primary fas fa-minus-circle "> POSTED SPIDC PAY TRANSACTION
        </a>&nbsp
        <div id="PostedSPIDCPay" class="collapsed show" >
            <asp:GridView ID="_oGridViewPostedSPIDCPay"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="false">
                <Columns>
                    <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelDate1" runat="server" Text='<%# Eval("Date")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTime1" runat="server" Text='<%# Eval("Time")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Number">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTransactioNumber1" runat="server" Text='<%# Eval("TransactionNumber")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Type">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTransactioType1" runat="server" Text='<%# Eval("TransactionType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Owner">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelOwner1" runat="server" Text='<%# Eval("Owner")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount Paid" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelAmountPaid1" runat="server" Text='<%#Eval("AmountPaid", "{0:C}").ToString().Replace("$", "")%>' />
                            </ItemTemplate>
                        <%--<ItemTemplate>
                        <input type="checkbox"   class="m-1" value='<%# Eval("TransactionNumber")%>'  id="_oCBSelectCheckbox" Name="_oCBSelectCheckbox" onchange="MULTITDN(this.checked,this.value);"/>
                        </ItemTemplate>--%>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="card-footer">
            <div class="row">
                <div class="col-sm-10 float-right">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="_oLabelTransaction2">Number of Transactions: &nbsp  <asp:Label ID="_oLblCountPostedSPIDCPay" runat="server" ></asp:Label> </p>
                </div>
                <div class="col-sm-2">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1 float-left" id="_oLabelTotal2">Total: &nbsp  <asp:Label ID="_oLblTotalPostedSPIDCPay" runat="server" ></asp:Label>  </p>
                </div>
            </div>
        </div>

                        <a data-toggle="collapse" data-dismiss="collapse" data-target="#UnpaidLandBank" data-ticket-type="standard-access" style="float: left; color: blueviolet" onclick="txtchange(this.id,innerHTML)" id="hdshw3" title="Expand" class="text-primary fas fa-minus-circle mt-4  "> LAND BANK
        </a>&nbsp
        <div id="UnpaidLandBank" class="collapsed show" >

    <asp:GridView ID="_oGridViewUnpaidLandBank" runat="server" AutoGenerateColumns="false" DataKeyNames="TransactionNumber"
        OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelEdit" OnRowUpdating="OnRowUpdating" CssClass="mgrid"  ShowHeaderWhenEmpty="false">
        <Columns>


                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Date")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Time">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Time")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TransactionNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransactionNumber" runat="server" Text='<%# Eval("TransactionNumber")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="TransactionType">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransactionType" runat="server" Text='<%# Eval("TransactionType")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Owner">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelOwner" runat="server" Text='<%# Eval("Owner")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelAmountPaid" runat="server" Text='<%#Eval("AmountPaid", "{0:C}").ToString().Replace("$", "")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="" HeaderStyle-CssClass="" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>                                                            
                                    <div class="col-lg-12 ml-2">
                                        <div class="row">
                                            <input type="checkbox"   class="m-1" checked  value ='<%# Eval("TransactionNumber")%>'  id="_oCBSelectProperty" Name="_oCBSelectProperty" onchange="MULTITDN(this.checked,this.value);"/>
                                        </div>
                                    </div>                                                         
                                </ItemTemplate>                                              
                            </asp:TemplateField>

        </Columns>
    </asp:GridView>
            <div class="col-lg-12 d-flex justify-content-end align-content-end">
<button href="LGU_MainPage.aspx" type="button" class="btn btn-primary btn-sm my-3 " data-dismiss="modal" id="_oBtnProceedLBP" runat="server">Proceed</button>
                </div>
            <div class="card-footer">
            <div class="row">
                <div class="col-sm-10 float-right">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="_oLabelTransaction3">Number of Transactions:   &nbsp  <asp:Label ID="_oLblCountLandBank" runat="server" ></asp:Label>  </p>
                </div>
                <div class="col-sm-2">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1 float-left" id="_oLabelTotal3">Total: &nbsp  <asp:Label ID="_oLblTotalLandBank" runat="server" ></asp:Label> </p>
                </div>
            </div>
        </div>


<%--<input type="checkbox"  ID="chkSelect" name="chkSelect"  class ="m-1" onchange="SELECTALLTDN(this.checked);chkindicator(this.checked)" />--%>

            
    </div>

        <a data-toggle="collapse" data-dismiss="collapse" data-target="#PostedLandBank" data-ticket-type="standard-access" style="float: left; color: blueviolet" onclick="txtchange(this.id,innerHTML)" id="hdshw4" title="Expand" class="text-primary fas fa-minus-circle "> POSTED LAND BANK TRANSACTION
        </a>&nbsp
        <div id="PostedLandBank" class="collapsed show" >
            <asp:GridView ID="_oGridViewPostedLandBank"  runat="server" CssClass="GridViewStyle mgrid "  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="false">
                <Columns>
                    <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelDate1" runat="server" Text='<%# Eval("Date")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTime1" runat="server" Text='<%# Eval("Time")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Number">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTransactioNumber1" runat="server" Text='<%# Eval("TransactionNumber")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Type">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTransactioType1" runat="server" Text='<%# Eval("TransactionType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Owner">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelOwner1" runat="server" Text='<%# Eval("Owner")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount Paid" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelAmountPaid1" runat="server" Text='<%#Eval("AmountPaid", "{0:C}").ToString().Replace("$", "")%>' />
                            </ItemTemplate>
                        <%--<ItemTemplate>
                        <input type="checkbox"   class="m-1" value='<%# Eval("TransactionNumber")%>'  id="_oCBSelectCheckbox" Name="_oCBSelectCheckbox" onchange="MULTITDN(this.checked,this.value);"/>
                        </ItemTemplate>--%>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="card-footer">
            <div class="row">
                <div class="col-sm-10 float-right">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="_oLabelTransaction4">Number of Transactions:   &nbsp  <asp:Label ID="_oLblCountPostedLandBank" runat="server" ></asp:Label>  </p>
                </div>
                <div class="col-sm-2">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1 float-left" id="_oLabelTotal4">Total: &nbsp  <asp:Label ID="_oLblTotalPostedLandBank" runat="server" ></asp:Label> </p>
                </div>
            </div>
        </div>
        </div>

                <a data-toggle="collapse" data-dismiss="collapse" data-target="#UnpaidDBP" data-ticket-type="standard-access" style="float: left; color: blueviolet" onclick="txtchange(this.id,innerHTML)" id="hdshw5" title="Expand" class="text-primary fas fa-minus-circle mt-4  "> DEVELOPMENT BANK OF THE PHILIPPINES
        </a>&nbsp
        <div id="UnpaidDBP" class="collapsed show" >

    <asp:GridView ID="_oGridViewUnpaidDBP" runat="server" AutoGenerateColumns="false" DataKeyNames="TransactionNumber"
        OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelEdit" OnRowUpdating="OnRowUpdating" CssClass="mgrid"  ShowHeaderWhenEmpty="false">
        <Columns>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Date")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Time">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Time")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TransactionNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransactionNumber" runat="server" Text='<%# Eval("TransactionNumber")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TransactionType">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransactionType" runat="server" Text='<%# Eval("TransactionType")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelOwner" runat="server" Text='<%# Eval("Owner")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelAmountPaid" runat="server" Text='<%#Eval("AmountPaid", "{0:C}").ToString().Replace("$", "")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="" HeaderStyle-CssClass="" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="center">
                                <ItemTemplate>                                                            
                                    <div class="col-lg-12 ml-2">
                                        <div class="row">
                                            <input type="checkbox"   class="m-1" checked  value ='<%# Eval("TransactionNumber")%>'  id="_oCBSelectProperty" Name="_oCBSelectProperty" onchange="MULTITDN(this.checked,this.value);"/>
                                        </div>
                                    </div>                                                         
                                </ItemTemplate>                                              
                            </asp:TemplateField>

        </Columns>
    </asp:GridView>
            <div class="col-lg-12 d-flex justify-content-end align-content-end">
<button href="LGU_MainPage.aspx" type="button" class="btn btn-primary btn-sm my-3 " data-dismiss="modal" id="Button2" runat="server">Proceed</button>
                </div>
            <div class="card-footer">
            <div class="row">
                <div class="col-sm-10 float-right">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="_oLabelTransaction5">Number of Transactions:   &nbsp  <asp:Label ID="_oLblCountUnpaidDBP" runat="server" ></asp:Label>  </p>
                </div>
                <div class="col-sm-2">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1 float-left" id="_oLabelTotal5">Total: &nbsp  <asp:Label ID="_oLblTotalUnpaidDBP" runat="server" ></asp:Label> </p>
                </div>
            </div>
        </div>
        </div>

                <a data-toggle="collapse" data-dismiss="collapse" data-target="#PostedDBP" data-ticket-type="standard-access" style="float: left; color: blueviolet" onclick="txtchange(this.id,innerHTML)" id="hdshw4" title="Expand" class="text-primary fas fa-minus-circle "> POSTED DEVELOPMENT BANK OF THE PHILIPPINES TRANSACTIONS
        </a>&nbsp
        <div id="PostedDBP" class="collapsed show" >
            <asp:GridView ID="_oGridViewPostedDBP"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="false">
                <Columns>
                    <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelDate1" runat="server" Text='<%# Eval("Date")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTime1" runat="server" Text='<%# Eval("Time")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Number">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTransactioNumber1" runat="server" Text='<%# Eval("TransactionNumber")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Transaction Type">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelTransactioType1" runat="server" Text='<%# Eval("TransactionType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Owner">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelOwner1" runat="server" Text='<%# Eval("Owner")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount Paid" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                            <asp:Label ID="_oLabelAmountPaid1" runat="server" Text='<%#Eval("AmountPaid", "{0:C}").ToString().Replace("$", "")%>' />
                            </ItemTemplate>
                        <%--<ItemTemplate>
                        <input type="checkbox"   class="m-1" value='<%# Eval("TransactionNumber")%>'  id="_oCBSelectCheckbox" Name="_oCBSelectCheckbox" onchange="MULTITDN(this.checked,this.value);"/>
                        </ItemTemplate>--%>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div class="card-footer">
            <div class="row">
                <div class="col-sm-10 float-right">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="_oLabelTransaction6">Number of Transactions:   &nbsp  <asp:Label ID="_oLblCountPostedDBP" runat="server" ></asp:Label>  </p>
                </div>
                <div class="col-sm-2">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1 float-left" id="_oLabelTotal6">Total: &nbsp  <asp:Label ID="_oLblTotalPostedDBP" runat="server" ></asp:Label> </p>
                </div>
            </div>
        </div>
        </div>


                <div class="col-sm-12" align="center">
                    <br />
                    <br />
                    <asp:Button class="btn btn-primary btn-sm col-md-2" id="_oBtnPrint" runat="server" Text="Print" />
                    <center>
                 
                        <%--REPORTVIEWER _MSRV--%>
                        <rsweb:reportviewer ID="_oMSRV" runat="server"  SizeToReportContent="false"
                            Width="100%" ZoomMode="PageWidth" Height="650px">
                        </rsweb:reportviewer>
                    </center>

                </div>

        
        <div class="card-footer">
            <div class="row">
                <div class="col-sm-10 float-right">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1" id="_oLabelTotalTransactions">Total Number of Transactions:&nbsp;&nbsp;&nbsp;   <asp:Label ID="_oLBLCOUNTALL" runat="server" ></asp:Label> </p>
                </div>
                <div class="col-sm-2">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1 float-left" id="_oLabelGrandTotal">Grand Total:  &nbsp;   <asp:Label ID="_oLBLGrandTotal" runat="server" ></asp:Label> </p>
                </div>
            </div>
        </div>


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
                        <div class="form-group" style="text-align:center">
                            
                            <label  id="lblTransactionNumber"> </label>

                        </div>

                        <div class="text-center">
                            <input type="button"  style="background-color: #a5eb67" value="Verify" onclick="update(this.value)" />
                            <input type="button"  style="background-color: #dd6363" value="Unverified" onclick="update(this.value)"/>
                            <input type ="hidden" id="actid" runat="server" />
                            <input type ="hidden" id="ButtonValue" runat="server" />
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
