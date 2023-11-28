<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Sample.aspx.vb" Inherits="SPIDC.Sample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>GridView Select Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false">

        <Columns>

        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

        <asp:TemplateField HeaderText="Header 1">

            <ItemTemplate>

                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Header 2">

            <ItemTemplate>

                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            </ItemTemplate>

        </asp:TemplateField>

        <asp:TemplateField HeaderText="Header 3">

            <ItemTemplate>

                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

            </ItemTemplate>

            <FooterStyle HorizontalAlign="Right" />

            <FooterTemplate>

             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" />

            </FooterTemplate>

        </asp:TemplateField>

        </Columns>

</asp:gridview>
    </form>  
  </body>
</html>
