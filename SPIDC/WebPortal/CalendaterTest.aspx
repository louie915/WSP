<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CalendaterTest.aspx.vb" Inherits="SPIDC.CalendaterTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
  <link href='https://cdn.jsdelivr.net/npm/fullcalendar@5.2.0/main.min.css' rel='stylesheet' />
  <script src='https://cdn.jsdelivr.net/npm/fullcalendar@5.2.0/main.min.js'></script>


     <script>


         document.addEventListener('DOMContentLoaded', function () {
             var calendarEl = document.getElementById('calendar');

             var calendar = new FullCalendar.Calendar(calendarEl, {
                 selectable: true,
                 validRange: function (nowDate) {
                     return {
                         start: nowDate
                     };
                 },
                 headerToolbar: {
                     left: 'title',
                     center: '',
                     right: 'today,prev,next'
                 },
                 dateClick: function (info) {
                     //alert('clicked ' + info.dateStr);
                     document.getElementById('SelDate').value = info.dateStr;
                 },
                 select: function (info) {
                     // alert('selected ' + info.startStr + ' to ' + info.endStr);
                     document.getElementById('SelDateStart').value = info.startStr;
                     document.getElementById('SelDateEnd').value = info.endStr;
                 },

                 eventClick: function (info) {
                     var eventObj = info.event;

                     if (eventObj.url) {
                         alert(
                           'Clicked ' + eventObj.title + '.\n' +
                           'Will open ' + eventObj.url + ' in a new tab'
                         );

                         window.open(eventObj.url);

                         info.jsEvent.preventDefault(); // prevents browser from following link in current tab.
                     } else {
                         alert('Clicked ' + eventObj.title);
                     }
                 },
                 events: [
        {
            title: 'simple event',
            start: '2020-08-23'
        },
        {
            title: 'event with URL',
            url: 'https://www.google.com/',
            start: '2020-08-24'
        }
                 ]

             });

             calendar.render();
         });

</script>
    <script>
        $(document).ready(function () {
            $("#<%= btnNext.ClientID %>").bind('click', function () {
                jConfirm('Can you confirm this?', 'Confirmation Dialog', function (r) {
                    if (r == true) {

                        //Unbind client side click event and submit btnNext
                        $("#<%= btnNext.ClientID %>").unbind('click');
                            $("#<%= btnNext.ClientID %>").click();
                        }
                    });

                //Always prevent a postback by returning false
                return false;
            });
        });
            ///-------------
    </script>
  
</head>

     <style>

    html, body {
      margin: 0;
      padding: 0;
      font-family: Arial, Helvetica Neue, Helvetica, sans-serif;
      font-size: 14px;
    }

    #calendar {
      max-width: 1100px;
      margin: 40px auto;
    }

  </style>



<body>

   Selected Date <input type="text" id="SelDate" /><br />
       Selected Date End <input type="text" id="SelDateStart" /><br />
   Selected Date End <input type="text" id="SelDateEnd" /><br />
    <input type="button" id="btnNext" value="Test" runat="server"/>
  <div id='calendar'></div>
</body>

</html>
