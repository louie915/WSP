<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/UserManagementMaster.Master" CodeBehind="UserAccountManagementCU.aspx.vb" Inherits="SPIDC.UserAccountManagementCU" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" p-1">
        <h5 class="m-1 font-weight-bold text-primary">Select from Local System</h5>
    </div>
    <style> 
input[type=text]:enabled {
  background: #ffffff;
}

input[type=text]:disabled,select:disabled,input[type=date]:disabled,input[type=number]:disabled,textarea:disabled  {
  background: #ffffff;
}
select[disabled] { background-color: blue; }
</style>
    <div class="row justify-content-center align-items-center form mb-0 m-1">
        <div class=" col-lg-12" style="padding-left: 0; padding-right: 0;">
            <div class="card shadow mx-2">
                <div class=" m-2">
                    <div class="form-row col-md-12 m-0 row ">
                        <div class="col-lg-12 m-2 mb-3 row">

                            <h6 class="m-0 font-weight-bold text-primary col"><i class="fa fa-user text-primary" style="font-size: 20px;"></i>&nbsp User Profile</h6>
                            <div class="col"><button id="_obtn_Edit" class="float-right btn-primary rounded" onserverclick="btnEdit_Click" runat="server" disabled="disabled"><i class="fa fa-edit color-white d-flex justify-content-center align-content-center" style="font-size: 20px;"> </i></button></div>
                            
                        </div>                        
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-4">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Email Address &nbsp</span></span>
                                    </label>
                                    <%--<input id="Text12" type="text" class="form-control CH-Size" required="" autocomplete="off" runat="server">--%>
                                    <asp:textbox runat="server" id="_otxt_EmailAddress" class="form-control CH-Size"/>
                                </div>
                            </div>

                            <div class="form-group col-lg-3">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Office &nbsp</span></span>
                                    </label>
                                    <%--<input id="Text13" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <asp:textbox runat="server" id="_otxt_Office" class="form-control CH-Size"/>
                                </div>

                            </div>
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp User Level &nbsp</span></span>
                                    </label>
                                    <%--<input id="Text14" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <select runat="server" id="_otxt_UserLevel" class="form-control CH-Size">
                                        <option value = "1" >User</option>
                                        <option value = "100">Administrator</option>
                                    </select>
                                </div>

                            </div>
                        </div>
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-2">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Last Name &nbsp</span></span>
                                    </label>
                                    <asp:textbox runat="server" id="_otxt_Lastname" class="form-control CH-Size"/>
                                </div>
                            </div>

                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp First Name &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxtEnterBusinessORNo" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <asp:textbox runat="server" id="_otxt_Firstname" class="form-control CH-Size"/>
                                </div>

                            </div>
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Middle Name &nbsp</span></span>
                                    </label>
                                    <%--<input id="Text1" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <asp:textbox runat="server" id="_otxt_Middlename" class="form-control CH-Size"/>
                                </div>

                            </div>
                            <div class="form-group col-lg-1">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Suffix &nbsp</span></span>
                                    </label>
                                    <%--<input id="Text3" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <asp:textbox runat="server" id="_otxt_NameSuffix" class="form-control CH-Size"/>
                                </div>

                            </div>
                        </div>                        
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-2">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Birthday &nbsp</span></span>
                                    </label>
                                  <%--  <input id="_otxt_Birthdate" type="date" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server" />
                                 --%>
                                    <input class="form-control CH-Size-new" runat="server" id="_otxt_Birthdate" onclick="this.type = 'date';"  />
                       
                                     </div>
                            </div>
                            <div class="form-group col-lg-4">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Birth Place &nbsp</span></span>
                                    </label>
                                    <textarea id="_otxt_BirthPlace" class="form-control CH-Size" required="" runat="server"></textarea>                                    
                                </div>
                            </div>
                            <div class="form-group col-lg-4">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Address &nbsp</span></span>
                                    </label>
                                    <textarea id="_otxt_Address" class="form-control CH-Size" required="" runat="server"></textarea>                                    
                                </div>
                            </div>
                        </div>
                        <div class="form-row col-md-12 m-0 row ">
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Gender &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Gender" type="text" class="form-control CH-Size" required="" autocomplete="off" runat="server">--%>
                                    <select runat="server" id="_otxt_Gender" class="form-control CH-Size">
                                        <option value = "M" >Male</option>
                                        <option value = "F">Female</option>                                        
                                    </select>
                                </div>
                            </div>

                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Citizenship &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Citizenship" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <select runat="server" class="form-control CH-size" id="_otxt_Citizenship">                                        
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
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Civil Status &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_CivilStatus" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <select runat="server" class="form-control CH-size" id="_otxt_CivilStatus">
                                        <option value="Single">Single</option>
                                        <option value="Married">Married</option>
                                        <option value="Widowed">Widowed</option>
                                        <option value="Divorced">Divorced</option>
                                        <option value="Separated">Separated</option>
                                    </select>
                                </div>

                            </div>
                            <div class="form-group col-lg-2">
                                <div>

                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Profession &nbsp</span></span>
                                    </label>
                                    <input id="_otxt_Profession" type="text" class="form-control CH-Size" required="" autocomplete="off" runat="server"/>
                                </div>
                            </div>
                        </div>
                        <div class="form-row col-md-12 m-0 row ">

                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp TIN &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_TIN" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server"/>--%>
                                    <input runat="server" type="text" class="form-control form-control-user CH-size" id="_otxt_TIN" placeholder="XXX-XXX-XXX-XXX" onkeypress="return onlyNumbers();" onkeyup="addHyphen(this)" maxlength="15"/>
                                </div>

                            </div>
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Mobile No. &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Contact_Number" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server"/>--%>
                                    <input runat="server" type="text" class="form-control form-control-user CH-size" id="_otxt_Contact_Number" placeholder="Mobile No." onkeypress="return onlyNumbers();" maxlength="11"/>
                                </div>

                            </div>
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Other Mobile No. &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Contact_OtherNumber" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server"/>--%>
                                    <input runat="server" type="text" class="form-control form-control-user CH-size" id="_otxt_Contact_OtherNumber" placeholder="Mobile No." onkeypress="return onlyNumbers();" maxlength="11"/>
                                </div>

                            </div>
                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Telephone Number &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Contact_Telephone" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <input runat="server" type="text" class="form-control form-control-user CH-size" id="_otxt_Contact_Telephone" placeholder="Mobile No." onkeypress="return onlyNumbers();"/>
                                </div>

                            </div>
                        </div>
                        <div class="form-row col-md-12 m-0 row ">

                            <div class="form-group col-lg-2">
                                <div>
                                    <label class="input-txt input-txt-active">
                                        <span><span class="">&nbsp Height (m.) &nbsp</span></span>
                                    </label>
                                    <%--<input id="_otxt_Height" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <input type="text" class="form-control CH-Size" required="" autocomplete="off" runat="server" id="_otxt_Height" step ="0.01" onfocus="(this.type='number');if(this.value=='0')this.value='';" onkeyup="this.value = heightminmax(this.value, 0.30, 3.05)" onclick="this.value = heightminmax(this.value, 0.30, 3.05)" onfocusout="return OnTextNumericKeyPress(event);" onBlur="if(this.value=='') this.value='0';return OnTextNumericKeyPress(event);"  onKeyPress="return OnTextNumericKeyPress(event);"  onchange="RoundtoDecimal(this);">
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
                                    <%--<input id="_otxt_Weight" type="text" class="form-control CH-Size" required="" autocomplete="off" placeholder="" runat="server">--%>
                                    <input type="text" class="form-control CH-Size" required autocomplete="off" min="1" max="300" runat="server" id="_otxt_Weight" onfocus="(this.type='number')" onkeyup="this.value = weightminmax(this.value, 1, 300)">
                                </div>

                            </div>
                        </div>
                        <%--<div class="form-group col-md-5">
                            <button  form="" name="btnEnroll" id="btnEnroll" type="submit" class="btn btn-primary btn-sm col right" runat="server">Enroll</button>
                        </div>--%>
                    </div>




                    <div class="col-12" style="color: #7e7e7e">

                        <div class="m-2 col-12 d-flex justify-content-center align-content-center">
                            <button class="btn btn-success btn-sm" runat="server" id="_obtn_Save" onserverclick="_oBtnSaveChanges_ServerClick" >Save &nbsp  <i class="fa fa-save icon"></i>&nbsp</button>
                            &nbsp &nbsp &nbsp
                                <button class="btn btn-danger btn-sm" runat="server" id="_obtn_Cancel" onserverclick="btnCancel_Click">Cancel <i class="fa fa-remove icon"></i></button>
                        </div>
                    </div>
                    <%--<script>
                            function Select(Action, Val) {
                                __doPostBack(Action, Val);
                            }
                        </script>  --%>
                </div>
            </div>
        </div>
    </div>
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

        <%--function chkboxRes() {
            var chkboxRes = document.getElementById('_oCheckBoxResident');

            if (chkboxRes.checked == true) {
                document.getElementById('<%=_oChkBoxRes.ClientID%>').value = '1';
            } else if (chkboxRes.checked == false) {
                document.getElementById('<%=_oChkBoxRes.ClientID%>').value = '0';
            }
    }

    function retrieveInfo() {
        var gen;
        var cit;
        var res;

        cit = document.getElementById('<%=_oLabelCitizenship.ClientID%>').innerText;
            cit = cit.toLowerCase();

            if (document.getElementById('<%=_oLabelGender.ClientID%>').innerText == 'Male') {
                gen = 'M';
            } else if (document.getElementById('<%=_oLabelGender.ClientID%>').innerText == 'Female') {
                gen = 'F';
            }

            res = "<%=getResident%>"

            if (res == "True") {
                document.getElementById('_oCheckBoxResident').checked = true;
            } else if (res == "False") {
                document.getElementById('_oCheckBoxResident').checked = false;
            }

            document.getElementById('<%=_oTextFirstName.ClientID%>').value = "<%=getFirstName%>";
            document.getElementById('<%=_oTextLastName.ClientID%>').value = "<%=getLastName%>";
            document.getElementById('<%=_oTextMiddleName.ClientID%>').value = "<%=getMiddleName%>";
            document.getElementById('<%=_oTextSuffix.ClientID%>').value = "<%=getSuffix%>";
            document.getElementById('<%=_oSelectGender.ClientID%>').value = gen;
            document.getElementById('<%=_oSelectCitizenship.ClientID%>').value = cit;
            document.getElementById('<%=_oTextBirthday.ClientID%>').value = "<%=getBirthDate%>";
            document.getElementById('<%=_oSelectCivilStatus.ClientID%>').value = document.getElementById('<%=_oLabelCivilStatus.ClientID%>').innerText;
            document.getElementById('<%=_oTextProfession.ClientID%>').value = document.getElementById('<%=_oLabelProfession.ClientID%>').innerText;
            document.getElementById('<%=_oTextAddress.ClientID%>').value = document.getElementById('<%=_oLabelAddress.ClientID%>').innerText;
            document.getElementById('<%=_oTextBirthAddress.ClientID%>').value = document.getElementById('<%=_oLabelBirthPlace.ClientID%>').innerText;
            document.getElementById('<%=_oTextTIN.ClientID%>').value = document.getElementById('<%=_oLabelTIN.ClientID%>').innerText;
            document.getElementById('<%=_oTextContactNumber1.ClientID%>').value = document.getElementById('<%=_oLabelContactNumber1.ClientID%>').innerText;
            document.getElementById('<%=_oTextContactNumber2.ClientID%>').value = document.getElementById('<%=_oLabelContactNumber2.ClientID%>').innerText;
            document.getElementById('<%=_oTextContactNumber3.ClientID%>').value = document.getElementById('<%=_oLabelContactNumber3.ClientID%>').innerText;
            document.getElementById('<%=_oTextHeight.ClientID%>').value = document.getElementById('<%=_oLabelHeight.ClientID%>').innerText;
            document.getElementById('<%=_oTextWeight.ClientID%>').value = document.getElementById('<%=_oLabelWeight.ClientID%>').innerText;
        }--%>

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
</asp:Content> 

