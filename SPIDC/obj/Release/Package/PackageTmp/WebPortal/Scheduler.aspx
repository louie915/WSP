<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/WebPortal/SchedulerMaster.Master" CodeBehind="Scheduler.aspx.vb" Inherits="SPIDC.Scheduler" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js"></script>
    <script src="Scripts/fullcalendar.js" type="text/javascript"></script>
    <link href="Styles/fullcalendar.css" rel="stylesheet" type="text/css" />

    <style>
        #fullcal {
            width: 700px;
            padding: 50px 0 0 10px;
        }
    </style>
    <script>
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
                    url: "Scheduler.aspx/GetEvents",
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
    </script>
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div id="snackbar" style="z-index: 1200;">Some text some message..</div>


    <!-- Modal Apointment Summary -->
    <div id="AppointmentSummary" class="modal fade">
        <div class="modal-dialog" style="min-width: 50vh; max-width: 80vh" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Appointment Saved</h4>
                </div>
                <div class="modal-body">                   
                    <div class="form-group">
                        <div class="card-footer">
                            <div class="row">

                                <div class="col-sm-6 align-content-center">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Appointment ID</p>
                                    <p class="h6 font-weight-light" id="lblAppID" runat="server"></p>
                                    <br />
                                </div>

                                 <div class="col-sm-6 align-content-center">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Remarks</p>
                                    <p class="h6 font-weight-light" id="lblRemarks" runat="server"></p>
                                    <br />
                                </div>

                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Name</p>
                                    <p class="h6 font-weight-light" id="lblName" runat="server"></p>
                                    <br />
                                </div>

                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Contact</p>
                                    <p class="h6 font-weight-light" id="lblContact" runat="server"></p>
                                    <br />
                                </div>

                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Department</p>
                                    <p class="h6 font-weight-light" id="lblDepartment" runat="server"></p>
                                    <br />
                                </div>

                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Transaction Type</p>
                                    <p class="h6 font-weight-light" id="lblType" runat="server"></p>
                                    <br />
                                </div>
                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Appointment Date</p>
                                    <p class="h6 font-weight-light" id="lblAppDate" runat="server"></p>
                                    <br />
                                </div>

                                <div class="col-sm-6">
                                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Purpose(if Type is [OTHERS])</p>
                                    <p class="h6 font-weight-light" id="lblPurpose" runat="server"></p>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>                    
  
               <div class="text-center">
                   <a href="#" class="btn btn-success  col-6" onclick="do_Print()"><i class="fa fa-print"></i>&nbsp Print Slip</a>
                   <input style="display:none;" type="button" runat="server" id="btnDone" value="Done" class="btn btn-primary col-lg-6" />
               </div>
                       



                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->




    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Appointment Scheduler</h5>
    </div>




    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="form-row col-lg-12">

                <div class="form-group col-lg-4" runat="server" id="div_Info">
                    <div class="form-row">
                        <div class="form-group col-lg-6">
                            <div>
                                <label class="input-txt input-txt-active2 ml-2">
                                    <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Taxpayer Name</span></span>
                                </label>
                                <input type="text" required class="form-control" runat="server" id="txtName" />
                            </div>
                        </div>
                        <div class="form-group col-lg-6">
                            <div>
                                <label class="input-txt input-txt-active2 ml-2">
                                    <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Taxpayer Contact No.</span></span>
                                </label>
                                <input type="text" required class="form-control" runat="server" id="txtContact" />
                            </div>
                        </div>
                    </div>


                    <div class="form-group">
                        <div>
                            <label class="input-txt input-txt-active2 ml-2">
                                <span><span class="m-2">BIN / TDN (if available)</span></span>
                            </label>
                            <input type="text" class="form-control" runat="server" id="txtAcctNo" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div>
                            <label class="input-txt input-txt-active2 ml-2">
                                <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Department</span></span>
                            </label>

                            <asp:DropDownList ID="cmbDepartment" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Department_Changed" runat="server">
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group">
                        <div>
                            <label class="input-txt input-txt-active2 ml-2">
                                <span><span class="m-2"><b style="color: red; font-size: larger">*</b>Type</span></span>
                            </label>
                            <asp:DropDownList ID="cmbType" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Type_Changed" runat="server">
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="form-group">
                        <div>
                            <label class="input-txt input-txt-active2 ml-2">
                                <span><span class="m-2">Purpose (if selected Type is [OTHERS])</span></span>
                            </label>
                            <textarea id="txtPurpose" runat="server" name="txtPurpose" style="height: 10vh" class="form-control"
                                placeholder="State the purpose of Appointment"></textarea>
                        </div>
                    </div>

                    <div class="form-group">
                        <div>
                            <label class="input-txt input-txt-active2 ml-2">
                                <span><span class="m-2">Requirements</span></span>
                            </label>
                            <div id="div_Reqs" class="form-control" runat="server"
                                style="height: auto;">
                            </div>
                        </div>
                    </div>

                     <div class="form-group">
                        <div>                          
                           <input type="button" id="btnNext" runat="server" value="Next" class="btn btn-primary col-md-12" />
                           <input type="button" id="btnReset" style="display:none;" runat="server" value="Reset" class="btn btn-danger col-md-12" />
                        
                        </div>
                    </div>

                </div>

                <div class="form-group col-lg-6" runat="server" id="div_Calendar" style="display:none;">
                    <div id="fullcal">
                        <br />
                        <input type="button" id="btnSave" value="Save" onclick="do_Save()" class="btn btn-success col-lg-12" />
                        <input type="button" runat="server" id="_btnSave" style="display: none;" />
                        <br />

                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <input type="hidden" runat="server" id="_EventID" />
    <input type="hidden" runat="server" id="_EventDate" />
    <input type="hidden" runat="server" id="_EventTime" />
    <input type="hidden" runat="server" id="_Name" />
    <input type="hidden" runat="server" id="_Contact" />
    <input type="hidden" runat="server" id="_Department" />
    <input type="hidden" runat="server" id="_Type" />


    <script>              
        function do_Print() {
            var AppID = document.getElementById('<%= lblAppID.ClientID%>').innerText;
               window.open('Report/ReportViewer.aspx?ReportType=AppointmentSlip&AppID=' + AppID);
        }

        function do_Save() {
            if (document.getElementById('<%= txtName.ClientID%>').checkValidity() == false) {
                document.getElementById('<%= txtName.ClientID%>').reportValidity();
            }
            else if (document.getElementById('<%= txtContact.ClientID%>').checkValidity() == false) {
                document.getElementById('<%= txtContact.ClientID%>').reportValidity();
            }
            else if (document.getElementById('<%= cmbDepartment.ClientID%>').checkValidity() == false) {
                document.getElementById('<%= cmbDepartment.ClientID%>').reportValidity();
            }
            else if (document.getElementById('<%= cmbType.ClientID%>').checkValidity() == false) {
                document.getElementById('<%= txtName.ClientID%>').reportValidity();
           }
           else if (document.getElementById('<%= cmbType.ClientID%>').checkValidity() == false) {
               document.getElementById('<%= txtName.ClientID%>').reportValidity();
           }
           else if (document.getElementById('<%= cmbDepartment.ClientID%>').value == "") {
               ShowSnackBar('red', "Please Select Department");
           }
           else if (document.getElementById('<%= cmbType.ClientID%>').value == "") {
               ShowSnackBar('red', "Please Select Appointment Type");
           }
           else if (getParameterByName('EventID') == null || getParameterByName('EventID') == "") {
               ShowSnackBar('red', "Please Select Appointment Date");
           }
           else if (getParameterByName('EventDate') == null || getParameterByName('EventDate') == "") {
               ShowSnackBar('red', "Please Select Appointment Date");
           }
           else if (getParameterByName('EventTime') == null || getParameterByName('EventTime') == "") {
               ShowSnackBar('red', "Please Select Appointment Date");
           }
           else {
               document.getElementById('btnSave').value = 'Saving, please wait ...';
               document.getElementById('btnSave').disabled = true;
               document.getElementById('<%= _btnSave.ClientID%>').click();
           }
}
function ShowSnackBar(color, msg) {
    var x = document.getElementById("snackbar");
    x.style.backgroundColor = color;
    x.innerText = msg;
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
}

function getParameterByName(name) {
    var url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}



    </script>
</asp:Content>
