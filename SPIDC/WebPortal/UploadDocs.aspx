
 <%@    Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="UploadDocs.aspx.vb" Inherits="SPIDC.UploadDocs" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
 
       <style>
     .ButtonCss:disabled {
        opacity:0.5;
        cursor:not-allowed;
    }
     .ButtonCss:enabled {
        opacity:1;
        cursor:default;
        }

    </style>
  <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

        <script>
            //SNACKBAR - Welcome       
            function SnackbarGreen() {
                var x = document.getElementById("snackbargreen");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
            }
            function Snackbar() {
                var x = document.getElementById("snackbar");
                x.className = "show";
                setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
            }
    </script>

     <link href="../CSS_JS_IMG/css/chosen.css" rel="stylesheet" />
    <script src="../CSS_JS_IMG/js/chosen.jquery.js"></script>

      <div id="snackbar" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbar"/>           
        </div>
        <div id="snackbargreen" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
        </div>

    
      <div class="container">
        <center> 
          <div class="col-md-10">
           <div class="details">             
		   <div  style="border:1px solid gray; background-color:white; padding:10px;display:block;">
                <div  style="text-align:center;font-family:Arial;" >
                  <h2 style="" >Business Permit Application</h2>
                </div>

              
		       <%-- <Strong>Upload Documents</Strong> --%>
                 <div class="progress">
                <div class="progress-bar progress-bar-striped active " role="progressbar" style="width:0%">
                0%
                </div>
              </div>   
               <br />
                <div class="btn-primary"><strong>Upload Image Attachments and Requirements</strong></div>
               <hr />		
               
             <div class="instruct">
                    <ul style="padding:0px 0px 0px 35px;">
                        <li> Upload soft-copy of neccessary document.</li>
                        <li> Fields with (<span style="color:red;font-size:large">*</span>) indicator are required. </li>
                        <li> Maximum of 10mb file size per file </li>
                        <li> Multiple page documents must be compiled into single PDF file or archive(.rar, .zip) before uploading.  </li>
                        <li > If you mistakenly uploaded the wrong file, just browse and upload again to replace the previous file. </li>
                    </ul>
                </div>

         
     <br />
     <%-- <div class="btn-primary"><strong>Image Attachment - Business</strong></div>--%>

               <asp:UpdatePanel runat="server">
                   <ContentTemplate>    
                       
                          <div style="text-align:left;">Owner's picture: <span style="color:red;font-size:large"> *</span></div> 
                    <asp:FileUpload ID="_oFileUploadOwnerPic" runat="server" ViewStateMode="Enabled"  Title=" "  AllowMultiple="true" />
                      
                        <asp:HyperLink ID="_oHyperLinkowner" runat="server" Target="_blank" Visible="false"> View Uploaded Picture </asp:HyperLink>
                  
                      
                       <br /> <br />
                 <div style="text-align:left;">Business Establishment picture: <span style="color:red;font-size:large"> *</span></div>
                    <asp:FileUpload ID="_oFileUploadEstablishment" runat="server"  ViewStateMode="Enabled" Title=" "  AllowMultiple="true" />
                       <asp:HyperLink ID="_oHyperLinkestablishment" runat="server" Target="_blank" Visible="false"> View Uploaded Picture </asp:HyperLink>
                    <label for="imageUpload2"></label>

                          <br /> <br />
                 <div style="text-align:left;">Business Map Location picture: <span style="color:red;font-size:large"> *</span></div>
                        <asp:FileUpload ID="_oFileUploadMapLoc" runat="server"  ViewStateMode="Enabled" Title=" " AllowMultiple="true"/>
                       <asp:HyperLink ID="_oHyperLinkmaplocation" runat="server" Target="_blank" Visible="false"> View Uploaded Picture </asp:HyperLink>
                    <label for="imageUpload3"></label> 
                 
                   </ContentTemplate>               
               </asp:UpdatePanel>    

       
                             <asp:Button class="btn btn-primary" ID="_oButtonUploadAttachment" runat="server" 
                                        Font-Size="small" UseSubmitBehavior="false" Text="Upload file/s"  Visible="false" />                           
                    
		  <hr/>
                    <%-- <div class="btn-primary"><strong>Image Attachment - Requirements</strong></div>--%>

              
               <asp:UpdatePanel runat="server">
                <ContentTemplate>

                     <asp:Panel id="_oPanelGridViewRequirementsList" runat="server" CssClass="input" ScrollBars="Auto" Width="98%">
                                    <asp:GridView id="_oGridViewRequirementsList" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
                                        PagerSettings-Mode="NumericFirstLast" PageSize="10" ShowFooter="True" ShowHeaderWhenEmpty="True"
                                        Width="100%" AllowPaging="false" CssClass="GridViewStyle mGrid"
                                        DataKeyNames="ReqCode"  OnRowDataBound="OnRowDataBound"
                                        >
                                        <FooterStyle CssClass="GridViewFooterStyle" />
                                        <RowStyle CssClass="GridViewRowStyle" />
                                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                        <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                        <HeaderStyle CssClass="GridViewHeaderStyle" />
                                        <Columns>
                                              <asp:TemplateField HeaderText="Mandatory">
                                                <ItemTemplate>
                                                    <center>
                                                      <asp:Image ID="Image1" ImageUrl='<%#_FnLoadImage%>' 
                                                         runat="server" Visible='<%#showImageIfCalled(Eval("COMPLIANT").ToString()) %>'
                                                        Height="20" Width="20" 
                                                     />
                                                    </center>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="cssGridViewItemStyleCenter" Width="5px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Code" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLabelListReqCode" runat="server" Text='<%# Eval("REQCODE")%>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="0px" />
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLabelListDescription" runat="server" Text='<%# Eval("REQDESC")%>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="390px" />
                                            </asp:TemplateField>      

                                          
                                                                            
                                            <asp:TemplateField HeaderText="File Count" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="_oLabelFileCount" runat="server" Text='<%# Eval("ImageCount")%>' />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="cssGridViewItemStyleCenter" Width="20px" />
                                            </asp:TemplateField> 
                                            <asp:TemplateField HeaderText="Upload Images">
                                                <ItemTemplate>
                                                     <asp:FileUpload ID="_oFileUploadRequirements" runat="server" Multiple="Multiple" />
                                                </ItemTemplate>
                                                <ItemStyle CssClass="cssGridViewItemStyleCenter" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="View Image" Visible="false">
                                                 <ItemTemplate>
                                                     <asp:HyperLink ID="_oHyperLinkViewImages" runat="server" Target="_blank"  visible="false"  Style="color: Black"
                                                                   Autoposback="true">View Uploaded Image</asp:HyperLink>
                                                 </ItemTemplate>
                                                 <ItemStyle CssClass="cssGridViewItemStyleCenter" Width="10px" />
                                            </asp:TemplateField>
                                          
                                            <%-- BIND UPLOADED IMAGE--%>
                                             <asp:TemplateField  HeaderText="Uploaded File">
                                            <ItemTemplate>
                                                <center>
                                    <%-- <img alt="" style="cursor: pointer" src="../CSS_JS_IMG/img/plus.png" />--%>
                                         <asp:Panel ID="pnl_oGridviewReqSubmitted" runat="server" style="text-align:center;" >
                                                    <asp:GridView ID="_oGridviewReqSubmitted" runat="server" DataKeyNames="ReqCode"  gridviewline="none"
                                                        AutoGenerateColumns="false" GridLines="None" Width="100%" height="100%" CssClass="tblnested">
                                                        <Columns>
                                                            <asp:BoundField DataField="ReqCode" HeaderText="ReqCode" Visible="false" />
                                                            <asp:BoundField DataField="ImagesID" HeaderText="ImageID" Visible="false" />
                                                            <asp:BoundField DataField="Name" HeaderText="File Name" Visible="false" />
                                                         <asp:TemplateField HeaderText="">
                                                                 <ItemTemplate>
                                                                    <asp:hyperlink ID="_oHyperLinkReqSubmitted" runat="server" Target="_blank" Enabled ="True" 
                                                                        NavigateUrl= '<%# Eval("ImageID", "ViewImage/ViewImage.aspx?Id={0}&Switch=B")%>'
                                                                           Text="View">
                                                                    </asp:hyperlink>
                                                                </ItemTemplate>
                                                                <ItemStyle />
                                                          </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                             <style>
                                                 .tblnested th {
                                                    
                                                     background-color:transparent !Important;border:0 !Important;
                                                 
                                                 }
                                                 .tblnested td
                                                 {
                                                     background-color:transparent !Important;border:0 !Important;
                                                 }
                                                 .tblnested tr {
                                                 
                                                    background-color:transparent !Important;border:0 !Important;
                                                 
                                                 }
                                             </style>
                                          </asp:Panel>
                                         </center>
                                </ItemTemplate>
                                                 <ItemStyle CssClass="cssGridViewItemStyleCenter" Width="70px" />
                                </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                      </asp:Panel>

                </ContentTemplate>
            </asp:UpdatePanel>


     
         <br />
         <div>
                             <asp:Button class="btn btn-primary" ID="_oButtonUploadImages" runat="server" 
                                        Font-Size="small" UseSubmitBehavior="false" Text="Upload file/s"  />
                           
                      </div>
               <hr />
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">	
    <asp:button cssclass="btn btn-success" id="Next_01" runat="server" text="Next"/>
</span>	 		   

		   </div>
  </div></div></center>
          </div>

    <script type="text/javascript">
        function openModal() {
            $('#NewBusReq').modal('show');
        }
</script>

        <!-- Modal New Business Requirements Form -->
      <div id="NewBusReq" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">New Business Application Prerequisite</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
            <div class="card mb-5 mb-lg-0">
              <div class="card-body">  
                <h6 class="card-price text-center">“Before proceeding, please prepare soft-copy of the following documents on your device."</h6>
                <hr>
              <%--  <ul class="fa-ul">--%>
                <%--  <li><span class="fa-li"><i class="fa fa-check"></i></span>Image Copy Barangay Business Clearance</li>--%>
                 <%-- <li><span class="fa-li"><i class="fa fa-check"></i></span>DTI Registration (Single Proprietor)</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>SEC Registration (Corporation)</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Lessor’s Permit (If Renting)</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Tax Declaration of Property (If Owned)</li>
                  <li><span class="fa-li"><i class="fa fa-check"></i></span>Public Liability Insurance SPA for Authorized Representatives with I.D.</li>--%>
              <%--  </ul>--%>
                   <img src="../CSS_JS_IMG/img/NewBPMinReq.PNG" width="100%" />

                <div style="display:none;">
                  <strong> You may also refer to the link below. </strong> <br />
                  <asp:HyperLink id="hyperlink1" 
                  NavigateUrl="#"
                  Text="Business Permit Application Requirements"
                  Target="_blank"
                  runat="server" />
                </div>

              </div>
            </div>
          </div>
                  <%--<div class="text-center">

                  <a href="../VS2014.BPLTIMS/UploadDocs.aspx" id="Proceed_02" class="button"" >Proceed</a>
                </div>--%>
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->



    <script>
        function FileUpClicked(ID) {
            var x = document.getElementById(ID).value;

            if (x.length == 0) {
                document.getElementById(ID).style.content = "Testing";
                document.getElementById(ID).style.color = "transparent";
            }
            else {
                document.getElementById(ID).style.color = "black";
            }


        }
        //   window.pressed = function () {           
        //       var Owner = document.getElementById('<%=_oFileUploadOwnerPic.ClientID%>');
        //       var Esta = document.getElementById('<%=_oFileUploadEstablishment.ClientID%>');
        //       var Maploc = document.getElementById('<%=_oFileUploadMapLoc.ClientID%>');
        //       alert(owner);
        //    //   if (Owner.value == "") {
        //   ///        Owner.innerHTML = "";
        //   //    }
        //     
        //   };
    </script>


 
    </asp:Content>