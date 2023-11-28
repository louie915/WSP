<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="StpCtcIndSetup.aspx.vb" Inherits="SPIDC.StpCtcIndSetup" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <style>
table, th, td {
  /*border: 1px solid black;*/
  text-align:center;
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
    <asp:TextBox ID="_oTextBox_OrNumber_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_OrNumber_Left" runat="server"></asp:TextBox>
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
<td>DateIssued</td>
<td>
    <asp:TextBox ID="_oTextBox_DateIssued_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_DateIssued_Left" runat="server"></asp:TextBox>
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
<td>LastName</td>
<td>
    <asp:TextBox ID="_oTextBox_LastName_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_LastName_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>FirstName</td>
<td>
    <asp:TextBox ID="_oTextBox_FirstName_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_FirstName_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>MiddleName</td>
<td>
    <asp:TextBox ID="_oTextBox_MiddleName_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_MiddleName_Left" runat="server"></asp:TextBox>
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
<td>Gender</td>
<td>
    <asp:TextBox ID="_oTextBox_Gender_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Gender_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>Citizenship</td>
<td>
    <asp:TextBox ID="_oTextBox_Citizenship_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Citizenship_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>BirthPlace</td>
<td>
    <asp:TextBox ID="_oTextBox_BirthPlace_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_BirthPlace_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>Occupation</td>
<td>
    <asp:TextBox ID="_oTextBox_Occupation_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_Occupation_Left" runat="server"></asp:TextBox>
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
<td>TotalAmount</td>
<td>
    <asp:TextBox ID="_oTextBox_TotalAmount_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_TotalAmount_Left" runat="server"></asp:TextBox>
    </td>

<tr>
<td>CivilStatus</td>
<td>
    <asp:TextBox ID="_oTextBox_CivilStatus_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_CivilStatus_Left" runat="server"></asp:TextBox>
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
<td>ProfIncome</td>
<td>
    <asp:TextBox ID="_oTextBox_ProfIncome_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_ProfIncome_Left" runat="server"></asp:TextBox>
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
<td>ProfIncomeComputation</td>
<td>
    <asp:TextBox ID="_oTextBox_ProfIncomeComputation_Top" runat="server"></asp:TextBox>
    </td>
<td>
    <asp:TextBox ID="_oTextBox_ProfIncomeComputation_Left" runat="server"></asp:TextBox>
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
