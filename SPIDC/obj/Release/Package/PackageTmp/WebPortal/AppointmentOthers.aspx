<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="AppointmentOthers.aspx.vb" Inherits="SPIDC.AppointmentOthers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js"></script>
    <script src="Scripts/fullcalendar.js" type="text/javascript"></script>
    <link href="Styles/fullcalendar.css" rel="stylesheet" type="text/css" />   
     
 <style>
     #fullcal{
         width:700px;
         padding:50px 0 0 10px ;
     }
 </style>
    

     <script> 
  
   



         function Set_Label(btnUp) {

             switch (btnUp.id) {

                 case 'up1':
                     if (btnUp.value.length !== 0) {
                         document.getElementById('<%=lblup1.ClientID%>').innerText = document.getElementById('<%=up1.ClientID%>').files.item(0).name;
                     }
                     else if (btnUp.value.length == 0) {
                         document.getElementById('<%=lblup1.ClientID%>').innerText = 'No File Chosen';
                             }

                         break;
                    <%-- case 'up2':
                         if (btnUp.value.length !== 0) {
                             document.getElementById('<%=lblup2.ClientID%>').innerText = document.getElementById('<%=up2.ClientID%>').files.item(0).name;
                             }
                             else if (btnUp.value.length == 0) {
                                 document.getElementById('<%=lblup2.ClientID%>').innerText = 'No File Chosen';
                             }

                         break;
                     case 'up3':
                         if (btnUp.value.length !== 0) {
                             document.getElementById('<%=lblup3.ClientID%>').innerText = document.getElementById('<%=up3.ClientID%>').files.item(0).name;
                             }
                             else if (btnUp.value.length == 0) {
                                 document.getElementById('<%=lblup3.ClientID%>').innerText = 'No File Chosen';
                             }
                         break;
                     case 'up4':
                         if (btnUp.value.length !== 0) {
                             document.getElementById('<%=lblup4.ClientID%>').innerText = document.getElementById('<%=up4.ClientID%>').files.item(0).name;

                             }
                             else if (btnUp.value.length == 0) {
                                 document.getElementById('<%=lblup4.ClientID%>').innerText = 'No File Chosen';
                             }
                         break;
                     case 'up5':
                         if (btnUp.value.length !== 0) {
                             document.getElementById('<%=lblup5.ClientID%>').innerText = document.getElementById('<%=up5.ClientID%>').files.item(0).name;

                             }
                             else if (btnUp.value.length == 0) {
                                 document.getElementById('<%=lblup5.ClientID%>').innerText = 'No File Chosen';

                             }

                         break;--%>
                 }

             }
             function Do_Upload(ID) {
                 __doPostBack(ID, 'Upload');
                 return false;
             }

             function Do_Download(ID) {
                 __doPostBack(ID, 'Download');
                 return false;
             }

                 function getParameterByName(name) {
                     name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
                     var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                         results = regex.exec(location.search);
                     return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
                 }

                 var conf = jQuery.noConflict(true);             

                 (function ($) {

                     $(document).ready(function () {      

                         var ED = getParameterByName("EventDate");
                       
                         $.ajax({
                             type: "POST",
                             contentType: "application/json",
                             data: "{}",
                             url: "AppointmentOthers.aspx/GetEvents",
                             dataType: "json",
                             success: function (data) {

                                 $('div[id*=fullcal]').fullCalendar({
                                     header: {
                                         left: 'title',
                                         right: 'today,prev,next '
                                     },                               
                                     editable: true,
                                     showNonCurrentDates: false,
                                     fixedWeekCount:false,

                                     events: $.map(data.d, function (item, i) {
                                         var event = new Object();
                                         event.id = item.EventID;
                                         event.start = new Date(item.StartDate);
                                         event.end = new Date(item.EndDate);
                                         event.title = item.EventName;
                                         event.color = item.Color;
                                         event.url = item.Url;                                    
                                         return event;
                                     })
                                 });
                        
                           
                             },
                             error: function (XMLHttpRequest, textStatus, errorThrown) {
                                 debugger;
                             }
                         });
                         $('#loading').hide();
                         $('div[id*=fullcal]').show();
                     });
        
                 }(conf))

         function Confirm() {            
             __doPostBack('Confirm');
         }

      


         //SNACKBAR - Welcome       
         function SnackbarGreen() {
             var x = document.getElementById("snackbargreen");
             x.className = "show";
             setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
         }
         function Snackbar() {
             var x = document.getElementById("snackbar");
             x.className = "show";
             setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
         }
         $(document).ready(function () {
             var ED = getParameterByName("EventDate");    
             if (ED == "") {
                // alert("No Selected Date");   
                 document.getElementById("btnNext").style.opacity = "0.5";
                 document.getElementById("btnNext").style.cursor = "not-allowed"; //"default";
                 document.getElementById("btnNext").disabled = true;
             }
             else
             {
               //  alert("Selected Date : " + ED)
                 document.getElementById("btnNext").style.opacity = "1";
                 document.getElementById("btnNext").style.cursor = "default";
                 document.getElementById("btnNext").disabled = false;
             }
            
         
         });
        
     

    </script>

    
      <div id="snackbar" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbar"/>           
        </div>
        <div id="snackbargreen" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
        </div>

       <!-- Modal Apointment Summary -->
      <div id="AppointmentSummary" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Appointment Request</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
          
                <div class="form-group">
                    * Please confirm if all the entries are correct
                     <div class="card-footer">
                    <div class="row">
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Transaction Type</p>
                            <p class="h6 font-weight-light" id="_oLabelTransType" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Appointment Date</p>
                            <p class="h6 font-weight-light" id="_oLabelAppDate" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Department</p>
                            <p class="h6 font-weight-light" id="_oLabelDepartment" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Purpose</p>
                            <p class="h6 font-weight-light" id="_oLabelPurpose" runat="server"></p>
                            <br />
                        </div>                      
                     
                    </div>
                </div>  
               
                </div>              
                Appointment Schedule is SUBJECTED FOR APPROVAL, you will receive email confirmation after we reviewed your documents.
  
               <div class="text-center">
                  <asp:button runat="server" ID="btnConfirm" type="submit" cssclass="btn btn-primary small" Text="Confirm"></asp:button>
              
                </div>
          

              
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->

     <div class="row justify-content-center align-items-center card form mb-0"> 
        <div class=" row col-md-12">
              <div class="form-row col-md-3 m-0 row ">
                        <div class="col-lg-12 m-2 mb-4">
                            <h6 class="m-0 font-weight-bold text-primary">Department:  </h6>
                             <label id="txtDepartment" runat="server">txtDepartment</label>
                            </div>
                        </div>       
            
              <div class="form-row col-md-3 m-0 row ">
                        <div class="col-lg-12 m-2 mb-3">
                            <h6 class="m-0 font-weight-bold text-primary">Transaction Type:  </h6>
                             <label id="txtTransType" runat="server">txtTransType</label>
                            </div>
                        </div>       
            
              <div class="form-row col-md-3 m-0 row ">
                        <div class="col-lg-12 m-2 mb-3">
                            <h6 class="m-0 font-weight-bold text-primary">Purpose:  </h6>
                             <label id="txtPurpose" runat="server">txtPurpose</label>
                            </div>
                        </div> 
            
              <div class="form-row col-md-12 m-0 row d-flex justify-content-center">
          
                  
               
       
                      
                  </div>              
              <div style="padding:10px;background-color:#F1F1F1; width:100%;">
                <center>
          <span style="background-color:red;color:white;font-weight:bold; border-radius:5px;padding:3px">Note :</span>
          <b style="color:indianred;" id="div_note">To set your appointment schedule, please click on the AM or PM button before uploading supported documents</b><br />
                 </center>
                      </div>           
                  </div>       

         
        <div class="d-flex justify-content-center col-lg-12">
     <div id="loading">
        <img src="Styles/images/loading_wh.gif" />
    </div>

    <div id="fullcal" > 
        <br>
        <center>
         <div class="col-md-12 border-dark border row " id="div_upload"> 
                     <div class="col-lg-6 mt-2" style="text-align:left">                        
                         <input type="file" id="up1" runat="server" style="display: none;" onchange="Set_Label(this);" />
                         <input type="button" value="Choose File" onclick="document.getElementById('up1').click();" />
                         <label id="lblup1" runat="server">No File Chosen</label>
                   
                     </div>
                     <div class="col-lg-6" style="text-align:left">
                        <span style=color:red;> Please attach PDF/Scanned copy of supporting documents</span>  
           
                     </div>  
                 </div>
            </center>
                <div class="col-md-10"> <br />
                           <input  type="button" style="display:none;" value="Upload Files" id="btnUpload" onclick="Do_Upload(this.id);"/>
                            </div>
     


       <div style="text-align:right">          
           <a href="#" id="btnNext" tabindex="99" data-toggle="modal" data-dismiss="modal" data-target="#AppointmentSummary" data-ticket-type="standard-access" class="btn-primary btn" >&nbsp Next &nbsp</a>

             
       </div>
           
               
       <br />
       
    </div>
            </div>
            </div>
           
  <input type="hidden" id="hdnErr" runat="server" />
  <script>
      var str = window.location.href;
     // if (str.toUpperCase().includes("CSJDM") == true) {
     //     alert('1');
     //     document.getElementById('div_upload').style.display = 'none';
     //     alert('2');
     //     document.getElementById('div_note').innerHTML =
     //         'To set your appointment schedule, please click on the AM or PM button and click Next';
     //     alert('3');
     // };

  </script>
  
</asp:Content>
