<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Gcash_Checker.aspx.vb" Inherits="SPIDC.Gcash_Checker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
    </asp:ScriptManager>
          
      <asp:UpdatePanel runat="server">
         <ContentTemplate>
             <asp:Timer runat="server" ID="Timer1" OnTick="Timer1_Tick"></asp:Timer>
                </ContentTemplate>
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick"/>
              </Triggers>
     </asp:UpdatePanel>
    </form> 
   
</body>
</html>
