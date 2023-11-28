<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="ImgUpload.aspx.vb" Inherits="SPIDC.ImgUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Image Manager</h1>
     <center>
         <div class="col-md-12 row "> 
                     <div class="col-lg-6 mt-2" style="text-align:left">   
                        <table>
                            <tr><td>SOA Logo</td><td>  <input type="file" id="up1" runat="server" />  </td></tr>
                            <tr><td>Email Banner</td><td>  <input type="file" id="up2" runat="server" />  </td></tr>
                        </table>                                
                                     
                     </div>
           
                   
                 </div>
            </center>
                <div class="col-md-10"> <br />
                           <input  type="button"  value="Save Changes" runat="server" id="btnUpload" />
                            </div>
</asp:Content>
