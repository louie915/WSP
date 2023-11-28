<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="LGUAppointmentApproval.aspx.vb" Inherits="SPIDC.LGUAppointmentApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
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

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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

    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Appointment Approval</h5>
    </div>
   
   <div class="form-row col-lg-12">


        <div class="form-group col-lg-12" style="border-radius: 1vh; border: 1px solid lightgray">

            <div class="form-row col-lg-12" style="padding-top: 2vh">
                <br />
                <br />                            

                
                <div class="form-group col-lg-2">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Type</span></span>
                    </label>
                    <select runat="server" id="cmbTypeFilter" class="form-control">
                        <option value="ALL">ALL </option>                       
                    </select>
                </div>               

                 <div class="form-group col-lg-2">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Sort By</span></span>
                    </label>
                    <select runat="server" id="cmb_SortBy" class="form-control">                    
                        <option selected value="TransDate">Date Requested </option>
                        <option value="Email">Email </option>                      
                        <option value="Type">Type </option>
                        <option value="AppDate">App Date </option>                    
                    </select>

                </div>

                 <div class="form-group col-lg-2">
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Order</span></span>
                    </label>
                    <select runat="server" id="cmb_Order" class="form-control">                       
                        <option selected value="ASC">Ascending </option>
                        <option value="DESC">Descending </option>
                    </select>

                </div>

                <div class=" form-group col-lg-2">
                    <a href="#" class="btn btn-primary" runat="server" id="btnFilter">
                        <i class="fa fa-filter"></i>&nbsp Filter
                    </a>
                </div>

            </div>

            <div class="form-group col-lg-12">
                <asp:GridView ID="_GVRequests" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_GVRequests"
                            PageSize="10">
                    <Columns>
                        <asp:TemplateField HeaderText="Date Requested" ItemStyle-HorizontalAlign="left">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelTransDate" runat="server" Text='<%# Eval("TransDate")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("Email")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Office" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelOffice" runat="server" Text='<%# Eval("Office")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center"  >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelType" runat="server" Text='<%# Eval("TransType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="App Date" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelAppDate" runat="server" Text='<%# Eval("AppDate2") + " " + Eval("slot")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>                            
                                <div class="form-row col-lg-12">
                                     <a href="#" class="btn btn-success form-group col-lg-12"   id="a_View"  
                                         onclick="do_View(this.id,'<%# Eval("AppID")%>','<%# Eval("Email")%>','<%# Eval("AppDate2")%>','<%# Eval("Slot")%>','<%# Eval("Office")%>','<%# Eval("TransType")%>')">View</a> 
                                      
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>





        </div>


    </div>


    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Approval History</h5>
    </div>
     <div class="form-row col-lg-12">
           <div class="form-group col-lg-12" style="border-radius: 1vh; border: 1px solid lightgray">
                <div class="form-group col-lg-12">
                <asp:GridView ID="_GVHistory" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_GVHistory"
                            PageSize="10">
                    <Columns>
                        <asp:TemplateField HeaderText="Date Requested" ItemStyle-HorizontalAlign="left">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TransDate")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Email")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Office" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Office")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center"  >
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("TransType")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="App Date/Time" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelAppDateTime" runat="server" Text='<%# Eval("AppDate2") + " " + Eval("slot")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Request Status" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelRequestStatus" runat="server" Text='<%# Eval("RequestStatus")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>                            
                                <div class="form-row col-lg-12">
                                     <a href="#" class="btn btn-success form-group col-lg-12" id="a_View_History"    
                                         onclick="do_View(this.id,'<%# Eval("AppID")%>','<%# Eval("Email")%>','<%# Eval("AppDate2")%>','<%# Eval("Slot")%>','<%# Eval("Office")%>','<%# Eval("TransType")%>')">View</a> 
                                       
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
           </div>
     </div>


    <div class="modal fade" id="ModalView">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h4 class="modal-title text-white">View Appointment Request</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="text-align: left">
                    <h6>Taxpayer is requesting for Appointment with the following details:</h6>
                 
                    <div class="form-row col-lg-12" style="text-align:center">
                       
                            <div class="form-row col-lg-12">
                                <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email</span></span>
                                    </label>
                                    <label class="form-control" id="lbl_Email" runat="server"></label>                                   
                                </div> 
                                 <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Selected Office</span></span>
                                    </label>
                                    <label class="form-control" id="lbl_Office" runat="server"></label>                                   
                                </div>
                                <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Appointment Type</span></span>
                                    </label>
                                    <label class="form-control" id="lbl_Type" runat="server"></label>                                   
                                </div>
                                <div class="form-group col-lg-6">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date</span></span>
                                    </label>
                                    <label class="form-control" id="lbl_Date" runat="server"></label>             
                                </div>
                                <div class="form-group col-lg-2">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Time</span></span>
                                    </label>
                                   <label class="form-control" id="lbl_Time" runat="server"></label>          
                                </div>
                                 <div class="form-group col-lg-4">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Remaining Slot/s</span></span>
                                    </label>
                                   <label class="form-control" id="lbl_Slot" runat="server"></label>          
                                </div>
                             <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Supported Document/s</span></span>
                                    </label>   
                                 <a href="#" runat="server" id="a_SupDoc" target="_blank" class="form-control" style="color:blue"></a>
                                </div>
                            </div>
                      
                        
                    </div>

                </div>
                <div class="modal-footer">

                    <div class="form-row col-lg-12">
                        <div class="form-group col-lg-12" style="background-color:#257CFC;padding-bottom:0.5em;padding-top:0.5em;">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Remarks</span><b style="color:red">*</b></span>
                                    </label>
                                    <textarea required class="form-control" runat="server" id="txt_Remarks"></textarea>
                                </div>
                        <div class="form-group col-lg-6">
                            <input type="button" id="btnApprove" runat="server"  value="Approve" class="btn btn-success" style="width: 100%" />
                        </div>
                        <div class="form-group col-lg-6">
                            <input type="button" id="btnReject" runat="server" value="Reject" class="btn btn-danger" style="width: 100%" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

       <div class="modal fade" id="ModalView_History">
        <div class="modal-dialog modal-md">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h4 class="modal-title text-white">View Approval History</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" style="text-align: left">                                  
                    <div class="form-row col-lg-12" style="text-align:center">                       
                            <div class="form-row col-lg-12">
                                <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email</span></span>
                                    </label>
                                    <label class="form-control" id="lbl_Email_History" runat="server"></label>                                   
                                </div> 
                                 <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Selected Office</span></span>
                                    </label>
                                    <label class="form-control" id="lbl_Office_History" runat="server"></label>                                   
                                </div>
                                <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Appointment Type</span></span>
                                    </label>
                                    <label class="form-control" id="lbl_Type_History" runat="server"></label>                                   
                                </div>
                                <div class="form-group col-lg-8">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Date</span></span>
                                    </label>
                                    <label class="form-control" id="lbl_Date_history" runat="server"></label>             
                                </div>
                                <div class="form-group col-lg-4">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Time</span></span>
                                    </label>
                                   <label class="form-control" id="lbl_Time_History" runat="server"></label>          
                                </div>
                               
                             <div class="form-group col-lg-12">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Supported Document/s</span></span>
                                    </label>   
                                 <a href="#" runat="server" id="a_SupDoc_History" target="_blank" class="form-control" style="color:blue"></a>
                                </div>
                            </div>
                      
                        
                    </div>

                </div>
                <div class="modal-footer">

                    <div class="form-row col-lg-12">
                        <div class="form-group col-lg-6" style="background-color:#257CFC;padding-bottom:0.5em;padding-top:0.5em;">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Processed By</span></span>
                                    </label>
                                      <label class="form-control" id="lbl_ProcessedBy" runat="server"></label>         
                                </div>     
                        <div class="form-group col-lg-6" style="background-color:#257CFC;padding-bottom:0.5em;padding-top:0.5em;">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Status</span></span>
                                    </label>
                                      <label class="form-control" id="lbl_Status_History" runat="server"></label>         
                                </div>                        
                         
                        <div class="form-group col-lg-12" style="background-color:#257CFC;padding-bottom:0.5em;padding-top:0.5em;">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Remarks</span></span>
                                    </label>
                                      <label class="form-control" id="lbl_Remarks_History" runat="server"></label>         
                                </div>                        
                    </div>
                </div>
            </div>
        </div>
    </div>

    
    
  
    <input type="hidden" id="hdnDepartment" runat="server" />

    
    <input type="hidden" id="hdnAppID" runat="server" />
    <input type="hidden" id="hdnEmail" runat="server" />
    <input type="hidden" id="hdnAppDate" runat="server" />
    <input type="hidden" id="hdnTime" runat="server" />
    <input type="hidden" id="hdnType" runat="server" />
    <input type="hidden" id="hdnOffice" runat="server" />
    <input type="button" id="btnView" runat="server"  style="display:none;"/>

    <input type="hidden" id="hdnAppID_History" runat="server" />
    <input type="hidden" id="hdnEmail_History" runat="server" />
    <input type="hidden" id="hdnAppDate_History" runat="server" />
    <input type="hidden" id="hdnTime_History" runat="server" />
    <input type="hidden" id="hdnType_History" runat="server" />
    <input type="hidden" id="hdnOffice_History" runat="server" />
    <input type="button" id="btnView_History" runat="server"  style="display:none;"/>
        
    <script>
        function do_Something(Action, Val) {
            __doPostBack(Action, Val);
        }

        function do_View(eleID, AppID, Email, AppDate, Time, Office, Type) {
            if (eleID == 'a_View') {
                document.getElementById('<%=hdnAppID.ClientID%>').value = AppID;
                document.getElementById('<%=hdnEmail.ClientID%>').value = Email;
                document.getElementById('<%=hdnAppDate.ClientID%>').value = AppDate;
                document.getElementById('<%=hdnTime.ClientID%>').value = Time;
                document.getElementById('<%=hdnOffice.ClientID%>').value = Office;
                document.getElementById('<%=hdnType.ClientID%>').value = Type;
                document.getElementById('<%=btnView.ClientID%>').click();
            }
            else if (eleID == 'a_View_History') {
                document.getElementById('<%=hdnAppID_History.ClientID%>').value = AppID;
                document.getElementById('<%=hdnEmail_History.ClientID%>').value = Email;
                document.getElementById('<%=hdnAppDate_History.ClientID%>').value = AppDate;
                document.getElementById('<%=hdnTime_History.ClientID%>').value = Time;
                document.getElementById('<%=hdnOffice_History.ClientID%>').value = Office;
                document.getElementById('<%=hdnType_History.ClientID%>').value = Type;
                document.getElementById('<%=btnView_History.ClientID%>').click();
            }


    }

    function openModal(ModalName) {
        $('#' + ModalName).modal('show');

    }

    </script>
</asp:Content>

