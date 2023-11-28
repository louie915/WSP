<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="TreasuryORSending.aspx.vb" Inherits="SPIDC.TreasuryORSending" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="padding: 10px">
        <div class="col-sm-12 mb-2">
            <div class="card shadow">
                <center>
                    <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Official Receipt Sending</label>
                </div>
                </center>

                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-5">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Transaction Type</span></span>
                                </label>
                                <select required name="cmbType" class="form-control CH-size-new" onchange="do_Select(this.value)" id="cmbType">
                                    <option value="BP">Business Permit</option>
                                    <option value="RPT">Real Property</option>
                                </select>
                            </div>
                        </div>

                        <div class="form-group form-group-sm col-md-5">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2" id="lblAcctDesc">Enter BIN</span></span>
                                </label>
                                <input required type="text" class="form-control CH-size-new" runat="server" name="txtAcctNo" id="txtAcctNo" />
                            </div>
                        </div>
                        <div class="form-group form-group-sm col-md-2">
                            <div>
                                <input type="button" class="btn btn-primary form-group col-md-12" value="Search" name="btnSearch" id="btnSearch" onclick="do_Search()" />
                                <input type="button" id="_btnSearch" runat="server" style="display: none;" />

                            </div>
                        </div>
                    </div>
                    <div runat="server" id="divNotice" style="color:orangered;text-align:center;display:none;">Account is not yet Enrolled.</div>
                    <hr />
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Taxpayer Name</span></span>
                                </label>
                                <label style="text-align: center" class="form-control CH-size-new" id="lblTaxpayerName" runat="server"></label>
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group form-group-sm col-md-12">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Taxpayer Email Address</span></span>
                                </label>
                                <input required type="email" style="text-align: center" class="form-control CH-size-new" runat="server" id="txtEmail" />
                            </div>
                        </div>
                    </div>
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Email Subject</span></span>
                                </label>
                                <input required type="text" class="form-control CH-size-new" style="text-align:center" id="txtSubject" runat="server" value="Copy of Official Receipt" />
                            </div>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Email Body</span></span>
                                </label>
                                <textarea required class="form-control CH-size-new" rows="7" runat="server" id="txtBody">
To our Valued Taxpayer,
Attached to this email is the copy of your Official Receipt.</textarea>
                            </div>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Upload Copy of Official Receipt</span></span>
                                </label>                          
                                <input required type="file" class="form-control CH-size-new upload-file" runat="server" id="FileUpload1" />
                            </div>
                        </div>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <div>
                                <input type="button" class="btn btn-primary col-md-12" value="Send" id="btnSend" onclick="do_Send();" />
                                <input type="button" id="_btnSend" runat="server" style="display: none;" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-sm-8 mb-2" style="display:none;">
            <div class="card shadow">
                <center>
                    <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">History</label>
                </div>
                </center>

                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-md-12">
                            <div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" runat="server" id="hdnType" value="BP"/>
    <input type="hidden" runat="server" id="hdnAcctNo" />
    <script>
        function do_Select(val) {
            if (val == 'BP') {
                document.getElementById('lblAcctDesc').innerText = 'Enter BIN';
            }
            else if (val == 'RPT') {
                document.getElementById('lblAcctDesc').innerText = 'Enter TDN';
            }          
            document.getElementById('<%= hdnType.ClientID%>').value = val;
        }
        function do_Search() {

            var isValid;
            isValid = document.getElementById('<%= txtAcctNo.ClientID%>').reportValidity();
            if (isValid == false) { return; }
            else {
                document.getElementById('btnSearch').value = 'Searching...';
                document.getElementById('btnSearch').disabled = true;
                document.getElementById('<%= _btnSearch.ClientID%>').click();
            }

        }

        function do_Send() {
            var isValid;
            isValid = document.getElementById('<%= txtAcctNo.ClientID%>').reportValidity();
            if (isValid==false) {return;}
            isValid = document.getElementById('<%= txtEmail.ClientID%>').reportValidity();
            if (isValid == false) { return; }
            isValid = document.getElementById('<%= txtSubject.ClientID%>').reportValidity();
            if (isValid == false) { return; }
            isValid = document.getElementById('<%= txtBody.ClientID%>').reportValidity();
            if (isValid == false) { return; }      
            isValid = document.getElementById('<%= FileUpload1.ClientID%>').reportValidity();
            if (isValid == false) { return; }

            if (isValid == true) {
                document.getElementById('btnSend').disabled = true;
                document.getElementById('btnSend').value = 'Sending ... ';

               // alert('ok');
                  document.getElementById('<%= _btnSend.ClientID%>').click();
            }
            // alert(isValid);
        }
    </script>
</asp:Content>
