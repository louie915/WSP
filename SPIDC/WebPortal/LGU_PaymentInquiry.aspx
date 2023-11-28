<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="LGU_PaymentInquiry.aspx.vb" Inherits="SPIDC.LGU_PaymentInquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class=" p-2">
        <h5 class="m-2 font-weight-bold text-primary">Payment Inquiry</h5>
    </div>
    <div class="card shadow col-lg-12">
        <div class="card-body">
            <div class="form-row col-lg-4">
                <div class="form-group col-md-9">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Online Payment RefNo</span></span>
                        </label>
                        <textarea runat="server" id="txt_MerchantRefNo" class="form-control"></textarea>
                    </div>
                </div>
                <input type="button" id="_btnCheck" onclick="do_Check(this.id)" class="form-group btn btn-success col-md-3" value="Check" />
                <input type="button" style="display: none;" runat="server" id="btnCheck" />
            </div>
            <div class="form-row col-lg-12" runat="server" id="div_Result">
            </div>
        </div>
    </div>
    <input type="hidden" id="err" runat="server" />
    <script>
        function do_Check(ID) {
            document.getElementById(ID).disabled = true;
            document.getElementById(ID).value = 'Checking...';
            document.getElementById('<%= btnCheck.ClientID%>').click();
        }
    </script>
</asp:Content>
