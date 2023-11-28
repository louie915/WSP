<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="ChangeUserPassword.aspx.vb" Inherits="SPIDC.ChangeUserPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <div id="snackbar" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbar"/>           
                </div>
                <div id="snackbargreen" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="form-row justify-content-center align-items-center form mb-0">
        <div class="col-sm-6">
            <br />
            <br />
            <br />
            <div class="card shadow">
                <div class="card-header">
                    <div class="form-inline">
                        <i class="fas fa-lock text-primary" style="font-size: 20px;"></i>
                        &nbsp;&nbsp;&nbsp;
                        <h1 class="h5 mb-0 text-gray-800">Change User Password</h1>
                    </div>
                </div>
                <div class="card-body">
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">New Password:</p>
                    <input type="password" class="form-control form-control-user CH-size" id="_oTextboxNewPass" placeholder="Enter New Password" required/><br />
                    <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Confirm New Password:</p>
                    <input type="password" class="form-control form-control-user CH-size" id="_oTextboxNewPass2" placeholder="Confirm New Password" required/>
                </div>
                <div class="card-footer">
                    <div class="">
                        <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Security Question:</p>
                        <textarea runat="server" class="form-control form-control-user CH-size" id="_oTextSecurityQuestion" name="_oTextBirthAddress" rows="2" required></textarea>
                        <br />
                        <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Answer:</p>
                        <input runat="server" type="text" class="form-control form-control-user CH-size" id="_oTextAnswer" placeholder="Enter your answer" required/><br />
                    </div>
                    <div align="center">
                        <button class="btn btn-sm col-xl-3 btn-primary" onclick="do_save('Save');" id="_oBtnChangePassword" runat="server">Change Password</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField id="pw" runat="server"/>
    <asp:HiddenField id="cfrmpw" runat="server"/>

    <script>
        document.getElementById('<%=_oTextSecurityQuestion.ClientID%>').disabled = true;

        function do_save(Action) {
            document.getElementById('<%=pw.ClientID%>').value = document.getElementById('_oTextboxNewPass').value;
            document.getElementById('<%=cfrmpw.ClientID%>').value = document.getElementById('_oTextboxNewPass2').value;
            var p1 = document.getElementById('_oTextboxNewPass').value;
            var p2 = document.getElementById('_oTextboxNewPass2').value;
            var result = p1.localeCompare(p2);
            switch (result) {
                case 0: // Password OK                    
                    document.getElementById('_oTextboxNewPass2').setCustomValidity("");
                    __doPostBack(Action, p2);
                    break;
                default: // Passwords don't match             
                    document.getElementById('_oTextboxNewPass2').setCustomValidity("Passwords don't match");
                    document.getElementById('_oTextboxNewPass2').reportValidity()

            }
        }
    </script>
      
</asp:Content>

