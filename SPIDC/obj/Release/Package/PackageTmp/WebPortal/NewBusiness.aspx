<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="NewBusiness.aspx.vb" Inherits="SPIDC.NewBusiness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">

      <meta charset="utf-8">
    <div class="p-1">
        <h5 class="m-2 font-weight-bold text-primary">New Business</h5>
    </div>
    <%-- ADDEDD BY LOUIE  PAGE STEP INDICATOR --%>
    <link href="../CSS_JS_IMG/css/newcss/aurora/aurora.css" rel="stylesheet" />
    <%-- -------%>

    <div>
        <%-- <div aria-label="progress" class="step-indicator">
                 <ul class="steps">
                     <li class="complete"> <span class="sr-only">completed</span></li>
                     <li class="active" aria-current="true"></li>
                     <li><span class="sr-only"></span></li>
                     <li><span class="sr-only"></span></li>
                  </ul>
             </div>--%>
        <%--   <div aria-label="progress" class="step-indicator">
                 <ul class="steps">
                     <li class="active"> <span class="sr-only"></span></li>
                     <li class="active"><span class="sr-only"></span></li>
                     <li><span class="sr-only"></span></li>
                     <li><span class="sr-only"></span></li>
                  </ul>
             </div>--%>
    </div>
    <div class="" style="width: 100%; z-index: -1; margin-top: 10px">
        <%--  <ul class="list-unstyled multi-steps">
    <li class="is-active">Cedula</li>   
    <li class="is-active">Payment</li>
    <li class="is-active" >Complete</li>
      
  </ul>--%>
    </div>
        
    <div class="col-md-5 row">
        <div class="form-group col-lg-6 ">
            <div>
                <label class="input-txt input-txt-active2">
                    <span><span class="m-2">Type of Ownership</span></span>
                </label>
                <select runat="server" id="_oDpTypeofOwnership" name="For Year" class="form-control CH-Size-New-New" onchange="OwnershipSelection(this)">
                    <option value="S" selected>Single</option>
                    <option value="P">Partnership</option>
                    <option value="C">Corporation</option>
                    <option value="A">Association</option>
                </select>
            </div>
        </div>
        <div class="form-group col-lg-6 ">
            <div>
                <label class="input-txt input-txt-active2">
                    <span><span class="m-2">Date of Application </span></span>
                </label>
                <input type="date" runat="server" class="form-control CH-Size-New" id="_otxtDateApplication" disabled/>
                
            </div>
        </div>
        <script>
             
            let today = new Date().toISOString().substr(0,10);
            document.querySelector("#_otxtDateApplication").value = today;
            
            </script>
        

    </div>
    <div class="col-lg-7 row">
    </div>
    <div class="m-1 ">

        <ul class="nav nav-tabs tab-PN" id="myTab" role="tablist">
            <li class="nav-item">
                <a class="nav-link active" id="tab1-tab" data-toggle="tab" href="#tab1" role="tab" aria-controls="tab1"
                    aria-selected="true" onclick="setTimeout(counter,1)">Step 1</a>
                <input type="hidden" runat="server" id="_oTxtHdnTab1" />
            </li>
            <li class="nav-item">
                <a class="nav-link" id="tab2-tab" data-toggle="tab" href="#tab2" role="tab" aria-controls="tab2"
                    aria-selected="false" onclick="setTimeout(counter,1)">Step 2</a>
                <input type="hidden" runat="server" id="_oTxtHdnTab2" />
            </li>
            <%--<li class="nav-item">
                <a class="nav-link" id="tab3-tab" data-toggle="tab" href="#tab3" role="tab" aria-controls="profile"
                    aria-selected="false" onclick="setTimeout(counter,1)">Step 3</a>
                <input type="hidden" runat="server" id="Hidden1" />
            </li>--%>
            <%--<li class="nav-item">
    <a class="nav-link" id="contact-tab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact"
      aria-selected="false">Contact</a>
  </li>--%>
        </ul>
        <script>
            function myFunction(OP) {
                var list = document.getElementsByClassName("tab-PN")[0];
                var i;
                for (i = 0; i < list.getElementsByTagName("LI").length; i++) {
                    var now = list.getElementsByTagName("LI")[i];
                    if (now.getElementsByTagName("A")[0].classList.contains('active')) {
                        list.getElementsByTagName("LI")[i + OP].getElementsByTagName("A")[0].click();
                        return false;
                    }
                }
            }
</script>


        </div>
        <div class="tab-content" id="myTabContent" style="background-color: #ffffff">
            <div class="tab-pane fade show active" id="tab1" role="tabpanel" aria-labelledby="home-tab" style="background-color: #ffffff">
                <div class="mx-1 d-flex justify-content-center">
                    <div class="row col-lg-12 ">
                        <div class="col-lg-12 ">

                            <%--<h6 class="m-0 font-weight-bold text-primary mb-3">Cedula (Individual)</h6>--%>
                        </div>

                        <div class="col-lg-10 row" id="_odvSingle">

                            <%--<div class="form-group col-lg-8 mb-4">
                       <%-- <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 CH-Size-New"  />--%>
                            <%--&nbsp  I am getting this cedula for myself. 
                        
                    </div>--%>

                            <div class="p-1 col-12 mb-2">
                                <p class="m-2 font-weight-bold text-primary">Business Informtion</p>
                            </div>


                            <div class="form-group col-lg-7 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Business Name </span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtBusName"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-5 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Trade Name(Franchise Name)</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New"  id="_otxtTradeName"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-5 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Business Address</span></span>
                                    </label>
                                    <textarea runat="server" class="form-control CH-Size-New" id="_otxtBusAddress" onclick="getpickaddress = this.id;PickAddress('Business Address');" data-toggle="modal" data-target="#AddressModal" data-ticket-type="standard-access"></textarea>
                                </div>
                            </div>
                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2"  id="_olblDTISEC">DTI Registration No.</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtDTISECReg" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2"  id="_olblDTISECDate">DTI Registration Date</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtDTIDate" onfocus="(this.type='date')"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtBusTelNo" onkeypress="return onlyNumbers();" maxlength="25"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="email" class="form-control CH-Size-New" runat="server" id="_otxtBusEmailAddress"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">T.I.N.</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtBusTIN" name="TIN" onkeypress="return onlyNumbers(this);" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" title="TIN" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-10 row" id="_odvTaxPayer-1">

                            <%--<div class="form-group col-lg-8 mb-4">
                       <%-- <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 CH-Size-New"  />--%>
                            <%--&nbsp  I am getting this cedula for myself. 
                        
                    </div>--%>

                            <div class="p-1 col-12 mb-2">
                                <p class="m-2 font-weight-bold text-primary" id="_olblTpTittle-1">Taxpayer's Information (Single)</p>
                            </div>


                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Last Name </span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" onkeypress="return onlyLetters();" name="LastName" id="_otxtTPLastName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">First Name</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" name="FisrtName" onkeypress="return onlyLetters();" id="_otxtTPFirstName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Middle Name</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" name="MiddleName" onkeypress="return onlyLetters();" id="_otxtTPMiddleName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Middle Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Suffix</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" onkeypress="return onlyLetters();" id="_otxtTPSuffix" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Suffix" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Gender</span></span>
                                    </label>                                    
                                    <select required runat="server" id="_oCBTPGender" name="radGender" class="form-control CH-Size-New">
                                <option value="M" selected>Male</option>
                                <option value="F">Female</option>
                            </select>
                                </div>
                            </div>
                            <div class="form-group col-lg-8 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Address</span></span>
                                    </label>
                                    <textarea class="form-control CH-Size-New" runat="server" id="_otxtTPAddress" onclick="getpickaddress = this.id;PickAddress('Address');" data-toggle="modal" data-target="#AddressModal" data-ticket-type="standard-access" title="Address"></textarea>
                                </div>
                            </div>
                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Citizenship</span></span>
                                    </label>                                    
                                    <select required runat="server" id="_oCBTPCitizenship" name="radCitizenship" class="form-control CH-Size-New" title="Citizenship">
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
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtTPTelNo" onkeypress="return onlyNumbers();" maxlength="25" title="Contact No."/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="email" class="form-control CH-Size-New" runat="server" id="_otxtTPEmailAddress"  title="Email Address"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">T.I.N.</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtTPTIN" name="TIN" onkeypress="return onlyNumbers(this);" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" title="TIN" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">SSS</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtTPSSS" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " title="SSS"/>
                                </div>
                            </div>
                        </div>


                        <div class="col-lg-10 row" id="_odvTaxPayer-2" style="display:none">

                            <%--<div class="form-group col-lg-8 mb-4">
                       <%-- <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 CH-Size-New"  />--%>
                            <%--&nbsp  I am getting this cedula for myself. 
                        
                    </div>--%>

                            <div class="p-1 col-12 mb-2">
                                <p class="m-2 font-weight-bold text-primary" id="_olblTpTittle-2">Taxpayer's Information (Single) or Partnership - Owner 1</p>
                            </div>


                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Last Name </span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" onkeypress="return onlyLetters();" name="LastName" id="_otxtTP2LastName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">First Name</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" name="FisrtName" onkeypress="return onlyLetters();" id="_otxtTP2FirstName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Middle Name</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" name="MiddleName" onkeypress="return onlyLetters();" id="_otxtTP2MiddleName" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Middle Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Suffix</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" onkeypress="return onlyLetters();" id="_otxtTP2Suffix" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Suffix" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Gender</span></span>
                                    </label>                                    
                                    <select required runat="server" id="_oCBTP2Gender" name="radGender" class="form-control CH-Size-New" title="Gender">
                                <option value="M" selected>Male</option>
                                <option value="F">Female</option>
                            </select>
                                </div>
                            </div>
                            <div class="form-group col-lg-8 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Address</span></span>
                                    </label>
                                    <textarea class="form-control CH-Size-New" runat="server" id="_otxtTP2Address" onclick="getpickaddress = this.id;PickAddress('Address');" data-toggle="modal" data-target="#AddressModal" data-ticket-type="standard-access" title="Address"></textarea>
                                </div>
                            </div>
                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Citizenship</span></span>
                                    </label>                                    
                                    <select required runat="server" id="_oCBTP2Citizenship" name="radCitizenship" class="form-control CH-Size-New" title="Citizenship">
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
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtTP2TelNo" onkeypress="return onlyNumbers();" maxlength="25" title="Contact No."/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="email" class="form-control CH-Size-New" runat="server" id="_otxtTP2EmailAddress" title="Email Address"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">T.I.N.</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtTP2TIN" name="TIN" onkeypress="return onlyNumbers(this);" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" title="TIN" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">SSS</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-New" runat="server" id="_otxtTP2SSS" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); "  title="SSS"/>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-10 row" id="_odvCorporation" style="display:none">

                            <%--<div class="form-group col-lg-8 mb-4">
                       <%-- <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 CH-Size-New"  />--%>
                            <%--&nbsp  I am getting this cedula for myself. 
                        
                    </div>--%>

                            <div class="p-1 col-12 mb-2">
                                <p class="m-2 font-weight-bold text-primary" id="_olblCorpTittle">(Corporation) or association</p>
                            </div>

                            <div class="form-group col-lg-7 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Name of Corporation</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCorpName" />
                                </div>
                            </div>
                            <div class="form-group col-lg-5 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCorpTelNo" onkeypress="return onlyNumbers();" maxlength="25" />
                                </div>
                            </div>
                            <div class="form-group col-lg-7 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Address of Main Office</span></span>
                                    </label>
                                    <textarea runat="server" class="form-control CH-Size-New" id="_otxtCorpAddress" onclick="getpickaddress = this.id;PickAddress('Address of Main Office');" data-toggle="modal" data-target="#AddressModal" data-ticket-type="standard-access"></textarea>
                                </div>
                            </div>
                            <div class="form-group col-lg-5 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="email" class="form-control CH-Size-New" runat="server" id="_otxtCorpEmailAddress" />
                                </div>
                            </div>

                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Name of President</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCorpPresident" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCPresEmailAddress" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCPresMobileNo" onkeypress="return onlyNumbers();" maxlength="11" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Gender</span></span>
                                    </label>
                                    <select required runat="server" id="_oCBCPresGender" name="radGender" class="form-control CH-Size-New">
                                        <option value="M" selected>Male</option>
                                        <option value="F">Female</option>
                                    </select>
                                </div>
                            </div>






                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Name of Tresurer</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCTresName"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCTresEmailAddress" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCTresMobileNo" onkeypress="return onlyNumbers();" maxlength="11" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Gender</span></span>
                                    </label>
                                    <select required runat="server" id="_otxtCTresGender" name="radGender" class="form-control CH-Size-New">
                                        <option value="M" selected>Male</option>
                                        <option value="F">Female</option>
                                    </select>
                                </div>
                            </div>


                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Name of Secretary</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCSecName"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCSecEmailAddress" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCSecMobileNo" onkeypress="return onlyNumbers();" maxlength="11" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Gender</span></span>
                                    </label>
                                    <select required runat="server" id="_otxtCSecGender" name="radGender" class="form-control CH-Size-New">
                                        <option value="M" selected>Male</option>
                                        <option value="F">Female</option>
                                    </select>
                                </div>
                            </div>



                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Name of Manager</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCManName"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCManEmailAddress" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCManMobileNo" onkeypress="return onlyNumbers();" maxlength="11" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Gender</span></span>
                                    </label>
                                    <select required runat="server" id="_otxtCManGender" name="radGender" class="form-control CH-Size-New">
                                        <option value="M" selected>Male</option>
                                        <option value="F">Female</option>
                                    </select>
                                </div>
                            </div>



                            <div class="form-group col-lg-4 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Name of Representative</span></span>
                                    </label>
                                    <input type="text" runat="server" id="_otxtCRepName" class="form-control CH-Size-New"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCRepEmailAddress" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtCRepMobileNo" onkeypress="return onlyNumbers();" maxlength="11" />
                                </div>
                            </div>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Gender</span></span>
                                    </label>
                                    <select required runat="server" id="_otxtCRepGender" name="radGender" class="form-control CH-Size-New">
                                        <option value="M" selected>Male</option>
                                        <option value="F">Female</option>
                                    </select>
                                </div>
                            </div>


                        </div>





                        <%--<div class="col-md-6 mt-2 d-flex justify-content-center">
                    <div class="col-lg-12 mt-5">
                    <div class="col-lg-12 row">
                        <label style="color:red" runat="server" id="_oLblKindly">* Kindly declare you're gross.</label>
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

                                            <label class="input-txt input-txt-active">
                                                <span><span class="m-2"></span></span>
                                            </label>

                                            <input type="text" runat="server" class="form-control CH-Size-New my-auto" onkeypress="return onlyNumbers();" autocomplete="off" value="0.00" style="text-align: right" id="_oTxtBusinessIncome"
                                                onkeyup="LabelHidden(); calculateAmount();"
                                                oninput="this.reportValidity(); calculateAmount();"
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

                                            <label class="input-txt input-txt-active">
                                                <span><span class="m-2">Amount</span></span>
                                            </label>
                                            <input type="text" runat="server" class="form-control CH-Size-New" onkeypress="return onlyNumbers(this);" title="Salary" autocomplete="off" value="0.00" style="text-align: right" id="_oTxtSalary"
                                                onkeyup="LabelHidden(); calculateAmount();"
                                                onblur="SetDefault(); calculateAmount();formatSalary(this.value);"
                                                onfocus="ClearSalary();removeCommaSalary(this.value);">
                                            <input type="hidden" id="_oTxtHiddenSalary">
                                            <%--  <input  type="text"  runat="server" name="RentPerMonth" class="form-control CH-Size-New" id="Slide_02_RentPerMonth" oninput="this.reportValidity()" pattern="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" title="Currency" placeholder="0" style="text-align:right" maxlength="25" onblur="formatMoney(this.value);" onfocus="removeComma(this.value);" />
                        --%>
                        <%--</div>
                                    </div>


                                </div>
                                <div class="row m-0">
                                    <div class="form-group col-lg-7">Gross Income from Real Prop.</div>
                                    <div class="form-group col-lg-5">
                                        <div>

                                            <label class="input-txt input-txt-active">
                                                <span><span class="m-2">Amount</span></span>
                                            </label>
                                            <input type="text" runat="server" id="_oTxtPropertySale" title="PropertySale" onkeypress="return onlyNumbers(this);" class="form-control CH-Size-New" autocomplete="off" value="0.00" style="text-align: right"
                                                onkeyup="LabelHidden(); calculateAmount();"
                                                onblur="SetDefault(); calculateAmount();formatSales(this.value);"
                                                onfocus="ClearProperty();removeCommaSales(this.value);">
                                            <input type="hidden" id="_oTxtHiddenPropertySale">
                                        </div>
                                    </div>


                                </div>
                                <div class="row">
                                    <div class="my-auto mx-2">Should we deliver your Documents (P250.00)? </div>

                                    <div class="align-items-center row m-1">
                                        <input type="checkbox" id="_oRadioPickup" onclick="calculateAmount();" name="CourierServices" class="form-control CH-Size-New my-auto mx-2" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="Pickup">
                                        <div class="m-0 font-weight-bold text-primary my-auto mx-2">Yes</div>
                                        <input type="hidden" runat="server" id="_oTxtHiddenDelivery">
                                        <input type="hidden" runat="server" id="_oTxtHiddenBasicAmount">
                                        <input type="hidden" runat="server" id="_oTxtHiddenTotAmount">
                                    </div>

                                </div>
                                
                                    <div class="row col-lg-12 d-flex justify-content-end">

                                        <div class="form-group font-weight-bold align-content-center col">Amount to Pay </div>
                                 
                                    <input type="text" runat="server" id="AmountToPay"  class="form-control CH-Size-New col-lg-7 my-3" autocomplete="off" value="0.00" placeholder="0.00" style="text-align: right; background: none; font-size: x-large; height: 50px" readonly="readonly">
                                    <input type="hidden" runat="server" id="_oTxtHiddenAmountDue">
                                    <input type="hidden" runat="server" id="_oTxtHiddenPenalty">

                                        </div> 


                                <div class=" d-flex justify-content-center">
                
                        <div class="col-md-12 row d-flex justify-content-center">
                            
                        
                        <button name="btnPayLayte" runat="server"  id="_oPayLayter" type="submit" class="btn btn-primary col-md-2 col-lg-4 m-2 btn-sm"> Reset </button>
                        <input name="btnPayNow" id="_oBtnPayNow" type="submit" onclick="PayNow('PayNow', 'PaymentInd')" class="btn btn-primary col-md-2 col-lg-4 m-2 btn-sm"  value="Proceed to Payment">
                                                  
                        </div>
                 
                    </div>

                                </div>

                        </div>

                </div>
    </div>
        </div>--%>

                    </div>

                </div>
                <script>
                    
                    function NextTab() {
                        var tab1 = document.getElementById("tab1-tab");
                        var tab2 = document.getElementById("tab2-tab");
                        if (tab2.hasAttribute("data-toggle")) {
                            var tabp1 = document.getElementById("tab1");
                            var tabp2 = document.getElementById("tab2");
                            tabp2.classList.add("active");
                            tabp1.classList.remove("active")
                            tab2.classList.add("active");
                            tabp2.classList.add("show");
                            tab1.classList.remove("active")
                        }
                        else {
                            tab2.setAttribute("data-toggle", "tab");
                            tab2.setAttribute("href", "#tab2");
                            tab2.classList.add("active");
                            tab1.classList.remove("active");
                        }
                        ;
                        // Setting new attributes
                        
                    };
            </script>                
            <%--<div class="m-2 col-12 d-flex justify-content-center align-content-center">
                            <button type="submit" class="btn btn-success btn-sm" runat="server" onclick="NextTab();return false" data-toggle="tab" href="#tab2" >Next &nbsp  <i class="fa fa-arrow-alt-circle-right icon"></i>&nbsp</button>                                                    
                        </div>   --%>                       
            </div>
            

            <%--<div class="tab-pane fade" id="tab3" role="tabpanel" aria-labelledby="profile-tab" style="background-color: #ffffff">

                </div>--%>
            <div class="tab-pane fade" id="tab2" role="tabpanel" aria-labelledby="profile-tab" style="background-color: #ffffff">
                <div class="mx-1 d-flex justify-content-center">
                    <div class="row col-lg-12">


                        <%--<div class="form-group col-lg-12 mb-4">
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 CH-Size-New"  />
               &nbsp  I am getting this cedula for myself. 
                        
                    </div>--%>

                        <div class="col-lg-12 row">

                            <%--<div class="form-group col-lg-8 mb-4">
                       <%-- <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 CH-Size-New"  />--%>
                            <%--&nbsp  I am getting this cedula for myself. 
                        
                    </div>--%>

                            <div class="p-1 col-12 mb-2">
                                <p class="m-2 font-weight-bold text-primary">Business Details</p>
                            </div>

                            <p style="font-size: 14px">Area of Business Establishment : &nbsp</p>
                            <div class="form-group col-md-2 ">

                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Area </span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" onfocus="(this.type='number');" min="0" id="_otxtArea" />
                                </div>
                            </div>
                            <p style="font-size: 14px">Capitalization: &nbsp</p>
                            <div class="form-group col-lg-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Amount</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" onfocus="(this.type='number');" min="0" id="_otxtTotNoCapital"  />
                                </div>
                            </div>

                        <div class="col-lg-12 row">
                            
                            <p style="font-size: 14px">No. of Employees : &nbsp</p>
                            <div class="form-group col-md-2 ">

                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Male </span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" onfocus="(this.type='number');" min="0" id="_otxtTotMale" />
                                </div>
                            </div>
                            <div class="form-group col-md-2 ">

                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Female </span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" onfocus="(this.type='number');" min="0" id="_otxtTotFemale"/>
                                </div>
                            </div>
                            <div class="form-group col-md-2 ">

                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Total </span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtTotNoEmployees" disabled/>
                                </div>
                            </div>

                        </div>
                        </div>
                        <div class="col-lg-12 row ml-2">
                            <div class=" row">
                                <p style="font-size: 14px" class="">Place is Rented? &nbsp</p>
                                <input type="checkbox" runat="server" class="m-1" onchange="Rented();" id="_cbrent"/>
                            </div>
                        </div>
                        <div class="col-lg-12 row" id="_opnLessorName" style="display:none">
                            <div class="form-group col-lg-6 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Name of Lessor</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtLessorName" />
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Contact No.</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New"  id="_otxtLessorMobileNo" onkeypress="return onlyNumbers();" min="0"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Monthly Rent</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtLessorMonthlyRent" onfocus="(this.type='number');" min="0" />
                                </div>
                            </div>
                            <div class="form-group col-lg-6 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Address of Lessor</span></span>
                                    </label>
                                    <textarea runat="server" class="form-control CH-Size-New" id="_otxtLessorAddress" onclick="getpickaddress = this.id;PickAddress('Address of Lessor');" data-toggle="modal" data-target="#AddressModal" data-ticket-type="standard-access"></textarea>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Citizenship</span></span>
                                    </label>                                    
                                    <select required runat="server" id="_otxtLessorCitizenship" name="radCitizenship" class="form-control CH-Size-New">
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
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Gender</span></span>
                                    </label>
                                    <select required runat="server" id="_otxtLessorGender" class="form-control CH-Size-New">
                                <option value="M" selected>Male</option>
                                <option value="F">Female</option>
                                        </select> 
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Tax Declaration of Building</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtLessorTaxDec"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Building Permit No.</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New"  id="_otxtLessorBuildingNo"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-3 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Email Address</span></span>
                                    </label>
                                    <input type="email" class="form-control CH-Size-New" runat="server" id="_otxtLessorEmail"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12 row">

                            <%--<div class="form-group col-lg-8 mb-4">
                       <%-- <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 CH-Size-New"  />--%>
                            <%--&nbsp  I am getting this cedula for myself. 
                        
                    </div>--%>


                            <div class="p-1 col-12 mb-2 row">
                                <div class="p-1 col-lg-6 row">
                                    <div class="p-1 col-12 mb-2">
                                        <p class="m-2 font-weight-bold text-primary">Business Activity</p>
                                    </div>
                                    <div class="form-group col-md-12 ">
                                        
                                            <div>
                                                <label class="input-txt input-txt-active2">
                                                    <span><span class="m-2">Has Delivery Services? </span></span>
                                                </label>
                                                <%--<input type="text" runat="server" class="form-control CH-Size-New"  id="_otxtBusHasDelivery" />--%>
                                                <select required runat="server" id="_otxtBusHasDelivery" name="radGender" class="form-control CH-Size-New">
                                                    <option value="1" selected>Yes</option> 
                                                    <option value="0">No</option>
                                                </select>
                                            </div>
                                        
                                    </div>      
                                    <div class="form-group col-md-12 ">
                                        

                                            <div>
                                                <label class="input-txt input-txt-active2">
                                                    <span><span class="m-2">Branch or Main Office? </span></span>
                                                </label>
                                                <%--<input type="text" runat="server" class="form-control CH-Size-New" id="_otxtBusBranchMain" />--%>
                                                <select required runat="server" id="_otxtBusBranchMain" name="radGender" class="form-control CH-Size-New">
                                                    <option value="SA" selected>Sample</option>
                                                    <option value="EX">Example</option>
                                                </select>
                                            </div>
                                        
                                    </div>
                                    <div class="form-group col-md-12 ">
                                        

                                            <div>
                                                <label class="input-txt input-txt-active2">
                                                    <span><span class="m-2">Brief Description of your Business </span></span>
                                                </label>
                                                <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtBusDesc"/>
                                            </div>
                                        
                                    </div>

                                </div>
                                <div class="p-1 col-lg-6 row">
                                    <div class="p-1 col-12 mb-2">
                                        <p class="m-2 font-weight-bold text-primary">Upload the following attachments: </p>
                                    </div>
                                    
                                    <div class="form-group col-md-12 ">

                                        <div>
                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Image of your commodities: 3 </span></span>
                                            </label>
                                            <input type="file" runat="server" class="form-control CH-Size-New"  style="font-size:11px !Important;padding-top:7px !Important" id="_otxtBusImgCommodities"/>
                                        </div>


                                    </div>
                                    <div class="form-group col-md-12 ">

                                        <div>
                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Image of your location: 3 {front, facede, billboard} </span></span>
                                            </label>
                                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size:11px !Important;padding-top:7px !Important" id="_otxtBusImgLoc"/>
                                        </div>

                                    </div>
                                    <div class="form-group col-md-12 ">

                                        <div>
                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Image of Owner: front ID, Government ID </span></span>
                                            </label>                                            
                                            <input type="file" runat="server" class="form-control CH-Size-New" style="font-size:11px !Important;padding-top:7px !Important" id="_otxtBusImgID"/>

                                        </div>
                                        
                                    </div>
                                </div>

                                <div class="p-1 col-lg-6 mb-2 row">                                    
                                    <div class="form-group col-md-12 ">
                                        
                                            <div>
                                                <label class="input-txt input-txt-active2">
                                                    <span><span class="m-2">Remarks </span></span>
                                                </label>
                                                <textarea type="text" runat="server" class="form-control CH-Size-New"  id="_otxtRemarks" />
                                            </div>
                                        
                                    </div>                                          
                                </div>

                            </div>
                        </div>
                        <div class="m-2 col-12 d-flex justify-content-center align-content-center">
                            
                            <%--<a  class="btn btn-primary btn-sm btnPrevious" runat="server" id="prv" data-toggle="tab" href="#tab1" role="tab"><i class="fa fa-arrow-alt-circle-left icon"> &nbsp Previous </i></a>
                            &nbsp &nbsp &nbsp
                            <button type="button" class="btn btn-success btn-sm" runat="server" id="_obtn_Save"  >Submit &nbsp  <i class="fa fa-check-circle icon"></i>&nbsp</button>  --%>                                                  
                        </div>                   
                            
                    </div>
                </div>                                               
                <%--<div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab"></div>--%>
            </div>       
               
    </div>  
    <script>
        function counter()
        {
            var list = document.getElementsByClassName("tab-PN")[0];
            var i;
            var counter = 0;
            for (i = 0; i < list.getElementsByTagName("LI").length; i++) {
                var now = list.getElementsByTagName("LI")[i];
                if (now.getElementsByTagName("A")[0].classList.contains('active')) {                    
                    counter = i;
                }
            }
            if (counter == 0) {
                document.getElementById("_obtn_Prev").disabled = true;
                document.getElementById("_obtn_Subm").disabled = true;
                document.getElementById("_obtn_Next").disabled = false;
            }
            if (counter == (list.getElementsByTagName("LI").length - 1)) {
                document.getElementById("_obtn_Prev").disabled = false;
                document.getElementById("_obtn_Subm").disabled = false;
                document.getElementById("_obtn_Next").disabled = true;
            }
            if (counter < (list.getElementsByTagName("LI").length - 1) && counter > 0) {
                document.getElementById("_obtn_Prev").disabled = false;
                document.getElementById("_obtn_Subm").disabled = true;
                document.getElementById("_obtn_Next").disabled = false;
            }
            
        }
        
    </script>
     <div class="m-2 col-12 d-flex justify-content-center align-content-center">
         <button class="btn-primary btn" onclick="myFunction(-1);counter();return false" disabled id="_obtn_Prev"><i class="fa fa-arrow-alt-circle-left icon"></i>&nbsp Prev &nbsp </button> &nbsp &nbsp
                <button class="btn-primary btn" onclick="myFunction(1);counter();return false" id="_obtn_Next">Next &nbsp<i class="fa fa-arrow-alt-circle-right icon"></i>&nbsp</button>   &nbsp &nbsp
                            <button type="submit" class="btn btn-success btn-sm" runat="server" onclick="NextTab();return false" data-toggle="tab" href="#tab2" disabled id="_obtn_Subm">Submit &nbsp &nbsp <i class="fa fa-check-circle icon"></i>&nbsp</button>                                                    
                        </div>   
      
    <div id="AddressModal" class="modal fade">
        <div class="modal-dialog " role="document">
          <div class="modal-content d-flex justify-content-center align-content-center">
            <div class="modal-header">
              <h4 class="modal-title" id="_otxtPickupAddTitle">Business Address</h4>
              <button type="submit" class="close" data-dismiss="modal" aria-label="Close" id="_obtnCloseModal">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
                
                <div class="form-group">
                    <div class="col-lg-12">
                        <div class="form-group col-md-12 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Block No./Street No. </span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" id="_otxtPickupStreetNo" />
                            </div>
                        </div>
                    </div>                    
                    <div class="col-lg-12">
                        <div class="form-group col-md-12 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Barangay <span style="color:red;">*</span></span></span>
                                </label>                                
                                <asp:DropDownList runat="server" class="form-control CH-Size-New" id="_otxtPickupBarangay">  
                                <asp:listitem text="Bagbaguin" value="BA"></asp:listitem>      
                                    <asp:listitem text="Sta Lucia" value="SL"></asp:listitem>                                    
                                </asp:DropDownList>   
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group col-md-12 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">District </span></span>
                                </label>                                
                                <asp:DropDownList runat="server" class="form-control CH-Size-New" id="_otxtPickupDistrict">  
                                <asp:listitem text="Sample" value="SA"></asp:listitem>      
                                    <asp:listitem text="Example" value="EX"></asp:listitem>                                    
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group col-md-12 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Municipality/City <span style="color:red;">*</span></span></span>
                                </label>                                
                                <asp:DropDownList runat="server" class="form-control CH-Size-New" id="_otxtPickupMuniCity">  
                                <asp:listitem text="Cainta" value="CA"></asp:listitem>      
                                    <asp:listitem text="Sta Maria" value="ST"></asp:listitem>                                    
                                </asp:DropDownList>      
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group col-md-12 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Province <span style="color:red;">*</span></span></span>
                                </label>                                                                
                                <asp:DropDownList runat="server" class="form-control CH-Size-New" id="_otxtPickupProvince">    
                                    <asp:listitem text="Rizal" value="RI"></asp:listitem>      
                                    <asp:listitem text="Bulacan" value="BU"></asp:listitem>                                    
                                </asp:DropDownList>                              
                            </div>
                        </div>
                    </div>
                    <div class="m-2 col-12 d-flex justify-content-center align-content-center">                         
                            <button type="button" class="btn btn-success btn-sm" runat="server" onclick="GetAddress();">Submit &nbsp  <i class="fa fa-check-circle icon"></i>&nbsp</button>                                                    
                        </div>

                    <%--<div class="col-lg-12">
                        <div class="form-group col-md-6 ">
                            <div>
                                <label class="input-txt input-txt-active2">
                                    <span><span class="m-2">Zipcode</span></span>
                                </label>
                                <input type="text" runat="server" class="form-control CH-Size-New" id="Text5" />
                            </div>
                        </div>
                    </div>--%>

                </div>              
  
               <div class="text-center">
                 
              
                   
                     </div>
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
    
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
        function addHyphen(element) {
            let ele = document.getElementById(element.id);
            ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

            let finalVal = ele.match(/.{1,3}/g).join('-');
            document.getElementById(element.id).value = finalVal;
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
        <script>
            function OwnershipSelection(val) {                
                var va = val.value;                
                if (va === "S") {
                    document.getElementById("_olblDTISEC").innerHTML = "DTI Registration No.";
                    document.getElementById("_olblDTISECDate").innerHTML = "DTI Registration Date";
                    document.getElementById("_olblTpTittle-1").innerHTML = "Taxpayer's Information (Single)";
                    document.getElementById("_odvTaxPayer-1").style.display = "flex";
                    document.getElementById("_odvTaxPayer-2").style.display = "none";
                    document.getElementById("_odvCorporation").style.display = "none";
                }
                if (va === "P") {
                    document.getElementById("_olblDTISEC").innerHTML = "DTI Registration No.";
                    document.getElementById("_olblDTISECDate").innerHTML = "DTI Registration Date";
                    document.getElementById("_olblTpTittle-1").innerHTML = "Taxpayer's Information (Partnership) Owner - 1";
                    document.getElementById("_olblTpTittle-2").innerHTML = "Taxpayer's Information (Partnership) Owner - 2";
                    document.getElementById("_odvTaxPayer-1").style.display = "flex";
                    document.getElementById("_odvTaxPayer-2").style.display = "flex";
                    document.getElementById("_odvCorporation").style.display = "none";
                }                
                if (va === "C") {
                    document.getElementById("_olblDTISEC").innerHTML = "SEC Registration No.";
                    document.getElementById("_olblDTISECDate").innerHTML = "SEC Registration Date";
                    document.getElementById("_olblCorpTittle").innerHTML = "Taxpayer's Information (Corporation)";
                    document.getElementById("_odvTaxPayer-1").style.display = "none";
                    document.getElementById("_odvTaxPayer-2").style.display = "none";
                    document.getElementById("_odvCorporation").style.display = "flex";
                }
                if (va === "A") {
                    document.getElementById("_olblDTISEC").innerHTML = "SEC Registration No.";
                    document.getElementById("_olblDTISECDate").innerHTML = "SEC Registration Date";
                    document.getElementById("_olblCorpTittle").innerHTML = "Taxpayer's Information (Association)";
                    document.getElementById("_odvTaxPayer-1").style.display = "none";
                    document.getElementById("_odvTaxPayer-2").style.display = "none";
                    document.getElementById("_odvCorporation").style.display = "flex";
                }
                return true;
            }

            function Rented() {                
                if (document.getElementById("_cbrent").checked == true) {                    
                    document.getElementById("_opnLessorName").style.display = "flex";
                }
                if (document.getElementById("_cbrent").checked == false) {
                    document.getElementById("_opnLessorName").style.display = "none";
                }               
                
                
            }

            function GetAddress()
            {                
                var oldAddress = document.getElementById(getpickaddress).value;
                var StreetNo = (document.getElementById("_otxtPickupStreetNo").value ? document.getElementById("_otxtPickupStreetNo").value + ", " : "");
                var District = ($("#<%=_otxtPickupDistrict.ClientID%> option:selected").text() ? $("#<%=_otxtPickupDistrict.ClientID%> option:selected").text() + ", " : "");
                var Barangay = ($("#<%=_otxtPickupBarangay.ClientID%> option:selected").text() ? $("#<%=_otxtPickupBarangay.ClientID%> option:selected").text() + ", " : "");
                var MuniCity = ($("#<%=_otxtPickupMuniCity.ClientID%> option:selected").text() ? $("#<%=_otxtPickupMuniCity.ClientID%> option:selected").text() + ", " : "");
                var Province = ($("#<%=_otxtPickupProvince.ClientID%> option:selected").text() ? $("#<%=_otxtPickupProvince.ClientID%> option:selected").text() + "" : "");
                if (Barangay && MuniCity && Province) 
                {

                    document.getElementById(getpickaddress).value = StreetNo + Barangay + District + MuniCity + Province;
                    if (document.getElementById(getpickaddress).value) {

                    }
                    else
                    {
                    
                        document.getElementById(getpickaddress).value = oldAddress;
                        
                    }
                    document.getElementById("_obtnCloseModal").click();
                }
                else {
                    alert('Please complete the following required(*) fields');
                }
                


            }            
            var getpickaddress = "";
            function PickAddress(value)
            {
                document.getElementById("_otxtPickupStreetNo").value = "";
                document.getElementById("_otxtPickupBarangay").value = "";
                document.getElementById("_otxtPickupMuniCity").value = "";
                document.getElementById("_otxtPickupProvince").value = "";
                document.getElementById("_otxtPickupDistrict").value = "";
                document.getElementById("_otxtPickupAddTitle").innerText = value;
            }
            
        </script>        

</asp:Content>


