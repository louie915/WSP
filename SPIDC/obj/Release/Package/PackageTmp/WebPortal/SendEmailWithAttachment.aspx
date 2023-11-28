<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="SendEmailWithAttachment.aspx.vb" Inherits="SPIDC.SendEmailWithAttachment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <table>
      <tr>
          <td>To</td>
          <td><asp:TextBox ID="txtTo" runat="server" ></asp:TextBox></td>
      </tr>
            <tr>
          <td>Subject</td>
          <td><asp:TextBox ID="txtSubject" runat="server"></asp:TextBox></td>
      </tr>
            <tr>
          <td>Body</td>
          <td><asp:TextBox ID="txtBody" runat="server" TextMode = "MultiLine" Height = "150" Width = "200"></asp:TextBox></td>
      </tr>
            <tr>
          <td>Attachment</td>
          <td><asp:FileUpload ID="fuAttachment" runat="server" /></td>
      </tr>
            <tr>
          <td>Host</td>
          <td><asp:TextBox ID="txtHost" placeholder="smtp.gmail.com" runat="server"></asp:TextBox></td>
      </tr>
            <tr>
          <td>Port</td>
          <td><asp:TextBox ID="txtPort" placeholder="587/465"  runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <td>Sender Email</td>
          <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
          <td>Sender Password</td>
          <td><asp:TextBox ID="txtPassword" runat="server" TextMode = "Password"></asp:TextBox></td>
      </tr>
       <tr>
          <td>SSL</td>
          <td><asp:TextBox ID="txtSSL" runat="server" placeholder="1/0"></asp:TextBox></td>
      </tr>
      

  </table>
            <asp:Button Text="Send" OnClick="SendEmail" runat="server" />
           

</asp:Content>
