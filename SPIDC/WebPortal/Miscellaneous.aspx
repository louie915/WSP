<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="Miscellaneous.aspx.vb" Inherits="SPIDC.Miscellaneous" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

     <style>
       select[multiple] {
  background:none;
  width:auto;
  height:auto;
  padding:0;
  margin:0;
  border-width: 2px;
  border-style: inset;
  -moz-appearance: menulist;
  -webkit-appearance: menulist;
  appearance: menulist;
}
   </style>
   
   <div style="width:100%;background-color:red;color:white;text-align:center"> 
       This page is under maintenance
   </div>
  
     <div class="form-row justify-content-center align-items-center form mb-0">
        <div class="col-sm-8">
         
            <div class="card shadow">
                <div class="card-header">
                    <div class="form-row form">
                        <div class="col-sm-6">
                            <h1 class="h5 mb-0 text-gray-800" id="_oLabelSwitch">Miscellaneous</h1>
                        </div>                       
                    </div>
                </div>
                <div class="card-body">
                    <form id="frmNone"></form>
                    <form frm="frmPayNow" method="post" onsubmit="do_submit();">
                    <div class="form-row form">
                                               <div class="col-sm-12">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Select Transaction</p>
                       
      <select  id="_oSelectCategory"  required runat="server" class="form-control" style="font-size: 13px; line-height:20px" onchange="do_select_category(this.value);">
        </select>
                                                   <br />
    <select  id="_oSelectSpecific" name="_oSelectSpecific"  required runat="server" class="form-control" style="font-size: 13px; line-height:20px" onchange="do_select_specific(this.value);">
        </select>                
                    
                        <div class="col-sm-6">
                            <br />
                          
                            <label class="mx-2 text-capitalize font-weight-bold" style="font-size:20px;text-align:right">Total Amount Due:
                                <label class="mx-2 my-auto border border-bottom-light rounded-lg" id="_oLabelTotalAmount" style="font-size:25px;" runat="server">0.00</label>
                                </label>
                        </div>            
                        <input type="hidden" id="Service" name="Service" value="Miscellaneous" />
                        <input type="hidden" id="GroupCd" name="GroupCd"  />
                        <input type="hidden" id="AcctNo" name="AcctNo"  /> 
                        <input type="hidden" id="Description" name="Description" />              
                        <input type="hidden" id="Fee" name="Fee" value="0"/>
                        <input type="hidden" id="totalAmount" name="totalAmount" value="0"/>                   

                        <div class="col-sm-6" align="center">                          
                       <%--<input type="submit" formaction="PayNow.aspx" class="btn btn-primary btn-sm" value="Proceed to Payment" id="btnPayNow"/>--%>
                       <input type="button" value="Submit Application" />
                             </div>
                    </div>
                  
                </div>
            </div>
        </div>
    </div>
    

    <script>              

      document.getElementById('<%= _oSelectSpecific.ClientID%>').disabled = true;
   


        function do_select_category(val) {          
          //  document.getElementById('<%= _oLabelTotalAmount.ClientID%>').innerHTML = formatMoney(totalAmount); //totalAmount.toFixed(2);
            
            document.getElementById('<%= _oSelectSpecific.ClientID%>').value='';
          
            var cmb1 = document.getElementById('<%= _oSelectCategory.ClientID%>').value;
            var cmb2 = document.getElementById('<%= _oSelectSpecific.ClientID%>');
            document.getElementById('<%= _oSelectSpecific.ClientID%>').disabled = false;
            for (var i = 0; i < cmb2.length; i++) {
                var txt = cmb2.options[i].value.substring(0, 2);       
                if (!txt.match(cmb1)) {                
                    $(cmb2.options[i]).attr('disabled', 'disabled').hide();
                }
                else {
                    $(cmb2.options[i]).removeAttr('disabled').show();
                }
            }
         
        }

        function do_select_specific(val){
            var part = val.split('_', 4);
            document.getElementById('GroupCd').value = part[0];
            document.getElementById('AcctNo').value = part[1];
            document.getElementById('Description').value = part[2];
            document.getElementById('Fee').value = part[3];
            alert(val);

        }



    </script>
  
   </div>

   
</asp:Content>