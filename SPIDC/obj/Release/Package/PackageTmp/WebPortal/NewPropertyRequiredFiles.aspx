<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="NewPropertyRequiredFiles.aspx.vb" Inherits="SPIDC.NewPropertyRequiredFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="p-1">
        <h5 class="m-2 font-weight-bold text-primary">Declaration of New Property</h5>
    </div>
    <div class="m-2">
                        
        <div class="row mt-3 mx-auto col-lg-10">
            <div class="p-1 col-12 mb-2">
                <p class="m-2 font-weight-bold">Upload the following attachments: </p>
                <p class="m-2" style="text-align:left !Important">Supported file Extensions (.png,.jpg,.pdf)</p>
            </div>           
            <div class="form-group col-md-6 ">

                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Deed of sale </span></span>
                    </label>
                    <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtDeedofsale" required/>
                </div>


            </div>
            <div class="form-group col-md-6 ">

                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Copy of Title</span></span>
                    </label>
                    <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtCopyofTitle" required/>
                </div>


            </div>
            <div class="form-group col-md-6 ">

                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">ECAR (BIR) Proof of Payment</span></span>
                    </label>
                    <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtProofofPayment" required/>
                </div>


            </div>
            <div class="form-group col-md-6 ">

                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Tax Clearance</span></span>
                    </label>
                    <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtTaxClearance" required/>
                </div>


            </div>
            <div class="form-group col-md-6 ">

                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Declaration Copy</span></span>
                    </label>
                    <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtDeclarationCopy" required/>
                </div>


            </div>
            <div class="form-group col-md-6 ">

                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Secretary Certificate for Corporate property</span></span>
                    </label>
                    <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtCorporateProperty" required/>
                </div>


            </div>
            <div class="form-group col-md-6 ">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Valid ID</span></span>
                    </label>
                    <input type="file" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtValidID" required/>
                </div>
            </div>
            <div class="col-md-12 d-flex align-content-center justify-content-center">                
                  <asp:Button ID="_oBtnContinue" runat="server" Text="Continue" CssClass="btn btn-primary" href="NewProperty.aspx"/>
            </div>
        </div>       

    </div>
  
</asp:Content >

