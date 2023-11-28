<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BPLONewBusinessList.aspx.vb" Inherits="SPIDC.BPLONewBusinessList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script>
     function do_notify(Action, Val) {
         __doPostBack(Action, Val);
     };

         </script>
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
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <div id="snackbar" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbar"/>           
                </div>
                <div id="snackbargreen" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
     
    <div class="row col-lg-12" id="div_NewBPv1" runat="server">
         <div class="col-sm-12" align="center">
            <br />
            <h4><label class="font-weight-bold text-primary mb-1">New Business Application List</label></h4>
        </div>
         <div class="col-sm-12" >
             <div class="card shadow">
                 <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">New Business - FOR REVIEW</label>
                </div>

                      <div class="card-body">
                    <asp:GridView ID="GridView3" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging"
                        PageSize="5">
                        <pagersettings mode="NumericFirstLast"
                            firstpagetext="First"
                            lastpagetext="Last"
                            pagebuttoncount="10"  
                            position="Bottom"
                            Visible="true"/>         
                        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("APP_DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAILADDR")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIN"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="CBP Transaction No." HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="cbp_transaction_no" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelcbp_transaction_no" runat="server" Text='<%# Eval("cbp_transaction_no")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Commercial Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="bpa" Visible="false" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelStatus" runat="server" Text='<%# Eval("STATCODE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ForYear" ItemStyle-CssClass="bpa"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelForYear" runat="server" Text='<%# Eval("FORYEAR")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks" ItemStyle-CssClass="bpa"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelRemarks" runat="server" Text='<%# Eval("REMARKS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                             <%--     <asp:ImageButton runat="server" title="Review" ID="_oButtonForAppNo" src="../CSS_JS_IMG/img/reviewIcon.png" style="width:20px;height:20px"/>
                                   View/Process
                                --%>
                                   <asp:ImageButton runat="server" title="Review" ID="ImageButton1" src="../CSS_JS_IMG/img/reviewIcon.png" OnClick="ImageButton_Click" style="width:20px;height:20px"/>
                                   View/Process
                                        
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                          </div>
                 </div>
         </div>   
        
      <%--  FOR NOTIFICATION   --%>       
          <div class="col-sm-12" >
             <div class="card shadow">
                 <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Pending Notification - For Billing and Payment</label>
                </div>

                 <div class="card-body">                          
                        <asp:GridView ID="GridView4" runat="server" CssClass="mGrid Table-MobileView" 
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid4_PageIndexChanging"
                        PageSize="5">
                        <pagersettings mode="NumericFirstLast"
            firstpagetext="First"
            lastpagetext="Last"
            pagebuttoncount="3"  
            position="Bottom"
            Visible="true"/>    
                         <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>
                             <asp:TemplateField HeaderText="Application Date" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" SortExpression="EMAILADDR" HeaderStyle-ForeColor="White" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelAPP_DATE" runat="server" Text='<%# Eval("APP_DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIN" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center" SortExpression="BIN" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelACCTNO" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="CBP Transaction No." HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" SortExpression="cbp_transaction_no" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelcbp_transaction_no" runat="server" Text='<%# Eval("cbp_transaction_no")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Business Name" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Center" SortExpression="COMMNAME" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCOMMNAME" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Address" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="EMAILADDR" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEMAILADDR" runat="server" Text='<%# Eval("EMAILADDR")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Notify" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" SortExpression="ARXfile" HeaderStyle-ForeColor="White">
                                <ItemTemplate>
                                <%--    <a href="#" onclick="do_nofity('<%# Eval("ACCTNO")%>')"  data-toggle="modal" data-target="#ModalView"  title="Notify">Notify</a>--%>
                                   <%-- <asp:Button runat="server" id="_oBtnNotify" OnClientClick="do_nofity('<%# Eval("ACCTNO")%>','<%# Eval("EMAILADDR")%>')"  />--%>
                                   <%-- <button id="_oBtnNotify" runat="server" onclick="do_nofity('Notify','<%# Eval("ACCTNO")%>' + '|' +'<%# Eval("EMAILADDR")%>')"  ></button>--%>
                                         <a href="#" onclick="do_notify('Notify','<%# Eval("ACCTNO")%>' + '|' + '<%# Eval("EMAILADDR")%>'+ '|' + '<%# Eval("APP_DATE")%>')" title="Send Notification">Notify</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

             </div>
            </div>        
         <%--  FOR NOTIFICATION   --%>       
        <div class="col-sm-12" style="display:none" >
             <div class="card shadow">
                 <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">New Business - REVIEWED/ FOR ASSESSMENT BILLING</label>
                </div>

                 <div class="card-body">                          
                          <asp:GridView ID="_oGvReviewed" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging1"
                        PageSize="5">
                        <pagersettings mode="NumericFirstLast"
                            firstpagetext="First"
                            lastpagetext="Last"
                            pagebuttoncount="10"  
                            position="Bottom"
                            Visible="true"/>         
                        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>
                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("APP_DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelEmail" runat="server" Text='<%# Eval("EMAILADDR")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIN"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("ACCTNO")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Commercial Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="bpa" Visible="false" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelStatus" runat="server" Text='<%# Eval("STATCODE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ForYear" ItemStyle-CssClass="bpa"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelForYear" runat="server" Text='<%# Eval("FORYEAR")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remarks" ItemStyle-CssClass="bpa"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelRemarks" runat="server" Text='<%# Eval("REMARKS")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                   <asp:ImageButton runat="server" title="Review" ID="_oButtonReview" src="../CSS_JS_IMG/img/reviewIcon.png" OnClick="ImageButton_Click" style="width:20px;height:20px" OnClientClick="NextPage();"/>
                                   View
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

             </div>
            </div>


      

        </div>

 
           
      <div id="div_NewBPv2" runat="server" class="MainDiv col-lg-12" style="border:2px double lightgray">
           
             <div class="card shadow">
                 <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">New Business (For assignment of Application Number)</label>
                </div>

                      <div class="card-body">
                    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                     
                        <Columns>
                            <asp:TemplateField HeaderText="Application ID"  Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelApplication_ID" runat="server" Text='<%# Eval("Application_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("APP_DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Commercial Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>       
                            <asp:TemplateField HeaderText="Owner Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelOwnerName" runat="server" Text='<%# Eval("OwnerName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Status"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelStatus" runat="server" Text='<%# Eval("Status")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                                             
                             <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                       <asp:ImageButton runat="server" title="Review" ID="_oButtonForAppNo" src="../CSS_JS_IMG/img/reviewIcon.png"  OnClick="ImageButton_Click2"  style="width:20px;height:20px"/>
                                   View/Process
                      <%--      <a href="#"><img src="../CSS_JS_IMG/img/reviewIcon.png" style="width:20px;height:20px"/>  View/Process</a>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                          </div>
                 </div>      
      
             <div class="card shadow" id="div_NBP_ForRegulatory" runat="server">
                 <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">New Business (For Regulatory)</label>
                </div>

                      <div class="card-body">
                    <asp:GridView ID="GridView2" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging"
                        PageSize="5">
                        <pagersettings mode="NumericFirstLast"
                            firstpagetext="First"
                            lastpagetext="Last"
                            pagebuttoncount="10"  
                            position="Bottom"
                            Visible="true"/>         
                        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>      
                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("APP_DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="Commercial Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField> 
                              
                            <asp:TemplateField HeaderText="Owner Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("OwnerName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Application ID" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelApplication_ID" runat="server" Text='<%# Eval("Application_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                                                    
                             <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>                          
                         <a href="#" onclick="do_view('ForRegulatory','<%# Eval("Application_ID")%>','<%# Eval("EMAILADDR")%>')"><img src="../CSS_JS_IMG/img/reviewIcon.png" style="width:20px;height:20px"/>  View</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                          </div>
                 </div>        
        
             <div class="card shadow">
                 <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">New Business (For Payment Approval)</label>
                </div>

                      <div class="card-body">
                    <asp:GridView ID="GridView_ForApproval" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging"
                        PageSize="5">
                        <pagersettings mode="NumericFirstLast"
                            firstpagetext="First"
                            lastpagetext="Last"
                            pagebuttoncount="10"  
                            position="Bottom"
                            Visible="true"/>         
                        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>      
                            <asp:TemplateField HeaderText="Date"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("APP_DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="Commercial Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelCommercialName" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField> 
                              
                            <asp:TemplateField HeaderText="Owner Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("OwnerName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Application ID" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelApplication_ID" runat="server" Text='<%# Eval("Application_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                                                    
                             <asp:TemplateField HeaderText="Action"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                               <a href="#" onclick="do_view('ForBPLOApproval','<%# Eval("Application_ID")%>','<%# Eval("EMAILADDR")%>')">
                                   <img src="../CSS_JS_IMG/img/reviewIcon.png" style="width:20px;height:20px"/>  View/Process</a>
                               </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                          </div>
                 </div>
       
       
          </div>           
   <br /> 
 
           <div class="card-body">
        <button class="btn btn-primary" runat="server" id="_BtnCBP"> Go to E-Cert Posting (CBP) </button>
    </div>
   

    <script>
        function do_view(grid, AppID, Email) {        
            switch (grid) {

                case 'ForRegulatory':
                    window.location.href = "BPLONewBP_ForRegulatory.aspx?Application_ID=" + AppID + "&Email=" + Email;
                    break;

                case 'ForBPLOApproval':
                    window.location.href = "BPLONewBP_ForApproval.aspx?Application_ID=" + AppID + "&Email=" + Email;
                    break;
            }
        }
    </script>

</asp:Content>