<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="StpCtcCorpSetup.aspx.vb" Inherits="SPIDC.StpCtcCorpSetup" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <style>
table, th, td {
  /*border: 1px solid black;*/
  text-align:center;
            margin-left: 40px;
        }
        .auto-style1 {
            height: 29px;
        }
    </style>
<table style="width:100%">
  <tr>
    <th></th>
    <th>TOP</th> 
    <th>LEFT</th>
  </tr>
  <tr>
<td>SRS</td>
<td>
    <asp:TextBox ID="_oTextBox_SRS_Top" runat="server"></asp:TextBox>
      </td>
<td>
    <asp:TextBox ID="_oTextBox_SRS_Left" runat="server"></asp:TextBox>
      </td>

<tr>
<td>OrNumber</td>
<td>
    <asp:TextBox ID="_oTextBox_Or_Number_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Or_Number_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>Year</td>
<td>
    <asp:TextBox ID="_oTextBox_Year_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Year_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>LguProfile</td>
<td>
    <asp:TextBox ID="_oTextBox_LguProfile_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_LguProfile_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td class="auto-style1">DateIssued</td>
<td class="auto-style1">
    <asp:TextBox ID="_oTextBox_DateIssued_Top" runat="server"></asp:TextBox>
    </td>
<td class="auto-style1">
    <asp:TextBox ID="_oTextBox_DateIssued_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>CompanyName</td>
<td>
    <asp:TextBox ID="_oTextBox_CompanyName_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_CompanyName_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>TIN</td>
<td>
    <asp:TextBox ID="_oTextBox_TIN_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_TIN_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>Address</td>
<td>
    <asp:TextBox ID="_oTextBox_Address_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Address_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>OrgKind	</td>
<td>
    <asp:TextBox ID="_oTextBox_OrgKind_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_OrgKind_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>PlaceofIncorporation</td>
<td>
    <asp:TextBox ID="_oTextBox_PlaceofIncorporation_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_PlaceofIncorporation_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>DateofIncorporation</td>
<td>
    <asp:TextBox ID="_oTextBox_DateofIncorporation_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_DateofIncorporation_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>BasicAmount</td>
<td>
    <asp:TextBox ID="_oTextBox_BasicAmount_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_BasicAmount_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>TaxAmount</td>
<td>
    <asp:TextBox ID="_oTextBox_TaxAmount_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_TaxAmount_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>Penalty</td>
<td>
    <asp:TextBox ID="_oTextBox_Penalty_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Penalty_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>TotAmount</td>
<td>
    <asp:TextBox ID="_oTextBox_TotAmount_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_TotAmount_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>DelFee</td>
<td>
    <asp:TextBox ID="_oTextBox_DelFee_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_DelFee_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>RPTIncome</td>
<td>
    <asp:TextBox ID="_oTextBox_RPTIncome_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_RPTIncome_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>BusIncome</td>
<td>
    <asp:TextBox ID="_oTextBox_BusIncome_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_BusIncome_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>RPTIncomeComputation</td>
<td>
    <asp:TextBox ID="_oTextBox_RPTIncomeComputation_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_RPTIncomeComputation_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>BusIncomeComputation</td>
<td>
    <asp:TextBox ID="_oTextBox_BusIncomeComputation_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_BusIncomeComputation_Left" runat="server"></asp:TextBox>
    </td>

<tr>

<td></td>
<td> </td>
<td> <asp:Button ID="Button1" runat="server" Text="Save" />  </td>

</table>

</asp:Content>
