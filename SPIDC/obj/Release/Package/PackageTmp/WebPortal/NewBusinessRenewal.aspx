<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="NewBusinessRenewal.aspx.vb" Inherits="SPIDC.NewBusinessRenewal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  

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
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>

    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Business Renewal</h5>
    </div>
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


            <div class="form-row form ">
                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Bus. ID Number: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusID" runat="server" Text="" />
                        </label>

                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Bus. Owner/Manager: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusOwner" runat="server" Text="" />
                        </label>

                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>


                        <label class="text-capitalize font-weight-bold text-primary">
                            Business Name: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusName" runat="server" Text="" />
                        </label>

                    </div>
                </div>


                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Business Address: &nbsp

                            <br>
                            <asp:Label ID="_oLblBusAddress" runat="server" Text="" />
                        </label>

                    </div>
                </div>

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Category: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusCategory" runat="server" Text="" />
                        </label>

                    </div>
                </div>

            </div>

            <%--            <div class="form-row form mt-4">
                <div class="form-group col-md-4 ">
                    <div>

                        <label class="input-txt input-txt-active">
                            <span><span class = "m-2">Business Line</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " required="" autocomplete="off" placeholder="Business Line" runat="server" id="_oTxtBusLine">
                    </div>
                </div>

                <div class="form-group col-md-4">
                    <div>
                        <label class="input-txt input-txt-active input-txt input-txt-active-active">
                            <span><span class = "m-2">Previous Gross</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " autocomplete="off" placeholder="Previous Gross" runat="server" id="_oTxtPreviousGross">
                    </div>

                </div>
                <div class="form-group col-md-3">
                    <div>
                        <label class="input-txt input-txt-active">
                            <span><span class = "m-2">Enter Gross</span></span>
                        </label>
                        <input type="text" 
                            required 
                            class="form-control CH-Size" 
                            onblur="formatMoney(this.value);" 
                            onfocus="removeComma(this.value);" 
                            pattern="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" 
                            title="Gross"
                            maxlength="20" 
                            autocomplete="off" 
                            placeholder="Enter Gross" 
                            runat="server" 
                            id="_oTxtEnterGross">             
               <script>
                   function removeComma(x) {
                       document.getElementById('<%=_oTxtEnterGross.ClientID%>').value = x.replace(/,/g, '');
                   }

                   function formatMoney(val) {

                       var formatter = new Intl.NumberFormat('en-US', {
                           style: 'currency',
                           currency: 'PHP',
                       });

                       var x = formatter.format(val);
                       x = x.split('PHP').join('');
                       x = x.replace(/\s/g, '');

                       document.getElementById('<%=_oTxtEnterGross.ClientID%>').value = x;
                     }
               </script>
                        
                         </div>

                    <!--input required="" type="text" name="txtBirthDate" class="form-control CH-Size" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
                </div>
            </div>--%>
            <center>
            <div class="table-responsive col-lg-12" >

             <asp:GridView ID="_GVBusinessLine" runat="server" CssClass="mGrid col-lg-10" AllowSorting="true"  
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" >
                <Columns>
                    <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="left" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Previous Gross" ItemStyle-HorizontalAlign="right" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelPrevGross" runat="server" Text='<%# Eval("GROSSAMT", "{0:C}").ToString().Replace("$", "")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Enter Gross" ItemStyle-HorizontalAlign="right" ItemStyle-Width="30%">
                        <ItemTemplate>
                           <%-- <asp:TextBox ID="_oLabelEnterGross" runat="server"  />--%>
                            <input type="text"" style="width:100%;text-align:right;border:none;background-color:#6495ed;color: white"  ID="_oLabelEnterGross"  value='<%# Eval("GROSSINPUT", "{0:C}").ToString().Replace("$", "")%>' onblur="GrossEntry(this.value,'<%# Eval("BUSCODE")%>');" onkeypress="return isNumberKey(event)"/>

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
                                    x.replace('₱', '');
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




            <%--  <div class="row">
                <div class="row col-lg-5 my-auto">
                    <div class="col-lg-10 mx-2 my-1">
                        <asp:Panel ID="_oAskHP1" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP1" runat="server" CssClass="col" Text='ENTER AGGREGATE AREA OF ESTABLISHMENT: [AREA]' />
                            <asp:TextBox ID="_oTxtAskHP1" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP2" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP2" runat="server" CssClass="col" Text='ENTER AREA IN HECTARES  : [AREA]' />
                            <asp:TextBox ID="_oTxtAskHP2" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP3" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP3" runat="server" CssClass="col" Text='ENTER AREA IN SQ. METERS  : [AREA]' />
                            <asp:TextBox ID="_oTxtAskHP3" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP4" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP4" runat="server" CssClass="col" Text='ENTER GROSS DECLARATION  : [GC]' />
                            <asp:TextBox ID="_oTxtAskHP4" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP5" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP5" runat="server" CssClass="col" Text='ENTER HOUSE CAPACITY  :' />
                            <asp:TextBox ID="_oTxtAskHP5" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP6" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP6" runat="server" CssClass="col" Text='ENTER NUMBER OF ACCOMMODATION(S)  :' />
                            <asp:TextBox ID="_oTxtAskHP6" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP7" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP7" runat="server" CssClass="col" Text='ENTER NUMBER OF BED CAPACITY  :' />
                            <asp:TextBox ID="_oTxtAskHP7" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP8" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP8" runat="server" CssClass="col" Text='ENTER NUMBER OF BOARDERS/LODGERS  :' />
                            <asp:TextBox ID="_oTxtAskHP8" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP9" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP9" runat="server" CssClass="col" Text='ENTER NUMBER OF ROOMS:' />
                            <asp:TextBox ID="_oTxtAskHP9" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP10" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP10" runat="server" CssClass="col" Text='ENTER NUMBER OF STUDENTS  :' />
                            <asp:TextBox ID="_oTxtAskHP10" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP11" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP11" runat="server" CssClass="col" Text='ENTER NUMBER OF WATCHERS  :' />
                            <asp:TextBox ID="_oTxtAskHP11" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskHP12" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskHP12" runat="server" CssClass="col" Text='ENTER PREVIOUS BUSINESS TAX PAID:' />
                            <asp:TextBox ID="_oTxtAskHP12" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                    </div>



                </div>


  


                <div class="row col-lg-5 my-auto">
                    <div class="col-lg-10 mx-2 my-1">
                        <asp:Panel ID="_oAskQ1" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ1" runat="server" CssClass="col" Text='ENTER # OF APPARATUS FOR VISUAL ENTERTAINMENT  :' />
                            <asp:TextBox ID="_oTxtAskQ1" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ2" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ2" runat="server" CssClass="col" Text='ENTER # OF APPARATUS FOR WEIGHING PERSONS  :' />
                            <asp:TextBox ID="_oTxtAskQ2" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ3" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ3" runat="server" CssClass="col" Text='ENTER # OF COMPUTER MACHINE  :' />
                            <asp:TextBox ID="_oTxtAskQ3" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ4" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ4" runat="server" CssClass="col" Text='ENTER NUMBER OF AUTOMATIC LANE  :' />
                            <asp:TextBox ID="_oTxtAskQ4" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ5" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ5" runat="server" CssClass="col" Text='ENTER NUMBER OF AUTOMATIC LANE(S) :' />
                            <asp:TextBox ID="_oTxtAskQ5" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ6" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ6" runat="server" CssClass="col" Text='ENTER NUMBER OF BED(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ6" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ7" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ7" runat="server" CssClass="col" Text='ENTER NUMBER OF BOOTHS  :' />
                            <asp:TextBox ID="_oTxtAskQ7" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ8" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ8" runat="server" CssClass="col" Text='ENTER NUMBER OF BRANCH  :' />
                            <asp:TextBox ID="_oTxtAskQ8" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ9" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ9" runat="server" CssClass="col" Text='ENTER NUMBER OF BRANCH / AGENCY  :' />
                            <asp:TextBox ID="_oTxtAskQ9" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ10" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ10" runat="server" CssClass="col" Text='ENTER NUMBER OF BRANCH / STATION(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ10" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ11" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ11" runat="server" CssClass="col" Text='ENTER NUMBER OF BRANCH OFFICE(S) :' />
                            <asp:TextBox ID="_oTxtAskQ11" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ12" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ12" runat="server" CssClass="col" Text='ENTER NUMBER OF BRANCHES/STATTIONS  :' />
                            <asp:TextBox ID="_oTxtAskQ12" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ13" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ13" runat="server" CssClass="col" Text='ENTER NUMBER OF CINEMA:' />
                            <asp:TextBox ID="_oTxtAskQ13" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ14" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ14" runat="server" CssClass="col" Text='ENTER NUMBER OF CONTRIVANCE(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ14" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ15" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ15" runat="server" CssClass="col" Text='ENTER NUMBER OF COURT(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ15" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ16" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ16" runat="server" CssClass="col" Text='ENTER NUMBER OF CUBICLE(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ16" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ17" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ17" runat="server" CssClass="col" Text='ENTER NUMBER OF DAY(S) :' />
                            <asp:TextBox ID="_oTxtAskQ17" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ18" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ18" runat="server" CssClass="col" Text='ENTER NUMBER OF DAYS FOR SHOOTING  :' />
                            <asp:TextBox ID="_oTxtAskQ18" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ19" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ19" runat="server" CssClass="col" Text='ENTER NUMBER OF DEVICE(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ19" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ20" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ20" runat="server" CssClass="col" Text='ENTER NUMBER OF DOOR(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ20" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ21" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ21" runat="server" CssClass="col" Text='ENTER NUMBER OF DOORS  :' />
                            <asp:TextBox ID="_oTxtAskQ21" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ22" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ22" runat="server" CssClass="col" Text='ENTER NUMBER OF ESTABLISHMENT(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ22" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ23" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ23" runat="server" CssClass="col" Text='ENTER NUMBER OF JUKEBOX  :' />
                            <asp:TextBox ID="_oTxtAskQ23" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ24" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ24" runat="server" CssClass="col" Text='ENTER NUMBER OF LOCALITY WHERE SECURITY GUARDS ARE POSTED  :' />
                            <asp:TextBox ID="_oTxtAskQ24" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ25" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ25" runat="server" CssClass="col" Text='ENTER NUMBER OF MATCH  :' />
                            <asp:TextBox ID="_oTxtAskQ25" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ26" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ26" runat="server" CssClass="col" Text='ENTER NUMBER OF NON-AUTOMATIC LANE  :' />
                            <asp:TextBox ID="_oTxtAskQ26" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ27" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ27" runat="server" CssClass="col" Text='ENTER NUMBER OF PEDDLER(S) :' />
                            <asp:TextBox ID="_oTxtAskQ27" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ28" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ28" runat="server" CssClass="col" Text='ENTER NUMBER OF POOL/BILLIARD TABLE(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ28" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ29" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ29" runat="server" CssClass="col" Text='ENTER NUMBER OF POWER PLANT(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ29" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ30" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ30" runat="server" CssClass="col" Text='ENTER NUMBER OF ROOMS  :' />
                            <asp:TextBox ID="_oTxtAskQ30" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ31" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ31" runat="server" CssClass="col" Text='ENTER NUMBER OF SALESMAN  :' />
                            <asp:TextBox ID="_oTxtAskQ31" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ32" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ32" runat="server" CssClass="col" Text='ENTER NUMBER OF SHOOTING DAY(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ32" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ33" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ33" runat="server" CssClass="col" Text='ENTER NUMBER OF STALL(S)  :' />
                            <asp:TextBox ID="_oTxtAskQ33" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ34" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ34" runat="server" CssClass="col" Text='ENTER NUMBER OF TABLES  :' />
                            <asp:TextBox ID="_oTxtAskQ34" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ35" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ35" runat="server" CssClass="col" Text='ENTER SIZE OF CAGES :' />
                            <asp:TextBox ID="_oTxtAskQ35" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ36" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ36" runat="server" CssClass="col" Text='IF FAMILY HOME COMPUTER, ENTER NUMBER OF UNIT :' />
                            <asp:TextBox ID="_oTxtAskQ36" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ37" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ37" runat="server" CssClass="col" Text='IF GAME AND WATCH DEVICE, ENTER NUMBER OF DEVICE :' />
                            <asp:TextBox ID="_oTxtAskQ37" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ38" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ38" runat="server" CssClass="col" Text='IF JUKEBOX MACHINE, ENTER NUMBER OF MACHINE :' />
                            <asp:TextBox ID="_oTxtAskQ38" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ39" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ39" runat="server" CssClass="col" Text='IF VIDEOKE MACHINE, ENTER NUMBER OF MACHINE :' />
                            <asp:TextBox ID="_oTxtAskQ39" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ40" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ40" runat="server" CssClass="col" Text='OTHER AMUSEMENT DEVICE, ENTER NUMBER OF DEVICE :' />
                            <asp:TextBox ID="_oTxtAskQ40" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="_oAskQ41" runat="server" class="row" Visible="false">
                            <asp:Label ID="_oLblAskQ41" runat="server" CssClass="col" Text='SLOT MACHINE NOT CLASSIFIED AS GAMBLING DEVICE, ENTER NUMBER OF DEVICE :' />
                            <asp:TextBox ID="_oTxtAskQ41" runat="server" Width="40px" onkeypress="return isNumberKey(event)" Height="30px" ></asp:TextBox>
                        </asp:Panel>


                    </div>



                </div>



                <div class="row col-lg-2 m-2">
                    <asp:Panel ID="_oOpt1" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt1" runat="server" CssClass="col" Visible="False" Text="1014"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt1" CssClass="CH-Size" Name="1014">
                            <asp:ListItem Value="RETAILER" Text="RETAILER" Selected="true" />
                            <asp:ListItem Value="WHOLESALER/DEALER" Text="WHOLESALER/DEALER" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt2" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt2" runat="server" CssClass="col" Visible="False" Text="1021"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt2" CssClass="CH-Size" Name="1021">
                            <asp:ListItem Value="DERBY COCK FIGHT" Text="DERBY COCK FIGHT" Selected="true" />
                            <asp:ListItem Value="REGULAR COCK FIGHT" Text="REGULAR COCK FIGHT" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt3" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt3" runat="server" CssClass="col" Visible="False" Text="1036"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt3" CssClass="CH-Size" Name="1036">
                            <asp:ListItem Value="BABY CONO" Text="BABY CONO" Selected="true" />
                            <asp:ListItem Value="CONO" Text="CONO" />
                            <asp:ListItem Value="KISKISAN" Text="KISKISAN" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt4" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt4" runat="server" CssClass="col" Visible="False" Text="3001"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt4" CssClass="CH-Size" Name="3001">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" Selected="true" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) JEEPLOAD BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) JEEPLOAD BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD " Text="WITH MORE THAN TEN (10) JEEPLOAD " />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt5" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt5" runat="server" CssClass="col" Visible="False" Text="3002"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt5" CssClass="CH-Size" Name="3002">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" Selected="true" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) JEEPLOAD BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) JEEPLOAD BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD " Text="WITH MORE THAN TEN (10) JEEPLOAD " />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt6" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt6" runat="server" CssClass="col" Visible="False" Text="3003"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt6" CssClass="CH-Size" Name="3003">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" Selected="true" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) JEEPLOAD BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) JEEPLOAD BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD " Text="WITH MORE THAN TEN (10) JEEPLOAD " />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt7" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt7" runat="server" CssClass="col" Visible="False" Text="3004"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt7" CssClass="CH-Size" Name="3004">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" Selected="true" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt8" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt8" runat="server" CssClass="col" Visible="False" Text="3005"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt8" CssClass="CH-Size" Name="3005">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" Selected="true" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) JEEPLOAD BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) JEEPLOAD BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD " Text="WITH MORE THAN TEN (10) JEEPLOAD " />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt9" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt9" runat="server" CssClass="col" Visible="False" Text="3024"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt9" CssClass="CH-Size" Name="3024">
                            <asp:ListItem Value="AUTHORIZED DEALER IN FOREIGN CURRENCY" Text="AUTHORIZED DEALER IN FOREIGN CURRENCY" Selected="true" />
                            <asp:ListItem Value="MAIN OFFICE" Text="MAIN OFFICE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt10" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt10" runat="server" CssClass="col" Visible="False" Text="3025"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt10" CssClass="CH-Size" Name="3025">
                            <asp:ListItem Value="CURBS PUMPS AND FILLING STATIONS" Text="CURBS PUMPS AND FILLING STATIONS" Selected="true" />
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                            <asp:ListItem Value="WITH SERVICE BAY" Text="WITH SERVICE BAY" />
                            <asp:ListItem Value="WITHOUT SERVICE BAY" Text="WITHOUT SERVICE BAY" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt11" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt11" runat="server" CssClass="col" Visible="False" Text="3026"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt11" CssClass="CH-Size" Name="3026">
                            <asp:ListItem Value="MEDICAL/LAB CLINICS" Text="MEDICAL/LAB CLINICS" Selected="true" />
                            <asp:ListItem Value="PRIVATE HOSPITAL" Text="PRIVATE HOSPITAL" />
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt12" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt12" runat="server" CssClass="col" Visible="False" Text="3027"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt12" CssClass="CH-Size" Name="3027">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt13" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt13" runat="server" CssClass="col" Visible="False" Text="3028"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt13" CssClass="CH-Size" Name="3028">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt14" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt14" runat="server" CssClass="col" Visible="False" Text="3031"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt14" CssClass="CH-Size" Name="3031">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt15" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt15" runat="server" CssClass="col" Visible="False" Text="3032"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt15" CssClass="CH-Size" Name="3032">
                            <asp:ListItem Value="DEALER" Text="DEALER" />
                            <asp:ListItem Value="MARKETER" Text="MARKETER" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt16" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt16" runat="server" CssClass="col" Visible="False" Text="3033"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt16" CssClass="CH-Size" Name="3033">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt17" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt17" runat="server" CssClass="col" Visible="False" Text="3034"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt17" CssClass="CH-Size" Name="3034">
                            <asp:ListItem Value="BOOKS/OTHER MAGAZINE PUBLICATIONS" Text="BOOKS/OTHER MAGAZINE PUBLICATIONS" />
                            <asp:ListItem Value="DAILY NEWSPAPER" Text="DAILY NEWSPAPER" />
                            <asp:ListItem Value="WEEKLY MAGAZINE" Text="WEEKLY MAGAZINE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt18" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt18" runat="server" CssClass="col" Visible="False" Text="3037"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt18" CssClass="CH-Size" Name="3037">
                            <asp:ListItem Value="MAIN OFFICE" Text="MAIN OFFICE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt19" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt19" runat="server" CssClass="col" Visible="False" Text="3038"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt19" CssClass="CH-Size" Name="3038">
                            <asp:ListItem Value="MAIN OFFICE" Text="MAIN OFFICE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt20" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt20" runat="server" CssClass="col" Visible="False" Text="3047"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt20" CssClass="CH-Size" Name="3047">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt21" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt21" runat="server" CssClass="col" Visible="False" Text="3051"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt21" CssClass="CH-Size" Name="3051">
                            <asp:ListItem Value="GF1" Text="GF1" />
                            <asp:ListItem Value="GF2" Text="GF2" />
                            <asp:ListItem Value="GF3" Text="GF3" />
                            <asp:ListItem Value="GF4" Text="GF4" />
                            <asp:ListItem Value="GF5" Text="GF5" />
                            <asp:ListItem Value="GF5" Text="GF5" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt22" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt22" runat="server" CssClass="col" Visible="False" Text="3052"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt22" CssClass="CH-Size" Name="3052">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt23" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt23" runat="server" CssClass="col" Visible="False" Text="3053"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt23" CssClass="CH-Size" Name="3053">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt24" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt24" runat="server" CssClass="col" Visible="False" Text="3054"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt24" CssClass="CH-Size" Name="3054">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt25" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt25" runat="server" CssClass="col" Visible="False" Text="3055"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt25" CssClass="CH-Size" Name="3055">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt26" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt26" runat="server" CssClass="col" Visible="False" Text="3056"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt26" CssClass="CH-Size" Name="3056">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt27" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt27" runat="server" CssClass="col" Visible="False" Text="3057"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt27" CssClass="CH-Size" Name="3057">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt28" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt28" runat="server" CssClass="col" Visible="False" Text="3058"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt28" CssClass="CH-Size" Name="3058">
                            <asp:ListItem Value="COCKTAIL LOUNGES OR BARS / BEER GARDENS / DISCOS" Text="COCKTAIL LOUNGES OR BARS / BEER GARDENS / DISCOS" />
                            <asp:ListItem Value="DAY CLUBS" Text="DAY CLUBS" />
                            <asp:ListItem Value="NIGHT CLUBS" Text="NIGHT CLUBS" />
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt29" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt29" runat="server" CssClass="col" Visible="False" Text="3059"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt29" CssClass="CH-Size" Name="3059">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt30" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt30" runat="server" CssClass="col" Visible="False" Text="3060"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt30" CssClass="CH-Size" Name="3060">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt31" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt31" runat="server" CssClass="col" Visible="False" Text="3061"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt31" CssClass="CH-Size" Name="3061">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt32" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt32" runat="server" CssClass="col" Visible="False" Text="3062"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt32" CssClass="CH-Size" Name="3062">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt33" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt33" runat="server" CssClass="col" Visible="False" Text="3063"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt33" CssClass="CH-Size" Name="3063">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt34" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt34" runat="server" CssClass="col" Visible="False" Text="3064"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt34" CssClass="CH-Size" Name="3064">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt35" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt35" runat="server" CssClass="col" Visible="False" Text="3065"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt35" CssClass="CH-Size" Name="3065">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt36" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt36" runat="server" CssClass="col" Visible="False" Text="3066"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt36" CssClass="CH-Size" Name="3066">
                            <asp:ListItem Value="RURAL BANKS" Text="RURAL BANKS" />
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt37" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt37" runat="server" CssClass="col" Visible="False" Text="3067"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt37" CssClass="CH-Size" Name="3067">
                            <asp:ListItem Value="MAIN OFFICE" Text="MAIN OFFICE" />
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt38" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt38" runat="server" CssClass="col" Visible="False" Text="3068"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt38" CssClass="CH-Size" Name="3068">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt39" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt39" runat="server" CssClass="col" Visible="False" Text="3069"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt39" CssClass="CH-Size" Name="3069">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt40" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt40" runat="server" CssClass="col" Visible="False" Text="3070"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt40" CssClass="CH-Size" Name="3070">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt41" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt41" runat="server" CssClass="col" Visible="False" Text="3071"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt41" CssClass="CH-Size" Name="3071">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt42" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt42" runat="server" CssClass="col" Visible="False" Text="3072"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt42" CssClass="CH-Size" Name="3072">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt43" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt43" runat="server" CssClass="col" Visible="False" Text="3073"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt43" CssClass="CH-Size" Name="3073">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt44" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt44" runat="server" CssClass="col" Visible="False" Text="3074"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt44" CssClass="CH-Size" Name="3074">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt45" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt45" runat="server" CssClass="col" Visible="False" Text="3075"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt45" CssClass="CH-Size" Name="3075">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt46" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt46" runat="server" CssClass="col" Visible="False" Text="3079"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt46" CssClass="CH-Size" Name="3079">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt47" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt47" runat="server" CssClass="col" Visible="False" Text="3080"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt47" CssClass="CH-Size" Name="3080">
                            <asp:ListItem Value="WITH SERVICE BAY" Text="WITH SERVICE BAY" />
                            <asp:ListItem Value="WITHOUT SERVICE BAY" Text="WITHOUT SERVICE BAY" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt48" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt48" runat="server" CssClass="col" Visible="False" Text="3081"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt48" CssClass="CH-Size" Name="3081">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt49" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt49" runat="server" CssClass="col" Visible="False" Text="3082"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt49" CssClass="CH-Size" Name="3082">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE* " Text="WITH ONE JEEPLOAD OR MORE* " />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE**" Text="WITH ONE JEEPLOAD OR MORE**" />
                            <asp:ListItem Value="WITH ONE JEEPLOAD OR MORE***" Text="WITH ONE JEEPLOAD OR MORE***" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt50" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt50" runat="server" CssClass="col" Visible="False" Text="3083"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt50" CssClass="CH-Size" Name="3083">
                            <asp:ListItem Value="WITH LESS THAN ONE (1) JEEPLOAD" Text="WITH LESS THAN ONE (1) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN ONE (1) BUT LESS THAN TEN (10) JEEPLOAD" />
                            <asp:ListItem Value="WITH MORE THAN TEN (10) JEEPLOAD" Text="WITH MORE THAN TEN (10) JEEPLOAD" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt51" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt51" runat="server" CssClass="col" Visible="False" Text="4005"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt51" CssClass="CH-Size" Name="4005">
                            <asp:ListItem Value="RETAILER" Text="RETAILER" />
                            <asp:ListItem Value="WHOLESALE/DEALER/PEDDLER" Text="WHOLESALE/DEALER/PEDDLER" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt52" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt52" runat="server" CssClass="col" Visible="False" Text="4013"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt52" CssClass="CH-Size" Name="4013">
                            <asp:ListItem Value="LESS THAN TEN (10) HOLES" Text="LESS THAN TEN (10) HOLES" />
                            <asp:ListItem Value="TEN (10) OR MORE HOLES" Text="TEN (10) OR MORE HOLES" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt53" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt53" runat="server" CssClass="col" Visible="False" Text="4027"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt53" CssClass="CH-Size" Name="4027">
                            <asp:ListItem Value="BRANCH" Text="BRANCH" />
                            <asp:ListItem Value="MAIN OFFICE" Text="MAIN OFFICE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt54" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt54" runat="server" CssClass="col" Visible="False" Text="4029"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt54" CssClass="CH-Size" Name="4029">
                            <asp:ListItem Value="MAIN OFFICE" Text="MAIN OFFICE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt55" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt55" runat="server" CssClass="col" Visible="False" Text="4039"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt55" CssClass="CH-Size" Name="4039">
                            <asp:ListItem Value="PRINCIPAL OFFICE" Text="PRINCIPAL OFFICE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt56" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt56" runat="server" CssClass="col" Visible="False" Text="4062"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt56" CssClass="CH-Size" Name="4062">
                            <asp:ListItem Value="MF1" Text="MF1" />
                            <asp:ListItem Value="MF2" Text="MF2" />
                            <asp:ListItem Value="MF3" Text="MF3" />
                            <asp:ListItem Value="MF4" Text="MF4" />
                            <asp:ListItem Value="MF5" Text="MF5" />
                            <asp:ListItem Value="MF6" Text="MF6" />
                            <asp:ListItem Value="MF7" Text="MF7" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt57" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt57" runat="server" CssClass="col" Visible="False" Text="5002"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt57" CssClass="CH-Size" Name="5002">
                            <asp:ListItem Value="MAIN OFFICE" Text="MAIN OFFICE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt58" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt58" runat="server" CssClass="col" Visible="False" Text="5013"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt58" CssClass="CH-Size" Name="5013">
                            <asp:ListItem Value="BRANCH(ES)" Text="BRANCH(ES)" />
                            <asp:ListItem Value="MAIN OFFICE" Text="MAIN OFFICE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt59" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt59" runat="server" CssClass="col" Visible="False" Text="6811"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt59" CssClass="CH-Size" Name="6811">
                            <asp:ListItem Value="DOUBLE BED" Text="DOUBLE BED" />
                            <asp:ListItem Value="SINGLE BED" Text="SINGLE BED" />
                            <asp:ListItem Value="SUITE" Text="SUITE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt60" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt60" runat="server" CssClass="col" Visible="False" Text="6812"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt60" CssClass="CH-Size" Name="6812">
                            <asp:ListItem Value="DOUBLE BED" Text="DOUBLE BED" />
                            <asp:ListItem Value="SINGLE BED" Text="SINGLE BED" />
                            <asp:ListItem Value="SUITE" Text="SUITE" />
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="_oOpt61" runat="server" class="row" Visible="false">
                        <asp:Label ID="_oLblOpt61" runat="server" CssClass="col" Visible="False" Text="6813"/>
                        <asp:DropDownList runat="server" ID="_oSelectOpt61" CssClass="CH-Size" Name="6813">
                            <asp:ListItem Value="DOUBLE BED" Text="DOUBLE BED" />
                            <asp:ListItem Value="SINGLE BED" Text="SINGLE BED" />
                            <asp:ListItem Value="SUITE" Text="SUITE" />
                        </asp:DropDownList>
                    </asp:Panel>
                </div> 
            </div>                                        --%>




            <%--askhdg,qty,option  --%>

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
                                <br />
                                <div class="card col-sm-12 px-0">
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
            <%--<div class="row">
                                <div class="row col-lg-5">
                                    <div class="col-lg-11 mx-2 my-1">
                                        <asp:Panel runat="server" ID="_opnlAllAskHeading"  >

                                        </asp:Panel>
                                    </div>
                                </div>

                                <div class="row col-lg-5">

                                    <div class="col-lg-11 mx-2 my-1">
                        
                                        <asp:Panel runat="server" ID="_opnlTextAskQ" >
                                        </asp:Panel>
                                    </div>
                                </div>

                                <div class="row col-lg-2 m-2">
                                    <asp:panel runat="server" ID="_opnlDrpDownAskOpt" >

                                    </asp:panel>
                                </div> 
                            </div>--%>
            <div class="row">
                <asp:ListBox ID="_oListBox1" runat="server" Visible="false"></asp:ListBox>
            </div>

            <div class=" d-flex justify-content-center">

                <div class="col-md-12 row d-flex justify-content-center">

                    <button name="_obtnSaveEdit" runat="server" id="_obtnSaveEdit" type="submit" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" autopostback="True">Submit</button>
                    <%--<button name="_obtnPrintApplication" runat="server" id="_obtnPrintApplication" type="submit" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm">Print Application Form</button>--%>
                </div>

            </div>



            <textarea id="txarea" name="txarea" style="visibility: hidden; display: none;"></textarea><br>

            <script>
                function GrossEntry(gross, uniqueID) {
                    document.getElementById("txarea").value = document.getElementById("txarea").value + uniqueID + ":" + gross + ";";
                    //document.getElementById("txarea").value = id;
                    //alert(gross + " - " + uniqueID);


                }
            </script>

            <%--<div class="d-flex justify-content-center col-lg-12">
                                <div class="form-row form row my-auto col-lg-11">

                    <div class="form-group col-md-12 my-auto row">
                        <div class="col-md-2 ml-auto row">                            
                            <select runat="server" id="_radYear" name="radYear" class="form-control CH-Size col-12">
                                <option value="2020" disabled selected>2020</option>
                                <option value="2021">2021</option>
                                <option value="2022">2022</option>
                            </select>
                            
                        </div>

                        <label class="float-left col-md-1">Year</label> 
                        <asp:Panel ID="_oPnRadQtr" runat="server" CssClass="row col-md-9 mb-2">

                            <asp:RadioButton ID="_oRadio1stQ" GroupName="QTR" runat="server" AutoPostBack="True" Text="&nbsp 1st Quarter" CssClass="my-auto col-md-3 " />
                            <asp:RadioButton ID="_oRadio2ndQ" GroupName="QTR" runat="server" AutoPostBack="True" Text="&nbsp 2nd Quarter" CssClass="my-auto col-md-3 " />
                            <asp:RadioButton ID="_oRadio3rdQ" GroupName="QTR" runat="server" AutoPostBack="True" Text="&nbsp 3rd Quarter" CssClass="my-auto col-md-3 " />
                            <asp:RadioButton ID="_oRadio4thQ" GroupName="QTR" runat="server" AutoPostBack="True" Text="&nbsp 4th Quarter" CssClass="my-auto col-md-3 " />

                        </asp:Panel>

                    </div>


                    <%--<%--  <div class="form-group col-md-2 row my-auto">
                    <input type="radio" onclick="Quarter(this.value);" name="1st" class="form-control CH-Size my-auto " style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="1">
                    <div class="m-0 font-weight-bold text-primary col my-auto">1st Quarter</div>
                </div>

                   <div class="form-group col-md-2 row my-auto">
                    <input type="radio" onclick="Quarter(this.value);" name="2nd" class="form-control CH-Size my-auto " style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="2">
                    <div class="m-0 font-weight-bold text-primary col my-auto">2nd Quarter</div>
                </div>

                   <div class="form-group col-md-2 row my-auto">
                    <input type="radio" onclick="Quarter(this.value);" name="3rd" class="form-control CH-Size my-auto " style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="3">
                    <div class="m-0 font-weight-bold text-primary col my-auto">3rd Quarter</div>
                </div>

                   <div class="form-group col-md-2 row my-auto">
                    <input type="radio" onclick="Quarter(this.value);" name="4th" class="form-control CH-Size my-auto " style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="4">
                    <div class="m-0 font-weight-bold text-primary col my-auto">4th Quarter</div>
                </div>
 

                <%--           
                <div class="form-group col-md-2 row my-auto">
                    <input type="radio" id="_oRadio4thQ" runat="server" onclick="InitCedulaType();" name="Quarter" class="form-control CH-Size my-auto" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="4th Quarter">
                    <div class="m-0 font-weight-bold text-primary col my-auto">4th Quarter</div>
                </div>  
            --%>







            <%-- <script>
                        function Quarter(name) {
                            __doPostBack('QuarterClick', name);
                        }
                        function Deliver(val) {
                            __doPostBack('Receive', val);
                        }
                    </script>

                </div>

            </div> 
            --%>
            <%--<div class=" table-responsive">


                <asp:GridView ID="_oGVBusinessRenewal" runat="server" CssClass="mx-auto NotResG" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" HeaderStyle-HorizontalAlign="Center">
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

                        <asp:TemplateField HeaderText="Gross Dec" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelGrossDec" runat="server" Text='<%# Eval("GROSSAMT", "{0:C}").ToString().Replace("$", "")%>' />

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Amount Due" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelAmountDue" runat="server" Text='<%# Eval("AMOUNTDUE", "{0:C}").ToString().Replace("$", "")%>' />

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
            <div class="border border-dark"><div class="row m-3 "><div class="my-auto mx-2">Should we deliver your Documents (P250.00)?  <asp:CheckBox runat="server" id="_oRadioPickup" AutoPostBack="True"  name="CourierServices" cssclass="CH-Size my-auto mx-2" Text="&nbsp Yes"/></div>

            <div class="align-items-center row m-1">

                
                          

                <%--<div class="align-items-center row m-1">
                    <input type="checkbox" id="_oRadioDelivered" onclick="Deliver(this.value);" name="CourierServices" class="form-control CH-Size my-auto mx-2" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="Delivered">
                    <div class="m-0 font-weight-bold text-primary my-auto">Delivered</div>
                    <asp:Label ID="_oLabelCourierServices" runat="server" text="250.00" class="mx-2"/>
                </div>--%>
        <%--</div>
    </div>
    </div>    
            <div class="row col-md-12 mx-auto my-2 d-flex justify-content-end ">
                <label class="mx-2 my-auto text-capitalize font-weight-bold col-md-2" style="font-size: 17px; text-align: right">Total Amount Due:</label>
                <asp:Label ID="_oLabelTotalAmountDue" runat="server" Text="0.00" class="mx-2 my-auto border border-bottom-light rounded-lg col-md-5" Font-Size="25" Width="100%" Style="text-align: right;" />
            </div>
    --%>
       
            


    <%--<div class="">

        <div class="col-md-12 row mx-auto d-flex justify-content-center mb-2">
            <button name="_obtnPrintStatement" runat="server" id="_obtnPrintStatement" type="submit" class="btn btn-primary col-md-3 col-lg-3 m-1 btn-sm">Print Statement of Account</button>
            <button name="_obtnPayment" runat="server" id="Button2" type="submit" class="btn btn-primary col-md-2 col-lg-2 m-1 btn-sm">Proceed to Payment</button>
        </div>




    </div>--%>

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

</asp:Content>
