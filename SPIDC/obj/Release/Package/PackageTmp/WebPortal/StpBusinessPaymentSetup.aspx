<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="StpBusinessPaymentSetup.aspx.vb" Inherits="SPIDC.StpBusinessPaymentSetup" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <style>
table, th, td {
  /*border: 1px solid black;*/
  text-align:center;
}
        .auto-style1 {
            height: 26px;
        }
    </style>
<table style="width:100%">
  <tr>
    <th class="auto-style1"></th>
    <th class="auto-style1">TOP</th> 
    <th class="auto-style1">LEFT</th>
  </tr>
  <tr>
<td>ORNumber</td>
<td>
    <asp:TextBox ID="_oTextBox_Or_Number_Top" runat="server"></asp:TextBox>
      </td>
<td>
    <asp:TextBox ID="_oTextBox_Or_Number_Left" runat="server"></asp:TextBox>
      </td>

<tr>
<td>Validation</td>
<td>
    <asp:TextBox ID="_oTextBox_Validation_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Validation_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>Table</td>
<td>
    <asp:TextBox ID="_oTextBox_Table_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Table_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>DateIssued</td>
<td>
    <asp:TextBox ID="_oTextBox_DateIssued_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_DateIssued_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>AmountInWord</td>
<td>
    <asp:TextBox ID="_oTextBox_AmountInWord_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_AmountInWord_Left" runat="server"></asp:TextBox>
    </td>
<tr>
<td></td>
<td> </td>
<td> <asp:Button ID="Button1" runat="server" Text="Save" />  </td>

</table>

</asp:Content>
