<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/Regulatory_BrgyClearance.Master" CodeBehind="Regulatory_BrgyClearanceReview.aspx.vb" Inherits="SPIDC.Regulatory_BrgyClearanceReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head"  runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">

     
    <style>
#Information{
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

#Information td, #Information th {
  border: 1px solid #ddd;
  padding: 8px;
}

#Information tr:nth-child(even){background-color: #f2f2f2;}
#Information tr:hover {background-color: #ddd;}

</style>
  <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<script type="text/javascript">

    $(function () {
        $("[id*=_oGridView_Fees]").find("[id*=_oButtonRegFeesEdit]").click(function () {
            //Reference the GridView Row.
            var row = $(this).closest("tr");

            //Determine the Row Index.
            var message = "Row Index: " + (row[0].rowIndex - 1);
            //Read values from Cells.
            var ItemCode = row.find("td").eq(0)[0].innerText;
            var ItemDesc = row.find("td").eq(1)[0].innerText;
            var Amount = row.find("td").eq(2)[0].innerText;
         
            // Display the data using JavaScript Alert Message Box.
            // alert(message);
            document.getElementById('<%=txtEditFeesAmount.ClientID%>').value = Amount;         
            document.getElementById('<%=txtEditFeesDesc.ClientID%>').value = ItemDesc;         
            document.getElementById('<%=txtEditFeesCode.ClientID%>').value = ItemCode;
         
            return false;
        });
      });


    $(function () {
        $("[id*=_oGridView_Fees]").find("[id*=_oButtonRegFeesRemove]").click(function () {
            //Reference the GridView Row.
            var row = $(this).closest("tr");

            //Determine the Row Index.
            var message = "Row Index: " + (row[0].rowIndex - 1);
            //Read values from Cells.
            var ItemCode = row.find("td").eq(0)[0].innerText;
            var ItemDesc = row.find("td").eq(1)[0].innerText;
            var Amount = row.find("td").eq(2)[0].innerText;

            // Display the data using JavaScript Alert Message Box.
            // alert(message);
            document.getElementById('<%=_oTextboxRegFeesItemCodeRemove.ClientID%>').value = ItemCode;
            document.getElementById('<%=_oTextboxRegFeesItemRemove.ClientID%>').value = ItemDesc;
            document.getElementById('<%=_oTextboxRegFeesAmountRemove.ClientID%>').value = Amount;


            return false;
        });
    });
 
    function do_embed(ctr) {
        var parent = $('embed#embed_Here').parent();
        var newElement = "<embed id='embed_Here' type='text/html' src='#'  width='100%' height='600px' style='object-fit: contain;'>";
        $('embed#embed_Here').remove();
        parent.append(newElement);

        switch (ctr) {

                   case 1:
                       document.getElementById('embed_Here').src = document.getElementById('<%= hdn_1.ClientID%>').value;
                       document.getElementById('embed_Here').type = document.getElementById('<%= hdn_1.ClientID%>').value.split(';')[0].split(':')[1];
                       document.getElementById('ModalFileName').innerHTML = 'Owner Picture';
                       document.getElementById('<%= hdn_ImageId.ClientID%>').value = "1"
                       document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks1.ClientID%>').value
                        break;
                   case 2:
                       document.getElementById('embed_Here').src = document.getElementById('<%= hdn_2.ClientID%>').value;
                       document.getElementById('embed_Here').type = document.getElementById('<%= hdn_2.ClientID%>').value.split(';')[0].split(':')[1];
                       document.getElementById('ModalFileName').innerHTML = 'Business Establishment Picture';
                       document.getElementById('<%= hdn_ImageId.ClientID%>').value = "2"
                       document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks2.ClientID%>').value
                        break;
                    case 3:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_3.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_3.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'Business Map Location';
                        document.getElementById('<%= hdn_ImageId.ClientID%>').value = "3"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks3.ClientID%>').value
                        break;
                    case 4:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_4.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_4.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'Application Form with Signature';
                        document.getElementById('<%= hdn_ImageId.ClientID%>').value = "4"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks4.ClientID%>').value
                        break;
                    case 5:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_5.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_5.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'DTI/SEC/CDA Registration';
                        document.getElementById('<%= hdn_ImageId.ClientID%>').value = "5"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks5.ClientID%>').value
                        break;
                    case 6:
                        document.getElementById('embed_Here').src = document.getElementById('<%= hdn_6.ClientID%>').value;
                        document.getElementById('embed_Here').type = document.getElementById('<%= hdn_6.ClientID%>').value.split(';')[0].split(':')[1];
                        document.getElementById('ModalFileName').innerHTML = 'TIN Registration';
                        document.getElementById('<%= hdn_ImageId.ClientID%>').value = "6"
                        document.getElementById('<%= txt_ImageRemarks.ClientID%>').value = document.getElementById('<%= hdn_ImageRemarks6.ClientID%>').value
                        break;
                }

    }

    function do_display() {
        if (sessionStorage.getItem("up_FileName1") == '') {
            document.getElementById('link_OwnPic').style.display = 'none';
        }
        if (sessionStorage.getItem("up_FileName2") == '') {
            document.getElementById('link_EstPic').style.display = 'none';
        }
        if (sessionStorage.getItem("up_FileName3") == '') {
            document.getElementById('link_MapPic').style.display = 'none';
        }
        if (sessionStorage.getItem("up_FileName4") == '') {
            document.getElementById('link_AppForm').style.display = 'none';
        }
        if (sessionStorage.getItem("up_FileName5") == '') {
            document.getElementById('link_DtiSecCda').style.display = 'none';
        }
        if (sessionStorage.getItem("up_FileName6") == '') {
            document.getElementById('link_TIN').style.display = 'none';
        }

    }

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
       
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        var values = eval('<%=Values%>');
        if (values != null) {
            var html = "";
            $(values).each(function () {
                var div = $("<div />");
                div.html(GetDynamicTextBox(this));
                $("#TextBoxContainer").append(div);
            });
        }
        $("#btnAdd").bind("click", function () {
            var div = $("<div />");
            div.html(GetDynamicTextBox(""));
            $("#TextBoxContainer").append(div);
        });
        $("body").on("click", ".remove", function () {
            $(this).closest("div").remove();
        });
    });
    function GetDynamicTextBox(value) {
        return '<select name="cars" id="cars">    ' +
                   ' <option value="Fees 1">Fees 1</option>       ' +
                   ' <option value="Fees 2">Fees 2</option>         ' +
                   ' <option value="Fees 3">Fees 3</option> ' +
               '</select> ' +
               '<input name = "DynamicTextBox" type="number"  value = "' + value + '" /> &nbsp;' +
               '<input type="button" value="Remove" class="remove" />'
    }
</script> 
    <div id="snackbar" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbar" />
    </div>
    <div id="snackbargreen" style="position: absolute">
        <asp:Label runat="server" ID="_oLabelSnackbargreen" />
    </div>


        <!-- Modal View Attachment Form -->
      <div id="ModalView" class="modal fade" >
        <div class="modal-dialog modal-lg">
          <div class="modal-content">
            <div class="modal-header  bg-primary">
              <h4 class="modal-title text-white" id="ModalFileName"></h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
               <div class="col-lg-12">
                   
                   <embed id="embed_Here" type="text/html" src="#"  width="100%" height="600px" style="object-fit: contain;" >
                       <input runat="server" type="hidden" id="hdn_ImageId" />
             
                    <div>
                        Remarks:
                        <textarea runat="server" id="txt_ImageRemarks" aria-multiline="true" style="height:50px;width:100%;" ></textarea>
                    </div>
                      
              </div>  
                    <br />
                     <br />
                    <input type="button" value="Reject" onclick="UpdateImageStatus('ImageReject','')"  class="btn btn-primary btn-sm col col-md-3"  style="background-color:red;display:inline-block"/>
                    <input type="button" value="Approve" onclick="UpdateImageStatus('ImageApprove','')"  class="btn btn-primary btn-sm col col-md-3"  style="background-color:green;display:inline-block"/>
                  
           
            </div>
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->


       <div class="container">
           <center>
               <div class="col-md-10">
                   <br />
              <h5>REGULATORY - NEW BUSINESS CLEARANCE
              </h5>
                   
    <div id="div_BusInfo" class="MainDiv">
      <%--<div class="btn-primary" style="text-align:left">  
            <strong > &nbsp A. BUSINESS INFORMATION AND REGISTRATION</strong> 
    </div> 
       --%>
    

       <table id="Information">
          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp NEW BUSINESS CLEARANCE</strong> 
          </div> 

  <tr>
    <td>Application No.</td>
    <td runat="server" id="td_ApplicationNo"> </td>  
  </tr>
  <tr>
    <td>Ownership Type</td>
    <td runat="server"  id="td_OwnershipType">   </td>
   
  </tr>
  <tr>
    <td>DTI/SEC/CDA Registration No.</td>
      <td runat="server"  id="td_DTI_SEC_CDA">   </td>
   
  </tr>
  <tr>
    <td>TIN No.</td>
      <td runat="server"  id="td_TIN">   </td>
  </tr>
  <tr>
    <td>Business Name</td>
      <td runat="server"  id="td_BusinessName">   </td>
 
  </tr>
  <tr>
    <td>Trade Name/Franchise</td>
      <td runat="server"  id="td_TradeName">   </td>
 
  </tr>
  <tr>
    <td>Main Office Address</td>
      <td runat="server"  id="td_MainAddress">   </td>

  </tr>
  <tr>
    <td>Telephone No.</td>
     <td runat="server"  id="td_TelephoneNo">   </td>
 
  </tr>
  <tr>
    <td>Mobile No.</td>
     <td runat="server"  id="td_MobileNo">   </td>
 
  </tr>
  <tr>
    <td>Email Address</td>
     <td runat="server"  id="td_EmailAddress">   </td>
 
  </tr>
  <tr>
    <td>President/Owner Fullname</td>
     <td runat="server"  id="td_PresOwnerFullname">   </td>
  
  </tr>
  <tr>
    <td>Nationality</td>
     <td runat="server"  id="td_Nationality">   </td>
  </tr>


</table>
  
        <br />
       <table >
           

          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp BUSINESS OPERATION</strong> 
          </div> 

  <tr>
    <td>Business Area (in sq.m)</td>
    <td runat="server"  id="td_BusinessArea" >    </td>  
  </tr>
  <tr>
    <td>Total Floor Area (in sq.m)</td>
    <td runat="server"  id="td_TotalFlrArea"></td>
   
  </tr>
  <tr>
    <td>No. of Employees Male</td>
    <td runat="server"  id="td_NoEmpMale"></td>
  
  </tr>
  <tr>
    <td>No. of Employees Female</td>
    <td runat="server"  id="td_NoEmpFemale"></td>
  
  </tr>
  <tr>
    <td>No. of Employees LGU Residing</td>
    <td runat="server"  id="td_LGUResiding"></td>   
  </tr>
  <tr>
    <td>No. of Delivery Van/Truck</td>
    <td runat="server"  id="td_DeliveryVanTruck"></td>
 
  </tr>
  <tr>
    <td>No. of Delivery Motorcyles</td>
    <td runat="server"  id="td_DeliveryMotorcycle"></td>
 
  </tr>
  <tr>
    <td>Business Location Address</td>
    <td runat="server"  id="td_BusinessLocAddress"></td>

  </tr>
  <tr>
    <td>Owned?</td>
    <td runat="server"  id="td_Owned"></td>
 
  </tr>
  <tr>
    <td>Tax Declaration No.</td>
    <td runat="server"  id="td_TDN"></td>
 
  </tr>
  <tr>
    <td>Property Identification No.</td>
    <td runat="server"  id="td_PIN"> </td>
 
  </tr>
  <tr>
    <td>Total Capitalization (PH)</td>
    <td runat="server"  id="td_Capitalization"> </td>
 
  </tr>
  <tr>
    <td>Enjoying tax incentives from any Gov't Entity?</td>
    <td runat="server"  id="td_EnjoyingTaxIncentives"> </td>
  
  </tr>
  <tr>
    <td>Business Activity</td>
    <td runat="server"  id="td_BusinessActivity"></td>  
  </tr>
   <tr>
    <td>Nature of Business</td>
    <td runat="server"  id="td_BusinessNature"></td>  
  </tr>

</table>

                <br />
        <div style="text-align:left" >

  <table id="tb_ImageAttachment" >
     <br />
          <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp ATTACHMENTS</strong> 
    </div> 
    
  <tr>
    <td >Owner's Picture</td>  
    <td runat ="server" id="td_OwnPicFileName">  </td>  
       <td> <a href="#" id="link_OwnPic"  class="form-group col col-md-12" onclick="do_embed(1);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
          <input type="hidden" runat="server" id="hdn_1"/>  
           <input type="hidden" runat="server" id="hdn_ImageRemarks1" />
       </td>  
 
    <td runat ="server" id="td_OwnPicStatus">  </td>    
  </tr>
  <tr>
    <td>Business Establishment Picture</td> 
    <td runat ="server" id="td_EstPicFileName" >  </td>  
     
    <td>   
         <a href="#" id="link_EstPic"  class="form-group col col-md-12" onclick="do_embed(2);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
        <input type="hidden" runat="server" id="hdn_2"/>
         <input type="hidden" runat="server" id="hdn_ImageRemarks2" />
    </td>  
    <td runat ="server" id="td_EstPicStatus" > </td>    
  </tr>
  <tr>
   <td>Business Map Location</td> 
    <td runat ="server" id="td_MapPicFileName" >  </td>  
    <td> 
        <a href="#" id="link_MapPic"  class="form-group col col-md-12" onclick="do_embed(3);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
        <input type="hidden" runat="server" id="hdn_3"/>
         <input type="hidden" runat="server" id="hdn_ImageRemarks3" />
    </td>   
    <td runat ="server" id="td_MapPicStatus"> </td>    
  </tr>
  <tr>
   <td>Application Form with Signature</td> 
    <td runat ="server" id="td_AppFormFileName">  </td>  
    <td> 
        <a href="#" id="link_AppForm"  class="form-group col col-md-12" onclick="do_embed(4);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_4"/>
         <input type="hidden" runat="server" id="hdn_ImageRemarks4"/>
    </td>  
  
    <td runat ="server" id="td_AppFormStatus">  </td>    
  </tr>
  <tr>
    <td>DTI/SEC/CDA Registration</td> 
    <td runat ="server" id="td_DtiSecCdaFileName" > </td>  
    <td> 
        <a href="#" id="link_DtiSecCda"  class="form-group col col-md-12" onclick="do_embed(5);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_5"/>
         <input type="hidden" runat="server" id="hdn_ImageRemarks5" />
    </td>  
  
    <td runat ="server" id="td_DtiSecCdaStatus">  </td>    

  </tr>
  <tr>
   <td>TIN Registration</td> 
    <td runat ="server" id="td_TINFileName" > </td>  
    <td> 
        <a href="#" id="link_TIN"  class="form-group col col-md-12" onclick="do_embed(6);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
       <input type="hidden" runat="server" id="hdn_6" />
          <input type="hidden" runat="server" id="hdn_ImageRemarks6" />
    </td>  
 
    <td runat ="server" id="td_TINStatus" >  </td>    
 
  </tr>
  
</table>
           <br />
     <table>
          <br />
        <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp I already have a Barangay Clearance</strong> 
        </div> 
         <tr>
           <td>Barangay Clearance</td> 
            <td runat ="server" id="td1" > </td>  
            <td> 
                <a href="#" id="link_BrgyClr"  class="form-group col col-md-12" onclick="do_embed(7);"  data-toggle="modal" data-target="#ModalView" data-ticket-type="standard-access">View</a>         
                <input type="hidden" runat="server" id="hdn_7" />
                <input type="hidden" runat="server" id="hdn_ImageRemarks7" />
            </td>  
 
            <td runat ="server" id="td_BrgyClr" >  </td>    
 
          </tr>
     </table>

        </div>
   
       
        <br />
          <div class="btn-primary" style="text-align:left">     
                      <strong > &nbsp LINE OF BUSINESS</strong>
    </div> 
           
           

<table id="Information">

    <br />
   <asp:Panel ID="_oPanelGridviewBussLine" runat="server" ScrollBars="Auto">
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
                    <asp:TemplateField HeaderText="Gross Sales" HeaderStyle-Width = "10%" Visible="false">
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
                    <asp:TemplateField HeaderText="NRC" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusStatCode" runat="server" Text='<%# Eval("STATCODE")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Business Fee" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusTax" runat="server" Text='<%# If(Eval("BUSTAX").ToString() = "", "0", Format(Eval("BUSTAX"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mayor's Fee" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelMayors" runat="server" Text='<%# If(Eval("MAYORS").ToString() = "", "0", Format(Eval("MAYORS"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sanitary Fee" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelSanitary" runat="server" Text='<%# If(Eval("SANITARY").ToString() = "", "0", Format(Eval("SANITARY"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Garbage Fee" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelGarbage" runat="server" Text='<%# If(Eval("GARBAGE").ToString() = "", "0", Format(Eval("GARBAGE"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fire Fee" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelFire" runat="server" Text='<%# If(Eval("FIRE").ToString() = "", "0", Format(Eval("FIRE"), "standard"))%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <center>
                              <input type="image" id="_oButtonBuslineEdit"  onclick="document.getElementById('hnbtn1').click();" src="../CSS_JS_IMG/img/editIcon.png" style="width:20px;height:20px" title="Edit"  usesubmitbehaviour="false" />
                     </center>
                                   </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Delete" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <center>
                                <input type="image" id="_ImgBtnBuslineRemove"  onclick="document.getElementById('hnbtn3').click();"  src="../CSS_JS_IMG/img/removeIcon.png"  style="width:20px;height:20px" title="Delete"  />
                                </center>
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Process" HeaderStyle-Width = "10%" Visible="false">
                        <ItemTemplate>
                            <center>
                                <input type="image" id="_ImgBtnBuslineProcess" onclick="document.getElementById('hnbtn4').click();" src="../CSS_JS_IMG/img/computeIcon.png"  style="width:20px;height:20px" title="Process Computation"  />
                                </center>
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"/>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Is Processed" HeaderStyle-Width = "10%" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="_oLabelBusIsPrcs" runat="server" Text='<%# Eval("ISPRCS")%>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>

       <br />
      
     <div class="btn-primary" style="text-align:left">  
                    <strong > &nbsp Barangay Clearance Fee</strong> 
      </div>

    <table>

 <%--   <div>
        <div id="TextBoxContainer">
            <!--Textboxes will be added here -->
   
        </div>
        <br />
        <input id="btnAdd" type="button" value="add" onclick="AddTextBox()" /> &nbsp &nbsp &nbsp <asp:Button ID="btnPost" runat="server" Text="Post" OnClick="Post" />
        
    </div>--%>
                <br />
               
      <asp:Panel ID="_oPanel_Fees" runat="server" ScrollBars="Auto">
         <asp:GridView ID="_oGridView_Fees" runat="server" CssClass="mGrid Table-MobileView" AllowSorting="true"
                            AutoGenerateColumns="false" ShowHeaderWhenEmpty="false" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="98%" 
                            HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11"
                AllowPaging="True" 
                PagerSettings-Mode="NumericFirstLast" PageSize="10" > 
                <Columns>
                    <asp:TemplateField HeaderText="Code" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("TAXCODE")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("TAXDESC")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <asp:Label ID="_oLabelBusCode" runat="server" Text='<%# Eval("AMOUNT")%>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <center>
                              <input type="image" id="_oButtonRegFeesEdit"  onclick="document.getElementById('hnbtn1').click();" src="../CSS_JS_IMG/img/editIcon.png" style="width:20px;height:20px" title="Edit"  usesubmitbehaviour="false" />
                     </center>
                                   </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft"  />
                    </asp:TemplateField>
                        
                     <asp:TemplateField HeaderText="Delete" HeaderStyle-Width = "10%">
                        <ItemTemplate>
                            <center>
                                      <input type="image" id="_oButtonRegFeesRemove"  onclick="document.getElementById('hnbtn3').click();"  src="../CSS_JS_IMG/img/removeIcon.png"  style="width:20px;height:20px" title="Delete"  />
                                </center>
                        </ItemTemplate>
                        <ItemStyle CssClass="cssGridViewItemStyleLeft" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

          
          <div style="text-align:right;font-size:larger">
            
              Total Due:   <input runat="server" type="text"  id="TxtRegFeesTotalDue"  readonly="readonly" style="border:none;" />
           
          </div>

          <div id="ActionButtons" runat="server" style="text-align:right;">
                <a id="_obtnaddFees" runat="server" href="#" class="btn btn-primary mt-2" data-toggle="modal" data-dismiss="modal" data-target="#id02" data-ticket-type="standard-access" UseSubmitBehaivour="false">
                  Add Fees
                </a>
               &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp  &nbsp &nbsp &nbsp 
             
         </div> 

          <br />
        

           <div class="form-group col col-md-12" style="display:inline-block" style="text-align:left;">
            Remarks: 
             <textarea runat="server" id="_oTxtRemarks" aria-multiline="true" style="height:50px;width:100%;" ></textarea>
        </div>

          <br />
          
           <div class="form-group col col-md-12" style="display:inline-block">           
                <button name="btnSaveDraft" id="btnSaveDraft" type="button" onclick="SaveDraft();" class="btn btn-primary btn-sm col col-md-3" style="display:inline-block" >Save Work</button>     
               <input name="btnSubmit" type="button" runat="server" onclick="Incomplete('Incomplete', '');" value="Incomplete" class="btn btn-primary btn-sm col col-md-3"  style="background-color:red;display:inline-block" />
                <input name="btnSubmit" type="button" runat="server" onclick="Approve('Approve', '');" value="Approve" class="btn btn-primary btn-sm col col-md-3"  style="background-color:green;display:inline-block" />
        </div>   
     
       </asp:Panel>
                  
       

    </table>
    <br />



   </asp:Panel>
         <a id="hnbtn4" href="#" class="btn btn-primary mt-2" data-toggle="modal" data-dismiss="modal" data-target="#id04" data-ticket-type="standard-access" UseSubmitBehaivour="false" style="display:none"></a>
            <a id="hnbtn3" href="#" class="btn btn-primary mt-2" data-toggle="modal" data-dismiss="modal" data-target="#id03" data-ticket-type="standard-access" UseSubmitBehaivour="false" style="display:none"></a>
            <a id="hnbtn1" href="#" class="btn btn-primary mt-2" data-toggle="modal" data-dismiss="modal" data-target="#id01" data-ticket-type="standard-access" UseSubmitBehaivour="false" style="display:none"></a>

 <link href="../CSS_JS_IMG/docsupport/chosen.css" rel="stylesheet" />

       <div id="id02" class="modal fade" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog">
                      <div class=" modal-content" style="margin-top:40% !Important;">
                            <header class="modal-header">                    
                                <h4>ADD FEES</h4>
                                <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                            </header>

                            <div class="modal-body">
                                        <center>
                                            <div> Select Fees Item <br /> 
                                                 <select   runat="server" id="cmbItemFees" name="cmbItemFees" data-placeholder="Business Line" class="form-control chosen-select" style="height:40px;" >  
                                                      <option value="001">Fees item 1</option> 
                                                      <option value="002">Fees item 2</option> 
                                                      <option value="003">Fees item 3</option> 
                                                 </select>
                                            </div>

                                            <br />
                                            <div> Amount Due <br /> 
                                                <input runat="server" type="number" id="txtFeesDue"  class="input-group" />
                                            </div>
                                            <br />
                                            <div>
                                                 <input type="button" runat="server" id="_btnSaveFees" value="Save" class="btn btn-primary btn-sm col col-md-3"/>
                                            </div>
                                        </center>

                           </div>
                      </div>
                </div>
          </div>

       <div id="id01" class="modal fade" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog">
                      <div class=" modal-content" style="margin-top:40% !Important;">
                            <header class="modal-header">                    
                                <h4>EDIT FEE</h4>
                                <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                            </header>

                            <div class="modal-body">
                                        <center>
                                            <div> Description
                                                  <input runat="server" type="text"  id="txtEditFeesDesc"  class="input-group" readonly="readonly" style="border:none;" />
                                            </div>
                                           
                                            <br />
                                            <div> Amount Due <br /> 
                                                <input runat="server" type="number" id="txtEditFeesAmount"  class="input-group" />
                                            </div>
                                            <input  id="txtEditFeesCode" runat="server" style="width:80%;border:none;text-align:center;display:none;"  />
                                            <br />
                                            <div>
                                                 <input type="button" runat="server" id="btnEditRegFees" value="Update" class="btn btn-primary btn-sm col col-md-3"/>
                                            </div>

                                        </center>

                           </div>
                      </div>
                </div>
          </div>

       <div id="id03" class="modal fade" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog">
                <div class=" modal-content" style="margin-top:20% !Important;">
                <header class="modal-header">                     
                    <h3>REMOVE FEE</h3>
                    <button type="button" class="close " data-dismiss="modal" aria-hidden="true">&times;</button>
                </header>
                <div class="modal-body">
                    <center>
                   
                        <div>

                             <h3>   Are you sure want to permanently Delete this Fee? <br />
                             This process cannot be undone.  <br /></h3> 
                    
                            
                            <div>
                                <div>
                                 <input  id="_oTextboxRegFeesItemRemove" runat="server" style="width:80%;border:none;text-align:center;font-size:large;" readonly="true"   onblur="FormatCurrency(this);" onkeypress="validate(event);" />
                                 Item Description: <br/>  
                                 <input  id="_oTextboxRegFeesAmountRemove" runat="server" style="width:80%;border:none;text-align:center;display:none;"  onblur="FormatCurrency(this);" onkeypress="validate(event);" />  <br/> 
                                 Amount:  <br/>  
                                 <input  id="_oTextboxRegFeesItemCodeRemove" runat="server" style="width:80%;border:none;text-align:center;" onkeypress="validate(event);"  />
                                    
                                </div>
                            </div>

                        </div>
                        <br />
                    <div>
                       <input type="button" runat="server" id="btnRemoveRegFees" value="YES" class="btn btn-success"/> &nbsp &nbsp 
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

</table>

        <br />
       
                 <button runat="server" id="btnSave" type="button" style="display:none" ></button>
                 <button runat="server" id="btnSubmit" type="button" style="display:none" ></button>
        
        
   <%-- Update Line of Business--%>
             

     
        </div>
 </div>
          </center>
           </div>



    <br />
     <asp:Panel ID="_oPanelProcess" runat="server" CssClass="cssPanelAlignCenter" Visible="False">
          <asp:Label ID="Label72" runat="server" CssClass="cssLabelCenter" Font-Bold="True" Text="Processing..." />
     </asp:Panel>

        <script>
            function PayNow(Action, Val) {
                __doPostBack(Action, Val);
            };

            function Incomplete(Action, Val) {
                __doPostBack(Action, Val);
            };

            function Approve(Action, Val) {
                __doPostBack(Action, Val);
            };

            function UpdateImageStatus(Action, Val) {
                __doPostBack(Action, Val);
            };

            

        function triggermodal() {

            if (sessionStorage.getItem('modaltrigger')) {
                $('#id02').modal('show');
                sessionStorage.clear();
            }

        }
        addLoadEvent(triggermodal);

              </script>

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

</asp:Content>
