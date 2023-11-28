<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TestReUpload.aspx.vb" Inherits="SPIDC.TestReUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:GridView ID="gv_test" runat="server" CssClass="mGrid col-lg-12 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>          
                    <asp:TemplateField HeaderText="ReqCode">
                        <ItemTemplate>
                           <asp:Label ID="lbl_ReqCode" runat="server" Text='<%# Eval("ReqCode")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                           
                     <asp:TemplateField HeaderText="Requirement" ItemStyle-HorizontalAlign="CENTER" >
                        <ItemTemplate>
                            <label><%# Eval("REQDESC")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="COMPLIANT" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>
                            <label><%# Eval("WEBCOMPLIANT")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>        
                    
                      <asp:TemplateField HeaderText="Upload" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>                
                            <input type="file" id="REQ<%# Eval("REQCODE")%>" /> 
                             <a download="<%# Eval("FileName")%>"
                               href="<%# Eval("File64")%>"   
                              target="_blank" class="btn btn-primary btn-sm col ">
                               <%# Eval("FileName")%>
                            </a>        
                            </ItemTemplate>
                    </asp:TemplateField>          

                  

                    <asp:TemplateField HeaderText="File Size"  ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>                
                             <label id="FS<%# Eval("REQCODE")%>"><%# Eval("FileSize")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
    </div>
    </form>
</body>
</html>
