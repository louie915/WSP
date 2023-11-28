<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUAppointmentMaster.Master"  CodeBehind="AppointmentList.aspx.vb" Inherits="SPIDC.AppointmentList" %>

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
           function do_save() {
               document.getElementById('<%= hdnStatus.ClientID%>').value = document.getElementById('_otxtAppStatus').value;;
               var Status = document.getElementById('<%= hdnStatus.ClientID%>').value;
               var AppID = document.getElementById('<%= _otxtAppID.ClientID%>').value;
               document.getElementById('<%= hdnServedBy.ClientID%>').value = document.getElementById('_otxtAppServedBy').value;
               __doPostBack(AppID, Status);
           }

           function do_view(Remarks, ServedBy, Purpose, Name, AppID, Status, Email, AppDate, Slot, TransDate, AcctID, TransType) {

               document.getElementById("AppDateSelected").style.display = "none";
               document.getElementById("AppIDSelected").style.display = "block";
               var part = AppDate.split(' ', 3);

               document.getElementById('<%= _otxtEmail.ClientID%>').value = Email;
               document.getElementById('<%= _otxtName.ClientID%>').value = Name;
               document.getElementById('<%= _otxtAppID.ClientID%>').value = AppID;
               document.getElementById('<%= _otxtAppDate.ClientID%>').value = part[0] + ' ' + Slot;
               document.getElementById('<%= _otxtAppType.ClientID%>').value = TransType;
               document.getElementById('<%= _otxtAppPurpose.ClientID%>').value = Purpose;
               document.getElementById('_otxtAppStatus').value = Status;
               document.getElementById('<%= _otxtAppServedBy.ClientID%>').value = ServedBy;
               document.getElementById('<%= _otxtAppRemarks.ClientID%>').value = Remarks;
           }

           function do_back() {
               document.getElementById("AppDateSelected").style.display = "block";
               document.getElementById("AppIDSelected").style.display = "none";
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

                   var nofile = 'No File Chosen';

                   var ED = getParameterByName("EventDate");

                   $.ajax({
                       type: "POST",
                       contentType: "application/json",
                       data: "{}",
                       url: "LGUAppointment.aspx/GetEvents",
                       dataType: "json",
                       success: function (data) {

                           $('div[id*=fullcal]').fullCalendar({
                               header: {
                                   left: 'title',
                                   right: 'today,prev,next '
                               },
                               editable: true,
                               showNonCurrentDates: false,
                               fixedWeekCount: false,

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
               //  alert(ED);
               if (ED == "") {
                   // alert("No Selected Date");   
                   document.getElementById("btnNext").style.opacity = "0.5";
                   document.getElementById("btnNext").style.cursor = "not-allowed"; //"default";
                   document.getElementById("btnNext").disabled = true;
               }
               else {
                   //  alert("Selected Date : " + ED)
                   document.getElementById("btnNext").style.opacity = "1";
                   document.getElementById("btnNext").style.cursor = "default";
                   document.getElementById("btnNext").disabled = false;
               }


           });

    </script>

    <input type="hidden" id="hdnServedBy" name="ServedBy" runat="server" />
      <div id="snackbar" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbar"/>           
        </div>
        <div id="snackbargreen" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
        </div>
      <asp:ScriptManager runat="server"></asp:ScriptManager>
    <!-- Modal Apointment Summary -->
      <div id="AppointmentSummary" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Appointment List</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">     
                <div id="AppDateSelected" runat="server">
                     <asp:GridView ID="GV_AppList"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true"  AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                        <Columns>                          
                             <asp:TemplateField HeaderText="Appointment ID" HeaderStyle-Width="40%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTransactionNumber" runat="server" Text='<%# Eval("AppID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                              <asp:TemplateField HeaderText="Status" HeaderStyle-Width="40%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelTag" runat="server" Text='<%# Eval("Status")%>'></asp:Label>                                                                 
                                         </ItemTemplate>
                                </asp:TemplateField>

                             <asp:TemplateField visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("Email")%>' />
                                    <asp:Label ID="_oLabelName" runat="server" Text='<%# Eval("Name")%>' />    
                                    <asp:Label ID="_oLabelAppDate" runat="server" Text='<%# Eval("AppDate")%>' />
                                    <asp:Label ID="_oLabelTime" runat="server" Text='<%# Eval("Slot")%>' />
                                    <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("TransDate")%>' />
                                    <asp:Label ID="_oLabelAcctID" runat="server" Text='<%# Eval("AcctID")%>' />
                                    <asp:Label ID="_oLabelAppointmentType" runat="server" Text='<%# Eval("TransType")%>' />
                                    <asp:Label ID="_oLabelPurpose" runat="server" Text='<%# Eval("Purpose")%>' />
                                    <asp:Label ID="_oLabelServedBy" runat="server" Text='<%# Eval("ServedBy")%>' />
                                           <asp:Label ID="_oLabelRemarks" runat="server" Text='<%# Eval("Remarks")%>' />
                                         </ItemTemplate>
                                </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="Details"  HeaderStyle-Width="20%">
                                    <ItemTemplate>
<a href="#" onclick="do_view('<%# Eval("Remarks")%>','<%# Eval("ServedBy")%>','<%# Eval("Purpose")%>','<%# Eval("Name")%>','<%# Eval("AppID")%>','<%# Eval("Status")%>','<%# Eval("Email")%>','<%# Eval("AppDate")%>','<%# Eval("Slot")%>','<%# Eval("TransDate")%>','<%# Eval("AcctID")%>','<%# Eval("TransType")%>');" >View</a>                     
                                         </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </div>   
                <div id="AppIDSelected" style="display:none">
                     <div class="form-group">
                  <input type="button" value="Back" onclick="do_back();" />
                     <div class="card-footer">
              <div class="row">
                  
                          <asp:GridView ID="GridViewDetails"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true" AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                        <Columns>                         
                            <asp:TemplateField visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelSeqID" runat="server" Text='<%# Eval("SeqID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>     
                               
                            <asp:TemplateField  HeaderText="Transaction No." ItemStyle-Width="100%"   >
                                    <ItemTemplate  >
                                    <asp:Label ID="_oLabelRefNo" runat="server" Text='<%# Eval("RefNo")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>        

                              <asp:TemplateField visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("Email")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>        

                            <asp:TemplateField visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelAcctID" runat="server" Text='<%# Eval("AcctID")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>    

                              <asp:TemplateField HeaderText="Document Type" ItemStyle-Width="100%">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDocType" runat="server" Text='<%# Eval("ReqDesc")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                            <asp:TemplateField  visible="false">
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelFileName" runat="server" Text='<%# Eval("FileName")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>               

                           
                           
                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                   <a href="#" id="_oButtonView" onclick="do_View('<%# Eval("Email")%>','<%# Eval("RefNo")%>','<%# Eval("ReqDesc")%>','<%# Eval("AcctID")%>' ,'<%# Eval("SeqID")%>')">Download</a> &nbsp;
                                                                                                                
                                         </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>                      

                    </div>

                                                 <div class="row" >
                                 
                              

                            <div class="form-group col-lg-12">
                                  <br />                             
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Email Address &nbsp</span></span>
                                    </label>
                                     <asp:textbox runat="server" id="_otxtEmail" class="form-control CH-Size" ReadOnly="true"/>
                            </div>

                            <div class="form-group col-lg-12">
                             
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Name &nbsp</span></span>
                                    </label>
                                      <asp:textbox runat="server" id="_otxtName" class="form-control CH-Size" ReadOnly="true"/>
                            
                            </div> 
                            <div class="form-group col-lg-6">
                             
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Appointment ID &nbsp</span></span>
                                    </label>
                                      <asp:textbox runat="server" id="_otxtAppID" class="form-control CH-Size" ReadOnly="true"/>
                            
                            </div>   
                                 
                            <div class="form-group col-lg-6">
                             
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Appointment Date &nbsp</span></span>
                                    </label>
                                      <asp:textbox runat="server" id="_otxtAppDate" class="form-control CH-Size" ReadOnly="true"/>
                            
                            </div>                              
                    

                           <div class="form-group col-lg-12">
                             
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Appointment Type &nbsp</span></span>
                                    </label>
                                      <asp:textbox runat="server" id="_otxtAppType" class="form-control CH-Size" ReadOnly="true"/>
                             </div> 
                               <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Purpose &nbsp</span></span>
                                    </label>
                                      <asp:textbox runat="server" id="_otxtAppPurpose" class="form-control CH-Size" ReadOnly="true"/>
                             </div> 
                                                          <div class="form-group col-lg-6">
                                 <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Status &nbsp</span></span>
                                    </label>
                  
                            <select id="_otxtAppStatus" class="form-control CH-Size">
                                <option value="Pending">Pending</option>
                                <option value="Served">Served</option>
                                <option value="NoShow">No Show</option>
                            </select>
                                                                </div>
                                                               <div class="form-group col-lg-6">
                                  <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Served By: &nbsp</span></span>
                                    </label>
                                      <asp:textbox runat="server" id="_otxtAppServedBy" class="form-control CH-Size"/>
                             </div> 
                         <div class="form-group col-lg-12">
                                <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Remarks &nbsp</span></span>
                                    </label>
                                      <asp:textbox runat="server" id="_otxtAppRemarks" class="form-control CH-Size" />
                            
                            </div>                                                  
                    <input type="button" value="Save" onclick="do_save();"/>
                            </div>
                </div>  
               
                </div>   
                </div>  
                         
                            
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
    <!-- /.modal -->
    <input type="hidden" runat="server" id="hdnStatus"/>
 

  
     <div class="row justify-content-center align-items-center card form mb-0"> 
        <div class=" row col-md-12">
             
     <div id="loading">
        <img src="Styles/images/loading_wh.gif" />
    </div>
            <div class="d-flex justify-content-center col-lg-12">
                <div id="fullcal">
                    <br />
                    <div style="padding: 10px; background-color: #F1F1F1; width: 100%;">
                        <span style="background-color: red; color: white; font-weight: bold; border-radius: 5px; padding: 3px">Note :</span>
                        <b style="color: indianred;">Please click on the AM or PM button to view appointment details</b><br />
                    </div>
                    <br />

                    <div style="text-align: right">
                        <input type="button" class="btn-primary btn" value="Cancel" />
                        <a href="#" id="btnNext" tabindex="99" data-toggle="modal" data-dismiss="modal" data-target="#AppointmentSummary" data-ticket-type="standard-access" class="btn-primary btn">&nbsp Next &nbsp</a>
                      
                    </div>



                    <br />
                    <br />
                </div>

            </div> 

            </div>          

       
            
         </div>

</asp:Content>