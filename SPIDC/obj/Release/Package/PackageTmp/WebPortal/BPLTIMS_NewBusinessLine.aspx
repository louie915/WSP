<%@ Page Language="vb" AutoEventWireup="false"   MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="BPLTIMS_NewBusinessLine.aspx.vb" Inherits="SPIDC.BPLTIMS_NewBusinessLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <script>
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };
    </script>

     <script src="http://code.jquery.com/jquery-1.5.js"></script>
                    <script>
                        function countChar(val) {
                            var len = val.value.length;
                            if (len >= 500) {
                                val.value = val.value.substring(0, 500);
                            } else {
                                $('#charNum').val(500 - len);
                            }
                        };

                        function FormatCurrency(ctrl) {
                            //Check if arrow keys are pressed - we want to allow navigation around textbox using arrow keys
                            if (event.keyCode == 37 || event.keyCode == 16 || event.keyCode == 38 || event.keyCode == 39 || event.keyCode == 40) {
                                return;
                            }

                            var val = ctrl.value;

                            val = val.replace(/,/g, "")
                            ctrl.value = "";
                            val += '';
                            x = val.split('.');
                            x1 = x[0];
                            x2 = x.length > 1 ? '.' + x[1] : '';

                            var rgx = /(\d+)(\d{3})/;

                            while (rgx.test(x1)) {
                                x1 = x1.replace(rgx, '$1' + ',' + '$2');
                            }

                            ctrl.value = x1 + x2;

                        };
                    </script>

    <script>
        function RemoveBusinessLine(Action, BusinessId) {
            __doPostBack(Action, BusinessId);
        }
    </script>   



    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="snackbar" style="position: absolute">
                    <asp:Label runat="server" ID="_oLabelSnackbar" />
                </div>
                <div id="snackbargreen" style="position: absolute">
                    <asp:Label runat="server" ID="_oLabelSnackbargreen" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="row col-lg-12">
        <div class="col-sm-12" align="center">
            <br />
            <h4>
                <label class="font-weight-bold text-primary mb-1">Business Description</label></h4>
        </div>
        <div class="col-sm-12" align="center">
            
              <div  style="width:95%;text-align:left;margin:2px">
                        <div   style="width:100%" ><b> Temporary Account No.</b>  <br />   
                            <label runat="server" id="_oLabelAcctNo" ></label>                
                       </div>
                 
                        <div   style="width:100%"> <b> Business Name </b> <br />   
                              <label runat="server" id="_oLabelBussinessName" ></label>              
                       </div>
             </div>
            <br />
            <div  style="width:95%;text-align:left;margin:10px;border: 1px">
                  <div>
                        <div   style="width:90%"  >Business Category <b style="color:red">*</b><br />   
                               <select required runat="server"  id="_oDDL_Category" style="width:100%" > <%--onchange="getSelected(this.id);"--%>
                                  <option value="BRGY_001" >Sample BRGY 001</option>  
                                  <option value="BRGY_002">Sample BRGY 002</option>                               
                              </select>                   
                       </div>
                  </div>
           
           </div>
            
            <div  style="width:95%;text-align:left;margin:10px;border: 1px">
                  <div>
                        <div   style="width:90%" >Products and/or Services <b style="color:red">*</b><br />   
                              <input required  id="_otxt_ProdSrvcs"  name="_otxt_ProdSrvcs" style="width:100%" />                
                       </div>
                  </div>
                  
           </div>

           <div  style="width:95%;text-align:left;margin:10px;border: 1px">
                  <div >
                        <div   style="width:90%" >Capitalization <b style="color:red">*</b><br />   
                              <input  required id="_otxt_Capital"   name="_otxt_Capital" style="width:100%;text-align:right"  onblur="FormatCurrency(this);" />                
                       </div>
                  </div>
           </div>

           <div  style="width:95%;text-align:left;margin:10px;border: 1px">
                  <div>
                        <div   style="width:90%" >Estimated Area (in square meters) <b style="color:red">*</b><br />   
                              <input  type="number"  id="_oTxt_Area"  name="_oTxt_Area" required style="width:100%;text-align:right" />                
                       </div>
                  </div>
                 
                 <div  style="width:90%;text-align:right;margin:10px;border: 1px">
                     <button type="button" runat="server" id="_oBtnSave"  class="btn btn-primary" > SAVE </button>
                 </div>

           </div>

           <div  style="width:95%;text-align:left;margin:10px;border: 1px">
               <div   style="width:90%" >
                          <asp:GridView ID="_oGridViewBusinessDetailsNew" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" 
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                    <Columns>

                        <asp:TemplateField  Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("BusinessId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField  HeaderText="Category" HeaderStyle-Width="30%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("Category")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Products/Services" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("ProductsServices")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Capitalization" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelCapital" runat="server" Text='<%# String.Format("{0:N2}", Eval("Capital"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Area" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelArea" runat="server" Text='<%# String.Format("{0:N2}", Eval("Area"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="20%">
                            <ItemTemplate>
                                <a href="#" onclick="RemoveBusinessLine('Remove','<%# Eval("BusinessId")%>')">Remove</a><br />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
               </div>
            </div>
          
             <div  style="width:95%;text-align:left;margin:10px;border: 1px">
                  <div style="display:none;"  >
                        <div   style="width:90%" >Describe your line of business <b style="color:red">*</b><br />   
                            <asp:textbox style="text-align:left;" id="_otextBusinessNature" onkeypress="countChar(this)"  onkeyup="countChar(this)" runat="server" cssclass="form-control" BorderStyle="Solid" MaxLength="500" height="100px" TextMode="MultiLine" ></asp:textbox>
                               <div style="text-align:right" >
                                   <input id="charNum" value="0" style="border:none;text-align:right" disabled="disabled" readonly="readonly" />
                                   /&nbsp 500
                               </div>        
                       </div>
                  </div>

                 <br />

                  <div  style="width:90%;text-align:right;margin:10px;border: 1px">
                     <button type="button" runat="server" id="_oBtnSubmit"  class="btn btn-primary" > Submit </button>
                 </div>
           </div>
        </div>
        

    </div>
</asp:Content>
