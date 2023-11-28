<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/VS2014.IMC/IMC.Master" EnableEventValidation = "false"
    CodeBehind="RPTIMSAssessmentBilling.aspx.vb" Inherits="SPIDC.RPTIMSAssessmentBilling" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <script>
              //SNACKBAR - Welcome       
              function SnackbarGreen() {
                  var x = document.getElementById("snackbargreen");
                  x.className = "show";
                  setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
              }
              function Snackbar() {
                  var x = document.getElementById("snackbar");
                  x.className = "show";
                  setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
              }
    </script>

    
      <div id="snackbar" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbar"/>           
        </div>
        <div id="snackbargreen" style="position:absolute">
            <asp:Label runat="server" id="_oLabelSnackbargreen"/>           
        </div>
        <br /> <br /> <br /> <br />  
       <form name="frmNone" id="frmNone" method="post"></form>
      <div class="container">
        <center> 
          <div class="col-md-7">
           <div class="details">   
                 		                    
  <%--  Assessment Billing  --%>      

  <div id="Slide_01" runat="server"  style="border:1px solid gray; background-color:white; padding:10px; display:block;" ClientIDMode="Static">
		  <strong>Welcome to RPTIMS</strong> 
              <div class="container">  
 
</div>    <hr />
          <div style="background-color:green;color:white;"><strong>Assessment Billing</strong></div>
                         
          <br />
 
            <div class="form-row">              
            <div class="form-group col-md-12">   
            <div class="container">
	        <div class="row">
              
                <div class="form-group col-md-12"  style="text-align:left">Search Account<br />   
                <asp:textbox id="RPTSearch"  runat="server" cssclass="form-control" placeholder="TDN or PIN" onkeyup="Search_Gridview(this)"></asp:textbox>
                </div>

                  <asp:UpdatePanel runat="server">
                     <ContentTemplate>
                     <asp:GridView ID="_oGridViewRPT"  runat="server" CssClass="GridViewStyle "  AllowSorting="true" 
                            AutoGenerateColumns="false"   ShowHeaderWhenEmpty="true" >     

                     <FooterStyle CssClass="GridViewFooterStyle" />
                     <RowStyle CssClass="GridViewRowStyle"  />
                     <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                     <PagerStyle CssClass="GridViewPagerStyle" />
                     <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                     <HeaderStyle CssClass="GridViewHeaderStyle" />
                                             
         <Columns >     

            <asp:TemplateField HeaderText="PIN">
                <ItemTemplate>
                 <asp:Label ID="_oLabelPIN" runat="server" Text='<%# Eval("PIN")%>' />
                </ItemTemplate>
            </asp:TemplateField>    

              <asp:TemplateField HeaderText="TDN">
                <ItemTemplate>
                  <asp:Label ID="_oLabelTDN" runat="server" Text='<%# Eval("TDN")%>' />
                </ItemTemplate>
            </asp:TemplateField>       

              <asp:TemplateField HeaderText="Owner Name">
                <ItemTemplate>
                  <asp:Label ID="_oLabelOWNERNAME" runat="server" Text='<%# Eval("NAME")%>' />
                </ItemTemplate>
              </asp:TemplateField>       
             
             
                 <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                <center>              

                     <a href="#" onclick="Select('Select','<%# Eval("TDN")%>')"  data-toggle="modal" data-target="#SetQuarter" data-ticket-type="standard-access"  title="Select">
 
                    <img border="0" src="../CSS_JS_IMG/img/trackIcon.png" width="20" height="20">                  
                </a>                                   
                &nbsp;&nbsp;&nbsp;</a></center>  
                </ItemTemplate>
              </asp:TemplateField>        
                                                              
        </Columns>

    </asp:GridView>
                      </ContentTemplate>
                  </asp:UpdatePanel>



                  <asp:TextBox 
                    ID="_oTextBoxTDN"  
                    runat="server"              
                    Width="100%" />

         <asp:HiddenField ID="hdnFldSelectedValues" runat="server" />

                <asp:HiddenField runat="server" ID="SelectedAcctNo" />
             <script type="text/javascript">

                 function Select(Action, TDN) {
                     document.getElementById("selectedTDN").value = TDN;
                     //   alert(Action + "-" + document.getElementById("selectedTDN").value);

                     // __doPostBack(Action, ACCTNO);
                 }
                 function Do_Process(Action) {
                     var tdn = document.getElementById("selectedTDN").value;
                     //alert(Action + "-" + tdn);
                     __doPostBack(Action, tdn);
                 }


                 function Search_Gridview(strKey) {
                     var strData = strKey.value.toLowerCase().split(" ");
                     var tblData = document.getElementById("<%=_oGridViewRPT.ClientID%>");
                     var rowData;
                     for (var i = 1; i < tblData.rows.length; i++) {
                         rowData = tblData.rows[i].innerHTML;
                         var styleDisplay = 'none';
                         for (var j = 0; j < strData.length; j++) {
                             if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                                 styleDisplay = '';
                             else {
                                 styleDisplay = 'none';
                                 break;
                             }
                         }
                         tblData.rows[i].style.display = styleDisplay;
                     }
                 }
</script>

              
          
           
                                                         
            </div>
        
   

	</div>

                  </div>        <br /><br />  </div>      
            
            <hr/>		
            
		  <span style="display:flex; justify-content:flex-end; width:100%; padding:0;">  &nbsp  
              <a class="button" href="../VS2014.IMC/Main.aspx">Back</a>           
            
          </span>	 
              		   
		   </div>

    

           </div>
          </div>

             <!-- Modal Set Quarter Form -->     
      <div id="SetQuarter" class="modal fade" >
        <div class="modal-dialog" role="document" >
          <div class="modal-content">
            <div class="modal-header">
              <h4 class="modal-title">Set Quarter and Year</h4>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>          
               <div class="modal-body">                
                <div class="form-group">  

                      <asp:TextBox 
                    ID="_oTextBoxBillingDate" 
                    runat="server" 
                    readonly="true" Visible="false"
                    CssClass="input" 
                    Width="100%" />                              
         
			
	
          
			<input id="RadioQtr1" runat ="server" name="qtr" type="radio" checked/>
			<label for="RadioQtr1">1st Quarter  </label>           
		

		
			<input id="RadioQtr2" runat ="server" name="qtr" type="radio"/>
			<label for="RadioQtr2">2nd Quarter</label>
		 
            <br />
			<input id="RadioQtr3" runat ="server" name="qtr" type="radio"/>
			<label for="RadioQtr3">3rd Quarter  </label>           
		
			<input id="RadioQtr4" runat ="server" name="qtr" type="radio"/>
			<label for="RadioQtr4">4th Quarter</label>
		<br />
            <asp:TextBox ID="_oTextBoxYear" runat="server" MaxLength="4"  placeholder="Year"/>
         
                      
                </div>    
       <input type="hidden" id="selectedTDN" name="selectedTDN" />
               <div class="text-center">                          
                   <button type="button" id="OK" name="OK" class="button" onclick="Do_Process('Process');">Save and Proceed</button>
         
                </div>
           
            
        
          </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
      </div>
      <!-- /.modal -->
 

           <%--  <rsweb:ReportViewer ID="_oMSRV" runat="server" Height="600px" 
                             Width="94%" ZoomMode="PageWidth" >
                          </rsweb:ReportViewer>--%>


         


            <asp:UpdatePanel runat="server">
                <ContentTemplate>


                


             <asp:GridView
                            ID="_oGridViewBillingTemp" runat="server"
                            CssClass="GridViewStyle"
                            AutoGenerateColumns="False"
                            Width="100%"
                            ShowFooter="True"
                            ShowHeaderWhenEmpty="True"
                            BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
                            BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" 
                            Height="16px" >

                             <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />    
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" font-size= "8px"/>
                            <Columns>
                             
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="3%"  HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                    <center>
                                        <asp:Label ID="_oLabelSEQCOUNTER" runat="server"
                                            Text='<%# Eval("SEQCOUNTER")%>' />
                                            </center>
                                    </ItemTemplate>
                                </asp:TemplateField>       

                                <asp:TemplateField HeaderText="NOTE"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Font-Size="10px" HeaderStyle-Width="8%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelOTHER_REMARKS" runat="server"
                                            Text='<%# Eval("OTHER_REMARKS")%>' />
                                    </ItemTemplate>
                                       </asp:TemplateField>            

                                <asp:TemplateField HeaderText="FUND TYPE"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px" HeaderStyle-Width="7%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelFUNDTYPE" runat="server"
                                            Text='<%# Eval("FUNDTYPE")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>  
                                  
                                <asp:TemplateField HeaderText="TDN"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px" HeaderStyle-Width="10%">
                                    <ItemTemplate>
                                    <center>
                                        <asp:Label ID="_oLabelTDN" runat="server"
                                            Text='<%# Eval("TDN")%>' />
                                               </center>
                                    </ItemTemplate>

                                </asp:TemplateField>    

                                <asp:TemplateField HeaderText="TRANS CODE"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px" HeaderStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTRANS_CD" runat="server"
                                            Text='<%# Eval("TRANS_CD")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>    
                                
                                
                                <asp:TemplateField HeaderText="PIN" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px" HeaderStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelPIN" runat="server"
                                            Text='<%# Eval("PIN")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>    

         

                                  <asp:TemplateField HeaderText="LAST COVERED PAID"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px" HeaderStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelLASTCOVEREDPAID" runat="server"
                                            Text='<%# Eval("LASTCOVEREDPAID")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>    
                                

                                <asp:TemplateField HeaderText="LAST AMOUNT PAID"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-Font-Size="10px" HeaderStyle-Width="12%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelLASTAMOUNTPAID" runat="server"
                                            Text='<%# Eval("LASTAMOUNTPAID")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>   
                                 
                                  <asp:TemplateField HeaderText="LAST OR"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px" HeaderStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelLASTOR" runat="server"
                                            Text='<%# Eval("LASTOR")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>    

                                 <asp:TemplateField HeaderText="LAST SRS"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px" HeaderStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelLASTSRS" runat="server"
                                            Text='<%# Eval("LASTSRS")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>    
               
                                <asp:TemplateField HeaderText="LAST OR DATE"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px" HeaderStyle-Width="8%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelLASTORDATES" runat="server"
                                            Text='<%# Eval("LASTORDATE")%>' />
                                    </ItemTemplate>

                                </asp:TemplateField>   

                                 <asp:TemplateField HeaderText="TOTAL AMOUNT"  HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Size="10px"  HeaderStyle-Width="13%">
                                    <ItemTemplate>
                                        <asp:Label ID="_oLabelTOTALAMOUNT" runat="server"
                                            Text='<%# Eval("TOTALAMOUNT")%>' />
                                    </ItemTemplate>

                                    <FooterTemplate>
				                        
				                         <asp:Label ID="_oLabeltotalamount" 
                                             runat="server"                                             
                                             Font-Size="Large"
                                         />
				                      
			                       </FooterTemplate>
 
                                </asp:TemplateField>    

             
             
                            </Columns>             

                           

                        </asp:GridView>
              
     
            </ContentTemplate>
        </asp:UpdatePanel>

        </center>
         
      </div>
       <rsweb:ReportViewer ID="_oMSRV" 
                        runat="server" 
                        Height="600px" Width="100%"
                        ZoomMode ="PageWidth" 
                        Font-Names="Verdana" 
                        Font-Size="8pt" 
                        WaitMessageFont-Names="Verdana" 
                        WaitMessageFont-Size="14pt">
                      </rsweb:ReportViewer>
   
       
</asp:Content>

