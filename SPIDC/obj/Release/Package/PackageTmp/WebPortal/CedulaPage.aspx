<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="CedulaPage.aspx.vb" Inherits="SPIDC.CedulaPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
       <meta charset="utf-8">





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



        
       <div aria-label="progress" class="step-indicator">
                 <ul class="steps">
                     <li class="active"> <span class="sr-only"></span></li>
                     <li><span class="sr-only"></span></li>
                     <li><span class="sr-only"></span></li>
                     <li><span class="sr-only"></span></li>
                  </ul>
             </div>


    </div>


    <div class="container card ">
        <div class="form-row form mt-4 mb-2">
            <div class="col-lg-12">

                <h6 class="m-0 font-weight-bold text-primary mb-3">Cedula (Individual)</h6>

            </div>

        </div>

        <div class="form-row form">

     

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
                    

                    if (document.getElementById('<%=CedulaIndi.ClientID%>').checked == true) {
                       
                        document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').disabled = false;
                        

                    } else {
                        document.getElementById('<%=_oTxtSalary.ClientID%>').disabled = true;
                        document.getElementById('<%=_oTxtPropertySale.ClientID%>').disabled = true;                                     
                    };
                };

                function numberWithCommas(x) {
                    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                };

                function removeCommaBusinessIncome(x) {
                    document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = x.replace(/,/g, '');


                };

                function formatBusinessIncome(val) {

                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: 'PHP',
                    });

                    var x = formatter.format(val);
                    x = x.split('PHP').join('');
                    x = x.replace(/\s/g, '');
                    x = x.replace('₱', '');
                    document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = x;
                };

                function removeCommaSalary(x) {
                    document.getElementById('<%=_oTxtSalary.ClientID%>').value = x.replace(/,/g, '');
                    

                 };

                function formatSalary(val) {

                     var formatter = new Intl.NumberFormat('en-US', {
                         style: 'currency',
                         currency: 'PHP',
                     });

                     var x = formatter.format(val);
                     x = x.split('PHP').join('');
                     x = x.replace(/\s/g, '');
                     x = x.replace('₱', '');
                     document.getElementById('<%=_oTxtSalary.ClientID%>').value = x;
                    
                };

                function formatHeight(val) {

                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: 'PHP',
                    });

                    var x = formatter.format(val);
                    if (x > 250)
                        x = 250;
                    x = x.split('PHP').join('');
                    x = x.replace(/\s/g, '');
                    x = x.replace('₱', '');
                    document.getElementById('<%=_oTxtHeight.ClientID%>').value = x;
                };

                function formatWeight(val) {

                    var formatter = new Intl.NumberFormat('en-US', {
                        style: 'currency',
                        currency: 'PHP',
                    });

                    var x = formatter.format(val);
                    if (x > 200)
                        x = 200;
                    x = x.split('PHP').join('');
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
                          currency: 'PHP',
                      });

                      var x = formatter.format(val);
                      x = x.split('PHP').join('');
                      x = x.replace(/\s/g, '');
                      x = x.replace('₱', '');
                      document.getElementById('<%=_oTxtPropertySale.ClientID%>').value = x;
                 };


            </script>

               <div class="form-group col row" style ="display:none">
                        <input type="radio" runat="server" id="CedulaIndi" onclick="InitCedulaType();" onchange="InitCedulaType();"  name="Cedula" class="form-control CH-Size" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" >
                        <div class="m-0 font-weight-bold text-primary" >Individual</div>
               </div>
               
            <div class="form-group col row"style ="display:none">
                        <input type="radio"  runat="server"  id="CedulaCorp" onclick="InitCedulaType();"  name="Cedula" class="form-control CH-Size" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" >
                        <div class="m-0 font-weight-bold text-primary" >Corporation
                        </div>
               </div>

             <div class="form-group col row my-auto ml-2">

            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="ChckedChanged" cssclass ="m-1 CH-Size"  />
               &nbsp  I am getting this cedula for myself. 
             <div class="my-auto" style="margin: 8px 8px 8px 8px"></div>
        </div>

        </div>

       




        <div class="form-row form mt-4">
            <div class="form-group col-md-4 ">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">First Name </span></span>
                    </label>
                        <input  type="text" required runat="server" class="form-control ch-size" onkeypress="return onlyLetters();" name="FirstName" id="_oTxtFirstName"  placeholder="First Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                     </div>
            </div>

            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Middle Name</span></span>
                    </label>
                    <input  type="text" required runat="server" class="form-control ch-size" name="MiddleName" onkeypress="return onlyLetters();" id="_oTxtMiddleName"  placeholder="Middle Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Middle Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                </div>
            </div>

            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Last Name</span></span>
                    </label>
                    <input  type="text" required runat="server" class="form-control ch-size" name="LastName" onkeypress="return onlyLetters();" id="_oTxtLastName"  placeholder="Last Name" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="Last Name"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="25" />
                </div>

                <!--input required="" type="text" name="txtBirthDate" class="form-control CH-Size" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
        </div>
        <div class="form-row form">
            <div class="form-group col-md-12">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Address</span></span>
                    </label>
                    <textarea class="form-control CH-Size" placeholder="Address" runat="server" id="_oTxtAddress" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); "></textarea>
                </div>

            </div>
        </div>

        <div class="form-row form">

            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Citizenship</span></span>
                    </label>
                    <select required runat="server" id="radCitizenship" name="radCitizenship" class="form-control CH-Size">
                        <option value="" disabled selected>Citizenship</option>
                        <option value='AF'>Afghan</option>
                        <option value='AL'>Albanian</option>
                        <option value='DZ'>Algerian</option>
                        <option value='US'>American</option>
                        <option value='AS'>American Samoan</option>
                        <option value='AD'>Andorran</option>
                        <option value='AO'>Angolan</option>
                        <option value='AI'>Anguillan</option>
                        <option value='AQ'>Antarctican</option>
                        <option value='AG'>Antigua and Barbuda national</option>
                        <option value='AN'>Antillean</option>
                        <option value='AR'>Argentinian</option>
                        <option value='AM'>Armenian</option>
                        <option value='AW'>Aruban</option>
                        <option value='AU'>Australian</option>
                        <option value='AT'>Austrian</option>
                        <option value='AZ'>Azerbaijani</option>
                        <option value='BS'>Bahamian</option>
                        <option value='BH'>Bahraini</option>
                        <option value='BD'>Bangladeshi</option>
                        <option value='BB'>Barbadian</option>
                        <option value='LS'>Basotho</option>
                        <option value='BY'>Belarusian</option>
                        <option value='BE'>Belgian</option>
                        <option value='BZ'>Belizean</option>
                        <option value='BJ'>Beninese</option>
                        <option value='BM'>Bermudian</option>
                        <option value='BT'>Bhutanese</option>
                        <option value='BO'>Bolivian</option>
                        <option value='BA'>Bosnia and Herzegovina national</option>
                        <option value='BW'>Botswanan</option>
                        <option value='BV'>Bouvet Island</option>
                        <option value='BR'>Brazilian</option>
                        <option value='IO'>British Indian Ocean Territory</option>
                        <option value='VG'>British Virgin Islander</option>
                        <option value='UK'>Briton</option>
                        <option value='BN'>Bruneian</option>
                        <option value='BG'>Bulgarian</option>
                        <option value='BF'>Burkinabe</option>
                        <option value='MM'>Burmese</option>
                        <option value='BI'>Burundian</option>
                        <option value='KH'>Cambodian</option>
                        <option value='CM'>Cameroonian</option>
                        <option value='CA'>Canadian</option>
                        <option value='CV'>Cape Verdean</option>
                        <option value='KY'>Caymanian</option>
                        <option value='CF'>Central African</option>
                        <option value='TD'>Chadian</option>
                        <option value='CL'>Chilean</option>
                        <option value='CN'>Chinese</option>
                        <option value='CX'>Christmas Islander</option>
                        <option value='CC'>Cocos Islander</option>
                        <option value='CO'>Colombian</option>
                        <option value='KM'>Comorian</option>
                        <option value='CG'>Congolese</option>
                        <option value='CD'>Congolese</option>
                        <option value='CK'>Cook Islander</option>
                        <option value='CR'>Costa Rican</option>
                        <option value='HR'>Croat</option>
                        <option value='CU'>Cuban</option>
                        <option value='CY'>Cypriot</option>
                        <option value='CZ'>Czech</option>
                        <option value='DK'>Dane</option>
                        <option value='DJ'>Djiboutian</option>
                        <option value='DO'>Dominican</option>
                        <option value='DM'>Dominican</option>
                        <option value='TL'>East Timorese</option>
                        <option value='EC'>Ecuadorian</option>
                        <option value='EG'>Egyptian</option>
                        <option value='AE'>Emirian</option>
                        <option value='GQ'>Equatorial Guinean</option>
                        <option value='ER'>Eritrean</option>
                        <option value='EE'>Estonian</option>
                        <option value='ET'>Ethiopian</option>
                        <option value='FO'>Faeroese</option>
                        <option value='FK'>Falkland Islander</option>
                        <option value='FJ'>Fiji Islander</option>
                        <option value='PH'>Filipino</option>
                        <option value='FI'>Finn</option>
                        <option value='FR'>French</option>
                        <option value='TF'>French Southern Territories</option>
                        <option value='GA'>Gabonese</option>
                        <option value='GM'>Gambian</option>
                        <option value='GE'>Georgian</option>
                        <option value='DE'>German</option>
                        <option value='GH'>Ghanaian</option>
                        <option value='GI'>Gibraltarian</option>
                        <option value='GR'>Greek</option>
                        <option value='GL'>Greenlander</option>
                        <option value='GD'>Grenadian</option>
                        <option value='GP'>Guadeloupean</option>
                        <option value='GU'>Guamanian</option>
                        <option value='GT'>Guatemalan</option>
                        <option value='GF'>Guianese</option>
                        <option value='GW'>Guinea-Bissau national</option>
                        <option value='GN'>Guinean</option>
                        <option value='GY'>Guyanese</option>
                        <option value='HT'>Haitian</option>
                        <option value='HM'>Heard Island and McDonald Islands</option>
                        <option value='HN'>Honduran</option>
                        <option value='HK'>Hong Kong Chinese</option>
                        <option value='HU'>Hungarian</option>
                        <option value='IS'>Icelander</option>
                        <option value='IN'>Indian</option>
                        <option value='ID'>Indonesian</option>
                        <option value='IR'>Iranian</option>
                        <option value='IQ'>Iraqi</option>
                        <option value='IE'>Irish</option>
                        <option value='IL'>Israeli</option>
                        <option value='IT'>Italian</option>
                        <option value='CI'>Ivorian</option>
                        <option value='JM'>Jamaican</option>
                        <option value='JP'>Japanese</option>
                        <option value='JO'>Jordanian</option>
                        <option value='KZ'>Kazakh</option>
                        <option value='KE'>Kenyan</option>
                        <option value='KI'>Kiribatian</option>
                        <option value='KW'>Kuwaiti</option>
                        <option value='KG'>Kyrgyz</option>
                        <option value='LA'>Lao</option>
                        <option value='LV'>Latvian</option>
                        <option value='LB'>Lebanese</option>
                        <option value='LR'>Liberian</option>
                        <option value='LY'>Libyan</option>
                        <option value='LI'>Liechtensteiner</option>
                        <option value='LT'>Lithuanian</option>
                        <option value='LU'>Luxembourger</option>
                        <option value='MO'>Macanese</option>
                        <option value='MK'>Macedonian</option>
                        <option value='YT'>Mahorais</option>
                        <option value='MG'>Malagasy</option>
                        <option value='MW'>Malawian</option>
                        <option value='MY'>Malaysian</option>
                        <option value='MV'>Maldivian</option>
                        <option value='ML'>Malian</option>
                        <option value='MT'>Maltese</option>
                        <option value='MH'>Marshallese</option>
                        <option value='MQ'>Martinican</option>
                        <option value='MR'>Mauritanian</option>
                        <option value='MU'>Mauritian</option>
                        <option value='MX'>Mexican</option>
                        <option value='FM'>Micronesian</option>
                        <option value='MD'>Moldovan</option>
                        <option value='MC'>Monegasque</option>
                        <option value='MN'>Mongolian</option>
                        <option value='ME'>Montenegrian</option>
                        <option value='MS'>Montserratian</option>
                        <option value='MA'>Moroccan</option>
                        <option value='MZ'>Mozambican</option>
                        <option value='NA'>Namibian</option>
                        <option value='NR'>Nauruan</option>
                        <option value='NP'>Nepalese</option>
                        <option value='NL'>Netherlander</option>
                        <option value='NC'>New Caledonian</option>
                        <option value='NZ'>New Zealander</option>
                        <option value='NI'>Nicaraguan</option>
                        <option value='NG'>Nigerian</option>
                        <option value='NE'>Nigerien</option>
                        <option value='NU'>Niuean</option>
                        <option value='NF'>Norfolk Islander</option>
                        <option value='KP'>North Korean</option>
                        <option value='MP'>Northern Mariana Islander</option>
                        <option value='NO'>Norwegian</option>
                        <option value='OM'>Omani</option>
                        <option value='PK'>Pakistani</option>
                        <option value='PW'>Palauan</option>
                        <option value='PA'>Panamanian</option>
                        <option value='PG'>Papua New Guinean</option>
                        <option value='PY'>Paraguayan</option>
                        <option value='PE'>Peruvian</option>
                        <option value='PN'>Pitcairner</option>
                        <option value='PL'>Pole</option>
                        <option value='PF'>Polynesian</option>
                        <option value='PT'>Portuguese</option>
                        <option value='PR'>Puerto Rican</option>
                        <option value='QA'>Qatari</option>
                        <option value='RE'>Reunionese</option>
                        <option value='RO'>Romanian</option>
                        <option value='RU'>Russian</option>
                        <option value='RW'>Rwandan</option>
                        <option value='EH'>Sahrawi</option>
                        <option value='SH'>Saint Helenian</option>
                        <option value='KN'>Saint Kitts and Nevis national</option>
                        <option value='LC'>Saint Lucian</option>
                        <option value='PM'>Saint Pierre and Miquelon national</option>
                        <option value='SV'>Salvadorian</option>
                        <option value='WS'>Samoan</option>
                        <option value='SM'>San Marinese</option>
                        <option value='ST'>São Toméan</option>
                        <option value='SA'>Saudi Arabian</option>
                        <option value='SN'>Senegalese</option>
                        <option value='RS'>Serbian</option>
                        <option value='SC'>Seychellois</option>
                        <option value='SL'>Sierra Leonean</option>
                        <option value='SG'>Singaporean</option>
                        <option value='SK'>Slovak</option>
                        <option value='SI'>Slovene</option>
                        <option value='SB'>Solomon Islander</option>
                        <option value='SO'>Somali</option>
                        <option value='ZA'>South African</option>
                        <option value='GS'>South Georgia and the South Sandwich Islands</option>
                        <option value='KR'>South Korean</option>
                        <option value='ES'>Spaniard</option>
                        <option value='LK'>Sri Lankan</option>
                        <option value='SD'>Sudanese</option>
                        <option value='SR'>Surinamer</option>
                        <option value='SJ'>Svalbard and Jan Mayen</option>
                        <option value='SZ'>Swazi</option>
                        <option value='SE'>Swede</option>
                        <option value='CH'>Swiss</option>
                        <option value='SY'>Syrian</option>
                        <option value='TW'>Taiwanese</option>
                        <option value='TJ'>Tajik</option>
                        <option value='TZ'>Tanzanian</option>
                        <option value='TH'>Thai</option>
                        <option value='TG'>Togolese</option>
                        <option value='TK'>Tokelauan</option>
                        <option value='TO'>Tongan</option>
                        <option value='TT'>Trinidad and Tobago national</option>
                        <option value='TN'>Tunisian</option>
                        <option value='TR'>Turk</option>
                        <option value='TM'>Turkmen</option>
                        <option value='TC'>Turks and Caicos Islander</option>
                        <option value='TV'>Tuvaluan</option>
                        <option value='UG'>Ugandan</option>
                        <option value='UA'>Ukrainian</option>
                        <option value='UM'>United States Minor Outlying Islands</option>
                        <option value='UY'>Uruguayan</option>
                        <option value='VI'>US Virgin Islander</option>
                        <option value='UZ'>Uzbek</option>
                        <option value='VU'>Vanuatuan</option>
                        <option value='VA'>Vatican</option>
                        <option value='VE'>Venezuelan</option>
                        <option value='VN'>Vietnamese</option>
                        <option value='VC'>Vincentian</option>
                        <option value='WF'>Wallis and Futuna Islander</option>
                        <option value='YE'>Yemeni</option>
                        <option value='ZM'>Zambian</option>
                        <option value='ZW'>Zimbabwean</option>
                        <option value='AX'>Åland Islander</option>
                    </select>
                </div>

            </div>
            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Birthday</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size" required="" autocomplete="off" onfocus="(this.type='date')" placeholder="Birthday" runat="server" id="_oTxtBirthDate" onblur ="ComputeAge(this)">
                </div>

            </div>
            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Birth Place</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size" required="" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " autocomplete="off" placeholder="Birth Place" runat="server" id="_oTxtBirthPlace">
                </div>

            </div>

        </div>
        <div class="form-row form">

            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Gender</span></span>
                    </label>
                    <select  runat="server" id="radGender" name="radGender" class="form-control CH-Size">
                        <option value="" disabled selected>Gender</option>
                        <option value="M">Male</option>
                        <option value="F">Female</option>
                    </select>
                </div>

            </div>
            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Civil Status</span></span>
                    </label>
                    <select  runat="server" id="radCivilstat" class="form-control CH-Size">
                        <option value="" selected disabled>Select Civil Status</option>
                        <option value="Single">Single</option>
                        <option value="Married">Married</option>
                        <option value="Devorced">Devorced</option>
                        <option value="Separated">Separated</option>
                    </select>

                </div>

            </div>
            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Profession</span></span>
                    </label>

                    <select required id="radioProfession" class="form-control CH-Size" onchange="EnableDisable(this); GetBasic(_oChkNewBusiness); calculateAmount(); PassToHidden(this)">
                        <option value="" selected disabled>Select Profession</option>
                        <option value="Unemployed">Unemployed</option>
                        <option value="Dentist">Dentist</option>
                        <option value="Dietitian or Nutritionist">Dietitian or Nutritionist</option>
                        <option value="Optometrist">Optometrist</option>
                        <option value="Pharmacist">Pharmacist</option>
                        <option value="Physician">Physician</option>
                    </select>

                    <input type="hidden" runat="server" id="radProfession" />

                </div>
            </div>


        </div>
        <div class="form-row form">
            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Tin No.</span></span>
                    </label>                   
                    <input  type="text" required runat="server" class="form-control ch-size" name="TIN" id="_oTxtTIN" onkeypress="return onlyNumbers();" onkeyup="addHyphen(this)" placeholder="XXX-XXX-XXX-XXX" pattern="[\s 0-9 -]+" oninput="this.reportValidity()" title="TIN"  onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " maxlength="15" />
                </div>

            </div>
            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Height (cm.)</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="Height" step="0.01" min="0" max="250" runat="server" id="_oTxtHeight" onblur="formatHeight(this.value)" onkeypress="return onlyNumbers();">
                </div>

            </div>
            <div class="form-group col-md-4">
                <div>
                    <label class="input-txt input-txt-active">
                        <span><span class = "m-2">Weight (lbs.)</span></span>
                    </label>
                    <input type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="Weight" step="0.01" min="0" max="200" runat="server" id="_oTxtWeight" onblur="formatWeight(this.value)" onkeypress="return onlyNumbers();">
                </div>

                <!--input required="" type="text" name="txtBirthDate" class="form-control CH-Size" id="txtBirthDate" min="1900-01-01" max="2020-04-13" placeholder="Birth Date" onfocus="(this.type='date')"-->
            </div>
        </div>      
                
        <div class="form-row form ">
            <div class="">
                <div class="form-group col font-weight-bold">Income (Annual of Previous Year)</div>
                <div class="row m-0">

                    <div class="form-group col-4">
                        <div>

                            <label class="input-txt input-txt-active">
                                <span><span class = "m-2">
                                      </span></span>
                            </label>
                         
                            <input type="text" runat="server" class="form-control CH-Size my-auto" onkeypress="return onlyNumbers();" required="" autocomplete="off" value="0.00" style="text-align: right" id="_oTxtBusinessIncome" 
                                onkeyup="calculateAmount();"  
                                oninput="this.reportValidity(); calculateAmount();"   
                                onblur="SetDefault();formatBusinessIncome(this.value);"  
                                onfocus="ClearBusiness();removeCommaBusinessIncome(this.value);" />
                            <input type="hidden" id ="_oTxtHiddenBusinessIncome"/>
                        </div>
                    </div>
                    <div class="form-group col-5 my-auto">Business Income (Gross Sales)</div>
                    <div class="form-group col row">
                        <input type="checkbox" id ="_oChkNewBusiness" class="form-control CH-Size" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="No Work" onclick="GetBasic(this); calculateAmount()">
                        <div class="" style="margin: 8px 8px 8px 8px">New Business</div>
                        <input type="hidden" id ="_oTxtHiddenNewBusiness">
                    </div>
                </div>
                <div class="row m-0">
                    <div class="form-group col-4">
                        <div>

                            <label class="input-txt input-txt-active">
                                <span><span class = "m-2">Amount</span></span>
                            </label> 
                            <input type="text" runat="server" class="form-control CH-Size" required="" onkeypress="return onlyNumbers();" title="Salary" autocomplete="off" value="0.00" style="text-align: right" id="_oTxtSalary"
                                onkeyup="calculateAmount();" 
                                onblur="SetDefault(); calculateAmount();formatSalary(this.value);"  
                                onfocus="ClearSalary();removeCommaSalary(this.value);" >
                            <input type="hidden" id ="_oTxtHiddenSalary">
                           <%--  <input  type="text" required runat="server" name="RentPerMonth" class="form-control ch-size" id="Slide_02_RentPerMonth" oninput="this.reportValidity()" pattern="^\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$" title="Currency" placeholder="0" style="text-align:right" maxlength="25" onblur="formatMoney(this.value);" onfocus="removeComma(this.value);" />
               --%>
                        </div>
                    </div>
                    <div class="form-group col-6 my-auto ">Salary Wages from Profession</div>

                </div>
                <div class="row m-0">
                    <div class="form-group col-4">
                        <div>

                            <label class="input-txt input-txt-active">
                                <span><span class = "m-2">Amount</span></span>
                            </label>
                            <input  type="text" runat="server" id="_oTxtPropertySale" title="PropertySale" onkeypress="return onlyNumbers();" class="form-control CH-Size" required="" autocomplete="off" value="0.00" style="text-align: right" 
                                 onkeyup="calculateAmount();"  
                                onblur="SetDefault(); calculateAmount();formatSales(this.value);"  
                                onfocus="ClearProperty();removeCommaSales(this.value);" >
                            <input type="hidden" id ="_oTxtHiddenPropertySale">
                        </div>
                    </div>
                    <div class="form-group col-6 my-auto">Income from Sale of Real Property </div>

                </div>

            </div>
            <div class="container col-sm-5 justify-content-center">
                <div class="form-group font-weight-bold align-content-center">Amount to Pay </div>
                <div>
                    <h1 >
                      </h1>

                      <input  type="text" runat="server" id="AmountToPay" required=""  class="form-control CH-Size col-lg-12" autocomplete="off" value="0.00" placeholder="0.00" style="text-align: right; background:none;font-size:x-large; height:50px" readonly="readonly" >
                    <input type="hidden" runat="server" id ="_oTxtHiddenAmountDue">
                    <input type="hidden" runat="server" id ="_oTxtHiddenPenalty">
                   
                </div><div >
                <div class="row" style="display:none;">
                    <div class="my-auto mx-2">
                        Should we deliver your Documents (P250.00)?
                    </div>

            <div class="align-items-center row m-1">
                    <input type="checkbox" id="_oRadioPickup" onclick="calculateAmount();" name="CourierServices" class="form-control CH-Size my-auto mx-2" style="height: 20px; width: 20px; margin: 8px 0px 0px 8px" value="Pickup">
                    <div class="m-0 font-weight-bold text-primary my-auto mx-2">Yes</div>
                    <input type="hidden" id ="_oTxtHiddenDelivery">
                </div>

                
                                
            
            </div>
                <div class="row col-lg-12">

                    <div class="col row">
                        
                        <button name="btnPayLayte" runat="server"  id="_oPayLayter" type="submit" class="btn btn-primary btn-sm m-2"> Cancel </button>
                        <button name="btnPayNow" runat="server" id="_oPayNow" type="submit" class="btn btn-primary btn-sm col-6 mx-1 my-2" onclick="NextPage();">Proceed to Payment</button>
                    </div>                    
                </div>


            </div>
        </div>      
           

    </div>

    <script> //NARDO 20200505
        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if (charCode < 48 || charCode > 57)
                return false;

            return true;

        }

        function formatMoney(id,val) {

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
            if ((parseInt(DateMonthNow) == parseInt(BirthdayMonth) && parseInt(DateDayNow) < parseInt(BirthdayDay)))
            {             
              age = age - 1;
            }
            if (age < 18)

            {
                alert("Under 18 is not allowed");
                document.getElementById("<%=_oTxtBirthDate.ClientID%>").focus = true;
            }
        }

    </script>
    

    <script> //NARDO 20200505
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
            if (id.value == "Unemployed") {
                document.getElementById("<%=_oTxtSalary.ClientID%>").disabled = true;
                document.getElementById("<%=_oTxtSalary.ClientID%>").value = "";
            }
            else {
                if (document.getElementById('<%=CedulaCorp.ClientID%>').checked == false)
                    document.getElementById("<%=_oTxtSalary.ClientID%>").disabled = false;
                document.getElementById("<%=_oTxtSalary.ClientID%>").value = "0.00";
               
            }
            
                
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
         function GetBasic(id)
         {
             if (id.checked == true) {
                 document.getElementById('_oTxtHiddenNewBusiness').value = 100;
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').disabled = true;
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = "";
             }
             else
             {
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

         function PassToHidden(id)
         {
             document.getElementById('<%=radProfession.ClientID%>').value = document.getElementById('radioProfession').value;
         }

         function calculateAmount() {
             var Bus = parseFloat(document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value.replace(/,/g, ''));
             var Sal = parseFloat(document.getElementById('<%=_oTxtSalary.ClientID%>').value.replace(/,/g, ''));
             var RP = parseFloat(document.getElementById('<%=_oTxtPropertySale.ClientID%>').value.replace(/,/g, '')); 
             
             var delivery = 0
             var newBusiness = 0
             var Unemployed = 0
             var Basic = 5.50 //+ parseInt(document.getElementById('_oTxtHiddenNewBusiness').value);
             if (radioProfession.value == "Unemployed") {
                 Unemployed = 15;
                 //alert(Basic)
             }
             if (_oRadioPickup.checked == true)
             {
                 delivery = 250;
                 
             }
             if (_oChkNewBusiness.checked == true)
             {
                 newBusiness = 100;
             }
             //parseInt(document.getElementById('_oTxtHiddenDelivery').value);
                                      
             var DateNow = new Date();
             var Month = parseInt(DateNow.getMonth()) + 1;
             var Penalty = 0.02 * parseInt(Month);
             
             //var TotGross = (parseFloat(Bus) + parseFloat(Sal) + parseFloat(RP));
             if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value == "")
             {
                 Bus = 0;
                 //alert("no business")
             }
             if (document.getElementById("<%=_oTxtSalary.ClientID%>").value == "")
             {
                 Sal = 0;
                 //alert("no salary")
             }
             if (document.getElementById("<%=_oTxtPropertySale.ClientID%>").value == "") {
                 RP = 0;
                 //alert("no salary")
             }

            var TotGross = (parseFloat(Bus) + parseFloat(Sal) + parseFloat(RP));

             /* get amount 1 peso for every 1000 */
             var Remainder = parseFloat(TotGross) % 1000;
             var Subtract = parseFloat(TotGross) - parseFloat(Remainder);
             var quotient = parseFloat(Subtract) / 1000;             
             var TaxDue = quotient;
             


             if (TaxDue >= 5000) {
                 TaxDue = 5000;
                 //alert(Bus)
                 //alert(TotGross)
             };
             //             
             var ComputedTaxDue = parseFloat(TaxDue) + parseFloat(Basic) + newBusiness + Unemployed;
             var Interest = parseFloat(ComputedTaxDue) * parseFloat(Penalty);
             var tot_amount = parseFloat(TaxDue) + parseFloat(Basic) + parseFloat(Interest) + newBusiness + Unemployed;
             document.getElementById('<%=_oTxtHiddenAmountDue.ClientID%>').value = ComputedTaxDue + delivery;
             document.getElementById('<%=_oTxtHiddenPenalty.ClientID%>').value = Interest;
             
             /*display the result*/
             document.getElementById('<%=AmountToPay.ClientID%>').value = tot_amount + delivery;            
             

           };
           

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
             };

         function ClearSalary() {
             if (document.getElementById('<%=_oTxtSalary.ClientID%>').value <= 0.00) {
                 document.getElementById('<%=_oTxtSalary.ClientID%>').value = '';
                 };
               
                 
         };

         function ClearBusiness() {
             if (document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value <= 0.00) {
                 document.getElementById('<%=_oTxtBusinessIncome.ClientID%>').value = '';
               };

         };

         function ClearProperty() {
             if (document.getElementById('<%=_oTxtPropertySale.ClientID%>').value <= 0.00) {
                 document.getElementById('<%=_oTxtPropertySale.ClientID%>').value ='';
             };
         };
     </script>
   
    <script>
        

    </script>
 </div>
</asp:Content>
