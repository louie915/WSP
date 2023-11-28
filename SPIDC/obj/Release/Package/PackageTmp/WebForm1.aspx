<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="SPIDC.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
    <input id="btndeletebookmark" class="button" type="button" value="Delete" />
</div>
<div class="row">
    <asp:CheckBoxList ID="lstBookmark" runat="server">
        <asp:ListItem Text="Mango" Value="Mango" />
        <asp:ListItem Text="Apple" Value="Apple" />
        <asp:ListItem Text="Banana" Value="Banana" />
        <asp:ListItem Text="Orange" Value="Orange" />
    </asp:CheckBoxList>
</div>
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("#btndeletebookmark").click(function (e) {
            e.preventDefault();
            var ids = [];
            $("#lstBookmark input[type='checkbox']:checked").each(function () {
                ids.push($(this).val());
            });
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebForm1.aspx/DeleteBookMark",
                data: JSON.stringify({ BookmnarkID: ids }),
                dataType: "json",
                success: function (data) {
                    alert("Bookmark Removed Successfully");
                    location.reload();
                },
                error: function (result) {
                    alert(result.responseText);
                }
            });
        })
    });
</script>
    </div>
    </form>
</body>
</html>
