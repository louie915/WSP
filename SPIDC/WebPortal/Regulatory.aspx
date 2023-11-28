<%@ Page Title="" Language="vb" AutoEventWireup="false" 
    EnableEventValidation="true"
    MasterPageFile="~/WebPortal/RegulatoryMaster.Master" 
    CodeBehind="Regulatory.aspx.vb" Inherits="SPIDC.Regulatory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

      <!-- Modal View Attachment Form -->
      <div id="ModalView" class="modal fade" >
        <div class="modal-dialog modal-lg">
          <div class="modal-content">
            <div class="modal-header  bg-primary">
              <h4 class="modal-title text-white" id="ModalFileName"></h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
                   <center>
                   <embed id="embed_Here" type="text/html" src="#"  width="100%" height="600px" style="object-fit: contain;" />
        
                       </center>
                  


          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
  
    <div class="row col-lg-12">
      
        <div class="col-sm-12">
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">New Clearance</label>
                </div>
                <div class="card-body">       
                    <asp:GridView ID="GridView1" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
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
                            <asp:TemplateField HeaderText="Date"  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("APP_DATE")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Business Trade Name"  HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBusiness_Trade_Name" runat="server" Text='<%# Eval("COMMNAME")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>  

                          
                            <asp:TemplateField HeaderText="Taxpayer Name"  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBIN" runat="server" Text='<%# Eval("OwnerName")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Application ID" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelApplication_ID" runat="server" Text='<%# Eval("Application_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>


                                                     
                             <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>                                    
                                  <a href="#" onclick="do_Review('<%# Eval("Application_ID")%>','<%# Eval("EMAILADDR")%>')"> View/Process</a>
                      <%--      <a href="#"><img src="../CSS_JS_IMG/img/reviewIcon.png" style="width:20px;height:20px"/>  View/Process</a>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>                 

                </div>
            </div>
            <br />
             <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Approved Clearance</label>
                </div>
                <div class="card-body">       
                    <asp:GridView ID="GridView2" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging_History"
                        PageSize="10">
                        <pagersettings mode="NumericFirstLast"
                            firstpagetext="First"
                            lastpagetext="Last"
                            pagebuttoncount="10"  
                            position="Bottom"
                            Visible="true"/>         
                        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>
                        <Columns>     
                            <asp:TemplateField HeaderText="Date"  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelDate" runat="server" Text='<%# Eval("Date_Assessed")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Business Trade Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelBusiness_Trade_Name" runat="server" Text='<%# Eval("Business_Trade_Name")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Taxpayer Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelTaxpayer_Name" runat="server" Text='<%# Eval("TaxPayer_Name")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="Application ID">
                                <ItemTemplate>
                                    <asp:Label ID="oLabelApplication_ID" runat="server" Text='<%# Eval("Application_ID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>     

                              <asp:TemplateField HeaderText="Clearance No" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelClearance_No" runat="server" Text='<%# Eval("Clearance_no")%>' />
                                </ItemTemplate>
                            </asp:TemplateField> 

                             <asp:TemplateField HeaderText="Assessed by" ItemStyle-HorizontalAlign="Center" >
                                <ItemTemplate>
                                    <asp:Label ID="oLabelAssessed_By" runat="server" Text='<%# Eval("Assessed_By")%>' />
                                </ItemTemplate>
                            </asp:TemplateField> 
                                                
                                                
                             <asp:TemplateField HeaderText="Action"  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>                                    
                                  <a href="#" onclick="do_View('<%# Eval("Application_ID")%>','<%# Eval("UserID")%>')"> View</a>
                     
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>                 

                </div>
            </div>


        </div>
        
    </div>

    
    <script>
        function do_Review(AppID, Email) {          
            window.location.href = "Regulatory_Review.aspx?Application_ID=" + AppID + "&Email=" + Email;
        }

        function do_View(AppID, Email) {
            window.location.href = "Regulatory_ReviewHistory.aspx?Application_ID=" + AppID + "&Email=" + Email;
        }
      
    </script>
 

</asp:Content>
