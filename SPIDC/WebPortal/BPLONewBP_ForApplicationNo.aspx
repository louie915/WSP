<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BPLONewBP_ForApplicationNo.aspx.vb" Inherits="SPIDC.BPLONewBP_ForApplicationNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head"  runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
     
    <style>
#Information{
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#Information td, #Information th {
  border: 1px solid #ddd;
  padding: 8px;
}

#Information tr:nth-child(even){background-color: #f2f2f2;}
#Information tr:hover {background-color: #ddd;}

.warning { background-color: #ffffcc;  border-left: 6px solid #ffeb3b;text-align:left}

   
.tooltip {
  position: relative;
  display: inline-block;
}

.tooltip .tooltiptext {
  visibility: hidden;
  width: 140px;
  background-color: #555;
  color: #fff;
  text-align: center;
  border-radius: 6px;
  padding: 5px;
  position: absolute;
  z-index: 1;
  bottom: 150%;
  left: 50%;
  margin-left: -75px;
  opacity: 0;
  transition: opacity 0.3s;
}

.tooltip .tooltiptext::after {
  content: "";
  position: absolute;
  top: 100%;
  left: 50%;
  margin-left: -5px;
  border-width: 5px;
  border-style: solid;
  border-color: #555 transparent transparent transparent;
}

.tooltip:hover .tooltiptext {
  visibility: visible;
  opacity: 1;
}

</style>
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<script type="text/javascript">

   <%--   function do_embed(ctr) {
        var parent = $('embed#embed_Here').parent();
        var newElement = "<embed id='embed_Here' type='text/html' src='#'  width='100%' height='600px' style='object-fit: contain;'>";
        $('embed#embed_Here').remove();
        parent.append(newElement);

        switch (ctr) {

            case 1:
                document.getElementById('embed_Here').src = document.getElementById('<%= hdn_1.ClientID%>').value;
                       document.getElementById('embed_Here').type = document.getElementById('<%= hdn_1.ClientID%>').value.split(';')[0].split(':')[1];
                       document.getElementById('ModalFileName').innerHTML = 'Owner Picture';
                       document.getElementById('<%= hdn_ImageId.ClientID%>').value = "1"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks1.ClientID%>').value
                       break;
                   case 2:
                       document.getElementById('embed_Here').src = document.getElementById('<%= hdn_2.ClientID%>').value;
                       document.getElementById('embed_Here').type = document.getElementById('<%= hdn_2.ClientID%>').value.split(';')[0].split(':')[1];
                       document.getElementById('ModalFileName').innerHTML = 'Business Establishment Picture';
                       document.getElementById('<%= hdn_ImageId.ClientID%>').value = "2"
                       document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks2.ClientID%>').value
                       break;
                   case 3:
                       document.getElementById('embed_Here').src = document.getElementById('<%= hdn_3.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_3.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'Business Map Location';
                        document.getElementById('<%= hdn_ImageId.ClientID%>').value = "3"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks3.ClientID%>').value
                        break;
                    case 4:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_4.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_4.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'Application Form with Signature';
                        document.getElementById('<%= hdn_ImageId.ClientID%>').value = "4"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks4.ClientID%>').value
                        break;
                    case 5:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_5.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_5.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'DTI/SEC/CDA Registration';
                        document.getElementById('<%= hdn_ImageId.ClientID%>').value = "5"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks5.ClientID%>').value
                        break;
                    case 6:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_6.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_6.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'TIN Registration';
                        document.getElementById('<%= hdn_ImageId.ClientID%>').value = "6"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks6.ClientID%>').value
                        break;
                }

            }

            function do_display() {
                if (sessionStorage.getItem("up_FileName1") == '') {
                    document.getElementById('link_OwnPic').style.display = 'none';
                }
                if (sessionStorage.getItem("up_FileName2") == '') {
                    document.getElementById('link_EstPic').style.display = 'none';
                }
                if (sessionStorage.getItem("up_FileName3") == '') {
                    document.getElementById('link_MapPic').style.display = 'none';
                }
                if (sessionStorage.getItem("up_FileName4") == '') {
                    document.getElementById('link_AppForm').style.display = 'none';
                }
                if (sessionStorage.getItem("up_FileName5") == '') {
                    document.getElementById('link_DtiSecCda').style.display = 'none';
                }
                if (sessionStorage.getItem("up_FileName6") == '') {
                    document.getElementById('link_TIN').style.display = 'none';
                }

            }--%>

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
       
    <script>
        function InitApproved() {
            if (confirm('Confirm approved for local assessment?')) {
                Approve('Approve', '');
            };
        }

        function InitDecline() {
            if (confirm('Confirm decline application?')) {
                Incomplete('Incomplete', '');
            };
        }

    </script>
    
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>

     <!-- Modal Submit Form -->
      <div id="ModalSubmit" class="modal fade" >
        <div class="modal-dialog modal-md"  role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Tag Success</h4>    
              
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
                   You can now Acquire and Assess on BPLTAS <br />
                   Application ID :     
                    <label runat="server" style="color:blue" id="lblApplicationID"></label> 
                              
                <div id="modalHTML" ></div>
                 <br />
               </div>     
                   
     

<div class="warning" style="display:none">
  <p><strong>Who will Assess Regulatory Requirements? : </strong> <br />
      <select id="cmbWho" class="form-control" runat="server" name="cmbWho">
          <option value="BPLO" selected>BPLO</option>
          <option value="REGULATORY">Regulatory Offices</option>
      </select>
</div>       
   
                <center>
                    <i style="color:blue">* Only click this button after completing the Assessment on BPLTAS</i> <br />
                     <input type="button" value="Notify Taxpayer" onclick="Notify('Notify', '')"  class="btn btn-primary btn-sm col col-md-3"  style="background-color:green;"/>
                    <br />      <br />
                    <a href="BPLONewBusinessList.aspx">Return to New Business List</a>
                </center>     
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

      <!-- Modal Incomplete Form -->
      <div id="ModalIncomplete" class="modal fade" >
        <div class="modal-dialog modal-md"  role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Tag as Incomplete</h4>    
              
            </div>
            <div class="modal-body">
               <div class="col-lg-12">                   
                     <div class="form-group col col-md-12">
        <div> 
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Remarks <b style="color:red">*</b>  </span></span>
                 </label>
                    <textarea id="IncRemarks" runat="server" required type="text" class="form-control CH-Size-New">

                    </textarea>
              </div>      
                         <br />
                         <center>
       <input type="button" id="btnINC"  runat="server" class="btn btn-primary btn-sm col col-md-3" value="Save"/>
        </center>
     </div>

                         
               
               </div>                            
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

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
                   <embed id="embed_Here" type="text/html" src="#"  width="100%" height="600px" style="object-fit: contain;" >
                       <input runat="server" type="hidden" id="hdn_ImageId" />
               </center>
                    <div>
                        Remarks:
                        <textarea runat="server" id="txt_ImageRemarks" aria-multiline="true" style="height:50px;width:100%;" ></textarea>
                    </div>
                      
              </div>  
                <center>

                    <br />
                     <br />
                    <input type="button" value="Reject" onclick="UpdateImageStatus('ImageReject', '')"  class="btn btn-primary btn-sm col col-md-3"  style="background-color:red;display:inline-block"/>
                    <input type="button" value="Approve" onclick="UpdateImageStatus('ImageApprove', '')"  class="btn btn-primary btn-sm col col-md-3"  style="background-color:green;display:inline-block"/>
                </center>            
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


       <div class="container">
           <center>
               <div class="col-md-10">
                   <br />
              <h5>New Business (For Application Number)
              </h5>
                   
    <div id="div_BusInfo" class="MainDiv">
      <%--<div class="btn-primary" style="text-align:left">  
            <strong > &nbsp A. BUSINESS INFORMATION AND REGISTRATION</strong> 
    </div> 
       --%>
     
<table id="Information">
     <br />
          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp ATTACHMENTS</strong> 
    </div> 
     <asp:GridView ID="GV_REQS" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true" AutoGenerateColumns="false"  RowStyle-BorderStyle="solid" 
                                               RowStyle-BorderWidth="1" Width="100%" RowStyle-Font-Size="11"  AllowPaging="True">                    
                            <Columns>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:Label ID="ReqDesc" runat="server" Text='<%# Eval("ReqDesc")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>     
                                                          
                                <asp:TemplateField >
                        <ItemTemplate>                
                            <a download="<%# Eval("FileName")%>"
                               href="<%# Eval("File64")%>"   
                              target="_blank" class="btn btn-primary btn-sm col ">
                               Download
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>

                            
                            </Columns>

                        </asp:GridView>
<%--  <tr>
    <td >Owner's Picture</td>  
    <td runat ="server" id="td_OwnPicFileName">  </td>  
       <td> <a href="#" id="link_OwnPic"  class="form-group col col-md-12" onclick="do_embed(1);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
          <input type="hidden" runat="server" id="hdn_1"/>  
           <input type="hidden" runat="server" id="hdn_ImageRemarks1" />
       </td>  
 
    <td runat ="server" id="td_OwnPicStatus">  </td>    
  </tr>
  <tr>
    <td>Business Establishment Picture</td> 
    <td runat ="server" id="td_EstPicFileName" >  </td>  
     
    <td>   
         <a href="#" id="link_EstPic"  class="form-group col col-md-12" onclick="do_embed(2);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
        <input type="hidden" runat="server" id="hdn_2"/>
         <input type="hidden" runat="server" id="hdn_ImageRemarks2" />
    </td>  
    <td runat ="server" id="td_EstPicStatus" > </td>    
  </tr>
  <tr>
   <td>Business Map Location</td> 
    <td runat ="server" id="td_MapPicFileName" >  </td>  
    <td> 
        <a href="#" id="link_MapPic"  class="form-group col col-md-12" onclick="do_embed(3);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
        <input type="hidden" runat="server" id="hdn_3"/>
         <input type="hidden" runat="server" id="hdn_ImageRemarks3" />
    </td>   
    <td runat ="server" id="td_MapPicStatus"> </td>    
  </tr>
  <tr>
   <td>Application Form with Signature</td> 
    <td runat ="server" id="td_AppFormFileName">  </td>  
    <td> 
        <a href="#" id="link_AppForm"  class="form-group col col-md-12" onclick="do_embed(4);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_4"/>
         <input type="hidden" runat="server" id="hdn_ImageRemarks4"/>
    </td>  
  
    <td runat ="server" id="td_AppFormStatus">  </td>    
  </tr>
  <tr>
    <td>DTI/SEC/CDA Registration</td> 
    <td runat ="server" id="td_DtiSecCdaFileName" > </td>  
    <td> 
        <a href="#" id="link_DtiSecCda" onclick="do_embed(5);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_5"/>
         <input type="hidden" runat="server" id="hdn_ImageRemarks5" />
    </td>  
  
    <td runat ="server" id="td_DtiSecCdaStatus">  </td>    

  </tr>
  <tr>
   <td>TIN Registration</td> 
    <td runat ="server" id="td_TINFileName" > </td>  
    <td> 
        <a href="#" id="link_TIN"  class="form-group col col-md-12" onclick="do_embed(6);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_6" />
          <input type="hidden" runat="server" id="hdn_ImageRemarks6" />
    </td>  
 
    <td runat ="server" id="td_TINStatus" >  </td>    
 
  </tr>
  --%>
</table>

        <br />

       <table id="Information">
           

          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp BUSINESS INFORMATION AND REGISTRATION</strong> 
          </div> 

  <tr>
    <td>Application No.</td>
    <td runat="server" id="td_ApplicationNo"> </td>  
  </tr>
  <tr>
    <td>Ownership Type</td>
    <td runat="server"  id="td_OwnershipType">   </td>
   
  </tr>
  <tr>
    <td>DTI/SEC/CDA Registration No.</td>
      <td runat="server"  id="td_DTI_SEC_CDA">   </td>
   
  </tr>
  <tr>
    <td>TIN No.</td>
      <td runat="server"  id="td_TIN">   </td>
  </tr>
  <tr>
    <td>Business Name</td>
      <td runat="server"  id="td_BusinessName">   </td>
 
  </tr>
  <tr style="display:none">
    <td>Trade Name/Franchise</td>
      <td runat="server"  id="td_TradeName">   </td>
 
  </tr>
  <tr>
    <td>Business Address</td>
      <td runat="server"  id="td_MainAddress">   </td>

  </tr>
  <tr>
    <td>Telephone No.</td>
     <td runat="server"  id="td_TelephoneNo">   </td>
 
  </tr>
  <tr>
    <td>Mobile No.</td>
     <td runat="server"  id="td_MobileNo">   </td>
 
  </tr>
  <tr>
    <td>Email Address</td>
     <td runat="server"  id="td_EmailAddress">   </td>
 
  </tr>
  <tr>
    <td>Owner Name</td>
     <td runat="server"  id="td_PresOwnerFullname">   </td>
  
  </tr>
  <tr>
    <td>Nationality</td>
     <td runat="server"  id="td_Nationality">   </td>
  </tr>


</table>
  
        <br />
       <table id="Information">
           

          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp BUSINESS OPERATION</strong> 
          </div> 

  <tr style="display:none">
    <td>Business Area (in sq.m)</td>
    <td runat="server"  id="td_BusinessArea" >    </td>  
  </tr>
  <tr style="display:none">
    <td>Total Floor Area (in sq.m)</td>
    <td runat="server"  id="td_TotalFlrArea"></td>
   
  </tr>
  <tr>
    <td>No. of Employees Male</td>
    <td runat="server"  id="td_NoEmpMale"></td>
  
  </tr>
  <tr>
    <td>No. of Employees Female</td>
    <td runat="server"  id="td_NoEmpFemale"></td>
  
  </tr>
  <tr>
    <td>No. of Employees LGU Residing</td>
    <td runat="server"  id="td_LGUResiding"></td>   
  </tr>
  <tr>
    <td>No. of Delivery Van/Truck</td>
    <td runat="server"  id="td_DeliveryVanTruck"></td>
 
  </tr>
  <tr>
    <td>No. of Delivery Motorcyles</td>
    <td runat="server"  id="td_DeliveryMotorcycle"></td>
 
  </tr>
  <tr style="display:none">
    <td>Business Location Address</td>
    <td runat="server"  id="td_BusinessLocAddress"></td>

  </tr>
  <tr style="display:none">
    <td>Owned?</td>
    <td runat="server"  id="td_Owned"></td>
 
  </tr>
  <tr style="display:none">
    <td>Tax Declaration No.</td>
    <td runat="server"  id="td_TDN"></td>
 
  </tr>
  <tr style="display:none">
    <td>Property Identification No.</td>
    <td runat="server"  id="td_PIN"> </td> 
  </tr>

  <tr style="display:none">
    <td >Total Capitalization (PH)</td>
    <td runat="server"  id="td_Capitalization"> </td> 
  </tr>

  <tr style="display:none">
    <td>Enjoying tax incentives from any Gov't Entity?</td>
    <td runat="server"  id="td_EnjoyingTaxIncentives"> </td>  
  </tr>

  <tr style="display:none">
    <td>Business Activity</td>
    <td runat="server"  id="td_BusinessActivity"></td>  
  </tr>

            <tr style="display:none">
    <td>Nature of Business</td>
    <td runat="server"  id="td_Nature"></td>  
  </tr>


</table>
        <br />

          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp Nature of Business - Taxpayer Input</strong> 
          </div> 
        <div id="NatureHTML" runat="server" >

        </div>

        <br />

             
          <div class="btn-primary" style="text-align:left">     
                      <strong > &nbsp LINE OF BUSINESS</strong>
    </div>
           
<table id="Information">
<div class="warning"  >
  <p><strong> Declaration of business line can be done using BPLTAS once the application has been approved and acquired locally. </strong>  </p>
</div>       
</table>
       
         <link href="../CSS_JS_IMG/docsupport/chosen.css" rel="stylesheet" />

          <div id="id02" class="modal fade" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog">
                      <div class=" modal-content" style="margin-top:40% !Important;">
                            <header class="modal-header">                    
                                <h4>ADD LINE OF BUSINESS</h4>
                                <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                            </header>

                            <div class="modal-body">
                                        <center>
                                            <div class="form-group col-md-12 row d-flex align-content-center justify-content-center " >Search Business Line<br />   
                                        <div class="d-flex align-content-center justify-content-center col-12 mx-auto">
                                         <asp:textbox   id="_oTxtSearchBusLine" runat="server" cssclass="form-control col-9 ml-1" placeholder="Search"  style="text-align:left;"></asp:textbox>
                                        <button type="button" class="btn btn-success col-3 ml-2" id="_oBtnSearch" onclick="PayNow('PayNow', '');">Search</button>
                                            </div> 
                                    </div>
                        
                                       <div>Select Business Line<br /> 
                                         <%--  <asp:DropDownList  runat="server" id="cmbBusCode"     cssclass="form-control chosen-select" style="height:40px;"></asp:DropDownList>--%>
                         
                                         <select   runat="server" id="cmbBusCode" name="cmbBusCode" data-placeholder="Business Line" class="form-control chosen-select" style="height:40px;" >  </select>
                                        </div>

                                        <div>
                                            Area:  <br />
                                             <input id="_oTextboxAddArea"   runat="server" style="text-align:right" class="form-control" placeholder="0" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                                        </div>
                                        <div>
                                            Capital:  <br />
                                           <input id="_oTextboxAddCapital" runat="server" style="text-align:right" class="form-control"  placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                                        </div>                
                                       <br />
                                        <div>
                                           <input type="button" runat="server" id="_ButtonSaveBusinessLine" value="Process and Save" class="btn btn-success"/>
                                       </div>
                                       <br />
                                        </center>
                  
                                    </div>

                      </div>
                </div>
          </div>

               <hr />
                 <button runat="server" id="btnSave" type="button" style="display:none" ></button>
                 <button runat="server" id="btnSubmit" type="button" style="display:none" ></button>


      <div class="form-group col col-md-12" style="display:inline-block">           
               <button name="btnSaveDraft" id="btnSaveDraft" type="button" onclick="SaveDraft();" class="btn btn-primary btn-sm col col-md-3" style="display:none;" >Save Work</button>     
               <input name="btnSubmit" type="button" runat="server" onclick="Incomplete('Incomplete', '');" value="Incomplete" class="btn btn-primary btn-sm col col-md-3"  style="background-color:red;display:none" />

               <input type="button" id="btnIncomplete"  class="btn btn-primary btn-sm col col-md-3" style="background-color:red;" onclick="OpenModalIncomplete();" value="Incomplete"/>
               <input name="btnSubmit" type="button" runat="server" onclick="Approve('Approve', '');" value="Tag as Reviewed" class="btn btn-primary btn-sm col col-md-3"  style="background-color:green" />



        <%--   <input name="btnSubmit" type="button" onclick="InitDecline()" value="Decline" class="btn btn-primary btn-sm col col-md-3"  style="background-color:red;display:inline-block" />
           <input name="btnSubmit" type="button" onclick="InitApproved()" value="Approve" class="btn btn-primary btn-sm col col-md-3"  style="background-color:green;display:inline-block" />--%>

      </div>        
                                     </div>
                   </center>
           </div>



    <br />
    


        <script>

     
     function openModalSubmit() {
         document.getElementById('modalHTML').innerHTML =
         document.getElementById('<%= NatureHTML.ClientID%>').innerHTML;
         $('#ModalSubmit').modal('show');
     }

            function OpenModalIncomplete() {               
                document.getElementById('<%= IncRemarks.ClientID%>').value='';
                $('#ModalIncomplete').modal('show');
     }
                   

            function Incomplete(Action, Val) {
                __doPostBack(Action, Val);
            };

            function Approve(Action, Val) {
                __doPostBack(Action, Val);
            };

            function Notify(Action, Val) {
                __doPostBack(Action, Val);
            };

            function UpdateImageStatus(Action, Val) {
                __doPostBack(Action, Val);
            };

            
        

    </script>

</asp:Content>
