<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="RPTBilling.aspx.vb" Inherits="SPIDC.RPTBilling"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
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
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

    </script>
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>
    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">RPT Billing</h5>
    </div>
    <div class="form-row form Main-Color-White">
        <div class="form-group mx-4 my-2">
            <div>

                <label class="text-capitalize font-weight-bold">
                    Tax. Dec. No: &nbsp
                            <br>
                    <asp:Label ID="_oLblTDN" runat="server" Text="" />
                </label>

            </div>
        </div>

        <div class="form-group mx-4 my-2">
            <div>

                <label class="text-capitalize font-weight-bold">
                    PIN: &nbsp
                            <br>
                    <asp:Label ID="_oLblPIN" runat="server" Text="" />
                </label>

            </div>
        </div>

        <div class="form-group mx-4 my-2">
            <div>


                <label class="text-capitalize font-weight-bold">
                    Kind: &nbsp
                            <br>
                    <asp:Label ID="_oLblKind" runat="server" Text="" />
                </label>

            </div>
        </div>


        <div class="form-group mx-4 my-2">
            <div>

                <label class="text-capitalize font-weight-bold">
                    Declared Owner: &nbsp

                            <br>
                    <asp:Label ID="_oLblOwner" runat="server" Text="" />
                </label>

            </div>
        </div>

        <div class="form-group mx-4 my-2">
            <div>

                <label class="text-capitalize font-weight-bold">
                    Property Location: &nbsp
                            <br>
                    <asp:Label ID="_oLblLocation" runat="server" Text="" />
                </label>

            </div>
        </div>

    </div>
    <div class="card">
        <div class="m-2">
            <div class="form-row form mx-auto row mb-3">
                <div class="form-group col-md-2 my-auto">
                    <div>
                        <%--<label class="input-txt">
                            <span><span style="margin: 0px 5px 5px 5px;">Year</span></span>
                        </label>--%>
                        <asp:DropDownList ID="_radYear" runat="server" AutoPostBack="true" class="form-control CH-Size">
                        </asp:DropDownList>


                    </div>

                </div>

                <label class="float-left col-md-1">Year</label>




                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="RDB" onchange="NextPage();" AutoPostBack="true" Text="&nbsp 1st Quarter" CssClass="my-auto col-sm-2 mx" />
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="RDB" onchange="NextPage();" AutoPostBack="true" Text="&nbsp 2nd Quarter" CssClass="my-auto col-sm-2 mx" />
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="RDB" onchange="NextPage();" AutoPostBack="true" Text="&nbsp 3rd Quarter" CssClass="my-auto col-sm-2 mx" />
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="RDB" onchange="NextPage();" AutoPostBack="true" Text="&nbsp 4th Quarter" CssClass="my-auto col-sm-2 mx" />

            </div>
            <%--                <asp:ScriptManager runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server">                                        
                    <ContentTemplate>--%>




            <%--       </ContentTemplate>    
</asp:UpdatePanel>--%>
            <div class="table-responsive m-2 mx-auto">
                <asp:GridView ID="_oGridViewRPT" runat="server" CssClass="mx-auto " AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
                    <Columns>

                        <asp:TemplateField HeaderText="Year" ItemStyle-HorizontalAlign="center" ItemStyle-Width="7%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelYear" runat="server" Text='<%# Eval("Yr")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Qtr" ItemStyle-HorizontalAlign="center" ItemStyle-Width="7%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelQtr" runat="server" Text='<%# Eval("Qtr")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="TDN" ItemStyle-HorizontalAlign="center" ItemStyle-Width="7%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelQtr" runat="server" Text='<%# Eval("TDN")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ass. Value" ItemStyle-HorizontalAlign="right" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelAssValu" runat="server" Text='<%# Eval("Ass_value", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Basic Tax" ItemStyle-HorizontalAlign="right" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelBasicTax" runat="server" Text='<%# Eval("BTAXDUE", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Pen/Disc" ItemStyle-HorizontalAlign="right" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelPenDisc1" runat="server" Text='<%# Eval("BPENDIS", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="SEF" ItemStyle-HorizontalAlign="right" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelSEF" runat="server" Text='<%# Eval("STAXDUE", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Pen/Disc" ItemStyle-HorizontalAlign="right" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelPenDisc2" runat="server" Text='<%# Eval("SPENDIS", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="IDLE" ItemStyle-HorizontalAlign="right" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelIDLE" runat="server" Text='<%# Eval("ITAXDUE", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Pen/Disc" ItemStyle-HorizontalAlign="right" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelPenDisc3" runat="server" Text='<%# Eval("IPENDIS", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="right" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTotal" runat="server" Text='<%# Eval("TOTAL", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle></FooterStyle>
                </asp:GridView>
            </div>
            <div class="border border-dark" style="display: none;">
                <div class="row m-3 ">
                    <div class="">How would you like your documents to be received? </div>

                    <div class="form-group col-md-2 row my-auto">
                        <input type="radio" id="_oRadioPickup" onclick="pickup();" name="CourierServices" class="form-control CH-Size my-auto col-1" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="1st Quarter" runat="server">
                        <div class="m-0 font-weight-bold text-primary my-auto col">Pickup</div>
                    </div>

                    <div class="form-group col-md-5 row my-auto" style="display: none">
                        <input type="radio" id="_oRadioDelivered" onclick="DELIVERY();" name="CourierServices" class="form-control CH-Size my-auto col-1" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="2nd Quarter" runat="server">
                        <div class="m-0 font-weight-bold text-primary my-auto col">Delivered</div>
                        <asp:Label ID="_oLabelCourierServices" runat="server" Text="250.00" CssClass="col" />
                    </div>



                </div>
            </div>



             <div id="_oDivAddFee" runat="server"  > 
                  <label class="mx-2 my-auto text-capitalize font-weight-bold col-md-2" style="font-size: 8px; text-align: right">Computer Fee:</label>
                    <asp:Label ID="_oLabelComputerFee" runat="server" CssClass="mx-2 my-auto border border-bottom-light rounded-lg" Font-Size="10" Width="370" Style="text-align: right;" />
            </div>
        </div>

          

           
        <div class="row col-md-12 mx-auto my-2 d-flex justify-content-end ">
            <label class="mx-2 my-auto text-capitalize font-weight-bold col-md-2" style="font-size: 17px; text-align: right">Total Amount Due:</label>
            <asp:Label ID="_oLabelTotalAmountDue" runat="server" CssClass="mx-2 my-auto border border-bottom-light rounded-lg" Font-Size="25" Width="370" Style="text-align: right;" />
            <asp:Label ID="_oLabelOrigTotalAmountDue" runat="server" CssClass="mx-2 my-auto border border-bottom-light rounded-lg" Font-Size="25" Width="370" Style="text-align: right; visibility: hidden" />
        </div>


        <div class="">

            <div class="col-md-12 row mx-auto d-flex justify-content-center mb-2">

                <div runat="server" id="div_PaymentFound" style="display: none;">
                    <center>
                <div class="w3-panel w3-pale-yellow"> 
  <p>We've detected that you have already attempted to pay for this TDN.<br />
    • If you have paid successfully, DO NOT proceed and just wait for our Payment Posting to avoid multiple payments. <br />
    • Disregard this message if you have not made any successful payment for this account. <br>
  </p>                  
</div> 
                </center>
                </div>

                <asp:Button ID="_obtnPrintStatement" class="btn btn-primary col-md-3 col-lg-3 m-1 btn-sm" runat="server" Text="Print Statement of Account" />
                <asp:Button ID="_obtnPayment" runat="server" class="btn btn-primary col-md-2 col-lg-2 m-1 btn-sm" Text="Proceed to Payment" />




                <%--  <button name="_obtnPrintStatement" runat="server" id="Button1" type="submit" class="btn btn-primary col-md-3">Print Statement of Account</button>
                            <button name="_obtnPayment" runat="server" id="Button2" type="submit" class="btn btn-primary ">Proceed to Payment</button>--%>
            </div>
        </div>
        <center>
           
         <div class=" col-md-6 w3-panel  w3-pale-yellow" runat="server" id="div_Notice" style="display:none;">
          
         </div> 
                
               
    </center>



        <input type="text" id="TXTTRAPERROR" name="TXTTRAPERROR" style="display: none;" runat="server" />


    </div>

    <script type="text/javascript">
        function Select(Action, TDN) {
            // document.getElementById("selectedTDN").value = TDN;
            //   alert(Action + "-" + document.getElementById("selectedTDN").value);

            __doPostBack(Action, TDN);
        }


        function DELIVERY() {

            var SSS = document.getElementById("<%=_oLabelOrigTotalAmountDue.ClientID%>").textContent

            document.getElementById('<%=_oLabelTotalAmountDue.ClientID%>').textContent = Number(SSS) + 250;

        }

        function pickup() {

            var SSS = document.getElementById("<%=_oLabelOrigTotalAmountDue.ClientID%>").textContent

            document.getElementById('<%=_oLabelTotalAmountDue.ClientID%>').textContent = Number(SSS);

        }
    </script>


</asp:Content>
