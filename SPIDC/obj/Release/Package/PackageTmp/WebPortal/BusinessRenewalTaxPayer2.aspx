<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="BusinessRenewalTaxPayer2.aspx.vb" Inherits="SPIDC.BusinessRenewalTaxPayer2" %>

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

    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Business Renewal</h5>
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

            <div class="form-group mx-4 my-2">
                <label class="text-capitalize font-weight-bold text-primary">
                    Business Address: &nbsp
                            <br>
                    <asp:Label ID="_oLblBusAddress" runat="server" Text="" />
                </label>
            </div>


        </div>
        <center>

         
        <div class="table-responsive col-lg-12 mt-4" style="border:1px solid #EAE9E9">
               <div runat="server" id="divDeclined" style="display:none" >
          <div class="w3-panel  w3-pale-yellow"> 
  <h3>Renewal Application has beed Declined</h3>
              You renewal application has beed declined due to following reasons : <br />
              • &nbsp <label id="rmrks" runat="server"></label>
  <p>
      Please make sure that your requirements are correct and    
        re-Upload all Mandatory requirements

  </p>
             
 
                
      
</div> 

            <div style="text-align:left">
                 <label class="text-capitalize font-weight-bold text-primary" >
                     Submitted Requirements 
                    </label>           
            </div>       
            <asp:GridView ID="gv_SubmittedRequirements" runat="server" CssClass="mGrid col-lg-10 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>                 
                     <asp:TemplateField HeaderText="Requirement" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <label><%# Eval("REQDESC")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="File Name" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>
                            <label><%# Eval("FileName")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>       
                      <asp:TemplateField HeaderText="File Type" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>
                            <label><%# Eval("FileType")%></label>
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
                <br />
     </div>

            <div style="text-align:left">
                 <label class="text-capitalize font-weight-bold text-primary" >
                     Business Line - Gross and Asset Entry: 
                    </label>
            </div>
            <asp:GridView ID="_GVBusinessLine" runat="server" CssClass="mGrid col-lg-10 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>
                    <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <label class="txBusCode"><%# Eval("BUS_CODE")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Business Line" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("BUSLINE")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CATEGORY" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Enter Gross (Mandatory)" ItemStyle-HorizontalAlign="right" >
                        <ItemTemplate>
                            <input type="text" id="Gross<%# Eval("BUS_CODE")%>" name="txtGross" maxlength="14" style="background-color:#6495ed;color: white;width: 100%; text-align: right" onfocus="do_focus(this.id,this.value)" onblur="do_blur(this.id,this.value)" value="<%# Eval("TaxpayerGross")%>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                
                    <asp:TemplateField HeaderText="Enter Asset (Optional)" ItemStyle-HorizontalAlign="right"  >
                        <ItemTemplate>
                            <input type="text" id="Asset<%# Eval("BUS_CODE")%>" name="txtAsset" maxlength="14" style="background-color:#6495ed;color: white;width: 100%; text-align: right" onfocus="do_focus(this.id,this.value)" onblur="do_blur(this.id,this.value)" value="<%# Eval("TaxpayerAsset")%>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

 
     <br />
            <div id="div_Requirements" runat="server">
                   <div style="text-align:left">
                 <label class="text-capitalize font-weight-bold text-primary" >
                     Max File Size(TOTAL) : <label id="totFS">0</label> / 10 mB
                    </label>
                <center>
                    <label id="lblMessage" style="display:none;color:red;font-weight:bold">Total File Size Exceeded</label>
                </center>
              
            </div>            
            <div style="display:none;"> <asp:FileUpload ID="FileUpload1" CssClass="upload-file" runat="server" /></div>
            <asp:GridView ID="_GVRequirements" runat="server" CssClass="mGrid col-lg-12 Table-MobileView" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>                 
                     <asp:TemplateField HeaderText="Requirement" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <label><%# Eval("REQDESC")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="COMPLIANT" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>
                            <label><%# Eval("WEBCOMPLIANT")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>                  

                    <asp:TemplateField HeaderText="Upload" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>                
                            <input type="file" class="upload-file upl" id="REQ<%# Eval("REQCODE")%>" name="file_<%# Eval("WEBCOMPLIANT")%>" onclick="initialize('<%# Eval("REQCODE")%>')" onchange="do_browse(this.id,'<%# Eval("REQCODE")%>',this.files[0].size)" />
                            
                              </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="File Size" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>                
                             <label id="FS<%# Eval("REQCODE")%>"></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            </div>
         

            <br />
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
            <hr />
              <div class="form-group col-md-8" style="text-align-last: center; color: blue">
                           <label class="container">
  <input type="checkbox" id="chk_auth" onclick="do_chk(this.checked)">
  <span class="checkmark"></span>
&nbsp  I certify to the best of my knowledge under penalty of perjury that the 
                                    information I have provided is true and correct. 
                                    I understand that any inaccurate, false, or missing 
                                    information may invalidate my application for business permit.<br />
</label>
                                
                                  
                            </div>
              <input type="button" disabled value="Submit" id="_btnSave" onclick="do_Save()" class="btn btn-primary col-md-2 col-lg-2 m-2 btn-sm" />

        </div>
            </center>
    </div>


    <asp:Button ID="btnSave" Style="display: none;" Text="Save" runat="server" OnClick="Upload" />

    <input type="hidden" id="hdnGrossAsset" runat="server" />
    <input type="hidden" runat="server" id="hdntotFS" />
    <input type="hidden" runat="server" id="hdnFile" />
    <input type="hidden" runat="server" id="hdnAttachment" />


    <textarea id="taGrossAsset" style="display: none"></textarea>
    <textarea id="taAttachment" style="display: none"></textarea>
    <input type="hidden" runat="server" id="Err" />

    <script>
        function do_chk(val){
            switch (val){
                case true:
                    document.getElementById('_btnSave').disabled=false;
                    break;
                case false:
                    document.getElementById('_btnSave').disabled=true;
                    break;

            }
              
        }

        var Exceeded = 0;
        $("document").ready(function () {
            $(".upload-file").on('change', function () {
                var totalSize = 0;
                $(".upload-file").each(function () {                    
                    for (var i = 0; i < this.files.length; i++) {
                        totalSize += this.files[i].size;
                    }
                });
                var valid = totalSize <= 	10000000;
                if (!valid) {              
                    document.getElementById('lblMessage').style.display='block';
                    Exceeded=1;
                }
                else{
                    document.getElementById('lblMessage').style.display='none';
                    Exceeded = 0;
                }
              
                   
                document.getElementById('totFS').innerText = fileSizeSI(totalSize);
                document.getElementById('<%= hdntotFS.ClientID%>').value = fileSizeSI(totalSize);

            });
        })

        function fileSizeSI(size) {
            var e = (Math.log(size) / Math.log(1e3)) | 0;
            return +(size / Math.pow(1e3, e)).toFixed(2) + ' ' + ('kMGTPEZY'[e - 1] || '') + 'B';
        }

        function _compliant() {
            var stat;
            if (document.getElementsByName("file_MANDATORY").length == 0){
                //document.getElementById('<%= div_Requirements.ClientID%>').style.display ='none';
                stat=true;
                if (Exceeded==0){                       
                   // console.log(document.getElementsByClassName("upl").length);
                    for(var i=0;i<document.getElementsByClassName("upl").length;i++){
                        if (document.getElementsByClassName("upl")[i].value !== ''){
                            var ReqCode = document.getElementsByClassName("upl")[i].id;
                            var ReqCode = ReqCode.replace('REQ','');
                          //  console.log(ReqCode);
                            document.getElementById('<%= hdnAttachment.ClientID%>').value  += ReqCode + ';' ;
                            document.getElementById('taAttachment').innerText  += ReqCode + ';' ;
                                  }                       
                              }
                          }   
            }
            else{
                for(var i=0;i<document.getElementsByName("file_MANDATORY").length;i++){
                    if( document.getElementsByName("file_MANDATORY")[i].files.length == 0 ){                   
                        stat=false;
                        break;
                    }
                    else{
                        stat=true;
                        if (Exceeded==0){                       
                             console.log(document.getElementsByClassName("upl").length);
                            for(var j=0;j<document.getElementsByClassName("upl").length;j++){
                                if (document.getElementsByClassName("upl")[j].value !== ''){
                                    var ReqCode = document.getElementsByClassName("upl")[j].id;
                                    var ReqCode = ReqCode.replace('REQ','');
                                      console.log(ReqCode);
                                    document.getElementById('<%= hdnAttachment.ClientID%>').value  += ReqCode + ';' ;
                                    document.getElementById('taAttachment').innerText  += ReqCode + ';' ;
                                }                       
                            }
                        }            
                    }              
                }      
            }
                 
            return stat
        }

        function hasset(){
            for (var i = 0; i < document.getElementsByName('txtAsset').length;i++){
                document.getElementsByName('txtAsset')[i].style.display='none';
            }
        }

        function do_Save() {
            if(_gross()){
                if (_compliant()){
                    if (Exceeded == 0){
                        var txBusCode = document.getElementsByClassName('txBusCode');
                        for (let i = 0; i < txBusCode.length; i++) {
                            document.getElementById('<%= hdnGrossAsset.ClientID%>').value += txBusCode[i].innerHTML + ':' + parseFloat(document.getElementsByName('txtGross')[i].value.replace(/,/g, '')).toFixed(2) + ':' + parseFloat(document.getElementsByName('txtAsset')[i].value.replace(/,/g, '')).toFixed(2) + ';';
                        }
                        document.getElementById('taGrossAsset').value = document.getElementById('<%= hdnGrossAsset.ClientID%>').value;
                        document.getElementById('<%= btnSave.ClientID%>').click();
                    }
                    else
                    {alert('Max File Size Exceeded.');}
                   
                }
                else{
                    alert('Please Upload MANDATORY Requirements');
                }
            }
            else{
                alert('Please Complete Gross Entry');
            }           
        }

        function _gross(){
            var stat;
            for(var i=0;i<document.getElementsByName("txtGross").length;i++){
                if( document.getElementsByName("txtGross")[i].value < 1 ){                   
                    stat=false;
                    break;
                }
                else{stat=true;}              
            }           
            return stat
        }

        function do_focus(id, val) {
            document.getElementById(id).value = val.replace(/,/g, '');
            document.getElementById(id).type = 'Number'
        }
        function do_blur(id, val) {
            document.getElementById(id).type = 'Text'
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(val);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');
            x = x.replace('₱', '');
            document.getElementById(id).value = x;
        }
        function do_browse(ID, ReqCode, FS) {
            //  ReqCode = ("0000" + ReqCode).slice(-4);
            document.getElementById("FS" + ReqCode).innerHTML = 0;
            document.getElementById("FS" + ReqCode).innerHTML = fileSizeSI(FS);
        }       
   
        function initialize(REQCODE)
        {
            var theFile = document.getElementById("REQ" + REQCODE);
            document.body.onfocus =  function checkIt()
            {
                if(theFile.value.length) 
                    document.getElementById("FS" + REQCODE).innerHTML='';
                else              
                    document.body.onfocus = null;
           
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
