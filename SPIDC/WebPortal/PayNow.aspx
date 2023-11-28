<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="PayNow.aspx.vb" Inherits="SPIDC.PayNow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
  
    <style>
#customers {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#customers td, #customers th {
  border: 1px solid #ddd;
  padding: 8px;
}

#customers tr:nth-child(even){background-color: #f2f2f2;}

#customers tr:hover {background-color: #ddd;}

#customers th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #5373DB;
  color: white;
}
</style>

    <script>
        //SNACKBAR - Welcome       
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

    </script>
    <asp:ScriptManager runat="server">
        
    </asp:ScriptManager>

 
      <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>

      <!-- Modal Mandaue LBP Payment Instruction -->
      <div id="ModalMandauePaymentInstruction" class="modal fade" style="z-index:1100 !important" >
        <div class="modal-dialog modal-md">
          <div class="modal-content">
            <div class="modal-header  bg-primary">
              <h4 class="modal-title text-white">Payment Instruction</h4> 
                 <a href="Account.aspx" class="close" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </a>           
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
                  <center>
        <div class="form-group col col-md-12" style="display:inline-block">
          
             <div class="w3-panel  w3-pale-blue">              
                <p>Upon clicking [PROCEED], you will be redirected to LandBank ePayment Page.<br>
                   You will be asked to enter the following details:<br>
                </p>
              </div> 
              
           <table id="customers">
                <tr>
                    <th colspan="2"> Payment Details</th>                    
                </tr>
                <tr>
                    <td>Transaction Type</td>
                    <td runat="server" id="td_TransactionType"></td>
                </tr>
                <tr>
                    <td>Amount</td>
                    <td runat="server" id="td_Amount" style="text-align:right"></td>
                </tr>
                <tr>
                    <td>Description</td>
                    <td runat="server" id="td_Description"></td>
                </tr>
                <tr>
                    <td>Tax Declaration Number</td>
                    <td runat="server" id="td_AssessmentNo"></td>
                </tr>
                <tr>
                    <td>Online ID</td>
                    <td runat="server" id="td_OnlineID"></td>
                </tr>
            </table>
           
        </div>
                      <br />
                      <asp:UpdatePanel runat="server">
                          <ContentTemplate>
                                <input type="button" class="btn btn-primary btn-sm col col-md-5"  value="Proceed" runat="server" id="btnProceed"/>
                          </ContentTemplate>
                            </asp:UpdatePanel>
                     
                  </center>    
          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


        <div class="" style="width:100%; z-index:-1;margin-top:10px">
  <ul class="list-unstyled multi-steps">
    <li runat="server" id="txtInitial">Start</li>   
    <li class="is-active">Payment</li>
    <li class="is-active" >Complete</li>      
  </ul>
</div>
       
    <div class="container">
        <div class="row">
            <div class="col-sm-9 col-md-7 col-lg-6 mx-auto">
                <h5 class="m-2 font-weight-bold text-primary">Online Payment</h5>   
                <div class="card card-signin mb-5">
                    <div class="card-body">

                        <div class="row">
                            <div class="form-group col-md-12">

                                <div class="form-group m-2">
                                    <div>

                                        <label class="input-txt input-txt-active">
                                            <span><span class="m-2">Transaction Type</span></span>
                                        </label>
                                        <input type="text" required runat="server" name="_oTxtTransacType" readonly class="form-control CH-Size" id="_oTxtTransacType" />

                                    </div>
                                </div>
                            </div>
                            <div class=" col-md-12 row mx-auto">
                                <div class="col-md-6 mb-4">
                                    <div class="">
                                        <div>

                                            <label class="input-txt input-txt-active">
                                                <span><span class="m-2" runat="server" id="BIN_ASSSESSNO">Account Number</span></span>
                                            </label>
                                            <input type="text" required runat="server" name="_oTxtAccNo" readonly class="form-control CH-Size" id="_oTxtAccNo" />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6 mb-4">
                                    <div class="">
                                        <div>

                                            <label class="input-txt input-txt-active">
                                                <span><span class="m-2">Amount</span></span>
                                            </label>
                                            <input type="text" required runat="server" name="_oTxtAmount" readonly class="form-control CH-Size" id="_oTxtAmount" />
                                        </div>
                                    </div>
                                </div>



                            </div>
                            <br>
                            <br>
                            <hr />
                            <h6 class="m-2" style="text-align: left">Select Payment Method</h6>

                            <div class="col-lg-12 row">
                                <div class="col-sm-12 justify-content-center">
                                    <div class=" align-items-center row m-1"  runat="server" id="div_DBP" >
                                        <input type="radio" onclick="SelectBank(this.id);"  name="ChooseBank"   value="DBP" id="RadDbp" class="">
                                        <label for="RadDbp" class="my-auto">&nbsp Development Bank of the Philippines</label>
                                    </div>

                                       <div class=" align-items-center row m-1" runat="server" id="div_OTC" >
                                        <input type="radio" onclick="SelectBank(this.id);"  name="ChooseBank" value="OTC" id="RadOTC" class="">
                                        <label for="RadOTC" runat="server" id="lbl_OTC" class="my-auto">&nbsp Over the Counter Payment (City/Municipal Hall)</label>
                                    </div>

                                    <div class=" align-items-center row m-1" runat="server" id="div_LBP" >
                                        <input type="radio" onclick="SelectBank(this.id);" name="ChooseBank"   value="LBP" id="RadLBP" class="">
                                        <label for="RadLBP" id="lblLBP" class="my-auto">&nbsp LandBank of the Philippines / Other Bancnet</label>
                                    </div>    

                                      <div class=" align-items-center row m-1" runat="server" id="div_LBP2" >
                                        <input type="radio" onclick="SelectBank(this.id);" name="ChooseBank"   value="LBP" id="RadLBP2" class="">
                                        <label for="RadLBP2" id="lblLBP2" class="my-auto">&nbsp LandBank of the Philippines / Other Bancnet</label>
                                    </div>    

                                     <div class=" align-items-center row m-1" runat="server" id="div_PayMaya" >
                                        <input type="radio" onclick="SelectBank(this.id);" name="ChooseBank"   value="PayMaya" id="RadPayMaya" class="">
                                        <label for="RadPayMaya" id="lblPayMaya" class="my-auto">&nbsp PayMaya [Debit/Credit Cards]</label>
                                    </div>  
                                    
                                      <div class=" align-items-center row m-1" runat="server" id="div_PayMaya2" >
                                        <input type="radio" onclick="SelectBank(this.id);" name="ChooseBank"   value="PayMaya2" id="RadPayMaya2" class="">
                                        <label for="RadPayMaya2" id="lblPayMaya2" class="my-auto">&nbsp PayMaya [E-Wallets]</label>
                                    </div>    

                                 
                                       <input type="hidden" runat="server" id="_err" name="_err" />
                                    <script>
                                        var str = window.location.href;
                                        var n = str.includes("122.53.27.82");
                                        var m = str.includes("mandaue");
                                        if (n == true || m == true) {

                                            document.getElementById("lblLBP").innerHTML = '&nbsp Online Payment through Link.BizPortal';
                                        }
                                    </script>
                                
                                    <div class=" align-items-center row m-1"  runat="server" id="div_GCASH" >
                                        <input type="radio" onclick="SelectBank(this.id);"  name="ChooseBank"   value="GCash" id="RadGCash" class="">
                                          <label for="RadGCash" class="my-auto">&nbsp GCash</label>
                                    </div>


                                      <div class=" align-items-center row m-1"  runat="server" id="div_SPIDCPay" >
                                        <input type="radio" onclick="SelectBank(this.id);"  name="ChooseBank"   value="SPIDCPay" id="RadSPIDCPay" class="">
                                          <label for="RadSPIDCPay" class="my-auto">&nbsp SPIDCPay</label>
                                    </div>

                                    <div class=" align-items-center row m-1" style="display:none"  runat="server" id="div_ITBS" >
                                        <input type="radio" onclick="SelectBank(this.id);"  name="ChooseBank"   value="ITBS" id="RadITBS" class="">
                                          <label for="RadITBS" class="my-auto">&nbsp Online Payment</label>
                                    </div>

                                    <br />

                                </div>
                                <input type="hidden" id="hdnSelectedBank" runat="server" value="OTC" />
                            </div>
                            <script>
                                function SelectBank(id) {
                                    // alert(id);
                                    if (document.getElementById(id).checked == true) {
                                        val = document.getElementById(id).value;
                                        document.getElementById('<%=hdnSelectedBank.ClientID%>').value = val;
                                    }

                                  <%--  function PayNow() {
                                        var selectedBank = document.getElementById('<%=hdnSelectedBank.ClientID%>').value;     
                                        alert(selectedBank);
                                            __doPostBack('PayNow', selectedBank);
                               
                                    }--%>
                                }
                            </script>


                            <hr />
                         
                                <button runat="server" id="btnPayNow" class="btn btn-primary col-lg-12" onclick="NextPage();">Pay Now</button>
                          
                            <div  id="divPayImg" runat="server" style="display:none;">
                                 <img width="100%" src="../CSS_JS_IMG/img/payments.png" />
                                 </div>
                           </div>
                       <input type="checkbox" runat="server" id="_cbredirect" style="display:none"/>
                    </div>
                </div>
            </div>
        </div>

    </div>
  <script>
      function openModal() {
          $('#ModalMandauePaymentInstruction').modal('show');
      }

  </script>
</asp:Content> 