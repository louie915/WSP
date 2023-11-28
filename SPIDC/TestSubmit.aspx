<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestSubmit.aspx.vb" Inherits="SPIDC.TestSubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form runat="server">

  
    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
<asp:Button ID="btnConvert" runat="server" Text="Convert" OnClick="btnConvert_Click" />
<asp:Label ID="lblAmountInWords" runat="server"></asp:Label>
          </form>
</body>
</html>
