<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="Update.aspx.vb" Inherits="SPIDC.Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input type="button"  class="btn btn-primary" id="btnUpdate" value="Check for Updates" onclick="do_Update(this.id)" /> 
    <label runat="server" id="lblRemarks"></label>
    <br />
    <input type="button" runat="server" id="_btnUpdate"/>
   <div runat="server" id="divStatus">

   </div>

    <script>
        function do_Update(ele) {
            document.getElementById(ele).value = 'Checking for Updates ...'
            document.getElementById('<%= _btnUpdate.ClientID%>').click();
        }
        

    </script>
</asp:Content>
