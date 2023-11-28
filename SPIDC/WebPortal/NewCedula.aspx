<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="NewCedula.aspx.vb" Inherits="SPIDC.NewCedula" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">       


    <%--<div class="p-2">
       <h5 class="m-2 font-weight-bold text-primary">Cedula</h5>
    </div>--%>
    
    <script type="text/javascript">
        document.body.onload = function () { sessionStorage.setItem("Active", "Cedula"); GetActive(); }
    </script>
                    	                    
<div class="" style="width:100%; z-index:-1;margin-top:10px">
  <ul class="list-unstyled multi-steps">
    <li class="is-active">Cedula</li>   
    <li class="is-active">Payment</li>
    <li class="is-active" >Complete</li>      
  </ul>
</div>
   
   <div class="m-1">
       
       <ul class="nav nav-tabs mt-2" id="myTab" role="tablist">
  <li class="nav-item">
    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home"
      aria-selected="true" onclick="IndividualClick()">Cedula (Individual)</a>
      <input type="hidden" runat="server" id="_oTxtHdnCedulaInd" />
  </li>
  <li class="nav-item">
    <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile"
      aria-selected="false" onclick="CorporationClick(); calculateAmountCorp(); formatCTCDue(_TxtCtcDue.value); formatTotAmountCorp(_oTxtTotAmountCorp.value);">Cedula (Corporation)</a>
      <input type="hidden" runat="server" id="_oTxtHdnCedulaCorp" />
  </li>
  <%--<li class="nav-item">
    <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact"
      aria-selected="false">Contact</a>
  </li>--%>
</ul>     
<div class="tab-content" id="myTabContent">
  <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
      <div class="mx-1 d-flex justify-content-center mt-3">       
            <div class="row col-lg-12 d-flex justify-content-center">
                <div class="col-lg-12 mt-2">

                <%--<h6 class="m-0 font-weight-bold text-primary mb-3">Cedula (Individual)</h6>--%>

            </div>
                 
                    <div class="col-md-6 mt-2 row">
                                              
                    <div class="form-group col-lg-8 mb-4">
                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 ch-size-new"  />
               &nbsp  I am getting this cedula for myself. 
                        
                    </div>

                        <div class="col-lg-4 mb-4" style="display:none">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">For Year </span></span>
                            </label>
                        <select runat="server"  id="_oDpForYear" name="For Year" class="form-control ch-size-new">
                                <option value="2021" selected>2021</option>
                                <option value="2020">2020</option>
                                <option value="2019">2019</option>
                                <option value="2018">2018</option>
                                <option value="2017">2017</option>
                                <option value="2016">2016</option>
                            </select>
                           </div> 


                    <div class="form-group col-lg-12 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">First Name </span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" onkeypress="return onlyLetters();" name="FirstName" id="_oTxtFirstName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Middle Name</span></span>
                            </label>
                            <input type="text" runat="server" class="form-control ch-size-new" name="MiddleName" onkeypress="return onlyLetters();" id="_oTxtMiddleName"  pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Middle Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Last Name</span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" name="LastName" onkeypress="return onlyLetters();" id="_oTxtLastName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Address</span></span>
                            </label>
                            <textarea class="form-control ch-size-new"  required runat="server" id="_oTxtAddress" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); "></textarea>
                        </div>
                    </div>
                    <div class="form-group col-lg-6 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Citizenship</span></span>
                            </label>
                            <select required runat="server" id="radCitizenship" name="radCitizenship" class="form-control ch-size-new">
                                <option value="Filipino" selected>Filipino</option>
                                <option value="afghan">Afghan</option>
                                <option value="albanian">Albanian</option>
                                <option value="algerian">Algerian</option>
                                <option value="american">American</option>
                                <option value="andorran">Andorran</option>
                                <option value="angolan">Angolan</option>
                                <option value="antiguans">Antiguans</option>
                                <option value="argentinean">Argentinean</option>
                                <option value="armenian">Armenian</option>
                                <option value="australian">Australian</option>
                                <option value="austrian">Austrian</option>
                                <option value="azerbaijani">Azerbaijani</option>
                                <option value="bahamian">Bahamian</option>
                                <option value="bahraini">Bahraini</option>
                                <option value="bangladeshi">Bangladeshi</option>
                                <option value="barbadian">Barbadian</option>
                                <option value="barbudans">Barbudans</option>
                                <option value="batswana">Batswana</option>
                                <option value="belarusian">Belarusian</option>
                                <option value="belgian">Belgian</option>
                                <option value="belizean">Belizean</option>
                                <option value="beninese">Beninese</option>
                                <option value="bhutanese">Bhutanese</option>
                                <option value="bolivian">Bolivian</option>
                                <option value="bosnian">Bosnian</option>
                                <option value="brazilian">Brazilian</option>
                                <option value="british">British</option>
                                <option value="bruneian">Bruneian</option>
                                <option value="bulgarian">Bulgarian</option>
                                <option value="burkinabe">Burkinabe</option>
                                <option value="burmese">Burmese</option>
                                <option value="burundian">Burundian</option>
                                <option value="cambodian">Cambodian</option>
                                <option value="cameroonian">Cameroonian</option>
                                <option value="canadian">Canadian</option>
                                <option value="cape verdean">Cape Verdean</option>
                                <option value="central african">Central African</option>
                                <option value="chadian">Chadian</option>
                                <option value="chilean">Chilean</option>
                                <option value="chinese">Chinese</option>
                                <option value="colombian">Colombian</option>
                                <option value="comoran">Comoran</option>
                                <option value="congolese">Congolese</option>
                                <option value="costa rican">Costa Rican</option>
                                <option value="croatian">Croatian</option>
                                <option value="cuban">Cuban</option>
                                <option value="cypriot">Cypriot</option>
                                <option value="czech">Czech</option>
                                <option value="danish">Danish</option>
                                <option value="djibouti">Djibouti</option>
                                <option value="dominican">Dominican</option>
                                <option value="dutch">Dutch</option>
                                <option value="east timorese">East Timorese</option>
                                <option value="ecuadorean">Ecuadorean</option>
                                <option value="egyptian">Egyptian</option>
                                <option value="emirian">Emirian</option>
                                <option value="equatorial guinean">Equatorial Guinean</option>
                                <option value="eritrean">Eritrean</option>
                                <option value="estonian">Estonian</option>
                                <option value="ethiopian">Ethiopian</option>
                                <option value="fijian">Fijian</option>
                                <option value="finnish">Finnish</option>
                                <option value="french">French</option>
                                <option value="gabonese">Gabonese</option>
                                <option value="gambian">Gambian</option>
                                <option value="georgian">Georgian</option>
                                <option value="german">German</option>
                                <option value="ghanaian">Ghanaian</option>
                                <option value="greek">Greek</option>
                                <option value="grenadian">Grenadian</option>
                                <option value="guatemalan">Guatemalan</option>
                                <option value="guinea-bissauan">Guinea-Bissauan</option>
                                <option value="guinean">Guinean</option>
                                <option value="guyanese">Guyanese</option>
                                <option value="haitian">Haitian</option>
                                <option value="herzegovinian">Herzegovinian</option>
                                <option value="honduran">Honduran</option>
                                <option value="hungarian">Hungarian</option>
                                <option value="icelander">Icelander</option>
                                <option value="indian">Indian</option>
                                <option value="indonesian">Indonesian</option>
                                <option value="iranian">Iranian</option>
                                <option value="iraqi">Iraqi</option>
                                <option value="irish">Irish</option>
                                <option value="israeli">Israeli</option>
                                <option value="italian">Italian</option>
                                <option value="ivorian">Ivorian</option>
                                <option value="jamaican">Jamaican</option>
                                <option value="japanese">Japanese</option>
                                <option value="jordanian">Jordanian</option>
                                <option value="kazakhstani">Kazakhstani</option>
                                <option value="kenyan">Kenyan</option>
                                <option value="kittian and nevisian">Kittian and Nevisian</option>
                                <option value="kuwaiti">Kuwaiti</option>
                                <option value="kyrgyz">Kyrgyz</option>
                                <option value="laotian">Laotian</option>
                                <option value="latvian">Latvian</option>
                                <option value="lebanese">Lebanese</option>
                                <option value="liberian">Liberian</option>
                                <option value="libyan">Libyan</option>
                                <option value="liechtensteiner">Liechtensteiner</option>
                                <option value="lithuanian">Lithuanian</option>
                                <option value="luxembourger">Luxembourger</option>
                                <option value="macedonian">Macedonian</option>
                                <option value="malagasy">Malagasy</option>
                                <option value="malawian">Malawian</option>
                                <option value="malaysian">Malaysian</option>
                                <option value="maldivan">Maldivan</option>
                                <option value="malian">Malian</option>
                                <option value="maltese">Maltese</option>
                                <option value="marshallese">Marshallese</option>
                                <option value="mauritanian">Mauritanian</option>
                                <option value="mauritian">Mauritian</option>
                                <option value="mexican">Mexican</option>
                                <option value="micronesian">Micronesian</option>
                                <option value="moldovan">Moldovan</option>
                                <option value="monacan">Monacan</option>
                                <option value="mongolian">Mongolian</option>
                                <option value="moroccan">Moroccan</option>
                                <option value="mosotho">Mosotho</option>
                                <option value="motswana">Motswana</option>
                                <option value="mozambican">Mozambican</option>
                                <option value="namibian">Namibian</option>
                                <option value="nauruan">Nauruan</option>
                                <option value="nepalese">Nepalese</option>
                                <option value="new zealander">New Zealander</option>
                                <option value="ni-vanuatu">Ni-Vanuatu</option>
                                <option value="nicaraguan">Nicaraguan</option>
                                <option value="nigerien">Nigerien</option>
                                <option value="north korean">North Korean</option>
                                <option value="northern irish">Northern Irish</option>
                                <option value="norwegian">Norwegian</option>
                                <option value="omani">Omani</option>
                                <option value="pakistani">Pakistani</option>
                                <option value="palauan">Palauan</option>
                                <option value="panamanian">Panamanian</option>
                                <option value="papua new guinean">Papua New Guinean</option>
                                <option value="paraguayan">Paraguayan</option>
                                <option value="peruvian">Peruvian</option>
                                <option value="polish">Polish</option>
                                <option value="portuguese">Portuguese</option>
                                <option value="qatari">Qatari</option>
                                <option value="romanian">Romanian</option>
                                <option value="russian">Russian</option>
                                <option value="rwandan">Rwandan</option>
                                <option value="saint lucian">Saint Lucian</option>
                                <option value="salvadoran">Salvadoran</option>
                                <option value="samoan">Samoan</option>
                                <option value="san marinese">San Marinese</option>
                                <option value="sao tomean">Sao Tomean</option>
                                <option value="saudi">Saudi</option>
                                <option value="scottish">Scottish</option>
                                <option value="senegalese">Senegalese</option>
                                <option value="serbian">Serbian</option>
                                <option value="seychellois">Seychellois</option>
                                <option value="sierra leonean">Sierra Leonean</option>
                                <option value="singaporean">Singaporean</option>
                                <option value="slovakian">Slovakian</option>
                                <option value="slovenian">Slovenian</option>
                                <option value="solomon islander">Solomon Islander</option>
                                <option value="somali">Somali</option>
                                <option value="south african">South African</option>
                                <option value="south korean">South Korean</option>
                                <option value="spanish">Spanish</option>
                                <option value="sri lankan">Sri Lankan</option>
                                <option value="sudanese">Sudanese</option>
                                <option value="surinamer">Surinamer</option>
                                <option value="swazi">Swazi</option>
                                <option value="swedish">Swedish</option>
                                <option value="swiss">Swiss</option>
                                <option value="syrian">Syrian</option>
                                <option value="taiwanese">Taiwanese</option>
                                <option value="tajik">Tajik</option>
                                <option value="tanzanian">Tanzanian</option>
                                <option value="thai">Thai</option>
                                <option value="togolese">Togolese</option>
                                <option value="tongan">Tongan</option>
                                <option value="trinidadian or tobagonian">Trinidadian or Tobagonian</option>
                                <option value="tunisian">Tunisian</option>
                                <option value="turkish">Turkish</option>
                                <option value="tuvaluan">Tuvaluan</option>
                                <option value="ugandan">Ugandan</option>
                                <option value="ukrainian">Ukrainian</option>
                                <option value="uruguayan">Uruguayan</option>
                                <option value="uzbekistani">Uzbekistani</option>
                                <option value="venezuelan">Venezuelan</option>
                                <option value="vietnamese">Vietnamese</option>
                                <option value="welsh">Welsh</option>
                                <option value="yemenite">Yemenite</option>
                                <option value="zambian">Zambian</option>
                                <option value="zimbabwean">Zimbabwean</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group col-lg-6 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Birthday</span></span>
                            </label>
                            <input type="text" class="form-control ch-size-new" required autocomplete="off" onfocus="(this.type='date')" runat="server" id="_oTxtBirthDate" min="1900-01-01" onblur="ComputeAge(this)">
                            <input type="hidden" runat="server" id ="_oTxtHdnBirthDate" />
                        </div>
                    </div>
                    <div class="form-group col-lg-12 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Birth Place</span></span>
                            </label>
                            <input type="text" class="form-control ch-size-new" required onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " autocomplete="off" runat="server" id="_oTxtBirthPlace">
                        </div>
                    </div>
                    <div class="form-group col-lg-6 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Gender</span></span>
                            </label>
                            <select required runat="server" id="radGender" name="radGender" class="form-control ch-size-new">
                                <option value="M" selected>Male</option>
                                <option value="F">Female</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group col-lg-6 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Civil Status</span></span>
                            </label>
                            <select required runat="server" id="radCivilstat" class="form-control ch-size-new">
                                <option value="Single" selected>Single</option>
                                <option value="Married">Married</option>
                                <option value="Widowed">Widowed</option>
                                <option value="Divorced">Divorced</option>
                                <option value="Separated">Separated</option>
                            </select>

                        </div>
                    </div>
                        <div class="form-group col-lg-6 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Profession</span></span>
                                </label>
                                <input type="text" required class="form-control ch-size-new" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, '');" onkeyup="calculateAmount(); PassToHidden(this); EnableDisableSalary(); LabelHidden();" autocomplete="off" placeholder="Unemployed" runat="server" id="radioProfession">
                                <%--<select required id="radioProfession" class="form-control ch-size-new" onchange="EnableDisable(this); GetBasic(_oChkNewBusiness); calculateAmount(); PassToHidden(this)">
                                    <option value="" selected disabled>Select Profession</option>
                                    <option value="Unemployed">Unemployed</option>
                                    <option value="Dentist">Dentist</option>
                                    <option value="Dietitian or Nutritionist">Dietitian or Nutritionist</option>
                                    <option value="Optometrist">Optometrist</option>
                                    <option value="Pharmacist">Pharmacist</option>
                                    <option value="Physician">Physician</option>
                                </select>--%>

                                <input type="hidden" runat="server" id="radProfession" />

                            </div>
                        </div>
                        <div class="form-group col-lg-4 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Tin No.</span></span>
                                </label>
                                <input type="text"  runat="server" class="form-control ch-size-new" name="TIN" id="_oTxtTIN" onkeypress="return onlyNumbers(this);" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" title="TIN" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                            </div>
                        </div>
                        <div class="form-group col-lg-3 mb-3 mt-2">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Height (m.)</span></span>
                                </label>
                                <input type="text" class="form-control ch-size-new" autocomplete="off" runat="server" id="_oTxtHeight" step ="0.01" onfocus="(this.type='number');if(this.value=='0')this.value='';" onkeyup="this.value = heightminmax(this.value, 0.30, 3.05)" onclick="this.value = heightminmax(this.value, 0.30, 3.05)" onfocusout="return OnTextNumericKeyPress(event);" onBlur="if(this.value=='') this.value='0';return OnTextNumericKeyPress(event);"  onKeyPress="return OnTextNumericKeyPress(event);"  onchange="RoundtoDecimal(this);">
                                <script type="text/javascript">
                                    function heightminmax(value, min, max) {
                                        if (parseFloat(value) < 0.30 || isNaN(value))
                                            return 0.30;
                                        else if (parseFloat(value) > 3.05)
                                            return 3.05;
                                        else return value;
                                    }
                                    function weightminmax(value, min, max) {
                                        if (parseInt(value) < 1 || isNaN(value))
                                            return 1;
                                        else if (parseInt(value) > 300)
                                            return 300;
                                        else return value;
                                    }
                                </script>

                            </div>
                        </div>
                        <div class="form-group col-lg-3 mb-3 mt-2">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Weight (kg.)</span></span>
                                </label>
                                <input type="text" class="form-control ch-size-new" autocomplete="off" min="1" max="300" runat="server" id="_oTxtWeight" onfocus="(this.type='number')" onkeyup="this.value = weightminmax(this.value, 1, 300)">
                            </div>
                        </div>
                </div>
            
                <div class="col-md-6 mt-2 d-flex justify-content-center">
                    <div class="col-lg-12 mt-5">
                    <div class="col-lg-12 row">
                        <label style="color:red" runat="server" id="_oLblKindly">* Kindly declare your gross.</label>
                        <div class="form-group col-lg-12 border border-dark rounded ">
                            <div class="mt-2">
                                <div class="form-group col font-weight-bold">Gross Declaration:</div>
                                <div class="row m-0">
                                    <div class="form-group col-lg-7 ">
                                        Gross Receipts from Business<br>
                                        &nbsp
                        <input type="checkbox" id="_oChkNewBusiness" class="mt-1" value="No Work" onclick="calculateAmount()">
                                        &nbsp New Business
                        <input type="hidden" id="_oTxtHiddenNewBusiness">
                                    </div>
                                    <div class="form-group col-lg-5">
                                        <div>

                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Amount</span></span>
                                            </label>

                                            <input type="text" runat="server" class="form-control ch-size-new my-auto" onkeypress="return onlyNumbers();" autocomplete="off" value="0.00" style="text-align: right" id="_oTxtBusinessIncome"
                                                onkeyup="LabelHidden(); calculateAmount(); changeColor();"
                                                oninput="this.reportValidity(); calculateAmount(); changeColor();"
                                                onblur="SetDefault();formatBusinessIncome(this.value);"
                                                onfocus="ClearBusiness();removeCommaBusinessIncome(this.value);" />
                                             
                                            <input type="hidden" id="_oTxtHiddenBusinessIncome" />
                                        </div>
                                    </div>


                                </div>
                                <div class="row m-0">
                                    <div class="form-group col-lg-7">Gross Income from Salary</div>
                                    <div class="form-group col-lg-5">
                                        <div>

                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Amount</span></span>
                                            </label>
                                            <input type="text" runat="server" class="form-control ch-size-new" onkeypress="return onlyNumbers(this);" title="Salary" autocomplete="off" value="0.00" style="text-align: right" id="_oTxtSalary"
                                                onkeyup="LabelHidden(); calculateAmount(); changeColor();"
                                                onblur="SetDefault(); calculateAmount();formatSalary(this.value); changeColor();"
                                                onfocus="ClearSalary();removeCommaSalary(this.value);">
                                            <input type="hidden" id="_oTxtHiddenSalary">
                                            <%--  <input  type="text" required runat="server" name="RentPerMonth" class="form-control ch-size-new" id="Slide_02_RentPerMonth" oninput="this.reportValidity()" pattern="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" title="Currency" placeholder="0" style="text-align:right" maxlength="25" onblur="formatMoney(this.value);" onfocus="removeComma(this.value);" />
                                            --%>
                                        </div>
                                    </div>


                                </div>
                                <div class="row m-0">
                                    <div class="form-group col-lg-7">Gross Income from Real Prop.</div>
                                    <div class="form-group col-lg-5">
                                        <div>

                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Amount</span></span>
                                            </label>
                                            <input type="text" runat="server" id="_oTxtPropertySale" title="PropertySale" onkeypress="return onlyNumbers(this);" class="form-control ch-size-new" autocomplete="off" value="0.00" style="text-align: right"
                                                onkeyup="LabelHidden(); calculateAmount(); changeColor();"
                                                onblur="SetDefault(); calculateAmount();formatSales(this.value); changeColor();"
                                                onfocus="ClearProperty();removeCommaSales(this.value);">
                                            <input type="hidden" id="_oTxtHiddenPropertySale">
                                        </div>
                                    </div>


                                </div>
                                <div class="row" style="display:none;">
                                    <div class="my-auto mx-2">Should we deliver your Documents (P250.00)? </div>

                                    <div class="align-items-center row m-1">
                                        <input type="checkbox" id="_oRadioPickup" onclick="calculateAmount();" name="CourierServices" class="form-control ch-size my-auto mx-2" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="Pickup">
                                        <div class="m-0 font-weight-bold text-primary my-auto mx-2">Yes</div>
                                        <input type="hidden" runat="server" id="_oTxtHiddenDelivery">
                                        <input type="hidden" runat="server" id="_oTxtHiddenBasicAmount">
                                        <input type="hidden" runat="server" id="_oTxtHiddenTotAmount">
                                    </div>

                                </div>
                                
                                    <div class="row col-lg-12 d-flex justify-content-end">

                                        <div class="form-group font-weight-bold align-content-center col">Amount to Pay </div>
                                 
                                    <input type="text" runat="server" id="AmountToPay" required class="form-control ch-size-new col-lg-7 my-3" autocomplete="off" value="0.00" placeholder="0.00" style="text-align: right; background: none; font-size: x-large; height: 50px" readonly="readonly">
                                    <input type="hidden" runat="server" id="_oTxtHiddenAmountDue">
                                    <input type="hidden" runat="server" id="_oTxtHiddenPenalty">

                                        </div> 


                                <div class=" d-flex justify-content-center">
                
                        <div class="col-md-12 row d-flex justify-content-center">
                            
                        
                        <button name="btnPayLayte" runat="server"  id="_oPayLayter" type="submit" class="btn btn-primary col-md-2 col-lg-4 m-2 btn-sm"> Reset </button>
                        <input name="btnPayNow" id="_oBtnPayNow" type="submit" onclick="PayNow('PayNow', 'PaymentInd');  " class="btn btn-primary col-md-2 col-lg-4 m-2 btn-sm"  value="Proceed to Payment" >
                                                  
                        </div>
                 
                    </div>

                                </div>

                        </div>

                </div>
    </div>
        </div>
    </div>
          
    </div>
  </div>





  <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
       <div class="mx-1 d-flex justify-content-center mt-3">
            <div class="row col-lg-12 d-flex justify-content-center">
                <div class="col-lg-12 mt-2">

                <%--<h6 class="m-0 font-weight-bold text-primary mb-3">Cedula (Individual)</h6>--%>

            </div>
                     
                                                                  
                    <%--<div class="form-group col-lg-12 mb-4">
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 ch-size-new"  />
               &nbsp  I am getting this cedula for myself. 
                        
                    </div>--%>
              
                
                    <div class="col-md-8 mt-2 row">



                    <div class="form-group col-lg-6 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Company Name </span></span>
                            </label>
                            <input type="text" required runat="server" class="form-control ch-size-new" onkeypress="" name="Company Name" id="_oTxtCompanyName" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                        </div>

                    </div>
                    <div class="form-group col-lg-3  ">
                        
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Tin No.</span></span>
                                </label>
                                <input type="text" required runat="server" class="form-control ch-size-new" name="TIN" id="_oTxtCorpTIN" onkeypress="return onlyNumbers(this);" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" title="TIN" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                            </div>
                     
                    </div>      
                        <div class="form-group col-lg-3">
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">For Year </span></span>
                            </label>
                        <select runat="server" id="_oDpForYearCorp" name="For Year" class="form-control ch-size-new">
                                <option value="2020" selected>2020</option>
                                <option value="2019">2019</option>
                                <option value="2018">2018</option>
                                <option value="2017">2017</option>
                                <option value="2016">2016</option>
                            </select>
                           </div>              
                    <div class="form-group col-lg-12 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Address of Principal of Business </span></span>
                            </label>
                            <textarea class="form-control ch-size-new" required runat="server" id="_oTxtAddressPrincipal" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); "></textarea>
                        </div>
                    </div>
                    <div class="form-group col-lg-12">                        
                        Kind of organization: &nbsp<asp:RadioButton ID="_oRadAssociation" runat="server" GroupName="Corp"/>&nbsp<asp:Label runat="server" AssociatedControlID="_oRadAssociation" Text="Association"/>
                        &nbsp
                        &nbsp
                        <asp:RadioButton ID="_oRadCorporation" runat="server" GroupName="Corp"/>&nbsp<asp:Label runat="server" AssociatedControlID="_oRadCorporation" Text="Corporation"/>
                        &nbsp
                        &nbsp
                        <asp:RadioButton ID="_oRadPartnership" runat="server" GroupName="Corp"/>&nbsp<asp:Label runat="server" AssociatedControlID="_oRadPartnership" Text="Partnership"/>
                            <br>
                        
                    </div>                      
                    <div class="form-group col-lg-4 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Place of Incorporation</span></span>
                            </label>
                            <input type="text" class="form-control ch-size-new" required onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " autocomplete="off" runat="server" id="_oTxtPlaceofIncorporation">
                        </div>
                    </div>
                    <div class="form-group col-lg-4 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Date of Incorporation</span></span>
                            </label>
                            <input type="text" class="form-control ch-size-new" required autocomplete="off" onfocus="(this.type='date')"  runat="server" id="_oTxtDateIncorporation" onblur="ComputeAge(this)" min = "1900-01-01">
                        </div>
                    </div>
                    <div class="form-group col-lg-4 ">
                        <div>
                            <label class="input-txt input-txt-active2">
                                <span><span class="m-2">Kind of Business</span></span>
                            </label>
                            <input type="text" class="form-control ch-size-new" required onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " autocomplete="off"  runat="server" id="_oTxtKindBusiness">
                        </div>
                    </div>                                        
                    <div class="col-md-12 d-flex justify-content-center row">
                    
                        
          
                          
                                <label class="font-weight-bold col-lg-12">Gross Declaration:</label>
                                <br>
                                    <label class="form-group col-lg-8">
                                        Assessed Value of Real Property Owned                        
                                    </label>
                                   
                                        <div class="col-lg-4">

                                            <label class="input-txt input-txt-active2">
                                                <%--<span><span class="m-2"></span></span>--%>
                                            </label>

                                            <input type="text" runat="server" class="form-control ch-size-new my-auto " onkeypress="return onlyNumbers();" required autocomplete="off" value="0.00" style="text-align: right" id="_oTxtAssValue"
                                                onkeyup="calculateAmountCorp(); formatCTCDue(_TxtCtcDue.value);"
                                                oninput="this.reportValidity(); calculateAmountCorp(); formatCTCDue(_TxtCtcDue.value); formatTotAmountCorp(_oTxtTotAmountCorp.value);"
                                                onblur="SetDefault();formatBusinessIncome(this.value);"
                                                onfocus="ClearBusiness();removeCommaBusinessIncome(this.value);" />
                                             
                                            <input type="hidden" id="_oTxtHiddenAssValue" />
                                        </div>                                                                                     
                                    <label class="form-group col-lg-8">Gross Receipts from Business</label>
                                    <div class="form-group col-lg-4">
                                        <div>

                                            <label class="input-txt input-txt-active2">
                                                <%--<span><span class="m-2">Amount</span></span>--%>
                                            </label>
                                            <input type="text" runat="server" class="form-control ch-size-new" required onkeypress="return onlyNumbers(this);" title="Salary" autocomplete="off" placeholder="0.00" style="text-align: right" id="_oTxtGrossReceipt"
                                                onkeyup="calculateAmountCorp(); formatCTCDue(_TxtCtcDue.value);"
                                                onblur="SetDefault(); calculateAmountCorp();formatSalary(this.value); formatCTCDue(_TxtCtcDue.value); formatTotAmountCorp(_oTxtTotAmountCorp.value);"
                                                onfocus="ClearSalary();removeCommaSalary(this.value);">
                                            <input type="hidden" id="_oTxtHiddenGrossReceipt">
                                            <%--  <input  type="text" required runat="server" name="RentPerMonth" class="form-control ch-size-new" id="Slide_02_RentPerMonth" oninput="this.reportValidity()" pattern="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" title="Currency" placeholder="0" style="text-align:right" maxlength="25" onblur="formatMoney(this.value);" onfocus="removeComma(this.value);" />
                                            --%>
                                        </div>
                                    </div>                              
                                    <label class="form-group col-lg-8">CTC Due</label>
                                    <div class="form-group col-lg-4">
                                        <div>

                                            <label class="input-txt input-txt-active2">
                                               <%-- <span><span class="m-2">Amount</span></span>--%>
                                            </label>
                                            <input type="text" runat="server" id="_TxtCtcDue" title="PropertySale" onkeypress="return onlyNumbers(this);" readonly="readonly" class="form-control ch-size-new" required autocomplete="off" value="0.00" style="text-align: right">
                                            <input type="hidden" id="_oTxtHiddenCtcDue">
                                        </div>
                                    </div>  
                                <div class="row" style="display:none;">
                                    <div class="my-auto mx-2">Should we deliver your Documents (P250.00)? </div>

                                    <div class="align-items-center row m-1">
                                        <input type="checkbox" id="_oRadioPickup2" onclick="calculateAmountCorp(); formatTotAmountCorp(_oTxtTotAmountCorp.value);" name="CourierServices" class="form-control ch-size my-auto mx-2" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="Pickup">
                                        <div class="m-0 font-weight-bold text-primary my-auto mx-2">Yes</div>
                                        <input type="hidden" runat="server" id="_oTxtHiddenDelivery2">
                                    </div>

                                </div>
                                
                                    <div class="row col-lg-12 d-flex justify-content-end">

                                        <div class="form-group font-weight-bold align-content-center col">Total Amount to Pay </div>
                                 
                                    <input type="text" runat="server" id="_oTxtTotAmountCorp" required class="form-control ch-size-new col-lg-7 my-3" autocomplete="off" value="0.00" placeholder="0.00" style="text-align: right; background: none; font-size: x-large; height: 50px" readonly="readonly">
                                    <input type="hidden" runat="server" id="Hidden1">
                                    <input type="hidden" runat="server" id="Hidden2">

                                        </div> 


                                <div class="col-md-12 d-flex justify-content-center">
                
                        <div class="col-md-12 row d-flex justify-content-center">
                            
                        
                        <button name="btnPayLayte" runat="server"  id="_oBtnResetCorp" type="submit" class="btn btn-primary col-lg-3 m-2 btn-sm"> Reset </button>
                        <input name="btnPayNowCorp" id="_oBtnPayNowCorp" type="submit" onclick="PayNow('PayNow', 'PaymentCorp');" class="btn btn-primary col-md-2 col-lg-4 m-2 btn-sm" value="Proceed to Payment">
                                                  
                        </div>  
                 
                    </div>


                        

             
 
        </div>
                </div>
            
              
    </div>
           

    </div>
  </div>
  <%--<div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab"></div>--%>
</div>

   </div>
        
             
    <script>

        function PayNow(Action, Val) {
            if (Val == 'PaymentInd') {
                if (document.getElementById('<%=_oTxtFirstName.ClientID%>').value !== "" && document.getElementById('<%=_oTxtLastName.ClientID%>').value !== "" && document.getElementById('<%=_oTxtAddress.ClientID%>').value !== "" && document.getElementById('<%=_oTxtBirthDate.ClientID%>').value !== "" && document.getElementById('<%=_oTxtBirthPlace.ClientID%>').value !== "" ) {
                    if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value !== "0.00")
                    {                                                
                        NextPage();
                        __doPostBack(Action, Val);                        
                    }
                    else if (document.getElementById('<%=_oTxtSalary.ClientID%>').value !== "0.00")
                    {                        
                        NextPage();
                        __doPostBack(Action, Val);
                    }
                    else if (document.getElementById('<%=_oTxtPropertySale.ClientID%>').value !== "0.00")
                    {                        
                        NextPage();
                        __doPostBack(Action, Val);
                    }
                    else
                    {
                        document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').style.borderColor = "red";
                        document.getElementById('<%=_oTxtSalary.ClientID%>').style.borderColor = "red";
                        document.getElementById('<%=_oTxtPropertySale.ClientID%>').style.borderColor = "red";
                        document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').focus = true;
                    }
                }
            }

            if (Val == 'PaymentCorp') {

                if (document.getElementById('<%=_oTxtCompanyName.ClientID%>').value !== "" && document.getElementById('<%=_oTxtCorpTIN.ClientID%>').value !== "" && document.getElementById('<%=_oTxtAddressPrincipal.ClientID%>').value !== "" && document.getElementById('<%=_oTxtPlaceofIncorporation.ClientID%>').value !== "" && document.getElementById('<%=_oTxtDateIncorporation.ClientID%>').value !== "" && document.getElementById('<%=_oTxtKindBusiness.ClientID%>').value !== "" && document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value !== "" && document.getElementById('<%=_oTxtAssValue.ClientID%>').value !== "") {
                    if (document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value !== "0.00" && document.getElementById('<%=_oTxtAssValue.ClientID%>').value !== "") {
                        NextPage();
                        __doPostBack(Action, Val);
                    }
                }
            }
            //document.getElementById('frmIndividual').reportValidity();                        
        }

        //NARDO 20200505
        function CheckBlank() {
            if (document.getElementById('<%=_oTxtFirstName.ClientID%>').value == "") {
                alert("Please input your First Name!")
            }
            else if (document.getElementById('<%=_oTxtLastName.ClientID%>').value == "") {
                alert("Please input your Last Name!")
            }
            else if (document.getElementById('<%=_oTxtAddress.ClientID%>').value == "") {
                alert("Please input your Address!")
            }
            else if (document.getElementById('<%=radCitizenship.ClientID%>').value == "") {
                alert("Please input your Citizenship!")
            }
            else if (document.getElementById('<%=_oTxtBirthDate.ClientID%>').value == "") {
                alert("Please input your Birth Date!")
            }
            else if (document.getElementById('<%=_oTxtHdnBirthDate.ClientID%>').value !== "") {
                alert("You're 18 years old below!")
            }
            else if (document.getElementById('<%=_oTxtBirthPlace.ClientID%>').value == "") {
                alert("Please input your Birth Place!")
            }
            else if (document.getElementById('<%=radGender.ClientID%>').value == "") {
                alert("Please input your Gender!")
            }
            else if (document.getElementById('<%=radCivilstat.ClientID%>').value == "") {
                alert("Please input your Civil Status!")
            }
            else if (document.getElementById('<%=radProfession.ClientID%>').value == "") {
                alert("Please input your Profession!")
            }
            else if (document.getElementById('<%=_oTxtTIN.ClientID%>').value == "") {
                alert("Please input your TIN No.!")
            }
            else if (document.getElementById('<%=_oTxtHeight.ClientID%>').value == "") {
                alert("Please input your Height!")
            }
            else if (document.getElementById('<%=_oTxtWeight.ClientID%>').value == "") {
                alert("Please input your Weight!")
            }
}


//function StopRefreshing()
//{
//    e.preventDefault()
//    alert
//}


function EnableDisableSalary() {

    <%--if (document.getElementById('<%=radProfession.ClientID%>').value == "")
    {
        
        document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = true
    }
    else
    {        
        document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = false
    }--%>

}


        function IndividualClick() {

            document.getElementById('<%=_oTxtHdnCedulaInd.ClientID%>').value = '1'
            document.getElementById('<%=_oTxtHdnCedulaCorp.ClientID%>').value = '0'
        }

        function CorporationClick() {
            document.getElementById('<%=_oTxtHdnCedulaInd.ClientID%>').value = '0'
            document.getElementById('<%=_oTxtHdnCedulaCorp.ClientID%>').value = '1'
        }

        function formatMoney(id, val) {

            var formatter = new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: '',
            });

            var x = formatter.format(val);
            x = x.replace(/\s/g, '');
            x = x.replace('₱', '');
            id.value = x;
            //  document.getElementById('').value = x;
        }

        function ComputeAge(id) {
            //_oTxtBirthDate
            var DateNow = new Date();
            var DateYearNow = parseInt(DateNow.getFullYear());
            //alert("year now" + DateYearNow)
            var DateMonthNow = parseInt(DateNow.getMonth()) + 1;
            //alert("month now" + DateMonthNow)
            var DateDayNow = parseInt(DateNow.getDate());
            //alert("day now" + DateDayNow)
            var BirthdayYear = document.getElementById('<%=_oTxtBirthDate.ClientID%>').value.substr(0, 4);
    //alert("year bday" + BirthdayYear)
    var BirthdayMonth = document.getElementById('<%=_oTxtBirthDate.ClientID%>').value.substr(5, 2);
    //alert("month bday" + BirthdayMonth)
    var BirthdayDay = document.getElementById('<%=_oTxtBirthDate.ClientID%>').value.substr(8, 2);
    //alert("day bday" + BirthdayDay)
    var age = parseInt(DateYearNow) - parseInt(BirthdayYear)
    if ((parseInt(DateMonthNow) == parseInt(BirthdayMonth) && parseInt(DateDayNow) < parseInt(BirthdayDay))) {
        age = age - 1;
    }
    if (age < 18) {
        alert("Under 18 is not allowed");
        document.getElementById("<%=_oTxtBirthDate.ClientID%>").focus = true;
                document.getElementById('<%=_oTxtHdnBirthDate.ClientID%>').value = "not allowed"
            }
            else {
                document.getElementById('<%=_oTxtHdnBirthDate.ClientID%>').value = ""
            }
        }

    </script>
    

    <script>        //NARDO 20200505

        function onlyNumbers(evt) {

            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if (charCode < 48 || charCode > 57)
                return false;

            return true;

        }
        function onlyNumbersDash(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode < 45 || charCode > 45) && (charCode < 48 || charCode > 57))
                return false;

            return true;

        }

    </script>

    <script> //NARDO 20200505
        function EnableDisable(id) {
            <%--if (id.value == "Unemployed") {
                document.getElementById("<%=_oTxtSalary.ClientID%>").disabled = true;
                document.getElementById("<%=_oTxtSalary.ClientID%>").value = "";
            }
            else {
                <%--if (document.getElementById('<%=CedulaCorp.ClientID%>').checked == false)--%>
                    <%--document.getElementById("<%=_oTxtSalary.ClientID%>").disabled = false;
                document.getElementById("<%=_oTxtSalary.ClientID%>").value = "0.00";--%>

            //}                           
        }

    </script>

    <script> //NARDO 20200505
        function onlyLetters(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 31 || charCode > 33))
                return false;


            return true;

        }
    </script>

    <script> //NARDO 20200505
        function addHyphen(element) {
            let ele = document.getElementById(element.id);
            ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

            let finalVal = ele.match(/.{1,3}/g).join('-');
            document.getElementById(element.id).value = finalVal;
        }
</script>

    <%--<script type="text/javascript">        //NARDO 20200505
        $(document).ready(function () {
            //Mask the textbox as per your format 123-123-123
            $('#_oTxtTIN').mask('999-999-999-999', { placeholder: "#" });
        });
       </script>--%>

     <script >
        
        
         function GetBasic(id) {
             if (id.checked == true) {
                 document.getElementById('_oTxtHiddenNewBusiness').value = 100;
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').disabled = true;
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = "";
             }
             else {
                 document.getElementById('_oTxtHiddenNewBusiness').value = 0;
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').disabled = false;
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = "0.00";
             }
         }

         function GetDelivery(id) {
             if (id.checked == true) {
                 document.getElementById('_oTxtHiddenDelivery').value = 250;
             }
             else {
                 document.getElementById('_oTxtHiddenDelivery').value = 0;
             }
         }

         function PassToHidden(id) {
             document.getElementById('<%=radProfession.ClientID%>').value = document.getElementById('radioProfession').value;
         }

         function LabelHidden() {

             <%--if (document.getElementById('<%=radioProfession.ClientID%>').value == "")
             {                
                 if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value !== "0.00" || document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value !== "")
                 {
                     _oLblKindly.hidden = true
                 }
                 if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value == "0.00" || document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value == "") {                     
                     _oLblKindly.hidden = false
                 }
             }

             if (document.getElementById('<%=radioProfession.ClientID%>').value !== "")
             {                           
                 if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value !== "0.00" || document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value !== "") {
                     _oLblKindly.hidden = true
                     if (document.getElementById('<%=_oTxtSalary.ClientID%>').value !== "0.00" || document.getElementById('<%=_oTxtSalary.ClientID%>').value !== "") {
                         _oLblKindly.hidden = true
                     }
                 }
                 if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value == "0.00" || document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value == "") {
                     _oLblKindly.hidden = false
                     if (document.getElementById('<%=_oTxtSalary.ClientID%>').value == "0.00" || document.getElementById('<%=_oTxtSalary.ClientID%>').value == "") {
                         _oLblKindly.hidden = false
                     }
                 }

                 if (document.getElementById('<%=_oTxtSalary.ClientID%>').value !== "0.00" || document.getElementById('<%=_oTxtSalary.ClientID%>').value !== "") {
                     _oLblKindly.hidden = true
                     if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value !== "0.00" || document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value !== "") {
                         _oLblKindly.hidden = true
                     }
                 }
                 if (document.getElementById('<%=_oTxtSalary.ClientID%>').value == "0.00" || document.getElementById('<%=_oTxtSalary.ClientID%>').value == "") {
                     _oLblKindly.hidden = false
                     if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value == "0.00" || document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value == "") {
                         _oLblKindly.hidden = false
                     }
                 }
             }

             if (_oChkNewBusiness.checked == true && document.getElementById('<%=radioProfession.ClientID%>').value == "")
             {
                 if (document.getElementById('<%=_oTxtPropertySale.ClientID%>').value !== "0.00" || document.getElementById('<%=_oTxtPropertySale.ClientID%>').value !== "") {
                     _oLblKindly.hidden = true
                 }
                 if (document.getElementById('<%=_oTxtPropertySale.ClientID%>').value == "0.00" || document.getElementById('<%=_oTxtPropertySale.ClientID%>').value == "") {
                     _oLblKindly.hidden = false
                 }
             }--%>
         }

         function changeColor()
         {
             
             if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value !== "0.00")
             {
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').style.borderColor = "gray"
                 document.getElementById('<%=_oTxtSalary.ClientID%>').style.borderColor = "gray"
                 document.getElementById('<%=_oTxtPropertySale.ClientID%>').style.borderColor = "gray"
             }
             else if (document.getElementById('<%=_oTxtSalary.ClientID%>').value !== "0.00")
             {
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').style.borderColor = "gray"
                 document.getElementById('<%=_oTxtSalary.ClientID%>').style.borderColor = "gray"
                 document.getElementById('<%=_oTxtPropertySale.ClientID%>').style.borderColor = "gray"
             }
             else if (document.getElementById('<%=_oTxtPropertySale.ClientID%>').value !== "0.00")
             {
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').style.borderColor = "gray"
                 document.getElementById('<%=_oTxtSalary.ClientID%>').style.borderColor = "gray"
                 document.getElementById('<%=_oTxtPropertySale.ClientID%>').style.borderColor = "gray"
             }
             else
             {
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').style.borderColor = "red"
                 document.getElementById('<%=_oTxtSalary.ClientID%>').style.borderColor = "red"
                 document.getElementById('<%=_oTxtPropertySale.ClientID%>').style.borderColor = "red"
             }
         }

         function calculateAmount() {
             var Bus = parseFloat(document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value.replace(/,/g, ''));
             var Sal = parseFloat(document.getElementById('<%=_oTxtSalary.ClientID%>').value.replace(/,/g, ''));
             var RP = parseFloat(document.getElementById('<%=_oTxtPropertySale.ClientID%>').value.replace(/,/g, ''));
             var TrimProfession = ""
             var delivery = 0
             var newBusiness = 0
             var Unemployed = 0
             var Basic = 5
             var CurrentURL = window.location.href;
             CurrentURL = CurrentURL.toUpperCase();       
             if (CurrentURL.includes("CALOOCAN") == true) {
                 Basic = 5.5   
             }

            //+ parseInt(document.getElementById('_oTxtHiddenNewBusiness').value);
             document.getElementById('<%=_oTxtHiddenBasicAmount.ClientID%>').value = Basic;
             TrimProfession = document.getElementById('<%=radioProfession.ClientID%>').value;
             if (TrimProfession.trim() == "") {
                 document.getElementById('<%=radioProfession.ClientID%>').value = ""
             }
             if (radioProfession.value == "") {
                 Unemployed = 15;
                 var x = 0
                 document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = true
                 document.getElementById('<%=_oTxtSalary.ClientID%>').value = "0.00"
                 Sal = 0

                 //alert(Basic)
             }
             if (radioProfession.value !== "") {
                 Unemployed = 0;
                 document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = false                                                 
                 <%--alert(document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value)--%>

             }

             if (_oRadioPickup.checked == true) {
                 delivery = 250;
                 document.getElementById('<%=_oTxtHiddenDelivery.ClientID%>').value = delivery;
             }
             if (_oChkNewBusiness.checked == true) {
                 newBusiness = 100;
                 var x = 0
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').disabled = true
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = "0.00"
                 Bus = 0


             }
             if (_oChkNewBusiness.checked == false) {
                 newBusiness = 0;
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').disabled = false

             }

             <%--if (TrimProfession.trim() == "")
             {
                 document.getElementById('<%=radioProfession.ClientID%>').value = TrimProfession.trim();
             }--%>

             <%--if (document.getElementById('<%=radioProfession.ClientID%>').value == "")
             {
                
                 document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = true
             }
             else
             {
                 
                 document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = false
             }--%>

             //parseInt(document.getElementById('_oTxtHiddenDelivery').value);

             var DateNow = new Date();
             var Month = parseInt(DateNow.getMonth()) + 1;
             var Penalty = 0.02 * parseInt(Month);

             //var TotGross = (parseFloat(Bus) + parseFloat(Sal) + parseFloat(RP));
             if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value == "") {
                 Bus = 0;
                 //alert("no business")
             }
             if (document.getElementById("<%=_oTxtSalary.ClientID%>").value == "") {
                 Sal = 0;
                 //alert("no salary")
             }
             if (document.getElementById("<%=_oTxtPropertySale.ClientID%>").value == "") {
                 RP = 0;
                 //alert("no salary")
             }

             var TotGross = (parseFloat(Bus) + parseFloat(Sal) + parseFloat(RP));

             /* get amount 1 peso for every 1000 */
             var Divisor = parseFloat(TotGross) / 1000;
             //var Subtract = parseFloat(TotGross) - parseFloat(Remainder);
             //var quotient = parseFloat(Subtract) / 2000;
             //var quotient = Math.floor(Divisor) * 2;

              var TaxDue = Math.floor(Divisor) * 1;
             var CurrentURL = window.location.href;
             CurrentURL = CurrentURL.toUpperCase();
             if (CurrentURL.includes("CALOOCAN") == true) {
                 TaxDue = Math.floor(Divisor) * 1.1;
                 //alert(TaxDue);
             }

           

             if (TaxDue >= 5000) {
                 TaxDue = 5000;
                 //alert(Bus)
                 //alert(TotGross)
             };
             //             
             var ComputedTaxDue = parseFloat(TaxDue) + parseFloat(Basic) + newBusiness + Unemployed;
             var Interest = parseFloat(ComputedTaxDue) * parseFloat(Penalty);
             var tot_amount = parseFloat(TaxDue) + parseFloat(Basic) + parseFloat(Interest) + newBusiness + Unemployed;
             document.getElementById('<%=_oTxtHiddenAmountDue.ClientID%>').value = TaxDue;
             document.getElementById('<%=_oTxtHiddenPenalty.ClientID%>').value = Interest;
             _oTxtHiddenTotAmount
             /*display the result*/
             document.getElementById('<%=AmountToPay.ClientID%>').value = (tot_amount + delivery).toFixed(2);
             document.getElementById('<%=_oTxtHiddenTotAmount.ClientID%>').value = tot_amount + delivery;

         };

         /**************************************Start of Corp Computation*****************************/
         function calculateAmountCorp() {
             var Bus = parseFloat(document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value.replace(/,/g, ''));
             var RP = parseFloat(document.getElementById('<%=_oTxtAssValue.ClientID%>').value.replace(/,/g, ''));
             var TrimProfession = ""
             var delivery = 0
             var newBusiness = 0
             var Unemployed = 0
             var Basic = 500 //+ parseInt(document.getElementById('_oTxtHiddenNewBusiness').value);
             var CurrentURL = window.location.href;
             CurrentURL = CurrentURL.toUpperCase();
             if (CurrentURL.includes("CALOOCAN") == true) {
                 Basic = 550
             }

             document.getElementById('<%=_oTxtHiddenBasicAmount.ClientID%>').value = Basic;

             if (_oRadioPickup2.checked == true) {
                 delivery = 250;
                 document.getElementById('<%=_oTxtHiddenDelivery.ClientID%>').value = delivery;
             }
             var DateNow = new Date();
             var Month = parseInt(DateNow.getMonth()) + 1;
             var Penalty = 0.02 * parseInt(Month);

             //var TotGross = (parseFloat(Bus) + parseFloat(Sal) + parseFloat(RP));
             if (document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value == "") {
                     Bus = 0;
                     //alert("no business")
                 }
                 if (document.getElementById("<%=_oTxtAssValue.ClientID%>").value == "") {
                 RP = 0;
                 //alert("no salary")
             }

             var TotGross = (parseFloat(Bus) + parseFloat(RP));

             /* get amount 1 peso for every 5000 */
             var Divisor = parseFloat(TotGross) / 5000;
             //var Subtract = parseFloat(TotGross) - parseFloat(Remainder);
             //var quotient = parseFloat(Subtract) / 2000;
             //var quotient = Math.floor(Divisor) * 2;
             var TaxDue = Math.floor(Divisor) * 2;

             if (CurrentURL.includes("CALOOCAN") == true) {
                 TaxDue = Math.floor(Divisor) * 2.2;
             }

             if (TaxDue >= 10000) {
                 TaxDue = 10000;
                 //alert(Bus)
                 //alert(TotGross)
             };
             //             
             var ComputedTaxDue = parseFloat(TaxDue) + parseFloat(Basic);
             var Interest = parseFloat(ComputedTaxDue) * parseFloat(Penalty);
             var tot_amount = parseFloat(TaxDue) + parseFloat(Basic) + parseFloat(Interest);
             document.getElementById('<%=_oTxtHiddenAmountDue.ClientID%>').value = TaxDue;
                 document.getElementById('<%=_oTxtHiddenPenalty.ClientID%>').value = Interest;

             /*display the result*/
             document.getElementById('<%=_TxtCtcDue.ClientID%>').value = tot_amount.toFixed(2);
             document.getElementById('<%=_oTxtTotAmountCorp.ClientID%>').value = (tot_amount + delivery).toFixed(2);
             document.getElementById('<%=_oTxtHiddenTotAmount.ClientID%>').value = tot_amount + delivery;


         }

         /**************************************End of Corp Computation*****************************/

         function SetDefault() {
             if (document.getElementById('<%=_oTxtSalary.ClientID%>').value.length == 0) {
                     document.getElementById('<%=_oTxtSalary.ClientID%>').value = 0.00;
                 };
                 if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value.length == 0) {
                     document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = 0.00;
                 };
                 if (document.getElementById('<%=_oTxtPropertySale.ClientID%>').value.length == 0) {
                     document.getElementById('<%=_oTxtPropertySale.ClientID%>').value = 0.00;
                 };
                 if (document.getElementById('<%=_oTxtAssValue.ClientID%>').value.length == 0) {
                     document.getElementById('<%=_oTxtAssValue.ClientID%>').value = 0.00;
                 };
                 if (document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value.length == 0) {
                     document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value = 0.00;
                 };
             };

             function ClearSalary() {
                 if (document.getElementById('<%=_oTxtSalary.ClientID%>').value <= 0.00) {
                     document.getElementById('<%=_oTxtSalary.ClientID%>').value = '';
                 };
                 if (document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value <= 0.00) {
                     document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value = '';
                 };

             };

             function ClearBusiness() {
                 if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value <= 0.00) {
                     document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = '';
                 };
                 if (document.getElementById('<%=_oTxtAssValue.ClientID%>').value <= 0.00) {
                     document.getElementById('<%=_oTxtAssValue.ClientID%>').value = '';
                 };
             };

             function ClearProperty() {
                 if (document.getElementById('<%=_oTxtPropertySale.ClientID%>').value <= 0.00) {
                     document.getElementById('<%=_oTxtPropertySale.ClientID%>').value = '';
                 };
             };
         </script>
   

         <script>
             var today = new Date();
             var dd = today.getDate();
             var mm = today.getMonth() + 1; //January is 0!
             var yyyy = today.getFullYear();
             if (dd < 10) {
                 dd = '0' + dd
             }
             if (mm < 10) {
                 mm = '0' + mm
             }

             today = yyyy + '-' + mm + '-' + dd;
             document.getElementById('<%=_oTxtBirthDate.ClientID%>').setAttribute("max", today);
             document.getElementById('<%=_oTxtDateIncorporation.ClientID%>').setAttribute("max", today);
                </script>


   <script type="text/javascript">
       function removeComma(x) {
           //document.getElementById().value = x.replace(/,/g, '');


       }

       function formatMoney(val) {

           var formatter = new Intl.NumberFormat('en-US', {
               style: 'currency',
               currency: 'PHP',
           });

           var x = formatter.format(val);
           x = x.split('PHP').join('');
           x = x.replace(/\s/g, '');
           x = x.replace('₱', '');
           //document.getElementById().value = x;
       }

       function InitCedulaType() {
           document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').disabled = false;
           document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = false;
           document.getElementById('<%=_oTxtPropertySale.ClientID%>').disabled = false;

           document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = 0.00;
           document.getElementById('<%=_oTxtSalary.ClientID%>').value = 0.00;
           document.getElementById('<%=_oTxtPropertySale.ClientID%>').value = 0.00;
           document.getElementById('<%=AmountToPay.ClientID%>').value = 0.00;


                    <%--if (document.getElementById('<%=CedulaIndi.ClientID%>').checked == true) {

                        document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').disabled = false;


                    } else {
                        document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = true;
                        document.getElementById('<%=_oTxtPropertySale.ClientID%>').disabled = true;
                    };--%>
       };

       function numberWithCommas(x) {
           return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
       };

       function removeCommaBusinessIncome(x) {
           document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = x.replace(/,/g, '');
                    document.getElementById('<%=_oTxtAssValue.ClientID%>').value = x.replace(/,/g, '');

                };

                function formatBusinessIncome(val) {

                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: '',
                    });

                    var x = formatter.format(val);
                    x = x.split('').join('');
                    x = x.replace(/\s/g, '');
                    x = x.replace('₱', '');
                    if (document.getElementById('<%=_oTxtHdnCedulaInd.ClientID%>').value == "1") {
                        document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = x;
                    }
                    if (document.getElementById('<%=_oTxtHdnCedulaCorp.ClientID%>').value == "1") {
                        document.getElementById('<%=_oTxtAssValue.ClientID%>').value = x;
                    }
                };

                function formatCTCDue(val) {

                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: '',
                    });

                    var x = formatter.format(val);
                    x = x.split('').join('');
                    x = x.replace(/\s/g, '');
                    x = x.replace('₱', '');

                    document.getElementById('<%=_TxtCtcDue.ClientID%>').value = x;


                    };

                    function formatTotAmountCorp(val) {

                        var formatter = new Intl.NumberFormat('en-US', {
                            style: 'currency',
                            currency: '',
                        });

                        var x = formatter.format(val);
                        x = x.split('').join('');
                        x = x.replace(/\s/g, '');
                        x = x.replace('₱', '');

                        document.getElementById('<%=_oTxtTotAmountCorp.ClientID%>').value = x;


       };



       function removeCommaSalary(x) {
           document.getElementById('<%=_oTxtSalary.ClientID%>').value = x.replace(/,/g, '');
                    document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value = x.replace(/,/g, '');

                };

                function formatSalary(val) {

                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: '',
                    });

                    var x = formatter.format(val);
                    x = x.split('').join('');
                    x = x.replace(/\s/g, '');
                    x = x.replace('₱', '');

                    if (document.getElementById('<%=_oTxtHdnCedulaInd.ClientID%>').value == "1") {
                        document.getElementById('<%=_oTxtSalary.ClientID%>').value = x;
                    }
                    if (document.getElementById('<%=_oTxtHdnCedulaCorp.ClientID%>').value == "1") {
                        document.getElementById('<%=_oTxtGrossReceipt.ClientID%>').value = x;
                    }
                };

                function formatHeight(val) {

                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: '',
                    });

                    var x = formatter.format(val);
                    if (x > 250)
                        x = 250;
                    x = x.split('').join('');
                    x = x.replace(/\s/g, '');
                    x = x.replace('₱', '');
                    document.getElementById('<%=_oTxtHeight.ClientID%>').value = x;
                 };

                 function formatWeight(val) {

                     var formatter = new Intl.NumberFormat('en-US', {
                         style: 'currency',
                         currency: '',
                     });

                     var x = formatter.format(val);
                     if (x > 200)
                         x = 200;
                     x = x.split('').join('');
                     x = x.replace(/\s/g, '');
                     x = x.replace('₱', '');


                     document.getElementById('<%=_oTxtWeight.ClientID%>').value = x;
                };


                function removeCommaSales(x) {
                    document.getElementById('<%=_oTxtPropertySale.ClientID%>').value = x.replace(/,/g, '');


                };

                function formatSales(val) {

                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: '',
                    });

                    var x = formatter.format(val);
                    x = x.split('').join('');
                    x = x.replace(/\s/g, '');
                    x = x.replace('₱', '');
                    document.getElementById('<%=_oTxtPropertySale.ClientID%>').value = x;
                };


            </script>

 
</asp:Content>



