<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="BusinessRenewalPayment.aspx.vb" Inherits="SPIDC.BusinessRenewalPayment" %>

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

    <input type="hidden" runat="server" id="_err"/>
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>

     <!-- Modal Request Form -->
      <div id="Request" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Request to Change Mode of Payment</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                 <br />
               <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Select Mode of Payment <b style="color:red">*</b> </span></span>
                 </label>
                  <select required runat="server" id="cmb_MOP" class="form-control">   
                      <option value="Quarterly">Quarterly</option>         
                      <option value="Semi-Annual">Semi-Annual</option>   
                      <option value="3-Quarters">3-Quarters</option>   
                      <option value="Annually">Annually</option>                 
                  </select> 
                 <br />
                   
               
                </div>              
  
               <div class="text-center">
                  <input type="button" runat="server"  ID="btnRequest" class="btn btn-primary small" value="Submit Request"/>
              <br /> <br />

               

              
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->

    <div class=" p-2"><h5 class="m-2 font-weight-bold text-primary">Business Renewal Payment</h5></div>
       <%-- ADDEDD BY LOUIE  PAGE STEP INDICATOR --%>
    <%--<link href="../CSS_JS_IMG/css/newcss/aurora/aurora.css" rel="stylesheet" />--%>
    <%--<link href="../css/aurora/aurora.css" rel="stylesheet" />--%>
    <link href="../CSS_JS_IMG/css/newcss/aurora/aurora.css" rel="stylesheet" />
   <%-- -------%>

    <div>
       <%-- <div aria-label="progress" class="step-indicator">
                 <ul class="steps">
                     <li class="complete"> <span class="sr-only">completed</span></li>
                     <li class="active" aria-current="true"></li>
                     <li><span class="sr-only"></span></li>
                     <li><span class="sr-only"></span></li>
                  </ul>
             </div>--%>               

    </div>
    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $('input').keyup(function () {
                var $txt = $(this).val();
                $(this).attr('title', $txt);
            })
        })

        $(document).ready(function () {
            $('select').change(function () {
                var $txt = $(this).val();
                $(this).attr('title', $txt);
            })
        })
    </script>
        
    <div class="card">
        <div class="">


            <div class="form-row form " >
                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Bus. ID Number: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusID" runat="server" text="" />
                        </label>
                        
                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Bus. Owner/Manager: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusOwner" runat="server" text="" />
                        </label>
                        
                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>


                        <label class="text-capitalize font-weight-bold text-primary">Business Name: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusName" runat="server" text="" />
                        </label>
                        
                    </div>
                </div>


                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Business Address: &nbsp

                            <br>
                            <asp:Label ID="_oLblBusAddress" runat="server" text="" />
                        </label>
                        
                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Business Line: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusCategory" runat="server" Text="" />
                        </label>
                        
                    </div>
                </div>


                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Category: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusCategory1" runat="server" text="" />
                        </label>
                        
                    </div>
                </div>

               

                
            </div>
            <center>
            <div class="table-responsive col-lg-12" >

             <asp:GridView ID="_GVBusinessLine" runat="server" CssClass="mGrid col-lg-10" AllowSorting="true"  
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" >
                <Columns>
                    <asp:TemplateField HeaderText="Business Line" ItemStyle-HorizontalAlign="left" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="CATEGORY" ItemStyle-HorizontalAlign="left" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY1")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Previous Gross" ItemStyle-HorizontalAlign="right" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelPrevGross" runat="server" Text='<%# Eval("PREVGROSS", "{0:C}").ToString().Replace("$", "")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tax Payer's Gross" ItemStyle-HorizontalAlign="right" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelTaxPayerGross" runat="server"  Text='<%# Eval("GROSSAMT", "{0:C}").ToString().Replace("$", "")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="BPLO Gross" ItemStyle-HorizontalAlign="right" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBPLOGross" runat="server"  Text='<%# Eval("BPLOGross", "{0:C}").ToString().Replace("$", "")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="New Gross" Visible="false" ItemStyle-HorizontalAlign="right" ItemStyle-Width="20%">
                        <ItemTemplate>
                           <%-- <asp:TextBox ID="_oLabelEnterGross" runat="server"  />--%>
                            <asp:Label ID="_oLabelGrossNew" runat="server"  Text='<%# Eval("GROSSNEW", "{0:C}").ToString().Replace("$", "")%>' />
                            <%--<input type="text"" style="width:100%;text-align:right;border:none;background-color:#6495ed;color: white"  ID="_oLabelEnterGross"  value='<%# Eval("GROSSINPUT", "{0:C}").ToString().Replace("$", "")%>' onblur="GrossEntry(this.value,'<%# Eval("BUSCODE")%>');" onkeypress="return isNumberKey(event)"/>--%>

                            <script>

                                function removeComma(val) {
                                    document.getElementById(val.id).value = val.value.replace(/,/g, '');
                                }

                                function formatMoney(val) {

                                    var formatter = new Intl.NumberFormat('en-US', {
                                        style: 'currency',
                                        currency: 'PHP',
                                    });

                                    var x = formatter.format(val.value);
                                    x = x.split('PHP').join('');
                                    x = x.replace(/\s/g, '');
                                    x = x.replace('₱', '');
                                    document.getElementById(val.id).value = x;
                                }

                                webshims.setOptions('forms-ext', {
                                    replaceUI: 'auto',
                                    types: 'number'
                                });
                                webshims.polyfill('forms forms-ext');

                                    </script>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>


            </asp:GridView>
                </div> 


                </center> 


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



                            <center>
                               
                                <div class="card col-sm-12 px-0" style="display:none">
                                    <div class="card-body">
                                        <div class="row mx-0 px-0">
                                            <div class="col-sm-4half px-0">
                                                <asp:Panel runat="server" ID="_opnlAllAskHeading" CssClass="col-12 px-0"></asp:Panel>
                                            </div>
                                            <div class="col-sm-4half px-0">
                                                <asp:Panel runat="server" ID="_opnlTextAskQ" CssClass="col-12 px-0"></asp:Panel>
                                            </div>
                                            <div class="col-sm-3 px-0">
                                                <asp:panel runat="server" ID="_opnlDrpDownAskOpt" CssClass="col-12 px-0"></asp:panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </center>

                            <div class="row">
                                <asp:ListBox ID="_oListBox1" runat="server" style="display:none">
                                  
                                </asp:ListBox>
                            </div> 

                <div class=" d-flex justify-content-center" style="display:none">
                
                        <div class="col-md-12 row d-flex justify-content-center">

                            <%--<button name="_obtnSaveEdit" runat="server" id="_obtnSaveEdit" type="submit" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" AutoPostBack="True">Compute</button>--%>
                            <button name="_obtnPrintApplication" runat="server" id="_obtnPrintApplication" type="submit" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" style="display:none;">Print Application Form</button>
                        </div>
                 
                    </div>
         


<textarea id="txarea" name ="txarea" style="visibility: hidden; display: none;"  ></textarea><br>
            
            <script>
                function GrossEntry(gross, uniqueID) {
                    document.getElementById("txarea").value = document.getElementById("txarea").value + uniqueID + ":" + gross + ";";
                    //document.getElementById("txarea").value = id;
                    //alert(gross + " - " + uniqueID);


                }
            </script>
 <div style="display:none">
            <div class="d-flex justify-content-center col-lg-12" style="display:none">
                                <div class="form-row form row my-auto col-lg-11">

                    <div class="form-group col-md-12 my-auto row">
                        <div class="col-md-2 ml-auto row">                            
                            <select runat="server" id="_radYear" name="radYear" style="display:none;" class="form-control CH-Size col-12">
                                <option value="2020" disabled selected>2020</option>
                                <option value="2021">2021</option>
                                <option value="2022">2022</option>
                            </select>
                            
                        </div>

                        <label class="float-left col-md-1" style="display:none">Year</label> 
                        <asp:Panel ID="_oPnRadQtr" runat="server" CssClass="row col-md-9 mb-2">

                        </asp:Panel>

                    </div>


                        




                    <script>
                        function Quarter(name) {
                            __doPostBack('QuarterClick', name);
                        }
                        function Deliver(val) {
                            __doPostBack('Receive', val);
                        }
                    </script>

                </div>

            </div> 
           
            <div class=" table-responsive">


                <asp:GridView ID="_oGVBusinessRenewal" runat="server" CssClass="mGrid col-lg-12 mx-auto" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center" Width="85%">
                    <Columns>

                        <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("TAXDESC")%>' />

                            </ItemTemplate>

                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Qtr" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelQtr" runat="server" Text='<%# Eval("QTR")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gross Dec" Visible="false" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelGrossDec" runat="server" Text='<%# Eval("GROSSAMT", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Amount Due" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelAmountDue" runat="server" Text='<%# Eval("AMOUNTDUE", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDiscount" runat="server" Text='<%# Eval("DISCOUNT", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Penalty" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelPenalty" runat="server" Text='<%# Eval("PENDUE", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTotal" runat="server" Text='<%# Eval("TOTAL", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>

                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:TemplateField>




                    </Columns>
                    <FooterStyle></FooterStyle>


                </asp:GridView><br>
                          </div>       
            <br>
            <div class="border border-dark"><div class="row m-3 ">
                <div class="my-auto mx-2" style="display:none;">
                    Should we deliver your Documents (P250.00)?  
                    <asp:CheckBox runat="server" id="_oRadioPickup" AutoPostBack="True"  name="CourierServices" cssclass="CH-Size my-auto mx-2" Text="&nbsp Yes"/>

                </div>

         </div>
        </div>    
            <div class="row col-md-12 mx-auto my-2 d-flex justify-content-end ">
                <label class="mx-2 my-auto text-capitalize font-weight-bold col-md-2" style="font-size:17px;text-align:right">Total Amount Due:</label>          
                <asp:Label ID="_oLabelTotalAmountDue" runat="server" text="0.00" class="mx-2 my-auto border border-bottom-light rounded-lg col-md-5" Font-Size="25" Width="100%" style="text-align: right;"/>                       
                </div>                
         </div>

            
              
 <div class="btn-primary" style="text-align:left;background-color:lightgray">  
<a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" 
    href="#div_Regulatory" role="button" aria-haspopup="true" aria-expanded="false" 
    >  Billing Information        </a>
</div>  

            <div runat="server" id="div_PaymentExpired">
                <div class="w3-panel  w3-pale-yellow">
  <h3>Attention! Payment Disabled</h3>
  <p>Statement of Account has expired. Click here to <a href="BusinessRenewalTaxpayer.aspx" style="color:blue">Request for Updated Statement of Account</a></p>
</div> 

            </div>

          

            <div runat="server" id="div_BillingInfo" >

                  
              <div class="form-group mx-4 my-2" style="display:inline-block">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Period Covered: &nbsp
                            <br>
                            <asp:Label ID="lbl_PeriodCovered" runat="server" text=""  />
                        </label>
                        
                    </div>
                </div>
              <div class="form-group mx-4 my-2" style="display:inline-block">
                    <div>
                   
                        <label class="text-capitalize font-weight-bold text-primary">Payment Mode: &nbsp
                            <br>                
                     
                                <asp:RadioButton ID="_oRadio1stQ" GroupName="QTR" AutoPostBack="true" runat="server" Text="&nbsp 1st Quarter" CssClass="my-auto col-md-3 " />
                                <asp:RadioButton ID="_oRadio2ndQ" GroupName="QTR" AutoPostBack="true" runat="server" Text="&nbsp 2nd Quarter" CssClass="my-auto col-md-3 " />
                                <asp:RadioButton ID="_oRadio3rdQ" GroupName="QTR" AutoPostBack="true" runat="server" Text="&nbsp 3rd Quarter" CssClass="my-auto col-md-3 " />
                                <asp:RadioButton ID="_oRadio4thQ" GroupName="QTR" Checked="false" AutoPostBack="true" runat="server" Text="&nbsp 4th Quarter" CssClass="my-auto col-md-3 " />
                               <asp:Label ID="lbl_Paymode" runat="server" text="" Style="display:none" />
                        </label>
                        
                    </div>
                </div>
              <div class="form-group mx-4 my-2" style="display:none">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">Foryear: &nbsp
                            <br>
                            <asp:Label ID="lbl_Foryear" runat="server" text="" />
                        </label>
                        
                    </div>
                </div>   
           
      <div id="div_TOP" class="MainDiv collapse show" style="border:2px double lightgray">
          
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

                      <asp:TemplateField HeaderText="TaxBase"  >
                        <ItemTemplate>
                            <asp:Label  ID="TaxBase" runat="server" Text='<%# If(Eval("TaxBase").ToString() = "", "", Format(Eval("TaxBase"), "standard"))%>'  />
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
                            <div style="display:inline-block;text-align:left;float:left;">
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
                            <asp:Label ID="Discount" runat="server" Text='<%# If(Eval("Discount").ToString() = "", "0", Format(Eval("Discount"), "standard"))%>' />
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Right"/>   
                    </asp:TemplateField>  

                    
                </Columns>
       
            </asp:GridView>
             </center>
         <br /><center>
         <table style="right:20px;font-size:20px;"">
             <tr>
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
             
    <br />
        <%-- <a href="#"  style="color:blue" data-toggle="modal" data-dismiss="modal" data-target="#Request" data-ticket-type="standard-access">Request to Change Mode of Payment</a>--%>
           <a href="BusinessRenewalTaxpayer.aspx" style="color:blue;display:none">Request for Update</a>
             
               </center>
       
           <div runat="server" id="div_PaidandPosted">
                <div class="w3-panel  w3-pale-green">
  <h3>Account already Paid</h3>
  <p></p>
</div >

            </div>
            <br />
         <br />
        <asp:Panel runat="server" ID="_oPnPrintStatement" class="col-md-12 row mx-auto d-flex justify-content-center mb-2">
                            <input type="button" value="Print Statement of Account" runat="server" id="btn_TOP" class="btn btn-primary w-25"/> &nbsp
             <input type="button" runat="server" id="btnPayment" value="Proceed to Payment" class="btn btn-primary w-25"/>
       
                        </asp:Panel>

            
          </div>           
   <br /> 
                             </div>
            </div>
    </div>
    </div>


    <script>

        function onlyNumbers(evt) {

            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if (charCode < 48 || charCode > 57)
                return false;

            return true;

        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

    </script>
         
</asp:content>

