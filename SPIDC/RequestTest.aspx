<%@ Page Language="vb" 
    AutoEventWireup="false" 
    EnableEventValidation="false"  
    CodeBehind="RequestTest.aspx.vb" Inherits="SPIDC.RequestTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
   <form runat="server" id="frmNone">
        <asp:ScriptManager runat="server">
            
    </asp:ScriptManager>
       <input type="file" runat="server" id="FileUpload1"/><br />
       <input type="button" runat="server" value="Post File" id="btnUpload"/>
       <br /><br />

       <textarea runat="server" id="txt64" placeholder="Enter Base64"></textarea> <br />
        <input type="button" value="Convert to FileData" runat="server" id="btnSubmit"/> <br />

       <textarea runat="server" id="txtFileData" placeholder="Result"></textarea> <br />

       <input type="button" value="getURL" id="btnGetURL" runat="server"/>
       <input type="text" placeholder="URL shows Her" readonly  runat="server" id="txtURL"/>
   </form>
 
</body>
</html>
