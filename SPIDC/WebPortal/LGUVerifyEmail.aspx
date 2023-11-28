<%@ Page Language="vb" ClientIDMode="Static" AutoEventWireup="false" CodeBehind="LGUVerifyEmail.aspx.vb" Inherits="SPIDC.LGUVerifyEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>SPIDC Web Portal</title>
    <link href="../CSS_JS_IMG/UserManagement/Css/style.css" rel="stylesheet" />    
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">   

</head>
<body>
   
     
    <%--<div class=" p-1">
        <h5 class="m-1 font-weight-bold text-primary">Select from Local System</h5>
    </div>--%>
    <style> 
input[type=text]:enabled {
  background: #ffffff;
}

input[type=text]:disabled,select:disabled,input[type=date]:disabled,input[type=number]:disabled,textarea:disabled  {
  background: #ffffff;
}
select[disabled] { background-color: blue; }
</style>

         <div runat="server" id="DivErr" class="row justify-content-center align-items-center form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
           
             <h6 runat="server" id="txtErr" class="m-0 font-weight-bold col" style="color:red">
            </h6>
            <br />
            <a href="#" runat="server" style="color:blue" id="lnkLogin"></a>

            </div></div>
    <form id="frmNone" ></form>
     <form id="frmSubmit" method="post" runat="server">
    <div runat="server" id="DivOK" class="row justify-content-center align-items-center form mb-0 m-1">
        <div class=" col-lg-7" style="padding-left: 0; padding-right: 0;">
            <div class="card shadow mx-2">
                <div class=" m-2">
               
                    <div class="form-row col-md-12 m-0 row ">
                        <div class="col-lg-12 m-2 mb-3 row">

                            <h6 class="m-0 font-weight-bold text-primary col"><i class="fa fa-user text-primary" style="font-size: 20px;"></i>&nbsp User Information
                            </h6>
                            <%--<div class="col"><button id="_obtn_Edit" class="float-right btn-primary rounded" runat="server" disabled="disabled"><i class="fa fa-edit color-white d-flex justify-content-center align-content-center" style="font-size: 20px;"> </i></button></div>--%>
                            
                        </div>           
                        <p class="text-primary" style="float:left">Please fill-up all the required fields to activate your account</p>              
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-8">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Email Address &nbsp</span></span>
                                    </label>
                                    <%--<input id="Text12" type="text" class="form-control CH-Size" required="" autocomplete="off" runat="server">--%>
                                    <asp:textbox runat="server" id="_otxt_EmailAddress" name="txtEmail" class="form-control CH-Size" ReadOnly="true"/>
                                   <asp:textbox runat="server" id="_otxt_code" name="_otxt_code" class="form-control CH-Size" ReadOnly="true" style="display:none"/>
                                     <asp:textbox runat="server" id="_otxt_R" name="_otxt_R" class="form-control CH-Size" ReadOnly="true" style="display:none"/>
                              
                                </div>
                            </div>

                            <div class="form-group col-lg-4">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Office &nbsp</span></span>
                                    </label>
                                    <%--<input id="Text13" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <asp:textbox runat="server" id="_otxt_Office" class="form-control CH-Size" ReadOnly="true"/>
                                </div>
                            </div>                        
                        </div>
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-3">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp <a style="color:red;font-weight:bold;">*</a> Last Name &nbsp</span></span>
                                    </label>
                              <input required type="text" name="txtLastname" class="form-control CH-size" id="txtLastname" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                                     
                                      </div>
                            </div>
                            <div class="form-group col-lg-3">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp <a style="color:red;font-weight:bold;">*</a> First Name &nbsp</span></span>
                                    </label>

                                <input required type="text" name="txtFirstname" class="form-control CH-size" id="txtFirstname" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                               
                                    
                                     </div>

                            </div>
                            <div class="form-group col-lg-3">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Middle Name &nbsp</span></span>
                                    </label>

                           <input  type="text" name="txtMiddlename" class="form-control CH-size" id="txtMiddlename" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                              
                                     </div>

                            </div>
                            <div class="form-group col-lg-3">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Suffix &nbsp</span></span>
                                    </label>

                         <input  type="text" name="txtSuffix" class="form-control CH-size" id="txtSuffix" pattern="[\s a-zA-ZñÑ]+" oninput="this.reportValidity()" title="First Name" onblur="this.style.textTransform  = 'capitalize';this.value = this.value.replace(/\s\s+/g, ' ').replace(/^\s+|\s+$/g, ''); " />
                         
                                       </div>

                            </div>
                        </div>                        
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-4">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp <a style="color:red;font-weight:bold;">*</a> Birthday &nbsp</span></span>
                                    </label>
                      <input required type="text" name="txtBirthDate" class="form-control CH-size" id="txtBirthDate" min="1900-01-01" max="2018-12-31" placeholder="Birth Date" onfocus="(this.type='date')" />
                                    
                                       </div>
                            </div>
                            <div class="form-group col-lg-4">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Birth Place &nbsp</span></span>
                                    </label>                                                       
                                <textarea  id="txtBirthPlace" name="txtBirthPlace" class="form-control CH-Size"></textarea>
                       
                                      </div>
                            </div>
                            <div class="form-group col-lg-4">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Address &nbsp</span></span>
                                    </label>
                                  <textarea  id="txtAddress" name="txtAddress" class="form-control CH-Size"></textarea>
                       
                                      </div>
                            </div>
                        </div>
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-3">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Gender &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Gender" type="text" class="form-control CH-Size" required="" autocomplete="off" runat="server">--%>
                                    <select id="txtGender" name="txtGender" class="form-control CH-Size">
                                        <option value = "M" >Male</option>
                                        <option value = "F">Female</option>                                        
                                    </select>
                                </div>
                            </div>

                            <div class="form-group col-lg-3">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Citizenship &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Citizenship" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <select class="form-control CH-size" id="txtCitizenship" name="txtCitizenship">                                        
                                        <option value="filipino">Filipino</option>
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
                            <div class="form-group col-lg-3">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Civil Status &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_CivilStatus" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <select class="form-control CH-size" id="txtCivilStatus" name="txtCivilStatus">
                                        <option value="Single">Single</option>
                                        <option value="Married">Married</option>
                                        <option value="Widowed">Widowed</option>
                                        <option value="Divorced">Divorced</option>
                                        <option value="Separated">Separated</option>
                                    </select>
                                </div>

                            </div>
                            <div class="form-group col-lg-3">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Profession &nbsp</span></span>
                                    </label>
                                    <input id="txtProfession" name="txtProfession" type="text" class="form-control CH-Size"/>
                                </div>
                            </div>
                        </div>
                        <div class="form-row col-md-12 m-0 row ">

                            <div class="form-group col-lg-4">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp TIN &nbsp</span></span>
                                    </label>
                                    <input type="text" class="form-control form-control-user CH-size" id="txtTIN" name="txtTIN" placeholder="XXX-XXX-XXX-XXX" onkeypress="return onlyNumbers();" onkeyup="addHyphen(this)" maxlength="15"/>
                                </div>

                            </div>
                            <div class="form-group col-lg-4">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Mobile No. &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Contact_Number" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server"/>--%>
                                    <input type="number" class="form-control form-control-user CH-size" id="txtContactNumber" name="txtContactNumber" placeholder="Mobile No." onkeypress="return onlyNumbers();" maxlength="11"/>
                                </div>

                            </div>                            
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Height (m.) &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Height" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <input type="text" class="form-control CH-Size"  id="txtHeight" name="txtHeight" step ="0.01" onfocus="(this.type='number');if(this.value=='0')this.value='';" onkeyup="this.value = heightminmax(this.value, 0.30, 3.05)" onclick="this.value = heightminmax(this.value, 0.30, 3.05)" onfocusout="return OnTextNumericKeyPress(event);" onblur="if(this.value=='') this.value='0';return OnTextNumericKeyPress(event);"  onkeypress="return OnTextNumericKeyPress(event);"  onchange="RoundtoDecimal(this);"/>
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
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Weight (kg.) &nbsp</span></span>
                                    </label>
                                 <input type="text" class="form-control CH-Size" min="1" max="300" id="txtWeight" name="txtWeight" onfocus="(this.type='number')" onkeyup="this.value = weightminmax(this.value, 1, 300)"/>
                                </div>

                            </div>
                                   
                            
                        <div class="form-group col-lg-4">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp <a style="color:red;font-weight:bold;">*</a> Security Question &nbsp</span></span>
                                    </label>
                                   <select required id="radQuestion" name="radQuestion" class="form-control CH-Size" style="font-size: 13px">
                                          <option value="" disabled="" selected="">Security Question</option>
                                          <option value="1">What's your pet's name?</option>
                                          <option value="2">What primary school did you attend?</option>
                                          <option value="3">In what town or city was your first full time job?</option>
                                          <option value="4">In what town or city did you meet your spouse/partner?</option>
                                          <option value="5">What are the last five digits of your driver's licence number?</option>
                                          <option value="6">What was the house number and street name you lived in as a child?</option>
                                          <option value="7">What were the last four digits of your childhood telephone number?</option>
                                      </select>
                                </div>
                            </div>                                                
 
                        <div class="form-group col-lg-4">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp <a style="color:red;font-weight:bold;">*</a> Security Answer &nbsp</span></span>
                                    </label>
                                  <input required type="text" class="form-control CH-Size" id="txtSecurityA" name="txtSecurityA" placeholder="" title="Security Answer"/>
                                </div>
                            </div>
    
                            <div class="form-group col-lg-4">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp <a style="color:red;font-weight:bold;">*</a> Password &nbsp</span></span>
                                    </label>
                              <input required type="password" class="form-control CH-Size" name="txtPassword" id="txtPassword" /> 
                                </div>
                            </div>
                         </div>
                               
                        <div class="form-row col-md-12 m-0 row " id ="div_PassKey">
                            <div class="form-group col-lg-6" id="PassKey" runat="server">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Pass Key:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtPassKey" name="_oTxtPassKey" onkeyup="_xheckpasskey()"  maxlength="4"/>
                                </div>
                            </div>
                            <div class="form-group col-lg-6" id="ConPassKey" runat="server">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Confirm Pass Key:</span></span>
                                    </label>
                                    <input type="text" class="form-control CH-Size-new" autocomplete="off" runat="server" id="_oTxtConPassKey" name="_oTxtConPassKey" onkeyup="_xheckpasskey()" maxlength="4"/>
                                </div>
                            </div>                             
                         </div>  
                        <div class="form-row col-md-12 m-0 row ">      
                        <div class="form-group col-lg-6" id="Div1" runat="server">
                                <div>
                                    <label id="errmessg" style="visibility:hidden;font-style:italic;font:bold;color:red"></label><br />
                                </div>
                             </div>
                            
                            <div class="form-group col-lg-6" id="Div2" runat="server">
                                <div>
                                    <label id="validationmsg" style="visibility:hidden;font-style:italic;font:bold;color:red"></label><br />
                                </div>
                             </div> 
                            </div> 
                                                                           
                        </div>  

              <input type="hidden" runat="server" id="hdnRegulatory" />

                    <div class="col-12" style="color: #7e7e7e">

                        <div class="m-2 col-12 d-flex justify-content-center align-content-center">
                            <input type="submit" value="Submit" id="btnSubmit" name="btnSubmit" formaction="LGUVerifyEmail.aspx"/>

                        </div>
                    </div>
               
                </div>
            </div>
        </div>
    </div>
          </form>   
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
           document.getElementById("txtBirthDate").setAttribute("max", today);

                </script>

   
          <script>          
                  var str = window.location.href;
                  if (str.toUpperCase().includes("EXECUTIVE") == true) {
                      document.getElementById('  div_PassKey').style.display = "none";                  
                  
                }
               

    



              function _xheckpasskey() {

                  if (document.getElementById('<%=_oTxtPassKey.ClientID%>').value.length < 4) {
                      document.getElementById('validationmsg').style.display = "flex";
                      document.getElementById('validationmsg').style.visibility = "visible";
                      document.getElementById('validationmsg').innerHTML = "passkey must have 4 characters!";
                      document.getElementById('validationmsg').style.color = "red";
                  }
                  if (document.getElementById('<%=_oTxtPassKey.ClientID%>').value.length == 4) {
                      document.getElementById('validationmsg').style.display = "none";
                      document.getElementById('validationmsg').style.visibility = "hidden";
                  }
                  if (document.getElementById('<%=_oTxtPassKey.ClientID%>').value == '') {
                      document.getElementById('validationmsg').style.display = "none";
                      document.getElementById('validationmsg').style.visibility = "hidden";
                  }


                  if (document.getElementById('<%=_oTxtPassKey.ClientID%>').value == document.getElementById('<%=_oTxtConPassKey.ClientID%>').value) {
                      document.getElementById("errmessg").style.display = "flex";
                      document.getElementById('errmessg').style.visibility = "visible"
                      document.getElementById('errmessg').innerHTML = "passkey match"
                      document.getElementById('errmessg').style.color = "green"
                  }

                  if (document.getElementById('<%=_oTxtPassKey.ClientID%>').value != document.getElementById('<%=_oTxtConPassKey.ClientID%>').value) {
                      document.getElementById("errmessg").style.display = "flex";
                      document.getElementById('errmessg').style.visibility = "visible"
                      document.getElementById('errmessg').innerHTML = "passkey do not match!"
                      document.getElementById('errmessg').style.color = "red"
                  }
                  if (document.getElementById('<%=_oTxtPassKey.ClientID%>').value == '' && document.getElementById('<%=_oTxtConPassKey.ClientID%>').value == '') {
                      document.getElementById("errmessg").style.display = "none";
                  }
              }

        document.getElementById("_oBtnEditProfile").addEventListener("click", retrieveInfo);
        document.getElementById("_oCheckBoxResident").addEventListener("change", chkboxRes);

        $(function () {
            var dtToday = new Date();

            var month = dtToday.getMonth() + 1;
            var day = dtToday.getDate();
            var year = dtToday.getFullYear();

            if (month < 10)
                month = '0' + month.toString();
            if (day < 10)
                day = '0' + day.toString();

            var maxDate = year + '-' + month + '-' + day;
            $('#_oTextBirthday').attr('max', maxDate);
        });


        function capitalizeFirstLetter(string) {
            return string.charAt(0).toUpperCase() + string.slice(1);
        }

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if (charCode < 48 || charCode > 57)
                return false;

            return true;

        }

        function addHyphen(element) {
            let ele = document.getElementById(element.id);
            ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

            let finalVal = ele.match(/.{1,3}/g).join('-');
            document.getElementById(element.id).value = finalVal;
        }
    </script>

        <script src="../CSS_JS_IMG/UserManagement/JS/jquery.min.js"></script>
    <script src="../CSS_JS_IMG/UserManagement/JS/bootstrap.min.js"></script>
    <script src="../CSS_JS_IMG/UserManagement/JS/popper.js"></script>
    <script src="../CSS_JS_IMG/UserManagement/JS/main.js"></script>
    <script>
        document.getElementById("_oBtnEditProfile").addEventListener("click", retrieveInfo);
        document.getElementById("_oCheckBoxResident").addEventListener("change", chkboxRes);

        $(function () {
            var dtToday = new Date();

            var month = dtToday.getMonth() + 1;
            var day = dtToday.getDate();
            var year = dtToday.getFullYear();

            if (month < 10)
                month = '0' + month.toString();
            if (day < 10)
                day = '0' + day.toString();

            var maxDate = year + '-' + month + '-' + day;
            $('#_oTextBirthday').attr('max', maxDate);
        });

   
        function capitalizeFirstLetter(string) {
            return string.charAt(0).toUpperCase() + string.slice(1);
        }

        function onlyNumbers(evt) {
            var e = event || evt; // for trans-browser compatibility
            var charCode = e.which || e.keyCode;

            if (charCode < 48 || charCode > 57)
                return false;

            return true;

        }

        function addHyphen(element) {
            let ele = document.getElementById(element.id);
            ele = ele.value.split('-').join('');    // Remove dash (-) if mistakenly entered.

            let finalVal = ele.match(/.{1,3}/g).join('-');
            document.getElementById(element.id).value = finalVal;
        }
    </script>
  
  </body>
</html>


