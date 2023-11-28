function ResponsiveTable() {
    var sheet = document.createElement('style')
    var newstyle = "";
    var textvalue = "";
    newstyle += "@media only screen and (max-width: 760px), (min-device-width: 200px) and (max-device-width: 760px) {";
    var table = document.getElementsByClassName('Table-MobileView');
    for (var i = 0; i < table.length; i++) {
        newstyle += "table.tb" + i + ", th.tb" + i + ", td.tb" + i + ", tr.tb" + i + " {display: block; text-align: left; border-style: none;}";
        newstyle += "table.tb" + i + " {top:2%;bottom:2%;left: 5%;right: 5%;border-style:none;width:95%;outline-color: #4975c3;}";
        newstyle += "thead tr.tb" + i + " {position: absolute;top: -9999px;left: -9999px; }";
        newstyle += "th.tb" + i + " {display:none;}";
        newstyle += "td.tb" + i + " {position: relative;text-align:left;padding-left: 0.5em;}";
        newstyle += "tr.paging > td.tb" + i + "p:last-of-type {content:\"\" !Important;position: relative;width:50% !Important;} ";
        var newtable = document.getElementById(table[i].id);
        var headers = newtable.getElementsByTagName('th');
        var data = newtable.getElementsByTagName('td');
        for (var j = 0; j < headers.length; j++) {
            //textvalue += headers[j].innerHTML;
            var Fvalue = "";                           
            var Headertext = headers[j].getElementsByTagName('a');
            for (var c = 0; c < Headertext.length; c++) {
                Fvalue = Headertext[c].innerText;
            }
            if (!Fvalue.length > 0)
            {
                Fvalue = headers[j].innerHTML;
            }                        
            
            newstyle += "td.tb" + i + ":nth-of-type(" + parseInt(parseInt(j) + parseInt(1)) + "):before  {content:  \" " + Fvalue + ": \" ;text-align:left;font-weight:bold;width: 40%;}";
            headers[j].classList.add("tb" + i + "");
            for (var t = 0; t < data.length; t++) {
                data[t].classList.add("tb" + i + "");
            }
            //or append to some div innerText
        }
        var tr = newtable.getElementsByClassName('paging');
        for (var j = 0; j < tr.length; j++) {
            var data = tr[j].getElementsByTagName('td');
            for (var t = 0; t < data.length; t++) {
                //document.getElementById(data[t].id).setAttribute('colspan', '1');                   
                data[t].classList.remove('tb' + i);
                data[t].classList.add('tb' + i + "p");
            }
        }
    }
    newstyle += "}";
    //document.getElementById('check').innerHTML = newstyle;
    sheet.type = 'text/css';
    sheet.innerHTML = newstyle;
    document.getElementsByTagName('head')[0].appendChild(sheet);
    //alert(newstyle);            
}


function ResponsivePagingTable() {
    if (screen.width < 760) {
        var table = document.getElementsByClassName('Table-MobileView');
        for (var i = 0; i < table.length; i++) {
            var newtable = document.getElementById(table[i].id);
            var tr = newtable.getElementsByClassName('paging');
            for (var j = 0; j < tr.length; j++) {
                var data = tr[j].getElementsByTagName('td');
                for (var t = 0; t < data.length; t++) {
                    data[t].id = "no";
                    document.getElementById(data[t].id).setAttribute("colspan", "1");
                    //document.getElementById(data[t].id).setAttribute('colspan', '1');                 
                    //data[t].classList.remove('tb'+i);
                }
            }
        }
    }
}

function addLoadEvent(func) {
    var oldonload = window.onload;
    if (typeof window.onload != 'function') {
        window.onload = func;
    } else {
        window.onload = function () {
            if (oldonload) {
                oldonload();
            }
            func();
        }
    }
}

addLoadEvent(ResponsiveTable)
addLoadEvent(ResponsivePagingTable);
