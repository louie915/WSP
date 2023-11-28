<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AssetTest.aspx.vb" Inherits="SPIDC.AssetTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="_GVBusinessLine" runat="server" CssClass="mGrid col-lg-10 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>
                    <asp:TemplateField HeaderText="Business Code">
                        <ItemTemplate>
                            <label class="txBusCode"><%# Eval("BUS_CODE")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Business Line" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("BUSLINE")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="CATEGORY" ItemStyle-HorizontalAlign="left" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusinessLine" runat="server" Text='<%# Eval("CATEGORY")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Enter Gross" ItemStyle-HorizontalAlign="right" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <input type="text" id="Gross<%# Eval("BUS_CODE")%>" name="txtGross" style="width: 100%" onfocus="do_focus(this.id,this.value)" onblur="do_blur(this.id,this.value)" value="<%# Eval("TaxpayerGross")%>" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Enter Asset" ItemStyle-HorizontalAlign="right" HeaderStyle-Width="20%">
                        <ItemTemplate>
                            <input type="text" id="Asset<%# Eval("BUS_CODE")%>" name="txtAsset" style="width: 100%"  onfocus="do_focus(this.id,this.value)" onblur="do_blur(this.id,this.value)" value="<%# Eval("TaxpayerAsset")%>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <input type="button" value="Save" id="_btnSave" onclick="do_Save()" />
            <input type="button" value="Save" id="btnSave" runat="server" style="display: none;" />

            <input type="hidden" id="hdnGross" runat="server" />
            <input type="hidden" id="hdnAsset" runat="server" />
            <input type="hidden" id="hdnGrossAsset" runat="server" />

            <textarea id="taGross"></textarea>
            <textarea id="taAsset"></textarea>
            <textarea id="taGrossAsset"></textarea>
            <script>
                function do_Save() {
                    var txBusCode = document.getElementsByClassName('txBusCode');    
                    for (let i = 0; i < txBusCode.length; i++) {            
                        document.getElementById('<%= hdnGross.ClientID%>').value += txBusCode[i].innerHTML + ':' + parseFloat(document.getElementsByName('txtGross')[i].value.replace(/,/g, '')).toFixed(2) + ';';
                        document.getElementById('<%= hdnAsset.ClientID%>').value += txBusCode[i].innerHTML + ':' + parseFloat(document.getElementsByName('txtAsset')[i].value.replace(/,/g, '')).toFixed(2) + ';';
                        document.getElementById('<%= hdnGrossAsset.ClientID%>').value += txBusCode[i].innerHTML + ':' + parseFloat(document.getElementsByName('txtGross')[i].value.replace(/,/g, '')).toFixed(2) + ':' + parseFloat(document.getElementsByName('txtAsset')[i].value.replace(/,/g, '')).toFixed(2) + ';';
                    }
                    document.getElementById('taGross').value = document.getElementById('<%= hdnGross.ClientID%>').value;
                    document.getElementById('taAsset').value = document.getElementById('<%= hdnAsset.ClientID%>').value;
                    document.getElementById('taGrossAsset').value = document.getElementById('<%= hdnGrossAsset.ClientID%>').value;

                     document.getElementById('<%= btnSave.ClientID%>').click();
                }
                function do_focus(id, val) {
                    document.getElementById(id).value = val.replace(/,/g, '');
                    document.getElementById(id).type = 'Number'
                }
                function do_blur(id, val) {
                    document.getElementById(id).type = 'Text'
                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: 'PHP',
                    });

                    var x = formatter.format(val);
                    x = x.split('PHP').join('');
                    x = x.replace(/\s/g, '');
                    x = x.replace('₱', '');
                    document.getElementById(id).value = x;
                }
            </script>
        </div>
    </form>
</body>
</html>
