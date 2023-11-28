<%@ Page Title="" EnableEventValidation="false" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="AppointmentSetup2.aspx.vb" Inherits="SPIDC.AppointmentSetup2" %>

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

                var nofile = 'No File Chosen';

                var ED = getParameterByName("EventDate");

                $.ajax({
                    type: "POST",
                    contentType: "application/json",
                    data: "{}",
                    url: "AppointmentSetup2.aspx/GetEvents",
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



    </script>




    <div id="snackbar" style="position: absolute; z-index: 5">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute; z-index: 5">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>
    <!-- Modal Edit Slot Form -->
    <div id="ModalEdit" class="modal fade">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header  bg-primary">
                    <h4 class="modal-title text-white" id="ModalFileName">Edit Appointment Slot</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">
                    <div class="col-lg-12">
                        <h6>Select Department:</h6>
                        <select name="cmbDepartment2" required id="cmbDepartment2" runat="server" class="form-control">
                        </select>
                        <br />
                        <h6>Select Date : <i style="color: blue">Press [Enter] after selecting Date</i></h6>

                        <input id="_date" runat="server" name="_date" type="text" class="form-control" min='2020-01-01' max='2020-13-13' />



                        <br />
                        <b>Remaining Slot/s</b>
                        <div class=" row ">
                            <div class="col-lg-6">
                                AM Slot
                <input type="text" runat="server" id="AM_Slot2" min="0" name="AM_Slot2" class="form-control" />
                            </div>
                            <div class="col-lg-6">
                                PM Slot
                <input type="text" runat="server" id="PM_Slot2" min="0" name="PM_Slot2" class="form-control" />
                            </div>

                        </div>
                        <br />
                        <input type="button" runat="server" id="btnSaveChanges" class="form-control btn btn-success" value="Save Changes" />



                    </div>

                </div>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->



       <div class="form-row" style="padding: 20px;">

       </div>



    <div class=" row col-md-12">


        <div class="col-lg-4">
            <h3 class="font-weight-bold text-primary">Add Appointment Slot</h3>
            <a href="#" class="form-control btn btn-success" data-toggle="modal" data-target="#ModalEdit" data-ticket-type="standard-access">Edit Appointment Slot</a>
            <br />
            <br />
            <h6>Select Department:</h6>
            <select name="cmbDepartment" required id="cmbDepartment" runat="server" class="form-control">
            </select>
        
            <br />
            <h6>Select Date Range:</h6>
            <input type="checkbox" id="WeekEnds" name="WeekEnds" />
            <label for="WeekEnds">Include Weekends</label>
            <br />
            From :
            <input id="dateFrom" name="dateFrom" type="text" class="form-control" min='2020-01-01' max='2020-13-13' />
            To :
            <input id="dateTo" name="dateTo" type="text" class="form-control" min='2020-01-01' max='2020-13-13' />


            <div class=" row ">
                <div class="col-lg-6">
                    AM Slot
                <input type="text" id="AM_Slot" min="0" required name="AM_Slot" class="form-control" />
                </div>
                <div class="col-lg-6">
                    PM Slot
                <input type="text" id="PM_Slot" min="0" required name="PM_Slot" class="form-control" />
                </div>

            </div>

            <br />
            <input type="submit" id="btnSubmit" class="form-control btn btn-success" value="Save Appointment Slot" formaction="AppointmentSetup.aspx" />
        </div>


        <input type="hidden" name="hdnClick" id="hdnClick" value="FALSE" />

        <div class="col-lg-8">
            <div id="fullcal">

                <br />
                <%-- <div style="padding:10px;background-color:#F1F1F1; width:100%;">
                <span style="background-color:red;color:white;font-weight:bold; border-radius:5px;padding:3px">Note :</span>
          <b style="color:indianred;">To EDIT appointment slots, please click on the AM or PM button</b><br />
                   </div>     --%>
                <br />
            </div>

        </div>
    </div>


    <script>

        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();
        if (dd < 10) {
            dd = '0' + dd
        }
        if (mm < 10) {
            mm = '0' + mm
        }

        today = yyyy + '-' + mm + '-' + dd;

        document.getElementById('<%= _date.ClientID%>').setAttribute("type", "date");
              document.getElementById('<%= AM_Slot2.ClientID%>').setAttribute("type", "number");
        document.getElementById('<%=  PM_Slot2.ClientID%>').setAttribute("type", "number");
        document.getElementById("AM_Slot").setAttribute("type", "number");
        document.getElementById("PM_Slot").setAttribute("type", "number");

        document.getElementById("dateFrom").setAttribute("type", "date");
        document.getElementById("dateFrom").value = today;
        document.getElementById("dateFrom").setAttribute("min", today);

        document.getElementById("dateTo").setAttribute("type", "date");
        document.getElementById("dateTo").value = today;
        document.getElementById("dateTo").setAttribute("min", today);

        function doSubmit() {
            document.getElementById('hdnClick').value = 'TRUE';

        }
        function openModal() {
            $('#ModalEdit').modal('show');
        }

        function do_Department(val) {
            document.getElementById('Department').value = val;
        }
    </script>


</asp:Content>
