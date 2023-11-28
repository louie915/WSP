
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BPLOAppointmentReq.aspx.vb" Inherits="SPIDC.BPLOAppointmentReq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">


    <asp:GridView ID="GV_AppList"  runat="server" CssClass="GridViewStyle mgrid"  AllowSorting="true"  AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true">
                        <Columns>           
                            
                               <asp:TemplateField HeaderText="Date" >
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelDate" runat="server" Text='<%# Eval("TransDate")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>                            
                                           
                             <asp:TemplateField HeaderText="Email" >
                                    <ItemTemplate>
                                    <asp:Label ID="_oLabelEmail" runat="server" Text='<%# Eval("Email")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                             <asp:TemplateField HeaderText="Transaction Type" >
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTransType" runat="server" Text='<%# Eval("TransType")%>' />                                                                    
                                    </ItemTemplate>
                                </asp:TemplateField>     
                            
                               <asp:TemplateField HeaderText="Attachment"  >
                                    <ItemTemplate>
                                        <a href="#" onclick="do_Process('Approve','<%# Eval("TransType")%>' , '<%# Eval("Email")%>');">Download</a>                     
                                         </ItemTemplate>
                                </asp:TemplateField>           
                          
                            <asp:TemplateField HeaderText="Approve">
                                    <ItemTemplate>                                                   
                                         <a href="#" style="color:green" data-toggle="modal" data-target="#div_Process" data-ticket-type="standard-access" onclick="do_Process('Approve','<%# Eval("TransType")%>' , '<%# Eval("Email")%>');">Approve</a>
                                            </ItemTemplate>
                                </asp:TemplateField>

                             <asp:TemplateField HeaderText="Deny">
                                    <ItemTemplate>                                                                                        
                                         <a href="#" style="color:red" data-toggle="modal" data-target="#div_Process" data-ticket-type="standard-access" onclick="do_Process('Deny','<%# Eval("TransType")%>' , '<%# Eval("Email")%>');">Deny</a>
                                           </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                    </asp:GridView>


         <!-- Modal div_Process Form -->
      <div id="div_Process" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title" id="ModalHeader"></h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>               
            <div class="modal-body">              
                <div class="form-group text-center">
                    Remarks
                <textarea type="text" required id="txtRemarks" name="txtRemarks" runat="server"/>  
                <input type="hidden" id="hdnTranstype" runat="server"/>
                <input type="hidden" id="hdnEmail" runat="server"/>         
                <input type="hidden" id="hdnRemarks" runat="server"/>

                
                </div> 
                <center>
                     <input type="button" id="btnProcess" class="btn btn-primary small" onclick="do_Process2(this.value);"/>
                        </center>
                 
                                                   
            </div>
                  
               
          
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div><!-- /.modal -->

                



    <script>
        function do_Process(Status, Transtype, Email) {

            document.getElementById('<%= hdnTranstype.ClientID%>').value = Transtype;
            document.getElementById('<%= hdnEmail.ClientID%>').value = Email; 
            document.getElementById('btnProcess').value = Status;

            if (Status == 'Approve') {
                document.getElementById('ModalHeader').innerHTML = "Approve Request";
            }
            else if (Status == 'Deny') {
                document.getElementById('ModalHeader').innerHTML = "Deny Request";
            }
           
         
          
           
        }    

        function do_Process2(Status) {            
            __doPostBack(Status, '');
                }



    
    </script>

</asp:Content>