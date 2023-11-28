<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/AbstractReportMaster.Master" CodeBehind="BusinessComparativeCollection.aspx.vb" Inherits="SPIDC.BusinessComparativeCollection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <div class="col-4 shadow justify-content-center align-items-center mt-4 mx-4" style="padding-left: 0 !important; padding-right: 0 !Important;">
        <div class=" card-header bg-primary text-light col-lg-12">Business Comparative Collection</div>
        <div class="mx-1 mr-2 card-body">

                <div class="col-sm-12 row">
                    <div class="col-sm-12 form-group">

                        <input type="checkbox" class="checkbox" runat="server" id="_oChkPresent" onchange="document.getElementById('checker').value = 0;"/>
                        <label id="Label2" style="color: #4975c3" for="_oChkPresent" onclick="document.getElementById('_oChkPresent').value=true;" runat="server">Exclude FISC(RA 9514)</label>

                    </div>
                    <%--<div class="col-sm-12 form-group">
                    <div class="custom-control custom-checkbox">
                        <input type="checkbox" class="custom-control-input" id="_oCheckBoxSpecial" value="ticked" name="_oCheckBoxResident" />
                        <label runat="server" id="Label1" class="custom-control-label font-weight-light text-primary mb-1" for="_oCheckBoxResident">Special</label>
                    </div>
                </div>--%>
                    <%--<div class="col-sm-12 form-group">
                <div>--%>
                    <%--<label class="input-txt input-txt-active2"><span><span class="m-2"></span></span></label>--%>
                    <%--<asp:DropDownList runat="server" class="form-control CH-Size-new" name="_oCmbAllfunds" ID="_oCmbAllfunds">
                        <asp:ListItem Value="" Text="All Funds"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>--%>
                </div>
                <div class="col-sm-12 row">
                    <div class="col-sm-12 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">From <%--<span style="color: red">*</span>--%></span></span></label>
                            <input type="text" runat="server" required="required" placeholder="mm/dd/yyyy" class="form-control CH-Size-new" name="_oDtpFrom" id="_oDtpFrom"  min="1900-01-01" max="2999-12-31"  onfocus="this.type='date';"  onchange="document.getElementById('checker').value = 0;"/>
                        </div>
                    </div>
                    <div class="col-sm-12 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">To <%--<span style="color: red">*</span>--%></span></span></label>
                            <input type="text" runat="server" required="required" placeholder="mm/dd/yyyy" class="form-control CH-Size-new" name="_oDtpTo" id="_oDtpTo"  min="1900-01-01" max="2999-12-31"  onfocus="this.type='date';"  onchange="document.getElementById('checker').value = 0;" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-12 form-group">
                    <div class="col-sm-12 d-flex align-content-end">
                        <input type="button" runat="server" class="btn btn-primary" style="align-content: flex-end !Important" value="Process" onclick="prev_rep();" />
                        <%--<button id="hb" runat="server" hidden="hidden" class="btn btn-primary btn-circle" data-toggle="collapse" data-dismiss="collapse" data-target="#myModal1" "></button>--%>
                    </div>
                </div>
        </div>

    </div>

    <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true">
        <div class="modal-dialog modal-lg ">
            <div class="modal-content">

                <div class="modal-header bg-primary text-light" >
                    <h4 class="modal-title" style="color: white;" id="LabelPos" runat="server"></h4>
                    <label class="close" style="color: white;" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </label>
                </div>

                <asp:GridView ID="_oGridViewAppList" runat="server" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center"  CssClass="vp mGrid " HeaderStyle-CssClass="vp" AllowSorting="true" OnRowDataBound="_oGridViewAppList_RowDataBound"
                    AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true" HeaderStyle-BorderStyle="None" GridLines="none" BorderStyle="None">
                    <Columns>

                        <asp:TemplateField HeaderText="Particular" HeaderStyle-Width="40%" HeaderStyle-CssClass="vp text-center bg-primary text-light" ItemStyle-CssClass="vp text-left pl-3">
                            <ItemTemplate>
                                <asp:Label ID="_oLabeldname" ForeColor="#222222" runat="server" Text='<%# Eval("Particular")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Previous" HeaderStyle-Width="20%" HeaderStyle-CssClass="vp text-center bg-primary text-light" ItemStyle-CssClass="vp text-right pr-3">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelamountPre" ForeColor='<%# IIf(Eval("Prev", "{0:C}").ToString().Replace("$", "") < "0", System.Drawing.Color.Red, System.Drawing.Color.FromArgb(22, 22, 22))%>' runat="server" Text='<%# Eval("Prev")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Present" HeaderStyle-Width="20%" HeaderStyle-CssClass="vp text-center bg-primary text-light" ItemStyle-CssClass="vp text-right pr-3">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelamountPrs" ForeColor='<%# IIf(Eval("Pres", "{0:C}").ToString().Replace("$", "") < "0", System.Drawing.Color.Red, System.Drawing.Color.FromArgb(22, 22, 22))%>' runat="server" Text='<%# Eval("Pres")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Difference" HeaderStyle-Width="20%" HeaderStyle-CssClass="vp text-center bg-primary text-light" ItemStyle-CssClass="vp text-right pr-3">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelamountD" ForeColor='<%# IIf(Eval("Diff", "{0:C}").ToString().Replace("$", "") < "0", System.Drawing.Color.Red, System.Drawing.Color.FromArgb(22, 22, 22))%>' runat="server" Text='<%# Eval("Diff")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

                <div class="modal-footer">
                    <label id="gt" runat="server" style="color: dimgray; font-size: larger; font-weight: 500" data-dismiss="modal" aria-label="Close">
                    </label>
                </div>

            </div>
        </div>
    </div>



    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>

    <input type="hidden" runat="server" id="code1" />
    <input type="hidden" runat="server" id="checker" />

    <script lang="javascript">


        function formatDate(objectName) {

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

            today = mm + '-' + dd + '-' + yyyy;
            document.getElementById(objectName).type = 'date';
            document.getElementById(objectName).setAttribute("max", today);
            alert(objectName)
        }



        function prev_rep() {


            if (document.getElementById("checker").value == 1) {
                $("#myModal1").modal("show");
                return;
            }

            if (document.getElementById("_oDtpFrom").value == "" || document.getElementById("_oDtpTo").value == "") {
                document.getElementById("_oLabelSnackbar").innerText = 'Entry date cannot be empty..';
                Snackbar();
                return;
            }
            if (document.getElementById("_oDtpFrom").value.substring(0, 4) != document.getElementById("_oDtpTo").value.substring(0, 4)) {
                document.getElementById("_oLabelSnackbar").innerText = 'Exclusive year should have the same year...';
                Snackbar();
                return;
            }
            else {
                document.getElementById("checker").value = 1;
                document.getElementById("_oLabelSnackbargreen").innerText = 'Processing..';
                SnackbarGreen();
                __doPostBack('previewRep', '1');
            }
        }

        function HidePopup() {
            $("#myModal1").modal("show");
        }

        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 60000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);

            
        };
    </script>



</asp:Content>
