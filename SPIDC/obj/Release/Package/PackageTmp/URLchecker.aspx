<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="URLchecker.aspx.vb" Inherits="SPIDC.URLchecker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <tr>
            <td>HttpContext.Current.Request.Url.AbsoluteUri;</td>
            <td runat="server" id="Td1"></td>
        </tr>   
        <tr>
            <td>HttpContext.Current.Request.Url.Host;</td>
           <td runat="server" id="Td2"></td>
        </tr>
        <tr>
            <td>HttpContext.Current.Request.Url.Authority;</td>
            <td runat="server" id="Td3"></td>
        </tr>
        <tr>
            <td>HttpContext.Current.Request.Url.Port;</td>
             <td runat="server" id="Td4"></td>
        </tr>
        <tr>
            <td>HttpContext.Current.Request.Url.AbsolutePath;</td>
            <td runat="server" id="Td5"></td>
        </tr>
        <tr>
            <td>HttpContext.Current.Request.ApplicationPath;</td>
             <td runat="server" id="Td6"></td>
        </tr>
        <tr>
            <td>HttpContext.Current.Request.Url.PathAndQuery;</td>
            <td runat="server" id="Td7"></td>
        </tr>
        <tr>
            <td>HttpContext.Current.Request.RawUrl;</td>
           <td runat="server" id="Td8"></td>
        </tr>
        <tr>
            <td>Request.Url.AbsoluteUri.Split('?')[0]</td>
           <td runat="server" id="Td9"></td>
        </tr>  

    </table>
    </div>
    </form>
</body>
</html>
