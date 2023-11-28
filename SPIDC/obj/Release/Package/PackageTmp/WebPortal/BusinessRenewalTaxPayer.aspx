<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="BusinessRenewalTaxPayer.aspx.vb" Inherits="SPIDC.BusinessRenewalTaxPayer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">


    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <script>


        //SNACKBAR - Welcome       
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
        };
        function CheckandSave()
        {  
            var sample  = document.getElementsByClassName('get-child-gross');
            var CheckTrigger = false;
            for (var a = 0 ; a < sample.length ; a++) 
            {
                //alert(sample[a].value);
                if(!sample[a].value.length > 0 ){                   
                    document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Please input Gross amount!";
                  
                            Snackbar();
                            CheckTrigger = true;
                            break;
                        }
                        else
                        {                            
                            var ChFile  = document.getElementsByClassName('FRequiered');
                            for (var b = 0 ; b < sample.length ; b++) 
                            {
                                if(!ChFile[a].value.length > 0  && !ChFile[a].value == 0){                   
                                    document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Please input Gross amount!";
                                    //alert('2');
                                    Snackbar();
                                    CheckTrigger = true;
                                    break;
                                }
                            }
                            for (var i = 0 ; i < ChFile.length ; i++)
                            {   
                                if(!ChFile[i].value.length)
                                {
                                    document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Please complete all required fields!";
                                    Snackbar();
                                    CheckTrigger = true;
                                    break;
                                }
                            
                            }
                            if(!CheckTrigger)
                            {
                                __doPostBack('Save','');
                            }                            
                            
                        }
                    }
                        
                }

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

    <link href="../CSS_JS_IMG/css/newcss/aurora/aurora.css" rel="stylesheet" />


    <div>
     
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


     <!-- Modal New Business Requirements Form -->
      <div id="NewBusReq" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Business Renewal Application Requirement</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
            <div class="card mb-5 mb-lg-0">
              <div class="card-body">  
                <h6 class="card-price text-center">“Before proceeding, please prepare soft-copy of the following documents on your device."</h6>
                <hr>
                <ul class="fa-ul">                
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>DTI Registration (Single Proprietor)</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>SEC Registration (Corporation)</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Lessor’s Permit (If Renting)</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Tax Declaration of Property (If Owned)</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Public Liability Insurance SPA/ Secretary's Certificate and LD for Authorized Representative</li>
                </ul>                  
                            </div>
            </div>
          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
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

                        <label class="text-capitalize font-weight-bold text-primary">Business Line: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusCategory" runat="server" Text="" />
                        </label>
                        
                    </div>
                </div>


                <div class="form-group mx-4 my-2">
                    <div>

                        <label class="text-capitalize font-weight-bold text-primary">
                            Category: &nbsp
                            <br>
                            <asp:Label ID="_oLblBusCategory1" runat="server" Text="" />
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

            </div>

            <center>
            <div class="table-responsive col-lg-12 mt-4" >

             <asp:GridView ID="_GVBusinessLine" runat="server" CssClass="mGrid col-lg-10 Table-MobileView get-gross" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" >
                <Columns>
                    <asp:TemplateField HeaderText="Business Line" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="CATEGORY" ItemStyle-HorizontalAlign="left" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY1")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Enter Gross" ItemStyle-HorizontalAlign="right" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <input type="text"" style="width:100%;text-align:right;border:none;background-color:#6495ed;color: white"  ID="_oLabelEnterGross"  value='<%# Eval("GROSSAMT", "{0:C}").ToString().Replace("$", "")%>' onblur="GrossEntry(this.value,'<%# Eval("BUSCODE")%>');FormatGross();" onkeypress="return isNumberKey(event)" class="get-child-gross"/>

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
                                    x = x.replace('₱',''); 
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
                                                x = x.replace('₱',''); 
                                                txtgross[a].value = x;
                                            }
                                        }
                                    }

                                }


                          
                                    </script>

                            <script>
                                window.onload = function () {
                                    var input = document.getElementById("_oLabelEnterGross").focus();
                                }
                            </script>

                        </ItemTemplate>
                    </asp:TemplateField>

                     

                </Columns>


            </asp:GridView>
            
                
                    <style>

                    .input-txt-active3 {
                    
                            text-align: left !Important;
                            font-size:15px !Important;
                            align-content:center !Important;                               
                    
                    }


                </style>
                </div> 

                <div class="col-lg-8 row">
                    <div class="p-1 col-12 mb-2">
                        <p class="m-2 font-weight-bold" style="text-align:left !Important">Uploaded Files: Supported file Extensions (.png,.jpg,.pdf)</p>
                    </div>
                    <div class="p-1 col-12 mb-2">
                        <p class="m-2 font-weight-bold" style="text-align:left !Important" id="_oLblTypeTitle" runat="server"></p>
                    </div>
                    <asp:Panel runat="server" ID="_oPnFile1"  CssClass="form-group col-md-6 " Visible="false">

                        <div>                            
                            <p class="input-txt-active3">Certified True Copy of Quaterly VAT and Monthly VAT for calendar year<%--<span style="color:red;font-weight:bolder; font-size:15px !Important;"> *</span>--%></p>                            
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important;" id="_oTxtFile1" onchange="here('file1',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <%--<input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oLblFile1"  visible="false"/>--%>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile1.ClientID%>').click();" style="font-size: 11px !Important;" />&nbsp
                                <label id="_oLblFile1" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile2"  CssClass="form-group col-md-6 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">If non-VAT present monthly percentage tax for the previous year<%--<span style="color:red;font-weight:bolder; font-size:15px !Important;"> *</span>--%>
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important;" id="_oTxtFile2"  onchange="here('file2',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile2.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile2" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile3" CssClass="form-group col-md-6 " Visible="true">

                        <div>
                            
                            <p class="input-txt-active3">Barangay Clearance / Barangay Tax Order of Payment&nbsp
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New " style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile3"  required onchange="here('file3',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile3.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile3" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile4" CssClass="form-group col-md-6 " Visible="false">

                        <div>
                           
                            <p class="input-txt-active3">
                                If with branches outside LGU Premise,submit Breakdown of sales per city/municipality and attach business/permit application for those cities.
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile4"  onchange="here('file4',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile4.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile4" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile5" CssClass="form-group col-md-6 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">Notarized Written Authorization Letter
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile5"  onchange="here('file5',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile5.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile5" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile6" CssClass="form-group col-md-6 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">ID of Registered Owner and Company ID of representative
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile6"  onchange="here('file6',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile6.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile6" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile7" CssClass="form-group col-md-6 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">Secretary Certificate
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile7"  onchange="here('file7',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile7.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile7" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile8" CssClass="form-group col-md-6 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">Notarized Written Authorization from one of the partners
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile8"  onchange="here('file8',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile8.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile8" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile9" CssClass="form-group col-md-6 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">Duly accomplished business application form, indicating gross sales/receipt
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile9"  onchange="here('file9',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile9.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile9" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile10" CssClass="form-group col-md-6 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">Public Liability Insurance
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile10"  onchange="here('file10',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile10.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile10" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel runat="server" ID="_oPnFile11" CssClass="form-group col-md-6 " Visible="false">

                        <div>
                            
                            <p class="input-txt-active3">Barangay Clearance
                            </p>
                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important;display:none !Important" id="_oTxtFile11"  onchange="here('file11',document.getElementById('txarea').value);" accept=".jpg,.jpeg,.pdf,.png"/>
                            <div class="form-control CH-Size-New align-content-between align-items-baseline d-flex" >
                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oTxtFile11.ClientID%>').click();" style="font-size: 11px !Important;"/>&nbsp
                                <label id="_oLblFile11" runat="server" class = "LblRequired" style="font-size: 11px !Important; padding-top: 7px !Important">No file chosen</label>
                            </div>
                        </div>


                    </asp:Panel>                
        </div>

                
         
                </center>

                              <script>       
                                  function OnloadFile()
                                  {
                                  
                                        }
                                   
                                  function here(fileno,txtval){                                           
                                      if(fileno == 'file1'){sessionStorage.setItem('file1',document.getElementById('<%=_oTxtFile1.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile1.ClientID%>').innerHTML = (sessionStorage.getItem('file1') ? sessionStorage.getItem('file1') : "No file chosen");  }
                                      if(fileno == 'file2'){sessionStorage.setItem('file2',document.getElementById('<%=_oTxtFile2.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile2.ClientID%>').innerHTML = (sessionStorage.getItem('file2') ? sessionStorage.getItem('file2') : "No file chosen");  }
                                      if(fileno == 'file3'){sessionStorage.setItem('file3',document.getElementById('<%=_oTxtFile3.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile3.ClientID%>').innerHTML = (sessionStorage.getItem('file3') ? sessionStorage.getItem('file3') : "No file chosen");  }
                                      if(fileno == 'file4'){sessionStorage.setItem('file4',document.getElementById('<%=_oTxtFile4.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile4.ClientID%>').innerHTML = (sessionStorage.getItem('file4') ? sessionStorage.getItem('file4') : "No file chosen");}
                                      if(fileno == 'file5'){sessionStorage.setItem('file5',document.getElementById('<%=_oTxtFile5.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile5.ClientID%>').innerHTML = (sessionStorage.getItem('file5') ? sessionStorage.getItem('file5') : "No file chosen");}
                                      if(fileno == 'file6'){sessionStorage.setItem('file6',document.getElementById('<%=_oTxtFile6.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile6.ClientID%>').innerHTML = (sessionStorage.getItem('file6') ? sessionStorage.getItem('file6') : "No file chosen");}
                                           if(fileno == 'file7'){sessionStorage.setItem('file7',document.getElementById('<%=_oTxtFile7.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile7.ClientID%>').innerHTML = (sessionStorage.getItem('file7') ? sessionStorage.getItem('file7') : "No file chosen");}
                                           if(fileno == 'file8'){sessionStorage.setItem('file8',document.getElementById('<%=_oTxtFile8.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile8.ClientID%>').innerHTML = (sessionStorage.getItem('file8') ? sessionStorage.getItem('file8') : "No file chosen");}
                                           if(fileno == 'file9'){sessionStorage.setItem('file9',document.getElementById('<%=_oTxtFile9.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile9.ClientID%>').innerHTML = (sessionStorage.getItem('file9') ? sessionStorage.getItem('file9') : "No file chosen");}
                                           if(fileno == 'file10'){sessionStorage.setItem('file10',document.getElementById('<%=_oTxtFile10.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile10.ClientID%>').innerHTML = (sessionStorage.getItem('file10') ? sessionStorage.getItem('file10') : "No file chosen");}
                                           if(fileno == 'file11'){sessionStorage.setItem('file11',document.getElementById('<%=_oTxtFile11.ClientID%>').files[0].name);                                       
                                          document.getElementById('<%=_oLblFile11.ClientID%>').innerHTML = (sessionStorage.getItem('file11') ? sessionStorage.getItem('file11') : "No file chosen");}
                                      //alert(txtval);                                    
                                           sessionStorage.setItem('txarea',txtval);                                       
                                      //__doPostBack('fileupload',fileno); 
                                       }
                                       window.onload = gettxarea;
                                       function gettxarea()
                                       {
                                           //alert(sessionStorage.getItem('txarea')); 
                                           document.getElementById('txarea').value = sessionStorage.getItem('txarea');
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

                            <center style="display:none">
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
            <div class="row">
                <asp:ListBox ID="_oListBox1" runat="server" Visible="false">
                                  
                </asp:ListBox>
            </div> 

            <br />
     <center>            
                    <div class="form-group col col-md-4" style="display:block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Select Mode of Payment <b style="color:red">*</b> </span></span>
                 </label>
                  <select required runat="server" id="cmb_MOP" class="form-control">   
                      <option value="Quarterly">Quarterly</option>         
                      <option value="Semi-Annual">Semi-Annual</option>   
                      <option value="3-Quarters">3-Quarters</option>   
                      <option value="Annually">Annually</option>                 
                  </select>  
   
             </div>               
        </div>
          </center>
            <div class=" d-flex justify-content-center">               
                <div class="col-md-12 row d-flex justify-content-center mt-4">

                    <button name="_obtnSaveEdit" id="_obtnSaveEdit" type="button" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" onclick="__doPostBack('Save','');">Submit
                    </button>
                    <button name="_obtnPrintApplication" runat="server" id="_obtnPrintApplication" type="submit" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" visible="false">Print Application Form</button>
                </div>

            </div>
            <script>
              function CheckandSave()
              {

              document.body.scrollTop = 0;
              document.documentElement.scrollTop = 0;

                    var sample  = document.getElementsByClassName('get-child-gross');
                    var CheckTrigger = false;
                    for (var a = 0 ; a < sample.length ; a++) 
                    {
                        //alert(sample[a].value);
                        if(!sample[a].value.length > 0 || sample[a].value == "0.00" ){                   
                            document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Please input Gross amount!";
                            Snackbar();
                            break;
                        }
                        else
                        {                            
                           var ChFile  = document.getElementsByClassName('FRequiered');
                            for (var b = 0 ; b < sample.length ; b++) 
                            {
                                if(!ChFile[a].value.length > 0 || sample[a].value == "0.00" ){                   
                                    document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Please input Gross amount!";
                                    Snackbar();
                                    break;
                                }
                            }
                        if(document.getElementById('<%=_oTxtFile3.ClientID%>').value.length > 0)
                            {
                                __doPostBack('Save','');
                          }
                            else
                            {
                                document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Please complete all required fields!";
                                Snackbar();
                            }
                            
                        }
                    }
                        
                }                                       
                                
            </script>
            <div class="modal fade" id="submitModal">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header bg-primary">
                            <i class="fa fa-info text-white float-right" style="font-size: 30px;"></i>
                            <h4 class="modal-title text-white" id="myModalLabel">&nbsp;&nbsp;Notice</h4>
                            <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body" align="center">
                            <label class="font-weight-bold text-gray mb-1">Gross amount successfully forwarded to BPLO!</label><br />
                            <label class="font-weight-light text-red mb-1" style="color: red">Note: Entered Gross amount is/are subject for approval.</label>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary btn-sm pull-center" data-dismiss="modal" id="_oBtnOkay" runat="server">Okay</button>
                        </div>
                    </div>
                </div>
            </div>
            
            <script>
                function openModal() {
                    $('#submitModal').modal('show');
                }
                //document.getElementById('_obtnSaveEdit').disabled = 'false';
            </script>


            <textarea id="txarea" name="txarea" style="visibility: hidden; display: none;"></textarea><br>

            <script>
                function GrossEntry(gross, uniqueID) {
                    document.getElementById("txarea").value = document.getElementById("txarea").value + uniqueID + ":" + gross + ";";
                    //document.getElementById("txarea").value = id;
                    //alert(gross + " - " + uniqueID);


                }
              
            </script>

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

        function openModal() {
            $('#NewBusReq').modal('show');
        }

    </script>
    
</asp:Content>
