<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="NewBP_Application.aspx.vb" Inherits="SPIDC.NewBP_Application" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
            function openModal() {
                $('#NewBusReq').modal('show');
            }

            function openModalSubmit() {
                $('#ModalSubmit').modal('show');
            }

            function do_submit() {
                alert('a');
                document.getElementById('<%= btn_Submit.ClientID%>').click();
            }

            function do_embed(ctr) {
                var parent = $('embed#embed_Here').parent();
                var newElement = "<embed id='embed_Here' type='text/html' src='#'  width='100%' height='600px' style='object-fit: contain;'>";
                $('embed#embed_Here').remove();
                parent.append(newElement);

                switch (ctr) {
                    case 1:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_1.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_1.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'Owner Picture';
                        break;
                    case 2:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_2.ClientID%>').value;
                             document.getElementById('embed_Here').type = document.getElementById('<%= hdn_2.ClientID%>').value.split(';')[0].split(':')[1];
                             document.getElementById('ModalFileName').innerHTML = 'Business Establishment Picture';
                             break;
                    case 3:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_3.ClientID%>').value;
                             document.getElementById('embed_Here').type = document.getElementById('<%= hdn_3.ClientID%>').value.split(';')[0].split(':')[1];
                             document.getElementById('ModalFileName').innerHTML = 'Business Map Location';
                             break;
                    case 4:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_4.ClientID%>').value;
                             document.getElementById('embed_Here').type = document.getElementById('<%= hdn_4.ClientID%>').value.split(';')[0].split(':')[1];
                             document.getElementById('ModalFileName').innerHTML = 'Application Form with Signature';
                             break;
                    case 5:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_5.ClientID%>').value;
                             document.getElementById('embed_Here').type = document.getElementById('<%= hdn_5.ClientID%>').value.split(';')[0].split(':')[1];
                             document.getElementById('ModalFileName').innerHTML = 'DTI/SEC/CDA Registration';
                             break;
                    case 6:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_6.ClientID%>').value;
                             document.getElementById('embed_Here').type = document.getElementById('<%= hdn_6.ClientID%>').value.split(';')[0].split(':')[1];
                             document.getElementById('ModalFileName').innerHTML = 'TIN Registration';
                             break;
                }
                               
               

            }
    </script>  
       <div class="container">
           <center>
               <div class="col-md-10">
           

     

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
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Public Liability Insurance SPA for Authorized Representatives with I.D.</li>
                </ul>                  
                            </div>
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
           </center>
          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->

   <!-- Modal View Attachment Form -->
      <div id="ModalSubmit" class="modal fade" >
        <div class="modal-dialog modal-lg">
          <div class="modal-content">
            <div class="modal-header  bg-primary">
              <h4 class="modal-title text-white"> Application Submitted</h4>            
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
                   <center>
                   Your Application Form has been submitted for further verification. Thank you for using our Web Service Portal.
           <a href="Account.aspx">Return to Home Page</a>
                   </center>
          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


                   
    
      <div class="container MainDiv">
           <center>
               <div class="col-md-12">
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
                        <li> Maximum of 10mb file size per file </li>
                        <li> Multiple page documents must be compiled into single PDF file or archive(.rar, .zip) before uploading.  </li>
                        <li > If you mistakenly uploaded the wrong file, just browse and upload again to replace the previous file. </li>
                    </ul>                     
                </div>
<br />
          
         <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp Business Information</strong> </div>
     
<form method="post" action="#">
  

       <table id="Information">
            <tr>
    <td style="width:35%">Ownership Type<b style="color:red">*</b></td>
    <td>   <select required id="td_OwnershipType" class="form-control">   
                      <option value="Single" selected>Single Proprietorship</option>    
                      <option value="Cooperative">Cooperative</option>  
                      <option value="Corporation">Corporation</option>                     
                      <option value="Partnership">Partnership</option>                                                        
                  </select></td>
   
  </tr>

           


  <tr>
    <td >Business Trade Name<b style="color:red">*</b></td>
    <td> <input type="text"  runat="server" id="td_Bus_Name" name="td_Bus_Name" class="form-control CH-Size-New" required/></td>
   
  </tr>
  <tr>
    <td>Capital<b style="color:red">*</b></td>
    <td> <input runat="server" id="td_capital" name="td_Capital" type="text" class="form-control CH-Size-New" required/></td>
  </tr>
  <tr>
    <td>Area<b style="color:red">*</b></td>
    <td> <input type="text" runat="server" id="td_Area" name="td_Area" class="form-control CH-Size-New" required/></td>
 
  </tr>
  <tr>
    <td>Business Address<b style="color:red">*</b></td>
   <td> <input type="text" runat="server" id="td_Bus_Address" name="td_Bus_Address" class="form-control CH-Size-New" required/></td>
  </tr>
  <tr>
    <td>Barangay <b style="color:red">*</b></td>
    <td> 
        <select class="form-control CH-Size-New" runat="server" id="td_Bus_Brgy" name="td_Bus_Brgy" required>
            <option>1</option>
            <option>2</option>
            <option>3</option>
        </select>
    </td>
 
  </tr>

            <tr>
    <td>Street <b style="color:red">*</b></td>
    <td> 
        <select class="form-control CH-Size-New" runat="server" id="td_Bus_Street" name="td_Bus_Street" required>
            <option>1</option>
            <option>2</option>
            <option>3</option>
        </select>
    </td>
 
  </tr>
  <tr>
    <td>DTI/SEC/CDA Registration No.<b style="color:red">*</b></td>
     <td> <input type="text" runat="server" id="td_DtiSecCda_No" name="td_DtiSecCda_No" class="form-control CH-Size-New" required/></td>
 
  </tr>
  <tr>
    <td>TIN No.<b style="color:red">*</b></td>
    <td> <input type="text" runat="server" id="td_TIN_No" name="td_TIN_No" class="form-control CH-Size-New" required/></td>
 
  </tr>
  <tr>
    <td>SSS No.<b style="color:red">*</b></td>
     <td> <input type="text" runat="server" id="td_SSS_No" name="td_SSS_No" class="form-control CH-Size-New" required/></td>
  
  </tr>
 
  <tr>
    <td>Nature of Business<b style="color:red">*</b></td>
     <td>    <textarea runat="server" id="td_Bus_Nature" name="td_Bus_Nature" style="height:70px" placeholder="Describe here the products being sold or services offered; or goods being manufactured or distributed" class="form-control CH-Size-New" required></textarea>
         </td>
  </tr>
</table>

<br />
          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp Taxpayer's Information</strong> 
              </div>

                                    <table id="Information">


  <tr>
    <td style="width:35%">Surame<b style="color:red">*</b></td>
   <td> <input type="text" runat="server" id="td_LName" name="td_LName" class="form-control CH-Size-New" required/></td>
  </tr>

 <tr>
    <td>First Name<b style="color:red">*</b></td>
    <td> <input type="text" runat="server" id="td_FName" name="td_FName" class="form-control CH-Size-New" required/></td>
  </tr>

 <tr>
    <td>Middle Name</td>
  <td> <input type="text" runat="server" id="td_MName" name="td_MName" class="form-control CH-Size-New" /></td>
  </tr>

   <tr>
    <td>Tel/Mobile No.<b style="color:red">*</b></td>
    <td> <input type="text" runat="server" id="td_Contact_No" name="td_Contact_No" class="form-control CH-Size-New" required/></td>
  </tr>

  <tr>
    <td>Resident</td>
    <td>
        <label >    
        &nbsp <input type="checkbox" runat="server" id="td_Resident" name="td_Resident"  />   
       I am a resident of LGU
    </label>
    </td>

       
  </tr>
           
  <tr>
    <td>Address<b style="color:red">*</b></td>
     <td>  <textarea runat="server" id="td_Own_Address" name="td_Own_Address"   style="height:70px" placeholder="House#, Street, Subdivision" class="form-control CH-Size-New" required></textarea>
        </td>
  </tr>
           
  <tr>
    <td>Barangay<b style="color:red">*</b></td>
     <td>    <select runat="server" id="td_Own_Brgy" name="td_Own_Brgy" class="form-control CH-Size-New" required>
            <option>1</option>
            <option>2</option>
            <option>3</option>
        </select>

      

     </td>
  </tr>
         
                                          <tr>
    <td>Street <b style="color:red">*</b></td>
    <td> 
        <select class="form-control CH-Size-New" runat="server" id="td_Own_Street" name="td_Own_Street" required>
            <option>1</option>
            <option>2</option>
            <option>3</option>
        </select>
    </td>
 
  </tr>  
  <tr>
    <td>City/Municipality<b style="color:red">*</b></td>
    <td> <input type="text" runat="server" id="td_Own_CityMun" name="td_Own_CityMun" class="form-control CH-Size-New" required/></td>
  </tr>

</table>
  
        <br />
          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp Attachments</strong> 
    </div> 
    
<table id="Information">

  <tr>
    <td style="width:35%">Owner's Picture<b style="color:red">*</b></td>  

    <td> 
        <input  class="form-control CH-Size-New" id="up_OwnPic" name="up_OwnPic" runat="server" required type="file"  />
    </td>  

       <td> 
            <a href="#" id="link_OwnPic"  class="form-group col col-md-12" onclick="do_embed(1);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
          <input type="hidden" runat="server" id="hdn_1"/>    
            </td>
 
  </tr>
  <tr>
    <td>Business Establishment Picture<b style="color:red">*</b></td> 

    <td>
          <input  class="form-control CH-Size-New" id="up_EstPic" name="up_EstPic" runat="server" required type="file"  />
    </td>  
      <td> 
            <a href="#" id="link_EstPic"  class="form-group col col-md-12" onclick="do_embed(2);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
        <input type="hidden" runat="server" id="hdn_2"/>
      </td>

  </tr>
  <tr>
   <td>Business Map Location<b style="color:red">*</b></td> 
  
      <td>
          <input  class="form-control CH-Size-New" id="up_MapPic" name="up_MapPic" runat="server" required type="file"  />
    </td>  
      <td> 
            <a href="#" id="link_MapPic"  class="form-group col col-md-12" onclick="do_embed(3);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
        <input type="hidden" runat="server" id="hdn_3"/>
      </td>
  </tr>
  <tr>
   <td>Application Form with Signature<b style="color:red">*</b></td> 
  
       <td>
          <input  class="form-control CH-Size-New" id="up_AppForm" name="up_AppForm" runat="server" required type="file"  />
    </td> 
        <td> 
            <a href="#" id="link_AppForm"  class="form-group col col-md-12" onclick="do_embed(4);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_4"/>
        </td>
  </tr>
  <tr>
    <td>DTI/SEC/CDA Registration<b style="color:red">*</b></td>  
      
       <td>
          <input  class="form-control CH-Size-New" id="up_DtiSecCda" name="up_DtiSecCda" runat="server" required type="file"  />
    </td> 
       <td> 
            <a href="#" id="link_DtiSecCda"  class="form-group col col-md-12" onclick="do_embed(5);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_5"/>
            </td>
  

  </tr>
  <tr>
   <td>TIN Registration<b style="color:red">*</b></td>    
        <td>
          <input  class="form-control CH-Size-New" id="up_TIN" name="up_TIN" runat="server" required type="file"  />
    </td> 
      <td> 
            <a href="#" id="link_TIN"  class="form-group col col-md-12" onclick="do_embed(6);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_6"/>
           </td>
  
 
  </tr>
  
</table>
    <hr />
    <input type="button" runat="server" id="btn_Save" value="Save as Draft" />
    <input type="button" runat="server" id="btn_Submit" style="display:none;" />
    <input type="button" value="Submit" onclick='do_Submit();' />
    </form>
    
        </div>  



                             </div>
                   </center>
           </div>


                   <script>
                      function do_Submit() {
                        var div_Main = document.getElementsByClassName('MainDiv');
                        var ele = div_Main[0].getElementsByTagName('input');                       
                          
                         for (var i = 0; i < ele.length; i++) {
                             if (ele[i].checkValidity() == false) {
                                 ele[i].reportValidity();
                                 break;                                 
                             }
                       
                               document.getElementById('<%= btn_Submit.ClientID%>').click();
                            
                           }
                      }

                       function do_display() {                   
                           if (sessionStorage.getItem("up_FileName1") == '') {
                               document.getElementById('link_OwnPic').style.display='none';
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
                          
                       }                      
                   </script>
</asp:Content>
