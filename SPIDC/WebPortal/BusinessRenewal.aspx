<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BusinessRenewal.aspx.vb" Inherits="SPIDC.BusinessRenewal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
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
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
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
        
    <script>


        //document.getElementsByClassName('thgross')[0].style.visibility = 'hidden';
        //var sample  = document.getElementsByClassName('tdgross');
        //for (var a = 0 ; a < sample.length ; a++) { sample[a].style.visibility = 'hidden'; alert(a); }


        function ViewSPA(Name, Type, Data, seqid, sample) {
            var Checkival = document.getElementById(sample).value;
            if (Checkival != "No Attached File") {
                document.getElementById('<%=hdnName.ClientID%>').value = Name;
                                document.getElementById('<%=hdnType.ClientID%>').value = Type;
                                document.getElementById('<%=hdnData.ClientID%>').value = Data;
                                __doPostBack('DownloadFiles_profile', seqid);
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


                        function Quarter(name) {
                            __doPostBack('QuarterClick', name);
                        }
                        function Deliver(val) {
                            __doPostBack('Receive', val);
                        }
                    </script>
    <input type="hidden" id="_err" runat="server" />

    <div  class="card mt-2">
        <div class="col-lg-12 p-2"><h5 class="m-2 font-weight-bold text-primary">Renewal of Business</h5></div>
        <div   class="col-lg-12">


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

                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Business Ownership: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusOwnership" runat="server" Text="" />
                        </label>

                    </div>
                </div>

                 


                <div class="form-group mx-4 my-2">            
                    <button type="button" data-toggle="modal" data-target="#myModal" class="text-white btn-primary d-flex align-items-center justify-content-center align-content-end">View Online Profile</button>        
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
            <div class="table-responsive-sm col-lg-12" >

             <asp:GridView ID="_GVBusinessLine" runat="server" CssClass="mGrid col-lg-10 get-gross" AllowSorting="true"  
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
                    <asp:TemplateField HeaderText="Tax Payer Gross" ItemStyle-HorizontalAlign="right" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelTPGross" runat="server" Text='<%# Eval("GROSSAMT", "{0:C}").ToString().Replace("$", "")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Assessed Gross" ItemStyle-HorizontalAlign="right" ItemStyle-Width="15%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBPLOGross" runat="server" Text='<%# Eval("ASSESSEDGROSS", "{0:C}").ToString().Replace("$", "")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    


                    <asp:TemplateField HeaderText="Enter Gross" ItemStyle-HorizontalAlign="right" ItemStyle-Width="20%" Visible="false" ><%--ItemStyle-CssClass="tdgross" HeaderStyle-CssClass="thgross">--%>
                        <ItemTemplate>
                           <%-- <asp:TextBox ID="_oLabelEnterGross" runat="server"  />--%>
                            <input type="text"" class="gross-color get-child-gross" style="width:100%;text-align:right;border:none;background-color:#6495ed;color: white"  ID="_oLabelEnterGross"  value='<%# Eval("GROSSINPUT", "{0:C}").ToString().Replace("$", "")%>' onblur="GrossEntry(this.value,'<%# Eval("BUSCODE")%>');FormatGross();" onkeypress="return isNumberKey(event)" />

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


                                function FormatGross() {
                                    var table = document.getElementsByClassName('get-gross');
                                    for (var i = 0; i < table.length; i++) {
                                        var newtable = document.getElementById(table[i].id);
                                        var txtgross = newtable.getElementsByTagName('input');
                                        for (var a = 0; a < txtgross.length; a++) {
                                            if (txtgross[a].classList.contains("get-child-gross")) {
                                                var val = txtgross[a].value.replace(/,/g, '');
                                                var formatter = new Intl.NumberFormat('en-US', {
                                                    style: 'currency',
                                                    currency: 'PHP',
                                                });
                                                var x = formatter.format(val);
                                                x = x.split('PHP').join('');
                                                x = x.replace(/\s/g, '');
                                                x = x.replace('₱', '');
                                                txtgross[a].value = x;
                                            }
                                        }
                                    }

                                }

                                //webshims.setOptions('forms-ext', {
                                //    replaceUI: 'auto',
                                //    types: 'number'
                                //});
                                //webshims.polyfill('forms forms-ext');




                                    </script>

                            <script>
                                //document.getElementById('_oLabelEnterGross').style.visibility = 'false';
                                //document.getElementById('txarea').value = sessionStorage.getItem('txarea');
                                window.onload = function () {
                                    var input = document.getElementById("_oLabelEnterGross").focus();
                                    document.getElementById('txarea').value = sessionStorage.getItem('txarea');
                                    //alert(sessionStorage.getItem('txarea'));
                                }
                            </script>


                        </ItemTemplate>
                    </asp:TemplateField>                    
                </Columns>


            </asp:GridView>
                </div> 
                <style>

                    .input-txt-active3 {
                    
                            text-align: left !Important;
                            font-size:15px !Important;
                            align-content:center !Important;                               
                    
                    }


                </style>
                <div class="col-lg-12 row">
                    <div class="p-1 col-12 mb-2">
                        <p class="m-2 font-weight-bold" style="text-align:left !Important">Uploaded Files: Supported file Extensions (.png,.jpg,.pdf)</p>
                    </div>
                    <div class="p-1 col-12 mb-2">
                        <p class="m-2 font-weight-bold" style="text-align:left !Important" id="_oLblTypeTitle" runat="server"></p>
                    </div>
                    <asp:Panel runat="server" ID="_oPnFile1"  CssClass="form-group col-md-4 " Visible="false">

                        <div>                            
                            <p class="input-txt-active3">
                            Certified True Copy of Quaterly VAT and Monthly VAT for calendar year
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile1" disabled />

                        </div>                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView1"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile1.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile1.ClientID%>','001');">View</a>                             
                    </asp:Panel > 
                    <asp:Panel runat="server" ID="_oPnFile2"  CssClass="form-group col-md-4 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">If non-VAT present monthly percentage tax for the previous year
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile2" disabled />

                        </div>      
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView2"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile2.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile2.ClientID%>','002');">View</a>                       
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile3" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">Barangay Clearance / Barangay Tax Order of Payment
                            <label class="input-txt input-txt-active2">
                                <%--<span><span class="m-2"></span></span>--%>
                            </label>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile3" disabled />

                        </div>                               
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView3"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile3.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile3.ClientID%>','003');">View</a>                      
                    </asp:Panel> 
                    <asp:Panel runat="server" ID="_oPnFile4" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">
                                If with branches outside LGU Premise,submit Breakdown of sales per city/municipality and attach business/permit application for those cities.
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile4" disabled />

                        </div>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView4"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile4.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile4.ClientID%>','004');">View</a>                             
                    </asp:Panel> 

                    <asp:Panel runat="server" ID="_oPnFile5" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">Notarized Written Authorization Letter
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile5" disabled />

                        </div>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView5"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile5.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile5.ClientID%>','005');">View</a>                             
                    </asp:Panel>

                    <asp:Panel runat="server" ID="_oPnFile6" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">ID of Registered Owner and Company ID of representative
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile6" disabled />

                        </div>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView6"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile6.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile6.ClientID%>','006');">View</a>                             
                    </asp:Panel>

                    <asp:Panel runat="server" ID="_oPnFile7" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">Secretary Certificate
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile7" disabled />

                        </div>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView7"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile7.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile7.ClientID%>','007');">View</a>                             
                    </asp:Panel>


                    <asp:Panel runat="server" ID="_oPnFile8" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">Notarized Written Authorization from one of the partners
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile8" disabled />

                        </div>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView8"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile8.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile8.ClientID%>','008');">View</a>                             
                    </asp:Panel>

                    <asp:Panel runat="server" ID="_oPnFile9" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">Duly accomplished business application form, indicating gross sales/receipt
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile9" disabled />

                        </div>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView9"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile9.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile9.ClientID%>','009');">View</a>                             
                    </asp:Panel>


                    <asp:Panel runat="server" ID="_oPnFile10" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">Public Liability Insurance
                            </p>    
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile10" disabled />

                        </div>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView10"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile10.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile10.ClientID%>','010');">View</a>                             
                    </asp:Panel>

                    <asp:Panel runat="server" ID="_oPnFile11" CssClass="form-group col-md-4 " Visible="false">
                        <div>
                            <p class="input-txt-active3">Barangay Clearance
                            </p>
                            <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtFile11" disabled />

                        </div>
                        
                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnView11"  CssClass="form-group col-sm-1" style="text-align:left !Important" Visible="false">
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtFile11.ClientID%>');NPViewFiles('FileName','FileType','FileData','<%=_oTxtFile11.ClientID%>','011');">View</a>                             
                    </asp:Panel>

                </div>

                <input type="hidden" runat="server" id="hdntdn" />
                    <input type="hidden" runat="server" id="hdnacctno" />
                    <%--<input type="hidden" runat="server" id="hdnpropid" />--%>
                    <input type="hidden" runat="server" id="hdnName" />
                    <input type="hidden" runat="server" id="hdnType" />
                    <input type="hidden" runat="server" id="hdnData" />                                      

                    <script>
                        function NPViewDetails(acctno) {
                            document.getElementById('<%=hdnacctno.ClientID%>').value = acctno;
                            __doPostBack('ViewDetails', '');
                        }
                        function NPViewFiles(Name, Type, Data, fileid, seqid) {
                            var Checkival = document.getElementById(fileid).value;
                            if (Checkival != "No Attached File" && Checkival != "") {
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
                            if (Checkival != "No Attached File" && Checkival != "") {
                                window.document.forms[0].target = '_blank';
                                setTimeout(function () { window.document.forms[0].target = ''; }, 0);
                            }

                        }
                    </script>

                </center> 


                
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
                                <div class="card col-sm-12 px-0" style="display:none;">
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
                                <asp:ListBox ID="_oListBox1" runat="server" Visible="false">
                                  
                                </asp:ListBox>
                            </div> 


                         <br />
 <div class="btn-primary" style="text-align:left;background-color:lightgray">  
<a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" 
    href="#div_Regulatory" role="button" aria-haspopup="true" aria-expanded="false" 
    >  Billing Information        </a>
</div>  
             <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Taxpayer Selected Mode of Payment: &nbsp
                            <br>
                            <asp:Label ID="_oLblMOP" runat="server" Text="" />
                        </label>

                    </div>
                </div>
            <div runat="server" id="div_AssessNoticeTreasury">
                <center>
                <div class="w3-panel  w3-pale-blue"> 
  <p>This application will be sent to Treasury office for Billing Assessment upon Approval.<br>
      Or you may DECLINE this application if the details are incorrect.<br>

  </p>
                    <input type="button" value="Approve" runat="server" id="btnApproveApplication" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm"/>                    
                    <button name="_obtnDecline" runat="server" id="Button5" type="button"  class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" data-toggle="modal" data-target="#modadeclineapplciation">Decline</button>

</div> 
                </center>
                </div>

              <div runat="server" id="div_AssessNoticeBPLO">
                <center>
                <div class="w3-panel  w3-pale-yellow"> 
  <h3>Attention! Not yet Assessed</h3>
  <p>No Billing found. Please proceed to Billing TOP on BPLTAS and  refresh this page. </p>
                     
</div> 
                </center>
                </div>

<div runat="server" id="div_Request">
                <div class="w3-panel  w3-pale-yellow">
  <h3>Attention! Requesting for Updated Billing TOP</h3>
  <p>The Owner of this account is Requesting for Updated Billing TOP. Please proceed to Billing TOP on BPLTAS </p>
</div> 
    </div>
    <div runat="server" id="div_RequestPaymentMode">
                <div class="w3-panel  w3-pale-yellow">
  <h3>Attention! Requesting for Updated Billing TOP</h3>
  <p>The Owner of this Account is Requesting to change Mode of Payment. Please proceed to Billing TOP on BPLTAS </p>
 <br /> <p runat="server" id="RequestContent"> • Change from [Annual] to [Quarterly] Payment</p>
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

                       <asp:TemplateField HeaderText="TaxBase"  >
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
             </center>

            <div class=" d-flex justify-content-center">
                
                        <div class="col-md-12 row d-flex justify-content-center">
               <input type="button" runat="server" id="btn_TOP" value="Preview TOP" class="btn btn-primary w-25"/>
           &nbsp <input type="button" runat="server" id="btnApprove" value="Notify Taxpayer for Payment" class="btn btn-primary w-25" />
          </div>
                 
                    </div>
        
        <asp:Panel runat="server" ID="_oPnPrintStatement" class="col-md-12 row mx-auto d-flex justify-content-center mb-2">
                            <button name="_obtnPrintStatement" style="display:none" runat="server" id="_obtnPrintStatement" type="submit" class="btn btn-primary col-md-3 col-lg-3 m-1 btn-sm"></button>
                            <button runat="server" style="display:none" id="Button2" class="btn btn-primary col-md-2 col-lg-2 m-1 btn-sm">Post Assessment</button>
                        <input type="button" id="btnPostAssessment" runat="server" value="Post Assessment" style="display:none;" onclick="openModal();" class="btn btn-primary col-md-2 col-lg-2 m-1 btn-sm"/>
                   
                        </asp:Panel>

              <div class=" d-flex justify-content-center">
                
                        <div class="col-md-12 row d-flex justify-content-center">

                            <button name="_obtnSaveEdit" runat="server" id="_obtnSaveEdit" type="submit" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" AutoPostBack="True"  style="display:none;" disabled onclick="Getgross();">Compute</button>
                            <button style="display:none" name="_obtnPrintApplication" runat="server" id="_obtnPrintApplication" type="submit" class="btn btn-primary col-md-3 col-lg-3 m-2 btn-sm" onclick="sessionStorage.setItem('txarea',document.getElementById('txarea').value);">Print Application Form</button>
                            <button name="_obtnDecline" runat="server" id="_obtnDecline" type="button" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" data-toggle="modal" data-target="#modadeclineapplciation">Decline</button>
                        </div>
                 
                    </div>
          </div>           
   <br /> 
                             </div>


            <br /> <br /> <br /> <br />

           
           <div style="display:none">
            
            <textarea id="hdtarea" runat="server"  style="visibility: hidden; display: none;"  ></textarea>
<textarea id="txarea" name ="txarea" style="visibility: hidden; display: none;"  ></textarea><br>
            
            <script>
                function GrossEntry(gross, uniqueID) {
                    document.getElementById("txarea").value = document.getElementById("txarea").value + uniqueID + ":" + gross + ";";
                    document.getElementById('<%=hdtarea.ClientID%>').value = document.getElementById("txarea").value + uniqueID + ":" + gross + ";";
                    //document.getElementById("txarea").value = id;
                    //alert(gross + " - " + uniqueID);                    
                }
            </script>
 
            <asp:Panel runat="server" ID="_oPnYandQ" class="d-flex justify-content-center col-lg-12" style="display:none">
                                <div class="form-row form row my-auto col-lg-11">

                    <asp:Panel ID="_oPnRadQtr" runat="server" CssClass="form-group col-md-12 my-auto row">
                        <div class="col-md-2 ml-auto row">                            
                            <select runat="server" id="_radYear" name="radYear" class="form-control CH-Size col-12" visible="false">
                                <option value="2020" disabled selected>2020</option>
                                <option value="2021">2021</option>
                                <option value="2022">2022</option>
                            </select>
                            
                        </div>

                        <label class="float-left col-md-1" runat="server" id="_oLblYear" style="display:none">Year</label> 
                        <asp:Panel ID="_oPnRadQtr2" runat="server" CssClass="row col-md-9 mb-2" style="display:none" >

                            <asp:RadioButton ID="_oRadio1stQ" GroupName="QTR" runat="server" AutoPostBack="True" Text="&nbsp 1st Quarter" CssClass="my-auto col-md-3 " />
                            <asp:RadioButton ID="_oRadio2ndQ" GroupName="QTR" runat="server" AutoPostBack="True" Text="&nbsp 2nd Quarter" CssClass="my-auto col-md-3 " />
                            <asp:RadioButton ID="_oRadio3rdQ" GroupName="QTR" runat="server" AutoPostBack="True" Text="&nbsp 3rd Quarter" CssClass="my-auto col-md-3 " />
                            <asp:RadioButton ID="_oRadio4thQ" GroupName="QTR" runat="server" AutoPostBack="True" Text="&nbsp 4th Quarter" CssClass="my-auto col-md-3 " />

                        </asp:Panel>

                    </asp:Panel>


                    <script>


                        //document.getElementsByClassName('thgross')[0].style.visibility = 'hidden';
                        //var sample  = document.getElementsByClassName('tdgross');
                        //for (var a = 0 ; a < sample.length ; a++) { sample[a].style.visibility = 'hidden'; alert(a); }


                        function ViewSPA(Name, Type, Data, seqid, sample) {
                            var Checkival = document.getElementById(sample).value;
                            if (Checkival != "No Attached File") {
                                document.getElementById('<%=hdnName.ClientID%>').value = Name;
                                document.getElementById('<%=hdnType.ClientID%>').value = Type;
                                document.getElementById('<%=hdnData.ClientID%>').value = Data;
                                __doPostBack('DownloadFiles_profile', seqid);
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


                        function Quarter(name) {
                            __doPostBack('QuarterClick', name);
                        }
                        function Deliver(val) {
                            __doPostBack('Receive', val);
                        }
                    </script>

                </div>

            </asp:Panel> 
           
            <div class=" table-responsive" style="display:none">


                <asp:GridView ID="_oGVBusinessRenewal" runat="server" CssClass="mx-auto mgrid" AllowSorting="true"
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
            <div class="border border-dark" style="display:none;">
                <div class="row m-3 ">
                    <div class="my-auto mx-2" style="display:none;">
                        Should we deliver your Documents (P250.00)?  
                        <asp:CheckBox runat="server" id="_oRadioPickup" AutoPostBack="True"  name="CourierServices" cssclass="CH-Size my-auto mx-2" Text="&nbsp Yes"/>
                    </div>

            <div class="align-items-center row m-1">

                
                          

                <%--<div class="align-items-center row m-1">
                    <input type="checkbox" id="_oRadioDelivered" onclick="Deliver(this.value);" name="CourierServices" class="form-control CH-Size my-auto mx-2" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="Delivered">
                    <div class="m-0 font-weight-bold text-primary my-auto">Delivered</div>
                    <asp:Label ID="_oLabelCourierServices" runat="server" text="250.00" class="mx-2"/>
                </div>--%>
                                
            
            </div> </div>
        </div>    
          
            <asp:Panel CssClass="row col-md-12 mx-auto my-2 d-flex justify-content-end " runat="server" id="_oPnTotal" Visible="false" style="display:none">
                <label class="mx-2 my-auto text-capitalize font-weight-bold col-md-2" style="font-size:17px;text-align:right">Total Amount Due:</label>          
                <asp:Label ID="_oLabelTotalAmountDue" runat="server" text="0.00" class="mx-2 my-auto border border-bottom-light rounded-lg col-md-5" Font-Size="25" Width="100%" style="text-align: right;"/>                       
                </asp:Panel> 
       
            
                </div>

    <div class="">

                     

    


                    </div>


  
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <%--<i class="fa fa-thumbs-up text-white float-right" style="font-size: 30px;"></i>--%>
                    <h4 class="modal-title text-white" id="myModalLabel">&nbsp;&nbsp;Owner's Information</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="form-row form">
                        <div class="col-sm-12 border-right">
                            <div align="center">
                                <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">User Profile</label>
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
                    <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtGovernmentID.ClientID%>');ViewSPA('FileName','FileType','FileData','001','<%=_oTxtGovernmentID.ClientID%>');">View</a>                             
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
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtSPA.ClientID%>');ViewSPA('FileName','FileType','FileData','002','<%=_oTxtSPA.ClientID%>');">View</a>    
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
                        <a href="#" style="font-size:14px !Important;height:30px !Important;max-width:60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtBRSec.ClientID%>');ViewSPA('FileName','FileType','FileData','003','<%=_oTxtBRSec.ClientID%>');">View</a>    
                     </div> 

                            </div>
                        </div>
                        <%--<div class="col-sm-6 border-left">
                            <div align="center">
                                <label class="text-xs font-weight-bold text-primary text-uppercase mb-1">Account Details</label>
                            </div>
                            <br />
                            <div>
                                <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Owner:&nbsp</label>
                                <p class="h6 font-weight-light" runat="server" id="_oLabelOwner"></p>
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
                        </div>--%>
                    </div>
                </div>                
            </div>
        </div>
    </div>
    

        <div class="modal fade" id="modadeclineapplciation">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header bg-primary">
                        <i class="fa fa-question-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="modadeclineapplciationlabel">Disapprove Assessment</h4>
                        <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                    </div>
                    <div class="modal-body">
                        <label class="font-weight-light text-gray mb-1" id="_olblMessage"></label>
                        <label class="text-xs font-weight-light text-primary text-uppercase mb-1">Remarks:&nbsp</label>
                    <textarea id="_oTextRemarks" runat="server" rows="1" class="form-control"></textarea>
                    </div>
                    <div class="modal-footer">            
                        <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" onclick="dodecline();" >Cancel</button>            
                        <%--<button type="button" class="btn btn-warning btn-sm" data-dismiss="modal"  id="_obtnRemarks" runat="server">Remarks</button>--%>
                        <button type="button" class="btn btn-success btn-sm" data-dismiss="modal"  id="_obtnSubmit" runat="server" onclick="dodecline('submit');">Submit</button>                        
                        <%--<input type="button" onclick="do_OK();" value="Okay" class="btn btn-success btn-sm" data-dismiss="modal" />--%>
                    </div>
                </div>
            </div>
        </div>
          
        <input type="hidden" runat="server" id="hdnuserid" />
    <input type="hidden" runat="server" id="hdnseqid" />
    <input type="hidden" runat="server" id="Hidden1" />
    <input type="hidden" runat="server" id="Hidden2" />
    <input type="hidden" runat="server" id="Hidden3" />    


        <script>


            function dodecline(value) {

                __doPostBack('declineapplication', value);
            }
        </script>


        <div class="modal fade" id="modalPostingConfirmation">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-question-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="modalPostingConfirmationLabel"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <label class="font-weight-light text-gray mb-1" id="mess"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-success btn-sm" data-dismiss="modal" style="display:none" id="_oBtnOkay" runat="server">Okay</button>
               <input type="button" onclick="do_OK();" value="Okay" class="btn btn-success btn-sm" data-dismiss="modal" />
                     </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalApproveConfirmation">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-question-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="modalApproveConfirmationLabel"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <label class="font-weight-light text-gray mb-1" id="mess3"></label>
               
                       <textarea runat="server" id="rmkmess3" class="form-control CH-Size-New" placeholder="Remarks" style="font-size: 11px !Important; padding-top: 7px !Important"></textarea>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-success btn-sm" data-dismiss="modal" style="display:none" id="Button1" runat="server">Okay</button>
               <input type="button" onclick="do_Approve(); openModalApproveDone();" value="Okay" class="btn btn-success btn-sm" data-dismiss="modal" />
                     </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalPostingConfirmationDone">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-exclamation-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="modalPostingConfirmationDoneLabel"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center">
                    <label class="font-weight-light text-gray mb-1" id="mess1"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success btn-sm" data-dismiss="modal" id="Button3" runat="server">Okay</button>
                </div>
            </div>
        </div>
    </div>
            <div class="modal fade" id="modalPostingApproveConfirmationDone">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <i class="fa fa-exclamation-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" id="modalPostingApproveConfirmationDoneLabel"></h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center">
                    <label class="font-weight-light text-gray mb-1" id="mess2"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success btn-sm" data-dismiss="modal" id="Button4" runat="server">Okay</button>
                </div>
            </div>
        </div>
    </div>
    </div>

    <script>
        sessionStorage.setItem('txarea', document.getElementById('txarea').value);
          if (sessionStorage.getItem("_sTxtFile1")) {
            document.getElementById('<%=_oTxtFile1.ClientID%>').value = sessionStorage.getItem("_sTxtFile1");
        }
        if (sessionStorage.getItem("_sTxtFile2")) {
            document.getElementById('<%=_oTxtFile2.ClientID%>').value = sessionStorage.getItem("_sTxtFile2");
    }
    if (sessionStorage.getItem("_sTxtFile3")) {
        document.getElementById('<%=_oTxtFile3.ClientID%>').value = sessionStorage.getItem("_sTxtFile3");
        }
        if (sessionStorage.getItem("_sTxtFile4")) {
            document.getElementById('<%=_oTxtFile4.ClientID%>').value = sessionStorage.getItem("_sTxtFile4");
        }
        if (sessionStorage.getItem("_sTxtFile5")) {
            document.getElementById('<%=_oTxtFile5.ClientID%>').value = sessionStorage.getItem("_sTxtFile5");
        }
        if (sessionStorage.getItem("_sTxtFile6")) {
            document.getElementById('<%=_oTxtFile6.ClientID%>').value = sessionStorage.getItem("_sTxtFile6");
        }
        if (sessionStorage.getItem("_sTxtFile7")) {
            document.getElementById('<%=_oTxtFile7.ClientID%>').value = sessionStorage.getItem("_sTxtFile7");
        }
        if (sessionStorage.getItem("_sTxtFile8")) {
            document.getElementById('<%=_oTxtFile8.ClientID%>').value = sessionStorage.getItem("_sTxtFile8");
        }
        if (sessionStorage.getItem("_sTxtFile9")) {
            document.getElementById('<%=_oTxtFile9.ClientID%>').value = sessionStorage.getItem("_sTxtFile9");
        }
        if (sessionStorage.getItem("_sTxtFile10")) {
            document.getElementById('<%=_oTxtFile10.ClientID%>').value = sessionStorage.getItem("_sTxtFile10");
        }
        if (sessionStorage.getItem("_sTxtFile11")) {
            document.getElementById('<%=_oTxtFile11.ClientID%>').value = sessionStorage.getItem("_sTxtFile11");
        }
        if (sessionStorage.getItem("_stxarea")) {
            document.getElementById('txarea').value = sessionStorage.getItem("_stxarea");
            //alert(sessionStorage.getItem("_stxarea"));
        }


        function Getgross() {

            sessionStorage.setItem("_stxarea", document.getElementById('txarea').value);

        }
    </script>
    <script>
        function do_OK() {
            __doPostBack('Post', 'OK');
        }

        function openModal() {
            document.getElementById('modalPostingConfirmationLabel').innerText = 'Posting Confirmation';
            document.getElementById('mess').innerText = 'Are you sure you want to post this assessment?';
            $('#modalPostingConfirmation').modal('show');
        }

        function openModalDone() {
            document.getElementById('modalPostingConfirmationDoneLabel').innerText = 'Done';
            document.getElementById('mess1').innerText = 'Assessment Posted';
            $('#modalPostingConfirmationDone').modal('show');
        }

        function openModalApproveDone() {
            document.getElementById('modalPostingApproveConfirmationDoneLabel').innerText = 'Done';
            document.getElementById('mess2').innerText = 'Account is ready for payment.';
            $('#modalPostingApproveConfirmationDone').modal('show');
        }

        function openModalApprove() {
            document.getElementById('modalApproveConfirmationLabel').innerText = 'Notify Taxpayer for Payment';
            document.getElementById('mess3').innerText = 'Are you sure you want to notify taxpayer for payment?';
            $('#modalApproveConfirmation').modal('show');
        }
        function do_Approve() {
            __doPostBack('Post1', 'OK1');
        }
    </script>

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
