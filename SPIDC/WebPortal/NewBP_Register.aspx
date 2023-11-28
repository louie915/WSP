﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="NewBP_Register.aspx.vb" Inherits="SPIDC.NewBP_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" ClientIDMode="Static" runat="server">

    <style>
        input[type="text"]:disabled {
            background: #dddddd;
        }

        #myTable, #myTable2 {
            font-family: Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            #myTable td, #myTable th, #myTable2 td, #myTable2 th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #myTable tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #myTable2 tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #myTable tr:hover {
                background-color: #ddd;
            }

            #myTable2 tr:hover {
                background-color: #ddd;
            }

            #myTable th, #myTable2 th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #C1C1C1;
                color: black;
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


    <!-- Modal New Business Requirements Form -->
    <div id="NewBusReq" class="modal fade">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">New Business Application Requirement</h4>
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
                                    <li><span class="fa-li"><i class="fa fa-check"></i></span>Image Copy Barangay Business Clearance</li>
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
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

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
                   <embed id="embed_Here" type="text/html" src="#"  width="100%" height="600px" style="object-fit: contain;" >
           </center>
                    </div>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <!-- Modal Nature Of Business -->
    <div id="ModalNature" class="modal fade">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header  bg-primary">
                    <h4 class="modal-title text-white">Nature of Business - Sample</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="col-lg-12">
                        <center>
           </center>
                    </div>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <!-- Modal Submit Form -->
    <div id="ModalSubmit" class="modal fade">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="New Business Application"></h4>
                    <%--<button type="button" class="close" onclick="window.location.href('account.aspx');" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>--%>
                </div>
                <div class="modal-body">
                    <div class="col-lg-12">
                        Your New Business Application is successfully submitted.<br />
                        We will email you for our response and update your account information.<br />
                        Stay safe.

                  
           
                    </div>
                    <center>
                    <a href="Account.aspx" >Return to Home Page</a>
                </center>

                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <div class="container">
        <center>
               <div class="col-md-10">
                    <div class="details">
                         <div  style="border:1px solid gray; background-color:white; padding:10px;display:block;">
                              <div  style="text-align:center;font-family:Arial;" >
                  <h3>New Business Permit Application</h3>
                                    <br />
                <div class="btn-primary"><strong>Complete this form & Upload the Requirements</strong></div>
                <hr />
                <div class="instruct">
                    <ul style="padding:0px 0px 0px 35px;">
                        <li> Upload soft-copy of neccessary document.</li>
                        <li> Fields with (<span style="color:red;font-size:large">*</span>) indicator are required. </li>
                        <%--<li> Maximum of 10mb file size per file </li>
                        <li> Multiple page documents must be compiled into single PDF file or archive(.rar, .zip) before uploading.  </li>
                        <li > If you mistakenly uploaded the wrong file, just browse and upload again to replace the previous file. </li>--%>
                    </ul>                     
                </div>
<br />
          
                                    
   <div id="divChecker">
<div id="div_BusInfo" class="MainDiv">
      <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp Business Information</strong> 
    </div> 
          <br />  

       <div class="form-group col col-md-4" style="display:inline-block;">
            <div>
                 <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Ownership Type <b style="color:red">*</b> </span></span>
                 </label>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                    <select required id="cmb_OwnershipType" runat="server" class="form-control" onchange="chkOwnership(this.value)">   
                  </select>
                    </ContentTemplate>
                </asp:UpdatePanel>

              
                
                <input type="hidden" id="hdn_Ownership" />
                               </div>          
                    </div>
                     
        <div class="form-group col col-md-4" style="display:inline-block;">
                                    <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">DTI/SEC/CDA Registration Number <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_DtiSecCda" class="form-control CH-Size-New"
                        runat="server" required
                        onkeypress="return onlyNumbers(this);"
                        onkeyup="addHyphen(this)"
                        placeholder="XXX-XXX-XXX-XXX" 
                        pattern="[\s 0-9 -]+" 
                        oninput="this.reportValidity()" 
                        title="DTI/SEC/CDA" 
                        onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " 
                        maxlength="15" 
                        />
             </div>               
        </div>
     <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Tax Identification Number <b style="color:red">*</b> </span></span>
                 </label>
                  <%--  <input id="txt_TIN" required type="text" type="number" class="form-control CH-Size-New"/>--%>
              <input type="text" required runat="server" class="form-control ch-size-new" name="TIN" id="txt_TIN" onkeypress="return onlyNumbers(this);" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" title="TIN" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                      
          
           </div>               
        </div>
     <div class="form-group col col-md-6"  style="display:inline-block" >
        <div> 
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Business / Commercial Name <b style="color:red">*</b>  </span></span>
                 </label>
                    <input id="txt_BusinessName" runat="server" required type="text"  class="form-control CH-Size-New uppercase-input"/>
              </div>      
        
     </div>
     <div class="form-group col col-md-5"  style="display:inline-block" >
        <div> 
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Date of Establishment <b style="color:red">*</b>  </span></span>
                 </label>
                    <input id="txt_DateEsta" runat="server" required type="text" class="form-control CH-Size-New" onfocus="date_OnFocus();" onblur="date_OnBlur();" format="MM/dd/yyyy"/>
              </div>      
        
     </div>


    

       
    </div>       
<div id="div_Branch" class="MainDiv"> 
            <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp  Business Location Address</strong> 
    </div> 
          <br />  
               <div class="form-group col col-md-2" style="display:inline-block;">
                                    <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">House/Bldg No. </span></span>
                 </label>
                    <input id="txt_B_HouseNo" runat="server"  type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

     <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Name of Building </span></span>
                 </label>
                    <input id="txt_B_BldgName" runat="server"  type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

    <div class="form-group col col-md-2" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Lot No.  </span></span>
                 </label>
                    <input id="txt_B_LotNo" runat="server" type="text" class="form-control CH-Size-New uppercase-input"   />
             </div>               
        </div>

 <div class="form-group col col-md-2" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Block No. </span></span>
                 </label>
                    <input id="txt_B_BlockNo" runat="server"  type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>
   
             <div class="form-group col col-md-4" style="display:inline-block">
      <div>

           
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Barangay <b style="color:red">*</b> </span></span>
                 </label>
        <asp:UpdatePanel runat="server">
        <ContentTemplate>
                   <select required runat="server" id="cmb_Brgy" class="form-control"  onchange="__doPostBack('BRGY', this.value)" >   
                                                            
                  </select>    
           </ContentTemplate>
    </asp:UpdatePanel>   
          
          <%-- <input id="txt_B_Brgy" required type="text" class="form-control CH-Size-New"  />--%>
             </div>               
        </div>
            <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Street <b style="color:red">*</b> </span></span>
                 </label>
       
              <select required runat="server" id="cmb_Street" class="form-control">   
                                                            
                  </select>  
                  
          
                 <%--   <input id="txt_B_Street" required type="text" class="form-control CH-Size-New"  />
        --%>     </div>               
        </div>
    
   

 



<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Subdivision </span></span>
                 </label>
                    <input id="txt_B_Subd" runat="server" type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

      
 <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">City/Municipality <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_B_CityMunicipality" readonly runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2"> Province<b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_B_Province" readonly runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Zip Code <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_B_ZipCode" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
 </div>   
<div id="div_Contact" class="MainDiv">

 <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp  Owner / President Information</strong> 
    </div>
<br />
       <div class="form-group col col-md-6" style="display:inline-block;">
                                    <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Telephone Number </span></span>
                 </label>
                    <input id="txt_TelNo"  runat="server"
                        onkeypress="return onlyNumbers(this);" maxlength="11" class="form-control CH-Size-New"  />
             </div>               
        </div>

     <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Mobile Number <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_MobileNo" required runat="server"
                        onkeypress="return onlyNumbers(this);" maxlength="11" class="form-control CH-Size-New"  />
             </div>               
        </div>
 <div class="form-group col col-md-5" style="display:none" >
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Email Address <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_Email" type="text" runat="server" class="form-control CH-Size-New"  />
             </div>               
        </div>

    <div id="_oDivOwnerName" style="display:block">
         <div class="form-group col col-md-3" style="display:inline-block">
          <div>
                     <label class="input-txt input-txt-active2">
                           <span><span class="m-2">Surname <b style="color:red">*</b> </span></span>
                     </label>
                        <input id="txt_Sole_Lname" runat="server" required type="text" class="form-control CH-Size-New uppercase-input"  />
                 </div>               
            </div>
         <div class="form-group col col-md-3" style="display:inline-block">
          <div>
                     <label class="input-txt input-txt-active2">
                           <span><span class="m-2">Given Name <b style="color:red">*</b> </span></span>
                     </label>
                        <input id="txt_Sole_Fname" runat="server" required type="text" class="form-control CH-Size-New uppercase-input"  />
                 </div>               
            </div>
         <div class="form-group col col-md-3" style="display:inline-block">
          <div>
                     <label class="input-txt input-txt-active2">
                           <span><span class="m-2">Middle Name </span></span>
                     </label>
                        <input id="txt_Sole_Mname" runat="server"  type="text" class="form-control CH-Size-New uppercase-input"  />
                 </div>               
            </div>
         <div class="form-group col col-md-2" style="display:inline-block">
            <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Suffix </span></span>
                 </label>
                    <input id="txt_Sole_Suffix" runat="server"  type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

    </div>
   




      <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Nationality <b style="color:red">*</b> </span></span>
                 </label>
                  <select required runat="server" id="cmb_Nationality" class="form-control">   
                                                            
                  </select>  
   
             </div>               
        </div>
    
     <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Gender <b style="color:red">*</b> </span></span>
                 </label>
                  <select required runat="server" id="cmb_Gender" class="form-control">   
                                                            
                  </select>  
   
             </div>               
        </div>



</div>
<div id="div_Address" class="MainDiv">   
    
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp Owner / President Address</strong></div>
      
 <label style="float:left;position:relative" id="lbl_SameAddress">    
        &nbsp <input  id="chk_SameAddress" type="checkbox" onchange="chkSameAddress(this.checked)" />   
       Same as Business Address
    </label> <br /><br />
     <div class="form-group col col-md-2" style="display:inline-block;">
                                    <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">House/Bldg No. <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_HouseNo" runat="server" required type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

     <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Name of Building </span></span>
                 </label>
                    <input id="txt_BldgName" runat="server"   type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

    <div class="form-group col col-md-2" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Lot No. </span></span>
                 </label>
                    <input id="txt_LotNo" runat="server"  type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

 <div class="form-group col col-md-2" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Block No. </span></span>
                 </label>
                    <input id="txt_BlockNo" runat="server"  type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>



<div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Barangay <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_Brgy" runat="server" required type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>
    
 <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Street <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_Street" runat="server" required type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Subdivision </span></span>
                 </label>
                    <input id="txt_Subd" runat="server"  type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

      
 <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">City/Municipality <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_CityMunicipality" runat="server" required type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

<div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2"> Province<b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_Province" runat="server" required type="text" class="form-control CH-Size-New uppercase-input"  />
             </div>               
        </div>

<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Zip Code <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_Zip" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
 </div>
<%--<div id="div_CorpCoopPart" class="MainDiv">
  
    <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp   Name of President/Officer in Charge</strong></div>
    <br />
     <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Surname <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_CorpCoopPart_Lname" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Given Name <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_CorpCoopPart_Fname" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Middle Name<b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_CorpCoopPart_Mname" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-2" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Suffix <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_CorpCoopPart_Suffix" runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

    <div class="form-group col col-md-5">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Nationality <b style="color:red">*</b> </span></span>
                 </label>
                    <label>    
        &nbsp <input type="radio" name="rad_Nationality" id="rad_Filipino" value="Filipino" checked onchange="chkNationality();" />   
        Filipino
    </label> 
    <label>    
        &nbsp <input type="radio" name="rad_Nationality" id="rad_Foreign" value="Foreign" onchange="chkNationality();" />   
        Foreign
    </label> 
             </div>               
        </div>
    <input type="hidden" id="hdn_Nationality"/>
  
</div>--%>
<div id="div_Operation" class="MainDiv">
   
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp  Business Operation</strong></div>
    <br />
     <div class="form-group col col-md-6" style="display:none">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Business Area (in sq.m) <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_BusArea" runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-5" style="display:none">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Total Floor Area (in sq.m) <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_TotFlrArea" runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. of Male Employees<b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_NoMaleEmp" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. of Female Employees <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_NoFemaleEmp" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. Employees Residing within <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_NoResidingEmp" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. of Delivery Van/Truck (if applicable)</span></span>
                 </label>
                    <input id="txt_DelVanTruck" runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. of Delivery Motorcycle (if applicable)  </span></span>
                 </label>
                    <input id="txt_DelMotor" runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
</div>




    <div>
         <label style="float:left;position:relative" id="lbl_chcklessor">    
            &nbsp <input  id="chk_lessor" type="checkbox" onchange="chkLessorDiv(this.checked)" />   
           Check if business establishment is rented
        </label> <br /><br />         
    </div>

</div>

       <input type="hidden" id="hdn_lessor_div" runat="server" />

       <script>

           function chkLessorDiv(val) {
               document.getElementById('<%= hdn_lessor_div.ClientID%>').value = val;
               if (val == true) {
                   document.getElementById('div_lessor').style.display = "block"
               }else if (val == false) {
                   document.getElementById('div_lessor').style.display = "none"
               }
           }

       </script>


<div id="div_lessor" class="MainDiv" style="display:none" >   
    
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp Lessor Information</strong></div>
    <br />
      
     <div class="form-group col col-md-4" style="display:inline-block;">
                                    <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Last Name <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txtlname" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

     <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">First Name <b style="color:red">*</b>  </span></span>
                 </label>
                    <input id="txtfname" runat="server"   type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

    <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Middle Name </span></span>
                 </label>
                    <input id="txtlmame" runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>





<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Bldg </span></span>
                 </label>
                    <input id="txtbldg" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    
 <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Street <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txtstrt" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">City <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txtcity" runat="server"  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

      
 <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Barangay <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txtbrgy" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2"> Subdivision </span></span>
                 </label>
                    <input id="txtsubd" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Province <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txtprovince" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>



     <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Tel No.</span></span>
                 </label>
                    <input id="txtTelNo" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2"> Email </span></span>
                 </label>
                    <input id="txtEmail" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>



 <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Area </span></span>
                 </label>
                    <input id="txtP_area" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2"> Rent </span></span>
                 </label>
                    <input id="txtP_rent" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Rent Date </span></span>
                 </label>
                    <input id="txtP_rentdate" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>


 <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Supervisor/Caretaker  </span></span>
                 </label>
                    <input id="txtP_admin" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2"> Rent Term Date</span></span>
                 </label>
                    <input id="txtP_renttermdate" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

<div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Permit No.  </span></span>
                 </label>
                    <input id="txtP_permitno" runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>






 </div>



<div id="div_Other" class="MainDiv">   
    
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp  Nature of Business</strong>&nbsp
        <a href="#ModalNature" data-target="#ModalNature" data-toggle="modal" class="fa fa-question-circle" style="  text-decoration: none;font-size:15px;color:white"></a>
         For Rental or Lessor, please include number of units.
    </div>      
     
        <div id="NatureHTML" runat="server" >

        </div>
    <input type="button" class="btn btn-secondary btn-sm col col-md-5"  runat="server" value="Change Nature of Business" id="btnChangeNature"/>
     <br />
<div style="text-align:right;overflow:scroll;" id="divInputNature" runat="server" >
<table id="myTable">

<tr id="tr01" style="font-size: small">
<th>Description</th>    <th>Product / Services</th> <th>No. of Units</th>   <th>Capital / Asset (Php)</th>    <th>Area (㎡)</th>    <th></th>   
</tr>
<tr>
<td><input id="txtDesc" runat="server" type="text" class="form-control CH-Size-New uppercase-input"/></td>
<td><input id="txtPrdctSvcs" runat="server" type="text" class="form-control CH-Size-New uppercase-input"/></td>
<td><input id="txtUnits" runat="server" type="text" value="0" class="form-control CH-Size-New" onkeypress="return isNumberKey(event)"/></td>
<td><input id="txtCapital" runat="server" type="text" class="form-control CH-Size-New" onkeypress="return isNumberKey(event)"/></td>
<td><input id="txtArea" runat="server" type="text" class="form-control CH-Size-New" onkeypress="return isNumberKey(event)"/></td>
<td><input type="button" onclick="AddNature()" value="+"/></td>
</tr>
<tr style="text-align:right;color:black">
<td colspan="3" >TOTAL</td>
<td id="txt_Capital" runat="server">0.00</td>
<td id="txt_Area" runat="server">0.00</td>        
</tr>

</table>
 </div>
    <br />
   <%-- <div class="form-group col col-md-5"  style="display:  inline-grid;">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Total Capital (Php) </span></span>
                 </label>
                   <asp:UpdatePanel runat="server">
                       <ContentTemplate>
                             <input id="txt_Capital" runat="server"  type="text" style="text-align:right"  value="0.00" readonly class="form-control CH-Size-New"  />
            
                       </ContentTemplate>
                   </asp:UpdatePanel>
                  
             </div>               
        </div>--%>
       

        <div style="display:none">
    

     <div class="form-group col col-md-6"  style="display: inline-grid;">
      <div>           

                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Nature of Business <b style="color:red">*</b> </span></span>
                 </label>            
                    <textarea id="txt_Nature" runat="server" style="height:70px" placeholder="Describe here the products being sold or services offered; or goods being manufactured or distributed." class="form-control CH-Size-New" required></textarea>
             </div>               
        </div>

     

          <hr />
      <div class="form-group col col-md-5"  style="display: inline-grid;" >
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Owned? <b style="color:red">*</b> </span></span>
                 </label>
          <asp:UpdatePanel runat="server">
              <ContentTemplate>
                    <select runat="server" id="cmb_Owned" onchange="chkOwned(this.value);" class="form-control">                                   
                           <option selected value="0">NO</option>   
                           <option value="1">YES</option>                          
                  </select>  
              </ContentTemplate>
          </asp:UpdatePanel>
             </div>
           </div>  
         <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Tax Declaration Number <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_TDN" disabled runat="server" type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
        
              <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">Property Identification Number <b style="color:red">*</b> </span></span>
                 </label>
                    <input id="txt_PIN" disabled  runat="server" required type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>

            <hr />
     <div class="form-group col col-md-5"  style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2" style="background-color:transparent;">
                       <span><span class="m-2">Do you have tax incentive from any Government Entity? <b style="color:red">*</b> </span></span>
                 </label>
          <asp:UpdatePanel runat="server">
              <ContentTemplate>
<select required runat="server" id="cmb_Incentive" onchange="chkIncentive(this.value)" class="form-control">                                   
                           <option selected value="0">NO</option>   
                           <option value="1">YES</option>                          
                  </select>  
                  </ContentTemplate>
          </asp:UpdatePanel>
                   
             </div>               
        </div>
   
    <div class="form-group col col-md-6"  style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">if YES, Please upload your certificate<b style="color:red">*</b> </span></span>
                 </label>              
                      
               <input  class="form-control CH-Size-New" disabled id="up_Incentive" name="up_Incentive" runat="server" required type="file"  />
        
      </div>               
        </div>
    </div>
    

   <div class="MainDiv" runat="server" id="divUploaded" style="display:none;">   
       <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp  Uploaded Attachments</strong></div>          
         <asp:GridView ID="GVSubmittedReqs" runat="server" CssClass="mGrid col-lg-12 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
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
       <i>Re-uploading will require you to upload AGAIN all Mandatory Requirements</i>
       <input type="button" class="btn btn-secondary btn-sm col col-md-5"  runat="server" value="Re-upload/Change Attachments" id="btnReUpload"/>
       
 </div>
  <br />
<div class="MainDiv" runat="server" id="divUpload">   
    
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp  Documentary Requirements</strong></div>  
    
    <br />
     <div class="instruct">
                    <ul style="padding:0px 0px 0px 35px;">
                        <li> Valid image file (PDF, JPG, JPEG, PNG, BMP)</li>
                        <li> Total file size must not exceed to 10MB </li>
                    </ul>                     
                </div>
              
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

        
            <asp:GridView ID="_GVRequirements" runat="server" CssClass="mGrid col-lg-12 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11"
                OnPageIndexChanging="datagrid_PageIndexChanging_GVReq" PageSize="100">
                <Columns>          
                    <asp:TemplateField HeaderText="ReqCode" visible="false" >
                        <ItemTemplate>
                           <asp:Label ID="lbl_ReqCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                           
                     <asp:TemplateField HeaderText="Requirement" HeaderStyle-Width="50%" ItemStyle-HorizontalAlign="Left" >
                        <ItemTemplate>
                            <label><%# Eval("REQDESC")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="COMPLIANT" HeaderStyle-Width="20%" Visible="false" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>
                            <label><%# Eval("WEBCOMPLIANT")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>                  

                    <asp:TemplateField HeaderText="Upload" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>                
                            <input type="file" accept=".pdf,.jpg, .png, .jpeg,  .bmp|image/*" class="upload-file upl" id="REQ<%# Eval("REQCODE")%>" name="file_<%# Eval("WEBCOMPLIANT")%>" onclick="initialize('<%# Eval("REQCODE")%>')" onchange="do_browse(this.id,'<%# Eval("REQCODE")%>',this.files[0].size)" />
                            
                              </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="File Size" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>                
                             <label id="FS<%# Eval("REQCODE")%>"></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            </div> 
</div>
    <br />
    <div class="MainDiv" id="divRegReq" runat="server" style="display:none">   
    
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp  Regulatory Requirements</strong></div>      

        
          <asp:GridView ID="Grid_RegReq" runat="server" CssClass="mGrid Table-MobileView" 
              AllowSorting="true" AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" 
              RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
              HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="10" HeaderStyle-Font-Size="11" AllowPaging="True"
              OnPageIndexChanging="datagrid_PageIndexChanging_RegReq" PageSize="100">
          
                            <Columns>

                <asp:TemplateField HeaderText="OFCCODE" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_OFCCODE" runat="server" Text='<%# Eval("OFCCODE")%>' />
                  </ItemTemplate>
              </asp:TemplateField>     

             <asp:TemplateField HeaderText="OFFICE" >
                  <ItemTemplate>
                      <asp:Label ID="lbl_OFCDESC" runat="server" Text='<%# Eval("OFCDESC")%>' />
                  </ItemTemplate>
              </asp:TemplateField>   
              
                 <asp:TemplateField HeaderText="REQCODE" Visible="false">
                  <ItemTemplate>
                      <asp:Label ID="lbl_REQCODE" runat="server" Text='<%# Eval("REQCODE")%>' />
                  </ItemTemplate>
              </asp:TemplateField>      

                <asp:TemplateField HeaderText="Requirement Description">
                  <ItemTemplate>
                      <asp:Label ID="lbl_REQDESC" runat="server" Text='<%# Eval("REQDESC")%>' />
                  </ItemTemplate>
              </asp:TemplateField>                 

              <asp:TemplateField HeaderText="Upload File" >
                  <ItemTemplate>
                        <input id="File_up" runat="server" type="file" class="form-control CH-Size-New"  />                                       
                  </ItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField HeaderText="Status" >
                  <ItemTemplate>
                        <asp:Label ID="_oLabelStatus" Text='<%# Eval("Status")%>' runat="server"/>
                  </ItemTemplate>
              </asp:TemplateField>

              <asp:TemplateField HeaderText="Remarks" >
                  <ItemTemplate>
                    <asp:Label ID="_oLabelRemarks" Text='<%# Eval("Remarks")%>' runat="server"/>
                  </ItemTemplate>
              </asp:TemplateField>
                            </Columns>

                        </asp:GridView>   

   

</div>
        <hr />         
         <div class="form-group col col-md-6" style="display:inline-block">    
             <input name="btnSubmit" id="btnSubmit" type="button" onclick="check_required();" value="Submit" class="btn btn-primary btn-sm col col-md-5"  style="display: inline-block" />
                
             <asp:UpdatePanel runat="server">
                 <ContentTemplate>
                        <input name="btnNewSubmit" id="btnNewSubmit" runat="server" type="button" value="Submit" class="btn btn-primary btn-sm col col-md-5"  style="display:none" />
                 </ContentTemplate>
             </asp:UpdatePanel>       
            
        </div>       



       <br />
   


                              </div>
       </div>
                         </div>   
                    </div>
               </div>
           </center>
    </div>

    <input type="hidden" id="hdnSame" runat="server" />
    <input type="hidden" runat="server" id="hdntotFS" />
    <input type="hidden" runat="server" id="hdnAttachment" />
    <textarea id="taAttachment" style="display: none"></textarea>

    <input type="hidden" id="hdnReSubmit" runat="server" />
    <input type="hidden" id="hdnReUpload" runat="server" />
    
    
    <div id="txHTML"></div>

    <script type="text/javascript">   

        function date_OnFocus(){
            if( document.getElementById('<%= txt_DateEsta.ClientID%>').value == 'mm/dd/yyyy' ||  document.getElementById('<%= txt_DateEsta.ClientID%>').value == '' ){
                document.getElementById('<%= txt_DateEsta.ClientID%>').setAttribute("type", "date"); 
            } ;
            
        }

        function date_OnBlur(inputDate){
            var date=new date(inputDate);
            var month = (date.getMonth()+1).toString().padStart(2,'0');
            var day = date.getDate().toString().padStart(2,'0');
            var year = date.getFullYear().toString;
            var formattedDate = month + '/' + day + '/' + year;

            document.getElementById('<%= txt_DateEsta.ClientID%>').setAttribute("type", "text"); 
            document.getElementById('<%= txt_DateEsta.ClientID%>').value=formattedDate;
        }
      


        $("input").on({
            keydown: function (e) {
                if (e.key === ";" || e.key === ":") { // disallow semicolon
                    return false;
                }
            }
        });            
          
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

        function openModal() {
            $('#NewBusReq').modal('show');
        }
        function openModalSubmit() {
            $('#ModalSubmit').modal('show');
        }
              

        function chkOwned(val) {       
            if (val == 1) {
                document.getElementById('<%= txt_TDN.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_TDN.ClientID%>').required = true;
                  document.getElementById('<%= txt_PIN.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_PIN.ClientID%>').required = true;
              }
              else {
                  document.getElementById('<%= txt_TDN.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_TDN.ClientID%>').required = false;
                  document.getElementById('<%= txt_TDN.ClientID%>').value = '';
                  document.getElementById('<%= txt_PIN.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_PIN.ClientID%>').required = false;
                  document.getElementById('<%= txt_PIN.ClientID%>').value = '';
              }
         
          }

          function chkIncentive(val) {
              alert(val);
              if (val == 1) {
                  document.getElementById('<%= up_Incentive.ClientID%>').disabled = false;
                  document.getElementById('<%= up_Incentive.ClientID%>').required = true;
                 
              }
              else {
                  document.getElementById('<%= up_Incentive.ClientID%>').disabled = true;
                  document.getElementById('<%= up_Incentive.ClientID%>').required = false;
                 
              }

          }

          function chkSameAddress(val) {
              document.getElementById('<%= hdnSame.ClientID%>').value = val;
              if (val == true) {

                  document.getElementById('<%= txt_HouseNo.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_BldgName.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_LotNo.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_BlockNo.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_Brgy.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_Street.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_Subd.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_CityMunicipality.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_Province.ClientID%>').disabled = true;
                  document.getElementById('<%= txt_Zip.ClientID%>').disabled = true;

                  document.getElementById('<%= txt_HouseNo.ClientID%>').value =
                  document.getElementById('<%= txt_B_HouseNo.ClientID%>').value;             

                  document.getElementById('<%= txt_BldgName.ClientID%>').value =
                 document.getElementById('<%= txt_B_BldgName.ClientID%>').value;

                  document.getElementById('<%= txt_LotNo.ClientID%>').value =
                 document.getElementById('<%= txt_B_LotNo.ClientID%>').value;

                  document.getElementById('<%= txt_BlockNo.ClientID%>').value =
                 document.getElementById('<%= txt_B_BlockNo.ClientID%>').value;

                  document.getElementById('<%= txt_Brgy.ClientID%>').value =
                  document.getElementById('<%= cmb_Brgy.ClientID%>').options[document.getElementById('<%= cmb_Brgy.ClientID%>').selectedIndex].text;

                  document.getElementById('<%= txt_Street.ClientID%>').value =
                  document.getElementById('<%= cmb_Street.ClientID%>').options[document.getElementById('<%= cmb_Street.ClientID%>').selectedIndex].text;

                 document.getElementById('<%= txt_Subd.ClientID%>').value =
                document.getElementById('<%= txt_B_Subd.ClientID%>').value;

                  document.getElementById('<%= txt_CityMunicipality.ClientID%>').value =
               document.getElementById('<%= txt_B_CityMunicipality.ClientID%>').value;

                  document.getElementById('<%= txt_Province.ClientID%>').value =
               document.getElementById('<%= txt_B_Province.ClientID%>').value;

                  document.getElementById('<%= txt_Zip.ClientID%>').value =
               document.getElementById('<%= txt_B_ZipCode.ClientID%>').value;

                  
         
              }
           
              else if (val == false) {
                  document.getElementById('<%= txt_HouseNo.ClientID%>').value ='';

                  document.getElementById('<%= txt_BldgName.ClientID%>').value ='';

                  document.getElementById('<%= txt_LotNo.ClientID%>').value ='';

                  document.getElementById('<%= txt_BlockNo.ClientID%>').value ='';

                  document.getElementById('<%= txt_Brgy.ClientID%>').value ='';

                  document.getElementById('<%= txt_Street.ClientID%>').value ='';

                  document.getElementById('<%= txt_Subd.ClientID%>').value ='';

                  document.getElementById('<%= txt_CityMunicipality.ClientID%>').value ='';

                  document.getElementById('<%= txt_Province.ClientID%>').value ='';

                  document.getElementById('<%= txt_Zip.ClientID%>').value = '';

                  document.getElementById('<%= txt_HouseNo.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_BldgName.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_LotNo.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_BlockNo.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_Brgy.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_Street.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_Subd.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_CityMunicipality.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_Province.ClientID%>').disabled = false;
                  document.getElementById('<%= txt_Zip.ClientID%>').disabled = false;
              }

      }

            

      function onlyNumbers(evt) {

          var e = event || evt; // for trans-browser compatibility
          var charCode = e.which || e.keyCode;

          if (charCode < 48 || charCode > 57)
              return false;

          return true;

      }
      function onlyNumbersDash(evt) {
          var e = event || evt; // for trans-browser compatibility
          var charCode = e.which || e.keyCode;

          if ((charCode < 45 || charCode > 45) && (charCode < 48 || charCode > 57))
              return false;

          return true;

      }

      function addHyphen(element) {
          let ele = document.getElementById(element.id);
          ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

          let finalVal = ele.match(/.{1,3}/g).join('-');
          document.getElementById(element.id).value = finalVal;
      }

      function AddNature() {
          if(document.getElementById("txtDesc").value.length > 0 &&
              document.getElementById("txtPrdctSvcs").value.length > 0 &&
              document.getElementById("txtUnits").value.length > 0 &&
              parseFloat(document.getElementById("txtArea").value) > 0 &&
              parseFloat(document.getElementById("txtCapital").value) > 0){
             

              var table = document.getElementById("myTable");
              var row = table.insertRow(table.rows.length-1);
              var cell_Desc = row.insertCell(0);
              var cell_PrdctSvcs = row.insertCell(1);
              var cell_Units = row.insertCell(2);
              var cell_Capital = row.insertCell(3);
              var cell_Area = row.insertCell(4);
              var cell_Remove = row.insertCell(5);
              var n;
              var parts;
              var num;
              cell_Desc.innerHTML = document.getElementById("txtDesc").value;
              cell_PrdctSvcs.innerHTML = document.getElementById("txtPrdctSvcs").value;
              cell_Units.innerHTML = document.getElementById("txtUnits").value;
            
              n = document.getElementById("txtCapital").value;
              parts = (+n).toFixed(2).split(".");
              num = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (+parts[1] ? "." + parts[1] : "");
              cell_Capital.innerHTML = num;

              n = document.getElementById("txtArea").value;
              parts = (+n).toFixed(2).split(".");
              num = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (+parts[1] ? "." + parts[1] : "");                
              cell_Area.innerHTML = num

              cell_Remove.innerHTML = "<input type='button' value='-' onclick='deleteRow(this)'/>";
              cell_Capital.style.textAlign = "right";
              cell_Area.style.textAlign = "right";

              var IntCap = parseFloat(document.getElementById('<%= txt_Capital.ClientID%>').innerText.replaceAll(',', ''));
              var IntAdd = parseFloat(cell_Capital.innerHTML.replaceAll(',', ''));
              var IntSum = parseFloat(IntCap) + parseFloat(IntAdd);
              n = IntSum;
              parts = (+n).toFixed(2).split(".");
              num = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (+parts[1] ? "." + parts[1] : "");
              IntSum = num;
              document.getElementById('<%= txt_Capital.ClientID%>').innerText = IntSum;

              var IntArea = parseFloat(document.getElementById('<%= txt_Area.ClientID%>').innerText.replaceAll(',', ''));
              var IntAddArea = parseFloat(cell_Area.innerHTML.replaceAll(',', ''));
              var IntSumArea = parseFloat(IntArea) + parseFloat(IntAddArea);
              n = IntSumArea;
              parts = (+n).toFixed(2).split(".");
              num = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (+parts[1] ? "." + parts[1] : "");
              IntSumArea = num;
              document.getElementById('<%= txt_Area.ClientID%>').innerText = IntSumArea;
              
                  document.getElementById("txtDesc").value = '';
                  document.getElementById("txtPrdctSvcs").value = '';
                  document.getElementById("txtUnits").value = '';
                  document.getElementById("txtCapital").value = '';
                  document.getElementById("txtArea").value = '';
                  getHTML();
              }
          }
          function deleteRow(btn) {
              var row = btn.parentNode.parentNode;           
              var ctr = $(row).find('td:eq(3)').text();
              var ctr2 = $(row).find('td:eq(4)').text();

              var IntCap = parseFloat(document.getElementById('<%= txt_Capital.ClientID%>').innerHTML.replaceAll(',', ''));
          var IntMinus = parseFloat(ctr.replaceAll(',', ''));
          var IntDiff = parseFloat(IntCap) - parseFloat(IntMinus);
          n = IntDiff;
          parts = (+n).toFixed(2).split(".");
          num = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (+parts[1] ? "." + parts[1] : "");
          IntDiff = num;
          document.getElementById('<%= txt_Capital.ClientID%>').innerText = IntDiff;

              var IntArea = parseFloat(document.getElementById('<%= txt_Area.ClientID%>').innerHTML.replaceAll(',', ''));
          var IntMinusArea = parseFloat(ctr2.replaceAll(',', ''));
          var IntDiffArea = parseFloat(IntArea) - parseFloat(IntMinusArea);
          n = IntDiffArea;
          parts = (+n).toFixed(2).split(".");
          num = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (+parts[1] ? "." + parts[1] : "");
          IntDiffArea = num;
          document.getElementById('<%= txt_Area.ClientID%>').innerText = IntDiffArea;

              row.parentNode.removeChild(row);
              getHTML();
          }

          function getHTML() {            
              var txTable = document.getElementById("myTable").innerHTML;
              txTable = txTable.replaceAll('tbody', 'table');
              txTable = txTable.replaceAll('<td><input name="ctl00$ContentPlaceHolder1$txtDesc" type="text" id="txtDesc" class="form-control CH-Size-New"></td>', '');
              txTable = txTable.replaceAll('<td><input name="ctl00$ContentPlaceHolder1$txtPrdctSvcs" type="text" id="txtPrdctSvcs" class="form-control CH-Size-New"></td>', '');
              txTable = txTable.replaceAll('<td><input name="ctl00$ContentPlaceHolder1$txtUnits" type="text" id="txtUnits" value="0" class="form-control CH-Size-New" onkeypress="return isNumberKey(event)"></td>', '');
              txTable = txTable.replaceAll('<td><input name="ctl00$ContentPlaceHolder1$txtDesc" type="text" id="txtDesc" class="form-control CH-Size-New"></td>', '');
              txTable = txTable.replaceAll('<td><input name="ctl00$ContentPlaceHolder1$txtCapital" type="text" id="txtCapital" class="form-control CH-Size-New" onkeypress="return isNumberKey(event)"></td>', '');
              txTable = txTable.replaceAll('<td><input name="ctl00$ContentPlaceHolder1$txtArea" type="text" id="txtArea" class="form-control CH-Size-New" onkeypress="return isNumberKey(event)"></td>', '');
              txTable = txTable.replaceAll('<td><input type="button" value="-" onclick="deleteRow(this)"></td>', '');
              txTable = txTable.replaceAll('<td><input type="button" onclick="AddNature()" value="+"></td>', '');
              txTable = txTable.replaceAll('style="text-align: right;"', '')
              txTable = txTable.replaceAll('<table', '<table style="border-collapse: collapse; width: 100%;border: 1px solid #ddd;padding: 8px;"')
              txTable = txTable.replaceAll('<td', '<td style="border: 1px solid #ddd;padding: 8px;"')                 
              txTable = txTable.replaceAll('<th>Action</th>', '');
              txTable = txTable.replaceAll('<td><input type="button" value="Delete" onclick="deleteRow(this)"></td>', '');
              txTable = txTable.replaceAll('<td><input type="button" onclick="AddNature()" value="Add"></td>', '');

              // document.getElementById("txHTML").innerText = txTable;
        
              document.getElementById('<%= txt_Nature.ClientID%>').value = txTable;
          
          }

          function isNumberKey(evt) {
              var charCode = (evt.which) ? evt.which : evt.keyCode;
              if (charCode != 46 && charCode > 31
                && (charCode < 48 || charCode > 57))
                  return false;

              return true;
          }
        
        
          function check_required() {
              var x = document.getElementById("divChecker").querySelectorAll("input");
              var complete=false;
              for (let i = 0; i < x.length; i++) {
                  if (x[i].checkValidity() == false) {
                      x[i].reportValidity();
                      complete = false;
                      break;
                  }
                  complete = true;
              }
              // alert(complete);
              if (complete == true) {
                  do_Save();                 
              }
          }
          function do_browse(ID, ReqCode, FS) {

              var fileName = document.getElementById(ID).value.toLowerCase();
              if (!fileName.endsWith('.pdf') && !fileName.endsWith('.jpg') && !fileName.endsWith('.png') && !fileName.endsWith('.jpeg') && !fileName.endsWith('.bmp')) {
                  alert('Invalid file selected.');
                  document.getElementById(ID).value = '';
                  return false;
              }

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
          function fileSizeSI(size) {
              var e = (Math.log(size) / Math.log(1e3)) | 0;
              return +(size / Math.pow(1e3, e)).toFixed(2) + ' ' + ('kMGTPEZY'[e - 1] || '') + 'B';
          }
       
          function _compliant() {
              var stat;
              var reUpload = document.getElementById('<%= hdnReUpload.ClientID%>').value;
              if (document.getElementsByName("file_MANDATORY").length == 0 || reUpload == 1){              
                  stat=true;
                  if (Exceeded==0){                                          
                      for(var i=0;i<document.getElementsByClassName("upl").length;i++){
                          if (document.getElementsByClassName("upl")[i].value !== ''){
                              var ReqCode = document.getElementsByClassName("upl")[i].id;
                              var ReqCode = ReqCode.replace('REQ','');                        
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
                            for(var j=0;j<document.getElementsByClassName("upl").length;j++){
                                if (document.getElementsByClassName("upl")[j].value !== ''){
                                    var ReqCode = document.getElementsByClassName("upl")[j].id;
                                    var ReqCode = ReqCode.replace('REQ','');
                                  
                                    document.getElementById('<%= hdnAttachment.ClientID%>').value  += ReqCode + ';' ;
                                    document.getElementById('taAttachment').innerText  += ReqCode + ';' ;
                                }                       
                            }
                        }    
                        console.log(document.getElementById('taAttachment').innerText);
                    }              
                }      
            }
                 
            return stat
        }


        function do_Save() {
            if(_NoB()){
                console.log("_NoB : OK")
                if (_compliant()){
                    console.log("_compliant : OK")
                    if (Exceeded == 0){ 
                        document.getElementById('btnSubmit').disabled = true;
                        document.getElementById('btnSubmit').value = 'Submitting ... ';
                        document.getElementById('<%= btnNewSubmit.ClientID%>').click(); 
                    }
                    else
                    {alert('Max File Size Exceeded.');}
                   
                }
                else{

                    alert('Please Upload MANDATORY Requirements');
                }
            }
            else{
                alert('Please Complete Nature of Business Entry');
            }           
        }

        function _NoB(){
            var stat;          
            var Area = parseFloat(document.getElementById('<%= txt_Area.ClientID%>').innerText);
              var Capital = parseFloat(document.getElementById('<%= txt_Capital.ClientID%>').innerText);
              console.log('Total Area : ' + Area);
              console.log('Total Capital : ' + Capital);
              if(  Area > 0 && Capital > 0){
                  stat=true;
                  console.log('stat : ' + stat);
              }

              else{
                  stat=false;
                  console.log('stat : ' + stat);
              }                 
              return stat
          }

    </script>

    <script>
        function convertAllToUpperCase() {
            var inputs = document.getElementsByClassName('uppercase-input');
            for (var i = 0; i < inputs.length; i++) {
                inputs[i].addEventListener('input', function() {
                    this.value = this.value.toUpperCase();
                });
            }
        }

        // Call the function when the DOM is loaded
        document.addEventListener('DOMContentLoaded', function() {
            convertAllToUpperCase();
        });
    </script>

   <script>

       function toggleInput() {
           alert('1');
           var selectValue = document.getElementById('<%= cmb_OwnershipType.ClientID%>').value;
           alert(selectValue);

           var inputElement = document.getElementById('_oDivOwnerName');

           if (selectValue == 'S' ) {
               inputElement.style.display = 'block'; // Show the input
           } else  {
               inputElement.style.display = 'none'; // Hide the input
           }
       }
   </script>

</asp:Content>