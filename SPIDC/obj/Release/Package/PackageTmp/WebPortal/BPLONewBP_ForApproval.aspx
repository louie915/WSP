<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BPLONewBP_ForApproval.aspx.vb" Inherits="SPIDC.BPLONewBP_ForApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head"  runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <style>
#Information {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#Information td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
}

#Information tr:nth-child(even){background-color: #f2f2f2;}

#Information tr:hover {background-color: #ddd;}

#Information th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #04AA6D;
  color: white;
}

</style>


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
    <div>
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <div id="snackbar" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbar"/>           
                </div>
                <div id="snackbargreen" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

      <!-- Modal View Attachment Form -->
      <div id="ModalView" class="modal fade" >
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
                   nat
          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

     <!-- Modal View Attachment Form -->
      <div id="ModalView2" class="modal fade" >
        <div class="modal-dialog modal-lg">
          <div class="modal-content">
            <div class="modal-header  bg-primary">
              <h4 class="modal-title text-white" id="ModalFileName2"></h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
                   <center>
                   <embed id="embed_Here2" type="text/html" src="#"  width="100%" height="500px" style="object-fit: contain;" />
               </center>    
          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
  

    <br />
     <div class="container">
           <center>
               <div class="col-md-10">
           
                   
    <div id="div_BusInfo" class="MainDiv">
      <div class="btn-primary" style="text-align:left;background-color:lightgray">  
<a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" 
    href="#div_Info" role="button" aria-haspopup="true" aria-expanded="false">  Business Information         </a>
</div>  
           
      <div id="div_Info" class="MainDiv collapse" style="border:2px double lightgray">
    
      
     <div class="collapse show" id="_oPNGrid_Info">  
     

       <table id="Information">

  <tr>
    <td>Application No.</td>
    <td runat="server" id="td_ApplicationNo"> </td>  
  </tr>

<tr>
    <td>Business Account No.</td>
    <td runat="server" id="td_AcctNo"> </td>  
  </tr>
  <tr>
    <td>Ownership Type</td>
    <td runat="server" id="td_OwnershipType"> </td>  
   
  </tr>
  <tr>
    <td>DTI/SEC/CDA Registration No.</td>
     <td runat="server" id="td_DtiSecCda"> </td>  
  </tr>
  <tr>
    <td>Tax Identification Number (TIN)</td>
    <td runat="server" id="td_TIN"> </td>  
 
  </tr>
  <tr>
    <td>Business Name</td>
    <td runat="server" id="td_BusinessName"> </td>  

  </tr>
  <tr>
    <td>Main Office Address</td>
    <td runat="server" id="td_MainOfficeAddress"> </td>  
 
  </tr>
  <tr>
    <td>Telephone Number</td>
    <td runat="server" id="td_TelNo"> </td>  
 
  </tr>
  <tr>
    <td>Mobile Number</td>
    <td runat="server" id="td_MobileNo"> </td>  
 
  </tr>
  <tr>
     <td>Email Address</td>
    <td runat="server" id="td_EmailAddress"> </td>  
  
  </tr>
  <tr>
    <td>Name of Owner</td>
     <td runat="server" id="td_OwnerName"> </td>  
  </tr>

           <tr>
   <td>Nationality</td>
    <td runat="server" id="td_Nationality"> </td>  
  </tr>


             
  <tr style="display:none">
    <td>Business Area (in sq.m)</td>
    <td runat="server" id="td_Area"> </td>  
  </tr>
           
  <tr  style="display:none">
     <td>Business Floor Area (in sq.m)</td>
    <td runat="server" id="td_FloorArea"> </td>  
  </tr>

    <tr>
     <td>No. of Male Employees</td>
    <td runat="server" id="td_MaleEmpNo"> </td>  
  </tr>
            <tr>
     <td>No. of Female Employees</td>
    <td runat="server" id="td_FemaleEmpNo"> </td>  
  </tr>

<tr>
     <td>No. of Employees Residing within</td>
    <td runat="server" id="td_ResidingEmpNo"> </td>  
</tr>           
             
  <tr>
    <td>No. of Delivery Van/Truck</td>
    <td runat="server" id="td_VanTruckNo"> </td>  
  </tr>
           
<tr>
     <td>No. of Delivery Motorcycle</td>
    <td runat="server" id="td_MotorNo"> </td>  
</tr> 
           
<tr style="display:none">
     <td>Business Location Address</td>
    <td runat="server" id="td_BusinessLocationAddress"> </td>  
</tr> 
           
<tr  style="display:none">
     <td>Total Capital (Php)</td>
    <td runat="server" id="td_Capital"> </td>  
</tr> 
           
<tr style="display:none">
     <td>Nature Of Business</td>
    <td runat="server" id="td_Nature"> </td>  
</tr> 
           

</table>
   <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp Nature of Business</strong> 
          </div> 
        <div id="NatureHTML" runat="server" >

        </div>
        <br />
          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp Attachments</strong> 
    </div> 
    
<table id="Information">

  <tr>
    <td>Owner's Picture</td>  
    <td runat="server" id="td_FileName1"> File Name </td>  
    <td><a href="#" 
        onclick="do_view('Owner Picture',
        document.getElementsByName('td_FileType1')[0].innerText, 
        document.getElementsByName('td_FileData1')[0].innerText)"       
        data-toggle="modal" data-target="#ModalView2" data-ticket-type="standard-access">
        View
        </a>
    </td>  

    <td style="display:none" runat="server" name="td_FileData1" id="td_FileData1"> </td>  
    <td style="display:none" runat="server" name="td_FileType1" id="td_FileType1"> </td>  
    <td style="display:none" runat="server" id="td_FileRemarks1"> </td>   
    <td runat="server" id="td_FileStatus1">  </td>    
  </tr>
  <tr>
    <td>Business Establishment Picture</td> 
    <td runat="server" id="td_FileName2"> File Name </td>  
     <td><a href="#" 
        onclick="do_view('Business Establishment Picture',
        document.getElementsByName('td_FileType2')[0].innerText, 
        document.getElementsByName('td_FileData2')[0].innerText)"       
        data-toggle="modal" data-target="#ModalView2" data-ticket-type="standard-access">
        View
        </a>
    </td>  

    <td style="display:none" runat="server" name="td_FileData2" id="td_FileData2"> </td>  
    <td style="display:none" runat="server" name="td_FileType2" id="td_FileType2"> </td>  
    <td style="display:none" runat="server" id="td_FileRemarks2"> </td>  
    <td runat="server" id="td_FileStatus2">  </td>    
  </tr>
  <tr>
   <td>Business Map Location</td> 
   <td runat="server" id="td_FileName3"> File Name </td>  
     <td><a href="#" 
        onclick="do_view('Business Map Location',
        document.getElementsByName('td_FileType3')[0].innerText, 
        document.getElementsByName('td_FileData3')[0].innerText)"       
        data-toggle="modal" data-target="#ModalView2" data-ticket-type="standard-access">
        View
        </a>
    </td>  

    <td style="display:none" runat="server" name="td_FileData3" id="td_FileData3"> </td>  
    <td style="display:none" runat="server" name="td_FileType3" id="td_FileType3"> </td>  
    <td style="display:none" runat="server" id="td_FileRemarks3"> </td>  
    <td runat="server" id="td_FileStatus3">  </td>    
  </tr>
  <tr>
   <td>Application Form with Signature</td> 
       <td runat="server" id="td_FileName4"> File Name </td>  
   <td><a href="#" 
        onclick="do_view('Application Form with Signature',
        document.getElementsByName('td_FileType4')[0].innerText, 
        document.getElementsByName('td_FileData4')[0].innerText)"       
         data-toggle="modal" data-target="#ModalView2" data-ticket-type="standard-access">
        View
        </a>
    </td>  

    <td style="display:none" runat="server" name="td_FileData4" id="td_FileData4"> </td>  
    <td style="display:none" runat="server" name="td_FileType4" id="td_FileType4"> </td>  
    <td style="display:none" runat="server" id="td_FileRemarks4"> </td>  
    <td runat="server" id="td_FileStatus4">  </td>    
  </tr>
  <tr>
    <td>DTI/SEC/CDA Registration</td> 
    <td runat="server" id="td_FileName5"> File Name </td>  
    <td><a href="#" 
        onclick="do_view('DTI/SEC/CDA Registration',
        document.getElementsByName('td_FileType5')[0].innerText, 
        document.getElementsByName('td_FileData5')[0].innerText)"      
         data-toggle="modal" data-target="#ModalView2" data-ticket-type="standard-access">
        View
        </a>
    </td>  

    <td style="display:none" runat="server" name="td_FileData5" id="td_FileData5"> </td>  
    <td style="display:none" runat="server" name="td_FileType5" id="td_FileType5"> </td>  
    <td style="display:none" runat="server" id="td_FileRemarks5"> </td>  
    <td runat="server" id="td_FileStatus5">  </td>    

  </tr>
  <tr>
   <td>TIN Registration</td> 
   <td runat="server" id="td_FileName6"> File Name </td>  
    <td><a href="#" 
        onclick="do_view('TIN Registration',
        document.getElementsByName('td_FileType6')[0].innerText, 
        document.getElementsByName('td_FileData6')[0].innerText)"       
         data-toggle="modal" data-target="#ModalView2" data-ticket-type="standard-access">
        View
        </a>
    </td>  

    <td style="display:none" runat="server" name="td_FileData6" id="td_FileData6"> </td>  
    <td style="display:none" runat="server" name="td_FileType6" id="td_FileType6"> </td>  
    <td style="display:none" runat="server" id="td_FileRemarks6"> </td>  
    <td runat="server" id="td_FileStatus6">  </td>    
 
  </tr>
  
</table>

                <br />
          <div class="btn-primary" style="text-align:left">     
                      <strong > &nbsp LINE OF BUSINESS</strong>
    </div> 
           
        
<table id="Information">

         <asp:GridView ID="_oGridViewBusLine" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="98%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11"
                AllowPaging="True" 
                PagerSettings-Mode="NumericFirstLast" PageSize="10" >
                      
                <Columns>
                    <asp:TemplateField HeaderText="Code" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("BUS_CODE")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width = "30%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusDescription" runat="server" Text='<%# Eval("LINE")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>   
 
                    <asp:TemplateField HeaderText="Capital" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label  ID="_oLabelBusCapital" runat="server" Text='<%# If(Eval("CAPITAL").ToString() = "", "0", Format(Eval("CAPITAL"), "standard"))%>'  />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                               <asp:Label  ID="_oBusinessLineArea" runat="server" Text='<%# If(Eval("AREA").ToString() = "", "0", Format(Eval("AREA"), "standard"))%>'  />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Business Fee" HeaderStyle-Width = "10%" >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusTax" runat="server" Text='<%# If(Eval("BUSTAX").ToString() = "", "0", Format(Eval("BUSTAX"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mayor's Fee" HeaderStyle-Width = "10%" >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelMayors" runat="server" Text='<%# If(Eval("MAYORS").ToString() = "", "0", Format(Eval("MAYORS"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sanitary Fee" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelSanitary" runat="server" Text='<%# If(Eval("SANITARY").ToString() = "", "0", Format(Eval("SANITARY"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Garbage Fee" HeaderStyle-Width = "10%" >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelGarbage" runat="server" Text='<%# If(Eval("GARBAGE").ToString() = "", "0", Format(Eval("GARBAGE"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fire Fee" HeaderStyle-Width = "10%" >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelFire" runat="server" Text='<%# If(Eval("FIRE").ToString() = "", "0", Format(Eval("FIRE"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                    </asp:TemplateField>
           
              
                    
                </Columns>
            </asp:GridView>
       
</table>

         </div>
          </div>


             <br />
 <div class="btn-primary" style="text-align:left;background-color:lightgray">  
<a class="nav-link font-weight-bold text-primary" style="color:white" data-toggle="collapse" 
    href="#div_Regulatory" role="button" aria-haspopup="true" aria-expanded="false" 
    >  For Approval        </a>
</div>  
           
      <div id="div_Regulatory" class="MainDiv collapse show" style="border:2px double lightgray">
          
     <div class="collapse show" id="_oPNGrid_Regulatory">        

         <asp:GridView ID="GridViewTOP" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="98%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                      
                <Columns>
                    <asp:TemplateField HeaderText="Code" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="BUS_CODE" runat="server" Text='<%# Eval("BUS_CODE")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tax Description" >
                        <ItemTemplate>
                            <asp:Label ID="Desc1" runat="server" Text='<%# Eval("Desc1")%>' />
                        </ItemTemplate>
                     
                    </asp:TemplateField>   
 
                    <asp:TemplateField HeaderText="Taxdue" >
                        <ItemTemplate>
                            <asp:Label  ID="Amt_Pd" runat="server" Text='<%# If(Eval("Amt_Pd").ToString() = "", "0", Format(Eval("Amt_Pd"), "standard"))%>'  />
                        </ItemTemplate>             
                           <ItemStyle HorizontalAlign="Right"/>       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Penalty">
                        <ItemTemplate>
                               <asp:Label  ID="Amt_PenPd" runat="server" Text='<%# If(Eval("Amt_PenPd").ToString() = "", "0", Format(Eval("Amt_PenPd"), "standard"))%>'  />
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Right"/>       
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Total Due">
                        <ItemTemplate>
                               <asp:Label  ID="Totdue" runat="server" Text='<%# If(Eval("Totdue").ToString() = "", "0", Format(Eval("Totdue"), "standard"))%>'  />
                        </ItemTemplate>
                          <ItemStyle HorizontalAlign="Right"/>       
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Period Cover" >
                        <ItemTemplate>
                            <asp:Label ID="Qtryr1" runat="server" Text='<%# Eval("Qtryr1")%>' />
                        </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center"/>       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Excess Tax Credit">
                        <ItemTemplate>
                            <asp:Label ID="Discount" runat="server" Text='<%# If(Eval("Discount").ToString() = "", "0", Format(Eval("Discount"), "standard"))%>' />
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Right"/>   
                    </asp:TemplateField>  
                </Columns>
            </asp:GridView>
         <br />     
   <h2 style="text-align:right">Total Amount Due : <span runat="server" id="TotAmtDue">0.00</span></h2>
         <br />
          <input type="button" value="Download App Form" disabled class="btn btn-primary w-25"/>
         <input type="button" value="Preview TOP" runat="server" id="btn_TOP" class="btn btn-primary w-25"/>
      <br />   <br />  
            <input type="button" runat="server" id="btnApproveForBilling" value="Approve for Payment" class="btn btn-primary w-25"/>
       
          </div>           
   <br /> 
                             </div>
                 
                   </div>
               <br /> <br /> <br />
                   </center>

         <input type="hidden" runat="server" id="hdnCode"/>
         <input type="hidden" runat="server" id="hdnAppID"/>
         <input type="hidden" runat="server" id="err" />
           </div>
    <script>
        function do_embed(AppID, ReqCode, File_Name, File_Type, File_Data) {
            document.getElementById('ModalFileName').innerHTML = File_Name;
            document.getElementById('embed_Here').type = File_Type;
            document.getElementById('embed_Here').src = File_Data;

            document.getElementById('<%= hdnCode.ClientID%>').value = ReqCode;
            document.getElementById('<%= hdnAppID.ClientID%>').value = AppID;
        }

        function do_view(File_Name, File_Type, File_Data) {
            document.getElementById('ModalFileName2').innerHTML = File_Name;
            document.getElementById('embed_Here2').type = File_Type;
            document.getElementById('embed_Here2').src = File_Data;

        }
    </script>

</asp:Content>