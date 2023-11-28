<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="UserAccountManagementRegister.aspx.vb" Inherits="SPIDC.UserAccountManagementRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <div class=" p-1">
        <center>
        <h5 class="m-1 font-weight-bold text-primary">Register Account</h5>
                </center>
    </div>
    <style>
        input[type=text]:enabled {
            background: #ffffff;
        }

        input[type=text]:disabled, select:disabled, input[type=date]:disabled, input[type=number]:disabled, textarea:disabled {
            background: #ffffff;
        }

        select[disabled] {
            background-color: blue;
        }
    </style>

    <script>

        //SNACKBAR - Welcome       
        function SnackbarGreen() {
            var x = document.getElementById("snackbargreen");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 5000);
        };

        function Snackbar() {
            var x = document.getElementById("snackbar");
            x.className = "show";
            setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
        };



    </script>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <input type="hidden" runat="server" id="_err"/>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>
    <div class="row justify-content-center align-items-center form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
            <center>
            <div class="card shadow col-lg-8">
                <form id="frm0">
                </form>

                 <form name="frmSubmit" method="post" onsubmit="document.getElementById('hdnSubmit').value ='TRUE' ">
                       <br />
                <div class=" m-2">
                    <div class="form-row col-md-12 m-0 row ">
                        
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-12">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Email Address &nbsp</span></span>
                                    </label>
                                 <input type="text"  id="txtEmail" name="txtEmail" class="form-control CH-Size" required/>
                                </div>
                            </div>                            
                            
                        </div>
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-md-6">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Department &nbsp</span></span>
                                    </label>
                                  <select name="cmbDepartment" required id="cmbDepartment" runat="server" onchange="getElementById('txtDesc').value=this.value; ShowPasskey(this.value)" class="form-control CH-Size">
                                                                           
                                  </select>                                  
                                  


                                </div> 
                            </div>

                             <div class="form-group col-md-6">
                              <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp UserType &nbsp</span></span>
                                    </label>
                                 <input type="text"  id="txtDesc" name="txtDesc"  value="BPLO" class="form-control CH-Size" readonly/>
                             </div>
                                 </div>
                                </div>                                                             
                        </div>  
                    </div>
                      <input type="hidden"  id="hdnSubmit" name="hdnSubmit"  value="FALSE"/>
                            
                    <div class="col-12" style="color: #7e7e7e">

                        <div class="m-2 col-12 d-flex justify-content-center align-content-center">
                            <button type="submit" class="btn btn-success btn-sm" id="btnSave" formaction="UserAccountManagementRegister.aspx">Save &nbsp  <i class="fa fa-save icon"></i>&nbsp</button>
                            &nbsp &nbsp &nbsp
                                <a href="UserAccountManagement.aspx" class="btn btn-danger btn-sm" id="_obtn_Cancel">Cancel <i class="fa fa-remove icon"></i></a>
                        </div>
                    </div>
               

                </form>
                 
                </div>
          
             </center>
        </div>
    </div>

    <script>
        function do_save() {
            __doPostBack('Save', 'Save');
        }        
      
    </script>
</asp:Content>
