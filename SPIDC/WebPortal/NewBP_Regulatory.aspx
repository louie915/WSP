<%@ Page Title="" Language="vb"
    AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master"
    CodeBehind="NewBP_Regulatory.aspx.vb" Inherits="SPIDC.NewBP_Regulatory"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        input[type="text"]:disabled {
            background: #dddddd;
        }
   
        body  
        {  
            font-family: Times New Roman;  
            font-size: 10pt;  
        }  
        .Grid th  
        {  
            background-color: #DF7401;  
            color: White;  
            font-size: 10pt;  
            line-height:200%;  
        }  
        .Grid td  
        {  
            background-color: #F3E2A9;  
            color: black;  
            font-size: 10pt;  
            line-height:200%;  
            text-align:center;  
        }  
        .ChildGrid th  
        {  
            background-color: Maroon;  
            color: White;  
            font-size: 10pt;  
        }  
        .ChildGrid td  
        {  
            background-color: Orange;  
            color: black;  
            font-size: 10pt;  
            text-align:center;  
        }  
 
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

    </script>

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="snackbar" style="position: absolute">
                <asp:Label runat="server" ID="_oLabelSnackbar" />
            </div>
            <div id="snackbargreen" style="position: absolute">
                <asp:Label runat="server" ID="_oLabelSnackbargreen" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- Modal View Attachment Form -->
    <div id="ModalView" class="modal fade">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header  bg-primary">
                    <h4 class="modal-title text-white" id="ModalFileName"></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="col-lg-12">
                        <center>
                   <embed id="embed_Here" type="text/html" src="#"  width="100%" height="500px" style="object-fit: contain;" />
           </center>

                    </div>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    <form id="frmNone"></form>
    <div class="container">
        <center>
               <div class="col-md-10">
                    <div class="details">
                         <div  style="border:1px solid gray; background-color:white; padding:10px;display:block;">
                              <div  style="text-align:center;font-family:Arial;" >
                  <h3>Regulatory Office</h3>
                                    <br />
                <div class="btn-primary"><strong>Complete each form & Upload the Requirements</strong></div>
                <hr />
                                   <div class="instruct">
                    <ul style="padding:0px 0px 0px 35px;">
                        <li> Upload soft-copy of neccessary document.</li>
                        <li> Fields with (<span style="color:red;font-size:large">*</span>) indicator are required. </li>
                        <li> Maximum of 10mb file size per file </li>
                        <li> Multiple page documents must be compiled into single PDF file or archive(.rar, .zip) before uploading.  </li>
                        <li > If you mistakenly uploaded the wrong file, just browse and upload again to replace the previous file. </li>
                    </ul>                     
                </div>

          
                       
                                  
<div> 

          <br />  
               <div class="form-group col col-md-5" style="display:inline-block;">
                                    <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Application No. </span></span>
                 </label>
                    <input id="txt_AppNo" runat="server" readonly type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

     <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Business Trade Name</span></span>
                 </label>
                    <input id="txt_BusTradeName" runat="server" readonly type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

    <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Business Address </span></span>
                 </label>
                    <input id="txt_BusAddress"  runat="server" readonly type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Barangay</span></span>
                 </label>
                    <input id="txt_Brgy"  runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 </div>   
                                  
                                               
   
<div id="div_Brgy" class="MainDiv">
      <div class="btn-primary" style="text-align:left;background-color:lightgray">  
        <a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" href="#div_brgy_CLPS" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('_oGIcoBRGY')">  Barangay Clearance Requirement 
            <i id="BRGY_LOCK" runat="server" style="text-align:right;float:right;color:gray"></i>
        </a>
          </div> 
     
    <div id="div_brgy_CLPS" class="collapse"  style="border:2px double lightgray">
       <br />
             <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Clearance No. </span></span>
                 </label>
                    <input id="BRGY_ClearanceNo"  runat="server" readonly  type="text" class="form-control CH-Size-New" />
             </div>               
        </div>

       <div class="form-group col col-md-11" style="display:none;text-align:left">                 
                <label>    
       &nbsp <input type="radio" id="rad_Apply" name="rad_brgyClearance" onchange="radBrgy(this.id);" value="Apply" />   
       I want to apply for Barangay Clearance
   </label>   
              <br />
                 <label>    
       &nbsp <input type="radio" id="rad_Already" name="rad_brgyClearance" onchange="radBrgy(this.id);" value="Already" checked  />   
      I already have Barangay Clearance
   </label>  
           <input type="text" runat="server" id="txtBrgy" name="txtBrgy" placeholder="Enter Clearance No." />   
       </div>
     <div class="" id="_oPNGrid_BRGY">
                        <asp:GridView ID="Grid_BRGY" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="10" HeaderStyle-Font-Size="11" AllowPaging="True">
                            <Columns>

                                  <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>     

                                <asp:TemplateField HeaderText="Requirement/s" HeaderStyle-Width="40%" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelRequirements" runat="server" Text='<%# Eval("REQDESC")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                                

                                <asp:TemplateField HeaderText="Upload File" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <input id="BRGY_up" runat="server" required type="file" class="form-control CH-Size-New"  />
                                           <a href="#" id="up_view" onclick="do_embed('<%# Eval("Application_ID")%>','<%# Eval("ReqCode")%>','<%# Eval("ReqDesc")%>','<%# Eval("File_Type")%>','<%# Eval("File_Data64")%>')" data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access"><%# Eval("File_Name")%></a>
                 
                 
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <asp:Label ID="_oLabelStatus" Text='<%# Eval("Status")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                      <asp:Label ID="_oLabelRemarks" Text='<%# Eval("Remarks")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>            
                    </div>
   <br />
         <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Status </span></span>
                 </label>
                    <input id="BRGY_Status"  runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Remarks</span></span>
                 </label>
                    <input id="BRGY_Remarks"  runat="server" readonly   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

      <input id="btn_BRGY" runat="server" type="button" value="Submit" class="btn btn-primary btn-sm col col-md-5" />
    
             <br />    <br />  

             </div>      
    </div>
  <br />                                        
   
<div class="btn-primary" style="text-align:left;background-color:lightgray">  
          <a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" href="#div_Zoning" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('_oGIcoCPDO')">  Zoning Clearance Requirement       
               <i id="CPDO_LOCK" runat="server" style="text-align:right;float:right;color:gray"></i>

          </a>
</div> 
<div id="div_Zoning" class="MainDiv collapse" style="border:2px double lightgray">
   
     <br />
             <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Clearance No. </span></span>
                 </label>
                    <input id="CPDO_ClearanceNo"  runat="server" readonly  type="text" class="form-control CH-Size-New" />
             </div>               
        </div>
    
          <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 1 </span></span>
                 </label>
                    <input id="CPDO_Info1"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 2</span></span>
                 </label>
                    <input id="CPDO_Info2"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
       <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 3 </span></span>
                 </label>
                    <input id="CPDO_Info3"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 4</span></span>
                 </label>
                    <input id="CPDO_Info4"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 5</span></span>
                 </label>
                    <input id="CPDO_Info5"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

     <div class="collapse show" id="_oPNGrid_CPDO">
                        <asp:GridView ID="Grid_CPDO" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="10" HeaderStyle-Font-Size="11" AllowPaging="True">
                            <Columns>
                                 <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>   
                                <asp:TemplateField HeaderText="Requirement/s" HeaderStyle-Width="40%"  > 
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelRequirements" runat="server" Text='<%# Eval("REQDESC")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                                

                                <asp:TemplateField HeaderText="Upload File" HeaderStyle-Width="40%">
                                    <ItemTemplate>
                                          <input id="CPDO_up" runat="server" required type="file" class="form-control CH-Size-New"  />
                                       <a href="#" id="up_view" onclick="do_embed('<%# Eval("Application_ID")%>','<%# Eval("ReqCode")%>','<%# Eval("ReqDesc")%>','<%# Eval("File_Type")%>','<%# Eval("File_Data64")%>')" data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access"><%# Eval("File_Name")%></a>
                 
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <asp:Label ID="_oLabelStatus" Text='<%# Eval("Status")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                      <asp:Label ID="_oLabelRemarks" Text='<%# Eval("Remarks")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>            
                    </div>
    <br />
      <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Status </span></span>
                 </label>
                    <input id="CPDO_Status"  runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Remarks</span></span>
                 </label>
                    <input id="CPDO_Remarks"  runat="server" readonly   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <br />
      <input id="btn_CPDO" runat="server" type="button" value="Submit" class="btn btn-primary btn-sm col col-md-5" />
    
             <br />          <br />    

             </div>     

<br />    
<div class="btn-primary" style="text-align:left;background-color:lightgray;" id="div_BLDG" runat="server">    
<a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" 
    href="#div_Building" role="button" aria-haspopup="true" aria-expanded="false">  
     Building Official Clearance Requirement       
     <i id="BLDG_LOCK" runat="server" style="text-align:right;float:right;color:gray">Locked</i>
</a>
</div>      
<div id="div_Building" class="MainDiv collapse" style="border:2px double lightgray">
    <br />
       <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Clearance No. </span></span>
                 </label>
                    <input id="BLDG_ClearanceNo"  runat="server" readonly  type="text" class="form-control CH-Size-New" />
             </div>               
        </div>
                                     <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 1 </span></span>
                 </label>
                    <input id="BLDG_Info1"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 2</span></span>
                 </label>
                    <input id="BLDG_Info2"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
       <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 3 </span></span>
                 </label>
                    <input id="BLDG_Info3"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 4</span></span>
                 </label>
                    <input id="BLDG_Info4"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 5</span></span>
                 </label>
                    <input id="BLDG_Info5"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
           <div class="collapse show" id="_oPNGrid_BLDG">
                        <asp:GridView ID="Grid_BLDG" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="10" HeaderStyle-Font-Size="11" AllowPaging="True">
                            <Columns>
                                 <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>   
                                <asp:TemplateField HeaderText="Requirement/s" HeaderStyle-Width="40%" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelRequirements" runat="server" Text='<%# Eval("REQDESC")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                                

                                <asp:TemplateField HeaderText="Upload File" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <input id="BLDG_up" runat="server" type="file" class="form-control CH-Size-New"  />
                                          <a href="#" id="up_view" onclick="do_embed('<%# Eval("Application_ID")%>','<%# Eval("ReqCode")%>','<%# Eval("ReqDesc")%>','<%# Eval("File_Type")%>','<%# Eval("File_Data64")%>')" data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access"><%# Eval("File_Name")%></a>
                 
                                    </ItemTemplate>
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <asp:Label ID="_oLabelStatus" Text='<%# Eval("Status")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                      <asp:Label ID="_oLabelRemarks" Text='<%# Eval("Remarks")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>            
                    </div>
       <br />      <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Status </span></span>
                 </label>
                    <input id="BLDG_Status"  runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Remarks</span></span>
                 </label>
                    <input id="BLDG_Remarks"  runat="server" readonly   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
       <br />
      <input id="btn_BLDG" runat="server" type="button" value="Submit" class="btn btn-primary btn-sm col col-md-5" />
    
             <br />          <br />  
             </div>   
              <br />    
                          
<div class="btn-primary" style="text-align:left;background-color:lightgray;" id="div_HO" runat="server">  
<a class="nav-link font-weight-bold text-primary" style="color:white"  data-toggle="collapse" href="#div_Health" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('_oGIcoHO')">  Health Clearance Requirement     
    <i id="HO_LOCK" runat="server" style="text-align:right;float:right;color:gray">Locked</i>
</a>
      
</div> 
<div id="div_Health" class="MainDiv collapse" style="border:2px double lightgray" style="background-color: #EFEFEF">
   
                                  <br />

      <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Clearance No. </span></span>
                 </label>
                    <input id="HO_ClearanceNo"  runat="server" readonly  type="text" class="form-control CH-Size-New" />
             </div>               
        </div>
                                     <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 1 </span></span>
                 </label>
                    <input id="HO_Info1"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 2</span></span>
                 </label>
                    <input id="HO_Info2"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
       <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 3 </span></span>
                 </label>
                    <input id="HO_Info3"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 4</span></span>
                 </label>
                    <input id="HO_Info4"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 5</span></span>
                 </label>
                    <input id="HO_Info5"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

     <div class="collapse show" id="_oPNGrid_HO">
                        <asp:GridView ID="Grid_HO" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="10" HeaderStyle-Font-Size="11" AllowPaging="True">
                            <Columns>
                                 <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>   
                                <asp:TemplateField HeaderText="Requirement/s" HeaderStyle-Width="40%" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelRequirements" runat="server" Text='<%# Eval("REQDESC")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                                

                                <asp:TemplateField HeaderText="Upload File" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <input id="HO_up" runat="server" required type="file" class="form-control CH-Size-New"  />
                  <a href="#" id="up_view" onclick="do_embed('<%# Eval("Application_ID")%>','<%# Eval("ReqCode")%>','<%# Eval("ReqDesc")%>','<%# Eval("File_Type")%>','<%# Eval("File_Data64")%>')" data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access"><%# Eval("File_Name")%></a>
                 
                                    </ItemTemplate>
                                </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <asp:Label ID="_oLabelStatus" Text='<%# Eval("Status")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                      <asp:Label ID="_oLabelRemarks" Text='<%# Eval("Remarks")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>            
                    </div>
   <br />
      <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Status </span></span>
                 </label>
                    <input id="HO_Status"  runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Remarks</span></span>
                 </label>
                    <input id="HO_Remarks"  runat="server" readonly   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <br />
      <input id="btn_HO" runat="server" type="button" value="Submit" class="btn btn-primary btn-sm col col-md-5" />
    
             <br />          <br />    
             </div>     

<br />  
<div class="btn-primary" style="text-align:left;background-color:lightgray;" id="div_CENRO" runat="server" >  
<a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" 
    href="#div_Environmental" role="button" aria-haspopup="true" aria-expanded="false" 
    onclick="GridCollapse('_oGIcoCENRO')">  Environmental Clearance Requirement       
     <i id="CENRO_LOCK" runat="server" style="text-align:right;float:right;color:gray">Locked</i>
</a>
</div> 
<div id="div_Environmental" class="MainDiv collapse" style="border:2px double lightgray" style="background-color: #EFEFEF">
  
                                  <br />

      <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Clearance No. </span></span>
                 </label>
                    <input id="CENRO_ClearanceNo"  runat="server" readonly  type="text" class="form-control CH-Size-New" />
             </div>               
        </div>
                                     <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 1 </span></span>
                 </label>
                    <input id="CENRO_Info1"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 2</span></span>
                 </label>
                    <input id="CENRO_Info2"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
       <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 3 </span></span>
                 </label>
                    <input id="CENRO_Info3"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 4</span></span>
                 </label>
                    <input id="CENRO_Info4"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 5</span></span>
                 </label>
                    <input id="CENRO_Info5"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
       <div class="collapse show" id="_oPNGrid_CENRO">
                        <asp:GridView ID="Grid_CENRO" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="10" HeaderStyle-Font-Size="11" AllowPaging="True">
                            <Columns>
                                 <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>   
                                <asp:TemplateField HeaderText="Requirement/s" HeaderStyle-Width="40%" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelRequirements" runat="server" Text='<%# Eval("REQDESC")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                                

                                <asp:TemplateField HeaderText="Upload File" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <input id="CENRO_up" runat="server" required type="file" class="form-control CH-Size-New"  />
                  <a href="#" id="up_view"  onclick="do_embed('<%# Eval("Application_ID")%>','<%# Eval("ReqCode")%>','<%# Eval("ReqDesc")%>','<%# Eval("File_Type")%>','<%# Eval("File_Data64")%>')" data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access"><%# Eval("File_Name")%></a>
                 
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <asp:Label ID="_oLabelStatus" Text='<%# Eval("Status")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                      <asp:Label ID="_oLabelRemarks" Text='<%# Eval("Remarks")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>            
                    </div>
    <br />      <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Status </span></span>
                 </label>
                    <input id="CENRO_Status"  runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Remarks</span></span>
                 </label>
                    <input id="CENRO_Remarks"  runat="server" readonly   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <br />
      <input id="btn_CENRO" runat="server" type="button" value="Submit" class="btn btn-primary btn-sm col col-md-5" />
    
             <br />          <br />    
             </div>  
        
  
  

<br />  
<div class="btn-primary" style="text-align:left;background-color:lightgray;" id="div_FIRE2" runat="server">    
<a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" 
    href="#div_FIRE" role="button" aria-haspopup="true" aria-expanded="false" >  
     Bureau of Fire Protection Requirement      
     <i id="FIRE_LOCK" runat="server" style="text-align:right;float:right;color:gray">Locked</i>
</a>
</div>  
<div id="div_FIRE" class="MainDiv collapse" style="border:2px double lightgray">
    <br />
     <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Clearance No. </span></span>
                 </label>
                    <input id="FIRE_ClearanceNo"  runat="server" readonly  type="text" class="form-control CH-Size-New" />
             </div>               
        </div>
                                     <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 1 </span></span>
                 </label>
                    <input id="FIRE_Info1"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 2</span></span>
                 </label>
                    <input id="FIRE_Info2"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
       <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 3 </span></span>
                 </label>
                    <input id="FIRE_Info3"  runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 4</span></span>
                 </label>
                    <input id="FIRE_Info4"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-11" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Info 5</span></span>
                 </label>
                    <input id="FIRE_Info5"  runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
           <div class="collapse show" id="_oPNGrid_FIRE">
                        <asp:GridView ID="Grid_FIRE" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="10" HeaderStyle-Font-Size="11" AllowPaging="True">
                            <Columns>
                                 <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>   

                                <asp:TemplateField HeaderText="Requirement/s" HeaderStyle-Width="40%" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelRequirements" runat="server" Text='<%# Eval("REQDESC")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                                

                                <asp:TemplateField HeaderText="Upload File" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <input id="FIRE_up" runat="server" required type="file" class="form-control CH-Size-New"  />
                                          <a href="#" id="up_view" onclick="do_embed('<%# Eval("Application_ID")%>','<%# Eval("ReqCode")%>','<%# Eval("ReqDesc")%>','<%# Eval("File_Type")%>','<%# Eval("File_Data64")%>')" data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access"><%# Eval("File_Name")%></a>
                 
                
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <asp:Label ID="_oLabelStatus" Text='<%# Eval("Status")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                      <asp:Label ID="_oLabelRemarks" Text='<%# Eval("Remarks")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>            
                    </div>
      <br />      <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Status </span></span>
                 </label>
                    <input id="FIRE_Status"  runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

 <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Remarks</span></span>
                 </label>
                    <input id="FIRE_Remarks"  runat="server" readonly   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
       <br />
   
      <input id="btn_FIRE" runat="server" type="button" value="Submit" class="btn btn-primary btn-sm col col-md-5" />
    
             <br />         <br />    
             </div>         
                              </div>
                         </div>   
                    </div>
 
<asp:GridView ID="GridRegulatory" runat="server" 
    CssClass="mGrid Table-MobileView" AllowSorting="true" 
    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" 
    RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" 
    Width="100%" HeaderStyle-HorizontalAlign="Center" 
    RowStyle-Font-Size="10" HeaderStyle-Font-Size="11" AllowPaging="True">
                            <Columns>
                        <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                                    </ItemTemplate>
                                    </asp:TemplateField>     

                                <asp:TemplateField HeaderText="Requirement/s" HeaderStyle-Width="40%" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelRequirements" runat="server" Text='<%# Eval("REQDESC")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                                

                                <asp:TemplateField HeaderText="Upload File" HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <input id="BRGY_up" runat="server" required type="file" class="form-control CH-Size-New"  />
                                                        <a href="#" id="up_view" onclick="do_embed('<%# Eval("Application_ID")%>','<%# Eval("ReqCode")%>','<%# Eval("ReqDesc")%>','<%# Eval("File_Type")%>','<%# Eval("File_Data64")%>')" data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access"><%# Eval("File_Name")%></a>
            
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                          <asp:Label ID="_oLabelStatus" Text='<%# Eval("Status")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Remarks"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                      <asp:Label ID="_oLabelRemarks" Text='<%# Eval("Remarks")%>' runat="server"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
</asp:GridView>            
               
               </div>
           </center>
    </div>




    <input type="hidden" runat="server" id="hdnCode" />
    <input type="hidden" runat="server" id="hdnAppID" />




    
    <script>
        function radBrgy(id) {
            if(document.getElementById){

            }
        }


        function do_Submit(name) {
            alert(name);

        }
        function do_embed(AppID, ReqCode, File_Name, File_Type, File_Data) {
            document.getElementById('ModalFileName').innerHTML = File_Name;
            document.getElementById('embed_Here').type = File_Type;
            document.getElementById('embed_Here').src = File_Data;

            document.getElementById('<%= hdnCode.ClientID%>').value = ReqCode;
            document.getElementById('<%= hdnAppID.ClientID%>').value = AppID;

        }

    </script>

</asp:Content>
