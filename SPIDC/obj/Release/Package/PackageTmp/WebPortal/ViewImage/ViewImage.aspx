<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ViewImage.aspx.vb" Inherits="SPIDC.ViewImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <center>
      <b>File Name: </b>  <asp:Label ID="_oLabel_FileName" runat="server" Text="Label" Font-Bold="true"></asp:Label>
         <br />
         <br />
       <div id="viewer" class="viewer">
            <asp:Image ID="Image1" runat="server" class="viewer" />
             <asp:Image ID="Image2" runat="server" Visible="false"  ImageUrl="../../CSS_JS_IMG/img/No%20Preview.png"/>
        </div>
         <br />
             <asp:Button runat="server" CssClass="button  ButtonCss"  Text="Download"  autopostback="true" OnClick="_InitDownload" />
         <br />
         </center>
    </div>
    </form>
</body>
</html>
