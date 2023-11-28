<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="eORSetup.aspx.vb" Inherits="SPIDC.eORSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <center>      

    <div class="col-md-12 row ">
        <br /><br />
        <div class="col-lg-8 " style="text-align: left; ">
              <div class=" p-1"><h5 class="m-1 font-weight-bold text-primary">Electronic Official Receipt Report Setup</h5></div>
            <br />
            <table>
                <tr>
                    <td>LGU Name</td>
                    <td><input type="text" runat="server" class="form-control col-lg-12" id="txtlguName" /></td>
                </tr>
                 <tr>
                    <td>Office</td>
                    <td><input type="text" runat="server" class=" form-control col-lg-12" id="txtOffice" /></td>
                </tr>               
                <tr>
                    <td>Collecting Officer Name</td>
                    <td><input type="text" runat="server" class=" form-control col-lg-12" id="txtOfficerName" /></td>
                </tr>
                              
                  <tr>
                    <td>Electronic Signature</td>
                    <td>  <asp:FileUpload ID="FileUpload1" CssClass="upload-file" runat="server" /></td>
                </tr>
                <tr>
                    <td>Watermark</td>
                    <td>  <asp:FileUpload ID="FileUpload2" CssClass="upload-file" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2">  
              <Label ID="lblMessage" >Selected File/s Total Size : </Label>
                        <br />
                    </td>

                </tr>
                <tr>
                    <td colspan="2">  <input type="button" class="btn btn-primary col-lg-12"  value="Save" id="_btnUpload" onclick="do_Click(this.id);"/> </td>
                </tr>
              
            </table>
            
            
               
          
            <asp:Button ID="Button1" style="display:none;" Text="Upload" runat="server" OnClick="Upload" />
     
        
        </div>

         

       
    </div>
        </center>
    <div id="snackbar"></div>

    <input type="hidden" id="hdnFileID" runat="server" />
    <input type="hidden" id="hdnFileName" runat="server" />
    <input type="hidden" id="ANN_STATUS" runat="server" />
  <%--  <asp:Button ID="btnRemove" Style="display: none;" runat="server" OnClick="Remove" />--%>

    <script>

        $("document").ready(function () {
            $(".upload-file").on('change', function () {
                var totalSize = 0;
                $(".upload-file").each(function () {
                    console.dir(this);
                    for (var i = 0; i < this.files.length; i++) {
                        totalSize += this.files[i].size;
                    }
                });

                document.getElementById('lblMessage').innerText = 'Selected File/s Total Size : ' + fileSizeSI(totalSize);

                var valid = totalSize <= 10485760;
                if (!valid) {
                    alert('Over Max Size');
                    document.getElementById('<%= FileUpload1.ClientID%>').value = '';
                    document.getElementById('<%= FileUpload2.ClientID%>').value = '';
                    document.getElementById('lblMessage').innerText = 'Total Size : ';
                }

                // 
                // document.getElementById('lblMessage').innerText = 'Total Size : ';
            });
        })

        function fileSizeSI(size) {
            var e = (Math.log(size) / Math.log(1e3)) | 0;
            return +(size / Math.pow(1e3, e)).toFixed(2) + ' ' + ('kMGTPEZY'[e - 1] || '') + 'B';
        }

        function do_Click(ID) {
         <%--   if (document.getElementById('<%= FileUpload1.ClientID%>').value !== "" && document.getElementById('<%= FileUpload2.ClientID%>').value !== "") {--%>
                document.getElementById(ID).value = 'Saving ...';
                document.getElementById(ID).disabled = true;
                document.getElementById('<%= Button1.ClientID%>').click();
            //}
            //else { alert('No File Chosen'); }
        }
         
     



    </script>
</asp:Content>
