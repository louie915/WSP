

<%@ Page Title="" Language="vb" AutoEventWireup="false" CodeBehind="Permit.aspx.vb" Inherits="SPIDC.Permit" MasterPageFile="~/WebPortal/OSMainPage.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="w3-overlay w3-animate" onclick="w3_close()" style="cursor: pointer" id="myOverlay"></div>
    <asp:UpdatePanel ID="UpdatePanel13" runat="server">
        <ContentTemplate>

            <asp:Label runat="server" ID="querystring" Style="display: none"></asp:Label>
            <asp:Label runat="server" ID="connectionstring" Style="display: none"></asp:Label>

            <center>
            <asp:Panel runat="server" ID="_oPanelPersonalInfo" class="input-group-text  col-12" Style="text-align: left">
                    <center>
                <div class="card shadow m-2 " style="width: 100%; vertical-align: middle">
                    
                    <div class="card-body">
                    
                        <div style="width: 100%">
                            <asp:Button runat="server" ID="btnPrint" CssClass="hover-mouse-kun btn btn-primary color-btn-kun" Text="Display & Save" Style="width: 20% ; display : none"/>
                            <%--<asp:Button runat="server" ID="SendEmailButton" CssClass="hover-mouse-kun btn btn-primary color-btn-kun" Text="button" Style="width: 20%"/>--%>
                            <%--<input type="button" runat="server" ID="SendEmailButton" class="hover-mouse-kun btn btn-primary color-btn-kun" value="button" Style="width: 20%" onclick="Export"/>--%>
                           
                        </div>
                        <br />

                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                  <rsweb:ReportViewer ID="_oMSRV"
                            runat="server"
                            Height="1000px" Width="100%"
                            ZoomMode="PageWidth"
                            Font-Names="Verdana"
                            Font-Size="8pt"
                            WaitMessageFont-Names="Verdana"
                            WaitMessageFont-Size="14pt"
                            PageCountMode="Actual"
                            SizeToReportContent="true">
                        </rsweb:ReportViewer>

                                <br />
                                  <asp:ImageButton  ID="btnExport" CssClass="buttons" runat="server" ImageUrl="../../CSS_JS_IMG/img/DownloadPDF.png" OnClick="Export" />

                            </ContentTemplate>

                             <Triggers>
                        <asp:PostBackTrigger ControlID="_oMSRV"/>
                        <asp:PostBackTrigger ControlID="btnExport"/>
                                 
                    </Triggers>
                        </asp:UpdatePanel>
                      
                    </div>
                    <br />
                    </center>
            </asp:Panel>
            </center>

        </ContentTemplate>

    </asp:UpdatePanel>


</asp:Content>
