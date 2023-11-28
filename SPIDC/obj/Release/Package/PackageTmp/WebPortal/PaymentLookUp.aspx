<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="PaymentLookUp.aspx.vb" Inherits="SPIDC.PaymentLookUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:100%;width:100%;">       
        <div class="col-12 mb-2" >
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Online Payment Look-Up</label>
                </div>
                <div class="card-body">
                    <span class="">Show</span>
                    <select runat="server" id="_oTxtShowEntries" onchange="__doPostBack('SearchBP',this.value);" class="">
                    </select>
                    Entries
            <input type="hidden" runat="server" id="_oTxtShowEntriesHdn" />
                 
                 
                </div>
            </div>
            </div>
         
    </div>
   
</asp:Content>