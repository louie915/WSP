<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/LGUOSMainPage.Master" CodeBehind="LGUeOR.aspx.vb" Inherits="SPIDC.LGUeOR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="modal fade" id="ModalViewPending">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-warning">
                    <i class="fa fa-question-circle text-white float-right" style="font-size: 30px;"></i>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white" >Pending eOR</h4>
                    <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body" align="center" id="pdfcontainer1" runat="server">
                 
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn-sm" data-dismiss="modal" id="_oBtnCancel" runat="server">Cancel</button>
                    <button type="button" class="btn btn-success btn-sm" data-dismiss="modal" id="_oBtnOkay" runat="server" onclick="verify('Verify','')">Confirm</button>
                </div>
            </div>
        </div>
    </div>


    <div class="row" style="padding: 10px">
        <div class="col-sm-12 mb-2">
            <div class="card shadow">
             
                    <div class="card-header">
                    <label class=" font-weight-bold text-primary">Pending e-OR List</label>
                </div>
             

                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-12">
                            <div>                               
                              <asp:GridView ID="gv_Pending" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="PageIndexChanging_Pending"
                            PageSize="10"  >
                            <PagerSettings Mode="NumericFirstLast"
                                FirstPageText="First"
                                LastPageText="Last"
                                PageButtonCount="5"
                                Position="Bottom"
                                Visible="true" />
                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />

                           <Columns>
                                 <asp:TemplateField HeaderText="eOR No."  ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <Label ><%# Eval("eORno")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Online ID" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <Label ><%# Eval("OnlineID")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>             

                                <asp:TemplateField HeaderText="TaxType"  ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <Label ><%# Eval("TaxType")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="BIN / TDN" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                       <Label ><%# Eval("TDNBIN")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Payor Name" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <Label ><%# Eval("PayorName")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                                              

                                <asp:TemplateField HeaderText="Sent Date"  ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                       <Label ><%# Eval("Sent_Date")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>                                       
                                        <a href="#" onclick="do_View('<%# Eval("eORno")%>','<%# Eval("TDNBIN")%>','<%# Eval("TaxType")%>','Sent')">View</a>                                                                                  
                                      <a href="#" onclick="do_Send('<%# Eval("eORno")%>','<%# Eval("TDNBIN")%>','<%# Eval("TaxType")%>','Pending')">Send</a>                                                        
                                         </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                               
                                  </asp:GridView>
                            </div>
                        </div>        
                    </div>                  
                </div>
            </div>
        </div>

        <div class="col-sm-12 mb-2">
            <div class="card shadow">
              
                    <div class="card-header">
                        <label class=" font-weight-bold text-primary">Sent e-OR List</label>
                    </div>
            

                <div class="card-body">
                    <div class="form-row">
                        <div class="form-group col-12">
                            <div>
                               
                              <asp:GridView ID="gv_Sent" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11" AllowPaging="True" OnPageIndexChanging="PageIndexChanging_Sent"
                            PageSize="10">
                            <PagerSettings Mode="NumericFirstLast"
                                FirstPageText="First"
                                LastPageText="Last"
                                PageButtonCount="5"
                                Position="Bottom"
                                Visible="true" />
                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />

                            <Columns>
                                 <asp:TemplateField HeaderText="eOR No."  ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <Label ><%# Eval("eORno")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Online ID" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <Label ><%# Eval("OnlineID")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>             

                                <asp:TemplateField HeaderText="TaxType"  ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <Label ><%# Eval("TaxType")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="BIN / TDN" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                       <Label ><%# Eval("TDNBIN")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Payor Name" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <Label ><%# Eval("PayorName")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                                              

                                <asp:TemplateField HeaderText="Sent Date"  ItemStyle-HorizontalAlign="right">
                                    <ItemTemplate>
                                       <Label ><%# Eval("Sent_Date")%></Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="18%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>                                       
                                        <a href="#" onclick="do_View('<%# Eval("eORno")%>','<%# Eval("TDNBIN")%>','<%# Eval("TaxType")%>','Sent')">View</a>                                                                                  
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                            </div>
                        </div>        
                    </div>                  
                </div>
            </div>
        </div>
          </div> 
    <input type="hidden" runat="server" id="hdnEORno" />
    <input type="hidden" runat="server" id="hdnTDNBIN" />
    <input type="hidden" runat="server" id="hdnTAXTYPE" />
    <input type="hidden" runat="server" id="hdnStatus" />
    <input type="button" runat="server" id="btn_View" style="display:none;" />
    <input type="button" runat="server" id="btn_Send" style="display:none;"  />

    <script>
        function do_View(eORno, TDNBIN, TAXTYPE, Status) {
          //  alert(eORno);
          //  alert(TDNBIN);
          //  alert(TAXTYPE);
          //  alert(Status);
         document.getElementById('<%= hdnEORno.ClientID%>').value = eORno;
         document.getElementById('<%= hdnTDNBIN.ClientID%>').value = TDNBIN;
         document.getElementById('<%= hdnTAXTYPE.ClientID%>').value = TAXTYPE;
         document.getElementById('<%= hdnStatus.ClientID%>').value = Status;
         document.getElementById('<%= btn_View.ClientID%>').click();
        }

        function do_Send(eORno, TDNBIN, TAXTYPE, Status) {
            document.getElementById('<%= hdnEORno.ClientID%>').value = eORno;
             document.getElementById('<%= hdnTDNBIN.ClientID%>').value = TDNBIN;
             document.getElementById('<%= hdnTAXTYPE.ClientID%>').value = TAXTYPE;
             document.getElementById('<%= hdnStatus.ClientID%>').value = Status;
             document.getElementById('<%= btn_Send.ClientID%>').click();
         }
    </script>
</asp:Content>
