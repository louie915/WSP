<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="PaymentStatusInquiry.aspx.vb" Inherits="SPIDC.PaymentStatusInquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-row  col-lg-12">
        <div class=" form-group  col-lg-12">
            <div class=" p-1">
                <h5 class="m-1 font-weight-bold text-primary">Online Payment Status Inqury</h5>
            </div>
        </div>
        <div class=" form-group  col-lg-3">
            <label class="input-txt input-txt-active2">
                <span><span class="m-2"><b style="color: red; font-size: large">*&nbsp</b>Enter Reference No.</span></span>
            </label>
            <input type="text" runat="server" class="form-control CH-size-new" id="txtRefNo" />
        </div>
        <input type="button" class="btn btn-success form-group col-md-2" value="Check Status" runat="server" id="btnCheck" />

        <div class=" form-group form-row  col-lg-12">
            <div class=" form-group col-lg-5" runat="server" id="div_Result">
                a
            </div>
            <div class=" form-group col-lg-6" runat="server" id="div_Err">
                b
            </div>

        </div>
</asp:Content>
