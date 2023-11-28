

<%@ 
    Page Title="" Language="vb" AutoEventWireup="false" 
    MasterPageFile="~/WebPortal/BPLOMaster.Master" CodeBehind="BPLTIMS_BPLOReview.aspx.vb" 
    Inherits="SPIDC.BPLTIMS_BPLOReview" EnableEventValidation="false"
%>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
     
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
<style>
.accordion {
      content: '\002B';
  background-color: #eee;
  color: #444;
  cursor: pointer;
  padding: 10px;
  width: 100%;
  border: none;
  text-align: center;
  outline: none;
  transition: 0.4s;
}

.active, .accordion:hover {
  background-color: #ccc; 
}

.panel {
  padding: 0 18px;
  display: none;
  background-color: white;
  overflow: hidden;
  width: 100%;
}

    .ButtonCss:disabled {
        opacity:0.5;
        cursor:not-allowed;
    }
      .ButtonCss:enabled {
        opacity:1;
        cursor:default;
        }

</style>

    
    <script src="../CSS_JS_IMG/js/jquery-1.8.3.min.js"></script>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>

    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", src = "../CSS_JS_IMG/img/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../CSS_JS_IMG/img/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
    <script src="../CSS_JS_IMG/js/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../CSS_JS_IMG/js/jquery-1.8.3.min.js"></script>
<%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
<script type="text/javascript">
    $(function () {
        $("[id*=_oGridViewBusLine]").find("[id*=_oButtonBuslineEdit]").click(function () {
            //Reference the GridView Row.
            var row = $(this).closest("tr");

            //Determine the Row Index.
            var message = "Row Index: " + (row[0].rowIndex - 1);
            //Read values from Cells.
            var BusCode = row.find("td").eq(0)[0].innerText;
            var Desc = row.find("td").eq(1)[0].innerText;
            var Year = row.find("td").eq(2)[0].innerText;
            var Capital = row.find("td").eq(4)[0].innerText;
            var Area = row.find("td").eq(5)[0].innerText;


            // Display the data using JavaScript Alert Message Box.
            // alert(message);
            document.getElementById('<%=_oBusinessLineCode.ClientID%>').value = BusCode;
            document.getElementById('<%=_oBusinessLineForYear.ClientID%>').value = Year;
            document.getElementById('<%=_oBusinessLineDesc.ClientID%>').value = Desc;
            document.getElementById('<%=_oBusinessLineCapital.ClientID%>').value = Capital;
            document.getElementById('<%=_oBusinessLineTextArea.ClientID%>').value = Area;
            document.getElementById('<%=_oBusinessLineTextArea.ClientID%>').value = Area;

            return false;
        });
    });

    $(function () {
        $("[id*=_oGridViewBusLine]").find("[id*=_ImgBtnBuslineRemove]").click(function () {
            //Reference the GridView Row.
            var row = $(this).closest("tr");

            //Determine the Row Index.

            //Read values from Cells.
            var BusCode = row.find("td").eq(0)[0].innerText;
            var Desc = row.find("td").eq(1)[0].innerText;
            var Year = row.find("td").eq(2)[0].innerText;
            // Display the data using JavaScript Alert Message Box.
            // alert(message);
            document.getElementById('<%=_oTextboxBusinessLineBusCodeRemove.ClientID%>').value = BusCode;
            document.getElementById('<%=_oTextboxBusinessLineDescRemove.ClientID%>').value = Desc;
            document.getElementById('<%=_oTextboxBusinessLineYearRemove.ClientID%>').value = Year;

            return false;
        });
    });


    $(function () {
        $("[id*=_oGridViewBusLine]").find("[id*=_ImgBtnBuslineProcess]").click(function () {
            //Reference the GridView Row.
            var row = $(this).closest("tr");

            //Determine the Row Index.

            //Read values from Cells.
            var BusCode = row.find("td").eq(0)[0].innerText;
            var Desc = row.find("td").eq(1)[0].innerText;
            var Year = row.find("td").eq(2)[0].innerText;
            var Capital = row.find("td").eq(4)[0].innerText;
            var Area = row.find("td").eq(5)[0].innerText;
            // Display the data using JavaScript Alert Message Box.
            // alert(message);
            document.getElementById('<%=_oTextboxBusinessLineBusCodeCompute.ClientID%>').value = BusCode;
            document.getElementById('<%=_oTextboxBusinessLineDescCompute.ClientID%>').value = Desc;
            document.getElementById('<%=_oTextboxBusinessLineYearCompute.ClientID%>').value = Year;
            document.getElementById('<%=_oTextboxBusinessLineCapitalCompute.ClientID%>').value = Capital;
            document.getElementById('<%=_oTextboxBusinessLineAreaCompute.ClientID%>').value = Area;


            return false;
        });
    });


    function GetRemark() {

        var Remarks = document.getElementById('<%=_oDDL_Remarks.ClientID%>').value
        document.getElementById('<%=_oTextboxRemarks.ClientID%>').value = '" ' + Remarks + ' "'
    };

</script>
   

   <%-- <script type="text/javascript">
        function CheckOtherIsCheckedByGVID(spanChk) {
            var IsChecked = spanChk.checked;
            if (IsChecked) {
                // spanChk.parentElement.parentElement.style.backgroundColor = '#66FFCC';
                // spanChk.parentElement.parentElement.style.color = 'white';
            }
            var CurrentRdbID = spanChk.id;
            var Chk = spanChk;
            Parent = document.getElementById("<%=_oGridViewOption.ClientID%>");
            var items = Parent.getElementsByTagName('input');
            for (i = 0; i < items.length; i++) {
                if (items[i].id != CurrentRdbID && items[i].type == "radio") {
                    if (items[i].checked) {
                        items[i].checked = false;
                        //  items[i].parentElement.parentElement.style.backgroundColor = 'white'
                        //  items[i].parentElement.parentElement.style.color = 'black';
                    }
                }
            }
        }
</script>  --%>

 
    <%--handles numeric validation--%>
     <script type="text/javascript">
         function FormatCurrency(ctrl) {
             //Check if arrow keys are pressed - we want to allow navigation around textbox using arrow keys
             if (event.keyCode == 37 || event.keyCode == 16 || event.keyCode == 38 || event.keyCode == 39 || event.keyCode == 40) {
                 return;
             }

             var val = ctrl.value;

             val = val.replace(/,/g, "")
             ctrl.value = "";
             val += '';
             x = val.split('.');
             x1 = x[0];
             x2 = x.length > 1 ? '.' + x[1] : '';

             var rgx = /(\d+)(\d{3})/;

             while (rgx.test(x1)) {
                 x1 = x1.replace(rgx, '$1' + ',' + '$2');
             }

             ctrl.value = x1 + x2;

         };

         function validate(evt) {
             var theEvent = evt || window.event;

             // Handle paste
             if (theEvent.type === 'paste') {
                 key = event.clipboardData.getData('text/plain');
             } else {
                 // Handle key press
                 var key = theEvent.keyCode || theEvent.which;
                 key = String.fromCharCode(key);
             }
             var regex = /[0-9]|\./;
             if (!regex.test(key)) {
                 theEvent.returnValue = false;
                 if (theEvent.preventDefault) theEvent.preventDefault();
             }
         };
        </script>
    <%------------------------------%>

      <center> 

          <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div class="">
           
          <div class="col-md-12 mt-1" style="font-size:12px;">
      

      <div>
                <asp:HiddenField id="hdnScrollPos" runat="server"/> 
                <input type="hidden" id="_oHidden_Capital" runat="server"  />
                <input type="hidden" id="_oHidden_GroupCd" runat="server" />
      </div>

		  
              <div class="card shadow">
       <label class="text-sm font-weight-bold text-primary text-uppercase mb-1 d-flex align-content-between justify-content-between card-header">NEW BUSINESS REVIEW </label>
   
       <center>           
    <input type="button" class="accordion btn btn-primary m-2 col-10" value="Business Information" style="color:white !Important;"/>
    <div class="panel col-10" style="text-align:left">
        <div>
        <div >

     <p> <b>Business Details</b></p>
       <div id="DateEstablished" runat="server">            
            <asp:Label runat="server" Width="25%" Text="Date Established" />                <asp:Label ID="_oLabelDateEstablish" runat="server" Text="--" />   <br />
       </div>

        <div id="OwnershipType" runat="server">
            <asp:Label ID="_oLabel1" runat="server" Width="25%" Text=" Ownership Type" />     <asp:Label ID="_oLabelOwnership" runat="server" Text="--" />   <br />
       </div>

        <div id="BusinessName" runat="server">
        <asp:Label ID="_oLabel2" runat="server" Width="25%" Text=" Business Name" />       <asp:Label ID="_oLabelBusinessName" runat="server" Text="--" />   <br />
       </div>

        <div id="BusinessAddress" runat="server">
        <asp:Label ID="_oLabel3" runat="server" Width="25%" Text=" Business Address" />    <asp:Label ID="_oLabelCommAdd" runat="server" Text="--" />   <br />
       </div>

        <div id="District" runat="server">
       <asp:Label ID="_oLabel4" runat="server" Width="25%" Text=" District" />            <asp:Label ID="_oLabelDistrict" runat="server" Text="--" />   <br />
       </div>

       <div id="StickerNum" runat="server">
            <asp:Label ID="_oLabel5" runat="server" Width="25%" Text=" Sticker Number" />      <asp:Label ID="_oLabelStickerNo" runat="server" Text="--" />   <br />
       </div>

        <div id="Barangay" runat="server">
       <asp:Label ID="_oLabel6" runat="server" Width="25%" Text=" Barangay:" />           <asp:Label ID="_oLabelBarangay" runat="server" Text="--" />   <br />
       </div>

        <div id="Street" runat="server">
        <asp:Label ID="_oLabel7" runat="server" Width="25%" Text=" Street:" />             <asp:Label ID="_oLabelStreet" runat="server" Text="--" />   <br />
       </div>

       <div id="GrpBldg" runat="server">
            <asp:Label ID="_oLabel8" runat="server" Width="25%" Text=" Group/Building" />      <asp:Label ID="_oLabelGrpBldg" runat="server" Text="--" />   <br />
       </div>
       <div id="PlateNo" runat="server">
            <asp:Label ID="_oLabel13" runat="server" Width="25%" Text=" Plate No." />          <asp:Label ID="_oLabelPlateNo" runat="server" Text="--" />   <br />
       </div>
       <div id="StallNo" runat="server">    
             <asp:Label ID="_oLabel14" runat="server" Width="25%" Text=" Stall No." />          <asp:Label ID="_oLabelStallNo" runat="server" Text="--" />   <br />
        </div>
      <br />

      <p> <b>Number of Employees</b></p> 
             
        <div id="Male" runat="server"> 
      <asp:Label ID="_oLabel10" runat="server" Width="25%" Text="Male" />             <asp:Label ID="_oLabelMale" runat="server" Text="--" />   <br />
      </div>

      <div id="Female" runat="server"> 
        <asp:Label ID="_oLabel11" runat="server" Width="25%" Text="Female" />          <asp:Label ID="_oLabelFemale" runat="server" Text="--" />   <br />
      </div>

        <div id="Resident" runat="server"> 
        <asp:Label ID="_oLabel12" runat="server" Width="25%" Text="Residing in LGU" />  <asp:Label ID="_oLabelLGURes" runat="server" Text="--" />   <br />
       </div>
        <br />

       <p> <b>Lessor Details </b></p>
       <div id="LessorFullName" runat="server"> 
       <asp:Label ID="_oLabel16" runat="server" Width="25%" Text="  Full Name" />         <asp:Label ID="_oLabelLessorName" runat="server" Text="--" />   <br />
       </div>
       <div id="LessorAddress" runat="server">
       <asp:Label ID="_oLabel17" runat="server" Width="25%" Text="  Address" />           <asp:Label ID="_oLabelLessorAddress" runat="server" Text="--" />   <br />
       </div>
       <div id="Administrator" runat="server">
       <asp:Label  runat="server" Width="25%" Text="  Administrator" />                   <asp:Label ID="_oLabelAdmin" runat="server" Text="--" />   <br />
       </div>
       <div id="DateRented" runat="server">
       <asp:Label ID="_oLabel18" runat="server" Width="25%" Text=" Date Rented" />        <asp:Label ID="_oLabelDateRented" runat="server" Text="--" />   <br />
       </div>
       <div id="LessorTelNo" runat="server">
       <asp:Label ID="_oLabel19" runat="server" Width="25%" Text=" Telephone No." />      <asp:Label ID="_oLabelLessorTelNo" runat="server" Text="--" />   <br />
       </div>
       <div id="RentPerMonth" runat="server">
       <asp:Label ID="_oLabel20" runat="server" Width="25%" Text=" Rent Per Month" />     <asp:Label ID="_oLabelRentPerMonth" runat="server" Text="--" />   <br />
       </div>
       <div id="EmailAddress" runat="server">
       <asp:Label ID="_oLabel21" runat="server" Width="25%" Text=" Email Address" />      <asp:Label ID="_oLabelLessorEmailAdd" runat="server" Text="--" />   <br />
       </div>
      </div>
      </div>
    </div>

   
     <input type="button" class="accordion btn btn-primary m-2 col-10" value="Tax Payer's Information" style="color:white !important;"/>
    <div class="panel col-10" style="text-align:left">
         <div>
     <p> <b>Owner Details</b></p>
       <div id="OwnerFullName" runat="server">
       <asp:Label ID="_oLabel40" runat="server" Width="25%" Text="Full Name" />           <asp:Label ID="_oLabelOwnerName" runat="server" Text="--" />   <br />
       </div>
       <div id="OwnerCitizenship" runat="server">
       <asp:Label ID="_oLabel41" runat="server" Width="25%" Text="Citizenship" />      <asp:Label ID="_oLabelCitizenship" runat="server" Text="--" />   <br />
       </div>
       <div id="OwnerGender" runat="server">
       <asp:Label ID="_oLabel43" runat="server" Width="25%" Text="Gender" />       <asp:Label ID="_oLabelGender" runat="server" Text="--" />   <br />
       </div>
       <div id="OwnerAddress" runat="server">
       <asp:Label ID="_oLabel45" runat="server" Width="25%" Text="Address" />    <asp:Label ID="_oLabelOwnerAddress" runat="server" Text="--" />   <br />
       </div>
       <div id="OwnerTelNo" runat="server">
       <asp:Label ID="_oLabel47" runat="server" Width="25%" Text="Telephone No." />            <asp:Label ID="_oLabelTelNo" runat="server" Text="--" />   <br />
       </div>
       <div id="OwnerEmailAddress" runat="server">
       <asp:Label ID="_oLabel49" runat="server" Width="25%" Text="Email Address" />      <asp:Label ID="_oLabelEmail" runat="server" Text="--" />   <br />
       </div>
       <asp:Label ID="_oLabel51" runat="server" Width="25%" Text="Alternative Email" />           <asp:Label ID="_oLabelAltEmail" runat="server" Text="--" />   <br />
      
      <div style="display:none;">
         <p> <b>Contact Person Details </b></p>
         <asp:Label ID="_oLabel68" runat="server" Width="25%" Text="Name" />         <asp:Label ID="_oLabelContactName" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel70" runat="server" Width="25%" Text="Telephone No." />           <asp:Label ID="_oLabelContactTelNo" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel72" runat="server" Width="25%" Text="Globe/TM" />        <asp:Label ID="_oLabelContactGlobeTM" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel74" runat="server" Width="25%" Text="Smart/TNT" />      <asp:Label ID="_oLabelContactSmartTNT" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel76" runat="server" Width="25%" Text="Sun" />     <asp:Label ID="_oLabelContactSun" runat="server" Text="--" />   <br />
          <p> <b>Emergency Contact Person Details </b></p>
         <asp:Label ID="_oLabel53" runat="server" Width="25%" Text="Name" />         <asp:Label ID="_oLabelE_ContactName" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel55" runat="server" Width="25%" Text="Telephone No." />           <asp:Label ID="_oLabelE_ContactTelNo" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel57" runat="server" Width="25%" Text="Mobile Number" />        <asp:Label ID="_oLabelE_ContactMobileNo" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel59" runat="server" Width="25%" Text="Email Address" />      <asp:Label ID="_oLabelE_EmailAdd" runat="server" Text="--" />   <br />
         <p> <b>Additional Information </b></p>
         <asp:Label ID="_oLabel61" runat="server" Width="25%" Text="Treasurer's Name" />         <asp:Label ID="_oLabelTreasurer" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel63" runat="server" Width="25%" Text="Authorized Rep." />           <asp:Label ID="_oLabelRep" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel65" runat="server" Width="25%" Text="Position" />        <asp:Label ID="_oLabelRepPos" runat="server" Text="--" />   <br />
         <asp:Label ID="_oLabel67" runat="server" Width="25%" Text="Tax Incentives" />      <asp:Label ID="_oLabelTaxIncentives" runat="server" Text="--" />   <br />
      </div>       

      </div>
    </div>
                    
    <input type="button" class="accordion btn btn-primary m-2 col-10" value="Government Registration" style="color:white !Important;"/>
    <div class="panel col-10" style="text-align:left">
         <div>
       <asp:Label ID="_oLabel96" runat="server" style="float:right" Width="33%" Text="Registration Date" /> <br />
       <div id="TIN" runat="server">
       <asp:Label ID="_oLabel9" runat="server" Width="30%" Text="TIN" />              <asp:Label ID="_oLabelTIN" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelTINDate" Width="39%" style="float:right" runat="server" Text="--" />   <br />
       </div>
       <div id="DTI" runat="server">
       <asp:Label ID="_oLabel82" runat="server" Width="30%" Text="DTI" />             <asp:Label ID="_oLabelDTI" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelDTIDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="SEC" runat="server">
       <asp:Label ID="_oLabel84" runat="server" Width="30%" Text="SEC" />             <asp:Label ID="_oLabelSEC" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelSECDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="SSS" runat="server">
       <asp:Label ID="_oLabel86" runat="server" Width="30%" Text="SSS" />             <asp:Label ID="_oLabelSSS" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelSSSDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="BrgyClearance" runat="server">
       <asp:Label ID="_oLabel88" runat="server" Width="30%" Text="Brgy Clearance" />  <asp:Label ID="_oLabelBrgyClearance" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelBrgyClearanceDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="PEZA" runat="server">
       <asp:Label ID="_oLabel90" runat="server" Width="30%" Text="PEZA" />            <asp:Label ID="_oLabelPEZA" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelPEZADate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="ARC" runat="server">
       <asp:Label ID="_oLabel92" runat="server" Width="30%" Text="ARC" />             <asp:Label ID="_oLabelARC" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelARCDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="BldgNo" runat="server">
       <asp:Label ID="_oLabel105" runat="server" Width="30%" Text="Building Number" />  <asp:Label ID="_oLabelBldgNo" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelBldgNoDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="CertOccupancy" runat="server">
       <asp:Label ID="_oLabel108" runat="server" Width="30%" Text="Certificate of Occupancy" />            <asp:Label ID="_oLabelCertificate" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelCertificateDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="BOI" runat="server">
       <asp:Label ID="_oLabel111" runat="server" Width="30%" Text="BOI Registration No." />             <asp:Label ID="_oLabelBOI" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelBOIDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="CDA" runat="server">
       <asp:Label ID="_oLabel114" runat="server" Width="30%" Text="CDA Registration No." />             <asp:Label ID="_oLabelCDA" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelCDADate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="CTC" runat="server">
       <asp:Label ID="_oLabel117" runat="server" Width="30%" Text="CTC Registration No." />             <asp:Label ID="_oLabelCTCReg" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelCTCRegDate" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="CTCPlace" runat="server">
       <asp:Label ID="_oLabel120" runat="server" Width="30%" Text="CTC Place" />             <asp:Label ID="_oLabelCTCPlace" Width="25%" runat="server" Text="--" /> <asp:Label ID="_oLabelCTCPlaceAmt" Width="39%" style="float:right" runat="server" Text="--" />  <br />
       </div>
       <div id="PBN" runat="server">
       <asp:Label ID="_oLabel123" runat="server" Width="30%" Text="PBN" />             <asp:Label ID="_oLabelPBN" Width="25%" runat="server" Text="--" /> 
       </div>
      </div>
    </div>
    
    <input type="button" class="accordion btn btn-primary m-2 col-10" value="Image Attachment" style="color:white !important;"/> 
         <div class="panel col-10">
           <div>
        
               <br />
             <asp:Panel runat="server" Style="text-align: left">
               
           
                 <asp:Panel runat="server" Style="display: inline-block" Width="80%">
                     <asp:HyperLink ID="_oHyperLinkowner" runat="server" Target="_blank"> View Owner's picture </asp:HyperLink>
                     &nbsp
                 </asp:Panel>
              
                 <hr />
               
                 <asp:Panel runat="server" Style="display: inline-block" Width="80%">
                     <asp:HyperLink ID="_oHyperLinkestablishment" runat="server" Target="_blank" > View Establishment picture</asp:HyperLink>
                     &nbsp
                 </asp:Panel>
            
                 <hr />
                
           
                 <asp:Panel ID="Panel12" runat="server" Style="display: inline-block" Width="80%">
                     <asp:HyperLink ID="_oHyperLinkmaplocation" runat="server" Target="_blank" > View Map location picture </asp:HyperLink>
                     &nbsp
                 </asp:Panel>
                
                 <br />
             </asp:Panel>
               <br />
               
         </div>
    </div>
    
    <input type="button" class="accordion btn btn-primary m-2 col-10" value="Requirement Submitted" style="color:white !important;"/> 
         <div class="panel col-11">
        <div>
             <div id="_oDiv_oGridviewRequirements" style="width: 90%;">
                    <asp:GridView ID="_oGridviewRequirements" runat="server" Width="90%" AutoGenerateColumns="false" GridLines="None"
                                 DataKeyNames="ReqCode"  OnRowDataBound="OnRowDataBound" CssClass="mgrid">
                           <Columns>
                                
                                <asp:TemplateField>
                               <ItemTemplate>
                                     <img alt="" style="cursor: pointer" src="../CSS_JS_IMG/img/plus.png" />
                                         <asp:Panel ID="pnl_oGridviewReqSubmitted" runat="server" style="display:none">
                                                    <asp:GridView ID="_oGridviewReqSubmitted" runat="server" DataKeyNames="ReqCode" AutoGenerateColumns="false" GridLines="None" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="ReqCode" HeaderText="ReqCode" Visible="false" />
                                                            <asp:BoundField DataField="ImagesID" HeaderText="ImageID" Visible="false" />
                                                            <asp:BoundField DataField="Name" HeaderText="File Name" Visible="false" />
                                                              <asp:TemplateField HeaderText="File Submitted">
                                                                <ItemTemplate>
                                                                    <asp:hyperlink ID="_oHyperLinkReqSubmitted" runat="server" Target="_blank" Enabled ="True" 
                                                                        NavigateUrl= '<%# Eval("ImageID", "viewimage/ViewImage.aspx?Id={0}&Switch=B")%>'
                                                                        Text='<%# Eval("Name")%>'> </asp:hyperlink>
                                                                </ItemTemplate>
                                                                <ItemStyle />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                          </asp:Panel>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="ReqDesc" HeaderText="Requirements" />
                           </Columns>
                     

                    </asp:GridView>
             </div>
        </div>
    </div>
          <br />
    <div style="display:none;">   <%--@Modidified 20211029--%>
        <hr />
          <%--ANNUAL INSFECTION FEES--%>
        
        <div>
            <h4>Regulatory Fees</h4>
            <div>
                <div style="display:none">
                     <input type="text" runat="server" id="_oTxtHiddenZONE" />   
                     <input type="text" runat="server" id="_oTxtHiddenPNP" />   
                     <input type="text" runat="server" id="_oTxtHiddenRTC" />   
                     <input type="text" runat="server" id="_oTxtHiddenFISCAL" />   
                     <input type="text" runat="server" id="_oTxtHiddenMEDICAL" />   
                     <input type="text" runat="server" id="_oTxtHiddenWMEASURES" /> 
                     <input type="text" runat="server" id="_oTxtHiddenSTICKER" />   
                     <input type="text" runat="server" id="_oTxtHiddenBUILDING" />  
                     <input type="text" runat="server" id="_oTxtHiddenMECHANICAL" />
                     <input type="text" runat="server" id="_oTxtHiddenPLUMBING" />  
                     <input type="text" runat="server" id="_oTxtHiddenELECTRICAL" />
                     <input type="text" runat="server" id="_oTxtHiddenSIGNBILL" />  
                     <input type="text" runat="server" id="_oTxtHiddenFIRECODE" />  
                     <input type="text" runat="server" id="_oTxtHiddenOTHER" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF1" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF2" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF3" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF4" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF5" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF6" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF7" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF8" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF9" />   
                     <input type="text" runat="server" id="_oTxtHiddenRF10" />  
                     <input type="text" runat="server" id="_oTxtHiddenRF11" />  
                     <input type="text" runat="server" id="_oTxtHiddenRF12" />  
                     <input type="text" runat="server" id="_oTxtHiddenRF13" />  
                     <input type="text" runat="server" id="_oTxtHiddenRF14" />  
                     <input type="text" runat="server" id="_oTxtHiddenRF15" />  
                     <input type="text" runat="server" id="_oTxtHiddenRF16" />
                </div>
                <%--REGULATORY FEES--%>
                    <asp:Panel runat="server" ID="_oPanelRegulatory" Enabled="false">
                            <div class="container" >
                     <%--ROW 1--%>
                    <div class="form-row">
                        <div class="form-group col-md-3" style="text-align: left;">

                           <%-- ZONE FEE--%>
                            <asp:Label ID="_oLabelZONE" runat="server" Text="ZONE FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtZONE" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                          <%--  FIRE FEE--%>
                            <asp:Label ID="_oLabelRF2" runat="server" Text="FIRE FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF2" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                         <div class="form-group col-md-3" style="text-align: left;">
                           <%-- POLICE CLEARANCE--%>
                             <asp:Label ID="_oLabelPNP" runat="server" Text="POLICE CLEARANCE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtPNP" placeholder="0.00"  onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                           <%-- WP-MAYOR'S PERMIT--%>
                            <asp:Label ID="_oLabelRF3" runat="server" Text=" WP-MAYOR'S PERMIT"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF3" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                    </div>
                     <%--ROW 2--%>
                    <div class="form-row">
                        <div class="form-group col-md-3" style="text-align: left;">
                           <%-- RTC CLEAREANCE FEE--%>
                            <asp:Label ID="_oLabelRTC" runat="server" Text="RTC CLEAREANCE FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRTC" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                           <%-- WP-HEALTH CERTIFICATE--%>
                            <asp:Label ID="_oLabelRF4" runat="server" Text="WP-HEALTH CERTIFICATE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF4" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                         <div class="form-group col-md-3" style="text-align: left;">
                            <%--FISCAL CLEARANCE--%>
                             <asp:Label ID="_oLabelFISCAL" runat="server" Text="FISCAL CLEARANCE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtFISCAL" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                          <%-- WP-PROCESSING FEE--%>
                            <asp:Label ID="_oLabelRF5" runat="server" Text="WP-PROCESSING FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF5" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                    </div>
                     <%--ROW 3--%>
                    <div class="form-row">
                       
                         <div class="form-group col-md-3" style="text-align: left;">
                            <%--MEDICAL FEE--%>
                             <asp:Label ID="_oLabelMEDICAL" runat="server" Text="MEDICAL FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtMEDICAL" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                          <%-- TRANSFER--%>
                            <asp:Label ID="_oLabelRF6" runat="server" Text="TRANSFER"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF6" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                         <div class="form-group col-md-3" style="text-align: left;">
                           <%-- WEIGHT MEASURES--%>
                             <asp:Label ID="_oLabelWMEASURES" runat="server" Text="WEIGHT MEASURES"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtWMEASURES" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                            <%--ENVT. PROT. INSP. FEE--%>
                            <asp:Label ID="_oLabelRF7" runat="server" Text="ENVT. PROT. INSP. FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF7" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                    </div>
                     <%--ROW 4--%>
                    <div class="form-row">
                       <div class="form-group col-md-3" style="text-align: left;">
                           <%-- STICKER/PLATE FEES--%>
                           <asp:Label ID="_oLabelSTICKER" runat="server" Text="STICKER/PLATE FEES"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtSTICKER" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                            <%--RF8--%>
                            <asp:Label ID="_oLabelRF8" runat="server" Text="RF8"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF8" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                        <div class="form-group col-md-3" style="text-align: left;">
                            <%--BUILDING FEE--%>
                            <asp:Label ID="_oLabelBUILDING" runat="server" Text="BUILDING FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtBUILDING" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                            <%--PROCESSING FEE--%>
                            <asp:Label ID="_oLabelRF9" runat="server" Text="PROCESSING FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF9" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                    </div>
                     <%--ROW 5--%>
                    <div class="form-row">
                       <div class="form-group col-md-3" style="text-align: left;">
                            <%--MECHANICAL FEE--%>
                           <asp:Label ID="_oLabelMECHANICAL" runat="server" Text="MECHANICAL FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtMECHANICAL" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                           <%-- RF10--%>
                            <asp:Label ID="_oLabelRF10" runat="server" Text="RF10"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF10" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                         <div class="form-group col-md-3" style="text-align: left;">
                           <%-- PLUMBING FEE--%>
                             <asp:Label ID="_oLabelPLUMBING" runat="server" Text="PLUMBING FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtPLUMBING" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                            <%--RF11--%>
                            <asp:Label ID="_oLabelRF11" runat="server" Text="RF11"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF11" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                    </div>
                     <%--ROW 6--%>
                    <div class="form-row">
                         <div class="form-group col-md-3" style="text-align: left;">
                            <%--ELECTRICAL FEE--%>
                             <asp:Label ID="_oLabelELECTRICAL" runat="server" Text="ELECTRICAL FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtELECTRICAL" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                            <%--RF12--%>
                            <asp:Label ID="_oLabelRF12" runat="server" Text="RF12"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF12" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                         <div class="form-group col-md-3" style="text-align: left;">
                           <%-- SIGN BOARD FEES--%>
                             <asp:Label ID="_oLabelSIGNBILL" runat="server" Text="SIGN BOARD FEES"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtSIGNBILL" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                           <%-- RF13--%>
                            <asp:Label ID="_oLabelRF13" runat="server" Text="RF13"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF13" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                       
                    </div>
                     <%--ROW 7--%>
                    <div class="form-row">
                        <div class="form-group col-md-3" style="text-align: left;">
                           <%-- RRDM FEE--%>
                            <asp:Label ID="_oLabelFIRECODE" runat="server" Text="RRDM FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtFIRECODE" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                            <%--CHANGE COMM. NAME--%>
                            <asp:Label ID="_oLabelRF14" runat="server" Text="CHANGE COMM. NAME"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF14" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>

                         <div class="form-group col-md-3" style="text-align: left;">
                            <%--OTHER FEES--%>
                             <asp:Label ID="_oLabelOTHER" runat="server" Text="OTHER FEES"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtOTHER" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-3" style="text-align: left;">
                            <%--CHANGE ADDRESS--%>
                            <asp:Label ID="_oLabelRF15" runat="server" Text="CHANGE ADDRESS"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF15" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                    </div>
                     <%--ROW 8--%>
                    <div class="form-row col-md-6">
                        <div class="form-group col-md-6" style="text-align: left;">
                           <%-- TOURISM FEE--%>
                            <asp:Label ID="_oLabelRF1" runat="server" Text="TOURISM FEE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF1" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                        <div class="form-group col-md-6" style="text-align: left;">
                            <%--CHANGE BUSINESS LINE--%>
                            <asp:Label ID="_oLabelRF16" runat="server" Text="CHANGE BUSINESS LINE"></asp:Label>
                            <br />
                            <input type="text" runat="server" class="form-control" id="_otxtRF16" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                        </div>
                    </div>           

                </div>
                    </asp:Panel>
                 

                 </div>
               
                </div>

             <%--BUTTONS--%>
                    <div>
                         <asp:Button ID="_obuttonregulatoryEdit" runat="server" Text="Edit" CssClass="btn btn-primary"  Width="100px" />
                                            <asp:Button ID="_obuttonregulatorySave" runat="server" Text="Save" CssClass="btn btn-primary"
                                                Width="100px" Enabled="False" />
                                            <asp:Button ID="_obuttonregulatoryCancel" runat="server" Text="Cancel" CssClass="btn btn-primary"
                                                Width="100px"  Enabled="False" />
                    </div>

            </div>
    <div style="display:none;">   <%--@Modidified 20211029--%>

    
        <hr />
        <div class="">
            <h4 id="BusLine" runat="server"> Line of Business</h4>
         <asp:Panel ID="_oPanelGridviewBussLine" runat="server" ScrollBars="Auto">
              <div class="form-group col-md-12"  style="text-align:left" id="NatureBusiness" runat="server">Nature of business (Described by applicant)<br />  
                     <asp:textbox style="text-align:left;height:auto;" id="_otextBusinessNature" ReadOnly="true"    runat="server" cssclass="form-control" BorderStyle="Solid" MaxLength="500"  TextMode="MultiLine" ></asp:textbox>
                  </div>
             <br />
            <asp:GridView ID="_oGridViewBusLine" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="98%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11"
                AllowPaging="True" 
                PagerSettings-Mode="NumericFirstLast" PageSize="10" >
                      
                <Columns>
                    <asp:TemplateField HeaderText="Code" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("BUS_CODE")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width = "30%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusDescription" runat="server" Text='<%# Eval("DESCRIPTION")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Year" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusYear" runat="server" Text='<%# Eval("FORYEAR")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gross Sales" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                             <asp:Label  ID="_oLabelBusGross" runat="server" Text='<%# If(Eval("GROSSREC").ToString() = "", "0", Format(Eval("GROSSREC"), "standard"))%>'  />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Capital" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label  ID="_oLabelBusCapital" runat="server" Text='<%# If(Eval("CAPITAL").ToString() = "", "0", Format(Eval("CAPITAL"), "standard"))%>'  />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                               <asp:Label  ID="_oBusinessLineArea" runat="server" Text='<%# If(Eval("AREA").ToString() = "", "0", Format(Eval("AREA"), "standard"))%>'  />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NRC" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusStatCode" runat="server" Text='<%# Eval("STATCODE")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Business Fee" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusTax" runat="server" Text='<%# If(Eval("BUSTAX").ToString() = "", "0", Format(Eval("BUSTAX"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mayor's Fee" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelMayors" runat="server" Text='<%# If(Eval("MAYORS").ToString() = "", "0", Format(Eval("MAYORS"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sanitary Fee" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelSanitary" runat="server" Text='<%# If(Eval("SANITARY").ToString() = "", "0", Format(Eval("SANITARY"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Garbage Fee" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelGarbage" runat="server" Text='<%# If(Eval("GARBAGE").ToString() = "", "0", Format(Eval("GARBAGE"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fire Fee" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelFire" runat="server" Text='<%# If(Eval("FIRE").ToString() = "", "0", Format(Eval("FIRE"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <center>
                              <input type="image" id="_oButtonBuslineEdit"  onclick="document.getElementById('hnbtn1').click();" src="../CSS_JS_IMG/img/editIcon.png" style="width:20px;height:20px" title="Edit"  usesubmitbehaviour="false" />
                     </center>
                                   </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Delete" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <center>
                                <input type="image" id="_ImgBtnBuslineRemove"  onclick="document.getElementById('hnbtn3').click();"  src="../CSS_JS_IMG/img/removeIcon.png"  style="width:20px;height:20px" title="Delete"  />
                                </center>
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Process" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <center>
                                <input type="image" id="_ImgBtnBuslineProcess" onclick="document.getElementById('hnbtn4').click();" src="../CSS_JS_IMG/img/computeIcon.png"  style="width:20px;height:20px" title="Process Computation"  />
                                </center>
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"/>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Is Processed" HeaderStyle-Width = "10%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelBusIsPrcs" runat="server" Text='<%# Eval("ISPRCS")%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
            <a id="hnbtn4" href="#" class="btn btn-primary mt-2" data-toggle="modal" data-dismiss="modal" data-target="#id04" data-ticket-type="standard-access" UseSubmitBehaivour="false" style="display:none">
            <a id="hnbtn3" href="#" class="btn btn-primary mt-2" data-toggle="modal" data-dismiss="modal" data-target="#id03" data-ticket-type="standard-access" UseSubmitBehaivour="false" style="display:none">
            <a id="hnbtn1" href="#" class="btn btn-primary mt-2" data-toggle="modal" data-dismiss="modal" data-target="#id01" data-ticket-type="standard-access" UseSubmitBehaivour="false" style="display:none">
                </a>
            <div id="ActionButtons" runat="server">
                <a id="_obtnaddlineb" runat="server" href="#" class="btn btn-primary mt-2" data-toggle="modal" data-dismiss="modal" data-target="#id02" data-ticket-type="standard-access" UseSubmitBehaivour="false">
                  Add Line of Business
                </a>

             
            </div>

            <br />

            <div>

             <div style="text-align:left;font-size:x-large;">
                &nbsp Total Amount Due: &nbsp <input runat="server" readonly="true"  type="text" id="_oTxtTotalAmountDue" style="border:none;" />
            </div>

            <div id="PreviewTOP" runat="server" class="col-md-12 d-flex justify-content-end align-content-end">

                <button runat="server" class="btn btn-primary m-2" onserverclick="ExportAppForm">  Download Application Form</button>
                &nbsp  &nbsp
                 <a href="#"  data-toggle="modal" data-dismiss="modal" data-target="#TOPGrid" data-ticket-type="standard-access" UseSubmitBehaivour="false" AutoPostback="false" class="btn btn-primary m-2">
                 Preview TOP
                </a>
            </div>

            </div>
          
        </div>


           
      <%--ADD LINE OF BUSINESS--%>                  
                  <link href="../CSS_JS_IMG/docsupport/chosen.css" rel="stylesheet" />

          <div id="id02" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class=" modal-content" style="margin-top:40% !Important;">
                <header class="modal-header">                    
                    <h4>ADD LINE OF BUSINESS</h4>
                    <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                </header>
                <div class="modal-body">
                    <center>
                        <div class="form-group col-md-12 row d-flex align-content-center justify-content-center " >Search Business Line<br />   
                    <div class="d-flex align-content-center justify-content-center col-12 mx-auto">
                     <asp:textbox   id="_oTxtSearchBusLine" runat="server" cssclass="form-control col-9 ml-1" placeholder="Search"  style="text-align:left;"></asp:textbox>
                    <button type="button" class="btn btn-success col-3 ml-2" id="_oBtnSearch" onclick="PayNow('PayNow', '');">Search</button>
                        </div> 
                </div>
                        
                   <div>Select Business Line<br /> 
                     <%--  <asp:DropDownList  runat="server" id="cmbBusCode"     cssclass="form-control chosen-select" style="height:40px;"></asp:DropDownList>--%>
                         
                     <select   runat="server" id="cmbBusCode" name="cmbBusCode" data-placeholder="Business Line" class="form-control chosen-select" style="height:40px;" >  </select>
                    </div>

                    <div>
                        Area:  <br />
                      
                         <input id="_oTextboxAddArea"   runat="server" style="text-align:right" class="form-control" placeholder="0" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                    </div>
                    <div>
                        Capital:  <br />
                       <input id="_oTextboxAddCapital" runat="server" style="text-align:right" class="form-control"  placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                    </div>
                    
                    
                   <br />
                    <div>
                       <input type="button" runat="server" id="_ButtonSaveBusinessLine" value="Process and Save" class="btn btn-success"/>
                   </div>
                   <br />
                    </center>
                  
                </div>
                <%--<footer class="w3-container w3-teal">
                    <p> </p>
                    
                </footer>--%>
                    </div> 
            </div>
        </div>
      <%--ADD LINE OF BUSINESS--%>

     <%-- CONFIRMATION PROCESS COMPUTATION--%>

           <div id="id04" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-lg">
                <div class=" modal-content" style="margin-top:20% !Important;">
                <header class="modal-header">  
                    <%--<span onclick="document.getElementById('id04').style.display='none'"
                        class="w3-button w3-display-topright">&times;</span>--%>
                    <h3>PROCESS BUSINESS LINE COMPUTATION</h3>
                <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                </header>
                <div class="modal-body">
                    <center>
                   
                        <div>
                          <h3>   Confirm Computation Process?   <br /></h3> 
                            <div>
                                <div>
                                    <input  id="_oTextboxBusinessLineYearCompute" runat="server" style="display:none;"  />
                                    <input  id="_oTextboxBusinessLineBusCodeCompute" runat="server" style="display:none;"  />
                                   <input  id="_oTextboxBusinessLineDescCompute" runat="server" style="width:80%;border:none;text-align:left;font-size:large;" readonly="true"   /> 

                                     <div style="width:80%;border:none;text-align:left;font-size:large;">
                                          Area:  &nbsp &nbsp
                                        <input id="_oTextboxBusinessLineAreaCompute"   runat="server" style="width:auto;border:none;text-align:left;" placeholder="0" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                                        sqm.
                                    </div>
                                    <div style="width:80%;border:none;text-align:left;font-size:large;">
                                          Capital:  
                                       <input id="_oTextboxBusinessLineCapitalCompute" runat="server" style="border:none;text-align:left;" placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);" />
                                    </div>
                                     
                                </div>
                                <div>
                                   
                                </div>
                            </div>

                        </div>
                        <br />
                    <div>
                       <input type="button" runat="server" id="_oButtonBuslineCompute" value="YES" class="btn btn-success"/> &nbsp &nbsp 
                         <input type="button" runat="server" data-dismiss="modal"  value="NO" class="btn btn-danger" />
                   </div>
                   <br />
                    </center>
                  
                </div>
                <%--<footer class="w3-container w3-teal">
                    <p> </p>
                    
                </footer>--%>
                    </div> 
            </div>
        </div>

    <%-- CONFIRMATION PROCESS COMPUTATION--%>


      <%--REMOVE CONFIRMATION LINE OF BUSINESS--%>

           <div id="id03" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class=" modal-content" style="margin-top:20% !Important;">
                <header class="modal-header">                     
                    <h3>REMOVE LINE OF BUSINESS</h3>
                    <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                </header>
                <div class="modal-body">
                    <center>
                   
                        <div>

                             <h3>   Are you sure want to permanently Delete this Line of Business? <br />
                             This process cannot be undone.  <br /></h3> 
                    
                            
                            <div>
                                <div>
                                    <input  id="_oTextboxBusinessLineYearRemove" runat="server" style="width:80%;border:none;text-align:center;display:none;"  onblur="FormatCurrency(this);" onkeypress="validate(event);" />
                                    <input  id="_oTextboxBusinessLineBusCodeRemove" runat="server" style="width:80%;border:none;text-align:center;display:none;" onblur="FormatCurrency(this);" onkeypress="validate(event);"  />
                                    <input  id="_oTextboxBusinessLineDescRemove" runat="server" style="width:80%;border:none;text-align:center;font-size:large;" readonly="true"   onblur="FormatCurrency(this);" onkeypress="validate(event);" />
                                </div>
                            </div>

                        </div>
                        <br />
                    <div>
                       <input type="button" runat="server" id="_oButtonBuslineRemove" value="YES" class="btn btn-success"/> &nbsp &nbsp 
                         <input type="button" runat="server" data-dismiss="modal"  value="NO " class="btn btn-danger" />
                   </div>
                   <br />
                    </center>
                  
                </div>
                <%--<footer class="w3-container w3-teal">
                    <p> </p>
                    
                </footer>--%>
                    </div> 
            </div>
        </div>

    <%--REMOVE CONFIRMATION LINE OF BUSINESS--%>

        <div id="id01" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class=" modal-content" style="margin-top:20% !Important;">
                <header class="modal-header">                      
                    <h3>UPDATE LINE OF BUSINESS</h3>
                    <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                </header>
                <br />
                <div class="modal-body">
                    <center>
                    <div style="display:none;">
                        Business Line: <br />
                              <input  id="_oBusinessLineCode" runat="server" readonly="true"  />
                    </div>
                    <div>
                        Business Line: <br />
                              <input  id="_oBusinessLineDesc" runat="server" class="form-control"  readonly="true"   />
                    </div>
                    <div style="display:none;">
                        Business Line: <br />
                              <input  id="_oBusinessLineForYear" runat="server" style="width:80%;border:none;text-align:center" readonly="true"   />
                    </div>
                    <div>
                        Area:  <br />
                      
                         <input id="_oBusinessLineTextArea"   runat="server" style="text-align:right" class="form-control" placeholder="0" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                    </div>
                    <div>
                        Capital:  <br />
                       <input id="_oBusinessLineCapital" runat="server" style="text-align:right" class="form-control"  placeholder="0.00" onblur="FormatCurrency(this);" onkeypress="validate(event);"/>
                    </div>
                    
                    
                   <br />
                    <div>
                       <input type="button" runat="server" id="_oButton_UpdateBusline" class="btn btn-primary" value="Process and Update" />
                   </div>
                   <br />
                    </center>
                  
                </div>
                <%--<footer class="w3-container w3-teal">
                    <p> </p>
                    
                </footer>--%>
                    </div>
            </div>
        </div>

       <%--TOP GRIDVIEW--%>
          <div id="TOPGrid" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-xl" style="width:1000px !Important">
                <div class=" modal-content">
                <header class="modal-header">
                    <%--<span onclick="document.getElementById('TOPGrid').style.display='none'"
                        class="w3-button w3-display-topright">&times;</span>--%>
                    <h2> TOP PREVIEW </h2>
                <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                </header>                
                <div class="modal-body table-responsive">
                      <br />

                    <center>
											
					  <asp:GridView ID="_oGridViewTOP" runat="server"  AutoGenerateColumns="False"
							PagerSettings-Mode="NumericFirstLast"  ShowFooter="True" ShowHeaderWhenEmpty="True"
							Width="100%" CssClass="mgrid">
							<FooterStyle CssClass="GridViewFooterStyle" />
							<RowStyle CssClass="GridViewRowStyle" />
							<SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
							<AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
							<HeaderStyle CssClass="GridViewHeaderStyle" />
							<Columns>
								
								<asp:TemplateField HeaderText="Taxcode">
									<ItemTemplate>
										<asp:Label ID="_oLabelTaxcode" runat="server" Text='<%# Eval("Taxcode")%>' />
									</ItemTemplate>
									<ItemStyle CssClass="cssGridViewItemStyleLeft" />
								</asp:TemplateField>
								
								<asp:TemplateField HeaderText="TaxDescription">
									<ItemTemplate>
										<asp:Label ID="_oLabelTaxDesc" runat="server" Text='<%# Eval("TaxDescription")%>' />
									</ItemTemplate>
									<ItemStyle CssClass="cssGridViewItemStyleLeft" />
								</asp:TemplateField>
								
								<asp:TemplateField HeaderText="Taxbase" Visible="false">
									<ItemTemplate>
										<asp:Label ID="_oLabelTaxbase" runat="server" Text='<%# If(Eval("Taxbase").ToString() = "", "0", Format(Eval("Taxbase"), "standard"))%>'   />
									</ItemTemplate>
									<ItemStyle CssClass="cssGridViewItemStyleRight" />
								</asp:TemplateField>
								
								<asp:TemplateField HeaderText="Taxdue">
									<ItemTemplate>
										<asp:Label ID="_oLabelTaxdue" runat="server" Text='<%# If(Eval("Taxdue").ToString() = "", "0", Format(Eval("Taxdue"), "standard"))%>'  />
									</ItemTemplate>
									<ItemStyle CssClass="cssGridViewItemStyleRight" />
								</asp:TemplateField>
								
								<asp:TemplateField HeaderText="Penalty">
									<ItemTemplate>
										<asp:Label ID="_oLabelPenalty" runat="server" Text='<%# If(Eval("Penalty").ToString() = "", "0", Format(Eval("Penalty"), "standard"))%>'  />
									</ItemTemplate>
									<ItemStyle CssClass="cssGridViewItemStyleRight" />
								</asp:TemplateField>
								
								<asp:TemplateField HeaderText="Total">
									<ItemTemplate>
										<asp:Label ID="_oLabelTotal" runat="server" Text='<%# If(Eval("Total").ToString() = "", "0", Format(Eval("Total"), "standard"))%>'  />
									</ItemTemplate>
									<ItemStyle CssClass="cssGridViewItemStyleRight" />
								</asp:TemplateField>
								
								<asp:TemplateField HeaderText="Covered Period">
									<ItemTemplate>
										<asp:Label ID="_oLabelCoveredPeriod" runat="server" Text='<%# Eval("CoveredPeriod")%>' />
									</ItemTemplate>
									<ItemStyle CssClass="cssGridViewItemStyleLeft" />
								</asp:TemplateField>
								
							</Columns>
						</asp:GridView>
                       
                    <div>
                      
                          <asp:UpdatePanel runat="server" >
                            <ContentTemplate>
                                  <rsweb:ReportViewer ID="_oRpt_Top" 
                                   runat="server"
                                    AsynRendering="true"
                                    SizeToReportContent = "true">
                                  </rsweb:ReportViewer>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="_oRpt_Top"/>
                            </Triggers>
                        </asp:UpdatePanel>
                   </div>
                  
                    </center>

                        <div style="font-size:x-large;">
                         <input type="button" runat="server" id="_oButtonPrintTOP"  class="btn btn-primary mt-2" value="Download" />
                    </div>
                  
                     <div style="text-align:left;font-size:x-large;display:none;">
                         Total Amount Due: &nbsp <input runat="server" readonly="true"  type="text" id="_oTxtboxTOPTotalAmount" style="border:none;" />
                    </div>
                     <br />
                </div>
                <%--<footer class="w3-container w3-teal">
                    <p> </p>
                    
                </footer>--%>
            </div>
                </div>
        </div>
         <%--  ----------%>

    
<%--PROCESS ALL--%>
          <div id="ProcessAll" class="modal fade" data-backdrop="static" data-keyboard="false">
               <div class="modal-dialog">
                      <div  class=" modal-content" style="margin-top:10% !Important;">
                <header class="modal-header">
                       <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                   <h3>PROCESS BUSINESS LINE COMPUTATION (ALL)</h3>
                </header>
                <br />
                <div class="modal-body table-responsive">
                    <center>
                           
                        <div>
                          <h3>   Confirm Process All Line Computation?  <br /></h3> 
                            <div>
                                <div>
                                   
                                </div>
                            </div>

                        </div>
                        <br />
                    <div>
                       <input type="button" class="btn btn-success" runat="server" id="_oButtonProcessAllLine" value="Process and save"  /> &nbsp &nbsp 
                         <input type="button" runat="server" data-dismiss="modal"   value="Cancel " class="btn btn-danger"/>
                   </div>
                   <br />
                    </center>
                  
                  
                  
                </div>
                <%--<footer class="w3-container w3-teal">
                    <p> </p>
                    
                </footer>--%>
            </div>
               </div>
         
        </div>
<%--PROCESS ALL--%>

<!-- Modal Popup Ask Business Line -->
<div id="MyPopup" class="modal" role="dialog" data-backdrop="static" data-keyboard="false" >
    <div  class="w3-modal-content w3-card-4">
        <!-- Modal content-->
        <div class="w3-container" style="margin-top: 30% !Important">
            <div class="modal-header">
                  <asp:Label ID="_oLabelAskBusinessDescription" runat="server" CssClass="cssLabelCenter" Font-Bold="True" />           
                  
                <h4 class="modal-title">
                </h4>
            </div>
            <div class="modal-body">
                <asp:Label ID="_oLabelFeeType" runat="server" CssClass="cssLabelCenter" Font-Bold="True" />
                 <asp:Panel ID="_oPanel_Ask" runat="server" 
                     CssClass="cssPanelAlignLeft" BackColor="White"
                     Style="min-height: 100px; overflow: hidden;" Width="60%" Visible="False">
                                                                                         
                                                                                            <asp:Panel ID="_oPanel1_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel1_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox1_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox1_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel2_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel2_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox2_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox2_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel3_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel3_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox3_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox3_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel4_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel4_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox4_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox4_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel5_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel5_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox5_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox5_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel6_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel6_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox6_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox6_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel7_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel7_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox7_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox7_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel8_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel8_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox8_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox8_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel9_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel9_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox9_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox9_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>
                                                                                            <asp:Panel ID="_oPanel10_Ask" runat="server" CssClass="cssPanelAlignLeft" Visible="False">
                                                                                                <asp:Label ID="_oLabel10_Ask" runat="server" CssClass="cssLabelLeft" AssociatedControlID="_oTextBox10_Ask" />
                                                                                                <asp:TextBox ID="_oTextBox10_Ask" runat="server" CssClass="input" align="Left" Width="100px"
                                                                                                    Font-Size="Smaller" autocomplete="off" onpaste="return falsepaste()" onkeyup="if (event.srcElement.value.charAt(0) == '.') 
                                                                                                    { event.srcElement.value ='0.'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) == '0' && event.srcElement.value.charAt(2) == '') 
                                                                                                    { event.srcElement.value = event.srcElement.value= '0.'; 
                                                                                                    };if (event.srcElement.value.charAt(0) == '0' && event.srcElement.value.charAt(1) !== '' && event.srcElement.value.charAt(1) !== '0' && event.srcElement.value.charAt(1) !== '.'  ) 
                                                                                                    { event.srcElement.value = event.srcElement.value.slice(1) ; 
                                                                                                    };return isNumberKey3(event,this);" onclick="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onkeypress="return isNumberKeye(event,this);" onfocus="if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.00') 
                                                                                                    { event.srcElement.value =''; 
                                                                                                    };FormatCurrency2(this);" onfocusout="if (event.srcElement.value == '') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };
                                                                                                    if (event.srcElement.value == '0.0') 
                                                                                                    { event.srcElement.value ='0.00'; 
                                                                                                    };FormatCurrency(this);" Font-Bold="True" Placeholder="0.00" />
                                                                                            </asp:Panel>

                                                                                            <br />
                                                                                             <%-- Panel OPTION--%>
                                                                                            <asp:Panel ID="_oPanel_oGridViewOption" runat="server" Style="overflow: hidden;" ScrollBars="Auto" BackColor="White" Visible="False" >
                                                                                                <asp:GridView ID="_oGridViewOption" runat="server" AutoGenerateColumns="False" PagerSettings-Mode="NumericFirstLast"
                                                                                                    ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" CssClass="GridViewStyle" >
                                                                                                    <FooterStyle CssClass="GridViewFooterStyle" />
                                                                                                    <RowStyle CssClass="GridViewRowStyle" />
                                                                                                    <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                                                                                    <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                                                                                    <HeaderStyle CssClass="GridViewHeaderStyle" />
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="" >
                                                                                                            <ItemTemplate >
                                                                                                                <asp:RadioButton ID="rbtnSelect" AutoPostBack="true" runat="server" OnCheckedChanged="rbtnSelect_CheckedChanged" />
                                                                                                               <%-- <input id="grdRdo" name="grdRdo" type="radio" runat="server" onclick="fnCheckUnCheck(this.id);" /> 
                                                                                                               <asp:RadioButton ID="_oRadioBtnOption" runat="server" onclick="javascript:CheckOtherIsCheckedByGVID(this);" /> 
                                                                                                                <input type="radio" id="_oRadioBtnOption" runat="server" onclick="javascript: CheckOtherIsCheckedByGVID(this);"  name="Option" />--%>
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" Width="2px" />
                                                                                                        </asp:TemplateField>                                                                                                        
                                                                                                      <%--   <asp:TemplateField HeaderText="" >
                                                                                                            <ItemTemplate >
                                                                                                                  <asp:RadioButton runat="server" ID="_oRadioBtnOption"  GroupName="RowOption" />
                                                                                                              <input type="radio" id="w" name="fd"/> 
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" Width="2px" />
                                                                                                        </asp:TemplateField>--%>

                                                                                                        <asp:TemplateField HeaderText="RowNo" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelRowNo" runat="server" Text='<%# Eval("RowNo")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="CODE" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelTaxCode" runat="server" Text='<%# Eval("TAXCODE")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                     
                                                                                                        <asp:TemplateField HeaderText="Option">
                                                                                                            <ItemTemplate>
                                                                                                                 <asp:Label ID="_oLabelOption" runat="server" Text='<%# Eval("OPTHDG1")%>' /> 
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="20px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="TAX RATE" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelTaxRate" runat="server" Text='<%# Eval("TAXRATE")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="TAX AMT" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelTaxAmt" runat="server" Text='<%# Eval("TAXAMT")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="CODE2" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelTaxCode2" runat="server" Text='<%# Eval("TAXCODE2")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Month" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelEff_Month" runat="server" Text='<%# Eval("EFF_MONTH")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Year" Visible="False">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="_oLabelEff_Year" runat="server" Text='<%# Eval("EFF_YEAR")%>' />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle CssClass="cssGridViewItemStyleLeft" Width="5px" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                </asp:GridView>
                                                                                            </asp:Panel>
                                                                                            <br />
                                                                                            <asp:Panel ID="Panel120" runat="server" CssClass="cssPanelAlignCenter">
                                                                                                <asp:Button ID="_oButton_OK" runat="server" CssClass="cssButton2" Font-Size="small"
                                                                                                    Text="Ok" Width="80px" Visible="False" />
                                                                                                <asp:Button ID="_oButtonTaxSave" runat="server" CssClass="btn btn-primary" Font-Size="small"
                                                                                                    Text="Save and proceed"  />
                                                                                            </asp:Panel>
                                                                                             <%-- Panel OPTION--%>
                                                                                        </asp:Panel>
            </div>
            <div class="modal-footer">
             
            </div>
        </div>
    </div>
</div>
<!-- Modal Popup Ask Business Line -->

 <!-- Bootstrap -->

<%--
<link rel="stylesheet" href="css/bootstrap.min.css">
<link rel="stylesheet" href="css/bootstrap-theme.min.css">
<script src="https://code.jquery.com/jquery-1.11.2.min.js"></script>
<script src="js/bootstrap.min.js"></script>

<script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
<link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css'media="screen" />--%>
<!-- Bootstrap -->
    </div>
   <%--NOTIFY--%>
        <div>
            
           <div id="id05" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class=" modal-content" style="margin-top:10% !Important;">
                <header class="modal-header">                    
                    <h3>CONFIRM TAG AS REVIEWED</h3>
                <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                </header>                
                <div class="modal-body table-responsive">
                    <center>
                   
                         <div>
                         <h4>  Do you wish to tag This Account with this remark ?<br />
                             <br />
                              <b>  <input  id="_oTextboxRemarks" runat="server" style="width:80%; border:none;text-align:center;font-size:large;" readonly="true"   />  </b> 
                             <br />
                             <br />
                             This process cannot be undone.

                         </h4>
                         </div>
                        <br />
                    <div>
                        <asp:Button runat="server" CssClass="btn btn-success" ID="_oButtonNotify" Text="Yes" OnClientClick="NextPage()" />
                         <input type="button" runat="server" onclick="document.getElementById('id05').style.display = 'none'"  value="NO " class="btn btn-danger"/>
                   </div>
                   <br />
                    </center>
                  
                </div>
                <%--<footer class="w3-container w3-teal">
                    <p> </p>
                    
                </footer>--%>
            </div>
        </div>
               </div>

               <div id="idSendNotification" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class=" modal-content" style="margin-top:10% !Important;">
                <header class="modal-header">                    
                    <h3>CONFIRM EMAIL NOTIFICATION</h3>
                <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                </header>                
                <div class="modal-body table-responsive">
                    <center>
                   
                         <div>
                         <h4>  Do you wish to notify application ?<br />
                             <br />
                             This process cannot be undone.

                         </h4>
                         </div>
                        <br />
                    <div>
                        <asp:Button runat="server" CssClass="btn btn-success" ID="_ButtonNotify2" Text="Yes" OnClientClick="NextPage()" />
                         <input type="button" runat="server" onclick="document.getElementById('idSendNotification').style.display = 'none'"  value="NO " class="btn btn-danger"/>
                   </div>
                   <br />
                    </center>
                  
                </div>
                <%--<footer class="w3-container w3-teal">
                    <p> </p>
                    
                </footer>--%>
            </div>
        </div>
               </div>
        </div>


    <div >
          <div  style="width:95%;margin:10px;border: 1px">
               <div   style="width:90%" >
                          <asp:GridView ID="_oGridViewBusinessDetailsNew" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                    AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" 
                    HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                    <Columns>

                        <asp:TemplateField  Visible="false" >
                            <ItemTemplate>
                                <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("BusinessId")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField  HeaderText="Category" HeaderStyle-Width="30%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("Category")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Products/Services" HeaderStyle-Width="40%">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelDescription" runat="server" Text='<%# Eval("ProductsServices")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Capitalization" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelCapital" runat="server" Text='<%# String.Format("{0:N2}", Eval("Capital"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Area" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="right">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelArea" runat="server" Text='<%# String.Format("{0:N2}", Eval("Area"))%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="20%" Visible="false">
                            <ItemTemplate>
                                <a href="#" onclick="RemoveBusinessLine('Remove','<%# Eval("BusinessId")%>')">Remove</a><br />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
               </div>
            </div>
    </div>


</div>
  <hr />

            

    <%--REMARKS--%>
    <div class="container" id="CommRem" runat="server">

         <p> <b>Comment and Remarks </b></p>
         <div class="form-group">Remarks
                <select runat="server" class="form-control" id="_oDDL_Remarks"  style="height:30px;padding:1px 1px 1px 1px;" >  
                          <option value="Reviewed/ For Assessment Billing" >Reviewed/ For Assessment Billing</option>  
                          <option value="Lacks Mandatory Requirements">Lacks Mandatory Requirements</option>                             
                </select>
            </div>
        <br />
        
         <div style="text-align:center">
                Comment:<br />
                <asp:TextBox runat="server" ID="_oTextboxComment" TextMode="MultiLine" style="width:100%; height:100px"></asp:TextBox>
            </div>
           <br />

        <div style="text-align:center">
                  <input type="button" class=" btn btn-primary" runat="server" id="_ImgBtn_oButtonNotify" onclick="GetRemark()" data-toggle="modal" data-dismiss="modal" data-target="#id05" data-ticket-type="standard-access" UseSubmitBehaivour="false" value="Tag as Reviewed"  />
            &nbsp &nbsp &nbsp 
             <input type="button" class=" btn btn-primary" runat="server" id="_ImgBtn_oButtonSendNotification"  data-toggle="modal" data-dismiss="modal" data-target="#idSendNotification" data-ticket-type="standard-access" UseSubmitBehaivour="false" value="Send Notification"  />
         </div>
         
         
    </div>
                    <br />
                    <br />

      <asp:Panel ID="_oPanelProcess" runat="server" CssClass="cssPanelAlignCenter" Visible="False">
                                                                                    <asp:Label ID="Label72" runat="server" CssClass="cssLabelCenter" Font-Bold="True"
                                                                                        Text="Processing..." />
                                                                                </asp:Panel>



     <script type="text/javascript">

         function ShowPopup(title, body) {
             $("#MyPopup .modal-title").html(title);
             $("#MyPopup").modal({
                 backdrop: 'static'
                    , keyboard: false
             }
                    , "show");
         }

         function HidePopup() {
             $("#MyPopup").modal("hide");
         }

    </script>

<script>
    var acc = document.getElementsByClassName("accordion");
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var panel = this.nextElementSibling;
            if (panel.style.display === "block") {
                panel.style.display = "none";
            } else {
                panel.style.display = "block";
            }
        });
    }
</script>
              <script>
                  function PayNow(Action, Val) {

                      __doPostBack(Action, Val);

                  }

                  //function openModal1()
                  //{
                  //    alert('hehe1');
                  //    sessionStorage.setItem('id02', 'true');
                  //}
                  //function OnloadModal()
                  //{
                  //    if (sessionStorage.getItem('id02'))
                  //    {
                  //        alert('hehe2');
                  //        $('#id02').modal('show');
                  //    }
                  //    sessionStorage.removeItem('id02')
                  //}                  

                  function triggermodal() {

                      if (sessionStorage.getItem('modaltrigger')) {
                          $('#id02').modal('show');
                          sessionStorage.clear();
                      }

                  }
                  addLoadEvent(triggermodal);
              </script>


          </div>
            
         </div>
      </center>
         
    
</asp:Content>
