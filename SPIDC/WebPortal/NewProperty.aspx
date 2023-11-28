<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="NewProperty.aspx.vb" Inherits="SPIDC.NewProperty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <%--<asp:ScriptManager></asp:ScriptManager>--%>
    
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>
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
    <div class="m-2">
                        
        <div class="row mt-3 mx-auto col-lg-10">
            <%--<div class="form-group col-md-4">
                <div>

                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Tax Declaration No. </span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtTaxDecNo">
                </div>
            </div>

            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Property Identification No.</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPropertyIdentificationNumber">
                </div>

            </div>--%>
            <%--<div class="form-group col-md-2">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">CCN</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCCN">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>--%>
        </div>
        <div class="row mx-auto col-lg-10">
            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Owner Name <span style="color: red;">*</span></span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new required" autocomplete="off" runat="server" id="_oTxtOwner" name="_oTxtOwner" required>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Owner Address</span></span>
                    </label>
                    <textarea class="form-control CH-Size-new" runat="server" id="_oTxtOwnerAddress"></textarea>
                </div>

            </div>
        </div>        

        <div class="row mx-auto col-lg-10">

            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Administrator/Beneficial User <span style="color: red;">*</span></span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new required" autocomplete="off" runat="server" id="_oTxtAdministrator" required>
                </div>

            </div>
            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Administrator Address</span></span>
                    </label>
                    <textarea class="form-control CH-Size-new" runat="server" id="_oTxtAdminAddress"></textarea>
                </div>

            </div>            
        </div>        
        <div class="row mx-auto col-lg-10">
            <div class="form-group col-md-4 font-weight-bold">Property Location</div>
        </div>
        <div class="row mx-auto col-lg-10">

            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Number and Street</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNoSt">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>

            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Barangay</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBarangay">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div><div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">District</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtDistrict">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
            <div class="form-group col-md-3 ">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Municipality/City <span style="color: red;">*</span></span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtCityMunicipality">
                    
                </div>
            </div>                                        
            <div class="form-group col-md-3 ">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Province <span style="color: red;">*</span></span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtProvince">                    
                </div>
            </div>
            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">OCT/TCT No./CLOA TCT <span style="color: red;">*</span></span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new required" autocomplete="off" runat="server" id="_oTxtOCT_TCT" required>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>

            

            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Survey No. <span style="color: red;">*</span></span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new required" autocomplete="off" runat="server" id="_oTxtSurveyNo" required>
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Lot No.</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_TxtLotNo">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Block No.</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtBlockNo">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
        </div>
        <%--<div class="row mx-auto col-lg-10">

            

        </div>--%>
        
        <div class="row mx-auto col-lg-10">
            <div class="form-group col-md-4 font-weight-bold">Property Boundary</div>
        </div>
        <%--<div class="row mx-auto col-lg-10">--%>

            <%--<div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">North</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtNorth">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>--%>

            <%--<div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">South</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtSouth">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>--%>
        <%--</div>--%>
        <%--<div class="row mx-auto col-lg-10">

            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">East</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtEast">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>

            <div class="form-group col-md-6">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">West</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtWest">
                </div>

                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
        </div>  --%>              
        <%--<div class="my-2 col-lg-11">
            <button name="_obtnPrint" runat="server" id="_obtnPrint" type="submit" class="btn btn-primary m-2 col-md-5 btn-sm mr-3" style="position: absolute; bottom: 0; right: 0; width: 100px">Print </button>

        </div>--%>
        <div class="row mt-3 mx-auto col-lg-10">
            <div class="form-group col-md-3">
                <div>

                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Area </span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new required" autocomplete="off" runat="server" id="_oTxtArea" onkeypress="return onlyNumbers(this);" onblur="formatArea(this.value)" placeholder="0 m²" required>
                </div>
            </div>

            <div class="form-group col-md-3">
                <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Amount Sold</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new" autocomplete="off" onkeypress="return onlyNumbers(this);" onblur="formatAmountSold(this.value)" runat="server" id="_oTxtAmountSold">
                </div>

            </div>
            <div class="form-group col-md-6">


                <!--input  type="text" name="txtBirthDate" class="form-control CH-Size-new" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
        </div>
        <div class="row mx-auto col-lg-10">
            <div class="form-group col-md-4 font-weight-bold">Actual Usage</div>
        </div>
        
        <div class="row mt-1 mx-auto col-lg-10">
            <div class="col-lg-4 row">
                <div class="form-group col-md-6">
                    <label class="ml-3">Agricultural</label>
                </div>
                <div class="form-group col-md-6">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Area</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-new totarea" autocomplete="off" runat="server" id="_oTxtAgricultural" onkeypress="return onlyNumbers(this);" onblur="formatCurrency(this.value,this.id);" onkeyup="ComputeArea();" placeholder="0 m²">
                    </div>
                </div>
            </div>
            <div class="col-lg-4 row">
                <div class="form-group col-md-6">           
                    <label class="ml-3">Residential</label>       
                </div>
                <div class="form-group col-md-6">  
                    <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Area</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new totarea" autocomplete="off" runat="server" id="_oTxtResidentialArea" onkeypress="return onlyNumbers(this);" onblur="formatCurrency(this.value,this.id);" onkeyup="ComputeArea();" placeholder="0 m²">
                </div>                  
                </div>
            </div>
            <div class="col-lg-4 row">
                <div class="form-group col-md-6">
                    <label class="ml-3">Commercial</label>
                </div>
                <div class="form-group col-md-6">
                    <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Area</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new totarea" autocomplete="off" runat="server" id="_oTxtCommercialArea" onkeypress="return onlyNumbers(this);" onblur="formatCurrency(this.value,this.id);" onkeyup="ComputeArea();" placeholder="0 m²">
                </div>
                </div>
            </div>
            <div class="col-lg-4 row">
                <div class="form-group col-md-6">
                    <label class="ml-3">Mineral</label>
                </div>
                <div class="form-group col-md-6">
                    <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Area</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new totarea" autocomplete="off" runat="server" id="_oTxtMineral" onkeypress="return onlyNumbers(this);" onblur="formatCurrency(this.value,this.id);" onkeyup="ComputeArea();" placeholder="0 m²"  >
                </div>
                </div>
            </div>
            <div class="col-lg-4 row">
                <div class="form-group col-md-6">
                    <label class="ml-3">Special</label>
                </div>
                <div class="form-group col-md-6">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Area</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-new totarea" autocomplete="off" runat="server" id="_oTxtSpecial" onkeypress="return onlyNumbers(this);" onblur="formatCurrency(this.value,this.id);" onkeyup="ComputeArea();" placeholder="0 m²"  >
                    </div>
                </div>
            </div>
            <div class="col-lg-4 row">
                <div class="form-group col-md-6">
                    <label class="ml-3">Timberland</label>
                </div>
                <div class="form-group col-md-6">
                    <div>
                    <label class="input-txt input-txt-active2">
                        <span><span class="m-2">Area</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size-new totarea" autocomplete="off" runat="server" id="_oTxtTimberland" onkeypress="return onlyNumbers(this);" onblur="formatCurrency(this.value,this.id);" onkeyup="ComputeArea();" placeholder="0 m²" >
                </div>
                </div>
            </div>  
            <div class="col-lg-4 row">
                <div class="form-group col-md-6">
                    <label class="ml-3">Industiral</label>
                </div>
                <div class="form-group col-md-6">
                    <div>
                        <label class="input-txt input-txt-active2">
                            <span><span class="m-2">Area</span></span>
                        </label>
                        <input type="text" class="form-control CH-Size-new totarea" autocomplete="off" runat="server" id="_oTxtIndustrial" onkeypress="return onlyNumbers(this);" onblur="formatCurrency(this.value,this.id);" onkeyup="ComputeArea();" placeholder="0 m²">
                    </div>
                </div>                
            </div>
            <div class="col-lg-4 row">
                    <div class="form-group col-md-6">
                        <label class="ml-3 font-weight-bold font-weight-bolder">Total Area</label>
                    </div>
                    <div class="form-group col-md-6">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <%--<span><span class="m-2">Area</span></span>--%>
                            </label>
                            <input type="text" class="form-control CH-Size-new font-weight-bold font-weight-bolder" autocomplete="off" runat="server" id="_oTxtTotalArea" placeholder="0 m²" disabled>
                        </div>
                    </div>
            </div>
        <div class="row mx-auto col-lg-10">
            
            <div class="col-md-12 d-flex align-content-center justify-content-center">                
                <button ID="_oBtnContinue" runat="server" class="btn btn-primary btn-icon-split" onclick="window.history.go(-1); return false;" type="button">
                    <span class="icon text-white-50">
                      <i class="fas fa-arrow-alt-circle-left mt-1"></i>
                    </span> 
                    <span class="text">Back</span>                       
                </button>
                &nbsp
                &nbsp                
                <button class="btn btn-success btn-icon-split" id="_oBtnSave" type="button" onclick="ChekingFields();">
                    <span class="text">Save</span>
                    <span class="icon text-white-50">
                      <i class="fas fa-save mt-1"></i>
                    </span>                    
                </button> 
                <%--<input name="btnPayNow" id="_oBtnSave" type="button" onclick="ChekingFields();" class="btn btn-success"  value="Save">--%>
            </div>
        </div> 

    </div>
    <a class="scroll-to-top rounded" href="#page-top" style="display: none;" id="_totop">
            <i class="fas fa-angle-up"></i>
        </a>
    <script>
        function ChekingFields() {
            var savetrigger = false;
            var tObj = document.getElementsByClassName('required');
            for (var i = 0; i < tObj.length; i++) {
                if (tObj[i].value.length == 0) {
                    savetrigger = true;
                    break;
                }
            }
            if (savetrigger) {
                document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Please complete the following fields!"; Snackbar();
                document.getElementById('_totop').click();
            }
            else {
                if (document.getElementById('<%=_oTxtArea.ClientID%>').value == document.getElementById('<%=_oTxtTotalArea.ClientID%>').value) {
                    SaveInfo('Save', 'NewProperty');
                    document.getElementById('<%=_oLabelSnackbargreen.ClientID%>').innerHTML = "Record Saved!";
                    SnackbarGreen();
                    document.getElementById('_totop').click();
                }
                else {
                    document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Property Boundary Area field must <br/> equal to Total Area Field!";
                    Snackbar();
                    document.getElementById('_totop').click();
                }

            }
            //SaveInfo('Save', 'NewProperty');
        }


        function SaveInfo(Action, Val) {
            __doPostBack(Action, Val);
        }

        function ComputeTotalArea() {
            var com
            var res
            var val
            if (document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value == "") {
                document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = 0 + parseFloat(document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value);
            }

            if (document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value == "") {
                document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = parseFloat(document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value) + 0;
            }

            if (document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value == "" && document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value == "") {
                document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = "0.00";
            }

            if (document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value !== "" && document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value !== "") {
                res = document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value.replace(/,/g, '');
                com = document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value.replace(/,/g, '');
                document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = parseFloat(res) + parseFloat(com);
            }
            val = document.getElementById('<%=_oTxtTotalArea.ClientID%>').value.replace(/,/g, '');
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(val);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');

            document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = x;
        };

        function formatTotalArea(val) {
            val = document.getElementById('<%=_oTxtTotalArea.ClientID%>').value.replace(/,/g, '');
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(val);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');

            document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = x;
        }

        function formatAmountSold(val) {
            val = document.getElementById('<%=_oTxtAmountSold.ClientID%>').value.replace(/,/g, '');
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(val);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');

            document.getElementById('<%=_oTxtAmountSold.ClientID%>').value = x;
        }

        function formatArea(val) {
            val = document.getElementById('<%=_oTxtArea.ClientID%>').value.replace(/,/g, '');
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(val);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');
            document.getElementById('<%=_oTxtArea.ClientID%>').value = x;
        }

        function formatResidential(val) {
            val = document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value.replace(/,/g, '');
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(val);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');

            document.getElementById('<%=_oTxtResidentialArea.ClientID%>').value = x;
        }

        function formatCommercial(val) {
            val = document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value.replace(/,/g, '');
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(val);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');

            document.getElementById('<%=_oTxtCommercialArea.ClientID%>').value = x;
        }

        function formatCurrency(val, id) {
            val = document.getElementById(id).value.replace(/,/g, '');
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(val);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');

            document.getElementById(id).value = x;
        }


        function ComputeArea() {
            var tot = 0;
            var tObj = document.getElementsByClassName('totarea');
            for (var i = 0; i < tObj.length; i++) {
                tot += Number(tObj[i].value.replace(/[^0-9.-]+/g, ""));
            }
            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'PHP',
            });

            var x = formatter.format(tot);
            x = x.split('PHP').join('');
            x = x.replace(/\s/g, '');

            document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = x;
        }


        function findTotal() {
            var arr = document.getElementsByName('totarea');
            var tot = 0;
            for (var i = 0; i < arr.length; i++) {
                alert(i);
                if (parseInt(arr[i].value))
                    alert(i);
                tot += parseInt(arr[i].value);

            }
            document.getElementById('<%=_oTxtTotalArea.ClientID%>').value = tot;
        }
        function onlyNumbers(evt) {

            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if (charCode == 46)
                return true;

            if (charCode < 48 || charCode > 57)
                return false;

            return true;

        }
     </script>
        </div>
</asp:Content >
