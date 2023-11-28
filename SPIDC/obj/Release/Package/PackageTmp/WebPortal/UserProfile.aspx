<%@ Page EnableEventValidation="false" Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="UserProfile.aspx.vb" Inherits="SPIDC.UserProfile" %>

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

    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div id="snackbar" style="position: absolute; z-index: 2000 !Important;">
                    <asp:Label runat="server" ID="_oLabelSnackbar" Style="z-index: 2000 !Important;" />
                </div>
                <div id="snackbargreen" style="position: absolute; z-index: 2000 !Important;">
                    <asp:Label runat="server" ID="_oLabelSnackbargreen" Style="z-index: 2000 !Important;" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="form-row justify-content-center align-items-center form mb-0">
        <div class="col-sm-11">
            <br />
            <div class="card shadow">
                <div class="card-header">
                    <div class="row">
                        <div class="col-sm-10 form-inline">
                            <i class="fas fa-user text-primary" style="font-size: 20px;"></i>
                            &nbsp;&nbsp;&nbsp;
                            <h1 class="h5 mb-0 text-gray-800">User Profile - Please make sure to complete your profile</h1>
                        </div>
                        <div class="col-sm-2">
                            <%--   <a data-toggle="modal" data-target="#myModal" id="_oBtnEditProfile"> <i class="fas fa-edit text-primary float-right" style="font-size: 20px; cursor:pointer">EDIT &nbsp</i></a>--%>
                            <a data-toggle="modal" data-target="#myModal" id="_oBtnEditProfile"><i class="fas fa-edit text-primary float-right" style="font-size: 20px; cursor: pointer">EDIT &nbsp</i></a>
                        </div>
                    </div>
                </div>

                <div class="card-body">
                    <div class="row">
                        <%--Gimay 20201123--%>
                        <%--Gimay 20201123--%>
                        <asp:Button runat="server" ID="btnUpdateFiles" ClientIDMode="Static" UseSubmitBehavior="false" OnClick="Upload_Docs_new" Style="display: none" />
                        <%-- <asp:Button runat="server" id="btnClose"  ClientIDMode="Static" UseSubmitBehavior="false"  OnClick="ModalClose" style="display:none" /> --%>

                        <div class="col-sm-12" align="center">
                            <br />
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Fullname</p>
                            <p class="h5 font-weight-bold text-uppercase" id="_oLabelFullname" runat="server"></p>
                            <p class="text-xs font-weight-italic text-primary" id="_oLabelEmail" runat="server"></p>
                            <br />
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Profession</p>
                            <p class="h6 font-weight-light" id="_oLabelProfession" runat="server"></p>
                        </div>
                    </div>
                </div>
                <div class="card-footer">
                    <div class="row">
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Birthday</p>
                            <p class="h6 font-weight-light" id="_oLabelBirthday" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center" style="display: none;">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Birth Place</p>
                            <p class="h6 font-weight-light" id="_oLabelBirthPlace" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Citizenship</p>
                            <p class="h6 font-weight-light" id="_oLabelCitizenship" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Address</p>
                            <p class="h6 font-weight-light" id="_oLabelAddress" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Gender</p>
                            <p class="h6 font-weight-light" id="_oLabelGender" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Civil Status</p>
                            <p class="h6 font-weight-light" id="_oLabelCivilStatus" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">TIN</p>
                            <p class="h6 font-weight-light" id="_oLabelTIN" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Mobile Number</p>
                            <p class="h6 font-weight-light" id="_oLabelContactNumber2" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Alternate Contact Number</p>
                            <p class="h6 font-weight-light" id="_oLabelContactNumber3" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Telephone Numbers</p>
                            <p class="h6 font-weight-light" id="_oLabelContactNumber1" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" align="center" style="display: none;">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Height (m)</p>
                            <p class="h6 font-weight-light" id="_oLabelHeight" runat="server"></p>
                            <br />
                        </div>
                        <div class="col-sm-6" style="display: none;" align="center">
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Weight (kls)</p>
                            <p class="h6 font-weight-light" id="_oLabelWeight" runat="server"></p>
                            <br />
                        </div>

                        <div class="col-sm-6" align="center">
                            <%--Gimay 20201120--%>
                            <p class="text-xs font-weight-bold text-primary text-uppercase mb-1">Alternate Email Address</p>
                            <p class="h6 font-weight-light" id="_oLabelAlternateEmail" runat="server"></p>
                            <br />
                            <br />
                        </div>

                        <asp:Panel runat="server" ID="_oPGIDView" CssClass="form-group col-lg-6 row">
                            <div class=" col-lg-8 mt-2 ">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Government ID</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtGovernmentID" />
                                </div>
                            </div>
                            <div class="col-lg-4 mb-4 mt-2">
                                <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtGovernmentID.ClientID%>');ViewSPA('FileName','FileType','FileData','001','<%=_oTxtGovernmentID.ClientID%>');">View</a>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="_oPSPAView" CssClass="form-group col-lg-6 row">
                            <div class="form-group col-lg-8 mt-2">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Special Power of Attorney</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtSPA" />
                                </div>
                            </div>
                            <div class="col-lg-4 mb-4 mt-2">
                                <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtSPA.ClientID%>');ViewSPA('FileName','FileType','FileData','002','<%=_oTxtSPA.ClientID%>');">View</a>
                            </div>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="_oPBRSec" CssClass="form-group col-lg-6 row">
                            <div class="form-group col-lg-8 mt-2">
                                <div>
                                    <label class="input-txt input-txt-active2">
                                        <span><span class="m-2">Board Resolution/Secretary Certificate</span></span>
                                    </label>
                                    <input type="text" runat="server" class="form-control CH-Size-New" style="font-size: 11px !Important; padding-top: 7px !Important" id="_oTxtBRSec" />
                                </div>
                            </div>
                            <div class="col-lg-4 mb-4 mt-2">
                                <a href="#" style="font-size: 14px !Important; height: 30px !Important; max-width: 60px !Important;" class="d-flex justify-content-between align-content-between btn btn-primary" onclick="opennewtab('<%=_oTxtBRSec.ClientID%>');ViewSPA('FileName','FileType','FileData','003','<%=_oTxtBRSec.ClientID%>');">View</a>
                            </div>
                        </asp:Panel>
                        <input type="hidden" runat="server" id="hdnuserid" />
                        <input type="hidden" runat="server" id="hdnseqid" />
                        <input type="hidden" runat="server" id="hdnName" />
                        <input type="hidden" runat="server" id="hdnType" />
                        <input type="hidden" runat="server" id="hdnData" />
                        <script>
                            function ViewSPA(Name, Type, Data, seqid, sample) {
                                var Checkival = document.getElementById(sample).value;
                                if (Checkival != "No Attached File") {
                                    document.getElementById('<%=hdnName.ClientID%>').value = Name;
                                    document.getElementById('<%=hdnType.ClientID%>').value = Type;
                                    document.getElementById('<%=hdnData.ClientID%>').value = Data;
                                    __doPostBack('DownloadFiles', seqid);
                                }
                                else {
                                    document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "No Attached File";
                                    Snackbar();

                                }
                            }
                            function opennewtab(fileid) {
                                var Checkival = document.getElementById(fileid).value;
                                //alert(Checkival)
                                if (Checkival != "No Attached File") {
                                    window.document.forms[0].target = '_blank';
                                    setTimeout(function () { window.document.forms[0].target = ''; }, 0);
                                }

                            }
                            function SendEmail() {
                                __doPostBack('EmailNotification', '');
                            }                        
                        </script>


                    </div>
                </div>
            </div>
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header bg-primary">
                            <i class="fas fa-edit text-white float-right" style="font-size: 30px;"></i>
                            <h4 class="modal-title text-white" id="myModalLabel">Edit Profile</h4>
                            <button type="button" class="close text-white" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <form id="frmNone"></form>
                        <%--<form id="frmSubmit" name="frmSubmit" method="post" onsubmit="document.getElementById('hdnSubmit').value=1;sessionStorage.removeItem('file1');sessionStorage.removeItem('file2')">              --%>
                        <form id="frmSubmit" name="frmSubmit">
                            <%--Gimay 20201126--%>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Firstname <span style="color: red">*</span></span></span></label>
                                            <input type="text" class="form-control CH-Size-new required" name="_oTextFirstName" id="_oTextFirstName" placeholder="Enter Firstname" required maxlength="100" />
                                        </div>
                                    </div>

                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Middlename</span></span></label>
                                            <input type="text" class="form-control CH-Size-new" name="_oTextMiddleName" id="_oTextMiddleName" placeholder="Enter Middlename" maxlength="100" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Lastname <span style="color: red">*</span></span></span></label>
                                            <input type="text" class="form-control CH-Size-new required" name="_oTextLastName" id="_oTextLastName" placeholder="Enter Lastname" required maxlength="100" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Suffix</span></span></label>
                                            <input type="text" class="form-control CH-Size-new" name="_oTextSuffix" id="_oTextSuffix" placeholder="Enter Suffix" maxlength="10" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Birthday </span></span></label>
                                            <input type="date" class="form-control CH-Size-new" name="_oTextBirthday" id="_oTextBirthday" min="1900-01-01" max="2020-06-10"  />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Gender</span></span></label>
                                            <select r class="form-control CH-Size-new" name="_oSelectGender" id="_oSelectGender">
                                                <option value="M">Male</option>
                                                <option value="F">Female</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 form-group " style="background-color:#257CFC;padding-bottom:0.5em;padding-top:0.5em;">
                                        <div>
                                            <center style="display:none;">
                                                <i style="color:white; text-align:center">Free Delivery Service for Addresses within 
                                                    <label runat="server" id="lblLGUNAME2"></label> Area 
                                                </i>
                                            </center>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Address <span style="color: red">*</span></span></span></label>
                                            <textarea class="form-control CH-Size-new" maxlength="255" name="_oTextAddress required" id="_oTextAddress" placeholder="Enter Address" rows="2" required></textarea>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group " style="display: none;">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Birthplace <span style="color: red">*</span></span></span></label>
                                            <textarea class="form-control CH-Size-new" maxlength="100" name="_oTextBirthAddress" id="_oTextBirthAddress" placeholder="Enter Birthplace" rows="2" required></textarea>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Citizenship <span style="color: red">*</span></span></span></label>
                                            <select class="form-control CH-Size-new" required id="_oSelectCitizenship" name="_oSelectCitizenship">
                                                <option value="filipino" selected>Filipino</option>
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
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Civil Status </span></span></label>
                                            <select class="form-control CH-Size-new" required id="_oSelectCivilStatus" name="_oSelectCivilStatus">
                                                <option value="Single">Single</option>
                                                <option value="Married">Married</option>
                                                <option value="Widowed">Widowed</option>
                                                <option value="Divorced">Divorced</option>
                                                <option value="Separated">Separated</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Profession </span></span></label>
                                            <input type="text" class="form-control CH-Size-new" name="_oTextProfession" maxlength="50" id="_oTextProfession" placeholder="Enter Profession" required />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">TIN</span></span></label>
                                            <input minlength="15" type="text" class="form-control CH-Size-new" name="_oTextTIN" id="_oTextTIN" placeholder="XXX-XXX-XXX-XXX" onkeypress="addHyphen(this); return onlyNumbers();" maxlength="15" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Mobile Number <span style="color: red">*</span></span></span></label>
                                            <input required type="text" class="form-control CH-Size-new required" name="_oTextContactNumber2" id="_oTextContactNumber2" placeholder="Mobile No." minlength="11" maxlength="11" onkeypress="return onlyNumbers();" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Alternate Contact Number</span></span></label>
                                            <input type="text" class="form-control CH-Size-new" name="_oTextContactNumber3" id="_oTextContactNumber3" maxlength="12" placeholder="Alternate Mobile No." onkeypress="return onlyNumbers();" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Telephone Number</span></span></label>
                                            <input type="text" class="form-control CH-Size-new" name="_oTextContactNumber1" id="_oTextContactNumber1" placeholder="Telephone" minlength="7" maxlength="12" onkeypress="return onlyNumbers();" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group " style="display: none;">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Height (m)</span></span></label>
                                            <input type="number" min="0" max="999" value="0" step=".01" name="_oTextHeight" class="form-control CH-Size-new" id="_oTextHeight" placeholder="Enter Height" maxlength="4" />
                                        </div>
                                    </div>
                                    <div class="col-sm-6 form-group " style="display: none;">
                                        <div>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Weight (kls)</span></span></label>
                                            <input type="number" min="0" max="10" value="0" step=".01" class="form-control CH-Size-new" name="_oTextWeight" id="_oTextWeight" placeholder="Enter Weight" maxlength="4" />
                                        </div>
                                    </div>

                                    <div class="col-sm-6 form-group ">
                                        <div>
                                            <%--Gimay 20201120--%>
                                            <label class="input-txt input-txt-active2"><span><span class="m-2">Alternate Email</span></span></label>
                                            <input type="text" class="form-control CH-Size-new" name="_oTextAlternateEmail" id="_oTextAlternateEmail" placeholder="Alternate Email" minlength="7" />
                                        </div>
                                    </div>

                                   
                                    <div class="p-1 col-12 mb-2">
                                        <p class="m-2 font-weight-bold" style="text-align: left !Important">Note: Supported file Extension(.png,.jpg,.pdf)</p>
                                    </div>

                                    <div class="form-group col-lg-6 mt-2 ">
                                        <div>
                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Government ID</span></span>
                                            </label>
                                            <div class="form-control CH-Size-New">
                                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oFileGovernmentID.ClientID%>').click();" style="font-size: 11px !Important;" />
                                                <%--<label id="_oLblGid" style="font-size: 11px !Important; padding-top: 7px !Important"/>--%>

                                                <asp:UpdatePanel runat="server" ID="upgid" UpdateMode="Conditional" class="float-right">
                                                    <%--Gimay 20201120--%>
                                                    <ContentTemplate>
                                                        <label id="_oLblGid" style="font-size: 11px !Important; padding-top: 7px !Important" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group col-lg-6 mt-2 ">
                                        <div>
                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Special Power of Attorney</span></span>
                                            </label>
                                            <div class="form-control CH-Size-New">
                                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oFileSPA.ClientID%>').click();" style="font-size: 11px !Important;" />
                                                <%--<label id="_oLblSPA" style="font-size: 11px !Important; padding-top: 7px !Important"/>--%>

                                                <asp:UpdatePanel runat="server" ID="upspa" UpdateMode="Conditional" class="float-right">
                                                    <%--Gimay 20201120--%>
                                                    <ContentTemplate>
                                                        <label id="_oLblSPA" style="font-size: 11px !Important; padding-top: 7px !Important" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group col-lg-6 mt-2 ">
                                        <div>
                                            <label class="input-txt input-txt-active2">
                                                <span><span class="m-2">Board Resolution/Secretary Certificate</span></span>
                                            </label>
                                            <div class="form-control CH-Size-New">
                                                <input type="button" value="Choose File" onclick="document.getElementById('<%=_oFileBRSec.ClientID%>').click();" style="font-size: 11px !Important;" />
                                                <%--<label id="_oLblBRSec" style="font-size: 11px !Important; padding-top: 7px !Important"/>--%>

                                                <asp:UpdatePanel runat="server" ID="upbrs" UpdateMode="Conditional" class="float-right">
                                                    <%--Gimay 20201120--%>
                                                    <ContentTemplate>
                                                        <label id="_oLblBRSec" style="font-size: 11px !Important; padding-top: 7px !Important" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="col-sm-6" align="center">
                                        <div class="custom-control custom-checkbox">
                                            <input type="checkbox" class="custom-control-input" id="_oCheckBoxResident" value="ticked" name="_oCheckBoxResident" />
                                            <label runat="server" id="lblLGUNAME" class="custom-control-label font-weight-light text-primary mb-1" for="_oCheckBoxResident">I am a resident of SPIDC</label>
                                        </div>
                                    </div>
                                    <script>
                                        function here(fileno) {
  
                                            if (fileno == 'file1') {
                                                sessionStorage.setItem('file1', document.getElementById('<%=_oFileGovernmentID.ClientID%>').value);
                                                document.getElementById('_oLblGid').innerHTML = sessionStorage.getItem('file1').toString().replace('C:\\fakepath\\', '');
                                            };

                                            if (fileno == 'file2') {
                                                sessionStorage.setItem('file2', document.getElementById('<%=_oFileSPA.ClientID%>').value);
                                              document.getElementById('_oLblSPA').innerHTML = sessionStorage.getItem('file2').toString().replace('C:\\fakepath\\', '');
                                          };

                                          if (fileno == 'file3') {
                                              sessionStorage.setItem('file3', document.getElementById('<%=_oFileBRSec.ClientID%>').value);
                                           document.getElementById('_oLblBRSec').innerHTML = sessionStorage.getItem('file3').toString().replace('C:\\fakepath\\', '');
                                       };

                                            //btnUpdate();
                                       sessionStorage.setItem('_oTextFirstName', document.getElementById('_oTextFirstName').value);
                                       sessionStorage.setItem('_oTextMiddleName', document.getElementById('_oTextMiddleName').value);
                                       sessionStorage.setItem('_oTextLastName', document.getElementById('_oTextLastName').value);      
                                       sessionStorage.setItem('_oTextSuffix', document.getElementById('_oTextSuffix').value);      
                                       sessionStorage.setItem('_oSelectGender', document.getElementById('_oSelectGender').value); 
                                       sessionStorage.setItem('_oTextBirthday', document.getElementById('_oTextBirthday').value);
                                       sessionStorage.setItem('_oTextAddress', document.getElementById('_oTextAddress').value);
                                       sessionStorage.setItem('_oTextBirthAddress', document.getElementById('_oTextBirthAddress').value);
                                       sessionStorage.setItem('_oSelectCitizenship', document.getElementById('_oSelectCitizenship').value);
                                       sessionStorage.setItem('_oSelectCivilStatus', document.getElementById('_oSelectCivilStatus').value);
                                       sessionStorage.setItem('_oTextTIN', document.getElementById('_oTextTIN').value);
                                       sessionStorage.setItem('_oTextContactNumber2', document.getElementById('_oTextContactNumber2').value);
                                       sessionStorage.setItem('_oTextContactNumber3', document.getElementById('_oTextContactNumber3').value);
                                       sessionStorage.setItem('_oTextContactNumber1', document.getElementById('_oTextContactNumber1').value);
                                       sessionStorage.setItem('_oTextHeight', document.getElementById('_oTextHeight').value);
                                       sessionStorage.setItem('_oTextWeight', document.getElementById('_oTextWeight').value);
                                       sessionStorage.setItem('_oTextProfession', document.getElementById('_oTextProfession').value);
                                       sessionStorage.setItem('_oCheckBoxResident', document.getElementById('_oCheckBoxResident').checked);
                                          <%--sessionStorage.setItem('_oCheckBoxResident', document.getElementById('<%=_oChkBoxRes.ClientID%>')value);--%>
                                            sessionStorage.setItem('_oTextAlternateEmail', document.getElementById('_oTextAlternateEmail').value); /*Gimay 20201120*/

                                            //Gimay 20201126
                                            //__doPostBack('Uploadfiles',fileno); c
                                        }

                                        function btnUpdate() {
                                     
                                            var pagebutton = document.getElementById("btnUpdateFiles");
                                            pagebutton.click();

                                            return false;
                                            //document.getElementById('btnUpdateFiles').click(); 
                                        }

                                        function btnClose() {
       
                                            var pagebutton = document.getElementById("btnClose");
                                            pagebutton.click();

                                            return false;
                                            //document.getElementById('btnUpdateFiles').click(); 
                                        }
                                    </script>

                                    <script> //Gimay 20201126
                                        function CheckandSave() {

                                            //document.getElementById('hdnSubmit').value = 1;
                                            sessionStorage.removeItem('file1');
                                            sessionStorage.removeItem('file2');
                                            sessionStorage.removeItem('file3');
                                            here('file99');                                        
                                            document.getElementById('<%=hdnFname.ClientID%>').value = sessionStorage.getItem('_oTextFirstName');
                                            document.getElementById('<%=hdnMname.ClientID%>').value = sessionStorage.getItem('_oTextMiddleName');
                                            document.getElementById('<%=hdnLname.ClientID%>').value = sessionStorage.getItem('_oTextLastName');
                                            document.getElementById('<%=hdnSuffix.ClientID%>').value = sessionStorage.getItem('_oTextSuffix');
                                            document.getElementById('<%=hdnGender.ClientID%>').value = sessionStorage.getItem('_oSelectGender');
                                            document.getElementById('<%=hdnBirthday.ClientID%>').value = sessionStorage.getItem('_oTextBirthday');
                                            document.getElementById('<%=hdnTextAddress.ClientID%>').value = sessionStorage.getItem('_oTextAddress');
                                            document.getElementById('<%=hdnTextBirthAddress.ClientID%>').value = sessionStorage.getItem('_oTextBirthAddress');
                                            document.getElementById('<%=hdnSelectCitizenship.ClientID%>').value = sessionStorage.getItem('_oSelectCitizenship');
                                            document.getElementById('<%=hdnSelectCivilStatus.ClientID%>').value = sessionStorage.getItem('_oSelectCivilStatus');
                                            document.getElementById('<%=hdnTextTIN.ClientID%>').value = sessionStorage.getItem('_oTextTIN');
                                            document.getElementById('<%=hdnTextContactNumber2.ClientID%>').value = sessionStorage.getItem('_oTextContactNumber2');
                                            document.getElementById('<%=hdnTextContactNumber3.ClientID%>').value = sessionStorage.getItem('_oTextContactNumber3');
                                            document.getElementById('<%=hdnTextContactNumber1.ClientID%>').value = sessionStorage.getItem('_oTextContactNumber1');
                                            document.getElementById('<%=hdnTextHeight.ClientID%>').value = sessionStorage.getItem('_oTextHeight');
                                            document.getElementById('<%=hdnTextWeight.ClientID%>').value = sessionStorage.getItem('_oTextWeight');
                                            document.getElementById('<%=hdnTextProfession.ClientID%>').value = sessionStorage.getItem('_oTextProfession');
                                            document.getElementById('<%=hdnCheckBoxResident.ClientID%>').value = sessionStorage.getItem('_oCheckBoxResident');
                                            document.getElementById('<%=hdnTextAlternateEmail.ClientID%>').value = sessionStorage.getItem('_oTextAlternateEmail');                                         
                                            var input = document.getElementsByClassName('required');
                                            var counter = false;
                                            for (var i = 0; i < input.length; i++) {
                                                if(!input[i].value.length > 0)
                                                {                                                
                                                    document.getElementById('<%=_oLabelSnackbar.ClientID%>').innerHTML = "Please fill all Required(*) fields";
                                                Snackbar();
                                                counter = true;
                                                break;
                                            }    
                                        }
                                        if(counter == false)__doPostBack('Uploadfiles'); 
                                    }                                        
                                    </script>

                                    <%-- <script>
                                   function here(fileno){
                                       if(!sessionStorage.getItem('file1'))sessionStorage.setItem('file1',document.getElementById('<%=_oFileGovernmentID.ClientID%>').value);                                       
                                       document.getElementById('_oLblGid').innerHTML = sessionStorage.getItem('file1').toString().replace('C:\\fakepath\\',''); 
                                       if(!sessionStorage.getItem('file2'))sessionStorage.setItem('file2',document.getElementById('<%=_oFileSPA.ClientID%>').value);
                                       document.getElementById('_oLblSPA').innerHTML = sessionStorage.getItem('file2').toString().replace('C:\\fakepath\\',''); 
                                       if(!sessionStorage.getItem('file3'))sessionStorage.setItem('file3',document.getElementById('<%=_oFileBRSec.ClientID%>').value);
                                       document.getElementById('_oLblBRSec').innerHTML = sessionStorage.getItem('file3').toString().replace('C:\\fakepath\\',''); 
                                       sessionStorage.setItem('_oTextFirstName',document.getElementById('_oTextFirstName').value);
                                       sessionStorage.setItem('_oTextMiddleName',document.getElementById('_oTextMiddleName').value);
                                       sessionStorage.setItem('_oTextLastName',document.getElementById('_oTextLastName').value);
                                       sessionStorage.setItem('_oTextSuffix',document.getElementById('_oTextSuffix').value);
                                       sessionStorage.setItem('_oTextBirthday',document.getElementById('_oTextBirthday').value);
                                       sessionStorage.setItem('_oTextAddress',document.getElementById('_oTextAddress').value);              
                                       sessionStorage.setItem('_oTextBirthAddress',document.getElementById('_oTextBirthAddress').value);
                                       sessionStorage.setItem('_oSelectCitizenship',document.getElementById('_oSelectCitizenship').value);
                                       sessionStorage.setItem('_oSelectCivilStatus',document.getElementById('_oSelectCivilStatus').value);
                                       sessionStorage.setItem('_oTextTIN',document.getElementById('_oTextTIN').value);
                                       sessionStorage.setItem('_oTextContactNumber2',document.getElementById('_oTextContactNumber2').value);
                                       sessionStorage.setItem('_oTextContactNumber3',document.getElementById('_oTextContactNumber3').value);
                                       sessionStorage.setItem('_oTextContactNumber1',document.getElementById('_oTextContactNumber1').value);
                                       sessionStorage.setItem('_oTextHeight',document.getElementById('_oTextHeight').value);
                                       sessionStorage.setItem('_oTextWeight',document.getElementById('_oTextWeight').value);
                                       sessionStorage.setItem('_oTextProfession',document.getElementById('_oTextProfession').value);
                                       sessionStorage.setItem('_oCheckBoxResident',document.getElementById('_oCheckBoxResident').value);
                                       __doPostBack('Uploadfiles',fileno);                                       
                                   }
                               </script> --%>
                                </div>
                            </div>
                            <hr />
                            <center>
                            <div class="form-group col-md-10" style="text-align-last: justify; color: blue">
                           <label class="container">
  <input type="checkbox" id="chk_auth" onclick="do_chk(this.checked)">
  <span class="checkmark"></span>
&nbsp  I certify to the best of my knowledge under penalty of perjury that the 
                                    information I have provided is true and correct. 
                                    I understand that any inaccurate, false, or missing 
                                    information may invalidate my application.<br />
</label>
                                
                                  
                            </div>
                            
                                  <div class="form-row col-md-8">
                               <button class="btn btn-danger form-group col-md-5"  type="button" data-dismiss="modal" onclick="btnClose();">Close</button>
                            <div class="form-group col-md-1"></div>
                                 <button class="btn btn-success form-group col-md-5" disabled id="_oBtnSaveChanges" type="button" onclick="CheckandSave();">Save changes</button>
                                             
                               </div>
                            </center>

                            <input type="hidden" id="hdnSubmit" name="hdnSubmit" value="0" />
                        </form>

                        <input type="file" runat="server" class="form-control CH-Size-New" style="display: none" id="_oFileSPA" onchange=" here('file2');" accept="APPLICATION/PDF,IMAGE/PNG,IMAGE/JPEG,TEXT/PLAIN" />
                        <input type="file" runat="server" class="form-control CH-Size-New" style="display: none" id="_oFileGovernmentID" onchange=" here('file1');" accept="APPLICATION/PDF,IMAGE/PNG,IMAGE/JPEG,TEXT/PLAIN" />
                        <input type="file" runat="server" class="form-control CH-Size-New" style="display: none" id="_oFileBRSec" onchange=" here('file3');" accept="APPLICATION/PDF,IMAGE/PNG,IMAGE/JPEG,TEXT/PLAIN" />
                        <asp:HiddenField runat="server" ID="HiddenField1" />

                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="_oChkBoxRes" />
    </div>


    <%--20201126--%>
    <asp:HiddenField runat="server" ID="hdnFname" />
    <asp:HiddenField runat="server" ID="hdnMname" />
    <asp:HiddenField runat="server" ID="hdnLname" />
    <asp:HiddenField runat="server" ID="hdnSuffix" />
    <asp:HiddenField runat="server" ID="hdnGender" />
    <asp:HiddenField runat="server" ID="hdnBirthday" />
    <asp:HiddenField runat="server" ID="hdnTextAddress" />
    <asp:HiddenField runat="server" ID="hdnTextBirthAddress" />
    <asp:HiddenField runat="server" ID="hdnSelectCitizenship" />
    <asp:HiddenField runat="server" ID="hdnSelectCivilStatus" />
    <asp:HiddenField runat="server" ID="hdnTextTIN" />
    <asp:HiddenField runat="server" ID="hdnTextContactNumber2" />
    <asp:HiddenField runat="server" ID="hdnTextContactNumber3" />
    <asp:HiddenField runat="server" ID="hdnTextContactNumber1" />
    <asp:HiddenField runat="server" ID="hdnTextHeight" />
    <asp:HiddenField runat="server" ID="hdnTextWeight" />
    <asp:HiddenField runat="server" ID="hdnTextProfession" />
    <asp:HiddenField runat="server" ID="hdnCheckBoxResident" />
    <asp:HiddenField runat="server" ID="hdnTextAlternateEmail" />


    <script>

      
        function do_chk(val){
            switch (val){
                case true:
                    document.getElementById('_oBtnSaveChanges').disabled=false;
                    break;
                case false:
                    document.getElementById('_oBtnSaveChanges').disabled=true;
                    break;

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

        function chkboxRes() {
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

        document.getElementById('_oTextFirstName').value = "<%=getFirstName%>";
            document.getElementById('_oTextLastName').value = "<%=getLastName%>";
        document.getElementById('_oTextMiddleName').value = "<%=getMiddleName%>";
        document.getElementById('_oTextSuffix').value = "<%=getSuffix%>";
        document.getElementById('_oSelectGender').value = gen;
        document.getElementById('_oSelectCitizenship').value = cit;
        document.getElementById('_oTextBirthday').value = "<%=getBirthDate%>";
            document.getElementById('_oSelectCivilStatus').value = document.getElementById('<%=_oLabelCivilStatus.ClientID%>').innerText;
        document.getElementById('_oTextProfession').value = document.getElementById('<%=_oLabelProfession.ClientID%>').innerText;
        document.getElementById('_oTextAddress').value = document.getElementById('<%=_oLabelAddress.ClientID%>').innerText;
        document.getElementById('_oTextBirthAddress').value = document.getElementById('<%=_oLabelBirthPlace.ClientID%>').innerText;
        document.getElementById('_oTextTIN').value = document.getElementById('<%=_oLabelTIN.ClientID%>').innerText;
        document.getElementById('_oTextContactNumber1').value = document.getElementById('<%=_oLabelContactNumber1.ClientID%>').innerText;
        document.getElementById('_oTextContactNumber2').value = document.getElementById('<%=_oLabelContactNumber2.ClientID%>').innerText;
        document.getElementById('_oTextContactNumber3').value = document.getElementById('<%=_oLabelContactNumber3.ClientID%>').innerText;
        document.getElementById('_oTextHeight').value = document.getElementById('<%=_oLabelHeight.ClientID%>').innerText;
        document.getElementById('_oTextWeight').value = document.getElementById('<%=_oLabelWeight.ClientID%>').innerText;
        document.getElementById('_oTextAlternateEmail').value = document.getElementById('<%=_oLabelAlternateEmail.ClientID%>').innerText;
        //ClickEdit();
        var RegMode = sessionStorage.getItem('RegMode');
        //alert(RegMode);
        //  alert(sessionStorage.getItem('RegMode'));
        if (RegMode == 'OAIMS'|| RegMode=='CBP') {

            try {
                var Citizenship =  sessionStorage.getItem('AR_nationality');
                document.getElementById("_oSelectCitizenship").value = Citizenship.toLowerCase();
                //alert(sessionStorage.getItem('AR_nationality'));
                //alert( document.getElementById("_oSelectCitizenship").value);
                document.getElementById("_oSelectGender").value = sessionStorage.getItem('AR_sex');
                //alert(sessionStorage.getItem('AR_sex'));        
          
                document.getElementById("_oTextTIN").value = sessionStorage.getItem('AR_tin_number');
                //alert(sessionStorage.getItem('AR_tin_number'));
                document.getElementById("_oTextContactNumber2").value = sessionStorage.getItem('AR_mobile_no');
                //alert(sessionStorage.getItem('AR_mobile_no'));
                document.getElementById("_oTextContactNumber1").value = sessionStorage.getItem('AR_telephone_number');
                //alert(sessionStorage.getItem('AR_telephone_number'));
                document.getElementById("_oTextAlternateEmail").value = sessionStorage.getItem('AR_alternate_email_address');
                //alert(sessionStorage.getItem('AR_alternate_email_address'));
                        
                var date = new Date(sessionStorage.getItem('AR_birthday'));
                var day = date.getDate();
                var month = date.getMonth() + 1;
                var year = date.getFullYear();
                
                if (month.toString().length < 2) 
                    month = '0' + month;
                if (day.toString().length < 2) 
                    day = '0' + day;

                //alert(day);
                //alert(month);
                //alert(year);

                var bDate  = year + "-" + month + "-" + day;
                document.getElementById('_oTextBirthday').value  = bDate;
                //alert(sessionStorage.getItem('AR_birthday').toString());
                //alert(document.getElementById("_oTextBirthday").value);
                //alert(bDate);
            }
            catch(err) {
                alert(err.message);
            }
     

            document.getElementById('_oLblGid').innerHTML = "<%=getGID%>";
                document.getElementById('_oLblSPA').innerHTML = "<%=getSPA%>";
                document.getElementById('_oLblBRSec').innerHTML = "<%=getBRSec%>";

                sessionStorage.setItem('GIDName') = "";
                sessionStorage.setItem('SPAName') = "";
                sessionStorage.setItem('BRSecName') = "";
                sessionStorage.setItem('GIDChanged') = False;
                sessionStorage.setItem('SPAChanged') = False;
                sessionStorage.setItem('BRSecChanged') = False;
            }
        }
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

        function ShowPopup() {    
            retrieveInfo()
            $("#myModal").modal("show");
        }


    </script>
    <script>
        window.onbeforeunload = confirmExit;
        function confirmExit()
        {
            __doPostBack("Reset","");
        }
    </script>

</asp:Content>
