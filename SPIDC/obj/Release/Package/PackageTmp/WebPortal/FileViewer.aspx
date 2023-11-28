<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="FileViewer.aspx.vb" Inherits="SPIDC.FileViewer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
       <div class = "col-lg-12 table-responsive-lg mt-2">
        <asp:GridView ID="Gv_FileViewer" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
        AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
        HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" EnableViewState="true" AllowPaging="True" OnPageIndexChanging="datagrid_PageIndexChanging"
        PageSize="5">
        <PagerSettings Mode="NumericFirstLast"
            FirstPageText="First"
            LastPageText="Last"
            PageButtonCount="3"
            Position="Bottom"
            Visible="true" />
        <pagersettings mode="NumericFirstLast"
            firstpagetext="First"
            lastpagetext="Last"
            pagebuttoncount="3"  
            position="Bottom"
            Visible="true"/>         
        <PagerStyle CssClass="paging" HorizontalAlign="Center"/>

        <Columns>

            <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="center" SortExpression="Email" HeaderStyle-ForeColor="White">
                <ItemTemplate>
                    <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("Email")%>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="GovID" HeaderStyle-Width="13%" ItemStyle-HorizontalAlign="center" SortExpression="Name1" HeaderStyle-ForeColor="White">
                <ItemTemplate>
                    <a href="#" onclick="do_view('<%# Eval("Email")%>','<%# Eval("Name1")%>','<%# Eval("Data1")%>','001')">
                        <%# Eval("Name1")%>                         s                               
                    </a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <a href="#" onclick="do_Delete('<%# Eval("Email")%>','<%# Eval("Name1")%>','<%# Eval("Data1")%>','001')"><i class="fa fa-remove icon" style="color: Red"></i></a>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="SPA" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="center" SortExpression="Name2" HeaderStyle-ForeColor="White">
                <ItemTemplate>
                    <a href="#" onclick="do_view('<%# Eval("Email")%>','<%# Eval("Name2")%>','<%# Eval("Data2")%>','002')">
                        <%# Eval("Name2")%>  
                    </a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <a href="#" onclick="do_Delete('<%# Eval("Email")%>','<%# Eval("Name2")%>','<%# Eval("Data2")%>','002')"><i class="fa fa-remove icon" style="color: Red"></i></a>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="BRSEC" HeaderStyle-Width="17%" ItemStyle-HorizontalAlign="center" SortExpression="Name3" HeaderStyle-ForeColor="White">
                <ItemTemplate>
                    <a href="#" onclick="do_view('<%# Eval("Email")%>','<%# Eval("Name3")%>','<%# Eval("Data3")%>','003')">
                        <%# Eval("Name3")%>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <a href="#" onclick="do_Delete('<%# Eval("Email")%>','<%# Eval("Name3")%>','<%# Eval("Data3")%>','003')"><i class="fa fa-remove icon" style="color: Red"></i></a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>



    </asp:GridView>
    </div>
        <div id="DeleteConfirmation" class="modal fade show">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Delete Record</h4>
              <button id="CancelDeletion2" class="close" data-dismiss="modal" aria-label="Close" onclick="setActive(this.id);">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                
                <div class="form-group">
                     Do you want to delete this File?
                  
                 <input type="hidden" id="hdnfld_Forgot" name="hdnfld_Forgot" value="false"/>  
               
                </div>              
  
               <div class="text-center">
                  <div class="m-2 col-12 d-flex justify-content-center align-content-center">
                            <button id="ConfirmDeletion" class="btn btn-success btn-sm" runat="server" onclick="setActive(this.id);Select('ConfirmDelete','')" >Confirm&nbsp<i class="fa fa-check icon"></i>&nbsp</button>
                            &nbsp &nbsp &nbsp
                                <button id="CancelDeletion" class="btn btn-danger btn-sm" data-dismiss="modal" aria-label="Close" onclick="setActive(this.id);" >Cancel <i class="fa fa-remove icon"></i></button>
                        </div>
              
                </div>
           

              
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->


                    <input type="hidden" runat="server" id="hdnEmail" />
                    <input type="hidden" runat="server" id="hdnFileName" />
                    <input type="hidden" runat="server" id="hdnFileData" />
  
             
   <script>
       function Select(GovID, Val) {
       
       }
       function do_view(Email, FileName, FileData, Val) {
    
           document.getElementById('<%=hdnEmail.ClientID%>').value = Email;
           document.getElementById('<%=hdnFileName.ClientID%>').value = FileName;
           document.getElementById('<%=hdnFileData.ClientID%>').value = FileData;
     
           __doPostBack('View', Val);
       }

       function do_Delete(Email, FileName, FileData, Val) {
       
           document.getElementById('<%=hdnEmail.ClientID%>').value = Email;
           document.getElementById('<%=hdnFileName.ClientID%>').value = FileName;
           document.getElementById('<%=hdnFileData.ClientID%>').value = FileData;              
           __doPostBack('Delete_Attachment', Val);
       }
           </script>
</asp:Content>
