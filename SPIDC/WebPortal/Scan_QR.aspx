<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="Scan_QR.aspx.vb" Inherits="SPIDC.Scan_QR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../CSS_JS_IMG/js/instascan.min.js"></script>
   <video id="preview" width="500px"></video>

    <input type="hidden" runat="server" id="txtScan" />
    <input type="button" runat="server" id="btnRender" />
    
    <script type="text/javascript">
        let scanner = new Instascan.Scanner({ video: document.getElementById('preview') });
        scanner.addListener('scan', function (content) {
            console.log(content);
            //  doPost(content);
            document.getElementById('<%= txtScan.ClientID%>').value = content;
            document.getElementById('<%= btnRender.ClientID%>').click();
        });
        Instascan.Camera.getCameras().then(function (cameras) {
            if (cameras.length > 0) {
                scanner.start(cameras[0]);
            } else {
                console.error('No cameras found.');
            }
        }).catch(function (e) {
            console.error(e);
        });
  
        function doPost(val) {
            let x;
            x = window.open("../DocViewer.aspx?docID=" & val, "", "width=290, height=140");
            x.moveTo(0, 0);
            window.close();
        }
    </script>
</asp:Content>
