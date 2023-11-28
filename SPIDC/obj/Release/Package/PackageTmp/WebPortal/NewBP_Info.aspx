<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebPortal/OSMainPage.Master" CodeBehind="NewBP_Info.aspx.vb" Inherits="SPIDC.NewBP_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" ClientIDMode="Static" runat="server">

    <style>
        input[type="text"]:disabled {
            background: #dddddd;
        }

        #myTable, #myTable2 {
            font-family: Arial, Helvetica, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

            #myTable td, #myTable th, #myTable2 td, #myTable2 th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            #myTable tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #myTable2 tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            #myTable tr:hover {
                background-color: #ddd;
            }

            #myTable2 tr:hover {
                background-color: #ddd;
            }

            #myTable th, #myTable2 th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: left;
                background-color: #C1C1C1;
                color: black;
            }
    </style>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
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

    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div id="snackbar" style="position: absolute">
                <asp:Label runat="server" ID="_oLabelSnackbar" />
            </div>
            <div id="snackbargreen" style="position: absolute">
                <asp:Label runat="server" ID="_oLabelSnackbargreen" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



    <div class="container">
        <center>
               <div class="col-md-10">
                    <div class="details">
                         <div  style="border:1px solid gray; background-color:white; padding:10px;display:block;">
                              <div  style="text-align:center;font-family:Arial;" >
                  <h3>New Business Permit Application - Information</h3>                                
                <hr />                                 

          

    <div id="div_BusInfo" class="MainDiv">
        <div class="btn-primary" style="text-align:left">
            <strong > &nbsp Business Information</strong>
        </div>
        <br />
         <div class="form-group col col-md-6" style="display:inline-block;">
        <div>
            <label class="input-txt input-txt-active2">
                <span><span class="m-2">Application ID </span></span>
            </label>
            <input type="text" readonly runat="server" style="color:blue;font-weight:bold" class="form-control ch-size-new" name="txt_AppID" id="txt_AppID"/>
        </div>
    </div>
         <div class="form-group col col-md-5" style="display:inline-block;">
        <div>
            <label class="input-txt input-txt-active2">
                <span><span class="m-2">Application Status </span></span>
            </label>
            <input type="text" readonly runat="server" style="color:blue;font-weight:bold" class="form-control ch-size-new" name="txt_AppStatus" id="txt_AppStatus"/>
        </div>
    </div>
    <div class="form-group col col-md-4" style="display:inline-block;">
        <div>
            <label class="input-txt input-txt-active2">
                <span><span class="m-2">Ownership Type </span></span>
            </label>
            <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_OwnType" id="txt_OwnType"/>
        </div>
    </div>
    <div class="form-group col col-md-4" style="display:inline-block;">
        <div>
            <label class="input-txt input-txt-active2">
                <span><span class="m-2">DTI/SEC/CDA Registration Number </span></span>
            </label>
            <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_DtiSecCda" id="txt_DtiSecCda"/>
        </div>
    </div>
    <div class="form-group col col-md-3" style="display:inline-block">
         <div>
             <label class="input-txt input-txt-active2">
                 <span><span class="m-2">Tax Identification Number </span></span>
             </label>
             <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_TIN" id="txt_TIN"/>
         </div>
     </div>
    <div class="form-group col col-md-6"  style="display:inline-block" >
        <div>
            <label class="input-txt input-txt-active2">
                <span><span class="m-2">Business Name  </span></span>
            </label>
            <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_BusinessName" id="txt_BusinessName"/>
        </div>
    </div>
    <div class="form-group col col-md-5"  style="display:inline-block" >
        <div>
            <label class="input-txt input-txt-active2">
                <span><span class="m-2">Date of Establishment <b style="color:red">*</b>  </span></span>
            </label>
              <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_DateEsta" id="txt_DateEsta"/>
        </div>
    </div>
      
       
    </div>       
<div id="div_Branch" class="MainDiv">
    <div class="btn-primary" style="text-align:left">
        <strong > &nbsp  Business Location Address</strong>
    </div>
    <br />
    <div class="form-group col col-md-2" style="display:inline-block;">
        <div>
            <label class="input-txt input-txt-active2">
                <span><span class="m-2">House/Bldg No. </span></span>
            </label>
             <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_HouseNo1" id="txt_HouseNo1"/>           
        </div>
    </div>
    <div class="form-group col col-md-5" style="display:inline-block">
        <div>
            <label class="input-txt input-txt-active2">
                <span><span class="m-2">Name of Building </span></span>
            </label>
             <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_BldgName1" id="txt_BldgName1"/>       
        </div>
    </div>
    <div class="form-group col col-md-2" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Lot No.  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_B_LotNo1" id="txt_B_LotNo1"/></div>
    </div>
    <div class="form-group col col-md-2" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Block No.  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_BlockNo1" id="txt_BlockNo1"/></div>
    </div>
    <div class="form-group col col-md-4" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Brgy1" id="txt_Brgy1"/></div>
    </div>    
    <div class="form-group col col-md-4" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Street  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Street1" id="txt_Street1"/></div>
    </div>
    <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Subdivision  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Subd1" id="txt_Subd1"/></div>
    </div>
    <div class="form-group col col-md-4" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_CityMunicipality1" id="txt_CityMunicipality1"/></div>
    </div>    
    <div class="form-group col col-md-4" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Province  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Province1" id="txt_Province1"/></div>
    </div>
    <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Zip Code  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_ZipCode1" id="txt_ZipCode1"/></div>
    </div> 
 </div>   
<div id="div_Contact" class="MainDiv">

 <div class="btn-primary" style="text-align:left">  
            <strong > &nbsp  Owner Information</strong> 
    </div>
<br />
      <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Telephone Number  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_TelNo" id="txt_TelNo"/></div>
    </div> 

     <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Mobile Number  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_MobileNo" id="txt_MobileNo"/></div>
    </div> 

     <div class="form-group col col-md-5" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Nationality  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Nationality" id="txt_Nationality"/></div>
    </div> 
  
    <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Surname  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Sole_Lname" id="txt_Sole_Lname"/></div>
    </div>     
    <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Given Name  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Sole_Fname" id="txt_Sole_Fname"/></div>
    </div>   
    <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Middle Name  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Sole_Mname" id="txt_Sole_Mname"/></div>
    </div> 
    <div class="form-group col col-md-2" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Suffix  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Sole_Suffix" id="txt_Sole_Suffix"/></div>
    </div> 
   

 
             

       



</div>
<div id="div_Address" class="MainDiv">   
    
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp Owner Address</strong></div>
      
 <br />
      <div class="form-group col col-md-2" style="display:inline-block;"><div>
          <label class="input-txt input-txt-active2"><span><span class="m-2">House/Bldg No.</span></span></label>
          <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_HouseNo2" id="txt_HouseNo2"/></div>
      </div>
    <div class="form-group col col-md-5" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Name of Building </span></span></label>
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_BldgName2" id="txt_BldgName2"/></div>
    </div>
    <div class="form-group col col-md-2" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Lot No.  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_LotNo2" id="txt_LotNo2"/></div>
    </div>
    <div class="form-group col col-md-2" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Block No.  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_BlockNo2" id="txt_BlockNo2"/></div>
    </div>
    <div class="form-group col col-md-4" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Barangay  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Brgy2" id="txt_Brgy2"/></div>
    </div>    
    <div class="form-group col col-md-4" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Street  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Street2" id="txt_Street2"/></div>
    </div>
    <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Subdivision  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Subd2" id="txt_Subd2"/></div>
    </div>
    <div class="form-group col col-md-4" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">City/Municipality  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_CityMunicipality2" id="txt_CityMunicipality2"/></div>
    </div>    
    <div class="form-group col col-md-4" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Province  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_Province2" id="txt_Province2"/></div>
    </div>
    <div class="form-group col col-md-3" style="display:inline-block"><div>
        <label class="input-txt input-txt-active2"><span><span class="m-2">Zip Code  </span></span></label>  
        <input type="text" readonly runat="server" class="form-control ch-size-new" name="txt_ZipCode2" id="txt_ZipCode2"/></div>
    </div> 
 </div>

<div id="div_Operation" class="MainDiv">
   
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp  Business Operation</strong></div>
    <br />  
   
     <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. of Male Employees</span></span>
                 </label>
                    <input id="txt_NoMaleEmp" runat="server" readonly type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
     <div class="form-group col col-md-4" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. of Female Employees </span></span>
                 </label>
                    <input id="txt_NoFemaleEmp" runat="server" readonly type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <div class="form-group col col-md-3" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. Employees Residing within </span></span>
                 </label>
                    <input id="txt_NoResidingEmp" runat="server" readonly type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <div class="form-group col col-md-6" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. of Delivery Van/Truck (if applicable)</span></span>
                 </label>
                    <input id="txt_DelVanTruck" runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
    <div class="form-group col col-md-5" style="display:inline-block">
      <div>
                 <label class="input-txt input-txt-active2">
                       <span><span class="m-2">No. of Delivery Motorcycle (if applicable)  </span></span>
                 </label>
                    <input id="txt_DelMotor" runat="server" readonly  type="text" class="form-control CH-Size-New"  />
             </div>               
        </div>
</div>
<div id="div_Other" class="MainDiv">   
    


    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp  Nature of Business</strong>&nbsp       
         For Rental or Lessor, please include number of units.
    </div>      

<div runat="server" id="div_NoB"></div>
 </div>
    <br />                  
<div class="MainDiv">   
    
    <div class="btn-primary"  style="text-align:left">  
            <strong > &nbsp  Uploaded Attachments</strong></div>            
     <div id="div_Requirements" runat="server">
                  <asp:GridView ID="_GVRequirements" runat="server" CssClass="mGrid col-lg-11 Table-MobileView get-gross" AllowSorting="true"
                AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" RowStyle-BorderStyle="solid" RowStyle-BorderWidth="1" Width="100%"
                HeaderStyle-HorizontalAlign="Center" RowStyle-Font-Size="11" HeaderStyle-Font-Size="11">
                <Columns>                 
                     <asp:TemplateField HeaderText="Code" ItemStyle-HorizontalAlign="CENTER" Visible="false" >
                        <ItemTemplate>
                            <label><%# Eval("REQCODE")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Requirement" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>
                            <label><%# Eval("REQDESC")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>                  

                    <asp:TemplateField HeaderText="File Uploaded" ItemStyle-HorizontalAlign="CENTER">
                        <ItemTemplate>                
                            <a download="<%# Eval("FileName")%>"
                               href="<%# Eval("File64")%>"   
                              target="_blank">
                               Download
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>

             

                </Columns>
            </asp:GridView> 
            </div> 
</div>
    <br />    
        <hr />         
        
                        
       </div>
                         </div>   
                    </div>
               </div>
           </center>
    </div>




</asp:Content>
