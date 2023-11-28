<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GenerateQR.aspx.vb" Inherits="SPIDC.GenerateQR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QR Generate</title>  

</head>
<body>
   <form id="form1" runat="server">  
        <div class="container">       
            <div class="row">  
                <div class="col-md-4">  
                    <div class="form-group">          
                        <div class="input-group">  
                            <asp:TextBox ID="txtQRCode" runat="server" CssClass="form-control"></asp:TextBox>  
                            <div class="input-group-prepend">  
                                <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-secondary" Text="Generate" OnClick="btnGenerate_Click" />  
                            </div>  
                        </div>  
                    </div>  
                </div>  
            </div>  
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">

                
            </asp:PlaceHolder>  
        </div>  
    </form>  
</body>
</html>
