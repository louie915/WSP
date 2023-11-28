<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="ImageSetup.aspx.vb" Inherits="SPIDC.ImageSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <center>

      

    <div class="col-md-12 row ">
        <br /><br />
        <div class="col-lg-4 " style="text-align: left; border:1px solid gray">
              <div class=" p-1"><h5 class="m-1 font-weight-bold text-primary">Carousel Setup</h5></div>
 
            <asp:FileUpload ID="FileUpload1" CssClass="upload-file" runat="server" />
               
            <input type="button" class="btn btn-primary"  value="Upload" id="_btnUpload" onclick="do_Click(this.id);"/>
            <input type="button" class="btn btn-primary" value="Remove All" id="_btnRemoveAll" onclick="do_RemoveAll(this.id);"/>

            <asp:Button ID="Button1" style="display:none;" Text="Upload" runat="server" OnClick="Upload" />
             <asp:Button ID="btnRemoveAll" style="display:none;" Text="Remove All" runat="server" OnClick="RemoveAll" />
              <br />
              <Label ID="lblMessage" >Selected File/s Total Size : </Label> 
           
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div style="text-align:left">
                    <Label style="color:blue;"> Max Total Uploaded File Size : 10mb</Label> <br />
            <Label style="color:green;" id="lblTotFileSize" runat="server"> Total Uploaded File Size : 0 KB</Label> 
           
                </div>
                  <asp:GridView ID="gv_Carousel" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                        <Columns>                      
                <asp:TemplateField HeaderText="File Name" ItemStyle-HorizontalAlign="Center" Visible="false">
                    <ItemTemplate>
                     <asp:Label ID="_oLabelFileName" runat="server" Text='<%# Eval("FileName")%>' />
                    </ItemTemplate>
                </asp:TemplateField>

                             <asp:TemplateField HeaderText="File Size" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                     <asp:Label ID="_oLabelFileSize" runat="server" Text='<%# Eval("strSize")%>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Preview" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <img src="<%# Eval("File64")%>"  height="100"/>                      

                      

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a  href="#" onclick="do_Remove('<%# Eval("FileID")%>','<%# Eval("FileName")%>')" style=" color: red; ">Remove</a>
                   
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>       
        </div>

         <div class="col-lg-4 " style="text-align: left; border:1px solid gray">
                 <div class=" p-1"><h5 class="m-1 font-weight-bold text-primary">Terms Setup</h5></div>
             <div class="form-row">
                            <div class=" form-group  col-lg-12">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2"><b style="color: red; font-size: large">*&nbsp</b>Title</span></span>
                                </label>
                                <input type="text" runat="server" name="txtTitle" class="form-control CH-size-new" id="txtTitle" />
                            </div>

                            <div class="form-group  col-lg-12">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2"><b style="color: red; font-size: large">*&nbsp</b>Content</span></span>
                                </label>
                                    <textarea  class="form-control CH-size-new" style="height:50vh" runat="server" id="txtContent"></textarea>
                                  </div>
                            <div class="col-lg-12">                             
                                <input type="button" id="btnSaveTerms" class="btn btn-primary col-lg-12" value="Save Terms" onclick="do_SaveTerms();" />
                            </div>
                 <br /><br />
                        </div>

         </div>

         <div class="col-lg-4 " style="text-align: left; border:1px solid gray">
                 <div class=" p-1"><h5 class="m-1 font-weight-bold text-primary">Announcement Setup</h5></div>
             <div class="form-row">
                   <div class=" form-group  col-lg-6">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2"><b style="color: red; font-size: large">*&nbsp</b>Status</span></span>
                                </label>
                       <div class="form-control CH-size-new">
                             &nbsp &nbsp 
                            <input type="radio" runat="server" name="ANN_STATUS" checked id="ANN_1" />
                                <label for="ANN_1">Enable</label>
                           &nbsp &nbsp &nbsp &nbsp
                                <input type="radio" runat="server" name="ANN_STATUS"  id="ANN_0" />
                                <label for="ANN_0">Disable</label>
                       </div>
                               
                            </div>


                    <div class=" form-group  col-lg-6">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2"><b style="color: red; font-size: large">*&nbsp</b>Date</span></span>
                                </label>
                                <input type="text" runat="server" name="ANN_Date" class="form-control CH-size-new" id="ANN_Date" />
                            </div>

                            <div class=" form-group  col-lg-12">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2"><b style="color: red; font-size: large">*&nbsp</b>Title</span></span>
                                </label>
                                <input type="text" runat="server" name="ANN_Title" class="form-control CH-size-new" id="ANN_Title" />
                            </div>

               

                            <div class="form-group  col-lg-12">
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2"><b style="color: red; font-size: large">*&nbsp</b>Content</span></span>
                                </label>
                                    <textarea  class="form-control CH-size-new" style="height:44vh" runat="server" id="ANN_content"></textarea>
                                  </div>
                            <div class="col-lg-12">                             
                                <input type="button" id="btnSaveANN" class="btn btn-primary col-lg-12" value="Save Announcement" onclick="do_SaveANN();" />
                            </div>
                 <br /><br />
                        </div>

         </div>
       
    </div>
        </center>
    <div id="snackbar"></div>

    <input type="hidden" id="hdnFileID" runat="server" />
    <input type="hidden" id="hdnFileName" runat="server" />
    <input type="hidden" id="ANN_STATUS" runat="server" />
    <asp:Button ID="btnRemove" Style="display: none;" runat="server" OnClick="Remove" />
    <asp:Button ID="_btnSaveTerms" Style="display: none;" runat="server" OnClick="SaveTerms" />
    <asp:Button ID="_btnSaveANN" Style="display: none;" runat="server" OnClick="SaveANN" />
    <script>

        $("document").ready(function () {
            $(".upload-file").on('change', function () {
                var totalSize = 0;
                $(".upload-file").each(function () {
                    console.dir(this);
                    for (var i = 0; i < this.files.length; i++) {
                        totalSize += this.files[i].size;
                    }
                });

                document.getElementById('lblMessage').innerText = 'Selected File/s Total Size : ' + fileSizeSI(totalSize);

                var valid = totalSize <= 10485760;
                if (!valid) {
                    alert('Over Max Size');
                    document.getElementById('<%= FileUpload1.ClientID%>').value = '';
                    document.getElementById('lblMessage').innerText = 'Total Size : ';
                }

                // 
                // document.getElementById('lblMessage').innerText = 'Total Size : ';
            });
        })

        function fileSizeSI(size) {
            var e = (Math.log(size) / Math.log(1e3)) | 0;
            return +(size / Math.pow(1e3, e)).toFixed(2) + ' ' + ('kMGTPEZY'[e - 1] || '') + 'B';
        }

        function do_Click(ID) {
            if (document.getElementById('<%= FileUpload1.ClientID%>').value !== "") {
                document.getElementById(ID).value = 'Uploading ...';
                document.getElementById(ID).disabled = true;
                document.getElementById('<%= Button1.ClientID%>').click();
            }
            else { alert('No File Chosen'); }
        }

        function do_RemoveAll(ID) {
            if (document.getElementById('<%= gv_Carousel.ClientID%>').getElementsByTagName('a').length > 0) {
                document.getElementById(ID).value = 'Removing ...';
                document.getElementById(ID).disabled = true;
                document.getElementById('<%= btnRemoveAll.ClientID%>').click();
            }

            else { alert('Already Empty'); }
        }

        function do_Remove(FileID, FileName) {
            document.getElementById('<%= hdnFileID.ClientID%>').value = FileID;
    document.getElementById('<%= hdnFileName.ClientID%>').value = FileName;
    var g = document.getElementById('<%= gv_Carousel.ClientID%>');

    let text = "Are you sure you want to Remove this File?\n" + FileName;
    if (confirm(text) == true) {
        document.getElementById('<%= btnRemove.ClientID%>').click();
            }
        }

        function do_SaveTerms() {
            if (document.getElementById('<%= txtTitle.ClientID%>').value !== "" && document.getElementById('<%= txtContent.ClientID%>').value !== "") {
                document.getElementById('btnSaveTerms').value = 'Saving ...';
                document.getElementById('btnSaveTerms').disabled = true;
                document.getElementById('<%= _btnSaveTerms.ClientID%>').click();
            }
            else { alert('Incomplete Fields'); }
        }

        function do_SaveANN() {
            if (document.getElementById('<%= ANN_Title.ClientID%>').value !== "" && document.getElementById('<%= ANN_content.ClientID%>').value !== "" && document.getElementById('<%= ANN_DATE.ClientID%>').value !== "") {
                 document.getElementById('btnSaveANN').value = 'Saving ...';
                 document.getElementById('btnSaveANN').disabled = true;
                 document.getElementById('<%= _btnSaveANN.ClientID%>').click();
            }
            else { alert('Incomplete Fields'); }
        }


    </script>
</asp:Content>
