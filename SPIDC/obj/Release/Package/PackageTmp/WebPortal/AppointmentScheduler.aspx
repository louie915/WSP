<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="AppointmentScheduler.aspx.vb" Inherits="SPIDC.AppointmentScheduler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">


    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Appointment Purpose</h5>
    </div>
    <div class="row justify-content-center align-items-center card form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
            <div class=" mb-0 m-2" style="background-color: white">
                <div class=" row">
                    <div class="form-row col-md-4 m-0 row ">
                        <form name="frmSubmit" enctype="multipart/form-data" method="post" onsubmit="document.getElementById('xSubmit').value = 'True'">
                            <div class="col-lg-12 m-2">

                                <h6 class="m-0 font-weight-bold text-primary">Select Department:</h6>
                                <select name="cmbDepartment" required id="cmbDepartment" runat="server" class="form-control" onchange="doSelectDept(this.selectedIndex,this.value);">
                                </select>
                                <br />

                                <h6 class="m-0 font-weight-bold text-primary">Select Appointment Type:</h6>

                                <select name="cmbType" required id="cmbType" runat="server" class="form-control" onchange="getSelectedType(this.value);">
                                </select>
                                <br />

                                <textarea id="Purpose" name="Purpose" class="form-control CH-size" style="height: 100px" placeholder="Please state your purpose of Appointment"></textarea>
                                <div id="spacer">
                                    <br />
                                    <br />
                                </div>
                                <center>
                                               

<%--                                                    
                        <input type="Submit" id="btnSubmit" name="btnSubmit" value="Next" formaction="AppointmentScheduler.aspx"  class="btn btn-primary col-md-2 col-lg-4 m-2 btn-sm"/>--%>
                       
                        <input type="button" id="btnNext" name="btnNext" runat="server" value="Next"  class="btn btn-primary col-md-12  m-2 btn-sm"/>
                                    <br />
                         
                                
                               <a href="#" id="link_HaveCode" data-toggle="modal" data-target="#AppointmentCode" data-ticket-type="standard-access" >I already have a Code </a>
                         
                                    </center>

                            </div>
                            <input name="DepartmentDesc" id="DepartmentDesc" type="hidden" />
                            <input name="DepartmentValue" id="DepartmentValue" type="hidden" />
                            <input name="AppointmentType" id="AppointmentType" type="hidden" />
                            <input name="xSubmit" id="xSubmit" type="hidden" value="False" />
                            <input name="xPurpose" id="xPurpose" type="hidden" />

                            <input type="hidden" id="CodeSubmited" value="" />


                        </form>

                    </div>
                    <div class="form-row col-md-6 m-0 row ">
                        <div class="col-lg-12 m-2 mb-3" style="border: 1px solid gray">
                            <h6 class="m-0 font-weight-bold text-primary">Requirements:</h6>
                            <div id="div_Reqs">
                            </div>



                        </div>
                        <center>
         <div class="col-lg-12  m-2 mb-3 row " style="border:1px solid gray" id="div_upload"> 
                     <div class="col-lg-6 mt-2" style="text-align:left">   
                              <input type="file" id="up1" runat="server"/>           
                     </div>
                     <div class="col-lg-6" style="text-align:left">
                        <span style=color:red;>Please compile all your supporting documents into 1 single file (rar|zip|7z) before uploading</span>  
                     </div>  
                 </div>
            </center>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--<div style="display: none">


        <h6 class="m-0 font-weight-bold text-primary">Select Department:</h6>
        <select name="test1" required id="test1" runat="server" class="form-control" onchange="filter();">
        </select>
        <br />
        <h6 class="m-0 font-weight-bold text-primary">Select Appointment Type:</h6>
        <select name="test2" required id="test2" runat="server" class="form-control">
        </select>
    </div>--%>

    <input type="hidden" runat="server" id='xDeptDesc' />
    <input type="hidden" runat="server" id='xAppType' />
    <input type="hidden" runat="server" id='xAppPurpose' />
    <input type="hidden" runat="server" id='xDeptVal' />





    <!-- Modal Appointment Code Form -->
    <div id="AppointmentCode" class="modal fade">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Enter Appointment Code</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <form id="frmCode" method="post">
                    <div class="modal-body">
                        <div class="form-group text-center">
                            <input type="text" maxlength="20" required id="txtCode" name="txtCode" />
                            <input type="submit" class="btn btn-primary small" value="Proceed" />
                        </div>
                    </div>
                </form>


            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->


    <script>

        var str = window.location.href;
        // if (str.toUpperCase().includes("CSJDM") == true) {
        //
        // }
        //
        // else {
        document.getElementById('div_upload').style.display = 'none';
        document.getElementById('link_HaveCode').style.display = 'none';
        document.getElementById('txtCode').value = '';
        // };

        function do_click_up1() {
            document.getElementById('<%= up1.ClientID%>').click();
        }
        function chk_CSJDM() {

            //   var str = window.location.href;
            //   if (str.toUpperCase().includes("CSJDM") == true) {          
            //       if (document.getElementById('<%= up1.ClientID%>').files.length == 0)
            //           {
            //               alert("Please Upload your supporting Documents");
            //               return false;
            //       }
            //       else
            //         {
            //           document.getElementById('<%= btnNext.ClientID%>').click();
            //           return false;
            //         }
            //       }
            //      
        }




        function doSelectDept(Action, Val) {
            __doPostBack(Action, Val);
        }


        function getSelectedType(value) {
            var TypeDesc = document.getElementById('<%=cmbType.ClientID%>').options[document.getElementById('<%=cmbType.ClientID%>').selectedIndex].text;
            var DeptDesc = document.getElementById('<%=cmbDepartment.ClientID%>').options[document.getElementById('<%=cmbDepartment.ClientID%>').selectedIndex].text;
            var DeptVal = document.getElementById('<%=cmbDepartment.ClientID%>').value;

            document.getElementById('DepartmentDesc').value = DeptDesc;
            document.getElementById('DepartmentValue').value = DeptVal;
            document.getElementById('AppointmentType').value = TypeDesc;

            document.getElementById('<%= xDeptDesc.ClientID%>').value = DeptDesc;
            document.getElementById('<%= xDeptVal.ClientID%>').value = DeptVal;
            document.getElementById('<%= xAppType.ClientID%>').value = TypeDesc;


            if (TypeDesc == 'Others') {
                document.getsElementById("Purpose").style.display = 'block';
                document.getElementById("Purpose").required = true;
            }
            else {
                document.getElementById("Purpose").style.display = 'none';
                document.getElementById("Purpose").required = false;
            }

            document.getElementById('div_Reqs').innerHTML = document.getElementById('<%=cmbType.ClientID%>').value;

            var div_text = document.getElementById('div_Reqs').innerHTML;

            if (div_text.includes("You still have PENDING Appointment") == true) {
                document.getElementById('btnSubmit').style.pointerEvents = "none";
                document.getElementById('btnSubmit').style.opacity = "0.4";
            } else {
                document.getElementById('btnSubmit').style.pointerEvents = "auto";
                document.getElementById('btnSubmit').style.opacity = "1";
            };
        }



<%--        document.getElementById('<%= test2.ClientID%>').disabled = true;
        function filter() {
            var cmb1 = document.getElementById('<%= test1.ClientID%>').value;
            var cmb2 = document.getElementById('<%= test2.ClientID%>');
            document.getElementById('<%= test2.ClientID%>').disabled = false;
            for (var i = 0; i < cmb2.length; i++) {
                var txt = cmb2.options[i].value;

                if (!txt.match(cmb1)) {
                    $(cmb2.options[i]).attr('disabled', 'disabled').hide();
                }
                else {
                    $(cmb2.options[i]).removeAttr('disabled').show();
                }
            }
        }--%>



        function Do_Upload(ID) {
            __doPostBack(ID, 'Upload');
            return false;
        }

    </script>

</asp:Content>
