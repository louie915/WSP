<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BPLODirectEnrollment.aspx.vb" Inherits="SPIDC.BPLODirectEnrollment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row col-lg-12">
        <div class="col-sm-12" align="center">
            <br />
            <h3>
                <label class=" font-weight-bold text-primary mb-1">Direct Enrollment</label></h3>
        </div>
        <div class="col-sm-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Taxpayer Information</label>
                </div>
                <div class="card-body col-sm-8">
                    <div class="form-row">
                        <div class="form-group col-md-4">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Enter BIN </span></span>
                                </label>
                                <input id="txtBIN" required style="text-align: center" type="text" class="form-control CH-Size-New" runat="server" />
                            </div>
                        </div>
                        <div class="form-group col-md-4">
                            <div>
                                <input id="btnSearch" type="button" onclick="do_Search()" value="Search" class="btn btn-primary" style="display: inline-block" />
                                <label style="color: red; font-weight: bold; font-size: small; display: none;" runat="server" id="lbl_Invalid">Invalid BIN</label>
                            </div>
                        </div>

                    </div>


                </div>
                <div class="form-row" style="padding: 5px; display: none;" id="div_BusInfo" runat="server">

                    <div class="w3-pale-green col-sm-12" style="font-weight:bold" runat="server" id="div_Notice">
                     
                    </div>

                    <div class="form-group col-sm-6" style="background-color: #CFD6E5">
                        <div style="background-color: white; padding: 5px">
                            <div class="card-header">
                                <label class=" font-weight-bold text-primary text-uppercase mb-1">Business Information</label>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <div>
                                        <label class="input-txt input-txt-active2">
                                            <span><span class="m-2">BIN</span></span>
                                        </label>
                                        <input type="text" class="form-control CH-size-new" id="lblBIN" runat="server" readonly>
                                    </div>
                                </div>

                                <div class="form-group col-md-6">
                                    <div>
                                        <label class="input-txt input-txt-active2">
                                            <span><span class="m-2">Date Established</span></span>
                                        </label>
                                        <input type="text" class="form-control CH-size-new" id="lblDateEsta" runat="server" readonly>
                                    </div>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <div>
                                        <label class="input-txt input-txt-active2">
                                            <span><span class="m-2">Business Name</span></span>
                                        </label>
                                        <input type="text" class="form-control CH-size-new" id="lblBusName" runat="server" readonly>
                                    </div>
                                </div>


                                <div class="form-group col-md-6">
                                    <div>
                                        <label class="input-txt input-txt-active2">
                                            <span><span class="m-2">Ownership Type</span></span>
                                        </label>
                                        <input type="text" class="form-control CH-size-new" id="lblOwnershipType" runat="server" readonly>
                                    </div>
                                </div>

                                <div class="form-group col-md-12">
                                    <div>
                                        <label class="input-txt input-txt-active2">
                                            <span><span class="m-2">Business Address</span></span>
                                        </label>
                                        <textarea class="form-control CH-size-new" id="lblBusAddress" runat="server" readonly></textarea>
                                    </div>
                                </div>

                                   <div class="form-group col-md-12">
                 <label class="text-capitalize font-weight-bold text-primary" >
                     Business Line
                    </label>

            
             <asp:GridView ID="_GVBusinessLine" runat="server" CssClass="mGrid col-lg-12 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>
                    <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="CENTER" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <label class="txBusCode"><%# Eval("BUS_CODE")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Business Line" ItemStyle-HorizontalAlign="CENTER"  >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("DESCRIPTION")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CATEGORY" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATDESC")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

            </div>


                            </div>
                        </div>
                    </div>
                    <div class="form-group  col-sm-5">
                        <div class="card-header">
                            <label class=" font-weight-bold text-primary text-uppercase mb-1">Owner Information</label>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-12">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Owner Name</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-size-new" id="lblOwnerName" runat="server" readonly>
                                </div>
                            </div>
                        </div>
                        <div class="form-row">

                            <div class="form-group col-md-12">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Owner Address</span></span>
                                    </label>
                                    <textarea class="form-control CH-size-new" id="lblOwnerAddress" runat="server" readonly></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="form-row" runat="server" id="div_Enroll">
                            <div class="form-group col-md-6" style="background-color: green">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Enter Valid Email Address </span></span>
                                    </label>
                                    <input id="txtEmail" style="text-align: center" type="text" class="form-control CH-Size-New" runat="server" />
                                </div>
                            </div>

                            <div class="form-group col-md-4">
                                <div>
                                    <input id="btnEnroll" onclick="do_Enroll();" type="button" value="Enroll Now" class="btn btn-primary" />
                                    <label style="color: red; font-weight: bold; font-size: small; display: none;" id="lbl_InvalidEmail">Invalid Email</label>
                                     </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="col-sm-12">
            <br />
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Enrollment History</label>
                </div>
                <div class="card-body">
                    <span class="">Show</span>
                </div>
            </div>
        </div>

    </div>
    <input type="button" runat="server" id="_btnSearch" style="display: none;" />
    <input type="button" runat="server" id="_btnEnrollNow" style="display: none;" />

    <input type="hidden" id="err" runat="server" />
    <script>

        function isEmpty(str) {
            return !str.trim().length;
        }

        function validateEmail(email) {
            var re = /\S+@\S+\.\S+/;
            return re.test(email);
        }      

        function do_Search() {
            var BIN = document.getElementById('<%= txtBIN.ClientID%>').value;
            if (isEmpty(BIN)) {
                alert('Please Enter BIN');
            }
            else {
                document.getElementById('btnSearch').value = 'Searching ...';
                document.getElementById('btnSearch').disabled = true;
                document.getElementById('<%= _btnSearch.ClientID%>').click();
            }
        }

        function do_Enroll() {
           var Email =  document.getElementById('<%= txtEmail.ClientID%>').value;
            if (validateEmail(Email)) {
                document.getElementById('btnEnroll').value = 'Enrolling ...';
                document.getElementById('btnEnroll').disabled = true;
                document.getElementById('lbl_InvalidEmail').style.display = 'none';
                document.getElementById('<%= _btnEnrollNow.ClientID%>').click(); 
               
            }
            else {
                document.getElementById('lbl_InvalidEmail').style.display = '';
            }
           
        }
    </script>
</asp:Content>
