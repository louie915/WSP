<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="ReportSetup.aspx.vb" Inherits="SPIDC.ReportSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .center {
            height: 100%;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .form-input {
            width: 100%;
            background: #fff;
        }

            .form-input img {
                width: 100%;
                display: none;
                margin-top: 30px;
            }

            .form-input input {
                display: none;
            }

            .form-input label {
                display: block;
                width: 45%;
                height: 45px;
                margin-left: 25%;
                line-height: 50px;
                text-align: center;
                background: #1172c2;
                color: #fff;
                font-size: 15px;
                font-family: "Open Sans",sans-serif;
                font-weight: 600;
                border-radius: 5px;
                cursor: pointer;
            }
    </style>

    <script src="https://code.jquery.com/jquery-3.1.0.js"></script>


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


    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Email Notifications Setup
        </h5>
    </div>
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


    <div class="row justify-content-center align-items-center card form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
            <div class=" mb-0 m-2" style="background-color: white">
                <div class=" row">

                    <div class="form-row col-md-6 m-0 row ">
                        <div class="form-group col">
                            <br />
                            <div class="form-row">
                                <div class="form-row col-md-6 m-0 row ">
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Receiver</span></span>
                                    </label>
                                    <select name="cmbReceiver" class="form-control CH-Size-New" required id="cmbReceiver" onchange="PopulateOptions('cmbModule',this.value);" class="form-control">
                                        <option value="0" selected disabled>Choose One</option>
                                        <option value="TAXPAYER">Taxpayer</option>
                                        <option value="BPLO">Business Permits and Licensing Office</option>
                                        <option value="ASSESSOR">Assessors Office</option>
                                        <option value="TREASURY">Treasury Office</option>
                                    </select>
                                </div>
                                <div class="form-row col-md-6 m-0 row ">

                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Module</span></span>
                                    </label>
                                    <select name="cmbModule" required id="cmbModule" onchange="SelectModule(this.value);" class="form-control CH-Size-New">
                                    </select>
                                </div>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <input type="button" runat="server" id="btnModule" style="display: none;" />


                                    <hr />
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Subject</span></span>
                                    </label>
                                    <input type="text" runat="server" id="txtSubject" class="form-control CH-Size-New" />

                                    <br />

                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Header</span></span>
                                    </label>
                                    <input type="text" runat="server" id="txtHeader" class="form-control CH-Size-New" />

                                    <br />

                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Body</span></span>
                                    </label>
                                    <textarea class="form-control CH-Size-New" runat="server" id="txtBody" rows="10">

                            </textarea>

                                    <br />

                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Footer</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="txtFooter" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>


                    <div class="form-row col-md-6 m-0 row ">
                        <div class=" p-2">
                            <h6 class="m-2 font-weight-bold text-primary">Code
                            </h6>
                            <table>
                                <tr>
                                    <td>@TN </td>
                                    <td>= Taxpayer Name</td>
                                    <td>&nbsp&nbsp&nbsp</td>
                                    <td>@TDN </td>
                                    <td>= Tax Declaration Number</td>
                                </tr>
                                <tr>
                                    <td id="tdBR">< br > </td>
                                    <td>= New Line</td>
                                    <td>&nbsp&nbsp&nbsp</td>
                                    <td>@BIN </td>
                                    <td>= Business Identification Number</td>
                                </tr>
                                <tr>
                                    <td>@VL </td>
                                    <td>= Verification Link</td>
                                    <td>&nbsp&nbsp&nbsp</td>
                                    <td>@VB </td>
                                    <td>= Verification Button</td>
                                </tr>

                                <tr>
                                    <td>@EA </td>
                                    <td>= Email Address</td>
                                    <td>&nbsp&nbsp&nbsp</td>
                                    <td>@RMK </td>
                                    <td>= Remarks</td>
                                </tr>

                                <tr>
                                    <td>@AI </td>
                                    <td>= Application ID</td>
                                    <td>&nbsp&nbsp&nbsp</td>
                                    <td>@AN </td>
                                    <td>= Assessment Number</td>
                                </tr>


                            </table>
                            <br />
                            <br />
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>

                                    <div class="mb-2" runat="server" id="div_AdvanceSettings">

                                        <a class="nav-link text-primary" data-toggle="collapse" href="#_AdvanceSettings" role="button" aria-haspopup="true" aria-expanded="false" onclick="GridCollapse('AdvanceSettings')">General Setup
                                             <i class="fas fa-minus-circle fa-fw" id="AdvanceSettings"></i>
                                        </a>
                                        <!-- Dropdown - Messages -->
                                        <div class="collapse" id="_AdvanceSettings">
                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Color Theme</span></span>
                                            </label>
                                            <input type="color" id="txtColor" onchange="SelectColor(this.value);" class="form-control CH-Size-New" />
                                            <input type="button" runat="server" id="btnColor" style="display: none;" />

                                            <div class="form-input">
                                                <div class="preview">
                                                    <img id="file-ip-1-preview">
                                                </div>
                                                </br>
                                        <label for="file-ip-1">Upload Image</label>
                                                <input type="file" id="file-ip-1" accept="image/*" onchange="showPreview(event);">
                                            </div>

                                        </div>
                                    </div>
                                    <input type="button" class="btn btn-primary" runat="server" id="btnSave" value="Save" style="position: absolute; right: 20px; bottom: 0;" />



                                </ContentTemplate>
                            </asp:UpdatePanel>




                        </div>
                    </div>
                </div>
                <h6 class="m-2 font-weight-bold text-primary">Email Preview
                </h6>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div id="divPreview" runat="server" style="font-size: small">
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>



    <input type="hidden" runat="server" id="hdnReceiver" />
    <input type="hidden" runat="server" id="hdnModule" />
    <input type="hidden" runat="server" id="hdnColor" />
    <script>

        let text = document.getElementById("tdBR").innerHTML;
        document.getElementById("tdBR").innerHTML = text.replace(/ /g, '');


        function PopulateOptions(e, val) {
            document.getElementById('<%= txtSubject.ClientID%>').value = '';
            document.getElementById('<%= txtHeader.ClientID%>').value = '';
            document.getElementById('<%= txtBody.ClientID%>').value = '';
            document.getElementById('<%= txtFooter.ClientID%>').value = '';

            var select = document.getElementById(e);
            var length = select.options.length;
            for (i = length - 1; i >= 0; i--) {
                select.options[i] = null;
            }

            document.getElementById('<%= hdnReceiver.ClientID%>').value = val;

            if (val == 'TAXPAYER') {
                const select = document.querySelector(e);
                $('#' + e).append($('<option selected disabled>').val('0').text('Choose One'));
                $('#' + e).append($('<option>').val('SIGNUP').text('SignUp'));
                $('#' + e).append($('<option>').val('FORGOT').text('Forgot Password'));
                $('#' + e).append($('<option>').val('RESEND').text('Resend Validation Link'));
                $('#' + e).append($('<option>').val('EBP').text('Enrollment BP'));
                $('#' + e).append($('<option>').val('EBPA').text('Enrollment BP - Approved'));
                $('#' + e).append($('<option>').val('EBPR').text('Enrollment BP - Rejected'));
                $('#' + e).append($('<option>').val('ERPT').text('Enrollment RPT'));
                $('#' + e).append($('<option>').val('ERPTA').text('Enrollment RPT - Approved'));
                $('#' + e).append($('<option>').val('ERPTR').text('Enrollment RPT - Rejected'));
                $('#' + e).append($('<option>').val('NBP').text('New BP Application'));
                $('#' + e).append($('<option>').val('NBPA').text('New BP Application - Approved'));
                $('#' + e).append($('<option>').val('NBPR').text('New BP Application - Rejected'));
            }

            else if (val == 'BPLO') {
                const select = document.querySelector(e);
                $('#' + e).append($('<option selected disabled>').val('0').text('Choose One'));
                $('#' + e).append($('<option>').val('BPLO_EBP').text('BP Enrollment Notification'));
                $('#' + e).append($('<option>').val('BPLO_RBP').text('BP Renewal Notification'));
                $('#' + e).append($('<option>').val('BPLO_NBP').text('New BP Notification'));
            }
            else if (val == 'ASSESSOR') {
                const select = document.querySelector(e);
                $('#' + e).append($('<option selected disabled>').val('0').text('Choose One'));
                $('#' + e).append($('<option>').val('RPT_ERPT').text('RPT Enrollment Notification'));
            }
            else if (val == 'TREASURY') {
            }



        }

        function SelectModule(ModuleCode) {
            document.getElementById('<%= hdnModule.ClientID%>').value = ModuleCode;
            document.getElementById('<%= btnModule.ClientID%>').click();
        }

        function showPreview(event) {
            if (event.target.files.length > 0) {
                var src = URL.createObjectURL(event.target.files[0]);
                var preview = document.getElementById("file-ip-1-preview");
                preview.src = src;
                preview.style.display = "block";
            }
        }

        function SelectColor(Hex) {
            document.getElementById('<%= hdnColor.ClientID%>').value = Hex;
            document.getElementById('<%= btnColor.ClientID%>').click();
        }


        function GridCollapse(val) {
            if (document.getElementById(val).classList.contains("fa-minus-circle")) {
                document.getElementById(val).classList.remove("fa-minus-circle");
                document.getElementById(val).classList.add("fa-plus-circle");
            }
            else {
                document.getElementById(val).classList.remove("fa-plus-circle");
                document.getElementById(val).classList.add("fa-minus-circle");
            }
        }
    </script>

</asp:Content>
