<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GETDATE.aspx.vb" Inherits="SPIDC.GETDATE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
         <asp:ScriptManager runat="server">

    </asp:ScriptManager>
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <input type="text" value="MM/dd/yyyy" runat="server" id="txtFormat" />
                    <input type="button" value="GetDate" runat="server" id="btnGetDate" />

                    <table>
                        <tr>
                            <td>SERVER</td>
                            <td>GETDATE()</td>
                        </tr>
                        <tr>
                            <td>SOS_BP</td>
                            <td runat="server" id="SOS_BP"></td>
                            <td runat="server" id="SOS_BP_Con"></td>
                        </tr>
                        <tr>
                            <td>SOS_CR</td>
                            <td runat="server" id="SOS_CR"></td>
                            <td runat="server" id="SOS_CR_Con"></td>
                        </tr>
                        <tr>
                            <td>SOS_OAIMS</td>
                            <td runat="server" id="SOS_OAIMS"></td>
                            <td runat="server" id="SOS_OAIMS_Con"></td>
                        </tr>
                        <tr>
                            <td>SOS_RPT</td>
                            <td runat="server" id="SOS_RPT"></td>
                             <td runat="server" id="SOS_RPT_con"></td>
                        </tr>
                        <tr>
                            <td>SOS_TIMS</td>
                            <td runat="server" id="SOS_TIMS"></td>
                             <td runat="server" id="SOS_TIMS_con"></td>
                        </tr>
                        <tr>
                            <td>BPLTAS</td>
                            <td runat="server" id="BPLTAS"></td>
                             <td runat="server" id="BPLTAS_con"></td>
                        </tr>
                        <tr>
                            <td>RPTAS</td>
                            <td runat="server" id="RPTAS"></td>
                            <td runat="server" id="RPTAS_Con"></td>
                        </tr>
                        <tr>
                            <td>TOIMS</td>
                            <td runat="server" id="TOIMS"></td>
                            <td runat="server" id="TOIMS_Con"></td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>



        </div>
    </form>
</body>
</html>
