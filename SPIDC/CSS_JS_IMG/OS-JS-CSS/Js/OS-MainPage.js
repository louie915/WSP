/// <reference path="../../../WebPortal/BPLONewProperty.aspx" />
//function StartActive() {
//    var x;
//    x = parseInt(sessionStorage.getItem("Counter")) || 0;
//    //alert(x);
//    if (x == 0)
//    { sessionStorage.setItem("Active", "sAccounts"); }

//}
function GetActive() {
    var Id = sessionStorage.getItem("Active")
    //if (Id != "sAccounts") {
    //    //document.getElementById('liAccounts').style.backgroundColor = '#446ad7';
    //    document.getElementById('IcoAccounts').style.color = '#edeef5';
    //}
    switch (Id) {
        case "Account": case "BusinessRenewalTaxPayer": case "BPOtherTransaction": case "RPTCertificationAssessment": case "PayNow":
        case "AccountInformation": case "BusinessRenewalTaxPayer": case "RPTInformation": case "RPTOtherTransaction": case "RPTBilling":
            ////document.getElementById('liAccounts').style.backgroundColor = '#f8f9fc';
            document.getElementById('IcoAccounts').style.color = '#ffffff';
            document.getElementById('LblAccounts').style.color = '#ffffff';
            document.getElementById('LblAccounts').style.fontWeight = 'bold';
            break;
        case "NewCedula":
            //document.getElementById('liCedula').style.backgroundColor = '#f8f9fc';
            document.getElementById('IcoCedula').style.color = '#ffffff';
            document.getElementById('LblCedula').style.color = '#ffffff';
            document.getElementById('LblCedula').style.fontWeight = 'bold';
            break;
        case "NoBusiness":
            //document.getElementById('liBP').style.backgroundColor = '#f8f9fc';
            document.getElementById('IcoBP').style.color = '#ffffff';
            document.getElementById('LblBP').style.color = '#ffffff';
            document.getElementById('LblBP').style.fontWeight = 'bold';
            break;
        case "NoProperty":
            //document.getElementById('liCRPT').style.backgroundColor = '#f8f9fc';
            //document.getElementById('IcoCRPT').style.color = '#ffffff';
            //document.getElementById('LblCRPT').style.color = '#ffffff';
            //document.getElementById('LblCRPT').style.fontWeight = 'bold';
            break;
        case "NewBusiness": case "UploadDocs": case "BPLTIMSNewBusinessApplication": case "BPLTIMSBusinessLine":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('IcoNewBusiness').style.color = '#ffffff';
            document.getElementById('LblNB').style.color = '#ffffff';
            document.getElementById('LblNB').style.fontWeight = 'bold';
            break
        case "NewProperty": case "NewPropertyRequiredFiles":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('IcoNewProperty').style.color = '#ffffff';
            document.getElementById('LblNP').style.color = '#ffffff';
            document.getElementById('LblNP').style.fontWeight = 'bold';
            break;
        case "Appointment": case "AppointmentScheduler":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('IcoAppointment').style.color = '#ffffff';
            document.getElementById('LblAppointment').style.color = '#ffffff';
            document.getElementById('LblAppointment').style.fontWeight = 'bold';
            break;

        case "Miscellaneous":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('IcoMisc').style.color = '#ffffff';
            document.getElementById('LblMisc').style.color = '#ffffff';
            document.getElementById('LblMisc').style.fontWeight = 'bold';
            break;

        case "BPLOEnrollmentVerification":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnBPLOEV').style.color = '#ffffff';
            document.getElementById('_oSbtnBPLOEV').style.fontWeight = 'bold';
            break;
        case "BPLONewBusinessList": case "BPLTIMS_BPLOReview":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnBPLOBL').style.color = '#ffffff';
            document.getElementById('_oSbtnBPLOBL').style.fontWeight = 'bold';
            break;
        case "BPLOBusinessRenewal":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnBPLOBR').style.color = '#ffffff';
            document.getElementById('_oSbtnBPLOBR').style.fontWeight = 'bold';
            break;
        case "BPLOCertificationList":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnBPLOCL').style.color = '#ffffff';
            document.getElementById('_oSbtnBPLOCL').style.fontWeight = 'bold';
            break;
        case "BPLOAppointmentList":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnBPLOAL').style.color = '#ffffff';
            document.getElementById('_oSbtnBPLOAL').style.fontWeight = 'bold';
            break;
        case "ASSESSOREnrollmentVerification":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnAE').style.color = '#ffffff';
            document.getElementById('_oSbtnAE').style.fontWeight = 'bold';
            break;
        case "ASSESSORCertificationList":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnAC').style.color = '#ffffff';
            document.getElementById('_oSbtnAC').style.fontWeight = 'bold';
            break;
        case "ASSESSORAppointmentList":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnAA').style.color = '#ffffff';
            document.getElementById('_oSbtnAA').style.fontWeight = 'bold';
            break;
        case "ASSESSORNewProperty":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnAN').style.color = '#ffffff';
            document.getElementById('_oSbtnAN').style.fontWeight = 'bold';
            break;
        case "ASSESSORFAASMain": case "ASSESSORFAASMachinery": case "ASSESSORFAASLand": case "ASSESSORFAASBuilding":
            //document.getElementById('liNB').style.backgroundColor = '#f8f9fc';
            document.getElementById('_oSbtnAF').style.color = '#ffffff';
            document.getElementById('_oSbtnAF').style.fontWeight = 'bold';
            break;
        case "PABusinessPermit":
            document.getElementById('_oSbtnPABP').style.color = '#ffffff';
            document.getElementById('_oSbtnPABP').style.fontWeight = 'bold';
            break;

    }  
    //switch (Id) {
    //    case "Account": case "BusinessRenewalTaxPayer": case "BPOtherTransaction": case "RPTCertificationAssessment": case "PayNow":
    //    case "AccountInformation": case "BusinessRenewalTaxPayer": case "RPTInformation": case "RPTOtherTransaction": case "RPTBilling":
    //    case "NewBusiness": case "UploadDocs": case "BPLTIMSNewBusinessApplication": case "BPLTIMSBusinessLine":
    //    case "NewProperty": case "NewPropertyRequiredFiles": case "account": case "AppointmentOthers": case "AppointmentScheduler":
    //        document.getElementById('_obtnback').style.display = "none";
    //        break;
    //    case "NewCedula":
    //        break;
    //}
}

function setActive(ID) {
    var x;
    x = parseInt(sessionStorage.getItem("Counter")) | 0;
    x += 1;
    sessionStorage.setItem("Counter", x);
    sessionStorage.setItem("Active", ID);
    //alert(x);
}

function activetoggle() {
    var a = document.querySelector('.sidebar');
    //a.+
    if (a.classList.contains('togactive')) {
        a.classList.remove('togactive');
        document.getElementById('isideToggle').classList.remove('fa-minus');
        document.getElementById('isideToggle').classList.add('fa-bars');
        document.getElementById('isideToggle').style.color = '#ffffff';
    }
    else {
        a.classList.add('togactive');
        document.getElementById('isideToggle').classList.remove('fa-bars');
        document.getElementById('isideToggle').classList.add('fa-minus');
        document.getElementById('isideToggle').style.color = '#ffffff';
    }
}


var path = window.location.pathname;
var page = path.split("/").pop();
var Fname = page.replace(".aspx", "");

if (Fname == "certification") {
    switch (document.getElementById("_oLabelSwitch").innerHTML) {
        case "Request for Certificate of No Real Property":
            Fname = "NoProperty"
            break;
        case "Request for Certificate of No Business":
            Fname = "NoBusiness"
            break;
    }
}
sessionStorage.setItem("Active", Fname);
GetActive();


$(document).ready(function () {
    // Custom 
    var stickyToggle = function (sticky, stickyWrapper, scrollElement) {
        var stickyHeight = sticky.outerHeight();
        var stickyTop = stickyWrapper.offset().top;
        if (scrollElement.scrollTop() >= stickyTop) {
            stickyWrapper.height(stickyHeight);
            sticky.addClass("is-sticky");
        }
        else {
            sticky.removeClass("is-sticky");
            stickyWrapper.height('auto');
        }
    };

    // Find all data-toggle="sticky-onscroll" elements
    $('[data-toggle="sticky-onscroll"]').each(function () {
        var sticky = $(this);
        var stickyWrapper = $('<div>').addClass('sticky-wrapper'); // insert hidden element to maintain actual top offset on page
        sticky.before(stickyWrapper);
        sticky.addClass('sticky');

        // Scroll & resize events
        $(window).on('scroll.sticky-onscroll resize.sticky-onscroll', function () {
            stickyToggle(sticky, stickyWrapper, $(this));
        });

        // On page load
        stickyToggle(sticky, stickyWrapper, $(window));
    });
});

$('.form').find('input, textarea,select').on('keyup blur focus', function (e) {

    var $this = $(this),
    label = $this.prev('label')


    if (e.type === 'keyup' || e.type === 'focus') {



        label.addClass('input-txt-active input-txt-highlight');


    } else if (e.type === 'blur') {
        if ($this.val() === '') {
            label.removeClass('input-txt-active input-txt-highlight');
        } else {
            label.removeClass('input-txt-highlight');
        }
    } else if (e.type === 'focus') {

        if ($this.val() === '') {
            label.removeClass('input-txt-highlight');
        } else
            if ($this.val() !== '') {
                label.addClass('input-txt-highlight');
            }
    }

});

$('.tab a').on('click', function (e) {

    e.preventDefault();

    $(this).parent().addClass('active');
    $(this).parent().siblings().removeClass('active');

    target = $(this).attr('href');

    $('.tab-content > div').not(target).hide();

    $(target).fadeIn(600);

});




$('input[type="text"]').keydown(function (event) {
    if (event.keyCode == 13) {
        event.preventDefault();
        return false;
    }
});

//$(".sidebar").hover(
//        function () {
//            var a = document.querySelector('.sidebar');
//            if (a.classList.contains('togactive')) {

//            }
//            else {
//                if (a.classList.contains('toggled')) {
//                    a.classList.remove('toggled');
//                }
//                else {
//                    a.classList.add('toggled');
//                }
//            }

//        }
//   );



document.onreadystatechange = function () {
    if (document.readyState !== "complete") {
        document.querySelector(
          "#Cloading").style.visibility = "visible";
    } else {
        document.querySelector(
          "#Cloading").style.display = "none";
    }
};

function Lodingscreen() {
    if (document.readyState !== "complete") {
        document.querySelector(
          "#Cloading").style.visibility = "visible";
    } else {
        document.querySelector(
          "#Cloading").style.display = "none";
    }
};

function NextPage() { document.getElementById("NextLoading").style.display = "block"; }


//function screenTest() {
//    var mql = window.matchMedia('(max-width: 600px)');
//    if (mql.matches) {
//        /* the viewport is 600 pixels wide or less */
//        document.getElementById('accordionSidebar').classList.add('toggled');
//        //document.getElementById('page-top').style.backgroundColor = 'red';
//    } else {
//        /* the viewport is more than than 600 pixels wide */

//        document.getElementById('accordionSidebar').classList.remove('toggled');
//        //document.getElementById('page-top').style.backgroundColor = 'blue';
//    }
//}



//var mql = window.matchMedia('(max-width: 600px)');

//function ontimescreenTest(e) {
//    if (e.matches) {
//        /* the viewport is 600 pixels wide or less */
//        document.getElementById('accordionSidebar').classList.add('toggled');
//        //document.getElementById('page-top').style.backgroundColor = 'red';
//    } else {
//        /* the viewport is more than than 600 pixels wide */

//        document.getElementById('accordionSidebar').classList.remove('toggled');
//        //document.getElementById('page-top').style.backgroundColor = 'red';
//    }
//}

//mql.addListener(ontimescreenTest);