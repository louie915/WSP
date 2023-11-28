<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="LGUMainPage.aspx.vb" Inherits="SPIDC.LGUMainPage" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">      
    <asp:ScriptManager runat="server">    </asp:ScriptManager>
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
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>
    <div class="container card my-2 col-lg-11" >

        <div class="form-row form my-4 d-flex justify-content-center col-lg-12">
            
            <div class="form-group col-lg-4 row align-content-center align-items-center justify-content-center d-flex">

                <input id="_txtSearch" type="text" class="form-control CH-Size col-md-9" placeholder="Search">

                <div class="col-md-2" style="text-align:right">
                    <button id="_btnSearch" class="btn btn-primary"> <i class="fas fa-search fa-fw"></i></button>
                </div>


            </div>

            <%--            <div class="input-group mb-3">
                
                <input type="text" class="form-control rounded rounded-sm" placeholder="Search">
                
                <div class="input-group-prepend">
                    <button class="btn btn-primary rounded-lg">Search</button>
                </div>
            </div>--%>

            <div class="form-group col-lg-3 align-content-center align-items-center justify-content-center d-flex mx-2">
                                
                    <select runat="server"  id="radFilterOptionTrasactionType" class="form-control CH-Size" onchange="FilterTransactionbyType(this.value)">
                        <option value="" selected disabled>Transaction Type</option>
                        <option value="RPT Payment">RPT Payment</option>
                        <option value="Business Payment">Business Payment</option>
                        <option value="CTC Individual">CTC Individual</option>          
                        <option value="CTC Corporation">CTC Corporation</option>   
                        <option value="RPT Certification">RPT Certification</option>
                        <option value="Business Certification">Business Certification</option>              
                    </select>
                <input type="hidden" id="HdnFilter" />
                <select runat="server" id="radFilterOptionForm" class="form-control CH-Size mt-2" onchange="FilterTransactionByForm(this.value)" visible="False" >
                        <option value="" selected disabled>Accountable Form</option>
                        <option value="AF51">AF51</option>
                        <option value="AF56">AF56</option>
                        <option value="BF0016">BF0016</option>
                        <option value="BF0017">BF0017</option>
                    </select>

                

            </div>
            <div class="form-group col-lg-4 row">
                
                <%--<a href="#" class="btn btn-primary btn-sm col-md-4 mx-2" style="height:29px;margin-top:2px" onclick="enableBtnORPrint()" >Cancel</a>--%>
                <%--<input id="BtnCancel" runat="server" type="button" class="btn btn-primary btn-sm col-md-7" style="height:29px;margin-top:2px"  Value="Cancel" onclick="CancelSelectedTransaction()" />--%>
                <asp:Button ID="BtnCancel2" runat="server" CssClass="btn btn-primary btn-sm mx-2" Text="Cancel" Visible="False" />
                <%--<a href="#" class="btn btn-primary btn-sm col-md-7" style="height:29px;margin-top:2px" data-toggle="modal" data-dismiss="modal" data-target="#Forgot">Print/OR</a>--%>
                <%--<input id="BtnOrPrint" runat="server" type="button" class="btn btn-primary btn-sm col-md-7" style="height:29px;margin-top:2px"  value="Assign OR" disabled onclick="LoadSelectedTransaction()" />--%>
                <asp:Button ID="BtnOrPrint2" runat="server" CssClass="btn btn-primary btn-sm mx-2" Text="Assign OR" Enabled="False"  />
                <%--<input id="BtnPost" runat="server" type="button" class="btn btn-primary btn-sm col-md-7" style="height:29px;margin-top:2px"  Value="Post" disabled onclick="NextPage();ClickPost()" />--%>
                <asp:Button ID="BtnPost2" runat="server" CssClass="btn btn-primary btn-sm mx-2" Text="Post" Enabled="False"   />
                    <%--<asp:RadioButton id="_oRadioPaidOnly" GroupName ="Paid" runat="server" AutoPostBack="True" Text ="&nbsp Paid Only" CssClass ="my-auto col-sm-2 mx"/>--%>
                    <%--<asp:RadioButton id="_oRadioAll" GroupName="Paid" runat="server"  AutoPostBack="True" Text ="&nbsp All" CssClass ="my-auto col-sm-2 mx"/>--%>                    

                
                
            </div>
               
            <div class=" col-lg-12 ">
                    <asp:GridView ID="_oGVTransaction"  runat="server" CssClass="mGrid mx-0 px-0 col-lg-12"  AllowSorting="true" 
                            AutoGenerateColumns="false"   ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1"
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" >     
                    <Columns >

                     <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("TransDate")%>'  />
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Transaction Number"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelTransNo" runat="server" Text='<%# Eval("ControlNo")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>    

                       <asp:TemplateField HeaderText="Form"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelTransType" runat="server" Text='<%# Eval("Form")%>' Visible="True" />
                         </ItemTemplate>
                     </asp:TemplateField>    

                       <asp:TemplateField HeaderText="Transaction Type"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelTransType" runat="server" Text='<%# Eval("TransactionType")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>       

                        <asp:TemplateField HeaderText="Status"  HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelStatus" runat="server" Text='<%# Eval("Status")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>  

                       <asp:TemplateField HeaderText="Name"  HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelName" runat="server" Text='<%# Eval("Name")%>' />
                         </ItemTemplate>
                       </asp:TemplateField>        

                        <asp:TemplateField HeaderText="Amount Paid"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>                                 
                        <asp:Label ID="_oLabelAmountPaid" runat="server" Text='<%# Eval("TaxAmount")%>' />
                         </ItemTemplate>
                       </asp:TemplateField>  
                        
                        <asp:TemplateField HeaderText="OR No. | SRS | Book No."  HeaderStyle-Width="25%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelpOrSrsBookNo" runat="server" Text='<%# Eval("Or_numberSRSBookno")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>                             
                                          
                        
                                <asp:TemplateField  HeaderText="Action" HeaderStyle-Width="18%" ItemStyle-HorizontalAlign="center" >
                                    <ItemTemplate>
                                        
                                        <a id="PrintLinkOr"  href="#" onclick="PrintOR('<%# Eval("Or_number")%>');" "title="Information" >Print</a>

                                    </ItemTemplate>
                                </asp:TemplateField>
                        
                                                
                      </Columns>

                    </asp:GridView> 
                <script type="text/javascript">
                    function hideColumn() {
                        var gridrows = $("#_oGVTransaction tbody tr");
                        for (var i = 0; i < gridrows.length; i++) {
                            gridrows[i].cells[8].style.display = (sessionStorage.getItem('_oGVTransaction') ? sessionStorage.getItem('_oGVTransaction') : "none");
                            gridrows[i].cells[8]
                        }
                        var table = document.getElementsByClassName('Table-DH');
                        for (var i = 0; i < table.length; i++) {
                            var newtable = document.getElementById(table[i].id);
                            var dh = newtable.getElementsByTagName('td');
                            for (var j = 0; j < dh.length; j++) {
                                var atag = dh[j].getElementsByTagName('a');
                                for (var t = 0; t < atag.length; t++) {
                                    dh[j].style.border = "0";
                                    dh[j].classList.add("align-content-center", "justify-content-center", "my-auto");
                                }

                            }
                            var th = newtable.getElementsByTagName('th');
                            th[th.length - 1].style.border = "0";
                            th[th.length - 1].classList.add("row", "align-self-center", "justify-content-center", "w-100");



                        }


                    };
                    window.onload = hideColumn;
                    </script>
                    <style>
                        table._oGVTransaction a {
                            border: 0;
                        }

                        table._oGVTransaction td {
                            border: 0;
                        }

                        .hey {
                            top: 0;
                            left: 0;
                            bottom: 0;
                            right: 0;
                        }
                    </style>
                </div>
               
            <center>
                 
                <%--REPORTVIEWER _MSRV--%>
                <rsweb:reportviewer ID="_oMSRV" runat="server"  SizeToReportContent="true" 
                    Width="100" Height="10000">
                </rsweb:reportviewer>
            </center>


            <div class=" col-lg-12 ml-lg-12 mt-5 d-flex justify-content-center row" style="text-align:inline-block">
              <%--  <button id="_btnGenerelColReport" class="btn btn-primary btn-sm col-3" onclick="window.location.replace('LGU_GeneralCollectionReport.aspx');">General Collection Report</button>
                <button id="_btnProCerList" class="btn btn-primary btn-sm col-3" onclick="window.location.replace('CertificationListPage.aspx');">Process Certification List</button>
                <button id="_btnViewArchive" class="btn btn-primary btn-sm col-3" onclick="window.location.replace('AppointmentList.aspx');">Appointment List</button>
            --%>
              <a href="LGU_GeneralCollectionReport.aspx" class="btn btn-primary btn-sm col-lg-3 m-1" >General Collection Report</a>
                 <a href="CertificationListPage.aspx" class="btn btn-primary btn-sm col-lg-3 m-1" >Process Certification List</a>
                <a href="AppointmentList.aspx" class="btn btn-primary btn-sm col-lg-3 m-1">Appointment List</a>
           
            </div>
        </div>
       <div id="Forgot" class="modal fade col-lg-12" >
        <div class="modal-dialog modal-lg col-lg-12" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title">Printing and Posting of Records (Transaction Type)</h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>

            
           
                    
                    <asp:GridView ID="_oGVPrintTransaction"  runat="server" CssClass=""  AllowSorting="true" 
                            AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">     
                    <Columns >

                     <asp:TemplateField HeaderText="Transaction No."  HeaderStyle-Width="8%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelpTransNo" runat="server" Text='<%# Eval("TransactionNumber")%>'  />
                         </ItemTemplate>
                     </asp:TemplateField>


                    <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelpDate" runat="server" Text='<%# Eval("Date")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>


                     <asp:TemplateField HeaderText="Owner"  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelpOwner" runat="server" Text='<%# Eval("Owner")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>    

                       <asp:TemplateField HeaderText="Amount No."  HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelpAmount" runat="server" Text='<%# Eval("Amount")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>       

                        <asp:TemplateField HeaderText="OR No. | SRS | Book No."  HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                         <ItemTemplate>
                          <asp:Label ID="_oLabelpOrSrsBookNo" runat="server" Text='<%# Eval("Or_numberSRSBookno")%>' />
                         </ItemTemplate>
                     </asp:TemplateField>                                                        
                                                                  
                      </Columns>

                    </asp:GridView> 
                

           
               <div class="text-center">         
                   <asp:Button ID="btnSignIn" UseSubmitBehavior="false" runat="server" Text ="Print" cssclass="btn btn-primary btn-sm col-3 m-2"/>
                </div>
            
              <input type="hidden" runat="server" id="HiddenPath">
              
         


          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->
  
    </div>

    <iframe  id="pdf" name="pdf" src="../Temp/ORPrint.pdf" style="display:none" width="500" height="10000"></iframe>  

    <script>
        function enableBtnORPrint() {
            document.getElementById("BtnOrPrint").disabled = false
        }

        function FilterTransactionbyType(val) {
            var strData = val.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=_oGVTransaction.ClientID%>");
            var rowData;

            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].cells[3].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {

                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
            document.getElementById("BtnOrPrint2").disabled = false;
            document.getElementById("radFilterOptionForm").value = ""

        }

        function FilterTransactionByForm(val) {
            var strData = val.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=_oGVTransaction.ClientID%>");
            var rowData;

            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].cells[2].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {

                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
            document.getElementById("BtnOrPrint").disabled = false;
            document.getElementById("radFilterOptionTrasactionType").value = ""

        }

        function LoadSelectedTransaction() {

            var LoadTransaction = document.getElementById('BtnOrPrint').value
            __doPostBack('BtnOrPrint', LoadTransaction);


        }

        function CancelSelectedTransaction() {

            var Cancel = document.getElementById('BtnCancel').value
            __doPostBack('BtnCancel', Cancel);

        }

        function ClickPost() {

            var Post = document.getElementById('BtnPost').value
            __doPostBack('BtnPost', Post);
        }

        function PrintOR(Or) {

            var Post = Or
            __doPostBack('PrintOR', Post);
        }




    </script>

    <script>
        <%--$('#frmPDF').attr('src', document.getElementById('<%=HiddenPath.ClientID%>').value);
        setTimeout(function () {
            frame = document.getElementById("frmPDF");
            framedoc = frame.contentWindow;
            framedoc.focus();
            framedoc.print();
        }, 1000);--%>

        </script>
<script language="javascript" type="text/javascript">



    function CallPrint(strid) {
        var prtContent = document.getElementById(strid);
        var WinPrint = window.open('', '', 'letf=0,top=0,width=600,height=1000,toolbar=0,scrollbars=0,status=0');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.write('../Temp/ORPrint.pdf');
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }

    function isLoaded() {
        var pdfFrame = window.frames["pdf"];
        pdfFrame.focus();
        pdfFrame.print();
    }
</script>
</asp:Content>
