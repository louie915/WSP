<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/AbstractReportMaster.Master" CodeBehind="AbstractReport.aspx.vb" Inherits="SPIDC.AbstractReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <asp:ScriptManager runat="server" />
    <div class="col-4 shadow justify-content-center align-items-center mt-4 mx-4" style="padding-left: 0 !important; padding-right: 0 !Important;">
        <div class=" card-header bg-primary text-light col-lg-12">Abstract Report</div>
        <div class="card-body">

            <div class="col-sm-12 row ml-2">
                <div class="col-sm-12 mt-2 row">
                    <div class="col-sm-12 form-group">
                        <input type="checkbox" onchange="document.getElementById('checker').value = 0;document.getElementById('_oCmbSelectReport').disabled=document.getElementById('_oChkPresent').checked;document.getElementById('_oCmbSelectReport').style=(document.getElementById('_oChkPresent').checked?'background-color:lightgray':'background-color:white'); " class="checkbox" runat="server" id="_oChkPresent" />
                        <label id="Label2" style="color: #4975c3;" for="_oChkPresent"  runat="server">Total City Collection</label>
                    </div>
                </div>
                <div class="col-sm-12 row">
                    <div class="col-sm-12 form-group">

                        <label class="input-txt input-txt-active2"><span><span>Select Report</span></span></label>
                        <asp:DropDownList runat="server"  class="form-control CH-Size-new" name="_oCmbSelectReport" ID="_oCmbSelectReport" onchange="document.getElementById('checker').value = 0;">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                </div>
                <div class="col-sm-12 row">

                    <div class="col-sm-12 form-group">
                        <div>
                            <%--<label class="input-txt input-txt-active2"><span><span class="m-2"></span></span></label>--%>
                            <asp:DropDownList runat="server" class="form-control CH-Size-new" name="_oCmbAllfunds" ID="_oCmbAllfunds" onchange="document.getElementById('checker').value = 0;">
                                <asp:ListItem Value="" Text="All Funds"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div id="panel" class="col-sm-12  row">
                    <div class="col-sm-12 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">From <%--<span style="color: red">*</span>--%></span></span></label>
                            <input type="text" runat="server" class="form-control CH-Size-new" placeholder="mm/dd/yyyy" name="_oDtpFrom" id="_oDtpFrom" onchange="document.getElementById('checker').value = 0;"  min="1900-01-01" max="2999-12-31"  onfocus="this.type='date';"/>
                        </div>
                    </div>
                    <div class="col-sm-12 form-group ">
                        <div>
                            <label class="input-txt input-txt-active2"><span><span class="m-2">To <%--<span style="color: red">*</span>--%></span></span></label>
                            <input type="text" runat="server" class="form-control CH-Size-new" placeholder="mm/dd/yyyy" name="_oDtpTo" id="_oDtpTo"  onchange="document.getElementById('checker').value = 0;"  min="1900-01-01" max="2999-12-31"  onfocus="this.type='date';"/>
                        </div>
                    </div>
                </div>

                <div class="col-sm-12 form-group">
                    <div>
                        <input type="button" runat="server" class="btn btn-primary  " style="align-content: flex-end !Important" value="Process" onclick="prev_rep('view');" />
                        <%--<button id="hb" runat="server" hidden="hidden" class="btn btn-primary btn-circle" data-toggle="collapse" data-dismiss="collapse" data-target="#myModal1" "></button>--%>
                    </div>
                </div>
            </div>

        </div>

        <div class="modal fade" id="myModal1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true">
            <div class="modal-dialog modal-lg ">
                <div class="modal-content">

                    <div class="modal-header bg-primary text-light">
                        <h4 class="modal-title" style="color: white;" id="LabelPos" runat="server"></h4>
                        <label class="close" style="color: white;" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">×</span>
                        </label>
                    </div>

                    <asp:GridView ID="_oGridViewAppList" runat="server" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#4975c3" HeaderStyle-ForeColor="#FFFFFF" CssClass="vp mGrid" HeaderStyle-CssClass="vp" AllowSorting="true"
                        AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true" HeaderStyle-BorderStyle="None" GridLines="none" BorderStyle="None">
                        <Columns>

                            <asp:TemplateField HeaderText="Account No." Visible="false" HeaderStyle-Width="30%" HeaderStyle-CssClass="vp bg-primary text-light" ItemStyle-CssClass="vp">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelaccno" Visible="false" runat="server" Text='<%# Eval("accno")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Particular" HeaderStyle-Width="55%" HeaderStyle-CssClass="vp text-center bg-primary text-light" ItemStyle-CssClass="vp text-left pl-3">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabeldname" ForeColor="#222222" runat="server" Text='<%# Eval("dname")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="15%" HeaderStyle-CssClass="vp text-center bg-primary text-light" ItemStyle-CssClass="vp text-right pr-3">
                                <ItemTemplate>
                                    <asp:Label ID="_oLabelamount" ForeColor='<%# IIf(Eval("amount", "{0:C}").ToString().Replace("$", "") < "0", System.Drawing.Color.Red, System.Drawing.Color.FromArgb(22, 22, 22))%>' runat="server" Text='<%# Eval("amount", "{0:C}").ToString().Replace("$", "") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                    <div class="modal-footer" style="text-align: left">
                        <asp:Button runat="server" class="btn btn-primary" Style="" Text="Export to PDF" OnClientClick="prev_rep('pdf');"></asp:Button>

                        <label id="gt" runat="server" style="color: dimgray; font-size: larger; font-weight: 500">
                        </label>
                    </div>

                </div>
            </div>
        </div>

    </div>

    

    <%--    <div class="card-header shadow Color-White TextShadow" style="font-size: x-large; background-color: #4975c3">
        <asp:Label ID="Label1" Font-Size="Medium" runat="server">Abstract</asp:Label>
    </div>
    <div class="card-body form shadow" style="padding: 0rem">
        <div>
            <asp:GridView ID="_oGridViewAppList" runat="server" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#4975c3" HeaderStyle-ForeColor="#FFFFFF" CssClass="vp GRID" HeaderStyle-CssClass="vp" AllowSorting="true"
                AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true" HeaderStyle-BorderStyle="None" GridLines="none" BorderStyle="None">
                <Columns>

                    <asp:TemplateField HeaderText="Account No." Visible="true" HeaderStyle-Width="20%" HeaderStyle-CssClass="vp" ItemStyle-CssClass="vp">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelaccno" runat="server" Text='<%# Eval("accno")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Particular" HeaderStyle-Width="70%" HeaderStyle-CssClass="vp text-left pl-2" ItemStyle-CssClass="vp text-left pl-2">
                        <ItemTemplate>
                            <asp:Label ID="_oLabeldname" runat="server" Text='<%# Eval("dname")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="10%" HeaderStyle-CssClass="vp text-left" ItemStyle-CssClass="vp text-left">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelamount" runat="server" Text='<%# Eval("amount")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>
    </div>
    <div class="card-footer shadow" style="background-color: #d7d7d7">
    </div>--%>
    


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
        }

        function prev_rep(act) {
            //alert(act)

            if (document.getElementById("checker").value==1) {
                $("#myModal1").modal("show");
                return;
            }

            if (document.getElementById("_oDtpFrom").value == "" || document.getElementById("_oDtpTo").value == "") {
                document.getElementById("_oLabelSnackbar").innerText = 'Entry date cannot be empty..';
                Snackbar();
                return;
            }
            document.getElementById("checker").value = 1;
            document.getElementById("_oLabelSnackbargreen").innerText = 'Processing..';
            SnackbarGreen();
            __doPostBack(act);
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
