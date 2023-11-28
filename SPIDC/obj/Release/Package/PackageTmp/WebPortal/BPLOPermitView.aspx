<%@ Page EnableEventValidation ="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind ="BPLOPermitView.aspx.vb" Inherits="SPIDC.BPLOPermitView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <script>
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };
    </script>   
      <!-- Modal  Form -->
      <div id="ModalEmailNotif" class="modal fade">
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Notify Taxpayer</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
           
         
           
                    <div class="form-group col">
                        <div>

                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Email Subject </span></span>

                            </label>
                            <input  type="text" runat="server" id="txtSubject" class="form-control CH-Size-New" value="Business Permit Issuance"  />
                          </div>
                    </div>
                   <div class="form-group col">
                        <div>

                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Email Content </span></span>

                            </label>
                            <textarea runat="server" id="txtContent" rows="5" class="form-control CH-Size-New" placeholder="">
Dear Valued Taxpayer,
We've attached the copy of your Business Permit and Official Receipt to this email.
                            </textarea>
                         </div>
                    </div>

                   <div class="form-group col">
                        <div>

                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Upload O.R</span></span>

                            </label>
                        
                            <input type="file" runat="server" class="form-control CH-Size-New" id="OR_upload"/>
                         </div>
                    </div>
                  
<div class="alert info">
  <strong>Included:</strong> Business Permit
</div>
                                  
                   <input type="button" style="width:100%"  class="btn btn-primary btn-sm col" runat="server" id="btn_Send" value="Send" />
             
          
          </div>              
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                    <div id="snackbar" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbar"/>           
                </div>
                <div id="snackbargreen" style="position:absolute">
                    <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row col-lg-12">              
            <div class="card shadow">
                <div class="card-header">
                    <label class=" font-weight-bold text-primary text-uppercase mb-1">Business Permit View</label>
                    <input type="button" style="float:right" value="Send & Notify Taxpayer" onclick="$('#ModalEmailNotif').modal('show');"/>
                </div>
                <div class="card-body">                                    
                   <img runat="server" src="#" id="myimage" name="myimage" alt="" >
                   
                      </div>              
             
            </div>
   
       </div>

   <input type="hidden" id="hdn_Clearances"  runat="server"/>
</asp:Content>