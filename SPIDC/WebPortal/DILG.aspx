<%@ Page Title="" Language="vb" EnableEventValidation="false"  AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="DILG.aspx.vb" Inherits="SPIDC.DILG" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
   <meta name="viewport" content="width=device-width, initial-scale=1">



      <div class=" p-2"><h5 class="m-2 font-weight-bold text-primary">Request for Inspection</h5></div>
    <div class="row justify-content-center align-items-center h-75 card form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left:0;padding-right:0;">
            <div class=" mb-0 m-2" style="background-color: white">
                <div class=" row">             

                    <div class="form-row col-md-6 m-0 row ">
                         <form name="frmSubmit" action="DILG.aspx" method="post" >
                        <div class="col-lg-12 m-2 mb-3">

                            <h6 class="m-0 font-weight-bold text-primary">Select Your Business_BIN:</h6>
                                  <select name="cmbBIN" required id="cmbBIN" runat="server" onchange="do_select()"  class="form-control">
                                  </select>
                            <br />                                       
                                          
                            <input type="hidden" name="hdnBIN" id="hdnBIN"/>

                       <center>                                               
                        <input type="Submit" id="btnSubmit" name="btnSubmit" value="Submit" class="btn btn-primary col-md-2 col-lg-4 m-2 btn-sm"/>
                       </center>
                   
                 </div>                               
                            
                        </form>

                        </div>

                    
                    </div>
                </div>
            </div>
        </div>    

     <div class="modal fade" id="ModalDILG">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header bg-primary">
                                <a class="text-white float-right" style="font-size: 20px;">Request Status</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                                <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body" align="center" runat="server" id="div_Modal">
                             
                            </div>
                            <div class="modal-footer">
                                </div>
                        </div>
                    </div>
                </div>

      <div class="modal fade" id="ModalChecklist">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header bg-primary">
                                <a class="text-white float-right" style="font-size: 20px;">Safety Seal Checklist</a>&nbsp;&nbsp;&nbsp;
                    <h4 class="modal-title text-white"></h4>
                                <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                            </div>
                            <div class="modal-body" align="center" runat="server" id="div1">
                                 <asp:Literal ID="ltEmbed" runat="server" />   
                            </div>
                            <div class="modal-footer" style="text-align:center">
                            
                                   <button type="button" class="btn btn-primary" data-dismiss="modal">I Understand</button>
                             
                                    </div>
                        </div>
                    </div>
                </div>


    <script>
        function do_submit() {
            var val = document.getElementById('<%=cmbBIN.ClientID%>').value; 
            document.getElementById('hdnBIN').value = val;
        }

        function openModal() {
            $('#ModalDILG').modal('show');
        }

        function openModalChecklist() {
            $('#ModalChecklist').modal('show');
        }


    </script>
   
</asp:Content>