<%@ 
    Page Title="" Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="BPLTIMSBusinessLine.aspx.vb" 
    Inherits="SPIDC.BPLTIMSBusinessLine" 
    EnableEventValidation="false"
    %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

    
      <asp:ScriptManager ID="ScriptManager1" runat="server" />
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
        <link href="../CSS_JS_IMG/docsupport/chosen.css" rel="stylesheet" />


     <script>

         //SNACKBAR - Welcome       
         function SnackbarGreen() {
             var x = document.getElementById("snackbargreen");
             x.className = "show";
             setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
         }

         function Snackbar() {
             var x = document.getElementById("snackbar");
             x.className = "show";
             setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
         }

    </script>    

    <%--handles numeric validation--%>
     <script type="text/javascript">
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

         function validate(evt) {
             var theEvent = evt || window.event;

             // Handle paste
             if (theEvent.type === 'paste') {
                 key = event.clipboardData.getData('text/plain');
             } else {
                 // Handle key press
                 var key = theEvent.keyCode || theEvent.which;
                 key = String.fromCharCode(key);
             }
             var regex = /[0-9]|\./;
             if (!regex.test(key)) {
                 theEvent.returnValue = false;
                 if (theEvent.preventDefault) theEvent.preventDefault();
             }
         };
        </script>
    <%------------------------------%>

      <div id="snackbar" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbar"/>           
        </div>
        <div id="snackbargreen" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
        </div>
       
       <form name="frmNone" id="frmNone" method="post"></form>
   
         <div class="container ">
               <center>   


           <br />
  <div id="Slide_11" style=" border:1px solid gray; background-color:white; padding:10px; display:block;" class="col-md-6" ClientIDMode="Static">
		   <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" > New Business Permit Application</h2>
                </div>
       <div class="progress">
    <div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width:99%">
      99%
    </div>
  </div>
         <hr />

      <div class="btn-primary"><strong>Line of business declaration</strong></div>
      <br />

             <div class="instruct">
                    <ul style="padding:0px 0px 0px 35px;">
                        <li> Declare your line of business to complete your application</li>
                    </ul>
                </div>

          <%--<div style="background-color:#ff5a95;color:white;"><strong>Business Line Entry</strong></div>
                             <i style="color:green">* Add atleast 1 business line to complete your application</i>--%>
          <br />
 
          
            <div class="">              

            <div class="">
	        <div class="row">

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
                    </script>

                  <div class="form-group col-md-12"  style="text-align:left"> Describe Nature of business<br />  

                     <asp:textbox style="text-align:left;" id="_otextBusinessNature" onkeypress="countChar(this)"  onkeyup="countChar(this)" runat="server" cssclass="form-control" BorderStyle="Solid" MaxLength="500" height="100px" TextMode="MultiLine" ></asp:textbox>
                       <div style="text-align:right" >
                           <input id="charNum" value="0" style="border:none;text-align:right" disabled="disabled" readonly="readonly" />
                           /&nbsp 500
                       </div>
                  </div>
                <div class="form-group col-md-12 row"  style="text-align:left">&nbsp&nbsp Search Business Line<br />   
                    <div class="d-flex align-content-center justify-content-center col-12 mx-auto">
                     <asp:textbox   id="_oTxtSearchBusLine" runat="server" cssclass="form-control col-10 ml-1" placeholder="Search"  style="text-align:left;"></asp:textbox>
                    <button type="button" runat="server" class="btn btn-success col-2 ml-2" id="_oBtnSearch" autopostback="true">Search</button>
                        </div> 
                </div>        
                <div class="form-group col-md-12"  style="text-align:left">  Select Business Line<br />   
                     <select   runat="server" id="cmbBusCode" name="cmbBusCode" data-placeholder="Business Line" class="form-control chosen-select Ch-Size-New">  </select>
                </div>
                  <div class="form-group col-md-12"  style="text-align:left"> Area (square meter)<br />   
                <asp:textbox style="text-align:right;" id="_otextArea" runat="server" cssclass="form-control" MaxLength="20" placeholder="0 m²" onblur="FormatCurrency(this);" onkeypress="validate(event);" ></asp:textbox>
                </div>     
              <div class="form-group col-md-12"  style="text-align:left"> Capital<br />  
                      <asp:textbox   id="_otextCapital" runat="server" cssclass="form-control" placeholder="Capital"  style="text-align:right;" onblur="FormatCurrency(this);" onkeypress="validate(event);"></asp:textbox>               
                      </div>
             
                 <div class="form-group col-md-12 "  >
                        <button type="button" runat="server" class="btn btn-success" id="btnSaveBusLine" autopostback="true">Save Business Line</button>
   <hr />
                      </div>
    
                <br />
                <script>
                    function ShowSnackBar(color, content) {
                        switch (color) {
                            case "red":
                                var x = document.getElementById("snackbar");
                                var y = document.getElementById("_oLabelSnackbar");
                                x.className = "show";
                                y.textContent = content;
                                setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
                                break;
                            case "green":
                                var x = document.getElementById("snackbargreen");
                                var y = document.getElementById("_oLabelSnackbargreen");
                                x.className = "show";
                                y.textContent = content;
                                setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
                                break;
                        }
                    }

                    function showBusLineModal() {
                        var x = document.getElementById("MyPopup");
                        x.className = "show";
                    }




        </script> 
                               
                      <br />

      <div class="col-lg-12">
      <asp:GridView ID="_oGridViewAddedBusline" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">                                     
         <Columns>

                <asp:TemplateField Visible="false" >
                <ItemTemplate>
                 <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("BUS_CODE")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="50%">
                <ItemTemplate>
                 <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("Description")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Area" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                 <asp:Label ID="_oLabelArea" runat="server" Text='<%# String.Format("{0:N2}", Eval("Area"))%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Capital" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                  <asp:Label ID="_oLabelCapital" runat="server" Text='<%# String.Format("{0:N2}", Eval("Capital"))%>' />
                </ItemTemplate>
            </asp:TemplateField>         
             
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="10%">
            <ItemTemplate>   
                <a href="#" onclick="RemoveBusLine('Remove','<%# Eval("BUS_CODE")%>')">Remove</a><br />              
            </ItemTemplate>
        </asp:TemplateField>
                                                                               
        </Columns>

    </asp:GridView>   
                </div>
                      <script>
                          function RemoveBusLine(Action, BusCode) {
                              __doPostBack(Action, BusCode);
                          }
                      </script>           
                       <asp:Panel ID="Panel1" runat="server" CssClass="cssPanelAlignCenter" Visible="False">
                                                                                    <asp:Label ID="Label1" runat="server" CssClass="cssLabelCenter" Font-Bold="True"
                                                                                        Text="Processing..." />
                                                                                </asp:Panel>
                     
                                                         
           
                
                      <script>
                          function RemoveBusLine(Action, BusCode) {
                              __doPostBack(Action, BusCode);
                          }
                      </script>           
                       <asp:Panel ID="_oPanelProcess" runat="server" CssClass="cssPanelAlignCenter" Visible="False">
                                                                                    <asp:Label ID="Label72" runat="server" CssClass="cssLabelCenter" Font-Bold="True"
                                                                                        Text="Processing..." />
                                                                                </asp:Panel>
                     
                                                         
            </div>

             <!-- Modal Popup Ask Business Line -->
<div id="MyPopup" class="modal fade" role="document"  data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">
        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">     
                  <asp:Label ID="_oLabelFeeType" runat="server" CssClass="cssLabelCenter" Font-Bold="True" />
                <h4 class="modal-title">
                </h4>
            </div>
            <div class="modal-body">
                 <asp:Panel ID="_oPanel_Ask" runat="server" 
                     CssClass="cssPanelAlignLeft" BackColor="White"
                     Style="min-height: 100px; overflow: hidden;" Width="60%" Visible="False">
                                                                                         
                                                                                            <asp:Panel ID="_oPanel1_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel1_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox1_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox1_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel2_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel2_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox2_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox2_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel3_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel3_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox3_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox3_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel4_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel4_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox4_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox4_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel5_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel5_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox5_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox5_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel6_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel6_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox6_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox6_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel7_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel7_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox7_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox7_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel8_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel8_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox8_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox8_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel9_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel9_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox9_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox9_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel10_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel10_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox10_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox10_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>

                                                                                            <br />
                                                                                             <%-- Panel OPTION--%>
                                                                                            <asp:Panel ID="_oPanel_oGridViewOption" runat="server" Style="overflow: hidden;" ScrollBars="Auto" BackColor="White" Visible="False" >
                                                                                                <asp:GridView ID="_oGridViewOption" runat="server" AutoGenerateColumns="False" PagerSettings-Mode="NumericFirstLast"
                                                                                                    ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" CssClass="GridViewStyle">
                                                                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                                    <Columns>
                                                                                                         <asp:TemplateField HeaderText="" >
                                                                                                            <ItemTemplate >
                                                                                                               <asp:RadioButton ID="rbtnSelect" AutoPostBack="true" runat="server" OnCheckedChanged="rbtnSelect_CheckedChanged" />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" Width="2px" />
                                                                                                        </asp:TemplateField>
                                                                                                       <%-- <asp:TemplateField HeaderText="" >
                                                                                                            <ItemTemplate >
                                                                                                                  <asp:RadioButton runat="server" ID="_oRadioBtnOption"  />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" Width="2px" />
                                                                                                        </asp:TemplateField>--%>

                                                                                                        <asp:TemplateField HeaderText="RowNo" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelRowNo" runat="server" Text='<%# Eval("RowNo")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="CODE" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelTaxCode" runat="server" Text='<%# Eval("TAXCODE")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                     
                                                                                                        <asp:TemplateField HeaderText="Option">
                                                                                                            <ItemTemplate>
                                                                                                                 <asp:Label ID="_oLabelOption" runat="server" Text='<%# Eval("OPTHDG1")%>' /> 
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="20px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="TAX RATE" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelTaxRate" runat="server" Text='<%# Eval("TAXRATE")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="TAX AMT" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelTaxAmt" runat="server" Text='<%# Eval("TAXAMT")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="CODE2" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelTaxCode2" runat="server" Text='<%# Eval("TAXCODE2")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Month" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelEff_Month" runat="server" Text='<%# Eval("EFF_MONTH")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Year" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelEff_Year" runat="server" Text='<%# Eval("EFF_YEAR")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                            </asp:Panel>
                                                                                            <br />
                                                                                            <asp:Panel ID="Panel120" runat="server" CssClass="cssPanelAlignCenter">
                                                                                                <asp:Button ID="_oButton_OK" runat="server" CssClass="cssButton2" Font-Size="small"
                                                                                                    Text="Ok" Width="80px" Visible="False" />
                                                                                                <asp:Button ID="_oButtonTaxSave" runat="server" CssClass="btn btn-primary" Font-Size="small"
                                                                                                    Text="Save and proceed"  />
                                                                                            </asp:Panel>
                                                                                             <%-- Panel OPTION--%>
                                                                                        </asp:Panel>
            </div>
            <div class="modal-footer">
             
            </div>
        </div>
    </div>
</div>


 
<!-- Modal Popup -->

  <%--  For Modal Popup Of Business Line--%>
                     <!-- Bootstrap -->

<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/bootstrap-theme.min.css">
<script src="https://code.jquery.com/jquery-1.11.2.min.js"></script>
<script src="js/bootstrap.min.js"></script>

<%--<script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>--%>
<%--<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'media="screen" />--%>
<!-- Bootstrap -->

    
<script type="text/javascript">
    function ShowPopup(title, body) {
        $("#MyPopup .modal-title").html(title);
        $("#MyPopup").modal("show");
    }

    function HidePopup() {
        $("#MyPopup").modal("hide");
    }


</script>



    <%--  For Modal Popup Of Business Line--%>


<script>

    function Filter_BusCode() {
        var filter = $('#cmbCatCode').val();
        $('#cmbBusCode option').each(function () {
            if ($(this).val().split('_')[0] == filter) {
                $(this).show();
            } else {
                $(this).hide();
            }
            $('#cmbBusCode').val(filter);
        })

    }

</script>


	</div>

                  </div>    
            
            <hr/>		
            
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">               &nbsp
             
            
              <button type="button" runat="server" class="btn btn-success" id="Finish_End"  autopostback="true" >Submit</button>
           
             
          </span>	 
              		   
		   </div>


            
      
       </center>
      </div>
    <br />

  <div style="display:none;">
       <asp:UpdatePanel runat="server" >
                <ContentTemplate>
                      <rsweb:ReportViewer ID="_oRpt_EnvelopeSeal" 
                        runat="server"
                        Height="900px" Width="100%"
                        ZoomMode ="PageWidth" 
                        Font-Names="Verdana" 
                        Font-Size="8pt" 
                        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" 
                        WaitMessageFont-Size="14pt">
                      </rsweb:ReportViewer>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="_oRpt_EnvelopeSeal"/>
                </Triggers>
            </asp:UpdatePanel>
  </div>
     
    <script src="../CSS_JS_IMG/js/chosen.jquery.js"></script>
    <script src="../CSS_JS_IMG/docsupport/init.js"></script>

</asp:Content>
