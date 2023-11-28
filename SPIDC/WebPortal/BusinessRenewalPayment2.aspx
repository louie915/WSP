<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="BusinessRenewalPayment2.aspx.vb" Inherits="SPIDC.BusinessRenewalPayment2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">

    <asp:ScriptManager runat="server"></asp:ScriptManager>
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

    <input type="hidden" runat="server" id="_err" />
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>



    <div class="modal fade" id="modadeclineapplciation">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-question-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="modadeclineapplciationlabel">Decline Application</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <label class="font-weight-light text-gray mb-1" id="_olblMessage">Click [Confirm] to decline the application, please provide reason on the remarks below.</label>
                    <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Remarks:&nbsp</label>
                    <textarea id="_oTextRemarks" runat="server" rows="1" class="form-control"></textarea>
                </div>
                <div class="modal-footer">
                    <input type="button" runat="server" id="btnDecline" class="btn btn-success btn-sm" value="Confirm" />
                </div>
            </div>
        </div>
    </div>

    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Business Renewal Payment</h5>
    </div>

    <link href="../CSS_JS_IMG/css/newcss/aurora/aurora.css" rel="stylesheet" />


    <div>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>




    <div class="card">
        <div class="form-row form ">
            <div class="form-group mx-4 my-2">
                <label class="text-capitalize font-weight-bold text-primary">
                    Bus. ID Number: &nbsp
                            <br>
                    <asp:Label ID="_oLblBusID" runat="server" Text="" />
                </label>
            </div>

            <div class="form-group mx-4 my-2">
                <label class="text-capitalize font-weight-bold text-primary">
                    Bus. Owner/Manager: &nbsp
                            <br>
                    <asp:Label ID="_oLblBusOwner" runat="server" Text="" />
                </label>
            </div>

            <div class="form-group mx-4 my-2">
                <label class="text-capitalize font-weight-bold text-primary">
                    Business Name: &nbsp
                            <br>
                    <asp:Label ID="_oLblBusName" runat="server" Text="" />
                </label>
            </div>

            <div class="form-group mx-4 my-2">
                <label class="text-capitalize font-weight-bold text-primary">
                    Business Ownership: &nbsp
                            <br>
                    <asp:Label ID="_oLblBusOwnership" runat="server" Text="" />
                </label>
            </div>



            <div class="form-group mx-3 my-2 w3-third">
                <label class="text-capitalize font-weight-bold text-primary">
                    Business Address: &nbsp
                            <br>
                    <asp:Label ID="_oLblBusAddress" runat="server" Text="" />
                </label>
            </div>



        </div>
        <center>

         
        <div class="table-responsive col-lg-12 mt-4" style="border:1px solid #EAE9E9">
            
                <div style="text-align:left">
                 <label class="text-capitalize font-weight-bold text-primary" >
                     Business Line
                    </label>
            </div>
            
             <asp:GridView ID="_GVBusinessLine" runat="server" CssClass="mGrid col-lg-11 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>
                    <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>
                            <label class="txBusCode"><%# Eval("BUS_CODE")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Business Line" ItemStyle-HorizontalAlign="CENTER"  >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("BUSLINE")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CATEGORY" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
      <br />
            <div runat="server" id="div_SubmittedRequirements">
            <div style="text-align:left">
                 <label class="text-capitalize font-weight-bold text-primary" >
                     Submitted Requirements 
                    </label>           
            </div>           
                               
            <asp:GridView ID="_GVRequirements" runat="server" CssClass="mGrid col-lg-11 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>                 
                     <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <label><%# Eval("REQCODE")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Requirement" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>
                            <label><%# Eval("REQDESC")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>                  

                    <asp:TemplateField HeaderText="File Uploaded" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>                
                            <a download="<%# Eval("FileName")%>"
                               href="<%# Eval("File64")%>"   
                              target="_blank">
                               Download
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>

             

                </Columns>
            </asp:GridView>

           </div>
                 <br />
 <div class="btn-primary" style="text-align:left;background-color:lightgray">  
<a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" 
    href="#div_Regulatory" role="button" aria-haspopup="true" aria-expanded="false" 
    >  Billing Information        </a>
</div>  
             <div class="form-group mx-4 my-2" style="text-align:left">
                    <div>

                         <label class="text-capitalize font-weight-bold text-primary">
                            Period Covered  &nbsp
                            <br>
                            <asp:Label ID="lblPeriodCovered" runat="server" Text="" />
                        </label>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Mode of Payment &nbsp
                            <br>
                            <asp:Label ID="LblMOP" runat="server" Text="" />
                        </label>

                    </div>
                </div>
                    

            <div id="div_TOP" runat="server" class="MainDiv collapse show" style="border:2px double lightgray">
          
     <div class="collapse show" id="_oPNGrid_TOP">        
          <center>
         <asp:GridView ID="GridViewTOP" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="98%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" ShowFooter="true">
                      
                <Columns>
                    <asp:TemplateField HeaderText="Code" >
                        <ItemTemplate>
                            <asp:Label ID="BUS_CODE" runat="server" Text='<%# Eval("BUS_CODE")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tax Description"  >
                        <ItemTemplate>
                            <asp:Label ID="Desc1" runat="server" Text='<%# Eval("Desc1")%>' />
                        </ItemTemplate>                     
                    </asp:TemplateField>   

                       <asp:TemplateField HeaderText="TaxBase" Visible="false"  >
                        <ItemTemplate>
                            <asp:Label ID="TaxBase" runat="server" Text='<%# If(Eval("TaxBase").ToString() = "", "", Format(Eval("TaxBase"), "standard"))%>'  />
                        </ItemTemplate>                     
                               <ItemStyle HorizontalAlign="Right"/>       
                    </asp:TemplateField>   
 
 
                    <asp:TemplateField HeaderText="Taxdue"  >
                        <ItemTemplate>
                            <asp:Label  ID="Amt_Pd" runat="server" Text='<%# If(Eval("Amt_Pd").ToString() = "", "0", Format(Eval("Amt_Pd"), "standard"))%>'  />
                        </ItemTemplate>             
                           <ItemStyle HorizontalAlign="Right"/>       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Penalty" >
                        <ItemTemplate>
                               <asp:Label  ID="Amt_PenPd" runat="server" Text='<%# If(Eval("Amt_PenPd").ToString() = "", "0", Format(Eval("Amt_PenPd"), "standard"))%>'  />
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Right"/>       
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Total Due"  >
                        <ItemTemplate>
                               <asp:Label  ID="Totdue" runat="server" Text='<%# If(Eval("Totdue").ToString() = "", "0", Format(Eval("Totdue"), "standard"))%>'  />
                        </ItemTemplate>
                          <ItemStyle HorizontalAlign="Right"/>       
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Period Cover" HeaderStyle-Width = "10%" >
                        <ItemTemplate>     
                            <div style="display:inline-block;text-align:left;float:left">
                                <asp:Label ID="Period" runat="server" Text='<%# Eval("Pres")%>' />
                            </div>
                            <div style="display:inline-block;text-align:right;float:right">
                                <asp:Label ID="Cover" runat="server" style="text-align:right" Text='<%# Eval("Prev")%>' />
                             
                            </div>
                        </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center"/>  
                              
                      
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Excess Tax Credit"  HeaderStyle-Width = "8%">
                        <ItemTemplate>
                            <asp:Label ID="Discount" runat="server" Text='<%# If(Eval("Discount").ToString() = "", "", Format(Eval("Discount"), "standard"))%>' />
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Right"/>   
                    </asp:TemplateField>  
                </Columns>
            </asp:GridView>
             </center> 
           <br /><center>
         <table style="right:20px;font-size:20px;"">
             <tr runat="server" id="trCTC">
                  <td>CTC Amount</td>
                 <td>: Php &nbsp</td>
                 <td style="text-align:right"><span runat="server" id="lblCTCAmount"></span></td>
               
             </tr>
             <tr >
                <td>TOTAL DUE </td>
                 <td>: Php &nbsp</td>
                 <td style="text-align:right"> <span runat="server" id="TotAmtDue">0.00</span></td>
         
             </tr>            
             <tr>
                   <td style="border-top: thin solid;" ><h1>Grand Total </h1></td>
                 <td style="border-top: thin solid;">: Php &nbsp</td>
                 <td style="border-top: thin solid;"><h1><span runat="server" id="GrandTotal">0.00</span></h1></td>
           
             </tr>
         </table>
             </center>

           <div runat="server" id="div_PaymentFound" style="display:none;">
                <center>
                <div class="w3-panel w3-pale-yellow"> 
  <p>We've detected that you have already attempted to pay for this Account.<br />
    • If you have paid successfully, DO NOT proceed and just wait for our Payment Posting to avoid multiple payments. <br />
    • Disregard this message if you have not made any successful payment for this account. <br>
  </p>                  
</div> 
                </center>
                </div>

            <div class=" d-flex justify-content-center">
                
                        <div class="col-md-12 row d-flex justify-content-center">
                            <a href="#" onclick="do_Action('DL_AppForm',this.id);" style="display:none;" class="btn btn-primary form-group col-md-3"><i class="fa fa-download"></i> Download Application Form</a>&nbsp
                            <a href="#" onclick="do_Action('DL_TOP',this.id);" class="btn btn-primary form-group col-md-3"><i class="fa fa-download"></i> Download Tax Order of Payment</a>&nbsp
                            <a href="#" onclick="do_Action('Payment',this.id);" class="btn btn-success form-group col-md-3"><i class="fa fa-money-bill"></i> Proceed to Payment</a>

                            <div style="display:none;">
                                        <input type="button" runat="server" id="btn_AppForm" value="Download Application Form" class="btn btn-primary w-25"/>                        
               <input type="button" runat="server" id="btn_TOP" value="Download Tax Order of Payment" class="btn btn-primary w-25"/>
          <input type="button" runat="server" id="btnPayNow" value="Proceed to Payment" class="btn btn-primary w-25" />
                            </div>
                    
          </div>
                 
                    </div>       
     

          
          </div>           
   <br /> 
                             </div>
        </div>
            </center>
    </div>



    <script>
        function do_Action(action, id) {
            //  document.getElementById(id).disabled = true;
            console.log(action);
            switch (action) {
                case 'DL_AppForm':
                    document.getElementById('<% = btn_AppForm.ClientID%>').click();
                    break;
                case 'DL_TOP':
                    document.getElementById('<% = btn_TOP.ClientID%>').click();
                    break;
                case 'Payment':
                    document.getElementById('<% = btnPayNow.ClientID%>').click();
                    break;
            }

        }
        function hasset() {
            for (var i = 0; i < document.getElementsByClassName('txtTpAsset').length; i++) {
                document.getElementsByClassName('txtTpAsset')[i].style.display = 'none';
                document.getElementsByClassName('txtTpAsset')[i].innerText = '';
            }
            for (var i = 0; i < document.getElementsByClassName('txtAsAsset').length; i++) {
                document.getElementsByClassName('txtAsAsset')[i].style.display = 'none';
                document.getElementsByClassName('txtAsAsset')[i].innerText = '';
            }
            for (var i = 0; i < document.getElementsByClassName('txtPrevAsset').length; i++) {
                document.getElementsByClassName('txtPrevAsset')[i].style.display = 'none';
                document.getElementsByClassName('txtPrevAsset')[i].innerText = '';
            }
        }





    </script>

    <style>
        .col-sm-4half {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }

        @media (min-width: 768px) {
            .col-sm-4half {
                float: left;
            }

            .col-sm-4half {
                width: 37.49997%;
            }
        }
    </style>


</asp:Content>

